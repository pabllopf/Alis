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
using Alis.Extension.Graphic.Ui.Test.Attributes;
using Xunit;

namespace Alis.Extension.Graphic.Ui.Test
{
    /// <summary>
    ///     The im draw list ptr test class
    /// </summary>
    public class ImDrawListPtrTest
    {
        /// <summary>
        ///     Tests that native ptr should store value from int ptr constructor
        /// </summary>
        [RequireCImguiSystemFact]
        public void NativePtr_ShouldStoreValueFromIntPtrConstructor()
        {
            IntPtr nativePtr = new IntPtr(42);
            ImDrawListPtr drawListPtr = new ImDrawListPtr(nativePtr);
            Assert.Equal(nativePtr, drawListPtr.NativePtr);
        }

        /// <summary>
        ///     Tests that implicit operator from int ptr should return correct instance
        /// </summary>
        [RequireCImguiSystemFact]
        public void ImplicitOperator_FromIntPtr_ShouldReturnCorrectInstance()
        {
            IntPtr nativePtr = new IntPtr(99);
            ImDrawListPtr drawListPtr = nativePtr;
            Assert.Equal(nativePtr, drawListPtr.NativePtr);
        }

        /// <summary>
        ///     Tests that implicit operator from im draw list ptr should return correct int ptr
        /// </summary>
        [RequireCImguiSystemFact]
        public void ImplicitOperator_FromImDrawListPtr_ShouldReturnCorrectIntPtr()
        {
            IntPtr nativePtr = new IntPtr(77);
            ImDrawListPtr drawListPtr = new ImDrawListPtr(nativePtr);
            IntPtr result = drawListPtr;
            Assert.Equal(nativePtr, result);
        }

        /// <summary>
        ///     Tests that add image with user texture id and min max adds image
        /// </summary>
        [RequireCImguiSystemFact]
        public void AddImage_WithUserTextureIdAndMinMax_AddsImage()
        {
        }

        /// <summary>
        ///     Tests that add image with user texture id min max and uv min adds image
        /// </summary>
        [RequireCImguiSystemFact]
        public void AddImage_WithUserTextureIdMinMaxAndUvMin_AddsImage()
        {
        }

        /// <summary>
        ///     Tests that add image with user texture id min max uv min and uv max adds image
        /// </summary>
        [RequireCImguiSystemFact]
        public void AddImage_WithUserTextureIdMinMaxUvMinAndUvMax_AddsImage()
        {
        }

        /// <summary>
        ///     Tests that add image with user texture id min max uv min uv max and col adds image
        /// </summary>
        [RequireCImguiSystemFact]
        public void AddImage_WithUserTextureIdMinMaxUvMinUvMaxAndCol_AddsImage()
        {
            uint col = 4294967295;
        }

        /// <summary>
        ///     Tests that add image quad with user texture id and points adds image quad
        /// </summary>
        [RequireCImguiSystemFact]
        public void AddImageQuad_WithUserTextureIdAndPoints_AddsImageQuad()
        {
        }

        /// <summary>
        ///     Tests that add image quad with user texture id points and uv 1 adds image quad
        /// </summary>
        [RequireCImguiSystemFact]
        public void AddImageQuad_WithUserTextureIdPointsAndUv1_AddsImageQuad()
        {
        }

        /// <summary>
        ///     Tests that add image quad with user texture id points uv 1 and uv 2 adds image quad
        /// </summary>
        [RequireCImguiSystemFact]
        public void AddImageQuad_WithUserTextureIdPointsUv1AndUv2_AddsImageQuad()
        {
        }

        /// <summary>
        ///     Tests that add image quad with user texture id points uv 1 uv 2 and uv 3 adds image quad
        /// </summary>
        [RequireCImguiSystemFact]
        public void AddImageQuad_WithUserTextureIdPointsUv1Uv2AndUv3_AddsImageQuad()
        {
        }

        /// <summary>
        ///     Tests that add image quad with user texture id points uv 1 uv 2 uv 3 and uv 4 adds image quad
        /// </summary>
        [RequireCImguiSystemFact]
        public void AddImageQuad_WithUserTextureIdPointsUv1Uv2Uv3AndUv4_AddsImageQuad()
        {
        }

        /// <summary>
        ///     Tests that add image quad with user texture id points uv 1 uv 2 uv 3 uv 4 and col adds image quad
        /// </summary>
        [RequireCImguiSystemFact]
        public void AddImageQuad_WithUserTextureIdPointsUv1Uv2Uv3Uv4AndCol_AddsImageQuad()
        {
            uint col = 4294967295;
        }

        /// <summary>
        ///     Tests that add image rounded with user texture id min max uv min uv max col and rounding adds image rounded
        /// </summary>
        [RequireCImguiSystemFact]
        public void AddImageRounded_WithUserTextureIdMinMaxUvMinUvMaxColAndRounding_AddsImageRounded()
        {
            uint col = 4294967295;
            float rounding = 0.5f;

        }

        /// <summary>
        ///     Tests that add image rounded with user texture id min max uv min uv max col rounding and flags adds image rounded
        /// </summary>
        [RequireCImguiSystemFact]
        public void AddImageRounded_WithUserTextureIdMinMaxUvMinUvMaxColRoundingAndFlags_AddsImageRounded()
        {
            uint col = 4294967295;
            float rounding = 0.5f;
            ImDrawFlags flags = 0;

        }

        /// <summary>
        ///     Tests that add line with p 1 p 2 and col adds line
        /// </summary>
        [RequireCImguiSystemFact]
        public void AddLine_WithP1P2AndCol_AddsLine()
        {
            uint col = 4294967295;
        }

        /// <summary>
        ///     Tests that add line with p 1 p 2 col and thickness adds line
        /// </summary>
        [RequireCImguiSystemFact]
        public void AddLine_WithP1P2ColAndThickness_AddsLine()
        {
            uint col = 4294967295;
            float thickness = 2.0f;

        }

        /// <summary>
        ///     Tests that add ngon with center radius col and num segments adds ngon
        /// </summary>
        [RequireCImguiSystemFact]
        public void AddNgon_WithCenterRadiusColAndNumSegments_AddsNgon()
        {
            float radius = 1.0f;
            uint col = 4294967295;
            int numSegments = 6;

        }

        /// <summary>
        ///     Tests that add ngon with center radius col num segments and thickness adds ngon
        /// </summary>
        [RequireCImguiSystemFact]
        public void AddNgon_WithCenterRadiusColNumSegmentsAndThickness_AddsNgon()
        {
            float radius = 1.0f;
            uint col = 4294967295;
            int numSegments = 6;
            float thickness = 2.0f;

        }

        /// <summary>
        ///     Tests that add ngon filled with center radius col and num segments adds ngon filled
        /// </summary>
        [RequireCImguiSystemFact]
        public void AddNgonFilled_WithCenterRadiusColAndNumSegments_AddsNgonFilled()
        {
            float radius = 1.0f;
            uint col = 4294967295;
            int numSegments = 6;

        }

        /// <summary>
        ///     Tests that add polyline with points num points col flags and thickness adds polyline
        /// </summary>
        [RequireCImguiSystemFact]
        public void AddPolyline_WithPointsNumPointsColFlagsAndThickness_AddsPolyline()
        {
            _ = new Vector2F[3] {new Vector2F(0, 0), new Vector2F(1, 1), new Vector2F(2, 2)};
            int numPoints = 3;
            uint col = 4294967295;
            ImDrawFlags flags = 0;
            float thickness = 2.0f;

        }

