// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:Vec3Test.cs
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
    ///     Unit tests for the Vec3 struct.
    /// </summary>
    public class Vec3Test
    {
        /// <summary>
        ///     Tests the constructor and field assignment.
        /// </summary>
        [Fact]
        public void Constructor_AssignsFields()
        {
            Vec3 v = new Vec3(1.5f, 2.5f, 3.5f);
            Assert.Equal(1.5f, v.X);
            Assert.Equal(2.5f, v.Y);
            Assert.Equal(3.5f, v.Z);
        }

        /// <summary>
        ///     Tests the constructor from Vector3F.
        /// </summary>
        [Fact]
        public void Constructor_FromVector3F_CopiesFields()
        {
            Vector3F source = new Vector3F(4.0f, 5.0f, 6.0f);
            Vec3 v = new Vec3(source);
            Assert.Equal(4.0f, v.X);
            Assert.Equal(5.0f, v.Y);
            Assert.Equal(6.0f, v.Z);
        }

        /// <summary>
        ///     Tests the implicit cast from Vector3F.
        /// </summary>
        [Fact]
        public void ImplicitCast_FromVector3F_Works()
        {
            Vector3F vec3f = new Vector3F(7.0f, 8.0f, 9.0f);
            Vec3 v = vec3f;
            Assert.Equal(7.0f, v.X);
            Assert.Equal(8.0f, v.Y);
            Assert.Equal(9.0f, v.Z);
        }
    }
}
