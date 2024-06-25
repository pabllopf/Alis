// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImPlotNative.cs
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

namespace Alis.Extension.Graphic.ImGui.Extras.Plot
{
    /// <summary>
    ///     The im plot native class
    /// </summary>
    public static class ImPlotNative
    {
        /// <summary>
        ///     The dll name
        /// </summary>
        private const string DllName = "cimgui";
        
        /// <summary>
        ///     Ims the plot add colormap vec 4 ptr using the specified name
        /// </summary>
        /// <param name="name">The name</param>
        /// <param name="cols">The cols</param>
        /// <param name="size">The size</param>
        /// <param name="qual">The qual</param>
        /// <returns>The im plot colormap</returns>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ImPlot_AddColormap_Vec4Ptr")]
        public static extern ImPlotColormap ImPlot_AddColormap_Vec4Ptr(byte[] name, Vector4 cols, int size, byte qual);
        
        /// <summary>
        ///     Ims the plot add colormap u 32 ptr using the specified name
        /// </summary>
        /// <param name="name">The name</param>
        /// <param name="cols">The cols</param>
        /// <param name="size">The size</param>
        /// <param name="qual">The qual</param>
        /// <returns>The im plot colormap</returns>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ImPlot_AddColormap_U32Ptr")]
        public static extern ImPlotColormap ImPlot_AddColormap_U32Ptr(byte[] name, uint cols, int size, byte qual);
        
        /// <summary>
        ///     Ims the plot annotation bool using the specified x
        /// </summary>
        /// <param name="x">The </param>
        /// <param name="y">The </param>
        /// <param name="col">The col</param>
        /// <param name="pixOffset">The pix offset</param>
        /// <param name="clamp">The clamp</param>
        /// <param name="round">The round</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ImPlot_Annotation_Bool")]
        public static extern void ImPlot_Annotation_Bool(double x, double y, Vector4 col, Vector2 pixOffset, byte clamp, byte round);
        
        /// <summary>
        ///     Ims the plot annotation str using the specified x
        /// </summary>
        /// <param name="x">The </param>
        /// <param name="y">The </param>
        /// <param name="col">The col</param>
        /// <param name="pixOffset">The pix offset</param>
        /// <param name="clamp">The clamp</param>
        /// <param name="fmt">The fmt</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ImPlot_Annotation_Str")]
        public static extern void ImPlot_Annotation_Str(double x, double y, Vector4 col, Vector2 pixOffset, byte clamp, byte[] fmt);
        
        /// <summary>
        ///     Ims the plot begin aligned plots using the specified group id
        /// </summary>
        /// <param name="groupId">The group id</param>
        /// <param name="vertical">The vertical</param>
        /// <returns>The byte</returns>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ImPlot_BeginAlignedPlots")]
        public static extern byte ImPlot_BeginAlignedPlots(byte[] groupId, byte vertical);
        
        /// <summary>
        ///     Ims the plot begin drag drop source axis using the specified axis
        /// </summary>
        /// <param name="axis">The axis</param>
        /// <param name="flags">The flags</param>
        /// <returns>The byte</returns>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ImPlot_BeginDragDropSourceAxis")]
        public static extern byte ImPlot_BeginDragDropSourceAxis(ImAxis axis, ImGuiDragDropFlags flags);
        
        /// <summary>
        ///     Ims the plot begin drag drop source item using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="flags">The flags</param>
        /// <returns>The byte</returns>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ImPlot_BeginDragDropSourceItem")]
        public static extern byte ImPlot_BeginDragDropSourceItem(byte[] labelId, ImGuiDragDropFlags flags);
        
        /// <summary>
        ///     Ims the plot begin drag drop source plot using the specified flags
        /// </summary>
        /// <param name="flags">The flags</param>
        /// <returns>The byte</returns>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ImPlot_BeginDragDropSourcePlot")]
        public static extern byte ImPlot_BeginDragDropSourcePlot(ImGuiDragDropFlags flags);
        
        /// <summary>
        ///     Ims the plot begin drag drop target axis using the specified axis
        /// </summary>
        /// <param name="axis">The axis</param>
        /// <returns>The byte</returns>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ImPlot_BeginDragDropTargetAxis")]
        public static extern byte ImPlot_BeginDragDropTargetAxis(ImAxis axis);
        
        /// <summary>
        ///     Ims the plot begin drag drop target legend
        /// </summary>
        /// <returns>The byte</returns>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ImPlot_BeginDragDropTargetLegend")]
        public static extern byte ImPlot_BeginDragDropTargetLegend();
        
        /// <summary>
        ///     Ims the plot begin drag drop target plot
        /// </summary>
        /// <returns>The byte</returns>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ImPlot_BeginDragDropTargetPlot")]
        public static extern byte ImPlot_BeginDragDropTargetPlot();
        
        /// <summary>
        ///     Ims the plot begin legend popup using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="mouseButton">The mouse button</param>
        /// <returns>The byte</returns>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ImPlot_BeginLegendPopup")]
        public static extern byte ImPlot_BeginLegendPopup(byte[] labelId, ImGuiMouseButton mouseButton);
        
        /// <summary>
        ///     Ims the plot begin plot using the specified title id
        /// </summary>
        /// <param name="titleId">The title id</param>
        /// <param name="size">The size</param>
        /// <param name="flags">The flags</param>
        /// <returns>The byte</returns>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ImPlot_BeginPlot")]
        public static extern byte ImPlot_BeginPlot(byte[] titleId, Vector2 size, ImPlotFlags flags);
        
        /// <summary>
        ///     Ims the plot begin subplots using the specified title id
        /// </summary>
        /// <param name="titleId">The title id</param>
        /// <param name="rows">The rows</param>
        /// <param name="cols">The cols</param>
        /// <param name="size">The size</param>
        /// <param name="flags">The flags</param>
        /// <param name="rowRatios">The row ratios</param>
        /// <param name="colRatios">The col ratios</param>
        /// <returns>The byte</returns>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ImPlot_BeginSubplots")]
        public static extern byte ImPlot_BeginSubplots(byte[] titleId, int rows, int cols, Vector2 size, ImPlotSubplotFlags flags, float rowRatios, float colRatios);
        
        /// <summary>
        ///     Ims the plot bust color cache using the specified plot title id
        /// </summary>
        /// <param name="plotTitleId">The plot title id</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ImPlot_BustColorCache")]
        public static extern void ImPlot_BustColorCache(byte[] plotTitleId);
        
        /// <summary>
        ///     Ims the plot cancel plot selection
        /// </summary>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ImPlot_CancelPlotSelection")]
        public static extern void ImPlot_CancelPlotSelection();
        
        /// <summary>
        ///     Ims the plot colormap button using the specified label
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="size">The size</param>
        /// <param name="cmap">The cmap</param>
        /// <returns>The byte</returns>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ImPlot_ColormapButton")]
        public static extern byte ImPlot_ColormapButton(byte[] label, Vector2 size, ImPlotColormap cmap);
        
        /// <summary>
        ///     Ims the plot colormap icon using the specified cmap
        /// </summary>
        /// <param name="cmap">The cmap</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ImPlot_ColormapIcon")]
        public static extern void ImPlot_ColormapIcon(ImPlotColormap cmap);
        
        /// <summary>
        ///     Ims the plot colormap scale using the specified label
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="scaleMin">The scale min</param>
        /// <param name="scaleMax">The scale max</param>
        /// <param name="size">The size</param>
        /// <param name="format">The format</param>
        /// <param name="flags">The flags</param>
        /// <param name="cmap">The cmap</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ImPlot_ColormapScale")]
        public static extern void ImPlot_ColormapScale(byte[] label, double scaleMin, double scaleMax, Vector2 size, byte[] format, ImPlotColormapScaleFlags flags, ImPlotColormap cmap);
        
        /// <summary>
        ///     Ims the plot colormap slider using the specified label
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="t">The </param>
        /// <param name="out">The out</param>
        /// <param name="format">The format</param>
        /// <param name="cmap">The cmap</param>
        /// <returns>The byte</returns>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ImPlot_ColormapSlider")]
        public static extern byte ImPlot_ColormapSlider(byte[] label, float t, out Vector4 @out, byte[] format, ImPlotColormap cmap);
        
        /// <summary>
        ///     Ims the plot create context
        /// </summary>
        /// <returns>The int ptr</returns>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ImPlot_CreateContext")]
        public static extern IntPtr ImPlot_CreateContext();
        
        /// <summary>
        ///     Ims the plot destroy context using the specified ctx
        /// </summary>
        /// <param name="ctx">The ctx</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ImPlot_DestroyContext")]
        public static extern void ImPlot_DestroyContext(IntPtr ctx);
        
        /// <summary>
        ///     Ims the plot drag line x using the specified id
        /// </summary>
        /// <param name="id">The id</param>
        /// <param name="x">The </param>
        /// <param name="col">The col</param>
        /// <param name="thickness">The thickness</param>
        /// <param name="flags">The flags</param>
        /// <returns>The byte</returns>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ImPlot_DragLineX")]
        public static extern byte ImPlot_DragLineX(int id, double x, Vector4 col, float thickness, ImPlotDragToolFlags flags);
        
        /// <summary>
        ///     Ims the plot drag line y using the specified id
        /// </summary>
        /// <param name="id">The id</param>
        /// <param name="y">The </param>
        /// <param name="col">The col</param>
        /// <param name="thickness">The thickness</param>
        /// <param name="flags">The flags</param>
        /// <returns>The byte</returns>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ImPlot_DragLineY")]
        public static extern byte ImPlot_DragLineY(int id, double y, Vector4 col, float thickness, ImPlotDragToolFlags flags);
        
        /// <summary>
        ///     Ims the plot drag point using the specified id
        /// </summary>
        /// <param name="id">The id</param>
        /// <param name="x">The </param>
        /// <param name="y">The </param>
        /// <param name="col">The col</param>
        /// <param name="size">The size</param>
        /// <param name="flags">The flags</param>
        /// <returns>The byte</returns>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ImPlot_DragPoint")]
        public static extern byte ImPlot_DragPoint(int id, double x, double y, Vector4 col, float size, ImPlotDragToolFlags flags);
        
        /// <summary>
        ///     Ims the plot drag rect using the specified id
        /// </summary>
        /// <param name="id">The id</param>
        /// <param name="x1">The </param>
        /// <param name="y1">The </param>
        /// <param name="x2">The </param>
        /// <param name="y2">The </param>
        /// <param name="col">The col</param>
        /// <param name="flags">The flags</param>
        /// <returns>The byte</returns>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ImPlot_DragRect")]
        public static extern byte ImPlot_DragRect(int id, double x1, double y1, double x2, double y2, Vector4 col, ImPlotDragToolFlags flags);
        
        /// <summary>
        ///     Ims the plot end aligned plots
        /// </summary>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ImPlot_EndAlignedPlots")]
        public static extern void ImPlot_EndAlignedPlots();
        
        /// <summary>
        ///     Ims the plot end drag drop source
        /// </summary>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ImPlot_EndDragDropSource")]
        public static extern void ImPlot_EndDragDropSource();
        
        /// <summary>
        ///     Ims the plot end drag drop target
        /// </summary>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ImPlot_EndDragDropTarget")]
        public static extern void ImPlot_EndDragDropTarget();
        
        /// <summary>
        ///     Ims the plot end legend popup
        /// </summary>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ImPlot_EndLegendPopup")]
        public static extern void ImPlot_EndLegendPopup();
        
        /// <summary>
        ///     Ims the plot end plot
        /// </summary>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ImPlot_EndPlot")]
        public static extern void ImPlot_EndPlot();
        
        /// <summary>
        ///     Ims the plot end subplots
        /// </summary>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ImPlot_EndSubplots")]
        public static extern void ImPlot_EndSubplots();
        
        /// <summary>
        ///     Ims the plot get colormap color using the specified p out
        /// </summary>
        /// <param name="pOut">The out</param>
        /// <param name="idx">The idx</param>
        /// <param name="cmap">The cmap</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ImPlot_GetColormapColor")]
        public static extern void ImPlot_GetColormapColor(out Vector4 pOut, int idx, ImPlotColormap cmap);
        
        /// <summary>
        ///     Ims the plot get colormap count
        /// </summary>
        /// <returns>The int</returns>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ImPlot_GetColormapCount")]
        public static extern int ImPlot_GetColormapCount();
        
        /// <summary>
        ///     Ims the plot get colormap index using the specified name
        /// </summary>
        /// <param name="name">The name</param>
        /// <returns>The im plot colormap</returns>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ImPlot_GetColormapIndex")]
        public static extern ImPlotColormap ImPlot_GetColormapIndex(byte[] name);
        
        /// <summary>
        ///     Ims the plot get colormap name using the specified cmap
        /// </summary>
        /// <param name="cmap">The cmap</param>
        /// <returns>The byte</returns>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ImPlot_GetColormapName")]
        public static extern byte[] ImPlot_GetColormapName(ImPlotColormap cmap);
        
        /// <summary>
        ///     Ims the plot get colormap size using the specified cmap
        /// </summary>
        /// <param name="cmap">The cmap</param>
        /// <returns>The int</returns>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ImPlot_GetColormapSize")]
        public static extern int ImPlot_GetColormapSize(ImPlotColormap cmap);
        
        /// <summary>
        ///     Ims the plot get current context
        /// </summary>
        /// <returns>The int ptr</returns>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ImPlot_GetCurrentContext")]
        public static extern IntPtr ImPlot_GetCurrentContext();
        
        /// <summary>
        ///     Ims the plot get input map
        /// </summary>
        /// <returns>The im plot input map</returns>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ImPlot_GetColormapIndex")]
        public static extern ImPlotInputMap ImPlot_GetInputMap();
        
        /// <summary>
        ///     Ims the plot get last item color using the specified p out
        /// </summary>
        /// <param name="pOut">The out</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ImPlot_GetLastItemColor")]
        public static extern void ImPlot_GetLastItemColor(out Vector4 pOut);
        
        /// <summary>
        ///     Ims the plot get marker name using the specified idx
        /// </summary>
        /// <param name="idx">The idx</param>
        /// <returns>The byte</returns>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ImPlot_GetMarkerName")]
        public static extern byte[] ImPlot_GetMarkerName(ImPlotMarker idx);
        
        /// <summary>
        ///     Ims the plot get plot draw list
        /// </summary>
        /// <returns>The im draw list</returns>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ImPlot_GetPlotDrawList")]
        public static extern ImDrawList ImPlot_GetPlotDrawList();
        
        /// <summary>
        ///     Ims the plot get plot limits using the specified x axis
        /// </summary>
        /// <param name="xAxis">The axis</param>
        /// <param name="yAxis">The axis</param>
        /// <returns>The im plot rect</returns>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ImPlot_GetPlotLimits")]
        public static extern ImPlotRect ImPlot_GetPlotLimits(ImAxis xAxis, ImAxis yAxis);
        
        /// <summary>
        ///     Ims the plot get plot mouse pos using the specified p out
        /// </summary>
        /// <param name="pOut">The out</param>
        /// <param name="xAxis">The axis</param>
        /// <param name="yAxis">The axis</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ImPlot_GetPlotMousePos")]
        public static extern void ImPlot_GetPlotMousePos(out ImPlotPoint pOut, ImAxis xAxis, ImAxis yAxis);
        
        /// <summary>
        ///     Ims the plot get plot pos using the specified p out
        /// </summary>
        /// <param name="pOut">The out</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ImPlot_GetPlotPos")]
        public static extern void ImPlot_GetPlotPos(out Vector2 pOut);
        
        /// <summary>
        ///     Ims the plot get plot selection using the specified x axis
        /// </summary>
        /// <param name="xAxis">The axis</param>
        /// <param name="yAxis">The axis</param>
        /// <returns>The im plot rect</returns>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ImPlot_GetPlotSelection")]
        public static extern ImPlotRect ImPlot_GetPlotSelection(ImAxis xAxis, ImAxis yAxis);
        
        /// <summary>
        ///     Ims the plot get plot size using the specified p out
        /// </summary>
        /// <param name="pOut">The out</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ImPlot_GetPlotSize")]
        public static extern void ImPlot_GetPlotSize(out Vector2 pOut);
        
        /// <summary>
        ///     Ims the plot get style
        /// </summary>
        /// <returns>The im plot style</returns>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ImPlot_GetStyle")]
        public static extern ImPlotStyle ImPlot_GetStyle();
        
        /// <summary>
        ///     Ims the plot get style color name using the specified idx
        /// </summary>
        /// <param name="idx">The idx</param>
        /// <returns>The byte</returns>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ImPlot_GetStyleColorName")]
        public static extern byte[] ImPlot_GetStyleColorName(ImPlotCol idx);
        
        /// <summary>
        ///     Ims the plot hide next item using the specified hidden
        /// </summary>
        /// <param name="hidden">The hidden</param>
        /// <param name="cond">The cond</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ImPlot_HideNextItem")]
        public static extern void ImPlot_HideNextItem(byte hidden, ImPlotCond cond);
        
        /// <summary>
        ///     Ims the plot is axis hovered using the specified axis
        /// </summary>
        /// <param name="axis">The axis</param>
        /// <returns>The byte</returns>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ImPlot_IsAxisHovered")]
        public static extern byte ImPlot_IsAxisHovered(ImAxis axis);
        
        /// <summary>
        ///     Ims the plot is legend entry hovered using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <returns>The byte</returns>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ImPlot_IsLegendEntryHovered")]
        public static extern byte ImPlot_IsLegendEntryHovered(byte[] labelId);
        
        /// <summary>
        ///     Ims the plot is plot hovered
        /// </summary>
        /// <returns>The byte</returns>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ImPlot_IsPlotHovered")]
        public static extern byte ImPlot_IsPlotHovered();
        
        /// <summary>
        ///     Ims the plot is plot selected
        /// </summary>
        /// <returns>The byte</returns>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ImPlot_IsPlotSelected")]
        public static extern byte ImPlot_IsPlotSelected();
        
        /// <summary>
        ///     Ims the plot is subplots hovered
        /// </summary>
        /// <returns>The byte</returns>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ImPlot_IsSubplotsHovered")]
        public static extern byte ImPlot_IsSubplotsHovered();
        
        /// <summary>
        ///     Ims the plot item icon vec 4 using the specified col
        /// </summary>
        /// <param name="col">The col</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ImPlot_ItemIcon_Vec4")]
        public static extern void ImPlot_ItemIcon_Vec4(Vector4 col);
        
        /// <summary>
        ///     Ims the plot item icon u 32 using the specified col
        /// </summary>
        /// <param name="col">The col</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ImPlot_ItemIcon_U32")]
        public static extern void ImPlot_ItemIcon_U32(uint col);
        
        /// <summary>
        ///     Ims the plot map input default using the specified dst
        /// </summary>
        /// <param name="dst">The dst</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ImPlot_MapInputDefault")]
        public static extern void ImPlot_MapInputDefault(ImPlotInputMap dst);
        
        /// <summary>
        ///     Ims the plot map input reverse using the specified dst
        /// </summary>
        /// <param name="dst">The dst</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ImPlot_MapInputReverse")]
        public static extern void ImPlot_MapInputReverse(ImPlotInputMap dst);
        
        /// <summary>
        ///     Ims the plot next colormap color using the specified p out
        /// </summary>
        /// <param name="pOut">The out</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ImPlot_NextColormapColor")]
        public static extern void ImPlot_NextColormapColor(out Vector4 pOut);
        
        /// <summary>
        ///     Ims the plot pixels to plot vec 2 using the specified p out
        /// </summary>
        /// <param name="pOut">The out</param>
        /// <param name="pix">The pix</param>
        /// <param name="xAxis">The axis</param>
        /// <param name="yAxis">The axis</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ImPlot_PixelsToPlot_Vec2")]
        public static extern void ImPlot_PixelsToPlot_Vec2(out ImPlotPoint pOut, Vector2 pix, ImAxis xAxis, ImAxis yAxis);
        
