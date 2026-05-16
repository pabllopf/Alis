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

namespace Alis.Extension.Graphic.Ui.Extras.Plot
{
    /// <summary>
    ///     Provides managed wrappers over the CImPlot native library for creating and interacting with ImPlot plots.
    /// </summary>
    public static partial class ImPlot
    {
        /// <summary>
        ///     Draws a stem plot with ushort X/Y data, a baseline reference, and explicit flags.
        /// </summary>
        /// <param name="labelId">Unique label for identifying this plot series in the legend</param>
        /// <param name="xs">X-coordinate values for each data point</param>
        /// <param name="ys">Y-coordinate values for each data point</param>
        /// <param name="count">Number of data points to plot</param>
        /// <param name="ref">Baseline reference value from which stems originate</param>
        /// <param name="flags">Combination of ImPlotStemsFlags controlling stem appearance</param>
        public static void PlotStems(string labelId, ref ushort xs, ref ushort ys, int count, double @ref, ImPlotStemsFlags flags)
        {
            ImPlotNative.ImPlot_PlotStems_U16PtrU16Ptr(Encoding.UTF8.GetBytes(labelId), ref xs, ref ys, count, @ref, flags, 0, sizeof(ushort));
        }

        /// <summary>
        ///     Draws a stem plot with ushort X/Y data, a baseline, flags, and a data offset.
        /// </summary>
        /// <param name="labelId">Unique label for identifying this plot series in the legend</param>
        /// <param name="xs">X-coordinate values for each data point</param>
        /// <param name="ys">Y-coordinate values for each data point</param>
        /// <param name="count">Number of data points to plot</param>
        /// <param name="ref">Baseline reference value from which stems originate</param>
        /// <param name="flags">Combination of ImPlotStemsFlags controlling stem appearance</param>
        /// <param name="offset">Index offset into the data arrays</param>
        public static void PlotStems(string labelId, ref ushort xs, ref ushort ys, int count, double @ref, ImPlotStemsFlags flags, int offset)
        {
            ImPlotNative.ImPlot_PlotStems_U16PtrU16Ptr(Encoding.UTF8.GetBytes(labelId), ref xs, ref ys, count, @ref, flags, offset, sizeof(ushort));
        }

        /// <summary>
        ///     Draws a stem plot with ushort X/Y data, a baseline, flags, offset, and stride.
        /// </summary>
        /// <param name="labelId">Unique label for identifying this plot series in the legend</param>
        /// <param name="xs">X-coordinate values for each data point</param>
        /// <param name="ys">Y-coordinate values for each data point</param>
        /// <param name="count">Number of data points to plot</param>
        /// <param name="ref">Baseline reference value from which stems originate</param>
        /// <param name="flags">Combination of ImPlotStemsFlags controlling stem appearance</param>
        /// <param name="offset">Index offset into the data arrays</param>
        /// <param name="stride">Byte stride between consecutive elements in the arrays</param>
        public static void PlotStems(string labelId, ref ushort xs, ref ushort ys, int count, double @ref, ImPlotStemsFlags flags, int offset, int stride)
        {
            ImPlotNative.ImPlot_PlotStems_U16PtrU16Ptr(Encoding.UTF8.GetBytes(labelId), ref xs, ref ys, count, @ref, flags, offset, stride);
        }

        /// <summary>
        ///     Plots the stems using the specified label id
        /// </summary>
        /// <param name="labelId">The label identifier for the plot item</param>
        /// <param name="xs">The array of x-coordinate values</param>
        /// <param name="ys">The array of y-coordinate values</param>
        /// <param name="count">The number of elements</param>
        public static void PlotStems(string labelId, ref int xs, ref int ys, int count)
        {
            ImPlotNative.ImPlot_PlotStems_S32PtrS32Ptr(Encoding.UTF8.GetBytes(labelId), xs, ys, count, 0, 0, 0, sizeof(int));
        }

        /// <summary>
        ///     Plots the stems using the specified label id
        /// </summary>
        /// <param name="labelId">The label identifier for the plot item</param>
        /// <param name="xs">The array of x-coordinate values</param>
        /// <param name="ys">The array of y-coordinate values</param>
        /// <param name="count">The number of elements</param>
        /// <param name="ref">The reference value</param>
        public static void PlotStems(string labelId, ref int xs, ref int ys, int count, double @ref)
        {
            ImPlotNative.ImPlot_PlotStems_S32PtrS32Ptr(Encoding.UTF8.GetBytes(labelId), xs, ys, count, @ref, 0, 0, sizeof(int));
        }

        /// <summary>
        ///     Plots the stems using the specified label id
        /// </summary>
        /// <param name="labelId">The label identifier for the plot item</param>
        /// <param name="xs">The array of x-coordinate values</param>
        /// <param name="ys">The array of y-coordinate values</param>
        /// <param name="count">The number of elements</param>
        /// <param name="ref">The reference value</param>
        /// <param name="flags">The ImGui behavior flags</param>
        public static void PlotStems(string labelId, ref int xs, ref int ys, int count, double @ref, ImPlotStemsFlags flags)
        {
            ImPlotNative.ImPlot_PlotStems_S32PtrS32Ptr(Encoding.UTF8.GetBytes(labelId), xs, ys, count, @ref, flags, 0, sizeof(int));
        }

        /// <summary>
        ///     Plots the stems using the specified label id
        /// </summary>
        /// <param name="labelId">The label identifier for the plot item</param>
        /// <param name="xs">The array of x-coordinate values</param>
        /// <param name="ys">The array of y-coordinate values</param>
        /// <param name="count">The number of elements</param>
        /// <param name="ref">The reference value</param>
        /// <param name="flags">The ImGui behavior flags</param>
        /// <param name="offset">The offset from the origin</param>
        public static void PlotStems(string labelId, ref int xs, ref int ys, int count, double @ref, ImPlotStemsFlags flags, int offset)
        {
            ImPlotNative.ImPlot_PlotStems_S32PtrS32Ptr(Encoding.UTF8.GetBytes(labelId), xs, ys, count, @ref, flags, offset, sizeof(int));
        }

        /// <summary>
        ///     Plots the stems using the specified label id
        /// </summary>
        /// <param name="labelId">The label identifier for the plot item</param>
        /// <param name="xs">The array of x-coordinate values</param>
        /// <param name="ys">The array of y-coordinate values</param>
        /// <param name="count">The number of elements</param>
        /// <param name="ref">The reference value</param>
        /// <param name="flags">The ImGui behavior flags</param>
        /// <param name="offset">The offset from the origin</param>
        /// <param name="stride">The byte stride between elements</param>
        public static void PlotStems(string labelId, ref int xs, ref int ys, int count, double @ref, ImPlotStemsFlags flags, int offset, int stride)
        {
            ImPlotNative.ImPlot_PlotStems_S32PtrS32Ptr(Encoding.UTF8.GetBytes(labelId), xs, ys, count, @ref, flags, offset, stride);
        }

        /// <summary>
        ///     Plots the stems using the specified label id
        /// </summary>
        /// <param name="labelId">The label identifier for the plot item</param>
        /// <param name="xs">The array of x-coordinate values</param>
        /// <param name="ys">The array of y-coordinate values</param>
        /// <param name="count">The number of elements</param>
        public static void PlotStems(string labelId, ref uint xs, ref uint ys, int count)
        {
            ImPlotNative.ImPlot_PlotStems_U32PtrU32Ptr(Encoding.UTF8.GetBytes(labelId), xs, ys, count, 0, 0, 0, sizeof(uint));
        }

        /// <summary>
        ///     Plots the stems using the specified label id
        /// </summary>
        /// <param name="labelId">The label identifier for the plot item</param>
        /// <param name="xs">The array of x-coordinate values</param>
        /// <param name="ys">The array of y-coordinate values</param>
        /// <param name="count">The number of elements</param>
        /// <param name="ref">The reference value</param>
        public static void PlotStems(string labelId, ref uint xs, ref uint ys, int count, double @ref)
        {
            ImPlotNative.ImPlot_PlotStems_U32PtrU32Ptr(Encoding.UTF8.GetBytes(labelId), xs, ys, count, @ref, 0, 0, sizeof(uint));
        }

