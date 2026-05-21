

using Alis.Core.Physic.Controllers;
using Xunit;

namespace Alis.Core.Physic.Test.Controllers
{
    /// <summary>
    ///     The gravity type test class
    /// </summary>
    public class GravityTypeTest
    {
        /// <summary>
        ///     Tests that linear should have value zero
        /// </summary>
        [Fact]
        public void Linear_ShouldHaveValueZero()
        {
            Assert.Equal(0, (int) GravityType.Linear);
        }

        /// <summary>
        ///     Tests that distance squared should have value one
        /// </summary>
        [Fact]
        public void DistanceSquared_ShouldHaveValueOne()
        {
            Assert.Equal(1, (int) GravityType.DistanceSquared);
        }

        /// <summary>
        ///     Tests that all values should be unique
        /// </summary>
        [Fact]
        public void AllValues_ShouldBeUnique()
        {
            Assert.NotEqual(GravityType.Linear, GravityType.DistanceSquared);
        }

        /// <summary>
        ///     Tests that values should be sequential
        /// </summary>
        [Fact]
        public void Values_ShouldBeSequential()
        {
            Assert.Equal(0, (int) GravityType.Linear);
            Assert.Equal(1, (int) GravityType.DistanceSquared);
        }
    }
}