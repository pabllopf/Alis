// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:SpriteTest.cs
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
using Alis.Builder.Core.Ecs.Component.Render;
using Alis.Core.Ecs.Component.Render;
using Alis.Core.Graphic.Sdl2.Enums;
using Xunit;

namespace Alis.Test.Core.Ecs.Component.Render
{
    /// <summary>
    /// The sprite test class
    /// </summary>
    public class SpriteTest
    {
        /// <summary>
        /// Tests that on init valid input
        /// </summary>
        [Fact]
        public void OnInit_ValidInput()
        {
            Sprite sprite = new Sprite("testTexturePath");
            sprite.OnInit();
            
            
        }
        
        /// <summary>
        /// Tests that on awake valid input
        /// </summary>
        [Fact]
        public void OnAwake_ValidInput()
        {
            Sprite sprite = new Sprite("testTexturePath");
            sprite.OnAwake();
            
            
        }
        
        /// <summary>
        /// Tests that on exit valid input
        /// </summary>
        [Fact]
        public void OnExit_ValidInput()
        {
            Sprite sprite = new Sprite("testTexturePath");
            sprite.OnExit();
            
            
        }
        
        /// <summary>
        /// Tests that render valid input
        /// </summary>
        [Fact]
        public void Render_ValidInput()
        {
            Sprite sprite = new Sprite("testTexturePath");
            IntPtr renderer = IntPtr.Zero; // You would need to initialize a valid renderer here
            Camera camera = new Camera(); // You would need to initialize a valid camera here
            
            sprite.Render(renderer, camera);
            
            
        }
        
        /// <summary>
        /// Tests that render without camera valid input
        /// </summary>
        [Fact]
        public void RenderWithoutCamera_ValidInput()
        {
            Sprite sprite = new Sprite("testTexturePath");
            IntPtr renderer = IntPtr.Zero; // You would need to initialize a valid renderer here
            
            sprite.Render(renderer);
            
            
        }
        
        /// <summary>
        /// Tests that builder should return sprite builder
        /// </summary>
        [Fact]
        public void Builder_ShouldReturnSpriteBuilder()
        {
            Sprite sprite = new Sprite();
            SpriteBuilder result = sprite.Builder();
            Assert.NotNull(result);
            Assert.IsType<SpriteBuilder>(result);
        }
        
        /// <summary>
        /// Tests that render with renderer and camera should not throw exception
        /// </summary>
        [Fact]
        public void Render_WithRendererAndCamera_ShouldNotThrowException()
        {
            Sprite sprite = new Sprite();
            IntPtr renderer = IntPtr.Zero; // You would replace this with a valid renderer
            Camera camera = new Camera(); // You would replace this with a valid camera
            
            Exception exception = Record.Exception(() => sprite.Render(renderer, camera));
            Assert.Null(exception);
        }
        
        /// <summary>
        /// Tests that render with renderer should not throw exception
        /// </summary>
        [Fact]
        public void Render_WithRenderer_ShouldNotThrowException()
        {
            Sprite sprite = new Sprite();
            IntPtr renderer = IntPtr.Zero; // You would replace this with a valid renderer
            
            Exception exception = Record.Exception(() => sprite.Render(renderer));
            Assert.Null(exception);
        }
        
        /// <summary>
        /// Tests that flips set value should change value
        /// </summary>
        [Fact]
        public void Flips_SetValue_ShouldChangeValue()
        {
            Sprite sprite = new Sprite();
            sprite.Flips = RendererFlips.FlipHorizontal;
            Assert.Equal(RendererFlips.FlipHorizontal, sprite.Flips);
            
            sprite.Flips = RendererFlips.FlipVertical;
            Assert.Equal(RendererFlips.FlipVertical, sprite.Flips);
            
            sprite.Flips = RendererFlips.None;
            Assert.Equal(RendererFlips.None, sprite.Flips);
        }
    }
}