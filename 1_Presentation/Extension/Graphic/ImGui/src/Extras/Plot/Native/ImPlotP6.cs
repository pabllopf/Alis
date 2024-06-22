// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImPlotP6.cs
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

using System.ComponentModel.Design.Serialization;
using System.Drawing;
using System.Text;

namespace Alis.Extension.Graphic.ImGui.Extras.Plot.Native
{
    /// <summary>
    /// The im plot class
    /// </summary>
    public static partial class ImPlot
    {
       
        /// <summary>
        ///     Plots the inf lines using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        /// <param name="stride">The stride</param>
        public static void PlotInfLines(string labelId, ref byte values, int count, ImPlotInfLinesFlags flags, int offset, int stride)
        {
            ImPlotNative.ImPlot_PlotInfLines_U8Ptr(Encoding.UTF8.GetBytes(labelId), ref values, count, flags, offset, stride);
        }
        
        /// <summary>
        ///     Plots the inf lines using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        public static void PlotInfLines(string labelId, ref short values, int count)
        {
            ImPlotNative.ImPlot_PlotInfLines_S16Ptr(Encoding.UTF8.GetBytes(labelId), ref values, count, ImPlotInfLinesFlags.None, 0, sizeof(short));
        }
        
        /// <summary>
        ///     Plots the inf lines using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="flags">The flags</param>
        public static void PlotInfLines(string labelId, ref short values, int count, ImPlotInfLinesFlags flags)
        {
            ImPlotNative.ImPlot_PlotInfLines_S16Ptr(Encoding.UTF8.GetBytes(labelId), ref values, count, flags, 0, sizeof(short));
        }
        
        /// <summary>
        ///     Plots the inf lines using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        public static void PlotInfLines(string labelId, ref short values, int count, ImPlotInfLinesFlags flags, int offset)
        {
            ImPlotNative.ImPlot_PlotInfLines_S16Ptr(Encoding.UTF8.GetBytes(labelId), ref values, count, flags, offset, sizeof(short));
        }
        
        /// <summary>
        ///     Plots the inf lines using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        /// <param name="stride">The stride</param>
        public static void PlotInfLines(string labelId, ref short values, int count, ImPlotInfLinesFlags flags, int offset, int stride)
        {
            ImPlotNative.ImPlot_PlotInfLines_S16Ptr(Encoding.UTF8.GetBytes(labelId), ref values, count, flags, offset, stride);
        }
        
        /// <summary>
        ///     Plots the inf lines using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        public static void PlotInfLines(string labelId, ref ushort values, int count)
        {
            ImPlotNative.ImPlot_PlotInfLines_U16Ptr(Encoding.UTF8.GetBytes(labelId), ref values, count, ImPlotInfLinesFlags.None, 0, sizeof(ushort));
        }
        
        /// <summary>
        ///     Plots the inf lines using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="flags">The flags</param>
        public static void PlotInfLines(string labelId, ref ushort values, int count, ImPlotInfLinesFlags flags)
        {
            ImPlotNative.ImPlot_PlotInfLines_U16Ptr(Encoding.UTF8.GetBytes(labelId), ref values, count, flags, 0, sizeof(ushort));
        }
        
        /// <summary>
        ///     Plots the inf lines using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        public static void PlotInfLines(string labelId, ref ushort values, int count, ImPlotInfLinesFlags flags, int offset)
        {
            ImPlotNative.ImPlot_PlotInfLines_U16Ptr(Encoding.UTF8.GetBytes(labelId), ref values, count, flags, offset, sizeof(ushort));
        }
        
        /// <summary>
        ///     Plots the inf lines using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        /// <param name="stride">The stride</param>
        public static void PlotInfLines(string labelId, ref ushort values, int count, ImPlotInfLinesFlags flags, int offset, int stride)
        {
            ImPlotNative.ImPlot_PlotInfLines_U16Ptr(Encoding.UTF8.GetBytes(labelId), ref values, count, flags, offset, stride);
        }
        
        /// <summary>
        ///     Plots the inf lines using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        public static void PlotInfLines(string labelId, ref int values, int count)
        {
            ImPlotNative.ImPlot_PlotInfLines_S32Ptr(Encoding.UTF8.GetBytes(labelId), ref values, count, ImPlotInfLinesFlags.None, 0, sizeof(int));
        }
        
