// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImPlotP2.cs
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
using System.Text;
using Alis.Core.Aspect.Math.Vector;

namespace Alis.Extension.Graphic.ImGui.Extras.Plot.Native
{
    /// <summary>
    /// The im plot class
    /// </summary>
    public static partial class ImPlot
    {
        
        /// <summary>
        ///     Ends the drag drop target
        /// </summary>
        public static void EndDragDropTarget()
        {
            ImPlotNative.ImPlot_EndDragDropTarget();
        }
        
        /// <summary>
        ///     Ends the legend popup
        /// </summary>
        public static void EndLegendPopup()
        {
            ImPlotNative.ImPlot_EndLegendPopup();
        }
        
        /// <summary>
        ///     Ends the plot
        /// </summary>
        public static void EndPlot()
        {
            ImPlotNative.ImPlot_EndPlot();
        }
        
        /// <summary>
        ///     Ends the subplots
        /// </summary>
        public static void EndSubplots()
        {
            ImPlotNative.ImPlot_EndSubplots();
        }
        
        /// <summary>
        ///     Gets the colormap color using the specified idx
        /// </summary>
        /// <param name="idx">The idx</param>
        /// <returns>The retval</returns>
        public static Vector4 GetColormapColor(int idx)
        {
            Vector4 retval;
            ImPlotColormap cmap = (ImPlotColormap) (-1);
            ImPlotNative.ImPlot_GetColormapColor(out retval, idx, cmap);
            return retval;
        }
        
        /// <summary>
        ///     Gets the colormap color using the specified idx
        /// </summary>
        /// <param name="idx">The idx</param>
        /// <param name="cmap">The cmap</param>
        /// <returns>The retval</returns>
        public static Vector4 GetColormapColor(int idx, ImPlotColormap cmap)
        {
            Vector4 retval;
            ImPlotNative.ImPlot_GetColormapColor(out retval, idx, cmap);
            return retval;
        }
        
        /// <summary>
        ///     Gets the colormap count
        /// </summary>
        /// <returns>The ret</returns>
        public static int GetColormapCount()
        {
            int ret = ImPlotNative.ImPlot_GetColormapCount();
            return ret;
        }
        
        /// <summary>
        ///     Gets the colormap index using the specified name
        /// </summary>
        /// <param name="name">The name</param>
        /// <returns>The ret</returns>
        public static ImPlotColormap GetColormapIndex(string name)
        {
            ImPlotColormap ret = ImPlotNative.ImPlot_GetColormapIndex(Encoding.UTF8.GetBytes(name));
            return ret;
        }
        
        /// <summary>
        ///     Gets the colormap name using the specified cmap
        /// </summary>
        /// <param name="cmap">The cmap</param>
        /// <returns>The string</returns>
        public static string GetColormapName(ImPlotColormap cmap)
        {
            return Encoding.UTF8.GetString(ImPlotNative.ImPlot_GetColormapName(cmap));
        }
        
        /// <summary>
        ///     Gets the colormap size
        /// </summary>
        /// <returns>The ret</returns>
        public static int GetColormapSize()
        {
            ImPlotColormap cmap = (ImPlotColormap) (-1);
            int ret = ImPlotNative.ImPlot_GetColormapSize(cmap);
            return ret;
        }
        
        /// <summary>
        ///     Gets the colormap size using the specified cmap
        /// </summary>
        /// <param name="cmap">The cmap</param>
        /// <returns>The ret</returns>
        public static int GetColormapSize(ImPlotColormap cmap)
        {
            int ret = ImPlotNative.ImPlot_GetColormapSize(cmap);
            return ret;
        }
        
        /// <summary>
        ///     Gets the current context
        /// </summary>
        /// <returns>The ret</returns>
        public static IntPtr GetCurrentContext()
        {
            IntPtr ret = ImPlotNative.ImPlot_GetCurrentContext();
            return ret;
        }
        
        /// <summary>
        ///     Gets the input map
        /// </summary>
        /// <returns>The im plot input map ptr</returns>
        public static ImPlotInputMap GetInputMap()
        {
            return ImPlotNative.ImPlot_GetInputMap();
        }
        
        /// <summary>
        ///     Gets the last item color
        /// </summary>
        /// <returns>The retval</returns>
        public static Vector4 GetLastItemColor()
        {
            Vector4 retval;
            ImPlotNative.ImPlot_GetLastItemColor(out retval);
            return retval;
        }
        
        /// <summary>
        ///     Gets the marker name using the specified idx
        /// </summary>
        /// <param name="idx">The idx</param>
        /// <returns>The string</returns>
        public static string GetMarkerName(ImPlotMarker idx)
        {
            return Encoding.UTF8.GetString(ImPlotNative.ImPlot_GetMarkerName(idx));
        }
        
        /// <summary>
        ///     Gets the plot draw list
        /// </summary>
        /// <returns>The im draw list ptr</returns>
        public static ImDrawList GetPlotDrawList()
        {
            return ImPlotNative.ImPlot_GetPlotDrawList();
        }
        
        /// <summary>
        ///     Gets the plot limits
        /// </summary>
        /// <returns>The ret</returns>
        public static ImPlotRect GetPlotLimits()
        {
            ImAxis xAxis = (ImAxis) (-1);
            ImAxis yAxis = (ImAxis) (-1);
            ImPlotRect ret = ImPlotNative.ImPlot_GetPlotLimits(xAxis, yAxis);
            return ret;
        }
        
