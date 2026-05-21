

using System;
using Alis.Core.Physic.Common.PolygonManipulation;
using Xunit;

namespace Alis.Core.Physic.Test.Common.PolygonManipulation
{
    /// <summary>
    ///     The poly clip type test class
    /// </summary>
    public class PolyClipTypeTest
    {
        /// <summary>
        ///     Tests that intersect enum value should be defined
        /// </summary>
        [Fact]
        public void IntersectEnumValue_ShouldBeDefined()
        {
            PolyClipType type = PolyClipType.Intersect;

            Assert.Equal(PolyClipType.Intersect, type);
        }

        /// <summary>
        ///     Tests that union enum value should be defined
        /// </summary>
        [Fact]
        public void UnionEnumValue_ShouldBeDefined()
        {
            PolyClipType type = PolyClipType.Union;

            Assert.Equal(PolyClipType.Union, type);
        }

        /// <summary>
        ///     Tests that difference enum value should be defined
        /// </summary>
        [Fact]
        public void DifferenceEnumValue_ShouldBeDefined()
        {
            PolyClipType type = PolyClipType.Difference;

            Assert.Equal(PolyClipType.Difference, type);
        }

        /// <summary>
        ///     Tests that poly clip type should have three values
        /// </summary>
        [Fact]
        public void PolyClipType_ShouldHaveThreeValues()
        {
            Array values = Enum.GetValues(typeof(PolyClipType));

            Assert.Equal(3, values.Length);
        }

        /// <summary>
        ///     Tests that poly clip type should be castable to int
        /// </summary>
        [Fact]
        public void PolyClipType_ShouldBeCastableToInt()
        {
            int intersectValue = (int) PolyClipType.Intersect;
            int unionValue = (int) PolyClipType.Union;
            int differenceValue = (int) PolyClipType.Difference;

            Assert.Equal(0, intersectValue);
            Assert.Equal(1, unionValue);
            Assert.Equal(2, differenceValue);
        }

        /// <summary>
        ///     Tests that poly clip type should support equality comparison
        /// </summary>
        [Fact]
        public void PolyClipType_ShouldSupportEqualityComparison()
        {
            PolyClipType type1 = PolyClipType.Union;
            PolyClipType type2 = PolyClipType.Union;

            Assert.Equal(type1, type2);
        }

        /// <summary>
        ///     Tests that poly clip type should support inequality comparison
        /// </summary>
        [Fact]
        public void PolyClipType_ShouldSupportInequalityComparison()
        {
            PolyClipType type1 = PolyClipType.Intersect;
            PolyClipType type2 = PolyClipType.Difference;

            Assert.NotEqual(type1, type2);
        }
    }
}