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
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using Alis.Core.Aspect.Data.Dll;
using Alis.Core.Aspect.Math.Vector;
using Alis.Extension.Graphic.ImGui.Properties;
using Alis.Extension.Graphic.ImGui.Utils;

namespace Alis.Extension.Graphic.ImGui
{
    public static unsafe partial class ImGui
    {
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
                byte ret = ImGuiNative.igSliderInt2(nativeLabel, nativeV, vMin, vMax, nativeFormat, flags);
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
                byte ret = ImGuiNative.igSliderInt2(nativeLabel, nativeV, vMin, vMax, nativeFormat, flags);
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
        ///     Describes whether slider int 3
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="v">The </param>
        /// <param name="vMin">The min</param>
        /// <param name="vMax">The max</param>
        /// <returns>The bool</returns>
        public static bool SliderInt3(string label, ref int v, int vMin, int vMax)
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
                byte ret = ImGuiNative.igSliderInt3(nativeLabel, nativeV, vMin, vMax, nativeFormat, flags);
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
                byte ret = ImGuiNative.igSliderInt3(nativeLabel, nativeV, vMin, vMax, nativeFormat, flags);
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
                byte ret = ImGuiNative.igSliderInt3(nativeLabel, nativeV, vMin, vMax, nativeFormat, flags);
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
        ///     Describes whether slider int 4
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="v">The </param>
        /// <param name="vMin">The min</param>
        /// <param name="vMax">The max</param>
        /// <returns>The bool</returns>
        public static bool SliderInt4(string label, ref int v, int vMin, int vMax)
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
                byte ret = ImGuiNative.igSliderInt4(nativeLabel, nativeV, vMin, vMax, nativeFormat, flags);
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
                byte ret = ImGuiNative.igSliderInt4(nativeLabel, nativeV, vMin, vMax, nativeFormat, flags);
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
                byte ret = ImGuiNative.igSliderInt4(nativeLabel, nativeV, vMin, vMax, nativeFormat, flags);
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
            byte ret = ImGuiNative.igSliderScalar(nativeLabel, dataType, nativePData, nativePMin, nativePMax, nativeFormat, flags);
            if (labelByteCount > Util.StackAllocationSizeLimit)
            {
                Util.Free(nativeLabel);
            }
            
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
            byte ret = ImGuiNative.igSliderScalar(nativeLabel, dataType, nativePData, nativePMin, nativePMax, nativeFormat, flags);
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
            
            byte ret = ImGuiNative.igSliderScalar(nativeLabel, dataType, nativePData, nativePMin, nativePMax, nativeFormat, flags);
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
            byte ret = ImGuiNative.igSliderScalarN(nativeLabel, dataType, nativePData, components, nativePMin, nativePMax, nativeFormat, flags);
            if (labelByteCount > Util.StackAllocationSizeLimit)
            {
                Util.Free(nativeLabel);
            }
            
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
            byte ret = ImGuiNative.igSliderScalarN(nativeLabel, dataType, nativePData, components, nativePMin, nativePMax, nativeFormat, flags);
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
            
            byte ret = ImGuiNative.igSliderScalarN(nativeLabel, dataType, nativePData, components, nativePMin, nativePMax, nativeFormat, flags);
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
        ///     Describes whether small button
        /// </summary>
        /// <param name="label">The label</param>
        /// <returns>The bool</returns>
        public static bool SmallButton(string label)
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
            
            byte ret = ImGuiNative.igSmallButton(nativeLabel);
            if (labelByteCount > Util.StackAllocationSizeLimit)
            {
                Util.Free(nativeLabel);
            }
            
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
            
            ImGuiTabItemFlags flags = 0;
            byte ret = ImGuiNative.igTabItemButton(nativeLabel, flags);
            if (labelByteCount > Util.StackAllocationSizeLimit)
            {
                Util.Free(nativeLabel);
            }
            
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
            
            byte ret = ImGuiNative.igTabItemButton(nativeLabel, flags);
            if (labelByteCount > Util.StackAllocationSizeLimit)
            {
                Util.Free(nativeLabel);
            }
            
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
            byte* ret = ImGuiNative.igTableGetColumnName_Int(columnN);
            return Util.StringFromPtr(ret);
        }
        
        /// <summary>
        ///     Tables the get column name using the specified column n
        /// </summary>
        /// <param name="columnN">The column</param>
        /// <returns>The string</returns>
        public static string TableGetColumnName(int columnN)
        {
            byte* ret = ImGuiNative.igTableGetColumnName_Int(columnN);
            return Util.StringFromPtr(ret);
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
            
            ImGuiNative.igTableHeader(nativeLabel);
            if (labelByteCount > Util.StackAllocationSizeLimit)
            {
                Util.Free(nativeLabel);
            }
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
            
            ImGuiTableColumnFlags flags = 0;
            float initWidthOrWeight = 0.0f;
            uint userId = 0;
            ImGuiNative.igTableSetupColumn(nativeLabel, flags, initWidthOrWeight, userId);
            if (labelByteCount > Util.StackAllocationSizeLimit)
            {
                Util.Free(nativeLabel);
            }
        }
        
        /// <summary>
        ///     Tables the setup column using the specified label
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="flags">The flags</param>
        public static void TableSetupColumn(string label, ImGuiTableColumnFlags flags)
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
            
