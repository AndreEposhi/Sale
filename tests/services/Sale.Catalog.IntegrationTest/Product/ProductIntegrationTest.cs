using Sale.Catalog.Api;
using Sale.Catalog.Api.Application.Product.Command;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace Sale.Catalog.IntegrationTest.Product
{
    public class ProductIntegrationTest : IntegrationTestBase
    {
        public ProductIntegrationTest(TestingWebAppFactory<Startup> factory) : base(factory)
        { }

        [Fact]
        [Trait("Catalog.Products", "Add")]
        public async Task MustAddProduct()
        {
            //Arrange
            var product = new AddProductCommand("Celular Xiaomi Redmine 9", 2500);
            var productJson = System.Text.Json.JsonSerializer.Serialize(product);
            var httpContent = new StringContent(productJson, System.Text.Encoding.UTF8, "application/json");

            //Act
            var response = await _client.PostAsync("products/add", httpContent);

            //Assert
            response.EnsureSuccessStatusCode();
        }

        [Fact]
        [Trait("Catalog.Products", "GetAll")]
        public async Task MustReturnAllProducts()
        {
            //Act
            var response = await _client.GetAsync("products/list");

            //Asset
            response.EnsureSuccessStatusCode();
        }
    }
}