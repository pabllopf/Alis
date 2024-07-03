// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImGui.cs
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
using Alis.Core.Aspect.Math.Vector;

namespace Alis.Extension.Graphic.ImGui.Native
{
    /// <summary>
    /// The im gui class
    /// </summary>
    public static partial class ImGui
    {
        /// <summary>
        ///     Describes whether slider float 4
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="v">The </param>
        /// <param name="vMin">The min</param>
        /// <param name="vMax">The max</param>
        /// <param name="format">The format</param>
        /// <param name="flags">The flags</param>
        /// <returns>The bool</returns>
        public static bool SliderFloat4(string label, ref Vector4 v, float vMin, float vMax, string format, ImGuiSliderFlags flags)
        {
            byte ret = ImGuiNative.igSliderFloat4(Encoding.UTF8.GetBytes(label), v, vMin, vMax, Encoding.UTF8.GetBytes(format), flags);
            return ret != 0;
        }
        
        /// <summary>
        ///     Describes whether slider int
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="v">The </param>
        /// <param name="vMin">The min</param>
        /// <param name="vMax">The max</param>
        /// <returns>The bool</returns>
        public static bool SliderInt(string label, ref int v, int vMin, int vMax)
        {
            byte ret = ImGuiNative.igSliderInt(Encoding.UTF8.GetBytes(label), ref v, vMin, vMax, Encoding.UTF8.GetBytes("%d"), 0);
                return ret != 0;
        }
        
        /// <summary>
        ///     Describes whether slider int
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="v">The </param>
        /// <param name="vMin">The min</param>
        /// <param name="vMax">The max</param>
        /// <param name="format">The format</param>
        /// <returns>The bool</returns>
        public static bool SliderInt(string label, ref int v, int vMin, int vMax, string format)
        {
            byte ret = ImGuiNative.igSliderInt(Encoding.UTF8.GetBytes(label), ref v, vMin, vMax, Encoding.UTF8.GetBytes(format), 0);
                return ret != 0;
        }
        
        /// <summary>
        ///     Describes whether slider int
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="v">The </param>
        /// <param name="vMin">The min</param>
        /// <param name="vMax">The max</param>
        /// <param name="format">The format</param>
        /// <param name="flags">The flags</param>
        /// <returns>The bool</returns>
        public static bool SliderInt(string label, ref int v, int vMin, int vMax, string format, ImGuiSliderFlags flags)
        {
            byte ret = ImGuiNative.igSliderInt(Encoding.UTF8.GetBytes(label), ref v, vMin, vMax, Encoding.UTF8.GetBytes(format), flags);
            return ret != 0;
        }
        
        /// <summary>
        ///     Describes whether slider int 2
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="v">The </param>
        /// <param name="vMin">The min</param>
        /// <param name="vMax">The max</param>
        /// <returns>The bool</returns>
        public static bool SliderInt2(string label, ref int v, int vMin, int vMax)
        {
            byte ret = ImGuiNative.igSliderInt2(Encoding.UTF8.GetBytes(label), ref v, vMin, vMax, Encoding.UTF8.GetBytes("%d"), 0);
                return ret != 0;
        }
        
        /// <summary>
        ///     Describes whether slider int 2
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="v">The </param>
        /// <param name="vMin">The min</param>
        /// <param name="vMax">The max</param>
        /// <param name="format">The format</param>
        /// <returns>The bool</returns>
        public static bool SliderInt2(string label, ref int v, int vMin, int vMax, string format)
        {
                byte ret = ImGuiNative.igSliderInt2(Encoding.UTF8.GetBytes(label), ref v, vMin, vMax, Encoding.UTF8.GetBytes(format), 0);
                return ret != 0;
        }
        
        /// <summary>
        ///     Describes whether slider int 2
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="v">The </param>
        /// <param name="vMin">The min</param>
        /// <param name="vMax">The max</param>
        /// <param name="format">The format</param>
        /// <param name="flags">The flags</param>
        /// <returns>The bool</returns>
        public static bool SliderInt2(string label, ref int v, int vMin, int vMax, string format, ImGuiSliderFlags flags)
        {
                byte ret = ImGuiNative.igSliderInt2(Encoding.UTF8.GetBytes(label), ref v, vMin, vMax, Encoding.UTF8.GetBytes(format), flags);
                return ret != 0;
        }
        
