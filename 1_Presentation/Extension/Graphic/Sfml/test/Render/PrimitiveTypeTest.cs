// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:PrimitiveTypeTest.cs
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
    ///     Tests the <see cref="PrimitiveType" /> enum.
    /// </summary>
    public class PrimitiveTypeTest
    {
        /// <summary>
        /// Tests that points has value 0
        /// </summary>
        [Fact]
        public void Points_HasValue0() => Assert.Equal(0, (int) PrimitiveType.Points);

        /// <summary>
        /// Tests that lines has value 1
        /// </summary>
        [Fact]
        public void Lines_HasValue1() => Assert.Equal(1, (int) PrimitiveType.Lines);

        /// <summary>
        /// Tests that line strip has value 2
        /// </summary>
        [Fact]
        public void LineStrip_HasValue2() => Assert.Equal(2, (int) PrimitiveType.LineStrip);

        /// <summary>
        /// Tests that triangles has value 3
        /// </summary>
        [Fact]
        public void Triangles_HasValue3() => Assert.Equal(3, (int) PrimitiveType.Triangles);

        /// <summary>
        /// Tests that triangle strip has value 4
        /// </summary>
        [Fact]
        public void TriangleStrip_HasValue4() => Assert.Equal(4, (int) PrimitiveType.TriangleStrip);

        /// <summary>
        /// Tests that triangle fan has value 5
        /// </summary>
        [Fact]
        public void TriangleFan_HasValue5() => Assert.Equal(5, (int) PrimitiveType.TriangleFan);

        /// <summary>
        /// Tests that quads has value 6
        /// </summary>
        [Fact]
        public void Quads_HasValue6() => Assert.Equal(6, (int) PrimitiveType.Quads);

        /// <summary>
        /// Tests that lines strip equals line strip
        /// </summary>
        [Fact]
        public void LinesStrip_EqualsLineStrip() => Assert.Equal(PrimitiveType.LineStrip, PrimitiveType.LinesStrip);

        /// <summary>
        /// Tests that triangles strip equals triangle strip
        /// </summary>
        [Fact]
        public void TrianglesStrip_EqualsTriangleStrip() => Assert.Equal(PrimitiveType.TriangleStrip, PrimitiveType.TrianglesStrip);

        /// <summary>
        /// Tests that triangles fan equals triangle fan
        /// </summary>
        [Fact]
        public void TrianglesFan_EqualsTriangleFan() => Assert.Equal(PrimitiveType.TriangleFan, PrimitiveType.TrianglesFan);
    }
}
