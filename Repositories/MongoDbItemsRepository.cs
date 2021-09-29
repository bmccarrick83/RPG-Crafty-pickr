using System;
using System.Collections.Generic;
using RPG_Crafty_pickr.Entitities;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Threading.Tasks;

namespace RPG_Crafty_pickr.Repositories.IItemsRepository
{
    public class MongoDbItemsRepository : IItemsRepository
    {
        private const string databaseName = "catalog";
        private const string collectionName = "items";
        private readonly IMongoCollection<Items> itemsCollection;
        private readonly FilterDefinitionBuilder<Items> filterBuilder = Builders<Items>.Filter;


    public MongoDbItemsRepository(IMongoClient mongoClient)
    {
       
        IMongoDatabase database = mongoClient.GetDatabase(databaseName);
  
        itemsCollection = database.GetCollection<Items>(collectionName);

    }
        public async Task CreateItemAsync(Items item)
        {
            await itemsCollection.InsertOneAsync(item);
        }
        public async Task DeleteItemAsync(Guid id)
        {
            var filter = filterBuilder.Eq(item => item.Id, id);
            await itemsCollection.DeleteOneAsync(filter);
        }

        public async Task<Items> GetItemAsync(Guid id)
        {
            var filter = filterBuilder.Eq(item => item.Id, id);
            return await itemsCollection.Find(filter).SingleOrDefaultAsync();
        }

        public async Task<IEnumerable<Items>> GetItemsAsync()
        {
            return await itemsCollection.Find(new BsonDocument()).ToListAsync();
        }

        public async Task UpdateItemAsync(Items item)
        {
            var filter = filterBuilder.Eq(existingItem => existingItem.Id, item.Id);
            await itemsCollection.ReplaceOneAsync(filter, item);
        }
    }
}