        /// <summary>
        ///     Plots the stems using the specified label id
        /// </summary>
        /// <param name="labelId">The label identifier for the plot item</param>
        /// <param name="xs">The array of x-coordinate values</param>
        /// <param name="ys">The array of y-coordinate values</param>
        /// <param name="count">The number of elements</param>
        /// <param name="ref">The reference value</param>
        /// <param name="flags">The ImGui behavior flags</param>
        public static void PlotStems(string labelId, ref uint xs, ref uint ys, int count, double @ref, ImPlotStemsFlags flags)
        {
            ImPlotNative.ImPlot_PlotStems_U32PtrU32Ptr(Encoding.UTF8.GetBytes(labelId), xs, ys, count, @ref, flags, 0, sizeof(uint));
        }

        /// <summary>
        ///     Plots the stems using the specified label id
        /// </summary>
        /// <param name="labelId">The label identifier for the plot item</param>
        /// <param name="xs">The array of x-coordinate values</param>
        /// <param name="ys">The array of y-coordinate values</param>
        /// <param name="count">The number of elements</param>
        /// <param name="ref">The reference value</param>
        /// <param name="flags">The ImGui behavior flags</param>
        /// <param name="offset">The offset from the origin</param>
        public static void PlotStems(string labelId, ref uint xs, ref uint ys, int count, double @ref, ImPlotStemsFlags flags, int offset)
        {
            ImPlotNative.ImPlot_PlotStems_U32PtrU32Ptr(Encoding.UTF8.GetBytes(labelId), xs, ys, count, @ref, flags, offset, sizeof(uint));
        }

        /// <summary>
        ///     Plots the stems using the specified label id
        /// </summary>
        /// <param name="labelId">The label identifier for the plot item</param>
        /// <param name="xs">The array of x-coordinate values</param>
        /// <param name="ys">The array of y-coordinate values</param>
        /// <param name="count">The number of elements</param>
        /// <param name="ref">The reference value</param>
        /// <param name="flags">The ImGui behavior flags</param>
        /// <param name="offset">The offset from the origin</param>
        /// <param name="stride">The byte stride between elements</param>
        public static void PlotStems(string labelId, ref uint xs, ref uint ys, int count, double @ref, ImPlotStemsFlags flags, int offset, int stride)
        {
            ImPlotNative.ImPlot_PlotStems_U32PtrU32Ptr(Encoding.UTF8.GetBytes(labelId), xs, ys, count, @ref, flags, offset, stride);
        }

        /// <summary>
        ///     Plots the stems using the specified label id
        /// </summary>
        /// <param name="labelId">The label identifier for the plot item</param>
        /// <param name="xs">The array of x-coordinate values</param>
        /// <param name="ys">The array of y-coordinate values</param>
        /// <param name="count">The number of elements</param>
        public static void PlotStems(string labelId, ref long xs, ref long ys, int count)
        {
            ImPlotNative.ImPlot_PlotStems_S64PtrS64Ptr(Encoding.UTF8.GetBytes(labelId), ref xs, ref ys, count, 0, 0, 0, sizeof(long));
        }

        /// <summary>
        ///     Plots the stems using the specified label id
        /// </summary>
        /// <param name="labelId">The label identifier for the plot item</param>
        /// <param name="xs">The array of x-coordinate values</param>
        /// <param name="ys">The array of y-coordinate values</param>
        /// <param name="count">The number of elements</param>
        /// <param name="ref">The reference value</param>
        public static void PlotStems(string labelId, ref long xs, ref long ys, int count, double @ref)
        {
            ImPlotNative.ImPlot_PlotStems_S64PtrS64Ptr(Encoding.UTF8.GetBytes(labelId), ref xs, ref ys, count, @ref, 0, 0, sizeof(long));
        }

        /// <summary>
        ///     Plots the stems using the specified label id
        /// </summary>
        /// <param name="labelId">The label identifier for the plot item</param>
        /// <param name="xs">The array of x-coordinate values</param>
        /// <param name="ys">The array of y-coordinate values</param>
        /// <param name="count">The number of elements</param>
        /// <param name="ref">The reference value</param>
        /// <param name="flags">The ImGui behavior flags</param>
        public static void PlotStems(string labelId, ref long xs, ref long ys, int count, double @ref, ImPlotStemsFlags flags)
        {
            ImPlotNative.ImPlot_PlotStems_S64PtrS64Ptr(Encoding.UTF8.GetBytes(labelId), ref xs, ref ys, count, @ref, flags, 0, sizeof(long));
        }

        /// <summary>
        ///     Plots the stems using the specified label id
        /// </summary>
        /// <param name="labelId">The label identifier for the plot item</param>
        /// <param name="xs">The array of x-coordinate values</param>
        /// <param name="ys">The array of y-coordinate values</param>
        /// <param name="count">The number of elements</param>
        /// <param name="ref">The reference value</param>
        /// <param name="flags">The ImGui behavior flags</param>
        /// <param name="offset">The offset from the origin</param>
        public static void PlotStems(string labelId, ref long xs, ref long ys, int count, double @ref, ImPlotStemsFlags flags, int offset)
        {
            ImPlotNative.ImPlot_PlotStems_S64PtrS64Ptr(Encoding.UTF8.GetBytes(labelId), ref xs, ref ys, count, @ref, flags, offset, sizeof(long));
        }

        /// <summary>
        ///     Plots the stems using the specified label id
        /// </summary>
        /// <param name="labelId">The label identifier for the plot item</param>
        /// <param name="xs">The array of x-coordinate values</param>
        /// <param name="ys">The array of y-coordinate values</param>
        /// <param name="count">The number of elements</param>
        /// <param name="ref">The reference value</param>
        /// <param name="flags">The ImGui behavior flags</param>
        /// <param name="offset">The offset from the origin</param>
        /// <param name="stride">The byte stride between elements</param>
        public static void PlotStems(string labelId, ref long xs, ref long ys, int count, double @ref, ImPlotStemsFlags flags, int offset, int stride)
        {
            ImPlotNative.ImPlot_PlotStems_S64PtrS64Ptr(Encoding.UTF8.GetBytes(labelId), ref xs, ref ys, count, @ref, flags, offset, stride);
        }

        /// <summary>
        ///     Plots the stems using the specified label id
        /// </summary>
        /// <param name="labelId">The label identifier for the plot item</param>
        /// <param name="xs">The array of x-coordinate values</param>
        /// <param name="ys">The array of y-coordinate values</param>
        /// <param name="count">The number of elements</param>
        public static void PlotStems(string labelId, ref ulong xs, ref ulong ys, int count)
        {
            ImPlotNative.ImPlot_PlotStems_U64PtrU64Ptr(Encoding.UTF8.GetBytes(labelId), ref xs, ref ys, count, 0, 0, 0, sizeof(ulong));
        }

        /// <summary>
        ///     Plots the stems using the specified label id
        /// </summary>
        /// <param name="labelId">The label identifier for the plot item</param>
        /// <param name="xs">The array of x-coordinate values</param>
        /// <param name="ys">The array of y-coordinate values</param>
        /// <param name="count">The number of elements</param>
        /// <param name="ref">The reference value</param>
        public static void PlotStems(string labelId, ref ulong xs, ref ulong ys, int count, double @ref)
        {
            ImPlotNative.ImPlot_PlotStems_U64PtrU64Ptr(Encoding.UTF8.GetBytes(labelId), ref xs, ref ys, count, @ref, 0, 0, sizeof(ulong));
        }

        /// <summary>
        ///     Plots the stems using the specified label id
        /// </summary>
        /// <param name="labelId">The label identifier for the plot item</param>
        /// <param name="xs">The array of x-coordinate values</param>
        /// <param name="ys">The array of y-coordinate values</param>
        /// <param name="count">The number of elements</param>
        /// <param name="ref">The reference value</param>
        /// <param name="flags">The ImGui behavior flags</param>
        public static void PlotStems(string labelId, ref ulong xs, ref ulong ys, int count, double @ref, ImPlotStemsFlags flags)
        {
            ImPlotNative.ImPlot_PlotStems_U64PtrU64Ptr(Encoding.UTF8.GetBytes(labelId), ref xs, ref ys, count, @ref, flags, 0, sizeof(ulong));
        }

