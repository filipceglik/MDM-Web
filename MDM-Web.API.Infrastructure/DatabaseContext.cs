using MongoDB.Driver;

namespace MDM_Web.API.Infrastructure
{
    public class DatabaseContext
    {
        private readonly IMongoDatabase _database;

        public DatabaseContext(string connectionString)
        {
            var client = new MongoClient(connectionString);
            _database = client.GetDatabase("MDM");
        }

        public IMongoCollection<TModel> GetCollection<TModel>() => _database.GetCollection<TModel>(typeof(TModel).Name);
    }
}