// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImPlotTestP2.cs
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
using Alis.Core.Aspect.Math.Vector;
using Alis.Extension.Graphic.ImGui.Extras.Plot;
using Alis.Extension.Graphic.ImGui.Extras.Plot.Native;
using Xunit;

namespace Alis.Extension.Graphic.ImGui.Test.Extras.Plot.Native
{
    /// <summary>
    ///     The im plot test class
    /// </summary>
    public class ImPlotTestP2
    {
        /// <summary>
        ///     Tests that get plot limits throws dll not found exception
        /// </summary>
        [Fact]
        public void GetPlotLimits_ThrowsMarshalDirectiveException()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.GetPlotLimits(0, 0));
        }
        
        /// <summary>
        ///     Tests that get plot mouse pos throws dll not found exception
        /// </summary>
        [Fact]
        public void GetPlotMousePos_ThrowsMarshalDirectiveException()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.GetPlotMousePos());
        }
        
        /// <summary>
        ///     Tests that get plot mouse pos with x axis throws dll not found exception
        /// </summary>
        [Fact]
        public void GetPlotMousePos_WithXAxis_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.GetPlotMousePos(0));
        }
        
        /// <summary>
        ///     Tests that get plot mouse pos with x axis and y axis throws dll not found exception
        /// </summary>
        [Fact]
        public void GetPlotMousePos_WithXAxisAndYAxis_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.GetPlotMousePos(0, 0));
        }
        
        /// <summary>
        ///     Tests that get plot pos throws dll not found exception
        /// </summary>
        [Fact]
        public void GetPlotPos_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.GetPlotPos());
        }
        
        /// <summary>
        ///     Tests that get plot selection throws dll not found exception
        /// </summary>
        [Fact]
        public void GetPlotSelection_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.GetPlotSelection());
        }
        
        /// <summary>
        ///     Tests that get plot selection with x axis throws dll not found exception
        /// </summary>
        [Fact]
        public void GetPlotSelection_WithXAxis_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.GetPlotSelection(0));
        }
        
        /// <summary>
        ///     Tests that get plot selection with x axis and y axis throws dll not found exception
        /// </summary>
        [Fact]
        public void GetPlotSelection_WithXAxisAndYAxis_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.GetPlotSelection(0, 0));
        }
        
        /// <summary>
        ///     Tests that get plot size throws dll not found exception
        /// </summary>
        [Fact]
        public void GetPlotSize_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.GetPlotSize());
        }
        
        /// <summary>
        ///     Tests that get style throws dll not found exception
        /// </summary>
        [Fact]
        public void GetStyle_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.GetStyle());
        }
        
        /// <summary>
        ///     Tests that get style color name throws dll not found exception
        /// </summary>
        [Fact]
        public void GetStyleColorName_ThrowsMarshalDirectiveException()
        {
            Assert.Throws<MarshalDirectiveException>(() => ImPlot.GetStyleColorName(0));
        }
        
        /// <summary>
        ///     Tests that hide next item throws dll not found exception
        /// </summary>
        [Fact]
        public void HideNextItem_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.HideNextItem());
        }
        
        /// <summary>
        ///     Tests that hide next item with hidden throws dll not found exception
        /// </summary>
        [Fact]
        public void HideNextItem_WithHidden_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.HideNextItem(true));
        }
        
        /// <summary>
        ///     Tests that hide next item with hidden and cond throws dll not found exception
        /// </summary>
        [Fact]
        public void HideNextItem_WithHiddenAndCond_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.HideNextItem(true, ImPlotCond.Once));
        }
        
        /// <summary>
        ///     Tests that is axis hovered throws dll not found exception
        /// </summary>
        [Fact]
        public void IsAxisHovered_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.IsAxisHovered(0));
        }
        
        /// <summary>
        ///     Tests that is legend entry hovered throws dll not found exception
        /// </summary>
        [Fact]
        public void IsLegendEntryHovered_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.IsLegendEntryHovered("label"));
        }
        
        /// <summary>
        ///     Tests that is plot hovered throws dll not found exception
        /// </summary>
        [Fact]
        public void IsPlotHovered_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.IsPlotHovered());
        }
        
        /// <summary>
        ///     Tests that is plot selected throws dll not found exception
        /// </summary>
        [Fact]
        public void IsPlotSelected_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.IsPlotSelected());
        }
        
        /// <summary>
        ///     Tests that is subplots hovered throws dll not found exception
        /// </summary>
        [Fact]
        public void IsSubplotsHovered_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.IsSubplotsHovered());
        }
        
        /// <summary>
        ///     Tests that item icon with vector 4 throws dll not found exception
        /// </summary>
        [Fact]
        public void ItemIcon_WithVector4_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.ItemIcon(new Vector4()));
        }
        
        /// <summary>
        ///     Tests that item icon with u int throws dll not found exception
        /// </summary>
        [Fact]
        public void ItemIcon_WithUInt_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.ItemIcon(0u));
        }
        
        /// <summary>
        ///     Tests that map input default throws dll not found exception
        /// </summary>
        [Fact]
        public void MapInputDefault_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.MapInputDefault());
        }
        
        /// <summary>
        ///     Tests that map input default with dst throws dll not found exception
        /// </summary>
        [Fact]
        public void MapInputDefault_WithDst_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.MapInputDefault(new ImPlotInputMap()));
        }
        
        /// <summary>
        ///     Tests that map input reverse throws dll not found exception
        /// </summary>
        [Fact]
        public void MapInputReverse_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.MapInputReverse());
        }
        
        /// <summary>
        ///     Tests that map input reverse with dst throws dll not found exception
        /// </summary>
        [Fact]
        public void MapInputReverse_WithDst_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.MapInputReverse(new ImPlotInputMap()));
        }
        
        /// <summary>
        ///     Tests that next colormap color throws dll not found exception
        /// </summary>
        [Fact]
        public void NextColormapColor_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.NextColormapColor());
        }
        
        /// <summary>
        ///     Tests that pixels to plot with vector 2 throws dll not found exception
        /// </summary>
        [Fact]
        public void PixelsToPlot_WithVector2_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PixelsToPlot(new Vector2()));
        }
        
        /// <summary>
        ///     Tests that pixels to plot with vector 2 and x axis throws dll not found exception
        /// </summary>
        [Fact]
        public void PixelsToPlot_WithVector2AndXAxis_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PixelsToPlot(new Vector2(), 0));
        }
        
        /// <summary>
        ///     Tests that pixels to plot with vector 2 x axis and y axis throws dll not found exception
        /// </summary>
        [Fact]
        public void PixelsToPlot_WithVector2XAxisAndYAxis_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PixelsToPlot(new Vector2(), 0, 0));
        }
        
        /// <summary>
        ///     Tests that pixels to plot with float throws dll not found exception
        /// </summary>
        [Fact]
        public void PixelsToPlot_WithFloat_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PixelsToPlot(0f, 0f));
        }
        
        /// <summary>
        ///     Tests that pixels to plot with float and x axis throws dll not found exception
        /// </summary>
        [Fact]
        public void PixelsToPlot_WithFloatAndXAxis_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PixelsToPlot(0f, 0f, 0));
        }
        
        /// <summary>
        ///     Tests that pixels to plot with float x axis and y axis throws dll not found exception
        /// </summary>
        [Fact]
        public void PixelsToPlot_WithFloatXAxisAndYAxis_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PixelsToPlot(0f, 0f, 0, 0));
        }
        
        /// <summary>
        ///     Tests that plot bar groups with float throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotBarGroups_WithFloat_ThrowsMarshalDirectiveException()
        {
            Assert.Throws<MarshalDirectiveException>(() => ImPlot.PlotBarGroups(new string[0], new float[0], 0, 0));
        }
        
        /// <summary>
        ///     Tests that plot bar groups with float and group size throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotBarGroups_WithFloatAndGroupSize_ThrowsMarshalDirectiveException()
        {
            Assert.Throws<MarshalDirectiveException>(() => ImPlot.PlotBarGroups(new string[0], new float[0], 0, 0, 0.67));
        }
        
        /// <summary>
        ///     Tests that plot bar groups with float group size and shift throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotBarGroups_WithFloatGroupSizeAndShift_ThrowsMarshalDirectiveException()
        {
            Assert.Throws<MarshalDirectiveException>(() => ImPlot.PlotBarGroups(new string[0], new float[0], 0, 0, 0.67, 0));
        }
        
        /// <summary>
        ///     Tests that plot bar groups with float group size shift and flags throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotBarGroups_WithFloatGroupSizeShiftAndFlags_ThrowsMarshalDirectiveException()
        {
            Assert.Throws<MarshalDirectiveException>(() => ImPlot.PlotBarGroups(new string[0], new float[0], 0, 0, 0.67, 0, ImPlotBarGroupsFlags.None));
        }
        
        /// <summary>
        ///     Tests that plot bar groups with double throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotBarGroups_WithDouble_ThrowsMarshalDirectiveException()
        {
            Assert.Throws<MarshalDirectiveException>(() => ImPlot.PlotBarGroups(new string[0], new double[0], 0, 0));
        }
        
        /// <summary>
        ///     Tests that plot bar groups with double and group size throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotBarGroups_WithDoubleAndGroupSize_ThrowsMarshalDirectiveException()
        {
            Assert.Throws<MarshalDirectiveException>(() => ImPlot.PlotBarGroups(new string[0], new double[0], 0, 0, 0.67));
        }
        
        /// <summary>
        ///     Tests that plot bar groups with double group size and shift throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotBarGroups_WithDoubleGroupSizeAndShift_ThrowsMarshalDirectiveException()
        {
            Assert.Throws<MarshalDirectiveException>(() => ImPlot.PlotBarGroups(new string[0], new double[0], 0, 0, 0.67, 0));
        }
        
        /// <summary>
        ///     Tests that plot bar groups with double group size shift and flags throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotBarGroups_WithDoubleGroupSizeShiftAndFlags_ThrowsMarshalDirectiveException()
        {
            Assert.Throws<MarshalDirectiveException>(() => ImPlot.PlotBarGroups(new string[0], new double[0], 0, 0, 0.67, 0, ImPlotBarGroupsFlags.None));
        }
        
        /// <summary>
        ///     Tests that plot bar groups with s byte throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotBarGroups_WithSByte_ThrowsMarshalDirectiveException()
        {
            Assert.Throws<MarshalDirectiveException>(() => ImPlot.PlotBarGroups(new string[0], new sbyte[0], 0, 0));
        }
        
        /// <summary>
        ///     Tests that plot bar groups with s byte and group size throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotBarGroups_WithSByteAndGroupSize_ThrowsMarshalDirectiveException()
        {
            Assert.Throws<MarshalDirectiveException>(() => ImPlot.PlotBarGroups(new string[0], new sbyte[0], 0, 0, 0.67));
        }
        
        /// <summary>
        ///     Tests that plot bar groups with s byte group size and shift throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotBarGroups_WithSByteGroupSizeAndShift_ThrowsMarshalDirectiveException()
        {
            Assert.Throws<MarshalDirectiveException>(() => ImPlot.PlotBarGroups(new string[0], new sbyte[0], 0, 0, 0.67, 0));
        }
        
        /// <summary>
        ///     Tests that plot bar groups with s byte group size shift and flags throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotBarGroups_WithSByteGroupSizeShiftAndFlags_ThrowsMarshalDirectiveException()
        {
            Assert.Throws<MarshalDirectiveException>(() => ImPlot.PlotBarGroups(new string[0], new sbyte[0], 0, 0, 0.67, 0, ImPlotBarGroupsFlags.None));
        }
        
        /// <summary>
        ///     Tests that plot bar groups with byte throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotBarGroups_WithByte_ThrowsMarshalDirectiveException()
        {
            Assert.Throws<MarshalDirectiveException>(() => ImPlot.PlotBarGroups(new string[0], new byte[0], 0, 0));
        }
        
        /// <summary>
        ///     Tests that plot bar groups with byte and group size throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotBarGroups_WithByteAndGroupSize_ThrowsMarshalDirectiveException()
        {
            Assert.Throws<MarshalDirectiveException>(() => ImPlot.PlotBarGroups(new string[0], new byte[0], 0, 0, 0.67));
        }
        
        /// <summary>
        ///     Tests that plot bar groups with byte group size and shift throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotBarGroups_WithByteGroupSizeAndShift_ThrowsMarshalDirectiveException()
        {
            Assert.Throws<MarshalDirectiveException>(() => ImPlot.PlotBarGroups(new string[0], new byte[0], 0, 0, 0.67, 0));
        }
        
        /// <summary>
        ///     Tests that plot bar groups with byte group size shift and flags throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotBarGroups_WithByteGroupSizeShiftAndFlags_ThrowsMarshalDirectiveException()
        {
            Assert.Throws<MarshalDirectiveException>(() => ImPlot.PlotBarGroups(new string[0], new byte[0], 0, 0, 0.67, 0, ImPlotBarGroupsFlags.None));
        }
        
        /// <summary>
        ///     Tests that plot bar groups with short throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotBarGroups_WithShort_ThrowsMarshalDirectiveException()
        {
            Assert.Throws<MarshalDirectiveException>(() => ImPlot.PlotBarGroups(new string[0], new short[0], 0, 0));
        }
        
        /// <summary>
        ///     Tests that plot bar groups with short and group size throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotBarGroups_WithShortAndGroupSize_ThrowsMarshalDirectiveException()
        {
            Assert.Throws<MarshalDirectiveException>(() => ImPlot.PlotBarGroups(new string[0], new short[0], 0, 0, 0.67));
        }
        
        /// <summary>
        ///     Tests that plot bar groups with short group size and shift throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotBarGroups_WithShortGroupSizeAndShift_ThrowsMarshalDirectiveException()
        {
            Assert.Throws<MarshalDirectiveException>(() => ImPlot.PlotBarGroups(new string[0], new short[0], 0, 0, 0.67, 0));
        }
        
        /// <summary>
        ///     Tests that plot bar groups with short group size shift and flags throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotBarGroups_WithShortGroupSizeShiftAndFlags_ThrowsMarshalDirectiveException()
        {
            Assert.Throws<MarshalDirectiveException>(() => ImPlot.PlotBarGroups(new string[0], new short[0], 0, 0, 0.67, 0, ImPlotBarGroupsFlags.None));
        }
        
        /// <summary>
        ///     Tests that plot bar groups with u short throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotBarGroups_WithUShort_ThrowsMarshalDirectiveException()
        {
            Assert.Throws<MarshalDirectiveException>(() => ImPlot.PlotBarGroups(new string[0], new ushort[0], 0, 0));
        }
        
        /// <summary>
        ///     Tests that plot bar groups with u short and group size throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotBarGroups_WithUShortAndGroupSize_ThrowsMarshalDirectiveException()
        {
            Assert.Throws<MarshalDirectiveException>(() => ImPlot.PlotBarGroups(new string[0], new ushort[0], 0, 0, 0.67));
        }
        
        /// <summary>
        ///     Tests that plot bar groups with u short group size and shift throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotBarGroups_WithUShortGroupSizeAndShift_ThrowsMarshalDirectiveException()
        {
            Assert.Throws<MarshalDirectiveException>(() => ImPlot.PlotBarGroups(new string[0], new ushort[0], 0, 0, 0.67, 0));
        }
        
        /// <summary>
        ///     Tests that plot bar groups with u short group size shift and flags throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotBarGroups_WithUShortGroupSizeShiftAndFlags_ThrowsMarshalDirectiveException()
        {
            Assert.Throws<MarshalDirectiveException>(() => ImPlot.PlotBarGroups(new string[0], new ushort[0], 0, 0, 0.67, 0, ImPlotBarGroupsFlags.None));
        }
        
        /// <summary>
        ///     Tests that plot bar groups with int throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotBarGroups_WithInt_ThrowsMarshalDirectiveException()
        {
            Assert.Throws<MarshalDirectiveException>(() => ImPlot.PlotBarGroups(new string[0], new int[0], 0, 0));
        }
        
        /// <summary>
        ///     Tests that plot bar groups with int and group size throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotBarGroups_WithIntAndGroupSize_ThrowsMarshalDirectiveException()
        {
            Assert.Throws<MarshalDirectiveException>(() => ImPlot.PlotBarGroups(new string[0], new int[0], 0, 0, 0.67));
        }
        
        /// <summary>
        ///     Tests that plot bar groups with int group size and shift throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotBarGroups_WithIntGroupSizeAndShift_ThrowsMarshalDirectiveException()
        {
            Assert.Throws<MarshalDirectiveException>(() => ImPlot.PlotBarGroups(new string[0], new int[0], 0, 0, 0.67, 0));
        }
        
        /// <summary>
        ///     Tests that plot bar groups with int group size shift and flags throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotBarGroups_WithIntGroupSizeShiftAndFlags_ThrowsMarshalDirectiveException()
        {
            Assert.Throws<MarshalDirectiveException>(() => ImPlot.PlotBarGroups(new string[0], new int[0], 0, 0, 0.67, 0, ImPlotBarGroupsFlags.None));
        }
        
        /// <summary>
        ///     Tests that plot bar groups with u int throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotBarGroups_WithUInt_ThrowsMarshalDirectiveException()
        {
            Assert.Throws<MarshalDirectiveException>(() => ImPlot.PlotBarGroups(new string[0], new uint[0], 0, 0));
        }
    }
}