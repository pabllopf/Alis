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
   public static unsafe partial class ImPlot
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
            byte* nativeLabelId;
            int labelIdByteCount = 0;
            if (labelId != null)
            {
                labelIdByteCount = Encoding.UTF8.GetByteCount(labelId);
                if (labelIdByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeLabelId = Util.Allocate(labelIdByteCount + 1);
                }
                else
                {
                    byte* nativeLabelIdStackBytes = stackalloc byte[labelIdByteCount + 1];
                    nativeLabelId = nativeLabelIdStackBytes;
                }
                
                int nativeLabelIdOffset = Util.GetUtf8(labelId, nativeLabelId, labelIdByteCount);
                nativeLabelId[nativeLabelIdOffset] = 0;
            }
            else
            {
                nativeLabelId = null;
            }
            
            ImPlotHistogramFlags flags = 0;
            fixed (byte* nativeXs = &xs)
            {
                fixed (byte* nativeYs = &ys)
                {
                    double ret = ImPlotNative.ImPlot_PlotHistogram2D_U8Ptr(nativeLabelId, nativeXs, nativeYs, count, xBins, yBins, range, flags);
                    if (labelIdByteCount > Util.StackAllocationSizeLimit)
                    {
                        Util.Free(nativeLabelId);
                    }
                    
                    return ret;
                }
            }
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
            byte* nativeLabelId;
            int labelIdByteCount = 0;
            if (labelId != null)
            {
                labelIdByteCount = Encoding.UTF8.GetByteCount(labelId);
                if (labelIdByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeLabelId = Util.Allocate(labelIdByteCount + 1);
                }
                else
                {
                    byte* nativeLabelIdStackBytes = stackalloc byte[labelIdByteCount + 1];
                    nativeLabelId = nativeLabelIdStackBytes;
                }
                
                int nativeLabelIdOffset = Util.GetUtf8(labelId, nativeLabelId, labelIdByteCount);
                nativeLabelId[nativeLabelIdOffset] = 0;
            }
            else
            {
                nativeLabelId = null;
            }
            
            fixed (byte* nativeXs = &xs)
            {
                fixed (byte* nativeYs = &ys)
                {
                    double ret = ImPlotNative.ImPlot_PlotHistogram2D_U8Ptr(nativeLabelId, nativeXs, nativeYs, count, xBins, yBins, range, flags);
                    if (labelIdByteCount > Util.StackAllocationSizeLimit)
                    {
                        Util.Free(nativeLabelId);
                    }
                    
                    return ret;
                }
            }
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
            byte* nativeLabelId;
            int labelIdByteCount = 0;
            if (labelId != null)
            {
                labelIdByteCount = Encoding.UTF8.GetByteCount(labelId);
                if (labelIdByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeLabelId = Util.Allocate(labelIdByteCount + 1);
                }
                else
                {
                    byte* nativeLabelIdStackBytes = stackalloc byte[labelIdByteCount + 1];
                    nativeLabelId = nativeLabelIdStackBytes;
                }
                
                int nativeLabelIdOffset = Util.GetUtf8(labelId, nativeLabelId, labelIdByteCount);
                nativeLabelId[nativeLabelIdOffset] = 0;
            }
            else
            {
                nativeLabelId = null;
            }
            
            int xBins = (int) ImPlotBin.Sturges;
            int yBins = (int) ImPlotBin.Sturges;
            ImPlotRect range = new ImPlotRect();
            ImPlotHistogramFlags flags = 0;
            fixed (short* nativeXs = &xs)
            {
                fixed (short* nativeYs = &ys)
                {
                    double ret = ImPlotNative.ImPlot_PlotHistogram2D_S16Ptr(nativeLabelId, nativeXs, nativeYs, count, xBins, yBins, range, flags);
                    if (labelIdByteCount > Util.StackAllocationSizeLimit)
                    {
                        Util.Free(nativeLabelId);
                    }
                    
                    return ret;
                }
            }
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
            byte* nativeLabelId;
            int labelIdByteCount = 0;
            if (labelId != null)
            {
                labelIdByteCount = Encoding.UTF8.GetByteCount(labelId);
                if (labelIdByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeLabelId = Util.Allocate(labelIdByteCount + 1);
                }
                else
                {
                    byte* nativeLabelIdStackBytes = stackalloc byte[labelIdByteCount + 1];
                    nativeLabelId = nativeLabelIdStackBytes;
                }
                
                int nativeLabelIdOffset = Util.GetUtf8(labelId, nativeLabelId, labelIdByteCount);
                nativeLabelId[nativeLabelIdOffset] = 0;
            }
            else
            {
                nativeLabelId = null;
            }
            
            int yBins = (int) ImPlotBin.Sturges;
            ImPlotRect range = new ImPlotRect();
            ImPlotHistogramFlags flags = 0;
            fixed (short* nativeXs = &xs)
            {
                fixed (short* nativeYs = &ys)
                {
                    double ret = ImPlotNative.ImPlot_PlotHistogram2D_S16Ptr(nativeLabelId, nativeXs, nativeYs, count, xBins, yBins, range, flags);
                    if (labelIdByteCount > Util.StackAllocationSizeLimit)
                    {
                        Util.Free(nativeLabelId);
                    }
                    
                    return ret;
                }
            }
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
            byte* nativeLabelId;
            int labelIdByteCount = 0;
            if (labelId != null)
            {
                labelIdByteCount = Encoding.UTF8.GetByteCount(labelId);
                if (labelIdByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeLabelId = Util.Allocate(labelIdByteCount + 1);
                }
                else
                {
                    byte* nativeLabelIdStackBytes = stackalloc byte[labelIdByteCount + 1];
                    nativeLabelId = nativeLabelIdStackBytes;
                }
                
                int nativeLabelIdOffset = Util.GetUtf8(labelId, nativeLabelId, labelIdByteCount);
                nativeLabelId[nativeLabelIdOffset] = 0;
            }
            else
            {
                nativeLabelId = null;
            }
            
            ImPlotRect range = new ImPlotRect();
            ImPlotHistogramFlags flags = 0;
            fixed (short* nativeXs = &xs)
            {
                fixed (short* nativeYs = &ys)
                {
                    double ret = ImPlotNative.ImPlot_PlotHistogram2D_S16Ptr(nativeLabelId, nativeXs, nativeYs, count, xBins, yBins, range, flags);
                    if (labelIdByteCount > Util.StackAllocationSizeLimit)
                    {
                        Util.Free(nativeLabelId);
                    }
                    
                    return ret;
                }
            }
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
            byte* nativeLabelId;
            int labelIdByteCount = 0;
            if (labelId != null)
            {
                labelIdByteCount = Encoding.UTF8.GetByteCount(labelId);
                if (labelIdByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeLabelId = Util.Allocate(labelIdByteCount + 1);
                }
                else
                {
                    byte* nativeLabelIdStackBytes = stackalloc byte[labelIdByteCount + 1];
                    nativeLabelId = nativeLabelIdStackBytes;
                }
                
                int nativeLabelIdOffset = Util.GetUtf8(labelId, nativeLabelId, labelIdByteCount);
                nativeLabelId[nativeLabelIdOffset] = 0;
            }
            else
            {
                nativeLabelId = null;
            }
            
            ImPlotHistogramFlags flags = 0;
            fixed (short* nativeXs = &xs)
            {
                fixed (short* nativeYs = &ys)
                {
                    double ret = ImPlotNative.ImPlot_PlotHistogram2D_S16Ptr(nativeLabelId, nativeXs, nativeYs, count, xBins, yBins, range, flags);
                    if (labelIdByteCount > Util.StackAllocationSizeLimit)
                    {
                        Util.Free(nativeLabelId);
                    }
                    
                    return ret;
                }
            }
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
            byte* nativeLabelId;
            int labelIdByteCount = 0;
            if (labelId != null)
            {
                labelIdByteCount = Encoding.UTF8.GetByteCount(labelId);
                if (labelIdByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeLabelId = Util.Allocate(labelIdByteCount + 1);
                }
                else
                {
                    byte* nativeLabelIdStackBytes = stackalloc byte[labelIdByteCount + 1];
                    nativeLabelId = nativeLabelIdStackBytes;
                }
                
                int nativeLabelIdOffset = Util.GetUtf8(labelId, nativeLabelId, labelIdByteCount);
                nativeLabelId[nativeLabelIdOffset] = 0;
            }
            else
            {
                nativeLabelId = null;
            }
            
            fixed (short* nativeXs = &xs)
            {
                fixed (short* nativeYs = &ys)
                {
                    double ret = ImPlotNative.ImPlot_PlotHistogram2D_S16Ptr(nativeLabelId, nativeXs, nativeYs, count, xBins, yBins, range, flags);
                    if (labelIdByteCount > Util.StackAllocationSizeLimit)
                    {
                        Util.Free(nativeLabelId);
                    }
                    
                    return ret;
                }
            }
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
            byte* nativeLabelId;
            int labelIdByteCount = 0;
            if (labelId != null)
            {
                labelIdByteCount = Encoding.UTF8.GetByteCount(labelId);
                if (labelIdByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeLabelId = Util.Allocate(labelIdByteCount + 1);
                }
                else
                {
                    byte* nativeLabelIdStackBytes = stackalloc byte[labelIdByteCount + 1];
                    nativeLabelId = nativeLabelIdStackBytes;
                }
                
                int nativeLabelIdOffset = Util.GetUtf8(labelId, nativeLabelId, labelIdByteCount);
                nativeLabelId[nativeLabelIdOffset] = 0;
            }
            else
            {
                nativeLabelId = null;
            }
            
            int xBins = (int) ImPlotBin.Sturges;
            int yBins = (int) ImPlotBin.Sturges;
            ImPlotRect range = new ImPlotRect();
            ImPlotHistogramFlags flags = 0;
            fixed (ushort* nativeXs = &xs)
            {
                fixed (ushort* nativeYs = &ys)
                {
                    double ret = ImPlotNative.ImPlot_PlotHistogram2D_U16Ptr(nativeLabelId, nativeXs, nativeYs, count, xBins, yBins, range, flags);
                    if (labelIdByteCount > Util.StackAllocationSizeLimit)
                    {
                        Util.Free(nativeLabelId);
                    }
                    
                    return ret;
                }
            }
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
            byte* nativeLabelId;
            int labelIdByteCount = 0;
            if (labelId != null)
            {
                labelIdByteCount = Encoding.UTF8.GetByteCount(labelId);
                if (labelIdByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeLabelId = Util.Allocate(labelIdByteCount + 1);
                }
                else
                {
                    byte* nativeLabelIdStackBytes = stackalloc byte[labelIdByteCount + 1];
                    nativeLabelId = nativeLabelIdStackBytes;
                }
                
                int nativeLabelIdOffset = Util.GetUtf8(labelId, nativeLabelId, labelIdByteCount);
                nativeLabelId[nativeLabelIdOffset] = 0;
            }
            else
            {
                nativeLabelId = null;
            }
            
            int yBins = (int) ImPlotBin.Sturges;
            ImPlotRect range = new ImPlotRect();
            ImPlotHistogramFlags flags = 0;
            fixed (ushort* nativeXs = &xs)
            {
                fixed (ushort* nativeYs = &ys)
                {
                    double ret = ImPlotNative.ImPlot_PlotHistogram2D_U16Ptr(nativeLabelId, nativeXs, nativeYs, count, xBins, yBins, range, flags);
                    if (labelIdByteCount > Util.StackAllocationSizeLimit)
                    {
                        Util.Free(nativeLabelId);
                    }
                    
                    return ret;
                }
            }
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
            byte* nativeLabelId;
            int labelIdByteCount = 0;
            if (labelId != null)
            {
                labelIdByteCount = Encoding.UTF8.GetByteCount(labelId);
                if (labelIdByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeLabelId = Util.Allocate(labelIdByteCount + 1);
                }
                else
                {
                    byte* nativeLabelIdStackBytes = stackalloc byte[labelIdByteCount + 1];
                    nativeLabelId = nativeLabelIdStackBytes;
                }
                
                int nativeLabelIdOffset = Util.GetUtf8(labelId, nativeLabelId, labelIdByteCount);
                nativeLabelId[nativeLabelIdOffset] = 0;
            }
            else
            {
                nativeLabelId = null;
            }
            
            ImPlotRect range = new ImPlotRect();
            ImPlotHistogramFlags flags = 0;
            fixed (ushort* nativeXs = &xs)
            {
                fixed (ushort* nativeYs = &ys)
                {
                    double ret = ImPlotNative.ImPlot_PlotHistogram2D_U16Ptr(nativeLabelId, nativeXs, nativeYs, count, xBins, yBins, range, flags);
                    if (labelIdByteCount > Util.StackAllocationSizeLimit)
                    {
                        Util.Free(nativeLabelId);
                    }
                    
                    return ret;
                }
            }
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
            byte* nativeLabelId;
            int labelIdByteCount = 0;
            if (labelId != null)
            {
                labelIdByteCount = Encoding.UTF8.GetByteCount(labelId);
                if (labelIdByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeLabelId = Util.Allocate(labelIdByteCount + 1);
                }
                else
                {
                    byte* nativeLabelIdStackBytes = stackalloc byte[labelIdByteCount + 1];
                    nativeLabelId = nativeLabelIdStackBytes;
                }
                
                int nativeLabelIdOffset = Util.GetUtf8(labelId, nativeLabelId, labelIdByteCount);
                nativeLabelId[nativeLabelIdOffset] = 0;
            }
            else
            {
                nativeLabelId = null;
            }
            
            ImPlotHistogramFlags flags = 0;
            fixed (ushort* nativeXs = &xs)
            {
                fixed (ushort* nativeYs = &ys)
                {
                    double ret = ImPlotNative.ImPlot_PlotHistogram2D_U16Ptr(nativeLabelId, nativeXs, nativeYs, count, xBins, yBins, range, flags);
                    if (labelIdByteCount > Util.StackAllocationSizeLimit)
                    {
                        Util.Free(nativeLabelId);
                    }
                    
                    return ret;
                }
            }
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
            byte* nativeLabelId;
            int labelIdByteCount = 0;
            if (labelId != null)
            {
                labelIdByteCount = Encoding.UTF8.GetByteCount(labelId);
                if (labelIdByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeLabelId = Util.Allocate(labelIdByteCount + 1);
                }
                else
                {
                    byte* nativeLabelIdStackBytes = stackalloc byte[labelIdByteCount + 1];
                    nativeLabelId = nativeLabelIdStackBytes;
                }
                
                int nativeLabelIdOffset = Util.GetUtf8(labelId, nativeLabelId, labelIdByteCount);
                nativeLabelId[nativeLabelIdOffset] = 0;
            }
            else
            {
                nativeLabelId = null;
            }
            
            fixed (ushort* nativeXs = &xs)
            {
                fixed (ushort* nativeYs = &ys)
                {
                    double ret = ImPlotNative.ImPlot_PlotHistogram2D_U16Ptr(nativeLabelId, nativeXs, nativeYs, count, xBins, yBins, range, flags);
                    if (labelIdByteCount > Util.StackAllocationSizeLimit)
                    {
                        Util.Free(nativeLabelId);
                    }
                    
                    return ret;
                }
            }
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
            byte* nativeLabelId;
            int labelIdByteCount = 0;
            if (labelId != null)
            {
                labelIdByteCount = Encoding.UTF8.GetByteCount(labelId);
                if (labelIdByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeLabelId = Util.Allocate(labelIdByteCount + 1);
                }
                else
                {
                    byte* nativeLabelIdStackBytes = stackalloc byte[labelIdByteCount + 1];
                    nativeLabelId = nativeLabelIdStackBytes;
                }
                
                int nativeLabelIdOffset = Util.GetUtf8(labelId, nativeLabelId, labelIdByteCount);
                nativeLabelId[nativeLabelIdOffset] = 0;
            }
            else
            {
                nativeLabelId = null;
            }
            
            int xBins = (int) ImPlotBin.Sturges;
            int yBins = (int) ImPlotBin.Sturges;
            ImPlotRect range = new ImPlotRect();
            ImPlotHistogramFlags flags = 0;
            fixed (int* nativeXs = &xs)
            {
                fixed (int* nativeYs = &ys)
                {
                    double ret = ImPlotNative.ImPlot_PlotHistogram2D_S32Ptr(nativeLabelId, nativeXs, nativeYs, count, xBins, yBins, range, flags);
                    if (labelIdByteCount > Util.StackAllocationSizeLimit)
                    {
                        Util.Free(nativeLabelId);
                    }
                    
                    return ret;
                }
            }
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
            byte* nativeLabelId;
            int labelIdByteCount = 0;
            if (labelId != null)
            {
                labelIdByteCount = Encoding.UTF8.GetByteCount(labelId);
                if (labelIdByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeLabelId = Util.Allocate(labelIdByteCount + 1);
                }
                else
                {
                    byte* nativeLabelIdStackBytes = stackalloc byte[labelIdByteCount + 1];
                    nativeLabelId = nativeLabelIdStackBytes;
                }
                
                int nativeLabelIdOffset = Util.GetUtf8(labelId, nativeLabelId, labelIdByteCount);
                nativeLabelId[nativeLabelIdOffset] = 0;
            }
            else
            {
                nativeLabelId = null;
            }
            
            int yBins = (int) ImPlotBin.Sturges;
            ImPlotRect range = new ImPlotRect();
            ImPlotHistogramFlags flags = 0;
            fixed (int* nativeXs = &xs)
            {
                fixed (int* nativeYs = &ys)
                {
                    double ret = ImPlotNative.ImPlot_PlotHistogram2D_S32Ptr(nativeLabelId, nativeXs, nativeYs, count, xBins, yBins, range, flags);
                    if (labelIdByteCount > Util.StackAllocationSizeLimit)
                    {
                        Util.Free(nativeLabelId);
                    }
                    
                    return ret;
                }
            }
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
            byte* nativeLabelId;
            int labelIdByteCount = 0;
            if (labelId != null)
            {
                labelIdByteCount = Encoding.UTF8.GetByteCount(labelId);
                if (labelIdByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeLabelId = Util.Allocate(labelIdByteCount + 1);
                }
                else
                {
                    byte* nativeLabelIdStackBytes = stackalloc byte[labelIdByteCount + 1];
                    nativeLabelId = nativeLabelIdStackBytes;
                }
                
                int nativeLabelIdOffset = Util.GetUtf8(labelId, nativeLabelId, labelIdByteCount);
                nativeLabelId[nativeLabelIdOffset] = 0;
            }
            else
            {
                nativeLabelId = null;
            }
            
            ImPlotRect range = new ImPlotRect();
            ImPlotHistogramFlags flags = 0;
            fixed (int* nativeXs = &xs)
            {
                fixed (int* nativeYs = &ys)
                {
                    double ret = ImPlotNative.ImPlot_PlotHistogram2D_S32Ptr(nativeLabelId, nativeXs, nativeYs, count, xBins, yBins, range, flags);
                    if (labelIdByteCount > Util.StackAllocationSizeLimit)
                    {
                        Util.Free(nativeLabelId);
                    }
                    
                    return ret;
                }
            }
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
            byte* nativeLabelId;
            int labelIdByteCount = 0;
            if (labelId != null)
            {
                labelIdByteCount = Encoding.UTF8.GetByteCount(labelId);
                if (labelIdByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeLabelId = Util.Allocate(labelIdByteCount + 1);
                }
                else
                {
                    byte* nativeLabelIdStackBytes = stackalloc byte[labelIdByteCount + 1];
                    nativeLabelId = nativeLabelIdStackBytes;
                }
                
                int nativeLabelIdOffset = Util.GetUtf8(labelId, nativeLabelId, labelIdByteCount);
                nativeLabelId[nativeLabelIdOffset] = 0;
            }
            else
            {
                nativeLabelId = null;
            }
            
            ImPlotHistogramFlags flags = 0;
            fixed (int* nativeXs = &xs)
            {
                fixed (int* nativeYs = &ys)
                {
                    double ret = ImPlotNative.ImPlot_PlotHistogram2D_S32Ptr(nativeLabelId, nativeXs, nativeYs, count, xBins, yBins, range, flags);
                    if (labelIdByteCount > Util.StackAllocationSizeLimit)
                    {
                        Util.Free(nativeLabelId);
                    }
                    
                    return ret;
                }
            }
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
            byte* nativeLabelId;
            int labelIdByteCount = 0;
            if (labelId != null)
            {
                labelIdByteCount = Encoding.UTF8.GetByteCount(labelId);
                if (labelIdByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeLabelId = Util.Allocate(labelIdByteCount + 1);
                }
                else
                {
                    byte* nativeLabelIdStackBytes = stackalloc byte[labelIdByteCount + 1];
                    nativeLabelId = nativeLabelIdStackBytes;
                }
                
                int nativeLabelIdOffset = Util.GetUtf8(labelId, nativeLabelId, labelIdByteCount);
                nativeLabelId[nativeLabelIdOffset] = 0;
            }
            else
            {
                nativeLabelId = null;
            }
            
            fixed (int* nativeXs = &xs)
            {
                fixed (int* nativeYs = &ys)
                {
                    double ret = ImPlotNative.ImPlot_PlotHistogram2D_S32Ptr(nativeLabelId, nativeXs, nativeYs, count, xBins, yBins, range, flags);
                    if (labelIdByteCount > Util.StackAllocationSizeLimit)
                    {
                        Util.Free(nativeLabelId);
                    }
                    
                    return ret;
                }
            }
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
            byte* nativeLabelId;
            int labelIdByteCount = 0;
            if (labelId != null)
            {
                labelIdByteCount = Encoding.UTF8.GetByteCount(labelId);
                if (labelIdByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeLabelId = Util.Allocate(labelIdByteCount + 1);
                }
                else
                {
                    byte* nativeLabelIdStackBytes = stackalloc byte[labelIdByteCount + 1];
                    nativeLabelId = nativeLabelIdStackBytes;
                }
                
                int nativeLabelIdOffset = Util.GetUtf8(labelId, nativeLabelId, labelIdByteCount);
                nativeLabelId[nativeLabelIdOffset] = 0;
            }
            else
            {
                nativeLabelId = null;
            }
            
            int xBins = (int) ImPlotBin.Sturges;
            int yBins = (int) ImPlotBin.Sturges;
            ImPlotRect range = new ImPlotRect();
            ImPlotHistogramFlags flags = 0;
            fixed (uint* nativeXs = &xs)
            {
                fixed (uint* nativeYs = &ys)
                {
                    double ret = ImPlotNative.ImPlot_PlotHistogram2D_U32Ptr(nativeLabelId, nativeXs, nativeYs, count, xBins, yBins, range, flags);
                    if (labelIdByteCount > Util.StackAllocationSizeLimit)
                    {
                        Util.Free(nativeLabelId);
                    }
                    
                    return ret;
                }
            }
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
            byte* nativeLabelId;
            int labelIdByteCount = 0;
            if (labelId != null)
            {
                labelIdByteCount = Encoding.UTF8.GetByteCount(labelId);
                if (labelIdByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeLabelId = Util.Allocate(labelIdByteCount + 1);
                }
                else
                {
                    byte* nativeLabelIdStackBytes = stackalloc byte[labelIdByteCount + 1];
                    nativeLabelId = nativeLabelIdStackBytes;
                }
                
                int nativeLabelIdOffset = Util.GetUtf8(labelId, nativeLabelId, labelIdByteCount);
                nativeLabelId[nativeLabelIdOffset] = 0;
            }
            else
            {
                nativeLabelId = null;
            }
            
            int yBins = (int) ImPlotBin.Sturges;
            ImPlotRect range = new ImPlotRect();
            ImPlotHistogramFlags flags = 0;
            fixed (uint* nativeXs = &xs)
            {
                fixed (uint* nativeYs = &ys)
                {
                    double ret = ImPlotNative.ImPlot_PlotHistogram2D_U32Ptr(nativeLabelId, nativeXs, nativeYs, count, xBins, yBins, range, flags);
                    if (labelIdByteCount > Util.StackAllocationSizeLimit)
                    {
                        Util.Free(nativeLabelId);
                    }
                    
                    return ret;
                }
            }
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
            byte* nativeLabelId;
            int labelIdByteCount = 0;
            if (labelId != null)
            {
                labelIdByteCount = Encoding.UTF8.GetByteCount(labelId);
                if (labelIdByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeLabelId = Util.Allocate(labelIdByteCount + 1);
                }
                else
                {
                    byte* nativeLabelIdStackBytes = stackalloc byte[labelIdByteCount + 1];
                    nativeLabelId = nativeLabelIdStackBytes;
                }
                
                int nativeLabelIdOffset = Util.GetUtf8(labelId, nativeLabelId, labelIdByteCount);
                nativeLabelId[nativeLabelIdOffset] = 0;
            }
            else
            {
                nativeLabelId = null;
            }
            
            ImPlotRect range = new ImPlotRect();
            ImPlotHistogramFlags flags = 0;
            fixed (uint* nativeXs = &xs)
            {
                fixed (uint* nativeYs = &ys)
                {
                    double ret = ImPlotNative.ImPlot_PlotHistogram2D_U32Ptr(nativeLabelId, nativeXs, nativeYs, count, xBins, yBins, range, flags);
                    if (labelIdByteCount > Util.StackAllocationSizeLimit)
                    {
                        Util.Free(nativeLabelId);
                    }
                    
                    return ret;
                }
            }
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
            byte* nativeLabelId;
            int labelIdByteCount = 0;
            if (labelId != null)
            {
                labelIdByteCount = Encoding.UTF8.GetByteCount(labelId);
                if (labelIdByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeLabelId = Util.Allocate(labelIdByteCount + 1);
                }
                else
                {
                    byte* nativeLabelIdStackBytes = stackalloc byte[labelIdByteCount + 1];
                    nativeLabelId = nativeLabelIdStackBytes;
                }
                
                int nativeLabelIdOffset = Util.GetUtf8(labelId, nativeLabelId, labelIdByteCount);
                nativeLabelId[nativeLabelIdOffset] = 0;
            }
            else
            {
                nativeLabelId = null;
            }
            
            ImPlotHistogramFlags flags = 0;
            fixed (uint* nativeXs = &xs)
            {
                fixed (uint* nativeYs = &ys)
                {
                    double ret = ImPlotNative.ImPlot_PlotHistogram2D_U32Ptr(nativeLabelId, nativeXs, nativeYs, count, xBins, yBins, range, flags);
                    if (labelIdByteCount > Util.StackAllocationSizeLimit)
                    {
                        Util.Free(nativeLabelId);
                    }
                    
                    return ret;
                }
            }
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
            byte* nativeLabelId;
            int labelIdByteCount = 0;
            if (labelId != null)
            {
                labelIdByteCount = Encoding.UTF8.GetByteCount(labelId);
                if (labelIdByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeLabelId = Util.Allocate(labelIdByteCount + 1);
                }
                else
                {
                    byte* nativeLabelIdStackBytes = stackalloc byte[labelIdByteCount + 1];
                    nativeLabelId = nativeLabelIdStackBytes;
                }
                
                int nativeLabelIdOffset = Util.GetUtf8(labelId, nativeLabelId, labelIdByteCount);
                nativeLabelId[nativeLabelIdOffset] = 0;
            }
            else
            {
                nativeLabelId = null;
            }
            
            fixed (uint* nativeXs = &xs)
            {
                fixed (uint* nativeYs = &ys)
                {
                    double ret = ImPlotNative.ImPlot_PlotHistogram2D_U32Ptr(nativeLabelId, nativeXs, nativeYs, count, xBins, yBins, range, flags);
                    if (labelIdByteCount > Util.StackAllocationSizeLimit)
                    {
                        Util.Free(nativeLabelId);
                    }
                    
                    return ret;
                }
            }
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
            byte* nativeLabelId;
            int labelIdByteCount = 0;
            if (labelId != null)
            {
                labelIdByteCount = Encoding.UTF8.GetByteCount(labelId);
                if (labelIdByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeLabelId = Util.Allocate(labelIdByteCount + 1);
                }
                else
                {
                    byte* nativeLabelIdStackBytes = stackalloc byte[labelIdByteCount + 1];
                    nativeLabelId = nativeLabelIdStackBytes;
                }
                
                int nativeLabelIdOffset = Util.GetUtf8(labelId, nativeLabelId, labelIdByteCount);
                nativeLabelId[nativeLabelIdOffset] = 0;
            }
            else
            {
                nativeLabelId = null;
            }
            
            int xBins = (int) ImPlotBin.Sturges;
            int yBins = (int) ImPlotBin.Sturges;
            ImPlotRect range = new ImPlotRect();
            ImPlotHistogramFlags flags = 0;
            fixed (long* nativeXs = &xs)
            {
                fixed (long* nativeYs = &ys)
                {
                    double ret = ImPlotNative.ImPlot_PlotHistogram2D_S64Ptr(nativeLabelId, nativeXs, nativeYs, count, xBins, yBins, range, flags);
                    if (labelIdByteCount > Util.StackAllocationSizeLimit)
                    {
                        Util.Free(nativeLabelId);
                    }
                    
                    return ret;
                }
            }
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
            byte* nativeLabelId;
            int labelIdByteCount = 0;
            if (labelId != null)
            {
                labelIdByteCount = Encoding.UTF8.GetByteCount(labelId);
                if (labelIdByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeLabelId = Util.Allocate(labelIdByteCount + 1);
                }
                else
                {
                    byte* nativeLabelIdStackBytes = stackalloc byte[labelIdByteCount + 1];
                    nativeLabelId = nativeLabelIdStackBytes;
                }
                
                int nativeLabelIdOffset = Util.GetUtf8(labelId, nativeLabelId, labelIdByteCount);
                nativeLabelId[nativeLabelIdOffset] = 0;
            }
            else
            {
                nativeLabelId = null;
            }
            
            int yBins = (int) ImPlotBin.Sturges;
            ImPlotRect range = new ImPlotRect();
            ImPlotHistogramFlags flags = 0;
            fixed (long* nativeXs = &xs)
            {
                fixed (long* nativeYs = &ys)
                {
                    double ret = ImPlotNative.ImPlot_PlotHistogram2D_S64Ptr(nativeLabelId, nativeXs, nativeYs, count, xBins, yBins, range, flags);
                    if (labelIdByteCount > Util.StackAllocationSizeLimit)
                    {
                        Util.Free(nativeLabelId);
                    }
                    
                    return ret;
                }
            }
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
            byte* nativeLabelId;
            int labelIdByteCount = 0;
            if (labelId != null)
            {
                labelIdByteCount = Encoding.UTF8.GetByteCount(labelId);
                if (labelIdByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeLabelId = Util.Allocate(labelIdByteCount + 1);
                }
                else
                {
                    byte* nativeLabelIdStackBytes = stackalloc byte[labelIdByteCount + 1];
                    nativeLabelId = nativeLabelIdStackBytes;
                }
                
                int nativeLabelIdOffset = Util.GetUtf8(labelId, nativeLabelId, labelIdByteCount);
                nativeLabelId[nativeLabelIdOffset] = 0;
            }
            else
            {
                nativeLabelId = null;
            }
            
            ImPlotRect range = new ImPlotRect();
            ImPlotHistogramFlags flags = 0;
            fixed (long* nativeXs = &xs)
            {
                fixed (long* nativeYs = &ys)
                {
                    double ret = ImPlotNative.ImPlot_PlotHistogram2D_S64Ptr(nativeLabelId, nativeXs, nativeYs, count, xBins, yBins, range, flags);
                    if (labelIdByteCount > Util.StackAllocationSizeLimit)
                    {
                        Util.Free(nativeLabelId);
                    }
                    
                    return ret;
                }
            }
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
            byte* nativeLabelId;
            int labelIdByteCount = 0;
            if (labelId != null)
            {
                labelIdByteCount = Encoding.UTF8.GetByteCount(labelId);
                if (labelIdByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeLabelId = Util.Allocate(labelIdByteCount + 1);
                }
                else
                {
                    byte* nativeLabelIdStackBytes = stackalloc byte[labelIdByteCount + 1];
                    nativeLabelId = nativeLabelIdStackBytes;
                }
                
                int nativeLabelIdOffset = Util.GetUtf8(labelId, nativeLabelId, labelIdByteCount);
                nativeLabelId[nativeLabelIdOffset] = 0;
            }
            else
            {
                nativeLabelId = null;
            }
            
            ImPlotHistogramFlags flags = 0;
            fixed (long* nativeXs = &xs)
            {
                fixed (long* nativeYs = &ys)
                {
                    double ret = ImPlotNative.ImPlot_PlotHistogram2D_S64Ptr(nativeLabelId, nativeXs, nativeYs, count, xBins, yBins, range, flags);
                    if (labelIdByteCount > Util.StackAllocationSizeLimit)
                    {
                        Util.Free(nativeLabelId);
                    }
                    
                    return ret;
                }
            }
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
            byte* nativeLabelId;
            int labelIdByteCount = 0;
            if (labelId != null)
            {
                labelIdByteCount = Encoding.UTF8.GetByteCount(labelId);
                if (labelIdByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeLabelId = Util.Allocate(labelIdByteCount + 1);
                }
                else
                {
                    byte* nativeLabelIdStackBytes = stackalloc byte[labelIdByteCount + 1];
                    nativeLabelId = nativeLabelIdStackBytes;
                }
                
                int nativeLabelIdOffset = Util.GetUtf8(labelId, nativeLabelId, labelIdByteCount);
                nativeLabelId[nativeLabelIdOffset] = 0;
            }
            else
            {
                nativeLabelId = null;
            }
            
            fixed (long* nativeXs = &xs)
            {
                fixed (long* nativeYs = &ys)
                {
                    double ret = ImPlotNative.ImPlot_PlotHistogram2D_S64Ptr(nativeLabelId, nativeXs, nativeYs, count, xBins, yBins, range, flags);
                    if (labelIdByteCount > Util.StackAllocationSizeLimit)
                    {
                        Util.Free(nativeLabelId);
                    }
                    
                    return ret;
                }
            }
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
            byte* nativeLabelId;
            int labelIdByteCount = 0;
            if (labelId != null)
            {
                labelIdByteCount = Encoding.UTF8.GetByteCount(labelId);
                if (labelIdByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeLabelId = Util.Allocate(labelIdByteCount + 1);
                }
                else
                {
                    byte* nativeLabelIdStackBytes = stackalloc byte[labelIdByteCount + 1];
                    nativeLabelId = nativeLabelIdStackBytes;
                }
                
                int nativeLabelIdOffset = Util.GetUtf8(labelId, nativeLabelId, labelIdByteCount);
                nativeLabelId[nativeLabelIdOffset] = 0;
            }
            else
            {
                nativeLabelId = null;
            }
            
            int xBins = (int) ImPlotBin.Sturges;
            int yBins = (int) ImPlotBin.Sturges;
            ImPlotRect range = new ImPlotRect();
            ImPlotHistogramFlags flags = 0;
            fixed (ulong* nativeXs = &xs)
            {
                fixed (ulong* nativeYs = &ys)
                {
                    double ret = ImPlotNative.ImPlot_PlotHistogram2D_U64Ptr(nativeLabelId, nativeXs, nativeYs, count, xBins, yBins, range, flags);
                    if (labelIdByteCount > Util.StackAllocationSizeLimit)
                    {
                        Util.Free(nativeLabelId);
                    }
                    
                    return ret;
                }
            }
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
            byte* nativeLabelId;
            int labelIdByteCount = 0;
            if (labelId != null)
            {
                labelIdByteCount = Encoding.UTF8.GetByteCount(labelId);
                if (labelIdByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeLabelId = Util.Allocate(labelIdByteCount + 1);
                }
                else
                {
                    byte* nativeLabelIdStackBytes = stackalloc byte[labelIdByteCount + 1];
                    nativeLabelId = nativeLabelIdStackBytes;
                }
                
                int nativeLabelIdOffset = Util.GetUtf8(labelId, nativeLabelId, labelIdByteCount);
                nativeLabelId[nativeLabelIdOffset] = 0;
            }
            else
            {
                nativeLabelId = null;
            }
            
            int yBins = (int) ImPlotBin.Sturges;
            ImPlotRect range = new ImPlotRect();
            ImPlotHistogramFlags flags = 0;
            fixed (ulong* nativeXs = &xs)
            {
                fixed (ulong* nativeYs = &ys)
                {
                    double ret = ImPlotNative.ImPlot_PlotHistogram2D_U64Ptr(nativeLabelId, nativeXs, nativeYs, count, xBins, yBins, range, flags);
                    if (labelIdByteCount > Util.StackAllocationSizeLimit)
                    {
                        Util.Free(nativeLabelId);
                    }
                    
                    return ret;
                }
            }
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
            byte* nativeLabelId;
            int labelIdByteCount = 0;
            if (labelId != null)
            {
                labelIdByteCount = Encoding.UTF8.GetByteCount(labelId);
                if (labelIdByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeLabelId = Util.Allocate(labelIdByteCount + 1);
                }
                else
                {
                    byte* nativeLabelIdStackBytes = stackalloc byte[labelIdByteCount + 1];
                    nativeLabelId = nativeLabelIdStackBytes;
                }
                
                int nativeLabelIdOffset = Util.GetUtf8(labelId, nativeLabelId, labelIdByteCount);
                nativeLabelId[nativeLabelIdOffset] = 0;
            }
            else
            {
                nativeLabelId = null;
            }
            
            ImPlotRect range = new ImPlotRect();
            ImPlotHistogramFlags flags = 0;
            fixed (ulong* nativeXs = &xs)
            {
                fixed (ulong* nativeYs = &ys)
                {
                    double ret = ImPlotNative.ImPlot_PlotHistogram2D_U64Ptr(nativeLabelId, nativeXs, nativeYs, count, xBins, yBins, range, flags);
                    if (labelIdByteCount > Util.StackAllocationSizeLimit)
                    {
                        Util.Free(nativeLabelId);
                    }
                    
                    return ret;
                }
            }
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
            byte* nativeLabelId;
            int labelIdByteCount = 0;
            if (labelId != null)
            {
                labelIdByteCount = Encoding.UTF8.GetByteCount(labelId);
                if (labelIdByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeLabelId = Util.Allocate(labelIdByteCount + 1);
                }
                else
                {
                    byte* nativeLabelIdStackBytes = stackalloc byte[labelIdByteCount + 1];
                    nativeLabelId = nativeLabelIdStackBytes;
                }
                
                int nativeLabelIdOffset = Util.GetUtf8(labelId, nativeLabelId, labelIdByteCount);
                nativeLabelId[nativeLabelIdOffset] = 0;
            }
            else
            {
                nativeLabelId = null;
            }
            
            ImPlotHistogramFlags flags = 0;
            fixed (ulong* nativeXs = &xs)
            {
                fixed (ulong* nativeYs = &ys)
                {
                    double ret = ImPlotNative.ImPlot_PlotHistogram2D_U64Ptr(nativeLabelId, nativeXs, nativeYs, count, xBins, yBins, range, flags);
                    if (labelIdByteCount > Util.StackAllocationSizeLimit)
                    {
                        Util.Free(nativeLabelId);
                    }
                    
                    return ret;
                }
            }
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
            byte* nativeLabelId;
            int labelIdByteCount = 0;
            if (labelId != null)
            {
                labelIdByteCount = Encoding.UTF8.GetByteCount(labelId);
                if (labelIdByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeLabelId = Util.Allocate(labelIdByteCount + 1);
                }
                else
                {
                    byte* nativeLabelIdStackBytes = stackalloc byte[labelIdByteCount + 1];
                    nativeLabelId = nativeLabelIdStackBytes;
                }
                
                int nativeLabelIdOffset = Util.GetUtf8(labelId, nativeLabelId, labelIdByteCount);
                nativeLabelId[nativeLabelIdOffset] = 0;
            }
            else
            {
                nativeLabelId = null;
            }
            
            fixed (ulong* nativeXs = &xs)
            {
                fixed (ulong* nativeYs = &ys)
                {
                    double ret = ImPlotNative.ImPlot_PlotHistogram2D_U64Ptr(nativeLabelId, nativeXs, nativeYs, count, xBins, yBins, range, flags);
                    if (labelIdByteCount > Util.StackAllocationSizeLimit)
                    {
                        Util.Free(nativeLabelId);
                    }
                    
                    return ret;
                }
            }
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
            byte* nativeLabelId;
            int labelIdByteCount = 0;
            if (labelId != null)
            {
                labelIdByteCount = Encoding.UTF8.GetByteCount(labelId);
                if (labelIdByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeLabelId = Util.Allocate(labelIdByteCount + 1);
                }
                else
                {
                    byte* nativeLabelIdStackBytes = stackalloc byte[labelIdByteCount + 1];
                    nativeLabelId = nativeLabelIdStackBytes;
                }
                
                int nativeLabelIdOffset = Util.GetUtf8(labelId, nativeLabelId, labelIdByteCount);
                nativeLabelId[nativeLabelIdOffset] = 0;
            }
            else
            {
                nativeLabelId = null;
            }
            
            Vector2 uv0 = new Vector2();
            Vector2 uv1 = new Vector2(1, 1);
            Vector4 tintCol = new Vector4(1, 1, 1, 1);
            ImPlotImageFlags flags = 0;
            ImPlotNative.ImPlot_PlotImage(nativeLabelId, userTextureId, boundsMin, boundsMax, uv0, uv1, tintCol, flags);
            if (labelIdByteCount > Util.StackAllocationSizeLimit)
            {
                Util.Free(nativeLabelId);
            }
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
            byte* nativeLabelId;
            int labelIdByteCount = 0;
            if (labelId != null)
            {
                labelIdByteCount = Encoding.UTF8.GetByteCount(labelId);
                if (labelIdByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeLabelId = Util.Allocate(labelIdByteCount + 1);
                }
                else
                {
                    byte* nativeLabelIdStackBytes = stackalloc byte[labelIdByteCount + 1];
                    nativeLabelId = nativeLabelIdStackBytes;
                }
                
                int nativeLabelIdOffset = Util.GetUtf8(labelId, nativeLabelId, labelIdByteCount);
                nativeLabelId[nativeLabelIdOffset] = 0;
            }
            else
            {
                nativeLabelId = null;
            }
            
            Vector2 uv1 = new Vector2(1, 1);
            Vector4 tintCol = new Vector4(1, 1, 1, 1);
            ImPlotImageFlags flags = 0;
            ImPlotNative.ImPlot_PlotImage(nativeLabelId, userTextureId, boundsMin, boundsMax, uv0, uv1, tintCol, flags);
            if (labelIdByteCount > Util.StackAllocationSizeLimit)
            {
                Util.Free(nativeLabelId);
            }
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
            byte* nativeLabelId;
            int labelIdByteCount = 0;
            if (labelId != null)
            {
                labelIdByteCount = Encoding.UTF8.GetByteCount(labelId);
                if (labelIdByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeLabelId = Util.Allocate(labelIdByteCount + 1);
                }
                else
                {
                    byte* nativeLabelIdStackBytes = stackalloc byte[labelIdByteCount + 1];
                    nativeLabelId = nativeLabelIdStackBytes;
                }
                
                int nativeLabelIdOffset = Util.GetUtf8(labelId, nativeLabelId, labelIdByteCount);
                nativeLabelId[nativeLabelIdOffset] = 0;
            }
            else
            {
                nativeLabelId = null;
            }
            
            Vector4 tintCol = new Vector4(1, 1, 1, 1);
            ImPlotImageFlags flags = 0;
            ImPlotNative.ImPlot_PlotImage(nativeLabelId, userTextureId, boundsMin, boundsMax, uv0, uv1, tintCol, flags);
            if (labelIdByteCount > Util.StackAllocationSizeLimit)
            {
                Util.Free(nativeLabelId);
            }
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
            byte* nativeLabelId;
            int labelIdByteCount = 0;
            if (labelId != null)
            {
                labelIdByteCount = Encoding.UTF8.GetByteCount(labelId);
                if (labelIdByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeLabelId = Util.Allocate(labelIdByteCount + 1);
                }
                else
                {
                    byte* nativeLabelIdStackBytes = stackalloc byte[labelIdByteCount + 1];
                    nativeLabelId = nativeLabelIdStackBytes;
                }
                
                int nativeLabelIdOffset = Util.GetUtf8(labelId, nativeLabelId, labelIdByteCount);
                nativeLabelId[nativeLabelIdOffset] = 0;
            }
            else
            {
                nativeLabelId = null;
            }
            
            ImPlotImageFlags flags = 0;
            ImPlotNative.ImPlot_PlotImage(nativeLabelId, userTextureId, boundsMin, boundsMax, uv0, uv1, tintCol, flags);
            if (labelIdByteCount > Util.StackAllocationSizeLimit)
            {
                Util.Free(nativeLabelId);
            }
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
            byte* nativeLabelId;
            int labelIdByteCount = 0;
            if (labelId != null)
            {
                labelIdByteCount = Encoding.UTF8.GetByteCount(labelId);
                if (labelIdByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeLabelId = Util.Allocate(labelIdByteCount + 1);
                }
                else
                {
                    byte* nativeLabelIdStackBytes = stackalloc byte[labelIdByteCount + 1];
                    nativeLabelId = nativeLabelIdStackBytes;
                }
                
                int nativeLabelIdOffset = Util.GetUtf8(labelId, nativeLabelId, labelIdByteCount);
                nativeLabelId[nativeLabelIdOffset] = 0;
            }
            else
            {
                nativeLabelId = null;
            }
            
            ImPlotNative.ImPlot_PlotImage(nativeLabelId, userTextureId, boundsMin, boundsMax, uv0, uv1, tintCol, flags);
            if (labelIdByteCount > Util.StackAllocationSizeLimit)
            {
                Util.Free(nativeLabelId);
            }
        }
        
        /// <summary>
        ///     Plots the inf lines using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        public static void PlotInfLines(string labelId, ref float values, int count)
        {
            byte* nativeLabelId;
            int labelIdByteCount = 0;
            if (labelId != null)
            {
                labelIdByteCount = Encoding.UTF8.GetByteCount(labelId);
                if (labelIdByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeLabelId = Util.Allocate(labelIdByteCount + 1);
                }
                else
                {
                    byte* nativeLabelIdStackBytes = stackalloc byte[labelIdByteCount + 1];
                    nativeLabelId = nativeLabelIdStackBytes;
                }
                
                int nativeLabelIdOffset = Util.GetUtf8(labelId, nativeLabelId, labelIdByteCount);
                nativeLabelId[nativeLabelIdOffset] = 0;
            }
            else
            {
                nativeLabelId = null;
            }
            
            ImPlotInfLinesFlags flags = 0;
            int offset = 0;
            int stride = sizeof(float);
            fixed (float* nativeValues = &values)
            {
                ImPlotNative.ImPlot_PlotInfLines_FloatPtr(nativeLabelId, nativeValues, count, flags, offset, stride);
                if (labelIdByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeLabelId);
                }
            }
        }
        
        /// <summary>
        ///     Plots the inf lines using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="flags">The flags</param>
        public static void PlotInfLines(string labelId, ref float values, int count, ImPlotInfLinesFlags flags)
        {
            byte* nativeLabelId;
            int labelIdByteCount = 0;
            if (labelId != null)
            {
                labelIdByteCount = Encoding.UTF8.GetByteCount(labelId);
                if (labelIdByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeLabelId = Util.Allocate(labelIdByteCount + 1);
                }
                else
                {
                    byte* nativeLabelIdStackBytes = stackalloc byte[labelIdByteCount + 1];
                    nativeLabelId = nativeLabelIdStackBytes;
                }
                
                int nativeLabelIdOffset = Util.GetUtf8(labelId, nativeLabelId, labelIdByteCount);
                nativeLabelId[nativeLabelIdOffset] = 0;
            }
            else
            {
                nativeLabelId = null;
            }
            
            int offset = 0;
            int stride = sizeof(float);
            fixed (float* nativeValues = &values)
            {
                ImPlotNative.ImPlot_PlotInfLines_FloatPtr(nativeLabelId, nativeValues, count, flags, offset, stride);
                if (labelIdByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeLabelId);
                }
            }
        }
        
        /// <summary>
        ///     Plots the inf lines using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        public static void PlotInfLines(string labelId, ref float values, int count, ImPlotInfLinesFlags flags, int offset)
        {
            byte* nativeLabelId;
            int labelIdByteCount = 0;
            if (labelId != null)
            {
                labelIdByteCount = Encoding.UTF8.GetByteCount(labelId);
                if (labelIdByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeLabelId = Util.Allocate(labelIdByteCount + 1);
                }
                else
                {
                    byte* nativeLabelIdStackBytes = stackalloc byte[labelIdByteCount + 1];
                    nativeLabelId = nativeLabelIdStackBytes;
                }
                
                int nativeLabelIdOffset = Util.GetUtf8(labelId, nativeLabelId, labelIdByteCount);
                nativeLabelId[nativeLabelIdOffset] = 0;
            }
            else
            {
                nativeLabelId = null;
            }
            
            int stride = sizeof(float);
            fixed (float* nativeValues = &values)
            {
                ImPlotNative.ImPlot_PlotInfLines_FloatPtr(nativeLabelId, nativeValues, count, flags, offset, stride);
                if (labelIdByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeLabelId);
                }
            }
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
        public static void PlotInfLines(string labelId, ref float values, int count, ImPlotInfLinesFlags flags, int offset, int stride)
        {
            byte* nativeLabelId;
            int labelIdByteCount = 0;
            if (labelId != null)
            {
                labelIdByteCount = Encoding.UTF8.GetByteCount(labelId);
                if (labelIdByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeLabelId = Util.Allocate(labelIdByteCount + 1);
                }
                else
                {
                    byte* nativeLabelIdStackBytes = stackalloc byte[labelIdByteCount + 1];
                    nativeLabelId = nativeLabelIdStackBytes;
                }
                
                int nativeLabelIdOffset = Util.GetUtf8(labelId, nativeLabelId, labelIdByteCount);
                nativeLabelId[nativeLabelIdOffset] = 0;
            }
            else
            {
                nativeLabelId = null;
            }
            
            fixed (float* nativeValues = &values)
            {
                ImPlotNative.ImPlot_PlotInfLines_FloatPtr(nativeLabelId, nativeValues, count, flags, offset, stride);
                if (labelIdByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeLabelId);
                }
            }
        }
        
        /// <summary>
        ///     Plots the inf lines using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        public static void PlotInfLines(string labelId, ref double values, int count)
        {
            byte* nativeLabelId;
            int labelIdByteCount = 0;
            if (labelId != null)
            {
                labelIdByteCount = Encoding.UTF8.GetByteCount(labelId);
                if (labelIdByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeLabelId = Util.Allocate(labelIdByteCount + 1);
                }
                else
                {
                    byte* nativeLabelIdStackBytes = stackalloc byte[labelIdByteCount + 1];
                    nativeLabelId = nativeLabelIdStackBytes;
                }
                
                int nativeLabelIdOffset = Util.GetUtf8(labelId, nativeLabelId, labelIdByteCount);
                nativeLabelId[nativeLabelIdOffset] = 0;
            }
            else
            {
                nativeLabelId = null;
            }
            
            ImPlotInfLinesFlags flags = 0;
            int offset = 0;
            int stride = sizeof(double);
            fixed (double* nativeValues = &values)
            {
                ImPlotNative.ImPlot_PlotInfLines_doublePtr(nativeLabelId, nativeValues, count, flags, offset, stride);
                if (labelIdByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeLabelId);
                }
            }
        }
        
        /// <summary>
        ///     Plots the inf lines using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="flags">The flags</param>
        public static void PlotInfLines(string labelId, ref double values, int count, ImPlotInfLinesFlags flags)
        {
            byte* nativeLabelId;
            int labelIdByteCount = 0;
            if (labelId != null)
            {
                labelIdByteCount = Encoding.UTF8.GetByteCount(labelId);
                if (labelIdByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeLabelId = Util.Allocate(labelIdByteCount + 1);
                }
                else
                {
                    byte* nativeLabelIdStackBytes = stackalloc byte[labelIdByteCount + 1];
                    nativeLabelId = nativeLabelIdStackBytes;
                }
                
                int nativeLabelIdOffset = Util.GetUtf8(labelId, nativeLabelId, labelIdByteCount);
                nativeLabelId[nativeLabelIdOffset] = 0;
            }
            else
            {
                nativeLabelId = null;
            }
            
            int offset = 0;
            int stride = sizeof(double);
            fixed (double* nativeValues = &values)
            {
                ImPlotNative.ImPlot_PlotInfLines_doublePtr(nativeLabelId, nativeValues, count, flags, offset, stride);
                if (labelIdByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeLabelId);
                }
            }
        }
        
        /// <summary>
        ///     Plots the inf lines using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        public static void PlotInfLines(string labelId, ref double values, int count, ImPlotInfLinesFlags flags, int offset)
        {
            byte* nativeLabelId;
            int labelIdByteCount = 0;
            if (labelId != null)
            {
                labelIdByteCount = Encoding.UTF8.GetByteCount(labelId);
                if (labelIdByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeLabelId = Util.Allocate(labelIdByteCount + 1);
                }
                else
                {
                    byte* nativeLabelIdStackBytes = stackalloc byte[labelIdByteCount + 1];
                    nativeLabelId = nativeLabelIdStackBytes;
                }
                
                int nativeLabelIdOffset = Util.GetUtf8(labelId, nativeLabelId, labelIdByteCount);
                nativeLabelId[nativeLabelIdOffset] = 0;
            }
            else
            {
                nativeLabelId = null;
            }
            
            int stride = sizeof(double);
            fixed (double* nativeValues = &values)
            {
                ImPlotNative.ImPlot_PlotInfLines_doublePtr(nativeLabelId, nativeValues, count, flags, offset, stride);
                if (labelIdByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeLabelId);
                }
            }
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
        public static void PlotInfLines(string labelId, ref double values, int count, ImPlotInfLinesFlags flags, int offset, int stride)
        {
            byte* nativeLabelId;
            int labelIdByteCount = 0;
            if (labelId != null)
            {
                labelIdByteCount = Encoding.UTF8.GetByteCount(labelId);
                if (labelIdByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeLabelId = Util.Allocate(labelIdByteCount + 1);
                }
                else
                {
                    byte* nativeLabelIdStackBytes = stackalloc byte[labelIdByteCount + 1];
                    nativeLabelId = nativeLabelIdStackBytes;
                }
                
                int nativeLabelIdOffset = Util.GetUtf8(labelId, nativeLabelId, labelIdByteCount);
                nativeLabelId[nativeLabelIdOffset] = 0;
            }
            else
            {
                nativeLabelId = null;
            }
            
            fixed (double* nativeValues = &values)
            {
                ImPlotNative.ImPlot_PlotInfLines_doublePtr(nativeLabelId, nativeValues, count, flags, offset, stride);
                if (labelIdByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeLabelId);
                }
            }
        }
        
        /// <summary>
        ///     Plots the inf lines using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        public static void PlotInfLines(string labelId, ref sbyte values, int count)
        {
            byte* nativeLabelId;
            int labelIdByteCount = 0;
            if (labelId != null)
            {
                labelIdByteCount = Encoding.UTF8.GetByteCount(labelId);
                if (labelIdByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeLabelId = Util.Allocate(labelIdByteCount + 1);
                }
                else
                {
                    byte* nativeLabelIdStackBytes = stackalloc byte[labelIdByteCount + 1];
                    nativeLabelId = nativeLabelIdStackBytes;
                }
                
                int nativeLabelIdOffset = Util.GetUtf8(labelId, nativeLabelId, labelIdByteCount);
                nativeLabelId[nativeLabelIdOffset] = 0;
            }
            else
            {
                nativeLabelId = null;
            }
            
            ImPlotInfLinesFlags flags = 0;
            int offset = 0;
            int stride = sizeof(sbyte);
            fixed (sbyte* nativeValues = &values)
            {
                ImPlotNative.ImPlot_PlotInfLines_S8Ptr(nativeLabelId, nativeValues, count, flags, offset, stride);
                if (labelIdByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeLabelId);
                }
            }
        }
        
        /// <summary>
        ///     Plots the inf lines using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="flags">The flags</param>
        public static void PlotInfLines(string labelId, ref sbyte values, int count, ImPlotInfLinesFlags flags)
        {
            byte* nativeLabelId;
            int labelIdByteCount = 0;
            if (labelId != null)
            {
                labelIdByteCount = Encoding.UTF8.GetByteCount(labelId);
                if (labelIdByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeLabelId = Util.Allocate(labelIdByteCount + 1);
                }
                else
                {
                    byte* nativeLabelIdStackBytes = stackalloc byte[labelIdByteCount + 1];
                    nativeLabelId = nativeLabelIdStackBytes;
                }
                
                int nativeLabelIdOffset = Util.GetUtf8(labelId, nativeLabelId, labelIdByteCount);
                nativeLabelId[nativeLabelIdOffset] = 0;
            }
            else
            {
                nativeLabelId = null;
            }
            
            int offset = 0;
            int stride = sizeof(sbyte);
            fixed (sbyte* nativeValues = &values)
            {
                ImPlotNative.ImPlot_PlotInfLines_S8Ptr(nativeLabelId, nativeValues, count, flags, offset, stride);
                if (labelIdByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeLabelId);
                }
            }
        }
        
        /// <summary>
        ///     Plots the inf lines using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        public static void PlotInfLines(string labelId, ref sbyte values, int count, ImPlotInfLinesFlags flags, int offset)
        {
            byte* nativeLabelId;
            int labelIdByteCount = 0;
            if (labelId != null)
            {
                labelIdByteCount = Encoding.UTF8.GetByteCount(labelId);
                if (labelIdByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeLabelId = Util.Allocate(labelIdByteCount + 1);
                }
                else
                {
                    byte* nativeLabelIdStackBytes = stackalloc byte[labelIdByteCount + 1];
                    nativeLabelId = nativeLabelIdStackBytes;
                }
                
                int nativeLabelIdOffset = Util.GetUtf8(labelId, nativeLabelId, labelIdByteCount);
                nativeLabelId[nativeLabelIdOffset] = 0;
            }
            else
            {
                nativeLabelId = null;
            }
            
            int stride = sizeof(sbyte);
            fixed (sbyte* nativeValues = &values)
            {
                ImPlotNative.ImPlot_PlotInfLines_S8Ptr(nativeLabelId, nativeValues, count, flags, offset, stride);
                if (labelIdByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeLabelId);
                }
            }
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
        public static void PlotInfLines(string labelId, ref sbyte values, int count, ImPlotInfLinesFlags flags, int offset, int stride)
        {
            byte* nativeLabelId;
            int labelIdByteCount = 0;
            if (labelId != null)
            {
                labelIdByteCount = Encoding.UTF8.GetByteCount(labelId);
                if (labelIdByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeLabelId = Util.Allocate(labelIdByteCount + 1);
                }
                else
                {
                    byte* nativeLabelIdStackBytes = stackalloc byte[labelIdByteCount + 1];
                    nativeLabelId = nativeLabelIdStackBytes;
                }
                
                int nativeLabelIdOffset = Util.GetUtf8(labelId, nativeLabelId, labelIdByteCount);
                nativeLabelId[nativeLabelIdOffset] = 0;
            }
            else
            {
                nativeLabelId = null;
            }
            
            fixed (sbyte* nativeValues = &values)
            {
                ImPlotNative.ImPlot_PlotInfLines_S8Ptr(nativeLabelId, nativeValues, count, flags, offset, stride);
                if (labelIdByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeLabelId);
                }
            }
        }
        
        /// <summary>
        ///     Plots the inf lines using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        public static void PlotInfLines(string labelId, ref byte values, int count)
        {
            byte* nativeLabelId;
            int labelIdByteCount = 0;
            if (labelId != null)
            {
                labelIdByteCount = Encoding.UTF8.GetByteCount(labelId);
                if (labelIdByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeLabelId = Util.Allocate(labelIdByteCount + 1);
                }
                else
                {
                    byte* nativeLabelIdStackBytes = stackalloc byte[labelIdByteCount + 1];
                    nativeLabelId = nativeLabelIdStackBytes;
                }
                
                int nativeLabelIdOffset = Util.GetUtf8(labelId, nativeLabelId, labelIdByteCount);
                nativeLabelId[nativeLabelIdOffset] = 0;
            }
            else
            {
                nativeLabelId = null;
            }
            
            ImPlotInfLinesFlags flags = 0;
            int offset = 0;
            int stride = sizeof(byte);
            fixed (byte* nativeValues = &values)
            {
                ImPlotNative.ImPlot_PlotInfLines_U8Ptr(nativeLabelId, nativeValues, count, flags, offset, stride);
                if (labelIdByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeLabelId);
                }
            }
        }
        
        /// <summary>
        ///     Plots the inf lines using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="flags">The flags</param>
        public static void PlotInfLines(string labelId, ref byte values, int count, ImPlotInfLinesFlags flags)
        {
            byte* nativeLabelId;
            int labelIdByteCount = 0;
            if (labelId != null)
            {
                labelIdByteCount = Encoding.UTF8.GetByteCount(labelId);
                if (labelIdByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeLabelId = Util.Allocate(labelIdByteCount + 1);
                }
                else
                {
                    byte* nativeLabelIdStackBytes = stackalloc byte[labelIdByteCount + 1];
                    nativeLabelId = nativeLabelIdStackBytes;
                }
                
                int nativeLabelIdOffset = Util.GetUtf8(labelId, nativeLabelId, labelIdByteCount);
                nativeLabelId[nativeLabelIdOffset] = 0;
            }
            else
            {
                nativeLabelId = null;
            }
            
            int offset = 0;
            int stride = sizeof(byte);
            fixed (byte* nativeValues = &values)
            {
                ImPlotNative.ImPlot_PlotInfLines_U8Ptr(nativeLabelId, nativeValues, count, flags, offset, stride);
                if (labelIdByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeLabelId);
                }
            }
        }
        
        /// <summary>
        ///     Plots the inf lines using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        public static void PlotInfLines(string labelId, ref byte values, int count, ImPlotInfLinesFlags flags, int offset)
        {
            byte* nativeLabelId;
            int labelIdByteCount = 0;
            if (labelId != null)
            {
                labelIdByteCount = Encoding.UTF8.GetByteCount(labelId);
                if (labelIdByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeLabelId = Util.Allocate(labelIdByteCount + 1);
                }
                else
                {
                    byte* nativeLabelIdStackBytes = stackalloc byte[labelIdByteCount + 1];
                    nativeLabelId = nativeLabelIdStackBytes;
                }
                
                int nativeLabelIdOffset = Util.GetUtf8(labelId, nativeLabelId, labelIdByteCount);
                nativeLabelId[nativeLabelIdOffset] = 0;
            }
            else
            {
                nativeLabelId = null;
            }
            
            int stride = sizeof(byte);
            fixed (byte* nativeValues = &values)
            {
                ImPlotNative.ImPlot_PlotInfLines_U8Ptr(nativeLabelId, nativeValues, count, flags, offset, stride);
                if (labelIdByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeLabelId);
                }
            }
        }
    }
}