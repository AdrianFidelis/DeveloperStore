using DeveloperStore.Domain.Entities;
using System;
using Xunit;

namespace DeveloperStore.Tests.Unit
{
    public class SaleTests
    {
        [Fact]
        public void AddItem_ShouldIncreaseTotal_WithCorrectDiscount()
        {
            var sale = new Sale("V001", DateTime.Now, "Cliente A", "Filial 1");
            var item = new SaleItem(Guid.NewGuid(), "Produto X", 10, 100); // 20% desconto

            sale.AddItem(item);

            Assert.Equal(800, sale.TotalSale); // 1000 - 20%
        }

        [Fact]
        public void Cancel_ShouldSetIsCancelledTrue()
        {
            var sale = new Sale("V002", DateTime.Now, "Cliente B", "Filial 2");
            sale.Cancel();

            Assert.True(sale.IsCancelled);
        }

        [Fact]
        public void Update_ShouldChangeCustomerAndBranch()
        {
            var sale = new Sale("V003", DateTime.Now, "Cliente C", "Filial 3");
            sale.Update("Cliente Novo", "Filial Nova");

            Assert.Equal("Cliente Novo", sale.Customer);
            Assert.Equal("Filial Nova", sale.Branch);
        }

        [Fact]
        public void CancelItem_ShouldRemoveItemAndRecalculateTotal()
        {
            var item1 = new SaleItem(Guid.NewGuid(), "Produto A", 10, 100); // 800
            var item2 = new SaleItem(Guid.NewGuid(), "Produto B", 3, 50);   // 150

            var sale = new Sale("V004", DateTime.Now, "Cliente D", "Filial 4");
            sale.AddItem(item1);
            sale.AddItem(item2);

            sale.CancelItem(item2.Id);

            Assert.Single(sale.Items);
            Assert.Equal(item1.Total, sale.TotalSale);
        }

        [Fact]
        public void AddItem_ShouldThrowException_IfQuantityExceedsLimit()
        {
            var sale = new Sale("V005", DateTime.Now, "Cliente E", "Filial 5");

            Assert.Throws<Exception>(() =>
                sale.AddItem(new SaleItem(Guid.NewGuid(), "Produto C", 21, 10))
            );
        }
    }
}