// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:InternalDirectfbWmInfoCoverageTests.cs
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
    ///     The internal directfb wm info coverage tests class
    /// </summary>
    public class InternalDirectfbWmInfoCoverageTests
    {
        /// <summary>
        ///     Tests that default initialization properties have default values
        /// </summary>
        [Fact]
        public void InternalDirectfbWmInfo_DefaultInitialization_PropertiesHaveDefaultValues()
        {
            InternalDirectfbWmInfo info = default(InternalDirectfbWmInfo);

            Assert.Equal(IntPtr.Zero, info.Dfb);
            Assert.Equal(IntPtr.Zero, info.Window);
            Assert.Equal(IntPtr.Zero, info.Surface);
        }

        /// <summary>
        ///     Tests that set properties stores values correctly
        /// </summary>
        [Fact]
        public void InternalDirectfbWmInfo_SetProperties_StoresValuesCorrectly()
        {
            InternalDirectfbWmInfo info = new InternalDirectfbWmInfo
            {
                Dfb = new IntPtr(1),
                Window = new IntPtr(2),
                Surface = new IntPtr(3)
            };

            Assert.Equal(new IntPtr(1), info.Dfb);
            Assert.Equal(new IntPtr(2), info.Window);
            Assert.Equal(new IntPtr(3), info.Surface);
        }

        /// <summary>
        ///     Tests that the struct is a value type and copies are independent
        /// </summary>
        [Fact]
        public void InternalDirectfbWmInfo_IsValueType_CopyIsIndependent()
        {
            InternalDirectfbWmInfo original = new InternalDirectfbWmInfo { Dfb = new IntPtr(10) };
            InternalDirectfbWmInfo copy = original;

            copy.Dfb = new IntPtr(20);

            Assert.Equal(new IntPtr(10), original.Dfb);
            Assert.Equal(new IntPtr(20), copy.Dfb);
        }
    }
}