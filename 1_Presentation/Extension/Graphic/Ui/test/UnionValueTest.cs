// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:UnionValueTest.cs
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
using Xunit;

namespace Alis.Extension.Graphic.Ui.Test
{
    /// <summary>
    ///     The union value test class
    /// </summary>
    public class UnionValueTest
    {
        /// <summary>
        ///     Tests that value i 32 should be initialized correctly
        /// </summary>
        [Fact]
        public void ValueI32_ShouldBeInitializedCorrectly()
        {
            // Arrange
            UnionValue unionValue = new UnionValue {ValueI32 = 42};

            // Act
            int value = unionValue.ValueI32;

            // Assert
            Assert.Equal(42, value);
        }

        /// <summary>
        ///     Tests that value f 32 should be initialized correctly
        /// </summary>
        [Fact]
        public void ValueF32_ShouldBeInitializedCorrectly()
        {
            // Arrange
            UnionValue unionValue = new UnionValue {ValueF32 = 42.0f};

            // Act
            float value = unionValue.ValueF32;

            // Assert
            Assert.Equal(42.0f, value);
        }

        /// <summary>
        ///     Tests that value ptr should be initialized correctly
        /// </summary>
        [Fact]
        public void ValuePtr_ShouldBeInitializedCorrectly()
        {
            // Arrange
            IntPtr ptr = new IntPtr(42);
            UnionValue unionValue = new UnionValue {ValuePtr = ptr};

            // Act
            IntPtr value = unionValue.ValuePtr;

            // Assert
            Assert.Equal(ptr, value);
        }

        /// <summary>
        ///     Tests that value i 32 should overwrite value f 32
        /// </summary>
        [Fact]
        public void ValueI32_ShouldOverwriteValueF32()
        {
            // Arrange
            UnionValue unionValue = new UnionValue {ValueF32 = 42.0f};

            // Act
            unionValue.ValueI32 = 42;

            // Assert
            Assert.Equal(42, unionValue.ValueI32);
            Assert.NotEqual(42.0f, unionValue.ValueF32);
        }

        /// <summary>
        ///     Tests that value f 32 should overwrite value i 32
        /// </summary>
        [Fact]
        public void ValueF32_ShouldOverwriteValueI32()
        {
            // Arrange
            UnionValue unionValue = new UnionValue {ValueI32 = 42};

            // Act
            unionValue.ValueF32 = 42.0f;

            // Assert
            Assert.Equal(42.0f, unionValue.ValueF32);
            Assert.NotEqual(42, unionValue.ValueI32);
        }

        /// <summary>
        ///     Tests that value ptr should overwrite value i 32
        /// </summary>
        [Fact]
        public void ValuePtr_ShouldOverwriteValueI32()
        {
            // Arrange
            UnionValue unionValue = new UnionValue {ValueI32 = 42};
            IntPtr ptr = new IntPtr(42);

            // Act
            unionValue.ValuePtr = ptr;

            // Assert
            Assert.Equal(ptr, unionValue.ValuePtr);
            Assert.Equal(42, unionValue.ValueI32);
        }
    }
}