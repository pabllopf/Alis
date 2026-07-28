// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:VertexArrayTest.cs
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
using Alis.Extension.Graphic.Sfml.Systems;
using Moq;
using Xunit;

namespace Alis.Extension.Graphic.Sfml.Test.Render
{
    /// <summary>
    /// The vertex array test class
    /// </summary>
    public class VertexArrayTest
    {
        /// <summary>
        /// Tests that vertex array is assignable from object base
        /// </summary>
        [Fact]
        public void VertexArray_IsAssignableFromObjectBase()
        {
            Assert.True(typeof(ObjectBase).IsAssignableFrom(typeof(VertexArray)));
        }

        /// <summary>
        /// Tests that vertex array implements i drawable
        /// </summary>
        [Fact]
        public void VertexArray_ImplementsIDrawable()
        {
            Assert.True(typeof(IDrawable).IsAssignableFrom(typeof(VertexArray)));
        }

        /// <summary>
        /// Tests that constructor default c pointer not null
        /// </summary>
        [Fact]
        public void Constructor_Default_CPointerNotNull()
        {
            using VertexArray va = new VertexArray();
            Assert.NotEqual(System.IntPtr.Zero, va.CPointer);
        }

        /// <summary>
        /// Tests that constructor primitive type sets primitive type
        /// </summary>
        [Fact]
        public void Constructor_PrimitiveType_SetsPrimitiveType()
        {
            using VertexArray va = new VertexArray(PrimitiveType.Triangles);
            Assert.Equal(PrimitiveType.Triangles, va.PrimitiveType);
        }

        /// <summary>
        /// Tests that constructor primitive type c pointer not null
        /// </summary>
        [Fact]
        public void Constructor_PrimitiveType_CPointerNotNull()
        {
            using VertexArray va = new VertexArray(PrimitiveType.Lines);
            Assert.NotEqual(System.IntPtr.Zero, va.CPointer);
        }

        /// <summary>
        /// Tests that constructor primitive type and vertex count sets primitive type
        /// </summary>
        [Fact]
        public void Constructor_PrimitiveTypeAndVertexCount_SetsPrimitiveType()
        {
            using VertexArray va = new VertexArray(PrimitiveType.Quads, 4);
            Assert.Equal(PrimitiveType.Quads, va.PrimitiveType);
        }

        /// <summary>
        /// Tests that constructor primitive type and vertex count sets vertex count
        /// </summary>
        [Fact]
        public void Constructor_PrimitiveTypeAndVertexCount_SetsVertexCount()
        {
            using VertexArray va = new VertexArray(PrimitiveType.Points, 3);
            Assert.Equal(3u, va.VertexCount);
        }

        /// <summary>
        /// Tests that constructor copy copies properties
        /// </summary>
        [Fact]
        public void Constructor_Copy_CopiesProperties()
        {
            using VertexArray original = new VertexArray(PrimitiveType.Triangles, 2);
            using VertexArray copy = new VertexArray(original);
            Assert.NotEqual(System.IntPtr.Zero, copy.CPointer);
            Assert.Equal(original.VertexCount, copy.VertexCount);
            Assert.Equal(original.PrimitiveType, copy.PrimitiveType);
        }

        /// <summary>
        /// Tests that vertex count default returns zero
        /// </summary>
        [Fact]
        public void VertexCount_Default_ReturnsZero()
        {
            using VertexArray va = new VertexArray();
            Assert.Equal(0u, va.VertexCount);
        }

        /// <summary>
        /// Tests that vertex count after resize returns correct count
        /// </summary>
        [Fact]
        public void VertexCount_AfterResize_ReturnsCorrectCount()
        {
            using VertexArray va = new VertexArray();
            va.Resize(5);
            Assert.Equal(5u, va.VertexCount);
        }

        /// <summary>
        /// Tests that vertex count after append increments count
        /// </summary>
        [Fact]
        public void VertexCount_AfterAppend_IncrementsCount()
        {
            using VertexArray va = new VertexArray();
            va.Append(new Vertex(new Vector2F(1, 2)));
            Assert.Equal(1u, va.VertexCount);
        }

