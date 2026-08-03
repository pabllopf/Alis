// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:WebAssemblyGameExamplesSafeTests.cs
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
using Alis.Core.Graphic.Platforms.Web;
using Alis.Core.Graphic.Test.Attributes;
using Xunit;

namespace Alis.Core.Graphic.Test.Platforms.Web
{
    /// <summary>
    ///     Safe tests for GameDevelopmentUtils that only exercise pure logic
    ///     (no browser/WebAssembly runtime required).
    /// </summary>
    public class WebAssemblyGameExamplesSafeTests
    {
        /// <summary>
        ///     Tests that ApplyDeadzero zeroes values below the deadzone.
        /// </summary>
        [WebOnly]
        public void ApplyDeadzone_BelowDeadzone_ZeroesValues()
        {
            float x = 0.1f;
            float y = 0.05f;
            GameDevelopmentUtils.ApplyDeadzone(ref x, ref y, 0.15f);
            Assert.Equal(0, x);
            Assert.Equal(0, y);
        }

        /// <summary>
        ///     Tests that ApplyDeadzone applies scaling for values above the deadzone.
        /// </summary>
        [WebOnlyAttribute]
        public void ApplyDeadzone_AboveDeadzone_AppliesScaling()
        {
            float x = 0.5f;
            float y = 0.5f;
            GameDevelopmentUtils.ApplyDeadzone(ref x, ref y, 0.15f);
            float magnitude = (float)Math.Sqrt(x * x + y * y);
            Assert.True(magnitude > 0);
            Assert.True(magnitude <= 1.0f);
        }

        /// <summary>
        ///     Tests that NormalizeInput normalizes when magnitude exceeds 1.
        /// </summary>
        [WebOnlyAttribute]
        public void NormalizeInput_MagnitudeAboveOne_Normalizes()
        {
            float x = 2.0f;
            float y = 0.0f;
            GameDevelopmentUtils.NormalizeInput(ref x, ref y);
            float magnitude = (float)Math.Sqrt(x * x + y * y);
            Assert.Equal(1.0f, magnitude, 5);
        }

        /// <summary>
        ///     Tests that NormalizeInput keeps values unchanged when magnitude is <= 1.
        /// </summary>
        [WebOnlyAttribute]
        public void NormalizeInput_MagnitudeBelowOrEqualOne_KeepsValues()
        {
            float x = 0.3f;
            float y = 0.4f;
            GameDevelopmentUtils.NormalizeInput(ref x, ref y);
            Assert.Equal(0.3f, x, 5);
            Assert.Equal(0.4f, y, 5);
        }

        /// <summary>
        ///     Tests that GetGamepadButtonName returns correct names for known indices.
        /// </summary>
        [Theory]
        [InlineData(0, "A / Cross")]
        [InlineData(1, "B / Circle")]
        [InlineData(2, "X / Square")]
        [InlineData(3, "Y / Triangle")]
        [InlineData(4, "LB / L1")]
        [InlineData(5, "RB / R1")]
        [InlineData(6, "LT")]
        [InlineData(7, "RT")]
        [InlineData(8, "Back / Select")]
        [InlineData(9, "Start")]
        [InlineData(10, "Left Stick Click")]
        [InlineData(11, "Right Stick Click")]
        [InlineData(12, "Guide / Home")]
        [InlineData(13, "Button 13")]
        public void GetGamepadButtonName_ReturnsCorrectName(int index, string expected)
        {
            string name = GameDevelopmentUtils.GetGamepadButtonName(index);
            Assert.Equal(expected, name);
        }

        /// <summary>
        ///     Tests that GetKeyName returns a non-null, non-empty string for any ConsoleKey.
        /// </summary>
        [WebOnlyAttribute]
        public void GetKeyName_ReturnsString()
        {
            string name = GameDevelopmentUtils.GetKeyName(ConsoleKey.A);
            Assert.NotNull(name);
            Assert.NotEmpty(name);
        }

        /// <summary>
        ///     Tests that GetKeyName returns correct known names.
        /// </summary>
        [WebOnlyAttribute]
        public void GetKeyName_ReturnsCorrectName()
        {
            Assert.Equal("A", GameDevelopmentUtils.GetKeyName(ConsoleKey.A));
            Assert.Equal("Enter", GameDevelopmentUtils.GetKeyName(ConsoleKey.Enter));
        }
    }
}
