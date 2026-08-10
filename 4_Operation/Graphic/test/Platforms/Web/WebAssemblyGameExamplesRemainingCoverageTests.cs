// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:WebAssemblyGameExamplesRemainingCoverageTests.cs
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

using Alis.Core.Graphic.Platforms.Web;
using Xunit;

namespace Alis.Core.Graphic.Test.Platforms.Web
{
    /// <summary>
    ///     The web assembly game examples remaining coverage tests class
    /// </summary>
    public class WebAssemblyGameExamplesRemainingCoverageTests
    {
        /// <summary>
        ///     Tests that apply deadzone zeroes below deadzone
        /// </summary>
        [Fact]
        public void ApplyDeadzone_BelowDeadzone_Zeroes()
        {
            float x = 0.05f;
            float y = 0.05f;

            GameDevelopmentUtils.ApplyDeadzone(ref x, ref y, 0.15f);

            Assert.Equal(0f, x, 5);
            Assert.Equal(0f, y, 5);
        }

        /// <summary>
        ///     Tests that apply deadzone scales above deadzone
        /// </summary>
        [Fact]
        public void ApplyDeadzone_AboveDeadzone_Scales()
        {
            float x = 1.0f;
            float y = 0.0f;

            GameDevelopmentUtils.ApplyDeadzone(ref x, ref y, 0.15f);

            Assert.Equal(1.0f, x, 5);
            Assert.Equal(0f, y, 5);
        }

        /// <summary>
        ///     Tests that normalize input with magnitude above one normalizes
        /// </summary>
        [Fact]
        public void NormalizeInput_AboveOne_Normalizes()
        {
            float x = 2.0f;
            float y = 0.0f;

            GameDevelopmentUtils.NormalizeInput(ref x, ref y);

            Assert.Equal(1.0f, x, 5);
            Assert.Equal(0f, y, 5);
        }

        /// <summary>
        ///     Tests that normalize input with magnitude below one keeps values
        /// </summary>
        [Fact]
        public void NormalizeInput_BelowOne_KeepsValues()
        {
            float x = 0.5f;
            float y = 0.0f;

            GameDevelopmentUtils.NormalizeInput(ref x, ref y);

            Assert.Equal(0.5f, x, 5);
        }

        /// <summary>
        ///     Tests that get gamepad button name returns expected names
        /// </summary>
        [Fact]
        public void GetGamepadButtonName_ReturnsExpectedNames()
        {
            Assert.Equal("A / Cross", GameDevelopmentUtils.GetGamepadButtonName(0));
            Assert.Equal("B / Circle", GameDevelopmentUtils.GetGamepadButtonName(1));
            Assert.Equal("X / Square", GameDevelopmentUtils.GetGamepadButtonName(2));
            Assert.Equal("Y / Triangle", GameDevelopmentUtils.GetGamepadButtonName(3));
            Assert.Equal("LB / L1", GameDevelopmentUtils.GetGamepadButtonName(4));
            Assert.Equal("RB / R1", GameDevelopmentUtils.GetGamepadButtonName(5));
            Assert.Equal("LT", GameDevelopmentUtils.GetGamepadButtonName(6));
            Assert.Equal("RT", GameDevelopmentUtils.GetGamepadButtonName(7));
            Assert.Equal("Back / Select", GameDevelopmentUtils.GetGamepadButtonName(8));
            Assert.Equal("Start", GameDevelopmentUtils.GetGamepadButtonName(9));
            Assert.Equal("Left Stick Click", GameDevelopmentUtils.GetGamepadButtonName(10));
            Assert.Equal("Right Stick Click", GameDevelopmentUtils.GetGamepadButtonName(11));
            Assert.Equal("Guide / Home", GameDevelopmentUtils.GetGamepadButtonName(12));
        }

        /// <summary>
        ///     Tests that get gamepad button name with unknown index returns generic
        /// </summary>
        [Fact]
        public void GetGamepadButtonName_WithUnknownIndex_ReturnsGeneric()
        {
            Assert.Equal("Button 20", GameDevelopmentUtils.GetGamepadButtonName(20));
        }
    }
}
