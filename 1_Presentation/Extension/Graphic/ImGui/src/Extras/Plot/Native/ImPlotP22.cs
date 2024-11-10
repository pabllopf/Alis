// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImPlotP22.cs
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

namespace Alis.Extension.Graphic.ImGui.Extras.Plot.Native
{
    /// <summary>
    ///     The im plot class
    /// </summary>
    public static partial class ImPlot
    {
        /// <summary>
        ///     Plots the line using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="xscale">The xscale</param>
        /// <param name="xstart">The xstart</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        /// <param name="stride">The stride</param>
        public static void PlotLine(string labelId, short[] values, int count, double xscale, double xstart, ImPlotLineFlags flags, int offset, int stride)
        {
            ImPlotNative.ImPlot_PlotLine_S16PtrInt(Encoding.UTF8.GetBytes(labelId), values, count, xscale, xstart, flags, offset, stride);
        }

        /// <summary>
        ///     Plots the line using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        public static void PlotLine(string labelId, ushort[] values, int count)
        {
            ImPlotNative.ImPlot_PlotLine_U16PtrInt(Encoding.UTF8.GetBytes(labelId), values, count, 1, 0, 0, 0, 0);
        }

        /// <summary>
        ///     Plots the line using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="xscale">The xscale</param>
        public static void PlotLine(string labelId, ushort[] values, int count, double xscale)
        {
            ImPlotNative.ImPlot_PlotLine_U16PtrInt(Encoding.UTF8.GetBytes(labelId), values, count, xscale, 0, 0, 0, 0);
        }

        /// <summary>
        ///     Plots the line using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="xscale">The xscale</param>
        /// <param name="xstart">The xstart</param>
        public static void PlotLine(string labelId, ushort[] values, int count, double xscale, double xstart)
        {
            ImPlotNative.ImPlot_PlotLine_U16PtrInt(Encoding.UTF8.GetBytes(labelId), values, count, xscale, xstart, 0, 0, 0);
        }

        /// <summary>
        ///     Plots the line using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="xscale">The xscale</param>
        /// <param name="xstart">The xstart</param>
        /// <param name="flags">The flags</param>
        public static void PlotLine(string labelId, ushort[] values, int count, double xscale, double xstart, ImPlotLineFlags flags)
        {
            ImPlotNative.ImPlot_PlotLine_U16PtrInt(Encoding.UTF8.GetBytes(labelId), values, count, xscale, xstart, flags, 0, 0);
        }

        /// <summary>
        ///     Plots the line using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="xscale">The xscale</param>
        /// <param name="xstart">The xstart</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        public static void PlotLine(string labelId, ushort[] values, int count, double xscale, double xstart, ImPlotLineFlags flags, int offset)
        {
            ImPlotNative.ImPlot_PlotLine_U16PtrInt(Encoding.UTF8.GetBytes(labelId), values, count, xscale, xstart, flags, offset, 0);
        }

        /// <summary>
        ///     Plots the line using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="xscale">The xscale</param>
        /// <param name="xstart">The xstart</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        /// <param name="stride">The stride</param>
        public static void PlotLine(string labelId, ushort[] values, int count, double xscale, double xstart, ImPlotLineFlags flags, int offset, int stride)
        {
            ImPlotNative.ImPlot_PlotLine_U16PtrInt(Encoding.UTF8.GetBytes(labelId), values, count, xscale, xstart, flags, offset, stride);
        }

        /// <summary>
        ///     Plots the line using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        public static void PlotLine(string labelId, int[] values, int count)
        {
            ImPlotNative.ImPlot_PlotLine_S32PtrInt(Encoding.UTF8.GetBytes(labelId), values, count, 1, 0, 0, 0, 0);
        }

        /// <summary>
        ///     Plots the line using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="xscale">The xscale</param>
        public static void PlotLine(string labelId, int[] values, int count, double xscale)
        {
            ImPlotNative.ImPlot_PlotLine_S32PtrInt(Encoding.UTF8.GetBytes(labelId), values, count, xscale, 0, 0, 0, 0);
        }

