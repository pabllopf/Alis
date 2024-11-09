// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImgInitFlagsTest.cs
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
using Alis.Core.Aspect.Data.Resource;
using Xunit;

namespace Alis.Extension.Graphic.Sdl2Image.Test
{
    /// <summary>
    /// The img init flags test class
    /// </summary>
    public class ImgInitFlagsTest
    {
        /// <summary>
        /// Tests that img init flags should contain jpg flag
        /// </summary>
        [Fact]
        public void ImgInitFlags_ShouldContainJpgFlag()
        {
            Assert.Equal(0x00000001, (int) ImgInitFlags.ImgInitJpg);
        }

        /// <summary>
        /// Tests that img init flags should contain png flag
        /// </summary>
        [Fact]
        public void ImgInitFlags_ShouldContainPngFlag()
        {
            Assert.Equal(0x00000002, (int) ImgInitFlags.ImgInitPng);
        }

        /// <summary>
        /// Tests that img init flags should contain tif flag
        /// </summary>
        [Fact]
        public void ImgInitFlags_ShouldContainTifFlag()
        {
            Assert.Equal(0x00000004, (int) ImgInitFlags.ImgInitTif);
        }

        /// <summary>
        /// Tests that img init flags should contain webp flag
        /// </summary>
        [Fact]
        public void ImgInitFlags_ShouldContainWebpFlag()
        {
            Assert.Equal(0x00000008, (int) ImgInitFlags.ImgInitWebp);
        }
    }
}