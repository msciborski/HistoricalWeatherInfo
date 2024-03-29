using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using AngleSharp.Dom;
using HistoricalWeatherInfo.Scraper.Interfaces;
using HistoricalWeatherInfo.Scraper.Models;
using Utils;

namespace HistoricalWeatherInfo.Scraper.Impl
{
    public class ImgwMeteoFilesScraper : IMeteoFilesScraper
    {
        private readonly string _folderNameRegexTemplate = @"(\d{4}_\d{4}\/)|(^\d{4}\/)";
        private readonly string _dateRegex = @"\d{4}-\d{2}-\d{2} \d{2}:\d{2}";
        private readonly string _zipRegex = ".+.zip";
        
        private readonly IScraper _scraper;

        public ImgwMeteoFilesScraper(IScraper scraper)
        {
            _scraper = scraper;
        }

        public async Task<IEnumerable<MeteoDataFileUrl>> GetAllMeteoDataFileUrlsAsync()
        {
            var root = await GetRootDocumentAsync(Paths.MeteoData);
            
            var meteoDataFileUrls = new List<MeteoDataFileUrl>();
            
            var directoryInfo = GetAllMeteoDataFilesDirectories(root);
            
            foreach (var meteoDataFileDirectory in directoryInfo)
            {
                meteoDataFileUrls.Add(await GetMeteoDataFileUrlAsync(meteoDataFileDirectory));
            }

            return meteoDataFileUrls;
        }
        
        private IEnumerable<MeteoDataFileDirectory> GetAllMeteoDataFilesDirectories(IDocument root)
        {
            var rowsWithDirectories = GetRowsWithMeteoData(root, _folderNameRegexTemplate);
            return GetMetoeDataFileDirectoriesFromRows(rowsWithDirectories);
        }

        //TODO: Exception handling, throwing exception when for file directory there is no file. When there is no date, set DateTime.Now
        private async Task<MeteoDataFileUrl> GetMeteoDataFileUrlAsync(MeteoDataFileDirectory fileDirectory)
        {
            var root = await GetRootDocumentAsync(fileDirectory.DirectoryUrl);

            var rowWithMeteoDataZip = GetRowsWithMeteoData(root, _zipRegex).FirstOrDefault();


            if (rowWithMeteoDataZip != null)
            {
                var anchorNode = GetChildAnchorNode(rowWithMeteoDataZip, _zipRegex);
                var dateNode = GetChildAnchorNode(rowWithMeteoDataZip, _dateRegex);

                if (anchorNode != null && dateNode != null)
                {
                    var meteoDataFileUrl = new MeteoDataFileUrl(
                        anchorNode.TextContent, 
                        $"{anchorNode.BaseUri}{anchorNode.TextContent}", 
                        DateTime.Parse(dateNode.TextContent));

                    return meteoDataFileUrl;
                }
            }

            return null;
        }

        private INode GetChildAnchorNode(IElement parent, string regexPattern)
        {
            return parent
                .Children?
                .FirstOrDefault(c => Regex.IsMatch(c.TextContent, regexPattern))?
                .FirstChild;
        }
        
        private IEnumerable<IElement> GetRowsWithMeteoData(IDocument root, string patternForChilds)
        {
            var rows = root.QuerySelectorAll("tbody tr");
            var rowsWithDirectories = new HashSet<IElement>();
            
            rows.Aggregate(rowsWithDirectories,
                (set, element) =>
                {
                    var isRowWithDirectory = element.Children.Any(c => Regex.IsMatch(c.TextContent, patternForChilds));

                    if (isRowWithDirectory)
                    {
                        set.Add(element);
                    }
                    
                    return set;
                });

            return rowsWithDirectories;
        }

        private IEnumerable<MeteoDataFileDirectory> GetMetoeDataFileDirectoriesFromRows(IEnumerable<IElement> rows)
        {
            var meteoDataDirectories = new List<MeteoDataFileDirectory>();

            rows.Aggregate(meteoDataDirectories,
                (list, element) =>
                {
                    var anchorNode = GetChildAnchorNode(element, _folderNameRegexTemplate);
                    var dateNode = GetChildAnchorNode(element, _dateRegex);

                        if (anchorNode != null && dateNode != null)
                    {
                        var meteoDataFileDirectory = new MeteoDataFileDirectory();
                        meteoDataFileDirectory.DirectoryUrl = $"{anchorNode.BaseUri}{anchorNode.TextContent}";
                        meteoDataFileDirectory.ModifyDate = DateTime.Parse(dateNode.TextContent);
                        
                        list.Add(meteoDataFileDirectory);
                    }
                    
                    return list;
                });

            return meteoDataDirectories;
        }
        
        private async Task<IDocument> GetRootDocumentAsync(string url)
        {
            return await _scraper.GetDocument(url);
        }
    }
}