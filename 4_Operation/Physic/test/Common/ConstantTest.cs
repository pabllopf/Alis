

using System;
using Alis.Core.Physic.Common;
using Xunit;

namespace Alis.Core.Physic.Test.Common
{
    /// <summary>
    ///     The constant test class
    /// </summary>
    public class ConstantTest
    {
        /// <summary>
        ///     Tests that pi should have correct value
        /// </summary>
        [Fact]
        public void Pi_ShouldHaveCorrectValue()
        {
            Assert.Equal((float) Math.PI, Constant.Pi, 5);
        }

        /// <summary>
        ///     Tests that tau should be two times pi
        /// </summary>
        [Fact]
        public void Tau_ShouldBeTwoTimesPi()
        {
            Assert.Equal((float) (Math.PI * 2.0), Constant.Tau, 5);
        }

        /// <summary>
        ///     Tests that tau should be approximately six point two eight
        /// </summary>
        [Fact]
        public void Tau_ShouldBeApproximatelySixPointTwoEight()
        {
            Assert.True((Constant.Tau > 6.28f) && (Constant.Tau < 6.29f));
        }

        /// <summary>
        ///     Tests that pi should be approximately three point one four
        /// </summary>
        [Fact]
        public void Pi_ShouldBeApproximatelyThreePointOneFour()
        {
            Assert.True((Constant.Pi > 3.14f) && (Constant.Pi < 3.15f));
        }
    }
}