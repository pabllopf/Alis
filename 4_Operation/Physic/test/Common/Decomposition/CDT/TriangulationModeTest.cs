

using System;
using Alis.Core.Physic.Common.Decomposition.CDT;
using Xunit;

namespace Alis.Core.Physic.Test.Common.Decomposition.CDT
{
    /// <summary>
    ///     The triangulation mode test class
    /// </summary>
    public class TriangulationModeTest
    {
        /// <summary>
        ///     Tests that unconstrained enum value should be defined
        /// </summary>
        [Fact]
        public void UnconstrainedEnumValue_ShouldBeDefined()
        {
            TriangulationMode mode = TriangulationMode.Unconstrained;

            Assert.Equal(TriangulationMode.Unconstrained, mode);
        }

        /// <summary>
        ///     Tests that constrained enum value should be defined
        /// </summary>
        [Fact]
        public void ConstrainedEnumValue_ShouldBeDefined()
        {
            TriangulationMode mode = TriangulationMode.Constrained;

            Assert.Equal(TriangulationMode.Constrained, mode);
        }

        /// <summary>
        ///     Tests that polygon enum value should be defined
        /// </summary>
        [Fact]
        public void PolygonEnumValue_ShouldBeDefined()
        {
            TriangulationMode mode = TriangulationMode.Polygon;

            Assert.Equal(TriangulationMode.Polygon, mode);
        }

        /// <summary>
        ///     Tests that triangulation mode should have three values
        /// </summary>
        [Fact]
        public void TriangulationMode_ShouldHaveThreeValues()
        {
            Array values = Enum.GetValues(typeof(TriangulationMode));

            Assert.Equal(3, values.Length);
        }

        /// <summary>
        ///     Tests that triangulation mode should be castable to int
        /// </summary>
        [Fact]
        public void TriangulationMode_ShouldBeCastableToInt()
        {
            int unconstrainedValue = (int) TriangulationMode.Unconstrained;
            int constrainedValue = (int) TriangulationMode.Constrained;
            int polygonValue = (int) TriangulationMode.Polygon;

            Assert.Equal(0, unconstrainedValue);
            Assert.Equal(1, constrainedValue);
            Assert.Equal(2, polygonValue);
        }

        /// <summary>
        ///     Tests that triangulation mode should support equality comparison
        /// </summary>
        [Fact]
        public void TriangulationMode_ShouldSupportEqualityComparison()
        {
            TriangulationMode mode1 = TriangulationMode.Constrained;
            TriangulationMode mode2 = TriangulationMode.Constrained;

            Assert.Equal(mode1, mode2);
        }

        /// <summary>
        ///     Tests that triangulation mode should support inequality comparison
        /// </summary>
        [Fact]
        public void TriangulationMode_ShouldSupportInequalityComparison()
        {
            TriangulationMode mode1 = TriangulationMode.Unconstrained;
            TriangulationMode mode2 = TriangulationMode.Polygon;

            Assert.NotEqual(mode1, mode2);
        }
    }
}