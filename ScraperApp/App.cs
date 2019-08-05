using System.Threading;
using System.Threading.Tasks;
using WeatherInfo;

namespace ScraperApp
{
    public class App
    {
        private readonly IMeteoDataProvider _meteoDataProvider;
        private readonly IMeteoDataUnitOfWork _unitOfWork;

        public App(IMeteoDataProvider meteoDataProvider, IMeteoDataUnitOfWork unitOfWork)
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