// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:SpriteBuilderTest.cs
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

using Alis.Builder.Core.Ecs.Component.Render;
using Alis.Core.Ecs.Component.Render;
using Xunit;

namespace Alis.Test.Builder.Core.Ecs.Component.Render
{
    /// <summary>
    /// The sprite builder test class
    /// </summary>
    public class SpriteBuilderTest
    {
        /// <summary>
        /// Tests that sprite builder default constructor valid input
        /// </summary>
        [Fact]
        public void SpriteBuilder_DefaultConstructor_ValidInput()
        {
            SpriteBuilder spriteBuilder = new SpriteBuilder();
            
            Assert.NotNull(spriteBuilder);
        }
        
        /// <summary>
        /// Tests that build valid input
        /// </summary>
        [Fact]
        public void Build_ValidInput()
        {
            SpriteBuilder spriteBuilder = new SpriteBuilder();
            
            Sprite sprite = spriteBuilder.Build();
            
            Assert.NotNull(sprite);
        }
        
        /// <summary>
        /// Tests that depth valid input
        /// </summary>
        [Fact]
        public void Depth_ValidInput()
        {
            SpriteBuilder spriteBuilder = new SpriteBuilder();
            int depth = 10;
            
            spriteBuilder.Depth(depth);
            
            Assert.Equal(depth, spriteBuilder.Build().Depth);
        }
        
        /// <summary>
        /// Tests that set texture valid input
        /// </summary>
        [Fact]
        public void SetTexture_ValidInput()
        {
            SpriteBuilder spriteBuilder = new SpriteBuilder();
            string texturePath = "testTexturePath";
            
            spriteBuilder.SetTexture(texturePath);
            
            Assert.Equal(texturePath, spriteBuilder.Build().Name);
        }
    }
}