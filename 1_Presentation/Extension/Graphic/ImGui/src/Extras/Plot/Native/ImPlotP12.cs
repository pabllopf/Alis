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

namespace Alis.Extension.Graphic.ImGui.Extras.Plot.Native
{
  public static unsafe partial class ImPlot
      {
        
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
        public static double PlotHistogram(string labelId, ref byte values, int count, int bins, double barScale, ImPlotRange range)
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
            fixed (byte* nativeValues = &values)
            {
                double ret = ImPlotNative.ImPlot_PlotHistogram_U8Ptr(nativeLabelId, nativeValues, count, bins, barScale, range, flags);
                if (labelIdByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeLabelId);
                }
                
                return ret;
            }
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
        public static double PlotHistogram(string labelId, ref byte values, int count, int bins, double barScale, ImPlotRange range, ImPlotHistogramFlags flags)
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
            
            fixed (byte* nativeValues = &values)
            {
                double ret = ImPlotNative.ImPlot_PlotHistogram_U8Ptr(nativeLabelId, nativeValues, count, bins, barScale, range, flags);
                if (labelIdByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeLabelId);
                }
                
                return ret;
            }
        }
        
        /// <summary>
        ///     Plots the histogram using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <returns>The double</returns>
        public static double PlotHistogram(string labelId, ref short values, int count)
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
            
            int bins = (int) ImPlotBin.Sturges;
            double barScale = 1.0;
            ImPlotRange range = new ImPlotRange();
            ImPlotHistogramFlags flags = 0;
            fixed (short* nativeValues = &values)
            {
                double ret = ImPlotNative.ImPlot_PlotHistogram_S16Ptr(nativeLabelId, nativeValues, count, bins, barScale, range, flags);
                if (labelIdByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeLabelId);
                }
                
                return ret;
            }
        }
        
        /// <summary>
        ///     Plots the histogram using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="bins">The bins</param>
        /// <returns>The double</returns>
        public static double PlotHistogram(string labelId, ref short values, int count, int bins)
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
            
            double barScale = 1.0;
            ImPlotRange range = new ImPlotRange();
            ImPlotHistogramFlags flags = 0;
            fixed (short* nativeValues = &values)
            {
                double ret = ImPlotNative.ImPlot_PlotHistogram_S16Ptr(nativeLabelId, nativeValues, count, bins, barScale, range, flags);
                if (labelIdByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeLabelId);
                }
                
                return ret;
            }
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
        public static double PlotHistogram(string labelId, ref short values, int count, int bins, double barScale)
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
            
            ImPlotRange range = new ImPlotRange();
            ImPlotHistogramFlags flags = 0;
            fixed (short* nativeValues = &values)
            {
                double ret = ImPlotNative.ImPlot_PlotHistogram_S16Ptr(nativeLabelId, nativeValues, count, bins, barScale, range, flags);
                if (labelIdByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeLabelId);
                }
                
                return ret;
            }
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
        public static double PlotHistogram(string labelId, ref short values, int count, int bins, double barScale, ImPlotRange range)
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
            fixed (short* nativeValues = &values)
            {
                double ret = ImPlotNative.ImPlot_PlotHistogram_S16Ptr(nativeLabelId, nativeValues, count, bins, barScale, range, flags);
                if (labelIdByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeLabelId);
                }
                
                return ret;
            }
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
        public static double PlotHistogram(string labelId, ref short values, int count, int bins, double barScale, ImPlotRange range, ImPlotHistogramFlags flags)
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
            
            fixed (short* nativeValues = &values)
            {
                double ret = ImPlotNative.ImPlot_PlotHistogram_S16Ptr(nativeLabelId, nativeValues, count, bins, barScale, range, flags);
                if (labelIdByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeLabelId);
                }
                
                return ret;
            }
        }
        
        /// <summary>
        ///     Plots the histogram using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <returns>The double</returns>
        public static double PlotHistogram(string labelId, ref ushort values, int count)
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
            
            int bins = (int) ImPlotBin.Sturges;
            double barScale = 1.0;
            ImPlotRange range = new ImPlotRange();
            ImPlotHistogramFlags flags = 0;
            fixed (ushort* nativeValues = &values)
            {
                double ret = ImPlotNative.ImPlot_PlotHistogram_U16Ptr(nativeLabelId, nativeValues, count, bins, barScale, range, flags);
                if (labelIdByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeLabelId);
                }
                
                return ret;
            }
        }
        
        /// <summary>
        ///     Plots the histogram using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="bins">The bins</param>
        /// <returns>The double</returns>
        public static double PlotHistogram(string labelId, ref ushort values, int count, int bins)
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
            
            double barScale = 1.0;
            ImPlotRange range = new ImPlotRange();
            ImPlotHistogramFlags flags = 0;
            fixed (ushort* nativeValues = &values)
            {
                double ret = ImPlotNative.ImPlot_PlotHistogram_U16Ptr(nativeLabelId, nativeValues, count, bins, barScale, range, flags);
                if (labelIdByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeLabelId);
                }
                
                return ret;
            }
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
        public static double PlotHistogram(string labelId, ref ushort values, int count, int bins, double barScale)
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
            
            ImPlotRange range = new ImPlotRange();
            ImPlotHistogramFlags flags = 0;
            fixed (ushort* nativeValues = &values)
            {
                double ret = ImPlotNative.ImPlot_PlotHistogram_U16Ptr(nativeLabelId, nativeValues, count, bins, barScale, range, flags);
                if (labelIdByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeLabelId);
                }
                
                return ret;
            }
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
        public static double PlotHistogram(string labelId, ref ushort values, int count, int bins, double barScale, ImPlotRange range)
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
            fixed (ushort* nativeValues = &values)
            {
                double ret = ImPlotNative.ImPlot_PlotHistogram_U16Ptr(nativeLabelId, nativeValues, count, bins, barScale, range, flags);
                if (labelIdByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeLabelId);
                }
                
                return ret;
            }
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
        public static double PlotHistogram(string labelId, ref ushort values, int count, int bins, double barScale, ImPlotRange range, ImPlotHistogramFlags flags)
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
            
            fixed (ushort* nativeValues = &values)
            {
                double ret = ImPlotNative.ImPlot_PlotHistogram_U16Ptr(nativeLabelId, nativeValues, count, bins, barScale, range, flags);
                if (labelIdByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeLabelId);
                }
                
                return ret;
            }
        }
        
        /// <summary>
        ///     Plots the histogram using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <returns>The double</returns>
        public static double PlotHistogram(string labelId, ref int values, int count)
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
            
            int bins = (int) ImPlotBin.Sturges;
            double barScale = 1.0;
            ImPlotRange range = new ImPlotRange();
            ImPlotHistogramFlags flags = 0;
            fixed (int* nativeValues = &values)
            {
                double ret = ImPlotNative.ImPlot_PlotHistogram_S32Ptr(nativeLabelId, nativeValues, count, bins, barScale, range, flags);
                if (labelIdByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeLabelId);
                }
                
                return ret;
            }
        }
        
        /// <summary>
        ///     Plots the histogram using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="bins">The bins</param>
        /// <returns>The double</returns>
        public static double PlotHistogram(string labelId, ref int values, int count, int bins)
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
            
            double barScale = 1.0;
            ImPlotRange range = new ImPlotRange();
            ImPlotHistogramFlags flags = 0;
            fixed (int* nativeValues = &values)
            {
                double ret = ImPlotNative.ImPlot_PlotHistogram_S32Ptr(nativeLabelId, nativeValues, count, bins, barScale, range, flags);
                if (labelIdByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeLabelId);
                }
                
                return ret;
            }
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
        public static double PlotHistogram(string labelId, ref int values, int count, int bins, double barScale)
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
            
            ImPlotRange range = new ImPlotRange();
            ImPlotHistogramFlags flags = 0;
            fixed (int* nativeValues = &values)
            {
                double ret = ImPlotNative.ImPlot_PlotHistogram_S32Ptr(nativeLabelId, nativeValues, count, bins, barScale, range, flags);
                if (labelIdByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeLabelId);
                }
                
                return ret;
            }
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
        public static double PlotHistogram(string labelId, ref int values, int count, int bins, double barScale, ImPlotRange range)
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
            fixed (int* nativeValues = &values)
            {
                double ret = ImPlotNative.ImPlot_PlotHistogram_S32Ptr(nativeLabelId, nativeValues, count, bins, barScale, range, flags);
                if (labelIdByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeLabelId);
                }
                
                return ret;
            }
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
        public static double PlotHistogram(string labelId, ref int values, int count, int bins, double barScale, ImPlotRange range, ImPlotHistogramFlags flags)
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
            
            fixed (int* nativeValues = &values)
            {
                double ret = ImPlotNative.ImPlot_PlotHistogram_S32Ptr(nativeLabelId, nativeValues, count, bins, barScale, range, flags);
                if (labelIdByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeLabelId);
                }
                
                return ret;
            }
        }
        
        /// <summary>
        ///     Plots the histogram using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <returns>The double</returns>
        public static double PlotHistogram(string labelId, ref uint values, int count)
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
            
            int bins = (int) ImPlotBin.Sturges;
            double barScale = 1.0;
            ImPlotRange range = new ImPlotRange();
            ImPlotHistogramFlags flags = 0;
            fixed (uint* nativeValues = &values)
            {
                double ret = ImPlotNative.ImPlot_PlotHistogram_U32Ptr(nativeLabelId, nativeValues, count, bins, barScale, range, flags);
                if (labelIdByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeLabelId);
                }
                
                return ret;
            }
        }
        
        /// <summary>
        ///     Plots the histogram using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="bins">The bins</param>
        /// <returns>The double</returns>
        public static double PlotHistogram(string labelId, ref uint values, int count, int bins)
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
            
            double barScale = 1.0;
            ImPlotRange range = new ImPlotRange();
            ImPlotHistogramFlags flags = 0;
            fixed (uint* nativeValues = &values)
            {
                double ret = ImPlotNative.ImPlot_PlotHistogram_U32Ptr(nativeLabelId, nativeValues, count, bins, barScale, range, flags);
                if (labelIdByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeLabelId);
                }
                
                return ret;
            }
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
        public static double PlotHistogram(string labelId, ref uint values, int count, int bins, double barScale)
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
            
            ImPlotRange range = new ImPlotRange();
            ImPlotHistogramFlags flags = 0;
            fixed (uint* nativeValues = &values)
            {
                double ret = ImPlotNative.ImPlot_PlotHistogram_U32Ptr(nativeLabelId, nativeValues, count, bins, barScale, range, flags);
                if (labelIdByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeLabelId);
                }
                
                return ret;
            }
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
        public static double PlotHistogram(string labelId, ref uint values, int count, int bins, double barScale, ImPlotRange range)
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
            fixed (uint* nativeValues = &values)
            {
                double ret = ImPlotNative.ImPlot_PlotHistogram_U32Ptr(nativeLabelId, nativeValues, count, bins, barScale, range, flags);
                if (labelIdByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeLabelId);
                }
                
                return ret;
            }
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
        public static double PlotHistogram(string labelId, ref uint values, int count, int bins, double barScale, ImPlotRange range, ImPlotHistogramFlags flags)
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
            
            fixed (uint* nativeValues = &values)
            {
                double ret = ImPlotNative.ImPlot_PlotHistogram_U32Ptr(nativeLabelId, nativeValues, count, bins, barScale, range, flags);
                if (labelIdByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeLabelId);
                }
                
                return ret;
            }
        }
        
        /// <summary>
        ///     Plots the histogram using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <returns>The double</returns>
        public static double PlotHistogram(string labelId, ref long values, int count)
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
            
            int bins = (int) ImPlotBin.Sturges;
            double barScale = 1.0;
            ImPlotRange range = new ImPlotRange();
            ImPlotHistogramFlags flags = 0;
            fixed (long* nativeValues = &values)
            {
                double ret = ImPlotNative.ImPlot_PlotHistogram_S64Ptr(nativeLabelId, nativeValues, count, bins, barScale, range, flags);
                if (labelIdByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeLabelId);
                }
                
                return ret;
            }
        }
        
        /// <summary>
        ///     Plots the histogram using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="bins">The bins</param>
        /// <returns>The double</returns>
        public static double PlotHistogram(string labelId, ref long values, int count, int bins)
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
            
            double barScale = 1.0;
            ImPlotRange range = new ImPlotRange();
            ImPlotHistogramFlags flags = 0;
            fixed (long* nativeValues = &values)
            {
                double ret = ImPlotNative.ImPlot_PlotHistogram_S64Ptr(nativeLabelId, nativeValues, count, bins, barScale, range, flags);
                if (labelIdByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeLabelId);
                }
                
                return ret;
            }
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
        public static double PlotHistogram(string labelId, ref long values, int count, int bins, double barScale)
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
            
            ImPlotRange range = new ImPlotRange();
            ImPlotHistogramFlags flags = 0;
            fixed (long* nativeValues = &values)
            {
                double ret = ImPlotNative.ImPlot_PlotHistogram_S64Ptr(nativeLabelId, nativeValues, count, bins, barScale, range, flags);
                if (labelIdByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeLabelId);
                }
                
                return ret;
            }
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
        public static double PlotHistogram(string labelId, ref long values, int count, int bins, double barScale, ImPlotRange range)
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
            fixed (long* nativeValues = &values)
            {
                double ret = ImPlotNative.ImPlot_PlotHistogram_S64Ptr(nativeLabelId, nativeValues, count, bins, barScale, range, flags);
                if (labelIdByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeLabelId);
                }
                
                return ret;
            }
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
        public static double PlotHistogram(string labelId, ref long values, int count, int bins, double barScale, ImPlotRange range, ImPlotHistogramFlags flags)
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
            
            fixed (long* nativeValues = &values)
            {
                double ret = ImPlotNative.ImPlot_PlotHistogram_S64Ptr(nativeLabelId, nativeValues, count, bins, barScale, range, flags);
                if (labelIdByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeLabelId);
                }
                
                return ret;
            }
        }
        
        /// <summary>
        ///     Plots the histogram using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <returns>The double</returns>
        public static double PlotHistogram(string labelId, ref ulong values, int count)
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
            
            int bins = (int) ImPlotBin.Sturges;
            double barScale = 1.0;
            ImPlotRange range = new ImPlotRange();
            ImPlotHistogramFlags flags = 0;
            fixed (ulong* nativeValues = &values)
            {
                double ret = ImPlotNative.ImPlot_PlotHistogram_U64Ptr(nativeLabelId, nativeValues, count, bins, barScale, range, flags);
                if (labelIdByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeLabelId);
                }
                
                return ret;
            }
        }
        
        /// <summary>
        ///     Plots the histogram using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="bins">The bins</param>
        /// <returns>The double</returns>
        public static double PlotHistogram(string labelId, ref ulong values, int count, int bins)
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
            
            double barScale = 1.0;
            ImPlotRange range = new ImPlotRange();
            ImPlotHistogramFlags flags = 0;
            fixed (ulong* nativeValues = &values)
            {
                double ret = ImPlotNative.ImPlot_PlotHistogram_U64Ptr(nativeLabelId, nativeValues, count, bins, barScale, range, flags);
                if (labelIdByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeLabelId);
                }
                
                return ret;
            }
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
        public static double PlotHistogram(string labelId, ref ulong values, int count, int bins, double barScale)
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
            
            ImPlotRange range = new ImPlotRange();
            ImPlotHistogramFlags flags = 0;
            fixed (ulong* nativeValues = &values)
            {
                double ret = ImPlotNative.ImPlot_PlotHistogram_U64Ptr(nativeLabelId, nativeValues, count, bins, barScale, range, flags);
                if (labelIdByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeLabelId);
                }
                
                return ret;
            }
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
        public static double PlotHistogram(string labelId, ref ulong values, int count, int bins, double barScale, ImPlotRange range)
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
            fixed (ulong* nativeValues = &values)
            {
                double ret = ImPlotNative.ImPlot_PlotHistogram_U64Ptr(nativeLabelId, nativeValues, count, bins, barScale, range, flags);
                if (labelIdByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeLabelId);
                }
                
                return ret;
            }
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
        public static double PlotHistogram(string labelId, ref ulong values, int count, int bins, double barScale, ImPlotRange range, ImPlotHistogramFlags flags)
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
            
            fixed (ulong* nativeValues = &values)
            {
                double ret = ImPlotNative.ImPlot_PlotHistogram_U64Ptr(nativeLabelId, nativeValues, count, bins, barScale, range, flags);
                if (labelIdByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeLabelId);
                }
                
                return ret;
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
        public static double PlotHistogram2D(string labelId, ref float xs, ref float ys, int count)
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
            fixed (float* nativeXs = &xs)
            {
                fixed (float* nativeYs = &ys)
                {
                    double ret = ImPlotNative.ImPlot_PlotHistogram2D_FloatPtr(nativeLabelId, nativeXs, nativeYs, count, xBins, yBins, range, flags);
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
        public static double PlotHistogram2D(string labelId, ref float xs, ref float ys, int count, int xBins)
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
            fixed (float* nativeXs = &xs)
            {
                fixed (float* nativeYs = &ys)
                {
                    double ret = ImPlotNative.ImPlot_PlotHistogram2D_FloatPtr(nativeLabelId, nativeXs, nativeYs, count, xBins, yBins, range, flags);
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
        public static double PlotHistogram2D(string labelId, ref float xs, ref float ys, int count, int xBins, int yBins)
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
            fixed (float* nativeXs = &xs)
            {
                fixed (float* nativeYs = &ys)
                {
                    double ret = ImPlotNative.ImPlot_PlotHistogram2D_FloatPtr(nativeLabelId, nativeXs, nativeYs, count, xBins, yBins, range, flags);
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
        public static double PlotHistogram2D(string labelId, ref float xs, ref float ys, int count, int xBins, int yBins, ImPlotRect range)
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
            fixed (float* nativeXs = &xs)
            {
                fixed (float* nativeYs = &ys)
                {
                    double ret = ImPlotNative.ImPlot_PlotHistogram2D_FloatPtr(nativeLabelId, nativeXs, nativeYs, count, xBins, yBins, range, flags);
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
        public static double PlotHistogram2D(string labelId, ref float xs, ref float ys, int count, int xBins, int yBins, ImPlotRect range, ImPlotHistogramFlags flags)
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
            
            fixed (float* nativeXs = &xs)
            {
                fixed (float* nativeYs = &ys)
                {
                    double ret = ImPlotNative.ImPlot_PlotHistogram2D_FloatPtr(nativeLabelId, nativeXs, nativeYs, count, xBins, yBins, range, flags);
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
        public static double PlotHistogram2D(string labelId, ref double xs, ref double ys, int count)
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
            fixed (double* nativeXs = &xs)
            {
                fixed (double* nativeYs = &ys)
                {
                    double ret = ImPlotNative.ImPlot_PlotHistogram2D_doublePtr(nativeLabelId, nativeXs, nativeYs, count, xBins, yBins, range, flags);
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
        public static double PlotHistogram2D(string labelId, ref double xs, ref double ys, int count, int xBins)
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
            fixed (double* nativeXs = &xs)
            {
                fixed (double* nativeYs = &ys)
                {
                    double ret = ImPlotNative.ImPlot_PlotHistogram2D_doublePtr(nativeLabelId, nativeXs, nativeYs, count, xBins, yBins, range, flags);
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
        public static double PlotHistogram2D(string labelId, ref double xs, ref double ys, int count, int xBins, int yBins)
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
            fixed (double* nativeXs = &xs)
            {
                fixed (double* nativeYs = &ys)
                {
                    double ret = ImPlotNative.ImPlot_PlotHistogram2D_doublePtr(nativeLabelId, nativeXs, nativeYs, count, xBins, yBins, range, flags);
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
        public static double PlotHistogram2D(string labelId, ref double xs, ref double ys, int count, int xBins, int yBins, ImPlotRect range)
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
            fixed (double* nativeXs = &xs)
            {
                fixed (double* nativeYs = &ys)
                {
                    double ret = ImPlotNative.ImPlot_PlotHistogram2D_doublePtr(nativeLabelId, nativeXs, nativeYs, count, xBins, yBins, range, flags);
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
        public static double PlotHistogram2D(string labelId, ref double xs, ref double ys, int count, int xBins, int yBins, ImPlotRect range, ImPlotHistogramFlags flags)
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
            
            fixed (double* nativeXs = &xs)
            {
                fixed (double* nativeYs = &ys)
                {
                    double ret = ImPlotNative.ImPlot_PlotHistogram2D_doublePtr(nativeLabelId, nativeXs, nativeYs, count, xBins, yBins, range, flags);
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
        public static double PlotHistogram2D(string labelId, ref sbyte xs, ref sbyte ys, int count)
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
            fixed (sbyte* nativeXs = &xs)
            {
                fixed (sbyte* nativeYs = &ys)
                {
                    double ret = ImPlotNative.ImPlot_PlotHistogram2D_S8Ptr(nativeLabelId, nativeXs, nativeYs, count, xBins, yBins, range, flags);
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
        public static double PlotHistogram2D(string labelId, ref sbyte xs, ref sbyte ys, int count, int xBins)
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
            fixed (sbyte* nativeXs = &xs)
            {
                fixed (sbyte* nativeYs = &ys)
                {
                    double ret = ImPlotNative.ImPlot_PlotHistogram2D_S8Ptr(nativeLabelId, nativeXs, nativeYs, count, xBins, yBins, range, flags);
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
        public static double PlotHistogram2D(string labelId, ref sbyte xs, ref sbyte ys, int count, int xBins, int yBins)
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
            fixed (sbyte* nativeXs = &xs)
            {
                fixed (sbyte* nativeYs = &ys)
                {
                    double ret = ImPlotNative.ImPlot_PlotHistogram2D_S8Ptr(nativeLabelId, nativeXs, nativeYs, count, xBins, yBins, range, flags);
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
        public static double PlotHistogram2D(string labelId, ref sbyte xs, ref sbyte ys, int count, int xBins, int yBins, ImPlotRect range)
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
            fixed (sbyte* nativeXs = &xs)
            {
                fixed (sbyte* nativeYs = &ys)
                {
                    double ret = ImPlotNative.ImPlot_PlotHistogram2D_S8Ptr(nativeLabelId, nativeXs, nativeYs, count, xBins, yBins, range, flags);
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
        public static double PlotHistogram2D(string labelId, ref sbyte xs, ref sbyte ys, int count, int xBins, int yBins, ImPlotRect range, ImPlotHistogramFlags flags)
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
            
            fixed (sbyte* nativeXs = &xs)
            {
                fixed (sbyte* nativeYs = &ys)
                {
                    double ret = ImPlotNative.ImPlot_PlotHistogram2D_S8Ptr(nativeLabelId, nativeXs, nativeYs, count, xBins, yBins, range, flags);
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
        public static double PlotHistogram2D(string labelId, ref byte xs, ref byte ys, int count)
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
        /// <returns>The double</returns>
        public static double PlotHistogram2D(string labelId, ref byte xs, ref byte ys, int count, int xBins)
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
        /// <returns>The double</returns>
        public static double PlotHistogram2D(string labelId, ref byte xs, ref byte ys, int count, int xBins, int yBins)
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
        
    }
}