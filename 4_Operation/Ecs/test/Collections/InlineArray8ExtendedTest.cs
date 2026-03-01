// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:InlineArray8ExtendedTest.cs
// 
//  Author:GitHub Copilot
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
    ///     Extended tests for InlineArray8 to validate fixed-size array behavior,
    ///     element access, and compatibility with ref semantics.
    /// </summary>
    public class InlineArray8ExtendedTest
    {
        /// <summary>
        ///     Test that InlineArray8 can store and retrieve elements by index.
        /// </summary>
        [Fact]
        public void Get_SetAndGet_StoresAndRetrievesCorrectly()
        {
            // Arrange
            var array = new InlineArray8<int>();

            // Act
            InlineArray8<int>.Get(ref array, 0) = 10;
            InlineArray8<int>.Get(ref array, 7) = 70;

            // Assert
            Assert.Equal(10, InlineArray8<int>.Get(ref array, 0));
            Assert.Equal(70, InlineArray8<int>.Get(ref array, 7));
        }

        /// <summary>
        ///     Test that InlineArray8 initializes all elements properly.
        /// </summary>
        [Fact]
        public void Get_AllElements_CanBeAccessed()
        {
            // Arrange
            var array = new InlineArray8<int>();

            // Act
            for (int i = 0; i < 8; i++)
            {
                InlineArray8<int>.Get(ref array, i) = i * 10;
            }

            // Assert
            for (int i = 0; i < 8; i++)
            {
                Assert.Equal(i * 10, InlineArray8<int>.Get(ref array, i));
            }
        }

        /// <summary>
        ///     Test that InlineArray8 works with reference types.
        /// </summary>
        [Fact]
        public void Get_ReferenceType_StoresReferences()
        {
            // Arrange
            var array = new InlineArray8<string>();
            var str1 = "Hello";
            var str2 = "World";

            // Act
            InlineArray8<string>.Get(ref array, 0) = str1;
            InlineArray8<string>.Get(ref array, 1) = str2;

            // Assert
            Assert.Equal("Hello", InlineArray8<string>.Get(ref array, 0));
            Assert.Equal("World", InlineArray8<string>.Get(ref array, 1));
        }

        /// <summary>
        ///     Test that InlineArray8 overwrites previous values correctly.
        /// </summary>
        [Fact]
        public void Get_Overwrite_NewValueReplacesPrevious()
        {
            // Arrange
            var array = new InlineArray8<int>();
            InlineArray8<int>.Get(ref array, 3) = 30;

            // Act
            InlineArray8<int>.Get(ref array, 3) = 300;

            // Assert
            Assert.Equal(300, InlineArray8<int>.Get(ref array, 3));
        }

        /// <summary>
        ///     Test that InlineArray8 maintains size of 8 elements.
        /// </summary>
        [Fact]
        public void FixedSize_AlwaysEightElements_EnforcedByType()
        {
            // This is a compile-time constraint, but we can verify the usage pattern
            var array = new InlineArray8<int>();

            // All 8 indices should be accessible
            for (int i = 0; i < 8; i++)
            {
                InlineArray8<int>.Get(ref array, i) = i;
            }

            Assert.Equal(7, InlineArray8<int>.Get(ref array, 7));
        }

        /// <summary>
        ///     Test that InlineArray8 with value types initializes to defaults.
        /// </summary>
        [Fact]
        public void Get_UninitializedAccess_HasDefaultValue()
        {
            // Arrange
            var array = new InlineArray8<int>();

            // Act - Don't initialize
            int value = InlineArray8<int>.Get(ref array, 5);

            // Assert
            Assert.Equal(0, value);
        }

        /// <summary>
        ///     Test that InlineArray8 can be used in struct layouts.
        /// </summary>
        [Fact]
        public void Get_InlineArrayField_Works()
        {
            // This tests that InlineArray8 is compatible with struct layouts
            var array = new InlineArray8<byte>();
            InlineArray8<byte>.Get(ref array, 0) = 255;
            InlineArray8<byte>.Get(ref array, 1) = 128;

            Assert.Equal(255, InlineArray8<byte>.Get(ref array, 0));
            Assert.Equal(128, InlineArray8<byte>.Get(ref array, 1));
        }

        /// <summary>
        ///     Test that InlineArray8 with guid values works correctly.
        /// </summary>
        [Fact]
        public void Get_ValueTypeGuid_StoresAndRetrieves()
        {
            // Arrange
            var array = new InlineArray8<System.Guid>();
            var guid = System.Guid.NewGuid();

            // Act
            InlineArray8<System.Guid>.Get(ref array, 0) = guid;

            // Assert
            Assert.Equal(guid, InlineArray8<System.Guid>.Get(ref array, 0));
        }
    }
}