        /// <summary>
        ///     Plots the stems using the specified label id
        /// </summary>
        /// <param name="labelId">The label identifier for the plot item</param>
        /// <param name="xs">The array of x-coordinate values</param>
        /// <param name="ys">The array of y-coordinate values</param>
        /// <param name="count">The number of elements</param>
        /// <param name="ref">The reference value</param>
        /// <param name="flags">The ImGui behavior flags</param>
        /// <param name="offset">The offset from the origin</param>
        public static void PlotStems(string labelId, ref ulong xs, ref ulong ys, int count, double @ref, ImPlotStemsFlags flags, int offset)
        {
            ImPlotNative.ImPlot_PlotStems_U64PtrU64Ptr(Encoding.UTF8.GetBytes(labelId), ref xs, ref ys, count, @ref, flags, offset, sizeof(ulong));
        }

        /// <summary>
        ///     Plots the stems using the specified label id
        /// </summary>
        /// <param name="labelId">The label identifier for the plot item</param>
        /// <param name="xs">The array of x-coordinate values</param>
        /// <param name="ys">The array of y-coordinate values</param>
        /// <param name="count">The number of elements</param>
        /// <param name="ref">The reference value</param>
        /// <param name="flags">The ImGui behavior flags</param>
        /// <param name="offset">The offset from the origin</param>
        /// <param name="stride">The byte stride between elements</param>
        public static void PlotStems(string labelId, ref ulong xs, ref ulong ys, int count, double @ref, ImPlotStemsFlags flags, int offset, int stride)
        {
            ImPlotNative.ImPlot_PlotStems_U64PtrU64Ptr(Encoding.UTF8.GetBytes(labelId), ref xs, ref ys, count, @ref, flags, offset, stride);
        }

        /// <summary>
        ///     Draws a text label at the specified plot coordinates.
        /// </summary>
        /// <param name="text">Text content to display</param>
        /// <param name="x">X-coordinate in plot space</param>
        /// <param name="y">Y-coordinate in plot space</param>
        public static void PlotText(string text, double x, double y)
        {
            ImPlotNative.ImPlot_PlotText(Encoding.UTF8.GetBytes(text), x, y, new Vector2F(0, 0), ImPlotTextFlags.None);
        }

        /// <summary>
        ///     Draws a text label at the specified plot coordinates with a pixel offset.
        /// </summary>
        /// <param name="text">Text content to display</param>
        /// <param name="x">X-coordinate in plot space</param>
        /// <param name="y">Y-coordinate in plot space</param>
        /// <param name="pixOffset">Pixel offset from the anchor point</param>
        public static void PlotText(string text, double x, double y, Vector2F pixOffset)
        {
            ImPlotNative.ImPlot_PlotText(Encoding.UTF8.GetBytes(text), x, y, pixOffset, ImPlotTextFlags.None);
        }

        /// <summary>
        ///     Draws a text label with a pixel offset and text orientation flags.
        /// </summary>
        /// <param name="text">Text content to display</param>
        /// <param name="x">X-coordinate in plot space</param>
        /// <param name="y">Y-coordinate in plot space</param>
        /// <param name="pixOffset">Pixel offset from the anchor point</param>
        /// <param name="flags">Combination of ImPlotTextFlags controlling text orientation</param>
        public static void PlotText(string text, double x, double y, Vector2F pixOffset, ImPlotTextFlags flags)
        {
            ImPlotNative.ImPlot_PlotText(Encoding.UTF8.GetBytes(text), x, y, pixOffset, flags);
        }

        /// <summary>
        ///     Converts a plot-space ImPlotPoint to pixel coordinates.
        /// </summary>
        /// <param name="plt">The plot-space point to convert</param>
        /// <returns>The pixel-space coordinates of the point</returns>
        public static Vector2F PlotToPixels(ImPlotPoint plt)
        {
            ImAxis xAxis = (ImAxis) (-1);
            ImAxis yAxis = (ImAxis) (-1);
            ImPlotNative.ImPlot_PlotToPixels_PlotPoInt(out Vector2F retval, plt, xAxis, yAxis);
            return retval;
        }

        /// <summary>
        ///     Converts a plot-space ImPlotPoint to pixel coordinates, specifying the X axis.
        /// </summary>
        /// <param name="plt">The plot-space point to convert</param>
        /// <param name="xAxis">X axis to use for the conversion</param>
        /// <returns>The pixel-space coordinates of the point</returns>
        public static Vector2F PlotToPixels(ImPlotPoint plt, ImAxis xAxis)
        {
            ImAxis yAxis = (ImAxis) (-1);
            ImPlotNative.ImPlot_PlotToPixels_PlotPoInt(out Vector2F retval, plt, xAxis, yAxis);
            return retval;
        }

        /// <summary>
        ///     Converts a plot-space ImPlotPoint to pixel coordinates with explicit axes.
        /// </summary>
        /// <param name="plt">The plot-space point to convert</param>
        /// <param name="xAxis">X axis to use for the conversion</param>
        /// <param name="yAxis">Y axis to use for the conversion</param>
        /// <returns>The pixel-space coordinates of the point</returns>
        public static Vector2F PlotToPixels(ImPlotPoint plt, ImAxis xAxis, ImAxis yAxis)
        {
            ImPlotNative.ImPlot_PlotToPixels_PlotPoInt(out Vector2F retval, plt, xAxis, yAxis);
            return retval;
        }

        /// <summary>
        ///     Converts plot-space (X, Y) doubles to pixel coordinates.
        /// </summary>
        /// <param name="x">X-coordinate in plot space</param>
        /// <param name="y">Y-coordinate in plot space</param>
        /// <returns>The pixel-space coordinates of the point</returns>
        public static Vector2F PlotToPixels(double x, double y)
        {
            ImAxis xAxis = (ImAxis) (-1);
            ImAxis yAxis = (ImAxis) (-1);
            ImPlotNative.ImPlot_PlotToPixels_double(out Vector2F retval, x, y, xAxis, yAxis);
            return retval;
        }

        /// <summary>
        ///     Converts plot-space doubles to pixel coordinates with an explicit X axis.
        /// </summary>
        /// <param name="x">X-coordinate in plot space</param>
        /// <param name="y">Y-coordinate in plot space</param>
        /// <param name="xAxis">X axis to use for the conversion</param>
        /// <returns>The pixel-space coordinates of the point</returns>
        public static Vector2F PlotToPixels(double x, double y, ImAxis xAxis)
        {
            ImAxis yAxis = (ImAxis) (-1);
            ImPlotNative.ImPlot_PlotToPixels_double(out Vector2F retval, x, y, xAxis, yAxis);
            return retval;
        }

        /// <summary>
        ///     Converts plot-space doubles to pixel coordinates with explicit axes.
        /// </summary>
        /// <param name="x">X-coordinate in plot space</param>
        /// <param name="y">Y-coordinate in plot space</param>
        /// <param name="xAxis">X axis to use for the conversion</param>
        /// <param name="yAxis">Y axis to use for the conversion</param>
        /// <returns>The pixel-space coordinates of the point</returns>
        public static Vector2F PlotToPixels(double x, double y, ImAxis xAxis, ImAxis yAxis)
        {
            ImPlotNative.ImPlot_PlotToPixels_double(out Vector2F retval, x, y, xAxis, yAxis);
            return retval;
        }

        /// <summary>
        ///     Pops one level from the colormap stack.
        /// </summary>
        public static void PopColormap()
        {
            int count = 1;
            ImPlotNative.ImPlot_PopColormap(count);
        }

        /// <summary>
        ///     Pops the specified number of levels from the colormap stack.
        /// </summary>
        /// <param name="count">Number of colormap levels to pop</param>
        public static void PopColormap(int count)
        {
            ImPlotNative.ImPlot_PopColormap(count);
        }

