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

using Alis.Core.Aspect.Math.Vector;
using Alis.Extension.Graphic.Sfml.Render;
using Xunit;

namespace Alis.Extension.Graphic.Sfml.Test.Render
{
    /// <summary>
    ///     Unit tests for the Vertex struct covering all constructors, default value, fields and ToString.
    /// </summary>
    public class VertexTests
    {
        /// <summary>
        ///     Tests that the default struct value has zeroed position, color and tex coords.
        /// </summary>
        [Fact]
        public void DefaultValue_HasZeroedFields()
        {
            Vertex vertex = default;

            Assert.Equal(0, vertex.Position.X);
            Assert.Equal(0, vertex.Position.Y);
            Assert.Equal(0, vertex.Color.R);
            Assert.Equal(0, vertex.TexCoords.X);
            Assert.Equal(0, vertex.TexCoords.Y);
        }

        /// <summary>
        ///     Tests that the position only constructor assigns position, white color and zero tex coords.
        /// </summary>
        [Fact]
        public void Constructor_PositionOnly_AssignsPositionWhiteColorAndZeroTexCoords()
        {
            Vertex vertex = new Vertex(new Vector2F(1, 2));

            Assert.Equal(1, vertex.Position.X);
            Assert.Equal(2, vertex.Position.Y);
            Assert.Equal(Color.White.R, vertex.Color.R);
            Assert.Equal(255, vertex.Color.A);
            Assert.Equal(0, vertex.TexCoords.X);
            Assert.Equal(0, vertex.TexCoords.Y);
        }

        /// <summary>
        ///     Tests that the position and color constructor assigns color and zero tex coords.
        /// </summary>
        [Fact]
        public void Constructor_PositionAndColor_AssignsColorAndZeroTexCoords()
        {
            Color color = new Color(10, 20, 30, 40);
            Vertex vertex = new Vertex(new Vector2F(3, 4), color);

            Assert.Equal(3, vertex.Position.X);
            Assert.Equal(4, vertex.Position.Y);
            Assert.Equal(10, vertex.Color.R);
            Assert.Equal(20, vertex.Color.G);
            Assert.Equal(30, vertex.Color.B);
            Assert.Equal(40, vertex.Color.A);
            Assert.Equal(0, vertex.TexCoords.X);
            Assert.Equal(0, vertex.TexCoords.Y);
        }

        /// <summary>
        ///     Tests that the position and tex coords constructor assigns tex coords and white color.
        /// </summary>
        [Fact]
        public void Constructor_PositionAndTexCoords_AssignsTexCoordsAndWhiteColor()
        {
            Vertex vertex = new Vertex(new Vector2F(5, 6), new Vector2F(0.5f, 0.25f));

            Assert.Equal(5, vertex.Position.X);
            Assert.Equal(6, vertex.Position.Y);
            Assert.Equal(0.5f, vertex.TexCoords.X);
            Assert.Equal(0.25f, vertex.TexCoords.Y);
            Assert.Equal(Color.White.R, vertex.Color.R);
            Assert.Equal(255, vertex.Color.A);
        }

        /// <summary>
        ///     Tests that the full constructor assigns all fields.
        /// </summary>
        [Fact]
        public void Constructor_PositionColorTexCoords_AssignsAllFields()
        {
            Color color = new Color(255, 0, 0, 255);
            Vertex vertex = new Vertex(new Vector2F(7, 8), color, new Vector2F(1, 1));

            Assert.Equal(7, vertex.Position.X);
            Assert.Equal(8, vertex.Position.Y);
            Assert.Equal(255, vertex.Color.R);
            Assert.Equal(0, vertex.Color.G);
            Assert.Equal(0, vertex.Color.B);
            Assert.Equal(255, vertex.Color.A);
            Assert.Equal(1, vertex.TexCoords.X);
            Assert.Equal(1, vertex.TexCoords.Y);
        }

        /// <summary>
        ///     Tests that all three fields are mutable.
        /// </summary>
        [Fact]
        public void Fields_AreMutable()
        {
            Vertex vertex = new Vertex(new Vector2F(0, 0));

            vertex.Position = new Vector2F(10, 20);
            vertex.Color = Color.Magenta;
            vertex.TexCoords = new Vector2F(30, 40);

            Assert.Equal(10, vertex.Position.X);
            Assert.Equal(20, vertex.Position.Y);
            Assert.Equal(Color.Magenta.R, vertex.Color.R);
            Assert.Equal(255, vertex.Color.A);
            Assert.Equal(30, vertex.TexCoords.X);
            Assert.Equal(40, vertex.TexCoords.Y);
        }

        /// <summary>
        ///     Tests that ToString contains the expected labels.
        /// </summary>
        [Fact]
        public void ToString_ContainsExpectedLabels()
        {
            Vertex vertex = new Vertex(new Vector2F(1, 2), Color.Red, new Vector2F(3, 4));

            string str = vertex.ToString();

            Assert.Contains("[Vertex]", str);
            Assert.Contains("Position", str);
            Assert.Contains("Color", str);
            Assert.Contains("TexCoords", str);
        }

        /// <summary>
        ///     Tests that ToString includes the field values.
        /// </summary>
        [Fact]
        public void ToString_IncludesFieldValues()
        {
            Vertex vertex = new Vertex(new Vector2F(1, 2), Color.Red, new Vector2F(3, 4));

            string str = vertex.ToString();

            Assert.Contains("1", str);
            Assert.Contains("2", str);
            Assert.Contains("3", str);
            Assert.Contains("4", str);
        }
    }
}
