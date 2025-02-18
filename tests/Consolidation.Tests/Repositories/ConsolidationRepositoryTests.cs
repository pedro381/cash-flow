using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging.Abstractions;
using Consolidation.Domain.Enums;
using Consolidation.Infrastructure.Database;
using Consolidation.Infrastructure.Repositories;

namespace Consolidation.Tests.Repositories
{
    public class ConsolidationRepositoryTests : IDisposable
    {
        private readonly ApplicationDbContext _context;
        private readonly ConsolidationRepository _repository;

        public ConsolidationRepositoryTests()
        {
            // Create a unique in-memory database for each test
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;
            _context = new ApplicationDbContext(options);
            _repository = new ConsolidationRepository(_context, NullLogger<ConsolidationRepository>.Instance);
        }

        [Fact]
        public async Task AddAsync_Should_Add_Consolidation_Successfully()
        {
            // Arrange
            var consolidation = new Domain.Entities.Consolidation
            {
                Date = DateTime.UtcNow,
                TotalCredits = 200m,
                TotalDebits = 100m,
                Balance = 100m,
                Type = ConsolidationType.Daily
            };

            // Act
            await _repository.AddAsync(consolidation);

            // Assert
            var addedConsolidation = await _context.Consolidations.FindAsync(consolidation.Id);
            Assert.NotNull(addedConsolidation);
            Assert.Equal(consolidation.Balance, addedConsolidation.Balance);
        }

        [Fact]
        public async Task GetAllAsync_Should_Return_All_Consolidations()
        {
            // Arrange
            var consolidation1 = new Domain.Entities.Consolidation
            {
                Date = DateTime.UtcNow,
                TotalCredits = 300m,
                TotalDebits = 150m,
                Balance = 150m,
                Type = ConsolidationType.Daily
            };
            var consolidation2 = new Domain.Entities.Consolidation
            {
                Date = DateTime.UtcNow.AddDays(1),
                TotalCredits = 400m,
                TotalDebits = 100m,
                Balance = 300m,
                Type = ConsolidationType.Daily
            };
            await _repository.AddAsync(consolidation1);
            await _repository.AddAsync(consolidation2);

            // Act
            var allConsolidations = await _repository.GetAllAsync();

            // Assert
            Assert.NotNull(allConsolidations);
            Assert.True(allConsolidations.Count() >= 2);
        }

        [Fact]
        public async Task GetByIdAsync_Should_Return_Consolidation_When_Exists()
        {
            // Arrange
            var consolidation = new Domain.Entities.Consolidation
            {
                Date = DateTime.UtcNow,
                TotalCredits = 500m,
                TotalDebits = 200m,
                Balance = 300m,
                Type = ConsolidationType.Daily
            };
            await _repository.AddAsync(consolidation);

            // Act
            var result = await _repository.GetByIdAsync(consolidation.Id);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(consolidation.Id, result.Id);
        }

        [Fact]
        public async Task UpdateAsync_Should_Update_Consolidation_Successfully()
        {
            // Arrange
            var consolidation = new Domain.Entities.Consolidation
            {
                Date = DateTime.UtcNow,
                TotalCredits = 600m,
                TotalDebits = 300m,
                Balance = 300m,
                Type = ConsolidationType.Daily
            };
            await _repository.AddAsync(consolidation);

            // Act
            consolidation.TotalCredits = 700m;
            consolidation.Balance = 400m;
            await _repository.UpdateAsync(consolidation);

            // Assert
            var updatedConsolidation = await _repository.GetByIdAsync(consolidation.Id);
            Assert.Equal(700m, updatedConsolidation.TotalCredits);
            Assert.Equal(400m, updatedConsolidation.Balance);
        }

        [Fact]
        public async Task DeleteAsync_Should_Delete_Consolidation_Successfully()
        {
            // Arrange
            var consolidation = new Domain.Entities.Consolidation
            {
                Date = DateTime.UtcNow,
                TotalCredits = 800m,
                TotalDebits = 300m,
                Balance = 500m,
                Type = ConsolidationType.Daily
            };
            await _repository.AddAsync(consolidation);

            // Act
            await _repository.DeleteAsync(consolidation.Id);

            // Assert
            var deleted = await _repository.GetByIdAsync(consolidation.Id);
            Assert.Null(deleted);
        }

        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}
