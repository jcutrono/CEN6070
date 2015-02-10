using MongoDB.Driver;

namespace CEN6070.Data
{
    public abstract class DataStore
    {
        protected readonly MongoDatabase Database;

        protected DataStore()
        {
            MongoClient client = new MongoClient();
            MongoServer server = client.GetServer();
            Database = server.GetDatabase("CEN6070");
        }
    }
}