        /// <summary>
        ///     Restores the previous plot clipping rectangle.
        /// </summary>
        public static void PopPlotClipRect()
        {
            ImPlotNative.ImPlot_PopPlotClipRect();
        }

        /// <summary>
        ///     Pops one level from the plot style color stack.
        /// </summary>
        public static void PopStyleColor()
        {
            int count = 1;
            ImPlotNative.ImPlot_PopStyleColor(count);
        }

        /// <summary>
        ///     Pops the specified number of levels from the style color stack.
        /// </summary>
        /// <param name="count">Number of color levels to restore</param>
        public static void PopStyleColor(int count)
        {
            ImPlotNative.ImPlot_PopStyleColor(count);
        }

        /// <summary>
        ///     Pops one level from the plot style variable stack.
        /// </summary>
        public static void PopStyleVar()
        {
            int count = 1;
            ImPlotNative.ImPlot_PopStyleVar(count);
        }

        /// <summary>
        ///     Pops the specified number of levels from the style variable stack.
        /// </summary>
        /// <param name="count">Number of style vars to restore</param>
        public static void PopStyleVar(int count)
        {
            ImPlotNative.ImPlot_PopStyleVar(count);
        }

        /// <summary>
        ///     Pushes a predefined colormap onto the colormap stack.
        /// </summary>
        /// <param name="cmap">The colormap to activate</param>
        public static void PushColormap(ImPlotColormap cmap)
        {
            ImPlotNative.ImPlot_PushColormap_PlotColormap(cmap);
        }

        /// <summary>
        ///     Pushes a custom named colormap onto the colormap stack.
        /// </summary>
        /// <param name="name">Name of the custom colormap</param>
        public static void PushColormap(string name)
        {
            ImPlotNative.ImPlot_PushColormap_Str(Encoding.UTF8.GetBytes(name));
        }

        /// <summary>
        ///     Pushes a new plot clipping rectangle with no expansion.
        /// </summary>
        public static void PushPlotClipRect()
        {
            float expand = 0;
            ImPlotNative.ImPlot_PushPlotClipRect(expand);
        }

        /// <summary>
        ///     Pushes a new plot clipping rectangle with the specified expansion.
        /// </summary>
        /// <param name="expand">Expansion (in pixels) applied to the clipping rect</param>
        public static void PushPlotClipRect(float expand)
        {
            ImPlotNative.ImPlot_PushPlotClipRect(expand);
        }

        /// <summary>
        ///     Pushes a plot color value onto the style stack (as a packed uint).
        /// </summary>
        /// <param name="idx">The style color index to modify</param>
        /// <param name="col">New color value as a packed 32-bit ABGR unsigned integer</param>
        public static void PushStyleColor(ImPlotCol idx, uint col)
        {
            ImPlotNative.ImPlot_PushStyleColor_U32(idx, col);
        }

        /// <summary>
        ///     Pushes a plot color value onto the style stack (as a Vector4F).
        /// </summary>
        /// <param name="idx">The style color index to modify</param>
        /// <param name="col">New color value as RGBA float components</param>
        public static void PushStyleColor(ImPlotCol idx, Vector4F col)
        {
            ImPlotNative.ImPlot_PushStyleColor_Vec4(idx, col);
        }

        /// <summary>
        ///     Pushes a float-valued style variable onto the style stack.
        /// </summary>
        /// <param name="idx">The style variable index to modify</param>
        /// <param name="val">New float value for the style variable</param>
        public static void PushStyleVar(ImPlotStyleVar idx, float val)
        {
            ImPlotNative.ImPlot_PushStyleVar_Float(idx, val);
        }

        /// <summary>
        ///     Pushes an integer-valued style variable onto the style stack.
        /// </summary>
        /// <param name="idx">The style variable index to modify</param>
        /// <param name="val">New integer value for the style variable</param>
        public static void PushStyleVar(ImPlotStyleVar idx, int val)
        {
            ImPlotNative.ImPlot_PushStyleVar_Int(idx, val);
        }

        /// <summary>
        ///     Pushes a Vector2F-valued style variable onto the style stack.
        /// </summary>
        /// <param name="idx">The style variable index to modify</param>
        /// <param name="val">New Vector2F value for the style variable</param>
        public static void PushStyleVar(ImPlotStyleVar idx, Vector2F val)
        {
            ImPlotNative.ImPlot_PushStyleVar_Vec2(idx, val);
        }

        /// <summary>
        ///     Samples the active colormap at a normalized position.
        /// </summary>
        /// <param name="t">Normalized position in [0, 1] along the colormap</param>
        /// <returns>Color sampled from the colormap at position t</returns>
        public static Vector4F SampleColormap(float t)
        {
            ImPlotColormap cmap = (ImPlotColormap) (-1);
            ImPlotNative.ImPlot_SampleColormap(out Vector4F retval, t, cmap);
            return retval;
        }

        /// <summary>
        ///     Samples a specific colormap at a normalized position.
        /// </summary>
        /// <param name="t">Normalized position in [0, 1] along the colormap</param>
        /// <param name="cmap">The colormap to sample</param>
        /// <returns>Color sampled from the specified colormap at position t</returns>
        public static Vector4F SampleColormap(float t, ImPlotColormap cmap)
        {
            ImPlotNative.ImPlot_SampleColormap(out Vector4F retval, t, cmap);
            return retval;
        }

        /// <summary>
        ///     Sets the active X and Y axes for subsequent plot operations.
        /// </summary>
        /// <param name="xAxis">The X axis to activate</param>
        /// <param name="yAxis">The Y axis to activate</param>
        public static void SetAxes(ImAxis xAxis, ImAxis yAxis)
        {
            ImPlotNative.ImPlot_SetAxes(xAxis, yAxis);
        }

        /// <summary>
        ///     Sets the active axis for subsequent plot operations.
        /// </summary>
        /// <param name="axis">The axis to activate</param>
        public static void SetAxis(ImAxis axis)
        {
            ImPlotNative.ImPlot_SetAxis(axis);
        }

        /// <summary>
        ///     Sets the current ImPlot context for multi-context scenarios.
        /// </summary>
        /// <param name="ctx">Pointer to the ImPlot context</param>
        public static void SetCurrentContext(IntPtr ctx)
        {
            ImPlotNative.ImPlot_SetCurrentContext(ctx);
        }

        /// <summary>
        ///     Associates an ImGui context with the current ImPlot context.
        /// </summary>
        /// <param name="ctx">Pointer to the ImGui context</param>
        public static void SetImGuiContext(IntPtr ctx)
        {
            ImPlotNative.ImPlot_SetImGuiContext(ctx);
        }

        /// <summary>
        ///     Sets the next plot's X and Y axis limits (applied once by default).
        /// </summary>
        /// <param name="xMin">Minimum value for the X axis</param>
        /// <param name="xMax">Maximum value for the X axis</param>
        /// <param name="yMin">Minimum value for the Y axis</param>
        /// <param name="yMax">Maximum value for the Y axis</param>
        public static void SetNextAxesLimits(double xMin, double xMax, double yMin, double yMax)
        {
            ImPlotCond cond = ImPlotCond.Once;
            ImPlotNative.ImPlot_SetNextAxesLimits(xMin, xMax, yMin, yMax, cond);
        }

        /// <summary>
        ///     Sets the next plot's X and Y axis limits with a specified condition.
        /// </summary>
        /// <param name="xMin">Minimum value for the X axis</param>
        /// <param name="xMax">Maximum value for the X axis</param>
        /// <param name="yMin">Minimum value for the Y axis</param>
        /// <param name="yMax">Maximum value for the Y axis</param>
        /// <param name="cond">Condition under which the limits are applied</param>
        public static void SetNextAxesLimits(double xMin, double xMax, double yMin, double yMax, ImPlotCond cond)
        {
            ImPlotNative.ImPlot_SetNextAxesLimits(xMin, xMax, yMin, yMax, cond);
        }

        /// <summary>
        ///     Automatically fits the next plot's axes to the visible data range.
        /// </summary>
        public static void SetNextAxesToFit()
        {
            ImPlotNative.ImPlot_SetNextAxesToFit();
        }