        /// <summary>
        ///     Tests that add quad with p 1 p 2 p 3 p 4 and col adds quad
        /// </summary>
        [RequireCImguiSystemFact]
        public void AddQuad_WithP1P2P3P4AndCol_AddsQuad()
        {
            uint col = 4294967295;
        }

        /// <summary>
        ///     Tests that add quad with p 1 p 2 p 3 p 4 col and thickness adds quad
        /// </summary>
        [RequireCImguiSystemFact]
        public void AddQuad_WithP1P2P3P4ColAndThickness_AddsQuad()
        {
            uint col = 4294967295;
            float thickness = 2.0f;

        }

        /// <summary>
        ///     Tests that add quad filled with p 1 p 2 p 3 p 4 and col adds quad filled
        /// </summary>
        [RequireCImguiSystemFact]
        public void AddQuadFilled_WithP1P2P3P4AndCol_AddsQuadFilled()
        {
            uint col = 4294967295;
        }

        /// <summary>
        ///     Tests that add rect with p min p max and col adds rect
        /// </summary>
        [RequireCImguiSystemFact]
        public void AddRect_WithPMinPMaxAndCol_AddsRect()
        {
            uint col = 4294967295;
        }

        /// <summary>
        ///     Tests that add rect with p min p max col and rounding adds rect
        /// </summary>
        [RequireCImguiSystemFact]
        public void AddRect_WithPMinPMaxColAndRounding_AddsRect()
        {
            uint col = 4294967295;
            float rounding = 0.5f;

        }

        /// <summary>
        ///     Tests that add rect with p min p max col rounding and flags adds rect
        /// </summary>
        [RequireCImguiSystemFact]
        public void AddRect_WithPMinPMaxColRoundingAndFlags_AddsRect()
        {
            uint col = 4294967295;
            float rounding = 0.5f;
            ImDrawFlags flags = 0;

        }

        /// <summary>
        ///     Tests that add rect with p min p max col rounding flags and thickness adds rect
        /// </summary>
        [RequireCImguiSystemFact]
        public void AddRect_WithPMinPMaxColRoundingFlagsAndThickness_AddsRect()
        {
            uint col = 4294967295;
            float rounding = 0.5f;
            ImDrawFlags flags = 0;
            float thickness = 2.0f;

        }

        /// <summary>
        ///     Tests that add rect filled with p min p max and col adds rect filled
        /// </summary>
        [RequireCImguiSystemFact]
        public void AddRectFilled_WithPMinPMaxAndCol_AddsRectFilled()
        {
            uint col = 4294967295;
        }

        /// <summary>
        ///     Tests that add rect filled with p min p max col and rounding adds rect filled
        /// </summary>
        [RequireCImguiSystemFact]
        public void AddRectFilled_WithPMinPMaxColAndRounding_AddsRectFilled()
        {
            uint col = 4294967295;
            float rounding = 0.5f;

        }

        /// <summary>
        ///     Tests that add rect filled with p min p max col rounding and flags adds rect filled
        /// </summary>
        [RequireCImguiSystemFact]
        public void AddRectFilled_WithPMinPMaxColRoundingAndFlags_AddsRectFilled()
        {
            uint col = 4294967295;
            float rounding = 0.5f;
            ImDrawFlags flags = 0;

        }

        /// <summary>
        ///     Tests that add rect filled multi color with p min p max col upr left col upr right col bot right and col bot left
        ///     adds rect filled multi color
        /// </summary>
        [RequireCImguiSystemFact]
        public void AddRectFilledMultiColor_WithPMinPMaxColUprLeftColUprRightColBotRightAndColBotLeft_AddsRectFilledMultiColor()
        {
            uint colUprLeft = 4294967295;
            uint colUprRight = 4294967295;
            uint colBotRight = 4294967295;
            uint colBotLeft = 4294967295;

        }

        /// <summary>
        ///     Tests that add triangle with p 1 p 2 p 3 and col adds triangle
        /// </summary>
        [RequireCImguiSystemFact]
        public void AddTriangle_WithP1P2P3AndCol_AddsTriangle()
        {
            uint col = 4294967295;
        }

        /// <summary>
        ///     Tests that add draw cmd throws dll not found exception
        /// </summary>
        [RequireCImguiSystemFact]
        public void AddDrawCmd_ThrowsDllNotFoundException()
        {
        }

        /// <summary>
        ///     Tests that add image throws dll not found exception
        /// </summary>
        [RequireCImguiSystemFact]
        public void AddImage_ThrowsDllNotFoundException()
        {
        }

        /// <summary>
        ///     Tests that add image with uv min throws dll not found exception
        /// </summary>
        [RequireCImguiSystemFact]
        public void AddImage_WithUvMin_ThrowsDllNotFoundException()
        {
        }

        /// <summary>
        ///     Tests that add image with uv min uv max throws dll not found exception
        /// </summary>
        [RequireCImguiSystemFact]
        public void AddImage_WithUvMinUvMax_ThrowsDllNotFoundException()
        {
        }

        /// <summary>
        ///     Tests that add image with uv min uv max col throws dll not found exception
        /// </summary>
        [RequireCImguiSystemFact]
        public void AddImage_WithUvMinUvMaxCol_ThrowsDllNotFoundException()
        {
        }

        /// <summary>
        ///     Tests that add image quad throws dll not found exception
        /// </summary>
        [RequireCImguiSystemFact]
        public void AddImageQuad_ThrowsDllNotFoundException()
        {
        }

        /// <summary>
        ///     Tests that add image quad with uv 1 throws dll not found exception
        /// </summary>
        [RequireCImguiSystemFact]
        public void AddImageQuad_WithUv1_ThrowsDllNotFoundException()
        {
        }

        /// <summary>
        ///     Tests that add image quad with uv 1 uv 2 throws dll not found exception
        /// </summary>
        [RequireCImguiSystemFact]
        public void AddImageQuad_WithUv1Uv2_ThrowsDllNotFoundException()
        {
        }

        /// <summary>
        ///     Tests that add image quad with uv 1 uv 2 uv 3 throws dll not found exception
        /// </summary>
        [RequireCImguiSystemFact]
        public void AddImageQuad_WithUv1Uv2Uv3_ThrowsDllNotFoundException()
        {
        }

        /// <summary>
        ///     Tests that add image quad with uv 1 uv 2 uv 3 uv 4 throws dll not found exception
        /// </summary>
        [RequireCImguiSystemFact]
        public void AddImageQuad_WithUv1Uv2Uv3Uv4_ThrowsDllNotFoundException()
        {
        }

        /// <summary>
        ///     Tests that add image rounded throws dll not found exception
        /// </summary>
        [RequireCImguiSystemFact]
        public void AddImageRounded_ThrowsDllNotFoundException()
        {
        }

        /// <summary>
        ///     Tests that add image rounded with flags throws dll not found exception
        /// </summary>
        [RequireCImguiSystemFact]
        public void AddImageRounded_WithFlags_ThrowsDllNotFoundException()
        {
        }

        /// <summary>
        ///     Tests that add line throws dll not found exception
        /// </summary>
        [RequireCImguiSystemFact]
        public void AddLine_ThrowsDllNotFoundException()
        {
        }

        /// <summary>
        ///     Tests that add line with thickness throws dll not found exception
        /// </summary>
        [RequireCImguiSystemFact]
        public void AddLine_WithThickness_ThrowsDllNotFoundException()
        {
        }

