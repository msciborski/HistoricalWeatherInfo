using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using DataAccess.Impl;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using WeatherInfo.Interfaces;
using WeatherInfo.Models;

namespace DataAccess.Repository
{
    public class ImgwClimateMeteDataRepository : IImgwClimateMeteoDataRepository
    {
        private readonly string CollectionName = "ImgwMeteoDataCollection";
        private readonly MongoDbClient _client;

        public ImgwClimateMeteDataRepository(MongoDbClient client)
        {
            _client = client;
        }
        
        public async Task AddAsync(ImgwClimateMeteoData entity, CancellationToken cancellationToken = default)
        {
            var database = _client.Client.GetDatabase("ImgwMeteoDataDatabase");
            var collection = database.GetCollection<ImgwClimateMeteoData>(CollectionName);
            await collection.InsertOneAsync(entity, cancellationToken);
        }

        public async Task AddRangeAsync(IEnumerable<ImgwClimateMeteoData> entities, CancellationToken cancellationToken = default)
        {
            var database = _client.Client.GetDatabase("ImgwMeteoDataDatabase");
            var collection = database.GetCollection<ImgwClimateMeteoData>(CollectionName);
            await collection.InsertManyAsync(entities, null, cancellationToken);
        }

        public async Task<IEnumerable<ImgwClimateMeteoData>> GetMeteoDataBetweenYears(int startYear, int endYear, int pageSize = 100, int pageNumber = 0)
        {
            var database = _client.Client.GetDatabase("ImgwMeteoDataDatabase");
            var collection = database.GetCollection<ImgwClimateMeteoData>(CollectionName).AsQueryable();
            var documentList = await collection.Where(c => c.Year >= startYear && c.Year <= endYear).Skip(pageSize * pageNumber).Take(pageSize).ToListAsync();

            return documentList;
        }

        public async Task<IEnumerable<ImgwClimateMeteoData>> GetMeteoDataForStation(string stationCode,
            int pageSize = 100, int pageNumber = 0)
        {
            var database = _client.Client.GetDatabase("ImgwMeteoDataDatabase");
            var collection = database.GetCollection<ImgwClimateMeteoData>(CollectionName).AsQueryable();
            var documentList = await collection.Where(c => c.StationCode.Equals(stationCode)).Skip(pageSize * pageNumber).Take(pageSize).ToListAsync();
            return documentList;    
        }
    }
}