// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:WindowAttributeEnumTests.cs
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
    ///     Tests for WindowAttribute enum
    /// </summary>
    public class WindowAttributeEnumTests
    {
        /// <summary>
        /// Tests that window attribute focused is defined
        /// </summary>
        [Fact]
        public void WindowAttribute_Focused_IsDefined()
        {
            // Act
            bool isDefined = Enum.IsDefined(typeof(WindowAttribute), WindowAttribute.Focused);

            // Assert
            Assert.True(isDefined);
        }

        /// <summary>
        /// Tests that window attribute resizable is defined
        /// </summary>
        [Fact]
        public void WindowAttribute_Resizable_IsDefined()
        {
            // Act
            bool isDefined = Enum.IsDefined(typeof(WindowAttribute), WindowAttribute.Resizable);

            // Assert
            Assert.True(isDefined);
        }

        /// <summary>
        /// Tests that window attribute visible is defined
        /// </summary>
        [Fact]
        public void WindowAttribute_Visible_IsDefined()
        {
            // Act
            bool isDefined = Enum.IsDefined(typeof(WindowAttribute), WindowAttribute.Visible);

            // Assert
            Assert.True(isDefined);
        }

        /// <summary>
        /// Tests that window attribute decorated is defined
        /// </summary>
        [Fact]
        public void WindowAttribute_Decorated_IsDefined()
        {
            // Act
            bool isDefined = Enum.IsDefined(typeof(WindowAttribute), WindowAttribute.Decorated);

            // Assert
            Assert.True(isDefined);
        }

        /// <summary>
        /// Tests that window attribute auto iconify is defined
        /// </summary>
        [Fact]
        public void WindowAttribute_AutoIconify_IsDefined()
        {
            // Act
            bool isDefined = Enum.IsDefined(typeof(WindowAttribute), WindowAttribute.AutoIconify);

            // Assert
            Assert.True(isDefined);
        }

        /// <summary>
        /// Tests that window attribute floating is defined
        /// </summary>
        [Fact]
        public void WindowAttribute_Floating_IsDefined()
        {
            // Act
            bool isDefined = Enum.IsDefined(typeof(WindowAttribute), WindowAttribute.Floating);

            // Assert
            Assert.True(isDefined);
        }

        /// <summary>
        /// Tests that window attribute maximized is defined
        /// </summary>
        [Fact]
        public void WindowAttribute_Maximized_IsDefined()
        {
            // Act
            bool isDefined = Enum.IsDefined(typeof(WindowAttribute), WindowAttribute.Maximized);

            // Assert
            Assert.True(isDefined);
        }

        /// <summary>
        /// Tests that window attribute can be cast to int
        /// </summary>
        [Fact]
        public void WindowAttribute_CanBeCastToInt()
        {
            // Arrange
            WindowAttribute attribute = WindowAttribute.Visible;

            // Act
            int value = (int)attribute;

            // Assert
            Assert.True(value != 0);
        }

        /// <summary>
        /// Tests that window attribute can be cast from int
        /// </summary>
        [Fact]
        public void WindowAttribute_CanBeCastFromInt()
        {
            // Arrange
            int value = (int)WindowAttribute.Visible;

            // Act
            WindowAttribute attribute = (WindowAttribute)value;

            // Assert
            Assert.Equal(WindowAttribute.Visible, attribute);
        }
    }
}

