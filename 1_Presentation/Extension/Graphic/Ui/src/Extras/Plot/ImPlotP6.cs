// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImPlotP6.cs
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

using System.Text;

namespace Alis.Extension.Graphic.Ui.Extras.Plot
{
    /// <summary>
    ///     Provides managed wrappers over the CImPlot native library for creating and interacting with ImPlot plots.
    /// </summary>
    public static partial class ImPlot
    {
        /// <summary>
        ///     Plots the inf lines using the specified label id
        /// </summary>
        /// <param name="labelId">The label identifier for the plot item</param>
        /// <param name="values">The array of data values to plot</param>
        /// <param name="count">The number of elements</param>
        /// <param name="flags">The ImGui behavior flags</param>
        /// <param name="offset">The offset from the origin</param>
        /// <param name="stride">The byte stride between elements</param>
        public static void PlotInfLines(string labelId, byte[] values, int count, ImPlotInfLinesFlags flags, int offset, int stride)
        {
            ImPlotNative.ImPlot_PlotInfLines_U8Ptr(Encoding.UTF8.GetBytes(labelId), values, count, flags, offset, stride);
        }

        /// <summary>
        ///     Plots the inf lines using the specified label id
        /// </summary>
        /// <param name="labelId">The label identifier for the plot item</param>
        /// <param name="values">The array of data values to plot</param>
        /// <param name="count">The number of elements</param>
        public static void PlotInfLines(string labelId, short[] values, int count)
        {
            ImPlotNative.ImPlot_PlotInfLines_S16Ptr(Encoding.UTF8.GetBytes(labelId), values, count, ImPlotInfLinesFlags.None, 0, sizeof(short));
        }

        /// <summary>
        ///     Plots the inf lines using the specified label id
        /// </summary>
        /// <param name="labelId">The label identifier for the plot item</param>
        /// <param name="values">The array of data values to plot</param>
        /// <param name="count">The number of elements</param>
        /// <param name="flags">The ImGui behavior flags</param>
        public static void PlotInfLines(string labelId, short[] values, int count, ImPlotInfLinesFlags flags)
        {
            ImPlotNative.ImPlot_PlotInfLines_S16Ptr(Encoding.UTF8.GetBytes(labelId), values, count, flags, 0, sizeof(short));
        }

        /// <summary>
        ///     Plots the inf lines using the specified label id
        /// </summary>
        /// <param name="labelId">The label identifier for the plot item</param>
        /// <param name="values">The array of data values to plot</param>
        /// <param name="count">The number of elements</param>
        /// <param name="flags">The ImGui behavior flags</param>
        /// <param name="offset">The offset from the origin</param>
        public static void PlotInfLines(string labelId, short[] values, int count, ImPlotInfLinesFlags flags, int offset)
        {
            ImPlotNative.ImPlot_PlotInfLines_S16Ptr(Encoding.UTF8.GetBytes(labelId), values, count, flags, offset, sizeof(short));
        }

        /// <summary>
        ///     Plots the inf lines using the specified label id
        /// </summary>
        /// <param name="labelId">The label identifier for the plot item</param>
        /// <param name="values">The array of data values to plot</param>
        /// <param name="count">The number of elements</param>
        /// <param name="flags">The ImGui behavior flags</param>
        /// <param name="offset">The offset from the origin</param>
        /// <param name="stride">The byte stride between elements</param>
        public static void PlotInfLines(string labelId, short[] values, int count, ImPlotInfLinesFlags flags, int offset, int stride)
        {
            ImPlotNative.ImPlot_PlotInfLines_S16Ptr(Encoding.UTF8.GetBytes(labelId), values, count, flags, offset, stride);
        }

        /// <summary>
        ///     Plots the inf lines using the specified label id
        /// </summary>
        /// <param name="labelId">The label identifier for the plot item</param>
        /// <param name="values">The array of data values to plot</param>
        /// <param name="count">The number of elements</param>
        public static void PlotInfLines(string labelId, ushort[] values, int count)
        {
            ImPlotNative.ImPlot_PlotInfLines_U16Ptr(Encoding.UTF8.GetBytes(labelId), values, count, ImPlotInfLinesFlags.None, 0, sizeof(ushort));
        }