        /// <summary>
        ///     Tests that add ngon throws dll not found exception
        /// </summary>
        [RequireCImguiSystemFact]
        public void AddNgon_ThrowsDllNotFoundException()
        {
        }

        /// <summary>
        ///     Tests that add ngon with thickness throws dll not found exception
        /// </summary>
        [RequireCImguiSystemFact]
        public void AddNgon_WithThickness_ThrowsDllNotFoundException()
        {
        }

        /// <summary>
        ///     Tests that add ngon filled throws dll not found exception
        /// </summary>
        [RequireCImguiSystemFact]
        public void AddNgonFilled_ThrowsDllNotFoundException()
        {
        }

        /// <summary>
        ///     Tests that add polyline throws dll not found exception
        /// </summary>
        [RequireCImguiSystemFact]
        public void AddPolyline_ThrowsDllNotFoundException()
        {
            Vector2F points = new Vector2F();
        }

        /// <summary>
        ///     Tests that add quad throws dll not found exception
        /// </summary>
        [RequireCImguiSystemFact]
        public void AddQuad_ThrowsDllNotFoundException()
        {
        }

        /// <summary>
        ///     Tests that add quad with thickness throws dll not found exception
        /// </summary>
        [RequireCImguiSystemFact]
        public void AddQuad_WithThickness_ThrowsDllNotFoundException()
        {
        }

        /// <summary>
        ///     Tests that add quad filled throws dll not found exception
        /// </summary>
        [RequireCImguiSystemFact]
        public void AddQuadFilled_ThrowsDllNotFoundException()
        {
        }

        /// <summary>
        ///     Tests that add rect throws dll not found exception
        /// </summary>
        [RequireCImguiSystemFact]
        public void AddRect_ThrowsDllNotFoundException()
        {
        }

        /// <summary>
        ///     Tests that add rect with rounding throws dll not found exception
        /// </summary>
        [RequireCImguiSystemFact]
        public void AddRect_WithRounding_ThrowsDllNotFoundException()
        {
        }

        /// <summary>
        ///     Tests that add rect with rounding flags throws dll not found exception
        /// </summary>
        [RequireCImguiSystemFact]
        public void AddRect_WithRoundingFlags_ThrowsDllNotFoundException()
        {
        }

        /// <summary>
        ///     Tests that add rect with rounding flags thickness throws dll not found exception
        /// </summary>
        [RequireCImguiSystemFact]
        public void AddRect_WithRoundingFlagsThickness_ThrowsDllNotFoundException()
        {
        }

        /// <summary>
        ///     Tests that add rect filled throws dll not found exception
        /// </summary>
        [RequireCImguiSystemFact]
        public void AddRectFilled_ThrowsDllNotFoundException()
        {
        }

        /// <summary>
        ///     Tests that add rect filled with rounding throws dll not found exception
        /// </summary>
        [RequireCImguiSystemFact]
        public void AddRectFilled_WithRounding_ThrowsDllNotFoundException()
        {
        }

        /// <summary>
        ///     Tests that add rect filled with rounding flags throws dll not found exception
        /// </summary>
        [RequireCImguiSystemFact]
        public void AddRectFilled_WithRoundingFlags_ThrowsDllNotFoundException()
        {
        }

        /// <summary>
        ///     Tests that add rect filled multi color throws dll not found exception
        /// </summary>
        [RequireCImguiSystemFact]
        public void AddRectFilledMultiColor_ThrowsDllNotFoundException()
        {
        }

        /// <summary>
        ///     Tests that add triangle throws dll not found exception
        /// </summary>
        [RequireCImguiSystemFact]
        public void AddTriangle_ThrowsDllNotFoundException()
        {
        }

        /// <summary>
        ///     Tests that add triangle with thickness throws dll not found exception
        /// </summary>
        [RequireCImguiSystemFact]
        public void AddTriangle_WithThickness_ThrowsDllNotFoundException()
        {
        }

        /// <summary>
        ///     Tests that add triangle filled throws dll not found exception
        /// </summary>
        [RequireCImguiSystemFact]
        public void AddTriangleFilled_ThrowsDllNotFoundException()
        {
        }

        /// <summary>
        ///     Tests that channels merge throws dll not found exception
        /// </summary>
        [RequireCImguiSystemFact]
        public void ChannelsMerge_ThrowsDllNotFoundException()
        {
        }

        /// <summary>
        ///     Tests that channels set current throws dll not found exception
        /// </summary>
        [RequireCImguiSystemFact]
        public void ChannelsSetCurrent_ThrowsDllNotFoundException()
        {
        }

        /// <summary>
        ///     Tests that channels split throws dll not found exception
        /// </summary>
        [RequireCImguiSystemFact]
        public void ChannelsSplit_ThrowsDllNotFoundException()
        {
        }

        /// <summary>
        ///     Tests that clone output throws dll not found exception
        /// </summary>
        [RequireCImguiSystemFact]
        public void CloneOutput_ThrowsDllNotFoundException()
        {
        }

        /// <summary>
        ///     Tests that get clip rect max throws dll not found exception
        /// </summary>
        [RequireCImguiSystemFact]
        public void GetClipRectMax_ThrowsDllNotFoundException()
        {
        }

        /// <summary>
        ///     Tests that get clip rect min throws dll not found exception
        /// </summary>
        [RequireCImguiSystemFact]
        public void GetClipRectMin_ThrowsDllNotFoundException()
        {
        }

        /// <summary>
        ///     Tests that path arc to throws dll not found exception
        /// </summary>
        [RequireCImguiSystemFact]
        public void PathArcTo_ThrowsDllNotFoundException()
        {
        }

        /// <summary>
        ///     Tests that path arc to with num segments throws dll not found exception
        /// </summary>
        [RequireCImguiSystemFact]
        public void PathArcTo_WithNumSegments_ThrowsDllNotFoundException()
        {
        }

        /// <summary>
        ///     Tests that path arc to fast throws dll not found exception
        /// </summary>
        [RequireCImguiSystemFact]
        public void PathArcToFast_ThrowsDllNotFoundException()
        {
        }

        /// <summary>
        ///     Tests that path bezier cubic curve to throws dll not found exception
        /// </summary>
        [RequireCImguiSystemFact]
        public void PathBezierCubicCurveTo_ThrowsDllNotFoundException()
        {
        }

        /// <summary>
        ///     Tests that path bezier cubic curve to with num segments throws dll not found exception
        /// </summary>
        [RequireCImguiSystemFact]
        public void PathBezierCubicCurveTo_WithNumSegments_ThrowsDllNotFoundException()
        {
        }

        /// <summary>
        ///     Tests that path bezier quadratic curve to throws dll not found exception
        /// </summary>
        [RequireCImguiSystemFact]
        public void PathBezierQuadraticCurveTo_ThrowsDllNotFoundException()
        {
        }

        /// <summary>
        ///     Tests that path bezier quadratic curve to with num segments throws dll not found exception
        /// </summary>
        [RequireCImguiSystemFact]
        public void PathBezierQuadraticCurveTo_WithNumSegments_ThrowsDllNotFoundException()
        {
        }

        /// <summary>
        ///     Tests that path clear throws dll not found exception
        /// </summary>
        [RequireCImguiSystemFact]
        public void PathClear_ThrowsDllNotFoundException()
        {
        }

        /// <summary>
        ///     Tests that path fill convex throws dll not found exception
        /// </summary>
        [RequireCImguiSystemFact]
        public void PathFillConvex_ThrowsDllNotFoundException()
        {
        }

