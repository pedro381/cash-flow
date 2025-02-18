using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Threading.Tasks;
using Transactions.Domain.Entities;
using Transactions.Infrastructure.Database;

namespace Transactions.Infrastructure.Repositories
{
    public class TransactionRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<TransactionRepository> _logger;

        public TransactionRepository(ApplicationDbContext context, ILogger<TransactionRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<Transaction> GetTransactionByIdAsync(int id)
        {
            try
            {
                _logger.LogInformation("Fetching transaction by ID: {Id}", id);

                var transaction = await _context.Transactions
                    .Where(t => t.Id == id)
                    .FirstOrDefaultAsync();

                if (transaction == null)
                {
                    _logger.LogWarning("No transaction found with ID: {Id}", id);
                }

                return transaction;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while fetching transaction with ID: {Id}", id);
                throw;
            }
        }

        public async Task<bool> AddTransactionAsync(Transaction transaction)
        {
            try
            {
                _logger.LogInformation("Adding a new transaction to the database.");

                await _context.Transactions.AddAsync(transaction);
                await _context.SaveChangesAsync();

                _logger.LogInformation("Transaction successfully added. ID: {Id}", transaction.Id);
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while adding transaction.");
                return false;
            }
        }
    }
}
