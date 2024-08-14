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
using Alis.Extension.Graphic.ImGui.Extras.Plot;
using Alis.Extension.Graphic.ImGui.Extras.Plot.Native;
using Xunit;

namespace Alis.Extension.Graphic.ImGui.Test.Extras.Plot.Native
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
            Vector4 cols = new Vector4();
            Assert.Throws<DllNotFoundException>(() => ImPlot.AddColormap("name", ref cols, 1));
        }
        
        /// <summary>
        ///     Tests that add colormap vec 4 ptr should throw dll not found exception v 2
        /// </summary>
        [Fact]
        public void AddColormap_Vec4Ptr_ShouldThrowDllNotFoundException_v2()
        {
            Vector4 cols = new Vector4();
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
            Vector4 col = new Vector4();
            Vector2 pixOffset = new Vector2();
            Assert.Throws<DllNotFoundException>(() => ImPlot.Annotation(1.0, 2.0, col, pixOffset, true));
        }
        
        /// <summary>
        ///     Tests that annotation should throw dll not found exception v 2
        /// </summary>
        [Fact]
        public void Annotation_ShouldThrowDllNotFoundException_v2()
        {
            Vector4 col = new Vector4();
            Vector2 pixOffset = new Vector2();
            Assert.Throws<DllNotFoundException>(() => ImPlot.Annotation(1.0, 2.0, col, pixOffset, true, true));
        }
        
        /// <summary>
        ///     Tests that annotation should throw dll not found exception v 3
        /// </summary>
        [Fact]
        public void Annotation_ShouldThrowDllNotFoundException_v3()
        {
            Vector4 col = new Vector4();
            Vector2 pixOffset = new Vector2();
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
            Assert.Throws<DllNotFoundException>(() => ImPlot.BeginDragDropSourceAxis(ImAxis.X1, ImGui.Extras.Plot.ImGuiDragDropFlags.None));
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
            Assert.Throws<DllNotFoundException>(() => ImPlot.BeginDragDropSourceItem("labelId", ImGui.Extras.Plot.ImGuiDragDropFlags.None));
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
            Assert.Throws<DllNotFoundException>(() => ImPlot.BeginDragDropSourcePlot(ImGui.Extras.Plot.ImGuiDragDropFlags.None));
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
            Vector2 size = new Vector2();
            Assert.Throws<DllNotFoundException>(() => ImPlot.BeginPlot("titleId", size));
        }
        
        /// <summary>
        ///     Tests that begin plot should throw dll not found exception v 3
        /// </summary>
        [Fact]
        public void BeginPlot_ShouldThrowDllNotFoundException_v3()
        {
            Vector2 size = new Vector2();
            Assert.Throws<DllNotFoundException>(() => ImPlot.BeginPlot("titleId", size, ImPlotFlags.None));
        }
        
        /// <summary>
        ///     Tests that begin subplots should throw dll not found exception v 1
        /// </summary>
        [Fact]
        public void BeginSubplots_ShouldThrowDllNotFoundException_v1()
        {
            Vector2 size = new Vector2();
            Assert.Throws<DllNotFoundException>(() => ImPlot.BeginSubplots("titleId", 1, 1, size));
        }
        
        /// <summary>
        ///     Tests that begin subplots should throw dll not found exception v 2
        /// </summary>
        [Fact]
        public void BeginSubplots_ShouldThrowDllNotFoundException_v2()
        {
            Vector2 size = new Vector2();
            Assert.Throws<DllNotFoundException>(() => ImPlot.BeginSubplots("titleId", 1, 1, size, ImPlotSubplotFlags.None));
        }
        
        /// <summary>
        ///     Tests that begin subplots should throw dll not found exception v 3
        /// </summary>
        [Fact]
        public void BeginSubplots_ShouldThrowDllNotFoundException_v3()
        {
            Vector2 size = new Vector2();
            float rowRatios = 1.0f;
            Assert.Throws<DllNotFoundException>(() => ImPlot.BeginSubplots("titleId", 1, 1, size, ImPlotSubplotFlags.None, ref rowRatios));
        }
        
        /// <summary>
        ///     Tests that begin subplots should throw dll not found exception v 4
        /// </summary>
        [Fact]
        public void BeginSubplots_ShouldThrowDllNotFoundException_v4()
        {
            Vector2 size = new Vector2();
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
            Vector2 size = new Vector2();
            Assert.Throws<DllNotFoundException>(() => ImPlot.ColormapButton("label", size));
        }
        
        /// <summary>
        ///     Tests that colormap button should throw dll not found exception v 3
        /// </summary>
        [Fact]
        public void ColormapButton_ShouldThrowDllNotFoundException_v3()
        {
            Vector2 size = new Vector2();
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
            Vector2 size = new Vector2();
            Assert.Throws<DllNotFoundException>(() => ImPlot.ColormapScale("label", 0.0, 1.0, size));
        }
        
        /// <summary>
        ///     Tests that colormap scale should throw dll not found exception v 3
        /// </summary>
        [Fact]
        public void ColormapScale_ShouldThrowDllNotFoundException_v3()
        {
            Vector2 size = new Vector2();
            Assert.Throws<DllNotFoundException>(() => ImPlot.ColormapScale("label", 0.0, 1.0, size, "format"));
        }
        
        /// <summary>
        ///     Tests that colormap scale should throw dll not found exception v 4
        /// </summary>
        [Fact]
        public void ColormapScale_ShouldThrowDllNotFoundException_v4()
        {
            Vector2 size = new Vector2();
            Assert.Throws<DllNotFoundException>(() => ImPlot.ColormapScale("label", 0.0, 1.0, size, "format", ImPlotColormapScaleFlags.None));
        }
        
        /// <summary>
        ///     Tests that colormap scale should throw dll not found exception v 5
        /// </summary>
        [Fact]
        public void ColormapScale_ShouldThrowDllNotFoundException_v5()
        {
            Vector2 size = new Vector2();
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
            Assert.Throws<DllNotFoundException>(() => ImPlot.ColormapSlider("label", ref t, out Vector4 _));
        }
        
        /// <summary>
        ///     Tests that colormap slider should throw dll not found exception v 3
        /// </summary>
        [Fact]
        public void ColormapSlider_ShouldThrowDllNotFoundException_v3()
        {
            float t = 0.0f;
            Assert.Throws<DllNotFoundException>(() => ImPlot.ColormapSlider("label", ref t, out Vector4 _, "format"));
        }
        
        /// <summary>
        ///     Tests that colormap slider should throw dll not found exception v 4
        /// </summary>
        [Fact]
        public void ColormapSlider_ShouldThrowDllNotFoundException_v4()
        {
            float t = 0.0f;
            Assert.Throws<DllNotFoundException>(() => ImPlot.ColormapSlider("label", ref t, out Vector4 _, "format", (ImPlotColormap) (-1)));
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
            Vector4 col = new Vector4();
            Assert.Throws<DllNotFoundException>(() => ImPlot.DragLineX(1, ref x, col));
        }
        
        /// <summary>
        ///     Tests that drag line x should throw dll not found exception v 2
        /// </summary>
        [Fact]
        public void DragLineX_ShouldThrowDllNotFoundException_v2()
        {
            double x = 0.0;
            Vector4 col = new Vector4();
            Assert.Throws<DllNotFoundException>(() => ImPlot.DragLineX(1, ref x, col, 1.0f));
        }
        
        /// <summary>
        ///     Tests that drag line x should throw dll not found exception v 3
        /// </summary>
        [Fact]
        public void DragLineX_ShouldThrowDllNotFoundException_v3()
        {
            double x = 0.0;
            Vector4 col = new Vector4();
            Assert.Throws<DllNotFoundException>(() => ImPlot.DragLineX(1, ref x, col, 1.0f, ImPlotDragToolFlags.None));
        }
        
        /// <summary>
        ///     Tests that drag line y should throw dll not found exception v 1
        /// </summary>
        [Fact]
        public void DragLineY_ShouldThrowDllNotFoundException_v1()
        {
            double y = 0.0;
            Vector4 col = new Vector4();
            Assert.Throws<DllNotFoundException>(() => ImPlot.DragLineY(1, ref y, col));
        }
        
        /// <summary>
        ///     Tests that drag line y should throw dll not found exception v 2
        /// </summary>
        [Fact]
        public void DragLineY_ShouldThrowDllNotFoundException_v2()
        {
            double y = 0.0;
            Vector4 col = new Vector4();
            Assert.Throws<DllNotFoundException>(() => ImPlot.DragLineY(1, ref y, col, 1.0f));
        }
        
        /// <summary>
        ///     Tests that drag line y should throw dll not found exception v 3
        /// </summary>
        [Fact]
        public void DragLineY_ShouldThrowDllNotFoundException_v3()
        {
            double y = 0.0;
            Vector4 col = new Vector4();
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
            Vector4 col = new Vector4();
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
            Vector4 col = new Vector4();
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
            Vector4 col = new Vector4();
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
            Vector4 col = new Vector4();
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
            Vector4 col = new Vector4();
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
    }
}