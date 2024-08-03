// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImDrawListPtrTest.cs
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
using Xunit;

namespace Alis.Extension.Graphic.ImGui.Test
{
    /// <summary>
    /// The im draw list ptr test class
    /// </summary>
    public class ImDrawListPtrTest
    {
        /// <summary>
        /// Tests that native ptr should be initialized
        /// </summary>
        [Fact]
        public void NativePtr_ShouldBeInitialized()
        {
            ImFontConfigPtr ptr = new ImFontConfigPtr(IntPtr.Zero);
            Assert.Equal(IntPtr.Zero, ptr.NativePtr);
        }

        /// <summary>
        /// Tests that font data should be initialized
        /// </summary>
        [Fact]
        public void FontData_ShouldBeInitialized()
        {
            ImFontConfig config = new ImFontConfig();
            ImFontConfigPtr ptr = new ImFontConfigPtr(config);
            Assert.Equal(config.FontData, ptr.FontData);
        }

        /// <summary>
        /// Tests that font data size should be initialized
        /// </summary>
        [Fact]
        public void FontDataSize_ShouldBeInitialized()
        {
            ImFontConfig config = new ImFontConfig();
            ImFontConfigPtr ptr = new ImFontConfigPtr(config);
            Assert.Equal(config.FontDataSize, ptr.FontDataSize);
        }

        /// <summary>
        /// Tests that font data owned by atlas should be initialized
        /// </summary>
        [Fact]
        public void FontDataOwnedByAtlas_ShouldBeInitialized()
        {
            ImFontConfig config = new ImFontConfig();
            ImFontConfigPtr ptr = new ImFontConfigPtr(config);
            Assert.Equal(config.FontDataOwnedByAtlas != 0, ptr.FontDataOwnedByAtlas);
        }

        /// <summary>
        /// Tests that font no should be initialized
        /// </summary>
        [Fact]
        public void FontNo_ShouldBeInitialized()
        {
            ImFontConfig config = new ImFontConfig();
            ImFontConfigPtr ptr = new ImFontConfigPtr(config);
            Assert.Equal(config.FontNo, ptr.FontNo);
        }

        /// <summary>
        /// Tests that size pixels should be initialized
        /// </summary>
        [Fact]
        public void SizePixels_ShouldBeInitialized()
        {
            ImFontConfig config = new ImFontConfig();
            ImFontConfigPtr ptr = new ImFontConfigPtr(config);
            Assert.Equal(config.SizePixels, ptr.SizePixels);
        }

        /// <summary>
        /// Tests that oversample h should be initialized
        /// </summary>
        [Fact]
        public void OversampleH_ShouldBeInitialized()
        {
            ImFontConfig config = new ImFontConfig();
            ImFontConfigPtr ptr = new ImFontConfigPtr(config);
            Assert.Equal(config.OversampleH, ptr.OversampleH);
        }

        /// <summary>
        /// Tests that oversample v should be initialized
        /// </summary>
        [Fact]
        public void OversampleV_ShouldBeInitialized()
        {
            ImFontConfig config = new ImFontConfig();
            ImFontConfigPtr ptr = new ImFontConfigPtr(config);
            Assert.Equal(config.OversampleV, ptr.OversampleV);
        }

        /// <summary>
        /// Tests that snap h should be initialized
        /// </summary>
        [Fact]
        public void SnapH_ShouldBeInitialized()
        {
            ImFontConfig config = new ImFontConfig();
            ImFontConfigPtr ptr = new ImFontConfigPtr(config);
            Assert.Equal(config.SnapH != 0, ptr.SnapH);
        }

        /// <summary>
        /// Tests that glyph extra spacing should be initialized
        /// </summary>
        [Fact]
        public void GlyphExtraSpacing_ShouldBeInitialized()
        {
            ImFontConfig config = new ImFontConfig();
            ImFontConfigPtr ptr = new ImFontConfigPtr(config);
            Assert.Equal(config.GlyphExtraSpacing, ptr.GlyphExtraSpacing);
        }

        /// <summary>
        /// Tests that glyph offset should be initialized
        /// </summary>
        [Fact]
        public void GlyphOffset_ShouldBeInitialized()
        {
            ImFontConfig config = new ImFontConfig();
            ImFontConfigPtr ptr = new ImFontConfigPtr(config);
            Assert.Equal(config.GlyphOffset, ptr.GlyphOffset);
        }

