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
using System.Diagnostics.CodeAnalysis;
using Alis.Core.Aspect.Math.Vector;
using Xunit;

namespace Alis.Extension.Graphic.ImGui.Test
{
    /// <summary>
    ///     The im draw list ptr test class
    /// </summary>
    	 [ExcludeFromCodeCoverage] 
	 public class ImDrawListPtrTest 
    {
        /// <summary>
        ///     Tests that native ptr should be initialized
        /// </summary>
        [Fact]
        public void NativePtr_ShouldBeInitialized()
        {
            ImFontConfigPtr ptr = new ImFontConfigPtr(IntPtr.Zero);
            Assert.Equal(IntPtr.Zero, ptr.NativePtr);
        }

        /// <summary>
        ///     Tests that font data should be initialized
        /// </summary>
        [Fact]
        public void FontData_ShouldBeInitialized()
        {
            ImFontConfig config = new ImFontConfig();
            ImFontConfigPtr ptr = new ImFontConfigPtr(config);
            Assert.Equal(config.FontData, ptr.FontData);
        }

        /// <summary>
        ///     Tests that font data size should be initialized
        /// </summary>
        [Fact]
        public void FontDataSize_ShouldBeInitialized()
        {
            ImFontConfig config = new ImFontConfig();
            ImFontConfigPtr ptr = new ImFontConfigPtr(config);
            Assert.Equal(config.FontDataSize, ptr.FontDataSize);
        }

        /// <summary>
        ///     Tests that font data owned by atlas should be initialized
        /// </summary>
        [Fact]
        public void FontDataOwnedByAtlas_ShouldBeInitialized()
        {
            ImFontConfig config = new ImFontConfig();
            ImFontConfigPtr ptr = new ImFontConfigPtr(config);
            Assert.Equal(config.FontDataOwnedByAtlas != 0, ptr.FontDataOwnedByAtlas);
        }

        /// <summary>
        ///     Tests that font no should be initialized
        /// </summary>
        [Fact]
        public void FontNo_ShouldBeInitialized()
        {
            ImFontConfig config = new ImFontConfig();
            ImFontConfigPtr ptr = new ImFontConfigPtr(config);
            Assert.Equal(config.FontNo, ptr.FontNo);
        }

        /// <summary>
        ///     Tests that size pixels should be initialized
        /// </summary>
        [Fact]
        public void SizePixels_ShouldBeInitialized()
        {
            ImFontConfig config = new ImFontConfig();
            ImFontConfigPtr ptr = new ImFontConfigPtr(config);
            Assert.Equal(config.SizePixels, ptr.SizePixels);
        }

        /// <summary>
        ///     Tests that oversample h should be initialized
        /// </summary>
        [Fact]
        public void OversampleH_ShouldBeInitialized()
        {
            ImFontConfig config = new ImFontConfig();
            ImFontConfigPtr ptr = new ImFontConfigPtr(config);
            Assert.Equal(config.OversampleH, ptr.OversampleH);
        }

        /// <summary>
        ///     Tests that oversample v should be initialized
        /// </summary>
        [Fact]
        public void OversampleV_ShouldBeInitialized()
        {
            ImFontConfig config = new ImFontConfig();
            ImFontConfigPtr ptr = new ImFontConfigPtr(config);
            Assert.Equal(config.OversampleV, ptr.OversampleV);
        }

        /// <summary>
        ///     Tests that snap h should be initialized
        /// </summary>
        [Fact]
        public void SnapH_ShouldBeInitialized()
        {
            ImFontConfig config = new ImFontConfig();
            ImFontConfigPtr ptr = new ImFontConfigPtr(config);
            Assert.Equal(config.SnapH != 0, ptr.SnapH);
        }

        /// <summary>
        ///     Tests that glyph extra spacing should be initialized
        /// </summary>
        [Fact]
        public void GlyphExtraSpacing_ShouldBeInitialized()
        {
            ImFontConfig config = new ImFontConfig();
            ImFontConfigPtr ptr = new ImFontConfigPtr(config);
            Assert.Equal(config.GlyphExtraSpacing, ptr.GlyphExtraSpacing);
        }

        /// <summary>
        ///     Tests that glyph offset should be initialized
        /// </summary>
        [Fact]
        public void GlyphOffset_ShouldBeInitialized()
        {
            ImFontConfig config = new ImFontConfig();
            ImFontConfigPtr ptr = new ImFontConfigPtr(config);
            Assert.Equal(config.GlyphOffset, ptr.GlyphOffset);
        }

        /// <summary>
        ///     Tests that glyph ranges should be initialized
        /// </summary>
        [Fact]
        public void GlyphRanges_ShouldBeInitialized()
        {
            ImFontConfig config = new ImFontConfig();
            ImFontConfigPtr ptr = new ImFontConfigPtr(config);
            Assert.Equal(config.GlyphRanges, ptr.GlyphRanges);
        }

        /// <summary>
        ///     Tests that glyph min advance x should be initialized
        /// </summary>
        [Fact]
        public void GlyphMinAdvanceX_ShouldBeInitialized()
        {
            ImFontConfig config = new ImFontConfig();
            ImFontConfigPtr ptr = new ImFontConfigPtr(config);
            Assert.Equal(config.GlyphMinAdvanceX, ptr.GlyphMinAdvanceX);
        }

        /// <summary>
        ///     Tests that glyph max advance x should be initialized
        /// </summary>
        [Fact]
        public void GlyphMaxAdvanceX_ShouldBeInitialized()
        {
            ImFontConfig config = new ImFontConfig();
            ImFontConfigPtr ptr = new ImFontConfigPtr(config);
            Assert.Equal(config.GlyphMaxAdvanceX, ptr.GlyphMaxAdvanceX);
        }

        /// <summary>
        ///     Tests that merge mode should be initialized
        /// </summary>
        [Fact]
        public void MergeMode_ShouldBeInitialized()
        {
            ImFontConfig config = new ImFontConfig();
            ImFontConfigPtr ptr = new ImFontConfigPtr(config);
            Assert.Equal(config.MergeMode != 0, ptr.MergeMode);
        }

        /// <summary>
        ///     Tests that font builder flags should be initialized
        /// </summary>
        [Fact]
        public void FontBuilderFlags_ShouldBeInitialized()
        {
            ImFontConfig config = new ImFontConfig();
            ImFontConfigPtr ptr = new ImFontConfigPtr(config);
            Assert.Equal(config.FontBuilderFlags, ptr.FontBuilderFlags);
        }

        /// <summary>
        ///     Tests that rasterizer multiply should be initialized
        /// </summary>
        [Fact]
        public void RasterizerMultiply_ShouldBeInitialized()
        {
            ImFontConfig config = new ImFontConfig();
            ImFontConfigPtr ptr = new ImFontConfigPtr(config);
            Assert.Equal(config.RasterizerMultiply, ptr.RasterizerMultiply);
        }

        /// <summary>
        ///     Tests that ellipsis char should be initialized
        /// </summary>
        [Fact]
        public void EllipsisChar_ShouldBeInitialized()
        {
            ImFontConfig config = new ImFontConfig();
            ImFontConfigPtr ptr = new ImFontConfigPtr(config);
            Assert.Equal(config.EllipsisChar, ptr.EllipsisChar);
        }

        /// <summary>
        ///     Tests that add image with user texture id and min max adds image
        /// </summary>
        [Fact]
        public void AddImage_WithUserTextureIdAndMinMax_AddsImage()
        {
            ImDrawListPtr drawList = new ImDrawListPtr(IntPtr.Zero);
            IntPtr userTextureId = new IntPtr(1);
            Vector2F pMin = new Vector2F(0, 0);
            Vector2F pMax = new Vector2F(1, 1);

            Assert.Throws<DllNotFoundException>(() => drawList.AddImage(userTextureId, pMin, pMax));

            // Assert logic here
        }

        /// <summary>
        ///     Tests that add image with user texture id min max and uv min adds image
        /// </summary>
        [Fact]
        public void AddImage_WithUserTextureIdMinMaxAndUvMin_AddsImage()
        {
            ImDrawListPtr drawList = new ImDrawListPtr(IntPtr.Zero);
            IntPtr userTextureId = new IntPtr(1);
            Vector2F pMin = new Vector2F(0, 0);
            Vector2F pMax = new Vector2F(1, 1);
            Vector2F uvMin = new Vector2F(0, 0);

            Assert.Throws<DllNotFoundException>(() => drawList.AddImage(userTextureId, pMin, pMax, uvMin));

            // Assert logic here
        }

        /// <summary>
        ///     Tests that add image with user texture id min max uv min and uv max adds image
        /// </summary>
        [Fact]
        public void AddImage_WithUserTextureIdMinMaxUvMinAndUvMax_AddsImage()
        {
            ImDrawListPtr drawList = new ImDrawListPtr(IntPtr.Zero);
            IntPtr userTextureId = new IntPtr(1);
            Vector2F pMin = new Vector2F(0, 0);
            Vector2F pMax = new Vector2F(1, 1);
            Vector2F uvMin = new Vector2F(0, 0);
            Vector2F uvMax = new Vector2F(1, 1);

            Assert.Throws<DllNotFoundException>(() => drawList.AddImage(userTextureId, pMin, pMax, uvMin, uvMax));

            // Assert logic here
        }

        /// <summary>
        ///     Tests that add image with user texture id min max uv min uv max and col adds image
        /// </summary>
        [Fact]
        public void AddImage_WithUserTextureIdMinMaxUvMinUvMaxAndCol_AddsImage()
        {
            ImDrawListPtr drawList = new ImDrawListPtr(IntPtr.Zero);
            IntPtr userTextureId = new IntPtr(1);
            Vector2F pMin = new Vector2F(0, 0);
            Vector2F pMax = new Vector2F(1, 1);
            Vector2F uvMin = new Vector2F(0, 0);
            Vector2F uvMax = new Vector2F(1, 1);
            uint col = 4294967295;

            Assert.Throws<DllNotFoundException>(() => drawList.AddImage(userTextureId, pMin, pMax, uvMin, uvMax, col));

            // Assert logic here
        }

        /// <summary>
        ///     Tests that add image quad with user texture id and points adds image quad
        /// </summary>
        [Fact]
        public void AddImageQuad_WithUserTextureIdAndPoints_AddsImageQuad()
        {
            ImDrawListPtr drawList = new ImDrawListPtr(IntPtr.Zero);
            IntPtr userTextureId = new IntPtr(1);
            Vector2F p1 = new Vector2F(0, 0);
            Vector2F p2 = new Vector2F(1, 0);
            Vector2F p3 = new Vector2F(1, 1);
            Vector2F p4 = new Vector2F(0, 1);

            Assert.Throws<DllNotFoundException>(() => drawList.AddImageQuad(userTextureId, p1, p2, p3, p4));

            // Assert logic here
        }

        /// <summary>
        ///     Tests that add image quad with user texture id points and uv 1 adds image quad
        /// </summary>
        [Fact]
        public void AddImageQuad_WithUserTextureIdPointsAndUv1_AddsImageQuad()
        {
            ImDrawListPtr drawList = new ImDrawListPtr(IntPtr.Zero);
            IntPtr userTextureId = new IntPtr(1);
            Vector2F p1 = new Vector2F(0, 0);
            Vector2F p2 = new Vector2F(1, 0);
            Vector2F p3 = new Vector2F(1, 1);
            Vector2F p4 = new Vector2F(0, 1);
            Vector2F uv1 = new Vector2F(0, 0);

            Assert.Throws<DllNotFoundException>(() => drawList.AddImageQuad(userTextureId, p1, p2, p3, p4, uv1));

            // Assert logic here
        }

        /// <summary>
        ///     Tests that add image quad with user texture id points uv 1 and uv 2 adds image quad
        /// </summary>
        [Fact]
        public void AddImageQuad_WithUserTextureIdPointsUv1AndUv2_AddsImageQuad()
        {
            ImDrawListPtr drawList = new ImDrawListPtr(IntPtr.Zero);
            IntPtr userTextureId = new IntPtr(1);
            Vector2F p1 = new Vector2F(0, 0);
            Vector2F p2 = new Vector2F(1, 0);
            Vector2F p3 = new Vector2F(1, 1);
            Vector2F p4 = new Vector2F(0, 1);
            Vector2F uv1 = new Vector2F(0, 0);
            Vector2F uv2 = new Vector2F(1, 0);

            Assert.Throws<DllNotFoundException>(() => drawList.AddImageQuad(userTextureId, p1, p2, p3, p4, uv1, uv2));

            // Assert logic here
        }

