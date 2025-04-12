using DeveloperStore.Domain.Entities;

namespace DeveloperStore.Application.Interfaces;

public interface ISaleRepository
{
    Task AddAsync(Sale sale);
    Task<List<Sale>> GetAllAsync();
    Task<Sale?> GetByIdAsync(Guid id);
    Task CancelAsync(Guid id);
}