        /// <summary>
        ///     Sets the next plot's axis limits (applied once by default).
        /// </summary>
        /// <param name="axis">The axis to constrain</param>
        /// <param name="vMin">Minimum value for the axis</param>
        /// <param name="vMax">Maximum value for the axis</param>
        public static void SetNextAxisLimits(ImAxis axis, double vMin, double vMax)
        {
            ImPlotCond cond = ImPlotCond.Once;
            ImPlotNative.ImPlot_SetNextAxisLimits(axis, vMin, vMax, cond);
        }

        /// <summary>
        ///     Sets the next plot's axis limits with a specified condition.
        /// </summary>
        /// <param name="axis">The axis to constrain</param>
        /// <param name="vMin">Minimum value for the axis</param>
        /// <param name="vMax">Maximum value for the axis</param>
        /// <param name="cond">Condition under which the limits are applied</param>
        public static void SetNextAxisLimits(ImAxis axis, double vMin, double vMax, ImPlotCond cond)
        {
            ImPlotNative.ImPlot_SetNextAxisLimits(axis, vMin, vMax, cond);
        }

        /// <summary>
        ///     Links the next plot's axis range to external variables.
        /// </summary>
        /// <param name="axis">The axis to link</param>
        /// <param name="linkMin">Reference to the external minimum value</param>
        /// <param name="linkMax">Reference to the external maximum value</param>
        public static void SetNextAxisLinks(ImAxis axis, ref double linkMin, ref double linkMax)
        {
            ImPlotNative.ImPlot_SetNextAxisLinks(axis, linkMin, linkMax);
        }

        /// <summary>
        ///     Automatically fits the specified axis to the visible data range.
        /// </summary>
        /// <param name="axis">The axis to fit</param>
        public static void SetNextAxisToFit(ImAxis axis)
        {
            ImPlotNative.ImPlot_SetNextAxisToFit(axis);
        }

        /// <summary>
        ///     Resets the error bar style to defaults for the next plot item.
        /// </summary>
        public static void SetNextErrorBarStyle()
        {
            Vector4F col = new Vector4F(0, 0, 0, -1);
            float size = -1;
            float weight = -1;
            ImPlotNative.ImPlot_SetNextErrorBarStyle(col, size, weight);
        }

        /// <summary>
        ///     Sets the error bar color for the next plot item.
        /// </summary>
        /// <param name="col">Color for the error bars</param>
        public static void SetNextErrorBarStyle(Vector4F col)
        {
            float size = -1;
            float weight = -1;
            ImPlotNative.ImPlot_SetNextErrorBarStyle(col, size, weight);
        }

        /// <summary>
        ///     Sets the error bar color and cap size for the next plot item.
        /// </summary>
        /// <param name="col">Color for the error bars</param>
        /// <param name="size">Width of the error bar cap lines in pixels</param>
        public static void SetNextErrorBarStyle(Vector4F col, float size)
        {
            float weight = -1;
            ImPlotNative.ImPlot_SetNextErrorBarStyle(col, size, weight);
        }

        /// <summary>
        ///     Sets the error bar color, cap size, and line weight for the next plot item.
        /// </summary>
        /// <param name="col">Color for the error bars</param>
        /// <param name="size">Width of the error bar cap lines in pixels</param>
        /// <param name="weight">Thickness of the error bar lines in pixels</param>
        public static void SetNextErrorBarStyle(Vector4F col, float size, float weight)
        {
            ImPlotNative.ImPlot_SetNextErrorBarStyle(col, size, weight);
        }

        /// <summary>
        ///     Resets the fill style to defaults for the next plot item.
        /// </summary>
        public static void SetNextFillStyle()
        {
            Vector4F col = new Vector4F(0, 0, 0, -1);
            float alphaMod = -1;
            ImPlotNative.ImPlot_SetNextFillStyle(col, alphaMod);
        }

        /// <summary>
        ///     Sets the fill color for the next plot item.
        /// </summary>
        /// <param name="col">Fill color for the next item</param>
        public static void SetNextFillStyle(Vector4F col)
        {
            float alphaMod = -1;
            ImPlotNative.ImPlot_SetNextFillStyle(col, alphaMod);
        }

        /// <summary>
        ///     Sets the fill color and alpha modifier for the next plot item.
        /// </summary>
        /// <param name="col">Fill color for the next item</param>
        /// <param name="alphaMod">Alpha multiplier applied to the fill color</param>
        public static void SetNextFillStyle(Vector4F col, float alphaMod)
        {
            ImPlotNative.ImPlot_SetNextFillStyle(col, alphaMod);
        }

        /// <summary>
        ///     Resets the line style to defaults for the next plot item.
        /// </summary>
        public static void SetNextLineStyle()
        {
            Vector4F col = new Vector4F(0, 0, 0, -1);
            float weight = -1;
            ImPlotNative.ImPlot_SetNextLineStyle(col, weight);
        }

        /// <summary>
        ///     Sets the line color for the next plot item.
        /// </summary>
        /// <param name="col">Line color for the next item</param>
        public static void SetNextLineStyle(Vector4F col)
        {
            float weight = -1;
            ImPlotNative.ImPlot_SetNextLineStyle(col, weight);
        }

        /// <summary>
        ///     Sets the line color and weight for the next plot item.
        /// </summary>
        /// <param name="col">Line color for the next item</param>
        /// <param name="weight">Thickness of the line in pixels</param>
        public static void SetNextLineStyle(Vector4F col, float weight)
        {
            ImPlotNative.ImPlot_SetNextLineStyle(col, weight);
        }

        /// <summary>
        ///     Resets the marker style to defaults for the next plot item.
        /// </summary>
        public static void SetNextMarkerStyle()
        {
            ImPlotMarker marker = (ImPlotMarker) (-1);
            float size = -1;
            Vector4F fill = new Vector4F(0, 0, 0, -1);
            float weight = -1;
            Vector4F outline = new Vector4F(0, 0, 0, -1);
            ImPlotNative.ImPlot_SetNextMarkerStyle(marker, size, fill, weight, outline);
        }

        /// <summary>
        ///     Sets the marker shape for the next plot item.
        /// </summary>
        /// <param name="marker">The marker shape to use</param>
        public static void SetNextMarkerStyle(ImPlotMarker marker)
        {
            float size = -1;
            Vector4F fill = new Vector4F(0, 0, 0, -1);
            float weight = -1;
            Vector4F outline = new Vector4F(0, 0, 0, -1);
            ImPlotNative.ImPlot_SetNextMarkerStyle(marker, size, fill, weight, outline);
        }

        /// <summary>
        ///     Sets the marker shape and size for the next plot item.
        /// </summary>
        /// <param name="marker">The marker shape to use</param>
        /// <param name="size">Size of the marker in pixels</param>
        public static void SetNextMarkerStyle(ImPlotMarker marker, float size)
        {
            Vector4F fill = new Vector4F(0, 0, 0, -1);
            float weight = -1;
            Vector4F outline = new Vector4F(0, 0, 0, -1);
            ImPlotNative.ImPlot_SetNextMarkerStyle(marker, size, fill, weight, outline);
        }

        /// <summary>
        ///     Sets the marker shape, size, and fill color for the next plot item.
        /// </summary>
        /// <param name="marker">The marker shape to use</param>
        /// <param name="size">Size of the marker in pixels</param>
        /// <param name="fill">Fill color for the marker interior</param>
        public static void SetNextMarkerStyle(ImPlotMarker marker, float size, Vector4F fill)
        {
            float weight = -1;
            Vector4F outline = new Vector4F(0, 0, 0, -1);
            ImPlotNative.ImPlot_SetNextMarkerStyle(marker, size, fill, weight, outline);
        }

        /// <summary>
        ///     Sets the marker shape, size, fill, and outline weight for the next plot item.
        /// </summary>
        /// <param name="marker">The marker shape to use</param>
        /// <param name="size">Size of the marker in pixels</param>
        /// <param name="fill">Fill color for the marker interior</param>
        /// <param name="weight">Thickness of the marker outline in pixels</param>
        public static void SetNextMarkerStyle(ImPlotMarker marker, float size, Vector4F fill, float weight)
        {
            Vector4F outline = new Vector4F(0, 0, 0, -1);
            ImPlotNative.ImPlot_SetNextMarkerStyle(marker, size, fill, weight, outline);
        }

