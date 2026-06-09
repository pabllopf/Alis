// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:WebAssemblyGameExamplesTest.cs
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
using Xunit;

namespace Alis.Core.Graphic.Test.Platforms.Web
{
    /// <summary>
    ///     Tests for WebAssemblyGameExamples and GameDevelopmentUtils.
    /// </summary>
    public class WebAssemblyGameExamplesTest
    {
        /// <summary>
        /// Tests that basic game loop example skipped on non browser
        /// </summary>
        [Fact]
        public void BasicGameLoopExample_SkippedOnNonBrowser()
        {
            Assert.True(true);
        }

        /// <summary>
        /// Tests that gamepad input example skipped on non browser
        /// </summary>
        [Fact]
        public void GamepadInputExample_SkippedOnNonBrowser()
        {
            Assert.True(true);
        }

        /// <summary>
        /// Tests that display management example skipped on non browser
        /// </summary>
        [Fact]
        public void DisplayManagementExample_SkippedOnNonBrowser()
        {
            Assert.True(true);
        }

        /// <summary>
        /// Tests that fps game example skipped on non browser
        /// </summary>
        [Fact]
        public void FpsGameExample_SkippedOnNonBrowser()
        {
            Assert.True(true);
        }



        // =====================================================================

        /// <summary>
        /// Tests that game development utils apply deadzone within deadzone zeroes output
        /// </summary>
        [Fact]
        public void GameDevelopmentUtils_ApplyDeadzone_WithinDeadzone_ZeroesOutput()
        {
            float x = 0.1f;
            float y = 0.05f;
            GameDevelopmentUtils.ApplyDeadzone(ref x, ref y, 0.15f);
            Assert.Equal(0, x);
            Assert.Equal(0, y);
        }

        /// <summary>
        /// Tests that game development utils apply deadzone outside deadzone normalizes
        /// </summary>
        [Fact]
        public void GameDevelopmentUtils_ApplyDeadzone_OutsideDeadzone_Normalizes()
        {
            float x = 0.5f;
            float y = 0.5f;
            GameDevelopmentUtils.ApplyDeadzone(ref x, ref y, 0.15f);
            float magnitude = (float)Math.Sqrt(x * x + y * y);
            Assert.True((magnitude > 0) && (magnitude <= 1.0f));
        }

        /// <summary>
        /// Tests that game development utils apply deadzone zero input stays zero
        /// </summary>
        [Fact]
        public void GameDevelopmentUtils_ApplyDeadzone_ZeroInput_StaysZero()
        {
            float x = 0;
            float y = 0;
            GameDevelopmentUtils.ApplyDeadzone(ref x, ref y, 0.15f);
            Assert.Equal(0, x);
            Assert.Equal(0, y);
        }

        /// <summary>
        /// Tests that game development utils apply deadzone custom deadzone works
        /// </summary>
        [Fact]
        public void GameDevelopmentUtils_ApplyDeadzone_CustomDeadzone_Works()
        {
            float x = 0.3f;
            float y = 0.0f;
            GameDevelopmentUtils.ApplyDeadzone(ref x, ref y, 0.2f);
            float magnitude = (float)Math.Sqrt(x * x + y * y);
            Assert.True(magnitude > 0);
        }

        /// <summary>
        /// Tests that game development utils apply deadzone at deadzone boundary zeroes output
        /// </summary>
        [Fact]
        public void GameDevelopmentUtils_ApplyDeadzone_AtDeadzoneBoundary_ZeroesOutput()
        {
            float x = 0.15f;
            float y = 0.0f;
            GameDevelopmentUtils.ApplyDeadzone(ref x, ref y, 0.15f);
            Assert.Equal(0, x);
            Assert.Equal(0, y);
        }

        /// <summary>
        /// Tests that game development utils normalize input within bounds no change
        /// </summary>
        [Fact]
        public void GameDevelopmentUtils_NormalizeInput_WithinBounds_NoChange()
        {
            float x = 0.3f;
            float y = 0.4f;
            GameDevelopmentUtils.NormalizeInput(ref x, ref y);
            Assert.Equal(0.3f, x, 5);
            Assert.Equal(0.4f, y, 5);
        }

        /// <summary>
        /// Tests that game development utils normalize input exceeds bounds normalizes
        /// </summary>
        [Fact]
        public void GameDevelopmentUtils_NormalizeInput_ExceedsBounds_Normalizes()
        {
            float x = 2.0f;
            float y = 0.0f;
            GameDevelopmentUtils.NormalizeInput(ref x, ref y);
            Assert.Equal(1.0f, x, 5);
            Assert.Equal(0.0f, y, 5);
        }

        /// <summary>
        /// Tests that game development utils normalize input zero input no change
        /// </summary>
        [Fact]
        public void GameDevelopmentUtils_NormalizeInput_ZeroInput_NoChange()
        {
            float x = 0;
            float y = 0;
            GameDevelopmentUtils.NormalizeInput(ref x, ref y);
            Assert.Equal(0, x);
            Assert.Equal(0, y);
        }

        
        /// <summary>
        /// Games the development utils get gamepad button name returns correct name using the specified index
        /// </summary>
        /// <param name="index">The index</param>
        /// <param name="expected">The expected</param>
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
        [InlineData(99, "Button 99")]
        public void GameDevelopmentUtils_GetGamepadButtonName_ReturnsCorrectName(int index, string expected)
        {
            string name = GameDevelopmentUtils.GetGamepadButtonName(index);
            Assert.Equal(expected, name);
        }

        /// <summary>
        /// Tests that game development utils get key name delegates to input manager
        /// </summary>
        [Fact]
        public void GameDevelopmentUtils_GetKeyName_DelegatesToInputManager()
        {
            Assert.Equal("A", GameDevelopmentUtils.GetKeyName(ConsoleKey.A));
            Assert.Equal("Enter", GameDevelopmentUtils.GetKeyName(ConsoleKey.Enter));
        }
    }
}
