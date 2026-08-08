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
using System.Reflection;
using Alis.Extension.Graphic.Sfml.Render;
using Alis.Extension.Graphic.Sfml.Test.Attributes;
using Xunit;

namespace Alis.Extension.Graphic.Sfml.Test.Render
{
    /// <summary>
    /// The sprite tests class
    /// </summary>
    public class SpriteTests
    {
        /// <summary>
        /// Tests that sprite is assignable from transformable
        /// </summary>
        [RequireCSfmlSystemFact]
        public void Sprite_IsAssignableFromTransformable()
        {
            Assert.True(typeof(Transformable).IsAssignableFrom(typeof(Sprite)));
        }

        /// <summary>
        /// Tests that sprite implements i drawable
        /// </summary>
        [RequireCSfmlSystemFact]
        public void Sprite_ImplementsIDrawable()
        {
            Assert.True(typeof(IDrawable).IsAssignableFrom(typeof(Sprite)));
        }

        /// <summary>
        /// Tests that sprite is i disposable
        /// </summary>
        [RequireCSfmlSystemFact]
        public void Sprite_IsIDisposable()
        {
            Assert.True(typeof(IDisposable).IsAssignableFrom(typeof(Sprite)));
        }

        /// <summary>
        /// Tests that constructor default exists
        /// </summary>
        [RequireCSfmlSystemFact]
        public void Constructor_Default_Exists()
        {
            Assert.NotNull(typeof(Sprite).GetConstructor(Type.EmptyTypes));
        }

        /// <summary>
        /// Tests that constructor texture exists
        /// </summary>
        [RequireCSfmlSystemFact]
        public void Constructor_Texture_Exists()
        {
            Assert.NotNull(typeof(Sprite).GetConstructor(new[] { typeof(Texture) }));
        }

        /// <summary>
        /// Tests that constructor texture and int rect exists
        /// </summary>
        [RequireCSfmlSystemFact]
        public void Constructor_TextureAndIntRect_Exists()
        {
            Assert.NotNull(typeof(Sprite).GetConstructor(new[] { typeof(Texture), typeof(IntRect) }));
        }

        /// <summary>
        /// Tests that constructor copy exists
        /// </summary>
        [RequireCSfmlSystemFact]
        public void Constructor_Copy_Exists()
        {
            Assert.NotNull(typeof(Sprite).GetConstructor(new[] { typeof(Sprite) }));
        }

        /// <summary>
        /// Tests that color property exists
        /// </summary>
        [RequireCSfmlSystemFact]
        public void Color_Property_Exists()
        {
            Assert.NotNull(typeof(Sprite).GetProperty("Color"));
        }

        /// <summary>
        /// Tests that color property is read write
        /// </summary>
        [RequireCSfmlSystemFact]
        public void Color_Property_IsReadWrite()
        {
            PropertyInfo prop = typeof(Sprite).GetProperty("Color");
            Assert.NotNull(prop);
            Assert.True(prop.CanRead);
            Assert.True(prop.CanWrite);
        }

        /// <summary>
        /// Tests that texture property exists
        /// </summary>
        [RequireCSfmlSystemFact]
        public void Texture_Property_Exists()
        {
            Assert.NotNull(typeof(Sprite).GetProperty("Texture"));
        }

        /// <summary>
        /// Tests that texture property is read write
        /// </summary>
        [RequireCSfmlSystemFact]
        public void Texture_Property_IsReadWrite()
        {
            PropertyInfo prop = typeof(Sprite).GetProperty("Texture");
            Assert.NotNull(prop);
            Assert.True(prop.CanRead);
            Assert.True(prop.CanWrite);
        }

        /// <summary>
        /// Tests that texture rect property exists
        /// </summary>
        [RequireCSfmlSystemFact]
        public void TextureRect_Property_Exists()
        {
            Assert.NotNull(typeof(Sprite).GetProperty("TextureRect"));
        }

        /// <summary>
        /// Tests that texture rect property is read write
        /// </summary>
        [RequireCSfmlSystemFact]
        public void TextureRect_Property_IsReadWrite()
        {
            PropertyInfo prop = typeof(Sprite).GetProperty("TextureRect");
            Assert.NotNull(prop);
            Assert.True(prop.CanRead);
            Assert.True(prop.CanWrite);
        }

