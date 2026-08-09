// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:Vec3RemainingCoverageTests.cs
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
    ///     The vec 3 remaining coverage tests class
    /// </summary>
    public class Vec3RemainingCoverageTests
    {
        /// <summary>
        ///     Tests that constructor assigns coordinates
        /// </summary>
        [Fact]
        public void Constructor_AssignsCoordinates()
        {
            Vec3 vec = new Vec3(1.0f, 2.0f, 3.0f);

            Assert.Equal(1.0f, vec.X);
            Assert.Equal(2.0f, vec.Y);
            Assert.Equal(3.0f, vec.Z);
        }

        /// <summary>
        ///     Tests that constructor from vector 3 f assigns components
        /// </summary>
        [Fact]
        public void Constructor_FromVector3F_AssignsComponents()
        {
            Vector3F source = new Vector3F(4.0f, 5.0f, 6.0f);

            Vec3 vec = new Vec3(source);

            Assert.Equal(4.0f, vec.X);
            Assert.Equal(5.0f, vec.Y);
            Assert.Equal(6.0f, vec.Z);
        }

        /// <summary>
        ///     Tests that implicit cast from vector 3 f assigns components
        /// </summary>
        [Fact]
        public void ImplicitCast_FromVector3F_AssignsComponents()
        {
            Vector3F source = new Vector3F(7.0f, 8.0f, 9.0f);

            Vec3 vec = source;

            Assert.Equal(7.0f, vec.X);
            Assert.Equal(8.0f, vec.Y);
            Assert.Equal(9.0f, vec.Z);
        }
    }
}
