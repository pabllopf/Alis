// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:KeysEnumTests.cs
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
    ///     Tests for Keys enum
    /// </summary>
    public class KeysEnumTests
    {
        /// <summary>
        /// Tests that keys unknown has correct value
        /// </summary>
        [Fact]
        public void Keys_Unknown_HasCorrectValue()
        {
            // Assert
            Assert.Equal(-1, (int)Keys.Unknown);
        }

        /// <summary>
        /// Tests that keys space has correct value
        /// </summary>
        [Fact]
        public void Keys_Space_HasCorrectValue()
        {
            // Assert
            Assert.Equal(32, (int)Keys.Space);
        }

        /// <summary>
        /// Tests that keys a is defined
        /// </summary>
        [Fact]
        public void Keys_A_IsDefined()
        {
            // Act
            bool isDefined = Enum.IsDefined(typeof(Keys), Keys.A);

            // Assert
            Assert.True(isDefined);
        }

        /// <summary>
        /// Tests that keys escape is defined
        /// </summary>
        [Fact]
        public void Keys_Escape_IsDefined()
        {
            // Act
            bool isDefined = Enum.IsDefined(typeof(Keys), Keys.Escape);

            // Assert
            Assert.True(isDefined);
        }

        /// <summary>
        /// Tests that keys enter is defined
        /// </summary>
        [Fact]
        public void Keys_Enter_IsDefined()
        {
            // Act
            bool isDefined = Enum.IsDefined(typeof(Keys), Keys.Enter);

            // Assert
            Assert.True(isDefined);
        }

        /// <summary>
        /// Tests that keys can be cast to int
        /// </summary>
        [Fact]
        public void Keys_CanBeCastToInt()
        {
            // Arrange
            Keys key = Keys.A;

            // Act
            int value = (int)key;

            // Assert
            Assert.True(value > 0);
        }

        /// <summary>
        /// Tests that keys can be cast from int
        /// </summary>
        [Fact]
        public void Keys_CanBeCastFromInt()
        {
            // Arrange
            int value = 32;

            // Act
            Keys key = (Keys)value;

            // Assert
            Assert.Equal(Keys.Space, key);
        }

        /// <summary>
        /// Tests that keys all alpha keys are defined
        /// </summary>
        [Fact]
        public void Keys_AllAlphaKeys_AreDefined()
        {
            // Assert
            Assert.True(Enum.IsDefined(typeof(Keys), Keys.A));
            Assert.True(Enum.IsDefined(typeof(Keys), Keys.Z));
        }

        /// <summary>
        /// Tests that keys all numeric keys are defined
        /// </summary>
        [Fact]
        public void Keys_AllNumericKeys_AreDefined()
        {
            // Assert
            Assert.True(Enum.IsDefined(typeof(Keys), Keys.Alpha0));
            Assert.True(Enum.IsDefined(typeof(Keys), Keys.Alpha9));
        }

        /// <summary>
        /// Tests that keys function keys are defined
        /// </summary>
        [Fact]
        public void Keys_FunctionKeys_AreDefined()
        {
            // Assert
            Assert.True(Enum.IsDefined(typeof(Keys), Keys.F1));
            Assert.True(Enum.IsDefined(typeof(Keys), Keys.F12));
        }
    }
}