        /// <summary>
        ///     Plots the inf lines using the specified label id
        /// </summary>
        /// <param name="labelId">The label identifier for the plot item</param>
        /// <param name="values">The array of data values to plot</param>
        /// <param name="count">The number of elements</param>
        /// <param name="flags">The ImGui behavior flags</param>
        public static void PlotInfLines(string labelId, ushort[] values, int count, ImPlotInfLinesFlags flags)
        {
            ImPlotNative.ImPlot_PlotInfLines_U16Ptr(Encoding.UTF8.GetBytes(labelId), values, count, flags, 0, sizeof(ushort));
        }

        /// <summary>
        ///     Plots the inf lines using the specified label id
        /// </summary>
        /// <param name="labelId">The label identifier for the plot item</param>
        /// <param name="values">The array of data values to plot</param>
        /// <param name="count">The number of elements</param>
        /// <param name="flags">The ImGui behavior flags</param>
        /// <param name="offset">The offset from the origin</param>
        public static void PlotInfLines(string labelId, ushort[] values, int count, ImPlotInfLinesFlags flags, int offset)
        {
            ImPlotNative.ImPlot_PlotInfLines_U16Ptr(Encoding.UTF8.GetBytes(labelId), values, count, flags, offset, sizeof(ushort));
        }

        /// <summary>
        ///     Plots the inf lines using the specified label id
        /// </summary>
        /// <param name="labelId">The label identifier for the plot item</param>
        /// <param name="values">The array of data values to plot</param>
        /// <param name="count">The number of elements</param>
        /// <param name="flags">The ImGui behavior flags</param>
        /// <param name="offset">The offset from the origin</param>
        /// <param name="stride">The byte stride between elements</param>
        public static void PlotInfLines(string labelId, ushort[] values, int count, ImPlotInfLinesFlags flags, int offset, int stride)
        {
            ImPlotNative.ImPlot_PlotInfLines_U16Ptr(Encoding.UTF8.GetBytes(labelId), values, count, flags, offset, stride);
        }

        /// <summary>
        ///     Plots the inf lines using the specified label id
        /// </summary>
        /// <param name="labelId">The label identifier for the plot item</param>
        /// <param name="values">The array of data values to plot</param>
        /// <param name="count">The number of elements</param>
        public static void PlotInfLines(string labelId, int[] values, int count)
        {
            ImPlotNative.ImPlot_PlotInfLines_S32Ptr(Encoding.UTF8.GetBytes(labelId), values, count, ImPlotInfLinesFlags.None, 0, sizeof(int));
        }

        /// <summary>
        ///     Plots the inf lines using the specified label id
        /// </summary>
        /// <param name="labelId">The label identifier for the plot item</param>
        /// <param name="values">The array of data values to plot</param>
        /// <param name="count">The number of elements</param>
        /// <param name="flags">The ImGui behavior flags</param>
        public static void PlotInfLines(string labelId, int[] values, int count, ImPlotInfLinesFlags flags)
        {
            ImPlotNative.ImPlot_PlotInfLines_S32Ptr(Encoding.UTF8.GetBytes(labelId), values, count, flags, 0, sizeof(int));
        }

        /// <summary>
        ///     Plots the inf lines using the specified label id
        /// </summary>
        /// <param name="labelId">The label identifier for the plot item</param>
        /// <param name="values">The array of data values to plot</param>
        /// <param name="count">The number of elements</param>
        /// <param name="flags">The ImGui behavior flags</param>
        /// <param name="offset">The offset from the origin</param>
        public static void PlotInfLines(string labelId, int[] values, int count, ImPlotInfLinesFlags flags, int offset)
        {
            ImPlotNative.ImPlot_PlotInfLines_S32Ptr(Encoding.UTF8.GetBytes(labelId), values, count, flags, offset, sizeof(int));
        }

        /// <summary>
        ///     Plots the inf lines using the specified label id
        /// </summary>
        /// <param name="labelId">The label identifier for the plot item</param>
        /// <param name="values">The array of data values to plot</param>
        /// <param name="count">The number of elements</param>
        /// <param name="flags">The ImGui behavior flags</param>
        /// <param name="offset">The offset from the origin</param>
        /// <param name="stride">The byte stride between elements</param>
        public static void PlotInfLines(string labelId, int[] values, int count, ImPlotInfLinesFlags flags, int offset, int stride)
        {
            ImPlotNative.ImPlot_PlotInfLines_S32Ptr(Encoding.UTF8.GetBytes(labelId), values, count, flags, offset, stride);
        }

