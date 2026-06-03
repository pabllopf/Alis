// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:MathUtilsTest.cs
// 
//  Author:Pablo Perdomo Falcón
//  Web:https://www.pabllopf.dev/
// 
//  Copyright (c) 2021 GNU General Public License v3.0
// 
//  This program is free software:you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
// 
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.See the
//  GNU General Public License for more details.
// 
//  You should have received a copy of the GNU General Public License
//  along with this program.If not, see <http://www.gnu.org/licenses/>.
// 
//  --------------------------------------------------------------------------

using System;
using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Physic.Dynamics;
using Xunit;

namespace Alis.Core.Physic.Test.Dynamics
{
    /// <summary>
    /// The math utils test class
    /// </summary>
    public class MathUtilsTest
    {
        /// <summary>
        /// Tests that math utils type should be accessible
        /// </summary>
        [Fact]
        public void MathUtils_TypeShouldBeAccessible()
        {
            Assert.NotNull(typeof(MathUtils));
        }

        /// <summary>
        /// Tests that cross product of 2d vectors returns correct value
        /// </summary>
        [Fact]
        public void Cross_Of2DVectors_ShouldReturnCorrectValue()
        {
            Vector2F a = new Vector2F(1.0f, 0.0f);
            Vector2F b = new Vector2F(0.0f, 1.0f);

            float result = MathUtils.Cross(ref a, ref b);

            Assert.Equal(1.0f, result);
        }

        /// <summary>
        /// Tests that cross product with scalar returns perpendicular vector
        /// </summary>
        [Fact]
        public void Cross_WithScalar_ShouldReturnPerpendicularVector()
        {
            Vector2F a = new Vector2F(1.0f, 0.0f);

            Vector2F result = MathUtils.Cross(a, 2.0f);

            Assert.Equal(0.0f, result.X);
            Assert.Equal(-2.0f, result.Y);
        }

        /// <summary>
        /// Tests that rotate 90 returns clockwise perpendicular
        /// </summary>
        [Fact]
        public void Rot90_ShouldReturnClockwisePerpendicular()
        {
            Vector2F a = new Vector2F(1.0f, 0.0f);

            Vector2F result = MathUtils.Rot90(ref a);

            Assert.Equal(0.0f, result.X);
            Assert.Equal(-1.0f, result.Y);
        }

        /// <summary>
        /// Tests that rotate 270 returns counter clockwise perpendicular
        /// </summary>
        [Fact]
        public void Rot270_ShouldReturnCounterClockwisePerpendicular()
        {
            Vector2F a = new Vector2F(1.0f, 0.0f);

            Vector2F result = MathUtils.Rot270(ref a);

            Assert.Equal(0.0f, result.X);
            Assert.Equal(1.0f, result.Y);
        }

        /// <summary>
        /// Tests that abs returns absolute values of vector components
        /// </summary>
        [Fact]
        public void Abs_ShouldReturnAbsoluteValues()
        {
            Vector2F v = new Vector2F(-3.0f, 4.0f);

            Vector2F result = MathUtils.Abs(v);

            Assert.Equal(3.0f, result.X);
            Assert.Equal(4.0f, result.Y);
        }

        /// <summary>
        /// Tests that clamp int should clamp value to range
        /// </summary>
        [Fact]
        public void Clamp_Int_ShouldClampValueToRange()
        {
            Assert.Equal(5, MathUtils.Clamp(3, 5, 10));
            Assert.Equal(10, MathUtils.Clamp(15, 5, 10));
            Assert.Equal(7, MathUtils.Clamp(7, 5, 10));
        }

        /// <summary>
        /// Tests that clamp float should clamp value to range
        /// </summary>
        [Fact]
        public void Clamp_Float_ShouldClampValueToRange()
        {
            Assert.Equal(1.5f, MathUtils.Clamp(0.5f, 1.5f, 3.0f));
            Assert.Equal(3.0f, MathUtils.Clamp(5.0f, 1.5f, 3.0f));
            Assert.Equal(2.0f, MathUtils.Clamp(2.0f, 1.5f, 3.0f));
        }