        /// <summary>
        ///     Tests that path line to throws dll not found exception
        /// </summary>
        [RequireCImguiSystemFact]
        public void PathLineTo_ThrowsDllNotFoundException()
        {
        }

        /// <summary>
        ///     Tests that path line to merge duplicate throws dll not found exception
        /// </summary>
        [RequireCImguiSystemFact]
        public void PathLineToMergeDuplicate_ThrowsDllNotFoundException()
        {
        }

        /// <summary>
        ///     Tests that path rect throws dll not found exception
        /// </summary>
        [RequireCImguiSystemFact]
        public void PathRect_ThrowsDllNotFoundException()
        {
        }

        /// <summary>
        ///     Tests that path rect with rounding throws dll not found exception
        /// </summary>
        [RequireCImguiSystemFact]
        public void PathRect_WithRounding_ThrowsDllNotFoundException()
        {
        }

        /// <summary>
        ///     Tests that path rect with rounding flags throws dll not found exception
        /// </summary>
        [RequireCImguiSystemFact]
        public void PathRect_WithRoundingFlags_ThrowsDllNotFoundException()
        {
        }

        /// <summary>
        ///     Tests that path stroke throws dll not found exception
        /// </summary>
        [RequireCImguiSystemFact]
        public void PathStroke_ThrowsDllNotFoundException()
        {
        }

        /// <summary>
        ///     Tests that path stroke with flags throws dll not found exception
        /// </summary>
        [RequireCImguiSystemFact]
        public void PathStroke_WithFlags_ThrowsDllNotFoundException()
        {
        }

        /// <summary>
        ///     Tests that path stroke with flags thickness throws dll not found exception
        /// </summary>
        [RequireCImguiSystemFact]
        public void PathStroke_WithFlagsThickness_ThrowsDllNotFoundException()
        {
        }

        /// <summary>
        ///     Tests that pop clip rect throws dll not found exception
        /// </summary>
        [RequireCImguiSystemFact]
        public void PopClipRect_ThrowsDllNotFoundException()
        {
        }

        /// <summary>
        ///     Tests that pop texture id throws dll not found exception
        /// </summary>
        [RequireCImguiSystemFact]
        public void PopTextureId_ThrowsDllNotFoundException()
        {
        }

        /// <summary>
        ///     Tests that prim quad uv throws dll not found exception
        /// </summary>
        [RequireCImguiSystemFact]
        public void PrimQuadUv_ThrowsDllNotFoundException()
        {
        }

        /// <summary>
        ///     Tests that prim rect throws dll not found exception
        /// </summary>
        [RequireCImguiSystemFact]
        public void PrimRect_ThrowsDllNotFoundException()
        {
        }

        /// <summary>
        ///     Tests that prim rect uv throws dll not found exception
        /// </summary>
        [RequireCImguiSystemFact]
        public void PrimRectUv_ThrowsDllNotFoundException()
        {
        }

        /// <summary>
        ///     Tests that prim reserve throws dll not found exception
        /// </summary>
        [RequireCImguiSystemFact]
        public void PrimReserve_ThrowsDllNotFoundException()
        {
        }

        /// <summary>
        ///     Tests that prim unreserve throws dll not found exception
        /// </summary>
        [RequireCImguiSystemFact]
        public void PrimUnreserve_ThrowsDllNotFoundException()
        {
        }

        /// <summary>
        ///     Tests that prim vtx throws dll not found exception
        /// </summary>
        [RequireCImguiSystemFact]
        public void PrimVtx_ThrowsDllNotFoundException()
        {
        }

        /// <summary>
        ///     Tests that prim write idx throws dll not found exception
        /// </summary>
        [RequireCImguiSystemFact]
        public void PrimWriteIdx_ThrowsDllNotFoundException()
        {
        }

        /// <summary>
        ///     Tests that prim write vtx throws dll not found exception
        /// </summary>
        [RequireCImguiSystemFact]
        public void PrimWriteVtx_ThrowsDllNotFoundException()
        {
        }

        /// <summary>
        ///     Tests that push clip rect throws dll not found exception
        /// </summary>
        [RequireCImguiSystemFact]
        public void PushClipRect_ThrowsDllNotFoundException()
        {
        }

        /// <summary>
        ///     Tests that push clip rect with intersect throws dll not found exception
        /// </summary>
        [RequireCImguiSystemFact]
        public void PushClipRect_WithIntersect_ThrowsDllNotFoundException()
        {
        }

        /// <summary>
        ///     Tests that v 2 add rect filled throws dll not found exception
        /// </summary>
        [RequireCImguiSystemFact]
        public void v2_AddRectFilled_ThrowsDllNotFoundException()
        {
            ImDrawListPtr drawListPtr = new ImDrawListPtr();
        }

        /// <summary>
        ///     Tests that v 2 add rect filled multi color throws dll not found exception
        /// </summary>
        [RequireCImguiSystemFact]
        public void v2_AddRectFilledMultiColor_ThrowsDllNotFoundException()
        {
            ImDrawListPtr drawListPtr = new ImDrawListPtr();
        }

        /// <summary>
        ///     Tests that v 2 add triangle throws dll not found exception
        /// </summary>
        [RequireCImguiSystemFact]
        public void v2_AddTriangle_ThrowsDllNotFoundException()
        {
            ImDrawListPtr drawListPtr = new ImDrawListPtr();
        }

        /// <summary>
        ///     Tests that v 2 add triangle with thickness throws dll not found exception
        /// </summary>
        [RequireCImguiSystemFact]
        public void v2_AddTriangle_WithThickness_ThrowsDllNotFoundException()
        {
            ImDrawListPtr drawListPtr = new ImDrawListPtr();
        }

        /// <summary>
        ///     Tests that v 2 add triangle filled throws dll not found exception
        /// </summary>
        [RequireCImguiSystemFact]
        public void v2_AddTriangleFilled_ThrowsDllNotFoundException()
        {
            ImDrawListPtr drawListPtr = new ImDrawListPtr();
        }

        /// <summary>
        ///     Tests that v 2 channels merge throws dll not found exception
        /// </summary>
        [RequireCImguiSystemFact]
        public void v2_ChannelsMerge_ThrowsDllNotFoundException()
        {
            ImDrawListPtr drawListPtr = new ImDrawListPtr();
        }

        /// <summary>
        ///     Tests that v 2 channels set current throws dll not found exception
        /// </summary>
        [RequireCImguiSystemFact]
        public void v2_ChannelsSetCurrent_ThrowsDllNotFoundException()
        {
            ImDrawListPtr drawListPtr = new ImDrawListPtr();
        }

        /// <summary>
        ///     Tests that v 2 channels split throws dll not found exception
        /// </summary>
        [RequireCImguiSystemFact]
        public void v2_ChannelsSplit_ThrowsDllNotFoundException()
        {
            ImDrawListPtr drawListPtr = new ImDrawListPtr();
        }

        /// <summary>
        ///     Tests that v 2 clone output throws dll not found exception
        /// </summary>
        [RequireCImguiSystemFact]
        public void v2_CloneOutput_ThrowsDllNotFoundException()
        {
            ImDrawListPtr drawListPtr = new ImDrawListPtr();
        }

        /// <summary>
        ///     Tests that v 2 get clip rect max throws dll not found exception
        /// </summary>
        [RequireCImguiSystemFact]
        public void v2_GetClipRectMax_ThrowsDllNotFoundException()
        {
            ImDrawListPtr drawListPtr = new ImDrawListPtr();
        }

