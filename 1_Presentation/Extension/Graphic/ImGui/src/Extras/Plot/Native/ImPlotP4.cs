// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImPlotP4.cs
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
        public static void PlotHeatmap(string labelId, ref double values, int rows, int cols, double scaleMin, double scaleMax, string labelFmt, ImPlotPoint boundsMin)
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
            
            byte* nativeLabelFmt;
            int labelFmtByteCount = 0;
            if (labelFmt != null)
            {
                labelFmtByteCount = Encoding.UTF8.GetByteCount(labelFmt);
                if (labelFmtByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeLabelFmt = Util.Allocate(labelFmtByteCount + 1);
                }
                else
                {
                    byte* nativeLabelFmtStackBytes = stackalloc byte[labelFmtByteCount + 1];
                    nativeLabelFmt = nativeLabelFmtStackBytes;
                }
                
                int nativeLabelFmtOffset = Util.GetUtf8(labelFmt, nativeLabelFmt, labelFmtByteCount);
                nativeLabelFmt[nativeLabelFmtOffset] = 0;
            }
            else
            {
                nativeLabelFmt = null;
            }
            
            ImPlotPoint boundsMax = new ImPlotPoint {X = 1, Y = 1};
            ImPlotHeatmapFlags flags = 0;
            fixed (double* nativeValues = &values)
            {
                ImPlotNative.ImPlot_PlotHeatmap_doublePtr(nativeLabelId, nativeValues, rows, cols, scaleMin, scaleMax, nativeLabelFmt, boundsMin, boundsMax, flags);
                if (labelIdByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeLabelId);
                }
                
                if (labelFmtByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeLabelFmt);
                }
            }
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
        public static void PlotHeatmap(string labelId, ref double values, int rows, int cols, double scaleMin, double scaleMax, string labelFmt, ImPlotPoint boundsMin, ImPlotPoint boundsMax)
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
            
            byte* nativeLabelFmt;
            int labelFmtByteCount = 0;
            if (labelFmt != null)
            {
                labelFmtByteCount = Encoding.UTF8.GetByteCount(labelFmt);
                if (labelFmtByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeLabelFmt = Util.Allocate(labelFmtByteCount + 1);
                }
                else
                {
                    byte* nativeLabelFmtStackBytes = stackalloc byte[labelFmtByteCount + 1];
                    nativeLabelFmt = nativeLabelFmtStackBytes;
                }
                
                int nativeLabelFmtOffset = Util.GetUtf8(labelFmt, nativeLabelFmt, labelFmtByteCount);
                nativeLabelFmt[nativeLabelFmtOffset] = 0;
            }
            else
            {
                nativeLabelFmt = null;
            }
            
            ImPlotHeatmapFlags flags = 0;
            fixed (double* nativeValues = &values)
            {
                ImPlotNative.ImPlot_PlotHeatmap_doublePtr(nativeLabelId, nativeValues, rows, cols, scaleMin, scaleMax, nativeLabelFmt, boundsMin, boundsMax, flags);
                if (labelIdByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeLabelId);
                }
                
                if (labelFmtByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeLabelFmt);
                }
            }
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
        public static void PlotHeatmap(string labelId, ref double values, int rows, int cols, double scaleMin, double scaleMax, string labelFmt, ImPlotPoint boundsMin, ImPlotPoint boundsMax, ImPlotHeatmapFlags flags)
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
            
            byte* nativeLabelFmt;
            int labelFmtByteCount = 0;
            if (labelFmt != null)
            {
                labelFmtByteCount = Encoding.UTF8.GetByteCount(labelFmt);
                if (labelFmtByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeLabelFmt = Util.Allocate(labelFmtByteCount + 1);
                }
                else
                {
                    byte* nativeLabelFmtStackBytes = stackalloc byte[labelFmtByteCount + 1];
                    nativeLabelFmt = nativeLabelFmtStackBytes;
                }
                
                int nativeLabelFmtOffset = Util.GetUtf8(labelFmt, nativeLabelFmt, labelFmtByteCount);
                nativeLabelFmt[nativeLabelFmtOffset] = 0;
            }
            else
            {
                nativeLabelFmt = null;
            }
            
            fixed (double* nativeValues = &values)
            {
                ImPlotNative.ImPlot_PlotHeatmap_doublePtr(nativeLabelId, nativeValues, rows, cols, scaleMin, scaleMax, nativeLabelFmt, boundsMin, boundsMax, flags);
                if (labelIdByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeLabelId);
                }
                
                if (labelFmtByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeLabelFmt);
                }
            }
        }
        
        /// <summary>
        ///     Plots the heatmap using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="rows">The rows</param>
        /// <param name="cols">The cols</param>
        public static void PlotHeatmap(string labelId, ref sbyte values, int rows, int cols)
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
            
            double scaleMin = 0;
            double scaleMax = 0;
            byte* nativeLabelFmt;
            int labelFmtByteCount = 0;
            labelFmtByteCount = Encoding.UTF8.GetByteCount("%.1f");
            if (labelFmtByteCount > Util.StackAllocationSizeLimit)
            {
                nativeLabelFmt = Util.Allocate(labelFmtByteCount + 1);
            }
            else
            {
                byte* nativeLabelFmtStackBytes = stackalloc byte[labelFmtByteCount + 1];
                nativeLabelFmt = nativeLabelFmtStackBytes;
            }
            
            int nativeLabelFmtOffset = Util.GetUtf8("%.1f", nativeLabelFmt, labelFmtByteCount);
            nativeLabelFmt[nativeLabelFmtOffset] = 0;
            ImPlotPoint boundsMin = new ImPlotPoint {X = 0, Y = 0};
            ImPlotPoint boundsMax = new ImPlotPoint {X = 1, Y = 1};
            ImPlotHeatmapFlags flags = 0;
            fixed (sbyte* nativeValues = &values)
            {
                ImPlotNative.ImPlot_PlotHeatmap_S8Ptr(nativeLabelId, nativeValues, rows, cols, scaleMin, scaleMax, nativeLabelFmt, boundsMin, boundsMax, flags);
                if (labelIdByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeLabelId);
                }
                
                if (labelFmtByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeLabelFmt);
                }
            }
        }
        
        /// <summary>
        ///     Plots the heatmap using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="rows">The rows</param>
        /// <param name="cols">The cols</param>
        /// <param name="scaleMin">The scale min</param>
        public static void PlotHeatmap(string labelId, ref sbyte values, int rows, int cols, double scaleMin)
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
            
            double scaleMax = 0;
            byte* nativeLabelFmt;
            int labelFmtByteCount = 0;
            labelFmtByteCount = Encoding.UTF8.GetByteCount("%.1f");
            if (labelFmtByteCount > Util.StackAllocationSizeLimit)
            {
                nativeLabelFmt = Util.Allocate(labelFmtByteCount + 1);
            }
            else
            {
                byte* nativeLabelFmtStackBytes = stackalloc byte[labelFmtByteCount + 1];
                nativeLabelFmt = nativeLabelFmtStackBytes;
            }
            
            int nativeLabelFmtOffset = Util.GetUtf8("%.1f", nativeLabelFmt, labelFmtByteCount);
            nativeLabelFmt[nativeLabelFmtOffset] = 0;
            ImPlotPoint boundsMin = new ImPlotPoint {X = 0, Y = 0};
            ImPlotPoint boundsMax = new ImPlotPoint {X = 1, Y = 1};
            ImPlotHeatmapFlags flags = 0;
            fixed (sbyte* nativeValues = &values)
            {
                ImPlotNative.ImPlot_PlotHeatmap_S8Ptr(nativeLabelId, nativeValues, rows, cols, scaleMin, scaleMax, nativeLabelFmt, boundsMin, boundsMax, flags);
                if (labelIdByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeLabelId);
                }
                
                if (labelFmtByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeLabelFmt);
                }
            }
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
        public static void PlotHeatmap(string labelId, ref sbyte values, int rows, int cols, double scaleMin, double scaleMax)
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
            
            byte* nativeLabelFmt;
            int labelFmtByteCount = 0;
            labelFmtByteCount = Encoding.UTF8.GetByteCount("%.1f");
            if (labelFmtByteCount > Util.StackAllocationSizeLimit)
            {
                nativeLabelFmt = Util.Allocate(labelFmtByteCount + 1);
            }
            else
            {
                byte* nativeLabelFmtStackBytes = stackalloc byte[labelFmtByteCount + 1];
                nativeLabelFmt = nativeLabelFmtStackBytes;
            }
            
            int nativeLabelFmtOffset = Util.GetUtf8("%.1f", nativeLabelFmt, labelFmtByteCount);
            nativeLabelFmt[nativeLabelFmtOffset] = 0;
            ImPlotPoint boundsMin = new ImPlotPoint {X = 0, Y = 0};
            ImPlotPoint boundsMax = new ImPlotPoint {X = 1, Y = 1};
            ImPlotHeatmapFlags flags = 0;
            fixed (sbyte* nativeValues = &values)
            {
                ImPlotNative.ImPlot_PlotHeatmap_S8Ptr(nativeLabelId, nativeValues, rows, cols, scaleMin, scaleMax, nativeLabelFmt, boundsMin, boundsMax, flags);
                if (labelIdByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeLabelId);
                }
                
                if (labelFmtByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeLabelFmt);
                }
            }
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
        public static void PlotHeatmap(string labelId, ref sbyte values, int rows, int cols, double scaleMin, double scaleMax, string labelFmt)
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
            
            byte* nativeLabelFmt;
            int labelFmtByteCount = 0;
            if (labelFmt != null)
            {
                labelFmtByteCount = Encoding.UTF8.GetByteCount(labelFmt);
                if (labelFmtByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeLabelFmt = Util.Allocate(labelFmtByteCount + 1);
                }
                else
                {
                    byte* nativeLabelFmtStackBytes = stackalloc byte[labelFmtByteCount + 1];
                    nativeLabelFmt = nativeLabelFmtStackBytes;
                }
                
                int nativeLabelFmtOffset = Util.GetUtf8(labelFmt, nativeLabelFmt, labelFmtByteCount);
                nativeLabelFmt[nativeLabelFmtOffset] = 0;
            }
            else
            {
                nativeLabelFmt = null;
            }
            
            ImPlotPoint boundsMin = new ImPlotPoint {X = 0, Y = 0};
            ImPlotPoint boundsMax = new ImPlotPoint {X = 1, Y = 1};
            ImPlotHeatmapFlags flags = 0;
            fixed (sbyte* nativeValues = &values)
            {
                ImPlotNative.ImPlot_PlotHeatmap_S8Ptr(nativeLabelId, nativeValues, rows, cols, scaleMin, scaleMax, nativeLabelFmt, boundsMin, boundsMax, flags);
                if (labelIdByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeLabelId);
                }
                
                if (labelFmtByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeLabelFmt);
                }
            }
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
        public static void PlotHeatmap(string labelId, ref sbyte values, int rows, int cols, double scaleMin, double scaleMax, string labelFmt, ImPlotPoint boundsMin)
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
            
            byte* nativeLabelFmt;
            int labelFmtByteCount = 0;
            if (labelFmt != null)
            {
                labelFmtByteCount = Encoding.UTF8.GetByteCount(labelFmt);
                if (labelFmtByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeLabelFmt = Util.Allocate(labelFmtByteCount + 1);
                }
                else
                {
                    byte* nativeLabelFmtStackBytes = stackalloc byte[labelFmtByteCount + 1];
                    nativeLabelFmt = nativeLabelFmtStackBytes;
                }
                
                int nativeLabelFmtOffset = Util.GetUtf8(labelFmt, nativeLabelFmt, labelFmtByteCount);
                nativeLabelFmt[nativeLabelFmtOffset] = 0;
            }
            else
            {
                nativeLabelFmt = null;
            }
            
            ImPlotPoint boundsMax = new ImPlotPoint {X = 1, Y = 1};
            ImPlotHeatmapFlags flags = 0;
            fixed (sbyte* nativeValues = &values)
            {
                ImPlotNative.ImPlot_PlotHeatmap_S8Ptr(nativeLabelId, nativeValues, rows, cols, scaleMin, scaleMax, nativeLabelFmt, boundsMin, boundsMax, flags);
                if (labelIdByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeLabelId);
                }
                
                if (labelFmtByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeLabelFmt);
                }
            }
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
        public static void PlotHeatmap(string labelId, ref sbyte values, int rows, int cols, double scaleMin, double scaleMax, string labelFmt, ImPlotPoint boundsMin, ImPlotPoint boundsMax)
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
            
            byte* nativeLabelFmt;
            int labelFmtByteCount = 0;
            if (labelFmt != null)
            {
                labelFmtByteCount = Encoding.UTF8.GetByteCount(labelFmt);
                if (labelFmtByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeLabelFmt = Util.Allocate(labelFmtByteCount + 1);
                }
                else
                {
                    byte* nativeLabelFmtStackBytes = stackalloc byte[labelFmtByteCount + 1];
                    nativeLabelFmt = nativeLabelFmtStackBytes;
                }
                
                int nativeLabelFmtOffset = Util.GetUtf8(labelFmt, nativeLabelFmt, labelFmtByteCount);
                nativeLabelFmt[nativeLabelFmtOffset] = 0;
            }
            else
            {
                nativeLabelFmt = null;
            }
            
            ImPlotHeatmapFlags flags = 0;
            fixed (sbyte* nativeValues = &values)
            {
                ImPlotNative.ImPlot_PlotHeatmap_S8Ptr(nativeLabelId, nativeValues, rows, cols, scaleMin, scaleMax, nativeLabelFmt, boundsMin, boundsMax, flags);
                if (labelIdByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeLabelId);
                }
                
                if (labelFmtByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeLabelFmt);
                }
            }
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
        public static void PlotHeatmap(string labelId, ref sbyte values, int rows, int cols, double scaleMin, double scaleMax, string labelFmt, ImPlotPoint boundsMin, ImPlotPoint boundsMax, ImPlotHeatmapFlags flags)
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
            
            byte* nativeLabelFmt;
            int labelFmtByteCount = 0;
            if (labelFmt != null)
            {
                labelFmtByteCount = Encoding.UTF8.GetByteCount(labelFmt);
                if (labelFmtByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeLabelFmt = Util.Allocate(labelFmtByteCount + 1);
                }
                else
                {
                    byte* nativeLabelFmtStackBytes = stackalloc byte[labelFmtByteCount + 1];
                    nativeLabelFmt = nativeLabelFmtStackBytes;
                }
                
                int nativeLabelFmtOffset = Util.GetUtf8(labelFmt, nativeLabelFmt, labelFmtByteCount);
                nativeLabelFmt[nativeLabelFmtOffset] = 0;
            }
            else
            {
                nativeLabelFmt = null;
            }
            
            fixed (sbyte* nativeValues = &values)
            {
                ImPlotNative.ImPlot_PlotHeatmap_S8Ptr(nativeLabelId, nativeValues, rows, cols, scaleMin, scaleMax, nativeLabelFmt, boundsMin, boundsMax, flags);
                if (labelIdByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeLabelId);
                }
                
                if (labelFmtByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeLabelFmt);
                }
            }
        }
        
        /// <summary>
        ///     Plots the heatmap using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="rows">The rows</param>
        /// <param name="cols">The cols</param>
        public static void PlotHeatmap(string labelId, ref byte values, int rows, int cols)
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
            
            double scaleMin = 0;
            double scaleMax = 0;
            byte* nativeLabelFmt;
            int labelFmtByteCount = 0;
            labelFmtByteCount = Encoding.UTF8.GetByteCount("%.1f");
            if (labelFmtByteCount > Util.StackAllocationSizeLimit)
            {
                nativeLabelFmt = Util.Allocate(labelFmtByteCount + 1);
            }
            else
            {
                byte* nativeLabelFmtStackBytes = stackalloc byte[labelFmtByteCount + 1];
                nativeLabelFmt = nativeLabelFmtStackBytes;
            }
            
            int nativeLabelFmtOffset = Util.GetUtf8("%.1f", nativeLabelFmt, labelFmtByteCount);
            nativeLabelFmt[nativeLabelFmtOffset] = 0;
            ImPlotPoint boundsMin = new ImPlotPoint {X = 0, Y = 0};
            ImPlotPoint boundsMax = new ImPlotPoint {X = 1, Y = 1};
            ImPlotHeatmapFlags flags = 0;
            fixed (byte* nativeValues = &values)
            {
                ImPlotNative.ImPlot_PlotHeatmap_U8Ptr(nativeLabelId, nativeValues, rows, cols, scaleMin, scaleMax, nativeLabelFmt, boundsMin, boundsMax, flags);
                if (labelIdByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeLabelId);
                }
                
                if (labelFmtByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeLabelFmt);
                }
            }
        }
        
        /// <summary>
        ///     Plots the heatmap using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="rows">The rows</param>
        /// <param name="cols">The cols</param>
        /// <param name="scaleMin">The scale min</param>
        public static void PlotHeatmap(string labelId, ref byte values, int rows, int cols, double scaleMin)
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
            
            double scaleMax = 0;
            byte* nativeLabelFmt;
            int labelFmtByteCount = 0;
            labelFmtByteCount = Encoding.UTF8.GetByteCount("%.1f");
            if (labelFmtByteCount > Util.StackAllocationSizeLimit)
            {
                nativeLabelFmt = Util.Allocate(labelFmtByteCount + 1);
            }
            else
            {
                byte* nativeLabelFmtStackBytes = stackalloc byte[labelFmtByteCount + 1];
                nativeLabelFmt = nativeLabelFmtStackBytes;
            }
            
            int nativeLabelFmtOffset = Util.GetUtf8("%.1f", nativeLabelFmt, labelFmtByteCount);
            nativeLabelFmt[nativeLabelFmtOffset] = 0;
            ImPlotPoint boundsMin = new ImPlotPoint {X = 0, Y = 0};
            ImPlotPoint boundsMax = new ImPlotPoint {X = 1, Y = 1};
            ImPlotHeatmapFlags flags = 0;
            fixed (byte* nativeValues = &values)
            {
                ImPlotNative.ImPlot_PlotHeatmap_U8Ptr(nativeLabelId, nativeValues, rows, cols, scaleMin, scaleMax, nativeLabelFmt, boundsMin, boundsMax, flags);
                if (labelIdByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeLabelId);
                }
                
                if (labelFmtByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeLabelFmt);
                }
            }
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
        public static void PlotHeatmap(string labelId, ref byte values, int rows, int cols, double scaleMin, double scaleMax)
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
            
            byte* nativeLabelFmt;
            int labelFmtByteCount = 0;
            labelFmtByteCount = Encoding.UTF8.GetByteCount("%.1f");
            if (labelFmtByteCount > Util.StackAllocationSizeLimit)
            {
                nativeLabelFmt = Util.Allocate(labelFmtByteCount + 1);
            }
            else
            {
                byte* nativeLabelFmtStackBytes = stackalloc byte[labelFmtByteCount + 1];
                nativeLabelFmt = nativeLabelFmtStackBytes;
            }
            
            int nativeLabelFmtOffset = Util.GetUtf8("%.1f", nativeLabelFmt, labelFmtByteCount);
            nativeLabelFmt[nativeLabelFmtOffset] = 0;
            ImPlotPoint boundsMin = new ImPlotPoint {X = 0, Y = 0};
            ImPlotPoint boundsMax = new ImPlotPoint {X = 1, Y = 1};
            ImPlotHeatmapFlags flags = 0;
            fixed (byte* nativeValues = &values)
            {
                ImPlotNative.ImPlot_PlotHeatmap_U8Ptr(nativeLabelId, nativeValues, rows, cols, scaleMin, scaleMax, nativeLabelFmt, boundsMin, boundsMax, flags);
                if (labelIdByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeLabelId);
                }
                
                if (labelFmtByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeLabelFmt);
                }
            }
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
        public static void PlotHeatmap(string labelId, ref byte values, int rows, int cols, double scaleMin, double scaleMax, string labelFmt)
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
            
            byte* nativeLabelFmt;
            int labelFmtByteCount = 0;
            if (labelFmt != null)
            {
                labelFmtByteCount = Encoding.UTF8.GetByteCount(labelFmt);
                if (labelFmtByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeLabelFmt = Util.Allocate(labelFmtByteCount + 1);
                }
                else
                {
                    byte* nativeLabelFmtStackBytes = stackalloc byte[labelFmtByteCount + 1];
                    nativeLabelFmt = nativeLabelFmtStackBytes;
                }
                
                int nativeLabelFmtOffset = Util.GetUtf8(labelFmt, nativeLabelFmt, labelFmtByteCount);
                nativeLabelFmt[nativeLabelFmtOffset] = 0;
            }
            else
            {
                nativeLabelFmt = null;
            }
            
            ImPlotPoint boundsMin = new ImPlotPoint {X = 0, Y = 0};
            ImPlotPoint boundsMax = new ImPlotPoint {X = 1, Y = 1};
            ImPlotHeatmapFlags flags = 0;
            fixed (byte* nativeValues = &values)
            {
                ImPlotNative.ImPlot_PlotHeatmap_U8Ptr(nativeLabelId, nativeValues, rows, cols, scaleMin, scaleMax, nativeLabelFmt, boundsMin, boundsMax, flags);
                if (labelIdByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeLabelId);
                }
                
                if (labelFmtByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeLabelFmt);
                }
            }
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
        public static void PlotHeatmap(string labelId, ref byte values, int rows, int cols, double scaleMin, double scaleMax, string labelFmt, ImPlotPoint boundsMin)
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
            
            byte* nativeLabelFmt;
            int labelFmtByteCount = 0;
            if (labelFmt != null)
            {
                labelFmtByteCount = Encoding.UTF8.GetByteCount(labelFmt);
                if (labelFmtByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeLabelFmt = Util.Allocate(labelFmtByteCount + 1);
                }
                else
                {
                    byte* nativeLabelFmtStackBytes = stackalloc byte[labelFmtByteCount + 1];
                    nativeLabelFmt = nativeLabelFmtStackBytes;
                }
                
                int nativeLabelFmtOffset = Util.GetUtf8(labelFmt, nativeLabelFmt, labelFmtByteCount);
                nativeLabelFmt[nativeLabelFmtOffset] = 0;
            }
            else
            {
                nativeLabelFmt = null;
            }
            
            ImPlotPoint boundsMax = new ImPlotPoint {X = 1, Y = 1};
            ImPlotHeatmapFlags flags = 0;
            fixed (byte* nativeValues = &values)
            {
                ImPlotNative.ImPlot_PlotHeatmap_U8Ptr(nativeLabelId, nativeValues, rows, cols, scaleMin, scaleMax, nativeLabelFmt, boundsMin, boundsMax, flags);
                if (labelIdByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeLabelId);
                }
                
                if (labelFmtByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeLabelFmt);
                }
            }
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
        public static void PlotHeatmap(string labelId, ref byte values, int rows, int cols, double scaleMin, double scaleMax, string labelFmt, ImPlotPoint boundsMin, ImPlotPoint boundsMax)
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
            
            byte* nativeLabelFmt;
            int labelFmtByteCount = 0;
            if (labelFmt != null)
            {
                labelFmtByteCount = Encoding.UTF8.GetByteCount(labelFmt);
                if (labelFmtByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeLabelFmt = Util.Allocate(labelFmtByteCount + 1);
                }
                else
                {
                    byte* nativeLabelFmtStackBytes = stackalloc byte[labelFmtByteCount + 1];
                    nativeLabelFmt = nativeLabelFmtStackBytes;
                }
                
                int nativeLabelFmtOffset = Util.GetUtf8(labelFmt, nativeLabelFmt, labelFmtByteCount);
                nativeLabelFmt[nativeLabelFmtOffset] = 0;
            }
            else
            {
                nativeLabelFmt = null;
            }
            
            ImPlotHeatmapFlags flags = 0;
            fixed (byte* nativeValues = &values)
            {
                ImPlotNative.ImPlot_PlotHeatmap_U8Ptr(nativeLabelId, nativeValues, rows, cols, scaleMin, scaleMax, nativeLabelFmt, boundsMin, boundsMax, flags);
                if (labelIdByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeLabelId);
                }
                
                if (labelFmtByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeLabelFmt);
                }
            }
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
        public static void PlotHeatmap(string labelId, ref byte values, int rows, int cols, double scaleMin, double scaleMax, string labelFmt, ImPlotPoint boundsMin, ImPlotPoint boundsMax, ImPlotHeatmapFlags flags)
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
            
            byte* nativeLabelFmt;
            int labelFmtByteCount = 0;
            if (labelFmt != null)
            {
                labelFmtByteCount = Encoding.UTF8.GetByteCount(labelFmt);
                if (labelFmtByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeLabelFmt = Util.Allocate(labelFmtByteCount + 1);
                }
                else
                {
                    byte* nativeLabelFmtStackBytes = stackalloc byte[labelFmtByteCount + 1];
                    nativeLabelFmt = nativeLabelFmtStackBytes;
                }
                
                int nativeLabelFmtOffset = Util.GetUtf8(labelFmt, nativeLabelFmt, labelFmtByteCount);
                nativeLabelFmt[nativeLabelFmtOffset] = 0;
            }
            else
            {
                nativeLabelFmt = null;
            }
            
            fixed (byte* nativeValues = &values)
            {
                ImPlotNative.ImPlot_PlotHeatmap_U8Ptr(nativeLabelId, nativeValues, rows, cols, scaleMin, scaleMax, nativeLabelFmt, boundsMin, boundsMax, flags);
                if (labelIdByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeLabelId);
                }
                
                if (labelFmtByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeLabelFmt);
                }
            }
        }
        
        /// <summary>
        ///     Plots the heatmap using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="rows">The rows</param>
        /// <param name="cols">The cols</param>
        public static void PlotHeatmap(string labelId, ref short values, int rows, int cols)
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
            
            double scaleMin = 0;
            double scaleMax = 0;
            byte* nativeLabelFmt;
            int labelFmtByteCount = 0;
            labelFmtByteCount = Encoding.UTF8.GetByteCount("%.1f");
            if (labelFmtByteCount > Util.StackAllocationSizeLimit)
            {
                nativeLabelFmt = Util.Allocate(labelFmtByteCount + 1);
            }
            else
            {
                byte* nativeLabelFmtStackBytes = stackalloc byte[labelFmtByteCount + 1];
                nativeLabelFmt = nativeLabelFmtStackBytes;
            }
            
            int nativeLabelFmtOffset = Util.GetUtf8("%.1f", nativeLabelFmt, labelFmtByteCount);
            nativeLabelFmt[nativeLabelFmtOffset] = 0;
            ImPlotPoint boundsMin = new ImPlotPoint {X = 0, Y = 0};
            ImPlotPoint boundsMax = new ImPlotPoint {X = 1, Y = 1};
            ImPlotHeatmapFlags flags = 0;
            fixed (short* nativeValues = &values)
            {
                ImPlotNative.ImPlot_PlotHeatmap_S16Ptr(nativeLabelId, nativeValues, rows, cols, scaleMin, scaleMax, nativeLabelFmt, boundsMin, boundsMax, flags);
                if (labelIdByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeLabelId);
                }
                
                if (labelFmtByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeLabelFmt);
                }
            }
        }
        
        /// <summary>
        ///     Plots the heatmap using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="rows">The rows</param>
        /// <param name="cols">The cols</param>
        /// <param name="scaleMin">The scale min</param>
        public static void PlotHeatmap(string labelId, ref short values, int rows, int cols, double scaleMin)
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
            
            double scaleMax = 0;
            byte* nativeLabelFmt;
            int labelFmtByteCount = 0;
            labelFmtByteCount = Encoding.UTF8.GetByteCount("%.1f");
            if (labelFmtByteCount > Util.StackAllocationSizeLimit)
            {
                nativeLabelFmt = Util.Allocate(labelFmtByteCount + 1);
            }
            else
            {
                byte* nativeLabelFmtStackBytes = stackalloc byte[labelFmtByteCount + 1];
                nativeLabelFmt = nativeLabelFmtStackBytes;
            }
            
            int nativeLabelFmtOffset = Util.GetUtf8("%.1f", nativeLabelFmt, labelFmtByteCount);
            nativeLabelFmt[nativeLabelFmtOffset] = 0;
            ImPlotPoint boundsMin = new ImPlotPoint {X = 0, Y = 0};
            ImPlotPoint boundsMax = new ImPlotPoint {X = 1, Y = 1};
            ImPlotHeatmapFlags flags = 0;
            fixed (short* nativeValues = &values)
            {
                ImPlotNative.ImPlot_PlotHeatmap_S16Ptr(nativeLabelId, nativeValues, rows, cols, scaleMin, scaleMax, nativeLabelFmt, boundsMin, boundsMax, flags);
                if (labelIdByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeLabelId);
                }
                
                if (labelFmtByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeLabelFmt);
                }
            }
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
        public static void PlotHeatmap(string labelId, ref short values, int rows, int cols, double scaleMin, double scaleMax)
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
            
            byte* nativeLabelFmt;
            int labelFmtByteCount = 0;
            labelFmtByteCount = Encoding.UTF8.GetByteCount("%.1f");
            if (labelFmtByteCount > Util.StackAllocationSizeLimit)
            {
                nativeLabelFmt = Util.Allocate(labelFmtByteCount + 1);
            }
            else
            {
                byte* nativeLabelFmtStackBytes = stackalloc byte[labelFmtByteCount + 1];
                nativeLabelFmt = nativeLabelFmtStackBytes;
            }
            
            int nativeLabelFmtOffset = Util.GetUtf8("%.1f", nativeLabelFmt, labelFmtByteCount);
            nativeLabelFmt[nativeLabelFmtOffset] = 0;
            ImPlotPoint boundsMin = new ImPlotPoint {X = 0, Y = 0};
            ImPlotPoint boundsMax = new ImPlotPoint {X = 1, Y = 1};
            ImPlotHeatmapFlags flags = 0;
            fixed (short* nativeValues = &values)
            {
                ImPlotNative.ImPlot_PlotHeatmap_S16Ptr(nativeLabelId, nativeValues, rows, cols, scaleMin, scaleMax, nativeLabelFmt, boundsMin, boundsMax, flags);
                if (labelIdByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeLabelId);
                }
                
                if (labelFmtByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeLabelFmt);
                }
            }
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
        public static void PlotHeatmap(string labelId, ref short values, int rows, int cols, double scaleMin, double scaleMax, string labelFmt)
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
            
            byte* nativeLabelFmt;
            int labelFmtByteCount = 0;
            if (labelFmt != null)
            {
                labelFmtByteCount = Encoding.UTF8.GetByteCount(labelFmt);
                if (labelFmtByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeLabelFmt = Util.Allocate(labelFmtByteCount + 1);
                }
                else
                {
                    byte* nativeLabelFmtStackBytes = stackalloc byte[labelFmtByteCount + 1];
                    nativeLabelFmt = nativeLabelFmtStackBytes;
                }
                
                int nativeLabelFmtOffset = Util.GetUtf8(labelFmt, nativeLabelFmt, labelFmtByteCount);
                nativeLabelFmt[nativeLabelFmtOffset] = 0;
            }
            else
            {
                nativeLabelFmt = null;
            }
            
            ImPlotPoint boundsMin = new ImPlotPoint {X = 0, Y = 0};
            ImPlotPoint boundsMax = new ImPlotPoint {X = 1, Y = 1};
            ImPlotHeatmapFlags flags = 0;
            fixed (short* nativeValues = &values)
            {
                ImPlotNative.ImPlot_PlotHeatmap_S16Ptr(nativeLabelId, nativeValues, rows, cols, scaleMin, scaleMax, nativeLabelFmt, boundsMin, boundsMax, flags);
                if (labelIdByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeLabelId);
                }
                
                if (labelFmtByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeLabelFmt);
                }
            }
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
        public static void PlotHeatmap(string labelId, ref short values, int rows, int cols, double scaleMin, double scaleMax, string labelFmt, ImPlotPoint boundsMin)
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
            
            byte* nativeLabelFmt;
            int labelFmtByteCount = 0;
            if (labelFmt != null)
            {
                labelFmtByteCount = Encoding.UTF8.GetByteCount(labelFmt);
                if (labelFmtByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeLabelFmt = Util.Allocate(labelFmtByteCount + 1);
                }
                else
                {
                    byte* nativeLabelFmtStackBytes = stackalloc byte[labelFmtByteCount + 1];
                    nativeLabelFmt = nativeLabelFmtStackBytes;
                }
                
                int nativeLabelFmtOffset = Util.GetUtf8(labelFmt, nativeLabelFmt, labelFmtByteCount);
                nativeLabelFmt[nativeLabelFmtOffset] = 0;
            }
            else
            {
                nativeLabelFmt = null;
            }
            
            ImPlotPoint boundsMax = new ImPlotPoint {X = 1, Y = 1};
            ImPlotHeatmapFlags flags = 0;
            fixed (short* nativeValues = &values)
            {
                ImPlotNative.ImPlot_PlotHeatmap_S16Ptr(nativeLabelId, nativeValues, rows, cols, scaleMin, scaleMax, nativeLabelFmt, boundsMin, boundsMax, flags);
                if (labelIdByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeLabelId);
                }
                
                if (labelFmtByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeLabelFmt);
                }
            }
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
        public static void PlotHeatmap(string labelId, ref short values, int rows, int cols, double scaleMin, double scaleMax, string labelFmt, ImPlotPoint boundsMin, ImPlotPoint boundsMax)
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
            
            byte* nativeLabelFmt;
            int labelFmtByteCount = 0;
            if (labelFmt != null)
            {
                labelFmtByteCount = Encoding.UTF8.GetByteCount(labelFmt);
                if (labelFmtByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeLabelFmt = Util.Allocate(labelFmtByteCount + 1);
                }
                else
                {
                    byte* nativeLabelFmtStackBytes = stackalloc byte[labelFmtByteCount + 1];
                    nativeLabelFmt = nativeLabelFmtStackBytes;
                }
                
                int nativeLabelFmtOffset = Util.GetUtf8(labelFmt, nativeLabelFmt, labelFmtByteCount);
                nativeLabelFmt[nativeLabelFmtOffset] = 0;
            }
            else
            {
                nativeLabelFmt = null;
            }
            
            ImPlotHeatmapFlags flags = 0;
            fixed (short* nativeValues = &values)
            {
                ImPlotNative.ImPlot_PlotHeatmap_S16Ptr(nativeLabelId, nativeValues, rows, cols, scaleMin, scaleMax, nativeLabelFmt, boundsMin, boundsMax, flags);
                if (labelIdByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeLabelId);
                }
                
                if (labelFmtByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeLabelFmt);
                }
            }
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
        public static void PlotHeatmap(string labelId, ref short values, int rows, int cols, double scaleMin, double scaleMax, string labelFmt, ImPlotPoint boundsMin, ImPlotPoint boundsMax, ImPlotHeatmapFlags flags)
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
            
            byte* nativeLabelFmt;
            int labelFmtByteCount = 0;
            if (labelFmt != null)
            {
                labelFmtByteCount = Encoding.UTF8.GetByteCount(labelFmt);
                if (labelFmtByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeLabelFmt = Util.Allocate(labelFmtByteCount + 1);
                }
                else
                {
                    byte* nativeLabelFmtStackBytes = stackalloc byte[labelFmtByteCount + 1];
                    nativeLabelFmt = nativeLabelFmtStackBytes;
                }
                
                int nativeLabelFmtOffset = Util.GetUtf8(labelFmt, nativeLabelFmt, labelFmtByteCount);
                nativeLabelFmt[nativeLabelFmtOffset] = 0;
            }
            else
            {
                nativeLabelFmt = null;
            }
            
            fixed (short* nativeValues = &values)
            {
                ImPlotNative.ImPlot_PlotHeatmap_S16Ptr(nativeLabelId, nativeValues, rows, cols, scaleMin, scaleMax, nativeLabelFmt, boundsMin, boundsMax, flags);
                if (labelIdByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeLabelId);
                }
                
                if (labelFmtByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeLabelFmt);
                }
            }
        }
        
        /// <summary>
        ///     Plots the heatmap using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="rows">The rows</param>
        /// <param name="cols">The cols</param>
        public static void PlotHeatmap(string labelId, ref ushort values, int rows, int cols)
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
            
            double scaleMin = 0;
            double scaleMax = 0;
            byte* nativeLabelFmt;
            int labelFmtByteCount = 0;
            labelFmtByteCount = Encoding.UTF8.GetByteCount("%.1f");
            if (labelFmtByteCount > Util.StackAllocationSizeLimit)
            {
                nativeLabelFmt = Util.Allocate(labelFmtByteCount + 1);
            }
            else
            {
                byte* nativeLabelFmtStackBytes = stackalloc byte[labelFmtByteCount + 1];
                nativeLabelFmt = nativeLabelFmtStackBytes;
            }
            
            int nativeLabelFmtOffset = Util.GetUtf8("%.1f", nativeLabelFmt, labelFmtByteCount);
            nativeLabelFmt[nativeLabelFmtOffset] = 0;
            ImPlotPoint boundsMin = new ImPlotPoint {X = 0, Y = 0};
            ImPlotPoint boundsMax = new ImPlotPoint {X = 1, Y = 1};
            ImPlotHeatmapFlags flags = 0;
            fixed (ushort* nativeValues = &values)
            {
                ImPlotNative.ImPlot_PlotHeatmap_U16Ptr(nativeLabelId, nativeValues, rows, cols, scaleMin, scaleMax, nativeLabelFmt, boundsMin, boundsMax, flags);
                if (labelIdByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeLabelId);
                }
                
                if (labelFmtByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeLabelFmt);
                }
            }
        }
        
        /// <summary>
        ///     Plots the heatmap using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="rows">The rows</param>
        /// <param name="cols">The cols</param>
        /// <param name="scaleMin">The scale min</param>
        public static void PlotHeatmap(string labelId, ref ushort values, int rows, int cols, double scaleMin)
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
            
            double scaleMax = 0;
            byte* nativeLabelFmt;
            int labelFmtByteCount = 0;
            labelFmtByteCount = Encoding.UTF8.GetByteCount("%.1f");
            if (labelFmtByteCount > Util.StackAllocationSizeLimit)
            {
                nativeLabelFmt = Util.Allocate(labelFmtByteCount + 1);
            }
            else
            {
                byte* nativeLabelFmtStackBytes = stackalloc byte[labelFmtByteCount + 1];
                nativeLabelFmt = nativeLabelFmtStackBytes;
            }
            
            int nativeLabelFmtOffset = Util.GetUtf8("%.1f", nativeLabelFmt, labelFmtByteCount);
            nativeLabelFmt[nativeLabelFmtOffset] = 0;
            ImPlotPoint boundsMin = new ImPlotPoint {X = 0, Y = 0};
            ImPlotPoint boundsMax = new ImPlotPoint {X = 1, Y = 1};
            ImPlotHeatmapFlags flags = 0;
            fixed (ushort* nativeValues = &values)
            {
                ImPlotNative.ImPlot_PlotHeatmap_U16Ptr(nativeLabelId, nativeValues, rows, cols, scaleMin, scaleMax, nativeLabelFmt, boundsMin, boundsMax, flags);
                if (labelIdByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeLabelId);
                }
                
                if (labelFmtByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeLabelFmt);
                }
            }
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
        public static void PlotHeatmap(string labelId, ref ushort values, int rows, int cols, double scaleMin, double scaleMax)
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
            
            byte* nativeLabelFmt;
            int labelFmtByteCount = 0;
            labelFmtByteCount = Encoding.UTF8.GetByteCount("%.1f");
            if (labelFmtByteCount > Util.StackAllocationSizeLimit)
            {
                nativeLabelFmt = Util.Allocate(labelFmtByteCount + 1);
            }
            else
            {
                byte* nativeLabelFmtStackBytes = stackalloc byte[labelFmtByteCount + 1];
                nativeLabelFmt = nativeLabelFmtStackBytes;
            }
            
            int nativeLabelFmtOffset = Util.GetUtf8("%.1f", nativeLabelFmt, labelFmtByteCount);
            nativeLabelFmt[nativeLabelFmtOffset] = 0;
            ImPlotPoint boundsMin = new ImPlotPoint {X = 0, Y = 0};
            ImPlotPoint boundsMax = new ImPlotPoint {X = 1, Y = 1};
            ImPlotHeatmapFlags flags = 0;
            fixed (ushort* nativeValues = &values)
            {
                ImPlotNative.ImPlot_PlotHeatmap_U16Ptr(nativeLabelId, nativeValues, rows, cols, scaleMin, scaleMax, nativeLabelFmt, boundsMin, boundsMax, flags);
                if (labelIdByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeLabelId);
                }
                
                if (labelFmtByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeLabelFmt);
                }
            }
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
        public static void PlotHeatmap(string labelId, ref ushort values, int rows, int cols, double scaleMin, double scaleMax, string labelFmt)
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
            
            byte* nativeLabelFmt;
            int labelFmtByteCount = 0;
            if (labelFmt != null)
            {
                labelFmtByteCount = Encoding.UTF8.GetByteCount(labelFmt);
                if (labelFmtByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeLabelFmt = Util.Allocate(labelFmtByteCount + 1);
                }
                else
                {
                    byte* nativeLabelFmtStackBytes = stackalloc byte[labelFmtByteCount + 1];
                    nativeLabelFmt = nativeLabelFmtStackBytes;
                }
                
                int nativeLabelFmtOffset = Util.GetUtf8(labelFmt, nativeLabelFmt, labelFmtByteCount);
                nativeLabelFmt[nativeLabelFmtOffset] = 0;
            }
            else
            {
                nativeLabelFmt = null;
            }
            
            ImPlotPoint boundsMin = new ImPlotPoint {X = 0, Y = 0};
            ImPlotPoint boundsMax = new ImPlotPoint {X = 1, Y = 1};
            ImPlotHeatmapFlags flags = 0;
            fixed (ushort* nativeValues = &values)
            {
                ImPlotNative.ImPlot_PlotHeatmap_U16Ptr(nativeLabelId, nativeValues, rows, cols, scaleMin, scaleMax, nativeLabelFmt, boundsMin, boundsMax, flags);
                if (labelIdByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeLabelId);
                }
                
                if (labelFmtByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeLabelFmt);
                }
            }
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
        public static void PlotHeatmap(string labelId, ref ushort values, int rows, int cols, double scaleMin, double scaleMax, string labelFmt, ImPlotPoint boundsMin)
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
            
            byte* nativeLabelFmt;
            int labelFmtByteCount = 0;
            if (labelFmt != null)
            {
                labelFmtByteCount = Encoding.UTF8.GetByteCount(labelFmt);
                if (labelFmtByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeLabelFmt = Util.Allocate(labelFmtByteCount + 1);
                }
                else
                {
                    byte* nativeLabelFmtStackBytes = stackalloc byte[labelFmtByteCount + 1];
                    nativeLabelFmt = nativeLabelFmtStackBytes;
                }
                
                int nativeLabelFmtOffset = Util.GetUtf8(labelFmt, nativeLabelFmt, labelFmtByteCount);
                nativeLabelFmt[nativeLabelFmtOffset] = 0;
            }
            else
            {
                nativeLabelFmt = null;
            }
            
            ImPlotPoint boundsMax = new ImPlotPoint {X = 1, Y = 1};
            ImPlotHeatmapFlags flags = 0;
            fixed (ushort* nativeValues = &values)
            {
                ImPlotNative.ImPlot_PlotHeatmap_U16Ptr(nativeLabelId, nativeValues, rows, cols, scaleMin, scaleMax, nativeLabelFmt, boundsMin, boundsMax, flags);
                if (labelIdByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeLabelId);
                }
                
                if (labelFmtByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeLabelFmt);
                }
            }
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
        public static void PlotHeatmap(string labelId, ref ushort values, int rows, int cols, double scaleMin, double scaleMax, string labelFmt, ImPlotPoint boundsMin, ImPlotPoint boundsMax)
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
            
            byte* nativeLabelFmt;
            int labelFmtByteCount = 0;
            if (labelFmt != null)
            {
                labelFmtByteCount = Encoding.UTF8.GetByteCount(labelFmt);
                if (labelFmtByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeLabelFmt = Util.Allocate(labelFmtByteCount + 1);
                }
                else
                {
                    byte* nativeLabelFmtStackBytes = stackalloc byte[labelFmtByteCount + 1];
                    nativeLabelFmt = nativeLabelFmtStackBytes;
                }
                
                int nativeLabelFmtOffset = Util.GetUtf8(labelFmt, nativeLabelFmt, labelFmtByteCount);
                nativeLabelFmt[nativeLabelFmtOffset] = 0;
            }
            else
            {
                nativeLabelFmt = null;
            }
            
            ImPlotHeatmapFlags flags = 0;
            fixed (ushort* nativeValues = &values)
            {
                ImPlotNative.ImPlot_PlotHeatmap_U16Ptr(nativeLabelId, nativeValues, rows, cols, scaleMin, scaleMax, nativeLabelFmt, boundsMin, boundsMax, flags);
                if (labelIdByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeLabelId);
                }
                
                if (labelFmtByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeLabelFmt);
                }
            }
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
        public static void PlotHeatmap(string labelId, ref ushort values, int rows, int cols, double scaleMin, double scaleMax, string labelFmt, ImPlotPoint boundsMin, ImPlotPoint boundsMax, ImPlotHeatmapFlags flags)
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
            
            byte* nativeLabelFmt;
            int labelFmtByteCount = 0;
            if (labelFmt != null)
            {
                labelFmtByteCount = Encoding.UTF8.GetByteCount(labelFmt);
                if (labelFmtByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeLabelFmt = Util.Allocate(labelFmtByteCount + 1);
                }
                else
                {
                    byte* nativeLabelFmtStackBytes = stackalloc byte[labelFmtByteCount + 1];
                    nativeLabelFmt = nativeLabelFmtStackBytes;
                }
                
                int nativeLabelFmtOffset = Util.GetUtf8(labelFmt, nativeLabelFmt, labelFmtByteCount);
                nativeLabelFmt[nativeLabelFmtOffset] = 0;
            }
            else
            {
                nativeLabelFmt = null;
            }
            
            fixed (ushort* nativeValues = &values)
            {
                ImPlotNative.ImPlot_PlotHeatmap_U16Ptr(nativeLabelId, nativeValues, rows, cols, scaleMin, scaleMax, nativeLabelFmt, boundsMin, boundsMax, flags);
                if (labelIdByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeLabelId);
                }
                
                if (labelFmtByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeLabelFmt);
                }
            }
        }
        
        /// <summary>
        ///     Plots the heatmap using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="rows">The rows</param>
        /// <param name="cols">The cols</param>
        public static void PlotHeatmap(string labelId, ref int values, int rows, int cols)
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
            
            double scaleMin = 0;
            double scaleMax = 0;
            byte* nativeLabelFmt;
            int labelFmtByteCount = 0;
            labelFmtByteCount = Encoding.UTF8.GetByteCount("%.1f");
            if (labelFmtByteCount > Util.StackAllocationSizeLimit)
            {
                nativeLabelFmt = Util.Allocate(labelFmtByteCount + 1);
            }
            else
            {
                byte* nativeLabelFmtStackBytes = stackalloc byte[labelFmtByteCount + 1];
                nativeLabelFmt = nativeLabelFmtStackBytes;
            }
            
            int nativeLabelFmtOffset = Util.GetUtf8("%.1f", nativeLabelFmt, labelFmtByteCount);
            nativeLabelFmt[nativeLabelFmtOffset] = 0;
            ImPlotPoint boundsMin = new ImPlotPoint {X = 0, Y = 0};
            ImPlotPoint boundsMax = new ImPlotPoint {X = 1, Y = 1};
            ImPlotHeatmapFlags flags = 0;
            fixed (int* nativeValues = &values)
            {
                ImPlotNative.ImPlot_PlotHeatmap_S32Ptr(nativeLabelId, nativeValues, rows, cols, scaleMin, scaleMax, nativeLabelFmt, boundsMin, boundsMax, flags);
                if (labelIdByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeLabelId);
                }
                
                if (labelFmtByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeLabelFmt);
                }
            }
        }
        
        /// <summary>
        ///     Plots the heatmap using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="rows">The rows</param>
        /// <param name="cols">The cols</param>
        /// <param name="scaleMin">The scale min</param>
        public static void PlotHeatmap(string labelId, ref int values, int rows, int cols, double scaleMin)
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
            
            double scaleMax = 0;
            byte* nativeLabelFmt;
            int labelFmtByteCount = 0;
            labelFmtByteCount = Encoding.UTF8.GetByteCount("%.1f");
            if (labelFmtByteCount > Util.StackAllocationSizeLimit)
            {
                nativeLabelFmt = Util.Allocate(labelFmtByteCount + 1);
            }
            else
            {
                byte* nativeLabelFmtStackBytes = stackalloc byte[labelFmtByteCount + 1];
                nativeLabelFmt = nativeLabelFmtStackBytes;
            }
            
            int nativeLabelFmtOffset = Util.GetUtf8("%.1f", nativeLabelFmt, labelFmtByteCount);
            nativeLabelFmt[nativeLabelFmtOffset] = 0;
            ImPlotPoint boundsMin = new ImPlotPoint {X = 0, Y = 0};
            ImPlotPoint boundsMax = new ImPlotPoint {X = 1, Y = 1};
            ImPlotHeatmapFlags flags = 0;
            fixed (int* nativeValues = &values)
            {
                ImPlotNative.ImPlot_PlotHeatmap_S32Ptr(nativeLabelId, nativeValues, rows, cols, scaleMin, scaleMax, nativeLabelFmt, boundsMin, boundsMax, flags);
                if (labelIdByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeLabelId);
                }
                
                if (labelFmtByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeLabelFmt);
                }
            }
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
        public static void PlotHeatmap(string labelId, ref int values, int rows, int cols, double scaleMin, double scaleMax)
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
            
            byte* nativeLabelFmt;
            int labelFmtByteCount = 0;
            labelFmtByteCount = Encoding.UTF8.GetByteCount("%.1f");
            if (labelFmtByteCount > Util.StackAllocationSizeLimit)
            {
                nativeLabelFmt = Util.Allocate(labelFmtByteCount + 1);
            }
            else
            {
                byte* nativeLabelFmtStackBytes = stackalloc byte[labelFmtByteCount + 1];
                nativeLabelFmt = nativeLabelFmtStackBytes;
            }
            
            int nativeLabelFmtOffset = Util.GetUtf8("%.1f", nativeLabelFmt, labelFmtByteCount);
            nativeLabelFmt[nativeLabelFmtOffset] = 0;
            ImPlotPoint boundsMin = new ImPlotPoint {X = 0, Y = 0};
            ImPlotPoint boundsMax = new ImPlotPoint {X = 1, Y = 1};
            ImPlotHeatmapFlags flags = 0;
            fixed (int* nativeValues = &values)
            {
                ImPlotNative.ImPlot_PlotHeatmap_S32Ptr(nativeLabelId, nativeValues, rows, cols, scaleMin, scaleMax, nativeLabelFmt, boundsMin, boundsMax, flags);
                if (labelIdByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeLabelId);
                }
                
                if (labelFmtByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeLabelFmt);
                }
            }
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
        public static void PlotHeatmap(string labelId, ref int values, int rows, int cols, double scaleMin, double scaleMax, string labelFmt)
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
            
            byte* nativeLabelFmt;
            int labelFmtByteCount = 0;
            if (labelFmt != null)
            {
                labelFmtByteCount = Encoding.UTF8.GetByteCount(labelFmt);
                if (labelFmtByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeLabelFmt = Util.Allocate(labelFmtByteCount + 1);
                }
                else
                {
                    byte* nativeLabelFmtStackBytes = stackalloc byte[labelFmtByteCount + 1];
                    nativeLabelFmt = nativeLabelFmtStackBytes;
                }
                
                int nativeLabelFmtOffset = Util.GetUtf8(labelFmt, nativeLabelFmt, labelFmtByteCount);
                nativeLabelFmt[nativeLabelFmtOffset] = 0;
            }
            else
            {
                nativeLabelFmt = null;
            }
            
            ImPlotPoint boundsMin = new ImPlotPoint {X = 0, Y = 0};
            ImPlotPoint boundsMax = new ImPlotPoint {X = 1, Y = 1};
            ImPlotHeatmapFlags flags = 0;
            fixed (int* nativeValues = &values)
            {
                ImPlotNative.ImPlot_PlotHeatmap_S32Ptr(nativeLabelId, nativeValues, rows, cols, scaleMin, scaleMax, nativeLabelFmt, boundsMin, boundsMax, flags);
                if (labelIdByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeLabelId);
                }
                
                if (labelFmtByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeLabelFmt);
                }
            }
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
        public static void PlotHeatmap(string labelId, ref int values, int rows, int cols, double scaleMin, double scaleMax, string labelFmt, ImPlotPoint boundsMin)
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
            
            byte* nativeLabelFmt;
            int labelFmtByteCount = 0;
            if (labelFmt != null)
            {
                labelFmtByteCount = Encoding.UTF8.GetByteCount(labelFmt);
                if (labelFmtByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeLabelFmt = Util.Allocate(labelFmtByteCount + 1);
                }
                else
                {
                    byte* nativeLabelFmtStackBytes = stackalloc byte[labelFmtByteCount + 1];
                    nativeLabelFmt = nativeLabelFmtStackBytes;
                }
                
                int nativeLabelFmtOffset = Util.GetUtf8(labelFmt, nativeLabelFmt, labelFmtByteCount);
                nativeLabelFmt[nativeLabelFmtOffset] = 0;
            }
            else
            {
                nativeLabelFmt = null;
            }
            
            ImPlotPoint boundsMax = new ImPlotPoint {X = 1, Y = 1};
            ImPlotHeatmapFlags flags = 0;
            fixed (int* nativeValues = &values)
            {
                ImPlotNative.ImPlot_PlotHeatmap_S32Ptr(nativeLabelId, nativeValues, rows, cols, scaleMin, scaleMax, nativeLabelFmt, boundsMin, boundsMax, flags);
                if (labelIdByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeLabelId);
                }
                
                if (labelFmtByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeLabelFmt);
                }
            }
        }
    }
}