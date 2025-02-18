using Consolidation.Application.Interfaces;
using Consolidation.Infrastructure.Repositories;
using Microsoft.Extensions.Logging;

namespace Consolidation.Application.Services
{
    public class ConsolidationService : IConsolidationService
    {
        private readonly ConsolidationRepository _repository;
        private readonly ILogger<ConsolidationService> _logger;

        public ConsolidationService(ConsolidationRepository repository, ILogger<ConsolidationService> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public async Task<IEnumerable<Domain.Entities.Consolidation>> GetAllAsync()
        {
            try
            {
                return await _repository.GetAllAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving all consolidations.");
                throw;
            }
        }

        public async Task<Domain.Entities.Consolidation> GetByIdAsync(int id)
        {
            try
            {
                return await _repository.GetByIdAsync(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error retrieving consolidation with ID {id}.");
                throw;
            }
        }

        public async Task AddAsync(Domain.Entities.Consolidation consolidation)
        {
            try
            {
                await _repository.AddAsync(consolidation);
                _logger.LogInformation("Domain.Entities.Consolidation added successfully.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error adding consolidation.");
                throw;
            }
        }

        public async Task UpdateAsync(Domain.Entities.Consolidation consolidation)
        {
            try
            {
                await _repository.UpdateAsync(consolidation);
                _logger.LogInformation($"Domain.Entities.Consolidation with ID {consolidation.Id} updated successfully.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error updating consolidation with ID {consolidation.Id}.");
                throw;
            }
        }

        public async Task DeleteAsync(int id)
        {
            try
            {
                await _repository.DeleteAsync(id);
                _logger.LogInformation($"Domain.Entities.Consolidation with ID {id} deleted successfully.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error deleting consolidation with ID {id}.");
                throw;
            }
        }
    }
}
