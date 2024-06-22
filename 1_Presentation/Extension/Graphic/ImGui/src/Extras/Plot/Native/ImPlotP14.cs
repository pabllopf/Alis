// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImPlotP14.cs
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
        public static void PlotStems(string labelId, ref byte values, int count, double @ref, double scale, double start, ImPlotStemsFlags flags, int offset)
        {
            ImPlotNative.ImPlot_PlotStems_U8PtrInt(Encoding.UTF8.GetBytes(labelId), ref values, count, @ref, scale, start, flags, offset, 0);
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
        public static void PlotStems(string labelId, ref byte values, int count, double @ref, double scale, double start, ImPlotStemsFlags flags, int offset, int stride)
        {
            ImPlotNative.ImPlot_PlotStems_U8PtrInt(Encoding.UTF8.GetBytes(labelId), ref values, count, @ref, scale, start, flags, offset, stride);
        }
        
        /// <summary>
        ///     Plots the stems using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        public static void PlotStems(string labelId, ref short values, int count)
        {
            ImPlotNative.ImPlot_PlotStems_S16PtrInt(Encoding.UTF8.GetBytes(labelId), ref values, count, 0, 1, 0, 0, 0, 0);
        }
        
        /// <summary>
        ///     Plots the stems using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="ref">The ref</param>
        public static void PlotStems(string labelId, ref short values, int count, double @ref)
        {
            ImPlotNative.ImPlot_PlotStems_S16PtrInt(Encoding.UTF8.GetBytes(labelId), ref values, count, @ref, 1, 0, 0, 0, 0);
        }
        
        /// <summary>
        ///     Plots the stems using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="ref">The ref</param>
        /// <param name="scale">The scale</param>
        public static void PlotStems(string labelId, ref short values, int count, double @ref, double scale)
        {
            ImPlotNative.ImPlot_PlotStems_S16PtrInt(Encoding.UTF8.GetBytes(labelId), ref values, count, @ref, scale, 0, 0, 0, 0);
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
        public static void PlotStems(string labelId, ref short values, int count, double @ref, double scale, double start)
        {
            ImPlotNative.ImPlot_PlotStems_S16PtrInt(Encoding.UTF8.GetBytes(labelId), ref values, count, @ref, scale, start, 0, 0, 0);
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
        public static void PlotStems(string labelId, ref short values, int count, double @ref, double scale, double start, ImPlotStemsFlags flags)
        {
            ImPlotNative.ImPlot_PlotStems_S16PtrInt(Encoding.UTF8.GetBytes(labelId), ref values, count, @ref, scale, start, flags, 0, 0);
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
        public static void PlotStems(string labelId, ref short values, int count, double @ref, double scale, double start, ImPlotStemsFlags flags, int offset)
        {
            ImPlotNative.ImPlot_PlotStems_S16PtrInt(Encoding.UTF8.GetBytes(labelId), ref values, count, @ref, scale, start, flags, offset, 0);
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
        public static void PlotStems(string labelId, ref short values, int count, double @ref, double scale, double start, ImPlotStemsFlags flags, int offset, int stride)
        {
            ImPlotNative.ImPlot_PlotStems_S16PtrInt(Encoding.UTF8.GetBytes(labelId), ref values, count, @ref, scale, start, flags, offset, stride);
        }
        
        /// <summary>
        ///     Plots the stems using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        public static void PlotStems(string labelId, ref ushort values, int count)
        {
            ImPlotNative.ImPlot_PlotStems_U16PtrInt(Encoding.UTF8.GetBytes(labelId), ref values, count, 0, 1, 0, 0, 0, 0);
        }
        
        /// <summary>
        ///     Plots the stems using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="ref">The ref</param>
        public static void PlotStems(string labelId, ref ushort values, int count, double @ref)
        {
            ImPlotNative.ImPlot_PlotStems_U16PtrInt(Encoding.UTF8.GetBytes(labelId), ref values, count, @ref, 1, 0, 0, 0, 0);
        }
        
        /// <summary>
        ///     Plots the stems using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="ref">The ref</param>
        /// <param name="scale">The scale</param>
        public static void PlotStems(string labelId, ref ushort values, int count, double @ref, double scale)
        {
            ImPlotNative.ImPlot_PlotStems_U16PtrInt(Encoding.UTF8.GetBytes(labelId), ref values, count, @ref, scale, 0, 0, 0, 0);
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
        public static void PlotStems(string labelId, ref ushort values, int count, double @ref, double scale, double start)
        {
            ImPlotNative.ImPlot_PlotStems_U16PtrInt(Encoding.UTF8.GetBytes(labelId), ref values, count, @ref, scale, start, 0, 0, 0);
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
        public static void PlotStems(string labelId, ref ushort values, int count, double @ref, double scale, double start, ImPlotStemsFlags flags)
        {
            ImPlotNative.ImPlot_PlotStems_U16PtrInt(Encoding.UTF8.GetBytes(labelId), ref values, count, @ref, scale, start, flags, 0, 0);
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
        public static void PlotStems(string labelId, ref ushort values, int count, double @ref, double scale, double start, ImPlotStemsFlags flags, int offset)
        {
            ImPlotNative.ImPlot_PlotStems_U16PtrInt(Encoding.UTF8.GetBytes(labelId), ref values, count, @ref, scale, start, flags, offset, 0);
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
        public static void PlotStems(string labelId, ref ushort values, int count, double @ref, double scale, double start, ImPlotStemsFlags flags, int offset, int stride)
        {
            ImPlotNative.ImPlot_PlotStems_U16PtrInt(Encoding.UTF8.GetBytes(labelId), ref values, count, @ref, scale, start, flags, offset, stride);
        }
        
        /// <summary>
        ///     Plots the stems using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        public static void PlotStems(string labelId, ref int values, int count)
        {
            ImPlotNative.ImPlot_PlotStems_S32PtrInt(Encoding.UTF8.GetBytes(labelId), ref values, count, 0, 1, 0, 0, 0, 0);
        }
        
        /// <summary>
        ///     Plots the stems using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="ref">The ref</param>
        public static void PlotStems(string labelId, ref int values, int count, double @ref)
        {
            ImPlotNative.ImPlot_PlotStems_S32PtrInt(Encoding.UTF8.GetBytes(labelId), ref values, count, @ref, 1, 0, 0, 0, 0);
        }
        
        /// <summary>
        ///     Plots the stems using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="ref">The ref</param>
        /// <param name="scale">The scale</param>
        public static void PlotStems(string labelId, ref int values, int count, double @ref, double scale)
        {
            ImPlotNative.ImPlot_PlotStems_S32PtrInt(Encoding.UTF8.GetBytes(labelId), ref values, count, @ref, scale, 0, 0, 0, 0);
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
        public static void PlotStems(string labelId, ref int values, int count, double @ref, double scale, double start)
        {
            ImPlotNative.ImPlot_PlotStems_S32PtrInt(Encoding.UTF8.GetBytes(labelId), ref values, count, @ref, scale, start, 0, 0, 0);
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
        public static void PlotStems(string labelId, ref int values, int count, double @ref, double scale, double start, ImPlotStemsFlags flags)
        {
            ImPlotNative.ImPlot_PlotStems_S32PtrInt(Encoding.UTF8.GetBytes(labelId), ref values, count, @ref, scale, start, flags, 0, 0);
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
        public static void PlotStems(string labelId, ref int values, int count, double @ref, double scale, double start, ImPlotStemsFlags flags, int offset)
        {
            ImPlotNative.ImPlot_PlotStems_S32PtrInt(Encoding.UTF8.GetBytes(labelId), ref values, count, @ref, scale, start, flags, offset, 0);
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
        public static void PlotStems(string labelId, ref int values, int count, double @ref, double scale, double start, ImPlotStemsFlags flags, int offset, int stride)
        {
            ImPlotNative.ImPlot_PlotStems_S32PtrInt(Encoding.UTF8.GetBytes(labelId), ref values, count, @ref, scale, start, flags, offset, stride);
        }
        
        /// <summary>
        ///     Plots the stems using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        public static void PlotStems(string labelId, ref uint values, int count)
        {
            ImPlotNative.ImPlot_PlotStems_U32PtrInt(Encoding.UTF8.GetBytes(labelId), ref values, count, 0, 1, 0, 0, 0, 0);
        }
        
        /// <summary>
        ///     Plots the stems using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="ref">The ref</param>
        public static void PlotStems(string labelId, ref uint values, int count, double @ref)
        {
            ImPlotNative.ImPlot_PlotStems_U32PtrInt(Encoding.UTF8.GetBytes(labelId), ref values, count, @ref, 1, 0, 0, 0, 0);
        }
        
        /// <summary>
        ///     Plots the stems using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="ref">The ref</param>
        /// <param name="scale">The scale</param>
        public static void PlotStems(string labelId, ref uint values, int count, double @ref, double scale)
        {
            ImPlotNative.ImPlot_PlotStems_U32PtrInt(Encoding.UTF8.GetBytes(labelId), ref values, count, @ref, scale, 0, 0, 0, 0);
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
        public static void PlotStems(string labelId, ref uint values, int count, double @ref, double scale, double start)
        {
            ImPlotNative.ImPlot_PlotStems_U32PtrInt(Encoding.UTF8.GetBytes(labelId), ref values, count, @ref, scale, start, 0, 0, 0);
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
        public static void PlotStems(string labelId, ref uint values, int count, double @ref, double scale, double start, ImPlotStemsFlags flags)
        {
            ImPlotNative.ImPlot_PlotStems_U32PtrInt(Encoding.UTF8.GetBytes(labelId), ref values, count, @ref, scale, start, flags, 0, 0);
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
        public static void PlotStems(string labelId, ref uint values, int count, double @ref, double scale, double start, ImPlotStemsFlags flags, int offset)
        {
            ImPlotNative.ImPlot_PlotStems_U32PtrInt(Encoding.UTF8.GetBytes(labelId), ref values, count, @ref, scale, start, flags, offset, 0);
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
        public static void PlotStems(string labelId, ref uint values, int count, double @ref, double scale, double start, ImPlotStemsFlags flags, int offset, int stride)
        {
            ImPlotNative.ImPlot_PlotStems_U32PtrInt(Encoding.UTF8.GetBytes(labelId), ref values, count, @ref, scale, start, flags, offset, stride);
        }
        
        /// <summary>
        ///     Plots the stems using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        public static void PlotStems(string labelId, ref long values, int count)
        {
            ImPlotNative.ImPlot_PlotStems_S64PtrInt(Encoding.UTF8.GetBytes(labelId), ref values, count, 0, 1, 0, 0, 0, 0);
        }
        
        /// <summary>
        ///     Plots the stems using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="ref">The ref</param>
        public static void PlotStems(string labelId, ref long values, int count, double @ref)
        {
            ImPlotNative.ImPlot_PlotStems_S64PtrInt(Encoding.UTF8.GetBytes(labelId), ref values, count, @ref, 1, 0, 0, 0, 0);
        }
        
        /// <summary>
        ///     Plots the stems using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="ref">The ref</param>
        /// <param name="scale">The scale</param>
        public static void PlotStems(string labelId, ref long values, int count, double @ref, double scale)
        {
            ImPlotNative.ImPlot_PlotStems_S64PtrInt(Encoding.UTF8.GetBytes(labelId), ref values, count, @ref, scale, 0, 0, 0, 0);
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
        public static void PlotStems(string labelId, ref long values, int count, double @ref, double scale, double start)
        {
            ImPlotNative.ImPlot_PlotStems_S64PtrInt(Encoding.UTF8.GetBytes(labelId), ref values, count, @ref, scale, start, 0, 0, 0);
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
        public static void PlotStems(string labelId, ref long values, int count, double @ref, double scale, double start, ImPlotStemsFlags flags)
        {
            ImPlotNative.ImPlot_PlotStems_S64PtrInt(Encoding.UTF8.GetBytes(labelId), ref values, count, @ref, scale, start, flags, 0, 0);
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
        public static void PlotStems(string labelId, ref long values, int count, double @ref, double scale, double start, ImPlotStemsFlags flags, int offset)
        {
            ImPlotNative.ImPlot_PlotStems_S64PtrInt(Encoding.UTF8.GetBytes(labelId), ref values, count, @ref, scale, start, flags, offset, 0);
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
        public static void PlotStems(string labelId, ref long values, int count, double @ref, double scale, double start, ImPlotStemsFlags flags, int offset, int stride)
        {
            ImPlotNative.ImPlot_PlotStems_S64PtrInt(Encoding.UTF8.GetBytes(labelId), ref values, count, @ref, scale, start, flags, offset, stride);
        }
        
        /// <summary>
        ///     Plots the stems using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        public static void PlotStems(string labelId, ref ulong values, int count)
        {
            ImPlotNative.ImPlot_PlotStems_U64PtrInt(Encoding.UTF8.GetBytes(labelId), ref values, count, 0, 1, 0, 0, 0, 0);
        }
        
        /// <summary>
        ///     Plots the stems using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="ref">The ref</param>
        public static void PlotStems(string labelId, ref ulong values, int count, double @ref)
        {
            ImPlotNative.ImPlot_PlotStems_U64PtrInt(Encoding.UTF8.GetBytes(labelId), ref values, count, @ref, 1, 0, 0, 0, 0);
        }
        
        /// <summary>
        ///     Plots the stems using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="ref">The ref</param>
        /// <param name="scale">The scale</param>
        public static void PlotStems(string labelId, ref ulong values, int count, double @ref, double scale)
        {
            ImPlotNative.ImPlot_PlotStems_U64PtrInt(Encoding.UTF8.GetBytes(labelId), ref values, count, @ref, scale, 0, 0, 0, 0);
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
        public static void PlotStems(string labelId, ref ulong values, int count, double @ref, double scale, double start)
        {
            ImPlotNative.ImPlot_PlotStems_U64PtrInt(Encoding.UTF8.GetBytes(labelId), ref values, count, @ref, scale, start, 0, 0, 0);
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
        public static void PlotStems(string labelId, ref ulong values, int count, double @ref, double scale, double start, ImPlotStemsFlags flags)
        {
            ImPlotNative.ImPlot_PlotStems_U64PtrInt(Encoding.UTF8.GetBytes(labelId), ref values, count, @ref, scale, start, flags, 0, 0);
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
        public static void PlotStems(string labelId, ref ulong values, int count, double @ref, double scale, double start, ImPlotStemsFlags flags, int offset)
        {
            ImPlotNative.ImPlot_PlotStems_U64PtrInt(Encoding.UTF8.GetBytes(labelId), ref values, count, @ref, scale, start, flags, offset, 0);
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
        public static void PlotStems(string labelId, ref ulong values, int count, double @ref, double scale, double start, ImPlotStemsFlags flags, int offset, int stride)
        {
            ImPlotNative.ImPlot_PlotStems_U64PtrInt(Encoding.UTF8.GetBytes(labelId), ref values, count, @ref, scale, start, flags, offset, stride);
        }
        
        /// <summary>
        ///     Plots the stems using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="count">The count</param>
        /// <param name="ref">The ref</param>
        public static void PlotStems(string labelId, ref float xs, ref float ys, int count, double @ref)
        {
            ImPlotNative.ImPlot_PlotStems_FloatPtrFloatPtr(Encoding.UTF8.GetBytes(labelId), ref xs, ref ys, count, @ref, 0, 0, 0);
        }
        
        /// <summary>
        ///     Plots the stems using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="count">The count</param>
        /// <param name="ref">The ref</param>
        /// <param name="flags">The flags</param>
        public static void PlotStems(string labelId, ref float xs, ref float ys, int count, double @ref, ImPlotStemsFlags flags)
        {
            ImPlotNative.ImPlot_PlotStems_FloatPtrFloatPtr(Encoding.UTF8.GetBytes(labelId), ref xs, ref ys, count, @ref, flags, 0, 0);
        }
        
        /// <summary>
        ///     Plots the stems using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="count">The count</param>
        /// <param name="ref">The ref</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        public static void PlotStems(string labelId, ref float xs, ref float ys, int count, double @ref, ImPlotStemsFlags flags, int offset)
        {
            ImPlotNative.ImPlot_PlotStems_FloatPtrFloatPtr(Encoding.UTF8.GetBytes(labelId), ref xs, ref ys, count, @ref, flags, offset, 0);
        }
        
        /// <summary>
        ///     Plots the stems using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="count">The count</param>
        /// <param name="ref">The ref</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        /// <param name="stride">The stride</param>
        public static void PlotStems(string labelId, ref float xs, ref float ys, int count, double @ref, ImPlotStemsFlags flags, int offset, int stride)
        {
            ImPlotNative.ImPlot_PlotStems_FloatPtrFloatPtr(Encoding.UTF8.GetBytes(labelId), ref xs, ref ys, count, @ref, flags, offset, stride);
        }
        
        /// <summary>
        ///     Plots the stems using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="count">The count</param>
        public static void PlotStems(string labelId, ref double xs, ref double ys, int count)
        {
            ImPlotNative.ImPlot_PlotStems_doublePtrdoublePtr(Encoding.UTF8.GetBytes(labelId), ref xs, ref ys, count, 0, 0, 0, 0);
        }
        
        /// <summary>
        ///     Plots the stems using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="count">The count</param>
        /// <param name="ref">The ref</param>
        public static void PlotStems(string labelId, ref double xs, ref double ys, int count, double @ref)
        {
            ImPlotNative.ImPlot_PlotStems_doublePtrdoublePtr(Encoding.UTF8.GetBytes(labelId), ref xs, ref ys, count, @ref, 0, 0, 0);
        }
        
        /// <summary>
        ///     Plots the stems using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="count">The count</param>
        /// <param name="ref">The ref</param>
        /// <param name="flags">The flags</param>
        public static void PlotStems(string labelId, ref double xs, ref double ys, int count, double @ref, ImPlotStemsFlags flags)
        {
            ImPlotNative.ImPlot_PlotStems_doublePtrdoublePtr(Encoding.UTF8.GetBytes(labelId), ref xs, ref ys, count, @ref, flags, 0, 0);
        }
        
        /// <summary>
        ///     Plots the stems using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="count">The count</param>
        /// <param name="ref">The ref</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        public static void PlotStems(string labelId, ref double xs, ref double ys, int count, double @ref, ImPlotStemsFlags flags, int offset)
        {
            ImPlotNative.ImPlot_PlotStems_doublePtrdoublePtr(Encoding.UTF8.GetBytes(labelId), ref xs, ref ys, count, @ref, flags, offset, 0);
        }
        
        /// <summary>
        ///     Plots the stems using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="count">The count</param>
        /// <param name="ref">The ref</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        /// <param name="stride">The stride</param>
        public static void PlotStems(string labelId, ref double xs, ref double ys, int count, double @ref, ImPlotStemsFlags flags, int offset, int stride)
        {
            ImPlotNative.ImPlot_PlotStems_doublePtrdoublePtr(Encoding.UTF8.GetBytes(labelId), ref xs, ref ys, count, @ref, flags, offset, stride);
        }
        
        /// <summary>
        ///     Plots the stems using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="count">The count</param>
        public static void PlotStems(string labelId, ref sbyte xs, ref sbyte ys, int count)
        {
            ImPlotNative.ImPlot_PlotStems_S8PtrS8Ptr(Encoding.UTF8.GetBytes(labelId), ref xs, ref ys, count, 0, 0, 0, 0);
        }
        
        /// <summary>
        ///     Plots the stems using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="count">The count</param>
        /// <param name="ref">The ref</param>
        public static void PlotStems(string labelId, ref sbyte xs, ref sbyte ys, int count, double @ref)
        {
            ImPlotNative.ImPlot_PlotStems_S8PtrS8Ptr(Encoding.UTF8.GetBytes(labelId), ref xs, ref ys, count, @ref, 0, 0, 0);
        }
        
        /// <summary>
        ///     Plots the stems using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="count">The count</param>
        /// <param name="ref">The ref</param>
        /// <param name="flags">The flags</param>
        public static void PlotStems(string labelId, ref sbyte xs, ref sbyte ys, int count, double @ref, ImPlotStemsFlags flags)
        {
            ImPlotNative.ImPlot_PlotStems_S8PtrS8Ptr(Encoding.UTF8.GetBytes(labelId), ref xs, ref ys, count, @ref, flags, 0, 0);
        }
        
        /// <summary>
        ///     Plots the stems using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="count">The count</param>
        /// <param name="ref">The ref</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        public static void PlotStems(string labelId, ref sbyte xs, ref sbyte ys, int count, double @ref, ImPlotStemsFlags flags, int offset)
        {
            ImPlotNative.ImPlot_PlotStems_S8PtrS8Ptr(Encoding.UTF8.GetBytes(labelId), ref xs, ref ys, count, @ref, flags, offset, 0);
        }
        
        /// <summary>
        ///     Plots the stems using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="count">The count</param>
        /// <param name="ref">The ref</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        /// <param name="stride">The stride</param>
        public static void PlotStems(string labelId, ref sbyte xs, ref sbyte ys, int count, double @ref, ImPlotStemsFlags flags, int offset, int stride)
        {
            ImPlotNative.ImPlot_PlotStems_S8PtrS8Ptr(Encoding.UTF8.GetBytes(labelId), ref xs, ref ys, count, @ref, flags, offset, stride);
        }
        
        /// <summary>
        ///     Plots the stems using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="count">The count</param>
        public static void PlotStems(string labelId, ref byte xs, ref byte ys, int count)
        {
            ImPlotNative.ImPlot_PlotStems_U8PtrU8Ptr(Encoding.UTF8.GetBytes(labelId), ref xs, ref ys, count, 0, 0, 0, 0);
        }
        
        /// <summary>
        ///     Plots the stems using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="count">The count</param>
        /// <param name="ref">The ref</param>
        public static void PlotStems(string labelId, ref byte xs, ref byte ys, int count, double @ref)
        {
            ImPlotNative.ImPlot_PlotStems_U8PtrU8Ptr(Encoding.UTF8.GetBytes(labelId), ref xs, ref ys, count, @ref, 0, 0, 0);
        }
        
        /// <summary>
        ///     Plots the stems using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="count">The count</param>
        /// <param name="ref">The ref</param>
        /// <param name="flags">The flags</param>
        public static void PlotStems(string labelId, ref byte xs, ref byte ys, int count, double @ref, ImPlotStemsFlags flags)
        {
            ImPlotNative.ImPlot_PlotStems_U8PtrU8Ptr(Encoding.UTF8.GetBytes(labelId), ref xs, ref ys, count, @ref, flags, 0, 0);
        }
        
        /// <summary>
        ///     Plots the stems using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="count">The count</param>
        /// <param name="ref">The ref</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        public static void PlotStems(string labelId, ref byte xs, ref byte ys, int count, double @ref, ImPlotStemsFlags flags, int offset)
        {
            ImPlotNative.ImPlot_PlotStems_U8PtrU8Ptr(Encoding.UTF8.GetBytes(labelId), ref xs, ref ys, count, @ref, flags, offset, 0);
        }
        
        /// <summary>
        ///     Plots the stems using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="count">The count</param>
        /// <param name="ref">The ref</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        /// <param name="stride">The stride</param>
        public static void PlotStems(string labelId, ref byte xs, ref byte ys, int count, double @ref, ImPlotStemsFlags flags, int offset, int stride)
        {
            ImPlotNative.ImPlot_PlotStems_U8PtrU8Ptr(Encoding.UTF8.GetBytes(labelId), ref xs, ref ys, count, @ref, flags, offset, stride);
        }
        
        /// <summary>
        ///     Plots the stems using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="count">The count</param>
        public static void PlotStems(string labelId, ref short xs, ref short ys, int count)
        {
            ImPlotNative.ImPlot_PlotStems_S16PtrS16Ptr(Encoding.UTF8.GetBytes(labelId), ref xs, ref ys, count, 0, 0, 0, 0);
        }
        
        /// <summary>
        ///     Plots the stems using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="count">The count</param>
        /// <param name="ref">The ref</param>
        public static void PlotStems(string labelId, ref short xs, ref short ys, int count, double @ref)
        {
            ImPlotNative.ImPlot_PlotStems_S16PtrS16Ptr(Encoding.UTF8.GetBytes(labelId), ref xs, ref ys, count, @ref, 0, 0, 0);
        }
        
        /// <summary>
        ///     Plots the stems using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="count">The count</param>
        /// <param name="ref">The ref</param>
        /// <param name="flags">The flags</param>
        public static void PlotStems(string labelId, ref short xs, ref short ys, int count, double @ref, ImPlotStemsFlags flags)
        {
            ImPlotNative.ImPlot_PlotStems_S16PtrS16Ptr(Encoding.UTF8.GetBytes(labelId), ref xs, ref ys, count, @ref, flags, 0, 0);
        }
        
        /// <summary>
        ///     Plots the stems using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="count">The count</param>
        /// <param name="ref">The ref</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        public static void PlotStems(string labelId, ref short xs, ref short ys, int count, double @ref, ImPlotStemsFlags flags, int offset)
        {
            ImPlotNative.ImPlot_PlotStems_S16PtrS16Ptr(Encoding.UTF8.GetBytes(labelId), ref xs, ref ys, count, @ref, flags, offset, 0);
        }
        
        /// <summary>
        ///     Plots the stems using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="count">The count</param>
        /// <param name="ref">The ref</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        /// <param name="stride">The stride</param>
        public static void PlotStems(string labelId, ref short xs, ref short ys, int count, double @ref, ImPlotStemsFlags flags, int offset, int stride)
        {
            ImPlotNative.ImPlot_PlotStems_S16PtrS16Ptr(Encoding.UTF8.GetBytes(labelId), ref xs, ref ys, count, @ref, flags, offset, stride);
        }
        
        /// <summary>
        ///     Plots the stems using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="count">The count</param>
        public static void PlotStems(string labelId, ref ushort xs, ref ushort ys, int count)
        {
            ImPlotNative.ImPlot_PlotStems_U16PtrU16Ptr(Encoding.UTF8.GetBytes(labelId), ref xs, ref ys, count, 0, 0, 0, 0);
        }
        
        /// <summary>
        ///     Plots the stems using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="count">The count</param>
        /// <param name="ref">The ref</param>
        public static void PlotStems(string labelId, ref ushort xs, ref ushort ys, int count, double @ref)
        {
            ImPlotNative.ImPlot_PlotStems_U16PtrU16Ptr(Encoding.UTF8.GetBytes(labelId), ref xs, ref ys, count, @ref, 0, 0, 0);
        }
    }
}