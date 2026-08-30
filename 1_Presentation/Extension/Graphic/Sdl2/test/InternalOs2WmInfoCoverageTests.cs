// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:InternalOs2WmInfoCoverageTests.cs
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
    ///     The internal os2 wm info coverage tests class
    /// </summary>
    public class InternalOs2WmInfoCoverageTests
    {
        /// <summary>
        ///     Tests that default initialization properties have default values
        /// </summary>
        [Fact]
        public void InternalOs2WmInfo_DefaultInitialization_PropertiesHaveDefaultValues()
        {
            InternalOs2WmInfo info = default(InternalOs2WmInfo);

            Assert.Equal(IntPtr.Zero, info.Hwnd);
            Assert.Equal(IntPtr.Zero, info.HwndFrame);
        }

        /// <summary>
        ///     Tests that set properties stores values correctly
        /// </summary>
        [Fact]
        public void InternalOs2WmInfo_SetProperties_StoresValuesCorrectly()
        {
            InternalOs2WmInfo info = new InternalOs2WmInfo
            {
                Hwnd = new IntPtr(1),
                HwndFrame = new IntPtr(2)
            };

            Assert.Equal(new IntPtr(1), info.Hwnd);
            Assert.Equal(new IntPtr(2), info.HwndFrame);
        }

        /// <summary>
        ///     Tests that the struct is a value type and copies are independent
        /// </summary>
        [Fact]
        public void InternalOs2WmInfo_IsValueType_CopyIsIndependent()
        {
            InternalOs2WmInfo original = new InternalOs2WmInfo { Hwnd = new IntPtr(100) };
            InternalOs2WmInfo copy = original;

            copy.Hwnd = new IntPtr(200);

            Assert.Equal(new IntPtr(100), original.Hwnd);
            Assert.Equal(new IntPtr(200), copy.Hwnd);
        }
    }
}