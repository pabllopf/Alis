// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:VertexCoverageTests.cs
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

using Alis.Core.Aspect.Math.Definition;
using Alis.Core.Aspect.Math.Shapes.Point;
using Alis.Extension.Graphic.Sdl2.Structs;
using Xunit;

namespace Alis.Extension.Graphic.Sdl2.Test
{
    /// <summary>
    ///     The vertex coverage tests class
    /// </summary>
    public class VertexCoverageTests
    {
        /// <summary>
        ///     Tests that default initialization properties have default values
        /// </summary>
        [Fact]
        public void Vertex_DefaultInitialization_PropertiesHaveDefaultValues()
        {
            Vertex vertex = default(Vertex);

            Assert.Equal(0f, vertex.Position.X, 5);
            Assert.Equal(0f, vertex.Position.Y, 5);
            Assert.Equal(0, vertex.Color.R);
            Assert.Equal(0, vertex.Color.G);
            Assert.Equal(0, vertex.Color.B);
            Assert.Equal(0f, vertex.TexCoordinate.X, 5);
            Assert.Equal(0f, vertex.TexCoordinate.Y, 5);
        }

        /// <summary>
        ///     Tests that set properties stores values correctly
        /// </summary>
        [Fact]
        public void Vertex_SetProperties_StoresValuesCorrectly()
        {
            Vertex vertex = new Vertex
            {
                Position = new PointF(1f, 2f),
                Color = new Color(10, 20, 30, 40),
                TexCoordinate = new PointF(3f, 4f)
            };

            Assert.Equal(1f, vertex.Position.X, 5);
            Assert.Equal(2f, vertex.Position.Y, 5);
            Assert.Equal(10, vertex.Color.R);
            Assert.Equal(20, vertex.Color.G);
            Assert.Equal(30, vertex.Color.B);
            Assert.Equal(3f, vertex.TexCoordinate.X, 5);
            Assert.Equal(4f, vertex.TexCoordinate.Y, 5);
        }

        /// <summary>
        ///     Tests that the struct is a value type and copies are independent
        /// </summary>
        [Fact]
        public void Vertex_IsValueType_CopyIsIndependent()
        {
            Vertex original = new Vertex { Position = new PointF(1f, 1f) };
            Vertex copy = original;

            copy.Position = new PointF(2f, 2f);

            Assert.Equal(1f, original.Position.X, 5);
            Assert.Equal(2f, copy.Position.X, 5);
        }
    }
}