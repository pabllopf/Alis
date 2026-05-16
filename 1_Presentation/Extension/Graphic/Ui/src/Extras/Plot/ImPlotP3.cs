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

namespace Alis.Extension.Graphic.Ui.Extras.Plot
{
    /// <summary>
    ///     Provides managed wrappers over the CImPlot native library for creating and interacting with ImPlot plots.
    /// </summary>
    public static partial class ImPlot
    {
        /// <summary>
        ///     Plots the error bars using the specified label id
        /// </summary>
        /// <param name="labelId">The label identifier for the plot item</param>
        /// <param name="xs">The array of x-coordinate values</param>
        /// <param name="ys">The array of y-coordinate values</param>
        /// <param name="err">The error value/array for error bars</param>
        /// <param name="count">The number of elements</param>
        /// <param name="flags">The ImGui behavior flags</param>
        /// <param name="offset">The offset from the origin</param>
        public static void PlotErrorBars(string labelId, ref float xs, ref float ys, ref float err, int count, ImPlotErrorBarsFlags flags, int offset)
        {
            ImPlotNative.ImPlot_PlotErrorBars_FloatPtrFloatPtrFloatPtrInt(Encoding.UTF8.GetBytes(labelId), ref xs, ref ys, err, count, flags, offset, sizeof(float));
        }

        /// <summary>
        ///     Plots the error bars using the specified label id
        /// </summary>
        /// <param name="labelId">The label identifier for the plot item</param>
        /// <param name="xs">The array of x-coordinate values</param>
        /// <param name="ys">The array of y-coordinate values</param>
        /// <param name="err">The error value/array for error bars</param>
        /// <param name="count">The number of elements</param>
        /// <param name="flags">The ImGui behavior flags</param>
        /// <param name="offset">The offset from the origin</param>
        /// <param name="stride">The byte stride between elements</param>
        public static void PlotErrorBars(string labelId, ref float xs, ref float ys, ref float err, int count, ImPlotErrorBarsFlags flags, int offset, int stride)
        {
            ImPlotNative.ImPlot_PlotErrorBars_FloatPtrFloatPtrFloatPtrInt(Encoding.UTF8.GetBytes(labelId), ref xs, ref ys, err, count, flags, offset, stride);
        }

        /// <summary>
        ///     Plots the error bars using the specified label id
        /// </summary>
        /// <param name="labelId">The label identifier for the plot item</param>
        /// <param name="xs">The array of x-coordinate values</param>
        /// <param name="ys">The array of y-coordinate values</param>
        /// <param name="err">The error value/array for error bars</param>
        /// <param name="count">The number of elements</param>
        public static void PlotErrorBars(string labelId, ref double xs, ref double ys, ref double err, int count)
        {
            ImPlotNative.ImPlot_PlotErrorBars_doublePtrdoublePtrdoublePtrInt(Encoding.UTF8.GetBytes(labelId), ref xs, ref ys, err, count, 0, 0, sizeof(double));
        }

        /// <summary>
        ///     Plots the error bars using the specified label id
        /// </summary>
        /// <param name="labelId">The label identifier for the plot item</param>
        /// <param name="xs">The array of x-coordinate values</param>
        /// <param name="ys">The array of y-coordinate values</param>
        /// <param name="err">The error value/array for error bars</param>
        /// <param name="count">The number of elements</param>
        /// <param name="flags">The ImGui behavior flags</param>
        public static void PlotErrorBars(string labelId, ref double xs, ref double ys, ref double err, int count, ImPlotErrorBarsFlags flags)
        {
            ImPlotNative.ImPlot_PlotErrorBars_doublePtrdoublePtrdoublePtrInt(Encoding.UTF8.GetBytes(labelId), ref xs, ref ys, err, count, flags, 0, sizeof(double));
        }

        /// <summary>
        ///     Plots the error bars using the specified label id
        /// </summary>
        /// <param name="labelId">The label identifier for the plot item</param>
        /// <param name="xs">The array of x-coordinate values</param>
        /// <param name="ys">The array of y-coordinate values</param>
        /// <param name="err">The error value/array for error bars</param>
        /// <param name="count">The number of elements</param>
        /// <param name="flags">The ImGui behavior flags</param>
        /// <param name="offset">The offset from the origin</param>
        public static void PlotErrorBars(string labelId, ref double xs, ref double ys, ref double err, int count, ImPlotErrorBarsFlags flags, int offset)
        {
            ImPlotNative.ImPlot_PlotErrorBars_doublePtrdoublePtrdoublePtrInt(Encoding.UTF8.GetBytes(labelId), ref xs, ref ys, err, count, flags, offset, sizeof(double));
        }

