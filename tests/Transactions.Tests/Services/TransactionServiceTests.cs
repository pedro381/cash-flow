using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging.Abstractions;
using Transactions.Application.Services;
using Transactions.Domain.Entities;
using Transactions.Domain.Enums;
using Transactions.Infrastructure.Database;
using Transactions.Infrastructure.Repositories;

namespace Transactions.Tests.Services
{
    public class TransactionServiceTests : IDisposable
    {
        private readonly ApplicationDbContext _context;
        private readonly TransactionRepository _repository;
        private readonly TransactionService _service;

        public TransactionServiceTests()
        {
            // Create a unique in-memory database for each test
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;
            _context = new ApplicationDbContext(options);

            // Use NullLogger for testing purposes
            _repository = new TransactionRepository(_context, NullLogger<TransactionRepository>.Instance);
            _service = new TransactionService(_repository, NullLogger<TransactionService>.Instance);
        }

        [Fact]
        public async Task AddTransactionAsync_Should_AddTransactionSuccessfully()
        {
            // Arrange
            var transaction = new Transaction
            {
                Amount = 100m,
                Date = DateTime.UtcNow,
                Type = TransactionType.Credit
            };

            // Act
            var result = await _service.AddTransactionAsync(transaction);

            // Assert
            Assert.True(result);
            var retrieved = await _context.Transactions.FirstOrDefaultAsync(t => t.Id == transaction.Id);
            Assert.NotNull(retrieved);
            Assert.Equal(transaction.Amount, retrieved.Amount);
        }

        [Fact]
        public async Task GetTransactionByIdAsync_Should_ReturnTransaction_WhenExists()
        {
            // Arrange
            var transaction = new Transaction
            {
                Amount = 200m,
                Date = DateTime.UtcNow,
                Type = TransactionType.Debit
            };

            // Add transaction directly via repository to set it up in the database
            await _repository.AddTransactionAsync(transaction);

            // Act
            var retrieved = await _service.GetTransactionByIdAsync(transaction.Id);

            // Assert
            Assert.NotNull(retrieved);
            Assert.Equal(transaction.Amount, retrieved.Amount);
        }

        [Fact]
        public async Task GetTransactionByIdAsync_Should_ReturnNull_WhenTransactionDoesNotExist()
        {
            // Act
            var retrieved = await _service.GetTransactionByIdAsync(9999);

            // Assert
            Assert.Null(retrieved);
        }

        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}
