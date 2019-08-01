using Autofac;
using HistoricalWeatherInfo.Parser.Impl;
using TinyCsvParser;
using WeatherInfo.Models;

namespace HistoricalWeatherInfo.Parser
{
    public class ParserModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.Register<ImgwMeteoDataParser>(c =>
                {
                    var options = new CsvParserOptions(true, ',');

                    return new ImgwMeteoDataParser(new CsvParser<ImgwClimateMeteoData>(options,
                        new ClimateMeteoDataParserMapping()));
                })
                .As<IMeteoDataParser<ImgwClimateMeteoData>>();
            
            base.Load(builder);
        }
    }
}