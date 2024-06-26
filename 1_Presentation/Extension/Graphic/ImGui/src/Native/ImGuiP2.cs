// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImGuiP2.cs
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

namespace Alis.Extension.Graphic.ImGui.Native
{
    /// <summary>
    /// The im gui class
    /// </summary>
    public static partial class ImGui
    {
        /// <summary>
        ///     Describes whether drag int
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="v">The </param>
        /// <param name="vSpeed">The speed</param>
        /// <returns>The bool</returns>
        public static bool DragInt(string label, ref int v, float vSpeed)
        {
            byte ret = ImGuiNative.igDragInt(Encoding.UTF8.GetBytes(label), ref v, vSpeed, 0, 0, Encoding.UTF8.GetBytes("%d"), ImGuiSliderFlags.None);
                return ret != 0;
        }
        
        /// <summary>
        ///     Describes whether drag int
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="v">The </param>
        /// <param name="vSpeed">The speed</param>
        /// <param name="vMin">The min</param>
        /// <returns>The bool</returns>
        public static bool DragInt(string label, ref int v, float vSpeed, int vMin)
        {
            byte ret = ImGuiNative.igDragInt(Encoding.UTF8.GetBytes(label), ref v, vSpeed, vMin, 0, Encoding.UTF8.GetBytes("%d"), ImGuiSliderFlags.None);
                return ret != 0;
        }
        
        /// <summary>
        ///     Describes whether drag int
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="v">The </param>
        /// <param name="vSpeed">The speed</param>
        /// <param name="vMin">The min</param>
        /// <param name="vMax">The max</param>
        /// <returns>The bool</returns>
        public static bool DragInt(string label, ref int v, float vSpeed, int vMin, int vMax)
        {
            byte ret = ImGuiNative.igDragInt(Encoding.UTF8.GetBytes(label), ref v, vSpeed, vMin, vMax, Encoding.UTF8.GetBytes("%d"), ImGuiSliderFlags.None);
                return ret != 0;
        }
        
        /// <summary>
        ///     Describes whether drag int
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="v">The </param>
        /// <param name="vSpeed">The speed</param>
        /// <param name="vMin">The min</param>
        /// <param name="vMax">The max</param>
        /// <param name="format">The format</param>
        /// <returns>The bool</returns>
        public static bool DragInt(string label, ref int v, float vSpeed, int vMin, int vMax, string format)
        {
            byte ret = ImGuiNative.igDragInt(Encoding.UTF8.GetBytes(label), ref v, vSpeed, vMin, vMax, Encoding.UTF8.GetBytes(format), ImGuiSliderFlags.None);
                return ret != 0;
        }
        
        /// <summary>
        ///     Describes whether drag int
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="v">The </param>
        /// <param name="vSpeed">The speed</param>
        /// <param name="vMin">The min</param>
        /// <param name="vMax">The max</param>
        /// <param name="format">The format</param>
        /// <param name="flags">The flags</param>
        /// <returns>The bool</returns>
        public static bool DragInt(string label, ref int v, float vSpeed, int vMin, int vMax, string format, ImGuiSliderFlags flags)
        {
            byte ret = ImGuiNative.igDragInt(Encoding.UTF8.GetBytes(label), ref v, vSpeed, vMin, vMax, Encoding.UTF8.GetBytes(format), flags);
            
                return ret != 0;
        }
        
        /// <summary>
        ///     Describes whether drag int 2
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="v">The </param>
        /// <returns>The bool</returns>
        public static bool DragInt2(string label, ref int v)
        {
            byte ret = ImGuiNative.igDragInt2(Encoding.UTF8.GetBytes(label), ref v, 1.0f, 0, 0, Encoding.UTF8.GetBytes("%d"), ImGuiSliderFlags.None);
                return ret != 0;
        }
        
        /// <summary>
        ///     Describes whether drag int 2
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="v">The </param>
        /// <param name="vSpeed">The speed</param>
        /// <returns>The bool</returns>
        public static bool DragInt2(string label, ref int v, float vSpeed)
        {
            byte ret = ImGuiNative.igDragInt2(Encoding.UTF8.GetBytes(label), ref v, vSpeed, 0, 0, Encoding.UTF8.GetBytes("%d"), ImGuiSliderFlags.None);
                return ret != 0;
        }
        
