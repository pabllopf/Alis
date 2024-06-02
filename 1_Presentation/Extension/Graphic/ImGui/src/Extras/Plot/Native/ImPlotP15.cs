// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImPlotP15.cs
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
    public static unsafe partial class ImPlot
    {
        /// <summary>
        ///     Plots the bar groups using the specified label ids
        /// </summary>
        /// <param name="labelIds">The label ids</param>
        /// <param name="values">The values</param>
        /// <param name="itemCount">The item count</param>
        /// <param name="groupCount">The group count</param>
        /// <param name="groupSize">The group size</param>
        public static void PlotBarGroups(string[] labelIds, ref uint values, int itemCount, int groupCount, double groupSize)
        {
            int* labelIdsByteCounts = stackalloc int[labelIds.Length];
            int labelIdsByteCount = 0;
            for (int i = 0; i < labelIds.Length; i++)
            {
                string s = labelIds[i];
                labelIdsByteCounts[i] = Encoding.UTF8.GetByteCount(s);
                labelIdsByteCount += labelIdsByteCounts[i] + 1;
            }
            
            byte* nativeLabelIdsData = stackalloc byte[labelIdsByteCount];
            int offset = 0;
            for (int i = 0; i < labelIds.Length; i++)
            {
                string s = labelIds[i];
                fixed (char* sPtr = s)
                {
                    offset += Encoding.UTF8.GetBytes(sPtr, s.Length, nativeLabelIdsData + offset, labelIdsByteCounts[i]);
                    nativeLabelIdsData[offset] = 0;
                    offset += 1;
                }
            }
            
            byte** nativeLabelIds = stackalloc byte*[labelIds.Length];
            offset = 0;
            for (int i = 0; i < labelIds.Length; i++)
            {
                nativeLabelIds[i] = &nativeLabelIdsData[offset];
                offset += labelIdsByteCounts[i] + 1;
            }
            
            double shift = 0;
            ImPlotBarGroupsFlags flags = 0;
            fixed (uint* nativeValues = &values)
            {
                ImPlotNative.ImPlot_PlotBarGroups_U32Ptr(nativeLabelIds, nativeValues, itemCount, groupCount, groupSize, shift, flags);
            }
        }
        
        /// <summary>
        ///     Plots the bar groups using the specified label ids
        /// </summary>
        /// <param name="labelIds">The label ids</param>
        /// <param name="values">The values</param>
        /// <param name="itemCount">The item count</param>
        /// <param name="groupCount">The group count</param>
        /// <param name="groupSize">The group size</param>
        /// <param name="shift">The shift</param>
        public static void PlotBarGroups(string[] labelIds, ref uint values, int itemCount, int groupCount, double groupSize, double shift)
        {
            int* labelIdsByteCounts = stackalloc int[labelIds.Length];
            int labelIdsByteCount = 0;
            for (int i = 0; i < labelIds.Length; i++)
            {
                string s = labelIds[i];
                labelIdsByteCounts[i] = Encoding.UTF8.GetByteCount(s);
                labelIdsByteCount += labelIdsByteCounts[i] + 1;
            }
            
            byte* nativeLabelIdsData = stackalloc byte[labelIdsByteCount];
            int offset = 0;
            for (int i = 0; i < labelIds.Length; i++)
            {
                string s = labelIds[i];
                fixed (char* sPtr = s)
                {
                    offset += Encoding.UTF8.GetBytes(sPtr, s.Length, nativeLabelIdsData + offset, labelIdsByteCounts[i]);
                    nativeLabelIdsData[offset] = 0;
                    offset += 1;
                }
            }
            
            byte** nativeLabelIds = stackalloc byte*[labelIds.Length];
            offset = 0;
            for (int i = 0; i < labelIds.Length; i++)
            {
                nativeLabelIds[i] = &nativeLabelIdsData[offset];
                offset += labelIdsByteCounts[i] + 1;
            }
            
            ImPlotBarGroupsFlags flags = 0;
            fixed (uint* nativeValues = &values)
            {
                ImPlotNative.ImPlot_PlotBarGroups_U32Ptr(nativeLabelIds, nativeValues, itemCount, groupCount, groupSize, shift, flags);
            }
        }
        
        /// <summary>
        ///     Plots the bar groups using the specified label ids
        /// </summary>
        /// <param name="labelIds">The label ids</param>
        /// <param name="values">The values</param>
        /// <param name="itemCount">The item count</param>
        /// <param name="groupCount">The group count</param>
        /// <param name="groupSize">The group size</param>
        /// <param name="shift">The shift</param>
        /// <param name="flags">The flags</param>
        public static void PlotBarGroups(string[] labelIds, ref uint values, int itemCount, int groupCount, double groupSize, double shift, ImPlotBarGroupsFlags flags)
        {
            int* labelIdsByteCounts = stackalloc int[labelIds.Length];
            int labelIdsByteCount = 0;
            for (int i = 0; i < labelIds.Length; i++)
            {
                string s = labelIds[i];
                labelIdsByteCounts[i] = Encoding.UTF8.GetByteCount(s);
                labelIdsByteCount += labelIdsByteCounts[i] + 1;
            }
            
            byte* nativeLabelIdsData = stackalloc byte[labelIdsByteCount];
            int offset = 0;
            for (int i = 0; i < labelIds.Length; i++)
            {
                string s = labelIds[i];
                fixed (char* sPtr = s)
                {
                    offset += Encoding.UTF8.GetBytes(sPtr, s.Length, nativeLabelIdsData + offset, labelIdsByteCounts[i]);
                    nativeLabelIdsData[offset] = 0;
                    offset += 1;
                }
            }
            
            byte** nativeLabelIds = stackalloc byte*[labelIds.Length];
            offset = 0;
            for (int i = 0; i < labelIds.Length; i++)
            {
                nativeLabelIds[i] = &nativeLabelIdsData[offset];
                offset += labelIdsByteCounts[i] + 1;
            }
            
            fixed (uint* nativeValues = &values)
            {
                ImPlotNative.ImPlot_PlotBarGroups_U32Ptr(nativeLabelIds, nativeValues, itemCount, groupCount, groupSize, shift, flags);
            }
        }
        
        /// <summary>
        ///     Plots the bar groups using the specified label ids
        /// </summary>
        /// <param name="labelIds">The label ids</param>
        /// <param name="values">The values</param>
        /// <param name="itemCount">The item count</param>
        /// <param name="groupCount">The group count</param>
        public static void PlotBarGroups(string[] labelIds, ref long values, int itemCount, int groupCount)
        {
            int* labelIdsByteCounts = stackalloc int[labelIds.Length];
            int labelIdsByteCount = 0;
            for (int i = 0; i < labelIds.Length; i++)
            {
                string s = labelIds[i];
                labelIdsByteCounts[i] = Encoding.UTF8.GetByteCount(s);
                labelIdsByteCount += labelIdsByteCounts[i] + 1;
            }
            
            byte* nativeLabelIdsData = stackalloc byte[labelIdsByteCount];
            int offset = 0;
            for (int i = 0; i < labelIds.Length; i++)
            {
                string s = labelIds[i];
                fixed (char* sPtr = s)
                {
                    offset += Encoding.UTF8.GetBytes(sPtr, s.Length, nativeLabelIdsData + offset, labelIdsByteCounts[i]);
                    nativeLabelIdsData[offset] = 0;
                    offset += 1;
                }
            }
            
            byte** nativeLabelIds = stackalloc byte*[labelIds.Length];
            offset = 0;
            for (int i = 0; i < labelIds.Length; i++)
            {
                nativeLabelIds[i] = &nativeLabelIdsData[offset];
                offset += labelIdsByteCounts[i] + 1;
            }
            
            double groupSize = 0.67;
            double shift = 0;
            ImPlotBarGroupsFlags flags = 0;
            fixed (long* nativeValues = &values)
            {
                ImPlotNative.ImPlot_PlotBarGroups_S64Ptr(nativeLabelIds, nativeValues, itemCount, groupCount, groupSize, shift, flags);
            }
        }
        
        /// <summary>
        ///     Plots the bar groups using the specified label ids
        /// </summary>
        /// <param name="labelIds">The label ids</param>
        /// <param name="values">The values</param>
        /// <param name="itemCount">The item count</param>
        /// <param name="groupCount">The group count</param>
        /// <param name="groupSize">The group size</param>
        public static void PlotBarGroups(string[] labelIds, ref long values, int itemCount, int groupCount, double groupSize)
        {
            int* labelIdsByteCounts = stackalloc int[labelIds.Length];
            int labelIdsByteCount = 0;
            for (int i = 0; i < labelIds.Length; i++)
            {
                string s = labelIds[i];
                labelIdsByteCounts[i] = Encoding.UTF8.GetByteCount(s);
                labelIdsByteCount += labelIdsByteCounts[i] + 1;
            }
            
            byte* nativeLabelIdsData = stackalloc byte[labelIdsByteCount];
            int offset = 0;
            for (int i = 0; i < labelIds.Length; i++)
            {
                string s = labelIds[i];
                fixed (char* sPtr = s)
                {
                    offset += Encoding.UTF8.GetBytes(sPtr, s.Length, nativeLabelIdsData + offset, labelIdsByteCounts[i]);
                    nativeLabelIdsData[offset] = 0;
                    offset += 1;
                }
            }
            
            byte** nativeLabelIds = stackalloc byte*[labelIds.Length];
            offset = 0;
            for (int i = 0; i < labelIds.Length; i++)
            {
                nativeLabelIds[i] = &nativeLabelIdsData[offset];
                offset += labelIdsByteCounts[i] + 1;
            }
            
            double shift = 0;
            ImPlotBarGroupsFlags flags = 0;
            fixed (long* nativeValues = &values)
            {
                ImPlotNative.ImPlot_PlotBarGroups_S64Ptr(nativeLabelIds, nativeValues, itemCount, groupCount, groupSize, shift, flags);
            }
        }
        
        /// <summary>
        ///     Plots the bar groups using the specified label ids
        /// </summary>
        /// <param name="labelIds">The label ids</param>
        /// <param name="values">The values</param>
        /// <param name="itemCount">The item count</param>
        /// <param name="groupCount">The group count</param>
        /// <param name="groupSize">The group size</param>
        /// <param name="shift">The shift</param>
        public static void PlotBarGroups(string[] labelIds, ref long values, int itemCount, int groupCount, double groupSize, double shift)
        {
            int* labelIdsByteCounts = stackalloc int[labelIds.Length];
            int labelIdsByteCount = 0;
            for (int i = 0; i < labelIds.Length; i++)
            {
                string s = labelIds[i];
                labelIdsByteCounts[i] = Encoding.UTF8.GetByteCount(s);
                labelIdsByteCount += labelIdsByteCounts[i] + 1;
            }
            
            byte* nativeLabelIdsData = stackalloc byte[labelIdsByteCount];
            int offset = 0;
            for (int i = 0; i < labelIds.Length; i++)
            {
                string s = labelIds[i];
                fixed (char* sPtr = s)
                {
                    offset += Encoding.UTF8.GetBytes(sPtr, s.Length, nativeLabelIdsData + offset, labelIdsByteCounts[i]);
                    nativeLabelIdsData[offset] = 0;
                    offset += 1;
                }
            }
            
            byte** nativeLabelIds = stackalloc byte*[labelIds.Length];
            offset = 0;
            for (int i = 0; i < labelIds.Length; i++)
            {
                nativeLabelIds[i] = &nativeLabelIdsData[offset];
                offset += labelIdsByteCounts[i] + 1;
            }
            
            ImPlotBarGroupsFlags flags = 0;
            fixed (long* nativeValues = &values)
            {
                ImPlotNative.ImPlot_PlotBarGroups_S64Ptr(nativeLabelIds, nativeValues, itemCount, groupCount, groupSize, shift, flags);
            }
        }
        
        /// <summary>
        ///     Plots the bar groups using the specified label ids
        /// </summary>
        /// <param name="labelIds">The label ids</param>
        /// <param name="values">The values</param>
        /// <param name="itemCount">The item count</param>
        /// <param name="groupCount">The group count</param>
        /// <param name="groupSize">The group size</param>
        /// <param name="shift">The shift</param>
        /// <param name="flags">The flags</param>
        public static void PlotBarGroups(string[] labelIds, ref long values, int itemCount, int groupCount, double groupSize, double shift, ImPlotBarGroupsFlags flags)
        {
            int* labelIdsByteCounts = stackalloc int[labelIds.Length];
            int labelIdsByteCount = 0;
            for (int i = 0; i < labelIds.Length; i++)
            {
                string s = labelIds[i];
                labelIdsByteCounts[i] = Encoding.UTF8.GetByteCount(s);
                labelIdsByteCount += labelIdsByteCounts[i] + 1;
            }
            
            byte* nativeLabelIdsData = stackalloc byte[labelIdsByteCount];
            int offset = 0;
            for (int i = 0; i < labelIds.Length; i++)
            {
                string s = labelIds[i];
                fixed (char* sPtr = s)
                {
                    offset += Encoding.UTF8.GetBytes(sPtr, s.Length, nativeLabelIdsData + offset, labelIdsByteCounts[i]);
                    nativeLabelIdsData[offset] = 0;
                    offset += 1;
                }
            }
            
            byte** nativeLabelIds = stackalloc byte*[labelIds.Length];
            offset = 0;
            for (int i = 0; i < labelIds.Length; i++)
            {
                nativeLabelIds[i] = &nativeLabelIdsData[offset];
                offset += labelIdsByteCounts[i] + 1;
            }
            
            fixed (long* nativeValues = &values)
            {
                ImPlotNative.ImPlot_PlotBarGroups_S64Ptr(nativeLabelIds, nativeValues, itemCount, groupCount, groupSize, shift, flags);
            }
        }
        
        /// <summary>
        ///     Plots the bar groups using the specified label ids
        /// </summary>
        /// <param name="labelIds">The label ids</param>
        /// <param name="values">The values</param>
        /// <param name="itemCount">The item count</param>
        /// <param name="groupCount">The group count</param>
        public static void PlotBarGroups(string[] labelIds, ref ulong values, int itemCount, int groupCount)
        {
            int* labelIdsByteCounts = stackalloc int[labelIds.Length];
            int labelIdsByteCount = 0;
            for (int i = 0; i < labelIds.Length; i++)
            {
                string s = labelIds[i];
                labelIdsByteCounts[i] = Encoding.UTF8.GetByteCount(s);
                labelIdsByteCount += labelIdsByteCounts[i] + 1;
            }
            
            byte* nativeLabelIdsData = stackalloc byte[labelIdsByteCount];
            int offset = 0;
            for (int i = 0; i < labelIds.Length; i++)
            {
                string s = labelIds[i];
                fixed (char* sPtr = s)
                {
                    offset += Encoding.UTF8.GetBytes(sPtr, s.Length, nativeLabelIdsData + offset, labelIdsByteCounts[i]);
                    nativeLabelIdsData[offset] = 0;
                    offset += 1;
                }
            }
            
            byte** nativeLabelIds = stackalloc byte*[labelIds.Length];
            offset = 0;
            for (int i = 0; i < labelIds.Length; i++)
            {
                nativeLabelIds[i] = &nativeLabelIdsData[offset];
                offset += labelIdsByteCounts[i] + 1;
            }
            
            double groupSize = 0.67;
            double shift = 0;
            ImPlotBarGroupsFlags flags = 0;
            fixed (ulong* nativeValues = &values)
            {
                ImPlotNative.ImPlot_PlotBarGroups_U64Ptr(nativeLabelIds, nativeValues, itemCount, groupCount, groupSize, shift, flags);
            }
        }
        
        /// <summary>
        ///     Plots the bar groups using the specified label ids
        /// </summary>
        /// <param name="labelIds">The label ids</param>
        /// <param name="values">The values</param>
        /// <param name="itemCount">The item count</param>
        /// <param name="groupCount">The group count</param>
        /// <param name="groupSize">The group size</param>
        public static void PlotBarGroups(string[] labelIds, ref ulong values, int itemCount, int groupCount, double groupSize)
        {
            int* labelIdsByteCounts = stackalloc int[labelIds.Length];
            int labelIdsByteCount = 0;
            for (int i = 0; i < labelIds.Length; i++)
            {
                string s = labelIds[i];
                labelIdsByteCounts[i] = Encoding.UTF8.GetByteCount(s);
                labelIdsByteCount += labelIdsByteCounts[i] + 1;
            }
            
            byte* nativeLabelIdsData = stackalloc byte[labelIdsByteCount];
            int offset = 0;
            for (int i = 0; i < labelIds.Length; i++)
            {
                string s = labelIds[i];
                fixed (char* sPtr = s)
                {
                    offset += Encoding.UTF8.GetBytes(sPtr, s.Length, nativeLabelIdsData + offset, labelIdsByteCounts[i]);
                    nativeLabelIdsData[offset] = 0;
                    offset += 1;
                }
            }
            
            byte** nativeLabelIds = stackalloc byte*[labelIds.Length];
            offset = 0;
            for (int i = 0; i < labelIds.Length; i++)
            {
                nativeLabelIds[i] = &nativeLabelIdsData[offset];
                offset += labelIdsByteCounts[i] + 1;
            }
            
            double shift = 0;
            ImPlotBarGroupsFlags flags = 0;
            fixed (ulong* nativeValues = &values)
            {
                ImPlotNative.ImPlot_PlotBarGroups_U64Ptr(nativeLabelIds, nativeValues, itemCount, groupCount, groupSize, shift, flags);
            }
        }
        
        /// <summary>
        ///     Plots the bar groups using the specified label ids
        /// </summary>
        /// <param name="labelIds">The label ids</param>
        /// <param name="values">The values</param>
        /// <param name="itemCount">The item count</param>
        /// <param name="groupCount">The group count</param>
        /// <param name="groupSize">The group size</param>
        /// <param name="shift">The shift</param>
        public static void PlotBarGroups(string[] labelIds, ref ulong values, int itemCount, int groupCount, double groupSize, double shift)
        {
            int* labelIdsByteCounts = stackalloc int[labelIds.Length];
            int labelIdsByteCount = 0;
            for (int i = 0; i < labelIds.Length; i++)
            {
                string s = labelIds[i];
                labelIdsByteCounts[i] = Encoding.UTF8.GetByteCount(s);
                labelIdsByteCount += labelIdsByteCounts[i] + 1;
            }
            
            byte* nativeLabelIdsData = stackalloc byte[labelIdsByteCount];
            int offset = 0;
            for (int i = 0; i < labelIds.Length; i++)
            {
                string s = labelIds[i];
                fixed (char* sPtr = s)
                {
                    offset += Encoding.UTF8.GetBytes(sPtr, s.Length, nativeLabelIdsData + offset, labelIdsByteCounts[i]);
                    nativeLabelIdsData[offset] = 0;
                    offset += 1;
                }
            }
            
            byte** nativeLabelIds = stackalloc byte*[labelIds.Length];
            offset = 0;
            for (int i = 0; i < labelIds.Length; i++)
            {
                nativeLabelIds[i] = &nativeLabelIdsData[offset];
                offset += labelIdsByteCounts[i] + 1;
            }
            
            ImPlotBarGroupsFlags flags = 0;
            fixed (ulong* nativeValues = &values)
            {
                ImPlotNative.ImPlot_PlotBarGroups_U64Ptr(nativeLabelIds, nativeValues, itemCount, groupCount, groupSize, shift, flags);
            }
        }
        
        /// <summary>
        ///     Plots the bar groups using the specified label ids
        /// </summary>
        /// <param name="labelIds">The label ids</param>
        /// <param name="values">The values</param>
        /// <param name="itemCount">The item count</param>
        /// <param name="groupCount">The group count</param>
        /// <param name="groupSize">The group size</param>
        /// <param name="shift">The shift</param>
        /// <param name="flags">The flags</param>
        public static void PlotBarGroups(string[] labelIds, ref ulong values, int itemCount, int groupCount, double groupSize, double shift, ImPlotBarGroupsFlags flags)
        {
            int* labelIdsByteCounts = stackalloc int[labelIds.Length];
            int labelIdsByteCount = 0;
            for (int i = 0; i < labelIds.Length; i++)
            {
                string s = labelIds[i];
                labelIdsByteCounts[i] = Encoding.UTF8.GetByteCount(s);
                labelIdsByteCount += labelIdsByteCounts[i] + 1;
            }
            
            byte* nativeLabelIdsData = stackalloc byte[labelIdsByteCount];
            int offset = 0;
            for (int i = 0; i < labelIds.Length; i++)
            {
                string s = labelIds[i];
                fixed (char* sPtr = s)
                {
                    offset += Encoding.UTF8.GetBytes(sPtr, s.Length, nativeLabelIdsData + offset, labelIdsByteCounts[i]);
                    nativeLabelIdsData[offset] = 0;
                    offset += 1;
                }
            }
            
            byte** nativeLabelIds = stackalloc byte*[labelIds.Length];
            offset = 0;
            for (int i = 0; i < labelIds.Length; i++)
            {
                nativeLabelIds[i] = &nativeLabelIdsData[offset];
                offset += labelIdsByteCounts[i] + 1;
            }
            
            fixed (ulong* nativeValues = &values)
            {
                ImPlotNative.ImPlot_PlotBarGroups_U64Ptr(nativeLabelIds, nativeValues, itemCount, groupCount, groupSize, shift, flags);
            }
        }
        
        /// <summary>
        ///     Plots the bars using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        public static void PlotBars(string labelId, ref float values, int count)
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
            
            double barSize = 0.67;
            double shift = 0;
            ImPlotBarsFlags flags = 0;
            int offset = 0;
            int stride = sizeof(float);
            fixed (float* nativeValues = &values)
            {
                ImPlotNative.ImPlot_PlotBars_FloatPtrInt(nativeLabelId, nativeValues, count, barSize, shift, flags, offset, stride);
                if (labelIdByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeLabelId);
                }
            }
        }
        
        /// <summary>
        ///     Plots the bars using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="barSize">The bar size</param>
        public static void PlotBars(string labelId, ref float values, int count, double barSize)
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
            
            double shift = 0;
            ImPlotBarsFlags flags = 0;
            int offset = 0;
            int stride = sizeof(float);
            fixed (float* nativeValues = &values)
            {
                ImPlotNative.ImPlot_PlotBars_FloatPtrInt(nativeLabelId, nativeValues, count, barSize, shift, flags, offset, stride);
                if (labelIdByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeLabelId);
                }
            }
        }
        
        /// <summary>
        ///     Plots the bars using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="barSize">The bar size</param>
        /// <param name="shift">The shift</param>
        public static void PlotBars(string labelId, ref float values, int count, double barSize, double shift)
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
            
            ImPlotBarsFlags flags = 0;
            int offset = 0;
            int stride = sizeof(float);
            fixed (float* nativeValues = &values)
            {
                ImPlotNative.ImPlot_PlotBars_FloatPtrInt(nativeLabelId, nativeValues, count, barSize, shift, flags, offset, stride);
                if (labelIdByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeLabelId);
                }
            }
        }
        
        /// <summary>
        ///     Plots the bars using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="barSize">The bar size</param>
        /// <param name="shift">The shift</param>
        /// <param name="flags">The flags</param>
        public static void PlotBars(string labelId, ref float values, int count, double barSize, double shift, ImPlotBarsFlags flags)
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
                ImPlotNative.ImPlot_PlotBars_FloatPtrInt(nativeLabelId, nativeValues, count, barSize, shift, flags, offset, stride);
                if (labelIdByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeLabelId);
                }
            }
        }
        
        /// <summary>
        ///     Plots the bars using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="barSize">The bar size</param>
        /// <param name="shift">The shift</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        public static void PlotBars(string labelId, ref float values, int count, double barSize, double shift, ImPlotBarsFlags flags, int offset)
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
                ImPlotNative.ImPlot_PlotBars_FloatPtrInt(nativeLabelId, nativeValues, count, barSize, shift, flags, offset, stride);
                if (labelIdByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeLabelId);
                }
            }
        }
        
        /// <summary>
        ///     Plots the bars using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="barSize">The bar size</param>
        /// <param name="shift">The shift</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        /// <param name="stride">The stride</param>
        public static void PlotBars(string labelId, ref float values, int count, double barSize, double shift, ImPlotBarsFlags flags, int offset, int stride)
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
                ImPlotNative.ImPlot_PlotBars_FloatPtrInt(nativeLabelId, nativeValues, count, barSize, shift, flags, offset, stride);
                if (labelIdByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeLabelId);
                }
            }
        }
        
        /// <summary>
        ///     Plots the bars using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        public static void PlotBars(string labelId, ref double values, int count)
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
            
            double barSize = 0.67;
            double shift = 0;
            ImPlotBarsFlags flags = 0;
            int offset = 0;
            int stride = sizeof(double);
            fixed (double* nativeValues = &values)
            {
                ImPlotNative.ImPlot_PlotBars_doublePtrInt(nativeLabelId, nativeValues, count, barSize, shift, flags, offset, stride);
                if (labelIdByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeLabelId);
                }
            }
        }
        
        /// <summary>
        ///     Plots the bars using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="barSize">The bar size</param>
        public static void PlotBars(string labelId, ref double values, int count, double barSize)
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
            
            double shift = 0;
            ImPlotBarsFlags flags = 0;
            int offset = 0;
            int stride = sizeof(double);
            fixed (double* nativeValues = &values)
            {
                ImPlotNative.ImPlot_PlotBars_doublePtrInt(nativeLabelId, nativeValues, count, barSize, shift, flags, offset, stride);
                if (labelIdByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeLabelId);
                }
            }
        }
        
        /// <summary>
        ///     Plots the bars using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="barSize">The bar size</param>
        /// <param name="shift">The shift</param>
        public static void PlotBars(string labelId, ref double values, int count, double barSize, double shift)
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
            
            ImPlotBarsFlags flags = 0;
            int offset = 0;
            int stride = sizeof(double);
            fixed (double* nativeValues = &values)
            {
                ImPlotNative.ImPlot_PlotBars_doublePtrInt(nativeLabelId, nativeValues, count, barSize, shift, flags, offset, stride);
                if (labelIdByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeLabelId);
                }
            }
        }
        
        /// <summary>
        ///     Plots the bars using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="barSize">The bar size</param>
        /// <param name="shift">The shift</param>
        /// <param name="flags">The flags</param>
        public static void PlotBars(string labelId, ref double values, int count, double barSize, double shift, ImPlotBarsFlags flags)
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
                ImPlotNative.ImPlot_PlotBars_doublePtrInt(nativeLabelId, nativeValues, count, barSize, shift, flags, offset, stride);
                if (labelIdByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeLabelId);
                }
            }
        }
        
        /// <summary>
        ///     Plots the bars using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="barSize">The bar size</param>
        /// <param name="shift">The shift</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        public static void PlotBars(string labelId, ref double values, int count, double barSize, double shift, ImPlotBarsFlags flags, int offset)
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
                ImPlotNative.ImPlot_PlotBars_doublePtrInt(nativeLabelId, nativeValues, count, barSize, shift, flags, offset, stride);
                if (labelIdByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeLabelId);
                }
            }
        }
        
        /// <summary>
        ///     Plots the bars using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="barSize">The bar size</param>
        /// <param name="shift">The shift</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        /// <param name="stride">The stride</param>
        public static void PlotBars(string labelId, ref double values, int count, double barSize, double shift, ImPlotBarsFlags flags, int offset, int stride)
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
                ImPlotNative.ImPlot_PlotBars_doublePtrInt(nativeLabelId, nativeValues, count, barSize, shift, flags, offset, stride);
                if (labelIdByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeLabelId);
                }
            }
        }
        
        /// <summary>
        ///     Plots the bars using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        public static void PlotBars(string labelId, ref sbyte values, int count)
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
            
            double barSize = 0.67;
            double shift = 0;
            ImPlotBarsFlags flags = 0;
            int offset = 0;
            int stride = sizeof(sbyte);
            fixed (sbyte* nativeValues = &values)
            {
                ImPlotNative.ImPlot_PlotBars_S8PtrInt(nativeLabelId, nativeValues, count, barSize, shift, flags, offset, stride);
                if (labelIdByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeLabelId);
                }
            }
        }
        
        /// <summary>
        ///     Plots the bars using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="barSize">The bar size</param>
        public static void PlotBars(string labelId, ref sbyte values, int count, double barSize)
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
            
            double shift = 0;
            ImPlotBarsFlags flags = 0;
            int offset = 0;
            int stride = sizeof(sbyte);
            fixed (sbyte* nativeValues = &values)
            {
                ImPlotNative.ImPlot_PlotBars_S8PtrInt(nativeLabelId, nativeValues, count, barSize, shift, flags, offset, stride);
                if (labelIdByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeLabelId);
                }
            }
        }
        
        /// <summary>
        ///     Plots the bars using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="barSize">The bar size</param>
        /// <param name="shift">The shift</param>
        public static void PlotBars(string labelId, ref sbyte values, int count, double barSize, double shift)
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
            
            ImPlotBarsFlags flags = 0;
            int offset = 0;
            int stride = sizeof(sbyte);
            fixed (sbyte* nativeValues = &values)
            {
                ImPlotNative.ImPlot_PlotBars_S8PtrInt(nativeLabelId, nativeValues, count, barSize, shift, flags, offset, stride);
                if (labelIdByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeLabelId);
                }
            }
        }
        
        /// <summary>
        ///     Plots the bars using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="barSize">The bar size</param>
        /// <param name="shift">The shift</param>
        /// <param name="flags">The flags</param>
        public static void PlotBars(string labelId, ref sbyte values, int count, double barSize, double shift, ImPlotBarsFlags flags)
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
                ImPlotNative.ImPlot_PlotBars_S8PtrInt(nativeLabelId, nativeValues, count, barSize, shift, flags, offset, stride);
                if (labelIdByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeLabelId);
                }
            }
        }
        
        /// <summary>
        ///     Plots the bars using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="barSize">The bar size</param>
        /// <param name="shift">The shift</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        public static void PlotBars(string labelId, ref sbyte values, int count, double barSize, double shift, ImPlotBarsFlags flags, int offset)
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
                ImPlotNative.ImPlot_PlotBars_S8PtrInt(nativeLabelId, nativeValues, count, barSize, shift, flags, offset, stride);
                if (labelIdByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeLabelId);
                }
            }
        }
        
        /// <summary>
        ///     Plots the bars using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="barSize">The bar size</param>
        /// <param name="shift">The shift</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        /// <param name="stride">The stride</param>
        public static void PlotBars(string labelId, ref sbyte values, int count, double barSize, double shift, ImPlotBarsFlags flags, int offset, int stride)
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
                ImPlotNative.ImPlot_PlotBars_S8PtrInt(nativeLabelId, nativeValues, count, barSize, shift, flags, offset, stride);
                if (labelIdByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeLabelId);
                }
            }
        }
        
        /// <summary>
        ///     Plots the bars using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        public static void PlotBars(string labelId, ref byte values, int count)
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
            
            double barSize = 0.67;
            double shift = 0;
            ImPlotBarsFlags flags = 0;
            int offset = 0;
            int stride = sizeof(byte);
            fixed (byte* nativeValues = &values)
            {
                ImPlotNative.ImPlot_PlotBars_U8PtrInt(nativeLabelId, nativeValues, count, barSize, shift, flags, offset, stride);
                if (labelIdByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeLabelId);
                }
            }
        }
        
        /// <summary>
        ///     Plots the bars using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="barSize">The bar size</param>
        public static void PlotBars(string labelId, ref byte values, int count, double barSize)
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
            
            double shift = 0;
            ImPlotBarsFlags flags = 0;
            int offset = 0;
            int stride = sizeof(byte);
            fixed (byte* nativeValues = &values)
            {
                ImPlotNative.ImPlot_PlotBars_U8PtrInt(nativeLabelId, nativeValues, count, barSize, shift, flags, offset, stride);
                if (labelIdByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeLabelId);
                }
            }
        }
        
        /// <summary>
        ///     Plots the bars using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="barSize">The bar size</param>
        /// <param name="shift">The shift</param>
        public static void PlotBars(string labelId, ref byte values, int count, double barSize, double shift)
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
            
            ImPlotBarsFlags flags = 0;
            int offset = 0;
            int stride = sizeof(byte);
            fixed (byte* nativeValues = &values)
            {
                ImPlotNative.ImPlot_PlotBars_U8PtrInt(nativeLabelId, nativeValues, count, barSize, shift, flags, offset, stride);
                if (labelIdByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeLabelId);
                }
            }
        }
        
        /// <summary>
        ///     Plots the bars using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="barSize">The bar size</param>
        /// <param name="shift">The shift</param>
        /// <param name="flags">The flags</param>
        public static void PlotBars(string labelId, ref byte values, int count, double barSize, double shift, ImPlotBarsFlags flags)
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
                ImPlotNative.ImPlot_PlotBars_U8PtrInt(nativeLabelId, nativeValues, count, barSize, shift, flags, offset, stride);
                if (labelIdByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeLabelId);
                }
            }
        }
        
        /// <summary>
        ///     Plots the bars using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="barSize">The bar size</param>
        /// <param name="shift">The shift</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        public static void PlotBars(string labelId, ref byte values, int count, double barSize, double shift, ImPlotBarsFlags flags, int offset)
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
                ImPlotNative.ImPlot_PlotBars_U8PtrInt(nativeLabelId, nativeValues, count, barSize, shift, flags, offset, stride);
                if (labelIdByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeLabelId);
                }
            }
        }
        
        /// <summary>
        ///     Plots the bars using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="barSize">The bar size</param>
        /// <param name="shift">The shift</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        /// <param name="stride">The stride</param>
        public static void PlotBars(string labelId, ref byte values, int count, double barSize, double shift, ImPlotBarsFlags flags, int offset, int stride)
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
                ImPlotNative.ImPlot_PlotBars_U8PtrInt(nativeLabelId, nativeValues, count, barSize, shift, flags, offset, stride);
                if (labelIdByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeLabelId);
                }
            }
        }
        
        /// <summary>
        ///     Plots the bars using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        public static void PlotBars(string labelId, ref short values, int count)
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
            
            double barSize = 0.67;
            double shift = 0;
            ImPlotBarsFlags flags = 0;
            int offset = 0;
            int stride = sizeof(short);
            fixed (short* nativeValues = &values)
            {
                ImPlotNative.ImPlot_PlotBars_S16PtrInt(nativeLabelId, nativeValues, count, barSize, shift, flags, offset, stride);
                if (labelIdByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeLabelId);
                }
            }
        }
        
        /// <summary>
        ///     Plots the bars using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="barSize">The bar size</param>
        public static void PlotBars(string labelId, ref short values, int count, double barSize)
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
            
            double shift = 0;
            ImPlotBarsFlags flags = 0;
            int offset = 0;
            int stride = sizeof(short);
            fixed (short* nativeValues = &values)
            {
                ImPlotNative.ImPlot_PlotBars_S16PtrInt(nativeLabelId, nativeValues, count, barSize, shift, flags, offset, stride);
                if (labelIdByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeLabelId);
                }
            }
        }
        
        /// <summary>
        ///     Plots the bars using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="barSize">The bar size</param>
        /// <param name="shift">The shift</param>
        public static void PlotBars(string labelId, ref short values, int count, double barSize, double shift)
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
            
            ImPlotBarsFlags flags = 0;
            int offset = 0;
            int stride = sizeof(short);
            fixed (short* nativeValues = &values)
            {
                ImPlotNative.ImPlot_PlotBars_S16PtrInt(nativeLabelId, nativeValues, count, barSize, shift, flags, offset, stride);
                if (labelIdByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeLabelId);
                }
            }
        }
        
        /// <summary>
        ///     Plots the bars using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="barSize">The bar size</param>
        /// <param name="shift">The shift</param>
        /// <param name="flags">The flags</param>
        public static void PlotBars(string labelId, ref short values, int count, double barSize, double shift, ImPlotBarsFlags flags)
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
            int stride = sizeof(short);
            fixed (short* nativeValues = &values)
            {
                ImPlotNative.ImPlot_PlotBars_S16PtrInt(nativeLabelId, nativeValues, count, barSize, shift, flags, offset, stride);
                if (labelIdByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeLabelId);
                }
            }
        }
        
        /// <summary>
        ///     Plots the bars using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="barSize">The bar size</param>
        /// <param name="shift">The shift</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        public static void PlotBars(string labelId, ref short values, int count, double barSize, double shift, ImPlotBarsFlags flags, int offset)
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
            
            int stride = sizeof(short);
            fixed (short* nativeValues = &values)
            {
                ImPlotNative.ImPlot_PlotBars_S16PtrInt(nativeLabelId, nativeValues, count, barSize, shift, flags, offset, stride);
                if (labelIdByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeLabelId);
                }
            }
        }
        
        /// <summary>
        ///     Plots the bars using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="barSize">The bar size</param>
        /// <param name="shift">The shift</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        /// <param name="stride">The stride</param>
        public static void PlotBars(string labelId, ref short values, int count, double barSize, double shift, ImPlotBarsFlags flags, int offset, int stride)
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
                ImPlotNative.ImPlot_PlotBars_S16PtrInt(nativeLabelId, nativeValues, count, barSize, shift, flags, offset, stride);
                if (labelIdByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeLabelId);
                }
            }
        }
        
        /// <summary>
        ///     Plots the bars using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        public static void PlotBars(string labelId, ref ushort values, int count)
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
            
            double barSize = 0.67;
            double shift = 0;
            ImPlotBarsFlags flags = 0;
            int offset = 0;
            int stride = sizeof(ushort);
            fixed (ushort* nativeValues = &values)
            {
                ImPlotNative.ImPlot_PlotBars_U16PtrInt(nativeLabelId, nativeValues, count, barSize, shift, flags, offset, stride);
                if (labelIdByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeLabelId);
                }
            }
        }
        
        /// <summary>
        ///     Plots the bars using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="barSize">The bar size</param>
        public static void PlotBars(string labelId, ref ushort values, int count, double barSize)
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
            
            double shift = 0;
            ImPlotBarsFlags flags = 0;
            int offset = 0;
            int stride = sizeof(ushort);
            fixed (ushort* nativeValues = &values)
            {
                ImPlotNative.ImPlot_PlotBars_U16PtrInt(nativeLabelId, nativeValues, count, barSize, shift, flags, offset, stride);
                if (labelIdByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeLabelId);
                }
            }
        }
        
        /// <summary>
        ///     Plots the bars using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="barSize">The bar size</param>
        /// <param name="shift">The shift</param>
        public static void PlotBars(string labelId, ref ushort values, int count, double barSize, double shift)
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
            
            ImPlotBarsFlags flags = 0;
            int offset = 0;
            int stride = sizeof(ushort);
            fixed (ushort* nativeValues = &values)
            {
                ImPlotNative.ImPlot_PlotBars_U16PtrInt(nativeLabelId, nativeValues, count, barSize, shift, flags, offset, stride);
                if (labelIdByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeLabelId);
                }
            }
        }
        
        /// <summary>
        ///     Plots the bars using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="barSize">The bar size</param>
        /// <param name="shift">The shift</param>
        /// <param name="flags">The flags</param>
        public static void PlotBars(string labelId, ref ushort values, int count, double barSize, double shift, ImPlotBarsFlags flags)
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
            int stride = sizeof(ushort);
            fixed (ushort* nativeValues = &values)
            {
                ImPlotNative.ImPlot_PlotBars_U16PtrInt(nativeLabelId, nativeValues, count, barSize, shift, flags, offset, stride);
                if (labelIdByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeLabelId);
                }
            }
        }
        
        /// <summary>
        ///     Plots the bars using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="barSize">The bar size</param>
        /// <param name="shift">The shift</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        public static void PlotBars(string labelId, ref ushort values, int count, double barSize, double shift, ImPlotBarsFlags flags, int offset)
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
            
            int stride = sizeof(ushort);
            fixed (ushort* nativeValues = &values)
            {
                ImPlotNative.ImPlot_PlotBars_U16PtrInt(nativeLabelId, nativeValues, count, barSize, shift, flags, offset, stride);
                if (labelIdByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeLabelId);
                }
            }
        }
        
        /// <summary>
        ///     Plots the bars using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="barSize">The bar size</param>
        /// <param name="shift">The shift</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        /// <param name="stride">The stride</param>
        public static void PlotBars(string labelId, ref ushort values, int count, double barSize, double shift, ImPlotBarsFlags flags, int offset, int stride)
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
                ImPlotNative.ImPlot_PlotBars_U16PtrInt(nativeLabelId, nativeValues, count, barSize, shift, flags, offset, stride);
                if (labelIdByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeLabelId);
                }
            }
        }
        
        /// <summary>
        ///     Plots the bars using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        public static void PlotBars(string labelId, ref int values, int count)
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
            
            double barSize = 0.67;
            double shift = 0;
            ImPlotBarsFlags flags = 0;
            int offset = 0;
            int stride = sizeof(int);
            fixed (int* nativeValues = &values)
            {
                ImPlotNative.ImPlot_PlotBars_S32PtrInt(nativeLabelId, nativeValues, count, barSize, shift, flags, offset, stride);
                if (labelIdByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeLabelId);
                }
            }
        }
        
        /// <summary>
        ///     Plots the bars using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="barSize">The bar size</param>
        public static void PlotBars(string labelId, ref int values, int count, double barSize)
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
            
            double shift = 0;
            ImPlotBarsFlags flags = 0;
            int offset = 0;
            int stride = sizeof(int);
            fixed (int* nativeValues = &values)
            {
                ImPlotNative.ImPlot_PlotBars_S32PtrInt(nativeLabelId, nativeValues, count, barSize, shift, flags, offset, stride);
                if (labelIdByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeLabelId);
                }
            }
        }
        
        /// <summary>
        ///     Plots the bars using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="barSize">The bar size</param>
        /// <param name="shift">The shift</param>
        public static void PlotBars(string labelId, ref int values, int count, double barSize, double shift)
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
            
            ImPlotBarsFlags flags = 0;
            int offset = 0;
            int stride = sizeof(int);
            fixed (int* nativeValues = &values)
            {
                ImPlotNative.ImPlot_PlotBars_S32PtrInt(nativeLabelId, nativeValues, count, barSize, shift, flags, offset, stride);
                if (labelIdByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeLabelId);
                }
            }
        }
        
        /// <summary>
        ///     Plots the bars using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="barSize">The bar size</param>
        /// <param name="shift">The shift</param>
        /// <param name="flags">The flags</param>
        public static void PlotBars(string labelId, ref int values, int count, double barSize, double shift, ImPlotBarsFlags flags)
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
            int stride = sizeof(int);
            fixed (int* nativeValues = &values)
            {
                ImPlotNative.ImPlot_PlotBars_S32PtrInt(nativeLabelId, nativeValues, count, barSize, shift, flags, offset, stride);
                if (labelIdByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeLabelId);
                }
            }
        }
        
        /// <summary>
        ///     Plots the bars using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="barSize">The bar size</param>
        /// <param name="shift">The shift</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        public static void PlotBars(string labelId, ref int values, int count, double barSize, double shift, ImPlotBarsFlags flags, int offset)
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
            
            int stride = sizeof(int);
            fixed (int* nativeValues = &values)
            {
                ImPlotNative.ImPlot_PlotBars_S32PtrInt(nativeLabelId, nativeValues, count, barSize, shift, flags, offset, stride);
                if (labelIdByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeLabelId);
                }
            }
        }
        
        /// <summary>
        ///     Plots the bars using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="barSize">The bar size</param>
        /// <param name="shift">The shift</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        /// <param name="stride">The stride</param>
        public static void PlotBars(string labelId, ref int values, int count, double barSize, double shift, ImPlotBarsFlags flags, int offset, int stride)
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
                ImPlotNative.ImPlot_PlotBars_S32PtrInt(nativeLabelId, nativeValues, count, barSize, shift, flags, offset, stride);
                if (labelIdByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeLabelId);
                }
            }
        }
        
        /// <summary>
        ///     Plots the bars using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        public static void PlotBars(string labelId, ref uint values, int count)
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
            
            double barSize = 0.67;
            double shift = 0;
            ImPlotBarsFlags flags = 0;
            int offset = 0;
            int stride = sizeof(uint);
            fixed (uint* nativeValues = &values)
            {
                ImPlotNative.ImPlot_PlotBars_U32PtrInt(nativeLabelId, nativeValues, count, barSize, shift, flags, offset, stride);
                if (labelIdByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeLabelId);
                }
            }
        }
        
    }
}