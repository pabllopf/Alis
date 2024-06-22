// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImPlotP8.cs
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
    /// <summary>
    /// The im plot class
    /// </summary>
    public static partial class ImPlot
    {
        
        /// <summary>
        ///     Plots the shaded using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys1">The ys</param>
        /// <param name="ys2">The ys</param>
        /// <param name="count">The count</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        public static void PlotShaded(string labelId, ref sbyte xs, ref sbyte ys1, ref sbyte ys2, int count, ImPlotShadedFlags flags, int offset)
        {
            ImPlotNative.ImPlot_PlotShaded_S8PtrS8PtrS8Ptr(Encoding.UTF8.GetBytes(labelId), ref xs, ref ys1, ref ys2, count, flags, offset, sizeof(sbyte));
        }
        
        /// <summary>
        ///     Plots the shaded using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys1">The ys</param>
        /// <param name="ys2">The ys</param>
        /// <param name="count">The count</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        /// <param name="stride">The stride</param>
        public static void PlotShaded(string labelId, ref sbyte xs, ref sbyte ys1, ref sbyte ys2, int count, ImPlotShadedFlags flags, int offset, int stride)
        {
            ImPlotNative.ImPlot_PlotShaded_S8PtrS8PtrS8Ptr(Encoding.UTF8.GetBytes(labelId), ref xs, ref ys1, ref ys2, count, flags, offset, stride);
        }
        
        /// <summary>
        ///     Plots the shaded using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys1">The ys</param>
        /// <param name="ys2">The ys</param>
        /// <param name="count">The count</param>
        public static void PlotShaded(string labelId, ref byte xs, ref byte ys1, ref byte ys2, int count)
        {
            ImPlotNative.ImPlot_PlotShaded_U8PtrU8PtrU8Ptr(Encoding.UTF8.GetBytes(labelId), ref xs, ref ys1, ref ys2, count, 0, 0, sizeof(byte));
        }
        
        /// <summary>
        ///     Plots the shaded using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys1">The ys</param>
        /// <param name="ys2">The ys</param>
        /// <param name="count">The count</param>
        /// <param name="flags">The flags</param>
        public static void PlotShaded(string labelId, ref byte xs, ref byte ys1, ref byte ys2, int count, ImPlotShadedFlags flags)
        {
            ImPlotNative.ImPlot_PlotShaded_U8PtrU8PtrU8Ptr(Encoding.UTF8.GetBytes(labelId), ref xs, ref ys1, ref ys2, count, flags, 0, sizeof(byte));
        }
        
        /// <summary>
        ///     Plots the shaded using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys1">The ys</param>
        /// <param name="ys2">The ys</param>
        /// <param name="count">The count</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        public static void PlotShaded(string labelId, ref byte xs, ref byte ys1, ref byte ys2, int count, ImPlotShadedFlags flags, int offset)
        {
            ImPlotNative.ImPlot_PlotShaded_U8PtrU8PtrU8Ptr(Encoding.UTF8.GetBytes(labelId), ref xs, ref ys1, ref ys2, count, flags, offset, sizeof(byte));
        }
        
        /// <summary>
        ///     Plots the shaded using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys1">The ys</param>
        /// <param name="ys2">The ys</param>
        /// <param name="count">The count</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        /// <param name="stride">The stride</param>
        public static void PlotShaded(string labelId, ref byte xs, ref byte ys1, ref byte ys2, int count, ImPlotShadedFlags flags, int offset, int stride)
        {
            ImPlotNative.ImPlot_PlotShaded_U8PtrU8PtrU8Ptr(Encoding.UTF8.GetBytes(labelId), ref xs, ref ys1, ref ys2, count, flags, offset, stride);
        }
        
        /// <summary>
        ///     Plots the shaded using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys1">The ys</param>
        /// <param name="ys2">The ys</param>
        /// <param name="count">The count</param>
        public static void PlotShaded(string labelId, ref short xs, ref short ys1, ref short ys2, int count)
        {
            ImPlotNative.ImPlot_PlotShaded_S16PtrS16PtrS16Ptr(Encoding.UTF8.GetBytes(labelId), xs, ys1, ys2, count, 0, 0, sizeof(short));
        }
        
        /// <summary>
        ///     Plots the shaded using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys1">The ys</param>
        /// <param name="ys2">The ys</param>
        /// <param name="count">The count</param>
        /// <param name="flags">The flags</param>
        public static void PlotShaded(string labelId, ref short xs, ref short ys1, ref short ys2, int count, ImPlotShadedFlags flags)
        {
            ImPlotNative.ImPlot_PlotShaded_S16PtrS16PtrS16Ptr(Encoding.UTF8.GetBytes(labelId), xs, ys1, ys2, count, flags, 0, sizeof(short));
        }
        
        /// <summary>
        ///     Plots the shaded using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys1">The ys</param>
        /// <param name="ys2">The ys</param>
        /// <param name="count">The count</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        public static void PlotShaded(string labelId, ref short xs, ref short ys1, ref short ys2, int count, ImPlotShadedFlags flags, int offset)
        {
            ImPlotNative.ImPlot_PlotShaded_S16PtrS16PtrS16Ptr(Encoding.UTF8.GetBytes(labelId), xs, ys1, ys2, count, flags, offset, sizeof(short));
        }
        
        /// <summary>
        ///     Plots the shaded using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys1">The ys</param>
        /// <param name="ys2">The ys</param>
        /// <param name="count">The count</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        /// <param name="stride">The stride</param>
        public static void PlotShaded(string labelId, ref short xs, ref short ys1, ref short ys2, int count, ImPlotShadedFlags flags, int offset, int stride)
        {
            ImPlotNative.ImPlot_PlotShaded_S16PtrS16PtrS16Ptr(Encoding.UTF8.GetBytes(labelId), xs, ys1, ys2, count, flags, offset, stride);
        }
        
        /// <summary>
        ///     Plots the shaded using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys1">The ys</param>
        /// <param name="ys2">The ys</param>
        /// <param name="count">The count</param>
        public static void PlotShaded(string labelId, ref ushort xs, ref ushort ys1, ref ushort ys2, int count)
        {
            ImPlotNative.ImPlot_PlotShaded_U16PtrU16PtrU16Ptr(Encoding.UTF8.GetBytes(labelId), ref xs, ys1, ys2, count, 0, 0, sizeof(ushort));
        }
        
        /// <summary>
        ///     Plots the shaded using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys1">The ys</param>
        /// <param name="ys2">The ys</param>
        /// <param name="count">The count</param>
        /// <param name="flags">The flags</param>
        public static void PlotShaded(string labelId, ref ushort xs, ref ushort ys1, ref ushort ys2, int count, ImPlotShadedFlags flags)
        {
               ImPlotNative.ImPlot_PlotShaded_U16PtrU16PtrU16Ptr(Encoding.UTF8.GetBytes(labelId), ref xs, ys1, ys2, count, flags, 0, sizeof(ushort));
        }
        
        /// <summary>
        ///     Plots the shaded using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys1">The ys</param>
        /// <param name="ys2">The ys</param>
        /// <param name="count">The count</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        public static void PlotShaded(string labelId, ref ushort xs, ref ushort ys1, ref ushort ys2, int count, ImPlotShadedFlags flags, int offset)
        {
            ImPlotNative.ImPlot_PlotShaded_U16PtrU16PtrU16Ptr(Encoding.UTF8.GetBytes(labelId), ref xs, ys1, ys2, count, flags, offset, sizeof(ushort));
        }
        
        /// <summary>
        ///     Plots the shaded using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys1">The ys</param>
        /// <param name="ys2">The ys</param>
        /// <param name="count">The count</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        /// <param name="stride">The stride</param>
        public static void PlotShaded(string labelId, ref ushort xs, ref ushort ys1, ref ushort ys2, int count, ImPlotShadedFlags flags, int offset, int stride)
        {
            ImPlotNative.ImPlot_PlotShaded_U16PtrU16PtrU16Ptr(Encoding.UTF8.GetBytes(labelId), ref xs, ys1, ys2, count, flags, offset, stride);
        }
        
        /// <summary>
        ///     Plots the shaded using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys1">The ys</param>
        /// <param name="ys2">The ys</param>
        /// <param name="count">The count</param>
        public static void PlotShaded(string labelId, ref int xs, ref int ys1, ref int ys2, int count)
        {
            ImPlotNative.ImPlot_PlotShaded_S32PtrS32PtrS32Ptr(Encoding.UTF8.GetBytes(labelId), xs, ys1, ys2, count, 0, 0, sizeof(int));
        }
        
        /// <summary>
        ///     Plots the shaded using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys1">The ys</param>
        /// <param name="ys2">The ys</param>
        /// <param name="count">The count</param>
        /// <param name="flags">The flags</param>
        public static void PlotShaded(string labelId, ref int xs, ref int ys1, ref int ys2, int count, ImPlotShadedFlags flags)
        {
            ImPlotNative.ImPlot_PlotShaded_S32PtrS32PtrS32Ptr(Encoding.UTF8.GetBytes(labelId), xs, ys1, ys2, count, flags, 0, sizeof(int));
        }
        
        /// <summary>
        ///     Plots the shaded using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys1">The ys</param>
        /// <param name="ys2">The ys</param>
        /// <param name="count">The count</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        public static void PlotShaded(string labelId, ref int xs, ref int ys1, ref int ys2, int count, ImPlotShadedFlags flags, int offset)
        {
            ImPlotNative.ImPlot_PlotShaded_S32PtrS32PtrS32Ptr(Encoding.UTF8.GetBytes(labelId), xs, ys1, ys2, count, flags, offset, sizeof(int));
        }
        
        /// <summary>
        ///     Plots the shaded using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys1">The ys</param>
        /// <param name="ys2">The ys</param>
        /// <param name="count">The count</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        /// <param name="stride">The stride</param>
        public static void PlotShaded(string labelId, ref int xs, ref int ys1, ref int ys2, int count, ImPlotShadedFlags flags, int offset, int stride)
        {
            ImPlotNative.ImPlot_PlotShaded_S32PtrS32PtrS32Ptr(Encoding.UTF8.GetBytes(labelId), xs, ys1, ys2, count, flags, offset, stride);
        }
        
        /// <summary>
        ///     Plots the shaded using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys1">The ys</param>
        /// <param name="ys2">The ys</param>
        /// <param name="count">The count</param>
        public static void PlotShaded(string labelId, ref uint xs, ref uint ys1, ref uint ys2, int count)
        {
            ImPlotNative.ImPlot_PlotShaded_U32PtrU32PtrU32Ptr(Encoding.UTF8.GetBytes(labelId), xs, ys1, ys2, count, 0, 0, sizeof(uint));
        }
        
        /// <summary>
        ///     Plots the shaded using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys1">The ys</param>
        /// <param name="ys2">The ys</param>
        /// <param name="count">The count</param>
        /// <param name="flags">The flags</param>
        public static void PlotShaded(string labelId, ref uint xs, ref uint ys1, ref uint ys2, int count, ImPlotShadedFlags flags)
        {
            ImPlotNative.ImPlot_PlotShaded_U32PtrU32PtrU32Ptr(Encoding.UTF8.GetBytes(labelId), xs, ys1, ys2, count, flags, 0, sizeof(uint));
        }
        
        /// <summary>
        ///     Plots the shaded using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys1">The ys</param>
        /// <param name="ys2">The ys</param>
        /// <param name="count">The count</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        public static void PlotShaded(string labelId, ref uint xs, ref uint ys1, ref uint ys2, int count, ImPlotShadedFlags flags, int offset)
        {
            ImPlotNative.ImPlot_PlotShaded_U32PtrU32PtrU32Ptr(Encoding.UTF8.GetBytes(labelId), xs, ys1, ys2, count, flags, offset, sizeof(uint));
        }
        
        /// <summary>
        ///     Plots the shaded using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys1">The ys</param>
        /// <param name="ys2">The ys</param>
        /// <param name="count">The count</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        /// <param name="stride">The stride</param>
        public static void PlotShaded(string labelId, ref uint xs, ref uint ys1, ref uint ys2, int count, ImPlotShadedFlags flags, int offset, int stride)
        {
            ImPlotNative.ImPlot_PlotShaded_U32PtrU32PtrU32Ptr(Encoding.UTF8.GetBytes(labelId), xs, ys1, ys2, count, flags, offset, stride);
        }
        
        /// <summary>
        ///     Plots the shaded using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys1">The ys</param>
        /// <param name="ys2">The ys</param>
        /// <param name="count">The count</param>
        public static void PlotShaded(string labelId, ref long xs, ref long ys1, ref long ys2, int count)
        {
            ImPlotNative.ImPlot_PlotShaded_S64PtrS64PtrS64Ptr(Encoding.UTF8.GetBytes(labelId), ref xs, ys1, ys2, count, 0, 0, sizeof(long));
        }
        
        /// <summary>
        ///     Plots the shaded using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys1">The ys</param>
        /// <param name="ys2">The ys</param>
        /// <param name="count">The count</param>
        /// <param name="flags">The flags</param>
        public static void PlotShaded(string labelId, ref long xs, ref long ys1, ref long ys2, int count, ImPlotShadedFlags flags)
        {
            ImPlotNative.ImPlot_PlotShaded_S64PtrS64PtrS64Ptr(Encoding.UTF8.GetBytes(labelId), ref xs, ys1, ys2, count, flags, 0, sizeof(long));
        }
        
        /// <summary>
        ///     Plots the shaded using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys1">The ys</param>
        /// <param name="ys2">The ys</param>
        /// <param name="count">The count</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        public static void PlotShaded(string labelId, ref long xs, ref long ys1, ref long ys2, int count, ImPlotShadedFlags flags, int offset)
        {
            ImPlotNative.ImPlot_PlotShaded_S64PtrS64PtrS64Ptr(Encoding.UTF8.GetBytes(labelId), ref xs, ys1, ys2, count, flags, offset, sizeof(long));
        }
        
        /// <summary>
        ///     Plots the shaded using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys1">The ys</param>
        /// <param name="ys2">The ys</param>
        /// <param name="count">The count</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        /// <param name="stride">The stride</param>
        public static void PlotShaded(string labelId, ref long xs, ref long ys1, ref long ys2, int count, ImPlotShadedFlags flags, int offset, int stride)
        {
            ImPlotNative.ImPlot_PlotShaded_S64PtrS64PtrS64Ptr(Encoding.UTF8.GetBytes(labelId), ref xs, ys1, ys2, count, flags, offset, stride);
        }
        
        /// <summary>
        ///     Plots the shaded using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys1">The ys</param>
        /// <param name="ys2">The ys</param>
        /// <param name="count">The count</param>
        public static void PlotShaded(string labelId, ref ulong xs, ref ulong ys1, ref ulong ys2, int count)
        {
            ImPlotNative.ImPlot_PlotShaded_U64PtrU64PtrU64Ptr(Encoding.UTF8.GetBytes(labelId), ref xs, ys1, ys2, count, 0, 0, sizeof(ulong));
        }
        
        /// <summary>
        ///     Plots the shaded using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys1">The ys</param>
        /// <param name="ys2">The ys</param>
        /// <param name="count">The count</param>
        /// <param name="flags">The flags</param>
        public static void PlotShaded(string labelId, ref ulong xs, ref ulong ys1, ref ulong ys2, int count, ImPlotShadedFlags flags)
        {
            ImPlotNative.ImPlot_PlotShaded_U64PtrU64PtrU64Ptr(Encoding.UTF8.GetBytes(labelId), ref xs, ys1, ys2, count, flags, 0, sizeof(ulong));
        }
        
        /// <summary>
        ///     Plots the shaded using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys1">The ys</param>
        /// <param name="ys2">The ys</param>
        /// <param name="count">The count</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        public static void PlotShaded(string labelId, ref ulong xs, ref ulong ys1, ref ulong ys2, int count, ImPlotShadedFlags flags, int offset)
        {
            ImPlotNative.ImPlot_PlotShaded_U64PtrU64PtrU64Ptr(Encoding.UTF8.GetBytes(labelId), ref xs, ys1, ys2, count, flags, offset, sizeof(ulong));
        }
        
        /// <summary>
        ///     Plots the shaded using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys1">The ys</param>
        /// <param name="ys2">The ys</param>
        /// <param name="count">The count</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        /// <param name="stride">The stride</param>
        public static void PlotShaded(string labelId, ref ulong xs, ref ulong ys1, ref ulong ys2, int count, ImPlotShadedFlags flags, int offset, int stride)
        {
            ImPlotNative.ImPlot_PlotShaded_U64PtrU64PtrU64Ptr(Encoding.UTF8.GetBytes(labelId), ref xs, ys1, ys2, count, flags, offset, stride);
        }
        
        /// <summary>
        ///     Plots the shaded g using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="getter1">The getter</param>
        /// <param name="data1">The data</param>
        /// <param name="getter2">The getter</param>
        /// <param name="data2">The data</param>
        /// <param name="count">The count</param>
        public static void PlotShadedG(string labelId, IntPtr getter1, IntPtr data1, IntPtr getter2, IntPtr data2, int count)
        {
            ImPlotNative.ImPlot_PlotShadedG(Encoding.UTF8.GetBytes(labelId), getter1, data1, getter2, data2, count, 0);
        }
        
        /// <summary>
        ///     Plots the shaded g using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="getter1">The getter</param>
        /// <param name="data1">The data</param>
        /// <param name="getter2">The getter</param>
        /// <param name="data2">The data</param>
        /// <param name="count">The count</param>
        /// <param name="flags">The flags</param>
        public static void PlotShadedG(string labelId, IntPtr getter1, IntPtr data1, IntPtr getter2, IntPtr data2, int count, ImPlotShadedFlags flags)
        {
            ImPlotNative.ImPlot_PlotShadedG(Encoding.UTF8.GetBytes(labelId), getter1, data1, getter2, data2, count, flags);
        }
        
        /// <summary>
        ///     Plots the stairs using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        public static void PlotStairs(string labelId, float[] values, int count)
        {
            ImPlotNative.ImPlot_PlotStairs_FloatPtrInt(Encoding.UTF8.GetBytes(labelId), values, count, 1, 0, 0, 0, sizeof(float));
        }
        
        /// <summary>
        ///     Plots the stairs using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="xscale">The xscale</param>
        public static void PlotStairs(string labelId, float[] values, int count, double xscale)
        {
            ImPlotNative.ImPlot_PlotStairs_FloatPtrInt(Encoding.UTF8.GetBytes(labelId), values, count, xscale, 0, 0, 0, sizeof(float)); 
        }
        
        /// <summary>
        ///     Plots the stairs using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="xscale">The xscale</param>
        /// <param name="xstart">The xstart</param>
        public static void PlotStairs(string labelId, float[] values, int count, double xscale, double xstart)
        {
            ImPlotNative.ImPlot_PlotStairs_FloatPtrInt(Encoding.UTF8.GetBytes(labelId), values, count, xscale, xstart, 0, 0, sizeof(float)); 
        }
        
        /// <summary>
        ///     Plots the stairs using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="xscale">The xscale</param>
        /// <param name="xstart">The xstart</param>
        /// <param name="flags">The flags</param>
        public static void PlotStairs(string labelId, float[] values, int count, double xscale, double xstart, ImPlotStairsFlags flags)
        {
            ImPlotNative.ImPlot_PlotStairs_FloatPtrInt(Encoding.UTF8.GetBytes(labelId), values, count, xscale, xstart, flags, 0, sizeof(float)); 
        }
        
        /// <summary>
        ///     Plots the stairs using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="xscale">The xscale</param>
        /// <param name="xstart">The xstart</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        public static void PlotStairs(string labelId, float[] values, int count, double xscale, double xstart, ImPlotStairsFlags flags, int offset)
        {
            ImPlotNative.ImPlot_PlotStairs_FloatPtrInt(Encoding.UTF8.GetBytes(labelId), values, count, xscale, xstart, flags, offset, sizeof(float)); 
        }
        
        /// <summary>
        ///     Plots the stairs using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="xscale">The xscale</param>
        /// <param name="xstart">The xstart</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        /// <param name="stride">The stride</param>
        public static void PlotStairs(string labelId, float[] values, int count, double xscale, double xstart, ImPlotStairsFlags flags, int offset, int stride)
        {
            ImPlotNative.ImPlot_PlotStairs_FloatPtrInt(Encoding.UTF8.GetBytes(labelId), values, count, xscale, xstart, flags, offset, stride);
        }
        
        /// <summary>
        ///     Plots the stairs using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        public static void PlotStairs(string labelId, double[] values, int count)
        {
            ImPlotNative.ImPlot_PlotStairs_doublePtrInt(Encoding.UTF8.GetBytes(labelId), values, count, 1, 0, 0, 0, sizeof(double));
        }
        
        /// <summary>
        ///     Plots the stairs using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="xscale">The xscale</param>
        public static void PlotStairs(string labelId, double[] values, int count, double xscale)
        {
            ImPlotNative.ImPlot_PlotStairs_doublePtrInt(Encoding.UTF8.GetBytes(labelId), values, count, xscale, 0, 0, 0, sizeof(double));
        }
        
        /// <summary>
        ///     Plots the stairs using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="xscale">The xscale</param>
        /// <param name="xstart">The xstart</param>
        public static void PlotStairs(string labelId, double[] values, int count, double xscale, double xstart)
        {
            ImPlotNative.ImPlot_PlotStairs_doublePtrInt(Encoding.UTF8.GetBytes(labelId), values, count, xscale, xstart, 0, 0, sizeof(double));
        }
        
        /// <summary>
        ///     Plots the stairs using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="xscale">The xscale</param>
        /// <param name="xstart">The xstart</param>
        /// <param name="flags">The flags</param>
        public static void PlotStairs(string labelId, double[] values, int count, double xscale, double xstart, ImPlotStairsFlags flags)
        {
            ImPlotNative.ImPlot_PlotStairs_doublePtrInt(Encoding.UTF8.GetBytes(labelId), values, count, xscale, xstart, flags, 0, sizeof(double));
        }
        
        /// <summary>
        ///     Plots the stairs using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="xscale">The xscale</param>
        /// <param name="xstart">The xstart</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        public static void PlotStairs(string labelId, double[] values, int count, double xscale, double xstart, ImPlotStairsFlags flags, int offset)
        {
            ImPlotNative.ImPlot_PlotStairs_doublePtrInt(Encoding.UTF8.GetBytes(labelId), values, count, xscale, xstart, flags, offset, sizeof(double));
        }
        
        /// <summary>
        ///     Plots the stairs using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="xscale">The xscale</param>
        /// <param name="xstart">The xstart</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        /// <param name="stride">The stride</param>
        public static void PlotStairs(string labelId, double[] values, int count, double xscale, double xstart, ImPlotStairsFlags flags, int offset, int stride)
        {
            ImPlotNative.ImPlot_PlotStairs_doublePtrInt(Encoding.UTF8.GetBytes(labelId), values, count, xscale, xstart, flags, offset, stride);
        }
        
        /// <summary>
        ///     Plots the stairs using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        public static void PlotStairs(string labelId, sbyte[] values, int count)
        {
            ImPlotNative.ImPlot_PlotStairs_S8PtrInt(Encoding.UTF8.GetBytes(labelId), values, count, 1, 0, 0, 0, sizeof(sbyte));
        }
        
        /// <summary>
        ///     Plots the stairs using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="xscale">The xscale</param>
        public static void PlotStairs(string labelId, sbyte[] values, int count, double xscale)
        {
            ImPlotNative.ImPlot_PlotStairs_S8PtrInt(Encoding.UTF8.GetBytes(labelId), values, count, xscale, 0, 0, 0, sizeof(sbyte));
        }
        
        /// <summary>
        ///     Plots the stairs using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="xscale">The xscale</param>
        /// <param name="xstart">The xstart</param>
        public static void PlotStairs(string labelId, sbyte[] values, int count, double xscale, double xstart)
        {
            ImPlotNative.ImPlot_PlotStairs_S8PtrInt(Encoding.UTF8.GetBytes(labelId), values, count, xscale, xstart, 0, 0, sizeof(sbyte));
        }
        
        /// <summary>
        ///     Plots the stairs using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="xscale">The xscale</param>
        /// <param name="xstart">The xstart</param>
        /// <param name="flags">The flags</param>
        public static void PlotStairs(string labelId, sbyte[] values, int count, double xscale, double xstart, ImPlotStairsFlags flags)
        {
            ImPlotNative.ImPlot_PlotStairs_S8PtrInt(Encoding.UTF8.GetBytes(labelId), values, count, xscale, xstart, flags, 0, sizeof(sbyte));
        }
        
        /// <summary>
        ///     Plots the stairs using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="xscale">The xscale</param>
        /// <param name="xstart">The xstart</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        public static void PlotStairs(string labelId, sbyte[] values, int count, double xscale, double xstart, ImPlotStairsFlags flags, int offset)
        {
            ImPlotNative.ImPlot_PlotStairs_S8PtrInt(Encoding.UTF8.GetBytes(labelId), values, count, xscale, xstart, flags, offset, sizeof(sbyte));
        }
        
        /// <summary>
        ///     Plots the stairs using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="xscale">The xscale</param>
        /// <param name="xstart">The xstart</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        /// <param name="stride">The stride</param>
        public static void PlotStairs(string labelId, sbyte[] values, int count, double xscale, double xstart, ImPlotStairsFlags flags, int offset, int stride)
        {
            ImPlotNative.ImPlot_PlotStairs_S8PtrInt(Encoding.UTF8.GetBytes(labelId), values, count, xscale, xstart, flags, offset, stride);
        }
        
        /// <summary>
        ///     Plots the stairs using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        public static void PlotStairs(string labelId, byte[] values, int count)
        {
            ImPlotNative.ImPlot_PlotStairs_U8PtrInt(Encoding.UTF8.GetBytes(labelId), values, count, 1, 0, 0, 0, sizeof(byte));
        }
        
        /// <summary>
        ///     Plots the stairs using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="xscale">The xscale</param>
        public static void PlotStairs(string labelId, byte[] values, int count, double xscale)
        {
            ImPlotNative.ImPlot_PlotStairs_U8PtrInt(Encoding.UTF8.GetBytes(labelId), values, count, xscale, 0, 0, 0, sizeof(byte));
        }
        
        /// <summary>
        ///     Plots the stairs using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="xscale">The xscale</param>
        /// <param name="xstart">The xstart</param>
        public static void PlotStairs(string labelId, byte[] values, int count, double xscale, double xstart)
        {
            ImPlotNative.ImPlot_PlotStairs_U8PtrInt(Encoding.UTF8.GetBytes(labelId), values, count, xscale, xstart, 0, 0, sizeof(byte));
        }
    }
}