        /// <summary>
        ///     Describes whether drag int 2
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="v">The </param>
        /// <param name="vSpeed">The speed</param>
        /// <param name="vMin">The min</param>
        /// <returns>The bool</returns>
        public static bool DragInt2(string label, ref int v, float vSpeed, int vMin)
        {
            byte ret = ImGuiNative.igDragInt2(Encoding.UTF8.GetBytes(label), ref v, vSpeed, vMin, 0, Encoding.UTF8.GetBytes("%d"), ImGuiSliderFlags.None);
                return ret != 0;
        }
        
        /// <summary>
        ///     Describes whether drag int 2
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="v">The </param>
        /// <param name="vSpeed">The speed</param>
        /// <param name="vMin">The min</param>
        /// <param name="vMax">The max</param>
        /// <returns>The bool</returns>
        public static bool DragInt2(string label, ref int v, float vSpeed, int vMin, int vMax)
        {
            byte ret = ImGuiNative.igDragInt2(Encoding.UTF8.GetBytes(label), ref v, vSpeed, vMin, vMax, Encoding.UTF8.GetBytes("%d"), ImGuiSliderFlags.None);
                return ret != 0;
        }
        
        /// <summary>
        ///     Describes whether drag int 2
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="v">The </param>
        /// <param name="vSpeed">The speed</param>
        /// <param name="vMin">The min</param>
        /// <param name="vMax">The max</param>
        /// <param name="format">The format</param>
        /// <returns>The bool</returns>
        public static bool DragInt2(string label, ref int v, float vSpeed, int vMin, int vMax, string format)
        {
            byte ret = ImGuiNative.igDragInt2(Encoding.UTF8.GetBytes(label), ref v, vSpeed, vMin, vMax, Encoding.UTF8.GetBytes(format), ImGuiSliderFlags.None);
                return ret != 0;
        }
        
        /// <summary>
        ///     Describes whether drag int 2
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="v">The </param>
        /// <param name="vSpeed">The speed</param>
        /// <param name="vMin">The min</param>
        /// <param name="vMax">The max</param>
        /// <param name="format">The format</param>
        /// <param name="flags">The flags</param>
        /// <returns>The bool</returns>
        public static bool DragInt2(string label, ref int v, float vSpeed, int vMin, int vMax, string format, ImGuiSliderFlags flags)
        {
            byte ret = ImGuiNative.igDragInt2(Encoding.UTF8.GetBytes(label), ref v, vSpeed, vMin, vMax, Encoding.UTF8.GetBytes(format), flags);
                return ret != 0;
        }
        
        /// <summary>
        ///     Describes whether drag int 3
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="v">The </param>
        /// <returns>The bool</returns>
        public static bool DragInt3(string label, ref int v)
        {
            byte ret = ImGuiNative.igDragInt3(Encoding.UTF8.GetBytes(label), ref v, 1.0f, 0, 0, Encoding.UTF8.GetBytes("%d"), ImGuiSliderFlags.None);
                return ret != 0;
        }
        
        /// <summary>
        ///     Describes whether drag int 3
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="v">The </param>
        /// <param name="vSpeed">The speed</param>
        /// <returns>The bool</returns>
        public static bool DragInt3(string label, ref int v, float vSpeed)
        {
            byte ret = ImGuiNative.igDragInt3(Encoding.UTF8.GetBytes(label), ref v, vSpeed, 0, 0, Encoding.UTF8.GetBytes("%d"), ImGuiSliderFlags.None);
                return ret != 0;
        }
        
        /// <summary>
        ///     Describes whether drag int 3
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="v">The </param>
        /// <param name="vSpeed">The speed</param>
        /// <param name="vMin">The min</param>
        /// <returns>The bool</returns>
        public static bool DragInt3(string label, ref int v, float vSpeed, int vMin)
        {
            byte ret = ImGuiNative.igDragInt3(Encoding.UTF8.GetBytes(label), ref v, vSpeed, vMin, 0, Encoding.UTF8.GetBytes("%d"), ImGuiSliderFlags.None);
                return ret != 0;
        }
        
