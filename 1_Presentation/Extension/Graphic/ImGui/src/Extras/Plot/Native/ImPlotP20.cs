// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImPlotP20.cs
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
      /// The im plot class
      /// </summary>
      public static partial class ImPlot
    {
        
        /// <summary>
        ///     Plots the heatmap using the specified label id
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
        public static void PlotHeatmap(string labelId, ref int values, int rows, int cols, double scaleMin, double scaleMax, string labelFmt, ImPlotPoint boundsMin, ImPlotPoint boundsMax)
        {
            ImPlotNative.ImPlot_PlotHeatmap_S32Ptr(Encoding.UTF8.GetBytes(labelId), ref values, rows, cols, scaleMin, scaleMax, Encoding.UTF8.GetBytes(labelFmt), boundsMin, boundsMax, 0);
        }
        
        /// <summary>
        ///     Plots the heatmap using the specified label id
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
        public static void PlotHeatmap(string labelId, ref int values, int rows, int cols, double scaleMin, double scaleMax, string labelFmt, ImPlotPoint boundsMin, ImPlotPoint boundsMax, ImPlotHeatmapFlags flags)
        {
            ImPlotNative.ImPlot_PlotHeatmap_S32Ptr(Encoding.UTF8.GetBytes(labelId), ref values, rows, cols, scaleMin, scaleMax, Encoding.UTF8.GetBytes(labelFmt), boundsMin, boundsMax, flags);
        }
        
        /// <summary>
        ///     Plots the heatmap using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="rows">The rows</param>
        /// <param name="cols">The cols</param>
        public static void PlotHeatmap(string labelId, ref uint values, int rows, int cols)
        {
            ImPlotNative.ImPlot_PlotHeatmap_U32Ptr(Encoding.UTF8.GetBytes(labelId), ref values, rows, cols, 0, 0, Encoding.UTF8.GetBytes("%.1f"), new ImPlotPoint {X = 0, Y = 0}, new ImPlotPoint {X = 1, Y = 1}, 0);
        }
        
        /// <summary>
        ///     Plots the heatmap using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="rows">The rows</param>
        /// <param name="cols">The cols</param>
        /// <param name="scaleMin">The scale min</param>
        public static void PlotHeatmap(string labelId, ref uint values, int rows, int cols, double scaleMin)
        {
            ImPlotNative.ImPlot_PlotHeatmap_U32Ptr(Encoding.UTF8.GetBytes(labelId), ref values, rows, cols, scaleMin, 0, Encoding.UTF8.GetBytes("%.1f"), new ImPlotPoint {X = 0, Y = 0}, new ImPlotPoint {X = 1, Y = 1}, 0);
        }
        
        /// <summary>
        ///     Plots the heatmap using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="rows">The rows</param>
        /// <param name="cols">The cols</param>
        /// <param name="scaleMin">The scale min</param>
        /// <param name="scaleMax">The scale max</param>
        public static void PlotHeatmap(string labelId, ref uint values, int rows, int cols, double scaleMin, double scaleMax)
        {
            ImPlotNative.ImPlot_PlotHeatmap_U32Ptr(Encoding.UTF8.GetBytes(labelId), ref values, rows, cols, scaleMin, scaleMax, Encoding.UTF8.GetBytes("%.1f"), new ImPlotPoint {X = 0, Y = 0}, new ImPlotPoint {X = 1, Y = 1}, 0);
        }
        
        /// <summary>
        ///     Plots the heatmap using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="rows">The rows</param>
        /// <param name="cols">The cols</param>
        /// <param name="scaleMin">The scale min</param>
        /// <param name="scaleMax">The scale max</param>
        /// <param name="labelFmt">The label fmt</param>
        public static void PlotHeatmap(string labelId, ref uint values, int rows, int cols, double scaleMin, double scaleMax, string labelFmt)
        {
            ImPlotNative.ImPlot_PlotHeatmap_U32Ptr(Encoding.UTF8.GetBytes(labelId), ref values, rows, cols, scaleMin, scaleMax, Encoding.UTF8.GetBytes(labelFmt), new ImPlotPoint {X = 0, Y = 0}, new ImPlotPoint {X = 1, Y = 1}, 0);
        }
        
        /// <summary>
        ///     Plots the heatmap using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="rows">The rows</param>
        /// <param name="cols">The cols</param>
        /// <param name="scaleMin">The scale min</param>
        /// <param name="scaleMax">The scale max</param>
        /// <param name="labelFmt">The label fmt</param>
        /// <param name="boundsMin">The bounds min</param>
        public static void PlotHeatmap(string labelId, ref uint values, int rows, int cols, double scaleMin, double scaleMax, string labelFmt, ImPlotPoint boundsMin)
        {
            ImPlotNative.ImPlot_PlotHeatmap_U32Ptr(Encoding.UTF8.GetBytes(labelId), ref values, rows, cols, scaleMin, scaleMax, Encoding.UTF8.GetBytes(labelFmt), boundsMin, new ImPlotPoint {X = 1, Y = 1}, 0);
        }
        
        /// <summary>
        ///     Plots the heatmap using the specified label id
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
        public static void PlotHeatmap(string labelId, ref uint values, int rows, int cols, double scaleMin, double scaleMax, string labelFmt, ImPlotPoint boundsMin, ImPlotPoint boundsMax)
        {
            ImPlotNative.ImPlot_PlotHeatmap_U32Ptr(Encoding.UTF8.GetBytes(labelId), ref values, rows, cols, scaleMin, scaleMax, Encoding.UTF8.GetBytes(labelFmt), boundsMin, boundsMax, 0);
        }
        
        /// <summary>
        ///     Plots the heatmap using the specified label id
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
        public static void PlotHeatmap(string labelId, ref uint values, int rows, int cols, double scaleMin, double scaleMax, string labelFmt, ImPlotPoint boundsMin, ImPlotPoint boundsMax, ImPlotHeatmapFlags flags)
        {
            ImPlotNative.ImPlot_PlotHeatmap_U32Ptr(Encoding.UTF8.GetBytes(labelId), ref values, rows, cols, scaleMin, scaleMax, Encoding.UTF8.GetBytes(labelFmt), boundsMin, boundsMax, flags);
        }
        
        /// <summary>
        ///     Plots the heatmap using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="rows">The rows</param>
        /// <param name="cols">The cols</param>
        public static void PlotHeatmap(string labelId, ref long values, int rows, int cols)
        {
            ImPlotNative.ImPlot_PlotHeatmap_S64Ptr(Encoding.UTF8.GetBytes(labelId), ref values, rows, cols, 0, 0, Encoding.UTF8.GetBytes("%.1f"), new ImPlotPoint {X = 0, Y = 0}, new ImPlotPoint {X = 1, Y = 1}, 0);
        }
        
        /// <summary>
        ///     Plots the heatmap using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="rows">The rows</param>
        /// <param name="cols">The cols</param>
        /// <param name="scaleMin">The scale min</param>
        public static void PlotHeatmap(string labelId, ref long values, int rows, int cols, double scaleMin)
        {
            ImPlotNative.ImPlot_PlotHeatmap_S64Ptr(Encoding.UTF8.GetBytes(labelId), ref values, rows, cols, scaleMin, 0, Encoding.UTF8.GetBytes("%.1f"), new ImPlotPoint {X = 0, Y = 0}, new ImPlotPoint {X = 1, Y = 1}, 0);
        }
        
        /// <summary>
        ///     Plots the heatmap using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="rows">The rows</param>
        /// <param name="cols">The cols</param>
        /// <param name="scaleMin">The scale min</param>
        /// <param name="scaleMax">The scale max</param>
        public static void PlotHeatmap(string labelId, ref long values, int rows, int cols, double scaleMin, double scaleMax)
        {
            ImPlotNative.ImPlot_PlotHeatmap_S64Ptr(Encoding.UTF8.GetBytes(labelId), ref values, rows, cols, scaleMin, scaleMax, Encoding.UTF8.GetBytes("%.1f"), new ImPlotPoint {X = 0, Y = 0}, new ImPlotPoint {X = 1, Y = 1}, 0);
        }
        
        /// <summary>
        ///     Plots the heatmap using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="rows">The rows</param>
        /// <param name="cols">The cols</param>
        /// <param name="scaleMin">The scale min</param>
        /// <param name="scaleMax">The scale max</param>
        /// <param name="labelFmt">The label fmt</param>
        public static void PlotHeatmap(string labelId, ref long values, int rows, int cols, double scaleMin, double scaleMax, string labelFmt)
        {
            ImPlotNative.ImPlot_PlotHeatmap_S64Ptr(Encoding.UTF8.GetBytes(labelId), ref values, rows, cols, scaleMin, scaleMax, Encoding.UTF8.GetBytes(labelFmt), new ImPlotPoint {X = 0, Y = 0}, new ImPlotPoint {X = 1, Y = 1}, 0);
        }
        
        /// <summary>
        ///     Plots the heatmap using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="rows">The rows</param>
        /// <param name="cols">The cols</param>
        /// <param name="scaleMin">The scale min</param>
        /// <param name="scaleMax">The scale max</param>
        /// <param name="labelFmt">The label fmt</param>
        /// <param name="boundsMin">The bounds min</param>
        public static void PlotHeatmap(string labelId, ref long values, int rows, int cols, double scaleMin, double scaleMax, string labelFmt, ImPlotPoint boundsMin)
        {
            ImPlotNative.ImPlot_PlotHeatmap_S64Ptr(Encoding.UTF8.GetBytes(labelId), ref values, rows, cols, scaleMin, scaleMax, Encoding.UTF8.GetBytes(labelFmt), boundsMin, new ImPlotPoint {X = 1, Y = 1}, 0);
        }
        
        /// <summary>
        ///     Plots the heatmap using the specified label id
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
        public static void PlotHeatmap(string labelId, ref long values, int rows, int cols, double scaleMin, double scaleMax, string labelFmt, ImPlotPoint boundsMin, ImPlotPoint boundsMax)
        {
            ImPlotNative.ImPlot_PlotHeatmap_S64Ptr(Encoding.UTF8.GetBytes(labelId), ref values, rows, cols, scaleMin, scaleMax, Encoding.UTF8.GetBytes(labelFmt), boundsMin, boundsMax, 0);
        }
        
        /// <summary>
        ///     Plots the heatmap using the specified label id
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
        public static void PlotHeatmap(string labelId, ref long values, int rows, int cols, double scaleMin, double scaleMax, string labelFmt, ImPlotPoint boundsMin, ImPlotPoint boundsMax, ImPlotHeatmapFlags flags)
        {
            ImPlotNative.ImPlot_PlotHeatmap_S64Ptr(Encoding.UTF8.GetBytes(labelId), ref values, rows, cols, scaleMin, scaleMax, Encoding.UTF8.GetBytes(labelFmt), boundsMin, boundsMax, flags);
        }
        
        /// <summary>
        ///     Plots the heatmap using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="rows">The rows</param>
        /// <param name="cols">The cols</param>
        public static void PlotHeatmap(string labelId, ref ulong values, int rows, int cols)
        {
            ImPlotNative.ImPlot_PlotHeatmap_U64Ptr(Encoding.UTF8.GetBytes(labelId), ref values, rows, cols, 0, 0, Encoding.UTF8.GetBytes("%.1f"), new ImPlotPoint {X = 0, Y = 0}, new ImPlotPoint {X = 1, Y = 1}, 0);
        }
        
        /// <summary>
        ///     Plots the heatmap using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="rows">The rows</param>
        /// <param name="cols">The cols</param>
        /// <param name="scaleMin">The scale min</param>
        public static void PlotHeatmap(string labelId, ref ulong values, int rows, int cols, double scaleMin)
        {
            ImPlotNative.ImPlot_PlotHeatmap_U64Ptr(Encoding.UTF8.GetBytes(labelId), ref values, rows, cols, scaleMin, 0, Encoding.UTF8.GetBytes("%.1f"), new ImPlotPoint {X = 0, Y = 0}, new ImPlotPoint {X = 1, Y = 1}, 0);
        }
        
        /// <summary>
        ///     Plots the heatmap using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="rows">The rows</param>
        /// <param name="cols">The cols</param>
        /// <param name="scaleMin">The scale min</param>
        /// <param name="scaleMax">The scale max</param>
        public static void PlotHeatmap(string labelId, ref ulong values, int rows, int cols, double scaleMin, double scaleMax)
        {
            ImPlotNative.ImPlot_PlotHeatmap_U64Ptr(Encoding.UTF8.GetBytes(labelId), ref values, rows, cols, scaleMin, scaleMax, Encoding.UTF8.GetBytes("%.1f"), new ImPlotPoint {X = 0, Y = 0}, new ImPlotPoint {X = 1, Y = 1}, 0);
        }
        
        /// <summary>
        ///     Plots the heatmap using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="rows">The rows</param>
        /// <param name="cols">The cols</param>
        /// <param name="scaleMin">The scale min</param>
        /// <param name="scaleMax">The scale max</param>
        /// <param name="labelFmt">The label fmt</param>
        public static void PlotHeatmap(string labelId, ref ulong values, int rows, int cols, double scaleMin, double scaleMax, string labelFmt)
        {
            ImPlotNative.ImPlot_PlotHeatmap_U64Ptr(Encoding.UTF8.GetBytes(labelId), ref values, rows, cols, scaleMin, scaleMax, Encoding.UTF8.GetBytes(labelFmt), new ImPlotPoint {X = 0, Y = 0}, new ImPlotPoint {X = 1, Y = 1}, 0);
        }
        
        /// <summary>
        ///     Plots the heatmap using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="rows">The rows</param>
        /// <param name="cols">The cols</param>
        /// <param name="scaleMin">The scale min</param>
        /// <param name="scaleMax">The scale max</param>
        /// <param name="labelFmt">The label fmt</param>
        /// <param name="boundsMin">The bounds min</param>
        public static void PlotHeatmap(string labelId, ref ulong values, int rows, int cols, double scaleMin, double scaleMax, string labelFmt, ImPlotPoint boundsMin)
        {
            ImPlotNative.ImPlot_PlotHeatmap_U64Ptr(Encoding.UTF8.GetBytes(labelId), ref values, rows, cols, scaleMin, scaleMax, Encoding.UTF8.GetBytes(labelFmt), boundsMin, new ImPlotPoint {X = 1, Y = 1}, 0);
        }
        
        /// <summary>
        ///     Plots the heatmap using the specified label id
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
        public static void PlotHeatmap(string labelId, ref ulong values, int rows, int cols, double scaleMin, double scaleMax, string labelFmt, ImPlotPoint boundsMin, ImPlotPoint boundsMax)
        {
            ImPlotNative.ImPlot_PlotHeatmap_U64Ptr(Encoding.UTF8.GetBytes(labelId), ref values, rows, cols, scaleMin, scaleMax, Encoding.UTF8.GetBytes(labelFmt), boundsMin, boundsMax, 0);
        }
        
        /// <summary>
        ///     Plots the heatmap using the specified label id
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
        public static void PlotHeatmap(string labelId, ref ulong values, int rows, int cols, double scaleMin, double scaleMax, string labelFmt, ImPlotPoint boundsMin, ImPlotPoint boundsMax, ImPlotHeatmapFlags flags)
        {
            ImPlotNative.ImPlot_PlotHeatmap_U64Ptr(Encoding.UTF8.GetBytes(labelId), ref values, rows, cols, scaleMin, scaleMax, Encoding.UTF8.GetBytes(labelFmt), boundsMin, boundsMax, flags);
        }
        
        /// <summary>
        ///     Plots the histogram using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <returns>The double</returns>
        public static double PlotHistogram(string labelId, ref float values, int count)
        {
            return ImPlotNative.ImPlot_PlotHistogram_FloatPtr(Encoding.UTF8.GetBytes(labelId), ref values, count, 0, 1.0, new ImPlotRange {Min = 0, Max = 0}, 0);
        }
        
        /// <summary>
        ///     Plots the histogram using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="bins">The bins</param>
        /// <returns>The double</returns>
        public static double PlotHistogram(string labelId, ref float values, int count, int bins)
        {
            return ImPlotNative.ImPlot_PlotHistogram_FloatPtr(Encoding.UTF8.GetBytes(labelId), ref values, count, bins, 1.0, new ImPlotRange {Min = 0, Max = 0}, 0);
        }
        
        /// <summary>
        ///     Plots the histogram using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="bins">The bins</param>
        /// <param name="barScale">The bar scale</param>
        /// <returns>The double</returns>
        public static double PlotHistogram(string labelId, ref float values, int count, int bins, double barScale)
        {
            return ImPlotNative.ImPlot_PlotHistogram_FloatPtr(Encoding.UTF8.GetBytes(labelId), ref values, count, bins, barScale, new ImPlotRange {Min = 0, Max = 0}, 0);
        }
        
        /// <summary>
        ///     Plots the histogram using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="bins">The bins</param>
        /// <param name="barScale">The bar scale</param>
        /// <param name="range">The range</param>
        /// <returns>The double</returns>
        public static double PlotHistogram(string labelId, ref float values, int count, int bins, double barScale, ImPlotRange range)
        {
            return ImPlotNative.ImPlot_PlotHistogram_FloatPtr(Encoding.UTF8.GetBytes(labelId), ref values, count, bins, barScale, range, 0);
        }
        
        /// <summary>
        ///     Plots the histogram using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="bins">The bins</param>
        /// <param name="barScale">The bar scale</param>
        /// <param name="range">The range</param>
        /// <param name="flags">The flags</param>
        /// <returns>The double</returns>
        public static double PlotHistogram(string labelId, ref float values, int count, int bins, double barScale, ImPlotRange range, ImPlotHistogramFlags flags)
        {
            return ImPlotNative.ImPlot_PlotHistogram_FloatPtr(Encoding.UTF8.GetBytes(labelId), ref values, count, bins, barScale, range, flags);
        }
        
        /// <summary>
        ///     Plots the histogram using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <returns>The double</returns>
        public static double PlotHistogram(string labelId, ref double values, int count)
        {
            return ImPlotNative.ImPlot_PlotHistogram_doublePtr(Encoding.UTF8.GetBytes(labelId), ref values, count, 0, 1.0, new ImPlotRange {Min = 0, Max = 0}, 0);
        }
        
        /// <summary>
        ///     Plots the histogram using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="bins">The bins</param>
        /// <returns>The double</returns>
        public static double PlotHistogram(string labelId, ref double values, int count, int bins)
        {
            return ImPlotNative.ImPlot_PlotHistogram_doublePtr(Encoding.UTF8.GetBytes(labelId), ref values, count, bins, 1.0, new ImPlotRange {Min = 0, Max = 0}, 0);
        }
        
        /// <summary>
        ///     Plots the histogram using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="bins">The bins</param>
        /// <param name="barScale">The bar scale</param>
        /// <returns>The double</returns>
        public static double PlotHistogram(string labelId, ref double values, int count, int bins, double barScale)
        {
            return ImPlotNative.ImPlot_PlotHistogram_doublePtr(Encoding.UTF8.GetBytes(labelId), ref values, count, bins, barScale, new ImPlotRange {Min = 0, Max = 0}, 0);
        }
        
        /// <summary>
        ///     Plots the histogram using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="bins">The bins</param>
        /// <param name="barScale">The bar scale</param>
        /// <param name="range">The range</param>
        /// <returns>The double</returns>
        public static double PlotHistogram(string labelId, ref double values, int count, int bins, double barScale, ImPlotRange range)
        {
            return ImPlotNative.ImPlot_PlotHistogram_doublePtr(Encoding.UTF8.GetBytes(labelId), ref values, count, bins, barScale, range, 0);
        }
        
        /// <summary>
        ///     Plots the histogram using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="bins">The bins</param>
        /// <param name="barScale">The bar scale</param>
        /// <param name="range">The range</param>
        /// <param name="flags">The flags</param>
        /// <returns>The double</returns>
        public static double PlotHistogram(string labelId, ref double values, int count, int bins, double barScale, ImPlotRange range, ImPlotHistogramFlags flags)
        {
            return ImPlotNative.ImPlot_PlotHistogram_doublePtr(Encoding.UTF8.GetBytes(labelId), ref values, count, bins, barScale, range, flags);
        }
        
        /// <summary>
        ///     Plots the histogram using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <returns>The double</returns>
        public static double PlotHistogram(string labelId, ref sbyte values, int count)
        {
            return ImPlotNative.ImPlot_PlotHistogram_S8Ptr(Encoding.UTF8.GetBytes(labelId), ref values, count, 0, 1.0, new ImPlotRange {Min = 0, Max = 0}, 0);
        }
        
        /// <summary>
        ///     Plots the histogram using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="bins">The bins</param>
        /// <returns>The double</returns>
        public static double PlotHistogram(string labelId, ref sbyte values, int count, int bins)
        {
            return ImPlotNative.ImPlot_PlotHistogram_S8Ptr(Encoding.UTF8.GetBytes(labelId), ref values, count, bins, 1.0, new ImPlotRange {Min = 0, Max = 0}, 0);
        }
        
        /// <summary>
        ///     Plots the histogram using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="bins">The bins</param>
        /// <param name="barScale">The bar scale</param>
        /// <returns>The double</returns>
        public static double PlotHistogram(string labelId, ref sbyte values, int count, int bins, double barScale)
        {
            return ImPlotNative.ImPlot_PlotHistogram_S8Ptr(Encoding.UTF8.GetBytes(labelId), ref values, count, bins, barScale, new ImPlotRange {Min = 0, Max = 0}, 0);
        }
        
        /// <summary>
        ///     Plots the histogram using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="bins">The bins</param>
        /// <param name="barScale">The bar scale</param>
        /// <param name="range">The range</param>
        /// <returns>The double</returns>
        public static double PlotHistogram(string labelId, ref sbyte values, int count, int bins, double barScale, ImPlotRange range)
        {
            return ImPlotNative.ImPlot_PlotHistogram_S8Ptr(Encoding.UTF8.GetBytes(labelId), ref values, count, bins, barScale, range, 0);
        }
        
        /// <summary>
        ///     Plots the histogram using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="bins">The bins</param>
        /// <param name="barScale">The bar scale</param>
        /// <param name="range">The range</param>
        /// <param name="flags">The flags</param>
        /// <returns>The double</returns>
        public static double PlotHistogram(string labelId, ref sbyte values, int count, int bins, double barScale, ImPlotRange range, ImPlotHistogramFlags flags)
        {
            return ImPlotNative.ImPlot_PlotHistogram_S8Ptr(Encoding.UTF8.GetBytes(labelId), ref values, count, bins, barScale, range, flags);
        }
        
        /// <summary>
        ///     Plots the histogram using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <returns>The double</returns>
        public static double PlotHistogram(string labelId, ref byte values, int count)
        {
            return ImPlotNative.ImPlot_PlotHistogram_U8Ptr(Encoding.UTF8.GetBytes(labelId), ref values, count, 0, 1.0, new ImPlotRange {Min = 0, Max = 0}, 0);
        }
        
        /// <summary>
        ///     Plots the histogram using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="bins">The bins</param>
        /// <returns>The double</returns>
        public static double PlotHistogram(string labelId, ref byte values, int count, int bins)
        {
            return ImPlotNative.ImPlot_PlotHistogram_U8Ptr(Encoding.UTF8.GetBytes(labelId), ref values, count, bins, 1.0, new ImPlotRange {Min = 0, Max = 0}, 0);
        }
        
        /// <summary>
        ///     Plots the histogram using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="bins">The bins</param>
        /// <param name="barScale">The bar scale</param>
        /// <returns>The double</returns>
        public static double PlotHistogram(string labelId, ref byte values, int count, int bins, double barScale)
        {
            return ImPlotNative.ImPlot_PlotHistogram_U8Ptr(Encoding.UTF8.GetBytes(labelId), ref values, count, bins, barScale, new ImPlotRange {Min = 0, Max = 0}, 0);
        }
    }
}