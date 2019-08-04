using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using DataAccess.Interfaces;
using WeatherInfo;
using WeatherInfo.Models;

namespace ScraperApp
{
    public class App
    {
        private readonly IMeteoDataProvider _meteoDataProvider;
        private readonly IUnitOfWork _unitOfWork;

        public App(IMeteoDataProvider meteoDataProvider, IUnitOfWork unitOfWork)
        {
            _meteoDataProvider = meteoDataProvider;
            _unitOfWork = unitOfWork;
        }

        public async Task Run(CancellationToken cancellationToken = default)
        {
            var imgwClimateMeteoDataList = await _meteoDataProvider.GetClimateMeteoDataAsync();
            await _unitOfWork.ImgwClimateMeteDataRepository.AddRangeAsync(imgwClimateMeteoDataList, cancellationToken);
        }
    }
}