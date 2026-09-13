// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:Vec3CoverageTests.cs
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
    ///     The vec 3 coverage tests class
    /// </summary>
    public class Vec3CoverageTests
    {
        /// <summary>
        ///     Tests that the coordinates constructor assigns the components
        /// </summary>
        [Fact]
        public void CoordinatesConstructor_AssignsComponents()
        {
            Vec3 vec = new Vec3(1.5f, -2.25f, 3.75f);

            Assert.Equal(1.5f, vec.X);
            Assert.Equal(-2.25f, vec.Y);
            Assert.Equal(3.75f, vec.Z);
        }

        /// <summary>
        ///     Tests that the coordinates constructor assigns zero components
        /// </summary>
        [Fact]
        public void CoordinatesConstructor_ZeroValues_AssignsZeroComponents()
        {
            Vec3 vec = new Vec3(0.0f, 0.0f, 0.0f);

            Assert.Equal(0.0f, vec.X);
            Assert.Equal(0.0f, vec.Y);
            Assert.Equal(0.0f, vec.Z);
        }

        /// <summary>
        ///     Tests that the vector constructor maps the source components
        /// </summary>
        [Fact]
        public void Vector3FConstructor_MapsSourceComponents()
        {
            Vector3F source = new Vector3F(2.5f, -3.5f, 4.5f);

            Vec3 vec = new Vec3(source);

            Assert.Equal(2.5f, vec.X);
            Assert.Equal(-3.5f, vec.Y);
            Assert.Equal(4.5f, vec.Z);
        }

        /// <summary>
        ///     Tests that the implicit cast maps the source components
        /// </summary>
        [Fact]
        public void ImplicitCast_FromVector3F_MapsSourceComponents()
        {
            Vector3F source = new Vector3F(7.25f, -8.5f, 9.75f);

            Vec3 vec = source;

            Assert.Equal(7.25f, vec.X);
            Assert.Equal(-8.5f, vec.Y);
            Assert.Equal(9.75f, vec.Z);
        }

        /// <summary>
        ///     Tests that the implicit cast maps a zero vector to zero components
        /// </summary>
        [Fact]
        public void ImplicitCast_FromZeroVector3F_MapsToZeroComponents()
        {
            Vector3F source = new Vector3F(0.0f, 0.0f, 0.0f);

            Vec3 vec = source;

            Assert.Equal(0.0f, vec.X);
            Assert.Equal(0.0f, vec.Y);
            Assert.Equal(0.0f, vec.Z);
        }
    }
}
