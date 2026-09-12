// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:SpriteCoverageTests.cs
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
using Xunit;

namespace Alis.Extension.Graphic.Sfml.Test.Render
{
    /// <summary>
    ///     Behavioral coverage tests for the <see cref="Alis.Extension.Graphic.Sfml.Render.Sprite" /> wrapper. Every test
    ///     executes against the real native CSFML library and asserts observable state: native pointer validity, property
    ///     round-trips, bounds computed from the native sprite, the copy constructor semantics and the dispose lifecycle.
    ///     The SFML context is required because the sprite is backed by native <c>sfSprite_*</c> entry points.
    /// </summary>
    public class SpriteCoverageTests
    {
        /// <summary>
        ///     Resolves the path of a bundled asset for loading textures.
        /// </summary>
        /// <param name="name">The asset file name.</param>
        /// <returns>The absolute path of the asset.</returns>
        private static string AssetPath(string name)
        {
            string assemblyDir = Path.GetDirectoryName(typeof(SpriteCoverageTests).Assembly.Location);
            return Path.Combine(assemblyDir, "..", "..", "..", "Assets", name);
        }

        /// <summary>
        ///     Creates a real native texture from the bundled asset.
        /// </summary>
        /// <returns>A live texture backed by the native library.</returns>
        private static Texture CreateTexture()
        {
            Texture texture = new Texture(AssetPath("tile000.bmp"));
            Assert.NotEqual(IntPtr.Zero, texture.CPointer);
            return texture;
        }

        /// <summary>
        /// Tests that the default constructor creates a valid native sprite
        /// </summary>
        [RequireCSfmlGraphicsFact]
        public void Constructor_Default_CreatesValidNativeSprite()
        {
            using Sprite sprite = new Sprite();
            Assert.NotEqual(IntPtr.Zero, sprite.CPointer);
            Assert.Null(sprite.Texture);
        }

        /// <summary>
        /// Tests that the texture constructor assigns the provided texture
        /// </summary>
        [RequireCSfmlGraphicsFact]
        public void Constructor_WithTexture_AssignsTexture()
        {
            using Texture texture = CreateTexture();
            using Sprite sprite = new Sprite(texture);
            Assert.NotEqual(IntPtr.Zero, sprite.CPointer);
            Assert.Same(texture, sprite.Texture);
        }

        /// <summary>
        /// Tests that the texture and rectangle constructor applies the texture rectangle
        /// </summary>
        [RequireCSfmlGraphicsFact]
        public void Constructor_WithTextureAndRectangle_AppliesTextureRect()
        {
            using Texture texture = CreateTexture();
            using Sprite sprite = new Sprite(texture, new IntRect(2, 3, 8, 9));
            Assert.NotEqual(IntPtr.Zero, sprite.CPointer);
            Assert.Same(texture, sprite.Texture);
            Assert.Equal(new IntRect(2, 3, 8, 9), sprite.TextureRect);
        }

        /// <summary>
        /// Tests that the copy constructor duplicates the transform and texture of the source sprite
        /// </summary>
        [RequireCSfmlGraphicsFact]
        public void Constructor_Copy_CopiesTransformAndTexture()
        {
            using Texture texture = CreateTexture();
            using Sprite source = new Sprite(texture);
            source.Position = new Vector2F(10.0f, 20.0f);
            source.Rotation = 45.0f;
            source.Scale = new Vector2F(2.0f, 3.0f);
            source.Origin = new Vector2F(4.0f, 5.0f);

            using Sprite copy = new Sprite(source);
            Assert.NotEqual(IntPtr.Zero, copy.CPointer);
            Assert.NotEqual(source.CPointer, copy.CPointer);
            Assert.Equal(source.Position, copy.Position);
            Assert.Equal(source.Rotation, copy.Rotation);
            Assert.Equal(source.Scale, copy.Scale);
            Assert.Equal(source.Origin, copy.Origin);
            Assert.Same(texture, copy.Texture);
        }

        /// <summary>
        /// Tests that the color property round-trips through the native sprite
        /// </summary>
        [RequireCSfmlGraphicsFact]
        public void Color_SetThenGet_RoundTripsValue()
        {
            using Sprite sprite = new Sprite();
            Color color = new Color(10, 20, 30, 40);
            sprite.Color = color;
            Color result = sprite.Color;
            Assert.Equal(color.R, result.R);
            Assert.Equal(color.G, result.G);
            Assert.Equal(color.B, result.B);
            Assert.Equal(color.A, result.A);
        }