        /// <summary>
        ///     Plots the line using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="xscale">The xscale</param>
        /// <param name="xstart">The xstart</param>
        public static void PlotLine(string labelId, int[] values, int count, double xscale, double xstart)
        {
            ImPlotNative.ImPlot_PlotLine_S32PtrInt(Encoding.UTF8.GetBytes(labelId), values, count, xscale, xstart, 0, 0, 0);
        }

        /// <summary>
        ///     Plots the line using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="xscale">The xscale</param>
        /// <param name="xstart">The xstart</param>
        /// <param name="flags">The flags</param>
        public static void PlotLine(string labelId, int[] values, int count, double xscale, double xstart, ImPlotLineFlags flags)
        {
            ImPlotNative.ImPlot_PlotLine_S32PtrInt(Encoding.UTF8.GetBytes(labelId), values, count, xscale, xstart, flags, 0, 0);
        }

        /// <summary>
        ///     Plots the line using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="xscale">The xscale</param>
        /// <param name="xstart">The xstart</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        public static void PlotLine(string labelId, int[] values, int count, double xscale, double xstart, ImPlotLineFlags flags, int offset)
        {
            ImPlotNative.ImPlot_PlotLine_S32PtrInt(Encoding.UTF8.GetBytes(labelId), values, count, xscale, xstart, flags, offset, 0);
        }

        /// <summary>
        ///     Plots the line using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="xscale">The xscale</param>
        /// <param name="xstart">The xstart</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        /// <param name="stride">The stride</param>
        public static void PlotLine(string labelId, int[] values, int count, double xscale, double xstart, ImPlotLineFlags flags, int offset, int stride)
        {
            ImPlotNative.ImPlot_PlotLine_S32PtrInt(Encoding.UTF8.GetBytes(labelId), values, count, xscale, xstart, flags, offset, stride);
        }

        /// <summary>
        ///     Plots the line using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        public static void PlotLine(string labelId, uint[] values, int count)
        {
            ImPlotNative.ImPlot_PlotLine_U32PtrInt(Encoding.UTF8.GetBytes(labelId), values, count, 1, 0, 0, 0, 0);
        }

        /// <summary>
        ///     Plots the line using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="xscale">The xscale</param>
        public static void PlotLine(string labelId, uint[] values, int count, double xscale)
        {
            ImPlotNative.ImPlot_PlotLine_U32PtrInt(Encoding.UTF8.GetBytes(labelId), values, count, xscale, 0, 0, 0, 0);
        }

        /// <summary>
        ///     Plots the line using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="xscale">The xscale</param>
        /// <param name="xstart">The xstart</param>
        public static void PlotLine(string labelId, uint[] values, int count, double xscale, double xstart)
        {
            ImPlotNative.ImPlot_PlotLine_U32PtrInt(Encoding.UTF8.GetBytes(labelId), values, count, xscale, xstart, 0, 0, 0);
        }

        /// <summary>
        ///     Plots the line using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="xscale">The xscale</param>
        /// <param name="xstart">The xstart</param>
        /// <param name="flags">The flags</param>
        public static void PlotLine(string labelId, uint[] values, int count, double xscale, double xstart, ImPlotLineFlags flags)
        {
            ImPlotNative.ImPlot_PlotLine_U32PtrInt(Encoding.UTF8.GetBytes(labelId), values, count, xscale, xstart, flags, 0, 0);
        }

        /// <summary>
        ///     Plots the line using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="xscale">The xscale</param>
        /// <param name="xstart">The xstart</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        public static void PlotLine(string labelId, uint[] values, int count, double xscale, double xstart, ImPlotLineFlags flags, int offset)
        {
            ImPlotNative.ImPlot_PlotLine_U32PtrInt(Encoding.UTF8.GetBytes(labelId), values, count, xscale, xstart, flags, offset, 0);
        }

