using DataAccess.Repository;

namespace DataAccess.Interfaces
{
    public interface IUnitOfWork
    {
        ImgwClimateMeteDataRepository ImgwClimateMeteDataRepository { get; set; }
    }
}