        /// <summary>
        /// Tests that skew returns perpendicular vector
        /// </summary>
        [Fact]
        public void Skew_ShouldReturnPerpendicular()
        {
            Vector2F input = new Vector2F(1.0f, 2.0f);

            Vector2F result = MathUtils.Skew(input);

            Assert.Equal(-2.0f, result.X);
            Assert.Equal(1.0f, result.Y);
        }

        /// <summary>
        /// Tests that swap exchanges two values
        /// </summary>
        [Fact]
        public void Swap_ShouldExchangeTwoValues()
        {
            int a = 1;
            int b = 2;

            MathUtils.Swap(ref a, ref b);

            Assert.Equal(2, a);
            Assert.Equal(1, b);
        }

        /// <summary>
        /// Tests that float equals returns correct comparison
        /// </summary>
        [Fact]
        public void FloatEquals_ShouldCompareWithinEpsilon()
        {
            Assert.True(MathUtils.FloatEquals(1.0f, 1.0f));
            Assert.False(MathUtils.FloatEquals(1.0f, 2.0f));
        }

        /// <summary>
        /// Tests that float in range checks value within inclusive bounds
        /// </summary>
        [Fact]
        public void FloatInRange_ShouldCheckValueWithinBounds()
        {
            Assert.True(MathUtils.FloatInRange(5.0f, 0.0f, 10.0f));
            Assert.True(MathUtils.FloatInRange(0.0f, 0.0f, 10.0f));
            Assert.True(MathUtils.FloatInRange(10.0f, 0.0f, 10.0f));
            Assert.False(MathUtils.FloatInRange(-1.0f, 0.0f, 10.0f));
            Assert.False(MathUtils.FloatInRange(11.0f, 0.0f, 10.0f));
        }

        /// <summary>
        /// Tests that is valid float returns true for normal values
        /// </summary>
        [Fact]
        public void IsValid_Float_ShouldReturnTrueForNormalValues()
        {
            Assert.True(MathUtils.IsValid(0.0f));
            Assert.True(MathUtils.IsValid(1.0f));
            Assert.True(MathUtils.IsValid(-1.0f));
        }

        /// <summary>
        /// Tests that vector angle returns correct angle between vectors
        /// </summary>
        [Fact]
        public void VectorAngle_ShouldReturnAngleBetweenVectors()
        {
            Vector2F v1 = new Vector2F(1.0f, 0.0f);
            Vector2F v2 = new Vector2F(0.0f, 1.0f);

            double angle = MathUtils.VectorAngle(ref v1, ref v2);

            Assert.Equal(Math.PI / 2, angle, 5);
        }

        /// <summary>
        /// Tests that area of triangle returns positive value for ccw vertices
        /// </summary>
        [Fact]
        public void Area_ShouldReturnPositiveForCcwVertices()
        {
            Vector2F a = new Vector2F(0.0f, 0.0f);
            Vector2F b = new Vector2F(1.0f, 0.0f);
            Vector2F c = new Vector2F(0.0f, 1.0f);

            float area = MathUtils.Area(ref a, ref b, ref c);

            Assert.True(area > 0);
        }

        /// <summary>
        /// Tests that dot product of 3d vectors returns correct value
        /// </summary>
        [Fact]
        public void Dot_Of3DVectors_ShouldReturnCorrectValue()
        {
            Vector3F a = new Vector3F(1.0f, 0.0f, 0.0f);
            Vector3F b = new Vector3F(0.0f, 1.0f, 0.0f);

            float result = MathUtils.Dot(a, b);

            Assert.Equal(0.0f, result);
        }

        /// <summary>
        /// Tests that is collinear returns true for collinear points
        /// </summary>
        [Fact]
        public void IsCollinear_ShouldReturnTrue_WhenPointsAreCollinear()
        {
            Vector2F a = new Vector2F(0.0f, 0.0f);
            Vector2F b = new Vector2F(1.0f, 1.0f);
            Vector2F c = new Vector2F(2.0f, 2.0f);

            Assert.True(MathUtils.IsCollinear(ref a, ref b, ref c));
        }