        /// <summary>
        ///     Gets the plot limits using the specified x axis
        /// </summary>
        /// <param name="xAxis">The axis</param>
        /// <returns>The ret</returns>
        public static ImPlotRect GetPlotLimits(ImAxis xAxis)
        {
            ImAxis yAxis = (ImAxis) (-1);
            ImPlotRect ret = ImPlotNative.ImPlot_GetPlotLimits(xAxis, yAxis);
            return ret;
        }
        
        /// <summary>
        ///     Gets the plot limits using the specified x axis
        /// </summary>
        /// <param name="xAxis">The axis</param>
        /// <param name="yAxis">The axis</param>
        /// <returns>The ret</returns>
        public static ImPlotRect GetPlotLimits(ImAxis xAxis, ImAxis yAxis)
        {
            ImPlotRect ret = ImPlotNative.ImPlot_GetPlotLimits(xAxis, yAxis);
            return ret;
        }
        
        /// <summary>
        ///     Gets the plot mouse pos
        /// </summary>
        /// <returns>The retval</returns>
        public static ImPlotPoint GetPlotMousePos()
        {
            ImPlotPoint retval;
            ImAxis xAxis = (ImAxis) (-1);
            ImAxis yAxis = (ImAxis) (-1);
            ImPlotNative.ImPlot_GetPlotMousePos(out retval, xAxis, yAxis);
            return retval;
        }
        
        /// <summary>
        ///     Gets the plot mouse pos using the specified x axis
        /// </summary>
        /// <param name="xAxis">The axis</param>
        /// <returns>The retval</returns>
        public static ImPlotPoint GetPlotMousePos(ImAxis xAxis)
        {
            ImPlotPoint retval;
            ImAxis yAxis = (ImAxis) (-1);
            ImPlotNative.ImPlot_GetPlotMousePos(out retval, xAxis, yAxis);
            return retval;
        }
        
        /// <summary>
        ///     Gets the plot mouse pos using the specified x axis
        /// </summary>
        /// <param name="xAxis">The axis</param>
        /// <param name="yAxis">The axis</param>
        /// <returns>The retval</returns>
        public static ImPlotPoint GetPlotMousePos(ImAxis xAxis, ImAxis yAxis)
        {
            ImPlotPoint retval;
            ImPlotNative.ImPlot_GetPlotMousePos(out retval, xAxis, yAxis);
            return retval;
        }
        
        /// <summary>
        ///     Gets the plot pos
        /// </summary>
        /// <returns>The retval</returns>
        public static Vector2 GetPlotPos()
        {
            Vector2 retval;
            ImPlotNative.ImPlot_GetPlotPos(out retval);
            return retval;
        }
        
        /// <summary>
        ///     Gets the plot selection
        /// </summary>
        /// <returns>The ret</returns>
        public static ImPlotRect GetPlotSelection()
        {
            ImAxis xAxis = (ImAxis) (-1);
            ImAxis yAxis = (ImAxis) (-1);
            ImPlotRect ret = ImPlotNative.ImPlot_GetPlotSelection(xAxis, yAxis);
            return ret;
        }
        
        /// <summary>
        ///     Gets the plot selection using the specified x axis
        /// </summary>
        /// <param name="xAxis">The axis</param>
        /// <returns>The ret</returns>
        public static ImPlotRect GetPlotSelection(ImAxis xAxis)
        {
            ImAxis yAxis = (ImAxis) (-1);
            ImPlotRect ret = ImPlotNative.ImPlot_GetPlotSelection(xAxis, yAxis);
            return ret;
        }
        
        /// <summary>
        ///     Gets the plot selection using the specified x axis
        /// </summary>
        /// <param name="xAxis">The axis</param>
        /// <param name="yAxis">The axis</param>
        /// <returns>The ret</returns>
        public static ImPlotRect GetPlotSelection(ImAxis xAxis, ImAxis yAxis)
        {
            ImPlotRect ret = ImPlotNative.ImPlot_GetPlotSelection(xAxis, yAxis);
            return ret;
        }
        
        /// <summary>
        ///     Gets the plot size
        /// </summary>
        /// <returns>The retval</returns>
        public static Vector2 GetPlotSize()
        {
            Vector2 retval;
            ImPlotNative.ImPlot_GetPlotSize(out retval);
            return retval;
        }
        
        /// <summary>
        ///     Gets the style
        /// </summary>
        /// <returns>The im plot style ptr</returns>
        public static ImPlotStyle GetStyle() => ImPlotNative.ImPlot_GetStyle();
        
        /// <summary>
        ///     Gets the style color name using the specified idx
        /// </summary>
        /// <param name="idx">The idx</param>
        /// <returns>The string</returns>
        public static string GetStyleColorName(ImPlotCol idx)
        {
            return Encoding.UTF8.GetString( ImPlotNative.ImPlot_GetStyleColorName(idx));
        }
        
        /// <summary>
        ///     Hides the next item
        /// </summary>
        public static void HideNextItem()
        {
            byte hidden = 1;
            ImPlotCond cond = ImPlotCond.Once;
            ImPlotNative.ImPlot_HideNextItem(hidden, cond);
        }
        
        /// <summary>
        ///     Hides the next item using the specified hidden
        /// </summary>
        /// <param name="hidden">The hidden</param>
        public static void HideNextItem(bool hidden)
        {
            byte nativeHidden = hidden ? (byte) 1 : (byte) 0;
            ImPlotCond cond = ImPlotCond.Once;
            ImPlotNative.ImPlot_HideNextItem(nativeHidden, cond);
        }
        
