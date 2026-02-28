// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:InlineArray8Test.cs
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

using Alis.Core.Ecs.Collections;
using Xunit;

namespace Alis.Core.Ecs.Test.Collections
{
    /// <summary>
    ///     Tests the <see cref="InlineArray8{T}"/> struct.
    /// </summary>
    public class InlineArray8Test
    {
        /// <summary>
        ///     Tests that get returns correct element at index 0.
        /// </summary>
        [Fact]
        public void Get_AtIndex0_ShouldReturnCorrectElement()
        {
            // Arrange
            InlineArray8<int> array = new InlineArray8<int> { _0 = 10 };
            
            // Act
            ref int value = ref InlineArray8<int>.Get(ref array, 0);
            
            // Assert
            Assert.Equal(10, value);
        }
        
        /// <summary>
        ///     Tests that get returns correct element at index 1.
        /// </summary>
        [Fact]
        public void Get_AtIndex1_ShouldReturnCorrectElement()
        {
            // Arrange
            InlineArray8<int> array = new InlineArray8<int> { _1 = 20 };
            
            // Act
            ref int value = ref InlineArray8<int>.Get(ref array, 1);
            
            // Assert
            Assert.Equal(20, value);
        }
        
        /// <summary>
        ///     Tests that get returns correct element at all indices.
        /// </summary>
        [Fact]
        public void Get_AtAllIndices_ShouldReturnCorrectElements()
        {
            // Arrange
            InlineArray8<int> array = new InlineArray8<int>
            {
                _0 = 0,
                _1 = 1,
                _2 = 2,
                _3 = 3,
                _4 = 4,
                _5 = 5,
                _6 = 6,
                _7 = 7
            };
            
            // Act & Assert
            for (int i = 0; i < 8; i++)
            {
                ref int value = ref InlineArray8<int>.Get(ref array, i);
                Assert.Equal(i, value);
            }
        }
        
        /// <summary>
        ///     Tests that get allows modification through reference.
        /// </summary>
        [Fact]
        public void Get_ModifyThroughReference_ShouldUpdateElement()
        {
            // Arrange
            InlineArray8<int> array = new InlineArray8<int> { _0 = 10 };
            
            // Act
            ref int value = ref InlineArray8<int>.Get(ref array, 0);
            value = 100;
            
            // Assert
            Assert.Equal(100, array._0);
        }
        
        /// <summary>
        ///     Tests that get with reference types works correctly.
        /// </summary>
        [Fact]
        public void Get_WithReferenceTypes_ShouldWorkCorrectly()
        {
            // Arrange
            string str1 = "test1";
            string str2 = "test2";
            InlineArray8<string> array = new InlineArray8<string>
            {
                _0 = str1,
                _1 = str2
            };
            
            // Act
            ref string value0 = ref InlineArray8<string>.Get(ref array, 0);
            ref string value1 = ref InlineArray8<string>.Get(ref array, 1);
            
            // Assert
            Assert.Equal("test1", value0);
            Assert.Equal("test2", value1);
        }
        
        /// <summary>
        ///     Tests that get allows replacing reference through assignment.
        /// </summary>
        [Fact]
        public void Get_ReplaceReference_ShouldUpdateElement()
        {
            // Arrange
            InlineArray8<string> array = new InlineArray8<string> { _0 = "original" };
            
            // Act
            ref string value = ref InlineArray8<string>.Get(ref array, 0);
            value = "modified";
            
            // Assert
            Assert.Equal("modified", array._0);
        }
        
        /// <summary>
        ///     Tests that all 8 elements can be accessed and modified.
        /// </summary>
        [Fact]
        public void Get_AllElements_CanBeAccessedAndModified()
        {
            // Arrange
            InlineArray8<int> array = new InlineArray8<int>();
            
            // Act
            for (int i = 0; i < 8; i++)
            {
                ref int value = ref InlineArray8<int>.Get(ref array, i);
                value = i * 10;
            }
            
            // Assert
            Assert.Equal(0, array._0);
            Assert.Equal(10, array._1);
            Assert.Equal(20, array._2);
            Assert.Equal(30, array._3);
            Assert.Equal(40, array._4);
            Assert.Equal(50, array._5);
            Assert.Equal(60, array._6);
            Assert.Equal(70, array._7);
        }
        
        /// <summary>
        ///     Tests that default values are zero for value types.
        /// </summary>
        [Fact]
        public void DefaultValues_ForValueTypes_ShouldBeZero()
        {
            // Arrange & Act
            InlineArray8<int> array = new InlineArray8<int>();
            
            // Assert
            for (int i = 0; i < 8; i++)
            {
                ref int value = ref InlineArray8<int>.Get(ref array, i);
                Assert.Equal(0, value);
            }
        }
        
        /// <summary>
        ///     Tests that default values are null for reference types.
        /// </summary>
        [Fact]
        public void DefaultValues_ForReferenceTypes_ShouldBeNull()
        {
            // Arrange & Act
            InlineArray8<string> array = new InlineArray8<string>();
            
            // Assert
            for (int i = 0; i < 8; i++)
            {
                ref string value = ref InlineArray8<string>.Get(ref array, i);
                Assert.Null(value);
            }
        }
        
        /// <summary>
        ///     Tests that get with struct types works correctly.
        /// </summary>
        [Fact]
        public void Get_WithStructTypes_ShouldWorkCorrectly()
        {
            // Arrange
            InlineArray8<(int x, int y)> array = new InlineArray8<(int x, int y)>
            {
                _0 = (1, 2),
                _1 = (3, 4)
            };
            
            // Act
            ref (int x, int y) value0 = ref InlineArray8<(int x, int y)>.Get(ref array, 0);
            ref (int x, int y) value1 = ref InlineArray8<(int x, int y)>.Get(ref array, 1);
            
            // Assert
            Assert.Equal((1, 2), value0);
            Assert.Equal((3, 4), value1);
        }
        
        /// <summary>
        ///     Tests that modifications are visible across multiple get calls.
        /// </summary>
        [Fact]
        public void Get_Modifications_ShouldBeVisibleAcrossMultipleCalls()
        {
            // Arrange
            InlineArray8<int> array = new InlineArray8<int>();
            
            // Act
            ref int value1 = ref InlineArray8<int>.Get(ref array, 0);
            value1 = 42;
            ref int value2 = ref InlineArray8<int>.Get(ref array, 0);
            
            // Assert
            Assert.Equal(42, value2);
        }
        
        /// <summary>
        ///     Tests that get at last index works correctly.
        /// </summary>
        [Fact]
        public void Get_AtLastIndex_ShouldWorkCorrectly()
        {
            // Arrange
            InlineArray8<int> array = new InlineArray8<int> { _7 = 777 };
            
            // Act
            ref int value = ref InlineArray8<int>.Get(ref array, 7);
            
            // Assert
            Assert.Equal(777, value);
        }
    }
}

