// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:MacNativePlatformRemainingCoverageTests.cs
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
    ///     Tests for MacNativePlatform covering remaining public methods not tested by MacNativePlatformTest.
    /// </summary>
    public class MacNativePlatformRemainingCoverageTests
    {
        [Fact]
        public void ShowWindow_NotInitialized_DoesNotThrow()
        {
            MacNativePlatform platform = new MacNativePlatform();
            platform.ShowWindow();
        }

        [Fact]
        public void HideWindow_NotInitialized_DoesNotThrow()
        {
            MacNativePlatform platform = new MacNativePlatform();
            platform.HideWindow();
        }

        [Fact]
        public void SetTitle_NotInitialized_DoesNotThrow()
        {
            MacNativePlatform platform = new MacNativePlatform();
            platform.SetTitle("TestTitle");
        }

        [Fact]
        public void SetTitle_Null_NotInitialized_DoesNotThrow()
        {
            MacNativePlatform platform = new MacNativePlatform();
            platform.SetTitle(null);
        }

        [Fact]
        public void SetSize_NotInitialized_DoesNotThrow()
        {
            MacNativePlatform platform = new MacNativePlatform();
            platform.SetSize(800, 600);
        }

        [Fact]
        public void MakeContextCurrent_NotInitialized_DoesNotThrow()
        {
            MacNativePlatform platform = new MacNativePlatform();
            platform.MakeContextCurrent();
        }

        [Fact]
        public void SwapBuffers_NotInitialized_DoesNotThrow()
        {
            MacNativePlatform platform = new MacNativePlatform();
            platform.SwapBuffers();
        }

        [Fact]
        public void Cleanup_NotInitialized_DoesNotThrow()
        {
            MacNativePlatform platform = new MacNativePlatform();
            platform.Cleanup();
        }

        [Fact]
        public void PollEvents_NotInitialized_ReturnsFalse()
        {
            MacNativePlatform platform = new MacNativePlatform();
            bool result = platform.PollEvents();
            Assert.False(result);
        }

        [Fact]
        public void GetWindowPositionX_NotInitialized_ThrowsNullReferenceException()
        {
            MacNativePlatform platform = new MacNativePlatform();
            Assert.Throws<NullReferenceException>(() => platform.GetWindowPositionX());
        }

        [Fact]
        public void GetWindowPositionY_NotInitialized_ThrowsNullReferenceException()
        {
            MacNativePlatform platform = new MacNativePlatform();
            Assert.Throws<NullReferenceException>(() => platform.GetWindowPositionY());
        }

        [Fact]
        public void GetWindowMetrics_NotInitialized_ThrowsNullReferenceException()
        {
            MacNativePlatform platform = new MacNativePlatform();
            Assert.Throws<NullReferenceException>(() =>
                platform.GetWindowMetrics(out _, out _, out _, out _, out _, out _));
        }

        [Fact]
        public void GetMouseState_ReturnsValidState()
        {
            MacNativePlatform platform = new MacNativePlatform();
            platform.GetMouseState(out int x, out int y, out bool[] buttons);
            Assert.NotNull(buttons);
            Assert.Equal(5, buttons.Length);
        }
    }
}
#endif