        /// <summary>
        ///     Plots the error bars using the specified label id
        /// </summary>
        /// <param name="labelId">The label identifier for the plot item</param>
        /// <param name="xs">The array of x-coordinate values</param>
        /// <param name="ys">The array of y-coordinate values</param>
        /// <param name="err">The error value/array for error bars</param>
        /// <param name="count">The number of elements</param>
        /// <param name="flags">The ImGui behavior flags</param>
        /// <param name="offset">The offset from the origin</param>
        /// <param name="stride">The byte stride between elements</param>
        public static void PlotErrorBars(string labelId, ref double xs, ref double ys, ref double err, int count, ImPlotErrorBarsFlags flags, int offset, int stride)
        {
            ImPlotNative.ImPlot_PlotErrorBars_doublePtrdoublePtrdoublePtrInt(Encoding.UTF8.GetBytes(labelId), ref xs, ref ys, err, count, flags, offset, stride);
        }

        /// <summary>
        ///     Plots the error bars using the specified label id
        /// </summary>
        /// <param name="labelId">The label identifier for the plot item</param>
        /// <param name="xs">The array of x-coordinate values</param>
        /// <param name="ys">The array of y-coordinate values</param>
        /// <param name="err">The error value/array for error bars</param>
        /// <param name="count">The number of elements</param>
        public static void PlotErrorBars(string labelId, ref sbyte xs, ref sbyte ys, ref sbyte err, int count)
        {
            ImPlotNative.ImPlot_PlotErrorBars_S8PtrS8PtrS8PtrInt(Encoding.UTF8.GetBytes(labelId), ref xs, ref ys, err, count, 0, 0, sizeof(sbyte));
        }

        /// <summary>
        ///     Plots the error bars using the specified label id
        /// </summary>
        /// <param name="labelId">The label identifier for the plot item</param>
        /// <param name="xs">The array of x-coordinate values</param>
        /// <param name="ys">The array of y-coordinate values</param>
        /// <param name="err">The error value/array for error bars</param>
        /// <param name="count">The number of elements</param>
        /// <param name="flags">The ImGui behavior flags</param>
        public static void PlotErrorBars(string labelId, ref sbyte xs, ref sbyte ys, ref sbyte err, int count, ImPlotErrorBarsFlags flags)
        {
            ImPlotNative.ImPlot_PlotErrorBars_S8PtrS8PtrS8PtrInt(Encoding.UTF8.GetBytes(labelId), ref xs, ref ys, err, count, flags, 0, sizeof(sbyte));
        }

        /// <summary>
        ///     Plots the error bars using the specified label id
        /// </summary>
        /// <param name="labelId">The label identifier for the plot item</param>
        /// <param name="xs">The array of x-coordinate values</param>
        /// <param name="ys">The array of y-coordinate values</param>
        /// <param name="err">The error value/array for error bars</param>
        /// <param name="count">The number of elements</param>
        /// <param name="flags">The ImGui behavior flags</param>
        /// <param name="offset">The offset from the origin</param>
        public static void PlotErrorBars(string labelId, ref sbyte xs, ref sbyte ys, ref sbyte err, int count, ImPlotErrorBarsFlags flags, int offset)
        {
            ImPlotNative.ImPlot_PlotErrorBars_S8PtrS8PtrS8PtrInt(Encoding.UTF8.GetBytes(labelId), ref xs, ref ys, err, count, flags, offset, sizeof(sbyte));
        }

        /// <summary>
        ///     Plots the error bars using the specified label id
        /// </summary>
        /// <param name="labelId">The label identifier for the plot item</param>
        /// <param name="xs">The array of x-coordinate values</param>
        /// <param name="ys">The array of y-coordinate values</param>
        /// <param name="err">The error value/array for error bars</param>
        /// <param name="count">The number of elements</param>
        /// <param name="flags">The ImGui behavior flags</param>
        /// <param name="offset">The offset from the origin</param>
        /// <param name="stride">The byte stride between elements</param>
        public static void PlotErrorBars(string labelId, ref sbyte xs, ref sbyte ys, ref sbyte err, int count, ImPlotErrorBarsFlags flags, int offset, int stride)
        {
            ImPlotNative.ImPlot_PlotErrorBars_S8PtrS8PtrS8PtrInt(Encoding.UTF8.GetBytes(labelId), ref xs, ref ys, err, count, flags, offset, stride);
        }

        /// <summary>
        ///     Plots the error bars using the specified label id
        /// </summary>
        /// <param name="labelId">The label identifier for the plot item</param>
        /// <param name="xs">The array of x-coordinate values</param>
        /// <param name="ys">The array of y-coordinate values</param>
        /// <param name="err">The error value/array for error bars</param>
        /// <param name="count">The number of elements</param>
        public static void PlotErrorBars(string labelId, ref byte xs, ref byte ys, ref byte err, int count)
        {
            ImPlotNative.ImPlot_PlotErrorBars_U8PtrU8PtrU8PtrInt(Encoding.UTF8.GetBytes(labelId), xs, ys, err, count, 0, 0, sizeof(byte));
        }

        /// <summary>
        ///     Plots the error bars using the specified label id
        /// </summary>
        /// <param name="labelId">The label identifier for the plot item</param>
        /// <param name="xs">The array of x-coordinate values</param>
        /// <param name="ys">The array of y-coordinate values</param>
        /// <param name="err">The error value/array for error bars</param>
        /// <param name="count">The number of elements</param>
        /// <param name="flags">The ImGui behavior flags</param>
        public static void PlotErrorBars(string labelId, ref byte xs, ref byte ys, ref byte err, int count, ImPlotErrorBarsFlags flags)
        {
            ImPlotNative.ImPlot_PlotErrorBars_U8PtrU8PtrU8PtrInt(Encoding.UTF8.GetBytes(labelId), xs, ys, err, count, flags, 0, sizeof(byte));
        }

