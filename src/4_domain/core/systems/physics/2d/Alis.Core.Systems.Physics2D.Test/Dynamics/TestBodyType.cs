// 

using Alis.Core.Systems.Physics2D.Dynamics;
using NUnit.Framework;

namespace Alis.Core.Systems.Physics2D.Test.Dynamics
{
    /// <summary>
    /// The test body type class
    /// </summary>
    public class TestBodyType
    {
        /// <summary>
        /// The body type
        /// </summary>
        private BodyType bodyType;

        /// <summary>
        ///     Setup this instance
        /// </summary>
        [SetUp]
        public void Setup()
        {
            bodyType = BodyType.Dynamic;
        }

        /// <summary>
        ///     Tests that test 1
        /// </summary>
        [Test]
        public void Test1()
        {
            Assert.Pass();
        }
    }
}