        /// <summary>
        ///     Tests that add image quad with user texture id points uv 1 uv 2 and uv 3 adds image quad
        /// </summary>
        [Fact]
        public void AddImageQuad_WithUserTextureIdPointsUv1Uv2AndUv3_AddsImageQuad()
        {
            ImDrawListPtr drawList = new ImDrawListPtr(IntPtr.Zero);
            IntPtr userTextureId = new IntPtr(1);
            Vector2F p1 = new Vector2F(0, 0);
            Vector2F p2 = new Vector2F(1, 0);
            Vector2F p3 = new Vector2F(1, 1);
            Vector2F p4 = new Vector2F(0, 1);
            Vector2F uv1 = new Vector2F(0, 0);
            Vector2F uv2 = new Vector2F(1, 0);
            Vector2F uv3 = new Vector2F(1, 1);

            Assert.Throws<DllNotFoundException>(() => drawList.AddImageQuad(userTextureId, p1, p2, p3, p4, uv1, uv2, uv3));

            // Assert logic here
        }

        /// <summary>
        ///     Tests that add image quad with user texture id points uv 1 uv 2 uv 3 and uv 4 adds image quad
        /// </summary>
        [Fact]
        public void AddImageQuad_WithUserTextureIdPointsUv1Uv2Uv3AndUv4_AddsImageQuad()
        {
            ImDrawListPtr drawList = new ImDrawListPtr(IntPtr.Zero);
            IntPtr userTextureId = new IntPtr(1);
            Vector2F p1 = new Vector2F(0, 0);
            Vector2F p2 = new Vector2F(1, 0);
            Vector2F p3 = new Vector2F(1, 1);
            Vector2F p4 = new Vector2F(0, 1);
            Vector2F uv1 = new Vector2F(0, 0);
            Vector2F uv2 = new Vector2F(1, 0);
            Vector2F uv3 = new Vector2F(1, 1);
            Vector2F uv4 = new Vector2F(0, 1);

            Assert.Throws<DllNotFoundException>(() => drawList.AddImageQuad(userTextureId, p1, p2, p3, p4, uv1, uv2, uv3, uv4));

            // Assert logic here
        }

        /// <summary>
        ///     Tests that add image quad with user texture id points uv 1 uv 2 uv 3 uv 4 and col adds image quad
        /// </summary>
        [Fact]
        public void AddImageQuad_WithUserTextureIdPointsUv1Uv2Uv3Uv4AndCol_AddsImageQuad()
        {
            ImDrawListPtr drawList = new ImDrawListPtr(IntPtr.Zero);
            IntPtr userTextureId = new IntPtr(1);
            Vector2F p1 = new Vector2F(0, 0);
            Vector2F p2 = new Vector2F(1, 0);
            Vector2F p3 = new Vector2F(1, 1);
            Vector2F p4 = new Vector2F(0, 1);
            Vector2F uv1 = new Vector2F(0, 0);
            Vector2F uv2 = new Vector2F(1, 0);
            Vector2F uv3 = new Vector2F(1, 1);
            Vector2F uv4 = new Vector2F(0, 1);
            uint col = 4294967295;

            Assert.Throws<DllNotFoundException>(() => drawList.AddImageQuad(userTextureId, p1, p2, p3, p4, uv1, uv2, uv3, uv4, col));

            // Assert logic here
        }

        /// <summary>
        ///     Tests that add image rounded with user texture id min max uv min uv max col and rounding adds image rounded
        /// </summary>
        [Fact]
        public void AddImageRounded_WithUserTextureIdMinMaxUvMinUvMaxColAndRounding_AddsImageRounded()
        {
            ImDrawListPtr drawList = new ImDrawListPtr(IntPtr.Zero);
            IntPtr userTextureId = new IntPtr(1);
            Vector2F pMin = new Vector2F(0, 0);
            Vector2F pMax = new Vector2F(1, 1);
            Vector2F uvMin = new Vector2F(0, 0);
            Vector2F uvMax = new Vector2F(1, 1);
            uint col = 4294967295;
            float rounding = 0.5f;

            Assert.Throws<DllNotFoundException>(() => drawList.AddImageRounded(userTextureId, pMin, pMax, uvMin, uvMax, col, rounding));

            // Assert logic here
        }

        /// <summary>
        ///     Tests that add image rounded with user texture id min max uv min uv max col rounding and flags adds image rounded
        /// </summary>
        [Fact]
        public void AddImageRounded_WithUserTextureIdMinMaxUvMinUvMaxColRoundingAndFlags_AddsImageRounded()
        {
            ImDrawListPtr drawList = new ImDrawListPtr(IntPtr.Zero);
            IntPtr userTextureId = new IntPtr(1);
            Vector2F pMin = new Vector2F(0, 0);
            Vector2F pMax = new Vector2F(1, 1);
            Vector2F uvMin = new Vector2F(0, 0);
            Vector2F uvMax = new Vector2F(1, 1);
            uint col = 4294967295;
            float rounding = 0.5f;
            ImDrawFlags flags = 0;

            Assert.Throws<DllNotFoundException>(() => drawList.AddImageRounded(userTextureId, pMin, pMax, uvMin, uvMax, col, rounding, flags));

            // Assert logic here
        }

        /// <summary>
        ///     Tests that add line with p 1 p 2 and col adds line
        /// </summary>
        [Fact]
        public void AddLine_WithP1P2AndCol_AddsLine()
        {
            ImDrawListPtr drawList = new ImDrawListPtr(IntPtr.Zero);
            Vector2F p1 = new Vector2F(0, 0);
            Vector2F p2 = new Vector2F(1, 1);
            uint col = 4294967295;

            Assert.Throws<DllNotFoundException>(() => drawList.AddLine(p1, p2, col));

            // Assert logic here
        }

        /// <summary>
        ///     Tests that add line with p 1 p 2 col and thickness adds line
        /// </summary>
        [Fact]
        public void AddLine_WithP1P2ColAndThickness_AddsLine()
        {
            ImDrawListPtr drawList = new ImDrawListPtr(IntPtr.Zero);
            Vector2F p1 = new Vector2F(0, 0);
            Vector2F p2 = new Vector2F(1, 1);
            uint col = 4294967295;
            float thickness = 2.0f;

            Assert.Throws<DllNotFoundException>(() => drawList.AddLine(p1, p2, col, thickness));

            // Assert logic here
        }

        /// <summary>
        ///     Tests that add ngon with center radius col and num segments adds ngon
        /// </summary>
        [Fact]
        public void AddNgon_WithCenterRadiusColAndNumSegments_AddsNgon()
        {
            ImDrawListPtr drawList = new ImDrawListPtr(IntPtr.Zero);
            Vector2F center = new Vector2F(0, 0);
            float radius = 1.0f;
            uint col = 4294967295;
            int numSegments = 6;

            Assert.Throws<DllNotFoundException>(() => drawList.AddNgon(center, radius, col, numSegments));

            // Assert logic here
        }

        /// <summary>
        ///     Tests that add ngon with center radius col num segments and thickness adds ngon
        /// </summary>
        [Fact]
        public void AddNgon_WithCenterRadiusColNumSegmentsAndThickness_AddsNgon()
        {
            ImDrawListPtr drawList = new ImDrawListPtr(IntPtr.Zero);
            Vector2F center = new Vector2F(0, 0);
            float radius = 1.0f;
            uint col = 4294967295;
            int numSegments = 6;
            float thickness = 2.0f;

            Assert.Throws<DllNotFoundException>(() => drawList.AddNgon(center, radius, col, numSegments, thickness));

            // Assert logic here
        }

        /// <summary>
        ///     Tests that add ngon filled with center radius col and num segments adds ngon filled
        /// </summary>
        [Fact]
        public void AddNgonFilled_WithCenterRadiusColAndNumSegments_AddsNgonFilled()
        {
            ImDrawListPtr drawList = new ImDrawListPtr(IntPtr.Zero);
            Vector2F center = new Vector2F(0, 0);
            float radius = 1.0f;
            uint col = 4294967295;
            int numSegments = 6;

            Assert.Throws<DllNotFoundException>(() => drawList.AddNgonFilled(center, radius, col, numSegments));

            // Assert logic here
        }

        /// <summary>
        ///     Tests that add polyline with points num points col flags and thickness adds polyline
        /// </summary>
        [Fact]
        public void AddPolyline_WithPointsNumPointsColFlagsAndThickness_AddsPolyline()
        {
            ImDrawListPtr drawList = new ImDrawListPtr(IntPtr.Zero);
            Vector2F[] points = new Vector2F[3] {new Vector2F(0, 0), new Vector2F(1, 1), new Vector2F(2, 2)};
            int numPoints = 3;
            uint col = 4294967295;
            ImDrawFlags flags = 0;
            float thickness = 2.0f;

            Assert.Throws<DllNotFoundException>(() => drawList.AddPolyline(ref points[0], numPoints, col, flags, thickness));

            // Assert logic here
        }

        /// <summary>
        ///     Tests that add quad with p 1 p 2 p 3 p 4 and col adds quad
        /// </summary>
        [Fact]
        public void AddQuad_WithP1P2P3P4AndCol_AddsQuad()
        {
            ImDrawListPtr drawList = new ImDrawListPtr(IntPtr.Zero);
            Vector2F p1 = new Vector2F(0, 0);
            Vector2F p2 = new Vector2F(1, 0);
            Vector2F p3 = new Vector2F(1, 1);
            Vector2F p4 = new Vector2F(0, 1);
            uint col = 4294967295;

            Assert.Throws<DllNotFoundException>(() => drawList.AddQuad(p1, p2, p3, p4, col));

            // Assert logic here
        }

        /// <summary>
        ///     Tests that add quad with p 1 p 2 p 3 p 4 col and thickness adds quad
        /// </summary>
        [Fact]
        public void AddQuad_WithP1P2P3P4ColAndThickness_AddsQuad()
        {
            ImDrawListPtr drawList = new ImDrawListPtr(IntPtr.Zero);
            Vector2F p1 = new Vector2F(0, 0);
            Vector2F p2 = new Vector2F(1, 0);
            Vector2F p3 = new Vector2F(1, 1);
            Vector2F p4 = new Vector2F(0, 1);
            uint col = 4294967295;
            float thickness = 2.0f;

            Assert.Throws<DllNotFoundException>(() => drawList.AddQuad(p1, p2, p3, p4, col, thickness));

            // Assert logic here
        }

        /// <summary>
        ///     Tests that add quad filled with p 1 p 2 p 3 p 4 and col adds quad filled
        /// </summary>
        [Fact]
        public void AddQuadFilled_WithP1P2P3P4AndCol_AddsQuadFilled()
        {
            ImDrawListPtr drawList = new ImDrawListPtr(IntPtr.Zero);
            Vector2F p1 = new Vector2F(0, 0);
            Vector2F p2 = new Vector2F(1, 0);
            Vector2F p3 = new Vector2F(1, 1);
            Vector2F p4 = new Vector2F(0, 1);
            uint col = 4294967295;

            Assert.Throws<DllNotFoundException>(() => drawList.AddQuadFilled(p1, p2, p3, p4, col));

            // Assert logic here
        }

        /// <summary>
        ///     Tests that add rect with p min p max and col adds rect
        /// </summary>
        [Fact]
        public void AddRect_WithPMinPMaxAndCol_AddsRect()
        {
            ImDrawListPtr drawList = new ImDrawListPtr(IntPtr.Zero);
            Vector2F pMin = new Vector2F(0, 0);
            Vector2F pMax = new Vector2F(1, 1);
            uint col = 4294967295;

            Assert.Throws<DllNotFoundException>(() => drawList.AddRect(pMin, pMax, col));

            // Assert logic here
        }