        /// <summary>
        ///     Plots the error bars using the specified label id
        /// </summary>
        /// <param name="labelId">The label identifier for the plot item</param>
        /// <param name="xs">The array of x-coordinate values</param>
        /// <param name="ys">The array of y-coordinate values</param>
        /// <param name="err">The error value/array for error bars</param>
        /// <param name="count">The number of elements</param>
        /// <param name="flags">The ImGui behavior flags</param>
        /// <param name="offset">The offset from the origin</param>
        public static void PlotErrorBars(string labelId, ref byte xs, ref byte ys, ref byte err, int count, ImPlotErrorBarsFlags flags, int offset)
        {
            ImPlotNative.ImPlot_PlotErrorBars_U8PtrU8PtrU8PtrInt(Encoding.UTF8.GetBytes(labelId), xs, ys, err, count, flags, offset, sizeof(byte));
        }

        /// <summary>
        ///     Plots the error bars using the specified label id
        /// </summary>
        /// <param name="labelId">The label identifier for the plot item</param>
        /// <param name="xs">The array of x-coordinate values</param>
        /// <param name="ys">The array of y-coordinate values</param>
        /// <param name="err">The error value/array for error bars</param>
        /// <param name="count">The number of elements</param>
        /// <param name="flags">The ImGui behavior flags</param>
        /// <param name="offset">The offset from the origin</param>
        /// <param name="stride">The byte stride between elements</param>
        public static void PlotErrorBars(string labelId, ref byte xs, ref byte ys, ref byte err, int count, ImPlotErrorBarsFlags flags, int offset, int stride)
        {
            ImPlotNative.ImPlot_PlotErrorBars_U8PtrU8PtrU8PtrInt(Encoding.UTF8.GetBytes(labelId), xs, ys, err, count, flags, offset, stride);
        }

        /// <summary>
        ///     Plots the error bars using the specified label id
        /// </summary>
        /// <param name="labelId">The label identifier for the plot item</param>
        /// <param name="xs">The array of x-coordinate values</param>
        /// <param name="ys">The array of y-coordinate values</param>
        /// <param name="err">The error value/array for error bars</param>
        /// <param name="count">The number of elements</param>
        public static void PlotErrorBars(string labelId, ref short xs, ref short ys, ref short err, int count)
        {
            ImPlotNative.ImPlot_PlotErrorBars_S16PtrS16PtrS16PtrInt(Encoding.UTF8.GetBytes(labelId), xs, ys, err, count, 0, 0, sizeof(short));
        }

        /// <summary>
        ///     Plots the error bars using the specified label id
        /// </summary>
        /// <param name="labelId">The label identifier for the plot item</param>
        /// <param name="xs">The array of x-coordinate values</param>
        /// <param name="ys">The array of y-coordinate values</param>
        /// <param name="err">The error value/array for error bars</param>
        /// <param name="count">The number of elements</param>
        /// <param name="flags">The ImGui behavior flags</param>
        public static void PlotErrorBars(string labelId, ref short xs, ref short ys, ref short err, int count, ImPlotErrorBarsFlags flags)
        {
            ImPlotNative.ImPlot_PlotErrorBars_S16PtrS16PtrS16PtrInt(Encoding.UTF8.GetBytes(labelId), xs, ys, err, count, flags, 0, sizeof(short));
        }

        /// <summary>
        ///     Plots the error bars using the specified label id
        /// </summary>
        /// <param name="labelId">The label identifier for the plot item</param>
        /// <param name="xs">The array of x-coordinate values</param>
        /// <param name="ys">The array of y-coordinate values</param>
        /// <param name="err">The error value/array for error bars</param>
        /// <param name="count">The number of elements</param>
        /// <param name="flags">The ImGui behavior flags</param>
        /// <param name="offset">The offset from the origin</param>
        public static void PlotErrorBars(string labelId, ref short xs, ref short ys, ref short err, int count, ImPlotErrorBarsFlags flags, int offset)
        {
            ImPlotNative.ImPlot_PlotErrorBars_S16PtrS16PtrS16PtrInt(Encoding.UTF8.GetBytes(labelId), xs, ys, err, count, flags, offset, sizeof(short));
        }

        /// <summary>
        ///     Plots the error bars using the specified label id
        /// </summary>
        /// <param name="labelId">The label identifier for the plot item</param>
        /// <param name="xs">The array of x-coordinate values</param>
        /// <param name="ys">The array of y-coordinate values</param>
        /// <param name="err">The error value/array for error bars</param>
        /// <param name="count">The number of elements</param>
        /// <param name="flags">The ImGui behavior flags</param>
        /// <param name="offset">The offset from the origin</param>
        /// <param name="stride">The byte stride between elements</param>
        public static void PlotErrorBars(string labelId, ref short xs, ref short ys, ref short err, int count, ImPlotErrorBarsFlags flags, int offset, int stride)
        {
            ImPlotNative.ImPlot_PlotErrorBars_S16PtrS16PtrS16PtrInt(Encoding.UTF8.GetBytes(labelId), xs, ys, err, count, flags, offset, stride);
        }

