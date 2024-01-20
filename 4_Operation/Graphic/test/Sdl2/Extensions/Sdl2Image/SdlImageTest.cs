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
using Alis.Core.Aspect.Data.Resource;
using Alis.Core.Graphic.Sdl2;
using Alis.Core.Graphic.Sdl2.Extensions.Sdl2Image;
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
        
        
        /// <summary>
        /// Tests that test get version
        /// </summary>
        [Fact]
        public void Test_GetVersion()
        {
            int sdlInit = Sdl.Init(Sdl.InitEverything);
            Assert.Equal(0, sdlInit);
            
            int sdlImage = SdlImage.Init();
            Assert.NotEqual(0, sdlImage);
            
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
       
        /// <summary>
        /// Tests that test load
        /// </summary>
        [Fact]
        public void Test_Load()
        {
            int sdlInit = Sdl.Init(Sdl.InitEverything);
            Assert.Equal(0, sdlInit);

            int sdlImage = SdlImage.Init();
            Assert.NotEqual(0, sdlImage);
            Assert.NotEqual(-1, sdlImage);
            
            try
            {
                string file = AssetManager.Find("tile000.png");
                IntPtr surface = SdlImage.Load(file);
                Assert.NotEqual(IntPtr.Zero, surface);
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

        /// <summary>
        /// Tests that test load rw
        /// </summary>
        [Fact]
        public void Test_LoadRw()
        {
            int sdlInit = Sdl.Init(Sdl.InitEverything);
            Assert.Equal(0, sdlInit);

            int sdlImage = SdlImage.Init();
            Assert.NotEqual(0, sdlImage);
            Assert.NotEqual(-1, sdlImage);
            
            try
            {
                string file = AssetManager.Find("tile000.png");
                IntPtr rw = Sdl.RwFromFile(file, "rb");
                IntPtr surface = SdlImage.LoadRw(rw, 0);
                Assert.NotEqual(IntPtr.Zero, surface);
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

        /// <summary>
        /// Tests that test load typed rw
        /// </summary>
        [Fact]
        public void Test_LoadTypedRw()
        {
            int sdlInit = Sdl.Init(Sdl.InitEverything);
            Assert.Equal(0, sdlInit);

            int sdlImage = SdlImage.Init();
            Assert.NotEqual(0, sdlImage);
            Assert.NotEqual(-1, sdlImage);
            
            try
            {
                string file = AssetManager.Find("tile000.png");
                IntPtr rw = Sdl.RwFromFile(file, "rb");
                IntPtr surface = SdlImage.LoadTypedRw(rw, 0, "PNG");
                Assert.NotEqual(IntPtr.Zero, surface);
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