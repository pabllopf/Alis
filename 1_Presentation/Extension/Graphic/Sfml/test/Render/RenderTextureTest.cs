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
using Alis.Extension.Graphic.Sfml.Test.Attributes;
using Alis.Extension.Graphic.Sfml.Windows;
using Xunit;

namespace Alis.Extension.Graphic.Sfml.Test.Render
{
    /// <summary>
    /// The render texture test class
    /// </summary>
    public class RenderTextureTest
    {
        /// <summary>
        /// Tests that render texture implements i render target
        /// </summary>
        [RequireCSfmlSystemFact]
        public void RenderTexture_ImplementsIRenderTarget()
        {
            Assert.True(typeof(IRenderTarget).IsAssignableFrom(typeof(RenderTexture)));
        }

        /// <summary>
        /// Tests that render texture is assignable from object base
        /// </summary>
        [RequireCSfmlSystemFact]
        public void RenderTexture_IsAssignableFromObjectBase()
        {
            Assert.True(typeof(ObjectBase).IsAssignableFrom(typeof(RenderTexture)));
        }

        /// <summary>
        /// Tests that render texture implements i disposable
        /// </summary>
        [RequireCSfmlSystemFact]
        public void RenderTexture_ImplementsIDisposable()
        {
            Assert.True(typeof(IDisposable).IsAssignableFrom(typeof(RenderTexture)));
        }

        /// <summary>
        /// Tests that texture property exists
        /// </summary>
        [RequireCSfmlSystemFact]
        public void Texture_Property_Exists()
        {
            var prop = typeof(RenderTexture).GetProperty("Texture");
            Assert.NotNull(prop);
        }

        /// <summary>
        /// Tests that texture property is read only
        /// </summary>
        [RequireCSfmlSystemFact]
        public void Texture_Property_IsReadOnly()
        {
            var prop = typeof(RenderTexture).GetProperty("Texture");
            Assert.NotNull(prop);
            Assert.True(prop.CanRead);
            Assert.False(prop.CanWrite);
        }

        /// <summary>
        /// Tests that maximum antialiasing level property exists
        /// </summary>
        [RequireCSfmlSystemFact]
        public void MaximumAntialiasingLevel_Property_Exists()
        {
            var prop = typeof(RenderTexture).GetProperty("MaximumAntialiasingLevel");
            Assert.NotNull(prop);
        }

        /// <summary>
        /// Tests that maximum antialiasing level property is static
        /// </summary>
        [RequireCSfmlSystemFact]
        public void MaximumAntialiasingLevel_Property_IsStatic()
        {
            var prop = typeof(RenderTexture).GetProperty("MaximumAntialiasingLevel");
            Assert.NotNull(prop);
            Assert.True(prop.GetMethod.IsStatic);
        }

        /// <summary>
        /// Tests that maximum antialiasing level property is read only
        /// </summary>
        [RequireCSfmlSystemFact]
        public void MaximumAntialiasingLevel_Property_IsReadOnly()
        {
            var prop = typeof(RenderTexture).GetProperty("MaximumAntialiasingLevel");
            Assert.NotNull(prop);
            Assert.True(prop.CanRead);
            Assert.False(prop.CanWrite);
        }

        /// <summary>
        /// Tests that repeated property exists
        /// </summary>
        [RequireCSfmlSystemFact]
        public void Repeated_Property_Exists()
        {
            Assert.NotNull(typeof(RenderTexture).GetProperty("Repeated"));
        }

        /// <summary>
        /// Tests that repeated property is read write
        /// </summary>
        [RequireCSfmlSystemFact]
        public void Repeated_Property_IsReadWrite()
        {
            var prop = typeof(RenderTexture).GetProperty("Repeated");
            Assert.NotNull(prop);
            Assert.True(prop.CanRead);
            Assert.True(prop.CanWrite);
        }

        /// <summary>
        /// Tests that smooth property exists
        /// </summary>
        [RequireCSfmlSystemFact]
        public void Smooth_Property_Exists()
        {
            Assert.NotNull(typeof(RenderTexture).GetProperty("Smooth"));
        }

        /// <summary>
        /// Tests that smooth property is read write
        /// </summary>
        [RequireCSfmlSystemFact]
        public void Smooth_Property_IsReadWrite()
        {
            var prop = typeof(RenderTexture).GetProperty("Smooth");
            Assert.NotNull(prop);
            Assert.True(prop.CanRead);
            Assert.True(prop.CanWrite);
        }

        /// <summary>
        /// Tests that size property exists
        /// </summary>
        [RequireCSfmlSystemFact]
        public void Size_Property_Exists()
        {
            Assert.NotNull(typeof(RenderTexture).GetProperty("Size"));
        }

        /// <summary>
        /// Tests that size property is read only
        /// </summary>
        [RequireCSfmlSystemFact]
        public void Size_Property_IsReadOnly()
        {
            var prop = typeof(RenderTexture).GetProperty("Size");
            Assert.NotNull(prop);
            Assert.True(prop.CanRead);
            Assert.False(prop.CanWrite);
        }

