// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImPlotP1RemainingCoverageTests.cs
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
using System.Runtime.InteropServices;
using Alis.Extension.Graphic.Ui.Extras.Plot;
using Alis.Core.Aspect.Math.Vector;
using Alis.Extension.Graphic.Ui.Test.Attributes;
using Xunit;

namespace Alis.Extension.Graphic.Ui.Test.Extras.Plot
{
    /// <summary>
    /// The ImPlotP1 remaining coverage tests class
    /// </summary>
    public class ImPlotP1RemainingCoverageTests
    {
        /// <summary>
        /// Tests that AddColormap throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void AddColormap_1_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 Vector4F cols = default;
                Assert.Throws<DllNotFoundException>(() => { ImPlot.AddColormap("label", ref cols, 0); });
            }
        }

        /// <summary>
        /// Tests that AddColormap throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void AddColormap_2_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 Vector4F cols = default;
                Assert.Throws<DllNotFoundException>(() => { ImPlot.AddColormap("label", ref cols, 0, false); });
            }
        }

        /// <summary>
        /// Tests that AddColormap throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void AddColormap_3_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 uint cols = default;
                Assert.Throws<DllNotFoundException>(() => { ImPlot.AddColormap("label", ref cols, 0); });
            }
        }

        /// <summary>
        /// Tests that AddColormap throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void AddColormap_4_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 uint cols = default;
                Assert.Throws<DllNotFoundException>(() => { ImPlot.AddColormap("label", ref cols, 0, false); });
            }
        }

        /// <summary>
        /// Tests that Annotation throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void Annotation_1_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.Annotation(0, 0, default(Vector4F), default(Vector2F), false); });
            }
        }

        /// <summary>
        /// Tests that Annotation throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void Annotation_2_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.Annotation(0, 0, default(Vector4F), default(Vector2F), false, false); });
            }
        }

        /// <summary>
        /// Tests that Annotation throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void Annotation_3_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.Annotation(0, 0, default(Vector4F), default(Vector2F), false, "label"); });
            }
        }

        /// <summary>
        /// Tests that BeginAlignedPlots throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void BeginAlignedPlots_1_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.BeginAlignedPlots("label"); });
            }
        }

        /// <summary>
        /// Tests that BeginAlignedPlots throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void BeginAlignedPlots_2_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.BeginAlignedPlots("label", false); });
            }
        }

        /// <summary>
        /// Tests that BeginDragDropSourceAxis throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void BeginDragDropSourceAxis_1_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.BeginDragDropSourceAxis((ImAxis)0); });
            }
        }

        /// <summary>
        /// Tests that BeginDragDropSourceAxis throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void BeginDragDropSourceAxis_2_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.BeginDragDropSourceAxis((ImAxis)0, (Alis.Extension.Graphic.Ui.Extras.Plot.ImGuiDragDropFlags)0); });
            }
        }

        /// <summary>
        /// Tests that BeginDragDropSourceItem throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void BeginDragDropSourceItem_1_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.BeginDragDropSourceItem("label"); });
            }
        }

        /// <summary>
        /// Tests that BeginDragDropSourceItem throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void BeginDragDropSourceItem_2_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.BeginDragDropSourceItem("label", (Alis.Extension.Graphic.Ui.Extras.Plot.ImGuiDragDropFlags)0); });
            }
        }

        /// <summary>
        /// Tests that BeginDragDropSourcePlot throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void BeginDragDropSourcePlot_1_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.BeginDragDropSourcePlot(); });
            }
        }

        /// <summary>
        /// Tests that BeginDragDropSourcePlot throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void BeginDragDropSourcePlot_2_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.BeginDragDropSourcePlot((Alis.Extension.Graphic.Ui.Extras.Plot.ImGuiDragDropFlags)0); });
            }
        }

        /// <summary>
        /// Tests that BeginDragDropTargetAxis throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void BeginDragDropTargetAxis_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.BeginDragDropTargetAxis((ImAxis)0); });
            }
        }

        /// <summary>
        /// Tests that BeginDragDropTargetLegend throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void BeginDragDropTargetLegend_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.BeginDragDropTargetLegend(); });
            }
        }

        /// <summary>
        /// Tests that BeginDragDropTargetPlot throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void BeginDragDropTargetPlot_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.BeginDragDropTargetPlot(); });
            }
        }

        /// <summary>
        /// Tests that BeginLegendPopup throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void BeginLegendPopup_1_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.BeginLegendPopup("label"); });
            }
        }

        /// <summary>
        /// Tests that BeginLegendPopup throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void BeginLegendPopup_2_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.BeginLegendPopup("label", (ImGuiMouseButton)0); });
            }
        }

        /// <summary>
        /// Tests that BeginPlot throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void BeginPlot_1_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.BeginPlot("label"); });
            }
        }

        /// <summary>
        /// Tests that BeginPlot throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void BeginPlot_2_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.BeginPlot("label", default(Vector2F)); });
            }
        }

        /// <summary>
        /// Tests that BeginPlot throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void BeginPlot_3_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.BeginPlot("label", default(Vector2F), (ImPlotFlags)0); });
            }
        }

        /// <summary>
        /// Tests that BeginSubplots throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void BeginSubplots_1_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.BeginSubplots("label", 0, 0, default(Vector2F)); });
            }
        }

        /// <summary>
        /// Tests that BeginSubplots throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void BeginSubplots_2_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.BeginSubplots("label", 0, 0, default(Vector2F), (ImPlotSubplotFlags)0); });
            }
        }

        /// <summary>
        /// Tests that BeginSubplots throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void BeginSubplots_3_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 float rowRatios = default;
                Assert.Throws<DllNotFoundException>(() => { ImPlot.BeginSubplots("label", 0, 0, default(Vector2F), (ImPlotSubplotFlags)0, ref rowRatios); });
            }
        }

        /// <summary>
        /// Tests that BeginSubplots throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void BeginSubplots_4_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 float rowRatios = default; float colRatios = default;
                Assert.Throws<DllNotFoundException>(() => { ImPlot.BeginSubplots("label", 0, 0, default(Vector2F), (ImPlotSubplotFlags)0, ref rowRatios, ref colRatios); });
            }
        }

        /// <summary>
        /// Tests that BustColorCache throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void BustColorCache_1_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.BustColorCache(); });
            }
        }

        /// <summary>
        /// Tests that BustColorCache throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void BustColorCache_2_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.BustColorCache("label"); });
            }
        }

        /// <summary>
        /// Tests that CancelPlotSelection throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void CancelPlotSelection_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.CancelPlotSelection(); });
            }
        }

        /// <summary>
        /// Tests that ColormapButton throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void ColormapButton_1_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.ColormapButton("label"); });
            }
        }

        /// <summary>
        /// Tests that ColormapButton throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void ColormapButton_2_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.ColormapButton("label", default(Vector2F)); });
            }
        }

        /// <summary>
        /// Tests that ColormapButton throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void ColormapButton_3_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.ColormapButton("label", default(Vector2F), (ImPlotColormap)0); });
            }
        }

        /// <summary>
        /// Tests that ColormapIcon throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void ColormapIcon_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.ColormapIcon((ImPlotColormap)0); });
            }
        }

        /// <summary>
        /// Tests that ColormapScale throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void ColormapScale_1_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.ColormapScale("label", 0, 0); });
            }
        }

        /// <summary>
        /// Tests that ColormapScale throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void ColormapScale_2_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.ColormapScale("label", 0, 0, default(Vector2F)); });
            }
        }

        /// <summary>
        /// Tests that ColormapScale throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void ColormapScale_3_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.ColormapScale("label", 0, 0, default(Vector2F), "label"); });
            }
        }

        /// <summary>
        /// Tests that ColormapScale throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void ColormapScale_4_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.ColormapScale("label", 0, 0, default(Vector2F), "label", (ImPlotColormapScaleFlags)0); });
            }
        }

        /// <summary>
        /// Tests that ColormapScale throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void ColormapScale_5_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.ColormapScale("label", 0, 0, default(Vector2F), "label", (ImPlotColormapScaleFlags)0, (ImPlotColormap)0); });
            }
        }

        /// <summary>
        /// Tests that ColormapSlider throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void ColormapSlider_1_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 float t = default;
                Assert.Throws<DllNotFoundException>(() => { ImPlot.ColormapSlider("label", ref t); });
            }
        }

        /// <summary>
        /// Tests that ColormapSlider throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void ColormapSlider_2_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 float t = default; Vector4F @out = default;
                Assert.Throws<DllNotFoundException>(() => { ImPlot.ColormapSlider("label", ref t, out @out); });
            }
        }

        /// <summary>
        /// Tests that ColormapSlider throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void ColormapSlider_3_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 float t = default; Vector4F @out = default;
                Assert.Throws<DllNotFoundException>(() => { ImPlot.ColormapSlider("label", ref t, out @out, "label"); });
            }
        }

        /// <summary>
        /// Tests that ColormapSlider throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void ColormapSlider_4_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 float t = default; Vector4F @out = default;
                Assert.Throws<DllNotFoundException>(() => { ImPlot.ColormapSlider("label", ref t, out @out, "label", (ImPlotColormap)0); });
            }
        }

        /// <summary>
        /// Tests that CreateContext throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void CreateContext_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.CreateContext(); });
            }
        }

        /// <summary>
        /// Tests that DestroyContext throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void DestroyContext_1_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.DestroyContext(); });
            }
        }

        /// <summary>
        /// Tests that DestroyContext throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void DestroyContext_2_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.DestroyContext(IntPtr.Zero); });
            }
        }

        /// <summary>
        /// Tests that DragLineX throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void DragLineX_1_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 double x = default;
                Assert.Throws<DllNotFoundException>(() => { ImPlot.DragLineX(0, ref x, default(Vector4F)); });
            }
        }

        /// <summary>
        /// Tests that DragLineX throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void DragLineX_2_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 double x = default;
                Assert.Throws<DllNotFoundException>(() => { ImPlot.DragLineX(0, ref x, default(Vector4F), 0); });
            }
        }

        /// <summary>
        /// Tests that DragLineX throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void DragLineX_3_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 double x = default;
                Assert.Throws<DllNotFoundException>(() => { ImPlot.DragLineX(0, ref x, default(Vector4F), 0, (ImPlotDragToolFlags)0); });
            }
        }

        /// <summary>
        /// Tests that DragLineY throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void DragLineY_1_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 double y = default;
                Assert.Throws<DllNotFoundException>(() => { ImPlot.DragLineY(0, ref y, default(Vector4F)); });
            }
        }

        /// <summary>
        /// Tests that DragLineY throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void DragLineY_2_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 double y = default;
                Assert.Throws<DllNotFoundException>(() => { ImPlot.DragLineY(0, ref y, default(Vector4F), 0); });
            }
        }

        /// <summary>
        /// Tests that DragLineY throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void DragLineY_3_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 double y = default;
                Assert.Throws<DllNotFoundException>(() => { ImPlot.DragLineY(0, ref y, default(Vector4F), 0, (ImPlotDragToolFlags)0); });
            }
        }

        /// <summary>
        /// Tests that DragPoint throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void DragPoint_1_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 double x = default; double y = default;
                Assert.Throws<DllNotFoundException>(() => { ImPlot.DragPoint(0, ref x, ref y, default(Vector4F)); });
            }
        }

        /// <summary>
        /// Tests that DragPoint throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void DragPoint_2_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 double x = default; double y = default;
                Assert.Throws<DllNotFoundException>(() => { ImPlot.DragPoint(0, ref x, ref y, default(Vector4F), 0); });
            }
        }

        /// <summary>
        /// Tests that DragPoint throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void DragPoint_3_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 double x = default; double y = default;
                Assert.Throws<DllNotFoundException>(() => { ImPlot.DragPoint(0, ref x, ref y, default(Vector4F), 0, (ImPlotDragToolFlags)0); });
            }
        }

        /// <summary>
        /// Tests that DragRect throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void DragRect_1_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 double x1 = default; double y1 = default; double x2 = default; double y2 = default;
                Assert.Throws<DllNotFoundException>(() => { ImPlot.DragRect(0, ref x1, ref y1, ref x2, ref y2, default(Vector4F)); });
            }
        }

        /// <summary>
        /// Tests that DragRect throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void DragRect_2_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 double x1 = default; double y1 = default; double x2 = default; double y2 = default;
                Assert.Throws<DllNotFoundException>(() => { ImPlot.DragRect(0, ref x1, ref y1, ref x2, ref y2, default(Vector4F), (ImPlotDragToolFlags)0); });
            }
        }

        /// <summary>
        /// Tests that EndAlignedPlots throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void EndAlignedPlots_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.EndAlignedPlots(); });
            }
        }

        /// <summary>
        /// Tests that EndDragDropSource throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void EndDragDropSource_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.EndDragDropSource(); });
            }
        }
        /// <summary>
        /// Determines whether the cimgui native library can be loaded
        /// </summary>
        /// <returns>True if the library can be loaded</returns>
        private static bool CanLoadCImguiLibrary()
        {
            if (NativeLibrary.TryLoad("cimgui", out _))
            {
                return true;
            }

            string assemblyDir = System.IO.Path.GetDirectoryName(typeof(ImPlotP1RemainingCoverageTests).Assembly.Location);
            if (assemblyDir == null)
            {
                return false;
            }

            string[] candidates = new[]
            {
                System.IO.Path.Combine(assemblyDir, "cimgui"),
                System.IO.Path.Combine(assemblyDir, "libcimgui"),
                System.IO.Path.Combine(assemblyDir, "libcimgui.dylib")
            };

            foreach (string candidate in candidates)
            {
                if (System.IO.File.Exists(candidate) && NativeLibrary.TryLoad(candidate, out _))
                {
                    return true;
                }
            }

            return false;
        }
    }
}