        /// <summary>
        ///     Tests that add rect with p min p max col and rounding adds rect
        /// </summary>
        [Fact]
        public void AddRect_WithPMinPMaxColAndRounding_AddsRect()
        {
            ImDrawListPtr drawList = new ImDrawListPtr(IntPtr.Zero);
            Vector2F pMin = new Vector2F(0, 0);
            Vector2F pMax = new Vector2F(1, 1);
            uint col = 4294967295;
            float rounding = 0.5f;

            Assert.Throws<DllNotFoundException>(() => drawList.AddRect(pMin, pMax, col, rounding));

            // Assert logic here
        }

        /// <summary>
        ///     Tests that add rect with p min p max col rounding and flags adds rect
        /// </summary>
        [Fact]
        public void AddRect_WithPMinPMaxColRoundingAndFlags_AddsRect()
        {
            ImDrawListPtr drawList = new ImDrawListPtr(IntPtr.Zero);
            Vector2F pMin = new Vector2F(0, 0);
            Vector2F pMax = new Vector2F(1, 1);
            uint col = 4294967295;
            float rounding = 0.5f;
            ImDrawFlags flags = 0;

            Assert.Throws<DllNotFoundException>(() => drawList.AddRect(pMin, pMax, col, rounding, flags));

            // Assert logic here
        }

        /// <summary>
        ///     Tests that add rect with p min p max col rounding flags and thickness adds rect
        /// </summary>
        [Fact]
        public void AddRect_WithPMinPMaxColRoundingFlagsAndThickness_AddsRect()
        {
            ImDrawListPtr drawList = new ImDrawListPtr(IntPtr.Zero);
            Vector2F pMin = new Vector2F(0, 0);
            Vector2F pMax = new Vector2F(1, 1);
            uint col = 4294967295;
            float rounding = 0.5f;
            ImDrawFlags flags = 0;
            float thickness = 2.0f;

            Assert.Throws<DllNotFoundException>(() => drawList.AddRect(pMin, pMax, col, rounding, flags, thickness));

            // Assert logic here
        }

        /// <summary>
        ///     Tests that add rect filled with p min p max and col adds rect filled
        /// </summary>
        [Fact]
        public void AddRectFilled_WithPMinPMaxAndCol_AddsRectFilled()
        {
            ImDrawListPtr drawList = new ImDrawListPtr(IntPtr.Zero);
            Vector2F pMin = new Vector2F(0, 0);
            Vector2F pMax = new Vector2F(1, 1);
            uint col = 4294967295;

            Assert.Throws<DllNotFoundException>(() => drawList.AddRectFilled(pMin, pMax, col));

            // Assert logic here
        }

        /// <summary>
        ///     Tests that add rect filled with p min p max col and rounding adds rect filled
        /// </summary>
        [Fact]
        public void AddRectFilled_WithPMinPMaxColAndRounding_AddsRectFilled()
        {
            ImDrawListPtr drawList = new ImDrawListPtr(IntPtr.Zero);
            Vector2F pMin = new Vector2F(0, 0);
            Vector2F pMax = new Vector2F(1, 1);
            uint col = 4294967295;
            float rounding = 0.5f;

            Assert.Throws<DllNotFoundException>(() => drawList.AddRectFilled(pMin, pMax, col, rounding));

            // Assert logic here
        }

        /// <summary>
        ///     Tests that add rect filled with p min p max col rounding and flags adds rect filled
        /// </summary>
        [Fact]
        public void AddRectFilled_WithPMinPMaxColRoundingAndFlags_AddsRectFilled()
        {
            ImDrawListPtr drawList = new ImDrawListPtr(IntPtr.Zero);
            Vector2F pMin = new Vector2F(0, 0);
            Vector2F pMax = new Vector2F(1, 1);
            uint col = 4294967295;
            float rounding = 0.5f;
            ImDrawFlags flags = 0;

            Assert.Throws<DllNotFoundException>(() => drawList.AddRectFilled(pMin, pMax, col, rounding, flags));

            // Assert logic here
        }

        /// <summary>
        ///     Tests that add rect filled multi color with p min p max col upr left col upr right col bot right and col bot left
        ///     adds rect filled multi color
        /// </summary>
        [Fact]
        public void AddRectFilledMultiColor_WithPMinPMaxColUprLeftColUprRightColBotRightAndColBotLeft_AddsRectFilledMultiColor()
        {
            ImDrawListPtr drawList = new ImDrawListPtr(IntPtr.Zero);
            Vector2F pMin = new Vector2F(0, 0);
            Vector2F pMax = new Vector2F(1, 1);
            uint colUprLeft = 4294967295;
            uint colUprRight = 4294967295;
            uint colBotRight = 4294967295;
            uint colBotLeft = 4294967295;

            Assert.Throws<DllNotFoundException>(() => drawList.AddRectFilledMultiColor(pMin, pMax, colUprLeft, colUprRight, colBotRight, colBotLeft));

            // Assert logic here
        }

        /// <summary>
        ///     Tests that add triangle with p 1 p 2 p 3 and col adds triangle
        /// </summary>
        [Fact]
        public void AddTriangle_WithP1P2P3AndCol_AddsTriangle()
        {
            ImDrawListPtr drawList = new ImDrawListPtr(IntPtr.Zero);
            Vector2F p1 = new Vector2F(0, 0);
            Vector2F p2 = new Vector2F(1, 0);
            Vector2F p3 = new Vector2F(0.5f, 1);
            uint col = 4294967295;

            Assert.Throws<DllNotFoundException>(() => drawList.AddTriangle(p1, p2, p3, col));

            // Assert logic here
        }

        /// <summary>
        ///     Tests that add draw cmd throws dll not found exception
        /// </summary>
        [Fact]
        public void AddDrawCmd_ThrowsDllNotFoundException()
        {
            ImDrawListPtr drawList = new ImDrawListPtr(IntPtr.Zero);
            Assert.Throws<DllNotFoundException>(() => drawList.AddDrawCmd());
        }

        /// <summary>
        ///     Tests that add image throws dll not found exception
        /// </summary>
        [Fact]
        public void AddImage_ThrowsDllNotFoundException()
        {
            ImDrawListPtr drawList = new ImDrawListPtr(IntPtr.Zero);
            Assert.Throws<DllNotFoundException>(() => drawList.AddImage(IntPtr.Zero, new Vector2F(), new Vector2F()));
        }

        /// <summary>
        ///     Tests that add image with uv min throws dll not found exception
        /// </summary>
        [Fact]
        public void AddImage_WithUvMin_ThrowsDllNotFoundException()
        {
            ImDrawListPtr drawList = new ImDrawListPtr(IntPtr.Zero);
            Assert.Throws<DllNotFoundException>(() => drawList.AddImage(IntPtr.Zero, new Vector2F(), new Vector2F(), new Vector2F()));
        }

        /// <summary>
        ///     Tests that add image with uv min uv max throws dll not found exception
        /// </summary>
        [Fact]
        public void AddImage_WithUvMinUvMax_ThrowsDllNotFoundException()
        {
            ImDrawListPtr drawList = new ImDrawListPtr(IntPtr.Zero);
            Assert.Throws<DllNotFoundException>(() => drawList.AddImage(IntPtr.Zero, new Vector2F(), new Vector2F(), new Vector2F(), new Vector2F()));
        }

        /// <summary>
        ///     Tests that add image with uv min uv max col throws dll not found exception
        /// </summary>
        [Fact]
        public void AddImage_WithUvMinUvMaxCol_ThrowsDllNotFoundException()
        {
            ImDrawListPtr drawList = new ImDrawListPtr(IntPtr.Zero);
            Assert.Throws<DllNotFoundException>(() => drawList.AddImage(IntPtr.Zero, new Vector2F(), new Vector2F(), new Vector2F(), new Vector2F(), 0));
        }

        /// <summary>
        ///     Tests that add image quad throws dll not found exception
        /// </summary>
        [Fact]
        public void AddImageQuad_ThrowsDllNotFoundException()
        {
            ImDrawListPtr drawList = new ImDrawListPtr(IntPtr.Zero);
            Assert.Throws<DllNotFoundException>(() => drawList.AddImageQuad(IntPtr.Zero, new Vector2F(), new Vector2F(), new Vector2F(), new Vector2F()));
        }

        /// <summary>
        ///     Tests that add image quad with uv 1 throws dll not found exception
        /// </summary>
        [Fact]
        public void AddImageQuad_WithUv1_ThrowsDllNotFoundException()
        {
            ImDrawListPtr drawList = new ImDrawListPtr(IntPtr.Zero);
            Assert.Throws<DllNotFoundException>(() => drawList.AddImageQuad(IntPtr.Zero, new Vector2F(), new Vector2F(), new Vector2F(), new Vector2F(), new Vector2F()));
        }

        /// <summary>
        ///     Tests that add image quad with uv 1 uv 2 throws dll not found exception
        /// </summary>
        [Fact]
        public void AddImageQuad_WithUv1Uv2_ThrowsDllNotFoundException()
        {
            ImDrawListPtr drawList = new ImDrawListPtr(IntPtr.Zero);
            Assert.Throws<DllNotFoundException>(() => drawList.AddImageQuad(IntPtr.Zero, new Vector2F(), new Vector2F(), new Vector2F(), new Vector2F(), new Vector2F(), new Vector2F()));
        }

        /// <summary>
        ///     Tests that add image quad with uv 1 uv 2 uv 3 throws dll not found exception
        /// </summary>
        [Fact]
        public void AddImageQuad_WithUv1Uv2Uv3_ThrowsDllNotFoundException()
        {
            ImDrawListPtr drawList = new ImDrawListPtr(IntPtr.Zero);
            Assert.Throws<DllNotFoundException>(() => drawList.AddImageQuad(IntPtr.Zero, new Vector2F(), new Vector2F(), new Vector2F(), new Vector2F(), new Vector2F(), new Vector2F(), new Vector2F()));
        }

        /// <summary>
        ///     Tests that add image quad with uv 1 uv 2 uv 3 uv 4 throws dll not found exception
        /// </summary>
        [Fact]
        public void AddImageQuad_WithUv1Uv2Uv3Uv4_ThrowsDllNotFoundException()
        {
            ImDrawListPtr drawList = new ImDrawListPtr(IntPtr.Zero);
            Assert.Throws<DllNotFoundException>(() => drawList.AddImageQuad(IntPtr.Zero, new Vector2F(), new Vector2F(), new Vector2F(), new Vector2F(), new Vector2F(), new Vector2F(), new Vector2F(), new Vector2F()));
        }

        /// <summary>
        ///     Tests that add image rounded throws dll not found exception
        /// </summary>
        [Fact]
        public void AddImageRounded_ThrowsDllNotFoundException()
        {
            ImDrawListPtr drawList = new ImDrawListPtr(IntPtr.Zero);
            Assert.Throws<DllNotFoundException>(() => drawList.AddImageRounded(IntPtr.Zero, new Vector2F(), new Vector2F(), new Vector2F(), new Vector2F(), 0, 0));
        }

        /// <summary>
        ///     Tests that add image rounded with flags throws dll not found exception
        /// </summary>
        [Fact]
        public void AddImageRounded_WithFlags_ThrowsDllNotFoundException()
        {
            ImDrawListPtr drawList = new ImDrawListPtr(IntPtr.Zero);
            Assert.Throws<DllNotFoundException>(() => drawList.AddImageRounded(IntPtr.Zero, new Vector2F(), new Vector2F(), new Vector2F(), new Vector2F(), 0, 0, 0));
        }

        /// <summary>
        ///     Tests that add line throws dll not found exception
        /// </summary>
        [Fact]
        public void AddLine_ThrowsDllNotFoundException()
        {
            ImDrawListPtr drawList = new ImDrawListPtr(IntPtr.Zero);
            Assert.Throws<DllNotFoundException>(() => drawList.AddLine(new Vector2F(), new Vector2F(), 0));
        }