        /// <summary>
        ///     Sets the full marker style for the next plot item.
        /// </summary>
        /// <param name="marker">The marker shape to use</param>
        /// <param name="size">Size of the marker in pixels</param>
        /// <param name="fill">Fill color for the marker interior</param>
        /// <param name="weight">Thickness of the marker outline in pixels</param>
        /// <param name="outline">Color for the marker outline</param>
        public static void SetNextMarkerStyle(ImPlotMarker marker, float size, Vector4F fill, float weight, Vector4F outline)
        {
            ImPlotNative.ImPlot_SetNextMarkerStyle(marker, size, fill, weight, outline);
        }

        /// <summary>
        ///     Configures the X and Y axis labels for the next plot.
        /// </summary>
        /// <param name="xLabel">Label for the X axis</param>
        /// <param name="yLabel">Label for the Y axis</param>
        public static void SetupAxes(string xLabel, string yLabel)
        {
            ImPlotNative.ImPlot_SetupAxes(Encoding.UTF8.GetBytes(xLabel), Encoding.UTF8.GetBytes(yLabel), 0, 0);
        }

        /// <summary>
        ///     Configures the X and Y axis labels with X axis flags.
        /// </summary>
        /// <param name="xLabel">Label for the X axis</param>
        /// <param name="yLabel">Label for the Y axis</param>
        /// <param name="xFlags">Flags controlling the X axis appearance</param>
        public static void SetupAxes(string xLabel, string yLabel, ImPlotAxisFlags xFlags)
        {
            ImPlotNative.ImPlot_SetupAxes(Encoding.UTF8.GetBytes(xLabel), Encoding.UTF8.GetBytes(yLabel), xFlags, 0);
        }

        /// <summary>
        ///     Configures both X and Y axis labels and flags for the next plot.
        /// </summary>
        /// <param name="xLabel">Label for the X axis</param>
        /// <param name="yLabel">Label for the Y axis</param>
        /// <param name="xFlags">Flags controlling the X axis appearance</param>
        /// <param name="yFlags">Flags controlling the Y axis appearance</param>
        public static void SetupAxes(string xLabel, string yLabel, ImPlotAxisFlags xFlags, ImPlotAxisFlags yFlags)
        {
            ImPlotNative.ImPlot_SetupAxes(Encoding.UTF8.GetBytes(xLabel), Encoding.UTF8.GetBytes(yLabel), xFlags, yFlags);
        }

        /// <summary>
        ///     Configures both X and Y axis limits for the next plot (applied once by default).
        /// </summary>
        /// <param name="xMin">Minimum value for the X axis</param>
        /// <param name="xMax">Maximum value for the X axis</param>
        /// <param name="yMin">Minimum value for the Y axis</param>
        /// <param name="yMax">Maximum value for the Y axis</param>
        public static void SetupAxesLimits(double xMin, double xMax, double yMin, double yMax)
        {
            ImPlotCond cond = ImPlotCond.Once;
            ImPlotNative.ImPlot_SetupAxesLimits(xMin, xMax, yMin, yMax, cond);
        }

        /// <summary>
        ///     Configures both X and Y axis limits with a specified condition.
        /// </summary>
        /// <param name="xMin">Minimum value for the X axis</param>
        /// <param name="xMax">Maximum value for the X axis</param>
        /// <param name="yMin">Minimum value for the Y axis</param>
        /// <param name="yMax">Maximum value for the Y axis</param>
        /// <param name="cond">Condition under which the limits are applied</param>
        public static void SetupAxesLimits(double xMin, double xMax, double yMin, double yMax, ImPlotCond cond)
        {
            ImPlotNative.ImPlot_SetupAxesLimits(xMin, xMax, yMin, yMax, cond);
        }

        /// <summary>
        ///     Configures an axis with default settings and no label.
        /// </summary>
        /// <param name="axis">The axis to configure</param>
        public static void SetupAxis(ImAxis axis)
        {
            ImPlotAxisFlags flags = 0;
            ImPlotNative.ImPlot_SetupAxis(axis, Array.Empty<byte>(), flags);
        }

        /// <summary>
        ///     Configures an axis with a label.
        /// </summary>
        /// <param name="axis">The axis to configure</param>
        /// <param name="label">Label text for the axis</param>
        public static void SetupAxis(ImAxis axis, string label)
        {
            ImPlotNative.ImPlot_SetupAxis(axis, Encoding.UTF8.GetBytes(label), 0);
        }

        /// <summary>
        ///     Configures an axis with a label and appearance flags.
        /// </summary>
        /// <param name="axis">The axis to configure</param>
        /// <param name="label">Label text for the axis</param>
        /// <param name="flags">Flags controlling the axis appearance and behaviour</param>
        public static void SetupAxis(ImAxis axis, string label, ImPlotAxisFlags flags)
        {
            ImPlotNative.ImPlot_SetupAxis(axis, Encoding.UTF8.GetBytes(label), flags);
        }

        /// <summary>
        ///     Sets the axis tick label format using a printf-style format string.
        /// </summary>
        /// <param name="axis">The axis to format</param>
        /// <param name="fmt">Printf-style format string for tick labels</param>
        public static void SetupAxisFormat(ImAxis axis, string fmt)
        {
            ImPlotNative.ImPlot_SetupAxisFormat_Str(axis, Encoding.UTF8.GetBytes(fmt));
        }

        /// <summary>
        ///     Sets the axis tick label format using a custom formatter callback.
        /// </summary>
        /// <param name="axis">The axis to format</param>
        /// <param name="formatter">Pointer to a custom formatter function</param>
        public static void SetupAxisFormat(ImAxis axis, IntPtr formatter)
        {
            ImPlotNative.ImPlot_SetupAxisFormat_PlotFormatter(axis, formatter, IntPtr.Zero);
        }

        /// <summary>
        ///     Sets the axis tick label format using a custom formatter callback with user data.
        /// </summary>
        /// <param name="axis">The axis to format</param>
        /// <param name="formatter">Pointer to a custom formatter function</param>
        /// <param name="data">User data pointer passed to the formatter callback</param>
        public static void SetupAxisFormat(ImAxis axis, IntPtr formatter, IntPtr data)
        {
            ImPlotNative.ImPlot_SetupAxisFormat_PlotFormatter(axis, formatter, data);
        }

        /// <summary>
        ///     Configures a single axis range (applied once by default).
        /// </summary>
        /// <param name="axis">The axis to constrain</param>
        /// <param name="vMin">Minimum value for the axis</param>
        /// <param name="vMax">Maximum value for the axis</param>
        public static void SetupAxisLimits(ImAxis axis, double vMin, double vMax)
        {
            ImPlotCond cond = ImPlotCond.Once;
            ImPlotNative.ImPlot_SetupAxisLimits(axis, vMin, vMax, cond);
        }

        /// <summary>
        ///     Configures a single axis range with a specified condition.
        /// </summary>
        /// <param name="axis">The axis to constrain</param>
        /// <param name="vMin">Minimum value for the axis</param>
        /// <param name="vMax">Maximum value for the axis</param>
        /// <param name="cond">Condition under which the limits are applied</param>
        public static void SetupAxisLimits(ImAxis axis, double vMin, double vMax, ImPlotCond cond)
        {
            ImPlotNative.ImPlot_SetupAxisLimits(axis, vMin, vMax, cond);
        }

        /// <summary>
        ///     Sets hard limits on the range of an axis that the user cannot zoom beyond.
        /// </summary>
        /// <param name="axis">The axis to constrain</param>
        /// <param name="vMin">Minimum allowed value</param>
        /// <param name="vMax">Maximum allowed value</param>
        public static void SetupAxisLimitsConstraints(ImAxis axis, double vMin, double vMax)
        {
            ImPlotNative.ImPlot_SetupAxisLimitsConstraints(axis, vMin, vMax);
        }

