// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:RenderTextureTest.cs
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

using System;
using Alis.Core.Aspect.Math.Vector;
using Alis.Extension.Graphic.Sfml.Render;
using Alis.Extension.Graphic.Sfml.Systems;
using Alis.Extension.Graphic.Sfml.Windows;
using Xunit;

namespace Alis.Extension.Graphic.Sfml.Test.Render
{
    public class RenderTextureTest
    {
        [Fact]
        public void RenderTexture_ImplementsIRenderTarget()
        {
            Assert.True(typeof(IRenderTarget).IsAssignableFrom(typeof(RenderTexture)));
        }

        [Fact]
        public void RenderTexture_IsAssignableFromObjectBase()
        {
            Assert.True(typeof(ObjectBase).IsAssignableFrom(typeof(RenderTexture)));
        }

        [Fact]
        public void RenderTexture_ImplementsIDisposable()
        {
            Assert.True(typeof(IDisposable).IsAssignableFrom(typeof(RenderTexture)));
        }

        [Fact]
        public void Texture_Property_Exists()
        {
            var prop = typeof(RenderTexture).GetProperty("Texture");
            Assert.NotNull(prop);
        }

        [Fact]
        public void Texture_Property_IsReadOnly()
        {
            var prop = typeof(RenderTexture).GetProperty("Texture");
            Assert.NotNull(prop);
            Assert.True(prop.CanRead);
            Assert.False(prop.CanWrite);
        }

        [Fact]
        public void MaximumAntialiasingLevel_Property_Exists()
        {
            var prop = typeof(RenderTexture).GetProperty("MaximumAntialiasingLevel");
            Assert.NotNull(prop);
        }

        [Fact]
        public void MaximumAntialiasingLevel_Property_IsStatic()
        {
            var prop = typeof(RenderTexture).GetProperty("MaximumAntialiasingLevel");
            Assert.NotNull(prop);
            Assert.True(prop.GetMethod.IsStatic);
        }

        [Fact]
        public void MaximumAntialiasingLevel_Property_IsReadOnly()
        {
            var prop = typeof(RenderTexture).GetProperty("MaximumAntialiasingLevel");
            Assert.NotNull(prop);
            Assert.True(prop.CanRead);
            Assert.False(prop.CanWrite);
        }

        [Fact]
        public void Repeated_Property_Exists()
        {
            Assert.NotNull(typeof(RenderTexture).GetProperty("Repeated"));
        }

        [Fact]
        public void Repeated_Property_IsReadWrite()
        {
            var prop = typeof(RenderTexture).GetProperty("Repeated");
            Assert.NotNull(prop);
            Assert.True(prop.CanRead);
            Assert.True(prop.CanWrite);
        }

        [Fact]
        public void Smooth_Property_Exists()
        {
            Assert.NotNull(typeof(RenderTexture).GetProperty("Smooth"));
        }

        [Fact]
        public void Smooth_Property_IsReadWrite()
        {
            var prop = typeof(RenderTexture).GetProperty("Smooth");
            Assert.NotNull(prop);
            Assert.True(prop.CanRead);
            Assert.True(prop.CanWrite);
        }

        [Fact]
        public void Size_Property_Exists()
        {
            Assert.NotNull(typeof(RenderTexture).GetProperty("Size"));
        }

        [Fact]
        public void Size_Property_IsReadOnly()
        {
            var prop = typeof(RenderTexture).GetProperty("Size");
            Assert.NotNull(prop);
            Assert.True(prop.CanRead);
            Assert.False(prop.CanWrite);
        }

        [Fact]
        public void DefaultView_Property_Exists()
        {
            Assert.NotNull(typeof(RenderTexture).GetProperty("DefaultView"));
        }

        [Fact]
        public void DefaultView_Property_IsReadOnly()
        {
            var prop = typeof(RenderTexture).GetProperty("DefaultView");
            Assert.NotNull(prop);
            Assert.True(prop.CanRead);
            Assert.False(prop.CanWrite);
        }

        [Fact]
        public void GetView_Method_Exists()
        {
            Assert.NotNull(typeof(RenderTexture).GetMethod("GetView", Type.EmptyTypes));
        }

        [Fact]
        public void SetView_Method_Exists()
        {
            Assert.NotNull(typeof(RenderTexture).GetMethod("SetView", new[] { typeof(View) }));
        }

        [Fact]
        public void GetViewport_Method_Exists()
        {
            Assert.NotNull(typeof(RenderTexture).GetMethod("GetViewport", new[] { typeof(View) }));
        }

        [Fact]
        public void MapPixelToCoords_WithPoint_Exists()
        {
            Assert.NotNull(typeof(RenderTexture).GetMethod("MapPixelToCoords", new[] { typeof(Vector2F) }));
        }

        [Fact]
        public void MapPixelToCoords_WithPointAndView_Exists()
        {
            Assert.NotNull(typeof(RenderTexture).GetMethod("MapPixelToCoords", new[] { typeof(Vector2F), typeof(View) }));
        }

        [Fact]
        public void MapCoordsToPixel_WithPoint_Exists()
        {
            Assert.NotNull(typeof(RenderTexture).GetMethod("MapCoordsToPixel", new[] { typeof(Vector2F) }));
        }

