// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImPlotP11.cs
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
        ///     Plots the pie chart using the specified label ids
        /// </summary>
        /// <param name="labelIds">The array of label identifiers</param>
        /// <param name="values">The array of data values to plot</param>
        /// <param name="count">The number of elements</param>
        /// <param name="x">The x-coordinate</param>
        /// <param name="y">The y-coordinate</param>
        /// <param name="radius">The radius of the shape</param>
        /// <param name="labelFmt">The label format string</param>
        public static void PlotPieChart(string[] labelIds, ushort[] values, int count, double x, double y, double radius, string labelFmt)
        {
            byte[][] nativeLabelIds = new byte[labelIds.Length][];
            for (int i = 0; i < labelIds.Length; i++)
            {
                nativeLabelIds[i] = Encoding.UTF8.GetBytes(labelIds[i]);
            }

            ImPlotNative.ImPlot_PlotPieChart_U16Ptr(nativeLabelIds, values, count, x, y, radius, Encoding.UTF8.GetBytes(labelFmt), 90, ImPlotPieChartFlags.None);
        }

        /// <summary>
        ///     Plots the pie chart using the specified label ids
        /// </summary>
        /// <param name="labelIds">The array of label identifiers</param>
        /// <param name="values">The array of data values to plot</param>
        /// <param name="count">The number of elements</param>
        /// <param name="x">The x-coordinate</param>
        /// <param name="y">The y-coordinate</param>
        /// <param name="radius">The radius of the shape</param>
        /// <param name="labelFmt">The label format string</param>
        /// <param name="angle0">The starting angle in radians</param>
        public static void PlotPieChart(string[] labelIds, ushort[] values, int count, double x, double y, double radius, string labelFmt, double angle0)
        {
            byte[][] nativeLabelIds = new byte[labelIds.Length][];
            for (int i = 0; i < labelIds.Length; i++)
            {
                nativeLabelIds[i] = Encoding.UTF8.GetBytes(labelIds[i]);
            }

            ImPlotNative.ImPlot_PlotPieChart_U16Ptr(nativeLabelIds, values, count, x, y, radius, Encoding.UTF8.GetBytes(labelFmt), angle0, ImPlotPieChartFlags.None);
        }

        /// <summary>
        ///     Plots the pie chart using the specified label ids
        /// </summary>
        /// <param name="labelIds">The array of label identifiers</param>
        /// <param name="values">The array of data values to plot</param>
        /// <param name="count">The number of elements</param>
        /// <param name="x">The x-coordinate</param>
        /// <param name="y">The y-coordinate</param>
        /// <param name="radius">The radius of the shape</param>
        /// <param name="labelFmt">The label format string</param>
        /// <param name="angle0">The starting angle in radians</param>
        /// <param name="flags">The ImGui behavior flags</param>
        public static void PlotPieChart(string[] labelIds, ushort[] values, int count, double x, double y, double radius, string labelFmt, double angle0, ImPlotPieChartFlags flags)
        {
            byte[][] nativeLabelIds = new byte[labelIds.Length][];
            for (int i = 0; i < labelIds.Length; i++)
            {
                nativeLabelIds[i] = Encoding.UTF8.GetBytes(labelIds[i]);
            }

            ImPlotNative.ImPlot_PlotPieChart_U16Ptr(nativeLabelIds, values, count, x, y, radius, Encoding.UTF8.GetBytes(labelFmt), angle0, flags);
        }

        /// <summary>
        ///     Plots the pie chart using the specified label ids
        /// </summary>
        /// <param name="labelIds">The array of label identifiers</param>
        /// <param name="values">The array of data values to plot</param>
        /// <param name="count">The number of elements</param>
        /// <param name="x">The x-coordinate</param>
        /// <param name="y">The y-coordinate</param>
        /// <param name="radius">The radius of the shape</param>
        public static void PlotPieChart(string[] labelIds, int[] values, int count, double x, double y, double radius)
        {
            byte[][] nativeLabelIds = new byte[labelIds.Length][];
            for (int i = 0; i < labelIds.Length; i++)
            {
                nativeLabelIds[i] = Encoding.UTF8.GetBytes(labelIds[i]);
            }

            ImPlotNative.ImPlot_PlotPieChart_S32Ptr(nativeLabelIds, values, count, x, y, radius, Encoding.UTF8.GetBytes("%.1f"), 90, ImPlotPieChartFlags.None);
        }

        /// <summary>
        ///     Plots the pie chart using the specified label ids
        /// </summary>
        /// <param name="labelIds">The array of label identifiers</param>
        /// <param name="values">The array of data values to plot</param>
        /// <param name="count">The number of elements</param>
        /// <param name="x">The x-coordinate</param>
        /// <param name="y">The y-coordinate</param>
        /// <param name="radius">The radius of the shape</param>
        /// <param name="labelFmt">The label format string</param>
        public static void PlotPieChart(string[] labelIds, int[] values, int count, double x, double y, double radius, string labelFmt)
        {
            byte[][] nativeLabelIds = new byte[labelIds.Length][];
            for (int i = 0; i < labelIds.Length; i++)
            {
                nativeLabelIds[i] = Encoding.UTF8.GetBytes(labelIds[i]);
            }

            ImPlotNative.ImPlot_PlotPieChart_S32Ptr(nativeLabelIds, values, count, x, y, radius, Encoding.UTF8.GetBytes(labelFmt), 90, ImPlotPieChartFlags.None);
        }

        /// <summary>
        ///     Plots the pie chart using the specified label ids
        /// </summary>
        /// <param name="labelIds">The array of label identifiers</param>
        /// <param name="values">The array of data values to plot</param>
        /// <param name="count">The number of elements</param>
        /// <param name="x">The x-coordinate</param>
        /// <param name="y">The y-coordinate</param>
        /// <param name="radius">The radius of the shape</param>
        /// <param name="labelFmt">The label format string</param>
        /// <param name="angle0">The starting angle in radians</param>
        public static void PlotPieChart(string[] labelIds, int[] values, int count, double x, double y, double radius, string labelFmt, double angle0)
        {
            byte[][] nativeLabelIds = new byte[labelIds.Length][];
            for (int i = 0; i < labelIds.Length; i++)
            {
                nativeLabelIds[i] = Encoding.UTF8.GetBytes(labelIds[i]);
            }

            ImPlotNative.ImPlot_PlotPieChart_S32Ptr(nativeLabelIds, values, count, x, y, radius, Encoding.UTF8.GetBytes(labelFmt), angle0, ImPlotPieChartFlags.None);
        }

        /// <summary>
        ///     Plots the pie chart using the specified label ids
        /// </summary>
        /// <param name="labelIds">The array of label identifiers</param>
        /// <param name="values">The array of data values to plot</param>
        /// <param name="count">The number of elements</param>
        /// <param name="x">The x-coordinate</param>
        /// <param name="y">The y-coordinate</param>
        /// <param name="radius">The radius of the shape</param>
        /// <param name="labelFmt">The label format string</param>
        /// <param name="angle0">The starting angle in radians</param>
        /// <param name="flags">The ImGui behavior flags</param>
        public static void PlotPieChart(string[] labelIds, int[] values, int count, double x, double y, double radius, string labelFmt, double angle0, ImPlotPieChartFlags flags)
        {
            byte[][] nativeLabelIds = new byte[labelIds.Length][];
            for (int i = 0; i < labelIds.Length; i++)
            {
                nativeLabelIds[i] = Encoding.UTF8.GetBytes(labelIds[i]);
            }

            ImPlotNative.ImPlot_PlotPieChart_S32Ptr(nativeLabelIds, values, count, x, y, radius, Encoding.UTF8.GetBytes(labelFmt), angle0, flags);
        }

        /// <summary>
        ///     Plots the pie chart using the specified label ids
        /// </summary>
        /// <param name="labelIds">The array of label identifiers</param>
        /// <param name="values">The array of data values to plot</param>
        /// <param name="count">The number of elements</param>
        /// <param name="x">The x-coordinate</param>
        /// <param name="y">The y-coordinate</param>
        /// <param name="radius">The radius of the shape</param>
        public static void PlotPieChart(string[] labelIds, uint[] values, int count, double x, double y, double radius)
        {
            byte[][] nativeLabelIds = new byte[labelIds.Length][];
            for (int i = 0; i < labelIds.Length; i++)
            {
                nativeLabelIds[i] = Encoding.UTF8.GetBytes(labelIds[i]);
            }

            ImPlotNative.ImPlot_PlotPieChart_U32Ptr(nativeLabelIds, values, count, x, y, radius, Encoding.UTF8.GetBytes("%.1f"), 90, ImPlotPieChartFlags.None);
        }

        /// <summary>
        ///     Plots the pie chart using the specified label ids
        /// </summary>
        /// <param name="labelIds">The array of label identifiers</param>
        /// <param name="values">The array of data values to plot</param>
        /// <param name="count">The number of elements</param>
        /// <param name="x">The x-coordinate</param>
        /// <param name="y">The y-coordinate</param>
        /// <param name="radius">The radius of the shape</param>
        /// <param name="labelFmt">The label format string</param>
        public static void PlotPieChart(string[] labelIds, uint[] values, int count, double x, double y, double radius, string labelFmt)
        {
            byte[][] nativeLabelIds = new byte[labelIds.Length][];
            for (int i = 0; i < labelIds.Length; i++)
            {
                nativeLabelIds[i] = Encoding.UTF8.GetBytes(labelIds[i]);
            }

            ImPlotNative.ImPlot_PlotPieChart_U32Ptr(nativeLabelIds, values, count, x, y, radius, Encoding.UTF8.GetBytes(labelFmt), 90, ImPlotPieChartFlags.None);
        }

        /// <summary>
        ///     Plots the pie chart using the specified label ids
        /// </summary>
        /// <param name="labelIds">The array of label identifiers</param>
        /// <param name="values">The array of data values to plot</param>
        /// <param name="count">The number of elements</param>
        /// <param name="x">The x-coordinate</param>
        /// <param name="y">The y-coordinate</param>
        /// <param name="radius">The radius of the shape</param>
        /// <param name="labelFmt">The label format string</param>
        /// <param name="angle0">The starting angle in radians</param>
        public static void PlotPieChart(string[] labelIds, uint[] values, int count, double x, double y, double radius, string labelFmt, double angle0)
        {
            byte[][] nativeLabelIds = new byte[labelIds.Length][];
            for (int i = 0; i < labelIds.Length; i++)
            {
                nativeLabelIds[i] = Encoding.UTF8.GetBytes(labelIds[i]);
            }

            ImPlotNative.ImPlot_PlotPieChart_U32Ptr(nativeLabelIds, values, count, x, y, radius, Encoding.UTF8.GetBytes(labelFmt), angle0, ImPlotPieChartFlags.None);
        }

        /// <summary>
        ///     Plots the pie chart using the specified label ids
        /// </summary>
        /// <param name="labelIds">The array of label identifiers</param>
        /// <param name="values">The array of data values to plot</param>
        /// <param name="count">The number of elements</param>
        /// <param name="x">The x-coordinate</param>
        /// <param name="y">The y-coordinate</param>
        /// <param name="radius">The radius of the shape</param>
        /// <param name="labelFmt">The label format string</param>
        /// <param name="angle0">The starting angle in radians</param>
        /// <param name="flags">The ImGui behavior flags</param>
        public static void PlotPieChart(string[] labelIds, uint[] values, int count, double x, double y, double radius, string labelFmt, double angle0, ImPlotPieChartFlags flags)
        {
            byte[][] nativeLabelIds = new byte[labelIds.Length][];
            for (int i = 0; i < labelIds.Length; i++)
            {
                nativeLabelIds[i] = Encoding.UTF8.GetBytes(labelIds[i]);
            }

            ImPlotNative.ImPlot_PlotPieChart_U32Ptr(nativeLabelIds, values, count, x, y, radius, Encoding.UTF8.GetBytes(labelFmt), angle0, flags);
        }

        /// <summary>
        ///     Plots the pie chart using the specified label ids
        /// </summary>
        /// <param name="labelIds">The array of label identifiers</param>
        /// <param name="values">The array of data values to plot</param>
        /// <param name="count">The number of elements</param>
        /// <param name="x">The x-coordinate</param>
        /// <param name="y">The y-coordinate</param>
        /// <param name="radius">The radius of the shape</param>
        public static void PlotPieChart(string[] labelIds, long[] values, int count, double x, double y, double radius)
        {
            byte[][] nativeLabelIds = new byte[labelIds.Length][];
            for (int i = 0; i < labelIds.Length; i++)
            {
                nativeLabelIds[i] = Encoding.UTF8.GetBytes(labelIds[i]);
            }

            ImPlotNative.ImPlot_PlotPieChart_S64Ptr(nativeLabelIds, values, count, x, y, radius, Encoding.UTF8.GetBytes("%.1f"), 90, ImPlotPieChartFlags.None);
        }

        /// <summary>
        ///     Plots the pie chart using the specified label ids
        /// </summary>
        /// <param name="labelIds">The array of label identifiers</param>
        /// <param name="values">The array of data values to plot</param>
        /// <param name="count">The number of elements</param>
        /// <param name="x">The x-coordinate</param>
        /// <param name="y">The y-coordinate</param>
        /// <param name="radius">The radius of the shape</param>
        /// <param name="labelFmt">The label format string</param>
        public static void PlotPieChart(string[] labelIds, long[] values, int count, double x, double y, double radius, string labelFmt)
        {
            byte[][] nativeLabelIds = new byte[labelIds.Length][];
            for (int i = 0; i < labelIds.Length; i++)
            {
                nativeLabelIds[i] = Encoding.UTF8.GetBytes(labelIds[i]);
            }

            ImPlotNative.ImPlot_PlotPieChart_S64Ptr(nativeLabelIds, values, count, x, y, radius, Encoding.UTF8.GetBytes(labelFmt), 90, ImPlotPieChartFlags.None);
        }

        /// <summary>
        ///     Plots the pie chart using the specified label ids
        /// </summary>
        /// <param name="labelIds">The array of label identifiers</param>
        /// <param name="values">The array of data values to plot</param>
        /// <param name="count">The number of elements</param>
        /// <param name="x">The x-coordinate</param>
        /// <param name="y">The y-coordinate</param>
        /// <param name="radius">The radius of the shape</param>
        /// <param name="labelFmt">The label format string</param>
        /// <param name="angle0">The starting angle in radians</param>
        public static void PlotPieChart(string[] labelIds, long[] values, int count, double x, double y, double radius, string labelFmt, double angle0)
        {
            byte[][] nativeLabelIds = new byte[labelIds.Length][];
            for (int i = 0; i < labelIds.Length; i++)
            {
                nativeLabelIds[i] = Encoding.UTF8.GetBytes(labelIds[i]);
            }

            ImPlotNative.ImPlot_PlotPieChart_S64Ptr(nativeLabelIds, values, count, x, y, radius, Encoding.UTF8.GetBytes(labelFmt), angle0, ImPlotPieChartFlags.None);
        }

        /// <summary>
        ///     Plots the pie chart using the specified label ids
        /// </summary>
        /// <param name="labelIds">The array of label identifiers</param>
        /// <param name="values">The array of data values to plot</param>
        /// <param name="count">The number of elements</param>
        /// <param name="x">The x-coordinate</param>
        /// <param name="y">The y-coordinate</param>
        /// <param name="radius">The radius of the shape</param>
        /// <param name="labelFmt">The label format string</param>
        /// <param name="angle0">The starting angle in radians</param>
        /// <param name="flags">The ImGui behavior flags</param>
        public static void PlotPieChart(string[] labelIds, long[] values, int count, double x, double y, double radius, string labelFmt, double angle0, ImPlotPieChartFlags flags)
        {
            byte[][] nativeLabelIds = new byte[labelIds.Length][];
            for (int i = 0; i < labelIds.Length; i++)
            {
                nativeLabelIds[i] = Encoding.UTF8.GetBytes(labelIds[i]);
            }

            ImPlotNative.ImPlot_PlotPieChart_S64Ptr(nativeLabelIds, values, count, x, y, radius, Encoding.UTF8.GetBytes(labelFmt), angle0, flags);
        }

        /// <summary>
        ///     Plots the pie chart using the specified label ids
        /// </summary>
        /// <param name="labelIds">The array of label identifiers</param>
        /// <param name="values">The array of data values to plot</param>
        /// <param name="count">The number of elements</param>
        /// <param name="x">The x-coordinate</param>
        /// <param name="y">The y-coordinate</param>
        /// <param name="radius">The radius of the shape</param>
        public static void PlotPieChart(string[] labelIds, ulong[] values, int count, double x, double y, double radius)
        {
            byte[][] nativeLabelIds = new byte[labelIds.Length][];
            for (int i = 0; i < labelIds.Length; i++)
            {
                nativeLabelIds[i] = Encoding.UTF8.GetBytes(labelIds[i]);
            }

            ImPlotNative.ImPlot_PlotPieChart_U64Ptr(nativeLabelIds, values, count, x, y, radius, Encoding.UTF8.GetBytes("%.1f"), 90, ImPlotPieChartFlags.None);
        }

        /// <summary>
        ///     Plots the pie chart using the specified label ids
        /// </summary>
        /// <param name="labelIds">The array of label identifiers</param>
        /// <param name="values">The array of data values to plot</param>
        /// <param name="count">The number of elements</param>
        /// <param name="x">The x-coordinate</param>
        /// <param name="y">The y-coordinate</param>
        /// <param name="radius">The radius of the shape</param>
        /// <param name="labelFmt">The label format string</param>
        public static void PlotPieChart(string[] labelIds, ulong[] values, int count, double x, double y, double radius, string labelFmt)
        {
            byte[][] nativeLabelIds = new byte[labelIds.Length][];
            for (int i = 0; i < labelIds.Length; i++)
            {
                nativeLabelIds[i] = Encoding.UTF8.GetBytes(labelIds[i]);
            }

            ImPlotNative.ImPlot_PlotPieChart_U64Ptr(nativeLabelIds, values, count, x, y, radius, Encoding.UTF8.GetBytes(labelFmt), 90, ImPlotPieChartFlags.None);
        }

        /// <summary>
        ///     Plots the pie chart using the specified label ids
        /// </summary>
        /// <param name="labelIds">The array of label identifiers</param>
        /// <param name="values">The array of data values to plot</param>
        /// <param name="count">The number of elements</param>
        /// <param name="x">The x-coordinate</param>
        /// <param name="y">The y-coordinate</param>
        /// <param name="radius">The radius of the shape</param>
        /// <param name="labelFmt">The label format string</param>
        /// <param name="angle0">The starting angle in radians</param>
        public static void PlotPieChart(string[] labelIds, ulong[] values, int count, double x, double y, double radius, string labelFmt, double angle0)
        {
            byte[][] nativeLabelIds = new byte[labelIds.Length][];
            for (int i = 0; i < labelIds.Length; i++)
            {
                nativeLabelIds[i] = Encoding.UTF8.GetBytes(labelIds[i]);
            }

            ImPlotNative.ImPlot_PlotPieChart_U64Ptr(nativeLabelIds, values, count, x, y, radius, Encoding.UTF8.GetBytes(labelFmt), angle0, ImPlotPieChartFlags.None);
        }

        /// <summary>
        ///     Plots the pie chart using the specified label ids
        /// </summary>
        /// <param name="labelIds">The array of label identifiers</param>
        /// <param name="values">The array of data values to plot</param>
        /// <param name="count">The number of elements</param>
        /// <param name="x">The x-coordinate</param>
        /// <param name="y">The y-coordinate</param>
        /// <param name="radius">The radius of the shape</param>
        /// <param name="labelFmt">The label format string</param>
        /// <param name="angle0">The starting angle in radians</param>
        /// <param name="flags">The ImGui behavior flags</param>
        public static void PlotPieChart(string[] labelIds, ulong[] values, int count, double x, double y, double radius, string labelFmt, double angle0, ImPlotPieChartFlags flags)
        {
            byte[][] nativeLabelIds = new byte[labelIds.Length][];
            for (int i = 0; i < labelIds.Length; i++)
            {
                nativeLabelIds[i] = Encoding.UTF8.GetBytes(labelIds[i]);
            }

            ImPlotNative.ImPlot_PlotPieChart_U64Ptr(nativeLabelIds, values, count, x, y, radius, Encoding.UTF8.GetBytes(labelFmt), angle0, flags);
        }

        /// <summary>
        ///     Plots the scatter using the specified label id
        /// </summary>
        /// <param name="labelId">The label identifier for the plot item</param>
        /// <param name="values">The array of data values to plot</param>
        /// <param name="count">The number of elements</param>
        public static void PlotScatter(string labelId, float[] values, int count)
        {
            ImPlotNative.ImPlot_PlotScatter_FloatPtrInt(Encoding.UTF8.GetBytes(labelId), values, count, 1.0, 0.0, ImPlotScatterFlags.None, 0, sizeof(float));
        }

        /// <summary>
        ///     Plots the scatter using the specified label id
        /// </summary>
        /// <param name="labelId">The label identifier for the plot item</param>
        /// <param name="values">The array of data values to plot</param>
        /// <param name="count">The number of elements</param>
        /// <param name="xscale">The x-axis scale factor</param>
        public static void PlotScatter(string labelId, float[] values, int count, double xscale)
        {
            ImPlotNative.ImPlot_PlotScatter_FloatPtrInt(Encoding.UTF8.GetBytes(labelId), values, count, xscale, 0.0, ImPlotScatterFlags.None, 0, sizeof(float));
        }

        /// <summary>
        ///     Plots the scatter using the specified label id
        /// </summary>
        /// <param name="labelId">The label identifier for the plot item</param>
        /// <param name="values">The array of data values to plot</param>
        /// <param name="count">The number of elements</param>
        /// <param name="xscale">The x-axis scale factor</param>
        /// <param name="xstart">The starting x value</param>
        public static void PlotScatter(string labelId, float[] values, int count, double xscale, double xstart)
        {
            ImPlotNative.ImPlot_PlotScatter_FloatPtrInt(Encoding.UTF8.GetBytes(labelId), values, count, xscale, xstart, ImPlotScatterFlags.None, 0, sizeof(float));
        }

        /// <summary>
        ///     Plots the scatter using the specified label id
        /// </summary>
        /// <param name="labelId">The label identifier for the plot item</param>
        /// <param name="values">The array of data values to plot</param>
        /// <param name="count">The number of elements</param>
        /// <param name="xscale">The x-axis scale factor</param>
        /// <param name="xstart">The starting x value</param>
        /// <param name="flags">The ImGui behavior flags</param>
        public static void PlotScatter(string labelId, float[] values, int count, double xscale, double xstart, ImPlotScatterFlags flags)
        {
            ImPlotNative.ImPlot_PlotScatter_FloatPtrInt(Encoding.UTF8.GetBytes(labelId), values, count, xscale, xstart, flags, 0, sizeof(float));
        }

        /// <summary>
        ///     Plots the scatter using the specified label id
        /// </summary>
        /// <param name="labelId">The label identifier for the plot item</param>
        /// <param name="values">The array of data values to plot</param>
        /// <param name="count">The number of elements</param>
        /// <param name="xscale">The x-axis scale factor</param>
        /// <param name="xstart">The starting x value</param>
        /// <param name="flags">The ImGui behavior flags</param>
        /// <param name="offset">The offset from the origin</param>
        public static void PlotScatter(string labelId, float[] values, int count, double xscale, double xstart, ImPlotScatterFlags flags, int offset)
        {
            ImPlotNative.ImPlot_PlotScatter_FloatPtrInt(Encoding.UTF8.GetBytes(labelId), values, count, xscale, xstart, flags, offset, sizeof(float));
        }

        /// <summary>
        ///     Plots the scatter using the specified label id
        /// </summary>
        /// <param name="labelId">The label identifier for the plot item</param>
        /// <param name="values">The array of data values to plot</param>
        /// <param name="count">The number of elements</param>
        /// <param name="xscale">The x-axis scale factor</param>
        /// <param name="xstart">The starting x value</param>
        /// <param name="flags">The ImGui behavior flags</param>
        /// <param name="offset">The offset from the origin</param>
        /// <param name="stride">The byte stride between elements</param>
        public static void PlotScatter(string labelId, float[] values, int count, double xscale, double xstart, ImPlotScatterFlags flags, int offset, int stride)
        {
            ImPlotNative.ImPlot_PlotScatter_FloatPtrInt(Encoding.UTF8.GetBytes(labelId), values, count, xscale, xstart, flags, offset, stride);
        }

        /// <summary>
        ///     Plots the scatter using the specified label id
        /// </summary>
        /// <param name="labelId">The label identifier for the plot item</param>
        /// <param name="values">The array of data values to plot</param>
        /// <param name="count">The number of elements</param>
        public static void PlotScatter(string labelId, double[] values, int count)
        {
            ImPlotNative.ImPlot_PlotScatter_doublePtrInt(Encoding.UTF8.GetBytes(labelId), values, count, 1.0, 0.0, ImPlotScatterFlags.None, 0, sizeof(double));
        }

        /// <summary>
        ///     Plots the scatter using the specified label id
        /// </summary>
        /// <param name="labelId">The label identifier for the plot item</param>
        /// <param name="values">The array of data values to plot</param>
        /// <param name="count">The number of elements</param>
        /// <param name="xscale">The x-axis scale factor</param>
        public static void PlotScatter(string labelId, double[] values, int count, double xscale)
        {
            ImPlotNative.ImPlot_PlotScatter_doublePtrInt(Encoding.UTF8.GetBytes(labelId), values, count, xscale, 0.0, ImPlotScatterFlags.None, 0, sizeof(double));
        }

        /// <summary>
        ///     Plots the scatter using the specified label id
        /// </summary>
        /// <param name="labelId">The label identifier for the plot item</param>
        /// <param name="values">The array of data values to plot</param>
        /// <param name="count">The number of elements</param>
        /// <param name="xscale">The x-axis scale factor</param>
        /// <param name="xstart">The starting x value</param>
        public static void PlotScatter(string labelId, double[] values, int count, double xscale, double xstart)
        {
            ImPlotNative.ImPlot_PlotScatter_doublePtrInt(Encoding.UTF8.GetBytes(labelId), values, count, xscale, xstart, ImPlotScatterFlags.None, 0, sizeof(double));
        }

        /// <summary>
        ///     Plots the scatter using the specified label id
        /// </summary>
        /// <param name="labelId">The label identifier for the plot item</param>
        /// <param name="values">The array of data values to plot</param>
        /// <param name="count">The number of elements</param>
        /// <param name="xscale">The x-axis scale factor</param>
        /// <param name="xstart">The starting x value</param>
        /// <param name="flags">The ImGui behavior flags</param>
        public static void PlotScatter(string labelId, double[] values, int count, double xscale, double xstart, ImPlotScatterFlags flags)
        {
            ImPlotNative.ImPlot_PlotScatter_doublePtrInt(Encoding.UTF8.GetBytes(labelId), values, count, xscale, xstart, flags, 0, sizeof(double));
        }

        /// <summary>
        ///     Plots the scatter using the specified label id
        /// </summary>
        /// <param name="labelId">The label identifier for the plot item</param>
        /// <param name="values">The array of data values to plot</param>
        /// <param name="count">The number of elements</param>
        /// <param name="xscale">The x-axis scale factor</param>
        /// <param name="xstart">The starting x value</param>
        /// <param name="flags">The ImGui behavior flags</param>
        /// <param name="offset">The offset from the origin</param>
        public static void PlotScatter(string labelId, double[] values, int count, double xscale, double xstart, ImPlotScatterFlags flags, int offset)
        {
            ImPlotNative.ImPlot_PlotScatter_doublePtrInt(Encoding.UTF8.GetBytes(labelId), values, count, xscale, xstart, flags, offset, sizeof(double));
        }

        /// <summary>
        ///     Plots the scatter using the specified label id
        /// </summary>
        /// <param name="labelId">The label identifier for the plot item</param>
        /// <param name="values">The array of data values to plot</param>
        /// <param name="count">The number of elements</param>
        /// <param name="xscale">The x-axis scale factor</param>
        /// <param name="xstart">The starting x value</param>
        /// <param name="flags">The ImGui behavior flags</param>
        /// <param name="offset">The offset from the origin</param>
        /// <param name="stride">The byte stride between elements</param>
        public static void PlotScatter(string labelId, double[] values, int count, double xscale, double xstart, ImPlotScatterFlags flags, int offset, int stride)
        {
            ImPlotNative.ImPlot_PlotScatter_doublePtrInt(Encoding.UTF8.GetBytes(labelId), values, count, xscale, xstart, flags, offset, stride);
        }

        /// <summary>
        ///     Plots the scatter using the specified label id
        /// </summary>
        /// <param name="labelId">The label identifier for the plot item</param>
        /// <param name="values">The array of data values to plot</param>
        /// <param name="count">The number of elements</param>
        public static void PlotScatter(string labelId, sbyte[] values, int count)
        {
            ImPlotNative.ImPlot_PlotScatter_S8PtrInt(Encoding.UTF8.GetBytes(labelId), values, count, 1.0, 0.0, ImPlotScatterFlags.None, 0, sizeof(sbyte));
        }

        /// <summary>
        ///     Plots the scatter using the specified label id
        /// </summary>
        /// <param name="labelId">The label identifier for the plot item</param>
        /// <param name="values">The array of data values to plot</param>
        /// <param name="count">The number of elements</param>
        /// <param name="xscale">The x-axis scale factor</param>
        public static void PlotScatter(string labelId, sbyte[] values, int count, double xscale)
        {
            ImPlotNative.ImPlot_PlotScatter_S8PtrInt(Encoding.UTF8.GetBytes(labelId), values, count, xscale, 0.0, ImPlotScatterFlags.None, 0, sizeof(sbyte));
        }

        /// <summary>
        ///     Plots the scatter using the specified label id
        /// </summary>
        /// <param name="labelId">The label identifier for the plot item</param>
        /// <param name="values">The array of data values to plot</param>
        /// <param name="count">The number of elements</param>
        /// <param name="xscale">The x-axis scale factor</param>
        /// <param name="xstart">The starting x value</param>
        public static void PlotScatter(string labelId, sbyte[] values, int count, double xscale, double xstart)
        {
            ImPlotNative.ImPlot_PlotScatter_S8PtrInt(Encoding.UTF8.GetBytes(labelId), values, count, xscale, xstart, ImPlotScatterFlags.None, 0, sizeof(sbyte));
        }

        /// <summary>
        ///     Plots the scatter using the specified label id
        /// </summary>
        /// <param name="labelId">The label identifier for the plot item</param>
        /// <param name="values">The array of data values to plot</param>
        /// <param name="count">The number of elements</param>
        /// <param name="xscale">The x-axis scale factor</param>
        /// <param name="xstart">The starting x value</param>
        /// <param name="flags">The ImGui behavior flags</param>
        public static void PlotScatter(string labelId, sbyte[] values, int count, double xscale, double xstart, ImPlotScatterFlags flags)
        {
            ImPlotNative.ImPlot_PlotScatter_S8PtrInt(Encoding.UTF8.GetBytes(labelId), values, count, xscale, xstart, flags, 0, sizeof(sbyte));
        }

        /// <summary>
        ///     Plots the scatter using the specified label id
        /// </summary>
        /// <param name="labelId">The label identifier for the plot item</param>
        /// <param name="values">The array of data values to plot</param>
        /// <param name="count">The number of elements</param>
        /// <param name="xscale">The x-axis scale factor</param>
        /// <param name="xstart">The starting x value</param>
        /// <param name="flags">The ImGui behavior flags</param>
        /// <param name="offset">The offset from the origin</param>
        public static void PlotScatter(string labelId, sbyte[] values, int count, double xscale, double xstart, ImPlotScatterFlags flags, int offset)
        {
            ImPlotNative.ImPlot_PlotScatter_S8PtrInt(Encoding.UTF8.GetBytes(labelId), values, count, xscale, xstart, flags, offset, sizeof(sbyte));
        }

        /// <summary>
        ///     Plots the scatter using the specified label id
        /// </summary>
        /// <param name="labelId">The label identifier for the plot item</param>
        /// <param name="values">The array of data values to plot</param>
        /// <param name="count">The number of elements</param>
        /// <param name="xscale">The x-axis scale factor</param>
        /// <param name="xstart">The starting x value</param>
        /// <param name="flags">The ImGui behavior flags</param>
        /// <param name="offset">The offset from the origin</param>
        /// <param name="stride">The byte stride between elements</param>
        public static void PlotScatter(string labelId, sbyte[] values, int count, double xscale, double xstart, ImPlotScatterFlags flags, int offset, int stride)
        {
            ImPlotNative.ImPlot_PlotScatter_S8PtrInt(Encoding.UTF8.GetBytes(labelId), values, count, xscale, xstart, flags, offset, stride);
        }

        /// <summary>
        ///     Plots the scatter using the specified label id
        /// </summary>
        /// <param name="labelId">The label identifier for the plot item</param>
        /// <param name="values">The array of data values to plot</param>
        /// <param name="count">The number of elements</param>
        public static void PlotScatter(string labelId, byte[] values, int count)
        {
            ImPlotNative.ImPlot_PlotScatter_U8PtrInt(Encoding.UTF8.GetBytes(labelId), values, count, 1.0, 0.0, ImPlotScatterFlags.None, 0, sizeof(byte));
        }

        /// <summary>
        ///     Plots the scatter using the specified label id
        /// </summary>
        /// <param name="labelId">The label identifier for the plot item</param>
        /// <param name="values">The array of data values to plot</param>
        /// <param name="count">The number of elements</param>
        /// <param name="xscale">The x-axis scale factor</param>
        public static void PlotScatter(string labelId, byte[] values, int count, double xscale)
        {
            ImPlotNative.ImPlot_PlotScatter_U8PtrInt(Encoding.UTF8.GetBytes(labelId), values, count, xscale, 0.0, ImPlotScatterFlags.None, 0, sizeof(byte));
        }

        /// <summary>
        ///     Plots the scatter using the specified label id
        /// </summary>
        /// <param name="labelId">The label identifier for the plot item</param>
        /// <param name="values">The array of data values to plot</param>
        /// <param name="count">The number of elements</param>
        /// <param name="xscale">The x-axis scale factor</param>
        /// <param name="xstart">The starting x value</param>
        public static void PlotScatter(string labelId, byte[] values, int count, double xscale, double xstart)
        {
            ImPlotNative.ImPlot_PlotScatter_U8PtrInt(Encoding.UTF8.GetBytes(labelId), values, count, xscale, xstart, ImPlotScatterFlags.None, 0, sizeof(byte));
        }

        /// <summary>
        ///     Plots the scatter using the specified label id
        /// </summary>
        /// <param name="labelId">The label identifier for the plot item</param>
        /// <param name="values">The array of data values to plot</param>
        /// <param name="count">The number of elements</param>
        /// <param name="xscale">The x-axis scale factor</param>
        /// <param name="xstart">The starting x value</param>
        /// <param name="flags">The ImGui behavior flags</param>
        public static void PlotScatter(string labelId, byte[] values, int count, double xscale, double xstart, ImPlotScatterFlags flags)
        {
            ImPlotNative.ImPlot_PlotScatter_U8PtrInt(Encoding.UTF8.GetBytes(labelId), values, count, xscale, xstart, flags, 0, sizeof(byte));
        }

        /// <summary>
        ///     Plots the scatter using the specified label id
        /// </summary>
        /// <param name="labelId">The label identifier for the plot item</param>
        /// <param name="values">The array of data values to plot</param>
        /// <param name="count">The number of elements</param>
        /// <param name="xscale">The x-axis scale factor</param>
        /// <param name="xstart">The starting x value</param>
        /// <param name="flags">The ImGui behavior flags</param>
        /// <param name="offset">The offset from the origin</param>
        public static void PlotScatter(string labelId, byte[] values, int count, double xscale, double xstart, ImPlotScatterFlags flags, int offset)
        {
            ImPlotNative.ImPlot_PlotScatter_U8PtrInt(Encoding.UTF8.GetBytes(labelId), values, count, xscale, xstart, flags, offset, sizeof(byte));
        }
    }
}