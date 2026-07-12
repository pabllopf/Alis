// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:SfmlTimeTest.cs
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

using Alis.Extension.Graphic.Sfml.Systems;
using Alis.Extension.Graphic.Sfml.Test.Attributes;
using Xunit;

namespace Alis.Extension.Graphic.Sfml.Test.Systems
{
    /// <summary>
    ///     Tests the <see cref="SfmlTime" /> struct.
    /// </summary>
    public class SfmlTimeTest
    {
        /// <summary>
        ///     Tests that <see cref="SfmlTime.Zero" /> is not equal to the default value.
        /// </summary>
        [RequireCSfmlWindowsFact]
        public void Zero_IsNotEmpty()
        {
            Assert.Equal(default(SfmlTime), SfmlTime.Zero);
        }

        /// <summary>
        ///     Tests that <see cref="SfmlTime.Zero" /> equals itself.
        /// </summary>
        [RequireCSfmlWindowsFact]
        public void Equals_ReturnsTrueForSameValues()
        {
            SfmlTime t1 = SfmlTime.Zero;
            SfmlTime t2 = SfmlTime.Zero;
            Assert.True(t1.Equals(t2));
            Assert.True(t1 == t2);
            Assert.False(t1 != t2);
        }

        /// <summary>
        ///     Tests that <see cref="SfmlTime.GetHashCode" /> returns consistent values.
        /// </summary>
        [RequireCSfmlWindowsFact]
        public void GetHashCode_ReturnsConsistentValue()
        {
            SfmlTime t1 = SfmlTime.Zero;
            SfmlTime t2 = SfmlTime.Zero;
            Assert.Equal(t1.GetHashCode(), t2.GetHashCode());
        }

        /// <summary>
        ///     Tests the less-than operator.
        /// </summary>
        [RequireCSfmlWindowsFact]
        public void OperatorLessThan_Works()
        {
            SfmlTime zero = SfmlTime.Zero;
            Assert.False(zero < zero);
            Assert.True(zero <= zero);
        }

        /// <summary>
        ///     Tests the greater-than operator.
        /// </summary>
        [RequireCSfmlWindowsFact]
        public void OperatorGreaterThan_Works()
        {
            SfmlTime zero = SfmlTime.Zero;
            Assert.False(zero > zero);
            Assert.True(zero >= zero);
        }

        /// <summary>
        ///     Tests the addition operator.
        /// </summary>
        [RequireCSfmlWindowsFact]
        public void OperatorAddition_Works()
        {
            SfmlTime zero = SfmlTime.Zero;
            SfmlTime result = zero + zero;
            Assert.True(result == zero);
        }

        /// <summary>
        ///     Tests the subtraction operator.
        /// </summary>
        [RequireCSfmlWindowsFact]
        public void OperatorSubtraction_Works()
        {
            SfmlTime zero = SfmlTime.Zero;
            SfmlTime result = zero - zero;
            Assert.True(result == zero);
        }

        /// <summary>
        ///     Tests the multiplication operator with a scalar.
        /// </summary>
        [RequireCSfmlWindowsFact]
        public void OperatorMultiply_Scalar_Works()
        {
            SfmlTime zero = SfmlTime.Zero;
            SfmlTime result = zero * 2.0f;
            Assert.True(result == zero);
        }

        /// <summary>
        ///     Tests the multiplication operator with a long.
        /// </summary>
        [RequireCSfmlWindowsFact]
        public void OperatorMultiply_Long_Works()
        {
            SfmlTime zero = SfmlTime.Zero;
            SfmlTime result = zero * 2L;
            Assert.True(result == zero);
        }

        /// <summary>
        ///     Tests the multiplication operator with a scalar on the left.
        /// </summary>
        [RequireCSfmlWindowsFact]
        public void OperatorMultiply_LeftScalar_Works()
        {
            SfmlTime zero = SfmlTime.Zero;
            SfmlTime result = 2.0f * zero;
            Assert.True(result == zero);
        }

        /// <summary>
        ///     Tests the multiplication operator with a long on the left.
        /// </summary>
        [RequireCSfmlWindowsFact]
        public void OperatorMultiply_LeftLong_Works()
        {
            SfmlTime zero = SfmlTime.Zero;
            SfmlTime result = 2L * zero;
            Assert.True(result == zero);
        }

        /// <summary>
        ///     Tests the division operator between two time values.
        /// </summary>
        [RequireCSfmlWindowsFact]
        public void OperatorDivision_Time_Works()
        {
            SfmlTime t1 = SfmlTime.FromSeconds(10.0f);
            SfmlTime t2 = SfmlTime.FromSeconds(2.0f);
            SfmlTime result = t1 / t2;
            Assert.Equal(5L, result.AsMicroseconds());
        }

        /// <summary>
        ///     Tests the division operator with a scalar.
        /// </summary>
        [RequireCSfmlWindowsFact]
        public void OperatorDivision_Scalar_Works()
        {
            SfmlTime zero = SfmlTime.Zero;
            SfmlTime result = zero / 2.0f;
            Assert.True(result == zero);
        }

        /// <summary>
        ///     Tests the division operator with a long.
        /// </summary>
        [RequireCSfmlWindowsFact]
        public void OperatorDivision_Long_Works()
        {
            SfmlTime zero = SfmlTime.Zero;
            SfmlTime result = zero / 2L;
            Assert.True(result == zero);
        }

        /// <summary>
        ///     Tests the modulo operator.
        /// </summary>
        [RequireCSfmlWindowsFact]
        public void OperatorModulo_Works()
        {
            SfmlTime t1 = SfmlTime.FromSeconds(10.0f);
            SfmlTime t2 = SfmlTime.FromSeconds(3.0f);
            SfmlTime result = t1 % t2;
            Assert.Equal(1_000_000L, result.AsMicroseconds());
        }
    }
}