        [Fact]
        public void MapCoordsToPixel_WithPointAndView_Exists()
        {
            Assert.NotNull(typeof(RenderTexture).GetMethod("MapCoordsToPixel", new[] { typeof(Vector2F), typeof(View) }));
        }

        [Fact]
        public void Clear_NoArgs_Exists()
        {
            Assert.NotNull(typeof(RenderTexture).GetMethod("Clear", Type.EmptyTypes));
        }

        [Fact]
        public void Clear_WithColor_Exists()
        {
            Assert.NotNull(typeof(RenderTexture).GetMethod("Clear", new[] { typeof(Color) }));
        }

        [Fact]
        public void Draw_WithIDrawable_Exists()
        {
            Assert.NotNull(typeof(RenderTexture).GetMethod("Draw", new[] { typeof(IDrawable) }));
        }

        [Fact]
        public void Draw_WithIDrawableAndStates_Exists()
        {
            Assert.NotNull(typeof(RenderTexture).GetMethod("Draw", new[] { typeof(IDrawable), typeof(RenderStates) }));
        }

        [Fact]
        public void Draw_WithVertexArrayAndType_Exists()
        {
            Assert.NotNull(typeof(RenderTexture).GetMethod("Draw", new[] { typeof(Vertex[]), typeof(PrimitiveType) }));
        }

        [Fact]
        public void Draw_WithVertexArrayTypeAndStates_Exists()
        {
            Assert.NotNull(typeof(RenderTexture).GetMethod("Draw", new[] { typeof(Vertex[]), typeof(PrimitiveType), typeof(RenderStates) }));
        }

        [Fact]
        public void Draw_WithVertexArrayStartCountType_Exists()
        {
            Assert.NotNull(typeof(RenderTexture).GetMethod("Draw", new[] { typeof(Vertex[]), typeof(uint), typeof(uint), typeof(PrimitiveType) }));
        }

        [Fact]
        public void Draw_WithVertexArrayStartCountTypeAndStates_Exists()
        {
            Assert.NotNull(typeof(RenderTexture).GetMethod("Draw", new[] { typeof(Vertex[]), typeof(uint), typeof(uint), typeof(PrimitiveType), typeof(RenderStates) }));
        }

        [Fact]
        public void PushGlStates_Method_Exists()
        {
            Assert.NotNull(typeof(RenderTexture).GetMethod("PushGlStates", Type.EmptyTypes));
        }

        [Fact]
        public void PopGlStates_Method_Exists()
        {
            Assert.NotNull(typeof(RenderTexture).GetMethod("PopGlStates", Type.EmptyTypes));
        }

        [Fact]
        public void ResetGlStates_Method_Exists()
        {
            Assert.NotNull(typeof(RenderTexture).GetMethod("ResetGlStates", Type.EmptyTypes));
        }

        [Fact]
        public void SetActive_Method_Exists()
        {
            Assert.NotNull(typeof(RenderTexture).GetMethod("SetActive", new[] { typeof(bool) }));
        }

        [Fact]
        public void GenerateMipmap_Method_Exists()
        {
            Assert.NotNull(typeof(RenderTexture).GetMethod("GenerateMipmap", Type.EmptyTypes));
        }

        [Fact]
        public void Display_Method_Exists()
        {
            Assert.NotNull(typeof(RenderTexture).GetMethod("Display", Type.EmptyTypes));
        }

        [Fact]
        public void ToString_Method_Exists()
        {
            Assert.NotNull(typeof(RenderTexture).GetMethod("ToString", Type.EmptyTypes));
        }

        [Fact]
        public void ToString_IsOverride()
        {
            var method = typeof(RenderTexture).GetMethod("ToString", Type.EmptyTypes);
            Assert.NotNull(method);
            Assert.True(method.IsVirtual);
            Assert.NotEqual(method.GetBaseDefinition(), method);
        }

        [Fact]
        public void Destroy_Method_Exists()
        {
            Assert.NotNull(typeof(RenderTexture).GetMethod("Destroy", new[] { typeof(bool) }));
        }

        [Fact]
        public void Destroy_IsOverride()
        {
            var method = typeof(RenderTexture).GetMethod("Destroy", new[] { typeof(bool) });
            Assert.NotNull(method);
            Assert.True(method.IsVirtual);
            Assert.NotEqual(method.GetBaseDefinition(), method);
        }

        [Fact]
        public void Constructor_WidthHeight_Exists()
        {
            Assert.NotNull(typeof(RenderTexture).GetConstructor(new[] { typeof(uint), typeof(uint) }));
        }

        [Fact]
        public void Constructor_WidthHeightDepthBuffer_Exists()
        {
            Assert.NotNull(typeof(RenderTexture).GetConstructor(new[] { typeof(uint), typeof(uint), typeof(bool) }));
        }

        [Fact]
        public void Constructor_WidthHeightContextSettings_Exists()
        {
            Assert.NotNull(typeof(RenderTexture).GetConstructor(new[] { typeof(uint), typeof(uint), typeof(ContextSettings) }));
        }
    }
}
