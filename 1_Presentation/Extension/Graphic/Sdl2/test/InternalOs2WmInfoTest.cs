// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:InternalOs2WmInfoTest.cs
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
    /// The internal os wm info test class
    /// </summary>
    public class InternalOs2WmInfoTest
    {
        /// <summary>
        /// Tests that internal os 2 wm info default initialization properties have default values
        /// </summary>
        [Fact]
        public void InternalOs2WmInfo_DefaultInitialization_PropertiesHaveDefaultValues()
        {
            InternalOs2WmInfo info = new InternalOs2WmInfo();

            Assert.Equal(IntPtr.Zero, info.Hwnd);
            Assert.Equal(IntPtr.Zero, info.HwndFrame);
        }

        /// <summary>
        /// Tests that internal os 2 wm info set properties stores values correctly
        /// </summary>
        [Fact]
        public void InternalOs2WmInfo_SetProperties_StoresValuesCorrectly()
        {
            InternalOs2WmInfo info = new InternalOs2WmInfo
            {
                Hwnd = new IntPtr(111),
                HwndFrame = new IntPtr(222)
            };

            Assert.Equal(new IntPtr(111), info.Hwnd);
            Assert.Equal(new IntPtr(222), info.HwndFrame);
        }

        /// <summary>
        /// Tests that internal os 2 wm info is value type copy is independent
        /// </summary>
        [Fact]
        public void InternalOs2WmInfo_IsValueType_CopyIsIndependent()
        {
            InternalOs2WmInfo original = new InternalOs2WmInfo { Hwnd = new IntPtr(77) };
            InternalOs2WmInfo copy = original;

            copy.Hwnd = new IntPtr(88);

            Assert.Equal(new IntPtr(77), original.Hwnd);
            Assert.Equal(new IntPtr(88), copy.Hwnd);
        }
    }
}
