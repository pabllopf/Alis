// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImPlotP9.cs
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

namespace Alis.Extension.Graphic.ImGui.Extras.Plot.Native
{
    public static unsafe partial class ImPlot
        {
        /// <summary>
        ///     Plots the line using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="count">The count</param>
        public static void PlotLine(string labelId, ref int xs, ref int ys, int count)
        {
            byte* nativeLabelId;
            int labelIdByteCount = 0;
            if (labelId != null)
            {
                labelIdByteCount = Encoding.UTF8.GetByteCount(labelId);
                if (labelIdByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeLabelId = Util.Allocate(labelIdByteCount + 1);
                }
                else
                {
                    byte* nativeLabelIdStackBytes = stackalloc byte[labelIdByteCount + 1];
                    nativeLabelId = nativeLabelIdStackBytes;
                }
                
                int nativeLabelIdOffset = Util.GetUtf8(labelId, nativeLabelId, labelIdByteCount);
                nativeLabelId[nativeLabelIdOffset] = 0;
            }
            else
            {
                nativeLabelId = null;
            }
            
            ImPlotLineFlags flags = 0;
            int offset = 0;
            int stride = sizeof(int);
            fixed (int* nativeXs = &xs)
            {
                fixed (int* nativeYs = &ys)
                {
                    ImPlotNative.ImPlot_PlotLine_S32PtrS32Ptr(nativeLabelId, nativeXs, nativeYs, count, flags, offset, stride);
                    if (labelIdByteCount > Util.StackAllocationSizeLimit)
                    {
                        Util.Free(nativeLabelId);
                    }
                }
            }
        }
        
