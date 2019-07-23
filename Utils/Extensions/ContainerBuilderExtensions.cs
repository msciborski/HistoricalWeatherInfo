using AngleSharp;
using Autofac;

namespace Utils.Extensions
{
    public static class ContainerBuilderExtensions
    {
        public static ContainerBuilder RegisterBrowsingContext(this ContainerBuilder builder,
            IConfiguration configuration = null)
        {
            if (configuration == null)
            {
                configuration = AngleSharp.Configuration.Default.WithDefaultLoader();
            }

            builder
                .RegisterInstance(BrowsingContext.New(configuration))
                .As<IBrowsingContext>()
                .SingleInstance();

            return builder;
        }
    }
}