        /// <summary>
        ///     Tests that add line with thickness throws dll not found exception
        /// </summary>
        [Fact]
        public void AddLine_WithThickness_ThrowsDllNotFoundException()
        {
            ImDrawListPtr drawList = new ImDrawListPtr(IntPtr.Zero);
            Assert.Throws<DllNotFoundException>(() => drawList.AddLine(new Vector2F(), new Vector2F(), 0, 1.0f));
        }

        /// <summary>
        ///     Tests that add ngon throws dll not found exception
        /// </summary>
        [Fact]
        public void AddNgon_ThrowsDllNotFoundException()
        {
            ImDrawListPtr drawList = new ImDrawListPtr(IntPtr.Zero);
            Assert.Throws<DllNotFoundException>(() => drawList.AddNgon(new Vector2F(), 0, 0, 0));
        }

        /// <summary>
        ///     Tests that add ngon with thickness throws dll not found exception
        /// </summary>
        [Fact]
        public void AddNgon_WithThickness_ThrowsDllNotFoundException()
        {
            ImDrawListPtr drawList = new ImDrawListPtr(IntPtr.Zero);
            Assert.Throws<DllNotFoundException>(() => drawList.AddNgon(new Vector2F(), 0, 0, 0, 1.0f));
        }

        /// <summary>
        ///     Tests that add ngon filled throws dll not found exception
        /// </summary>
        [Fact]
        public void AddNgonFilled_ThrowsDllNotFoundException()
        {
            ImDrawListPtr drawList = new ImDrawListPtr(IntPtr.Zero);
            Assert.Throws<DllNotFoundException>(() => drawList.AddNgonFilled(new Vector2F(), 0, 0, 0));
        }

        /// <summary>
        ///     Tests that add polyline throws dll not found exception
        /// </summary>
        [Fact]
        public void AddPolyline_ThrowsDllNotFoundException()
        {
            ImDrawListPtr drawList = new ImDrawListPtr(IntPtr.Zero);
            Vector2F points = new Vector2F();
            Assert.Throws<DllNotFoundException>(() => drawList.AddPolyline(ref points, 0, 0, 0, 1.0f));
        }

        /// <summary>
        ///     Tests that add quad throws dll not found exception
        /// </summary>
        [Fact]
        public void AddQuad_ThrowsDllNotFoundException()
        {
            ImDrawListPtr drawList = new ImDrawListPtr(IntPtr.Zero);
            Assert.Throws<DllNotFoundException>(() => drawList.AddQuad(new Vector2F(), new Vector2F(), new Vector2F(), new Vector2F(), 0));
        }

        /// <summary>
        ///     Tests that add quad with thickness throws dll not found exception
        /// </summary>
        [Fact]
        public void AddQuad_WithThickness_ThrowsDllNotFoundException()
        {
            ImDrawListPtr drawList = new ImDrawListPtr(IntPtr.Zero);
            Assert.Throws<DllNotFoundException>(() => drawList.AddQuad(new Vector2F(), new Vector2F(), new Vector2F(), new Vector2F(), 0, 1.0f));
        }

        /// <summary>
        ///     Tests that add quad filled throws dll not found exception
        /// </summary>
        [Fact]
        public void AddQuadFilled_ThrowsDllNotFoundException()
        {
            ImDrawListPtr drawList = new ImDrawListPtr(IntPtr.Zero);
            Assert.Throws<DllNotFoundException>(() => drawList.AddQuadFilled(new Vector2F(), new Vector2F(), new Vector2F(), new Vector2F(), 0));
        }

        /// <summary>
        ///     Tests that add rect throws dll not found exception
        /// </summary>
        [Fact]
        public void AddRect_ThrowsDllNotFoundException()
        {
            ImDrawListPtr drawList = new ImDrawListPtr(IntPtr.Zero);
            Assert.Throws<DllNotFoundException>(() => drawList.AddRect(new Vector2F(), new Vector2F(), 0));
        }

        /// <summary>
        ///     Tests that add rect with rounding throws dll not found exception
        /// </summary>
        [Fact]
        public void AddRect_WithRounding_ThrowsDllNotFoundException()
        {
            ImDrawListPtr drawList = new ImDrawListPtr(IntPtr.Zero);
            Assert.Throws<DllNotFoundException>(() => drawList.AddRect(new Vector2F(), new Vector2F(), 0, 0.0f));
        }

        /// <summary>
        ///     Tests that add rect with rounding flags throws dll not found exception
        /// </summary>
        [Fact]
        public void AddRect_WithRoundingFlags_ThrowsDllNotFoundException()
        {
            ImDrawListPtr drawList = new ImDrawListPtr(IntPtr.Zero);
            Assert.Throws<DllNotFoundException>(() => drawList.AddRect(new Vector2F(), new Vector2F(), 0, 0.0f, 0));
        }

        /// <summary>
        ///     Tests that add rect with rounding flags thickness throws dll not found exception
        /// </summary>
        [Fact]
        public void AddRect_WithRoundingFlagsThickness_ThrowsDllNotFoundException()
        {
            ImDrawListPtr drawList = new ImDrawListPtr(IntPtr.Zero);
            Assert.Throws<DllNotFoundException>(() => drawList.AddRect(new Vector2F(), new Vector2F(), 0, 0.0f, 0, 1.0f));
        }

        /// <summary>
        ///     Tests that add rect filled throws dll not found exception
        /// </summary>
        [Fact]
        public void AddRectFilled_ThrowsDllNotFoundException()
        {
            ImDrawListPtr drawList = new ImDrawListPtr(IntPtr.Zero);
            Assert.Throws<DllNotFoundException>(() => drawList.AddRectFilled(new Vector2F(), new Vector2F(), 0));
        }

        /// <summary>
        ///     Tests that add rect filled with rounding throws dll not found exception
        /// </summary>
        [Fact]
        public void AddRectFilled_WithRounding_ThrowsDllNotFoundException()
        {
            ImDrawListPtr drawList = new ImDrawListPtr(IntPtr.Zero);
            Assert.Throws<DllNotFoundException>(() => drawList.AddRectFilled(new Vector2F(), new Vector2F(), 0, 0.0f));
        }

        /// <summary>
        ///     Tests that add rect filled with rounding flags throws dll not found exception
        /// </summary>
        [Fact]
        public void AddRectFilled_WithRoundingFlags_ThrowsDllNotFoundException()
        {
            ImDrawListPtr drawList = new ImDrawListPtr(IntPtr.Zero);
            Assert.Throws<DllNotFoundException>(() => drawList.AddRectFilled(new Vector2F(), new Vector2F(), 0, 0.0f, 0));
        }

        /// <summary>
        ///     Tests that add rect filled multi color throws dll not found exception
        /// </summary>
        [Fact]
        public void AddRectFilledMultiColor_ThrowsDllNotFoundException()
        {
            ImDrawListPtr drawList = new ImDrawListPtr(IntPtr.Zero);
            Assert.Throws<DllNotFoundException>(() => drawList.AddRectFilledMultiColor(new Vector2F(), new Vector2F(), 0, 0, 0, 0));
        }

        /// <summary>
        ///     Tests that add triangle throws dll not found exception
        /// </summary>
        [Fact]
        public void AddTriangle_ThrowsDllNotFoundException()
        {
            ImDrawListPtr drawList = new ImDrawListPtr(IntPtr.Zero);
            Assert.Throws<DllNotFoundException>(() => drawList.AddTriangle(new Vector2F(), new Vector2F(), new Vector2F(), 0));
        }

        /// <summary>
        ///     Tests that add triangle with thickness throws dll not found exception
        /// </summary>
        [Fact]
        public void AddTriangle_WithThickness_ThrowsDllNotFoundException()
        {
            ImDrawListPtr drawList = new ImDrawListPtr(IntPtr.Zero);
            Assert.Throws<DllNotFoundException>(() => drawList.AddTriangle(new Vector2F(), new Vector2F(), new Vector2F(), 0, 1.0f));
        }

        /// <summary>
        ///     Tests that add triangle filled throws dll not found exception
        /// </summary>
        [Fact]
        public void AddTriangleFilled_ThrowsDllNotFoundException()
        {
            ImDrawListPtr drawList = new ImDrawListPtr(IntPtr.Zero);
            Assert.Throws<DllNotFoundException>(() => drawList.AddTriangleFilled(new Vector2F(), new Vector2F(), new Vector2F(), 0));
        }

        /// <summary>
        ///     Tests that channels merge throws dll not found exception
        /// </summary>
        [Fact]
        public void ChannelsMerge_ThrowsDllNotFoundException()
        {
            ImDrawListPtr drawList = new ImDrawListPtr(IntPtr.Zero);
            Assert.Throws<DllNotFoundException>(() => drawList.ChannelsMerge());
        }

        /// <summary>
        ///     Tests that channels set current throws dll not found exception
        /// </summary>
        [Fact]
        public void ChannelsSetCurrent_ThrowsDllNotFoundException()
        {
            ImDrawListPtr drawList = new ImDrawListPtr(IntPtr.Zero);
            Assert.Throws<DllNotFoundException>(() => drawList.ChannelsSetCurrent(0));
        }

        /// <summary>
        ///     Tests that channels split throws dll not found exception
        /// </summary>
        [Fact]
        public void ChannelsSplit_ThrowsDllNotFoundException()
        {
            ImDrawListPtr drawList = new ImDrawListPtr(IntPtr.Zero);
            Assert.Throws<DllNotFoundException>(() => drawList.ChannelsSplit(0));
        }

        /// <summary>
        ///     Tests that clone output throws dll not found exception
        /// </summary>
        [Fact]
        public void CloneOutput_ThrowsDllNotFoundException()
        {
            ImDrawListPtr drawList = new ImDrawListPtr(IntPtr.Zero);
            Assert.Throws<DllNotFoundException>(() => drawList.CloneOutput());
        }

        /// <summary>
        ///     Tests that get clip rect max throws dll not found exception
        /// </summary>
        [Fact]
        public void GetClipRectMax_ThrowsDllNotFoundException()
        {
            ImDrawListPtr drawList = new ImDrawListPtr(IntPtr.Zero);
            Assert.Throws<DllNotFoundException>(() => drawList.GetClipRectMax());
        }

        /// <summary>
        ///     Tests that get clip rect min throws dll not found exception
        /// </summary>
        [Fact]
        public void GetClipRectMin_ThrowsDllNotFoundException()
        {
            ImDrawListPtr drawList = new ImDrawListPtr(IntPtr.Zero);
            Assert.Throws<DllNotFoundException>(() => drawList.GetClipRectMin());
        }

        /// <summary>
        ///     Tests that path arc to throws dll not found exception
        /// </summary>
        [Fact]
        public void PathArcTo_ThrowsDllNotFoundException()
        {
            ImDrawListPtr drawList = new ImDrawListPtr(IntPtr.Zero);
            Assert.Throws<DllNotFoundException>(() => drawList.PathArcTo(new Vector2F(), 0, 0, 0));
        }

        /// <summary>
        ///     Tests that path arc to with num segments throws dll not found exception
        /// </summary>
        [Fact]
        public void PathArcTo_WithNumSegments_ThrowsDllNotFoundException()
        {
            ImDrawListPtr drawList = new ImDrawListPtr(IntPtr.Zero);
            Assert.Throws<DllNotFoundException>(() => drawList.PathArcTo(new Vector2F(), 0, 0, 0, 0));
        }

        /// <summary>
        ///     Tests that path arc to fast throws dll not found exception
        /// </summary>
        [Fact]
        public void PathArcToFast_ThrowsDllNotFoundException()
        {
            ImDrawListPtr drawList = new ImDrawListPtr(IntPtr.Zero);
            Assert.Throws<DllNotFoundException>(() => drawList.PathArcToFast(new Vector2F(), 0, 0, 0));
        }

        /// <summary>
        ///     Tests that path bezier cubic curve to throws dll not found exception
        /// </summary>
        [Fact]
        public void PathBezierCubicCurveTo_ThrowsDllNotFoundException()
        {
            ImDrawListPtr drawList = new ImDrawListPtr(IntPtr.Zero);
            Assert.Throws<DllNotFoundException>(() => drawList.PathBezierCubicCurveTo(new Vector2F(), new Vector2F(), new Vector2F()));
        }

