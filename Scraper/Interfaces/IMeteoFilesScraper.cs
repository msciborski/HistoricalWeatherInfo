using System.Collections.Generic;
using System.Threading.Tasks;
using AngleSharp.Dom;
using HistoricalWeatherInfo.Scraper.Models;

namespace HistoricalWeatherInfo.Scraper.Interfaces
{
    public interface IMeteoFilesScraper
    {
        Task<IEnumerable<MeteoDataFileUrl>> GetAllMeteoDataFileUrlsAsync();
    }
}