        /// <summary>
        ///     Describes whether drag int 3
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="v">The </param>
        /// <param name="vSpeed">The speed</param>
        /// <param name="vMin">The min</param>
        /// <param name="vMax">The max</param>
        /// <returns>The bool</returns>
        public static bool DragInt3(string label, ref int v, float vSpeed, int vMin, int vMax)
        {
            byte ret = ImGuiNative.igDragInt3(Encoding.UTF8.GetBytes(label), ref v, vSpeed, vMin, vMax, Encoding.UTF8.GetBytes("%d"), ImGuiSliderFlags.None);
                return ret != 0;
        }
        
        /// <summary>
        ///     Describes whether drag int 3
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="v">The </param>
        /// <param name="vSpeed">The speed</param>
        /// <param name="vMin">The min</param>
        /// <param name="vMax">The max</param>
        /// <param name="format">The format</param>
        /// <returns>The bool</returns>
        public static bool DragInt3(string label, ref int v, float vSpeed, int vMin, int vMax, string format)
        {
            byte ret = ImGuiNative.igDragInt3(Encoding.UTF8.GetBytes(label), ref v, vSpeed, vMin, vMax, Encoding.UTF8.GetBytes(format), ImGuiSliderFlags.None);
                return ret != 0;
        }
        
        /// <summary>
        ///     Describes whether drag int 3
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="v">The </param>
        /// <param name="vSpeed">The speed</param>
        /// <param name="vMin">The min</param>
        /// <param name="vMax">The max</param>
        /// <param name="format">The format</param>
        /// <param name="flags">The flags</param>
        /// <returns>The bool</returns>
        public static bool DragInt3(string label, ref int v, float vSpeed, int vMin, int vMax, string format, ImGuiSliderFlags flags)
        {
            byte ret = ImGuiNative.igDragInt3(Encoding.UTF8.GetBytes(label), ref v, vSpeed, vMin, vMax, Encoding.UTF8.GetBytes(format), flags);
                return ret != 0;
        }
        
        /// <summary>
        ///     Describes whether drag int 4
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="v">The </param>
        /// <returns>The bool</returns>
        public static bool DragInt4(string label, ref int v)
        {
            byte ret = ImGuiNative.igDragInt4(Encoding.UTF8.GetBytes(label), ref v, 1.0f, 0, 0, Encoding.UTF8.GetBytes("%d"), ImGuiSliderFlags.None);
                return ret != 0;
        }
        
        /// <summary>
        ///     Describes whether drag int 4
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="v">The </param>
        /// <param name="vSpeed">The speed</param>
        /// <returns>The bool</returns>
        public static bool DragInt4(string label, ref int v, float vSpeed)
        {
            byte ret = ImGuiNative.igDragInt4(Encoding.UTF8.GetBytes(label), ref v, vSpeed, 0, 0, Encoding.UTF8.GetBytes("%d"), ImGuiSliderFlags.None);
                return ret != 0;
        }
        
        /// <summary>
        ///     Describes whether drag int 4
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="v">The </param>
        /// <param name="vSpeed">The speed</param>
        /// <param name="vMin">The min</param>
        /// <returns>The bool</returns>
        public static bool DragInt4(string label, ref int v, float vSpeed, int vMin)
        {
            byte ret = ImGuiNative.igDragInt4(Encoding.UTF8.GetBytes(label), ref v, vSpeed, vMin, 0, Encoding.UTF8.GetBytes("%d"), ImGuiSliderFlags.None);
                return ret != 0;
        }
        
        /// <summary>
        ///     Describes whether drag int 4
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="v">The </param>
        /// <param name="vSpeed">The speed</param>
        /// <param name="vMin">The min</param>
        /// <param name="vMax">The max</param>
        /// <returns>The bool</returns>
        public static bool DragInt4(string label, ref int v, float vSpeed, int vMin, int vMax)
        {
            byte ret = ImGuiNative.igDragInt4(Encoding.UTF8.GetBytes(label), ref v, vSpeed, vMin, vMax, Encoding.UTF8.GetBytes("%d"), ImGuiSliderFlags.None);
                return ret != 0;
        }
        
        /// <summary>
        ///     Describes whether drag int 4
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="v">The </param>
        /// <param name="vSpeed">The speed</param>
        /// <param name="vMin">The min</param>
        /// <param name="vMax">The max</param>
        /// <param name="format">The format</param>
        /// <returns>The bool</returns>
        public static bool DragInt4(string label, ref int v, float vSpeed, int vMin, int vMax, string format)
        {
            byte ret = ImGuiNative.igDragInt4(Encoding.UTF8.GetBytes(label), ref v, vSpeed, vMin, vMax, Encoding.UTF8.GetBytes(format), ImGuiSliderFlags.None);
                return ret != 0;
        }
        