        /// <summary>
        ///     Hides the next item using the specified hidden
        /// </summary>
        /// <param name="hidden">The hidden</param>
        /// <param name="cond">The cond</param>
        public static void HideNextItem(bool hidden, ImPlotCond cond)
        {
            byte nativeHidden = hidden ? (byte) 1 : (byte) 0;
            ImPlotNative.ImPlot_HideNextItem(nativeHidden, cond);
        }
        
        /// <summary>
        ///     Describes whether is axis hovered
        /// </summary>
        /// <param name="axis">The axis</param>
        /// <returns>The bool</returns>
        public static bool IsAxisHovered(ImAxis axis)
        {
            byte ret = ImPlotNative.ImPlot_IsAxisHovered(axis);
            return ret != 0;
        }
        
        /// <summary>
        ///     Describes whether is legend entry hovered
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <returns>The bool</returns>
        public static bool IsLegendEntryHovered(string labelId)
        {
            byte ret = ImPlotNative.ImPlot_IsLegendEntryHovered(Encoding.UTF8.GetBytes(labelId));
            return ret != 0;
        }
        
        /// <summary>
        ///     Describes whether is plot hovered
        /// </summary>
        /// <returns>The bool</returns>
        public static bool IsPlotHovered()
        {
            byte ret = ImPlotNative.ImPlot_IsPlotHovered();
            return ret != 0;
        }
        
        /// <summary>
        ///     Describes whether is plot selected
        /// </summary>
        /// <returns>The bool</returns>
        public static bool IsPlotSelected()
        {
            byte ret = ImPlotNative.ImPlot_IsPlotSelected();
            return ret != 0;
        }
        
        /// <summary>
        ///     Describes whether is subplots hovered
        /// </summary>
        /// <returns>The bool</returns>
        public static bool IsSubplotsHovered()
        {
            byte ret = ImPlotNative.ImPlot_IsSubplotsHovered();
            return ret != 0;
        }
        
        /// <summary>
        ///     Items the icon using the specified col
        /// </summary>
        /// <param name="col">The col</param>
        public static void ItemIcon(Vector4 col)
        {
            ImPlotNative.ImPlot_ItemIcon_Vec4(col);
        }
        
        /// <summary>
        ///     Items the icon using the specified col
        /// </summary>
        /// <param name="col">The col</param>
        public static void ItemIcon(uint col)
        {
            ImPlotNative.ImPlot_ItemIcon_U32(col);
        }
        
        /// <summary>
        ///     Maps the input default
        /// </summary>
        public static void MapInputDefault()
        {
            ImPlotNative.ImPlot_MapInputDefault(new ImPlotInputMap());
        }
        
        /// <summary>
        ///     Maps the input default using the specified dst
        /// </summary>
        /// <param name="dst">The dst</param>
        public static void MapInputDefault(ImPlotInputMap dst)
        {
            ImPlotNative.ImPlot_MapInputDefault(dst);
        }
        
        /// <summary>
        ///     Maps the input reverse
        /// </summary>
        public static void MapInputReverse()
        {
            ImPlotNative.ImPlot_MapInputReverse(new ImPlotInputMap());
        }
        
        /// <summary>
        ///     Maps the input reverse using the specified dst
        /// </summary>
        /// <param name="dst">The dst</param>
        public static void MapInputReverse(ImPlotInputMap dst)
        {
            ImPlotNative.ImPlot_MapInputReverse(dst);
        }
        
        /// <summary>
        ///     Nexts the colormap color
        /// </summary>
        /// <returns>The retval</returns>
        public static Vector4 NextColormapColor()
        {
            Vector4 retval;
            ImPlotNative.ImPlot_NextColormapColor(out retval);
            return retval;
        }
        
        /// <summary>
        ///     Pixelses the to plot using the specified pix
        /// </summary>
        /// <param name="pix">The pix</param>
        /// <returns>The retval</returns>
        public static ImPlotPoint PixelsToPlot(Vector2 pix)
        {
            ImPlotPoint retval;
            ImAxis xAxis = (ImAxis) (-1);
            ImAxis yAxis = (ImAxis) (-1);
            ImPlotNative.ImPlot_PixelsToPlot_Vec2(out retval, pix, xAxis, yAxis);
            return retval;
        }
        
        /// <summary>
        ///     Pixelses the to plot using the specified pix
        /// </summary>
        /// <param name="pix">The pix</param>
        /// <param name="xAxis">The axis</param>
        /// <returns>The retval</returns>
        public static ImPlotPoint PixelsToPlot(Vector2 pix, ImAxis xAxis)
        {
            ImPlotPoint retval;
            ImAxis yAxis = (ImAxis) (-1);
            ImPlotNative.ImPlot_PixelsToPlot_Vec2(out retval, pix, xAxis, yAxis);
            return retval;
        }
        
        /// <summary>
        ///     Pixelses the to plot using the specified pix
        /// </summary>
        /// <param name="pix">The pix</param>
        /// <param name="xAxis">The axis</param>
        /// <param name="yAxis">The axis</param>
        /// <returns>The retval</returns>
        public static ImPlotPoint PixelsToPlot(Vector2 pix, ImAxis xAxis, ImAxis yAxis)
        {
            ImPlotPoint retval;
            ImPlotNative.ImPlot_PixelsToPlot_Vec2(out retval, pix, xAxis, yAxis);
            return retval;
        }
        
