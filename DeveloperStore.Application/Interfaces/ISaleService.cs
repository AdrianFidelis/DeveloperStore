using DeveloperStore.Domain.Entities;
using DeveloperStore.Application.DTOs;

namespace DeveloperStore.Application.Interfaces;

public interface ISaleService
{
    Task<Sale> CreateSaleAsync(SaleDto saleDto);
    Task<List<Sale>> GetAllAsync();
    Task<Sale?> GetByIdAsync(Guid id);
    Task CancelAsync(Guid id);
}