        /// <summary>
        ///     Ims the plot pixels to plot float using the specified p out
        /// </summary>
        /// <param name="pOut">The out</param>
        /// <param name="x">The </param>
        /// <param name="y">The </param>
        /// <param name="xAxis">The axis</param>
        /// <param name="yAxis">The axis</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ImPlot_PixelsToPlot_Float")]
        public static extern void ImPlot_PixelsToPlot_Float(out ImPlotPoint pOut, float x, float y, ImAxis xAxis, ImAxis yAxis);
        
        /// <summary>
        ///     Ims the plot plot bar groups float ptr using the specified label ids
        /// </summary>
        /// <param name="labelIds">The label ids</param>
        /// <param name="values">The values</param>
        /// <param name="itemCount">The item count</param>
        /// <param name="groupCount">The group count</param>
        /// <param name="groupSize">The group size</param>
        /// <param name="shift">The shift</param>
        /// <param name="flags">The flags</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ImPlot_PlotBarGroups_FloatPtr")]
        public static extern void ImPlot_PlotBarGroups_FloatPtr(byte[][] labelIds, float[] values, int itemCount, int groupCount, double groupSize, double shift, ImPlotBarGroupsFlags flags);
        
        /// <summary>
        ///     Ims the plot plot bar groups double ptr using the specified label ids
        /// </summary>
        /// <param name="labelIds">The label ids</param>
        /// <param name="values">The values</param>
        /// <param name="itemCount">The item count</param>
        /// <param name="groupCount">The group count</param>
        /// <param name="groupSize">The group size</param>
        /// <param name="shift">The shift</param>
        /// <param name="flags">The flags</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ImPlot_PlotBarGroups_doublePtr")]
        public static extern void ImPlot_PlotBarGroups_doublePtr(byte[][] labelIds, double[] values, int itemCount, int groupCount, double groupSize, double shift, ImPlotBarGroupsFlags flags);
        
        /// <summary>
        ///     Ims the plot plot bar groups s 8 ptr using the specified label ids
        /// </summary>
        /// <param name="labelIds">The label ids</param>
        /// <param name="values">The values</param>
        /// <param name="itemCount">The item count</param>
        /// <param name="groupCount">The group count</param>
        /// <param name="groupSize">The group size</param>
        /// <param name="shift">The shift</param>
        /// <param name="flags">The flags</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ImPlot_PlotBarGroups_S8Ptr")]
        public static extern void ImPlot_PlotBarGroups_S8Ptr(byte[][] labelIds, sbyte[] values, int itemCount, int groupCount, double groupSize, double shift, ImPlotBarGroupsFlags flags);
        
        /// <summary>
        ///     Ims the plot plot bar groups u 8 ptr using the specified label ids
        /// </summary>
        /// <param name="labelIds">The label ids</param>
        /// <param name="values">The values</param>
        /// <param name="itemCount">The item count</param>
        /// <param name="groupCount">The group count</param>
        /// <param name="groupSize">The group size</param>
        /// <param name="shift">The shift</param>
        /// <param name="flags">The flags</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ImPlot_PlotBarGroups_U8Ptr")]
        public static extern void ImPlot_PlotBarGroups_U8Ptr(byte[][] labelIds, byte[] values, int itemCount, int groupCount, double groupSize, double shift, ImPlotBarGroupsFlags flags);
        
        /// <summary>
        ///     Ims the plot plot bar groups s 16 ptr using the specified label ids
        /// </summary>
        /// <param name="labelIds">The label ids</param>
        /// <param name="values">The values</param>
        /// <param name="itemCount">The item count</param>
        /// <param name="groupCount">The group count</param>
        /// <param name="groupSize">The group size</param>
        /// <param name="shift">The shift</param>
        /// <param name="flags">The flags</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ImPlot_PlotBarGroups_S16Ptr")]
        public static extern void ImPlot_PlotBarGroups_S16Ptr(byte[][] labelIds, short[] values, int itemCount, int groupCount, double groupSize, double shift, ImPlotBarGroupsFlags flags);
        
        /// <summary>
        ///     Ims the plot plot bar groups u 16 ptr using the specified label ids
        /// </summary>
        /// <param name="labelIds">The label ids</param>
        /// <param name="values">The values</param>
        /// <param name="itemCount">The item count</param>
        /// <param name="groupCount">The group count</param>
        /// <param name="groupSize">The group size</param>
        /// <param name="shift">The shift</param>
        /// <param name="flags">The flags</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ImPlot_PlotBarGroups_U16Ptr")]
        public static extern void ImPlot_PlotBarGroups_U16Ptr(byte[][] labelIds, ushort[] values, int itemCount, int groupCount, double groupSize, double shift, ImPlotBarGroupsFlags flags);
        
        /// <summary>
        ///     Ims the plot plot bar groups s 32 ptr using the specified label ids
        /// </summary>
        /// <param name="labelIds">The label ids</param>
        /// <param name="values">The values</param>
        /// <param name="itemCount">The item count</param>
        /// <param name="groupCount">The group count</param>
        /// <param name="groupSize">The group size</param>
        /// <param name="shift">The shift</param>
        /// <param name="flags">The flags</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ImPlot_PlotBarGroups_S32Ptr")]
        public static extern void ImPlot_PlotBarGroups_S32Ptr(byte[][] labelIds, int[] values, int itemCount, int groupCount, double groupSize, double shift, ImPlotBarGroupsFlags flags);
        
        /// <summary>
        ///     Ims the plot plot bar groups u 32 ptr using the specified label ids
        /// </summary>
        /// <param name="labelIds">The label ids</param>
        /// <param name="values">The values</param>
        /// <param name="itemCount">The item count</param>
        /// <param name="groupCount">The group count</param>
        /// <param name="groupSize">The group size</param>
        /// <param name="shift">The shift</param>
        /// <param name="flags">The flags</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ImPlot_PlotBarGroups_U32Ptr")]
        public static extern void ImPlot_PlotBarGroups_U32Ptr(byte[][] labelIds, uint[] values, int itemCount, int groupCount, double groupSize, double shift, ImPlotBarGroupsFlags flags);
        
        /// <summary>
        ///     Ims the plot plot bar groups s 64 ptr using the specified label ids
        /// </summary>
        /// <param name="labelIds">The label ids</param>
        /// <param name="values">The values</param>
        /// <param name="itemCount">The item count</param>
        /// <param name="groupCount">The group count</param>
        /// <param name="groupSize">The group size</param>
        /// <param name="shift">The shift</param>
        /// <param name="flags">The flags</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ImPlot_PlotBarGroups_S64Ptr")]
        public static extern void ImPlot_PlotBarGroups_S64Ptr(byte[][] labelIds, long[] values, int itemCount, int groupCount, double groupSize, double shift, ImPlotBarGroupsFlags flags);
        
        /// <summary>
        ///     Ims the plot plot bar groups u 64 ptr using the specified label ids
        /// </summary>
        /// <param name="labelIds">The label ids</param>
        /// <param name="values">The values</param>
        /// <param name="itemCount">The item count</param>
        /// <param name="groupCount">The group count</param>
        /// <param name="groupSize">The group size</param>
        /// <param name="shift">The shift</param>
        /// <param name="flags">The flags</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ImPlot_PlotBarGroups_U64Ptr")]
        public static extern void ImPlot_PlotBarGroups_U64Ptr(byte[][] labelIds, ulong[] values, int itemCount, int groupCount, double groupSize, double shift, ImPlotBarGroupsFlags flags);
        
        /// <summary>
        ///     Ims the plot plot bars float ptr int using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="barSize">The bar size</param>
        /// <param name="shift">The shift</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        /// <param name="stride">The stride</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ImPlot_PlotBars_FloatPtrInt")]
        public static extern void ImPlot_PlotBars_FloatPtrInt(byte[] labelId, float[] values, int count, double barSize, double shift, ImPlotBarsFlags flags, int offset, int stride);
        
        /// <summary>
        ///     Ims the plot plot bars double ptr int using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="barSize">The bar size</param>
        /// <param name="shift">The shift</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        /// <param name="stride">The stride</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ImPlot_PlotBars_doublePtrInt")]
        public static extern void ImPlot_PlotBars_doublePtrInt(byte[] labelId, double[] values, int count, double barSize, double shift, ImPlotBarsFlags flags, int offset, int stride);
        
        /// <summary>
        ///     Ims the plot plot bars s 8 ptr int using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="barSize">The bar size</param>
        /// <param name="shift">The shift</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        /// <param name="stride">The stride</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ImPlot_PlotBars_S8PtrInt")]
        public static extern void ImPlot_PlotBars_S8PtrInt(byte[] labelId, sbyte[] values, int count, double barSize, double shift, ImPlotBarsFlags flags, int offset, int stride);
        
        /// <summary>
        ///     Ims the plot plot bars u 8 ptr int using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="barSize">The bar size</param>
        /// <param name="shift">The shift</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        /// <param name="stride">The stride</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ImPlot_PlotBars_U8PtrInt")]
        public static extern void ImPlot_PlotBars_U8PtrInt(byte[] labelId, byte[] values, int count, double barSize, double shift, ImPlotBarsFlags flags, int offset, int stride);
        
        /// <summary>
        ///     Ims the plot plot bars s 16 ptr int using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="barSize">The bar size</param>
        /// <param name="shift">The shift</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        /// <param name="stride">The stride</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ImPlot_PlotBars_S16PtrInt")]
        public static extern void ImPlot_PlotBars_S16PtrInt(byte[] labelId, short[] values, int count, double barSize, double shift, ImPlotBarsFlags flags, int offset, int stride);
        
        /// <summary>
        ///     Ims the plot plot bars u 16 ptr int using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="barSize">The bar size</param>
        /// <param name="shift">The shift</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        /// <param name="stride">The stride</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ImPlot_PlotBars_U16PtrInt")]
        public static extern void ImPlot_PlotBars_U16PtrInt(byte[] labelId, ushort[] values, int count, double barSize, double shift, ImPlotBarsFlags flags, int offset, int stride);
        
        /// <summary>
        ///     Ims the plot plot bars s 32 ptr int using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="barSize">The bar size</param>
        /// <param name="shift">The shift</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        /// <param name="stride">The stride</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ImPlot_PlotBars_S32PtrInt")]
        public static extern void ImPlot_PlotBars_S32PtrInt(byte[] labelId, int[] values, int count, double barSize, double shift, ImPlotBarsFlags flags, int offset, int stride);
        
        /// <summary>
        ///     Ims the plot plot bars u 32 ptr int using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="barSize">The bar size</param>
        /// <param name="shift">The shift</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        /// <param name="stride">The stride</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ImPlot_PlotBars_U32PtrInt")]
        public static extern void ImPlot_PlotBars_U32PtrInt(byte[] labelId, uint[] values, int count, double barSize, double shift, ImPlotBarsFlags flags, int offset, int stride);
        
        /// <summary>
        ///     Ims the plot plot bars s 64 ptr int using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="barSize">The bar size</param>
        /// <param name="shift">The shift</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        /// <param name="stride">The stride</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ImPlot_PlotBars_S64PtrInt")]
        public static extern void ImPlot_PlotBars_S64PtrInt(byte[] labelId, long[] values, int count, double barSize, double shift, ImPlotBarsFlags flags, int offset, int stride);
        
        /// <summary>
        ///     Ims the plot plot bars u 64 ptr int using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="barSize">The bar size</param>
        /// <param name="shift">The shift</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        /// <param name="stride">The stride</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ImPlot_PlotBars_U64PtrInt")]
        public static extern void ImPlot_PlotBars_U64PtrInt(byte[] labelId, ulong[] values, int count, double barSize, double shift, ImPlotBarsFlags flags, int offset, int stride);
        
        /// <summary>
        ///     Ims the plot plot bars float ptr float ptr using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="count">The count</param>
        /// <param name="barSize">The bar size</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        /// <param name="stride">The stride</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ImPlot_PlotBars_FloatPtrFloatPtr")]
        public static extern void ImPlot_PlotBars_FloatPtrFloatPtr(byte[] labelId, ref float xs, ref float ys, int count, double barSize, ImPlotBarsFlags flags, int offset, int stride);
        
        /// <summary>
        ///     Ims the plot plot bars double ptrdouble ptr using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="count">The count</param>
        /// <param name="barSize">The bar size</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        /// <param name="stride">The stride</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ImPlot_PlotBars_doublePtrdoublePtr")]
        public static extern void ImPlot_PlotBars_doublePtrdoublePtr(byte[] labelId, ref double xs, ref double ys, int count, double barSize, ImPlotBarsFlags flags, int offset, int stride);
        
        /// <summary>
        ///     Ims the plot plot bars s 8 ptr s 8 ptr using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="count">The count</param>
        /// <param name="barSize">The bar size</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        /// <param name="stride">The stride</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ImPlot_PlotBars_S8PtrS8Ptr")]
        public static extern void ImPlot_PlotBars_S8PtrS8Ptr(byte[] labelId, ref sbyte xs, ref sbyte ys, int count, double barSize, ImPlotBarsFlags flags, int offset, int stride);
        
        /// <summary>
        ///     Ims the plot plot bars u 8 ptr u 8 ptr using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="count">The count</param>
        /// <param name="barSize">The bar size</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        /// <param name="stride">The stride</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ImPlot_PlotBars_U8PtrU8Ptr")]
        public static extern void ImPlot_PlotBars_U8PtrU8Ptr(byte[] labelId, ref byte xs, ref byte ys, int count, double barSize, ImPlotBarsFlags flags, int offset, int stride);
        
        /// <summary>
        ///     Ims the plot plot bars s 16 ptr s 16 ptr using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="count">The count</param>
        /// <param name="barSize">The bar size</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        /// <param name="stride">The stride</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ImPlot_PlotBars_S16PtrS16Ptr")]
        public static extern void ImPlot_PlotBars_S16PtrS16Ptr(byte[] labelId, ref short xs, ref short ys, int count, double barSize, ImPlotBarsFlags flags, int offset, int stride);
        
        /// <summary>
        ///     Ims the plot plot bars u 16 ptr u 16 ptr using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="count">The count</param>
        /// <param name="barSize">The bar size</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        /// <param name="stride">The stride</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ImPlot_PlotBars_U16PtrU16Ptr")]
        public static extern void ImPlot_PlotBars_U16PtrU16Ptr(byte[] labelId, ref ushort xs, ref ushort ys, int count, double barSize, ImPlotBarsFlags flags, int offset, int stride);
        
        /// <summary>
        ///     Ims the plot plot bars s 32 ptr s 32 ptr using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="count">The count</param>
        /// <param name="barSize">The bar size</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        /// <param name="stride">The stride</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ImPlot_PlotBars_S32PtrS32Ptr")]
        public static extern void ImPlot_PlotBars_S32PtrS32Ptr(byte[] labelId, ref int xs, ref int ys, int count, double barSize, ImPlotBarsFlags flags, int offset, int stride);
        
        /// <summary>
        ///     Ims the plot plot bars u 32 ptr u 32 ptr using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="count">The count</param>
        /// <param name="barSize">The bar size</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        /// <param name="stride">The stride</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ImPlot_PlotBars_U32PtrU32Ptr")]
        public static extern void ImPlot_PlotBars_U32PtrU32Ptr(byte[] labelId, ref uint xs, ref uint ys, int count, double barSize, ImPlotBarsFlags flags, int offset, int stride);
        
        /// <summary>
        ///     Ims the plot plot bars s 64 ptr s 64 ptr using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="count">The count</param>
        /// <param name="barSize">The bar size</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        /// <param name="stride">The stride</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ImPlot_PlotBars_S64PtrS64Ptr")]
        public static extern void ImPlot_PlotBars_S64PtrS64Ptr(byte[] labelId, ref long xs, ref long ys, int count, double barSize, ImPlotBarsFlags flags, int offset, int stride);
        
        /// <summary>
        ///     Ims the plot plot bars u 64 ptr u 64 ptr using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="count">The count</param>
        /// <param name="barSize">The bar size</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        /// <param name="stride">The stride</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ImPlot_PlotBars_U64PtrU64Ptr")]
        public static extern void ImPlot_PlotBars_U64PtrU64Ptr(byte[] labelId, ref ulong xs, ref ulong ys, int count, double barSize, ImPlotBarsFlags flags, int offset, int stride);
        
        /// <summary>
        ///     Ims the plot plot bars g using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="getter">The getter</param>
        /// <param name="data">The data</param>
        /// <param name="count">The count</param>
        /// <param name="barSize">The bar size</param>
        /// <param name="flags">The flags</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ImPlot_PlotBarsG")]
        public static extern void ImPlot_PlotBarsG(byte[] labelId, IntPtr getter, IntPtr data, int count, double barSize, ImPlotBarsFlags flags);
        
        /// <summary>
        ///     Ims the plot plot digital float ptr using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="count">The count</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        /// <param name="stride">The stride</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ImPlot_PlotDigital_FloatPtr")]
        public static extern void ImPlot_PlotDigital_FloatPtr(byte[] labelId, ref float xs, ref float ys, int count, ImPlotDigitalFlags flags, int offset, int stride);
        
        /// <summary>
        ///     Ims the plot plot digital double ptr using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="count">The count</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        /// <param name="stride">The stride</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ImPlot_PlotDigital_doublePtr")]
        public static extern void ImPlot_PlotDigital_doublePtr(byte[] labelId, ref double xs, ref double ys, int count, ImPlotDigitalFlags flags, int offset, int stride);
        
        /// <summary>
        ///     Ims the plot plot digital s 8 ptr using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="count">The count</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        /// <param name="stride">The stride</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ImPlot_PlotDigital_S8Ptr")]
        public static extern void ImPlot_PlotDigital_S8Ptr(byte[] labelId, ref sbyte xs, ref sbyte ys, int count, ImPlotDigitalFlags flags, int offset, int stride);
        
        /// <summary>
        ///     Ims the plot plot digital u 8 ptr using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="count">The count</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        /// <param name="stride">The stride</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ImPlot_PlotDigital_U8Ptr")]
        public static extern void ImPlot_PlotDigital_U8Ptr(byte[] labelId, ref byte xs, ref byte ys, int count, ImPlotDigitalFlags flags, int offset, int stride);
        
        /// <summary>
        ///     Ims the plot plot digital s 16 ptr using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="count">The count</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        /// <param name="stride">The stride</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ImPlot_PlotDigital_S16Ptr")]
        public static extern void ImPlot_PlotDigital_S16Ptr(byte[] labelId, ref short xs, ref short ys, int count, ImPlotDigitalFlags flags, int offset, int stride);
        
        /// <summary>
        ///     Ims the plot plot digital u 16 ptr using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="count">The count</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        /// <param name="stride">The stride</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ImPlot_PlotDigital_U16Ptr")]
        public static extern void ImPlot_PlotDigital_U16Ptr(byte[] labelId, ref ushort xs, ref ushort ys, int count, ImPlotDigitalFlags flags, int offset, int stride);
        
        /// <summary>
        ///     Ims the plot plot digital s 32 ptr using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="count">The count</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        /// <param name="stride">The stride</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ImPlot_PlotDigital_S32Ptr")]
        public static extern void ImPlot_PlotDigital_S32Ptr(byte[] labelId, ref int xs, ref int ys, int count, ImPlotDigitalFlags flags, int offset, int stride);
        
        /// <summary>
        ///     Ims the plot plot digital u 32 ptr using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="count">The count</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        /// <param name="stride">The stride</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ImPlot_PlotDigital_U32Ptr")]
        public static extern void ImPlot_PlotDigital_U32Ptr(byte[] labelId, ref uint xs, ref uint ys, int count, ImPlotDigitalFlags flags, int offset, int stride);
        
        /// <summary>
        ///     Ims the plot plot digital s 64 ptr using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="count">The count</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        /// <param name="stride">The stride</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ImPlot_PlotDigital_S64Ptr")]
        public static extern void ImPlot_PlotDigital_S64Ptr(byte[] labelId, ref long xs, ref long ys, int count, ImPlotDigitalFlags flags, int offset, int stride);
        