        /// <summary>
        /// Tests that primitive type get set roundtrips
        /// </summary>
        [Fact]
        public void PrimitiveType_GetSet_Roundtrips()
        {
            using VertexArray va = new VertexArray();
            va.PrimitiveType = PrimitiveType.TriangleStrip;
            Assert.Equal(PrimitiveType.TriangleStrip, va.PrimitiveType);
        }

        /// <summary>
        /// Tests that primitive type default returns points
        /// </summary>
        [Fact]
        public void PrimitiveType_Default_ReturnsPoints()
        {
            using VertexArray va = new VertexArray();
            Assert.Equal(PrimitiveType.Points, va.PrimitiveType);
        }

        /// <summary>
        /// Tests that indexer get returns vertex at position
        /// </summary>
        [Fact]
        public void Indexer_Get_ReturnsVertexAtPosition()
        {
            using VertexArray va = new VertexArray();
            va.Append(new Vertex(new Vector2F(10, 20), Color.Red));
            Vertex v = va[0];
            Assert.Equal(10, v.Position.X);
            Assert.Equal(20, v.Position.Y);
            Assert.Equal(Color.Red, v.Color);
        }

        /// <summary>
        /// Tests that indexer set modifies vertex
        /// </summary>
        [Fact]
        public void Indexer_Set_ModifiesVertex()
        {
            using VertexArray va = new VertexArray();
            va.Append(new Vertex(new Vector2F(0, 0)));
            va[0] = new Vertex(new Vector2F(99, 88), Color.Blue);
            Vertex v = va[0];
            Assert.Equal(99, v.Position.X);
            Assert.Equal(88, v.Position.Y);
            Assert.Equal(Color.Blue, v.Color);
        }

        /// <summary>
        /// Tests that bounds empty array returns zero rect
        /// </summary>
        [Fact]
        public void Bounds_EmptyArray_ReturnsZeroRect()
        {
            using VertexArray va = new VertexArray();
            FloatRect bounds = va.Bounds;
            Assert.Equal(0, bounds.Left);
            Assert.Equal(0, bounds.Top);
            Assert.Equal(0, bounds.Width);
            Assert.Equal(0, bounds.Height);
        }

        /// <summary>
        /// Tests that bounds with vertices returns non empty
        /// </summary>
        [Fact]
        public void Bounds_WithVertices_ReturnsNonEmpty()
        {
            using VertexArray va = new VertexArray();
            va.Append(new Vertex(new Vector2F(0, 0)));
            va.Append(new Vertex(new Vector2F(10, 20)));
            FloatRect bounds = va.Bounds;
            Assert.True(bounds.Width > 0);
            Assert.True(bounds.Height > 0);
        }

        /// <summary>
        /// Tests that clear removes all vertices
        /// </summary>
        [Fact]
        public void Clear_RemovesAllVertices()
        {
            using VertexArray va = new VertexArray();
            va.Append(new Vertex(new Vector2F(1, 2)));
            va.Append(new Vertex(new Vector2F(3, 4)));
            va.Clear();
            Assert.Equal(0u, va.VertexCount);
        }

        /// <summary>
        /// Tests that resize to zero clears array
        /// </summary>
        [Fact]
        public void Resize_ToZero_ClearsArray()
        {
            using VertexArray va = new VertexArray();
            va.Append(new Vertex(new Vector2F(5, 6)));
            va.Resize(0);
            Assert.Equal(0u, va.VertexCount);
        }

        /// <summary>
        /// Tests that resize to larger extends array
        /// </summary>
        [Fact]
        public void Resize_ToLarger_ExtendsArray()
        {
            using VertexArray va = new VertexArray();
            va.Append(new Vertex(new Vector2F(7, 8)));
            va.Resize(3);
            Assert.Equal(3u, va.VertexCount);
        }

        /// <summary>
        /// Tests that append adds vertex at end
        /// </summary>
        [Fact]
        public void Append_AddsVertexAtEnd()
        {
            using VertexArray va = new VertexArray();
            va.Append(new Vertex(new Vector2F(1, 2)));
            va.Append(new Vertex(new Vector2F(3, 4)));
            Assert.Equal(2u, va.VertexCount);
            Assert.Equal(3, va[1].Position.X);
            Assert.Equal(4, va[1].Position.Y);
        }

