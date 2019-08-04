using DataAccess.Interfaces;
using DataAccess.Repository;
using DataAccess.Repository.Interfaces;
using WeatherInfo.Models;

namespace DataAccess.Impl
{
    public class UnitOfWork : IUnitOfWork
    {

        public UnitOfWork(IImgwClimateMeteoDataRepository imgwClimateMeteoDataRepository)
        {
            ImgwClimateMeteDataRepository = imgwClimateMeteoDataRepository;
        }

        public IImgwClimateMeteoDataRepository ImgwClimateMeteDataRepository { get; set; }
    }
}