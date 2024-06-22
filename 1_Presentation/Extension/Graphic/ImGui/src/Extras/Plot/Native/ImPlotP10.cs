// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImPlotP10.cs
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
        ///     Plots the scatter using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="count">The count</param>
        /// <param name="flags">The flags</param>
        public static void PlotScatter(string labelId, ref short xs, ref short ys, int count, ImPlotScatterFlags flags)
        {
            ImPlotNative.ImPlot_PlotScatter_S16PtrS16Ptr(Encoding.UTF8.GetBytes(labelId), ref xs, ref ys, count, flags, 0, sizeof(short));
        }
        
        /// <summary>
        ///     Plots the scatter using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="count">The count</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        public static void PlotScatter(string labelId, ref short xs, ref short ys, int count, ImPlotScatterFlags flags, int offset)
        {
            ImPlotNative.ImPlot_PlotScatter_S16PtrS16Ptr(Encoding.UTF8.GetBytes(labelId), ref xs, ref ys, count, flags, offset, sizeof(short));
        }
        
        /// <summary>
        ///     Plots the scatter using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="count">The count</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        /// <param name="stride">The stride</param>
        public static void PlotScatter(string labelId, ref short xs, ref short ys, int count, ImPlotScatterFlags flags, int offset, int stride)
        {
            ImPlotNative.ImPlot_PlotScatter_S16PtrS16Ptr(Encoding.UTF8.GetBytes(labelId), ref xs, ref ys, count, flags, offset, stride);
        }
        
        /// <summary>
        ///     Plots the scatter using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="count">The count</param>
        public static void PlotScatter(string labelId, ref ushort xs, ref ushort ys, int count)
        {
            ImPlotNative.ImPlot_PlotScatter_U16PtrU16Ptr(Encoding.UTF8.GetBytes(labelId), ref xs, ref ys, count, 0, 0, sizeof(ushort));
        }
        
        /// <summary>
        ///     Plots the scatter using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="count">The count</param>
        /// <param name="flags">The flags</param>
        public static void PlotScatter(string labelId, ref ushort xs, ref ushort ys, int count, ImPlotScatterFlags flags)
        {
            ImPlotNative.ImPlot_PlotScatter_U16PtrU16Ptr(Encoding.UTF8.GetBytes(labelId), ref xs, ref ys, count, flags, 0, sizeof(ushort));
        }
        
        /// <summary>
        ///     Plots the scatter using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="count">The count</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        public static void PlotScatter(string labelId, ref ushort xs, ref ushort ys, int count, ImPlotScatterFlags flags, int offset)
        {
            ImPlotNative.ImPlot_PlotScatter_U16PtrU16Ptr(Encoding.UTF8.GetBytes(labelId), ref xs, ref ys, count, flags, offset, sizeof(ushort));
        }
        
        /// <summary>
        ///     Plots the scatter using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="count">The count</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        /// <param name="stride">The stride</param>
        public static void PlotScatter(string labelId, ref ushort xs, ref ushort ys, int count, ImPlotScatterFlags flags, int offset, int stride)
        {
            ImPlotNative.ImPlot_PlotScatter_U16PtrU16Ptr(Encoding.UTF8.GetBytes(labelId), ref xs, ref ys, count, flags, offset, stride);
        }
        
        /// <summary>
        ///     Plots the scatter using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="count">The count</param>
        public static void PlotScatter(string labelId, ref int xs, ref int ys, int count)
        {
            ImPlotNative.ImPlot_PlotScatter_S32PtrS32Ptr(Encoding.UTF8.GetBytes(labelId), ref xs, ref ys, count, 0, 0, sizeof(int));
        }
        
        /// <summary>
        ///     Plots the scatter using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="count">The count</param>
        /// <param name="flags">The flags</param>
        public static void PlotScatter(string labelId, ref int xs, ref int ys, int count, ImPlotScatterFlags flags)
        {
            ImPlotNative.ImPlot_PlotScatter_S32PtrS32Ptr(Encoding.UTF8.GetBytes(labelId), ref xs, ref ys, count, flags, 0, sizeof(int));
        }
        
        /// <summary>
        ///     Plots the scatter using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="count">The count</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        public static void PlotScatter(string labelId, ref int xs, ref int ys, int count, ImPlotScatterFlags flags, int offset)
        {
            ImPlotNative.ImPlot_PlotScatter_S32PtrS32Ptr(Encoding.UTF8.GetBytes(labelId), ref xs, ref ys, count, flags, offset, sizeof(int));
        }
        
        /// <summary>
        ///     Plots the scatter using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="count">The count</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        /// <param name="stride">The stride</param>
        public static void PlotScatter(string labelId, ref int xs, ref int ys, int count, ImPlotScatterFlags flags, int offset, int stride)
        {
            ImPlotNative.ImPlot_PlotScatter_S32PtrS32Ptr(Encoding.UTF8.GetBytes(labelId), ref xs, ref ys, count, flags, offset, stride);
        }
        
        /// <summary>
        ///     Plots the scatter using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="count">The count</param>
        public static void PlotScatter(string labelId, ref uint xs, ref uint ys, int count)
        {
            ImPlotNative.ImPlot_PlotScatter_U32PtrU32Ptr(Encoding.UTF8.GetBytes(labelId), ref xs, ref ys, count, 0, 0, sizeof(uint));
        }
        
        /// <summary>
        ///     Plots the scatter using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="count">The count</param>
        /// <param name="flags">The flags</param>
        public static void PlotScatter(string labelId, ref uint xs, ref uint ys, int count, ImPlotScatterFlags flags)
        {
            ImPlotNative.ImPlot_PlotScatter_U32PtrU32Ptr(Encoding.UTF8.GetBytes(labelId), ref xs, ref ys, count, flags, 0, sizeof(uint));
        }
        
        /// <summary>
        ///     Plots the scatter using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="count">The count</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        public static void PlotScatter(string labelId, ref uint xs, ref uint ys, int count, ImPlotScatterFlags flags, int offset)
        {
            ImPlotNative.ImPlot_PlotScatter_U32PtrU32Ptr(Encoding.UTF8.GetBytes(labelId), ref xs, ref ys, count, flags, offset, sizeof(uint));
        }
        
        /// <summary>
        ///     Plots the scatter using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="count">The count</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        /// <param name="stride">The stride</param>
        public static void PlotScatter(string labelId, ref uint xs, ref uint ys, int count, ImPlotScatterFlags flags, int offset, int stride)
        {
            ImPlotNative.ImPlot_PlotScatter_U32PtrU32Ptr(Encoding.UTF8.GetBytes(labelId), ref xs, ref ys, count, flags, offset, stride);
        }
        
        /// <summary>
        ///     Plots the scatter using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="count">The count</param>
        public static void PlotScatter(string labelId, ref long xs, ref long ys, int count)
        {
            ImPlotNative.ImPlot_PlotScatter_S64PtrS64Ptr(Encoding.UTF8.GetBytes(labelId), ref xs, ref ys, count, 0, 0, sizeof(long));
        }
        
        /// <summary>
        ///     Plots the scatter using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="count">The count</param>
        /// <param name="flags">The flags</param>
        public static void PlotScatter(string labelId, ref long xs, ref long ys, int count, ImPlotScatterFlags flags)
        {
            ImPlotNative.ImPlot_PlotScatter_S64PtrS64Ptr(Encoding.UTF8.GetBytes(labelId), ref xs, ref ys, count, flags, 0, sizeof(long));
        }
        
        /// <summary>
        ///     Plots the scatter using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="count">The count</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        public static void PlotScatter(string labelId, ref long xs, ref long ys, int count, ImPlotScatterFlags flags, int offset)
        {
            ImPlotNative.ImPlot_PlotScatter_S64PtrS64Ptr(Encoding.UTF8.GetBytes(labelId), ref xs, ref ys, count, flags, offset, sizeof(long));
        }
        
        /// <summary>
        ///     Plots the scatter using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="count">The count</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        /// <param name="stride">The stride</param>
        public static void PlotScatter(string labelId, ref long xs, ref long ys, int count, ImPlotScatterFlags flags, int offset, int stride)
        {
            ImPlotNative.ImPlot_PlotScatter_S64PtrS64Ptr(Encoding.UTF8.GetBytes(labelId), ref xs, ref ys, count, flags, offset, stride);
        }
        
        /// <summary>
        ///     Plots the scatter using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="count">The count</param>
        public static void PlotScatter(string labelId, ref ulong xs, ref ulong ys, int count)
        {
            ImPlotNative.ImPlot_PlotScatter_U64PtrU64Ptr(Encoding.UTF8.GetBytes(labelId), ref xs, ref ys, count, 0, 0, sizeof(ulong));
        }
        
        /// <summary>
        ///     Plots the scatter using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="count">The count</param>
        /// <param name="flags">The flags</param>
        public static void PlotScatter(string labelId, ref ulong xs, ref ulong ys, int count, ImPlotScatterFlags flags)
        {
            ImPlotNative.ImPlot_PlotScatter_U64PtrU64Ptr(Encoding.UTF8.GetBytes(labelId), ref xs, ref ys, count, flags, 0, sizeof(ulong));
        }
        
        /// <summary>
        ///     Plots the scatter using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="count">The count</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        public static void PlotScatter(string labelId, ref ulong xs, ref ulong ys, int count, ImPlotScatterFlags flags, int offset)
        {
            ImPlotNative.ImPlot_PlotScatter_U64PtrU64Ptr(Encoding.UTF8.GetBytes(labelId), ref xs, ref ys, count, flags, offset, sizeof(ulong));
        }
        
        /// <summary>
        ///     Plots the scatter using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="count">The count</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        /// <param name="stride">The stride</param>
        public static void PlotScatter(string labelId, ref ulong xs, ref ulong ys, int count, ImPlotScatterFlags flags, int offset, int stride)
        {
            ImPlotNative.ImPlot_PlotScatter_U64PtrU64Ptr(Encoding.UTF8.GetBytes(labelId), ref xs, ref ys, count, flags, offset, stride);
        }
        
        /// <summary>
        ///     Plots the scatter g using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="getter">The getter</param>
        /// <param name="data">The data</param>
        /// <param name="count">The count</param>
        public static void PlotScatterG(string labelId, IntPtr getter, IntPtr data, int count)
        {
            ImPlotNative.ImPlot_PlotScatterG(Encoding.UTF8.GetBytes(labelId), getter, data, count, 0);
        }
        
        /// <summary>
        ///     Plots the scatter g using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="getter">The getter</param>
        /// <param name="data">The data</param>
        /// <param name="count">The count</param>
        /// <param name="flags">The flags</param>
        public static void PlotScatterG(string labelId, IntPtr getter, IntPtr data, int count, ImPlotScatterFlags flags)
        {
            ImPlotNative.ImPlot_PlotScatterG(Encoding.UTF8.GetBytes(labelId), getter, data, count, flags);
        }
        
        /// <summary>
        ///     Plots the shaded using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        public static void PlotShaded(string labelId, float[] values, int count)
        {
            ImPlotNative.ImPlot_PlotShaded_FloatPtrInt(Encoding.UTF8.GetBytes(labelId), values, count, 0, 1, 0, 0, 0, sizeof(float));
        }
        
        /// <summary>
        ///     Plots the shaded using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="yref">The yref</param>
        public static void PlotShaded(string labelId, float[] values, int count, double yref)
        {
            ImPlotNative.ImPlot_PlotShaded_FloatPtrInt(Encoding.UTF8.GetBytes(labelId), values, count, yref, 1, 0, 0, 0, sizeof(float));
        }
        
        /// <summary>
        ///     Plots the shaded using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="yref">The yref</param>
        /// <param name="xscale">The xscale</param>
        public static void PlotShaded(string labelId, float[] values, int count, double yref, double xscale)
        {
            ImPlotNative.ImPlot_PlotShaded_FloatPtrInt(Encoding.UTF8.GetBytes(labelId), values, count, yref, xscale, 0, 0, 0, sizeof(float));
        }
        
        /// <summary>
        ///     Plots the shaded using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="yref">The yref</param>
        /// <param name="xscale">The xscale</param>
        /// <param name="xstart">The xstart</param>
        public static void PlotShaded(string labelId, float[] values, int count, double yref, double xscale, double xstart)
        {
            ImPlotNative.ImPlot_PlotShaded_FloatPtrInt(Encoding.UTF8.GetBytes(labelId), values, count, yref, xscale, xstart, 0, 0, sizeof(float));
        }
        
        /// <summary>
        ///     Plots the shaded using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="yref">The yref</param>
        /// <param name="xscale">The xscale</param>
        /// <param name="xstart">The xstart</param>
        /// <param name="flags">The flags</param>
        public static void PlotShaded(string labelId, float[] values, int count, double yref, double xscale, double xstart, ImPlotShadedFlags flags)
        {
            ImPlotNative.ImPlot_PlotShaded_FloatPtrInt(Encoding.UTF8.GetBytes(labelId), values, count, yref, xscale, xstart, flags, 0, sizeof(float));
        }
        
        /// <summary>
        ///     Plots the shaded using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="yref">The yref</param>
        /// <param name="xscale">The xscale</param>
        /// <param name="xstart">The xstart</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        public static void PlotShaded(string labelId, float[] values, int count, double yref, double xscale, double xstart, ImPlotShadedFlags flags, int offset)
        {
            ImPlotNative.ImPlot_PlotShaded_FloatPtrInt(Encoding.UTF8.GetBytes(labelId), values, count, yref, xscale, xstart, flags, offset, sizeof(float));
        }
        
        /// <summary>
        ///     Plots the shaded using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="yref">The yref</param>
        /// <param name="xscale">The xscale</param>
        /// <param name="xstart">The xstart</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        /// <param name="stride">The stride</param>
        public static void PlotShaded(string labelId, float[] values, int count, double yref, double xscale, double xstart, ImPlotShadedFlags flags, int offset, int stride)
        {
            ImPlotNative.ImPlot_PlotShaded_FloatPtrInt(Encoding.UTF8.GetBytes(labelId), values, count, yref, xscale, xstart, flags, offset, stride);
        }
        
        /// <summary>
        ///     Plots the shaded using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        public static void PlotShaded(string labelId, double[] values, int count)
        {
            ImPlotNative.ImPlot_PlotShaded_doublePtrInt(Encoding.UTF8.GetBytes(labelId), values, count, 0, 1, 0, 0, 0, sizeof(double));
        }
        
        /// <summary>
        ///     Plots the shaded using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="yref">The yref</param>
        public static void PlotShaded(string labelId, double[] values, int count, double yref)
        {
            ImPlotNative.ImPlot_PlotShaded_doublePtrInt(Encoding.UTF8.GetBytes(labelId), values, count, yref, 1, 0, 0, 0, sizeof(double));
        }
        
        /// <summary>
        ///     Plots the shaded using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="yref">The yref</param>
        /// <param name="xscale">The xscale</param>
        public static void PlotShaded(string labelId, double[] values, int count, double yref, double xscale)
        {
            ImPlotNative.ImPlot_PlotShaded_doublePtrInt(Encoding.UTF8.GetBytes(labelId), values, count, yref, xscale, 0, 0, 0, sizeof(double));
        }
        
        /// <summary>
        ///     Plots the shaded using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="yref">The yref</param>
        /// <param name="xscale">The xscale</param>
        /// <param name="xstart">The xstart</param>
        public static void PlotShaded(string labelId, double[] values, int count, double yref, double xscale, double xstart)
        {
            ImPlotNative.ImPlot_PlotShaded_doublePtrInt(Encoding.UTF8.GetBytes(labelId), values, count, yref, xscale, xstart, 0, 0, sizeof(double));
        }
        
        /// <summary>
        ///     Plots the shaded using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="yref">The yref</param>
        /// <param name="xscale">The xscale</param>
        /// <param name="xstart">The xstart</param>
        /// <param name="flags">The flags</param>
        public static void PlotShaded(string labelId, double[] values, int count, double yref, double xscale, double xstart, ImPlotShadedFlags flags)
        {
            ImPlotNative.ImPlot_PlotShaded_doublePtrInt(Encoding.UTF8.GetBytes(labelId), values, count, yref, xscale, xstart, flags, 0, sizeof(double));
        }
        
        /// <summary>
        ///     Plots the shaded using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="yref">The yref</param>
        /// <param name="xscale">The xscale</param>
        /// <param name="xstart">The xstart</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        public static void PlotShaded(string labelId, double[] values, int count, double yref, double xscale, double xstart, ImPlotShadedFlags flags, int offset)
        {
            ImPlotNative.ImPlot_PlotShaded_doublePtrInt(Encoding.UTF8.GetBytes(labelId), values, count, yref, xscale, xstart, flags, offset, sizeof(double));
        }
        
        /// <summary>
        ///     Plots the shaded using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="yref">The yref</param>
        /// <param name="xscale">The xscale</param>
        /// <param name="xstart">The xstart</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        /// <param name="stride">The stride</param>
        public static void PlotShaded(string labelId, double[] values, int count, double yref, double xscale, double xstart, ImPlotShadedFlags flags, int offset, int stride)
        {
            ImPlotNative.ImPlot_PlotShaded_doublePtrInt(Encoding.UTF8.GetBytes(labelId), values, count, yref, xscale, xstart, flags, offset, stride);
        }
        
        /// <summary>
        ///     Plots the shaded using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        public static void PlotShaded(string labelId, sbyte[] values, int count)
        {
            ImPlotNative.ImPlot_PlotShaded_S8PtrInt(Encoding.UTF8.GetBytes(labelId), values, count, 0, 1, 0, 0, 0, sizeof(sbyte));
        }
        
        /// <summary>
        ///     Plots the shaded using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="yref">The yref</param>
        public static void PlotShaded(string labelId, sbyte[] values, int count, double yref)
        {
            ImPlotNative.ImPlot_PlotShaded_S8PtrInt(Encoding.UTF8.GetBytes(labelId), values, count, yref, 1, 0, 0, 0, sizeof(sbyte));
        }
        
        /// <summary>
        ///     Plots the shaded using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="yref">The yref</param>
        /// <param name="xscale">The xscale</param>
        public static void PlotShaded(string labelId, sbyte[] values, int count, double yref, double xscale)
        {
            ImPlotNative.ImPlot_PlotShaded_S8PtrInt(Encoding.UTF8.GetBytes(labelId), values, count, yref, xscale, 0, 0, 0, sizeof(sbyte));
        }
        
        /// <summary>
        ///     Plots the shaded using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="yref">The yref</param>
        /// <param name="xscale">The xscale</param>
        /// <param name="xstart">The xstart</param>
        public static void PlotShaded(string labelId, sbyte[] values, int count, double yref, double xscale, double xstart)
        {
            ImPlotNative.ImPlot_PlotShaded_S8PtrInt(Encoding.UTF8.GetBytes(labelId), values, count, yref, xscale, xstart, 0, 0, sizeof(sbyte));
        }
        
        /// <summary>
        ///     Plots the shaded using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="yref">The yref</param>
        /// <param name="xscale">The xscale</param>
        /// <param name="xstart">The xstart</param>
        /// <param name="flags">The flags</param>
        public static void PlotShaded(string labelId, sbyte[] values, int count, double yref, double xscale, double xstart, ImPlotShadedFlags flags)
        {
            ImPlotNative.ImPlot_PlotShaded_S8PtrInt(Encoding.UTF8.GetBytes(labelId), values, count, yref, xscale, xstart, flags, 0, sizeof(sbyte));
        }
        
        /// <summary>
        ///     Plots the shaded using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="yref">The yref</param>
        /// <param name="xscale">The xscale</param>
        /// <param name="xstart">The xstart</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        public static void PlotShaded(string labelId, sbyte[] values, int count, double yref, double xscale, double xstart, ImPlotShadedFlags flags, int offset)
        {
            ImPlotNative.ImPlot_PlotShaded_S8PtrInt(Encoding.UTF8.GetBytes(labelId), values, count, yref, xscale, xstart, flags, offset, sizeof(sbyte));
        }
        
        /// <summary>
        ///     Plots the shaded using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="yref">The yref</param>
        /// <param name="xscale">The xscale</param>
        /// <param name="xstart">The xstart</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        /// <param name="stride">The stride</param>
        public static void PlotShaded(string labelId, sbyte[] values, int count, double yref, double xscale, double xstart, ImPlotShadedFlags flags, int offset, int stride)
        {
            ImPlotNative.ImPlot_PlotShaded_S8PtrInt(Encoding.UTF8.GetBytes(labelId), values, count, yref, xscale, xstart, flags, offset, stride);
        }
        
        /// <summary>
        ///     Plots the shaded using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        public static void PlotShaded(string labelId, byte[] values, int count)
        {
            ImPlotNative.ImPlot_PlotShaded_U8PtrInt(Encoding.UTF8.GetBytes(labelId), values, count, 0, 1, 0, 0, 0, sizeof(byte));
        }
        
        /// <summary>
        ///     Plots the shaded using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="yref">The yref</param>
        public static void PlotShaded(string labelId, byte[] values, int count, double yref)
        {
            ImPlotNative.ImPlot_PlotShaded_U8PtrInt(Encoding.UTF8.GetBytes(labelId), values, count, yref, 1, 0, 0, 0, sizeof(byte));
        }
        
        /// <summary>
        ///     Plots the shaded using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="yref">The yref</param>
        /// <param name="xscale">The xscale</param>
        public static void PlotShaded(string labelId, byte[] values, int count, double yref, double xscale)
        {
            ImPlotNative.ImPlot_PlotShaded_U8PtrInt(Encoding.UTF8.GetBytes(labelId), values, count, yref, xscale, 0, 0, 0, sizeof(byte));
        }
        
        /// <summary>
        ///     Plots the shaded using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="yref">The yref</param>
        /// <param name="xscale">The xscale</param>
        /// <param name="xstart">The xstart</param>
        public static void PlotShaded(string labelId, byte[] values, int count, double yref, double xscale, double xstart)
        {
            ImPlotNative.ImPlot_PlotShaded_U8PtrInt(Encoding.UTF8.GetBytes(labelId), values, count, yref, xscale, xstart, 0, 0, sizeof(byte));
        }
        
        /// <summary>
        ///     Plots the shaded using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="yref">The yref</param>
        /// <param name="xscale">The xscale</param>
        /// <param name="xstart">The xstart</param>
        /// <param name="flags">The flags</param>
        public static void PlotShaded(string labelId, byte[] values, int count, double yref, double xscale, double xstart, ImPlotShadedFlags flags)
        {
            ImPlotNative.ImPlot_PlotShaded_U8PtrInt(Encoding.UTF8.GetBytes(labelId), values, count, yref, xscale, xstart, flags, 0, sizeof(byte));
        }
        
        /// <summary>
        ///     Plots the shaded using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="yref">The yref</param>
        /// <param name="xscale">The xscale</param>
        /// <param name="xstart">The xstart</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        public static void PlotShaded(string labelId, byte[] values, int count, double yref, double xscale, double xstart, ImPlotShadedFlags flags, int offset)
        {
            ImPlotNative.ImPlot_PlotShaded_U8PtrInt(Encoding.UTF8.GetBytes(labelId), values, count, yref, xscale, xstart, flags, offset, sizeof(byte));
        }
        
        /// <summary>
        ///     Plots the shaded using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="yref">The yref</param>
        /// <param name="xscale">The xscale</param>
        /// <param name="xstart">The xstart</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        /// <param name="stride">The stride</param>
        public static void PlotShaded(string labelId, byte[] values, int count, double yref, double xscale, double xstart, ImPlotShadedFlags flags, int offset, int stride)
        {
            ImPlotNative.ImPlot_PlotShaded_U8PtrInt(Encoding.UTF8.GetBytes(labelId), values, count, yref, xscale, xstart, flags, offset, stride);
        }
        
        /// <summary>
        ///     Plots the shaded using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        public static void PlotShaded(string labelId, short[] values, int count)
        {
            ImPlotNative.ImPlot_PlotShaded_S16PtrInt(Encoding.UTF8.GetBytes(labelId), values, count, 0, 1, 0, 0, 0, sizeof(short));
        }
        
        /// <summary>
        ///     Plots the shaded using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="yref">The yref</param>
        public static void PlotShaded(string labelId, short[] values, int count, double yref)
        {
            ImPlotNative.ImPlot_PlotShaded_S16PtrInt(Encoding.UTF8.GetBytes(labelId), values, count, yref, 1, 0, 0, 0, sizeof(short));
        }
        
        /// <summary>
        ///     Plots the shaded using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="yref">The yref</param>
        /// <param name="xscale">The xscale</param>
        public static void PlotShaded(string labelId, short[] values, int count, double yref, double xscale)
        {
            ImPlotNative.ImPlot_PlotShaded_S16PtrInt(Encoding.UTF8.GetBytes(labelId), values, count, yref, xscale, 0, 0, 0, sizeof(short));
        }
        
        /// <summary>
        ///     Plots the shaded using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="yref">The yref</param>
        /// <param name="xscale">The xscale</param>
        /// <param name="xstart">The xstart</param>
        public static void PlotShaded(string labelId, short[] values, int count, double yref, double xscale, double xstart)
        {
            ImPlotNative.ImPlot_PlotShaded_S16PtrInt(Encoding.UTF8.GetBytes(labelId), values, count, yref, xscale, xstart, 0, 0, sizeof(short));
        }
        
        /// <summary>
        ///     Plots the shaded using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="yref">The yref</param>
        /// <param name="xscale">The xscale</param>
        /// <param name="xstart">The xstart</param>
        /// <param name="flags">The flags</param>
        public static void PlotShaded(string labelId, short[] values, int count, double yref, double xscale, double xstart, ImPlotShadedFlags flags)
        {
            ImPlotNative.ImPlot_PlotShaded_S16PtrInt(Encoding.UTF8.GetBytes(labelId), values, count, yref, xscale, xstart, flags, 0, sizeof(short));
        }
        
        /// <summary>
        ///     Plots the shaded using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="yref">The yref</param>
        /// <param name="xscale">The xscale</param>
        /// <param name="xstart">The xstart</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        public static void PlotShaded(string labelId, short[] values, int count, double yref, double xscale, double xstart, ImPlotShadedFlags flags, int offset)
        {
            ImPlotNative.ImPlot_PlotShaded_S16PtrInt(Encoding.UTF8.GetBytes(labelId), values, count, yref, xscale, xstart, flags, offset, sizeof(short));
        }
        
        /// <summary>
        ///     Plots the shaded using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="yref">The yref</param>
        /// <param name="xscale">The xscale</param>
        /// <param name="xstart">The xstart</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        /// <param name="stride">The stride</param>
        public static void PlotShaded(string labelId, short[] values, int count, double yref, double xscale, double xstart, ImPlotShadedFlags flags, int offset, int stride)
        {
            ImPlotNative.ImPlot_PlotShaded_S16PtrInt(Encoding.UTF8.GetBytes(labelId), values, count, yref, xscale, xstart, flags, offset, stride);
        }
        
        /// <summary>
        ///     Plots the shaded using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        public static void PlotShaded(string labelId, ushort[] values, int count)
        {
            ImPlotNative.ImPlot_PlotShaded_U16PtrInt(Encoding.UTF8.GetBytes(labelId), values, count, 0, 1, 0, 0, 0, sizeof(ushort));
        }
        
        /// <summary>
        ///     Plots the shaded using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="yref">The yref</param>
        public static void PlotShaded(string labelId, ushort[] values, int count, double yref)
        {
            ImPlotNative.ImPlot_PlotShaded_U16PtrInt(Encoding.UTF8.GetBytes(labelId), values, count, yref, 1, 0, 0, 0, sizeof(ushort));
        }
        
        /// <summary>
        ///     Plots the shaded using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="yref">The yref</param>
        /// <param name="xscale">The xscale</param>
        public static void PlotShaded(string labelId, ushort[] values, int count, double yref, double xscale)
        {
ImPlotNative.ImPlot_PlotShaded_U16PtrInt(Encoding.UTF8.GetBytes(labelId), values, count, yref, xscale, 0, 0, 0, sizeof(ushort));
        }
        
        /// <summary>
        ///     Plots the shaded using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="yref">The yref</param>
        /// <param name="xscale">The xscale</param>
        /// <param name="xstart">The xstart</param>
        public static void PlotShaded(string labelId, ushort[] values, int count, double yref, double xscale, double xstart)
        {
            ImPlotNative.ImPlot_PlotShaded_U16PtrInt(Encoding.UTF8.GetBytes(labelId), values, count, yref, xscale, xstart, 0, 0, sizeof(ushort));
        }
        
        /// <summary>
        ///     Plots the shaded using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="yref">The yref</param>
        /// <param name="xscale">The xscale</param>
        /// <param name="xstart">The xstart</param>
        /// <param name="flags">The flags</param>
        public static void PlotShaded(string labelId, ushort[] values, int count, double yref, double xscale, double xstart, ImPlotShadedFlags flags)
        {
            ImPlotNative.ImPlot_PlotShaded_U16PtrInt(Encoding.UTF8.GetBytes(labelId), values, count, yref, xscale, xstart, flags, 0, sizeof(ushort));
        }
        
        /// <summary>
        ///     Plots the shaded using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="yref">The yref</param>
        /// <param name="xscale">The xscale</param>
        /// <param name="xstart">The xstart</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        public static void PlotShaded(string labelId, ushort[] values, int count, double yref, double xscale, double xstart, ImPlotShadedFlags flags, int offset)
        {
            ImPlotNative.ImPlot_PlotShaded_U16PtrInt(Encoding.UTF8.GetBytes(labelId), values, count, yref, xscale, xstart, flags, offset, sizeof(ushort));
        }
        
        /// <summary>
        ///     Plots the shaded using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="yref">The yref</param>
        /// <param name="xscale">The xscale</param>
        /// <param name="xstart">The xstart</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        /// <param name="stride">The stride</param>
        public static void PlotShaded(string labelId, ushort[] values, int count, double yref, double xscale, double xstart, ImPlotShadedFlags flags, int offset, int stride)
        {
            ImPlotNative.ImPlot_PlotShaded_U16PtrInt(Encoding.UTF8.GetBytes(labelId), values, count, yref, xscale, xstart, flags, offset, stride);
        }
        
        /// <summary>
        ///     Plots the shaded using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        public static void PlotShaded(string labelId, int[] values, int count)
        {
            ImPlotNative.ImPlot_PlotShaded_S32PtrInt(Encoding.UTF8.GetBytes(labelId), values, count, 0, 1, 0, 0, 0, sizeof(int));
        }
        
        /// <summary>
        ///     Plots the shaded using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="yref">The yref</param>
        public static void PlotShaded(string labelId, int[] values, int count, double yref)
        {
            ImPlotNative.ImPlot_PlotShaded_S32PtrInt(Encoding.UTF8.GetBytes(labelId), values, count, yref, 1, 0, 0, 0, sizeof(int));
        }
        
        /// <summary>
        ///     Plots the shaded using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="yref">The yref</param>
        /// <param name="xscale">The xscale</param>
        public static void PlotShaded(string labelId, int[] values, int count, double yref, double xscale)
        {
            ImPlotNative.ImPlot_PlotShaded_S32PtrInt(Encoding.UTF8.GetBytes(labelId), values, count, yref, xscale, 0, 0, 0, sizeof(int));
        }
        
        /// <summary>
        ///     Plots the shaded using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="yref">The yref</param>
        /// <param name="xscale">The xscale</param>
        /// <param name="xstart">The xstart</param>
        public static void PlotShaded(string labelId, int[] values, int count, double yref, double xscale, double xstart)
        {
            ImPlotNative.ImPlot_PlotShaded_S32PtrInt(Encoding.UTF8.GetBytes(labelId), values, count, yref, xscale, xstart, 0, 0, sizeof(int));
        }
        
        /// <summary>
        ///     Plots the shaded using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="yref">The yref</param>
        /// <param name="xscale">The xscale</param>
        /// <param name="xstart">The xstart</param>
        /// <param name="flags">The flags</param>
        public static void PlotShaded(string labelId, int[] values, int count, double yref, double xscale, double xstart, ImPlotShadedFlags flags)
        {
            ImPlotNative.ImPlot_PlotShaded_S32PtrInt(Encoding.UTF8.GetBytes(labelId), values, count, yref, xscale, xstart, flags, 0, sizeof(int));
        }
        
        /// <summary>
        ///     Plots the shaded using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="yref">The yref</param>
        /// <param name="xscale">The xscale</param>
        /// <param name="xstart">The xstart</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        public static void PlotShaded(string labelId, int[] values, int count, double yref, double xscale, double xstart, ImPlotShadedFlags flags, int offset)
        {
            ImPlotNative.ImPlot_PlotShaded_S32PtrInt(Encoding.UTF8.GetBytes(labelId), values, count, yref, xscale, xstart, flags, offset, sizeof(int));
        }
        
        /// <summary>
        ///     Plots the shaded using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="yref">The yref</param>
        /// <param name="xscale">The xscale</param>
        /// <param name="xstart">The xstart</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        /// <param name="stride">The stride</param>
        public static void PlotShaded(string labelId, int[] values, int count, double yref, double xscale, double xstart, ImPlotShadedFlags flags, int offset, int stride)
        {
            ImPlotNative.ImPlot_PlotShaded_S32PtrInt(Encoding.UTF8.GetBytes(labelId), values, count, yref, xscale, xstart, flags, offset, stride);
        }
        
        /// <summary>
        ///     Plots the shaded using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        public static void PlotShaded(string labelId, uint[] values, int count)
        {
            ImPlotNative.ImPlot_PlotShaded_U32PtrInt(Encoding.UTF8.GetBytes(labelId), values, count, 0, 1, 0, 0, 0, sizeof(uint));
        }
        
        /// <summary>
        ///     Plots the shaded using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="yref">The yref</param>
        public static void PlotShaded(string labelId, uint[] values, int count, double yref)
        {
            ImPlotNative.ImPlot_PlotShaded_U32PtrInt(Encoding.UTF8.GetBytes(labelId), values, count, yref, 1, 0, 0, 0, sizeof(uint));
        }
        
        /// <summary>
        ///     Plots the shaded using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="yref">The yref</param>
        /// <param name="xscale">The xscale</param>
        public static void PlotShaded(string labelId, uint[] values, int count, double yref, double xscale)
        {
            ImPlotNative.ImPlot_PlotShaded_U32PtrInt(Encoding.UTF8.GetBytes(labelId), values, count, yref, xscale, 0, 0, 0, sizeof(uint));
        }
        
        /// <summary>
        ///     Plots the shaded using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="yref">The yref</param>
        /// <param name="xscale">The xscale</param>
        /// <param name="xstart">The xstart</param>
        public static void PlotShaded(string labelId, uint[] values, int count, double yref, double xscale, double xstart)
        {
            ImPlotNative.ImPlot_PlotShaded_U32PtrInt(Encoding.UTF8.GetBytes(labelId), values, count, yref, xscale, xstart, 0, 0, sizeof(uint));
        }
        
        /// <summary>
        ///     Plots the shaded using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="yref">The yref</param>
        /// <param name="xscale">The xscale</param>
        /// <param name="xstart">The xstart</param>
        /// <param name="flags">The flags</param>
        public static void PlotShaded(string labelId, uint[] values, int count, double yref, double xscale, double xstart, ImPlotShadedFlags flags)
        {
            ImPlotNative.ImPlot_PlotShaded_U32PtrInt(Encoding.UTF8.GetBytes(labelId), values, count, yref, xscale, xstart, flags, 0, sizeof(uint));
        }
        
        /// <summary>
        ///     Plots the shaded using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="yref">The yref</param>
        /// <param name="xscale">The xscale</param>
        /// <param name="xstart">The xstart</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        public static void PlotShaded(string labelId, uint[] values, int count, double yref, double xscale, double xstart, ImPlotShadedFlags flags, int offset)
        {
            ImPlotNative.ImPlot_PlotShaded_U32PtrInt(Encoding.UTF8.GetBytes(labelId), values, count, yref, xscale, xstart, flags, offset, sizeof(uint));
        }
        
        /// <summary>
        ///     Plots the shaded using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="yref">The yref</param>
        /// <param name="xscale">The xscale</param>
        /// <param name="xstart">The xstart</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        /// <param name="stride">The stride</param>
        public static void PlotShaded(string labelId, uint[] values, int count, double yref, double xscale, double xstart, ImPlotShadedFlags flags, int offset, int stride)
        {
            ImPlotNative.ImPlot_PlotShaded_U32PtrInt(Encoding.UTF8.GetBytes(labelId), values, count, yref, xscale, xstart, flags, offset, stride);
        }
        
        /// <summary>
        ///     Plots the shaded using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        public static void PlotShaded(string labelId, long[] values, int count)
        {
            ImPlotNative.ImPlot_PlotShaded_S64PtrInt(Encoding.UTF8.GetBytes(labelId), values, count, 0, 1, 0, 0, 0, sizeof(long));
        }
        
        /// <summary>
        ///     Plots the shaded using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="yref">The yref</param>
        public static void PlotShaded(string labelId, long[] values, int count, double yref)
        {
            ImPlotNative.ImPlot_PlotShaded_S64PtrInt(Encoding.UTF8.GetBytes(labelId), values, count, yref, 1, 0, 0, 0, sizeof(long));
        }
        
        /// <summary>
        ///     Plots the shaded using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="yref">The yref</param>
        /// <param name="xscale">The xscale</param>
        public static void PlotShaded(string labelId, long[] values, int count, double yref, double xscale)
        {
            ImPlotNative.ImPlot_PlotShaded_S64PtrInt(Encoding.UTF8.GetBytes(labelId), values, count, yref, xscale, 0, 0, 0, sizeof(long));
        }
        
        /// <summary>
        ///     Plots the shaded using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="yref">The yref</param>
        /// <param name="xscale">The xscale</param>
        /// <param name="xstart">The xstart</param>
        public static void PlotShaded(string labelId, long[] values, int count, double yref, double xscale, double xstart)
        {
            ImPlotNative.ImPlot_PlotShaded_S64PtrInt(Encoding.UTF8.GetBytes(labelId), values, count, yref, xscale, xstart, 0, 0, sizeof(long));
        }
        
        /// <summary>
        ///     Plots the shaded using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="yref">The yref</param>
        /// <param name="xscale">The xscale</param>
        /// <param name="xstart">The xstart</param>
        /// <param name="flags">The flags</param>
        public static void PlotShaded(string labelId, long[] values, int count, double yref, double xscale, double xstart, ImPlotShadedFlags flags)
        {
            ImPlotNative.ImPlot_PlotShaded_S64PtrInt(Encoding.UTF8.GetBytes(labelId), values, count, yref, xscale, xstart, flags, 0, sizeof(long));
        }
        
        /// <summary>
        ///     Plots the shaded using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="yref">The yref</param>
        /// <param name="xscale">The xscale</param>
        /// <param name="xstart">The xstart</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        public static void PlotShaded(string labelId, long[] values, int count, double yref, double xscale, double xstart, ImPlotShadedFlags flags, int offset)
        {
            ImPlotNative.ImPlot_PlotShaded_S64PtrInt(Encoding.UTF8.GetBytes(labelId), values, count, yref, xscale, xstart, flags, offset, sizeof(long));
        }
        
        /// <summary>
        ///     Plots the shaded using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="yref">The yref</param>
        /// <param name="xscale">The xscale</param>
        /// <param name="xstart">The xstart</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        /// <param name="stride">The stride</param>
        public static void PlotShaded(string labelId, long[] values, int count, double yref, double xscale, double xstart, ImPlotShadedFlags flags, int offset, int stride)
        {
            ImPlotNative.ImPlot_PlotShaded_S64PtrInt(Encoding.UTF8.GetBytes(labelId), values, count, yref, xscale, xstart, flags, offset, stride);
        }
        
        /// <summary>
        ///     Plots the shaded using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        public static void PlotShaded(string labelId, ulong[] values, int count)
        {
            ImPlotNative.ImPlot_PlotShaded_U64PtrInt(Encoding.UTF8.GetBytes(labelId), values, count, 0, 1, 0, 0, 0, sizeof(ulong));
        }
        
        /// <summary>
        ///     Plots the shaded using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="yref">The yref</param>
        public static void PlotShaded(string labelId, ulong[] values, int count, double yref)
        {
            ImPlotNative.ImPlot_PlotShaded_U64PtrInt(Encoding.UTF8.GetBytes(labelId), values, count, yref, 1, 0, 0, 0, sizeof(ulong));
        }
        
        /// <summary>
        ///     Plots the shaded using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="yref">The yref</param>
        /// <param name="xscale">The xscale</param>
        public static void PlotShaded(string labelId, ulong[] values, int count, double yref, double xscale)
        {
            ImPlotNative.ImPlot_PlotShaded_U64PtrInt(Encoding.UTF8.GetBytes(labelId), values, count, yref, xscale, 0, 0, 0, sizeof(ulong));
        }
        
        /// <summary>
        ///     Plots the shaded using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="yref">The yref</param>
        /// <param name="xscale">The xscale</param>
        /// <param name="xstart">The xstart</param>
        public static void PlotShaded(string labelId, ulong[] values, int count, double yref, double xscale, double xstart)
        {
            ImPlotNative.ImPlot_PlotShaded_U64PtrInt(Encoding.UTF8.GetBytes(labelId), values, count, yref, xscale, xstart, 0, 0, sizeof(ulong));
        }
        
        /// <summary>
        ///     Plots the shaded using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="yref">The yref</param>
        /// <param name="xscale">The xscale</param>
        /// <param name="xstart">The xstart</param>
        /// <param name="flags">The flags</param>
        public static void PlotShaded(string labelId, ulong[] values, int count, double yref, double xscale, double xstart, ImPlotShadedFlags flags)
        {
            ImPlotNative.ImPlot_PlotShaded_U64PtrInt(Encoding.UTF8.GetBytes(labelId), values, count, yref, xscale, xstart, flags, 0, sizeof(ulong));
        }
        
        /// <summary>
        ///     Plots the shaded using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="yref">The yref</param>
        /// <param name="xscale">The xscale</param>
        /// <param name="xstart">The xstart</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        public static void PlotShaded(string labelId, ulong[] values, int count, double yref, double xscale, double xstart, ImPlotShadedFlags flags, int offset)
        {
            ImPlotNative.ImPlot_PlotShaded_U64PtrInt(Encoding.UTF8.GetBytes(labelId), values, count, yref, xscale, xstart, flags, offset, sizeof(ulong));
        }
        
        /// <summary>
        ///     Plots the shaded using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="yref">The yref</param>
        /// <param name="xscale">The xscale</param>
        /// <param name="xstart">The xstart</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        /// <param name="stride">The stride</param>
        public static void PlotShaded(string labelId, ulong[] values, int count, double yref, double xscale, double xstart, ImPlotShadedFlags flags, int offset, int stride)
        {
            ImPlotNative.ImPlot_PlotShaded_U64PtrInt(Encoding.UTF8.GetBytes(labelId), values, count, yref, xscale, xstart, flags, offset, stride);
        }
        
        /// <summary>
        ///     Plots the shaded using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="count">The count</param>
        public static void PlotShaded(string labelId, ref float xs, ref float ys, int count)
        {
            ImPlotNative.ImPlot_PlotShaded_FloatPtrFloatPtrInt(Encoding.UTF8.GetBytes(labelId), ref xs, ref ys, count,   0, ImPlotShadedFlags.None, 0,  sizeof(float));
        }
        
        /// <summary>
        ///     Plots the shaded using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="count">The count</param>
        /// <param name="yref">The yref</param>
        public static void PlotShaded(string labelId, ref float xs, ref float ys, int count, double yref)
        {
            ImPlotNative.ImPlot_PlotShaded_FloatPtrFloatPtrInt(Encoding.UTF8.GetBytes(labelId), ref xs, ref ys, count, yref, ImPlotShadedFlags.None, 0, sizeof(float));
        }
        
        /// <summary>
        ///     Plots the shaded using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="count">The count</param>
        /// <param name="yref">The yref</param>
        /// <param name="flags">The flags</param>
        public static void PlotShaded(string labelId, ref float xs, ref float ys, int count, double yref, ImPlotShadedFlags flags)
        {
            ImPlotNative.ImPlot_PlotShaded_FloatPtrFloatPtrInt(Encoding.UTF8.GetBytes(labelId), ref xs, ref ys, count, yref, flags, 0, sizeof(float));
        }
        
        /// <summary>
        ///     Plots the shaded using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="count">The count</param>
        /// <param name="yref">The yref</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        public static void PlotShaded(string labelId, ref float xs, ref float ys, int count, double yref, ImPlotShadedFlags flags, int offset)
        {
            ImPlotNative.ImPlot_PlotShaded_FloatPtrFloatPtrInt(Encoding.UTF8.GetBytes(labelId), ref xs, ref ys, count, yref, flags, offset, sizeof(float));
        }
        
        /// <summary>
        ///     Plots the shaded using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="count">The count</param>
        /// <param name="yref">The yref</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        /// <param name="stride">The stride</param>
        public static void PlotShaded(string labelId, ref float xs, ref float ys, int count, double yref, ImPlotShadedFlags flags, int offset, int stride)
        {
            ImPlotNative.ImPlot_PlotShaded_FloatPtrFloatPtrInt(Encoding.UTF8.GetBytes(labelId), ref xs, ref ys, count, yref, flags, offset, stride);
        }
        
        /// <summary>
        ///     Plots the shaded using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="count">The count</param>
        public static void PlotShaded(string labelId, ref double xs, ref double ys, int count)
        {
            ImPlotNative.ImPlot_PlotShaded_doublePtrdoublePtrInt(Encoding.UTF8.GetBytes(labelId), ref xs, ref ys, count, 0, ImPlotShadedFlags.None, 0,  sizeof(double));
        }
        
        /// <summary>
        ///     Plots the shaded using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="count">The count</param>
        /// <param name="yref">The yref</param>
        public static void PlotShaded(string labelId, ref double xs, ref double ys, int count, double yref)
        {
            ImPlotNative.ImPlot_PlotShaded_doublePtrdoublePtrInt(Encoding.UTF8.GetBytes(labelId), ref xs, ref ys, count, yref, ImPlotShadedFlags.None, 0, sizeof(double));
        }
        
        /// <summary>
        ///     Plots the shaded using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="count">The count</param>
        /// <param name="yref">The yref</param>
        /// <param name="flags">The flags</param>
        public static void PlotShaded(string labelId, ref double xs, ref double ys, int count, double yref, ImPlotShadedFlags flags)
        {
            ImPlotNative.ImPlot_PlotShaded_doublePtrdoublePtrInt(Encoding.UTF8.GetBytes(labelId), ref xs, ref ys, count, yref, flags, 0, sizeof(double));
        }
        
        /// <summary>
        ///     Plots the shaded using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="count">The count</param>
        /// <param name="yref">The yref</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        public static void PlotShaded(string labelId, ref double xs, ref double ys, int count, double yref, ImPlotShadedFlags flags, int offset)
        {
            ImPlotNative.ImPlot_PlotShaded_doublePtrdoublePtrInt(Encoding.UTF8.GetBytes(labelId), ref xs, ref ys, count, yref, flags, offset, sizeof(double));
        }
        
        /// <summary>
        ///     Plots the shaded using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="count">The count</param>
        /// <param name="yref">The yref</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        /// <param name="stride">The stride</param>
        public static void PlotShaded(string labelId, ref double xs, ref double ys, int count, double yref, ImPlotShadedFlags flags, int offset, int stride)
        {
            ImPlotNative.ImPlot_PlotShaded_doublePtrdoublePtrInt(Encoding.UTF8.GetBytes(labelId), ref xs, ref ys, count, yref, flags, offset, stride);
        }
    }
}