
using BusinessEntities;
using DataModel;
using Microsoft.Owin.Testing;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
//using WebApp;
//using WebApi.App_Start;
using Xunit;

namespace WebApiXUnitIntegrationTest
{
    public class ProductControllerTest : IDisposable
    {
        protected TestServer _server;
        private WebApiDbEntities _webApiDbEntities;
        public ProductControllerTest()
        {
            _server = TestServer.Create<Startup>();
            _webApiDbEntities = new WebApiDbEntities();
        }

        [Fact]
        public async void Returns200()
        {
            var result = await _server.HttpClient.GetAsync("api/v1/product/all");
            string responseContent = await result.Content.ReadAsStringAsync();
            var entity = JsonConvert.DeserializeObject<List<ProductEntity>>(responseContent);

            Assert.True(entity.Count == 50);
        }



        public void Dispose()
        {
            _server?.Dispose();
        }
    }
}