        /// <summary>
        ///     Plots the inf lines using the specified label id
        /// </summary>
        /// <param name="labelId">The label identifier for the plot item</param>
        /// <param name="values">The array of data values to plot</param>
        /// <param name="count">The number of elements</param>
        public static void PlotInfLines(string labelId, uint[] values, int count)
        {
            ImPlotNative.ImPlot_PlotInfLines_U32Ptr(Encoding.UTF8.GetBytes(labelId), values, count, ImPlotInfLinesFlags.None, 0, sizeof(uint));
        }

        /// <summary>
        ///     Plots the inf lines using the specified label id
        /// </summary>
        /// <param name="labelId">The label identifier for the plot item</param>
        /// <param name="values">The array of data values to plot</param>
        /// <param name="count">The number of elements</param>
        /// <param name="flags">The ImGui behavior flags</param>
        public static void PlotInfLines(string labelId, uint[] values, int count, ImPlotInfLinesFlags flags)
        {
            ImPlotNative.ImPlot_PlotInfLines_U32Ptr(Encoding.UTF8.GetBytes(labelId), values, count, flags, 0, sizeof(uint));
        }

        /// <summary>
        ///     Plots the inf lines using the specified label id
        /// </summary>
        /// <param name="labelId">The label identifier for the plot item</param>
        /// <param name="values">The array of data values to plot</param>
        /// <param name="count">The number of elements</param>
        /// <param name="flags">The ImGui behavior flags</param>
        /// <param name="offset">The offset from the origin</param>
        public static void PlotInfLines(string labelId, uint[] values, int count, ImPlotInfLinesFlags flags, int offset)
        {
            ImPlotNative.ImPlot_PlotInfLines_U32Ptr(Encoding.UTF8.GetBytes(labelId), values, count, flags, offset, sizeof(uint));
        }

        /// <summary>
        ///     Plots the inf lines using the specified label id
        /// </summary>
        /// <param name="labelId">The label identifier for the plot item</param>
        /// <param name="values">The array of data values to plot</param>
        /// <param name="count">The number of elements</param>
        /// <param name="flags">The ImGui behavior flags</param>
        /// <param name="offset">The offset from the origin</param>
        /// <param name="stride">The byte stride between elements</param>
        public static void PlotInfLines(string labelId, uint[] values, int count, ImPlotInfLinesFlags flags, int offset, int stride)
        {
            ImPlotNative.ImPlot_PlotInfLines_U32Ptr(Encoding.UTF8.GetBytes(labelId), values, count, flags, offset, stride);
        }

        /// <summary>
        ///     Plots the inf lines using the specified label id
        /// </summary>
        /// <param name="labelId">The label identifier for the plot item</param>
        /// <param name="values">The array of data values to plot</param>
        /// <param name="count">The number of elements</param>
        public static void PlotInfLines(string labelId, long[] values, int count)
        {
            ImPlotNative.ImPlot_PlotInfLines_S64Ptr(Encoding.UTF8.GetBytes(labelId), values, count, ImPlotInfLinesFlags.None, 0, sizeof(long));
        }

        /// <summary>
        ///     Plots the inf lines using the specified label id
        /// </summary>
        /// <param name="labelId">The label identifier for the plot item</param>
        /// <param name="values">The array of data values to plot</param>
        /// <param name="count">The number of elements</param>
        /// <param name="flags">The ImGui behavior flags</param>
        public static void PlotInfLines(string labelId, long[] values, int count, ImPlotInfLinesFlags flags)
        {
            ImPlotNative.ImPlot_PlotInfLines_S64Ptr(Encoding.UTF8.GetBytes(labelId), values, count, flags, 0, sizeof(long));
        }

        /// <summary>
        ///     Plots the inf lines using the specified label id
        /// </summary>
        /// <param name="labelId">The label identifier for the plot item</param>
        /// <param name="values">The array of data values to plot</param>
        /// <param name="count">The number of elements</param>
        /// <param name="flags">The ImGui behavior flags</param>
        /// <param name="offset">The offset from the origin</param>
        public static void PlotInfLines(string labelId, long[] values, int count, ImPlotInfLinesFlags flags, int offset)
        {
            ImPlotNative.ImPlot_PlotInfLines_S64Ptr(Encoding.UTF8.GetBytes(labelId), values, count, flags, offset, sizeof(long));
        }

        /// <summary>
        ///     Plots the inf lines using the specified label id
        /// </summary>
        /// <param name="labelId">The label identifier for the plot item</param>
        /// <param name="values">The array of data values to plot</param>
        /// <param name="count">The number of elements</param>
        /// <param name="flags">The ImGui behavior flags</param>
        /// <param name="offset">The offset from the origin</param>
        /// <param name="stride">The byte stride between elements</param>
        public static void PlotInfLines(string labelId, long[] values, int count, ImPlotInfLinesFlags flags, int offset, int stride)
        {
            ImPlotNative.ImPlot_PlotInfLines_S64Ptr(Encoding.UTF8.GetBytes(labelId), values, count, flags, offset, stride);
        }