        /// <summary>
        /// Tests that draw method exists
        /// </summary>
        [RequireCSfmlSystemFact]
        public void Draw_Method_Exists()
        {
            Assert.NotNull(typeof(Sprite).GetMethod("Draw", new[] { typeof(IRenderTarget), typeof(RenderStates) }));
        }

        /// <summary>
        /// Tests that get local bounds method exists
        /// </summary>
        [RequireCSfmlSystemFact]
        public void GetLocalBounds_Method_Exists()
        {
            Assert.NotNull(typeof(Sprite).GetMethod("GetLocalBounds"));
        }

        /// <summary>
        /// Tests that get global bounds method exists
        /// </summary>
        [RequireCSfmlSystemFact]
        public void GetGlobalBounds_Method_Exists()
        {
            Assert.NotNull(typeof(Sprite).GetMethod("GetGlobalBounds"));
        }

        /// <summary>
        /// Tests that to string method exists
        /// </summary>
        [RequireCSfmlSystemFact]
        public void ToString_Method_Exists()
        {
            Assert.NotNull(typeof(Sprite).GetMethod("ToString"));
        }

        /// <summary>
        /// Tests that destroy method exists
        /// </summary>
        [RequireCSfmlSystemFact]
        public void Destroy_Method_Exists()
        {
            Assert.NotNull(typeof(Sprite).GetMethod("Destroy"));
        }

        /// <summary>
        /// Tests that to string is override
        /// </summary>
        [RequireCSfmlSystemFact]
        public void ToString_IsOverride()
        {
            MethodInfo method = typeof(Sprite).GetMethod("ToString");
            Assert.NotNull(method);
            Assert.True(method.IsVirtual);
            Assert.NotEqual(method.GetBaseDefinition(), method);
        }

        /// <summary>
        /// Tests that destroy is override
        /// </summary>
        [RequireCSfmlSystemFact]
        public void Destroy_IsOverride()
        {
            MethodInfo method = typeof(Sprite).GetMethod("Destroy");
            Assert.NotNull(method);
            Assert.True(method.IsVirtual);
            Assert.NotEqual(method.GetBaseDefinition(), method);
        }

        /// <summary>
        /// Tests that sprite has public parameterless constructor
        /// </summary>
        [RequireCSfmlSystemFact]
        public void Sprite_HasPublicParameterlessConstructor()
        {
            ConstructorInfo ctor = typeof(Sprite).GetConstructor(Type.EmptyTypes);
            Assert.NotNull(ctor);
            Assert.True(ctor.IsPublic);
        }

        /// <summary>
        /// Tests that get local bounds returns float rect
        /// </summary>
        [RequireCSfmlSystemFact]
        public void GetLocalBounds_ReturnsFloatRect()
        {
            MethodInfo method = typeof(Sprite).GetMethod("GetLocalBounds");
            Assert.NotNull(method);
            Assert.Equal(typeof(FloatRect), method.ReturnType);
        }

        /// <summary>
        /// Tests that get global bounds returns float rect
        /// </summary>
        [RequireCSfmlSystemFact]
        public void GetGlobalBounds_ReturnsFloatRect()
        {
            MethodInfo method = typeof(Sprite).GetMethod("GetGlobalBounds");
            Assert.NotNull(method);
            Assert.Equal(typeof(FloatRect), method.ReturnType);
        }

        /// <summary>
        /// Tests that color property type is color
        /// </summary>
        [RequireCSfmlSystemFact]
        public void Color_Property_TypeIsColor()
        {
            PropertyInfo prop = typeof(Sprite).GetProperty("Color");
            Assert.NotNull(prop);
            Assert.Equal(typeof(Color), prop.PropertyType);
        }

        /// <summary>
        /// Tests that texture property type is texture
        /// </summary>
        [RequireCSfmlSystemFact]
        public void Texture_Property_TypeIsTexture()
        {
            PropertyInfo prop = typeof(Sprite).GetProperty("Texture");
            Assert.NotNull(prop);
            Assert.Equal(typeof(Texture), prop.PropertyType);
        }

        /// <summary>
        /// Tests that texture rect property type is int rect
        /// </summary>
        [RequireCSfmlSystemFact]
        public void TextureRect_Property_TypeIsIntRect()
        {
            PropertyInfo prop = typeof(Sprite).GetProperty("TextureRect");
            Assert.NotNull(prop);
            Assert.Equal(typeof(IntRect), prop.PropertyType);
        }
    }
}
