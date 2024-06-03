// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImPlot.cs
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
        ///     Plots the stems using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="count">The count</param>
        /// <param name="ref">The ref</param>
        /// <param name="flags">The flags</param>
        public static void PlotStems(string labelId, ref ushort xs, ref ushort ys, int count, double @ref, ImPlotStemsFlags flags)
        {
            ImPlotNative.ImPlot_PlotStems_U16PtrU16Ptr(Encoding.UTF8.GetBytes(labelId), ref xs, ref ys, count, @ref, flags, 0, sizeof(ushort));
        }
        
        /// <summary>
        ///     Plots the stems using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="count">The count</param>
        /// <param name="ref">The ref</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        public static void PlotStems(string labelId, ref ushort xs, ref ushort ys, int count, double @ref, ImPlotStemsFlags flags, int offset)
        {
            ImPlotNative.ImPlot_PlotStems_U16PtrU16Ptr(Encoding.UTF8.GetBytes(labelId), ref xs, ref ys, count, @ref, flags, offset, sizeof(ushort));
        }
        
        /// <summary>
        ///     Plots the stems using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="count">The count</param>
        /// <param name="ref">The ref</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        /// <param name="stride">The stride</param>
        public static void PlotStems(string labelId, ref ushort xs, ref ushort ys, int count, double @ref, ImPlotStemsFlags flags, int offset, int stride)
        {
            ImPlotNative.ImPlot_PlotStems_U16PtrU16Ptr(Encoding.UTF8.GetBytes(labelId), ref xs, ref ys, count, @ref, flags, offset, stride);
        }
        
        /// <summary>
        ///     Plots the stems using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="count">The count</param>
        public static void PlotStems(string labelId, ref int xs, ref int ys, int count)
        {
            ImPlotNative.ImPlot_PlotStems_S32PtrS32Ptr(Encoding.UTF8.GetBytes(labelId), xs, ys, count, 0, 0, 0, sizeof(int));
        }
        
        /// <summary>
        ///     Plots the stems using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="count">The count</param>
        /// <param name="ref">The ref</param>
        public static void PlotStems(string labelId, ref int xs, ref int ys, int count, double @ref)
        {
            ImPlotNative.ImPlot_PlotStems_S32PtrS32Ptr(Encoding.UTF8.GetBytes(labelId), xs, ys, count, @ref, 0, 0, sizeof(int));
        }
        
        /// <summary>
        ///     Plots the stems using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="count">The count</param>
        /// <param name="ref">The ref</param>
        /// <param name="flags">The flags</param>
        public static void PlotStems(string labelId, ref int xs, ref int ys, int count, double @ref, ImPlotStemsFlags flags)
        {
            ImPlotNative.ImPlot_PlotStems_S32PtrS32Ptr(Encoding.UTF8.GetBytes(labelId), xs, ys, count, @ref, flags, 0, sizeof(int));
        }
        
        /// <summary>
        ///     Plots the stems using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="count">The count</param>
        /// <param name="ref">The ref</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        public static void PlotStems(string labelId, ref int xs, ref int ys, int count, double @ref, ImPlotStemsFlags flags, int offset)
        {
            ImPlotNative.ImPlot_PlotStems_S32PtrS32Ptr(Encoding.UTF8.GetBytes(labelId), xs, ys, count, @ref, flags, offset, sizeof(int));
        }
        
        /// <summary>
        ///     Plots the stems using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="count">The count</param>
        /// <param name="ref">The ref</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        /// <param name="stride">The stride</param>
        public static void PlotStems(string labelId, ref int xs, ref int ys, int count, double @ref, ImPlotStemsFlags flags, int offset, int stride)
        {
            ImPlotNative.ImPlot_PlotStems_S32PtrS32Ptr(Encoding.UTF8.GetBytes(labelId), xs, ys, count, @ref, flags, offset, stride);
        }
        
        /// <summary>
        ///     Plots the stems using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="count">The count</param>
        public static void PlotStems(string labelId, ref uint xs, ref uint ys, int count)
        {
            ImPlotNative.ImPlot_PlotStems_U32PtrU32Ptr(Encoding.UTF8.GetBytes(labelId), xs, ys, count, 0, 0, 0, sizeof(uint));
        }
        
        /// <summary>
        ///     Plots the stems using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="count">The count</param>
        /// <param name="ref">The ref</param>
        public static void PlotStems(string labelId, ref uint xs, ref uint ys, int count, double @ref)
        {
            ImPlotNative.ImPlot_PlotStems_U32PtrU32Ptr(Encoding.UTF8.GetBytes(labelId), xs, ys, count, @ref, 0, 0, sizeof(uint));
        }
        
        /// <summary>
        ///     Plots the stems using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="count">The count</param>
        /// <param name="ref">The ref</param>
        /// <param name="flags">The flags</param>
        public static void PlotStems(string labelId, ref uint xs, ref uint ys, int count, double @ref, ImPlotStemsFlags flags)
        {
            ImPlotNative.ImPlot_PlotStems_U32PtrU32Ptr(Encoding.UTF8.GetBytes(labelId), xs, ys, count, @ref, flags, 0, sizeof(uint));
        }
        
        /// <summary>
        ///     Plots the stems using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="count">The count</param>
        /// <param name="ref">The ref</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        public static void PlotStems(string labelId, ref uint xs, ref uint ys, int count, double @ref, ImPlotStemsFlags flags, int offset)
        {
            ImPlotNative.ImPlot_PlotStems_U32PtrU32Ptr(Encoding.UTF8.GetBytes(labelId), xs, ys, count, @ref, flags, offset, sizeof(uint));
        }
        
        /// <summary>
        ///     Plots the stems using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="count">The count</param>
        /// <param name="ref">The ref</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        /// <param name="stride">The stride</param>
        public static void PlotStems(string labelId, ref uint xs, ref uint ys, int count, double @ref, ImPlotStemsFlags flags, int offset, int stride)
        {
            ImPlotNative.ImPlot_PlotStems_U32PtrU32Ptr(Encoding.UTF8.GetBytes(labelId), xs, ys, count, @ref, flags, offset, stride);
        }
        
        /// <summary>
        ///     Plots the stems using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="count">The count</param>
        public static void PlotStems(string labelId, ref long xs, ref long ys, int count)
        {
            ImPlotNative.ImPlot_PlotStems_S64PtrS64Ptr(Encoding.UTF8.GetBytes(labelId), ref xs, ref ys, count, 0, 0, 0, sizeof(long));
        }
        
        /// <summary>
        ///     Plots the stems using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="count">The count</param>
        /// <param name="ref">The ref</param>
        public static void PlotStems(string labelId, ref long xs, ref long ys, int count, double @ref)
        {
            ImPlotNative.ImPlot_PlotStems_S64PtrS64Ptr(Encoding.UTF8.GetBytes(labelId), ref xs, ref ys, count, @ref, 0, 0, sizeof(long));
        }
        
        /// <summary>
        ///     Plots the stems using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="count">The count</param>
        /// <param name="ref">The ref</param>
        /// <param name="flags">The flags</param>
        public static void PlotStems(string labelId, ref long xs, ref long ys, int count, double @ref, ImPlotStemsFlags flags)
        {
            ImPlotNative.ImPlot_PlotStems_S64PtrS64Ptr(Encoding.UTF8.GetBytes(labelId), ref xs, ref ys, count, @ref, flags, 0, sizeof(long));
        }
        
        /// <summary>
        ///     Plots the stems using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="count">The count</param>
        /// <param name="ref">The ref</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        public static void PlotStems(string labelId, ref long xs, ref long ys, int count, double @ref, ImPlotStemsFlags flags, int offset)
        {
            ImPlotNative.ImPlot_PlotStems_S64PtrS64Ptr(Encoding.UTF8.GetBytes(labelId), ref xs, ref ys, count, @ref, flags, offset, sizeof(long));
        }
        
        /// <summary>
        ///     Plots the stems using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="count">The count</param>
        /// <param name="ref">The ref</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        /// <param name="stride">The stride</param>
        public static void PlotStems(string labelId, ref long xs, ref long ys, int count, double @ref, ImPlotStemsFlags flags, int offset, int stride)
        {
            ImPlotNative.ImPlot_PlotStems_S64PtrS64Ptr(Encoding.UTF8.GetBytes(labelId), ref xs, ref ys, count, @ref, flags, offset, stride);
        }
        
        /// <summary>
        ///     Plots the stems using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="count">The count</param>
        public static void PlotStems(string labelId, ref ulong xs, ref ulong ys, int count)
        {
            ImPlotNative.ImPlot_PlotStems_U64PtrU64Ptr(Encoding.UTF8.GetBytes(labelId), ref xs, ref ys, count, 0, 0, 0, sizeof(ulong));
        }
        
        /// <summary>
        ///     Plots the stems using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="count">The count</param>
        /// <param name="ref">The ref</param>
        public static void PlotStems(string labelId, ref ulong xs, ref ulong ys, int count, double @ref)
        {
            ImPlotNative.ImPlot_PlotStems_U64PtrU64Ptr(Encoding.UTF8.GetBytes(labelId), ref xs, ref ys, count, @ref, 0, 0, sizeof(ulong));
        }
        
        /// <summary>
        ///     Plots the stems using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="count">The count</param>
        /// <param name="ref">The ref</param>
        /// <param name="flags">The flags</param>
        public static void PlotStems(string labelId, ref ulong xs, ref ulong ys, int count, double @ref, ImPlotStemsFlags flags)
        {
            ImPlotNative.ImPlot_PlotStems_U64PtrU64Ptr(Encoding.UTF8.GetBytes(labelId), ref xs, ref ys, count, @ref, flags, 0, sizeof(ulong));
        }
        
        /// <summary>
        ///     Plots the stems using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="count">The count</param>
        /// <param name="ref">The ref</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        public static void PlotStems(string labelId, ref ulong xs, ref ulong ys, int count, double @ref, ImPlotStemsFlags flags, int offset)
        {
            ImPlotNative.ImPlot_PlotStems_U64PtrU64Ptr(Encoding.UTF8.GetBytes(labelId), ref xs, ref ys, count, @ref, flags, offset, sizeof(ulong));
        }
        
        /// <summary>
        ///     Plots the stems using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="count">The count</param>
        /// <param name="ref">The ref</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        /// <param name="stride">The stride</param>
        public static void PlotStems(string labelId, ref ulong xs, ref ulong ys, int count, double @ref, ImPlotStemsFlags flags, int offset, int stride)
        {
            ImPlotNative.ImPlot_PlotStems_U64PtrU64Ptr(Encoding.UTF8.GetBytes(labelId), ref xs, ref ys, count, @ref, flags, offset, stride);
        }
        
        /// <summary>
        ///     Plots the text using the specified text
        /// </summary>
        /// <param name="text">The text</param>
        /// <param name="x">The </param>
        /// <param name="y">The </param>
        public static void PlotText(string text, double x, double y)
        {
            ImPlotNative.ImPlot_PlotText(Encoding.UTF8.GetBytes(text), x, y, new Vector2(0, 0), ImPlotTextFlags.None);
        }
        
        /// <summary>
        ///     Plots the text using the specified text
        /// </summary>
        /// <param name="text">The text</param>
        /// <param name="x">The </param>
        /// <param name="y">The </param>
        /// <param name="pixOffset">The pix offset</param>
        public static void PlotText(string text, double x, double y, Vector2 pixOffset)
        {
            ImPlotNative.ImPlot_PlotText(Encoding.UTF8.GetBytes(text), x, y, pixOffset, ImPlotTextFlags.None);
        }
        
        /// <summary>
        ///     Plots the text using the specified text
        /// </summary>
        /// <param name="text">The text</param>
        /// <param name="x">The </param>
        /// <param name="y">The </param>
        /// <param name="pixOffset">The pix offset</param>
        /// <param name="flags">The flags</param>
        public static void PlotText(string text, double x, double y, Vector2 pixOffset, ImPlotTextFlags flags)
        {
            ImPlotNative.ImPlot_PlotText(Encoding.UTF8.GetBytes(text), x, y, pixOffset, flags);
        }
        
        /// <summary>
        ///     Plots the to pixels using the specified plt
        /// </summary>
        /// <param name="plt">The plt</param>
        /// <returns>The retval</returns>
        public static Vector2 PlotToPixels(ImPlotPoint plt)
        {
            Vector2 retval;
            ImAxis xAxis = (ImAxis) (-1);
            ImAxis yAxis = (ImAxis) (-1);
            ImPlotNative.ImPlot_PlotToPixels_PlotPoInt(out retval, plt, xAxis, yAxis);
            return retval;
        }
        
        /// <summary>
        ///     Plots the to pixels using the specified plt
        /// </summary>
        /// <param name="plt">The plt</param>
        /// <param name="xAxis">The axis</param>
        /// <returns>The retval</returns>
        public static Vector2 PlotToPixels(ImPlotPoint plt, ImAxis xAxis)
        {
            Vector2 retval;
            ImAxis yAxis = (ImAxis) (-1);
            ImPlotNative.ImPlot_PlotToPixels_PlotPoInt(out retval, plt, xAxis, yAxis);
            return retval;
        }
        
        /// <summary>
        ///     Plots the to pixels using the specified plt
        /// </summary>
        /// <param name="plt">The plt</param>
        /// <param name="xAxis">The axis</param>
        /// <param name="yAxis">The axis</param>
        /// <returns>The retval</returns>
        public static Vector2 PlotToPixels(ImPlotPoint plt, ImAxis xAxis, ImAxis yAxis)
        {
            Vector2 retval;
            ImPlotNative.ImPlot_PlotToPixels_PlotPoInt(out retval, plt, xAxis, yAxis);
            return retval;
        }
        
        /// <summary>
        ///     Plots the to pixels using the specified x
        /// </summary>
        /// <param name="x">The </param>
        /// <param name="y">The </param>
        /// <returns>The retval</returns>
        public static Vector2 PlotToPixels(double x, double y)
        {
            Vector2 retval;
            ImAxis xAxis = (ImAxis) (-1);
            ImAxis yAxis = (ImAxis) (-1);
            ImPlotNative.ImPlot_PlotToPixels_double(out retval, x, y, xAxis, yAxis);
            return retval;
        }
        
        /// <summary>
        ///     Plots the to pixels using the specified x
        /// </summary>
        /// <param name="x">The </param>
        /// <param name="y">The </param>
        /// <param name="xAxis">The axis</param>
        /// <returns>The retval</returns>
        public static Vector2 PlotToPixels(double x, double y, ImAxis xAxis)
        {
            Vector2 retval;
            ImAxis yAxis = (ImAxis) (-1);
            ImPlotNative.ImPlot_PlotToPixels_double(out retval, x, y, xAxis, yAxis);
            return retval;
        }
        
        /// <summary>
        ///     Plots the to pixels using the specified x
        /// </summary>
        /// <param name="x">The </param>
        /// <param name="y">The </param>
        /// <param name="xAxis">The axis</param>
        /// <param name="yAxis">The axis</param>
        /// <returns>The retval</returns>
        public static Vector2 PlotToPixels(double x, double y, ImAxis xAxis, ImAxis yAxis)
        {
            Vector2 retval;
            ImPlotNative.ImPlot_PlotToPixels_double(out retval, x, y, xAxis, yAxis);
            return retval;
        }
        
        /// <summary>
        ///     Pops the colormap
        /// </summary>
        public static void PopColormap()
        {
            int count = 1;
            ImPlotNative.ImPlot_PopColormap(count);
        }
        
        /// <summary>
        ///     Pops the colormap using the specified count
        /// </summary>
        /// <param name="count">The count</param>
        public static void PopColormap(int count)
        {
            ImPlotNative.ImPlot_PopColormap(count);
        }
        
        /// <summary>
        ///     Pops the plot clip rect
        /// </summary>
        public static void PopPlotClipRect()
        {
            ImPlotNative.ImPlot_PopPlotClipRect();
        }
        
        /// <summary>
        ///     Pops the style color
        /// </summary>
        public static void PopStyleColor()
        {
            int count = 1;
            ImPlotNative.ImPlot_PopStyleColor(count);
        }
        
        /// <summary>
        ///     Pops the style color using the specified count
        /// </summary>
        /// <param name="count">The count</param>
        public static void PopStyleColor(int count)
        {
            ImPlotNative.ImPlot_PopStyleColor(count);
        }
        
        /// <summary>
        ///     Pops the style var
        /// </summary>
        public static void PopStyleVar()
        {
            int count = 1;
            ImPlotNative.ImPlot_PopStyleVar(count);
        }
        
        /// <summary>
        ///     Pops the style var using the specified count
        /// </summary>
        /// <param name="count">The count</param>
        public static void PopStyleVar(int count)
        {
            ImPlotNative.ImPlot_PopStyleVar(count);
        }
        
        /// <summary>
        ///     Pushes the colormap using the specified cmap
        /// </summary>
        /// <param name="cmap">The cmap</param>
        public static void PushColormap(ImPlotColormap cmap)
        {
            ImPlotNative.ImPlot_PushColormap_PlotColormap(cmap);
        }
        
        /// <summary>
        ///     Pushes the colormap using the specified name
        /// </summary>
        /// <param name="name">The name</param>
        public static void PushColormap(string name)
        {
            ImPlotNative.ImPlot_PushColormap_Str(Encoding.UTF8.GetBytes(name));
        }
        
        /// <summary>
        ///     Pushes the plot clip rect
        /// </summary>
        public static void PushPlotClipRect()
        {
            float expand = 0;
            ImPlotNative.ImPlot_PushPlotClipRect(expand);
        }
        
        /// <summary>
        ///     Pushes the plot clip rect using the specified expand
        /// </summary>
        /// <param name="expand">The expand</param>
        public static void PushPlotClipRect(float expand)
        {
            ImPlotNative.ImPlot_PushPlotClipRect(expand);
        }
        
        /// <summary>
        ///     Pushes the style color using the specified idx
        /// </summary>
        /// <param name="idx">The idx</param>
        /// <param name="col">The col</param>
        public static void PushStyleColor(ImPlotCol idx, uint col)
        {
            ImPlotNative.ImPlot_PushStyleColor_U32(idx, col);
        }
        
        /// <summary>
        ///     Pushes the style color using the specified idx
        /// </summary>
        /// <param name="idx">The idx</param>
        /// <param name="col">The col</param>
        public static void PushStyleColor(ImPlotCol idx, Vector4 col)
        {
            ImPlotNative.ImPlot_PushStyleColor_Vec4(idx, col);
        }
        
        /// <summary>
        ///     Pushes the style var using the specified idx
        /// </summary>
        /// <param name="idx">The idx</param>
        /// <param name="val">The val</param>
        public static void PushStyleVar(ImPlotStyleVar idx, float val)
        {
            ImPlotNative.ImPlot_PushStyleVar_Float(idx, val);
        }
        
        /// <summary>
        ///     Pushes the style var using the specified idx
        /// </summary>
        /// <param name="idx">The idx</param>
        /// <param name="val">The val</param>
        public static void PushStyleVar(ImPlotStyleVar idx, int val)
        {
            ImPlotNative.ImPlot_PushStyleVar_Int(idx, val);
        }
        
        /// <summary>
        ///     Pushes the style var using the specified idx
        /// </summary>
        /// <param name="idx">The idx</param>
        /// <param name="val">The val</param>
        public static void PushStyleVar(ImPlotStyleVar idx, Vector2 val)
        {
            ImPlotNative.ImPlot_PushStyleVar_Vec2(idx, val);
        }
        
        /// <summary>
        ///     Samples the colormap using the specified t
        /// </summary>
        /// <param name="t">The </param>
        /// <returns>The retval</returns>
        public static Vector4 SampleColormap(float t)
        {
            Vector4 retval;
            ImPlotColormap cmap = (ImPlotColormap) (-1);
            ImPlotNative.ImPlot_SampleColormap(out retval, t, cmap);
            return retval;
        }
        
        /// <summary>
        ///     Samples the colormap using the specified t
        /// </summary>
        /// <param name="t">The </param>
        /// <param name="cmap">The cmap</param>
        /// <returns>The retval</returns>
        public static Vector4 SampleColormap(float t, ImPlotColormap cmap)
        {
            Vector4 retval;
            ImPlotNative.ImPlot_SampleColormap(out retval, t, cmap);
            return retval;
        }
        
        /// <summary>
        ///     Sets the axes using the specified x axis
        /// </summary>
        /// <param name="xAxis">The axis</param>
        /// <param name="yAxis">The axis</param>
        public static void SetAxes(ImAxis xAxis, ImAxis yAxis)
        {
            ImPlotNative.ImPlot_SetAxes(xAxis, yAxis);
        }
        
        /// <summary>
        ///     Sets the axis using the specified axis
        /// </summary>
        /// <param name="axis">The axis</param>
        public static void SetAxis(ImAxis axis)
        {
            ImPlotNative.ImPlot_SetAxis(axis);
        }
        
        /// <summary>
        ///     Sets the current context using the specified ctx
        /// </summary>
        /// <param name="ctx">The ctx</param>
        public static void SetCurrentContext(IntPtr ctx)
        {
            ImPlotNative.ImPlot_SetCurrentContext(ctx);
        }
        
        /// <summary>
        ///     Sets the im gui context using the specified ctx
        /// </summary>
        /// <param name="ctx">The ctx</param>
        public static void SetImGuiContext(IntPtr ctx)
        {
            ImPlotNative.ImPlot_SetImGuiContext(ctx);
        }
        
        /// <summary>
        ///     Sets the next axes limits using the specified x min
        /// </summary>
        /// <param name="xMin">The min</param>
        /// <param name="xMax">The max</param>
        /// <param name="yMin">The min</param>
        /// <param name="yMax">The max</param>
        public static void SetNextAxesLimits(double xMin, double xMax, double yMin, double yMax)
        {
            ImPlotCond cond = ImPlotCond.Once;
            ImPlotNative.ImPlot_SetNextAxesLimits(xMin, xMax, yMin, yMax, cond);
        }
        
        /// <summary>
        ///     Sets the next axes limits using the specified x min
        /// </summary>
        /// <param name="xMin">The min</param>
        /// <param name="xMax">The max</param>
        /// <param name="yMin">The min</param>
        /// <param name="yMax">The max</param>
        /// <param name="cond">The cond</param>
        public static void SetNextAxesLimits(double xMin, double xMax, double yMin, double yMax, ImPlotCond cond)
        {
            ImPlotNative.ImPlot_SetNextAxesLimits(xMin, xMax, yMin, yMax, cond);
        }
        
        /// <summary>
        ///     Sets the next axes to fit
        /// </summary>
        public static void SetNextAxesToFit()
        {
            ImPlotNative.ImPlot_SetNextAxesToFit();
        }
        
        /// <summary>
        ///     Sets the next axis limits using the specified axis
        /// </summary>
        /// <param name="axis">The axis</param>
        /// <param name="vMin">The min</param>
        /// <param name="vMax">The max</param>
        public static void SetNextAxisLimits(ImAxis axis, double vMin, double vMax)
        {
            ImPlotCond cond = ImPlotCond.Once;
            ImPlotNative.ImPlot_SetNextAxisLimits(axis, vMin, vMax, cond);
        }
        
        /// <summary>
        ///     Sets the next axis limits using the specified axis
        /// </summary>
        /// <param name="axis">The axis</param>
        /// <param name="vMin">The min</param>
        /// <param name="vMax">The max</param>
        /// <param name="cond">The cond</param>
        public static void SetNextAxisLimits(ImAxis axis, double vMin, double vMax, ImPlotCond cond)
        {
            ImPlotNative.ImPlot_SetNextAxisLimits(axis, vMin, vMax, cond);
        }
        
        /// <summary>
        ///     Sets the next axis links using the specified axis
        /// </summary>
        /// <param name="axis">The axis</param>
        /// <param name="linkMin">The link min</param>
        /// <param name="linkMax">The link max</param>
        public static void SetNextAxisLinks(ImAxis axis, ref double linkMin, ref double linkMax)
        {
            ImPlotNative.ImPlot_SetNextAxisLinks(axis, linkMin, linkMax);
        }
        
        /// <summary>
        ///     Sets the next axis to fit using the specified axis
        /// </summary>
        /// <param name="axis">The axis</param>
        public static void SetNextAxisToFit(ImAxis axis)
        {
            ImPlotNative.ImPlot_SetNextAxisToFit(axis);
        }
        
        /// <summary>
        ///     Sets the next error bar style
        /// </summary>
        public static void SetNextErrorBarStyle()
        {
            Vector4 col = new Vector4(0, 0, 0, -1);
            float size = -1;
            float weight = -1;
            ImPlotNative.ImPlot_SetNextErrorBarStyle(col, size, weight);
        }
        
        /// <summary>
        ///     Sets the next error bar style using the specified col
        /// </summary>
        /// <param name="col">The col</param>
        public static void SetNextErrorBarStyle(Vector4 col)
        {
            float size = -1;
            float weight = -1;
            ImPlotNative.ImPlot_SetNextErrorBarStyle(col, size, weight);
        }
        
        /// <summary>
        ///     Sets the next error bar style using the specified col
        /// </summary>
        /// <param name="col">The col</param>
        /// <param name="size">The size</param>
        public static void SetNextErrorBarStyle(Vector4 col, float size)
        {
            float weight = -1;
            ImPlotNative.ImPlot_SetNextErrorBarStyle(col, size, weight);
        }
        
        /// <summary>
        ///     Sets the next error bar style using the specified col
        /// </summary>
        /// <param name="col">The col</param>
        /// <param name="size">The size</param>
        /// <param name="weight">The weight</param>
        public static void SetNextErrorBarStyle(Vector4 col, float size, float weight)
        {
            ImPlotNative.ImPlot_SetNextErrorBarStyle(col, size, weight);
        }
        
        /// <summary>
        ///     Sets the next fill style
        /// </summary>
        public static void SetNextFillStyle()
        {
            Vector4 col = new Vector4(0, 0, 0, -1);
            float alphaMod = -1;
            ImPlotNative.ImPlot_SetNextFillStyle(col, alphaMod);
        }
        
        /// <summary>
        ///     Sets the next fill style using the specified col
        /// </summary>
        /// <param name="col">The col</param>
        public static void SetNextFillStyle(Vector4 col)
        {
            float alphaMod = -1;
            ImPlotNative.ImPlot_SetNextFillStyle(col, alphaMod);
        }
        
        /// <summary>
        ///     Sets the next fill style using the specified col
        /// </summary>
        /// <param name="col">The col</param>
        /// <param name="alphaMod">The alpha mod</param>
        public static void SetNextFillStyle(Vector4 col, float alphaMod)
        {
            ImPlotNative.ImPlot_SetNextFillStyle(col, alphaMod);
        }
        
        /// <summary>
        ///     Sets the next line style
        /// </summary>
        public static void SetNextLineStyle()
        {
            Vector4 col = new Vector4(0, 0, 0, -1);
            float weight = -1;
            ImPlotNative.ImPlot_SetNextLineStyle(col, weight);
        }
        
        /// <summary>
        ///     Sets the next line style using the specified col
        /// </summary>
        /// <param name="col">The col</param>
        public static void SetNextLineStyle(Vector4 col)
        {
            float weight = -1;
            ImPlotNative.ImPlot_SetNextLineStyle(col, weight);
        }
        
        /// <summary>
        ///     Sets the next line style using the specified col
        /// </summary>
        /// <param name="col">The col</param>
        /// <param name="weight">The weight</param>
        public static void SetNextLineStyle(Vector4 col, float weight)
        {
            ImPlotNative.ImPlot_SetNextLineStyle(col, weight);
        }
        
        /// <summary>
        ///     Sets the next marker style
        /// </summary>
        public static void SetNextMarkerStyle()
        {
            ImPlotMarker marker = (ImPlotMarker) (-1);
            float size = -1;
            Vector4 fill = new Vector4(0, 0, 0, -1);
            float weight = -1;
            Vector4 outline = new Vector4(0, 0, 0, -1);
            ImPlotNative.ImPlot_SetNextMarkerStyle(marker, size, fill, weight, outline);
        }
        
        /// <summary>
        ///     Sets the next marker style using the specified marker
        /// </summary>
        /// <param name="marker">The marker</param>
        public static void SetNextMarkerStyle(ImPlotMarker marker)
        {
            float size = -1;
            Vector4 fill = new Vector4(0, 0, 0, -1);
            float weight = -1;
            Vector4 outline = new Vector4(0, 0, 0, -1);
            ImPlotNative.ImPlot_SetNextMarkerStyle(marker, size, fill, weight, outline);
        }
        
        /// <summary>
        ///     Sets the next marker style using the specified marker
        /// </summary>
        /// <param name="marker">The marker</param>
        /// <param name="size">The size</param>
        public static void SetNextMarkerStyle(ImPlotMarker marker, float size)
        {
            Vector4 fill = new Vector4(0, 0, 0, -1);
            float weight = -1;
            Vector4 outline = new Vector4(0, 0, 0, -1);
            ImPlotNative.ImPlot_SetNextMarkerStyle(marker, size, fill, weight, outline);
        }
        
        /// <summary>
        ///     Sets the next marker style using the specified marker
        /// </summary>
        /// <param name="marker">The marker</param>
        /// <param name="size">The size</param>
        /// <param name="fill">The fill</param>
        public static void SetNextMarkerStyle(ImPlotMarker marker, float size, Vector4 fill)
        {
            float weight = -1;
            Vector4 outline = new Vector4(0, 0, 0, -1);
            ImPlotNative.ImPlot_SetNextMarkerStyle(marker, size, fill, weight, outline);
        }
        
        /// <summary>
        ///     Sets the next marker style using the specified marker
        /// </summary>
        /// <param name="marker">The marker</param>
        /// <param name="size">The size</param>
        /// <param name="fill">The fill</param>
        /// <param name="weight">The weight</param>
        public static void SetNextMarkerStyle(ImPlotMarker marker, float size, Vector4 fill, float weight)
        {
            Vector4 outline = new Vector4(0, 0, 0, -1);
            ImPlotNative.ImPlot_SetNextMarkerStyle(marker, size, fill, weight, outline);
        }
        
        /// <summary>
        ///     Sets the next marker style using the specified marker
        /// </summary>
        /// <param name="marker">The marker</param>
        /// <param name="size">The size</param>
        /// <param name="fill">The fill</param>
        /// <param name="weight">The weight</param>
        /// <param name="outline">The outline</param>
        public static void SetNextMarkerStyle(ImPlotMarker marker, float size, Vector4 fill, float weight, Vector4 outline)
        {
            ImPlotNative.ImPlot_SetNextMarkerStyle(marker, size, fill, weight, outline);
        }
        
        /// <summary>
        ///     Setup the axes using the specified x label
        /// </summary>
        /// <param name="xLabel">The label</param>
        /// <param name="yLabel">The label</param>
        public static void SetupAxes(string xLabel, string yLabel)
        {
            ImPlotNative.ImPlot_SetupAxes(Encoding.UTF8.GetBytes(xLabel), Encoding.UTF8.GetBytes(yLabel), 0, 0);
        }
        
        /// <summary>
        ///     Setup the axes using the specified x label
        /// </summary>
        /// <param name="xLabel">The label</param>
        /// <param name="yLabel">The label</param>
        /// <param name="xFlags">The flags</param>
        public static void SetupAxes(string xLabel, string yLabel, ImPlotAxisFlags xFlags)
        {
            ImPlotNative.ImPlot_SetupAxes(Encoding.UTF8.GetBytes(xLabel), Encoding.UTF8.GetBytes(yLabel), xFlags, 0);
        }
        
        /// <summary>
        ///     Setup the axes using the specified x label
        /// </summary>
        /// <param name="xLabel">The label</param>
        /// <param name="yLabel">The label</param>
        /// <param name="xFlags">The flags</param>
        /// <param name="yFlags">The flags</param>
        public static void SetupAxes(string xLabel, string yLabel, ImPlotAxisFlags xFlags, ImPlotAxisFlags yFlags)
        {
            ImPlotNative.ImPlot_SetupAxes(Encoding.UTF8.GetBytes(xLabel), Encoding.UTF8.GetBytes(yLabel), xFlags, yFlags);
        }
        
        /// <summary>
        ///     Setup the axes limits using the specified x min
        /// </summary>
        /// <param name="xMin">The min</param>
        /// <param name="xMax">The max</param>
        /// <param name="yMin">The min</param>
        /// <param name="yMax">The max</param>
        public static void SetupAxesLimits(double xMin, double xMax, double yMin, double yMax)
        {
            ImPlotCond cond = ImPlotCond.Once;
            ImPlotNative.ImPlot_SetupAxesLimits(xMin, xMax, yMin, yMax, cond);
        }
        
        /// <summary>
        ///     Setup the axes limits using the specified x min
        /// </summary>
        /// <param name="xMin">The min</param>
        /// <param name="xMax">The max</param>
        /// <param name="yMin">The min</param>
        /// <param name="yMax">The max</param>
        /// <param name="cond">The cond</param>
        public static void SetupAxesLimits(double xMin, double xMax, double yMin, double yMax, ImPlotCond cond)
        {
            ImPlotNative.ImPlot_SetupAxesLimits(xMin, xMax, yMin, yMax, cond);
        }
        
        /// <summary>
        ///     Setup the axis using the specified axis
        /// </summary>
        /// <param name="axis">The axis</param>
        public static void SetupAxis(ImAxis axis)
        {
            ImPlotAxisFlags flags = 0;
            ImPlotNative.ImPlot_SetupAxis(axis, Array.Empty<byte>(), flags);
        }
        
        /// <summary>
        ///     Setup the axis using the specified axis
        /// </summary>
        /// <param name="axis">The axis</param>
        /// <param name="label">The label</param>
        public static void SetupAxis(ImAxis axis, string label)
        {
            ImPlotNative.ImPlot_SetupAxis(axis, Encoding.UTF8.GetBytes(label), 0);
        }
        
        /// <summary>
        ///     Setup the axis using the specified axis
        /// </summary>
        /// <param name="axis">The axis</param>
        /// <param name="label">The label</param>
        /// <param name="flags">The flags</param>
        public static void SetupAxis(ImAxis axis, string label, ImPlotAxisFlags flags)
        {
            ImPlotNative.ImPlot_SetupAxis(axis, Encoding.UTF8.GetBytes(label), flags);
        }
        
        /// <summary>
        ///     Setup the axis format using the specified axis
        /// </summary>
        /// <param name="axis">The axis</param>
        /// <param name="fmt">The fmt</param>
        public static void SetupAxisFormat(ImAxis axis, string fmt)
        {
            ImPlotNative.ImPlot_SetupAxisFormat_Str(axis, Encoding.UTF8.GetBytes(fmt));
        }
        
        /// <summary>
        ///     Setup the axis format using the specified axis
        /// </summary>
        /// <param name="axis">The axis</param>
        /// <param name="formatter">The formatter</param>
        public static void SetupAxisFormat(ImAxis axis, IntPtr formatter)
        {
            ImPlotNative.ImPlot_SetupAxisFormat_PlotFormatter(axis, formatter, IntPtr.Zero);
        }
        
        /// <summary>
        ///     Setup the axis format using the specified axis
        /// </summary>
        /// <param name="axis">The axis</param>
        /// <param name="formatter">The formatter</param>
        /// <param name="data">The data</param>
        public static void SetupAxisFormat(ImAxis axis, IntPtr formatter, IntPtr data)
        {
            ImPlotNative.ImPlot_SetupAxisFormat_PlotFormatter(axis, formatter, data);
        }
        
        /// <summary>
        ///     Setup the axis limits using the specified axis
        /// </summary>
        /// <param name="axis">The axis</param>
        /// <param name="vMin">The min</param>
        /// <param name="vMax">The max</param>
        public static void SetupAxisLimits(ImAxis axis, double vMin, double vMax)
        {
            ImPlotCond cond = ImPlotCond.Once;
            ImPlotNative.ImPlot_SetupAxisLimits(axis, vMin, vMax, cond);
        }
        
        /// <summary>
        ///     Setup the axis limits using the specified axis
        /// </summary>
        /// <param name="axis">The axis</param>
        /// <param name="vMin">The min</param>
        /// <param name="vMax">The max</param>
        /// <param name="cond">The cond</param>
        public static void SetupAxisLimits(ImAxis axis, double vMin, double vMax, ImPlotCond cond)
        {
            ImPlotNative.ImPlot_SetupAxisLimits(axis, vMin, vMax, cond);
        }
        
        /// <summary>
        ///     Setup the axis limits constraints using the specified axis
        /// </summary>
        /// <param name="axis">The axis</param>
        /// <param name="vMin">The min</param>
        /// <param name="vMax">The max</param>
        public static void SetupAxisLimitsConstraints(ImAxis axis, double vMin, double vMax)
        {
            ImPlotNative.ImPlot_SetupAxisLimitsConstraints(axis, vMin, vMax);
        }
        
        /// <summary>
        ///     Setup the axis links using the specified axis
        /// </summary>
        /// <param name="axis">The axis</param>
        /// <param name="linkMin">The link min</param>
        /// <param name="linkMax">The link max</param>
        public static void SetupAxisLinks(ImAxis axis, ref double linkMin, ref double linkMax)
        {
            ImPlotNative.ImPlot_SetupAxisLinks(axis, linkMin, linkMax);
        }
        
        /// <summary>
        ///     Setup the axis scale using the specified axis
        /// </summary>
        /// <param name="axis">The axis</param>
        /// <param name="scale">The scale</param>
        public static void SetupAxisScale(ImAxis axis, ImPlotScale scale)
        {
            ImPlotNative.ImPlot_SetupAxisScale_PlotScale(axis, scale);
        }
        
        /// <summary>
        ///     Setup the axis scale using the specified axis
        /// </summary>
        /// <param name="axis">The axis</param>
        /// <param name="forward">The forward</param>
        /// <param name="inverse">The inverse</param>
        public static void SetupAxisScale(ImAxis axis, IntPtr forward, IntPtr inverse)
        {
            ImPlotNative.ImPlot_SetupAxisScale_PlotTransform(axis, forward, inverse, IntPtr.Zero);
        }
        
        /// <summary>
        ///     Setup the axis scale using the specified axis
        /// </summary>
        /// <param name="axis">The axis</param>
        /// <param name="forward">The forward</param>
        /// <param name="inverse">The inverse</param>
        /// <param name="data">The data</param>
        public static void SetupAxisScale(ImAxis axis, IntPtr forward, IntPtr inverse, IntPtr data)
        {
            ImPlotNative.ImPlot_SetupAxisScale_PlotTransform(axis, forward, inverse, data);
        }
        
        /// <summary>
        ///     Setup the axis ticks using the specified axis
        /// </summary>
        /// <param name="axis">The axis</param>
        /// <param name="values">The values</param>
        /// <param name="nTicks">The ticks</param>
        public static void SetupAxisTicks(ImAxis axis, ref double values, int nTicks)
        {
            ImPlotNative.ImPlot_SetupAxisTicks_doublePtr(axis, ref values, nTicks, null, 0);
        }
        
        /// <summary>
        ///     Setup the axis ticks using the specified axis
        /// </summary>
        /// <param name="axis">The axis</param>
        /// <param name="values">The values</param>
        /// <param name="nTicks">The ticks</param>
        /// <param name="labels">The labels</param>
        public static void SetupAxisTicks(ImAxis axis, ref double values, int nTicks, string[] labels)
        {
            ImPlotNative.ImPlot_SetupAxisTicks_doublePtr(axis, ref values, nTicks, null, 0);
        }
        
        /// <summary>
        ///     Setup the axis ticks using the specified axis
        /// </summary>
        /// <param name="axis">The axis</param>
        /// <param name="values">The values</param>
        /// <param name="nTicks">The ticks</param>
        /// <param name="labels">The labels</param>
        /// <param name="keepDefault">The keep default</param>
        public static void SetupAxisTicks(ImAxis axis, ref double values, int nTicks, string[] labels, bool keepDefault)
        {
            ImPlotNative.ImPlot_SetupAxisTicks_doublePtr(axis, ref values, nTicks, null, 0);
        }
        
        /// <summary>
        ///     Setup the axis ticks using the specified axis
        /// </summary>
        /// <param name="axis">The axis</param>
        /// <param name="vMin">The min</param>
        /// <param name="vMax">The max</param>
        /// <param name="nTicks">The ticks</param>
        public static void SetupAxisTicks(ImAxis axis, double vMin, double vMax, int nTicks)
        {
            ImPlotNative.ImPlot_SetupAxisTicks_double(axis, vMin, vMax, nTicks, Array.Empty<byte[]>(), 0);
        }
        
        /// <summary>
        ///     Setup the axis ticks using the specified axis
        /// </summary>
        /// <param name="axis">The axis</param>
        /// <param name="vMin">The min</param>
        /// <param name="vMax">The max</param>
        /// <param name="nTicks">The ticks</param>
        /// <param name="labels">The labels</param>
        public static void SetupAxisTicks(ImAxis axis, double vMin, double vMax, int nTicks, string[] labels)
        {
            ImPlotNative.ImPlot_SetupAxisTicks_double(axis, vMin, vMax, nTicks, Array.Empty<byte[]>(), 0);
        }
        
        /// <summary>
        ///     Setup the axis ticks using the specified axis
        /// </summary>
        /// <param name="axis">The axis</param>
        /// <param name="vMin">The min</param>
        /// <param name="vMax">The max</param>
        /// <param name="nTicks">The ticks</param>
        /// <param name="labels">The labels</param>
        /// <param name="keepDefault">The keep default</param>
        public static void SetupAxisTicks(ImAxis axis, double vMin, double vMax, int nTicks, string[] labels, bool keepDefault)
        {
            ImPlotNative.ImPlot_SetupAxisTicks_double(axis, vMin, vMax, nTicks, Array.Empty<byte[]>(), 0);
        }
        
        /// <summary>
        ///     Setup the axis zoom constraints using the specified axis
        /// </summary>
        /// <param name="axis">The axis</param>
        /// <param name="zMin">The min</param>
        /// <param name="zMax">The max</param>
        public static void SetupAxisZoomConstraints(ImAxis axis, double zMin, double zMax)
        {
            ImPlotNative.ImPlot_SetupAxisZoomConstraints(axis, zMin, zMax);
        }
        
        /// <summary>
        ///     Setup the finish
        /// </summary>
        public static void SetupFinish()
        {
            ImPlotNative.ImPlot_SetupFinish();
        }
        
        /// <summary>
        ///     Setup the legend using the specified location
        /// </summary>
        /// <param name="location">The location</param>
        public static void SetupLegend(ImPlotLocation location)
        {
            ImPlotLegendFlags flags = 0;
            ImPlotNative.ImPlot_SetupLegend(location, flags);
        }
        
        /// <summary>
        ///     Setup the legend using the specified location
        /// </summary>
        /// <param name="location">The location</param>
        /// <param name="flags">The flags</param>
        public static void SetupLegend(ImPlotLocation location, ImPlotLegendFlags flags)
        {
            ImPlotNative.ImPlot_SetupLegend(location, flags);
        }
        
        /// <summary>
        ///     Setup the mouse text using the specified location
        /// </summary>
        /// <param name="location">The location</param>
        public static void SetupMouseText(ImPlotLocation location)
        {
            ImPlotMouseTextFlags flags = 0;
            ImPlotNative.ImPlot_SetupMouseText(location, flags);
        }
        
        /// <summary>
        ///     Setup the mouse text using the specified location
        /// </summary>
        /// <param name="location">The location</param>
        /// <param name="flags">The flags</param>
        public static void SetupMouseText(ImPlotLocation location, ImPlotMouseTextFlags flags)
        {
            ImPlotNative.ImPlot_SetupMouseText(location, flags);
        }
        
        /// <summary>
        ///     Describes whether show colormap selector
        /// </summary>
        /// <param name="label">The label</param>
        /// <returns>The bool</returns>
        public static bool ShowColormapSelector(string label)
        {
            byte ret = ImPlotNative.ImPlot_ShowColormapSelector(Encoding.UTF8.GetBytes(label));
            return ret != 0;
        }
        
        /// <summary>
        ///     Shows the demo window
        /// </summary>
        public static void ShowDemoWindow()
        {
            ImPlotNative.ImPlot_ShowDemoWindow(0);
        }
        
        /// <summary>
        ///     Shows the demo window using the specified p open
        /// </summary>
        /// <param name="pOpen">The open</param>
        public static void ShowDemoWindow(ref bool pOpen)
        {
            byte nativePOpenVal = pOpen ? (byte) 1 : (byte) 0;
            ImPlotNative.ImPlot_ShowDemoWindow(nativePOpenVal);
            pOpen = nativePOpenVal != 0;
        }
        
        /// <summary>
        ///     Describes whether show input map selector
        /// </summary>
        /// <param name="label">The label</param>
        /// <returns>The bool</returns>
        public static bool ShowInputMapSelector(string label)
        {
            byte ret = ImPlotNative.ImPlot_ShowInputMapSelector(Encoding.UTF8.GetBytes(label));
            return ret != 0;
        }
        
        /// <summary>
        ///     Shows the metrics window
        /// </summary>
        public static void ShowMetricsWindow()
        {
            ImPlotNative.ImPlot_ShowMetricsWindow(0);
        }
        
        /// <summary>
        ///     Shows the metrics window using the specified p popen
        /// </summary>
        /// <param name="pPopen">The popen</param>
        public static void ShowMetricsWindow(ref bool pPopen)
        {
            byte nativePPopenVal = pPopen ? (byte) 1 : (byte) 0;
            ImPlotNative.ImPlot_ShowMetricsWindow(nativePPopenVal);
            pPopen = nativePPopenVal != 0;
        }
        
        /// <summary>
        ///     Shows the style editor
        /// </summary>
        public static void ShowStyleEditor()
        {
            ImPlotNative.ImPlot_ShowStyleEditor(new ImPlotStyle());
        }
        
        /// <summary>
        ///     Shows the style editor using the specified ref
        /// </summary>
        public static void ShowStyleEditor(ImPlotStyle imPlotStyle)
        {
            ImPlotNative.ImPlot_ShowStyleEditor(imPlotStyle);
        }
        
        /// <summary>
        ///     Describes whether show style selector
        /// </summary>
        /// <param name="label">The label</param>
        /// <returns>The bool</returns>
        public static bool ShowStyleSelector(string label)
        {
            byte ret = ImPlotNative.ImPlot_ShowStyleSelector(Encoding.UTF8.GetBytes(label));
            return ret != 0;
        }
        
        /// <summary>
        ///     Shows the user guide
        /// </summary>
        public static void ShowUserGuide()
        {
            ImPlotNative.ImPlot_ShowUserGuide();
        }
        
        /// <summary>
        ///     Styles the colors auto
        /// </summary>
        public static void StyleColorsAuto()
        {
            ImPlotNative.ImPlot_StyleColorsAuto(new ImPlotStyle());
        }
        
        /// <summary>
        ///     Styles the colors auto using the specified dst
        /// </summary>
        /// <param name="dst">The dst</param>
        public static void StyleColorsAuto(ImPlotStyle dst)
        {
            ImPlotNative.ImPlot_StyleColorsAuto(dst);
        }
        
        /// <summary>
        ///     Styles the colors classic
        /// </summary>
        public static void StyleColorsClassic()
        {
            ImPlotNative.ImPlot_StyleColorsClassic(new ImPlotStyle());
        }
        
        /// <summary>
        ///     Styles the colors classic using the specified dst
        /// </summary>
        /// <param name="dst">The dst</param>
        public static void StyleColorsClassic(ImPlotStyle dst)
        {
            ImPlotNative.ImPlot_StyleColorsClassic(dst);
        }
        
        /// <summary>
        ///     Styles the colors dark
        /// </summary>
        public static void StyleColorsDark()
        {
            ImPlotNative.ImPlot_StyleColorsDark(new ImPlotStyle());
        }
        
        /// <summary>
        ///     Styles the colors dark using the specified dst
        /// </summary>
        /// <param name="dst">The dst</param>
        public static void StyleColorsDark(ImPlotStyle dst)
        {
            ImPlotNative.ImPlot_StyleColorsDark(dst);
        }
        
        /// <summary>
        ///     Styles the colors light
        /// </summary>
        public static void StyleColorsLight()
        {
            ImPlotNative.ImPlot_StyleColorsLight(new ImPlotStyle());
        }
        
        /// <summary>
        ///     Styles the colors light using the specified dst
        /// </summary>
        /// <param name="dst">The dst</param>
        public static void StyleColorsLight(ImPlotStyle dst)
        {
            ImPlotNative.ImPlot_StyleColorsLight(dst);
        }
        
        /// <summary>
        ///     Tags the x using the specified x
        /// </summary>
        /// <param name="x">The </param>
        /// <param name="col">The col</param>
        public static void TagX(double x, Vector4 col)
        {
            byte round = 0;
            ImPlotNative.ImPlot_TagX_Bool(x, col, round);
        }
        
        /// <summary>
        ///     Tags the x using the specified x
        /// </summary>
        /// <param name="x">The </param>
        /// <param name="col">The col</param>
        /// <param name="round">The round</param>
        public static void TagX(double x, Vector4 col, bool round)
        {
            byte nativeRound = round ? (byte) 1 : (byte) 0;
            ImPlotNative.ImPlot_TagX_Bool(x, col, nativeRound);
        }
        
        /// <summary>
        ///     Tags the x using the specified x
        /// </summary>
        /// <param name="x">The </param>
        /// <param name="col">The col</param>
        /// <param name="fmt">The fmt</param>
        public static void TagX(double x, Vector4 col, string fmt)
        {
            ImPlotNative.ImPlot_TagX_Str(x, col, Encoding.UTF8.GetBytes(fmt));
        }
        
        /// <summary>
        ///     Tags the y using the specified y
        /// </summary>
        /// <param name="y">The </param>
        /// <param name="col">The col</param>
        public static void TagY(double y, Vector4 col)
        {
            byte round = 0;
            ImPlotNative.ImPlot_TagY_Bool(y, col, round);
        }
        
        /// <summary>
        ///     Tags the y using the specified y
        /// </summary>
        /// <param name="y">The </param>
        /// <param name="col">The col</param>
        /// <param name="round">The round</param>
        public static void TagY(double y, Vector4 col, bool round)
        {
            byte nativeRound = round ? (byte) 1 : (byte) 0;
            ImPlotNative.ImPlot_TagY_Bool(y, col, nativeRound);
        }
        
        /// <summary>
        ///     Tags the y using the specified y
        /// </summary>
        /// <param name="y">The </param>
        /// <param name="col">The col</param>
        /// <param name="fmt">The fmt</param>
        public static void TagY(double y, Vector4 col, string fmt)
        {
            ImPlotNative.ImPlot_TagY_Str(y, col, Encoding.UTF8.GetBytes(fmt));
        }
    }
}