        /// <summary>
        ///     Plots the error bars using the specified label id
        /// </summary>
        /// <param name="labelId">The label identifier for the plot item</param>
        /// <param name="xs">The array of x-coordinate values</param>
        /// <param name="ys">The array of y-coordinate values</param>
        /// <param name="err">The error value/array for error bars</param>
        /// <param name="count">The number of elements</param>
        public static void PlotErrorBars(string labelId, ref ushort xs, ref ushort ys, ref ushort err, int count)
        {
            ImPlotNative.ImPlot_PlotErrorBars_U16PtrU16PtrU16PtrInt(Encoding.UTF8.GetBytes(labelId), ref xs, ref ys, err, count, 0, 0, sizeof(ushort));
        }

        /// <summary>
        ///     Plots the error bars using the specified label id
        /// </summary>
        /// <param name="labelId">The label identifier for the plot item</param>
        /// <param name="xs">The array of x-coordinate values</param>
        /// <param name="ys">The array of y-coordinate values</param>
        /// <param name="err">The error value/array for error bars</param>
        /// <param name="count">The number of elements</param>
        /// <param name="flags">The ImGui behavior flags</param>
        public static void PlotErrorBars(string labelId, ref ushort xs, ref ushort ys, ref ushort err, int count, ImPlotErrorBarsFlags flags)
        {
            ImPlotNative.ImPlot_PlotErrorBars_U16PtrU16PtrU16PtrInt(Encoding.UTF8.GetBytes(labelId), ref xs, ref ys, err, count, flags, 0, sizeof(ushort));
        }

        /// <summary>
        ///     Plots the error bars using the specified label id
        /// </summary>
        /// <param name="labelId">The label identifier for the plot item</param>
        /// <param name="xs">The array of x-coordinate values</param>
        /// <param name="ys">The array of y-coordinate values</param>
        /// <param name="err">The error value/array for error bars</param>
        /// <param name="count">The number of elements</param>
        /// <param name="flags">The ImGui behavior flags</param>
        /// <param name="offset">The offset from the origin</param>
        public static void PlotErrorBars(string labelId, ref ushort xs, ref ushort ys, ref ushort err, int count, ImPlotErrorBarsFlags flags, int offset)
        {
            ImPlotNative.ImPlot_PlotErrorBars_U16PtrU16PtrU16PtrInt(Encoding.UTF8.GetBytes(labelId), ref xs, ref ys, err, count, flags, offset, sizeof(ushort));
        }

        /// <summary>
        ///     Plots the error bars using the specified label id
        /// </summary>
        /// <param name="labelId">The label identifier for the plot item</param>
        /// <param name="xs">The array of x-coordinate values</param>
        /// <param name="ys">The array of y-coordinate values</param>
        /// <param name="err">The error value/array for error bars</param>
        /// <param name="count">The number of elements</param>
        /// <param name="flags">The ImGui behavior flags</param>
        /// <param name="offset">The offset from the origin</param>
        /// <param name="stride">The byte stride between elements</param>
        public static void PlotErrorBars(string labelId, ref ushort xs, ref ushort ys, ref ushort err, int count, ImPlotErrorBarsFlags flags, int offset, int stride)
        {
            ImPlotNative.ImPlot_PlotErrorBars_U16PtrU16PtrU16PtrInt(Encoding.UTF8.GetBytes(labelId), ref xs, ref ys, err, count, flags, offset, stride);
        }

        /// <summary>
        ///     Plots the error bars using the specified label id
        /// </summary>
        /// <param name="labelId">The label identifier for the plot item</param>
        /// <param name="xs">The array of x-coordinate values</param>
        /// <param name="ys">The array of y-coordinate values</param>
        /// <param name="err">The error value/array for error bars</param>
        /// <param name="count">The number of elements</param>
        public static void PlotErrorBars(string labelId, ref int xs, ref int ys, ref int err, int count)
        {
            ImPlotNative.ImPlot_PlotErrorBars_S32PtrS32PtrS32PtrInt(Encoding.UTF8.GetBytes(labelId), xs, ys, err, count, 0, 0, sizeof(int));
        }

        /// <summary>
        ///     Plots the error bars using the specified label id
        /// </summary>
        /// <param name="labelId">The label identifier for the plot item</param>
        /// <param name="xs">The array of x-coordinate values</param>
        /// <param name="ys">The array of y-coordinate values</param>
        /// <param name="err">The error value/array for error bars</param>
        /// <param name="count">The number of elements</param>
        /// <param name="flags">The ImGui behavior flags</param>
        public static void PlotErrorBars(string labelId, ref int xs, ref int ys, ref int err, int count, ImPlotErrorBarsFlags flags)
        {
            ImPlotNative.ImPlot_PlotErrorBars_S32PtrS32PtrS32PtrInt(Encoding.UTF8.GetBytes(labelId), xs, ys, err, count, flags, 0, sizeof(int));
        }

