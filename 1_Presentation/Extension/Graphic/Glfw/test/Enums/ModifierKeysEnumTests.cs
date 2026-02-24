// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ModifierKeysEnumTests.cs
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
using Alis.Extension.Graphic.Glfw.Enums;
using Xunit;

namespace Alis.Extension.Graphic.Glfw.Test.Enums
{
    /// <summary>
    ///     Tests for ModifierKeys enum
    /// </summary>
    public class ModifierKeysEnumTests
    {
        /// <summary>
        /// Tests that modifier keys none is defined
        /// </summary>
        [Fact]
        public void ModifierKeys_None_IsDefined()
        {
            // Act
            bool isDefined = Enum.IsDefined(typeof(ModifierKeys), ModifierKeys.None);

            // Assert
            Assert.True(isDefined);
        }

        /// <summary>
        /// Tests that modifier keys shift is defined
        /// </summary>
        [Fact]
        public void ModifierKeys_Shift_IsDefined()
        {
            // Act
            bool isDefined = Enum.IsDefined(typeof(ModifierKeys), ModifierKeys.Shift);

            // Assert
            Assert.True(isDefined);
        }

        /// <summary>
        /// Tests that modifier keys control is defined
        /// </summary>
        [Fact]
        public void ModifierKeys_Control_IsDefined()
        {
            // Act
            bool isDefined = Enum.IsDefined(typeof(ModifierKeys), ModifierKeys.Control);

            // Assert
            Assert.True(isDefined);
        }

        /// <summary>
        /// Tests that modifier keys alt is defined
        /// </summary>
        [Fact]
        public void ModifierKeys_Alt_IsDefined()
        {
            // Act
            bool isDefined = Enum.IsDefined(typeof(ModifierKeys), ModifierKeys.Alt);

            // Assert
            Assert.True(isDefined);
        }

        /// <summary>
        /// Tests that modifier keys super is defined
        /// </summary>
        [Fact]
        public void ModifierKeys_Super_IsDefined()
        {
            // Act
            bool isDefined = Enum.IsDefined(typeof(ModifierKeys), ModifierKeys.Super);

            // Assert
            Assert.True(isDefined);
        }

        /// <summary>
        /// Tests that modifier keys can be combined with bitwise or
        /// </summary>
        [Fact]
        public void ModifierKeys_CanBeCombinedWithBitwiseOr()
        {
            // Arrange & Act
            ModifierKeys combined = ModifierKeys.Shift | ModifierKeys.Control;

            // Assert
            Assert.NotEqual(ModifierKeys.None, combined);
            Assert.True((combined & ModifierKeys.Shift) == ModifierKeys.Shift);
            Assert.True((combined & ModifierKeys.Control) == ModifierKeys.Control);
        }

        /// <summary>
        /// Tests that modifier keys can be checked with bitwise and
        /// </summary>
        [Fact]
        public void ModifierKeys_CanBeCheckedWithBitwiseAnd()
        {
            // Arrange
            ModifierKeys modifiers = ModifierKeys.Shift | ModifierKeys.Control;

            // Act
            bool hasShift = (modifiers & ModifierKeys.Shift) == ModifierKeys.Shift;
            bool hasAlt = (modifiers & ModifierKeys.Alt) == ModifierKeys.Alt;

            // Assert
            Assert.True(hasShift);
            Assert.False(hasAlt);
        }

        /// <summary>
        /// Tests that modifier keys none has zero value
        /// </summary>
        [Fact]
        public void ModifierKeys_None_HasZeroValue()
        {
            // Assert
            Assert.Equal(0, (int)ModifierKeys.None);
        }

        /// <summary>
        /// Tests that modifier keys can be cast to int
        /// </summary>
        [Fact]
        public void ModifierKeys_CanBeCastToInt()
        {
            // Arrange
            ModifierKeys modifier = ModifierKeys.Shift;

            // Act
            int value = (int)modifier;

            // Assert
            Assert.True(value > 0);
        }

        /// <summary>
        /// Tests that modifier keys all modifiers are different
        /// </summary>
        [Fact]
        public void ModifierKeys_AllModifiers_AreDifferent()
        {
            // Assert
            Assert.NotEqual(ModifierKeys.Shift, ModifierKeys.Control);
            Assert.NotEqual(ModifierKeys.Shift, ModifierKeys.Alt);
            Assert.NotEqual(ModifierKeys.Control, ModifierKeys.Alt);
        }
    }
}

