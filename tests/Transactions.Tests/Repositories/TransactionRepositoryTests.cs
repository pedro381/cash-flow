using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;
using Transactions.Domain.Entities;
using Transactions.Domain.Enums;
using Transactions.Infrastructure.Database;
using Transactions.Infrastructure.Repositories;

namespace Transactions.Tests.Repositories
{
    public class TransactionRepositoryTests
    {
        private readonly TransactionRepository _repository;
        private readonly ApplicationDbContext _context;
        private readonly Mock<ILogger<TransactionRepository>> _loggerMock;

        public TransactionRepositoryTests()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;

            _context = new ApplicationDbContext(options);
            _loggerMock = new Mock<ILogger<TransactionRepository>>();
            _repository = new TransactionRepository(_context, _loggerMock.Object);
        }

        [Fact]
        public async Task GetTransactionByIdAsync_ShouldReturnTransaction_WhenExists()
        {
            // Arrange
            var transaction = new Transaction { Id = 1, Amount = 100, Type = TransactionType.Credit, Date = DateTime.UtcNow };
            _context.Transactions.Add(transaction);
            await _context.SaveChangesAsync();

            // Act
            var result = await _repository.GetTransactionByIdAsync(1);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(1, result.Id);
            Assert.Equal(100, result.Amount);
        }

        [Fact]
        public async Task GetTransactionByIdAsync_ShouldReturnNull_WhenNotFound()
        {
            // Act
            var result = await _repository.GetTransactionByIdAsync(999);

            // Assert
            Assert.Null(result);
        }

        [Fact]
        public async Task AddTransactionAsync_ShouldReturnTrue_WhenSuccessful()
        {
            // Arrange
            var transaction = new Transaction { Id = 2, Amount = 200, Type = TransactionType.Debit, Date = DateTime.UtcNow };

            // Act
            var result = await _repository.AddTransactionAsync(transaction);

            // Assert
            Assert.True(result);
        }
    }
}
