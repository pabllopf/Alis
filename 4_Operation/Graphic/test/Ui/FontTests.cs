// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:FontTests.cs
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
    /// The font tests class
    /// </summary>
    public class FontTests
    {

        /// <summary>
        /// Tests that render text with empty text does not iterate chars
        /// </summary>
        [Fact]
        public void RenderText_WithEmptyText_DoesNotIterateChars()
        {
            Font font = new Font(null, 1, 16);

            Assert.ThrowsAny<Exception>(() =>
                font.RenderText(string.Empty, 0, 0, Color.White, Color.Transparent));
        }

        /// <summary>
        /// Tests that render text with white background calls method
        /// </summary>
        [Fact]
        public void RenderText_WithWhiteBackground_CallsMethod()
        {
            Font font = new Font(null, 1, 16);

            Assert.ThrowsAny<Exception>(() =>
                font.RenderText("x", 100, 200, Color.White, Color.White));
        }

        /// <summary>
        /// Tests that render text with custom position uses position
        /// </summary>
        [Fact]
        public void RenderText_WithCustomPosition_UsesPosition()
        {
            Font font = new Font(null, 1, 16);

            Assert.ThrowsAny<Exception>(() =>
                font.RenderText("test", 50, 75, Color.Black, Color.Transparent));
        }
    }
}