        /// <summary>
        ///     Plots the line using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="xscale">The xscale</param>
        /// <param name="xstart">The xstart</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        /// <param name="stride">The stride</param>
        public static void PlotLine(string labelId, uint[] values, int count, double xscale, double xstart, ImPlotLineFlags flags, int offset, int stride)
        {
            ImPlotNative.ImPlot_PlotLine_U32PtrInt(Encoding.UTF8.GetBytes(labelId), values, count, xscale, xstart, flags, offset, stride);
        }

        /// <summary>
        ///     Plots the line using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        public static void PlotLine(string labelId, long[] values, int count)
        {
            ImPlotNative.ImPlot_PlotLine_S64PtrInt(Encoding.UTF8.GetBytes(labelId), values, count, 1, 0, 0, 0, 0);
        }

        /// <summary>
        ///     Plots the line using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="xscale">The xscale</param>
        public static void PlotLine(string labelId, long[] values, int count, double xscale)
        {
            ImPlotNative.ImPlot_PlotLine_S64PtrInt(Encoding.UTF8.GetBytes(labelId), values, count, xscale, 0, 0, 0, 0);
        }

        /// <summary>
        ///     Plots the line using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="xscale">The xscale</param>
        /// <param name="xstart">The xstart</param>
        public static void PlotLine(string labelId, long[] values, int count, double xscale, double xstart)
        {
            ImPlotNative.ImPlot_PlotLine_S64PtrInt(Encoding.UTF8.GetBytes(labelId), values, count, xscale, xstart, 0, 0, 0);
        }

        /// <summary>
        ///     Plots the line using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="xscale">The xscale</param>
        /// <param name="xstart">The xstart</param>
        /// <param name="flags">The flags</param>
        public static void PlotLine(string labelId, long[] values, int count, double xscale, double xstart, ImPlotLineFlags flags)
        {
            ImPlotNative.ImPlot_PlotLine_S64PtrInt(Encoding.UTF8.GetBytes(labelId), values, count, xscale, xstart, flags, 0, 0);
        }

        /// <summary>
        ///     Plots the line using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="xscale">The xscale</param>
        /// <param name="xstart">The xstart</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        public static void PlotLine(string labelId, long[] values, int count, double xscale, double xstart, ImPlotLineFlags flags, int offset)
        {
            ImPlotNative.ImPlot_PlotLine_S64PtrInt(Encoding.UTF8.GetBytes(labelId), values, count, xscale, xstart, flags, offset, 0);
        }

        /// <summary>
        ///     Plots the line using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="xscale">The xscale</param>
        /// <param name="xstart">The xstart</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        /// <param name="stride">The stride</param>
        public static void PlotLine(string labelId, long[] values, int count, double xscale, double xstart, ImPlotLineFlags flags, int offset, int stride)
        {
            ImPlotNative.ImPlot_PlotLine_S64PtrInt(Encoding.UTF8.GetBytes(labelId), values, count, xscale, xstart, flags, offset, stride);
        }

        /// <summary>
        ///     Plots the line using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        public static void PlotLine(string labelId, ulong[] values, int count)
        {
            ImPlotNative.ImPlot_PlotLine_U64PtrInt(Encoding.UTF8.GetBytes(labelId), values, count, 1, 0, 0, 0, 0);
        }

        /// <summary>
        ///     Plots the line using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="xscale">The xscale</param>
        public static void PlotLine(string labelId, ulong[] values, int count, double xscale)
        {
            ImPlotNative.ImPlot_PlotLine_U64PtrInt(Encoding.UTF8.GetBytes(labelId), values, count, xscale, 0, 0, 0, 0);
        }