        /// <summary>
        ///     Ims the plot plot digital u 64 ptr using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="count">The count</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        /// <param name="stride">The stride</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ImPlot_PlotDigital_U64Ptr")]
        public static extern void ImPlot_PlotDigital_U64Ptr(byte[] labelId, ref ulong xs, ref ulong ys, int count, ImPlotDigitalFlags flags, int offset, int stride);
        
        /// <summary>
        ///     Ims the plot plot digital g using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="getter">The getter</param>
        /// <param name="data">The data</param>
        /// <param name="count">The count</param>
        /// <param name="flags">The flags</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ImPlot_PlotDigitalG")]
        public static extern void ImPlot_PlotDigitalG(byte[] labelId, IntPtr getter, IntPtr data, int count, ImPlotDigitalFlags flags);
        
        /// <summary>
        ///     Ims the plot plot dummy using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="flags">The flags</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ImPlot_PlotDummy")]
        public static extern void ImPlot_PlotDummy(byte[] labelId, ImPlotDummyFlags flags);
        
        /// <summary>
        ///     Ims the plot plot error bars float ptr float ptr float ptr int using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="err">The err</param>
        /// <param name="count">The count</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        /// <param name="stride">The stride</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ImPlot_PlotErrorBars_FloatPtrFloatPtrFloatPtrInt")]
        public static extern void ImPlot_PlotErrorBars_FloatPtrFloatPtrFloatPtrInt(byte[] labelId, ref float xs, ref float ys, float err, int count, ImPlotErrorBarsFlags flags, int offset, int stride);
        
        /// <summary>
        ///     Ims the plot plot error bars double ptrdouble ptrdouble ptr int using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="err">The err</param>
        /// <param name="count">The count</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        /// <param name="stride">The stride</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ImPlot_PlotErrorBars_doublePtrdoublePtrdoublePtrInt")]
        public static extern void ImPlot_PlotErrorBars_doublePtrdoublePtrdoublePtrInt(byte[] labelId, ref double xs, ref double ys, double err, int count, ImPlotErrorBarsFlags flags, int offset, int stride);
        
        /// <summary>
        ///     Ims the plot plot error bars s 8 ptr s 8 ptr s 8 ptr int using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="err">The err</param>
        /// <param name="count">The count</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        /// <param name="stride">The stride</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ImPlot_PlotErrorBars_S8PtrS8PtrS8PtrInt")]
        public static extern void ImPlot_PlotErrorBars_S8PtrS8PtrS8PtrInt(byte[] labelId, ref sbyte xs, ref sbyte ys, sbyte err, int count, ImPlotErrorBarsFlags flags, int offset, int stride);
        
        /// <summary>
        ///     Ims the plot plot error bars u 8 ptr u 8 ptr u 8 ptr int using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="err">The err</param>
        /// <param name="count">The count</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        /// <param name="stride">The stride</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ImPlot_PlotErrorBars_U8PtrU8PtrU8PtrInt")]
        public static extern void ImPlot_PlotErrorBars_U8PtrU8PtrU8PtrInt(byte[] labelId, byte xs, byte ys, byte err, int count, ImPlotErrorBarsFlags flags, int offset, int stride);
        
        /// <summary>
        ///     Ims the plot plot error bars s 16 ptr s 16 ptr s 16 ptr int using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="err">The err</param>
        /// <param name="count">The count</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        /// <param name="stride">The stride</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ImPlot_PlotErrorBars_S16PtrS16PtrS16PtrInt")]
        public static extern void ImPlot_PlotErrorBars_S16PtrS16PtrS16PtrInt(byte[] labelId, short xs, short ys, short err, int count, ImPlotErrorBarsFlags flags, int offset, int stride);
        
        /// <summary>
        ///     Ims the plot plot error bars u 16 ptr u 16 ptr u 16 ptr int using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="err">The err</param>
        /// <param name="count">The count</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        /// <param name="stride">The stride</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ImPlot_PlotErrorBars_U16PtrU16PtrU16PtrInt")]
        public static extern void ImPlot_PlotErrorBars_U16PtrU16PtrU16PtrInt(byte[] labelId, ref ushort xs, ref ushort ys, ushort err, int count, ImPlotErrorBarsFlags flags, int offset, int stride);
        
        /// <summary>
        ///     Ims the plot plot error bars s 32 ptr s 32 ptr s 32 ptr int using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="err">The err</param>
        /// <param name="count">The count</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        /// <param name="stride">The stride</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ImPlot_PlotErrorBars_S32PtrS32PtrS32PtrInt")]
        public static extern void ImPlot_PlotErrorBars_S32PtrS32PtrS32PtrInt(byte[] labelId, int xs, int ys, int err, int count, ImPlotErrorBarsFlags flags, int offset, int stride);
        
        /// <summary>
        ///     Ims the plot plot error bars u 32 ptr u 32 ptr u 32 ptr int using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="err">The err</param>
        /// <param name="count">The count</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        /// <param name="stride">The stride</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ImPlot_PlotErrorBars_U32PtrU32PtrU32PtrInt")]
        public static extern void ImPlot_PlotErrorBars_U32PtrU32PtrU32PtrInt(byte[] labelId, uint xs, uint ys, uint err, int count, ImPlotErrorBarsFlags flags, int offset, int stride);
        
        /// <summary>
        ///     Ims the plot plot error bars s 64 ptr s 64 ptr s 64 ptr int using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="err">The err</param>
        /// <param name="count">The count</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        /// <param name="stride">The stride</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ImPlot_PlotErrorBars_S64PtrS64PtrS64PtrInt")]
        public static extern void ImPlot_PlotErrorBars_S64PtrS64PtrS64PtrInt(byte[] labelId, ref long xs, ref long ys, long err, int count, ImPlotErrorBarsFlags flags, int offset, int stride);
        
        /// <summary>
        ///     Ims the plot plot error bars u 64 ptr u 64 ptr u 64 ptr int using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="err">The err</param>
        /// <param name="count">The count</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        /// <param name="stride">The stride</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ImPlot_PlotErrorBars_U64PtrU64PtrU64PtrInt")]
        public static extern void ImPlot_PlotErrorBars_U64PtrU64PtrU64PtrInt(byte[] labelId, ref ulong xs, ref ulong ys, ulong err, int count, ImPlotErrorBarsFlags flags, int offset, int stride);
        
        /// <summary>
        ///     Ims the plot plot error bars float ptr float ptr float ptr float ptr using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="neg">The neg</param>
        /// <param name="pos">The pos</param>
        /// <param name="count">The count</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        /// <param name="stride">The stride</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ImPlot_PlotErrorBars_FloatPtrFloatPtrFloatPtrFloatPtr")]
        public static extern void ImPlot_PlotErrorBars_FloatPtrFloatPtrFloatPtrFloatPtr(byte[] labelId, ref float xs, ref float ys, float neg, float pos, int count, ImPlotErrorBarsFlags flags, int offset, int stride);
        
        /// <summary>
        ///     Ims the plot plot error bars double ptrdouble ptrdouble ptrdouble ptr using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="neg">The neg</param>
        /// <param name="pos">The pos</param>
        /// <param name="count">The count</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        /// <param name="stride">The stride</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ImPlot_PlotErrorBars_doublePtrdoublePtrdoublePtrdoublePtr")]
        public static extern void ImPlot_PlotErrorBars_doublePtrdoublePtrdoublePtrdoublePtr(byte[] labelId, ref double xs, ref double ys, double neg, double pos, int count, ImPlotErrorBarsFlags flags, int offset, int stride);
        
        /// <summary>
        ///     Ims the plot plot error bars s 8 ptr s 8 ptr s 8 ptr s 8 ptr using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="neg">The neg</param>
        /// <param name="pos">The pos</param>
        /// <param name="count">The count</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        /// <param name="stride">The stride</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ImPlot_PlotErrorBars_S8PtrS8PtrS8PtrS8Ptr")]
        public static extern void ImPlot_PlotErrorBars_S8PtrS8PtrS8PtrS8Ptr(byte[] labelId, ref sbyte xs, ref sbyte ys, sbyte neg, sbyte pos, int count, ImPlotErrorBarsFlags flags, int offset, int stride);
        
        /// <summary>
        ///     Ims the plot plot error bars u 8 ptr u 8 ptr u 8 ptr u 8 ptr using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="neg">The neg</param>
        /// <param name="pos">The pos</param>
        /// <param name="count">The count</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        /// <param name="stride">The stride</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ImPlot_PlotErrorBars_U8PtrU8PtrU8PtrU8Ptr")]
        public static extern void ImPlot_PlotErrorBars_U8PtrU8PtrU8PtrU8Ptr(byte[] labelId, byte xs, byte ys, byte neg, byte pos, int count, ImPlotErrorBarsFlags flags, int offset, int stride);
        
        /// <summary>
        ///     Ims the plot plot error bars s 16 ptr s 16 ptr s 16 ptr s 16 ptr using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="neg">The neg</param>
        /// <param name="pos">The pos</param>
        /// <param name="count">The count</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        /// <param name="stride">The stride</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ImPlot_PlotErrorBars_S16PtrS16PtrS16PtrS16Ptr")]
        public static extern void ImPlot_PlotErrorBars_S16PtrS16PtrS16PtrS16Ptr(byte[] labelId, short xs, short ys, short neg, short pos, int count, ImPlotErrorBarsFlags flags, int offset, int stride);
        
        /// <summary>
        ///     Ims the plot plot error bars u 16 ptr u 16 ptr u 16 ptr u 16 ptr using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="neg">The neg</param>
        /// <param name="pos">The pos</param>
        /// <param name="count">The count</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        /// <param name="stride">The stride</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ImPlot_PlotErrorBars_U16PtrU16PtrU16PtrU16Ptr")]
        public static extern void ImPlot_PlotErrorBars_U16PtrU16PtrU16PtrU16Ptr(byte[] labelId, ref ushort xs, ref ushort ys, ushort neg, ushort pos, int count, ImPlotErrorBarsFlags flags, int offset, int stride);
        
        /// <summary>
        ///     Ims the plot plot error bars s 32 ptr s 32 ptr s 32 ptr s 32 ptr using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="neg">The neg</param>
        /// <param name="pos">The pos</param>
        /// <param name="count">The count</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        /// <param name="stride">The stride</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ImPlot_PlotErrorBars_S32PtrS32PtrS32PtrS32Ptr")]
        public static extern void ImPlot_PlotErrorBars_S32PtrS32PtrS32PtrS32Ptr(byte[] labelId, int xs, int ys, int neg, int pos, int count, ImPlotErrorBarsFlags flags, int offset, int stride);
        
        /// <summary>
        ///     Ims the plot plot error bars u 32 ptr u 32 ptr u 32 ptr u 32 ptr using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="neg">The neg</param>
        /// <param name="pos">The pos</param>
        /// <param name="count">The count</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        /// <param name="stride">The stride</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ImPlot_PlotErrorBars_U32PtrU32PtrU32PtrU32Ptr")]
        public static extern void ImPlot_PlotErrorBars_U32PtrU32PtrU32PtrU32Ptr(byte[] labelId, uint xs, uint ys, uint neg, uint pos, int count, ImPlotErrorBarsFlags flags, int offset, int stride);
        
        /// <summary>
        ///     Ims the plot plot error bars s 64 ptr s 64 ptr s 64 ptr s 64 ptr using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="neg">The neg</param>
        /// <param name="pos">The pos</param>
        /// <param name="count">The count</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        /// <param name="stride">The stride</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ImPlot_PlotErrorBars_S64PtrS64PtrS64PtrS64Ptr")]
        public static extern void ImPlot_PlotErrorBars_S64PtrS64PtrS64PtrS64Ptr(byte[] labelId, ref long xs, ref long ys, long neg, long pos, int count, ImPlotErrorBarsFlags flags, int offset, int stride);
        
        /// <summary>
        ///     Ims the plot plot error bars u 64 ptr u 64 ptr u 64 ptr u 64 ptr using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="neg">The neg</param>
        /// <param name="pos">The pos</param>
        /// <param name="count">The count</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        /// <param name="stride">The stride</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ImPlot_PlotErrorBars_U64PtrU64PtrU64PtrU64Ptr")]
        public static extern void ImPlot_PlotErrorBars_U64PtrU64PtrU64PtrU64Ptr(byte[] labelId, ref ulong xs, ref ulong ys, ulong neg, ulong pos, int count, ImPlotErrorBarsFlags flags, int offset, int stride);
        
        /// <summary>
        ///     Ims the plot plot heatmap float ptr using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="rows">The rows</param>
        /// <param name="cols">The cols</param>
        /// <param name="scaleMin">The scale min</param>
        /// <param name="scaleMax">The scale max</param>
        /// <param name="labelFmt">The label fmt</param>
        /// <param name="boundsMin">The bounds min</param>
        /// <param name="boundsMax">The bounds max</param>
        /// <param name="flags">The flags</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ImPlot_PlotHeatmap_FloatPtr")]
        public static extern void ImPlot_PlotHeatmap_FloatPtr(byte[] labelId, float[] values, int rows, int cols, double scaleMin, double scaleMax, byte[] labelFmt, ImPlotPoint boundsMin, ImPlotPoint boundsMax, ImPlotHeatmapFlags flags);
        
        /// <summary>
        ///     Ims the plot plot heatmap double ptr using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="rows">The rows</param>
        /// <param name="cols">The cols</param>
        /// <param name="scaleMin">The scale min</param>
        /// <param name="scaleMax">The scale max</param>
        /// <param name="labelFmt">The label fmt</param>
        /// <param name="boundsMin">The bounds min</param>
        /// <param name="boundsMax">The bounds max</param>
        /// <param name="flags">The flags</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ImPlot_PlotHeatmap_doublePtr")]
        public static extern void ImPlot_PlotHeatmap_doublePtr(byte[] labelId, double[] values, int rows, int cols, double scaleMin, double scaleMax, byte[] labelFmt, ImPlotPoint boundsMin, ImPlotPoint boundsMax, ImPlotHeatmapFlags flags);
        
        /// <summary>
        ///     Ims the plot plot heatmap s 8 ptr using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="rows">The rows</param>
        /// <param name="cols">The cols</param>
        /// <param name="scaleMin">The scale min</param>
        /// <param name="scaleMax">The scale max</param>
        /// <param name="labelFmt">The label fmt</param>
        /// <param name="boundsMin">The bounds min</param>
        /// <param name="boundsMax">The bounds max</param>
        /// <param name="flags">The flags</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ImPlot_PlotHeatmap_S8Ptr")]
        public static extern void ImPlot_PlotHeatmap_S8Ptr(byte[] labelId, sbyte[] values, int rows, int cols, double scaleMin, double scaleMax, byte[] labelFmt, ImPlotPoint boundsMin, ImPlotPoint boundsMax, ImPlotHeatmapFlags flags);
        
        /// <summary>
        ///     Ims the plot plot heatmap u 8 ptr using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="rows">The rows</param>
        /// <param name="cols">The cols</param>
        /// <param name="scaleMin">The scale min</param>
        /// <param name="scaleMax">The scale max</param>
        /// <param name="labelFmt">The label fmt</param>
        /// <param name="boundsMin">The bounds min</param>
        /// <param name="boundsMax">The bounds max</param>
        /// <param name="flags">The flags</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ImPlot_PlotHeatmap_U8Ptr")]
        public static extern void ImPlot_PlotHeatmap_U8Ptr(byte[] labelId, byte[] values, int rows, int cols, double scaleMin, double scaleMax, byte[] labelFmt, ImPlotPoint boundsMin, ImPlotPoint boundsMax, ImPlotHeatmapFlags flags);
        
        /// <summary>
        ///     Ims the plot plot heatmap s 16 ptr using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="rows">The rows</param>
        /// <param name="cols">The cols</param>
        /// <param name="scaleMin">The scale min</param>
        /// <param name="scaleMax">The scale max</param>
        /// <param name="labelFmt">The label fmt</param>
        /// <param name="boundsMin">The bounds min</param>
        /// <param name="boundsMax">The bounds max</param>
        /// <param name="flags">The flags</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ImPlot_PlotHeatmap_S16Ptr")]
        public static extern void ImPlot_PlotHeatmap_S16Ptr(byte[] labelId, short[] values, int rows, int cols, double scaleMin, double scaleMax, byte[] labelFmt, ImPlotPoint boundsMin, ImPlotPoint boundsMax, ImPlotHeatmapFlags flags);
        
        /// <summary>
        ///     Ims the plot plot heatmap u 16 ptr using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="rows">The rows</param>
        /// <param name="cols">The cols</param>
        /// <param name="scaleMin">The scale min</param>
        /// <param name="scaleMax">The scale max</param>
        /// <param name="labelFmt">The label fmt</param>
        /// <param name="boundsMin">The bounds min</param>
        /// <param name="boundsMax">The bounds max</param>
        /// <param name="flags">The flags</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ImPlot_PlotHeatmap_U16Ptr")]
        public static extern void ImPlot_PlotHeatmap_U16Ptr(byte[] labelId, ushort[] values, int rows, int cols, double scaleMin, double scaleMax, byte[] labelFmt, ImPlotPoint boundsMin, ImPlotPoint boundsMax, ImPlotHeatmapFlags flags);
        
        /// <summary>
        ///     Ims the plot plot heatmap s 32 ptr using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="rows">The rows</param>
        /// <param name="cols">The cols</param>
        /// <param name="scaleMin">The scale min</param>
        /// <param name="scaleMax">The scale max</param>
        /// <param name="labelFmt">The label fmt</param>
        /// <param name="boundsMin">The bounds min</param>
        /// <param name="boundsMax">The bounds max</param>
        /// <param name="flags">The flags</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ImPlot_PlotHeatmap_S32Ptr")]
        public static extern void ImPlot_PlotHeatmap_S32Ptr(byte[] labelId, int[] values, int rows, int cols, double scaleMin, double scaleMax, byte[] labelFmt, ImPlotPoint boundsMin, ImPlotPoint boundsMax, ImPlotHeatmapFlags flags);
        
        /// <summary>
        ///     Ims the plot plot heatmap u 32 ptr using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="rows">The rows</param>
        /// <param name="cols">The cols</param>
        /// <param name="scaleMin">The scale min</param>
        /// <param name="scaleMax">The scale max</param>
        /// <param name="labelFmt">The label fmt</param>
        /// <param name="boundsMin">The bounds min</param>
        /// <param name="boundsMax">The bounds max</param>
        /// <param name="flags">The flags</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ImPlot_PlotHeatmap_U32Ptr")]
        public static extern void ImPlot_PlotHeatmap_U32Ptr(byte[] labelId, uint[] values, int rows, int cols, double scaleMin, double scaleMax, byte[] labelFmt, ImPlotPoint boundsMin, ImPlotPoint boundsMax, ImPlotHeatmapFlags flags);
        
        /// <summary>
        ///     Ims the plot plot heatmap s 64 ptr using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="rows">The rows</param>
        /// <param name="cols">The cols</param>
        /// <param name="scaleMin">The scale min</param>
        /// <param name="scaleMax">The scale max</param>
        /// <param name="labelFmt">The label fmt</param>
        /// <param name="boundsMin">The bounds min</param>
        /// <param name="boundsMax">The bounds max</param>
        /// <param name="flags">The flags</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ImPlot_PlotHeatmap_S64Ptr")]
        public static extern void ImPlot_PlotHeatmap_S64Ptr(byte[] labelId, long[] values, int rows, int cols, double scaleMin, double scaleMax, byte[] labelFmt, ImPlotPoint boundsMin, ImPlotPoint boundsMax, ImPlotHeatmapFlags flags);
        
        /// <summary>
        ///     Ims the plot plot heatmap u 64 ptr using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="rows">The rows</param>
        /// <param name="cols">The cols</param>
        /// <param name="scaleMin">The scale min</param>
        /// <param name="scaleMax">The scale max</param>
        /// <param name="labelFmt">The label fmt</param>
        /// <param name="boundsMin">The bounds min</param>
        /// <param name="boundsMax">The bounds max</param>
        /// <param name="flags">The flags</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ImPlot_PlotHeatmap_U64Ptr")]
        public static extern void ImPlot_PlotHeatmap_U64Ptr(byte[] labelId, ulong[] values, int rows, int cols, double scaleMin, double scaleMax, byte[] labelFmt, ImPlotPoint boundsMin, ImPlotPoint boundsMax, ImPlotHeatmapFlags flags);
        
