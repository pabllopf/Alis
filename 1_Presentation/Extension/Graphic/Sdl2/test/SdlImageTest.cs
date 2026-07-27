// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:SdlImageTest.cs
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
    /// The sdl image test class
    /// </summary>
    public class SdlImageTest
    {
        /// <summary>
        /// Tests that should return compiled version
        /// </summary>
        [Fact]
        public void ShouldReturnCompiledVersion()
        {
            Version version = SdlImage.Version();
            Assert.Equal(2, version.Major);
            Assert.Equal(0, version.Minor);
            Assert.Equal(6, version.Build);
        }

        /// <summary>
        /// Tests that GetError returns a string when no error is set
        /// </summary>
        [Fact]
        public void ShouldGetError()
        {
            string error = SdlImage.GetError();
            Assert.NotNull(error);
        }

        /// <summary>
        /// Tests that SetError and GetError work together
        /// </summary>
        [Fact]
        public void ShouldSetAndGetError()
        {
            SdlImage.SetError("test error");
            string error = SdlImage.GetError();
            Assert.Contains("test error", error);
        }

        /// <summary>
        /// Tests that Init initializes and Quit cleans up
        /// </summary>
        [Fact]
        public void ShouldInitAndQuit()
        {
            int result = SdlImage.Init(ImgInitFlags.ImgInitPng);
            Assert.Equal(ImgInitFlags.ImgInitPng, (ImgInitFlags)result);
            SdlImage.Quit();
        }

        /// <summary>
        /// Tests that Init with multiple flags returns the expected mask
        /// </summary>
        [Fact]
        public void ShouldInitWithMultipleFlags()
        {
            ImgInitFlags flags = ImgInitFlags.ImgInitJpg | ImgInitFlags.ImgInitPng;
            int result = SdlImage.Init(flags);
            Assert.True((result & (int)ImgInitFlags.ImgInitJpg) != 0);
            Assert.True((result & (int)ImgInitFlags.ImgInitPng) != 0);
            SdlImage.Quit();
        }

        /// <summary>
        /// Tests that LoadImg with non-existent file returns IntPtr.Zero
        /// </summary>
        [Fact]
        public void ShouldLoadImgReturnZeroForNonExistentFile()
        {
            IntPtr result = SdlImage.LoadImg("nonexistent_file_xyz.png");
            Assert.Equal(IntPtr.Zero, result);
        }

        /// <summary>
        /// Tests that LoadAnimation with non-existent file returns IntPtr.Zero
        /// </summary>
        [Fact]
        public void ShouldLoadAnimationReturnZeroForNonExistentFile()
        {
            IntPtr result = SdlImage.LoadAnimation("nonexistent_file_xyz.gif");
            Assert.Equal(IntPtr.Zero, result);
        }

        /// <summary>
        /// Tests that FreeAnimation with IntPtr.Zero does not throw
        /// </summary>
        [Fact]
        public void ShouldFreeAnimationNotThrowWithZero()
        {
            SdlImage.FreeAnimation(IntPtr.Zero);
        }

        /// <summary>
        /// Tests that LoadRw with invalid src returns IntPtr.Zero
        /// </summary>
        [Fact]
        public void ShouldLoadRwReturnZeroWithInvalidSrc()
        {
            IntPtr result = SdlImage.LoadRw(IntPtr.Zero, 0);
            Assert.Equal(IntPtr.Zero, result);
        }

        /// <summary>
        /// Tests that LoadTypedRw with invalid src returns IntPtr.Zero
        /// </summary>
        [Fact]
        public void ShouldLoadTypedRwReturnZeroWithInvalidSrc()
        {
            IntPtr result = SdlImage.LoadTypedRw(IntPtr.Zero, 0, "PNG");
            Assert.Equal(IntPtr.Zero, result);
        }

        /// <summary>
        /// Tests that LoadTexture with invalid renderer returns IntPtr.Zero
        /// </summary>
        [Fact]
        public void ShouldLoadTextureReturnZeroWithInvalidRenderer()
        {
            IntPtr result = SdlImage.LoadTexture(IntPtr.Zero, "test.png");
            Assert.Equal(IntPtr.Zero, result);
        }

        /// <summary>
        /// Tests that LoadTextureTypedRw with invalid params returns IntPtr.Zero
        /// </summary>
        [Fact]
        public void ShouldLoadTextureTypedRwReturnZeroWithInvalidParams()
        {
            IntPtr result = SdlImage.LoadTextureTypedRw(IntPtr.Zero, IntPtr.Zero, 0, "PNG");
            Assert.Equal(IntPtr.Zero, result);
        }

        /// <summary>
        /// Tests that LoadAnimationRw with invalid src returns IntPtr.Zero
        /// </summary>
        [Fact]
        public void ShouldLoadAnimationRwReturnZeroWithInvalidSrc()
        {
            IntPtr result = SdlImage.LoadAnimationRw(IntPtr.Zero, 0);
            Assert.Equal(IntPtr.Zero, result);
        }

        /// <summary>
        /// Tests that LoadAnimationTypedRw with invalid params returns IntPtr.Zero
        /// </summary>
        [Fact]
        public void ShouldLoadAnimationTypedRwReturnZeroWithInvalidParams()
        {
            IntPtr result = SdlImage.LoadAnimationTypedRw(IntPtr.Zero, 0, "GIF");
            Assert.Equal(IntPtr.Zero, result);
        }

        /// <summary>
        /// Tests that LoadGifAnimationRw with invalid src returns IntPtr.Zero
        /// </summary>
        [Fact]
        public void ShouldLoadGifAnimationRwReturnZeroWithInvalidSrc()
        {
            IntPtr result = SdlImage.LoadGifAnimationRw(IntPtr.Zero);
            Assert.Equal(IntPtr.Zero, result);
        }

        /// <summary>
        /// Tests that SaveJpgRw with invalid params returns error
        /// </summary>
        [Fact]
        public void ShouldSaveJpgRwReturnErrorWithInvalidParams()
        {
            int result = SdlImage.SaveJpgRw(IntPtr.Zero, IntPtr.Zero, 0, 85);
            Assert.NotEqual(0, result);
        }

        /// <summary>
        /// Tests that SavePngRw with invalid params returns error
        /// </summary>
        [Fact]
        public void ShouldSavePngRwReturnErrorWithInvalidParams()
        {
            int result = SdlImage.SavePngRw(IntPtr.Zero, IntPtr.Zero, 0);
            Assert.NotEqual(0, result);
        }

        /// <summary>
        /// Tests that ReadXpmFromArray with empty array returns IntPtr.Zero
        /// </summary>
        [Fact]
        public void ShouldReadXpmFromArrayReturnZeroForEmptyArray()
        {
            string[] xpm = { };
            IntPtr result = SdlImage.ReadXpmFromArray(xpm);
            Assert.Equal(IntPtr.Zero, result);
        }

    }
}
