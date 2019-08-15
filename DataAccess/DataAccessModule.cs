using Autofac;
using DataAccess.Impl;
using DataAccess.Repository;
using WeatherInfo;
using WeatherInfo.Interfaces;


namespace DataAccess
{
    public class DataAccessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<MongoDbClient>()
                .As<MongoDbClient>()
                .SingleInstance();

            builder.RegisterType<ImgwClimateMeteDataRepository>()
                .As<IImgwClimateMeteoDataRepository>()
                .InstancePerDependency();

            builder.RegisterType<UnitOfWork>()
                .As<IMeteoDataUnitOfWork>()
                .InstancePerDependency();

            base.Load(builder);
        }
    }
}