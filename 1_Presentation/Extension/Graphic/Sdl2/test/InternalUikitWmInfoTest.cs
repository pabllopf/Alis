// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:InternalUikitWmInfoTest.cs
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
    /// The internal uikit wm info test class
    /// </summary>
    public class InternalUikitWmInfoTest
    {
        /// <summary>
        /// Tests that internal uikit wm info default initialization fields have default values
        /// </summary>
        [Fact]
        public void InternalUikitWmInfo_DefaultInitialization_FieldsHaveDefaultValues()
        {
            InternalUikitWmInfo info = new InternalUikitWmInfo();

            Assert.Equal(IntPtr.Zero, info.Window);
            Assert.Equal(0u, info.framebuffer);
            Assert.Equal(0u, info.colorBuffer);
            Assert.Equal(0u, info.resolveFramebuffer);
        }

        /// <summary>
        /// Tests that internal uikit wm info set fields stores values correctly
        /// </summary>
        [Fact]
        public void InternalUikitWmInfo_SetFields_StoresValuesCorrectly()
        {
            InternalUikitWmInfo info = new InternalUikitWmInfo
            {
                Window = new IntPtr(999),
                framebuffer = 1u,
                colorBuffer = 2u,
                resolveFramebuffer = 3u
            };

            Assert.Equal(new IntPtr(999), info.Window);
            Assert.Equal(1u, info.framebuffer);
            Assert.Equal(2u, info.colorBuffer);
            Assert.Equal(3u, info.resolveFramebuffer);
        }

        /// <summary>
        /// Tests that internal uikit wm info is value type copy is independent
        /// </summary>
        [Fact]
        public void InternalUikitWmInfo_IsValueType_CopyIsIndependent()
        {
            InternalUikitWmInfo original = new InternalUikitWmInfo { framebuffer = 10u };
            InternalUikitWmInfo copy = original;

            copy.framebuffer = 20u;

            Assert.Equal(10u, original.framebuffer);
            Assert.Equal(20u, copy.framebuffer);
        }
    }
}