        /// <summary>
        ///     Plots the inf lines using the specified label id
        /// </summary>
        /// <param name="labelId">The label identifier for the plot item</param>
        /// <param name="values">The array of data values to plot</param>
        /// <param name="count">The number of elements</param>
        public static void PlotInfLines(string labelId, ulong[] values, int count)
        {
            ImPlotNative.ImPlot_PlotInfLines_U64Ptr(Encoding.UTF8.GetBytes(labelId), values, count, ImPlotInfLinesFlags.None, 0, sizeof(ulong));
        }

        /// <summary>
        ///     Plots the inf lines using the specified label id
        /// </summary>
        /// <param name="labelId">The label identifier for the plot item</param>
        /// <param name="values">The array of data values to plot</param>
        /// <param name="count">The number of elements</param>
        /// <param name="flags">The ImGui behavior flags</param>
        public static void PlotInfLines(string labelId, ulong[] values, int count, ImPlotInfLinesFlags flags)
        {
            ImPlotNative.ImPlot_PlotInfLines_U64Ptr(Encoding.UTF8.GetBytes(labelId), values, count, flags, 0, sizeof(ulong));
        }

        /// <summary>
        ///     Plots the inf lines using the specified label id
        /// </summary>
        /// <param name="labelId">The label identifier for the plot item</param>
        /// <param name="values">The array of data values to plot</param>
        /// <param name="count">The number of elements</param>
        /// <param name="flags">The ImGui behavior flags</param>
        /// <param name="offset">The offset from the origin</param>
        public static void PlotInfLines(string labelId, ulong[] values, int count, ImPlotInfLinesFlags flags, int offset)
        {
            ImPlotNative.ImPlot_PlotInfLines_U64Ptr(Encoding.UTF8.GetBytes(labelId), values, count, flags, offset, sizeof(ulong));
        }

        /// <summary>
        ///     Plots the inf lines using the specified label id
        /// </summary>
        /// <param name="labelId">The label identifier for the plot item</param>
        /// <param name="values">The array of data values to plot</param>
        /// <param name="count">The number of elements</param>
        /// <param name="flags">The ImGui behavior flags</param>
        /// <param name="offset">The offset from the origin</param>
        /// <param name="stride">The byte stride between elements</param>
        public static void PlotInfLines(string labelId, ulong[] values, int count, ImPlotInfLinesFlags flags, int offset, int stride)
        {
            ImPlotNative.ImPlot_PlotInfLines_U64Ptr(Encoding.UTF8.GetBytes(labelId), values, count, flags, offset, stride);
        }

        /// <summary>
        ///     Plots the line using the specified label id
        /// </summary>
        /// <param name="labelId">The label identifier for the plot item</param>
        /// <param name="values">The array of data values to plot</param>
        /// <param name="count">The number of elements</param>
        public static void PlotLine(string labelId, float[] values, int count)
        {
            ImPlotNative.ImPlot_PlotLine_FloatPtrInt(Encoding.UTF8.GetBytes(labelId), values, count, 1, 0, 0, 0, sizeof(float));
        }

        /// <summary>
        ///     Plots the line using the specified label id
        /// </summary>
        /// <param name="labelId">The label identifier for the plot item</param>
        /// <param name="values">The array of data values to plot</param>
        /// <param name="count">The number of elements</param>
        /// <param name="xscale">The x-axis scale factor</param>
        public static void PlotLine(string labelId, float[] values, int count, double xscale)
        {
            ImPlotNative.ImPlot_PlotLine_FloatPtrInt(Encoding.UTF8.GetBytes(labelId), values, count, xscale, 0, 0, 0, sizeof(float));
        }

        /// <summary>
        ///     Plots the line using the specified label id
        /// </summary>
        /// <param name="labelId">The label identifier for the plot item</param>
        /// <param name="values">The array of data values to plot</param>
        /// <param name="count">The number of elements</param>
        /// <param name="xscale">The x-axis scale factor</param>
        /// <param name="xstart">The starting x value</param>
        public static void PlotLine(string labelId, float[] values, int count, double xscale, double xstart)
        {
            ImPlotNative.ImPlot_PlotLine_FloatPtrInt(Encoding.UTF8.GetBytes(labelId), values, count, xscale, xstart, 0, 0, sizeof(float));
        }

