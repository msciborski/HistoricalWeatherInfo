using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using DataAccess.Impl;
using DataAccess.Repository.Interfaces;
using MongoDB.Bson;
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
            var database = _client.Client.GetDatabase("ImgwMeteoData");
            var collection = database.GetCollection<ImgwClimateMeteoData>(CollectionName);
            await collection.InsertOneAsync(entity, cancellationToken);
        }

        public async Task AddRangeAsync(IEnumerable<ImgwClimateMeteoData> entities, CancellationToken cancellationToken = default)
        {
            var database = _client.Client.GetDatabase("ImgwMeteoData");
            var collection = database.GetCollection<ImgwClimateMeteoData>(CollectionName);
            await collection.InsertManyAsync(entities, null, cancellationToken);

        }
    }
}