        /// <summary>
        /// Tests that default view property exists
        /// </summary>
        [RequireCSfmlSystemFact]
        public void DefaultView_Property_Exists()
        {
            Assert.NotNull(typeof(RenderTexture).GetProperty("DefaultView"));
        }

        /// <summary>
        /// Tests that default view property is read only
        /// </summary>
        [RequireCSfmlSystemFact]
        public void DefaultView_Property_IsReadOnly()
        {
            var prop = typeof(RenderTexture).GetProperty("DefaultView");
            Assert.NotNull(prop);
            Assert.True(prop.CanRead);
            Assert.False(prop.CanWrite);
        }

        /// <summary>
        /// Tests that get view method exists
        /// </summary>
        [RequireCSfmlSystemFact]
        public void GetView_Method_Exists()
        {
            Assert.NotNull(typeof(RenderTexture).GetMethod("GetView", Type.EmptyTypes));
        }

        /// <summary>
        /// Tests that set view method exists
        /// </summary>
        [RequireCSfmlSystemFact]
        public void SetView_Method_Exists()
        {
            Assert.NotNull(typeof(RenderTexture).GetMethod("SetView", new[] { typeof(View) }));
        }

        /// <summary>
        /// Tests that get viewport method exists
        /// </summary>
        [RequireCSfmlSystemFact]
        public void GetViewport_Method_Exists()
        {
            Assert.NotNull(typeof(RenderTexture).GetMethod("GetViewport", new[] { typeof(View) }));
        }

        /// <summary>
        /// Tests that map pixel to coords with point exists
        /// </summary>
        [RequireCSfmlSystemFact]
        public void MapPixelToCoords_WithPoint_Exists()
        {
            Assert.NotNull(typeof(RenderTexture).GetMethod("MapPixelToCoords", new[] { typeof(Vector2F) }));
        }

        /// <summary>
        /// Tests that map pixel to coords with point and view exists
        /// </summary>
        [RequireCSfmlSystemFact]
        public void MapPixelToCoords_WithPointAndView_Exists()
        {
            Assert.NotNull(typeof(RenderTexture).GetMethod("MapPixelToCoords", new[] { typeof(Vector2F), typeof(View) }));
        }

        /// <summary>
        /// Tests that map coords to pixel with point exists
        /// </summary>
        [RequireCSfmlSystemFact]
        public void MapCoordsToPixel_WithPoint_Exists()
        {
            Assert.NotNull(typeof(RenderTexture).GetMethod("MapCoordsToPixel", new[] { typeof(Vector2F) }));
        }

        /// <summary>
        /// Tests that map coords to pixel with point and view exists
        /// </summary>
        [RequireCSfmlSystemFact]
        public void MapCoordsToPixel_WithPointAndView_Exists()
        {
            Assert.NotNull(typeof(RenderTexture).GetMethod("MapCoordsToPixel", new[] { typeof(Vector2F), typeof(View) }));
        }

        /// <summary>
        /// Tests that clear no args exists
        /// </summary>
        [RequireCSfmlSystemFact]
        public void Clear_NoArgs_Exists()
        {
            Assert.NotNull(typeof(RenderTexture).GetMethod("Clear", Type.EmptyTypes));
        }

        /// <summary>
        /// Tests that clear with color exists
        /// </summary>
        [RequireCSfmlSystemFact]
        public void Clear_WithColor_Exists()
        {
            Assert.NotNull(typeof(RenderTexture).GetMethod("Clear", new[] { typeof(Color) }));
        }

        /// <summary>
        /// Tests that draw with i drawable exists
        /// </summary>
        [RequireCSfmlSystemFact]
        public void Draw_WithIDrawable_Exists()
        {
            Assert.NotNull(typeof(RenderTexture).GetMethod("Draw", new[] { typeof(IDrawable) }));
        }

        /// <summary>
        /// Tests that draw with i drawable and states exists
        /// </summary>
        [RequireCSfmlSystemFact]
        public void Draw_WithIDrawableAndStates_Exists()
        {
            Assert.NotNull(typeof(RenderTexture).GetMethod("Draw", new[] { typeof(IDrawable), typeof(RenderStates) }));
        }

        /// <summary>
        /// Tests that draw with vertex array and type exists
        /// </summary>
        [RequireCSfmlSystemFact]
        public void Draw_WithVertexArrayAndType_Exists()
        {
            Assert.NotNull(typeof(RenderTexture).GetMethod("Draw", new[] { typeof(Vertex[]), typeof(PrimitiveType) }));
        }

        /// <summary>
        /// Tests that draw with vertex array type and states exists
        /// </summary>
        [RequireCSfmlSystemFact]
        public void Draw_WithVertexArrayTypeAndStates_Exists()
        {
            Assert.NotNull(typeof(RenderTexture).GetMethod("Draw", new[] { typeof(Vertex[]), typeof(PrimitiveType), typeof(RenderStates) }));
        }