        /// <summary>
        ///     Pixelses the to plot using the specified x
        /// </summary>
        /// <param name="x">The </param>
        /// <param name="y">The </param>
        /// <returns>The retval</returns>
        public static ImPlotPoint PixelsToPlot(float x, float y)
        {
            ImPlotPoint retval;
            ImAxis xAxis = (ImAxis) (-1);
            ImAxis yAxis = (ImAxis) (-1);
            ImPlotNative.ImPlot_PixelsToPlot_Float(out retval, x, y, xAxis, yAxis);
            return retval;
        }
        
        /// <summary>
        ///     Pixelses the to plot using the specified x
        /// </summary>
        /// <param name="x">The </param>
        /// <param name="y">The </param>
        /// <param name="xAxis">The axis</param>
        /// <returns>The retval</returns>
        public static ImPlotPoint PixelsToPlot(float x, float y, ImAxis xAxis)
        {
            ImPlotPoint retval;
            ImAxis yAxis = (ImAxis) (-1);
            ImPlotNative.ImPlot_PixelsToPlot_Float(out retval, x, y, xAxis, yAxis);
            return retval;
        }
        
        /// <summary>
        ///     Pixelses the to plot using the specified x
        /// </summary>
        /// <param name="x">The </param>
        /// <param name="y">The </param>
        /// <param name="xAxis">The axis</param>
        /// <param name="yAxis">The axis</param>
        /// <returns>The retval</returns>
        public static ImPlotPoint PixelsToPlot(float x, float y, ImAxis xAxis, ImAxis yAxis)
        {
            ImPlotPoint retval;
            ImPlotNative.ImPlot_PixelsToPlot_Float(out retval, x, y, xAxis, yAxis);
            return retval;
        }
        
        /// <summary>
        ///     Plots the bar groups using the specified label ids
        /// </summary>
        /// <param name="labelIds">The label ids</param>
        /// <param name="values">The values</param>
        /// <param name="itemCount">The item count</param>
        /// <param name="groupCount">The group count</param>
        public static void PlotBarGroups(string[] labelIds, ref float values, int itemCount, int groupCount)
        {
            byte[][] nativeLabelIds = new byte[labelIds.Length][];
            for (int i = 0; i < labelIds.Length; i++)
            {
                string s = labelIds[i];
                nativeLabelIds[i] = Encoding.UTF8.GetBytes(s);
            }
            ImPlotNative.ImPlot_PlotBarGroups_FloatPtr(nativeLabelIds, ref values, itemCount, groupCount, 0.67, 0, 0);
        }
        
        /// <summary>
        ///     Plots the bar groups using the specified label ids
        /// </summary>
        /// <param name="labelIds">The label ids</param>
        /// <param name="values">The values</param>
        /// <param name="itemCount">The item count</param>
        /// <param name="groupCount">The group count</param>
        /// <param name="groupSize">The group size</param>
        public static void PlotBarGroups(string[] labelIds, ref float values, int itemCount, int groupCount, double groupSize)
        {
            byte[][] nativeLabelIds = new byte[labelIds.Length][];
            for (int i = 0; i < labelIds.Length; i++)
            {
                string s = labelIds[i];
                nativeLabelIds[i] = Encoding.UTF8.GetBytes(s);
            }
            ImPlotNative.ImPlot_PlotBarGroups_FloatPtr(nativeLabelIds, ref values, itemCount, groupCount, groupSize, 0, 0);
        }
        
        /// <summary>
        ///     Plots the bar groups using the specified label ids
        /// </summary>
        /// <param name="labelIds">The label ids</param>
        /// <param name="values">The values</param>
        /// <param name="itemCount">The item count</param>
        /// <param name="groupCount">The group count</param>
        /// <param name="groupSize">The group size</param>
        /// <param name="shift">The shift</param>
        public static void PlotBarGroups(string[] labelIds, ref float values, int itemCount, int groupCount, double groupSize, double shift)
        {
            byte[][] nativeLabelIds = new byte[labelIds.Length][];
            for (int i = 0; i < labelIds.Length; i++)
            {
                string s = labelIds[i];
                nativeLabelIds[i] = Encoding.UTF8.GetBytes(s);
            }
            ImPlotNative.ImPlot_PlotBarGroups_FloatPtr(nativeLabelIds, ref values, itemCount, groupCount, groupSize, shift, 0);
        }
        
        /// <summary>
        ///     Plots the bar groups using the specified label ids
        /// </summary>
        /// <param name="labelIds">The label ids</param>
        /// <param name="values">The values</param>
        /// <param name="itemCount">The item count</param>
        /// <param name="groupCount">The group count</param>
        /// <param name="groupSize">The group size</param>
        /// <param name="shift">The shift</param>
        /// <param name="flags">The flags</param>
        public static void PlotBarGroups(string[] labelIds, ref float values, int itemCount, int groupCount, double groupSize, double shift, ImPlotBarGroupsFlags flags)
        {
            byte[][] nativeLabelIds = new byte[labelIds.Length][];
            for (int i = 0; i < labelIds.Length; i++)
            {
                string s = labelIds[i];
                nativeLabelIds[i] = Encoding.UTF8.GetBytes(s);
            }
            ImPlotNative.ImPlot_PlotBarGroups_FloatPtr(nativeLabelIds, ref values, itemCount, groupCount, groupSize, shift, flags);
        }
        
        /// <summary>
        ///     Plots the bar groups using the specified label ids
        /// </summary>
        /// <param name="labelIds">The label ids</param>
        /// <param name="values">The values</param>
        /// <param name="itemCount">The item count</param>
        /// <param name="groupCount">The group count</param>
        public static void PlotBarGroups(string[] labelIds, ref double values, int itemCount, int groupCount)
        {
            byte[][] nativeLabelIds = new byte[labelIds.Length][];
            for (int i = 0; i < labelIds.Length; i++)
            {
                string s = labelIds[i];
                nativeLabelIds[i] = Encoding.UTF8.GetBytes(s);
            }
            ImPlotNative.ImPlot_PlotBarGroups_doublePtr(nativeLabelIds, ref values, itemCount, groupCount, 0.67, 0, 0);
        }
        
