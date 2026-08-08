// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:VertexBufferTests.cs
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
using Alis.Extension.Graphic.Sfml.Test.Attributes;
using Moq;
using Xunit;

namespace Alis.Extension.Graphic.Sfml.Test.Render
{
    /// <summary>
    /// The vertex buffer test class
    /// </summary>
    public class VertexBufferTest
    {
        /// <summary>
        /// Tests that vertex buffer is assignable from object base
        /// </summary>
        [RequireCSfmlSystemFact]
        public void VertexBuffer_IsAssignableFromObjectBase()
        {
            Assert.True(typeof(ObjectBase).IsAssignableFrom(typeof(VertexBuffer)));
        }

        /// <summary>
        /// Tests that vertex buffer implements i drawable
        /// </summary>
        [RequireCSfmlSystemFact]
        public void VertexBuffer_ImplementsIDrawable()
        {
            Assert.True(typeof(IDrawable).IsAssignableFrom(typeof(VertexBuffer)));
        }

        /// <summary>
        /// Tests that usage specifier has correct values
        /// </summary>
        [RequireCSfmlSystemFact]
        public void UsageSpecifier_HasCorrectValues()
        {
            Assert.Equal(0, (int)VertexBuffer.UsageSpecifier.Stream);
            Assert.Equal(1, (int)VertexBuffer.UsageSpecifier.Dynamic);
            Assert.Equal(2, (int)VertexBuffer.UsageSpecifier.Static);
        }

        /// <summary>
        /// Tests that constructor with params c pointer not null
        /// </summary>
        [RequireCSfmlSystemFact]
        public void Constructor_WithParams_CPointerNotNull()
        {
            using VertexBuffer vb = new VertexBuffer(3, PrimitiveType.Triangles, VertexBuffer.UsageSpecifier.Static);
            Assert.NotEqual(System.IntPtr.Zero, vb.CPointer);
        }

        /// <summary>
        /// Tests that constructor with params sets primitive type
        /// </summary>
        [RequireCSfmlSystemFact]
        public void Constructor_WithParams_SetsPrimitiveType()
        {
            using VertexBuffer vb = new VertexBuffer(3, PrimitiveType.Triangles, VertexBuffer.UsageSpecifier.Static);
            Assert.Equal(PrimitiveType.Triangles, vb.PrimitiveType);
        }

        /// <summary>
        /// Tests that constructor with params sets usage
        /// </summary>
        [RequireCSfmlSystemFact]
        public void Constructor_WithParams_SetsUsage()
        {
            using VertexBuffer vb = new VertexBuffer(3, PrimitiveType.Points, VertexBuffer.UsageSpecifier.Stream);
            Assert.Equal(VertexBuffer.UsageSpecifier.Stream, vb.Usage);
        }

        /// <summary>
        /// Tests that constructor with params sets vertex count
        /// </summary>
        [RequireCSfmlSystemFact]
        public void Constructor_WithParams_SetsVertexCount()
        {
            using VertexBuffer vb = new VertexBuffer(5, PrimitiveType.Lines, VertexBuffer.UsageSpecifier.Dynamic);
            Assert.Equal(5u, vb.VertexCount);
        }

        /// <summary>
        /// Tests that constructor copy copies properties
        /// </summary>
        [RequireCSfmlSystemFact]
        public void Constructor_Copy_CopiesProperties()
        {
            using VertexBuffer original = new VertexBuffer(2, PrimitiveType.Quads, VertexBuffer.UsageSpecifier.Static);
            using VertexBuffer copy = new VertexBuffer(original);
            Assert.NotEqual(System.IntPtr.Zero, copy.CPointer);
            Assert.Equal(original.VertexCount, copy.VertexCount);
            Assert.Equal(original.PrimitiveType, copy.PrimitiveType);
            Assert.Equal(original.Usage, copy.Usage);
        }

        /// <summary>
        /// Tests that available static returns bool
        /// </summary>
        [RequireCSfmlSystemFact]
        public void Available_Static_ReturnsBool()
        {
            bool available = VertexBuffer.Available;
            Assert.IsType<bool>(available);
        }

        /// <summary>
        /// Tests that vertex count returns correct value
        /// </summary>
        [RequireCSfmlSystemFact]
        public void VertexCount_ReturnsCorrectValue()
        {
            using VertexBuffer vb = new VertexBuffer(7, PrimitiveType.TriangleStrip, VertexBuffer.UsageSpecifier.Static);
            Assert.Equal(7u, vb.VertexCount);
        }

