// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:InternalWaylandWmInfoTest.cs
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
using Alis.Extension.Graphic.Sdl2.Structs;
using Xunit;

namespace Alis.Extension.Graphic.Sdl2.Test
{
    /// <summary>
    /// The internal wayland wm info test class
    /// </summary>
    public class InternalWaylandWmInfoTest
    {
        /// <summary>
        /// Tests that internal wayland wm info default initialization properties have default values
        /// </summary>
        [Fact]
        public void InternalWaylandWmInfo_DefaultInitialization_PropertiesHaveDefaultValues()
        {
            InternalWaylandWmInfo info = new InternalWaylandWmInfo();

            Assert.Equal(IntPtr.Zero, info.Display);
            Assert.Equal(IntPtr.Zero, info.Surface);
            Assert.Equal(IntPtr.Zero, info.ShellSurface);
            Assert.Equal(IntPtr.Zero, info.EglWindow);
            Assert.Equal(IntPtr.Zero, info.XdgSurface);
            Assert.Equal(IntPtr.Zero, info.XdgToplevel);
        }

        /// <summary>
        /// Tests that internal wayland wm info set properties stores values correctly
        /// </summary>
        [Fact]
        public void InternalWaylandWmInfo_SetProperties_StoresValuesCorrectly()
        {
            InternalWaylandWmInfo info = new InternalWaylandWmInfo
            {
                Display = new IntPtr(1),
                Surface = new IntPtr(2),
                ShellSurface = new IntPtr(3),
                EglWindow = new IntPtr(4),
                XdgSurface = new IntPtr(5),
                XdgToplevel = new IntPtr(6)
            };

            Assert.Equal(new IntPtr(1), info.Display);
            Assert.Equal(new IntPtr(2), info.Surface);
            Assert.Equal(new IntPtr(3), info.ShellSurface);
            Assert.Equal(new IntPtr(4), info.EglWindow);
            Assert.Equal(new IntPtr(5), info.XdgSurface);
            Assert.Equal(new IntPtr(6), info.XdgToplevel);
        }

        /// <summary>
        /// Tests that internal wayland wm info is value type copy is independent
        /// </summary>
        [Fact]
        public void InternalWaylandWmInfo_IsValueType_CopyIsIndependent()
        {
            InternalWaylandWmInfo original = new InternalWaylandWmInfo { Display = new IntPtr(100) };
            InternalWaylandWmInfo copy = original;

            copy.Display = new IntPtr(200);

            Assert.Equal(new IntPtr(100), original.Display);
            Assert.Equal(new IntPtr(200), copy.Display);
        }
    }
}