        /// <summary>
        ///     Plots the error bars using the specified label id
        /// </summary>
        /// <param name="labelId">The label identifier for the plot item</param>
        /// <param name="xs">The array of x-coordinate values</param>
        /// <param name="ys">The array of y-coordinate values</param>
        /// <param name="err">The error value/array for error bars</param>
        /// <param name="count">The number of elements</param>
        /// <param name="flags">The ImGui behavior flags</param>
        /// <param name="offset">The offset from the origin</param>
        public static void PlotErrorBars(string labelId, ref int xs, ref int ys, ref int err, int count, ImPlotErrorBarsFlags flags, int offset)
        {
            ImPlotNative.ImPlot_PlotErrorBars_S32PtrS32PtrS32PtrInt(Encoding.UTF8.GetBytes(labelId), xs, ys, err, count, flags, offset, sizeof(int));
        }

        /// <summary>
        ///     Plots the error bars using the specified label id
        /// </summary>
        /// <param name="labelId">The label identifier for the plot item</param>
        /// <param name="xs">The array of x-coordinate values</param>
        /// <param name="ys">The array of y-coordinate values</param>
        /// <param name="err">The error value/array for error bars</param>
        /// <param name="count">The number of elements</param>
        /// <param name="flags">The ImGui behavior flags</param>
        /// <param name="offset">The offset from the origin</param>
        /// <param name="stride">The byte stride between elements</param>
        public static void PlotErrorBars(string labelId, ref int xs, ref int ys, ref int err, int count, ImPlotErrorBarsFlags flags, int offset, int stride)
        {
            ImPlotNative.ImPlot_PlotErrorBars_S32PtrS32PtrS32PtrInt(Encoding.UTF8.GetBytes(labelId), xs, ys, err, count, flags, offset, stride);
        }

        /// <summary>
        ///     Plots the error bars using the specified label id
        /// </summary>
        /// <param name="labelId">The label identifier for the plot item</param>
        /// <param name="xs">The array of x-coordinate values</param>
        /// <param name="ys">The array of y-coordinate values</param>
        /// <param name="err">The error value/array for error bars</param>
        /// <param name="count">The number of elements</param>
        public static void PlotErrorBars(string labelId, ref uint xs, ref uint ys, ref uint err, int count)
        {
            ImPlotNative.ImPlot_PlotErrorBars_U32PtrU32PtrU32PtrInt(Encoding.UTF8.GetBytes(labelId), xs, ys, err, count, 0, 0, sizeof(uint));
        }

        /// <summary>
        ///     Plots the error bars using the specified label id
        /// </summary>
        /// <param name="labelId">The label identifier for the plot item</param>
        /// <param name="xs">The array of x-coordinate values</param>
        /// <param name="ys">The array of y-coordinate values</param>
        /// <param name="err">The error value/array for error bars</param>
        /// <param name="count">The number of elements</param>
        /// <param name="flags">The ImGui behavior flags</param>
        public static void PlotErrorBars(string labelId, ref uint xs, ref uint ys, ref uint err, int count, ImPlotErrorBarsFlags flags)
        {
            ImPlotNative.ImPlot_PlotErrorBars_U32PtrU32PtrU32PtrInt(Encoding.UTF8.GetBytes(labelId), xs, ys, err, count, flags, 0, sizeof(uint));
        }

        /// <summary>
        ///     Plots the error bars using the specified label id
        /// </summary>
        /// <param name="labelId">The label identifier for the plot item</param>
        /// <param name="xs">The array of x-coordinate values</param>
        /// <param name="ys">The array of y-coordinate values</param>
        /// <param name="err">The error value/array for error bars</param>
        /// <param name="count">The number of elements</param>
        /// <param name="flags">The ImGui behavior flags</param>
        /// <param name="offset">The offset from the origin</param>
        public static void PlotErrorBars(string labelId, ref uint xs, ref uint ys, ref uint err, int count, ImPlotErrorBarsFlags flags, int offset)
        {
            ImPlotNative.ImPlot_PlotErrorBars_U32PtrU32PtrU32PtrInt(Encoding.UTF8.GetBytes(labelId), xs, ys, err, count, flags, offset, sizeof(uint));
        }

        /// <summary>
        ///     Plots the error bars using the specified label id
        /// </summary>
        /// <param name="labelId">The label identifier for the plot item</param>
        /// <param name="xs">The array of x-coordinate values</param>
        /// <param name="ys">The array of y-coordinate values</param>
        /// <param name="err">The error value/array for error bars</param>
        /// <param name="count">The number of elements</param>
        /// <param name="flags">The ImGui behavior flags</param>
        /// <param name="offset">The offset from the origin</param>
        /// <param name="stride">The byte stride between elements</param>
        public static void PlotErrorBars(string labelId, ref uint xs, ref uint ys, ref uint err, int count, ImPlotErrorBarsFlags flags, int offset, int stride)
        {
            ImPlotNative.ImPlot_PlotErrorBars_U32PtrU32PtrU32PtrInt(Encoding.UTF8.GetBytes(labelId), xs, ys, err, count, flags, offset, stride);
        }