        /// <summary>
        ///     Plots the bar groups using the specified label ids
        /// </summary>
        /// <param name="labelIds">The label ids</param>
        /// <param name="values">The values</param>
        /// <param name="itemCount">The item count</param>
        /// <param name="groupCount">The group count</param>
        /// <param name="groupSize">The group size</param>
        public static void PlotBarGroups(string[] labelIds, ref double values, int itemCount, int groupCount, double groupSize)
        {
            byte[][] nativeLabelIds = new byte[labelIds.Length][];
            for (int i = 0; i < labelIds.Length; i++)
            {
                string s = labelIds[i];
                nativeLabelIds[i] = Encoding.UTF8.GetBytes(s);
            }
            ImPlotNative.ImPlot_PlotBarGroups_doublePtr(nativeLabelIds, ref values, itemCount, groupCount, groupSize, 0, 0);
        }
        
        /// <summary>
        ///     Plots the bar groups using the specified label ids
        /// </summary>
        /// <param name="labelIds">The label ids</param>
        /// <param name="values">The values</param>
        /// <param name="itemCount">The item count</param>
        /// <param name="groupCount">The group count</param>
        /// <param name="groupSize">The group size</param>
        /// <param name="shift">The shift</param>
        public static void PlotBarGroups(string[] labelIds, ref double values, int itemCount, int groupCount, double groupSize, double shift)
        {
            byte[][] nativeLabelIds = new byte[labelIds.Length][];
            for (int i = 0; i < labelIds.Length; i++)
            {
                string s = labelIds[i];
                nativeLabelIds[i] = Encoding.UTF8.GetBytes(s);
            }
            ImPlotNative.ImPlot_PlotBarGroups_doublePtr(nativeLabelIds, ref values, itemCount, groupCount, groupSize, shift, 0);
        }
        
        /// <summary>
        ///     Plots the bar groups using the specified label ids
        /// </summary>
        /// <param name="labelIds">The label ids</param>
        /// <param name="values">The values</param>
        /// <param name="itemCount">The item count</param>
        /// <param name="groupCount">The group count</param>
        /// <param name="groupSize">The group size</param>
        /// <param name="shift">The shift</param>
        /// <param name="flags">The flags</param>
        public static void PlotBarGroups(string[] labelIds, ref double values, int itemCount, int groupCount, double groupSize, double shift, ImPlotBarGroupsFlags flags)
        {
            byte[][] nativeLabelIds = new byte[labelIds.Length][];
            for (int i = 0; i < labelIds.Length; i++)
            {
                string s = labelIds[i];
                nativeLabelIds[i] = Encoding.UTF8.GetBytes(s);
            }
            ImPlotNative.ImPlot_PlotBarGroups_doublePtr(nativeLabelIds, ref values, itemCount, groupCount, groupSize, shift, flags);
        }
        
        /// <summary>
        ///     Plots the bar groups using the specified label ids
        /// </summary>
        /// <param name="labelIds">The label ids</param>
        /// <param name="values">The values</param>
        /// <param name="itemCount">The item count</param>
        /// <param name="groupCount">The group count</param>
        public static void PlotBarGroups(string[] labelIds, ref sbyte values, int itemCount, int groupCount)
        {
            byte[][] nativeLabelIds = new byte[labelIds.Length][];
            for (int i = 0; i < labelIds.Length; i++)
            {
                string s = labelIds[i];
                nativeLabelIds[i] = Encoding.UTF8.GetBytes(s);
            }
            ImPlotNative.ImPlot_PlotBarGroups_S8Ptr(nativeLabelIds,  ref values, itemCount, groupCount, 0.67, 0, 0);
        }
        
        /// <summary>
        ///     Plots the bar groups using the specified label ids
        /// </summary>
        /// <param name="labelIds">The label ids</param>
        /// <param name="values">The values</param>
        /// <param name="itemCount">The item count</param>
        /// <param name="groupCount">The group count</param>
        /// <param name="groupSize">The group size</param>
        public static void PlotBarGroups(string[] labelIds, ref sbyte values, int itemCount, int groupCount, double groupSize)
        {
            byte[][] nativeLabelIds = new byte[labelIds.Length][];
            for (int i = 0; i < labelIds.Length; i++)
            {
                string s = labelIds[i];
                nativeLabelIds[i] = Encoding.UTF8.GetBytes(s);
            }
            ImPlotNative.ImPlot_PlotBarGroups_S8Ptr(nativeLabelIds,  ref values, itemCount, groupCount, groupSize, 0, 0);
        }
        
        /// <summary>
        ///     Plots the bar groups using the specified label ids
        /// </summary>
        /// <param name="labelIds">The label ids</param>
        /// <param name="values">The values</param>
        /// <param name="itemCount">The item count</param>
        /// <param name="groupCount">The group count</param>
        /// <param name="groupSize">The group size</param>
        /// <param name="shift">The shift</param>
        public static void PlotBarGroups(string[] labelIds, ref sbyte values, int itemCount, int groupCount, double groupSize, double shift)
        {
            byte[][] nativeLabelIds = new byte[labelIds.Length][];
            for (int i = 0; i < labelIds.Length; i++)
            {
                string s = labelIds[i];
                nativeLabelIds[i] = Encoding.UTF8.GetBytes(s);
            }
            ImPlotNative.ImPlot_PlotBarGroups_S8Ptr(nativeLabelIds,  ref values, itemCount, groupCount, groupSize, shift, 0);
        }
        
