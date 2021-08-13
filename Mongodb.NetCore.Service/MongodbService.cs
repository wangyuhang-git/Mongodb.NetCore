using Mongodb.NetCore.Common;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Mongodb.NetCore.Service
{
    public class MongodbService<T> where T : class
    {
        public readonly IMongoCollection<T> collection;

        public MongodbService(string collectionName)
        {
            IMongoClient mongoClient = new MongoClient(ConfigHelper.GetSectionValue("ConnectionMongodb:MongodbAddress"));
            IMongoDatabase mongoDatabase = mongoClient.GetDatabase(ConfigHelper.GetSectionValue("ConnectionMongodb:MongodbName"));
            collection = mongoDatabase.GetCollection<T>(collectionName);
        }

        public async Task<T> GetAsync(Expression<Func<T, bool>> expression)
        {
            var fullCollection = await collection.FindAsync(expression);
            return await fullCollection.FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<T>> GetListAsync(Func<T, bool> func)
        {
            var list = collection.AsQueryable().Where(func);
            return await Task.FromResult(list);
        }

        public async Task<T> AddAsync(T t)
        {
            await collection.InsertOneAsync(t);
            return t;
        }

        public async Task AddManyAsync(IEnumerable<T> list)
        {
            await collection.InsertManyAsync(list);
        }
    }
}