        /// <summary>
        /// Tests that draw with vertex array start count type exists
        /// </summary>
        [RequireCSfmlSystemFact]
        public void Draw_WithVertexArrayStartCountType_Exists()
        {
            Assert.NotNull(typeof(RenderTexture).GetMethod("Draw", new[] { typeof(Vertex[]), typeof(uint), typeof(uint), typeof(PrimitiveType) }));
        }

        /// <summary>
        /// Tests that draw with vertex array start count type and states exists
        /// </summary>
        [RequireCSfmlSystemFact]
        public void Draw_WithVertexArrayStartCountTypeAndStates_Exists()
        {
            Assert.NotNull(typeof(RenderTexture).GetMethod("Draw", new[] { typeof(Vertex[]), typeof(uint), typeof(uint), typeof(PrimitiveType), typeof(RenderStates) }));
        }

        /// <summary>
        /// Tests that push gl states method exists
        /// </summary>
        [RequireCSfmlSystemFact]
        public void PushGlStates_Method_Exists()
        {
            Assert.NotNull(typeof(RenderTexture).GetMethod("PushGlStates", Type.EmptyTypes));
        }

        /// <summary>
        /// Tests that pop gl states method exists
        /// </summary>
        [RequireCSfmlSystemFact]
        public void PopGlStates_Method_Exists()
        {
            Assert.NotNull(typeof(RenderTexture).GetMethod("PopGlStates", Type.EmptyTypes));
        }

        /// <summary>
        /// Tests that reset gl states method exists
        /// </summary>
        [RequireCSfmlSystemFact]
        public void ResetGlStates_Method_Exists()
        {
            Assert.NotNull(typeof(RenderTexture).GetMethod("ResetGlStates", Type.EmptyTypes));
        }

        /// <summary>
        /// Tests that set active method exists
        /// </summary>
        [RequireCSfmlSystemFact]
        public void SetActive_Method_Exists()
        {
            Assert.NotNull(typeof(RenderTexture).GetMethod("SetActive", new[] { typeof(bool) }));
        }

        /// <summary>
        /// Tests that generate mipmap method exists
        /// </summary>
        [RequireCSfmlSystemFact]
        public void GenerateMipmap_Method_Exists()
        {
            Assert.NotNull(typeof(RenderTexture).GetMethod("GenerateMipmap", Type.EmptyTypes));
        }

        /// <summary>
        /// Tests that display method exists
        /// </summary>
        [RequireCSfmlSystemFact]
        public void Display_Method_Exists()
        {
            Assert.NotNull(typeof(RenderTexture).GetMethod("Display", Type.EmptyTypes));
        }

        /// <summary>
        /// Tests that to string method exists
        /// </summary>
        [RequireCSfmlSystemFact]
        public void ToString_Method_Exists()
        {
            Assert.NotNull(typeof(RenderTexture).GetMethod("ToString", Type.EmptyTypes));
        }

        /// <summary>
        /// Tests that to string is override
        /// </summary>
        [RequireCSfmlSystemFact]
        public void ToString_IsOverride()
        {
            var method = typeof(RenderTexture).GetMethod("ToString", Type.EmptyTypes);
            Assert.NotNull(method);
            Assert.True(method.IsVirtual);
            Assert.NotEqual(method.GetBaseDefinition(), method);
        }

        /// <summary>
        /// Tests that destroy method exists
        /// </summary>
        [RequireCSfmlSystemFact]
        public void Destroy_Method_Exists()
        {
            Assert.NotNull(typeof(RenderTexture).GetMethod("Destroy", new[] { typeof(bool) }));
        }

        /// <summary>
        /// Tests that destroy is override
        /// </summary>
        [RequireCSfmlSystemFact]
        public void Destroy_IsOverride()
        {
            var method = typeof(RenderTexture).GetMethod("Destroy", new[] { typeof(bool) });
            Assert.NotNull(method);
            Assert.True(method.IsVirtual);
            Assert.NotEqual(method.GetBaseDefinition(), method);
        }

        /// <summary>
        /// Tests that constructor width height exists
        /// </summary>
        [RequireCSfmlSystemFact]
        public void Constructor_WidthHeight_Exists()
        {
            Assert.NotNull(typeof(RenderTexture).GetConstructor(new[] { typeof(uint), typeof(uint) }));
        }

        /// <summary>
        /// Tests that constructor width height depth buffer exists
        /// </summary>
        [RequireCSfmlSystemFact]
        public void Constructor_WidthHeightDepthBuffer_Exists()
        {
            Assert.NotNull(typeof(RenderTexture).GetConstructor(new[] { typeof(uint), typeof(uint), typeof(bool) }));
        }

        /// <summary>
        /// Tests that constructor width height context settings exists
        /// </summary>
        [RequireCSfmlSystemFact]
        public void Constructor_WidthHeightContextSettings_Exists()
        {
            Assert.NotNull(typeof(RenderTexture).GetConstructor(new[] { typeof(uint), typeof(uint), typeof(ContextSettings) }));
        }
    }
}
