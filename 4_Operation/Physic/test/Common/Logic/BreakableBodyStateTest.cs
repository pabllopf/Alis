

using System;
using Alis.Core.Physic.Common.Logic;
using Xunit;

namespace Alis.Core.Physic.Test.Common.Logic
{
    /// <summary>
    ///     The breakable body state test class
    /// </summary>
    public class BreakableBodyStateTest
    {
        /// <summary>
        ///     Tests that unbroken enum value should be defined
        /// </summary>
        [Fact]
        public void UnbrokenEnumValue_ShouldBeDefined()
        {
            BreakableBodyState state = BreakableBodyState.Unbroken;

            Assert.Equal(BreakableBodyState.Unbroken, state);
        }

        /// <summary>
        ///     Tests that should break enum value should be defined
        /// </summary>
        [Fact]
        public void ShouldBreakEnumValue_ShouldBeDefined()
        {
            BreakableBodyState state = BreakableBodyState.ShouldBreak;

            Assert.Equal(BreakableBodyState.ShouldBreak, state);
        }

        /// <summary>
        ///     Tests that broken enum value should be defined
        /// </summary>
        [Fact]
        public void BrokenEnumValue_ShouldBeDefined()
        {
            BreakableBodyState state = BreakableBodyState.Broken;

            Assert.Equal(BreakableBodyState.Broken, state);
        }

        /// <summary>
        ///     Tests that breakable body state should have three values
        /// </summary>
        [Fact]
        public void BreakableBodyState_ShouldHaveThreeValues()
        {
            Array values = Enum.GetValues(typeof(BreakableBodyState));

            Assert.Equal(3, values.Length);
        }

        /// <summary>
        ///     Tests that breakable body state should be castable to int
        /// </summary>
        [Fact]
        public void BreakableBodyState_ShouldBeCastableToInt()
        {
            int unbrokenValue = (int) BreakableBodyState.Unbroken;
            int shouldBreakValue = (int) BreakableBodyState.ShouldBreak;
            int brokenValue = (int) BreakableBodyState.Broken;

            Assert.Equal(0, unbrokenValue);
            Assert.Equal(1, shouldBreakValue);
            Assert.Equal(2, brokenValue);
        }

        /// <summary>
        ///     Tests that breakable body state should support equality comparison
        /// </summary>
        [Fact]
        public void BreakableBodyState_ShouldSupportEqualityComparison()
        {
            BreakableBodyState state1 = BreakableBodyState.Unbroken;
            BreakableBodyState state2 = BreakableBodyState.Unbroken;

            Assert.Equal(state1, state2);
        }

        /// <summary>
        ///     Tests that breakable body state should support inequality comparison
        /// </summary>
        [Fact]
        public void BreakableBodyState_ShouldSupportInequalityComparison()
        {
            BreakableBodyState state1 = BreakableBodyState.Unbroken;
            BreakableBodyState state2 = BreakableBodyState.Broken;

            Assert.NotEqual(state1, state2);
        }

        /// <summary>
        ///     Tests that breakable body state should transition from unbroken to should break
        /// </summary>
        [Fact]
        public void BreakableBodyState_ShouldTransitionFromUnbrokenToShouldBreak()
        {
            BreakableBodyState state = BreakableBodyState.Unbroken;
            state = BreakableBodyState.ShouldBreak;

            Assert.Equal(BreakableBodyState.ShouldBreak, state);
        }

        /// <summary>
        ///     Tests that breakable body state should transition from should break to broken
        /// </summary>
        [Fact]
        public void BreakableBodyState_ShouldTransitionFromShouldBreakToBroken()
        {
            BreakableBodyState state = BreakableBodyState.ShouldBreak;
            state = BreakableBodyState.Broken;

            Assert.Equal(BreakableBodyState.Broken, state);
        }
    }
}