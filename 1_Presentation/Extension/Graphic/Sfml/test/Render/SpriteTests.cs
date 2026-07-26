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

using System;
using Alis.Extension.Graphic.Sfml.Render;
using Xunit;

namespace Alis.Extension.Graphic.Sfml.Test.Render
{
    public class SpriteTests
    {
        [Fact]
        public void Sprite_IsAssignableFromTransformable()
        {
            Assert.True(typeof(Transformable).IsAssignableFrom(typeof(Sprite)));
        }

        [Fact]
        public void Sprite_ImplementsIDrawable()
        {
            Assert.True(typeof(IDrawable).IsAssignableFrom(typeof(Sprite)));
        }

        [Fact]
        public void Sprite_IsIDisposable()
        {
            Assert.True(typeof(IDisposable).IsAssignableFrom(typeof(Sprite)));
        }

        [Fact]
        public void Constructor_Default_Exists()
        {
            Assert.NotNull(typeof(Sprite).GetConstructor(Type.EmptyTypes));
        }

        [Fact]
        public void Constructor_Texture_Exists()
        {
            Assert.NotNull(typeof(Sprite).GetConstructor(new[] { typeof(Texture) }));
        }

        [Fact]
        public void Constructor_TextureAndIntRect_Exists()
        {
            Assert.NotNull(typeof(Sprite).GetConstructor(new[] { typeof(Texture), typeof(IntRect) }));
        }

        [Fact]
        public void Constructor_Copy_Exists()
        {
            Assert.NotNull(typeof(Sprite).GetConstructor(new[] { typeof(Sprite) }));
        }

        [Fact]
        public void Color_Property_Exists()
        {
            Assert.NotNull(typeof(Sprite).GetProperty("Color"));
        }

        [Fact]
        public void Color_Property_IsReadWrite()
        {
            var prop = typeof(Sprite).GetProperty("Color");
            Assert.NotNull(prop);
            Assert.True(prop.CanRead);
            Assert.True(prop.CanWrite);
        }

        [Fact]
        public void Texture_Property_Exists()
        {
            Assert.NotNull(typeof(Sprite).GetProperty("Texture"));
        }

        [Fact]
        public void Texture_Property_IsReadWrite()
        {
            var prop = typeof(Sprite).GetProperty("Texture");
            Assert.NotNull(prop);
            Assert.True(prop.CanRead);
            Assert.True(prop.CanWrite);
        }

        [Fact]
        public void TextureRect_Property_Exists()
        {
            Assert.NotNull(typeof(Sprite).GetProperty("TextureRect"));
        }

        [Fact]
        public void TextureRect_Property_IsReadWrite()
        {
            var prop = typeof(Sprite).GetProperty("TextureRect");
            Assert.NotNull(prop);
            Assert.True(prop.CanRead);
            Assert.True(prop.CanWrite);
        }

        [Fact]
        public void Draw_Method_Exists()
        {
            Assert.NotNull(typeof(Sprite).GetMethod("Draw", new[] { typeof(IRenderTarget), typeof(RenderStates) }));
        }

        [Fact]
        public void GetLocalBounds_Method_Exists()
        {
            Assert.NotNull(typeof(Sprite).GetMethod("GetLocalBounds"));
        }

        [Fact]
        public void GetGlobalBounds_Method_Exists()
        {
            Assert.NotNull(typeof(Sprite).GetMethod("GetGlobalBounds"));
        }

        [Fact]
        public void ToString_Method_Exists()
        {
            Assert.NotNull(typeof(Sprite).GetMethod("ToString"));
        }

        [Fact]
        public void Destroy_Method_Exists()
        {
            Assert.NotNull(typeof(Sprite).GetMethod("Destroy"));
        }

        [Fact]
        public void ToString_IsOverride()
        {
            var method = typeof(Sprite).GetMethod("ToString");
            Assert.NotNull(method);
            Assert.True(method.IsVirtual);
            Assert.NotEqual(method.GetBaseDefinition(), method);
        }

        [Fact]
        public void Destroy_IsOverride()
        {
            var method = typeof(Sprite).GetMethod("Destroy");
            Assert.NotNull(method);
            Assert.True(method.IsVirtual);
            Assert.NotEqual(method.GetBaseDefinition(), method);
        }

        [Fact]
        public void Sprite_HasPublicParameterlessConstructor()
        {
            var ctor = typeof(Sprite).GetConstructor(Type.EmptyTypes);
            Assert.NotNull(ctor);
            Assert.True(ctor.IsPublic);
        }

        [Fact]
        public void GetLocalBounds_ReturnsFloatRect()
        {
            var method = typeof(Sprite).GetMethod("GetLocalBounds");
            Assert.NotNull(method);
            Assert.Equal(typeof(FloatRect), method.ReturnType);
        }

        [Fact]
        public void GetGlobalBounds_ReturnsFloatRect()
        {
            var method = typeof(Sprite).GetMethod("GetGlobalBounds");
            Assert.NotNull(method);
            Assert.Equal(typeof(FloatRect), method.ReturnType);
        }

        [Fact]
        public void Color_Property_TypeIsColor()
        {
            var prop = typeof(Sprite).GetProperty("Color");
            Assert.NotNull(prop);
            Assert.Equal(typeof(Color), prop.PropertyType);
        }

        [Fact]
        public void Texture_Property_TypeIsTexture()
        {
            var prop = typeof(Sprite).GetProperty("Texture");
            Assert.NotNull(prop);
            Assert.Equal(typeof(Texture), prop.PropertyType);
        }

        [Fact]
        public void TextureRect_Property_TypeIsIntRect()
        {
            var prop = typeof(Sprite).GetProperty("TextureRect");
            Assert.NotNull(prop);
            Assert.Equal(typeof(IntRect), prop.PropertyType);
        }
    }
}
