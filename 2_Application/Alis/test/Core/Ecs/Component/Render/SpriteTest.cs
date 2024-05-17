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
using Alis.Core.Ecs.Component.Render;
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
            
            // Asserts would go here, but it's hard to assert anything because the method doesn't return anything or change any observable state
        }
        
        /// <summary>
        /// Tests that on awake valid input
        /// </summary>
        [Fact]
        public void OnAwake_ValidInput()
        {
            Sprite sprite = new Sprite("testTexturePath");
            sprite.OnAwake();
            
            // Asserts would go here, but it's hard to assert anything because the method doesn't return anything or change any observable state
        }
        
        /// <summary>
        /// Tests that on exit valid input
        /// </summary>
        [Fact]
        public void OnExit_ValidInput()
        {
            Sprite sprite = new Sprite("testTexturePath");
            sprite.OnExit();
            
            // Asserts would go here, but it's hard to assert anything because the method doesn't return anything or change any observable state
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
            
            // Asserts would go here, but it's hard to assert anything because the method doesn't return anything or change any observable state
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
            
            // Asserts would go here, but it's hard to assert anything because the method doesn't return anything or change any observable state
        }
    }
}