        /// <summary>
        ///     Plots the inf lines using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="flags">The flags</param>
        public static void PlotInfLines(string labelId, ref int values, int count, ImPlotInfLinesFlags flags)
        {
            ImPlotNative.ImPlot_PlotInfLines_S32Ptr(Encoding.UTF8.GetBytes(labelId), ref values, count, flags, 0, sizeof(int));
        }
        
        /// <summary>
        ///     Plots the inf lines using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        public static void PlotInfLines(string labelId, ref int values, int count, ImPlotInfLinesFlags flags, int offset)
        {
            ImPlotNative.ImPlot_PlotInfLines_S32Ptr(Encoding.UTF8.GetBytes(labelId), ref values, count, flags, offset, sizeof(int));
        }
        
        /// <summary>
        ///     Plots the inf lines using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        /// <param name="stride">The stride</param>
        public static void PlotInfLines(string labelId, ref int values, int count, ImPlotInfLinesFlags flags, int offset, int stride)
        {
            ImPlotNative.ImPlot_PlotInfLines_S32Ptr(Encoding.UTF8.GetBytes(labelId), ref values, count, flags, offset, stride);
        }
        
        /// <summary>
        ///     Plots the inf lines using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        public static void PlotInfLines(string labelId, ref uint values, int count)
        {
            ImPlotNative.ImPlot_PlotInfLines_U32Ptr(Encoding.UTF8.GetBytes(labelId), ref values, count, ImPlotInfLinesFlags.None, 0, sizeof(uint));
        }
        
        /// <summary>
        ///     Plots the inf lines using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="flags">The flags</param>
        public static void PlotInfLines(string labelId, ref uint values, int count, ImPlotInfLinesFlags flags)
        {
            ImPlotNative.ImPlot_PlotInfLines_U32Ptr(Encoding.UTF8.GetBytes(labelId), ref values, count, flags, 0, sizeof(uint));
        }
        
        /// <summary>
        ///     Plots the inf lines using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        public static void PlotInfLines(string labelId, ref uint values, int count, ImPlotInfLinesFlags flags, int offset)
        {
            ImPlotNative.ImPlot_PlotInfLines_U32Ptr(Encoding.UTF8.GetBytes(labelId), ref values, count, flags, offset, sizeof(uint));
        }
        
        /// <summary>
        ///     Plots the inf lines using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        /// <param name="stride">The stride</param>
        public static void PlotInfLines(string labelId, ref uint values, int count, ImPlotInfLinesFlags flags, int offset, int stride)
        {
            ImPlotNative.ImPlot_PlotInfLines_U32Ptr(Encoding.UTF8.GetBytes(labelId), ref values, count, flags, offset, stride);
        }
        
        /// <summary>
        ///     Plots the inf lines using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        public static void PlotInfLines(string labelId, ref long values, int count)
        {
            ImPlotNative.ImPlot_PlotInfLines_S64Ptr(Encoding.UTF8.GetBytes(labelId), ref values, count, ImPlotInfLinesFlags.None, 0, sizeof(long));
        }
        
        /// <summary>
        ///     Plots the inf lines using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="flags">The flags</param>
        public static void PlotInfLines(string labelId, ref long values, int count, ImPlotInfLinesFlags flags)
        {
            ImPlotNative.ImPlot_PlotInfLines_S64Ptr(Encoding.UTF8.GetBytes(labelId), ref values, count, flags, 0, sizeof(long));
        }
        
        /// <summary>
        ///     Plots the inf lines using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        public static void PlotInfLines(string labelId, ref long values, int count, ImPlotInfLinesFlags flags, int offset)
        {
            ImPlotNative.ImPlot_PlotInfLines_S64Ptr(Encoding.UTF8.GetBytes(labelId), ref values, count, flags, offset, sizeof(long));
        }
        
        /// <summary>
        ///     Plots the inf lines using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        /// <param name="stride">The stride</param>
        public static void PlotInfLines(string labelId, ref long values, int count, ImPlotInfLinesFlags flags, int offset, int stride)
        {
            ImPlotNative.ImPlot_PlotInfLines_S64Ptr(Encoding.UTF8.GetBytes(labelId), ref values, count, flags, offset, stride);
        }
        
        /// <summary>
        ///     Plots the inf lines using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        public static void PlotInfLines(string labelId, ref ulong values, int count)
        {
            ImPlotNative.ImPlot_PlotInfLines_U64Ptr(Encoding.UTF8.GetBytes(labelId), ref values, count, ImPlotInfLinesFlags.None, 0, sizeof(ulong));
        }
        
