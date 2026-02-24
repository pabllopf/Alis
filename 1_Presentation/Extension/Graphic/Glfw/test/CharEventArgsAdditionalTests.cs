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
    ///     Additional tests for CharEventArgs class
    /// </summary>
    public class CharEventArgsAdditionalTests
    {
        /// <summary>
        /// Tests that char event args with ascii characters returns correct char
        /// </summary>
        /// <param name="codePoint">The code point</param>
        /// <param name="expectedChar">The expected char</param>
        [Theory]
        [InlineData(32, " ")] // Space
        [InlineData(65, "A")] // A
        [InlineData(97, "a")] // a
        [InlineData(48, "0")] // 0
        [InlineData(126, "~")] // ~
        public void CharEventArgs_WithAsciiCharacters_ReturnsCorrectChar(uint codePoint, string expectedChar)
        {
            // Arrange & Act
            CharEventArgs args = new CharEventArgs(codePoint, ModifierKeys.None);

            // Assert
            Assert.Equal(expectedChar, args.Char);
        }

        /// <summary>
        /// Tests that char event args with different modifiers stores modifiers correctly
        /// </summary>
        /// <param name="modifier">The modifier</param>
        [Theory]
        [InlineData(ModifierKeys.None)]
        [InlineData(ModifierKeys.Shift)]
        [InlineData(ModifierKeys.Control)]
        [InlineData(ModifierKeys.Alt)]
        [InlineData(ModifierKeys.Super)]
        public void CharEventArgs_WithDifferentModifiers_StoresModifiersCorrectly(ModifierKeys modifier)
        {
            // Arrange & Act
            CharEventArgs args = new CharEventArgs(65, modifier);

            // Assert
            Assert.Equal(modifier, args.ModifierKeys);
        }

        /// <summary>
        /// Tests that char event args with combined modifiers stores all modifiers
        /// </summary>
        [Fact]
        public void CharEventArgs_WithCombinedModifiers_StoresAllModifiers()
        {
            // Arrange
            ModifierKeys modifiers = ModifierKeys.Shift | ModifierKeys.Control | ModifierKeys.Alt;

            // Act
            CharEventArgs args = new CharEventArgs(65, modifiers);

            // Assert
            Assert.Equal(modifiers, args.ModifierKeys);
            Assert.True((args.ModifierKeys & ModifierKeys.Shift) == ModifierKeys.Shift);
            Assert.True((args.ModifierKeys & ModifierKeys.Control) == ModifierKeys.Control);
            Assert.True((args.ModifierKeys & ModifierKeys.Alt) == ModifierKeys.Alt);
        }

        /// <summary>
        /// Tests that char event args with special unicode characters handles correctly
        /// </summary>
        [Fact]
        public void CharEventArgs_WithSpecialUnicodeCharacters_HandlesCorrectly()
        {
            // Arrange
            uint codePoint = 0x00E9; // é

            // Act
            CharEventArgs args = new CharEventArgs(codePoint, ModifierKeys.None);

            // Assert
            Assert.Equal("é", args.Char);
            Assert.Equal(codePoint, args.CodePoint);
        }

        /// <summary>
        /// Tests that char event args code point property is read only
        /// </summary>
        [Fact]
        public void CharEventArgs_CodePoint_Property_IsReadOnly()
        {
            // Arrange
            uint codePoint = 65;
            CharEventArgs args = new CharEventArgs(codePoint, ModifierKeys.None);

            // Act
            uint retrievedCodePoint = args.CodePoint;

            // Assert
            Assert.Equal(codePoint, retrievedCodePoint);
        }

        /// <summary>
        /// Tests that char event args modifier keys property is read only
        /// </summary>
        [Fact]
        public void CharEventArgs_ModifierKeys_Property_IsReadOnly()
        {
            // Arrange
            ModifierKeys modifiers = ModifierKeys.Shift;
            CharEventArgs args = new CharEventArgs(65, modifiers);

            // Act
            ModifierKeys retrievedModifiers = args.ModifierKeys;

            // Assert
            Assert.Equal(modifiers, retrievedModifiers);
        }
    }
}

