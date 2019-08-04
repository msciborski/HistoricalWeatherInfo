using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using DataAccess;
using DataAccess.Options;
using Downloader;
using Downloader.Impl;
using Downloader.Interfaces;
using FileService;
using HistoricalWeatherInfo.Parser;
using HistoricalWeatherInfo.Scraper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WeatherInfo;
using IConfiguration = Microsoft.Extensions.Configuration.IConfiguration;

namespace ScraperApp
{
    class Program
    {
        private static IServiceCollection _collection;
        private static IServiceProvider _serviceProvider;
        private static IConfiguration _configuration;

        private static async Task Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            
            AddAppSettings();
            RegisterServices();
            await _serviceProvider.GetService<App>().Run();

            DisposeServices();
        }

        private static void RegisterServices()
        {
            _collection = new ServiceCollection();

            _collection.AddHttpClient<IDownloader, ImgwMeteoDataDownloader>();
            _collection.AddOptions();
            _collection.Configure<MongoDbSettings>(_configuration.GetSection(nameof(MongoDbSettings)));
            _serviceProvider = AddAutoFac();
        }

        private static IServiceProvider AddAutoFac()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<MeteoDataFromFileProvider>()
                .As<IMeteoDataProvider>();
            builder.RegisterType<App>()
                .AsSelf();

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

        private static void AddAppSettings()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .AddEnvironmentVariables();
            _configuration = builder.Build();

        }

        private static IEnumerable<Module> GetModules()
        {
            yield return new ScraperModule();
            yield return new DownladerModule();
            yield return new ParserModule();
            yield return new FileServiceModule();
            yield return new DataAccessModule();
            
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