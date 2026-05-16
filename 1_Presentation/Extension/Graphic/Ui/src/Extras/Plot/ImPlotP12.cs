// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImPlotP12.cs
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
    ///     The ImPlot wrapper class for native plot rendering functions
    /// </summary>
    public static partial class ImPlot
    {
        /// <summary>
        ///     Plots the histogram using the specified label id
        /// </summary>
        /// <param name="labelId">The label identifier for the plot item</param>
        /// <param name="values">The array of data values to plot</param>
        /// <param name="count">The number of elements</param>
        /// <param name="bins">The number of histogram bins</param>
        /// <param name="barScale">The bar scale</param>
        /// <param name="range">The value range (min, max)</param>
        /// <returns>The double-precision floating-point result</returns>
        public static double PlotHistogram(string labelId, byte[] values, int count, int bins, double barScale, ImPlotRange range)
        {
            double ret = ImPlotNative.ImPlot_PlotHistogram_U8Ptr(Encoding.UTF8.GetBytes(labelId), values, count, bins, barScale, range, 0);
            return ret;
        }

        /// <summary>
        ///     Plots the histogram using the specified label id
        /// </summary>
        /// <param name="labelId">The label identifier for the plot item</param>
        /// <param name="values">The array of data values to plot</param>
        /// <param name="count">The number of elements</param>
        /// <param name="bins">The number of histogram bins</param>
        /// <param name="barScale">The bar scale</param>
        /// <param name="range">The value range (min, max)</param>
        /// <param name="flags">The ImGui behavior flags</param>
        /// <returns>The double-precision floating-point result</returns>
        public static double PlotHistogram(string labelId, byte[] values, int count, int bins, double barScale, ImPlotRange range, ImPlotHistogramFlags flags)
        {
            double ret = ImPlotNative.ImPlot_PlotHistogram_U8Ptr(Encoding.UTF8.GetBytes(labelId), values, count, bins, barScale, range, flags);
            return ret;
        }

        /// <summary>
        ///     Plots the histogram using the specified label id
        /// </summary>
        /// <param name="labelId">The label identifier for the plot item</param>
        /// <param name="values">The array of data values to plot</param>
        /// <param name="count">The number of elements</param>
        /// <returns>The double-precision floating-point result</returns>
        public static double PlotHistogram(string labelId, short[] values, int count)
        {
            double ret = ImPlotNative.ImPlot_PlotHistogram_S16Ptr(Encoding.UTF8.GetBytes(labelId), values, count, 0, 1.0, new ImPlotRange(), 0);
            return ret;
        }

        /// <summary>
        ///     Plots the histogram using the specified label id
        /// </summary>
        /// <param name="labelId">The label identifier for the plot item</param>
        /// <param name="values">The array of data values to plot</param>
        /// <param name="count">The number of elements</param>
        /// <param aram>
        /// <param name="count">The number of elements</param>
        /// <param name="bins">The number of histogram bins</param>
        /// <returns>The double-precision floating-point result</returns>
        public static double PlotHistogram(string labelId, short[] values, int count, int bins)
        {
            double ret = ImPlotNative.ImPlot_PlotHistogram_S16Ptr(Encoding.UTF8.GetBytes(labelId), values, count, bins, 1.0, new ImPlotRange(), 0);
            return ret;
        }

        /// <summary>
        ///     Plots the histogram using the specified label id
        /// </summary>
        /// <param name="labelId">The label identifier for the plot item</param>
        /// <param name="values">The array of data values to plot</param>
        /// <param name="count">The number of elements</param>
        /// <param name="bins">The number of histogram bins</param>
        /// <param name="barScale">The bar scale</param>
        /// <returns>The double-precision floating-point result</returns>
        public static double PlotHistogram(string labelId, short[] values, int count, int bins, double barScale)
        {
            double ret = ImPlotNative.ImPlot_PlotHistogram_S16Ptr(Encoding.UTF8.GetBytes(labelId), values, count, bins, barScale, new ImPlotRange(), 0);
            return ret;
        }

        /// <summary>
        ///     Plots the histogram using the specified label id
        /// </summary>
        /// <param name="labelId">The label identifier for the plot item</param>
        /// <param name="values">The array of data values to plot</param>
        /// <param name="count">The number of elements</param>
        /// <param name="bins">The number of histogram bins</param>
        /// <param name="barScale">The bar scale</param>
        /// <param name="range">The value range (min, max)</param>
        /// <returns>The double-precision floating-point result</returns>
        public static double PlotHistogram(string labelId, short[] values, int count, int bins, double barScale, ImPlotRange range)
        {
            double ret = ImPlotNative.ImPlot_PlotHistogram_S16Ptr(Encoding.UTF8.GetBytes(labelId), values, count, bins, barScale, range, 0);
            return ret;
        }

        /// <summary>
        ///     Plots the histogram using the specified label id
        /// </summary>
        /// <param name="labelId">The label identifier for the plot item</param>
        /// <param name="values">The array of data values to plot</param>
        /// <param name="count">The number of elements</param>
        /// <param name="bins">The number of histogram bins</param>
        /// <param name="barScale">The bar scale</param>
        /// <param name="range">The value range (min, max)</param>
        /// <param name="flags">The ImGui behavior flags</param>
        /// <returns>The double-precision floating-point result</returns>
        public static double PlotHistogram(string labelId, short[] values, int count, int bins, double barScale, ImPlotRange range, ImPlotHistogramFlags flags)
        {
            double ret = ImPlotNative.ImPlot_PlotHistogram_S16Ptr(Encoding.UTF8.GetBytes(labelId), values, count, bins, barScale, range, flags);
            return ret;
        }

        /// <summary>
        ///     Plots the histogram using the specified label id
        /// </summary>
        /// <param name="labelId">The label identifier for the plot item</param>
        /// <param name="values">The array of data values to plot</param>
        /// <param name="count">The number of elements</param>
        /// <returns>The double-precision floating-point result</returns>
        public static double PlotHistogram(string labelId, ushort[] values, int count)
        {
            double ret = ImPlotNative.ImPlot_PlotHistogram_U16Ptr(Encoding.UTF8.GetBytes(labelId), values, count, 0, 1.0, new ImPlotRange(), 0);
            return ret;
        }

        /// <summary>
        ///     Plots the histogram using the specified label id
        /// </summary>
        /// <param name="labelId">The label identifier for the plot item</param>
        /// <param name="values">The array of data values to plot</param>
        /// <param name="count">The number of elements</param>
        /// <param name="bins">The number of histogram bins</param>
        /// <returns>The double-precision floating-point result</returns>
        public static double PlotHistogram(string labelId, ushort[] values, int count, int bins)
        {
            double ret = ImPlotNative.ImPlot_PlotHistogram_U16Ptr(Encoding.UTF8.GetBytes(labelId), values, count, bins, 1.0, new ImPlotRange(), 0);
            return ret;
        }

        /// <summary>
        ///     Plots the histogram using the specified label id
        /// </summary>
        /// <param name="labelId">The label identifier for the plot item</param>
        /// <param name="values">The array of data values to plot</param>
        /// <param name="count">The number of elements</param>
        /// <param name="bins">The number of histogram bins</param>
        /// <param name="barScale">The bar scale</param>
        /// <returns>The double-precision floating-point result</returns>
        public static double PlotHistogram(string labelId, ushort[] values, int count, int bins, double barScale)
        {
            double ret = ImPlotNative.ImPlot_PlotHistogram_U16Ptr(Encoding.UTF8.GetBytes(labelId), values, count, bins, barScale, new ImPlotRange(), 0);
            return ret;
        }

        /// <summary>
        ///     Plots the histogram using the specified label id
        /// </summary>
        /// <param name="labelId">The label identifier for the plot item</param>
        /// <param name="values">The array of data values to plot</param>
        /// <param name="count">The number of elements</param>
        /// <param name="bins">The number of histogram bins</param>
        /// <param name="barScale">The bar scale</param>
        /// <param name="range">The value range (min, max)</param>
        /// <returns>The double-precision floating-point result</returns>
        public static double PlotHistogram(string labelId, ushort[] values, int count, int bins, double barScale, ImPlotRange range)
        {
            double ret = ImPlotNative.ImPlot_PlotHistogram_U16Ptr(Encoding.UTF8.GetBytes(labelId), values, count, bins, barScale, range, 0);
            return ret;
        }

        /// <summary>
        ///     Plots the histogram using the specified label id
        /// </summary>
        /// <param name="labelId">The label identifier for the plot item</param>
        /// <param name="values">The array of data values to plot</param>
        /// <param name="count">The number of elements</param>
        /// <param name="bins">The number of histogram bins</param>
        /// <param name="barScale">The bar scale</param>
        /// <param name="range">The value range (min, max)</param>
        /// <param name="flags">The ImGui behavior flags</param>
        /// <returns>The double-precision floating-point result</returns>
        public static double PlotHistogram(string labelId, ushort[] values, int count, int bins, double barScale, ImPlotRange range, ImPlotHistogramFlags flags)
        {
            double ret = ImPlotNative.ImPlot_PlotHistogram_U16Ptr(Encoding.UTF8.GetBytes(labelId), values, count, bins, barScale, range, flags);
            return ret;
        }

        /// <summary>
        ///     Plots the histogram using the specified label id
        /// </summary>
        /// <param name="labelId">The label identifier for the plot item</param>
        /// <param name="values">The array of data values to plot</param>
        /// <param name="count">The number of elements</param>
        /// <returns>The double-precision floating-point result</returns>
        public static double PlotHistogram(string labelId, int[] values, int count)
        {
            double ret = ImPlotNative.ImPlot_PlotHistogram_S32Ptr(Encoding.UTF8.GetBytes(labelId), values, count, 0, 1.0, new ImPlotRange(), 0);
            return ret;
        }

        /// <summary>
        ///     Plots the histogram using the specified label id
        /// </summary>
        /// <param name="labelId">The label identifier for the plot item</param>
        /// <param name="values">The array of data values to plot</param>
        /// <param name="count">The number of elements</param>
        /// <param name="bins">The number of histogram bins</param>
        /// <returns>The double-precision floating-point result</returns>
        public static double PlotHistogram(string labelId, int[] values, int count, int bins)
        {
            double ret = ImPlotNative.ImPlot_PlotHistogram_S32Ptr(Encoding.UTF8.GetBytes(labelId), values, count, bins, 1.0, new ImPlotRange(), 0);
            return ret;
        }

        /// <summary>
        ///     Plots the histogram using the specified label id
        /// </summary>
        /// <param name="labelId">The label identifier for the plot item</param>
        /// <param name="values">The array of data values to plot</param>
        /// <param name="count">The number of elements</param>
        /// <param name="bins">The number of histogram bins</param>
        /// <param name="barScale">The bar scale</param>
        /// <returns>The double-precision floating-point result</returns>
        public static double PlotHistogram(string labelId, int[] values, int count, int bins, double barScale)
        {
            double ret = ImPlotNative.ImPlot_PlotHistogram_S32Ptr(Encoding.UTF8.GetBytes(labelId), values, count, bins, barScale, new ImPlotRange(), 0);
            return ret;
        }

        /// <summary>
        ///     Plots the histogram using the specified label id
        /// </summary>
        /// <param name="labelId">The label identifier for the plot item</param>
        /// <param name="values">The array of data values to plot</param>
        /// <param name="count">The number of elements</param>
        /// <param name="bins">The number of histogram bins</param>
        /// <param name="barScale">The bar scale</param>
        /// <param name="range">The value range (min, max)</param>
        /// <returns>The double-precision floating-point result</returns>
        public static double PlotHistogram(string labelId, int[] values, int count, int bins, double barScale, ImPlotRange range)
        {
            double ret = ImPlotNative.ImPlot_PlotHistogram_S32Ptr(Encoding.UTF8.GetBytes(labelId), values, count, bins, barScale, range, 0);
            return ret;
        }

        /// <summary>
        ///     Plots the histogram using the specified label id
        /// </summary>
        /// <param name="labelId">The label identifier for the plot item</param>
        /// <param name="values">The array of data values to plot</param>
        /// <param name="count">The number of elements</param>
        /// <param name="bins">The number of histogram bins</param>
        /// <param name="barScale">The bar scale</param>
        /// <param name="range">The value range (min, max)</param>
        /// <param name="flags">The ImGui behavior flags</param>
        /// <returns>The double-precision floating-point result</returns>
        public static double PlotHistogram(string labelId, int[] values, int count, int bins, double barScale, ImPlotRange range, ImPlotHistogramFlags flags)
        {
            double ret = ImPlotNative.ImPlot_PlotHistogram_S32Ptr(Encoding.UTF8.GetBytes(labelId), values, count, bins, barScale, range, flags);
            return ret;
        }

        /// <summary>
        ///     Plots the histogram using the specified label id
        /// </summary>
        /// <param name="labelId">The label identifier for the plot item</param>
        /// <param name="values">The array of data values to plot</param>
        /// <param name="count">The number of elements</param>
        /// <returns>The double-precision floating-point result</returns>
        public static double PlotHistogram(string labelId, uint[] values, int count)
        {
            double ret = ImPlotNative.ImPlot_PlotHistogram_U32Ptr(Encoding.UTF8.GetBytes(labelId), values, count, 0, 1.0, new ImPlotRange(), 0);
            return ret;
        }

        /// <summary>
        ///     Plots the histogram using the specified label id
        /// </summary>
        /// <param name="labelId">The label identifier for the plot item</param>
        /// <param name="values">The array of data values to plot</param>
        /// <param name="count">The number of elements</param>
        /// <param name="bins">The number of histogram bins</param>
        /// <returns>The double-precision floating-point result</returns>
        public static double PlotHistogram(string labelId, uint[] values, int count, int bins)
        {
            double ret = ImPlotNative.ImPlot_PlotHistogram_U32Ptr(Encoding.UTF8.GetBytes(labelId), values, count, bins, 1.0, new ImPlotRange(), 0);
            return ret;
        }

        /// <summary>
        ///     Plots the histogram using the specified label id
        /// </summary>
        /// <param name="labelId">The label identifier for the plot item</param>
        /// <param name="values">The array of data values to plot</param>
        /// <param name="count">The number of elements</param>
        /// <param name="bins">The number of histogram bins</param>
        /// <param name="barScale">The bar scale</param>
        /// <returns>The double-precision floating-point result</returns>
        public static double PlotHistogram(string labelId, uint[] values, int count, int bins, double barScale)
        {
            double ret = ImPlotNative.ImPlot_PlotHistogram_U32Ptr(Encoding.UTF8.GetBytes(labelId), values, count, bins, barScale, new ImPlotRange(), 0);
            return ret;
        }

        /// <summary>
        ///     Plots the histogram using the specified label id
        /// </summary>
        /// <param name="labelId">The label identifier for the plot item</param>
        /// <param name="values">The array of data values to plot</param>
        /// <param name="count">The number of elements</param>
        /// <param name="bins">The number of histogram bins</param>
        /// <param name="barScale">The bar scale</param>
        /// <param name="range">The value range (min, max)</param>
        /// <returns>The double-precision floating-point result</returns>
        public static double PlotHistogram(string labelId, uint[] values, int count, int bins, double barScale, ImPlotRange range)
        {
            double ret = ImPlotNative.ImPlot_PlotHistogram_U32Ptr(Encoding.UTF8.GetBytes(labelId), values, count, bins, barScale, range, 0);
            return ret;
        }

        /// <summary>
        ///     Plots the histogram using the specified label id
        /// </summary>
        /// <param name="labelId">The label identifier for the plot item</param>
        /// <param name="values">The array of data values to plot</param>
        /// <param name="count">The number of elements</param>
        /// <param name="bins">The number of histogram bins</param>
        /// <param name="barScale">The bar scale</param>
        /// <param name="range">The value range (min, max)</param>
        /// <param name="flags">The ImGui behavior flags</param>
        /// <returns>The double-precision floating-point result</returns>
        public static double PlotHistogram(string labelId, uint[] values, int count, int bins, double barScale, ImPlotRange range, ImPlotHistogramFlags flags)
        {
            double ret = ImPlotNative.ImPlot_PlotHistogram_U32Ptr(Encoding.UTF8.GetBytes(labelId), values, count, bins, barScale, range, flags);
            return ret;
        }

        /// <summary>
        ///     Plots the histogram using the specified label id
        /// </summary>
        /// <param name="labelId">The label identifier for the plot item</param>
        /// <param name="values">The array of data values to plot</param>
        /// <param name="count">The number of elements</param>
        /// <returns>The double-precision floating-point result</returns>
        public static double PlotHistogram(string labelId, long[] values, int count)
        {
            double ret = ImPlotNative.ImPlot_PlotHistogram_S64Ptr(Encoding.UTF8.GetBytes(labelId), values, count, 0, 1.0, new ImPlotRange(), 0);
            return ret;
        }

        /// <summary>
        ///     Plots the histogram using the specified label id
        /// </summary>
        /// <param name="labelId">The label identifier for the plot item</param>
        /// <param name="values">The array of data values to plot</param>
        /// <param name="count">The number of elements</param>
        /// <param name="bins">The number of histogram bins</param>
        /// <returns>The double-precision floating-point result</returns>
        public static double PlotHistogram(string labelId, long[] values, int count, int bins)
        {
            double ret = ImPlotNative.ImPlot_PlotHistogram_S64Ptr(Encoding.UTF8.GetBytes(labelId), values, count, bins, 1.0, new ImPlotRange(), 0);
            return ret;
        }

        /// <summary>
        ///     Plots the histogram using the specified label id
        /// </summary>
        /// <param name="labelId">The label identifier for the plot item</param>
        /// <param name="values">The array of data values to plot</param>
        /// <param name="count">The number of elements</param>
        /// <param name="bins">The number of histogram bins</param>
        /// <param name="barScale">The bar scale</param>
        /// <returns>The double-precision floating-point result</returns>
        public static double PlotHistogram(string labelId, long[] values, int count, int bins, double barScale)
        {
            double ret = ImPlotNative.ImPlot_PlotHistogram_S64Ptr(Encoding.UTF8.GetBytes(labelId), values, count, bins, barScale, new ImPlotRange(), 0);
            return ret;
        }

        /// <summary>
        ///     Plots the histogram using the specified label id
        /// </summary>
        /// <param name="labelId">The label identifier for the plot item</param>
        /// <param name="values">The array of data values to plot</param>
        /// <param name="count">The number of elements</param>
        /// <param name="bins">The number of histogram bins</param>
        /// <param name="barScale">The bar scale</param>
        /// <param name="range">The value range (min, max)</param>
        /// <returns>The double-precision floating-point result</returns>
        public static double PlotHistogram(string labelId, long[] values, int count, int bins, double barScale, ImPlotRange range)
        {
            double ret = ImPlotNative.ImPlot_PlotHistogram_S64Ptr(Encoding.UTF8.GetBytes(labelId), values, count, bins, barScale, range, 0);
            return ret;
        }

        /// <summary>
        ///     Plots the histogram using the specified label id
        /// </summary>
        /// <param name="labelId">The label identifier for the plot item</param>
        /// <param name="values">The array of data values to plot</param>
        /// <param name="count">The number of elements</param>
        /// <param name="bins">The number of histogram bins</param>
        /// <param name="barScale">The bar scale</param>
        /// <param name="range">The value range (min, max)</param>
        /// <param name="flags">The ImGui behavior flags</param>
        /// <returns>The double-precision floating-point result</returns>
        public static double PlotHistogram(string labelId, long[] values, int count, int bins, double barScale, ImPlotRange range, ImPlotHistogramFlags flags)
        {
            double ret = ImPlotNative.ImPlot_PlotHistogram_S64Ptr(Encoding.UTF8.GetBytes(labelId), values, count, bins, barScale, range, flags);
            return ret;
        }

        /// <summary>
        ///     Plots the histogram using the specified label id
        /// </summary>
        /// <param name="labelId">The label identifier for the plot item</param>
        /// <param name="values">The array of data values to plot</param>
        /// <param name="count">The number of elements</param>
        /// <returns>The double-precision floating-point result</returns>
        public static double PlotHistogram(string labelId, ulong[] values, int count)
        {
            double ret = ImPlotNative.ImPlot_PlotHistogram_U64Ptr(Encoding.UTF8.GetBytes(labelId), values, count, 0, 1.0, new ImPlotRange(), 0);
            return ret;
        }

        /// <summary>
        ///     Plots the histogram using the specified label id
        /// </summary>
        /// <param name="labelId">The label identifier for the plot item</param>
        /// <param name="values">The array of data values to plot</param>
        /// <param name="count">The number of elements</param>
        /// <param name="bins">The number of histogram bins</param>
        /// <returns>The double-precision floating-point result</returns>
        public static double PlotHistogram(string labelId, ulong[] values, int count, int bins)
        {
            double ret = ImPlotNative.ImPlot_PlotHistogram_U64Ptr(Encoding.UTF8.GetBytes(labelId), values, count, bins, 1.0, new ImPlotRange(), 0);
            return ret;
        }

        /// <summary>
        ///     Plots the histogram using the specified label id
        /// </summary>
        /// <param name="labelId">The label identifier for the plot item</param>
        /// <param name="values">The array of data values to plot</param>
        /// <param name="count">The number of elements</param>
        /// <param name="bins">The number of histogram bins</param>
        /// <param name="barScale">The bar scale</param>
        /// <returns>The double-precision floating-point result</returns>
        public static double PlotHistogram(string labelId, ulong[] values, int count, int bins, double barScale)
        {
            double ret = ImPlotNative.ImPlot_PlotHistogram_U64Ptr(Encoding.UTF8.GetBytes(labelId), values, count, bins, barScale, new ImPlotRange(), 0);
            return ret;
        }

        /// <summary>
        ///     Plots the histogram using the specified label id
        /// </summary>
        /// <param name="labelId">The label identifier for the plot item</param>
        /// <param name="values">The array of data values to plot</param>
        /// <param name="count">The number of elements</param>
        /// <param name="bins">The number of histogram bins</param>
        /// <param name="barScale">The bar scale</param>
        /// <param name="range">The value range (min, max)</param>
        /// <returns>The double-precision floating-point result</returns>
        public static double PlotHistogram(string labelId, ulong[] values, int count, int bins, double barScale, ImPlotRange range)
        {
            double ret = ImPlotNative.ImPlot_PlotHistogram_U64Ptr(Encoding.UTF8.GetBytes(labelId), values, count, bins, barScale, range, 0);
            return ret;
        }

        /// <summary>
        ///     Plots the histogram using the specified label id
        /// </summary>
        /// <param name="labelId">The label identifier for the plot item</param>
        /// <param name="values">The array of data values to plot</param>
        /// <param name="count">The number of elements</param>
        /// <param name="bins">The number of histogram bins</param>
        /// <param name="barScale">The bar scale</param>
        /// <param name="range">The value range (min, max)</param>
        /// <param name="flags">The ImGui behavior flags</param>
        /// <returns>The double-precision floating-point result</returns>
        public static double PlotHistogram(string labelId, ulong[] values, int count, int bins, double barScale, ImPlotRange range, ImPlotHistogramFlags flags)
        {
            double ret = ImPlotNative.ImPlot_PlotHistogram_U64Ptr(Encoding.UTF8.GetBytes(labelId), values, count, bins, barScale, range, flags);
            return ret;
        }

        /// <summary>
        ///     Plots the histogram 2 d using the specified label id
        /// </summary>
        /// <param name="labelId">The label identifier for the plot item</param>
        /// <param name="xs">The array of x-coordinate values</param>
        /// <param name="ys">The array of y-coordinate values</param>
        /// <param name="count">The number of elements</param>
        /// <returns>The double-precision floating-point result</returns>
        public static double PlotHistogram2D(string labelId, ref float xs, ref float ys, int count)
        {
            double ret = ImPlotNative.ImPlot_PlotHistogram2D_FloatPtr(Encoding.UTF8.GetBytes(labelId), ref xs, ref ys, count, 0, 0, new ImPlotRect(), 0);
            return ret;
        }

        /// <summary>
        ///     Plots the histogram 2 d using the specified label id
        /// </summary>
        /// <param name="labelId">The label identifier for the plot item</param>
        /// <param name="xs">The array of x-coordinate values</param>
        /// <param name="ys">The array of y-coordinate values</param>
        /// <param name="count">The number of elements</param>
        /// <param name="xBins">The number of bins along the x-axis</param>
        /// <returns>The double-precision floating-point result</returns>
        public static double PlotHistogram2D(string labelId, ref float xs, ref float ys, int count, int xBins)
        {
            double ret = ImPlotNative.ImPlot_PlotHistogram2D_FloatPtr(Encoding.UTF8.GetBytes(labelId), ref xs, ref ys, count, xBins, 0, new ImPlotRect(), 0);
            return ret;
        }

        /// <summary>
        ///     Plots the histogram 2 d using the specified label id
        /// </summary>
        /// <param name="labelId">The label identifier for the plot item</param>
        /// <param name="xs">The array of x-coordinate values</param>
        /// <param name="ys">The array of y-coordinate values</param>
        /// <param name="count">The number of elements</param>
        /// <param name="xBins">The number of bins along the x-axis</param>
        /// <param name="yBins">The number of bins along the y-axis</param>
        /// <returns>The double-precision floating-point result</returns>
        public static double PlotHistogram2D(string labelId, ref float xs, ref float ys, int count, int xBins, int yBins)
        {
            double ret = ImPlotNative.ImPlot_PlotHistogram2D_FloatPtr(Encoding.UTF8.GetBytes(labelId), ref xs, ref ys, count, xBins, yBins, new ImPlotRect(), 0);
            return ret;
        }

        /// <summary>
        ///     Plots the histogram 2 d using the specified label id
        /// </summary>
        /// <param name="labelId">The label identifier for the plot item</param>
        /// <param name="xs">The array of x-coordinate values</param>
        /// <param name="ys">The array of y-coordinate values</param>
        /// <param name="count">The number of elements</param>
        /// <param name="xBins">The number of bins along the x-axis</param>
        /// <param name="yBins">The number of bins along the y-axis</param>
        /// <param name="range">The value range (min, max)</param>
        /// <returns>The double-precision floating-point result</returns>
        public static double PlotHistogram2D(string labelId, ref float xs, ref float ys, int count, int xBins, int yBins, ImPlotRect range)
        {
            double ret = ImPlotNative.ImPlot_PlotHistogram2D_FloatPtr(Encoding.UTF8.GetBytes(labelId), ref xs, ref ys, count, xBins, yBins, range, 0);
            return ret;
        }

        /// <summary>
        ///     Plots the histogram 2 d using the specified label id
        /// </summary>
        /// <param name="labelId">The label identifier for the plot item</param>
        /// <param name="xs">The array of x-coordinate values</param>
        /// <param name="ys">The array of y-coordinate values</param>
        /// <param name="count">The number of elements</param>
        /// <param name="xBins">The number of bins along the x-axis</param>
        /// <param name="yBins">The number of bins along the y-axis</param>
        /// <param name="range">The value range (min, max)</param>
        /// <param name="flags">The ImGui behavior flags</param>
        /// <returns>The double-precision floating-point result</returns>
        public static double PlotHistogram2D(string labelId, ref float xs, ref float ys, int count, int xBins, int yBins, ImPlotRect range, ImPlotHistogramFlags flags)
        {
            double ret = ImPlotNative.ImPlot_PlotHistogram2D_FloatPtr(Encoding.UTF8.GetBytes(labelId), ref xs, ref ys, count, xBins, yBins, range, flags);
            return ret;
        }

        /// <summary>
        ///     Plots the histogram 2 d using the specified label id
        /// </summary>
        /// <param name="labelId">The label identifier for the plot item</param>
        /// <param name="xs">The array of x-coordinate values</param>
        /// <param name="ys">The array of y-coordinate values</param>
        /// <param name="count">The number of elements</param>
        /// <returns>The double-precision floating-point result</returns>
        public static double PlotHistogram2D(string labelId, ref double xs, ref double ys, int count)
        {
            double ret = ImPlotNative.ImPlot_PlotHistogram2D_doublePtr(Encoding.UTF8.GetBytes(labelId), ref xs, ref ys, count, 0, 0, new ImPlotRect(), 0);
            return ret;
        }

        /// <summary>
        ///     Plots the histogram 2 d using the specified label id
        /// </summary>
        /// <param name="labelId">The label identifier for the plot item</param>
        /// <param name="xs">The array of x-coordinate values</param>
        /// <param name="ys">The array of y-coordinate values</param>
        /// <param name="count">The number of elements</param>
        /// <param name="xBins">The number of bins along the x-axis</param>
        /// <returns>The double-precision floating-point result</returns>
        public static double PlotHistogram2D(string labelId, ref double xs, ref double ys, int count, int xBins)
        {
            double ret = ImPlotNative.ImPlot_PlotHistogram2D_doublePtr(Encoding.UTF8.GetBytes(labelId), ref xs, ref ys, count, xBins, 0, new ImPlotRect(), 0);
            return ret;
        }

        /// <summary>
        ///     Plots the histogram 2 d using the specified label id
        /// </summary>
        /// <param name="labelId">The label identifier for the plot item</param>
        /// <param name="xs">The array of x-coordinate values</param>
        /// <param name="ys">The array of y-coordinate values</param>
        /// <param name="count">The number of elements</param>
        /// <param name="xBins">The number of bins along the x-axis</param>
        /// <param name="yBins">The number of bins along the y-axis</param>
        /// <returns>The double-precision floating-point result</returns>
        public static double PlotHistogram2D(string labelId, ref double xs, ref double ys, int count, int xBins, int yBins)
        {
            double ret = ImPlotNative.ImPlot_PlotHistogram2D_doublePtr(Encoding.UTF8.GetBytes(labelId), ref xs, ref ys, count, xBins, yBins, new ImPlotRect(), 0);
            return ret;
        }

        /// <summary>
        ///     Plots the histogram 2 d using the specified label id
        /// </summary>
        /// <param name="labelId">The label identifier for the plot item</param>
        /// <param name="xs">The array of x-coordinate values</param>
        /// <param name="ys">The array of y-coordinate values</param>
        /// <param name="count">The number of elements</param>
        /// <param name="xBins">The number of bins along the x-axis</param>
        /// <param name="yBins">The number of bins along the y-axis</param>
        /// <param name="range">The value range (min, max)</param>
        /// <returns>The double-precision floating-point result</returns>
        public static double PlotHistogram2D(string labelId, ref double xs, ref double ys, int count, int xBins, int yBins, ImPlotRect range)
        {
            double ret = ImPlotNative.ImPlot_PlotHistogram2D_doublePtr(Encoding.UTF8.GetBytes(labelId), ref xs, ref ys, count, xBins, yBins, range, 0);
            return ret;
        }

        /// <summary>
        ///     Plots the histogram 2 d using the specified label id
        /// </summary>
        /// <param name="labelId">The label identifier for the plot item</param>
        /// <param name="xs">The array of x-coordinate values</param>
        /// <param name="ys">The array of y-coordinate values</param>
        /// <param name="count">The number of elements</param>
        /// <param name="xBins">The number of bins along the x-axis</param>
        /// <param name="yBins">The number of bins along the y-axis</param>
        /// <param name="range">The value range (min, max)</param>
        /// <param name="flags">The ImGui behavior flags</param>
        /// <returns>The double-precision floating-point result</returns>
        public static double PlotHistogram2D(string labelId, ref double xs, ref double ys, int count, int xBins, int yBins, ImPlotRect range, ImPlotHistogramFlags flags)
        {
            double ret = ImPlotNative.ImPlot_PlotHistogram2D_doublePtr(Encoding.UTF8.GetBytes(labelId), ref xs, ref ys, count, xBins, yBins, range, flags);
            return ret;
        }

        /// <summary>
        ///     Plots the histogram 2 d using the specified label id
        /// </summary>
        /// <param name="labelId">The label identifier for the plot item</param>
        /// <param name="xs">The array of x-coordinate values</param>
        /// <param name="ys">The array of y-coordinate values</param>
        /// <param name="count">The number of elements</param>
        /// <returns>The double-precision floating-point result</returns>
        public static double PlotHistogram2D(string labelId, ref sbyte xs, ref sbyte ys, int count)
        {
            double ret = ImPlotNative.ImPlot_PlotHistogram2D_S8Ptr(Encoding.UTF8.GetBytes(labelId), ref xs, ref ys, count, 0, 0, new ImPlotRect(), 0);
            return ret;
        }

        /// <summary>
        ///     Plots the histogram 2 d using the specified label id
        /// </summary>
        /// <param name="labelId">The label identifier for the plot item</param>
        /// <param name="xs">The array of x-coordinate values</param>
        /// <param name="ys">The array of y-coordinate values</param>
        /// <param name="count">The number of elements</param>
        /// <param name="xBins">The number of bins along the x-axis</param>
        /// <returns>The double-precision floating-point result</returns>
        public static double PlotHistogram2D(string labelId, ref sbyte xs, ref sbyte ys, int count, int xBins)
        {
            double ret = ImPlotNative.ImPlot_PlotHistogram2D_S8Ptr(Encoding.UTF8.GetBytes(labelId), ref xs, ref ys, count, xBins, 0, new ImPlotRect(), 0);
            return ret;
        }

        /// <summary>
        ///     Plots the histogram 2 d using the specified label id
        /// </summary>
        /// <param name="labelId">The label identifier for the plot item</param>
        /// <param name="xs">The array of x-coordinate values</param>
        /// <param name="ys">The array of y-coordinate values</param>
        /// <param name="count">The number of elements</param>
        /// <param name="xBins">The number of bins along the x-axis</param>
        /// <param name="yBins">The number of bins along the y-axis</param>
        /// <returns>The double-precision floating-point result</returns>
        public static double PlotHistogram2D(string labelId, ref sbyte xs, ref sbyte ys, int count, int xBins, int yBins)
        {
            double ret = ImPlotNative.ImPlot_PlotHistogram2D_S8Ptr(Encoding.UTF8.GetBytes(labelId), ref xs, ref ys, count, xBins, yBins, new ImPlotRect(), 0);
            return ret;
        }

        /// <summary>
        ///     Plots the histogram 2 d using the specified label id
        /// </summary>
        /// <param name="labelId">The label identifier for the plot item</param>
        /// <param name="xs">The array of x-coordinate values</param>
        /// <param name="ys">The array of y-coordinate values</param>
        /// <param name="count">The number of elements</param>
        /// <param name="xBins">The number of bins along the x-axis</param>
        /// <param name="yBins">The number of bins along the y-axis</param>
        /// <param name="range">The value range (min, max)</param>
        /// <returns>The double-precision floating-point result</returns>
        public static double PlotHistogram2D(string labelId, ref sbyte xs, ref sbyte ys, int count, int xBins, int yBins, ImPlotRect range)
        {
            double ret = ImPlotNative.ImPlot_PlotHistogram2D_S8Ptr(Encoding.UTF8.GetBytes(labelId), ref xs, ref ys, count, xBins, yBins, range, 0);
            return ret;
        }

        /// <summary>
        ///     Plots the histogram 2 d using the specified label id
        /// </summary>
        /// <param name="labelId">The label identifier for the plot item</param>
        /// <param name="xs">The array of x-coordinate values</param>
        /// <param name="ys">The array of y-coordinate values</param>
        /// <param name="count">The number of elements</param>
        /// <param name="xBins">The number of bins along the x-axis</param>
        /// <param name="yBins">The number of bins along the y-axis</param>
        /// <param name="range">The value range (min, max)</param>
        /// <param name="flags">The ImGui behavior flags</param>
        /// <returns>The double-precision floating-point result</returns>
        public static double PlotHistogram2D(string labelId, ref sbyte xs, ref sbyte ys, int count, int xBins, int yBins, ImPlotRect range, ImPlotHistogramFlags flags)
        {
            double ret = ImPlotNative.ImPlot_PlotHistogram2D_S8Ptr(Encoding.UTF8.GetBytes(labelId), ref xs, ref ys, count, xBins, yBins, range, flags);
            return ret;
        }

        /// <summary>
        ///     Plots the histogram 2 d using the specified label id
        /// </summary>
        /// <param name="labelId">The label identifier for the plot item</param>
        /// <param name="xs">The array of x-coordinate values</param>
        /// <param name="ys">The array of y-coordinate values</param>
        /// <param name="count">The number of elements</param>
        /// <returns>The double-precision floating-point result</returns>
        public static double PlotHistogram2D(string labelId, ref byte xs, ref byte ys, int count)
        {
            double ret = ImPlotNative.ImPlot_PlotHistogram2D_U8Ptr(Encoding.UTF8.GetBytes(labelId), ref xs, ref ys, count, 0, 0, new ImPlotRect(), 0);
            return ret;
        }

        /// <summary>
        ///     Plots the histogram 2 d using the specified label id
        /// </summary>
        /// <param name="labelId">The label identifier for the plot item</param>
        /// <param name="xs">The array of x-coordinate values</param>
        /// <param name="ys">The array of y-coordinate values</param>
        /// <param name="count">The number of elements</param>
        /// <param name="xBins">The number of bins along the x-axis</param>
        /// <returns>The double-precision floating-point result</returns>
        public static double PlotHistogram2D(string labelId, ref byte xs, ref byte ys, int count, int xBins)
        {
            double ret = ImPlotNative.ImPlot_PlotHistogram2D_U8Ptr(Encoding.UTF8.GetBytes(labelId), ref xs, ref ys, count, xBins, 0, new ImPlotRect(), 0);
            return ret;
        }

        /// <summary>
        ///     Plots the histogram 2 d using the specified label id
        /// </summary>
        /// <param name="labelId">The label identifier for the plot item</param>
        /// <param name="xs">The array of x-coordinate values</param>
        /// <param name="ys">The array of y-coordinate values</param>
        /// <param name="count">The number of elements</param>
        /// <param name="xBins">The number of bins along the x-axis</param>
        /// <param name="yBins">The number of bins along the y-axis</param>
        /// <returns>The double-precision floating-point result</returns>
        public static double PlotHistogram2D(string labelId, ref byte xs, ref byte ys, int count, int xBins, int yBins)
        {
            double ret = ImPlotNative.ImPlot_PlotHistogram2D_U8Ptr(Encoding.UTF8.GetBytes(labelId), ref xs, ref ys, count, xBins, yBins, new ImPlotRect(), 0);
            return ret;
        }
    }
}