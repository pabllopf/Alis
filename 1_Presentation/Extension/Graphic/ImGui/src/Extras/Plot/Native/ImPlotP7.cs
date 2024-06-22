// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImPlotP7.cs
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
        ///     Plots the scatter using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="xscale">The xscale</param>
        /// <param name="xstart">The xstart</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        /// <param name="stride">The stride</param>
        public static void PlotScatter(string labelId, ref byte values, int count, double xscale, double xstart, ImPlotScatterFlags flags, int offset, int stride)
        {
            ImPlotNative.ImPlot_PlotScatter_U8PtrInt(Encoding.UTF8.GetBytes(labelId), ref values, count, xscale, xstart, flags, offset, stride);
        }
        
        /// <summary>
        ///     Plots the scatter using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        public static void PlotScatter(string labelId, ref short values, int count)
        {
            ImPlotNative.ImPlot_PlotScatter_S16PtrInt(Encoding.UTF8.GetBytes(labelId), ref values, count, 1, 0, 0, 0, sizeof(short));
        }
        
        /// <summary>
        ///     Plots the scatter using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="xscale">The xscale</param>
        public static void PlotScatter(string labelId, ref short values, int count, double xscale)
        {
            ImPlotNative.ImPlot_PlotScatter_S16PtrInt(Encoding.UTF8.GetBytes(labelId), ref values, count, xscale, 0, 0, 0, sizeof(short));
        }
        
        /// <summary>
        ///     Plots the scatter using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="xscale">The xscale</param>
        /// <param name="xstart">The xstart</param>
        public static void PlotScatter(string labelId, ref short values, int count, double xscale, double xstart)
        {
            ImPlotNative.ImPlot_PlotScatter_S16PtrInt(Encoding.UTF8.GetBytes(labelId), ref values, count, xscale, xstart, 0, 0, sizeof(short));
        }
        
        /// <summary>
        ///     Plots the scatter using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="xscale">The xscale</param>
        /// <param name="xstart">The xstart</param>
        /// <param name="flags">The flags</param>
        public static void PlotScatter(string labelId, ref short values, int count, double xscale, double xstart, ImPlotScatterFlags flags)
        {
            ImPlotNative.ImPlot_PlotScatter_S16PtrInt(Encoding.UTF8.GetBytes(labelId), ref values, count, xscale, xstart, flags, 0, sizeof(short));
        }
        
        /// <summary>
        ///     Plots the scatter using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="xscale">The xscale</param>
        /// <param name="xstart">The xstart</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        public static void PlotScatter(string labelId, ref short values, int count, double xscale, double xstart, ImPlotScatterFlags flags, int offset)
        {
            ImPlotNative.ImPlot_PlotScatter_S16PtrInt(Encoding.UTF8.GetBytes(labelId), ref values, count, xscale, xstart, flags, offset, sizeof(short));    
        }
        
        /// <summary>
        ///     Plots the scatter using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="xscale">The xscale</param>
        /// <param name="xstart">The xstart</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        /// <param name="stride">The stride</param>
        public static void PlotScatter(string labelId, ref short values, int count, double xscale, double xstart, ImPlotScatterFlags flags, int offset, int stride)
        {
            ImPlotNative.ImPlot_PlotScatter_S16PtrInt(Encoding.UTF8.GetBytes(labelId), ref values, count, xscale, xstart, flags, offset, stride);
        }
        
        /// <summary>
        ///     Plots the scatter using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        public static void PlotScatter(string labelId, ref ushort values, int count)
        {
            ImPlotNative.ImPlot_PlotScatter_U16PtrInt(Encoding.UTF8.GetBytes(labelId), ref values, count, 1, 0, 0, 0, sizeof(ushort));
        }
        
        /// <summary>
        ///     Plots the scatter using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="xscale">The xscale</param>
        public static void PlotScatter(string labelId, ref ushort values, int count, double xscale)
        {
            ImPlotNative.ImPlot_PlotScatter_U16PtrInt(Encoding.UTF8.GetBytes(labelId), ref values, count, xscale, 0, 0, 0, sizeof(ushort));
        }
        
        /// <summary>
        ///     Plots the scatter using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="xscale">The xscale</param>
        /// <param name="xstart">The xstart</param>
        public static void PlotScatter(string labelId, ref ushort values, int count, double xscale, double xstart)
        {
            ImPlotNative.ImPlot_PlotScatter_U16PtrInt(Encoding.UTF8.GetBytes(labelId), ref values, count, xscale, xstart, 0, 0, sizeof(ushort));
        }
        
        /// <summary>
        ///     Plots the scatter using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="xscale">The xscale</param>
        /// <param name="xstart">The xstart</param>
        /// <param name="flags">The flags</param>
        public static void PlotScatter(string labelId, ref ushort values, int count, double xscale, double xstart, ImPlotScatterFlags flags)
        {
            ImPlotNative.ImPlot_PlotScatter_U16PtrInt(Encoding.UTF8.GetBytes(labelId), ref values, count, xscale, xstart, flags, 0, sizeof(ushort));
        }
        
        /// <summary>
        ///     Plots the scatter using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="xscale">The xscale</param>
        /// <param name="xstart">The xstart</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        public static void PlotScatter(string labelId, ref ushort values, int count, double xscale, double xstart, ImPlotScatterFlags flags, int offset)
        {
            ImPlotNative.ImPlot_PlotScatter_U16PtrInt(Encoding.UTF8.GetBytes(labelId), ref values, count, xscale, xstart, flags, offset, sizeof(ushort));
        }
        
        /// <summary>
        ///     Plots the scatter using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="xscale">The xscale</param>
        /// <param name="xstart">The xstart</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        /// <param name="stride">The stride</param>
        public static void PlotScatter(string labelId, ref ushort values, int count, double xscale, double xstart, ImPlotScatterFlags flags, int offset, int stride)
        {
            ImPlotNative.ImPlot_PlotScatter_U16PtrInt(Encoding.UTF8.GetBytes(labelId), ref values, count, xscale, xstart, flags, offset, stride);
        }
        
        /// <summary>
        ///     Plots the scatter using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        public static void PlotScatter(string labelId, ref int values, int count)
        {
            ImPlotNative.ImPlot_PlotScatter_S32PtrInt(Encoding.UTF8.GetBytes(labelId), ref values, count, 1, 0, 0, 0, sizeof(int));
        }
        
        /// <summary>
        ///     Plots the scatter using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="xscale">The xscale</param>
        public static void PlotScatter(string labelId, ref int values, int count, double xscale)
        {
            ImPlotNative.ImPlot_PlotScatter_S32PtrInt(Encoding.UTF8.GetBytes(labelId), ref values, count, xscale, 0, 0, 0, sizeof(int));
        }
        
        /// <summary>
        ///     Plots the scatter using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="xscale">The xscale</param>
        /// <param name="xstart">The xstart</param>
        public static void PlotScatter(string labelId, ref int values, int count, double xscale, double xstart)
        {
            ImPlotNative.ImPlot_PlotScatter_S32PtrInt(Encoding.UTF8.GetBytes(labelId), ref values, count, xscale, xstart, 0, 0, sizeof(int));
        }
        
        /// <summary>
        ///     Plots the scatter using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="xscale">The xscale</param>
        /// <param name="xstart">The xstart</param>
        /// <param name="flags">The flags</param>
        public static void PlotScatter(string labelId, ref int values, int count, double xscale, double xstart, ImPlotScatterFlags flags)
        {
            ImPlotNative.ImPlot_PlotScatter_S32PtrInt(Encoding.UTF8.GetBytes(labelId), ref values, count, xscale, xstart, flags, 0, sizeof(int));
        }
        
        /// <summary>
        ///     Plots the scatter using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="xscale">The xscale</param>
        /// <param name="xstart">The xstart</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        public static void PlotScatter(string labelId, ref int values, int count, double xscale, double xstart, ImPlotScatterFlags flags, int offset)
        {
            ImPlotNative.ImPlot_PlotScatter_S32PtrInt(Encoding.UTF8.GetBytes(labelId), ref values, count, xscale, xstart, flags, offset, sizeof(int));
        }
        
        /// <summary>
        ///     Plots the scatter using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="xscale">The xscale</param>
        /// <param name="xstart">The xstart</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        /// <param name="stride">The stride</param>
        public static void PlotScatter(string labelId, ref int values, int count, double xscale, double xstart, ImPlotScatterFlags flags, int offset, int stride)
        {
            ImPlotNative.ImPlot_PlotScatter_S32PtrInt(Encoding.UTF8.GetBytes(labelId), ref values, count, xscale, xstart, flags, offset, stride);
        }
        
        /// <summary>
        ///     Plots the scatter using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        public static void PlotScatter(string labelId, ref uint values, int count)
        {
            ImPlotNative.ImPlot_PlotScatter_U32PtrInt(Encoding.UTF8.GetBytes(labelId), ref values, count, 1, 0, 0, 0, sizeof(uint));
        }
        
        /// <summary>
        ///     Plots the scatter using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="xscale">The xscale</param>
        public static void PlotScatter(string labelId, ref uint values, int count, double xscale)
        {
            ImPlotNative.ImPlot_PlotScatter_U32PtrInt(Encoding.UTF8.GetBytes(labelId), ref values, count, xscale, 0, 0, 0, sizeof(uint));
        }
        
        /// <summary>
        ///     Plots the scatter using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="xscale">The xscale</param>
        /// <param name="xstart">The xstart</param>
        public static void PlotScatter(string labelId, ref uint values, int count, double xscale, double xstart)
        {
            ImPlotNative.ImPlot_PlotScatter_U32PtrInt(Encoding.UTF8.GetBytes(labelId), ref values, count, xscale, xstart, 0, 0, sizeof(uint));
        }
        
        /// <summary>
        ///     Plots the scatter using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="xscale">The xscale</param>
        /// <param name="xstart">The xstart</param>
        /// <param name="flags">The flags</param>
        public static void PlotScatter(string labelId, ref uint values, int count, double xscale, double xstart, ImPlotScatterFlags flags)
        {
            ImPlotNative.ImPlot_PlotScatter_U32PtrInt(Encoding.UTF8.GetBytes(labelId), ref values, count, xscale, xstart, flags, 0, sizeof(uint));
        }
        
        /// <summary>
        ///     Plots the scatter using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="xscale">The xscale</param>
        /// <param name="xstart">The xstart</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        public static void PlotScatter(string labelId, ref uint values, int count, double xscale, double xstart, ImPlotScatterFlags flags, int offset)
        {
            ImPlotNative.ImPlot_PlotScatter_U32PtrInt(Encoding.UTF8.GetBytes(labelId), ref values, count, xscale, xstart, flags, offset, sizeof(uint));
        }
        
        /// <summary>
        ///     Plots the scatter using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="xscale">The xscale</param>
        /// <param name="xstart">The xstart</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        /// <param name="stride">The stride</param>
        public static void PlotScatter(string labelId, ref uint values, int count, double xscale, double xstart, ImPlotScatterFlags flags, int offset, int stride)
        {
            ImPlotNative.ImPlot_PlotScatter_U32PtrInt(Encoding.UTF8.GetBytes(labelId), ref values, count, xscale, xstart, flags, offset, stride);
            
        }
        
        /// <summary>
        ///     Plots the scatter using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        public static void PlotScatter(string labelId, ref long values, int count)
        {
            ImPlotNative.ImPlot_PlotScatter_S64PtrInt(Encoding.UTF8.GetBytes(labelId), ref values, count, 1, 0, 0, 0, sizeof(long));
        }
        
        /// <summary>
        ///     Plots the scatter using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="xscale">The xscale</param>
        public static void PlotScatter(string labelId, ref long values, int count, double xscale)
        {
            ImPlotNative.ImPlot_PlotScatter_S64PtrInt(Encoding.UTF8.GetBytes(labelId), ref values, count, xscale, 0, 0, 0, sizeof(long));
        }
        
        /// <summary>
        ///     Plots the scatter using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="xscale">The xscale</param>
        /// <param name="xstart">The xstart</param>
        public static void PlotScatter(string labelId, ref long values, int count, double xscale, double xstart)
        {
            ImPlotNative.ImPlot_PlotScatter_S64PtrInt(Encoding.UTF8.GetBytes(labelId), ref values, count, xscale, xstart, 0, 0, sizeof(long));
            
        }
        
        /// <summary>
        ///     Plots the scatter using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="xscale">The xscale</param>
        /// <param name="xstart">The xstart</param>
        /// <param name="flags">The flags</param>
        public static void PlotScatter(string labelId, ref long values, int count, double xscale, double xstart, ImPlotScatterFlags flags)
        {
            ImPlotNative.ImPlot_PlotScatter_S64PtrInt(Encoding.UTF8.GetBytes(labelId), ref values, count, xscale, xstart, flags, 0, sizeof(long));
        }
        
        /// <summary>
        ///     Plots the scatter using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="xscale">The xscale</param>
        /// <param name="xstart">The xstart</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        public static void PlotScatter(string labelId, ref long values, int count, double xscale, double xstart, ImPlotScatterFlags flags, int offset)
        {
            ImPlotNative.ImPlot_PlotScatter_S64PtrInt(Encoding.UTF8.GetBytes(labelId), ref values, count, xscale, xstart, flags, offset, sizeof(long));
        }
        
        /// <summary>
        ///     Plots the scatter using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="xscale">The xscale</param>
        /// <param name="xstart">The xstart</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        /// <param name="stride">The stride</param>
        public static void PlotScatter(string labelId, ref long values, int count, double xscale, double xstart, ImPlotScatterFlags flags, int offset, int stride)
        {
            ImPlotNative.ImPlot_PlotScatter_S64PtrInt(Encoding.UTF8.GetBytes(labelId), ref values, count, xscale, xstart, flags, offset, stride);
        }
        
        /// <summary>
        ///     Plots the scatter using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        public static void PlotScatter(string labelId, ref ulong values, int count)
        {
            ImPlotNative.ImPlot_PlotScatter_U64PtrInt(Encoding.UTF8.GetBytes(labelId), ref values, count, 1, 0, 0, 0, sizeof(ulong));
        }
        
        /// <summary>
        ///     Plots the scatter using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="xscale">The xscale</param>
        public static void PlotScatter(string labelId, ref ulong values, int count, double xscale)
        {
            ImPlotNative.ImPlot_PlotScatter_U64PtrInt(Encoding.UTF8.GetBytes(labelId), ref values, count, xscale, 0, 0, 0, sizeof(ulong));
        }
        
        /// <summary>
        ///     Plots the scatter using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="xscale">The xscale</param>
        /// <param name="xstart">The xstart</param>
        public static void PlotScatter(string labelId, ref ulong values, int count, double xscale, double xstart)
        {
            ImPlotNative.ImPlot_PlotScatter_U64PtrInt(Encoding.UTF8.GetBytes(labelId), ref values, count, xscale, xstart, 0, 0, sizeof(ulong));
        }
        
        /// <summary>
        ///     Plots the scatter using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="xscale">The xscale</param>
        /// <param name="xstart">The xstart</param>
        /// <param name="flags">The flags</param>
        public static void PlotScatter(string labelId, ref ulong values, int count, double xscale, double xstart, ImPlotScatterFlags flags)
        {
            ImPlotNative.ImPlot_PlotScatter_U64PtrInt(Encoding.UTF8.GetBytes(labelId), ref values, count, xscale, xstart, flags, 0, sizeof(ulong));
        }
        
        /// <summary>
        ///     Plots the scatter using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="xscale">The xscale</param>
        /// <param name="xstart">The xstart</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        public static void PlotScatter(string labelId, ref ulong values, int count, double xscale, double xstart, ImPlotScatterFlags flags, int offset)
        {
            ImPlotNative.ImPlot_PlotScatter_U64PtrInt(Encoding.UTF8.GetBytes(labelId), ref values, count, xscale, xstart, flags, offset, sizeof(ulong));
        }
        
        /// <summary>
        ///     Plots the scatter using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="xscale">The xscale</param>
        /// <param name="xstart">The xstart</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        /// <param name="stride">The stride</param>
        public static void PlotScatter(string labelId, ref ulong values, int count, double xscale, double xstart, ImPlotScatterFlags flags, int offset, int stride)
        {
            ImPlotNative.ImPlot_PlotScatter_U64PtrInt(Encoding.UTF8.GetBytes(labelId), ref values, count, xscale, xstart, flags, offset, stride);
        }
        
        /// <summary>
        ///     Plots the scatter using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="count">The count</param>
        public static void PlotScatter(string labelId, ref float xs, ref float ys, int count)
        {
            ImPlotNative.ImPlot_PlotScatter_FloatPtrFloatPtr(Encoding.UTF8.GetBytes(labelId), ref xs, ref ys, count, 0, 0, sizeof(float));
        }
        
        /// <summary>
        ///     Plots the scatter using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="count">The count</param>
        /// <param name="flags">The flags</param>
        public static void PlotScatter(string labelId, ref float xs, ref float ys, int count, ImPlotScatterFlags flags)
        {
            ImPlotNative.ImPlot_PlotScatter_FloatPtrFloatPtr(Encoding.UTF8.GetBytes(labelId), ref xs, ref ys, count, flags, 0, sizeof(float));
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
        public static void PlotScatter(string labelId, ref float xs, ref float ys, int count, ImPlotScatterFlags flags, int offset)
        {
            ImPlotNative.ImPlot_PlotScatter_FloatPtrFloatPtr(Encoding.UTF8.GetBytes(labelId), ref xs, ref ys, count, flags, offset, sizeof(float));
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
        public static void PlotScatter(string labelId, ref float xs, ref float ys, int count, ImPlotScatterFlags flags, int offset, int stride)
        {
            ImPlotNative.ImPlot_PlotScatter_FloatPtrFloatPtr(Encoding.UTF8.GetBytes(labelId), ref xs, ref ys, count, flags, offset, stride);
        }
        
        /// <summary>
        ///     Plots the scatter using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="count">The count</param>
        public static void PlotScatter(string labelId, ref double xs, ref double ys, int count)
        {
            ImPlotNative.ImPlot_PlotScatter_doublePtrdoublePtr(Encoding.UTF8.GetBytes(labelId), ref xs, ref ys, count, 0, 0, sizeof(double));
        }
        
        /// <summary>
        ///     Plots the scatter using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="count">The count</param>
        /// <param name="flags">The flags</param>
        public static void PlotScatter(string labelId, ref double xs, ref double ys, int count, ImPlotScatterFlags flags)
        {
            ImPlotNative.ImPlot_PlotScatter_doublePtrdoublePtr(Encoding.UTF8.GetBytes(labelId), ref xs, ref ys, count, flags, 0, sizeof(double));
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
        public static void PlotScatter(string labelId, ref double xs, ref double ys, int count, ImPlotScatterFlags flags, int offset)
        {
            ImPlotNative.ImPlot_PlotScatter_doublePtrdoublePtr(Encoding.UTF8.GetBytes(labelId), ref xs, ref ys, count, flags, offset, sizeof(double));
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
        public static void PlotScatter(string labelId, ref double xs, ref double ys, int count, ImPlotScatterFlags flags, int offset, int stride)
        {
            ImPlotNative.ImPlot_PlotScatter_doublePtrdoublePtr(Encoding.UTF8.GetBytes(labelId), ref xs, ref ys, count, flags, offset, stride);
        }
        
        /// <summary>
        ///     Plots the scatter using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="count">The count</param>
        public static void PlotScatter(string labelId, ref sbyte xs, ref sbyte ys, int count)
        {
            ImPlotNative.ImPlot_PlotScatter_S8PtrS8Ptr(Encoding.UTF8.GetBytes(labelId), ref xs, ref ys, count, 0, 0, sizeof(sbyte));
        }
        
        /// <summary>
        ///     Plots the scatter using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="count">The count</param>
        /// <param name="flags">The flags</param>
        public static void PlotScatter(string labelId, ref sbyte xs, ref sbyte ys, int count, ImPlotScatterFlags flags)
        {
            ImPlotNative.ImPlot_PlotScatter_S8PtrS8Ptr(Encoding.UTF8.GetBytes(labelId), ref xs, ref ys, count, flags, 0, sizeof(sbyte));
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
        public static void PlotScatter(string labelId, ref sbyte xs, ref sbyte ys, int count, ImPlotScatterFlags flags, int offset)
        {
            ImPlotNative.ImPlot_PlotScatter_S8PtrS8Ptr(Encoding.UTF8.GetBytes(labelId), ref xs, ref ys, count, flags, offset, sizeof(sbyte));
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
        public static void PlotScatter(string labelId, ref sbyte xs, ref sbyte ys, int count, ImPlotScatterFlags flags, int offset, int stride)
        {
            ImPlotNative.ImPlot_PlotScatter_S8PtrS8Ptr(Encoding.UTF8.GetBytes(labelId), ref xs, ref ys, count, flags, offset, stride);
        }
        
        
        /// <summary>
        ///     Plots the scatter using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="count">The count</param>
        public static void PlotScatter(string labelId, ref byte xs, ref byte ys, int count)
        {
            ImPlotNative.ImPlot_PlotScatter_U8PtrU8Ptr(Encoding.UTF8.GetBytes(labelId), ref xs, ref ys, count, 0, 0, sizeof(byte));
        }
        
        /// <summary>
        ///     Plots the scatter using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="count">The count</param>
        /// <param name="flags">The flags</param>
        public static void PlotScatter(string labelId, ref byte xs, ref byte ys, int count, ImPlotScatterFlags flags)
        {
            ImPlotNative.ImPlot_PlotScatter_U8PtrU8Ptr(Encoding.UTF8.GetBytes(labelId), ref xs, ref ys, count, flags, 0, sizeof(byte));
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
        public static void PlotScatter(string labelId, ref byte xs, ref byte ys, int count, ImPlotScatterFlags flags, int offset)
        {
            ImPlotNative.ImPlot_PlotScatter_U8PtrU8Ptr(Encoding.UTF8.GetBytes(labelId), ref xs, ref ys, count, flags, offset, sizeof(byte));
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
        public static void PlotScatter(string labelId, ref byte xs, ref byte ys, int count, ImPlotScatterFlags flags, int offset, int stride)
        {
            ImPlotNative.ImPlot_PlotScatter_U8PtrU8Ptr(Encoding.UTF8.GetBytes(labelId), ref xs, ref ys, count, flags, offset, stride);
        }
        
        /// <summary>
        ///     Plots the scatter using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="count">The count</param>
        public static void PlotScatter(string labelId, ref short xs, ref short ys, int count)
        {
            ImPlotNative.ImPlot_PlotScatter_S16PtrS16Ptr(Encoding.UTF8.GetBytes(labelId), ref xs, ref ys, count, 0, 0, sizeof(short));
        }
    }
}