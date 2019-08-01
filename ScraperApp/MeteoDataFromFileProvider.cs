using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Downloader.Interfaces;
using HistoricalWeatherInfo.Parser;
using HistoricalWeatherInfo.Scraper.Interfaces;
using WeatherInfo;
using WeatherInfo.Models;

namespace ScraperApp
{
    public class MeteoDataFromFileProvider : IMeteoDataProvider
    {
        private readonly IMeteoFilesScraper _scraper;
        private readonly IDownloader _downloader;
        private readonly IMeteoDataParser<ClimateMeteoData> _parser;

        public MeteoDataFromFileProvider(IMeteoFilesScraper scraper, IDownloader downloader, IMeteoDataParser<ClimateMeteoData> parser)
        {
            _scraper = scraper;
            _downloader = downloader;
            _parser = parser;
        }
        public async Task<IEnumerable<ClimateMeteoData>> GetClimateMeteoData()
        {
            var climateMeteoDataList = new List<ClimateMeteoData>();
            var meteoDataFileUrls = await _scraper.GetAllMeteoDataFileUrlsAsync();
            foreach (var meteoDataFileUrl in meteoDataFileUrls)
            {
                climateMeteoDataList.AddRange(await GetClimateMeteoDataFromFiles(meteoDataFileUrl.Url, "k_m_d.*"));

            }

            return climateMeteoDataList;
        }

        private IEnumerable<ClimateMeteoData> GetClimateMeteoDataFromStream(Stream file)
        {
            return _parser.GetMeteoData(file);
        }

        private async Task<IEnumerable<ClimateMeteoData>> GetClimateMeteoDataFromFiles(string url, string fileNamePattern)
        {
            var climateMeteoDataList = new List<ClimateMeteoData>();
            var zipedFiles = await _downloader.DownloadFile(url);
            using (var zip = new ZipArchive(zipedFiles, ZipArchiveMode.Read))
            {
                foreach (var entry in zip.Entries)
                {
                    if (Regex.IsMatch(entry.Name, fileNamePattern))
                    {
                        var stream = entry.Open();
                        climateMeteoDataList.AddRange(GetClimateMeteoDataFromStream(stream));
                    }
                }

                return climateMeteoDataList;
            }
        }
    }
}