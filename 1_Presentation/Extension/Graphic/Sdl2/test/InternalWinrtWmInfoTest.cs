// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:InternalWinrtWmInfoTest.cs
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
    /// The internal winrt wm info test class
    /// </summary>
    public class InternalWinrtWmInfoTest
    {
        /// <summary>
        /// Tests that internal winrt wm info default initialization property has default value
        /// </summary>
        [Fact]
        public void InternalWinrtWmInfo_DefaultInitialization_PropertyHasDefaultValue()
        {
            InternalWinrtWmInfo info = new InternalWinrtWmInfo();

            Assert.Equal(IntPtr.Zero, info.Window);
        }

        /// <summary>
        /// Tests that internal winrt wm info set property stores value correctly
        /// </summary>
        [Fact]
        public void InternalWinrtWmInfo_SetProperty_StoresValueCorrectly()
        {
            InternalWinrtWmInfo info = new InternalWinrtWmInfo
            {
                Window = new IntPtr(777)
            };

            Assert.Equal(new IntPtr(777), info.Window);
        }

        /// <summary>
        /// Tests that internal winrt wm info is value type copy is independent
        /// </summary>
        [Fact]
        public void InternalWinrtWmInfo_IsValueType_CopyIsIndependent()
        {
            InternalWinrtWmInfo original = new InternalWinrtWmInfo { Window = new IntPtr(111) };
            InternalWinrtWmInfo copy = original;

            copy.Window = new IntPtr(222);

            Assert.Equal(new IntPtr(111), original.Window);
            Assert.Equal(new IntPtr(222), copy.Window);
        }
    }
}
