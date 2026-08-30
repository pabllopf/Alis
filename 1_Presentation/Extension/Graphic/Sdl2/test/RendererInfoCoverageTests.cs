// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:RendererInfoCoverageTests.cs
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
    ///     The renderer info coverage tests class
    /// </summary>
    public class RendererInfoCoverageTests
    {
        /// <summary>
        ///     Tests that default initialization properties have default values
        /// </summary>
        [Fact]
        public void RendererInfo_DefaultInitialization_PropertiesHaveDefaultValues()
        {
            RendererInfo info = default(RendererInfo);

            Assert.Equal(IntPtr.Zero, info.Name);
            Assert.Equal(0U, info.flags);
            Assert.Equal(0U, info.num_texture_formats);
            Assert.Equal(0, info.maxTextureWidth);
            Assert.Equal(0, info.maxTextureHeight);
            Assert.Null(info.GetName());
        }

        /// <summary>
        ///     Tests that set properties stores values correctly
        /// </summary>
        [Fact]
        public void RendererInfo_SetProperties_StoresValuesCorrectly()
        {
            RendererInfo info = new RendererInfo
            {
                Name = new IntPtr(123),
                flags = 5U,
                num_texture_formats = 2U,
                textureFormats0 = 1,
                maxTextureWidth = 640,
                maxTextureHeight = 480
            };

            Assert.Equal(new IntPtr(123), info.Name);
            Assert.Equal(5U, info.flags);
            Assert.Equal(2U, info.num_texture_formats);
            Assert.Equal(1, info.textureFormats0);
            Assert.Equal(640, info.maxTextureWidth);
            Assert.Equal(480, info.maxTextureHeight);
        }

        /// <summary>
        ///     Tests that the struct is a value type and copies are independent
        /// </summary>
        [Fact]
        public void RendererInfo_IsValueType_CopyIsIndependent()
        {
            RendererInfo original = new RendererInfo { flags = 7U };
            RendererInfo copy = original;

            copy.flags = 8U;

            Assert.Equal(7U, original.flags);
            Assert.Equal(8U, copy.flags);
        }

        /// <summary>
        ///     Tests that get name returns null when name is zero
        /// </summary>
        [Fact]
        public void RendererInfo_GetName_ReturnsNullWhenNameIsZero()
        {
            RendererInfo info = new RendererInfo { Name = IntPtr.Zero };

            Assert.Null(info.GetName());
        }
    }
}