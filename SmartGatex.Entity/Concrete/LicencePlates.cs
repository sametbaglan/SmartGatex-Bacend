using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using SmartGatex.Entity.Abstrack;

namespace SmartGatex.Entity.Concrete
{
    public class LicencePlates:IBaseEntity
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string LicencePlate { get; set; }
        public string Userid { get; set; }
    }
}
