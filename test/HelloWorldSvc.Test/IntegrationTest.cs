using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HelloWorldSvc.Test
{
    /// <summary>
    /// a set of test cases that checks the basic
    /// 
    /// </summary>
    [TestClass]
    public class IntegrationTests
    {
        private HttpClient _client;
        private WebApplicationFactory<Startup> _factory;
        
        [TestInitialize]
        public void Init()
        {
            _factory = new WebApplicationFactory<Startup>();
            _client = _factory.CreateClient();
        }

        [TestMethod]
        public async Task TesValuesGet()
        {
            var response = await _client.GetAsync("/api/v1/values/");
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            var resultBody = await response.Content.ReadAsStringAsync();
            Assert.IsTrue(resultBody.Contains("world"));
        }
    }
}