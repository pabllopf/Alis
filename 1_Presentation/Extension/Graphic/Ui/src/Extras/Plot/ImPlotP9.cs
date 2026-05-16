// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImPlotP9.cs
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

namespace Alis.Extension.Graphic.Ui.Extras.Plot
{
    /// <summary>
    ///     Provides managed wrappers over the CImPlot native library for creating and interacting with ImPlot plots.
    /// </summary>
    public static partial class ImPlot
    {
        /// <summary>
        ///     Plots the line using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="count">The number of elements</param>
        public static void PlotLine(string labelId, ref int xs, ref int ys, int count)
        {
            ImPlotNative.ImPlot_PlotLine_S32PtrS32Ptr(Encoding.UTF8.GetBytes(labelId), xs, ys, count, 0, 0, sizeof(int));
        }

        /// <summary>
        ///     Plots the line using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="count">The number of elements</param>
        /// <param name="flags">The ImGui behavior flags</param>
        public static void PlotLine(string labelId, ref int xs, ref int ys, int count, ImPlotLineFlags flags)
        {
            ImPlotNative.ImPlot_PlotLine_S32PtrS32Ptr(Encoding.UTF8.GetBytes(labelId), xs, ys, count, flags, 0, sizeof(int));
        }

        /// <summary>
        ///     Plots the line using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="count">The number of elements</param>
        /// <param name="flags">The ImGui behavior flags</param>
        /// <param name="offset">The offset from the origin</param>
        public static void PlotLine(string labelId, ref int xs, ref int ys, int count, ImPlotLineFlags flags, int offset)
        {
            ImPlotNative.ImPlot_PlotLine_S32PtrS32Ptr(Encoding.UTF8.GetBytes(labelId), xs, ys, count, flags, offset, sizeof(int));
        }

        /// <summary>
        ///     Plots the line using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="count">The number of elements</param>
        /// <param name="flags">The ImGui behavior flags</param>
        /// <param name="offset">The offset from the origin</param>
        /// <param name="stride">The byte stride between elements</param>
        public static void PlotLine(string labelId, ref int xs, ref int ys, int count, ImPlotLineFlags flags, int offset, int stride)
        {
            ImPlotNative.ImPlot_PlotLine_S32PtrS32Ptr(Encoding.UTF8.GetBytes(labelId), xs, ys, count, flags, offset, stride);
        }

        /// <summary>
        ///     Plots the line using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="count">The number of elements</param>
        public static void PlotLine(string labelId, ref uint xs, ref uint ys, int count)
        {
            ImPlotNative.ImPlot_PlotLine_U32PtrU32Ptr(Encoding.UTF8.GetBytes(labelId), xs, ys, count, 0, 0, sizeof(uint));
        }

        /// <summary>
        ///     Plots the line using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="count">The number of elements</param>
        /// <param name="flags">The ImGui behavior flags</param>
        public static void PlotLine(string labelId, ref uint xs, ref uint ys, int count, ImPlotLineFlags flags)
        {
            ImPlotNative.ImPlot_PlotLine_U32PtrU32Ptr(Encoding.UTF8.GetBytes(labelId), xs, ys, count, flags, 0, sizeof(uint));
        }

        /// <summary>
        ///     Plots the line using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="count">The number of elements</param>
        /// <param name="flags">The ImGui behavior flags</param>
        /// <param name="offset">The offset from the origin</param>
        public static void PlotLine(string labelId, ref uint xs, ref uint ys, int count, ImPlotLineFlags flags, int offset)
        {
            ImPlotNative.ImPlot_PlotLine_U32PtrU32Ptr(Encoding.UTF8.GetBytes(labelId), xs, ys, count, flags, offset, sizeof(uint));
        }

        /// <summary>
        ///     Plots the line using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="count">The number of elements</param>
        /// <param name="flags">The ImGui behavior flags</param>
        /// <param name="offset">The offset from the origin</param>
        /// <param name="stride">The byte stride between elements</param>
        public static void PlotLine(string labelId, ref uint xs, ref uint ys, int count, ImPlotLineFlags flags, int offset, int stride)
        {
            ImPlotNative.ImPlot_PlotLine_U32PtrU32Ptr(Encoding.UTF8.GetBytes(labelId), xs, ys, count, flags, offset, stride);
        }

