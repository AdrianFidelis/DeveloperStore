using DeveloperStore.Application.DTOs;
using DeveloperStore.Application.Interfaces;
using DeveloperStore.Domain.Entities;

public class SaleService : ISaleService
{
    private readonly ISaleRepository _repository;

    public SaleService(ISaleRepository repository)
    {
        _repository = repository;
    }

    public async Task<Sale> CreateSaleAsync(SaleDto saleDto)
    {
        var sale = new Sale(saleDto.SaleNumber, saleDto.SaleDate, saleDto.Customer, saleDto.Branch);

        foreach (var itemDto in saleDto.Items)
        {
            var item = new SaleItem(itemDto.ProductId, itemDto.ProductDescription, itemDto.Quantity, itemDto.UnitPrice);
            sale.AddItem(item);
        }

        await _repository.AddAsync(sale);
        return sale;
    }

    public Task<List<Sale>> GetAllAsync() => _repository.GetAllAsync();

    public Task<Sale?> GetByIdAsync(Guid id) => _repository.GetByIdAsync(id);

    public Task CancelAsync(Guid id) => _repository.CancelAsync(id);
}
