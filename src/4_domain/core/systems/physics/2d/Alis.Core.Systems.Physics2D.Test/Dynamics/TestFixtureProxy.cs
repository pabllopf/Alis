// 

using Alis.Core.Systems.Physics2D.Dynamics;
using NUnit.Framework;

namespace Alis.Core.Systems.Physics2D.Test.Dynamics
{
    /// <summary>
    /// The test fixture proxy class
    /// </summary>
    public class TestFixtureProxy
    {
        /// <summary>
        /// The fixture proxy
        /// </summary>
        private FixtureProxy fixtureProxy;

        /// <summary>
        ///     Setup this instance
        /// </summary>
        [SetUp]
        public void Setup()
        {
            fixtureProxy = new FixtureProxy();
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