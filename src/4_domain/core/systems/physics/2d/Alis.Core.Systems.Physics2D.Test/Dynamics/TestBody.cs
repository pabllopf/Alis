// 

using Alis.Core.Systems.Physics2D.Definitions;
using Alis.Core.Systems.Physics2D.Dynamics;
using NUnit.Framework;

namespace Alis.Core.Systems.Physics2D.Test.Dynamics
{
    public class TestBody
    {
        private Body body;
        
        /// <summary>
        ///     Setup this instance
        /// </summary>
        [SetUp]
        public void Setup()
        {
            body = new Body(new BodyDef());
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