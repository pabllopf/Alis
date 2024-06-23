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

namespace Alis.Extension.Graphic.ImGui.Native
{
    /// <summary>
    /// The im gui class
    /// </summary>
    public static unsafe partial class ImGui
    {
        
        
        /// <summary>
        ///     Describes whether drag scalar n
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="dataType">The data type</param>
        /// <param name="pData">The data</param>
        /// <param name="components">The components</param>
        /// <param name="vSpeed">The speed</param>
        /// <param name="pMin">The min</param>
        /// <param name="pMax">The max</param>
        /// <returns>The bool</returns>
        public static bool DragScalarN(string label, ImGuiDataType dataType, IntPtr pData, int components, float vSpeed, IntPtr pMin, IntPtr pMax)
        {
            byte ret = ImGuiNative.igDragScalarN(Encoding.UTF8.GetBytes(label), dataType, pData, components, vSpeed, pMin, pMax, Encoding.UTF8.GetBytes(""), 0);
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
        /// <param name="pMax">The max</param>
        /// <param name="format">The format</param>
        /// <returns>The bool</returns>
        public static bool DragScalarN(string label, ImGuiDataType dataType, IntPtr pData, int components, float vSpeed, IntPtr pMin, IntPtr pMax, string format)
        {
            byte ret = ImGuiNative.igDragScalarN(Encoding.UTF8.GetBytes(label), dataType, pData, components, vSpeed, pMin, pMax, Encoding.UTF8.GetBytes(format), 0);
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
        /// <param name="pMax">The max</param>
        /// <param name="format">The format</param>
        /// <param name="flags">The flags</param>
        /// <returns>The bool</returns>
        public static bool DragScalarN(string label, ImGuiDataType dataType, IntPtr pData, int components, float vSpeed, IntPtr pMin, IntPtr pMax, string format, ImGuiSliderFlags flags)
        {
            byte ret = ImGuiNative.igDragScalarN(Encoding.UTF8.GetBytes(label), dataType, pData, components, vSpeed, pMin, pMax, Encoding.UTF8.GetBytes(format), flags);
            return ret != 0;
        }
        
        /// <summary>
        ///     Dummies the size
        /// </summary>
        /// <param name="size">The size</param>
        public static void Dummy(Vector2 size)
        {
            ImGuiNative.igDummy(size);
        }
        
        /// <summary>
        ///     Ends
        /// </summary>
        public static void End()
        {
            ImGuiNative.igEnd();
        }
        
        /// <summary>
        ///     Ends the child
        /// </summary>
        public static void EndChild()
        {
            ImGuiNative.igEndChild();
        }
        
        /// <summary>
        ///     Ends the child frame
        /// </summary>
        public static void EndChildFrame()
        {
            ImGuiNative.igEndChildFrame();
        }
        
        /// <summary>
        ///     Ends the combo
        /// </summary>
        public static void EndCombo()
        {
            ImGuiNative.igEndCombo();
        }
        
        /// <summary>
        ///     Ends the disabled
        /// </summary>
        public static void EndDisabled()
        {
            ImGuiNative.igEndDisabled();
        }
        
        /// <summary>
        ///     Ends the drag drop source
        /// </summary>
        public static void EndDragDropSource()
        {
            ImGuiNative.igEndDragDropSource();
        }
        
        /// <summary>
        ///     Ends the drag drop target
        /// </summary>
        public static void EndDragDropTarget()
        {
            ImGuiNative.igEndDragDropTarget();
        }
        
        /// <summary>
        ///     Ends the frame
        /// </summary>
        public static void EndFrame()
        {
            ImGuiNative.igEndFrame();
        }
        
        /// <summary>
        ///     Ends the group
        /// </summary>
        public static void EndGroup()
        {
            ImGuiNative.igEndGroup();
        }
        
        /// <summary>
        ///     Ends the list box
        /// </summary>
        public static void EndListBox()
        {
            ImGuiNative.igEndListBox();
        }
        
        /// <summary>
        ///     Ends the main menu bar
        /// </summary>
        public static void EndMainMenuBar()
        {
            ImGuiNative.igEndMainMenuBar();
        }
        
        /// <summary>
        ///     Ends the menu
        /// </summary>
        public static void EndMenu()
        {
            ImGuiNative.igEndMenu();
        }
        
        /// <summary>
        ///     Ends the menu bar
        /// </summary>
        public static void EndMenuBar()
        {
            ImGuiNative.igEndMenuBar();
        }
        
        /// <summary>
        ///     Ends the popup
        /// </summary>
        public static void EndPopup()
        {
            ImGuiNative.igEndPopup();
        }
        
        /// <summary>
        ///     Ends the tab bar
        /// </summary>
        public static void EndTabBar()
        {
            ImGuiNative.igEndTabBar();
        }
        
        /// <summary>
        ///     Ends the tab item
        /// </summary>
        public static void EndTabItem()
        {
            ImGuiNative.igEndTabItem();
        }
        
        /// <summary>
        ///     Ends the table
        /// </summary>
        public static void EndTable()
        {
            ImGuiNative.igEndTable();
        }
        
        /// <summary>
        ///     Ends the tooltip
        /// </summary>
        public static void EndTooltip()
        {
            ImGuiNative.igEndTooltip();
        }
        
        /// <summary>
        ///     Finds the viewport by id using the specified id
        /// </summary>
        /// <param name="id">The id</param>
        /// <returns>The im gui viewport ptr</returns>
        public static ImGuiViewportPtr FindViewportById(uint id)
        {
            ImGuiViewport* ret = ImGuiNative.igFindViewportByID(id);
            return new ImGuiViewportPtr(ret);
        }
        
        /// <summary>
        ///     Finds the viewport by platform handle using the specified platform handle
        /// </summary>
        /// <param name="platformHandle">The platform handle</param>
        /// <returns>The im gui viewport ptr</returns>
        public static ImGuiViewportPtr FindViewportByPlatformHandle(IntPtr platformHandle)
        {
            IntPtr nativePlatformHandle = platformHandle;
            ImGuiViewport* ret = ImGuiNative.igFindViewportByPlatformHandle(nativePlatformHandle);
            return new ImGuiViewportPtr(ret);
        }
        
        /// <summary>
        ///     Gets the allocator functions using the specified p alloc func
        /// </summary>
        /// <param name="pAllocFunc">The alloc func</param>
        /// <param name="pFreeFunc">The free func</param>
        /// <param name="pUserData">The user data</param>
        public static void GetAllocatorFunctions(ref IntPtr pAllocFunc, ref IntPtr pFreeFunc, ref IntPtr pUserData)
        {
            fixed (IntPtr* nativePAllocFunc = &pAllocFunc)
            {
                fixed (IntPtr* nativePFreeFunc = &pFreeFunc)
                {
                    fixed (void* nativePUserData = &pUserData)
                    {
                        ImGuiNative.igGetAllocatorFunctions(nativePAllocFunc, nativePFreeFunc, nativePUserData);
                    }
                }
            }
        }
        
        /// <summary>
        ///     Gets the background draw list
        /// </summary>
        /// <returns>The im draw list ptr</returns>
        public static ImDrawListPtr GetBackgroundDrawList()
        {
            ImDrawList* ret = ImGuiNative.igGetBackgroundDrawList_Nil();
            return new ImDrawListPtr(ret);
        }
        
        /// <summary>
        ///     Gets the background draw list using the specified viewport
        /// </summary>
        /// <param name="viewport">The viewport</param>
        /// <returns>The im draw list ptr</returns>
        public static ImDrawListPtr GetBackgroundDrawList(ImGuiViewportPtr viewport)
        {
            ImGuiViewport* nativeViewport = viewport.NativePtr;
            ImDrawList* ret = ImGuiNative.igGetBackgroundDrawList_ViewportPtr(nativeViewport);
            return new ImDrawListPtr(ret);
        }
        
        /// <summary>
        ///     Gets the clipboard text
        /// </summary>
        /// <returns>The string</returns>
        public static string GetClipboardText()
        {
            byte* ret = ImGuiNative.igGetClipboardText();
            return Util.StringFromPtr(ret);
        }
        
        /// <summary>
        ///     Gets the color u 32 using the specified idx
        /// </summary>
        /// <param name="idx">The idx</param>
        /// <returns>The ret</returns>
        public static uint GetColorU32(ImGuiCol idx)
        {
            float alphaMul = 1.0f;
            uint ret = ImGuiNative.igGetColorU32_Col(idx, alphaMul);
            return ret;
        }
        
        /// <summary>
        ///     Gets the color u 32 using the specified idx
        /// </summary>
        /// <param name="idx">The idx</param>
        /// <param name="alphaMul">The alpha mul</param>
        /// <returns>The ret</returns>
        public static uint GetColorU32(ImGuiCol idx, float alphaMul)
        {
            uint ret = ImGuiNative.igGetColorU32_Col(idx, alphaMul);
            return ret;
        }
        
        /// <summary>
        ///     Gets the color u 32 using the specified col
        /// </summary>
        /// <param name="col">The col</param>
        /// <returns>The ret</returns>
        public static uint GetColorU32(Vector4 col)
        {
            uint ret = ImGuiNative.igGetColorU32_Vec4(col);
            return ret;
        }
        
        /// <summary>
        ///     Gets the color u 32 using the specified col
        /// </summary>
        /// <param name="col">The col</param>
        /// <returns>The ret</returns>
        public static uint GetColorU32(uint col)
        {
            uint ret = ImGuiNative.igGetColorU32_U32(col);
            return ret;
        }
        
        /// <summary>
        ///     Gets the column index
        /// </summary>
        /// <returns>The ret</returns>
        public static int GetColumnIndex()
        {
            int ret = ImGuiNative.igGetColumnIndex();
            return ret;
        }
        
        /// <summary>
        ///     Gets the column offset
        /// </summary>
        /// <returns>The ret</returns>
        public static float GetColumnOffset()
        {
            int columnIndex = -1;
            float ret = ImGuiNative.igGetColumnOffset(columnIndex);
            return ret;
        }
        
        /// <summary>
        ///     Gets the column offset using the specified column index
        /// </summary>
        /// <param name="columnIndex">The column index</param>
        /// <returns>The ret</returns>
        public static float GetColumnOffset(int columnIndex)
        {
            float ret = ImGuiNative.igGetColumnOffset(columnIndex);
            return ret;
        }
        
        /// <summary>
        ///     Gets the columns count
        /// </summary>
        /// <returns>The ret</returns>
        public static int GetColumnsCount()
        {
            int ret = ImGuiNative.igGetColumnsCount();
            return ret;
        }
        
        /// <summary>
        ///     Gets the column width
        /// </summary>
        /// <returns>The ret</returns>
        public static float GetColumnWidth()
        {
            int columnIndex = -1;
            float ret = ImGuiNative.igGetColumnWidth(columnIndex);
            return ret;
        }
        
        /// <summary>
        ///     Gets the column width using the specified column index
        /// </summary>
        /// <param name="columnIndex">The column index</param>
        /// <returns>The ret</returns>
        public static float GetColumnWidth(int columnIndex)
        {
            float ret = ImGuiNative.igGetColumnWidth(columnIndex);
            return ret;
        }
        
        /// <summary>
        ///     Gets the content region avail
        /// </summary>
        /// <returns>The retval</returns>
        public static Vector2 GetContentRegionAvail()
        {
            Vector2 retval;
            ImGuiNative.igGetContentRegionAvail(out retval);
            return retval;
        }
        
        /// <summary>
        ///     Gets the content region max
        /// </summary>
        /// <returns>The retval</returns>
        public static Vector2 GetContentRegionMax()
        {
            Vector2 retval;
            ImGuiNative.igGetContentRegionMax(out retval);
            return retval;
        }
        
        /// <summary>
        ///     Gets the current context
        /// </summary>
        /// <returns>The ret</returns>
        public static IntPtr GetCurrentContext()
        {
            IntPtr ret = ImGuiNative.igGetCurrentContext();
            return ret;
        }
        
        /// <summary>
        ///     Gets the cursor pos
        /// </summary>
        /// <returns>The retval</returns>
        public static Vector2 GetCursorPos()
        {
            Vector2 retval;
            ImGuiNative.igGetCursorPos(out retval);
            return retval;
        }
        
        /// <summary>
        ///     Gets the cursor pos x
        /// </summary>
        /// <returns>The ret</returns>
        public static float GetCursorPosX()
        {
            float ret = ImGuiNative.igGetCursorPosX();
            return ret;
        }
        
        /// <summary>
        ///     Gets the cursor pos y
        /// </summary>
        /// <returns>The ret</returns>
        public static float GetCursorPosY()
        {
            float ret = ImGuiNative.igGetCursorPosY();
            return ret;
        }
        
        /// <summary>
        ///     Gets the cursor screen pos
        /// </summary>
        /// <returns>The retval</returns>
        public static Vector2 GetCursorScreenPos()
        {
            Vector2 retval;
            ImGuiNative.igGetCursorScreenPos(out retval);
            return retval;
        }
        
        /// <summary>
        ///     Gets the cursor start pos
        /// </summary>
        /// <returns>The retval</returns>
        public static Vector2 GetCursorStartPos()
        {
            Vector2 retval;
            ImGuiNative.igGetCursorStartPos(out retval);
            return retval;
        }
        
        /// <summary>
        ///     Gets the drag drop payload
        /// </summary>
        /// <returns>The im gui payload ptr</returns>
        public static ImGuiPayload GetDragDropPayload() => ImGuiNative.igGetDragDropPayload();
        
        /// <summary>
        ///     Gets the draw data
        /// </summary>
        /// <returns>The im draw data ptr</returns>
        public static ImDrawData GetDrawData() => ImGuiNative.igGetDrawData();
        
        /// <summary>
        ///     Gets the draw list shared data
        /// </summary>
        /// <returns>The ret</returns>
        public static IntPtr GetDrawListSharedData()
        {
            IntPtr ret = ImGuiNative.igGetDrawListSharedData();
            return ret;
        }
        
        /// <summary>
        ///     Gets the font
        /// </summary>
        /// <returns>The im font ptr</returns>
        public static ImFontPtr GetFont()
        {
            ImFont* ret = ImGuiNative.igGetFont();
            return new ImFontPtr(ret);
        }
        
        /// <summary>
        ///     Gets the font size
        /// </summary>
        /// <returns>The ret</returns>
        public static float GetFontSize()
        {
            float ret = ImGuiNative.igGetFontSize();
            return ret;
        }
        
        /// <summary>
        ///     Gets the font tex uv white pixel
        /// </summary>
        /// <returns>The retval</returns>
        public static Vector2 GetFontTexUvWhitePixel()
        {
            Vector2 retval;
            ImGuiNative.igGetFontTexUvWhitePixel(out retval);
            return retval;
        }
        
        /// <summary>
        ///     Gets the foreground draw list
        /// </summary>
        /// <returns>The im draw list ptr</returns>
        public static ImDrawListPtr GetForegroundDrawList()
        {
            ImDrawList* ret = ImGuiNative.igGetForegroundDrawList_Nil();
            return new ImDrawListPtr(ret);
        }
        
        /// <summary>
        ///     Gets the foreground draw list using the specified viewport
        /// </summary>
        /// <param name="viewport">The viewport</param>
        /// <returns>The im draw list ptr</returns>
        public static ImDrawListPtr GetForegroundDrawList(ImGuiViewportPtr viewport)
        {
            ImGuiViewport* nativeViewport = viewport.NativePtr;
            ImDrawList* ret = ImGuiNative.igGetForegroundDrawList_ViewportPtr(nativeViewport);
            return new ImDrawListPtr(ret);
        }
        
        /// <summary>
        ///     Gets the frame count
        /// </summary>
        /// <returns>The ret</returns>
        public static int GetFrameCount()
        {
            int ret = ImGuiNative.igGetFrameCount();
            return ret;
        }
        
        /// <summary>
        ///     Gets the frame height
        /// </summary>
        /// <returns>The ret</returns>
        public static float GetFrameHeight()
        {
            float ret = ImGuiNative.igGetFrameHeight();
            return ret;
        }
        
        /// <summary>
        ///     Gets the frame height with spacing
        /// </summary>
        /// <returns>The ret</returns>
        public static float GetFrameHeightWithSpacing()
        {
            float ret = ImGuiNative.igGetFrameHeightWithSpacing();
            return ret;
        }
        
        /// <summary>
        ///     Gets the id using the specified str id
        /// </summary>
        /// <param name="strId">The str id</param>
        /// <returns>The ret</returns>
        public static uint GetId(string strId)
        {
            uint ret = ImGuiNative.igGetID_Str(Encoding.UTF8.GetBytes(strId));
            return ret;
        }
        
        /// <summary>
        ///     Gets the id using the specified ptr id
        /// </summary>
        /// <param name="ptrId">The ptr id</param>
        /// <returns>The ret</returns>
        public static uint GetId(IntPtr ptrId)
        {
            IntPtr nativePtrId = ptrId;
            uint ret = ImGuiNative.igGetID_Ptr(nativePtrId);
            return ret;
        }
        
        /// <summary>
        ///     Gets the io
        /// </summary>
        /// <returns>The im gui io ptr</returns>
        public static ImGuiIoPtr GetIo()
        {
            ImGuiIo* ret = ImGuiNative.igGetIO();
            return new ImGuiIoPtr(ret);
        }
        
        /// <summary>
        ///     Gets the item rect max
        /// </summary>
        /// <returns>The retval</returns>
        public static Vector2 GetItemRectMax()
        {
            Vector2 retval;
            ImGuiNative.igGetItemRectMax(out retval);
            return retval;
        }
        
        /// <summary>
        ///     Gets the item rect min
        /// </summary>
        /// <returns>The retval</returns>
        public static Vector2 GetItemRectMin()
        {
            Vector2 retval;
            ImGuiNative.igGetItemRectMin(out retval);
            return retval;
        }
        
        /// <summary>
        ///     Gets the item rect size
        /// </summary>
        /// <returns>The retval</returns>
        public static Vector2 GetItemRectSize()
        {
            Vector2 retval;
            ImGuiNative.igGetItemRectSize(out retval);
            return retval;
        }
        
        /// <summary>
        ///     Gets the key index using the specified key
        /// </summary>
        /// <param name="key">The key</param>
        /// <returns>The ret</returns>
        public static ImGuiKey GetKeyIndex(ImGuiKey key)
        {
            ImGuiKey ret = ImGuiNative.igGetKeyIndex(key);
            return ret;
        }
        
        /// <summary>
        ///     Gets the key name using the specified key
        /// </summary>
        /// <param name="key">The key</param>
        /// <returns>The string</returns>
        public static string GetKeyName(ImGuiKey key)
        {
            byte* ret = ImGuiNative.igGetKeyName(key);
            return Util.StringFromPtr(ret);
        }
        
        /// <summary>
        ///     Gets the key pressed amount using the specified key
        /// </summary>
        /// <param name="key">The key</param>
        /// <param name="repeatDelay">The repeat delay</param>
        /// <param name="rate">The rate</param>
        /// <returns>The ret</returns>
        public static int GetKeyPressedAmount(ImGuiKey key, float repeatDelay, float rate)
        {
            int ret = ImGuiNative.igGetKeyPressedAmount(key, repeatDelay, rate);
            return ret;
        }
        
        /// <summary>
        ///     Gets the main viewport
        /// </summary>
        /// <returns>The im gui viewport ptr</returns>
        public static ImGuiViewportPtr GetMainViewport()
        {
            ImGuiViewport* ret = ImGuiNative.igGetMainViewport();
            return new ImGuiViewportPtr(ret);
        }
        
        /// <summary>
        ///     Gets the mouse clicked count using the specified button
        /// </summary>
        /// <param name="button">The button</param>
        /// <returns>The ret</returns>
        public static int GetMouseClickedCount(ImGuiMouseButton button)
        {
            int ret = ImGuiNative.igGetMouseClickedCount(button);
            return ret;
        }
        
        /// <summary>
        ///     Gets the mouse cursor
        /// </summary>
        /// <returns>The ret</returns>
        public static ImGuiMouseCursor GetMouseCursor()
        {
            ImGuiMouseCursor ret = ImGuiNative.igGetMouseCursor();
            return ret;
        }
        
        /// <summary>
        ///     Gets the mouse drag delta
        /// </summary>
        /// <returns>The retval</returns>
        public static Vector2 GetMouseDragDelta()
        {
            Vector2 retval;
            ImGuiMouseButton button = 0;
            float lockThreshold = -1.0f;
            ImGuiNative.igGetMouseDragDelta(out retval, button, lockThreshold);
            return retval;
        }
        
        /// <summary>
        ///     Gets the mouse drag delta using the specified button
        /// </summary>
        /// <param name="button">The button</param>
        /// <returns>The retval</returns>
        public static Vector2 GetMouseDragDelta(ImGuiMouseButton button)
        {
            Vector2 retval;
            float lockThreshold = -1.0f;
            ImGuiNative.igGetMouseDragDelta(out retval, button, lockThreshold);
            return retval;
        }
        
        /// <summary>
        ///     Gets the mouse drag delta using the specified button
        /// </summary>
        /// <param name="button">The button</param>
        /// <param name="lockThreshold">The lock threshold</param>
        /// <returns>The retval</returns>
        public static Vector2 GetMouseDragDelta(ImGuiMouseButton button, float lockThreshold)
        {
            Vector2 retval;
            ImGuiNative.igGetMouseDragDelta(out retval, button, lockThreshold);
            return retval;
        }
        
        /// <summary>
        ///     Gets the mouse pos
        /// </summary>
        /// <returns>The retval</returns>
        public static Vector2 GetMousePos()
        {
            Vector2 retval;
            ImGuiNative.igGetMousePos(out retval);
            return retval;
        }
        
        /// <summary>
        ///     Gets the mouse pos on opening current popup
        /// </summary>
        /// <returns>The retval</returns>
        public static Vector2 GetMousePosOnOpeningCurrentPopup()
        {
            Vector2 retval;
            ImGuiNative.igGetMousePosOnOpeningCurrentPopup(out retval);
            return retval;
        }
        
        /// <summary>
        ///     Gets the platform io
        /// </summary>
        /// <returns>The im gui platform io ptr</returns>
        public static ImGuiPlatformIoPtr GetPlatformIo()
        {
            ImGuiPlatformIo* ret = ImGuiNative.igGetPlatformIO();
            return new ImGuiPlatformIoPtr(ret);
        }
        
        /// <summary>
        ///     Gets the scroll max x
        /// </summary>
        /// <returns>The ret</returns>
        public static float GetScrollMaxX()
        {
            float ret = ImGuiNative.igGetScrollMaxX();
            return ret;
        }
        
        /// <summary>
        ///     Gets the scroll max y
        /// </summary>
        /// <returns>The ret</returns>
        public static float GetScrollMaxY()
        {
            float ret = ImGuiNative.igGetScrollMaxY();
            return ret;
        }
        
        /// <summary>
        ///     Gets the scroll x
        /// </summary>
        /// <returns>The ret</returns>
        public static float GetScrollX()
        {
            float ret = ImGuiNative.igGetScrollX();
            return ret;
        }
        
        /// <summary>
        ///     Gets the scroll y
        /// </summary>
        /// <returns>The ret</returns>
        public static float GetScrollY()
        {
            float ret = ImGuiNative.igGetScrollY();
            return ret;
        }
        
        /// <summary>
        ///     Gets the state storage
        /// </summary>
        /// <returns>The im gui storage ptr</returns>
        public static ImGuiStorage GetStateStorage() => ImGuiNative.igGetStateStorage();
        
        /// <summary>
        ///     Gets the style
        /// </summary>
        /// <returns>The im gui style ptr</returns>
        public static ImGuiStyle GetStyle() => ImGuiNative.igGetStyle();
        
        /// <summary>
        ///     Gets the style color name using the specified idx
        /// </summary>
        /// <param name="idx">The idx</param>
        /// <returns>The string</returns>
        public static string GetStyleColorName(ImGuiCol idx)
        {
            byte* ret = ImGuiNative.igGetStyleColorName(idx);
            return Util.StringFromPtr(ret);
        }
        
        /// <summary>
        ///     Gets the style color vec 4 using the specified idx
        /// </summary>
        /// <param name="idx">The idx</param>
        /// <returns>The ret</returns>
        public static Vector4 GetStyleColorVec4(ImGuiCol idx)
        {
            Vector4 ret = ImGuiNative.igGetStyleColorVec4(idx);
            return ret;
        }
        
        /// <summary>
        ///     Gets the text line height
        /// </summary>
        /// <returns>The ret</returns>
        public static float GetTextLineHeight()
        {
            float ret = ImGuiNative.igGetTextLineHeight();
            return ret;
        }
        
        /// <summary>
        ///     Gets the text line height with spacing
        /// </summary>
        /// <returns>The ret</returns>
        public static float GetTextLineHeightWithSpacing()
        {
            float ret = ImGuiNative.igGetTextLineHeightWithSpacing();
            return ret;
        }
        
        /// <summary>
        ///     Gets the time
        /// </summary>
        /// <returns>The ret</returns>
        public static double GetTime()
        {
            double ret = ImGuiNative.igGetTime();
            return ret;
        }
        
        /// <summary>
        ///     Gets the tree node to label spacing
        /// </summary>
        /// <returns>The ret</returns>
        public static float GetTreeNodeToLabelSpacing()
        {
            float ret = ImGuiNative.igGetTreeNodeToLabelSpacing();
            return ret;
        }
        
        /// <summary>
        ///     Gets the version
        /// </summary>
        /// <returns>The string</returns>
        public static string GetVersion()
        {
            byte* ret = ImGuiNative.igGetVersion();
            return Util.StringFromPtr(ret);
        }
        
        /// <summary>
        ///     Gets the window content region max
        /// </summary>
        /// <returns>The retval</returns>
        public static Vector2 GetWindowContentRegionMax()
        {
            Vector2 retval;
            ImGuiNative.igGetWindowContentRegionMax(out retval);
            return retval;
        }
        
        /// <summary>
        ///     Gets the window content region min
        /// </summary>
        /// <returns>The retval</returns>
        public static Vector2 GetWindowContentRegionMin()
        {
            Vector2 retval;
            ImGuiNative.igGetWindowContentRegionMin(out retval);
            return retval;
        }
        
        /// <summary>
        ///     Gets the window dock id
        /// </summary>
        /// <returns>The ret</returns>
        public static uint GetWindowDockId()
        {
            uint ret = ImGuiNative.igGetWindowDockID();
            return ret;
        }
        
        /// <summary>
        ///     Gets the window dpi scale
        /// </summary>
        /// <returns>The ret</returns>
        public static float GetWindowDpiScale()
        {
            float ret = ImGuiNative.igGetWindowDpiScale();
            return ret;
        }
        
        /// <summary>
        ///     Gets the window draw list
        /// </summary>
        /// <returns>The im draw list ptr</returns>
        public static ImDrawListPtr GetWindowDrawList()
        {
            ImDrawList* ret = ImGuiNative.igGetWindowDrawList();
            return new ImDrawListPtr(ret);
        }
        
        /// <summary>
        ///     Gets the window height
        /// </summary>
        /// <returns>The ret</returns>
        public static float GetWindowHeight()
        {
            float ret = ImGuiNative.igGetWindowHeight();
            return ret;
        }
        
        /// <summary>
        ///     Gets the window pos
        /// </summary>
        /// <returns>The retval</returns>
        public static Vector2 GetWindowPos()
        {
            Vector2 retval;
            ImGuiNative.igGetWindowPos(out retval);
            return retval;
        }
        
        /// <summary>
        ///     Gets the window size
        /// </summary>
        /// <returns>The retval</returns>
        public static Vector2 GetWindowSize()
        {
            Vector2 retval;
            ImGuiNative.igGetWindowSize(out retval);
            return retval;
        }
        
        /// <summary>
        ///     Gets the window viewport
        /// </summary>
        /// <returns>The im gui viewport ptr</returns>
        public static ImGuiViewportPtr GetWindowViewport()
        {
            ImGuiViewport* ret = ImGuiNative.igGetWindowViewport();
            return new ImGuiViewportPtr(ret);
        }
        
        /// <summary>
        ///     Gets the window width
        /// </summary>
        /// <returns>The ret</returns>
        public static float GetWindowWidth()
        {
            float ret = ImGuiNative.igGetWindowWidth();
            return ret;
        }
        
        /// <summary>
        ///     Images the user texture id
        /// </summary>
        /// <param name="userTextureId">The user texture id</param>
        /// <param name="size">The size</param>
        public static void Image(IntPtr userTextureId, Vector2 size)
        {
            Vector2 uv0 = new Vector2();
            Vector2 uv1 = new Vector2(1, 1);
            Vector4 tintCol = new Vector4(1, 1, 1, 1);
            Vector4 borderCol = new Vector4();
            ImGuiNative.igImage(userTextureId, size, uv0, uv1, tintCol, borderCol);
        }
        
        /// <summary>
        ///     Images the user texture id
        /// </summary>
        /// <param name="userTextureId">The user texture id</param>
        /// <param name="size">The size</param>
        /// <param name="uv0">The uv</param>
        public static void Image(IntPtr userTextureId, Vector2 size, Vector2 uv0)
        {
            Vector2 uv1 = new Vector2(1, 1);
            Vector4 tintCol = new Vector4(1, 1, 1, 1);
            Vector4 borderCol = new Vector4();
            ImGuiNative.igImage(userTextureId, size, uv0, uv1, tintCol, borderCol);
        }
        
        /// <summary>
        ///     Images the user texture id
        /// </summary>
        /// <param name="userTextureId">The user texture id</param>
        /// <param name="size">The size</param>
        /// <param name="uv0">The uv</param>
        /// <param name="uv1">The uv</param>
        public static void Image(IntPtr userTextureId, Vector2 size, Vector2 uv0, Vector2 uv1)
        {
            Vector4 tintCol = new Vector4(1, 1, 1, 1);
            Vector4 borderCol = new Vector4();
            ImGuiNative.igImage(userTextureId, size, uv0, uv1, tintCol, borderCol);
        }
        
        /// <summary>
        ///     Images the user texture id
        /// </summary>
        /// <param name="userTextureId">The user texture id</param>
        /// <param name="size">The size</param>
        /// <param name="uv0">The uv</param>
        /// <param name="uv1">The uv</param>
        /// <param name="tintCol">The tint col</param>
        public static void Image(IntPtr userTextureId, Vector2 size, Vector2 uv0, Vector2 uv1, Vector4 tintCol)
        {
            Vector4 borderCol = new Vector4();
            ImGuiNative.igImage(userTextureId, size, uv0, uv1, tintCol, borderCol);
        }
        
        /// <summary>
        ///     Images the user texture id
        /// </summary>
        /// <param name="userTextureId">The user texture id</param>
        /// <param name="size">The size</param>
        /// <param name="uv0">The uv</param>
        /// <param name="uv1">The uv</param>
        /// <param name="tintCol">The tint col</param>
        /// <param name="borderCol">The border col</param>
        public static void Image(IntPtr userTextureId, Vector2 size, Vector2 uv0, Vector2 uv1, Vector4 tintCol, Vector4 borderCol)
        {
            ImGuiNative.igImage(userTextureId, size, uv0, uv1, tintCol, borderCol);
        }
        
        /// <summary>
        ///     Describes whether image button
        /// </summary>
        /// <param name="strId">The str id</param>
        /// <param name="userTextureId">The user texture id</param>
        /// <param name="size">The size</param>
        /// <returns>The bool</returns>
        public static bool ImageButton(string strId, IntPtr userTextureId, Vector2 size)
        {
            byte ret = ImGuiNative.igImageButton(Encoding.UTF8.GetBytes(strId), userTextureId, size, new Vector2(), new Vector2(1, 1), new Vector4(), new Vector4(1, 1, 1, 1));
            return ret != 0;
        }
        
        /// <summary>
        ///     Describes whether image button
        /// </summary>
        /// <param name="strId">The str id</param>
        /// <param name="userTextureId">The user texture id</param>
        /// <param name="size">The size</param>
        /// <param name="uv0">The uv</param>
        /// <returns>The bool</returns>
        public static bool ImageButton(string strId, IntPtr userTextureId, Vector2 size, Vector2 uv0)
        {
            byte ret = ImGuiNative.igImageButton(Encoding.UTF8.GetBytes(strId), userTextureId, size, uv0, new Vector2(1, 1), new Vector4(), new Vector4(1, 1, 1, 1));
            return ret != 0;
        }
        
        /// <summary>
        ///     Describes whether image button
        /// </summary>
        /// <param name="strId">The str id</param>
        /// <param name="userTextureId">The user texture id</param>
        /// <param name="size">The size</param>
        /// <param name="uv0">The uv</param>
        /// <param name="uv1">The uv</param>
        /// <returns>The bool</returns>
        public static bool ImageButton(string strId, IntPtr userTextureId, Vector2 size, Vector2 uv0, Vector2 uv1)
        {
            byte ret = ImGuiNative.igImageButton(Encoding.UTF8.GetBytes(strId), userTextureId, size, uv0, uv1, new Vector4(), new Vector4(1, 1, 1, 1));
            return ret != 0;
        }
        
        /// <summary>
        ///     Describes whether image button
        /// </summary>
        /// <param name="strId">The str id</param>
        /// <param name="userTextureId">The user texture id</param>
        /// <param name="size">The size</param>
        /// <param name="uv0">The uv</param>
        /// <param name="uv1">The uv</param>
        /// <param name="bgCol">The bg col</param>
        /// <returns>The bool</returns>
        public static bool ImageButton(string strId, IntPtr userTextureId, Vector2 size, Vector2 uv0, Vector2 uv1, Vector4 bgCol)
        {
            byte ret = ImGuiNative.igImageButton(Encoding.UTF8.GetBytes(strId), userTextureId, size, uv0, uv1, bgCol, new Vector4(1, 1, 1, 1));
            return ret != 0;
        }
        
        /// <summary>
        ///     Describes whether image button
        /// </summary>
        /// <param name="strId">The str id</param>
        /// <param name="userTextureId">The user texture id</param>
        /// <param name="size">The size</param>
        /// <param name="uv0">The uv</param>
        /// <param name="uv1">The uv</param>
        /// <param name="bgCol">The bg col</param>
        /// <param name="tintCol">The tint col</param>
        /// <returns>The bool</returns>
        public static bool ImageButton(string strId, IntPtr userTextureId, Vector2 size, Vector2 uv0, Vector2 uv1, Vector4 bgCol, Vector4 tintCol)
        {
            byte ret = ImGuiNative.igImageButton(Encoding.UTF8.GetBytes(strId), userTextureId, size, uv0, uv1, bgCol, tintCol);
            return ret != 0;
        }
        
        /// <summary>
        ///     Indents
        /// </summary>
        public static void Indent()
        {
            float indentW = 0.0f;
            ImGuiNative.igIndent(indentW);
        }
        
        /// <summary>
        ///     Indents the indent w
        /// </summary>
        /// <param name="indentW">The indent</param>
        public static void Indent(float indentW)
        {
            ImGuiNative.igIndent(indentW);
        }
        
        /// <summary>
        ///     Describes whether input double
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="v">The </param>
        /// <returns>The bool</returns>
        public static bool InputDouble(string label, ref double v)
        {
            byte ret = ImGuiNative.igInputDouble(Encoding.UTF8.GetBytes(label), ref v, 0.0, 0.0, null, 0);
            return ret != 0;
        }
        
        /// <summary>
        ///     Describes whether input double
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="v">The </param>
        /// <param name="step">The step</param>
        /// <returns>The bool</returns>
        public static bool InputDouble(string label, ref double v, double step)
        {
            byte ret = ImGuiNative.igInputDouble(Encoding.UTF8.GetBytes(label), ref v, step, 0.0, null, 0);
                return ret != 0;
        }
        
        /// <summary>
        ///     Describes whether input double
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="v">The </param>
        /// <param name="step">The step</param>
        /// <param name="stepFast">The step fast</param>
        /// <returns>The bool</returns>
        public static bool InputDouble(string label, ref double v, double step, double stepFast)
        {
            byte ret = ImGuiNative.igInputDouble(Encoding.UTF8.GetBytes(label), ref v, step, stepFast, null, 0);
                return ret != 0;
        }
        
        /// <summary>
        ///     Describes whether input double
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="v">The </param>
        /// <param name="step">The step</param>
        /// <param name="stepFast">The step fast</param>
        /// <param name="format">The format</param>
        /// <returns>The bool</returns>
        public static bool InputDouble(string label, ref double v, double step, double stepFast, string format)
        {
            byte ret = ImGuiNative.igInputDouble(Encoding.UTF8.GetBytes(label), ref v, step, stepFast, Encoding.UTF8.GetBytes(format), 0);
            
                return ret != 0;
        }
        
        /// <summary>
        ///     Describes whether input double
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="v">The </param>
        /// <param name="step">The step</param>
        /// <param name="stepFast">The step fast</param>
        /// <param name="format">The format</param>
        /// <param name="flags">The flags</param>
        /// <returns>The bool</returns>
        public static bool InputDouble(string label, ref double v, double step, double stepFast, string format, ImGuiInputTextFlags flags)
        {
            byte ret = ImGuiNative.igInputDouble(Encoding.UTF8.GetBytes(label), ref v, step, stepFast, Encoding.UTF8.GetBytes(format), flags);
                return ret != 0;
        }
        
        /// <summary>
        ///     Describes whether input float
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="v">The </param>
        /// <returns>The bool</returns>
        public static bool InputFloat(string label, ref float v)
        {
            byte ret = ImGuiNative.igInputFloat(Encoding.UTF8.GetBytes(label), ref v, 0.0f, 0.0f, null, 0);
                return ret != 0;
        }
        
        /// <summary>
        ///     Describes whether input float
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="v">The </param>
        /// <param name="step">The step</param>
        /// <returns>The bool</returns>
        public static bool InputFloat(string label, ref float v, float step)
        {
            byte ret = ImGuiNative.igInputFloat(Encoding.UTF8.GetBytes(label), ref v, step, 0.0f, null, 0);
                return ret != 0;
        }
        
        /// <summary>
        ///     Describes whether input float
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="v">The </param>
        /// <param name="step">The step</param>
        /// <param name="stepFast">The step fast</param>
        /// <returns>The bool</returns>
        public static bool InputFloat(string label, ref float v, float step, float stepFast)
        {
            byte ret = ImGuiNative.igInputFloat(Encoding.UTF8.GetBytes(label), ref v, step, stepFast, null, 0);
                return ret != 0;
        }
        
        /// <summary>
        ///     Describes whether input float
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="v">The </param>
        /// <param name="step">The step</param>
        /// <param name="stepFast">The step fast</param>
        /// <param name="format">The format</param>
        /// <returns>The bool</returns>
        public static bool InputFloat(string label, ref float v, float step, float stepFast, string format)
        {
            byte ret = ImGuiNative.igInputFloat(Encoding.UTF8.GetBytes(label), ref v, step, stepFast, Encoding.UTF8.GetBytes(format), 0);
                return ret != 0;
        }
        
        /// <summary>
        ///     Describes whether input float
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="v">The </param>
        /// <param name="step">The step</param>
        /// <param name="stepFast">The step fast</param>
        /// <param name="format">The format</param>
        /// <param name="flags">The flags</param>
        /// <returns>The bool</returns>
        public static bool InputFloat(string label, ref float v, float step, float stepFast, string format, ImGuiInputTextFlags flags)
        {
            byte ret = ImGuiNative.igInputFloat(Encoding.UTF8.GetBytes(label), ref v, step, stepFast, Encoding.UTF8.GetBytes(format), flags);
            
                return ret != 0;
        }
        
        /// <summary>
        ///     Describes whether input float 2
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="v">The </param>
        /// <returns>The bool</returns>
        public static bool InputFloat2(string label, ref Vector2 v)
        {
            byte ret = ImGuiNative.igInputFloat2(Encoding.UTF8.GetBytes(label), ref v, null, 0);
                
                return ret != 0;
        }
        
        /// <summary>
        ///     Describes whether input float 2
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="v">The </param>
        /// <param name="format">The format</param>
        /// <returns>The bool</returns>
        public static bool InputFloat2(string label, ref Vector2 v, string format)
        {
            byte ret = ImGuiNative.igInputFloat2(Encoding.UTF8.GetBytes(label), ref v, Encoding.UTF8.GetBytes(format), 0);
                return ret != 0;
        }
        
        /// <summary>
        ///     Describes whether input float 2
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="v">The </param>
        /// <param name="format">The format</param>
        /// <param name="flags">The flags</param>
        /// <returns>The bool</returns>
        public static bool InputFloat2(string label, ref Vector2 v, string format, ImGuiInputTextFlags flags)
        {
            byte ret = ImGuiNative.igInputFloat2(Encoding.UTF8.GetBytes(label), ref v, Encoding.UTF8.GetBytes(format), flags);
                
                return ret != 0;
        }
        
        /// <summary>
        ///     Describes whether input float 3
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="v">The </param>
        /// <returns>The bool</returns>
        public static bool InputFloat3(string label, ref Vector3 v)
        {
            byte ret = ImGuiNative.igInputFloat3(Encoding.UTF8.GetBytes(label), ref v, null, 0);
                return ret != 0;
        }
        
        /// <summary>
        ///     Describes whether input float 3
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="v">The </param>
        /// <param name="format">The format</param>
        /// <returns>The bool</returns>
        public static bool InputFloat3(string label, ref Vector3 v, string format)
        {
            byte ret = ImGuiNative.igInputFloat3(Encoding.UTF8.GetBytes(label), ref v, Encoding.UTF8.GetBytes(format), 0);
            
                return ret != 0;
        }
        
        /// <summary>
        ///     Describes whether input float 3
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="v">The </param>
        /// <param name="format">The format</param>
        /// <param name="flags">The flags</param>
        /// <returns>The bool</returns>
        public static bool InputFloat3(string label, ref Vector3 v, string format, ImGuiInputTextFlags flags)
        {
            byte ret = ImGuiNative.igInputFloat3(Encoding.UTF8.GetBytes(label), ref v, Encoding.UTF8.GetBytes(format), flags);
                return ret != 0;
        }
        
        /// <summary>
        ///     Describes whether input float 4
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="v">The </param>
        /// <returns>The bool</returns>
        public static bool InputFloat4(string label, ref Vector4 v)
        {
            byte ret = ImGuiNative.igInputFloat4(Encoding.UTF8.GetBytes(label), ref v, null, 0);
            return ret != 0;
        }
    }
}