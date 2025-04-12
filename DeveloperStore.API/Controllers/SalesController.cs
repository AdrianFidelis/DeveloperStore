// SaleController.cs (em DeveloperStore.API/Controllers)
using DeveloperStore.Application.Interfaces;
using DeveloperStore.Application.DTOs;
using DeveloperStore.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace DeveloperStore.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SalesController : ControllerBase
    {
        private readonly ISaleService _saleService;

        public SalesController(ISaleService saleService)
        {
            _saleService = saleService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateSale([FromBody] SaleDto saleDto)
        {
            var sale = await _saleService.CreateSaleAsync(saleDto);
            Console.WriteLine($"Evento: VendaCriada | Id: {sale.Id} | Total: {sale.TotalSale}");
            return CreatedAtAction(nameof(GetById), new { id = sale.Id }, sale);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var sales = await _saleService.GetAllAsync();
            return Ok(sales);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var sale = await _saleService.GetByIdAsync(id);
            if (sale == null) return NotFound();
            return Ok(sale);
        }

        [HttpPut("{id}/cancel")]
        public async Task<IActionResult> Cancel(Guid id)
        {
            await _saleService.CancelAsync(id);
            Console.WriteLine($"Evento: VendaCancelada | Id: {id}");
            return NoContent();
        }

        [HttpPut("{id}/edit")]
        public async Task<IActionResult> Edit(Guid id, [FromBody] SaleDto updatedSaleDto)
        {
            var sale = await _saleService.GetByIdAsync(id);
            if (sale == null) return NotFound();

            sale.Update(updatedSaleDto.Customer, updatedSaleDto.Branch);
            Console.WriteLine($"Evento: VendaAlterada | Id: {id}");

            return Ok(sale);
        }

        [HttpPut("{saleId}/items/{itemId}/cancel")]
        public async Task<IActionResult> CancelItem(Guid saleId, Guid itemId)
        {
            var sale = await _saleService.GetByIdAsync(saleId);
            if (sale == null) return NotFound();

            sale.CancelItem(itemId);
            Console.WriteLine($"Evento: ItemCancelado | SaleId: {saleId} | ItemId: {itemId}");

            return Ok(sale);
        }
    }
}