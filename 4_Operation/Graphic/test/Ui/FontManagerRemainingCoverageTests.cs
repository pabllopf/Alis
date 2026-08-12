// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:FontManagerRemainingCoverageTests.cs
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
    ///     Coverage tests for the font manager static entry points
    /// </summary>
    public class FontManagerRemainingCoverageTests
    {
        /// <summary>
        ///     Tests that default font is lazily created
        /// </summary>
        [Fact]
        public void DefaultFont_IsCreatedOnAccess()
        {
            Font font = FontManager.DefaultFont;

            Assert.NotNull(font);
            Assert.Equal("mono.bmp", font.NameFile);
            Assert.Equal(1, font.Depth);
        }

        /// <summary>
        ///     Tests that render text with colors forwards to the default font
        /// </summary>
        [Fact]
        public void RenderText_WithColors_ForwardsToDefaultFont()
        {
            Assert.ThrowsAny<Exception>(() =>
                FontManager.RenderText("hello", 0, 0, Color.White, Color.Transparent));
        }

        /// <summary>
        ///     Tests that render text without colors forwards to the default font
        /// </summary>
        [Fact]
        public void RenderText_WithoutColors_ForwardsToDefaultFont()
        {
            Assert.ThrowsAny<Exception>(() =>
                FontManager.RenderText("hello", 0, 0));
        }
    }
}
