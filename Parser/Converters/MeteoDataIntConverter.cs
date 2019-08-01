using System;
using System.Globalization;
using TinyCsvParser.TypeConverter;

namespace HistoricalWeatherInfo.Parser.Converters
{
    public class MeteoDataIntConverter : Int32Converter
    {
        public MeteoDataIntConverter(IFormatProvider formatProvider) 
            : base(formatProvider)
        {
        }

        public MeteoDataIntConverter(IFormatProvider formatProvider, NumberStyles numberStyles) 
            : base(formatProvider, numberStyles)
        {
        }

        public override bool TryConvert(ReadOnlySpan<char> value, out int result)
        {
            if (value.IsEmpty)
            {
                result = 0;
                return true;
            }

            return base.TryConvert(value, out result);
        }
    }
}