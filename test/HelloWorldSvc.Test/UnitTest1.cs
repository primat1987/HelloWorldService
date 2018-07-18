using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using Microsoft.Extensions.Configuration;
using HelloWorldSvc.Controllers;

namespace HelloWorldSvc.test
{
    [TestClass]
    public class BasicTest
    {
        [TestMethod]
        public void TestController()
        {
            var controller = new ValuesController();
            var result = controller.Get(2);
            Assert.AreEqual("world", result);
        }
    }
}