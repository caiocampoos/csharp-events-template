

using Event.Generator.Application.Interfaces;
using Event.Generator.Dal;
using Event.Generator.Domain.Models;
using Event.Generator.Services.RabbitMqService.Interfaces;

namespace Event.Generator.Application
{
    public class TransactionHandler : ITransactionHandler
    {
        private readonly MongoDbCommands _database;
        private readonly IEventProducer _eventProducer;
        public TransactionHandler(MongoDbCommands dbcommands, IEventProducer eventProducer) 
        {
            _database = dbcommands;
            _eventProducer = eventProducer;
        }
        public Task<Transaction> Execute(Transaction transaction)
        {   
            try
            {
                var trans =  _database.Create(transaction);
                
                if (Task.FromResult(trans).IsCompleted) { 
                    
                    _eventProducer.SendMessage(transaction);
                
                }

                              
              
                return Task.FromResult(trans);
            }
            catch (Exception ex) {

                return (Task<Transaction>)Task.FromException(ex);
            }

        }
    }
}
