// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:GlyphTest.cs
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

using Alis.Extension.Graphic.Sfml.Render;
using Xunit;

namespace Alis.Extension.Graphic.Sfml.Test.Render
{
    /// <summary>
    ///     Unit tests for the Glyph struct.
    /// </summary>
    public class GlyphTest
    {
        /// <summary>
        ///     Tests default field values.
        /// </summary>
        [Fact]
        public void Default_Fields_HaveExpectedValues()
        {
            Glyph g = new Glyph();
            Assert.Equal(0.0f, g.Advance);
            Assert.Equal(0.0f, g.Bounds.Left);
            Assert.Equal(0.0f, g.Bounds.Top);
            Assert.Equal(0.0f, g.Bounds.Width);
            Assert.Equal(0.0f, g.Bounds.Height);
            Assert.Equal(0, g.TextureRect.Left);
            Assert.Equal(0, g.TextureRect.Top);
            Assert.Equal(0, g.TextureRect.Width);
            Assert.Equal(0, g.TextureRect.Height);
        }
    }
}
