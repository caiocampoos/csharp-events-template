using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Event.Generator.Domain.Models
{
    public class Transaction
    {
        [BsonId]
        public string? Id { get; set; }
        
        [BsonElement("Emiter")]
        public string? Emiter { get; set; }
        
        [BsonElement("TransactionType")]
        public TransactionType Type { get; set; }

        [BsonElement("Amount")]
        public long Amout { get; set; }

        [BsonElement("Notes")]
        public string? Notes { get; set; }
    }
}
