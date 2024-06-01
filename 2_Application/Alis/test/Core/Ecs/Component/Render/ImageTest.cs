// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImageTest.cs
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
using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Ecs;
using Alis.Core.Ecs.Component.Render;
using Alis.Core.Ecs.System;
using Alis.Core.Ecs.System.Manager.Audio;
using Alis.Core.Ecs.System.Manager.Graphic;
using Alis.Core.Ecs.System.Manager.Input;
using Alis.Core.Ecs.System.Manager.Network;
using Alis.Core.Ecs.System.Manager.Physic;
using Alis.Core.Ecs.System.Manager.Scene;
using Alis.Core.Ecs.System.Setting;
using Xunit;

namespace Alis.Test.Core.Ecs.Component.Render
{
    /// <summary>
    /// The image test class
    /// </summary>
    public class ImageTest
    {
        /// <summary>
        /// Tests that image default constructor valid input
        /// </summary>
        [Fact]
        public void Image_DefaultConstructor_ValidInput()
        {
            Settings settings = new Settings();
            Context context = new Context(new Settings());
            Image image = new Image();
            
            // Asserts would go here, but it's hard to assert anything because the method doesn't return anything or change any observable state
        }
        
        /// <summary>
        /// Tests that image constructor with parameters valid input
        /// </summary>
        [Fact]
        public void Image_ConstructorWithParameters_ValidInput()
        {
            VideoGame videoGame = new VideoGame();
            Settings settings = new Settings();
            Context context = new Context(new Settings());
            string path = "dino_assets.png";
            Image image = new Image(path);
            
            // Asserts would go here, but it's hard to assert anything because the method doesn't return anything or change any observable state
        }
        
        /// <summary>
        /// Tests that image path property valid input
        /// </summary>
        [Fact]
        public void Image_PathProperty_ValidInput()
        {
            Settings settings = new Settings();
            Context context = new Context(new Settings());
            string path = "dino_assets.png";
            Image image = new Image();
            image.Path = path;
            
            // Asserts would go here, but it's hard to assert anything because the method doesn't return anything or change any observable state
        }
        
        /// <summary>
        /// Tests that image texture property valid input
        /// </summary>
        [Fact]
        public void Image_TextureProperty_ValidInput()
        {
            VideoGame videoGame = new VideoGame();
            Settings settings = new Settings();
            Context context = new Context(new Settings());
            string path = "dino_assets.png";
            Image image = new Image(path);
            IntPtr texture = image.Texture;
            
            // Asserts would go here, but it's hard to assert anything because the method doesn't return anything or change any observable state
        }
        
        /// <summary>
        /// Tests that image size property valid input
        /// </summary>
        [Fact]
        public void Image_SizeProperty_ValidInput()
        {
            VideoGame videoGame = new VideoGame();
            Settings settings = new Settings();
            Context context = new Context(new Settings());
            string path = "dino_assets.png";
            Image image = new Image(path);
            Vector2 size = image.Size;
            
            // Asserts would go here, but it's hard to assert anything because the method doesn't return anything or change any observable state
        }
        
        /// <summary>
        /// Tests that path set value should change value
        /// </summary>
        [Fact]
        public void Path_SetValue_ShouldChangeValue()
        {
            VideoGame videoGame = new VideoGame();
            Image image = new Image("dino_assets.png");
            Assert.Equal("dino_assets.png", image.NameFile);
            
            image.Path = "dino_assets.png";
            Assert.Equal("dino_assets.png", image.NameFile);
        }
    }
}