        /// <summary>
        /// Tests that glyph ranges should be initialized
        /// </summary>
        [Fact]
        public void GlyphRanges_ShouldBeInitialized()
        {
            ImFontConfig config = new ImFontConfig();
            ImFontConfigPtr ptr = new ImFontConfigPtr(config);
            Assert.Equal(config.GlyphRanges, ptr.GlyphRanges);
        }

        /// <summary>
        /// Tests that glyph min advance x should be initialized
        /// </summary>
        [Fact]
        public void GlyphMinAdvanceX_ShouldBeInitialized()
        {
            ImFontConfig config = new ImFontConfig();
            ImFontConfigPtr ptr = new ImFontConfigPtr(config);
            Assert.Equal(config.GlyphMinAdvanceX, ptr.GlyphMinAdvanceX);
        }

        /// <summary>
        /// Tests that glyph max advance x should be initialized
        /// </summary>
        [Fact]
        public void GlyphMaxAdvanceX_ShouldBeInitialized()
        {
            ImFontConfig config = new ImFontConfig();
            ImFontConfigPtr ptr = new ImFontConfigPtr(config);
            Assert.Equal(config.GlyphMaxAdvanceX, ptr.GlyphMaxAdvanceX);
        }

        /// <summary>
        /// Tests that merge mode should be initialized
        /// </summary>
        [Fact]
        public void MergeMode_ShouldBeInitialized()
        {
            ImFontConfig config = new ImFontConfig();
            ImFontConfigPtr ptr = new ImFontConfigPtr(config);
            Assert.Equal(config.MergeMode != 0, ptr.MergeMode);
        }

        /// <summary>
        /// Tests that font builder flags should be initialized
        /// </summary>
        [Fact]
        public void FontBuilderFlags_ShouldBeInitialized()
        {
            ImFontConfig config = new ImFontConfig();
            ImFontConfigPtr ptr = new ImFontConfigPtr(config);
            Assert.Equal(config.FontBuilderFlags, ptr.FontBuilderFlags);
        }

        /// <summary>
        /// Tests that rasterizer multiply should be initialized
        /// </summary>
        [Fact]
        public void RasterizerMultiply_ShouldBeInitialized()
        {
            ImFontConfig config = new ImFontConfig();
            ImFontConfigPtr ptr = new ImFontConfigPtr(config);
            Assert.Equal(config.RasterizerMultiply, ptr.RasterizerMultiply);
        }

        /// <summary>
        /// Tests that ellipsis char should be initialized
        /// </summary>
        [Fact]
        public void EllipsisChar_ShouldBeInitialized()
        {
            ImFontConfig config = new ImFontConfig();
            ImFontConfigPtr ptr = new ImFontConfigPtr(config);
            Assert.Equal(config.EllipsisChar, ptr.EllipsisChar);
        }

        /// <summary>
        /// Tests that add image with user texture id and min max adds image
        /// </summary>
        [Fact]
        public void AddImage_WithUserTextureIdAndMinMax_AddsImage()
        {
            ImDrawListPtr drawList = new ImDrawListPtr(IntPtr.Zero);
            IntPtr userTextureId = new IntPtr(1);
            Vector2 pMin = new Vector2(0, 0);
            Vector2 pMax = new Vector2(1, 1);

            Assert.Throws<DllNotFoundException>(() => drawList.AddImage(userTextureId, pMin, pMax));

            // Assert logic here
        }

        /// <summary>
        /// Tests that add image with user texture id min max and uv min adds image
        /// </summary>
        [Fact]
        public void AddImage_WithUserTextureIdMinMaxAndUvMin_AddsImage()
        {
            ImDrawListPtr drawList = new ImDrawListPtr(IntPtr.Zero);
            IntPtr userTextureId = new IntPtr(1);
            Vector2 pMin = new Vector2(0, 0);
            Vector2 pMax = new Vector2(1, 1);
            Vector2 uvMin = new Vector2(0, 0);

            Assert.Throws<DllNotFoundException>(() => drawList.AddImage(userTextureId, pMin, pMax, uvMin));

            // Assert logic here
        }

