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
using System.Net.Mime;
using Alis.Builder.Core.Ecs.Component.Render;
using Alis.Core.Ecs;
using Alis.Core.Ecs.Component.Render;
using Alis.Core.Ecs.Entity;
using Alis.Core.Graphic.Sdl2.Enums;
using Xunit;

namespace Alis.Test.Core.Ecs.Component.Render
{
    /// <summary>
    ///     The sprite test class
    /// </summary>
    public class SpriteTest
    {
        /// <summary>
        ///     Tests that on init valid input
        /// </summary>
        [Fact]
        public void OnInit_ValidInput()
        {
            VideoGame videoGame = new VideoGame();
            Sprite sprite = new Sprite("dino_assets.png");
            GameObject gameObject = new GameObject();
            gameObject.SetContext(videoGame.Context);
            sprite.Attach(gameObject);
            sprite.OnStart();
            sprite.OnInit();
        }

        /// <summary>
        ///     Tests that on awake valid input
        /// </summary>
        [Fact]
        public void OnAwake_ValidInput()
        {
            VideoGame videoGame = new VideoGame();
            Sprite sprite = new Sprite("dino_assets.png");
            GameObject gameObject = new GameObject();
            gameObject.SetContext(videoGame.Context);
            sprite.Attach(gameObject);
            sprite.OnStart();
            sprite.OnAwake();
        }

        /// <summary>
        ///     Tests that on exit valid input
        /// </summary>
        [Fact]
        public void OnExit_ValidInput()
        {
            VideoGame videoGame = new VideoGame();
            Sprite sprite = new Sprite("dino_assets.png");
            GameObject gameObject = new GameObject();
            gameObject.SetContext(videoGame.Context);
            sprite.Attach(gameObject);
            sprite.OnStart();
            sprite.OnExit();
        }

        /// <summary>
        ///     Tests that render valid input
        /// </summary>
        [Fact]
        public void Render_ValidInput()
        {
            VideoGame videoGame = new VideoGame();
            Sprite sprite = new Sprite("dino_assets.png");
            IntPtr renderer = IntPtr.Zero; // You would need to initialize a valid renderer here
            Camera camera = new Camera(); // You would need to initialize a valid camera here
        }

        /// <summary>
        ///     Tests that render without camera valid input
        /// </summary>
        [Fact]
        public void RenderWithoutCamera_ValidInput()
        {
            VideoGame videoGame = new VideoGame();
            Sprite sprite = new Sprite("dino_assets.png");
            IntPtr renderer = IntPtr.Zero;
        }

        /// <summary>
        ///     Tests that builder should return sprite builder
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
        ///     Tests that flips set value should change value
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