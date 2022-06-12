using NUnit.Framework;
using Alis;

namespace Alis.Test.Unit
{
    /// <summary>
    /// The tests class
    /// </summary>
    public class Tests
    {
        /// <summary>
        /// Setup this instance
        /// </summary>
        [SetUp]
        public void Setup()
        {
        }

        /// <summary>
        /// Tests that test 1
        /// </summary>
        [Test]
        public void Test1()
        {
            Assert.AreEqual(Example.Sum(4, 4), 8);
        }
    }
}