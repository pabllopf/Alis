// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImGuiP5.cs
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

namespace Alis.Extension.Graphic.ImGui.Native
{
    /// <summary>
    ///     The im gui class
    /// </summary>
    public static unsafe partial class ImGui
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="ImGui" /> class
        /// </summary>
        static ImGui()
        {
            EmbeddedDllClass.ExtractEmbeddedDlls("cimgui", DllType.Lib, ImGuiDlls.ImGuiDllBytes, Assembly.GetExecutingAssembly());
        }
        
        /// <summary>
        ///     Accepts the drag drop payload using the specified type
        /// </summary>
        /// <param name="type">The type</param>
        /// <returns>The im gui payload ptr</returns>
        public static ImGuiPayload AcceptDragDropPayload(string type)
        {
            byte* nativeType;
            int typeByteCount = 0;
            if (type != null)
            {
                typeByteCount = Encoding.UTF8.GetByteCount(type);
                if (typeByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeType = Util.Allocate(typeByteCount + 1);
                }
                else
                {
                    byte* nativeTypeStackBytes = stackalloc byte[typeByteCount + 1];
                    nativeType = nativeTypeStackBytes;
                }
                
                int nativeTypeOffset = Util.GetUtf8(type, nativeType, typeByteCount);
                nativeType[nativeTypeOffset] = 0;
            }
            else
            {
                nativeType = null;
            }
            
            ImGuiDragDropFlags flags = 0;
            ImGuiPayload ret = ImGuiNative.igAcceptDragDropPayload(nativeType, flags);
            if (typeByteCount > Util.StackAllocationSizeLimit)
            {
                Util.Free(nativeType);
            }
            
            return ret;
        }
        
        /// <summary>
        ///     Accepts the drag drop payload using the specified type
        /// </summary>
        /// <param name="type">The type</param>
        /// <param name="flags">The flags</param>
        /// <returns>The im gui payload ptr</returns>
        public static ImGuiPayload AcceptDragDropPayload(string type, ImGuiDragDropFlags flags)
        {
            byte* nativeType;
            int typeByteCount = 0;
            if (type != null)
            {
                typeByteCount = Encoding.UTF8.GetByteCount(type);
                if (typeByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeType = Util.Allocate(typeByteCount + 1);
                }
                else
                {
                    byte* nativeTypeStackBytes = stackalloc byte[typeByteCount + 1];
                    nativeType = nativeTypeStackBytes;
                }
                
                int nativeTypeOffset = Util.GetUtf8(type, nativeType, typeByteCount);
                nativeType[nativeTypeOffset] = 0;
            }
            else
            {
                nativeType = null;
            }
            
            ImGuiPayload ret = ImGuiNative.igAcceptDragDropPayload(nativeType, flags);
            if (typeByteCount > Util.StackAllocationSizeLimit)
            {
                Util.Free(nativeType);
            }
            
            return ret;
        }
        
        /// <summary>
        ///     Aligns the text to frame padding
        /// </summary>
        public static void AlignTextToFramePadding()
        {
            ImGuiNative.igAlignTextToFramePadding();
        }
        
        /// <summary>
        ///     Describes whether arrow button
        /// </summary>
        /// <param name="strId">The str id</param>
        /// <param name="dir">The dir</param>
        /// <returns>The bool</returns>
        public static bool ArrowButton(string strId, ImGuiDir dir)
        {
            byte ret = ImGuiNative.igArrowButton(Encoding.UTF8.GetBytes(strId), dir);
            
            return ret != 0;
        }
        
        /// <summary>
        ///     Describes whether begin
        /// </summary>
        /// <param name="name">The name</param>
        /// <returns>The bool</returns>
        public static bool Begin(string name)
        {
            byte ret = ImGuiNative.igBegin(Encoding.UTF8.GetBytes(name), true, 0);
            
            return ret != 0;
        }
        
        /// <summary>
        ///     Describes whether begin
        /// </summary>
        /// <param name="name">The name</param>
        /// <param name="pOpen">The open</param>
        /// <returns>The bool</returns>
        public static bool Begin(string name, ref bool pOpen)
        {
            byte ret = ImGuiNative.igBegin(Encoding.UTF8.GetBytes(name),  pOpen, 0);
            return ret != 0;
        }
        
        /// <summary>
        ///     Describes whether begin
        /// </summary>
        /// <param name="name">The name</param>
        /// <param name="pOpen">The open</param>
        /// <param name="flags">The flags</param>
        /// <returns>The bool</returns>
        public static bool Begin(string name, ref bool pOpen, ImGuiWindowFlags flags)
        {
            byte ret = ImGuiNative.igBegin(Encoding.UTF8.GetBytes(name), pOpen, flags);
            return ret != 0;
        }
        
