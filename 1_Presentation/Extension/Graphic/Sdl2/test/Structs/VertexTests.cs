// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:VertexTests.cs
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

using Alis.Core.Aspect.Math;
using Alis.Core.Aspect.Math.Definition;
using Alis.Core.Aspect.Math.Shape.Point;
using Alis.Extension.Graphic.Sdl2.Structs;
using Xunit;

namespace Alis.Extension.Graphic.Sdl2.Test.Structs
{
    /// <summary>
    ///     The vertex tests class
    /// </summary>
    public class VertexTests
    {
        /// <summary>
        ///     Tests that vertex initializes position correctly
        /// </summary>
        [Fact]
        public void Vertex_InitializesPositionCorrectly()
        {
            PointF expectedPosition = new PointF(1.0f, 2.0f);

            Vertex vertex = new Vertex
            {
                Position = expectedPosition
            };

            Assert.Equal(expectedPosition, vertex.Position);
        }

        /// <summary>
        ///     Tests that vertex initializes color correctly
        /// </summary>
        [Fact]
        public void Vertex_InitializesColorCorrectly()
        {
            Color expectedColor = new Color(255, 255, 255, 255);

            Vertex vertex = new Vertex
            {
                Color = expectedColor
            };

            Assert.Equal(expectedColor, vertex.Color);
        }

        /// <summary>
        ///     Tests that vertex initializes tex coordinate correctly
        /// </summary>
        [Fact]
        public void Vertex_InitializesTexCoordinateCorrectly()
        {
            PointF expectedTexCoordinate = new PointF(0.5f, 0.5f);

            Vertex vertex = new Vertex
            {
                TexCoordinate = expectedTexCoordinate
            };

            Assert.Equal(expectedTexCoordinate, vertex.TexCoordinate);
        }
    }
}