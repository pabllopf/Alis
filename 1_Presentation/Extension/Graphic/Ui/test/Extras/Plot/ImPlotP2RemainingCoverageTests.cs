// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImPlotP2RemainingCoverageTests.cs
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
    /// The ImPlotP2 remaining coverage tests class
    /// </summary>
    public class ImPlotP2RemainingCoverageTests
    {
        /// <summary>
        /// Tests that EndDragDropTarget throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void EndDragDropTarget_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.EndDragDropTarget(); });
            }
        }

        /// <summary>
        /// Tests that EndLegendPopup throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void EndLegendPopup_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.EndLegendPopup(); });
            }
        }

        /// <summary>
        /// Tests that EndPlot throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void EndPlot_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.EndPlot(); });
            }
        }

        /// <summary>
        /// Tests that EndSubplots throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void EndSubplots_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.EndSubplots(); });
            }
        }

        /// <summary>
        /// Tests that GetColormapColor throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void GetColormapColor_1_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.GetColormapColor(0); });
            }
        }

        /// <summary>
        /// Tests that GetColormapColor throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void GetColormapColor_2_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.GetColormapColor(0, (ImPlotColormap)0); });
            }
        }

        /// <summary>
        /// Tests that GetColormapCount throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void GetColormapCount_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.GetColormapCount(); });
            }
        }

        /// <summary>
        /// Tests that GetColormapIndex throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void GetColormapIndex_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.GetColormapIndex("label"); });
            }
        }

        /// <summary>
        /// Tests that GetColormapName throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void GetColormapName_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.GetColormapName((ImPlotColormap)0); });
            }
        }

        /// <summary>
        /// Tests that GetColormapSize throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void GetColormapSize_1_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.GetColormapSize(); });
            }
        }

        /// <summary>
        /// Tests that GetColormapSize throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void GetColormapSize_2_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.GetColormapSize((ImPlotColormap)0); });
            }
        }

        /// <summary>
        /// Tests that GetCurrentContext throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void GetCurrentContext_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.GetCurrentContext(); });
            }
        }

        /// <summary>
        /// Tests that GetInputMap throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void GetInputMap_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.GetInputMap(); });
            }
        }

        /// <summary>
        /// Tests that GetLastItemColor throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void GetLastItemColor_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.GetLastItemColor(); });
            }
        }

        /// <summary>
        /// Tests that GetMarkerName throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void GetMarkerName_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.GetMarkerName((ImPlotMarker)0); });
            }
        }

        /// <summary>
        /// Tests that GetPlotDrawList throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void GetPlotDrawList_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.GetPlotDrawList(); });
            }
        }

        /// <summary>
        /// Tests that GetPlotLimits throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void GetPlotLimits_1_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.GetPlotLimits(); });
            }
        }

        /// <summary>
        /// Tests that GetPlotLimits throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void GetPlotLimits_2_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.GetPlotLimits((ImAxis)0); });
            }
        }

        /// <summary>
        /// Tests that GetPlotLimits throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void GetPlotLimits_3_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.GetPlotLimits((ImAxis)0, (ImAxis)0); });
            }
        }

        /// <summary>
        /// Tests that GetPlotMousePos throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void GetPlotMousePos_1_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.GetPlotMousePos(); });
            }
        }

        /// <summary>
        /// Tests that GetPlotMousePos throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void GetPlotMousePos_2_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.GetPlotMousePos((ImAxis)0); });
            }
        }

        /// <summary>
        /// Tests that GetPlotMousePos throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void GetPlotMousePos_3_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.GetPlotMousePos((ImAxis)0, (ImAxis)0); });
            }
        }

        /// <summary>
        /// Tests that GetPlotPos throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void GetPlotPos_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.GetPlotPos(); });
            }
        }

        /// <summary>
        /// Tests that GetPlotSelection throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void GetPlotSelection_1_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.GetPlotSelection(); });
            }
        }

        /// <summary>
        /// Tests that GetPlotSelection throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void GetPlotSelection_2_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.GetPlotSelection((ImAxis)0); });
            }
        }

        /// <summary>
        /// Tests that GetPlotSelection throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void GetPlotSelection_3_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.GetPlotSelection((ImAxis)0, (ImAxis)0); });
            }
        }

        /// <summary>
        /// Tests that GetPlotSize throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void GetPlotSize_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.GetPlotSize(); });
            }
        }

        /// <summary>
        /// Tests that GetStyle throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void GetStyle_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.GetStyle(); });
            }
        }

        /// <summary>
        /// Tests that GetStyleColorName throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void GetStyleColorName_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.GetStyleColorName((ImPlotCol)0); });
            }
        }

        /// <summary>
        /// Tests that HideNextItem throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void HideNextItem_1_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.HideNextItem(); });
            }
        }

        /// <summary>
        /// Tests that HideNextItem throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void HideNextItem_2_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.HideNextItem(false); });
            }
        }

        /// <summary>
        /// Tests that HideNextItem throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void HideNextItem_3_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.HideNextItem(false, (ImPlotCond)0); });
            }
        }

        /// <summary>
        /// Tests that IsAxisHovered throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void IsAxisHovered_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.IsAxisHovered((ImAxis)0); });
            }
        }

        /// <summary>
        /// Tests that IsLegendEntryHovered throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void IsLegendEntryHovered_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.IsLegendEntryHovered("label"); });
            }
        }

        /// <summary>
        /// Tests that IsPlotHovered throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void IsPlotHovered_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.IsPlotHovered(); });
            }
        }

        /// <summary>
        /// Tests that IsPlotSelected throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void IsPlotSelected_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.IsPlotSelected(); });
            }
        }

        /// <summary>
        /// Tests that IsSubplotsHovered throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void IsSubplotsHovered_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.IsSubplotsHovered(); });
            }
        }

        /// <summary>
        /// Tests that ItemIcon throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void ItemIcon_1_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.ItemIcon(default(Vector4F)); });
            }
        }

        /// <summary>
        /// Tests that ItemIcon throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void ItemIcon_2_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.ItemIcon(0); });
            }
        }

        /// <summary>
        /// Tests that MapInputDefault throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void MapInputDefault_1_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.MapInputDefault(); });
            }
        }

        /// <summary>
        /// Tests that MapInputDefault throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void MapInputDefault_2_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.MapInputDefault(default(ImPlotInputMap)); });
            }
        }

        /// <summary>
        /// Tests that MapInputReverse throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void MapInputReverse_1_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.MapInputReverse(); });
            }
        }

        /// <summary>
        /// Tests that MapInputReverse throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void MapInputReverse_2_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.MapInputReverse(default(ImPlotInputMap)); });
            }
        }

        /// <summary>
        /// Tests that NextColormapColor throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void NextColormapColor_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.NextColormapColor(); });
            }
        }

        /// <summary>
        /// Tests that PixelsToPlot throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void PixelsToPlot_1_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PixelsToPlot(default(Vector2F)); });
            }
        }

        /// <summary>
        /// Tests that PixelsToPlot throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void PixelsToPlot_2_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PixelsToPlot(default(Vector2F), (ImAxis)0); });
            }
        }

        /// <summary>
        /// Tests that PixelsToPlot throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void PixelsToPlot_3_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PixelsToPlot(default(Vector2F), (ImAxis)0, (ImAxis)0); });
            }
        }

        /// <summary>
        /// Tests that PixelsToPlot throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void PixelsToPlot_4_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PixelsToPlot(0, 0); });
            }
        }

        /// <summary>
        /// Tests that PixelsToPlot throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void PixelsToPlot_5_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PixelsToPlot(0, 0, (ImAxis)0); });
            }
        }

        /// <summary>
        /// Tests that PixelsToPlot throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void PixelsToPlot_6_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PixelsToPlot(0, 0, (ImAxis)0, (ImAxis)0); });
            }
        }

        /// <summary>
        /// Tests that PlotBarGroups throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotBarGroups_1_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotBarGroups(default(string[]), default(float[]), 0, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotBarGroups throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotBarGroups_2_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotBarGroups(default(string[]), default(float[]), 0, 0, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotBarGroups throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotBarGroups_3_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotBarGroups(default(string[]), default(float[]), 0, 0, 0, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotBarGroups throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotBarGroups_4_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotBarGroups(default(string[]), default(float[]), 0, 0, 0, 0, (ImPlotBarGroupsFlags)0); });
            }
        }

        /// <summary>
        /// Tests that PlotBarGroups throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotBarGroups_5_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotBarGroups(default(string[]), default(double[]), 0, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotBarGroups throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotBarGroups_6_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotBarGroups(default(string[]), default(double[]), 0, 0, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotBarGroups throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotBarGroups_7_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotBarGroups(default(string[]), default(double[]), 0, 0, 0, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotBarGroups throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotBarGroups_8_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotBarGroups(default(string[]), default(double[]), 0, 0, 0, 0, (ImPlotBarGroupsFlags)0); });
            }
        }

        /// <summary>
        /// Tests that PlotBarGroups throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotBarGroups_9_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotBarGroups(default(string[]), default(sbyte[]), 0, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotBarGroups throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotBarGroups_10_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotBarGroups(default(string[]), default(sbyte[]), 0, 0, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotBarGroups throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotBarGroups_11_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotBarGroups(default(string[]), default(sbyte[]), 0, 0, 0, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotBarGroups throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotBarGroups_12_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotBarGroups(default(string[]), default(sbyte[]), 0, 0, 0, 0, (ImPlotBarGroupsFlags)0); });
            }
        }

        /// <summary>
        /// Tests that PlotBarGroups throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotBarGroups_13_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotBarGroups(default(string[]), default(byte[]), 0, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotBarGroups throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotBarGroups_14_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotBarGroups(default(string[]), default(byte[]), 0, 0, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotBarGroups throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotBarGroups_15_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotBarGroups(default(string[]), default(byte[]), 0, 0, 0, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotBarGroups throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotBarGroups_16_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotBarGroups(default(string[]), default(byte[]), 0, 0, 0, 0, (ImPlotBarGroupsFlags)0); });
            }
        }

        /// <summary>
        /// Tests that PlotBarGroups throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotBarGroups_17_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotBarGroups(default(string[]), default(short[]), 0, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotBarGroups throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotBarGroups_18_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotBarGroups(default(string[]), default(short[]), 0, 0, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotBarGroups throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotBarGroups_19_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotBarGroups(default(string[]), default(short[]), 0, 0, 0, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotBarGroups throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotBarGroups_20_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotBarGroups(default(string[]), default(short[]), 0, 0, 0, 0, (ImPlotBarGroupsFlags)0); });
            }
        }

        /// <summary>
        /// Tests that PlotBarGroups throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotBarGroups_21_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotBarGroups(default(string[]), default(ushort[]), 0, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotBarGroups throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotBarGroups_22_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotBarGroups(default(string[]), default(ushort[]), 0, 0, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotBarGroups throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotBarGroups_23_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotBarGroups(default(string[]), default(ushort[]), 0, 0, 0, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotBarGroups throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotBarGroups_24_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotBarGroups(default(string[]), default(ushort[]), 0, 0, 0, 0, (ImPlotBarGroupsFlags)0); });
            }
        }

        /// <summary>
        /// Tests that PlotBarGroups throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotBarGroups_25_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotBarGroups(default(string[]), default(int[]), 0, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotBarGroups throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotBarGroups_26_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotBarGroups(default(string[]), default(int[]), 0, 0, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotBarGroups throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotBarGroups_27_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotBarGroups(default(string[]), default(int[]), 0, 0, 0, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotBarGroups throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotBarGroups_28_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotBarGroups(default(string[]), default(int[]), 0, 0, 0, 0, (ImPlotBarGroupsFlags)0); });
            }
        }

        /// <summary>
        /// Tests that PlotBarGroups throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotBarGroups_29_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotBarGroups(default(string[]), default(uint[]), 0, 0); });
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

            string assemblyDir = System.IO.Path.GetDirectoryName(typeof(ImPlotP2RemainingCoverageTests).Assembly.Location);
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
