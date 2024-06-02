// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImPlotP14.cs
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
        ///     Plots the stems using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="ref">The ref</param>
        /// <param name="scale">The scale</param>
        /// <param name="start">The start</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        public static void PlotStems(string labelId, ref byte values, int count, double @ref, double scale, double start, ImPlotStemsFlags flags, int offset)
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
                ImPlotNative.ImPlot_PlotStems_U8PtrInt(nativeLabelId, nativeValues, count, @ref, scale, start, flags, offset, stride);
                if (labelIdByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeLabelId);
                }
            }
        }
        
        /// <summary>
        ///     Plots the stems using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="ref">The ref</param>
        /// <param name="scale">The scale</param>
        /// <param name="start">The start</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        /// <param name="stride">The stride</param>
        public static void PlotStems(string labelId, ref byte values, int count, double @ref, double scale, double start, ImPlotStemsFlags flags, int offset, int stride)
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
                ImPlotNative.ImPlot_PlotStems_U8PtrInt(nativeLabelId, nativeValues, count, @ref, scale, start, flags, offset, stride);
                if (labelIdByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeLabelId);
                }
            }
        }
        
        /// <summary>
        ///     Plots the stems using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        public static void PlotStems(string labelId, ref short values, int count)
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
            
            double @ref = 0;
            double scale = 1;
            double start = 0;
            ImPlotStemsFlags flags = 0;
            int offset = 0;
            int stride = sizeof(short);
            fixed (short* nativeValues = &values)
            {
                ImPlotNative.ImPlot_PlotStems_S16PtrInt(nativeLabelId, nativeValues, count, @ref, scale, start, flags, offset, stride);
                if (labelIdByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeLabelId);
                }
            }
        }
        
        /// <summary>
        ///     Plots the stems using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="ref">The ref</param>
        public static void PlotStems(string labelId, ref short values, int count, double @ref)
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
            
            double scale = 1;
            double start = 0;
            ImPlotStemsFlags flags = 0;
            int offset = 0;
            int stride = sizeof(short);
            fixed (short* nativeValues = &values)
            {
                ImPlotNative.ImPlot_PlotStems_S16PtrInt(nativeLabelId, nativeValues, count, @ref, scale, start, flags, offset, stride);
                if (labelIdByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeLabelId);
                }
            }
        }
        
        /// <summary>
        ///     Plots the stems using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="ref">The ref</param>
        /// <param name="scale">The scale</param>
        public static void PlotStems(string labelId, ref short values, int count, double @ref, double scale)
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
            
            double start = 0;
            ImPlotStemsFlags flags = 0;
            int offset = 0;
            int stride = sizeof(short);
            fixed (short* nativeValues = &values)
            {
                ImPlotNative.ImPlot_PlotStems_S16PtrInt(nativeLabelId, nativeValues, count, @ref, scale, start, flags, offset, stride);
                if (labelIdByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeLabelId);
                }
            }
        }
        
        /// <summary>
        ///     Plots the stems using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="ref">The ref</param>
        /// <param name="scale">The scale</param>
        /// <param name="start">The start</param>
        public static void PlotStems(string labelId, ref short values, int count, double @ref, double scale, double start)
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
            
            ImPlotStemsFlags flags = 0;
            int offset = 0;
            int stride = sizeof(short);
            fixed (short* nativeValues = &values)
            {
                ImPlotNative.ImPlot_PlotStems_S16PtrInt(nativeLabelId, nativeValues, count, @ref, scale, start, flags, offset, stride);
                if (labelIdByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeLabelId);
                }
            }
        }
        
        /// <summary>
        ///     Plots the stems using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="ref">The ref</param>
        /// <param name="scale">The scale</param>
        /// <param name="start">The start</param>
        /// <param name="flags">The flags</param>
        public static void PlotStems(string labelId, ref short values, int count, double @ref, double scale, double start, ImPlotStemsFlags flags)
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
                ImPlotNative.ImPlot_PlotStems_S16PtrInt(nativeLabelId, nativeValues, count, @ref, scale, start, flags, offset, stride);
                if (labelIdByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeLabelId);
                }
            }
        }
        
        /// <summary>
        ///     Plots the stems using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="ref">The ref</param>
        /// <param name="scale">The scale</param>
        /// <param name="start">The start</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        public static void PlotStems(string labelId, ref short values, int count, double @ref, double scale, double start, ImPlotStemsFlags flags, int offset)
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
                ImPlotNative.ImPlot_PlotStems_S16PtrInt(nativeLabelId, nativeValues, count, @ref, scale, start, flags, offset, stride);
                if (labelIdByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeLabelId);
                }
            }
        }
        
        /// <summary>
        ///     Plots the stems using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="ref">The ref</param>
        /// <param name="scale">The scale</param>
        /// <param name="start">The start</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        /// <param name="stride">The stride</param>
        public static void PlotStems(string labelId, ref short values, int count, double @ref, double scale, double start, ImPlotStemsFlags flags, int offset, int stride)
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
                ImPlotNative.ImPlot_PlotStems_S16PtrInt(nativeLabelId, nativeValues, count, @ref, scale, start, flags, offset, stride);
                if (labelIdByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeLabelId);
                }
            }
        }
        
        /// <summary>
        ///     Plots the stems using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        public static void PlotStems(string labelId, ref ushort values, int count)
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
            
            double @ref = 0;
            double scale = 1;
            double start = 0;
            ImPlotStemsFlags flags = 0;
            int offset = 0;
            int stride = sizeof(ushort);
            fixed (ushort* nativeValues = &values)
            {
                ImPlotNative.ImPlot_PlotStems_U16PtrInt(nativeLabelId, nativeValues, count, @ref, scale, start, flags, offset, stride);
                if (labelIdByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeLabelId);
                }
            }
        }
        
        /// <summary>
        ///     Plots the stems using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="ref">The ref</param>
        public static void PlotStems(string labelId, ref ushort values, int count, double @ref)
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
            
            double scale = 1;
            double start = 0;
            ImPlotStemsFlags flags = 0;
            int offset = 0;
            int stride = sizeof(ushort);
            fixed (ushort* nativeValues = &values)
            {
                ImPlotNative.ImPlot_PlotStems_U16PtrInt(nativeLabelId, nativeValues, count, @ref, scale, start, flags, offset, stride);
                if (labelIdByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeLabelId);
                }
            }
        }
        
        /// <summary>
        ///     Plots the stems using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="ref">The ref</param>
        /// <param name="scale">The scale</param>
        public static void PlotStems(string labelId, ref ushort values, int count, double @ref, double scale)
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
            
            double start = 0;
            ImPlotStemsFlags flags = 0;
            int offset = 0;
            int stride = sizeof(ushort);
            fixed (ushort* nativeValues = &values)
            {
                ImPlotNative.ImPlot_PlotStems_U16PtrInt(nativeLabelId, nativeValues, count, @ref, scale, start, flags, offset, stride);
                if (labelIdByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeLabelId);
                }
            }
        }
        
        /// <summary>
        ///     Plots the stems using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="ref">The ref</param>
        /// <param name="scale">The scale</param>
        /// <param name="start">The start</param>
        public static void PlotStems(string labelId, ref ushort values, int count, double @ref, double scale, double start)
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
            
            ImPlotStemsFlags flags = 0;
            int offset = 0;
            int stride = sizeof(ushort);
            fixed (ushort* nativeValues = &values)
            {
                ImPlotNative.ImPlot_PlotStems_U16PtrInt(nativeLabelId, nativeValues, count, @ref, scale, start, flags, offset, stride);
                if (labelIdByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeLabelId);
                }
            }
        }
        
        /// <summary>
        ///     Plots the stems using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="ref">The ref</param>
        /// <param name="scale">The scale</param>
        /// <param name="start">The start</param>
        /// <param name="flags">The flags</param>
        public static void PlotStems(string labelId, ref ushort values, int count, double @ref, double scale, double start, ImPlotStemsFlags flags)
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
                ImPlotNative.ImPlot_PlotStems_U16PtrInt(nativeLabelId, nativeValues, count, @ref, scale, start, flags, offset, stride);
                if (labelIdByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeLabelId);
                }
            }
        }
        
        /// <summary>
        ///     Plots the stems using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="ref">The ref</param>
        /// <param name="scale">The scale</param>
        /// <param name="start">The start</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        public static void PlotStems(string labelId, ref ushort values, int count, double @ref, double scale, double start, ImPlotStemsFlags flags, int offset)
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
                ImPlotNative.ImPlot_PlotStems_U16PtrInt(nativeLabelId, nativeValues, count, @ref, scale, start, flags, offset, stride);
                if (labelIdByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeLabelId);
                }
            }
        }
        
        /// <summary>
        ///     Plots the stems using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="ref">The ref</param>
        /// <param name="scale">The scale</param>
        /// <param name="start">The start</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        /// <param name="stride">The stride</param>
        public static void PlotStems(string labelId, ref ushort values, int count, double @ref, double scale, double start, ImPlotStemsFlags flags, int offset, int stride)
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
                ImPlotNative.ImPlot_PlotStems_U16PtrInt(nativeLabelId, nativeValues, count, @ref, scale, start, flags, offset, stride);
                if (labelIdByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeLabelId);
                }
            }
        }
        
        /// <summary>
        ///     Plots the stems using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        public static void PlotStems(string labelId, ref int values, int count)
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
            
            double @ref = 0;
            double scale = 1;
            double start = 0;
            ImPlotStemsFlags flags = 0;
            int offset = 0;
            int stride = sizeof(int);
            fixed (int* nativeValues = &values)
            {
                ImPlotNative.ImPlot_PlotStems_S32PtrInt(nativeLabelId, nativeValues, count, @ref, scale, start, flags, offset, stride);
                if (labelIdByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeLabelId);
                }
            }
        }
        
        /// <summary>
        ///     Plots the stems using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="ref">The ref</param>
        public static void PlotStems(string labelId, ref int values, int count, double @ref)
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
            
            double scale = 1;
            double start = 0;
            ImPlotStemsFlags flags = 0;
            int offset = 0;
            int stride = sizeof(int);
            fixed (int* nativeValues = &values)
            {
                ImPlotNative.ImPlot_PlotStems_S32PtrInt(nativeLabelId, nativeValues, count, @ref, scale, start, flags, offset, stride);
                if (labelIdByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeLabelId);
                }
            }
        }
        
        /// <summary>
        ///     Plots the stems using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="ref">The ref</param>
        /// <param name="scale">The scale</param>
        public static void PlotStems(string labelId, ref int values, int count, double @ref, double scale)
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
            
            double start = 0;
            ImPlotStemsFlags flags = 0;
            int offset = 0;
            int stride = sizeof(int);
            fixed (int* nativeValues = &values)
            {
                ImPlotNative.ImPlot_PlotStems_S32PtrInt(nativeLabelId, nativeValues, count, @ref, scale, start, flags, offset, stride);
                if (labelIdByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeLabelId);
                }
            }
        }
        
        /// <summary>
        ///     Plots the stems using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="ref">The ref</param>
        /// <param name="scale">The scale</param>
        /// <param name="start">The start</param>
        public static void PlotStems(string labelId, ref int values, int count, double @ref, double scale, double start)
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
            
            ImPlotStemsFlags flags = 0;
            int offset = 0;
            int stride = sizeof(int);
            fixed (int* nativeValues = &values)
            {
                ImPlotNative.ImPlot_PlotStems_S32PtrInt(nativeLabelId, nativeValues, count, @ref, scale, start, flags, offset, stride);
                if (labelIdByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeLabelId);
                }
            }
        }
        
        /// <summary>
        ///     Plots the stems using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="ref">The ref</param>
        /// <param name="scale">The scale</param>
        /// <param name="start">The start</param>
        /// <param name="flags">The flags</param>
        public static void PlotStems(string labelId, ref int values, int count, double @ref, double scale, double start, ImPlotStemsFlags flags)
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
                ImPlotNative.ImPlot_PlotStems_S32PtrInt(nativeLabelId, nativeValues, count, @ref, scale, start, flags, offset, stride);
                if (labelIdByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeLabelId);
                }
            }
        }
        
        /// <summary>
        ///     Plots the stems using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="ref">The ref</param>
        /// <param name="scale">The scale</param>
        /// <param name="start">The start</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        public static void PlotStems(string labelId, ref int values, int count, double @ref, double scale, double start, ImPlotStemsFlags flags, int offset)
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
                ImPlotNative.ImPlot_PlotStems_S32PtrInt(nativeLabelId, nativeValues, count, @ref, scale, start, flags, offset, stride);
                if (labelIdByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeLabelId);
                }
            }
        }
        
        /// <summary>
        ///     Plots the stems using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="ref">The ref</param>
        /// <param name="scale">The scale</param>
        /// <param name="start">The start</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        /// <param name="stride">The stride</param>
        public static void PlotStems(string labelId, ref int values, int count, double @ref, double scale, double start, ImPlotStemsFlags flags, int offset, int stride)
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
                ImPlotNative.ImPlot_PlotStems_S32PtrInt(nativeLabelId, nativeValues, count, @ref, scale, start, flags, offset, stride);
                if (labelIdByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeLabelId);
                }
            }
        }
        
        /// <summary>
        ///     Plots the stems using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        public static void PlotStems(string labelId, ref uint values, int count)
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
            
            double @ref = 0;
            double scale = 1;
            double start = 0;
            ImPlotStemsFlags flags = 0;
            int offset = 0;
            int stride = sizeof(uint);
            fixed (uint* nativeValues = &values)
            {
                ImPlotNative.ImPlot_PlotStems_U32PtrInt(nativeLabelId, nativeValues, count, @ref, scale, start, flags, offset, stride);
                if (labelIdByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeLabelId);
                }
            }
        }
        
        /// <summary>
        ///     Plots the stems using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="ref">The ref</param>
        public static void PlotStems(string labelId, ref uint values, int count, double @ref)
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
            
            double scale = 1;
            double start = 0;
            ImPlotStemsFlags flags = 0;
            int offset = 0;
            int stride = sizeof(uint);
            fixed (uint* nativeValues = &values)
            {
                ImPlotNative.ImPlot_PlotStems_U32PtrInt(nativeLabelId, nativeValues, count, @ref, scale, start, flags, offset, stride);
                if (labelIdByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeLabelId);
                }
            }
        }
        
        /// <summary>
        ///     Plots the stems using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="ref">The ref</param>
        /// <param name="scale">The scale</param>
        public static void PlotStems(string labelId, ref uint values, int count, double @ref, double scale)
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
            
            double start = 0;
            ImPlotStemsFlags flags = 0;
            int offset = 0;
            int stride = sizeof(uint);
            fixed (uint* nativeValues = &values)
            {
                ImPlotNative.ImPlot_PlotStems_U32PtrInt(nativeLabelId, nativeValues, count, @ref, scale, start, flags, offset, stride);
                if (labelIdByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeLabelId);
                }
            }
        }
        
        /// <summary>
        ///     Plots the stems using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="ref">The ref</param>
        /// <param name="scale">The scale</param>
        /// <param name="start">The start</param>
        public static void PlotStems(string labelId, ref uint values, int count, double @ref, double scale, double start)
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
            
            ImPlotStemsFlags flags = 0;
            int offset = 0;
            int stride = sizeof(uint);
            fixed (uint* nativeValues = &values)
            {
                ImPlotNative.ImPlot_PlotStems_U32PtrInt(nativeLabelId, nativeValues, count, @ref, scale, start, flags, offset, stride);
                if (labelIdByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeLabelId);
                }
            }
        }
        
        /// <summary>
        ///     Plots the stems using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="ref">The ref</param>
        /// <param name="scale">The scale</param>
        /// <param name="start">The start</param>
        /// <param name="flags">The flags</param>
        public static void PlotStems(string labelId, ref uint values, int count, double @ref, double scale, double start, ImPlotStemsFlags flags)
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
            int stride = sizeof(uint);
            fixed (uint* nativeValues = &values)
            {
                ImPlotNative.ImPlot_PlotStems_U32PtrInt(nativeLabelId, nativeValues, count, @ref, scale, start, flags, offset, stride);
                if (labelIdByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeLabelId);
                }
            }
        }
        
        /// <summary>
        ///     Plots the stems using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="ref">The ref</param>
        /// <param name="scale">The scale</param>
        /// <param name="start">The start</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        public static void PlotStems(string labelId, ref uint values, int count, double @ref, double scale, double start, ImPlotStemsFlags flags, int offset)
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
            
            int stride = sizeof(uint);
            fixed (uint* nativeValues = &values)
            {
                ImPlotNative.ImPlot_PlotStems_U32PtrInt(nativeLabelId, nativeValues, count, @ref, scale, start, flags, offset, stride);
                if (labelIdByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeLabelId);
                }
            }
        }
        
        /// <summary>
        ///     Plots the stems using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="ref">The ref</param>
        /// <param name="scale">The scale</param>
        /// <param name="start">The start</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        /// <param name="stride">The stride</param>
        public static void PlotStems(string labelId, ref uint values, int count, double @ref, double scale, double start, ImPlotStemsFlags flags, int offset, int stride)
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
                ImPlotNative.ImPlot_PlotStems_U32PtrInt(nativeLabelId, nativeValues, count, @ref, scale, start, flags, offset, stride);
                if (labelIdByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeLabelId);
                }
            }
        }
        
        /// <summary>
        ///     Plots the stems using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        public static void PlotStems(string labelId, ref long values, int count)
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
            
            double @ref = 0;
            double scale = 1;
            double start = 0;
            ImPlotStemsFlags flags = 0;
            int offset = 0;
            int stride = sizeof(long);
            fixed (long* nativeValues = &values)
            {
                ImPlotNative.ImPlot_PlotStems_S64PtrInt(nativeLabelId, nativeValues, count, @ref, scale, start, flags, offset, stride);
                if (labelIdByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeLabelId);
                }
            }
        }
        
        /// <summary>
        ///     Plots the stems using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="ref">The ref</param>
        public static void PlotStems(string labelId, ref long values, int count, double @ref)
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
            
            double scale = 1;
            double start = 0;
            ImPlotStemsFlags flags = 0;
            int offset = 0;
            int stride = sizeof(long);
            fixed (long* nativeValues = &values)
            {
                ImPlotNative.ImPlot_PlotStems_S64PtrInt(nativeLabelId, nativeValues, count, @ref, scale, start, flags, offset, stride);
                if (labelIdByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeLabelId);
                }
            }
        }
        
        /// <summary>
        ///     Plots the stems using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="ref">The ref</param>
        /// <param name="scale">The scale</param>
        public static void PlotStems(string labelId, ref long values, int count, double @ref, double scale)
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
            
            double start = 0;
            ImPlotStemsFlags flags = 0;
            int offset = 0;
            int stride = sizeof(long);
            fixed (long* nativeValues = &values)
            {
                ImPlotNative.ImPlot_PlotStems_S64PtrInt(nativeLabelId, nativeValues, count, @ref, scale, start, flags, offset, stride);
                if (labelIdByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeLabelId);
                }
            }
        }
        
        /// <summary>
        ///     Plots the stems using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="ref">The ref</param>
        /// <param name="scale">The scale</param>
        /// <param name="start">The start</param>
        public static void PlotStems(string labelId, ref long values, int count, double @ref, double scale, double start)
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
            
            ImPlotStemsFlags flags = 0;
            int offset = 0;
            int stride = sizeof(long);
            fixed (long* nativeValues = &values)
            {
                ImPlotNative.ImPlot_PlotStems_S64PtrInt(nativeLabelId, nativeValues, count, @ref, scale, start, flags, offset, stride);
                if (labelIdByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeLabelId);
                }
            }
        }
        
        /// <summary>
        ///     Plots the stems using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="ref">The ref</param>
        /// <param name="scale">The scale</param>
        /// <param name="start">The start</param>
        /// <param name="flags">The flags</param>
        public static void PlotStems(string labelId, ref long values, int count, double @ref, double scale, double start, ImPlotStemsFlags flags)
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
            int stride = sizeof(long);
            fixed (long* nativeValues = &values)
            {
                ImPlotNative.ImPlot_PlotStems_S64PtrInt(nativeLabelId, nativeValues, count, @ref, scale, start, flags, offset, stride);
                if (labelIdByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeLabelId);
                }
            }
        }
        
        /// <summary>
        ///     Plots the stems using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="ref">The ref</param>
        /// <param name="scale">The scale</param>
        /// <param name="start">The start</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        public static void PlotStems(string labelId, ref long values, int count, double @ref, double scale, double start, ImPlotStemsFlags flags, int offset)
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
            
            int stride = sizeof(long);
            fixed (long* nativeValues = &values)
            {
                ImPlotNative.ImPlot_PlotStems_S64PtrInt(nativeLabelId, nativeValues, count, @ref, scale, start, flags, offset, stride);
                if (labelIdByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeLabelId);
                }
            }
        }
        
        /// <summary>
        ///     Plots the stems using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="ref">The ref</param>
        /// <param name="scale">The scale</param>
        /// <param name="start">The start</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        /// <param name="stride">The stride</param>
        public static void PlotStems(string labelId, ref long values, int count, double @ref, double scale, double start, ImPlotStemsFlags flags, int offset, int stride)
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
                ImPlotNative.ImPlot_PlotStems_S64PtrInt(nativeLabelId, nativeValues, count, @ref, scale, start, flags, offset, stride);
                if (labelIdByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeLabelId);
                }
            }
        }
        
        /// <summary>
        ///     Plots the stems using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        public static void PlotStems(string labelId, ref ulong values, int count)
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
            
            double @ref = 0;
            double scale = 1;
            double start = 0;
            ImPlotStemsFlags flags = 0;
            int offset = 0;
            int stride = sizeof(ulong);
            fixed (ulong* nativeValues = &values)
            {
                ImPlotNative.ImPlot_PlotStems_U64PtrInt(nativeLabelId, nativeValues, count, @ref, scale, start, flags, offset, stride);
                if (labelIdByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeLabelId);
                }
            }
        }
        
        /// <summary>
        ///     Plots the stems using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="ref">The ref</param>
        public static void PlotStems(string labelId, ref ulong values, int count, double @ref)
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
            
            double scale = 1;
            double start = 0;
            ImPlotStemsFlags flags = 0;
            int offset = 0;
            int stride = sizeof(ulong);
            fixed (ulong* nativeValues = &values)
            {
                ImPlotNative.ImPlot_PlotStems_U64PtrInt(nativeLabelId, nativeValues, count, @ref, scale, start, flags, offset, stride);
                if (labelIdByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeLabelId);
                }
            }
        }
        
        /// <summary>
        ///     Plots the stems using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="ref">The ref</param>
        /// <param name="scale">The scale</param>
        public static void PlotStems(string labelId, ref ulong values, int count, double @ref, double scale)
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
            
            double start = 0;
            ImPlotStemsFlags flags = 0;
            int offset = 0;
            int stride = sizeof(ulong);
            fixed (ulong* nativeValues = &values)
            {
                ImPlotNative.ImPlot_PlotStems_U64PtrInt(nativeLabelId, nativeValues, count, @ref, scale, start, flags, offset, stride);
                if (labelIdByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeLabelId);
                }
            }
        }
        
        /// <summary>
        ///     Plots the stems using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="ref">The ref</param>
        /// <param name="scale">The scale</param>
        /// <param name="start">The start</param>
        public static void PlotStems(string labelId, ref ulong values, int count, double @ref, double scale, double start)
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
            
            ImPlotStemsFlags flags = 0;
            int offset = 0;
            int stride = sizeof(ulong);
            fixed (ulong* nativeValues = &values)
            {
                ImPlotNative.ImPlot_PlotStems_U64PtrInt(nativeLabelId, nativeValues, count, @ref, scale, start, flags, offset, stride);
                if (labelIdByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeLabelId);
                }
            }
        }
        
        /// <summary>
        ///     Plots the stems using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="ref">The ref</param>
        /// <param name="scale">The scale</param>
        /// <param name="start">The start</param>
        /// <param name="flags">The flags</param>
        public static void PlotStems(string labelId, ref ulong values, int count, double @ref, double scale, double start, ImPlotStemsFlags flags)
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
            int stride = sizeof(ulong);
            fixed (ulong* nativeValues = &values)
            {
                ImPlotNative.ImPlot_PlotStems_U64PtrInt(nativeLabelId, nativeValues, count, @ref, scale, start, flags, offset, stride);
                if (labelIdByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeLabelId);
                }
            }
        }
        
        /// <summary>
        ///     Plots the stems using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="ref">The ref</param>
        /// <param name="scale">The scale</param>
        /// <param name="start">The start</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        public static void PlotStems(string labelId, ref ulong values, int count, double @ref, double scale, double start, ImPlotStemsFlags flags, int offset)
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
            
            int stride = sizeof(ulong);
            fixed (ulong* nativeValues = &values)
            {
                ImPlotNative.ImPlot_PlotStems_U64PtrInt(nativeLabelId, nativeValues, count, @ref, scale, start, flags, offset, stride);
                if (labelIdByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeLabelId);
                }
            }
        }
        
        /// <summary>
        ///     Plots the stems using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="ref">The ref</param>
        /// <param name="scale">The scale</param>
        /// <param name="start">The start</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        /// <param name="stride">The stride</param>
        public static void PlotStems(string labelId, ref ulong values, int count, double @ref, double scale, double start, ImPlotStemsFlags flags, int offset, int stride)
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
                ImPlotNative.ImPlot_PlotStems_U64PtrInt(nativeLabelId, nativeValues, count, @ref, scale, start, flags, offset, stride);
                if (labelIdByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeLabelId);
                }
            }
        }
        
        /// <summary>
        ///     Plots the stems using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="count">The count</param>
        public static void PlotStems(string labelId, ref float xs, ref float ys, int count)
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
            
            double @ref = 0;
            ImPlotStemsFlags flags = 0;
            int offset = 0;
            int stride = sizeof(float);
            fixed (float* nativeXs = &xs)
            {
                fixed (float* nativeYs = &ys)
                {
                    ImPlotNative.ImPlot_PlotStems_FloatPtrFloatPtr(nativeLabelId, nativeXs, nativeYs, count, @ref, flags, offset, stride);
                    if (labelIdByteCount > Util.StackAllocationSizeLimit)
                    {
                        Util.Free(nativeLabelId);
                    }
                }
            }
        }
        
        /// <summary>
        ///     Plots the stems using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="count">The count</param>
        /// <param name="ref">The ref</param>
        public static void PlotStems(string labelId, ref float xs, ref float ys, int count, double @ref)
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
            
            ImPlotStemsFlags flags = 0;
            int offset = 0;
            int stride = sizeof(float);
            fixed (float* nativeXs = &xs)
            {
                fixed (float* nativeYs = &ys)
                {
                    ImPlotNative.ImPlot_PlotStems_FloatPtrFloatPtr(nativeLabelId, nativeXs, nativeYs, count, @ref, flags, offset, stride);
                    if (labelIdByteCount > Util.StackAllocationSizeLimit)
                    {
                        Util.Free(nativeLabelId);
                    }
                }
            }
        }
        
        /// <summary>
        ///     Plots the stems using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="count">The count</param>
        /// <param name="ref">The ref</param>
        /// <param name="flags">The flags</param>
        public static void PlotStems(string labelId, ref float xs, ref float ys, int count, double @ref, ImPlotStemsFlags flags)
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
            fixed (float* nativeXs = &xs)
            {
                fixed (float* nativeYs = &ys)
                {
                    ImPlotNative.ImPlot_PlotStems_FloatPtrFloatPtr(nativeLabelId, nativeXs, nativeYs, count, @ref, flags, offset, stride);
                    if (labelIdByteCount > Util.StackAllocationSizeLimit)
                    {
                        Util.Free(nativeLabelId);
                    }
                }
            }
        }
        
        /// <summary>
        ///     Plots the stems using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="count">The count</param>
        /// <param name="ref">The ref</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        public static void PlotStems(string labelId, ref float xs, ref float ys, int count, double @ref, ImPlotStemsFlags flags, int offset)
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
            fixed (float* nativeXs = &xs)
            {
                fixed (float* nativeYs = &ys)
                {
                    ImPlotNative.ImPlot_PlotStems_FloatPtrFloatPtr(nativeLabelId, nativeXs, nativeYs, count, @ref, flags, offset, stride);
                    if (labelIdByteCount > Util.StackAllocationSizeLimit)
                    {
                        Util.Free(nativeLabelId);
                    }
                }
            }
        }
        
        /// <summary>
        ///     Plots the stems using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="count">The count</param>
        /// <param name="ref">The ref</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        /// <param name="stride">The stride</param>
        public static void PlotStems(string labelId, ref float xs, ref float ys, int count, double @ref, ImPlotStemsFlags flags, int offset, int stride)
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
                    ImPlotNative.ImPlot_PlotStems_FloatPtrFloatPtr(nativeLabelId, nativeXs, nativeYs, count, @ref, flags, offset, stride);
                    if (labelIdByteCount > Util.StackAllocationSizeLimit)
                    {
                        Util.Free(nativeLabelId);
                    }
                }
            }
        }
        
        /// <summary>
        ///     Plots the stems using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="count">The count</param>
        public static void PlotStems(string labelId, ref double xs, ref double ys, int count)
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
            
            double @ref = 0;
            ImPlotStemsFlags flags = 0;
            int offset = 0;
            int stride = sizeof(double);
            fixed (double* nativeXs = &xs)
            {
                fixed (double* nativeYs = &ys)
                {
                    ImPlotNative.ImPlot_PlotStems_doublePtrdoublePtr(nativeLabelId, nativeXs, nativeYs, count, @ref, flags, offset, stride);
                    if (labelIdByteCount > Util.StackAllocationSizeLimit)
                    {
                        Util.Free(nativeLabelId);
                    }
                }
            }
        }
        
        /// <summary>
        ///     Plots the stems using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="count">The count</param>
        /// <param name="ref">The ref</param>
        public static void PlotStems(string labelId, ref double xs, ref double ys, int count, double @ref)
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
            
            ImPlotStemsFlags flags = 0;
            int offset = 0;
            int stride = sizeof(double);
            fixed (double* nativeXs = &xs)
            {
                fixed (double* nativeYs = &ys)
                {
                    ImPlotNative.ImPlot_PlotStems_doublePtrdoublePtr(nativeLabelId, nativeXs, nativeYs, count, @ref, flags, offset, stride);
                    if (labelIdByteCount > Util.StackAllocationSizeLimit)
                    {
                        Util.Free(nativeLabelId);
                    }
                }
            }
        }
        
        /// <summary>
        ///     Plots the stems using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="count">The count</param>
        /// <param name="ref">The ref</param>
        /// <param name="flags">The flags</param>
        public static void PlotStems(string labelId, ref double xs, ref double ys, int count, double @ref, ImPlotStemsFlags flags)
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
            fixed (double* nativeXs = &xs)
            {
                fixed (double* nativeYs = &ys)
                {
                    ImPlotNative.ImPlot_PlotStems_doublePtrdoublePtr(nativeLabelId, nativeXs, nativeYs, count, @ref, flags, offset, stride);
                    if (labelIdByteCount > Util.StackAllocationSizeLimit)
                    {
                        Util.Free(nativeLabelId);
                    }
                }
            }
        }
        
        /// <summary>
        ///     Plots the stems using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="count">The count</param>
        /// <param name="ref">The ref</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        public static void PlotStems(string labelId, ref double xs, ref double ys, int count, double @ref, ImPlotStemsFlags flags, int offset)
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
            fixed (double* nativeXs = &xs)
            {
                fixed (double* nativeYs = &ys)
                {
                    ImPlotNative.ImPlot_PlotStems_doublePtrdoublePtr(nativeLabelId, nativeXs, nativeYs, count, @ref, flags, offset, stride);
                    if (labelIdByteCount > Util.StackAllocationSizeLimit)
                    {
                        Util.Free(nativeLabelId);
                    }
                }
            }
        }
        
        /// <summary>
        ///     Plots the stems using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="count">The count</param>
        /// <param name="ref">The ref</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        /// <param name="stride">The stride</param>
        public static void PlotStems(string labelId, ref double xs, ref double ys, int count, double @ref, ImPlotStemsFlags flags, int offset, int stride)
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
                    ImPlotNative.ImPlot_PlotStems_doublePtrdoublePtr(nativeLabelId, nativeXs, nativeYs, count, @ref, flags, offset, stride);
                    if (labelIdByteCount > Util.StackAllocationSizeLimit)
                    {
                        Util.Free(nativeLabelId);
                    }
                }
            }
        }
        
        /// <summary>
        ///     Plots the stems using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="count">The count</param>
        public static void PlotStems(string labelId, ref sbyte xs, ref sbyte ys, int count)
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
            
            double @ref = 0;
            ImPlotStemsFlags flags = 0;
            int offset = 0;
            int stride = sizeof(sbyte);
            fixed (sbyte* nativeXs = &xs)
            {
                fixed (sbyte* nativeYs = &ys)
                {
                    ImPlotNative.ImPlot_PlotStems_S8PtrS8Ptr(nativeLabelId, nativeXs, nativeYs, count, @ref, flags, offset, stride);
                    if (labelIdByteCount > Util.StackAllocationSizeLimit)
                    {
                        Util.Free(nativeLabelId);
                    }
                }
            }
        }
        
        /// <summary>
        ///     Plots the stems using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="count">The count</param>
        /// <param name="ref">The ref</param>
        public static void PlotStems(string labelId, ref sbyte xs, ref sbyte ys, int count, double @ref)
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
            
            ImPlotStemsFlags flags = 0;
            int offset = 0;
            int stride = sizeof(sbyte);
            fixed (sbyte* nativeXs = &xs)
            {
                fixed (sbyte* nativeYs = &ys)
                {
                    ImPlotNative.ImPlot_PlotStems_S8PtrS8Ptr(nativeLabelId, nativeXs, nativeYs, count, @ref, flags, offset, stride);
                    if (labelIdByteCount > Util.StackAllocationSizeLimit)
                    {
                        Util.Free(nativeLabelId);
                    }
                }
            }
        }
        
        /// <summary>
        ///     Plots the stems using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="count">The count</param>
        /// <param name="ref">The ref</param>
        /// <param name="flags">The flags</param>
        public static void PlotStems(string labelId, ref sbyte xs, ref sbyte ys, int count, double @ref, ImPlotStemsFlags flags)
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
            fixed (sbyte* nativeXs = &xs)
            {
                fixed (sbyte* nativeYs = &ys)
                {
                    ImPlotNative.ImPlot_PlotStems_S8PtrS8Ptr(nativeLabelId, nativeXs, nativeYs, count, @ref, flags, offset, stride);
                    if (labelIdByteCount > Util.StackAllocationSizeLimit)
                    {
                        Util.Free(nativeLabelId);
                    }
                }
            }
        }
        
        /// <summary>
        ///     Plots the stems using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="count">The count</param>
        /// <param name="ref">The ref</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        public static void PlotStems(string labelId, ref sbyte xs, ref sbyte ys, int count, double @ref, ImPlotStemsFlags flags, int offset)
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
            fixed (sbyte* nativeXs = &xs)
            {
                fixed (sbyte* nativeYs = &ys)
                {
                    ImPlotNative.ImPlot_PlotStems_S8PtrS8Ptr(nativeLabelId, nativeXs, nativeYs, count, @ref, flags, offset, stride);
                    if (labelIdByteCount > Util.StackAllocationSizeLimit)
                    {
                        Util.Free(nativeLabelId);
                    }
                }
            }
        }
        
        /// <summary>
        ///     Plots the stems using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="count">The count</param>
        /// <param name="ref">The ref</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        /// <param name="stride">The stride</param>
        public static void PlotStems(string labelId, ref sbyte xs, ref sbyte ys, int count, double @ref, ImPlotStemsFlags flags, int offset, int stride)
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
                    ImPlotNative.ImPlot_PlotStems_S8PtrS8Ptr(nativeLabelId, nativeXs, nativeYs, count, @ref, flags, offset, stride);
                    if (labelIdByteCount > Util.StackAllocationSizeLimit)
                    {
                        Util.Free(nativeLabelId);
                    }
                }
            }
        }
        
        /// <summary>
        ///     Plots the stems using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="count">The count</param>
        public static void PlotStems(string labelId, ref byte xs, ref byte ys, int count)
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
            
            double @ref = 0;
            ImPlotStemsFlags flags = 0;
            int offset = 0;
            int stride = sizeof(byte);
            fixed (byte* nativeXs = &xs)
            {
                fixed (byte* nativeYs = &ys)
                {
                    ImPlotNative.ImPlot_PlotStems_U8PtrU8Ptr(nativeLabelId, nativeXs, nativeYs, count, @ref, flags, offset, stride);
                    if (labelIdByteCount > Util.StackAllocationSizeLimit)
                    {
                        Util.Free(nativeLabelId);
                    }
                }
            }
        }
        
        /// <summary>
        ///     Plots the stems using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="count">The count</param>
        /// <param name="ref">The ref</param>
        public static void PlotStems(string labelId, ref byte xs, ref byte ys, int count, double @ref)
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
            
            ImPlotStemsFlags flags = 0;
            int offset = 0;
            int stride = sizeof(byte);
            fixed (byte* nativeXs = &xs)
            {
                fixed (byte* nativeYs = &ys)
                {
                    ImPlotNative.ImPlot_PlotStems_U8PtrU8Ptr(nativeLabelId, nativeXs, nativeYs, count, @ref, flags, offset, stride);
                    if (labelIdByteCount > Util.StackAllocationSizeLimit)
                    {
                        Util.Free(nativeLabelId);
                    }
                }
            }
        }
        
        /// <summary>
        ///     Plots the stems using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="count">The count</param>
        /// <param name="ref">The ref</param>
        /// <param name="flags">The flags</param>
        public static void PlotStems(string labelId, ref byte xs, ref byte ys, int count, double @ref, ImPlotStemsFlags flags)
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
            fixed (byte* nativeXs = &xs)
            {
                fixed (byte* nativeYs = &ys)
                {
                    ImPlotNative.ImPlot_PlotStems_U8PtrU8Ptr(nativeLabelId, nativeXs, nativeYs, count, @ref, flags, offset, stride);
                    if (labelIdByteCount > Util.StackAllocationSizeLimit)
                    {
                        Util.Free(nativeLabelId);
                    }
                }
            }
        }
        
        /// <summary>
        ///     Plots the stems using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="count">The count</param>
        /// <param name="ref">The ref</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        public static void PlotStems(string labelId, ref byte xs, ref byte ys, int count, double @ref, ImPlotStemsFlags flags, int offset)
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
            fixed (byte* nativeXs = &xs)
            {
                fixed (byte* nativeYs = &ys)
                {
                    ImPlotNative.ImPlot_PlotStems_U8PtrU8Ptr(nativeLabelId, nativeXs, nativeYs, count, @ref, flags, offset, stride);
                    if (labelIdByteCount > Util.StackAllocationSizeLimit)
                    {
                        Util.Free(nativeLabelId);
                    }
                }
            }
        }
        
        /// <summary>
        ///     Plots the stems using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="count">The count</param>
        /// <param name="ref">The ref</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        /// <param name="stride">The stride</param>
        public static void PlotStems(string labelId, ref byte xs, ref byte ys, int count, double @ref, ImPlotStemsFlags flags, int offset, int stride)
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
                    ImPlotNative.ImPlot_PlotStems_U8PtrU8Ptr(nativeLabelId, nativeXs, nativeYs, count, @ref, flags, offset, stride);
                    if (labelIdByteCount > Util.StackAllocationSizeLimit)
                    {
                        Util.Free(nativeLabelId);
                    }
                }
            }
        }
        
        /// <summary>
        ///     Plots the stems using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="count">The count</param>
        public static void PlotStems(string labelId, ref short xs, ref short ys, int count)
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
            
            double @ref = 0;
            ImPlotStemsFlags flags = 0;
            int offset = 0;
            int stride = sizeof(short);
            fixed (short* nativeXs = &xs)
            {
                fixed (short* nativeYs = &ys)
                {
                    ImPlotNative.ImPlot_PlotStems_S16PtrS16Ptr(nativeLabelId, nativeXs, nativeYs, count, @ref, flags, offset, stride);
                    if (labelIdByteCount > Util.StackAllocationSizeLimit)
                    {
                        Util.Free(nativeLabelId);
                    }
                }
            }
        }
        
        /// <summary>
        ///     Plots the stems using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="count">The count</param>
        /// <param name="ref">The ref</param>
        public static void PlotStems(string labelId, ref short xs, ref short ys, int count, double @ref)
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
            
            ImPlotStemsFlags flags = 0;
            int offset = 0;
            int stride = sizeof(short);
            fixed (short* nativeXs = &xs)
            {
                fixed (short* nativeYs = &ys)
                {
                    ImPlotNative.ImPlot_PlotStems_S16PtrS16Ptr(nativeLabelId, nativeXs, nativeYs, count, @ref, flags, offset, stride);
                    if (labelIdByteCount > Util.StackAllocationSizeLimit)
                    {
                        Util.Free(nativeLabelId);
                    }
                }
            }
        }
        
        /// <summary>
        ///     Plots the stems using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="count">The count</param>
        /// <param name="ref">The ref</param>
        /// <param name="flags">The flags</param>
        public static void PlotStems(string labelId, ref short xs, ref short ys, int count, double @ref, ImPlotStemsFlags flags)
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
            fixed (short* nativeXs = &xs)
            {
                fixed (short* nativeYs = &ys)
                {
                    ImPlotNative.ImPlot_PlotStems_S16PtrS16Ptr(nativeLabelId, nativeXs, nativeYs, count, @ref, flags, offset, stride);
                    if (labelIdByteCount > Util.StackAllocationSizeLimit)
                    {
                        Util.Free(nativeLabelId);
                    }
                }
            }
        }
        
        /// <summary>
        ///     Plots the stems using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="count">The count</param>
        /// <param name="ref">The ref</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        public static void PlotStems(string labelId, ref short xs, ref short ys, int count, double @ref, ImPlotStemsFlags flags, int offset)
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
            fixed (short* nativeXs = &xs)
            {
                fixed (short* nativeYs = &ys)
                {
                    ImPlotNative.ImPlot_PlotStems_S16PtrS16Ptr(nativeLabelId, nativeXs, nativeYs, count, @ref, flags, offset, stride);
                    if (labelIdByteCount > Util.StackAllocationSizeLimit)
                    {
                        Util.Free(nativeLabelId);
                    }
                }
            }
        }
        
        /// <summary>
        ///     Plots the stems using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="count">The count</param>
        /// <param name="ref">The ref</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        /// <param name="stride">The stride</param>
        public static void PlotStems(string labelId, ref short xs, ref short ys, int count, double @ref, ImPlotStemsFlags flags, int offset, int stride)
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
                    ImPlotNative.ImPlot_PlotStems_S16PtrS16Ptr(nativeLabelId, nativeXs, nativeYs, count, @ref, flags, offset, stride);
                    if (labelIdByteCount > Util.StackAllocationSizeLimit)
                    {
                        Util.Free(nativeLabelId);
                    }
                }
            }
        }
        
        /// <summary>
        ///     Plots the stems using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="count">The count</param>
        public static void PlotStems(string labelId, ref ushort xs, ref ushort ys, int count)
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
            
            double @ref = 0;
            ImPlotStemsFlags flags = 0;
            int offset = 0;
            int stride = sizeof(ushort);
            fixed (ushort* nativeXs = &xs)
            {
                fixed (ushort* nativeYs = &ys)
                {
                    ImPlotNative.ImPlot_PlotStems_U16PtrU16Ptr(nativeLabelId, nativeXs, nativeYs, count, @ref, flags, offset, stride);
                    if (labelIdByteCount > Util.StackAllocationSizeLimit)
                    {
                        Util.Free(nativeLabelId);
                    }
                }
            }
        }
        
        /// <summary>
        ///     Plots the stems using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="count">The count</param>
        /// <param name="ref">The ref</param>
        public static void PlotStems(string labelId, ref ushort xs, ref ushort ys, int count, double @ref)
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
            
            ImPlotStemsFlags flags = 0;
            int offset = 0;
            int stride = sizeof(ushort);
            fixed (ushort* nativeXs = &xs)
            {
                fixed (ushort* nativeYs = &ys)
                {
                    ImPlotNative.ImPlot_PlotStems_U16PtrU16Ptr(nativeLabelId, nativeXs, nativeYs, count, @ref, flags, offset, stride);
                    if (labelIdByteCount > Util.StackAllocationSizeLimit)
                    {
                        Util.Free(nativeLabelId);
                    }
                }
            }
        }
    }
}