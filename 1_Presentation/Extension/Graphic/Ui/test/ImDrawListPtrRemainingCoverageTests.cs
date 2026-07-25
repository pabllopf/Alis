// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImDrawListPtrRemainingCoverageTests.cs
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
    public class ImDrawListPtrRemainingCoverageTests
    {
        [RequireCImguiSystemFact]
        public void AddDrawCmd_ShouldCallNative()
        {
            ImDrawListPtr drawList = new ImDrawListPtr(new ImDrawList());
            drawList.AddDrawCmd();
        }

        [RequireCImguiSystemFact]
        public void AddCallback_ShouldCallNative()
        {
            ImDrawListPtr drawList = new ImDrawListPtr(new ImDrawList());
            drawList.AddCallback(IntPtr.Zero, IntPtr.Zero);
        }

        [RequireCImguiSystemFact]
        public void AddCircle_Default_ShouldCallNative()
        {
            ImDrawListPtr drawList = new ImDrawListPtr(new ImDrawList());
            drawList.AddCircle(new Vector2F(), 1.0f, 4294967295);
        }

        [RequireCImguiSystemFact]
        public void AddCircle_WithSegments_ShouldCallNative()
        {
            ImDrawListPtr drawList = new ImDrawListPtr(new ImDrawList());
            drawList.AddCircle(new Vector2F(), 1.0f, 4294967295, 12);
        }

        [RequireCImguiSystemFact]
        public void AddCircle_WithSegmentsAndThickness_ShouldCallNative()
        {
            ImDrawListPtr drawList = new ImDrawListPtr(new ImDrawList());
            drawList.AddCircle(new Vector2F(), 1.0f, 4294967295, 12, 2.0f);
        }

        [RequireCImguiSystemFact]
        public void AddCircleFilled_Default_ShouldCallNative()
        {
            ImDrawListPtr drawList = new ImDrawListPtr(new ImDrawList());
            drawList.AddCircleFilled(new Vector2F(), 1.0f, 4294967295);
        }

        [RequireCImguiSystemFact]
        public void AddCircleFilled_WithSegments_ShouldCallNative()
        {
            ImDrawListPtr drawList = new ImDrawListPtr(new ImDrawList());
            drawList.AddCircleFilled(new Vector2F(), 1.0f, 4294967295, 12);
        }

        [RequireCImguiSystemFact]
        public void AddConvexPolyFilled_ShouldCallNative()
        {
            ImDrawListPtr drawList = new ImDrawListPtr(new ImDrawList());
            Vector2F points = new Vector2F();
            drawList.AddConvexPolyFilled(ref points, 3, 4294967295);
        }

        [RequireCImguiSystemFact]
        public void AddImage_Default_ShouldCallNative()
        {
            ImDrawListPtr drawList = new ImDrawListPtr(new ImDrawList());
            drawList.AddImage(IntPtr.Zero, new Vector2F(), new Vector2F(1, 1));
        }

        [RequireCImguiSystemFact]
        public void AddImage_WithUvMin_ShouldCallNative()
        {
            ImDrawListPtr drawList = new ImDrawListPtr(new ImDrawList());
            drawList.AddImage(IntPtr.Zero, new Vector2F(), new Vector2F(1, 1), new Vector2F());
        }

        [RequireCImguiSystemFact]
        public void AddImage_WithUvMinUvMax_ShouldCallNative()
        {
            ImDrawListPtr drawList = new ImDrawListPtr(new ImDrawList());
            drawList.AddImage(IntPtr.Zero, new Vector2F(), new Vector2F(1, 1), new Vector2F(), new Vector2F(1, 1));
        }

        [RequireCImguiSystemFact]
        public void AddImage_WithUvMinUvMaxCol_ShouldCallNative()
        {
            ImDrawListPtr drawList = new ImDrawListPtr(new ImDrawList());
            drawList.AddImage(IntPtr.Zero, new Vector2F(), new Vector2F(1, 1), new Vector2F(), new Vector2F(1, 1), 4294967295);
        }

        [RequireCImguiSystemFact]
        public void AddImageQuad_Default_ShouldCallNative()
        {
            ImDrawListPtr drawList = new ImDrawListPtr(new ImDrawList());
            drawList.AddImageQuad(IntPtr.Zero, new Vector2F(), new Vector2F(1, 0), new Vector2F(1, 1), new Vector2F(0, 1));
        }

        [RequireCImguiSystemFact]
        public void AddImageQuad_WithUv1_ShouldCallNative()
        {
            ImDrawListPtr drawList = new ImDrawListPtr(new ImDrawList());
            drawList.AddImageQuad(IntPtr.Zero, new Vector2F(), new Vector2F(1, 0), new Vector2F(1, 1), new Vector2F(0, 1), new Vector2F());
        }

        [RequireCImguiSystemFact]
        public void AddImageQuad_WithUv1Uv2_ShouldCallNative()
        {
            ImDrawListPtr drawList = new ImDrawListPtr(new ImDrawList());
            drawList.AddImageQuad(IntPtr.Zero, new Vector2F(), new Vector2F(1, 0), new Vector2F(1, 1), new Vector2F(0, 1), new Vector2F(), new Vector2F(1, 0));
        }

        [RequireCImguiSystemFact]
        public void AddImageQuad_WithUv1Uv2Uv3_ShouldCallNative()
        {
            ImDrawListPtr drawList = new ImDrawListPtr(new ImDrawList());
            drawList.AddImageQuad(IntPtr.Zero, new Vector2F(), new Vector2F(1, 0), new Vector2F(1, 1), new Vector2F(0, 1), new Vector2F(), new Vector2F(1, 0), new Vector2F(1, 1));
        }

        [RequireCImguiSystemFact]
        public void AddImageQuad_WithUv1Uv2Uv3Uv4_ShouldCallNative()
        {
            ImDrawListPtr drawList = new ImDrawListPtr(new ImDrawList());
            drawList.AddImageQuad(IntPtr.Zero, new Vector2F(), new Vector2F(1, 0), new Vector2F(1, 1), new Vector2F(0, 1), new Vector2F(), new Vector2F(1, 0), new Vector2F(1, 1), new Vector2F(0, 1));
        }

        [RequireCImguiSystemFact]
        public void AddImageQuad_WithUv1Uv2Uv3Uv4Col_ShouldCallNative()
        {
            ImDrawListPtr drawList = new ImDrawListPtr(new ImDrawList());
            drawList.AddImageQuad(IntPtr.Zero, new Vector2F(), new Vector2F(1, 0), new Vector2F(1, 1), new Vector2F(0, 1), new Vector2F(), new Vector2F(1, 0), new Vector2F(1, 1), new Vector2F(0, 1), 4294967295);
        }

        [RequireCImguiSystemFact]
        public void AddImageRounded_Default_ShouldCallNative()
        {
            ImDrawListPtr drawList = new ImDrawListPtr(new ImDrawList());
            drawList.AddImageRounded(IntPtr.Zero, new Vector2F(), new Vector2F(1, 1), new Vector2F(), new Vector2F(1, 1), 4294967295, 0.5f);
        }

        [RequireCImguiSystemFact]
        public void AddImageRounded_WithFlags_ShouldCallNative()
        {
            ImDrawListPtr drawList = new ImDrawListPtr(new ImDrawList());
            drawList.AddImageRounded(IntPtr.Zero, new Vector2F(), new Vector2F(1, 1), new Vector2F(), new Vector2F(1, 1), 4294967295, 0.5f, 0);
        }

        [RequireCImguiSystemFact]
        public void AddLine_Default_ShouldCallNative()
        {
            ImDrawListPtr drawList = new ImDrawListPtr(new ImDrawList());
            drawList.AddLine(new Vector2F(), new Vector2F(1, 1), 4294967295);
        }

        [RequireCImguiSystemFact]
        public void AddLine_WithThickness_ShouldCallNative()
        {
            ImDrawListPtr drawList = new ImDrawListPtr(new ImDrawList());
            drawList.AddLine(new Vector2F(), new Vector2F(1, 1), 4294967295, 2.0f);
        }

        [RequireCImguiSystemFact]
        public void AddNgon_Default_ShouldCallNative()
        {
            ImDrawListPtr drawList = new ImDrawListPtr(new ImDrawList());
            drawList.AddNgon(new Vector2F(), 1.0f, 4294967295, 6);
        }

        [RequireCImguiSystemFact]
        public void AddNgon_WithThickness_ShouldCallNative()
        {
            ImDrawListPtr drawList = new ImDrawListPtr(new ImDrawList());
            drawList.AddNgon(new Vector2F(), 1.0f, 4294967295, 6, 2.0f);
        }

        [RequireCImguiSystemFact]
        public void AddNgonFilled_ShouldCallNative()
        {
            ImDrawListPtr drawList = new ImDrawListPtr(new ImDrawList());
            drawList.AddNgonFilled(new Vector2F(), 1.0f, 4294967295, 6);
        }

        [RequireCImguiSystemFact]
        public void AddPolyline_ShouldCallNative()
        {
            ImDrawListPtr drawList = new ImDrawListPtr(new ImDrawList());
            Vector2F points = new Vector2F();
            drawList.AddPolyline(ref points, 3, 4294967295, 0, 2.0f);
        }

        [RequireCImguiSystemFact]
        public void AddQuad_Default_ShouldCallNative()
        {
            ImDrawListPtr drawList = new ImDrawListPtr(new ImDrawList());
            drawList.AddQuad(new Vector2F(), new Vector2F(1, 0), new Vector2F(1, 1), new Vector2F(0, 1), 4294967295);
        }

        [RequireCImguiSystemFact]
        public void AddQuad_WithThickness_ShouldCallNative()
        {
            ImDrawListPtr drawList = new ImDrawListPtr(new ImDrawList());
            drawList.AddQuad(new Vector2F(), new Vector2F(1, 0), new Vector2F(1, 1), new Vector2F(0, 1), 4294967295, 2.0f);
        }

        [RequireCImguiSystemFact]
        public void AddQuadFilled_ShouldCallNative()
        {
            ImDrawListPtr drawList = new ImDrawListPtr(new ImDrawList());
            drawList.AddQuadFilled(new Vector2F(), new Vector2F(1, 0), new Vector2F(1, 1), new Vector2F(0, 1), 4294967295);
        }

        [RequireCImguiSystemFact]
        public void AddRect_Default_ShouldCallNative()
        {
            ImDrawListPtr drawList = new ImDrawListPtr(new ImDrawList());
            drawList.AddRect(new Vector2F(), new Vector2F(1, 1), 4294967295);
        }

        [RequireCImguiSystemFact]
        public void AddRect_WithRounding_ShouldCallNative()
        {
            ImDrawListPtr drawList = new ImDrawListPtr(new ImDrawList());
            drawList.AddRect(new Vector2F(), new Vector2F(1, 1), 4294967295, 0.5f);
        }

        [RequireCImguiSystemFact]
        public void AddRect_WithRoundingFlags_ShouldCallNative()
        {
            ImDrawListPtr drawList = new ImDrawListPtr(new ImDrawList());
            drawList.AddRect(new Vector2F(), new Vector2F(1, 1), 4294967295, 0.5f, 0);
        }

        [RequireCImguiSystemFact]
        public void AddRect_WithRoundingFlagsThickness_ShouldCallNative()
        {
            ImDrawListPtr drawList = new ImDrawListPtr(new ImDrawList());
            drawList.AddRect(new Vector2F(), new Vector2F(1, 1), 4294967295, 0.5f, 0, 2.0f);
        }

        [RequireCImguiSystemFact]
        public void AddRectFilled_Default_ShouldCallNative()
        {
            ImDrawListPtr drawList = new ImDrawListPtr(new ImDrawList());
            drawList.AddRectFilled(new Vector2F(), new Vector2F(1, 1), 4294967295);
        }

        [RequireCImguiSystemFact]
        public void AddRectFilled_WithRounding_ShouldCallNative()
        {
            ImDrawListPtr drawList = new ImDrawListPtr(new ImDrawList());
            drawList.AddRectFilled(new Vector2F(), new Vector2F(1, 1), 4294967295, 0.5f);
        }

        [RequireCImguiSystemFact]
        public void AddRectFilled_WithRoundingFlags_ShouldCallNative()
        {
            ImDrawListPtr drawList = new ImDrawListPtr(new ImDrawList());
            drawList.AddRectFilled(new Vector2F(), new Vector2F(1, 1), 4294967295, 0.5f, 0);
        }

        [RequireCImguiSystemFact]
        public void AddRectFilledMultiColor_ShouldCallNative()
        {
            ImDrawListPtr drawList = new ImDrawListPtr(new ImDrawList());
            drawList.AddRectFilledMultiColor(new Vector2F(), new Vector2F(1, 1), 4294967295, 4294967295, 4294967295, 4294967295);
        }

        [RequireCImguiSystemFact]
        public void AddTriangle_Default_ShouldCallNative()
        {
            ImDrawListPtr drawList = new ImDrawListPtr(new ImDrawList());
            drawList.AddTriangle(new Vector2F(), new Vector2F(1, 0), new Vector2F(0.5f, 1), 4294967295);
        }

        [RequireCImguiSystemFact]
        public void AddTriangle_WithThickness_ShouldCallNative()
        {
            ImDrawListPtr drawList = new ImDrawListPtr(new ImDrawList());
            drawList.AddTriangle(new Vector2F(), new Vector2F(1, 0), new Vector2F(0.5f, 1), 4294967295, 2.0f);
        }

        [RequireCImguiSystemFact]
        public void AddTriangleFilled_ShouldCallNative()
        {
            ImDrawListPtr drawList = new ImDrawListPtr(new ImDrawList());
            drawList.AddTriangleFilled(new Vector2F(), new Vector2F(1, 0), new Vector2F(0.5f, 1), 4294967295);
        }

        [RequireCImguiSystemFact]
        public void ChannelsMerge_ShouldCallNative()
        {
            ImDrawListPtr drawList = new ImDrawListPtr(new ImDrawList());
            drawList.ChannelsMerge();
        }

        [RequireCImguiSystemFact]
        public void ChannelsSetCurrent_ShouldCallNative()
        {
            ImDrawListPtr drawList = new ImDrawListPtr(new ImDrawList());
            drawList.ChannelsSetCurrent(0);
        }

        [RequireCImguiSystemFact]
        public void ChannelsSplit_ShouldCallNative()
        {
            ImDrawListPtr drawList = new ImDrawListPtr(new ImDrawList());
            drawList.ChannelsSplit(1);
        }

        [RequireCImguiSystemFact]
        public void CloneOutput_ShouldCallNative()
        {
            ImDrawListPtr drawList = new ImDrawListPtr(new ImDrawList());
            ImDrawListPtr clone = drawList.CloneOutput();
            Assert.NotEqual(IntPtr.Zero, clone.NativePtr);
        }

        [RequireCImguiSystemFact]
        public void GetClipRectMax_ShouldCallNative()
        {
            ImDrawListPtr drawList = new ImDrawListPtr(new ImDrawList());
            Vector2F result = drawList.GetClipRectMax();
            _ = result;
        }

        [RequireCImguiSystemFact]
        public void GetClipRectMin_ShouldCallNative()
        {
            ImDrawListPtr drawList = new ImDrawListPtr(new ImDrawList());
            Vector2F result = drawList.GetClipRectMin();
            _ = result;
        }

        [RequireCImguiSystemFact]
        public void PathArcTo_Default_ShouldCallNative()
        {
            ImDrawListPtr drawList = new ImDrawListPtr(new ImDrawList());
            drawList.PathArcTo(new Vector2F(), 1.0f, 0.0f, 6.28f);
        }

        [RequireCImguiSystemFact]
        public void PathArcTo_WithNumSegments_ShouldCallNative()
        {
            ImDrawListPtr drawList = new ImDrawListPtr(new ImDrawList());
            drawList.PathArcTo(new Vector2F(), 1.0f, 0.0f, 6.28f, 12);
        }

        [RequireCImguiSystemFact]
        public void PathArcToFast_ShouldCallNative()
        {
            ImDrawListPtr drawList = new ImDrawListPtr(new ImDrawList());
            drawList.PathArcToFast(new Vector2F(), 1.0f, 0, 12);
        }

        [RequireCImguiSystemFact]
        public void PathBezierCubicCurveTo_Default_ShouldCallNative()
        {
            ImDrawListPtr drawList = new ImDrawListPtr(new ImDrawList());
            drawList.PathBezierCubicCurveTo(new Vector2F(), new Vector2F(), new Vector2F());
        }

        [RequireCImguiSystemFact]
        public void PathBezierCubicCurveTo_WithNumSegments_ShouldCallNative()
        {
            ImDrawListPtr drawList = new ImDrawListPtr(new ImDrawList());
            drawList.PathBezierCubicCurveTo(new Vector2F(), new Vector2F(), new Vector2F(), 12);
        }

        [RequireCImguiSystemFact]
        public void PathBezierQuadraticCurveTo_Default_ShouldCallNative()
        {
            ImDrawListPtr drawList = new ImDrawListPtr(new ImDrawList());
            drawList.PathBezierQuadraticCurveTo(new Vector2F(), new Vector2F());
        }

        [RequireCImguiSystemFact]
        public void PathBezierQuadraticCurveTo_WithNumSegments_ShouldCallNative()
        {
            ImDrawListPtr drawList = new ImDrawListPtr(new ImDrawList());
            drawList.PathBezierQuadraticCurveTo(new Vector2F(), new Vector2F(), 12);
        }

        [RequireCImguiSystemFact]
        public void PathClear_ShouldCallNative()
        {
            ImDrawListPtr drawList = new ImDrawListPtr(new ImDrawList());
            drawList.PathClear();
        }

        [RequireCImguiSystemFact]
        public void PathFillConvex_ShouldCallNative()
        {
            ImDrawListPtr drawList = new ImDrawListPtr(new ImDrawList());
            drawList.PathFillConvex(4294967295);
        }

        [RequireCImguiSystemFact]
        public void PathLineTo_ShouldCallNative()
        {
            ImDrawListPtr drawList = new ImDrawListPtr(new ImDrawList());
            drawList.PathLineTo(new Vector2F());
        }

        [RequireCImguiSystemFact]
        public void PathLineToMergeDuplicate_ShouldCallNative()
        {
            ImDrawListPtr drawList = new ImDrawListPtr(new ImDrawList());
            drawList.PathLineToMergeDuplicate(new Vector2F());
        }

        [RequireCImguiSystemFact]
        public void PathRect_Default_ShouldCallNative()
        {
            ImDrawListPtr drawList = new ImDrawListPtr(new ImDrawList());
            drawList.PathRect(new Vector2F(), new Vector2F(1, 1));
        }

        [RequireCImguiSystemFact]
        public void PathRect_WithRounding_ShouldCallNative()
        {
            ImDrawListPtr drawList = new ImDrawListPtr(new ImDrawList());
            drawList.PathRect(new Vector2F(), new Vector2F(1, 1), 0.5f);
        }

        [RequireCImguiSystemFact]
        public void PathRect_WithRoundingFlags_ShouldCallNative()
        {
            ImDrawListPtr drawList = new ImDrawListPtr(new ImDrawList());
            drawList.PathRect(new Vector2F(), new Vector2F(1, 1), 0.5f, 0);
        }

        [RequireCImguiSystemFact]
        public void PathStroke_Default_ShouldCallNative()
        {
            ImDrawListPtr drawList = new ImDrawListPtr(new ImDrawList());
            drawList.PathStroke(4294967295);
        }

        [RequireCImguiSystemFact]
        public void PathStroke_WithFlags_ShouldCallNative()
        {
            ImDrawListPtr drawList = new ImDrawListPtr(new ImDrawList());
            drawList.PathStroke(4294967295, 0);
        }

        [RequireCImguiSystemFact]
        public void PathStroke_WithFlagsThickness_ShouldCallNative()
        {
            ImDrawListPtr drawList = new ImDrawListPtr(new ImDrawList());
            drawList.PathStroke(4294967295, 0, 2.0f);
        }

        [RequireCImguiSystemFact]
        public void PopClipRect_ShouldCallNative()
        {
            ImDrawListPtr drawList = new ImDrawListPtr(new ImDrawList());
            drawList.PopClipRect();
        }

        [RequireCImguiSystemFact]
        public void PopTextureId_ShouldCallNative()
        {
            ImDrawListPtr drawList = new ImDrawListPtr(new ImDrawList());
            drawList.PopTextureId();
        }

        [RequireCImguiSystemFact]
        public void PrimQuadUv_ShouldCallNative()
        {
            ImDrawListPtr drawList = new ImDrawListPtr(new ImDrawList());
            drawList.PrimQuadUv(new Vector2F(), new Vector2F(1, 0), new Vector2F(1, 1), new Vector2F(0, 1), new Vector2F(), new Vector2F(1, 0), new Vector2F(1, 1), new Vector2F(0, 1), 4294967295);
        }

        [RequireCImguiSystemFact]
        public void PrimRect_ShouldCallNative()
        {
            ImDrawListPtr drawList = new ImDrawListPtr(new ImDrawList());
            drawList.PrimRect(new Vector2F(), new Vector2F(1, 1), 4294967295);
        }

        [RequireCImguiSystemFact]
        public void PrimRectUv_ShouldCallNative()
        {
            ImDrawListPtr drawList = new ImDrawListPtr(new ImDrawList());
            drawList.PrimRectUv(new Vector2F(), new Vector2F(1, 1), new Vector2F(), new Vector2F(1, 1), 4294967295);
        }

        [RequireCImguiSystemFact]
        public void PrimReserve_ShouldCallNative()
        {
            ImDrawListPtr drawList = new ImDrawListPtr(new ImDrawList());
            drawList.PrimReserve(6, 4);
        }

        [RequireCImguiSystemFact]
        public void PrimUnreserve_ShouldCallNative()
        {
            ImDrawListPtr drawList = new ImDrawListPtr(new ImDrawList());
            drawList.PrimUnreserve(0, 0);
        }

        [RequireCImguiSystemFact]
        public void PrimVtx_ShouldCallNative()
        {
            ImDrawListPtr drawList = new ImDrawListPtr(new ImDrawList());
            drawList.PrimVtx(new Vector2F(), new Vector2F(), 4294967295);
        }

        [RequireCImguiSystemFact]
        public void PrimWriteIdx_ShouldCallNative()
        {
            ImDrawListPtr drawList = new ImDrawListPtr(new ImDrawList());
            drawList.PrimWriteIdx(0);
        }

        [RequireCImguiSystemFact]
        public void PrimWriteVtx_ShouldCallNative()
        {
            ImDrawListPtr drawList = new ImDrawListPtr(new ImDrawList());
            drawList.PrimWriteVtx(new Vector2F(), new Vector2F(), 4294967295);
        }

        [RequireCImguiSystemFact]
        public void PushClipRect_Default_ShouldCallNative()
        {
            ImDrawListPtr drawList = new ImDrawListPtr(new ImDrawList());
            drawList.PushClipRect(new Vector2F(), new Vector2F(1, 1));
        }

        [RequireCImguiSystemFact]
        public void PushClipRect_WithIntersect_ShouldCallNative()
        {
            ImDrawListPtr drawList = new ImDrawListPtr(new ImDrawList());
            drawList.PushClipRect(new Vector2F(), new Vector2F(1, 1), true);
        }

        [RequireCImguiSystemFact]
        public void PushClipRectFullScreen_ShouldCallNative()
        {
            ImDrawListPtr drawList = new ImDrawListPtr(new ImDrawList());
            drawList.PushClipRectFullScreen();
        }

        [RequireCImguiSystemFact]
        public void PushTextureId_ShouldCallNative()
        {
            ImDrawListPtr drawList = new ImDrawListPtr(new ImDrawList());
            drawList.PushTextureId(IntPtr.Zero);
        }

        [RequireCImguiSystemFact]
        public void AddText_ShouldCallNative()
        {
            ImDrawListPtr drawList = new ImDrawListPtr(new ImDrawList());
            drawList.AddText(new Vector2F(), 4294967295, "Hello");
        }

        [RequireCImguiSystemFact]
        public void AddText_WithFont_ShouldCallNative()
        {
            ImDrawListPtr drawList = new ImDrawListPtr(new ImDrawList());
            ImFontPtr font = new ImFontPtr(IntPtr.Zero);
            drawList.AddText(font, 16.0f, new Vector2F(), 4294967295, "Hello");
        }

        [RequireCImguiSystemFact]
        public void AddBezierCubic_Default_ShouldCallNative()
        {
            ImDrawListPtr drawList = new ImDrawListPtr(new ImDrawList());
            drawList.AddBezierCubic(new Vector2F(), new Vector2F(), new Vector2F(), new Vector2F(), 4294967295, 1.0f);
        }

        [RequireCImguiSystemFact]
        public void AddBezierCubic_WithNumSegments_ShouldCallNative()
        {
            ImDrawListPtr drawList = new ImDrawListPtr(new ImDrawList());
            drawList.AddBezierCubic(new Vector2F(), new Vector2F(), new Vector2F(), new Vector2F(), 4294967295, 1.0f, 12);
        }

        [RequireCImguiSystemFact]
        public void AddBezierQuadratic_Default_ShouldCallNative()
        {
            ImDrawListPtr drawList = new ImDrawListPtr(new ImDrawList());
            drawList.AddBezierQuadratic(new Vector2F(), new Vector2F(), new Vector2F(), 4294967295, 1.0f);
        }

        [RequireCImguiSystemFact]
        public void AddBezierQuadratic_WithNumSegments_ShouldCallNative()
        {
            ImDrawListPtr drawList = new ImDrawListPtr(new ImDrawList());
            drawList.AddBezierQuadratic(new Vector2F(), new Vector2F(), new Vector2F(), 4294967295, 1.0f, 12);
        }

        [RequireCImguiSystemFact]
        public void ClearFreeMemory_ShouldCallNative()
        {
            ImDrawListPtr drawList = new ImDrawListPtr(new ImDrawList());
            drawList.ClearFreeMemory();
        }

        [RequireCImguiSystemFact]
        public void OnChangedClipRect_ShouldCallNative()
        {
            ImDrawListPtr drawList = new ImDrawListPtr(new ImDrawList());
            drawList.OnChangedClipRect();
        }

        [RequireCImguiSystemFact]
        public void OnChangedTextureID_ShouldCallNative()
        {
            ImDrawListPtr drawList = new ImDrawListPtr(new ImDrawList());
            drawList.OnChangedTextureID();
        }

        [RequireCImguiSystemFact]
        public void OnChangedVtxOffset_ShouldCallNative()
        {
            ImDrawListPtr drawList = new ImDrawListPtr(new ImDrawList());
            drawList.OnChangedVtxOffset();
        }

        [RequireCImguiSystemFact]
        public void PathArcToFastEx_ShouldCallNative()
        {
            ImDrawListPtr drawList = new ImDrawListPtr(new ImDrawList());
            drawList.PathArcToFastEx(new Vector2F(), 1.0f, 0, 12, 6);
        }

        [RequireCImguiSystemFact]
        public void PathArcToN_ShouldCallNative()
        {
            ImDrawListPtr drawList = new ImDrawListPtr(new ImDrawList());
            drawList.PathArcToN(new Vector2F(), 1.0f, 0.0f, 6.28f, 12);
        }

        [RequireCImguiSystemFact]
        public void PopUnusedDrawCmd_ShouldCallNative()
        {
            ImDrawListPtr drawList = new ImDrawListPtr(new ImDrawList());
            drawList.PopUnusedDrawCmd();
        }

        [RequireCImguiSystemFact]
        public void ResetForNewFrame_ShouldCallNative()
        {
            ImDrawListPtr drawList = new ImDrawListPtr(new ImDrawList());
            drawList.ResetForNewFrame();
        }

        [RequireCImguiSystemFact]
        public void TryMergeDrawCmd_ShouldCallNative()
        {
            ImDrawListPtr drawList = new ImDrawListPtr(new ImDrawList());
            drawList.TryMergeDrawCmd();
        }

        [RequireCImguiSystemFact]
        public void CalcCircleAutoSegmentCount_ShouldCallNative()
        {
            ImDrawListPtr drawList = new ImDrawListPtr(new ImDrawList());
            int result = drawList._CalcCircleAutoSegmentCount(1.0f);
            _ = result;
        }

        [Fact]
        public void CmdBuffer_WithImDrawListConstructor_ReturnsMarshaledData()
        {
            ImDrawList source = new ImDrawList();
            ImDrawListPtr drawList = new ImDrawListPtr(source);
            ImVectorG<ImDrawCmd> cmdBuffer = drawList.CmdBuffer;
            Assert.Equal(0, cmdBuffer.Size);
        }

        [Fact]
        public void IdxBuffer_WithImDrawListConstructor_ReturnsMarshaledData()
        {
            ImDrawList source = new ImDrawList();
            ImDrawListPtr drawList = new ImDrawListPtr(source);
            ImVectorG<ushort> idxBuffer = drawList.IdxBuffer;
            Assert.Equal(0, idxBuffer.Size);
        }

        [Fact]
        public void VtxBuffer_WithImDrawListConstructor_ReturnsMarshaledData()
        {
            ImDrawList source = new ImDrawList();
            ImDrawListPtr drawList = new ImDrawListPtr(source);
            ImVectorG<ImDrawVert> vtxBuffer = drawList.VtxBuffer;
            Assert.Equal(0, vtxBuffer.Size);
        }

        [Fact]
        public void Flags_WithImDrawListConstructor_ReturnsMarshaledData()
        {
            ImDrawList source = new ImDrawList();
            ImDrawListPtr drawList = new ImDrawListPtr(source);
            ImDrawListFlags flags = drawList.Flags;
            Assert.Equal(ImDrawListFlags.None, flags);
        }

        [Fact]
        public void VtxCurrentIdx_WithImDrawListConstructor_ReturnsMarshaledData()
        {
            ImDrawList source = new ImDrawList();
            ImDrawListPtr drawList = new ImDrawListPtr(source);
            uint idx = drawList.VtxCurrentIdx;
            Assert.Equal(0u, idx);
        }

        [Fact]
        public void Data_WithImDrawListConstructor_ReturnsMarshaledData()
        {
            ImDrawList source = new ImDrawList();
            ImDrawListPtr drawList = new ImDrawListPtr(source);
            IntPtr data = drawList.Data;
            Assert.Equal(IntPtr.Zero, data);
        }

        [Fact]
        public void OwnerName_WithImDrawListConstructor_ReturnsMarshaledData()
        {
            ImDrawList source = new ImDrawList();
            ImDrawListPtr drawList = new ImDrawListPtr(source);
            NullTerminatedString ownerName = drawList.OwnerName;
            Assert.Equal("", ownerName.ToString());
        }

        [Fact]
        public void IdxWritePtr_WithImDrawListConstructor_ReturnsMarshaledData()
        {
            ImDrawList source = new ImDrawList();
            ImDrawListPtr drawList = new ImDrawListPtr(source);
            IntPtr idxWritePtr = drawList.IdxWritePtr;
            Assert.Equal(IntPtr.Zero, idxWritePtr);
        }

        [Fact]
        public void ClipRectStack_WithImDrawListConstructor_ReturnsMarshaledData()
        {
            ImDrawList source = new ImDrawList();
            ImDrawListPtr drawList = new ImDrawListPtr(source);
            ImVectorG<Vector4F> clipRectStack = drawList.ClipRectStack;
            Assert.Equal(0, clipRectStack.Size);
        }

        [Fact]
        public void TextureIdStack_WithImDrawListConstructor_ReturnsMarshaledData()
        {
            ImDrawList source = new ImDrawList();
            ImDrawListPtr drawList = new ImDrawListPtr(source);
            ImVectorG<IntPtr> textureIdStack = drawList.TextureIdStack;
            Assert.Equal(0, textureIdStack.Size);
        }

        [Fact]
        public void Path_WithImDrawListConstructor_ReturnsMarshaledData()
        {
            ImDrawList source = new ImDrawList();
            ImDrawListPtr drawList = new ImDrawListPtr(source);
            ImVectorG<Vector2F> path = drawList.Path;
            Assert.Equal(0, path.Size);
        }

        [Fact]
        public void CmdHeader_WithImDrawListConstructor_ReturnsMarshaledData()
        {
            ImDrawList source = new ImDrawList();
            ImDrawListPtr drawList = new ImDrawListPtr(source);
            ImDrawCmdHeader cmdHeader = drawList.CmdHeader;
            _ = cmdHeader;
        }

        [Fact]
        public void Splitter_WithImDrawListConstructor_ReturnsMarshaledData()
        {
            ImDrawList source = new ImDrawList();
            ImDrawListPtr drawList = new ImDrawListPtr(source);
            ImDrawListSplitter splitter = drawList.Splitter;
            _ = splitter;
        }

        [Fact]
        public void FringeScale_WithImDrawListConstructor_ReturnsMarshaledData()
        {
            ImDrawList source = new ImDrawList();
            ImDrawListPtr drawList = new ImDrawListPtr(source);
            float fringeScale = drawList.FringeScale;
            Assert.Equal(0.0f, fringeScale);
        }

        [RequireCImguiSystemFact]
        public void VtxWritePtr_WithImDrawListConstructor_ThrowsNullReference()
        {
            ImDrawListPtr drawList = new ImDrawListPtr(new ImDrawList());
            Assert.Throws<NullReferenceException>(() => drawList.VtxWritePtr);
        }

        [Fact]
        public void NativePtr_FromImDrawListConstructor_ShouldNotBeZero()
        {
            ImDrawListPtr drawList = new ImDrawListPtr(new ImDrawList());
            Assert.NotEqual(IntPtr.Zero, drawList.NativePtr);
        }

        [Fact]
        public void ImplicitFromIntPtr_ShouldReturnSamePtr()
        {
            IntPtr ptr = new IntPtr(42);
            ImDrawListPtr drawList = ptr;
            Assert.Equal(ptr, drawList.NativePtr);
        }

        [Fact]
        public void ImplicitToIntPtr_ShouldReturnNativePtr()
        {
            IntPtr ptr = new IntPtr(99);
            ImDrawListPtr drawList = new ImDrawListPtr(ptr);
            IntPtr result = drawList;
            Assert.Equal(ptr, result);
        }

        [Fact]
        public void ImDrawListConstructor_AllocatesAndMarshals()
        {
            ImDrawList source = new ImDrawList();
            ImDrawListPtr drawList = new ImDrawListPtr(source);
            IntPtr nativePtr = drawList.NativePtr;
            Assert.NotEqual(IntPtr.Zero, nativePtr);
            ImDrawList result = System.Runtime.InteropServices.Marshal.PtrToStructure<ImDrawList>(nativePtr);
            Assert.Equal(0u, result.VtxCurrentIdx);
        }
    }
}