        /// <summary>
        ///     Plots the inf lines using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="flags">The flags</param>
        public static void PlotInfLines(string labelId, ref ulong values, int count, ImPlotInfLinesFlags flags)
        {
            ImPlotNative.ImPlot_PlotInfLines_U64Ptr(Encoding.UTF8.GetBytes(labelId), ref values, count, flags, 0, sizeof(ulong));
        }
        
        /// <summary>
        ///     Plots the inf lines using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        public static void PlotInfLines(string labelId, ref ulong values, int count, ImPlotInfLinesFlags flags, int offset)
        {
            ImPlotNative.ImPlot_PlotInfLines_U64Ptr(Encoding.UTF8.GetBytes(labelId), ref values, count, flags, offset, sizeof(ulong));
        }
        
        /// <summary>
        ///     Plots the inf lines using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        /// <param name="stride">The stride</param>
        public static void PlotInfLines(string labelId, ref ulong values, int count, ImPlotInfLinesFlags flags, int offset, int stride)
        {
            ImPlotNative.ImPlot_PlotInfLines_U64Ptr(Encoding.UTF8.GetBytes(labelId), ref values, count, flags, offset, stride);
        }
        
        /// <summary>
        ///     Plots the line using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        public static void PlotLine(string labelId, float[] values, int count)
        {
            ImPlotNative.ImPlot_PlotLine_FloatPtrInt(Encoding.UTF8.GetBytes(labelId), values, count, 1, 0, 0, 0, sizeof(float));
        }
        
        /// <summary>
        ///     Plots the line using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="xscale">The xscale</param>
        public static void PlotLine(string labelId, float[] values, int count, double xscale)
        {
            ImPlotNative.ImPlot_PlotLine_FloatPtrInt(Encoding.UTF8.GetBytes(labelId), values, count, xscale, 0, 0, 0, sizeof(float));
        }
        
        /// <summary>
        ///     Plots the line using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="xscale">The xscale</param>
        /// <param name="xstart">The xstart</param>
        public static void PlotLine(string labelId, float[] values, int count, double xscale, double xstart)
        {
            ImPlotNative.ImPlot_PlotLine_FloatPtrInt(Encoding.UTF8.GetBytes(labelId), values, count, xscale, xstart, 0, 0, sizeof(float));
        }
        
        /// <summary>
        ///     Plots the line using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="xscale">The xscale</param>
        /// <param name="xstart">The xstart</param>
        /// <param name="flags">The flags</param>
        public static void PlotLine(string labelId, float[] values, int count, double xscale, double xstart, ImPlotLineFlags flags)
        {
            ImPlotNative.ImPlot_PlotLine_FloatPtrInt(Encoding.UTF8.GetBytes(labelId), values, count, xscale, xstart, flags, 0, sizeof(float));
        }
        
        /// <summary>
        ///     Plots the line using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="xscale">The xscale</param>
        /// <param name="xstart">The xstart</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        public static void PlotLine(string labelId, float[] values, int count, double xscale, double xstart, ImPlotLineFlags flags, int offset)
        {
            ImPlotNative.ImPlot_PlotLine_FloatPtrInt(Encoding.UTF8.GetBytes(labelId), values, count, xscale, xstart, flags, offset, sizeof(float));
        }
        
        /// <summary>
        ///     Plots the line using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="xscale">The xscale</param>
        /// <param name="xstart">The xstart</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        /// <param name="stride">The stride</param>
        public static void PlotLine(string labelId, float[] values, int count, double xscale, double xstart, ImPlotLineFlags flags, int offset, int stride)
        {
            ImPlotNative.ImPlot_PlotLine_FloatPtrInt(Encoding.UTF8.GetBytes(labelId), values, count, xscale, xstart, flags, offset, stride);
        }
        
        /// <summary>
        ///     Plots the line using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        public static void PlotLine(string labelId, ref double values, int count)
        {
            ImPlotNative.ImPlot_PlotLine_doublePtrInt(Encoding.UTF8.GetBytes(labelId), ref values, count, 1, 0, 0, 0, 0);
        }
        
        /// <summary>
        ///     Plots the line using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="xscale">The xscale</param>
        public static void PlotLine(string labelId, ref double values, int count, double xscale)
        {
            ImPlotNative.ImPlot_PlotLine_doublePtrInt(Encoding.UTF8.GetBytes(labelId), ref values, count, xscale, 0, 0, 0, 0);
        }
        