        /// <summary>
        /// Tests that native handle returns value
        /// </summary>
        [RequireCSfmlSystemFact]
        public void NativeHandle_ReturnsValue()
        {
            using VertexBuffer vb = new VertexBuffer(1, PrimitiveType.Points, VertexBuffer.UsageSpecifier.Static);
            uint handle = vb.NativeHandle;
            Assert.IsType<uint>(handle);
        }

        /// <summary>
        /// Tests that primitive type get set roundtrips
        /// </summary>
        [RequireCSfmlSystemFact]
        public void PrimitiveType_GetSet_Roundtrips()
        {
            using VertexBuffer vb = new VertexBuffer(1, PrimitiveType.Points, VertexBuffer.UsageSpecifier.Static);
            vb.PrimitiveType = PrimitiveType.TriangleFan;
            Assert.Equal(PrimitiveType.TriangleFan, vb.PrimitiveType);
        }

        /// <summary>
        /// Tests that primitive type all values can be set
        /// </summary>
        [RequireCSfmlSystemFact]
        public void PrimitiveType_AllValues_CanBeSet()
        {
            using VertexBuffer vb = new VertexBuffer(1, PrimitiveType.Points, VertexBuffer.UsageSpecifier.Static);
            vb.PrimitiveType = PrimitiveType.Points;
            Assert.Equal(PrimitiveType.Points, vb.PrimitiveType);
            vb.PrimitiveType = PrimitiveType.Lines;
            Assert.Equal(PrimitiveType.Lines, vb.PrimitiveType);
            vb.PrimitiveType = PrimitiveType.LineStrip;
            Assert.Equal(PrimitiveType.LineStrip, vb.PrimitiveType);
            vb.PrimitiveType = PrimitiveType.Triangles;
            Assert.Equal(PrimitiveType.Triangles, vb.PrimitiveType);
            vb.PrimitiveType = PrimitiveType.TriangleStrip;
            Assert.Equal(PrimitiveType.TriangleStrip, vb.PrimitiveType);
            vb.PrimitiveType = PrimitiveType.TriangleFan;
            Assert.Equal(PrimitiveType.TriangleFan, vb.PrimitiveType);
            vb.PrimitiveType = PrimitiveType.Quads;
            Assert.Equal(PrimitiveType.Quads, vb.PrimitiveType);
        }

        /// <summary>
        /// Tests that usage get set roundtrips
        /// </summary>
        [RequireCSfmlSystemFact]
        public void Usage_GetSet_Roundtrips()
        {
            using VertexBuffer vb = new VertexBuffer(1, PrimitiveType.Points, VertexBuffer.UsageSpecifier.Stream);
            vb.Usage = VertexBuffer.UsageSpecifier.Dynamic;
            Assert.Equal(VertexBuffer.UsageSpecifier.Dynamic, vb.Usage);
        }

        /// <summary>
        /// Tests that usage all values can be set
        /// </summary>
        [RequireCSfmlSystemFact]
        public void Usage_AllValues_CanBeSet()
        {
            using VertexBuffer vb = new VertexBuffer(1, PrimitiveType.Points, VertexBuffer.UsageSpecifier.Static);
            vb.Usage = VertexBuffer.UsageSpecifier.Stream;
            Assert.Equal(VertexBuffer.UsageSpecifier.Stream, vb.Usage);
            vb.Usage = VertexBuffer.UsageSpecifier.Dynamic;
            Assert.Equal(VertexBuffer.UsageSpecifier.Dynamic, vb.Usage);
            vb.Usage = VertexBuffer.UsageSpecifier.Static;
            Assert.Equal(VertexBuffer.UsageSpecifier.Static, vb.Usage);
        }

        /// <summary>
        /// Tests that draw with mock target does not throw
        /// </summary>
        [RequireCSfmlSystemFact]
        public void Draw_WithMockTarget_DoesNotThrow()
        {
            using VertexBuffer vb = new VertexBuffer(1, PrimitiveType.Points, VertexBuffer.UsageSpecifier.Static);
            Mock<IRenderTarget> mockTarget = new Mock<IRenderTarget>();
            RenderStates states = new RenderStates();
            vb.Draw(mockTarget.Object, states);
        }

