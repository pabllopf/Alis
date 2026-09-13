// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:Vec4CoverageTests.cs
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
    ///     The vec 4 coverage tests class
    /// </summary>
    public class Vec4CoverageTests
    {
        /// <summary>
        ///     Tests that the coordinates constructor assigns the components
        /// </summary>
        [Fact]
        public void CoordinatesConstructor_AssignsComponents()
        {
            Vec4 vec = new Vec4(1.5f, -2.25f, 3.75f, -4.5f);

            Assert.Equal(1.5f, vec.X);
            Assert.Equal(-2.25f, vec.Y);
            Assert.Equal(3.75f, vec.Z);
            Assert.Equal(-4.5f, vec.W);
        }

        /// <summary>
        ///     Tests that the coordinates constructor assigns zero components
        /// </summary>
        [Fact]
        public void CoordinatesConstructor_ZeroValues_AssignsZeroComponents()
        {
            Vec4 vec = new Vec4(0.0f, 0.0f, 0.0f, 0.0f);

            Assert.Equal(0.0f, vec.X);
            Assert.Equal(0.0f, vec.Y);
            Assert.Equal(0.0f, vec.Z);
            Assert.Equal(0.0f, vec.W);
        }

        /// <summary>
        ///     Tests that the color constructor normalizes red green blue alpha components
        /// </summary>
        [Fact]
        public void ColorConstructor_NormalizesRgbaComponents()
        {
            Color color = new Color(128, 64, 32, 16);

            Vec4 vec = new Vec4(color);

            Assert.Equal(128 / 255.0f, vec.X, 6);
            Assert.Equal(64 / 255.0f, vec.Y, 6);
            Assert.Equal(32 / 255.0f, vec.Z, 6);
            Assert.Equal(16 / 255.0f, vec.W, 6);
        }

        /// <summary>
        ///     Tests that the color constructor maps white color to one components
        /// </summary>
        [Fact]
        public void ColorConstructor_WhiteColor_MapsToOneComponents()
        {
            Vec4 vec = new Vec4(Color.White);

            Assert.Equal(1.0f, vec.X);
            Assert.Equal(1.0f, vec.Y);
            Assert.Equal(1.0f, vec.Z);
            Assert.Equal(1.0f, vec.W);
        }

        /// <summary>
        ///     Tests that the color constructor maps transparent color to zero components
        /// </summary>
        [Fact]
        public void ColorConstructor_TransparentColor_MapsToZeroComponents()
        {
            Vec4 vec = new Vec4(Color.Transparent);

            Assert.Equal(0.0f, vec.X);
            Assert.Equal(0.0f, vec.Y);
            Assert.Equal(0.0f, vec.Z);
            Assert.Equal(0.0f, vec.W);
        }
    }
}
