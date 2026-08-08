// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:MassDataTest.cs
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
using Alis.Core.Physic.Collisions.Shapes;
using Xunit;

namespace Alis.Core.Physic.Test.Collisions.Shapes
{
    /// <summary>
    /// The mass data test class
    /// </summary>
    public class MassDataTest
    {
        /// <summary>
        /// Tests that default mass data should have area zero
        /// </summary>
        [Fact]
        public void DefaultMassData_ShouldHaveAreaZero()
        {
            MassData massData = default;

            Assert.Equal(0f, massData.Area, 5);
        }

        /// <summary>
        /// Tests that default mass data should have centroid zero
        /// </summary>
        [Fact]
        public void DefaultMassData_ShouldHaveCentroidZero()
        {
            MassData massData = default;

            Assert.Equal(Vector2F.Zero, massData.Centroid);
        }

        /// <summary>
        /// Tests that default mass data should have inertia zero
        /// </summary>
        [Fact]
        public void DefaultMassData_ShouldHaveInertiaZero()
        {
            MassData massData = default;

            Assert.Equal(0f, massData.Inertia, 5);
        }

        /// <summary>
        /// Tests that default mass data should have mass zero
        /// </summary>
        [Fact]
        public void DefaultMassData_ShouldHaveMassZero()
        {
            MassData massData = default;

            Assert.Equal(0f, massData.Mass, 5);
        }

        /// <summary>
        /// Tests that equals should return true for same default values
        /// </summary>
        [Fact]
        public void Equals_WithTwoDefaultInstances_ShouldReturnTrue()
        {
            MassData first = default;
            MassData second = default;

            Assert.True(first.Equals(second));
        }

        /// <summary>
        /// Tests that equality operator should return true for same default values
        /// </summary>
        [Fact]
        public void EqualityOperator_WithTwoDefaultInstances_ShouldReturnTrue()
        {
            MassData first = default;
            MassData second = default;

            Assert.True(first == second);
        }

        /// <summary>
        /// Tests that inequality operator should return false for same default values
        /// </summary>
        [Fact]
        public void InequalityOperator_WithTwoDefaultInstances_ShouldReturnFalse()
        {
            MassData first = default;
            MassData second = default;

            Assert.False(first != second);
        }

        /// <summary>
        /// Tests that get hash code should be consistent for same values
        /// </summary>
        [Fact]
        public void GetHashCode_WithSameValues_ShouldBeEqual()
        {
            MassData first = default;
            MassData second = default;

            Assert.Equal(first.GetHashCode(), second.GetHashCode());
        }

        /// <summary>
        /// Tests that equals object should return true for same default mass data
        /// </summary>
        [Fact]
        public void Equals_Object_WithSameDefaultValues_ShouldReturnTrue()
        {
            MassData massData = default;
            object obj = default(MassData);

            Assert.True(massData.Equals(obj));
        }

        /// <summary>
        /// Tests that equals object should return false for null
        /// </summary>
        [Fact]
        public void Equals_Object_WithNull_ShouldReturnFalse()
        {
            MassData massData = default;

            Assert.False(massData.Equals(null));
        }

        /// <summary>
        /// Tests that equals object should throw invalid cast exception for different type
        /// </summary>
        [Fact]
        public void Equals_Object_WithDifferentType_ShouldThrowInvalidCastException()
        {
            MassData massData = default;

            Assert.Throws<InvalidCastException>(() => massData.Equals("not a MassData"));
        }

        /// <summary>
        ///     Tests that equality operator returns false for different values.
        /// </summary>
        [Fact]
        public void EqualityOperator_WithDifferentValues_ShouldReturnFalse()
        {
            MassData first = new MassData { Area = 1f, Mass = 2f, Inertia = 3f, Centroid = new Vector2F(1f, 2f) };
            MassData second = new MassData { Area = 1f, Mass = 2f, Inertia = 3f, Centroid = new Vector2F(1f, 2f) };

            Assert.True(first == second);
        }

        /// <summary>
        ///     Tests that inequality operator returns true for different values.
        /// </summary>
        [Fact]
        public void InequalityOperator_WithDifferentValues_ShouldReturnTrue()
        {
            MassData first = default;
            MassData second = new MassData { Area = 5f, Mass = 2f, Inertia = 3f, Centroid = new Vector2F(1f, 2f) };

            Assert.True(first != second);
        }

        /// <summary>
        ///     Tests that Equals returns true for instances with same values.
        /// </summary>
        [Fact]
        public void Equals_WithSameNonDefaultValues_ShouldReturnTrue()
        {
            MassData first = new MassData { Area = 10f, Mass = 5f, Inertia = 2f, Centroid = new Vector2F(3f, 4f) };
            MassData second = new MassData { Area = 10f, Mass = 5f, Inertia = 2f, Centroid = new Vector2F(3f, 4f) };

            Assert.True(first.Equals(second));
        }

        /// <summary>
        ///     Tests that Equals returns false for instances with different values.
        /// </summary>
        [Fact]
        public void Equals_WithDifferentValues_ShouldReturnFalse()
        {
            MassData first = default;
            MassData second = new MassData { Area = 10f, Mass = 5f, Inertia = 2f, Centroid = new Vector2F(3f, 4f) };

            Assert.False(first.Equals(second));
        }

        /// <summary>
        ///     Tests that Equals object returns true for boxed MassData with same values.
        /// </summary>
        [Fact]
        public void Equals_Object_WithSameNonDefaultValues_ShouldReturnTrue()
        {
            MassData massData = new MassData { Area = 10f, Mass = 5f, Inertia = 2f, Centroid = new Vector2F(3f, 4f) };
            object obj = new MassData { Area = 10f, Mass = 5f, Inertia = 2f, Centroid = new Vector2F(3f, 4f) };

            Assert.True(massData.Equals(obj));
        }

        /// <summary>
        ///     Tests that GetHashCode returns different values for different MassData.
        /// </summary>
        [Fact]
        public void GetHashCode_WithDifferentValues_ShouldDiffer()
        {
            MassData first = default;
            MassData second = new MassData { Area = 10f, Mass = 5f, Inertia = 2f, Centroid = new Vector2F(3f, 4f) };

            Assert.NotEqual(first.GetHashCode(), second.GetHashCode());
        }
    }
}