        /// <summary>
        ///     Plots the line using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="count">The number of elements</param>
        public static void PlotLine(string labelId, ref long xs, ref long ys, int count)
        {
            ImPlotNative.ImPlot_PlotLine_S64PtrS64Ptr(Encoding.UTF8.GetBytes(labelId), ref xs, ref ys, count, 0, 0, sizeof(long));
        }

        /// <summary>
        ///     Plots the line using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="count">The number of elements</param>
        /// <param name="flags">The ImGui behavior flags</param>
        public static void PlotLine(string labelId, ref long xs, ref long ys, int count, ImPlotLineFlags flags)
        {
            ImPlotNative.ImPlot_PlotLine_S64PtrS64Ptr(Encoding.UTF8.GetBytes(labelId), ref xs, ref ys, count, flags, 0, sizeof(long));
        }

        /// <summary>
        ///     Plots the line using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="count">The number of elements</param>
        /// <param name="flags">The ImGui behavior flags</param>
        /// <param name="offset">The offset from the origin</param>
        public static void PlotLine(string labelId, ref long xs, ref long ys, int count, ImPlotLineFlags flags, int offset)
        {
            ImPlotNative.ImPlot_PlotLine_S64PtrS64Ptr(Encoding.UTF8.GetBytes(labelId), ref xs, ref ys, count, flags, offset, sizeof(long));
        }

        /// <summary>
        ///     Plots the line using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="count">The number of elements</param>
        /// <param name="flags">The ImGui behavior flags</param>
        /// <param name="offset">The offset from the origin</param>
        /// <param name="stride">The byte stride between elements</param>
        public static void PlotLine(string labelId, ref long xs, ref long ys, int count, ImPlotLineFlags flags, int offset, int stride)
        {
            ImPlotNative.ImPlot_PlotLine_S64PtrS64Ptr(Encoding.UTF8.GetBytes(labelId), ref xs, ref ys, count, flags, offset, stride);
        }

        /// <summary>
        ///     Plots the line using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="count">The number of elements</param>
        public static void PlotLine(string labelId, ref ulong xs, ref ulong ys, int count)
        {
            ImPlotNative.ImPlot_PlotLine_U64PtrU64Ptr(Encoding.UTF8.GetBytes(labelId), ref xs, ref ys, count, 0, 0, sizeof(ulong));
        }

        /// <summary>
        ///     Plots the line using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="count">The number of elements</param>
        /// <param name="flags">The ImGui behavior flags</param>
        public static void PlotLine(string labelId, ref ulong xs, ref ulong ys, int count, ImPlotLineFlags flags)
        {
            ImPlotNative.ImPlot_PlotLine_U64PtrU64Ptr(Encoding.UTF8.GetBytes(labelId), ref xs, ref ys, count, flags, 0, sizeof(ulong));
        }

        /// <summary>
        ///     Plots the line using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="count">The number of elements</param>
        /// <param name="flags">The ImGui behavior flags</param>
        /// <param name="offset">The offset from the origin</param>
        public static void PlotLine(string labelId, ref ulong xs, ref ulong ys, int count, ImPlotLineFlags flags, int offset)
        {
            ImPlotNative.ImPlot_PlotLine_U64PtrU64Ptr(Encoding.UTF8.GetBytes(labelId), ref xs, ref ys, count, flags, offset, sizeof(ulong));
        }

        /// <summary>
        ///     Plots the line using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="count">The number of elements</param>
        /// <param name="flags">The ImGui behavior flags</param>
        /// <param name="offset">The offset from the origin</param>
        /// <param name="stride">The byte stride between elements</param>
        public static void PlotLine(string labelId, ref ulong xs, ref ulong ys, int count, ImPlotLineFlags flags, int offset, int stride)
        {
            ImPlotNative.ImPlot_PlotLine_U64PtrU64Ptr(Encoding.UTF8.GetBytes(labelId), ref xs, ref ys, count, flags, offset, stride);
        }

        /// <summary>
        ///     Plots the line g using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="getter">The getter</param>
        /// <param name="data">The data buffer content</param>
        /// <param name="count">The number of elements</param>
        public static void PlotLineG(string labelId, IntPtr getter, IntPtr data, int count)
        {
            ImPlotNative.ImPlot_PlotLineG(Encoding.UTF8.GetBytes(labelId), getter, data, count, 0);
        }