        /// <summary>
        ///     Links an axis range to external variables for two-way synchronization.
        /// </summary>
        /// <param name="axis">The axis to link</param>
        /// <param name="linkMin">Reference to the external minimum value</param>
        /// <param name="linkMax">Reference to the external maximum value</param>
        public static void SetupAxisLinks(ImAxis axis, ref double linkMin, ref double linkMax)
        {
            ImPlotNative.ImPlot_SetupAxisLinks(axis, linkMin, linkMax);
        }

        /// <summary>
        ///     Sets the scaling type for an axis (linear, log, time, etc.).
        /// </summary>
        /// <param name="axis">The axis to configure</param>
        /// <param name="scale">The scaling mode to apply</param>
        public static void SetupAxisScale(ImAxis axis, ImPlotScale scale)
        {
            ImPlotNative.ImPlot_SetupAxisScale_PlotScale(axis, scale);
        }

        /// <summary>
        ///     Sets a custom transform for an axis via forward/inverse callbacks.
        /// </summary>
        /// <param name="axis">The axis to configure</param>
        /// <param name="forward">Pointer to the forward transform function</param>
        /// <param name="inverse">Pointer to the inverse transform function</param>
        public static void SetupAxisScale(ImAxis axis, IntPtr forward, IntPtr inverse)
        {
            ImPlotNative.ImPlot_SetupAxisScale_PlotTransform(axis, forward, inverse, IntPtr.Zero);
        }

        /// <summary>
        ///     Sets a custom transform for an axis with user data.
        /// </summary>
        /// <param name="axis">The axis to configure</param>
        /// <param name="forward">Pointer to the forward transform function</param>
        /// <param name="inverse">Pointer to the inverse transform function</param>
        /// <param name="data">User data pointer passed to the transform functions</param>
        public static void SetupAxisScale(ImAxis axis, IntPtr forward, IntPtr inverse, IntPtr data)
        {
            ImPlotNative.ImPlot_SetupAxisScale_PlotTransform(axis, forward, inverse, data);
        }

        /// <summary>
        ///     Sets custom tick positions for an axis using an array of values.
        /// </summary>
        /// <param name="axis">The axis to configure</param>
        /// <param name="values">Array of tick position values</param>
        /// <param name="nTicks">Number of ticks to set</param>
        public static void SetupAxisTicks(ImAxis axis, double[] values, int nTicks)
        {
            ImPlotNative.ImPlot_SetupAxisTicks_doublePtr(axis, values, nTicks, null, 0);
        }

        /// <summary>
        ///     Sets custom tick positions and labels for an axis.
        /// </summary>
        /// <param name="axis">The axis to configure</param>
        /// <param name="values">Array of tick position values</param>
        /// <param name="nTicks">Number of ticks to set</param>
        /// <param name="labels">Array of label strings for each tick</param>
        public static void SetupAxisTicks(ImAxis axis, double[] values, int nTicks, string[] labels)
        {
            ImPlotNative.ImPlot_SetupAxisTicks_doublePtr(axis, values, nTicks, null, 0);
        }

        /// <summary>
        ///     Sets custom tick positions and labels with an option to keep default ticks.
        /// </summary>
        /// <param name="axis">The axis to configure</param>
        /// <param name="values">Array of tick position values</param>
        /// <param name="nTicks">Number of ticks to set</param>
        /// <param name="labels">Array of label strings for each tick</param>
        /// <param name="keepDefault">Whether to keep the default ticks as well</param>
        public static void SetupAxisTicks(ImAxis axis, double[] values, int nTicks, string[] labels, bool keepDefault)
        {
            ImPlotNative.ImPlot_SetupAxisTicks_doublePtr(axis, values, nTicks, null, 0);
        }

        /// <summary>
        ///     Sets evenly-spaced ticks between a min and max value.
        /// </summary>
        /// <param name="axis">The axis to configure</param>
        /// <param name="vMin">Start value for the tick range</param>
        /// <param name="vMax">End value for the tick range</param>
        /// <param name="nTicks">Number of evenly-spaced ticks to create</param>
        public static void SetupAxisTicks(ImAxis axis, double vMin, double vMax, int nTicks)
        {
            ImPlotNative.ImPlot_SetupAxisTicks_double(axis, vMin, vMax, nTicks, Array.Empty<byte[]>(), 0);
        }

        /// <summary>
        ///     Sets evenly-spaced ticks with custom labels.
        /// </summary>
        /// <param name="axis">The axis to configure</param>
        /// <param name="vMin">Start value for the tick range</param>
        /// <param name="vMax">End value for the tick range</param>
        /// <param name="nTicks">Number of evenly-spaced ticks to create</param>
        /// <param name="labels">Array of label strings for each tick</param>
        public static void SetupAxisTicks(ImAxis axis, double vMin, double vMax, int nTicks, string[] labels)
        {
            ImPlotNative.ImPlot_SetupAxisTicks_double(axis, vMin, vMax, nTicks, Array.Empty<byte[]>(), 0);
        }

        /// <summary>
        ///     Sets evenly-spaced ticks with custom labels and a keep-default option.
        /// </summary>
        /// <param name="axis">The axis to configure</param>
        /// <param name="vMin">Start value for the tick range</param>
        /// <param name="vMax">End value for the tick range</param>
        /// <param name="nTicks">Number of evenly-spaced ticks to create</param>
        /// <param name="labels">Array of label strings for each tick</param>
        /// <param name="keepDefault">Whether to keep the default ticks as well</param>
        public static void SetupAxisTicks(ImAxis axis, double vMin, double vMax, int nTicks, string[] labels, bool keepDefault)
        {
            ImPlotNative.ImPlot_SetupAxisTicks_double(axis, vMin, vMax, nTicks, Array.Empty<byte[]>(), 0);
        }

        /// <summary>
        ///     Constrains the zoom range for an axis.
        /// </summary>
        /// <param name="axis">The axis to constrain</param>
        /// <param name="zMin">Minimum allowed zoom level (axis span)</param>
        /// <param name="zMax">Maximum allowed zoom level (axis span)</param>
        public static void SetupAxisZoomConstraints(ImAxis axis, double zMin, double zMax)
        {
            ImPlotNative.ImPlot_SetupAxisZoomConstraints(axis, zMin, zMax);
        }

        /// <summary>
        ///     Finalises the plot configuration after all Setup* calls.
        /// </summary>
        public static void SetupFinish()
        {
            ImPlotNative.ImPlot_SetupFinish();
        }

        /// <summary>
        ///     Configures the legend location with default flags.
        /// </summary>
        /// <param name="location">Anchor location for the legend within the plot</param>
        public static void SetupLegend(ImPlotLocation location)
        {
            ImPlotLegendFlags flags = 0;
            ImPlotNative.ImPlot_SetupLegend(location, flags);
        }

        /// <summary>
        ///     Configures the legend location and appearance flags.
        /// </summary>
        /// <param name="location">Anchor location for the legend within the plot</param>
        /// <param name="flags">Combination of ImPlotLegendFlags controlling legend appearance</param>
        public static void SetupLegend(ImPlotLocation location, ImPlotLegendFlags flags)
        {
            ImPlotNative.ImPlot_SetupLegend(location, flags);
        }

        /// <summary>
        ///     Configures the mouse position tooltip location.
        /// </summary>
        /// <param name="location">Anchor location for the mouse tooltip</param>
        public static void SetupMouseText(ImPlotLocation location)
        {
            ImPlotMouseTextFlags flags = 0;
            ImPlotNative.ImPlot_SetupMouseText(location, flags);
        }

        /// <summary>
        ///     Configures the mouse position tooltip location and flags.
        /// </summary>
        /// <param name="location">Anchor location for the mouse tooltip</param>
        /// <param name="flags">Combination of ImPlotMouseTextFlags controlling tooltip behaviour</param>
        public static void SetupMouseText(ImPlotLocation location, ImPlotMouseTextFlags flags)
        {
            ImPlotNative.ImPlot_SetupMouseText(location, flags);
        }

