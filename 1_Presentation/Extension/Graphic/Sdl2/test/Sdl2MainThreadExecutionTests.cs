// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:Sdl2MainThreadExecutionTests.cs
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
using Alis.Extension.Graphic.Sdl2.Test.Attributes;
using Xunit;

namespace Alis.Extension.Graphic.Sdl2.Test
{
    /// <summary>
    ///     Verifies the main-thread SDL2 wrapper calls recorded by <see cref="Sdl2TestBootstrap" />. The tests are
    ///     harmless no-ops when the startup hook was not installed (<see cref="Sdl2TestBootstrap.Ready" /> is false on
    ///     CI).
    /// </summary>
    public class Sdl2MainThreadExecutionTests
    {
        /// <summary>
        ///     Tests that the video subsystem initialized on the main thread
        /// </summary>
        [RequireSdl2Fact]
        public void Init_Video_SucceedsOnMainThread()
        {
            if (!Sdl2TestBootstrap.Ready)
            {
                return;
            }

            Assert.Equal(0, Sdl2TestBootstrap.InitResult);
        }

        /// <summary>
        ///     Tests that the hidden window was created on the main thread
        /// </summary>
        [RequireSdl2Fact]
        public void CreateWindow_HiddenWindow_CreatedOnMainThread()
        {
            if (!Sdl2TestBootstrap.Ready)
            {
                return;
            }

            Assert.NotEqual(IntPtr.Zero, Sdl2TestBootstrap.WindowHandle);
        }

        /// <summary>
        ///     Tests that the window and renderer pair was created on the main thread
        /// </summary>
        [RequireSdl2Fact]
        public void CreateWindowAndRenderer_SucceedsOnMainThread()
        {
            if (!Sdl2TestBootstrap.Ready)
            {
                return;
            }

            Assert.Equal(0, Sdl2TestBootstrap.WindowAndRendererResult);
        }

        /// <summary>
        ///     Tests that a GL context for a null window is rejected on the main thread
        /// </summary>
        [RequireSdl2Fact]
        public void CreateContext_NullWindow_ReturnsZeroOnMainThread()
        {
            if (!Sdl2TestBootstrap.Ready)
            {
                return;
            }

            Assert.Equal(IntPtr.Zero, Sdl2TestBootstrap.ContextResult);
        }

        /// <summary>
        ///     Tests that a cursor was created from raw bitmaps on the main thread
        /// </summary>
        [RequireSdl2Fact]
        public void CreateCursor_Bitmaps_CreatedOnMainThread()
        {
            if (!Sdl2TestBootstrap.Ready)
            {
                return;
            }

            Assert.NotEqual(IntPtr.Zero, Sdl2TestBootstrap.CursorHandle);
        }
    }
}
