// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImGuiP3.cs
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

namespace Alis.Extension.Graphic.ImGui
{
    public static unsafe partial class ImGui
    {
        /// <summary>
        ///     Describes whether is mouse down
        /// </summary>
        /// <param name="button">The button</param>
        /// <returns>The bool</returns>
        public static bool IsMouseDown(ImGuiMouseButton button)
        {
            byte ret = ImGuiNative.igIsMouseDown_Nil(button);
            return ret != 0;
        }
        
        /// <summary>
        ///     Describes whether is mouse dragging
        /// </summary>
        /// <param name="button">The button</param>
        /// <returns>The bool</returns>
        public static bool IsMouseDragging(ImGuiMouseButton button)
        {
            float lockThreshold = -1.0f;
            byte ret = ImGuiNative.igIsMouseDragging(button, lockThreshold);
            return ret != 0;
        }
        
        /// <summary>
        ///     Describes whether is mouse dragging
        /// </summary>
        /// <param name="button">The button</param>
        /// <param name="lockThreshold">The lock threshold</param>
        /// <returns>The bool</returns>
        public static bool IsMouseDragging(ImGuiMouseButton button, float lockThreshold)
        {
            byte ret = ImGuiNative.igIsMouseDragging(button, lockThreshold);
            return ret != 0;
        }
        
        /// <summary>
        ///     Describes whether is mouse hovering rect
        /// </summary>
        /// <param name="rMin">The min</param>
        /// <param name="rMax">The max</param>
        /// <returns>The bool</returns>
        public static bool IsMouseHoveringRect(Vector2 rMin, Vector2 rMax)
        {
            byte clip = 1;
            byte ret = ImGuiNative.igIsMouseHoveringRect(rMin, rMax, clip);
            return ret != 0;
        }
        
        /// <summary>
        ///     Describes whether is mouse hovering rect
        /// </summary>
        /// <param name="rMin">The min</param>
        /// <param name="rMax">The max</param>
        /// <param name="clip">The clip</param>
        /// <returns>The bool</returns>
        public static bool IsMouseHoveringRect(Vector2 rMin, Vector2 rMax, bool clip)
        {
            byte nativeClip = clip ? (byte) 1 : (byte) 0;
            byte ret = ImGuiNative.igIsMouseHoveringRect(rMin, rMax, nativeClip);
            return ret != 0;
        }
        
        /// <summary>
        ///     Describes whether is mouse pos valid
        /// </summary>
        /// <returns>The bool</returns>
        public static bool IsMousePosValid()
        {
            Vector2* mousePos = null;
            byte ret = ImGuiNative.igIsMousePosValid(mousePos);
            return ret != 0;
        }
        
        /// <summary>
        ///     Describes whether is mouse pos valid
        /// </summary>
        /// <param name="mousePos">The mouse pos</param>
        /// <returns>The bool</returns>
        public static bool IsMousePosValid(ref Vector2 mousePos)
        {
            fixed (Vector2* nativeMousePos = &mousePos)
            {
                byte ret = ImGuiNative.igIsMousePosValid(nativeMousePos);
                return ret != 0;
            }
        }
        
        /// <summary>
        ///     Describes whether is mouse released
        /// </summary>
        /// <param name="button">The button</param>
        /// <returns>The bool</returns>
        public static bool IsMouseReleased(ImGuiMouseButton button)
        {
            byte ret = ImGuiNative.igIsMouseReleased_Nil(button);
            return ret != 0;
        }
        
        /// <summary>
        ///     Describes whether is popup open
        /// </summary>
        /// <param name="strId">The str id</param>
        /// <returns>The bool</returns>
        public static bool IsPopupOpen(string strId)
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
            
            ImGuiPopupFlags flags = 0;
            byte ret = ImGuiNative.igIsPopupOpen_Str(nativeStrId, flags);
            if (strIdByteCount > Util.StackAllocationSizeLimit)
            {
                Util.Free(nativeStrId);
            }
            
            return ret != 0;
        }
        
        /// <summary>
        ///     Describes whether is popup open
        /// </summary>
        /// <param name="strId">The str id</param>
        /// <param name="flags">The flags</param>
        /// <returns>The bool</returns>
        public static bool IsPopupOpen(string strId, ImGuiPopupFlags flags)
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
            
            byte ret = ImGuiNative.igIsPopupOpen_Str(nativeStrId, flags);
            if (strIdByteCount > Util.StackAllocationSizeLimit)
            {
                Util.Free(nativeStrId);
            }
            