        /// <summary>
        ///     Describes whether begin child
        /// </summary>
        /// <param name="strId">The str id</param>
        /// <returns>The bool</returns>
        public static bool BeginChild(string strId)
        {
            byte ret = ImGuiNative.igBeginChild_Str(Encoding.UTF8.GetBytes(strId), new Vector2(), 0, 0);
            return ret != 0;
        }
        
        /// <summary>
        ///     Describes whether begin child
        /// </summary>
        /// <param name="strId">The str id</param>
        /// <param name="size">The size</param>
        /// <returns>The bool</returns>
        public static bool BeginChild(string strId, Vector2 size)
        {
            byte ret = ImGuiNative.igBeginChild_Str(Encoding.UTF8.GetBytes(strId), size, 0, 0);
            return ret != 0;
        }
        
        /// <summary>
        ///     Describes whether begin child
        /// </summary>
        /// <param name="strId">The str id</param>
        /// <param name="size">The size</param>
        /// <param name="border">The border</param>
        /// <returns>The bool</returns>
        public static bool BeginChild(string strId, Vector2 size, bool border)
        {
            byte ret = ImGuiNative.igBeginChild_Str(Encoding.UTF8.GetBytes(strId), size, border ? (byte) 1 : (byte) 0, 0);
            return ret != 0;
        }
        
        /// <summary>
        ///     Describes whether begin child
        /// </summary>
        /// <param name="strId">The str id</param>
        /// <param name="size">The size</param>
        /// <param name="border">The border</param>
        /// <param name="flags">The flags</param>
        /// <returns>The bool</returns>
        public static bool BeginChild(string strId, Vector2 size, bool border, ImGuiWindowFlags flags)
        {
            byte ret = ImGuiNative.igBeginChild_Str(Encoding.UTF8.GetBytes(strId), size, border ? (byte) 1 : (byte) 0, flags);
            return ret != 0;
        }
        
        /// <summary>
        ///     Describes whether begin child
        /// </summary>
        /// <param name="id">The id</param>
        /// <returns>The bool</returns>
        public static bool BeginChild(uint id)
        {
            Vector2 size = new Vector2();
            byte border = 0;
            ImGuiWindowFlags flags = 0;
            byte ret = ImGuiNative.igBeginChild_ID(id, size, border, flags);
            return ret != 0;
        }
        
        /// <summary>
        ///     Describes whether begin child
        /// </summary>
        /// <param name="id">The id</param>
        /// <param name="size">The size</param>
        /// <returns>The bool</returns>
        public static bool BeginChild(uint id, Vector2 size)
        {
            byte border = 0;
            ImGuiWindowFlags flags = 0;
            byte ret = ImGuiNative.igBeginChild_ID(id, size, border, flags);
            return ret != 0;
        }
        
        /// <summary>
        ///     Describes whether begin child
        /// </summary>
        /// <param name="id">The id</param>
        /// <param name="size">The size</param>
        /// <param name="border">The border</param>
        /// <returns>The bool</returns>
        public static bool BeginChild(uint id, Vector2 size, bool border)
        {
            byte nativeBorder = border ? (byte) 1 : (byte) 0;
            ImGuiWindowFlags flags = 0;
            byte ret = ImGuiNative.igBeginChild_ID(id, size, nativeBorder, flags);
            return ret != 0;
        }
        
        /// <summary>
        ///     Describes whether begin child
        /// </summary>
        /// <param name="id">The id</param>
        /// <param name="size">The size</param>
        /// <param name="border">The border</param>
        /// <param name="flags">The flags</param>
        /// <returns>The bool</returns>
        public static bool BeginChild(uint id, Vector2 size, bool border, ImGuiWindowFlags flags)
        {
            byte nativeBorder = border ? (byte) 1 : (byte) 0;
            byte ret = ImGuiNative.igBeginChild_ID(id, size, nativeBorder, flags);
            return ret != 0;
        }
        
        /// <summary>
        ///     Describes whether begin child frame
        /// </summary>
        /// <param name="id">The id</param>
        /// <param name="size">The size</param>
        /// <returns>The bool</returns>
        public static bool BeginChildFrame(uint id, Vector2 size)
        {
            ImGuiWindowFlags flags = 0;
            byte ret = ImGuiNative.igBeginChildFrame(id, size, flags);
            return ret != 0;
        }
        
