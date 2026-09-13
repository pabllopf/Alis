// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:Vec2CoverageTests.cs
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
    ///     The vec 2 coverage tests class
    /// </summary>
    public class Vec2CoverageTests
    {
        /// <summary>
        ///     Tests that the coordinates constructor assigns the components
        /// </summary>
        [Fact]
        public void CoordinatesConstructor_AssignsComponents()
        {
            Vec2 vec = new Vec2(1.5f, -2.25f);

            Assert.Equal(1.5f, vec.X);
            Assert.Equal(-2.25f, vec.Y);
        }

        /// <summary>
        ///     Tests that the coordinates constructor assigns zero components
        /// </summary>
        [Fact]
        public void CoordinatesConstructor_ZeroValues_AssignsZeroComponents()
        {
            Vec2 vec = new Vec2(0.0f, 0.0f);

            Assert.Equal(0.0f, vec.X);
            Assert.Equal(0.0f, vec.Y);
        }

        /// <summary>
        ///     Tests that the vector constructor maps the source components
        /// </summary>
        [Fact]
        public void Vector2FConstructor_MapsSourceComponents()
        {
            Vector2F source = new Vector2F(3.75f, -4.5f);

            Vec2 vec = new Vec2(source);

            Assert.Equal(3.75f, vec.X);
            Assert.Equal(-4.5f, vec.Y);
        }

        /// <summary>
        ///     Tests that the vector constructor maps a zero vector to zero components
        /// </summary>
        [Fact]
        public void Vector2FConstructor_ZeroVector_MapsToZeroComponents()
        {
            Vector2F source = new Vector2F(0.0f, 0.0f);

            Vec2 vec = new Vec2(source);

            Assert.Equal(0.0f, vec.X);
            Assert.Equal(0.0f, vec.Y);
        }

        /// <summary>
        ///     Tests that the implicit cast maps the source components
        /// </summary>
        [Fact]
        public void ImplicitCast_FromVector2F_MapsSourceComponents()
        {
            Vector2F source = new Vector2F(7.25f, -8.5f);

            Vec2 vec = source;

            Assert.Equal(7.25f, vec.X);
            Assert.Equal(-8.5f, vec.Y);
        }

        /// <summary>
        ///     Tests that the implicit cast maps a zero vector to zero components
        /// </summary>
        [Fact]
        public void ImplicitCast_FromZeroVector2F_MapsToZeroComponents()
        {
            Vector2F source = new Vector2F(0.0f, 0.0f);

            Vec2 vec = source;

            Assert.Equal(0.0f, vec.X);
            Assert.Equal(0.0f, vec.Y);
        }
    }
}
