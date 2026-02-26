// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:CursorModeEnumTests.cs
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
    ///     Tests for CursorMode enum
    /// </summary>
    public class CursorModeEnumTests
    {
        /// <summary>
        /// Tests that cursor mode normal is defined
        /// </summary>
        [Fact]
        public void CursorMode_Normal_IsDefined()
        {
            // Act
            bool isDefined = Enum.IsDefined(typeof(CursorMode), CursorMode.Normal);

            // Assert
            Assert.True(isDefined);
        }

        /// <summary>
        /// Tests that cursor mode hidden is defined
        /// </summary>
        [Fact]
        public void CursorMode_Hidden_IsDefined()
        {
            // Act
            bool isDefined = Enum.IsDefined(typeof(CursorMode), CursorMode.Hidden);

            // Assert
            Assert.True(isDefined);
        }

        /// <summary>
        /// Tests that cursor mode disabled is defined
        /// </summary>
        [Fact]
        public void CursorMode_Disabled_IsDefined()
        {
            // Act
            bool isDefined = Enum.IsDefined(typeof(CursorMode), CursorMode.Disabled);

            // Assert
            Assert.True(isDefined);
        }

        /// <summary>
        /// Tests that cursor mode can be cast to int
        /// </summary>
        [Fact]
        public void CursorMode_CanBeCastToInt()
        {
            // Arrange
            CursorMode mode = CursorMode.Normal;

            // Act
            int value = (int)mode;

            // Assert
            Assert.True(value >= 0);
        }

        /// <summary>
        /// Tests that cursor mode all modes are different
        /// </summary>
        [Fact]
        public void CursorMode_AllModes_AreDifferent()
        {
            // Assert
            Assert.NotEqual(CursorMode.Normal, CursorMode.Hidden);
            Assert.NotEqual(CursorMode.Normal, CursorMode.Disabled);
            Assert.NotEqual(CursorMode.Hidden, CursorMode.Disabled);
        }
    }
}

