namespace DeveloperStore.Domain.Entities;

public class SaleItem
{
    public Guid Id { get; private set; } = Guid.NewGuid();
    public Guid ProductId { get; private set; }
    public string ProductDescription { get; private set; }
    public int Quantity { get; private set; }
    public decimal UnitPrice { get; private set; }
    public decimal Discount { get; private set; }
    public decimal Total { get; private set; }

    // ✅ EF Core exige esse construtor sem parâmetros
    public SaleItem() { }

    // ✅ Nome dos parâmetros iguais às propriedades
    public SaleItem(Guid productId, string productDescription, int quantity, decimal unitPrice)
    {
        ProductId = productId;
        ProductDescription = productDescription;
        Quantity = quantity;
        UnitPrice = unitPrice;

        ApplyDiscount();
        CalculateTotal();
    }

    private void ApplyDiscount()
    {
        if (Quantity > 20)
            throw new Exception("Não é permitido vender mais que 20 unidades do mesmo produto.");

        if (Quantity >= 10)
            Discount = 0.20m;
        else if (Quantity >= 4)
            Discount = 0.10m;
        else
            Discount = 0;
    }

    private void CalculateTotal()
    {
        Total = Quantity * UnitPrice * (1 - Discount);
    }
}
