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

using System;
using System.Runtime.InteropServices;
using System.Text;

namespace Alis.Extension.Graphic.ImGui.Extras.Plot.Native
{
     /// <summary>
    ///     The im plot class
    /// </summary>
    public static partial class ImPlot
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
            byte[][] nativeLabelIds = new byte[labelIds.Length][];
            for (int i = 0; i < labelIds.Length; i++)
            {
                nativeLabelIds[i] = Encoding.UTF8.GetBytes(labelIds[i]);
            }
            
            ImPlotNative.ImPlot_PlotBarGroups_U32Ptr(nativeLabelIds, ref values, itemCount, groupCount, groupSize, 0, 0);
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
            byte[][] nativeLabelIds = new byte[labelIds.Length][];
            for (int i = 0; i < labelIds.Length; i++)
            {
                nativeLabelIds[i] = Encoding.UTF8.GetBytes(labelIds[i]);
            }
            
            ImPlotNative.ImPlot_PlotBarGroups_U32Ptr(nativeLabelIds, ref values, itemCount, groupCount, groupSize, shift, 0);
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
            byte[][] nativeLabelIds = new byte[labelIds.Length][];
            for (int i = 0; i < labelIds.Length; i++)
            {
                nativeLabelIds[i] = Encoding.UTF8.GetBytes(labelIds[i]);
            }
            
            ImPlotNative.ImPlot_PlotBarGroups_U32Ptr(nativeLabelIds, ref values, itemCount, groupCount, groupSize, shift, flags);
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
            byte[][] nativeLabelIds = new byte[labelIds.Length][];
            for (int i = 0; i < labelIds.Length; i++)
            {
                nativeLabelIds[i] = Encoding.UTF8.GetBytes(labelIds[i]);
            }
            
            double groupSize = 0.67;
            double shift = 0;
            ImPlotBarGroupsFlags flags = 0;
            ImPlotNative.ImPlot_PlotBarGroups_S64Ptr(nativeLabelIds, ref values, itemCount, groupCount, groupSize, shift, flags);
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
            byte[][] nativeLabelIds = new byte[labelIds.Length][];
            for (int i = 0; i < labelIds.Length; i++)
            {
                nativeLabelIds[i] = Encoding.UTF8.GetBytes(labelIds[i]);
            }
            
            double shift = 0;
            ImPlotBarGroupsFlags flags = 0;
            ImPlotNative.ImPlot_PlotBarGroups_S64Ptr(nativeLabelIds, ref values, itemCount, groupCount, groupSize, shift, flags);
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
            byte[][] nativeLabelIds = new byte[labelIds.Length][];
            for (int i = 0; i < labelIds.Length; i++)
            {
                nativeLabelIds[i] = Encoding.UTF8.GetBytes(labelIds[i]);
            }
            
            ImPlotBarGroupsFlags flags = 0;
            ImPlotNative.ImPlot_PlotBarGroups_S64Ptr(nativeLabelIds, ref values, itemCount, groupCount, groupSize, shift, flags);
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
            byte[][] nativeLabelIds = new byte[labelIds.Length][];
            for (int i = 0; i < labelIds.Length; i++)
            {
                nativeLabelIds[i] = Encoding.UTF8.GetBytes(labelIds[i]);
            }
            
