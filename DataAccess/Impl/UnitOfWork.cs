using WeatherInfo;
using WeatherInfo.Interfaces;

namespace DataAccess.Impl
{
    public class UnitOfWork : IMeteoDataUnitOfWork
    {

        public UnitOfWork(IImgwClimateMeteoDataRepository imgwClimateMeteoDataRepository)
        {
            ImgwClimateMeteDataRepository = imgwClimateMeteoDataRepository;
        }

        public IImgwClimateMeteoDataRepository ImgwClimateMeteDataRepository { get; set; }
    }
}