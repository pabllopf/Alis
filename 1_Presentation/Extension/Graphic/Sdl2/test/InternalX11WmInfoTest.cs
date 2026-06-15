// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:InternalX11WmInfoTest.cs
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
    /// The internal 11 wm info test class
    /// </summary>
    public class InternalX11WmInfoTest
    {
        /// <summary>
        /// Tests that internal x 11 wm info default initialization properties have default values
        /// </summary>
        [Fact]
        public void InternalX11WmInfo_DefaultInitialization_PropertiesHaveDefaultValues()
        {
            InternalX11WmInfo info = new InternalX11WmInfo();

            Assert.Equal(IntPtr.Zero, info.Display);
            Assert.Equal(IntPtr.Zero, info.Window);
        }

        /// <summary>
        /// Tests that internal x 11 wm info set properties stores values correctly
        /// </summary>
        [Fact]
        public void InternalX11WmInfo_SetProperties_StoresValuesCorrectly()
        {
            InternalX11WmInfo info = new InternalX11WmInfo
            {
                Display = new IntPtr(1000),
                Window = new IntPtr(2000)
            };

            Assert.Equal(new IntPtr(1000), info.Display);
            Assert.Equal(new IntPtr(2000), info.Window);
        }

        /// <summary>
        /// Tests that internal x 11 wm info is value type copy is independent
        /// </summary>
        [Fact]
        public void InternalX11WmInfo_IsValueType_CopyIsIndependent()
        {
            InternalX11WmInfo original = new InternalX11WmInfo { Display = new IntPtr(3000) };
            InternalX11WmInfo copy = original;

            copy.Display = new IntPtr(4000);

            Assert.Equal(new IntPtr(3000), original.Display);
            Assert.Equal(new IntPtr(4000), copy.Display);
        }
    }
}
