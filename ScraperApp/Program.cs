using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Downloader;
using Downloader.Impl;
using Downloader.Interfaces;
using HistoricalWeatherInfo.Scraper;
using HistoricalWeatherInfo.Scraper.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace ScraperApp
{
    class Program
    {
        private static IServiceCollection _collection;
        private static IServiceProvider _serviceProvider;
        
        private static async Task Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            
            RegisterServices();
            var downloader = _serviceProvider.GetService<IDownloader>();
            await downloader.DownloadAndSaveFile(
                "https://dane.imgw.pl/data/dane_pomiarowo_obserwacyjne/dane_meteorologiczne/miesieczne/klimat/1951_1955/1951_1955_m_k.zip",
                @"C:\Users\Michal\Documents\meteo\data.zip");
            
            DisposeServices();
        }

        private static void RegisterServices()
        {
            _collection = new ServiceCollection();
            _collection.AddHttpClient<IDownloader, ImgwMeteoDataDownloader>();
            _serviceProvider = AddAutoFac();
        }

        private static IServiceProvider AddAutoFac()
        {
            var builder = new ContainerBuilder();
            RegisterModules(builder);
            
            builder.Populate(_collection);
        
            var container = builder.Build();
            return new AutofacServiceProvider(container);
        }

        private static void RegisterModules(ContainerBuilder builder)
        {
            foreach (var module in GetModules())
            {
                builder.RegisterModule(module);
            }
        }

        private static IEnumerable<Module> GetModules()
        {
            yield return new ScraperModule();
            yield return new DownladerModule();
        }

        private static void DisposeServices()
        {
            if (_serviceProvider == null)
            {
                return;
            }

            if (_serviceProvider is IDisposable)
            {
                ((IDisposable) _serviceProvider).Dispose();
            }
        }
    }
}