        /// <summary>
        ///     Ims the plot plot histogram float ptr using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="bins">The bins</param>
        /// <param name="barScale">The bar scale</param>
        /// <param name="range">The range</param>
        /// <param name="flags">The flags</param>
        /// <returns>The double</returns>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ImPlot_PlotHistogram_FloatPtr")]
        public static extern double ImPlot_PlotHistogram_FloatPtr(byte[] labelId, float[] values, int count, int bins, double barScale, ImPlotRange range, ImPlotHistogramFlags flags);
        
        /// <summary>
        ///     Ims the plot plot histogram double ptr using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="bins">The bins</param>
        /// <param name="barScale">The bar scale</param>
        /// <param name="range">The range</param>
        /// <param name="flags">The flags</param>
        /// <returns>The double</returns>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ImPlot_PlotHistogram_doublePtr")]
        public static extern double ImPlot_PlotHistogram_doublePtr(byte[] labelId, double[] values, int count, int bins, double barScale, ImPlotRange range, ImPlotHistogramFlags flags);
        
        /// <summary>
        ///     Ims the plot plot histogram s 8 ptr using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="bins">The bins</param>
        /// <param name="barScale">The bar scale</param>
        /// <param name="range">The range</param>
        /// <param name="flags">The flags</param>
        /// <returns>The double</returns>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ImPlot_PlotHistogram_S8Ptr")]
        public static extern double ImPlot_PlotHistogram_S8Ptr(byte[] labelId, sbyte[] values, int count, int bins, double barScale, ImPlotRange range, ImPlotHistogramFlags flags);
        
        /// <summary>
        ///     Ims the plot plot histogram u 8 ptr using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="bins">The bins</param>
        /// <param name="barScale">The bar scale</param>
        /// <param name="range">The range</param>
        /// <param name="flags">The flags</param>
        /// <returns>The double</returns>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ImPlot_PlotHistogram_U8Ptr")]
        public static extern double ImPlot_PlotHistogram_U8Ptr(byte[] labelId, byte[] values, int count, int bins, double barScale, ImPlotRange range, ImPlotHistogramFlags flags);
        
        /// <summary>
        ///     Ims the plot plot histogram s 16 ptr using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="bins">The bins</param>
        /// <param name="barScale">The bar scale</param>
        /// <param name="range">The range</param>
        /// <param name="flags">The flags</param>
        /// <returns>The double</returns>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ImPlot_PlotHistogram_S16Ptr")]
        public static extern double ImPlot_PlotHistogram_S16Ptr(byte[] labelId, short[] values, int count, int bins, double barScale, ImPlotRange range, ImPlotHistogramFlags flags);
        
        /// <summary>
        ///     Ims the plot plot histogram u 16 ptr using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="bins">The bins</param>
        /// <param name="barScale">The bar scale</param>
        /// <param name="range">The range</param>
        /// <param name="flags">The flags</param>
        /// <returns>The double</returns>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ImPlot_PlotHistogram_U16Ptr")]
        public static extern double ImPlot_PlotHistogram_U16Ptr(byte[] labelId, ushort[] values, int count, int bins, double barScale, ImPlotRange range, ImPlotHistogramFlags flags);
        
        /// <summary>
        ///     Ims the plot plot histogram s 32 ptr using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="bins">The bins</param>
        /// <param name="barScale">The bar scale</param>
        /// <param name="range">The range</param>
        /// <param name="flags">The flags</param>
        /// <returns>The double</returns>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ImPlot_PlotHistogram_S32Ptr")]
        public static extern double ImPlot_PlotHistogram_S32Ptr(byte[] labelId, int[] values, int count, int bins, double barScale, ImPlotRange range, ImPlotHistogramFlags flags);
        
        /// <summary>
        ///     Ims the plot plot histogram u 32 ptr using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="bins">The bins</param>
        /// <param name="barScale">The bar scale</param>
        /// <param name="range">The range</param>
        /// <param name="flags">The flags</param>
        /// <returns>The double</returns>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ImPlot_PlotHistogram_U32Ptr")]
        public static extern double ImPlot_PlotHistogram_U32Ptr(byte[] labelId, uint[] values, int count, int bins, double barScale, ImPlotRange range, ImPlotHistogramFlags flags);
        
        /// <summary>
        ///     Ims the plot plot histogram s 64 ptr using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="bins">The bins</param>
        /// <param name="barScale">The bar scale</param>
        /// <param name="range">The range</param>
        /// <param name="flags">The flags</param>
        /// <returns>The double</returns>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ImPlot_PlotHistogram_S64Ptr")]
        public static extern double ImPlot_PlotHistogram_S64Ptr(byte[] labelId, long[] values, int count, int bins, double barScale, ImPlotRange range, ImPlotHistogramFlags flags);
        
        /// <summary>
        ///     Ims the plot plot histogram u 64 ptr using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="bins">The bins</param>
        /// <param name="barScale">The bar scale</param>
        /// <param name="range">The range</param>
        /// <param name="flags">The flags</param>
        /// <returns>The double</returns>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ImPlot_PlotHistogram_U64Ptr")]
        public static extern double ImPlot_PlotHistogram_U64Ptr(byte[] labelId, ulong[] values, int count, int bins, double barScale, ImPlotRange range, ImPlotHistogramFlags flags);
        
        /// <summary>
        ///     Ims the plot plot histogram 2 d float ptr using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="count">The count</param>
        /// <param name="xBins">The bins</param>
        /// <param name="yBins">The bins</param>
        /// <param name="range">The range</param>
        /// <param name="flags">The flags</param>
        /// <returns>The double</returns>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ImPlot_PlotHistogram2D_FloatPtr")]
        public static extern double ImPlot_PlotHistogram2D_FloatPtr(byte[] labelId, ref float xs, ref float ys, int count, int xBins, int yBins, ImPlotRect range, ImPlotHistogramFlags flags);
        
        /// <summary>
        ///     Ims the plot plot histogram 2 d double ptr using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="count">The count</param>
        /// <param name="xBins">The bins</param>
        /// <param name="yBins">The bins</param>
        /// <param name="range">The range</param>
        /// <param name="flags">The flags</param>
        /// <returns>The double</returns>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ImPlot_PlotHistogram2D_doublePtr")]
        public static extern double ImPlot_PlotHistogram2D_doublePtr(byte[] labelId, ref double xs, ref double ys, int count, int xBins, int yBins, ImPlotRect range, ImPlotHistogramFlags flags);
        
        /// <summary>
        ///     Ims the plot plot histogram 2 d s 8 ptr using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="count">The count</param>
        /// <param name="xBins">The bins</param>
        /// <param name="yBins">The bins</param>
        /// <param name="range">The range</param>
        /// <param name="flags">The flags</param>
        /// <returns>The double</returns>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ImPlot_PlotHistogram2D_S8Ptr")]
        public static extern double ImPlot_PlotHistogram2D_S8Ptr(byte[] labelId, ref sbyte xs, ref sbyte ys, int count, int xBins, int yBins, ImPlotRect range, ImPlotHistogramFlags flags);
        
        /// <summary>
        ///     Ims the plot plot histogram 2 d u 8 ptr using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="count">The count</param>
        /// <param name="xBins">The bins</param>
        /// <param name="yBins">The bins</param>
        /// <param name="range">The range</param>
        /// <param name="flags">The flags</param>
        /// <returns>The double</returns>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ImPlot_PlotHistogram2D_U8Ptr")]
        public static extern double ImPlot_PlotHistogram2D_U8Ptr(byte[] labelId, ref byte xs, ref byte ys, int count, int xBins, int yBins, ImPlotRect range, ImPlotHistogramFlags flags);
        
        /// <summary>
        ///     Ims the plot plot histogram 2 d s 16 ptr using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="count">The count</param>
        /// <param name="xBins">The bins</param>
        /// <param name="yBins">The bins</param>
        /// <param name="range">The range</param>
        /// <param name="flags">The flags</param>
        /// <returns>The double</returns>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ImPlot_PlotHistogram2D_S16Ptr")]
        public static extern double ImPlot_PlotHistogram2D_S16Ptr(byte[] labelId, ref short xs, ref short ys, int count, int xBins, int yBins, ImPlotRect range, ImPlotHistogramFlags flags);
        
        /// <summary>
        ///     Ims the plot plot histogram 2 d u 16 ptr using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="count">The count</param>
        /// <param name="xBins">The bins</param>
        /// <param name="yBins">The bins</param>
        /// <param name="range">The range</param>
        /// <param name="flags">The flags</param>
        /// <returns>The double</returns>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ImPlot_PlotHistogram2D_U16Ptr")]
        public static extern double ImPlot_PlotHistogram2D_U16Ptr(byte[] labelId, ref ushort xs, ref ushort ys, int count, int xBins, int yBins, ImPlotRect range, ImPlotHistogramFlags flags);
        
        /// <summary>
        ///     Ims the plot plot histogram 2 d s 32 ptr using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="count">The count</param>
        /// <param name="xBins">The bins</param>
        /// <param name="yBins">The bins</param>
        /// <param name="range">The range</param>
        /// <param name="flags">The flags</param>
        /// <returns>The double</returns>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ImPlot_PlotHistogram2D_S32Ptr")]
        public static extern double ImPlot_PlotHistogram2D_S32Ptr(byte[] labelId, ref int xs, ref int ys, int count, int xBins, int yBins, ImPlotRect range, ImPlotHistogramFlags flags);
        
        /// <summary>
        ///     Ims the plot plot histogram 2 d u 32 ptr using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="count">The count</param>
        /// <param name="xBins">The bins</param>
        /// <param name="yBins">The bins</param>
        /// <param name="range">The range</param>
        /// <param name="flags">The flags</param>
        /// <returns>The double</returns>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ImPlot_PlotHistogram2D_U32Ptr")]
        public static extern double ImPlot_PlotHistogram2D_U32Ptr(byte[] labelId, ref uint xs, ref uint ys, int count, int xBins, int yBins, ImPlotRect range, ImPlotHistogramFlags flags);
        
        /// <summary>
        ///     Ims the plot plot histogram 2 d s 64 ptr using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="count">The count</param>
        /// <param name="xBins">The bins</param>
        /// <param name="yBins">The bins</param>
        /// <param name="range">The range</param>
        /// <param name="flags">The flags</param>
        /// <returns>The double</returns>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ImPlot_PlotHistogram2D_S64Ptr")]
        public static extern double ImPlot_PlotHistogram2D_S64Ptr(byte[] labelId, ref long xs, ref long ys, int count, int xBins, int yBins, ImPlotRect range, ImPlotHistogramFlags flags);
        
        /// <summary>
        ///     Ims the plot plot histogram 2 d u 64 ptr using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="count">The count</param>
        /// <param name="xBins">The bins</param>
        /// <param name="yBins">The bins</param>
        /// <param name="range">The range</param>
        /// <param name="flags">The flags</param>
        /// <returns>The double</returns>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ImPlot_PlotHistogram2D_U64Ptr")]
        public static extern double ImPlot_PlotHistogram2D_U64Ptr(byte[] labelId, ref ulong xs, ref ulong ys, int count, int xBins, int yBins, ImPlotRect range, ImPlotHistogramFlags flags);
        
        /// <summary>
        ///     Ims the plot plot image using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="userTextureId">The user texture id</param>
        /// <param name="boundsMin">The bounds min</param>
        /// <param name="boundsMax">The bounds max</param>
        /// <param name="uv0">The uv</param>
        /// <param name="uv1">The uv</param>
        /// <param name="tintCol">The tint col</param>
        /// <param name="flags">The flags</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ImPlot_PlotImage")]
        public static extern void ImPlot_PlotImage(byte[] labelId, IntPtr userTextureId, ImPlotPoint boundsMin, ImPlotPoint boundsMax, Vector2 uv0, Vector2 uv1, Vector4 tintCol, ImPlotImageFlags flags);
        
        /// <summary>
        ///     Ims the plot plot inf lines float ptr using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        /// <param name="stride">The stride</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ImPlot_PlotInfLines_FloatPtr")]
        public static extern void ImPlot_PlotInfLines_FloatPtr(byte[] labelId, float[] values, int count, ImPlotInfLinesFlags flags, int offset, int stride);
        
        /// <summary>
        ///     Ims the plot plot inf lines double ptr using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        /// <param name="stride">The stride</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ImPlot_PlotInfLines_doublePtr")]
        public static extern void ImPlot_PlotInfLines_doublePtr(byte[] labelId, double[] values, int count, ImPlotInfLinesFlags flags, int offset, int stride);
        
        /// <summary>
        ///     Ims the plot plot inf lines s 8 ptr using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        /// <param name="stride">The stride</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ImPlot_PlotInfLines_S8Ptr")]
        public static extern void ImPlot_PlotInfLines_S8Ptr(byte[] labelId, sbyte[] values, int count, ImPlotInfLinesFlags flags, int offset, int stride);
        
        /// <summary>
        ///     Ims the plot plot inf lines u 8 ptr using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        /// <param name="stride">The stride</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ImPlot_PlotInfLines_U8Ptr")]
        public static extern void ImPlot_PlotInfLines_U8Ptr(byte[] labelId, byte[] values, int count, ImPlotInfLinesFlags flags, int offset, int stride);
        
        /// <summary>
        ///     Ims the plot plot inf lines s 16 ptr using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        /// <param name="stride">The stride</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ImPlot_PlotInfLines_S16Ptr")]
        public static extern void ImPlot_PlotInfLines_S16Ptr(byte[] labelId, short[] values, int count, ImPlotInfLinesFlags flags, int offset, int stride);
        
        /// <summary>
        ///     Ims the plot plot inf lines u 16 ptr using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        /// <param name="stride">The stride</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ImPlot_PlotInfLines_U16Ptr")]
        public static extern void ImPlot_PlotInfLines_U16Ptr(byte[] labelId, ushort[] values, int count, ImPlotInfLinesFlags flags, int offset, int stride);
        
        /// <summary>
        ///     Ims the plot plot inf lines s 32 ptr using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        /// <param name="stride">The stride</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ImPlot_PlotInfLines_S32Ptr")]
        public static extern void ImPlot_PlotInfLines_S32Ptr(byte[] labelId, int[] values, int count, ImPlotInfLinesFlags flags, int offset, int stride);
        
        /// <summary>
        ///     Ims the plot plot inf lines u 32 ptr using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        /// <param name="stride">The stride</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ImPlot_PlotInfLines_U32Ptr")]
        public static extern void ImPlot_PlotInfLines_U32Ptr(byte[] labelId, uint[] values, int count, ImPlotInfLinesFlags flags, int offset, int stride);
        
        /// <summary>
        ///     Ims the plot plot inf lines s 64 ptr using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        /// <param name="stride">The stride</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ImPlot_PlotInfLines_S64Ptr")]
        public static extern void ImPlot_PlotInfLines_S64Ptr(byte[] labelId, long[] values, int count, ImPlotInfLinesFlags flags, int offset, int stride);
        
        /// <summary>
        ///     Ims the plot plot inf lines u 64 ptr using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        /// <param name="stride">The stride</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ImPlot_PlotInfLines_U64Ptr")]
        public static extern void ImPlot_PlotInfLines_U64Ptr(byte[] labelId, ulong[] values, int count, ImPlotInfLinesFlags flags, int offset, int stride);
        
        /// <summary>
        ///     Ims the plot plot line float ptr int using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="xscale">The xscale</param>
        /// <param name="xstart">The xstart</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        /// <param name="stride">The stride</param>
        [DllImport(DllName,CallingConvention = CallingConvention.Cdecl, EntryPoint = "ImPlot_PlotLine_FloatPtrInt")]
        public static extern void ImPlot_PlotLine_FloatPtrInt(byte[] labelId, float[] values, int count, double xscale, double xstart, ImPlotLineFlags flags, int offset, int stride);
        
        /// <summary>
        ///     Ims the plot plot line double ptr int using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="xscale">The xscale</param>
        /// <param name="xstart">The xstart</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        /// <param name="stride">The stride</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ImPlot_PlotLine_doublePtrInt")]
        public static extern void ImPlot_PlotLine_doublePtrInt(byte[] labelId, double[] values, int count, double xscale, double xstart, ImPlotLineFlags flags, int offset, int stride);
        
        /// <summary>
        ///     Ims the plot plot line s 8 ptr int using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="xscale">The xscale</param>
        /// <param name="xstart">The xstart</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        /// <param name="stride">The stride</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ImPlot_PlotLine_S8PtrInt")]
        public static extern void ImPlot_PlotLine_S8PtrInt(byte[] labelId, sbyte[] values, int count, double xscale, double xstart, ImPlotLineFlags flags, int offset, int stride);
        
        /// <summary>
        ///     Ims the plot plot line u 8 ptr int using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="xscale">The xscale</param>
        /// <param name="xstart">The xstart</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        /// <param name="stride">The stride</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ImPlot_PlotLine_U8PtrInt")]
        public static extern void ImPlot_PlotLine_U8PtrInt(byte[] labelId, byte[] values, int count, double xscale, double xstart, ImPlotLineFlags flags, int offset, int stride);
        
        /// <summary>
        ///     Ims the plot plot line s 16 ptr int using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="xscale">The xscale</param>
        /// <param name="xstart">The xstart</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        /// <param name="stride">The stride</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ImPlot_PlotLine_S16PtrInt")]
        public static extern void ImPlot_PlotLine_S16PtrInt(byte[] labelId, short[] values, int count, double xscale, double xstart, ImPlotLineFlags flags, int offset, int stride);
        
        /// <summary>
        ///     Ims the plot plot line u 16 ptr int using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="xscale">The xscale</param>
        /// <param name="xstart">The xstart</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        /// <param name="stride">The stride</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ImPlot_PlotLine_U16PtrInt")]
        public static extern void ImPlot_PlotLine_U16PtrInt(byte[] labelId, ushort[] values, int count, double xscale, double xstart, ImPlotLineFlags flags, int offset, int stride);
        
        /// <summary>
        ///     Ims the plot plot line s 32 ptr int using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="xscale">The xscale</param>
        /// <param name="xstart">The xstart</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        /// <param name="stride">The stride</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ImPlot_PlotLine_S32PtrInt")]
        public static extern void ImPlot_PlotLine_S32PtrInt(byte[] labelId, int[] values, int count, double xscale, double xstart, ImPlotLineFlags flags, int offset, int stride);
        
        /// <summary>
        ///     Ims the plot plot line u 32 ptr int using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="xscale">The xscale</param>
        /// <param name="xstart">The xstart</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        /// <param name="stride">The stride</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ImPlot_PlotLine_U32PtrInt")]
        public static extern void ImPlot_PlotLine_U32PtrInt(byte[] labelId, uint[] values, int count, double xscale, double xstart, ImPlotLineFlags flags, int offset, int stride);
        
        /// <summary>
        ///     Ims the plot plot line s 64 ptr int using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="xscale">The xscale</param>
        /// <param name="xstart">The xstart</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        /// <param name="stride">The stride</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ImPlot_PlotLine_S64PtrInt")]
        public static extern void ImPlot_PlotLine_S64PtrInt(byte[] labelId, long[] values, int count, double xscale, double xstart, ImPlotLineFlags flags, int offset, int stride);
        
        /// <summary>
        ///     Ims the plot plot line u 64 ptr int using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="xscale">The xscale</param>
        /// <param name="xstart">The xstart</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        /// <param name="stride">The stride</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ImPlot_PlotLine_U64PtrInt")]
        public static extern void ImPlot_PlotLine_U64PtrInt(byte[] labelId, ulong[] values, int count, double xscale, double xstart, ImPlotLineFlags flags, int offset, int stride);
        
        /// <summary>
        ///     Ims the plot plot line float ptr float ptr using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="count">The count</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        /// <param name="stride">The stride</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ImPlot_PlotLine_FloatPtrFloatPtr")]
        public static extern void ImPlot_PlotLine_FloatPtrFloatPtr(byte[] labelId, ref float xs, ref float ys, int count, ImPlotLineFlags flags, int offset, int stride);
        