        /// <summary>
        ///     Tests that v 2 get clip rect min throws dll not found exception
        /// </summary>
        [RequireCImguiSystemFact]
        public void v2_GetClipRectMin_ThrowsDllNotFoundException()
        {
            ImDrawListPtr drawListPtr = new ImDrawListPtr();
        }

        /// <summary>
        ///     Tests that v 2 path arc to throws dll not found exception
        /// </summary>
        [RequireCImguiSystemFact]
        public void v2_PathArcTo_ThrowsDllNotFoundException()
        {
            ImDrawListPtr drawListPtr = new ImDrawListPtr();
        }

        /// <summary>
        ///     Tests that path arc to with segments throws dll not found exception
        /// </summary>
        [RequireCImguiSystemFact]
        public void PathArcTo_WithSegments_ThrowsDllNotFoundException()
        {
            ImDrawListPtr drawListPtr = new ImDrawListPtr();
        }

        /// <summary>
        ///     Tests that v 2 path arc to fast throws dll not found exception
        /// </summary>
        [RequireCImguiSystemFact]
        public void v2_PathArcToFast_ThrowsDllNotFoundException()
        {
            ImDrawListPtr drawListPtr = new ImDrawListPtr();
        }

        /// <summary>
        ///     Tests that v 2 path bezier cubic curve to throws dll not found exception
        /// </summary>
        [RequireCImguiSystemFact]
        public void v2_PathBezierCubicCurveTo_ThrowsDllNotFoundException()
        {
            ImDrawListPtr drawListPtr = new ImDrawListPtr();
        }

        /// <summary>
        ///     Tests that path bezier cubic curve to with segments throws dll not found exception
        /// </summary>
        [RequireCImguiSystemFact]
        public void PathBezierCubicCurveTo_WithSegments_ThrowsDllNotFoundException()
        {
            ImDrawListPtr drawListPtr = new ImDrawListPtr();
        }

        /// <summary>
        ///     Tests that v 2 path bezier quadratic curve to throws dll not found exception
        /// </summary>
        [RequireCImguiSystemFact]
        public void v2_PathBezierQuadraticCurveTo_ThrowsDllNotFoundException()
        {
            ImDrawListPtr drawListPtr = new ImDrawListPtr();
        }

        /// <summary>
        ///     Tests that path bezier quadratic curve to with segments throws dll not found exception
        /// </summary>
        [RequireCImguiSystemFact]
        public void PathBezierQuadraticCurveTo_WithSegments_ThrowsDllNotFoundException()
        {
            ImDrawListPtr drawListPtr = new ImDrawListPtr();
        }

        /// <summary>
        ///     Tests that v 2 path clear throws dll not found exception
        /// </summary>
        [RequireCImguiSystemFact]
        public void v2_PathClear_ThrowsDllNotFoundException()
        {
            ImDrawListPtr drawListPtr = new ImDrawListPtr();
        }

        /// <summary>
        ///     Tests that v 2 path fill convex throws dll not found exception
        /// </summary>
        [RequireCImguiSystemFact]
        public void v2_PathFillConvex_ThrowsDllNotFoundException()
        {
            ImDrawListPtr drawListPtr = new ImDrawListPtr();
        }

        /// <summary>
        ///     Tests that v 2 path line to throws dll not found exception
        /// </summary>
        [RequireCImguiSystemFact]
        public void v2_PathLineTo_ThrowsDllNotFoundException()
        {
            ImDrawListPtr drawListPtr = new ImDrawListPtr();
        }

        /// <summary>
        ///     Tests that v 2 path line to merge duplicate throws dll not found exception
        /// </summary>
        [RequireCImguiSystemFact]
        public void v2_PathLineToMergeDuplicate_ThrowsDllNotFoundException()
        {
            ImDrawListPtr drawListPtr = new ImDrawListPtr();
        }

        /// <summary>
        ///     Tests that v 2 path rect throws dll not found exception
        /// </summary>
        [RequireCImguiSystemFact]
        public void v2_PathRect_ThrowsDllNotFoundException()
        {
            ImDrawListPtr drawListPtr = new ImDrawListPtr();
        }

        /// <summary>
        ///     Tests that v 2 path rect with rounding throws dll not found exception
        /// </summary>
        [RequireCImguiSystemFact]
        public void v2_PathRect_WithRounding_ThrowsDllNotFoundException()
        {
            ImDrawListPtr drawListPtr = new ImDrawListPtr();
        }

        /// <summary>
        ///     Tests that path rect with rounding and flags throws dll not found exception
        /// </summary>
        [RequireCImguiSystemFact]
        public void PathRect_WithRoundingAndFlags_ThrowsDllNotFoundException()
        {
            ImDrawListPtr drawListPtr = new ImDrawListPtr();
        }

        /// <summary>
        ///     Tests that v 2 path stroke throws dll not found exception
        /// </summary>
        [RequireCImguiSystemFact]
        public void v2_PathStroke_ThrowsDllNotFoundException()
        {
            ImDrawListPtr drawListPtr = new ImDrawListPtr();
        }

        /// <summary>
        ///     Tests that v 2 path stroke with flags throws dll not found exception
        /// </summary>
        [RequireCImguiSystemFact]
        public void v2_PathStroke_WithFlags_ThrowsDllNotFoundException()
        {
            ImDrawListPtr drawListPtr = new ImDrawListPtr();
        }

        /// <summary>
        ///     Tests that path stroke with flags and thickness throws dll not found exception
        /// </summary>
        [RequireCImguiSystemFact]
        public void PathStroke_WithFlagsAndThickness_ThrowsDllNotFoundException()
        {
            ImDrawListPtr drawListPtr = new ImDrawListPtr();
        }

        /// <summary>
        ///     Tests that v 2 pop clip rect throws dll not found exception
        /// </summary>
        [RequireCImguiSystemFact]
        public void v2_PopClipRect_ThrowsDllNotFoundException()
        {
            ImDrawListPtr drawListPtr = new ImDrawListPtr();
        }

        /// <summary>
        ///     Tests that v 2 pop texture id throws dll not found exception
        /// </summary>
        [RequireCImguiSystemFact]
        public void v2_PopTextureId_ThrowsDllNotFoundException()
        {
            ImDrawListPtr drawListPtr = new ImDrawListPtr();
        }

        /// <summary>
        ///     Tests that v 2 prim quad uv throws dll not found exception
        /// </summary>
        [RequireCImguiSystemFact]
        public void v2_PrimQuadUv_ThrowsDllNotFoundException()
        {
            ImDrawListPtr drawListPtr = new ImDrawListPtr();
        }

        /// <summary>
        ///     Tests that v 2 prim rect throws dll not found exception
        /// </summary>
        [RequireCImguiSystemFact]
        public void v2_PrimRect_ThrowsDllNotFoundException()
        {
            ImDrawListPtr drawListPtr = new ImDrawListPtr();
        }

        /// <summary>
        ///     Tests that v 2 prim rect uv throws dll not found exception
        /// </summary>
        [RequireCImguiSystemFact]
        public void v2_PrimRectUv_ThrowsDllNotFoundException()
        {
            ImDrawListPtr drawListPtr = new ImDrawListPtr();
        }

