using NUnit.Framework;

namespace UnitTests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            Assert.True(true);
            Assert.Pass();
        }
    }
}