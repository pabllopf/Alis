// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:SdlImageNativeTest.cs
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
    /// The sdl image native test class
    /// </summary>
    public class NativeSdlImageTest
    {
        /// <summary>
        /// Tests that version should return correct version
        /// </summary>
        [Fact]
        public void Version_ShouldReturnCorrectVersion()
        {
            SdlImage.Init(ImgInitFlags.ImgInitPng);
            Version version = SdlImage.Version();
            Assert.Equal(new Version(2, 0, 6), version);
        }
        
        /// <summary>
        /// Tests that load img should return valid pointer
        /// </summary>
        [Fact]
        public void LoadImg_ShouldReturnValidPointer()
        {
            SdlImage.Init(ImgInitFlags.ImgInitPng);
            string file = AssetManager.Find("test_image.png");
            IntPtr ptr = SdlImage.LoadImg(file);
            Assert.NotEqual(IntPtr.Zero, ptr);
        }
        
        /// <summary>
        /// Tests that get error should return error message
        /// </summary>
        [Fact]
        public void GetError_ShouldReturnErrorMessage()
        {
            SdlImage.Init(ImgInitFlags.ImgInitPng);
            string errorMessage = "Test error";
            SdlImage.SetError(errorMessage);
            string result = SdlImage.GetError();
            Assert.Equal(errorMessage, result);
        }

        /// <summary>
        /// Tests that img linked version should return valid pointer
        /// </summary>
        [Fact]
        public void IMG_Linked_Version_ShouldReturnValidPointer()
        {
            SdlImage.Init(ImgInitFlags.ImgInitPng);
            IntPtr ptr = NativeSdlImage.InternalVersion();
            Assert.NotEqual(IntPtr.Zero, ptr);
        }

        /// <summary>
        /// Tests that img load animation should return valid pointer
        /// </summary>
        [Fact]
        public void IMG_LoadAnimation_ShouldReturnValidPointer()
        {
            SdlImage.Init(ImgInitFlags.ImgInitPng);
            string file = AssetManager.Find("test_animation.gif");
            IntPtr ptr = NativeSdlImage.InternalLoadAnimation(file);
            Assert.NotEqual(IntPtr.Zero, ptr);
        }
        

        /// <summary>
        /// Tests that img init should return non zero
        /// </summary>
        [Fact]
        public void IMG_Init_ShouldReturnNonZero()
        {
            SdlImage.Init(ImgInitFlags.ImgInitPng);
            int result = NativeSdlImage.InternalInternalInit(ImgInitFlags.ImgInitJpg);
            Assert.NotEqual(0, result);
        }

        /// <summary>
        /// Tests that img quit should not throw exception
        /// </summary>
        [Fact]
        public void IMG_Quit_ShouldNotThrowException()
        {
            SdlImage.Init(ImgInitFlags.ImgInitPng);
            NativeSdlImage.InternalQuit();
        }

        /// <summary>
        /// Tests that internal img load should return valid pointer
        /// </summary>
        [Fact]
        public void INTERNAL_IMG_Load_ShouldReturnValidPointer()
        {
            SdlImage.Init(ImgInitFlags.ImgInitPng);
            IntPtr file = Marshal.StringToHGlobalAnsi(AssetManager.Find("test_image.png"));
            try
            {
                IntPtr ptr = NativeSdlImage.InternalLoad(file);
                Assert.NotEqual(IntPtr.Zero, ptr);
            }
            finally
            {
                Marshal.FreeHGlobal(file);
            }
        }
    }
}