using WeatherInfo.Interfaces;

namespace WeatherInfo
{
    public interface IMeteoDataUnitOfWork
    {
        IImgwClimateMeteoDataRepository ImgwClimateMeteDataRepository { get; }

    }
}