        /// <summary>
        ///     Plots the error bars using the specified label id
        /// </summary>
        /// <param name="labelId">The label identifier for the plot item</param>
        /// <param name="xs">The array of x-coordinate values</param>
        /// <param name="ys">The array of y-coordinate values</param>
        /// <param name="err">The error value/array for error bars</param>
        /// <param name="count">The number of elements</param>
        public static void PlotErrorBars(string labelId, ref long xs, ref long ys, ref long err, int count)
        {
            ImPlotNative.ImPlot_PlotErrorBars_S64PtrS64PtrS64PtrInt(Encoding.UTF8.GetBytes(labelId), ref xs, ref ys, err, count, 0, 0, sizeof(long));
        }

        /// <summary>
        ///     Plots the error bars using the specified label id
        /// </summary>
        /// <param name="labelId">The label identifier for the plot item</param>
        /// <param name="xs">The array of x-coordinate values</param>
        /// <param name="ys">The array of y-coordinate values</param>
        /// <param name="err">The error value/array for error bars</param>
        /// <param name="count">The number of elements</param>
        /// <param name="flags">The ImGui behavior flags</param>
        public static void PlotErrorBars(string labelId, ref long xs, ref long ys, ref long err, int count, ImPlotErrorBarsFlags flags)
        {
            ImPlotNative.ImPlot_PlotErrorBars_S64PtrS64PtrS64PtrInt(Encoding.UTF8.GetBytes(labelId), ref xs, ref ys, err, count, flags, 0, sizeof(long));
        }

        /// <summary>
        ///     Plots the error bars using the specified label id
        /// </summary>
        /// <param name="labelId">The label identifier for the plot item</param>
        /// <param name="xs">The array of x-coordinate values</param>
        /// <param name="ys">The array of y-coordinate values</param>
        /// <param name="err">The error value/array for error bars</param>
        /// <param name="count">The number of elements</param>
        /// <param name="flags">The ImGui behavior flags</param>
        /// <param name="offset">The offset from the origin</param>
        public static void PlotErrorBars(string labelId, ref long xs, ref long ys, ref long err, int count, ImPlotErrorBarsFlags flags, int offset)
        {
            ImPlotNative.ImPlot_PlotErrorBars_S64PtrS64PtrS64PtrInt(Encoding.UTF8.GetBytes(labelId), ref xs, ref ys, err, count, flags, offset, sizeof(long));
        }

        /// <summary>
        ///     Plots the error bars using the specified label id
        /// </summary>
        /// <param name="labelId">The label identifier for the plot item</param>
        /// <param name="xs">The array of x-coordinate values</param>
        /// <param name="ys">The array of y-coordinate values</param>
        /// <param name="err">The error value/array for error bars</param>
        /// <param name="count">The number of elements</param>
        /// <param name="flags">The ImGui behavior flags</param>
        /// <param name="offset">The offset from the origin</param>
        /// <param name="stride">The byte stride between elements</param>
        public static void PlotErrorBars(string labelId, ref long xs, ref long ys, ref long err, int count, ImPlotErrorBarsFlags flags, int offset, int stride)
        {
            ImPlotNative.ImPlot_PlotErrorBars_S64PtrS64PtrS64PtrInt(Encoding.UTF8.GetBytes(labelId), ref xs, ref ys, err, count, flags, offset, stride);
        }

        /// <summary>
        ///     Plots the error bars using the specified label id
        /// </summary>
        /// <param name="labelId">The label identifier for the plot item</param>
        /// <param name="xs">The array of x-coordinate values</param>
        /// <param name="ys">The array of y-coordinate values</param>
        /// <param name="err">The error value/array for error bars</param>
        /// <param name="count">The number of elements</param>
        public static void PlotErrorBars(string labelId, ref ulong xs, ref ulong ys, ref ulong err, int count)
        {
            ImPlotNative.ImPlot_PlotErrorBars_U64PtrU64PtrU64PtrInt(Encoding.UTF8.GetBytes(labelId), ref xs, ref ys, err, count, 0, 0, sizeof(ulong));
        }

        /// <summary>
        ///     Plots the error bars using the specified label id
        /// </summary>
        /// <param name="labelId">The label identifier for the plot item</param>
        /// <param name="xs">The array of x-coordinate values</param>
        /// <param name="ys">The array of y-coordinate values</param>
        /// <param name="err">The error value/array for error bars</param>
        /// <param name="count">The number of elements</param>
        /// <param name="flags">The ImGui behavior flags</param>
        public static void PlotErrorBars(string labelId, ref ulong xs, ref ulong ys, ref ulong err, int count, ImPlotErrorBarsFlags flags)
        {
            ImPlotNative.ImPlot_PlotErrorBars_U64PtrU64PtrU64PtrInt(Encoding.UTF8.GetBytes(labelId), ref xs, ref ys, err, count, flags, 0, sizeof(ulong));
        }

