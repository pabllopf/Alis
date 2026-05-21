

using Alis.Core.Physic.Collisions;
using Xunit;

namespace Alis.Core.Physic.Test.Collisions
{
    /// <summary>
    ///     The manifold type test class
    /// </summary>
    public class ManifoldTypeTest
    {
        /// <summary>
        ///     Tests that circles should have value zero
        /// </summary>
        [Fact]
        public void Circles_ShouldHaveValueZero()
        {
            Assert.Equal(0, (int) ManifoldType.Circles);
        }

        /// <summary>
        ///     Tests that face a should have value one
        /// </summary>
        [Fact]
        public void FaceA_ShouldHaveValueOne()
        {
            Assert.Equal(1, (int) ManifoldType.FaceA);
        }

        /// <summary>
        ///     Tests that face b should have value two
        /// </summary>
        [Fact]
        public void FaceB_ShouldHaveValueTwo()
        {
            Assert.Equal(2, (int) ManifoldType.FaceB);
        }

        /// <summary>
        ///     Tests that all values should be unique
        /// </summary>
        [Fact]
        public void AllValues_ShouldBeUnique()
        {
            ManifoldType[] values = new[]
            {
                ManifoldType.Circles,
                ManifoldType.FaceA,
                ManifoldType.FaceB
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