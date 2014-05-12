using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EsthR.Tests
{
    [TestClass]
    public class FluentTests
    {
        [TestMethod]
        public void RequestChainTest()
        {
            var request = new Request()
                .WithHeader("Accept", "text/json")
                .WithHeader("Authorize", "Bearer toketokentokenee")
                .WithMethod("GET")
                .WithBody("almabeka");

            Assert.AreEqual("GET", request.Method);
            Assert.AreEqual("text/json", request.Headers[0].Value);
        }
    }
}
