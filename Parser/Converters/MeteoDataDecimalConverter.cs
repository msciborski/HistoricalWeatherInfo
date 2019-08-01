using System;
using System.Globalization;
using TinyCsvParser.Extensions;
using TinyCsvParser.TypeConverter;

namespace HistoricalWeatherInfo.Parser.Converters
{
    public class MeteoDataDecimalConverter : NonNullableConverter<decimal>
    {
        protected override bool InternalConvert(ReadOnlySpan<char> value, out decimal result)
        {
            if (value.StartsWith("."))
            {
                var newValue = "0" + value.ToString();
                return decimal.TryParse(newValue, NumberStyles.Number, CultureInfo.InvariantCulture, out result);
            }
            else if (value.StartsWith("-."))
            {
                var valueWithoutMinusSign = value.ToString().Substring(1);
                var newValue = "-0" + valueWithoutMinusSign; 
                return decimal.TryParse(value, NumberStyles.Number, CultureInfo.InvariantCulture, out result);
            }
            else
            {
                return decimal.TryParse(value, NumberStyles.Number, CultureInfo.InvariantCulture, out result);
            }
        }
    }
}