        /// <summary>
        /// Tests that add image with user texture id min max uv min and uv max adds image
        /// </summary>
        [Fact]
        public void AddImage_WithUserTextureIdMinMaxUvMinAndUvMax_AddsImage()
        {
            ImDrawListPtr drawList = new ImDrawListPtr(IntPtr.Zero);
            IntPtr userTextureId = new IntPtr(1);
            Vector2 pMin = new Vector2(0, 0);
            Vector2 pMax = new Vector2(1, 1);
            Vector2 uvMin = new Vector2(0, 0);
            Vector2 uvMax = new Vector2(1, 1);

            Assert.Throws<DllNotFoundException>(() =>drawList.AddImage(userTextureId, pMin, pMax, uvMin, uvMax));

            // Assert logic here
        }

        /// <summary>
        /// Tests that add image with user texture id min max uv min uv max and col adds image
        /// </summary>
        [Fact]
        public void AddImage_WithUserTextureIdMinMaxUvMinUvMaxAndCol_AddsImage()
        {
            ImDrawListPtr drawList = new ImDrawListPtr(IntPtr.Zero);
            IntPtr userTextureId = new IntPtr(1);
            Vector2 pMin = new Vector2(0, 0);
            Vector2 pMax = new Vector2(1, 1);
            Vector2 uvMin = new Vector2(0, 0);
            Vector2 uvMax = new Vector2(1, 1);
            uint col = 4294967295;

            Assert.Throws<DllNotFoundException>(() => drawList.AddImage(userTextureId, pMin, pMax, uvMin, uvMax, col));

            // Assert logic here
        }

        /// <summary>
        /// Tests that add image quad with user texture id and points adds image quad
        /// </summary>
        [Fact]
        public void AddImageQuad_WithUserTextureIdAndPoints_AddsImageQuad()
        {
            ImDrawListPtr drawList = new ImDrawListPtr(IntPtr.Zero);
            IntPtr userTextureId = new IntPtr(1);
            Vector2 p1 = new Vector2(0, 0);
            Vector2 p2 = new Vector2(1, 0);
            Vector2 p3 = new Vector2(1, 1);
            Vector2 p4 = new Vector2(0, 1);

            Assert.Throws<DllNotFoundException>(() => drawList.AddImageQuad(userTextureId, p1, p2, p3, p4));

            // Assert logic here
        }

        /// <summary>
        /// Tests that add image quad with user texture id points and uv 1 adds image quad
        /// </summary>
        [Fact]
        public void AddImageQuad_WithUserTextureIdPointsAndUv1_AddsImageQuad()
        {
            ImDrawListPtr drawList = new ImDrawListPtr(IntPtr.Zero);
            IntPtr userTextureId = new IntPtr(1);
            Vector2 p1 = new Vector2(0, 0);
            Vector2 p2 = new Vector2(1, 0);
            Vector2 p3 = new Vector2(1, 1);
            Vector2 p4 = new Vector2(0, 1);
            Vector2 uv1 = new Vector2(0, 0);

            Assert.Throws<DllNotFoundException>(() => drawList.AddImageQuad(userTextureId, p1, p2, p3, p4, uv1));

            // Assert logic here
        }

        /// <summary>
        /// Tests that add image quad with user texture id points uv 1 and uv 2 adds image quad
        /// </summary>
        [Fact]
        public void AddImageQuad_WithUserTextureIdPointsUv1AndUv2_AddsImageQuad()
        {
            ImDrawListPtr drawList = new ImDrawListPtr(IntPtr.Zero);
            IntPtr userTextureId = new IntPtr(1);
            Vector2 p1 = new Vector2(0, 0);
            Vector2 p2 = new Vector2(1, 0);
            Vector2 p3 = new Vector2(1, 1);
            Vector2 p4 = new Vector2(0, 1);
            Vector2 uv1 = new Vector2(0, 0);
            Vector2 uv2 = new Vector2(1, 0);

            Assert.Throws<DllNotFoundException>(() => drawList.AddImageQuad(userTextureId, p1, p2, p3, p4, uv1, uv2));

            // Assert logic here
        }

