// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:InternalAndroidWmInfoTest.cs
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
    /// The internal android wm info test class
    /// </summary>
    public class InternalAndroidWmInfoTest
    {
        /// <summary>
        /// Tests that internal android wm info default initialization properties have default values
        /// </summary>
        [Fact]
        public void InternalAndroidWmInfo_DefaultInitialization_PropertiesHaveDefaultValues()
        {
            InternalAndroidWmInfo info = new InternalAndroidWmInfo();

            Assert.Equal(IntPtr.Zero, info.Window);
            Assert.Equal(IntPtr.Zero, info.Surface);
        }

        /// <summary>
        /// Tests that internal android wm info set properties stores values correctly
        /// </summary>
        [Fact]
        public void InternalAndroidWmInfo_SetProperties_StoresValuesCorrectly()
        {
            InternalAndroidWmInfo info = new InternalAndroidWmInfo
            {
                Window = new IntPtr(123),
                Surface = new IntPtr(456)
            };

            Assert.Equal(new IntPtr(123), info.Window);
            Assert.Equal(new IntPtr(456), info.Surface);
        }

        /// <summary>
        /// Tests that internal android wm info is value type copy is independent
        /// </summary>
        [Fact]
        public void InternalAndroidWmInfo_IsValueType_CopyIsIndependent()
        {
            InternalAndroidWmInfo original = new InternalAndroidWmInfo { Window = new IntPtr(100) };
            InternalAndroidWmInfo copy = original;

            copy.Window = new IntPtr(200);

            Assert.Equal(new IntPtr(100), original.Window);
            Assert.Equal(new IntPtr(200), copy.Window);
        }
    }
}