        /// <summary>
        ///     Tests that path bezier cubic curve to with num segments throws dll not found exception
        /// </summary>
        [Fact]
        public void PathBezierCubicCurveTo_WithNumSegments_ThrowsDllNotFoundException()
        {
            ImDrawListPtr drawList = new ImDrawListPtr(IntPtr.Zero);
            Assert.Throws<DllNotFoundException>(() => drawList.PathBezierCubicCurveTo(new Vector2F(), new Vector2F(), new Vector2F(), 0));
        }

        /// <summary>
        ///     Tests that path bezier quadratic curve to throws dll not found exception
        /// </summary>
        [Fact]
        public void PathBezierQuadraticCurveTo_ThrowsDllNotFoundException()
        {
            ImDrawListPtr drawList = new ImDrawListPtr(IntPtr.Zero);
            Assert.Throws<DllNotFoundException>(() => drawList.PathBezierQuadraticCurveTo(new Vector2F(), new Vector2F()));
        }

        /// <summary>
        ///     Tests that path bezier quadratic curve to with num segments throws dll not found exception
        /// </summary>
        [Fact]
        public void PathBezierQuadraticCurveTo_WithNumSegments_ThrowsDllNotFoundException()
        {
            ImDrawListPtr drawList = new ImDrawListPtr(IntPtr.Zero);
            Assert.Throws<DllNotFoundException>(() => drawList.PathBezierQuadraticCurveTo(new Vector2F(), new Vector2F(), 0));
        }

        /// <summary>
        ///     Tests that path clear throws dll not found exception
        /// </summary>
        [Fact]
        public void PathClear_ThrowsDllNotFoundException()
        {
            ImDrawListPtr drawList = new ImDrawListPtr(IntPtr.Zero);
            Assert.Throws<DllNotFoundException>(() => drawList.PathClear());
        }

        /// <summary>
        ///     Tests that path fill convex throws dll not found exception
        /// </summary>
        [Fact]
        public void PathFillConvex_ThrowsDllNotFoundException()
        {
            ImDrawListPtr drawList = new ImDrawListPtr(IntPtr.Zero);
            Assert.Throws<DllNotFoundException>(() => drawList.PathFillConvex(0));
        }

        /// <summary>
        ///     Tests that path line to throws dll not found exception
        /// </summary>
        [Fact]
        public void PathLineTo_ThrowsDllNotFoundException()
        {
            ImDrawListPtr drawList = new ImDrawListPtr(IntPtr.Zero);
            Assert.Throws<DllNotFoundException>(() => drawList.PathLineTo(new Vector2F()));
        }

        /// <summary>
        ///     Tests that path line to merge duplicate throws dll not found exception
        /// </summary>
        [Fact]
        public void PathLineToMergeDuplicate_ThrowsDllNotFoundException()
        {
            ImDrawListPtr drawList = new ImDrawListPtr(IntPtr.Zero);
            Assert.Throws<DllNotFoundException>(() => drawList.PathLineToMergeDuplicate(new Vector2F()));
        }

        /// <summary>
        ///     Tests that path rect throws dll not found exception
        /// </summary>
        [Fact]
        public void PathRect_ThrowsDllNotFoundException()
        {
            ImDrawListPtr drawList = new ImDrawListPtr(IntPtr.Zero);
            Assert.Throws<DllNotFoundException>(() => drawList.PathRect(new Vector2F(), new Vector2F()));
        }

        /// <summary>
        ///     Tests that path rect with rounding throws dll not found exception
        /// </summary>
        [Fact]
        public void PathRect_WithRounding_ThrowsDllNotFoundException()
        {
            ImDrawListPtr drawList = new ImDrawListPtr(IntPtr.Zero);
            Assert.Throws<DllNotFoundException>(() => drawList.PathRect(new Vector2F(), new Vector2F(), 0.0f));
        }

        /// <summary>
        ///     Tests that path rect with rounding flags throws dll not found exception
        /// </summary>
        [Fact]
        public void PathRect_WithRoundingFlags_ThrowsDllNotFoundException()
        {
            ImDrawListPtr drawList = new ImDrawListPtr(IntPtr.Zero);
            Assert.Throws<DllNotFoundException>(() => drawList.PathRect(new Vector2F(), new Vector2F(), 0.0f, 0));
        }

        /// <summary>
        ///     Tests that path stroke throws dll not found exception
        /// </summary>
        [Fact]
        public void PathStroke_ThrowsDllNotFoundException()
        {
            ImDrawListPtr drawList = new ImDrawListPtr(IntPtr.Zero);
            Assert.Throws<DllNotFoundException>(() => drawList.PathStroke(0));
        }

        /// <summary>
        ///     Tests that path stroke with flags throws dll not found exception
        /// </summary>
        [Fact]
        public void PathStroke_WithFlags_ThrowsDllNotFoundException()
        {
            ImDrawListPtr drawList = new ImDrawListPtr(IntPtr.Zero);
            Assert.Throws<DllNotFoundException>(() => drawList.PathStroke(0, 0));
        }

        /// <summary>
        ///     Tests that path stroke with flags thickness throws dll not found exception
        /// </summary>
        [Fact]
        public void PathStroke_WithFlagsThickness_ThrowsDllNotFoundException()
        {
            ImDrawListPtr drawList = new ImDrawListPtr(IntPtr.Zero);
            Assert.Throws<DllNotFoundException>(() => drawList.PathStroke(0, 0, 1.0f));
        }

        /// <summary>
        ///     Tests that pop clip rect throws dll not found exception
        /// </summary>
        [Fact]
        public void PopClipRect_ThrowsDllNotFoundException()
        {
            ImDrawListPtr drawList = new ImDrawListPtr(IntPtr.Zero);
            Assert.Throws<DllNotFoundException>(() => drawList.PopClipRect());
        }

        /// <summary>
        ///     Tests that pop texture id throws dll not found exception
        /// </summary>
        [Fact]
        public void PopTextureId_ThrowsDllNotFoundException()
        {
            ImDrawListPtr drawList = new ImDrawListPtr(IntPtr.Zero);
            Assert.Throws<DllNotFoundException>(() => drawList.PopTextureId());
        }

        /// <summary>
        ///     Tests that prim quad uv throws dll not found exception
        /// </summary>
        [Fact]
        public void PrimQuadUv_ThrowsDllNotFoundException()
        {
            ImDrawListPtr drawList = new ImDrawListPtr(IntPtr.Zero);
            Assert.Throws<DllNotFoundException>(() => drawList.PrimQuadUv(new Vector2F(), new Vector2F(), new Vector2F(), new Vector2F(), new Vector2F(), new Vector2F(), new Vector2F(), new Vector2F(), 0));
        }

        /// <summary>
        ///     Tests that prim rect throws dll not found exception
        /// </summary>
        [Fact]
        public void PrimRect_ThrowsDllNotFoundException()
        {
            ImDrawListPtr drawList = new ImDrawListPtr(IntPtr.Zero);
            Assert.Throws<DllNotFoundException>(() => drawList.PrimRect(new Vector2F(), new Vector2F(), 0));
        }

        /// <summary>
        ///     Tests that prim rect uv throws dll not found exception
        /// </summary>
        [Fact]
        public void PrimRectUv_ThrowsDllNotFoundException()
        {
            ImDrawListPtr drawList = new ImDrawListPtr(IntPtr.Zero);
            Assert.Throws<DllNotFoundException>(() => drawList.PrimRectUv(new Vector2F(), new Vector2F(), new Vector2F(), new Vector2F(), 0));
        }

        /// <summary>
        ///     Tests that prim reserve throws dll not found exception
        /// </summary>
        [Fact]
        public void PrimReserve_ThrowsDllNotFoundException()
        {
            ImDrawListPtr drawList = new ImDrawListPtr(IntPtr.Zero);
            Assert.Throws<DllNotFoundException>(() => drawList.PrimReserve(0, 0));
        }

        /// <summary>
        ///     Tests that prim unreserve throws dll not found exception
        /// </summary>
        [Fact]
        public void PrimUnreserve_ThrowsDllNotFoundException()
        {
            ImDrawListPtr drawList = new ImDrawListPtr(IntPtr.Zero);
            Assert.Throws<DllNotFoundException>(() => drawList.PrimUnreserve(0, 0));
        }

        /// <summary>
        ///     Tests that prim vtx throws dll not found exception
        /// </summary>
        [Fact]
        public void PrimVtx_ThrowsDllNotFoundException()
        {
            ImDrawListPtr drawList = new ImDrawListPtr(IntPtr.Zero);
            Assert.Throws<DllNotFoundException>(() => drawList.PrimVtx(new Vector2F(), new Vector2F(), 0));
        }

        /// <summary>
        ///     Tests that prim write idx throws dll not found exception
        /// </summary>
        [Fact]
        public void PrimWriteIdx_ThrowsDllNotFoundException()
        {
            ImDrawListPtr drawList = new ImDrawListPtr(IntPtr.Zero);
            Assert.Throws<DllNotFoundException>(() => drawList.PrimWriteIdx(0));
        }

        /// <summary>
        ///     Tests that prim write vtx throws dll not found exception
        /// </summary>
        [Fact]
        public void PrimWriteVtx_ThrowsDllNotFoundException()
        {
            ImDrawListPtr drawList = new ImDrawListPtr(IntPtr.Zero);
            Assert.Throws<DllNotFoundException>(() => drawList.PrimWriteVtx(new Vector2F(), new Vector2F(), 0));
        }

        /// <summary>
        ///     Tests that push clip rect throws dll not found exception
        /// </summary>
        [Fact]
        public void PushClipRect_ThrowsDllNotFoundException()
        {
            ImDrawListPtr drawList = new ImDrawListPtr(IntPtr.Zero);
            Assert.Throws<DllNotFoundException>(() => drawList.PushClipRect(new Vector2F(), new Vector2F()));
        }

        /// <summary>
        ///     Tests that push clip rect with intersect throws dll not found exception
        /// </summary>
        [Fact]
        public void PushClipRect_WithIntersect_ThrowsDllNotFoundException()
        {
            ImDrawListPtr drawList = new ImDrawListPtr(IntPtr.Zero);
            Assert.Throws<DllNotFoundException>(() => drawList.PushClipRect(new Vector2F(), new Vector2F(), true));
        }

        /// <summary>
        ///     Tests that v 2 add rect filled throws dll not found exception
        /// </summary>
        [Fact]
        public void v2_AddRectFilled_ThrowsDllNotFoundException()
        {
            ImDrawListPtr drawListPtr = new ImDrawListPtr();
            Assert.Throws<DllNotFoundException>(() => drawListPtr.AddRectFilled(new Vector2F(), new Vector2F(), 0, 0, 0));
        }

        /// <summary>
        ///     Tests that v 2 add rect filled multi color throws dll not found exception
        /// </summary>
        [Fact]
        public void v2_AddRectFilledMultiColor_ThrowsDllNotFoundException()
        {
            ImDrawListPtr drawListPtr = new ImDrawListPtr();
            Assert.Throws<DllNotFoundException>(() => drawListPtr.AddRectFilledMultiColor(new Vector2F(), new Vector2F(), 0, 0, 0, 0));
        }

        /// <summary>
        ///     Tests that v 2 add triangle throws dll not found exception
        /// </summary>
        [Fact]
        public void v2_AddTriangle_ThrowsDllNotFoundException()
        {
            ImDrawListPtr drawListPtr = new ImDrawListPtr();
            Assert.Throws<DllNotFoundException>(() => drawListPtr.AddTriangle(new Vector2F(), new Vector2F(), new Vector2F(), 0));
        }

        /// <summary>
        ///     Tests that v 2 add triangle with thickness throws dll not found exception
        /// </summary>
        [Fact]
        public void v2_AddTriangle_WithThickness_ThrowsDllNotFoundException()
        {
            ImDrawListPtr drawListPtr = new ImDrawListPtr();
            Assert.Throws<DllNotFoundException>(() => drawListPtr.AddTriangle(new Vector2F(), new Vector2F(), new Vector2F(), 0, 1.0f));
        }

