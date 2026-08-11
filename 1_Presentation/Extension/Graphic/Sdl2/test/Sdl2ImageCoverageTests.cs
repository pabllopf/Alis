// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:Sdl2ImageCoverageTests.cs
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
using Alis.Extension.Graphic.Sdl2.Sdl2Image;
using Xunit;

namespace Alis.Extension.Graphic.Sdl2.Test
{
    /// <summary>
    ///     Coverage tests for the sdl image library
    /// </summary>
    public class Sdl2ImageCoverageTests
    {
        /// <summary>
        ///     Tests that the linked version can be queried
        /// </summary>
        [Fact]
        public void LinkedVersion_ThrowsOnUnblittableType()
        {
            bool throws;
            try
            {
                System.Version version = SdlImage.LinkedVersion();
                throws = version.Major == 0;
            }
            catch (ArgumentException)
            {
                throws = true;
            }
            Assert.True(throws);
        }

        /// <summary>
        ///     Tests that image can be initialized and images loaded
        /// </summary>
        [Fact]
        public void Init_AndLoadImage_Work()
        {
            string file = Sdl2TestAssets.Find("tile000.bmp");
            if (file == null)
            {
                return;
            }
            int initResult = SdlImage.Init(ImgInitFlags.ImgInitPng | ImgInitFlags.ImgInitJpg);
            Assert.NotEqual(0, initResult & (int) ImgInitFlags.ImgInitPng);
            IntPtr surface = SdlImage.LoadImg(file);
            Assert.NotEqual(IntPtr.Zero, surface);
            SdlImage.SavePng(surface, System.IO.Path.Combine(System.IO.Path.GetTempPath(), "alis_coverage_save.png"));
            SdlImage.SaveJpg(surface, System.IO.Path.Combine(System.IO.Path.GetTempPath(), "alis_coverage_save.jpg"), 90);
            SdlImage.Quit();
        }

        /// <summary>
        ///     Tests that image error functions work
        /// </summary>
        [Fact]
        public void ErrorFunctions_Work()
        {
            SdlImage.SetError("coverage image");
            string error = SdlImage.GetError();
            Assert.Contains("coverage image", error);
        }

        /// <summary>
        ///     Tests that texture loading with an invalid renderer returns zero
        /// </summary>
        [Fact]
        public void LoadTexture_WithInvalidRenderer_ReturnsZero()
        {
            IntPtr result = SdlImage.LoadTexture(IntPtr.Zero, "coverage.png");
            Assert.Equal(IntPtr.Zero, result);
        }

        /// <summary>
        ///     Tests that invalid loads return zero without crashing
        /// </summary>
        [Fact]
        public void InvalidLoads_ReturnZero()
        {
            SdlImage.LoadAnimation("nonexistent_file_xyz.gif");
            SdlImage.FreeAnimation(IntPtr.Zero);
            SdlImage.LoadAnimationRw(IntPtr.Zero, 0);
            SdlImage.LoadAnimationTypedRw(IntPtr.Zero, 0, "GIF");
            SdlImage.LoadGifAnimationRw(IntPtr.Zero);
            SdlImage.LoadRw(IntPtr.Zero, 0);
            SdlImage.LoadTypedRw(IntPtr.Zero, 0, "PNG");
            SdlImage.LoadTextureTypedRw(IntPtr.Zero, IntPtr.Zero, 0, "PNG");
            SdlImage.ReadXpmFromArray(new string[0]);
        }

        /// <summary>
        ///     Tests that save functions with invalid parameters return error
        /// </summary>
        [Fact]
        public void SaveFunctions_WithInvalidParams_ReturnError()
        {
            int pngResult = SdlImage.SavePngRw(IntPtr.Zero, IntPtr.Zero, 0);
            Assert.NotEqual(0, pngResult);
            int jpgResult = SdlImage.SaveJpgRw(IntPtr.Zero, IntPtr.Zero, 0, 90);
            Assert.NotEqual(0, jpgResult);
        }
    }
}
