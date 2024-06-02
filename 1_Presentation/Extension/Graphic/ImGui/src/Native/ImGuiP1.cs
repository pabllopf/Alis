// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImGuiP1.cs
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
    public static unsafe partial class ImGui
    {
        /// <summary>
        ///     Describes whether combo
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="currentItem">The current item</param>
        /// <param name="itemsSeparatedByZeros">The items separated by zeros</param>
        /// <returns>The bool</returns>
        public static bool Combo(string label, ref int currentItem, string itemsSeparatedByZeros)
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
            
            byte* nativeItemsSeparatedByZeros;
            int itemsSeparatedByZerosByteCount = 0;
            if (itemsSeparatedByZeros != null)
            {
                itemsSeparatedByZerosByteCount = Encoding.UTF8.GetByteCount(itemsSeparatedByZeros);
                if (itemsSeparatedByZerosByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeItemsSeparatedByZeros = Util.Allocate(itemsSeparatedByZerosByteCount + 1);
                }
                else
                {
                    byte* nativeItemsSeparatedByZerosStackBytes = stackalloc byte[itemsSeparatedByZerosByteCount + 1];
                    nativeItemsSeparatedByZeros = nativeItemsSeparatedByZerosStackBytes;
                }
                
                int nativeItemsSeparatedByZerosOffset = Util.GetUtf8(itemsSeparatedByZeros, nativeItemsSeparatedByZeros, itemsSeparatedByZerosByteCount);
                nativeItemsSeparatedByZeros[nativeItemsSeparatedByZerosOffset] = 0;
            }
            else
            {
                nativeItemsSeparatedByZeros = null;
            }
            
            int popupMaxHeightInItems = -1;
            fixed (int* nativeCurrentItem = &currentItem)
            {
                byte ret = ImGuiNative.igCombo_Str(nativeLabel, nativeCurrentItem, nativeItemsSeparatedByZeros, popupMaxHeightInItems);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeLabel);
                }
                
                if (itemsSeparatedByZerosByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeItemsSeparatedByZeros);
                }
                
                return ret != 0;
            }
        }
        
        /// <summary>
        ///     Describes whether combo
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="currentItem">The current item</param>
        /// <param name="itemsSeparatedByZeros">The items separated by zeros</param>
        /// <param name="popupMaxHeightInItems">The popup max height in items</param>
        /// <returns>The bool</returns>
        public static bool Combo(string label, ref int currentItem, string itemsSeparatedByZeros, int popupMaxHeightInItems)
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
            
            byte* nativeItemsSeparatedByZeros;
            int itemsSeparatedByZerosByteCount = 0;
            if (itemsSeparatedByZeros != null)
            {
                itemsSeparatedByZerosByteCount = Encoding.UTF8.GetByteCount(itemsSeparatedByZeros);
                if (itemsSeparatedByZerosByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeItemsSeparatedByZeros = Util.Allocate(itemsSeparatedByZerosByteCount + 1);
                }
                else
                {
                    byte* nativeItemsSeparatedByZerosStackBytes = stackalloc byte[itemsSeparatedByZerosByteCount + 1];
                    nativeItemsSeparatedByZeros = nativeItemsSeparatedByZerosStackBytes;
                }
                
                int nativeItemsSeparatedByZerosOffset = Util.GetUtf8(itemsSeparatedByZeros, nativeItemsSeparatedByZeros, itemsSeparatedByZerosByteCount);
                nativeItemsSeparatedByZeros[nativeItemsSeparatedByZerosOffset] = 0;
            }
            else
            {
                nativeItemsSeparatedByZeros = null;
            }
            
            fixed (int* nativeCurrentItem = &currentItem)
            {
                byte ret = ImGuiNative.igCombo_Str(nativeLabel, nativeCurrentItem, nativeItemsSeparatedByZeros, popupMaxHeightInItems);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeLabel);
                }
                
                if (itemsSeparatedByZerosByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeItemsSeparatedByZeros);
                }
                
                return ret != 0;
            }
        }
        
        /// <summary>
        ///     Creates the context
        /// </summary>
        /// <returns>The ret</returns>
        public static IntPtr CreateContext()
        {
            ImFontAtlas* sharedFontAtlas = null;
            IntPtr ret = ImGuiNative.igCreateContext(sharedFontAtlas);
            return ret;
        }
        
        /// <summary>
        ///     Creates the context using the specified shared font atlas
        /// </summary>
        /// <param name="sharedFontAtlas">The shared font atlas</param>
        /// <returns>The ret</returns>
        public static IntPtr CreateContext(ImFontAtlasPtr sharedFontAtlas)
        {
            ImFontAtlas* nativeSharedFontAtlas = sharedFontAtlas.NativePtr;
            IntPtr ret = ImGuiNative.igCreateContext(nativeSharedFontAtlas);
            return ret;
        }
        
        /// <summary>
        ///     Describes whether debug check version and data layout
        /// </summary>
        /// <param name="versionStr">The version str</param>
        /// <param name="szIo">The sz io</param>
        /// <param name="szStyle">The sz style</param>
        /// <param name="szVec2">The sz vec2</param>
        /// <param name="szVec4">The sz vec4</param>
        /// <param name="szDrawvert">The sz drawvert</param>
        /// <param name="szDrawidx">The sz drawidx</param>
        /// <returns>The bool</returns>
        public static bool DebugCheckVersionAndDataLayout(string versionStr, uint szIo, uint szStyle, uint szVec2, uint szVec4, uint szDrawvert, uint szDrawidx)
        {
            byte* nativeVersionStr;
            int versionStrByteCount = 0;
            if (versionStr != null)
            {
                versionStrByteCount = Encoding.UTF8.GetByteCount(versionStr);
                if (versionStrByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeVersionStr = Util.Allocate(versionStrByteCount + 1);
                }
                else
                {
                    byte* nativeVersionStrStackBytes = stackalloc byte[versionStrByteCount + 1];
                    nativeVersionStr = nativeVersionStrStackBytes;
                }
                
                int nativeVersionStrOffset = Util.GetUtf8(versionStr, nativeVersionStr, versionStrByteCount);
                nativeVersionStr[nativeVersionStrOffset] = 0;
            }
            else
            {
                nativeVersionStr = null;
            }
            
            byte ret = ImGuiNative.igDebugCheckVersionAndDataLayout(nativeVersionStr, szIo, szStyle, szVec2, szVec4, szDrawvert, szDrawidx);
            if (versionStrByteCount > Util.StackAllocationSizeLimit)
            {
                Util.Free(nativeVersionStr);
            }
            
            return ret != 0;
        }
        
        /// <summary>
        ///     Debugs the text encoding using the specified text
        /// </summary>
        /// <param name="text">The text</param>
        public static void DebugTextEncoding(string text)
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
            
            ImGuiNative.igDebugTextEncoding(nativeText);
            if (textByteCount > Util.StackAllocationSizeLimit)
            {
                Util.Free(nativeText);
            }
        }
        
        /// <summary>
        ///     Destroys the context
        /// </summary>
        public static void DestroyContext()
        {
            IntPtr ctx = IntPtr.Zero;
            ImGuiNative.igDestroyContext(ctx);
        }
        
        /// <summary>
        ///     Destroys the context using the specified ctx
        /// </summary>
        /// <param name="ctx">The ctx</param>
        public static void DestroyContext(IntPtr ctx)
        {
            ImGuiNative.igDestroyContext(ctx);
        }
        
        /// <summary>
        ///     Destroys the platform windows
        /// </summary>
        public static void DestroyPlatformWindows()
        {
            ImGuiNative.igDestroyPlatformWindows();
        }
        
        /// <summary>
        ///     Docks the space using the specified id
        /// </summary>
        /// <param name="id">The id</param>
        /// <returns>The ret</returns>
        public static uint DockSpace(uint id)
        {
            Vector2 size = new Vector2();
            ImGuiDockNodeFlags flags = 0;
            ImGuiWindowClass windowClass = new ImGuiWindowClass();
            uint ret = ImGuiNative.igDockSpace(id, size, flags, windowClass);
            return ret;
        }
        
        /// <summary>
        ///     Docks the space using the specified id
        /// </summary>
        /// <param name="id">The id</param>
        /// <param name="size">The size</param>
        /// <returns>The ret</returns>
        public static uint DockSpace(uint id, Vector2 size)
        {
            ImGuiDockNodeFlags flags = 0;
            ImGuiWindowClass windowClass = new ImGuiWindowClass();
            uint ret = ImGuiNative.igDockSpace(id, size, flags, windowClass);
            return ret;
        }
        
        /// <summary>
        ///     Docks the space using the specified id
        /// </summary>
        /// <param name="id">The id</param>
        /// <param name="size">The size</param>
        /// <param name="flags">The flags</param>
        /// <returns>The ret</returns>
        public static uint DockSpace(uint id, Vector2 size, ImGuiDockNodeFlags flags)
        {
            ImGuiWindowClass windowClass = new ImGuiWindowClass();
            uint ret = ImGuiNative.igDockSpace(id, size, flags, windowClass);
            return ret;
        }
        
        /// <summary>
        ///     Docks the space using the specified id
        /// </summary>
        /// <param name="id">The id</param>
        /// <param name="size">The size</param>
        /// <param name="flags">The flags</param>
        /// <param name="windowClass">The window class</param>
        /// <returns>The ret</returns>
        public static uint DockSpace(uint id, Vector2 size, ImGuiDockNodeFlags flags, ImGuiWindowClass windowClass)
        {
            uint ret = ImGuiNative.igDockSpace(id, size, flags, windowClass);
            return ret;
        }
        
        /// <summary>
        ///     Docks the space over viewport
        /// </summary>
        /// <returns>The ret</returns>
        public static uint DockSpaceOverViewport()
        {
            ImGuiViewport* viewport = null;
            ImGuiDockNodeFlags flags = 0;
            ImGuiWindowClass windowClass = new ImGuiWindowClass();
            uint ret = ImGuiNative.igDockSpaceOverViewport(viewport, flags, windowClass);
            return ret;
        }
        
        /// <summary>
        ///     Docks the space over viewport using the specified viewport
        /// </summary>
        /// <param name="viewport">The viewport</param>
        /// <returns>The ret</returns>
        public static uint DockSpaceOverViewport(ImGuiViewportPtr viewport)
        {
            ImGuiViewport* nativeViewport = viewport.NativePtr;
            ImGuiDockNodeFlags flags = 0;
            ImGuiWindowClass windowClass = new ImGuiWindowClass();
            uint ret = ImGuiNative.igDockSpaceOverViewport(nativeViewport, flags, windowClass);
            return ret;
        }
        
        /// <summary>
        ///     Docks the space over viewport using the specified viewport
        /// </summary>
        /// <param name="viewport">The viewport</param>
        /// <param name="flags">The flags</param>
        /// <returns>The ret</returns>
        public static uint DockSpaceOverViewport(ImGuiViewportPtr viewport, ImGuiDockNodeFlags flags)
        {
            ImGuiViewport* nativeViewport = viewport.NativePtr;
            ImGuiWindowClass windowClass = new ImGuiWindowClass();
            uint ret = ImGuiNative.igDockSpaceOverViewport(nativeViewport, flags, windowClass);
            return ret;
        }
        
        /// <summary>
        ///     Docks the space over viewport using the specified viewport
        /// </summary>
        /// <param name="viewport">The viewport</param>
        /// <param name="flags">The flags</param>
        /// <param name="windowClass">The window class</param>
        /// <returns>The ret</returns>
        public static uint DockSpaceOverViewport(ImGuiViewportPtr viewport, ImGuiDockNodeFlags flags, ImGuiWindowClass windowClass)
        {
            ImGuiViewport* nativeViewport = viewport.NativePtr;
            uint ret = ImGuiNative.igDockSpaceOverViewport(nativeViewport, flags, windowClass);
            return ret;
        }
        
        /// <summary>
        ///     Describes whether drag float
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="v">The </param>
        /// <returns>The bool</returns>
        public static bool DragFloat(string label, ref float v)
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
            float vMin = 0.0f;
            float vMax = 0.0f;
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
                byte ret = ImGuiNative.igDragFloat(nativeLabel, nativeV, vSpeed, vMin, vMax, nativeFormat, flags);
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
        ///     Describes whether drag float
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="v">The </param>
        /// <param name="vSpeed">The speed</param>
        /// <returns>The bool</returns>
        public static bool DragFloat(string label, ref float v, float vSpeed)
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
            
            float vMin = 0.0f;
            float vMax = 0.0f;
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
                byte ret = ImGuiNative.igDragFloat(nativeLabel, nativeV, vSpeed, vMin, vMax, nativeFormat, flags);
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
        ///     Describes whether drag float
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="v">The </param>
        /// <param name="vSpeed">The speed</param>
        /// <param name="vMin">The min</param>
        /// <returns>The bool</returns>
        public static bool DragFloat(string label, ref float v, float vSpeed, float vMin)
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
            
            float vMax = 0.0f;
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
                byte ret = ImGuiNative.igDragFloat(nativeLabel, nativeV, vSpeed, vMin, vMax, nativeFormat, flags);
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
        ///     Describes whether drag float
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="v">The </param>
        /// <param name="vSpeed">The speed</param>
        /// <param name="vMin">The min</param>
        /// <param name="vMax">The max</param>
        /// <returns>The bool</returns>
        public static bool DragFloat(string label, ref float v, float vSpeed, float vMin, float vMax)
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
                byte ret = ImGuiNative.igDragFloat(nativeLabel, nativeV, vSpeed, vMin, vMax, nativeFormat, flags);
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
        ///     Describes whether drag float
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="v">The </param>
        /// <param name="vSpeed">The speed</param>
        /// <param name="vMin">The min</param>
        /// <param name="vMax">The max</param>
        /// <param name="format">The format</param>
        /// <returns>The bool</returns>
        public static bool DragFloat(string label, ref float v, float vSpeed, float vMin, float vMax, string format)
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
                byte ret = ImGuiNative.igDragFloat(nativeLabel, nativeV, vSpeed, vMin, vMax, nativeFormat, flags);
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
        ///     Describes whether drag float
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="v">The </param>
        /// <param name="vSpeed">The speed</param>
        /// <param name="vMin">The min</param>
        /// <param name="vMax">The max</param>
        /// <param name="format">The format</param>
        /// <param name="flags">The flags</param>
        /// <returns>The bool</returns>
        public static bool DragFloat(string label, ref float v, float vSpeed, float vMin, float vMax, string format, ImGuiSliderFlags flags)
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
                byte ret = ImGuiNative.igDragFloat(nativeLabel, nativeV, vSpeed, vMin, vMax, nativeFormat, flags);
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
        ///     Describes whether drag float 2
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="v">The </param>
        /// <returns>The bool</returns>
        public static bool DragFloat2(string label, ref Vector2 v)
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
            float vMin = 0.0f;
            float vMax = 0.0f;
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
            fixed (Vector2* nativeV = &v)
            {
                byte ret = ImGuiNative.igDragFloat2(nativeLabel, nativeV, vSpeed, vMin, vMax, nativeFormat, flags);
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
        ///     Describes whether drag float 2
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="v">The </param>
        /// <param name="vSpeed">The speed</param>
        /// <returns>The bool</returns>
        public static bool DragFloat2(string label, ref Vector2 v, float vSpeed)
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
            
            float vMin = 0.0f;
            float vMax = 0.0f;
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
            fixed (Vector2* nativeV = &v)
            {
                byte ret = ImGuiNative.igDragFloat2(nativeLabel, nativeV, vSpeed, vMin, vMax, nativeFormat, flags);
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
        ///     Describes whether drag float 2
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="v">The </param>
        /// <param name="vSpeed">The speed</param>
        /// <param name="vMin">The min</param>
        /// <returns>The bool</returns>
        public static bool DragFloat2(string label, ref Vector2 v, float vSpeed, float vMin)
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
            
            float vMax = 0.0f;
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
            fixed (Vector2* nativeV = &v)
            {
                byte ret = ImGuiNative.igDragFloat2(nativeLabel, nativeV, vSpeed, vMin, vMax, nativeFormat, flags);
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
        ///     Describes whether drag float 2
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="v">The </param>
        /// <param name="vSpeed">The speed</param>
        /// <param name="vMin">The min</param>
        /// <param name="vMax">The max</param>
        /// <returns>The bool</returns>
        public static bool DragFloat2(string label, ref Vector2 v, float vSpeed, float vMin, float vMax)
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
            fixed (Vector2* nativeV = &v)
            {
                byte ret = ImGuiNative.igDragFloat2(nativeLabel, nativeV, vSpeed, vMin, vMax, nativeFormat, flags);
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
        ///     Describes whether drag float 2
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="v">The </param>
        /// <param name="vSpeed">The speed</param>
        /// <param name="vMin">The min</param>
        /// <param name="vMax">The max</param>
        /// <param name="format">The format</param>
        /// <returns>The bool</returns>
        public static bool DragFloat2(string label, ref Vector2 v, float vSpeed, float vMin, float vMax, string format)
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
            fixed (Vector2* nativeV = &v)
            {
                byte ret = ImGuiNative.igDragFloat2(nativeLabel, nativeV, vSpeed, vMin, vMax, nativeFormat, flags);
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
        ///     Describes whether drag float 2
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="v">The </param>
        /// <param name="vSpeed">The speed</param>
        /// <param name="vMin">The min</param>
        /// <param name="vMax">The max</param>
        /// <param name="format">The format</param>
        /// <param name="flags">The flags</param>
        /// <returns>The bool</returns>
        public static bool DragFloat2(string label, ref Vector2 v, float vSpeed, float vMin, float vMax, string format, ImGuiSliderFlags flags)
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
            
            fixed (Vector2* nativeV = &v)
            {
                byte ret = ImGuiNative.igDragFloat2(nativeLabel, nativeV, vSpeed, vMin, vMax, nativeFormat, flags);
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
        ///     Describes whether drag float 3
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="v">The </param>
        /// <returns>The bool</returns>
        public static bool DragFloat3(string label, ref Vector3 v)
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
            float vMin = 0.0f;
            float vMax = 0.0f;
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
            fixed (Vector3* nativeV = &v)
            {
                byte ret = ImGuiNative.igDragFloat3(nativeLabel, nativeV, vSpeed, vMin, vMax, nativeFormat, flags);
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
        ///     Describes whether drag float 3
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="v">The </param>
        /// <param name="vSpeed">The speed</param>
        /// <returns>The bool</returns>
        public static bool DragFloat3(string label, ref Vector3 v, float vSpeed)
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
            
            float vMin = 0.0f;
            float vMax = 0.0f;
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
            fixed (Vector3* nativeV = &v)
            {
                byte ret = ImGuiNative.igDragFloat3(nativeLabel, nativeV, vSpeed, vMin, vMax, nativeFormat, flags);
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
        ///     Describes whether drag float 3
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="v">The </param>
        /// <param name="vSpeed">The speed</param>
        /// <param name="vMin">The min</param>
        /// <returns>The bool</returns>
        public static bool DragFloat3(string label, ref Vector3 v, float vSpeed, float vMin)
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
            
            float vMax = 0.0f;
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
            fixed (Vector3* nativeV = &v)
            {
                byte ret = ImGuiNative.igDragFloat3(nativeLabel, nativeV, vSpeed, vMin, vMax, nativeFormat, flags);
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
        ///     Describes whether drag float 3
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="v">The </param>
        /// <param name="vSpeed">The speed</param>
        /// <param name="vMin">The min</param>
        /// <param name="vMax">The max</param>
        /// <returns>The bool</returns>
        public static bool DragFloat3(string label, ref Vector3 v, float vSpeed, float vMin, float vMax)
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
            fixed (Vector3* nativeV = &v)
            {
                byte ret = ImGuiNative.igDragFloat3(nativeLabel, nativeV, vSpeed, vMin, vMax, nativeFormat, flags);
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
        ///     Describes whether drag float 3
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="v">The </param>
        /// <param name="vSpeed">The speed</param>
        /// <param name="vMin">The min</param>
        /// <param name="vMax">The max</param>
        /// <param name="format">The format</param>
        /// <returns>The bool</returns>
        public static bool DragFloat3(string label, ref Vector3 v, float vSpeed, float vMin, float vMax, string format)
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
            fixed (Vector3* nativeV = &v)
            {
                byte ret = ImGuiNative.igDragFloat3(nativeLabel, nativeV, vSpeed, vMin, vMax, nativeFormat, flags);
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
        ///     Describes whether drag float 3
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="v">The </param>
        /// <param name="vSpeed">The speed</param>
        /// <param name="vMin">The min</param>
        /// <param name="vMax">The max</param>
        /// <param name="format">The format</param>
        /// <param name="flags">The flags</param>
        /// <returns>The bool</returns>
        public static bool DragFloat3(string label, ref Vector3 v, float vSpeed, float vMin, float vMax, string format, ImGuiSliderFlags flags)
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
            
            fixed (Vector3* nativeV = &v)
            {
                byte ret = ImGuiNative.igDragFloat3(nativeLabel, nativeV, vSpeed, vMin, vMax, nativeFormat, flags);
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
        ///     Describes whether drag float 4
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="v">The </param>
        /// <returns>The bool</returns>
        public static bool DragFloat4(string label, ref Vector4 v)
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
            float vMin = 0.0f;
            float vMax = 0.0f;
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
            byte ret = ImGuiNative.igDragFloat4(nativeLabel, v, vSpeed, vMin, vMax, nativeFormat, flags);
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
        ///     Describes whether drag float 4
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="v">The </param>
        /// <param name="vSpeed">The speed</param>
        /// <returns>The bool</returns>
        public static bool DragFloat4(string label, ref Vector4 v, float vSpeed)
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
            
            float vMin = 0.0f;
            float vMax = 0.0f;
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
            byte ret = ImGuiNative.igDragFloat4(nativeLabel, v, vSpeed, vMin, vMax, nativeFormat, flags);
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
        ///     Describes whether drag float 4
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="v">The </param>
        /// <param name="vSpeed">The speed</param>
        /// <param name="vMin">The min</param>
        /// <returns>The bool</returns>
        public static bool DragFloat4(string label, ref Vector4 v, float vSpeed, float vMin)
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
            
            float vMax = 0.0f;
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
            byte ret = ImGuiNative.igDragFloat4(nativeLabel, v, vSpeed, vMin, vMax, nativeFormat, flags);
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
        ///     Describes whether drag float 4
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="v">The </param>
        /// <param name="vSpeed">The speed</param>
        /// <param name="vMin">The min</param>
        /// <param name="vMax">The max</param>
        /// <returns>The bool</returns>
        public static bool DragFloat4(string label, ref Vector4 v, float vSpeed, float vMin, float vMax)
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
            byte ret = ImGuiNative.igDragFloat4(nativeLabel, v, vSpeed, vMin, vMax, nativeFormat, flags);
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
        ///     Describes whether drag float 4
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="v">The </param>
        /// <param name="vSpeed">The speed</param>
        /// <param name="vMin">The min</param>
        /// <param name="vMax">The max</param>
        /// <param name="format">The format</param>
        /// <returns>The bool</returns>
        public static bool DragFloat4(string label, ref Vector4 v, float vSpeed, float vMin, float vMax, string format)
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
            byte ret = ImGuiNative.igDragFloat4(nativeLabel, v, vSpeed, vMin, vMax, nativeFormat, flags);
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
        ///     Describes whether drag float 4
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="v">The </param>
        /// <param name="vSpeed">The speed</param>
        /// <param name="vMin">The min</param>
        /// <param name="vMax">The max</param>
        /// <param name="format">The format</param>
        /// <param name="flags">The flags</param>
        /// <returns>The bool</returns>
        public static bool DragFloat4(string label, ref Vector4 v, float vSpeed, float vMin, float vMax, string format, ImGuiSliderFlags flags)
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
            
            byte ret = ImGuiNative.igDragFloat4(nativeLabel, v, vSpeed, vMin, vMax, nativeFormat, flags);
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
        ///     Describes whether drag float range 2
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="vCurrentMin">The current min</param>
        /// <param name="vCurrentMax">The current max</param>
        /// <returns>The bool</returns>
        public static bool DragFloatRange2(string label, ref float vCurrentMin, ref float vCurrentMax)
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
            float vMin = 0.0f;
            float vMax = 0.0f;
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
            byte* nativeFormatMax = null;
            ImGuiSliderFlags flags = 0;
            fixed (float* nativeVCurrentMin = &vCurrentMin)
            {
                fixed (float* nativeVCurrentMax = &vCurrentMax)
                {
                    byte ret = ImGuiNative.igDragFloatRange2(nativeLabel, nativeVCurrentMin, nativeVCurrentMax, vSpeed, vMin, vMax, nativeFormat, nativeFormatMax, flags);
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
        ///     Describes whether drag float range 2
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="vCurrentMin">The current min</param>
        /// <param name="vCurrentMax">The current max</param>
        /// <param name="vSpeed">The speed</param>
        /// <returns>The bool</returns>
        public static bool DragFloatRange2(string label, ref float vCurrentMin, ref float vCurrentMax, float vSpeed)
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
            
            float vMin = 0.0f;
            float vMax = 0.0f;
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
            byte* nativeFormatMax = null;
            ImGuiSliderFlags flags = 0;
            fixed (float* nativeVCurrentMin = &vCurrentMin)
            {
                fixed (float* nativeVCurrentMax = &vCurrentMax)
                {
                    byte ret = ImGuiNative.igDragFloatRange2(nativeLabel, nativeVCurrentMin, nativeVCurrentMax, vSpeed, vMin, vMax, nativeFormat, nativeFormatMax, flags);
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
        ///     Describes whether drag float range 2
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="vCurrentMin">The current min</param>
        /// <param name="vCurrentMax">The current max</param>
        /// <param name="vSpeed">The speed</param>
        /// <param name="vMin">The min</param>
        /// <returns>The bool</returns>
        public static bool DragFloatRange2(string label, ref float vCurrentMin, ref float vCurrentMax, float vSpeed, float vMin)
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
            
            float vMax = 0.0f;
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
            byte* nativeFormatMax = null;
            ImGuiSliderFlags flags = 0;
            fixed (float* nativeVCurrentMin = &vCurrentMin)
            {
                fixed (float* nativeVCurrentMax = &vCurrentMax)
                {
                    byte ret = ImGuiNative.igDragFloatRange2(nativeLabel, nativeVCurrentMin, nativeVCurrentMax, vSpeed, vMin, vMax, nativeFormat, nativeFormatMax, flags);
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
        ///     Describes whether drag float range 2
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="vCurrentMin">The current min</param>
        /// <param name="vCurrentMax">The current max</param>
        /// <param name="vSpeed">The speed</param>
        /// <param name="vMin">The min</param>
        /// <param name="vMax">The max</param>
        /// <returns>The bool</returns>
        public static bool DragFloatRange2(string label, ref float vCurrentMin, ref float vCurrentMax, float vSpeed, float vMin, float vMax)
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
            byte* nativeFormatMax = null;
            ImGuiSliderFlags flags = 0;
            fixed (float* nativeVCurrentMin = &vCurrentMin)
            {
                fixed (float* nativeVCurrentMax = &vCurrentMax)
                {
                    byte ret = ImGuiNative.igDragFloatRange2(nativeLabel, nativeVCurrentMin, nativeVCurrentMax, vSpeed, vMin, vMax, nativeFormat, nativeFormatMax, flags);
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
        ///     Describes whether drag float range 2
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="vCurrentMin">The current min</param>
        /// <param name="vCurrentMax">The current max</param>
        /// <param name="vSpeed">The speed</param>
        /// <param name="vMin">The min</param>
        /// <param name="vMax">The max</param>
        /// <param name="format">The format</param>
        /// <returns>The bool</returns>
        public static bool DragFloatRange2(string label, ref float vCurrentMin, ref float vCurrentMax, float vSpeed, float vMin, float vMax, string format)
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
            fixed (float* nativeVCurrentMin = &vCurrentMin)
            {
                fixed (float* nativeVCurrentMax = &vCurrentMax)
                {
                    byte ret = ImGuiNative.igDragFloatRange2(nativeLabel, nativeVCurrentMin, nativeVCurrentMax, vSpeed, vMin, vMax, nativeFormat, nativeFormatMax, flags);
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
        ///     Describes whether drag float range 2
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
        public static bool DragFloatRange2(string label, ref float vCurrentMin, ref float vCurrentMax, float vSpeed, float vMin, float vMax, string format, string formatMax)
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
            fixed (float* nativeVCurrentMin = &vCurrentMin)
            {
                fixed (float* nativeVCurrentMax = &vCurrentMax)
                {
                    byte ret = ImGuiNative.igDragFloatRange2(nativeLabel, nativeVCurrentMin, nativeVCurrentMax, vSpeed, vMin, vMax, nativeFormat, nativeFormatMax, flags);
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
        ///     Describes whether drag float range 2
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
        public static bool DragFloatRange2(string label, ref float vCurrentMin, ref float vCurrentMax, float vSpeed, float vMin, float vMax, string format, string formatMax, ImGuiSliderFlags flags)
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
            
            fixed (float* nativeVCurrentMin = &vCurrentMin)
            {
                fixed (float* nativeVCurrentMax = &vCurrentMax)
                {
                    byte ret = ImGuiNative.igDragFloatRange2(nativeLabel, nativeVCurrentMin, nativeVCurrentMax, vSpeed, vMin, vMax, nativeFormat, nativeFormatMax, flags);
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
        ///     Describes whether drag int
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="v">The </param>
        /// <returns>The bool</returns>
        public static bool DragInt(string label, ref int v)
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
    }
}