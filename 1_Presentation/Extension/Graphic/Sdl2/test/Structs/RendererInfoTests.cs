// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:RendererInfoTests.cs
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
using System.Runtime.InteropServices;
using Alis.Extension.Graphic.Sdl2.Structs;
using Xunit;

namespace Alis.Extension.Graphic.Sdl2.Test.Structs
{
    /// <summary>
    ///     The renderer info tests class
    /// </summary>
    public class RendererInfoTests
    {
        /// <summary>
        ///     Tests that renderer info initializes properties correctly
        /// </summary>
        [Fact]
        public void RendererInfo_InitializesPropertiesCorrectly()
        {
            IntPtr namePtr = Marshal.StringToHGlobalAnsi("TestRenderer");
            RendererInfo rendererInfo = new RendererInfo
            {
                Name = namePtr,
                flags = 1,
                num_texture_formats = 2,
                textureFormats0 = 3,
                textureFormats1 = 4,
                textureFormats2 = 5,
                textureFormats3 = 6,
                textureFormats4 = 7,
                textureFormats5 = 8,
                textureFormats6 = 9,
                textureFormats7 = 10,
                textureFormats8 = 11,
                textureFormats9 = 12,
                textureFormats10 = 13,
                textureFormats11 = 14,
                textureFormats12 = 15,
                textureFormats13 = 16,
                textureFormats14 = 17,
                textureFormats15 = 18,
                maxTextureWidth = 1920,
                maxTextureHeight = 1080
            };

            Assert.Equal((string)"TestRenderer", (string)rendererInfo.GetName());
            Assert.Equal(1u, rendererInfo.flags);
            Assert.Equal(2u, rendererInfo.num_texture_formats);
            Assert.Equal(3, rendererInfo.textureFormats0);
            Assert.Equal(4, rendererInfo.textureFormats1);
            Assert.Equal(5, rendererInfo.textureFormats2);
            Assert.Equal(6, rendererInfo.textureFormats3);
            Assert.Equal(7, rendererInfo.textureFormats4);
            Assert.Equal(8, rendererInfo.textureFormats5);
            Assert.Equal(9, rendererInfo.textureFormats6);
            Assert.Equal(10, rendererInfo.textureFormats7);
            Assert.Equal(11, rendererInfo.textureFormats8);
            Assert.Equal(12, rendererInfo.textureFormats9);
            Assert.Equal(13, rendererInfo.textureFormats10);
            Assert.Equal(14, rendererInfo.textureFormats11);
            Assert.Equal(15, rendererInfo.textureFormats12);
            Assert.Equal(16, rendererInfo.textureFormats13);
            Assert.Equal(17, rendererInfo.textureFormats14);
            Assert.Equal(18, rendererInfo.textureFormats15);
            Assert.Equal(1920, rendererInfo.maxTextureWidth);
            Assert.Equal(1080, rendererInfo.maxTextureHeight);

            Marshal.FreeHGlobal(namePtr);
        }
    }
}