        /// <summary>
        ///     Describes whether slider int 3
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="v">The </param>
        /// <param name="vMin">The min</param>
        /// <param name="vMax">The max</param>
        /// <returns>The bool</returns>
        public static bool SliderInt3(string label, ref int v, int vMin, int vMax)
        {
                byte ret = ImGuiNative.igSliderInt3(Encoding.UTF8.GetBytes(label), ref v, vMin, vMax, Encoding.UTF8.GetBytes("%d"), 0);
                return ret != 0;
        }
        
        /// <summary>
        ///     Describes whether slider int 3
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="v">The </param>
        /// <param name="vMin">The min</param>
        /// <param name="vMax">The max</param>
        /// <param name="format">The format</param>
        /// <returns>The bool</returns>
        public static bool SliderInt3(string label, ref int v, int vMin, int vMax, string format)
        {
                byte ret = ImGuiNative.igSliderInt3(Encoding.UTF8.GetBytes(label), ref v, vMin, vMax, Encoding.UTF8.GetBytes(format), 0);
                return ret != 0;
        }
        
        /// <summary>
        ///     Describes whether slider int 3
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="v">The </param>
        /// <param name="vMin">The min</param>
        /// <param name="vMax">The max</param>
        /// <param name="format">The format</param>
        /// <param name="flags">The flags</param>
        /// <returns>The bool</returns>
        public static bool SliderInt3(string label, ref int v, int vMin, int vMax, string format, ImGuiSliderFlags flags)
        {
                byte ret = ImGuiNative.igSliderInt3(Encoding.UTF8.GetBytes(label), ref v, vMin, vMax, Encoding.UTF8.GetBytes(format), flags);
                return ret != 0;
        }
        
        /// <summary>
        ///     Describes whether slider int 4
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="v">The </param>
        /// <param name="vMin">The min</param>
        /// <param name="vMax">The max</param>
        /// <returns>The bool</returns>
        public static bool SliderInt4(string label, ref int v, int vMin, int vMax)
        {
                byte ret = ImGuiNative.igSliderInt4(Encoding.UTF8.GetBytes(label), ref v, vMin, vMax, Encoding.UTF8.GetBytes("%d"), 0);
                return ret != 0;
        }
        
        /// <summary>
        ///     Describes whether slider int 4
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="v">The </param>
        /// <param name="vMin">The min</param>
        /// <param name="vMax">The max</param>
        /// <param name="format">The format</param>
        /// <returns>The bool</returns>
        public static bool SliderInt4(string label, ref int v, int vMin, int vMax, string format)
        {
                byte ret = ImGuiNative.igSliderInt4(Encoding.UTF8.GetBytes(label), ref v, vMin, vMax, Encoding.UTF8.GetBytes(format), 0);
                return ret != 0;
        }
        
        /// <summary>
        ///     Describes whether slider int 4
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="v">The </param>
        /// <param name="vMin">The min</param>
        /// <param name="vMax">The max</param>
        /// <param name="format">The format</param>
        /// <param name="flags">The flags</param>
        /// <returns>The bool</returns>
        public static bool SliderInt4(string label, ref int v, int vMin, int vMax, string format, ImGuiSliderFlags flags)
        {
                byte ret = ImGuiNative.igSliderInt4(Encoding.UTF8.GetBytes(label), ref v, vMin, vMax, Encoding.UTF8.GetBytes(format), flags);
                return ret != 0;
        }
        
        /// <summary>
        ///     Describes whether slider scalar
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="dataType">The data type</param>
        /// <param name="pData">The data</param>
        /// <param name="pMin">The min</param>
        /// <param name="pMax">The max</param>
        /// <returns>The bool</returns>
        public static bool SliderScalar(string label, ImGuiDataType dataType, IntPtr pData, IntPtr pMin, IntPtr pMax)
        {
            byte ret = ImGuiNative.igSliderScalar(Encoding.UTF8.GetBytes(label), dataType, pData, pMin, pMax, null, 0);
            return ret != 0;
        }
        