        /// <summary>
        ///     Describes whether begin child frame
        /// </summary>
        /// <param name="id">The id</param>
        /// <param name="size">The size</param>
        /// <param name="flags">The flags</param>
        /// <returns>The bool</returns>
        public static bool BeginChildFrame(uint id, Vector2 size, ImGuiWindowFlags flags)
        {
            byte ret = ImGuiNative.igBeginChildFrame(id, size, flags);
            return ret != 0;
        }
        
        /// <summary>
        ///     Describes whether begin combo
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="previewValue">The preview value</param>
        /// <returns>The bool</returns>
        public static bool BeginCombo(string label, string previewValue)
        {
            byte ret = ImGuiNative.igBeginCombo(Encoding.UTF8.GetBytes(label), Encoding.UTF8.GetBytes(previewValue), ImGuiComboFlags.None);
            
            return ret != 0;
        }
        
        /// <summary>
        ///     Describes whether begin combo
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="previewValue">The preview value</param>
        /// <param name="flags">The flags</param>
        /// <returns>The bool</returns>
        public static bool BeginCombo(string label, string previewValue, ImGuiComboFlags flags)
        {
            byte ret = ImGuiNative.igBeginCombo(Encoding.UTF8.GetBytes(label), Encoding.UTF8.GetBytes(previewValue), flags);
            
            return ret != 0;
        }
        
        /// <summary>
        ///     Begins the disabled
        /// </summary>
        public static void BeginDisabled()
        {
            byte disabled = 1;
            ImGuiNative.igBeginDisabled(disabled);
        }
        
        /// <summary>
        ///     Begins the disabled using the specified disabled
        /// </summary>
        /// <param name="disabled">The disabled</param>
        public static void BeginDisabled(bool disabled)
        {
            byte nativeDisabled = disabled ? (byte) 1 : (byte) 0;
            ImGuiNative.igBeginDisabled(nativeDisabled);
        }
        
        /// <summary>
        ///     Describes whether begin drag drop source
        /// </summary>
        /// <returns>The bool</returns>
        public static bool BeginDragDropSource()
        {
            ImGuiDragDropFlags flags = 0;
            byte ret = ImGuiNative.igBeginDragDropSource(flags);
            return ret != 0;
        }
        
        /// <summary>
        ///     Describes whether begin drag drop source
        /// </summary>
        /// <param name="flags">The flags</param>
        /// <returns>The bool</returns>
        public static bool BeginDragDropSource(ImGuiDragDropFlags flags)
        {
            byte ret = ImGuiNative.igBeginDragDropSource(flags);
            return ret != 0;
        }
        
        /// <summary>
        ///     Describes whether begin drag drop target
        /// </summary>
        /// <returns>The bool</returns>
        public static bool BeginDragDropTarget()
        {
            byte ret = ImGuiNative.igBeginDragDropTarget();
            return ret != 0;
        }
        
        /// <summary>
        ///     Begins the group
        /// </summary>
        public static void BeginGroup()
        {
            ImGuiNative.igBeginGroup();
        }
        
        /// <summary>
        ///     Describes whether begin list box
        /// </summary>
        /// <param name="label">The label</param>
        /// <returns>The bool</returns>
        public static bool BeginListBox(string label)
        {
            byte ret = ImGuiNative.igBeginListBox(Encoding.UTF8.GetBytes(label), new Vector2());
            return ret != 0;
        }
        
        /// <summary>
        ///     Describes whether begin list box
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="size">The size</param>
        /// <returns>The bool</returns>
        public static bool BeginListBox(string label, Vector2 size)
        {
            byte ret = ImGuiNative.igBeginListBox(Encoding.UTF8.GetBytes(label), size);
            
            return ret != 0;
        }
        
        /// <summary>
        ///     Describes whether begin main menu bar
        /// </summary>
        /// <returns>The bool</returns>
        public static bool BeginMainMenuBar()
        {
            byte ret = ImGuiNative.igBeginMainMenuBar();
            return ret != 0;
        }
        
        /// <summary>
        ///     Describes whether begin menu
        /// </summary>
        /// <param name="label">The label</param>
        /// <returns>The bool</returns>
        public static bool BeginMenu(string label)
        {
            byte ret = ImGuiNative.igBeginMenu(Encoding.UTF8.GetBytes(label), true);
            
            return ret != 0;
        }
        
        /// <summary>
        ///     Describes whether begin menu
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="enabled">The enabled</param>
        /// <returns>The bool</returns>
        public static bool BeginMenu(string label, bool enabled)
        {
            byte ret = ImGuiNative.igBeginMenu(Encoding.UTF8.GetBytes(label), enabled);
            
            return ret != 0;
        }
        
