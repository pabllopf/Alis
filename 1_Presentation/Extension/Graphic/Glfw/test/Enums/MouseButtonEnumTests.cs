// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:MouseButtonEnumTests.cs
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
using Alis.Extension.Graphic.Glfw.Enums;
using Xunit;

namespace Alis.Extension.Graphic.Glfw.Test.Enums
{
    /// <summary>
    ///     Tests for MouseButton enum
    /// </summary>
    public class MouseButtonEnumTests
    {
        /// <summary>
        ///     Tests that mouse button left is defined
        /// </summary>
        [Fact]
        public void MouseButton_Left_IsDefined()
        {
            bool isDefined = Enum.IsDefined(typeof(MouseButton), MouseButton.Left);

            Assert.True(isDefined);
        }

        /// <summary>
        ///     Tests that mouse button right is defined
        /// </summary>
        [Fact]
        public void MouseButton_Right_IsDefined()
        {
            bool isDefined = Enum.IsDefined(typeof(MouseButton), MouseButton.Right);

            Assert.True(isDefined);
        }

        /// <summary>
        ///     Tests that mouse button middle is defined
        /// </summary>
        [Fact]
        public void MouseButton_Middle_IsDefined()
        {
            bool isDefined = Enum.IsDefined(typeof(MouseButton), MouseButton.Middle);

            Assert.True(isDefined);
        }

        /// <summary>
        ///     Tests that mouse button can be cast to int
        /// </summary>
        [Fact]
        public void MouseButton_CanBeCastToInt()
        {
            MouseButton button = MouseButton.Left;

            int value = (int) button;

            Assert.True(value >= 0);
        }

        /// <summary>
        ///     Tests that mouse button can be cast from int
        /// </summary>
        [Fact]
        public void MouseButton_CanBeCastFromInt()
        {
            int value = (int) MouseButton.Left;

            MouseButton button = (MouseButton) value;

            Assert.Equal(MouseButton.Left, button);
        }

        /// <summary>
        ///     Tests that mouse button all buttons are different
        /// </summary>
        [Fact]
        public void MouseButton_AllButtons_AreDifferent()
        {
            Assert.NotEqual(MouseButton.Left, MouseButton.Right);
            Assert.NotEqual(MouseButton.Left, MouseButton.Middle);
            Assert.NotEqual(MouseButton.Right, MouseButton.Middle);
        }
    }
}