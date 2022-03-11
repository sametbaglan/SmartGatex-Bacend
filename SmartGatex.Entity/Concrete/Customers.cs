using MongoDB.Bson.Serialization.Attributes;
using SmartGatex.Entity.Abstrack;

namespace SmartGatex.Entity.Concrete
{
    public class Customers:IBaseEntity
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string CustomerName { get; set; }
        public string Userid { get; set; }
    }
}