        /// <summary>
        ///     Plots the line g using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="getter">The getter</param>
        /// <param name="data">The data buffer content</param>
        /// <param name="count">The number of elements</param>
        /// <param name="flags">The ImGui behavior flags</param>
        public static void PlotLineG(string labelId, IntPtr getter, IntPtr data, int count, ImPlotLineFlags flags)
        {
            ImPlotNative.ImPlot_PlotLineG(Encoding.UTF8.GetBytes(labelId), getter, data, count, flags);
        }

        /// <summary>
        ///     Plots the pie chart using the specified label ids
        /// </summary>
        /// <param name="labelIds">The label ids</param>
        /// <param name="values">The values</param>
        /// <param name="count">The number of elements</param>
        /// <param name="x">The x-coordinate</param>
        /// <param name="y">The y-coordinate</param>
        /// <param name="radius">The radius of the shape</param>
        public static void PlotPieChart(string[] labelIds, float[] values, int count, double x, double y, double radius)
        {
            byte[][] nativeLabelIds = new byte[labelIds.Length][];
            for (int i = 0; i < labelIds.Length; i++)
            {
                nativeLabelIds[i] = Encoding.UTF8.GetBytes(labelIds[i]);
            }

            ImPlotNative.ImPlot_PlotPieChart_FloatPtr(nativeLabelIds, values, count, x, y, radius, null, 90, 0);
        }

        /// <summary>
        ///     Plots the pie chart using the specified label ids
        /// </summary>
        /// <param name="labelIds">The label ids</param>
        /// <param name="values">The values</param>
        /// <param name="count">The number of elements</param>
        /// <param name="x">The x-coordinate</param>
        /// <param name="y">The y-coordinate</param>
        /// <param name="radius">The radius of the shape</param>
        /// <param name="labelFmt">The label fmt</param>
        public static void PlotPieChart(string[] labelIds, float[] values, int count, double x, double y, double radius, string labelFmt)
        {
            byte[][] nativeLabelIds = new byte[labelIds.Length][];
            for (int i = 0; i < labelIds.Length; i++)
            {
                nativeLabelIds[i] = Encoding.UTF8.GetBytes(labelIds[i]);
            }

            ImPlotNative.ImPlot_PlotPieChart_FloatPtr(nativeLabelIds, values, count, x, y, radius, Encoding.UTF8.GetBytes(labelFmt), 90, 0);
        }

        /// <summary>
        ///     Plots the pie chart using the specified label ids
        /// </summary>
        /// <param name="labelIds">The label ids</param>
        /// <param name="values">The values</param>
        /// <param name="count">The number of elements</param>
        /// <param name="x">The x-coordinate</param>
        /// <param name="y">The y-coordinate</param>
        /// <param name="radius">The radius of the shape</param>
        /// <param name="labelFmt">The label fmt</param>
        /// <param name="angle0">The angle</param>
        public static void PlotPieChart(string[] labelIds, float[] values, int count, double x, double y, double radius, string labelFmt, double angle0)
        {
            byte[][] nativeLabelIds = new byte[labelIds.Length][];
            for (int i = 0; i < labelIds.Length; i++)
            {
                nativeLabelIds[i] = Encoding.UTF8.GetBytes(labelIds[i]);
            }

            ImPlotNative.ImPlot_PlotPieChart_FloatPtr(nativeLabelIds, values, count, x, y, radius, Encoding.UTF8.GetBytes(labelFmt), angle0, 0);
        }

        /// <summary>
        ///     Plots the pie chart using the specified label ids
        /// </summary>
        /// <param name="labelIds">The label ids</param>
        /// <param name="values">The values</param>
        /// <param name="count">The number of elements</param>
        /// <param name="x">The x-coordinate</param>
        /// <param name="y">The y-coordinate</param>
        /// <param name="radius">The radius of the shape</param>
        /// <param name="labelFmt">The label fmt</param>
        /// <param name="angle0">The angle</param>
        /// <param name="flags">The ImGui behavior flags</param>
        public static void PlotPieChart(string[] labelIds, float[] values, int count, double x, double y, double radius, string labelFmt, double angle0, ImPlotPieChartFlags flags)
        {
            byte[][] nativeLabelIds = new byte[labelIds.Length][];
            for (int i = 0; i < labelIds.Length; i++)
            {
                nativeLabelIds[i] = Encoding.UTF8.GetBytes(labelIds[i]);
            }

            ImPlotNative.ImPlot_PlotPieChart_FloatPtr(nativeLabelIds, values, count, x, y, radius, Encoding.UTF8.GetBytes(labelFmt), angle0, flags);
        }

