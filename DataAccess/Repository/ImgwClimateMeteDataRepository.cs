using DataAccess.Impl;
using DataAccess.Repository.Interfaces;
using WeatherInfo.Models;

namespace DataAccess.Repository
{
    public class ImgwClimateMeteDataRepository : IImgwClimateMeteoDataRepository
    {
        private readonly MongoDbClient _client;

        public ImgwClimateMeteDataRepository(MongoDbClient client)
        {
            _client = client;
        }
        
        public void Add(ImgwClimateMeteoData entity)
        {
            throw new System.NotImplementedException();
        }
    }
}