using Event.Generator.Domain.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Event.Generator.Dal
{
    public class MongoDbCommands 
    {
        private readonly IMongoCollection<Transaction> _transactions;

        public MongoDbCommands(
        IOptions<MongoDbConnection> settings)
        {
            var mongoClient = new MongoClient(
            settings.Value.ConnectionUri);

            var mongoDatabase = mongoClient.GetDatabase(
                settings.Value.DatabaseName);

            _transactions = mongoDatabase.GetCollection<Transaction>(
                settings.Value.CollectionName);
        }

        public Transaction Create(Transaction transaction)
        {
            _transactions.InsertOneAsync(transaction);
            return transaction;
        }
    }
}
