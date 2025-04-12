namespace DeveloperStore.Domain.Entities;

public class Sale
{
    public Guid Id { get; private set; } = Guid.NewGuid();
    public string SaleNumber { get; private set; }
    public DateTime SaleDate { get; private set; }
    public string Customer { get; private set; }
    public string Branch { get; private set; }
    public List<SaleItem> Items { get; private set; } = new();
    public decimal TotalSale { get; private set; }
    public bool IsCancelled { get; private set; }

    public Sale(string saleNumber, DateTime saleDate, string customer, string branch)
    {
        SaleNumber = saleNumber;
        SaleDate = saleDate;
        Customer = customer;
        Branch = branch;
    }

    public void AddItem(SaleItem item)
    {
        Items.Add(item);
        RecalculateTotal();
    }

    public void RecalculateTotal()
    {
        TotalSale = Items.Sum(i => i.Total);
    }

    public void Cancel()
    {
        IsCancelled = true;
    }

    public void Update(string customer, string branch)
    {
        Customer = customer;
        Branch = branch;
    }

    public void CancelItem(Guid itemId)
    {
        var item = Items.FirstOrDefault(i => i.Id == itemId);
        if (item != null)
        {
            Items.Remove(item);
            RecalculateTotal();
        }
    }
}
