namespace SmartGatex.DataAccess.DbConnection.MongoDb.IDbContext
{
    public interface IMongoDbContext
    {
        public string MongoDbUrl { get; set; }
        public string MongoDbDatabase { get; set; }
    }
}