        /// <summary>
        ///     Plots the bar groups using the specified label ids
        /// </summary>
        /// <param name="labelIds">The label ids</param>
        /// <param name="values">The values</param>
        /// <param name="itemCount">The item count</param>
        /// <param name="groupCount">The group count</param>
        /// <param name="groupSize">The group size</param>
        /// <param name="shift">The shift</param>
        /// <param name="flags">The flags</param>
        public static void PlotBarGroups(string[] labelIds, ref sbyte values, int itemCount, int groupCount, double groupSize, double shift, ImPlotBarGroupsFlags flags)
        {
            byte[][] nativeLabelIds = new byte[labelIds.Length][];
            for (int i = 0; i < labelIds.Length; i++)
            {
                string s = labelIds[i];
                nativeLabelIds[i] = Encoding.UTF8.GetBytes(s);
            }
            ImPlotNative.ImPlot_PlotBarGroups_S8Ptr(nativeLabelIds,  ref values, itemCount, groupCount, groupSize, shift, flags);
        }
        
        /// <summary>
        ///     Plots the bar groups using the specified label ids
        /// </summary>
        /// <param name="labelIds">The label ids</param>
        /// <param name="values">The values</param>
        /// <param name="itemCount">The item count</param>
        /// <param name="groupCount">The group count</param>
        public static void PlotBarGroups(string[] labelIds, ref byte values, int itemCount, int groupCount)
        {
            byte[][] nativeLabelIds = new byte[labelIds.Length][];
            for (int i = 0; i < labelIds.Length; i++)
            {
                string s = labelIds[i];
                nativeLabelIds[i] = Encoding.UTF8.GetBytes(s);
            }
            ImPlotNative.ImPlot_PlotBarGroups_U8Ptr(nativeLabelIds, ref values, itemCount, groupCount, 0.67, 0, 0);
        }
        
        /// <summary>
        ///     Plots the bar groups using the specified label ids
        /// </summary>
        /// <param name="labelIds">The label ids</param>
        /// <param name="values">The values</param>
        /// <param name="itemCount">The item count</param>
        /// <param name="groupCount">The group count</param>
        /// <param name="groupSize">The group size</param>
        public static void PlotBarGroups(string[] labelIds, ref byte values, int itemCount, int groupCount, double groupSize)
        {
            byte[][] nativeLabelIds = new byte[labelIds.Length][];
            for (int i = 0; i < labelIds.Length; i++)
            {
                string s = labelIds[i];
                nativeLabelIds[i] = Encoding.UTF8.GetBytes(s);
            }
            ImPlotNative.ImPlot_PlotBarGroups_U8Ptr(nativeLabelIds,  ref values, itemCount, groupCount, groupSize, 0, 0);
        }
        
        /// <summary>
        ///     Plots the bar groups using the specified label ids
        /// </summary>
        /// <param name="labelIds">The label ids</param>
        /// <param name="values">The values</param>
        /// <param name="itemCount">The item count</param>
        /// <param name="groupCount">The group count</param>
        /// <param name="groupSize">The group size</param>
        /// <param name="shift">The shift</param>
        public static void PlotBarGroups(string[] labelIds, ref byte values, int itemCount, int groupCount, double groupSize, double shift)
        {
            byte[][] nativeLabelIds = new byte[labelIds.Length][];
            for (int i = 0; i < labelIds.Length; i++)
            {
                string s = labelIds[i];
                nativeLabelIds[i] = Encoding.UTF8.GetBytes(s);
            }
            ImPlotNative.ImPlot_PlotBarGroups_U8Ptr(nativeLabelIds, ref values, itemCount, groupCount, groupSize, shift, 0);
        }
        
        /// <summary>
        ///     Plots the bar groups using the specified label ids
        /// </summary>
        /// <param name="labelIds">The label ids</param>
        /// <param name="values">The values</param>
        /// <param name="itemCount">The item count</param>
        /// <param name="groupCount">The group count</param>
        /// <param name="groupSize">The group size</param>
        /// <param name="shift">The shift</param>
        /// <param name="flags">The flags</param>
        public static void PlotBarGroups(string[] labelIds, ref byte values, int itemCount, int groupCount, double groupSize, double shift, ImPlotBarGroupsFlags flags)
        {
            byte[][] nativeLabelIds = new byte[labelIds.Length][];
            for (int i = 0; i < labelIds.Length; i++)
            {
                string s = labelIds[i];
                nativeLabelIds[i] = Encoding.UTF8.GetBytes(s);
            }
            ImPlotNative.ImPlot_PlotBarGroups_U8Ptr(nativeLabelIds,ref values, itemCount, groupCount, groupSize, shift, flags);
        }
        
        /// <summary>
        ///     Plots the bar groups using the specified label ids
        /// </summary>
        /// <param name="labelIds">The label ids</param>
        /// <param name="values">The values</param>
        /// <param name="itemCount">The item count</param>
        /// <param name="groupCount">The group count</param>
        public static void PlotBarGroups(string[] labelIds, ref short values, int itemCount, int groupCount)
        {
            byte[][] nativeLabelIds = new byte[labelIds.Length][];
            for (int i = 0; i < labelIds.Length; i++)
            {
                string s = labelIds[i];
                nativeLabelIds[i] = Encoding.UTF8.GetBytes(s);
            }
            ImPlotNative.ImPlot_PlotBarGroups_S16Ptr(nativeLabelIds, ref values, itemCount, groupCount, 0.67, 0, 0);
        }
        