        /// <summary>
        ///     Plots the line using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="xscale">The xscale</param>
        /// <param name="xstart">The xstart</param>
        public static void PlotLine(string labelId, ulong[] values, int count, double xscale, double xstart)
        {
            ImPlotNative.ImPlot_PlotLine_U64PtrInt(Encoding.UTF8.GetBytes(labelId), values, count, xscale, xstart, 0, 0, 0);
        }

        /// <summary>
        ///     Plots the line using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="xscale">The xscale</param>
        /// <param name="xstart">The xstart</param>
        /// <param name="flags">The flags</param>
        public static void PlotLine(string labelId, ulong[] values, int count, double xscale, double xstart, ImPlotLineFlags flags)
        {
            ImPlotNative.ImPlot_PlotLine_U64PtrInt(Encoding.UTF8.GetBytes(labelId), values, count, xscale, xstart, flags, 0, 0);
        }

        /// <summary>
        ///     Plots the line using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="xscale">The xscale</param>
        /// <param name="xstart">The xstart</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        public static void PlotLine(string labelId, ulong[] values, int count, double xscale, double xstart, ImPlotLineFlags flags, int offset)
        {
            ImPlotNative.ImPlot_PlotLine_U64PtrInt(Encoding.UTF8.GetBytes(labelId), values, count, xscale, xstart, flags, offset, 0);
        }

        /// <summary>
        ///     Plots the line using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="xscale">The xscale</param>
        /// <param name="xstart">The xstart</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        /// <param name="stride">The stride</param>
        public static void PlotLine(string labelId, ulong[] values, int count, double xscale, double xstart, ImPlotLineFlags flags, int offset, int stride)
        {
            ImPlotNative.ImPlot_PlotLine_U64PtrInt(Encoding.UTF8.GetBytes(labelId), values, count, xscale, xstart, flags, offset, stride);
        }

        /// <summary>
        ///     Plots the line using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="count">The count</param>
        public static void PlotLine(string labelId, ref float xs, ref float ys, int count)
        {
            ImPlotNative.ImPlot_PlotLine_FloatPtrFloatPtr(Encoding.UTF8.GetBytes(labelId), ref xs, ref ys, count, 0, 0, sizeof(float));
        }

        /// <summary>
        ///     Plots the line using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="count">The count</param>
        /// <param name="flags">The flags</param>
        public static void PlotLine(string labelId, ref float xs, ref float ys, int count, ImPlotLineFlags flags)
        {
            ImPlotNative.ImPlot_PlotLine_FloatPtrFloatPtr(Encoding.UTF8.GetBytes(labelId), ref xs, ref ys, count, flags, 0, sizeof(float));
        }

        /// <summary>
        ///     Plots the line using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="count">The count</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        public static void PlotLine(string labelId, ref float xs, ref float ys, int count, ImPlotLineFlags flags, int offset)
        {
            ImPlotNative.ImPlot_PlotLine_FloatPtrFloatPtr(Encoding.UTF8.GetBytes(labelId), ref xs, ref ys, count, flags, offset, sizeof(float));
        }

        /// <summary>
        ///     Plots the line using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="count">The count</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        /// <param name="stride">The stride</param>
        public static void PlotLine(string labelId, ref float xs, ref float ys, int count, ImPlotLineFlags flags, int offset, int stride)
        {
            ImPlotNative.ImPlot_PlotLine_FloatPtrFloatPtr(Encoding.UTF8.GetBytes(labelId), ref xs, ref ys, count, flags, offset, stride);
        }

        /// <summary>
        ///     Plots the line using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="count">The count</param>
        public static void PlotLine(string labelId, ref double xs, ref double ys, int count)
        {
            ImPlotNative.ImPlot_PlotLine_doublePtrdoublePtr(Encoding.UTF8.GetBytes(labelId), ref xs, ref ys, count, 0, 0, sizeof(double));
        }

