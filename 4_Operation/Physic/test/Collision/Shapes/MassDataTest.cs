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

using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Physic.Collision.Shapes;
using Xunit;

namespace Alis.Core.Physic.Test.Collision.Shapes
{
    /// <summary>
    ///     The mass data test class
    /// </summary>
    public class MassDataTest
    {
        /// <summary>
        ///     Tests that test area property
        /// </summary>
        [Fact]
        public void Test_AreaProperty()
        {
            // Arrange
            MassData massData = new MassData();
            float expectedValue = 1.5f;
            
            // Act
            massData.Area = expectedValue;
            
            // Assert
            Assert.Equal(expectedValue, massData.Area);
        }
        
        /// <summary>
        ///     Tests that test centroid property
        /// </summary>
        [Fact]
        public void Test_CentroidProperty()
        {
            // Arrange
            MassData massData = new MassData();
            Vector2 expectedValue = new Vector2(1, 1);
            
            // Act
            massData.Centroid = expectedValue;
            
            // Assert
            Assert.Equal(expectedValue, massData.Centroid);
        }
        
        /// <summary>
        ///     Tests that test inertia property
        /// </summary>
        [Fact]
        public void Test_InertiaProperty()
        {
            // Arrange
            MassData massData = new MassData();
            float expectedValue = 2.5f;
            
            // Act
            massData.Inertia = expectedValue;
            
            // Assert
            Assert.Equal(expectedValue, massData.Inertia);
        }
        
        /// <summary>
        ///     Tests that test mass property
        /// </summary>
        [Fact]
        public void Test_MassProperty()
        {
            // Arrange
            MassData massData = new MassData();
            float expectedValue = 3.5f;
            
            // Act
            massData.Mass = expectedValue;
            
            // Assert
            Assert.Equal(expectedValue, massData.Mass);
        }
        
        /// <summary>
        ///     Tests that test equality operator
        /// </summary>
        [Fact]
        public void Test_EqualityOperator()
        {
            // Arrange
            MassData massData1 = new MassData {Area = 1.5f, Centroid = new Vector2(1, 1), Inertia = 2.5f, Mass = 3.5f};
            MassData massData2 = new MassData {Area = 1.5f, Centroid = new Vector2(1, 1), Inertia = 2.5f, Mass = 3.5f};
            
            // Act
            bool areEqual = massData1 == massData2;
            
            // Assert
            Assert.True(areEqual);
        }
        
        /// <summary>
        ///     Tests that test inequality operator
        /// </summary>
        [Fact]
        public void Test_InequalityOperator()
        {
            // Arrange
            MassData massData1 = new MassData {Area = 1.5f, Centroid = new Vector2(1, 1), Inertia = 2.5f, Mass = 3.5f};
            MassData massData2 = new MassData {Area = 2.5f, Centroid = new Vector2(2, 2), Inertia = 3.5f, Mass = 4.5f};
            
            // Act
            bool areNotEqual = massData1 != massData2;
            
            // Assert
            Assert.True(areNotEqual);
        }
        
        /// <summary>
        /// Tests that operator equal returns true when mass data are equal
        /// </summary>
        [Fact]
        public void OperatorEqual_ReturnsTrue_WhenMassDataAreEqual()
        {
            MassData massData1 = new MassData(1.0f, 2.0f, 3.0f);
            MassData massData2 = new MassData(1.0f, 2.0f, 3.0f);
            
            bool result = massData1 == massData2;
            
            Assert.True(result);
        }
        
        /// <summary>
        /// Tests that operator equal returns false when mass data are not equal
        /// </summary>
        [Fact]
        public void OperatorEqual_ReturnsFalse_WhenMassDataAreNotEqual()
        {
            MassData massData1 = new MassData(1.0f, 2.0f, 3.0f);
            MassData massData2 = new MassData(4.0f, 5.0f, 6.0f);
            
            bool result = massData1 == massData2;
            
            Assert.False(result);
        }
        
        /// <summary>
        /// Tests that operator not equal returns true when mass data are not equal
        /// </summary>
        [Fact]
        public void OperatorNotEqual_ReturnsTrue_WhenMassDataAreNotEqual()
        {
            MassData massData1 = new MassData(1.0f, 2.0f, 3.0f);
            MassData massData2 = new MassData(4.0f, 5.0f, 6.0f);
            
            bool result = massData1 != massData2;
            
            Assert.True(result);
        }
        
