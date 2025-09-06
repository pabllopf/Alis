// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImPlotTestP1.cs
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
using Alis.Extension.Graphic.Ui.Extras.Plot;
using Xunit;

namespace Alis.Extension.Graphic.Ui.Test.Extras.Plot.Native
{
    /// <summary>
    ///     The im plot test class
    /// </summary>
    public class ImPlotTestP1
    {
        /// <summary>
        ///     Tests that add colormap vec 4 ptr should throw dll not found exception v 1
        /// </summary>
        [Fact]
        public void AddColormap_Vec4Ptr_ShouldThrowDllNotFoundException_v1()
        {
            Vector4F cols = new Vector4F();
            Assert.Throws<DllNotFoundException>(() => ImPlot.AddColormap("name", ref cols, 1));
        }

        /// <summary>
        ///     Tests that add colormap vec 4 ptr should throw dll not found exception v 2
        /// </summary>
        [Fact]
        public void AddColormap_Vec4Ptr_ShouldThrowDllNotFoundException_v2()
        {
            Vector4F cols = new Vector4F();
            Assert.Throws<DllNotFoundException>(() => ImPlot.AddColormap("name", ref cols, 1, true));
        }

        /// <summary>
        ///     Tests that add colormap u 32 ptr should throw dll not found exception v 1
        /// </summary>
        [Fact]
        public void AddColormap_U32Ptr_ShouldThrowDllNotFoundException_v1()
        {
            uint cols = 0;
            Assert.Throws<DllNotFoundException>(() => ImPlot.AddColormap("name", ref cols, 1));
        }

        /// <summary>
        ///     Tests that add colormap u 32 ptr should throw dll not found exception v 2
        /// </summary>
        [Fact]
        public void AddColormap_U32Ptr_ShouldThrowDllNotFoundException_v2()
        {
            uint cols = 0;
            Assert.Throws<DllNotFoundException>(() => ImPlot.AddColormap("name", ref cols, 1, true));
        }

        /// <summary>
        ///     Tests that annotation should throw dll not found exception v 1
        /// </summary>
        [Fact]
        public void Annotation_ShouldThrowDllNotFoundException_v1()
        {
            Vector4F col = new Vector4F();
            Vector2F pixOffset = new Vector2F();
            Assert.Throws<DllNotFoundException>(() => ImPlot.Annotation(1.0, 2.0, col, pixOffset, true));
        }

        /// <summary>
        ///     Tests that annotation should throw dll not found exception v 2
        /// </summary>
        [Fact]
        public void Annotation_ShouldThrowDllNotFoundException_v2()
        {
            Vector4F col = new Vector4F();
            Vector2F pixOffset = new Vector2F();
            Assert.Throws<DllNotFoundException>(() => ImPlot.Annotation(1.0, 2.0, col, pixOffset, true, true));
        }

        /// <summary>
        ///     Tests that annotation should throw dll not found exception v 3
        /// </summary>
        [Fact]
        public void Annotation_ShouldThrowDllNotFoundException_v3()
        {
            Vector4F col = new Vector4F();
            Vector2F pixOffset = new Vector2F();
            Assert.Throws<DllNotFoundException>(() => ImPlot.Annotation(1.0, 2.0, col, pixOffset, true, "fmt"));
        }