        /// <summary>
        ///     Plots the pie chart using the specified label ids
        /// </summary>
        /// <param name="labelIds">The label ids</param>
        /// <param name="values">The values</param>
        /// <param name="count">The number of elements</param>
        /// <param name="x">The x-coordinate</param>
        /// <param name="y">The y-coordinate</param>
        /// <param name="radius">The radius of the shape</param>
        public static void PlotPieChart(string[] labelIds, double[] values, int count, double x, double y, double radius)
        {
            byte[][] nativeLabelIds = new byte[labelIds.Length][];
            for (int i = 0; i < labelIds.Length; i++)
            {
                nativeLabelIds[i] = Encoding.UTF8.GetBytes(labelIds[i]);
            }

            ImPlotNative.ImPlot_PlotPieChart_doublePtr(nativeLabelIds, values, count, x, y, radius, null, 90, 0);
        }

        /// <summary>
        ///     Plots the pie chart using the specified label ids
        /// </summary>
        /// <param name="labelIds">The label ids</param>
        /// <param name="values">The values</param>
        /// <param name="count">The number of elements</param>
        /// <param name="x">The x-coordinate</param>
        /// <param name="y">The y-coordinate</param>
        /// <param name="radius">The radius of the shape</param>
        /// <param name="labelFmt">The label fmt</param>
        public static void PlotPieChart(string[] labelIds, double[] values, int count, double x, double y, double radius, string labelFmt)
        {
            byte[][] nativeLabelIds = new byte[labelIds.Length][];
            for (int i = 0; i < labelIds.Length; i++)
            {
                nativeLabelIds[i] = Encoding.UTF8.GetBytes(labelIds[i]);
            }

            ImPlotNative.ImPlot_PlotPieChart_doublePtr(nativeLabelIds, values, count, x, y, radius, Encoding.UTF8.GetBytes(labelFmt), 90, 0);
        }

        /// <summary>
        ///     Plots the pie chart using the specified label ids
        /// </summary>
        /// <param name="labelIds">The label ids</param>
        /// <param name="values">The values</param>
        /// <param name="count">The number of elements</param>
        /// <param name="x">The x-coordinate</param>
        /// <param name="y">The y-coordinate</param>
        /// <param name="radius">The radius of the shape</param>
        /// <param name="labelFmt">The label fmt</param>
        /// <param name="angle0">The angle</param>
        public static void PlotPieChart(string[] labelIds, double[] values, int count, double x, double y, double radius, string labelFmt, double angle0)
        {
            byte[][] nativeLabelIds = new byte[labelIds.Length][];
            for (int i = 0; i < labelIds.Length; i++)
            {
                nativeLabelIds[i] = Encoding.UTF8.GetBytes(labelIds[i]);
            }

            ImPlotNative.ImPlot_PlotPieChart_doublePtr(nativeLabelIds, values, count, x, y, radius, Encoding.UTF8.GetBytes(labelFmt), angle0, 0);
        }

        /// <summary>
        ///     Plots the pie chart using the specified label ids
        /// </summary>
        /// <param name="labelIds">The label ids</param>
        /// <param name="values">The values</param>
        /// <param name="count">The number of elements</param>
        /// <param name="x">The x-coordinate</param>
        /// <param name="y">The y-coordinate</param>
        /// <param name="radius">The radius of the shape</param>
        /// <param name="labelFmt">The label fmt</param>
        /// <param name="angle0">The angle</param>
        /// <param name="flags">The ImGui behavior flags</param>
        public static void PlotPieChart(string[] labelIds, double[] values, int count, double x, double y, double radius, string labelFmt, double angle0, ImPlotPieChartFlags flags)
        {
            byte[][] nativeLabelIds = new byte[labelIds.Length][];
            for (int i = 0; i < labelIds.Length; i++)
            {
                nativeLabelIds[i] = Encoding.UTF8.GetBytes(labelIds[i]);
            }

            ImPlotNative.ImPlot_PlotPieChart_doublePtr(nativeLabelIds, values, count, x, y, radius, Encoding.UTF8.GetBytes(labelFmt), angle0, flags);
        }

