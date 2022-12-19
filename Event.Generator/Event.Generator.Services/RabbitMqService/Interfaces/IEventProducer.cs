using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Event.Generator.Services.RabbitMqService.Interfaces
{
    public interface IEventProducer
    {
        void SendMessage<T> (T message);
    }
}
