using Sale.Catalog.Api;
using System.Net.Http;
using Xunit;

namespace Sale.Catalog.IntegrationTest
{
    public class IntegrationTestBase : IClassFixture<TestingWebAppFactory<Startup>>
    {
        protected readonly HttpClient _client;
        public IntegrationTestBase(TestingWebAppFactory<Startup> factory)
        {
            _client = factory.CreateClient();
            _client.BaseAddress = new System.Uri("https://localhost:5001/api/");
        }
    }
}