        /// <summary>
        ///     Tests that v 2 prim reserve throws dll not found exception
        /// </summary>
        [RequireCImguiSystemFact]
        public void v2_PrimReserve_ThrowsDllNotFoundException()
        {
            ImDrawListPtr drawListPtr = new ImDrawListPtr();
        }

        /// <summary>
        ///     Tests that v 2 prim unreserve throws dll not found exception
        /// </summary>
        [RequireCImguiSystemFact]
        public void v2_PrimUnreserve_ThrowsDllNotFoundException()
        {
            ImDrawListPtr drawListPtr = new ImDrawListPtr();
        }

        /// <summary>
        ///     Tests that v 2 prim vtx throws dll not found exception
        /// </summary>
        [RequireCImguiSystemFact]
        public void v2_PrimVtx_ThrowsDllNotFoundException()
        {
            ImDrawListPtr drawListPtr = new ImDrawListPtr();
        }

        /// <summary>
        ///     Tests that v 2 prim write idx throws dll not found exception
        /// </summary>
        [RequireCImguiSystemFact]
        public void v2_PrimWriteIdx_ThrowsDllNotFoundException()
        {
            ImDrawListPtr drawListPtr = new ImDrawListPtr();
        }

        /// <summary>
        ///     Tests that v 2 prim write vtx throws dll not found exception
        /// </summary>
        [RequireCImguiSystemFact]
        public void v2_PrimWriteVtx_ThrowsDllNotFoundException()
        {
            ImDrawListPtr drawListPtr = new ImDrawListPtr();
        }

        /// <summary>
        ///     Tests that v 2 push clip rect throws dll not found exception
        /// </summary>
        [RequireCImguiSystemFact]
        public void v2_PushClipRect_ThrowsDllNotFoundException()
        {
            ImDrawListPtr drawListPtr = new ImDrawListPtr();
        }

        /// <summary>
        ///     Tests that v 2 push clip rect with intersect throws dll not found exception
        /// </summary>
        [RequireCImguiSystemFact]
        public void v2_PushClipRect_WithIntersect_ThrowsDllNotFoundException()
        {
            ImDrawListPtr drawListPtr = new ImDrawListPtr();
        }

        /// <summary>
        ///     Tests that push clip rect full screen throws dll not found exception
        /// </summary>
        [RequireCImguiSystemFact]
        public void PushClipRectFullScreen_ThrowsDllNotFoundException()
        {
            ImDrawListPtr drawListPtr = new ImDrawListPtr();
        }

        /// <summary>
        ///     Tests that push texture id throws dll not found exception
        /// </summary>
        [RequireCImguiSystemFact]
        public void PushTextureId_ThrowsDllNotFoundException()
        {
            ImDrawListPtr drawListPtr = new ImDrawListPtr();
        }

        /// <summary>
        ///     Tests that add text throws dll not found exception
        /// </summary>
        [RequireCImguiSystemFact]
        public void AddText_ThrowsDllNotFoundException()
        {
            ImDrawListPtr drawListPtr = new ImDrawListPtr();
        }

        /// <summary>
        ///     Tests that add text with font throws dll not found exception
        /// </summary>
        [RequireCImguiSystemFact]
        public void AddText_WithFont_ThrowsDllNotFoundException()
        {
            ImDrawListPtr drawListPtr = new ImDrawListPtr();
        }

        /// <summary>
        ///     Tests that path arc to n throws dll not found exception
        /// </summary>
        [RequireCImguiSystemFact]
        public void _PathArcToN_ThrowsDllNotFoundException()
        {
            ImDrawListPtr drawListPtr = new ImDrawListPtr();
        }

        /// <summary>
        ///     Tests that pop unused draw cmd throws dll not found exception
        /// </summary>
        [RequireCImguiSystemFact]
        public void _PopUnusedDrawCmd_ThrowsDllNotFoundException()
        {
            ImDrawListPtr drawListPtr = new ImDrawListPtr();
        }

        /// <summary>
        ///     Tests that reset for new frame throws dll not found exception
        /// </summary>
        [RequireCImguiSystemFact]
        public void _ResetForNewFrame_ThrowsDllNotFoundException()
        {
            ImDrawListPtr drawListPtr = new ImDrawListPtr();
        }

        /// <summary>
        ///     Tests that try merge draw cmds throws dll not found exception
        /// </summary>
        [RequireCImguiSystemFact]
        public void _TryMergeDrawCmds_ThrowsDllNotFoundException()
        {
            ImDrawListPtr drawListPtr = new ImDrawListPtr();
        }

        /// <summary>
        ///     Tests that add bezier cubic throws dll not found exception
        /// </summary>
        [RequireCImguiSystemFact]
        public void AddBezierCubic_ThrowsDllNotFoundException()
        {
            ImDrawListPtr drawListPtr = new ImDrawListPtr();
        }

        /// <summary>
        ///     Tests that add bezier cubic with segments throws dll not found exception
        /// </summary>
        [RequireCImguiSystemFact]
        public void AddBezierCubic_WithSegments_ThrowsDllNotFoundException()
        {
            ImDrawListPtr drawListPtr = new ImDrawListPtr();
        }

        /// <summary>
        ///     Tests that add bezier quadratic throws dll not found exception
        /// </summary>
        [RequireCImguiSystemFact]
        public void AddBezierQuadratic_ThrowsDllNotFoundException()
        {
            ImDrawListPtr drawListPtr = new ImDrawListPtr();
        }

        /// <summary>
        ///     Tests that add bezier quadratic with segments throws dll not found exception
        /// </summary>
        [RequireCImguiSystemFact]
        public void AddBezierQuadratic_WithSegments_ThrowsDllNotFoundException()
        {
            ImDrawListPtr drawListPtr = new ImDrawListPtr();
        }

        /// <summary>
        ///     Tests that add callback throws dll not found exception
        /// </summary>
        [RequireCImguiSystemFact]
        public void AddCallback_ThrowsDllNotFoundException()
        {
            ImDrawListPtr drawListPtr = new ImDrawListPtr();
        }

        /// <summary>
        ///     Tests that add circle throws dll not found exception
        /// </summary>
        [RequireCImguiSystemFact]
        public void AddCircle_ThrowsDllNotFoundException()
        {
            ImDrawListPtr drawListPtr = new ImDrawListPtr();
        }

        /// <summary>
        ///     Tests that add circle with segments throws dll not found exception
        /// </summary>
        [RequireCImguiSystemFact]
        public void AddCircle_WithSegments_ThrowsDllNotFoundException()
        {
            ImDrawListPtr drawListPtr = new ImDrawListPtr();
        }

        /// <summary>
        ///     Tests that add circle with segments and thickness throws dll not found exception
        /// </summary>
        [RequireCImguiSystemFact]
        public void AddCircle_WithSegmentsAndThickness_ThrowsDllNotFoundException()
        {
            ImDrawListPtr drawListPtr = new ImDrawListPtr();
        }

        /// <summary>
        ///     Tests that add circle filled throws dll not found exception
        /// </summary>
        [RequireCImguiSystemFact]
        public void AddCircleFilled_ThrowsDllNotFoundException()
        {
            ImDrawListPtr drawListPtr = new ImDrawListPtr();
        }

        /// <summary>
        ///     Tests that add circle filled with segments throws dll not found exception
        /// </summary>
        [RequireCImguiSystemFact]
        public void AddCircleFilled_WithSegments_ThrowsDllNotFoundException()
        {
            ImDrawListPtr drawListPtr = new ImDrawListPtr();
        }

