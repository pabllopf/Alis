// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:InternalWindowsWmInfoTest.cs
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
    /// The internal windows wm info test class
    /// </summary>
    public class InternalWindowsWmInfoTest
    {
        /// <summary>
        /// Tests that internal windows wm info default initialization properties have default values
        /// </summary>
        [Fact]
        public void InternalWindowsWmInfo_DefaultInitialization_PropertiesHaveDefaultValues()
        {
            InternalWindowsWmInfo info = new InternalWindowsWmInfo();

            Assert.Equal(IntPtr.Zero, info.Window);
            Assert.Equal(IntPtr.Zero, info.Hdc);
            Assert.Equal(IntPtr.Zero, info.HInstance);
        }

        /// <summary>
        /// Tests that internal windows wm info set properties stores values correctly
        /// </summary>
        [Fact]
        public void InternalWindowsWmInfo_SetProperties_StoresValuesCorrectly()
        {
            InternalWindowsWmInfo info = new InternalWindowsWmInfo
            {
                Window = new IntPtr(10),
                Hdc = new IntPtr(20),
                HInstance = new IntPtr(30)
            };

            Assert.Equal(new IntPtr(10), info.Window);
            Assert.Equal(new IntPtr(20), info.Hdc);
            Assert.Equal(new IntPtr(30), info.HInstance);
        }

        /// <summary>
        /// Tests that internal windows wm info is value type copy is independent
        /// </summary>
        [Fact]
        public void InternalWindowsWmInfo_IsValueType_CopyIsIndependent()
        {
            InternalWindowsWmInfo original = new InternalWindowsWmInfo { Window = new IntPtr(55) };
            InternalWindowsWmInfo copy = original;

            copy.Window = new IntPtr(66);

            Assert.Equal(new IntPtr(55), original.Window);
            Assert.Equal(new IntPtr(66), copy.Window);
        }
    }
}
