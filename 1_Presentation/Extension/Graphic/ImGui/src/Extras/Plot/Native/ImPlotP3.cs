// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImPlotP3.cs
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
        ///     Plots the error bars using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="err">The err</param>
        /// <param name="count">The count</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        public static void PlotErrorBars(string labelId, ref float xs, ref float ys, ref float err, int count, ImPlotErrorBarsFlags flags, int offset)
        {
            byte* nativeLabelId;
            int labelIdByteCount = 0;
            if (labelId != null)
            {
                labelIdByteCount = Encoding.UTF8.GetByteCount(labelId);
                if (labelIdByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeLabelId = Util.Allocate(labelIdByteCount + 1);
                }
                else
                {
                    byte* nativeLabelIdStackBytes = stackalloc byte[labelIdByteCount + 1];
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
                    fixed (float* nativeErr = &err)
                    {
                        ImPlotNative.ImPlot_PlotErrorBars_FloatPtrFloatPtrFloatPtrInt(nativeLabelId, nativeXs, nativeYs, nativeErr, count, flags, offset, stride);
                        if (labelIdByteCount > Util.StackAllocationSizeLimit)
                        {
                            Util.Free(nativeLabelId);
                        }
                    }
                }
            }
        }
        
        /// <summary>
        ///     Plots the error bars using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="err">The err</param>
        /// <param name="count">The count</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        /// <param name="stride">The stride</param>
        public static void PlotErrorBars(string labelId, ref float xs, ref float ys, ref float err, int count, ImPlotErrorBarsFlags flags, int offset, int stride)
        {
            byte* nativeLabelId;
            int labelIdByteCount = 0;
            if (labelId != null)
            {
                labelIdByteCount = Encoding.UTF8.GetByteCount(labelId);
                if (labelIdByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeLabelId = Util.Allocate(labelIdByteCount + 1);
                }
                else
                {
                    byte* nativeLabelIdStackBytes = stackalloc byte[labelIdByteCount + 1];
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
                    fixed (float* nativeErr = &err)
                    {
                        ImPlotNative.ImPlot_PlotErrorBars_FloatPtrFloatPtrFloatPtrInt(nativeLabelId, nativeXs, nativeYs, nativeErr, count, flags, offset, stride);
                        if (labelIdByteCount > Util.StackAllocationSizeLimit)
                        {
                            Util.Free(nativeLabelId);
                        }
                    }
                }
            }
        }
        
        /// <summary>
        ///     Plots the error bars using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="err">The err</param>
        /// <param name="count">The count</param>
        public static void PlotErrorBars(string labelId, ref double xs, ref double ys, ref double err, int count)
        {
            byte* nativeLabelId;
            int labelIdByteCount = 0;
            if (labelId != null)
            {
                labelIdByteCount = Encoding.UTF8.GetByteCount(labelId);
                if (labelIdByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeLabelId = Util.Allocate(labelIdByteCount + 1);
                }
                else
                {
                    byte* nativeLabelIdStackBytes = stackalloc byte[labelIdByteCount + 1];
                    nativeLabelId = nativeLabelIdStackBytes;
                }
                
                int nativeLabelIdOffset = Util.GetUtf8(labelId, nativeLabelId, labelIdByteCount);
                nativeLabelId[nativeLabelIdOffset] = 0;
            }
            else
            {
                nativeLabelId = null;
            }
            
            ImPlotErrorBarsFlags flags = 0;
            int offset = 0;
            int stride = sizeof(double);
            fixed (double* nativeXs = &xs)
            {
                fixed (double* nativeYs = &ys)
                {
                    fixed (double* nativeErr = &err)
                    {
                        ImPlotNative.ImPlot_PlotErrorBars_doublePtrdoublePtrdoublePtrInt(nativeLabelId, nativeXs, nativeYs, nativeErr, count, flags, offset, stride);
                        if (labelIdByteCount > Util.StackAllocationSizeLimit)
                        {
                            Util.Free(nativeLabelId);
                        }
                    }
                }
            }
        }
        
        /// <summary>
        ///     Plots the error bars using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="err">The err</param>
        /// <param name="count">The count</param>
        /// <param name="flags">The flags</param>
        public static void PlotErrorBars(string labelId, ref double xs, ref double ys, ref double err, int count, ImPlotErrorBarsFlags flags)
        {
            byte* nativeLabelId;
            int labelIdByteCount = 0;
            if (labelId != null)
            {
                labelIdByteCount = Encoding.UTF8.GetByteCount(labelId);
                if (labelIdByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeLabelId = Util.Allocate(labelIdByteCount + 1);
                }
                else
                {
                    byte* nativeLabelIdStackBytes = stackalloc byte[labelIdByteCount + 1];
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
                    fixed (double* nativeErr = &err)
                    {
                        ImPlotNative.ImPlot_PlotErrorBars_doublePtrdoublePtrdoublePtrInt(nativeLabelId, nativeXs, nativeYs, nativeErr, count, flags, offset, stride);
                        if (labelIdByteCount > Util.StackAllocationSizeLimit)
                        {
                            Util.Free(nativeLabelId);
                        }
                    }
                }
            }
        }
        
        /// <summary>
        ///     Plots the error bars using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="err">The err</param>
        /// <param name="count">The count</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        public static void PlotErrorBars(string labelId, ref double xs, ref double ys, ref double err, int count, ImPlotErrorBarsFlags flags, int offset)
        {
            byte* nativeLabelId;
            int labelIdByteCount = 0;
            if (labelId != null)
            {
                labelIdByteCount = Encoding.UTF8.GetByteCount(labelId);
                if (labelIdByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeLabelId = Util.Allocate(labelIdByteCount + 1);
                }
                else
                {
                    byte* nativeLabelIdStackBytes = stackalloc byte[labelIdByteCount + 1];
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
                    fixed (double* nativeErr = &err)
                    {
                        ImPlotNative.ImPlot_PlotErrorBars_doublePtrdoublePtrdoublePtrInt(nativeLabelId, nativeXs, nativeYs, nativeErr, count, flags, offset, stride);
                        if (labelIdByteCount > Util.StackAllocationSizeLimit)
                        {
                            Util.Free(nativeLabelId);
                        }
                    }
                }
            }
        }
        
        /// <summary>
        ///     Plots the error bars using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="err">The err</param>
        /// <param name="count">The count</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        /// <param name="stride">The stride</param>
        public static void PlotErrorBars(string labelId, ref double xs, ref double ys, ref double err, int count, ImPlotErrorBarsFlags flags, int offset, int stride)
        {
            byte* nativeLabelId;
            int labelIdByteCount = 0;
            if (labelId != null)
            {
                labelIdByteCount = Encoding.UTF8.GetByteCount(labelId);
                if (labelIdByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeLabelId = Util.Allocate(labelIdByteCount + 1);
                }
                else
                {
                    byte* nativeLabelIdStackBytes = stackalloc byte[labelIdByteCount + 1];
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
                    fixed (double* nativeErr = &err)
                    {
                        ImPlotNative.ImPlot_PlotErrorBars_doublePtrdoublePtrdoublePtrInt(nativeLabelId, nativeXs, nativeYs, nativeErr, count, flags, offset, stride);
                        if (labelIdByteCount > Util.StackAllocationSizeLimit)
                        {
                            Util.Free(nativeLabelId);
                        }
                    }
                }
            }
        }
        
        /// <summary>
        ///     Plots the error bars using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="err">The err</param>
        /// <param name="count">The count</param>
        public static void PlotErrorBars(string labelId, ref sbyte xs, ref sbyte ys, ref sbyte err, int count)
        {
            byte* nativeLabelId;
            int labelIdByteCount = 0;
            if (labelId != null)
            {
                labelIdByteCount = Encoding.UTF8.GetByteCount(labelId);
                if (labelIdByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeLabelId = Util.Allocate(labelIdByteCount + 1);
                }
                else
                {
                    byte* nativeLabelIdStackBytes = stackalloc byte[labelIdByteCount + 1];
                    nativeLabelId = nativeLabelIdStackBytes;
                }
                
                int nativeLabelIdOffset = Util.GetUtf8(labelId, nativeLabelId, labelIdByteCount);
                nativeLabelId[nativeLabelIdOffset] = 0;
            }
            else
            {
                nativeLabelId = null;
            }
            
            ImPlotErrorBarsFlags flags = 0;
            int offset = 0;
            int stride = sizeof(sbyte);
            fixed (sbyte* nativeXs = &xs)
            {
                fixed (sbyte* nativeYs = &ys)
                {
                    fixed (sbyte* nativeErr = &err)
                    {
                        ImPlotNative.ImPlot_PlotErrorBars_S8PtrS8PtrS8PtrInt(nativeLabelId, nativeXs, nativeYs, nativeErr, count, flags, offset, stride);
                        if (labelIdByteCount > Util.StackAllocationSizeLimit)
                        {
                            Util.Free(nativeLabelId);
                        }
                    }
                }
            }
        }
        
        /// <summary>
        ///     Plots the error bars using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="err">The err</param>
        /// <param name="count">The count</param>
        /// <param name="flags">The flags</param>
        public static void PlotErrorBars(string labelId, ref sbyte xs, ref sbyte ys, ref sbyte err, int count, ImPlotErrorBarsFlags flags)
        {
            byte* nativeLabelId;
            int labelIdByteCount = 0;
            if (labelId != null)
            {
                labelIdByteCount = Encoding.UTF8.GetByteCount(labelId);
                if (labelIdByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeLabelId = Util.Allocate(labelIdByteCount + 1);
                }
                else
                {
                    byte* nativeLabelIdStackBytes = stackalloc byte[labelIdByteCount + 1];
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
                    fixed (sbyte* nativeErr = &err)
                    {
                        ImPlotNative.ImPlot_PlotErrorBars_S8PtrS8PtrS8PtrInt(nativeLabelId, nativeXs, nativeYs, nativeErr, count, flags, offset, stride);
                        if (labelIdByteCount > Util.StackAllocationSizeLimit)
                        {
                            Util.Free(nativeLabelId);
                        }
                    }
                }
            }
        }
        
        /// <summary>
        ///     Plots the error bars using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="err">The err</param>
        /// <param name="count">The count</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        public static void PlotErrorBars(string labelId, ref sbyte xs, ref sbyte ys, ref sbyte err, int count, ImPlotErrorBarsFlags flags, int offset)
        {
            byte* nativeLabelId;
            int labelIdByteCount = 0;
            if (labelId != null)
            {
                labelIdByteCount = Encoding.UTF8.GetByteCount(labelId);
                if (labelIdByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeLabelId = Util.Allocate(labelIdByteCount + 1);
                }
                else
                {
                    byte* nativeLabelIdStackBytes = stackalloc byte[labelIdByteCount + 1];
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
                    fixed (sbyte* nativeErr = &err)
                    {
                        ImPlotNative.ImPlot_PlotErrorBars_S8PtrS8PtrS8PtrInt(nativeLabelId, nativeXs, nativeYs, nativeErr, count, flags, offset, stride);
                        if (labelIdByteCount > Util.StackAllocationSizeLimit)
                        {
                            Util.Free(nativeLabelId);
                        }
                    }
                }
            }
        }
        
        /// <summary>
        ///     Plots the error bars using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="err">The err</param>
        /// <param name="count">The count</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        /// <param name="stride">The stride</param>
        public static void PlotErrorBars(string labelId, ref sbyte xs, ref sbyte ys, ref sbyte err, int count, ImPlotErrorBarsFlags flags, int offset, int stride)
        {
            byte* nativeLabelId;
            int labelIdByteCount = 0;
            if (labelId != null)
            {
                labelIdByteCount = Encoding.UTF8.GetByteCount(labelId);
                if (labelIdByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeLabelId = Util.Allocate(labelIdByteCount + 1);
                }
                else
                {
                    byte* nativeLabelIdStackBytes = stackalloc byte[labelIdByteCount + 1];
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
                    fixed (sbyte* nativeErr = &err)
                    {
                        ImPlotNative.ImPlot_PlotErrorBars_S8PtrS8PtrS8PtrInt(nativeLabelId, nativeXs, nativeYs, nativeErr, count, flags, offset, stride);
                        if (labelIdByteCount > Util.StackAllocationSizeLimit)
                        {
                            Util.Free(nativeLabelId);
                        }
                    }
                }
            }
        }
        
        /// <summary>
        ///     Plots the error bars using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="err">The err</param>
        /// <param name="count">The count</param>
        public static void PlotErrorBars(string labelId, ref byte xs, ref byte ys, ref byte err, int count)
        {
            byte* nativeLabelId;
            int labelIdByteCount = 0;
            if (labelId != null)
            {
                labelIdByteCount = Encoding.UTF8.GetByteCount(labelId);
                if (labelIdByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeLabelId = Util.Allocate(labelIdByteCount + 1);
                }
                else
                {
                    byte* nativeLabelIdStackBytes = stackalloc byte[labelIdByteCount + 1];
                    nativeLabelId = nativeLabelIdStackBytes;
                }
                
                int nativeLabelIdOffset = Util.GetUtf8(labelId, nativeLabelId, labelIdByteCount);
                nativeLabelId[nativeLabelIdOffset] = 0;
            }
            else
            {
                nativeLabelId = null;
            }
            
            ImPlotErrorBarsFlags flags = 0;
            int offset = 0;
            int stride = sizeof(byte);
            fixed (byte* nativeXs = &xs)
            {
                fixed (byte* nativeYs = &ys)
                {
                    fixed (byte* nativeErr = &err)
                    {
                        ImPlotNative.ImPlot_PlotErrorBars_U8PtrU8PtrU8PtrInt(nativeLabelId, nativeXs, nativeYs, nativeErr, count, flags, offset, stride);
                        if (labelIdByteCount > Util.StackAllocationSizeLimit)
                        {
                            Util.Free(nativeLabelId);
                        }
                    }
                }
            }
        }
        
        /// <summary>
        ///     Plots the error bars using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="err">The err</param>
        /// <param name="count">The count</param>
        /// <param name="flags">The flags</param>
        public static void PlotErrorBars(string labelId, ref byte xs, ref byte ys, ref byte err, int count, ImPlotErrorBarsFlags flags)
        {
            byte* nativeLabelId;
            int labelIdByteCount = 0;
            if (labelId != null)
            {
                labelIdByteCount = Encoding.UTF8.GetByteCount(labelId);
                if (labelIdByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeLabelId = Util.Allocate(labelIdByteCount + 1);
                }
                else
                {
                    byte* nativeLabelIdStackBytes = stackalloc byte[labelIdByteCount + 1];
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
                    fixed (byte* nativeErr = &err)
                    {
                        ImPlotNative.ImPlot_PlotErrorBars_U8PtrU8PtrU8PtrInt(nativeLabelId, nativeXs, nativeYs, nativeErr, count, flags, offset, stride);
                        if (labelIdByteCount > Util.StackAllocationSizeLimit)
                        {
                            Util.Free(nativeLabelId);
                        }
                    }
                }
            }
        }
        
        /// <summary>
        ///     Plots the error bars using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="err">The err</param>
        /// <param name="count">The count</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        public static void PlotErrorBars(string labelId, ref byte xs, ref byte ys, ref byte err, int count, ImPlotErrorBarsFlags flags, int offset)
        {
            byte* nativeLabelId;
            int labelIdByteCount = 0;
            if (labelId != null)
            {
                labelIdByteCount = Encoding.UTF8.GetByteCount(labelId);
                if (labelIdByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeLabelId = Util.Allocate(labelIdByteCount + 1);
                }
                else
                {
                    byte* nativeLabelIdStackBytes = stackalloc byte[labelIdByteCount + 1];
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
                    fixed (byte* nativeErr = &err)
                    {
                        ImPlotNative.ImPlot_PlotErrorBars_U8PtrU8PtrU8PtrInt(nativeLabelId, nativeXs, nativeYs, nativeErr, count, flags, offset, stride);
                        if (labelIdByteCount > Util.StackAllocationSizeLimit)
                        {
                            Util.Free(nativeLabelId);
                        }
                    }
                }
            }
        }
        
        /// <summary>
        ///     Plots the error bars using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="err">The err</param>
        /// <param name="count">The count</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        /// <param name="stride">The stride</param>
        public static void PlotErrorBars(string labelId, ref byte xs, ref byte ys, ref byte err, int count, ImPlotErrorBarsFlags flags, int offset, int stride)
        {
            byte* nativeLabelId;
            int labelIdByteCount = 0;
            if (labelId != null)
            {
                labelIdByteCount = Encoding.UTF8.GetByteCount(labelId);
                if (labelIdByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeLabelId = Util.Allocate(labelIdByteCount + 1);
                }
                else
                {
                    byte* nativeLabelIdStackBytes = stackalloc byte[labelIdByteCount + 1];
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
                    fixed (byte* nativeErr = &err)
                    {
                        ImPlotNative.ImPlot_PlotErrorBars_U8PtrU8PtrU8PtrInt(nativeLabelId, nativeXs, nativeYs, nativeErr, count, flags, offset, stride);
                        if (labelIdByteCount > Util.StackAllocationSizeLimit)
                        {
                            Util.Free(nativeLabelId);
                        }
                    }
                }
            }
        }
        
        /// <summary>
        ///     Plots the error bars using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="err">The err</param>
        /// <param name="count">The count</param>
        public static void PlotErrorBars(string labelId, ref short xs, ref short ys, ref short err, int count)
        {
            byte* nativeLabelId;
            int labelIdByteCount = 0;
            if (labelId != null)
            {
                labelIdByteCount = Encoding.UTF8.GetByteCount(labelId);
                if (labelIdByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeLabelId = Util.Allocate(labelIdByteCount + 1);
                }
                else
                {
                    byte* nativeLabelIdStackBytes = stackalloc byte[labelIdByteCount + 1];
                    nativeLabelId = nativeLabelIdStackBytes;
                }
                
                int nativeLabelIdOffset = Util.GetUtf8(labelId, nativeLabelId, labelIdByteCount);
                nativeLabelId[nativeLabelIdOffset] = 0;
            }
            else
            {
                nativeLabelId = null;
            }
            
            ImPlotErrorBarsFlags flags = 0;
            int offset = 0;
            int stride = sizeof(short);
            fixed (short* nativeXs = &xs)
            {
                fixed (short* nativeYs = &ys)
                {
                    fixed (short* nativeErr = &err)
                    {
                        ImPlotNative.ImPlot_PlotErrorBars_S16PtrS16PtrS16PtrInt(nativeLabelId, nativeXs, nativeYs, nativeErr, count, flags, offset, stride);
                        if (labelIdByteCount > Util.StackAllocationSizeLimit)
                        {
                            Util.Free(nativeLabelId);
                        }
                    }
                }
            }
        }
        
        /// <summary>
        ///     Plots the error bars using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="err">The err</param>
        /// <param name="count">The count</param>
        /// <param name="flags">The flags</param>
        public static void PlotErrorBars(string labelId, ref short xs, ref short ys, ref short err, int count, ImPlotErrorBarsFlags flags)
        {
            byte* nativeLabelId;
            int labelIdByteCount = 0;
            if (labelId != null)
            {
                labelIdByteCount = Encoding.UTF8.GetByteCount(labelId);
                if (labelIdByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeLabelId = Util.Allocate(labelIdByteCount + 1);
                }
                else
                {
                    byte* nativeLabelIdStackBytes = stackalloc byte[labelIdByteCount + 1];
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
                    fixed (short* nativeErr = &err)
                    {
                        ImPlotNative.ImPlot_PlotErrorBars_S16PtrS16PtrS16PtrInt(nativeLabelId, nativeXs, nativeYs, nativeErr, count, flags, offset, stride);
                        if (labelIdByteCount > Util.StackAllocationSizeLimit)
                        {
                            Util.Free(nativeLabelId);
                        }
                    }
                }
            }
        }
        
        /// <summary>
        ///     Plots the error bars using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="err">The err</param>
        /// <param name="count">The count</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        public static void PlotErrorBars(string labelId, ref short xs, ref short ys, ref short err, int count, ImPlotErrorBarsFlags flags, int offset)
        {
            byte* nativeLabelId;
            int labelIdByteCount = 0;
            if (labelId != null)
            {
                labelIdByteCount = Encoding.UTF8.GetByteCount(labelId);
                if (labelIdByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeLabelId = Util.Allocate(labelIdByteCount + 1);
                }
                else
                {
                    byte* nativeLabelIdStackBytes = stackalloc byte[labelIdByteCount + 1];
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
                    fixed (short* nativeErr = &err)
                    {
                        ImPlotNative.ImPlot_PlotErrorBars_S16PtrS16PtrS16PtrInt(nativeLabelId, nativeXs, nativeYs, nativeErr, count, flags, offset, stride);
                        if (labelIdByteCount > Util.StackAllocationSizeLimit)
                        {
                            Util.Free(nativeLabelId);
                        }
                    }
                }
            }
        }
        
        /// <summary>
        ///     Plots the error bars using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="err">The err</param>
        /// <param name="count">The count</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        /// <param name="stride">The stride</param>
        public static void PlotErrorBars(string labelId, ref short xs, ref short ys, ref short err, int count, ImPlotErrorBarsFlags flags, int offset, int stride)
        {
            byte* nativeLabelId;
            int labelIdByteCount = 0;
            if (labelId != null)
            {
                labelIdByteCount = Encoding.UTF8.GetByteCount(labelId);
                if (labelIdByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeLabelId = Util.Allocate(labelIdByteCount + 1);
                }
                else
                {
                    byte* nativeLabelIdStackBytes = stackalloc byte[labelIdByteCount + 1];
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
                    fixed (short* nativeErr = &err)
                    {
                        ImPlotNative.ImPlot_PlotErrorBars_S16PtrS16PtrS16PtrInt(nativeLabelId, nativeXs, nativeYs, nativeErr, count, flags, offset, stride);
                        if (labelIdByteCount > Util.StackAllocationSizeLimit)
                        {
                            Util.Free(nativeLabelId);
                        }
                    }
                }
            }
        }
        
        /// <summary>
        ///     Plots the error bars using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="err">The err</param>
        /// <param name="count">The count</param>
        public static void PlotErrorBars(string labelId, ref ushort xs, ref ushort ys, ref ushort err, int count)
        {
            byte* nativeLabelId;
            int labelIdByteCount = 0;
            if (labelId != null)
            {
                labelIdByteCount = Encoding.UTF8.GetByteCount(labelId);
                if (labelIdByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeLabelId = Util.Allocate(labelIdByteCount + 1);
                }
                else
                {
                    byte* nativeLabelIdStackBytes = stackalloc byte[labelIdByteCount + 1];
                    nativeLabelId = nativeLabelIdStackBytes;
                }
                
                int nativeLabelIdOffset = Util.GetUtf8(labelId, nativeLabelId, labelIdByteCount);
                nativeLabelId[nativeLabelIdOffset] = 0;
            }
            else
            {
                nativeLabelId = null;
            }
            
            ImPlotErrorBarsFlags flags = 0;
            int offset = 0;
            int stride = sizeof(ushort);
            fixed (ushort* nativeXs = &xs)
            {
                fixed (ushort* nativeYs = &ys)
                {
                    fixed (ushort* nativeErr = &err)
                    {
                        ImPlotNative.ImPlot_PlotErrorBars_U16PtrU16PtrU16PtrInt(nativeLabelId, nativeXs, nativeYs, nativeErr, count, flags, offset, stride);
                        if (labelIdByteCount > Util.StackAllocationSizeLimit)
                        {
                            Util.Free(nativeLabelId);
                        }
                    }
                }
            }
        }
        
        /// <summary>
        ///     Plots the error bars using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="err">The err</param>
        /// <param name="count">The count</param>
        /// <param name="flags">The flags</param>
        public static void PlotErrorBars(string labelId, ref ushort xs, ref ushort ys, ref ushort err, int count, ImPlotErrorBarsFlags flags)
        {
            byte* nativeLabelId;
            int labelIdByteCount = 0;
            if (labelId != null)
            {
                labelIdByteCount = Encoding.UTF8.GetByteCount(labelId);
                if (labelIdByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeLabelId = Util.Allocate(labelIdByteCount + 1);
                }
                else
                {
                    byte* nativeLabelIdStackBytes = stackalloc byte[labelIdByteCount + 1];
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
            fixed (ushort* nativeXs = &xs)
            {
                fixed (ushort* nativeYs = &ys)
                {
                    fixed (ushort* nativeErr = &err)
                    {
                        ImPlotNative.ImPlot_PlotErrorBars_U16PtrU16PtrU16PtrInt(nativeLabelId, nativeXs, nativeYs, nativeErr, count, flags, offset, stride);
                        if (labelIdByteCount > Util.StackAllocationSizeLimit)
                        {
                            Util.Free(nativeLabelId);
                        }
                    }
                }
            }
        }
        
        /// <summary>
        ///     Plots the error bars using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="err">The err</param>
        /// <param name="count">The count</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        public static void PlotErrorBars(string labelId, ref ushort xs, ref ushort ys, ref ushort err, int count, ImPlotErrorBarsFlags flags, int offset)
        {
            byte* nativeLabelId;
            int labelIdByteCount = 0;
            if (labelId != null)
            {
                labelIdByteCount = Encoding.UTF8.GetByteCount(labelId);
                if (labelIdByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeLabelId = Util.Allocate(labelIdByteCount + 1);
                }
                else
                {
                    byte* nativeLabelIdStackBytes = stackalloc byte[labelIdByteCount + 1];
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
            fixed (ushort* nativeXs = &xs)
            {
                fixed (ushort* nativeYs = &ys)
                {
                    fixed (ushort* nativeErr = &err)
                    {
                        ImPlotNative.ImPlot_PlotErrorBars_U16PtrU16PtrU16PtrInt(nativeLabelId, nativeXs, nativeYs, nativeErr, count, flags, offset, stride);
                        if (labelIdByteCount > Util.StackAllocationSizeLimit)
                        {
                            Util.Free(nativeLabelId);
                        }
                    }
                }
            }
        }
        
        /// <summary>
        ///     Plots the error bars using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="err">The err</param>
        /// <param name="count">The count</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        /// <param name="stride">The stride</param>
        public static void PlotErrorBars(string labelId, ref ushort xs, ref ushort ys, ref ushort err, int count, ImPlotErrorBarsFlags flags, int offset, int stride)
        {
            byte* nativeLabelId;
            int labelIdByteCount = 0;
            if (labelId != null)
            {
                labelIdByteCount = Encoding.UTF8.GetByteCount(labelId);
                if (labelIdByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeLabelId = Util.Allocate(labelIdByteCount + 1);
                }
                else
                {
                    byte* nativeLabelIdStackBytes = stackalloc byte[labelIdByteCount + 1];
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
                    fixed (ushort* nativeErr = &err)
                    {
                        ImPlotNative.ImPlot_PlotErrorBars_U16PtrU16PtrU16PtrInt(nativeLabelId, nativeXs, nativeYs, nativeErr, count, flags, offset, stride);
                        if (labelIdByteCount > Util.StackAllocationSizeLimit)
                        {
                            Util.Free(nativeLabelId);
                        }
                    }
                }
            }
        }
        
        /// <summary>
        ///     Plots the error bars using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="err">The err</param>
        /// <param name="count">The count</param>
        public static void PlotErrorBars(string labelId, ref int xs, ref int ys, ref int err, int count)
        {
            byte* nativeLabelId;
            int labelIdByteCount = 0;
            if (labelId != null)
            {
                labelIdByteCount = Encoding.UTF8.GetByteCount(labelId);
                if (labelIdByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeLabelId = Util.Allocate(labelIdByteCount + 1);
                }
                else
                {
                    byte* nativeLabelIdStackBytes = stackalloc byte[labelIdByteCount + 1];
                    nativeLabelId = nativeLabelIdStackBytes;
                }
                
                int nativeLabelIdOffset = Util.GetUtf8(labelId, nativeLabelId, labelIdByteCount);
                nativeLabelId[nativeLabelIdOffset] = 0;
            }
            else
            {
                nativeLabelId = null;
            }
            
            ImPlotErrorBarsFlags flags = 0;
            int offset = 0;
            int stride = sizeof(int);
            fixed (int* nativeXs = &xs)
            {
                fixed (int* nativeYs = &ys)
                {
                    fixed (int* nativeErr = &err)
                    {
                        ImPlotNative.ImPlot_PlotErrorBars_S32PtrS32PtrS32PtrInt(nativeLabelId, nativeXs, nativeYs, nativeErr, count, flags, offset, stride);
                        if (labelIdByteCount > Util.StackAllocationSizeLimit)
                        {
                            Util.Free(nativeLabelId);
                        }
                    }
                }
            }
        }
        
        /// <summary>
        ///     Plots the error bars using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="err">The err</param>
        /// <param name="count">The count</param>
        /// <param name="flags">The flags</param>
        public static void PlotErrorBars(string labelId, ref int xs, ref int ys, ref int err, int count, ImPlotErrorBarsFlags flags)
        {
            byte* nativeLabelId;
            int labelIdByteCount = 0;
            if (labelId != null)
            {
                labelIdByteCount = Encoding.UTF8.GetByteCount(labelId);
                if (labelIdByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeLabelId = Util.Allocate(labelIdByteCount + 1);
                }
                else
                {
                    byte* nativeLabelIdStackBytes = stackalloc byte[labelIdByteCount + 1];
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
                    fixed (int* nativeErr = &err)
                    {
                        ImPlotNative.ImPlot_PlotErrorBars_S32PtrS32PtrS32PtrInt(nativeLabelId, nativeXs, nativeYs, nativeErr, count, flags, offset, stride);
                        if (labelIdByteCount > Util.StackAllocationSizeLimit)
                        {
                            Util.Free(nativeLabelId);
                        }
                    }
                }
            }
        }
        
        /// <summary>
        ///     Plots the error bars using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="err">The err</param>
        /// <param name="count">The count</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        public static void PlotErrorBars(string labelId, ref int xs, ref int ys, ref int err, int count, ImPlotErrorBarsFlags flags, int offset)
        {
            byte* nativeLabelId;
            int labelIdByteCount = 0;
            if (labelId != null)
            {
                labelIdByteCount = Encoding.UTF8.GetByteCount(labelId);
                if (labelIdByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeLabelId = Util.Allocate(labelIdByteCount + 1);
                }
                else
                {
                    byte* nativeLabelIdStackBytes = stackalloc byte[labelIdByteCount + 1];
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
                    fixed (int* nativeErr = &err)
                    {
                        ImPlotNative.ImPlot_PlotErrorBars_S32PtrS32PtrS32PtrInt(nativeLabelId, nativeXs, nativeYs, nativeErr, count, flags, offset, stride);
                        if (labelIdByteCount > Util.StackAllocationSizeLimit)
                        {
                            Util.Free(nativeLabelId);
                        }
                    }
                }
            }
        }
        
        /// <summary>
        ///     Plots the error bars using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="err">The err</param>
        /// <param name="count">The count</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        /// <param name="stride">The stride</param>
        public static void PlotErrorBars(string labelId, ref int xs, ref int ys, ref int err, int count, ImPlotErrorBarsFlags flags, int offset, int stride)
        {
            byte* nativeLabelId;
            int labelIdByteCount = 0;
            if (labelId != null)
            {
                labelIdByteCount = Encoding.UTF8.GetByteCount(labelId);
                if (labelIdByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeLabelId = Util.Allocate(labelIdByteCount + 1);
                }
                else
                {
                    byte* nativeLabelIdStackBytes = stackalloc byte[labelIdByteCount + 1];
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
                    fixed (int* nativeErr = &err)
                    {
                        ImPlotNative.ImPlot_PlotErrorBars_S32PtrS32PtrS32PtrInt(nativeLabelId, nativeXs, nativeYs, nativeErr, count, flags, offset, stride);
                        if (labelIdByteCount > Util.StackAllocationSizeLimit)
                        {
                            Util.Free(nativeLabelId);
                        }
                    }
                }
            }
        }
        
        /// <summary>
        ///     Plots the error bars using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="err">The err</param>
        /// <param name="count">The count</param>
        public static void PlotErrorBars(string labelId, ref uint xs, ref uint ys, ref uint err, int count)
        {
            byte* nativeLabelId;
            int labelIdByteCount = 0;
            if (labelId != null)
            {
                labelIdByteCount = Encoding.UTF8.GetByteCount(labelId);
                if (labelIdByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeLabelId = Util.Allocate(labelIdByteCount + 1);
                }
                else
                {
                    byte* nativeLabelIdStackBytes = stackalloc byte[labelIdByteCount + 1];
                    nativeLabelId = nativeLabelIdStackBytes;
                }
                
                int nativeLabelIdOffset = Util.GetUtf8(labelId, nativeLabelId, labelIdByteCount);
                nativeLabelId[nativeLabelIdOffset] = 0;
            }
            else
            {
                nativeLabelId = null;
            }
            
            ImPlotErrorBarsFlags flags = 0;
            int offset = 0;
            int stride = sizeof(uint);
            fixed (uint* nativeXs = &xs)
            {
                fixed (uint* nativeYs = &ys)
                {
                    fixed (uint* nativeErr = &err)
                    {
                        ImPlotNative.ImPlot_PlotErrorBars_U32PtrU32PtrU32PtrInt(nativeLabelId, nativeXs, nativeYs, nativeErr, count, flags, offset, stride);
                        if (labelIdByteCount > Util.StackAllocationSizeLimit)
                        {
                            Util.Free(nativeLabelId);
                        }
                    }
                }
            }
        }
        
        /// <summary>
        ///     Plots the error bars using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="err">The err</param>
        /// <param name="count">The count</param>
        /// <param name="flags">The flags</param>
        public static void PlotErrorBars(string labelId, ref uint xs, ref uint ys, ref uint err, int count, ImPlotErrorBarsFlags flags)
        {
            byte* nativeLabelId;
            int labelIdByteCount = 0;
            if (labelId != null)
            {
                labelIdByteCount = Encoding.UTF8.GetByteCount(labelId);
                if (labelIdByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeLabelId = Util.Allocate(labelIdByteCount + 1);
                }
                else
                {
                    byte* nativeLabelIdStackBytes = stackalloc byte[labelIdByteCount + 1];
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
                    fixed (uint* nativeErr = &err)
                    {
                        ImPlotNative.ImPlot_PlotErrorBars_U32PtrU32PtrU32PtrInt(nativeLabelId, nativeXs, nativeYs, nativeErr, count, flags, offset, stride);
                        if (labelIdByteCount > Util.StackAllocationSizeLimit)
                        {
                            Util.Free(nativeLabelId);
                        }
                    }
                }
            }
        }
        
        /// <summary>
        ///     Plots the error bars using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="err">The err</param>
        /// <param name="count">The count</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        public static void PlotErrorBars(string labelId, ref uint xs, ref uint ys, ref uint err, int count, ImPlotErrorBarsFlags flags, int offset)
        {
            byte* nativeLabelId;
            int labelIdByteCount = 0;
            if (labelId != null)
            {
                labelIdByteCount = Encoding.UTF8.GetByteCount(labelId);
                if (labelIdByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeLabelId = Util.Allocate(labelIdByteCount + 1);
                }
                else
                {
                    byte* nativeLabelIdStackBytes = stackalloc byte[labelIdByteCount + 1];
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
                    fixed (uint* nativeErr = &err)
                    {
                        ImPlotNative.ImPlot_PlotErrorBars_U32PtrU32PtrU32PtrInt(nativeLabelId, nativeXs, nativeYs, nativeErr, count, flags, offset, stride);
                        if (labelIdByteCount > Util.StackAllocationSizeLimit)
                        {
                            Util.Free(nativeLabelId);
                        }
                    }
                }
            }
        }
        
        /// <summary>
        ///     Plots the error bars using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="err">The err</param>
        /// <param name="count">The count</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        /// <param name="stride">The stride</param>
        public static void PlotErrorBars(string labelId, ref uint xs, ref uint ys, ref uint err, int count, ImPlotErrorBarsFlags flags, int offset, int stride)
        {
            byte* nativeLabelId;
            int labelIdByteCount = 0;
            if (labelId != null)
            {
                labelIdByteCount = Encoding.UTF8.GetByteCount(labelId);
                if (labelIdByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeLabelId = Util.Allocate(labelIdByteCount + 1);
                }
                else
                {
                    byte* nativeLabelIdStackBytes = stackalloc byte[labelIdByteCount + 1];
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
                    fixed (uint* nativeErr = &err)
                    {
                        ImPlotNative.ImPlot_PlotErrorBars_U32PtrU32PtrU32PtrInt(nativeLabelId, nativeXs, nativeYs, nativeErr, count, flags, offset, stride);
                        if (labelIdByteCount > Util.StackAllocationSizeLimit)
                        {
                            Util.Free(nativeLabelId);
                        }
                    }
                }
            }
        }
        
        /// <summary>
        ///     Plots the error bars using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="err">The err</param>
        /// <param name="count">The count</param>
        public static void PlotErrorBars(string labelId, ref long xs, ref long ys, ref long err, int count)
        {
            byte* nativeLabelId;
            int labelIdByteCount = 0;
            if (labelId != null)
            {
                labelIdByteCount = Encoding.UTF8.GetByteCount(labelId);
                if (labelIdByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeLabelId = Util.Allocate(labelIdByteCount + 1);
                }
                else
                {
                    byte* nativeLabelIdStackBytes = stackalloc byte[labelIdByteCount + 1];
                    nativeLabelId = nativeLabelIdStackBytes;
                }
                
                int nativeLabelIdOffset = Util.GetUtf8(labelId, nativeLabelId, labelIdByteCount);
                nativeLabelId[nativeLabelIdOffset] = 0;
            }
            else
            {
                nativeLabelId = null;
            }
            
            ImPlotErrorBarsFlags flags = 0;
            int offset = 0;
            int stride = sizeof(long);
            fixed (long* nativeXs = &xs)
            {
                fixed (long* nativeYs = &ys)
                {
                    fixed (long* nativeErr = &err)
                    {
                        ImPlotNative.ImPlot_PlotErrorBars_S64PtrS64PtrS64PtrInt(nativeLabelId, nativeXs, nativeYs, nativeErr, count, flags, offset, stride);
                        if (labelIdByteCount > Util.StackAllocationSizeLimit)
                        {
                            Util.Free(nativeLabelId);
                        }
                    }
                }
            }
        }
        
        /// <summary>
        ///     Plots the error bars using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="err">The err</param>
        /// <param name="count">The count</param>
        /// <param name="flags">The flags</param>
        public static void PlotErrorBars(string labelId, ref long xs, ref long ys, ref long err, int count, ImPlotErrorBarsFlags flags)
        {
            byte* nativeLabelId;
            int labelIdByteCount = 0;
            if (labelId != null)
            {
                labelIdByteCount = Encoding.UTF8.GetByteCount(labelId);
                if (labelIdByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeLabelId = Util.Allocate(labelIdByteCount + 1);
                }
                else
                {
                    byte* nativeLabelIdStackBytes = stackalloc byte[labelIdByteCount + 1];
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
                    fixed (long* nativeErr = &err)
                    {
                        ImPlotNative.ImPlot_PlotErrorBars_S64PtrS64PtrS64PtrInt(nativeLabelId, nativeXs, nativeYs, nativeErr, count, flags, offset, stride);
                        if (labelIdByteCount > Util.StackAllocationSizeLimit)
                        {
                            Util.Free(nativeLabelId);
                        }
                    }
                }
            }
        }
        
        /// <summary>
        ///     Plots the error bars using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="err">The err</param>
        /// <param name="count">The count</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        public static void PlotErrorBars(string labelId, ref long xs, ref long ys, ref long err, int count, ImPlotErrorBarsFlags flags, int offset)
        {
            byte* nativeLabelId;
            int labelIdByteCount = 0;
            if (labelId != null)
            {
                labelIdByteCount = Encoding.UTF8.GetByteCount(labelId);
                if (labelIdByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeLabelId = Util.Allocate(labelIdByteCount + 1);
                }
                else
                {
                    byte* nativeLabelIdStackBytes = stackalloc byte[labelIdByteCount + 1];
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
                    fixed (long* nativeErr = &err)
                    {
                        ImPlotNative.ImPlot_PlotErrorBars_S64PtrS64PtrS64PtrInt(nativeLabelId, nativeXs, nativeYs, nativeErr, count, flags, offset, stride);
                        if (labelIdByteCount > Util.StackAllocationSizeLimit)
                        {
                            Util.Free(nativeLabelId);
                        }
                    }
                }
            }
        }
        
        /// <summary>
        ///     Plots the error bars using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="err">The err</param>
        /// <param name="count">The count</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        /// <param name="stride">The stride</param>
        public static void PlotErrorBars(string labelId, ref long xs, ref long ys, ref long err, int count, ImPlotErrorBarsFlags flags, int offset, int stride)
        {
            byte* nativeLabelId;
            int labelIdByteCount = 0;
            if (labelId != null)
            {
                labelIdByteCount = Encoding.UTF8.GetByteCount(labelId);
                if (labelIdByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeLabelId = Util.Allocate(labelIdByteCount + 1);
                }
                else
                {
                    byte* nativeLabelIdStackBytes = stackalloc byte[labelIdByteCount + 1];
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
                    fixed (long* nativeErr = &err)
                    {
                        ImPlotNative.ImPlot_PlotErrorBars_S64PtrS64PtrS64PtrInt(nativeLabelId, nativeXs, nativeYs, nativeErr, count, flags, offset, stride);
                        if (labelIdByteCount > Util.StackAllocationSizeLimit)
                        {
                            Util.Free(nativeLabelId);
                        }
                    }
                }
            }
        }
        
        /// <summary>
        ///     Plots the error bars using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="err">The err</param>
        /// <param name="count">The count</param>
        public static void PlotErrorBars(string labelId, ref ulong xs, ref ulong ys, ref ulong err, int count)
        {
            byte* nativeLabelId;
            int labelIdByteCount = 0;
            if (labelId != null)
            {
                labelIdByteCount = Encoding.UTF8.GetByteCount(labelId);
                if (labelIdByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeLabelId = Util.Allocate(labelIdByteCount + 1);
                }
                else
                {
                    byte* nativeLabelIdStackBytes = stackalloc byte[labelIdByteCount + 1];
                    nativeLabelId = nativeLabelIdStackBytes;
                }
                
                int nativeLabelIdOffset = Util.GetUtf8(labelId, nativeLabelId, labelIdByteCount);
                nativeLabelId[nativeLabelIdOffset] = 0;
            }
            else
            {
                nativeLabelId = null;
            }
            
            ImPlotErrorBarsFlags flags = 0;
            int offset = 0;
            int stride = sizeof(ulong);
            fixed (ulong* nativeXs = &xs)
            {
                fixed (ulong* nativeYs = &ys)
                {
                    fixed (ulong* nativeErr = &err)
                    {
                        ImPlotNative.ImPlot_PlotErrorBars_U64PtrU64PtrU64PtrInt(nativeLabelId, nativeXs, nativeYs, nativeErr, count, flags, offset, stride);
                        if (labelIdByteCount > Util.StackAllocationSizeLimit)
                        {
                            Util.Free(nativeLabelId);
                        }
                    }
                }
            }
        }
        
        /// <summary>
        ///     Plots the error bars using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="err">The err</param>
        /// <param name="count">The count</param>
        /// <param name="flags">The flags</param>
        public static void PlotErrorBars(string labelId, ref ulong xs, ref ulong ys, ref ulong err, int count, ImPlotErrorBarsFlags flags)
        {
            byte* nativeLabelId;
            int labelIdByteCount = 0;
            if (labelId != null)
            {
                labelIdByteCount = Encoding.UTF8.GetByteCount(labelId);
                if (labelIdByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeLabelId = Util.Allocate(labelIdByteCount + 1);
                }
                else
                {
                    byte* nativeLabelIdStackBytes = stackalloc byte[labelIdByteCount + 1];
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
                    fixed (ulong* nativeErr = &err)
                    {
                        ImPlotNative.ImPlot_PlotErrorBars_U64PtrU64PtrU64PtrInt(nativeLabelId, nativeXs, nativeYs, nativeErr, count, flags, offset, stride);
                        if (labelIdByteCount > Util.StackAllocationSizeLimit)
                        {
                            Util.Free(nativeLabelId);
                        }
                    }
                }
            }
        }
        
        /// <summary>
        ///     Plots the error bars using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="err">The err</param>
        /// <param name="count">The count</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        public static void PlotErrorBars(string labelId, ref ulong xs, ref ulong ys, ref ulong err, int count, ImPlotErrorBarsFlags flags, int offset)
        {
            byte* nativeLabelId;
            int labelIdByteCount = 0;
            if (labelId != null)
            {
                labelIdByteCount = Encoding.UTF8.GetByteCount(labelId);
                if (labelIdByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeLabelId = Util.Allocate(labelIdByteCount + 1);
                }
                else
                {
                    byte* nativeLabelIdStackBytes = stackalloc byte[labelIdByteCount + 1];
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
                    fixed (ulong* nativeErr = &err)
                    {
                        ImPlotNative.ImPlot_PlotErrorBars_U64PtrU64PtrU64PtrInt(nativeLabelId, nativeXs, nativeYs, nativeErr, count, flags, offset, stride);
                        if (labelIdByteCount > Util.StackAllocationSizeLimit)
                        {
                            Util.Free(nativeLabelId);
                        }
                    }
                }
            }
        }
        
        /// <summary>
        ///     Plots the error bars using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="err">The err</param>
        /// <param name="count">The count</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        /// <param name="stride">The stride</param>
        public static void PlotErrorBars(string labelId, ref ulong xs, ref ulong ys, ref ulong err, int count, ImPlotErrorBarsFlags flags, int offset, int stride)
        {
            byte* nativeLabelId;
            int labelIdByteCount = 0;
            if (labelId != null)
            {
                labelIdByteCount = Encoding.UTF8.GetByteCount(labelId);
                if (labelIdByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeLabelId = Util.Allocate(labelIdByteCount + 1);
                }
                else
                {
                    byte* nativeLabelIdStackBytes = stackalloc byte[labelIdByteCount + 1];
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
                    fixed (ulong* nativeErr = &err)
                    {
                        ImPlotNative.ImPlot_PlotErrorBars_U64PtrU64PtrU64PtrInt(nativeLabelId, nativeXs, nativeYs, nativeErr, count, flags, offset, stride);
                        if (labelIdByteCount > Util.StackAllocationSizeLimit)
                        {
                            Util.Free(nativeLabelId);
                        }
                    }
                }
            }
        }
        
        /// <summary>
        ///     Plots the error bars using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="neg">The neg</param>
        /// <param name="pos">The pos</param>
        /// <param name="count">The count</param>
        public static void PlotErrorBars(string labelId, ref float xs, ref float ys, ref float neg, ref float pos, int count)
        {
            byte* nativeLabelId;
            int labelIdByteCount = 0;
            if (labelId != null)
            {
                labelIdByteCount = Encoding.UTF8.GetByteCount(labelId);
                if (labelIdByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeLabelId = Util.Allocate(labelIdByteCount + 1);
                }
                else
                {
                    byte* nativeLabelIdStackBytes = stackalloc byte[labelIdByteCount + 1];
                    nativeLabelId = nativeLabelIdStackBytes;
                }
                
                int nativeLabelIdOffset = Util.GetUtf8(labelId, nativeLabelId, labelIdByteCount);
                nativeLabelId[nativeLabelIdOffset] = 0;
            }
            else
            {
                nativeLabelId = null;
            }
            
            ImPlotErrorBarsFlags flags = 0;
            int offset = 0;
            int stride = sizeof(float);
            fixed (float* nativeXs = &xs)
            {
                fixed (float* nativeYs = &ys)
                {
                    fixed (float* nativeNeg = &neg)
                    {
                        fixed (float* nativePos = &pos)
                        {
                            ImPlotNative.ImPlot_PlotErrorBars_FloatPtrFloatPtrFloatPtrFloatPtr(nativeLabelId, nativeXs, nativeYs, nativeNeg, nativePos, count, flags, offset, stride);
                            if (labelIdByteCount > Util.StackAllocationSizeLimit)
                            {
                                Util.Free(nativeLabelId);
                            }
                        }
                    }
                }
            }
        }
        
        /// <summary>
        ///     Plots the error bars using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="neg">The neg</param>
        /// <param name="pos">The pos</param>
        /// <param name="count">The count</param>
        /// <param name="flags">The flags</param>
        public static void PlotErrorBars(string labelId, ref float xs, ref float ys, ref float neg, ref float pos, int count, ImPlotErrorBarsFlags flags)
        {
            byte* nativeLabelId;
            int labelIdByteCount = 0;
            if (labelId != null)
            {
                labelIdByteCount = Encoding.UTF8.GetByteCount(labelId);
                if (labelIdByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeLabelId = Util.Allocate(labelIdByteCount + 1);
                }
                else
                {
                    byte* nativeLabelIdStackBytes = stackalloc byte[labelIdByteCount + 1];
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
                    fixed (float* nativeNeg = &neg)
                    {
                        fixed (float* nativePos = &pos)
                        {
                            ImPlotNative.ImPlot_PlotErrorBars_FloatPtrFloatPtrFloatPtrFloatPtr(nativeLabelId, nativeXs, nativeYs, nativeNeg, nativePos, count, flags, offset, stride);
                            if (labelIdByteCount > Util.StackAllocationSizeLimit)
                            {
                                Util.Free(nativeLabelId);
                            }
                        }
                    }
                }
            }
        }
        
        /// <summary>
        ///     Plots the error bars using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="neg">The neg</param>
        /// <param name="pos">The pos</param>
        /// <param name="count">The count</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        public static void PlotErrorBars(string labelId, ref float xs, ref float ys, ref float neg, ref float pos, int count, ImPlotErrorBarsFlags flags, int offset)
        {
            byte* nativeLabelId;
            int labelIdByteCount = 0;
            if (labelId != null)
            {
                labelIdByteCount = Encoding.UTF8.GetByteCount(labelId);
                if (labelIdByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeLabelId = Util.Allocate(labelIdByteCount + 1);
                }
                else
                {
                    byte* nativeLabelIdStackBytes = stackalloc byte[labelIdByteCount + 1];
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
                    fixed (float* nativeNeg = &neg)
                    {
                        fixed (float* nativePos = &pos)
                        {
                            ImPlotNative.ImPlot_PlotErrorBars_FloatPtrFloatPtrFloatPtrFloatPtr(nativeLabelId, nativeXs, nativeYs, nativeNeg, nativePos, count, flags, offset, stride);
                            if (labelIdByteCount > Util.StackAllocationSizeLimit)
                            {
                                Util.Free(nativeLabelId);
                            }
                        }
                    }
                }
            }
        }
        
        /// <summary>
        ///     Plots the error bars using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="neg">The neg</param>
        /// <param name="pos">The pos</param>
        /// <param name="count">The count</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        /// <param name="stride">The stride</param>
        public static void PlotErrorBars(string labelId, ref float xs, ref float ys, ref float neg, ref float pos, int count, ImPlotErrorBarsFlags flags, int offset, int stride)
        {
            byte* nativeLabelId;
            int labelIdByteCount = 0;
            if (labelId != null)
            {
                labelIdByteCount = Encoding.UTF8.GetByteCount(labelId);
                if (labelIdByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeLabelId = Util.Allocate(labelIdByteCount + 1);
                }
                else
                {
                    byte* nativeLabelIdStackBytes = stackalloc byte[labelIdByteCount + 1];
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
                    fixed (float* nativeNeg = &neg)
                    {
                        fixed (float* nativePos = &pos)
                        {
                            ImPlotNative.ImPlot_PlotErrorBars_FloatPtrFloatPtrFloatPtrFloatPtr(nativeLabelId, nativeXs, nativeYs, nativeNeg, nativePos, count, flags, offset, stride);
                            if (labelIdByteCount > Util.StackAllocationSizeLimit)
                            {
                                Util.Free(nativeLabelId);
                            }
                        }
                    }
                }
            }
        }
        
        /// <summary>
        ///     Plots the error bars using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="neg">The neg</param>
        /// <param name="pos">The pos</param>
        /// <param name="count">The count</param>
        public static void PlotErrorBars(string labelId, ref double xs, ref double ys, ref double neg, ref double pos, int count)
        {
            byte* nativeLabelId;
            int labelIdByteCount = 0;
            if (labelId != null)
            {
                labelIdByteCount = Encoding.UTF8.GetByteCount(labelId);
                if (labelIdByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeLabelId = Util.Allocate(labelIdByteCount + 1);
                }
                else
                {
                    byte* nativeLabelIdStackBytes = stackalloc byte[labelIdByteCount + 1];
                    nativeLabelId = nativeLabelIdStackBytes;
                }
                
                int nativeLabelIdOffset = Util.GetUtf8(labelId, nativeLabelId, labelIdByteCount);
                nativeLabelId[nativeLabelIdOffset] = 0;
            }
            else
            {
                nativeLabelId = null;
            }
            
            ImPlotErrorBarsFlags flags = 0;
            int offset = 0;
            int stride = sizeof(double);
            fixed (double* nativeXs = &xs)
            {
                fixed (double* nativeYs = &ys)
                {
                    fixed (double* nativeNeg = &neg)
                    {
                        fixed (double* nativePos = &pos)
                        {
                            ImPlotNative.ImPlot_PlotErrorBars_doublePtrdoublePtrdoublePtrdoublePtr(nativeLabelId, nativeXs, nativeYs, nativeNeg, nativePos, count, flags, offset, stride);
                            if (labelIdByteCount > Util.StackAllocationSizeLimit)
                            {
                                Util.Free(nativeLabelId);
                            }
                        }
                    }
                }
            }
        }
        
        /// <summary>
        ///     Plots the error bars using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="neg">The neg</param>
        /// <param name="pos">The pos</param>
        /// <param name="count">The count</param>
        /// <param name="flags">The flags</param>
        public static void PlotErrorBars(string labelId, ref double xs, ref double ys, ref double neg, ref double pos, int count, ImPlotErrorBarsFlags flags)
        {
            byte* nativeLabelId;
            int labelIdByteCount = 0;
            if (labelId != null)
            {
                labelIdByteCount = Encoding.UTF8.GetByteCount(labelId);
                if (labelIdByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeLabelId = Util.Allocate(labelIdByteCount + 1);
                }
                else
                {
                    byte* nativeLabelIdStackBytes = stackalloc byte[labelIdByteCount + 1];
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
                    fixed (double* nativeNeg = &neg)
                    {
                        fixed (double* nativePos = &pos)
                        {
                            ImPlotNative.ImPlot_PlotErrorBars_doublePtrdoublePtrdoublePtrdoublePtr(nativeLabelId, nativeXs, nativeYs, nativeNeg, nativePos, count, flags, offset, stride);
                            if (labelIdByteCount > Util.StackAllocationSizeLimit)
                            {
                                Util.Free(nativeLabelId);
                            }
                        }
                    }
                }
            }
        }
        
        /// <summary>
        ///     Plots the error bars using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="neg">The neg</param>
        /// <param name="pos">The pos</param>
        /// <param name="count">The count</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        public static void PlotErrorBars(string labelId, ref double xs, ref double ys, ref double neg, ref double pos, int count, ImPlotErrorBarsFlags flags, int offset)
        {
            byte* nativeLabelId;
            int labelIdByteCount = 0;
            if (labelId != null)
            {
                labelIdByteCount = Encoding.UTF8.GetByteCount(labelId);
                if (labelIdByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeLabelId = Util.Allocate(labelIdByteCount + 1);
                }
                else
                {
                    byte* nativeLabelIdStackBytes = stackalloc byte[labelIdByteCount + 1];
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
                    fixed (double* nativeNeg = &neg)
                    {
                        fixed (double* nativePos = &pos)
                        {
                            ImPlotNative.ImPlot_PlotErrorBars_doublePtrdoublePtrdoublePtrdoublePtr(nativeLabelId, nativeXs, nativeYs, nativeNeg, nativePos, count, flags, offset, stride);
                            if (labelIdByteCount > Util.StackAllocationSizeLimit)
                            {
                                Util.Free(nativeLabelId);
                            }
                        }
                    }
                }
            }
        }
        
        /// <summary>
        ///     Plots the error bars using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="neg">The neg</param>
        /// <param name="pos">The pos</param>
        /// <param name="count">The count</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        /// <param name="stride">The stride</param>
        public static void PlotErrorBars(string labelId, ref double xs, ref double ys, ref double neg, ref double pos, int count, ImPlotErrorBarsFlags flags, int offset, int stride)
        {
            byte* nativeLabelId;
            int labelIdByteCount = 0;
            if (labelId != null)
            {
                labelIdByteCount = Encoding.UTF8.GetByteCount(labelId);
                if (labelIdByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeLabelId = Util.Allocate(labelIdByteCount + 1);
                }
                else
                {
                    byte* nativeLabelIdStackBytes = stackalloc byte[labelIdByteCount + 1];
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
                    fixed (double* nativeNeg = &neg)
                    {
                        fixed (double* nativePos = &pos)
                        {
                            ImPlotNative.ImPlot_PlotErrorBars_doublePtrdoublePtrdoublePtrdoublePtr(nativeLabelId, nativeXs, nativeYs, nativeNeg, nativePos, count, flags, offset, stride);
                            if (labelIdByteCount > Util.StackAllocationSizeLimit)
                            {
                                Util.Free(nativeLabelId);
                            }
                        }
                    }
                }
            }
        }
        
        /// <summary>
        ///     Plots the error bars using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="neg">The neg</param>
        /// <param name="pos">The pos</param>
        /// <param name="count">The count</param>
        public static void PlotErrorBars(string labelId, ref sbyte xs, ref sbyte ys, ref sbyte neg, ref sbyte pos, int count)
        {
            byte* nativeLabelId;
            int labelIdByteCount = 0;
            if (labelId != null)
            {
                labelIdByteCount = Encoding.UTF8.GetByteCount(labelId);
                if (labelIdByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeLabelId = Util.Allocate(labelIdByteCount + 1);
                }
                else
                {
                    byte* nativeLabelIdStackBytes = stackalloc byte[labelIdByteCount + 1];
                    nativeLabelId = nativeLabelIdStackBytes;
                }
                
                int nativeLabelIdOffset = Util.GetUtf8(labelId, nativeLabelId, labelIdByteCount);
                nativeLabelId[nativeLabelIdOffset] = 0;
            }
            else
            {
                nativeLabelId = null;
            }
            
            ImPlotErrorBarsFlags flags = 0;
            int offset = 0;
            int stride = sizeof(sbyte);
            fixed (sbyte* nativeXs = &xs)
            {
                fixed (sbyte* nativeYs = &ys)
                {
                    fixed (sbyte* nativeNeg = &neg)
                    {
                        fixed (sbyte* nativePos = &pos)
                        {
                            ImPlotNative.ImPlot_PlotErrorBars_S8PtrS8PtrS8PtrS8Ptr(nativeLabelId, nativeXs, nativeYs, nativeNeg, nativePos, count, flags, offset, stride);
                            if (labelIdByteCount > Util.StackAllocationSizeLimit)
                            {
                                Util.Free(nativeLabelId);
                            }
                        }
                    }
                }
            }
        }
    }
}