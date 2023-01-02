using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Event.Generator.Dal
{
    public class MongoDbConnection : IMongoDbConnection
    {
        public string ConnectionUri { get; set; }
        public string DatabaseName { get; set; }
        public string CollectionName { get; set; }
    }

    public interface IMongoDbConnection
    {
        string ConnectionUri { get; set; }
        string DatabaseName { get; set; }
        string CollectionName { get; set; }
    }
}