        /// <summary>
        /// Tests that add image quad with user texture id points uv 1 uv 2 and uv 3 adds image quad
        /// </summary>
        [Fact]
        public void AddImageQuad_WithUserTextureIdPointsUv1Uv2AndUv3_AddsImageQuad()
        {
            ImDrawListPtr drawList = new ImDrawListPtr(IntPtr.Zero);
            IntPtr userTextureId = new IntPtr(1);
            Vector2 p1 = new Vector2(0, 0);
            Vector2 p2 = new Vector2(1, 0);
            Vector2 p3 = new Vector2(1, 1);
            Vector2 p4 = new Vector2(0, 1);
            Vector2 uv1 = new Vector2(0, 0);
            Vector2 uv2 = new Vector2(1, 0);
            Vector2 uv3 = new Vector2(1, 1);

            Assert.Throws<DllNotFoundException>(() =>drawList.AddImageQuad(userTextureId, p1, p2, p3, p4, uv1, uv2, uv3));

            // Assert logic here
        }

        /// <summary>
        /// Tests that add image quad with user texture id points uv 1 uv 2 uv 3 and uv 4 adds image quad
        /// </summary>
        [Fact]
        public void AddImageQuad_WithUserTextureIdPointsUv1Uv2Uv3AndUv4_AddsImageQuad()
        {
            ImDrawListPtr drawList = new ImDrawListPtr(IntPtr.Zero);
            IntPtr userTextureId = new IntPtr(1);
            Vector2 p1 = new Vector2(0, 0);
            Vector2 p2 = new Vector2(1, 0);
            Vector2 p3 = new Vector2(1, 1);
            Vector2 p4 = new Vector2(0, 1);
            Vector2 uv1 = new Vector2(0, 0);
            Vector2 uv2 = new Vector2(1, 0);
            Vector2 uv3 = new Vector2(1, 1);
            Vector2 uv4 = new Vector2(0, 1);

            Assert.Throws<DllNotFoundException>(() =>drawList.AddImageQuad(userTextureId, p1, p2, p3, p4, uv1, uv2, uv3, uv4));

            // Assert logic here
        }

        /// <summary>
        /// Tests that add image quad with user texture id points uv 1 uv 2 uv 3 uv 4 and col adds image quad
        /// </summary>
        [Fact]
        public void AddImageQuad_WithUserTextureIdPointsUv1Uv2Uv3Uv4AndCol_AddsImageQuad()
        {
            ImDrawListPtr drawList = new ImDrawListPtr(IntPtr.Zero);
            IntPtr userTextureId = new IntPtr(1);
            Vector2 p1 = new Vector2(0, 0);
            Vector2 p2 = new Vector2(1, 0);
            Vector2 p3 = new Vector2(1, 1);
            Vector2 p4 = new Vector2(0, 1);
            Vector2 uv1 = new Vector2(0, 0);
            Vector2 uv2 = new Vector2(1, 0);
            Vector2 uv3 = new Vector2(1, 1);
            Vector2 uv4 = new Vector2(0, 1);
            uint col = 4294967295;

            Assert.Throws<DllNotFoundException>(() =>drawList.AddImageQuad(userTextureId, p1, p2, p3, p4, uv1, uv2, uv3, uv4, col));

            // Assert logic here
        }

        /// <summary>
        /// Tests that add image rounded with user texture id min max uv min uv max col and rounding adds image rounded
        /// </summary>
        [Fact]
        public void AddImageRounded_WithUserTextureIdMinMaxUvMinUvMaxColAndRounding_AddsImageRounded()
        {
            ImDrawListPtr drawList = new ImDrawListPtr(IntPtr.Zero);
            IntPtr userTextureId = new IntPtr(1);
            Vector2 pMin = new Vector2(0, 0);
            Vector2 pMax = new Vector2(1, 1);
            Vector2 uvMin = new Vector2(0, 0);
            Vector2 uvMax = new Vector2(1, 1);
            uint col = 4294967295;
            float rounding = 0.5f;

            Assert.Throws<DllNotFoundException>(() => drawList.AddImageRounded(userTextureId, pMin, pMax, uvMin, uvMax, col, rounding));

            // Assert logic here
        }

