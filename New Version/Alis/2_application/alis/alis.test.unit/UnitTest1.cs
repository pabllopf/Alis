using NUnit.Framework;
using Alis;

namespace Alis.Test.Unit
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
            Assert.AreEqual(Example.Sum(4, 4), 8);
        }
    }
}