        /// <summary>
        ///     Plots the pie chart using the specified label ids
        /// </summary>
        /// <param name="labelIds">The label ids</param>
        /// <param name="values">The values</param>
        /// <param name="count">The number of elements</param>
        /// <param name="x">The x-coordinate</param>
        /// <param name="y">The y-coordinate</param>
        /// <param name="radius">The radius of the shape</param>
        public static void PlotPieChart(string[] labelIds, sbyte[] values, int count, double x, double y, double radius)
        {
            byte[][] nativeLabelIds = new byte[labelIds.Length][];
            for (int i = 0; i < labelIds.Length; i++)
            {
                nativeLabelIds[i] = Encoding.UTF8.GetBytes(labelIds[i]);
            }

            ImPlotNative.ImPlot_PlotPieChart_S8Ptr(nativeLabelIds, values, count, x, y, radius, null, 90, 0);
        }

        /// <summary>
        ///     Plots the pie chart using the specified label ids
        /// </summary>
        /// <param name="labelIds">The label ids</param>
        /// <param name="values">The values</param>
        /// <param name="count">The number of elements</param>
        /// <param name="x">The x-coordinate</param>
        /// <param name="y">The y-coordinate</param>
        /// <param name="radius">The radius of the shape</param>
        /// <param name="labelFmt">The label fmt</param>
        public static void PlotPieChart(string[] labelIds, sbyte[] values, int count, double x, double y, double radius, string labelFmt)
        {
            byte[][] nativeLabelIds = new byte[labelIds.Length][];
            for (int i = 0; i < labelIds.Length; i++)
            {
                nativeLabelIds[i] = Encoding.UTF8.GetBytes(labelIds[i]);
            }

            ImPlotNative.ImPlot_PlotPieChart_S8Ptr(nativeLabelIds, values, count, x, y, radius, Encoding.UTF8.GetBytes(labelFmt), 90, 0);
        }

        /// <summary>
        ///     Plots the pie chart using the specified label ids
        /// </summary>
        /// <param name="labelIds">The label ids</param>
        /// <param name="values">The values</param>
        /// <param name="count">The number of elements</param>
        /// <param name="x">The x-coordinate</param>
        /// <param name="y">The y-coordinate</param>
        /// <param name="radius">The radius of the shape</param>
        /// <param name="labelFmt">The label fmt</param>
        /// <param name="angle0">The angle</param>
        public static void PlotPieChart(string[] labelIds, sbyte[] values, int count, double x, double y, double radius, string labelFmt, double angle0)
        {
            byte[][] nativeLabelIds = new byte[labelIds.Length][];
            for (int i = 0; i < labelIds.Length; i++)
            {
                nativeLabelIds[i] = Encoding.UTF8.GetBytes(labelIds[i]);
            }

            ImPlotNative.ImPlot_PlotPieChart_S8Ptr(nativeLabelIds, values, count, x, y, radius, Encoding.UTF8.GetBytes(labelFmt), angle0, 0);
        }

        /// <summary>
        ///     Plots the pie chart using the specified label ids
        /// </summary>
        /// <param name="labelIds">The label ids</param>
        /// <param name="values">The values</param>
        /// <param name="count">The number of elements</param>
        /// <param name="x">The x-coordinate</param>
        /// <param name="y">The y-coordinate</param>
        /// <param name="radius">The radius of the shape</param>
        /// <param name="labelFmt">The label fmt</param>
        /// <param name="angle0">The angle</param>
        /// <param name="flags">The ImGui behavior flags</param>
        public static void PlotPieChart(string[] labelIds, sbyte[] values, int count, double x, double y, double radius, string labelFmt, double angle0, ImPlotPieChartFlags flags)
        {
            byte[][] nativeLabelIds = new byte[labelIds.Length][];
            for (int i = 0; i < labelIds.Length; i++)
            {
                nativeLabelIds[i] = Encoding.UTF8.GetBytes(labelIds[i]);
            }

            ImPlotNative.ImPlot_PlotPieChart_S8Ptr(nativeLabelIds, values, count, x, y, radius, Encoding.UTF8.GetBytes(labelFmt), angle0, flags);
        }