        /// <summary>
        ///     Describes whether begin menu bar
        /// </summary>
        /// <returns>The bool</returns>
        public static bool BeginMenuBar()
        {
            byte ret = ImGuiNative.igBeginMenuBar();
            return ret != 0;
        }
        
        /// <summary>
        ///     Describes whether begin popup
        /// </summary>
        /// <param name="strId">The str id</param>
        /// <returns>The bool</returns>
        public static bool BeginPopup(string strId)
        {
            byte ret = ImGuiNative.igBeginPopup(Encoding.UTF8.GetBytes(strId), ImGuiWindowFlags.None);
            return ret != 0;
        }
        
        /// <summary>
        ///     Describes whether begin popup
        /// </summary>
        /// <param name="strId">The str id</param>
        /// <param name="flags">The flags</param>
        /// <returns>The bool</returns>
        public static bool BeginPopup(string strId, ImGuiWindowFlags flags)
        {
            byte ret = ImGuiNative.igBeginPopup(Encoding.UTF8.GetBytes(strId), flags);
            return ret != 0;
        }
        
        /// <summary>
        ///     Describes whether begin popup context item
        /// </summary>
        /// <returns>The bool</returns>
        public static bool BeginPopupContextItem()
        {
            ImGuiPopupFlags popupFlags = (ImGuiPopupFlags) 1;
            byte ret = ImGuiNative.igBeginPopupContextItem(Encoding.UTF8.GetBytes(""), popupFlags);
            return ret != 0;
        }
        
        /// <summary>
        ///     Describes whether begin popup context item
        /// </summary>
        /// <param name="strId">The str id</param>
        /// <returns>The bool</returns>
        public static bool BeginPopupContextItem(string strId)
        {
            byte ret = ImGuiNative.igBeginPopupContextItem(Encoding.UTF8.GetBytes(strId), ImGuiPopupFlags.None);
            
            return ret != 0;
        }
        
        /// <summary>
        ///     Describes whether begin popup context item
        /// </summary>
        /// <param name="strId">The str id</param>
        /// <param name="popupFlags">The popup flags</param>
        /// <returns>The bool</returns>
        public static bool BeginPopupContextItem(string strId, ImGuiPopupFlags popupFlags)
        {
            byte ret = ImGuiNative.igBeginPopupContextItem(Encoding.UTF8.GetBytes(strId), popupFlags);
            
            return ret != 0;
        }
        
        /// <summary>
        ///     Describes whether begin popup context void
        /// </summary>
        /// <returns>The bool</returns>
        public static bool BeginPopupContextVoid()
        {
            ImGuiPopupFlags popupFlags = (ImGuiPopupFlags) 1;
            byte ret = ImGuiNative.igBeginPopupContextVoid(Encoding.UTF8.GetBytes(""), popupFlags);
            return ret != 0;
        }
        
        /// <summary>
        ///     Describes whether begin popup context void
        /// </summary>
        /// <param name="strId">The str id</param>
        /// <returns>The bool</returns>
        public static bool BeginPopupContextVoid(string strId)
        {
            byte ret = ImGuiNative.igBeginPopupContextVoid(Encoding.UTF8.GetBytes(strId), ImGuiPopupFlags.None);
            
            return ret != 0;
        }
        
        /// <summary>
        ///     Describes whether begin popup context void
        /// </summary>
        /// <param name="strId">The str id</param>
        /// <param name="popupFlags">The popup flags</param>
        /// <returns>The bool</returns>
        public static bool BeginPopupContextVoid(string strId, ImGuiPopupFlags popupFlags)
        {
            byte ret = ImGuiNative.igBeginPopupContextVoid(Encoding.UTF8.GetBytes(strId), popupFlags);
            
            return ret != 0;
        }
        
        /// <summary>
        ///     Describes whether begin popup context window
        /// </summary>
        /// <returns>The bool</returns>
        public static bool BeginPopupContextWindow()
        {
            ImGuiPopupFlags popupFlags = (ImGuiPopupFlags) 1;
            byte ret = ImGuiNative.igBeginPopupContextWindow(Encoding.UTF8.GetBytes(""), popupFlags);
            return ret != 0;
        }
        
        /// <summary>
        ///     Describes whether begin popup context window
        /// </summary>
        /// <param name="strId">The str id</param>
        /// <returns>The bool</returns>
        public static bool BeginPopupContextWindow(string strId)
        {
            byte ret = ImGuiNative.igBeginPopupContextWindow(Encoding.UTF8.GetBytes(strId), ImGuiPopupFlags.None);
            
            return ret != 0;
        }
        
