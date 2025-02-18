using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Consolidation.Infrastructure.Database;

namespace Consolidation.Infrastructure.Repositories
{
    public class ConsolidationRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<ConsolidationRepository> _logger;

        public ConsolidationRepository(ApplicationDbContext context, ILogger<ConsolidationRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        // Retrieves all consolidations
        public async Task<IEnumerable<Domain.Entities.Consolidation>> GetAllAsync()
        {
            try
            {
                return await _context.Consolidations.ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error fetching all consolidations.");
                throw;
            }
        }

        // Retrieves a consolidation by its ID
        public async Task<Domain.Entities.Consolidation> GetByIdAsync(int id)
        {
            try
            {
                return await _context.Consolidations.FindAsync(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error fetching consolidation with ID {id}.");
                throw;
            }
        }

        // Adds a new consolidation
        public async Task AddAsync(Domain.Entities.Consolidation consolidation)
        {
            try
            {
                await _context.Consolidations.AddAsync(consolidation);
                await _context.SaveChangesAsync();
                _logger.LogInformation("Consolidation added successfully.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error adding consolidation.");
                throw;
            }
        }

        // Updates an existing consolidation
        public async Task UpdateAsync(Domain.Entities.Consolidation consolidation)
        {
            try
            {
                _context.Consolidations.Update(consolidation);
                await _context.SaveChangesAsync();
                _logger.LogInformation($"Consolidation with ID {consolidation.Id} updated successfully.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error updating consolidation with ID {consolidation.Id}.");
                throw;
            }
        }

        // Deletes a consolidation by its ID
        public async Task DeleteAsync(int id)
        {
            try
            {
                var consolidation = await _context.Consolidations.FindAsync(id);
                if (consolidation == null)
                {
                    _logger.LogWarning($"Consolidation with ID {id} not found for deletion.");
                    return;
                }

                _context.Consolidations.Remove(consolidation);
                await _context.SaveChangesAsync();
                _logger.LogInformation($"Consolidation with ID {id} deleted successfully.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error deleting consolidation with ID {id}.");
                throw;
            }
        }
    }
}