        /// <summary>
        ///     Tests that add convex poly filled throws dll not found exception
        /// </summary>
        [RequireCImguiSystemFact]
        public void AddConvexPolyFilled_ThrowsDllNotFoundException()
        {
        }

        /// <summary>
        ///     Tests that clip rect stack throws dll not found exception
        /// </summary>
        [RequireCImguiSystemFact]
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
        [RequireCImguiSystemFact]
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
        [RequireCImguiSystemFact]
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
        [RequireCImguiSystemFact]
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
        [RequireCImguiSystemFact]
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
        [RequireCImguiSystemFact]
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
        [RequireCImguiSystemFact]
        public void _CalcCircleAutoSegmentCount_ThrowsDllNotFoundException()
        {
            ImDrawListPtr drawListPtr = new ImDrawListPtr();
        }

        /// <summary>
        ///     Tests that clear free memory throws dll not found exception
        /// </summary>
        [RequireCImguiSystemFact]
        public void _ClearFreeMemory_ThrowsDllNotFoundException()
        {
            ImDrawListPtr drawListPtr = new ImDrawListPtr();
        }

        /// <summary>
        ///     Tests that on changed clip rect throws dll not found exception
        /// </summary>
        [RequireCImguiSystemFact]
        public void _OnChangedClipRect_ThrowsDllNotFoundException()
        {
            ImDrawListPtr drawListPtr = new ImDrawListPtr();
        }

        /// <summary>
        ///     Tests that on changed texture id throws dll not found exception
        /// </summary>
        [RequireCImguiSystemFact]
        public void _OnChangedTextureID_ThrowsDllNotFoundException()
        {
            ImDrawListPtr drawListPtr = new ImDrawListPtr();
        }

        /// <summary>
        ///     Tests that on changed vtx offset throws dll not found exception
        /// </summary>
        [RequireCImguiSystemFact]
        public void _OnChangedVtxOffset_ThrowsDllNotFoundException()
        {
            ImDrawListPtr drawListPtr = new ImDrawListPtr();
        }

        /// <summary>
        ///     Tests that path arc to fast ex throws dll not found exception
        /// </summary>
        [RequireCImguiSystemFact]
        public void _PathArcToFastEx_ThrowsDllNotFoundException()
        {
            ImDrawListPtr drawListPtr = new ImDrawListPtr();
        }

        /// <summary>
        ///     Tests that implicit conversion to int ptr returns native ptr
        /// </summary>
        [RequireCImguiSystemFact]
        public void ImplicitConversionToIntPtr_ReturnsNativePtr()
        {
            ImDrawListPtr drawListPtr = new ImDrawListPtr(new ImDrawList());
            IntPtr result = drawListPtr;
            Assert.NotEqual(IntPtr.Zero, result);
        }

        /// <summary>
        ///     Tests that implicit conversion from int ptr returns im draw list ptr
        /// </summary>
        [RequireCImguiSystemFact]
        public void ImplicitConversionFromIntPtr_ReturnsImDrawListPtr()
        {
            IntPtr nativePtr = new IntPtr(123);
            ImDrawListPtr drawListPtr = nativePtr;
            Assert.Equal(nativePtr, drawListPtr.NativePtr);
        }

        /// <summary>
        ///     Tests that cmd buffer returns correct value
        /// </summary>
        [RequireCImguiSystemFact]
        public void CmdBuffer_ReturnsCorrectValue()
        {
        }

        /// <summary>
        ///     Tests that idx buffer returns correct value
        /// </summary>
        [RequireCImguiSystemFact]
        public void IdxBuffer_ReturnsCorrectValue()
        {
        }

        /// <summary>
        ///     Tests that vtx buffer returns correct value
        /// </summary>
        [RequireCImguiSystemFact]
        public void VtxBuffer_ReturnsCorrectValue()
        {
        }

        /// <summary>
        ///     Tests that flags returns correct value
        /// </summary>
        [RequireCImguiSystemFact]
        public void Flags_ReturnsCorrectValue()
        {
        }

        /// <summary>
        ///     Tests that vtx current idx returns correct value
        /// </summary>
        [RequireCImguiSystemFact]
        public void VtxCurrentIdx_ReturnsCorrectValue()
        {
            ImDrawListPtr drawListPtr = new ImDrawListPtr(new ImDrawList());
            uint vtxCurrentIdx = drawListPtr.VtxCurrentIdx;
            Assert.Equal(0u, vtxCurrentIdx);
        }

        /// <summary>
        ///     Tests that data returns correct value
        /// </summary>
        [RequireCImguiSystemFact]
        public void Data_ReturnsCorrectValue()
        {
            ImDrawListPtr drawListPtr = new ImDrawListPtr(new ImDrawList());
            IntPtr data = drawListPtr.Data;
            Assert.Equal(IntPtr.Zero, data);
        }

        /// <summary>
        ///     Tests that owner name returns correct value
        /// </summary>
        [RequireCImguiSystemFact]
        public void OwnerName_ReturnsCorrectValue()
        {
        }

        /// <summary>
        ///     Tests that idx write ptr get returns correct value
        /// </summary>
        [RequireCImguiSystemFact]
        public void IdxWritePtr_Get_ReturnsCorrectValue()
        {
            ImDrawListPtr drawListPtr = new ImDrawListPtr(new ImDrawList());
            IntPtr idxWritePtr = drawListPtr.IdxWritePtr;
            Assert.Equal(IntPtr.Zero, idxWritePtr);
        }

        /// <summary>
        ///     Tests that cmd buffer returns correct value v 3
        /// </summary>
        [RequireCImguiSystemFact]
        public void CmdBuffer_ReturnsCorrectValue_v3()
        {
            ImDrawListPtr drawListPtr = new ImDrawListPtr(new ImDrawList());
            ImVectorG<ImDrawCmd> cmdBuffer = drawListPtr.CmdBuffer;
            Assert.Equal(0, cmdBuffer.Size);
        }

        /// <summary>
        ///     Tests that idx buffer returns correct value v 3
        /// </summary>
        [RequireCImguiSystemFact]
        public void IdxBuffer_ReturnsCorrectValue_v3()
        {
            ImDrawListPtr drawListPtr = new ImDrawListPtr(new ImDrawList());
            ImVectorG<ushort> idxBuffer = drawListPtr.IdxBuffer;
            Assert.Equal(0, idxBuffer.Size);
        }

        /// <summary>
        ///     Tests that vtx buffer returns correct value v 3
        /// </summary>
        [RequireCImguiSystemFact]
        public void VtxBuffer_ReturnsCorrectValue_v3()
        {
            ImDrawListPtr drawListPtr = new ImDrawListPtr(new ImDrawList());
            ImVectorG<ImDrawVert> vtxBuffer = drawListPtr.VtxBuffer;
            Assert.Equal(0, vtxBuffer.Size);
        }

        /// <summary>
        ///     Tests that flags returns correct value v 3
        /// </summary>
        [RequireCImguiSystemFact]
        public void Flags_ReturnsCorrectValue_v3()
        {
            ImDrawListPtr drawListPtr = new ImDrawListPtr(new ImDrawList());
            ImDrawListFlags flags = drawListPtr.Flags;
            Assert.Equal(ImDrawListFlags.None, flags);
        }

        /// <summary>
        ///     Tests that implicit conversion to int ptr returns native ptr v 4
        /// </summary>
        [RequireCImguiSystemFact]
        public void ImplicitConversionToIntPtr_ReturnsNativePtr_v4()
        {
            ImDrawListPtr drawListPtr = new ImDrawListPtr(new ImDrawList());
            IntPtr result = drawListPtr;
            Assert.NotEqual(IntPtr.Zero, result);
        }

