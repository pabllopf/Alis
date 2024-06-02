// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImPlotP5.cs
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
            /// <param name="neg">The neg</param>
            /// <param name="pos">The pos</param>
            /// <param name="count">The count</param>
            /// <param name="flags">The flags</param>
            public static void PlotErrorBars(string labelId, ref sbyte xs, ref sbyte ys, ref sbyte neg, ref sbyte pos, int count, ImPlotErrorBarsFlags flags)
            {
                byte* nativeLabelId;
                int labelIdByteCount = 0;
                if (labelId != null)
                {
                    labelIdByteCount = Encoding.UTF8.GetByteCount(labelId);
                    if (labelIdByteCount > Util.StackAllocationSizeLimit)
                    {
                        nativeLabelId = Util.Allocate(labelIdByteCount + 1);
                    }
                    else
                    {
                        byte* nativeLabelIdStackBytes = stackalloc byte[labelIdByteCount + 1];
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
            public static void PlotErrorBars(string labelId, ref sbyte xs, ref sbyte ys, ref sbyte neg, ref sbyte pos, int count, ImPlotErrorBarsFlags flags, int offset)
            {
                byte* nativeLabelId;
                int labelIdByteCount = 0;
                if (labelId != null)
                {
                    labelIdByteCount = Encoding.UTF8.GetByteCount(labelId);
                    if (labelIdByteCount > Util.StackAllocationSizeLimit)
                    {
                        nativeLabelId = Util.Allocate(labelIdByteCount + 1);
                    }
                    else
                    {
                        byte* nativeLabelIdStackBytes = stackalloc byte[labelIdByteCount + 1];
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
            public static void PlotErrorBars(string labelId, ref sbyte xs, ref sbyte ys, ref sbyte neg, ref sbyte pos, int count, ImPlotErrorBarsFlags flags, int offset, int stride)
            {
                byte* nativeLabelId;
                int labelIdByteCount = 0;
                if (labelId != null)
                {
                    labelIdByteCount = Encoding.UTF8.GetByteCount(labelId);
                    if (labelIdByteCount > Util.StackAllocationSizeLimit)
                    {
                        nativeLabelId = Util.Allocate(labelIdByteCount + 1);
                    }
                    else
                    {
                        byte* nativeLabelIdStackBytes = stackalloc byte[labelIdByteCount + 1];
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
            
            /// <summary>
            ///     Plots the error bars using the specified label id
            /// </summary>
            /// <param name="labelId">The label id</param>
            /// <param name="xs">The xs</param>
            /// <param name="ys">The ys</param>
            /// <param name="neg">The neg</param>
            /// <param name="pos">The pos</param>
            /// <param name="count">The count</param>
            public static void PlotErrorBars(string labelId, ref byte xs, ref byte ys, ref byte neg, ref byte pos, int count)
            {
                byte* nativeLabelId;
                int labelIdByteCount = 0;
                if (labelId != null)
                {
                    labelIdByteCount = Encoding.UTF8.GetByteCount(labelId);
                    if (labelIdByteCount > Util.StackAllocationSizeLimit)
                    {
                        nativeLabelId = Util.Allocate(labelIdByteCount + 1);
                    }
                    else
                    {
                        byte* nativeLabelIdStackBytes = stackalloc byte[labelIdByteCount + 1];
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
                        fixed (byte* nativeNeg = &neg)
                        {
                            fixed (byte* nativePos = &pos)
                            {
                                ImPlotNative.ImPlot_PlotErrorBars_U8PtrU8PtrU8PtrU8Ptr(nativeLabelId, nativeXs, nativeYs, nativeNeg, nativePos, count, flags, offset, stride);
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
            public static void PlotErrorBars(string labelId, ref byte xs, ref byte ys, ref byte neg, ref byte pos, int count, ImPlotErrorBarsFlags flags)
            {
                byte* nativeLabelId;
                int labelIdByteCount = 0;
                if (labelId != null)
                {
                    labelIdByteCount = Encoding.UTF8.GetByteCount(labelId);
                    if (labelIdByteCount > Util.StackAllocationSizeLimit)
                    {
                        nativeLabelId = Util.Allocate(labelIdByteCount + 1);
                    }
                    else
                    {
                        byte* nativeLabelIdStackBytes = stackalloc byte[labelIdByteCount + 1];
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
                        fixed (byte* nativeNeg = &neg)
                        {
                            fixed (byte* nativePos = &pos)
                            {
                                ImPlotNative.ImPlot_PlotErrorBars_U8PtrU8PtrU8PtrU8Ptr(nativeLabelId, nativeXs, nativeYs, nativeNeg, nativePos, count, flags, offset, stride);
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
            public static void PlotErrorBars(string labelId, ref byte xs, ref byte ys, ref byte neg, ref byte pos, int count, ImPlotErrorBarsFlags flags, int offset)
            {
                byte* nativeLabelId;
                int labelIdByteCount = 0;
                if (labelId != null)
                {
                    labelIdByteCount = Encoding.UTF8.GetByteCount(labelId);
                    if (labelIdByteCount > Util.StackAllocationSizeLimit)
                    {
                        nativeLabelId = Util.Allocate(labelIdByteCount + 1);
                    }
                    else
                    {
                        byte* nativeLabelIdStackBytes = stackalloc byte[labelIdByteCount + 1];
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
                        fixed (byte* nativeNeg = &neg)
                        {
                            fixed (byte* nativePos = &pos)
                            {
                                ImPlotNative.ImPlot_PlotErrorBars_U8PtrU8PtrU8PtrU8Ptr(nativeLabelId, nativeXs, nativeYs, nativeNeg, nativePos, count, flags, offset, stride);
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
            public static void PlotErrorBars(string labelId, ref byte xs, ref byte ys, ref byte neg, ref byte pos, int count, ImPlotErrorBarsFlags flags, int offset, int stride)
            {
                byte* nativeLabelId;
                int labelIdByteCount = 0;
                if (labelId != null)
                {
                    labelIdByteCount = Encoding.UTF8.GetByteCount(labelId);
                    if (labelIdByteCount > Util.StackAllocationSizeLimit)
                    {
                        nativeLabelId = Util.Allocate(labelIdByteCount + 1);
                    }
                    else
                    {
                        byte* nativeLabelIdStackBytes = stackalloc byte[labelIdByteCount + 1];
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
                        fixed (byte* nativeNeg = &neg)
                        {
                            fixed (byte* nativePos = &pos)
                            {
                                ImPlotNative.ImPlot_PlotErrorBars_U8PtrU8PtrU8PtrU8Ptr(nativeLabelId, nativeXs, nativeYs, nativeNeg, nativePos, count, flags, offset, stride);
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
            public static void PlotErrorBars(string labelId, ref short xs, ref short ys, ref short neg, ref short pos, int count)
            {
                byte* nativeLabelId;
                int labelIdByteCount = 0;
                if (labelId != null)
                {
                    labelIdByteCount = Encoding.UTF8.GetByteCount(labelId);
                    if (labelIdByteCount > Util.StackAllocationSizeLimit)
                    {
                        nativeLabelId = Util.Allocate(labelIdByteCount + 1);
                    }
                    else
                    {
                        byte* nativeLabelIdStackBytes = stackalloc byte[labelIdByteCount + 1];
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
                        fixed (short* nativeNeg = &neg)
                        {
                            fixed (short* nativePos = &pos)
                            {
                                ImPlotNative.ImPlot_PlotErrorBars_S16PtrS16PtrS16PtrS16Ptr(nativeLabelId, nativeXs, nativeYs, nativeNeg, nativePos, count, flags, offset, stride);
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
            public static void PlotErrorBars(string labelId, ref short xs, ref short ys, ref short neg, ref short pos, int count, ImPlotErrorBarsFlags flags)
            {
                byte* nativeLabelId;
                int labelIdByteCount = 0;
                if (labelId != null)
                {
                    labelIdByteCount = Encoding.UTF8.GetByteCount(labelId);
                    if (labelIdByteCount > Util.StackAllocationSizeLimit)
                    {
                        nativeLabelId = Util.Allocate(labelIdByteCount + 1);
                    }
                    else
                    {
                        byte* nativeLabelIdStackBytes = stackalloc byte[labelIdByteCount + 1];
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
                        fixed (short* nativeNeg = &neg)
                        {
                            fixed (short* nativePos = &pos)
                            {
                                ImPlotNative.ImPlot_PlotErrorBars_S16PtrS16PtrS16PtrS16Ptr(nativeLabelId, nativeXs, nativeYs, nativeNeg, nativePos, count, flags, offset, stride);
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
            public static void PlotErrorBars(string labelId, ref short xs, ref short ys, ref short neg, ref short pos, int count, ImPlotErrorBarsFlags flags, int offset)
            {
                byte* nativeLabelId;
                int labelIdByteCount = 0;
                if (labelId != null)
                {
                    labelIdByteCount = Encoding.UTF8.GetByteCount(labelId);
                    if (labelIdByteCount > Util.StackAllocationSizeLimit)
                    {
                        nativeLabelId = Util.Allocate(labelIdByteCount + 1);
                    }
                    else
                    {
                        byte* nativeLabelIdStackBytes = stackalloc byte[labelIdByteCount + 1];
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
                        fixed (short* nativeNeg = &neg)
                        {
                            fixed (short* nativePos = &pos)
                            {
                                ImPlotNative.ImPlot_PlotErrorBars_S16PtrS16PtrS16PtrS16Ptr(nativeLabelId, nativeXs, nativeYs, nativeNeg, nativePos, count, flags, offset, stride);
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
            public static void PlotErrorBars(string labelId, ref short xs, ref short ys, ref short neg, ref short pos, int count, ImPlotErrorBarsFlags flags, int offset, int stride)
            {
                byte* nativeLabelId;
                int labelIdByteCount = 0;
                if (labelId != null)
                {
                    labelIdByteCount = Encoding.UTF8.GetByteCount(labelId);
                    if (labelIdByteCount > Util.StackAllocationSizeLimit)
                    {
                        nativeLabelId = Util.Allocate(labelIdByteCount + 1);
                    }
                    else
                    {
                        byte* nativeLabelIdStackBytes = stackalloc byte[labelIdByteCount + 1];
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
                        fixed (short* nativeNeg = &neg)
                        {
                            fixed (short* nativePos = &pos)
                            {
                                ImPlotNative.ImPlot_PlotErrorBars_S16PtrS16PtrS16PtrS16Ptr(nativeLabelId, nativeXs, nativeYs, nativeNeg, nativePos, count, flags, offset, stride);
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
            public static void PlotErrorBars(string labelId, ref ushort xs, ref ushort ys, ref ushort neg, ref ushort pos, int count)
            {
                byte* nativeLabelId;
                int labelIdByteCount = 0;
                if (labelId != null)
                {
                    labelIdByteCount = Encoding.UTF8.GetByteCount(labelId);
                    if (labelIdByteCount > Util.StackAllocationSizeLimit)
                    {
                        nativeLabelId = Util.Allocate(labelIdByteCount + 1);
                    }
                    else
                    {
                        byte* nativeLabelIdStackBytes = stackalloc byte[labelIdByteCount + 1];
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
                        fixed (ushort* nativeNeg = &neg)
                        {
                            fixed (ushort* nativePos = &pos)
                            {
                                ImPlotNative.ImPlot_PlotErrorBars_U16PtrU16PtrU16PtrU16Ptr(nativeLabelId, nativeXs, nativeYs, nativeNeg, nativePos, count, flags, offset, stride);
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
            public static void PlotErrorBars(string labelId, ref ushort xs, ref ushort ys, ref ushort neg, ref ushort pos, int count, ImPlotErrorBarsFlags flags)
            {
                byte* nativeLabelId;
                int labelIdByteCount = 0;
                if (labelId != null)
                {
                    labelIdByteCount = Encoding.UTF8.GetByteCount(labelId);
                    if (labelIdByteCount > Util.StackAllocationSizeLimit)
                    {
                        nativeLabelId = Util.Allocate(labelIdByteCount + 1);
                    }
                    else
                    {
                        byte* nativeLabelIdStackBytes = stackalloc byte[labelIdByteCount + 1];
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
                        fixed (ushort* nativeNeg = &neg)
                        {
                            fixed (ushort* nativePos = &pos)
                            {
                                ImPlotNative.ImPlot_PlotErrorBars_U16PtrU16PtrU16PtrU16Ptr(nativeLabelId, nativeXs, nativeYs, nativeNeg, nativePos, count, flags, offset, stride);
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
            public static void PlotErrorBars(string labelId, ref ushort xs, ref ushort ys, ref ushort neg, ref ushort pos, int count, ImPlotErrorBarsFlags flags, int offset)
            {
                byte* nativeLabelId;
                int labelIdByteCount = 0;
                if (labelId != null)
                {
                    labelIdByteCount = Encoding.UTF8.GetByteCount(labelId);
                    if (labelIdByteCount > Util.StackAllocationSizeLimit)
                    {
                        nativeLabelId = Util.Allocate(labelIdByteCount + 1);
                    }
                    else
                    {
                        byte* nativeLabelIdStackBytes = stackalloc byte[labelIdByteCount + 1];
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
                        fixed (ushort* nativeNeg = &neg)
                        {
                            fixed (ushort* nativePos = &pos)
                            {
                                ImPlotNative.ImPlot_PlotErrorBars_U16PtrU16PtrU16PtrU16Ptr(nativeLabelId, nativeXs, nativeYs, nativeNeg, nativePos, count, flags, offset, stride);
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
            public static void PlotErrorBars(string labelId, ref ushort xs, ref ushort ys, ref ushort neg, ref ushort pos, int count, ImPlotErrorBarsFlags flags, int offset, int stride)
            {
                byte* nativeLabelId;
                int labelIdByteCount = 0;
                if (labelId != null)
                {
                    labelIdByteCount = Encoding.UTF8.GetByteCount(labelId);
                    if (labelIdByteCount > Util.StackAllocationSizeLimit)
                    {
                        nativeLabelId = Util.Allocate(labelIdByteCount + 1);
                    }
                    else
                    {
                        byte* nativeLabelIdStackBytes = stackalloc byte[labelIdByteCount + 1];
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
                        fixed (ushort* nativeNeg = &neg)
                        {
                            fixed (ushort* nativePos = &pos)
                            {
                                ImPlotNative.ImPlot_PlotErrorBars_U16PtrU16PtrU16PtrU16Ptr(nativeLabelId, nativeXs, nativeYs, nativeNeg, nativePos, count, flags, offset, stride);
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
            public static void PlotErrorBars(string labelId, ref int xs, ref int ys, ref int neg, ref int pos, int count)
            {
                byte* nativeLabelId;
                int labelIdByteCount = 0;
                if (labelId != null)
                {
                    labelIdByteCount = Encoding.UTF8.GetByteCount(labelId);
                    if (labelIdByteCount > Util.StackAllocationSizeLimit)
                    {
                        nativeLabelId = Util.Allocate(labelIdByteCount + 1);
                    }
                    else
                    {
                        byte* nativeLabelIdStackBytes = stackalloc byte[labelIdByteCount + 1];
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
                        fixed (int* nativeNeg = &neg)
                        {
                            fixed (int* nativePos = &pos)
                            {
                                ImPlotNative.ImPlot_PlotErrorBars_S32PtrS32PtrS32PtrS32Ptr(nativeLabelId, nativeXs, nativeYs, nativeNeg, nativePos, count, flags, offset, stride);
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
            public static void PlotErrorBars(string labelId, ref int xs, ref int ys, ref int neg, ref int pos, int count, ImPlotErrorBarsFlags flags)
            {
                byte* nativeLabelId;
                int labelIdByteCount = 0;
                if (labelId != null)
                {
                    labelIdByteCount = Encoding.UTF8.GetByteCount(labelId);
                    if (labelIdByteCount > Util.StackAllocationSizeLimit)
                    {
                        nativeLabelId = Util.Allocate(labelIdByteCount + 1);
                    }
                    else
                    {
                        byte* nativeLabelIdStackBytes = stackalloc byte[labelIdByteCount + 1];
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
                        fixed (int* nativeNeg = &neg)
                        {
                            fixed (int* nativePos = &pos)
                            {
                                ImPlotNative.ImPlot_PlotErrorBars_S32PtrS32PtrS32PtrS32Ptr(nativeLabelId, nativeXs, nativeYs, nativeNeg, nativePos, count, flags, offset, stride);
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
            public static void PlotErrorBars(string labelId, ref int xs, ref int ys, ref int neg, ref int pos, int count, ImPlotErrorBarsFlags flags, int offset)
            {
                byte* nativeLabelId;
                int labelIdByteCount = 0;
                if (labelId != null)
                {
                    labelIdByteCount = Encoding.UTF8.GetByteCount(labelId);
                    if (labelIdByteCount > Util.StackAllocationSizeLimit)
                    {
                        nativeLabelId = Util.Allocate(labelIdByteCount + 1);
                    }
                    else
                    {
                        byte* nativeLabelIdStackBytes = stackalloc byte[labelIdByteCount + 1];
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
                        fixed (int* nativeNeg = &neg)
                        {
                            fixed (int* nativePos = &pos)
                            {
                                ImPlotNative.ImPlot_PlotErrorBars_S32PtrS32PtrS32PtrS32Ptr(nativeLabelId, nativeXs, nativeYs, nativeNeg, nativePos, count, flags, offset, stride);
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
            public static void PlotErrorBars(string labelId, ref int xs, ref int ys, ref int neg, ref int pos, int count, ImPlotErrorBarsFlags flags, int offset, int stride)
            {
                byte* nativeLabelId;
                int labelIdByteCount = 0;
                if (labelId != null)
                {
                    labelIdByteCount = Encoding.UTF8.GetByteCount(labelId);
                    if (labelIdByteCount > Util.StackAllocationSizeLimit)
                    {
                        nativeLabelId = Util.Allocate(labelIdByteCount + 1);
                    }
                    else
                    {
                        byte* nativeLabelIdStackBytes = stackalloc byte[labelIdByteCount + 1];
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
                        fixed (int* nativeNeg = &neg)
                        {
                            fixed (int* nativePos = &pos)
                            {
                                ImPlotNative.ImPlot_PlotErrorBars_S32PtrS32PtrS32PtrS32Ptr(nativeLabelId, nativeXs, nativeYs, nativeNeg, nativePos, count, flags, offset, stride);
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
            public static void PlotErrorBars(string labelId, ref uint xs, ref uint ys, ref uint neg, ref uint pos, int count)
            {
                byte* nativeLabelId;
                int labelIdByteCount = 0;
                if (labelId != null)
                {
                    labelIdByteCount = Encoding.UTF8.GetByteCount(labelId);
                    if (labelIdByteCount > Util.StackAllocationSizeLimit)
                    {
                        nativeLabelId = Util.Allocate(labelIdByteCount + 1);
                    }
                    else
                    {
                        byte* nativeLabelIdStackBytes = stackalloc byte[labelIdByteCount + 1];
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
                        fixed (uint* nativeNeg = &neg)
                        {
                            fixed (uint* nativePos = &pos)
                            {
                                ImPlotNative.ImPlot_PlotErrorBars_U32PtrU32PtrU32PtrU32Ptr(nativeLabelId, nativeXs, nativeYs, nativeNeg, nativePos, count, flags, offset, stride);
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
            public static void PlotErrorBars(string labelId, ref uint xs, ref uint ys, ref uint neg, ref uint pos, int count, ImPlotErrorBarsFlags flags)
            {
                byte* nativeLabelId;
                int labelIdByteCount = 0;
                if (labelId != null)
                {
                    labelIdByteCount = Encoding.UTF8.GetByteCount(labelId);
                    if (labelIdByteCount > Util.StackAllocationSizeLimit)
                    {
                        nativeLabelId = Util.Allocate(labelIdByteCount + 1);
                    }
                    else
                    {
                        byte* nativeLabelIdStackBytes = stackalloc byte[labelIdByteCount + 1];
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
                        fixed (uint* nativeNeg = &neg)
                        {
                            fixed (uint* nativePos = &pos)
                            {
                                ImPlotNative.ImPlot_PlotErrorBars_U32PtrU32PtrU32PtrU32Ptr(nativeLabelId, nativeXs, nativeYs, nativeNeg, nativePos, count, flags, offset, stride);
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
            public static void PlotErrorBars(string labelId, ref uint xs, ref uint ys, ref uint neg, ref uint pos, int count, ImPlotErrorBarsFlags flags, int offset)
            {
                byte* nativeLabelId;
                int labelIdByteCount = 0;
                if (labelId != null)
                {
                    labelIdByteCount = Encoding.UTF8.GetByteCount(labelId);
                    if (labelIdByteCount > Util.StackAllocationSizeLimit)
                    {
                        nativeLabelId = Util.Allocate(labelIdByteCount + 1);
                    }
                    else
                    {
                        byte* nativeLabelIdStackBytes = stackalloc byte[labelIdByteCount + 1];
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
                        fixed (uint* nativeNeg = &neg)
                        {
                            fixed (uint* nativePos = &pos)
                            {
                                ImPlotNative.ImPlot_PlotErrorBars_U32PtrU32PtrU32PtrU32Ptr(nativeLabelId, nativeXs, nativeYs, nativeNeg, nativePos, count, flags, offset, stride);
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
            public static void PlotErrorBars(string labelId, ref uint xs, ref uint ys, ref uint neg, ref uint pos, int count, ImPlotErrorBarsFlags flags, int offset, int stride)
            {
                byte* nativeLabelId;
                int labelIdByteCount = 0;
                if (labelId != null)
                {
                    labelIdByteCount = Encoding.UTF8.GetByteCount(labelId);
                    if (labelIdByteCount > Util.StackAllocationSizeLimit)
                    {
                        nativeLabelId = Util.Allocate(labelIdByteCount + 1);
                    }
                    else
                    {
                        byte* nativeLabelIdStackBytes = stackalloc byte[labelIdByteCount + 1];
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
                        fixed (uint* nativeNeg = &neg)
                        {
                            fixed (uint* nativePos = &pos)
                            {
                                ImPlotNative.ImPlot_PlotErrorBars_U32PtrU32PtrU32PtrU32Ptr(nativeLabelId, nativeXs, nativeYs, nativeNeg, nativePos, count, flags, offset, stride);
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
            public static void PlotErrorBars(string labelId, ref long xs, ref long ys, ref long neg, ref long pos, int count)
            {
                byte* nativeLabelId;
                int labelIdByteCount = 0;
                if (labelId != null)
                {
                    labelIdByteCount = Encoding.UTF8.GetByteCount(labelId);
                    if (labelIdByteCount > Util.StackAllocationSizeLimit)
                    {
                        nativeLabelId = Util.Allocate(labelIdByteCount + 1);
                    }
                    else
                    {
                        byte* nativeLabelIdStackBytes = stackalloc byte[labelIdByteCount + 1];
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
                        fixed (long* nativeNeg = &neg)
                        {
                            fixed (long* nativePos = &pos)
                            {
                                ImPlotNative.ImPlot_PlotErrorBars_S64PtrS64PtrS64PtrS64Ptr(nativeLabelId, nativeXs, nativeYs, nativeNeg, nativePos, count, flags, offset, stride);
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
            public static void PlotErrorBars(string labelId, ref long xs, ref long ys, ref long neg, ref long pos, int count, ImPlotErrorBarsFlags flags)
            {
                byte* nativeLabelId;
                int labelIdByteCount = 0;
                if (labelId != null)
                {
                    labelIdByteCount = Encoding.UTF8.GetByteCount(labelId);
                    if (labelIdByteCount > Util.StackAllocationSizeLimit)
                    {
                        nativeLabelId = Util.Allocate(labelIdByteCount + 1);
                    }
                    else
                    {
                        byte* nativeLabelIdStackBytes = stackalloc byte[labelIdByteCount + 1];
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
                        fixed (long* nativeNeg = &neg)
                        {
                            fixed (long* nativePos = &pos)
                            {
                                ImPlotNative.ImPlot_PlotErrorBars_S64PtrS64PtrS64PtrS64Ptr(nativeLabelId, nativeXs, nativeYs, nativeNeg, nativePos, count, flags, offset, stride);
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
            public static void PlotErrorBars(string labelId, ref long xs, ref long ys, ref long neg, ref long pos, int count, ImPlotErrorBarsFlags flags, int offset)
            {
                byte* nativeLabelId;
                int labelIdByteCount = 0;
                if (labelId != null)
                {
                    labelIdByteCount = Encoding.UTF8.GetByteCount(labelId);
                    if (labelIdByteCount > Util.StackAllocationSizeLimit)
                    {
                        nativeLabelId = Util.Allocate(labelIdByteCount + 1);
                    }
                    else
                    {
                        byte* nativeLabelIdStackBytes = stackalloc byte[labelIdByteCount + 1];
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
                        fixed (long* nativeNeg = &neg)
                        {
                            fixed (long* nativePos = &pos)
                            {
                                ImPlotNative.ImPlot_PlotErrorBars_S64PtrS64PtrS64PtrS64Ptr(nativeLabelId, nativeXs, nativeYs, nativeNeg, nativePos, count, flags, offset, stride);
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
            public static void PlotErrorBars(string labelId, ref long xs, ref long ys, ref long neg, ref long pos, int count, ImPlotErrorBarsFlags flags, int offset, int stride)
            {
                byte* nativeLabelId;
                int labelIdByteCount = 0;
                if (labelId != null)
                {
                    labelIdByteCount = Encoding.UTF8.GetByteCount(labelId);
                    if (labelIdByteCount > Util.StackAllocationSizeLimit)
                    {
                        nativeLabelId = Util.Allocate(labelIdByteCount + 1);
                    }
                    else
                    {
                        byte* nativeLabelIdStackBytes = stackalloc byte[labelIdByteCount + 1];
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
                        fixed (long* nativeNeg = &neg)
                        {
                            fixed (long* nativePos = &pos)
                            {
                                ImPlotNative.ImPlot_PlotErrorBars_S64PtrS64PtrS64PtrS64Ptr(nativeLabelId, nativeXs, nativeYs, nativeNeg, nativePos, count, flags, offset, stride);
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
            public static void PlotErrorBars(string labelId, ref ulong xs, ref ulong ys, ref ulong neg, ref ulong pos, int count)
            {
                byte* nativeLabelId;
                int labelIdByteCount = 0;
                if (labelId != null)
                {
                    labelIdByteCount = Encoding.UTF8.GetByteCount(labelId);
                    if (labelIdByteCount > Util.StackAllocationSizeLimit)
                    {
                        nativeLabelId = Util.Allocate(labelIdByteCount + 1);
                    }
                    else
                    {
                        byte* nativeLabelIdStackBytes = stackalloc byte[labelIdByteCount + 1];
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
                        fixed (ulong* nativeNeg = &neg)
                        {
                            fixed (ulong* nativePos = &pos)
                            {
                                ImPlotNative.ImPlot_PlotErrorBars_U64PtrU64PtrU64PtrU64Ptr(nativeLabelId, nativeXs, nativeYs, nativeNeg, nativePos, count, flags, offset, stride);
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
            public static void PlotErrorBars(string labelId, ref ulong xs, ref ulong ys, ref ulong neg, ref ulong pos, int count, ImPlotErrorBarsFlags flags)
            {
                byte* nativeLabelId;
                int labelIdByteCount = 0;
                if (labelId != null)
                {
                    labelIdByteCount = Encoding.UTF8.GetByteCount(labelId);
                    if (labelIdByteCount > Util.StackAllocationSizeLimit)
                    {
                        nativeLabelId = Util.Allocate(labelIdByteCount + 1);
                    }
                    else
                    {
                        byte* nativeLabelIdStackBytes = stackalloc byte[labelIdByteCount + 1];
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
                        fixed (ulong* nativeNeg = &neg)
                        {
                            fixed (ulong* nativePos = &pos)
                            {
                                ImPlotNative.ImPlot_PlotErrorBars_U64PtrU64PtrU64PtrU64Ptr(nativeLabelId, nativeXs, nativeYs, nativeNeg, nativePos, count, flags, offset, stride);
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
            public static void PlotErrorBars(string labelId, ref ulong xs, ref ulong ys, ref ulong neg, ref ulong pos, int count, ImPlotErrorBarsFlags flags, int offset)
            {
                byte* nativeLabelId;
                int labelIdByteCount = 0;
                if (labelId != null)
                {
                    labelIdByteCount = Encoding.UTF8.GetByteCount(labelId);
                    if (labelIdByteCount > Util.StackAllocationSizeLimit)
                    {
                        nativeLabelId = Util.Allocate(labelIdByteCount + 1);
                    }
                    else
                    {
                        byte* nativeLabelIdStackBytes = stackalloc byte[labelIdByteCount + 1];
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
                        fixed (ulong* nativeNeg = &neg)
                        {
                            fixed (ulong* nativePos = &pos)
                            {
                                ImPlotNative.ImPlot_PlotErrorBars_U64PtrU64PtrU64PtrU64Ptr(nativeLabelId, nativeXs, nativeYs, nativeNeg, nativePos, count, flags, offset, stride);
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
            public static void PlotErrorBars(string labelId, ref ulong xs, ref ulong ys, ref ulong neg, ref ulong pos, int count, ImPlotErrorBarsFlags flags, int offset, int stride)
            {
                byte* nativeLabelId;
                int labelIdByteCount = 0;
                if (labelId != null)
                {
                    labelIdByteCount = Encoding.UTF8.GetByteCount(labelId);
                    if (labelIdByteCount > Util.StackAllocationSizeLimit)
                    {
                        nativeLabelId = Util.Allocate(labelIdByteCount + 1);
                    }
                    else
                    {
                        byte* nativeLabelIdStackBytes = stackalloc byte[labelIdByteCount + 1];
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
                        fixed (ulong* nativeNeg = &neg)
                        {
                            fixed (ulong* nativePos = &pos)
                            {
                                ImPlotNative.ImPlot_PlotErrorBars_U64PtrU64PtrU64PtrU64Ptr(nativeLabelId, nativeXs, nativeYs, nativeNeg, nativePos, count, flags, offset, stride);
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
            ///     Plots the heatmap using the specified label id
            /// </summary>
            /// <param name="labelId">The label id</param>
            /// <param name="values">The values</param>
            /// <param name="rows">The rows</param>
            /// <param name="cols">The cols</param>
            public static void PlotHeatmap(string labelId, ref float values, int rows, int cols)
            {
                byte* nativeLabelId;
                int labelIdByteCount = 0;
                if (labelId != null)
                {
                    labelIdByteCount = Encoding.UTF8.GetByteCount(labelId);
                    if (labelIdByteCount > Util.StackAllocationSizeLimit)
                    {
                        nativeLabelId = Util.Allocate(labelIdByteCount + 1);
                    }
                    else
                    {
                        byte* nativeLabelIdStackBytes = stackalloc byte[labelIdByteCount + 1];
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
                fixed (float* nativeValues = &values)
                {
                    ImPlotNative.ImPlot_PlotHeatmap_FloatPtr(nativeLabelId, nativeValues, rows, cols, scaleMin, scaleMax, nativeLabelFmt, boundsMin, boundsMax, flags);
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
            public static void PlotHeatmap(string labelId, ref float values, int rows, int cols, double scaleMin)
            {
                byte* nativeLabelId;
                int labelIdByteCount = 0;
                if (labelId != null)
                {
                    labelIdByteCount = Encoding.UTF8.GetByteCount(labelId);
                    if (labelIdByteCount > Util.StackAllocationSizeLimit)
                    {
                        nativeLabelId = Util.Allocate(labelIdByteCount + 1);
                    }
                    else
                    {
                        byte* nativeLabelIdStackBytes = stackalloc byte[labelIdByteCount + 1];
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
                fixed (float* nativeValues = &values)
                {
                    ImPlotNative.ImPlot_PlotHeatmap_FloatPtr(nativeLabelId, nativeValues, rows, cols, scaleMin, scaleMax, nativeLabelFmt, boundsMin, boundsMax, flags);
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
            public static void PlotHeatmap(string labelId, ref float values, int rows, int cols, double scaleMin, double scaleMax)
            {
                byte* nativeLabelId;
                int labelIdByteCount = 0;
                if (labelId != null)
                {
                    labelIdByteCount = Encoding.UTF8.GetByteCount(labelId);
                    if (labelIdByteCount > Util.StackAllocationSizeLimit)
                    {
                        nativeLabelId = Util.Allocate(labelIdByteCount + 1);
                    }
                    else
                    {
                        byte* nativeLabelIdStackBytes = stackalloc byte[labelIdByteCount + 1];
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
                fixed (float* nativeValues = &values)
                {
                    ImPlotNative.ImPlot_PlotHeatmap_FloatPtr(nativeLabelId, nativeValues, rows, cols, scaleMin, scaleMax, nativeLabelFmt, boundsMin, boundsMax, flags);
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
            public static void PlotHeatmap(string labelId, ref float values, int rows, int cols, double scaleMin, double scaleMax, string labelFmt)
            {
                byte* nativeLabelId;
                int labelIdByteCount = 0;
                if (labelId != null)
                {
                    labelIdByteCount = Encoding.UTF8.GetByteCount(labelId);
                    if (labelIdByteCount > Util.StackAllocationSizeLimit)
                    {
                        nativeLabelId = Util.Allocate(labelIdByteCount + 1);
                    }
                    else
                    {
                        byte* nativeLabelIdStackBytes = stackalloc byte[labelIdByteCount + 1];
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
                fixed (float* nativeValues = &values)
                {
                    ImPlotNative.ImPlot_PlotHeatmap_FloatPtr(nativeLabelId, nativeValues, rows, cols, scaleMin, scaleMax, nativeLabelFmt, boundsMin, boundsMax, flags);
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
            public static void PlotHeatmap(string labelId, ref float values, int rows, int cols, double scaleMin, double scaleMax, string labelFmt, ImPlotPoint boundsMin)
            {
                byte* nativeLabelId;
                int labelIdByteCount = 0;
                if (labelId != null)
                {
                    labelIdByteCount = Encoding.UTF8.GetByteCount(labelId);
                    if (labelIdByteCount > Util.StackAllocationSizeLimit)
                    {
                        nativeLabelId = Util.Allocate(labelIdByteCount + 1);
                    }
                    else
                    {
                        byte* nativeLabelIdStackBytes = stackalloc byte[labelIdByteCount + 1];
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
                fixed (float* nativeValues = &values)
                {
                    ImPlotNative.ImPlot_PlotHeatmap_FloatPtr(nativeLabelId, nativeValues, rows, cols, scaleMin, scaleMax, nativeLabelFmt, boundsMin, boundsMax, flags);
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
            public static void PlotHeatmap(string labelId, ref float values, int rows, int cols, double scaleMin, double scaleMax, string labelFmt, ImPlotPoint boundsMin, ImPlotPoint boundsMax)
            {
                byte* nativeLabelId;
                int labelIdByteCount = 0;
                if (labelId != null)
                {
                    labelIdByteCount = Encoding.UTF8.GetByteCount(labelId);
                    if (labelIdByteCount > Util.StackAllocationSizeLimit)
                    {
                        nativeLabelId = Util.Allocate(labelIdByteCount + 1);
                    }
                    else
                    {
                        byte* nativeLabelIdStackBytes = stackalloc byte[labelIdByteCount + 1];
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
                fixed (float* nativeValues = &values)
                {
                    ImPlotNative.ImPlot_PlotHeatmap_FloatPtr(nativeLabelId, nativeValues, rows, cols, scaleMin, scaleMax, nativeLabelFmt, boundsMin, boundsMax, flags);
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
            public static void PlotHeatmap(string labelId, ref float values, int rows, int cols, double scaleMin, double scaleMax, string labelFmt, ImPlotPoint boundsMin, ImPlotPoint boundsMax, ImPlotHeatmapFlags flags)
            {
                byte* nativeLabelId;
                int labelIdByteCount = 0;
                if (labelId != null)
                {
                    labelIdByteCount = Encoding.UTF8.GetByteCount(labelId);
                    if (labelIdByteCount > Util.StackAllocationSizeLimit)
                    {
                        nativeLabelId = Util.Allocate(labelIdByteCount + 1);
                    }
                    else
                    {
                        byte* nativeLabelIdStackBytes = stackalloc byte[labelIdByteCount + 1];
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
                
                fixed (float* nativeValues = &values)
                {
                    ImPlotNative.ImPlot_PlotHeatmap_FloatPtr(nativeLabelId, nativeValues, rows, cols, scaleMin, scaleMax, nativeLabelFmt, boundsMin, boundsMax, flags);
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
            public static void PlotHeatmap(string labelId, ref double values, int rows, int cols)
            {
                byte* nativeLabelId;
                int labelIdByteCount = 0;
                if (labelId != null)
                {
                    labelIdByteCount = Encoding.UTF8.GetByteCount(labelId);
                    if (labelIdByteCount > Util.StackAllocationSizeLimit)
                    {
                        nativeLabelId = Util.Allocate(labelIdByteCount + 1);
                    }
                    else
                    {
                        byte* nativeLabelIdStackBytes = stackalloc byte[labelIdByteCount + 1];
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
            public static void PlotHeatmap(string labelId, ref double values, int rows, int cols, double scaleMin)
            {
                byte* nativeLabelId;
                int labelIdByteCount = 0;
                if (labelId != null)
                {
                    labelIdByteCount = Encoding.UTF8.GetByteCount(labelId);
                    if (labelIdByteCount > Util.StackAllocationSizeLimit)
                    {
                        nativeLabelId = Util.Allocate(labelIdByteCount + 1);
                    }
                    else
                    {
                        byte* nativeLabelIdStackBytes = stackalloc byte[labelIdByteCount + 1];
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
            public static void PlotHeatmap(string labelId, ref double values, int rows, int cols, double scaleMin, double scaleMax)
            {
                byte* nativeLabelId;
                int labelIdByteCount = 0;
                if (labelId != null)
                {
                    labelIdByteCount = Encoding.UTF8.GetByteCount(labelId);
                    if (labelIdByteCount > Util.StackAllocationSizeLimit)
                    {
                        nativeLabelId = Util.Allocate(labelIdByteCount + 1);
                    }
                    else
                    {
                        byte* nativeLabelIdStackBytes = stackalloc byte[labelIdByteCount + 1];
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
            public static void PlotHeatmap(string labelId, ref double values, int rows, int cols, double scaleMin, double scaleMax, string labelFmt)
            {
                byte* nativeLabelId;
                int labelIdByteCount = 0;
                if (labelId != null)
                {
                    labelIdByteCount = Encoding.UTF8.GetByteCount(labelId);
                    if (labelIdByteCount > Util.StackAllocationSizeLimit)
                    {
                        nativeLabelId = Util.Allocate(labelIdByteCount + 1);
                    }
                    else
                    {
                        byte* nativeLabelIdStackBytes = stackalloc byte[labelIdByteCount + 1];
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
        }
}

        