        /// <summary>
        ///     Plots the bar groups using the specified label ids
        /// </summary>
        /// <param name="labelIds">The label ids</param>
        /// <param name="values">The values</param>
        /// <param name="itemCount">The item count</param>
        /// <param name="groupCount">The group count</param>
        /// <param name="groupSize">The group size</param>
        public static void PlotBarGroups(string[] labelIds, ref short values, int itemCount, int groupCount, double groupSize)
        {
            byte[][] nativeLabelIds = new byte[labelIds.Length][];
            for (int i = 0; i < labelIds.Length; i++)
            {
                string s = labelIds[i];
                nativeLabelIds[i] = Encoding.UTF8.GetBytes(s);
            }
            ImPlotNative.ImPlot_PlotBarGroups_S16Ptr(nativeLabelIds, ref values, itemCount, groupCount, groupSize, 0, 0);
        }
        
        /// <summary>
        ///     Plots the bar groups using the specified label ids
        /// </summary>
        /// <param name="labelIds">The label ids</param>
        /// <param name="values">The values</param>
        /// <param name="itemCount">The item count</param>
        /// <param name="groupCount">The group count</param>
        /// <param name="groupSize">The group size</param>
        /// <param name="shift">The shift</param>
        public static void PlotBarGroups(string[] labelIds, ref short values, int itemCount, int groupCount, double groupSize, double shift)
        {
            byte[][] nativeLabelIds = new byte[labelIds.Length][];
            for (int i = 0; i < labelIds.Length; i++)
            {
                string s = labelIds[i];
                nativeLabelIds[i] = Encoding.UTF8.GetBytes(s);
            }
            ImPlotNative.ImPlot_PlotBarGroups_S16Ptr(nativeLabelIds, ref values, itemCount, groupCount, groupSize, shift, 0);
        }
        
        /// <summary>
        ///     Plots the bar groups using the specified label ids
        /// </summary>
        /// <param name="labelIds">The label ids</param>
        /// <param name="values">The values</param>
        /// <param name="itemCount">The item count</param>
        /// <param name="groupCount">The group count</param>
        /// <param name="groupSize">The group size</param>
        /// <param name="shift">The shift</param>
        /// <param name="flags">The flags</param>
        public static void PlotBarGroups(string[] labelIds, ref short values, int itemCount, int groupCount, double groupSize, double shift, ImPlotBarGroupsFlags flags)
        {
            byte[][] nativeLabelIds = new byte[labelIds.Length][];
            for (int i = 0; i < labelIds.Length; i++)
            {
                string s = labelIds[i];
                nativeLabelIds[i] = Encoding.UTF8.GetBytes(s);
            }
            ImPlotNative.ImPlot_PlotBarGroups_S16Ptr(nativeLabelIds, ref values, itemCount, groupCount, groupSize, shift, flags);
        }
        
        /// <summary>
        ///     Plots the bar groups using the specified label ids
        /// </summary>
        /// <param name="labelIds">The label ids</param>
        /// <param name="values">The values</param>
        /// <param name="itemCount">The item count</param>
        /// <param name="groupCount">The group count</param>
        public static void PlotBarGroups(string[] labelIds, ref ushort values, int itemCount, int groupCount)
        {
            byte[][] nativeLabelIds = new byte[labelIds.Length][];
            for (int i = 0; i < labelIds.Length; i++)
            {
                string s = labelIds[i];
                nativeLabelIds[i] = Encoding.UTF8.GetBytes(s);
            }
            ImPlotNative.ImPlot_PlotBarGroups_U16Ptr(nativeLabelIds, ref values, itemCount, groupCount, 0.67, 0, 0);
        }
        
        /// <summary>
        ///     Plots the bar groups using the specified label ids
        /// </summary>
        /// <param name="labelIds">The label ids</param>
        /// <param name="values">The values</param>
        /// <param name="itemCount">The item count</param>
        /// <param name="groupCount">The group count</param>
        /// <param name="groupSize">The group size</param>
        public static void PlotBarGroups(string[] labelIds, ref ushort values, int itemCount, int groupCount, double groupSize)
        {
            byte[][] nativeLabelIds = new byte[labelIds.Length][];
            for (int i = 0; i < labelIds.Length; i++)
            {
                string s = labelIds[i];
                nativeLabelIds[i] = Encoding.UTF8.GetBytes(s);
            }
            ImPlotNative.ImPlot_PlotBarGroups_U16Ptr(nativeLabelIds, ref values, itemCount, groupCount, groupSize, 0, 0);
        }
        
        /// <summary>
        ///     Plots the bar groups using the specified label ids
        /// </summary>
        /// <param name="labelIds">The label ids</param>
        /// <param name="values">The values</param>
        /// <param name="itemCount">The item count</param>
        /// <param name="groupCount">The group count</param>
        /// <param name="groupSize">The group size</param>
        /// <param name="shift">The shift</param>
        public static void PlotBarGroups(string[] labelIds, ref ushort values, int itemCount, int groupCount, double groupSize, double shift)
        {
            byte[][] nativeLabelIds = new byte[labelIds.Length][];
            for (int i = 0; i < labelIds.Length; i++)
            {
                string s = labelIds[i];
                nativeLabelIds[i] = Encoding.UTF8.GetBytes(s);
            }
            ImPlotNative.ImPlot_PlotBarGroups_U16Ptr(nativeLabelIds, ref values, itemCount, groupCount, groupSize, shift, 0);
        }
        
