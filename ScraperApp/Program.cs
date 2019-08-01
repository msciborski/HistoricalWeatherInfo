using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Downloader;
using Downloader.Impl;
using Downloader.Interfaces;
using FileService;
using HistoricalWeatherInfo.Parser;
using HistoricalWeatherInfo.Scraper;
using HistoricalWeatherInfo.Scraper.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using WeatherInfo;
using WeatherInfo.Models;

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
            var meteoDataProvider = _serviceProvider.GetService<IMeteoDataProvider>();
            try
            {
                var x = await meteoDataProvider.GetClimateMeteoData();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;        
            }
            

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

            builder.RegisterType<MeteoDataFromFileProvider>()
                .As<IMeteoDataProvider>();
            
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
            yield return new ParserModule();
            yield return new FileServiceModule();
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