using System.Collections.Generic;
using System.IO;

namespace HistoricalWeatherInfo.Parser
{
    public interface IMeteoDataParser<TEntity> where TEntity : class
    {
        IEnumerable<TEntity> GetMeteoData(string path);
        IEnumerable<TEntity> GetMeteoData(Stream stream);
    }
}