using System;

namespace WeatherInfo.Models
{
    public class ClimateMeteoData
    {
        public string StationCode { get; set; }
        public string StationName { get; set; }
        public string Year { get; set; }
        public string Month { get; set; }
        public decimal AbsoluteTempMax { get; set; }
        public string AbsoluteTempMaxStatus { get; set; }
        public decimal AverageTempMax { get; set; }
        public string AverageTempMaxStatus { get; set; }
        public decimal AbsoluteTempMin { get; set; }
        public string AbsoluteTempMinStatus { get; set; }
        public decimal AverageTempMin { get; set; }
        public string AverageTempMinStatus { get; set; }
        public decimal AverageMonthlyTemp { get; set; }
        public string AverageMonthlyTempStatus { get; set; }
        public decimal GroundTempMin { get; set; }
        public string GroundTempMinStatus { get; set; }
        public decimal MonthlyFallSum { get; set; }
        public string MonthlyFallSumStatus { get; set; }
        public decimal DailyRainMax { get; set; }
        public string DailyRainMaxStatus { get; set; }
        public int FirstDayWithMaxFall { get; set; }
        public int LastDayWithMaxFall { get; set; }
        public decimal SnowCoverMax { get; set; }
        public string SnowCoverMaxStatus { get; set; }
        public int DayWithSnowCoverCount { get; set; }
        public int DayWithRainCount { get; set; }
        public int DayWithSnowCount { get; set; }
    }
}