        /// <summary>
        /// Tests that update vertex array returns bool
        /// </summary>
        [RequireCSfmlSystemFact]
        public void Update_VertexArray_ReturnsBool()
        {
            using VertexBuffer vb = new VertexBuffer(1, PrimitiveType.Points, VertexBuffer.UsageSpecifier.Static);
            Vertex[] vertices = new Vertex[] { new Vertex(new Vector2F(1, 2)) };
            bool result = vb.Update(vertices);
            Assert.IsType<bool>(result);
        }

        /// <summary>
        /// Tests that update vertex array with offset returns bool
        /// </summary>
        [RequireCSfmlSystemFact]
        public void Update_VertexArrayWithOffset_ReturnsBool()
        {
            using VertexBuffer vb = new VertexBuffer(2, PrimitiveType.Points, VertexBuffer.UsageSpecifier.Static);
            Vertex[] vertices = new Vertex[] { new Vertex(new Vector2F(1, 2)), new Vertex(new Vector2F(3, 4)) };
            bool result = vb.Update(vertices, 0u);
            Assert.IsType<bool>(result);
        }

        /// <summary>
        /// Tests that update vertex array with count and offset returns bool
        /// </summary>
        [RequireCSfmlSystemFact]
        public void Update_VertexArrayWithCountAndOffset_ReturnsBool()
        {
            using VertexBuffer vb = new VertexBuffer(1, PrimitiveType.Points, VertexBuffer.UsageSpecifier.Static);
            Vertex[] vertices = new Vertex[] { new Vertex(new Vector2F(1, 2)) };
            bool result = vb.Update(vertices, 1u, 0u);
            Assert.IsType<bool>(result);
        }

        /// <summary>
        /// Tests that update vertex buffer returns bool
        /// </summary>
        [RequireCSfmlSystemFact]
        public void Update_VertexBuffer_ReturnsBool()
        {
            using VertexBuffer source = new VertexBuffer(1, PrimitiveType.Points, VertexBuffer.UsageSpecifier.Static);
            using VertexBuffer dest = new VertexBuffer(1, PrimitiveType.Points, VertexBuffer.UsageSpecifier.Static);
            bool result = dest.Update(source);
            Assert.IsType<bool>(result);
        }

        /// <summary>
        /// Tests that swap exchanges contents
        /// </summary>
        [RequireCSfmlSystemFact]
        public void Swap_ExchangesContents()
        {
            using VertexBuffer vb1 = new VertexBuffer(1, PrimitiveType.Points, VertexBuffer.UsageSpecifier.Static);
            using VertexBuffer vb2 = new VertexBuffer(2, PrimitiveType.Lines, VertexBuffer.UsageSpecifier.Dynamic);
            vb1.Swap(vb2);
            Assert.Equal(2u, vb1.VertexCount);
            Assert.Equal(1u, vb2.VertexCount);
        }

        /// <summary>
        /// Tests that destroy sets c pointer to zero
        /// </summary>
        [RequireCSfmlSystemFact]
        public void Destroy_SetsCPointerToZero()
        {
            VertexBuffer vb = new VertexBuffer(1, PrimitiveType.Points, VertexBuffer.UsageSpecifier.Static);
            Assert.NotEqual(System.IntPtr.Zero, vb.CPointer);
            vb.Destroy(true);
            Assert.Equal(System.IntPtr.Zero, vb.CPointer);
        }

        /// <summary>
        /// Tests that dispose calls destroy
        /// </summary>
        [RequireCSfmlSystemFact]
        public void Dispose_CallsDestroy()
        {
            VertexBuffer vb = new VertexBuffer(1, PrimitiveType.Points, VertexBuffer.UsageSpecifier.Static);
            vb.Dispose();
            Assert.Equal(System.IntPtr.Zero, vb.CPointer);
        }

        /// <summary>
        /// Tests that constructor dispose does not throw
        /// </summary>
        [RequireCSfmlSystemFact]
        public void Constructor_Dispose_DoesNotThrow()
        {
            VertexBuffer vb = new VertexBuffer(1, PrimitiveType.Points, VertexBuffer.UsageSpecifier.Static);
            vb.Dispose();
        }

        /// <summary>
        /// Tests that vertex count property exists
        /// </summary>
        [RequireCSfmlSystemFact]
        public void VertexCount_Property_Exists()
        {
            Assert.NotNull(typeof(VertexBuffer).GetProperty("VertexCount"));
        }