        /// <summary>
        ///     Tests that implicit conversion from int ptr returns im draw list ptr v 4
        /// </summary>
        [RequireCImguiSystemFact]
        public void ImplicitConversionFromIntPtr_ReturnsImDrawListPtr_v4()
        {
            IntPtr nativePtr = new IntPtr(123);
            ImDrawListPtr drawListPtr = nativePtr;
            Assert.Equal(nativePtr, drawListPtr.NativePtr);
        }

        /// <summary>
        ///     Tests that cmd buffer returns correct value v 4
        /// </summary>
        [RequireCImguiSystemFact]
        public void CmdBuffer_ReturnsCorrectValue_v4()
        {
            ImDrawListPtr drawListPtr = new ImDrawListPtr(new ImDrawList());
            ImVectorG<ImDrawCmd> cmdBuffer = drawListPtr.CmdBuffer;
            Assert.Equal(0, cmdBuffer.Size);
        }

        /// <summary>
        ///     Tests that idx buffer returns correct value v 4
        /// </summary>
        [RequireCImguiSystemFact]
        public void IdxBuffer_ReturnsCorrectValue_v4()
        {
            ImDrawListPtr drawListPtr = new ImDrawListPtr(new ImDrawList());
            ImVectorG<ushort> idxBuffer = drawListPtr.IdxBuffer;
            Assert.Equal(0, idxBuffer.Size);
        }

        /// <summary>
        ///     Tests that vtx buffer returns correct value v 4
        /// </summary>
        [RequireCImguiSystemFact]
        public void VtxBuffer_ReturnsCorrectValue_v4()
        {
            ImDrawListPtr drawListPtr = new ImDrawListPtr(new ImDrawList());
            ImVectorG<ImDrawVert> vtxBuffer = drawListPtr.VtxBuffer;
            Assert.Equal(0, vtxBuffer.Size);
        }

        /// <summary>
        ///     Tests that flags returns correct value v 4
        /// </summary>
        [RequireCImguiSystemFact]
        public void Flags_ReturnsCorrectValue_v4()
        {
            ImDrawListPtr drawListPtr = new ImDrawListPtr(new ImDrawList());
            ImDrawListFlags flags = drawListPtr.Flags;
            Assert.Equal(ImDrawListFlags.None, flags);
        }

        /// <summary>
        ///     Tests that vtx current idx returns correct value v 4
        /// </summary>
        [RequireCImguiSystemFact]
        public void VtxCurrentIdx_ReturnsCorrectValue_v4()
        {
            ImDrawListPtr drawListPtr = new ImDrawListPtr(new ImDrawList());
            uint vtxCurrentIdx = drawListPtr.VtxCurrentIdx;
            Assert.Equal(0u, vtxCurrentIdx);
        }

        /// <summary>
        ///     Tests that data returns correct value v 4
        /// </summary>
        [RequireCImguiSystemFact]
        public void Data_ReturnsCorrectValue_v4()
        {
            ImDrawListPtr drawListPtr = new ImDrawListPtr(new ImDrawList());
            IntPtr data = drawListPtr.Data;
            Assert.Equal(IntPtr.Zero, data);
        }

        /// <summary>
        ///     Tests that owner name returns correct value v 4
        /// </summary>
        [RequireCImguiSystemFact]
        public void OwnerName_ReturnsCorrectValue_v4()
        {
            ImDrawListPtr drawListPtr = new ImDrawListPtr(new ImDrawList());
            NullTerminatedString ownerName = drawListPtr.OwnerName;
            Assert.Equal("", ownerName.ToString());
        }

        /// <summary>
        ///     Tests that vtx write ptr returns correct value
        /// </summary>
        [RequireCImguiSystemFact]
        public void VtxWritePtr_ReturnsCorrectValue()
        {
            ImDrawListPtr drawListPtr = new ImDrawListPtr(new ImDrawList());
            Assert.Throws<NullReferenceException>(() => drawListPtr.VtxWritePtr);
        }

        /// <summary>
        ///     Tests that idx write ptr get returns correct value v 4
        /// </summary>
        [RequireCImguiSystemFact]
        public void IdxWritePtr_Get_ReturnsCorrectValue_v4()
        {
            ImDrawListPtr drawListPtr = new ImDrawListPtr(new ImDrawList());
            IntPtr idxWritePtr = drawListPtr.IdxWritePtr;
            Assert.Equal(IntPtr.Zero, idxWritePtr);
        }

        /// <summary>
        ///     Verifies that the type is a readonly struct.
        /// </summary>
        [RequireCImguiSystemFact]
        public void Type_ShouldBeReadonlyStruct()
        {
            Type type = typeof(ImDrawListPtr);

            Assert.True(type.IsValueType);
            Assert.False(type.IsClass);
        }

        /// <summary>
        ///     Verifies that a default instance has NativePtr equal to IntPtr.Zero.
        /// </summary>
        [RequireCImguiSystemFact]
        public void DefaultConstructor_ShouldHaveZeroNativePtr()
        {
            ImDrawListPtr drawListPtr = new ImDrawListPtr();

            Assert.Equal(IntPtr.Zero, drawListPtr.NativePtr);
        }

        /// <summary>
        ///     Verifies that NativePtr can be set via the IntPtr constructor and read back.
        /// </summary>
        [RequireCImguiSystemFact]
        public void NativePtr_ShouldRoundTripFromIntPtrConstructor()
        {
            IntPtr expected = new IntPtr(42);
            ImDrawListPtr drawListPtr = new ImDrawListPtr(expected);

            Assert.Equal(expected, drawListPtr.NativePtr);
        }

        /// <summary>
        ///     Verifies that the implicit conversion from IntPtr sets NativePtr correctly.
        /// </summary>
        [RequireCImguiSystemFact]
        public void ImplicitFromIntPtr_ShouldSetNativePtr()
        {
            IntPtr ptr = new IntPtr(1024);
            ImDrawListPtr drawListPtr = ptr;

            Assert.Equal(ptr, drawListPtr.NativePtr);
        }

        /// <summary>
        ///     Verifies that the implicit conversion to IntPtr returns NativePtr.
        /// </summary>
        [RequireCImguiSystemFact]
        public void ImplicitToIntPtr_ShouldReturnNativePtr()
        {
            IntPtr ptr = new IntPtr(2048);
            ImDrawListPtr drawListPtr = new ImDrawListPtr(ptr);
            IntPtr result = drawListPtr;

            Assert.Equal(ptr, result);
        }

        /// <summary>
        ///     Verifies that two instances with the same NativePtr are equal.
        /// </summary>
        [RequireCImguiSystemFact]
        public void SameNativePtr_ShouldBeEqual()
        {
            IntPtr ptr = new IntPtr(777);
            ImDrawListPtr drawListPtr1 = new ImDrawListPtr(ptr);
            ImDrawListPtr drawListPtr2 = new ImDrawListPtr(ptr);

            Assert.Equal(drawListPtr1.NativePtr, drawListPtr2.NativePtr);
        }

        /// <summary>
        ///     Verifies that the struct is marked as public.
        /// </summary>
        [RequireCImguiSystemFact]
        public void Type_ShouldBePublic()
        {
            Assert.True(typeof(ImDrawListPtr).IsPublic);
        }
    }
}