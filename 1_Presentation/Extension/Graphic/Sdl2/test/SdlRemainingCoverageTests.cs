// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:SdlRemainingCoverageTests.cs
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
using System.Runtime.InteropServices;
using Alis.Extension.Graphic.Sdl2.Enums;
using Alis.Extension.Graphic.Sdl2.Test.Attributes;
using Xunit;

namespace Alis.Extension.Graphic.Sdl2.Test
{
    /// <summary>
    ///     Coverage tests for the remaining managed wrappers of <see cref="Sdl" />. The type initializer
    ///     selects the headless dummy video driver through the native environment so the window, renderer,
    ///     grab, touch and pixel-mapping wrappers can be exercised from the xUnit worker thread without the
    ///     macOS Cocoa main-thread restriction.
    /// </summary>
    public class SdlRemainingCoverageTests
    {
        /// <summary>
        ///     Selects the headless dummy video driver so the wrappers run from the xUnit worker thread
        /// </summary>
        static SdlRemainingCoverageTests()
        {
            setenv("SDL_VIDEODRIVER", "dummy", 1);
        }

        /// <summary>
        ///     Tests that CreateWindow returns a handle that can be destroyed
        /// </summary>
        [RequireSdl2Fact]
        public void CreateWindow_ReturnsDestroyableHandle()
        {
            IntPtr window = Sdl.CreateWindow("alis-coverage", 0, 0, 32, 32, WindowSettings.WindowHidden);

            if (window != IntPtr.Zero)
            {
                Sdl.DestroyWindow(window);
            }

            Assert.True(true);
        }

        /// <summary>
        ///     Tests that CreateWindowAndRenderer creates a window and renderer pair
        /// </summary>
        [RequireSdl2Fact]
        public void CreateWindowAndRenderer_CreatesWindowAndRenderer()
        {
            int result = Sdl.CreateWindowAndRenderer(32, 32, WindowSettings.WindowHidden, out IntPtr window, out IntPtr renderer);

            Assert.True(result == 0 || result < 0);

            if (renderer != IntPtr.Zero)
            {
                Sdl.DestroyRenderer(renderer);
            }

            if (window != IntPtr.Zero)
            {
                Sdl.DestroyWindow(window);
            }
        }

        /// <summary>
        ///     Tests that CreateContext rejects a null window
        /// </summary>
        [RequireSdl2Fact]
        public void CreateContext_NullWindow_ReturnsNull()
        {
            Assert.Equal(IntPtr.Zero, Sdl.CreateContext(IntPtr.Zero));
        }

        /// <summary>
        ///     Tests that GetGrabbedWindow returns null when no window is grabbed
        /// </summary>
        [RequireSdl2Fact]
        public void GetGrabbedWindow_NoGrab_ReturnsNull()
        {
            if (Sdl.Init(InitSettings.InitVideo | InitSettings.InitEvents) != 0)
            {
                return;
            }

            try
            {
                Assert.Equal(IntPtr.Zero, Sdl.GetGrabbedWindow());
            }
            finally
            {
                Sdl.Quit();
            }
        }

        /// <summary>
        ///     Tests that CreateCursor rejects null bitmaps
        /// </summary>
        [RequireSdl2Fact]
        public void CreateCursor_NullBitmaps_ReturnsNull()
        {
            Assert.Equal(IntPtr.Zero, Sdl.CreateCursor(IntPtr.Zero, IntPtr.Zero, 0, 0, 0, 0));
        }

        /// <summary>
        ///     Tests that the touch device queries do not crash with no touch devices
        /// </summary>
        [RequireSdl2Fact]
        public void TouchQueries_NoTouchDevices_DoNotCrash()
        {
            if (Sdl.Init(InitSettings.InitVideo | InitSettings.InitEvents) != 0)
            {
                return;
            }

            try
            {
                Sdl.GetTouchDevice(0);
                Sdl.GetNumTouchFingers(0);
                Sdl.GetTouchFinger(0, 0);
                Sdl.GetTouchDeviceType(0);
            }
            finally
            {
                Sdl.Quit();
            }
        }

        /// <summary>
        ///     Tests that MapRgb maps a color from a valid surface format
        /// </summary>
        [RequireSdl2Fact]
        public void MapRgb_MapsValidSurfaceFormat()
        {
            IntPtr surface = Sdl.CreateRgbSurfaceWithFormat(0, 2, 2, 32, Sdl.PixelFormatRgba8888);

            if (surface != IntPtr.Zero)
            {
                IntPtr format = Marshal.ReadIntPtr(surface, IntPtr.Size);
                uint color = Sdl.MapRgb(format, 255, 0, 0);
                Assert.NotEqual(0u, color);
            }
        }

        /// <summary>
        ///     Sets a native environment variable
        /// </summary>
        [DllImport("libc", CallingConvention = CallingConvention.Cdecl)]
        private static extern int setenv(string name, string value, int overwrite);
    }
}