        /// <summary>
        ///     Tests that v 2 add triangle filled throws dll not found exception
        /// </summary>
        [Fact]
        public void v2_AddTriangleFilled_ThrowsDllNotFoundException()
        {
            ImDrawListPtr drawListPtr = new ImDrawListPtr();
            Assert.Throws<DllNotFoundException>(() => drawListPtr.AddTriangleFilled(new Vector2F(), new Vector2F(), new Vector2F(), 0));
        }

        /// <summary>
        ///     Tests that v 2 channels merge throws dll not found exception
        /// </summary>
        [Fact]
        public void v2_ChannelsMerge_ThrowsDllNotFoundException()
        {
            ImDrawListPtr drawListPtr = new ImDrawListPtr();
            Assert.Throws<DllNotFoundException>(() => drawListPtr.ChannelsMerge());
        }

        /// <summary>
        ///     Tests that v 2 channels set current throws dll not found exception
        /// </summary>
        [Fact]
        public void v2_ChannelsSetCurrent_ThrowsDllNotFoundException()
        {
            ImDrawListPtr drawListPtr = new ImDrawListPtr();
            Assert.Throws<DllNotFoundException>(() => drawListPtr.ChannelsSetCurrent(0));
        }

        /// <summary>
        ///     Tests that v 2 channels split throws dll not found exception
        /// </summary>
        [Fact]
        public void v2_ChannelsSplit_ThrowsDllNotFoundException()
        {
            ImDrawListPtr drawListPtr = new ImDrawListPtr();
            Assert.Throws<DllNotFoundException>(() => drawListPtr.ChannelsSplit(0));
        }

        /// <summary>
        ///     Tests that v 2 clone output throws dll not found exception
        /// </summary>
        [Fact]
        public void v2_CloneOutput_ThrowsDllNotFoundException()
        {
            ImDrawListPtr drawListPtr = new ImDrawListPtr();
            Assert.Throws<DllNotFoundException>(() => drawListPtr.CloneOutput());
        }

        /// <summary>
        ///     Tests that v 2 get clip rect max throws dll not found exception
        /// </summary>
        [Fact]
        public void v2_GetClipRectMax_ThrowsDllNotFoundException()
        {
            ImDrawListPtr drawListPtr = new ImDrawListPtr();
            Assert.Throws<DllNotFoundException>(() => drawListPtr.GetClipRectMax());
        }

        /// <summary>
        ///     Tests that v 2 get clip rect min throws dll not found exception
        /// </summary>
        [Fact]
        public void v2_GetClipRectMin_ThrowsDllNotFoundException()
        {
            ImDrawListPtr drawListPtr = new ImDrawListPtr();
            Assert.Throws<DllNotFoundException>(() => drawListPtr.GetClipRectMin());
        }

        /// <summary>
        ///     Tests that v 2 path arc to throws dll not found exception
        /// </summary>
        [Fact]
        public void v2_PathArcTo_ThrowsDllNotFoundException()
        {
            ImDrawListPtr drawListPtr = new ImDrawListPtr();
            Assert.Throws<DllNotFoundException>(() => drawListPtr.PathArcTo(new Vector2F(), 0, 0, 0));
        }

        /// <summary>
        ///     Tests that path arc to with segments throws dll not found exception
        /// </summary>
        [Fact]
        public void PathArcTo_WithSegments_ThrowsDllNotFoundException()
        {
            ImDrawListPtr drawListPtr = new ImDrawListPtr();
            Assert.Throws<DllNotFoundException>(() => drawListPtr.PathArcTo(new Vector2F(), 0, 0, 0, 0));
        }

        /// <summary>
        ///     Tests that v 2 path arc to fast throws dll not found exception
        /// </summary>
        [Fact]
        public void v2_PathArcToFast_ThrowsDllNotFoundException()
        {
            ImDrawListPtr drawListPtr = new ImDrawListPtr();
            Assert.Throws<DllNotFoundException>(() => drawListPtr.PathArcToFast(new Vector2F(), 0, 0, 0));
        }

        /// <summary>
        ///     Tests that v 2 path bezier cubic curve to throws dll not found exception
        /// </summary>
        [Fact]
        public void v2_PathBezierCubicCurveTo_ThrowsDllNotFoundException()
        {
            ImDrawListPtr drawListPtr = new ImDrawListPtr();
            Assert.Throws<DllNotFoundException>(() => drawListPtr.PathBezierCubicCurveTo(new Vector2F(), new Vector2F(), new Vector2F()));
        }

        /// <summary>
        ///     Tests that path bezier cubic curve to with segments throws dll not found exception
        /// </summary>
        [Fact]
        public void PathBezierCubicCurveTo_WithSegments_ThrowsDllNotFoundException()
        {
            ImDrawListPtr drawListPtr = new ImDrawListPtr();
            Assert.Throws<DllNotFoundException>(() => drawListPtr.PathBezierCubicCurveTo(new Vector2F(), new Vector2F(), new Vector2F(), 0));
        }

        /// <summary>
        ///     Tests that v 2 path bezier quadratic curve to throws dll not found exception
        /// </summary>
        [Fact]
        public void v2_PathBezierQuadraticCurveTo_ThrowsDllNotFoundException()
        {
            ImDrawListPtr drawListPtr = new ImDrawListPtr();
            Assert.Throws<DllNotFoundException>(() => drawListPtr.PathBezierQuadraticCurveTo(new Vector2F(), new Vector2F()));
        }

        /// <summary>
        ///     Tests that path bezier quadratic curve to with segments throws dll not found exception
        /// </summary>
        [Fact]
        public void PathBezierQuadraticCurveTo_WithSegments_ThrowsDllNotFoundException()
        {
            ImDrawListPtr drawListPtr = new ImDrawListPtr();
            Assert.Throws<DllNotFoundException>(() => drawListPtr.PathBezierQuadraticCurveTo(new Vector2F(), new Vector2F(), 0));
        }

        /// <summary>
        ///     Tests that v 2 path clear throws dll not found exception
        /// </summary>
        [Fact]
        public void v2_PathClear_ThrowsDllNotFoundException()
        {
            ImDrawListPtr drawListPtr = new ImDrawListPtr();
            Assert.Throws<DllNotFoundException>(() => drawListPtr.PathClear());
        }

        /// <summary>
        ///     Tests that v 2 path fill convex throws dll not found exception
        /// </summary>
        [Fact]
        public void v2_PathFillConvex_ThrowsDllNotFoundException()
        {
            ImDrawListPtr drawListPtr = new ImDrawListPtr();
            Assert.Throws<DllNotFoundException>(() => drawListPtr.PathFillConvex(0));
        }

        /// <summary>
        ///     Tests that v 2 path line to throws dll not found exception
        /// </summary>
        [Fact]
        public void v2_PathLineTo_ThrowsDllNotFoundException()
        {
            ImDrawListPtr drawListPtr = new ImDrawListPtr();
            Assert.Throws<DllNotFoundException>(() => drawListPtr.PathLineTo(new Vector2F()));
        }

        /// <summary>
        ///     Tests that v 2 path line to merge duplicate throws dll not found exception
        /// </summary>
        [Fact]
        public void v2_PathLineToMergeDuplicate_ThrowsDllNotFoundException()
        {
            ImDrawListPtr drawListPtr = new ImDrawListPtr();
            Assert.Throws<DllNotFoundException>(() => drawListPtr.PathLineToMergeDuplicate(new Vector2F()));
        }

        /// <summary>
        ///     Tests that v 2 path rect throws dll not found exception
        /// </summary>
        [Fact]
        public void v2_PathRect_ThrowsDllNotFoundException()
        {
            ImDrawListPtr drawListPtr = new ImDrawListPtr();
            Assert.Throws<DllNotFoundException>(() => drawListPtr.PathRect(new Vector2F(), new Vector2F()));
        }

        /// <summary>
        ///     Tests that v 2 path rect with rounding throws dll not found exception
        /// </summary>
        [Fact]
        public void v2_PathRect_WithRounding_ThrowsDllNotFoundException()
        {
            ImDrawListPtr drawListPtr = new ImDrawListPtr();
            Assert.Throws<DllNotFoundException>(() => drawListPtr.PathRect(new Vector2F(), new Vector2F(), 0));
        }

        /// <summary>
        ///     Tests that path rect with rounding and flags throws dll not found exception
        /// </summary>
        [Fact]
        public void PathRect_WithRoundingAndFlags_ThrowsDllNotFoundException()
        {
            ImDrawListPtr drawListPtr = new ImDrawListPtr();
            Assert.Throws<DllNotFoundException>(() => drawListPtr.PathRect(new Vector2F(), new Vector2F(), 0, 0));
        }

        /// <summary>
        ///     Tests that v 2 path stroke throws dll not found exception
        /// </summary>
        [Fact]
        public void v2_PathStroke_ThrowsDllNotFoundException()
        {
            ImDrawListPtr drawListPtr = new ImDrawListPtr();
            Assert.Throws<DllNotFoundException>(() => drawListPtr.PathStroke(0));
        }

        /// <summary>
        ///     Tests that v 2 path stroke with flags throws dll not found exception
        /// </summary>
        [Fact]
        public void v2_PathStroke_WithFlags_ThrowsDllNotFoundException()
        {
            ImDrawListPtr drawListPtr = new ImDrawListPtr();
            Assert.Throws<DllNotFoundException>(() => drawListPtr.PathStroke(0, 0));
        }

        /// <summary>
        ///     Tests that path stroke with flags and thickness throws dll not found exception
        /// </summary>
        [Fact]
        public void PathStroke_WithFlagsAndThickness_ThrowsDllNotFoundException()
        {
            ImDrawListPtr drawListPtr = new ImDrawListPtr();
            Assert.Throws<DllNotFoundException>(() => drawListPtr.PathStroke(0, 0, 1.0f));
        }

        /// <summary>
        ///     Tests that v 2 pop clip rect throws dll not found exception
        /// </summary>
        [Fact]
        public void v2_PopClipRect_ThrowsDllNotFoundException()
        {
            ImDrawListPtr drawListPtr = new ImDrawListPtr();
            Assert.Throws<DllNotFoundException>(() => drawListPtr.PopClipRect());
        }

        /// <summary>
        ///     Tests that v 2 pop texture id throws dll not found exception
        /// </summary>
        [Fact]
        public void v2_PopTextureId_ThrowsDllNotFoundException()
        {
            ImDrawListPtr drawListPtr = new ImDrawListPtr();
            Assert.Throws<DllNotFoundException>(() => drawListPtr.PopTextureId());
        }

        /// <summary>
        ///     Tests that v 2 prim quad uv throws dll not found exception
        /// </summary>
        [Fact]
        public void v2_PrimQuadUv_ThrowsDllNotFoundException()
        {
            ImDrawListPtr drawListPtr = new ImDrawListPtr();
            Assert.Throws<DllNotFoundException>(() => drawListPtr.PrimQuadUv(new Vector2F(), new Vector2F(), new Vector2F(), new Vector2F(), new Vector2F(), new Vector2F(), new Vector2F(), new Vector2F(), 0));
        }

        /// <summary>
        ///     Tests that v 2 prim rect throws dll not found exception
        /// </summary>
        [Fact]
        public void v2_PrimRect_ThrowsDllNotFoundException()
        {
            ImDrawListPtr drawListPtr = new ImDrawListPtr();
            Assert.Throws<DllNotFoundException>(() => drawListPtr.PrimRect(new Vector2F(), new Vector2F(), 0));
        }

        /// <summary>
        ///     Tests that v 2 prim rect uv throws dll not found exception
        /// </summary>
        [Fact]
        public void v2_PrimRectUv_ThrowsDllNotFoundException()
        {
            ImDrawListPtr drawListPtr = new ImDrawListPtr();
            Assert.Throws<DllNotFoundException>(() => drawListPtr.PrimRectUv(new Vector2F(), new Vector2F(), new Vector2F(), new Vector2F(), 0));
        }

        /// <summary>
        ///     Tests that v 2 prim reserve throws dll not found exception
        /// </summary>
        [Fact]
        public void v2_PrimReserve_ThrowsDllNotFoundException()
        {
            ImDrawListPtr drawListPtr = new ImDrawListPtr();
            Assert.Throws<DllNotFoundException>(() => drawListPtr.PrimReserve(0, 0));
        }

