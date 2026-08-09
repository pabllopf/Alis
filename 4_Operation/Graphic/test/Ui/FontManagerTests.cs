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
using Alis.Core.Aspect.Math.Definition;
using Alis.Core.Graphic.Ui;
using Xunit;

namespace Alis.Core.Graphic.Test.Ui
{
    /// <summary>
    /// The font manager tests class
    /// </summary>
    public class FontManagerTests
    {
        /// <summary>
        /// Tests that default font is not null
        /// </summary>
        [Fact]
        public void DefaultFont_IsNotNull()
        {
            Font font = FontManager.DefaultFont;
            Assert.NotNull(font);
        }

        /// <summary>
        /// Tests that default font has expected name file
        /// </summary>
        [Fact]
        public void DefaultFont_HasExpectedNameFile()
        {
            Font font = FontManager.DefaultFont;
            Assert.Equal("mono.bmp", font.NameFile);
        }

        /// <summary>
        /// Tests that default font has depth one
        /// </summary>
        [Fact]
        public void DefaultFont_HasDepthOne()
        {
            Font font = FontManager.DefaultFont;
            Assert.Equal(1, font.Depth);
        }

        /// <summary>
        /// Tests that default font returns same instance
        /// </summary>
        [Fact]
        public void DefaultFont_ReturnsSameInstance()
        {
            Font first = FontManager.DefaultFont;
            Font second = FontManager.DefaultFont;
            Assert.Same(first, second);
        }

        /// <summary>
        /// Tests that render text with coordinates throws when open gl not initialized
        /// </summary>
        [Fact]
        public void RenderText_WithCoordinates_ThrowsWhenOpenGLNotInitialized()
        {
            Assert.ThrowsAny<Exception>(() => FontManager.RenderText("hello", 0, 0));
        }

        /// <summary>
        /// Tests that render text with colors throws when open gl not initialized
        /// </summary>
        [Fact]
        public void RenderText_WithColors_ThrowsWhenOpenGLNotInitialized()
        {
            Assert.ThrowsAny<Exception>(() => FontManager.RenderText("hello", 0, 0, Color.White, Color.Black));
        }

        /// <summary>
        /// Tests that font manager is static
        /// </summary>
        [Fact]
        public void FontManager_IsStaticClass()
        {
            Type type = typeof(FontManager);
            Assert.True(type.IsSealed);
            Assert.True(type.IsAbstract);
        }

        /// <summary>
        /// Tests that font manager is public
        /// </summary>
        [Fact]
        public void FontManager_IsPublic()
        {
            Assert.True(typeof(FontManager).IsPublic);
        }

        /// <summary>
        /// Tests that render text with foreground and background delegates to default font
        /// </summary>
        [Fact]
        public void RenderText_WithForegroundAndBackground_DelegatesToDefaultFont()
        {
            Assert.ThrowsAny<Exception>(() => FontManager.RenderText("hello", 10, 20, Color.White, Color.Black));
        }

        /// <summary>
        /// Tests that render text with default colors delegates to default font
        /// </summary>
        [Fact]
        public void RenderText_WithDefaultColors_DelegatesToDefaultFont()
        {
            Assert.ThrowsAny<Exception>(() => FontManager.RenderText("hello", 10, 20));
        }
    }
}
