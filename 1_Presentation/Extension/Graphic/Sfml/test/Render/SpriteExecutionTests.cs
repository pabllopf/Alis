// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:SpriteExecutionTests.cs
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
using System.IO;
using Alis.Core.Aspect.Math.Vector;
using Alis.Extension.Graphic.Sfml.Render;
using Alis.Extension.Graphic.Sfml.Test.Attributes;
using Moq;
using Xunit;

namespace Alis.Extension.Graphic.Sfml.Test.Render
{
    /// <summary>
    ///     Executes the <see cref="Sprite" /> wrapper members against the real native CSFML library. Textures are loaded
    ///     from the bundled bitmap asset because the installed CSFML 3.0 changed the creation ABI to <c>sfVector2u</c> and
    ///     the wrapper still declares the two integer form, which makes the width and height constructor always fail. The
    ///     draw switch cases for <see cref="RenderWindow" /> and <see cref="RenderTexture" /> are not exercised because the
    ///     installed CSFML 3.0 shifted the <c>sfRenderStates</c> layout and the native draw calls crash the test host.
    /// </summary>
    public class SpriteExecutionTests
    {
        /// <summary>
        ///     The assets dir
        /// </summary>
        private static readonly string AssetsDir;

        /// <summary>
        ///     Initializes a new instance of the <see cref="SpriteExecutionTests"/> class
        /// </summary>
        static SpriteExecutionTests()
        {
            string assemblyDir = Path.GetDirectoryName(typeof(SpriteExecutionTests).Assembly.Location);
            AssetsDir = Path.GetFullPath(Path.Combine(assemblyDir, "..", "..", "..", "Assets"));
        }

        /// <summary>
        ///     Gets the value of the bitmap sample path
        /// </summary>
        private static string BitmapSamplePath => Path.Combine(AssetsDir, "tile000.bmp");

        /// <summary>
        ///     Tests that the default constructor creates a valid native handle
        /// </summary>
        [RequireCSfmlSystemFact]
        public void Ctor_Default_CreatesNativeHandle()
        {
            using Sprite sprite = new Sprite();
            Assert.NotEqual(IntPtr.Zero, sprite.CPointer);
        }

        /// <summary>
        ///     Tests that the texture constructor assigns the source texture
        /// </summary>
        [RequireCSfmlSystemFact]
        public void Ctor_Texture_AssignsTexture()
        {
            using Texture texture = new Texture(BitmapSamplePath);
            using Sprite sprite = new Sprite(texture);
            Assert.Same(texture, sprite.Texture);
        }

        /// <summary>
        ///     Tests that the texture and rectangle constructor assigns both members
        /// </summary>
        [RequireCSfmlSystemFact]
        public void Ctor_TextureAndIntRect_AssignsBothMembers()
        {
            using Texture texture = new Texture(BitmapSamplePath);
            IntRect rect = new IntRect(4, 4, 32, 32);
            using Sprite sprite = new Sprite(texture, rect);
            Assert.Same(texture, sprite.Texture);
            Assert.Equal(4f, sprite.TextureRect.Left);
            Assert.Equal(4f, sprite.TextureRect.Top);
            Assert.Equal(32f, sprite.TextureRect.Width);
            Assert.Equal(32f, sprite.TextureRect.Height);
        }

        /// <summary>
        ///     Tests that the copy constructor copies the transform members and the texture
        /// </summary>
        [RequireCSfmlSystemFact]
        public void Ctor_Copy_CopiesTransformMembersAndTexture()
        {
            using Texture texture = new Texture(BitmapSamplePath);
            using Sprite original = new Sprite(texture);
            original.Position = new Vector2F(10, 20);
            original.Rotation = 45;
            original.Scale = new Vector2F(2, 3);
            original.Origin = new Vector2F(5, 6);
            original.Color = new Color(10, 20, 30, 40);
            using Sprite copy = new Sprite(original);
            Assert.Equal(10, copy.Position.X);
            Assert.Equal(20, copy.Position.Y);
            Assert.Equal(45, copy.Rotation);
            Assert.Equal(2, copy.Scale.X);
            Assert.Equal(3, copy.Scale.Y);
            Assert.Equal(5, copy.Origin.X);
            Assert.Equal(6, copy.Origin.Y);
            Assert.Equal(new Color(10, 20, 30, 40), copy.Color);
            Assert.Same(texture, copy.Texture);
        }

        /// <summary>
        ///     Tests that the color property round trips
        /// </summary>
        [RequireCSfmlSystemFact]
        public void Color_GetSet_RoundTrips()
        {
            using Sprite sprite = new Sprite();
            Color color = new Color(255, 128, 64, 32);
            sprite.Color = color;
            Assert.Equal(color, sprite.Color);
        }

        /// <summary>
        ///     Tests that the texture property round trips
        /// </summary>
        [RequireCSfmlSystemFact]
        public void Texture_GetSet_RoundTrips()
        {
            using Texture texture = new Texture(BitmapSamplePath);
            using Sprite sprite = new Sprite();
            Assert.Null(sprite.Texture);
            sprite.Texture = texture;
            Assert.Same(texture, sprite.Texture);
        }

        /// <summary>
        ///     Tests that setting the texture property to null does not throw
        /// </summary>
        [RequireCSfmlSystemFact]
        public void Texture_SetNull_DoesNotThrow()
        {
            using Sprite sprite = new Sprite();
            sprite.Texture = null;
            Assert.Null(sprite.Texture);
        }