        /// <summary>
        ///     Describes whether drag int 4
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="v">The </param>
        /// <param name="vSpeed">The speed</param>
        /// <param name="vMin">The min</param>
        /// <param name="vMax">The max</param>
        /// <param name="format">The format</param>
        /// <param name="flags">The flags</param>
        /// <returns>The bool</returns>
        public static bool DragInt4(string label, ref int v, float vSpeed, int vMin, int vMax, string format, ImGuiSliderFlags flags)
        {
            byte ret = ImGuiNative.igDragInt4(Encoding.UTF8.GetBytes(label), ref v, vSpeed, vMin, vMax, Encoding.UTF8.GetBytes(format), flags);
                return ret != 0;
        }
        
        /// <summary>
        ///     Describes whether drag int range 2
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="vCurrentMin">The current min</param>
        /// <param name="vCurrentMax">The current max</param>
        /// <returns>The bool</returns>
        public static bool DragIntRange2(string label, ref int vCurrentMin, ref int vCurrentMax)
        {
            byte[] formatMax = Encoding.UTF8.GetBytes("");
            byte ret = ImGuiNative.igDragIntRange2(Encoding.UTF8.GetBytes(label), ref vCurrentMin, ref vCurrentMax, 1.0f, 0, 0, Encoding.UTF8.GetBytes("%d"), formatMax, ImGuiSliderFlags.None);
            return ret != 0;
        }
        
        /// <summary>
        ///     Describes whether drag int range 2
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="vCurrentMin">The current min</param>
        /// <param name="vCurrentMax">The current max</param>
        /// <param name="vSpeed">The speed</param>
        /// <returns>The bool</returns>
        public static bool DragIntRange2(string label, ref int vCurrentMin, ref int vCurrentMax, float vSpeed)
        {
            byte[] formatMax = Encoding.UTF8.GetBytes("");
            byte ret = ImGuiNative.igDragIntRange2(Encoding.UTF8.GetBytes(label), ref vCurrentMin, ref vCurrentMax, vSpeed, 0, 0, Encoding.UTF8.GetBytes("%d"),  formatMax, ImGuiSliderFlags.None);
            
                    return ret != 0;
        }
        
        /// <summary>
        ///     Describes whether drag int range 2
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="vCurrentMin">The current min</param>
        /// <param name="vCurrentMax">The current max</param>
        /// <param name="vSpeed">The speed</param>
        /// <param name="vMin">The min</param>
        /// <returns>The bool</returns>
        public static bool DragIntRange2(string label, ref int vCurrentMin, ref int vCurrentMax, float vSpeed, int vMin)
        {
            byte[] formatMax = Encoding.UTF8.GetBytes("");
            byte ret = ImGuiNative.igDragIntRange2(Encoding.UTF8.GetBytes(label), ref vCurrentMin, ref vCurrentMax, vSpeed, vMin, 0, Encoding.UTF8.GetBytes("%d"),  formatMax, ImGuiSliderFlags.None);
                    return ret != 0;
        }
        
        /// <summary>
        ///     Describes whether drag int range 2
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="vCurrentMin">The current min</param>
        /// <param name="vCurrentMax">The current max</param>
        /// <param name="vSpeed">The speed</param>
        /// <param name="vMin">The min</param>
        /// <param name="vMax">The max</param>
        /// <returns>The bool</returns>
        public static bool DragIntRange2(string label, ref int vCurrentMin, ref int vCurrentMax, float vSpeed, int vMin, int vMax)
        {
            byte[] formatMax = Encoding.UTF8.GetBytes("");
            byte ret = ImGuiNative.igDragIntRange2(Encoding.UTF8.GetBytes(label), ref vCurrentMin, ref vCurrentMax, vSpeed, vMin, vMax, Encoding.UTF8.GetBytes("%d"), formatMax, ImGuiSliderFlags.None);
            return ret != 0;
        }
        
