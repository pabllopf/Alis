// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:GamePadAxisEnumTests.cs
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
    ///     Tests for GamePadAxis enum
    /// </summary>
    public class GamePadAxisEnumTests
    {
        /// <summary>
        /// Tests that game pad axis left x is defined
        /// </summary>
        [Fact]
        public void GamePadAxis_LeftX_IsDefined()
        {
            Assert.True(Enum.IsDefined(typeof(GamePadAxis), GamePadAxis.LeftX));
        }

        /// <summary>
        /// Tests that game pad axis left y is defined
        /// </summary>
        [Fact]
        public void GamePadAxis_LeftY_IsDefined()
        {
            Assert.True(Enum.IsDefined(typeof(GamePadAxis), GamePadAxis.LeftY));
        }

        /// <summary>
        /// Tests that game pad axis right x is defined
        /// </summary>
        [Fact]
        public void GamePadAxis_RightX_IsDefined()
        {
            Assert.True(Enum.IsDefined(typeof(GamePadAxis), GamePadAxis.RightX));
        }

        /// <summary>
        /// Tests that game pad axis right y is defined
        /// </summary>
        [Fact]
        public void GamePadAxis_RightY_IsDefined()
        {
            Assert.True(Enum.IsDefined(typeof(GamePadAxis), GamePadAxis.RightY));
        }

        /// <summary>
        /// Tests that game pad axis left trigger is defined
        /// </summary>
        [Fact]
        public void GamePadAxis_LeftTrigger_IsDefined()
        {
            Assert.True(Enum.IsDefined(typeof(GamePadAxis), GamePadAxis.LeftTrigger));
        }

        /// <summary>
        /// Tests that game pad axis right trigger is defined
        /// </summary>
        [Fact]
        public void GamePadAxis_RightTrigger_IsDefined()
        {
            Assert.True(Enum.IsDefined(typeof(GamePadAxis), GamePadAxis.RightTrigger));
        }

        /// <summary>
        /// Tests that game pad axis can be cast to int
        /// </summary>
        [Fact]
        public void GamePadAxis_CanBeCastToInt()
        {
            GamePadAxis axis = GamePadAxis.LeftX;
            int value = (int)axis;
            Assert.True(value >= 0);
        }

        /// <summary>
        /// Tests that game pad axis all axes are different
        /// </summary>
        [Fact]
        public void GamePadAxis_AllAxes_AreDifferent()
        {
            Assert.NotEqual(GamePadAxis.LeftX, GamePadAxis.LeftY);
            Assert.NotEqual(GamePadAxis.RightX, GamePadAxis.RightY);
            Assert.NotEqual(GamePadAxis.LeftTrigger, GamePadAxis.RightTrigger);
        }
    }
}

