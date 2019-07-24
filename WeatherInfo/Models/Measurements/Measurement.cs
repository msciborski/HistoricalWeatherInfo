namespace WeatherInfo.Models.Measurements
{
    public abstract class Measurement
    {
        public decimal Value { get; set; }
        public string Status { get; set; }
    }
}