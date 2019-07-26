using TinyCsvParser.Mapping;
using WeatherInfo.Models;

namespace HistoricalWeatherInfo.Parser.Impl
{
    public class ClimateMeteoDataParserMapping : CsvMapping<ClimateMeteoData>
    {
        public ClimateMeteoDataParserMapping()
            : base()
        {
            MapProperty(0, c => c.StationCode);
            MapProperty(1, c => c.StationName);
            MapProperty(2, c => c.Year);
            MapProperty(3, c => c.Month);
            MapProperty(4, c => c.AbsoluteTempMax.Value);
            MapProperty(5, c => c.AbsoluteTempMax.Status);
            MapProperty(6, c => c.AverageTempMax.Value);
            MapProperty(7, c => c.AverageTempMax.Status);
            MapProperty(8, c => c.AbsoluteTempMin.Value);
            MapProperty(9, c => c.AbsoluteTempMin.Status);
            MapProperty(10, c => c.AverageTempMin.Value);
            MapProperty(11, c => c.AverageTempMin.Status);
            MapProperty(12, c => c.AverageTempMontly.Value);
            MapProperty(13, c => c.AverageTempMontly.Status);
            MapProperty(14, c => c.GroundTempMin.Value);
            MapProperty(15, c => c.GroundTempMin.Status);
            MapProperty(16, c => c.MonthlyFallSum.Value);
            MapProperty(17, c => c.MonthlyFallSum.Status);
            MapProperty(18, c => c.DailyFallMax.Value);
            MapProperty(19, c => c.DailyFallMax.Status);
            MapProperty(20, c => c.DailyFallMax.FirstDayWithMaxFall);
            MapProperty(21, c => c.DailyFallMax.LastDayWithMaxFall);
            MapProperty(22, c => c.SnowCoverMax.Value);
            MapProperty(23, c => c.SnowCoverMax.Status);
            MapProperty(24, c => c.DayCountWiithSnowCover);
            MapProperty(25, c => c.DayCountWithSnow);
            MapProperty(26, c => c.DayCountWithRain);
        }
    }
}