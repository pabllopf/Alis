// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:CursorTests.cs
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

using System;
using Alis.Extension.Graphic.Glfw.Structs;
using Xunit;

namespace Alis.Extension.Graphic.Glfw.Test.Structs
{
    /// <summary>
    ///     Tests for Cursor structure
    /// </summary>
    public class CursorTests
    {
        /// <summary>
        /// Tests that cursor none is default value
        /// </summary>
        [Fact]
        public void Cursor_None_IsDefaultValue()
        {
            // Arrange & Act
            Cursor none = Cursor.None;

            // Assert
            Assert.Equal(default(Cursor), none);
        }

        /// <summary>
        /// Tests that cursor equals with same cursor returns true
        /// </summary>
        [Fact]
        public void Cursor_Equals_WithSameCursor_ReturnsTrue()
        {
            // Arrange
            Cursor cursor1 = Cursor.None;
            Cursor cursor2 = Cursor.None;

            // Act
            bool result = cursor1.Equals(cursor2);

            // Assert
            Assert.True(result);
        }

        /// <summary>
        /// Tests that cursor equals with object returns correct result
        /// </summary>
        [Fact]
        public void Cursor_Equals_WithObject_ReturnsCorrectResult()
        {
            // Arrange
            Cursor cursor = Cursor.None;
            object obj = Cursor.None;

            // Act
            bool result = cursor.Equals(obj);

            // Assert
            Assert.True(result);
        }

        /// <summary>
        /// Tests that cursor equals with non cursor object returns false
        /// </summary>
        [Fact]
        public void Cursor_Equals_WithNonCursorObject_ReturnsFalse()
        {
            // Arrange
            Cursor cursor = Cursor.None;
            object obj = new object();

            // Act
            bool result = cursor.Equals(obj);

            // Assert
            Assert.False(result);
        }

        /// <summary>
        /// Tests that cursor get hash code returns same for equal cursors
        /// </summary>
        [Fact]
        public void Cursor_GetHashCode_ReturnsSameForEqualCursors()
        {
            // Arrange
            Cursor cursor1 = Cursor.None;
            Cursor cursor2 = Cursor.None;

            // Act
            int hash1 = cursor1.GetHashCode();
            int hash2 = cursor2.GetHashCode();

            // Assert
            Assert.Equal(hash1, hash2);
        }

        /// <summary>
        /// Tests that cursor equality operator with same cursors returns true
        /// </summary>
        [Fact]
        public void Cursor_EqualityOperator_WithSameCursors_ReturnsTrue()
        {
            // Arrange
            Cursor cursor1 = Cursor.None;
            Cursor cursor2 = Cursor.None;

            // Act
            bool result = cursor1 == cursor2;

            // Assert
            Assert.True(result);
        }

        /// <summary>
        /// Tests that cursor inequality operator with same cursors returns false
        /// </summary>
        [Fact]
        public void Cursor_InequalityOperator_WithSameCursors_ReturnsFalse()
        {
            // Arrange
            Cursor cursor1 = Cursor.None;
            Cursor cursor2 = Cursor.None;

            // Act
            bool result = cursor1 != cursor2;

            // Assert
            Assert.False(result);
        }

        /// <summary>
        /// Tests that cursor equals with i equatable interface works
        /// </summary>
        [Fact]
        public void Cursor_Equals_WithIEquatableInterface_Works()
        {
            // Arrange
            Cursor cursor1 = Cursor.None;
            IEquatable<Cursor> cursor2 = Cursor.None;

            // Act
            bool result = cursor1.Equals(cursor2);

            // Assert
            Assert.True(result);
        }
    }
}

