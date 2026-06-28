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

using Alis.Core.Aspect.Math.Vector;
using Alis.Extension.Graphic.Sfml.Render;
using Xunit;

namespace Alis.Extension.Graphic.Sfml.Test.Render
{
    /// <summary>
    ///     Tests the <see cref="Vertex" /> struct.
    /// </summary>
    public class VertexTest
    {
        /// <summary>
        /// Tests that constructor position only sets fields
        /// </summary>
        [Fact]
        public void Constructor_PositionOnly_SetsFields()
        {
            Vertex v = new Vertex(new Vector2F(1, 2));
            Assert.Equal(1, v.Position.X);
            Assert.Equal(2, v.Position.Y);
            Assert.Equal(Color.White, v.Color);
            Assert.Equal(0, v.TexCoords.X);
            Assert.Equal(0, v.TexCoords.Y);
        }

        /// <summary>
        /// Tests that constructor position and color sets fields
        /// </summary>
        [Fact]
        public void Constructor_PositionAndColor_SetsFields()
        {
            Vertex v = new Vertex(new Vector2F(3, 4), Color.Black);
            Assert.Equal(3, v.Position.X);
            Assert.Equal(4, v.Position.Y);
            Assert.Equal(Color.Black, v.Color);
            Assert.Equal(0, v.TexCoords.X);
            Assert.Equal(0, v.TexCoords.Y);
        }

        /// <summary>
        /// Tests that constructor position and tex coords sets fields
        /// </summary>
        [Fact]
        public void Constructor_PositionAndTexCoords_SetsFields()
        {
            Vertex v = new Vertex(new Vector2F(5, 6), new Vector2F(7, 8));
            Assert.Equal(5, v.Position.X);
            Assert.Equal(6, v.Position.Y);
            Assert.Equal(Color.White, v.Color);
            Assert.Equal(7, v.TexCoords.X);
            Assert.Equal(8, v.TexCoords.Y);
        }

        /// <summary>
        /// Tests that constructor position color tex coords sets fields
        /// </summary>
        [Fact]
        public void Constructor_PositionColorTexCoords_SetsFields()
        {
            Vertex v = new Vertex(new Vector2F(9, 10), Color.Blue, new Vector2F(11, 12));
            Assert.Equal(9, v.Position.X);
            Assert.Equal(10, v.Position.Y);
            Assert.Equal(Color.Blue, v.Color);
            Assert.Equal(11, v.TexCoords.X);
            Assert.Equal(12, v.TexCoords.Y);
        }

        /// <summary>
        /// Tests that fields are mutable
        /// </summary>
        [Fact]
        public void Fields_AreMutable()
        {
            Vertex v = new Vertex(new Vector2F(0, 0));
            v.Position = new Vector2F(10, 20);
            v.Color = Color.Magenta;
            v.TexCoords = new Vector2F(30, 40);
            Assert.Equal(10, v.Position.X);
            Assert.Equal(20, v.Position.Y);
            Assert.Equal(Color.Magenta, v.Color);
            Assert.Equal(30, v.TexCoords.X);
            Assert.Equal(40, v.TexCoords.Y);
        }

        /// <summary>
        /// Tests that to string contains fields
        /// </summary>
        [Fact]
        public void ToString_ContainsFields()
        {
            Vertex v = new Vertex(new Vector2F(1, 2), Color.Red, new Vector2F(3, 4));
            string str = v.ToString();
            Assert.Contains("Position", str);
            Assert.Contains("Color", str);
            Assert.Contains("TexCoords", str);
        }
    }
}
