using DataAccess.Options;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using System.Linq;
using WeatherInfo.Models;

namespace DataAccess.Impl
{
    public class MongoDbClient
    {
        private readonly MongoDbSettings _settings;
        
        public MongoClient Client { get; private set; }

        public IMongoCollection<ImgwClimateMeteoData> ImgwClimateMeteoDatas => Client.GetDatabase("ImgwMeteoDataDatabase").GetCollection<ImgwClimateMeteoData>("ImgwMeteoDataCollection");
        
        public MongoDbClient(IOptions<MongoDbSettings> options)
        {
            _settings = options.Value;
            Connect();
        }

        private void Connect()
        {
            Client = new MongoClient(_settings.ConnectionString);
        }
    }
}