        /// <summary>
        /// Tests that add image rounded with user texture id min max uv min uv max col rounding and flags adds image rounded
        /// </summary>
        [Fact]
        public void AddImageRounded_WithUserTextureIdMinMaxUvMinUvMaxColRoundingAndFlags_AddsImageRounded()
        {
            ImDrawListPtr drawList = new ImDrawListPtr(IntPtr.Zero);
            IntPtr userTextureId = new IntPtr(1);
            Vector2 pMin = new Vector2(0, 0);
            Vector2 pMax = new Vector2(1, 1);
            Vector2 uvMin = new Vector2(0, 0);
            Vector2 uvMax = new Vector2(1, 1);
            uint col = 4294967295;
            float rounding = 0.5f;
            ImDrawFlags flags = 0;

            Assert.Throws<DllNotFoundException>(() => drawList.AddImageRounded(userTextureId, pMin, pMax, uvMin, uvMax, col, rounding, flags));

            // Assert logic here
        }

        /// <summary>
        /// Tests that add line with p 1 p 2 and col adds line
        /// </summary>
        [Fact]
        public void AddLine_WithP1P2AndCol_AddsLine()
        {
            ImDrawListPtr drawList = new ImDrawListPtr(IntPtr.Zero);
            Vector2 p1 = new Vector2(0, 0);
            Vector2 p2 = new Vector2(1, 1);
            uint col = 4294967295;

            Assert.Throws<DllNotFoundException>(() =>drawList.AddLine(p1, p2, col));

            // Assert logic here
        }

        /// <summary>
        /// Tests that add line with p 1 p 2 col and thickness adds line
        /// </summary>
        [Fact]
        public void AddLine_WithP1P2ColAndThickness_AddsLine()
        {
            ImDrawListPtr drawList = new ImDrawListPtr(IntPtr.Zero);
            Vector2 p1 = new Vector2(0, 0);
            Vector2 p2 = new Vector2(1, 1);
            uint col = 4294967295;
            float thickness = 2.0f;

            Assert.Throws<DllNotFoundException>(() =>drawList.AddLine(p1, p2, col, thickness));

            // Assert logic here
        }

        /// <summary>
        /// Tests that add ngon with center radius col and num segments adds ngon
        /// </summary>
        [Fact]
        public void AddNgon_WithCenterRadiusColAndNumSegments_AddsNgon()
        {
            ImDrawListPtr drawList = new ImDrawListPtr(IntPtr.Zero);
            Vector2 center = new Vector2(0, 0);
            float radius = 1.0f;
            uint col = 4294967295;
            int numSegments = 6;

            Assert.Throws<DllNotFoundException>(() => drawList.AddNgon(center, radius, col, numSegments));

            // Assert logic here
        }

        /// <summary>
        /// Tests that add ngon with center radius col num segments and thickness adds ngon
        /// </summary>
        [Fact]
        public void AddNgon_WithCenterRadiusColNumSegmentsAndThickness_AddsNgon()
        {
            ImDrawListPtr drawList = new ImDrawListPtr(IntPtr.Zero);
            Vector2 center = new Vector2(0, 0);
            float radius = 1.0f;
            uint col = 4294967295;
            int numSegments = 6;
            float thickness = 2.0f;

            Assert.Throws<DllNotFoundException>(() =>drawList.AddNgon(center, radius, col, numSegments, thickness));

            // Assert logic here
        }

        /// <summary>
        /// Tests that add ngon filled with center radius col and num segments adds ngon filled
        /// </summary>
        [Fact]
        public void AddNgonFilled_WithCenterRadiusColAndNumSegments_AddsNgonFilled()
        {
            ImDrawListPtr drawList = new ImDrawListPtr(IntPtr.Zero);
            Vector2 center = new Vector2(0, 0);
            float radius = 1.0f;
            uint col = 4294967295;
            int numSegments = 6;

            Assert.Throws<DllNotFoundException>(() =>drawList.AddNgonFilled(center, radius, col, numSegments));

            // Assert logic here
        }

        /// <summary>
        /// Tests that add polyline with points num points col flags and thickness adds polyline
        /// </summary>
        [Fact]
        public void AddPolyline_WithPointsNumPointsColFlagsAndThickness_AddsPolyline()
        {
            ImDrawListPtr drawList = new ImDrawListPtr(IntPtr.Zero);
            Vector2[] points = new Vector2[3] {new Vector2(0, 0), new Vector2(1, 1), new Vector2(2, 2)};
            int numPoints = 3;
            uint col = 4294967295;
            ImDrawFlags flags = 0;
            float thickness = 2.0f;

            Assert.Throws<DllNotFoundException>(() => drawList.AddPolyline(ref points[0], numPoints, col, flags, thickness));

            // Assert logic here
        }

