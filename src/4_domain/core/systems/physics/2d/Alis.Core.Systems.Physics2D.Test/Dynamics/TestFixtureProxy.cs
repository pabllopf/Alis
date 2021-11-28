// 

using Alis.Core.Systems.Physics2D.Dynamics;
using NUnit.Framework;

namespace Alis.Core.Systems.Physics2D.Test.Dynamics
{
    public class TestFixtureProxy
    {
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