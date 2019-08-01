using System.Globalization;
using HistoricalWeatherInfo.Parser.Converters;
using TinyCsvParser.Mapping;
using TinyCsvParser.TypeConverter;
using WeatherInfo.Models;

namespace HistoricalWeatherInfo.Parser.Impl
{
    public class ClimateMeteoDataParserMapping : CsvMapping<ImgwClimateMeteoData>
    {
        public ClimateMeteoDataParserMapping()
        {
            MapProperty(0, x => x.StationCode);
            MapProperty(1, x => x.StationName);
            MapProperty(2, x => x.Year);
            MapProperty(3, x => x.Month);
            MapProperty(4, x => x.AbsoluteTempMax, new MeteoDataDecimalConverter());
            MapProperty(5, x => x.AbsoluteTempMaxStatus);
            MapProperty(6, x => x.AverageTempMax, new MeteoDataDecimalConverter());
            MapProperty(7, x => x.AverageTempMinStatus);
            MapProperty(8, x => x.AbsoluteTempMin, new MeteoDataDecimalConverter());
            MapProperty(9, x => x.AbsoluteTempMinStatus);
            MapProperty(10, x => x.AverageTempMin, new MeteoDataDecimalConverter());
            MapProperty(11, x => x.AverageTempMinStatus);
            MapProperty(12, x => x.AverageMonthlyTemp, new MeteoDataDecimalConverter());
            MapProperty(13, x => x.AverageMonthlyTempStatus);
            MapProperty(14, x => x.GroundTempMin, new MeteoDataDecimalConverter());
            MapProperty(15, x => x.GroundTempMinStatus);
            MapProperty(16, x => x.MonthlyFallSum, new MeteoDataDecimalConverter());
            MapProperty(17, x => x.MonthlyFallSumStatus);
            MapProperty(18, x => x.DailyRainMax, new MeteoDataDecimalConverter());
            MapProperty(19, x => x.DailyRainMaxStatus);
            MapProperty(20, x => x.FirstDayWithMaxFall, new MeteoDataIntConverter(CultureInfo.InvariantCulture, NumberStyles.Number));
            MapProperty(21, x => x.LastDayWithMaxFall, new MeteoDataIntConverter(CultureInfo.InvariantCulture, NumberStyles.Number));
            MapProperty(22, x => x.SnowCoverMax, new MeteoDataDecimalConverter());
            MapProperty(23, x => x.SnowCoverMaxStatus);
            MapProperty(24, x => x.DayWithSnowCoverCount, new MeteoDataIntConverter(CultureInfo.InvariantCulture, NumberStyles.Number));
            MapProperty(25, x => x.DayWithRainCount, new MeteoDataIntConverter(CultureInfo.InvariantCulture, NumberStyles.Number));
            MapProperty(26, x => x.DayWithSnowCount, new MeteoDataIntConverter(CultureInfo.InvariantCulture, NumberStyles.Number));
        }
    }
}