        /// <summary>
        ///     Describes whether slider scalar
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="dataType">The data type</param>
        /// <param name="pData">The data</param>
        /// <param name="pMin">The min</param>
        /// <param name="pMax">The max</param>
        /// <param name="format">The format</param>
        /// <returns>The bool</returns>
        public static bool SliderScalar(string label, ImGuiDataType dataType, IntPtr pData, IntPtr pMin, IntPtr pMax, string format)
        {
            byte ret = ImGuiNative.igSliderScalar(Encoding.UTF8.GetBytes(label), dataType, pData, pMin, pMax, Encoding.UTF8.GetBytes(format), 0);
            return ret != 0;
        }
        
        /// <summary>
        ///     Describes whether slider scalar
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="dataType">The data type</param>
        /// <param name="pData">The data</param>
        /// <param name="pMin">The min</param>
        /// <param name="pMax">The max</param>
        /// <param name="format">The format</param>
        /// <param name="flags">The flags</param>
        /// <returns>The bool</returns>
        public static bool SliderScalar(string label, ImGuiDataType dataType, IntPtr pData, IntPtr pMin, IntPtr pMax, string format, ImGuiSliderFlags flags)
        {
           byte ret = ImGuiNative.igSliderScalar(Encoding.UTF8.GetBytes(label), dataType, pData, pMin, pMax, Encoding.UTF8.GetBytes(format), flags);
            return ret != 0;
        }
        
        /// <summary>
        ///     Describes whether slider scalar n
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="dataType">The data type</param>
        /// <param name="pData">The data</param>
        /// <param name="components">The components</param>
        /// <param name="pMin">The min</param>
        /// <param name="pMax">The max</param>
        /// <returns>The bool</returns>
        public static bool SliderScalarN(string label, ImGuiDataType dataType, IntPtr pData, int components, IntPtr pMin, IntPtr pMax)
        {
            byte ret = ImGuiNative.igSliderScalarN(Encoding.UTF8.GetBytes(label), dataType, pData, components, pMin, pMax, null, 0);
            return ret != 0;
        }
        
        /// <summary>
        ///     Describes whether slider scalar n
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="dataType">The data type</param>
        /// <param name="pData">The data</param>
        /// <param name="components">The components</param>
        /// <param name="pMin">The min</param>
        /// <param name="pMax">The max</param>
        /// <param name="format">The format</param>
        /// <returns>The bool</returns>
        public static bool SliderScalarN(string label, ImGuiDataType dataType, IntPtr pData, int components, IntPtr pMin, IntPtr pMax, string format)
        {
            byte ret = ImGuiNative.igSliderScalarN(Encoding.UTF8.GetBytes(label), dataType, pData, components, pMin, pMax, Encoding.UTF8.GetBytes(format), 0);
            return ret != 0;
        }
        
        /// <summary>
        ///     Describes whether slider scalar n
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="dataType">The data type</param>
        /// <param name="pData">The data</param>
        /// <param name="components">The components</param>
        /// <param name="pMin">The min</param>
        /// <param name="pMax">The max</param>
        /// <param name="format">The format</param>
        /// <param name="flags">The flags</param>
        /// <returns>The bool</returns>
        public static bool SliderScalarN(string label, ImGuiDataType dataType, IntPtr pData, int components, IntPtr pMin, IntPtr pMax, string format, ImGuiSliderFlags flags)
        {
            byte ret = ImGuiNative.igSliderScalarN(Encoding.UTF8.GetBytes(label), dataType, pData, components, pMin, pMax, Encoding.UTF8.GetBytes(format), flags);
            return ret != 0;
        }
        
        /// <summary>
        ///     Describes whether small button
        /// </summary>
        /// <param name="label">The label</param>
        /// <returns>The bool</returns>
        public static bool SmallButton(string label)
        {
            byte ret = ImGuiNative.igSmallButton(Encoding.UTF8.GetBytes(label));
            return ret != 0;
        }
        
        /// <summary>
        ///     Spacings
        /// </summary>
        public static void Spacing()
        {
            ImGuiNative.igSpacing();
        }
        
