using SmartGatex.DataAccess.DbConnection.MongoDb.IDbContext;

namespace SmartGatex.DataAccess.DbConnection.MongoDb.DbContracts
{
    public class MongoDbContext : IMongoDbContext
    {
        public string MongoDbUrl { get; set; }
        public string MongoDbDatabase { get; set; }
        public MongoDbContext()
        {
            MongoDbDatabase = "SmartGatexDb";
            MongoDbUrl = "mongodb://cariousrs:cariodatabases781@96.74.198.5:27889/?authSource=admin&readPreference=primary&appname=MongoDB%20Compass&ssl=false";
        }
    }
}