        /// <summary>
        ///     Tests that begin aligned plots should throw dll not found exception v 1
        /// </summary>
        [Fact]
        public void BeginAlignedPlots_ShouldThrowDllNotFoundException_v1()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.BeginAlignedPlots("groupId"));
        }

        /// <summary>
        ///     Tests that begin aligned plots should throw dll not found exception v 2
        /// </summary>
        [Fact]
        public void BeginAlignedPlots_ShouldThrowDllNotFoundException_v2()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.BeginAlignedPlots("groupId", true));
        }

        /// <summary>
        ///     Tests that begin drag drop source axis should throw dll not found exception v 1
        /// </summary>
        [Fact]
        public void BeginDragDropSourceAxis_ShouldThrowDllNotFoundException_v1()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.BeginDragDropSourceAxis(ImAxis.X1));
        }

        /// <summary>
        ///     Tests that begin drag drop source axis should throw dll not found exception v 2
        /// </summary>
        [Fact]
        public void BeginDragDropSourceAxis_ShouldThrowDllNotFoundException_v2()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.BeginDragDropSourceAxis(ImAxis.X1, Ui.Extras.Plot.ImGuiDragDropFlags.None));
        }

        /// <summary>
        ///     Tests that begin drag drop source item should throw dll not found exception v 1
        /// </summary>
        [Fact]
        public void BeginDragDropSourceItem_ShouldThrowDllNotFoundException_v1()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.BeginDragDropSourceItem("labelId"));
        }

        /// <summary>
        ///     Tests that begin drag drop source item should throw dll not found exception v 2
        /// </summary>
        [Fact]
        public void BeginDragDropSourceItem_ShouldThrowDllNotFoundException_v2()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.BeginDragDropSourceItem("labelId", Ui.Extras.Plot.ImGuiDragDropFlags.None));
        }

        /// <summary>
        ///     Tests that begin drag drop source plot should throw dll not found exception v 1
        /// </summary>
        [Fact]
        public void BeginDragDropSourcePlot_ShouldThrowDllNotFoundException_v1()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.BeginDragDropSourcePlot());
        }

        /// <summary>
        ///     Tests that begin drag drop source plot should throw dll not found exception v 2
        /// </summary>
        [Fact]
        public void BeginDragDropSourcePlot_ShouldThrowDllNotFoundException_v2()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.BeginDragDropSourcePlot(Ui.Extras.Plot.ImGuiDragDropFlags.None));
        }

        /// <summary>
        ///     Tests that begin drag drop target axis should throw dll not found exception
        /// </summary>
        [Fact]
        public void BeginDragDropTargetAxis_ShouldThrowDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.BeginDragDropTargetAxis(ImAxis.X1));
        }

        /// <summary>
        ///     Tests that begin drag drop target legend should throw dll not found exception
        /// </summary>
        [Fact]
        public void BeginDragDropTargetLegend_ShouldThrowDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.BeginDragDropTargetLegend());
        }

        /// <summary>
        ///     Tests that begin drag drop target plot should throw dll not found exception
        /// </summary>
        [Fact]
        public void BeginDragDropTargetPlot_ShouldThrowDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.BeginDragDropTargetPlot());
        }

        /// <summary>
        ///     Tests that begin legend popup should throw dll not found exception v 1
        /// </summary>
        [Fact]
        public void BeginLegendPopup_ShouldThrowDllNotFoundException_v1()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.BeginLegendPopup("labelId"));
        }

        /// <summary>
        ///     Tests that begin legend popup should throw dll not found exception v 2
        /// </summary>
        [Fact]
        public void BeginLegendPopup_ShouldThrowDllNotFoundException_v2()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.BeginLegendPopup("labelId", ImGuiMouseButton.Left));
        }

        /// <summary>
        ///     Tests that begin plot should throw dll not found exception v 1
        /// </summary>
        [Fact]
        public void BeginPlot_ShouldThrowDllNotFoundException_v1()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.BeginPlot("titleId"));
        }

        /// <summary>
        ///     Tests that begin plot should throw dll not found exception v 2
        /// </summary>
        [Fact]
        public void BeginPlot_ShouldThrowDllNotFoundException_v2()
        {
            Vector2F size = new Vector2F();
            Assert.Throws<DllNotFoundException>(() => ImPlot.BeginPlot("titleId", size));
        }

        /// <summary>
        ///     Tests that begin plot should throw dll not found exception v 3
        /// </summary>
        [Fact]
        public void BeginPlot_ShouldThrowDllNotFoundException_v3()
        {
            Vector2F size = new Vector2F();
            Assert.Throws<DllNotFoundException>(() => ImPlot.BeginPlot("titleId", size, ImPlotFlags.None));
        }

        /// <summary>
        ///     Tests that begin subplots should throw dll not found exception v 1
        /// </summary>
        [Fact]
        public void BeginSubplots_ShouldThrowDllNotFoundException_v1()
        {
            Vector2F size = new Vector2F();
            Assert.Throws<DllNotFoundException>(() => ImPlot.BeginSubplots("titleId", 1, 1, size));
        }

        /// <summary>
        ///     Tests that begin subplots should throw dll not found exception v 2
        /// </summary>
        [Fact]
        public void BeginSubplots_ShouldThrowDllNotFoundException_v2()
        {
            Vector2F size = new Vector2F();
            Assert.Throws<DllNotFoundException>(() => ImPlot.BeginSubplots("titleId", 1, 1, size, ImPlotSubplotFlags.None));
        }

        /// <summary>
        ///     Tests that begin subplots should throw dll not found exception v 3
        /// </summary>
        [Fact]
        public void BeginSubplots_ShouldThrowDllNotFoundException_v3()
        {
            Vector2F size = new Vector2F();
            float rowRatios = 1.0f;
            Assert.Throws<DllNotFoundException>(() => ImPlot.BeginSubplots("titleId", 1, 1, size, ImPlotSubplotFlags.None, ref rowRatios));
        }

        /// <summary>
        ///     Tests that begin subplots should throw dll not found exception v 4
        /// </summary>
        [Fact]
        public void BeginSubplots_ShouldThrowDllNotFoundException_v4()
        {
            Vector2F size = new Vector2F();
            float rowRatios = 1.0f;
            float colRatios = 1.0f;
            Assert.Throws<DllNotFoundException>(() => ImPlot.BeginSubplots("titleId", 1, 1, size, ImPlotSubplotFlags.None, ref rowRatios, ref colRatios));
        }

        /// <summary>
        ///     Tests that bust color cache should throw dll not found exception v 1
        /// </summary>
        [Fact]
        public void BustColorCache_ShouldThrowDllNotFoundException_v1()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.BustColorCache());
        }

        /// <summary>
        ///     Tests that bust color cache should throw dll not found exception v 2
        /// </summary>
        [Fact]
        public void BustColorCache_ShouldThrowDllNotFoundException_v2()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.BustColorCache("plotTitleId"));
        }

        /// <summary>
        ///     Tests that cancel plot selection should throw dll not found exception
        /// </summary>
        [Fact]
        public void CancelPlotSelection_ShouldThrowDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.CancelPlotSelection());
        }

        /// <summary>
        ///     Tests that colormap button should throw dll not found exception v 1
        /// </summary>
        [Fact]
        public void ColormapButton_ShouldThrowDllNotFoundException_v1()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.ColormapButton("label"));
        }

        /// <summary>
        ///     Tests that colormap button should throw dll not found exception v 2
        /// </summary>
        [Fact]
        public void ColormapButton_ShouldThrowDllNotFoundException_v2()
        {
            Vector2F size = new Vector2F();
            Assert.Throws<DllNotFoundException>(() => ImPlot.ColormapButton("label", size));
        }

        /// <summary>
        ///     Tests that colormap button should throw dll not found exception v 3
        /// </summary>
        [Fact]
        public void ColormapButton_ShouldThrowDllNotFoundException_v3()
        {
            Vector2F size = new Vector2F();
            Assert.Throws<DllNotFoundException>(() => ImPlot.ColormapButton("label", size, (ImPlotColormap) (-1)));
        }

        /// <summary>
        ///     Tests that colormap icon should throw dll not found exception
        /// </summary>
        [Fact]
        public void ColormapIcon_ShouldThrowDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.ColormapIcon((ImPlotColormap) (-1)));
        }

        /// <summary>
        ///     Tests that colormap scale should throw dll not found exception v 1
        /// </summary>
        [Fact]
        public void ColormapScale_ShouldThrowDllNotFoundException_v1()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.ColormapScale("label", 0.0, 1.0));
        }

        /// <summary>
        ///     Tests that colormap scale should throw dll not found exception v 2
        /// </summary>
        [Fact]
        public void ColormapScale_ShouldThrowDllNotFoundException_v2()
        {
            Vector2F size = new Vector2F();
            Assert.Throws<DllNotFoundException>(() => ImPlot.ColormapScale("label", 0.0, 1.0, size));
        }

        /// <summary>
        ///     Tests that colormap scale should throw dll not found exception v 3
        /// </summary>
        [Fact]
        public void ColormapScale_ShouldThrowDllNotFoundException_v3()
        {
            Vector2F size = new Vector2F();
            Assert.Throws<DllNotFoundException>(() => ImPlot.ColormapScale("label", 0.0, 1.0, size, "format"));
        }

        /// <summary>
        ///     Tests that colormap scale should throw dll not found exception v 4
        /// </summary>
        [Fact]
        public void ColormapScale_ShouldThrowDllNotFoundException_v4()
        {
            Vector2F size = new Vector2F();
            Assert.Throws<DllNotFoundException>(() => ImPlot.ColormapScale("label", 0.0, 1.0, size, "format", ImPlotColormapScaleFlags.None));
        }

        /// <summary>
        ///     Tests that colormap scale should throw dll not found exception v 5
        /// </summary>
        [Fact]
        public void ColormapScale_ShouldThrowDllNotFoundException_v5()
        {
            Vector2F size = new Vector2F();
            Assert.Throws<DllNotFoundException>(() => ImPlot.ColormapScale("label", 0.0, 1.0, size, "format", ImPlotColormapScaleFlags.None, (ImPlotColormap) (-1)));
        }

        /// <summary>
        ///     Tests that colormap slider should throw dll not found exception v 1
        /// </summary>
        [Fact]
        public void ColormapSlider_ShouldThrowDllNotFoundException_v1()
        {
            float t = 0.0f;
            Assert.Throws<DllNotFoundException>(() => ImPlot.ColormapSlider("label", ref t));
        }

        /// <summary>
        ///     Tests that colormap slider should throw dll not found exception v 2
        /// </summary>
        [Fact]
        public void ColormapSlider_ShouldThrowDllNotFoundException_v2()
        {
            float t = 0.0f;
            Assert.Throws<DllNotFoundException>(() => ImPlot.ColormapSlider("label", ref t, out Vector4F _));
        }

        /// <summary>
        ///     Tests that colormap slider should throw dll not found exception v 3
        /// </summary>
        [Fact]
        public void ColormapSlider_ShouldThrowDllNotFoundException_v3()
        {
            float t = 0.0f;
            Assert.Throws<DllNotFoundException>(() => ImPlot.ColormapSlider("label", ref t, out Vector4F _, "format"));
        }

        /// <summary>
        ///     Tests that colormap slider should throw dll not found exception v 4
        /// </summary>
        [Fact]
        public void ColormapSlider_ShouldThrowDllNotFoundException_v4()
        {
            float t = 0.0f;
            Assert.Throws<DllNotFoundException>(() => ImPlot.ColormapSlider("label", ref t, out Vector4F _, "format", (ImPlotColormap) (-1)));
        }

        /// <summary>
        ///     Tests that create context should throw dll not found exception
        /// </summary>
        [Fact]
        public void CreateContext_ShouldThrowDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.CreateContext());
        }

        /// <summary>
        ///     Tests that destroy context should throw dll not found exception v 1
        /// </summary>
        [Fact]
        public void DestroyContext_ShouldThrowDllNotFoundException_v1()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.DestroyContext());
        }

        /// <summary>
        ///     Tests that destroy context should throw dll not found exception v 2
        /// </summary>
        [Fact]
        public void DestroyContext_ShouldThrowDllNotFoundException_v2()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.DestroyContext(IntPtr.Zero));
        }

        /// <summary>
        ///     Tests that drag line x should throw dll not found exception v 1
        /// </summary>
        [Fact]
        public void DragLineX_ShouldThrowDllNotFoundException_v1()
        {
            double x = 0.0;
            Vector4F col = new Vector4F();
            Assert.Throws<DllNotFoundException>(() => ImPlot.DragLineX(1, ref x, col));
        }

        /// <summary>
        ///     Tests that drag line x should throw dll not found exception v 2
        /// </summary>
        [Fact]
        public void DragLineX_ShouldThrowDllNotFoundException_v2()
        {
            double x = 0.0;
            Vector4F col = new Vector4F();
            Assert.Throws<DllNotFoundException>(() => ImPlot.DragLineX(1, ref x, col, 1.0f));
        }

        /// <summary>
        ///     Tests that drag line x should throw dll not found exception v 3
        /// </summary>
        [Fact]
        public void DragLineX_ShouldThrowDllNotFoundException_v3()
        {
            double x = 0.0;
            Vector4F col = new Vector4F();
            Assert.Throws<DllNotFoundException>(() => ImPlot.DragLineX(1, ref x, col, 1.0f, ImPlotDragToolFlags.None));
        }

        /// <summary>
        ///     Tests that drag line y should throw dll not found exception v 1
        /// </summary>
        [Fact]
        public void DragLineY_ShouldThrowDllNotFoundException_v1()
        {
            double y = 0.0;
            Vector4F col = new Vector4F();
            Assert.Throws<DllNotFoundException>(() => ImPlot.DragLineY(1, ref y, col));
        }

        /// <summary>
        ///     Tests that drag line y should throw dll not found exception v 2
        /// </summary>
        [Fact]
        public void DragLineY_ShouldThrowDllNotFoundException_v2()
        {
            double y = 0.0;
            Vector4F col = new Vector4F();
            Assert.Throws<DllNotFoundException>(() => ImPlot.DragLineY(1, ref y, col, 1.0f));
        }

        /// <summary>
        ///     Tests that drag line y should throw dll not found exception v 3
        /// </summary>
        [Fact]
        public void DragLineY_ShouldThrowDllNotFoundException_v3()
        {
            double y = 0.0;
            Vector4F col = new Vector4F();
            Assert.Throws<DllNotFoundException>(() => ImPlot.DragLineY(1, ref y, col, 1.0f, ImPlotDragToolFlags.None));
        }

        /// <summary>
        ///     Tests that drag point should throw dll not found exception v 1
        /// </summary>
        [Fact]
        public void DragPoint_ShouldThrowDllNotFoundException_v1()
        {
            double x = 0.0;
            double y = 0.0;
            Vector4F col = new Vector4F();
            Assert.Throws<DllNotFoundException>(() => ImPlot.DragPoint(1, ref x, ref y, col));
        }

        /// <summary>
        ///     Tests that drag point should throw dll not found exception v 2
        /// </summary>
        [Fact]
        public void DragPoint_ShouldThrowDllNotFoundException_v2()
        {
            double x = 0.0;
            double y = 0.0;
            Vector4F col = new Vector4F();
            Assert.Throws<DllNotFoundException>(() => ImPlot.DragPoint(1, ref x, ref y, col, 4.0f));
        }

        /// <summary>
        ///     Tests that drag point should throw dll not found exception v 3
        /// </summary>
        [Fact]
        public void DragPoint_ShouldThrowDllNotFoundException_v3()
        {
            double x = 0.0;
            double y = 0.0;
            Vector4F col = new Vector4F();
            Assert.Throws<DllNotFoundException>(() => ImPlot.DragPoint(1, ref x, ref y, col, 4.0f, ImPlotDragToolFlags.None));
        }

        /// <summary>
        ///     Tests that drag rect should throw dll not found exception v 1
        /// </summary>
        [Fact]
        public void DragRect_ShouldThrowDllNotFoundException_v1()
        {
            double x1 = 0.0;
            double y1 = 0.0;
            double x2 = 0.0;
            double y2 = 0.0;
            Vector4F col = new Vector4F();
            Assert.Throws<DllNotFoundException>(() => ImPlot.DragRect(1, ref x1, ref y1, ref x2, ref y2, col));
        }

        /// <summary>
        ///     Tests that drag rect should throw dll not found exception v 2
        /// </summary>
        [Fact]
        public void DragRect_ShouldThrowDllNotFoundException_v2()
        {
            double x1 = 0.0;
            double y1 = 0.0;
            double x2 = 0.0;
            double y2 = 0.0;
            Vector4F col = new Vector4F();
            Assert.Throws<DllNotFoundException>(() => ImPlot.DragRect(1, ref x1, ref y1, ref x2, ref y2, col, ImPlotDragToolFlags.None));
        }

        /// <summary>
        ///     Tests that end aligned plots should throw dll not found exception
        /// </summary>
        [Fact]
        public void EndAlignedPlots_ShouldThrowDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.EndAlignedPlots());
        }

        /// <summary>
        ///     Tests that end drag drop source should throw dll not found exception
        /// </summary>
        [Fact]
        public void EndDragDropSource_ShouldThrowDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.EndDragDropSource());
        }

        /// <summary>
        ///     Tests that add colormap with vector 4 throws dll not found exception
        /// </summary>
        [Fact]
        public void AddColormap_WithVector4_ThrowsDllNotFoundException()
        {
            Vector4F cols = new Vector4F();
            Assert.Throws<DllNotFoundException>(() => ImPlot.AddColormap("name", ref cols, 1));
        }

        /// <summary>
        ///     Tests that add colormap with vector 4 and qual throws dll not found exception
        /// </summary>
        [Fact]
        public void AddColormap_WithVector4AndQual_ThrowsDllNotFoundException()
        {
            Vector4F cols = new Vector4F();
            Assert.Throws<DllNotFoundException>(() => ImPlot.AddColormap("name", ref cols, 1, true));
        }

        /// <summary>
        ///     Tests that add colormap with u int throws dll not found exception
        /// </summary>
        [Fact]
        public void AddColormap_WithUInt_ThrowsDllNotFoundException()
        {
            uint cols = 0;
            Assert.Throws<DllNotFoundException>(() => ImPlot.AddColormap("name", ref cols, 1));
        }

        /// <summary>
        ///     Tests that add colormap with u int and qual throws dll not found exception
        /// </summary>
        [Fact]
        public void AddColormap_WithUIntAndQual_ThrowsDllNotFoundException()
        {
            uint cols = 0;
            Assert.Throws<DllNotFoundException>(() => ImPlot.AddColormap("name", ref cols, 1, true));
        }

        /// <summary>
        ///     Tests that annotation with basic params throws dll not found exception
        /// </summary>
        [Fact]
        public void Annotation_WithBasicParams_ThrowsDllNotFoundException()
        {
            Vector4F col = new Vector4F();
            Vector2F pixOffset = new Vector2F();
            Assert.Throws<DllNotFoundException>(() => ImPlot.Annotation(1.0, 1.0, col, pixOffset, true));
        }

        /// <summary>
        ///     Tests that annotation with round throws dll not found exception
        /// </summary>
        [Fact]
        public void Annotation_WithRound_ThrowsDllNotFoundException()
        {
            Vector4F col = new Vector4F();
            Vector2F pixOffset = new Vector2F();
            Assert.Throws<DllNotFoundException>(() => ImPlot.Annotation(1.0, 1.0, col, pixOffset, true, true));
        }

        /// <summary>
        ///     Tests that annotation with format throws dll not found exception
        /// </summary>
        [Fact]
        public void Annotation_WithFormat_ThrowsDllNotFoundException()
        {
            Vector4F col = new Vector4F();
            Vector2F pixOffset = new Vector2F();
            Assert.Throws<DllNotFoundException>(() => ImPlot.Annotation(1.0, 1.0, col, pixOffset, true, "fmt"));
        }

        /// <summary>
        ///     Tests that begin aligned plots with group id throws dll not found exception
        /// </summary>
        [Fact]
        public void BeginAlignedPlots_WithGroupId_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.BeginAlignedPlots("groupId"));
        }

        /// <summary>
        ///     Tests that begin aligned plots with group id and vertical throws dll not found exception
        /// </summary>
        [Fact]
        public void BeginAlignedPlots_WithGroupIdAndVertical_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.BeginAlignedPlots("groupId", true));
        }

        /// <summary>
        ///     Tests that begin drag drop source axis with axis throws dll not found exception
        /// </summary>
        [Fact]
        public void BeginDragDropSourceAxis_WithAxis_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.BeginDragDropSourceAxis(ImAxis.X1));
        }

        /// <summary>
        ///     Tests that begin drag drop source axis with axis and flags throws dll not found exception
        /// </summary>
        [Fact]
        public void BeginDragDropSourceAxis_WithAxisAndFlags_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.BeginDragDropSourceAxis(ImAxis.X1, (Ui.Extras.Plot.ImGuiDragDropFlags) ImGuiDragDropFlags.None));
        }

        /// <summary>
        ///     Tests that begin drag drop source item with label id throws dll not found exception
        /// </summary>
        [Fact]
        public void BeginDragDropSourceItem_WithLabelId_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.BeginDragDropSourceItem("labelId"));
        }

        /// <summary>
        ///     Tests that begin drag drop source item with label id and flags throws dll not found exception
        /// </summary>
        [Fact]
        public void BeginDragDropSourceItem_WithLabelIdAndFlags_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.BeginDragDropSourceItem("labelId", (Ui.Extras.Plot.ImGuiDragDropFlags) ImGuiDragDropFlags.None));
        }

        /// <summary>
        ///     Tests that begin drag drop source plot throws dll not found exception
        /// </summary>
        [Fact]
        public void BeginDragDropSourcePlot_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.BeginDragDropSourcePlot());
        }

        /// <summary>
        ///     Tests that begin drag drop source plot with flags throws dll not found exception
        /// </summary>
        [Fact]
        public void BeginDragDropSourcePlot_WithFlags_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.BeginDragDropSourcePlot((Ui.Extras.Plot.ImGuiDragDropFlags) ImGuiDragDropFlags.None));
        }

        /// <summary>
        ///     Tests that begin drag drop target axis with axis throws dll not found exception
        /// </summary>
        [Fact]
        public void BeginDragDropTargetAxis_WithAxis_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.BeginDragDropTargetAxis(ImAxis.X1));
        }

        /// <summary>
        ///     Tests that begin drag drop target legend throws dll not found exception
        /// </summary>
        [Fact]
        public void BeginDragDropTargetLegend_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.BeginDragDropTargetLegend());
        }

        /// <summary>
        ///     Tests that begin drag drop target plot throws dll not found exception
        /// </summary>
        [Fact]
        public void BeginDragDropTargetPlot_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.BeginDragDropTargetPlot());
        }

        /// <summary>
        ///     Tests that begin legend popup with label id throws dll not found exception
        /// </summary>
        [Fact]
        public void BeginLegendPopup_WithLabelId_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.BeginLegendPopup("labelId"));
        }

        /// <summary>
        ///     Tests that begin legend popup with label id and mouse button throws dll not found exception
        /// </summary>
        [Fact]
        public void BeginLegendPopup_WithLabelIdAndMouseButton_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.BeginLegendPopup("labelId", ImGuiMouseButton.Left));
        }

        /// <summary>
        ///     Tests that begin plot with title id throws dll not found exception
        /// </summary>
        [Fact]
        public void BeginPlot_WithTitleId_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.BeginPlot("titleId"));
        }

        /// <summary>
        ///     Tests that begin plot with title id and size throws dll not found exception
        /// </summary>
        [Fact]
        public void BeginPlot_WithTitleIdAndSize_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.BeginPlot("titleId", new Vector2F()));
        }

        /// <summary>
        ///     Tests that begin plot with title id size and flags throws dll not found exception
        /// </summary>
        [Fact]
        public void BeginPlot_WithTitleIdSizeAndFlags_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.BeginPlot("titleId", new Vector2F(), ImPlotFlags.None));
        }

        /// <summary>
        ///     Tests that begin subplots with basic params throws dll not found exception
        /// </summary>
        [Fact]
        public void BeginSubplots_WithBasicParams_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.BeginSubplots("titleId", 1, 1, new Vector2F()));
        }

        /// <summary>
        ///     Tests that begin subplots with flags throws dll not found exception
        /// </summary>
        [Fact]
        public void BeginSubplots_WithFlags_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.BeginSubplots("titleId", 1, 1, new Vector2F(), ImPlotSubplotFlags.None));
        }

        /// <summary>
        ///     Tests that begin subplots with row ratios throws dll not found exception
        /// </summary>
        [Fact]
        public void BeginSubplots_WithRowRatios_ThrowsDllNotFoundException()
        {
            float rowRatios = 0.0f;
            Assert.Throws<DllNotFoundException>(() => ImPlot.BeginSubplots("titleId", 1, 1, new Vector2F(), ImPlotSubplotFlags.None, ref rowRatios));
        }

        /// <summary>
        ///     Tests that begin subplots with row and col ratios throws dll not found exception
        /// </summary>
        [Fact]
        public void BeginSubplots_WithRowAndColRatios_ThrowsDllNotFoundException()
        {
            float rowRatios = 0.0f;
            float colRatios = 0.0f;
            Assert.Throws<DllNotFoundException>(() => ImPlot.BeginSubplots("titleId", 1, 1, new Vector2F(), ImPlotSubplotFlags.None, ref rowRatios, ref colRatios));
        }

        /// <summary>
        ///     Tests that bust color cache throws dll not found exception
        /// </summary>
        [Fact]
        public void BustColorCache_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.BustColorCache());
        }

        /// <summary>
        ///     Tests that bust color cache with plot title id throws dll not found exception
        /// </summary>
        [Fact]
        public void BustColorCache_WithPlotTitleId_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.BustColorCache("plotTitleId"));
        }

        /// <summary>
        ///     Tests that cancel plot selection throws dll not found exception
        /// </summary>
        [Fact]
        public void CancelPlotSelection_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.CancelPlotSelection());
        }

        /// <summary>
        ///     Tests that colormap button with label throws dll not found exception
        /// </summary>
        [Fact]
        public void ColormapButton_WithLabel_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.ColormapButton("label"));
        }

        /// <summary>
        ///     Tests that colormap button with label and size throws dll not found exception
        /// </summary>
        [Fact]
        public void ColormapButton_WithLabelAndSize_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.ColormapButton("label", new Vector2F()));
        }

        /// <summary>
        ///     Tests that colormap button with label size and cmap throws dll not found exception
        /// </summary>
        [Fact]
        public void ColormapButton_WithLabelSizeAndCmap_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.ColormapButton("label", new Vector2F(), (ImPlotColormap) (-1)));
        }

        /// <summary>
        ///     Tests that colormap icon with cmap throws dll not found exception
        /// </summary>
        [Fact]
        public void ColormapIcon_WithCmap_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.ColormapIcon((ImPlotColormap) (-1)));
        }

        /// <summary>
        ///     Tests that colormap scale with label scale min and scale max throws dll not found exception
        /// </summary>
        [Fact]
        public void ColormapScale_WithLabelScaleMinAndScaleMax_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.ColormapScale("label", 0.0, 1.0));
        }

        /// <summary>
        ///     Tests that colormap scale with label scale min scale max and size throws dll not found exception
        /// </summary>
        [Fact]
        public void ColormapScale_WithLabelScaleMinScaleMaxAndSize_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.ColormapScale("label", 0.0, 1.0, new Vector2F()));
        }

        /// <summary>
        ///     Tests that colormap scale with label scale min scale max size and format throws dll not found exception
        /// </summary>
        [Fact]
        public void ColormapScale_WithLabelScaleMinScaleMaxSizeAndFormat_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.ColormapScale("label", 0.0, 1.0, new Vector2F(), "format"));
        }

        /// <summary>
        ///     Tests that colormap scale with label scale min scale max size format and flags throws dll not found exception
        /// </summary>
        [Fact]
        public void ColormapScale_WithLabelScaleMinScaleMaxSizeFormatAndFlags_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.ColormapScale("label", 0.0, 1.0, new Vector2F(), "format", ImPlotColormapScaleFlags.None));
        }

        /// <summary>
        ///     Tests that colormap scale with label scale min scale max size format flags and cmap throws dll not found exception
        /// </summary>
        [Fact]
        public void ColormapScale_WithLabelScaleMinScaleMaxSizeFormatFlagsAndCmap_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.ColormapScale("label", 0.0, 1.0, new Vector2F(), "format", ImPlotColormapScaleFlags.None, (ImPlotColormap) (-1)));
        }

        /// <summary>
        ///     Tests that colormap slider with label and t throws dll not found exception
        /// </summary>
        [Fact]
        public void ColormapSlider_WithLabelAndT_ThrowsDllNotFoundException()
        {
            float t = 0.0f;
            Assert.Throws<DllNotFoundException>(() => ImPlot.ColormapSlider("label", ref t));
        }

        /// <summary>
        ///     Tests that colormap slider with label t and out throws dll not found exception
        /// </summary>
        [Fact]
        public void ColormapSlider_WithLabelTAndOut_ThrowsDllNotFoundException()
        {
            float t = 0.0f;
            Assert.Throws<DllNotFoundException>(() => ImPlot.ColormapSlider("label", ref t, out Vector4F _));
        }

        /// <summary>
        ///     Tests that colormap slider with label t out and format throws dll not found exception
        /// </summary>
        [Fact]
        public void ColormapSlider_WithLabelTOutAndFormat_ThrowsDllNotFoundException()
        {
            float t = 0.0f;
            Assert.Throws<DllNotFoundException>(() => ImPlot.ColormapSlider("label", ref t, out Vector4F _, "format"));
        }

        /// <summary>
        ///     Tests that colormap slider with label t out format and cmap throws dll not found exception
        /// </summary>
        [Fact]
        public void ColormapSlider_WithLabelTOutFormatAndCmap_ThrowsDllNotFoundException()
        {
            float t = 0.0f;
            Assert.Throws<DllNotFoundException>(() => ImPlot.ColormapSlider("label", ref t, out Vector4F _, "format", (ImPlotColormap) (-1)));
        }

        /// <summary>
        ///     Tests that create context throws dll not found exception
        /// </summary>
        [Fact]
        public void CreateContext_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.CreateContext());
        }

        /// <summary>
        ///     Tests that destroy context throws dll not found exception
        /// </summary>
        [Fact]
        public void DestroyContext_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.DestroyContext());
        }

        /// <summary>
        ///     Tests that destroy context with ctx throws dll not found exception
        /// </summary>
        [Fact]
        public void DestroyContext_WithCtx_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.DestroyContext(IntPtr.Zero));
        }

        /// <summary>
        ///     Tests that drag line x with id x and col throws dll not found exception
        /// </summary>
        [Fact]
        public void DragLineX_WithIdXAndCol_ThrowsDllNotFoundException()
        {
            double x = 0.0;
            Vector4F col = new Vector4F();
            Assert.Throws<DllNotFoundException>(() => ImPlot.DragLineX(1, ref x, col));
        }

        /// <summary>
        ///     Tests that drag line x with id x col and thickness throws dll not found exception
        /// </summary>
        [Fact]
        public void DragLineX_WithIdXColAndThickness_ThrowsDllNotFoundException()
        {
            double x = 0.0;
            Vector4F col = new Vector4F();
            Assert.Throws<DllNotFoundException>(() => ImPlot.DragLineX(1, ref x, col, 1.0f));
        }

        /// <summary>
        ///     Tests that drag line x with id x col thickness and flags throws dll not found exception
        /// </summary>
        [Fact]
        public void DragLineX_WithIdXColThicknessAndFlags_ThrowsDllNotFoundException()
        {
            double x = 0.0;
            Vector4F col = new Vector4F();
            Assert.Throws<DllNotFoundException>(() => ImPlot.DragLineX(1, ref x, col, 1.0f, ImPlotDragToolFlags.None));
        }

        /// <summary>
        ///     Tests that drag line y with id y and col throws dll not found exception
        /// </summary>
        [Fact]
        public void DragLineY_WithIdYAndCol_ThrowsDllNotFoundException()
        {
            double y = 0.0;
            Vector4F col = new Vector4F();
            Assert.Throws<DllNotFoundException>(() => ImPlot.DragLineY(1, ref y, col));
        }

        /// <summary>
        ///     Tests that drag line y with id y col and thickness throws dll not found exception
        /// </summary>
        [Fact]
        public void DragLineY_WithIdYColAndThickness_ThrowsDllNotFoundException()
        {
            double y = 0.0;
            Vector4F col = new Vector4F();
            Assert.Throws<DllNotFoundException>(() => ImPlot.DragLineY(1, ref y, col, 1.0f));
        }

        /// <summary>
        ///     Tests that drag line y with id y col thickness and flags throws dll not found exception
        /// </summary>
        [Fact]
        public void DragLineY_WithIdYColThicknessAndFlags_ThrowsDllNotFoundException()
        {
            double y = 0.0;
            Vector4F col = new Vector4F();
            Assert.Throws<DllNotFoundException>(() => ImPlot.DragLineY(1, ref y, col, 1.0f, ImPlotDragToolFlags.None));
        }

        /// <summary>
        ///     Tests that drag point with id x and y col throws dll not found exception
        /// </summary>
        [Fact]
        public void DragPoint_WithIdXAndYCol_ThrowsDllNotFoundException()
        {
            double x = 0.0;
            double y = 0.0;
            Vector4F col = new Vector4F();
            Assert.Throws<DllNotFoundException>(() => ImPlot.DragPoint(1, ref x, ref y, col));
        }

        /// <summary>
        ///     Tests that drag point with id x and y col and size throws dll not found exception
        /// </summary>
        [Fact]
        public void DragPoint_WithIdXAndYColAndSize_ThrowsDllNotFoundException()
        {
            double x = 0.0;
            double y = 0.0;
            Vector4F col = new Vector4F();
            Assert.Throws<DllNotFoundException>(() => ImPlot.DragPoint(1, ref x, ref y, col, 4.0f));
        }

        /// <summary>
        ///     Tests that drag point with id x and y col size and flags throws dll not found exception
        /// </summary>
        [Fact]
        public void DragPoint_WithIdXAndYColSizeAndFlags_ThrowsDllNotFoundException()
        {
            double x = 0.0;
            double y = 0.0;
            Vector4F col = new Vector4F();
            Assert.Throws<DllNotFoundException>(() => ImPlot.DragPoint(1, ref x, ref y, col, 4.0f, ImPlotDragToolFlags.None));
        }

        /// <summary>
        ///     Tests that drag rect with id x 1 y 1 x 2 y 2 and col throws dll not found exception
        /// </summary>
        [Fact]
        public void DragRect_WithIdX1Y1X2Y2AndCol_ThrowsDllNotFoundException()
        {
            double x1 = 0.0;
            double y1 = 0.0;
            double x2 = 0.0;
            double y2 = 0.0;
            Vector4F col = new Vector4F();
            Assert.Throws<DllNotFoundException>(() => ImPlot.DragRect(1, ref x1, ref y1, ref x2, ref y2, col));
        }

        /// <summary>
        ///     Tests that drag rect with id x 1 y 1 x 2 y 2 col and flags throws dll not found exception
        /// </summary>
        [Fact]
        public void DragRect_WithIdX1Y1X2Y2ColAndFlags_ThrowsDllNotFoundException()
        {
            double x1 = 0.0;
            double y1 = 0.0;
            double x2 = 0.0;
            double y2 = 0.0;
            Vector4F col = new Vector4F();
            Assert.Throws<DllNotFoundException>(() => ImPlot.DragRect(1, ref x1, ref y1, ref x2, ref y2, col, ImPlotDragToolFlags.None));
        }

        /// <summary>
        ///     Tests that end aligned plots throws dll not found exception
        /// </summary>
        [Fact]
        public void EndAlignedPlots_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.EndAlignedPlots());
        }

        /// <summary>
        ///     Tests that end drag drop source throws dll not found exception
        /// </summary>
        [Fact]
        public void EndDragDropSource_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.EndDragDropSource());
        }
    }
}