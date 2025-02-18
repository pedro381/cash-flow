using Microsoft.Extensions.Logging;
using Transactions.Application.Interfaces;
using Transactions.Domain.Entities;
using Transactions.Infrastructure.Repositories;

namespace Transactions.Application.Services
{
    public class TransactionService : ITransactionService
    {
        private readonly TransactionRepository _transactionRepository;
        private readonly ILogger<TransactionService> _logger;

        public TransactionService(TransactionRepository transactionRepository, ILogger<TransactionService> logger)
        {
            _transactionRepository = transactionRepository;
            _logger = logger;
        }

        public async Task<bool> AddTransactionAsync(Transaction transaction)
        {
            try
            {
                _logger.LogInformation("Attempting to add a new transaction.");
                var result = await _transactionRepository.AddTransactionAsync(transaction);

                if (result)
                {
                    _logger.LogInformation("Transaction added successfully. ID: {Id}", transaction.Id);
                    return true;
                }
                else
                {
                    _logger.LogWarning("Transaction addition failed.");
                    return false;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while adding a transaction.");
                throw;
            }
        }

        public async Task<Transaction> GetTransactionByIdAsync(int id)
        {
            try
            {
                _logger.LogInformation("Fetching transaction by ID: {Id}", id);
                var transaction = await _transactionRepository.GetTransactionByIdAsync(id);

                if (transaction == null)
                {
                    _logger.LogWarning("Transaction not found with ID: {Id}", id);
                }

                return transaction;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while retrieving transaction ID: {Id}", id);
                throw;
            }
        }
    }
}