        /// <summary>
        ///     Ims the plot plot line double ptrdouble ptr using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="count">The count</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        /// <param name="stride">The stride</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ImPlot_PlotLine_doublePtrdoublePtr")]
        public static extern void ImPlot_PlotLine_doublePtrdoublePtr(byte[] labelId, ref double xs, ref double ys, int count, ImPlotLineFlags flags, int offset, int stride);
        
        /// <summary>
        ///     Ims the plot plot line s 8 ptr s 8 ptr using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="count">The count</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        /// <param name="stride">The stride</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ImPlot_PlotLine_S8PtrS8Ptr")]
        public static extern void ImPlot_PlotLine_S8PtrS8Ptr(byte[] labelId, ref sbyte xs, ref sbyte ys, int count, ImPlotLineFlags flags, int offset, int stride);
        
        /// <summary>
        ///     Ims the plot plot line u 8 ptr u 8 ptr using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="count">The count</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        /// <param name="stride">The stride</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ImPlot_PlotLine_U8PtrU8Ptr")]
        public static extern void ImPlot_PlotLine_U8PtrU8Ptr(byte[] labelId, ref byte xs, ref byte ys, int count, ImPlotLineFlags flags, int offset, int stride);
        
        /// <summary>
        ///     Ims the plot plot line s 16 ptr s 16 ptr using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="count">The count</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        /// <param name="stride">The stride</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ImPlot_PlotLine_S16PtrS16Ptr")]
        public static extern void ImPlot_PlotLine_S16PtrS16Ptr(byte[] labelId, short xs, short ys, int count, ImPlotLineFlags flags, int offset, int stride);
        
        /// <summary>
        ///     Ims the plot plot line u 16 ptr u 16 ptr using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="count">The count</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        /// <param name="stride">The stride</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ImPlot_PlotLine_U16PtrU16Ptr")]
        public static extern void ImPlot_PlotLine_U16PtrU16Ptr(byte[] labelId, ref ushort xs, ref ushort ys, int count, ImPlotLineFlags flags, int offset, int stride);
        
        /// <summary>
        ///     Ims the plot plot line s 32 ptr s 32 ptr using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="count">The count</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        /// <param name="stride">The stride</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ImPlot_PlotLine_S32PtrS32Ptr")]
        public static extern void ImPlot_PlotLine_S32PtrS32Ptr(byte[] labelId, int xs, int ys, int count, ImPlotLineFlags flags, int offset, int stride);
        
        /// <summary>
        ///     Ims the plot plot line u 32 ptr u 32 ptr using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="count">The count</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        /// <param name="stride">The stride</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ImPlot_PlotLine_U32PtrU32Ptr")]
        public static extern void ImPlot_PlotLine_U32PtrU32Ptr(byte[] labelId, uint xs, uint ys, int count, ImPlotLineFlags flags, int offset, int stride);
        
        /// <summary>
        ///     Ims the plot plot line s 64 ptr s 64 ptr using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="count">The count</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        /// <param name="stride">The stride</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ImPlot_PlotLine_S64PtrS64Ptr")]
        public static extern void ImPlot_PlotLine_S64PtrS64Ptr(byte[] labelId, ref long xs, ref long ys, int count, ImPlotLineFlags flags, int offset, int stride);
        
        /// <summary>
        ///     Ims the plot plot line u 64 ptr u 64 ptr using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="count">The count</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        /// <param name="stride">The stride</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ImPlot_PlotLine_U64PtrU64Ptr")]
        public static extern void ImPlot_PlotLine_U64PtrU64Ptr(byte[] labelId, ref ulong xs, ref ulong ys, int count, ImPlotLineFlags flags, int offset, int stride);
        
        /// <summary>
        ///     Ims the plot plot line g using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="getter">The getter</param>
        /// <param name="data">The data</param>
        /// <param name="count">The count</param>
        /// <param name="flags">The flags</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ImPlot_PlotLineG")]
        public static extern void ImPlot_PlotLineG(byte[] labelId, IntPtr getter, IntPtr data, int count, ImPlotLineFlags flags);
        
        /// <summary>
        ///     Ims the plot plot pie chart float ptr using the specified label ids
        /// </summary>
        /// <param name="labelIds">The label ids</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="x">The </param>
        /// <param name="y">The </param>
        /// <param name="radius">The radius</param>
        /// <param name="labelFmt">The label fmt</param>
        /// <param name="angle0">The angle</param>
        /// <param name="flags">The flags</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ImPlot_PlotPieChart_FloatPtr")]
        public static extern void ImPlot_PlotPieChart_FloatPtr(byte[][] labelIds, float[] values, int count, double x, double y, double radius, byte[] labelFmt, double angle0, ImPlotPieChartFlags flags);
        
        /// <summary>
        ///     Ims the plot plot pie chart double ptr using the specified label ids
        /// </summary>
        /// <param name="labelIds">The label ids</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="x">The </param>
        /// <param name="y">The </param>
        /// <param name="radius">The radius</param>
        /// <param name="labelFmt">The label fmt</param>
        /// <param name="angle0">The angle</param>
        /// <param name="flags">The flags</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ImPlot_PlotPieChart_doublePtr")]
        public static extern void ImPlot_PlotPieChart_doublePtr(byte[][] labelIds, double[] values, int count, double x, double y, double radius, byte[] labelFmt, double angle0, ImPlotPieChartFlags flags);
        
        /// <summary>
        ///     Ims the plot plot pie chart s 8 ptr using the specified label ids
        /// </summary>
        /// <param name="labelIds">The label ids</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="x">The </param>
        /// <param name="y">The </param>
        /// <param name="radius">The radius</param>
        /// <param name="labelFmt">The label fmt</param>
        /// <param name="angle0">The angle</param>
        /// <param name="flags">The flags</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ImPlot_PlotPieChart_S8Ptr")]
        public static extern void ImPlot_PlotPieChart_S8Ptr(byte[][] labelIds, sbyte[] values, int count, double x, double y, double radius, byte[] labelFmt, double angle0, ImPlotPieChartFlags flags);
        
        /// <summary>
        ///     Ims the plot plot pie chart u 8 ptr using the specified label ids
        /// </summary>
        /// <param name="labelIds">The label ids</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="x">The </param>
        /// <param name="y">The </param>
        /// <param name="radius">The radius</param>
        /// <param name="labelFmt">The label fmt</param>
        /// <param name="angle0">The angle</param>
        /// <param name="flags">The flags</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ImPlot_PlotPieChart_U8Ptr")]
        public static extern void ImPlot_PlotPieChart_U8Ptr(byte[][] labelIds, byte[] values, int count, double x, double y, double radius, byte[] labelFmt, double angle0, ImPlotPieChartFlags flags);
        
        /// <summary>
        ///     Ims the plot plot pie chart s 16 ptr using the specified label ids
        /// </summary>
        /// <param name="labelIds">The label ids</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="x">The </param>
        /// <param name="y">The </param>
        /// <param name="radius">The radius</param>
        /// <param name="labelFmt">The label fmt</param>
        /// <param name="angle0">The angle</param>
        /// <param name="flags">The flags</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ImPlot_PlotPieChart_S16Ptr")]
        public static extern void ImPlot_PlotPieChart_S16Ptr(byte[][] labelIds, short[] values, int count, double x, double y, double radius, byte[] labelFmt, double angle0, ImPlotPieChartFlags flags);
        
        /// <summary>
        ///     Ims the plot plot pie chart u 16 ptr using the specified label ids
        /// </summary>
        /// <param name="labelIds">The label ids</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="x">The </param>
        /// <param name="y">The </param>
        /// <param name="radius">The radius</param>
        /// <param name="labelFmt">The label fmt</param>
        /// <param name="angle0">The angle</param>
        /// <param name="flags">The flags</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ImPlot_PlotPieChart_U16Ptr")]
        public static extern void ImPlot_PlotPieChart_U16Ptr(byte[][] labelIds, ushort[] values, int count, double x, double y, double radius, byte[] labelFmt, double angle0, ImPlotPieChartFlags flags);
        
        /// <summary>
        ///     Ims the plot plot pie chart s 32 ptr using the specified label ids
        /// </summary>
        /// <param name="labelIds">The label ids</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="x">The </param>
        /// <param name="y">The </param>
        /// <param name="radius">The radius</param>
        /// <param name="labelFmt">The label fmt</param>
        /// <param name="angle0">The angle</param>
        /// <param name="flags">The flags</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ImPlot_PlotPieChart_S32Ptr")]
        public static extern void ImPlot_PlotPieChart_S32Ptr(byte[][] labelIds, int[] values, int count, double x, double y, double radius, byte[] labelFmt, double angle0, ImPlotPieChartFlags flags);
        
        /// <summary>
        ///     Ims the plot plot pie chart u 32 ptr using the specified label ids
        /// </summary>
        /// <param name="labelIds">The label ids</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="x">The </param>
        /// <param name="y">The </param>
        /// <param name="radius">The radius</param>
        /// <param name="labelFmt">The label fmt</param>
        /// <param name="angle0">The angle</param>
        /// <param name="flags">The flags</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ImPlot_PlotPieChart_U32Ptr")]
        public static extern void ImPlot_PlotPieChart_U32Ptr(byte[][] labelIds, uint[] values, int count, double x, double y, double radius, byte[] labelFmt, double angle0, ImPlotPieChartFlags flags);
        
        /// <summary>
        ///     Ims the plot plot pie chart s 64 ptr using the specified label ids
        /// </summary>
        /// <param name="labelIds">The label ids</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="x">The </param>
        /// <param name="y">The </param>
        /// <param name="radius">The radius</param>
        /// <param name="labelFmt">The label fmt</param>
        /// <param name="angle0">The angle</param>
        /// <param name="flags">The flags</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ImPlot_PlotPieChart_S64Ptr")]
        public static extern void ImPlot_PlotPieChart_S64Ptr(byte[][] labelIds, long[] values, int count, double x, double y, double radius, byte[] labelFmt, double angle0, ImPlotPieChartFlags flags);
        
        /// <summary>
        ///     Ims the plot plot pie chart u 64 ptr using the specified label ids
        /// </summary>
        /// <param name="labelIds">The label ids</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="x">The </param>
        /// <param name="y">The </param>
        /// <param name="radius">The radius</param>
        /// <param name="labelFmt">The label fmt</param>
        /// <param name="angle0">The angle</param>
        /// <param name="flags">The flags</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ImPlot_PlotPieChart_U64Ptr")]
        public static extern void ImPlot_PlotPieChart_U64Ptr(byte[][] labelIds, ulong[] values, int count, double x, double y, double radius, byte[] labelFmt, double angle0, ImPlotPieChartFlags flags);
        
        /// <summary>
        ///     Ims the plot plot scatter float ptr int using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="xscale">The xscale</param>
        /// <param name="xstart">The xstart</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        /// <param name="stride">The stride</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ImPlot_PlotScatter_FloatPtrInt")]
        public static extern void ImPlot_PlotScatter_FloatPtrInt(byte[] labelId, float[] values, int count, double xscale, double xstart, ImPlotScatterFlags flags, int offset, int stride);
        
        /// <summary>
        ///     Ims the plot plot scatter double ptr int using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="xscale">The xscale</param>
        /// <param name="xstart">The xstart</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        /// <param name="stride">The stride</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ImPlot_PlotScatter_doublePtrInt")]
        public static extern void ImPlot_PlotScatter_doublePtrInt(byte[] labelId, double[] values, int count, double xscale, double xstart, ImPlotScatterFlags flags, int offset, int stride);
        
        /// <summary>
        ///     Ims the plot plot scatter s 8 ptr int using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="xscale">The xscale</param>
        /// <param name="xstart">The xstart</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        /// <param name="stride">The stride</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ImPlot_PlotScatter_S8PtrInt")]
        public static extern void ImPlot_PlotScatter_S8PtrInt(byte[] labelId, sbyte[] values, int count, double xscale, double xstart, ImPlotScatterFlags flags, int offset, int stride);
        
        /// <summary>
        ///     Ims the plot plot scatter u 8 ptr int using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="xscale">The xscale</param>
        /// <param name="xstart">The xstart</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        /// <param name="stride">The stride</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ImPlot_PlotScatter_U8PtrInt")]
        public static extern void ImPlot_PlotScatter_U8PtrInt(byte[] labelId, byte[] values, int count, double xscale, double xstart, ImPlotScatterFlags flags, int offset, int stride);
        
        /// <summary>
        ///     Ims the plot plot scatter s 16 ptr int using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="xscale">The xscale</param>
        /// <param name="xstart">The xstart</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        /// <param name="stride">The stride</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ImPlot_PlotScatter_S16PtrInt")]
        public static extern void ImPlot_PlotScatter_S16PtrInt(byte[] labelId, short[] values, int count, double xscale, double xstart, ImPlotScatterFlags flags, int offset, int stride);
        
        /// <summary>
        ///     Ims the plot plot scatter u 16 ptr int using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="xscale">The xscale</param>
        /// <param name="xstart">The xstart</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        /// <param name="stride">The stride</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ImPlot_PlotScatter_U16PtrInt")]
        public static extern void ImPlot_PlotScatter_U16PtrInt(byte[] labelId, ushort[] values, int count, double xscale, double xstart, ImPlotScatterFlags flags, int offset, int stride);
        
        /// <summary>
        ///     Ims the plot plot scatter s 32 ptr int using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="xscale">The xscale</param>
        /// <param name="xstart">The xstart</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        /// <param name="stride">The stride</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ImPlot_PlotScatter_S32PtrInt")]
        public static extern void ImPlot_PlotScatter_S32PtrInt(byte[] labelId, int[] values, int count, double xscale, double xstart, ImPlotScatterFlags flags, int offset, int stride);
        
        /// <summary>
        ///     Ims the plot plot scatter u 32 ptr int using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="xscale">The xscale</param>
        /// <param name="xstart">The xstart</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        /// <param name="stride">The stride</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ImPlot_PlotScatter_U32PtrInt")]
        public static extern void ImPlot_PlotScatter_U32PtrInt(byte[] labelId, uint[] values, int count, double xscale, double xstart, ImPlotScatterFlags flags, int offset, int stride);
        
        /// <summary>
        ///     Ims the plot plot scatter s 64 ptr int using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="xscale">The xscale</param>
        /// <param name="xstart">The xstart</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        /// <param name="stride">The stride</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ImPlot_PlotScatter_S64PtrInt")]
        public static extern void ImPlot_PlotScatter_S64PtrInt(byte[] labelId, long[] values, int count, double xscale, double xstart, ImPlotScatterFlags flags, int offset, int stride);
        
        /// <summary>
        ///     Ims the plot plot scatter u 64 ptr int using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="xscale">The xscale</param>
        /// <param name="xstart">The xstart</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        /// <param name="stride">The stride</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ImPlot_PlotScatter_U64PtrInt")]
        public static extern void ImPlot_PlotScatter_U64PtrInt(byte[] labelId, ulong[] values, int count, double xscale, double xstart, ImPlotScatterFlags flags, int offset, int stride);
        
        /// <summary>
        ///     Ims the plot plot scatter float ptr float ptr using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="count">The count</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        /// <param name="stride">The stride</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ImPlot_PlotScatter_FloatPtrFloatPtr")]
        public static extern void ImPlot_PlotScatter_FloatPtrFloatPtr(byte[] labelId, ref float xs, ref float ys, int count, ImPlotScatterFlags flags, int offset, int stride);
        
        /// <summary>
        ///     Ims the plot plot scatter double ptrdouble ptr using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="count">The count</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        /// <param name="stride">The stride</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ImPlot_PlotScatter_doublePtrdoublePtr")]
        public static extern void ImPlot_PlotScatter_doublePtrdoublePtr(byte[] labelId, ref double xs, ref double ys, int count, ImPlotScatterFlags flags, int offset, int stride);
        
        /// <summary>
        ///     Ims the plot plot scatter s 8 ptr s 8 ptr using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="count">The count</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        /// <param name="stride">The stride</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ImPlot_PlotScatter_S8PtrS8Ptr")]
        public static extern void ImPlot_PlotScatter_S8PtrS8Ptr(byte[] labelId, ref sbyte xs, ref sbyte ys, int count, ImPlotScatterFlags flags, int offset, int stride);
        
        /// <summary>
        ///     Ims the plot plot scatter u 8 ptr u 8 ptr using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="count">The count</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        /// <param name="stride">The stride</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ImPlot_PlotScatter_U8PtrU8Ptr")]
        public static extern void ImPlot_PlotScatter_U8PtrU8Ptr(byte[] labelId, ref byte xs, ref byte ys, int count, ImPlotScatterFlags flags, int offset, int stride);
        
        /// <summary>
        ///     Ims the plot plot scatter s 16 ptr s 16 ptr using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="count">The count</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        /// <param name="stride">The stride</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ImPlot_PlotScatter_S16PtrS16Ptr")]
        public static extern void ImPlot_PlotScatter_S16PtrS16Ptr(byte[] labelId, ref short xs, ref short ys, int count, ImPlotScatterFlags flags, int offset, int stride);
        
        /// <summary>
        ///     Ims the plot plot scatter u 16 ptr u 16 ptr using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="count">The count</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        /// <param name="stride">The stride</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ImPlot_PlotScatter_U16PtrU16Ptr")]
        public static extern void ImPlot_PlotScatter_U16PtrU16Ptr(byte[] labelId, ref ushort xs, ref ushort ys, int count, ImPlotScatterFlags flags, int offset, int stride);
        
        /// <summary>
        ///     Ims the plot plot scatter s 32 ptr s 32 ptr using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="count">The count</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        /// <param name="stride">The stride</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ImPlot_PlotScatter_S32PtrS32Ptr")]
        public static extern void ImPlot_PlotScatter_S32PtrS32Ptr(byte[] labelId, ref int xs, ref int ys, int count, ImPlotScatterFlags flags, int offset, int stride);
        
        /// <summary>
        ///     Ims the plot plot scatter u 32 ptr u 32 ptr using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="count">The count</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        /// <param name="stride">The stride</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ImPlot_PlotScatter_U32PtrU32Ptr")]
        public static extern void ImPlot_PlotScatter_U32PtrU32Ptr(byte[] labelId, ref uint xs, ref uint ys, int count, ImPlotScatterFlags flags, int offset, int stride);
        
        /// <summary>
        ///     Ims the plot plot scatter s 64 ptr s 64 ptr using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="count">The count</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        /// <param name="stride">The stride</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ImPlot_PlotScatter_S64PtrS64Ptr")]
        public static extern void ImPlot_PlotScatter_S64PtrS64Ptr(byte[] labelId, ref long xs, ref long ys, int count, ImPlotScatterFlags flags, int offset, int stride);
        
        /// <summary>
        ///     Ims the plot plot scatter u 64 ptr u 64 ptr using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="count">The count</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        /// <param name="stride">The stride</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ImPlot_PlotScatter_U64PtrU64Ptr")]
        public static extern void ImPlot_PlotScatter_U64PtrU64Ptr(byte[] labelId,  ref ulong xs, ref ulong ys, int count, ImPlotScatterFlags flags, int offset, int stride);
        
        /// <summary>
        ///     Ims the plot plot scatter g using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="getter">The getter</param>
        /// <param name="data">The data</param>
        /// <param name="count">The count</param>
        /// <param name="flags">The flags</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ImPlot_PlotScatterG")]
        public static extern void ImPlot_PlotScatterG(byte[] labelId, IntPtr getter, IntPtr data, int count, ImPlotScatterFlags flags);
        
        /// <summary>
        ///     Ims the plot plot shaded float ptr int using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="yref">The yref</param>
        /// <param name="xscale">The xscale</param>
        /// <param name="xstart">The xstart</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        /// <param name="stride">The stride</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ImPlot_PlotShaded_FloatPtrInt")]
        public static extern void ImPlot_PlotShaded_FloatPtrInt(byte[] labelId, float[] values, int count, double yref, double xscale, double xstart, ImPlotShadedFlags flags, int offset, int stride);
        
