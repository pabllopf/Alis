// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:SpriteTests.cs
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

using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Ecs.Components.Render;
using Alis.Core.Ecs.Systems.Scope;
using Xunit;

namespace Alis.Test.Core.Ecs.Components.Render
{
    /// <summary>
    ///     Additional coverage tests for the Sprite component record struct
    /// </summary>
    public class SpriteTests
    {
        /// <summary>
        ///     Tests that OnUpdate does not throw when called
        /// </summary>
        [Fact]
        public void OnUpdate_ShouldNotThrow()
        {
            Context context = new Context();
            Sprite sprite = new Sprite(context, "test.png", 0);

            sprite.OnUpdate(null);
        }

        /// <summary>
        ///     Tests that OnStart does not throw when called
        /// </summary>
        [Fact]
        public void OnStart_ShouldNotThrow()
        {
            Context context = new Context();
            Sprite sprite = new Sprite(context, "test.png", 0);

            sprite.OnStart(null);
        }

        /// <summary>
        ///     Tests that OnExit does not throw with default state (Texture == 0)
        /// </summary>
        [Fact]
        public void OnExit_WithDefaultTexture_ShouldNotThrow()
        {
            Context context = new Context();
            Sprite sprite = new Sprite(context, "test.png", 0);

            sprite.OnExit(null);
        }

        /// <summary>
        ///     Tests that OnExit clears the internal Path
        /// </summary>
        [Fact]
        public void OnExit_ShouldClearInternalPath()
        {
            Context context = new Context();
            Sprite sprite = new Sprite(context, "test.png", 0);

            sprite.OnExit(null);

            Assert.Equal(string.Empty, sprite.Path);
        }

        /// <summary>
        ///     Tests that the internal Path property is settable and gettable
        /// </summary>
        [Fact]
        public void Path_InternalProperty_ShouldBeSettableAndGettable()
        {
            Context context = new Context();
            Sprite sprite = new Sprite(context, "test.png", 0);

            Assert.Equal(string.Empty, sprite.Path);
        }

        /// <summary>
        ///     Tests that Depth can be set to different values
        /// </summary>
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(-1)]
        [InlineData(int.MaxValue)]
        [InlineData(int.MinValue)]
        public void Depth_ShouldAcceptAnyIntValue(int depth)
        {
            Context context = new Context();
            Sprite sprite = new Sprite(context, "test.png", depth);

            Assert.Equal(depth, sprite.Depth);

            sprite.Depth = depth;
            Assert.Equal(depth, sprite.Depth);
        }

        /// <summary>
        ///     Tests that NameFile can be set after construction
        /// </summary>
        [Fact]
        public void NameFile_ShouldBeSettable()
        {
            Context context = new Context();
            Sprite sprite = new Sprite(context, "original.png", 0);

            sprite.NameFile = "updated.png";
            Assert.Equal("updated.png", sprite.NameFile);
        }

        /// <summary>
        ///     Tests that Depth can be set after construction
        /// </summary>
        [Fact]
        public void Depth_ShouldBeSettable()
        {
            Context context = new Context();
            Sprite sprite = new Sprite(context, "test.png", 0);

            sprite.Depth = 10;
            Assert.Equal(10, sprite.Depth);
        }

        /// <summary>
        ///     Tests that Context property returns the instance passed to constructor
        /// </summary>
        [Fact]
        public void Context_ShouldReturnConstructorValue()
        {
            Context context = new Context();
            Sprite sprite = new Sprite(context, "test.png", 0);

            Assert.Same(context, sprite.Context);
        }

        /// <summary>
        ///     Tests that two Sprites with same values are equal
        /// </summary>
        [Fact]
        public void Equals_SameValues_ReturnsTrue()
        {
            Context context = new Context();
            Sprite sprite1 = new Sprite(context, "test.png", 0);
            Sprite sprite2 = new Sprite(context, "test.png", 0);

            Assert.True(sprite1.Equals(sprite2));
        }

        /// <summary>
        ///     Tests that Equals with different NameFile returns false
        /// </summary>
        [Fact]
        public void Equals_DifferentNameFile_ReturnsFalse()
        {
            Context context = new Context();
            Sprite sprite1 = new Sprite(context, "a.png", 0);
            Sprite sprite2 = new Sprite(context, "b.png", 0);

            Assert.False(sprite1.Equals(sprite2));
        }