            ImPlotNative.ImPlot_PlotBarGroups_S64Ptr(nativeLabelIds, ref values, itemCount, groupCount, groupSize, shift, flags);
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
           byte[][] nativeLabelIds = new byte[labelIds.Length][];
            for (int i = 0; i < labelIds.Length; i++)
            {
                nativeLabelIds[i] = Encoding.UTF8.GetBytes(labelIds[i]);
            }
            ImPlotNative.ImPlot_PlotBarGroups_U64Ptr(nativeLabelIds, ref values, itemCount, groupCount, 0, 0, 0);
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
            byte[][] nativeLabelIds = new byte[labelIds.Length][];
            for (int i = 0; i < labelIds.Length; i++)
            {
                nativeLabelIds[i] = Encoding.UTF8.GetBytes(labelIds[i]);
            }
            double shift = 0;
            ImPlotNative.ImPlot_PlotBarGroups_U64Ptr(nativeLabelIds, ref values, itemCount, groupCount, groupSize, shift, 0);
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
            byte[][] nativeLabelIds = new byte[labelIds.Length][];
            for (int i = 0; i < labelIds.Length; i++)
            {
                nativeLabelIds[i] = Encoding.UTF8.GetBytes(labelIds[i]);
            }
            ImPlotNative.ImPlot_PlotBarGroups_U64Ptr(nativeLabelIds, ref values, itemCount, groupCount, groupSize, shift, 0);
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
            byte[][] nativeLabelIds = new byte[labelIds.Length][];
            for (int i = 0; i < labelIds.Length; i++)
            {
                nativeLabelIds[i] = Encoding.UTF8.GetBytes(labelIds[i]);
            }
            ImPlotNative.ImPlot_PlotBarGroups_U64Ptr(nativeLabelIds, ref values, itemCount, groupCount, groupSize, shift, flags);
        }
        
        /// <summary>
        ///     Plots the bars using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        public static void PlotBars(string labelId, ref float[] values, int count)
        {
            ImPlotNative.ImPlot_PlotBars_FloatPtrInt(Encoding.UTF8.GetBytes(labelId), values, count, 0.67, 0, 0, 0, 0);
        }
        
        /// <summary>
        ///     Plots the bars using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="barSize">The bar size</param>
        public static void PlotBars(string labelId, ref float[] values, int count, double barSize)
        {
            ImPlotNative.ImPlot_PlotBars_FloatPtrInt(Encoding.UTF8.GetBytes(labelId), values, count, barSize, 0, 0, 0, 0);
        }
        
        /// <summary>
        ///     Plots the bars using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="barSize">The bar size</param>
        /// <param name="shift">The shift</param>
        public static void PlotBars(string labelId, ref float[] values, int count, double barSize, double shift)
        {
            ImPlotNative.ImPlot_PlotBars_FloatPtrInt(Encoding.UTF8.GetBytes(labelId), values, count, barSize, shift, 0, 0, sizeof(float));
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
        public static void PlotBars(string labelId, float[] values, int count, double barSize, double shift, ImPlotBarsFlags flags)
        {
            ImPlotNative.ImPlot_PlotBars_FloatPtrInt(Encoding.UTF8.GetBytes(labelId), values, count, barSize, shift, flags, 0, sizeof(float));
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
        public static void PlotBars(string labelId, ref float[] values, int count, double barSize, double shift, ImPlotBarsFlags flags, int offset)
        {
            ImPlotNative.ImPlot_PlotBars_FloatPtrInt(Encoding.UTF8.GetBytes(labelId), values, count, barSize, shift, flags, offset, 0);
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
        public static void PlotBars(string labelId, ref float[] values, int count, double barSize, double shift, ImPlotBarsFlags flags, int offset, int stride)
        {
            ImPlotNative.ImPlot_PlotBars_FloatPtrInt(Encoding.UTF8.GetBytes(labelId), values, count, barSize, shift, flags, offset, stride);
        }
        
        /// <summary>
        ///     Plots the bars using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        public static void PlotBars(string labelId, ref double values, int count)
        {
            ImPlotNative.ImPlot_PlotBars_doublePtrInt(Encoding.UTF8.GetBytes(labelId), ref values, count, 0.67, 0, 0, 0, 0);
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
            ImPlotNative.ImPlot_PlotBars_doublePtrInt(Encoding.UTF8.GetBytes(labelId), ref values, count, barSize, 0, 0, 0, 0);
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
            ImPlotNative.ImPlot_PlotBars_doublePtrInt(Encoding.UTF8.GetBytes(labelId), ref values, count, barSize, shift, 0, 0, 0);
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
            ImPlotNative.ImPlot_PlotBars_doublePtrInt(Encoding.UTF8.GetBytes(labelId), ref values, count, barSize, shift, flags, 0, 0);
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
            ImPlotNative.ImPlot_PlotBars_doublePtrInt(Encoding.UTF8.GetBytes(labelId), ref values, count, barSize, shift, flags, offset, 0);
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
            ImPlotNative.ImPlot_PlotBars_doublePtrInt(Encoding.UTF8.GetBytes(labelId), ref values, count, barSize, shift, flags, offset, stride);
        }
        
        /// <summary>
        ///     Plots the bars using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        public static void PlotBars(string labelId, ref sbyte values, int count)
        {
          ImPlotNative.ImPlot_PlotBars_S8PtrInt(Encoding.UTF8.GetBytes(labelId), ref values, count, 0.67, 0, 0, 0, 0);
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
            ImPlotNative.ImPlot_PlotBars_S8PtrInt(Encoding.UTF8.GetBytes(labelId), ref values, count, barSize, 0, 0, 0, 0);
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
            ImPlotNative.ImPlot_PlotBars_S8PtrInt(Encoding.UTF8.GetBytes(labelId), ref values, count, barSize, shift, 0, 0, 0);
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
        public static void PlotBars(string labelId, sbyte[] values, int count, double barSize, double shift, ImPlotBarsFlags flags)
        {
            ImPlotNative.ImPlot_PlotBars_S8PtrInt(Encoding.UTF8.GetBytes(labelId), ref values[0], count, barSize, shift, flags, 0, 0);
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
            ImPlotNative.ImPlot_PlotBars_S8PtrInt(Encoding.UTF8.GetBytes(labelId), ref values, count, barSize, shift, flags, offset, 0);
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
            ImPlotNative.ImPlot_PlotBars_S8PtrInt(Encoding.UTF8.GetBytes(labelId), ref values, count, barSize, shift, flags, offset, stride);
        }
        
        /// <summary>
        ///     Plots the bars using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        public static void PlotBars(string labelId, ref byte values, int count)
        {
            ImPlotNative.ImPlot_PlotBars_U8PtrInt(Encoding.UTF8.GetBytes(labelId), ref values, count, 0.67, 0, 0, 0, 0);
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
            ImPlotNative.ImPlot_PlotBars_U8PtrInt(Encoding.UTF8.GetBytes(labelId), ref values, count, barSize, 0, 0, 0, 0);
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
            ImPlotNative.ImPlot_PlotBars_U8PtrInt(Encoding.UTF8.GetBytes(labelId), ref values, count, barSize, shift, 0, 0, 0);
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
            ImPlotNative.ImPlot_PlotBars_U8PtrInt(Encoding.UTF8.GetBytes(labelId), ref values, count, barSize, shift, flags, 0, 0);
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
            ImPlotNative.ImPlot_PlotBars_U8PtrInt(Encoding.UTF8.GetBytes(labelId), ref values, count, barSize, shift, flags, offset, 0);
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
            ImPlotNative.ImPlot_PlotBars_U8PtrInt(Encoding.UTF8.GetBytes(labelId), ref values, count, barSize, shift, flags, offset, stride);
        }
        
        /// <summary>
        ///     Plots the bars using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        public static void PlotBars(string labelId, ref short values, int count)
        {
            ImPlotNative.ImPlot_PlotBars_S16PtrInt(Encoding.UTF8.GetBytes(labelId), ref values, count, 0.67, 0, 0, 0, 0);
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
            ImPlotNative.ImPlot_PlotBars_S16PtrInt(Encoding.UTF8.GetBytes(labelId), ref values, count, barSize, 0, 0, 0, 0);
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
            ImPlotNative.ImPlot_PlotBars_S16PtrInt(Encoding.UTF8.GetBytes(labelId), ref values, count, barSize, shift, 0, 0, 0);
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
            ImPlotNative.ImPlot_PlotBars_S16PtrInt(Encoding.UTF8.GetBytes(labelId), ref values, count, barSize, shift, flags, 0, 0);
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
            ImPlotNative.ImPlot_PlotBars_S16PtrInt(Encoding.UTF8.GetBytes(labelId), ref values, count, barSize, shift, flags, offset, 0);
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
            ImPlotNative.ImPlot_PlotBars_S16PtrInt(Encoding.UTF8.GetBytes(labelId), ref values, count, barSize, shift, flags, offset, stride);
        }
        
        /// <summary>
        ///     Plots the bars using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        public static void PlotBars(string labelId, ref ushort values, int count)
        {
            ImPlotNative.ImPlot_PlotBars_U16PtrInt(Encoding.UTF8.GetBytes(labelId), ref values, count, 0.67, 0, 0, 0, 0);
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
            ImPlotNative.ImPlot_PlotBars_U16PtrInt(Encoding.UTF8.GetBytes(labelId), ref values, count, barSize, 0, 0, 0, 0);
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
            ImPlotNative.ImPlot_PlotBars_U16PtrInt(Encoding.UTF8.GetBytes(labelId), ref values, count, barSize, shift, 0, 0, 0);
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
            ImPlotNative.ImPlot_PlotBars_U16PtrInt(Encoding.UTF8.GetBytes(labelId), ref values, count, barSize, shift, flags, 0, 0);
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
            ImPlotNative.ImPlot_PlotBars_U16PtrInt(Encoding.UTF8.GetBytes(labelId), ref values, count, barSize, shift, flags, offset, 0);
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
            ImPlotNative.ImPlot_PlotBars_U16PtrInt(Encoding.UTF8.GetBytes(labelId), ref values, count, barSize, shift, flags, offset, stride);
        }
        
        /// <summary>
        ///     Plots the bars using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        public static void PlotBars(string labelId, ref int values, int count)
        {
            ImPlotNative.ImPlot_PlotBars_S32PtrInt(Encoding.UTF8.GetBytes(labelId), ref values, count, 0.67, 0, 0, 0, 0);
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
            ImPlotNative.ImPlot_PlotBars_S32PtrInt(Encoding.UTF8.GetBytes(labelId), ref values, count, barSize, 0, 0, 0, 0);
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
            ImPlotNative.ImPlot_PlotBars_S32PtrInt(Encoding.UTF8.GetBytes(labelId), ref values, count, barSize, shift, 0, 0, 0);
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
            ImPlotNative.ImPlot_PlotBars_S32PtrInt(Encoding.UTF8.GetBytes(labelId), ref values, count, barSize, shift, flags, 0, 0);
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
            ImPlotNative.ImPlot_PlotBars_S32PtrInt(Encoding.UTF8.GetBytes(labelId), ref values, count, barSize, shift, flags, offset, sizeof(int));
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
            ImPlotNative.ImPlot_PlotBars_S32PtrInt(Encoding.UTF8.GetBytes(labelId), ref values, count, barSize, shift, flags, offset, stride);
        }
        
        /// <summary>
        ///     Plots the bars using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        public static void PlotBars(string labelId, ref uint values, int count)
        {
            ImPlotNative.ImPlot_PlotBars_U32PtrInt(Encoding.UTF8.GetBytes(labelId), ref values, count, 0.67, 0, 0, 0, sizeof(uint));
        }
    }
}