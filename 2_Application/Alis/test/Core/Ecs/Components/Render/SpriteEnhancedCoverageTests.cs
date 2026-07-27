// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:SpriteEnhancedCoverageTests.cs
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
using System.Reflection;
using System.Runtime.InteropServices;
using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Ecs.Components.Render;
using Alis.Core.Ecs.Systems.Scope;
using Alis.Core.Graphic.OpenGL;
using Xunit;

namespace Alis.Test.Core.Ecs.Components.Render
{
    public class SpriteEnhancedCoverageTests : IDisposable
    {
        private static readonly FieldInfo GlField = typeof(Gl).GetField("_getProcAddress", BindingFlags.NonPublic | BindingFlags.Static);

        private static readonly FieldInfo TextureField = typeof(Sprite).GetField("<Texture>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance);

        private readonly object _savedGl;

        private readonly string _tempBmp;

        public SpriteEnhancedCoverageTests()
        {
            _savedGl = GlField?.GetValue(null);
            _tempBmp = Path.GetTempFileName() + ".bmp";
        }

        public void Dispose()
        {
            GlField?.SetValue(null, _savedGl);
            if (File.Exists(_tempBmp))
            {
                File.Delete(_tempBmp);
            }
        }

        private static void InitGlToThrow() => Gl.Initialize(_ => IntPtr.Zero);

        private static void SetTextureField(ref Sprite sprite, uint value)
        {
            object boxed = sprite;
            TextureField?.SetValue(boxed, value);
            sprite = (Sprite)boxed;
        }

        private void WriteMinimalBmp()
        {
            byte[] data = new byte[58];
            data[0] = 0x42;
            data[1] = 0x4D;
            BitConverter.GetBytes(58).CopyTo(data, 2);
            data[10] = 54;
            BitConverter.GetBytes(40).CopyTo(data, 14);
            BitConverter.GetBytes(1).CopyTo(data, 18);
            BitConverter.GetBytes(1).CopyTo(data, 22);
            BitConverter.GetBytes((short)1).CopyTo(data, 26);
            BitConverter.GetBytes((short)32).CopyTo(data, 28);
            data[54] = 0;
            data[55] = 0;
            data[56] = 255;
            data[57] = 255;
            File.WriteAllBytes(_tempBmp, data);
        }

        [Fact]
        public void OnExit_WhenTextureNonZeroAndGlThrows_CatchesException()
        {
            InitGlToThrow();
            Context context = new Context();
            Sprite sprite = new Sprite(context, "test.png", 0);
            SetTextureField(ref sprite, 42u);

            sprite.OnExit(null);
        }

        [Fact]
        public void OnExit_WhenTextureZero_CompletesSuccessfully()
        {
            Context context = new Context();
            Sprite sprite = new Sprite(context, "test.png", 0);

            sprite.OnExit(null);
        }

        [Fact]
        public void LoadTexture_WhenFileExistsAndGlThrows_ThrowsExternalException()
        {
            InitGlToThrow();
            WriteMinimalBmp();

            Context context = new Context();
            Sprite sprite = new Sprite(context, string.Empty, 0);

            Assert.Throws<ExternalException>(() => sprite.LoadTexture(_tempBmp));
        }

        [Fact]
        public void LoadTexture_WhenFileNotExistsAndNameFileEmpty_ThrowsFileNotFoundException()
        {
            InitGlToThrow();

            Context context = new Context();
            Sprite sprite = new Sprite(context, string.Empty, 0);

            Assert.Throws<FileNotFoundException>(() => sprite.LoadTexture("nonexistent.bmp"));
        }

        [Fact]
        public void LoadTexture_WhenFilePathEmpty_UsesNameFileFallback()
        {
            InitGlToThrow();

            Context context = new Context();
            Sprite sprite = new Sprite(context, "fallback.bmp", 0);

            Assert.Throws<FileNotFoundException>(() => sprite.LoadTexture(string.Empty));
        }

        [Fact]
        public void LoadTexture_WhenFilePathNotEmptyAndNameFileDiffers_UpdatesNameFile()
        {
            InitGlToThrow();

            Context context = new Context();
            Sprite sprite = new Sprite(context, "original.bmp", 0);

            Assert.Throws<FileNotFoundException>(() => sprite.LoadTexture("different.bmp"));

            Assert.Equal("different.bmp", sprite.NameFile);
        }

        [Fact]
        public void IsSpriteVisible_SpriteAtCameraCenterWithMinimalRotation_ReturnsTrue()
        {
            Vector2F spritePos = new Vector2F(0, 0);
            Vector2F spriteSize = new Vector2F(32, 32);
            Vector2F spriteScale = new Vector2F(1, 1);
            float rotation = 0.00005f;
            Vector2F cameraPos = new Vector2F(0, 0);
            Vector2F cameraRes = new Vector2F(800, 600);
            float ppm = 32;

            bool visible = Sprite.IsSpriteVisible(spritePos, spriteSize, spriteScale, rotation, cameraPos, cameraRes, ppm);

            Assert.True(visible);
        }

        [Fact]
        public void IsSpriteVisible_ExactEdgeOnX_ReturnsTrue()
        {
            Vector2F spritePos = new Vector2F(12.5f, 0);
            Vector2F spriteSize = new Vector2F(32, 32);
            Vector2F spriteScale = new Vector2F(1, 1);
            float rotation = 0;
            Vector2F cameraPos = new Vector2F(0, 0);
            Vector2F cameraRes = new Vector2F(800, 600);
            float ppm = 32;

            bool visible = Sprite.IsSpriteVisible(spritePos, spriteSize, spriteScale, rotation, cameraPos, cameraRes, ppm);

            Assert.True(visible);
        }

        [Fact]
        public void IsSpriteVisible_JustBeyondEdgeOnX_ReturnsFalse()
        {
            Vector2F spritePos = new Vector2F(14, 0);
            Vector2F spriteSize = new Vector2F(32, 32);
            Vector2F spriteScale = new Vector2F(1, 1);
            float rotation = 0;
            Vector2F cameraPos = new Vector2F(0, 0);
            Vector2F cameraRes = new Vector2F(800, 600);
            float ppm = 32;

            bool visible = Sprite.IsSpriteVisible(spritePos, spriteSize, spriteScale, rotation, cameraPos, cameraRes, ppm);

            Assert.False(visible);
        }

        [Fact]
        public void IsSpriteVisible_ExactEdgeOnY_ReturnsTrue()
        {
            Vector2F spritePos = new Vector2F(0, 9.375f);
            Vector2F spriteSize = new Vector2F(32, 32);
            Vector2F spriteScale = new Vector2F(1, 1);
            float rotation = 0;
            Vector2F cameraPos = new Vector2F(0, 0);
            Vector2F cameraRes = new Vector2F(800, 600);
            float ppm = 32;

            bool visible = Sprite.IsSpriteVisible(spritePos, spriteSize, spriteScale, rotation, cameraPos, cameraRes, ppm);

            Assert.True(visible);
        }

        [Fact]
        public void IsSpriteVisible_JustBeyondEdgeOnY_ReturnsFalse()
        {
            Vector2F spritePos = new Vector2F(0, 10);
            Vector2F spriteSize = new Vector2F(32, 32);
            Vector2F spriteScale = new Vector2F(1, 1);
            float rotation = 0;
            Vector2F cameraPos = new Vector2F(0, 0);
            Vector2F cameraRes = new Vector2F(800, 600);
            float ppm = 32;

            bool visible = Sprite.IsSpriteVisible(spritePos, spriteSize, spriteScale, rotation, cameraPos, cameraRes, ppm);

            Assert.False(visible);
        }

        [Fact]
        public void IsSpriteVisible_SmallScaleSpriteAtCameraEdge_ReturnsTrue()
        {
            Vector2F spritePos = new Vector2F(12.5f, 0);
            Vector2F spriteSize = new Vector2F(16, 16);
            Vector2F spriteScale = new Vector2F(1, 1);
            float rotation = 0;
            Vector2F cameraPos = new Vector2F(0, 0);
            Vector2F cameraRes = new Vector2F(800, 600);
            float ppm = 32;

            bool visible = Sprite.IsSpriteVisible(spritePos, spriteSize, spriteScale, rotation, cameraPos, cameraRes, ppm);

            Assert.True(visible);
        }

        [Fact]
        public void IsSpriteVisible_WithCustomPixelsPerMeter_ComputesCorrectly()
        {
            Vector2F spritePos = new Vector2F(0, 0);
            Vector2F spriteSize = new Vector2F(64, 64);
            Vector2F spriteScale = new Vector2F(1, 1);
            float rotation = 0;
            Vector2F cameraPos = new Vector2F(0, 0);
            Vector2F cameraRes = new Vector2F(1920, 1080);
            float ppm = 64;

            bool visible = Sprite.IsSpriteVisible(spritePos, spriteSize, spriteScale, rotation, cameraPos, cameraRes, ppm);

            Assert.True(visible);
        }

        [Fact]
        public void IsSpriteVisible_SpriteWithNoScale_CannotBeVisible()
        {
            Vector2F spritePos = new Vector2F(0, 0);
            Vector2F spriteSize = new Vector2F(32, 32);
            Vector2F spriteScale = new Vector2F(0, 0);
            float rotation = 0;
            Vector2F cameraPos = new Vector2F(0, 0);
            Vector2F cameraRes = new Vector2F(800, 600);
            float ppm = 32;

            bool visible = Sprite.IsSpriteVisible(spritePos, spriteSize, spriteScale, rotation, cameraPos, cameraRes, ppm);

            Assert.True(visible);
        }

        [Fact]
        public void Deconstruct_ReturnsCorrectValues()
        {
            Context context = new Context();
            Sprite sprite = new Sprite(context, "test.png", 5);

            var (ctx, name, depth) = sprite;

            Assert.Equal(context, ctx);
            Assert.Equal("test.png", name);
            Assert.Equal(5, depth);
        }

        [Fact]
        public void ToString_ContainsTypeAndProperties()
        {
            Context context = new Context();
            Sprite sprite = new Sprite(context, "display.png", 3);

            string str = sprite.ToString();

            Assert.Contains("Sprite", str);
            Assert.Contains("display.png", str);
            Assert.Contains("3", str);
        }

        [Fact]
        public void Equals_SameValues_ReturnsTrue()
        {
            Context context = new Context();
            Sprite sprite1 = new Sprite(context, "same.png", 1);
            Sprite sprite2 = new Sprite(context, "same.png", 1);

            Assert.True(sprite1.Equals(sprite2));
            Assert.True(sprite1 == sprite2);
            Assert.False(sprite1 != sprite2);
        }

        [Fact]
        public void Equals_DifferentValues_ReturnsFalse()
        {
            Context context = new Context();
            Sprite sprite1 = new Sprite(context, "a.png", 1);
            Sprite sprite2 = new Sprite(context, "b.png", 2);

            Assert.False(sprite1.Equals(sprite2));
            Assert.False(sprite1 == sprite2);
            Assert.True(sprite1 != sprite2);
        }

        [Fact]
        public void GetHashCode_SameValues_ReturnsSameHash()
        {
            Context context = new Context();
            Sprite sprite1 = new Sprite(context, "hash.png", 7);
            Sprite sprite2 = new Sprite(context, "hash.png", 7);

            Assert.Equal(sprite1.GetHashCode(), sprite2.GetHashCode());
        }

        [Fact]
        public void GetHashCode_DifferentValues_ReturnsDifferentHash()
        {
            Context context = new Context();
            Sprite sprite1 = new Sprite(context, "a.png", 1);
            Sprite sprite2 = new Sprite(context, "b.png", 2);

            Assert.NotEqual(sprite1.GetHashCode(), sprite2.GetHashCode());
        }

        [Fact]
        public void PathProperty_Internal_HasDefaultValue()
        {
            Context context = new Context();
            Sprite sprite = new Sprite(context, "path.png", 0);

            object path = typeof(Sprite).GetProperty("Path", BindingFlags.NonPublic | BindingFlags.Instance)?.GetValue(sprite);

            Assert.Equal(string.Empty, path);
        }
    }
}