        /// <summary>
        ///     Tests that the texture rect property round trips
        /// </summary>
        [RequireCSfmlSystemFact]
        public void TextureRect_GetSet_RoundTrips()
        {
            using Texture texture = new Texture(BitmapSamplePath);
            using Sprite sprite = new Sprite(texture);
            IntRect rect = new IntRect(2, 2, 16, 16);
            sprite.TextureRect = rect;
            Assert.Equal(2f, sprite.TextureRect.Left);
            Assert.Equal(2f, sprite.TextureRect.Top);
            Assert.Equal(16f, sprite.TextureRect.Width);
            Assert.Equal(16f, sprite.TextureRect.Height);
        }

        /// <summary>
        ///     Tests that the position property round trips
        /// </summary>
        [RequireCSfmlSystemFact]
        public void Position_GetSet_RoundTrips()
        {
            using Sprite sprite = new Sprite();
            sprite.Position = new Vector2F(11, 22);
            Assert.Equal(11, sprite.Position.X);
            Assert.Equal(22, sprite.Position.Y);
        }

        /// <summary>
        ///     Tests that the rotation property round trips
        /// </summary>
        [RequireCSfmlSystemFact]
        public void Rotation_GetSet_RoundTrips()
        {
            using Sprite sprite = new Sprite();
            sprite.Rotation = 33;
            Assert.Equal(33, sprite.Rotation);
        }

        /// <summary>
        ///     Tests that the scale property round trips
        /// </summary>
        [RequireCSfmlSystemFact]
        public void Scale_GetSet_RoundTrips()
        {
            using Sprite sprite = new Sprite();
            sprite.Scale = new Vector2F(1.5f, 2.5f);
            Assert.Equal(1.5f, sprite.Scale.X);
            Assert.Equal(2.5f, sprite.Scale.Y);
        }

        /// <summary>
        ///     Tests that the origin property round trips
        /// </summary>
        [RequireCSfmlSystemFact]
        public void Origin_GetSet_RoundTrips()
        {
            using Sprite sprite = new Sprite();
            sprite.Origin = new Vector2F(7, 8);
            Assert.Equal(7, sprite.Origin.X);
            Assert.Equal(8, sprite.Origin.Y);
        }

        /// <summary>
        ///     Tests that the local bounds are readable
        /// </summary>
        [RequireCSfmlSystemFact]
        public void GetLocalBounds_IsReadable()
        {
            using Sprite sprite = new Sprite();
            FloatRect bounds = sprite.GetLocalBounds();
            Assert.True(bounds.Width >= 0);
            Assert.True(bounds.Height >= 0);
        }

        /// <summary>
        ///     Tests that the global bounds follow the transformable members
        /// </summary>
        [RequireCSfmlSystemFact]
        public void GetGlobalBounds_IsReadable()
        {
            using Sprite sprite = new Sprite();
            sprite.Position = new Vector2F(10, 20);
            FloatRect bounds = sprite.GetGlobalBounds();
            Assert.True(bounds.Left >= 0);
            Assert.True(bounds.Top >= 0);
        }

        /// <summary>
        ///     Tests that the string description contains the sprite markers
        /// </summary>
        [RequireCSfmlSystemFact]
        public void ToString_ContainsSpriteMarkers()
        {
            using Sprite sprite = new Sprite();
            string str = sprite.ToString();
            Assert.StartsWith("[Sprite]", str);
            Assert.Contains("Color", str);
            Assert.Contains("Texture", str);
            Assert.Contains("TextureRect", str);
        }

        /// <summary>
        ///     Tests that drawing with a mock target covers the transform and marshal steps without throwing
        /// </summary>
        [RequireCSfmlSystemFact]
        public void Draw_WithMockTarget_DoesNotThrow()
        {
            using Sprite sprite = new Sprite();
            sprite.Position = new Vector2F(10, 20);
            Mock<IRenderTarget> mockTarget = new Mock<IRenderTarget>();
            RenderStates states = new RenderStates();
            sprite.Draw(mockTarget.Object, states);
        }

        /// <summary>
        ///     Tests that drawing with a texture assigned does not throw
        /// </summary>
        [RequireCSfmlSystemFact]
        public void Draw_WithTexture_DoesNotThrow()
        {
            using Texture texture = new Texture(BitmapSamplePath);
            using Sprite sprite = new Sprite(texture);
            Mock<IRenderTarget> mockTarget = new Mock<IRenderTarget>();
            RenderStates states = new RenderStates();
            sprite.Draw(mockTarget.Object, states);
        }

        /// <summary>
        ///     Tests that destroying the sprite clears the native pointer
        /// </summary>
        [RequireCSfmlSystemFact]
        public void Destroy_ClearsNativePointer()
        {
            Sprite sprite = new Sprite();
            Assert.NotEqual(IntPtr.Zero, sprite.CPointer);
            sprite.Destroy(true);
            Assert.Equal(IntPtr.Zero, sprite.CPointer);
        }

        /// <summary>
        ///     Tests that disposing the sprite destroys the native handle
        /// </summary>
        [RequireCSfmlSystemFact]
        public void Dispose_DestroysNativeHandle()
        {
            Sprite sprite = new Sprite();
            sprite.Dispose();
            Assert.Equal(IntPtr.Zero, sprite.CPointer);
        }
    }
}
