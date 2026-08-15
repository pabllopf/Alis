// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:WebAssemblyGameExamplesEntryCoverageTests.cs
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
    ///     Exercises the WebAssemblyGameExamples entry points on desktop hosts where the
    ///     platform cannot be initialized, and the managed GameDevelopmentUtils helpers.
    /// </summary>
    public class WebAssemblyGameExamplesEntryCoverageTests
    {
        /// <summary>
        ///     Verifies the basic game loop example fails on desktop where the EGL platform
        ///     cannot be initialized.
        /// </summary>
        [Fact]
        public void BasicGameLoopExample_OnDesktop_ThrowsInvalidOperationException()
        {
            Assert.Throws<InvalidOperationException>(() => WebAssemblyGameExamples.BasicGameLoopExample());
        }

        /// <summary>
        ///     Verifies the gamepad input example fails on desktop where the EGL platform
        ///     cannot be initialized.
        /// </summary>
        [Fact]
        public void GamepadInputExample_OnDesktop_ThrowsInvalidOperationException()
        {
            Assert.Throws<InvalidOperationException>(() => WebAssemblyGameExamples.GamepadInputExample());
        }

        /// <summary>
        ///     Verifies the display management example fails on desktop where the EGL platform
        ///     cannot be initialized.
        /// </summary>
        [Fact]
        public void DisplayManagementExample_OnDesktop_ThrowsInvalidOperationException()
        {
            Assert.Throws<InvalidOperationException>(() => WebAssemblyGameExamples.DisplayManagementExample());
        }

        /// <summary>
        ///     Verifies the fps game example fails on desktop where the EGL platform cannot
        ///     be initialized.
        /// </summary>
        [Fact]
        public void FpsGameExample_OnDesktop_ThrowsInvalidOperationException()
        {
            Assert.Throws<InvalidOperationException>(() => WebAssemblyGameExamples.FpsGameExample());
        }

        /// <summary>
        ///     Verifies the system info example fails on desktop where the EGL platform cannot
        ///     be initialized.
        /// </summary>
        [Fact]
        public void SystemInfoExample_OnDesktop_ThrowsInvalidOperationException()
        {
            Assert.Throws<InvalidOperationException>(() => WebAssemblyGameExamples.SystemInfoExample());
        }

        /// <summary>
        ///     Verifies the configuration presets example fails on desktop where the EGL
        ///     platform cannot be initialized.
        /// </summary>
        [Fact]
        public void ConfigurationPresetsExample_OnDesktop_ThrowsInvalidOperationException()
        {
            Assert.Throws<InvalidOperationException>(() => WebAssemblyGameExamples.ConfigurationPresetsExample());
        }

        /// <summary>
        ///     Verifies the text input example fails on desktop where the EGL platform cannot
        ///     be initialized.
        /// </summary>
        [Fact]
        public void TextInputExample_OnDesktop_ThrowsInvalidOperationException()
        {
            Assert.Throws<InvalidOperationException>(() => WebAssemblyGameExamples.TextInputExample());
        }

        /// <summary>
        ///     Verifies the performance monitoring example fails on desktop where the EGL
        ///     platform cannot be initialized.
        /// </summary>
        [Fact]
        public void PerformanceMonitoringExample_OnDesktop_ThrowsInvalidOperationException()
        {
            Assert.Throws<InvalidOperationException>(() => WebAssemblyGameExamples.PerformanceMonitoringExample());
        }

        /// <summary>
        ///     Verifies the dialog box example fails on desktop where the EGL platform cannot
        ///     be initialized.
        /// </summary>
        [Fact]
        public void DialogBoxExample_OnDesktop_ThrowsInvalidOperationException()
        {
            Assert.Throws<InvalidOperationException>(() => WebAssemblyGameExamples.DialogBoxExample());
        }

        /// <summary>
        ///     Verifies the complete game template fails on desktop where the EGL platform
        ///     cannot be initialized.
        /// </summary>
        [Fact]
        public void CompleteGameTemplate_OnDesktop_ThrowsInvalidOperationException()
        {
            Assert.Throws<InvalidOperationException>(() => WebAssemblyGameExamples.CompleteGameTemplate());
        }

        /// <summary>
        ///     Verifies that letter keys resolve to their display names.
        /// </summary>
        [Fact]
        public void GetKeyName_WithLetters_ReturnsNames()
        {
            Assert.Equal("A", GameDevelopmentUtils.GetKeyName(ConsoleKey.A));
            Assert.Equal("W", GameDevelopmentUtils.GetKeyName(ConsoleKey.W));
            Assert.Equal("Z", GameDevelopmentUtils.GetKeyName(ConsoleKey.Z));
        }

        /// <summary>
        ///     Verifies that digit and special keys resolve to their display names.
        /// </summary>
        [Fact]
        public void GetKeyName_WithDigitsAndSpecials_ReturnsNames()
        {
            Assert.Equal("0", GameDevelopmentUtils.GetKeyName(ConsoleKey.D0));
            Assert.Equal("9", GameDevelopmentUtils.GetKeyName(ConsoleKey.D9));
            Assert.Equal("Enter", GameDevelopmentUtils.GetKeyName(ConsoleKey.Enter));
            Assert.Equal("Space", GameDevelopmentUtils.GetKeyName(ConsoleKey.Spacebar));
            Assert.Equal("Up", GameDevelopmentUtils.GetKeyName(ConsoleKey.UpArrow));
            Assert.Equal("F12", GameDevelopmentUtils.GetKeyName(ConsoleKey.F12));
            Assert.Equal("Numpad 5", GameDevelopmentUtils.GetKeyName(ConsoleKey.NumPad5));
            Assert.Equal("Page Up", GameDevelopmentUtils.GetKeyName(ConsoleKey.PageUp));
        }

        /// <summary>
        ///     Verifies that unknown keys resolve to the fallback name.
        /// </summary>
        [Fact]
        public void GetKeyName_WithUnknownKey_ReturnsUnknown()
        {
            Assert.Equal("Unknown", GameDevelopmentUtils.GetKeyName(ConsoleKey.F24));
        }

        /// <summary>
        ///     Verifies that every gamepad button index resolves to its display name.
        /// </summary>
        [Fact]
        public void GetGamepadButtonName_WithEveryIndex_ReturnsNames()
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
            Assert.Equal("Button 13", GameDevelopmentUtils.GetGamepadButtonName(13));
        }
    }
}
