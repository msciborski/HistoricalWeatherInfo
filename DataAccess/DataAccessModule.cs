using Autofac;
using DataAccess.Impl;
using DataAccess.Interfaces;
using DataAccess.Repository;
using DataAccess.Repository.Interfaces;
using MongoDB.Driver;
using WeatherInfo.Models;

namespace DataAccess
{
    public class DataAccessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<MongoClient>().AsSelf();
            builder.RegisterType<ImgwClimateMeteDataRepository>()
                .As<IRepository<ImgwClimateMeteoData>>();

            builder.RegisterType<UnitOfWork>()
                .As<IUnitOfWork>();
            
            base.Load(builder);
        }

    }
}