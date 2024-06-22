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
    public static partial class ImPlot
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
                ImPlotNative.ImPlot_PlotErrorBars_S8PtrS8PtrS8PtrS8Ptr(Encoding.UTF8.GetBytes(labelId), ref xs, ref ys, neg, pos, count, flags, 0, sizeof(sbyte));
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
                ImPlotNative.ImPlot_PlotErrorBars_S8PtrS8PtrS8PtrS8Ptr(Encoding.UTF8.GetBytes(labelId), ref xs, ref ys, neg, pos, count, flags, offset, sizeof(sbyte));
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
                ImPlotNative.ImPlot_PlotErrorBars_S8PtrS8PtrS8PtrS8Ptr(Encoding.UTF8.GetBytes(labelId), ref xs, ref ys, neg, pos, count, flags, offset, stride);
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
                ImPlotNative.ImPlot_PlotErrorBars_U8PtrU8PtrU8PtrU8Ptr(Encoding.UTF8.GetBytes(labelId), xs, ys, neg, pos, count, 0, 0, sizeof(byte));
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
                ImPlotNative.ImPlot_PlotErrorBars_U8PtrU8PtrU8PtrU8Ptr(Encoding.UTF8.GetBytes(labelId), xs, ys, neg, pos, count, flags, 0, sizeof(byte));
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
                ImPlotNative.ImPlot_PlotErrorBars_U8PtrU8PtrU8PtrU8Ptr(Encoding.UTF8.GetBytes(labelId), xs, ys, neg, pos, count, flags, offset, sizeof(byte));
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
                ImPlotNative.ImPlot_PlotErrorBars_U8PtrU8PtrU8PtrU8Ptr(Encoding.UTF8.GetBytes(labelId), xs, ys, neg, pos, count, flags, offset, stride);
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
                ImPlotNative.ImPlot_PlotErrorBars_S16PtrS16PtrS16PtrS16Ptr(Encoding.UTF8.GetBytes(labelId), xs, ys, neg, pos, count, 0, 0, sizeof(short));
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
                ImPlotNative.ImPlot_PlotErrorBars_S16PtrS16PtrS16PtrS16Ptr(Encoding.UTF8.GetBytes(labelId), xs, ys, neg, pos, count, flags, 0, sizeof(short));
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
                ImPlotNative.ImPlot_PlotErrorBars_S16PtrS16PtrS16PtrS16Ptr(Encoding.UTF8.GetBytes(labelId), xs, ys, neg, pos, count, flags, offset, sizeof(short));
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
                ImPlotNative.ImPlot_PlotErrorBars_S16PtrS16PtrS16PtrS16Ptr(Encoding.UTF8.GetBytes(labelId), xs, ys, neg, pos, count, flags, offset, stride);
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
                ImPlotNative.ImPlot_PlotErrorBars_U16PtrU16PtrU16PtrU16Ptr(Encoding.UTF8.GetBytes(labelId), ref xs, ref ys, neg, pos, count, 0, 0, sizeof(ushort));
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
                ImPlotNative.ImPlot_PlotErrorBars_U16PtrU16PtrU16PtrU16Ptr(Encoding.UTF8.GetBytes(labelId), ref xs, ref ys, neg, pos, count, flags, 0, sizeof(ushort));
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
                ImPlotNative.ImPlot_PlotErrorBars_U16PtrU16PtrU16PtrU16Ptr(Encoding.UTF8.GetBytes(labelId), ref xs, ref ys, neg, pos, count, flags, offset, sizeof(ushort));
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
                ImPlotNative.ImPlot_PlotErrorBars_U16PtrU16PtrU16PtrU16Ptr(Encoding.UTF8.GetBytes(labelId), ref xs, ref ys, neg, pos, count, flags, offset, stride);
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
                ImPlotNative.ImPlot_PlotErrorBars_S32PtrS32PtrS32PtrS32Ptr(Encoding.UTF8.GetBytes(labelId), xs, ys, neg, pos, count, 0, 0, sizeof(int));
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
                ImPlotNative.ImPlot_PlotErrorBars_S32PtrS32PtrS32PtrS32Ptr(Encoding.UTF8.GetBytes(labelId), xs, ys, neg, pos, count, flags, 0, sizeof(int));
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
                ImPlotNative.ImPlot_PlotErrorBars_S32PtrS32PtrS32PtrS32Ptr(Encoding.UTF8.GetBytes(labelId), xs, ys, neg, pos, count, flags, offset, sizeof(int));
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
                ImPlotNative.ImPlot_PlotErrorBars_S32PtrS32PtrS32PtrS32Ptr(Encoding.UTF8.GetBytes(labelId), xs, ys, neg, pos, count, flags, offset, stride);
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
                ImPlotNative.ImPlot_PlotErrorBars_U32PtrU32PtrU32PtrU32Ptr(Encoding.UTF8.GetBytes(labelId), xs, ys, neg, pos, count, 0, 0, sizeof(uint));
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
                ImPlotNative.ImPlot_PlotErrorBars_U32PtrU32PtrU32PtrU32Ptr(Encoding.UTF8.GetBytes(labelId), xs, ys, neg, pos, count, flags, 0, sizeof(uint));
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
                ImPlotNative.ImPlot_PlotErrorBars_U32PtrU32PtrU32PtrU32Ptr(Encoding.UTF8.GetBytes(labelId), xs, ys, neg, pos, count, flags, offset, sizeof(uint));
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
                ImPlotNative.ImPlot_PlotErrorBars_U32PtrU32PtrU32PtrU32Ptr(Encoding.UTF8.GetBytes(labelId), xs, ys, neg, pos, count, flags, offset, stride);
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
                ImPlotNative.ImPlot_PlotErrorBars_S64PtrS64PtrS64PtrS64Ptr(Encoding.UTF8.GetBytes(labelId), ref xs, ref ys, neg, pos, count, 0, 0, sizeof(long));
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
                ImPlotNative.ImPlot_PlotErrorBars_S64PtrS64PtrS64PtrS64Ptr(Encoding.UTF8.GetBytes(labelId), ref xs, ref ys, neg, pos, count, flags, 0, sizeof(long));
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
                ImPlotNative.ImPlot_PlotErrorBars_S64PtrS64PtrS64PtrS64Ptr(Encoding.UTF8.GetBytes(labelId), ref xs, ref ys, neg, pos, count, flags, offset, sizeof(long));
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
                ImPlotNative.ImPlot_PlotErrorBars_S64PtrS64PtrS64PtrS64Ptr(Encoding.UTF8.GetBytes(labelId), ref xs, ref ys, neg, pos, count, flags, offset, stride);
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
                ImPlotNative.ImPlot_PlotErrorBars_U64PtrU64PtrU64PtrU64Ptr(Encoding.UTF8.GetBytes(labelId), ref xs, ref ys, neg, pos, count, 0, 0, sizeof(ulong));
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
                ImPlotNative.ImPlot_PlotErrorBars_U64PtrU64PtrU64PtrU64Ptr(Encoding.UTF8.GetBytes(labelId), ref xs, ref ys, neg, pos, count, flags, 0, sizeof(ulong));
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
                ImPlotNative.ImPlot_PlotErrorBars_U64PtrU64PtrU64PtrU64Ptr(Encoding.UTF8.GetBytes(labelId), ref xs, ref ys, neg, pos, count, flags, offset, sizeof(ulong));
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
                ImPlotNative.ImPlot_PlotErrorBars_U64PtrU64PtrU64PtrU64Ptr(Encoding.UTF8.GetBytes(labelId), ref xs, ref ys, neg, pos, count, flags, offset, stride);
            }
            
            /// <summary>
            ///     Plots the heatmap using the specified label id
            /// </summary>
            /// <param name="labelId">The label id</param>
            /// <param name="values">The values</param>
            /// <param name="rows">The rows</param>
            /// <param name="cols">The cols</param>
            public static void PlotHeatmap(string labelId, float[] values, int rows, int cols)
            {
                ImPlotNative.ImPlot_PlotHeatmap_FloatPtr(Encoding.UTF8.GetBytes(labelId), values, rows, cols, 0, 0, Encoding.UTF8.GetBytes("%.1f"), new ImPlotPoint {X = 0, Y = 0}, new ImPlotPoint {X = 1, Y = 1}, 0);
            }
            
            /// <summary>
            ///     Plots the heatmap using the specified label id
            /// </summary>
            /// <param name="labelId">The label id</param>
            /// <param name="values">The values</param>
            /// <param name="rows">The rows</param>
            /// <param name="cols">The cols</param>
            /// <param name="scaleMin">The scale min</param>
            public static void PlotHeatmap(string labelId, float[] values, int rows, int cols, double scaleMin)
            {
                ImPlotNative.ImPlot_PlotHeatmap_FloatPtr(Encoding.UTF8.GetBytes(labelId), values, rows, cols, scaleMin, 0, Encoding.UTF8.GetBytes("%.1f"), new ImPlotPoint {X = 0, Y = 0}, new ImPlotPoint {X = 1, Y = 1}, 0);
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
            public static void PlotHeatmap(string labelId, float[] values, int rows, int cols, double scaleMin, double scaleMax)
            {
                ImPlotNative.ImPlot_PlotHeatmap_FloatPtr(Encoding.UTF8.GetBytes(labelId), values, rows, cols, scaleMin, scaleMax, Encoding.UTF8.GetBytes("%.1f"), new ImPlotPoint {X = 0, Y = 0}, new ImPlotPoint {X = 1, Y = 1}, 0);
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
            public static void PlotHeatmap(string labelId, float[] values, int rows, int cols, double scaleMin, double scaleMax, string labelFmt)
            {
                ImPlotNative.ImPlot_PlotHeatmap_FloatPtr(Encoding.UTF8.GetBytes(labelId), values, rows, cols, scaleMin, scaleMax, Encoding.UTF8.GetBytes(labelFmt), new ImPlotPoint {X = 0, Y = 0}, new ImPlotPoint {X = 1, Y = 1}, 0);
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
            public static void PlotHeatmap(string labelId, float[] values, int rows, int cols, double scaleMin, double scaleMax, string labelFmt, ImPlotPoint boundsMin)
            {
                ImPlotNative.ImPlot_PlotHeatmap_FloatPtr(Encoding.UTF8.GetBytes(labelId), values, rows, cols, scaleMin, scaleMax, Encoding.UTF8.GetBytes(labelFmt), boundsMin, new ImPlotPoint {X = 1, Y = 1}, 0);
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
            public static void PlotHeatmap(string labelId, float[] values, int rows, int cols, double scaleMin, double scaleMax, string labelFmt, ImPlotPoint boundsMin, ImPlotPoint boundsMax)
            {
                ImPlotNative.ImPlot_PlotHeatmap_FloatPtr(Encoding.UTF8.GetBytes(labelId), values, rows, cols, scaleMin, scaleMax, Encoding.UTF8.GetBytes(labelFmt), boundsMin, boundsMax, 0);
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
            public static void PlotHeatmap(string labelId, float[] values, int rows, int cols, double scaleMin, double scaleMax, string labelFmt, ImPlotPoint boundsMin, ImPlotPoint boundsMax, ImPlotHeatmapFlags flags)
            {
                ImPlotNative.ImPlot_PlotHeatmap_FloatPtr(Encoding.UTF8.GetBytes(labelId), values, rows, cols, scaleMin, scaleMax, Encoding.UTF8.GetBytes(labelFmt), boundsMin, boundsMax, flags);
            }
            
            /// <summary>
            ///     Plots the heatmap using the specified label id
            /// </summary>
            /// <param name="labelId">The label id</param>
            /// <param name="values">The values</param>
            /// <param name="rows">The rows</param>
            /// <param name="cols">The cols</param>
            public static void PlotHeatmap(string labelId, double[] values, int rows, int cols)
            {
                ImPlotNative.ImPlot_PlotHeatmap_doublePtr(Encoding.UTF8.GetBytes(labelId), values, rows, cols, 0, 0, Encoding.UTF8.GetBytes("%.1f"), new ImPlotPoint {X = 0, Y = 0}, new ImPlotPoint {X = 1, Y = 1}, 0);
            }
            
            /// <summary>
            ///     Plots the heatmap using the specified label id
            /// </summary>
            /// <param name="labelId">The label id</param>
            /// <param name="values">The values</param>
            /// <param name="rows">The rows</param>
            /// <param name="cols">The cols</param>
            /// <param name="scaleMin">The scale min</param>
            public static void PlotHeatmap(string labelId, double[] values, int rows, int cols, double scaleMin)
            {
                ImPlotNative.ImPlot_PlotHeatmap_doublePtr(Encoding.UTF8.GetBytes(labelId), values, rows, cols, scaleMin, 0, Encoding.UTF8.GetBytes("%.1f"), new ImPlotPoint {X = 0, Y = 0}, new ImPlotPoint {X = 1, Y = 1}, 0);
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
            public static void PlotHeatmap(string labelId, double[] values, int rows, int cols, double scaleMin, double scaleMax)
            {
                ImPlotNative.ImPlot_PlotHeatmap_doublePtr(Encoding.UTF8.GetBytes(labelId), values, rows, cols, scaleMin, scaleMax, Encoding.UTF8.GetBytes("%.1f"), new ImPlotPoint {X = 0, Y = 0}, new ImPlotPoint {X = 1, Y = 1}, 0);
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
            public static void PlotHeatmap(string labelId, double[] values, int rows, int cols, double scaleMin, double scaleMax, string labelFmt)
            {
                ImPlotNative.ImPlot_PlotHeatmap_doublePtr(Encoding.UTF8.GetBytes(labelId), values, rows, cols, scaleMin, scaleMax, Encoding.UTF8.GetBytes(labelFmt), new ImPlotPoint {X = 0, Y = 0}, new ImPlotPoint {X = 1, Y = 1}, 0);
            }
        }
}

        