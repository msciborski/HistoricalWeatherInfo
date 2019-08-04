using System;
using System.Threading.Tasks;
using AngleSharp;
using AngleSharp.Browser;
using AngleSharp.Dom;
using HistoricalWeatherInfo.Scraper.Interfaces;
using Utils;

namespace HistoricalWeatherInfo.Scraper.Impl
{
    public class Scraper : IScraper
    {
        private readonly IBrowsingContext _browsingContext;

        public Scraper(IBrowsingContext browsingContext)
        {
            _browsingContext = browsingContext;
        }
        public async Task<IDocument> GetDocument(string url)
        {
            var foundBrowsingContext = _browsingContext.FindChild(url);

            if (foundBrowsingContext == null)
            {
                var newBrowsingContext = _browsingContext.CreateChild(url, Sandboxes.None);
                // When I'm using await, it doesn't work, this is temporary solution
                var openedDocument = await newBrowsingContext.OpenAsync(url);
                return openedDocument;
            }

            return await foundBrowsingContext.OpenAsync(url);
        }
    }
}