        /// <summary>
        ///     Shows an interactive colormap selector widget.
        /// </summary>
        /// <param name="label">Label for the colormap selector</param>
        /// <returns>true if the colormap was changed</returns>
        public static bool ShowColormapSelector(string label)
        {
            byte ret = ImPlotNative.ImPlot_ShowColormapSelector(Encoding.UTF8.GetBytes(label));
            return ret != 0;
        }

        /// <summary>
        ///     Opens the ImPlot demo window.
        /// </summary>
        public static void ShowDemoWindow()
        {
            ImPlotNative.ImPlot_ShowDemoWindow(0);
        }

        /// <summary>
        ///     Opens the ImPlot demo window with an open/close state.
        /// </summary>
        /// <param name="pOpen">Reference to a bool tracking whether the demo window is open</param>
        public static void ShowDemoWindow(ref bool pOpen)
        {
            byte nativePOpenVal = pOpen ? (byte) 1 : (byte) 0;
            ImPlotNative.ImPlot_ShowDemoWindow(nativePOpenVal);
            pOpen = nativePOpenVal != 0;
        }

        /// <summary>
        ///     Shows an interactive input map selector widget.
        /// </summary>
        /// <param name="label">Label for the input map selector</param>
        /// <returns>true if the input map was changed</returns>
        public static bool ShowInputMapSelector(string label)
        {
            byte ret = ImPlotNative.ImPlot_ShowInputMapSelector(Encoding.UTF8.GetBytes(label));
            return ret != 0;
        }

        /// <summary>
        ///     Opens the ImPlot metrics (profiling) window.
        /// </summary>
        public static void ShowMetricsWindow()
        {
            ImPlotNative.ImPlot_ShowMetricsWindow(0);
        }

        /// <summary>
        ///     Opens the ImPlot metrics window with an open/close state.
        /// </summary>
        /// <param name="pPopen">Reference to a bool tracking whether the metrics window is open</param>
        public static void ShowMetricsWindow(ref bool pPopen)
        {
            byte nativePPopenVal = pPopen ? (byte) 1 : (byte) 0;
            ImPlotNative.ImPlot_ShowMetricsWindow(nativePPopenVal);
            pPopen = nativePPopenVal != 0;
        }

        /// <summary>
        ///     Opens the ImPlot style editor widget with default style values.
        /// </summary>
        public static void ShowStyleEditor()
        {
            ImPlotNative.ImPlot_ShowStyleEditor(new ImPlotStyle());
        }

        /// <summary>
        ///     Opens the ImPlot style editor widget.
        /// </summary>
        public static void ShowStyleEditor(ImPlotStyle imPlotStyle)
        {
            ImPlotNative.ImPlot_ShowStyleEditor(imPlotStyle);
        }

        /// <summary>
        ///     Shows an interactive style preset selector widget.
        /// </summary>
        /// <param name="label">Label for the style selector</param>
        /// <returns>true if the style was changed</returns>
        public static bool ShowStyleSelector(string label)
        {
            byte ret = ImPlotNative.ImPlot_ShowStyleSelector(Encoding.UTF8.GetBytes(label));
            return ret != 0;
        }

        /// <summary>
        ///     Opens the ImPlot user guide.
        /// </summary>
        public static void ShowUserGuide()
        {
            ImPlotNative.ImPlot_ShowUserGuide();
        }

        /// <summary>
        ///     Applies the default ImPlot color theme (auto).
        /// </summary>
        public static void StyleColorsAuto()
        {
            ImPlotNative.ImPlot_StyleColorsAuto(new ImPlotStyle());
        }

        /// <summary>
        ///     Applies the default ImPlot color theme to the specified style.
        /// </summary>
        /// <param name="dst">Style struct to populate with auto theme colors</param>
        public static void StyleColorsAuto(ImPlotStyle dst)
        {
            ImPlotNative.ImPlot_StyleColorsAuto(dst);
        }

        /// <summary>
        ///     Applies the classic ImPlot color theme.
        /// </summary>
        public static void StyleColorsClassic()
        {
            ImPlotNative.ImPlot_StyleColorsClassic(new ImPlotStyle());
        }

        /// <summary>
        ///     Applies the classic ImPlot color theme to the specified style.
        /// </summary>
        /// <param name="dst">Style struct to populate with classic theme colors</param>
        public static void StyleColorsClassic(ImPlotStyle dst)
        {
            ImPlotNative.ImPlot_StyleColorsClassic(dst);
        }

        /// <summary>
        ///     Applies the dark ImPlot color theme.
        /// </summary>
        public static void StyleColorsDark()
        {
            ImPlotNative.ImPlot_StyleColorsDark(new ImPlotStyle());
        }

        /// <summary>
        ///     Applies the dark ImPlot color theme to the specified style.
        /// </summary>
        /// <param name="dst">Style struct to populate with dark theme colors</param>
        public static void StyleColorsDark(ImPlotStyle dst)
        {
            ImPlotNative.ImPlot_StyleColorsDark(dst);
        }

        /// <summary>
        ///     Applies the light ImPlot color theme.
        /// </summary>
        public static void StyleColorsLight()
        {
            ImPlotNative.ImPlot_StyleColorsLight(new ImPlotStyle());
        }

        /// <summary>
        ///     Applies the light ImPlot color theme to the specified style.
        /// </summary>
        /// <param name="dst">Style struct to populate with light theme colors</param>
        public static void StyleColorsLight(ImPlotStyle dst)
        {
            ImPlotNative.ImPlot_StyleColorsLight(dst);
        }

        /// <summary>
        ///     Draws a vertical tag (annotation line) at the specified X position.
        /// </summary>
        /// <param name="x">X-coordinate in plot space for the tag</param>
        /// <param name="col">Color of the tag</param>
        public static void TagX(double x, Vector4F col)
        {
            byte round = 0;
            ImPlotNative.ImPlot_TagX_Bool(x, col, round);
        }

        /// <summary>
        ///     Draws a vertical tag with rounded endpoints.
        /// </summary>
        /// <param name="x">X-coordinate in plot space for the tag</param>
        /// <param name="col">Color of the tag</param>
        /// <param name="round">Whether to draw rounded endpoints on the tag</param>
        public static void TagX(double x, Vector4F col, bool round)
        {
            byte nativeRound = round ? (byte) 1 : (byte) 0;
            ImPlotNative.ImPlot_TagX_Bool(x, col, nativeRound);
        }

        /// <summary>
        ///     Draws a vertical tag with custom label text.
        /// </summary>
        /// <param name="x">X-coordinate in plot space for the tag</param>
        /// <param name="col">Color of the tag</param>
        /// <param name="fmt">Format string for the tag label</param>
        public static void TagX(double x, Vector4F col, string fmt)
        {
            ImPlotNative.ImPlot_TagX_Str(x, col, Encoding.UTF8.GetBytes(fmt));
        }

        /// <summary>
        ///     Draws a horizontal tag (annotation line) at the specified Y position.
        /// </summary>
        /// <param name="y">Y-coordinate in plot space for the tag</param>
        /// <param name="col">Color of the tag</param>
        public static void TagY(double y, Vector4F col)
        {
            byte round = 0;
            ImPlotNative.ImPlot_TagY_Bool(y, col, round);
        }

        /// <summary>
        ///     Draws a horizontal tag with rounded endpoints.
        /// </summary>
        /// <param name="y">Y-coordinate in plot space for the tag</param>
        /// <param name="col">Color of the tag</param>
        /// <param name="round">Whether to draw rounded endpoints on the tag</param>
        public static void TagY(double y, Vector4F col, bool round)
        {
            byte nativeRound = round ? (byte) 1 : (byte) 0;
            ImPlotNative.ImPlot_TagY_Bool(y, col, nativeRound);
        }

        /// <summary>
        ///     Draws a horizontal tag with custom label text.
        /// </summary>
        /// <param name="y">Y-coordinate in plot space for the tag</param>
        /// <param name="col">Color of the tag</param>
        /// <param name="fmt">Format string for the tag label</param>
        public static void TagY(double y, Vector4F col, string fmt)
        {
            ImPlotNative.ImPlot_TagY_Str(y, col, Encoding.UTF8.GetBytes(fmt));
        }
    }
}