        /// <summary>
        ///     Plots the error bars using the specified label id
        /// </summary>
        /// <param name="labelId">The label identifier for the plot item</param>
        /// <param name="xs">The array of x-coordinate values</param>
        /// <param name="ys">The array of y-coordinate values</param>
        /// <param name="err">The error value/array for error bars</param>
        /// <param name="count">The number of elements</param>
        /// <param name="flags">The ImGui behavior flags</param>
        /// <param name="offset">The offset from the origin</param>
        public static void PlotErrorBars(string labelId, ref ulong xs, ref ulong ys, ref ulong err, int count, ImPlotErrorBarsFlags flags, int offset)
        {
            ImPlotNative.ImPlot_PlotErrorBars_U64PtrU64PtrU64PtrInt(Encoding.UTF8.GetBytes(labelId), ref xs, ref ys, err, count, flags, offset, sizeof(ulong));
        }

        /// <summary>
        ///     Plots the error bars using the specified label id
        /// </summary>
        /// <param name="labelId">The label identifier for the plot item</param>
        /// <param name="xs">The array of x-coordinate values</param>
        /// <param name="ys">The array of y-coordinate values</param>
        /// <param name="err">The error value/array for error bars</param>
        /// <param name="count">The number of elements</param>
        /// <param name="flags">The ImGui behavior flags</param>
        /// <param name="offset">The offset from the origin</param>
        /// <param name="stride">The byte stride between elements</param>
        public static void PlotErrorBars(string labelId, ref ulong xs, ref ulong ys, ref ulong err, int count, ImPlotErrorBarsFlags flags, int offset, int stride)
        {
            ImPlotNative.ImPlot_PlotErrorBars_U64PtrU64PtrU64PtrInt(Encoding.UTF8.GetBytes(labelId), ref xs, ref ys, err, count, flags, offset, stride);
        }

        /// <summary>
        ///     Plots the error bars using the specified label id
        /// </summary>
        /// <param name="labelId">The label identifier for the plot item</param>
        /// <param name="xs">The array of x-coordinate values</param>
        /// <param name="ys">The array of y-coordinate values</param>
        /// <param name="neg">The negative direction value</param>
        /// <param name="pos">The position in screen coordinates</param>
        /// <param name="count">The number of elements</param>
        public static void PlotErrorBars(string labelId, ref float xs, ref float ys, ref float neg, ref float pos, int count)
        {
            ImPlotNative.ImPlot_PlotErrorBars_FloatPtrFloatPtrFloatPtrFloatPtr(Encoding.UTF8.GetBytes(labelId), ref xs, ref ys, neg, pos, count, ImPlotErrorBarsFlags.None, 0, 0);
        }

        /// <summary>
        ///     Plots the error bars using the specified label id
        /// </summary>
        /// <param name="labelId">The label identifier for the plot item</param>
        /// <param name="xs">The array of x-coordinate values</param>
        /// <param name="ys">The array of y-coordinate values</param>
        /// <param name="neg">The negative direction value</param>
        /// <param name="pos">The position in screen coordinates</param>
        /// <param name="count">The number of elements</param>
        /// <param name="flags">The ImGui behavior flags</param>
        public static void PlotErrorBars(string labelId, ref float xs, ref float ys, ref float neg, ref float pos, int count, ImPlotErrorBarsFlags flags)
        {
            ImPlotNative.ImPlot_PlotErrorBars_FloatPtrFloatPtrFloatPtrFloatPtr(Encoding.UTF8.GetBytes(labelId), ref xs, ref ys, neg, pos, count, flags, 0, 0);
        }

        /// <summary>
        ///     Plots the error bars using the specified label id
        /// </summary>
        /// <param name="labelId">The label identifier for the plot item</param>
        /// <param name="xs">The array of x-coordinate values</param>
        /// <param name="ys">The array of y-coordinate values</param>
        /// <param name="neg">The negative direction value</param>
        /// <param name="pos">The position in screen coordinates</param>
        /// <param name="count">The number of elements</param>
        /// <param name="flags">The ImGui behavior flags</param>
        /// <param name="offset">The offset from the origin</param>
        public static void PlotErrorBars(string labelId, ref float xs, ref float ys, ref float neg, ref float pos, int count, ImPlotErrorBarsFlags flags, int offset)
        {
            ImPlotNative.ImPlot_PlotErrorBars_FloatPtrFloatPtrFloatPtrFloatPtr(Encoding.UTF8.GetBytes(labelId), ref xs, ref ys, neg, pos, count, flags, offset, 0);
        }

