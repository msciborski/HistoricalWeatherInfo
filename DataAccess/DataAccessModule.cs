using Autofac;


namespace DataAccess
{
    public class DataAccessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
//            builder.RegisterType<MongoDbClient>().As<MongoDbClient>().SingleInstance();
//            builder.RegisterType<ImgwClimateMeteDataRepository>()
//                .As<IImgwClimateMeteoDataRepository>()
//                .As<IRepository<ImgwClimateMeteoData>>();
//
//            builder.RegisterType<UnitOfWork>()
//                .As<IUnitOfWork>();
            
            base.Load(builder);
        }

    }
}