        /// <summary>
        /// Tests that setting a null texture stores null and clears the native texture
        /// </summary>
        [RequireCSfmlGraphicsFact]
        public void Texture_SetNull_StoresNullAndClearsNativeTexture()
        {
            using Texture texture = CreateTexture();
            using Sprite sprite = new Sprite(texture);
            Assert.Same(texture, sprite.Texture);

            sprite.Texture = null;
            Assert.Null(sprite.Texture);
        }

        /// <summary>
        /// Tests that setting a texture stores it and reports the same instance
        /// </summary>
        [RequireCSfmlGraphicsFact]
        public void Texture_SetAfterNull_StoresNewTexture()
        {
            using Texture texture = CreateTexture();
            using Sprite sprite = new Sprite();
            sprite.Texture = null;
            sprite.Texture = texture;
            Assert.Same(texture, sprite.Texture);
        }

        /// <summary>
        /// Tests that the texture rectangle property round-trips through the native sprite
        /// </summary>
        [RequireCSfmlGraphicsFact]
        public void TextureRect_SetThenGet_RoundTripsValue()
        {
            using Sprite sprite = new Sprite();
            sprite.TextureRect = new IntRect(1, 2, 30, 40);
            Assert.Equal(new IntRect(1, 2, 30, 40), sprite.TextureRect);
        }

        /// <summary>
        /// Tests that the local bounds of a sprite without a texture are empty
        /// </summary>
        [RequireCSfmlGraphicsFact]
        public void GetLocalBounds_WithoutTexture_ReturnsEmptyRect()
        {
            using Sprite sprite = new Sprite();
            FloatRect bounds = sprite.GetLocalBounds();
            Assert.Equal(0.0f, bounds.Width);
            Assert.Equal(0.0f, bounds.Height);
        }

        /// <summary>
        /// Tests that the local bounds of a textured sprite match the texture size
        /// </summary>
        [RequireCSfmlGraphicsFact]
        public void GetLocalBounds_WithTexture_ReturnsTextureSize()
        {
            using Texture texture = CreateTexture();
            using Sprite sprite = new Sprite(texture);
            FloatRect bounds = sprite.GetLocalBounds();
            Assert.Equal(texture.Size.X, (uint) bounds.Width);
            Assert.Equal(texture.Size.Y, (uint) bounds.Height);
        }

        /// <summary>
        /// Tests that the global bounds apply the sprite transform to the local bounds
        /// </summary>
        [RequireCSfmlGraphicsFact]
        public void GetGlobalBounds_WithScale_AppliesTransformToLocalBounds()
        {
            using Texture texture = CreateTexture();
            using Sprite sprite = new Sprite(texture);
            sprite.Scale = new Vector2F(2.0f, 2.0f);

            FloatRect local = sprite.GetLocalBounds();
            FloatRect global = sprite.GetGlobalBounds();
            Assert.Equal(local.Width * 2.0f, global.Width);
            Assert.Equal(local.Height * 2.0f, global.Height);
        }

        /// <summary>
        /// Tests that the global bounds include the sprite position
        /// </summary>
        [RequireCSfmlGraphicsFact]
        public void GetGlobalBounds_WithPosition_IncludesPosition()
        {
            using Texture texture = CreateTexture();
            using Sprite sprite = new Sprite(texture);
            sprite.Position = new Vector2F(100.0f, 200.0f);

            FloatRect global = sprite.GetGlobalBounds();
            Assert.Equal(100.0f, global.Left);
            Assert.Equal(200.0f, global.Top);
        }

        /// <summary>
        /// Tests that ToString describes color, texture and texture rectangle
        /// </summary>
        [RequireCSfmlGraphicsFact]
        public void ToString_WithTextureAndRect_DescribesState()
        {
            using Texture texture = CreateTexture();
            using Sprite sprite = new Sprite(texture, new IntRect(1, 2, 3, 4));
            sprite.Color = new Color(10, 20, 30, 40);

            string text = sprite.ToString();
            Assert.Contains("[Sprite]", text);
            Assert.Contains("[Color] R(10) G(20) B(30) A(40)", text);
            Assert.Contains("[IntRect] Left(1) Top(2) Width(3) Height(4)", text);
            Assert.Contains("[Texture]", text);
        }

        /// <summary>
        /// Tests that ToString on a sprite without a texture mentions no texture
        /// </summary>
        [RequireCSfmlGraphicsFact]
        public void ToString_WithoutTexture_DescribesEmptyState()
        {
            using Sprite sprite = new Sprite();
            string text = sprite.ToString();
            Assert.StartsWith("[Sprite]", text);
            Assert.Contains("()", text);
        }

        /// <summary>
        /// Tests that drawing to a stub render target marshals the render states without throwing
        /// </summary>
        [RequireCSfmlGraphicsFact]
        public void Draw_StubTarget_DoesNotThrow()
        {
            using Sprite sprite = new Sprite();
            sprite.Position = new Vector2F(5.0f, 6.0f);
            StubRenderTarget target = new StubRenderTarget();
            Exception result = Record.Exception(() => sprite.Draw(target, new RenderStates()));
            Assert.Null(result);
        }