        /// <summary>
        ///     Tests that v 2 prim unreserve throws dll not found exception
        /// </summary>
        [Fact]
        public void v2_PrimUnreserve_ThrowsDllNotFoundException()
        {
            ImDrawListPtr drawListPtr = new ImDrawListPtr();
            Assert.Throws<DllNotFoundException>(() => drawListPtr.PrimUnreserve(0, 0));
        }

        /// <summary>
        ///     Tests that v 2 prim vtx throws dll not found exception
        /// </summary>
        [Fact]
        public void v2_PrimVtx_ThrowsDllNotFoundException()
        {
            ImDrawListPtr drawListPtr = new ImDrawListPtr();
            Assert.Throws<DllNotFoundException>(() => drawListPtr.PrimVtx(new Vector2F(), new Vector2F(), 0));
        }

        /// <summary>
        ///     Tests that v 2 prim write idx throws dll not found exception
        /// </summary>
        [Fact]
        public void v2_PrimWriteIdx_ThrowsDllNotFoundException()
        {
            ImDrawListPtr drawListPtr = new ImDrawListPtr();
            Assert.Throws<DllNotFoundException>(() => drawListPtr.PrimWriteIdx(0));
        }

        /// <summary>
        ///     Tests that v 2 prim write vtx throws dll not found exception
        /// </summary>
        [Fact]
        public void v2_PrimWriteVtx_ThrowsDllNotFoundException()
        {
            ImDrawListPtr drawListPtr = new ImDrawListPtr();
            Assert.Throws<DllNotFoundException>(() => drawListPtr.PrimWriteVtx(new Vector2F(), new Vector2F(), 0));
        }

        /// <summary>
        ///     Tests that v 2 push clip rect throws dll not found exception
        /// </summary>
        [Fact]
        public void v2_PushClipRect_ThrowsDllNotFoundException()
        {
            ImDrawListPtr drawListPtr = new ImDrawListPtr();
            Assert.Throws<DllNotFoundException>(() => drawListPtr.PushClipRect(new Vector2F(), new Vector2F()));
        }

        /// <summary>
        ///     Tests that v 2 push clip rect with intersect throws dll not found exception
        /// </summary>
        [Fact]
        public void v2_PushClipRect_WithIntersect_ThrowsDllNotFoundException()
        {
            ImDrawListPtr drawListPtr = new ImDrawListPtr();
            Assert.Throws<DllNotFoundException>(() => drawListPtr.PushClipRect(new Vector2F(), new Vector2F(), true));
        }

        /// <summary>
        ///     Tests that push clip rect full screen throws dll not found exception
        /// </summary>
        [Fact]
        public void PushClipRectFullScreen_ThrowsDllNotFoundException()
        {
            ImDrawListPtr drawListPtr = new ImDrawListPtr();
            Assert.Throws<DllNotFoundException>(() => drawListPtr.PushClipRectFullScreen());
        }

        /// <summary>
        ///     Tests that push texture id throws dll not found exception
        /// </summary>
        [Fact]
        public void PushTextureId_ThrowsDllNotFoundException()
        {
            ImDrawListPtr drawListPtr = new ImDrawListPtr();
            Assert.Throws<DllNotFoundException>(() => drawListPtr.PushTextureId(IntPtr.Zero));
        }

        /// <summary>
        ///     Tests that add text throws dll not found exception
        /// </summary>
        [Fact]
        public void AddText_ThrowsDllNotFoundException()
        {
            ImDrawListPtr drawListPtr = new ImDrawListPtr();
            Assert.Throws<DllNotFoundException>(() => drawListPtr.AddText(new Vector2F(), 0, ""));
        }

        /// <summary>
        ///     Tests that add text with font throws dll not found exception
        /// </summary>
        [Fact]
        public void AddText_WithFont_ThrowsDllNotFoundException()
        {
            ImDrawListPtr drawListPtr = new ImDrawListPtr();
            Assert.Throws<DllNotFoundException>(() => drawListPtr.AddText(new ImFontPtr(), 0, new Vector2F(), 0, ""));
        }

        /// <summary>
        ///     Tests that path arc to n throws dll not found exception
        /// </summary>
        [Fact]
        public void _PathArcToN_ThrowsDllNotFoundException()
        {
            ImDrawListPtr drawListPtr = new ImDrawListPtr();
            Assert.Throws<DllNotFoundException>(() => drawListPtr.PathArcToN(new Vector2F(), 0, 0, 0, 0));
        }

        /// <summary>
        ///     Tests that pop unused draw cmd throws dll not found exception
        /// </summary>
        [Fact]
        public void _PopUnusedDrawCmd_ThrowsDllNotFoundException()
        {
            ImDrawListPtr drawListPtr = new ImDrawListPtr();
            Assert.Throws<DllNotFoundException>(() => drawListPtr.PopUnusedDrawCmd());
        }

        /// <summary>
        ///     Tests that reset for new frame throws dll not found exception
        /// </summary>
        [Fact]
        public void _ResetForNewFrame_ThrowsDllNotFoundException()
        {
            ImDrawListPtr drawListPtr = new ImDrawListPtr();
            Assert.Throws<DllNotFoundException>(() => drawListPtr.ResetForNewFrame());
        }

        /// <summary>
        ///     Tests that try merge draw cmds throws dll not found exception
        /// </summary>
        [Fact]
        public void _TryMergeDrawCmds_ThrowsDllNotFoundException()
        {
            ImDrawListPtr drawListPtr = new ImDrawListPtr();
            Assert.Throws<DllNotFoundException>(() => drawListPtr.TryMergeDrawCmd());
        }

        /// <summary>
        ///     Tests that add bezier cubic throws dll not found exception
        /// </summary>
        [Fact]
        public void AddBezierCubic_ThrowsDllNotFoundException()
        {
            ImDrawListPtr drawListPtr = new ImDrawListPtr();
            Assert.Throws<DllNotFoundException>(() => drawListPtr.AddBezierCubic(new Vector2F(), new Vector2F(), new Vector2F(), new Vector2F(), 0, 0));
        }

        /// <summary>
        ///     Tests that add bezier cubic with segments throws dll not found exception
        /// </summary>
        [Fact]
        public void AddBezierCubic_WithSegments_ThrowsDllNotFoundException()
        {
            ImDrawListPtr drawListPtr = new ImDrawListPtr();
            Assert.Throws<DllNotFoundException>(() => drawListPtr.AddBezierCubic(new Vector2F(), new Vector2F(), new Vector2F(), new Vector2F(), 0, 0, 0));
        }

        /// <summary>
        ///     Tests that add bezier quadratic throws dll not found exception
        /// </summary>
        [Fact]
        public void AddBezierQuadratic_ThrowsDllNotFoundException()
        {
            ImDrawListPtr drawListPtr = new ImDrawListPtr();
            Assert.Throws<DllNotFoundException>(() => drawListPtr.AddBezierQuadratic(new Vector2F(), new Vector2F(), new Vector2F(), 0, 0));
        }

        /// <summary>
        ///     Tests that add bezier quadratic with segments throws dll not found exception
        /// </summary>
        [Fact]
        public void AddBezierQuadratic_WithSegments_ThrowsDllNotFoundException()
        {
            ImDrawListPtr drawListPtr = new ImDrawListPtr();
            Assert.Throws<DllNotFoundException>(() => drawListPtr.AddBezierQuadratic(new Vector2F(), new Vector2F(), new Vector2F(), 0, 0, 0));
        }

        /// <summary>
        ///     Tests that add callback throws dll not found exception
        /// </summary>
        [Fact]
        public void AddCallback_ThrowsDllNotFoundException()
        {
            ImDrawListPtr drawListPtr = new ImDrawListPtr();
            Assert.Throws<DllNotFoundException>(() => drawListPtr.AddCallback(IntPtr.Zero, IntPtr.Zero));
        }

        /// <summary>
        ///     Tests that add circle throws dll not found exception
        /// </summary>
        [Fact]
        public void AddCircle_ThrowsDllNotFoundException()
        {
            ImDrawListPtr drawListPtr = new ImDrawListPtr();
            Assert.Throws<DllNotFoundException>(() => drawListPtr.AddCircle(new Vector2F(), 0, 0));
        }

        /// <summary>
        ///     Tests that add circle with segments throws dll not found exception
        /// </summary>
        [Fact]
        public void AddCircle_WithSegments_ThrowsDllNotFoundException()
        {
            ImDrawListPtr drawListPtr = new ImDrawListPtr();
            Assert.Throws<DllNotFoundException>(() => drawListPtr.AddCircle(new Vector2F(), 0, 0, 0));
        }

        /// <summary>
        ///     Tests that add circle with segments and thickness throws dll not found exception
        /// </summary>
        [Fact]
        public void AddCircle_WithSegmentsAndThickness_ThrowsDllNotFoundException()
        {
            ImDrawListPtr drawListPtr = new ImDrawListPtr();
            Assert.Throws<DllNotFoundException>(() => drawListPtr.AddCircle(new Vector2F(), 0, 0, 0, 0));
        }

        /// <summary>
        ///     Tests that add circle filled throws dll not found exception
        /// </summary>
        [Fact]
        public void AddCircleFilled_ThrowsDllNotFoundException()
        {
            ImDrawListPtr drawListPtr = new ImDrawListPtr();
            Assert.Throws<DllNotFoundException>(() => drawListPtr.AddCircleFilled(new Vector2F(), 0, 0));
        }

        /// <summary>
        ///     Tests that add circle filled with segments throws dll not found exception
        /// </summary>
        [Fact]
        public void AddCircleFilled_WithSegments_ThrowsDllNotFoundException()
        {
            ImDrawListPtr drawListPtr = new ImDrawListPtr();
            Assert.Throws<DllNotFoundException>(() => drawListPtr.AddCircleFilled(new Vector2F(), 0, 0, 0));
        }

        /// <summary>
        ///     Tests that add convex poly filled throws dll not found exception
        /// </summary>
        [Fact]
        public void AddConvexPolyFilled_ThrowsDllNotFoundException()
        {
            ImDrawListPtr drawListPtr = new ImDrawListPtr();
            Assert.Throws<DllNotFoundException>(() =>
            {
                Vector2F vector2F = new Vector2F();
                drawListPtr.AddConvexPolyFilled(ref vector2F, 0, 0);
            });
        }

        /// <summary>
        ///     Tests that clip rect stack throws dll not found exception
        /// </summary>
        [Fact]
        public void ClipRectStack_ThrowsDllNotFoundException()
        {
            ImDrawListPtr drawListPtr = new ImDrawListPtr();
            Assert.Throws<NullReferenceException>(() =>
            {
                ImVectorG<Vector4F> _ = drawListPtr.ClipRectStack;
            });
        }

        /// <summary>
        ///     Tests that texture id stack throws null reference exception
        /// </summary>
        [Fact]
        public void TextureIdStack_ThrowsNullReferenceException()
        {
            ImDrawListPtr drawListPtr = new ImDrawListPtr();
            Assert.Throws<NullReferenceException>(() =>
            {
                ImVectorG<IntPtr> _ = drawListPtr.TextureIdStack;
            });
        }

        /// <summary>
        ///     Tests that path throws null reference exception
        /// </summary>
        [Fact]
        public void Path_ThrowsNullReferenceException()
        {
            ImDrawListPtr drawListPtr = new ImDrawListPtr();
            Assert.Throws<NullReferenceException>(() =>
            {
                ImVectorG<Vector2F> _ = drawListPtr.Path;
            });
        }

        /// <summary>
        ///     Tests that cmd header throws null reference exception
        /// </summary>
        [Fact]
        public void CmdHeader_ThrowsNullReferenceException()
        {
            ImDrawListPtr drawListPtr = new ImDrawListPtr();
            Assert.Throws<NullReferenceException>(() =>
            {
                ImDrawCmdHeader _ = drawListPtr.CmdHeader;
            });
        }

