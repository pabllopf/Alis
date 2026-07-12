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

using Alis.Extension.Graphic.Sfml.Render;
using Alis.Extension.Graphic.Sfml.Systems;
using Xunit;

namespace Alis.Extension.Graphic.Sfml.Test.Render
{
    /// <summary>
    ///     Unit tests for the <see cref="RenderTexture"/> class.
    /// </summary>
    public class RenderTextureTest
    {
        /// <summary>
        /// Tests that render texture implements i render target
        /// </summary>
        [Fact]
        public void RenderTexture_ImplementsIRenderTarget()
        {
            Assert.True(typeof(IRenderTarget).IsAssignableFrom(typeof(RenderTexture)));
        }

        /// <summary>
        /// Tests that render texture is assignable from object base
        /// </summary>
        [Fact]
        public void RenderTexture_IsAssignableFromObjectBase()
        {
            Assert.True(typeof(ObjectBase).IsAssignableFrom(typeof(RenderTexture)));
        }

        /// <summary>
        /// Tests that texture property exists
        /// </summary>
        [Fact]
        public void Texture_Property_Exists()
        {
            var prop = typeof(RenderTexture).GetProperty("Texture");
            Assert.NotNull(prop);
            Assert.True(prop.CanRead);
        }

        /// <summary>
        /// Tests that maximum antialiasing level property exists
        /// </summary>
        [Fact]
        public void MaximumAntialiasingLevel_Property_Exists()
        {
            var prop = typeof(RenderTexture).GetProperty("MaximumAntialiasingLevel");
            Assert.NotNull(prop);
            Assert.True(prop.CanRead);
            Assert.True(prop.GetMethod.IsStatic);
        }

        /// <summary>
        /// Tests that repeated smooth properties exist
        /// </summary>
        [Fact]
        public void Repeated_Smooth_Properties_Exist()
        {
            Assert.NotNull(typeof(RenderTexture).GetProperty("Repeated"));
            Assert.NotNull(typeof(RenderTexture).GetProperty("Smooth"));
        }

        /// <summary>
        /// Tests that size default view properties exist
        /// </summary>
        [Fact]
        public void Size_DefaultView_Properties_Exist()
        {
            Assert.NotNull(typeof(RenderTexture).GetProperty("Size"));
            Assert.NotNull(typeof(RenderTexture).GetProperty("DefaultView"));
        }

        /// <summary>
        /// Tests that get view set view methods exist
        /// </summary>
        [Fact]
        public void GetView_SetView_Methods_Exist()
        {
            Assert.NotNull(typeof(RenderTexture).GetMethod("GetView"));
            Assert.NotNull(typeof(RenderTexture).GetMethod("SetView"));
        }

        /// <summary>
        /// Tests that get viewport method exists
        /// </summary>
        [Fact]
        public void GetViewport_Method_Exists()
        {
            Assert.NotNull(typeof(RenderTexture).GetMethod("GetViewport"));
        }

        /// <summary>
        /// Tests that map pixel to coords map coords to pixel methods exist
        /// </summary>
        [Fact]
        public void MapPixelToCoords_MapCoordsToPixel_Methods_Exist()
        {
            Assert.NotNull(typeof(RenderTexture).GetMethod("MapPixelToCoords", new[] { typeof(Alis.Core.Aspect.Math.Vector.Vector2F) }));
            Assert.NotNull(typeof(RenderTexture).GetMethod("MapPixelToCoords", new[] { typeof(Alis.Core.Aspect.Math.Vector.Vector2F), typeof(View) }));
            Assert.NotNull(typeof(RenderTexture).GetMethod("MapCoordsToPixel", new[] { typeof(Alis.Core.Aspect.Math.Vector.Vector2F) }));
            Assert.NotNull(typeof(RenderTexture).GetMethod("MapCoordsToPixel", new[] { typeof(Alis.Core.Aspect.Math.Vector.Vector2F), typeof(View) }));
        }

        /// <summary>
        /// Tests that clear draw methods exist
        /// </summary>
        [Fact]
        public void Clear_Draw_Methods_Exist()
        {
            Assert.NotNull(typeof(RenderTexture).GetMethod("Clear", System.Type.EmptyTypes));
            Assert.NotNull(typeof(RenderTexture).GetMethod("Clear", new[] { typeof(Color) }));
            Assert.NotNull(typeof(RenderTexture).GetMethod("Draw", new[] { typeof(IDrawable) }));
        }

        /// <summary>
        /// Tests that push gl states pop gl states reset gl states methods exist
        /// </summary>
        [Fact]
        public void PushGlStates_PopGlStates_ResetGlStates_Methods_Exist()
        {
            Assert.NotNull(typeof(RenderTexture).GetMethod("PushGlStates"));
            Assert.NotNull(typeof(RenderTexture).GetMethod("PopGlStates"));
            Assert.NotNull(typeof(RenderTexture).GetMethod("ResetGlStates"));
        }

        /// <summary>
        /// Tests that set active generate mipmap display methods exist
        /// </summary>
        [Fact]
        public void SetActive_GenerateMipmap_Display_Methods_Exist()
        {
            Assert.NotNull(typeof(RenderTexture).GetMethod("SetActive"));
            Assert.NotNull(typeof(RenderTexture).GetMethod("GenerateMipmap"));
            Assert.NotNull(typeof(RenderTexture).GetMethod("Display"));
        }
    }
}