            return ret != 0;
        }
        
        /// <summary>
        ///     Describes whether is rect visible
        /// </summary>
        /// <param name="size">The size</param>
        /// <returns>The bool</returns>
        public static bool IsRectVisible(Vector2 size)
        {
            byte ret = ImGuiNative.igIsRectVisible_Nil(size);
            return ret != 0;
        }
        
        /// <summary>
        ///     Describes whether is rect visible
        /// </summary>
        /// <param name="rectMin">The rect min</param>
        /// <param name="rectMax">The rect max</param>
        /// <returns>The bool</returns>
        public static bool IsRectVisible(Vector2 rectMin, Vector2 rectMax)
        {
            byte ret = ImGuiNative.igIsRectVisible_Vec2(rectMin, rectMax);
            return ret != 0;
        }
        
        /// <summary>
        ///     Describes whether is window appearing
        /// </summary>
        /// <returns>The bool</returns>
        public static bool IsWindowAppearing()
        {
            byte ret = ImGuiNative.igIsWindowAppearing();
            return ret != 0;
        }
        
        /// <summary>
        ///     Describes whether is window collapsed
        /// </summary>
        /// <returns>The bool</returns>
        public static bool IsWindowCollapsed()
        {
            byte ret = ImGuiNative.igIsWindowCollapsed();
            return ret != 0;
        }
        
        /// <summary>
        ///     Describes whether is window docked
        /// </summary>
        /// <returns>The bool</returns>
        public static bool IsWindowDocked()
        {
            byte ret = ImGuiNative.igIsWindowDocked();
            return ret != 0;
        }
        
        /// <summary>
        ///     Describes whether is window focused
        /// </summary>
        /// <returns>The bool</returns>
        public static bool IsWindowFocused()
        {
            ImGuiFocusedFlags flags = 0;
            byte ret = ImGuiNative.igIsWindowFocused(flags);
            return ret != 0;
        }
        
        /// <summary>
        ///     Describes whether is window focused
        /// </summary>
        /// <param name="flags">The flags</param>
        /// <returns>The bool</returns>
        public static bool IsWindowFocused(ImGuiFocusedFlags flags)
        {
            byte ret = ImGuiNative.igIsWindowFocused(flags);
            return ret != 0;
        }
        
        /// <summary>
        ///     Describes whether is window hovered
        /// </summary>
        /// <returns>The bool</returns>
        public static bool IsWindowHovered()
        {
            ImGuiHoveredFlags flags = 0;
            byte ret = ImGuiNative.igIsWindowHovered(flags);
            return ret != 0;
        }
        
        /// <summary>
        ///     Describes whether is window hovered
        /// </summary>
        /// <param name="flags">The flags</param>
        /// <returns>The bool</returns>
        public static bool IsWindowHovered(ImGuiHoveredFlags flags)
        {
            byte ret = ImGuiNative.igIsWindowHovered(flags);
            return ret != 0;
        }
        
        /// <summary>
        ///     Labels the text using the specified label
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="fmt">The fmt</param>
        public static void LabelText(string label, string fmt)
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
            
            ImGuiNative.igLabelText(nativeLabel, nativeFmt);
            if (labelByteCount > Util.StackAllocationSizeLimit)
            {
                Util.Free(nativeLabel);
            }
            
            if (fmtByteCount > Util.StackAllocationSizeLimit)
            {
                Util.Free(nativeFmt);
            }
        }
        
        /// <summary>
        ///     Describes whether list box
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="currentItem">The current item</param>
        /// <param name="items">The items</param>
        /// <param name="itemsCount">The items count</param>
        /// <returns>The bool</returns>
        public static bool ListBox(string label, ref int currentItem, string[] items, int itemsCount)
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
            
            int heightInItems = -1;
            fixed (int* nativeCurrentItem = &currentItem)
            {
                byte ret = ImGuiNative.igListBox_Str_arr(nativeLabel, nativeCurrentItem, nativeItems, itemsCount, heightInItems);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeLabel);
                }
                
                return ret != 0;
            }
        }
        
        /// <summary>
        ///     Describes whether list box
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="currentItem">The current item</param>
        /// <param name="items">The items</param>
        /// <param name="itemsCount">The items count</param>
        /// <param name="heightInItems">The height in items</param>
        /// <returns>The bool</returns>
        public static bool ListBox(string label, ref int currentItem, string[] items, int itemsCount, int heightInItems)
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
                byte ret = ImGuiNative.igListBox_Str_arr(nativeLabel, nativeCurrentItem, nativeItems, itemsCount, heightInItems);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeLabel);
                }
                
                return ret != 0;
            }
        }
        
        /// <summary>
        ///     Loads the ini settings from disk using the specified ini filename
        /// </summary>
        /// <param name="iniFilename">The ini filename</param>
        public static void LoadIniSettingsFromDisk(string iniFilename)
        {
            byte* nativeIniFilename;
            int iniFilenameByteCount = 0;
            if (iniFilename != null)
            {
                iniFilenameByteCount = Encoding.UTF8.GetByteCount(iniFilename);
                if (iniFilenameByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeIniFilename = Util.Allocate(iniFilenameByteCount + 1);
                }
                else
                {
                    byte* nativeIniFilenameStackBytes = stackalloc byte[iniFilenameByteCount + 1];
                    nativeIniFilename = nativeIniFilenameStackBytes;
                }
                
                int nativeIniFilenameOffset = Util.GetUtf8(iniFilename, nativeIniFilename, iniFilenameByteCount);
                nativeIniFilename[nativeIniFilenameOffset] = 0;
            }
            else
            {
                nativeIniFilename = null;
            }
            
            ImGuiNative.igLoadIniSettingsFromDisk(nativeIniFilename);
            if (iniFilenameByteCount > Util.StackAllocationSizeLimit)
            {
                Util.Free(nativeIniFilename);
            }
        }
        
        /// <summary>
        ///     Loads the ini settings from memory using the specified ini data
        /// </summary>
        /// <param name="iniData">The ini data</param>
        public static void LoadIniSettingsFromMemory(string iniData)
        {
            byte* nativeIniData;
            int iniDataByteCount = 0;
            if (iniData != null)
            {
                iniDataByteCount = Encoding.UTF8.GetByteCount(iniData);
                if (iniDataByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeIniData = Util.Allocate(iniDataByteCount + 1);
                }
                else
                {
                    byte* nativeIniDataStackBytes = stackalloc byte[iniDataByteCount + 1];
                    nativeIniData = nativeIniDataStackBytes;
                }
                
                int nativeIniDataOffset = Util.GetUtf8(iniData, nativeIniData, iniDataByteCount);
                nativeIniData[nativeIniDataOffset] = 0;
            }
            else
            {
                nativeIniData = null;
            }
            
            uint iniSize = 0;
            ImGuiNative.igLoadIniSettingsFromMemory(nativeIniData, iniSize);
            if (iniDataByteCount > Util.StackAllocationSizeLimit)
            {
                Util.Free(nativeIniData);
            }
        }
        
        /// <summary>
        ///     Loads the ini settings from memory using the specified ini data
        /// </summary>
        /// <param name="iniData">The ini data</param>
        /// <param name="iniSize">The ini size</param>
        public static void LoadIniSettingsFromMemory(string iniData, uint iniSize)
        {
            byte* nativeIniData;
            int iniDataByteCount = 0;
            if (iniData != null)
            {
                iniDataByteCount = Encoding.UTF8.GetByteCount(iniData);
                if (iniDataByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeIniData = Util.Allocate(iniDataByteCount + 1);
                }
                else
                {
                    byte* nativeIniDataStackBytes = stackalloc byte[iniDataByteCount + 1];
                    nativeIniData = nativeIniDataStackBytes;
                }
                
                int nativeIniDataOffset = Util.GetUtf8(iniData, nativeIniData, iniDataByteCount);
                nativeIniData[nativeIniDataOffset] = 0;
            }
            else
            {
                nativeIniData = null;
            }
            
            ImGuiNative.igLoadIniSettingsFromMemory(nativeIniData, iniSize);
            if (iniDataByteCount > Util.StackAllocationSizeLimit)
            {
                Util.Free(nativeIniData);
            }
        }
        
        /// <summary>
        ///     Logs the buttons
        /// </summary>
        public static void LogButtons()
        {
            ImGuiNative.igLogButtons();
        }
        
        /// <summary>
        ///     Logs the finish
        /// </summary>
        public static void LogFinish()
        {
            ImGuiNative.igLogFinish();
        }
        
        /// <summary>
        ///     Logs the text using the specified fmt
        /// </summary>
        /// <param name="fmt">The fmt</param>
        public static void LogText(string fmt)
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
            
            ImGuiNative.igLogText(nativeFmt);
            if (fmtByteCount > Util.StackAllocationSizeLimit)
            {
                Util.Free(nativeFmt);
            }
        }
        
        /// <summary>
        ///     Logs the to clipboard
        /// </summary>
        public static void LogToClipboard()
        {
            int autoOpenDepth = -1;
            ImGuiNative.igLogToClipboard(autoOpenDepth);
        }
        
        /// <summary>
        ///     Logs the to clipboard using the specified auto open depth
        /// </summary>
        /// <param name="autoOpenDepth">The auto open depth</param>
        public static void LogToClipboard(int autoOpenDepth)
        {
            ImGuiNative.igLogToClipboard(autoOpenDepth);
        }
        
        /// <summary>
        ///     Logs the to file
        /// </summary>
        public static void LogToFile()
        {
            int autoOpenDepth = -1;
            byte* nativeFilename = null;
            ImGuiNative.igLogToFile(autoOpenDepth, nativeFilename);
        }
        
        /// <summary>
        ///     Logs the to file using the specified auto open depth
        /// </summary>
        /// <param name="autoOpenDepth">The auto open depth</param>
        public static void LogToFile(int autoOpenDepth)
        {
            byte* nativeFilename = null;
            ImGuiNative.igLogToFile(autoOpenDepth, nativeFilename);
        }
        
        /// <summary>
        ///     Logs the to file using the specified auto open depth
        /// </summary>
        /// <param name="autoOpenDepth">The auto open depth</param>
        /// <param name="filename">The filename</param>
        public static void LogToFile(int autoOpenDepth, string filename)
        {
            byte* nativeFilename;
            int filenameByteCount = 0;
            if (filename != null)
            {
                filenameByteCount = Encoding.UTF8.GetByteCount(filename);
                if (filenameByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeFilename = Util.Allocate(filenameByteCount + 1);
                }
                else
                {
                    byte* nativeFilenameStackBytes = stackalloc byte[filenameByteCount + 1];
                    nativeFilename = nativeFilenameStackBytes;
                }
                
                int nativeFilenameOffset = Util.GetUtf8(filename, nativeFilename, filenameByteCount);
                nativeFilename[nativeFilenameOffset] = 0;
            }
            else
            {
                nativeFilename = null;
            }
            
            ImGuiNative.igLogToFile(autoOpenDepth, nativeFilename);
            if (filenameByteCount > Util.StackAllocationSizeLimit)
            {
                Util.Free(nativeFilename);
            }
        }
        
        /// <summary>
        ///     Logs the to tty
        /// </summary>
        public static void LogToTty()
        {
            int autoOpenDepth = -1;
            ImGuiNative.igLogToTTY(autoOpenDepth);
        }
        
        /// <summary>
        ///     Logs the to tty using the specified auto open depth
        /// </summary>
        /// <param name="autoOpenDepth">The auto open depth</param>
        public static void LogToTty(int autoOpenDepth)
        {
            ImGuiNative.igLogToTTY(autoOpenDepth);
        }
        
        /// <summary>
        ///     Mems the alloc using the specified size
        /// </summary>
        /// <param name="size">The size</param>
        /// <returns>The int ptr</returns>
        public static IntPtr MemAlloc(uint size)
        {
            IntPtr ret = ImGuiNative.igMemAlloc(size);
            return ret;
        }
        
        /// <summary>
        ///     Mems the free using the specified ptr
        /// </summary>
        /// <param name="ptr">The ptr</param>
        public static void MemFree(IntPtr ptr)
        {
            IntPtr nativePtr = ptr;
            ImGuiNative.igMemFree(nativePtr);
        }
        
        /// <summary>
        ///     Describes whether menu item
        /// </summary>
        /// <param name="label">The label</param>
        /// <returns>The bool</returns>
        public static bool MenuItem(string label)
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
            
            byte* nativeShortcut = null;
            byte selected = 0;
            byte enabled = 1;
            byte ret = ImGuiNative.igMenuItem_Bool(nativeLabel, nativeShortcut, selected, enabled);
            if (labelByteCount > Util.StackAllocationSizeLimit)
            {
                Util.Free(nativeLabel);
            }
            
            return ret != 0;
        }
        
        /// <summary>
        ///     Describes whether menu item
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="shortcut">The shortcut</param>
        /// <returns>The bool</returns>
        public static bool MenuItem(string label, string shortcut)
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
            
            byte* nativeShortcut;
            int shortcutByteCount = 0;
            if (shortcut != null)
            {
                shortcutByteCount = Encoding.UTF8.GetByteCount(shortcut);
                if (shortcutByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeShortcut = Util.Allocate(shortcutByteCount + 1);
                }
                else
                {
                    byte* nativeShortcutStackBytes = stackalloc byte[shortcutByteCount + 1];
                    nativeShortcut = nativeShortcutStackBytes;
                }
                
                int nativeShortcutOffset = Util.GetUtf8(shortcut, nativeShortcut, shortcutByteCount);
                nativeShortcut[nativeShortcutOffset] = 0;
            }
            else
            {
                nativeShortcut = null;
            }
            
            byte selected = 0;
            byte enabled = 1;
            byte ret = ImGuiNative.igMenuItem_Bool(nativeLabel, nativeShortcut, selected, enabled);
            if (labelByteCount > Util.StackAllocationSizeLimit)
            {
                Util.Free(nativeLabel);
            }
            
            if (shortcutByteCount > Util.StackAllocationSizeLimit)
            {
                Util.Free(nativeShortcut);
            }
            
            return ret != 0;
        }
        
        /// <summary>
        ///     Describes whether menu item
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="shortcut">The shortcut</param>
        /// <param name="selected">The selected</param>
        /// <returns>The bool</returns>
        public static bool MenuItem(string label, string shortcut, bool selected)
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
            
            byte* nativeShortcut;
            int shortcutByteCount = 0;
            if (shortcut != null)
            {
                shortcutByteCount = Encoding.UTF8.GetByteCount(shortcut);
                if (shortcutByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeShortcut = Util.Allocate(shortcutByteCount + 1);
                }
                else
                {
                    byte* nativeShortcutStackBytes = stackalloc byte[shortcutByteCount + 1];
                    nativeShortcut = nativeShortcutStackBytes;
                }
                
                int nativeShortcutOffset = Util.GetUtf8(shortcut, nativeShortcut, shortcutByteCount);
                nativeShortcut[nativeShortcutOffset] = 0;
            }
            else
            {
                nativeShortcut = null;
            }
            
            byte nativeSelected = selected ? (byte) 1 : (byte) 0;
            byte enabled = 1;
            byte ret = ImGuiNative.igMenuItem_Bool(nativeLabel, nativeShortcut, nativeSelected, enabled);
            if (labelByteCount > Util.StackAllocationSizeLimit)
            {
                Util.Free(nativeLabel);
            }
            
            if (shortcutByteCount > Util.StackAllocationSizeLimit)
            {
                Util.Free(nativeShortcut);
            }
            
            return ret != 0;
        }
        
        /// <summary>
        ///     Describes whether menu item
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="shortcut">The shortcut</param>
        /// <param name="selected">The selected</param>
        /// <param name="enabled">The enabled</param>
        /// <returns>The bool</returns>
        public static bool MenuItem(string label, string shortcut, bool selected, bool enabled)
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
            
            byte* nativeShortcut;
            int shortcutByteCount = 0;
            if (shortcut != null)
            {
                shortcutByteCount = Encoding.UTF8.GetByteCount(shortcut);
                if (shortcutByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeShortcut = Util.Allocate(shortcutByteCount + 1);
                }
                else
                {
                    byte* nativeShortcutStackBytes = stackalloc byte[shortcutByteCount + 1];
                    nativeShortcut = nativeShortcutStackBytes;
                }
                
                int nativeShortcutOffset = Util.GetUtf8(shortcut, nativeShortcut, shortcutByteCount);
                nativeShortcut[nativeShortcutOffset] = 0;
            }
            else
            {
                nativeShortcut = null;
            }
            
            byte nativeSelected = selected ? (byte) 1 : (byte) 0;
            byte nativeEnabled = enabled ? (byte) 1 : (byte) 0;
            byte ret = ImGuiNative.igMenuItem_Bool(nativeLabel, nativeShortcut, nativeSelected, nativeEnabled);
            if (labelByteCount > Util.StackAllocationSizeLimit)
            {
                Util.Free(nativeLabel);
            }
            
            if (shortcutByteCount > Util.StackAllocationSizeLimit)
            {
                Util.Free(nativeShortcut);
            }
            
            return ret != 0;
        }
        
        /// <summary>
        ///     Describes whether menu item
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="shortcut">The shortcut</param>
        /// <param name="pSelected">The selected</param>
        /// <returns>The bool</returns>
        public static bool MenuItem(string label, string shortcut, ref bool pSelected)
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
            
            byte* nativeShortcut;
            int shortcutByteCount = 0;
            if (shortcut != null)
            {
                shortcutByteCount = Encoding.UTF8.GetByteCount(shortcut);
                if (shortcutByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeShortcut = Util.Allocate(shortcutByteCount + 1);
                }
                else
                {
                    byte* nativeShortcutStackBytes = stackalloc byte[shortcutByteCount + 1];
                    nativeShortcut = nativeShortcutStackBytes;
                }
                
                int nativeShortcutOffset = Util.GetUtf8(shortcut, nativeShortcut, shortcutByteCount);
                nativeShortcut[nativeShortcutOffset] = 0;
            }
            else
            {
                nativeShortcut = null;
            }
            
            byte nativePSelectedVal = pSelected ? (byte) 1 : (byte) 0;
            byte* nativePSelected = &nativePSelectedVal;
            byte enabled = 1;
            byte ret = ImGuiNative.igMenuItem_BoolPtr(nativeLabel, nativeShortcut, nativePSelected, enabled);
            if (labelByteCount > Util.StackAllocationSizeLimit)
            {
                Util.Free(nativeLabel);
            }
            
            if (shortcutByteCount > Util.StackAllocationSizeLimit)
            {
                Util.Free(nativeShortcut);
            }
            
            pSelected = nativePSelectedVal != 0;
            return ret != 0;
        }
        
        /// <summary>
        ///     Describes whether menu item
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="shortcut">The shortcut</param>
        /// <param name="pSelected">The selected</param>
        /// <param name="enabled">The enabled</param>
        /// <returns>The bool</returns>
        public static bool MenuItem(string label, string shortcut, ref bool pSelected, bool enabled)
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
            
            byte* nativeShortcut;
            int shortcutByteCount = 0;
            if (shortcut != null)
            {
                shortcutByteCount = Encoding.UTF8.GetByteCount(shortcut);
                if (shortcutByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeShortcut = Util.Allocate(shortcutByteCount + 1);
                }
                else
                {
                    byte* nativeShortcutStackBytes = stackalloc byte[shortcutByteCount + 1];
                    nativeShortcut = nativeShortcutStackBytes;
                }
                
                int nativeShortcutOffset = Util.GetUtf8(shortcut, nativeShortcut, shortcutByteCount);
                nativeShortcut[nativeShortcutOffset] = 0;
            }
            else
            {
                nativeShortcut = null;
            }
            
            byte nativePSelectedVal = pSelected ? (byte) 1 : (byte) 0;
            byte* nativePSelected = &nativePSelectedVal;
            byte nativeEnabled = enabled ? (byte) 1 : (byte) 0;
            byte ret = ImGuiNative.igMenuItem_BoolPtr(nativeLabel, nativeShortcut, nativePSelected, nativeEnabled);
            if (labelByteCount > Util.StackAllocationSizeLimit)
            {
                Util.Free(nativeLabel);
            }
            
            if (shortcutByteCount > Util.StackAllocationSizeLimit)
            {
                Util.Free(nativeShortcut);
            }
            
            pSelected = nativePSelectedVal != 0;
            return ret != 0;
        }
        
        /// <summary>
        ///     News the frame
        /// </summary>
        public static void NewFrame()
        {
            ImGuiNative.igNewFrame();
        }
        
        /// <summary>
        ///     News the line
        /// </summary>
        public static void NewLine()
        {
            ImGuiNative.igNewLine();
        }
        
        /// <summary>
        ///     Nexts the column
        /// </summary>
        public static void NextColumn()
        {
            ImGuiNative.igNextColumn();
        }
        
        /// <summary>
        ///     Opens the popup using the specified str id
        /// </summary>
        /// <param name="strId">The str id</param>
        public static void OpenPopup(string strId)
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
            
            ImGuiPopupFlags popupFlags = 0;
            ImGuiNative.igOpenPopup_Str(nativeStrId, popupFlags);
            if (strIdByteCount > Util.StackAllocationSizeLimit)
            {
                Util.Free(nativeStrId);
            }
        }
        
        /// <summary>
        ///     Opens the popup using the specified str id
        /// </summary>
        /// <param name="strId">The str id</param>
        /// <param name="popupFlags">The popup flags</param>
        public static void OpenPopup(string strId, ImGuiPopupFlags popupFlags)
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
            
            ImGuiNative.igOpenPopup_Str(nativeStrId, popupFlags);
            if (strIdByteCount > Util.StackAllocationSizeLimit)
            {
                Util.Free(nativeStrId);
            }
        }
        
        /// <summary>
        ///     Opens the popup using the specified id
        /// </summary>
        /// <param name="id">The id</param>
        public static void OpenPopup(uint id)
        {
            ImGuiPopupFlags popupFlags = 0;
            ImGuiNative.igOpenPopup_ID(id, popupFlags);
        }
        
        /// <summary>
        ///     Opens the popup using the specified id
        /// </summary>
        /// <param name="id">The id</param>
        /// <param name="popupFlags">The popup flags</param>
        public static void OpenPopup(uint id, ImGuiPopupFlags popupFlags)
        {
            ImGuiNative.igOpenPopup_ID(id, popupFlags);
        }
        
        /// <summary>
        ///     Opens the popup on item click
        /// </summary>
        public static void OpenPopupOnItemClick()
        {
            byte* nativeStrId = null;
            ImGuiPopupFlags popupFlags = (ImGuiPopupFlags) 1;
            ImGuiNative.igOpenPopupOnItemClick(nativeStrId, popupFlags);
        }
        
        /// <summary>
        ///     Opens the popup on item click using the specified str id
        /// </summary>
        /// <param name="strId">The str id</param>
        public static void OpenPopupOnItemClick(string strId)
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
            
            ImGuiPopupFlags popupFlags = (ImGuiPopupFlags) 1;
            ImGuiNative.igOpenPopupOnItemClick(nativeStrId, popupFlags);
            if (strIdByteCount > Util.StackAllocationSizeLimit)
            {
                Util.Free(nativeStrId);
            }
        }
        
        /// <summary>
        ///     Opens the popup on item click using the specified str id
        /// </summary>
        /// <param name="strId">The str id</param>
        /// <param name="popupFlags">The popup flags</param>
        public static void OpenPopupOnItemClick(string strId, ImGuiPopupFlags popupFlags)
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
            
            ImGuiNative.igOpenPopupOnItemClick(nativeStrId, popupFlags);
            if (strIdByteCount > Util.StackAllocationSizeLimit)
            {
                Util.Free(nativeStrId);
            }
        }
        
        /// <summary>
        ///     Plots the histogram using the specified label
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="values">The values</param>
        /// <param name="valuesCount">The values count</param>
        public static void PlotHistogram(string label, ref float values, int valuesCount)
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
            
            int valuesOffset = 0;
            byte* nativeOverlayText = null;
            float scaleMin = float.MaxValue;
            float scaleMax = float.MaxValue;
            Vector2 graphSize = new Vector2();
            int stride = sizeof(float);
            fixed (float* nativeValues = &values)
            {
                ImGuiNative.igPlotHistogram_FloatPtr(nativeLabel, nativeValues, valuesCount, valuesOffset, nativeOverlayText, scaleMin, scaleMax, graphSize, stride);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeLabel);
                }
            }
        }
        
        /// <summary>
        ///     Plots the histogram using the specified label
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="values">The values</param>
        /// <param name="valuesCount">The values count</param>
        /// <param name="valuesOffset">The values offset</param>
        public static void PlotHistogram(string label, ref float values, int valuesCount, int valuesOffset)
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
            
            byte* nativeOverlayText = null;
            float scaleMin = float.MaxValue;
            float scaleMax = float.MaxValue;
            Vector2 graphSize = new Vector2();
            int stride = sizeof(float);
            fixed (float* nativeValues = &values)
            {
                ImGuiNative.igPlotHistogram_FloatPtr(nativeLabel, nativeValues, valuesCount, valuesOffset, nativeOverlayText, scaleMin, scaleMax, graphSize, stride);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeLabel);
                }
            }
        }
        
        /// <summary>
        ///     Plots the histogram using the specified label
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="values">The values</param>
        /// <param name="valuesCount">The values count</param>
        /// <param name="valuesOffset">The values offset</param>
        /// <param name="overlayText">The overlay text</param>
        public static void PlotHistogram(string label, ref float values, int valuesCount, int valuesOffset, string overlayText)
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
            
            byte* nativeOverlayText;
            int overlayTextByteCount = 0;
            if (overlayText != null)
            {
                overlayTextByteCount = Encoding.UTF8.GetByteCount(overlayText);
                if (overlayTextByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeOverlayText = Util.Allocate(overlayTextByteCount + 1);
                }
                else
                {
                    byte* nativeOverlayTextStackBytes = stackalloc byte[overlayTextByteCount + 1];
                    nativeOverlayText = nativeOverlayTextStackBytes;
                }
                
                int nativeOverlayTextOffset = Util.GetUtf8(overlayText, nativeOverlayText, overlayTextByteCount);
                nativeOverlayText[nativeOverlayTextOffset] = 0;
            }
            else
            {
                nativeOverlayText = null;
            }
            
            float scaleMin = float.MaxValue;
            float scaleMax = float.MaxValue;
            Vector2 graphSize = new Vector2();
            int stride = sizeof(float);
            fixed (float* nativeValues = &values)
            {
                ImGuiNative.igPlotHistogram_FloatPtr(nativeLabel, nativeValues, valuesCount, valuesOffset, nativeOverlayText, scaleMin, scaleMax, graphSize, stride);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeLabel);
                }
                
                if (overlayTextByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeOverlayText);
                }
            }
        }
        
        /// <summary>
        ///     Plots the histogram using the specified label
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="values">The values</param>
        /// <param name="valuesCount">The values count</param>
        /// <param name="valuesOffset">The values offset</param>
        /// <param name="overlayText">The overlay text</param>
        /// <param name="scaleMin">The scale min</param>
        public static void PlotHistogram(string label, ref float values, int valuesCount, int valuesOffset, string overlayText, float scaleMin)
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
            
            byte* nativeOverlayText;
            int overlayTextByteCount = 0;
            if (overlayText != null)
            {
                overlayTextByteCount = Encoding.UTF8.GetByteCount(overlayText);
                if (overlayTextByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeOverlayText = Util.Allocate(overlayTextByteCount + 1);
                }
                else
                {
                    byte* nativeOverlayTextStackBytes = stackalloc byte[overlayTextByteCount + 1];
                    nativeOverlayText = nativeOverlayTextStackBytes;
                }
                
                int nativeOverlayTextOffset = Util.GetUtf8(overlayText, nativeOverlayText, overlayTextByteCount);
                nativeOverlayText[nativeOverlayTextOffset] = 0;
            }
            else
            {
                nativeOverlayText = null;
            }
            
            float scaleMax = float.MaxValue;
            Vector2 graphSize = new Vector2();
            int stride = sizeof(float);
            fixed (float* nativeValues = &values)
            {
                ImGuiNative.igPlotHistogram_FloatPtr(nativeLabel, nativeValues, valuesCount, valuesOffset, nativeOverlayText, scaleMin, scaleMax, graphSize, stride);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeLabel);
                }
                
                if (overlayTextByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeOverlayText);
                }
            }
        }
        
        /// <summary>
        ///     Plots the histogram using the specified label
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="values">The values</param>
        /// <param name="valuesCount">The values count</param>
        /// <param name="valuesOffset">The values offset</param>
        /// <param name="overlayText">The overlay text</param>
        /// <param name="scaleMin">The scale min</param>
        /// <param name="scaleMax">The scale max</param>
        public static void PlotHistogram(string label, ref float values, int valuesCount, int valuesOffset, string overlayText, float scaleMin, float scaleMax)
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
            
            byte* nativeOverlayText;
            int overlayTextByteCount = 0;
            if (overlayText != null)
            {
                overlayTextByteCount = Encoding.UTF8.GetByteCount(overlayText);
                if (overlayTextByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeOverlayText = Util.Allocate(overlayTextByteCount + 1);
                }
                else
                {
                    byte* nativeOverlayTextStackBytes = stackalloc byte[overlayTextByteCount + 1];
                    nativeOverlayText = nativeOverlayTextStackBytes;
                }
                
                int nativeOverlayTextOffset = Util.GetUtf8(overlayText, nativeOverlayText, overlayTextByteCount);
                nativeOverlayText[nativeOverlayTextOffset] = 0;
            }
            else
            {
                nativeOverlayText = null;
            }
            
            Vector2 graphSize = new Vector2();
            int stride = sizeof(float);
            fixed (float* nativeValues = &values)
            {
                ImGuiNative.igPlotHistogram_FloatPtr(nativeLabel, nativeValues, valuesCount, valuesOffset, nativeOverlayText, scaleMin, scaleMax, graphSize, stride);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeLabel);
                }
                
                if (overlayTextByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeOverlayText);
                }
            }
        }
        
        /// <summary>
        ///     Plots the histogram using the specified label
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="values">The values</param>
        /// <param name="valuesCount">The values count</param>
        /// <param name="valuesOffset">The values offset</param>
        /// <param name="overlayText">The overlay text</param>
        /// <param name="scaleMin">The scale min</param>
        /// <param name="scaleMax">The scale max</param>
        /// <param name="graphSize">The graph size</param>
        public static void PlotHistogram(string label, ref float values, int valuesCount, int valuesOffset, string overlayText, float scaleMin, float scaleMax, Vector2 graphSize)
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
            
            byte* nativeOverlayText;
            int overlayTextByteCount = 0;
            if (overlayText != null)
            {
                overlayTextByteCount = Encoding.UTF8.GetByteCount(overlayText);
                if (overlayTextByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeOverlayText = Util.Allocate(overlayTextByteCount + 1);
                }
                else
                {
                    byte* nativeOverlayTextStackBytes = stackalloc byte[overlayTextByteCount + 1];
                    nativeOverlayText = nativeOverlayTextStackBytes;
                }
                
                int nativeOverlayTextOffset = Util.GetUtf8(overlayText, nativeOverlayText, overlayTextByteCount);
                nativeOverlayText[nativeOverlayTextOffset] = 0;
            }
            else
            {
                nativeOverlayText = null;
            }
            
            int stride = sizeof(float);
            fixed (float* nativeValues = &values)
            {
                ImGuiNative.igPlotHistogram_FloatPtr(nativeLabel, nativeValues, valuesCount, valuesOffset, nativeOverlayText, scaleMin, scaleMax, graphSize, stride);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeLabel);
                }
                
                if (overlayTextByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeOverlayText);
                }
            }
        }
        
        /// <summary>
        ///     Plots the histogram using the specified label
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="values">The values</param>
        /// <param name="valuesCount">The values count</param>
        /// <param name="valuesOffset">The values offset</param>
        /// <param name="overlayText">The overlay text</param>
        /// <param name="scaleMin">The scale min</param>
        /// <param name="scaleMax">The scale max</param>
        /// <param name="graphSize">The graph size</param>
        /// <param name="stride">The stride</param>
        public static void PlotHistogram(string label, ref float values, int valuesCount, int valuesOffset, string overlayText, float scaleMin, float scaleMax, Vector2 graphSize, int stride)
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
            
            byte* nativeOverlayText;
            int overlayTextByteCount = 0;
            if (overlayText != null)
            {
                overlayTextByteCount = Encoding.UTF8.GetByteCount(overlayText);
                if (overlayTextByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeOverlayText = Util.Allocate(overlayTextByteCount + 1);
                }
                else
                {
                    byte* nativeOverlayTextStackBytes = stackalloc byte[overlayTextByteCount + 1];
                    nativeOverlayText = nativeOverlayTextStackBytes;
                }
                
                int nativeOverlayTextOffset = Util.GetUtf8(overlayText, nativeOverlayText, overlayTextByteCount);
                nativeOverlayText[nativeOverlayTextOffset] = 0;
            }
            else
            {
                nativeOverlayText = null;
            }
            
            fixed (float* nativeValues = &values)
            {
                ImGuiNative.igPlotHistogram_FloatPtr(nativeLabel, nativeValues, valuesCount, valuesOffset, nativeOverlayText, scaleMin, scaleMax, graphSize, stride);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeLabel);
                }
                
                if (overlayTextByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeOverlayText);
                }
            }
        }
        
        /// <summary>
        ///     Plots the lines using the specified label
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="values">The values</param>
        /// <param name="valuesCount">The values count</param>
        public static void PlotLines(string label, ref float values, int valuesCount)
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
            
            int valuesOffset = 0;
            byte* nativeOverlayText = null;
            float scaleMin = float.MaxValue;
            float scaleMax = float.MaxValue;
            Vector2 graphSize = new Vector2();
            int stride = sizeof(float);
            fixed (float* nativeValues = &values)
            {
                ImGuiNative.igPlotLines_FloatPtr(nativeLabel, nativeValues, valuesCount, valuesOffset, nativeOverlayText, scaleMin, scaleMax, graphSize, stride);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeLabel);
                }
            }
        }
        
        /// <summary>
        ///     Plots the lines using the specified label
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="values">The values</param>
        /// <param name="valuesCount">The values count</param>
        /// <param name="valuesOffset">The values offset</param>
        public static void PlotLines(string label, ref float values, int valuesCount, int valuesOffset)
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
            
            byte* nativeOverlayText = null;
            float scaleMin = float.MaxValue;
            float scaleMax = float.MaxValue;
            Vector2 graphSize = new Vector2();
            int stride = sizeof(float);
            fixed (float* nativeValues = &values)
            {
                ImGuiNative.igPlotLines_FloatPtr(nativeLabel, nativeValues, valuesCount, valuesOffset, nativeOverlayText, scaleMin, scaleMax, graphSize, stride);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeLabel);
                }
            }
        }
        
        /// <summary>
        ///     Plots the lines using the specified label
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="values">The values</param>
        /// <param name="valuesCount">The values count</param>
        /// <param name="valuesOffset">The values offset</param>
        /// <param name="overlayText">The overlay text</param>
        public static void PlotLines(string label, ref float values, int valuesCount, int valuesOffset, string overlayText)
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
            
            byte* nativeOverlayText;
            int overlayTextByteCount = 0;
            if (overlayText != null)
            {
                overlayTextByteCount = Encoding.UTF8.GetByteCount(overlayText);
                if (overlayTextByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeOverlayText = Util.Allocate(overlayTextByteCount + 1);
                }
                else
                {
                    byte* nativeOverlayTextStackBytes = stackalloc byte[overlayTextByteCount + 1];
                    nativeOverlayText = nativeOverlayTextStackBytes;
                }
                
                int nativeOverlayTextOffset = Util.GetUtf8(overlayText, nativeOverlayText, overlayTextByteCount);
                nativeOverlayText[nativeOverlayTextOffset] = 0;
            }
            else
            {
                nativeOverlayText = null;
            }
            
            float scaleMin = float.MaxValue;
            float scaleMax = float.MaxValue;
            Vector2 graphSize = new Vector2();
            int stride = sizeof(float);
            fixed (float* nativeValues = &values)
            {
                ImGuiNative.igPlotLines_FloatPtr(nativeLabel, nativeValues, valuesCount, valuesOffset, nativeOverlayText, scaleMin, scaleMax, graphSize, stride);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeLabel);
                }
                
                if (overlayTextByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeOverlayText);
                }
            }
        }
        
        /// <summary>
        ///     Plots the lines using the specified label
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="values">The values</param>
        /// <param name="valuesCount">The values count</param>
        /// <param name="valuesOffset">The values offset</param>
        /// <param name="overlayText">The overlay text</param>
        /// <param name="scaleMin">The scale min</param>
        public static void PlotLines(string label, ref float values, int valuesCount, int valuesOffset, string overlayText, float scaleMin)
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
            
            byte* nativeOverlayText;
            int overlayTextByteCount = 0;
            if (overlayText != null)
            {
                overlayTextByteCount = Encoding.UTF8.GetByteCount(overlayText);
                if (overlayTextByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeOverlayText = Util.Allocate(overlayTextByteCount + 1);
                }
                else
                {
                    byte* nativeOverlayTextStackBytes = stackalloc byte[overlayTextByteCount + 1];
                    nativeOverlayText = nativeOverlayTextStackBytes;
                }
                
                int nativeOverlayTextOffset = Util.GetUtf8(overlayText, nativeOverlayText, overlayTextByteCount);
                nativeOverlayText[nativeOverlayTextOffset] = 0;
            }
            else
            {
                nativeOverlayText = null;
            }
            
            float scaleMax = float.MaxValue;
            Vector2 graphSize = new Vector2();
            int stride = sizeof(float);
            fixed (float* nativeValues = &values)
            {
                ImGuiNative.igPlotLines_FloatPtr(nativeLabel, nativeValues, valuesCount, valuesOffset, nativeOverlayText, scaleMin, scaleMax, graphSize, stride);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeLabel);
                }
                
                if (overlayTextByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeOverlayText);
                }
            }
        }
        
        /// <summary>
        ///     Plots the lines using the specified label
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="values">The values</param>
        /// <param name="valuesCount">The values count</param>
        /// <param name="valuesOffset">The values offset</param>
        /// <param name="overlayText">The overlay text</param>
        /// <param name="scaleMin">The scale min</param>
        /// <param name="scaleMax">The scale max</param>
        public static void PlotLines(string label, ref float values, int valuesCount, int valuesOffset, string overlayText, float scaleMin, float scaleMax)
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
            
            byte* nativeOverlayText;
            int overlayTextByteCount = 0;
            if (overlayText != null)
            {
                overlayTextByteCount = Encoding.UTF8.GetByteCount(overlayText);
                if (overlayTextByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeOverlayText = Util.Allocate(overlayTextByteCount + 1);
                }
                else
                {
                    byte* nativeOverlayTextStackBytes = stackalloc byte[overlayTextByteCount + 1];
                    nativeOverlayText = nativeOverlayTextStackBytes;
                }
                
                int nativeOverlayTextOffset = Util.GetUtf8(overlayText, nativeOverlayText, overlayTextByteCount);
                nativeOverlayText[nativeOverlayTextOffset] = 0;
            }
            else
            {
                nativeOverlayText = null;
            }
            
            Vector2 graphSize = new Vector2();
            int stride = sizeof(float);
            fixed (float* nativeValues = &values)
            {
                ImGuiNative.igPlotLines_FloatPtr(nativeLabel, nativeValues, valuesCount, valuesOffset, nativeOverlayText, scaleMin, scaleMax, graphSize, stride);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeLabel);
                }
                
                if (overlayTextByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeOverlayText);
                }
            }
        }
        
        /// <summary>
        ///     Plots the lines using the specified label
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="values">The values</param>
        /// <param name="valuesCount">The values count</param>
        /// <param name="valuesOffset">The values offset</param>
        /// <param name="overlayText">The overlay text</param>
        /// <param name="scaleMin">The scale min</param>
        /// <param name="scaleMax">The scale max</param>
        /// <param name="graphSize">The graph size</param>
        public static void PlotLines(string label, ref float values, int valuesCount, int valuesOffset, string overlayText, float scaleMin, float scaleMax, Vector2 graphSize)
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
            
            byte* nativeOverlayText;
            int overlayTextByteCount = 0;
            if (overlayText != null)
            {
                overlayTextByteCount = Encoding.UTF8.GetByteCount(overlayText);
                if (overlayTextByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeOverlayText = Util.Allocate(overlayTextByteCount + 1);
                }
                else
                {
                    byte* nativeOverlayTextStackBytes = stackalloc byte[overlayTextByteCount + 1];
                    nativeOverlayText = nativeOverlayTextStackBytes;
                }
                
                int nativeOverlayTextOffset = Util.GetUtf8(overlayText, nativeOverlayText, overlayTextByteCount);
                nativeOverlayText[nativeOverlayTextOffset] = 0;
            }
            else
            {
                nativeOverlayText = null;
            }
            
            int stride = sizeof(float);
            fixed (float* nativeValues = &values)
            {
                ImGuiNative.igPlotLines_FloatPtr(nativeLabel, nativeValues, valuesCount, valuesOffset, nativeOverlayText, scaleMin, scaleMax, graphSize, stride);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeLabel);
                }
                
                if (overlayTextByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeOverlayText);
                }
            }
        }
        
        /// <summary>
        ///     Plots the lines using the specified label
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="values">The values</param>
        /// <param name="valuesCount">The values count</param>
        /// <param name="valuesOffset">The values offset</param>
        /// <param name="overlayText">The overlay text</param>
        /// <param name="scaleMin">The scale min</param>
        /// <param name="scaleMax">The scale max</param>
        /// <param name="graphSize">The graph size</param>
        /// <param name="stride">The stride</param>
        public static void PlotLines(string label, ref float values, int valuesCount, int valuesOffset, string overlayText, float scaleMin, float scaleMax, Vector2 graphSize, int stride)
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
            
            byte* nativeOverlayText;
            int overlayTextByteCount = 0;
            if (overlayText != null)
            {
                overlayTextByteCount = Encoding.UTF8.GetByteCount(overlayText);
                if (overlayTextByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeOverlayText = Util.Allocate(overlayTextByteCount + 1);
                }
                else
                {
                    byte* nativeOverlayTextStackBytes = stackalloc byte[overlayTextByteCount + 1];
                    nativeOverlayText = nativeOverlayTextStackBytes;
                }
                
                int nativeOverlayTextOffset = Util.GetUtf8(overlayText, nativeOverlayText, overlayTextByteCount);
                nativeOverlayText[nativeOverlayTextOffset] = 0;
            }
            else
            {
                nativeOverlayText = null;
            }
            
            fixed (float* nativeValues = &values)
            {
                ImGuiNative.igPlotLines_FloatPtr(nativeLabel, nativeValues, valuesCount, valuesOffset, nativeOverlayText, scaleMin, scaleMax, graphSize, stride);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeLabel);
                }
                
                if (overlayTextByteCount > Util.StackAllocationSizeLimit)
                {
                    Util.Free(nativeOverlayText);
                }
            }
        }
        
        /// <summary>
        ///     Pops the allow keyboard focus
        /// </summary>
        public static void PopAllowKeyboardFocus()
        {
            ImGuiNative.igPopAllowKeyboardFocus();
        }
        
        /// <summary>
        ///     Pops the button repeat
        /// </summary>
        public static void PopButtonRepeat()
        {
            ImGuiNative.igPopButtonRepeat();
        }
        
        /// <summary>
        ///     Pops the clip rect
        /// </summary>
        public static void PopClipRect()
        {
            ImGuiNative.igPopClipRect();
        }
        
        /// <summary>
        ///     Pops the font
        /// </summary>
        public static void PopFont()
        {
            ImGuiNative.igPopFont();
        }
        
        /// <summary>
        ///     Pops the id
        /// </summary>
        public static void PopId()
        {
            ImGuiNative.igPopID();
        }
        
        /// <summary>
        ///     Pops the item width
        /// </summary>
        public static void PopItemWidth()
        {
            ImGuiNative.igPopItemWidth();
        }
        
        /// <summary>
        ///     Pops the style color
        /// </summary>
        public static void PopStyleColor()
        {
            int count = 1;
            ImGuiNative.igPopStyleColor(count);
        }
        
        /// <summary>
        ///     Pops the style color using the specified count
        /// </summary>
        /// <param name="count">The count</param>
        public static void PopStyleColor(int count)
        {
            ImGuiNative.igPopStyleColor(count);
        }
        
        /// <summary>
        ///     Pops the style var
        /// </summary>
        public static void PopStyleVar()
        {
            int count = 1;
            ImGuiNative.igPopStyleVar(count);
        }
        
        /// <summary>
        ///     Pops the style var using the specified count
        /// </summary>
        /// <param name="count">The count</param>
        public static void PopStyleVar(int count)
        {
            ImGuiNative.igPopStyleVar(count);
        }
        
        /// <summary>
        ///     Pops the text wrap pos
        /// </summary>
        public static void PopTextWrapPos()
        {
            ImGuiNative.igPopTextWrapPos();
        }
        
        /// <summary>
        ///     Progresses the bar using the specified fraction
        /// </summary>
        /// <param name="fraction">The fraction</param>
        public static void ProgressBar(float fraction)
        {
            Vector2 sizeArg = new Vector2(-float.MinValue, 0.0f);
            byte* nativeOverlay = null;
            ImGuiNative.igProgressBar(fraction, sizeArg, nativeOverlay);
        }
        
        /// <summary>
        ///     Progresses the bar using the specified fraction
        /// </summary>
        /// <param name="fraction">The fraction</param>
        /// <param name="sizeArg">The size arg</param>
        public static void ProgressBar(float fraction, Vector2 sizeArg)
        {
            byte* nativeOverlay = null;
            ImGuiNative.igProgressBar(fraction, sizeArg, nativeOverlay);
        }
        
        /// <summary>
        ///     Progresses the bar using the specified fraction
        /// </summary>
        /// <param name="fraction">The fraction</param>
        /// <param name="sizeArg">The size arg</param>
        /// <param name="overlay">The overlay</param>
        public static void ProgressBar(float fraction, Vector2 sizeArg, string overlay)
        {
            byte* nativeOverlay;
            int overlayByteCount = 0;
            if (overlay != null)
            {
                overlayByteCount = Encoding.UTF8.GetByteCount(overlay);
                if (overlayByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeOverlay = Util.Allocate(overlayByteCount + 1);
                }
                else
                {
                    byte* nativeOverlayStackBytes = stackalloc byte[overlayByteCount + 1];
                    nativeOverlay = nativeOverlayStackBytes;
                }
                
                int nativeOverlayOffset = Util.GetUtf8(overlay, nativeOverlay, overlayByteCount);
                nativeOverlay[nativeOverlayOffset] = 0;
            }
            else
            {
                nativeOverlay = null;
            }
            
            ImGuiNative.igProgressBar(fraction, sizeArg, nativeOverlay);
            if (overlayByteCount > Util.StackAllocationSizeLimit)
            {
                Util.Free(nativeOverlay);
            }
        }
        
        /// <summary>
        ///     Pushes the allow keyboard focus using the specified allow keyboard focus
        /// </summary>
        /// <param name="allowKeyboardFocus">The allow keyboard focus</param>
        public static void PushAllowKeyboardFocus(bool allowKeyboardFocus)
        {
            byte nativeAllowKeyboardFocus = allowKeyboardFocus ? (byte) 1 : (byte) 0;
            ImGuiNative.igPushAllowKeyboardFocus(nativeAllowKeyboardFocus);
        }
        
        /// <summary>
        ///     Pushes the button repeat using the specified repeat
        /// </summary>
        /// <param name="repeat">The repeat</param>
        public static void PushButtonRepeat(bool repeat)
        {
            byte nativeRepeat = repeat ? (byte) 1 : (byte) 0;
            ImGuiNative.igPushButtonRepeat(nativeRepeat);
        }
        
        /// <summary>
        ///     Pushes the clip rect using the specified clip rect min
        /// </summary>
        /// <param name="clipRectMin">The clip rect min</param>
        /// <param name="clipRectMax">The clip rect max</param>
        /// <param name="intersectWithCurrentClipRect">The intersect with current clip rect</param>
        public static void PushClipRect(Vector2 clipRectMin, Vector2 clipRectMax, bool intersectWithCurrentClipRect)
        {
            byte nativeIntersectWithCurrentClipRect = intersectWithCurrentClipRect ? (byte) 1 : (byte) 0;
            ImGuiNative.igPushClipRect(clipRectMin, clipRectMax, nativeIntersectWithCurrentClipRect);
        }
        
        /// <summary>
        ///     Pushes the font using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        public static void PushFont(ImFontPtr font)
        {
            ImFont* nativeFont = font.NativePtr;
            ImGuiNative.igPushFont(nativeFont);
        }
        
        /// <summary>
        ///     Pushes the id using the specified str id
        /// </summary>
        /// <param name="strId">The str id</param>
        public static void PushId(string strId)
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
            
            ImGuiNative.igPushID_Str(nativeStrId);
            if (strIdByteCount > Util.StackAllocationSizeLimit)
            {
                Util.Free(nativeStrId);
            }
        }
        
        /// <summary>
        ///     Pushes the id using the specified ptr id
        /// </summary>
        /// <param name="ptrId">The ptr id</param>
        public static void PushId(IntPtr ptrId)
        {
            IntPtr nativePtrId = ptrId;
            ImGuiNative.igPushID_Ptr(nativePtrId);
        }
        
        /// <summary>
        ///     Pushes the id using the specified int id
        /// </summary>
        /// <param name="intId">The int id</param>
        public static void PushId(int intId)
        {
            ImGuiNative.igPushID_Int(intId);
        }
        
        /// <summary>
        ///     Pushes the item width using the specified item width
        /// </summary>
        /// <param name="itemWidth">The item width</param>
        public static void PushItemWidth(float itemWidth)
        {
            ImGuiNative.igPushItemWidth(itemWidth);
        }
        
        /// <summary>
        ///     Pushes the style color using the specified idx
        /// </summary>
        /// <param name="idx">The idx</param>
        /// <param name="col">The col</param>
        public static void PushStyleColor(ImGuiCol idx, uint col)
        {
            ImGuiNative.igPushStyleColor_U32(idx, col);
        }
        
        /// <summary>
        ///     Pushes the style color using the specified idx
        /// </summary>
        /// <param name="idx">The idx</param>
        /// <param name="col">The col</param>
        public static void PushStyleColor(ImGuiCol idx, Vector4 col)
        {
            ImGuiNative.igPushStyleColor_Vec4(idx, col);
        }
        
        /// <summary>
        ///     Pushes the style var using the specified idx
        /// </summary>
        /// <param name="idx">The idx</param>
        /// <param name="val">The val</param>
        public static void PushStyleVar(ImGuiStyleVar idx, float val)
        {
            ImGuiNative.igPushStyleVar_Float(idx, val);
        }
        
    }
}