// 

using Alis.Core.Systems.Physics2D.Dynamics;
using NUnit.Framework;

namespace Alis.Core.Systems.Physics2D.Test.Dynamics
{
    /// <summary>
    /// The test profile class
    /// </summary>
    public class TestProfile
    {
        /// <summary>
        /// The profile
        /// </summary>
        private Profile profile;

        /// <summary>
        ///     Setup this instance
        /// </summary>
        [SetUp]
        public void Setup()
        {
            profile = new Profile();
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