        /// <summary>
        ///     Ims the plot plot shaded double ptr int using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="yref">The yref</param>
        /// <param name="xscale">The xscale</param>
        /// <param name="xstart">The xstart</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        /// <param name="stride">The stride</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ImPlot_PlotShaded_doublePtrInt")]
        public static extern void ImPlot_PlotShaded_doublePtrInt(byte[] labelId, double[] values, int count, double yref, double xscale, double xstart, ImPlotShadedFlags flags, int offset, int stride);
        
        /// <summary>
        ///     Ims the plot plot shaded s 8 ptr int using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="yref">The yref</param>
        /// <param name="xscale">The xscale</param>
        /// <param name="xstart">The xstart</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        /// <param name="stride">The stride</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ImPlot_PlotShaded_S8PtrInt")]
        public static extern void ImPlot_PlotShaded_S8PtrInt(byte[] labelId, sbyte[] values, int count, double yref, double xscale, double xstart, ImPlotShadedFlags flags, int offset, int stride);
        
        /// <summary>
        ///     Ims the plot plot shaded u 8 ptr int using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="yref">The yref</param>
        /// <param name="xscale">The xscale</param>
        /// <param name="xstart">The xstart</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        /// <param name="stride">The stride</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ImPlot_PlotShaded_U8PtrInt")]
        public static extern void ImPlot_PlotShaded_U8PtrInt(byte[] labelId, byte[] values, int count, double yref, double xscale, double xstart, ImPlotShadedFlags flags, int offset, int stride);
        
        /// <summary>
        ///     Ims the plot plot shaded s 16 ptr int using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="yref">The yref</param>
        /// <param name="xscale">The xscale</param>
        /// <param name="xstart">The xstart</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        /// <param name="stride">The stride</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ImPlot_PlotShaded_S16PtrInt")]
        public static extern void ImPlot_PlotShaded_S16PtrInt(byte[] labelId, short[] values, int count, double yref, double xscale, double xstart, ImPlotShadedFlags flags, int offset, int stride);
        
        /// <summary>
        ///     Ims the plot plot shaded u 16 ptr int using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="yref">The yref</param>
        /// <param name="xscale">The xscale</param>
        /// <param name="xstart">The xstart</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        /// <param name="stride">The stride</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ImPlot_PlotShaded_U16PtrInt")]
        public static extern void ImPlot_PlotShaded_U16PtrInt(byte[] labelId, ushort[] values, int count, double yref, double xscale, double xstart, ImPlotShadedFlags flags, int offset, int stride);
        
        /// <summary>
        ///     Ims the plot plot shaded s 32 ptr int using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="yref">The yref</param>
        /// <param name="xscale">The xscale</param>
        /// <param name="xstart">The xstart</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        /// <param name="stride">The stride</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ImPlot_PlotShaded_S32PtrInt")]
        public static extern void ImPlot_PlotShaded_S32PtrInt(byte[] labelId, int[] values, int count, double yref, double xscale, double xstart, ImPlotShadedFlags flags, int offset, int stride);
        
        /// <summary>
        ///     Ims the plot plot shaded u 32 ptr int using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="yref">The yref</param>
        /// <param name="xscale">The xscale</param>
        /// <param name="xstart">The xstart</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        /// <param name="stride">The stride</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ImPlot_PlotShaded_U32PtrInt")]
        public static extern void ImPlot_PlotShaded_U32PtrInt(byte[] labelId, uint[] values, int count, double yref, double xscale, double xstart, ImPlotShadedFlags flags, int offset, int stride);
        
        /// <summary>
        ///     Ims the plot plot shaded s 64 ptr int using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="yref">The yref</param>
        /// <param name="xscale">The xscale</param>
        /// <param name="xstart">The xstart</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        /// <param name="stride">The stride</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ImPlot_PlotShaded_S64PtrInt")]
        public static extern void ImPlot_PlotShaded_S64PtrInt(byte[] labelId, long[] values, int count, double yref, double xscale, double xstart, ImPlotShadedFlags flags, int offset, int stride);
        
        /// <summary>
        ///     Ims the plot plot shaded u 64 ptr int using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="yref">The yref</param>
        /// <param name="xscale">The xscale</param>
        /// <param name="xstart">The xstart</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        /// <param name="stride">The stride</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ImPlot_PlotShaded_U64PtrInt")]
        public static extern void ImPlot_PlotShaded_U64PtrInt(byte[] labelId, ulong[] values, int count, double yref, double xscale, double xstart, ImPlotShadedFlags flags, int offset, int stride);
        
        /// <summary>
        ///     Ims the plot plot shaded float ptr float ptr int using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="count">The count</param>
        /// <param name="yref">The yref</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        /// <param name="stride">The stride</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ImPlot_PlotShaded_FloatPtrFloatPtrInt")]
        public static extern void ImPlot_PlotShaded_FloatPtrFloatPtrInt(byte[] labelId, ref float xs, ref float ys, int count, double yref, ImPlotShadedFlags flags, int offset, int stride);
        
        /// <summary>
        ///     Ims the plot plot shaded double ptrdouble ptr int using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="count">The count</param>
        /// <param name="yref">The yref</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        /// <param name="stride">The stride</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ImPlot_PlotShaded_doublePtrdoublePtrInt")]
        public static extern void ImPlot_PlotShaded_doublePtrdoublePtrInt(byte[] labelId, ref double xs, ref double ys, int count, double yref, ImPlotShadedFlags flags, int offset, int stride);
        
        /// <summary>
        ///     Ims the plot plot shaded s 8 ptr s 8 ptr int using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="count">The count</param>
        /// <param name="yref">The yref</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        /// <param name="stride">The stride</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ImPlot_PlotShaded_S8PtrS8PtrInt")]
        public static extern void ImPlot_PlotShaded_S8PtrS8PtrInt(byte[] labelId, ref sbyte xs, ref sbyte ys, int count, double yref, ImPlotShadedFlags flags, int offset, int stride);
        
        /// <summary>
        ///     Ims the plot plot shaded u 8 ptr u 8 ptr int using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="count">The count</param>
        /// <param name="yref">The yref</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        /// <param name="stride">The stride</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ImPlot_PlotShaded_U8PtrU8PtrInt")]
        public static extern void ImPlot_PlotShaded_U8PtrU8PtrInt(byte[] labelId, ref byte xs, ref byte ys, int count, double yref, ImPlotShadedFlags flags, int offset, int stride);
        
        /// <summary>
        ///     Ims the plot plot shaded s 16 ptr s 16 ptr int using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="count">The count</param>
        /// <param name="yref">The yref</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        /// <param name="stride">The stride</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ImPlot_PlotShaded_S16PtrS16PtrInt")]
        public static extern void ImPlot_PlotShaded_S16PtrS16PtrInt(byte[] labelId,ref short xs, ref short ys, int count, double yref, ImPlotShadedFlags flags, int offset, int stride);
        
        /// <summary>
        ///     Ims the plot plot shaded u 16 ptr u 16 ptr int using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="count">The count</param>
        /// <param name="yref">The yref</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        /// <param name="stride">The stride</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ImPlot_PlotShaded_U16PtrU16PtrInt")]
        public static extern void ImPlot_PlotShaded_U16PtrU16PtrInt(byte[] labelId, ref ushort xs, ref ushort ys, int count, double yref, ImPlotShadedFlags flags, int offset, int stride);
        
        /// <summary>
        ///     Ims the plot plot shaded s 32 ptr s 32 ptr int using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="count">The count</param>
        /// <param name="yref">The yref</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        /// <param name="stride">The stride</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ImPlot_PlotShaded_S32PtrS32PtrInt")]
        public static extern void ImPlot_PlotShaded_S32PtrS32PtrInt(byte[] labelId, ref int xs, ref int ys, int count, double yref, ImPlotShadedFlags flags, int offset, int stride);
        
        /// <summary>
        ///     Ims the plot plot shaded u 32 ptr u 32 ptr int using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="count">The count</param>
        /// <param name="yref">The yref</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        /// <param name="stride">The stride</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ImPlot_PlotShaded_U32PtrU32PtrInt")]
        public static extern void ImPlot_PlotShaded_U32PtrU32PtrInt(byte[] labelId, ref uint xs, ref uint ys, int count, double yref, ImPlotShadedFlags flags, int offset, int stride);
        
        /// <summary>
        ///     Ims the plot plot shaded s 64 ptr s 64 ptr int using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="count">The count</param>
        /// <param name="yref">The yref</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        /// <param name="stride">The stride</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ImPlot_PlotShaded_S64PtrS64PtrInt")]
        public static extern void ImPlot_PlotShaded_S64PtrS64PtrInt(byte[] labelId, ref long xs, ref long ys, int count, double yref, ImPlotShadedFlags flags, int offset, int stride);
        
        /// <summary>
        ///     Ims the plot plot shaded u 64 ptr u 64 ptr int using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="count">The count</param>
        /// <param name="yref">The yref</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        /// <param name="stride">The stride</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ImPlot_PlotShaded_U64PtrU64PtrInt")]
        public static extern void ImPlot_PlotShaded_U64PtrU64PtrInt(byte[] labelId, ref ulong xs, ref ulong ys, int count, double yref, ImPlotShadedFlags flags, int offset, int stride);
        
        /// <summary>
        ///     Ims the plot plot shaded float ptr float ptr float ptr using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys1">The ys</param>
        /// <param name="ys2">The ys</param>
        /// <param name="count">The count</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        /// <param name="stride">The stride</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ImPlot_PlotShaded_FloatPtrFloatPtrFloatPtr")]
        public static extern void ImPlot_PlotShaded_FloatPtrFloatPtrFloatPtr(byte[] labelId, ref float xs, ref float ys1, ref float ys2, int count, ImPlotShadedFlags flags, int offset, int stride);
        
        /// <summary>
        ///     Ims the plot plot shaded double ptrdouble ptrdouble ptr using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys1">The ys</param>
        /// <param name="ys2">The ys</param>
        /// <param name="count">The count</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        /// <param name="stride">The stride</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ImPlot_PlotShaded_doublePtrdoublePtrdoublePtr")]
        public static extern void ImPlot_PlotShaded_doublePtrdoublePtrdoublePtr(byte[] labelId, ref double xs, ref double ys1, ref double ys2, int count, ImPlotShadedFlags flags, int offset, int stride);
        
        /// <summary>
        ///     Ims the plot plot shaded s 8 ptr s 8 ptr s 8 ptr using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys1">The ys</param>
        /// <param name="ys2">The ys</param>
        /// <param name="count">The count</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        /// <param name="stride">The stride</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ImPlot_PlotShaded_S8PtrS8PtrS8Ptr")]
        public static extern void ImPlot_PlotShaded_S8PtrS8PtrS8Ptr(byte[] labelId, ref sbyte xs, ref sbyte ys1, ref sbyte ys2, int count, ImPlotShadedFlags flags, int offset, int stride);
        
        /// <summary>
        ///     Ims the plot plot shaded u 8 ptr u 8 ptr u 8 ptr using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys1">The ys</param>
        /// <param name="ys2">The ys</param>
        /// <param name="count">The count</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        /// <param name="stride">The stride</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ImPlot_PlotShaded_U8PtrU8PtrU8Ptr")]
        public static extern void ImPlot_PlotShaded_U8PtrU8PtrU8Ptr(byte[] labelId, ref byte xs, ref byte ys1, ref byte ys2, int count, ImPlotShadedFlags flags, int offset, int stride);
        
        /// <summary>
        ///     Ims the plot plot shaded s 16 ptr s 16 ptr s 16 ptr using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys1">The ys</param>
        /// <param name="ys2">The ys</param>
        /// <param name="count">The count</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        /// <param name="stride">The stride</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ImPlot_PlotShaded_S16PtrS16PtrS16Ptr")]
        public static extern void ImPlot_PlotShaded_S16PtrS16PtrS16Ptr(byte[] labelId, short xs, short ys1, short ys2, int count, ImPlotShadedFlags flags, int offset, int stride);
        
        /// <summary>
        ///     Ims the plot plot shaded u 16 ptr u 16 ptr u 16 ptr using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys1">The ys</param>
        /// <param name="ys2">The ys</param>
        /// <param name="count">The count</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        /// <param name="stride">The stride</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ImPlot_PlotShaded_U16PtrU16PtrU16Ptr")]
        public static extern void ImPlot_PlotShaded_U16PtrU16PtrU16Ptr(byte[] labelId, ref ushort xs, ushort ys1, ushort ys2, int count, ImPlotShadedFlags flags, int offset, int stride);
        
        /// <summary>
        ///     Ims the plot plot shaded s 32 ptr s 32 ptr s 32 ptr using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys1">The ys</param>
        /// <param name="ys2">The ys</param>
        /// <param name="count">The count</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        /// <param name="stride">The stride</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ImPlot_PlotShaded_S32PtrS32PtrS32Ptr")]
        public static extern void ImPlot_PlotShaded_S32PtrS32PtrS32Ptr(byte[] labelId, int xs, int ys1, int ys2, int count, ImPlotShadedFlags flags, int offset, int stride);
        
        /// <summary>
        ///     Ims the plot plot shaded u 32 ptr u 32 ptr u 32 ptr using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys1">The ys</param>
        /// <param name="ys2">The ys</param>
        /// <param name="count">The count</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        /// <param name="stride">The stride</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ImPlot_PlotShaded_U32PtrU32PtrU32Ptr")]
        public static extern void ImPlot_PlotShaded_U32PtrU32PtrU32Ptr(byte[] labelId, uint xs, uint ys1, uint ys2, int count, ImPlotShadedFlags flags, int offset, int stride);
        
        /// <summary>
        ///     Ims the plot plot shaded s 64 ptr s 64 ptr s 64 ptr using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys1">The ys</param>
        /// <param name="ys2">The ys</param>
        /// <param name="count">The count</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        /// <param name="stride">The stride</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ImPlot_PlotShaded_S64PtrS64PtrS64Ptr")]
        public static extern void ImPlot_PlotShaded_S64PtrS64PtrS64Ptr(byte[] labelId, ref long xs, long ys1, long ys2, int count, ImPlotShadedFlags flags, int offset, int stride);
        
        /// <summary>
        ///     Ims the plot plot shaded u 64 ptr u 64 ptr u 64 ptr using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys1">The ys</param>
        /// <param name="ys2">The ys</param>
        /// <param name="count">The count</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        /// <param name="stride">The stride</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ImPlot_PlotShaded_U64PtrU64PtrU64Ptr")]
        public static extern void ImPlot_PlotShaded_U64PtrU64PtrU64Ptr(byte[] labelId, ref ulong xs, ulong ys1, ulong ys2, int count, ImPlotShadedFlags flags, int offset, int stride);
        
        /// <summary>
        ///     Ims the plot plot shaded g using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="getter1">The getter</param>
        /// <param name="data1">The data</param>
        /// <param name="getter2">The getter</param>
        /// <param name="data2">The data</param>
        /// <param name="count">The count</param>
        /// <param name="flags">The flags</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ImPlot_PlotShadedG")]
        public static extern void ImPlot_PlotShadedG(byte[] labelId, IntPtr getter1, IntPtr data1, IntPtr getter2, IntPtr data2, int count, ImPlotShadedFlags flags);
        
        /// <summary>
        ///     Ims the plot plot stairs float ptr int using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="xscale">The xscale</param>
        /// <param name="xstart">The xstart</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        /// <param name="stride">The stride</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ImPlot_PlotStairs_FloatPtrInt")]
        public static extern void ImPlot_PlotStairs_FloatPtrInt(byte[] labelId, float[] values, int count, double xscale, double xstart, ImPlotStairsFlags flags, int offset, int stride);
        
        /// <summary>
        ///     Ims the plot plot stairs double ptr int using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="xscale">The xscale</param>
        /// <param name="xstart">The xstart</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        /// <param name="stride">The stride</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ImPlot_PlotStairs_doublePtrInt")]
        public static extern void ImPlot_PlotStairs_doublePtrInt(byte[] labelId, double[] values, int count, double xscale, double xstart, ImPlotStairsFlags flags, int offset, int stride);
        
        /// <summary>
        ///     Ims the plot plot stairs s 8 ptr int using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="xscale">The xscale</param>
        /// <param name="xstart">The xstart</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        /// <param name="stride">The stride</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ImPlot_PlotStairs_S8PtrInt")]
        public static extern void ImPlot_PlotStairs_S8PtrInt(byte[] labelId, sbyte[] values, int count, double xscale, double xstart, ImPlotStairsFlags flags, int offset, int stride);
        
        /// <summary>
        ///     Ims the plot plot stairs u 8 ptr int using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="xscale">The xscale</param>
        /// <param name="xstart">The xstart</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        /// <param name="stride">The stride</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ImPlot_PlotStairs_U8PtrInt")]
        public static extern void ImPlot_PlotStairs_U8PtrInt(byte[] labelId, byte[] values, int count, double xscale, double xstart, ImPlotStairsFlags flags, int offset, int stride);
        
        /// <summary>
        ///     Ims the plot plot stairs s 16 ptr int using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="xscale">The xscale</param>
        /// <param name="xstart">The xstart</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        /// <param name="stride">The stride</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ImPlot_PlotStairs_S16PtrInt")]
        public static extern void ImPlot_PlotStairs_S16PtrInt(byte[] labelId, short[] values, int count, double xscale, double xstart, ImPlotStairsFlags flags, int offset, int stride);
        
        /// <summary>
        ///     Ims the plot plot stairs u 16 ptr int using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="xscale">The xscale</param>
        /// <param name="xstart">The xstart</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        /// <param name="stride">The stride</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ImPlot_PlotStairs_U16PtrInt")]
        public static extern void ImPlot_PlotStairs_U16PtrInt(byte[] labelId, ushort[] values, int count, double xscale, double xstart, ImPlotStairsFlags flags, int offset, int stride);
        
        /// <summary>
        ///     Ims the plot plot stairs s 32 ptr int using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="xscale">The xscale</param>
        /// <param name="xstart">The xstart</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        /// <param name="stride">The stride</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ImPlot_PlotStairs_S32PtrInt")]
        public static extern void ImPlot_PlotStairs_S32PtrInt(byte[] labelId, int[] values, int count, double xscale, double xstart, ImPlotStairsFlags flags, int offset, int stride);
        
        /// <summary>
        ///     Ims the plot plot stairs u 32 ptr int using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="xscale">The xscale</param>
        /// <param name="xstart">The xstart</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        /// <param name="stride">The stride</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ImPlot_PlotStairs_U32PtrInt")]
        public static extern void ImPlot_PlotStairs_U32PtrInt(byte[] labelId, uint[] values, int count, double xscale, double xstart, ImPlotStairsFlags flags, int offset, int stride);
        
        /// <summary>
        ///     Ims the plot plot stairs s 64 ptr int using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="xscale">The xscale</param>
        /// <param name="xstart">The xstart</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        /// <param name="stride">The stride</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ImPlot_PlotStairs_S64PtrInt")]
        public static extern void ImPlot_PlotStairs_S64PtrInt(byte[] labelId, long[] values, int count, double xscale, double xstart, ImPlotStairsFlags flags, int offset, int stride);
        
        /// <summary>
        ///     Ims the plot plot stairs u 64 ptr int using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="xscale">The xscale</param>
        /// <param name="xstart">The xstart</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        /// <param name="stride">The stride</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ImPlot_PlotStairs_U64PtrInt")]
        public static extern void ImPlot_PlotStairs_U64PtrInt(byte[] labelId, ulong[] values, int count, double xscale, double xstart, ImPlotStairsFlags flags, int offset, int stride);
        
        /// <summary>
        ///     Ims the plot plot stairs float ptr float ptr using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="count">The count</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        /// <param name="stride">The stride</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ImPlot_PlotStairs_FloatPtrFloatPtr")]
        public static extern void ImPlot_PlotStairs_FloatPtrFloatPtr(byte[] labelId, ref float xs, ref float ys, int count, ImPlotStairsFlags flags, int offset, int stride);
        