        /// <summary>
        ///     Plots the line using the specified label id
        /// </summary>
        /// <param name="labelId">The label identifier for the plot item</param>
        /// <param name="values">The array of data values to plot</param>
        /// <param name="count">The number of elements</param>
        /// <param name="xscale">The x-axis scale factor</param>
        /// <param name="xstart">The starting x value</param>
        /// <param name="flags">The ImGui behavior flags</param>
        public static void PlotLine(string labelId, float[] values, int count, double xscale, double xstart, ImPlotLineFlags flags)
        {
            ImPlotNative.ImPlot_PlotLine_FloatPtrInt(Encoding.UTF8.GetBytes(labelId), values, count, xscale, xstart, flags, 0, sizeof(float));
        }

        /// <summary>
        ///     Plots the line using the specified label id
        /// </summary>
        /// <param name="labelId">The label identifier for the plot item</param>
        /// <param name="values">The array of data values to plot</param>
        /// <param name="count">The number of elements</param>
        /// <param name="xscale">The x-axis scale factor</param>
        /// <param name="xstart">The starting x value</param>
        /// <param name="flags">The ImGui behavior flags</param>
        /// <param name="offset">The offset from the origin</param>
        public static void PlotLine(string labelId, float[] values, int count, double xscale, double xstart, ImPlotLineFlags flags, int offset)
        {
            ImPlotNative.ImPlot_PlotLine_FloatPtrInt(Encoding.UTF8.GetBytes(labelId), values, count, xscale, xstart, flags, offset, sizeof(float));
        }

        /// <summary>
        ///     Plots the line using the specified label id
        /// </summary>
        /// <param name="labelId">The label identifier for the plot item</param>
        /// <param name="values">The array of data values to plot</param>
        /// <param name="count">The number of elements</param>
        /// <param name="xscale">The x-axis scale factor</param>
        /// <param name="xstart">The starting x value</param>
        /// <param name="flags">The ImGui behavior flags</param>
        /// <param name="offset">The offset from the origin</param>
        /// <param name="stride">The byte stride between elements</param>
        public static void PlotLine(string labelId, float[] values, int count, double xscale, double xstart, ImPlotLineFlags flags, int offset, int stride)
        {
            ImPlotNative.ImPlot_PlotLine_FloatPtrInt(Encoding.UTF8.GetBytes(labelId), values, count, xscale, xstart, flags, offset, stride);
        }

        /// <summary>
        ///     Plots the line using the specified label id
        /// </summary>
        /// <param name="labelId">The label identifier for the plot item</param>
        /// <param name="values">The array of data values to plot</param>
        /// <param name="count">The number of elements</param>
        public static void PlotLine(string labelId, double[] values, int count)
        {
            ImPlotNative.ImPlot_PlotLine_doublePtrInt(Encoding.UTF8.GetBytes(labelId), values, count, 1, 0, 0, 0, 0);
        }

        /// <summary>
        ///     Plots the line using the specified label id
        /// </summary>
        /// <param name="labelId">The label identifier for the plot item</param>
        /// <param name="values">The array of data values to plot</param>
        /// <param name="count">The number of elements</param>
        /// <param name="xscale">The x-axis scale factor</param>
        public static void PlotLine(string labelId, double[] values, int count, double xscale)
        {
            ImPlotNative.ImPlot_PlotLine_doublePtrInt(Encoding.UTF8.GetBytes(labelId), values, count, xscale, 0, 0, 0, 0);
        }

        /// <summary>
        ///     Plots the line using the specified label id
        /// </summary>
        /// <param name="labelId">The label identifier for the plot item</param>
        /// <param name="values">The array of data values to plot</param>
        /// <param name="count">The number of elements</param>
        /// <param name="xscale">The x-axis scale factor</param>
        /// <param name="xstart">The starting x value</param>
        public static void PlotLine(string labelId, double[] values, int count, double xscale, double xstart)
        {
            ImPlotNative.ImPlot_PlotLine_doublePtrInt(Encoding.UTF8.GetBytes(labelId), values, count, xscale, xstart, 0, 0, 0);
        }

