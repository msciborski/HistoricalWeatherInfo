using DataAccess.Interfaces;
using DataAccess.Repository;
using DataAccess.Repository.Interfaces;
using WeatherInfo.Models;

namespace DataAccess.Impl
{
    public class UnitOfWork : IUnitOfWork
    {

        public UnitOfWork(ImgwClimateMeteDataRepository imgwClimateMeteoDataRepository)
        {
            ImgwClimateMeteDataRepository = imgwClimateMeteoDataRepository;
        }

        public ImgwClimateMeteDataRepository ImgwClimateMeteDataRepository { get; set; }
    }
}