        /// <summary>
        ///     Plots the line using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="count">The count</param>
        /// <param name="flags">The flags</param>
        public static void PlotLine(string labelId, ref double xs, ref double ys, int count, ImPlotLineFlags flags)
        {
            ImPlotNative.ImPlot_PlotLine_doublePtrdoublePtr(Encoding.UTF8.GetBytes(labelId), ref xs, ref ys, count, flags, 0, sizeof(double));
        }

        /// <summary>
        ///     Plots the line using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="count">The count</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        public static void PlotLine(string labelId, ref double xs, ref double ys, int count, ImPlotLineFlags flags, int offset)
        {
            ImPlotNative.ImPlot_PlotLine_doublePtrdoublePtr(Encoding.UTF8.GetBytes(labelId), ref xs, ref ys, count, flags, offset, sizeof(double));
        }

        /// <summary>
        ///     Plots the line using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="count">The count</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        /// <param name="stride">The stride</param>
        public static void PlotLine(string labelId, ref double xs, ref double ys, int count, ImPlotLineFlags flags, int offset, int stride)
        {
            ImPlotNative.ImPlot_PlotLine_doublePtrdoublePtr(Encoding.UTF8.GetBytes(labelId), ref xs, ref ys, count, flags, offset, stride);
        }

        /// <summary>
        ///     Plots the line using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="count">The count</param>
        public static void PlotLine(string labelId, ref sbyte xs, ref sbyte ys, int count)
        {
            ImPlotNative.ImPlot_PlotLine_S8PtrS8Ptr(Encoding.UTF8.GetBytes(labelId), ref xs, ref ys, count, 0, 0, sizeof(sbyte));
        }

        /// <summary>
        ///     Plots the line using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="count">The count</param>
        /// <param name="flags">The flags</param>
        public static void PlotLine(string labelId, ref sbyte xs, ref sbyte ys, int count, ImPlotLineFlags flags)
        {
            ImPlotNative.ImPlot_PlotLine_S8PtrS8Ptr(Encoding.UTF8.GetBytes(labelId), ref xs, ref ys, count, flags, 0, sizeof(sbyte));
        }

        /// <summary>
        ///     Plots the line using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="count">The count</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        public static void PlotLine(string labelId, ref sbyte xs, ref sbyte ys, int count, ImPlotLineFlags flags, int offset)
        {
            ImPlotNative.ImPlot_PlotLine_S8PtrS8Ptr(Encoding.UTF8.GetBytes(labelId), ref xs, ref ys, count, flags, offset, sizeof(sbyte));
        }

        /// <summary>
        ///     Plots the line using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="count">The count</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        /// <param name="stride">The stride</param>
        public static void PlotLine(string labelId, ref sbyte xs, ref sbyte ys, int count, ImPlotLineFlags flags, int offset, int stride)
        {
            ImPlotNative.ImPlot_PlotLine_S8PtrS8Ptr(Encoding.UTF8.GetBytes(labelId), ref xs, ref ys, count, flags, offset, stride);
        }

        /// <summary>
        ///     Plots the line using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="count">The count</param>
        public static void PlotLine(string labelId, ref byte xs, ref byte ys, int count)
        {
            ImPlotNative.ImPlot_PlotLine_U8PtrU8Ptr(Encoding.UTF8.GetBytes(labelId), ref xs, ref ys, count, 0, 0, sizeof(byte));
        }

        /// <summary>
        ///     Plots the line using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="count">The count</param>
        /// <param name="flags">The flags</param>
        public static void PlotLine(string labelId, ref byte xs, ref byte ys, int count, ImPlotLineFlags flags)
        {
            ImPlotNative.ImPlot_PlotLine_U8PtrU8Ptr(Encoding.UTF8.GetBytes(labelId), ref xs, ref ys, count, flags, 0, sizeof(byte));
        }

        /// <summary>
        ///     Plots the line using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="count">The count</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        public static void PlotLine(string labelId, ref byte xs, ref byte ys, int count, ImPlotLineFlags flags, int offset)
        {
            ImPlotNative.ImPlot_PlotLine_U8PtrU8Ptr(Encoding.UTF8.GetBytes(labelId), ref xs, ref ys, count, flags, offset, sizeof(byte));
        }