        /// <summary>
        ///     Plots the bar groups using the specified label ids
        /// </summary>
        /// <param name="labelIds">The label ids</param>
        /// <param name="values">The values</param>
        /// <param name="itemCount">The item count</param>
        /// <param name="groupCount">The group count</param>
        /// <param name="groupSize">The group size</param>
        /// <param name="shift">The shift</param>
        /// <param name="flags">The flags</param>
        public static void PlotBarGroups(string[] labelIds, ref ushort values, int itemCount, int groupCount, double groupSize, double shift, ImPlotBarGroupsFlags flags)
        {
            byte[][] nativeLabelIds = new byte[labelIds.Length][];
            for (int i = 0; i < labelIds.Length; i++)
            {
                string s = labelIds[i];
                nativeLabelIds[i] = Encoding.UTF8.GetBytes(s);
            }
            ImPlotNative.ImPlot_PlotBarGroups_U16Ptr(nativeLabelIds, ref values, itemCount, groupCount, groupSize, shift, flags);
        }
        
        /// <summary>
        ///     Plots the bar groups using the specified label ids
        /// </summary>
        /// <param name="labelIds">The label ids</param>
        /// <param name="values">The values</param>
        /// <param name="itemCount">The item count</param>
        /// <param name="groupCount">The group count</param>
        public static void PlotBarGroups(string[] labelIds, ref int values, int itemCount, int groupCount)
        {
            byte[][] nativeLabelIds = new byte[labelIds.Length][];
            for (int i = 0; i < labelIds.Length; i++)
            {
                string s = labelIds[i];
                nativeLabelIds[i] = Encoding.UTF8.GetBytes(s);
            }
            ImPlotNative.ImPlot_PlotBarGroups_S32Ptr(nativeLabelIds, ref values, itemCount, groupCount, 0.67, 0, 0);
        }
        
        /// <summary>
        ///     Plots the bar groups using the specified label ids
        /// </summary>
        /// <param name="labelIds">The label ids</param>
        /// <param name="values">The values</param>
        /// <param name="itemCount">The item count</param>
        /// <param name="groupCount">The group count</param>
        /// <param name="groupSize">The group size</param>
        public static void PlotBarGroups(string[] labelIds, ref int values, int itemCount, int groupCount, double groupSize)
        {
            byte[][] nativeLabelIds = new byte[labelIds.Length][];
            for (int i = 0; i < labelIds.Length; i++)
            {
                string s = labelIds[i];
                nativeLabelIds[i] = Encoding.UTF8.GetBytes(s);
            }
            ImPlotNative.ImPlot_PlotBarGroups_S32Ptr(nativeLabelIds, ref values, itemCount, groupCount, groupSize, 0, 0);
        }
        
        /// <summary>
        ///     Plots the bar groups using the specified label ids
        /// </summary>
        /// <param name="labelIds">The label ids</param>
        /// <param name="values">The values</param>
        /// <param name="itemCount">The item count</param>
        /// <param name="groupCount">The group count</param>
        /// <param name="groupSize">The group size</param>
        /// <param name="shift">The shift</param>
        public static void PlotBarGroups(string[] labelIds, ref int values, int itemCount, int groupCount, double groupSize, double shift)
        {
            byte[][] nativeLabelIds = new byte[labelIds.Length][];
            for (int i = 0; i < labelIds.Length; i++)
            {
                string s = labelIds[i];
                nativeLabelIds[i] = Encoding.UTF8.GetBytes(s);
            }
            ImPlotNative.ImPlot_PlotBarGroups_S32Ptr(nativeLabelIds, ref values, itemCount, groupCount, groupSize, shift, 0);
        }
        
        /// <summary>
        ///     Plots the bar groups using the specified label ids
        /// </summary>
        /// <param name="labelIds">The label ids</param>
        /// <param name="values">The values</param>
        /// <param name="itemCount">The item count</param>
        /// <param name="groupCount">The group count</param>
        /// <param name="groupSize">The group size</param>
        /// <param name="shift">The shift</param>
        /// <param name="flags">The flags</param>
        public static void PlotBarGroups(string[] labelIds, ref int values, int itemCount, int groupCount, double groupSize, double shift, ImPlotBarGroupsFlags flags)
        {
            byte[][] nativeLabelIds = new byte[labelIds.Length][];
            for (int i = 0; i < labelIds.Length; i++)
            {
                string s = labelIds[i];
                nativeLabelIds[i] = Encoding.UTF8.GetBytes(s);
            }
            ImPlotNative.ImPlot_PlotBarGroups_S32Ptr(nativeLabelIds, ref values, itemCount, groupCount, groupSize, shift, flags);
        }
        
        /// <summary>
        ///     Plots the bar groups using the specified label ids
        /// </summary>
        /// <param name="labelIds">The label ids</param>
        /// <param name="values">The values</param>
        /// <param name="itemCount">The item count</param>
        /// <param name="groupCount">The group count</param>
        public static void PlotBarGroups(string[] labelIds, ref uint values, int itemCount, int groupCount)
        {
            byte[][] nativeLabelIds = new byte[labelIds.Length][];
            for (int i = 0; i < labelIds.Length; i++)
            {
                string s = labelIds[i];
                nativeLabelIds[i] = Encoding.UTF8.GetBytes(s);
            }
            ImPlotNative.ImPlot_PlotBarGroups_U32Ptr(nativeLabelIds, ref values, itemCount, groupCount, 0.67, 0, 0);
        }
        
        
    }
}