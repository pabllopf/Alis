// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImPlotP18.cs
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
        ///     Plots the histogram 2 d using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="count">The count</param>
        /// <param name="xBins">The bins</param>
        /// <param name="yBins">The bins</param>
        /// <param name="range">The range</param>
        /// <returns>The double</returns>
        public static double PlotHistogram2D(string labelId, ref byte xs, ref byte ys, int count, int xBins, int yBins, ImPlotRect range)
        {
            return ImPlotNative.ImPlot_PlotHistogram2D_U8Ptr(Encoding.UTF8.GetBytes(labelId), ref xs, ref ys, count, xBins, yBins, range, 0);
        }
        
        /// <summary>
        ///     Plots the histogram 2 d using the specified label id
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
        public static double PlotHistogram2D(string labelId, ref byte xs, ref byte ys, int count, int xBins, int yBins, ImPlotRect range, ImPlotHistogramFlags flags)
        {
            return  ImPlotNative.ImPlot_PlotHistogram2D_U8Ptr(Encoding.UTF8.GetBytes(labelId), ref xs, ref ys, count, xBins, yBins, range, flags);
        }
        
        /// <summary>
        ///     Plots the histogram 2 d using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="count">The count</param>
        /// <returns>The double</returns>
        public static double PlotHistogram2D(string labelId, ref short xs, ref short ys, int count)
        {
            return   ImPlotNative.ImPlot_PlotHistogram2D_S16Ptr(Encoding.UTF8.GetBytes(labelId), ref xs, ref ys, count, (int) ImPlotBin.Sturges, (int) ImPlotBin.Sturges, new ImPlotRect(), 0);
        }
        
        /// <summary>
        ///     Plots the histogram 2 d using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="count">The count</param>
        /// <param name="xBins">The bins</param>
        /// <returns>The double</returns>
        public static double PlotHistogram2D(string labelId, ref short xs, ref short ys, int count, int xBins)
        {
            return  ImPlotNative.ImPlot_PlotHistogram2D_S16Ptr(Encoding.UTF8.GetBytes(labelId), ref xs, ref ys, count, xBins, (int) ImPlotBin.Sturges, new ImPlotRect(), 0);
        }
        
        /// <summary>
        ///     Plots the histogram 2 d using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="count">The count</param>
        /// <param name="xBins">The bins</param>
        /// <param name="yBins">The bins</param>
        /// <returns>The double</returns>
        public static double PlotHistogram2D(string labelId, ref short xs, ref short ys, int count, int xBins, int yBins)
        {
            return   ImPlotNative.ImPlot_PlotHistogram2D_S16Ptr(Encoding.UTF8.GetBytes(labelId), ref xs, ref ys, count, xBins, yBins, new ImPlotRect(), 0);
        }
        
        /// <summary>
        ///     Plots the histogram 2 d using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="count">The count</param>
        /// <param name="xBins">The bins</param>
        /// <param name="yBins">The bins</param>
        /// <param name="range">The range</param>
        /// <returns>The double</returns>
        public static double PlotHistogram2D(string labelId, ref short xs, ref short ys, int count, int xBins, int yBins, ImPlotRect range)
        {
            return    ImPlotNative.ImPlot_PlotHistogram2D_S16Ptr(Encoding.UTF8.GetBytes(labelId), ref xs, ref ys, count, xBins, yBins, range, 0);
        }
        
        /// <summary>
        ///     Plots the histogram 2 d using the specified label id
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
        public static double PlotHistogram2D(string labelId, ref short xs, ref short ys, int count, int xBins, int yBins, ImPlotRect range, ImPlotHistogramFlags flags)
        {
            return  ImPlotNative.ImPlot_PlotHistogram2D_S16Ptr(Encoding.UTF8.GetBytes(labelId), ref xs, ref ys, count, xBins, yBins, range, flags);
        }
        
        /// <summary>
        ///     Plots the histogram 2 d using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="count">The count</param>
        /// <returns>The double</returns>
        public static double PlotHistogram2D(string labelId, ref ushort xs, ref ushort ys, int count)
        {
            return    ImPlotNative.ImPlot_PlotHistogram2D_U16Ptr(Encoding.UTF8.GetBytes(labelId), ref xs, ref ys, count, (int) ImPlotBin.Sturges, (int) ImPlotBin.Sturges, new ImPlotRect(), 0);
        }
        
        /// <summary>
        ///     Plots the histogram 2 d using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="count">The count</param>
        /// <param name="xBins">The bins</param>
        /// <returns>The double</returns>
        public static double PlotHistogram2D(string labelId, ref ushort xs, ref ushort ys, int count, int xBins)
        {
            return    ImPlotNative.ImPlot_PlotHistogram2D_U16Ptr(Encoding.UTF8.GetBytes(labelId), ref xs, ref ys, count, xBins, (int) ImPlotBin.Sturges, new ImPlotRect(), 0);
        }
        
        /// <summary>
        ///     Plots the histogram 2 d using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="count">The count</param>
        /// <param name="xBins">The bins</param>
        /// <param name="yBins">The bins</param>
        /// <returns>The double</returns>
        public static double PlotHistogram2D(string labelId, ref ushort xs, ref ushort ys, int count, int xBins, int yBins)
        {
            return  ImPlotNative.ImPlot_PlotHistogram2D_U16Ptr(Encoding.UTF8.GetBytes(labelId), ref xs, ref ys, count, xBins, yBins, new ImPlotRect(), 0);
        }
        
        /// <summary>
        ///     Plots the histogram 2 d using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="count">The count</param>
        /// <param name="xBins">The bins</param>
        /// <param name="yBins">The bins</param>
        /// <param name="range">The range</param>
        /// <returns>The double</returns>
        public static double PlotHistogram2D(string labelId, ref ushort xs, ref ushort ys, int count, int xBins, int yBins, ImPlotRect range)
        {
            return   ImPlotNative.ImPlot_PlotHistogram2D_U16Ptr(Encoding.UTF8.GetBytes(labelId), ref xs, ref ys, count, xBins, yBins, range, 0);
        }
        
        /// <summary>
        ///     Plots the histogram 2 d using the specified label id
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
        public static double PlotHistogram2D(string labelId, ref ushort xs, ref ushort ys, int count, int xBins, int yBins, ImPlotRect range, ImPlotHistogramFlags flags)
        {
            return  ImPlotNative.ImPlot_PlotHistogram2D_U16Ptr(Encoding.UTF8.GetBytes(labelId), ref xs, ref ys, count, xBins, yBins, range, flags);
        }
        
        /// <summary>
        ///     Plots the histogram 2 d using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="count">The count</param>
        /// <returns>The double</returns>
        public static double PlotHistogram2D(string labelId, ref int xs, ref int ys, int count)
        {
            return ImPlotNative.ImPlot_PlotHistogram2D_S32Ptr(Encoding.UTF8.GetBytes(labelId), ref xs, ref ys, count, (int) ImPlotBin.Sturges, (int) ImPlotBin.Sturges, new ImPlotRect(), 0);
        }
        
        /// <summary>
        ///     Plots the histogram 2 d using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="count">The count</param>
        /// <param name="xBins">The bins</param>
        /// <returns>The double</returns>
        public static double PlotHistogram2D(string labelId, ref int xs, ref int ys, int count, int xBins)
        {
            return  ImPlotNative.ImPlot_PlotHistogram2D_S32Ptr(Encoding.UTF8.GetBytes(labelId), ref xs, ref ys, count, xBins, (int) ImPlotBin.Sturges, new ImPlotRect(), 0);
        }
        
        /// <summary>
        ///     Plots the histogram 2 d using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="count">The count</param>
        /// <param name="xBins">The bins</param>
        /// <param name="yBins">The bins</param>
        /// <returns>The double</returns>
        public static double PlotHistogram2D(string labelId, ref int xs, ref int ys, int count, int xBins, int yBins)
        {
            return  ImPlotNative.ImPlot_PlotHistogram2D_S32Ptr(Encoding.UTF8.GetBytes(labelId), ref xs, ref ys, count, xBins, yBins, new ImPlotRect(), 0);
        }
        
        /// <summary>
        ///     Plots the histogram 2 d using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="count">The count</param>
        /// <param name="xBins">The bins</param>
        /// <param name="yBins">The bins</param>
        /// <param name="range">The range</param>
        /// <returns>The double</returns>
        public static double PlotHistogram2D(string labelId, ref int xs, ref int ys, int count, int xBins, int yBins, ImPlotRect range)
        {
            return  ImPlotNative.ImPlot_PlotHistogram2D_S32Ptr(Encoding.UTF8.GetBytes(labelId), ref xs, ref ys, count, xBins, yBins, range, 0);
        }
        
        /// <summary>
        ///     Plots the histogram 2 d using the specified label id
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
        public static double PlotHistogram2D(string labelId, ref int xs, ref int ys, int count, int xBins, int yBins, ImPlotRect range, ImPlotHistogramFlags flags)
        {
            return  ImPlotNative.ImPlot_PlotHistogram2D_S32Ptr(Encoding.UTF8.GetBytes(labelId), ref xs, ref ys, count, xBins, yBins, range, flags);
        }
        
        /// <summary>
        ///     Plots the histogram 2 d using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="count">The count</param>
        /// <returns>The double</returns>
        public static double PlotHistogram2D(string labelId, ref uint xs, ref uint ys, int count)
        {
            return  ImPlotNative.ImPlot_PlotHistogram2D_U32Ptr(Encoding.UTF8.GetBytes(labelId), ref xs, ref ys, count, (int) ImPlotBin.Sturges, (int) ImPlotBin.Sturges, new ImPlotRect(), 0);
        }
        
        /// <summary>
        ///     Plots the histogram 2 d using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="count">The count</param>
        /// <param name="xBins">The bins</param>
        /// <returns>The double</returns>
        public static double PlotHistogram2D(string labelId, ref uint xs, ref uint ys, int count, int xBins)
        {
            return  ImPlotNative.ImPlot_PlotHistogram2D_U32Ptr(Encoding.UTF8.GetBytes(labelId), ref xs, ref ys, count, xBins, (int) ImPlotBin.Sturges, new ImPlotRect(), 0);
        }
        
        /// <summary>
        ///     Plots the histogram 2 d using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="count">The count</param>
        /// <param name="xBins">The bins</param>
        /// <param name="yBins">The bins</param>
        /// <returns>The double</returns>
        public static double PlotHistogram2D(string labelId, ref uint xs, ref uint ys, int count, int xBins, int yBins)
        {
            return  ImPlotNative.ImPlot_PlotHistogram2D_U32Ptr(Encoding.UTF8.GetBytes(labelId), ref xs, ref ys, count, xBins, yBins, new ImPlotRect(), 0);
        }
        
        /// <summary>
        ///     Plots the histogram 2 d using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="count">The count</param>
        /// <param name="xBins">The bins</param>
        /// <param name="yBins">The bins</param>
        /// <param name="range">The range</param>
        /// <returns>The double</returns>
        public static double PlotHistogram2D(string labelId, ref uint xs, ref uint ys, int count, int xBins, int yBins, ImPlotRect range)
        {
            return  ImPlotNative.ImPlot_PlotHistogram2D_U32Ptr(Encoding.UTF8.GetBytes(labelId), ref xs, ref ys, count, xBins, yBins, range, 0);
        }
        
        /// <summary>
        ///     Plots the histogram 2 d using the specified label id
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
        public static double PlotHistogram2D(string labelId, ref uint xs, ref uint ys, int count, int xBins, int yBins, ImPlotRect range, ImPlotHistogramFlags flags)
        {
            return  ImPlotNative.ImPlot_PlotHistogram2D_U32Ptr(Encoding.UTF8.GetBytes(labelId), ref xs, ref ys, count, xBins, yBins, range, flags);
        }
        
        /// <summary>
        ///     Plots the histogram 2 d using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="count">The count</param>
        /// <returns>The double</returns>
        public static double PlotHistogram2D(string labelId, ref long xs, ref long ys, int count)
        {
            return  ImPlotNative.ImPlot_PlotHistogram2D_S64Ptr(Encoding.UTF8.GetBytes(labelId), ref xs, ref ys, count, (int) ImPlotBin.Sturges, (int) ImPlotBin.Sturges, new ImPlotRect(), 0);
        }
        
        /// <summary>
        ///     Plots the histogram 2 d using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="count">The count</param>
        /// <param name="xBins">The bins</param>
        /// <returns>The double</returns>
        public static double PlotHistogram2D(string labelId, ref long xs, ref long ys, int count, int xBins)
        {
            return  ImPlotNative.ImPlot_PlotHistogram2D_S64Ptr(Encoding.UTF8.GetBytes(labelId), ref xs, ref ys, count, xBins, (int) ImPlotBin.Sturges, new ImPlotRect(), 0);
        }
        
        /// <summary>
        ///     Plots the histogram 2 d using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="count">The count</param>
        /// <param name="xBins">The bins</param>
        /// <param name="yBins">The bins</param>
        /// <returns>The double</returns>
        public static double PlotHistogram2D(string labelId, ref long xs, ref long ys, int count, int xBins, int yBins)
        {
            return  ImPlotNative.ImPlot_PlotHistogram2D_S64Ptr(Encoding.UTF8.GetBytes(labelId), ref xs, ref ys, count, xBins, yBins, new ImPlotRect(), 0);
        }
        
        /// <summary>
        ///     Plots the histogram 2 d using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="count">The count</param>
        /// <param name="xBins">The bins</param>
        /// <param name="yBins">The bins</param>
        /// <param name="range">The range</param>
        /// <returns>The double</returns>
        public static double PlotHistogram2D(string labelId, ref long xs, ref long ys, int count, int xBins, int yBins, ImPlotRect range)
        {
            return  ImPlotNative.ImPlot_PlotHistogram2D_S64Ptr(Encoding.UTF8.GetBytes(labelId), ref xs, ref ys, count, xBins, yBins, range, 0);
        }
        
        /// <summary>
        ///     Plots the histogram 2 d using the specified label id
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
        public static double PlotHistogram2D(string labelId, ref long xs, ref long ys, int count, int xBins, int yBins, ImPlotRect range, ImPlotHistogramFlags flags)
        {
            return  ImPlotNative.ImPlot_PlotHistogram2D_S64Ptr(Encoding.UTF8.GetBytes(labelId), ref xs, ref ys, count, xBins, yBins, range, flags);
        }
        
        /// <summary>
        ///     Plots the histogram 2 d using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="count">The count</param>
        /// <returns>The double</returns>
        public static double PlotHistogram2D(string labelId, ref ulong xs, ref ulong ys, int count)
        {
            return  ImPlotNative.ImPlot_PlotHistogram2D_U64Ptr(Encoding.UTF8.GetBytes(labelId), ref xs, ref ys, count, (int) ImPlotBin.Sturges, (int) ImPlotBin.Sturges, new ImPlotRect(), 0);
        }
        
        /// <summary>
        ///     Plots the histogram 2 d using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="count">The count</param>
        /// <param name="xBins">The bins</param>
        /// <returns>The double</returns>
        public static double PlotHistogram2D(string labelId, ref ulong xs, ref ulong ys, int count, int xBins)
        {
            return  ImPlotNative.ImPlot_PlotHistogram2D_U64Ptr(Encoding.UTF8.GetBytes(labelId), ref xs, ref ys, count, xBins, (int) ImPlotBin.Sturges, new ImPlotRect(), 0);
        }
        
        /// <summary>
        ///     Plots the histogram 2 d using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="count">The count</param>
        /// <param name="xBins">The bins</param>
        /// <param name="yBins">The bins</param>
        /// <returns>The double</returns>
        public static double PlotHistogram2D(string labelId, ref ulong xs, ref ulong ys, int count, int xBins, int yBins)
        {
            return  ImPlotNative.ImPlot_PlotHistogram2D_U64Ptr(Encoding.UTF8.GetBytes(labelId), ref xs, ref ys, count, xBins, yBins, new ImPlotRect(), 0);
        }
        
        /// <summary>
        ///     Plots the histogram 2 d using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="count">The count</param>
        /// <param name="xBins">The bins</param>
        /// <param name="yBins">The bins</param>
        /// <param name="range">The range</param>
        /// <returns>The double</returns>
        public static double PlotHistogram2D(string labelId, ref ulong xs, ref ulong ys, int count, int xBins, int yBins, ImPlotRect range)
        {
            return  ImPlotNative.ImPlot_PlotHistogram2D_U64Ptr(Encoding.UTF8.GetBytes(labelId), ref xs, ref ys, count, xBins, yBins, range, 0);
        }
        
        /// <summary>
        ///     Plots the histogram 2 d using the specified label id
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
        public static double PlotHistogram2D(string labelId, ref ulong xs, ref ulong ys, int count, int xBins, int yBins, ImPlotRect range, ImPlotHistogramFlags flags)
        {
            return  ImPlotNative.ImPlot_PlotHistogram2D_U64Ptr(Encoding.UTF8.GetBytes(labelId), ref xs, ref ys, count, xBins, yBins, range, flags);
        }
        
        /// <summary>
        ///     Plots the image using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="userTextureId">The user texture id</param>
        /// <param name="boundsMin">The bounds min</param>
        /// <param name="boundsMax">The bounds max</param>
        public static void PlotImage(string labelId, IntPtr userTextureId, ImPlotPoint boundsMin, ImPlotPoint boundsMax)
        {
            ImPlotNative.ImPlot_PlotImage(Encoding.UTF8.GetBytes(labelId), userTextureId, boundsMin, boundsMax, new Vector2(0, 0), new Vector2(1, 1), new Vector4(1, 1, 1, 1), 0);
        }
        
        /// <summary>
        ///     Plots the image using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="userTextureId">The user texture id</param>
        /// <param name="boundsMin">The bounds min</param>
        /// <param name="boundsMax">The bounds max</param>
        /// <param name="uv0">The uv</param>
        public static void PlotImage(string labelId, IntPtr userTextureId, ImPlotPoint boundsMin, ImPlotPoint boundsMax, Vector2 uv0)
        {
            ImPlotNative.ImPlot_PlotImage(Encoding.UTF8.GetBytes(labelId), userTextureId, boundsMin, boundsMax, uv0, new Vector2(1, 1), new Vector4(1, 1, 1, 1), 0);
        }
        
        /// <summary>
        ///     Plots the image using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="userTextureId">The user texture id</param>
        /// <param name="boundsMin">The bounds min</param>
        /// <param name="boundsMax">The bounds max</param>
        /// <param name="uv0">The uv</param>
        /// <param name="uv1">The uv</param>
        public static void PlotImage(string labelId, IntPtr userTextureId, ImPlotPoint boundsMin, ImPlotPoint boundsMax, Vector2 uv0, Vector2 uv1)
        {
            ImPlotNative.ImPlot_PlotImage(Encoding.UTF8.GetBytes(labelId), userTextureId, boundsMin, boundsMax, uv0, uv1, new Vector4(1, 1, 1, 1), 0);
        }
        
        /// <summary>
        ///     Plots the image using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="userTextureId">The user texture id</param>
        /// <param name="boundsMin">The bounds min</param>
        /// <param name="boundsMax">The bounds max</param>
        /// <param name="uv0">The uv</param>
        /// <param name="uv1">The uv</param>
        /// <param name="tintCol">The tint col</param>
        public static void PlotImage(string labelId, IntPtr userTextureId, ImPlotPoint boundsMin, ImPlotPoint boundsMax, Vector2 uv0, Vector2 uv1, Vector4 tintCol)
        {
            ImPlotNative.ImPlot_PlotImage(Encoding.UTF8.GetBytes(labelId), userTextureId, boundsMin, boundsMax, uv0, uv1, tintCol, 0);
        }
        
        /// <summary>
        ///     Plots the image using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="userTextureId">The user texture id</param>
        /// <param name="boundsMin">The bounds min</param>
        /// <param name="boundsMax">The bounds max</param>
        /// <param name="uv0">The uv</param>
        /// <param name="uv1">The uv</param>
        /// <param name="tintCol">The tint col</param>
        /// <param name="flags">The flags</param>
        public static void PlotImage(string labelId, IntPtr userTextureId, ImPlotPoint boundsMin, ImPlotPoint boundsMax, Vector2 uv0, Vector2 uv1, Vector4 tintCol, ImPlotImageFlags flags)
        {
            ImPlotNative.ImPlot_PlotImage(Encoding.UTF8.GetBytes(labelId), userTextureId, boundsMin, boundsMax, uv0, uv1, tintCol, flags);
        }
        
        /// <summary>
        ///     Plots the inf lines using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        public static void PlotInfLines(string labelId, float[] values, int count)
        {
            ImPlotNative.ImPlot_PlotInfLines_FloatPtr(Encoding.UTF8.GetBytes(labelId), values, count, 0, 0, sizeof(float));
        }
        
        /// <summary>
        ///     Plots the inf lines using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="flags">The flags</param>
        public static void PlotInfLines(string labelId, float[] values, int count, ImPlotInfLinesFlags flags)
        {
            ImPlotNative.ImPlot_PlotInfLines_FloatPtr(Encoding.UTF8.GetBytes(labelId), values, count, flags, 0, sizeof(float));
        }
        
        /// <summary>
        ///     Plots the inf lines using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        public static void PlotInfLines(string labelId, float[] values, int count, ImPlotInfLinesFlags flags, int offset)
        {
            ImPlotNative.ImPlot_PlotInfLines_FloatPtr(Encoding.UTF8.GetBytes(labelId), values, count, flags, offset, sizeof(float));
        }
        
        /// <summary>
        ///     Plots the inf lines using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        /// <param name="stride">The stride</param>
        public static void PlotInfLines(string labelId, float[] values, int count, ImPlotInfLinesFlags flags, int offset, int stride)
        {
            ImPlotNative.ImPlot_PlotInfLines_FloatPtr(Encoding.UTF8.GetBytes(labelId), values, count, flags, offset, stride);
        }
        
        /// <summary>
        ///     Plots the inf lines using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        public static void PlotInfLines(string labelId, double[] values, int count)
        {
            ImPlotNative.ImPlot_PlotInfLines_doublePtr(Encoding.UTF8.GetBytes(labelId), values, count, 0, 0, sizeof(double));
        }
        
        /// <summary>
        ///     Plots the inf lines using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="flags">The flags</param>
        public static void PlotInfLines(string labelId, double[] values, int count, ImPlotInfLinesFlags flags)
        {
            ImPlotNative.ImPlot_PlotInfLines_doublePtr(Encoding.UTF8.GetBytes(labelId), values, count, flags, 0, sizeof(double));
        }
        
        /// <summary>
        ///     Plots the inf lines using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        public static void PlotInfLines(string labelId, double[] values, int count, ImPlotInfLinesFlags flags, int offset)
        {
            ImPlotNative.ImPlot_PlotInfLines_doublePtr(Encoding.UTF8.GetBytes(labelId), values, count, flags, offset, sizeof(double));
        }
        
        /// <summary>
        ///     Plots the inf lines using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        /// <param name="stride">The stride</param>
        public static void PlotInfLines(string labelId, double[] values, int count, ImPlotInfLinesFlags flags, int offset, int stride)
        {
            ImPlotNative.ImPlot_PlotInfLines_doublePtr(Encoding.UTF8.GetBytes(labelId), values, count, flags, offset, stride);
        }
        
        /// <summary>
        ///     Plots the inf lines using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        public static void PlotInfLines(string labelId, sbyte[] values, int count)
        {
            ImPlotInfLinesFlags flags = 0;
            int offset = 0;
            int stride = sizeof(sbyte);
            ImPlotNative.ImPlot_PlotInfLines_S8Ptr(Encoding.UTF8.GetBytes(labelId), values, count, flags, offset, stride);
        }
        
        /// <summary>
        ///     Plots the inf lines using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="flags">The flags</param>
        public static void PlotInfLines(string labelId, sbyte[] values, int count, ImPlotInfLinesFlags flags)
        {
            ImPlotNative.ImPlot_PlotInfLines_S8Ptr(Encoding.UTF8.GetBytes(labelId), values, count, flags, 0, sizeof(sbyte));
        }
        
        /// <summary>
        ///     Plots the inf lines using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        public static void PlotInfLines(string labelId, sbyte[] values, int count, ImPlotInfLinesFlags flags, int offset)
        {
            int stride = sizeof(sbyte);
            ImPlotNative.ImPlot_PlotInfLines_S8Ptr(Encoding.UTF8.GetBytes(labelId), values, count, flags, offset, stride);
        }
        
        /// <summary>
        ///     Plots the inf lines using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        /// <param name="stride">The stride</param>
        public static void PlotInfLines(string labelId, sbyte[] values, int count, ImPlotInfLinesFlags flags, int offset, int stride)
        {
            ImPlotNative.ImPlot_PlotInfLines_S8Ptr(Encoding.UTF8.GetBytes(labelId), values, count, flags, offset, stride);
        }
        
        /// <summary>
        ///     Plots the inf lines using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        public static void PlotInfLines(string labelId, byte[] values, int count)
        {
            ImPlotInfLinesFlags flags = 0;
            int offset = 0;
            int stride = sizeof(byte);
            ImPlotNative.ImPlot_PlotInfLines_U8Ptr(Encoding.UTF8.GetBytes(labelId), values, count, flags, offset, stride);
        }
        
        /// <summary>
        ///     Plots the inf lines using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="flags">The flags</param>
        public static void PlotInfLines(string labelId, byte[] values, int count, ImPlotInfLinesFlags flags)
        {
            ImPlotNative.ImPlot_PlotInfLines_U8Ptr(Encoding.UTF8.GetBytes(labelId), values, count, flags, 0, sizeof(byte));
        }
        
        /// <summary>
        ///     Plots the inf lines using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        public static void PlotInfLines(string labelId, byte[] values, int count, ImPlotInfLinesFlags flags, int offset)
        {
            int stride = sizeof(byte);
            ImPlotNative.ImPlot_PlotInfLines_U8Ptr(Encoding.UTF8.GetBytes(labelId), values, count, flags, offset, stride);
        }
    }
}