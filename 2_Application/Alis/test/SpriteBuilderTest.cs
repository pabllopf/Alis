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

using Alis.Builder.Core.Ecs.Components.Render;
using Alis.Core.Ecs.Components.Render;
using Alis.Core.Ecs.Systems.Scope;
using Xunit;

namespace Alis.Test
{
    /// <summary>
    /// The sprite builder test class
    /// </summary>
    public class SpriteBuilderTest
    {
        /// <summary>
        /// Tests that constructor with context creates builder
        /// </summary>
        [Fact]
        public void Constructor_WithContext_CreatesBuilder()
        {
            Context context = new Context();
            SpriteBuilder builder = new SpriteBuilder(context);
            Assert.NotNull(builder);
        }

        /// <summary>
        /// Tests that build returns sprite instance
        /// </summary>
        [Fact]
        public void Build_ReturnsSpriteInstance()
        {
            Context context = new Context();
            SpriteBuilder builder = new SpriteBuilder(context);
            Sprite sprite = builder.Build();
            Assert.NotNull(sprite);
        }

        /// <summary>
        /// Tests that depth sets depth returns builder
        /// </summary>
        [Fact]
        public void Depth_SetsDepth_ReturnsBuilder()
        {
            Context context = new Context();
            SpriteBuilder builder = new SpriteBuilder(context);
            SpriteBuilder result = builder.Depth(5);
            Assert.Same(builder, result);
        }

        /// <summary>
        /// Tests that set texture sets texture path returns builder
        /// </summary>
        [Fact]
        public void SetTexture_SetsTexturePath_ReturnsBuilder()
        {
            Context context = new Context();
            SpriteBuilder builder = new SpriteBuilder(context);
            SpriteBuilder result = builder.SetTexture("textures/test.png");
            Assert.Same(builder, result);
        }

        /// <summary>
        /// Tests that chaining all properties creates sprite
        /// </summary>
        [Fact]
        public void ChainingAllProperties_CreatesSprite()
        {
            Context context = new Context();
            SpriteBuilder builder = new SpriteBuilder(context);
            Sprite sprite = builder
                .SetTexture("textures/sprite.png")
                .Depth(3)
                .Build();
            Assert.NotNull(sprite);
        }
    }
}
