using MongoDB.Bson.Serialization.Attributes;
using SmartGatex.Entity.Abstrack;
namespace SmartGatex.Entity.Concrete
{
    public class Cams:IBaseEntity
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string Id { get; set; }
        public string SerialNumber { get; set; }
        public string Model { get; set; }
        public string  Brand { get; set; }
        public string Description { get; set; }
        public string CustomerId { get; set; }
    }
}
