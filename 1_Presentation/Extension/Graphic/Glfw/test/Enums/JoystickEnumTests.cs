// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:JoystickEnumTests.cs
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
    ///     Tests for Joystick enum
    /// </summary>
    public class JoystickEnumTests
    {
        /// <summary>
        /// Tests that joystick all joysticks are defined
        /// </summary>
        /// <param name="joystick">The joystick</param>
        [Theory]
        [InlineData(Joystick.Joystick1)]
        [InlineData(Joystick.Joystick2)]
        [InlineData(Joystick.Joystick3)]
        [InlineData(Joystick.Joystick4)]
        [InlineData(Joystick.Joystick5)]
        [InlineData(Joystick.Joystick6)]
        [InlineData(Joystick.Joystick7)]
        [InlineData(Joystick.Joystick8)]
        [InlineData(Joystick.Joystick9)]
        [InlineData(Joystick.Joystick10)]
        [InlineData(Joystick.Joystick11)]
        [InlineData(Joystick.Joystick12)]
        [InlineData(Joystick.Joystick13)]
        [InlineData(Joystick.Joystick14)]
        [InlineData(Joystick.Joystick15)]
        [InlineData(Joystick.Joystick16)]
        public void Joystick_AllJoysticks_AreDefined(Joystick joystick)
        {
            Assert.True(Enum.IsDefined(typeof(Joystick), joystick));
        }

        /// <summary>
        /// Tests that joystick can be cast to int
        /// </summary>
        [Fact]
        public void Joystick_CanBeCastToInt()
        {
            Joystick joystick = Joystick.Joystick1;
            int value = (int)joystick;
            Assert.True(value >= 0);
        }

        /// <summary>
        /// Tests that joystick all joysticks have unique values
        /// </summary>
        [Fact]
        public void Joystick_AllJoysticks_HaveUniqueValues()
        {
            Assert.NotEqual((int)Joystick.Joystick1, (int)Joystick.Joystick2);
            Assert.NotEqual((int)Joystick.Joystick1, (int)Joystick.Joystick16);
        }
    }
}

