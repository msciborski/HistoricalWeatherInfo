using System.Collections.Generic;
using System.Threading.Tasks;
using Utils.Interfaces;
using WeatherInfo.Models;

namespace WeatherInfo.Interfaces
{
    public interface IImgwClimateMeteoDataRepository : IRepository<ImgwClimateMeteoData>
    {
        Task<IEnumerable<ImgwClimateMeteoData>> GetMeteoDataForStation(string stationCode,
            int pageSize = 100, int pageNumber = 0);
        Task<IEnumerable<ImgwClimateMeteoData>> GetMeteoDataBetweenYears(int startYear, int endYear, int pageSize = 100, int pageNumber = 0);
    }
}