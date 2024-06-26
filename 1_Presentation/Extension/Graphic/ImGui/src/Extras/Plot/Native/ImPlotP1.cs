// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImPlotP1.cs
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
        ///     Adds the colormap using the specified name
        /// </summary>
        /// <param name="name">The name</param>
        /// <param name="cols">The cols</param>
        /// <param name="size">The size</param>
        /// <returns>The im plot colormap</returns>
        public static ImPlotColormap AddColormap(string name, ref Vector4 cols, int size)
        {
            ImPlotColormap ret = ImPlotNative.ImPlot_AddColormap_Vec4Ptr(Encoding.UTF8.GetBytes(name), cols, size, 0);
            return ret;
        }
        
        /// <summary>
        ///     Adds the colormap using the specified name
        /// </summary>
        /// <param name="name">The name</param>
        /// <param name="cols">The cols</param>
        /// <param name="size">The size</param>
        /// <param name="qual">The qual</param>
        /// <returns>The im plot colormap</returns>
        public static ImPlotColormap AddColormap(string name, ref Vector4 cols, int size, bool qual)
        {
            ImPlotColormap ret = ImPlotNative.ImPlot_AddColormap_Vec4Ptr(Encoding.UTF8.GetBytes(name), cols, size, qual ? (byte) 1 : (byte) 0);
            return ret;
        }
        
        /// <summary>
        ///     Adds the colormap using the specified name
        /// </summary>
        /// <param name="name">The name</param>
        /// <param name="cols">The cols</param>
        /// <param name="size">The size</param>
        /// <returns>The im plot colormap</returns>
        public static ImPlotColormap AddColormap(string name, ref uint cols, int size)
        {
            ImPlotColormap ret = ImPlotNative.ImPlot_AddColormap_U32Ptr(Encoding.UTF8.GetBytes(name), cols, size, 0);
            return ret;
        }
        
        /// <summary>
        ///     Adds the colormap using the specified name
        /// </summary>
        /// <param name="name">The name</param>
        /// <param name="cols">The cols</param>
        /// <param name="size">The size</param>
        /// <param name="qual">The qual</param>
        /// <returns>The im plot colormap</returns>
        public static ImPlotColormap AddColormap(string name, ref uint cols, int size, bool qual)
        {
            ImPlotColormap ret = ImPlotNative.ImPlot_AddColormap_U32Ptr(Encoding.UTF8.GetBytes(name), cols, size, qual ? (byte) 1 : (byte) 0);
            return ret;
        }
        
        /// <summary>
        ///     Annotations the x
        /// </summary>
        /// <param name="x">The </param>
        /// <param name="y">The </param>
        /// <param name="col">The col</param>
        /// <param name="pixOffset">The pix offset</param>
        /// <param name="clamp">The clamp</param>
        public static void Annotation(double x, double y, Vector4 col, Vector2 pixOffset, bool clamp)
        {
            byte nativeClamp = clamp ? (byte) 1 : (byte) 0;
            byte round = 0;
            ImPlotNative.ImPlot_Annotation_Bool(x, y, col, pixOffset, nativeClamp, round);
        }
        
        /// <summary>
        ///     Annotations the x
        /// </summary>
        /// <param name="x">The </param>
        /// <param name="y">The </param>
        /// <param name="col">The col</param>
        /// <param name="pixOffset">The pix offset</param>
        /// <param name="clamp">The clamp</param>
        /// <param name="round">The round</param>
        public static void Annotation(double x, double y, Vector4 col, Vector2 pixOffset, bool clamp, bool round)
        {
            byte nativeClamp = clamp ? (byte) 1 : (byte) 0;
            byte nativeRound = round ? (byte) 1 : (byte) 0;
            ImPlotNative.ImPlot_Annotation_Bool(x, y, col, pixOffset, nativeClamp, nativeRound);
        }
        
        /// <summary>
        ///     Annotations the x
        /// </summary>
        /// <param name="x">The </param>
        /// <param name="y">The </param>
        /// <param name="col">The col</param>
        /// <param name="pixOffset">The pix offset</param>
        /// <param name="clamp">The clamp</param>
        /// <param name="fmt">The fmt</param>
        public static void Annotation(double x, double y, Vector4 col, Vector2 pixOffset, bool clamp, string fmt)
        {
            ImPlotNative.ImPlot_Annotation_Str(x, y, col, pixOffset, clamp ? (byte) 1 : (byte) 0, Encoding.UTF8.GetBytes(fmt));
        }
        
        /// <summary>
        ///     Describes whether begin aligned plots
        /// </summary>
        /// <param name="groupId">The group id</param>
        /// <returns>The bool</returns>
        public static bool BeginAlignedPlots(string groupId)
        {
            byte ret = ImPlotNative.ImPlot_BeginAlignedPlots(Encoding.UTF8.GetBytes(groupId), 0);
            return ret != 0;
        }
        
        /// <summary>
        ///     Describes whether begin aligned plots
        /// </summary>
        /// <param name="groupId">The group id</param>
        /// <param name="vertical">The vertical</param>
        /// <returns>The bool</returns>
        public static bool BeginAlignedPlots(string groupId, bool vertical)
        {
            byte ret = ImPlotNative.ImPlot_BeginAlignedPlots(Encoding.UTF8.GetBytes(groupId), vertical ? (byte) 1 : (byte) 0);
            return ret != 0;
        }
        
        /// <summary>
        ///     Describes whether begin drag drop source axis
        /// </summary>
        /// <param name="axis">The axis</param>
        /// <returns>The bool</returns>
        public static bool BeginDragDropSourceAxis(ImAxis axis)
        {
            ImGuiDragDropFlags flags = 0;
            byte ret = ImPlotNative.ImPlot_BeginDragDropSourceAxis(axis, flags);
            return ret != 0;
        }
        
        /// <summary>
        ///     Describes whether begin drag drop source axis
        /// </summary>
        /// <param name="axis">The axis</param>
        /// <param name="flags">The flags</param>
        /// <returns>The bool</returns>
        public static bool BeginDragDropSourceAxis(ImAxis axis, ImGuiDragDropFlags flags)
        {
            byte ret = ImPlotNative.ImPlot_BeginDragDropSourceAxis(axis, flags);
            return ret != 0;
        }
        
        /// <summary>
        ///     Describes whether begin drag drop source item
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <returns>The bool</returns>
        public static bool BeginDragDropSourceItem(string labelId)
        {
            byte ret = ImPlotNative.ImPlot_BeginDragDropSourceItem(Encoding.UTF8.GetBytes(labelId), 0);
            return ret != 0;
        }
        
        /// <summary>
        ///     Describes whether begin drag drop source item
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="flags">The flags</param>
        /// <returns>The bool</returns>
        public static bool BeginDragDropSourceItem(string labelId, ImGuiDragDropFlags flags)
        {
            byte ret = ImPlotNative.ImPlot_BeginDragDropSourceItem(Encoding.UTF8.GetBytes(labelId), flags);
            return ret != 0;
        }
        
        /// <summary>
        ///     Describes whether begin drag drop source plot
        /// </summary>
        /// <returns>The bool</returns>
        public static bool BeginDragDropSourcePlot()
        {
            ImGuiDragDropFlags flags = 0;
            byte ret = ImPlotNative.ImPlot_BeginDragDropSourcePlot(flags);
            return ret != 0;
        }
        
        /// <summary>
        ///     Describes whether begin drag drop source plot
        /// </summary>
        /// <param name="flags">The flags</param>
        /// <returns>The bool</returns>
        public static bool BeginDragDropSourcePlot(ImGuiDragDropFlags flags)
        {
            byte ret = ImPlotNative.ImPlot_BeginDragDropSourcePlot(flags);
            return ret != 0;
        }
        
        /// <summary>
        ///     Describes whether begin drag drop target axis
        /// </summary>
        /// <param name="axis">The axis</param>
        /// <returns>The bool</returns>
        public static bool BeginDragDropTargetAxis(ImAxis axis)
        {
            byte ret = ImPlotNative.ImPlot_BeginDragDropTargetAxis(axis);
            return ret != 0;
        }
        
        /// <summary>
        ///     Describes whether begin drag drop target legend
        /// </summary>
        /// <returns>The bool</returns>
        public static bool BeginDragDropTargetLegend()
        {
            byte ret = ImPlotNative.ImPlot_BeginDragDropTargetLegend();
            return ret != 0;
        }
        
        /// <summary>
        ///     Describes whether begin drag drop target plot
        /// </summary>
        /// <returns>The bool</returns>
        public static bool BeginDragDropTargetPlot()
        {
            byte ret = ImPlotNative.ImPlot_BeginDragDropTargetPlot();
            return ret != 0;
        }
        
        /// <summary>
        ///     Describes whether begin legend popup
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <returns>The bool</returns>
        public static bool BeginLegendPopup(string labelId)
        {
            byte ret = ImPlotNative.ImPlot_BeginLegendPopup(Encoding.UTF8.GetBytes(labelId), 0);
            return ret != 0;
        }
        
        /// <summary>
        ///     Describes whether begin legend popup
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="mouseButton">The mouse button</param>
        /// <returns>The bool</returns>
        public static bool BeginLegendPopup(string labelId, ImGuiMouseButton mouseButton)
        {
            byte ret = ImPlotNative.ImPlot_BeginLegendPopup(Encoding.UTF8.GetBytes(labelId),  mouseButton);
            return ret != 0;
        }
        
        /// <summary>
        ///     Describes whether begin plot
        /// </summary>
        /// <param name="titleId">The title id</param>
        /// <returns>The bool</returns>
        public static bool BeginPlot(string titleId)
        {
            byte ret = ImPlotNative.ImPlot_BeginPlot( Encoding.UTF8.GetBytes(titleId), new Vector2(-1, 0), 0);
            return ret != 0;
        }
        
       /// <summary>
        ///     Describes whether begin plot
        /// </summary>
        /// <param name="titleId">The title id</param>
        /// <param name="size">The size</param>
        /// <returns>The bool</returns>
        public static bool BeginPlot(string titleId, Vector2 size)
        {
            byte ret = ImPlotNative.ImPlot_BeginPlot( Encoding.UTF8.GetBytes(titleId), size, 0);
            return ret != 0;
        }
        
        /// <summary>
        ///     Describes whether begin plot
        /// </summary>
        /// <param name="titleId">The title id</param>
        /// <param name="size">The size</param>
        /// <param name="flags">The flags</param>
        /// <returns>The bool</returns>
        public static  bool BeginPlot(string titleId, Vector2 size, ImPlotFlags flags)
        {
           byte ret = ImPlotNative.ImPlot_BeginPlot(Encoding.UTF8.GetBytes(titleId), size, flags);
            return ret != 0;
        }
        
        /// <summary>
        ///     Describes whether begin subplots
        /// </summary>
        /// <param name="titleId">The title id</param>
        /// <param name="rows">The rows</param>
        /// <param name="cols">The cols</param>
        /// <param name="size">The size</param>
        /// <returns>The bool</returns>
        public static bool BeginSubplots(string titleId, int rows, int cols, Vector2 size)
        {
            byte ret = ImPlotNative.ImPlot_BeginSubplots(Encoding.UTF8.GetBytes(titleId), rows, cols, size, 0,   (float)ImPlotSubplotFlags.None, 0.0f);
            return ret != 0;
        }
        
        /// <summary>
        ///     Describes whether begin subplots
        /// </summary>
        /// <param name="titleId">The title id</param>
        /// <param name="rows">The rows</param>
        /// <param name="cols">The cols</param>
        /// <param name="size">The size</param>
        /// <param name="flags">The flags</param>
        /// <returns>The bool</returns>
        public static bool BeginSubplots(string titleId, int rows, int cols, Vector2 size, ImPlotSubplotFlags flags)
        {
            byte ret = ImPlotNative.ImPlot_BeginSubplots(Encoding.UTF8.GetBytes(titleId), rows, cols, size, flags,   (float)ImPlotSubplotFlags.None, 0.0f);
            return ret != 0;
        }
        
        /// <summary>
        ///     Describes whether begin subplots
        /// </summary>
        /// <param name="titleId">The title id</param>
        /// <param name="rows">The rows</param>
        /// <param name="cols">The cols</param>
        /// <param name="size">The size</param>
        /// <param name="flags">The flags</param>
        /// <param name="rowRatios">The row ratios</param>
        /// <returns>The bool</returns>
        public static bool BeginSubplots(string titleId, int rows, int cols, Vector2 size, ImPlotSubplotFlags flags, ref float rowRatios)
        {
            byte ret = ImPlotNative.ImPlot_BeginSubplots(Encoding.UTF8.GetBytes(titleId), rows, cols, size, flags,    rowRatios, 0.0f);
            return ret != 0;
        }
        
        /// <summary>
        ///     Describes whether begin subplots
        /// </summary>
        /// <param name="titleId">The title id</param>
        /// <param name="rows">The rows</param>
        /// <param name="cols">The cols</param>
        /// <param name="size">The size</param>
        /// <param name="flags">The flags</param>
        /// <param name="rowRatios">The row ratios</param>
        /// <param name="colRatios">The col ratios</param>
        /// <returns>The bool</returns>
        public static bool BeginSubplots(string titleId, int rows, int cols, Vector2 size, ImPlotSubplotFlags flags, ref float rowRatios, ref float colRatios)
        {
            byte ret = ImPlotNative.ImPlot_BeginSubplots(Encoding.UTF8.GetBytes(titleId), rows, cols, size, flags,    rowRatios, colRatios);
            return ret != 0;
        }
        
        /// <summary>
        ///     Busts the color cache
        /// </summary>
        public static void BustColorCache()
        {
            ImPlotNative.ImPlot_BustColorCache(null);
        }
        
        /// <summary>
        ///     Busts the color cache using the specified plot title id
        /// </summary>
        /// <param name="plotTitleId">The plot title id</param>
        public static void BustColorCache(string plotTitleId)
        {
            ImPlotNative.ImPlot_BustColorCache(Encoding.UTF8.GetBytes(plotTitleId));
        }
        
        /// <summary>
        ///     Cancels the plot selection
        /// </summary>
        public static void CancelPlotSelection()
        {
            ImPlotNative.ImPlot_CancelPlotSelection();
        }
        
        /// <summary>
        ///     Describes whether colormap button
        /// </summary>
        /// <param name="label">The label</param>
        /// <returns>The bool</returns>
        public static bool ColormapButton(string label)
        {
            Vector2 size = new Vector2();
            ImPlotColormap cmap = (ImPlotColormap) (-1);
            byte ret = ImPlotNative.ImPlot_ColormapButton(Encoding.UTF8.GetBytes(label), size, cmap);
            return ret != 0;
        }
        
        /// <summary>
        ///     Describes whether colormap button
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="size">The size</param>
        /// <returns>The bool</returns>
        public static bool ColormapButton(string label, Vector2 size)
        {
            ImPlotColormap cmap = (ImPlotColormap) (-1);
            byte ret = ImPlotNative.ImPlot_ColormapButton(Encoding.UTF8.GetBytes(label), size, cmap);
            return ret != 0;
        }
        
        /// <summary>
        ///     Describes whether colormap button
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="size">The size</param>
        /// <param name="cmap">The cmap</param>
        /// <returns>The bool</returns>
        public static bool ColormapButton(string label, Vector2 size, ImPlotColormap cmap)
        {
            byte ret = ImPlotNative.ImPlot_ColormapButton(Encoding.UTF8.GetBytes(label), size, cmap);
            return ret != 0;
        }
        
        /// <summary>
        ///     Colormaps the icon using the specified cmap
        /// </summary>
        /// <param name="cmap">The cmap</param>
        public static void ColormapIcon(ImPlotColormap cmap)
        {
            ImPlotNative.ImPlot_ColormapIcon(cmap);
        }
        
        /// <summary>
        ///     Colormaps the scale using the specified label
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="scaleMin">The scale min</param>
        /// <param name="scaleMax">The scale max</param>
        public static void ColormapScale(string label, double scaleMin, double scaleMax)
        {
            ImPlotNative.ImPlot_ColormapScale(Encoding.UTF8.GetBytes(label), scaleMin, scaleMax, new Vector2(0, 0), null, 0, (ImPlotColormap) (-1));
        }
        
        /// <summary>
        ///     Colormaps the scale using the specified label
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="scaleMin">The scale min</param>
        /// <param name="scaleMax">The scale max</param>
        /// <param name="size">The size</param>
        public static void ColormapScale(string label, double scaleMin, double scaleMax, Vector2 size)
        {
            ImPlotNative.ImPlot_ColormapScale(Encoding.UTF8.GetBytes(label), scaleMin, scaleMax, size, null, 0, (ImPlotColormap) (-1));
        }
        
        /// <summary>
        ///     Colormaps the scale using the specified label
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="scaleMin">The scale min</param>
        /// <param name="scaleMax">The scale max</param>
        /// <param name="size">The size</param>
        /// <param name="format">The format</param>
        public static void ColormapScale(string label, double scaleMin, double scaleMax, Vector2 size, string format)
        {
            ImPlotNative.ImPlot_ColormapScale(Encoding.UTF8.GetBytes(label), scaleMin, scaleMax, size, Encoding.UTF8.GetBytes(format), 0, (ImPlotColormap) (-1));
        }
        
        /// <summary>
        ///     Colormaps the scale using the specified label
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="scaleMin">The scale min</param>
        /// <param name="scaleMax">The scale max</param>
        /// <param name="size">The size</param>
        /// <param name="format">The format</param>
        /// <param name="flags">The flags</param>
        public static void ColormapScale(string label, double scaleMin, double scaleMax, Vector2 size, string format, ImPlotColormapScaleFlags flags)
        {
            ImPlotNative.ImPlot_ColormapScale(Encoding.UTF8.GetBytes(label), scaleMin, scaleMax, size, Encoding.UTF8.GetBytes(format), flags, (ImPlotColormap) (-1));
        }
        
        /// <summary>
        ///     Colormaps the scale using the specified label
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="scaleMin">The scale min</param>
        /// <param name="scaleMax">The scale max</param>
        /// <param name="size">The size</param>
        /// <param name="format">The format</param>
        /// <param name="flags">The flags</param>
        /// <param name="cmap">The cmap</param>
        public static void ColormapScale(string label, double scaleMin, double scaleMax, Vector2 size, string format, ImPlotColormapScaleFlags flags, ImPlotColormap cmap)
        {
            ImPlotNative.ImPlot_ColormapScale(Encoding.UTF8.GetBytes(label), scaleMin, scaleMax, size, Encoding.UTF8.GetBytes(format), flags, cmap);
        }
        
        /// <summary>
        ///     Describes whether colormap slider
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="t">The </param>
        /// <returns>The bool</returns>
        public static bool ColormapSlider(string label, ref float t)
        {
            byte ret = ImPlotNative.ImPlot_ColormapSlider(Encoding.UTF8.GetBytes(label),  t, out Vector4 @out, Encoding.UTF8.GetBytes(""), (ImPlotColormap) (-1));
            return ret != 0;
        }
        
        /// <summary>
        ///     Describes whether colormap slider
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="t">The </param>
        /// <param name="out">The out</param>
        /// <returns>The bool</returns>
        public static bool ColormapSlider(string label, ref float t, out Vector4 @out)
        {
            byte ret = ImPlotNative.ImPlot_ColormapSlider(Encoding.UTF8.GetBytes(label), t, out @out, Encoding.UTF8.GetBytes(""), (ImPlotColormap) (-1));
            return ret != 0;
        }
        
        /// <summary>
        ///     Describes whether colormap slider
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="t">The </param>
        /// <param name="out">The out</param>
        /// <param name="format">The format</param>
        /// <returns>The bool</returns>
        public static bool ColormapSlider(string label, ref float t, out Vector4 @out, string format)
        {
            byte ret = ImPlotNative.ImPlot_ColormapSlider(Encoding.UTF8.GetBytes(label), t, out @out, Encoding.UTF8.GetBytes(format), (ImPlotColormap) (-1));
            return ret != 0;
        }
        
        /// <summary>
        ///     Describes whether colormap slider
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="t">The </param>
        /// <param name="out">The out</param>
        /// <param name="format">The format</param>
        /// <param name="cmap">The cmap</param>
        /// <returns>The bool</returns>
        public static bool ColormapSlider(string label, ref float t, out Vector4 @out, string format, ImPlotColormap cmap)
        {
            byte ret = ImPlotNative.ImPlot_ColormapSlider(Encoding.UTF8.GetBytes(label), t, out @out, Encoding.UTF8.GetBytes(format), cmap);
            return ret != 0;
        }
        
        /// <summary>
        ///     Creates the context
        /// </summary>
        /// <returns>The ret</returns>
        public static IntPtr CreateContext()
        {
            IntPtr ret = ImPlotNative.ImPlot_CreateContext();
            return ret;
        }
        
        /// <summary>
        ///     Destroys the context
        /// </summary>
        public static void DestroyContext()
        {
            IntPtr ctx = IntPtr.Zero;
            ImPlotNative.ImPlot_DestroyContext(ctx);
        }
        
        /// <summary>
        ///     Destroys the context using the specified ctx
        /// </summary>
        /// <param name="ctx">The ctx</param>
        public static void DestroyContext(IntPtr ctx)
        {
            ImPlotNative.ImPlot_DestroyContext(ctx);
        }
        
        /// <summary>
        ///     Describes whether drag line x
        /// </summary>
        /// <param name="id">The id</param>
        /// <param name="x">The </param>
        /// <param name="col">The col</param>
        /// <returns>The bool</returns>
        public static bool DragLineX(int id, ref double x, Vector4 col)
        {
            float thickness = 1;
            ImPlotDragToolFlags flags = 0;
            byte ret = ImPlotNative.ImPlot_DragLineX(id, x, col, thickness, flags);
            return ret != 0;
        }
        
        /// <summary>
        ///     Describes whether drag line x
        /// </summary>
        /// <param name="id">The id</param>
        /// <param name="x">The </param>
        /// <param name="col">The col</param>
        /// <param name="thickness">The thickness</param>
        /// <returns>The bool</returns>
        public static bool DragLineX(int id, ref double x, Vector4 col, float thickness)
        {
            ImPlotDragToolFlags flags = 0;
            byte ret = ImPlotNative.ImPlot_DragLineX(id, x, col, thickness, flags);
            return ret != 0;
        }
        
        /// <summary>
        ///     Describes whether drag line x
        /// </summary>
        /// <param name="id">The id</param>
        /// <param name="x">The </param>
        /// <param name="col">The col</param>
        /// <param name="thickness">The thickness</param>
        /// <param name="flags">The flags</param>
        /// <returns>The bool</returns>
        public static bool DragLineX(int id, ref double x, Vector4 col, float thickness, ImPlotDragToolFlags flags)
        {
            byte ret = ImPlotNative.ImPlot_DragLineX(id, x, col, thickness, flags);
            return ret != 0;
        }
        
        /// <summary>
        ///     Describes whether drag line y
        /// </summary>
        /// <param name="id">The id</param>
        /// <param name="y">The </param>
        /// <param name="col">The col</param>
        /// <returns>The bool</returns>
        public static bool DragLineY(int id, ref double y, Vector4 col)
        {
            float thickness = 1;
            ImPlotDragToolFlags flags = 0;
            byte ret = ImPlotNative.ImPlot_DragLineY(id, y, col, thickness, flags);
            return ret != 0;
        }
        
        /// <summary>
        ///     Describes whether drag line y
        /// </summary>
        /// <param name="id">The id</param>
        /// <param name="y">The </param>
        /// <param name="col">The col</param>
        /// <param name="thickness">The thickness</param>
        /// <returns>The bool</returns>
        public static bool DragLineY(int id, ref double y, Vector4 col, float thickness)
        {
            ImPlotDragToolFlags flags = 0;
            byte ret = ImPlotNative.ImPlot_DragLineY(id, y, col, thickness, flags);
            return ret != 0;
        }
        
        /// <summary>
        ///     Describes whether drag line y
        /// </summary>
        /// <param name="id">The id</param>
        /// <param name="y">The </param>
        /// <param name="col">The col</param>
        /// <param name="thickness">The thickness</param>
        /// <param name="flags">The flags</param>
        /// <returns>The bool</returns>
        public static bool DragLineY(int id, ref double y, Vector4 col, float thickness, ImPlotDragToolFlags flags)
        {
            byte ret = ImPlotNative.ImPlot_DragLineY(id, y, col, thickness, flags);
            return ret != 0;
        }
        
        /// <summary>
        ///     Describes whether drag point
        /// </summary>
        /// <param name="id">The id</param>
        /// <param name="x">The </param>
        /// <param name="y">The </param>
        /// <param name="col">The col</param>
        /// <returns>The bool</returns>
        public static bool DragPoint(int id, ref double x, ref double y, Vector4 col)
        {
            float size = 4;
            ImPlotDragToolFlags flags = 0;
            byte ret = ImPlotNative.ImPlot_DragPoint(id, x, y, col, size, flags);
            return ret != 0;
        }
        
        /// <summary>
        ///     Describes whether drag point
        /// </summary>
        /// <param name="id">The id</param>
        /// <param name="x">The </param>
        /// <param name="y">The </param>
        /// <param name="col">The col</param>
        /// <param name="size">The size</param>
        /// <returns>The bool</returns>
        public static bool DragPoint(int id, ref double x, ref double y, Vector4 col, float size)
        {
            ImPlotDragToolFlags flags = 0;
            byte ret = ImPlotNative.ImPlot_DragPoint(id, x, y, col, size, flags);
            return ret != 0;
        }
        
        /// <summary>
        ///     Describes whether drag point
        /// </summary>
        /// <param name="id">The id</param>
        /// <param name="x">The </param>
        /// <param name="y">The </param>
        /// <param name="col">The col</param>
        /// <param name="size">The size</param>
        /// <param name="flags">The flags</param>
        /// <returns>The bool</returns>
        public static bool DragPoint(int id, ref double x, ref double y, Vector4 col, float size, ImPlotDragToolFlags flags)
        {
            byte ret = ImPlotNative.ImPlot_DragPoint(id, x, y, col, size, flags);
            return ret != 0;
        }
        
        /// <summary>
        ///     Describes whether drag rect
        /// </summary>
        /// <param name="id">The id</param>
        /// <param name="x1">The </param>
        /// <param name="y1">The </param>
        /// <param name="x2">The </param>
        /// <param name="y2">The </param>
        /// <param name="col">The col</param>
        /// <returns>The bool</returns>
        public static bool DragRect(int id, ref double x1, ref double y1, ref double x2, ref double y2, Vector4 col)
        {
            ImPlotDragToolFlags flags = 0;
            byte ret = ImPlotNative.ImPlot_DragRect(id, x1, y1, x2, y2, col, flags);
            return ret != 0;
        }
        
        /// <summary>
        ///     Describes whether drag rect
        /// </summary>
        /// <param name="id">The id</param>
        /// <param name="x1">The </param>
        /// <param name="y1">The </param>
        /// <param name="x2">The </param>
        /// <param name="y2">The </param>
        /// <param name="col">The col</param>
        /// <param name="flags">The flags</param>
        /// <returns>The bool</returns>
        public static bool DragRect(int id, ref double x1, ref double y1, ref double x2, ref double y2, Vector4 col, ImPlotDragToolFlags flags)
        {
            byte ret = ImPlotNative.ImPlot_DragRect(id, x1, y1, x2, y2, col, flags);
            return ret != 0;
        }
        
        /// <summary>
        ///     Ends the aligned plots
        /// </summary>
        public static void EndAlignedPlots()
        {
            ImPlotNative.ImPlot_EndAlignedPlots();
        }
        
        /// <summary>
        ///     Ends the drag drop source
        /// </summary>
        public static void EndDragDropSource()
        {
            ImPlotNative.ImPlot_EndDragDropSource();
        }
        
    }
}