        /// <summary>
        ///     Plots the line using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="count">The count</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        /// <param name="stride">The stride</param>
        public static void PlotLine(string labelId, ref byte xs, ref byte ys, int count, ImPlotLineFlags flags, int offset, int stride)
        {
            ImPlotNative.ImPlot_PlotLine_U8PtrU8Ptr(Encoding.UTF8.GetBytes(labelId), ref xs, ref ys, count, flags, offset, stride);
        }

        /// <summary>
        ///     Plots the line using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="count">The count</param>
        public static void PlotLine(string labelId, ref short xs, ref short ys, int count)
        {
            ImPlotNative.ImPlot_PlotLine_S16PtrS16Ptr(Encoding.UTF8.GetBytes(labelId), xs, ys, count, 0, 0, sizeof(short));
        }

        /// <summary>
        ///     Plots the line using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="count">The count</param>
        /// <param name="flags">The flags</param>
        public static void PlotLine(string labelId, ref short xs, ref short ys, int count, ImPlotLineFlags flags)
        {
            ImPlotNative.ImPlot_PlotLine_S16PtrS16Ptr(Encoding.UTF8.GetBytes(labelId), xs, ys, count, flags, 0, sizeof(short));
        }

        /// <summary>
        ///     Plots the line using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="count">The count</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        public static void PlotLine(string labelId, ref short xs, ref short ys, int count, ImPlotLineFlags flags, int offset)
        {
            ImPlotNative.ImPlot_PlotLine_S16PtrS16Ptr(Encoding.UTF8.GetBytes(labelId), xs, ys, count, flags, offset, sizeof(short));
        }

        /// <summary>
        ///     Plots the line using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="count">The count</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        /// <param name="stride">The stride</param>
        public static void PlotLine(string labelId, ref short xs, ref short ys, int count, ImPlotLineFlags flags, int offset, int stride)
        {
            ImPlotNative.ImPlot_PlotLine_S16PtrS16Ptr(Encoding.UTF8.GetBytes(labelId), xs, ys, count, flags, offset, stride);
        }

        /// <summary>
        ///     Plots the line using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="count">The count</param>
        public static void PlotLine(string labelId, ref ushort xs, ref ushort ys, int count)
        {
            ImPlotNative.ImPlot_PlotLine_U16PtrU16Ptr(Encoding.UTF8.GetBytes(labelId), ref xs, ref ys, count, 0, 0, sizeof(ushort));
        }

        /// <summary>
        ///     Plots the line using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="count">The count</param>
        /// <param name="flags">The flags</param>
        public static void PlotLine(string labelId, ref ushort xs, ref ushort ys, int count, ImPlotLineFlags flags)
        {
            ImPlotNative.ImPlot_PlotLine_U16PtrU16Ptr(Encoding.UTF8.GetBytes(labelId), ref xs, ref ys, count, flags, 0, sizeof(ushort));
        }

        /// <summary>
        ///     Plots the line using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="count">The count</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        public static void PlotLine(string labelId, ref ushort xs, ref ushort ys, int count, ImPlotLineFlags flags, int offset)
        {
            ImPlotNative.ImPlot_PlotLine_U16PtrU16Ptr(Encoding.UTF8.GetBytes(labelId), ref xs, ref ys, count, flags, offset, sizeof(ushort));
        }

        /// <summary>
        ///     Plots the line using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="count">The count</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        /// <param name="stride">The stride</param>
        public static void PlotLine(string labelId, ref ushort xs, ref ushort ys, int count, ImPlotLineFlags flags, int offset, int stride)
        {
            ImPlotNative.ImPlot_PlotLine_U16PtrU16Ptr(Encoding.UTF8.GetBytes(labelId), ref xs, ref ys, count, flags, offset, stride);
        }
    }
}