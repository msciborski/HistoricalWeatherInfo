using Autofac;
using FileService.Interfaces;

namespace FileService
{
    public class FileServiceModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<Impl.FileService>()
                .As<IFileService>();
            
            base.Load(builder);
        }
    }
}