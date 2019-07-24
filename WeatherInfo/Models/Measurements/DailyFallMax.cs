namespace WeatherInfo.Models.Measurements
{
    public class DailyFallMax : Measurement
    {
        public int FirstDayWithMaxFall { get; set; }
        public int LastDayWithMaxFall { get; set; }
    }
}