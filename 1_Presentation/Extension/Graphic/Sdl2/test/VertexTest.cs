// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:VertexTest.cs
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
    ///     Unit tests for the Vertex struct.
    /// </summary>
    public class VertexTest
    {
        /// <summary>
        /// Tests that should default to zero
        /// </summary>
        [Fact]
        public void ShouldDefaultToZero()
        {
            // Arrange
            Vertex vertex = new Vertex();
            // Assert
            Assert.Equal(0f, vertex.Position.X);
            Assert.Equal(0f, vertex.Position.Y);
            Assert.Equal(0f, vertex.TexCoordinate.X);
            Assert.Equal(0f, vertex.TexCoordinate.Y);
        }

        /// <summary>
        /// Tests that should assign and retrieve properties
        /// </summary>
        [Fact]
        public void ShouldAssignAndRetrieveProperties()
        {
            // Arrange
            Vertex vertex = new Vertex
            {
                Position = new PointF(1.5f, 2.5f),
                TexCoordinate = new PointF(0.5f, 0.5f),
                Color = new Color(255, 128, 64, 255)
            };
            // Assert
            Assert.Equal(1.5f, vertex.Position.X);
            Assert.Equal(2.5f, vertex.Position.Y);
            Assert.Equal(0.5f, vertex.TexCoordinate.X);
            Assert.Equal(0.5f, vertex.TexCoordinate.Y);
            Assert.Equal(255, vertex.Color.R);
            Assert.Equal(128, vertex.Color.G);
            Assert.Equal(64, vertex.Color.B);
            Assert.Equal(255, vertex.Color.A);
        }
    }
}
