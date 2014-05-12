using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EsthR.Tests
{
    [TestClass]
    public class SerializerTests
    {
        [TestMethod]
        public void DeserializerTest()
        {
            var request = Request.FromConfig(@".\testInput\RequestInput.json");

            Assert.IsNotNull(request);
            Assert.IsTrue(request.FormValues.Count == 2);
            Assert.IsTrue(request.Headers[0].Key == "Accept");
        }
    }
}
