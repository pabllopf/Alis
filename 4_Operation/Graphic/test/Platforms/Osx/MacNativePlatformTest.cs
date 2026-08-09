// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:MacNativePlatformTest.cs
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

#if osxarm64 || osxarm || osxx64 || osx
using System;
using System.Collections.Generic;
using Alis.Core.Graphic.Platforms.Osx;
using Xunit;

namespace Alis.Core.Graphic.Test.Platforms.Osx
{
    /// <summary>
    ///     Tests for MacNativePlatform default behavior without native initialization.
    /// </summary>
    public class MacNativePlatformTest
    {
        /// <summary>
        ///     MacNativePlatform_DefaultState_IsSafe
        /// </summary>
        [Fact]
        public void MacNativePlatform_DefaultState_IsSafe()
        {
            MacNativePlatform platform = new MacNativePlatform();

            Assert.False(platform.IsWindowVisible());
            Assert.Equal(0, platform.GetWindowWidth());
            Assert.Equal(0, platform.GetWindowHeight());
            Assert.False(platform.TryGetLastKeyPressed(out ConsoleKey _));
            Assert.False(platform.IsKeyDown(ConsoleKey.A));
            Assert.Equal(0.0f, platform.GetMouseWheel(), 5);
            Assert.False(platform.TryGetLastInputCharacters(out string chars));
            Assert.Equal(string.Empty, chars);
        }

        /// <summary>
        ///     TryGetLastKeyPressed_NoKey_ReturnsFalse
        /// </summary>
        [Fact]
        public void TryGetLastKeyPressed_NoKey_ReturnsFalse()
        {
            MacNativePlatform platform = new MacNativePlatform();
            bool result = platform.TryGetLastKeyPressed(out ConsoleKey key);
            Assert.False(result);
            Assert.Equal(default(ConsoleKey), key);
        }

        /// <summary>
        ///     GetMouseWheel_Default_ReturnsZero
        /// </summary>
        [Fact]
        public void GetMouseWheel_Default_ReturnsZero()
        {
            MacNativePlatform platform = new MacNativePlatform();
            Assert.Equal(0.0f, platform.GetMouseWheel(), 5);
        }

        /// <summary>
        ///     GetMouseWheel_InternalFieldSet_ReturnsValueAndResets
        /// </summary>
        [Fact]
        public void GetMouseWheel_InternalFieldSet_ReturnsValueAndResets()
        {
            MacNativePlatform platform = new MacNativePlatform();
            platform.mouseWheel = 42.5f;

            float result = platform.GetMouseWheel();
            Assert.Equal(42.5f, result, 5);
            Assert.Equal(0.0f, platform.mouseWheel, 5);
        }

        /// <summary>
        ///     GetMouseWheel_NegativeValue_ReturnsValueAndResets
        /// </summary>
        [Fact]
        public void GetMouseWheel_NegativeValue_ReturnsValueAndResets()
        {
            MacNativePlatform platform = new MacNativePlatform();
            platform.mouseWheel = -15.0f;

            float result = platform.GetMouseWheel();
            Assert.Equal(-15.0f, result, 5);
            Assert.Equal(0.0f, platform.mouseWheel, 5);
        }

        /// <summary>
        ///     IsKeyDown_KeyNotPressed_ReturnsFalse
        /// </summary>
        [Fact]
        public void IsKeyDown_KeyNotPressed_ReturnsFalse()
        {
            MacNativePlatform platform = new MacNativePlatform();
            Assert.False(platform.IsKeyDown(ConsoleKey.A));
            Assert.False(platform.IsKeyDown(ConsoleKey.Spacebar));
            Assert.False(platform.IsKeyDown(ConsoleKey.Enter));
        }

        /// <summary>
        ///     TryGetLastInputCharacters_ReturnsFalseAndEmptyString
        /// </summary>
        [Fact]
        public void TryGetLastInputCharacters_ReturnsFalseAndEmptyString()
        {
            MacNativePlatform platform = new MacNativePlatform();
            bool result = platform.TryGetLastInputCharacters(out string chars);

            Assert.False(result);
            Assert.Equal(string.Empty, chars);
        }

        /// <summary>
        ///     IsWindowVisible_NotInitialized_ReturnsFalse
        /// </summary>
        [Fact]
        public void IsWindowVisible_NotInitialized_ReturnsFalse()
        {
            MacNativePlatform platform = new MacNativePlatform();
            Assert.False(platform.IsWindowVisible());
        }

        /// <summary>
        ///     GetWindowWidth_NotInitialized_ReturnsZero
        /// </summary>
        [Fact]
        public void GetWindowWidth_NotInitialized_ReturnsZero()
        {
            MacNativePlatform platform = new MacNativePlatform();
            Assert.Equal(0, platform.GetWindowWidth());
        }

        /// <summary>
        ///     GetWindowHeight_NotInitialized_ReturnsZero
        /// </summary>
        [Fact]
        public void GetWindowHeight_NotInitialized_ReturnsZero()
        {
            MacNativePlatform platform = new MacNativePlatform();
            Assert.Equal(0, platform.GetWindowHeight());
        }

        /// <summary>
        ///     GetMouseWheel_ConsecutiveCalls_SecondReturnsZero
        /// </summary>
        [Fact]
        public void GetMouseWheel_ConsecutiveCalls_SecondReturnsZero()
        {
            MacNativePlatform platform = new MacNativePlatform();
            platform.mouseWheel = 7.0f;

            Assert.Equal(7.0f, platform.GetMouseWheel(), 5);
            Assert.Equal(0.0f, platform.GetMouseWheel(), 5);
        }
    }
}
#endif
