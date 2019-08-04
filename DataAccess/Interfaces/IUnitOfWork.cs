using DataAccess.Repository;
using DataAccess.Repository.Interfaces;

namespace DataAccess.Interfaces
{
    public interface IUnitOfWork
    {
        IImgwClimateMeteoDataRepository ImgwClimateMeteDataRepository { get; set; }
    }
}