        /// <summary>
        /// Tests that is collinear returns false for non collinear points
        /// </summary>
        [Fact]
        public void IsCollinear_ShouldReturnFalse_WhenPointsAreNotCollinear()
        {
            Vector2F a = new Vector2F(0.0f, 0.0f);
            Vector2F b = new Vector2F(1.0f, 0.0f);
            Vector2F c = new Vector2F(0.0f, 1.0f);

            Assert.False(MathUtils.IsCollinear(ref a, ref b, ref c));
        }

        /// <summary>
        /// Tests that cross product of 3d vectors returns perpendicular vector
        /// </summary>
        [Fact]
        public void Cross_Of3DVectors_ShouldReturnPerpendicularVector()
        {
            Vector3F a = new Vector3F(1.0f, 0.0f, 0.0f);
            Vector3F b = new Vector3F(0.0f, 1.0f, 0.0f);

            Vector3F result = MathUtils.Cross(ref a, ref b);

            Assert.Equal(0.0f, result.X);
            Assert.Equal(0.0f, result.Y);
            Assert.Equal(1.0f, result.Z);
        }

        /// <summary>
        /// Tests that is valid vector returns true for valid vector
        /// </summary>
        [Fact]
        public void IsValid_Vector2F_ShouldReturnTrue_WhenBothComponentsAreValid()
        {
            Vector2F v = new Vector2F(1.0f, 2.0f);

            Assert.True(v.IsValid());
        }

        /// <summary>
        /// Tests that clamp vector should clamp each component
        /// </summary>
        [Fact]
        public void Clamp_Vector2F_ShouldClampComponents()
        {
            Vector2F value = new Vector2F(0.5f, 1.5f);
            Vector2F low = new Vector2F(0.0f, 1.0f);
            Vector2F high = new Vector2F(1.0f, 2.0f);

            Vector2F result = MathUtils.Clamp(value, low, high);

            Assert.Equal(0.5f, result.X);
            Assert.Equal(1.5f, result.Y);
        }

        /// <summary>
        /// Tests that area by value returns positive for ccw vertices
        /// </summary>
        [Fact]
        public void Area_ByValue_ShouldReturnPositiveForCcwVertices()
        {
            Vector2F a = new Vector2F(0.0f, 0.0f);
            Vector2F b = new Vector2F(1.0f, 0.0f);
            Vector2F c = new Vector2F(0.0f, 1.0f);

            float area = MathUtils.Area(a, b, c);

            Assert.True(area > 0);
        }

        /// <summary>
        /// Tests that vector angle by value returns angle between vectors
        /// </summary>
        [Fact]
        public void VectorAngle_ByValue_ShouldReturnAngleBetweenVectors()
        {
            Vector2F v1 = new Vector2F(1.0f, 0.0f);
            Vector2F v2 = new Vector2F(0.0f, 1.0f);

            double angle = MathUtils.VectorAngle(v1, v2);

            Assert.Equal(Math.PI / 2, angle, 5);
        }

        /// <summary>
        /// Tests that cross by value returns perpendicular vector
        /// </summary>
        [Fact]
        public void Cross_ByValue2D_ShouldReturnCorrectValue()
        {
            Vector2F a = new Vector2F(1.0f, 0.0f);
            Vector2F b = new Vector2F(0.0f, 1.0f);

            float result = MathUtils.Cross(a, b);

            Assert.Equal(1.0f, result);
        }

        /// <summary>
        /// Tests that cross with scalar first returns perpendicular vector
        /// </summary>
        [Fact]
        public void Cross_ScalarFirst_ShouldReturnPerpendicularVector()
        {
            Vector2F a = new Vector2F(1.0f, 0.0f);

            Vector2F result = MathUtils.Cross(2.0f, ref a);

            Assert.Equal(0.0f, result.X);
            Assert.Equal(2.0f, result.Y);
        }
    }
}

