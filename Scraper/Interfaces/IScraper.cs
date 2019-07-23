using System.Threading.Tasks;
using AngleSharp.Dom;

namespace HistoricalWeatherInfo.Scraper.Interfaces
{
    public interface IScraper
    {
        Task<IDocument> GetDocument(string url);
    }
}