        /// <summary>
        ///     Plots the line using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="xscale">The xscale</param>
        /// <param name="xstart">The xstart</param>
        public static void PlotLine(string labelId, ref double values, int count, double xscale, double xstart)
        {
            ImPlotNative.ImPlot_PlotLine_doublePtrInt(Encoding.UTF8.GetBytes(labelId), ref values, count, xscale, xstart, 0, 0, 0);
        }
        
        /// <summary>
        ///     Plots the line using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="xscale">The xscale</param>
        /// <param name="xstart">The xstart</param>
        /// <param name="flags">The flags</param>
        public static void PlotLine(string labelId, ref double values, int count, double xscale, double xstart, ImPlotLineFlags flags)
        {
            ImPlotNative.ImPlot_PlotLine_doublePtrInt(Encoding.UTF8.GetBytes(labelId), ref values, count, xscale, xstart, flags, 0, 0);
        }
        
        /// <summary>
        ///     Plots the line using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="xscale">The xscale</param>
        /// <param name="xstart">The xstart</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        public static void PlotLine(string labelId, ref double values, int count, double xscale, double xstart, ImPlotLineFlags flags, int offset)
        {
            ImPlotNative.ImPlot_PlotLine_doublePtrInt(Encoding.UTF8.GetBytes(labelId), ref values, count, xscale, xstart, flags, offset, 0);
        }
        
        /// <summary>
        ///     Plots the line using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="xscale">The xscale</param>
        /// <param name="xstart">The xstart</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        /// <param name="stride">The stride</param>
        public static void PlotLine(string labelId, ref double values, int count, double xscale, double xstart, ImPlotLineFlags flags, int offset, int stride)
        {
            ImPlotNative.ImPlot_PlotLine_doublePtrInt(Encoding.UTF8.GetBytes(labelId), ref values, count, xscale, xstart, flags, offset, stride);
        }
        
        /// <summary>
        ///     Plots the line using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        public static void PlotLine(string labelId, ref sbyte values, int count)
        {
            ImPlotNative.ImPlot_PlotLine_S8PtrInt(Encoding.UTF8.GetBytes(labelId), ref values, count, 1, 0, 0, 0, 0);
        }
        
        /// <summary>
        ///     Plots the line using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="xscale">The xscale</param>
        public static void PlotLine(string labelId, ref sbyte values, int count, double xscale)
        {
            ImPlotNative.ImPlot_PlotLine_S8PtrInt(Encoding.UTF8.GetBytes(labelId), ref values, count, xscale, 0, 0, 0, 0);
        }
        
        /// <summary>
        ///     Plots the line using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="xscale">The xscale</param>
        /// <param name="xstart">The xstart</param>
        public static void PlotLine(string labelId, ref sbyte values, int count, double xscale, double xstart)
        {
            ImPlotNative.ImPlot_PlotLine_S8PtrInt(Encoding.UTF8.GetBytes(labelId), ref values, count, xscale, xstart, 0, 0, 0);
        }
        
        /// <summary>
        ///     Plots the line using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="xscale">The xscale</param>
        /// <param name="xstart">The xstart</param>
        /// <param name="flags">The flags</param>
        public static void PlotLine(string labelId, ref sbyte values, int count, double xscale, double xstart, ImPlotLineFlags flags)
        {
            ImPlotNative.ImPlot_PlotLine_S8PtrInt(Encoding.UTF8.GetBytes(labelId), ref values, count, xscale, xstart, flags, 0, 0);
        }
        
        /// <summary>
        ///     Plots the line using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="xscale">The xscale</param>
        /// <param name="xstart">The xstart</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        public static void PlotLine(string labelId, ref sbyte values, int count, double xscale, double xstart, ImPlotLineFlags flags, int offset)
        {
            ImPlotNative.ImPlot_PlotLine_S8PtrInt(Encoding.UTF8.GetBytes(labelId), ref values, count, xscale, xstart, flags, offset, 0);
        }
        
        /// <summary>
        ///     Plots the line using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="xscale">The xscale</param>
        /// <param name="xstart">The xstart</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        /// <param name="stride">The stride</param>
        public static void PlotLine(string labelId, ref sbyte values, int count, double xscale, double xstart, ImPlotLineFlags flags, int offset, int stride)
        {
            ImPlotNative.ImPlot_PlotLine_S8PtrInt(Encoding.UTF8.GetBytes(labelId), ref values, count, xscale, xstart, flags, offset, stride);
        }
        
