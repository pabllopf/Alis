// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:StylesTest.cs
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

using SfmlRender = Alis.Extension.Graphic.Sfml.Render;
using Xunit;

namespace Alis.Extension.Graphic.Sfml.Test.Render
{
    /// <summary>
    ///     Tests the <see cref="Alis.Extension.Graphic.Sfml.Render.Styles" /> enum.
    /// </summary>
    public class RenderStylesTest
    {
        /// <summary>
        /// Tests that none has value 0
        /// </summary>
        [Fact]
        public void None_HasValue0() => Assert.Equal(0, (int) SfmlRender.Styles.None);

        /// <summary>
        /// Tests that bold has value 1
        /// </summary>
        [Fact]
        public void Bold_HasValue1() => Assert.Equal(1, (int) SfmlRender.Styles.Bold);

        /// <summary>
        /// Tests that italic has value 2
        /// </summary>
        [Fact]
        public void Italic_HasValue2() => Assert.Equal(2, (int) SfmlRender.Styles.Italic);

        /// <summary>
        /// Tests that underlined has value 4
        /// </summary>
        [Fact]
        public void Underlined_HasValue4() => Assert.Equal(4, (int) SfmlRender.Styles.Underlined);

        /// <summary>
        /// Tests that strike through has value 8
        /// </summary>
        [Fact]
        public void StrikeThrough_HasValue8() => Assert.Equal(8, (int) SfmlRender.Styles.StrikeThrough);

        /// <summary>
        /// Tests that bold italic combined
        /// </summary>
        [Fact]
        public void BoldItalic_Combined() => Assert.Equal(3, (int) (SfmlRender.Styles.Bold | SfmlRender.Styles.Italic));

        /// <summary>
        /// Tests that all combined
        /// </summary>
        [Fact]
        public void All_Combined() => Assert.Equal(15, (int) (SfmlRender.Styles.Bold | SfmlRender.Styles.Italic | SfmlRender.Styles.Underlined | SfmlRender.Styles.StrikeThrough));
    }
}