        /// <summary>
        /// Tests that drawing to a live render window executes the native draw call
        /// </summary>
        [RequireCSfmlGraphicsFact]
        public void Draw_RenderWindow_ExecutesNativeDraw()
        {
            if (!SfmlTestBootstrap.Ready)
            {
                return;
            }

            using Texture texture = CreateTexture();
            using Sprite sprite = new Sprite(texture);
            sprite.Position = new Vector2F(10.0f, 10.0f);
            RenderWindow window = SfmlTestBootstrap.Window;
            Exception result = Record.Exception(() => window.Draw(sprite));
            Assert.Null(result);
        }

        /// <summary>
        /// Tests that drawing with explicit render states to the live render window works
        /// </summary>
        [RequireCSfmlGraphicsFact]
        public void Draw_RenderWindowWithStates_ExecutesNativeDraw()
        {
            if (!SfmlTestBootstrap.Ready)
            {
                return;
            }

            using Texture texture = CreateTexture();
            using Sprite sprite = new Sprite(texture);
            RenderWindow window = SfmlTestBootstrap.Window;
            RenderStates states = new RenderStates(new Transform(1.0f, 0.0f, 0.0f, 0.0f, 1.0f, 0.0f, 0.0f, 0.0f, 1.0f));
            Exception result = Record.Exception(() => sprite.Draw(window, states));
            Assert.Null(result);
        }

        /// <summary>
        /// Tests that disposing the sprite releases the native handle
        /// </summary>
        [RequireCSfmlGraphicsFact]
        public void Dispose_WhenCalled_DestroysNativeSprite()
        {
            Sprite sprite = new Sprite();
            Assert.NotEqual(IntPtr.Zero, sprite.CPointer);
            sprite.Dispose();
            Assert.Equal(IntPtr.Zero, sprite.CPointer);
        }

        /// <summary>
        /// Tests that the sprite finalizer runs without leaking the native handle
        /// </summary>
        [RequireCSfmlGraphicsFact]
        public void Finalizer_WhenCollected_RunsWithoutException()
        {
            CreateDroppedSprite();
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }

        /// <summary>
        /// Creates a sprite that is immediately unreachable.
        /// </summary>
        private static void CreateDroppedSprite()
        {
            Sprite sprite = new Sprite();
            Assert.NotEqual(IntPtr.Zero, sprite.CPointer);
        }

        /// <summary>
        ///     Stub render target that is neither a window nor a render texture; drawing to it only
        ///     exercises managed state marshaling before the native dispatch switch.
        /// </summary>
        private sealed class StubRenderTarget : IRenderTarget
        {
            /// <inheritdoc />
            public Vector2F Size => default;

            /// <inheritdoc />
            public View DefaultView => null;

            /// <inheritdoc />
            public View GetView() => null;

            /// <inheritdoc />
            public void SetView(View view)
            {
            }

            /// <inheritdoc />
            public IntRect GetViewport(View view) => default;

            /// <inheritdoc />
            public Vector2F MapPixelToCoords(Vector2F point) => default;

            /// <inheritdoc />
            public Vector2F MapPixelToCoords(Vector2F point, View view) => default;

            /// <inheritdoc />
            public Vector2F MapCoordsToPixel(Vector2F point) => default;

            /// <inheritdoc />
            public Vector2F MapCoordsToPixel(Vector2F point, View view) => default;

            /// <inheritdoc />
            public void Clear()
            {
            }

            /// <inheritdoc />
            public void Clear(Color color)
            {
            }

            /// <inheritdoc />
            public void Draw(IDrawable drawable)
            {
            }

            /// <inheritdoc />
            public void Draw(IDrawable drawable, RenderStates states)
            {
            }

            /// <inheritdoc />
            public void Draw(Vertex[] vertices, PrimitiveType type)
            {
            }

            /// <inheritdoc />
            public void Draw(Vertex[] vertices, PrimitiveType type, RenderStates states)
            {
            }

            /// <inheritdoc />
            public void Draw(Vertex[] vertices, uint start, uint count, PrimitiveType type)
            {
            }

            /// <inheritdoc />
            public void Draw(Vertex[] vertices, uint start, uint count, PrimitiveType type, RenderStates states)
            {
            }

            /// <inheritdoc />
            public void PushGlStates()
            {
            }

            /// <inheritdoc />
            public void PopGlStates()
            {
            }

            /// <inheritdoc />
            public void ResetGlStates()
            {
            }
        }
    }
}
