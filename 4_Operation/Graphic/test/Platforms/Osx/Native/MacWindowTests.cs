// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:MacWindowTests.cs
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
using System.Runtime.InteropServices;
using Alis.Core.Graphic.Platforms.Osx.Native;
using Xunit;

namespace Alis.Core.Graphic.Test.Platforms.Osx.Native
{
    public class MacWindowTests
    {
        [DllImport("/usr/lib/libSystem.B.dylib")]
        private static extern int pthread_main_np();

        private static bool IsMainThread() => pthread_main_np() != 0;

        private static MacWindow CreateWindow(int width, int height, string title)
        {
            if (!IsMainThread())
            {
                return null;
            }
            ObjectiveCInterop.NSApplicationLoad();
            return new MacWindow(width, height, title);
        }

        [Fact]
        public void Constructor_WithValidValues_SetsWidth()
        {
            MacWindow window = CreateWindow(800, 600, "Test");
            if (window == null) return;
            Assert.Equal(800, window.Width);
        }

        [Fact]
        public void Constructor_WithValidValues_SetsHeight()
        {
            MacWindow window = CreateWindow(800, 600, "Test");
            if (window == null) return;
            Assert.Equal(600, window.Height);
        }

        [Fact]
        public void Constructor_WithValidValues_SetsTitle()
        {
            MacWindow window = CreateWindow(800, 600, "Test Title");
            if (window == null) return;
            Assert.Equal("Test Title", window.Title);
        }

        [Fact]
        public void Constructor_CreatesNonZeroHandle()
        {
            MacWindow window = CreateWindow(800, 600, "Handle Test");
            if (window == null) return;
            Assert.NotEqual(IntPtr.Zero, window.Handle);
        }

        [Fact]
        public void IsVisible_ReturnsFalse_WhenNotShown()
        {
            MacWindow window = CreateWindow(800, 600, "Visible Test");
            if (window == null) return;
            bool visible = window.IsVisible();
            Assert.False(visible);
        }

        [Fact]
        public void Show_DoesNotThrow()
        {
            MacWindow window = CreateWindow(800, 600, "Show Test");
            if (window == null) return;
            window.Show();
        }

        [Fact]
        public void Hide_DoesNotThrow()
        {
            MacWindow window = CreateWindow(800, 600, "Hide Test");
            if (window == null) return;
            window.Hide();
        }

        [Fact]
        public void GetFrame_ReturnsPositiveDimensions()
        {
            MacWindow window = CreateWindow(800, 600, "Frame Test");
            if (window == null) return;
            NsRect frame = window.GetFrame();
            Assert.True(frame.width > 0);
            Assert.True(frame.height > 0);
        }

        [Fact]
        public void SetTitle_UpdatesTitle()
        {
            MacWindow window = CreateWindow(800, 600, "Original");
            if (window == null) return;
            window.SetTitle("Updated");
            Assert.Equal("Updated", window.Title);
        }

        [Fact]
        public void SetSize_UpdatesWidthAndHeight()
        {
            MacWindow window = CreateWindow(800, 600, "Size Test");
            if (window == null) return;
            window.SetSize(1024, 768);
            Assert.Equal(1024, window.Width);
            Assert.Equal(768, window.Height);
        }
    }
}
#endif
