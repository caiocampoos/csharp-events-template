

using Event.Generator.Domain.Models;

namespace Event.Generator.Application.Interfaces
{
    public interface ITransactionHandler
    {
        Task<Transaction> Execute(Transaction transaction);
    }
}
