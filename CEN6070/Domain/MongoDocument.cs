using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace CEN6070.Domain
{
    public class MongoDocument
    {
        [BsonId]
        public ObjectId Id { get; set; }
    }
}
