// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImgAnimationTest.cs
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
using Xunit;

namespace Alis.Extension.Graphic.Sdl2Image.Test
{
    /// <summary>
    /// The img animation test class
    /// </summary>
    public class ImgAnimationTest
    {
        /// <summary>
        /// Tests that img animation should initialize correctly
        /// </summary>
        [Fact]
        public void ImgAnimation_ShouldInitializeCorrectly()
        {
            SdlImage.Init(ImgInitFlags.ImgInitPng);
            
            ImgAnimation animation = new ImgAnimation
            {
                W = 100,
                H = 200,
                Frames = IntPtr.Zero,
                Delays = IntPtr.Zero
            };

            Assert.Equal(100, animation.W);
            Assert.Equal(200, animation.H);
            Assert.Equal(IntPtr.Zero, animation.Frames);
            Assert.Equal(IntPtr.Zero, animation.Delays);
        }

        /// <summary>
        /// Tests that img animation should set frames correctly
        /// </summary>
        [Fact]
        public void ImgAnimation_ShouldSetFramesCorrectly()
        {
            SdlImage.Init(ImgInitFlags.ImgInitPng);
            IntPtr frames = new IntPtr(123);
            ImgAnimation animation = new ImgAnimation
            {
                Frames = frames
            };

            Assert.Equal(frames, animation.Frames);
        }

        /// <summary>
        /// Tests that img animation should set delays correctly
        /// </summary>
        [Fact]
        public void ImgAnimation_ShouldSetDelaysCorrectly()
        {
            SdlImage.Init(ImgInitFlags.ImgInitPng);
            IntPtr delays = new IntPtr(456);
            ImgAnimation animation = new ImgAnimation
            {
                Delays = delays
            };

            Assert.Equal(delays, animation.Delays);
        }
    }
}