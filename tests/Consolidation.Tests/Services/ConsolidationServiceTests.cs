using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging.Abstractions;
using Consolidation.Application.Services;
using Consolidation.Domain.Enums;
using Consolidation.Infrastructure.Database;
using Consolidation.Infrastructure.Repositories;

namespace Consolidation.Tests.Services
{
    public class ConsolidationServiceTests : IDisposable
    {
        private readonly ApplicationDbContext _context;
        private readonly ConsolidationRepository _repository;
        private readonly ConsolidationService _service;

        public ConsolidationServiceTests()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;
            _context = new ApplicationDbContext(options);

            _repository = new ConsolidationRepository(_context, NullLogger<ConsolidationRepository>.Instance);
            _service = new ConsolidationService(_repository, NullLogger<ConsolidationService>.Instance);
        }

        [Fact]
        public async Task AddConsolidationAsync_Should_AddConsolidationSuccessfully()
        {
            // Arrange
            var consolidation = new Domain.Entities.Consolidation
            {
                Date = DateTime.UtcNow,
                TotalCredits = 100m,
                TotalDebits = 50m,
                Balance = 50m,
                Type = ConsolidationType.Daily
            };

            // Act
            await _service.AddAsync(consolidation);

            // Assert
            var retrieved = await _context.Consolidations.FirstOrDefaultAsync(c => c.Id == consolidation.Id);
            Assert.NotNull(retrieved);
            Assert.Equal(consolidation.TotalCredits, retrieved.TotalCredits);
            Assert.Equal(consolidation.TotalDebits, retrieved.TotalDebits);
            Assert.Equal(consolidation.Balance, retrieved.Balance);
            Assert.Equal(consolidation.Type, retrieved.Type);
        }

        [Fact]
        public async Task GetConsolidationByIdAsync_Should_ReturnConsolidation_WhenExists()
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

            await _repository.AddAsync(consolidation);

            // Act
            var retrieved = await _service.GetByIdAsync(consolidation.Id);

            // Assert
            Assert.NotNull(retrieved);
            Assert.Equal(consolidation.TotalCredits, retrieved.TotalCredits);
        }

        [Fact]
        public async Task GetConsolidationByIdAsync_Should_ReturnNull_WhenNotFound()
        {
            // Act
            var retrieved = await _service.GetByIdAsync(9999);

            // Assert
            Assert.Null(retrieved);
        }

        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}
