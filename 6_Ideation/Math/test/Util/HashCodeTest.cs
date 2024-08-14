// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:HashCodeTest.cs
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

using Alis.Core.Aspect.Math.Util;
using Xunit;

namespace Alis.Core.Aspect.Math.Test.Util
{
    /// <summary>
    ///     The hash code test class
    /// </summary>
    public class HashCodeTest
    {
        /// <summary>
        ///     Tests that combine should calculate correctly for different input
        /// </summary>
        [Fact]
        public void Combine_ShouldCalculateCorrectly_ForDifferentInput()
        {
            // Arrange
            int value1 = 1;
            int value2 = 2;
            int value3 = 3;
            int value4 = 4;
            int value5 = 5;
            int value6 = 6;
            int value7 = 7;
            int value8 = 8;
            
            // Act
            int result1 = HashCode.Combine(value1);
            int result2 = HashCode.Combine(value1, value2);
            int result3 = HashCode.Combine(value1, value2, value3);
            int result4 = HashCode.Combine(value1, value2, value3, value4);
            int result5 = HashCode.Combine(value1, value2, value3, value4, value5);
            int result6 = HashCode.Combine(value1, value2, value3, value4, value5, value6);
            int result7 = HashCode.Combine(value1, value2, value3, value4, value5, value6, value7);
            int result8 = HashCode.Combine(value1, value2, value3, value4, value5, value6, value7, value8);
            
            // Assert
            Assert.NotEqual(result1, result2);
            Assert.NotEqual(result1, result3);
            Assert.NotEqual(result1, result4);
            Assert.NotEqual(result1, result5);
            Assert.NotEqual(result1, result6);
            Assert.NotEqual(result1, result7);
            Assert.NotEqual(result1, result8);
            Assert.NotEqual(result2, result3);
            Assert.NotEqual(result2, result4);
            Assert.NotEqual(result2, result5);
            Assert.NotEqual(result2, result6);
            Assert.NotEqual(result2, result7);
            Assert.NotEqual(result2, result8);
            Assert.NotEqual(result3, result4);
            Assert.NotEqual(result3, result5);
            Assert.NotEqual(result3, result6);
            Assert.NotEqual(result3, result7);
            Assert.NotEqual(result3, result8);
            Assert.NotEqual(result4, result5);
            Assert.NotEqual(result4, result6);
            Assert.NotEqual(result4, result7);
            Assert.NotEqual(result4, result8);
            Assert.NotEqual(result5, result6);
            Assert.NotEqual(result5, result7);
            Assert.NotEqual(result5, result8);
            Assert.NotEqual(result6, result7);
            Assert.NotEqual(result6, result8);
            Assert.NotEqual(result7, result8);
        }
        
        /// <summary>
        ///     Tests that add should calculate correctly for different input
        /// </summary>
        [Fact]
        public void Add_ShouldCalculateCorrectly_ForDifferentInput()
        {
            // Arrange
            int value1 = 1;
            int value2 = 2;
            int value3 = 3;
            int value4 = 4;
            int value5 = 5;
            int value6 = 6;
            int value7 = 7;
            int value8 = 8;
            
            HashCode hashCode = new HashCode();
            
            // Act
            hashCode.Add(value1);
            int result1 = hashCode.ToHashCode();
            hashCode.Add(value2);
            int result2 = hashCode.ToHashCode();
            hashCode.Add(value3);
            int result3 = hashCode.ToHashCode();
            hashCode.Add(value4);
            int result4 = hashCode.ToHashCode();
            hashCode.Add(value5);
            int result5 = hashCode.ToHashCode();
            hashCode.Add(value6);
            int result6 = hashCode.ToHashCode();
            hashCode.Add(value7);
            int result7 = hashCode.ToHashCode();
            hashCode.Add(value8);
            int result8 = hashCode.ToHashCode();
            
            // Assert
            Assert.NotEqual(result1, result2);
            Assert.NotEqual(result1, result3);
            Assert.NotEqual(result1, result4);
            Assert.NotEqual(result1, result5);
            Assert.NotEqual(result1, result6);
            Assert.NotEqual(result1, result7);
            Assert.NotEqual(result1, result8);
            Assert.NotEqual(result2, result3);
            Assert.NotEqual(result2, result4);
            Assert.NotEqual(result2, result5);
            Assert.NotEqual(result2, result6);
            Assert.NotEqual(result2, result7);
            Assert.NotEqual(result2, result8);
            Assert.NotEqual(result3, result4);
            Assert.NotEqual(result3, result5);
            Assert.NotEqual(result3, result6);
            Assert.NotEqual(result3, result7);
            Assert.NotEqual(result3, result8);
            Assert.NotEqual(result4, result5);
            Assert.NotEqual(result4, result6);
            Assert.NotEqual(result4, result7);
            Assert.NotEqual(result4, result8);
            Assert.NotEqual(result5, result6);
            Assert.NotEqual(result5, result7);
            Assert.NotEqual(result5, result8);
            Assert.NotEqual(result6, result7);
            Assert.NotEqual(result6, result8);
            Assert.NotEqual(result7, result8);
        }
    }
}