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
        /// <param name="boundsMax">The bounds max</param>
        public static void PlotHeatmap(string labelId, ref int values, int rows, int cols, double scaleMin, double scaleMax, string labelFmt, ImPlotPoint boundsMin, ImPlotPoint boundsMax)
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
        /// <param name="boundsMax">The bounds max</param>
        /// <param name="flags">The flags</param>
        public static void PlotHeatmap(string labelId, ref int values, int rows, int cols, double scaleMin, double scaleMax, string labelFmt, ImPlotPoint boundsMin, ImPlotPoint boundsMax, ImPlotHeatmapFlags flags)
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
        public static void PlotHeatmap(string labelId, ref uint values, int rows, int cols)
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
            fixed (uint* nativeValues = &values)
            {
                ImPlotNative.ImPlot_PlotHeatmap_U32Ptr(nativeLabelId, nativeValues, rows, cols, scaleMin, scaleMax, nativeLabelFmt, boundsMin, boundsMax, flags);
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
        public static void PlotHeatmap(string labelId, ref uint values, int rows, int cols, double scaleMin)
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
            fixed (uint* nativeValues = &values)
            {
                ImPlotNative.ImPlot_PlotHeatmap_U32Ptr(nativeLabelId, nativeValues, rows, cols, scaleMin, scaleMax, nativeLabelFmt, boundsMin, boundsMax, flags);
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
        public static void PlotHeatmap(string labelId, ref uint values, int rows, int cols, double scaleMin, double scaleMax)
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
            fixed (uint* nativeValues = &values)
            {
                ImPlotNative.ImPlot_PlotHeatmap_U32Ptr(nativeLabelId, nativeValues, rows, cols, scaleMin, scaleMax, nativeLabelFmt, boundsMin, boundsMax, flags);
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
        public static void PlotHeatmap(string labelId, ref uint values, int rows, int cols, double scaleMin, double scaleMax, string labelFmt)
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
            fixed (uint* nativeValues = &values)
            {
                ImPlotNative.ImPlot_PlotHeatmap_U32Ptr(nativeLabelId, nativeValues, rows, cols, scaleMin, scaleMax, nativeLabelFmt, boundsMin, boundsMax, flags);
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
        public static void PlotHeatmap(string labelId, ref uint values, int rows, int cols, double scaleMin, double scaleMax, string labelFmt, ImPlotPoint boundsMin)
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
            fixed (uint* nativeValues = &values)
            {
                ImPlotNative.ImPlot_PlotHeatmap_U32Ptr(nativeLabelId, nativeValues, rows, cols, scaleMin, scaleMax, nativeLabelFmt, boundsMin, boundsMax, flags);
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
        public static void PlotHeatmap(string labelId, ref uint values, int rows, int cols, double scaleMin, double scaleMax, string labelFmt, ImPlotPoint boundsMin, ImPlotPoint boundsMax)
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
            fixed (uint* nativeValues = &values)
            {
                ImPlotNative.ImPlot_PlotHeatmap_U32Ptr(nativeLabelId, nativeValues, rows, cols, scaleMin, scaleMax, nativeLabelFmt, boundsMin, boundsMax, flags);
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
        public static void PlotHeatmap(string labelId, ref uint values, int rows, int cols, double scaleMin, double scaleMax, string labelFmt, ImPlotPoint boundsMin, ImPlotPoint boundsMax, ImPlotHeatmapFlags flags)
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
            
            fixed (uint* nativeValues = &values)
            {
                ImPlotNative.ImPlot_PlotHeatmap_U32Ptr(nativeLabelId, nativeValues, rows, cols, scaleMin, scaleMax, nativeLabelFmt, boundsMin, boundsMax, flags);
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
        public static void PlotHeatmap(string labelId, ref long values, int rows, int cols)
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
            fixed (long* nativeValues = &values)
            {
                ImPlotNative.ImPlot_PlotHeatmap_S64Ptr(nativeLabelId, nativeValues, rows, cols, scaleMin, scaleMax, nativeLabelFmt, boundsMin, boundsMax, flags);
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
        public static void PlotHeatmap(string labelId, ref long values, int rows, int cols, double scaleMin)
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
            fixed (long* nativeValues = &values)
            {
                ImPlotNative.ImPlot_PlotHeatmap_S64Ptr(nativeLabelId, nativeValues, rows, cols, scaleMin, scaleMax, nativeLabelFmt, boundsMin, boundsMax, flags);
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
        public static void PlotHeatmap(string labelId, ref long values, int rows, int cols, double scaleMin, double scaleMax)
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
            fixed (long* nativeValues = &values)
            {
                ImPlotNative.ImPlot_PlotHeatmap_S64Ptr(nativeLabelId, nativeValues, rows, cols, scaleMin, scaleMax, nativeLabelFmt, boundsMin, boundsMax, flags);
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
        public static void PlotHeatmap(string labelId, ref long values, int rows, int cols, double scaleMin, double scaleMax, string labelFmt)
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
            fixed (long* nativeValues = &values)
            {
                ImPlotNative.ImPlot_PlotHeatmap_S64Ptr(nativeLabelId, nativeValues, rows, cols, scaleMin, scaleMax, nativeLabelFmt, boundsMin, boundsMax, flags);
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
        public static void PlotHeatmap(string labelId, ref long values, int rows, int cols, double scaleMin, double scaleMax, string labelFmt, ImPlotPoint boundsMin)
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
            fixed (long* nativeValues = &values)
            {
                ImPlotNative.ImPlot_PlotHeatmap_S64Ptr(nativeLabelId, nativeValues, rows, cols, scaleMin, scaleMax, nativeLabelFmt, boundsMin, boundsMax, flags);
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
        public static void PlotHeatmap(string labelId, ref long values, int rows, int cols, double scaleMin, double scaleMax, string labelFmt, ImPlotPoint boundsMin, ImPlotPoint boundsMax)
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
            fixed (long* nativeValues = &values)
            {
                ImPlotNative.ImPlot_PlotHeatmap_S64Ptr(nativeLabelId, nativeValues, rows, cols, scaleMin, scaleMax, nativeLabelFmt, boundsMin, boundsMax, flags);
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
        public static void PlotHeatmap(string labelId, ref long values, int rows, int cols, double scaleMin, double scaleMax, string labelFmt, ImPlotPoint boundsMin, ImPlotPoint boundsMax, ImPlotHeatmapFlags flags)
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
            
            fixed (long* nativeValues = &values)
            {
                ImPlotNative.ImPlot_PlotHeatmap_S64Ptr(nativeLabelId, nativeValues, rows, cols, scaleMin, scaleMax, nativeLabelFmt, boundsMin, boundsMax, flags);
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
        public static void PlotHeatmap(string labelId, ref ulong values, int rows, int cols)
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
            fixed (ulong* nativeValues = &values)
            {
                ImPlotNative.ImPlot_PlotHeatmap_U64Ptr(nativeLabelId, nativeValues, rows, cols, scaleMin, scaleMax, nativeLabelFmt, boundsMin, boundsMax, flags);
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
        public static void PlotHeatmap(string labelId, ref ulong values, int rows, int cols, double scaleMin)
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
            fixed (ulong* nativeValues = &values)
            {
                ImPlotNative.ImPlot_PlotHeatmap_U64Ptr(nativeLabelId, nativeValues, rows, cols, scaleMin, scaleMax, nativeLabelFmt, boundsMin, boundsMax, flags);
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
        public static void PlotHeatmap(string labelId, ref ulong values, int rows, int cols, double scaleMin, double scaleMax)
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
            fixed (ulong* nativeValues = &values)
            {
                ImPlotNative.ImPlot_PlotHeatmap_U64Ptr(nativeLabelId, nativeValues, rows, cols, scaleMin, scaleMax, nativeLabelFmt, boundsMin, boundsMax, flags);
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
        public static void PlotHeatmap(string labelId, ref ulong values, int rows, int cols, double scaleMin, double scaleMax, string labelFmt)
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
            fixed (ulong* nativeValues = &values)
            {
                ImPlotNative.ImPlot_PlotHeatmap_U64Ptr(nativeLabelId, nativeValues, rows, cols, scaleMin, scaleMax, nativeLabelFmt, boundsMin, boundsMax, flags);
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
        public static void PlotHeatmap(string labelId, ref ulong values, int rows, int cols, double scaleMin, double scaleMax, string labelFmt, ImPlotPoint boundsMin)
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
            fixed (ulong* nativeValues = &values)
            {
                ImPlotNative.ImPlot_PlotHeatmap_U64Ptr(nativeLabelId, nativeValues, rows, cols, scaleMin, scaleMax, nativeLabelFmt, boundsMin, boundsMax, flags);
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
        public static void PlotHeatmap(string labelId, ref ulong values, int rows, int cols, double scaleMin, double scaleMax, string labelFmt, ImPlotPoint boundsMin, ImPlotPoint boundsMax)
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
            fixed (ulong* nativeValues = &values)
            {
                ImPlotNative.ImPlot_PlotHeatmap_U64Ptr(nativeLabelId, nativeValues, rows, cols, scaleMin, scaleMax, nativeLabelFmt, boundsMin, boundsMax, flags);
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
        public static void PlotHeatmap(string labelId, ref ulong values, int rows, int cols, double scaleMin, double scaleMax, string labelFmt, ImPlotPoint boundsMin, ImPlotPoint boundsMax, ImPlotHeatmapFlags flags)
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
            
            fixed (ulong* nativeValues = &values)
            {
                ImPlotNative.ImPlot_PlotHeatmap_U64Ptr(nativeLabelId, nativeValues, rows, cols, scaleMin, scaleMax, nativeLabelFmt, boundsMin, boundsMax, flags);
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
        ///     Plots the histogram using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <returns>The double</returns>
        public static double PlotHistogram(string labelId, ref float values, int count)
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
            fixed (float* nativeValues = &values)
            {
                double ret = ImPlotNative.ImPlot_PlotHistogram_FloatPtr(nativeLabelId, nativeValues, count, bins, barScale, range, flags);
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
        public static double PlotHistogram(string labelId, ref float values, int count, int bins)
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
            fixed (float* nativeValues = &values)
            {
                double ret = ImPlotNative.ImPlot_PlotHistogram_FloatPtr(nativeLabelId, nativeValues, count, bins, barScale, range, flags);
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
        public static double PlotHistogram(string labelId, ref float values, int count, int bins, double barScale)
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
            fixed (float* nativeValues = &values)
            {
                double ret = ImPlotNative.ImPlot_PlotHistogram_FloatPtr(nativeLabelId, nativeValues, count, bins, barScale, range, flags);
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
        public static double PlotHistogram(string labelId, ref float values, int count, int bins, double barScale, ImPlotRange range)
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
            fixed (float* nativeValues = &values)
            {
                double ret = ImPlotNative.ImPlot_PlotHistogram_FloatPtr(nativeLabelId, nativeValues, count, bins, barScale, range, flags);
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
        public static double PlotHistogram(string labelId, ref float values, int count, int bins, double barScale, ImPlotRange range, ImPlotHistogramFlags flags)
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
                double ret = ImPlotNative.ImPlot_PlotHistogram_FloatPtr(nativeLabelId, nativeValues, count, bins, barScale, range, flags);
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
        public static double PlotHistogram(string labelId, ref double values, int count)
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
            fixed (double* nativeValues = &values)
            {
                double ret = ImPlotNative.ImPlot_PlotHistogram_doublePtr(nativeLabelId, nativeValues, count, bins, barScale, range, flags);
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
        public static double PlotHistogram(string labelId, ref double values, int count, int bins)
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
            fixed (double* nativeValues = &values)
            {
                double ret = ImPlotNative.ImPlot_PlotHistogram_doublePtr(nativeLabelId, nativeValues, count, bins, barScale, range, flags);
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
        public static double PlotHistogram(string labelId, ref double values, int count, int bins, double barScale)
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
            fixed (double* nativeValues = &values)
            {
                double ret = ImPlotNative.ImPlot_PlotHistogram_doublePtr(nativeLabelId, nativeValues, count, bins, barScale, range, flags);
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
        public static double PlotHistogram(string labelId, ref double values, int count, int bins, double barScale, ImPlotRange range)
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
            fixed (double* nativeValues = &values)
            {
                double ret = ImPlotNative.ImPlot_PlotHistogram_doublePtr(nativeLabelId, nativeValues, count, bins, barScale, range, flags);
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
        public static double PlotHistogram(string labelId, ref double values, int count, int bins, double barScale, ImPlotRange range, ImPlotHistogramFlags flags)
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
                double ret = ImPlotNative.ImPlot_PlotHistogram_doublePtr(nativeLabelId, nativeValues, count, bins, barScale, range, flags);
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
        public static double PlotHistogram(string labelId, ref sbyte values, int count)
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
            fixed (sbyte* nativeValues = &values)
            {
                double ret = ImPlotNative.ImPlot_PlotHistogram_S8Ptr(nativeLabelId, nativeValues, count, bins, barScale, range, flags);
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
        public static double PlotHistogram(string labelId, ref sbyte values, int count, int bins)
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
            fixed (sbyte* nativeValues = &values)
            {
                double ret = ImPlotNative.ImPlot_PlotHistogram_S8Ptr(nativeLabelId, nativeValues, count, bins, barScale, range, flags);
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
        public static double PlotHistogram(string labelId, ref sbyte values, int count, int bins, double barScale)
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
            fixed (sbyte* nativeValues = &values)
            {
                double ret = ImPlotNative.ImPlot_PlotHistogram_S8Ptr(nativeLabelId, nativeValues, count, bins, barScale, range, flags);
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
        public static double PlotHistogram(string labelId, ref sbyte values, int count, int bins, double barScale, ImPlotRange range)
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
            fixed (sbyte* nativeValues = &values)
            {
                double ret = ImPlotNative.ImPlot_PlotHistogram_S8Ptr(nativeLabelId, nativeValues, count, bins, barScale, range, flags);
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
        public static double PlotHistogram(string labelId, ref sbyte values, int count, int bins, double barScale, ImPlotRange range, ImPlotHistogramFlags flags)
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
                double ret = ImPlotNative.ImPlot_PlotHistogram_S8Ptr(nativeLabelId, nativeValues, count, bins, barScale, range, flags);
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
        public static double PlotHistogram(string labelId, ref byte values, int count)
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
        /// <returns>The double</returns>
        public static double PlotHistogram(string labelId, ref byte values, int count, int bins)
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
        /// <returns>The double</returns>
        public static double PlotHistogram(string labelId, ref byte values, int count, int bins, double barScale)
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
        
    }
}