        /// <summary>
        ///     Plots the line using the specified label id
        /// </summary>
        /// <param name="labelId">The label identifier for the plot item</param>
        /// <param name="values">The array of data values to plot</param>
        /// <param name="count">The number of elements</param>
        /// <param name="xscale">The x-axis scale factor</param>
        /// <param name="xstart">The starting x value</param>
        /// <param name="flags">The ImGui behavior flags</param>
        public static void PlotLine(string labelId, double[] values, int count, double xscale, double xstart, ImPlotLineFlags flags)
        {
            ImPlotNative.ImPlot_PlotLine_doublePtrInt(Encoding.UTF8.GetBytes(labelId), values, count, xscale, xstart, flags, 0, 0);
        }

        /// <summary>
        ///     Plots the line using the specified label id
        /// </summary>
        /// <param name="labelId">The label identifier for the plot item</param>
        /// <param name="values">The array of data values to plot</param>
        /// <param name="count">The number of elements</param>
        /// <param name="xscale">The x-axis scale factor</param>
        /// <param name="xstart">The starting x value</param>
        /// <param name="flags">The ImGui behavior flags</param>
        /// <param name="offset">The offset from the origin</param>
        public static void PlotLine(string labelId, double[] values, int count, double xscale, double xstart, ImPlotLineFlags flags, int offset)
        {
            ImPlotNative.ImPlot_PlotLine_doublePtrInt(Encoding.UTF8.GetBytes(labelId), values, count, xscale, xstart, flags, offset, 0);
        }

        /// <summary>
        ///     Plots the line using the specified label id
        /// </summary>
        /// <param name="labelId">The label identifier for the plot item</param>
        /// <param name="values">The array of data values to plot</param>
        /// <param name="count">The number of elements</param>
        /// <param name="xscale">The x-axis scale factor</param>
        /// <param name="xstart">The starting x value</param>
        /// <param name="flags">The ImGui behavior flags</param>
        /// <param name="offset">The offset from the origin</param>
        /// <param name="stride">The byte stride between elements</param>
        public static void PlotLine(string labelId, double[] values, int count, double xscale, double xstart, ImPlotLineFlags flags, int offset, int stride)
        {
            ImPlotNative.ImPlot_PlotLine_doublePtrInt(Encoding.UTF8.GetBytes(labelId), values, count, xscale, xstart, flags, offset, stride);
        }

        /// <summary>
        ///     Plots the line using the specified label id
        /// </summary>
        /// <param name="labelId">The label identifier for the plot item</param>
        /// <param name="values">The array of data values to plot</param>
        /// <param name="count">The number of elements</param>
        public static void PlotLine(string labelId, sbyte[] values, int count)
        {
            ImPlotNative.ImPlot_PlotLine_S8PtrInt(Encoding.UTF8.GetBytes(labelId), values, count, 1, 0, 0, 0, 0);
        }

        /// <summary>
        ///     Plots the line using the specified label id
        /// </summary>
        /// <param name="labelId">The label identifier for the plot item</param>
        /// <param name="values">The array of data values to plot</param>
        /// <param name="count">The number of elements</param>
        /// <param name="xscale">The x-axis scale factor</param>
        public static void PlotLine(string labelId, sbyte[] values, int count, double xscale)
        {
            ImPlotNative.ImPlot_PlotLine_S8PtrInt(Encoding.UTF8.GetBytes(labelId), values, count, xscale, 0, 0, 0, 0);
        }

        /// <summary>
        ///     Plots the line using the specified label id
        /// </summary>
        /// <param name="labelId">The label identifier for the plot item</param>
        /// <param name="values">The array of data values to plot</param>
        /// <param name="count">The number of elements</param>
        /// <param name="xscale">The x-axis scale factor</param>
        /// <param name="xstart">The starting x value</param>
        public static void PlotLine(string labelId, sbyte[] values, int count, double xscale, double xstart)
        {
            ImPlotNative.ImPlot_PlotLine_S8PtrInt(Encoding.UTF8.GetBytes(labelId), values, count, xscale, xstart, 0, 0, 0);
        }

        /// <summary>
        ///     Plots the line using the specified label id
        /// </summary>
        /// <param name="labelId">The label identifier for the plot item</param>
        /// <param name="values">The array of data values to plot</param>
        /// <param name="count">The number of elements</param>
        /// <param name="xscale">The x-axis scale factor</param>
        /// <param name="xstart">The starting x value</param>
        /// <param name="flags">The ImGui behavior flags</param>
        public static void PlotLine(string labelId, sbyte[] values, int count, double xscale, double xstart, ImPlotLineFlags flags)
        {
            ImPlotNative.ImPlot_PlotLine_S8PtrInt(Encoding.UTF8.GetBytes(labelId), values, count, xscale, xstart, flags, 0, 0);
        }

