namespace DeveloperStore.Application.DTOs;

public class SaleItemDto
{
    public Guid ProductId { get; set; }
    public string ProductDescription { get; set; }
    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; }
}

public class SaleDto
{
    public string SaleNumber { get; set; }
    public DateTime SaleDate { get; set; }
    public string Customer { get; set; }
    public string Branch { get; set; }
    public List<SaleItemDto> Items { get; set; }
}
