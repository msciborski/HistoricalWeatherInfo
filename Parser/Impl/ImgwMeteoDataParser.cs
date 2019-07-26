using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using TinyCsvParser;
using WeatherInfo.Models;

namespace HistoricalWeatherInfo.Parser.Impl
{
    public class ImgwMeteoDataParser : IMeteoDataParser<ClimateMeteoData>
    {
        private readonly ICsvParser<ClimateMeteoData> _csvParser;

        public ImgwMeteoDataParser(ICsvParser<ClimateMeteoData> csvParser)
        {
            _csvParser = csvParser;
        }
        
        public IEnumerable<ClimateMeteoData> GetMeteoData(string path)
        {
            using (var fileStream = new FileStream(path, FileMode.Open, FileAccess.Read))
            {
                GetMeteoData(fileStream);
            }

            return null;
        }
        
        public IEnumerable<ClimateMeteoData> GetMeteoData(Stream stream)
        {
            return _csvParser.Parse(stream).Select(c => c.Result);
        }


    }
}