        /// <summary>
        ///     Describes whether begin popup context window
        /// </summary>
        /// <param name="strId">The str id</param>
        /// <param name="popupFlags">The popup flags</param>
        /// <returns>The bool</returns>
        public static bool BeginPopupContextWindow(string strId, ImGuiPopupFlags popupFlags)
        {
            byte ret = ImGuiNative.igBeginPopupContextWindow(Encoding.UTF8.GetBytes(strId), popupFlags);
            
            return ret != 0;
        }
        
        /// <summary>
        ///     Describes whether begin popup modal
        /// </summary>
        /// <param name="name">The name</param>
        /// <returns>The bool</returns>
        public static bool BeginPopupModal(string name)
        {
            byte ret = ImGuiNative.igBeginPopupModal(Encoding.UTF8.GetBytes(name), true, 0);
            return ret != 0;
        }
        
        /// <summary>
        ///     Describes whether begin popup modal
        /// </summary>
        /// <param name="name">The name</param>
        /// <param name="pOpen">The open</param>
        /// <returns>The bool</returns>
        public static bool BeginPopupModal(string name, ref bool pOpen)
        {
            byte ret = ImGuiNative.igBeginPopupModal(Encoding.UTF8.GetBytes(name), pOpen, 0);
            return ret != 0;
        }
        
        /// <summary>
        ///     Describes whether begin popup modal
        /// </summary>
        /// <param name="name">The name</param>
        /// <param name="pOpen">The open</param>
        /// <param name="flags">The flags</param>
        /// <returns>The bool</returns>
        public static bool BeginPopupModal(string name, ref bool pOpen, ImGuiWindowFlags flags)
        {
            byte ret = ImGuiNative.igBeginPopupModal(Encoding.UTF8.GetBytes(name), pOpen, flags);
            return ret != 0;
        }
        
        /// <summary>
        ///     Describes whether begin tab bar
        /// </summary>
        /// <param name="strId">The str id</param>
        /// <returns>The bool</returns>
        public static bool BeginTabBar(string strId)
        {
            byte ret = ImGuiNative.igBeginTabBar(Encoding.UTF8.GetBytes(strId), ImGuiTabBarFlags.None);
            return ret != 0;
        }
        
        /// <summary>
        ///     Describes whether begin tab bar
        /// </summary>
        /// <param name="strId">The str id</param>
        /// <param name="flags">The flags</param>
        /// <returns>The bool</returns>
        public static bool BeginTabBar(string strId, ImGuiTabBarFlags flags)
        {
            byte ret = ImGuiNative.igBeginTabBar(Encoding.UTF8.GetBytes(strId), flags);
            
            return ret != 0;
        }
        
        /// <summary>
        ///     Describes whether begin tab item
        /// </summary>
        /// <param name="label">The label</param>
        /// <returns>The bool</returns>
        public static bool BeginTabItem(string label)
        {
            byte ret = ImGuiNative.igBeginTabItem(Encoding.UTF8.GetBytes(label), true, 0);
            return ret != 0;
        }
        
        /// <summary>
        ///     Describes whether begin tab item
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="pOpen">The open</param>
        /// <returns>The bool</returns>
        public static bool BeginTabItem(string label, ref bool pOpen)
        {
            byte ret = ImGuiNative.igBeginTabItem(Encoding.UTF8.GetBytes(label), pOpen, 0);
            return ret != 0;
        }
        
        /// <summary>
        ///     Describes whether begin tab item
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="pOpen">The open</param>
        /// <param name="flags">The flags</param>
        /// <returns>The bool</returns>
        public static bool BeginTabItem(string label, ref bool pOpen, ImGuiTabItemFlags flags)
        {
            byte ret = ImGuiNative.igBeginTabItem(Encoding.UTF8.GetBytes(label), pOpen, flags);
            return ret != 0;
        }
        
        /// <summary>
        ///     Describes whether begin table
        /// </summary>
        /// <param name="strId">The str id</param>
        /// <param name="column">The column</param>
        /// <returns>The bool</returns>
        public static bool BeginTable(string strId, int column)
        {
            byte ret = ImGuiNative.igBeginTable(Encoding.UTF8.GetBytes(strId), column, ImGuiTableFlags.None, new Vector2(), 0.0f);
            
            return ret != 0;
        }
        
        /// <summary>
        ///     Describes whether begin table
        /// </summary>
        /// <param name="strId">The str id</param>
        /// <param name="column">The column</param>
        /// <param name="flags">The flags</param>
        /// <returns>The bool</returns>
        public static bool BeginTable(string strId, int column, ImGuiTableFlags flags)
        {
            byte ret = ImGuiNative.igBeginTable(Encoding.UTF8.GetBytes(strId), column, flags, new Vector2(), 0.0f);
            
            return ret != 0;
        }
        