        /// <summary>
        ///     Plots the error bars using the specified label id
        /// </summary>
        /// <param name="labelId">The label identifier for the plot item</param>
        /// <param name="xs">The array of x-coordinate values</param>
        /// <param name="ys">The array of y-coordinate values</param>
        /// <param name="neg">The negative direction value</param>
        /// <param name="pos">The position in screen coordinates</param>
        /// <param name="count">The number of elements</param>
        /// <param name="flags">The ImGui behavior flags</param>
        /// <param name="offset">The offset from the origin</param>
        /// <param name="stride">The byte stride between elements</param>
        public static void PlotErrorBars(string labelId, ref float xs, ref float ys, ref float neg, ref float pos, int count, ImPlotErrorBarsFlags flags, int offset, int stride)
        {
            ImPlotNative.ImPlot_PlotErrorBars_FloatPtrFloatPtrFloatPtrFloatPtr(Encoding.UTF8.GetBytes(labelId), ref xs, ref ys, neg, pos, count, flags, offset, stride);
        }

        /// <summary>
        ///     Plots the error bars using the specified label id
        /// </summary>
        /// <param name="labelId">The label identifier for the plot item</param>
        /// <param name="xs">The array of x-coordinate values</param>
        /// <param name="ys">The array of y-coordinate values</param>
        /// <param name="neg">The negative direction value</param>
        /// <param name="pos">The position in screen coordinates</param>
        /// <param name="count">The number of elements</param>
        public static void PlotErrorBars(string labelId, ref double xs, ref double ys, ref double neg, ref double pos, int count)
        {
            ImPlotNative.ImPlot_PlotErrorBars_doublePtrdoublePtrdoublePtrdoublePtr(Encoding.UTF8.GetBytes(labelId), ref xs, ref ys, neg, pos, count, ImPlotErrorBarsFlags.None, 0, 0);
        }

        /// <summary>
        ///     Plots the error bars using the specified label id
        /// </summary>
        /// <param name="labelId">The label identifier for the plot item</param>
        /// <param name="xs">The array of x-coordinate values</param>
        /// <param name="ys">The array of y-coordinate values</param>
        /// <param name="neg">The negative direction value</param>
        /// <param name="pos">The position in screen coordinates</param>
        /// <param name="count">The number of elements</param>
        /// <param name="flags">The ImGui behavior flags</param>
        public static void PlotErrorBars(string labelId, ref double xs, ref double ys, ref double neg, ref double pos, int count, ImPlotErrorBarsFlags flags)
        {
            ImPlotNative.ImPlot_PlotErrorBars_doublePtrdoublePtrdoublePtrdoublePtr(Encoding.UTF8.GetBytes(labelId), ref xs, ref ys, neg, pos, count, flags, 0, 0);
        }

        /// <summary>
        ///     Plots the error bars using the specified label id
        /// </summary>
        /// <param name="labelId">The label identifier for the plot item</param>
        /// <param name="xs">The array of x-coordinate values</param>
        /// <param name="ys">The array of y-coordinate values</param>
        /// <param name="neg">The negative direction value</param>
        /// <param name="pos">The position in screen coordinates</param>
        /// <param name="count">The number of elements</param>
        /// <param name="flags">The ImGui behavior flags</param>
        /// <param name="offset">The offset from the origin</param>
        public static void PlotErrorBars(string labelId, ref double xs, ref double ys, ref double neg, ref double pos, int count, ImPlotErrorBarsFlags flags, int offset)
        {
            ImPlotNative.ImPlot_PlotErrorBars_doublePtrdoublePtrdoublePtrdoublePtr(Encoding.UTF8.GetBytes(labelId), ref xs, ref ys, neg, pos, count, flags, offset, 0);
        }

        /// <summary>
        ///     Plots the error bars using the specified label id
        /// </summary>
        /// <param name="labelId">The label identifier for the plot item</param>
        /// <param name="xs">The array of x-coordinate values</param>
        /// <param name="ys">The array of y-coordinate values</param>
        /// <param name="neg">The negative direction value</param>
        /// <param name="pos">The position in screen coordinates</param>
        /// <param name="count">The number of elements</param>
        /// <param name="flags">The ImGui behavior flags</param>
        /// <param name="offset">The offset from the origin</param>
        /// <param name="stride">The byte stride between elements</param>
        public static void PlotErrorBars(string labelId, ref double xs, ref double ys, ref double neg, ref double pos, int count, ImPlotErrorBarsFlags flags, int offset, int stride)
        {
            ImPlotNative.ImPlot_PlotErrorBars_doublePtrdoublePtrdoublePtrdoublePtr(Encoding.UTF8.GetBytes(labelId), ref xs, ref ys, neg, pos, count, flags, offset, stride);
        }

        /// <summary>
        ///     Plots the error bars using the specified label id
        /// </summary>
        /// <param name="labelId">The label identifier for the plot item</param>
        /// <param name="xs">The array of x-coordinate values</param>
        /// <param name="ys">The array of y-coordinate values</param>
        /// <param name="neg">The negative direction value</param>
        /// <param name="pos">The position in screen coordinates</param>
        /// <param name="count">The number of elements</param>
        public static void PlotErrorBars(string labelId, ref sbyte xs, ref sbyte ys, ref sbyte neg, ref sbyte pos, int count)
        {
            ImPlotNative.ImPlot_PlotErrorBars_S8PtrS8PtrS8PtrS8Ptr(Encoding.UTF8.GetBytes(labelId), ref xs, ref ys, neg, pos, count, 0, 0, sizeof(sbyte));
        }
    }
}