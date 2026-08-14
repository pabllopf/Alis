// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:VertexRemainingCoverageTests.cs
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
using Alis.Extension.Graphic.Sfml.Test.Attributes;
using Xunit;

namespace Alis.Extension.Graphic.Sfml.Test.Render
{
    /// <summary>
    ///     The vertex remaining coverage tests class
    /// </summary>
    public class VertexRemainingCoverageTests
    {
        /// <summary>
        ///     Tests that position constructor assigns position white color and zero tex coords
        /// </summary>
        [RequireCSfmlWindowsFact]
        public void PositionConstructor_AssignsPositionWhiteColorAndZeroTexCoords()
        {
            Vertex vertex = new Vertex(new Vector2F(1, 2));

            Assert.Equal(1, vertex.Position.X);
            Assert.Equal(2, vertex.Position.Y);
            Assert.Equal(Color.White.R, vertex.Color.R);
            Assert.Equal(Color.White.G, vertex.Color.G);
            Assert.Equal(0, vertex.TexCoords.X);
            Assert.Equal(0, vertex.TexCoords.Y);
        }

        /// <summary>
        ///     Tests that position and color constructor assigns color and zero tex coords
        /// </summary>
        [RequireCSfmlWindowsFact]
        public void PositionAndColorConstructor_AssignsColorAndZeroTexCoords()
        {
            Color color = new Color(10, 20, 30, 40);
            Vertex vertex = new Vertex(new Vector2F(3, 4), color);

            Assert.Equal(3, vertex.Position.X);
            Assert.Equal(4, vertex.Position.Y);
            Assert.Equal(10, vertex.Color.R);
            Assert.Equal(20, vertex.Color.G);
            Assert.Equal(0, vertex.TexCoords.X);
            Assert.Equal(0, vertex.TexCoords.Y);
        }

        /// <summary>
        ///     Tests that position and tex coords constructor assigns tex coords and white color
        /// </summary>
        [RequireCSfmlWindowsFact]
        public void PositionAndTexCoordsConstructor_AssignsTexCoordsAndWhiteColor()
        {
            Vertex vertex = new Vertex(new Vector2F(5, 6), new Vector2F(0.5f, 0.25f));

            Assert.Equal(5, vertex.Position.X);
            Assert.Equal(6, vertex.Position.Y);
            Assert.Equal(0.5f, vertex.TexCoords.X);
            Assert.Equal(0.25f, vertex.TexCoords.Y);
            Assert.Equal(Color.White.R, vertex.Color.R);
        }

        /// <summary>
        ///     Tests that full constructor assigns all fields
        /// </summary>
        [RequireCSfmlWindowsFact]
        public void FullConstructor_AssignsAllFields()
        {
            Color color = new Color(255, 0, 0, 255);
            Vertex vertex = new Vertex(new Vector2F(7, 8), color, new Vector2F(1, 1));

            Assert.Equal(7, vertex.Position.X);
            Assert.Equal(8, vertex.Position.Y);
            Assert.Equal(color.R, vertex.Color.R);
            Assert.Equal(color.G, vertex.Color.G);
            Assert.Equal(1, vertex.TexCoords.X);
            Assert.Equal(1, vertex.TexCoords.Y);
        }

        /// <summary>
        ///     Tests that to string returns expected format
        /// </summary>
        [RequireCSfmlWindowsFact]
        public void ToString_ReturnsExpectedFormat()
        {
            Vertex vertex = new Vertex(new Vector2F(1, 2), Color.Red, new Vector2F(3, 4));

            string str = vertex.ToString();

            Assert.Contains("[Vertex]", str);
            Assert.Contains("Position", str);
            Assert.Contains("Color", str);
            Assert.Contains("TexCoords", str);
        }
    }
}
