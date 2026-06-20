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
        [Fact]
        public void Points_HasValue0() => Assert.Equal(0, (int) PrimitiveType.Points);

        [Fact]
        public void Lines_HasValue1() => Assert.Equal(1, (int) PrimitiveType.Lines);

        [Fact]
        public void LineStrip_HasValue2() => Assert.Equal(2, (int) PrimitiveType.LineStrip);

        [Fact]
        public void Triangles_HasValue3() => Assert.Equal(3, (int) PrimitiveType.Triangles);

        [Fact]
        public void TriangleStrip_HasValue4() => Assert.Equal(4, (int) PrimitiveType.TriangleStrip);

        [Fact]
        public void TriangleFan_HasValue5() => Assert.Equal(5, (int) PrimitiveType.TriangleFan);

        [Fact]
        public void Quads_HasValue6() => Assert.Equal(6, (int) PrimitiveType.Quads);

        [Fact]
        public void LinesStrip_EqualsLineStrip() => Assert.Equal(PrimitiveType.LineStrip, PrimitiveType.LinesStrip);

        [Fact]
        public void TrianglesStrip_EqualsTriangleStrip() => Assert.Equal(PrimitiveType.TriangleStrip, PrimitiveType.TrianglesStrip);

        [Fact]
        public void TrianglesFan_EqualsTriangleFan() => Assert.Equal(PrimitiveType.TriangleFan, PrimitiveType.TrianglesFan);
    }
}