        /// <summary>
        /// Tests that add quad with p 1 p 2 p 3 p 4 and col adds quad
        /// </summary>
        [Fact]
        public void AddQuad_WithP1P2P3P4AndCol_AddsQuad()
        {
            ImDrawListPtr drawList = new ImDrawListPtr(IntPtr.Zero);
            Vector2 p1 = new Vector2(0, 0);
            Vector2 p2 = new Vector2(1, 0);
            Vector2 p3 = new Vector2(1, 1);
            Vector2 p4 = new Vector2(0, 1);
            uint col = 4294967295;

            Assert.Throws<DllNotFoundException>(() =>drawList.AddQuad(p1, p2, p3, p4, col));

            // Assert logic here
        }

        /// <summary>
        /// Tests that add quad with p 1 p 2 p 3 p 4 col and thickness adds quad
        /// </summary>
        [Fact]
        public void AddQuad_WithP1P2P3P4ColAndThickness_AddsQuad()
        {
            ImDrawListPtr drawList = new ImDrawListPtr(IntPtr.Zero);
            Vector2 p1 = new Vector2(0, 0);
            Vector2 p2 = new Vector2(1, 0);
            Vector2 p3 = new Vector2(1, 1);
            Vector2 p4 = new Vector2(0, 1);
            uint col = 4294967295;
            float thickness = 2.0f;

            Assert.Throws<DllNotFoundException>(() =>drawList.AddQuad(p1, p2, p3, p4, col, thickness));

            // Assert logic here
        }

        /// <summary>
        /// Tests that add quad filled with p 1 p 2 p 3 p 4 and col adds quad filled
        /// </summary>
        [Fact]
        public void AddQuadFilled_WithP1P2P3P4AndCol_AddsQuadFilled()
        {
            ImDrawListPtr drawList = new ImDrawListPtr(IntPtr.Zero);
            Vector2 p1 = new Vector2(0, 0);
            Vector2 p2 = new Vector2(1, 0);
            Vector2 p3 = new Vector2(1, 1);
            Vector2 p4 = new Vector2(0, 1);
            uint col = 4294967295;

            Assert.Throws<DllNotFoundException>(() =>drawList.AddQuadFilled(p1, p2, p3, p4, col));

            // Assert logic here
        }

        /// <summary>
        /// Tests that add rect with p min p max and col adds rect
        /// </summary>
        [Fact]
        public void AddRect_WithPMinPMaxAndCol_AddsRect()
        {
            ImDrawListPtr drawList = new ImDrawListPtr(IntPtr.Zero);
            Vector2 pMin = new Vector2(0, 0);
            Vector2 pMax = new Vector2(1, 1);
            uint col = 4294967295;

            Assert.Throws<DllNotFoundException>(() =>drawList.AddRect(pMin, pMax, col));

            // Assert logic here
        }

        /// <summary>
        /// Tests that add rect with p min p max col and rounding adds rect
        /// </summary>
        [Fact]
        public void AddRect_WithPMinPMaxColAndRounding_AddsRect()
        {
            ImDrawListPtr drawList = new ImDrawListPtr(IntPtr.Zero);
            Vector2 pMin = new Vector2(0, 0);
            Vector2 pMax = new Vector2(1, 1);
            uint col = 4294967295;
            float rounding = 0.5f;

            Assert.Throws<DllNotFoundException>(() =>drawList.AddRect(pMin, pMax, col, rounding));

            // Assert logic here
        }

        /// <summary>
        /// Tests that add rect with p min p max col rounding and flags adds rect
        /// </summary>
        [Fact]
        public void AddRect_WithPMinPMaxColRoundingAndFlags_AddsRect()
        {
            ImDrawListPtr drawList = new ImDrawListPtr(IntPtr.Zero);
            Vector2 pMin = new Vector2(0, 0);
            Vector2 pMax = new Vector2(1, 1);
            uint col = 4294967295;
            float rounding = 0.5f;
            ImDrawFlags flags = 0;

            Assert.Throws<DllNotFoundException>(() =>drawList.AddRect(pMin, pMax, col, rounding, flags));

            // Assert logic here
        }

