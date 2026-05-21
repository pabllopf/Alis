

using System;
using Alis.Core.Physic.Collisions;
using Xunit;

namespace Alis.Core.Physic.Test.Collisions
{
    /// <summary>
    ///     The toi output state test class
    /// </summary>
    public class ToiOutputStateTest
    {
        /// <summary>
        ///     Tests that unknown enum value should be defined
        /// </summary>
        [Fact]
        public void UnknownEnumValue_ShouldBeDefined()
        {
            ToiOutputState state = ToiOutputState.Unknown;

            Assert.Equal(ToiOutputState.Unknown, state);
        }

        /// <summary>
        ///     Tests that failed enum value should be defined
        /// </summary>
        [Fact]
        public void FailedEnumValue_ShouldBeDefined()
        {
            ToiOutputState state = ToiOutputState.Failed;

            Assert.Equal(ToiOutputState.Failed, state);
        }

        /// <summary>
        ///     Tests that overlapped enum value should be defined
        /// </summary>
        [Fact]
        public void OverlappedEnumValue_ShouldBeDefined()
        {
            ToiOutputState state = ToiOutputState.Overlapped;

            Assert.Equal(ToiOutputState.Overlapped, state);
        }

        /// <summary>
        ///     Tests that touching enum value should be defined
        /// </summary>
        [Fact]
        public void TouchingEnumValue_ShouldBeDefined()
        {
            ToiOutputState state = ToiOutputState.Touching;

            Assert.Equal(ToiOutputState.Touching, state);
        }

        /// <summary>
        ///     Tests that separated enum value should be defined
        /// </summary>
        [Fact]
        public void SeparatedEnumValue_ShouldBeDefined()
        {
            ToiOutputState state = ToiOutputState.Seperated;

            Assert.Equal(ToiOutputState.Seperated, state);
        }

        /// <summary>
        ///     Tests that toi output state should have five values
        /// </summary>
        [Fact]
        public void ToiOutputState_ShouldHaveFiveValues()
        {
            Array values = Enum.GetValues(typeof(ToiOutputState));

            Assert.Equal(5, values.Length);
        }

        /// <summary>
        ///     Tests that toi output state should be castable to int
        /// </summary>
        [Fact]
        public void ToiOutputState_ShouldBeCastableToInt()
        {
            int unknownValue = (int) ToiOutputState.Unknown;
            int failedValue = (int) ToiOutputState.Failed;
            int overlappedValue = (int) ToiOutputState.Overlapped;

            Assert.Equal(0, unknownValue);
            Assert.Equal(1, failedValue);
            Assert.Equal(2, overlappedValue);
        }

        /// <summary>
        ///     Tests that toi output state should support equality comparison
        /// </summary>
        [Fact]
        public void ToiOutputState_ShouldSupportEqualityComparison()
        {
            ToiOutputState state1 = ToiOutputState.Touching;
            ToiOutputState state2 = ToiOutputState.Touching;

            Assert.Equal(state1, state2);
        }

        /// <summary>
        ///     Tests that toi output state should support inequality comparison
        /// </summary>
        [Fact]
        public void ToiOutputState_ShouldSupportInequalityComparison()
        {
            ToiOutputState state1 = ToiOutputState.Unknown;
            ToiOutputState state2 = ToiOutputState.Failed;

            Assert.NotEqual(state1, state2);
        }
    }
}