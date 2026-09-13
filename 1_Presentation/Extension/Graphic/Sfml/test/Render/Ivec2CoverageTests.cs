// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:Ivec2CoverageTests.cs
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

using Alis.Core.Aspect.Math.Vector;
using Alis.Extension.Graphic.Sfml.Render;
using Xunit;

namespace Alis.Extension.Graphic.Sfml.Test.Render
{
    /// <summary>
    ///     The ivec 2 coverage tests class
    /// </summary>
    public class Ivec2CoverageTests
    {
        /// <summary>
        ///     Tests that the coordinates constructor assigns the components
        /// </summary>
        [Fact]
        public void CoordinatesConstructor_AssignsComponents()
        {
            Ivec2 vec = new Ivec2(-1, 2);

            Assert.Equal(-1, vec.X);
            Assert.Equal(2, vec.Y);
        }

        /// <summary>
        ///     Tests that the coordinates constructor assigns zero components
        /// </summary>
        [Fact]
        public void CoordinatesConstructor_ZeroValues_AssignsZeroComponents()
        {
            Ivec2 vec = new Ivec2(0, 0);

            Assert.Equal(0, vec.X);
            Assert.Equal(0, vec.Y);
        }

        /// <summary>
        ///     Tests that the vector constructor maps the vector 2f components
        /// </summary>
        [Fact]
        public void Vector2FConstructor_MapsComponents()
        {
            Vector2F vector = new Vector2F(3.5f, -7.25f);

            Ivec2 vec = new Ivec2(vector);

            Assert.Equal(3.5f, vec.X);
            Assert.Equal(-7.25f, vec.Y);
        }

        /// <summary>
        ///     Tests that the implicit cast operator maps the vector 2f components
        /// </summary>
        [Fact]
        public void ImplicitCast_MapsComponents()
        {
            Vector2F vector = new Vector2F(2.5f, 4.5f);

            Ivec2 vec = vector;

            Assert.Equal(2.5f, vec.X);
            Assert.Equal(4.5f, vec.Y);
        }
    }
}