        /// <summary>
        /// Tests that draw with mock target does not throw
        /// </summary>
        [Fact]
        public void Draw_WithMockTarget_DoesNotThrow()
        {
            using VertexArray va = new VertexArray();
            Mock<IRenderTarget> mockTarget = new Mock<IRenderTarget>();
            RenderStates states = new RenderStates();
            va.Draw(mockTarget.Object, states);
        }

        /// <summary>
        /// Tests that destroy sets c pointer to zero
        /// </summary>
        [Fact]
        public void Destroy_SetsCPointerToZero()
        {
            VertexArray va = new VertexArray();
            Assert.NotEqual(System.IntPtr.Zero, va.CPointer);
            va.Destroy(true);
            Assert.Equal(System.IntPtr.Zero, va.CPointer);
        }

        /// <summary>
        /// Tests that dispose calls destroy
        /// </summary>
        [Fact]
        public void Dispose_CallsDestroy()
        {
            VertexArray va = new VertexArray();
            va.Dispose();
            Assert.Equal(System.IntPtr.Zero, va.CPointer);
        }

        /// <summary>
        /// Tests that constructor default dispose does not throw
        /// </summary>
        [Fact]
        public void Constructor_Default_Dispose_DoesNotThrow()
        {
            VertexArray va = new VertexArray();
            va.Dispose();
        }

        /// <summary>
        /// Tests that primitive type all values can be set
        /// </summary>
        [Fact]
        public void PrimitiveType_AllValues_CanBeSet()
        {
            using VertexArray va = new VertexArray();
            va.PrimitiveType = PrimitiveType.Points;
            Assert.Equal(PrimitiveType.Points, va.PrimitiveType);
            va.PrimitiveType = PrimitiveType.Lines;
            Assert.Equal(PrimitiveType.Lines, va.PrimitiveType);
            va.PrimitiveType = PrimitiveType.LineStrip;
            Assert.Equal(PrimitiveType.LineStrip, va.PrimitiveType);
            va.PrimitiveType = PrimitiveType.Triangles;
            Assert.Equal(PrimitiveType.Triangles, va.PrimitiveType);
            va.PrimitiveType = PrimitiveType.TriangleStrip;
            Assert.Equal(PrimitiveType.TriangleStrip, va.PrimitiveType);
            va.PrimitiveType = PrimitiveType.TriangleFan;
            Assert.Equal(PrimitiveType.TriangleFan, va.PrimitiveType);
            va.PrimitiveType = PrimitiveType.Quads;
            Assert.Equal(PrimitiveType.Quads, va.PrimitiveType);
        }

        /// <summary>
        /// Tests that vertex count property exists
        /// </summary>
        [Fact]
        public void VertexCount_Property_Exists()
        {
            Assert.NotNull(typeof(VertexArray).GetProperty("VertexCount"));
        }

        /// <summary>
        /// Tests that primitive type property exists
        /// </summary>
        [Fact]
        public void PrimitiveType_Property_Exists()
        {
            var prop = typeof(VertexArray).GetProperty("PrimitiveType");
            Assert.NotNull(prop);
            Assert.True(prop.CanRead);
            Assert.True(prop.CanWrite);
        }

        /// <summary>
        /// Tests that bounds property exists
        /// </summary>
        [Fact]
        public void Bounds_Property_Exists()
        {
            Assert.NotNull(typeof(VertexArray).GetProperty("Bounds"));
        }

        /// <summary>
        /// Tests that indexer exists
        /// </summary>
        [Fact]
        public void Indexer_Exists()
        {
            var prop = typeof(VertexArray).GetProperty("Item");
            Assert.NotNull(prop);
        }

        /// <summary>
        /// Tests that clear resize append methods exist
        /// </summary>
        [Fact]
        public void Clear_Resize_Append_Methods_Exist()
        {
            Assert.NotNull(typeof(VertexArray).GetMethod("Clear"));
            Assert.NotNull(typeof(VertexArray).GetMethod("Resize"));
            Assert.NotNull(typeof(VertexArray).GetMethod("Append"));
        }
    }
}
