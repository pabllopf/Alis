// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImPlotP21.cs
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
        ///     Plots the shaded using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="count">The count</param>
        public static void PlotShaded(string labelId, ref sbyte xs, ref sbyte ys, int count)
        {
           ImPlotNative.ImPlot_PlotShaded_S8PtrS8PtrInt(Encoding.UTF8.GetBytes(labelId), ref xs, ref ys, count, 0, 0, 0, sizeof(sbyte));
        }
        
        /// <summary>
        ///     Plots the shaded using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="count">The count</param>
        /// <param name="yref">The yref</param>
        public static void PlotShaded(string labelId, ref sbyte xs, ref sbyte ys, int count, double yref)
        {
              ImPlotNative.ImPlot_PlotShaded_S8PtrS8PtrInt(Encoding.UTF8.GetBytes(labelId), ref xs, ref ys, count, yref, 0, 0, sizeof(sbyte));
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
        public static void PlotShaded(string labelId, ref sbyte xs, ref sbyte ys, int count, double yref, ImPlotShadedFlags flags)
        {
                ImPlotNative.ImPlot_PlotShaded_S8PtrS8PtrInt(Encoding.UTF8.GetBytes(labelId), ref xs, ref ys, count, yref, flags, 0, sizeof(sbyte));
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
        public static void PlotShaded(string labelId, ref sbyte xs, ref sbyte ys, int count, double yref, ImPlotShadedFlags flags, int offset)
        {
                ImPlotNative.ImPlot_PlotShaded_S8PtrS8PtrInt(Encoding.UTF8.GetBytes(labelId), ref xs, ref ys, count, yref, flags, offset, sizeof(sbyte));
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
        public static void PlotShaded(string labelId, ref sbyte xs, ref sbyte ys, int count, double yref, ImPlotShadedFlags flags, int offset, int stride)
        {
                ImPlotNative.ImPlot_PlotShaded_S8PtrS8PtrInt(Encoding.UTF8.GetBytes(labelId), ref xs, ref ys, count, yref, flags, offset, stride);
        }
        
        /// <summary>
        ///     Plots the shaded using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="count">The count</param>
        public static void PlotShaded(string labelId, ref byte xs, ref byte ys, int count)
        {
            ImPlotNative.ImPlot_PlotShaded_U8PtrU8PtrInt(Encoding.UTF8.GetBytes(labelId), ref xs, ref ys, count, 0, 0, 0, sizeof(byte));
        }
        
        /// <summary>
        ///     Plots the shaded using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="count">The count</param>
        /// <param name="yref">The yref</param>
        public static void PlotShaded(string labelId, ref byte xs, ref byte ys, int count, double yref)
        {
            ImPlotNative.ImPlot_PlotShaded_U8PtrU8PtrInt(Encoding.UTF8.GetBytes(labelId), ref xs, ref ys, count, yref, 0, 0, sizeof(byte));
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
        public static void PlotShaded(string labelId, ref byte xs, ref byte ys, int count, double yref, ImPlotShadedFlags flags)
        {
            ImPlotNative.ImPlot_PlotShaded_U8PtrU8PtrInt(Encoding.UTF8.GetBytes(labelId), ref xs, ref ys, count, yref, flags, 0, sizeof(byte));
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
        public static void PlotShaded(string labelId, ref byte xs, ref byte ys, int count, double yref, ImPlotShadedFlags flags, int offset)
        {
            ImPlotNative.ImPlot_PlotShaded_U8PtrU8PtrInt(Encoding.UTF8.GetBytes(labelId), ref xs, ref ys, count, yref, flags, offset, sizeof(byte));
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
        public static void PlotShaded(string labelId, ref byte xs, ref byte ys, int count, double yref, ImPlotShadedFlags flags, int offset, int stride)
        {
            ImPlotNative.ImPlot_PlotShaded_U8PtrU8PtrInt(Encoding.UTF8.GetBytes(labelId), ref xs, ref ys, count, yref, flags, offset, stride);
        }
        
        /// <summary>
        ///     Plots the shaded using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="count">The count</param>
        public static void PlotShaded(string labelId, ref short xs, ref short ys, int count)
        {
            ImPlotNative.ImPlot_PlotShaded_S16PtrS16PtrInt(Encoding.UTF8.GetBytes(labelId), ref xs, ref ys, count, 0, 0, 0, sizeof(short));
        }
        
        /// <summary>
        ///     Plots the shaded using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="count">The count</param>
        /// <param name="yref">The yref</param>
        public static void PlotShaded(string labelId, ref short xs, ref short ys, int count, double yref)
        {
            ImPlotNative.ImPlot_PlotShaded_S16PtrS16PtrInt(Encoding.UTF8.GetBytes(labelId), ref xs, ref ys, count, yref, 0, 0, sizeof(short));
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
        public static void PlotShaded(string labelId, ref short xs, ref short ys, int count, double yref, ImPlotShadedFlags flags)
        {
            ImPlotNative.ImPlot_PlotShaded_S16PtrS16PtrInt(Encoding.UTF8.GetBytes(labelId), ref xs, ref ys, count, yref, flags, 0, sizeof(short));
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
        public static void PlotShaded(string labelId, ref short xs, ref short ys, int count, double yref, ImPlotShadedFlags flags, int offset)
        {
            ImPlotNative.ImPlot_PlotShaded_S16PtrS16PtrInt(Encoding.UTF8.GetBytes(labelId), ref xs, ref ys, count, yref, flags, offset, sizeof(short));
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
        public static void PlotShaded(string labelId, ref short xs, ref short ys, int count, double yref, ImPlotShadedFlags flags, int offset, int stride)
        {
            ImPlotNative.ImPlot_PlotShaded_S16PtrS16PtrInt(Encoding.UTF8.GetBytes(labelId), ref xs, ref ys, count, yref, flags, offset, stride);
        }
        
        /// <summary>
        ///     Plots the shaded using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="count">The count</param>
        public static void PlotShaded(string labelId, ref ushort xs, ref ushort ys, int count)
        {
            ImPlotNative.ImPlot_PlotShaded_U16PtrU16PtrInt(Encoding.UTF8.GetBytes(labelId), ref xs, ref ys, count, 0, 0, 0, sizeof(ushort));
        }
        
        /// <summary>
        ///     Plots the shaded using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="count">The count</param>
        /// <param name="yref">The yref</param>
        public static void PlotShaded(string labelId, ref ushort xs, ref ushort ys, int count, double yref)
        {
            ImPlotNative.ImPlot_PlotShaded_U16PtrU16PtrInt(Encoding.UTF8.GetBytes(labelId), ref xs, ref ys, count, yref, 0, 0, sizeof(ushort));
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
        public static void PlotShaded(string labelId, ref ushort xs, ref ushort ys, int count, double yref, ImPlotShadedFlags flags)
        {
            ImPlotNative.ImPlot_PlotShaded_U16PtrU16PtrInt(Encoding.UTF8.GetBytes(labelId), ref xs, ref ys, count, yref, flags, 0, sizeof(ushort));
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
        public static void PlotShaded(string labelId, ref ushort xs, ref ushort ys, int count, double yref, ImPlotShadedFlags flags, int offset)
        {
            ImPlotNative.ImPlot_PlotShaded_U16PtrU16PtrInt(Encoding.UTF8.GetBytes(labelId), ref xs, ref ys, count, yref, flags, offset, sizeof(ushort));
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
        public static void PlotShaded(string labelId, ref ushort xs, ref ushort ys, int count, double yref, ImPlotShadedFlags flags, int offset, int stride)
        {
            ImPlotNative.ImPlot_PlotShaded_U16PtrU16PtrInt(Encoding.UTF8.GetBytes(labelId), ref xs, ref ys, count, yref, flags, offset, stride);
        }
        
        /// <summary>
        ///     Plots the shaded using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="count">The count</param>
        public static void PlotShaded(string labelId, ref int xs, ref int ys, int count)
        {
            ImPlotNative.ImPlot_PlotShaded_S32PtrS32PtrInt(Encoding.UTF8.GetBytes(labelId), ref xs, ref ys, count, 0, 0, 0, sizeof(int));
        }
        
        /// <summary>
        ///     Plots the shaded using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="count">The count</param>
        /// <param name="yref">The yref</param>
        public static void PlotShaded(string labelId, ref int xs, ref int ys, int count, double yref)
        {
            ImPlotNative.ImPlot_PlotShaded_S32PtrS32PtrInt(Encoding.UTF8.GetBytes(labelId), ref xs, ref ys, count, yref, 0, 0, sizeof(int));
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
        public static void PlotShaded(string labelId, ref int xs, ref int ys, int count, double yref, ImPlotShadedFlags flags)
        {
            ImPlotNative.ImPlot_PlotShaded_S32PtrS32PtrInt(Encoding.UTF8.GetBytes(labelId), ref xs, ref ys, count, yref, flags, 0, sizeof(int));
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
        public static void PlotShaded(string labelId, ref int xs, ref int ys, int count, double yref, ImPlotShadedFlags flags, int offset)
        {
            ImPlotNative.ImPlot_PlotShaded_S32PtrS32PtrInt(Encoding.UTF8.GetBytes(labelId), ref xs, ref ys, count, yref, flags, offset, sizeof(int));
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
        public static void PlotShaded(string labelId, ref int xs, ref int ys, int count, double yref, ImPlotShadedFlags flags, int offset, int stride)
        {
            ImPlotNative.ImPlot_PlotShaded_S32PtrS32PtrInt(Encoding.UTF8.GetBytes(labelId), ref xs, ref ys, count, yref, flags, offset, stride);
        }
        
        /// <summary>
        ///     Plots the shaded using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="count">The count</param>
        public static void PlotShaded(string labelId, ref uint xs, ref uint ys, int count)
        {
            ImPlotNative.ImPlot_PlotShaded_U32PtrU32PtrInt(Encoding.UTF8.GetBytes(labelId), ref xs, ref ys, count, 0, 0, 0, sizeof(uint));
        }
        
        /// <summary>
        ///     Plots the shaded using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="count">The count</param>
        /// <param name="yref">The yref</param>
        public static void PlotShaded(string labelId, ref uint xs, ref uint ys, int count, double yref)
        {
            ImPlotNative.ImPlot_PlotShaded_U32PtrU32PtrInt(Encoding.UTF8.GetBytes(labelId), ref xs, ref ys, count, yref, 0, 0, sizeof(uint));
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
        public static void PlotShaded(string labelId, ref uint xs, ref uint ys, int count, double yref, ImPlotShadedFlags flags)
        {
            ImPlotNative.ImPlot_PlotShaded_U32PtrU32PtrInt(Encoding.UTF8.GetBytes(labelId), ref xs, ref ys, count, yref, flags, 0, sizeof(uint));
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
        public static void PlotShaded(string labelId, ref uint xs, ref uint ys, int count, double yref, ImPlotShadedFlags flags, int offset)
        {
            ImPlotNative.ImPlot_PlotShaded_U32PtrU32PtrInt(Encoding.UTF8.GetBytes(labelId), ref xs, ref ys, count, yref, flags, offset, sizeof(uint));
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
        public static void PlotShaded(string labelId, ref uint xs, ref uint ys, int count, double yref, ImPlotShadedFlags flags, int offset, int stride)
        {
            ImPlotNative.ImPlot_PlotShaded_U32PtrU32PtrInt(Encoding.UTF8.GetBytes(labelId), ref xs, ref ys, count, yref, flags, offset, stride);
        }
        
        /// <summary>
        ///     Plots the shaded using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="count">The count</param>
        public static void PlotShaded(string labelId, ref long xs, ref long ys, int count)
        {
            ImPlotNative.ImPlot_PlotShaded_S64PtrS64PtrInt(Encoding.UTF8.GetBytes(labelId), ref xs, ref ys, count, 0, 0, 0, sizeof(long));
        }
        
        /// <summary>
        ///     Plots the shaded using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="count">The count</param>
        /// <param name="yref">The yref</param>
        public static void PlotShaded(string labelId, ref long xs, ref long ys, int count, double yref)
        {
            ImPlotNative.ImPlot_PlotShaded_S64PtrS64PtrInt(Encoding.UTF8.GetBytes(labelId), ref xs, ref ys, count, yref, 0, 0, sizeof(long));
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
        public static void PlotShaded(string labelId, ref long xs, ref long ys, int count, double yref, ImPlotShadedFlags flags)
        {
            ImPlotNative.ImPlot_PlotShaded_S64PtrS64PtrInt(Encoding.UTF8.GetBytes(labelId), ref xs, ref ys, count, yref, flags, 0, sizeof(long));
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
        public static void PlotShaded(string labelId, ref long xs, ref long ys, int count, double yref, ImPlotShadedFlags flags, int offset)
        {
            ImPlotNative.ImPlot_PlotShaded_S64PtrS64PtrInt(Encoding.UTF8.GetBytes(labelId), ref xs, ref ys, count, yref, flags, offset, sizeof(long));
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
        public static void PlotShaded(string labelId, ref long xs, ref long ys, int count, double yref, ImPlotShadedFlags flags, int offset, int stride)
        {
            ImPlotNative.ImPlot_PlotShaded_S64PtrS64PtrInt(Encoding.UTF8.GetBytes(labelId), ref xs, ref ys, count, yref, flags, offset, stride);
        }
        
        /// <summary>
        ///     Plots the shaded using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="count">The count</param>
        public static void PlotShaded(string labelId, ref ulong xs, ref ulong ys, int count)
        {
            ImPlotNative.ImPlot_PlotShaded_U64PtrU64PtrInt(Encoding.UTF8.GetBytes(labelId), ref xs, ref ys, count, 0, 0, 0, sizeof(ulong));
        }
        
        /// <summary>
        ///     Plots the shaded using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="count">The count</param>
        /// <param name="yref">The yref</param>
        public static void PlotShaded(string labelId, ref ulong xs, ref ulong ys, int count, double yref)
        {
            ImPlotNative.ImPlot_PlotShaded_U64PtrU64PtrInt(Encoding.UTF8.GetBytes(labelId), ref xs, ref ys, count, yref, 0, 0, sizeof(ulong));
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
        public static void PlotShaded(string labelId, ref ulong xs, ref ulong ys, int count, double yref, ImPlotShadedFlags flags)
        {
            ImPlotNative.ImPlot_PlotShaded_U64PtrU64PtrInt(Encoding.UTF8.GetBytes(labelId), ref xs, ref ys, count, yref, flags, 0, sizeof(ulong));
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
        public static void PlotShaded(string labelId, ref ulong xs, ref ulong ys, int count, double yref, ImPlotShadedFlags flags, int offset)
        {
            ImPlotNative.ImPlot_PlotShaded_U64PtrU64PtrInt(Encoding.UTF8.GetBytes(labelId), ref xs, ref ys, count, yref, flags, offset, sizeof(ulong));
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
        public static void PlotShaded(string labelId, ref ulong xs, ref ulong ys, int count, double yref, ImPlotShadedFlags flags, int offset, int stride)
        {
            ImPlotNative.ImPlot_PlotShaded_U64PtrU64PtrInt(Encoding.UTF8.GetBytes(labelId), ref xs, ref ys, count, yref, flags, offset, stride);
        }
        
        /// <summary>
        ///     Plots the shaded using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys1">The ys</param>
        /// <param name="ys2">The ys</param>
        /// <param name="count">The count</param>
        public static void PlotShaded(string labelId, ref float xs, ref float ys1, ref float ys2, int count)
        {
            ImPlotNative.ImPlot_PlotShaded_FloatPtrFloatPtrFloatPtr(Encoding.UTF8.GetBytes(labelId), ref xs, ref ys1, ref ys2, count, 0, 0, 0);
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
        public static void PlotShaded(string labelId, ref float xs, ref float ys1, ref float ys2, int count, ImPlotShadedFlags flags)
        {
            ImPlotNative.ImPlot_PlotShaded_FloatPtrFloatPtrFloatPtr(Encoding.UTF8.GetBytes(labelId), ref xs, ref ys1, ref ys2, count, flags, 0, 0);
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
        public static void PlotShaded(string labelId, ref float xs, ref float ys1, ref float ys2, int count, ImPlotShadedFlags flags, int offset)
        {
            ImPlotNative.ImPlot_PlotShaded_FloatPtrFloatPtrFloatPtr(Encoding.UTF8.GetBytes(labelId), ref xs, ref ys1, ref ys2, count, flags, offset, 0);
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
        public static void PlotShaded(string labelId, ref float xs, ref float ys1, ref float ys2, int count, ImPlotShadedFlags flags, int offset, int stride)
        {
            ImPlotNative.ImPlot_PlotShaded_FloatPtrFloatPtrFloatPtr(Encoding.UTF8.GetBytes(labelId), ref xs, ref ys1, ref ys2, count, flags, offset, stride);
        }
        
        /// <summary>
        ///     Plots the shaded using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys1">The ys</param>
        /// <param name="ys2">The ys</param>
        /// <param name="count">The count</param>
        public static void PlotShaded(string labelId, ref double xs, ref double ys1, ref double ys2, int count)
        {
            ImPlotNative.ImPlot_PlotShaded_doublePtrdoublePtrdoublePtr(Encoding.UTF8.GetBytes(labelId), ref xs, ref ys1, ref ys2, count, 0, 0, 0);
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
        public static void PlotShaded(string labelId, ref double xs, ref double ys1, ref double ys2, int count, ImPlotShadedFlags flags)
        {
            ImPlotNative.ImPlot_PlotShaded_doublePtrdoublePtrdoublePtr(Encoding.UTF8.GetBytes(labelId), ref xs, ref ys1, ref ys2, count, flags, 0, 0);
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
        public static void PlotShaded(string labelId, ref double xs, ref double ys1, ref double ys2, int count, ImPlotShadedFlags flags, int offset)
        {
            ImPlotNative.ImPlot_PlotShaded_doublePtrdoublePtrdoublePtr(Encoding.UTF8.GetBytes(labelId), ref xs, ref ys1, ref ys2, count, flags, offset, 0);
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
        public static void PlotShaded(string labelId, ref double xs, ref double ys1, ref double ys2, int count, ImPlotShadedFlags flags, int offset, int stride)
        {
            ImPlotNative.ImPlot_PlotShaded_doublePtrdoublePtrdoublePtr(Encoding.UTF8.GetBytes(labelId), ref xs, ref ys1, ref ys2, count, flags, offset, stride);
        }
        
        /// <summary>
        ///     Plots the shaded using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys1">The ys</param>
        /// <param name="ys2">The ys</param>
        /// <param name="count">The count</param>
        public static void PlotShaded(string labelId, ref sbyte xs, ref sbyte ys1, ref sbyte ys2, int count)
        {
            ImPlotNative.ImPlot_PlotShaded_S8PtrS8PtrS8Ptr(Encoding.UTF8.GetBytes(labelId), ref xs, ref ys1, ref ys2, count, 0, 0, 0);
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
        public static void PlotShaded(string labelId, ref sbyte xs, ref sbyte ys1, ref sbyte ys2, int count, ImPlotShadedFlags flags)
        {
            ImPlotNative.ImPlot_PlotShaded_S8PtrS8PtrS8Ptr(Encoding.UTF8.GetBytes(labelId), ref xs, ref ys1, ref ys2, count, flags, 0, 0);
        }
    }
}