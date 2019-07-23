using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Autofac;
using Autofac.Extensions.DependencyInjection;
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
            var meteoFilesScraper = _serviceProvider.GetService<IMeteoFilesScraper>();

            var meteoDataFileUrls = await meteoFilesScraper.GetAllMeteoDataFileUrlsAsync();
            
            DisposeServices();
        }

        private static void RegisterServices()
        {
            _collection = new ServiceCollection();
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