        /// <summary>
        ///     Ims the plot plot stairs double ptrdouble ptr using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="count">The count</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        /// <param name="stride">The stride</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ImPlot_PlotStairs_doublePtrdoublePtr")]
        public static extern void ImPlot_PlotStairs_doublePtrdoublePtr(byte[] labelId, ref double xs, ref double ys, int count, ImPlotStairsFlags flags, int offset, int stride);
        
        /// <summary>
        ///     Ims the plot plot stairs s 8 ptr s 8 ptr using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="count">The count</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        /// <param name="stride">The stride</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ImPlot_PlotStairs_S8PtrS8Ptr")]
        public static extern void ImPlot_PlotStairs_S8PtrS8Ptr(byte[] labelId, ref sbyte xs, ref sbyte ys, int count, ImPlotStairsFlags flags, int offset, int stride);
        
        /// <summary>
        ///     Ims the plot plot stairs u 8 ptr u 8 ptr using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="count">The count</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        /// <param name="stride">The stride</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ImPlot_PlotStairs_U8PtrU8Ptr")]
        public static extern void ImPlot_PlotStairs_U8PtrU8Ptr(byte[] labelId, ref byte xs, ref byte ys, int count, ImPlotStairsFlags flags, int offset, int stride);
        
        /// <summary>
        ///     Ims the plot plot stairs s 16 ptr s 16 ptr using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="count">The count</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        /// <param name="stride">The stride</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ImPlot_PlotStairs_S16PtrS16Ptr")]
        public static extern void ImPlot_PlotStairs_S16PtrS16Ptr(byte[] labelId, short xs, short ys, int count, ImPlotStairsFlags flags, int offset, int stride);
        
        /// <summary>
        ///     Ims the plot plot stairs u 16 ptr u 16 ptr using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="count">The count</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        /// <param name="stride">The stride</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ImPlot_PlotStairs_U16PtrU16Ptr")]
        public static extern void ImPlot_PlotStairs_U16PtrU16Ptr(byte[] labelId, ref ushort xs, ref ushort ys, int count, ImPlotStairsFlags flags, int offset, int stride);
        
        /// <summary>
        ///     Ims the plot plot stairs s 32 ptr s 32 ptr using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="count">The count</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        /// <param name="stride">The stride</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ImPlot_PlotStairs_S32PtrS32Ptr")]
        public static extern void ImPlot_PlotStairs_S32PtrS32Ptr(byte[] labelId, int xs, int ys, int count, ImPlotStairsFlags flags, int offset, int stride);
        
        /// <summary>
        ///     Ims the plot plot stairs u 32 ptr u 32 ptr using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="count">The count</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        /// <param name="stride">The stride</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ImPlot_PlotStairs_U32PtrU32Ptr")]
        public static extern void ImPlot_PlotStairs_U32PtrU32Ptr(byte[] labelId, uint xs, uint ys, int count, ImPlotStairsFlags flags, int offset, int stride);
        
        /// <summary>
        ///     Ims the plot plot stairs s 64 ptr s 64 ptr using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="count">The count</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        /// <param name="stride">The stride</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ImPlot_PlotStairs_S64PtrS64Ptr")]
        public static extern void ImPlot_PlotStairs_S64PtrS64Ptr(byte[] labelId, ref long xs, ref long ys, int count, ImPlotStairsFlags flags, int offset, int stride);
        
        /// <summary>
        ///     Ims the plot plot stairs u 64 ptr u 64 ptr using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="count">The count</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        /// <param name="stride">The stride</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ImPlot_PlotStairs_U64PtrU64Ptr")]
        public static extern void ImPlot_PlotStairs_U64PtrU64Ptr(byte[] labelId, ref ulong xs, ref ulong ys, int count, ImPlotStairsFlags flags, int offset, int stride);
        
        /// <summary>
        ///     Ims the plot plot stairs g using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="getter">The getter</param>
        /// <param name="data">The data</param>
        /// <param name="count">The count</param>
        /// <param name="flags">The flags</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ImPlot_PlotStairsG")]
        public static extern void ImPlot_PlotStairsG(byte[] labelId, IntPtr getter, IntPtr data, int count, ImPlotStairsFlags flags);
        
        /// <summary>
        ///     Ims the plot plot stems float ptr int using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="ref">The ref</param>
        /// <param name="scale">The scale</param>
        /// <param name="start">The start</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        /// <param name="stride">The stride</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ImPlot_PlotStems_FloatPtrInt")]
        public static extern void ImPlot_PlotStems_FloatPtrInt(byte[] labelId, float[] values, int count, double @ref, double scale, double start, ImPlotStemsFlags flags, int offset, int stride);
        
        /// <summary>
        ///     Ims the plot plot stems double ptr int using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="ref">The ref</param>
        /// <param name="scale">The scale</param>
        /// <param name="start">The start</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        /// <param name="stride">The stride</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ImPlot_PlotStems_doublePtrInt")]
        public static extern void ImPlot_PlotStems_doublePtrInt(byte[] labelId, double[] values, int count, double @ref, double scale, double start, ImPlotStemsFlags flags, int offset, int stride);
        
        /// <summary>
        ///     Ims the plot plot stems s 8 ptr int using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="ref">The ref</param>
        /// <param name="scale">The scale</param>
        /// <param name="start">The start</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        /// <param name="stride">The stride</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ImPlot_PlotStems_S8PtrInt")]
        public static extern void ImPlot_PlotStems_S8PtrInt(byte[] labelId, sbyte[] values, int count, double @ref, double scale, double start, ImPlotStemsFlags flags, int offset, int stride);
        
        /// <summary>
        ///     Ims the plot plot stems u 8 ptr int using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="ref">The ref</param>
        /// <param name="scale">The scale</param>
        /// <param name="start">The start</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        /// <param name="stride">The stride</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ImPlot_PlotStems_U8PtrInt")]
        public static extern void ImPlot_PlotStems_U8PtrInt(byte[] labelId, byte[] values, int count, double @ref, double scale, double start, ImPlotStemsFlags flags, int offset, int stride);
        
        /// <summary>
        ///     Ims the plot plot stems s 16 ptr int using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="ref">The ref</param>
        /// <param name="scale">The scale</param>
        /// <param name="start">The start</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        /// <param name="stride">The stride</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ImPlot_PlotStems_S16PtrInt")]
        public static extern void ImPlot_PlotStems_S16PtrInt(byte[] labelId, short[] values, int count, double @ref, double scale, double start, ImPlotStemsFlags flags, int offset, int stride);
        
        /// <summary>
        ///     Ims the plot plot stems u 16 ptr int using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="ref">The ref</param>
        /// <param name="scale">The scale</param>
        /// <param name="start">The start</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        /// <param name="stride">The stride</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ImPlot_PlotStems_U16PtrInt")]
        public static extern void ImPlot_PlotStems_U16PtrInt(byte[] labelId, ushort[] values, int count, double @ref, double scale, double start, ImPlotStemsFlags flags, int offset, int stride);
        
        /// <summary>
        ///     Ims the plot plot stems s 32 ptr int using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="ref">The ref</param>
        /// <param name="scale">The scale</param>
        /// <param name="start">The start</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        /// <param name="stride">The stride</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ImPlot_PlotStems_S32PtrInt")]
        public static extern void ImPlot_PlotStems_S32PtrInt(byte[] labelId, int[] values, int count, double @ref, double scale, double start, ImPlotStemsFlags flags, int offset, int stride);
        
        /// <summary>
        ///     Ims the plot plot stems u 32 ptr int using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="ref">The ref</param>
        /// <param name="scale">The scale</param>
        /// <param name="start">The start</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        /// <param name="stride">The stride</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ImPlot_PlotStems_U32PtrInt")]
        public static extern void ImPlot_PlotStems_U32PtrInt(byte[] labelId, uint[] values, int count, double @ref, double scale, double start, ImPlotStemsFlags flags, int offset, int stride);
        
        /// <summary>
        ///     Ims the plot plot stems s 64 ptr int using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="ref">The ref</param>
        /// <param name="scale">The scale</param>
        /// <param name="start">The start</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        /// <param name="stride">The stride</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ImPlot_PlotStems_S64PtrInt")]
        public static extern void ImPlot_PlotStems_S64PtrInt(byte[] labelId, long[] values, int count, double @ref, double scale, double start, ImPlotStemsFlags flags, int offset, int stride);
        
        /// <summary>
        ///     Ims the plot plot stems u 64 ptr int using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="ref">The ref</param>
        /// <param name="scale">The scale</param>
        /// <param name="start">The start</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        /// <param name="stride">The stride</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ImPlot_PlotStems_U64PtrInt")]
        public static extern void ImPlot_PlotStems_U64PtrInt(byte[] labelId, ulong[] values, int count, double @ref, double scale, double start, ImPlotStemsFlags flags, int offset, int stride);
        
        /// <summary>
        ///     Ims the plot plot stems float ptr float ptr using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="count">The count</param>
        /// <param name="ref">The ref</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        /// <param name="stride">The stride</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ImPlot_PlotStems_FloatPtrFloatPtr")]
        public static extern void ImPlot_PlotStems_FloatPtrFloatPtr(byte[] labelId, ref float xs, ref float ys, int count, double @ref, ImPlotStemsFlags flags, int offset, int stride);
        
        /// <summary>
        ///     Ims the plot plot stems double ptrdouble ptr using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="count">The count</param>
        /// <param name="ref">The ref</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        /// <param name="stride">The stride</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ImPlot_PlotStems_doublePtrdoublePtr")]
        public static extern void ImPlot_PlotStems_doublePtrdoublePtr(byte[] labelId, ref double xs, ref double ys, int count, double @ref, ImPlotStemsFlags flags, int offset, int stride);
        
        /// <summary>
        ///     Ims the plot plot stems s 8 ptr s 8 ptr using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="count">The count</param>
        /// <param name="ref">The ref</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        /// <param name="stride">The stride</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ImPlot_PlotStems_S8PtrS8Ptr")]
        public static extern void ImPlot_PlotStems_S8PtrS8Ptr(byte[] labelId, ref sbyte xs, ref sbyte ys, int count, double @ref, ImPlotStemsFlags flags, int offset, int stride);
        
        /// <summary>
        ///     Ims the plot plot stems u 8 ptr u 8 ptr using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="count">The count</param>
        /// <param name="ref">The ref</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        /// <param name="stride">The stride</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ImPlot_PlotStems_U8PtrU8Ptr")]
        public static extern void ImPlot_PlotStems_U8PtrU8Ptr(byte[] labelId, ref byte xs, ref byte ys, int count, double @ref, ImPlotStemsFlags flags, int offset, int stride);
        
        /// <summary>
        ///     Ims the plot plot stems s 16 ptr s 16 ptr using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="count">The count</param>
        /// <param name="ref">The ref</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        /// <param name="stride">The stride</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ImPlot_PlotStems_S16PtrS16Ptr")]
        public static extern void ImPlot_PlotStems_S16PtrS16Ptr(byte[] labelId, ref short xs, ref short ys, int count, double @ref, ImPlotStemsFlags flags, int offset, int stride);
        
        /// <summary>
        ///     Ims the plot plot stems u 16 ptr u 16 ptr using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="count">The count</param>
        /// <param name="ref">The ref</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        /// <param name="stride">The stride</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ImPlot_PlotStems_U16PtrU16Ptr")]
        public static extern void ImPlot_PlotStems_U16PtrU16Ptr(byte[] labelId, ref ushort xs, ref ushort ys, int count, double @ref, ImPlotStemsFlags flags, int offset, int stride);
        
        /// <summary>
        ///     Ims the plot plot stems s 32 ptr s 32 ptr using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="count">The count</param>
        /// <param name="ref">The ref</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        /// <param name="stride">The stride</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ImPlot_PlotStems_S32PtrS32Ptr")]
        public static extern void ImPlot_PlotStems_S32PtrS32Ptr(byte[] labelId, int xs, int ys, int count, double @ref, ImPlotStemsFlags flags, int offset, int stride);
        
        /// <summary>
        ///     Ims the plot plot stems u 32 ptr u 32 ptr using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="count">The count</param>
        /// <param name="ref">The ref</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        /// <param name="stride">The stride</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ImPlot_PlotStems_U32PtrU32Ptr")]
        public static extern void ImPlot_PlotStems_U32PtrU32Ptr(byte[] labelId, uint xs, uint ys, int count, double @ref, ImPlotStemsFlags flags, int offset, int stride);
        
        /// <summary>
        ///     Ims the plot plot stems s 64 ptr s 64 ptr using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="count">The count</param>
        /// <param name="ref">The ref</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        /// <param name="stride">The stride</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ImPlot_PlotStems_S64PtrS64Ptr")]
        public static extern void ImPlot_PlotStems_S64PtrS64Ptr(byte[] labelId, ref long xs, ref long ys, int count, double @ref, ImPlotStemsFlags flags, int offset, int stride);
        
        /// <summary>
        ///     Ims the plot plot stems u 64 ptr u 64 ptr using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="count">The count</param>
        /// <param name="ref">The ref</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        /// <param name="stride">The stride</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ImPlot_PlotStems_U64PtrU64Ptr")]
        public static extern void ImPlot_PlotStems_U64PtrU64Ptr(byte[] labelId, ref ulong xs, ref ulong ys, int count, double @ref, ImPlotStemsFlags flags, int offset, int stride);
        
        /// <summary>
        ///     Ims the plot plot text using the specified text
        /// </summary>
        /// <param name="text">The text</param>
        /// <param name="x">The </param>
        /// <param name="y">The </param>
        /// <param name="pixOffset">The pix offset</param>
        /// <param name="flags">The flags</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ImPlot_PlotText")]
        public static extern void ImPlot_PlotText(byte[] text, double x, double y, Vector2 pixOffset, ImPlotTextFlags flags);
        
        /// <summary>
        ///     Ims the plot plot to pixels plot po int using the specified p out
        /// </summary>
        /// <param name="pOut">The out</param>
        /// <param name="plt">The plt</param>
        /// <param name="xAxis">The axis</param>
        /// <param name="yAxis">The axis</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ImPlot_PlotToPixels_PlotPoInt")]
        public static extern void ImPlot_PlotToPixels_PlotPoInt(out Vector2 pOut, ImPlotPoint plt, ImAxis xAxis, ImAxis yAxis);
        
        /// <summary>
        ///     Ims the plot plot to pixels double using the specified p out
        /// </summary>
        /// <param name="pOut">The out</param>
        /// <param name="x">The </param>
        /// <param name="y">The </param>
        /// <param name="xAxis">The axis</param>
        /// <param name="yAxis">The axis</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ImPlot_PlotToPixels_double")]
        public static extern void ImPlot_PlotToPixels_double(out Vector2 pOut, double x, double y, ImAxis xAxis, ImAxis yAxis);
        
        /// <summary>
        ///     Ims the plot pop colormap using the specified count
        /// </summary>
        /// <param name="count">The count</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ImPlot_PopColormap")]
        public static extern void ImPlot_PopColormap(int count);
        
        /// <summary>
        ///     Ims the plot pop plot clip rect
        /// </summary>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ImPlot_PopPlotClipRect")]
        public static extern void ImPlot_PopPlotClipRect();
        
        /// <summary>
        ///     Ims the plot pop style color using the specified count
        /// </summary>
        /// <param name="count">The count</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ImPlot_PopStyleColor")]
        public static extern void ImPlot_PopStyleColor(int count);
        
        /// <summary>
        ///     Ims the plot pop style var using the specified count
        /// </summary>
        /// <param name="count">The count</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ImPlot_PopStyleVar")]
        public static extern void ImPlot_PopStyleVar(int count);
        
        /// <summary>
        ///     Ims the plot push colormap plot colormap using the specified cmap
        /// </summary>
        /// <param name="cmap">The cmap</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ImPlot_PushColormap_PlotColormap")]
        public static extern void ImPlot_PushColormap_PlotColormap(ImPlotColormap cmap);
        
        /// <summary>
        ///     Ims the plot push colormap str using the specified name
        /// </summary>
        /// <param name="name">The name</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ImPlot_PushColormap_Str")]
        public static extern void ImPlot_PushColormap_Str(byte[] name);
        
        /// <summary>
        ///     Ims the plot push plot clip rect using the specified expand
        /// </summary>
        /// <param name="expand">The expand</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ImPlot_PushPlotClipRect")]
        public static extern void ImPlot_PushPlotClipRect(float expand);
        
        /// <summary>
        ///     Ims the plot push style color u 32 using the specified idx
        /// </summary>
        /// <param name="idx">The idx</param>
        /// <param name="col">The col</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ImPlot_PushStyleColor_U32")]
        public static extern void ImPlot_PushStyleColor_U32(ImPlotCol idx, uint col);
        
        /// <summary>
        ///     Ims the plot push style color vec 4 using the specified idx
        /// </summary>
        /// <param name="idx">The idx</param>
        /// <param name="col">The col</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ImPlot_PushStyleColor_Vec4")]
        public static extern void ImPlot_PushStyleColor_Vec4(ImPlotCol idx, Vector4 col);
        
        /// <summary>
        ///     Ims the plot push style var float using the specified idx
        /// </summary>
        /// <param name="idx">The idx</param>
        /// <param name="val">The val</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ImPlot_PushStyleVar_Float")]
        public static extern void ImPlot_PushStyleVar_Float(ImPlotStyleVar idx, float val);
        
        /// <summary>
        ///     Ims the plot push style var int using the specified idx
        /// </summary>
        /// <param name="idx">The idx</param>
        /// <param name="val">The val</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ImPlot_PushStyleVar_Int")]
        public static extern void ImPlot_PushStyleVar_Int(ImPlotStyleVar idx, int val);
        
        /// <summary>
        ///     Ims the plot push style var vec 2 using the specified idx
        /// </summary>
        /// <param name="idx">The idx</param>
        /// <param name="val">The val</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ImPlot_PushStyleVar_Vec2")]
        public static extern void ImPlot_PushStyleVar_Vec2(ImPlotStyleVar idx, Vector2 val);
        
        /// <summary>
        ///     Ims the plot sample colormap using the specified p out
        /// </summary>
        /// <param name="pOut">The out</param>
        /// <param name="t">The </param>
        /// <param name="cmap">The cmap</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ImPlot_SampleColormap")]
        public static extern void ImPlot_SampleColormap(out Vector4 pOut, float t, ImPlotColormap cmap);
        
        /// <summary>
        ///     Ims the plot set axes using the specified x axis
        /// </summary>
        /// <param name="xAxis">The axis</param>
        /// <param name="yAxis">The axis</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ImPlot_SetAxes")]
        public static extern void ImPlot_SetAxes(ImAxis xAxis, ImAxis yAxis);
        
        /// <summary>
        ///     Ims the plot set axis using the specified axis
        /// </summary>
        /// <param name="axis">The axis</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ImPlot_SetAxis")]
        public static extern void ImPlot_SetAxis(ImAxis axis);
        
        /// <summary>
        ///     Ims the plot set current context using the specified ctx
        /// </summary>
        /// <param name="ctx">The ctx</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ImPlot_SetCurrentContext")]
        public static extern void ImPlot_SetCurrentContext(IntPtr ctx);
        
        /// <summary>
        ///     Ims the plot set im gui context using the specified ctx
        /// </summary>
        /// <param name="ctx">The ctx</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ImPlot_SetImGuiContext")]
        public static extern void ImPlot_SetImGuiContext(IntPtr ctx);
        
        /// <summary>
        ///     Ims the plot set next axes limits using the specified x min
        /// </summary>
        /// <param name="xMin">The min</param>
        /// <param name="xMax">The max</param>
        /// <param name="yMin">The min</param>
        /// <param name="yMax">The max</param>
        /// <param name="cond">The cond</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ImPlot_SetNextAxesLimits")]
        public static extern void ImPlot_SetNextAxesLimits(double xMin, double xMax, double yMin, double yMax, ImPlotCond cond);
        
        /// <summary>
        ///     Ims the plot set next axes to fit
        /// </summary>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ImPlot_SetNextAxesToFit")]
        public static extern void ImPlot_SetNextAxesToFit();
        