        /// <summary>
        ///     Plots the pie chart using the specified label ids
        /// </summary>
        /// <param name="labelIds">The label ids</param>
        /// <param name="values">The values</param>
        /// <param name="count">The number of elements</param>
        /// <param name="x">The x-coordinate</param>
        /// <param name="y">The y-coordinate</param>
        /// <param name="radius">The radius of the shape</param>
        public static void PlotPieChart(string[] labelIds, byte[] values, int count, double x, double y, double radius)
        {
            byte[][] nativeLabelIds = new byte[labelIds.Length][];
            for (int i = 0; i < labelIds.Length; i++)
            {
                nativeLabelIds[i] = Encoding.UTF8.GetBytes(labelIds[i]);
            }

            ImPlotNative.ImPlot_PlotPieChart_U8Ptr(nativeLabelIds, values, count, x, y, radius, null, 90, 0);
        }

        /// <summary>
        ///     Plots the pie chart using the specified label ids
        /// </summary>
        /// <param name="labelIds">The label ids</param>
        /// <param name="values">The values</param>
        /// <param name="count">The number of elements</param>
        /// <param name="x">The x-coordinate</param>
        /// <param name="y">The y-coordinate</param>
        /// <param name="radius">The radius of the shape</param>
        /// <param name="labelFmt">The label fmt</param>
        public static void PlotPieChart(string[] labelIds, byte[] values, int count, double x, double y, double radius, string labelFmt)
        {
            byte[][] nativeLabelIds = new byte[labelIds.Length][];
            for (int i = 0; i < labelIds.Length; i++)
            {
                nativeLabelIds[i] = Encoding.UTF8.GetBytes(labelIds[i]);
            }

            ImPlotNative.ImPlot_PlotPieChart_U8Ptr(nativeLabelIds, values, count, x, y, radius, Encoding.UTF8.GetBytes(labelFmt), 90, 0);
        }

        /// <summary>
        ///     Plots the pie chart using the specified label ids
        /// </summary>
        /// <param name="labelIds">The label ids</param>
        /// <param name="values">The values</param>
        /// <param name="count">The number of elements</param>
        /// <param name="x">The x-coordinate</param>
        /// <param name="y">The y-coordinate</param>
        /// <param name="radius">The radius of the shape</param>
        /// <param name="labelFmt">The label fmt</param>
        /// <param name="angle0">The angle</param>
        public static void PlotPieChart(string[] labelIds, byte[] values, int count, double x, double y, double radius, string labelFmt, double angle0)
        {
            byte[][] nativeLabelIds = new byte[labelIds.Length][];
            for (int i = 0; i < labelIds.Length; i++)
            {
                nativeLabelIds[i] = Encoding.UTF8.GetBytes(labelIds[i]);
            }

            ImPlotNative.ImPlot_PlotPieChart_U8Ptr(nativeLabelIds, values, count, x, y, radius, Encoding.UTF8.GetBytes(labelFmt), angle0, 0);
        }

        /// <summary>
        ///     Plots the pie chart using the specified label ids
        /// </summary>
        /// <param name="labelIds">The label ids</param>
        /// <param name="values">The values</param>
        /// <param name="count">The number of elements</param>
        /// <param name="x">The x-coordinate</param>
        /// <param name="y">The y-coordinate</param>
        /// <param name="radius">The radius of the shape</param>
        /// <param name="labelFmt">The label fmt</param>
        /// <param name="angle0">The angle</param>
        /// <param name="flags">The ImGui behavior flags</param>
        public static void PlotPieChart(string[] labelIds, byte[] values, int count, double x, double y, double radius, string labelFmt, double angle0, ImPlotPieChartFlags flags)
        {
            byte[][] nativeLabelIds = new byte[labelIds.Length][];
            for (int i = 0; i < labelIds.Length; i++)
            {
                nativeLabelIds[i] = Encoding.UTF8.GetBytes(labelIds[i]);
            }

            ImPlotNative.ImPlot_PlotPieChart_U8Ptr(nativeLabelIds, values, count, x, y, radius, Encoding.UTF8.GetBytes(labelFmt), angle0, flags);
        }

        /// <summary>
        ///     Plots the pie chart using the specified label ids
        /// </summary>
        /// <param name="labelIds">The label ids</param>
        /// <param name="values">The values</param>
        /// <param name="count">The number of elements</param>
        /// <param name="x">The x-coordinate</param>
        /// <param name="y">The y-coordinate</param>
        /// <param name="radius">The radius of the shape</param>
        public static void PlotPieChart(string[] labelIds, short[] values, int count, double x, double y, double radius)
        {
            byte[][] nativeLabelIds = new byte[labelIds.Length][];
            for (int i = 0; i < labelIds.Length; i++)
            {
                nativeLabelIds[i] = Encoding.UTF8.GetBytes(labelIds[i]);
            }

            ImPlotNative.ImPlot_PlotPieChart_S16Ptr(nativeLabelIds, values, count, x, y, radius, null, 90, 0);
        }