        /// <summary>
        ///     Plots the line using the specified label id
        /// </summary>
        /// <param name="labelId">The label identifier for the plot item</param>
        /// <param name="values">The array of data values to plot</param>
        /// <param name="count">The number of elements</param>
        /// <param name="xscale">The x-axis scale factor</param>
        /// <param name="xstart">The starting x value</param>
        /// <param name="flags">The ImGui behavior flags</param>
        /// <param name="offset">The offset from the origin</param>
        public static void PlotLine(string labelId, sbyte[] values, int count, double xscale, double xstart, ImPlotLineFlags flags, int offset)
        {
            ImPlotNative.ImPlot_PlotLine_S8PtrInt(Encoding.UTF8.GetBytes(labelId), values, count, xscale, xstart, flags, offset, 0);
        }

        /// <summary>
        ///     Plots the line using the specified label id
        /// </summary>
        /// <param name="labelId">The label identifier for the plot item</param>
        /// <param name="values">The array of data values to plot</param>
        /// <param name="count">The number of elements</param>
        /// <param name="xscale">The x-axis scale factor</param>
        /// <param name="xstart">The starting x value</param>
        /// <param name="flags">The ImGui behavior flags</param>
        /// <param name="offset">The offset from the origin</param>
        /// <param name="stride">The byte stride between elements</param>
        public static void PlotLine(string labelId, sbyte[] values, int count, double xscale, double xstart, ImPlotLineFlags flags, int offset, int stride)
        {
            ImPlotNative.ImPlot_PlotLine_S8PtrInt(Encoding.UTF8.GetBytes(labelId), values, count, xscale, xstart, flags, offset, stride);
        }

        /// <summary>
        ///     Plots the line using the specified label id
        /// </summary>
        /// <param name="labelId">The label identifier for the plot item</param>
        /// <param name="values">The array of data values to plot</param>
        /// <param name="count">The number of elements</param>
        public static void PlotLine(string labelId, byte[] values, int count)
        {
            ImPlotNative.ImPlot_PlotLine_U8PtrInt(Encoding.UTF8.GetBytes(labelId), values, count, 1, 0, 0, 0, 0);
        }

        /// <summary>
        ///     Plots the line using the specified label id
        /// </summary>
        /// <param name="labelId">The label identifier for the plot item</param>
        /// <param name="values">The array of data values to plot</param>
        /// <param name="count">The number of elements</param>
        /// <param name="xscale">The x-axis scale factor</param>
        public static void PlotLine(string labelId, byte[] values, int count, double xscale)
        {
            ImPlotNative.ImPlot_PlotLine_U8PtrInt(Encoding.UTF8.GetBytes(labelId), values, count, xscale, 0, 0, 0, 0);
        }

        /// <summary>
        ///     Plots the line using the specified label id
        /// </summary>
        /// <param name="labelId">The label identifier for the plot item</param>
        /// <param name="values">The array of data values to plot</param>
        /// <param name="count">The number of elements</param>
        /// <param name="xscale">The x-axis scale factor</param>
        /// <param name="xstart">The starting x value</param>
        public static void PlotLine(string labelId, byte[] values, int count, double xscale, double xstart)
        {
            ImPlotNative.ImPlot_PlotLine_U8PtrInt(Encoding.UTF8.GetBytes(labelId), values, count, xscale, xstart, 0, 0, 0);
        }

        /// <summary>
        ///     Plots the line using the specified label id
        /// </summary>
        /// <param name="labelId">The label identifier for the plot item</param>
        /// <param name="values">The array of data values to plot</param>
        /// <param name="count">The number of elements</param>
        /// <param name="xscale">The x-axis scale factor</param>
        /// <param name="xstart">The starting x value</param>
        /// <param name="flags">The ImGui behavior flags</param>
        public static void PlotLine(string labelId, byte[] values, int count, double xscale, double xstart, ImPlotLineFlags flags)
        {
            ImPlotNative.ImPlot_PlotLine_U8PtrInt(Encoding.UTF8.GetBytes(labelId), values, count, xscale, xstart, flags, 0, 0);
        }

