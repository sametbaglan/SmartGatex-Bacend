using MongoDB.Bson;
using MongoDB.Driver;
using SmartGatex.DataAccess.Abstrack;
using SmartGatex.DataAccess.DbConnection.MongoDb.DbContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SmartGatex.DataAccess.Concrete
{
    public class RepositoryDesignDal<T> : IRepositoryDesign<T> where T : class, new()
    {
        private IMongoCollection<T> db { get; }
        public RepositoryDesignDal(string collection)
        {
            MongoDbContext context = new MongoDbContext();
            var mongoClient = new MongoClient(context.MongoDbUrl);
            var mongoDatabase = mongoClient.GetDatabase(context.MongoDbDatabase);
            db = mongoDatabase.GetCollection<T>(collection);
            db.AsQueryable(new AggregateOptions { AllowDiskUse = true });
        }
        public Task<List<T>> GetAllAsync(Expression<Func<T, bool>> filter = null, FindOptions<T, T> orderBy = null, string includeProperties = null)
        {
            if (filter != null)
                if (orderBy != null)
                    return db.FindAsync<T>(filter, orderBy).Result.ToListAsync();
                else
                    return db.FindAsync<T>(filter).Result.ToListAsync();

            else if (orderBy != null)

                return db.FindAsync(new BsonDocument(), orderBy).Result.ToListAsync();

            else
                return db.FindAsync(new BsonDocument()).Result.ToListAsync();
        }

        public Task<T> GetByIdAsync(Expression<Func<T, bool>> filter, FindOptions<T, T> orderBy = null)
        {
            if (filter != null)
                if (orderBy != null)
                    return db.FindAsync<T>(filter, orderBy).Result.FirstOrDefaultAsync();
                else
                    return db.FindAsync<T>(filter).Result.FirstOrDefaultAsync();
            else return null;
        }

        public async Task<T> AddAsync(T entity)
        {
            await db.InsertOneAsync(entity);
            return entity;
        }

        public bool Update(T entity, Expression<Func<T, bool>> filter)
        {
            try
            {
                return db.ReplaceOneAsync(filter, entity).Result.MatchedCount > 0 ? true : false;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
