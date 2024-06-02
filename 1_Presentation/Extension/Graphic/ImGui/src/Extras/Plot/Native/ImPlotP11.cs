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

namespace Alis.Extension.Graphic.ImGui.Extras.Plot.Native
{
    /// <summary>
    /// The im plot class
    /// </summary>
    public static unsafe partial class ImPlot
    {
        
        /// <summary>
        ///     Plots the pie chart using the specified label ids
        /// </summary>
        /// <param name="labelIds">The label ids</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="x">The </param>
        /// <param name="y">The </param>
        /// <param name="radius">The radius</param>
        /// <param name="labelFmt">The label fmt</param>
        public static void PlotPieChart(string[] labelIds, ref ushort values, int count, double x, double y, double radius, string labelFmt)
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
            
            double angle0 = 90;
            ImPlotPieChartFlags flags = 0;
            fixed (ushort* nativeValues = &values)
            {
                ImPlotNative.ImPlot_PlotPieChart_U16Ptr(nativeLabelIds, nativeValues, count, x, y, radius, nativeLabelFmt, angle0, flags);
                if (labelFmtByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeLabelFmt);
                }
            }
        }
        
        /// <summary>
        ///     Plots the pie chart using the specified label ids
        /// </summary>
        /// <param name="labelIds">The label ids</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="x">The </param>
        /// <param name="y">The </param>
        /// <param name="radius">The radius</param>
        /// <param name="labelFmt">The label fmt</param>
        /// <param name="angle0">The angle</param>
        public static void PlotPieChart(string[] labelIds, ref ushort values, int count, double x, double y, double radius, string labelFmt, double angle0)
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
            
            ImPlotPieChartFlags flags = 0;
            fixed (ushort* nativeValues = &values)
            {
                ImPlotNative.ImPlot_PlotPieChart_U16Ptr(nativeLabelIds, nativeValues, count, x, y, radius, nativeLabelFmt, angle0, flags);
                if (labelFmtByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeLabelFmt);
                }
            }
        }
        
        /// <summary>
        ///     Plots the pie chart using the specified label ids
        /// </summary>
        /// <param name="labelIds">The label ids</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="x">The </param>
        /// <param name="y">The </param>
        /// <param name="radius">The radius</param>
        /// <param name="labelFmt">The label fmt</param>
        /// <param name="angle0">The angle</param>
        /// <param name="flags">The flags</param>
        public static void PlotPieChart(string[] labelIds, ref ushort values, int count, double x, double y, double radius, string labelFmt, double angle0, ImPlotPieChartFlags flags)
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
                ImPlotNative.ImPlot_PlotPieChart_U16Ptr(nativeLabelIds, nativeValues, count, x, y, radius, nativeLabelFmt, angle0, flags);
                if (labelFmtByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeLabelFmt);
                }
            }
        }
        
        /// <summary>
        ///     Plots the pie chart using the specified label ids
        /// </summary>
        /// <param name="labelIds">The label ids</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="x">The </param>
        /// <param name="y">The </param>
        /// <param name="radius">The radius</param>
        public static void PlotPieChart(string[] labelIds, ref int values, int count, double x, double y, double radius)
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
            double angle0 = 90;
            ImPlotPieChartFlags flags = 0;
            fixed (int* nativeValues = &values)
            {
                ImPlotNative.ImPlot_PlotPieChart_S32Ptr(nativeLabelIds, nativeValues, count, x, y, radius, nativeLabelFmt, angle0, flags);
                if (labelFmtByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeLabelFmt);
                }
            }
        }
        
        /// <summary>
        ///     Plots the pie chart using the specified label ids
        /// </summary>
        /// <param name="labelIds">The label ids</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="x">The </param>
        /// <param name="y">The </param>
        /// <param name="radius">The radius</param>
        /// <param name="labelFmt">The label fmt</param>
        public static void PlotPieChart(string[] labelIds, ref int values, int count, double x, double y, double radius, string labelFmt)
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
            
            double angle0 = 90;
            ImPlotPieChartFlags flags = 0;
            fixed (int* nativeValues = &values)
            {
                ImPlotNative.ImPlot_PlotPieChart_S32Ptr(nativeLabelIds, nativeValues, count, x, y, radius, nativeLabelFmt, angle0, flags);
                if (labelFmtByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeLabelFmt);
                }
            }
        }
        
        /// <summary>
        ///     Plots the pie chart using the specified label ids
        /// </summary>
        /// <param name="labelIds">The label ids</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="x">The </param>
        /// <param name="y">The </param>
        /// <param name="radius">The radius</param>
        /// <param name="labelFmt">The label fmt</param>
        /// <param name="angle0">The angle</param>
        public static void PlotPieChart(string[] labelIds, ref int values, int count, double x, double y, double radius, string labelFmt, double angle0)
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
            
            ImPlotPieChartFlags flags = 0;
            fixed (int* nativeValues = &values)
            {
                ImPlotNative.ImPlot_PlotPieChart_S32Ptr(nativeLabelIds, nativeValues, count, x, y, radius, nativeLabelFmt, angle0, flags);
                if (labelFmtByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeLabelFmt);
                }
            }
        }
        
        /// <summary>
        ///     Plots the pie chart using the specified label ids
        /// </summary>
        /// <param name="labelIds">The label ids</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="x">The </param>
        /// <param name="y">The </param>
        /// <param name="radius">The radius</param>
        /// <param name="labelFmt">The label fmt</param>
        /// <param name="angle0">The angle</param>
        /// <param name="flags">The flags</param>
        public static void PlotPieChart(string[] labelIds, ref int values, int count, double x, double y, double radius, string labelFmt, double angle0, ImPlotPieChartFlags flags)
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
                ImPlotNative.ImPlot_PlotPieChart_S32Ptr(nativeLabelIds, nativeValues, count, x, y, radius, nativeLabelFmt, angle0, flags);
                if (labelFmtByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeLabelFmt);
                }
            }
        }
        
        /// <summary>
        ///     Plots the pie chart using the specified label ids
        /// </summary>
        /// <param name="labelIds">The label ids</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="x">The </param>
        /// <param name="y">The </param>
        /// <param name="radius">The radius</param>
        public static void PlotPieChart(string[] labelIds, ref uint values, int count, double x, double y, double radius)
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
            double angle0 = 90;
            ImPlotPieChartFlags flags = 0;
            fixed (uint* nativeValues = &values)
            {
                ImPlotNative.ImPlot_PlotPieChart_U32Ptr(nativeLabelIds, nativeValues, count, x, y, radius, nativeLabelFmt, angle0, flags);
                if (labelFmtByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeLabelFmt);
                }
            }
        }
        
        /// <summary>
        ///     Plots the pie chart using the specified label ids
        /// </summary>
        /// <param name="labelIds">The label ids</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="x">The </param>
        /// <param name="y">The </param>
        /// <param name="radius">The radius</param>
        /// <param name="labelFmt">The label fmt</param>
        public static void PlotPieChart(string[] labelIds, ref uint values, int count, double x, double y, double radius, string labelFmt)
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
            
            double angle0 = 90;
            ImPlotPieChartFlags flags = 0;
            fixed (uint* nativeValues = &values)
            {
                ImPlotNative.ImPlot_PlotPieChart_U32Ptr(nativeLabelIds, nativeValues, count, x, y, radius, nativeLabelFmt, angle0, flags);
                if (labelFmtByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeLabelFmt);
                }
            }
        }
        
        /// <summary>
        ///     Plots the pie chart using the specified label ids
        /// </summary>
        /// <param name="labelIds">The label ids</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="x">The </param>
        /// <param name="y">The </param>
        /// <param name="radius">The radius</param>
        /// <param name="labelFmt">The label fmt</param>
        /// <param name="angle0">The angle</param>
        public static void PlotPieChart(string[] labelIds, ref uint values, int count, double x, double y, double radius, string labelFmt, double angle0)
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
            
            ImPlotPieChartFlags flags = 0;
            fixed (uint* nativeValues = &values)
            {
                ImPlotNative.ImPlot_PlotPieChart_U32Ptr(nativeLabelIds, nativeValues, count, x, y, radius, nativeLabelFmt, angle0, flags);
                if (labelFmtByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeLabelFmt);
                }
            }
        }
        
        /// <summary>
        ///     Plots the pie chart using the specified label ids
        /// </summary>
        /// <param name="labelIds">The label ids</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="x">The </param>
        /// <param name="y">The </param>
        /// <param name="radius">The radius</param>
        /// <param name="labelFmt">The label fmt</param>
        /// <param name="angle0">The angle</param>
        /// <param name="flags">The flags</param>
        public static void PlotPieChart(string[] labelIds, ref uint values, int count, double x, double y, double radius, string labelFmt, double angle0, ImPlotPieChartFlags flags)
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
                ImPlotNative.ImPlot_PlotPieChart_U32Ptr(nativeLabelIds, nativeValues, count, x, y, radius, nativeLabelFmt, angle0, flags);
                if (labelFmtByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeLabelFmt);
                }
            }
        }
        
        /// <summary>
        ///     Plots the pie chart using the specified label ids
        /// </summary>
        /// <param name="labelIds">The label ids</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="x">The </param>
        /// <param name="y">The </param>
        /// <param name="radius">The radius</param>
        public static void PlotPieChart(string[] labelIds, ref long values, int count, double x, double y, double radius)
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
            double angle0 = 90;
            ImPlotPieChartFlags flags = 0;
            fixed (long* nativeValues = &values)
            {
                ImPlotNative.ImPlot_PlotPieChart_S64Ptr(nativeLabelIds, nativeValues, count, x, y, radius, nativeLabelFmt, angle0, flags);
                if (labelFmtByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeLabelFmt);
                }
            }
        }
        
        /// <summary>
        ///     Plots the pie chart using the specified label ids
        /// </summary>
        /// <param name="labelIds">The label ids</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="x">The </param>
        /// <param name="y">The </param>
        /// <param name="radius">The radius</param>
        /// <param name="labelFmt">The label fmt</param>
        public static void PlotPieChart(string[] labelIds, ref long values, int count, double x, double y, double radius, string labelFmt)
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
            
            double angle0 = 90;
            ImPlotPieChartFlags flags = 0;
            fixed (long* nativeValues = &values)
            {
                ImPlotNative.ImPlot_PlotPieChart_S64Ptr(nativeLabelIds, nativeValues, count, x, y, radius, nativeLabelFmt, angle0, flags);
                if (labelFmtByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeLabelFmt);
                }
            }
        }
        
        /// <summary>
        ///     Plots the pie chart using the specified label ids
        /// </summary>
        /// <param name="labelIds">The label ids</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="x">The </param>
        /// <param name="y">The </param>
        /// <param name="radius">The radius</param>
        /// <param name="labelFmt">The label fmt</param>
        /// <param name="angle0">The angle</param>
        public static void PlotPieChart(string[] labelIds, ref long values, int count, double x, double y, double radius, string labelFmt, double angle0)
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
            
            ImPlotPieChartFlags flags = 0;
            fixed (long* nativeValues = &values)
            {
                ImPlotNative.ImPlot_PlotPieChart_S64Ptr(nativeLabelIds, nativeValues, count, x, y, radius, nativeLabelFmt, angle0, flags);
                if (labelFmtByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeLabelFmt);
                }
            }
        }
        
        /// <summary>
        ///     Plots the pie chart using the specified label ids
        /// </summary>
        /// <param name="labelIds">The label ids</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="x">The </param>
        /// <param name="y">The </param>
        /// <param name="radius">The radius</param>
        /// <param name="labelFmt">The label fmt</param>
        /// <param name="angle0">The angle</param>
        /// <param name="flags">The flags</param>
        public static void PlotPieChart(string[] labelIds, ref long values, int count, double x, double y, double radius, string labelFmt, double angle0, ImPlotPieChartFlags flags)
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
                ImPlotNative.ImPlot_PlotPieChart_S64Ptr(nativeLabelIds, nativeValues, count, x, y, radius, nativeLabelFmt, angle0, flags);
                if (labelFmtByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeLabelFmt);
                }
            }
        }
        
        /// <summary>
        ///     Plots the pie chart using the specified label ids
        /// </summary>
        /// <param name="labelIds">The label ids</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="x">The </param>
        /// <param name="y">The </param>
        /// <param name="radius">The radius</param>
        public static void PlotPieChart(string[] labelIds, ref ulong values, int count, double x, double y, double radius)
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
            double angle0 = 90;
            ImPlotPieChartFlags flags = 0;
            fixed (ulong* nativeValues = &values)
            {
                ImPlotNative.ImPlot_PlotPieChart_U64Ptr(nativeLabelIds, nativeValues, count, x, y, radius, nativeLabelFmt, angle0, flags);
                if (labelFmtByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeLabelFmt);
                }
            }
        }
        
        /// <summary>
        ///     Plots the pie chart using the specified label ids
        /// </summary>
        /// <param name="labelIds">The label ids</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="x">The </param>
        /// <param name="y">The </param>
        /// <param name="radius">The radius</param>
        /// <param name="labelFmt">The label fmt</param>
        public static void PlotPieChart(string[] labelIds, ref ulong values, int count, double x, double y, double radius, string labelFmt)
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
            
            double angle0 = 90;
            ImPlotPieChartFlags flags = 0;
            fixed (ulong* nativeValues = &values)
            {
                ImPlotNative.ImPlot_PlotPieChart_U64Ptr(nativeLabelIds, nativeValues, count, x, y, radius, nativeLabelFmt, angle0, flags);
                if (labelFmtByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeLabelFmt);
                }
            }
        }
        
        /// <summary>
        ///     Plots the pie chart using the specified label ids
        /// </summary>
        /// <param name="labelIds">The label ids</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="x">The </param>
        /// <param name="y">The </param>
        /// <param name="radius">The radius</param>
        /// <param name="labelFmt">The label fmt</param>
        /// <param name="angle0">The angle</param>
        public static void PlotPieChart(string[] labelIds, ref ulong values, int count, double x, double y, double radius, string labelFmt, double angle0)
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
            
            ImPlotPieChartFlags flags = 0;
            fixed (ulong* nativeValues = &values)
            {
                ImPlotNative.ImPlot_PlotPieChart_U64Ptr(nativeLabelIds, nativeValues, count, x, y, radius, nativeLabelFmt, angle0, flags);
                if (labelFmtByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeLabelFmt);
                }
            }
        }
        
        /// <summary>
        ///     Plots the pie chart using the specified label ids
        /// </summary>
        /// <param name="labelIds">The label ids</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="x">The </param>
        /// <param name="y">The </param>
        /// <param name="radius">The radius</param>
        /// <param name="labelFmt">The label fmt</param>
        /// <param name="angle0">The angle</param>
        /// <param name="flags">The flags</param>
        public static void PlotPieChart(string[] labelIds, ref ulong values, int count, double x, double y, double radius, string labelFmt, double angle0, ImPlotPieChartFlags flags)
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
                ImPlotNative.ImPlot_PlotPieChart_U64Ptr(nativeLabelIds, nativeValues, count, x, y, radius, nativeLabelFmt, angle0, flags);
                if (labelFmtByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeLabelFmt);
                }
            }
        }
        
        /// <summary>
        ///     Plots the scatter using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        public static void PlotScatter(string labelId, ref float values, int count)
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
            
            double xscale = 1;
            double xstart = 0;
            ImPlotScatterFlags flags = 0;
            int offset = 0;
            int stride = sizeof(float);
            fixed (float* nativeValues = &values)
            {
                ImPlotNative.ImPlot_PlotScatter_FloatPtrInt(nativeLabelId, nativeValues, count, xscale, xstart, flags, offset, stride);
                if (labelIdByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeLabelId);
                }
            }
        }
        
        /// <summary>
        ///     Plots the scatter using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="xscale">The xscale</param>
        public static void PlotScatter(string labelId, ref float values, int count, double xscale)
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
            
            double xstart = 0;
            ImPlotScatterFlags flags = 0;
            int offset = 0;
            int stride = sizeof(float);
            fixed (float* nativeValues = &values)
            {
                ImPlotNative.ImPlot_PlotScatter_FloatPtrInt(nativeLabelId, nativeValues, count, xscale, xstart, flags, offset, stride);
                if (labelIdByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeLabelId);
                }
            }
        }
        
        /// <summary>
        ///     Plots the scatter using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="xscale">The xscale</param>
        /// <param name="xstart">The xstart</param>
        public static void PlotScatter(string labelId, ref float values, int count, double xscale, double xstart)
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
            
            ImPlotScatterFlags flags = 0;
            int offset = 0;
            int stride = sizeof(float);
            fixed (float* nativeValues = &values)
            {
                ImPlotNative.ImPlot_PlotScatter_FloatPtrInt(nativeLabelId, nativeValues, count, xscale, xstart, flags, offset, stride);
                if (labelIdByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeLabelId);
                }
            }
        }
        
        /// <summary>
        ///     Plots the scatter using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="xscale">The xscale</param>
        /// <param name="xstart">The xstart</param>
        /// <param name="flags">The flags</param>
        public static void PlotScatter(string labelId, ref float values, int count, double xscale, double xstart, ImPlotScatterFlags flags)
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
                ImPlotNative.ImPlot_PlotScatter_FloatPtrInt(nativeLabelId, nativeValues, count, xscale, xstart, flags, offset, stride);
                if (labelIdByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeLabelId);
                }
            }
        }
        
        /// <summary>
        ///     Plots the scatter using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="xscale">The xscale</param>
        /// <param name="xstart">The xstart</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        public static void PlotScatter(string labelId, ref float values, int count, double xscale, double xstart, ImPlotScatterFlags flags, int offset)
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
                ImPlotNative.ImPlot_PlotScatter_FloatPtrInt(nativeLabelId, nativeValues, count, xscale, xstart, flags, offset, stride);
                if (labelIdByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeLabelId);
                }
            }
        }
        
        /// <summary>
        ///     Plots the scatter using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="xscale">The xscale</param>
        /// <param name="xstart">The xstart</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        /// <param name="stride">The stride</param>
        public static void PlotScatter(string labelId, ref float values, int count, double xscale, double xstart, ImPlotScatterFlags flags, int offset, int stride)
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
                ImPlotNative.ImPlot_PlotScatter_FloatPtrInt(nativeLabelId, nativeValues, count, xscale, xstart, flags, offset, stride);
                if (labelIdByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeLabelId);
                }
            }
        }
        
        /// <summary>
        ///     Plots the scatter using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        public static void PlotScatter(string labelId, ref double values, int count)
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
            
            double xscale = 1;
            double xstart = 0;
            ImPlotScatterFlags flags = 0;
            int offset = 0;
            int stride = sizeof(double);
            fixed (double* nativeValues = &values)
            {
                ImPlotNative.ImPlot_PlotScatter_doublePtrInt(nativeLabelId, nativeValues, count, xscale, xstart, flags, offset, stride);
                if (labelIdByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeLabelId);
                }
            }
        }
        
        /// <summary>
        ///     Plots the scatter using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="xscale">The xscale</param>
        public static void PlotScatter(string labelId, ref double values, int count, double xscale)
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
            
            double xstart = 0;
            ImPlotScatterFlags flags = 0;
            int offset = 0;
            int stride = sizeof(double);
            fixed (double* nativeValues = &values)
            {
                ImPlotNative.ImPlot_PlotScatter_doublePtrInt(nativeLabelId, nativeValues, count, xscale, xstart, flags, offset, stride);
                if (labelIdByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeLabelId);
                }
            }
        }
        
        /// <summary>
        ///     Plots the scatter using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="xscale">The xscale</param>
        /// <param name="xstart">The xstart</param>
        public static void PlotScatter(string labelId, ref double values, int count, double xscale, double xstart)
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
            
            ImPlotScatterFlags flags = 0;
            int offset = 0;
            int stride = sizeof(double);
            fixed (double* nativeValues = &values)
            {
                ImPlotNative.ImPlot_PlotScatter_doublePtrInt(nativeLabelId, nativeValues, count, xscale, xstart, flags, offset, stride);
                if (labelIdByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeLabelId);
                }
            }
        }
        
        /// <summary>
        ///     Plots the scatter using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="xscale">The xscale</param>
        /// <param name="xstart">The xstart</param>
        /// <param name="flags">The flags</param>
        public static void PlotScatter(string labelId, ref double values, int count, double xscale, double xstart, ImPlotScatterFlags flags)
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
                ImPlotNative.ImPlot_PlotScatter_doublePtrInt(nativeLabelId, nativeValues, count, xscale, xstart, flags, offset, stride);
                if (labelIdByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeLabelId);
                }
            }
        }
        
        /// <summary>
        ///     Plots the scatter using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="xscale">The xscale</param>
        /// <param name="xstart">The xstart</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        public static void PlotScatter(string labelId, ref double values, int count, double xscale, double xstart, ImPlotScatterFlags flags, int offset)
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
                ImPlotNative.ImPlot_PlotScatter_doublePtrInt(nativeLabelId, nativeValues, count, xscale, xstart, flags, offset, stride);
                if (labelIdByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeLabelId);
                }
            }
        }
        
        /// <summary>
        ///     Plots the scatter using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="xscale">The xscale</param>
        /// <param name="xstart">The xstart</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        /// <param name="stride">The stride</param>
        public static void PlotScatter(string labelId, ref double values, int count, double xscale, double xstart, ImPlotScatterFlags flags, int offset, int stride)
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
                ImPlotNative.ImPlot_PlotScatter_doublePtrInt(nativeLabelId, nativeValues, count, xscale, xstart, flags, offset, stride);
                if (labelIdByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeLabelId);
                }
            }
        }
        
        /// <summary>
        ///     Plots the scatter using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        public static void PlotScatter(string labelId, ref sbyte values, int count)
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
            
            double xscale = 1;
            double xstart = 0;
            ImPlotScatterFlags flags = 0;
            int offset = 0;
            int stride = sizeof(sbyte);
            fixed (sbyte* nativeValues = &values)
            {
                ImPlotNative.ImPlot_PlotScatter_S8PtrInt(nativeLabelId, nativeValues, count, xscale, xstart, flags, offset, stride);
                if (labelIdByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeLabelId);
                }
            }
        }
        
        /// <summary>
        ///     Plots the scatter using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="xscale">The xscale</param>
        public static void PlotScatter(string labelId, ref sbyte values, int count, double xscale)
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
            
            double xstart = 0;
            ImPlotScatterFlags flags = 0;
            int offset = 0;
            int stride = sizeof(sbyte);
            fixed (sbyte* nativeValues = &values)
            {
                ImPlotNative.ImPlot_PlotScatter_S8PtrInt(nativeLabelId, nativeValues, count, xscale, xstart, flags, offset, stride);
                if (labelIdByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeLabelId);
                }
            }
        }
        
        /// <summary>
        ///     Plots the scatter using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="xscale">The xscale</param>
        /// <param name="xstart">The xstart</param>
        public static void PlotScatter(string labelId, ref sbyte values, int count, double xscale, double xstart)
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
            
            ImPlotScatterFlags flags = 0;
            int offset = 0;
            int stride = sizeof(sbyte);
            fixed (sbyte* nativeValues = &values)
            {
                ImPlotNative.ImPlot_PlotScatter_S8PtrInt(nativeLabelId, nativeValues, count, xscale, xstart, flags, offset, stride);
                if (labelIdByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeLabelId);
                }
            }
        }
        
        /// <summary>
        ///     Plots the scatter using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="xscale">The xscale</param>
        /// <param name="xstart">The xstart</param>
        /// <param name="flags">The flags</param>
        public static void PlotScatter(string labelId, ref sbyte values, int count, double xscale, double xstart, ImPlotScatterFlags flags)
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
                ImPlotNative.ImPlot_PlotScatter_S8PtrInt(nativeLabelId, nativeValues, count, xscale, xstart, flags, offset, stride);
                if (labelIdByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeLabelId);
                }
            }
        }
        
        /// <summary>
        ///     Plots the scatter using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="xscale">The xscale</param>
        /// <param name="xstart">The xstart</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        public static void PlotScatter(string labelId, ref sbyte values, int count, double xscale, double xstart, ImPlotScatterFlags flags, int offset)
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
                ImPlotNative.ImPlot_PlotScatter_S8PtrInt(nativeLabelId, nativeValues, count, xscale, xstart, flags, offset, stride);
                if (labelIdByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeLabelId);
                }
            }
        }
        
        /// <summary>
        ///     Plots the scatter using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="xscale">The xscale</param>
        /// <param name="xstart">The xstart</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        /// <param name="stride">The stride</param>
        public static void PlotScatter(string labelId, ref sbyte values, int count, double xscale, double xstart, ImPlotScatterFlags flags, int offset, int stride)
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
                ImPlotNative.ImPlot_PlotScatter_S8PtrInt(nativeLabelId, nativeValues, count, xscale, xstart, flags, offset, stride);
                if (labelIdByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeLabelId);
                }
            }
        }
        
        /// <summary>
        ///     Plots the scatter using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        public static void PlotScatter(string labelId, ref byte values, int count)
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
            
            double xscale = 1;
            double xstart = 0;
            ImPlotScatterFlags flags = 0;
            int offset = 0;
            int stride = sizeof(byte);
            fixed (byte* nativeValues = &values)
            {
                ImPlotNative.ImPlot_PlotScatter_U8PtrInt(nativeLabelId, nativeValues, count, xscale, xstart, flags, offset, stride);
                if (labelIdByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeLabelId);
                }
            }
        }
        
        /// <summary>
        ///     Plots the scatter using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="xscale">The xscale</param>
        public static void PlotScatter(string labelId, ref byte values, int count, double xscale)
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
            
            double xstart = 0;
            ImPlotScatterFlags flags = 0;
            int offset = 0;
            int stride = sizeof(byte);
            fixed (byte* nativeValues = &values)
            {
                ImPlotNative.ImPlot_PlotScatter_U8PtrInt(nativeLabelId, nativeValues, count, xscale, xstart, flags, offset, stride);
                if (labelIdByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeLabelId);
                }
            }
        }
        
        /// <summary>
        ///     Plots the scatter using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="xscale">The xscale</param>
        /// <param name="xstart">The xstart</param>
        public static void PlotScatter(string labelId, ref byte values, int count, double xscale, double xstart)
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
            
            ImPlotScatterFlags flags = 0;
            int offset = 0;
            int stride = sizeof(byte);
            fixed (byte* nativeValues = &values)
            {
                ImPlotNative.ImPlot_PlotScatter_U8PtrInt(nativeLabelId, nativeValues, count, xscale, xstart, flags, offset, stride);
                if (labelIdByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeLabelId);
                }
            }
        }
        
        /// <summary>
        ///     Plots the scatter using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="xscale">The xscale</param>
        /// <param name="xstart">The xstart</param>
        /// <param name="flags">The flags</param>
        public static void PlotScatter(string labelId, ref byte values, int count, double xscale, double xstart, ImPlotScatterFlags flags)
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
                ImPlotNative.ImPlot_PlotScatter_U8PtrInt(nativeLabelId, nativeValues, count, xscale, xstart, flags, offset, stride);
                if (labelIdByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeLabelId);
                }
            }
        }
        
        /// <summary>
        ///     Plots the scatter using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="xscale">The xscale</param>
        /// <param name="xstart">The xstart</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        public static void PlotScatter(string labelId, ref byte values, int count, double xscale, double xstart, ImPlotScatterFlags flags, int offset)
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
                ImPlotNative.ImPlot_PlotScatter_U8PtrInt(nativeLabelId, nativeValues, count, xscale, xstart, flags, offset, stride);
                if (labelIdByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeLabelId);
                }
            }
        }
        
    }
}