        /// <summary>
        ///     Describes whether begin table
        /// </summary>
        /// <param name="strId">The str id</param>
        /// <param name="column">The column</param>
        /// <param name="flags">The flags</param>
        /// <param name="outerSize">The outer size</param>
        /// <returns>The bool</returns>
        public static bool BeginTable(string strId, int column, ImGuiTableFlags flags, Vector2 outerSize)
        {
            byte ret = ImGuiNative.igBeginTable(Encoding.UTF8.GetBytes(strId), column, flags, outerSize, 0.0f);
            return ret != 0;
        }
        
        /// <summary>
        ///     Describes whether begin table
        /// </summary>
        /// <param name="strId">The str id</param>
        /// <param name="column">The column</param>
        /// <param name="flags">The flags</param>
        /// <param name="outerSize">The outer size</param>
        /// <param name="innerWidth">The inner width</param>
        /// <returns>The bool</returns>
        public static bool BeginTable(string strId, int column, ImGuiTableFlags flags, Vector2 outerSize, float innerWidth)
        {
            byte ret = ImGuiNative.igBeginTable(Encoding.UTF8.GetBytes(strId), column, flags, outerSize, innerWidth);
            
            return ret != 0;
        }
        
        /// <summary>
        ///     Begins the tooltip
        /// </summary>
        public static void BeginTooltip()
        {
            ImGuiNative.igBeginTooltip();
        }
        
        /// <summary>
        ///     Bullets
        /// </summary>
        public static void Bullet()
        {
            ImGuiNative.igBullet();
        }
        
        /// <summary>
        ///     Bullets the text using the specified fmt
        /// </summary>
        /// <param name="fmt">The fmt</param>
        public static void BulletText(string fmt)
        {
            ImGuiNative.igBulletText(Encoding.UTF8.GetBytes(fmt));
        }
        
        /// <summary>
        ///     Describes whether button
        /// </summary>
        /// <param name="label">The label</param>
        /// <returns>The bool</returns>
        public static bool Button(string label)
        {
            byte ret = ImGuiNative.igButton(Encoding.UTF8.GetBytes(label), new Vector2());
            return ret != 0;
        }
        
        /// <summary>
        ///     Describes whether button
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="size">The size</param>
        /// <returns>The bool</returns>
        public static bool Button(string label, Vector2 size)
        {
            byte ret = ImGuiNative.igButton(Encoding.UTF8.GetBytes(label), size);
            return ret != 0;
        }
        
        /// <summary>
        ///     Calcs the item width
        /// </summary>
        /// <returns>The ret</returns>
        public static float CalcItemWidth()
        {
            float ret = ImGuiNative.igCalcItemWidth();
            return ret;
        }
        
        /// <summary>
        ///     Describes whether checkbox
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="v">The </param>
        /// <returns>The bool</returns>
        public static bool Checkbox(string label, ref bool v)
        {
            byte ret = ImGuiNative.igCheckbox(Encoding.UTF8.GetBytes(label),  v);
            return ret != 0;
        }
        
        /// <summary>
        ///     Describes whether checkbox flags
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="flags">The flags</param>
        /// <param name="flagsValue">The flags value</param>
        /// <returns>The bool</returns>
        public static bool CheckboxFlags(string label, ref int flags, int flagsValue)
        {
            byte ret = ImGuiNative.igCheckboxFlags_IntPtr(Encoding.UTF8.GetBytes(label), flags, flagsValue);
                return ret != 0;
            
        }
        
        /// <summary>
        ///     Describes whether checkbox flags
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="flags">The flags</param>
        /// <param name="flagsValue">The flags value</param>
        /// <returns>The bool</returns>
        public static bool CheckboxFlags(string label, ref uint flags, uint flagsValue)
        {
            byte ret = ImGuiNative.igCheckboxFlags_UintPtr(Encoding.UTF8.GetBytes(label), flags, flagsValue);
                return ret != 0;
            
        }
        
        /// <summary>
        ///     Closes the current popup
        /// </summary>
        public static void CloseCurrentPopup()
        {
            ImGuiNative.igCloseCurrentPopup();
        }
        
        /// <summary>
        ///     Describes whether collapsing header
        /// </summary>
        /// <param name="label">The label</param>
        /// <returns>The bool</returns>
        public static bool CollapsingHeader(string label)
        {
            byte ret = ImGuiNative.igCollapsingHeader_TreeNodeFlags(Encoding.UTF8.GetBytes(label), ImGuiTreeNodeFlags.None);
            return ret != 0;
        }
        