        /// <summary>
        ///     Styles the colors classic
        /// </summary>
        public static void StyleColorsClassic()
        {
            ImGuiNative.igStyleColorsClassic(new ImGuiStyle());
        }
        
        /// <summary>
        ///     Styles the colors classic using the specified dst
        /// </summary>
        /// <param name="dst">The dst</param>
        public static void StyleColorsClassic(ImGuiStyle dst)
        {
            ImGuiNative.igStyleColorsClassic(dst);
        }
        
        /// <summary>
        ///     Styles the colors dark
        /// </summary>
        public static void StyleColorsDark()
        {
            ImGuiNative.igStyleColorsDark(new ImGuiStyle());
        }
        
        /// <summary>
        ///     Styles the colors dark using the specified dst
        /// </summary>
        /// <param name="dst">The dst</param>
        public static void StyleColorsDark(ImGuiStyle dst)
        {
            ImGuiNative.igStyleColorsDark(dst);
        }
        
        /// <summary>
        ///     Styles the colors light
        /// </summary>
        public static void StyleColorsLight()
        {
            ImGuiNative.igStyleColorsLight(new ImGuiStyle());
        }
        
        /// <summary>
        ///     Styles the colors light using the specified dst
        /// </summary>
        /// <param name="dst">The dst</param>
        public static void StyleColorsLight(ImGuiStyle dst)
        {
            ImGuiNative.igStyleColorsLight(dst);
        }
        
        /// <summary>
        ///     Describes whether tab item button
        /// </summary>
        /// <param name="label">The label</param>
        /// <returns>The bool</returns>
        public static bool TabItemButton(string label)
        {
            byte ret = ImGuiNative.igTabItemButton(Encoding.UTF8.GetBytes(label), 0);
            return ret != 0;
        }
        
        /// <summary>
        ///     Describes whether tab item button
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="flags">The flags</param>
        /// <returns>The bool</returns>
        public static bool TabItemButton(string label, ImGuiTabItemFlags flags)
        {
            byte ret = ImGuiNative.igTabItemButton(Encoding.UTF8.GetBytes(label), flags);
            return ret != 0;
        }
        
        /// <summary>
        ///     Tables the get column count
        /// </summary>
        /// <returns>The ret</returns>
        public static int TableGetColumnCount()
        {
            int ret = ImGuiNative.igTableGetColumnCount();
            return ret;
        }
        
        /// <summary>
        ///     Tables the get column flags
        /// </summary>
        /// <returns>The ret</returns>
        public static ImGuiTableColumnFlags TableGetColumnFlags()
        {
            int columnN = -1;
            ImGuiTableColumnFlags ret = ImGuiNative.igTableGetColumnFlags(columnN);
            return ret;
        }
        
        /// <summary>
        ///     Tables the get column flags using the specified column n
        /// </summary>
        /// <param name="columnN">The column</param>
        /// <returns>The ret</returns>
        public static ImGuiTableColumnFlags TableGetColumnFlags(int columnN)
        {
            ImGuiTableColumnFlags ret = ImGuiNative.igTableGetColumnFlags(columnN);
            return ret;
        }
        
        /// <summary>
        ///     Tables the get column index
        /// </summary>
        /// <returns>The ret</returns>
        public static int TableGetColumnIndex()
        {
            int ret = ImGuiNative.igTableGetColumnIndex();
            return ret;
        }
        
        /// <summary>
        ///     Tables the get column name
        /// </summary>
        /// <returns>The string</returns>
        public static string TableGetColumnName()
        {
            int columnN = -1;
            return Encoding.UTF8.GetString(ImGuiNative.igTableGetColumnName_Int(columnN));
        }
        
        /// <summary>
        ///     Tables the get column name using the specified column n
        /// </summary>
        /// <param name="columnN">The column</param>
        /// <returns>The string</returns>
        public static string TableGetColumnName(int columnN)
        {
            return Encoding.UTF8.GetString(ImGuiNative.igTableGetColumnName_Int(columnN));
        }
        
        /// <summary>
        ///     Tables the get row index
        /// </summary>
        /// <returns>The ret</returns>
        public static int TableGetRowIndex()
        {
            int ret = ImGuiNative.igTableGetRowIndex();
            return ret;
        }
        
