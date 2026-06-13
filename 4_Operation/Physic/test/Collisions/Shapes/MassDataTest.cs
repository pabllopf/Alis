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

            Assert.Equal(0f, massData.Area);
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

            Assert.Equal(0f, massData.Inertia);
        }

        /// <summary>
        /// Tests that default mass data should have mass zero
        /// </summary>
        [Fact]
        public void DefaultMassData_ShouldHaveMassZero()
        {
            MassData massData = default;

            Assert.Equal(0f, massData.Mass);
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
    }
}