        /// <summary>
        ///     Plots the pie chart using the specified label ids
        /// </summary>
        /// <param name="labelIds">The label ids</param>
        /// <param name="values">The values</param>
        /// <param name="count">The number of elements</param>
        /// <param name="x">The x-coordinate</param>
        /// <param name="y">The y-coordinate</param>
        /// <param name="radius">The radius of the shape</param>
        /// <param name="labelFmt">The label fmt</param>
        public static void PlotPieChart(string[] labelIds, short[] values, int count, double x, double y, double radius, string labelFmt)
        {
            byte[][] nativeLabelIds = new byte[labelIds.Length][];
            for (int i = 0; i < labelIds.Length; i++)
            {
                nativeLabelIds[i] = Encoding.UTF8.GetBytes(labelIds[i]);
            }

            ImPlotNative.ImPlot_PlotPieChart_S16Ptr(nativeLabelIds, values, count, x, y, radius, Encoding.UTF8.GetBytes(labelFmt), 90, 0);
        }

        /// <summary>
        ///     Plots the pie chart using the specified label ids
        /// </summary>
        /// <param name="labelIds">The label ids</param>
        /// <param name="values">The values</param>
        /// <param name="count">The number of elements</param>
        /// <param name="x">The x-coordinate</param>
        /// <param name="y">The y-coordinate</param>
        /// <param name="radius">The radius of the shape</param>
        /// <param name="labelFmt">The label fmt</param>
        /// <param name="angle0">The angle</param>
        public static void PlotPieChart(string[] labelIds, short[] values, int count, double x, double y, double radius, string labelFmt, double angle0)
        {
            byte[][] nativeLabelIds = new byte[labelIds.Length][];
            for (int i = 0; i < labelIds.Length; i++)
            {
                nativeLabelIds[i] = Encoding.UTF8.GetBytes(labelIds[i]);
            }

            ImPlotNative.ImPlot_PlotPieChart_S16Ptr(nativeLabelIds, values, count, x, y, radius, Encoding.UTF8.GetBytes(labelFmt), angle0, 0);
        }

        /// <summary>
        ///     Plots the pie chart using the specified label ids
        /// </summary>
        /// <param name="labelIds">The label ids</param>
        /// <param name="values">The values</param>
        /// <param name="count">The number of elements</param>
        /// <param name="x">The x-coordinate</param>
        /// <param name="y">The y-coordinate</param>
        /// <param name="radius">The radius of the shape</param>
        /// <param name="labelFmt">The label fmt</param>
        /// <param name="angle0">The angle</param>
        /// <param name="flags">The ImGui behavior flags</param>
        public static void PlotPieChart(string[] labelIds, short[] values, int count, double x, double y, double radius, string labelFmt, double angle0, ImPlotPieChartFlags flags)
        {
            byte[][] nativeLabelIds = new byte[labelIds.Length][];
            for (int i = 0; i < labelIds.Length; i++)
            {
                nativeLabelIds[i] = Encoding.UTF8.GetBytes(labelIds[i]);
            }

            ImPlotNative.ImPlot_PlotPieChart_S16Ptr(nativeLabelIds, values, count, x, y, radius, Encoding.UTF8.GetBytes(labelFmt), angle0, flags);
        }

        /// <summary>
        ///     Plots the pie chart using the specified label ids
        /// </summary>
        /// <param name="labelIds">The label ids</param>
        /// <param name="values">The values</param>
        /// <param name="count">The number of elements</param>
        /// <param name="x">The x-coordinate</param>
        /// <param name="y">The y-coordinate</param>
        /// <param name="radius">The radius of the shape</param>
        public static void PlotPieChart(string[] labelIds, ushort[] values, int count, double x, double y, double radius)
        {
            byte[][] nativeLabelIds = new byte[labelIds.Length][];
            for (int i = 0; i < labelIds.Length; i++)
            {
                nativeLabelIds[i] = Encoding.UTF8.GetBytes(labelIds[i]);
            }

            ImPlotNative.ImPlot_PlotPieChart_U16Ptr(nativeLabelIds, values, count, x, y, radius, null, 90, 0);
        }
    }
}