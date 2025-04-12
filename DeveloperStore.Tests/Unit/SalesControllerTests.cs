using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;
using DeveloperStore.Application.DTOs;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;

namespace DeveloperStore.Tests.Integration
{
    public class SalesControllerTests : IClassFixture<WebApplicationFactory<DeveloperStore.API.Program>>
    {
        private readonly HttpClient _client;

        public SalesControllerTests(WebApplicationFactory<DeveloperStore.API.Program> factory)
        {
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task PostSale_ShouldReturnCreated()
        {
            var sale = new SaleDto
            {
                SaleNumber = "VENDA_INTEG_001",
                SaleDate = DateTime.UtcNow,
                Customer = "Adrian Test",
                Branch = "Teste",
                Items = new List<SaleItemDto>
                {
                    new SaleItemDto
                    {
                        ProductId = Guid.NewGuid(),
                        ProductDescription = "Produto Teste",
                        Quantity = 10,
                        UnitPrice = 100
                    }
                }
            };

            var response = await _client.PostAsJsonAsync("/api/sales", sale);
            response.EnsureSuccessStatusCode();
            Assert.Equal(System.Net.HttpStatusCode.Created, response.StatusCode);
        }

        [Fact]
        public async Task GetAllSales_ShouldReturnOk()
        {
            var response = await _client.GetAsync("/api/sales");
            response.EnsureSuccessStatusCode();
            Assert.Equal(System.Net.HttpStatusCode.OK, response.StatusCode);
        }
    }
}
