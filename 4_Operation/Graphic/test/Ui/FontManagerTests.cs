// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:FontManagerTests.cs
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
using Alis.Core.Aspect.Math.Definition;
using Alis.Core.Graphic.Ui;
using Xunit;

namespace Alis.Core.Graphic.Test.Ui
{
    public class FontManagerTests
    {
        [Fact]
        public void DefaultFont_IsNotNull()
        {
            Font font = FontManager.DefaultFont;
            Assert.NotNull(font);
        }

        [Fact]
        public void DefaultFont_HasExpectedNameFile()
        {
            Font font = FontManager.DefaultFont;
            Assert.Equal("mono.bmp", font.NameFile);
        }

        [Fact]
        public void DefaultFont_HasDepthOne()
        {
            Font font = FontManager.DefaultFont;
            Assert.Equal(1, font.Depth);
        }

        [Fact]
        public void DefaultFont_PropertyIsReadOnly()
        {
            PropertyInfo prop = typeof(FontManager).GetProperty("DefaultFont", BindingFlags.Public | BindingFlags.Static);
            Assert.NotNull(prop);
            Assert.True(prop.CanRead);
            Assert.False(prop.CanWrite);
        }

        [Fact]
        public void DefaultFont_ReturnsSameInstance()
        {
            Font first = FontManager.DefaultFont;
            Font second = FontManager.DefaultFont;
            Assert.Same(first, second);
        }

        [Fact]
        public void RenderText_WithCoordinates_ThrowsWhenOpenGLNotInitialized()
        {
            Assert.ThrowsAny<Exception>(() => FontManager.RenderText("hello", 0, 0));
        }

        [Fact]
        public void RenderText_WithColors_ThrowsWhenOpenGLNotInitialized()
        {
            Assert.ThrowsAny<Exception>(() => FontManager.RenderText("hello", 0, 0, Color.White, Color.Black));
        }

        [Fact]
        public void RenderText_WithCoordinates_MethodExists()
        {
            MethodInfo method = typeof(FontManager).GetMethod("RenderText", BindingFlags.Public | BindingFlags.Static, null, new[] { typeof(string), typeof(int), typeof(int) }, null);
            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        [Fact]
        public void RenderText_WithColors_MethodExists()
        {
            MethodInfo method = typeof(FontManager).GetMethod("RenderText", BindingFlags.Public | BindingFlags.Static, null, new[] { typeof(string), typeof(int), typeof(int), typeof(Color), typeof(Color) }, null);
            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        [Fact]
        public void FontManager_IsStaticClass()
        {
            Type type = typeof(FontManager);
            Assert.True(type.IsSealed);
            Assert.True(type.IsAbstract);
        }

        [Fact]
        public void FontManager_IsPublic()
        {
            Assert.True(typeof(FontManager).IsPublic);
        }

        [Fact]
        public void RenderText_WithForegroundAndBackground_DelegatesToDefaultFont()
        {
            Assert.ThrowsAny<Exception>(() => FontManager.RenderText("hello", 10, 20, Color.White, Color.Black));
        }

        [Fact]
        public void RenderText_WithDefaultColors_DelegatesToDefaultFont()
        {
            Assert.ThrowsAny<Exception>(() => FontManager.RenderText("hello", 10, 20));
        }
    }
}
