using System.Collections.Generic;
using System.Threading.Tasks;
using WeatherInfo.Models;

namespace WeatherInfo
{
    public interface IMeteoDataProvider
    {
        Task<IEnumerable<ClimateMeteoData>> GetClimateMeteoData();
    }
}