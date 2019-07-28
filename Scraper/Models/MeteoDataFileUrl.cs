using System;
using System.IO;

namespace HistoricalWeatherInfo.Scraper.Models
{
    public class MeteoDataFileUrl
    {
        public string Url { get; private set; }
        public string FileName { get; private set; }
        public string Extension { get; private set; }
        public DateTime ModfiedAt { get; set; }

        public MeteoDataFileUrl(string fileName, string url, DateTime modifiedAt)
        {
            ModfiedAt = modifiedAt;
            FileName = Path.GetFileName(fileName);
            Extension = Path.GetExtension(fileName);
            Url = url;

        }
        
        
    }
}