// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:Ivec4CoverageTests.cs
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
    ///     The ivec 4 coverage tests class
    /// </summary>
    public class Ivec4CoverageTests
    {
        /// <summary>
        ///     Tests that the coordinates constructor assigns the components
        /// </summary>
        [Fact]
        public void CoordinatesConstructor_AssignsComponents()
        {
            Ivec4 vec = new Ivec4(-1, 2, 3, -4);

            Assert.Equal(-1, vec.X);
            Assert.Equal(2, vec.Y);
            Assert.Equal(3, vec.Z);
            Assert.Equal(-4, vec.W);
        }

        /// <summary>
        ///     Tests that the color constructor maps red green blue alpha to components
        /// </summary>
        [Fact]
        public void ColorConstructor_MapsRgbaComponents()
        {
            Color color = new Color(10, 20, 30, 40);

            Ivec4 vec = new Ivec4(color);

            Assert.Equal(10, vec.X);
            Assert.Equal(20, vec.Y);
            Assert.Equal(30, vec.Z);
            Assert.Equal(40, vec.W);
        }

        /// <summary>
        ///     Tests that the color constructor maps zero color to zero components
        /// </summary>
        [Fact]
        public void ColorConstructor_ZeroColor_MapsZeroComponents()
        {
            Ivec4 vec = new Ivec4(Color.Transparent);

            Assert.Equal(0, vec.X);
            Assert.Equal(0, vec.Y);
            Assert.Equal(0, vec.Z);
            Assert.Equal(0, vec.W);
        }

        /// <summary>
        ///     Tests that the color constructor maps max alpha color
        /// </summary>
        [Fact]
        public void ColorConstructor_MaxColor_MapsMaxComponents()
        {
            Ivec4 vec = new Ivec4(Color.White);

            Assert.Equal(255, vec.X);
            Assert.Equal(255, vec.Y);
            Assert.Equal(255, vec.Z);
            Assert.Equal(255, vec.W);
        }
    }
}
