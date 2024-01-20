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
using Alis.Core.Graphic.Sdl2;
using Alis.Core.Graphic.Sdl2.Enums;
using Alis.Core.Graphic.Sdl2.Extensions.Sdl2Image;
using Alis.Core.Graphic.Sdl2.Extensions.Sdl2Ttf;
using Alis.Core.Graphic.Sdl2.Structs;
using Xunit;

namespace Alis.Core.Graphic.Test.Sdl2.Extensions.Sdl2Image
{
    /// <summary>
    /// The sdl image test class
    /// </summary>
    public class SdlImageTest
    {
        /// <summary>
        /// Tests that test
        /// </summary>
        [Fact]
        public void Test_Default() => Assert.True(true);
        
        [Fact]
        public void Test_GetVersion()
        {
            int sdlInit = Sdl.Init(Sdl.InitEverything);
            Assert.Equal(0, sdlInit);
            
            const ImgInitFlags flagImage = ImgInitFlags.ImgInitPng | ImgInitFlags.ImgInitJpg | ImgInitFlags.ImgInitTif | ImgInitFlags.ImgInitWebp;
            int sdlTtf = SdlImage.Init(flagImage);
            Assert.Equal(15, sdlTtf);
            
            try
            {
                SdlVersion version = SdlImage.GetVersion();
                Assert.Equal(2, version.major);
                Assert.Equal(0, version.minor);
                Assert.Equal(6, version.patch);
            }
            catch (Exception ex)
            {
                Assert.Fail($"No expected exception, but was thrown: {ex}");
            }finally
            {
                SdlImage.Quit();
                Sdl.Quit();
            }
        }
    }
}