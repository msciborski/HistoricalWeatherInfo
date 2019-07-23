using AngleSharp;
using Autofac;
using HistoricalWeatherInfo.Scraper.Impl;
using HistoricalWeatherInfo.Scraper.Interfaces;
using Utils.Extensions;

namespace HistoricalWeatherInfo.Scraper
{
    public class ScraperModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder
                .RegisterBrowsingContext(AngleSharp.Configuration.Default.WithDefaultLoader());

            builder
                .RegisterType<HistoricalWeatherInfo.Scraper.Impl.Scraper>()
                .As<IScraper>();

            builder
                .RegisterType<ImgwMeteoFilesScraper>()
                .As<IMeteoFilesScraper>();
            
            base.Load(builder);
        }
    }
}