        /// <summary>
        ///     Tests that Equals with different Depth returns false
        /// </summary>
        [Fact]
        public void Equals_DifferentDepth_ReturnsFalse()
        {
            Context context = new Context();
            Sprite sprite1 = new Sprite(context, "test.png", 0);
            Sprite sprite2 = new Sprite(context, "test.png", 1);

            Assert.False(sprite1.Equals(sprite2));
        }

        /// <summary>
        ///     Tests that Equals with different Context returns false
        /// </summary>
        [Fact]
        public void Equals_DifferentContext_ReturnsFalse()
        {
            Context context1 = new Context();
            Context context2 = new Context();
            Sprite sprite1 = new Sprite(context1, "test.png", 0);
            Sprite sprite2 = new Sprite(context2, "test.png", 0);

            Assert.False(sprite1.Equals(sprite2));
        }

        /// <summary>
        ///     Tests that Equals with null returns false
        /// </summary>
        [Fact]
        public void Equals_Null_ReturnsFalse()
        {
            Context context = new Context();
            Sprite sprite = new Sprite(context, "test.png", 0);

            Assert.False(sprite.Equals(null));
        }

        /// <summary>
        ///     Tests that Equals with different type returns false
        /// </summary>
        [Fact]
        public void Equals_DifferentType_ReturnsFalse()
        {
            Context context = new Context();
            Sprite sprite = new Sprite(context, "test.png", 0);

            Assert.False(sprite.Equals("not a sprite"));
        }

        /// <summary>
        ///     Tests that == operator returns true for equal values
        /// </summary>
        [Fact]
        public void OperatorEquals_SameValues_ReturnsTrue()
        {
            Context context = new Context();
            Sprite sprite1 = new Sprite(context, "test.png", 0);
            Sprite sprite2 = new Sprite(context, "test.png", 0);

            Assert.True(sprite1 == sprite2);
        }

        /// <summary>
        ///     Tests that != operator returns true for different values
        /// </summary>
        [Fact]
        public void OperatorNotEquals_DifferentValues_ReturnsTrue()
        {
            Context context = new Context();
            Sprite sprite1 = new Sprite(context, "a.png", 0);
            Sprite sprite2 = new Sprite(context, "b.png", 0);

            Assert.True(sprite1 != sprite2);
        }

        /// <summary>
        ///     Tests that GetHashCode is consistent for equal sprites
        /// </summary>
        [Fact]
        public void GetHashCode_SameValues_ShouldMatch()
        {
            Context context = new Context();
            Sprite sprite1 = new Sprite(context, "test.png", 0);
            Sprite sprite2 = new Sprite(context, "test.png", 0);

            Assert.Equal(sprite1.GetHashCode(), sprite2.GetHashCode());
        }

        /// <summary>
        ///     Tests that GetHashCode differs for different sprites
        /// </summary>
        [Fact]
        public void GetHashCode_DifferentValues_ShouldDiffer()
        {
            Context context = new Context();
            Sprite sprite1 = new Sprite(context, "a.png", 0);
            Sprite sprite2 = new Sprite(context, "b.png", 0);

            Assert.NotEqual(sprite1.GetHashCode(), sprite2.GetHashCode());
        }

        /// <summary>
        ///     Tests that ToString returns a non-null value
        /// </summary>
        [Fact]
        public void ToString_ShouldReturnNonNull()
        {
            Context context = new Context();
            Sprite sprite = new Sprite(context, "test.png", 0);

            Assert.NotNull(sprite.ToString());
        }

        /// <summary>
        ///     Tests that Deconstruct returns the component values
        /// </summary>
        [Fact]
        public void Deconstruct_ShouldReturnComponents()
        {
            Context context = new Context();
            Sprite sprite = new Sprite(context, "deconstruct.png", 42);

            sprite.Deconstruct(out Context ctx, out string name, out int depth);

            Assert.Same(context, ctx);
            Assert.Equal("deconstruct.png", name);
            Assert.Equal(42, depth);
        }

