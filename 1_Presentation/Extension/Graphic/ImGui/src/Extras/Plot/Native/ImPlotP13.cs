// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImPlotP13.cs
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
        ///     Plots the stairs using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="count">The count</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        /// <param name="stride">The stride</param>
        public static void PlotStairs(string labelId, ref byte xs, ref byte ys, int count, ImPlotStairsFlags flags, int offset, int stride)
        {
            ImPlotNative.ImPlot_PlotStairs_U8PtrU8Ptr(Encoding.UTF8.GetBytes(labelId), ref xs, ref ys, count, flags, offset, stride);
        }
        
        /// <summary>
        ///     Plots the stairs using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="count">The count</param>
        public static void PlotStairs(string labelId, ref short xs, ref short ys, int count)
        {
            ImPlotNative.ImPlot_PlotStairs_S16PtrS16Ptr(Encoding.UTF8.GetBytes(labelId), xs, ys, count, 0, 0, sizeof(short));
        }
        
        /// <summary>
        ///     Plots the stairs using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="count">The count</param>
        /// <param name="flags">The flags</param>
        public static void PlotStairs(string labelId, ref short xs, ref short ys, int count, ImPlotStairsFlags flags)
        {
            ImPlotNative.ImPlot_PlotStairs_S16PtrS16Ptr(Encoding.UTF8.GetBytes(labelId), xs, ys, count, flags, 0, sizeof(short));
        }
        
        /// <summary>
        ///     Plots the stairs using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="count">The count</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        public static void PlotStairs(string labelId, ref short xs, ref short ys, int count, ImPlotStairsFlags flags, int offset)
        {
            ImPlotNative.ImPlot_PlotStairs_S16PtrS16Ptr(Encoding.UTF8.GetBytes(labelId), xs, ys, count, flags, offset, sizeof(short));
        }
        
        /// <summary>
        ///     Plots the stairs using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="count">The count</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        /// <param name="stride">The stride</param>
        public static void PlotStairs(string labelId, ref short xs, ref short ys, int count, ImPlotStairsFlags flags, int offset, int stride)
        {
            ImPlotNative.ImPlot_PlotStairs_S16PtrS16Ptr(Encoding.UTF8.GetBytes(labelId), xs, ys, count, flags, offset, stride);
        }
        
        /// <summary>
        ///     Plots the stairs using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="count">The count</param>
        public static void PlotStairs(string labelId, ref ushort xs, ref ushort ys, int count)
        {
            ImPlotNative.ImPlot_PlotStairs_U16PtrU16Ptr(Encoding.UTF8.GetBytes(labelId), ref xs, ref ys, count, 0, 0, sizeof(ushort));
        }
        
        /// <summary>
        ///     Plots the stairs using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="count">The count</param>
        /// <param name="flags">The flags</param>
        public static void PlotStairs(string labelId, ref ushort xs, ref ushort ys, int count, ImPlotStairsFlags flags)
        {
            ImPlotNative.ImPlot_PlotStairs_U16PtrU16Ptr(Encoding.UTF8.GetBytes(labelId), ref xs, ref ys, count, flags, 0, sizeof(ushort));
        }
        
        /// <summary>
        ///     Plots the stairs using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="count">The count</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        public static void PlotStairs(string labelId, ref ushort xs, ref ushort ys, int count, ImPlotStairsFlags flags, int offset)
        {
            ImPlotNative.ImPlot_PlotStairs_U16PtrU16Ptr(Encoding.UTF8.GetBytes(labelId), ref xs, ref ys, count, flags, offset, sizeof(ushort));
        }
        
        /// <summary>
        ///     Plots the stairs using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="count">The count</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        /// <param name="stride">The stride</param>
        public static void PlotStairs(string labelId, ref ushort xs, ref ushort ys, int count, ImPlotStairsFlags flags, int offset, int stride)
        {
            ImPlotNative.ImPlot_PlotStairs_U16PtrU16Ptr(Encoding.UTF8.GetBytes(labelId), ref xs, ref ys, count, flags, offset, stride);
        }
        
        /// <summary>
        ///     Plots the stairs using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="count">The count</param>
        public static void PlotStairs(string labelId, ref int xs, ref int ys, int count)
        {
            ImPlotNative.ImPlot_PlotStairs_S32PtrS32Ptr(Encoding.UTF8.GetBytes(labelId),  xs,  ys, count, 0, 0, sizeof(int));
        }
        
        /// <summary>
        ///     Plots the stairs using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="count">The count</param>
        /// <param name="flags">The flags</param>
        public static void PlotStairs(string labelId, ref int xs, ref int ys, int count, ImPlotStairsFlags flags)
        {
            ImPlotNative.ImPlot_PlotStairs_S32PtrS32Ptr(Encoding.UTF8.GetBytes(labelId),  xs,  ys, count, flags, 0, sizeof(int));
        }
        
        /// <summary>
        ///     Plots the stairs using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="count">The count</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        public static void PlotStairs(string labelId, ref int xs, ref int ys, int count, ImPlotStairsFlags flags, int offset)
        {
            ImPlotNative.ImPlot_PlotStairs_S32PtrS32Ptr(Encoding.UTF8.GetBytes(labelId),  xs,  ys, count, flags, offset, sizeof(int));
        }
        
        /// <summary>
        ///     Plots the stairs using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="count">The count</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        /// <param name="stride">The stride</param>
        public static void PlotStairs(string labelId, ref int xs, ref int ys, int count, ImPlotStairsFlags flags, int offset, int stride)
        {
            ImPlotNative.ImPlot_PlotStairs_S32PtrS32Ptr(Encoding.UTF8.GetBytes(labelId),  xs,  ys, count, flags, offset, stride);
        }
        
        /// <summary>
        ///     Plots the stairs using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="count">The count</param>
        public static void PlotStairs(string labelId, ref uint xs, ref uint ys, int count)
        {
            ImPlotNative.ImPlot_PlotStairs_U32PtrU32Ptr(Encoding.UTF8.GetBytes(labelId),  xs,  ys, count, 0, 0, sizeof(uint));
        }
        
        /// <summary>
        ///     Plots the stairs using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="count">The count</param>
        /// <param name="flags">The flags</param>
        public static void PlotStairs(string labelId, ref uint xs, ref uint ys, int count, ImPlotStairsFlags flags)
        {
            ImPlotNative.ImPlot_PlotStairs_U32PtrU32Ptr(Encoding.UTF8.GetBytes(labelId),  xs,  ys, count, flags, 0, sizeof(uint));
        }
        
        /// <summary>
        ///     Plots the stairs using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="count">The count</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        public static void PlotStairs(string labelId, ref uint xs, ref uint ys, int count, ImPlotStairsFlags flags, int offset)
        {
            ImPlotNative.ImPlot_PlotStairs_U32PtrU32Ptr(Encoding.UTF8.GetBytes(labelId),  xs,  ys, count, flags, offset, sizeof(uint));
        }
        
        /// <summary>
        ///     Plots the stairs using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="count">The count</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        /// <param name="stride">The stride</param>
        public static void PlotStairs(string labelId, ref uint xs, ref uint ys, int count, ImPlotStairsFlags flags, int offset, int stride)
        {
            ImPlotNative.ImPlot_PlotStairs_U32PtrU32Ptr(Encoding.UTF8.GetBytes(labelId),  xs,  ys, count, flags, offset, stride);
        }
        
        /// <summary>
        ///     Plots the stairs using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="count">The count</param>
        public static void PlotStairs(string labelId, ref long xs, ref long ys, int count)
        {
            ImPlotNative.ImPlot_PlotStairs_S64PtrS64Ptr(Encoding.UTF8.GetBytes(labelId), ref xs, ref ys, count, 0, 0, sizeof(long));
        }
        
        /// <summary>
        ///     Plots the stairs using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="count">The count</param>
        /// <param name="flags">The flags</param>
        public static void PlotStairs(string labelId, ref long xs, ref long ys, int count, ImPlotStairsFlags flags)
        {
            ImPlotNative.ImPlot_PlotStairs_S64PtrS64Ptr(Encoding.UTF8.GetBytes(labelId), ref xs, ref ys, count, flags, 0, sizeof(long));
        }
        
        /// <summary>
        ///     Plots the stairs using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="count">The count</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        public static void PlotStairs(string labelId, ref long xs, ref long ys, int count, ImPlotStairsFlags flags, int offset)
        {
            ImPlotNative.ImPlot_PlotStairs_S64PtrS64Ptr(Encoding.UTF8.GetBytes(labelId), ref xs, ref ys, count, flags, offset, sizeof(long));
        }
        
        /// <summary>
        ///     Plots the stairs using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="count">The count</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        /// <param name="stride">The stride</param>
        public static void PlotStairs(string labelId, ref long xs, ref long ys, int count, ImPlotStairsFlags flags, int offset, int stride)
        {
            ImPlotNative.ImPlot_PlotStairs_S64PtrS64Ptr(Encoding.UTF8.GetBytes(labelId), ref xs, ref ys, count, flags, offset, stride);
        }
        
        /// <summary>
        ///     Plots the stairs using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="count">The count</param>
        public static void PlotStairs(string labelId, ref ulong xs, ref ulong ys, int count)
        {
            ImPlotNative.ImPlot_PlotStairs_U64PtrU64Ptr(Encoding.UTF8.GetBytes(labelId), ref xs, ref ys, count, 0, 0, sizeof(ulong));
        }
        
        /// <summary>
        ///     Plots the stairs using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="count">The count</param>
        /// <param name="flags">The flags</param>
        public static void PlotStairs(string labelId, ref ulong xs, ref ulong ys, int count, ImPlotStairsFlags flags)
        {
            ImPlotNative.ImPlot_PlotStairs_U64PtrU64Ptr(Encoding.UTF8.GetBytes(labelId), ref xs, ref ys, count, flags, 0, sizeof(ulong));
        }
        
        /// <summary>
        ///     Plots the stairs using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="count">The count</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        public static void PlotStairs(string labelId, ref ulong xs, ref ulong ys, int count, ImPlotStairsFlags flags, int offset)
        {
            ImPlotNative.ImPlot_PlotStairs_U64PtrU64Ptr(Encoding.UTF8.GetBytes(labelId), ref xs, ref ys, count, flags, offset, sizeof(ulong));
        }
        
        /// <summary>
        ///     Plots the stairs using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="count">The count</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        /// <param name="stride">The stride</param>
        public static void PlotStairs(string labelId, ref ulong xs, ref ulong ys, int count, ImPlotStairsFlags flags, int offset, int stride)
        {
            ImPlotNative.ImPlot_PlotStairs_U64PtrU64Ptr(Encoding.UTF8.GetBytes(labelId), ref xs, ref ys, count, flags, offset, stride);
        }
        
        /// <summary>
        ///     Plots the stairs g using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="getter">The getter</param>
        /// <param name="data">The data</param>
        /// <param name="count">The count</param>
        public static void PlotStairsG(string labelId, IntPtr getter, IntPtr data, int count)
        {
            ImPlotNative.ImPlot_PlotStairsG(Encoding.UTF8.GetBytes(labelId), getter, data, count, 0);
        }
        
        /// <summary>
        ///     Plots the stairs g using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="getter">The getter</param>
        /// <param name="data">The data</param>
        /// <param name="count">The count</param>
        /// <param name="flags">The flags</param>
        public static void PlotStairsG(string labelId, IntPtr getter, IntPtr data, int count, ImPlotStairsFlags flags)
        {
            ImPlotNative.ImPlot_PlotStairsG(Encoding.UTF8.GetBytes(labelId), getter, data, count, flags);
        }
        
        /// <summary>
        ///     Plots the stems using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        public static void PlotStems(string labelId, ref float values, int count)
        {
            ImPlotNative.ImPlot_PlotStems_FloatPtrInt(Encoding.UTF8.GetBytes(labelId), ref values, count, 0, 1, 0, 0, 0, sizeof(float));
        }
        
        /// <summary>
        ///     Plots the stems using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="ref">The ref</param>
        public static void PlotStems(string labelId, ref float values, int count, double @ref)
        {
            ImPlotNative.ImPlot_PlotStems_FloatPtrInt(Encoding.UTF8.GetBytes(labelId), ref values, count, @ref, 1, 0, 0, 0, sizeof(float));
        }
        
        /// <summary>
        ///     Plots the stems using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="ref">The ref</param>
        /// <param name="scale">The scale</param>
        public static void PlotStems(string labelId, ref float values, int count, double @ref, double scale)
        {
            ImPlotNative.ImPlot_PlotStems_FloatPtrInt(Encoding.UTF8.GetBytes(labelId), ref values, count, @ref, scale, 0, 0, 0, sizeof(float));
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
        public static void PlotStems(string labelId, ref float values, int count, double @ref, double scale, double start)
        {
            ImPlotNative.ImPlot_PlotStems_FloatPtrInt(Encoding.UTF8.GetBytes(labelId), ref values, count, @ref, scale, start, 0, 0, sizeof(float));
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
        public static void PlotStems(string labelId, ref float values, int count, double @ref, double scale, double start, ImPlotStemsFlags flags)
        {
            ImPlotNative.ImPlot_PlotStems_FloatPtrInt(Encoding.UTF8.GetBytes(labelId), ref values, count, @ref, scale, start, flags, 0, sizeof(float));
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
        public static void PlotStems(string labelId, ref float values, int count, double @ref, double scale, double start, ImPlotStemsFlags flags, int offset)
        {
            ImPlotNative.ImPlot_PlotStems_FloatPtrInt(Encoding.UTF8.GetBytes(labelId), ref values, count, @ref, scale, start, flags, offset, sizeof(float));
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
        public static void PlotStems(string labelId, ref float values, int count, double @ref, double scale, double start, ImPlotStemsFlags flags, int offset, int stride)
        {
            ImPlotNative.ImPlot_PlotStems_FloatPtrInt(Encoding.UTF8.GetBytes(labelId), ref values, count, @ref, scale, start, flags, offset, stride);
        }
        
        /// <summary>
        ///     Plots the stems using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        public static void PlotStems(string labelId, ref double values, int count)
        {
            ImPlotNative.ImPlot_PlotStems_doublePtrInt(Encoding.UTF8.GetBytes(labelId), ref values, count, 0, 1, 0, 0, 0, sizeof(double));
        }
        
        /// <summary>
        ///     Plots the stems using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="ref">The ref</param>
        public static void PlotStems(string labelId, ref double values, int count, double @ref)
        {
            ImPlotNative.ImPlot_PlotStems_doublePtrInt(Encoding.UTF8.GetBytes(labelId), ref values, count, @ref, 1, 0, 0, 0, sizeof(double));
        }
        
        /// <summary>
        ///     Plots the stems using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="ref">The ref</param>
        /// <param name="scale">The scale</param>
        public static void PlotStems(string labelId, ref double values, int count, double @ref, double scale)
        {
            ImPlotNative.ImPlot_PlotStems_doublePtrInt(Encoding.UTF8.GetBytes(labelId), ref values, count, @ref, scale, 0, 0, 0, sizeof(double));
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
        public static void PlotStems(string labelId, ref double values, int count, double @ref, double scale, double start)
        {
            ImPlotNative.ImPlot_PlotStems_doublePtrInt(Encoding.UTF8.GetBytes(labelId), ref values, count, @ref, scale, start, 0, 0, sizeof(double));
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
        public static void PlotStems(string labelId, ref double values, int count, double @ref, double scale, double start, ImPlotStemsFlags flags)
        {
            ImPlotNative.ImPlot_PlotStems_doublePtrInt(Encoding.UTF8.GetBytes(labelId), ref values, count, @ref, scale, start, flags, 0, sizeof(double));
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
        public static void PlotStems(string labelId, ref double values, int count, double @ref, double scale, double start, ImPlotStemsFlags flags, int offset)
        {
            ImPlotNative.ImPlot_PlotStems_doublePtrInt(Encoding.UTF8.GetBytes(labelId), ref values, count, @ref, scale, start, flags, offset, sizeof(double));
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
        public static void PlotStems(string labelId, ref double values, int count, double @ref, double scale, double start, ImPlotStemsFlags flags, int offset, int stride)
        {
            ImPlotNative.ImPlot_PlotStems_doublePtrInt(Encoding.UTF8.GetBytes(labelId), ref values, count, @ref, scale, start, flags, offset, stride);
        }
        
        /// <summary>
        ///     Plots the stems using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        public static void PlotStems(string labelId, ref sbyte values, int count)
        {
            ImPlotNative.ImPlot_PlotStems_S8PtrInt(Encoding.UTF8.GetBytes(labelId), ref values, count, 0, 1, 0, 0, 0, sizeof(sbyte));
        }
        
        /// <summary>
        ///     Plots the stems using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="ref">The ref</param>
        public static void PlotStems(string labelId, ref sbyte values, int count, double @ref)
        {
            ImPlotNative.ImPlot_PlotStems_S8PtrInt(Encoding.UTF8.GetBytes(labelId), ref values, count, @ref, 1, 0, 0, 0, sizeof(sbyte));
        }
        
        /// <summary>
        ///     Plots the stems using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="ref">The ref</param>
        /// <param name="scale">The scale</param>
        public static void PlotStems(string labelId, ref sbyte values, int count, double @ref, double scale)
        {
            ImPlotNative.ImPlot_PlotStems_S8PtrInt(Encoding.UTF8.GetBytes(labelId), ref values, count, @ref, scale, 0, 0, 0, sizeof(sbyte));
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
        public static void PlotStems(string labelId, ref sbyte values, int count, double @ref, double scale, double start)
        {
            ImPlotNative.ImPlot_PlotStems_S8PtrInt(Encoding.UTF8.GetBytes(labelId), ref values, count, @ref, scale, start, 0, 0, sizeof(sbyte));
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
        public static void PlotStems(string labelId, ref sbyte values, int count, double @ref, double scale, double start, ImPlotStemsFlags flags)
        {
            ImPlotNative.ImPlot_PlotStems_S8PtrInt(Encoding.UTF8.GetBytes(labelId), ref values, count, @ref, scale, start, flags, 0, sizeof(sbyte));
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
        public static void PlotStems(string labelId, ref sbyte values, int count, double @ref, double scale, double start, ImPlotStemsFlags flags, int offset)
        {
            ImPlotNative.ImPlot_PlotStems_S8PtrInt(Encoding.UTF8.GetBytes(labelId), ref values, count, @ref, scale, start, flags, offset, sizeof(sbyte));
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
        public static void PlotStems(string labelId, ref sbyte values, int count, double @ref, double scale, double start, ImPlotStemsFlags flags, int offset, int stride)
        {
            ImPlotNative.ImPlot_PlotStems_S8PtrInt(Encoding.UTF8.GetBytes(labelId), ref values, count, @ref, scale, start, flags, offset, stride);
        }
        
        /// <summary>
        ///     Plots the stems using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        public static void PlotStems(string labelId, ref byte values, int count)
        {
            ImPlotNative.ImPlot_PlotStems_U8PtrInt(Encoding.UTF8.GetBytes(labelId), ref values, count, 0, 1, 0, 0, 0, sizeof(byte));
        }
        
        /// <summary>
        ///     Plots the stems using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="ref">The ref</param>
        public static void PlotStems(string labelId, ref byte values, int count, double @ref)
        {
            ImPlotNative.ImPlot_PlotStems_U8PtrInt(Encoding.UTF8.GetBytes(labelId), ref values, count, @ref, 1, 0, 0, 0, sizeof(byte));
        }
        
        /// <summary>
        ///     Plots the stems using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="ref">The ref</param>
        /// <param name="scale">The scale</param>
        public static void PlotStems(string labelId, ref byte values, int count, double @ref, double scale)
        {
            ImPlotNative.ImPlot_PlotStems_U8PtrInt(Encoding.UTF8.GetBytes(labelId), ref values, count, @ref, scale, 0, 0, 0, sizeof(byte));
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
        public static void PlotStems(string labelId, ref byte values, int count, double @ref, double scale, double start)
        {
            ImPlotNative.ImPlot_PlotStems_U8PtrInt(Encoding.UTF8.GetBytes(labelId), ref values, count, @ref, scale, start, 0, 0, sizeof(byte));
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
        public static void PlotStems(string labelId, ref byte values, int count, double @ref, double scale, double start, ImPlotStemsFlags flags)
        {
            ImPlotNative.ImPlot_PlotStems_U8PtrInt(Encoding.UTF8.GetBytes(labelId), ref values, count, @ref, scale, start, flags, 0, sizeof(byte));
        }
    }
}