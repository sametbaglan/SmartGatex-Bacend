using MongoDB.Bson.Serialization.Attributes;
using SmartGatex.Entity.Abstrack;
using MongoDB.Bson;
namespace SmartGatex.Entity.Concrete
{
    public class Users:IBaseEntity
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        [BsonElement("Email")]
        public string Email { get; set; }
        [BsonElement("Password")]
        public string Password { get; set; }
        [BsonElement("CustomerId")]
        public string CustomerId { get; set; }
    }
}