        /// <summary>
        /// Tests that add rect with p min p max col rounding flags and thickness adds rect
        /// </summary>
        [Fact]
        public void AddRect_WithPMinPMaxColRoundingFlagsAndThickness_AddsRect()
        {
            ImDrawListPtr drawList = new ImDrawListPtr(IntPtr.Zero);
            Vector2 pMin = new Vector2(0, 0);
            Vector2 pMax = new Vector2(1, 1);
            uint col = 4294967295;
            float rounding = 0.5f;
            ImDrawFlags flags = 0;
            float thickness = 2.0f;

            Assert.Throws<DllNotFoundException>(() =>drawList.AddRect(pMin, pMax, col, rounding, flags, thickness));

            // Assert logic here
        }

        /// <summary>
        /// Tests that add rect filled with p min p max and col adds rect filled
        /// </summary>
        [Fact]
        public void AddRectFilled_WithPMinPMaxAndCol_AddsRectFilled()
        {
            ImDrawListPtr drawList = new ImDrawListPtr(IntPtr.Zero);
            Vector2 pMin = new Vector2(0, 0);
            Vector2 pMax = new Vector2(1, 1);
            uint col = 4294967295;

            Assert.Throws<DllNotFoundException>(() =>drawList.AddRectFilled(pMin, pMax, col));

            // Assert logic here
        }

        /// <summary>
        /// Tests that add rect filled with p min p max col and rounding adds rect filled
        /// </summary>
        [Fact]
        public void AddRectFilled_WithPMinPMaxColAndRounding_AddsRectFilled()
        {
            ImDrawListPtr drawList = new ImDrawListPtr(IntPtr.Zero);
            Vector2 pMin = new Vector2(0, 0);
            Vector2 pMax = new Vector2(1, 1);
            uint col = 4294967295;
            float rounding = 0.5f;

            Assert.Throws<DllNotFoundException>(() => drawList.AddRectFilled(pMin, pMax, col, rounding));

            // Assert logic here
        }

        /// <summary>
        /// Tests that add rect filled with p min p max col rounding and flags adds rect filled
        /// </summary>
        [Fact]
        public void AddRectFilled_WithPMinPMaxColRoundingAndFlags_AddsRectFilled()
        {
            ImDrawListPtr drawList = new ImDrawListPtr(IntPtr.Zero);
            Vector2 pMin = new Vector2(0, 0);
            Vector2 pMax = new Vector2(1, 1);
            uint col = 4294967295;
            float rounding = 0.5f;
            ImDrawFlags flags = 0;

            Assert.Throws<DllNotFoundException>(() =>drawList.AddRectFilled(pMin, pMax, col, rounding, flags));

            // Assert logic here
        }

        /// <summary>
        /// Tests that add rect filled multi color with p min p max col upr left col upr right col bot right and col bot left adds rect filled multi color
        /// </summary>
        [Fact]
        public void AddRectFilledMultiColor_WithPMinPMaxColUprLeftColUprRightColBotRightAndColBotLeft_AddsRectFilledMultiColor()
        {
            ImDrawListPtr drawList = new ImDrawListPtr(IntPtr.Zero);
            Vector2 pMin = new Vector2(0, 0);
            Vector2 pMax = new Vector2(1, 1);
            uint colUprLeft = 4294967295;
            uint colUprRight = 4294967295;
            uint colBotRight = 4294967295;
            uint colBotLeft = 4294967295;

            Assert.Throws<DllNotFoundException>(() =>drawList.AddRectFilledMultiColor(pMin, pMax, colUprLeft, colUprRight, colBotRight, colBotLeft));

            // Assert logic here
        }

        /// <summary>
        /// Tests that add triangle with p 1 p 2 p 3 and col adds triangle
        /// </summary>
        [Fact]
        public void AddTriangle_WithP1P2P3AndCol_AddsTriangle()
        {
            ImDrawListPtr drawList = new ImDrawListPtr(IntPtr.Zero);
            Vector2 p1 = new Vector2(0, 0);
            Vector2 p2 = new Vector2(1, 0);
            Vector2 p3 = new Vector2(0.5f, 1);
            uint col = 4294967295;

            Assert.Throws<DllNotFoundException>(() => drawList.AddTriangle(p1, p2, p3, col));

            // Assert logic here
        }
    }
}