        /// <summary>
        ///     Describes whether drag int range 2
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="vCurrentMin">The current min</param>
        /// <param name="vCurrentMax">The current max</param>
        /// <param name="vSpeed">The speed</param>
        /// <param name="vMin">The min</param>
        /// <param name="vMax">The max</param>
        /// <param name="format">The format</param>
        /// <returns>The bool</returns>
        public static bool DragIntRange2(string label, ref int vCurrentMin, ref int vCurrentMax, float vSpeed, int vMin, int vMax, string format)
        {
            byte[] formatMax = Encoding.UTF8.GetBytes("");
            byte ret = ImGuiNative.igDragIntRange2(Encoding.UTF8.GetBytes(label), ref vCurrentMin, ref vCurrentMax, vSpeed, vMin, vMax, Encoding.UTF8.GetBytes(format),  formatMax, ImGuiSliderFlags.None);
                    return ret != 0;
        }
        
        /// <summary>
        ///     Describes whether drag int range 2
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="vCurrentMin">The current min</param>
        /// <param name="vCurrentMax">The current max</param>
        /// <param name="vSpeed">The speed</param>
        /// <param name="vMin">The min</param>
        /// <param name="vMax">The max</param>
        /// <param name="format">The format</param>
        /// <param name="formatMax">The format max</param>
        /// <returns>The bool</returns>
        public static bool DragIntRange2(string label, ref int vCurrentMin, ref int vCurrentMax, float vSpeed, int vMin, int vMax, string format, string formatMax)
        {
            byte ret = ImGuiNative.igDragIntRange2(Encoding.UTF8.GetBytes(label), ref vCurrentMin, ref vCurrentMax, vSpeed, vMin, vMax, Encoding.UTF8.GetBytes(format), Encoding.UTF8.GetBytes(formatMax), ImGuiSliderFlags.None);
                    return ret != 0;
        }
        
        /// <summary>
        ///     Describes whether drag int range 2
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="vCurrentMin">The current min</param>
        /// <param name="vCurrentMax">The current max</param>
        /// <param name="vSpeed">The speed</param>
        /// <param name="vMin">The min</param>
        /// <param name="vMax">The max</param>
        /// <param name="format">The format</param>
        /// <param name="formatMax">The format max</param>
        /// <param name="flags">The flags</param>
        /// <returns>The bool</returns>
        public static bool DragIntRange2(string label, ref int vCurrentMin, ref int vCurrentMax, float vSpeed, int vMin, int vMax, string format, string formatMax, ImGuiSliderFlags flags)
        {
            byte ret = ImGuiNative.igDragIntRange2(Encoding.UTF8.GetBytes(label), ref vCurrentMin, ref vCurrentMax, vSpeed, vMin, vMax, Encoding.UTF8.GetBytes(format), Encoding.UTF8.GetBytes(formatMax), flags);
            
                    return ret != 0;
        }
        
        /// <summary>
        ///     Describes whether drag scalar
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="dataType">The data type</param>
        /// <param name="pData">The data</param>
        /// <returns>The bool</returns>
        public static bool DragScalar(string label, ImGuiDataType dataType, IntPtr pData)
        {
            byte ret = ImGuiNative.igDragScalar(Encoding.UTF8.GetBytes(label), dataType, pData, 1.0f, IntPtr.Zero, IntPtr.Zero, null, ImGuiSliderFlags.None);
            return ret != 0;
        }
        
        /// <summary>
        ///     Describes whether drag scalar
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="dataType">The data type</param>
        /// <param name="pData">The data</param>
        /// <param name="vSpeed">The speed</param>
        /// <returns>The bool</returns>
        public static bool DragScalar(string label, ImGuiDataType dataType, IntPtr pData, float vSpeed)
        {
            byte ret = ImGuiNative.igDragScalar(Encoding.UTF8.GetBytes(label), dataType, pData, vSpeed, IntPtr.Zero, IntPtr.Zero, null, ImGuiSliderFlags.None);
            return ret != 0;
        }
        
        /// <summary>
        ///     Describes whether drag scalar
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="dataType">The data type</param>
        /// <param name="pData">The data</param>
        /// <param name="vSpeed">The speed</param>
        /// <param name="pMin">The min</param>
        /// <returns>The bool</returns>
        public static bool DragScalar(string label, ImGuiDataType dataType, IntPtr pData, float vSpeed, IntPtr pMin)
        {
            byte ret = ImGuiNative.igDragScalar(Encoding.UTF8.GetBytes(label), dataType, pData, vSpeed, pMin, IntPtr.Zero, null, ImGuiSliderFlags.None);
            return ret != 0;
        }
        