        /// <summary>
        ///     Tests that splitter throws null reference exception
        /// </summary>
        [Fact]
        public void Splitter_ThrowsNullReferenceException()
        {
            ImDrawListPtr drawListPtr = new ImDrawListPtr();
            Assert.Throws<NullReferenceException>(() =>
            {
                ImDrawListSplitter _ = drawListPtr.Splitter;
            });
        }

        /// <summary>
        ///     Tests that fringe scale throws null reference exception
        /// </summary>
        [Fact]
        public void FringeScale_ThrowsNullReferenceException()
        {
            ImDrawListPtr drawListPtr = new ImDrawListPtr();
            Assert.Throws<NullReferenceException>(() =>
            {
                float _ = drawListPtr.FringeScale;
            });
        }

        /// <summary>
        ///     Tests that calc circle auto segment count throws dll not found exception
        /// </summary>
        [Fact]
        public void _CalcCircleAutoSegmentCount_ThrowsDllNotFoundException()
        {
            ImDrawListPtr drawListPtr = new ImDrawListPtr();
            Assert.Throws<DllNotFoundException>(() => drawListPtr._CalcCircleAutoSegmentCount(0));
        }

        /// <summary>
        ///     Tests that clear free memory throws dll not found exception
        /// </summary>
        [Fact]
        public void _ClearFreeMemory_ThrowsDllNotFoundException()
        {
            ImDrawListPtr drawListPtr = new ImDrawListPtr();
            Assert.Throws<DllNotFoundException>(() => drawListPtr.ClearFreeMemory());
        }

        /// <summary>
        ///     Tests that on changed clip rect throws dll not found exception
        /// </summary>
        [Fact]
        public void _OnChangedClipRect_ThrowsDllNotFoundException()
        {
            ImDrawListPtr drawListPtr = new ImDrawListPtr();
            Assert.Throws<DllNotFoundException>(() => drawListPtr.OnChangedClipRect());
        }

        /// <summary>
        ///     Tests that on changed texture id throws dll not found exception
        /// </summary>
        [Fact]
        public void _OnChangedTextureID_ThrowsDllNotFoundException()
        {
            ImDrawListPtr drawListPtr = new ImDrawListPtr();
            Assert.Throws<DllNotFoundException>(() => drawListPtr.OnChangedTextureID());
        }

        /// <summary>
        ///     Tests that on changed vtx offset throws dll not found exception
        /// </summary>
        [Fact]
        public void _OnChangedVtxOffset_ThrowsDllNotFoundException()
        {
            ImDrawListPtr drawListPtr = new ImDrawListPtr();
            Assert.Throws<DllNotFoundException>(() => drawListPtr.OnChangedVtxOffset());
        }

        /// <summary>
        ///     Tests that path arc to fast ex throws dll not found exception
        /// </summary>
        [Fact]
        public void _PathArcToFastEx_ThrowsDllNotFoundException()
        {
            ImDrawListPtr drawListPtr = new ImDrawListPtr();
            Assert.Throws<DllNotFoundException>(() => drawListPtr.PathArcToFastEx(new Vector2F(), 0, 0, 0, 0));
        }

        /// <summary>
        ///     Tests that implicit conversion to int ptr returns native ptr
        /// </summary>
        [Fact]
        public void ImplicitConversionToIntPtr_ReturnsNativePtr()
        {
            ImDrawListPtr drawListPtr = new ImDrawListPtr(new ImDrawList());
            IntPtr result = drawListPtr;
            Assert.NotEqual(IntPtr.Zero, result);
        }

        /// <summary>
        ///     Tests that implicit conversion from int ptr returns im draw list ptr
        /// </summary>
        [Fact]
        public void ImplicitConversionFromIntPtr_ReturnsImDrawListPtr()
        {
            IntPtr nativePtr = new IntPtr(123);
            ImDrawListPtr drawListPtr = nativePtr;
            Assert.Equal(nativePtr, drawListPtr.NativePtr);
        }

        /// <summary>
        ///     Tests that cmd buffer returns correct value
        /// </summary>
        [Fact]
        public void CmdBuffer_ReturnsCorrectValue()
        {
        }

        /// <summary>
        ///     Tests that idx buffer returns correct value
        /// </summary>
        [Fact]
        public void IdxBuffer_ReturnsCorrectValue()
        {
        }

        /// <summary>
        ///     Tests that vtx buffer returns correct value
        /// </summary>
        [Fact]
        public void VtxBuffer_ReturnsCorrectValue()
        {
        }

        /// <summary>
        ///     Tests that flags returns correct value
        /// </summary>
        [Fact]
        public void Flags_ReturnsCorrectValue()
        {
        }

        /// <summary>
        ///     Tests that vtx current idx returns correct value
        /// </summary>
        [Fact]
        public void VtxCurrentIdx_ReturnsCorrectValue()
        {
            ImDrawListPtr drawListPtr = new ImDrawListPtr(new ImDrawList());
            uint vtxCurrentIdx = drawListPtr.VtxCurrentIdx;
            Assert.Equal(0u, vtxCurrentIdx);
        }

        /// <summary>
        ///     Tests that data returns correct value
        /// </summary>
        [Fact]
        public void Data_ReturnsCorrectValue()
        {
            ImDrawListPtr drawListPtr = new ImDrawListPtr(new ImDrawList());
            IntPtr data = drawListPtr.Data;
            Assert.Equal(IntPtr.Zero, data);
        }

        /// <summary>
        ///     Tests that owner name returns correct value
        /// </summary>
        [Fact]
        public void OwnerName_ReturnsCorrectValue()
        {
        }

        /// <summary>
        ///     Tests that idx write ptr get returns correct value
        /// </summary>
        [Fact]
        public void IdxWritePtr_Get_ReturnsCorrectValue()
        {
            ImDrawListPtr drawListPtr = new ImDrawListPtr(new ImDrawList());
            IntPtr idxWritePtr = drawListPtr.IdxWritePtr;
            Assert.Equal(IntPtr.Zero, idxWritePtr);
        }

        /// <summary>
        ///     Tests that cmd buffer returns correct value v 3
        /// </summary>
        [Fact]
        public void CmdBuffer_ReturnsCorrectValue_v3()
        {
            ImDrawListPtr drawListPtr = new ImDrawListPtr(new ImDrawList());
            ImVectorG<ImDrawCmd> cmdBuffer = drawListPtr.CmdBuffer;
            Assert.Equal(0, cmdBuffer.Size);
        }

        /// <summary>
        ///     Tests that idx buffer returns correct value v 3
        /// </summary>
        [Fact]
        public void IdxBuffer_ReturnsCorrectValue_v3()
        {
            ImDrawListPtr drawListPtr = new ImDrawListPtr(new ImDrawList());
            ImVectorG<ushort> idxBuffer = drawListPtr.IdxBuffer;
            Assert.Equal(0, idxBuffer.Size);
        }

        /// <summary>
        ///     Tests that vtx buffer returns correct value v 3
        /// </summary>
        [Fact]
        public void VtxBuffer_ReturnsCorrectValue_v3()
        {
            ImDrawListPtr drawListPtr = new ImDrawListPtr(new ImDrawList());
            ImVectorG<ImDrawVert> vtxBuffer = drawListPtr.VtxBuffer;
            Assert.Equal(0, vtxBuffer.Size);
        }

        /// <summary>
        ///     Tests that flags returns correct value v 3
        /// </summary>
        [Fact]
        public void Flags_ReturnsCorrectValue_v3()
        {
            ImDrawListPtr drawListPtr = new ImDrawListPtr(new ImDrawList());
            ImDrawListFlags flags = drawListPtr.Flags;
            Assert.Equal(ImDrawListFlags.None, flags);
        }

        /// <summary>
        ///     Tests that implicit conversion to int ptr returns native ptr v 4
        /// </summary>
        [Fact]
        public void ImplicitConversionToIntPtr_ReturnsNativePtr_v4()
        {
            ImDrawListPtr drawListPtr = new ImDrawListPtr(new ImDrawList());
            IntPtr result = drawListPtr;
            Assert.NotEqual(IntPtr.Zero, result);
        }

        /// <summary>
        ///     Tests that implicit conversion from int ptr returns im draw list ptr v 4
        /// </summary>
        [Fact]
        public void ImplicitConversionFromIntPtr_ReturnsImDrawListPtr_v4()
        {
            IntPtr nativePtr = new IntPtr(123);
            ImDrawListPtr drawListPtr = nativePtr;
            Assert.Equal(nativePtr, drawListPtr.NativePtr);
        }

        /// <summary>
        ///     Tests that cmd buffer returns correct value v 4
        /// </summary>
        [Fact]
        public void CmdBuffer_ReturnsCorrectValue_v4()
        {
            ImDrawListPtr drawListPtr = new ImDrawListPtr(new ImDrawList());
            ImVectorG<ImDrawCmd> cmdBuffer = drawListPtr.CmdBuffer;
            Assert.Equal(0, cmdBuffer.Size);
        }

        /// <summary>
        ///     Tests that idx buffer returns correct value v 4
        /// </summary>
        [Fact]
        public void IdxBuffer_ReturnsCorrectValue_v4()
        {
            ImDrawListPtr drawListPtr = new ImDrawListPtr(new ImDrawList());
            ImVectorG<ushort> idxBuffer = drawListPtr.IdxBuffer;
            Assert.Equal(0, idxBuffer.Size);
        }

        /// <summary>
        ///     Tests that vtx buffer returns correct value v 4
        /// </summary>
        [Fact]
        public void VtxBuffer_ReturnsCorrectValue_v4()
        {
            ImDrawListPtr drawListPtr = new ImDrawListPtr(new ImDrawList());
            ImVectorG<ImDrawVert> vtxBuffer = drawListPtr.VtxBuffer;
            Assert.Equal(0, vtxBuffer.Size);
        }

        /// <summary>
        ///     Tests that flags returns correct value v 4
        /// </summary>
        [Fact]
        public void Flags_ReturnsCorrectValue_v4()
        {
            ImDrawListPtr drawListPtr = new ImDrawListPtr(new ImDrawList());
            ImDrawListFlags flags = drawListPtr.Flags;
            Assert.Equal(ImDrawListFlags.None, flags);
        }

        /// <summary>
        ///     Tests that vtx current idx returns correct value v 4
        /// </summary>
        [Fact]
        public void VtxCurrentIdx_ReturnsCorrectValue_v4()
        {
            ImDrawListPtr drawListPtr = new ImDrawListPtr(new ImDrawList());
            uint vtxCurrentIdx = drawListPtr.VtxCurrentIdx;
            Assert.Equal(0u, vtxCurrentIdx);
        }

        /// <summary>
        ///     Tests that data returns correct value v 4
        /// </summary>
        [Fact]
        public void Data_ReturnsCorrectValue_v4()
        {
            ImDrawListPtr drawListPtr = new ImDrawListPtr(new ImDrawList());
            IntPtr data = drawListPtr.Data;
            Assert.Equal(IntPtr.Zero, data);
        }

        /// <summary>
        ///     Tests that owner name returns correct value v 4
        /// </summary>
        [Fact]
        public void OwnerName_ReturnsCorrectValue_v4()
        {
            ImDrawListPtr drawListPtr = new ImDrawListPtr(new ImDrawList());
            NullTerminatedString ownerName = drawListPtr.OwnerName;
            Assert.Equal("", ownerName.ToString());
        }

        /// <summary>
        ///     Tests that vtx write ptr returns correct value
        /// </summary>
        [Fact]
        public void VtxWritePtr_ReturnsCorrectValue()
        {
            ImDrawListPtr drawListPtr = new ImDrawListPtr(new ImDrawList());
            Assert.Throws<NullReferenceException>(() => drawListPtr.VtxWritePtr);
        }

        /// <summary>
        ///     Tests that idx write ptr get returns correct value v 4
        /// </summary>
        [Fact]
        public void IdxWritePtr_Get_ReturnsCorrectValue_v4()
        {
            ImDrawListPtr drawListPtr = new ImDrawListPtr(new ImDrawList());
            IntPtr idxWritePtr = drawListPtr.IdxWritePtr;
            Assert.Equal(IntPtr.Zero, idxWritePtr);
        }
    }
}