        /// <summary>
        ///     Describes whether collapsing header
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="flags">The flags</param>
        /// <returns>The bool</returns>
        public static bool CollapsingHeader(string label, ImGuiTreeNodeFlags flags)
        {
            byte ret = ImGuiNative.igCollapsingHeader_TreeNodeFlags(Encoding.UTF8.GetBytes(label), flags);
            
            return ret != 0;
        }
        
        /// <summary>
        ///     Describes whether collapsing header
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="pVisible">The visible</param>
        /// <returns>The bool</returns>
        public static bool CollapsingHeader(string label, ref bool pVisible)
        {
            byte ret = ImGuiNative.igCollapsingHeader_BoolPtr(Encoding.UTF8.GetBytes(label), pVisible, ImGuiTreeNodeFlags.None);
            return ret != 0;
        }
        
        /// <summary>
        ///     Describes whether collapsing header
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="pVisible">The visible</param>
        /// <param name="flags">The flags</param>
        /// <returns>The bool</returns>
        public static bool CollapsingHeader(string label, ref bool pVisible, ImGuiTreeNodeFlags flags)
        {
            byte ret = ImGuiNative.igCollapsingHeader_BoolPtr(Encoding.UTF8.GetBytes(label), pVisible, flags);
            return ret != 0;
        }
        
        /// <summary>
        ///     Describes whether color button
        /// </summary>
        /// <param name="descId">The desc id</param>
        /// <param name="col">The col</param>
        /// <returns>The bool</returns>
        public static bool ColorButton(string descId, Vector4 col)
        {
            byte ret = ImGuiNative.igColorButton(Encoding.UTF8.GetBytes(descId), col, ImGuiColorEditFlags.None, new Vector2());
            return ret != 0;
        }
        
        /// <summary>
        ///     Describes whether color button
        /// </summary>
        /// <param name="descId">The desc id</param>
        /// <param name="col">The col</param>
        /// <param name="flags">The flags</param>
        /// <returns>The bool</returns>
        public static bool ColorButton(string descId, Vector4 col, ImGuiColorEditFlags flags)
        {
            byte ret = ImGuiNative.igColorButton(Encoding.UTF8.GetBytes(descId), col, flags, new Vector2());
            return ret != 0;
        }
        
        /// <summary>
        ///     Describes whether color button
        /// </summary>
        /// <param name="descId">The desc id</param>
        /// <param name="col">The col</param>
        /// <param name="flags">The flags</param>
        /// <param name="size">The size</param>
        /// <returns>The bool</returns>
        public static bool ColorButton(string descId, Vector4 col, ImGuiColorEditFlags flags, Vector2 size)
        {
            byte ret = ImGuiNative.igColorButton(Encoding.UTF8.GetBytes(descId), col, flags, size);
            return ret != 0;
        }
        
        /// <summary>
        ///     Colors the convert float 4 to u 32 using the specified in
        /// </summary>
        /// <param name="in">The in</param>
        /// <returns>The ret</returns>
        public static uint ColorConvertFloat4ToU32(Vector4 @in)
        {
            uint ret = ImGuiNative.igColorConvertFloat4ToU32(@in);
            return ret;
        }
        
        /// <summary>
        ///     Colors the convert hs vto rgb using the specified h
        /// </summary>
        /// <param name="h">The </param>
        /// <param name="s">The </param>
        /// <param name="v">The </param>
        /// <param name="outR">The out</param>
        /// <param name="outG">The out</param>
        /// <param name="outB">The out</param>
        public static void ColorConvertHsVtoRgb(float h, float s, float v, out float outR, out float outG, out float outB)
        {
            fixed (float* nativeOutR = &outR)
            {
                fixed (float* nativeOutG = &outG)
                {
                    fixed (float* nativeOutB = &outB)
                    {
                        ImGuiNative.igColorConvertHSVtoRGB(h, s, v, nativeOutR, nativeOutG, nativeOutB);
                    }
                }
            }
        }
        
        /// <summary>
        ///     Colors the convert rg bto hsv using the specified r
        /// </summary>
        /// <param name="r">The </param>
        /// <param name="g">The </param>
        /// <param name="b">The </param>
        /// <param name="outH">The out</param>
        /// <param name="outS">The out</param>
        /// <param name="outV">The out</param>
        public static void ColorConvertRgBtoHsv(float r, float g, float b, out float outH, out float outS, out float outV)
        {
            fixed (float* nativeOutH = &outH)
            {
                fixed (float* nativeOutS = &outS)
                {
                    fixed (float* nativeOutV = &outV)
                    {
                        ImGuiNative.igColorConvertRGBtoHSV(r, g, b, nativeOutH, nativeOutS, nativeOutV);
                    }
                }
            }
        }
        
