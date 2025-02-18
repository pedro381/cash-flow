namespace Consolidation.Application.Interfaces
{
    public interface IConsolidationService
    {
        Task<IEnumerable<Domain.Entities.Consolidation>> GetAllAsync();
        Task<Domain.Entities.Consolidation> GetByIdAsync(int id);
        Task AddAsync(Domain.Entities.Consolidation consolidation);
        Task UpdateAsync(Domain.Entities.Consolidation consolidation);
        Task DeleteAsync(int id);
    }
}
