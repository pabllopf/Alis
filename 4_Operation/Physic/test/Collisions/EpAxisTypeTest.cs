

using Alis.Core.Physic.Collisions;
using Xunit;

namespace Alis.Core.Physic.Test.Collisions
{
    /// <summary>
    ///     The ep axis type test class
    /// </summary>
    public class EpAxisTypeTest
    {
        /// <summary>
        ///     Tests that unknown should have value zero
        /// </summary>
        [Fact]
        public void Unknown_ShouldHaveValueZero()
        {
            Assert.Equal(0, (int) EpAxisType.Unknown);
        }

        /// <summary>
        ///     Tests that edge a should have value one
        /// </summary>
        [Fact]
        public void EdgeA_ShouldHaveValueOne()
        {
            Assert.Equal(1, (int) EpAxisType.EdgeA);
        }

        /// <summary>
        ///     Tests that edge b should have value two
        /// </summary>
        [Fact]
        public void EdgeB_ShouldHaveValueTwo()
        {
            Assert.Equal(2, (int) EpAxisType.EdgeB);
        }

        /// <summary>
        ///     Tests that all values should be unique
        /// </summary>
        [Fact]
        public void AllValues_ShouldBeUnique()
        {
            EpAxisType[] values = new[]
            {
                EpAxisType.Unknown,
                EpAxisType.EdgeA,
                EpAxisType.EdgeB
            };

            for (int i = 0; i < values.Length; i++)
            {
                for (int j = i + 1; j < values.Length; j++)
                {
                    Assert.NotEqual(values[i], values[j]);
                }
            }
        }
    }
}