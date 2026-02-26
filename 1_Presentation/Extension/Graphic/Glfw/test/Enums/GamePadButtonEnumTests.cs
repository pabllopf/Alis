// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:GamePadButtonEnumTests.cs
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
    ///     Tests for GamePadButton enum
    /// </summary>
    public class GamePadButtonEnumTests
    {
        [Fact]
        public void GamePadButton_A_IsDefined()
        {
            Assert.True(Enum.IsDefined(typeof(GamePadButton), GamePadButton.A));
        }

        [Fact]
        public void GamePadButton_B_IsDefined()
        {
            Assert.True(Enum.IsDefined(typeof(GamePadButton), GamePadButton.B));
        }

        [Fact]
        public void GamePadButton_X_IsDefined()
        {
            Assert.True(Enum.IsDefined(typeof(GamePadButton), GamePadButton.X));
        }

        [Fact]
        public void GamePadButton_Y_IsDefined()
        {
            Assert.True(Enum.IsDefined(typeof(GamePadButton), GamePadButton.Y));
        }

        [Fact]
        public void GamePadButton_LeftBumper_IsDefined()
        {
            Assert.True(Enum.IsDefined(typeof(GamePadButton), GamePadButton.LeftBumper));
        }

        [Fact]
        public void GamePadButton_RightBumper_IsDefined()
        {
            Assert.True(Enum.IsDefined(typeof(GamePadButton), GamePadButton.RightBumper));
        }

        [Fact]
        public void GamePadButton_Back_IsDefined()
        {
            Assert.True(Enum.IsDefined(typeof(GamePadButton), GamePadButton.Back));
        }

        [Fact]
        public void GamePadButton_Start_IsDefined()
        {
            Assert.True(Enum.IsDefined(typeof(GamePadButton), GamePadButton.Start));
        }

        [Fact]
        public void GamePadButton_Guide_IsDefined()
        {
            Assert.True(Enum.IsDefined(typeof(GamePadButton), GamePadButton.Guide));
        }

        [Fact]
        public void GamePadButton_LeftThumb_IsDefined()
        {
            Assert.True(Enum.IsDefined(typeof(GamePadButton), GamePadButton.LeftThumb));
        }

        [Fact]
        public void GamePadButton_RightThumb_IsDefined()
        {
            Assert.True(Enum.IsDefined(typeof(GamePadButton), GamePadButton.RightThumb));
        }

        [Fact]
        public void GamePadButton_DPadUp_IsDefined()
        {
            Assert.True(Enum.IsDefined(typeof(GamePadButton), GamePadButton.DpadUp));
        }

        [Fact]
        public void GamePadButton_DPadRight_IsDefined()
        {
            Assert.True(Enum.IsDefined(typeof(GamePadButton), GamePadButton.DpadRight));
        }

        [Fact]
        public void GamePadButton_DPadDown_IsDefined()
        {
            Assert.True(Enum.IsDefined(typeof(GamePadButton), GamePadButton.DpadDown));
        }

        [Fact]
        public void GamePadButton_DPadLeft_IsDefined()
        {
            Assert.True(Enum.IsDefined(typeof(GamePadButton), GamePadButton.DpadLeft));
        }

        [Fact]
        public void GamePadButton_CanBeCastToInt()
        {
            GamePadButton button = GamePadButton.A;
            int value = (int)button;
            Assert.True(value >= 0);
        }

        [Fact]
        public void GamePadButton_AllButtons_AreDifferent()
        {
            Assert.NotEqual(GamePadButton.A, GamePadButton.B);
            Assert.NotEqual(GamePadButton.X, GamePadButton.Y);
            Assert.NotEqual(GamePadButton.Start, GamePadButton.Back);
        }
    }
}