        /// <summary>
        ///     Ims the plot set next axis limits using the specified axis
        /// </summary>
        /// <param name="axis">The axis</param>
        /// <param name="vMin">The min</param>
        /// <param name="vMax">The max</param>
        /// <param name="cond">The cond</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ImPlot_SetNextAxisLimits")]
        public static extern void ImPlot_SetNextAxisLimits(ImAxis axis, double vMin, double vMax, ImPlotCond cond);
        
        /// <summary>
        ///     Ims the plot set next axis links using the specified axis
        /// </summary>
        /// <param name="axis">The axis</param>
        /// <param name="linkMin">The link min</param>
        /// <param name="linkMax">The link max</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ImPlot_SetNextAxisLinks")]
        public static extern void ImPlot_SetNextAxisLinks(ImAxis axis, double linkMin, double linkMax);
        
        /// <summary>
        ///     Ims the plot set next axis to fit using the specified axis
        /// </summary>
        /// <param name="axis">The axis</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ImPlot_SetNextAxisToFit")]
        public static extern void ImPlot_SetNextAxisToFit(ImAxis axis);
        
        /// <summary>
        ///     Ims the plot set next error bar style using the specified col
        /// </summary>
        /// <param name="col">The col</param>
        /// <param name="size">The size</param>
        /// <param name="weight">The weight</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ImPlot_SetNextErrorBarStyle")]
        public static extern void ImPlot_SetNextErrorBarStyle(Vector4 col, float size, float weight);
        
        /// <summary>
        ///     Ims the plot set next fill style using the specified col
        /// </summary>
        /// <param name="col">The col</param>
        /// <param name="alphaMod">The alpha mod</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ImPlot_SetNextFillStyle")]
        public static extern void ImPlot_SetNextFillStyle(Vector4 col, float alphaMod);
        
        /// <summary>
        ///     Ims the plot set next line style using the specified col
        /// </summary>
        /// <param name="col">The col</param>
        /// <param name="weight">The weight</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ImPlot_SetNextLineStyle")]
        public static extern void ImPlot_SetNextLineStyle(Vector4 col, float weight);
        
        /// <summary>
        ///     Ims the plot set next marker style using the specified marker
        /// </summary>
        /// <param name="marker">The marker</param>
        /// <param name="size">The size</param>
        /// <param name="fill">The fill</param>
        /// <param name="weight">The weight</param>
        /// <param name="outline">The outline</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ImPlot_SetNextMarkerStyle")]
        public static extern void ImPlot_SetNextMarkerStyle(ImPlotMarker marker, float size, Vector4 fill, float weight, Vector4 outline);
        
        /// <summary>
        ///     Ims the plot setup axes using the specified x label
        /// </summary>
        /// <param name="xLabel">The label</param>
        /// <param name="yLabel">The label</param>
        /// <param name="xFlags">The flags</param>
        /// <param name="yFlags">The flags</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ImPlot_SetupAxes")]
        public static extern void ImPlot_SetupAxes(byte[] xLabel, byte[] yLabel, ImPlotAxisFlags xFlags, ImPlotAxisFlags yFlags);
        
        /// <summary>
        ///     Ims the plot setup axes limits using the specified x min
        /// </summary>
        /// <param name="xMin">The min</param>
        /// <param name="xMax">The max</param>
        /// <param name="yMin">The min</param>
        /// <param name="yMax">The max</param>
        /// <param name="cond">The cond</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ImPlot_SetupAxesLimits")]
        public static extern void ImPlot_SetupAxesLimits(double xMin, double xMax, double yMin, double yMax, ImPlotCond cond);
        
        /// <summary>
        ///     Ims the plot setup axis using the specified axis
        /// </summary>
        /// <param name="axis">The axis</param>
        /// <param name="label">The label</param>
        /// <param name="flags">The flags</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ImPlot_SetupAxis")]
        public static extern void ImPlot_SetupAxis(ImAxis axis, byte[] label, ImPlotAxisFlags flags);
        
        /// <summary>
        ///     Ims the plot setup axis format str using the specified axis
        /// </summary>
        /// <param name="axis">The axis</param>
        /// <param name="fmt">The fmt</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ImPlot_SetupAxisFormat_Str")]
        public static extern void ImPlot_SetupAxisFormat_Str(ImAxis axis, byte[] fmt);
        
        /// <summary>
        ///     Ims the plot setup axis format plot formatter using the specified axis
        /// </summary>
        /// <param name="axis">The axis</param>
        /// <param name="formatter">The formatter</param>
        /// <param name="data">The data</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ImPlot_SetupAxisFormat_PlotFormatter")]
        public static extern void ImPlot_SetupAxisFormat_PlotFormatter(ImAxis axis, IntPtr formatter, IntPtr data);
        
        /// <summary>
        ///     Ims the plot setup axis limits using the specified axis
        /// </summary>
        /// <param name="axis">The axis</param>
        /// <param name="vMin">The min</param>
        /// <param name="vMax">The max</param>
        /// <param name="cond">The cond</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ImPlot_SetupAxisLimits")]
        public static extern void ImPlot_SetupAxisLimits(ImAxis axis, double vMin, double vMax, ImPlotCond cond);
        
        /// <summary>
        ///     Ims the plot setup axis limits constraints using the specified axis
        /// </summary>
        /// <param name="axis">The axis</param>
        /// <param name="vMin">The min</param>
        /// <param name="vMax">The max</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ImPlot_SetupAxisLimitsConstraints")]
        public static extern void ImPlot_SetupAxisLimitsConstraints(ImAxis axis, double vMin, double vMax);
        
        /// <summary>
        ///     Ims the plot setup axis links using the specified axis
        /// </summary>
        /// <param name="axis">The axis</param>
        /// <param name="linkMin">The link min</param>
        /// <param name="linkMax">The link max</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ImPlot_SetupAxisLinks")]
        public static extern void ImPlot_SetupAxisLinks(ImAxis axis, double linkMin, double linkMax);
        
        /// <summary>
        ///     Ims the plot setup axis scale plot scale using the specified axis
        /// </summary>
        /// <param name="axis">The axis</param>
        /// <param name="scale">The scale</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ImPlot_SetupAxisScale_PlotScale")]
        public static extern void ImPlot_SetupAxisScale_PlotScale(ImAxis axis, ImPlotScale scale);
        
        /// <summary>
        ///     Ims the plot setup axis scale plot transform using the specified axis
        /// </summary>
        /// <param name="axis">The axis</param>
        /// <param name="forward">The forward</param>
        /// <param name="inverse">The inverse</param>
        /// <param name="data">The data</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ImPlot_SetupAxisScale_PlotTransform")]
        public static extern void ImPlot_SetupAxisScale_PlotTransform(ImAxis axis, IntPtr forward, IntPtr inverse, IntPtr data);
        
        /// <summary>
        ///     Ims the plot setup axis ticks double ptr using the specified axis
        /// </summary>
        /// <param name="axis">The axis</param>
        /// <param name="values">The values</param>
        /// <param name="nTicks">The ticks</param>
        /// <param name="labels">The labels</param>
        /// <param name="keepDefault">The keep default</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ImPlot_SetupAxisTicks_doublePtr")]
        public static extern void ImPlot_SetupAxisTicks_doublePtr(ImAxis axis, double[] values, int nTicks, byte[][] labels, byte keepDefault);
        
        /// <summary>
        ///     Ims the plot setup axis ticks double using the specified axis
        /// </summary>
        /// <param name="axis">The axis</param>
        /// <param name="vMin">The min</param>
        /// <param name="vMax">The max</param>
        /// <param name="nTicks">The ticks</param>
        /// <param name="labels">The labels</param>
        /// <param name="keepDefault">The keep default</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ImPlot_SetupAxisTicks_double")]
        public static extern void ImPlot_SetupAxisTicks_double(ImAxis axis, double vMin, double vMax, int nTicks, byte[][] labels, byte keepDefault);
        
        /// <summary>
        ///     Ims the plot setup axis zoom constraints using the specified axis
        /// </summary>
        /// <param name="axis">The axis</param>
        /// <param name="zMin">The min</param>
        /// <param name="zMax">The max</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ImPlot_SetupAxisZoomConstraints")]
        public static extern void ImPlot_SetupAxisZoomConstraints(ImAxis axis, double zMin, double zMax);
        
        /// <summary>
        ///     Ims the plot setup finish
        /// </summary>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ImPlot_SetupFinish")]
        public static extern void ImPlot_SetupFinish();
        
        /// <summary>
        ///     Ims the plot setup legend using the specified location
        /// </summary>
        /// <param name="location">The location</param>
        /// <param name="flags">The flags</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ImPlot_SetupLegend")]
        public static extern void ImPlot_SetupLegend(ImPlotLocation location, ImPlotLegendFlags flags);
        
        /// <summary>
        ///     Ims the plot setup mouse text using the specified location
        /// </summary>
        /// <param name="location">The location</param>
        /// <param name="flags">The flags</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ImPlot_SetupMouseText")]
        public static extern void ImPlot_SetupMouseText(ImPlotLocation location, ImPlotMouseTextFlags flags);
        
        /// <summary>
        ///     Ims the plot show colormap selector using the specified label
        /// </summary>
        /// <param name="label">The label</param>
        /// <returns>The byte</returns>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ImPlot_ShowColormapSelector")]
        public static extern byte ImPlot_ShowColormapSelector(byte[] label);
        
        /// <summary>
        ///     Ims the plot show demo window using the specified p open
        /// </summary>
        /// <param name="pOpen">The open</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ImPlot_ShowDemoWindow")]
        public static extern void ImPlot_ShowDemoWindow(byte pOpen);
        
        /// <summary>
        ///     Ims the plot show input map selector using the specified label
        /// </summary>
        /// <param name="label">The label</param>
        /// <returns>The byte</returns>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ImPlot_ShowInputMapSelector")]
        public static extern byte ImPlot_ShowInputMapSelector(byte[] label);
        
        /// <summary>
        ///     Ims the plot show metrics window using the specified p popen
        /// </summary>
        /// <param name="pPopen">The popen</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ImPlot_ShowMetricsWindow")]
        public static extern void ImPlot_ShowMetricsWindow(byte pPopen);
        
        /// <summary>
        ///     Ims the plot show style editor using the specified ref
        /// </summary>
        /// <param name="imPlotStyle"></param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ImPlot_ShowStyleEditor")]
        public static extern void ImPlot_ShowStyleEditor(ImPlotStyle imPlotStyle);
        
        /// <summary>
        ///     Ims the plot show style selector using the specified label
        /// </summary>
        /// <param name="label">The label</param>
        /// <returns>The byte</returns>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ImPlot_ShowStyleSelector")]
        public static extern byte ImPlot_ShowStyleSelector(byte[] label);
        
        /// <summary>
        ///     Ims the plot show user guide
        /// </summary>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ImPlot_ShowUserGuide")]
        public static extern void ImPlot_ShowUserGuide();
        
        /// <summary>
        ///     Ims the plot style colors auto using the specified dst
        /// </summary>
        /// <param name="dst">The dst</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ImPlot_StyleColorsAuto")]
        public static extern void ImPlot_StyleColorsAuto(ImPlotStyle dst);
        
        /// <summary>
        ///     Ims the plot style colors classic using the specified dst
        /// </summary>
        /// <param name="dst">The dst</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ImPlot_StyleColorsClassic")]
        public static extern void ImPlot_StyleColorsClassic(ImPlotStyle dst);
        
        /// <summary>
        ///     Ims the plot style colors dark using the specified dst
        /// </summary>
        /// <param name="dst">The dst</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ImPlot_StyleColorsDark")]
        public static extern void ImPlot_StyleColorsDark(ImPlotStyle dst);
        
        /// <summary>
        ///     Ims the plot style colors light using the specified dst
        /// </summary>
        /// <param name="dst">The dst</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ImPlot_StyleColorsLight")]
        public static extern void ImPlot_StyleColorsLight(ImPlotStyle dst);
        
        /// <summary>
        ///     Ims the plot tag x bool using the specified x
        /// </summary>
        /// <param name="x">The </param>
        /// <param name="col">The col</param>
        /// <param name="round">The round</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ImPlot_TagX_Bool")]
        public static extern void ImPlot_TagX_Bool(double x, Vector4 col, byte round);
        
        /// <summary>
        ///     Ims the plot tag x str using the specified x
        /// </summary>
        /// <param name="x">The </param>
        /// <param name="col">The col</param>
        /// <param name="fmt">The fmt</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ImPlot_TagX_Str")]
        public static extern void ImPlot_TagX_Str(double x, Vector4 col, byte[] fmt);
        
        /// <summary>
        ///     Ims the plot tag y bool using the specified y
        /// </summary>
        /// <param name="y">The </param>
        /// <param name="col">The col</param>
        /// <param name="round">The round</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ImPlot_TagY_Bool")]
        public static extern void ImPlot_TagY_Bool(double y, Vector4 col, byte round);
        
        /// <summary>
        ///     Ims the plot tag y str using the specified y
        /// </summary>
        /// <param name="y">The </param>
        /// <param name="col">The col</param>
        /// <param name="fmt">The fmt</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ImPlot_TagY_Str")]
        public static extern void ImPlot_TagY_Str(double y, Vector4 col, byte[] fmt);
        
        /// <summary>
        ///     Ims the plot input map destroy using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ImPlotInputMap_destroy")]
        public static extern void ImPlotInputMap_destroy(ImPlotInputMap self);
        
        /// <summary>
        ///     Ims the plot input map im plot input map
        /// </summary>
        /// <returns>The im plot input map</returns>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ImPlotInputMap_ImPlotInputMap")]
        public static extern ImPlotInputMap ImPlotInputMap_ImPlotInputMap();
        
        /// <summary>
        ///     Ims the plot point destroy using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ImPlotPoint_destroy")]
        public static extern void ImPlotPoint_destroy(ImPlotPoint self);
        
        /// <summary>
        ///     Ims the plot point im plot point nil
        /// </summary>
        /// <returns>The im plot point</returns>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ImPlotPoint_ImPlotPoint_Nil")]
        public static extern ImPlotPoint ImPlotPoint_ImPlotPoint_Nil();
        
        /// <summary>
        ///     Ims the plot point im plot point double using the specified  x
        /// </summary>
        /// <param name="x">The </param>
        /// <param name="y">The </param>
        /// <returns>The im plot point</returns>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ImPlotPoint_ImPlotPoint_double")]
        public static extern ImPlotPoint ImPlotPoint_ImPlotPoint_double(double x, double y);
        
        /// <summary>
        ///     Ims the plot point im plot point vec 2 using the specified p
        /// </summary>
        /// <param name="p">The </param>
        /// <returns>The im plot point</returns>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ImPlotPoint_ImPlotPoint_Vec2")]
        public static extern ImPlotPoint ImPlotPoint_ImPlotPoint_Vec2(Vector2 p);
        
        /// <summary>
        ///     Ims the plot range clamp using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        /// <param name="value">The value</param>
        /// <returns>The double</returns>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ImPlotRange_Clamp")]
        public static extern double ImPlotRange_Clamp(ref ImPlotRange self, double value);
        
        /// <summary>
        ///     Ims the plot range contains using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        /// <param name="value">The value</param>
        /// <returns>The byte</returns>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ImPlotRange_Contains")]
        public static extern byte ImPlotRange_Contains(ref ImPlotRange self, double value);
        
        /// <summary>
        ///     Ims the plot range destroy using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ImPlotRange_destroy")]
        public static extern void ImPlotRange_destroy(ref ImPlotRange self);
        
        /// <summary>
        ///     Ims the plot range im plot range nil
        /// </summary>
        /// <returns>The im plot range</returns>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ImPlotRange_ImPlotRange_Nil")]
        public static extern ImPlotRange ImPlotRange_ImPlotRange_Nil();
        
        /// <summary>
        ///     Ims the plot range im plot range double using the specified  min
        /// </summary>
        /// <param name="min">The min</param>
        /// <param name="max">The max</param>
        /// <returns>The im plot range</returns>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ImPlotRange_ImPlotRange_double")]
        public static extern ImPlotRange ImPlotRange_ImPlotRange_double(double min, double max);
        
        /// <summary>
        ///     Ims the plot range size using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        /// <returns>The double</returns>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ImPlotRange_Size")]
        public static extern double ImPlotRange_Size(ref ImPlotRange self);
        
        /// <summary>
        ///     Ims the plot rect clamp plot po int using the specified p out
        /// </summary>
        /// <param name="pOut">The out</param>
        /// <param name="self">The self</param>
        /// <param name="p">The </param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ImPlotRect_Clamp_PlotPoInt")]
        public static extern void ImPlotRect_Clamp_PlotPoInt(out ImPlotPoint pOut, ref ImPlotPoint self, ImPlotPoint p);
        
        /// <summary>
        ///     Ims the plot rect clamp double using the specified p out
        /// </summary>
        /// <param name="pOut">The out</param>
        /// <param name="self">The self</param>
        /// <param name="x">The </param>
        /// <param name="y">The </param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ImPlotRect_Clamp_double")]
        public static extern void ImPlotRect_Clamp_double(out ImPlotPoint pOut, ref ImPlotPoint self, double x, double y);
        
        /// <summary>
        ///     Ims the plot rect contains plot po int using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        /// <param name="p">The </param>
        /// <returns>The byte</returns>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ImPlotRect_Contains_PlotPoInt")]
        public static extern byte ImPlotRect_Contains_PlotPoInt(ref ImPlotPoint self, ImPlotPoint p);
        
        /// <summary>
        ///     Ims the plot rect contains double using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        /// <param name="x">The </param>
        /// <param name="y">The </param>
        /// <returns>The byte</returns>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ImPlotRect_Contains_double")]
        public static extern byte ImPlotRect_Contains_double(ref ImPlotPoint self, double x, double y);
        
        /// <summary>
        ///     Ims the plot rect destroy using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ImPlotRect_destroy")]
        public static extern void ImPlotRect_destroy(ref ImPlotPoint self);
        
        /// <summary>
        ///     Ims the plot rect im plot rect nil
        /// </summary>
        /// <returns>The im plot rect</returns>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ImPlotRect_ImPlotRect_Nil")]
        public static extern ref ImPlotPoint ImPlotRect_ImPlotRect_Nil();
        
        /// <summary>
        ///     Ims the plot rect im plot rect double using the specified x min
        /// </summary>
        /// <param name="xMin">The min</param>
        /// <param name="xMax">The max</param>
        /// <param name="yMin">The min</param>
        /// <param name="yMax">The max</param>
        /// <returns>The im plot rect</returns>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ImPlotRect_ImPlotRect_double")]
        public static extern ref ImPlotPoint ImPlotRect_ImPlotRect_double(double xMin, double xMax, double yMin, double yMax);
        
        /// <summary>
        ///     Ims the plot rect max using the specified p out
        /// </summary>
        /// <param name="pOut">The out</param>
        /// <param name="self">The self</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ImPlotRect_Max")]
        public static extern void ImPlotRect_Max(out ImPlotPoint pOut, ref ImPlotPoint self);
        
        /// <summary>
        ///     Ims the plot rect min using the specified p out
        /// </summary>
        /// <param name="pOut">The out</param>
        /// <param name="self">The self</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ImPlotRect_Min")]
        public static extern void ImPlotRect_Min(out ImPlotPoint pOut, ref ImPlotRect self);
        
        /// <summary>
        ///     Ims the plot rect size using the specified p out
        /// </summary>
        /// <param name="pOut">The out</param>
        /// <param name="self">The self</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ImPlotRect_Size")]
        public static extern void ImPlotRect_Size(out ImPlotPoint pOut, ref ImPlotRect self);
        
        /// <summary>
        ///     Ims the plot style destroy using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ImPlotStyle_destroy")]
        public static extern void ImPlotStyle_destroy(ImPlotStyle self);
        
        /// <summary>
        ///     Ims the plot style im plot style
        /// </summary>
        /// <returns>The im plot style</returns>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ImPlotStyle_ImPlotStyle")]
        public static extern ImPlotStyle ImPlotStyle_ImPlotStyle();
    }
}