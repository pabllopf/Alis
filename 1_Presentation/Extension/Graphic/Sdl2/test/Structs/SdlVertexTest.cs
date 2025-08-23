// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:SdlVertexTest.cs
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

using System.Reflection;
using Alis.Core.Aspect.Math;
using Alis.Core.Aspect.Math.Definition;
using Alis.Core.Aspect.Math.Shape.Point;
using Alis.Extension.Graphic.Sdl2.Structs;
using Xunit;

namespace Alis.Extension.Graphic.Sdl2.Test.Structs
{
    /// <summary>
    ///     The sdl vertex test class
    /// </summary>
    public class SdlVertexTest
    {
        /// <summary>
        ///     Tests that sdl vertex has correct field count
        /// </summary>
        [Fact]
        public void SdlVertex_HasCorrectFieldCount()
        {
            PropertyInfo[] fields = typeof(Vertex).GetProperties();
            Assert.Equal(3, fields.Length);
        }

        /// <summary>
        ///     Tests that sdl vertex position field is of type point f
        /// </summary>
        [Fact]
        public void SdlVertex_PositionField_IsOfTypePointF()
        {
            PropertyInfo positionField = typeof(Vertex).GetProperty("Position");
            Assert.NotNull(positionField);
            Assert.Equal(typeof(PointF), positionField.PropertyType);
        }

        /// <summary>
        ///     Tests that sdl vertex color field is of type sdl color
        /// </summary>
        [Fact]
        public void SdlVertex_ColorField_IsOfTypeSdlColor()
        {
            PropertyInfo colorField = typeof(Vertex).GetProperty("Color");
            Assert.NotNull(colorField);
            Assert.Equal(typeof(Color), colorField.PropertyType);
        }

        /// <summary>
        ///     Tests that sdl vertex tex coordinate field is of type point f
        /// </summary>
        [Fact]
        public void SdlVertex_TexCoordinateField_IsOfTypePointF()
        {
            PropertyInfo texCoordinateField = typeof(Vertex).GetProperty("TexCoordinate");
            Assert.NotNull(texCoordinateField);
            Assert.Equal(typeof(PointF), texCoordinateField.PropertyType);
        }

        /// <summary>
        ///     Tests that sdl vertex position field initializes correctly
        /// </summary>
        [Fact]
        public void SdlVertex_PositionField_InitializesCorrectly()
        {
            Vertex vertex = new Vertex();
            Assert.Equal(new PointF(), vertex.Position);
        }

        /// <summary>
        ///     Tests that sdl vertex color field initializes correctly
        /// </summary>
        [Fact]
        public void SdlVertex_ColorField_InitializesCorrectly()
        {
            Vertex vertex = new Vertex();
            Assert.Equal(new Color(), vertex.Color);
        }

        /// <summary>
        ///     Tests that sdl vertex tex coordinate field initializes correctly
        /// </summary>
        [Fact]
        public void SdlVertex_TexCoordinateField_InitializesCorrectly()
        {
            Vertex vertex = new Vertex();
            Assert.Equal(new PointF(), vertex.TexCoordinate);
        }
    }
}