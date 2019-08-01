using DataAccess.Options;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace DataAccess.Impl
{
    public class MongoDbClient
    {
        private readonly MongoDbSettings _settings;
        
        public MongoClient Client { get; private set; }
        
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