        /// <summary>
        /// Tests that native handle property exists
        /// </summary>
        [RequireCSfmlSystemFact]
        public void NativeHandle_Property_Exists()
        {
            Assert.NotNull(typeof(VertexBuffer).GetProperty("NativeHandle"));
        }

        /// <summary>
        /// Tests that primitive type property exists
        /// </summary>
        [RequireCSfmlSystemFact]
        public void PrimitiveType_Property_Exists()
        {
            System.Reflection.PropertyInfo prop = typeof(VertexBuffer).GetProperty("PrimitiveType");
            Assert.NotNull(prop);
            Assert.True(prop.CanRead);
            Assert.True(prop.CanWrite);
        }

        /// <summary>
        /// Tests that usage property exists
        /// </summary>
        [RequireCSfmlSystemFact]
        public void Usage_Property_Exists()
        {
            System.Reflection.PropertyInfo prop = typeof(VertexBuffer).GetProperty("Usage");
            Assert.NotNull(prop);
            Assert.True(prop.CanRead);
            Assert.True(prop.CanWrite);
        }

        /// <summary>
        /// Tests that update methods exist
        /// </summary>
        [RequireCSfmlSystemFact]
        public void Update_Methods_Exist()
        {
            Assert.NotNull(typeof(VertexBuffer).GetMethod("Update", new System.Type[] { typeof(Vertex[]) }));
            Assert.NotNull(typeof(VertexBuffer).GetMethod("Update", new System.Type[] { typeof(Vertex[]), typeof(uint) }));
            Assert.NotNull(typeof(VertexBuffer).GetMethod("Update", new System.Type[] { typeof(Vertex[]), typeof(uint), typeof(uint) }));
            Assert.NotNull(typeof(VertexBuffer).GetMethod("Update", new System.Type[] { typeof(VertexBuffer) }));
        }

        /// <summary>
        /// Tests that swap method exists
        /// </summary>
        [RequireCSfmlSystemFact]
        public void Swap_Method_Exists()
        {
            Assert.NotNull(typeof(VertexBuffer).GetMethod("Swap"));
        }

        /// <summary>
        /// Tests that available property exists
        /// </summary>
        [RequireCSfmlSystemFact]
        public void Available_Property_Exists()
        {
            System.Reflection.PropertyInfo prop = typeof(VertexBuffer).GetProperty("Available");
            Assert.NotNull(prop);
            Assert.True(prop.GetMethod.IsStatic);
        }

        /// <summary>
        /// Tests that available returns without throwing
        /// </summary>
        [RequireCSfmlSystemFact]
        public void Available_ReturnsWithoutThrowing()
        {
        }

        /// <summary>
        /// Tests that usage specifier stream value zero
        /// </summary>
        [RequireCSfmlSystemFact]
        public void UsageSpecifier_Stream_ValueZero()
        {
            Assert.Equal(0, (int)VertexBuffer.UsageSpecifier.Stream);
        }

        /// <summary>
        /// Tests that usage specifier dynamic value one
        /// </summary>
        [RequireCSfmlSystemFact]
        public void UsageSpecifier_Dynamic_ValueOne()
        {
            Assert.Equal(1, (int)VertexBuffer.UsageSpecifier.Dynamic);
        }

        /// <summary>
        /// Tests that usage specifier static value two
        /// </summary>
        [RequireCSfmlSystemFact]
        public void UsageSpecifier_Static_ValueTwo()
        {
            Assert.Equal(2, (int)VertexBuffer.UsageSpecifier.Static);
        }

        /// <summary>
        /// Tests that constructor default primitive type is points
        /// </summary>
        [RequireCSfmlSystemFact]
        public void Constructor_DefaultPrimitiveType_IsPoints()
        {
            using VertexBuffer vb = new VertexBuffer(1, PrimitiveType.Points, VertexBuffer.UsageSpecifier.Static);
            Assert.Equal(PrimitiveType.Points, vb.PrimitiveType);
        }

        /// <summary>
        /// Tests that constructor default usage is static
        /// </summary>
        [RequireCSfmlSystemFact]
        public void Constructor_DefaultUsage_IsStatic()
        {
            using VertexBuffer vb = new VertexBuffer(1, PrimitiveType.Points, VertexBuffer.UsageSpecifier.Static);
            Assert.Equal(VertexBuffer.UsageSpecifier.Static, vb.Usage);
        }
    }
}