        /// <summary>
        ///     Describes whether drag scalar
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="dataType">The data type</param>
        /// <param name="pData">The data</param>
        /// <param name="vSpeed">The speed</param>
        /// <param name="pMin">The min</param>
        /// <param name="pMax">The max</param>
        /// <returns>The bool</returns>
        public static bool DragScalar(string label, ImGuiDataType dataType, IntPtr pData, float vSpeed, IntPtr pMin, IntPtr pMax)
        {
            byte ret = ImGuiNative.igDragScalar(Encoding.UTF8.GetBytes(label), dataType, pData, vSpeed, pMin, pMax, null, ImGuiSliderFlags.None);
            return ret != 0;
        }
        
        /// <summary>
        ///     Describes whether drag scalar
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="dataType">The data type</param>
        /// <param name="pData">The data</param>
        /// <param name="vSpeed">The speed</param>
        /// <param name="pMin">The min</param>
        /// <param name="pMax">The max</param>
        /// <param name="format">The format</param>
        /// <returns>The bool</returns>
        public static bool DragScalar(string label, ImGuiDataType dataType, IntPtr pData, float vSpeed, IntPtr pMin, IntPtr pMax, string format)
        {
            byte ret = ImGuiNative.igDragScalar(Encoding.UTF8.GetBytes(label), dataType, pData, vSpeed, pMin, pMax, Encoding.UTF8.GetBytes(format), ImGuiSliderFlags.None);
            return ret != 0;
        }
        
        /// <summary>
        ///     Describes whether drag scalar
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="dataType">The data type</param>
        /// <param name="pData">The data</param>
        /// <param name="vSpeed">The speed</param>
        /// <param name="pMin">The min</param>
        /// <param name="pMax">The max</param>
        /// <param name="format">The format</param>
        /// <param name="flags">The flags</param>
        /// <returns>The bool</returns>
        public static bool DragScalar(string label, ImGuiDataType dataType, IntPtr pData, float vSpeed, IntPtr pMin, IntPtr pMax, string format, ImGuiSliderFlags flags)
        {
            byte ret = ImGuiNative.igDragScalar(Encoding.UTF8.GetBytes(label), dataType, pData, vSpeed, pMin, pMax, Encoding.UTF8.GetBytes(format), flags);
            return ret != 0;
        }
        
        /// <summary>
        ///     Describes whether drag scalar n
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="dataType">The data type</param>
        /// <param name="pData">The data</param>
        /// <param name="components">The components</param>
        /// <returns>The bool</returns>
        public static bool DragScalarN(string label, ImGuiDataType dataType, IntPtr pData, int components)
        {
            byte ret = ImGuiNative.igDragScalarN(Encoding.UTF8.GetBytes(label), dataType, pData, components, 1.0f, IntPtr.Zero, IntPtr.Zero, null, ImGuiSliderFlags.None);
            return ret != 0;
        }
        
        /// <summary>
        ///     Describes whether drag scalar n
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="dataType">The data type</param>
        /// <param name="pData">The data</param>
        /// <param name="components">The components</param>
        /// <param name="vSpeed">The speed</param>
        /// <returns>The bool</returns>
        public static bool DragScalarN(string label, ImGuiDataType dataType, IntPtr pData, int components, float vSpeed)
        {
            byte ret = ImGuiNative.igDragScalarN(Encoding.UTF8.GetBytes(label), dataType, pData, components, vSpeed, IntPtr.Zero, IntPtr.Zero, null, ImGuiSliderFlags.None);
            return ret != 0;
        }
        
        /// <summary>
        ///     Describes whether drag scalar n
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="dataType">The data type</param>
        /// <param name="pData">The data</param>
        /// <param name="components">The components</param>
        /// <param name="vSpeed">The speed</param>
        /// <param name="pMin">The min</param>
        /// <returns>The bool</returns>
        public static bool DragScalarN(string label, ImGuiDataType dataType, IntPtr pData, int components, float vSpeed, IntPtr pMin)
        {
            byte ret = ImGuiNative.igDragScalarN(Encoding.UTF8.GetBytes(label), dataType, pData, components, vSpeed, pMin, IntPtr.Zero, null, ImGuiSliderFlags.None);
            return ret != 0;
        }
    }
}