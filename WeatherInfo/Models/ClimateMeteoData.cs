using System;
using WeatherInfo.Models.Measurements;

namespace WeatherInfo.Models
{
    public class ClimateMeteoData
    {
        public string StationCode { get; set; }
        public string StationName { get; set; }
        public int Year { get; set; }
        public int Month { get; set; }
        public AbsoluteTempMax AbsoluteTempMax { get; set; }
        public AbsoluteTempMin AbsoluteTempMin { get; set; }
        public AverageTempMax AverageTempMax { get; set; }
        public AverageTempMin AverageTempMin { get; set; }
        public AverageTempMontly AverageTempMontly { get; set; }
        public GroundTempMin GroundTempMin { get; set; }
        public DailyFallMax DailyFallMax { get; set; }
        public MonthlyFallSum MonthlyFallSum { get; set; }
        public SnowCoverMax SnowCoverMax { get; set; }
        public int DayCountWithSnow { get; set; }
        public int DayCountWithRain { get; set; }
        public int DayCountWiithSnowCover { get; set; }
    }
}