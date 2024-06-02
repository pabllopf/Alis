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
using System.Reflection;
using System.Text;
using Alis.Core.Aspect.Data.Dll;
using Alis.Core.Aspect.Math.Vector;
using Alis.Extension.Graphic.ImGui.Properties;

namespace Alis.Extension.Graphic.ImGui
{
    public static unsafe partial class ImGui
    {
        /// <summary>
        ///     Describes whether color picker 3
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="col">The col</param>
        /// <param name="flags">The flags</param>
        /// <returns>The bool</returns>
        public static bool ColorPicker3(string label, ref Vector3 col, ImGuiColorEditFlags flags)
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
            
            fixed (Vector3* nativeCol = &col)
            {
                byte ret = ImGuiNative.igColorPicker3(nativeLabel, nativeCol, flags);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeLabel);
                }
                
                return ret != 0;
            }
        }
        
        /// <summary>
        ///     Describes whether color picker 4
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="col">The col</param>
        /// <returns>The bool</returns>
        public static bool ColorPicker4(string label, ref Vector4 col)
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
            
            ImGuiColorEditFlags flags = 0;
            float* refCol = null;
            byte ret = ImGuiNative.igColorPicker4(nativeLabel, col, flags, refCol);
            if (labelByteCount > Util.StackAllocationSizeLimit)
            {
                Util.Free(nativeLabel);
            }
            
            return ret != 0;
        }
        
        /// <summary>
        ///     Describes whether color picker 4
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="col">The col</param>
        /// <param name="flags">The flags</param>
        /// <returns>The bool</returns>
        public static bool ColorPicker4(string label, ref Vector4 col, ImGuiColorEditFlags flags)
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
            
            float* refCol = null;
            byte ret = ImGuiNative.igColorPicker4(nativeLabel, col, flags, refCol);
            if (labelByteCount > Util.StackAllocationSizeLimit)
            {
                Util.Free(nativeLabel);
            }
            
            return ret != 0;
        }
        
        /// <summary>
        ///     Describes whether color picker 4
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="col">The col</param>
        /// <param name="flags">The flags</param>
        /// <param name="refCol">The ref col</param>
        /// <returns>The bool</returns>
        public static bool ColorPicker4(string label, ref Vector4 col, ImGuiColorEditFlags flags, ref float refCol)
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
            
            fixed (float* nativeRefCol = &refCol)
            {
                byte ret = ImGuiNative.igColorPicker4(nativeLabel, col, flags, nativeRefCol);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeLabel);
                }
                
                return ret != 0;
            }
        }
        
        /// <summary>
        ///     Columnses
        /// </summary>
        public static void Columns()
        {
            int count = 1;
            byte* nativeId = null;
            byte border = 1;
            ImGuiNative.igColumns(count, nativeId, border);
        }
        
        /// <summary>
        ///     Columnses the count
        /// </summary>
        /// <param name="count">The count</param>
        public static void Columns(int count)
        {
            byte* nativeId = null;
            byte border = 1;
            ImGuiNative.igColumns(count, nativeId, border);
        }
        
        /// <summary>
        ///     Columnses the count
        /// </summary>
        /// <param name="count">The count</param>
        /// <param name="id">The id</param>
        public static void Columns(int count, string id)
        {
            byte* nativeId;
            int idByteCount = 0;
            if (id != null)
            {
                idByteCount = Encoding.UTF8.GetByteCount(id);
                if (idByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeId = Util.Allocate(idByteCount + 1);
                }
                else
                {
                    byte* nativeIdStackBytes = stackalloc byte[idByteCount + 1];
                    nativeId = nativeIdStackBytes;
                }
                
                int nativeIdOffset = Util.GetUtf8(id, nativeId, idByteCount);
                nativeId[nativeIdOffset] = 0;
            }
            else
            {
                nativeId = null;
            }
            
            byte border = 1;
            ImGuiNative.igColumns(count, nativeId, border);
            if (idByteCount > Util.StackAllocationSizeLimit)
            {
                Util.Free(nativeId);
            }
        }
        
        /// <summary>
        ///     Columnses the count
        /// </summary>
        /// <param name="count">The count</param>
        /// <param name="id">The id</param>
        /// <param name="border">The border</param>
        public static void Columns(int count, string id, bool border)
        {
            byte* nativeId;
            int idByteCount = 0;
            if (id != null)
            {
                idByteCount = Encoding.UTF8.GetByteCount(id);
                if (idByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeId = Util.Allocate(idByteCount + 1);
                }
                else
                {
                    byte* nativeIdStackBytes = stackalloc byte[idByteCount + 1];
                    nativeId = nativeIdStackBytes;
                }
                
                int nativeIdOffset = Util.GetUtf8(id, nativeId, idByteCount);
                nativeId[nativeIdOffset] = 0;
            }
            else
            {
                nativeId = null;
            }
            
            byte nativeBorder = border ? (byte) 1 : (byte) 0;
            ImGuiNative.igColumns(count, nativeId, nativeBorder);
            if (idByteCount > Util.StackAllocationSizeLimit)
            {
                Util.Free(nativeId);
            }
        }
        
        /// <summary>
        ///     Describes whether combo
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="currentItem">The current item</param>
        /// <param name="items">The items</param>
        /// <param name="itemsCount">The items count</param>
        /// <returns>The bool</returns>
        public static bool Combo(string label, ref int currentItem, string[] items, int itemsCount)
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
            
            int* itemsByteCounts = stackalloc int[items.Length];
            int itemsByteCount = 0;
            for (int i = 0; i < items.Length; i++)
            {
                string s = items[i];
                itemsByteCounts[i] = Encoding.UTF8.GetByteCount(s);
                itemsByteCount += itemsByteCounts[i] + 1;
            }
            
            byte* nativeItemsData = stackalloc byte[itemsByteCount];
            int offset = 0;
            for (int i = 0; i < items.Length; i++)
            {
                string s = items[i];
                fixed (char* sPtr = s)
                {
                    offset += Encoding.UTF8.GetBytes(sPtr, s.Length, nativeItemsData + offset, itemsByteCounts[i]);
                    nativeItemsData[offset] = 0;
                    offset += 1;
                }
            }
            
            byte** nativeItems = stackalloc byte*[items.Length];
            offset = 0;
            for (int i = 0; i < items.Length; i++)
            {
                nativeItems[i] = &nativeItemsData[offset];
                offset += itemsByteCounts[i] + 1;
            }
            
            int popupMaxHeightInItems = -1;
            fixed (int* nativeCurrentItem = &currentItem)
            {
                byte ret = ImGuiNative.igCombo_Str_arr(nativeLabel, nativeCurrentItem, nativeItems, itemsCount, popupMaxHeightInItems);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeLabel);
                }
                
                return ret != 0;
            }
        }
        
        /// <summary>
        ///     Describes whether combo
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="currentItem">The current item</param>
        /// <param name="items">The items</param>
        /// <param name="itemsCount">The items count</param>
        /// <param name="popupMaxHeightInItems">The popup max height in items</param>
        /// <returns>The bool</returns>
        public static bool Combo(string label, ref int currentItem, string[] items, int itemsCount, int popupMaxHeightInItems)
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
            
            int* itemsByteCounts = stackalloc int[items.Length];
            int itemsByteCount = 0;
            for (int i = 0; i < items.Length; i++)
            {
                string s = items[i];
                itemsByteCounts[i] = Encoding.UTF8.GetByteCount(s);
                itemsByteCount += itemsByteCounts[i] + 1;
            }
            
            byte* nativeItemsData = stackalloc byte[itemsByteCount];
            int offset = 0;
            for (int i = 0; i < items.Length; i++)
            {
                string s = items[i];
                fixed (char* sPtr = s)
                {
                    offset += Encoding.UTF8.GetBytes(sPtr, s.Length, nativeItemsData + offset, itemsByteCounts[i]);
                    nativeItemsData[offset] = 0;
                    offset += 1;
                }
            }
            
            byte** nativeItems = stackalloc byte*[items.Length];
            offset = 0;
            for (int i = 0; i < items.Length; i++)
            {
                nativeItems[i] = &nativeItemsData[offset];
                offset += itemsByteCounts[i] + 1;
            }
            
            fixed (int* nativeCurrentItem = &currentItem)
            {
                byte ret = ImGuiNative.igCombo_Str_arr(nativeLabel, nativeCurrentItem, nativeItems, itemsCount, popupMaxHeightInItems);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeLabel);
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
        
        
    }
}