        /// <summary>
        ///     Plots the line using the specified label id
        /// </summary>
        /// <param name="labelId">The label identifier for the plot item</param>
        /// <param name="values">The array of data values to plot</param>
        /// <param name="count">The number of elements</param>
        /// <param name="xscale">The x-axis scale factor</param>
        /// <param name="xstart">The starting x value</param>
        /// <param name="flags">The ImGui behavior flags</param>
        /// <param name="offset">The offset from the origin</param>
        public static void PlotLine(string labelId, byte[] values, int count, double xscale, double xstart, ImPlotLineFlags flags, int offset)
        {
            ImPlotNative.ImPlot_PlotLine_U8PtrInt(Encoding.UTF8.GetBytes(labelId), values, count, xscale, xstart, flags, offset, 0);
        }

        /// <summary>
        ///     Plots the line using the specified label id
        /// </summary>
        /// <param name="labelId">The label identifier for the plot item</param>
        /// <param name="values">The array of data values to plot</param>
        /// <param name="count">The number of elements</param>
        /// <param name="xscale">The x-axis scale factor</param>
        /// <param name="xstart">The starting x value</param>
        /// <param name="flags">The ImGui behavior flags</param>
        /// <param name="offset">The offset from the origin</param>
        /// <param name="stride">The byte stride between elements</param>
        public static void PlotLine(string labelId, byte[] values, int count, double xscale, double xstart, ImPlotLineFlags flags, int offset, int stride)
        {
            ImPlotNative.ImPlot_PlotLine_U8PtrInt(Encoding.UTF8.GetBytes(labelId), values, count, xscale, xstart, flags, offset, stride);
        }

        /// <summary>
        ///     Plots the line using the specified label id
        /// </summary>
        /// <param name="labelId">The label identifier for the plot item</param>
        /// <param name="values">The array of data values to plot</param>
        /// <param name="count">The number of elements</param>
        public static void PlotLine(string labelId, short[] values, int count)
        {
            ImPlotNative.ImPlot_PlotLine_S16PtrInt(Encoding.UTF8.GetBytes(labelId), values, count, 1, 0, 0, 0, 0);
        }

        /// <summary>
        ///     Plots the line using the specified label id
        /// </summary>
        /// <param name="labelId">The label identifier for the plot item</param>
        /// <param name="values">The array of data values to plot</param>
        /// <param name="count">The number of elements</param>
        /// <param name="xscale">The x-axis scale factor</param>
        public static void PlotLine(string labelId, short[] values, int count, double xscale)
        {
            ImPlotNative.ImPlot_PlotLine_S16PtrInt(Encoding.UTF8.GetBytes(labelId), values, count, xscale, 0, 0, 0, 0);
        }

        /// <summary>
        ///     Plots the line using the specified label id
        /// </summary>
        /// <param name="labelId">The label identifier for the plot item</param>
        /// <param name="values">The array of data values to plot</param>
        /// <param name="count">The number of elements</param>
        /// <param name="xscale">The x-axis scale factor</param>
        /// <param name="xstart">The starting x value</param>
        public static void PlotLine(string labelId, short[] values, int count, double xscale, double xstart)
        {
            ImPlotNative.ImPlot_PlotLine_S16PtrInt(Encoding.UTF8.GetBytes(labelId), values, count, xscale, xstart, 0, 0, 0);
        }

        /// <summary>
        ///     Plots the line using the specified label id
        /// </summary>
        /// <param name="labelId">The label identifier for the plot item</param>
        /// <param name="values">The array of data values to plot</param>
        /// <param name="count">The number of elements</param>
        /// <param name="xscale">The x-axis scale factor</param>
        /// <param name="xstart">The starting x value</param>
        /// <param name="flags">The ImGui behavior flags</param>
        public static void PlotLine(string labelId, short[] values, int count, double xscale, double xstart, ImPlotLineFlags flags)
        {
            ImPlotNative.ImPlot_PlotLine_S16PtrInt(Encoding.UTF8.GetBytes(labelId), values, count, xscale, xstart, flags, 0, 0);
        }

        /// <summary>
        ///     Plots the line using the specified label id
        /// </summary>
        /// <param name="labelId">The label identifier for the plot item</param>
        /// <param name="values">The array of data values to plot</param>
        /// <param name="count">The number of elements</param>
        /// <param name="xscale">The x-axis scale factor</param>
        /// <param name="xstart">The starting x value</param>
        /// <param name="flags">The ImGui behavior flags</param>
        /// <param name="offset">The offset from the origin</param>
        public static void PlotLine(string labelId, short[] values, int count, double xscale, double xstart, ImPlotLineFlags flags, int offset)
        {
            ImPlotNative.ImPlot_PlotLine_S16PtrInt(Encoding.UTF8.GetBytes(labelId), values, count, xscale, xstart, flags, offset, 0);
        }
    }
}