            float initWidthOrWeight = 0.0f;
            uint userId = 0;
            ImGuiNative.igTableSetupColumn(nativeLabel, flags, initWidthOrWeight, userId);
            if (labelByteCount > Util.StackAllocationSizeLimit)
            {
                Util.Free(nativeLabel);
            }
        }
        
        /// <summary>
        ///     Tables the setup column using the specified label
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="flags">The flags</param>
        /// <param name="initWidthOrWeight">The init width or weight</param>
        public static void TableSetupColumn(string label, ImGuiTableColumnFlags flags, float initWidthOrWeight)
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
            
            uint userId = 0;
            ImGuiNative.igTableSetupColumn(nativeLabel, flags, initWidthOrWeight, userId);
            if (labelByteCount > Util.StackAllocationSizeLimit)
            {
                Util.Free(nativeLabel);
            }
        }
        
        /// <summary>
        ///     Tables the setup column using the specified label
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="flags">The flags</param>
        /// <param name="initWidthOrWeight">The init width or weight</param>
        /// <param name="userId">The user id</param>
        public static void TableSetupColumn(string label, ImGuiTableColumnFlags flags, float initWidthOrWeight, uint userId)
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
            
            ImGuiNative.igTableSetupColumn(nativeLabel, flags, initWidthOrWeight, userId);
            if (labelByteCount > Util.StackAllocationSizeLimit)
            {
                Util.Free(nativeLabel);
            }
        }
        
        /// <summary>
        ///     Tables the setup scroll freeze using the specified cols
        /// </summary>
        /// <param name="cols">The cols</param>
        /// <param name="rows">The rows</param>
        public static void TableSetupScrollFreeze(int cols, int rows)
        {
            ImGuiNative.igTableSetupScrollFreeze(cols, rows);
        }
        
        /// <summary>
        ///     Texts the fmt
        /// </summary>
        /// <param name="fmt">The fmt</param>
        public static void Text(string fmt)
        {
            byte* nativeFmt;
            int fmtByteCount = 0;
            if (fmt != null)
            {
                fmtByteCount = Encoding.UTF8.GetByteCount(fmt);
                if (fmtByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeFmt = Util.Allocate(fmtByteCount + 1);
                }
                else
                {
                    byte* nativeFmtStackBytes = stackalloc byte[fmtByteCount + 1];
                    nativeFmt = nativeFmtStackBytes;
                }
                
                int nativeFmtOffset = Util.GetUtf8(fmt, nativeFmt, fmtByteCount);
                nativeFmt[nativeFmtOffset] = 0;
            }
            else
            {
                nativeFmt = null;
            }
            
            ImGuiNative.igText(nativeFmt);
            if (fmtByteCount > Util.StackAllocationSizeLimit)
            {
                Util.Free(nativeFmt);
            }
        }
        
        /// <summary>
        ///     Texts the colored using the specified col
        /// </summary>
        /// <param name="col">The col</param>
        /// <param name="fmt">The fmt</param>
        public static void TextColored(Vector4 col, string fmt)
        {
            byte* nativeFmt;
            int fmtByteCount = 0;
            if (fmt != null)
            {
                fmtByteCount = Encoding.UTF8.GetByteCount(fmt);
                if (fmtByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeFmt = Util.Allocate(fmtByteCount + 1);
                }
                else
                {
                    byte* nativeFmtStackBytes = stackalloc byte[fmtByteCount + 1];
                    nativeFmt = nativeFmtStackBytes;
                }
                
                int nativeFmtOffset = Util.GetUtf8(fmt, nativeFmt, fmtByteCount);
                nativeFmt[nativeFmtOffset] = 0;
            }
            else
            {
                nativeFmt = null;
            }
            
            ImGuiNative.igTextColored(col, nativeFmt);
            if (fmtByteCount > Util.StackAllocationSizeLimit)
            {
                Util.Free(nativeFmt);
            }
        }
        
        /// <summary>
        ///     Texts the disabled using the specified fmt
        /// </summary>
        /// <param name="fmt">The fmt</param>
        public static void TextDisabled(string fmt)
        {
            byte* nativeFmt;
            int fmtByteCount = 0;
            if (fmt != null)
            {
                fmtByteCount = Encoding.UTF8.GetByteCount(fmt);
                if (fmtByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeFmt = Util.Allocate(fmtByteCount + 1);
                }
                else
                {
                    byte* nativeFmtStackBytes = stackalloc byte[fmtByteCount + 1];
                    nativeFmt = nativeFmtStackBytes;
                }
                
                int nativeFmtOffset = Util.GetUtf8(fmt, nativeFmt, fmtByteCount);
                nativeFmt[nativeFmtOffset] = 0;
            }
            else
            {
                nativeFmt = null;
            }
            
            ImGuiNative.igTextDisabled(nativeFmt);
            if (fmtByteCount > Util.StackAllocationSizeLimit)
            {
                Util.Free(nativeFmt);
            }
        }
        
        /// <summary>
        ///     Texts the unformatted using the specified text
        /// </summary>
        /// <param name="text">The text</param>
        public static void TextUnformatted(string text)
        {
            byte* nativeText;
            int textByteCount = 0;
            if (text != null)
            {
                textByteCount = Encoding.UTF8.GetByteCount(text);
                if (textByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeText = Util.Allocate(textByteCount + 1);
                }
                else
                {
                    byte* nativeTextStackBytes = stackalloc byte[textByteCount + 1];
                    nativeText = nativeTextStackBytes;
                }
                
                int nativeTextOffset = Util.GetUtf8(text, nativeText, textByteCount);
                nativeText[nativeTextOffset] = 0;
            }
            else
            {
                nativeText = null;
            }
            
            byte* nativeTextEnd = null;
            ImGuiNative.igTextUnformatted(nativeText, nativeTextEnd);
            if (textByteCount > Util.StackAllocationSizeLimit)
            {
                Util.Free(nativeText);
            }
        }
        
        /// <summary>
        ///     Texts the wrapped using the specified fmt
        /// </summary>
        /// <param name="fmt">The fmt</param>
        public static void TextWrapped(string fmt)
        {
            byte* nativeFmt;
            int fmtByteCount = 0;
            if (fmt != null)
            {
                fmtByteCount = Encoding.UTF8.GetByteCount(fmt);
                if (fmtByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeFmt = Util.Allocate(fmtByteCount + 1);
                }
                else
                {
                    byte* nativeFmtStackBytes = stackalloc byte[fmtByteCount + 1];
                    nativeFmt = nativeFmtStackBytes;
                }
                
                int nativeFmtOffset = Util.GetUtf8(fmt, nativeFmt, fmtByteCount);
                nativeFmt[nativeFmtOffset] = 0;
            }
            else
            {
                nativeFmt = null;
            }
            
            ImGuiNative.igTextWrapped(nativeFmt);
            if (fmtByteCount > Util.StackAllocationSizeLimit)
            {
                Util.Free(nativeFmt);
            }
        }
        
        /// <summary>
        ///     Describes whether tree node
        /// </summary>
        /// <param name="label">The label</param>
        /// <returns>The bool</returns>
        public static bool TreeNode(string label)
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
            
            byte ret = ImGuiNative.igTreeNode_Str(nativeLabel);
            if (labelByteCount > Util.StackAllocationSizeLimit)
            {
                Util.Free(nativeLabel);
            }
            
            return ret != 0;
        }
        
        /// <summary>
        ///     Describes whether tree node
        /// </summary>
        /// <param name="strId">The str id</param>
        /// <param name="fmt">The fmt</param>
        /// <returns>The bool</returns>
        public static bool TreeNode(string strId, string fmt)
        {
            byte* nativeStrId;
            int strIdByteCount = 0;
            if (strId != null)
            {
                strIdByteCount = Encoding.UTF8.GetByteCount(strId);
                if (strIdByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeStrId = Util.Allocate(strIdByteCount + 1);
                }
                else
                {
                    byte* nativeStrIdStackBytes = stackalloc byte[strIdByteCount + 1];
                    nativeStrId = nativeStrIdStackBytes;
                }
                
                int nativeStrIdOffset = Util.GetUtf8(strId, nativeStrId, strIdByteCount);
                nativeStrId[nativeStrIdOffset] = 0;
            }
            else
            {
                nativeStrId = null;
            }
            
            byte* nativeFmt;
            int fmtByteCount = 0;
            if (fmt != null)
            {
                fmtByteCount = Encoding.UTF8.GetByteCount(fmt);
                if (fmtByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeFmt = Util.Allocate(fmtByteCount + 1);
                }
                else
                {
                    byte* nativeFmtStackBytes = stackalloc byte[fmtByteCount + 1];
                    nativeFmt = nativeFmtStackBytes;
                }
                
                int nativeFmtOffset = Util.GetUtf8(fmt, nativeFmt, fmtByteCount);
                nativeFmt[nativeFmtOffset] = 0;
            }
            else
            {
                nativeFmt = null;
            }
            
            byte ret = ImGuiNative.igTreeNode_StrStr(nativeStrId, nativeFmt);
            if (strIdByteCount > Util.StackAllocationSizeLimit)
            {
                Util.Free(nativeStrId);
            }
            
            if (fmtByteCount > Util.StackAllocationSizeLimit)
            {
                Util.Free(nativeFmt);
            }
            
            return ret != 0;
        }
        
        /// <summary>
        ///     Describes whether tree node
        /// </summary>
        /// <param name="ptrId">The ptr id</param>
        /// <param name="fmt">The fmt</param>
        /// <returns>The bool</returns>
        public static bool TreeNode(IntPtr ptrId, string fmt)
        {
            IntPtr nativePtrId = ptrId;
            byte* nativeFmt;
            int fmtByteCount = 0;
            if (fmt != null)
            {
                fmtByteCount = Encoding.UTF8.GetByteCount(fmt);
                if (fmtByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeFmt = Util.Allocate(fmtByteCount + 1);
                }
                else
                {
                    byte* nativeFmtStackBytes = stackalloc byte[fmtByteCount + 1];
                    nativeFmt = nativeFmtStackBytes;
                }
                
                int nativeFmtOffset = Util.GetUtf8(fmt, nativeFmt, fmtByteCount);
                nativeFmt[nativeFmtOffset] = 0;
            }
            else
            {
                nativeFmt = null;
            }
            
            byte ret = ImGuiNative.igTreeNode_Ptr(nativePtrId, nativeFmt);
            if (fmtByteCount > Util.StackAllocationSizeLimit)
            {
                Util.Free(nativeFmt);
            }
            
            return ret != 0;
        }
        
        /// <summary>
        ///     Describes whether tree node ex
        /// </summary>
        /// <param name="label">The label</param>
        /// <returns>The bool</returns>
        public static bool TreeNodeEx(string label)
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
            
            ImGuiTreeNodeFlags flags = 0;
            byte ret = ImGuiNative.igTreeNodeEx_Str(nativeLabel, flags);
            if (labelByteCount > Util.StackAllocationSizeLimit)
            {
                Util.Free(nativeLabel);
            }
            
            return ret != 0;
        }
        
        /// <summary>
        ///     Describes whether tree node ex
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="flags">The flags</param>
        /// <returns>The bool</returns>
        public static bool TreeNodeEx(string label, ImGuiTreeNodeFlags flags)
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
            
            byte ret = ImGuiNative.igTreeNodeEx_Str(nativeLabel, flags);
            if (labelByteCount > Util.StackAllocationSizeLimit)
            {
                Util.Free(nativeLabel);
            }
            
            return ret != 0;
        }
        
        /// <summary>
        ///     Describes whether tree node ex
        /// </summary>
        /// <param name="strId">The str id</param>
        /// <param name="flags">The flags</param>
        /// <param name="fmt">The fmt</param>
        /// <returns>The bool</returns>
        public static bool TreeNodeEx(string strId, ImGuiTreeNodeFlags flags, string fmt)
        {
            byte* nativeStrId;
            int strIdByteCount = 0;
            if (strId != null)
            {
                strIdByteCount = Encoding.UTF8.GetByteCount(strId);
                if (strIdByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeStrId = Util.Allocate(strIdByteCount + 1);
                }
                else
                {
                    byte* nativeStrIdStackBytes = stackalloc byte[strIdByteCount + 1];
                    nativeStrId = nativeStrIdStackBytes;
                }
                
                int nativeStrIdOffset = Util.GetUtf8(strId, nativeStrId, strIdByteCount);
                nativeStrId[nativeStrIdOffset] = 0;
            }
            else
            {
                nativeStrId = null;
            }
            
            byte* nativeFmt;
            int fmtByteCount = 0;
            if (fmt != null)
            {
                fmtByteCount = Encoding.UTF8.GetByteCount(fmt);
                if (fmtByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeFmt = Util.Allocate(fmtByteCount + 1);
                }
                else
                {
                    byte* nativeFmtStackBytes = stackalloc byte[fmtByteCount + 1];
                    nativeFmt = nativeFmtStackBytes;
                }
                
                int nativeFmtOffset = Util.GetUtf8(fmt, nativeFmt, fmtByteCount);
                nativeFmt[nativeFmtOffset] = 0;
            }
            else
            {
                nativeFmt = null;
            }
            
            byte ret = ImGuiNative.igTreeNodeEx_StrStr(nativeStrId, flags, nativeFmt);
            if (strIdByteCount > Util.StackAllocationSizeLimit)
            {
                Util.Free(nativeStrId);
            }
            
            if (fmtByteCount > Util.StackAllocationSizeLimit)
            {
                Util.Free(nativeFmt);
            }
            
            return ret != 0;
        }
        
        /// <summary>
        ///     Describes whether tree node ex
        /// </summary>
        /// <param name="ptrId">The ptr id</param>
        /// <param name="flags">The flags</param>
        /// <param name="fmt">The fmt</param>
        /// <returns>The bool</returns>
        public static bool TreeNodeEx(IntPtr ptrId, ImGuiTreeNodeFlags flags, string fmt)
        {
            IntPtr nativePtrId = ptrId;
            byte* nativeFmt;
            int fmtByteCount = 0;
            if (fmt != null)
            {
                fmtByteCount = Encoding.UTF8.GetByteCount(fmt);
                if (fmtByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeFmt = Util.Allocate(fmtByteCount + 1);
                }
                else
                {
                    byte* nativeFmtStackBytes = stackalloc byte[fmtByteCount + 1];
                    nativeFmt = nativeFmtStackBytes;
                }
                
                int nativeFmtOffset = Util.GetUtf8(fmt, nativeFmt, fmtByteCount);
                nativeFmt[nativeFmtOffset] = 0;
            }
            else
            {
                nativeFmt = null;
            }
            
            byte ret = ImGuiNative.igTreeNodeEx_Ptr(nativePtrId, flags, nativeFmt);
            if (fmtByteCount > Util.StackAllocationSizeLimit)
            {
                Util.Free(nativeFmt);
            }
            
            return ret != 0;
        }
        
        /// <summary>
        ///     Trees the pop
        /// </summary>
        public static void TreePop()
        {
            ImGuiNative.igTreePop();
        }
        
        /// <summary>
        ///     Trees the push using the specified str id
        /// </summary>
        /// <param name="strId">The str id</param>
        public static void TreePush(string strId)
        {
            byte* nativeStrId;
            int strIdByteCount = 0;
            if (strId != null)
            {
                strIdByteCount = Encoding.UTF8.GetByteCount(strId);
                if (strIdByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeStrId = Util.Allocate(strIdByteCount + 1);
                }
                else
                {
                    byte* nativeStrIdStackBytes = stackalloc byte[strIdByteCount + 1];
                    nativeStrId = nativeStrIdStackBytes;
                }
                
                int nativeStrIdOffset = Util.GetUtf8(strId, nativeStrId, strIdByteCount);
                nativeStrId[nativeStrIdOffset] = 0;
            }
            else
            {
                nativeStrId = null;
            }
            
            ImGuiNative.igTreePush_Str(nativeStrId);
            if (strIdByteCount > Util.StackAllocationSizeLimit)
            {
                Util.Free(nativeStrId);
            }
        }
        
        /// <summary>
        ///     Trees the push using the specified ptr id
        /// </summary>
        /// <param name="ptrId">The ptr id</param>
        public static void TreePush(IntPtr ptrId)
        {
            IntPtr nativePtrId = ptrId;
            ImGuiNative.igTreePush_Ptr(nativePtrId);
        }
        
        /// <summary>
        ///     Unindents
        /// </summary>
        public static void Unindent()
        {
            float indentW = 0.0f;
            ImGuiNative.igUnindent(indentW);
        }
        
        /// <summary>
        ///     Unindents the indent w
        /// </summary>
        /// <param name="indentW">The indent</param>
        public static void Unindent(float indentW)
        {
            ImGuiNative.igUnindent(indentW);
        }
        
        /// <summary>
        ///     Updates the platform windows
        /// </summary>
        public static void UpdatePlatformWindows()
        {
            ImGuiNative.igUpdatePlatformWindows();
        }
        
        /// <summary>
        ///     Values the prefix
        /// </summary>
        /// <param name="prefix">The prefix</param>
        /// <param name="b">The </param>
        public static void Value(string prefix, bool b)
        {
            byte* nativePrefix;
            int prefixByteCount = 0;
            if (prefix != null)
            {
                prefixByteCount = Encoding.UTF8.GetByteCount(prefix);
                if (prefixByteCount > Util.StackAllocationSizeLimit)
                {
                    nativePrefix = Util.Allocate(prefixByteCount + 1);
                }
                else
                {
                    byte* nativePrefixStackBytes = stackalloc byte[prefixByteCount + 1];
                    nativePrefix = nativePrefixStackBytes;
                }
                
                int nativePrefixOffset = Util.GetUtf8(prefix, nativePrefix, prefixByteCount);
                nativePrefix[nativePrefixOffset] = 0;
            }
            else
            {
                nativePrefix = null;
            }
            
            byte nativeB = b ? (byte) 1 : (byte) 0;
            ImGuiNative.igValue_Bool(nativePrefix, nativeB);
            if (prefixByteCount > Util.StackAllocationSizeLimit)
            {
                Util.Free(nativePrefix);
            }
        }
        
        /// <summary>
        ///     Values the prefix
        /// </summary>
        /// <param name="prefix">The prefix</param>
        /// <param name="v">The </param>
        public static void Value(string prefix, int v)
        {
            byte* nativePrefix;
            int prefixByteCount = 0;
            if (prefix != null)
            {
                prefixByteCount = Encoding.UTF8.GetByteCount(prefix);
                if (prefixByteCount > Util.StackAllocationSizeLimit)
                {
                    nativePrefix = Util.Allocate(prefixByteCount + 1);
                }
                else
                {
                    byte* nativePrefixStackBytes = stackalloc byte[prefixByteCount + 1];
                    nativePrefix = nativePrefixStackBytes;
                }
                
                int nativePrefixOffset = Util.GetUtf8(prefix, nativePrefix, prefixByteCount);
                nativePrefix[nativePrefixOffset] = 0;
            }
            else
            {
                nativePrefix = null;
            }
            
            ImGuiNative.igValue_Int(nativePrefix, v);
            if (prefixByteCount > Util.StackAllocationSizeLimit)
            {
                Util.Free(nativePrefix);
            }
        }
        
        /// <summary>
        ///     Values the prefix
        /// </summary>
        /// <param name="prefix">The prefix</param>
        /// <param name="v">The </param>
        public static void Value(string prefix, uint v)
        {
            byte* nativePrefix;
            int prefixByteCount = 0;
            if (prefix != null)
            {
                prefixByteCount = Encoding.UTF8.GetByteCount(prefix);
                if (prefixByteCount > Util.StackAllocationSizeLimit)
                {
                    nativePrefix = Util.Allocate(prefixByteCount + 1);
                }
                else
                {
                    byte* nativePrefixStackBytes = stackalloc byte[prefixByteCount + 1];
                    nativePrefix = nativePrefixStackBytes;
                }
                
                int nativePrefixOffset = Util.GetUtf8(prefix, nativePrefix, prefixByteCount);
                nativePrefix[nativePrefixOffset] = 0;
            }
            else
            {
                nativePrefix = null;
            }
            
            ImGuiNative.igValue_Uint(nativePrefix, v);
            if (prefixByteCount > Util.StackAllocationSizeLimit)
            {
                Util.Free(nativePrefix);
            }
        }
        
        /// <summary>
        ///     Values the prefix
        /// </summary>
        /// <param name="prefix">The prefix</param>
        /// <param name="v">The </param>
        public static void Value(string prefix, float v)
        {
            byte* nativePrefix;
            int prefixByteCount = 0;
            if (prefix != null)
            {
                prefixByteCount = Encoding.UTF8.GetByteCount(prefix);
                if (prefixByteCount > Util.StackAllocationSizeLimit)
                {
                    nativePrefix = Util.Allocate(prefixByteCount + 1);
                }
                else
                {
                    byte* nativePrefixStackBytes = stackalloc byte[prefixByteCount + 1];
                    nativePrefix = nativePrefixStackBytes;
                }
                
                int nativePrefixOffset = Util.GetUtf8(prefix, nativePrefix, prefixByteCount);
                nativePrefix[nativePrefixOffset] = 0;
            }
            else
            {
                nativePrefix = null;
            }
            
            byte* nativeFloatFormat = null;
            ImGuiNative.igValue_Float(nativePrefix, v, nativeFloatFormat);
            if (prefixByteCount > Util.StackAllocationSizeLimit)
            {
                Util.Free(nativePrefix);
            }
        }
        
        /// <summary>
        ///     Values the prefix
        /// </summary>
        /// <param name="prefix">The prefix</param>
        /// <param name="v">The </param>
        /// <param name="floatFormat">The float format</param>
        public static void Value(string prefix, float v, string floatFormat)
        {
            byte* nativePrefix;
            int prefixByteCount = 0;
            if (prefix != null)
            {
                prefixByteCount = Encoding.UTF8.GetByteCount(prefix);
                if (prefixByteCount > Util.StackAllocationSizeLimit)
                {
                    nativePrefix = Util.Allocate(prefixByteCount + 1);
                }
                else
                {
                    byte* nativePrefixStackBytes = stackalloc byte[prefixByteCount + 1];
                    nativePrefix = nativePrefixStackBytes;
                }
                
                int nativePrefixOffset = Util.GetUtf8(prefix, nativePrefix, prefixByteCount);
                nativePrefix[nativePrefixOffset] = 0;
            }
            else
            {
                nativePrefix = null;
            }
            
            byte* nativeFloatFormat;
            int floatFormatByteCount = 0;
            if (floatFormat != null)
            {
                floatFormatByteCount = Encoding.UTF8.GetByteCount(floatFormat);
                if (floatFormatByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeFloatFormat = Util.Allocate(floatFormatByteCount + 1);
                }
                else
                {
                    byte* nativeFloatFormatStackBytes = stackalloc byte[floatFormatByteCount + 1];
                    nativeFloatFormat = nativeFloatFormatStackBytes;
                }
                
                int nativeFloatFormatOffset = Util.GetUtf8(floatFormat, nativeFloatFormat, floatFormatByteCount);
                nativeFloatFormat[nativeFloatFormatOffset] = 0;
            }
            else
            {
                nativeFloatFormat = null;
            }
            
            ImGuiNative.igValue_Float(nativePrefix, v, nativeFloatFormat);
            if (prefixByteCount > Util.StackAllocationSizeLimit)
            {
                Util.Free(nativePrefix);
            }
            
            if (floatFormatByteCount > Util.StackAllocationSizeLimit)
            {
                Util.Free(nativeFloatFormat);
            }
        }
        
        /// <summary>
        ///     Describes whether v slider float
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="size">The size</param>
        /// <param name="v">The </param>
        /// <param name="vMin">The min</param>
        /// <param name="vMax">The max</param>
        /// <returns>The bool</returns>
        public static bool VSliderFloat(string label, Vector2 size, ref float v, float vMin, float vMax)
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
            formatByteCount = Encoding.UTF8.GetByteCount("%.3f");
            if (formatByteCount > Util.StackAllocationSizeLimit)
            {
                nativeFormat = Util.Allocate(formatByteCount + 1);
            }
            else
            {
                byte* nativeFormatStackBytes = stackalloc byte[formatByteCount + 1];
                nativeFormat = nativeFormatStackBytes;
            }
            
            int nativeFormatOffset = Util.GetUtf8("%.3f", nativeFormat, formatByteCount);
            nativeFormat[nativeFormatOffset] = 0;
            ImGuiSliderFlags flags = 0;
            fixed (float* nativeV = &v)
            {
                byte ret = ImGuiNative.igVSliderFloat(nativeLabel, size, nativeV, vMin, vMax, nativeFormat, flags);
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
        ///     Describes whether v slider float
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="size">The size</param>
        /// <param name="v">The </param>
        /// <param name="vMin">The min</param>
        /// <param name="vMax">The max</param>
        /// <param name="format">The format</param>
        /// <returns>The bool</returns>
        public static bool VSliderFloat(string label, Vector2 size, ref float v, float vMin, float vMax, string format)
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
            fixed (float* nativeV = &v)
            {
                byte ret = ImGuiNative.igVSliderFloat(nativeLabel, size, nativeV, vMin, vMax, nativeFormat, flags);
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
        ///     Describes whether v slider float
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="size">The size</param>
        /// <param name="v">The </param>
        /// <param name="vMin">The min</param>
        /// <param name="vMax">The max</param>
        /// <param name="format">The format</param>
        /// <param name="flags">The flags</param>
        /// <returns>The bool</returns>
        public static bool VSliderFloat(string label, Vector2 size, ref float v, float vMin, float vMax, string format, ImGuiSliderFlags flags)
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
            
            fixed (float* nativeV = &v)
            {
                byte ret = ImGuiNative.igVSliderFloat(nativeLabel, size, nativeV, vMin, vMax, nativeFormat, flags);
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
        ///     Describes whether v slider int
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="size">The size</param>
        /// <param name="v">The </param>
        /// <param name="vMin">The min</param>
        /// <param name="vMax">The max</param>
        /// <returns>The bool</returns>
        public static bool VSliderInt(string label, Vector2 size, ref int v, int vMin, int vMax)
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
                byte ret = ImGuiNative.igVSliderInt(nativeLabel, size, nativeV, vMin, vMax, nativeFormat, flags);
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
        ///     Describes whether v slider int
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="size">The size</param>
        /// <param name="v">The </param>
        /// <param name="vMin">The min</param>
        /// <param name="vMax">The max</param>
        /// <param name="format">The format</param>
        /// <returns>The bool</returns>
        public static bool VSliderInt(string label, Vector2 size, ref int v, int vMin, int vMax, string format)
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
                byte ret = ImGuiNative.igVSliderInt(nativeLabel, size, nativeV, vMin, vMax, nativeFormat, flags);
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
        ///     Describes whether v slider int
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="size">The size</param>
        /// <param name="v">The </param>
        /// <param name="vMin">The min</param>
        /// <param name="vMax">The max</param>
        /// <param name="format">The format</param>
        /// <param name="flags">The flags</param>
        /// <returns>The bool</returns>
        public static bool VSliderInt(string label, Vector2 size, ref int v, int vMin, int vMax, string format, ImGuiSliderFlags flags)
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
                byte ret = ImGuiNative.igVSliderInt(nativeLabel, size, nativeV, vMin, vMax, nativeFormat, flags);
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
        ///     Describes whether v slider scalar
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="size">The size</param>
        /// <param name="dataType">The data type</param>
        /// <param name="pData">The data</param>
        /// <param name="pMin">The min</param>
        /// <param name="pMax">The max</param>
        /// <returns>The bool</returns>
        public static bool VSliderScalar(string label, Vector2 size, ImGuiDataType dataType, IntPtr pData, IntPtr pMin, IntPtr pMax)
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
            byte ret = ImGuiNative.igVSliderScalar(nativeLabel, size, dataType, nativePData, nativePMin, nativePMax, nativeFormat, flags);
            if (labelByteCount > Util.StackAllocationSizeLimit)
            {
                Util.Free(nativeLabel);
            }
            
            return ret != 0;
        }
        
        /// <summary>
        ///     Describes whether v slider scalar
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="size">The size</param>
        /// <param name="dataType">The data type</param>
        /// <param name="pData">The data</param>
        /// <param name="pMin">The min</param>
        /// <param name="pMax">The max</param>
        /// <param name="format">The format</param>
        /// <returns>The bool</returns>
        public static bool VSliderScalar(string label, Vector2 size, ImGuiDataType dataType, IntPtr pData, IntPtr pMin, IntPtr pMax, string format)
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
            byte ret = ImGuiNative.igVSliderScalar(nativeLabel, size, dataType, nativePData, nativePMin, nativePMax, nativeFormat, flags);
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
        ///     Describes whether v slider scalar
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="size">The size</param>
        /// <param name="dataType">The data type</param>
        /// <param name="pData">The data</param>
        /// <param name="pMin">The min</param>
        /// <param name="pMax">The max</param>
        /// <param name="format">The format</param>
        /// <param name="flags">The flags</param>
        /// <returns>The bool</returns>
        public static bool VSliderScalar(string label, Vector2 size, ImGuiDataType dataType, IntPtr pData, IntPtr pMin, IntPtr pMax, string format, ImGuiSliderFlags flags)
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
            
            byte ret = ImGuiNative.igVSliderScalar(nativeLabel, size, dataType, nativePData, nativePMin, nativePMax, nativeFormat, flags);
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
        ///     Describes whether input text
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="buf">The buf</param>
        /// <param name="bufSize">The buf size</param>
        /// <returns>The bool</returns>
        public static bool InputText(
            string label,
            byte[] buf,
            uint bufSize)
            => InputText(label, buf, bufSize, 0, null, IntPtr.Zero);
        
        /// <summary>
        ///     Describes whether input text
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="buf">The buf</param>
        /// <param name="bufSize">The buf size</param>
        /// <param name="flags">The flags</param>
        /// <returns>The bool</returns>
        public static bool InputText(
            string label,
            byte[] buf,
            uint bufSize,
            ImGuiInputTextFlags flags)
            => InputText(label, buf, bufSize, flags, null, IntPtr.Zero);
        
        /// <summary>
        ///     Describes whether input text
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="buf">The buf</param>
        /// <param name="bufSize">The buf size</param>
        /// <param name="flags">The flags</param>
        /// <param name="callback">The callback</param>
        /// <returns>The bool</returns>
        public static bool InputText(
            string label,
            byte[] buf,
            uint bufSize,
            ImGuiInputTextFlags flags,
            ImGuiInputTextCallback callback)
            => InputText(label, buf, bufSize, flags, callback, IntPtr.Zero);
        
        /// <summary>
        ///     Describes whether input text
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="buf">The buf</param>
        /// <param name="bufSize">The buf size</param>
        /// <param name="flags">The flags</param>
        /// <param name="callback">The callback</param>
        /// <param name="userData">The user data</param>
        /// <returns>The ret</returns>
        public static bool InputText(
            string label,
            byte[] buf,
            uint bufSize,
            ImGuiInputTextFlags flags,
            ImGuiInputTextCallback callback,
            IntPtr userData)
        {
            int utf8LabelByteCount = Encoding.UTF8.GetByteCount(label);
            byte* utf8LabelBytes;
            if (utf8LabelByteCount > Util.StackAllocationSizeLimit)
            {
                utf8LabelBytes = Util.Allocate(utf8LabelByteCount + 1);
            }
            else
            {
                byte* stackPtr = stackalloc byte[utf8LabelByteCount + 1];
                utf8LabelBytes = stackPtr;
            }
            
            Util.GetUtf8(label, utf8LabelBytes, utf8LabelByteCount);
            
            bool ret;
            fixed (byte* bufPtr = buf)
            {
                ret = ImGuiNative.igInputText(utf8LabelBytes, bufPtr, bufSize, flags, callback, userData) != 0;
            }
            
            if (utf8LabelByteCount > Util.StackAllocationSizeLimit)
            {
                Util.Free(utf8LabelBytes);
            }
            
            return ret;
        }
        
        /// <summary>
        ///     Describes whether input text
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="input">The input</param>
        /// <param name="maxLength">The max length</param>
        /// <returns>The bool</returns>
        public static bool InputText(
            string label,
            ref string input,
            uint maxLength) => InputText(label, ref input, maxLength, 0, null, IntPtr.Zero);
        
        /// <summary>
        ///     Describes whether input text
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="input">The input</param>
        /// <param name="maxLength">The max length</param>
        /// <param name="flags">The flags</param>
        /// <returns>The bool</returns>
        public static bool InputText(
            string label,
            ref string input,
            uint maxLength,
            ImGuiInputTextFlags flags) => InputText(label, ref input, maxLength, flags, null, IntPtr.Zero);
        
        /// <summary>
        ///     Describes whether input text
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="input">The input</param>
        /// <param name="maxLength">The max length</param>
        /// <param name="flags">The flags</param>
        /// <param name="callback">The callback</param>
        /// <returns>The bool</returns>
        public static bool InputText(
            string label,
            ref string input,
            uint maxLength,
            ImGuiInputTextFlags flags,
            ImGuiInputTextCallback callback) => InputText(label, ref input, maxLength, flags, callback, IntPtr.Zero);
        
        /// <summary>
        ///     Determines whether the input text.
        /// </summary>
        /// <param name="label">The label.</param>
        /// <param name="input">The input.</param>
        /// <param name="maxLength">The maximum length.</param>
        /// <param name="flag">The flags.</param>
        /// <param name="callback">The callback.</param>
        /// <param name="userData">The user data.</param>
        /// <returns><c>true</c> if the input text; otherwise, <c>false</c>.</returns>
        public static bool InputText(
            string label,
            ref string input,
            uint maxLength,
            ImGuiInputTextFlags flag,
            ImGuiInputTextCallback callback,
            IntPtr userData)
        {
            // Convert label and input to ANSI strings
            IntPtr labelPtr = Marshal.StringToHGlobalAnsi(label);
            IntPtr inputPtr = Marshal.StringToHGlobalAnsi(input);
            
            // Convert ANSI strings to UTF-8 bytes
            byte* utf8LabelBytes = (byte*) labelPtr;
            byte* utf8InputBytes = (byte*) inputPtr;
            
            // Create buffers for modified input
            int inputBufSize = Math.Max((int) maxLength + 1, Encoding.UTF8.GetByteCount(input) + 1);
            byte* modifiedUtf8InputBytes = stackalloc byte[inputBufSize];
            byte* originalUtf8InputBytes = stackalloc byte[inputBufSize];
            
            // Copy input bytes to the modified input buffer
            Unsafe.CopyBlock(modifiedUtf8InputBytes, utf8InputBytes, (uint) inputBufSize);
            
            // Call the ImGuiNative method
            byte result = ImGuiNative.igInputText(
                utf8LabelBytes,
                modifiedUtf8InputBytes,
                (uint) inputBufSize,
                flag,
                callback,
                userData);
            
            // Check if the input was modified and update the input variable accordingly
            if (!Util.AreStringsEqual(originalUtf8InputBytes, inputBufSize, modifiedUtf8InputBytes))
            {
                input = Encoding.UTF8.GetString(modifiedUtf8InputBytes, inputBufSize);
            }
            
            // Free the memory allocated by Marshal.StringToHGlobalAnsi
            Marshal.FreeHGlobal(labelPtr);
            Marshal.FreeHGlobal(inputPtr);
            
            return result != 0;
        }
        
        
        /// <summary>
        ///     Describes whether input text multiline
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="input">The input</param>
        /// <param name="maxLength">The max length</param>
        /// <param name="size">The size</param>
        /// <returns>The bool</returns>
        public static bool InputTextMultiline(
            string label,
            ref string input,
            uint maxLength,
            Vector2 size) => InputTextMultiline(label, ref input, maxLength, size, 0, null, IntPtr.Zero);
        
        /// <summary>
        ///     Describes whether input text multiline
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="input">The input</param>
        /// <param name="maxLength">The max length</param>
        /// <param name="size">The size</param>
        /// <param name="flags">The flags</param>
        /// <returns>The bool</returns>
        public static bool InputTextMultiline(
            string label,
            ref string input,
            uint maxLength,
            Vector2 size,
            ImGuiInputTextFlags flags) => InputTextMultiline(label, ref input, maxLength, size, flags, null, IntPtr.Zero);
        
        /// <summary>
        ///     Describes whether input text multiline
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="input">The input</param>
        /// <param name="maxLength">The max length</param>
        /// <param name="size">The size</param>
        /// <param name="flags">The flags</param>
        /// <param name="callback">The callback</param>
        /// <returns>The bool</returns>
        public static bool InputTextMultiline(
            string label,
            ref string input,
            uint maxLength,
            Vector2 size,
            ImGuiInputTextFlags flags,
            ImGuiInputTextCallback callback) => InputTextMultiline(label, ref input, maxLength, size, flags, callback, IntPtr.Zero);
        
        /// <summary>
        ///     Determines whether the input text is multiline.
        /// </summary>
        /// <param name="label">The label.</param>
        /// <param name="input">The input.</param>
        /// <param name="maxLength">The maximum length.</param>
        /// <param name="size">The size.</param>
        /// <param name="flag">The flags.</param>
        /// <param name="callback">The callback.</param>
        /// <param name="userData">The user data.</param>
        /// <returns><c>true</c> if the input text is multiline; otherwise, <c>false</c>.</returns>
        public static bool InputTextMultiline(
            string label,
            ref string input,
            uint maxLength,
            Vector2 size,
            ImGuiInputTextFlags flag,
            ImGuiInputTextCallback callback,
            IntPtr userData)
        {
            // Convert label and input to ANSI strings
            IntPtr labelPtr = Marshal.StringToHGlobalAnsi(label);
            IntPtr inputPtr = Marshal.StringToHGlobalAnsi(input);
            
            // Convert ANSI strings to UTF-8 bytes
            byte* utf8LabelBytes = (byte*) labelPtr;
            byte* utf8InputBytes = (byte*) inputPtr;
            
            // Create buffers for modified input
            int inputBufSize = Math.Max((int) maxLength + 1, Encoding.UTF8.GetByteCount(input) + 1);
            byte* modifiedUtf8InputBytes = stackalloc byte[inputBufSize];
            byte* originalUtf8InputBytes = stackalloc byte[inputBufSize];
            
            // Copy input bytes to the modified input buffer
            Unsafe.CopyBlock(modifiedUtf8InputBytes, utf8InputBytes, (uint) inputBufSize);
            
            // Call the ImGuiNative method
            byte result = ImGuiNative.igInputTextMultiline(
                utf8LabelBytes,
                modifiedUtf8InputBytes,
                (uint) inputBufSize,
                size,
                flag,
                callback,
                userData);
            
            // Check if the input was modified and update the input variable accordingly
            if (!Util.AreStringsEqual(originalUtf8InputBytes, inputBufSize, modifiedUtf8InputBytes))
            {
                input = Encoding.UTF8.GetString(modifiedUtf8InputBytes, inputBufSize);
            }
            
            // Free the memory allocated by Marshal.StringToHGlobalAnsi
            Marshal.FreeHGlobal(labelPtr);
            Marshal.FreeHGlobal(inputPtr);
            
            return result != 0;
        }
        
        
        /// <summary>
        ///     Describes whether input text with hint
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="hint">The hint</param>
        /// <param name="input">The input</param>
        /// <param name="maxLength">The max length</param>
        /// <returns>The bool</returns>
        public static bool InputTextWithHint(
            string label,
            string hint,
            ref string input,
            uint maxLength) => InputTextWithHint(label, hint, ref input, maxLength, 0, null, IntPtr.Zero);
        
        /// <summary>
        ///     Describes whether input text with hint
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="hint">The hint</param>
        /// <param name="input">The input</param>
        /// <param name="maxLength">The max length</param>
        /// <param name="flags">The flags</param>
        /// <returns>The bool</returns>
        public static bool InputTextWithHint(
            string label,
            string hint,
            ref string input,
            uint maxLength,
            ImGuiInputTextFlags flags) => InputTextWithHint(label, hint, ref input, maxLength, flags, null, IntPtr.Zero);
        
        /// <summary>
        ///     Describes whether input text with hint
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="hint">The hint</param>
        /// <param name="input">The input</param>
        /// <param name="maxLength">The max length</param>
        /// <param name="flags">The flags</param>
        /// <param name="callback">The callback</param>
        /// <returns>The bool</returns>
        public static bool InputTextWithHint(
            string label,
            string hint,
            ref string input,
            uint maxLength,
            ImGuiInputTextFlags flags,
            ImGuiInputTextCallback callback) => InputTextWithHint(label, hint, ref input, maxLength, flags, callback, IntPtr.Zero);
        
        /// <summary>
        ///     Describes whether input text with hint
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="hint">The hint</param>
        /// <param name="input">The input</param>
        /// <param name="maxLength">The max length</param>
        /// <param name="flag">The flags</param>
        /// <param name="callback">The callback</param>
        /// <param name="userData">The user data</param>
        /// <returns>The bool</returns>
        public static bool InputTextWithHint(
            string label,
            string hint,
            ref string input,
            uint maxLength,
            ImGuiInputTextFlags flag,
            ImGuiInputTextCallback callback,
            IntPtr userData)
        {
            byte* utf8LabelBytes = GetUtf8Bytes(label);
            byte* utf8HintBytes = GetUtf8Bytes(hint);
            byte* utf8InputBytes = GetUtf8Bytes(input, maxLength);
            
            byte result = ImGuiNative.igInputTextWithHint(
                utf8LabelBytes,
                utf8HintBytes,
                utf8InputBytes,
                maxLength + 1,
                flag,
                callback,
                userData);
            
            bool hasInputChanged = !AreUtf8StringsEqual(utf8InputBytes, input);
            if (hasInputChanged)
            {
                input = GetStringFromUtf8(utf8InputBytes);
            }
            
            FreeUtf8Bytes(utf8LabelBytes);
            FreeUtf8Bytes(utf8HintBytes);
            FreeUtf8Bytes(utf8InputBytes);
            
            return result != 0;
        }
        
        /// <summary>
        ///     Gets the utf 8 bytes using the specified text
        /// </summary>
        /// <param name="text">The text</param>
        /// <returns>The utf bytes</returns>
        private static byte* GetUtf8Bytes(string text)
        {
            int byteCount = Encoding.UTF8.GetByteCount(text);
            byte* utf8Bytes = (byte*) Marshal.AllocHGlobal(byteCount + 1);
            Util.GetUtf8(text, utf8Bytes, byteCount);
            utf8Bytes[byteCount] = 0; // Null-terminate the string
            return utf8Bytes;
        }
        
        
        /// <summary>
        ///     Gets the utf 8 bytes using the specified text
        /// </summary>
        /// <param name="text">The text</param>
        /// <param name="maxLength">The max length</param>
        /// <returns>The utf bytes</returns>
        private static byte* GetUtf8Bytes(string text, uint maxLength)
        {
            int byteCount = Encoding.UTF8.GetByteCount(text);
            int inputBufSize = Math.Max((int) maxLength + 1, byteCount + 1);
            byte[] utf8BytesArray = new byte[inputBufSize];
            
            fixed (byte* utf8Bytes = utf8BytesArray)
            {
                Util.GetUtf8(text, utf8Bytes, inputBufSize);
                Unsafe.InitBlockUnaligned(utf8Bytes, 0, (uint) inputBufSize);
                
                byte* result = (byte*) Marshal.AllocHGlobal(inputBufSize);
                Buffer.MemoryCopy(utf8Bytes, result, inputBufSize, inputBufSize);
                
                return result;
            }
        }
        
        
        /// <summary>
        ///     Describes whether are utf 8 strings equal
        /// </summary>
        /// <param name="utf8Bytes">The utf bytes</param>
        /// <param name="text">The text</param>
        /// <returns>The bool</returns>
        private static bool AreUtf8StringsEqual(byte* utf8Bytes, string text)
        {
            int byteCount = Encoding.UTF8.GetByteCount(text);
            return Util.AreStringsEqual(utf8Bytes, byteCount, utf8Bytes);
        }
        
        /// <summary>
        ///     Gets the string from utf 8 using the specified utf 8 bytes
        /// </summary>
        /// <param name="utf8Bytes">The utf bytes</param>
        /// <returns>The string</returns>
        private static string GetStringFromUtf8(byte* utf8Bytes) => Util.StringFromPtr(utf8Bytes);
        
        /// <summary>
        ///     Frees the utf 8 bytes using the specified utf 8 bytes
        /// </summary>
        /// <param name="utf8Bytes">The utf bytes</param>
        private static void FreeUtf8Bytes(byte* utf8Bytes)
        {
            int allocatedSize = GetUtf8BytesLength(utf8Bytes);
            if (allocatedSize > Util.StackAllocationSizeLimit)
            {
                Util.Free(utf8Bytes);
            }
        }
        
        /// <summary>
        ///     Gets the utf 8 bytes length using the specified utf 8 bytes
        /// </summary>
        /// <param name="utf8Bytes">The utf bytes</param>
        /// <returns>The length</returns>
        private static int GetUtf8BytesLength(byte* utf8Bytes)
        {
            if (utf8Bytes == null)
            {
                return 0;
            }
            
            int length = 0;
            while (*(utf8Bytes + length) != 0)
            {
                length++;
            }
            
            return length;
        }
        
        /// <summary>
        ///     Calcs the text size using the specified text
        /// </summary>
        /// <param name="text">The text</param>
        /// <returns>The vector</returns>
        public static Vector2 CalcTextSize(string text)
            => CalcTextSizeImpl(text);
        
        /// <summary>
        ///     Calcs the text size using the specified text
        /// </summary>
        /// <param name="text">The text</param>
        /// <param name="start">The start</param>
        /// <returns>The vector</returns>
        public static Vector2 CalcTextSize(string text, int start)
            => CalcTextSizeImpl(text, start);
        
        /// <summary>
        ///     Calcs the text size using the specified text
        /// </summary>
        /// <param name="text">The text</param>
        /// <param name="wrapWidth">The wrap width</param>
        /// <returns>The vector</returns>
        public static Vector2 CalcTextSize(string text, float wrapWidth)
            => CalcTextSizeImpl(text, wrapWidth: wrapWidth);
        
        /// <summary>
        ///     Calcs the text size using the specified text
        /// </summary>
        /// <param name="text">The text</param>
        /// <param name="hideTextAfterDoubleHash">The hide text after double hash</param>
        /// <returns>The vector</returns>
        public static Vector2 CalcTextSize(string text, bool hideTextAfterDoubleHash)
            => CalcTextSizeImpl(text, hideTextAfterDoubleHash: hideTextAfterDoubleHash);
        
        /// <summary>
        ///     Calcs the text size using the specified text
        /// </summary>
        /// <param name="text">The text</param>
        /// <param name="start">The start</param>
        /// <param name="length">The length</param>
        /// <returns>The vector</returns>
        public static Vector2 CalcTextSize(string text, int start, int length)
            => CalcTextSizeImpl(text, start, length);
        
        /// <summary>
        ///     Calcs the text size using the specified text
        /// </summary>
        /// <param name="text">The text</param>
        /// <param name="start">The start</param>
        /// <param name="hideTextAfterDoubleHash">The hide text after double hash</param>
        /// <returns>The vector</returns>
        public static Vector2 CalcTextSize(string text, int start, bool hideTextAfterDoubleHash)
            => CalcTextSizeImpl(text, start, hideTextAfterDoubleHash: hideTextAfterDoubleHash);
        
        /// <summary>
        ///     Calcs the text size using the specified text
        /// </summary>
        /// <param name="text">The text</param>
        /// <param name="start">The start</param>
        /// <param name="wrapWidth">The wrap width</param>
        /// <returns>The vector</returns>
        public static Vector2 CalcTextSize(string text, int start, float wrapWidth)
            => CalcTextSizeImpl(text, start, wrapWidth: wrapWidth);
        
        /// <summary>
        ///     Calcs the text size using the specified text
        /// </summary>
        /// <param name="text">The text</param>
        /// <param name="hideTextAfterDoubleHash">The hide text after double hash</param>
        /// <param name="wrapWidth">The wrap width</param>
        /// <returns>The vector</returns>
        public static Vector2 CalcTextSize(string text, bool hideTextAfterDoubleHash, float wrapWidth)
            => CalcTextSizeImpl(text, hideTextAfterDoubleHash: hideTextAfterDoubleHash, wrapWidth: wrapWidth);
        
        /// <summary>
        ///     Calcs the text size using the specified text
        /// </summary>
        /// <param name="text">The text</param>
        /// <param name="start">The start</param>
        /// <param name="length">The length</param>
        /// <param name="hideTextAfterDoubleHash">The hide text after double hash</param>
        /// <returns>The vector</returns>
        public static Vector2 CalcTextSize(string text, int start, int length, bool hideTextAfterDoubleHash)
            => CalcTextSizeImpl(text, start, length, hideTextAfterDoubleHash);
        
        /// <summary>
        ///     Calcs the text size using the specified text
        /// </summary>
        /// <param name="text">The text</param>
        /// <param name="start">The start</param>
        /// <param name="length">The length</param>
        /// <param name="wrapWidth">The wrap width</param>
        /// <returns>The vector</returns>
        public static Vector2 CalcTextSize(string text, int start, int length, float wrapWidth)
            => CalcTextSizeImpl(text, start, length, wrapWidth: wrapWidth);
        
        /// <summary>
        ///     Calcs the text size using the specified text
        /// </summary>
        /// <param name="text">The text</param>
        /// <param name="start">The start</param>
        /// <param name="length">The length</param>
        /// <param name="hideTextAfterDoubleHash">The hide text after double hash</param>
        /// <param name="wrapWidth">The wrap width</param>
        /// <returns>The vector</returns>
        public static Vector2 CalcTextSize(string text, int start, int length, bool hideTextAfterDoubleHash, float wrapWidth)
            => CalcTextSizeImpl(text, start, length, hideTextAfterDoubleHash, wrapWidth);
        
        /// <summary>
        ///     Calcs the text size impl using the specified text
        /// </summary>
        /// <param name="text">The text</param>
        /// <param name="start">The start</param>
        /// <param name="length">The length</param>
        /// <param name="hideTextAfterDoubleHash">The hide text after double hash</param>
        /// <param name="wrapWidth">The wrap width</param>
        /// <returns>The ret</returns>
        private static Vector2 CalcTextSizeImpl(
            string text,
            int start = 0,
            int? length = null,
            bool hideTextAfterDoubleHash = false,
            float wrapWidth = -1.0f)
        {
            Vector2 ret;
            byte* nativeTextStart = null;
            byte* nativeTextEnd = null;
            int textByteCount = 0;
            if (text != null)
            {
                int textToCopyLen = length.HasValue ? length.Value : text.Length;
                textByteCount = Util.CalcSizeInUtf8(text, start, textToCopyLen);
                if (textByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeTextStart = Util.Allocate(textByteCount + 1);
                }
                else
                {
                    byte* nativeTextStackBytes = stackalloc byte[textByteCount + 1];
                    nativeTextStart = nativeTextStackBytes;
                }
                
                int nativeTextOffset = Util.GetUtf8(text, start, textToCopyLen, nativeTextStart, textByteCount);
                nativeTextStart[nativeTextOffset] = 0;
                nativeTextEnd = nativeTextStart + nativeTextOffset;
            }
            
            ImGuiNative.igCalcTextSize(&ret, nativeTextStart, nativeTextEnd, *(byte*) &hideTextAfterDoubleHash, wrapWidth);
            if (textByteCount > Util.StackAllocationSizeLimit)
            {
                Util.Free(nativeTextStart);
            }
            
            return ret;
        }
        
        /// <summary>
        ///     Describes whether input text
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="buf">The buf</param>
        /// <param name="bufSize">The buf size</param>
        /// <returns>The bool</returns>
        public static bool InputText(
            string label,
            IntPtr buf,
            uint bufSize)
            => InputText(label, buf, bufSize, 0, null, IntPtr.Zero);
        
        /// <summary>
        ///     Describes whether input text
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="buf">The buf</param>
        /// <param name="bufSize">The buf size</param>
        /// <param name="flags">The flags</param>
        /// <returns>The bool</returns>
        public static bool InputText(
            string label,
            IntPtr buf,
            uint bufSize,
            ImGuiInputTextFlags flags)
            => InputText(label, buf, bufSize, flags, null, IntPtr.Zero);
        
        /// <summary>
        ///     Describes whether input text
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="buf">The buf</param>
        /// <param name="bufSize">The buf size</param>
        /// <param name="flags">The flags</param>
        /// <param name="callback">The callback</param>
        /// <returns>The bool</returns>
        public static bool InputText(
            string label,
            IntPtr buf,
            uint bufSize,
            ImGuiInputTextFlags flags,
            ImGuiInputTextCallback callback)
            => InputText(label, buf, bufSize, flags, callback, IntPtr.Zero);
        
        /// <summary>
        ///     Describes whether input text
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="buf">The buf</param>
        /// <param name="bufSize">The buf size</param>
        /// <param name="flags">The flags</param>
        /// <param name="callback">The callback</param>
        /// <param name="userData">The user data</param>
        /// <returns>The ret</returns>
        public static bool InputText(
            string label,
            IntPtr buf,
            uint bufSize,
            ImGuiInputTextFlags flags,
            ImGuiInputTextCallback callback,
            IntPtr userData)
        {
            int utf8LabelByteCount = Encoding.UTF8.GetByteCount(label);
            byte* utf8LabelBytes;
            if (utf8LabelByteCount > Util.StackAllocationSizeLimit)
            {
                utf8LabelBytes = Util.Allocate(utf8LabelByteCount + 1);
            }
            else
            {
                byte* stackPtr = stackalloc byte[utf8LabelByteCount + 1];
                utf8LabelBytes = stackPtr;
            }
            
            Util.GetUtf8(label, utf8LabelBytes, utf8LabelByteCount);
            
            bool ret = ImGuiNative.igInputText(utf8LabelBytes, (byte*) buf, bufSize, flags, callback, userData) != 0;
            
            if (utf8LabelByteCount > Util.StackAllocationSizeLimit)
            {
                Util.Free(utf8LabelBytes);
            }
            
            return ret;
        }
        
        /// <summary>
        ///     Describes whether begin
        /// </summary>
        /// <param name="name">The name</param>
        /// <param name="flags">The flags</param>
        /// <returns>The bool</returns>
        public static bool Begin(string name, ImGuiWindowFlags flags)
        {
            int utf8NameByteCount = Encoding.UTF8.GetByteCount(name);
            byte* utf8NameBytes;
            if (utf8NameByteCount > Util.StackAllocationSizeLimit)
            {
                utf8NameBytes = Util.Allocate(utf8NameByteCount + 1);
            }
            else
            {
                byte* stackPtr = stackalloc byte[utf8NameByteCount + 1];
                utf8NameBytes = stackPtr;
            }
            
            Util.GetUtf8(name, utf8NameBytes, utf8NameByteCount);
            
            byte* pOpen = null;
            byte ret = ImGuiNative.igBegin(utf8NameBytes, pOpen, flags);
            
            if (utf8NameByteCount > Util.StackAllocationSizeLimit)
            {
                Util.Free(utf8NameBytes);
            }
            
            return ret != 0;
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