        /// <summary>
        ///     Tables the get sort specs
        /// </summary>
        /// <returns>The im gui table sort specs ptr</returns>
        public static ImGuiTableSortSpecs TableGetSortSpecs() => ImGuiNative.igTableGetSortSpecs();
        
        /// <summary>
        ///     Tables the header using the specified label
        /// </summary>
        /// <param name="label">The label</param>
        public static void TableHeader(string label)
        {
            ImGuiNative.igTableHeader(Encoding.UTF8.GetBytes(label));
        }
        
        /// <summary>
        ///     Tables the headers row
        /// </summary>
        public static void TableHeadersRow()
        {
            ImGuiNative.igTableHeadersRow();
        }
        
        /// <summary>
        ///     Describes whether table next column
        /// </summary>
        /// <returns>The bool</returns>
        public static bool TableNextColumn()
        {
            byte ret = ImGuiNative.igTableNextColumn();
            return ret != 0;
        }
        
        /// <summary>
        ///     Tables the next row
        /// </summary>
        public static void TableNextRow()
        {
            ImGuiTableRowFlags rowFlags = 0;
            float minRowHeight = 0.0f;
            ImGuiNative.igTableNextRow(rowFlags, minRowHeight);
        }
        
        /// <summary>
        ///     Tables the next row using the specified row flags
        /// </summary>
        /// <param name="rowFlags">The row flags</param>
        public static void TableNextRow(ImGuiTableRowFlags rowFlags)
        {
            float minRowHeight = 0.0f;
            ImGuiNative.igTableNextRow(rowFlags, minRowHeight);
        }
        
        /// <summary>
        ///     Tables the next row using the specified row flags
        /// </summary>
        /// <param name="rowFlags">The row flags</param>
        /// <param name="minRowHeight">The min row height</param>
        public static void TableNextRow(ImGuiTableRowFlags rowFlags, float minRowHeight)
        {
            ImGuiNative.igTableNextRow(rowFlags, minRowHeight);
        }
        
        /// <summary>
        ///     Tables the set bg color using the specified target
        /// </summary>
        /// <param name="target">The target</param>
        /// <param name="color">The color</param>
        public static void TableSetBgColor(ImGuiTableBgTarget target, uint color)
        {
            int columnN = -1;
            ImGuiNative.igTableSetBgColor(target, color, columnN);
        }
        
        /// <summary>
        ///     Tables the set bg color using the specified target
        /// </summary>
        /// <param name="target">The target</param>
        /// <param name="color">The color</param>
        /// <param name="columnN">The column</param>
        public static void TableSetBgColor(ImGuiTableBgTarget target, uint color, int columnN)
        {
            ImGuiNative.igTableSetBgColor(target, color, columnN);
        }
        
        /// <summary>
        ///     Tables the set column enabled using the specified column n
        /// </summary>
        /// <param name="columnN">The column</param>
        /// <param name="v">The </param>
        public static void TableSetColumnEnabled(int columnN, bool v)
        {
            byte nativeV = v ? (byte) 1 : (byte) 0;
            ImGuiNative.igTableSetColumnEnabled(columnN, nativeV);
        }
        
        /// <summary>
        ///     Describes whether table set column index
        /// </summary>
        /// <param name="columnN">The column</param>
        /// <returns>The bool</returns>
        public static bool TableSetColumnIndex(int columnN)
        {
            byte ret = ImGuiNative.igTableSetColumnIndex(columnN);
            return ret != 0;
        }
        
        /// <summary>
        ///     Tables the setup column using the specified label
        /// </summary>
        /// <param name="label">The label</param>
        public static void TableSetupColumn(string label)
        {
            ImGuiNative.igTableSetupColumn(Encoding.UTF8.GetBytes(label), 0, 0, 0);
        }
        
        /// <summary>
                ///     Describes whether menu item
                /// </summary>
                /// <param name="label">The label</param>
                /// <param name="enabled">The enabled</param>
                /// <returns>The bool</returns>
                public static bool MenuItem(string label, bool enabled) => MenuItem(label, string.Empty, false, enabled);
    }
}