        /// <summary>
        ///     Tests that IsSpriteVisible returns visible when sprite is exactly at camera center
        ///     with rotation exactly at the threshold (0.0001f)
        /// </summary>
        [Fact]
        public void IsSpriteVisible_WithRotationAtThreshold_ShouldUseNoRotationBounds()
        {
            Vector2F spritePos = new Vector2F(0, 0);
            Vector2F spriteSize = new Vector2F(32, 32);
            Vector2F spriteScale = new Vector2F(1, 1);
            Vector2F cameraPos = new Vector2F(0, 0);
            Vector2F cameraRes = new Vector2F(800, 600);
            float ppm = 32;

            bool visible = Sprite.IsSpriteVisible(spritePos, spriteSize, spriteScale, 0.0001f, cameraPos, cameraRes, ppm);

            Assert.True(visible);
        }

        /// <summary>
        ///     Tests that IsSpriteVisible returns false when sprite is very far on both axes
        /// </summary>
        [Fact]
        public void IsSpriteVisible_FarOnBothAxes_ReturnsFalse()
        {
            Vector2F spritePos = new Vector2F(-1000, 2000);
            Vector2F spriteSize = new Vector2F(16, 16);
            Vector2F spriteScale = new Vector2F(1, 1);
            Vector2F cameraPos = new Vector2F(0, 0);
            Vector2F cameraRes = new Vector2F(800, 600);
            float ppm = 32;

            bool visible = Sprite.IsSpriteVisible(spritePos, spriteSize, spriteScale, 0f, cameraPos, cameraRes, ppm);

            Assert.False(visible);
        }

        /// <summary>
        ///     Tests that IsSpriteVisible returns false when sprite is on negative X outside camera
        ///     with rotation
        /// </summary>
        [Fact]
        public void IsSpriteVisible_NegativeXWithRotation_ReturnsFalse()
        {
            Vector2F spritePos = new Vector2F(-50, 0);
            Vector2F spriteSize = new Vector2F(16, 16);
            Vector2F spriteScale = new Vector2F(1, 1);
            Vector2F cameraPos = new Vector2F(0, 0);
            Vector2F cameraRes = new Vector2F(800, 600);
            float ppm = 32;

            bool visible = Sprite.IsSpriteVisible(spritePos, spriteSize, spriteScale, 45f, cameraPos, cameraRes, ppm);

            Assert.False(visible);
        }

        /// <summary>
        ///     Tests that IsSpriteVisible returns true with non-uniform scale
        /// </summary>
        [Fact]
        public void IsSpriteVisible_NonUniformScale_ReturnsTrue()
        {
            Vector2F spritePos = new Vector2F(5, 5);
            Vector2F spriteSize = new Vector2F(32, 32);
            Vector2F spriteScale = new Vector2F(2, 1);
            Vector2F cameraPos = new Vector2F(0, 0);
            Vector2F cameraRes = new Vector2F(800, 600);
            float ppm = 32;

            bool visible = Sprite.IsSpriteVisible(spritePos, spriteSize, spriteScale, 0f, cameraPos, cameraRes, ppm);

            Assert.True(visible);
        }

        /// <summary>
        ///     Tests that IsSpriteVisible works with custom camera position
        /// </summary>
        [Fact]
        public void IsSpriteVisible_WithCameraOffset_ReturnsTrue()
        {
            Vector2F spritePos = new Vector2F(100, 100);
            Vector2F spriteSize = new Vector2F(32, 32);
            Vector2F spriteScale = new Vector2F(1, 1);
            Vector2F cameraPos = new Vector2F(100, 100);
            Vector2F cameraRes = new Vector2F(800, 600);
            float ppm = 32;

            bool visible = Sprite.IsSpriteVisible(spritePos, spriteSize, spriteScale, 0f, cameraPos, cameraRes, ppm);

            Assert.True(visible);
        }

        /// <summary>
        ///     Tests that constructor can be called with default (parameterless) syntax
        /// </summary>
        [Fact]
        public void DefaultConstructor_ShouldCreateDefaultSprite()
        {
            Sprite sprite = default;

            Assert.Null(sprite.Context);
            Assert.Null(sprite.NameFile);
            Assert.Equal(0, sprite.Depth);
        }
    }
}
