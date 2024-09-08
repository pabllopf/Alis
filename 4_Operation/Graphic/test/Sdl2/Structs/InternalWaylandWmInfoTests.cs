// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:InternalWaylandWmInfoTests.cs
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
using Alis.Core.Graphic.Sdl2.Structs;
using Xunit;

namespace Alis.Core.Graphic.Test.Sdl2.Structs
{
    /// <summary>
    ///     The internal wayland wm info tests class
    /// </summary>
    public class InternalWaylandWmInfoTests
    {
        /// <summary>
        ///     Tests that internal wayland wm info initializes properties correctly
        /// </summary>
        [Fact]
        public void InternalWaylandWmInfo_InitializesPropertiesCorrectly()
        {
            IntPtr displayPtr = new IntPtr(1);
            IntPtr surfacePtr = new IntPtr(2);
            IntPtr shellSurfacePtr = new IntPtr(3);
            IntPtr eglWindowPtr = new IntPtr(4);
            IntPtr xdgSurfacePtr = new IntPtr(5);
            IntPtr xdgToplevelPtr = new IntPtr(6);

            InternalWaylandWmInfo info = new InternalWaylandWmInfo
            {
                Display = displayPtr,
                Surface = surfacePtr,
                ShellSurface = shellSurfacePtr,
                EglWindow = eglWindowPtr,
                XdgSurface = xdgSurfacePtr,
                XdgToplevel = xdgToplevelPtr
            };

            Assert.Equal(displayPtr, info.Display);
            Assert.Equal(surfacePtr, info.Surface);
            Assert.Equal(shellSurfacePtr, info.ShellSurface);
            Assert.Equal(eglWindowPtr, info.EglWindow);
            Assert.Equal(xdgSurfacePtr, info.XdgSurface);
            Assert.Equal(xdgToplevelPtr, info.XdgToplevel);
        }
    }
}