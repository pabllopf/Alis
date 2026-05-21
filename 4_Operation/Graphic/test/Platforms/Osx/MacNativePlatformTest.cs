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
        ///     Verifies that default state getters are safe before initialization.
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

            platform.GetMousePositionInView(out float x, out float y);
            Assert.Equal(0.0f, x, 5);
            Assert.Equal(0.0f, y, 5);
        }
    }
}
#endif