        /// <summary>
        ///     Colors the convert u 32 to float 4 using the specified in
        /// </summary>
        /// <param name="in">The in</param>
        /// <returns>The retval</returns>
        public static Vector4 ColorConvertU32ToFloat4(uint @in)
        {
            Vector4 retval = new Vector4();
            ImGuiNative.igColorConvertU32ToFloat4(out retval, @in);
            return retval;
        }
        
        /// <summary>
        ///     Describes whether color edit 3
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="col">The col</param>
        /// <returns>The bool</returns>
        public static bool ColorEdit3(string label, ref Vector3 col)
        {
            byte ret = ImGuiNative.igColorEdit3(Encoding.UTF8.GetBytes(label), col, ImGuiColorEditFlags.None);
                
                return ret != 0;
            
        }
        
        /// <summary>
        ///     Describes whether color edit 3
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="col">The col</param>
        /// <param name="flags">The flags</param>
        /// <returns>The bool</returns>
        public static bool ColorEdit3(string label, ref Vector3 col, ImGuiColorEditFlags flags)
        {
            byte ret = ImGuiNative.igColorEdit3(Encoding.UTF8.GetBytes(label), col, flags);
                return ret != 0;
            
        }
        
        /// <summary>
        ///     Describes whether color edit 4
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="col">The col</param>
        /// <returns>The bool</returns>
        public static bool ColorEdit4(string label, ref Vector4 col)
        {
            byte ret = ImGuiNative.igColorEdit4(Encoding.UTF8.GetBytes(label), col, ImGuiColorEditFlags.None);
                
                return ret != 0;
        }
        
        /// <summary>
        ///     Describes whether color edit 4
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="col">The col</param>
        /// <param name="flags">The flags</param>
        /// <returns>The bool</returns>
        public static bool ColorEdit4(string label, ref Vector4 col, ImGuiColorEditFlags flags)
        {
            byte ret = ImGuiNative.igColorEdit4(Encoding.UTF8.GetBytes(label), col, flags);
                return ret != 0;
        }
        
        /// <summary>
        ///     Describes whether color picker 3
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="col">The col</param>
        /// <returns>The bool</returns>
        public static bool ColorPicker3(string label, ref Vector3 col)
        {
            byte ret = ImGuiNative.igColorPicker3(Encoding.UTF8.GetBytes(label), col, ImGuiColorEditFlags.None);
                
                return ret != 0;
            
        }
        
        /// <summary>
        ///     Describes whether color picker 3
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="col">The col</param>
        /// <param name="flags">The flags</param>
        /// <returns>The bool</returns>
        public static bool ColorPicker3(string label, ref Vector3 col, ImGuiColorEditFlags flags)
        {
            byte ret = ImGuiNative.igColorPicker3(Encoding.UTF8.GetBytes(label), col, flags);
                return ret != 0;
            
        }
        
        /// <summary>
        ///     Describes whether color picker 4
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="col">The col</param>
        /// <returns>The bool</returns>
        public static bool ColorPicker4(string label, ref Vector4 col)
        {
            byte ret = ImGuiNative.igColorPicker4(Encoding.UTF8.GetBytes(label), col, ImGuiColorEditFlags.None, 0);
                
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
            byte ret = ImGuiNative.igColorPicker4(Encoding.UTF8.GetBytes(label), col, flags, 0);
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
            byte ret = ImGuiNative.igColorPicker4(Encoding.UTF8.GetBytes(label), col, flags, refCol);
                
                return ret != 0;
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
            byte[][] itemsNative = new byte[items.Length][];
            for (int i = 0; i < items.Length; i++)
            {
                itemsNative[i] = Encoding.UTF8.GetBytes(items[i]);
            }
            byte ret = ImGuiNative.igCombo_Str_arr(Encoding.UTF8.GetBytes(label), ref currentItem, itemsNative, itemsCount, -1);
                return ret != 0;
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
            byte[][] itemsNative = new byte[items.Length][];
            for (int i = 0; i < items.Length; i++)
            {
                itemsNative[i] = Encoding.UTF8.GetBytes(items[i]);
            }
            byte ret = ImGuiNative.igCombo_Str_arr(Encoding.UTF8.GetBytes(label), ref currentItem, itemsNative, itemsCount, popupMaxHeightInItems);
                return ret != 0;
        }
    }
}