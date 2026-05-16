// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImPlotP19.cs
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
        ///     Plots the stairs using the specified label id
        /// </summary>
        /// <param name="labelId">The label identifier for the plot item</param>
        /// <param name="values">The array of data values to plot</param>
        /// <param name="count">The number of elements</param>
        /// <param name="xscale">The x-axis scale factor</param>
        /// <param name="xstart">The starting x value</param>
        /// <param name="flags">The ImGui behavior flags</param>
        public static void PlotStairs(string labelId, byte[] values, int count, double xscale, double xstart, ImPlotStairsFlags flags)
        {
            ImPlotNative.ImPlot_PlotStairs_U8PtrInt(Encoding.UTF8.GetBytes(labelId), values, count, xscale, xstart, flags, 0, sizeof(byte));
        }

        /// <summary>
        ///     Plots the stairs using the specified label id
        /// </summary>
        /// <param name="labelId">The label identifier for the plot item</param>
        /// <param name="values">The array of data values to plot</param>
        /// <param name="count">The number of elements</param>
        /// <param name="xscale">The x-axis scale factor</param>
        /// <param name="xstart">The starting x value</param>
        /// <param name="flags">The ImGui behavior flags</param>
        /// <param name="offset">The offset from the origin</param>
        public static void PlotStairs(string labelId, byte[] values, int count, double xscale, double xstart, ImPlotStairsFlags flags, int offset)
        {
            ImPlotNative.ImPlot_PlotStairs_U8PtrInt(Encoding.UTF8.GetBytes(labelId), values, count, xscale, xstart, flags, offset, sizeof(byte));
        }

        /// <summary>
        ///     Plots the stairs using the specified label id
        /// </summary>
        /// <param name="labelId">The label identifier for the plot item</param>
        /// <param name="values">The array of data values to plot</param>
        /// <param name="count">The number of elements</param>
        /// <param name="xscale">The x-axis scale factor</param>
        /// <param name="xstart">The starting x value</param>
        /// <param name="flags">The ImGui behavior flags</param>
        /// <param name="offset">The offset from the origin</param>
        /// <param name="stride">The byte stride between elements</param>
        public static void PlotStairs(string labelId, byte[] values, int count, double xscale, double xstart, ImPlotStairsFlags flags, int offset, int stride)
        {
            ImPlotNative.ImPlot_PlotStairs_U8PtrInt(Encoding.UTF8.GetBytes(labelId), values, count, xscale, xstart, flags, offset, stride);
        }

        /// <summary>
        ///     Plots the stairs using the specified label id
        /// </summary>
        /// <param name="labelId">The label identifier for the plot item</param>
        /// <param name="values">The array of data values to plot</param>
        /// <param name="count">The number of elements</param>
        public static void PlotStairs(string labelId, short[] values, int count)
        {
            ImPlotNative.ImPlot_PlotStairs_S16PtrInt(Encoding.UTF8.GetBytes(labelId), values, count, 1, 0, 0, 0, sizeof(short));
        }

        /// <summary>
        ///     Plots the stairs using the specified label id
        /// </summary>
        /// <param name="labelId">The label identifier for the plot item</param>
        /// <param name="values">The array of data values to plot</param>
        /// <param name="count">The number of elements</param>
        /// <param name="xscale">The x-axis scale factor</param>
        public static void PlotStairs(string labelId, short[] values, int count, double xscale)
        {
            ImPlotNative.ImPlot_PlotStairs_S16PtrInt(Encoding.UTF8.GetBytes(labelId), values, count, xscale, 0, 0, 0, sizeof(short));
        }

        /// <summary>
        ///     Plots the stairs using the specified label id
        /// </summary>
        /// <param name="labelId">The label identifier for the plot item</param>
        /// <param name="values">The array of data values to plot</param>
        /// <param name="count">The number of elements</param>
        /// <param name="xscale">The x-axis scale factor</param>
        /// <param name="xstart">The starting x value</param>
        public static void PlotStairs(string labelId, short[] values, int count, double xscale, double xstart)
        {
            ImPlotNative.ImPlot_PlotStairs_S16PtrInt(Encoding.UTF8.GetBytes(labelId), values, count, xscale, xstart, 0, 0, sizeof(short));
        }

        /// <summary>
        ///     Plots the stairs using the specified label id
        /// </summary>
        /// <param name="labelId">The label identifier for the plot item</param>
        /// <param name="values">The array of data values to plot</param>
        /// <param name="count">The number of elements</param>
        /// <param name="xscale">The x-axis scale factor</param>
        /// <param name="xstart">The starting x value</param>
        /// <param name="flags">The ImGui behavior flags</param>
        public static void PlotStairs(string labelId, short[] values, int count, double xscale, double xstart, ImPlotStairsFlags flags)
        {
            ImPlotNative.ImPlot_PlotStairs_S16PtrInt(Encoding.UTF8.GetBytes(labelId), values, count, xscale, xstart, flags, 0, sizeof(short));
        }

        /// <summary>
        ///     Plots the stairs using the specified label id
        /// </summary>
        /// <param name="labelId">The label identifier for the plot item</param>
        /// <param name="values">The array of data values to plot</param>
        /// <param name="count">The number of elements</param>
        /// <param name="xscale">The x-axis scale factor</param>
        /// <param name="xstart">The starting x value</param>
        /// <param name="flags">The ImGui behavior flags</param>
        /// <param name="offset">The offset from the origin</param>
        public static void PlotStairs(string labelId, short[] values, int count, double xscale, double xstart, ImPlotStairsFlags flags, int offset)
        {
            ImPlotNative.ImPlot_PlotStairs_S16PtrInt(Encoding.UTF8.GetBytes(labelId), values, count, xscale, xstart, flags, offset, sizeof(short));
        }

        /// <summary>
        ///     Plots the stairs using the specified label id
        /// </summary>
        /// <param name="labelId">The label identifier for the plot item</param>
        /// <param name="values">The array of data values to plot</param>
        /// <param name="count">The number of elements</param>
        /// <param name="xscale">The x-axis scale factor</param>
        /// <param name="xstart">The starting x value</param>
        /// <param name="flags">The ImGui behavior flags</param>
        /// <param name="offset">The offset from the origin</param>
        /// <param name="stride">The byte stride between elements</param>
        public static void PlotStairs(string labelId, short[] values, int count, double xscale, double xstart, ImPlotStairsFlags flags, int offset, int stride)
        {
            ImPlotNative.ImPlot_PlotStairs_S16PtrInt(Encoding.UTF8.GetBytes(labelId), values, count, xscale, xstart, flags, offset, stride);
        }

        /// <summary>
        ///     Plots the stairs using the specified label id
        /// </summary>
        /// <param name="labelId">The label identifier for the plot item</param>
        /// <param name="values">The array of data values to plot</param>
        /// <param name="count">The number of elements</param>
        public static void PlotStairs(string labelId, ushort[] values, int count)
        {
            ImPlotNative.ImPlot_PlotStairs_U16PtrInt(Encoding.UTF8.GetBytes(labelId), values, count, 1, 0, 0, 0, sizeof(ushort));
        }

        /// <summary>
        ///     Plots the stairs using the specified label id
        /// </summary>
        /// <param name="labelId">The label identifier for the plot item</param>
        /// <param name="values">The array of data values to plot</param>
        /// <param name="count">The number of elements</param>
        /// <param name="xscale">The x-axis scale factor</param>
        public static void PlotStairs(string labelId, ushort[] values, int count, double xscale)
        {
            ImPlotNative.ImPlot_PlotStairs_U16PtrInt(Encoding.UTF8.GetBytes(labelId), values, count, xscale, 0, 0, 0, sizeof(ushort));
        }

        /// <summary>
        ///     Plots the stairs using the specified label id
        /// </summary>
        /// <param name="labelId">The label identifier for the plot item</param>
        /// <param name="values">The array of data values to plot</param>
        /// <param name="count">The number of elements</param>
        /// <param name="xscale">The x-axis scale factor</param>
        /// <param name="xstart">The starting x value</param>
        public static void PlotStairs(string labelId, ushort[] values, int count, double xscale, double xstart)
        {
            ImPlotNative.ImPlot_PlotStairs_U16PtrInt(Encoding.UTF8.GetBytes(labelId), values, count, xscale, xstart, 0, 0, sizeof(ushort));
        }

        /// <summary>
        ///     Plots the stairs using the specified label id
        /// </summary>
        /// <param name="labelId">The label identifier for the plot item</param>
        /// <param name="values">The array of data values to plot</param>
        /// <param name="count">The number of elements</param>
        /// <param name="xscale">The x-axis scale factor</param>
        /// <param name="xstart">The starting x value</param>
        /// <param name="flags">The ImGui behavior flags</param>
        public static void PlotStairs(string labelId, ushort[] values, int count, double xscale, double xstart, ImPlotStairsFlags flags)
        {
            ImPlotNative.ImPlot_PlotStairs_U16PtrInt(Encoding.UTF8.GetBytes(labelId), values, count, xscale, xstart, flags, 0, sizeof(ushort));
        }

        /// <summary>
        ///     Plots the stairs using the specified label id
        /// </summary>
        /// <param name="labelId">The label identifier for the plot item</param>
        /// <param name="values">The array of data values to plot</param>
        /// <param name="count">The number of elements</param>
        /// <param name="xscale">The x-axis scale factor</param>
        /// <param name="xstart">The starting x value</param>
        /// <param name="flags">The ImGui behavior flags</param>
        /// <param name="offset">The offset from the origin</param>
        public static void PlotStairs(string labelId, ushort[] values, int count, double xscale, double xstart, ImPlotStairsFlags flags, int offset)
        {
            ImPlotNative.ImPlot_PlotStairs_U16PtrInt(Encoding.UTF8.GetBytes(labelId), values, count, xscale, xstart, flags, offset, sizeof(ushort));
        }

        /// <summary>
        ///     Plots the stairs using the specified label id
        /// </summary>
        /// <param name="labelId">The label identifier for the plot item</param>
        /// <param name="values">The array of data values to plot</param>
        /// <param name="count">The number of elements</param>
        /// <param name="xscale">The x-axis scale factor</param>
        /// <param name="xstart">The starting x value</param>
        /// <param name="flags">The ImGui behavior flags</param>
        /// <param name="offset">The offset from the origin</param>
        /// <param name="stride">The byte stride between elements</param>
        public static void PlotStairs(string labelId, ushort[] values, int count, double xscale, double xstart, ImPlotStairsFlags flags, int offset, int stride)
        {
            ImPlotNative.ImPlot_PlotStairs_U16PtrInt(Encoding.UTF8.GetBytes(labelId), values, count, xscale, xstart, flags, offset, stride);
        }

        /// <summary>
        ///     Plots the stairs using the specified label id
        /// </summary>
        /// <param name="labelId">The label identifier for the plot item</param>
        /// <param name="values">The array of data values to plot</param>
        /// <param name="count">The number of elements</param>
        public static void PlotStairs(string labelId, int[] values, int count)
        {
            ImPlotNative.ImPlot_PlotStairs_S32PtrInt(Encoding.UTF8.GetBytes(labelId), values, count, 1, 0, 0, 0, sizeof(int));
        }

        /// <summary>
        ///     Plots the stairs using the specified label id
        /// </summary>
        /// <param name="labelId">The label identifier for the plot item</param>
        /// <param name="values">The array of data values to plot</param>
        /// <param name="count">The number of elements</param>
        /// <param name="xscale">The x-axis scale factor</param>
        public static void PlotStairs(string labelId, int[] values, int count, double xscale)
        {
            ImPlotNative.ImPlot_PlotStairs_S32PtrInt(Encoding.UTF8.GetBytes(labelId), values, count, xscale, 0, 0, 0, sizeof(int));
        }


        /// <summary>
        ///     Plots the stairs using the specified label id
        /// </summary>
        /// <param name="labelId">The label identifier for the plot item</param>
        /// <param name="values">The array of data values to plot</param>
        /// <param name="count">The number of elements</param>
        /// <param name="xscale">The x-axis scale factor</param>
        /// <param name="xstart">The starting x value</param>
        public static void PlotStairs(string labelId, int[] values, int count, double xscale, double xstart)
        {
            ImPlotNative.ImPlot_PlotStairs_S32PtrInt(Encoding.UTF8.GetBytes(labelId), values, count, xscale, xstart, 0, 0, sizeof(int));
        }

        /// <summary>
        ///     Plots the stairs using the specified label id
        /// </summary>
        /// <param name="labelId">The label identifier for the plot item</param>
        /// <param name="values">The array of data values to plot</param>
        /// <param name="count">The number of elements</param>
        /// <param name="xscale">The x-axis scale factor</param>
        /// <param name="xstart">The starting x value</param>
        /// <param name="flags">The ImGui behavior flags</param>
        public static void PlotStairs(string labelId, int[] values, int count, double xscale, double xstart, ImPlotStairsFlags flags)
        {
            ImPlotNative.ImPlot_PlotStairs_S32PtrInt(Encoding.UTF8.GetBytes(labelId), values, count, xscale, xstart, flags, 0, sizeof(int));
        }

        /// <summary>
        ///     Plots the stairs using the specified label id
        /// </summary>
        /// <param name="labelId">The label identifier for the plot item</param>
        /// <param name="values">The array of data values to plot</param>
        /// <param name="count">The number of elements</param>
        /// <param name="xscale">The x-axis scale factor</param>
        /// <param name="xstart">The starting x value</param>
        /// <param name="flags">The ImGui behavior flags</param>
        /// <param name="offset">The offset from the origin</param>
        public static void PlotStairs(string labelId, int[] values, int count, double xscale, double xstart, ImPlotStairsFlags flags, int offset)
        {
            ImPlotNative.ImPlot_PlotStairs_S32PtrInt(Encoding.UTF8.GetBytes(labelId), values, count, xscale, xstart, flags, offset, sizeof(int));
        }

        /// <summary>
        ///     Plots the stairs using the specified label id
        /// </summary>
        /// <param name="labelId">The label identifier for the plot item</param>
        /// <param name="values">The array of data values to plot</param>
        /// <param name="count">The number of elements</param>
        /// <param name="xscale">The x-axis scale factor</param>
        /// <param name="xstart">The starting x value</param>
        /// <param name="flags">The ImGui behavior flags</param>
        /// <param name="offset">The offset from the origin</param>
        /// <param name="stride">The byte stride between elements</param>
        public static void PlotStairs(string labelId, int[] values, int count, double xscale, double xstart, ImPlotStairsFlags flags, int offset, int stride)
        {
            ImPlotNative.ImPlot_PlotStairs_S32PtrInt(Encoding.UTF8.GetBytes(labelId), values, count, xscale, xstart, flags, offset, stride);
        }

        /// <summary>
        ///     Plots the stairs using the specified label id
        /// </summary>
        /// <param name="labelId">The label identifier for the plot item</param>
        /// <param name="values">The array of data values to plot</param>
        /// <param name="count">The number of elements</param>
        public static void PlotStairs(string labelId, uint[] values, int count)
        {
            ImPlotNative.ImPlot_PlotStairs_U32PtrInt(Encoding.UTF8.GetBytes(labelId), values, count, 1, 0, 0, 0, sizeof(uint));
        }

        /// <summary>
        ///     Plots the stairs using the specified label id
        /// </summary>
        /// <param name="labelId">The label identifier for the plot item</param>
        /// <param name="values">The array of data values to plot</param>
        /// <param name="count">The number of elements</param>
        /// <param name="xscale">The x-axis scale factor</param>
        public static void PlotStairs(string labelId, uint[] values, int count, double xscale)
        {
            ImPlotNative.ImPlot_PlotStairs_U32PtrInt(Encoding.UTF8.GetBytes(labelId), values, count, xscale, 0, 0, 0, sizeof(uint));
        }

        /// <summary>
        ///     Plots the stairs using the specified label id
        /// </summary>
        /// <param name="labelId">The label identifier for the plot item</param>
        /// <param name="values">The array of data values to plot</param>
        /// <param name="count">The number of elements</param>
        /// <param name="xscale">The x-axis scale factor</param>
        /// <param name="xstart">The starting x value</param>
        public static void PlotStairs(string labelId, uint[] values, int count, double xscale, double xstart)
        {
            ImPlotNative.ImPlot_PlotStairs_U32PtrInt(Encoding.UTF8.GetBytes(labelId), values, count, xscale, xstart, 0, 0, sizeof(uint));
        }

        /// <summary>
        ///     Plots the stairs using the specified label id
        /// </summary>
        /// <param name="labelId">The label identifier for the plot item</param>
        /// <param name="values">The array of data values to plot</param>
        /// <param name="count">The number of elements</param>
        /// <param name="xscale">The x-axis scale factor</param>
        /// <param name="xstart">The starting x value</param>
        /// <param name="flags">The ImGui behavior flags</param>
        public static void PlotStairs(string labelId, uint[] values, int count, double xscale, double xstart, ImPlotStairsFlags flags)
        {
            ImPlotNative.ImPlot_PlotStairs_U32PtrInt(Encoding.UTF8.GetBytes(labelId), values, count, xscale, xstart, flags, 0, sizeof(uint));
        }

        /// <summary>
        ///     Plots the stairs using the specified label id
        /// </summary>
        /// <param name="labelId">The label identifier for the plot item</param>
        /// <param name="values">The array of data values to plot</param>
        /// <param name="count">The number of elements</param>
        /// <param name="xscale">The x-axis scale factor</param>
        /// <param name="xstart">The starting x value</param>
        /// <param name="flags">The ImGui behavior flags</param>
        /// <param name="offset">The offset from the origin</param>
        public static void PlotStairs(string labelId, uint[] values, int count, double xscale, double xstart, ImPlotStairsFlags flags, int offset)
        {
            ImPlotNative.ImPlot_PlotStairs_U32PtrInt(Encoding.UTF8.GetBytes(labelId), values, count, xscale, xstart, flags, offset, sizeof(uint));
        }

        /// <summary>
        ///     Plots the stairs using the specified label id
        /// </summary>
        /// <param name="labelId">The label identifier for the plot item</param>
        /// <param name="values">The array of data values to plot</param>
        /// <param name="count">The number of elements</param>
        /// <param name="xscale">The x-axis scale factor</param>
        /// <param name="xstart">The starting x value</param>
        /// <param name="flags">The ImGui behavior flags</param>
        /// <param name="offset">The offset from the origin</param>
        /// <param name="stride">The byte stride between elements</param>
        public static void PlotStairs(string labelId, uint[] values, int count, double xscale, double xstart, ImPlotStairsFlags flags, int offset, int stride)
        {
            ImPlotNative.ImPlot_PlotStairs_U32PtrInt(Encoding.UTF8.GetBytes(labelId), values, count, xscale, xstart, flags, offset, stride);
        }

        /// <summary>
        ///     Plots the stairs using the specified label id
        /// </summary>
        /// <param name="labelId">The label identifier for the plot item</param>
        /// <param name="values">The array of data values to plot</param>
        /// <param name="count">The number of elements</param>
        public static void PlotStairs(string labelId, long[] values, int count)
        {
            ImPlotNative.ImPlot_PlotStairs_S64PtrInt(Encoding.UTF8.GetBytes(labelId), values, count, 1, 0, 0, 0, sizeof(long));
        }

        /// <summary>
        ///     Plots the stairs using the specified label id
        /// </summary>
        /// <param name="labelId">The label identifier for the plot item</param>
        /// <param name="values">The array of data values to plot</param>
        /// <param name="count">The number of elements</param>
        /// <param name="xscale">The x-axis scale factor</param>
        public static void PlotStairs(string labelId, long[] values, int count, double xscale)
        {
            ImPlotNative.ImPlot_PlotStairs_S64PtrInt(Encoding.UTF8.GetBytes(labelId), values, count, xscale, 0, 0, 0, sizeof(long));
        }

        /// <summary>
        ///     Plots the stairs using the specified label id
        /// </summary>
        /// <param name="labelId">The label identifier for the plot item</param>
        /// <param name="values">The array of data values to plot</param>
        /// <param name="count">The number of elements</param>
        /// <param name="xscale">The x-axis scale factor</param>
        /// <param name="xstart">The starting x value</param>
        public static void PlotStairs(string labelId, long[] values, int count, double xscale, double xstart)
        {
            ImPlotNative.ImPlot_PlotStairs_S64PtrInt(Encoding.UTF8.GetBytes(labelId), values, count, xscale, xstart, 0, 0, sizeof(long));
        }

        /// <summary>
        ///     Plots the stairs using the specified label id
        /// </summary>
        /// <param name="labelId">The label identifier for the plot item</param>
        /// <param name="values">The array of data values to plot</param>
        /// <param name="count">The number of elements</param>
        /// <param name="xscale">The x-axis scale factor</param>
        /// <param name="xstart">The starting x value</param>
        /// <param name="flags">The ImGui behavior flags</param>
        public static void PlotStairs(string labelId, long[] values, int count, double xscale, double xstart, ImPlotStairsFlags flags)
        {
            ImPlotNative.ImPlot_PlotStairs_S64PtrInt(Encoding.UTF8.GetBytes(labelId), values, count, xscale, xstart, flags, 0, sizeof(long));
        }

        /// <summary>
        ///     Plots the stairs using the specified label id
        /// </summary>
        /// <param name="labelId">The label identifier for the plot item</param>
        /// <param name="values">The array of data values to plot</param>
        /// <param name="count">The number of elements</param>
        /// <param name="xscale">The x-axis scale factor</param>
        /// <param name="xstart">The starting x value</param>
        /// <param name="flags">The ImGui behavior flags</param>
        /// <param name="offset">The offset from the origin</param>
        public static void PlotStairs(string labelId, long[] values, int count, double xscale, double xstart, ImPlotStairsFlags flags, int offset)
        {
            ImPlotNative.ImPlot_PlotStairs_S64PtrInt(Encoding.UTF8.GetBytes(labelId), values, count, xscale, xstart, flags, offset, sizeof(long));
        }

        /// <summary>
        ///     Plots the stairs using the specified label id
        /// </summary>
        /// <param name="labelId">The label identifier for the plot item</param>
        /// <param name="values">The array of data values to plot</param>
        /// <param name="count">The number of elements</param>
        /// <param name="xscale">The x-axis scale factor</param>
        /// <param name="xstart">The starting x value</param>
        /// <param name="flags">The ImGui behavior flags</param>
        /// <param name="offset">The offset from the origin</param>
        /// <param name="stride">The byte stride between elements</param>
        public static void PlotStairs(string labelId, long[] values, int count, double xscale, double xstart, ImPlotStairsFlags flags, int offset, int stride)
        {
            ImPlotNative.ImPlot_PlotStairs_S64PtrInt(Encoding.UTF8.GetBytes(labelId), values, count, xscale, xstart, flags, offset, stride);
        }

        /// <summary>
        ///     Plots the stairs using the specified label id
        /// </summary>
        /// <param name="labelId">The label identifier for the plot item</param>
        /// <param name="values">The array of data values to plot</param>
        /// <param name="count">The number of elements</param>
        public static void PlotStairs(string labelId, ulong[] values, int count)
        {
            ImPlotNative.ImPlot_PlotStairs_U64PtrInt(Encoding.UTF8.GetBytes(labelId), values, count, 1, 0, 0, 0, sizeof(ulong));
        }

        /// <summary>
        ///     Plots the stairs using the specified label id
        /// </summary>
        /// <param name="labelId">The label identifier for the plot item</param>
        /// <param name="values">The array of data values to plot</param>
        /// <param name="count">The number of elements</param>
        /// <param name="xscale">The x-axis scale factor</param>
        public static void PlotStairs(string labelId, ulong[] values, int count, double xscale)
        {
            ImPlotNative.ImPlot_PlotStairs_U64PtrInt(Encoding.UTF8.GetBytes(labelId), values, count, xscale, 0, 0, 0, sizeof(ulong));
        }

        /// <summary>
        ///     Plots the stairs using the specified label id
        /// </summary>
        /// <param name="labelId">The label identifier for the plot item</param>
        /// <param name="values">The array of data values to plot</param>
        /// <param name="count">The number of elements</param>
        /// <param name="xscale">The x-axis scale factor</param>
        /// <param name="xstart">The starting x value</param>
        public static void PlotStairs(string labelId, ulong[] values, int count, double xscale, double xstart)
        {
            ImPlotNative.ImPlot_PlotStairs_U64PtrInt(Encoding.UTF8.GetBytes(labelId), values, count, xscale, xstart, 0, 0, sizeof(ulong));
        }

        /// <summary>
        ///     Plots the stairs using the specified label id
        /// </summary>
        /// <param name="labelId">The label identifier for the plot item</param>
        /// <param name="values">The array of data values to plot</param>
        /// <param name="count">The number of elements</param>
        /// <param name="xscale">The x-axis scale factor</param>
        /// <param name="xstart">The starting x value</param>
        /// <param name="flags">The ImGui behavior flags</param>
        public static void PlotStairs(string labelId, ulong[] values, int count, double xscale, double xstart, ImPlotStairsFlags flags)
        {
            ImPlotNative.ImPlot_PlotStairs_U64PtrInt(Encoding.UTF8.GetBytes(labelId), values, count, xscale, xstart, flags, 0, sizeof(ulong));
        }

        /// <summary>
        ///     Plots the stairs using the specified label id
        /// </summary>
        /// <param name="labelId">The label identifier for the plot item</param>
        /// <param name="values">The array of data values to plot</param>
        /// <param name="count">The number of elements</param>
        /// <param name="xscale">The x-axis scale factor</param>
        /// <param name="xstart">The starting x value</param>
        /// <param name="flags">The ImGui behavior flags</param>
        /// <param name="offset">The offset from the origin</param>
        public static void PlotStairs(string labelId, ulong[] values, int count, double xscale, double xstart, ImPlotStairsFlags flags, int offset)
        {
            ImPlotNative.ImPlot_PlotStairs_U64PtrInt(Encoding.UTF8.GetBytes(labelId), values, count, xscale, xstart, flags, offset, sizeof(ulong));
        }

        /// <summary>
        ///     Plots the stairs using the specified label id
        /// </summary>
        /// <param name="labelId">The label identifier for the plot item</param>
        /// <param name="values">The array of data values to plot</param>
        /// <param name="count">The number of elements</param>
        /// <param name="xscale">The x-axis scale factor</param>
        /// <param name="xstart">The starting x value</param>
        /// <param name="flags">The ImGui behavior flags</param>
        /// <param name="offset">The offset from the origin</param>
        /// <param name="stride">The byte stride between elements</param>
        public static void PlotStairs(string labelId, ulong[] values, int count, double xscale, double xstart, ImPlotStairsFlags flags, int offset, int stride)
        {
            ImPlotNative.ImPlot_PlotStairs_U64PtrInt(Encoding.UTF8.GetBytes(labelId), values, count, xscale, xstart, flags, offset, stride);
        }

        /// <summary>
        ///     Plots the stairs using the specified label id
        /// </summary>
        /// <param name="labelId">The label identifier for the plot item</param>
        /// <param name="xs">The array of x-coordinate values</param>
        /// <param name="ys">The array of y-coordinate values</param>
        /// <param name="count">The number of elements</param>
        public static void PlotStairs(string labelId, ref float xs, ref float ys, int count)
        {
            ImPlotNative.ImPlot_PlotStairs_FloatPtrFloatPtr(Encoding.UTF8.GetBytes(labelId), ref xs, ref ys, count, 0, 0, sizeof(float));
        }

        /// <summary>
        ///     Plots the stairs using the specified label id
        /// </summary>
        /// <param name="labelId">The label identifier for the plot item</param>
        /// <param name="xs">The array of x-coordinate values</param>
        /// <param name="ys">The array of y-coordinate values</param>
        /// <param name="count">The number of elements</param>
        /// <param name="flags">The ImGui behavior flags</param>
        public static void PlotStairs(string labelId, ref float xs, ref float ys, int count, ImPlotStairsFlags flags)
        {
            ImPlotNative.ImPlot_PlotStairs_FloatPtrFloatPtr(Encoding.UTF8.GetBytes(labelId), ref xs, ref ys, count, flags, 0, sizeof(float));
        }

        /// <summary>
        ///     Plots the stairs using the specified label id
        /// </summary>
        /// <param name="labelId">The label identifier for the plot item</param>
        /// <param name="xs">The array of x-coordinate values</param>
        /// <param name="ys">The array of y-coordinate values</param>
        /// <param name="count">The number of elements</param>
        /// <param name="flags">The ImGui behavior flags</param>
        /// <param name="offset">The offset from the origin</param>
        public static void PlotStairs(string labelId, ref float xs, ref float ys, int count, ImPlotStairsFlags flags, int offset)
        {
            ImPlotNative.ImPlot_PlotStairs_FloatPtrFloatPtr(Encoding.UTF8.GetBytes(labelId), ref xs, ref ys, count, flags, offset, sizeof(float));
        }

        /// <summary>
        ///     Plots the stairs using the specified label id
        /// </summary>
        /// <param name="labelId">The label identifier for the plot item</param>
        /// <param name="xs">The array of x-coordinate values</param>
        /// <param name="ys">The array of y-coordinate values</param>
        /// <param name="count">The number of elements</param>
        /// <param name="flags">The ImGui behavior flags</param>
        /// <param name="offset">The offset from the origin</param>
        /// <param name="stride">The byte stride between elements</param>
        public static void PlotStairs(string labelId, ref float xs, ref float ys, int count, ImPlotStairsFlags flags, int offset, int stride)
        {
            ImPlotNative.ImPlot_PlotStairs_FloatPtrFloatPtr(Encoding.UTF8.GetBytes(labelId), ref xs, ref ys, count, flags, offset, stride);
        }

        /// <summary>
        ///     Plots the stairs using the specified label id
        /// </summary>
        /// <param name="labelId">The label identifier for the plot item</param>
        /// <param name="xs">The array of x-coordinate values</param>
        /// <param name="ys">The array of y-coordinate values</param>
        /// <param name="count">The number of elements</param>
        public static void PlotStairs(string labelId, ref double xs, ref double ys, int count)
        {
            ImPlotNative.ImPlot_PlotStairs_doublePtrdoublePtr(Encoding.UTF8.GetBytes(labelId), ref xs, ref ys, count, 0, 0, sizeof(double));
        }

        /// <summary>
        ///     Plots the stairs using the specified label id
        /// </summary>
        /// <param name="labelId">The label identifier for the plot item</param>
        /// <param name="xs">The array of x-coordinate values</param>
        /// <param name="ys">The array of y-coordinate values</param>
        /// <param name="count">The number of elements</param>
        /// <param name="flags">The ImGui behavior flags</param>
        public static void PlotStairs(string labelId, ref double xs, ref double ys, int count, ImPlotStairsFlags flags)
        {
            ImPlotNative.ImPlot_PlotStairs_doublePtrdoublePtr(Encoding.UTF8.GetBytes(labelId), ref xs, ref ys, count, flags, 0, sizeof(double));
        }

        /// <summary>
        ///     Plots the stairs using the specified label id
        /// </summary>
        /// <param name="labelId">The label identifier for the plot item</param>
        /// <param name="xs">The array of x-coordinate values</param>
        /// <param name="ys">The array of y-coordinate values</param>
        /// <param name="count">The number of elements</param>
        /// <param name="flags">The ImGui behavior flags</param>
        /// <param name="offset">The offset from the origin</param>
        public static void PlotStairs(string labelId, ref double xs, ref double ys, int count, ImPlotStairsFlags flags, int offset)
        {
            ImPlotNative.ImPlot_PlotStairs_doublePtrdoublePtr(Encoding.UTF8.GetBytes(labelId), ref xs, ref ys, count, flags, offset, sizeof(double));
        }

        /// <summary>
        ///     Plots the stairs using the specified label id
        /// </summary>
        /// <param name="labelId">The label identifier for the plot item</param>
        /// <param name="xs">The array of x-coordinate values</param>
        /// <param name="ys">The array of y-coordinate values</param>
        /// <param name="count">The number of elements</param>
        /// <param name="flags">The ImGui behavior flags</param>
        /// <param name="offset">The offset from the origin</param>
        /// <param name="stride">The byte stride between elements</param>
        public static void PlotStairs(string labelId, ref double xs, ref double ys, int count, ImPlotStairsFlags flags, int offset, int stride)
        {
            ImPlotNative.ImPlot_PlotStairs_doublePtrdoublePtr(Encoding.UTF8.GetBytes(labelId), ref xs, ref ys, count, flags, offset, stride);
        }

        /// <summary>
        ///     Plots the stairs using the specified label id
        /// </summary>
        /// <param name="labelId">The label identifier for the plot item</param>
        /// <param name="xs">The array of x-coordinate values</param>
        /// <param name="ys">The array of y-coordinate values</param>
        /// <param name="count">The number of elements</param>
        public static void PlotStairs(string labelId, ref sbyte xs, ref sbyte ys, int count)
        {
            ImPlotNative.ImPlot_PlotStairs_S8PtrS8Ptr(Encoding.UTF8.GetBytes(labelId), ref xs, ref ys, count, 0, 0, sizeof(sbyte));
        }

        /// <summary>
        ///     Plots the stairs using the specified label id
        /// </summary>
        /// <param name="labelId">The label identifier for the plot item</param>
        /// <param name="xs">The array of x-coordinate values</param>
        /// <param name="ys">The array of y-coordinate values</param>
        /// <param name="count">The number of elements</param>
        /// <param name="flags">The ImGui behavior flags</param>
        public static void PlotStairs(string labelId, ref sbyte xs, ref sbyte ys, int count, ImPlotStairsFlags flags)
        {
            ImPlotNative.ImPlot_PlotStairs_S8PtrS8Ptr(Encoding.UTF8.GetBytes(labelId), ref xs, ref ys, count, flags, 0, sizeof(sbyte));
        }

        /// <summary>
        ///     Plots the stairs using the specified label id
        /// </summary>
        /// <param name="labelId">The label identifier for the plot item</param>
        /// <param name="xs">The array of x-coordinate values</param>
        /// <param name="ys">The array of y-coordinate values</param>
        /// <param name="count">The number of elements</param>
        /// <param name="flags">The ImGui behavior flags</param>
        /// <param name="offset">The offset from the origin</param>
        public static void PlotStairs(string labelId, ref sbyte xs, ref sbyte ys, int count, ImPlotStairsFlags flags, int offset)
        {
            ImPlotNative.ImPlot_PlotStairs_S8PtrS8Ptr(Encoding.UTF8.GetBytes(labelId), ref xs, ref ys, count, flags, offset, sizeof(sbyte));
        }

        /// <summary>
        ///     Plots the stairs using the specified label id
        /// </summary>
        /// <param name="labelId">The label identifier for the plot item</param>
        /// <param name="xs">The array of x-coordinate values</param>
        /// <param name="ys">The array of y-coordinate values</param>
        /// <param name="count">The number of elements</param>
        /// <param name="flags">The ImGui behavior flags</param>
        /// <param name="offset">The offset from the origin</param>
        /// <param name="stride">The byte stride between elements</param>
        public static void PlotStairs(string labelId, ref sbyte xs, ref sbyte ys, int count, ImPlotStairsFlags flags, int offset, int stride)
        {
            ImPlotNative.ImPlot_PlotStairs_S8PtrS8Ptr(Encoding.UTF8.GetBytes(labelId), ref xs, ref ys, count, flags, offset, stride);
        }

        /// <summary>
        ///     Plots the stairs using the specified label id
        /// </summary>
        /// <param name="labelId">The label identifier for the plot item</param>
        /// <param name="xs">The array of x-coordinate values</param>
        /// <param name="ys">The array of y-coordinate values</param>
        /// <param name="count">The number of elements</param>
        public static void PlotStairs(string labelId, ref byte xs, ref byte ys, int count)
        {
            ImPlotNative.ImPlot_PlotStairs_U8PtrU8Ptr(Encoding.UTF8.GetBytes(labelId), ref xs, ref ys, count, 0, 0, sizeof(byte));
        }

        /// <summary>
        ///     Plots the stairs using the specified label id
        /// </summary>
        /// <param name="labelId">The label identifier for the plot item</param>
        /// <param name="xs">The array of x-coordinate values</param>
        /// <param name="ys">The array of y-coordinate values</param>
        /// <param name="count">The number of elements</param>
        /// <param name="flags">The ImGui behavior flags</param>
        public static void PlotStairs(string labelId, ref byte xs, ref byte ys, int count, ImPlotStairsFlags flags)
        {
            ImPlotNative.ImPlot_PlotStairs_U8PtrU8Ptr(Encoding.UTF8.GetBytes(labelId), ref xs, ref ys, count, flags, 0, sizeof(byte));
        }

        /// <summary>
        ///     Plots the stairs using the specified label id
        /// </summary>
        /// <param name="labelId">The label identifier for the plot item</param>
        /// <param name="xs">The array of x-coordinate values</param>
        /// <param name="ys">The array of y-coordinate values</param>
        /// <param name="count">The number of elements</param>
        /// <param name="flags">The ImGui behavior flags</param>
        /// <param name="offset">The offset from the origin</param>
        public static void PlotStairs(string labelId, ref byte xs, ref byte ys, int count, ImPlotStairsFlags flags, int offset)
        {
            ImPlotNative.ImPlot_PlotStairs_U8PtrU8Ptr(Encoding.UTF8.GetBytes(labelId), ref xs, ref ys, count, flags, offset, sizeof(byte));
        }
    }
}