        /// <summary>
        /// Tests that operator not equal returns false when mass data are equal
        /// </summary>
        [Fact]
        public void OperatorNotEqual_ReturnsFalse_WhenMassDataAreEqual()
        {
            MassData massData1 = new MassData(1.0f, 2.0f, 3.0f);
            MassData massData2 = new MassData(1.0f, 2.0f, 3.0f);
            
            bool result = massData1 != massData2;
            
            Assert.False(result);
        }
        
        /// <summary>
        /// Tests that equals returns true when mass data are equal
        /// </summary>
        [Fact]
        public void Equals_ReturnsTrue_WhenMassDataAreEqual()
        {
            MassData massData1 = new MassData(1.0f, 2.0f, 3.0f);
            MassData massData2 = new MassData(1.0f, 2.0f, 3.0f);
            
            bool result = massData1.Equals(massData2);
            
            Assert.True(result);
        }
        
        /// <summary>
        /// Tests that equals returns false when mass data are not equal
        /// </summary>
        [Fact]
        public void Equals_ReturnsFalse_WhenMassDataAreNotEqual()
        {
            MassData massData1 = new MassData(1.0f, 2.0f, 3.0f);
            MassData massData2 = new MassData(4.0f, 5.0f, 6.0f);
            
            bool result = massData1.Equals(massData2);
            
            Assert.False(result);
        }
        
        /// <summary>
        /// Tests that get hash code returns same hash code when mass data are equal
        /// </summary>
        [Fact]
        public void GetHashCode_ReturnsSameHashCode_WhenMassDataAreEqual()
        {
            MassData massData1 = new MassData(1.0f, 2.0f, 3.0f);
            MassData massData2 = new MassData(1.0f, 2.0f, 3.0f);
            
            int hashCode1 = massData1.GetHashCode();
            int hashCode2 = massData2.GetHashCode();
            
            Assert.Equal(hashCode1, hashCode2);
        }
        
        /// <summary>
        /// Tests that get hash code returns different hash code when mass data are not equal
        /// </summary>
        [Fact]
        public void GetHashCode_ReturnsDifferentHashCode_WhenMassDataAreNotEqual()
        {
            MassData massData1 = new MassData(1.0f, 2.0f, 3.0f);
            MassData massData2 = new MassData(4.0f, 5.0f, 6.0f);
            
            int hashCode1 = massData1.GetHashCode();
            int hashCode2 = massData2.GetHashCode();
            
            Assert.NotEqual(hashCode1, hashCode2);
        }
        
        /// <summary>
        /// Tests that equals returns false when object is null
        /// </summary>
        [Fact]
        public void Equals_ReturnsFalse_WhenObjectIsNull()
        {
            MassData massData = new MassData(1.0f, 2.0f, 3.0f);
            object obj = null;
            
            bool result = massData.Equals(obj);
            
            Assert.False(result);
        }
        
        /// <summary>
        /// Tests that equals returns false when object is not mass data
        /// </summary>
        [Fact]
        public void Equals_ReturnsFalse_WhenObjectIsNotMassData()
        {
            MassData massData = new MassData(1.0f, 2.0f, 3.0f);
            object obj = new object();
            
            bool result = massData.Equals(obj);
            
            Assert.False(result);
        }
        
        /// <summary>
        /// Tests that equals returns true when object is equal mass data
        /// </summary>
        [Fact]
        public void Equals_ReturnsTrue_WhenObjectIsEqualMassData()
        {
            MassData massData1 = new MassData(1.0f, 2.0f, 3.0f);
            object obj = new MassData(1.0f, 2.0f, 3.0f);
            
            bool result = massData1.Equals(obj);
            
            Assert.True(result);
        }
        
        /// <summary>
        /// Tests that equals returns false when object is different mass data
        /// </summary>
        [Fact]
        public void Equals_ReturnsFalse_WhenObjectIsDifferentMassData()
        {
            MassData massData1 = new MassData(1.0f, 2.0f, 3.0f);
            object obj = new MassData(4.0f, 5.0f, 6.0f);
            
            bool result = massData1.Equals(obj);
            
            Assert.False(result);
        }
    }
}