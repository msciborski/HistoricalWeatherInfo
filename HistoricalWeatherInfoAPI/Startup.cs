using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Autofac;
using DataAccess;
using DataAccess.Options;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using WeatherInfo;
using Module = Autofac.Module;

namespace HistoricalWeatherInfoAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.Configure<MongoDbSettings>(Configuration.GetSection("MongoDbSettings"));
            services.AddMediatR(GetAssemblies().ToArray());
        }
        
        public void ConfigureContainer(ContainerBuilder builder)
        {
            foreach (var module in GetModules())
            {
                builder.RegisterModule(module);
            }
        }

        public IEnumerable<Module> GetModules()
        {
            yield return new WeatherInfoModule();
            yield return new DataAccessModule();
        }

        public IEnumerable<Assembly> GetAssemblies()
        {
            yield return typeof(WeatherInfoModule).GetTypeInfo().Assembly;
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {

            app.UseMvc();
        }
    }
}