        /// <summary>
        ///     Plots the line using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        public static void PlotLine(string labelId, ref byte values, int count)
        {
            ImPlotNative.ImPlot_PlotLine_U8PtrInt(Encoding.UTF8.GetBytes(labelId), ref values, count, 1, 0, 0, 0, 0);
        }
        
        /// <summary>
        ///     Plots the line using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="xscale">The xscale</param>
        public static void PlotLine(string labelId, ref byte values, int count, double xscale)
        {
            ImPlotNative.ImPlot_PlotLine_U8PtrInt(Encoding.UTF8.GetBytes(labelId), ref values, count, xscale, 0, 0, 0, 0);
        }
        
        /// <summary>
        ///     Plots the line using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="xscale">The xscale</param>
        /// <param name="xstart">The xstart</param>
        public static void PlotLine(string labelId, ref byte values, int count, double xscale, double xstart)
        {
            ImPlotNative.ImPlot_PlotLine_U8PtrInt(Encoding.UTF8.GetBytes(labelId), ref values, count, xscale, xstart, 0, 0, 0);
        }
        
        /// <summary>
        ///     Plots the line using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="xscale">The xscale</param>
        /// <param name="xstart">The xstart</param>
        /// <param name="flags">The flags</param>
        public static void PlotLine(string labelId, ref byte values, int count, double xscale, double xstart, ImPlotLineFlags flags)
        {
            ImPlotNative.ImPlot_PlotLine_U8PtrInt(Encoding.UTF8.GetBytes(labelId), ref values, count, xscale, xstart, flags, 0, 0);
        }
        
        /// <summary>
        ///     Plots the line using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="xscale">The xscale</param>
        /// <param name="xstart">The xstart</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        public static void PlotLine(string labelId, ref byte values, int count, double xscale, double xstart, ImPlotLineFlags flags, int offset)
        {
            ImPlotNative.ImPlot_PlotLine_U8PtrInt(Encoding.UTF8.GetBytes(labelId), ref values, count, xscale, xstart, flags, offset, 0);
        }
        
        /// <summary>
        ///     Plots the line using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="xscale">The xscale</param>
        /// <param name="xstart">The xstart</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        /// <param name="stride">The stride</param>
        public static void PlotLine(string labelId, ref byte values, int count, double xscale, double xstart, ImPlotLineFlags flags, int offset, int stride)
        {
            ImPlotNative.ImPlot_PlotLine_U8PtrInt(Encoding.UTF8.GetBytes(labelId), ref values, count, xscale, xstart, flags, offset, stride);
        }
        
        /// <summary>
        ///     Plots the line using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        public static void PlotLine(string labelId, ref short values, int count)
        {
            ImPlotNative.ImPlot_PlotLine_S16PtrInt(Encoding.UTF8.GetBytes(labelId), ref values, count, 1, 0, 0, 0, 0);
        }
        
        /// <summary>
        ///     Plots the line using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="xscale">The xscale</param>
        public static void PlotLine(string labelId, ref short values, int count, double xscale)
        {
            ImPlotNative.ImPlot_PlotLine_S16PtrInt(Encoding.UTF8.GetBytes(labelId), ref values, count, xscale, 0, 0, 0, 0);
        }
        
        /// <summary>
        ///     Plots the line using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="xscale">The xscale</param>
        /// <param name="xstart">The xstart</param>
        public static void PlotLine(string labelId, ref short values, int count, double xscale, double xstart)
        {
            ImPlotNative.ImPlot_PlotLine_S16PtrInt(Encoding.UTF8.GetBytes(labelId), ref values, count, xscale, xstart, 0, 0, 0);
        }
        
        /// <summary>
        ///     Plots the line using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="xscale">The xscale</param>
        /// <param name="xstart">The xstart</param>
        /// <param name="flags">The flags</param>
        public static void PlotLine(string labelId, ref short values, int count, double xscale, double xstart, ImPlotLineFlags flags)
        {
            ImPlotNative.ImPlot_PlotLine_S16PtrInt(Encoding.UTF8.GetBytes(labelId), ref values, count, xscale, xstart, flags, 0, 0);
        }
        
        /// <summary>
        ///     Plots the line using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="xscale">The xscale</param>
        /// <param name="xstart">The xstart</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        public static void PlotLine(string labelId, ref short values, int count, double xscale, double xstart, ImPlotLineFlags flags, int offset)
        {
            ImPlotNative.ImPlot_PlotLine_S16PtrInt(Encoding.UTF8.GetBytes(labelId), ref values, count, xscale, xstart, flags, offset, 0);
        }
    }
}