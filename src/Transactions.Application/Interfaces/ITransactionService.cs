using Transactions.Domain.Entities;

namespace Transactions.Application.Interfaces
{
    public interface ITransactionService
    {
        Task<bool> AddTransactionAsync(Transaction transaction);
        Task<Transaction> GetTransactionByIdAsync(int id);
    }
}
