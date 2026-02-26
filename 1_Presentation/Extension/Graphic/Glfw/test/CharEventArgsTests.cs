// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:CharEventArgsTests.cs
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

using Alis.Extension.Graphic.Glfw.Enums;
using Xunit;

namespace Alis.Extension.Graphic.Glfw.Test
{
    /// <summary>
    ///     Tests for CharEventArgs class
    /// </summary>
    public class CharEventArgsTests
    {
        /// <summary>
        /// Tests that constructor with valid parameters sets properties
        /// </summary>
        [Fact]
        public void Constructor_WithValidParameters_SetsProperties()
        {
            // Arrange
            uint codePoint = 65; // 'A'
            ModifierKeys modifiers = ModifierKeys.Shift;

            // Act
            CharEventArgs args = new CharEventArgs(codePoint, modifiers);

            // Assert
            Assert.Equal(codePoint, args.CodePoint);
            Assert.Equal(modifiers, args.ModifierKeys);
        }

        /// <summary>
        /// Tests that char with ascii code point returns correct character
        /// </summary>
        [Fact]
        public void Char_WithAsciiCodePoint_ReturnsCorrectCharacter()
        {
            // Arrange
            uint codePoint = 65; // 'A'
            CharEventArgs args = new CharEventArgs(codePoint, ModifierKeys.None);

            // Act
            string result = args.Char;

            // Assert
            Assert.Equal("A", result);
        }

        /// <summary>
        /// Tests that char with unicode code point returns correct character
        /// </summary>
        [Fact]
        public void Char_WithUnicodeCodePoint_ReturnsCorrectCharacter()
        {
            // Arrange
            uint codePoint = 0x1F600; // 😀 emoji
            CharEventArgs args = new CharEventArgs(codePoint, ModifierKeys.None);

            // Act
            string result = args.Char;

            // Assert
            Assert.Equal("😀", result);
        }

        /// <summary>
        /// Tests that char with lowercase code point returns correct character
        /// </summary>
        [Fact]
        public void Char_WithLowercaseCodePoint_ReturnsCorrectCharacter()
        {
            // Arrange
            uint codePoint = 97; // 'a'
            CharEventArgs args = new CharEventArgs(codePoint, ModifierKeys.None);

            // Act
            string result = args.Char;

            // Assert
            Assert.Equal("a", result);
        }

        /// <summary>
        /// Tests that constructor with multiple modifiers stores modifiers
        /// </summary>
        [Fact]
        public void Constructor_WithMultipleModifiers_StoresModifiers()
        {
            // Arrange
            uint codePoint = 65;
            ModifierKeys modifiers = ModifierKeys.Shift | ModifierKeys.Control;

            // Act
            CharEventArgs args = new CharEventArgs(codePoint, modifiers);

            // Assert
            Assert.Equal(modifiers, args.ModifierKeys);
        }

        /// <summary>
        /// Tests that code point property returns correct value
        /// </summary>
        [Fact]
        public void CodePoint_Property_ReturnsCorrectValue()
        {
            // Arrange
            uint codePoint = 12345;
            CharEventArgs args = new CharEventArgs(codePoint, ModifierKeys.None);

            // Act
            uint result = args.CodePoint;

            // Assert
            Assert.Equal(codePoint, result);
        }
    }
}

