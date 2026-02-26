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
        [Fact]
        public void GamePadAxis_LeftX_IsDefined()
        {
            Assert.True(Enum.IsDefined(typeof(GamePadAxis), GamePadAxis.LeftX));
        }

        [Fact]
        public void GamePadAxis_LeftY_IsDefined()
        {
            Assert.True(Enum.IsDefined(typeof(GamePadAxis), GamePadAxis.LeftY));
        }

        [Fact]
        public void GamePadAxis_RightX_IsDefined()
        {
            Assert.True(Enum.IsDefined(typeof(GamePadAxis), GamePadAxis.RightX));
        }

        [Fact]
        public void GamePadAxis_RightY_IsDefined()
        {
            Assert.True(Enum.IsDefined(typeof(GamePadAxis), GamePadAxis.RightY));
        }

        [Fact]
        public void GamePadAxis_LeftTrigger_IsDefined()
        {
            Assert.True(Enum.IsDefined(typeof(GamePadAxis), GamePadAxis.LeftTrigger));
        }

        [Fact]
        public void GamePadAxis_RightTrigger_IsDefined()
        {
            Assert.True(Enum.IsDefined(typeof(GamePadAxis), GamePadAxis.RightTrigger));
        }

        [Fact]
        public void GamePadAxis_CanBeCastToInt()
        {
            GamePadAxis axis = GamePadAxis.LeftX;
            int value = (int)axis;
            Assert.True(value >= 0);
        }

        [Fact]
        public void GamePadAxis_AllAxes_AreDifferent()
        {
            Assert.NotEqual(GamePadAxis.LeftX, GamePadAxis.LeftY);
            Assert.NotEqual(GamePadAxis.RightX, GamePadAxis.RightY);
            Assert.NotEqual(GamePadAxis.LeftTrigger, GamePadAxis.RightTrigger);
        }
    }
}