        /// <summary>
        ///     Plots the line using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="count">The count</param>
        /// <param name="flags">The flags</param>
        public static void PlotLine(string labelId, ref int xs, ref int ys, int count, ImPlotLineFlags flags)
        {
            byte* nativeLabelId;
            int labelIdByteCount = 0;
            if (labelId != null)
            {
                labelIdByteCount = Encoding.UTF8.GetByteCount(labelId);
                if (labelIdByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeLabelId = Util.Allocate(labelIdByteCount + 1);
                }
                else
                {
                    byte* nativeLabelIdStackBytes = stackalloc byte[labelIdByteCount + 1];
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
            fixed (int* nativeXs = &xs)
            {
                fixed (int* nativeYs = &ys)
                {
                    ImPlotNative.ImPlot_PlotLine_S32PtrS32Ptr(nativeLabelId, nativeXs, nativeYs, count, flags, offset, stride);
                    if (labelIdByteCount > Util.StackAllocationSizeLimit)
                    {
                        Util.Free(nativeLabelId);
                    }
                }
            }
        }
        
        /// <summary>
        ///     Plots the line using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="count">The count</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        public static void PlotLine(string labelId, ref int xs, ref int ys, int count, ImPlotLineFlags flags, int offset)
        {
            byte* nativeLabelId;
            int labelIdByteCount = 0;
            if (labelId != null)
            {
                labelIdByteCount = Encoding.UTF8.GetByteCount(labelId);
                if (labelIdByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeLabelId = Util.Allocate(labelIdByteCount + 1);
                }
                else
                {
                    byte* nativeLabelIdStackBytes = stackalloc byte[labelIdByteCount + 1];
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
            fixed (int* nativeXs = &xs)
            {
                fixed (int* nativeYs = &ys)
                {
                    ImPlotNative.ImPlot_PlotLine_S32PtrS32Ptr(nativeLabelId, nativeXs, nativeYs, count, flags, offset, stride);
                    if (labelIdByteCount > Util.StackAllocationSizeLimit)
                    {
                        Util.Free(nativeLabelId);
                    }
                }
            }
        }
        
        /// <summary>
        ///     Plots the line using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="count">The count</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        /// <param name="stride">The stride</param>
        public static void PlotLine(string labelId, ref int xs, ref int ys, int count, ImPlotLineFlags flags, int offset, int stride)
        {
            byte* nativeLabelId;
            int labelIdByteCount = 0;
            if (labelId != null)
            {
                labelIdByteCount = Encoding.UTF8.GetByteCount(labelId);
                if (labelIdByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeLabelId = Util.Allocate(labelIdByteCount + 1);
                }
                else
                {
                    byte* nativeLabelIdStackBytes = stackalloc byte[labelIdByteCount + 1];
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
                    ImPlotNative.ImPlot_PlotLine_S32PtrS32Ptr(nativeLabelId, nativeXs, nativeYs, count, flags, offset, stride);
                    if (labelIdByteCount > Util.StackAllocationSizeLimit)
                    {
                        Util.Free(nativeLabelId);
                    }
                }
            }
        }
        
        /// <summary>
        ///     Plots the line using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="count">The count</param>
        public static void PlotLine(string labelId, ref uint xs, ref uint ys, int count)
        {
            byte* nativeLabelId;
            int labelIdByteCount = 0;
            if (labelId != null)
            {
                labelIdByteCount = Encoding.UTF8.GetByteCount(labelId);
                if (labelIdByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeLabelId = Util.Allocate(labelIdByteCount + 1);
                }
                else
                {
                    byte* nativeLabelIdStackBytes = stackalloc byte[labelIdByteCount + 1];
                    nativeLabelId = nativeLabelIdStackBytes;
                }
                
                int nativeLabelIdOffset = Util.GetUtf8(labelId, nativeLabelId, labelIdByteCount);
                nativeLabelId[nativeLabelIdOffset] = 0;
            }
            else
            {
                nativeLabelId = null;
            }
            
            ImPlotLineFlags flags = 0;
            int offset = 0;
            int stride = sizeof(uint);
            fixed (uint* nativeXs = &xs)
            {
                fixed (uint* nativeYs = &ys)
                {
                    ImPlotNative.ImPlot_PlotLine_U32PtrU32Ptr(nativeLabelId, nativeXs, nativeYs, count, flags, offset, stride);
                    if (labelIdByteCount > Util.StackAllocationSizeLimit)
                    {
                        Util.Free(nativeLabelId);
                    }
                }
            }
        }
        
        /// <summary>
        ///     Plots the line using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="count">The count</param>
        /// <param name="flags">The flags</param>
        public static void PlotLine(string labelId, ref uint xs, ref uint ys, int count, ImPlotLineFlags flags)
        {
            byte* nativeLabelId;
            int labelIdByteCount = 0;
            if (labelId != null)
            {
                labelIdByteCount = Encoding.UTF8.GetByteCount(labelId);
                if (labelIdByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeLabelId = Util.Allocate(labelIdByteCount + 1);
                }
                else
                {
                    byte* nativeLabelIdStackBytes = stackalloc byte[labelIdByteCount + 1];
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
            fixed (uint* nativeXs = &xs)
            {
                fixed (uint* nativeYs = &ys)
                {
                    ImPlotNative.ImPlot_PlotLine_U32PtrU32Ptr(nativeLabelId, nativeXs, nativeYs, count, flags, offset, stride);
                    if (labelIdByteCount > Util.StackAllocationSizeLimit)
                    {
                        Util.Free(nativeLabelId);
                    }
                }
            }
        }
        
        /// <summary>
        ///     Plots the line using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="count">The count</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        public static void PlotLine(string labelId, ref uint xs, ref uint ys, int count, ImPlotLineFlags flags, int offset)
        {
            byte* nativeLabelId;
            int labelIdByteCount = 0;
            if (labelId != null)
            {
                labelIdByteCount = Encoding.UTF8.GetByteCount(labelId);
                if (labelIdByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeLabelId = Util.Allocate(labelIdByteCount + 1);
                }
                else
                {
                    byte* nativeLabelIdStackBytes = stackalloc byte[labelIdByteCount + 1];
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
            fixed (uint* nativeXs = &xs)
            {
                fixed (uint* nativeYs = &ys)
                {
                    ImPlotNative.ImPlot_PlotLine_U32PtrU32Ptr(nativeLabelId, nativeXs, nativeYs, count, flags, offset, stride);
                    if (labelIdByteCount > Util.StackAllocationSizeLimit)
                    {
                        Util.Free(nativeLabelId);
                    }
                }
            }
        }
        
        /// <summary>
        ///     Plots the line using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="count">The count</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        /// <param name="stride">The stride</param>
        public static void PlotLine(string labelId, ref uint xs, ref uint ys, int count, ImPlotLineFlags flags, int offset, int stride)
        {
            byte* nativeLabelId;
            int labelIdByteCount = 0;
            if (labelId != null)
            {
                labelIdByteCount = Encoding.UTF8.GetByteCount(labelId);
                if (labelIdByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeLabelId = Util.Allocate(labelIdByteCount + 1);
                }
                else
                {
                    byte* nativeLabelIdStackBytes = stackalloc byte[labelIdByteCount + 1];
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
                    ImPlotNative.ImPlot_PlotLine_U32PtrU32Ptr(nativeLabelId, nativeXs, nativeYs, count, flags, offset, stride);
                    if (labelIdByteCount > Util.StackAllocationSizeLimit)
                    {
                        Util.Free(nativeLabelId);
                    }
                }
            }
        }
        
        /// <summary>
        ///     Plots the line using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="count">The count</param>
        public static void PlotLine(string labelId, ref long xs, ref long ys, int count)
        {
            byte* nativeLabelId;
            int labelIdByteCount = 0;
            if (labelId != null)
            {
                labelIdByteCount = Encoding.UTF8.GetByteCount(labelId);
                if (labelIdByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeLabelId = Util.Allocate(labelIdByteCount + 1);
                }
                else
                {
                    byte* nativeLabelIdStackBytes = stackalloc byte[labelIdByteCount + 1];
                    nativeLabelId = nativeLabelIdStackBytes;
                }
                
                int nativeLabelIdOffset = Util.GetUtf8(labelId, nativeLabelId, labelIdByteCount);
                nativeLabelId[nativeLabelIdOffset] = 0;
            }
            else
            {
                nativeLabelId = null;
            }
            
            ImPlotLineFlags flags = 0;
            int offset = 0;
            int stride = sizeof(long);
            fixed (long* nativeXs = &xs)
            {
                fixed (long* nativeYs = &ys)
                {
                    ImPlotNative.ImPlot_PlotLine_S64PtrS64Ptr(nativeLabelId, nativeXs, nativeYs, count, flags, offset, stride);
                    if (labelIdByteCount > Util.StackAllocationSizeLimit)
                    {
                        Util.Free(nativeLabelId);
                    }
                }
            }
        }
        
        /// <summary>
        ///     Plots the line using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="count">The count</param>
        /// <param name="flags">The flags</param>
        public static void PlotLine(string labelId, ref long xs, ref long ys, int count, ImPlotLineFlags flags)
        {
            byte* nativeLabelId;
            int labelIdByteCount = 0;
            if (labelId != null)
            {
                labelIdByteCount = Encoding.UTF8.GetByteCount(labelId);
                if (labelIdByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeLabelId = Util.Allocate(labelIdByteCount + 1);
                }
                else
                {
                    byte* nativeLabelIdStackBytes = stackalloc byte[labelIdByteCount + 1];
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
            fixed (long* nativeXs = &xs)
            {
                fixed (long* nativeYs = &ys)
                {
                    ImPlotNative.ImPlot_PlotLine_S64PtrS64Ptr(nativeLabelId, nativeXs, nativeYs, count, flags, offset, stride);
                    if (labelIdByteCount > Util.StackAllocationSizeLimit)
                    {
                        Util.Free(nativeLabelId);
                    }
                }
            }
        }
        
        /// <summary>
        ///     Plots the line using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="count">The count</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        public static void PlotLine(string labelId, ref long xs, ref long ys, int count, ImPlotLineFlags flags, int offset)
        {
            byte* nativeLabelId;
            int labelIdByteCount = 0;
            if (labelId != null)
            {
                labelIdByteCount = Encoding.UTF8.GetByteCount(labelId);
                if (labelIdByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeLabelId = Util.Allocate(labelIdByteCount + 1);
                }
                else
                {
                    byte* nativeLabelIdStackBytes = stackalloc byte[labelIdByteCount + 1];
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
            fixed (long* nativeXs = &xs)
            {
                fixed (long* nativeYs = &ys)
                {
                    ImPlotNative.ImPlot_PlotLine_S64PtrS64Ptr(nativeLabelId, nativeXs, nativeYs, count, flags, offset, stride);
                    if (labelIdByteCount > Util.StackAllocationSizeLimit)
                    {
                        Util.Free(nativeLabelId);
                    }
                }
            }
        }
        
        /// <summary>
        ///     Plots the line using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="count">The count</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        /// <param name="stride">The stride</param>
        public static void PlotLine(string labelId, ref long xs, ref long ys, int count, ImPlotLineFlags flags, int offset, int stride)
        {
            byte* nativeLabelId;
            int labelIdByteCount = 0;
            if (labelId != null)
            {
                labelIdByteCount = Encoding.UTF8.GetByteCount(labelId);
                if (labelIdByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeLabelId = Util.Allocate(labelIdByteCount + 1);
                }
                else
                {
                    byte* nativeLabelIdStackBytes = stackalloc byte[labelIdByteCount + 1];
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
                    ImPlotNative.ImPlot_PlotLine_S64PtrS64Ptr(nativeLabelId, nativeXs, nativeYs, count, flags, offset, stride);
                    if (labelIdByteCount > Util.StackAllocationSizeLimit)
                    {
                        Util.Free(nativeLabelId);
                    }
                }
            }
        }
        
        /// <summary>
        ///     Plots the line using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="count">The count</param>
        public static void PlotLine(string labelId, ref ulong xs, ref ulong ys, int count)
        {
            byte* nativeLabelId;
            int labelIdByteCount = 0;
            if (labelId != null)
            {
                labelIdByteCount = Encoding.UTF8.GetByteCount(labelId);
                if (labelIdByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeLabelId = Util.Allocate(labelIdByteCount + 1);
                }
                else
                {
                    byte* nativeLabelIdStackBytes = stackalloc byte[labelIdByteCount + 1];
                    nativeLabelId = nativeLabelIdStackBytes;
                }
                
                int nativeLabelIdOffset = Util.GetUtf8(labelId, nativeLabelId, labelIdByteCount);
                nativeLabelId[nativeLabelIdOffset] = 0;
            }
            else
            {
                nativeLabelId = null;
            }
            
            ImPlotLineFlags flags = 0;
            int offset = 0;
            int stride = sizeof(ulong);
            fixed (ulong* nativeXs = &xs)
            {
                fixed (ulong* nativeYs = &ys)
                {
                    ImPlotNative.ImPlot_PlotLine_U64PtrU64Ptr(nativeLabelId, nativeXs, nativeYs, count, flags, offset, stride);
                    if (labelIdByteCount > Util.StackAllocationSizeLimit)
                    {
                        Util.Free(nativeLabelId);
                    }
                }
            }
        }
        
        /// <summary>
        ///     Plots the line using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="count">The count</param>
        /// <param name="flags">The flags</param>
        public static void PlotLine(string labelId, ref ulong xs, ref ulong ys, int count, ImPlotLineFlags flags)
        {
            byte* nativeLabelId;
            int labelIdByteCount = 0;
            if (labelId != null)
            {
                labelIdByteCount = Encoding.UTF8.GetByteCount(labelId);
                if (labelIdByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeLabelId = Util.Allocate(labelIdByteCount + 1);
                }
                else
                {
                    byte* nativeLabelIdStackBytes = stackalloc byte[labelIdByteCount + 1];
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
            fixed (ulong* nativeXs = &xs)
            {
                fixed (ulong* nativeYs = &ys)
                {
                    ImPlotNative.ImPlot_PlotLine_U64PtrU64Ptr(nativeLabelId, nativeXs, nativeYs, count, flags, offset, stride);
                    if (labelIdByteCount > Util.StackAllocationSizeLimit)
                    {
                        Util.Free(nativeLabelId);
                    }
                }
            }
        }
        
        /// <summary>
        ///     Plots the line using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="count">The count</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        public static void PlotLine(string labelId, ref ulong xs, ref ulong ys, int count, ImPlotLineFlags flags, int offset)
        {
            byte* nativeLabelId;
            int labelIdByteCount = 0;
            if (labelId != null)
            {
                labelIdByteCount = Encoding.UTF8.GetByteCount(labelId);
                if (labelIdByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeLabelId = Util.Allocate(labelIdByteCount + 1);
                }
                else
                {
                    byte* nativeLabelIdStackBytes = stackalloc byte[labelIdByteCount + 1];
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
            fixed (ulong* nativeXs = &xs)
            {
                fixed (ulong* nativeYs = &ys)
                {
                    ImPlotNative.ImPlot_PlotLine_U64PtrU64Ptr(nativeLabelId, nativeXs, nativeYs, count, flags, offset, stride);
                    if (labelIdByteCount > Util.StackAllocationSizeLimit)
                    {
                        Util.Free(nativeLabelId);
                    }
                }
            }
        }
        
        /// <summary>
        ///     Plots the line using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="count">The count</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        /// <param name="stride">The stride</param>
        public static void PlotLine(string labelId, ref ulong xs, ref ulong ys, int count, ImPlotLineFlags flags, int offset, int stride)
        {
            byte* nativeLabelId;
            int labelIdByteCount = 0;
            if (labelId != null)
            {
                labelIdByteCount = Encoding.UTF8.GetByteCount(labelId);
                if (labelIdByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeLabelId = Util.Allocate(labelIdByteCount + 1);
                }
                else
                {
                    byte* nativeLabelIdStackBytes = stackalloc byte[labelIdByteCount + 1];
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
                    ImPlotNative.ImPlot_PlotLine_U64PtrU64Ptr(nativeLabelId, nativeXs, nativeYs, count, flags, offset, stride);
                    if (labelIdByteCount > Util.StackAllocationSizeLimit)
                    {
                        Util.Free(nativeLabelId);
                    }
                }
            }
        }
        
        /// <summary>
        ///     Plots the line g using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="getter">The getter</param>
        /// <param name="data">The data</param>
        /// <param name="count">The count</param>
        public static void PlotLineG(string labelId, IntPtr getter, IntPtr data, int count)
        {
            byte* nativeLabelId;
            int labelIdByteCount = 0;
            if (labelId != null)
            {
                labelIdByteCount = Encoding.UTF8.GetByteCount(labelId);
                if (labelIdByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeLabelId = Util.Allocate(labelIdByteCount + 1);
                }
                else
                {
                    byte* nativeLabelIdStackBytes = stackalloc byte[labelIdByteCount + 1];
                    nativeLabelId = nativeLabelIdStackBytes;
                }
                
                int nativeLabelIdOffset = Util.GetUtf8(labelId, nativeLabelId, labelIdByteCount);
                nativeLabelId[nativeLabelIdOffset] = 0;
            }
            else
            {
                nativeLabelId = null;
            }
            
            void* nativeData = data.ToPointer();
            ImPlotLineFlags flags = 0;
            ImPlotNative.ImPlot_PlotLineG(nativeLabelId, getter, nativeData, count, flags);
            if (labelIdByteCount > Util.StackAllocationSizeLimit)
            {
                Util.Free(nativeLabelId);
            }
        }
        
        /// <summary>
        ///     Plots the line g using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="getter">The getter</param>
        /// <param name="data">The data</param>
        /// <param name="count">The count</param>
        /// <param name="flags">The flags</param>
        public static void PlotLineG(string labelId, IntPtr getter, IntPtr data, int count, ImPlotLineFlags flags)
        {
            byte* nativeLabelId;
            int labelIdByteCount = 0;
            if (labelId != null)
            {
                labelIdByteCount = Encoding.UTF8.GetByteCount(labelId);
                if (labelIdByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeLabelId = Util.Allocate(labelIdByteCount + 1);
                }
                else
                {
                    byte* nativeLabelIdStackBytes = stackalloc byte[labelIdByteCount + 1];
                    nativeLabelId = nativeLabelIdStackBytes;
                }
                
                int nativeLabelIdOffset = Util.GetUtf8(labelId, nativeLabelId, labelIdByteCount);
                nativeLabelId[nativeLabelIdOffset] = 0;
            }
            else
            {
                nativeLabelId = null;
            }
            
            void* nativeData = data.ToPointer();
            ImPlotNative.ImPlot_PlotLineG(nativeLabelId, getter, nativeData, count, flags);
            if (labelIdByteCount > Util.StackAllocationSizeLimit)
            {
                Util.Free(nativeLabelId);
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
        public static void PlotPieChart(string[] labelIds, ref float values, int count, double x, double y, double radius)
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
            fixed (float* nativeValues = &values)
            {
                ImPlotNative.ImPlot_PlotPieChart_FloatPtr(nativeLabelIds, nativeValues, count, x, y, radius, nativeLabelFmt, angle0, flags);
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
        public static void PlotPieChart(string[] labelIds, ref float values, int count, double x, double y, double radius, string labelFmt)
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
            fixed (float* nativeValues = &values)
            {
                ImPlotNative.ImPlot_PlotPieChart_FloatPtr(nativeLabelIds, nativeValues, count, x, y, radius, nativeLabelFmt, angle0, flags);
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
        public static void PlotPieChart(string[] labelIds, ref float values, int count, double x, double y, double radius, string labelFmt, double angle0)
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
            fixed (float* nativeValues = &values)
            {
                ImPlotNative.ImPlot_PlotPieChart_FloatPtr(nativeLabelIds, nativeValues, count, x, y, radius, nativeLabelFmt, angle0, flags);
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
        public static void PlotPieChart(string[] labelIds, ref float values, int count, double x, double y, double radius, string labelFmt, double angle0, ImPlotPieChartFlags flags)
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
            
            fixed (float* nativeValues = &values)
            {
                ImPlotNative.ImPlot_PlotPieChart_FloatPtr(nativeLabelIds, nativeValues, count, x, y, radius, nativeLabelFmt, angle0, flags);
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
        public static void PlotPieChart(string[] labelIds, ref double values, int count, double x, double y, double radius)
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
            fixed (double* nativeValues = &values)
            {
                ImPlotNative.ImPlot_PlotPieChart_doublePtr(nativeLabelIds, nativeValues, count, x, y, radius, nativeLabelFmt, angle0, flags);
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
        public static void PlotPieChart(string[] labelIds, ref double values, int count, double x, double y, double radius, string labelFmt)
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
            fixed (double* nativeValues = &values)
            {
                ImPlotNative.ImPlot_PlotPieChart_doublePtr(nativeLabelIds, nativeValues, count, x, y, radius, nativeLabelFmt, angle0, flags);
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
        public static void PlotPieChart(string[] labelIds, ref double values, int count, double x, double y, double radius, string labelFmt, double angle0)
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
            fixed (double* nativeValues = &values)
            {
                ImPlotNative.ImPlot_PlotPieChart_doublePtr(nativeLabelIds, nativeValues, count, x, y, radius, nativeLabelFmt, angle0, flags);
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
        public static void PlotPieChart(string[] labelIds, ref double values, int count, double x, double y, double radius, string labelFmt, double angle0, ImPlotPieChartFlags flags)
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
            
            fixed (double* nativeValues = &values)
            {
                ImPlotNative.ImPlot_PlotPieChart_doublePtr(nativeLabelIds, nativeValues, count, x, y, radius, nativeLabelFmt, angle0, flags);
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
        public static void PlotPieChart(string[] labelIds, ref sbyte values, int count, double x, double y, double radius)
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
            fixed (sbyte* nativeValues = &values)
            {
                ImPlotNative.ImPlot_PlotPieChart_S8Ptr(nativeLabelIds, nativeValues, count, x, y, radius, nativeLabelFmt, angle0, flags);
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
        public static void PlotPieChart(string[] labelIds, ref sbyte values, int count, double x, double y, double radius, string labelFmt)
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
            fixed (sbyte* nativeValues = &values)
            {
                ImPlotNative.ImPlot_PlotPieChart_S8Ptr(nativeLabelIds, nativeValues, count, x, y, radius, nativeLabelFmt, angle0, flags);
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
        public static void PlotPieChart(string[] labelIds, ref sbyte values, int count, double x, double y, double radius, string labelFmt, double angle0)
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
            fixed (sbyte* nativeValues = &values)
            {
                ImPlotNative.ImPlot_PlotPieChart_S8Ptr(nativeLabelIds, nativeValues, count, x, y, radius, nativeLabelFmt, angle0, flags);
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
        public static void PlotPieChart(string[] labelIds, ref sbyte values, int count, double x, double y, double radius, string labelFmt, double angle0, ImPlotPieChartFlags flags)
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
            
            fixed (sbyte* nativeValues = &values)
            {
                ImPlotNative.ImPlot_PlotPieChart_S8Ptr(nativeLabelIds, nativeValues, count, x, y, radius, nativeLabelFmt, angle0, flags);
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
        public static void PlotPieChart(string[] labelIds, ref byte values, int count, double x, double y, double radius)
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
            fixed (byte* nativeValues = &values)
            {
                ImPlotNative.ImPlot_PlotPieChart_U8Ptr(nativeLabelIds, nativeValues, count, x, y, radius, nativeLabelFmt, angle0, flags);
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
        public static void PlotPieChart(string[] labelIds, ref byte values, int count, double x, double y, double radius, string labelFmt)
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
            fixed (byte* nativeValues = &values)
            {
                ImPlotNative.ImPlot_PlotPieChart_U8Ptr(nativeLabelIds, nativeValues, count, x, y, radius, nativeLabelFmt, angle0, flags);
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
        public static void PlotPieChart(string[] labelIds, ref byte values, int count, double x, double y, double radius, string labelFmt, double angle0)
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
            fixed (byte* nativeValues = &values)
            {
                ImPlotNative.ImPlot_PlotPieChart_U8Ptr(nativeLabelIds, nativeValues, count, x, y, radius, nativeLabelFmt, angle0, flags);
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
        public static void PlotPieChart(string[] labelIds, ref byte values, int count, double x, double y, double radius, string labelFmt, double angle0, ImPlotPieChartFlags flags)
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
            
            fixed (byte* nativeValues = &values)
            {
                ImPlotNative.ImPlot_PlotPieChart_U8Ptr(nativeLabelIds, nativeValues, count, x, y, radius, nativeLabelFmt, angle0, flags);
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
        public static void PlotPieChart(string[] labelIds, ref short values, int count, double x, double y, double radius)
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
            fixed (short* nativeValues = &values)
            {
                ImPlotNative.ImPlot_PlotPieChart_S16Ptr(nativeLabelIds, nativeValues, count, x, y, radius, nativeLabelFmt, angle0, flags);
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
        public static void PlotPieChart(string[] labelIds, ref short values, int count, double x, double y, double radius, string labelFmt)
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
            fixed (short* nativeValues = &values)
            {
                ImPlotNative.ImPlot_PlotPieChart_S16Ptr(nativeLabelIds, nativeValues, count, x, y, radius, nativeLabelFmt, angle0, flags);
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
        public static void PlotPieChart(string[] labelIds, ref short values, int count, double x, double y, double radius, string labelFmt, double angle0)
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
            fixed (short* nativeValues = &values)
            {
                ImPlotNative.ImPlot_PlotPieChart_S16Ptr(nativeLabelIds, nativeValues, count, x, y, radius, nativeLabelFmt, angle0, flags);
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
        public static void PlotPieChart(string[] labelIds, ref short values, int count, double x, double y, double radius, string labelFmt, double angle0, ImPlotPieChartFlags flags)
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
            
            fixed (short* nativeValues = &values)
            {
                ImPlotNative.ImPlot_PlotPieChart_S16Ptr(nativeLabelIds, nativeValues, count, x, y, radius, nativeLabelFmt, angle0, flags);
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
        public static void PlotPieChart(string[] labelIds, ref ushort values, int count, double x, double y, double radius)
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
            fixed (ushort* nativeValues = &values)
            {
                ImPlotNative.ImPlot_PlotPieChart_U16Ptr(nativeLabelIds, nativeValues, count, x, y, radius, nativeLabelFmt, angle0, flags);
                if (labelFmtByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeLabelFmt);
                }
            }
        }
        
    }
}