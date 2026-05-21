

using System;
using Alis.Core.Physic.Collisions;
using Xunit;

namespace Alis.Core.Physic.Test.Collisions
{
    /// <summary>
    ///     The separation function type test class
    /// </summary>
    public class SeparationFunctionTypeTest
    {
        /// <summary>
        ///     Tests that points enum value should be defined
        /// </summary>
        [Fact]
        public void PointsEnumValue_ShouldBeDefined()
        {
            SeparationFunctionType type = SeparationFunctionType.Points;

            Assert.Equal(SeparationFunctionType.Points, type);
        }

        /// <summary>
        ///     Tests that face a enum value should be defined
        /// </summary>
        [Fact]
        public void FaceAEnumValue_ShouldBeDefined()
        {
            SeparationFunctionType type = SeparationFunctionType.FaceA;

            Assert.Equal(SeparationFunctionType.FaceA, type);
        }

        /// <summary>
        ///     Tests that face b enum value should be defined
        /// </summary>
        [Fact]
        public void FaceBEnumValue_ShouldBeDefined()
        {
            SeparationFunctionType type = SeparationFunctionType.FaceB;

            Assert.Equal(SeparationFunctionType.FaceB, type);
        }

        /// <summary>
        ///     Tests that separation function type should have three values
        /// </summary>
        [Fact]
        public void SeparationFunctionType_ShouldHaveThreeValues()
        {
            Array values = Enum.GetValues(typeof(SeparationFunctionType));

            Assert.Equal(3, values.Length);
        }

        /// <summary>
        ///     Tests that separation function type should be castable to int
        /// </summary>
        [Fact]
        public void SeparationFunctionType_ShouldBeCastableToInt()
        {
            int pointsValue = (int) SeparationFunctionType.Points;
            int faceAValue = (int) SeparationFunctionType.FaceA;
            int faceBValue = (int) SeparationFunctionType.FaceB;

            Assert.Equal(0, pointsValue);
            Assert.Equal(1, faceAValue);
            Assert.Equal(2, faceBValue);
        }

        /// <summary>
        ///     Tests that separation function type should support equality comparison
        /// </summary>
        [Fact]
        public void SeparationFunctionType_ShouldSupportEqualityComparison()
        {
            SeparationFunctionType type1 = SeparationFunctionType.FaceA;
            SeparationFunctionType type2 = SeparationFunctionType.FaceA;

            Assert.Equal(type1, type2);
        }

        /// <summary>
        ///     Tests that separation function type should support inequality comparison
        /// </summary>
        [Fact]
        public void SeparationFunctionType_ShouldSupportInequalityComparison()
        {
            SeparationFunctionType type1 = SeparationFunctionType.Points;
            SeparationFunctionType type2 = SeparationFunctionType.FaceB;

            Assert.NotEqual(type1, type2);
        }
    }
}