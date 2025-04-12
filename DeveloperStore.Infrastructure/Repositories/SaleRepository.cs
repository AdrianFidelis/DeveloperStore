using DeveloperStore.Application.Interfaces;
using DeveloperStore.Domain.Entities;
using DeveloperStore.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace DeveloperStore.Infrastructure.Repositories;

public class SaleRepository : ISaleRepository
{
    private readonly AppDbContext _context;

    public SaleRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(Sale sale)
    {
        await _context.Sales.AddAsync(sale);
        await _context.SaveChangesAsync();
    }

    public async Task<List<Sale>> GetAllAsync()
    {
        return await _context.Sales.Include(s => s.Items).ToListAsync();
    }

    public async Task<Sale?> GetByIdAsync(Guid id)
    {
        return await _context.Sales.Include(s => s.Items).FirstOrDefaultAsync(s => s.Id == id);
    }

    public async Task CancelAsync(Guid id)
    {
        var sale = await _context.Sales.FirstOrDefaultAsync(s => s.Id == id);
        if (sale is null) return;

        sale.Cancel();
        await _context.SaveChangesAsync();
    }
}
