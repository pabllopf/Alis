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
    public static unsafe partial class ImGui
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
            byte* nativeLabel;
            int labelByteCount = 0;
            if (label != null)
            {
                labelByteCount = Encoding.UTF8.GetByteCount(label);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeLabel = Util.Allocate(labelByteCount + 1);
                }
                else
                {
                    byte* nativeLabelStackBytes = stackalloc byte[labelByteCount + 1];
                    nativeLabel = nativeLabelStackBytes;
                }
                
                int nativeLabelOffset = Util.GetUtf8(label, nativeLabel, labelByteCount);
                nativeLabel[nativeLabelOffset] = 0;
            }
            else
            {
                nativeLabel = null;
            }
            
            int vMin = 0;
            int vMax = 0;
            byte* nativeFormat;
            int formatByteCount = 0;
            formatByteCount = Encoding.UTF8.GetByteCount("%d");
            if (formatByteCount > Util.StackAllocationSizeLimit)
            {
                nativeFormat = Util.Allocate(formatByteCount + 1);
            }
            else
            {
                byte* nativeFormatStackBytes = stackalloc byte[formatByteCount + 1];
                nativeFormat = nativeFormatStackBytes;
            }
            
            int nativeFormatOffset = Util.GetUtf8("%d", nativeFormat, formatByteCount);
            nativeFormat[nativeFormatOffset] = 0;
            ImGuiSliderFlags flags = 0;
            fixed (int* nativeV = &v)
            {
                byte ret = ImGuiNative.igDragInt(nativeLabel, nativeV, vSpeed, vMin, vMax, nativeFormat, flags);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeLabel);
                }
                
                if (formatByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeFormat);
                }
                
                return ret != 0;
            }
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
            byte* nativeLabel;
            int labelByteCount = 0;
            if (label != null)
            {
                labelByteCount = Encoding.UTF8.GetByteCount(label);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeLabel = Util.Allocate(labelByteCount + 1);
                }
                else
                {
                    byte* nativeLabelStackBytes = stackalloc byte[labelByteCount + 1];
                    nativeLabel = nativeLabelStackBytes;
                }
                
                int nativeLabelOffset = Util.GetUtf8(label, nativeLabel, labelByteCount);
                nativeLabel[nativeLabelOffset] = 0;
            }
            else
            {
                nativeLabel = null;
            }
            
            int vMax = 0;
            byte* nativeFormat;
            int formatByteCount = 0;
            formatByteCount = Encoding.UTF8.GetByteCount("%d");
            if (formatByteCount > Util.StackAllocationSizeLimit)
            {
                nativeFormat = Util.Allocate(formatByteCount + 1);
            }
            else
            {
                byte* nativeFormatStackBytes = stackalloc byte[formatByteCount + 1];
                nativeFormat = nativeFormatStackBytes;
            }
            
            int nativeFormatOffset = Util.GetUtf8("%d", nativeFormat, formatByteCount);
            nativeFormat[nativeFormatOffset] = 0;
            ImGuiSliderFlags flags = 0;
            fixed (int* nativeV = &v)
            {
                byte ret = ImGuiNative.igDragInt(nativeLabel, nativeV, vSpeed, vMin, vMax, nativeFormat, flags);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeLabel);
                }
                
                if (formatByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeFormat);
                }
                
                return ret != 0;
            }
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
            byte* nativeLabel;
            int labelByteCount = 0;
            if (label != null)
            {
                labelByteCount = Encoding.UTF8.GetByteCount(label);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeLabel = Util.Allocate(labelByteCount + 1);
                }
                else
                {
                    byte* nativeLabelStackBytes = stackalloc byte[labelByteCount + 1];
                    nativeLabel = nativeLabelStackBytes;
                }
                
                int nativeLabelOffset = Util.GetUtf8(label, nativeLabel, labelByteCount);
                nativeLabel[nativeLabelOffset] = 0;
            }
            else
            {
                nativeLabel = null;
            }
            
            byte* nativeFormat;
            int formatByteCount = 0;
            formatByteCount = Encoding.UTF8.GetByteCount("%d");
            if (formatByteCount > Util.StackAllocationSizeLimit)
            {
                nativeFormat = Util.Allocate(formatByteCount + 1);
            }
            else
            {
                byte* nativeFormatStackBytes = stackalloc byte[formatByteCount + 1];
                nativeFormat = nativeFormatStackBytes;
            }
            
            int nativeFormatOffset = Util.GetUtf8("%d", nativeFormat, formatByteCount);
            nativeFormat[nativeFormatOffset] = 0;
            ImGuiSliderFlags flags = 0;
            fixed (int* nativeV = &v)
            {
                byte ret = ImGuiNative.igDragInt(nativeLabel, nativeV, vSpeed, vMin, vMax, nativeFormat, flags);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeLabel);
                }
                
                if (formatByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeFormat);
                }
                
                return ret != 0;
            }
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
            byte* nativeLabel;
            int labelByteCount = 0;
            if (label != null)
            {
                labelByteCount = Encoding.UTF8.GetByteCount(label);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeLabel = Util.Allocate(labelByteCount + 1);
                }
                else
                {
                    byte* nativeLabelStackBytes = stackalloc byte[labelByteCount + 1];
                    nativeLabel = nativeLabelStackBytes;
                }
                
                int nativeLabelOffset = Util.GetUtf8(label, nativeLabel, labelByteCount);
                nativeLabel[nativeLabelOffset] = 0;
            }
            else
            {
                nativeLabel = null;
            }
            
            byte* nativeFormat;
            int formatByteCount = 0;
            if (format != null)
            {
                formatByteCount = Encoding.UTF8.GetByteCount(format);
                if (formatByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeFormat = Util.Allocate(formatByteCount + 1);
                }
                else
                {
                    byte* nativeFormatStackBytes = stackalloc byte[formatByteCount + 1];
                    nativeFormat = nativeFormatStackBytes;
                }
                
                int nativeFormatOffset = Util.GetUtf8(format, nativeFormat, formatByteCount);
                nativeFormat[nativeFormatOffset] = 0;
            }
            else
            {
                nativeFormat = null;
            }
            
            ImGuiSliderFlags flags = 0;
            fixed (int* nativeV = &v)
            {
                byte ret = ImGuiNative.igDragInt(nativeLabel, nativeV, vSpeed, vMin, vMax, nativeFormat, flags);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeLabel);
                }
                
                if (formatByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeFormat);
                }
                
                return ret != 0;
            }
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
            byte* nativeLabel;
            int labelByteCount = 0;
            if (label != null)
            {
                labelByteCount = Encoding.UTF8.GetByteCount(label);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeLabel = Util.Allocate(labelByteCount + 1);
                }
                else
                {
                    byte* nativeLabelStackBytes = stackalloc byte[labelByteCount + 1];
                    nativeLabel = nativeLabelStackBytes;
                }
                
                int nativeLabelOffset = Util.GetUtf8(label, nativeLabel, labelByteCount);
                nativeLabel[nativeLabelOffset] = 0;
            }
            else
            {
                nativeLabel = null;
            }
            
            byte* nativeFormat;
            int formatByteCount = 0;
            if (format != null)
            {
                formatByteCount = Encoding.UTF8.GetByteCount(format);
                if (formatByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeFormat = Util.Allocate(formatByteCount + 1);
                }
                else
                {
                    byte* nativeFormatStackBytes = stackalloc byte[formatByteCount + 1];
                    nativeFormat = nativeFormatStackBytes;
                }
                
                int nativeFormatOffset = Util.GetUtf8(format, nativeFormat, formatByteCount);
                nativeFormat[nativeFormatOffset] = 0;
            }
            else
            {
                nativeFormat = null;
            }
            
            fixed (int* nativeV = &v)
            {
                byte ret = ImGuiNative.igDragInt(nativeLabel, nativeV, vSpeed, vMin, vMax, nativeFormat, flags);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeLabel);
                }
                
                if (formatByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeFormat);
                }
                
                return ret != 0;
            }
        }
        
        /// <summary>
        ///     Describes whether drag int 2
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="v">The </param>
        /// <returns>The bool</returns>
        public static bool DragInt2(string label, ref int v)
        {
            byte* nativeLabel;
            int labelByteCount = 0;
            if (label != null)
            {
                labelByteCount = Encoding.UTF8.GetByteCount(label);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeLabel = Util.Allocate(labelByteCount + 1);
                }
                else
                {
                    byte* nativeLabelStackBytes = stackalloc byte[labelByteCount + 1];
                    nativeLabel = nativeLabelStackBytes;
                }
                
                int nativeLabelOffset = Util.GetUtf8(label, nativeLabel, labelByteCount);
                nativeLabel[nativeLabelOffset] = 0;
            }
            else
            {
                nativeLabel = null;
            }
            
            float vSpeed = 1.0f;
            int vMin = 0;
            int vMax = 0;
            byte* nativeFormat;
            int formatByteCount = 0;
            formatByteCount = Encoding.UTF8.GetByteCount("%d");
            if (formatByteCount > Util.StackAllocationSizeLimit)
            {
                nativeFormat = Util.Allocate(formatByteCount + 1);
            }
            else
            {
                byte* nativeFormatStackBytes = stackalloc byte[formatByteCount + 1];
                nativeFormat = nativeFormatStackBytes;
            }
            
            int nativeFormatOffset = Util.GetUtf8("%d", nativeFormat, formatByteCount);
            nativeFormat[nativeFormatOffset] = 0;
            ImGuiSliderFlags flags = 0;
            fixed (int* nativeV = &v)
            {
                byte ret = ImGuiNative.igDragInt2(nativeLabel, nativeV, vSpeed, vMin, vMax, nativeFormat, flags);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeLabel);
                }
                
                if (formatByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeFormat);
                }
                
                return ret != 0;
            }
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
            byte* nativeLabel;
            int labelByteCount = 0;
            if (label != null)
            {
                labelByteCount = Encoding.UTF8.GetByteCount(label);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeLabel = Util.Allocate(labelByteCount + 1);
                }
                else
                {
                    byte* nativeLabelStackBytes = stackalloc byte[labelByteCount + 1];
                    nativeLabel = nativeLabelStackBytes;
                }
                
                int nativeLabelOffset = Util.GetUtf8(label, nativeLabel, labelByteCount);
                nativeLabel[nativeLabelOffset] = 0;
            }
            else
            {
                nativeLabel = null;
            }
            
            int vMin = 0;
            int vMax = 0;
            byte* nativeFormat;
            int formatByteCount = 0;
            formatByteCount = Encoding.UTF8.GetByteCount("%d");
            if (formatByteCount > Util.StackAllocationSizeLimit)
            {
                nativeFormat = Util.Allocate(formatByteCount + 1);
            }
            else
            {
                byte* nativeFormatStackBytes = stackalloc byte[formatByteCount + 1];
                nativeFormat = nativeFormatStackBytes;
            }
            
            int nativeFormatOffset = Util.GetUtf8("%d", nativeFormat, formatByteCount);
            nativeFormat[nativeFormatOffset] = 0;
            ImGuiSliderFlags flags = 0;
            fixed (int* nativeV = &v)
            {
                byte ret = ImGuiNative.igDragInt2(nativeLabel, nativeV, vSpeed, vMin, vMax, nativeFormat, flags);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeLabel);
                }
                
                if (formatByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeFormat);
                }
                
                return ret != 0;
            }
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
            byte* nativeLabel;
            int labelByteCount = 0;
            if (label != null)
            {
                labelByteCount = Encoding.UTF8.GetByteCount(label);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeLabel = Util.Allocate(labelByteCount + 1);
                }
                else
                {
                    byte* nativeLabelStackBytes = stackalloc byte[labelByteCount + 1];
                    nativeLabel = nativeLabelStackBytes;
                }
                
                int nativeLabelOffset = Util.GetUtf8(label, nativeLabel, labelByteCount);
                nativeLabel[nativeLabelOffset] = 0;
            }
            else
            {
                nativeLabel = null;
            }
            
            int vMax = 0;
            byte* nativeFormat;
            int formatByteCount = 0;
            formatByteCount = Encoding.UTF8.GetByteCount("%d");
            if (formatByteCount > Util.StackAllocationSizeLimit)
            {
                nativeFormat = Util.Allocate(formatByteCount + 1);
            }
            else
            {
                byte* nativeFormatStackBytes = stackalloc byte[formatByteCount + 1];
                nativeFormat = nativeFormatStackBytes;
            }
            
            int nativeFormatOffset = Util.GetUtf8("%d", nativeFormat, formatByteCount);
            nativeFormat[nativeFormatOffset] = 0;
            ImGuiSliderFlags flags = 0;
            fixed (int* nativeV = &v)
            {
                byte ret = ImGuiNative.igDragInt2(nativeLabel, nativeV, vSpeed, vMin, vMax, nativeFormat, flags);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeLabel);
                }
                
                if (formatByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeFormat);
                }
                
                return ret != 0;
            }
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
            byte* nativeLabel;
            int labelByteCount = 0;
            if (label != null)
            {
                labelByteCount = Encoding.UTF8.GetByteCount(label);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeLabel = Util.Allocate(labelByteCount + 1);
                }
                else
                {
                    byte* nativeLabelStackBytes = stackalloc byte[labelByteCount + 1];
                    nativeLabel = nativeLabelStackBytes;
                }
                
                int nativeLabelOffset = Util.GetUtf8(label, nativeLabel, labelByteCount);
                nativeLabel[nativeLabelOffset] = 0;
            }
            else
            {
                nativeLabel = null;
            }
            
            byte* nativeFormat;
            int formatByteCount = 0;
            formatByteCount = Encoding.UTF8.GetByteCount("%d");
            if (formatByteCount > Util.StackAllocationSizeLimit)
            {
                nativeFormat = Util.Allocate(formatByteCount + 1);
            }
            else
            {
                byte* nativeFormatStackBytes = stackalloc byte[formatByteCount + 1];
                nativeFormat = nativeFormatStackBytes;
            }
            
            int nativeFormatOffset = Util.GetUtf8("%d", nativeFormat, formatByteCount);
            nativeFormat[nativeFormatOffset] = 0;
            ImGuiSliderFlags flags = 0;
            fixed (int* nativeV = &v)
            {
                byte ret = ImGuiNative.igDragInt2(nativeLabel, nativeV, vSpeed, vMin, vMax, nativeFormat, flags);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeLabel);
                }
                
                if (formatByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeFormat);
                }
                
                return ret != 0;
            }
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
            byte* nativeLabel;
            int labelByteCount = 0;
            if (label != null)
            {
                labelByteCount = Encoding.UTF8.GetByteCount(label);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeLabel = Util.Allocate(labelByteCount + 1);
                }
                else
                {
                    byte* nativeLabelStackBytes = stackalloc byte[labelByteCount + 1];
                    nativeLabel = nativeLabelStackBytes;
                }
                
                int nativeLabelOffset = Util.GetUtf8(label, nativeLabel, labelByteCount);
                nativeLabel[nativeLabelOffset] = 0;
            }
            else
            {
                nativeLabel = null;
            }
            
            byte* nativeFormat;
            int formatByteCount = 0;
            if (format != null)
            {
                formatByteCount = Encoding.UTF8.GetByteCount(format);
                if (formatByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeFormat = Util.Allocate(formatByteCount + 1);
                }
                else
                {
                    byte* nativeFormatStackBytes = stackalloc byte[formatByteCount + 1];
                    nativeFormat = nativeFormatStackBytes;
                }
                
                int nativeFormatOffset = Util.GetUtf8(format, nativeFormat, formatByteCount);
                nativeFormat[nativeFormatOffset] = 0;
            }
            else
            {
                nativeFormat = null;
            }
            
            ImGuiSliderFlags flags = 0;
            fixed (int* nativeV = &v)
            {
                byte ret = ImGuiNative.igDragInt2(nativeLabel, nativeV, vSpeed, vMin, vMax, nativeFormat, flags);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeLabel);
                }
                
                if (formatByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeFormat);
                }
                
                return ret != 0;
            }
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
            byte* nativeLabel;
            int labelByteCount = 0;
            if (label != null)
            {
                labelByteCount = Encoding.UTF8.GetByteCount(label);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeLabel = Util.Allocate(labelByteCount + 1);
                }
                else
                {
                    byte* nativeLabelStackBytes = stackalloc byte[labelByteCount + 1];
                    nativeLabel = nativeLabelStackBytes;
                }
                
                int nativeLabelOffset = Util.GetUtf8(label, nativeLabel, labelByteCount);
                nativeLabel[nativeLabelOffset] = 0;
            }
            else
            {
                nativeLabel = null;
            }
            
            byte* nativeFormat;
            int formatByteCount = 0;
            if (format != null)
            {
                formatByteCount = Encoding.UTF8.GetByteCount(format);
                if (formatByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeFormat = Util.Allocate(formatByteCount + 1);
                }
                else
                {
                    byte* nativeFormatStackBytes = stackalloc byte[formatByteCount + 1];
                    nativeFormat = nativeFormatStackBytes;
                }
                
                int nativeFormatOffset = Util.GetUtf8(format, nativeFormat, formatByteCount);
                nativeFormat[nativeFormatOffset] = 0;
            }
            else
            {
                nativeFormat = null;
            }
            
            fixed (int* nativeV = &v)
            {
                byte ret = ImGuiNative.igDragInt2(nativeLabel, nativeV, vSpeed, vMin, vMax, nativeFormat, flags);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeLabel);
                }
                
                if (formatByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeFormat);
                }
                
                return ret != 0;
            }
        }
        
        /// <summary>
        ///     Describes whether drag int 3
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="v">The </param>
        /// <returns>The bool</returns>
        public static bool DragInt3(string label, ref int v)
        {
            byte* nativeLabel;
            int labelByteCount = 0;
            if (label != null)
            {
                labelByteCount = Encoding.UTF8.GetByteCount(label);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeLabel = Util.Allocate(labelByteCount + 1);
                }
                else
                {
                    byte* nativeLabelStackBytes = stackalloc byte[labelByteCount + 1];
                    nativeLabel = nativeLabelStackBytes;
                }
                
                int nativeLabelOffset = Util.GetUtf8(label, nativeLabel, labelByteCount);
                nativeLabel[nativeLabelOffset] = 0;
            }
            else
            {
                nativeLabel = null;
            }
            
            float vSpeed = 1.0f;
            int vMin = 0;
            int vMax = 0;
            byte* nativeFormat;
            int formatByteCount = 0;
            formatByteCount = Encoding.UTF8.GetByteCount("%d");
            if (formatByteCount > Util.StackAllocationSizeLimit)
            {
                nativeFormat = Util.Allocate(formatByteCount + 1);
            }
            else
            {
                byte* nativeFormatStackBytes = stackalloc byte[formatByteCount + 1];
                nativeFormat = nativeFormatStackBytes;
            }
            
            int nativeFormatOffset = Util.GetUtf8("%d", nativeFormat, formatByteCount);
            nativeFormat[nativeFormatOffset] = 0;
            ImGuiSliderFlags flags = 0;
            fixed (int* nativeV = &v)
            {
                byte ret = ImGuiNative.igDragInt3(nativeLabel, nativeV, vSpeed, vMin, vMax, nativeFormat, flags);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeLabel);
                }
                
                if (formatByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeFormat);
                }
                
                return ret != 0;
            }
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
            byte* nativeLabel;
            int labelByteCount = 0;
            if (label != null)
            {
                labelByteCount = Encoding.UTF8.GetByteCount(label);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeLabel = Util.Allocate(labelByteCount + 1);
                }
                else
                {
                    byte* nativeLabelStackBytes = stackalloc byte[labelByteCount + 1];
                    nativeLabel = nativeLabelStackBytes;
                }
                
                int nativeLabelOffset = Util.GetUtf8(label, nativeLabel, labelByteCount);
                nativeLabel[nativeLabelOffset] = 0;
            }
            else
            {
                nativeLabel = null;
            }
            
            int vMin = 0;
            int vMax = 0;
            byte* nativeFormat;
            int formatByteCount = 0;
            formatByteCount = Encoding.UTF8.GetByteCount("%d");
            if (formatByteCount > Util.StackAllocationSizeLimit)
            {
                nativeFormat = Util.Allocate(formatByteCount + 1);
            }
            else
            {
                byte* nativeFormatStackBytes = stackalloc byte[formatByteCount + 1];
                nativeFormat = nativeFormatStackBytes;
            }
            
            int nativeFormatOffset = Util.GetUtf8("%d", nativeFormat, formatByteCount);
            nativeFormat[nativeFormatOffset] = 0;
            ImGuiSliderFlags flags = 0;
            fixed (int* nativeV = &v)
            {
                byte ret = ImGuiNative.igDragInt3(nativeLabel, nativeV, vSpeed, vMin, vMax, nativeFormat, flags);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeLabel);
                }
                
                if (formatByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeFormat);
                }
                
                return ret != 0;
            }
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
            byte* nativeLabel;
            int labelByteCount = 0;
            if (label != null)
            {
                labelByteCount = Encoding.UTF8.GetByteCount(label);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeLabel = Util.Allocate(labelByteCount + 1);
                }
                else
                {
                    byte* nativeLabelStackBytes = stackalloc byte[labelByteCount + 1];
                    nativeLabel = nativeLabelStackBytes;
                }
                
                int nativeLabelOffset = Util.GetUtf8(label, nativeLabel, labelByteCount);
                nativeLabel[nativeLabelOffset] = 0;
            }
            else
            {
                nativeLabel = null;
            }
            
            int vMax = 0;
            byte* nativeFormat;
            int formatByteCount = 0;
            formatByteCount = Encoding.UTF8.GetByteCount("%d");
            if (formatByteCount > Util.StackAllocationSizeLimit)
            {
                nativeFormat = Util.Allocate(formatByteCount + 1);
            }
            else
            {
                byte* nativeFormatStackBytes = stackalloc byte[formatByteCount + 1];
                nativeFormat = nativeFormatStackBytes;
            }
            
            int nativeFormatOffset = Util.GetUtf8("%d", nativeFormat, formatByteCount);
            nativeFormat[nativeFormatOffset] = 0;
            ImGuiSliderFlags flags = 0;
            fixed (int* nativeV = &v)
            {
                byte ret = ImGuiNative.igDragInt3(nativeLabel, nativeV, vSpeed, vMin, vMax, nativeFormat, flags);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeLabel);
                }
                
                if (formatByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeFormat);
                }
                
                return ret != 0;
            }
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
            byte* nativeLabel;
            int labelByteCount = 0;
            if (label != null)
            {
                labelByteCount = Encoding.UTF8.GetByteCount(label);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeLabel = Util.Allocate(labelByteCount + 1);
                }
                else
                {
                    byte* nativeLabelStackBytes = stackalloc byte[labelByteCount + 1];
                    nativeLabel = nativeLabelStackBytes;
                }
                
                int nativeLabelOffset = Util.GetUtf8(label, nativeLabel, labelByteCount);
                nativeLabel[nativeLabelOffset] = 0;
            }
            else
            {
                nativeLabel = null;
            }
            
            byte* nativeFormat;
            int formatByteCount = 0;
            formatByteCount = Encoding.UTF8.GetByteCount("%d");
            if (formatByteCount > Util.StackAllocationSizeLimit)
            {
                nativeFormat = Util.Allocate(formatByteCount + 1);
            }
            else
            {
                byte* nativeFormatStackBytes = stackalloc byte[formatByteCount + 1];
                nativeFormat = nativeFormatStackBytes;
            }
            
            int nativeFormatOffset = Util.GetUtf8("%d", nativeFormat, formatByteCount);
            nativeFormat[nativeFormatOffset] = 0;
            ImGuiSliderFlags flags = 0;
            fixed (int* nativeV = &v)
            {
                byte ret = ImGuiNative.igDragInt3(nativeLabel, nativeV, vSpeed, vMin, vMax, nativeFormat, flags);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeLabel);
                }
                
                if (formatByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeFormat);
                }
                
                return ret != 0;
            }
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
            byte* nativeLabel;
            int labelByteCount = 0;
            if (label != null)
            {
                labelByteCount = Encoding.UTF8.GetByteCount(label);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeLabel = Util.Allocate(labelByteCount + 1);
                }
                else
                {
                    byte* nativeLabelStackBytes = stackalloc byte[labelByteCount + 1];
                    nativeLabel = nativeLabelStackBytes;
                }
                
                int nativeLabelOffset = Util.GetUtf8(label, nativeLabel, labelByteCount);
                nativeLabel[nativeLabelOffset] = 0;
            }
            else
            {
                nativeLabel = null;
            }
            
            byte* nativeFormat;
            int formatByteCount = 0;
            if (format != null)
            {
                formatByteCount = Encoding.UTF8.GetByteCount(format);
                if (formatByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeFormat = Util.Allocate(formatByteCount + 1);
                }
                else
                {
                    byte* nativeFormatStackBytes = stackalloc byte[formatByteCount + 1];
                    nativeFormat = nativeFormatStackBytes;
                }
                
                int nativeFormatOffset = Util.GetUtf8(format, nativeFormat, formatByteCount);
                nativeFormat[nativeFormatOffset] = 0;
            }
            else
            {
                nativeFormat = null;
            }
            
            ImGuiSliderFlags flags = 0;
            fixed (int* nativeV = &v)
            {
                byte ret = ImGuiNative.igDragInt3(nativeLabel, nativeV, vSpeed, vMin, vMax, nativeFormat, flags);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeLabel);
                }
                
                if (formatByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeFormat);
                }
                
                return ret != 0;
            }
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
            byte* nativeLabel;
            int labelByteCount = 0;
            if (label != null)
            {
                labelByteCount = Encoding.UTF8.GetByteCount(label);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeLabel = Util.Allocate(labelByteCount + 1);
                }
                else
                {
                    byte* nativeLabelStackBytes = stackalloc byte[labelByteCount + 1];
                    nativeLabel = nativeLabelStackBytes;
                }
                
                int nativeLabelOffset = Util.GetUtf8(label, nativeLabel, labelByteCount);
                nativeLabel[nativeLabelOffset] = 0;
            }
            else
            {
                nativeLabel = null;
            }
            
            byte* nativeFormat;
            int formatByteCount = 0;
            if (format != null)
            {
                formatByteCount = Encoding.UTF8.GetByteCount(format);
                if (formatByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeFormat = Util.Allocate(formatByteCount + 1);
                }
                else
                {
                    byte* nativeFormatStackBytes = stackalloc byte[formatByteCount + 1];
                    nativeFormat = nativeFormatStackBytes;
                }
                
                int nativeFormatOffset = Util.GetUtf8(format, nativeFormat, formatByteCount);
                nativeFormat[nativeFormatOffset] = 0;
            }
            else
            {
                nativeFormat = null;
            }
            
            fixed (int* nativeV = &v)
            {
                byte ret = ImGuiNative.igDragInt3(nativeLabel, nativeV, vSpeed, vMin, vMax, nativeFormat, flags);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeLabel);
                }
                
                if (formatByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeFormat);
                }
                
                return ret != 0;
            }
        }
        
        /// <summary>
        ///     Describes whether drag int 4
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="v">The </param>
        /// <returns>The bool</returns>
        public static bool DragInt4(string label, ref int v)
        {
            byte* nativeLabel;
            int labelByteCount = 0;
            if (label != null)
            {
                labelByteCount = Encoding.UTF8.GetByteCount(label);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeLabel = Util.Allocate(labelByteCount + 1);
                }
                else
                {
                    byte* nativeLabelStackBytes = stackalloc byte[labelByteCount + 1];
                    nativeLabel = nativeLabelStackBytes;
                }
                
                int nativeLabelOffset = Util.GetUtf8(label, nativeLabel, labelByteCount);
                nativeLabel[nativeLabelOffset] = 0;
            }
            else
            {
                nativeLabel = null;
            }
            
            float vSpeed = 1.0f;
            int vMin = 0;
            int vMax = 0;
            byte* nativeFormat;
            int formatByteCount = 0;
            formatByteCount = Encoding.UTF8.GetByteCount("%d");
            if (formatByteCount > Util.StackAllocationSizeLimit)
            {
                nativeFormat = Util.Allocate(formatByteCount + 1);
            }
            else
            {
                byte* nativeFormatStackBytes = stackalloc byte[formatByteCount + 1];
                nativeFormat = nativeFormatStackBytes;
            }
            
            int nativeFormatOffset = Util.GetUtf8("%d", nativeFormat, formatByteCount);
            nativeFormat[nativeFormatOffset] = 0;
            ImGuiSliderFlags flags = 0;
            fixed (int* nativeV = &v)
            {
                byte ret = ImGuiNative.igDragInt4(nativeLabel, nativeV, vSpeed, vMin, vMax, nativeFormat, flags);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeLabel);
                }
                
                if (formatByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeFormat);
                }
                
                return ret != 0;
            }
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
            byte* nativeLabel;
            int labelByteCount = 0;
            if (label != null)
            {
                labelByteCount = Encoding.UTF8.GetByteCount(label);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeLabel = Util.Allocate(labelByteCount + 1);
                }
                else
                {
                    byte* nativeLabelStackBytes = stackalloc byte[labelByteCount + 1];
                    nativeLabel = nativeLabelStackBytes;
                }
                
                int nativeLabelOffset = Util.GetUtf8(label, nativeLabel, labelByteCount);
                nativeLabel[nativeLabelOffset] = 0;
            }
            else
            {
                nativeLabel = null;
            }
            
            int vMin = 0;
            int vMax = 0;
            byte* nativeFormat;
            int formatByteCount = 0;
            formatByteCount = Encoding.UTF8.GetByteCount("%d");
            if (formatByteCount > Util.StackAllocationSizeLimit)
            {
                nativeFormat = Util.Allocate(formatByteCount + 1);
            }
            else
            {
                byte* nativeFormatStackBytes = stackalloc byte[formatByteCount + 1];
                nativeFormat = nativeFormatStackBytes;
            }
            
            int nativeFormatOffset = Util.GetUtf8("%d", nativeFormat, formatByteCount);
            nativeFormat[nativeFormatOffset] = 0;
            ImGuiSliderFlags flags = 0;
            fixed (int* nativeV = &v)
            {
                byte ret = ImGuiNative.igDragInt4(nativeLabel, nativeV, vSpeed, vMin, vMax, nativeFormat, flags);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeLabel);
                }
                
                if (formatByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeFormat);
                }
                
                return ret != 0;
            }
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
            byte* nativeLabel;
            int labelByteCount = 0;
            if (label != null)
            {
                labelByteCount = Encoding.UTF8.GetByteCount(label);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeLabel = Util.Allocate(labelByteCount + 1);
                }
                else
                {
                    byte* nativeLabelStackBytes = stackalloc byte[labelByteCount + 1];
                    nativeLabel = nativeLabelStackBytes;
                }
                
                int nativeLabelOffset = Util.GetUtf8(label, nativeLabel, labelByteCount);
                nativeLabel[nativeLabelOffset] = 0;
            }
            else
            {
                nativeLabel = null;
            }
            
            int vMax = 0;
            byte* nativeFormat;
            int formatByteCount = 0;
            formatByteCount = Encoding.UTF8.GetByteCount("%d");
            if (formatByteCount > Util.StackAllocationSizeLimit)
            {
                nativeFormat = Util.Allocate(formatByteCount + 1);
            }
            else
            {
                byte* nativeFormatStackBytes = stackalloc byte[formatByteCount + 1];
                nativeFormat = nativeFormatStackBytes;
            }
            
            int nativeFormatOffset = Util.GetUtf8("%d", nativeFormat, formatByteCount);
            nativeFormat[nativeFormatOffset] = 0;
            ImGuiSliderFlags flags = 0;
            fixed (int* nativeV = &v)
            {
                byte ret = ImGuiNative.igDragInt4(nativeLabel, nativeV, vSpeed, vMin, vMax, nativeFormat, flags);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeLabel);
                }
                
                if (formatByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeFormat);
                }
                
                return ret != 0;
            }
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
            byte* nativeLabel;
            int labelByteCount = 0;
            if (label != null)
            {
                labelByteCount = Encoding.UTF8.GetByteCount(label);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeLabel = Util.Allocate(labelByteCount + 1);
                }
                else
                {
                    byte* nativeLabelStackBytes = stackalloc byte[labelByteCount + 1];
                    nativeLabel = nativeLabelStackBytes;
                }
                
                int nativeLabelOffset = Util.GetUtf8(label, nativeLabel, labelByteCount);
                nativeLabel[nativeLabelOffset] = 0;
            }
            else
            {
                nativeLabel = null;
            }
            
            byte* nativeFormat;
            int formatByteCount = 0;
            formatByteCount = Encoding.UTF8.GetByteCount("%d");
            if (formatByteCount > Util.StackAllocationSizeLimit)
            {
                nativeFormat = Util.Allocate(formatByteCount + 1);
            }
            else
            {
                byte* nativeFormatStackBytes = stackalloc byte[formatByteCount + 1];
                nativeFormat = nativeFormatStackBytes;
            }
            
            int nativeFormatOffset = Util.GetUtf8("%d", nativeFormat, formatByteCount);
            nativeFormat[nativeFormatOffset] = 0;
            ImGuiSliderFlags flags = 0;
            fixed (int* nativeV = &v)
            {
                byte ret = ImGuiNative.igDragInt4(nativeLabel, nativeV, vSpeed, vMin, vMax, nativeFormat, flags);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeLabel);
                }
                
                if (formatByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeFormat);
                }
                
                return ret != 0;
            }
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
            byte* nativeLabel;
            int labelByteCount = 0;
            if (label != null)
            {
                labelByteCount = Encoding.UTF8.GetByteCount(label);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeLabel = Util.Allocate(labelByteCount + 1);
                }
                else
                {
                    byte* nativeLabelStackBytes = stackalloc byte[labelByteCount + 1];
                    nativeLabel = nativeLabelStackBytes;
                }
                
                int nativeLabelOffset = Util.GetUtf8(label, nativeLabel, labelByteCount);
                nativeLabel[nativeLabelOffset] = 0;
            }
            else
            {
                nativeLabel = null;
            }
            
            byte* nativeFormat;
            int formatByteCount = 0;
            if (format != null)
            {
                formatByteCount = Encoding.UTF8.GetByteCount(format);
                if (formatByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeFormat = Util.Allocate(formatByteCount + 1);
                }
                else
                {
                    byte* nativeFormatStackBytes = stackalloc byte[formatByteCount + 1];
                    nativeFormat = nativeFormatStackBytes;
                }
                
                int nativeFormatOffset = Util.GetUtf8(format, nativeFormat, formatByteCount);
                nativeFormat[nativeFormatOffset] = 0;
            }
            else
            {
                nativeFormat = null;
            }
            
            ImGuiSliderFlags flags = 0;
            fixed (int* nativeV = &v)
            {
                byte ret = ImGuiNative.igDragInt4(nativeLabel, nativeV, vSpeed, vMin, vMax, nativeFormat, flags);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeLabel);
                }
                
                if (formatByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeFormat);
                }
                
                return ret != 0;
            }
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
            byte* nativeLabel;
            int labelByteCount = 0;
            if (label != null)
            {
                labelByteCount = Encoding.UTF8.GetByteCount(label);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeLabel = Util.Allocate(labelByteCount + 1);
                }
                else
                {
                    byte* nativeLabelStackBytes = stackalloc byte[labelByteCount + 1];
                    nativeLabel = nativeLabelStackBytes;
                }
                
                int nativeLabelOffset = Util.GetUtf8(label, nativeLabel, labelByteCount);
                nativeLabel[nativeLabelOffset] = 0;
            }
            else
            {
                nativeLabel = null;
            }
            
            byte* nativeFormat;
            int formatByteCount = 0;
            if (format != null)
            {
                formatByteCount = Encoding.UTF8.GetByteCount(format);
                if (formatByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeFormat = Util.Allocate(formatByteCount + 1);
                }
                else
                {
                    byte* nativeFormatStackBytes = stackalloc byte[formatByteCount + 1];
                    nativeFormat = nativeFormatStackBytes;
                }
                
                int nativeFormatOffset = Util.GetUtf8(format, nativeFormat, formatByteCount);
                nativeFormat[nativeFormatOffset] = 0;
            }
            else
            {
                nativeFormat = null;
            }
            
            fixed (int* nativeV = &v)
            {
                byte ret = ImGuiNative.igDragInt4(nativeLabel, nativeV, vSpeed, vMin, vMax, nativeFormat, flags);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeLabel);
                }
                
                if (formatByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeFormat);
                }
                
                return ret != 0;
            }
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
            byte* nativeLabel;
            int labelByteCount = 0;
            if (label != null)
            {
                labelByteCount = Encoding.UTF8.GetByteCount(label);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeLabel = Util.Allocate(labelByteCount + 1);
                }
                else
                {
                    byte* nativeLabelStackBytes = stackalloc byte[labelByteCount + 1];
                    nativeLabel = nativeLabelStackBytes;
                }
                
                int nativeLabelOffset = Util.GetUtf8(label, nativeLabel, labelByteCount);
                nativeLabel[nativeLabelOffset] = 0;
            }
            else
            {
                nativeLabel = null;
            }
            
            float vSpeed = 1.0f;
            int vMin = 0;
            int vMax = 0;
            byte* nativeFormat;
            int formatByteCount = 0;
            formatByteCount = Encoding.UTF8.GetByteCount("%d");
            if (formatByteCount > Util.StackAllocationSizeLimit)
            {
                nativeFormat = Util.Allocate(formatByteCount + 1);
            }
            else
            {
                byte* nativeFormatStackBytes = stackalloc byte[formatByteCount + 1];
                nativeFormat = nativeFormatStackBytes;
            }
            
            int nativeFormatOffset = Util.GetUtf8("%d", nativeFormat, formatByteCount);
            nativeFormat[nativeFormatOffset] = 0;
            byte* nativeFormatMax = null;
            ImGuiSliderFlags flags = 0;
            fixed (int* nativeVCurrentMin = &vCurrentMin)
            {
                fixed (int* nativeVCurrentMax = &vCurrentMax)
                {
                    byte ret = ImGuiNative.igDragIntRange2(nativeLabel, nativeVCurrentMin, nativeVCurrentMax, vSpeed, vMin, vMax, nativeFormat, nativeFormatMax, flags);
                    if (labelByteCount > Util.StackAllocationSizeLimit)
                    {
                        Util.Free(nativeLabel);
                    }
                    
                    if (formatByteCount > Util.StackAllocationSizeLimit)
                    {
                        Util.Free(nativeFormat);
                    }
                    
                    return ret != 0;
                }
            }
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
            byte* nativeLabel;
            int labelByteCount = 0;
            if (label != null)
            {
                labelByteCount = Encoding.UTF8.GetByteCount(label);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeLabel = Util.Allocate(labelByteCount + 1);
                }
                else
                {
                    byte* nativeLabelStackBytes = stackalloc byte[labelByteCount + 1];
                    nativeLabel = nativeLabelStackBytes;
                }
                
                int nativeLabelOffset = Util.GetUtf8(label, nativeLabel, labelByteCount);
                nativeLabel[nativeLabelOffset] = 0;
            }
            else
            {
                nativeLabel = null;
            }
            
            int vMin = 0;
            int vMax = 0;
            byte* nativeFormat;
            int formatByteCount = 0;
            formatByteCount = Encoding.UTF8.GetByteCount("%d");
            if (formatByteCount > Util.StackAllocationSizeLimit)
            {
                nativeFormat = Util.Allocate(formatByteCount + 1);
            }
            else
            {
                byte* nativeFormatStackBytes = stackalloc byte[formatByteCount + 1];
                nativeFormat = nativeFormatStackBytes;
            }
            
            int nativeFormatOffset = Util.GetUtf8("%d", nativeFormat, formatByteCount);
            nativeFormat[nativeFormatOffset] = 0;
            byte* nativeFormatMax = null;
            ImGuiSliderFlags flags = 0;
            fixed (int* nativeVCurrentMin = &vCurrentMin)
            {
                fixed (int* nativeVCurrentMax = &vCurrentMax)
                {
                    byte ret = ImGuiNative.igDragIntRange2(nativeLabel, nativeVCurrentMin, nativeVCurrentMax, vSpeed, vMin, vMax, nativeFormat, nativeFormatMax, flags);
                    if (labelByteCount > Util.StackAllocationSizeLimit)
                    {
                        Util.Free(nativeLabel);
                    }
                    
                    if (formatByteCount > Util.StackAllocationSizeLimit)
                    {
                        Util.Free(nativeFormat);
                    }
                    
                    return ret != 0;
                }
            }
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
            byte* nativeLabel;
            int labelByteCount = 0;
            if (label != null)
            {
                labelByteCount = Encoding.UTF8.GetByteCount(label);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeLabel = Util.Allocate(labelByteCount + 1);
                }
                else
                {
                    byte* nativeLabelStackBytes = stackalloc byte[labelByteCount + 1];
                    nativeLabel = nativeLabelStackBytes;
                }
                
                int nativeLabelOffset = Util.GetUtf8(label, nativeLabel, labelByteCount);
                nativeLabel[nativeLabelOffset] = 0;
            }
            else
            {
                nativeLabel = null;
            }
            
            int vMax = 0;
            byte* nativeFormat;
            int formatByteCount = 0;
            formatByteCount = Encoding.UTF8.GetByteCount("%d");
            if (formatByteCount > Util.StackAllocationSizeLimit)
            {
                nativeFormat = Util.Allocate(formatByteCount + 1);
            }
            else
            {
                byte* nativeFormatStackBytes = stackalloc byte[formatByteCount + 1];
                nativeFormat = nativeFormatStackBytes;
            }
            
            int nativeFormatOffset = Util.GetUtf8("%d", nativeFormat, formatByteCount);
            nativeFormat[nativeFormatOffset] = 0;
            byte* nativeFormatMax = null;
            ImGuiSliderFlags flags = 0;
            fixed (int* nativeVCurrentMin = &vCurrentMin)
            {
                fixed (int* nativeVCurrentMax = &vCurrentMax)
                {
                    byte ret = ImGuiNative.igDragIntRange2(nativeLabel, nativeVCurrentMin, nativeVCurrentMax, vSpeed, vMin, vMax, nativeFormat, nativeFormatMax, flags);
                    if (labelByteCount > Util.StackAllocationSizeLimit)
                    {
                        Util.Free(nativeLabel);
                    }
                    
                    if (formatByteCount > Util.StackAllocationSizeLimit)
                    {
                        Util.Free(nativeFormat);
                    }
                    
                    return ret != 0;
                }
            }
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
            byte* nativeLabel;
            int labelByteCount = 0;
            if (label != null)
            {
                labelByteCount = Encoding.UTF8.GetByteCount(label);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeLabel = Util.Allocate(labelByteCount + 1);
                }
                else
                {
                    byte* nativeLabelStackBytes = stackalloc byte[labelByteCount + 1];
                    nativeLabel = nativeLabelStackBytes;
                }
                
                int nativeLabelOffset = Util.GetUtf8(label, nativeLabel, labelByteCount);
                nativeLabel[nativeLabelOffset] = 0;
            }
            else
            {
                nativeLabel = null;
            }
            
            byte* nativeFormat;
            int formatByteCount = 0;
            formatByteCount = Encoding.UTF8.GetByteCount("%d");
            if (formatByteCount > Util.StackAllocationSizeLimit)
            {
                nativeFormat = Util.Allocate(formatByteCount + 1);
            }
            else
            {
                byte* nativeFormatStackBytes = stackalloc byte[formatByteCount + 1];
                nativeFormat = nativeFormatStackBytes;
            }
            
            int nativeFormatOffset = Util.GetUtf8("%d", nativeFormat, formatByteCount);
            nativeFormat[nativeFormatOffset] = 0;
            byte* nativeFormatMax = null;
            ImGuiSliderFlags flags = 0;
            fixed (int* nativeVCurrentMin = &vCurrentMin)
            {
                fixed (int* nativeVCurrentMax = &vCurrentMax)
                {
                    byte ret = ImGuiNative.igDragIntRange2(nativeLabel, nativeVCurrentMin, nativeVCurrentMax, vSpeed, vMin, vMax, nativeFormat, nativeFormatMax, flags);
                    if (labelByteCount > Util.StackAllocationSizeLimit)
                    {
                        Util.Free(nativeLabel);
                    }
                    
                    if (formatByteCount > Util.StackAllocationSizeLimit)
                    {
                        Util.Free(nativeFormat);
                    }
                    
                    return ret != 0;
                }
            }
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
            byte* nativeLabel;
            int labelByteCount = 0;
            if (label != null)
            {
                labelByteCount = Encoding.UTF8.GetByteCount(label);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeLabel = Util.Allocate(labelByteCount + 1);
                }
                else
                {
                    byte* nativeLabelStackBytes = stackalloc byte[labelByteCount + 1];
                    nativeLabel = nativeLabelStackBytes;
                }
                
                int nativeLabelOffset = Util.GetUtf8(label, nativeLabel, labelByteCount);
                nativeLabel[nativeLabelOffset] = 0;
            }
            else
            {
                nativeLabel = null;
            }
            
            byte* nativeFormat;
            int formatByteCount = 0;
            if (format != null)
            {
                formatByteCount = Encoding.UTF8.GetByteCount(format);
                if (formatByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeFormat = Util.Allocate(formatByteCount + 1);
                }
                else
                {
                    byte* nativeFormatStackBytes = stackalloc byte[formatByteCount + 1];
                    nativeFormat = nativeFormatStackBytes;
                }
                
                int nativeFormatOffset = Util.GetUtf8(format, nativeFormat, formatByteCount);
                nativeFormat[nativeFormatOffset] = 0;
            }
            else
            {
                nativeFormat = null;
            }
            
            byte* nativeFormatMax = null;
            ImGuiSliderFlags flags = 0;
            fixed (int* nativeVCurrentMin = &vCurrentMin)
            {
                fixed (int* nativeVCurrentMax = &vCurrentMax)
                {
                    byte ret = ImGuiNative.igDragIntRange2(nativeLabel, nativeVCurrentMin, nativeVCurrentMax, vSpeed, vMin, vMax, nativeFormat, nativeFormatMax, flags);
                    if (labelByteCount > Util.StackAllocationSizeLimit)
                    {
                        Util.Free(nativeLabel);
                    }
                    
                    if (formatByteCount > Util.StackAllocationSizeLimit)
                    {
                        Util.Free(nativeFormat);
                    }
                    
                    return ret != 0;
                }
            }
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
            byte* nativeLabel;
            int labelByteCount = 0;
            if (label != null)
            {
                labelByteCount = Encoding.UTF8.GetByteCount(label);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeLabel = Util.Allocate(labelByteCount + 1);
                }
                else
                {
                    byte* nativeLabelStackBytes = stackalloc byte[labelByteCount + 1];
                    nativeLabel = nativeLabelStackBytes;
                }
                
                int nativeLabelOffset = Util.GetUtf8(label, nativeLabel, labelByteCount);
                nativeLabel[nativeLabelOffset] = 0;
            }
            else
            {
                nativeLabel = null;
            }
            
            byte* nativeFormat;
            int formatByteCount = 0;
            if (format != null)
            {
                formatByteCount = Encoding.UTF8.GetByteCount(format);
                if (formatByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeFormat = Util.Allocate(formatByteCount + 1);
                }
                else
                {
                    byte* nativeFormatStackBytes = stackalloc byte[formatByteCount + 1];
                    nativeFormat = nativeFormatStackBytes;
                }
                
                int nativeFormatOffset = Util.GetUtf8(format, nativeFormat, formatByteCount);
                nativeFormat[nativeFormatOffset] = 0;
            }
            else
            {
                nativeFormat = null;
            }
            
            byte* nativeFormatMax;
            int formatMaxByteCount = 0;
            if (formatMax != null)
            {
                formatMaxByteCount = Encoding.UTF8.GetByteCount(formatMax);
                if (formatMaxByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeFormatMax = Util.Allocate(formatMaxByteCount + 1);
                }
                else
                {
                    byte* nativeFormatMaxStackBytes = stackalloc byte[formatMaxByteCount + 1];
                    nativeFormatMax = nativeFormatMaxStackBytes;
                }
                
                int nativeFormatMaxOffset = Util.GetUtf8(formatMax, nativeFormatMax, formatMaxByteCount);
                nativeFormatMax[nativeFormatMaxOffset] = 0;
            }
            else
            {
                nativeFormatMax = null;
            }
            
            ImGuiSliderFlags flags = 0;
            fixed (int* nativeVCurrentMin = &vCurrentMin)
            {
                fixed (int* nativeVCurrentMax = &vCurrentMax)
                {
                    byte ret = ImGuiNative.igDragIntRange2(nativeLabel, nativeVCurrentMin, nativeVCurrentMax, vSpeed, vMin, vMax, nativeFormat, nativeFormatMax, flags);
                    if (labelByteCount > Util.StackAllocationSizeLimit)
                    {
                        Util.Free(nativeLabel);
                    }
                    
                    if (formatByteCount > Util.StackAllocationSizeLimit)
                    {
                        Util.Free(nativeFormat);
                    }
                    
                    if (formatMaxByteCount > Util.StackAllocationSizeLimit)
                    {
                        Util.Free(nativeFormatMax);
                    }
                    
                    return ret != 0;
                }
            }
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
            byte* nativeLabel;
            int labelByteCount = 0;
            if (label != null)
            {
                labelByteCount = Encoding.UTF8.GetByteCount(label);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeLabel = Util.Allocate(labelByteCount + 1);
                }
                else
                {
                    byte* nativeLabelStackBytes = stackalloc byte[labelByteCount + 1];
                    nativeLabel = nativeLabelStackBytes;
                }
                
                int nativeLabelOffset = Util.GetUtf8(label, nativeLabel, labelByteCount);
                nativeLabel[nativeLabelOffset] = 0;
            }
            else
            {
                nativeLabel = null;
            }
            
            byte* nativeFormat;
            int formatByteCount = 0;
            if (format != null)
            {
                formatByteCount = Encoding.UTF8.GetByteCount(format);
                if (formatByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeFormat = Util.Allocate(formatByteCount + 1);
                }
                else
                {
                    byte* nativeFormatStackBytes = stackalloc byte[formatByteCount + 1];
                    nativeFormat = nativeFormatStackBytes;
                }
                
                int nativeFormatOffset = Util.GetUtf8(format, nativeFormat, formatByteCount);
                nativeFormat[nativeFormatOffset] = 0;
            }
            else
            {
                nativeFormat = null;
            }
            
            byte* nativeFormatMax;
            int formatMaxByteCount = 0;
            if (formatMax != null)
            {
                formatMaxByteCount = Encoding.UTF8.GetByteCount(formatMax);
                if (formatMaxByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeFormatMax = Util.Allocate(formatMaxByteCount + 1);
                }
                else
                {
                    byte* nativeFormatMaxStackBytes = stackalloc byte[formatMaxByteCount + 1];
                    nativeFormatMax = nativeFormatMaxStackBytes;
                }
                
                int nativeFormatMaxOffset = Util.GetUtf8(formatMax, nativeFormatMax, formatMaxByteCount);
                nativeFormatMax[nativeFormatMaxOffset] = 0;
            }
            else
            {
                nativeFormatMax = null;
            }
            
            fixed (int* nativeVCurrentMin = &vCurrentMin)
            {
                fixed (int* nativeVCurrentMax = &vCurrentMax)
                {
                    byte ret = ImGuiNative.igDragIntRange2(nativeLabel, nativeVCurrentMin, nativeVCurrentMax, vSpeed, vMin, vMax, nativeFormat, nativeFormatMax, flags);
                    if (labelByteCount > Util.StackAllocationSizeLimit)
                    {
                        Util.Free(nativeLabel);
                    }
                    
                    if (formatByteCount > Util.StackAllocationSizeLimit)
                    {
                        Util.Free(nativeFormat);
                    }
                    
                    if (formatMaxByteCount > Util.StackAllocationSizeLimit)
                    {
                        Util.Free(nativeFormatMax);
                    }
                    
                    return ret != 0;
                }
            }
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
            byte* nativeLabel;
            int labelByteCount = 0;
            if (label != null)
            {
                labelByteCount = Encoding.UTF8.GetByteCount(label);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeLabel = Util.Allocate(labelByteCount + 1);
                }
                else
                {
                    byte* nativeLabelStackBytes = stackalloc byte[labelByteCount + 1];
                    nativeLabel = nativeLabelStackBytes;
                }
                
                int nativeLabelOffset = Util.GetUtf8(label, nativeLabel, labelByteCount);
                nativeLabel[nativeLabelOffset] = 0;
            }
            else
            {
                nativeLabel = null;
            }
            
            IntPtr nativePData = pData;
            float vSpeed = 1.0f;
            IntPtr pMin = IntPtr.Zero;
            IntPtr pMax = IntPtr.Zero;
            byte* nativeFormat = null;
            ImGuiSliderFlags flags = 0;
            byte ret = ImGuiNative.igDragScalar(nativeLabel, dataType, nativePData, vSpeed, pMin, pMax, nativeFormat, flags);
            if (labelByteCount > Util.StackAllocationSizeLimit)
            {
                Util.Free(nativeLabel);
            }
            
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
            byte* nativeLabel;
            int labelByteCount = 0;
            if (label != null)
            {
                labelByteCount = Encoding.UTF8.GetByteCount(label);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeLabel = Util.Allocate(labelByteCount + 1);
                }
                else
                {
                    byte* nativeLabelStackBytes = stackalloc byte[labelByteCount + 1];
                    nativeLabel = nativeLabelStackBytes;
                }
                
                int nativeLabelOffset = Util.GetUtf8(label, nativeLabel, labelByteCount);
                nativeLabel[nativeLabelOffset] = 0;
            }
            else
            {
                nativeLabel = null;
            }
            
            IntPtr nativePData = pData;
            IntPtr pMin = IntPtr.Zero;
            IntPtr pMax = IntPtr.Zero;
            byte* nativeFormat = null;
            ImGuiSliderFlags flags = 0;
            byte ret = ImGuiNative.igDragScalar(nativeLabel, dataType, nativePData, vSpeed, pMin, pMax, nativeFormat, flags);
            if (labelByteCount > Util.StackAllocationSizeLimit)
            {
                Util.Free(nativeLabel);
            }
            
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
            byte* nativeLabel;
            int labelByteCount = 0;
            if (label != null)
            {
                labelByteCount = Encoding.UTF8.GetByteCount(label);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeLabel = Util.Allocate(labelByteCount + 1);
                }
                else
                {
                    byte* nativeLabelStackBytes = stackalloc byte[labelByteCount + 1];
                    nativeLabel = nativeLabelStackBytes;
                }
                
                int nativeLabelOffset = Util.GetUtf8(label, nativeLabel, labelByteCount);
                nativeLabel[nativeLabelOffset] = 0;
            }
            else
            {
                nativeLabel = null;
            }
            
            IntPtr nativePData = pData;
            IntPtr nativePMin = pMin;
            IntPtr pMax = IntPtr.Zero;
            byte* nativeFormat = null;
            ImGuiSliderFlags flags = 0;
            byte ret = ImGuiNative.igDragScalar(nativeLabel, dataType, nativePData, vSpeed, nativePMin, pMax, nativeFormat, flags);
            if (labelByteCount > Util.StackAllocationSizeLimit)
            {
                Util.Free(nativeLabel);
            }
            
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
            byte* nativeLabel;
            int labelByteCount = 0;
            if (label != null)
            {
                labelByteCount = Encoding.UTF8.GetByteCount(label);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeLabel = Util.Allocate(labelByteCount + 1);
                }
                else
                {
                    byte* nativeLabelStackBytes = stackalloc byte[labelByteCount + 1];
                    nativeLabel = nativeLabelStackBytes;
                }
                
                int nativeLabelOffset = Util.GetUtf8(label, nativeLabel, labelByteCount);
                nativeLabel[nativeLabelOffset] = 0;
            }
            else
            {
                nativeLabel = null;
            }
            
            IntPtr nativePData = pData;
            IntPtr nativePMin = pMin;
            IntPtr nativePMax = pMax;
            byte* nativeFormat = null;
            ImGuiSliderFlags flags = 0;
            byte ret = ImGuiNative.igDragScalar(nativeLabel, dataType, nativePData, vSpeed, nativePMin, nativePMax, nativeFormat, flags);
            if (labelByteCount > Util.StackAllocationSizeLimit)
            {
                Util.Free(nativeLabel);
            }
            
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
            byte* nativeLabel;
            int labelByteCount = 0;
            if (label != null)
            {
                labelByteCount = Encoding.UTF8.GetByteCount(label);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeLabel = Util.Allocate(labelByteCount + 1);
                }
                else
                {
                    byte* nativeLabelStackBytes = stackalloc byte[labelByteCount + 1];
                    nativeLabel = nativeLabelStackBytes;
                }
                
                int nativeLabelOffset = Util.GetUtf8(label, nativeLabel, labelByteCount);
                nativeLabel[nativeLabelOffset] = 0;
            }
            else
            {
                nativeLabel = null;
            }
            
            IntPtr nativePData = pData;
            IntPtr nativePMin = pMin;
            IntPtr nativePMax = pMax;
            byte* nativeFormat;
            int formatByteCount = 0;
            if (format != null)
            {
                formatByteCount = Encoding.UTF8.GetByteCount(format);
                if (formatByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeFormat = Util.Allocate(formatByteCount + 1);
                }
                else
                {
                    byte* nativeFormatStackBytes = stackalloc byte[formatByteCount + 1];
                    nativeFormat = nativeFormatStackBytes;
                }
                
                int nativeFormatOffset = Util.GetUtf8(format, nativeFormat, formatByteCount);
                nativeFormat[nativeFormatOffset] = 0;
            }
            else
            {
                nativeFormat = null;
            }
            
            ImGuiSliderFlags flags = 0;
            byte ret = ImGuiNative.igDragScalar(nativeLabel, dataType, nativePData, vSpeed, nativePMin, nativePMax, nativeFormat, flags);
            if (labelByteCount > Util.StackAllocationSizeLimit)
            {
                Util.Free(nativeLabel);
            }
            
            if (formatByteCount > Util.StackAllocationSizeLimit)
            {
                Util.Free(nativeFormat);
            }
            
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
            byte* nativeLabel;
            int labelByteCount = 0;
            if (label != null)
            {
                labelByteCount = Encoding.UTF8.GetByteCount(label);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeLabel = Util.Allocate(labelByteCount + 1);
                }
                else
                {
                    byte* nativeLabelStackBytes = stackalloc byte[labelByteCount + 1];
                    nativeLabel = nativeLabelStackBytes;
                }
                
                int nativeLabelOffset = Util.GetUtf8(label, nativeLabel, labelByteCount);
                nativeLabel[nativeLabelOffset] = 0;
            }
            else
            {
                nativeLabel = null;
            }
            
            IntPtr nativePData = pData;
            IntPtr nativePMin = pMin;
            IntPtr nativePMax = pMax;
            byte* nativeFormat;
            int formatByteCount = 0;
            if (format != null)
            {
                formatByteCount = Encoding.UTF8.GetByteCount(format);
                if (formatByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeFormat = Util.Allocate(formatByteCount + 1);
                }
                else
                {
                    byte* nativeFormatStackBytes = stackalloc byte[formatByteCount + 1];
                    nativeFormat = nativeFormatStackBytes;
                }
                
                int nativeFormatOffset = Util.GetUtf8(format, nativeFormat, formatByteCount);
                nativeFormat[nativeFormatOffset] = 0;
            }
            else
            {
                nativeFormat = null;
            }
            
            byte ret = ImGuiNative.igDragScalar(nativeLabel, dataType, nativePData, vSpeed, nativePMin, nativePMax, nativeFormat, flags);
            if (labelByteCount > Util.StackAllocationSizeLimit)
            {
                Util.Free(nativeLabel);
            }
            
            if (formatByteCount > Util.StackAllocationSizeLimit)
            {
                Util.Free(nativeFormat);
            }
            
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
            byte* nativeLabel;
            int labelByteCount = 0;
            if (label != null)
            {
                labelByteCount = Encoding.UTF8.GetByteCount(label);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeLabel = Util.Allocate(labelByteCount + 1);
                }
                else
                {
                    byte* nativeLabelStackBytes = stackalloc byte[labelByteCount + 1];
                    nativeLabel = nativeLabelStackBytes;
                }
                
                int nativeLabelOffset = Util.GetUtf8(label, nativeLabel, labelByteCount);
                nativeLabel[nativeLabelOffset] = 0;
            }
            else
            {
                nativeLabel = null;
            }
            
            IntPtr nativePData = pData;
            float vSpeed = 1.0f;
            IntPtr pMin = IntPtr.Zero;
            IntPtr pMax = IntPtr.Zero;
            byte* nativeFormat = null;
            ImGuiSliderFlags flags = 0;
            byte ret = ImGuiNative.igDragScalarN(nativeLabel, dataType, nativePData, components, vSpeed, pMin, pMax, nativeFormat, flags);
            if (labelByteCount > Util.StackAllocationSizeLimit)
            {
                Util.Free(nativeLabel);
            }
            
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
            byte* nativeLabel;
            int labelByteCount = 0;
            if (label != null)
            {
                labelByteCount = Encoding.UTF8.GetByteCount(label);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeLabel = Util.Allocate(labelByteCount + 1);
                }
                else
                {
                    byte* nativeLabelStackBytes = stackalloc byte[labelByteCount + 1];
                    nativeLabel = nativeLabelStackBytes;
                }
                
                int nativeLabelOffset = Util.GetUtf8(label, nativeLabel, labelByteCount);
                nativeLabel[nativeLabelOffset] = 0;
            }
            else
            {
                nativeLabel = null;
            }
            
            IntPtr nativePData = pData;
            IntPtr pMin = IntPtr.Zero;
            IntPtr pMax = IntPtr.Zero;
            byte* nativeFormat = null;
            ImGuiSliderFlags flags = 0;
            byte ret = ImGuiNative.igDragScalarN(nativeLabel, dataType, nativePData, components, vSpeed, pMin, pMax, nativeFormat, flags);
            if (labelByteCount > Util.StackAllocationSizeLimit)
            {
                Util.Free(nativeLabel);
            }
            
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
            byte* nativeLabel;
            int labelByteCount = 0;
            if (label != null)
            {
                labelByteCount = Encoding.UTF8.GetByteCount(label);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeLabel = Util.Allocate(labelByteCount + 1);
                }
                else
                {
                    byte* nativeLabelStackBytes = stackalloc byte[labelByteCount + 1];
                    nativeLabel = nativeLabelStackBytes;
                }
                
                int nativeLabelOffset = Util.GetUtf8(label, nativeLabel, labelByteCount);
                nativeLabel[nativeLabelOffset] = 0;
            }
            else
            {
                nativeLabel = null;
            }
            
            IntPtr nativePData = pData;
            IntPtr nativePMin = pMin;
            IntPtr pMax = IntPtr.Zero;
            byte* nativeFormat = null;
            ImGuiSliderFlags flags = 0;
            byte ret = ImGuiNative.igDragScalarN(nativeLabel, dataType, nativePData, components, vSpeed, nativePMin, pMax, nativeFormat, flags);
            if (labelByteCount > Util.StackAllocationSizeLimit)
            {
                Util.Free(nativeLabel);
            }
            
            return ret != 0;
        }
    }
}