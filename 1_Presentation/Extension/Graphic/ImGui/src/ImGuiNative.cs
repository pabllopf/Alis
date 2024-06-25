// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImGuiNative.cs
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
using System.Runtime.InteropServices;
using Alis.Core.Aspect.Math.Vector;

namespace Alis.Extension.Graphic.ImGui
{
    /// <summary>
    ///     The im gui native class
    /// </summary>
    public static unsafe class ImGuiNative
    {
        /// <summary>
        ///     The dll name
        /// </summary>
        private const string DllName = "cimgui";
        
        /// <summary>
        ///     Igs the accept drag drop payload using the specified type
        /// </summary>
        /// <param name="type">The type</param>
        /// <param name="flags">The flags</param>
        /// <returns>The im gui payload</returns>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "igAcceptDragDropPayload")]
        public static extern ImGuiPayload igAcceptDragDropPayload(byte[] type, ImGuiDragDropFlags flags);
        
        /// <summary>
        ///     Igs the align text to frame padding
        /// </summary>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "igAlignTextToFramePadding")]
        public static extern void igAlignTextToFramePadding();
        
        /// <summary>
        ///     Ims the gui platform io set platform get window pos using the specified platform io
        /// </summary>
        /// <param name="platformIo">The platform io</param>
        /// <param name="funcPtr">The func ptr</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ImGuiPlatformIO_Set_Platform_GetWindowPos")]
        public static extern void ImGuiPlatformIO_Set_Platform_GetWindowPos(IntPtr platformIo, IntPtr funcPtr);
        
        /// <summary>
        ///     Ims the gui platform io set platform get window size using the specified platform io
        /// </summary>
        /// <param name="platformIo">The platform io</param>
        /// <param name="funcPtr">The func ptr</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ImGuiPlatformIO_Set_Platform_GetWindowSize")]
        public static extern void ImGuiPlatformIO_Set_Platform_GetWindowSize(IntPtr platformIo, IntPtr funcPtr);
        
        /// <summary>
        ///     Igs the arrow button using the specified str id
        /// </summary>
        /// <param name="strId">The str id</param>
        /// <param name="dir">The dir</param>
        /// <returns>The byte</returns>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "igArrowButton")]
        public static extern byte igArrowButton(byte[] strId, ImGuiDir dir);
        
        /// <summary>
        ///     Igs the begin using the specified name
        /// </summary>
        /// <param name="name">The name</param>
        /// <param name="pOpen">The open</param>
        /// <param name="flags">The flags</param>
        /// <returns>The byte</returns>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "igBegin")]
        public static extern byte igBegin(byte[] name,  bool pOpen, ImGuiWindowFlags flags);
        
        /// <summary>
        ///     Igs the begin child str using the specified str id
        /// </summary>
        /// <param name="strId">The str id</param>
        /// <param name="size">The size</param>
        /// <param name="border">The border</param>
        /// <param name="flags">The flags</param>
        /// <returns>The byte</returns>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "igBeginChild_Str")]
        public static extern byte igBeginChild_Str(byte[] strId, Vector2 size, byte border, ImGuiWindowFlags flags);
        
        /// <summary>
        ///     Igs the begin child id using the specified id
        /// </summary>
        /// <param name="id">The id</param>
        /// <param name="size">The size</param>
        /// <param name="border">The border</param>
        /// <param name="flags">The flags</param>
        /// <returns>The byte</returns>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "igBeginChild_ID")]
        public static extern byte igBeginChild_ID(uint id, Vector2 size, byte border, ImGuiWindowFlags flags);
        
        /// <summary>
        ///     Igs the begin child frame using the specified id
        /// </summary>
        /// <param name="id">The id</param>
        /// <param name="size">The size</param>
        /// <param name="flags">The flags</param>
        /// <returns>The byte</returns>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "igBeginChildFrame")]
        public static extern byte igBeginChildFrame(uint id, Vector2 size, ImGuiWindowFlags flags);
        
        /// <summary>
        ///     Igs the begin combo using the specified label
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="previewValue">The preview value</param>
        /// <param name="flags">The flags</param>
        /// <returns>The byte</returns>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "igBeginCombo")]
        public static extern byte igBeginCombo(byte[] label, byte[] previewValue, ImGuiComboFlags flags);
        
        /// <summary>
        ///     Igs the begin disabled using the specified disabled
        /// </summary>
        /// <param name="disabled">The disabled</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "igBeginDisabled")]
        public static extern void igBeginDisabled(byte disabled);
        
        /// <summary>
        ///     Igs the begin drag drop source using the specified flags
        /// </summary>
        /// <param name="flags">The flags</param>
        /// <returns>The byte</returns>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "igBeginDragDropSource")]
        public static extern byte igBeginDragDropSource(ImGuiDragDropFlags flags);
        
        /// <summary>
        ///     Igs the begin drag drop target
        /// </summary>
        /// <returns>The byte</returns>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "igBeginDragDropTarget")]
        public static extern byte igBeginDragDropTarget();
        
        /// <summary>
        ///     Igs the begin group
        /// </summary>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "igBeginGroup")]
        public static extern void igBeginGroup();
        
        /// <summary>
        ///     Igs the begin list box using the specified label
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="size">The size</param>
        /// <returns>The byte</returns>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "igBeginListBox")]
        public static extern byte igBeginListBox(byte[] label, Vector2 size);
        
        /// <summary>
        ///     Igs the begin main menu bar
        /// </summary>
        /// <returns>The byte</returns>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "igBeginMainMenuBar")]
        public static extern byte igBeginMainMenuBar();
        
        /// <summary>
        ///     Igs the begin menu using the specified label
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="enabled">The enabled</param>
        /// <returns>The byte</returns>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "igBeginMenu")]
        public static extern byte igBeginMenu(byte[] label, bool enabled);
        
        /// <summary>
        ///     Igs the begin menu bar
        /// </summary>
        /// <returns>The byte</returns>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "igBeginMenuBar")]
        public static extern byte igBeginMenuBar();
        
        /// <summary>
        ///     Igs the begin popup using the specified str id
        /// </summary>
        /// <param name="strId">The str id</param>
        /// <param name="flags">The flags</param>
        /// <returns>The byte</returns>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "igBeginPopup")]
        public static extern byte igBeginPopup(byte[] strId, ImGuiWindowFlags flags);
        
        /// <summary>
        ///     Igs the begin popup context item using the specified str id
        /// </summary>
        /// <param name="strId">The str id</param>
        /// <param name="popupFlags">The popup flags</param>
        /// <returns>The byte</returns>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "igBeginPopupContextItem")]
        public static extern byte igBeginPopupContextItem(byte[] strId, ImGuiPopupFlags popupFlags);
        
        /// <summary>
        ///     Igs the begin popup context void using the specified str id
        /// </summary>
        /// <param name="strId">The str id</param>
        /// <param name="popupFlags">The popup flags</param>
        /// <returns>The byte</returns>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "igBeginPopupContextVoid")]
        public static extern byte igBeginPopupContextVoid(byte[] strId, ImGuiPopupFlags popupFlags);
        
        /// <summary>
        ///     Igs the begin popup context window using the specified str id
        /// </summary>
        /// <param name="strId">The str id</param>
        /// <param name="popupFlags">The popup flags</param>
        /// <returns>The byte</returns>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "igBeginPopupContextWindow")]
        public static extern byte igBeginPopupContextWindow(byte[] strId, ImGuiPopupFlags popupFlags);
        
        /// <summary>
        ///     Igs the begin popup modal using the specified name
        /// </summary>
        /// <param name="name">The name</param>
        /// <param name="pOpen">The open</param>
        /// <param name="flags">The flags</param>
        /// <returns>The byte</returns>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "igBeginPopupModal")]
        public static extern byte igBeginPopupModal(byte[] name, bool pOpen, ImGuiWindowFlags flags);
        
        /// <summary>
        ///     Igs the begin tab bar using the specified str id
        /// </summary>
        /// <param name="strId">The str id</param>
        /// <param name="flags">The flags</param>
        /// <returns>The byte</returns>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "igBeginTabBar")]
        public static extern byte igBeginTabBar(byte[] strId, ImGuiTabBarFlags flags);
        
        /// <summary>
        ///     Igs the begin tab item using the specified label
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="pOpen">The open</param>
        /// <param name="flags">The flags</param>
        /// <returns>The byte</returns>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "igBeginTabItem")]
        public static extern byte igBeginTabItem(byte[] label, bool pOpen, ImGuiTabItemFlags flags);
        
        /// <summary>
        ///     Igs the begin table using the specified str id
        /// </summary>
        /// <param name="strId">The str id</param>
        /// <param name="column">The column</param>
        /// <param name="flags">The flags</param>
        /// <param name="outerSize">The outer size</param>
        /// <param name="innerWidth">The inner width</param>
        /// <returns>The byte</returns>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "igBeginTable")]
        public static extern byte igBeginTable(byte[] strId, int column, ImGuiTableFlags flags, Vector2 outerSize, float innerWidth);
        
        /// <summary>
        ///     Igs the begin tooltip
        /// </summary>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "igBeginTooltip")]
        public static extern void igBeginTooltip();
        
        /// <summary>
        ///     Igs the bullet
        /// </summary>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "igBullet")]
        public static extern void igBullet();
        
        /// <summary>
        ///     Igs the bullet text using the specified fmt
        /// </summary>
        /// <param name="fmt">The fmt</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "igBulletText")]
        public static extern void igBulletText(byte[] fmt);
        
        /// <summary>
        ///     Igs the button using the specified label
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="size">The size</param>
        /// <returns>The byte</returns>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "igButton")]
        public static extern byte igButton(byte[] label, Vector2 size);
        
        /// <summary>
        ///     Igs the calc item width
        /// </summary>
        /// <returns>The float</returns>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "igCalcItemWidth")]
        public static extern float igCalcItemWidth();
        
        /// <summary>
        ///     Igs the calc text size using the specified p out
        /// </summary>
        /// <param name="pOut">The out</param>
        /// <param name="text">The text</param>
        /// <param name="textEnd">The text end</param>
        /// <param name="hideTextAfterDoubleHash">The hide text after double hash</param>
        /// <param name="wrapWidth">The wrap width</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "igCalcTextSize")]
        public static extern void igCalcTextSize(out Vector2 pOut, byte[] text, byte textEnd, bool hideTextAfterDoubleHash, float wrapWidth);
        
        /// <summary>
        ///     Igs the checkbox using the specified label
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="v">The </param>
        /// <returns>The byte</returns>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "igCheckbox")]
        public static extern byte igCheckbox(byte[] label, bool v);
        
        /// <summary>
        ///     Igs the checkbox flags int ptr using the specified label
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="flags">The flags</param>
        /// <param name="flagsValue">The flags value</param>
        /// <returns>The byte</returns>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "igCheckboxFlags_IntPtr")]
        public static extern byte igCheckboxFlags_IntPtr(byte[] label, int flags, int flagsValue);
        
        /// <summary>
        ///     Igs the checkbox flags uint ptr using the specified label
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="flags">The flags</param>
        /// <param name="flagsValue">The flags value</param>
        /// <returns>The byte</returns>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "igCheckboxFlags_UintPtr")]
        public static extern byte igCheckboxFlags_UintPtr(byte[] label, uint flags, uint flagsValue);
        
        /// <summary>
        ///     Igs the close current popup
        /// </summary>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "igCloseCurrentPopup")]
        public static extern void igCloseCurrentPopup();
        
        /// <summary>
        ///     Igs the collapsing header tree node flags using the specified label
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="flags">The flags</param>
        /// <returns>The byte</returns>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "igCollapsingHeader_TreeNodeFlags")]
        public static extern byte igCollapsingHeader_TreeNodeFlags(byte[] label, ImGuiTreeNodeFlags flags);
        
        /// <summary>
        ///     Igs the collapsing header bool ptr using the specified label
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="pVisible">The visible</param>
        /// <param name="flags">The flags</param>
        /// <returns>The byte</returns>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "igCollapsingHeader_BoolPtr")]
        public static extern byte igCollapsingHeader_BoolPtr(byte[] label, bool pVisible, ImGuiTreeNodeFlags flags);
        
        /// <summary>
        ///     Igs the color button using the specified desc id
        /// </summary>
        /// <param name="descId">The desc id</param>
        /// <param name="col">The col</param>
        /// <param name="flags">The flags</param>
        /// <param name="size">The size</param>
        /// <returns>The byte</returns>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "igColorButton")]
        public static extern byte igColorButton(byte[] descId, Vector4 col, ImGuiColorEditFlags flags, Vector2 size);
        
        /// <summary>
        ///     Igs the color convert float 4 to u 32 using the specified in
        /// </summary>
        /// <param name="in">The in</param>
        /// <returns>The uint</returns>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "igColorConvertFloat4ToU32")]
        public static extern uint igColorConvertFloat4ToU32(Vector4 @in);
        
        /// <summary>
        ///     Igs the color convert hs vto rgb using the specified h
        /// </summary>
        /// <param name="h">The </param>
        /// <param name="s">The </param>
        /// <param name="v">The </param>
        /// <param name="outR">The out</param>
        /// <param name="outG">The out</param>
        /// <param name="outB">The out</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "igColorConvertHSVtoRGB")]
        public static extern void igColorConvertHSVtoRGB(float h, float s, float v, out float outR, out float outG, out float outB);
        
        /// <summary>
        ///     Igs the color convert rg bto hsv using the specified r
        /// </summary>
        /// <param name="r">The </param>
        /// <param name="g">The </param>
        /// <param name="b">The </param>
        /// <param name="outH">The out</param>
        /// <param name="outS">The out</param>
        /// <param name="outV">The out</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "igColorConvertRGBtoHSV")]
        public static extern void igColorConvertRGBtoHSV(float r, float g, float b, out float outH, out float outS, out float outV);
        
        /// <summary>
        ///     Igs the color convert u 32 to float 4 using the specified p out
        /// </summary>
        /// <param name="pOut">The out</param>
        /// <param name="in">The in</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "igColorConvertU32ToFloat4")]
        public static extern void igColorConvertU32ToFloat4(out Vector4 pOut, uint @in);
        
        /// <summary>
        ///     Igs the color edit 3 using the specified label
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="col">The col</param>
        /// <param name="flags">The flags</param>
        /// <returns>The byte</returns>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "igColorEdit3")]
        public static extern byte igColorEdit3(byte[] label, Vector3 col, ImGuiColorEditFlags flags);
        
        /// <summary>
        ///     Igs the color edit 4 using the specified label
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="col">The col</param>
        /// <param name="flags">The flags</param>
        /// <returns>The byte</returns>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "igColorEdit4")]
        public static extern byte igColorEdit4(byte[] label, Vector4 col, ImGuiColorEditFlags flags);
        
        /// <summary>
        ///     Igs the color picker 3 using the specified label
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="col">The col</param>
        /// <param name="flags">The flags</param>
        /// <returns>The byte</returns>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "igColorPicker3")]
        public static extern byte igColorPicker3(byte[] label, Vector3 col, ImGuiColorEditFlags flags);
        
        /// <summary>
        ///     Igs the color picker 4 using the specified label
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="col">The col</param>
        /// <param name="flags">The flags</param>
        /// <param name="refCol">The ref col</param>
        /// <returns>The byte</returns>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "igColorPicker4")]
        public static extern byte igColorPicker4(byte[] label, Vector4 col, ImGuiColorEditFlags flags, float refCol);
        
        /// <summary>
        ///     Igs the columns using the specified count
        /// </summary>
        /// <param name="count">The count</param>
        /// <param name="id">The id</param>
        /// <param name="border">The border</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "igColumns")]
        public static extern void igColumns(int count, byte[] id, byte border);
        
        /// <summary>
        ///     Igs the combo str arr using the specified label
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="currentItem">The current item</param>
        /// <param name="items">The items</param>
        /// <param name="itemsCount">The items count</param>
        /// <param name="popupMaxHeightInItems">The popup max height in items</param>
        /// <returns>The byte</returns>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "igCombo_Str_arr")]
        public static extern byte igCombo_Str_arr(byte[] label, ref int currentItem, byte[][] items, int itemsCount, int popupMaxHeightInItems);
        
        /// <summary>
        ///     Igs the combo str using the specified label
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="currentItem">The current item</param>
        /// <param name="itemsSeparatedByZeros">The items separated by zeros</param>
        /// <param name="popupMaxHeightInItems">The popup max height in items</param>
        /// <returns>The byte</returns>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "igCombo_Str")]
        public static extern byte igCombo_Str(byte[] label, ref int currentItem, byte[] itemsSeparatedByZeros, int popupMaxHeightInItems);
        
        /// <summary>
        ///     Igs the create context using the specified shared font atlas
        /// </summary>
        /// <param name="sharedFontAtlas">The shared font atlas</param>
        /// <returns>The int ptr</returns>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "igCreateContext")]
        public static extern IntPtr igCreateContext(IntPtr sharedFontAtlas);
        
        /// <summary>
        ///     Igs the debug check version and data layout using the specified version str
        /// </summary>
        /// <param name="versionStr">The version str</param>
        /// <param name="szIo">The sz io</param>
        /// <param name="szStyle">The sz style</param>
        /// <param name="szVec2">The sz vec2</param>
        /// <param name="szVec4">The sz vec4</param>
        /// <param name="szDrawvert">The sz drawvert</param>
        /// <param name="szDrawidx">The sz drawidx</param>
        /// <returns>The byte</returns>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "igDebugCheckVersionAndDataLayout")]
        public static extern byte igDebugCheckVersionAndDataLayout(byte[] versionStr, uint szIo, uint szStyle, uint szVec2, uint szVec4, uint szDrawvert, uint szDrawidx);
        
        /// <summary>
        ///     Igs the debug text encoding using the specified text
        /// </summary>
        /// <param name="text">The text</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "igDebugTextEncoding")]
        public static extern void igDebugTextEncoding(byte[] text);
        
        /// <summary>
        ///     Igs the destroy context using the specified ctx
        /// </summary>
        /// <param name="ctx">The ctx</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "igDestroyContext")]
        public static extern void igDestroyContext(IntPtr ctx);
        
        /// <summary>
        ///     Igs the destroy platform windows
        /// </summary>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "igDestroyPlatformWindows")]
        public static extern void igDestroyPlatformWindows();
        
        /// <summary>
        ///     Igs the dock space using the specified id
        /// </summary>
        /// <param name="id">The id</param>
        /// <param name="size">The size</param>
        /// <param name="flags">The flags</param>
        /// <param name="windowClass">The window class</param>
        /// <returns>The uint</returns>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "igDockSpace")]
        public static extern uint igDockSpace(uint id, Vector2 size, ImGuiDockNodeFlags flags, ImGuiWindowClass windowClass);
        
        /// <summary>
        ///     Igs the dock space over viewport using the specified viewport
        /// </summary>
        /// <param name="viewport">The viewport</param>
        /// <param name="flags">The flags</param>
        /// <param name="windowClass">The window class</param>
        /// <returns>The uint</returns>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "igDockSpaceOverViewport")]
        public static extern uint igDockSpaceOverViewport(IntPtr viewport, ImGuiDockNodeFlags flags, ImGuiWindowClass windowClass);
        
        /// <summary>
        ///     Igs the drag float using the specified label
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="v">The </param>
        /// <param name="vSpeed">The speed</param>
        /// <param name="vMin">The min</param>
        /// <param name="vMax">The max</param>
        /// <param name="format">The format</param>
        /// <param name="flags">The flags</param>
        /// <returns>The byte</returns>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "igDragFloat")]
        public static extern byte igDragFloat(byte[] label, ref float v, float vSpeed, float vMin, float vMax, byte[] format, ImGuiSliderFlags flags);
        
        /// <summary>
        ///     Igs the drag float 2 using the specified label
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="v">The </param>
        /// <param name="vSpeed">The speed</param>
        /// <param name="vMin">The min</param>
        /// <param name="vMax">The max</param>
        /// <param name="format">The format</param>
        /// <param name="flags">The flags</param>
        /// <returns>The byte</returns>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "igDragFloat2")]
        public static extern byte igDragFloat2(byte[] label, ref Vector2 v, float vSpeed, float vMin, float vMax, byte[] format, ImGuiSliderFlags flags);
        
        /// <summary>
        ///     Igs the drag float 3 using the specified label
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="v">The </param>
        /// <param name="vSpeed">The speed</param>
        /// <param name="vMin">The min</param>
        /// <param name="vMax">The max</param>
        /// <param name="format">The format</param>
        /// <param name="flags">The flags</param>
        /// <returns>The byte</returns>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "igDragFloat3")]
        public static extern byte igDragFloat3(byte[] label, ref Vector3 v, float vSpeed, float vMin, float vMax, byte[] format, ImGuiSliderFlags flags);
        
        /// <summary>
        ///     Igs the drag float 4 using the specified label
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="v">The </param>
        /// <param name="vSpeed">The speed</param>
        /// <param name="vMin">The min</param>
        /// <param name="vMax">The max</param>
        /// <param name="format">The format</param>
        /// <param name="flags">The flags</param>
        /// <returns>The byte</returns>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "igDragFloat4")]
        public static extern byte igDragFloat4(byte[] label, Vector4 v, float vSpeed, float vMin, float vMax, byte[] format, ImGuiSliderFlags flags);
        
        /// <summary>
        ///     Igs the drag float range 2 using the specified label
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
        /// <returns>The byte</returns>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "igDragFloatRange2")]
        public static extern byte igDragFloatRange2(byte[] label, ref float vCurrentMin, ref float vCurrentMax, float vSpeed, float vMin, float vMax, byte[] format, byte[] formatMax, ImGuiSliderFlags flags);
        
        /// <summary>
        ///     Igs the drag int using the specified label
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="v">The </param>
        /// <param name="vSpeed">The speed</param>
        /// <param name="vMin">The min</param>
        /// <param name="vMax">The max</param>
        /// <param name="format">The format</param>
        /// <param name="flags">The flags</param>
        /// <returns>The byte</returns>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "igDragInt")]
        public static extern byte igDragInt(byte[] label, ref int v, float vSpeed, int vMin, int vMax, byte[] format, ImGuiSliderFlags flags);
        
        /// <summary>
        ///     Igs the drag int 2 using the specified label
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="v">The </param>
        /// <param name="vSpeed">The speed</param>
        /// <param name="vMin">The min</param>
        /// <param name="vMax">The max</param>
        /// <param name="format">The format</param>
        /// <param name="flags">The flags</param>
        /// <returns>The byte</returns>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "igDragInt2")]
        public static extern byte igDragInt2(byte[] label, ref int v, float vSpeed, int vMin, int vMax, byte[] format, ImGuiSliderFlags flags);
        
        /// <summary>
        ///     Igs the drag int 3 using the specified label
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="v">The </param>
        /// <param name="vSpeed">The speed</param>
        /// <param name="vMin">The min</param>
        /// <param name="vMax">The max</param>
        /// <param name="format">The format</param>
        /// <param name="flags">The flags</param>
        /// <returns>The byte</returns>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "igDragInt3")]
        public static extern byte igDragInt3(byte[] label, ref int v, float vSpeed, int vMin, int vMax, byte[] format, ImGuiSliderFlags flags);
        
        /// <summary>
        ///     Igs the drag int 4 using the specified label
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="v">The </param>
        /// <param name="vSpeed">The speed</param>
        /// <param name="vMin">The min</param>
        /// <param name="vMax">The max</param>
        /// <param name="format">The format</param>
        /// <param name="flags">The flags</param>
        /// <returns>The byte</returns>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "igDragInt4")]
        public static extern byte igDragInt4(byte[] label, ref int v, float vSpeed, int vMin, int vMax, byte[] format, ImGuiSliderFlags flags);
        
        /// <summary>
        ///     Igs the drag int range 2 using the specified label
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
        /// <returns>The byte</returns>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "igDragIntRange2")]
        public static extern byte igDragIntRange2(byte[] label, ref int vCurrentMin, ref int vCurrentMax, float vSpeed, int vMin, int vMax, byte[] format, byte[] formatMax, ImGuiSliderFlags flags);
        
        /// <summary>
        ///     Igs the drag scalar using the specified label
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="dataType">The data type</param>
        /// <param name="pData">The data</param>
        /// <param name="vSpeed">The speed</param>
        /// <param name="pMin">The min</param>
        /// <param name="pMax">The max</param>
        /// <param name="format">The format</param>
        /// <param name="flags">The flags</param>
        /// <returns>The byte</returns>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "igDragScalar")]
        public static extern byte igDragScalar(byte[] label, ImGuiDataType dataType, IntPtr pData, float vSpeed, IntPtr pMin, IntPtr pMax, byte[] format, ImGuiSliderFlags flags);
        
        /// <summary>
        ///     Igs the drag scalar n using the specified label
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
        /// <returns>The byte</returns>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "igDragScalarN")]
        public static extern byte igDragScalarN(byte[] label, ImGuiDataType dataType, IntPtr pData, int components, float vSpeed, IntPtr pMin, IntPtr pMax, byte[] format, ImGuiSliderFlags flags);
        
        /// <summary>
        ///     Igs the dummy using the specified size
        /// </summary>
        /// <param name="size">The size</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "igDummy")]
        public static extern void igDummy(Vector2 size);
        
        /// <summary>
        ///     Igs the end
        /// </summary>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "igEnd")]
        public static extern void igEnd();
        
        /// <summary>
        ///     Igs the end child
        /// </summary>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "igEndChild")]
        public static extern void igEndChild();
        
        /// <summary>
        ///     Igs the end child frame
        /// </summary>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "igEndChildFrame")]
        public static extern void igEndChildFrame();
        
        /// <summary>
        ///     Igs the end combo
        /// </summary>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "igEndCombo")]
        public static extern void igEndCombo();
        
        /// <summary>
        ///     Igs the end disabled
        /// </summary>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "igEndDisabled")]
        public static extern void igEndDisabled();
        
        /// <summary>
        ///     Igs the end drag drop source
        /// </summary>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "igEndDragDropSource")]
        public static extern void igEndDragDropSource();
        
        /// <summary>
        ///     Igs the end drag drop target
        /// </summary>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "igEndDragDropTarget")]
        public static extern void igEndDragDropTarget();
        
        /// <summary>
        ///     Igs the end frame
        /// </summary>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "igEndFrame")]
        public static extern void igEndFrame();
        
        /// <summary>
        ///     Igs the end group
        /// </summary>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "igEndGroup")]
        public static extern void igEndGroup();
        
        /// <summary>
        ///     Igs the end list box
        /// </summary>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "igEndListBox")]
        public static extern void igEndListBox();
        
        /// <summary>
        ///     Igs the end main menu bar
        /// </summary>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "igEndMainMenuBar")]
        public static extern void igEndMainMenuBar();
        
        /// <summary>
        ///     Igs the end menu
        /// </summary>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "igEndMenu")]
        public static extern void igEndMenu();
        
        /// <summary>
        ///     Igs the end menu bar
        /// </summary>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "igEndMenuBar")]
        public static extern void igEndMenuBar();
        
        /// <summary>
        ///     Igs the end popup
        /// </summary>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "igEndPopup")]
        public static extern void igEndPopup();
        
        /// <summary>
        ///     Igs the end tab bar
        /// </summary>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "igEndTabBar")]
        public static extern void igEndTabBar();
        
        /// <summary>
        ///     Igs the end tab item
        /// </summary>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "igEndTabItem")]
        public static extern void igEndTabItem();
        
        /// <summary>
        ///     Igs the end table
        /// </summary>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "igEndTable")]
        public static extern void igEndTable();
        
        /// <summary>
        ///     Igs the end tooltip
        /// </summary>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "igEndTooltip")]
        public static extern void igEndTooltip();
        
        /// <summary>
        ///     Igs the find viewport by id using the specified id
        /// </summary>
        /// <param name="id">The id</param>
        /// <returns>The im gui viewport</returns>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "igFindViewportByID")]
        public static extern IntPtr igFindViewportByID(uint id);
        
        /// <summary>
        ///     Igs the find viewport by platform handle using the specified platform handle
        /// </summary>
        /// <param name="platformHandle">The platform handle</param>
        /// <returns>The im gui viewport</returns>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "igFindViewportByPlatformHandle")]
        public static extern IntPtr igFindViewportByPlatformHandle(IntPtr platformHandle);
        
        /// <summary>
        ///     Igs the get allocator functions using the specified p alloc func
        /// </summary>
        /// <param name="pAllocFunc">The alloc func</param>
        /// <param name="pFreeFunc">The free func</param>
        /// <param name="pUserData">The user data</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "igGetAllocatorFunctions")]
        public static extern void igGetAllocatorFunctions(ref IntPtr pAllocFunc, ref IntPtr pFreeFunc, ref IntPtr pUserData);
        
        /// <summary>
        ///     Igs the get background draw list nil
        /// </summary>
        /// <returns>The im draw list</returns>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "igGetBackgroundDrawList_Nil")]
        public static extern IntPtr igGetBackgroundDrawList_Nil();
        
        /// <summary>
        ///     Igs the get background draw list viewport ptr using the specified viewport
        /// </summary>
        /// <param name="viewport">The viewport</param>
        /// <returns>The im draw list</returns>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "igGetBackgroundDrawList_ViewportPtr")]
        public static extern IntPtr igGetBackgroundDrawList_ViewportPtr(IntPtr viewport);
        
        /// <summary>
        ///     Igs the get clipboard text
        /// </summary>
        /// <returns>The byte</returns>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "igGetClipboardText")]
        public static extern byte* igGetClipboardText();
        
        /// <summary>
        ///     Igs the get color u 32 col using the specified idx
        /// </summary>
        /// <param name="idx">The idx</param>
        /// <param name="alphaMul">The alpha mul</param>
        /// <returns>The uint</returns>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "igGetColorU32_Col")]
        public static extern uint igGetColorU32_Col(ImGuiCol idx, float alphaMul);
        
        /// <summary>
        ///     Igs the get color u 32 vec 4 using the specified col
        /// </summary>
        /// <param name="col">The col</param>
        /// <returns>The uint</returns>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "igGetColorU32_Vec4")]
        public static extern uint igGetColorU32_Vec4(Vector4 col);
        
        /// <summary>
        ///     Igs the get color u 32 u 32 using the specified col
        /// </summary>
        /// <param name="col">The col</param>
        /// <returns>The uint</returns>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "igGetColorU32_U32")]
        public static extern uint igGetColorU32_U32(uint col);
        
        /// <summary>
        ///     Igs the get column index
        /// </summary>
        /// <returns>The int</returns>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "igGetColumnIndex")]
        public static extern int igGetColumnIndex();
        
        /// <summary>
        ///     Igs the get column offset using the specified column index
        /// </summary>
        /// <param name="columnIndex">The column index</param>
        /// <returns>The float</returns>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "igGetColumnOffset")]
        public static extern float igGetColumnOffset(int columnIndex);
        
        /// <summary>
        ///     Igs the get columns count
        /// </summary>
        /// <returns>The int</returns>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "igGetColumnsCount")]
        public static extern int igGetColumnsCount();
        
        /// <summary>
        ///     Igs the get column width using the specified column index
        /// </summary>
        /// <param name="columnIndex">The column index</param>
        /// <returns>The float</returns>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "igGetColumnWidth")]
        public static extern float igGetColumnWidth(int columnIndex);
        
        /// <summary>
        ///     Igs the get content region avail using the specified p out
        /// </summary>
        /// <param name="pOut">The out</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "igGetContentRegionAvail")]
        public static extern void igGetContentRegionAvail(out Vector2 pOut);
        
        /// <summary>
        ///     Igs the get content region max using the specified p out
        /// </summary>
        /// <param name="pOut">The out</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "igGetContentRegionMax")]
        public static extern void igGetContentRegionMax(out Vector2 pOut);
        
        /// <summary>
        ///     Igs the get current context
        /// </summary>
        /// <returns>The int ptr</returns>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "igGetCurrentContext")]
        public static extern IntPtr igGetCurrentContext();
        
        /// <summary>
        ///     Igs the get cursor pos using the specified p out
        /// </summary>
        /// <param name="pOut">The out</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "igGetCursorPos")]
        public static extern void igGetCursorPos(out Vector2 pOut);
        
        /// <summary>
        ///     Igs the get cursor pos x
        /// </summary>
        /// <returns>The float</returns>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "igGetCursorPosX")]
        public static extern float igGetCursorPosX();
        
        /// <summary>
        ///     Igs the get cursor pos y
        /// </summary>
        /// <returns>The float</returns>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "igGetCursorPosY")]
        public static extern float igGetCursorPosY();
        
        /// <summary>
        ///     Igs the get cursor screen pos using the specified p out
        /// </summary>
        /// <param name="pOut">The out</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "igGetCursorScreenPos")]
        public static extern void igGetCursorScreenPos(out Vector2 pOut);
        
        /// <summary>
        ///     Igs the get cursor start pos using the specified p out
        /// </summary>
        /// <param name="pOut">The out</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "igGetCursorStartPos")]
        public static extern void igGetCursorStartPos(out Vector2 pOut);
        
        /// <summary>
        ///     Igs the get drag drop payload
        /// </summary>
        /// <returns>The im gui payload</returns>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "igGetDragDropPayload")]
        public static extern ImGuiPayload igGetDragDropPayload();
        
        /// <summary>
        ///     Igs the get draw data
        /// </summary>
        /// <returns>The im draw data</returns>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "igGetDrawData")]
        public static extern ref ImDrawData igGetDrawData();
        
        /// <summary>
        ///     Igs the get draw list shared data
        /// </summary>
        /// <returns>The int ptr</returns>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "igGetDrawListSharedData")]
        public static extern IntPtr igGetDrawListSharedData();
        
        /// <summary>
        ///     Igs the get font
        /// </summary>
        /// <returns>The im font</returns>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "igGetFont")]
        public static extern IntPtr igGetFont();
        
        /// <summary>
        ///     Igs the get font size
        /// </summary>
        /// <returns>The float</returns>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "igGetFontSize")]
        public static extern float igGetFontSize();
        
        /// <summary>
        ///     Igs the get font tex uv white pixel using the specified p out
        /// </summary>
        /// <param name="pOut">The out</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "igGetFontTexUvWhitePixel")]
        public static extern void igGetFontTexUvWhitePixel(out Vector2 pOut);
        
        /// <summary>
        ///     Igs the get foreground draw list nil
        /// </summary>
        /// <returns>The im draw list</returns>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "igGetForegroundDrawList_Nil")]
        public static extern IntPtr igGetForegroundDrawList_Nil();
        
        /// <summary>
        ///     Igs the get foreground draw list viewport ptr using the specified viewport
        /// </summary>
        /// <param name="viewport">The viewport</param>
        /// <returns>The im draw list</returns>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "igGetForegroundDrawList_ViewportPtr")]
        public static extern IntPtr igGetForegroundDrawList_ViewportPtr(IntPtr viewport);
        
        /// <summary>
        ///     Igs the get frame count
        /// </summary>
        /// <returns>The int</returns>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "igGetFrameCount")]
        public static extern int igGetFrameCount();
        
        /// <summary>
        ///     Igs the get frame height
        /// </summary>
        /// <returns>The float</returns>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "igGetFrameHeight")]
        public static extern float igGetFrameHeight();
        
        /// <summary>
        ///     Igs the get frame height with spacing
        /// </summary>
        /// <returns>The float</returns>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "igGetFrameHeightWithSpacing")]
        public static extern float igGetFrameHeightWithSpacing();
        
        /// <summary>
        ///     Igs the get id str using the specified str id
        /// </summary>
        /// <param name="strId">The str id</param>
        /// <returns>The uint</returns>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "igGetID_Str")]
        public static extern uint igGetID_Str(byte[] strId);
        
        /// <summary>
        ///     Igs the get id str str using the specified str id begin
        /// </summary>
        /// <param name="strIdBegin">The str id begin</param>
        /// <param name="strIdEnd">The str id end</param>
        /// <returns>The uint</returns>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "igGetID_StrStr")]
        public static extern uint igGetID_StrStr(byte* strIdBegin, byte* strIdEnd);
        
        /// <summary>
        ///     Igs the get id ptr using the specified ptr id
        /// </summary>
        /// <param name="ptrId">The ptr id</param>
        /// <returns>The uint</returns>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "igGetID_Ptr")]
        public static extern uint igGetID_Ptr(IntPtr ptrId);
        
        /// <summary>
        ///     Igs the get io
        /// </summary>
        /// <returns>The im gui io</returns>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "igGetIO")]
        public static extern IntPtr igGetIO();
        
        /// <summary>
        ///     Igs the get item rect max using the specified p out
        /// </summary>
        /// <param name="pOut">The out</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "igGetItemRectMax")]
        public static extern void igGetItemRectMax(out Vector2 pOut);
        
        /// <summary>
        ///     Igs the get item rect min using the specified p out
        /// </summary>
        /// <param name="pOut">The out</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "igGetItemRectMin")]
        public static extern void igGetItemRectMin(out Vector2 pOut);
        
        /// <summary>
        ///     Igs the get item rect size using the specified p out
        /// </summary>
        /// <param name="pOut">The out</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "igGetItemRectSize")]
        public static extern void igGetItemRectSize(out Vector2 pOut);
        
        /// <summary>
        ///     Igs the get key index using the specified key
        /// </summary>
        /// <param name="key">The key</param>
        /// <returns>The im gui key</returns>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "igGetKeyIndex")]
        public static extern ImGuiKey igGetKeyIndex(ImGuiKey key);
        
        /// <summary>
        ///     Igs the get key name using the specified key
        /// </summary>
        /// <param name="key">The key</param>
        /// <returns>The byte</returns>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "igGetKeyName")]
        public static extern byte* igGetKeyName(ImGuiKey key);
        
        /// <summary>
        ///     Igs the get key pressed amount using the specified key
        /// </summary>
        /// <param name="key">The key</param>
        /// <param name="repeatDelay">The repeat delay</param>
        /// <param name="rate">The rate</param>
        /// <returns>The int</returns>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "igGetKeyPressedAmount")]
        public static extern int igGetKeyPressedAmount(ImGuiKey key, float repeatDelay, float rate);
        
        /// <summary>
        ///     Igs the get main viewport
        /// </summary>
        /// <returns>The im gui viewport</returns>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "igGetMainViewport")]
        public static extern IntPtr igGetMainViewport();
        
        /// <summary>
        ///     Igs the get mouse clicked count using the specified button
        /// </summary>
        /// <param name="button">The button</param>
        /// <returns>The int</returns>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "igGetMouseClickedCount")]
        public static extern int igGetMouseClickedCount(ImGuiMouseButton button);
        
        /// <summary>
        ///     Igs the get mouse cursor
        /// </summary>
        /// <returns>The im gui mouse cursor</returns>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "igGetMouseCursor")]
        public static extern ImGuiMouseCursor igGetMouseCursor();
        
        /// <summary>
        ///     Igs the get mouse drag delta using the specified p out
        /// </summary>
        /// <param name="pOut">The out</param>
        /// <param name="button">The button</param>
        /// <param name="lockThreshold">The lock threshold</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "igGetMouseDragDelta")]
        public static extern void igGetMouseDragDelta(out Vector2 pOut, ImGuiMouseButton button, float lockThreshold);
        
        /// <summary>
        ///     Igs the get mouse pos using the specified p out
        /// </summary>
        /// <param name="pOut">The out</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "igGetMousePos")]
        public static extern void igGetMousePos(out Vector2 pOut);
        
        /// <summary>
        ///     Igs the get mouse pos on opening current popup using the specified p out
        /// </summary>
        /// <param name="pOut">The out</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "igGetMousePosOnOpeningCurrentPopup")]
        public static extern void igGetMousePosOnOpeningCurrentPopup(out Vector2 pOut);
        
        /// <summary>
        ///     Igs the get platform io
        /// </summary>
        /// <returns>The im gui platform io</returns>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "igGetPlatformIO")]
        public static extern IntPtr igGetPlatformIO();
        
        /// <summary>
        ///     Igs the get scroll max x
        /// </summary>
        /// <returns>The float</returns>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "igGetScrollMaxX")]
        public static extern float igGetScrollMaxX();
        
        /// <summary>
        ///     Igs the get scroll max y
        /// </summary>
        /// <returns>The float</returns>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "igGetScrollMaxY")]
        public static extern float igGetScrollMaxY();
        
        /// <summary>
        ///     Igs the get scroll x
        /// </summary>
        /// <returns>The float</returns>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "igGetScrollX")]
        public static extern float igGetScrollX();
        
        /// <summary>
        ///     Igs the get scroll y
        /// </summary>
        /// <returns>The float</returns>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "igGetScrollY")]
        public static extern float igGetScrollY();
        
        /// <summary>
        ///     Igs the get state storage
        /// </summary>
        /// <returns>The im gui storage</returns>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "igGetStateStorage")]
        public static extern ImGuiStorage igGetStateStorage();
        
        /// <summary>
        ///     Igs the get style
        /// </summary>
        /// <returns>The im gui style</returns>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "igGetStyle")]
        public static extern ImGuiStyle igGetStyle();
        
        /// <summary>
        ///     Igs the get style color name using the specified idx
        /// </summary>
        /// <param name="idx">The idx</param>
        /// <returns>The byte</returns>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "igGetStyleColorName")]
        public static extern byte* igGetStyleColorName(ImGuiCol idx);
        
        /// <summary>
        ///     Igs the get style color vec 4 using the specified idx
        /// </summary>
        /// <param name="idx">The idx</param>
        /// <returns>The vector</returns>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "igGetStyleColorVec4")]
        public static extern Vector4 igGetStyleColorVec4(ImGuiCol idx);
        
        /// <summary>
        ///     Igs the get text line height
        /// </summary>
        /// <returns>The float</returns>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "igGetTextLineHeight")]
        public static extern float igGetTextLineHeight();
        
        /// <summary>
        ///     Igs the get text line height with spacing
        /// </summary>
        /// <returns>The float</returns>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "igGetTextLineHeightWithSpacing")]
        public static extern float igGetTextLineHeightWithSpacing();
        
        /// <summary>
        ///     Igs the get time
        /// </summary>
        /// <returns>The double</returns>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "igGetTime")]
        public static extern double igGetTime();
        
        /// <summary>
        ///     Igs the get tree node to label spacing
        /// </summary>
        /// <returns>The float</returns>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "igGetTreeNodeToLabelSpacing")]
        public static extern float igGetTreeNodeToLabelSpacing();
        
        /// <summary>
        ///     Igs the get version
        /// </summary>
        /// <returns>The byte</returns>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "igGetVersion")]
        public static extern IntPtr igGetVersion();
        
        /// <summary>
        ///     Igs the get window content region max using the specified p out
        /// </summary>
        /// <param name="pOut">The out</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "igGetWindowContentRegionMax")]
        public static extern void igGetWindowContentRegionMax(out Vector2 pOut);
        
        /// <summary>
        ///     Igs the get window content region min using the specified p out
        /// </summary>
        /// <param name="pOut">The out</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "igGetWindowContentRegionMin")]
        public static extern void igGetWindowContentRegionMin(out Vector2 pOut);
        
        /// <summary>
        ///     Igs the get window dock id
        /// </summary>
        /// <returns>The uint</returns>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "igGetWindowDockID")]
        public static extern uint igGetWindowDockID();
        
        /// <summary>
        ///     Igs the get window dpi scale
        /// </summary>
        /// <returns>The float</returns>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "igGetWindowDpiScale")]
        public static extern float igGetWindowDpiScale();
        
        /// <summary>
        ///     Igs the get window draw list
        /// </summary>
        /// <returns>The im draw list</returns>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "igGetWindowDrawList")]
        public static extern IntPtr igGetWindowDrawList();
        
        /// <summary>
        ///     Igs the get window height
        /// </summary>
        /// <returns>The float</returns>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "igGetWindowHeight")]
        public static extern float igGetWindowHeight();
        
        /// <summary>
        ///     Igs the get window pos using the specified p out
        /// </summary>
        /// <param name="pOut">The out</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "igGetWindowPos")]
        public static extern void igGetWindowPos(out Vector2 pOut);
        
        /// <summary>
        ///     Igs the get window size using the specified p out
        /// </summary>
        /// <param name="pOut">The out</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "igGetWindowSize")]
        public static extern void igGetWindowSize(out Vector2 pOut);
        
        /// <summary>
        ///     Igs the get window viewport
        /// </summary>
        /// <returns>The im gui viewport</returns>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "igGetWindowViewport")]
        public static extern IntPtr igGetWindowViewport();
        
        /// <summary>
        ///     Igs the get window width
        /// </summary>
        /// <returns>The float</returns>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "igGetWindowWidth")]
        public static extern float igGetWindowWidth();
        
        /// <summary>
        ///     Igs the image using the specified user texture id
        /// </summary>
        /// <param name="userTextureId">The user texture id</param>
        /// <param name="size">The size</param>
        /// <param name="uv0">The uv</param>
        /// <param name="uv1">The uv</param>
        /// <param name="tintCol">The tint col</param>
        /// <param name="borderCol">The border col</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "igImage")]
        public static extern void igImage(IntPtr userTextureId, Vector2 size, Vector2 uv0, Vector2 uv1, Vector4 tintCol, Vector4 borderCol);
        
        /// <summary>
        ///     Igs the image button using the specified str id
        /// </summary>
        /// <param name="strId">The str id</param>
        /// <param name="userTextureId">The user texture id</param>
        /// <param name="size">The size</param>
        /// <param name="uv0">The uv</param>
        /// <param name="uv1">The uv</param>
        /// <param name="bgCol">The bg col</param>
        /// <param name="tintCol">The tint col</param>
        /// <returns>The byte</returns>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "igImageButton")]
        public static extern byte igImageButton(byte[] strId, IntPtr userTextureId, Vector2 size, Vector2 uv0, Vector2 uv1, Vector4 bgCol, Vector4 tintCol);
        
        /// <summary>
        ///     Igs the indent using the specified indent w
        /// </summary>
        /// <param name="indentW">The indent</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "igIndent")]
        public static extern void igIndent(float indentW);
        
        /// <summary>
        ///     Igs the input double using the specified label
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="v">The </param>
        /// <param name="step">The step</param>
        /// <param name="stepFast">The step fast</param>
        /// <param name="format">The format</param>
        /// <param name="flags">The flags</param>
        /// <returns>The byte</returns>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "igInputDouble")]
        public static extern byte igInputDouble(byte[] label, ref double v, double step, double stepFast, byte[] format, ImGuiInputTextFlags flags);
        
        /// <summary>
        ///     Igs the input float using the specified label
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="v">The </param>
        /// <param name="step">The step</param>
        /// <param name="stepFast">The step fast</param>
        /// <param name="format">The format</param>
        /// <param name="flags">The flags</param>
        /// <returns>The byte</returns>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "igInputFloat")]
        public static extern byte igInputFloat(byte[] label, ref float v, float step, float stepFast, byte[] format, ImGuiInputTextFlags flags);
        
        /// <summary>
        ///     Igs the input float 2 using the specified label
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="v">The </param>
        /// <param name="format">The format</param>
        /// <param name="flags">The flags</param>
        /// <returns>The byte</returns>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "igInputFloat2")]
        public static extern byte igInputFloat2(byte[] label, ref Vector2 v, byte[] format, ImGuiInputTextFlags flags);
        
        /// <summary>
        ///     Igs the input float 3 using the specified label
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="v">The </param>
        /// <param name="format">The format</param>
        /// <param name="flags">The flags</param>
        /// <returns>The byte</returns>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "igInputFloat3")]
        public static extern byte igInputFloat3(byte[] label, ref Vector3 v, byte[] format, ImGuiInputTextFlags flags);
        
        /// <summary>
        ///     Igs the input float 4 using the specified label
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="v">The </param>
        /// <param name="format">The format</param>
        /// <param name="flags">The flags</param>
        /// <returns>The byte</returns>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "igInputFloat4")]
        public static extern byte igInputFloat4(byte[] label, ref Vector4 v, byte[] format, ImGuiInputTextFlags flags);
        
        /// <summary>
        ///     Igs the input int using the specified label
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="v">The </param>
        /// <param name="step">The step</param>
        /// <param name="stepFast">The step fast</param>
        /// <param name="flags">The flags</param>
        /// <returns>The byte</returns>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "igInputInt")]
        public static extern byte igInputInt(byte[] label, ref int v, int step, int stepFast, ImGuiInputTextFlags flags);
        
        /// <summary>
        ///     Igs the input int 2 using the specified label
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="v">The </param>
        /// <param name="flags">The flags</param>
        /// <returns>The byte</returns>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "igInputInt2")]
        public static extern byte igInputInt2(byte[] label, ref int v, ImGuiInputTextFlags flags);
        
        /// <summary>
        ///     Igs the input int 3 using the specified label
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="v">The </param>
        /// <param name="flags">The flags</param>
        /// <returns>The byte</returns>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "_igInputInt3")]
        public static extern byte igInputInt3(byte[] label, ref int v, ImGuiInputTextFlags flags);
        
        /// <summary>
        ///     Igs the input int 4 using the specified label
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="v">The </param>
        /// <param name="flags">The flags</param>
        /// <returns>The byte</returns>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "igInputInt4")]
        public static extern byte igInputInt4(byte[] label, ref int v, ImGuiInputTextFlags flags);
        
        /// <summary>
        ///     Igs the input scalar using the specified label
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="dataType">The data type</param>
        /// <param name="pData">The data</param>
        /// <param name="pStep">The step</param>
        /// <param name="pStepFast">The step fast</param>
        /// <param name="format">The format</param>
        /// <param name="flags">The flags</param>
        /// <returns>The byte</returns>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "igInputScalar")]
        public static extern byte igInputScalar(byte[] label, ImGuiDataType dataType, IntPtr pData, IntPtr pStep, IntPtr pStepFast, byte[] format, ImGuiInputTextFlags flags);
        
        /// <summary>
        ///     Igs the input scalar n using the specified label
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="dataType">The data type</param>
        /// <param name="pData">The data</param>
        /// <param name="components">The components</param>
        /// <param name="pStep">The step</param>
        /// <param name="pStepFast">The step fast</param>
        /// <param name="format">The format</param>
        /// <param name="flags">The flags</param>
        /// <returns>The byte</returns>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "igInputScalarN")]
        public static extern byte igInputScalarN(byte[] label, ImGuiDataType dataType, IntPtr pData, int components, IntPtr pStep, IntPtr pStepFast, byte[] format, ImGuiInputTextFlags flags);
        
        /// <summary>
        ///     Igs the input text using the specified label
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="buf">The buf</param>
        /// <param name="bufSize">The buf size</param>
        /// <param name="flags">The flags</param>
        /// <param name="callback">The callback</param>
        /// <param name="userData">The user data</param>
        /// <returns>The byte</returns>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "igInputText")]
        public static extern byte igInputText(byte[] label, IntPtr buf, uint bufSize, ImGuiInputTextFlags flags, ImGuiInputTextCallback callback, IntPtr userData);
        
        /// <summary>
        ///     Igs the input text multiline using the specified label
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="buf">The buf</param>
        /// <param name="bufSize">The buf size</param>
        /// <param name="size">The size</param>
        /// <param name="flags">The flags</param>
        /// <param name="callback">The callback</param>
        /// <param name="userData">The user data</param>
        /// <returns>The byte</returns>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "igInputTextMultiline")]
        public static extern byte igInputTextMultiline(byte[] label, byte[] buf, uint bufSize, Vector2 size, ImGuiInputTextFlags flags, ImGuiInputTextCallback callback, IntPtr userData);
        
        /// <summary>
        ///     Igs the input text with hint using the specified label
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="hint">The hint</param>
        /// <param name="buf">The buf</param>
        /// <param name="bufSize">The buf size</param>
        /// <param name="flags">The flags</param>
        /// <param name="callback">The callback</param>
        /// <param name="userData">The user data</param>
        /// <returns>The byte</returns>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "igInputTextWithHint")]
        public static extern byte igInputTextWithHint(byte[] label, byte[] hint, byte[] buf, uint bufSize, ImGuiInputTextFlags flags, ImGuiInputTextCallback callback, IntPtr userData);
        
        /// <summary>
        ///     Igs the invisible button using the specified str id
        /// </summary>
        /// <param name="strId">The str id</param>
        /// <param name="size">The size</param>
        /// <param name="flags">The flags</param>
        /// <returns>The byte</returns>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "igInvisibleButton")]
        public static extern byte igInvisibleButton(byte[] strId, Vector2 size, ImGuiButtonFlags flags);
        
        /// <summary>
        ///     Igs the is any item active
        /// </summary>
        /// <returns>The byte</returns>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "igIsAnyItemActive")]
        public static extern byte igIsAnyItemActive();
        
        /// <summary>
        ///     Igs the is any item focused
        /// </summary>
        /// <returns>The byte</returns>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "igIsAnyItemFocused")]
        public static extern byte igIsAnyItemFocused();
        
        /// <summary>
        ///     Igs the is any item hovered
        /// </summary>
        /// <returns>The byte</returns>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "igIsAnyItemHovered")]
        public static extern byte igIsAnyItemHovered();
        
        /// <summary>
        ///     Igs the is any mouse down
        /// </summary>
        /// <returns>The byte</returns>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "igIsAnyMouseDown")]
        public static extern byte igIsAnyMouseDown();
        
        /// <summary>
        ///     Igs the is item activated
        /// </summary>
        /// <returns>The byte</returns>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "igIsItemActivated")]
        public static extern byte igIsItemActivated();
        
        /// <summary>
        ///     Igs the is item active
        /// </summary>
        /// <returns>The byte</returns>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "igIsItemActive")]
        public static extern byte igIsItemActive();
        
        /// <summary>
        ///     Igs the is item clicked using the specified mouse button
        /// </summary>
        /// <param name="mouseButton">The mouse button</param>
        /// <returns>The byte</returns>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "igIsItemClicked")]
        public static extern byte igIsItemClicked(ImGuiMouseButton mouseButton);
        
        /// <summary>
        ///     Igs the is item deactivated
        /// </summary>
        /// <returns>The byte</returns>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "igIsItemDeactivated")]
        public static extern byte igIsItemDeactivated();
        
        /// <summary>
        ///     Igs the is item deactivated after edit
        /// </summary>
        /// <returns>The byte</returns>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "igIsItemDeactivatedAfterEdit")]
        public static extern byte igIsItemDeactivatedAfterEdit();
        
        /// <summary>
        ///     Igs the is item edited
        /// </summary>
        /// <returns>The byte</returns>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "igIsItemEdited")]
        public static extern byte igIsItemEdited();
        
        /// <summary>
        ///     Igs the is item focused
        /// </summary>
        /// <returns>The byte</returns>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "igIsItemFocused")]
        public static extern byte igIsItemFocused();
        
        /// <summary>
        ///     Igs the is item hovered using the specified flags
        /// </summary>
        /// <param name="flags">The flags</param>
        /// <returns>The byte</returns>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "igIsItemHovered")]
        public static extern byte igIsItemHovered(ImGuiHoveredFlags flags);
        
        /// <summary>
        ///     Igs the is item toggled open
        /// </summary>
        /// <returns>The byte</returns>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "igIsItemToggledOpen")]
        public static extern byte igIsItemToggledOpen();
        
        /// <summary>
        ///     Igs the is item visible
        /// </summary>
        /// <returns>The byte</returns>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "igIsItemVisible")]
        public static extern byte igIsItemVisible();
        
        /// <summary>
        ///     Igs the is key down nil using the specified key
        /// </summary>
        /// <param name="key">The key</param>
        /// <returns>The byte</returns>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "igIsKeyDown_Nil")]
        public static extern byte igIsKeyDown_Nil(ImGuiKey key);
        
        /// <summary>
        ///     Igs the is key pressed bool using the specified key
        /// </summary>
        /// <param name="key">The key</param>
        /// <param name="repeat">The repeat</param>
        /// <returns>The byte</returns>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "igIsKeyPressed_Bool")]
        public static extern byte igIsKeyPressed_Bool(ImGuiKey key, byte repeat);
        
        /// <summary>
        ///     Igs the is key released nil using the specified key
        /// </summary>
        /// <param name="key">The key</param>
        /// <returns>The byte</returns>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "igIsKeyReleased_Nil")]
        public static extern byte igIsKeyReleased_Nil(ImGuiKey key);
        
        /// <summary>
        ///     Igs the is mouse clicked bool using the specified button
        /// </summary>
        /// <param name="button">The button</param>
        /// <param name="repeat">The repeat</param>
        /// <returns>The byte</returns>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "igIsMouseClicked_Bool")]
        public static extern byte igIsMouseClicked_Bool(ImGuiMouseButton button, byte repeat);
        
        /// <summary>
        ///     Igs the is mouse double clicked using the specified button
        /// </summary>
        /// <param name="button">The button</param>
        /// <returns>The byte</returns>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "igIsMouseDoubleClicked")]
        public static extern byte igIsMouseDoubleClicked(ImGuiMouseButton button);
        
        /// <summary>
        ///     Igs the is mouse down nil using the specified button
        /// </summary>
        /// <param name="button">The button</param>
        /// <returns>The byte</returns>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "igIsMouseDown_Nil")]
        public static extern byte igIsMouseDown_Nil(ImGuiMouseButton button);
        
        /// <summary>
        ///     Igs the is mouse dragging using the specified button
        /// </summary>
        /// <param name="button">The button</param>
        /// <param name="lockThreshold">The lock threshold</param>
        /// <returns>The byte</returns>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "igIsMouseDragging")]
        public static extern byte igIsMouseDragging(ImGuiMouseButton button, float lockThreshold);
        
        /// <summary>
        ///     Igs the is mouse hovering rect using the specified r min
        /// </summary>
        /// <param name="rMin">The min</param>
        /// <param name="rMax">The max</param>
        /// <param name="clip">The clip</param>
        /// <returns>The byte</returns>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "igIsMouseHoveringRect")]
        public static extern byte igIsMouseHoveringRect(Vector2 rMin, Vector2 rMax, byte clip);
        
        /// <summary>
        ///     Igs the is mouse pos valid using the specified mouse pos
        /// </summary>
        /// <param name="mousePos">The mouse pos</param>
        /// <returns>The byte</returns>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "igIsMousePosValid")]
        public static extern byte igIsMousePosValid(Vector2* mousePos);
        
        /// <summary>
        ///     Igs the is mouse released nil using the specified button
        /// </summary>
        /// <param name="button">The button</param>
        /// <returns>The byte</returns>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "igIsMouseReleased_Nil")]
        public static extern byte igIsMouseReleased_Nil(ImGuiMouseButton button);
        
        /// <summary>
        ///     Igs the is popup open str using the specified str id
        /// </summary>
        /// <param name="strId">The str id</param>
        /// <param name="flags">The flags</param>
        /// <returns>The byte</returns>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "igIsPopupOpen_Str")]
        public static extern byte igIsPopupOpen_Str(byte[] strId, ImGuiPopupFlags flags);
        
        /// <summary>
        ///     Igs the is rect visible nil using the specified size
        /// </summary>
        /// <param name="size">The size</param>
        /// <returns>The byte</returns>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "igIsRectVisible_Nil")]
        public static extern byte igIsRectVisible_Nil(Vector2 size);
        
        /// <summary>
        ///     Igs the is rect visible vec 2 using the specified rect min
        /// </summary>
        /// <param name="rectMin">The rect min</param>
        /// <param name="rectMax">The rect max</param>
        /// <returns>The byte</returns>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "igIsRectVisible_Vec2")]
        public static extern byte igIsRectVisible_Vec2(Vector2 rectMin, Vector2 rectMax);
        
        /// <summary>
        ///     Igs the is window appearing
        /// </summary>
        /// <returns>The byte</returns>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "igIsWindowAppearing")]
        public static extern byte igIsWindowAppearing();
        
        /// <summary>
        ///     Igs the is window collapsed
        /// </summary>
        /// <returns>The byte</returns>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "igIsWindowCollapsed")]
        public static extern byte igIsWindowCollapsed();
        
        /// <summary>
        ///     Igs the is window docked
        /// </summary>
        /// <returns>The byte</returns>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "igIsWindowDocked")]
        public static extern byte igIsWindowDocked();
        
        /// <summary>
        ///     Igs the is window focused using the specified flags
        /// </summary>
        /// <param name="flags">The flags</param>
        /// <returns>The byte</returns>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "igIsWindowFocused")]
        public static extern byte igIsWindowFocused(ImGuiFocusedFlags flags);
        
        /// <summary>
        ///     Igs the is window hovered using the specified flags
        /// </summary>
        /// <param name="flags">The flags</param>
        /// <returns>The byte</returns>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "igIsWindowHovered")]
        public static extern byte igIsWindowHovered(ImGuiHoveredFlags flags);
        
        /// <summary>
        ///     Igs the label text using the specified label
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="fmt">The fmt</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "igLabelText")]
        public static extern void igLabelText(byte[] label, byte[] fmt);
        
        /// <summary>
        ///     Igs the list box str arr using the specified label
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="currentItem">The current item</param>
        /// <param name="items">The items</param>
        /// <param name="itemsCount">The items count</param>
        /// <param name="heightInItems">The height in items</param>
        /// <returns>The byte</returns>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "igListBox_Str_arr")]
        public static extern byte igListBox_Str_arr(byte[] label, ref int currentItem, byte[][] items, int itemsCount, int heightInItems);
        
        /// <summary>
        ///     Igs the load ini settings from disk using the specified ini filename
        /// </summary>
        /// <param name="iniFilename">The ini filename</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "igLoadIniSettingsFromDisk")]
        public static extern void igLoadIniSettingsFromDisk(byte[] iniFilename);
        
        /// <summary>
        ///     Igs the load ini settings from memory using the specified ini data
        /// </summary>
        /// <param name="iniData">The ini data</param>
        /// <param name="iniSize">The ini size</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "igLoadIniSettingsFromMemory")]
        public static extern void igLoadIniSettingsFromMemory(byte* iniData, uint iniSize);
        
        /// <summary>
        ///     Igs the log buttons
        /// </summary>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "igLogButtons")]
        public static extern void igLogButtons();
        
        /// <summary>
        ///     Igs the log finish
        /// </summary>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "igLogFinish")]
        public static extern void igLogFinish();
        
        /// <summary>
        ///     Igs the log text using the specified fmt
        /// </summary>
        /// <param name="fmt">The fmt</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "igLogText")]
        public static extern void igLogText(byte[] fmt);
        
        /// <summary>
        ///     Igs the log to clipboard using the specified auto open depth
        /// </summary>
        /// <param name="autoOpenDepth">The auto open depth</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "igLogToClipboard")]
        public static extern void igLogToClipboard(int autoOpenDepth);
        
        /// <summary>
        ///     Igs the log to file using the specified auto open depth
        /// </summary>
        /// <param name="autoOpenDepth">The auto open depth</param>
        /// <param name="filename">The filename</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "igLogToFile")]
        public static extern void igLogToFile(int autoOpenDepth, byte* filename);
        
        /// <summary>
        ///     Igs the log to tty using the specified auto open depth
        /// </summary>
        /// <param name="autoOpenDepth">The auto open depth</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "igLogToTTY")]
        public static extern void igLogToTTY(int autoOpenDepth);
        
        /// <summary>
        ///     Igs the mem alloc using the specified size
        /// </summary>
        /// <param name="size">The size</param>
        /// <returns>The void</returns>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "igMemAlloc")]
        public static extern IntPtr igMemAlloc(uint size);
        
        /// <summary>
        ///     Igs the mem free using the specified ptr
        /// </summary>
        /// <param name="ptr">The ptr</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "igMemFree")]
        public static extern void igMemFree(IntPtr ptr);
        
        /// <summary>
        ///     Igs the menu item bool using the specified label
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="shortcut">The shortcut</param>
        /// <param name="selected">The selected</param>
        /// <param name="enabled">The enabled</param>
        /// <returns>The byte</returns>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "igMenuItem_Bool")]
        public static extern byte igMenuItem_Bool(byte[] label, byte[] shortcut, byte selected, byte enabled);
        
        /// <summary>
        ///     Igs the menu item bool ptr using the specified label
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="shortcut">The shortcut</param>
        /// <param name="pSelected">The selected</param>
        /// <param name="enabled">The enabled</param>
        /// <returns>The byte</returns>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "igMenuItem_BoolPtr")]
        public static extern byte igMenuItem_BoolPtr(byte[] label, byte[] shortcut, bool pSelected, bool enabled);
        
        /// <summary>
        ///     Igs the new frame
        /// </summary>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "igNewFrame")]
        public static extern void igNewFrame();
        
        /// <summary>
        ///     Igs the new line
        /// </summary>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "igNewLine")]
        public static extern void igNewLine();
        
        /// <summary>
        ///     Igs the next column
        /// </summary>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "igNextColumn")]
        public static extern void igNextColumn();
        
        /// <summary>
        ///     Igs the open popup str using the specified str id
        /// </summary>
        /// <param name="strId">The str id</param>
        /// <param name="popupFlags">The popup flags</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "igOpenPopup_Str")]
        public static extern void igOpenPopup_Str(byte[] strId, ImGuiPopupFlags popupFlags);
        
        /// <summary>
        ///     Igs the open popup id using the specified id
        /// </summary>
        /// <param name="id">The id</param>
        /// <param name="popupFlags">The popup flags</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "igOpenPopup_ID")]
        public static extern void igOpenPopup_ID(uint id, ImGuiPopupFlags popupFlags);
        
        /// <summary>
        ///     Igs the open popup on item click using the specified str id
        /// </summary>
        /// <param name="strId">The str id</param>
        /// <param name="popupFlags">The popup flags</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "igOpenPopupOnItemClick")]
        public static extern void igOpenPopupOnItemClick(byte[] strId, ImGuiPopupFlags popupFlags);
        
        /// <summary>
        ///     Igs the plot histogram float ptr using the specified label
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
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "igPlotHistogram_FloatPtr")]
        public static extern void igPlotHistogram_FloatPtr(byte[] label, float values, int valuesCount, int valuesOffset, byte[] overlayText, float scaleMin, float scaleMax, Vector2 graphSize, int stride);
        
        /// <summary>
        ///     Igs the plot lines float ptr using the specified label
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
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "igPlotLines_FloatPtr")]
        public static extern void igPlotLines_FloatPtr(byte[] label, float values, int valuesCount, int valuesOffset, byte[] overlayText, float scaleMin, float scaleMax, Vector2 graphSize, int stride);
        
        /// <summary>
        ///     Igs the pop allow keyboard focus
        /// </summary>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "igPopAllowKeyboardFocus")]
        public static extern void igPopAllowKeyboardFocus();
        
        /// <summary>
        ///     Igs the pop button repeat
        /// </summary>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "igPopButtonRepeat")]
        public static extern void igPopButtonRepeat();
        
        /// <summary>
        ///     Igs the pop clip rect
        /// </summary>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "igPopClipRect")]
        public static extern void igPopClipRect();
        
        /// <summary>
        ///     Igs the pop font
        /// </summary>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "igPopFont")]
        public static extern void igPopFont();
        
        /// <summary>
        ///     Igs the pop id
        /// </summary>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "igPopID")]
        public static extern void igPopID();
        
        /// <summary>
        ///     Igs the pop item width
        /// </summary>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "igPopItemWidth")]
        public static extern void igPopItemWidth();
        
        /// <summary>
        ///     Igs the pop style color using the specified count
        /// </summary>
        /// <param name="count">The count</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "igPopStyleColor")]
        public static extern void igPopStyleColor(int count);
        
        /// <summary>
        ///     Igs the pop style var using the specified count
        /// </summary>
        /// <param name="count">The count</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "igPopStyleVar")]
        public static extern void igPopStyleVar(int count);
        
        /// <summary>
        ///     Igs the pop text wrap pos
        /// </summary>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "igPopTextWrapPos")]
        public static extern void igPopTextWrapPos();
        
        /// <summary>
        ///     Igs the progress bar using the specified fraction
        /// </summary>
        /// <param name="fraction">The fraction</param>
        /// <param name="sizeArg">The size arg</param>
        /// <param name="overlay">The overlay</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "igProgressBar")]
        public static extern void igProgressBar(float fraction, Vector2 sizeArg, byte* overlay);
        
        /// <summary>
        ///     Igs the push allow keyboard focus using the specified allow keyboard focus
        /// </summary>
        /// <param name="allowKeyboardFocus">The allow keyboard focus</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "igPushAllowKeyboardFocus")]
        public static extern void igPushAllowKeyboardFocus(byte allowKeyboardFocus);
        
        /// <summary>
        ///     Igs the push button repeat using the specified repeat
        /// </summary>
        /// <param name="repeat">The repeat</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "igPushButtonRepeat")]
        public static extern void igPushButtonRepeat(byte repeat);
        
        /// <summary>
        ///     Igs the push clip rect using the specified clip rect min
        /// </summary>
        /// <param name="clipRectMin">The clip rect min</param>
        /// <param name="clipRectMax">The clip rect max</param>
        /// <param name="intersectWithCurrentClipRect">The intersect with current clip rect</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "igPushClipRect")]
        public static extern void igPushClipRect(Vector2 clipRectMin, Vector2 clipRectMax, byte intersectWithCurrentClipRect);
        
        /// <summary>
        ///     Igs the push font using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "igPushFont")]
        public static extern void igPushFont(IntPtr font);
        
        /// <summary>
        ///     Igs the push id str using the specified str id
        /// </summary>
        /// <param name="strId">The str id</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "igPushID_Str")]
        public static extern void igPushID_Str(byte[] strId);
        
        /// <summary>
        ///     Igs the push id str str using the specified str id begin
        /// </summary>
        /// <param name="strIdBegin">The str id begin</param>
        /// <param name="strIdEnd">The str id end</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "igPushID_StrStr")]
        public static extern void igPushID_StrStr(byte* strIdBegin, byte* strIdEnd);
        
        /// <summary>
        ///     Igs the push id ptr using the specified ptr id
        /// </summary>
        /// <param name="ptrId">The ptr id</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "igPushID_Ptr")]
        public static extern void igPushID_Ptr(IntPtr ptrId);
        
        /// <summary>
        ///     Igs the push id int using the specified int id
        /// </summary>
        /// <param name="intId">The int id</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "igPushID_Int")]
        public static extern void igPushID_Int(int intId);
        
        /// <summary>
        ///     Igs the push item width using the specified item width
        /// </summary>
        /// <param name="itemWidth">The item width</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "igPushItemWidth")]
        public static extern void igPushItemWidth(float itemWidth);
        
        /// <summary>
        ///     Igs the push style color u 32 using the specified idx
        /// </summary>
        /// <param name="idx">The idx</param>
        /// <param name="col">The col</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "igPushStyleColor_U32")]
        public static extern void igPushStyleColor_U32(ImGuiCol idx, uint col);
        
        /// <summary>
        ///     Igs the push style color vec 4 using the specified idx
        /// </summary>
        /// <param name="idx">The idx</param>
        /// <param name="col">The col</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "igPushStyleColor_Vec4")]
        public static extern void igPushStyleColor_Vec4(ImGuiCol idx, Vector4 col);
        
        /// <summary>
        ///     Igs the push style var float using the specified idx
        /// </summary>
        /// <param name="idx">The idx</param>
        /// <param name="val">The val</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "igPushStyleVar_Float")]
        public static extern void igPushStyleVar_Float(ImGuiStyleVar idx, float val);
        
        /// <summary>
        ///     Igs the push style var vec 2 using the specified idx
        /// </summary>
        /// <param name="idx">The idx</param>
        /// <param name="val">The val</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "igPushStyleVar_Vec2")]
        public static extern void igPushStyleVar_Vec2(ImGuiStyleVar idx, Vector2 val);
        
        /// <summary>
        ///     Igs the push text wrap pos using the specified wrap local pos x
        /// </summary>
        /// <param name="wrapLocalPosX">The wrap local pos</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "igPushTextWrapPos")]
        public static extern void igPushTextWrapPos(float wrapLocalPosX);
        
        /// <summary>
        ///     Igs the radio button bool using the specified label
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="active">The active</param>
        /// <returns>The byte</returns>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "igRadioButton_Bool")]
        public static extern byte igRadioButton_Bool(byte[] label, bool active);
        
        /// <summary>
        ///     Igs the radio button int ptr using the specified label
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="v">The </param>
        /// <param name="vButton">The button</param>
        /// <returns>The byte</returns>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "igRadioButton_IntPtr")]
        public static extern byte igRadioButton_IntPtr(byte[] label, ref int v, int vButton);
        
        /// <summary>
        ///     Igs the render
        /// </summary>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "igRender")]
        public static extern void igRender();
        
        /// <summary>
        ///     Igs the render platform windows default using the specified platform render arg
        /// </summary>
        /// <param name="platformRenderArg">The platform render arg</param>
        /// <param name="rendererRenderArg">The renderer render arg</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "igRenderPlatformWindowsDefault")]
        public static extern void igRenderPlatformWindowsDefault(IntPtr platformRenderArg, IntPtr rendererRenderArg);
        
        /// <summary>
        ///     Igs the reset mouse drag delta using the specified button
        /// </summary>
        /// <param name="button">The button</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "igResetMouseDragDelta")]
        public static extern void igResetMouseDragDelta(ImGuiMouseButton button);
        
        /// <summary>
        ///     Igs the same line using the specified offset from start x
        /// </summary>
        /// <param name="offsetFromStartX">The offset from start</param>
        /// <param name="spacing">The spacing</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "igSameLine")]
        public static extern void igSameLine(float offsetFromStartX, float spacing);
        
        /// <summary>
        ///     Igs the save ini settings to disk using the specified ini filename
        /// </summary>
        /// <param name="iniFilename">The ini filename</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "igSaveIniSettingsToDisk")]
        public static extern void igSaveIniSettingsToDisk(byte[] iniFilename);
        
        /// <summary>
        ///     Igs the save ini settings to memory using the specified out ini size
        /// </summary>
        /// <param name="outIniSize">The out ini size</param>
        /// <returns>The byte</returns>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "igSaveIniSettingsToMemory")]
        public static extern byte* igSaveIniSettingsToMemory(uint* outIniSize);
        
        /// <summary>
        ///     Igs the selectable bool using the specified label
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="selected">The selected</param>
        /// <param name="flags">The flags</param>
        /// <param name="size">The size</param>
        /// <returns>The byte</returns>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "igSelectable_Bool")]
        public static extern byte igSelectable_Bool(byte[] label, bool selected, ImGuiSelectableFlags flags, Vector2 size);
        
        /// <summary>
        ///     Igs the selectable bool ptr using the specified label
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="pSelected">The selected</param>
        /// <param name="flags">The flags</param>
        /// <param name="size">The size</param>
        /// <returns>The byte</returns>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "igSelectable_BoolPtr")]
        public static extern byte igSelectable_BoolPtr(byte[] label, bool pSelected, ImGuiSelectableFlags flags, Vector2 size);
        
        /// <summary>
        ///     Igs the separator
        /// </summary>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "igSeparator")]
        public static extern void igSeparator();
        
        /// <summary>
        ///     Igs the set allocator functions using the specified alloc func
        /// </summary>
        /// <param name="allocFunc">The alloc func</param>
        /// <param name="freeFunc">The free func</param>
        /// <param name="userData">The user data</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "igSetAllocatorFunctions")]
        public static extern void igSetAllocatorFunctions(IntPtr allocFunc, IntPtr freeFunc, IntPtr userData);
        
        /// <summary>
        ///     Igs the set clipboard text using the specified text
        /// </summary>
        /// <param name="text">The text</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "igSetClipboardText")]
        public static extern void igSetClipboardText(byte[] text);
        
        /// <summary>
        ///     Igs the set color edit options using the specified flags
        /// </summary>
        /// <param name="flags">The flags</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "igSetColorEditOptions")]
        public static extern void igSetColorEditOptions(ImGuiColorEditFlags flags);
        
        /// <summary>
        ///     Igs the set column offset using the specified column index
        /// </summary>
        /// <param name="columnIndex">The column index</param>
        /// <param name="offsetX">The offset</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "igSetColumnOffset")]
        public static extern void igSetColumnOffset(int columnIndex, float offsetX);
        
        /// <summary>
        ///     Igs the set column width using the specified column index
        /// </summary>
        /// <param name="columnIndex">The column index</param>
        /// <param name="width">The width</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "igSetColumnWidth")]
        public static extern void igSetColumnWidth(int columnIndex, float width);
        
        /// <summary>
        ///     Igs the set current context using the specified ctx
        /// </summary>
        /// <param name="ctx">The ctx</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "igSetCurrentContext")]
        public static extern void igSetCurrentContext(IntPtr ctx);
        
        /// <summary>
        ///     Igs the set cursor pos using the specified local pos
        /// </summary>
        /// <param name="localPos">The local pos</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "igSetCursorPos")]
        public static extern void igSetCursorPos(Vector2 localPos);
        
        /// <summary>
        ///     Igs the set cursor pos x using the specified local x
        /// </summary>
        /// <param name="localX">The local</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "igSetCursorPosX")]
        public static extern void igSetCursorPosX(float localX);
        
        /// <summary>
        ///     Igs the set cursor pos y using the specified local y
        /// </summary>
        /// <param name="localY">The local</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "igSetCursorPosY")]
        public static extern void igSetCursorPosY(float localY);
        
        /// <summary>
        ///     Igs the set cursor screen pos using the specified pos
        /// </summary>
        /// <param name="pos">The pos</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "igSetCursorScreenPos")]
        public static extern void igSetCursorScreenPos(Vector2 pos);
        
        /// <summary>
        ///     Igs the set drag drop payload using the specified type
        /// </summary>
        /// <param name="type">The type</param>
        /// <param name="data">The data</param>
        /// <param name="sz">The sz</param>
        /// <param name="cond">The cond</param>
        /// <returns>The byte</returns>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "igSetDragDropPayload")]
        public static extern byte igSetDragDropPayload(byte* type, IntPtr data, uint sz, ImGuiCond cond);
        
        /// <summary>
        ///     Igs the set item allow overlap
        /// </summary>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "igSetItemAllowOverlap")]
        public static extern void igSetItemAllowOverlap();
        
        /// <summary>
        ///     Igs the set item default focus
        /// </summary>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "igSetItemDefaultFocus")]
        public static extern void igSetItemDefaultFocus();
        
        /// <summary>
        ///     Igs the set keyboard focus here using the specified offset
        /// </summary>
        /// <param name="offset">The offset</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "igSetKeyboardFocusHere")]
        public static extern void igSetKeyboardFocusHere(int offset);
        
        /// <summary>
        ///     Igs the set mouse cursor using the specified cursor type
        /// </summary>
        /// <param name="cursorType">The cursor type</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "igSetMouseCursor")]
        public static extern void igSetMouseCursor(ImGuiMouseCursor cursorType);
        
        /// <summary>
        ///     Igs the set next frame want capture keyboard using the specified want capture keyboard
        /// </summary>
        /// <param name="wantCaptureKeyboard">The want capture keyboard</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "igSetNextFrameWantCaptureKeyboard")]
        public static extern void igSetNextFrameWantCaptureKeyboard(byte wantCaptureKeyboard);
        
        /// <summary>
        ///     Igs the set next frame want capture mouse using the specified want capture mouse
        /// </summary>
        /// <param name="wantCaptureMouse">The want capture mouse</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "igSetNextFrameWantCaptureMouse")]
        public static extern void igSetNextFrameWantCaptureMouse(byte wantCaptureMouse);
        
        /// <summary>
        ///     Igs the set next item open using the specified is open
        /// </summary>
        /// <param name="isOpen">The is open</param>
        /// <param name="cond">The cond</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "igSetNextItemOpen")]
        public static extern void igSetNextItemOpen(byte isOpen, ImGuiCond cond);
        
        /// <summary>
        ///     Igs the set next item width using the specified item width
        /// </summary>
        /// <param name="itemWidth">The item width</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "igSetNextItemWidth")]
        public static extern void igSetNextItemWidth(float itemWidth);
        
        /// <summary>
        ///     Igs the set next window bg alpha using the specified alpha
        /// </summary>
        /// <param name="alpha">The alpha</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "igSetNextWindowBgAlpha")]
        public static extern void igSetNextWindowBgAlpha(float alpha);
        
        /// <summary>
        ///     Igs the set next window using the specified window class
        /// </summary>
        /// <param name="windowClass">The window class</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "igSetNextWindowClass")]
        public static extern void igSetNextWindowClass(ImGuiWindowClass windowClass);
        
        /// <summary>
        ///     Igs the set next window collapsed using the specified collapsed
        /// </summary>
        /// <param name="collapsed">The collapsed</param>
        /// <param name="cond">The cond</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "igSetNextWindowCollapsed")]
        public static extern void igSetNextWindowCollapsed(byte collapsed, ImGuiCond cond);
        
        /// <summary>
        ///     Igs the set next window content size using the specified size
        /// </summary>
        /// <param name="size">The size</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "igSetNextWindowContentSize")]
        public static extern void igSetNextWindowContentSize(Vector2 size);
        
        /// <summary>
        ///     Igs the set next window dock id using the specified dock id
        /// </summary>
        /// <param name="dockId">The dock id</param>
        /// <param name="cond">The cond</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "igSetNextWindowDockID")]
        public static extern void igSetNextWindowDockID(uint dockId, ImGuiCond cond);
        
        /// <summary>
        ///     Igs the set next window focus
        /// </summary>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "igSetNextWindowFocus")]
        public static extern void igSetNextWindowFocus();
        
        /// <summary>
        ///     Igs the set next window pos using the specified pos
        /// </summary>
        /// <param name="pos">The pos</param>
        /// <param name="cond">The cond</param>
        /// <param name="pivot">The pivot</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "igSetNextWindowPos")]
        public static extern void igSetNextWindowPos(Vector2 pos, ImGuiCond cond, Vector2 pivot);
        
        /// <summary>
        ///     Igs the set next window scroll using the specified scroll
        /// </summary>
        /// <param name="scroll">The scroll</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "igSetNextWindowScroll")]
        public static extern void igSetNextWindowScroll(Vector2 scroll);
        
        /// <summary>
        ///     Igs the set next window size using the specified size
        /// </summary>
        /// <param name="size">The size</param>
        /// <param name="cond">The cond</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "igSetNextWindowSize")]
        public static extern void igSetNextWindowSize(Vector2 size, ImGuiCond cond);
        
        /// <summary>
        ///     Igs the set next window size constraints using the specified size min
        /// </summary>
        /// <param name="sizeMin">The size min</param>
        /// <param name="sizeMax">The size max</param>
        /// <param name="customCallback">The custom callback</param>
        /// <param name="customCallbackData">The custom callback data</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "igSetNextWindowSizeConstraints")]
        public static extern void igSetNextWindowSizeConstraints(Vector2 sizeMin, Vector2 sizeMax, ImGuiSizeCallback customCallback, IntPtr customCallbackData);
        
        /// <summary>
        ///     Igs the set next window viewport using the specified viewport id
        /// </summary>
        /// <param name="viewportId">The viewport id</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "igSetNextWindowViewport")]
        public static extern void igSetNextWindowViewport(uint viewportId);
        
        /// <summary>
        ///     Igs the set scroll from pos x float using the specified local x
        /// </summary>
        /// <param name="localX">The local</param>
        /// <param name="centerXRatio">The center ratio</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "igSetScrollFromPosX_Float")]
        public static extern void igSetScrollFromPosX_Float(float localX, float centerXRatio);
        
        /// <summary>
        ///     Igs the set scroll from pos y float using the specified local y
        /// </summary>
        /// <param name="localY">The local</param>
        /// <param name="centerYRatio">The center ratio</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "igSetScrollFromPosY_Float")]
        public static extern void igSetScrollFromPosY_Float(float localY, float centerYRatio);
        
        /// <summary>
        ///     Igs the set scroll here x using the specified center x ratio
        /// </summary>
        /// <param name="centerXRatio">The center ratio</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "igSetScrollHereX")]
        public static extern void igSetScrollHereX(float centerXRatio);
        
        /// <summary>
        ///     Igs the set scroll here y using the specified center y ratio
        /// </summary>
        /// <param name="centerYRatio">The center ratio</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "igSetScrollHereY")]
        public static extern void igSetScrollHereY(float centerYRatio);
        
        /// <summary>
        ///     Igs the set scroll x float using the specified scroll x
        /// </summary>
        /// <param name="scrollX">The scroll</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "igSetScrollX_Float")]
        public static extern void igSetScrollX_Float(float scrollX);
        
        /// <summary>
        ///     Igs the set scroll y float using the specified scroll y
        /// </summary>
        /// <param name="scrollY">The scroll</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "igSetScrollY_Float")]
        public static extern void igSetScrollY_Float(float scrollY);
        
        /// <summary>
        ///     Igs the set state storage using the specified storage
        /// </summary>
        /// <param name="storage">The storage</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "igSetStateStorage")]
        public static extern void igSetStateStorage(ImGuiStorage storage);
        
        /// <summary>
        ///     Igs the set tab item closed using the specified tab or docked window label
        /// </summary>
        /// <param name="tabOrDockedWindowLabel">The tab or docked window label</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "igSetTabItemClosed")]
        public static extern void igSetTabItemClosed(byte* tabOrDockedWindowLabel);
        
        /// <summary>
        ///     Igs the set tooltip using the specified fmt
        /// </summary>
        /// <param name="fmt">The fmt</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "igSetTooltip")]
        public static extern void igSetTooltip(byte[] fmt);
        
        /// <summary>
        ///     Igs the set window collapsed bool using the specified collapsed
        /// </summary>
        /// <param name="collapsed">The collapsed</param>
        /// <param name="cond">The cond</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "igSetWindowCollapsed_Bool")]
        public static extern void igSetWindowCollapsed_Bool(byte collapsed, ImGuiCond cond);
        
        /// <summary>
        ///     Igs the set window collapsed str using the specified name
        /// </summary>
        /// <param name="name">The name</param>
        /// <param name="collapsed">The collapsed</param>
        /// <param name="cond">The cond</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "igSetWindowCollapsed_Str")]
        public static extern void igSetWindowCollapsed_Str(byte[] name, bool collapsed, ImGuiCond cond);
        
        /// <summary>
        ///     Igs the set window focus nil
        /// </summary>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "igSetWindowFocus_Nil")]
        public static extern void igSetWindowFocus_Nil();
        
        /// <summary>
        ///     Igs the set window focus str using the specified name
        /// </summary>
        /// <param name="name">The name</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "igSetWindowFocus_Str")]
        public static extern void igSetWindowFocus_Str(byte[] name);
        
        /// <summary>
        ///     Igs the set window font scale using the specified scale
        /// </summary>
        /// <param name="scale">The scale</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "igSetWindowFontScale")]
        public static extern void igSetWindowFontScale(float scale);
        
        /// <summary>
        ///     Igs the set window pos vec 2 using the specified pos
        /// </summary>
        /// <param name="pos">The pos</param>
        /// <param name="cond">The cond</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "igSetWindowPos_Vec2")]
        public static extern void igSetWindowPos_Vec2(Vector2 pos, ImGuiCond cond);
        
        /// <summary>
        ///     Igs the set window pos str using the specified name
        /// </summary>
        /// <param name="name">The name</param>
        /// <param name="pos">The pos</param>
        /// <param name="cond">The cond</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "igSetWindowPos_Str")]
        public static extern void igSetWindowPos_Str(byte[] name, Vector2 pos, ImGuiCond cond);
        
        /// <summary>
        ///     Igs the set window size vec 2 using the specified size
        /// </summary>
        /// <param name="size">The size</param>
        /// <param name="cond">The cond</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "igSetWindowSize_Vec2")]
        public static extern void igSetWindowSize_Vec2(Vector2 size, ImGuiCond cond);
        
        /// <summary>
        ///     Igs the set window size str using the specified name
        /// </summary>
        /// <param name="name">The name</param>
        /// <param name="size">The size</param>
        /// <param name="cond">The cond</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "igSetWindowSize_Str")]
        public static extern void igSetWindowSize_Str(byte[] name, Vector2 size, ImGuiCond cond);
        
        /// <summary>
        ///     Igs the show about window using the specified p open
        /// </summary>
        /// <param name="pOpen">The open</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "igShowAboutWindow")]
        public static extern void igShowAboutWindow(IntPtr pOpen);
        
        /// <summary>
        ///     Igs the show debug log window using the specified p open
        /// </summary>
        /// <param name="pOpen">The open</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "igShowDebugLogWindow")]
        public static extern void igShowDebugLogWindow(IntPtr pOpen);
        
        /// <summary>
        ///     Igs the show demo window using the specified p open
        /// </summary>
        /// <param name="pOpen">The open</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "igShowDemoWindow")]
        public static extern void igShowDemoWindow(IntPtr pOpen);
        
        /// <summary>
        ///     Igs the show font selector using the specified label
        /// </summary>
        /// <param name="label">The label</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "igShowFontSelector")]
        public static extern void igShowFontSelector(byte[] label);
        
        /// <summary>
        ///     Igs the show metrics window using the specified p open
        /// </summary>
        /// <param name="pOpen">The open</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "igShowMetricsWindow")]
        public static extern void igShowMetricsWindow(IntPtr pOpen);
        
        /// <summary>
        ///     Igs the show stack tool window using the specified p open
        /// </summary>
        /// <param name="pOpen">The open</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "igShowStackToolWindow")]
        public static extern void igShowStackToolWindow(IntPtr pOpen);
        
        /// <summary>
        ///     Igs the show style editor using the specified ref
        /// </summary>
        /// <param name="imGuiStyle"></param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "igShowStyleEditor")]
        public static extern void igShowStyleEditor(ImGuiStyle imGuiStyle);
        
        /// <summary>
        ///     Igs the show style selector using the specified label
        /// </summary>
        /// <param name="label">The label</param>
        /// <returns>The byte</returns>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "igShowStyleSelector")]
        public static extern byte igShowStyleSelector(byte[] label);
        
        /// <summary>
        ///     Igs the show user guide
        /// </summary>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "igShowUserGuide")]
        public static extern void igShowUserGuide();
        
        /// <summary>
        ///     Igs the slider angle using the specified label
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="vRad">The rad</param>
        /// <param name="vDegreesMin">The degrees min</param>
        /// <param name="vDegreesMax">The degrees max</param>
        /// <param name="format">The format</param>
        /// <param name="flags">The flags</param>
        /// <returns>The byte</returns>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "igSliderAngle")]
        public static extern byte igSliderAngle(byte[] label, ref float vRad, float vDegreesMin, float vDegreesMax, byte[] format, ImGuiSliderFlags flags);
        
        /// <summary>
        ///     Igs the slider float using the specified label
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="v">The </param>
        /// <param name="vMin">The min</param>
        /// <param name="vMax">The max</param>
        /// <param name="format">The format</param>
        /// <param name="flags">The flags</param>
        /// <returns>The byte</returns>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "igSliderFloat")]
        public static extern byte igSliderFloat(byte[] label, ref float v, float vMin, float vMax, byte[] format, ImGuiSliderFlags flags);
        
        /// <summary>
        ///     Igs the slider float 2 using the specified label
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="v">The </param>
        /// <param name="vMin">The min</param>
        /// <param name="vMax">The max</param>
        /// <param name="format">The format</param>
        /// <param name="flags">The flags</param>
        /// <returns>The byte</returns>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "igSliderFloat2")]
        public static extern byte igSliderFloat2(byte[] label, ref Vector2 v, float vMin, float vMax, byte[] format, ImGuiSliderFlags flags);
        
        /// <summary>
        ///     Igs the slider float 3 using the specified label
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="v">The </param>
        /// <param name="vMin">The min</param>
        /// <param name="vMax">The max</param>
        /// <param name="format">The format</param>
        /// <param name="flags">The flags</param>
        /// <returns>The byte</returns>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "igSliderFloat3")]
        public static extern byte igSliderFloat3(byte[] label, ref Vector3 v, float vMin, float vMax, byte[] format, ImGuiSliderFlags flags);
        
        /// <summary>
        ///     Igs the slider float 4 using the specified label
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="v">The </param>
        /// <param name="vMin">The min</param>
        /// <param name="vMax">The max</param>
        /// <param name="format">The format</param>
        /// <param name="flags">The flags</param>
        /// <returns>The byte</returns>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "igSliderFloat4")]
        public static extern byte igSliderFloat4(byte[] label, Vector4 v, float vMin, float vMax, byte[] format, ImGuiSliderFlags flags);
        
        /// <summary>
        ///     Igs the slider int using the specified label
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="v">The </param>
        /// <param name="vMin">The min</param>
        /// <param name="vMax">The max</param>
        /// <param name="format">The format</param>
        /// <param name="flags">The flags</param>
        /// <returns>The byte</returns>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "igSliderInt")]
        public static extern byte igSliderInt(byte[] label, ref int v, int vMin, int vMax, byte[] format, ImGuiSliderFlags flags);
        
        /// <summary>
        ///     Igs the slider int 2 using the specified label
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="v">The </param>
        /// <param name="vMin">The min</param>
        /// <param name="vMax">The max</param>
        /// <param name="format">The format</param>
        /// <param name="flags">The flags</param>
        /// <returns>The byte</returns>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "igSliderInt2")]
        public static extern byte igSliderInt2(byte[] label, ref int v, int vMin, int vMax, byte[] format, ImGuiSliderFlags flags);
        
        /// <summary>
        ///     Igs the slider int 3 using the specified label
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="v">The </param>
        /// <param name="vMin">The min</param>
        /// <param name="vMax">The max</param>
        /// <param name="format">The format</param>
        /// <param name="flags">The flags</param>
        /// <returns>The byte</returns>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "igSliderInt3")]
        public static extern byte igSliderInt3(byte[] label, ref int v, int vMin, int vMax, byte[] format, ImGuiSliderFlags flags);
        
        /// <summary>
        ///     Igs the slider int 4 using the specified label
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="v">The </param>
        /// <param name="vMin">The min</param>
        /// <param name="vMax">The max</param>
        /// <param name="format">The format</param>
        /// <param name="flags">The flags</param>
        /// <returns>The byte</returns>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "igSliderInt4")]
        public static extern byte igSliderInt4(byte[] label, ref int v, int vMin, int vMax, byte[] format, ImGuiSliderFlags flags);
        
        /// <summary>
        ///     Igs the slider scalar using the specified label
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="dataType">The data type</param>
        /// <param name="pData">The data</param>
        /// <param name="pMin">The min</param>
        /// <param name="pMax">The max</param>
        /// <param name="format">The format</param>
        /// <param name="flags">The flags</param>
        /// <returns>The byte</returns>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "igSliderScalar")]
        public static extern byte igSliderScalar(byte[] label, ImGuiDataType dataType, IntPtr pData, IntPtr pMin, IntPtr pMax, byte[] format, ImGuiSliderFlags flags);
        
        /// <summary>
        ///     Igs the slider scalar n using the specified label
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="dataType">The data type</param>
        /// <param name="pData">The data</param>
        /// <param name="components">The components</param>
        /// <param name="pMin">The min</param>
        /// <param name="pMax">The max</param>
        /// <param name="format">The format</param>
        /// <param name="flags">The flags</param>
        /// <returns>The byte</returns>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "igSliderScalarN")]
        public static extern byte igSliderScalarN(byte[] label, ImGuiDataType dataType, IntPtr pData, int components, IntPtr pMin, IntPtr pMax, byte[] format, ImGuiSliderFlags flags);
        
        /// <summary>
        ///     Igs the small button using the specified label
        /// </summary>
        /// <param name="label">The label</param>
        /// <returns>The byte</returns>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "igSmallButton")]
        public static extern byte igSmallButton(byte[] label);
        
        /// <summary>
        ///     Igs the spacing
        /// </summary>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "igSpacing")]
        public static extern void igSpacing();
        
        /// <summary>
        ///     Igs the style colors classic using the specified dst
        /// </summary>
        /// <param name="dst">The dst</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "igStyleColorsClassic")]
        public static extern void igStyleColorsClassic(ImGuiStyle dst);
        
        /// <summary>
        ///     Igs the style colors dark using the specified dst
        /// </summary>
        /// <param name="dst">The dst</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "igStyleColorsDark")]
        public static extern void igStyleColorsDark(ImGuiStyle dst);
        
        /// <summary>
        ///     Igs the style colors light using the specified dst
        /// </summary>
        /// <param name="dst">The dst</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "igStyleColorsLight")]
        public static extern void igStyleColorsLight(ImGuiStyle dst);
        
        /// <summary>
        ///     Igs the tab item button using the specified label
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="flags">The flags</param>
        /// <returns>The byte</returns>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "igTabItemButton")]
        public static extern byte igTabItemButton(byte[] label, ImGuiTabItemFlags flags);
        
        /// <summary>
        ///     Igs the table get column count
        /// </summary>
        /// <returns>The int</returns>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "igTableGetColumnCount")]
        public static extern int igTableGetColumnCount();
        
        /// <summary>
        ///     Igs the table get column flags using the specified column n
        /// </summary>
        /// <param name="columnN">The column</param>
        /// <returns>The im gui table column flags</returns>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "igTableGetColumnFlags")]
        public static extern ImGuiTableColumnFlags igTableGetColumnFlags(int columnN);
        
        /// <summary>
        ///     Igs the table get column index
        /// </summary>
        /// <returns>The int</returns>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "igTableGetColumnIndex")]
        public static extern int igTableGetColumnIndex();
        
        /// <summary>
        ///     Igs the table get column name int using the specified column n
        /// </summary>
        /// <param name="columnN">The column</param>
        /// <returns>The byte</returns>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "igTableGetColumnName_Int")]
        public static extern byte* igTableGetColumnName_Int(int columnN);
        
        /// <summary>
        ///     Igs the table get row index
        /// </summary>
        /// <returns>The int</returns>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "igTableGetRowIndex")]
        public static extern int igTableGetRowIndex();
        
        /// <summary>
        ///     Igs the table get sort specs
        /// </summary>
        /// <returns>The im gui table sort specs</returns>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "igTableGetSortSpecs")]
        public static extern ImGuiTableSortSpecs igTableGetSortSpecs();
        
        /// <summary>
        ///     Igs the table header using the specified label
        /// </summary>
        /// <param name="label">The label</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "igTableHeader")]
        public static extern void igTableHeader(byte[] label);
        
        /// <summary>
        ///     Igs the table headers row
        /// </summary>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "igTableHeadersRow")]
        public static extern void igTableHeadersRow();
        
        /// <summary>
        ///     Igs the table next column
        /// </summary>
        /// <returns>The byte</returns>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "igTableNextColumn")]
        public static extern byte igTableNextColumn();
        
        /// <summary>
        ///     Igs the table next row using the specified row flags
        /// </summary>
        /// <param name="rowFlags">The row flags</param>
        /// <param name="minRowHeight">The min row height</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "igTableNextRow")]
        public static extern void igTableNextRow(ImGuiTableRowFlags rowFlags, float minRowHeight);
        
        /// <summary>
        ///     Igs the table set bg color using the specified target
        /// </summary>
        /// <param name="target">The target</param>
        /// <param name="color">The color</param>
        /// <param name="columnN">The column</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "igTableSetBgColor")]
        public static extern void igTableSetBgColor(ImGuiTableBgTarget target, uint color, int columnN);
        
        /// <summary>
        ///     Igs the table set column enabled using the specified column n
        /// </summary>
        /// <param name="columnN">The column</param>
        /// <param name="v">The </param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "igTableSetColumnEnabled")]
        public static extern void igTableSetColumnEnabled(int columnN, byte v);
        
        /// <summary>
        ///     Igs the table set column index using the specified column n
        /// </summary>
        /// <param name="columnN">The column</param>
        /// <returns>The byte</returns>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "igTableSetColumnIndex")]
        public static extern byte igTableSetColumnIndex(int columnN);
        
        /// <summary>
        ///     Igs the table setup column using the specified label
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="flags">The flags</param>
        /// <param name="initWidthOrWeight">The init width or weight</param>
        /// <param name="userId">The user id</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "igTableSetupColumn")]
        public static extern void igTableSetupColumn(byte[] label, ImGuiTableColumnFlags flags, float initWidthOrWeight, uint userId);
        
        /// <summary>
        ///     Igs the table setup scroll freeze using the specified cols
        /// </summary>
        /// <param name="cols">The cols</param>
        /// <param name="rows">The rows</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "igTableSetupScrollFreeze")]
        public static extern void igTableSetupScrollFreeze(int cols, int rows);
        
        /// <summary>
        ///     Igs the text using the specified fmt
        /// </summary>
        /// <param name="fmt">The fmt</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "igText")]
        public static extern void igText(byte[] fmt);
        
        /// <summary>
        ///     Igs the text colored using the specified col
        /// </summary>
        /// <param name="col">The col</param>
        /// <param name="fmt">The fmt</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "igTextColored")]
        public static extern void igTextColored(Vector4 col, byte[] fmt);
        
        /// <summary>
        ///     Igs the text disabled using the specified fmt
        /// </summary>
        /// <param name="fmt">The fmt</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "igTextDisabled")]
        public static extern void igTextDisabled(byte[] fmt);
        
        /// <summary>
        ///     Igs the text unformatted using the specified text
        /// </summary>
        /// <param name="text">The text</param>
        /// <param name="textEnd">The text end</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "igTextUnformatted")]
        public static extern void igTextUnformatted(byte[] text, byte textEnd);
        
        /// <summary>
        ///     Igs the text wrapped using the specified fmt
        /// </summary>
        /// <param name="fmt">The fmt</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "igTextWrapped")]
        public static extern void igTextWrapped(byte[] fmt);
        
        /// <summary>
        ///     Igs the tree node str using the specified label
        /// </summary>
        /// <param name="label">The label</param>
        /// <returns>The byte</returns>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "igTreeNode_Str")]
        public static extern byte igTreeNode_Str(byte[] label);
        
        /// <summary>
        ///     Igs the tree node str str using the specified str id
        /// </summary>
        /// <param name="strId">The str id</param>
        /// <param name="fmt">The fmt</param>
        /// <returns>The byte</returns>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "igTreeNode_StrStr")]
        public static extern byte igTreeNode_StrStr(byte[] strId, byte[] fmt);
        
        /// <summary>
        ///     Igs the tree node ptr using the specified ptr id
        /// </summary>
        /// <param name="ptrId">The ptr id</param>
        /// <param name="fmt">The fmt</param>
        /// <returns>The byte</returns>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "igTreeNode_Ptr")]
        public static extern byte igTreeNode_Ptr(IntPtr ptrId, byte[] fmt);
        
        /// <summary>
        ///     Igs the tree node ex str using the specified label
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="flags">The flags</param>
        /// <returns>The byte</returns>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "igTreeNodeEx_Str")]
        public static extern byte igTreeNodeEx_Str(byte[] label, ImGuiTreeNodeFlags flags);
        
        /// <summary>
        ///     Igs the tree node ex str str using the specified str id
        /// </summary>
        /// <param name="strId">The str id</param>
        /// <param name="flags">The flags</param>
        /// <param name="fmt">The fmt</param>
        /// <returns>The byte</returns>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "igTreeNodeEx_StrStr")]
        public static extern byte igTreeNodeEx_StrStr(byte[] strId, ImGuiTreeNodeFlags flags, byte[] fmt);
        
        /// <summary>
        ///     Igs the tree node ex ptr using the specified ptr id
        /// </summary>
        /// <param name="ptrId">The ptr id</param>
        /// <param name="flags">The flags</param>
        /// <param name="fmt">The fmt</param>
        /// <returns>The byte</returns>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "igTreeNodeEx_Ptr")]
        public static extern byte igTreeNodeEx_Ptr(IntPtr ptrId, ImGuiTreeNodeFlags flags, byte[] fmt);
        
        /// <summary>
        ///     Igs the tree pop
        /// </summary>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "igTreePop")]
        public static extern void igTreePop();
        
        /// <summary>
        ///     Igs the tree push str using the specified str id
        /// </summary>
        /// <param name="strId">The str id</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "igTreePush_Str")]
        public static extern void igTreePush_Str(byte[] strId);
        
        /// <summary>
        ///     Igs the tree push ptr using the specified ptr id
        /// </summary>
        /// <param name="ptrId">The ptr id</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "igTreePush_Ptr")]
        public static extern void igTreePush_Ptr(IntPtr ptrId);
        
        /// <summary>
        ///     Igs the unindent using the specified indent w
        /// </summary>
        /// <param name="indentW">The indent</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "igUnindent")]
        public static extern void igUnindent(float indentW);
        
        /// <summary>
        ///     Igs the update platform windows
        /// </summary>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "igUpdatePlatformWindows")]
        public static extern void igUpdatePlatformWindows();
        
        /// <summary>
        ///     Igs the value bool using the specified prefix
        /// </summary>
        /// <param name="prefix">The prefix</param>
        /// <param name="b">The </param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "igValue_Bool")]
        public static extern void igValue_Bool(byte* prefix, byte b);
        
        /// <summary>
        ///     Igs the value int using the specified prefix
        /// </summary>
        /// <param name="prefix">The prefix</param>
        /// <param name="v">The </param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "igValue_Int")]
        public static extern void igValue_Int(byte* prefix, int v);
        
        /// <summary>
        ///     Igs the value uint using the specified prefix
        /// </summary>
        /// <param name="prefix">The prefix</param>
        /// <param name="v">The </param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "igValue_Uint")]
        public static extern void igValue_Uint(byte* prefix, uint v);
        
        /// <summary>
        ///     Igs the value float using the specified prefix
        /// </summary>
        /// <param name="prefix">The prefix</param>
        /// <param name="v">The </param>
        /// <param name="floatFormat">The float format</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "igValue_Float")]
        public static extern void igValue_Float(byte* prefix, float v, byte* floatFormat);
        
        /// <summary>
        ///     Igs the v slider float using the specified label
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="size">The size</param>
        /// <param name="v">The </param>
        /// <param name="vMin">The min</param>
        /// <param name="vMax">The max</param>
        /// <param name="format">The format</param>
        /// <param name="flags">The flags</param>
        /// <returns>The byte</returns>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "igVSliderFloat")]
        public static extern byte igVSliderFloat(byte[] label, Vector2 size, ref float v, float vMin, float vMax, byte[] format, ImGuiSliderFlags flags);
        
        /// <summary>
        ///     Igs the v slider int using the specified label
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="size">The size</param>
        /// <param name="v">The </param>
        /// <param name="vMin">The min</param>
        /// <param name="vMax">The max</param>
        /// <param name="format">The format</param>
        /// <param name="flags">The flags</param>
        /// <returns>The byte</returns>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "igVSliderInt")]
        public static extern byte igVSliderInt(byte[] label, Vector2 size, ref int v, int vMin, int vMax, byte[] format, ImGuiSliderFlags flags);
        
        /// <summary>
        ///     Igs the v slider scalar using the specified label
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="size">The size</param>
        /// <param name="dataType">The data type</param>
        /// <param name="pData">The data</param>
        /// <param name="pMin">The min</param>
        /// <param name="pMax">The max</param>
        /// <param name="format">The format</param>
        /// <param name="flags">The flags</param>
        /// <returns>The byte</returns>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "igVSliderScalar")]
        public static extern byte igVSliderScalar(byte[] label, Vector2 size, ImGuiDataType dataType, IntPtr pData, IntPtr pMin, IntPtr pMax, byte[] format, ImGuiSliderFlags flags);
        
        /// <summary>
        ///     Ims the color destroy using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "ImColor_destroy")]
        public static extern void ImColor_destroy(ref ImColor self);
        
        /// <summary>
        ///     Ims the color hsv using the specified p out
        /// </summary>
        /// <param name="pOut">The out</param>
        /// <param name="h">The </param>
        /// <param name="s">The </param>
        /// <param name="v">The </param>
        /// <param name="a">The </param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "ImColor_HSV")]
        public static extern void ImColor_HSV(out ImColor pOut, float h, float s, float v, float a);
        
        /// <summary>
        ///     Ims the color im color nil
        /// </summary>
        /// <returns>The im color</returns>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "ImColor_ImColor_Nil")]
        public static extern ImColor ImColor_ImColor_Nil();
        
        /// <summary>
        ///     Ims the color im color float using the specified r
        /// </summary>
        /// <param name="r">The </param>
        /// <param name="g">The </param>
        /// <param name="b">The </param>
        /// <param name="a">The </param>
        /// <returns>The im color</returns>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "ImColor_ImColor_Float")]
        public static extern ImColor ImColor_ImColor_Float(float r, float g, float b, float a);
        
        /// <summary>
        ///     Ims the color im color vec 4 using the specified col
        /// </summary>
        /// <param name="col">The col</param>
        /// <returns>The im color</returns>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "ImColor_ImColor_Vec4")]
        public static extern ImColor ImColor_ImColor_Vec4(Vector4 col);
        
        /// <summary>
        ///     Ims the color im color int using the specified r
        /// </summary>
        /// <param name="r">The </param>
        /// <param name="g">The </param>
        /// <param name="b">The </param>
        /// <param name="a">The </param>
        /// <returns>The im color</returns>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "ImColor_ImColor_Int")]
        public static extern ImColor ImColor_ImColor_Int(int r, int g, int b, int a);
        
        /// <summary>
        ///     Ims the color im color u 32 using the specified rgba
        /// </summary>
        /// <param name="rgba">The rgba</param>
        /// <returns>The im color</returns>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "ImColor_ImColor_U32")]
        public static extern ImColor ImColor_ImColor_U32(uint rgba);
        
        /// <summary>
        ///     Ims the color set hsv using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        /// <param name="h">The </param>
        /// <param name="s">The </param>
        /// <param name="v">The </param>
        /// <param name="a">The </param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "ImColor_SetHSV")]
        public static extern void ImColor_SetHSV(ref ImColor self, float h, float s, float v, float a);
        
        /// <summary>
        ///     Ims the draw cmd destroy using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "ImDrawCmd_destroy")]
        public static extern void ImDrawCmd_destroy(ref ImDrawCmd self);
        
        /// <summary>
        ///     Ims the draw cmd get tex id using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        /// <returns>The int ptr</returns>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "ImDrawCmd_GetTexID")]
        public static extern IntPtr ImDrawCmd_GetTexID(ref ImDrawCmd self);
        
        /// <summary>
        ///     Ims the draw cmd im draw cmd
        /// </summary>
        /// <returns>The im draw cmd</returns>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "ImDrawCmd_ImDrawCmd")]
        public static extern IntPtr ImDrawCmd_ImDrawCmd();
        
        /// <summary>
        ///     Ims the draw data clear using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "ImDrawData_Clear")]
        public static extern void ImDrawData_Clear(ref ImDrawData self);
        
        /// <summary>
        ///     Ims the draw data de index all buffers using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "ImDrawData_DeIndexAllBuffers")]
        public static extern void ImDrawData_DeIndexAllBuffers(ref ImDrawData self);
        
        /// <summary>
        ///     Ims the draw data destroy using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "ImDrawData_destroy")]
        public static extern void ImDrawData_destroy(ref ImDrawData self);
        
        /// <summary>
        ///     Ims the draw data im draw data
        /// </summary>
        /// <returns>The im draw data</returns>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "ImDrawData_ImDrawData")]
        public static extern ref ImDrawData ImDrawData_ImDrawData();
        
        /// <summary>
        ///     Ims the draw data scale clip rects using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        /// <param name="fbScale">The fb scale</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "ImDrawData_ScaleClipRects")]
        public static extern void ImDrawData_ScaleClipRects(ref ImDrawData self, Vector2 fbScale);
        
        /// <summary>
        ///     Ims the draw list calc circle auto segment count using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        /// <param name="radius">The radius</param>
        /// <returns>The int</returns>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "ImDrawList__CalcCircleAutoSegmentCount")]
        public static extern int ImDrawList__CalcCircleAutoSegmentCount(IntPtr self, float radius);
        
        /// <summary>
        ///     Ims the draw list clear free memory using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "ImDrawList__ClearFreeMemory")]
        public static extern void ImDrawList__ClearFreeMemory(IntPtr self);
        
        /// <summary>
        ///     Ims the draw list on changed clip rect using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "ImDrawList__OnChangedClipRect")]
        public static extern void ImDrawList__OnChangedClipRect(IntPtr self);
        
        /// <summary>
        ///     Ims the draw list on changed texture id using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "ImDrawList__OnChangedTextureID")]
        public static extern void ImDrawList__OnChangedTextureID(IntPtr self);
        
        /// <summary>
        ///     Ims the draw list on changed vtx offset using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "ImDrawList__OnChangedVtxOffset")]
        public static extern void ImDrawList__OnChangedVtxOffset(IntPtr self);
        
        /// <summary>
        ///     Ims the draw list path arc to fast ex using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        /// <param name="center">The center</param>
        /// <param name="radius">The radius</param>
        /// <param name="aMinSample">The min sample</param>
        /// <param name="aMaxSample">The max sample</param>
        /// <param name="aStep">The step</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "ImDrawList__PathArcToFastEx")]
        public static extern void ImDrawList__PathArcToFastEx(IntPtr self, Vector2 center, float radius, int aMinSample, int aMaxSample, int aStep);
        
        /// <summary>
        ///     Ims the draw list path arc to n using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        /// <param name="center">The center</param>
        /// <param name="radius">The radius</param>
        /// <param name="aMin">The min</param>
        /// <param name="aMax">The max</param>
        /// <param name="numSegments">The num segments</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "ImDrawList__PathArcToN")]
        public static extern void ImDrawList__PathArcToN(IntPtr self, Vector2 center, float radius, float aMin, float aMax, int numSegments);
        
        /// <summary>
        ///     Ims the draw list pop unused draw cmd using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "ImDrawList__PopUnusedDrawCmd")]
        public static extern void ImDrawList__PopUnusedDrawCmd(IntPtr self);
        
        /// <summary>
        ///     Ims the draw list reset for new frame using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "ImDrawList__ResetForNewFrame")]
        public static extern void ImDrawList__ResetForNewFrame(IntPtr self);
        
        /// <summary>
        ///     Ims the draw list try merge draw cmds using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "ImDrawList__TryMergeDrawCmds")]
        public static extern void ImDrawList__TryMergeDrawCmds(IntPtr self);
        
        /// <summary>
        ///     Ims the draw list add bezier cubic using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        /// <param name="p1">The </param>
        /// <param name="p2">The </param>
        /// <param name="p3">The </param>
        /// <param name="p4">The </param>
        /// <param name="col">The col</param>
        /// <param name="thickness">The thickness</param>
        /// <param name="numSegments">The num segments</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "ImDrawList_AddBezierCubic")]
        public static extern void ImDrawList_AddBezierCubic(IntPtr self, Vector2 p1, Vector2 p2, Vector2 p3, Vector2 p4, uint col, float thickness, int numSegments);
        
        /// <summary>
        ///     Ims the draw list add bezier quadratic using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        /// <param name="p1">The </param>
        /// <param name="p2">The </param>
        /// <param name="p3">The </param>
        /// <param name="col">The col</param>
        /// <param name="thickness">The thickness</param>
        /// <param name="numSegments">The num segments</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "ImDrawList_AddBezierQuadratic")]
        public static extern void ImDrawList_AddBezierQuadratic(IntPtr self, Vector2 p1, Vector2 p2, Vector2 p3, uint col, float thickness, int numSegments);
        
        /// <summary>
        ///     Ims the draw list add callback using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        /// <param name="callback">The callback</param>
        /// <param name="callbackData">The callback data</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "ImDrawList_AddCallback")]
        public static extern void ImDrawList_AddCallback(IntPtr self, IntPtr callback, IntPtr callbackData);
        
        /// <summary>
        ///     Ims the draw list add circle using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        /// <param name="center">The center</param>
        /// <param name="radius">The radius</param>
        /// <param name="col">The col</param>
        /// <param name="numSegments">The num segments</param>
        /// <param name="thickness">The thickness</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "ImDrawList_AddCircle")]
        public static extern void ImDrawList_AddCircle(IntPtr self, Vector2 center, float radius, uint col, int numSegments, float thickness);
        
        /// <summary>
        ///     Ims the draw list add circle filled using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        /// <param name="center">The center</param>
        /// <param name="radius">The radius</param>
        /// <param name="col">The col</param>
        /// <param name="numSegments">The num segments</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "ImDrawList_AddCircleFilled")]
        public static extern void ImDrawList_AddCircleFilled(IntPtr self, Vector2 center, float radius, uint col, int numSegments);
        
        /// <summary>
        ///     Ims the draw list add convex poly filled using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        /// <param name="points">The points</param>
        /// <param name="numPoints">The num points</param>
        /// <param name="col">The col</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "ImDrawList_AddConvexPolyFilled")]
        public static extern void ImDrawList_AddConvexPolyFilled(IntPtr self, Vector2* points, int numPoints, uint col);
        
        /// <summary>
        ///     Ims the draw list add draw cmd using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "ImDrawList_AddDrawCmd")]
        public static extern void ImDrawList_AddDrawCmd(IntPtr self);
        
        /// <summary>
        ///     Ims the draw list add image using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        /// <param name="userTextureId">The user texture id</param>
        /// <param name="pMin">The min</param>
        /// <param name="pMax">The max</param>
        /// <param name="uvMin">The uv min</param>
        /// <param name="uvMax">The uv max</param>
        /// <param name="col">The col</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "ImDrawList_AddImage")]
        public static extern void ImDrawList_AddImage(IntPtr self, IntPtr userTextureId, Vector2 pMin, Vector2 pMax, Vector2 uvMin, Vector2 uvMax, uint col);
        
        /// <summary>
        ///     Ims the draw list add image quad using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        /// <param name="userTextureId">The user texture id</param>
        /// <param name="p1">The </param>
        /// <param name="p2">The </param>
        /// <param name="p3">The </param>
        /// <param name="p4">The </param>
        /// <param name="uv1">The uv</param>
        /// <param name="uv2">The uv</param>
        /// <param name="uv3">The uv</param>
        /// <param name="uv4">The uv</param>
        /// <param name="col">The col</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "ImDrawList_AddImageQuad")]
        public static extern void ImDrawList_AddImageQuad(IntPtr self, IntPtr userTextureId, Vector2 p1, Vector2 p2, Vector2 p3, Vector2 p4, Vector2 uv1, Vector2 uv2, Vector2 uv3, Vector2 uv4, uint col);
        
        /// <summary>
        ///     Ims the draw list add image rounded using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        /// <param name="userTextureId">The user texture id</param>
        /// <param name="pMin">The min</param>
        /// <param name="pMax">The max</param>
        /// <param name="uvMin">The uv min</param>
        /// <param name="uvMax">The uv max</param>
        /// <param name="col">The col</param>
        /// <param name="rounding">The rounding</param>
        /// <param name="flags">The flags</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "ImDrawList_AddImageRounded")]
        public static extern void ImDrawList_AddImageRounded(IntPtr self, IntPtr userTextureId, Vector2 pMin, Vector2 pMax, Vector2 uvMin, Vector2 uvMax, uint col, float rounding, ImDrawFlags flags);
        
        /// <summary>
        ///     Ims the draw list add line using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        /// <param name="p1">The </param>
        /// <param name="p2">The </param>
        /// <param name="col">The col</param>
        /// <param name="thickness">The thickness</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "ImDrawList_AddLine")]
        public static extern void ImDrawList_AddLine(IntPtr self, Vector2 p1, Vector2 p2, uint col, float thickness);
        
        /// <summary>
        ///     Ims the draw list add ngon using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        /// <param name="center">The center</param>
        /// <param name="radius">The radius</param>
        /// <param name="col">The col</param>
        /// <param name="numSegments">The num segments</param>
        /// <param name="thickness">The thickness</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "ImDrawList_AddNgon")]
        public static extern void ImDrawList_AddNgon(IntPtr self, Vector2 center, float radius, uint col, int numSegments, float thickness);
        
        /// <summary>
        ///     Ims the draw list add ngon filled using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        /// <param name="center">The center</param>
        /// <param name="radius">The radius</param>
        /// <param name="col">The col</param>
        /// <param name="numSegments">The num segments</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "ImDrawList_AddNgonFilled")]
        public static extern void ImDrawList_AddNgonFilled(IntPtr self, Vector2 center, float radius, uint col, int numSegments);
        
        /// <summary>
        ///     Ims the draw list add polyline using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        /// <param name="points">The points</param>
        /// <param name="numPoints">The num points</param>
        /// <param name="col">The col</param>
        /// <param name="flags">The flags</param>
        /// <param name="thickness">The thickness</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "ImDrawList_AddPolyline")]
        public static extern void ImDrawList_AddPolyline(IntPtr self, Vector2* points, int numPoints, uint col, ImDrawFlags flags, float thickness);
        
        /// <summary>
        ///     Ims the draw list add quad using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        /// <param name="p1">The </param>
        /// <param name="p2">The </param>
        /// <param name="p3">The </param>
        /// <param name="p4">The </param>
        /// <param name="col">The col</param>
        /// <param name="thickness">The thickness</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "ImDrawList_AddQuad")]
        public static extern void ImDrawList_AddQuad(IntPtr self, Vector2 p1, Vector2 p2, Vector2 p3, Vector2 p4, uint col, float thickness);
        
        /// <summary>
        ///     Ims the draw list add quad filled using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        /// <param name="p1">The </param>
        /// <param name="p2">The </param>
        /// <param name="p3">The </param>
        /// <param name="p4">The </param>
        /// <param name="col">The col</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "ImDrawList_AddQuadFilled")]
        public static extern void ImDrawList_AddQuadFilled(IntPtr self, Vector2 p1, Vector2 p2, Vector2 p3, Vector2 p4, uint col);
        
        /// <summary>
        ///     Ims the draw list add rect using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        /// <param name="pMin">The min</param>
        /// <param name="pMax">The max</param>
        /// <param name="col">The col</param>
        /// <param name="rounding">The rounding</param>
        /// <param name="flags">The flags</param>
        /// <param name="thickness">The thickness</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "ImDrawList_AddRect")]
        public static extern void ImDrawList_AddRect(IntPtr self, Vector2 pMin, Vector2 pMax, uint col, float rounding, ImDrawFlags flags, float thickness);
        
        /// <summary>
        ///     Ims the draw list add rect filled using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        /// <param name="pMin">The min</param>
        /// <param name="pMax">The max</param>
        /// <param name="col">The col</param>
        /// <param name="rounding">The rounding</param>
        /// <param name="flags">The flags</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "ImDrawList_AddRectFilled")]
        public static extern void ImDrawList_AddRectFilled(IntPtr self, Vector2 pMin, Vector2 pMax, uint col, float rounding, ImDrawFlags flags);
        
        /// <summary>
        ///     Ims the draw list add rect filled multi color using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        /// <param name="pMin">The min</param>
        /// <param name="pMax">The max</param>
        /// <param name="colUprLeft">The col upr left</param>
        /// <param name="colUprRight">The col upr right</param>
        /// <param name="colBotRight">The col bot right</param>
        /// <param name="colBotLeft">The col bot left</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "ImDrawList_AddRectFilledMultiColor")]
        public static extern void ImDrawList_AddRectFilledMultiColor(IntPtr self, Vector2 pMin, Vector2 pMax, uint colUprLeft, uint colUprRight, uint colBotRight, uint colBotLeft);
        
        /// <summary>
        ///     Ims the draw list add text vec 2 using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        /// <param name="pos">The pos</param>
        /// <param name="col">The col</param>
        /// <param name="textBegin">The text begin</param>
        /// <param name="textEnd">The text end</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "ImDrawList_AddText_Vec2")]
        public static extern void ImDrawList_AddText_Vec2(IntPtr self, Vector2 pos, uint col, byte* textBegin, byte[] textEnd);
        
        /// <summary>
        ///     Ims the draw list add text font ptr using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        /// <param name="font">The font</param>
        /// <param name="fontSize">The font size</param>
        /// <param name="pos">The pos</param>
        /// <param name="col">The col</param>
        /// <param name="textBegin">The text begin</param>
        /// <param name="textEnd">The text end</param>
        /// <param name="wrapWidth">The wrap width</param>
        /// <param name="cpuFineClipRect">The cpu fine clip rect</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "ImDrawList_AddText_FontPtr")]
        public static extern void ImDrawList_AddText_FontPtr(IntPtr self, IntPtr font, float fontSize, Vector2 pos, uint col, byte* textBegin, byte[] textEnd, float wrapWidth, Vector4 cpuFineClipRect);
        
        /// <summary>
        ///     Ims the draw list add triangle using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        /// <param name="p1">The </param>
        /// <param name="p2">The </param>
        /// <param name="p3">The </param>
        /// <param name="col">The col</param>
        /// <param name="thickness">The thickness</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "ImDrawList_AddTriangle")]
        public static extern void ImDrawList_AddTriangle(IntPtr self, Vector2 p1, Vector2 p2, Vector2 p3, uint col, float thickness);
        
        /// <summary>
        ///     Ims the draw list add triangle filled using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        /// <param name="p1">The </param>
        /// <param name="p2">The </param>
        /// <param name="p3">The </param>
        /// <param name="col">The col</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "ImDrawList_AddTriangleFilled")]
        public static extern void ImDrawList_AddTriangleFilled(IntPtr self, Vector2 p1, Vector2 p2, Vector2 p3, uint col);
        
        /// <summary>
        ///     Ims the draw list channels merge using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "ImDrawList_ChannelsMerge")]
        public static extern void ImDrawList_ChannelsMerge(IntPtr self);
        
        /// <summary>
        ///     Ims the draw list channels set current using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        /// <param name="n">The </param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "ImDrawList_ChannelsSetCurrent")]
        public static extern void ImDrawList_ChannelsSetCurrent(IntPtr self, int n);
        
        /// <summary>
        ///     Ims the draw list channels split using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        /// <param name="count">The count</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "ImDrawList_ChannelsSplit")]
        public static extern void ImDrawList_ChannelsSplit(IntPtr self, int count);
        
        /// <summary>
        ///     Ims the draw list clone output using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        /// <returns>The im draw list</returns>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "ImDrawList_CloneOutput")]
        public static extern IntPtr ImDrawList_CloneOutput(IntPtr self);
        
        /// <summary>
        ///     Ims the draw list destroy using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "ImDrawList_destroy")]
        public static extern void ImDrawList_destroy(IntPtr self);
        
        /// <summary>
        ///     Ims the draw list get clip rect max using the specified p out
        /// </summary>
        /// <param name="pOut">The out</param>
        /// <param name="self">The self</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "ImDrawList_GetClipRectMax")]
        public static extern void ImDrawList_GetClipRectMax(out Vector2 pOut, IntPtr self);
        
        /// <summary>
        ///     Ims the draw list get clip rect min using the specified p out
        /// </summary>
        /// <param name="pOut">The out</param>
        /// <param name="self">The self</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "ImDrawList_GetClipRectMin")]
        public static extern void ImDrawList_GetClipRectMin(out Vector2 pOut, IntPtr self);
        
        /// <summary>
        ///     Ims the draw list im draw list using the specified shared data
        /// </summary>
        /// <param name="sharedData">The shared data</param>
        /// <returns>The im draw list</returns>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "ImDrawList_ImDrawList")]
        public static extern IntPtr ImDrawList_ImDrawList(IntPtr sharedData);
        
        /// <summary>
        ///     Ims the draw list path arc to using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        /// <param name="center">The center</param>
        /// <param name="radius">The radius</param>
        /// <param name="aMin">The min</param>
        /// <param name="aMax">The max</param>
        /// <param name="numSegments">The num segments</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "ImDrawList_PathArcTo")]
        public static extern void ImDrawList_PathArcTo(IntPtr self, Vector2 center, float radius, float aMin, float aMax, int numSegments);
        
        /// <summary>
        ///     Ims the draw list path arc to fast using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        /// <param name="center">The center</param>
        /// <param name="radius">The radius</param>
        /// <param name="aMinOf12">The min of 12</param>
        /// <param name="aMaxOf12">The max of 12</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "ImDrawList_PathArcToFast")]
        public static extern void ImDrawList_PathArcToFast(IntPtr self, Vector2 center, float radius, int aMinOf12, int aMaxOf12);
        
        /// <summary>
        ///     Ims the draw list path bezier cubic curve to using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        /// <param name="p2">The </param>
        /// <param name="p3">The </param>
        /// <param name="p4">The </param>
        /// <param name="numSegments">The num segments</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "ImDrawList_PathBezierCubicCurveTo")]
        public static extern void ImDrawList_PathBezierCubicCurveTo(IntPtr self, Vector2 p2, Vector2 p3, Vector2 p4, int numSegments);
        
        /// <summary>
        ///     Ims the draw list path bezier quadratic curve to using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        /// <param name="p2">The </param>
        /// <param name="p3">The </param>
        /// <param name="numSegments">The num segments</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "ImDrawList_PathBezierQuadraticCurveTo")]
        public static extern void ImDrawList_PathBezierQuadraticCurveTo(IntPtr self, Vector2 p2, Vector2 p3, int numSegments);
        
        /// <summary>
        ///     Ims the draw list path clear using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "ImDrawList_PathClear")]
        public static extern void ImDrawList_PathClear(IntPtr self);
        
        /// <summary>
        ///     Ims the draw list path fill convex using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        /// <param name="col">The col</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "ImDrawList_PathFillConvex")]
        public static extern void ImDrawList_PathFillConvex(IntPtr self, uint col);
        
        /// <summary>
        ///     Ims the draw list path line to using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        /// <param name="pos">The pos</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "ImDrawList_PathLineTo")]
        public static extern void ImDrawList_PathLineTo(IntPtr self, Vector2 pos);
        
        /// <summary>
        ///     Ims the draw list path line to merge duplicate using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        /// <param name="pos">The pos</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "ImDrawList_PathLineToMergeDuplicate")]
        public static extern void ImDrawList_PathLineToMergeDuplicate(IntPtr self, Vector2 pos);
        
        /// <summary>
        ///     Ims the draw list path rect using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        /// <param name="rectMin">The rect min</param>
        /// <param name="rectMax">The rect max</param>
        /// <param name="rounding">The rounding</param>
        /// <param name="flags">The flags</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "ImDrawList_PathRect")]
        public static extern void ImDrawList_PathRect(IntPtr self, Vector2 rectMin, Vector2 rectMax, float rounding, ImDrawFlags flags);
        
        /// <summary>
        ///     Ims the draw list path stroke using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        /// <param name="col">The col</param>
        /// <param name="flags">The flags</param>
        /// <param name="thickness">The thickness</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "ImDrawList_PathStroke")]
        public static extern void ImDrawList_PathStroke(IntPtr self, uint col, ImDrawFlags flags, float thickness);
        
        /// <summary>
        ///     Ims the draw list pop clip rect using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "ImDrawList_PopClipRect")]
        public static extern void ImDrawList_PopClipRect(IntPtr self);
        
        /// <summary>
        ///     Ims the draw list pop texture id using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "ImDrawList_PopTextureID")]
        public static extern void ImDrawList_PopTextureID(IntPtr self);
        
        /// <summary>
        ///     Ims the draw list prim quad uv using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        /// <param name="a">The </param>
        /// <param name="b">The </param>
        /// <param name="c">The </param>
        /// <param name="d">The </param>
        /// <param name="uvA">The uv</param>
        /// <param name="uvB">The uv</param>
        /// <param name="uvC">The uv</param>
        /// <param name="uvD">The uv</param>
        /// <param name="col">The col</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "ImDrawList_PrimQuadUV")]
        public static extern void ImDrawList_PrimQuadUV(IntPtr self, Vector2 a, Vector2 b, Vector2 c, Vector2 d, Vector2 uvA, Vector2 uvB, Vector2 uvC, Vector2 uvD, uint col);
        
        /// <summary>
        ///     Ims the draw list prim rect using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        /// <param name="a">The </param>
        /// <param name="b">The </param>
        /// <param name="col">The col</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "ImDrawList_PrimRect")]
        public static extern void ImDrawList_PrimRect(IntPtr self, Vector2 a, Vector2 b, uint col);
        
        /// <summary>
        ///     Ims the draw list prim rect uv using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        /// <param name="a">The </param>
        /// <param name="b">The </param>
        /// <param name="uvA">The uv</param>
        /// <param name="uvB">The uv</param>
        /// <param name="col">The col</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "ImDrawList_PrimRectUV")]
        public static extern void ImDrawList_PrimRectUV(IntPtr self, Vector2 a, Vector2 b, Vector2 uvA, Vector2 uvB, uint col);
        
        /// <summary>
        ///     Ims the draw list prim reserve using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        /// <param name="idxCount">The idx count</param>
        /// <param name="vtxCount">The vtx count</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "ImDrawList_PrimReserve")]
        public static extern void ImDrawList_PrimReserve(IntPtr self, int idxCount, int vtxCount);
        
        /// <summary>
        ///     Ims the draw list prim unreserve using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        /// <param name="idxCount">The idx count</param>
        /// <param name="vtxCount">The vtx count</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "ImDrawList_PrimUnreserve")]
        public static extern void ImDrawList_PrimUnreserve(IntPtr self, int idxCount, int vtxCount);
        
        /// <summary>
        ///     Ims the draw list prim vtx using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        /// <param name="pos">The pos</param>
        /// <param name="uv">The uv</param>
        /// <param name="col">The col</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "ImDrawList_PrimVtx")]
        public static extern void ImDrawList_PrimVtx(IntPtr self, Vector2 pos, Vector2 uv, uint col);
        
        /// <summary>
        ///     Ims the draw list prim write idx using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        /// <param name="idx">The idx</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "ImDrawList_PrimVtx")]
        public static extern void ImDrawList_PrimWriteIdx(IntPtr self, ushort idx);
        
        /// <summary>
        ///     Ims the draw list prim write vtx using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        /// <param name="pos">The pos</param>
        /// <param name="uv">The uv</param>
        /// <param name="col">The col</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "ImDrawList_PrimWriteVtx")]
        public static extern void ImDrawList_PrimWriteVtx(IntPtr self, Vector2 pos, Vector2 uv, uint col);
        
        /// <summary>
        ///     Ims the draw list push clip rect using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        /// <param name="clipRectMin">The clip rect min</param>
        /// <param name="clipRectMax">The clip rect max</param>
        /// <param name="intersectWithCurrentClipRect">The intersect with current clip rect</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "ImDrawList_PushClipRect")]
        public static extern void ImDrawList_PushClipRect(IntPtr self, Vector2 clipRectMin, Vector2 clipRectMax, byte intersectWithCurrentClipRect);
        
        /// <summary>
        ///     Ims the draw list push clip rect full screen using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "ImDrawList_PushClipRectFullScreen")]
        public static extern void ImDrawList_PushClipRectFullScreen(IntPtr self);
        
        /// <summary>
        ///     Ims the draw list push texture id using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        /// <param name="textureId">The texture id</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "ImDrawList_PushTextureID")]
        public static extern void ImDrawList_PushTextureID(IntPtr self, IntPtr textureId);
        
        /// <summary>
        ///     Ims the draw list splitter clear using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "ImDrawListSplitter_Clear")]
        public static extern void ImDrawListSplitter_Clear(ImDrawListSplitter* self);
        
        /// <summary>
        ///     Ims the draw list splitter clear free memory using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "ImDrawListSplitter_ClearFreeMemory")]
        public static extern void ImDrawListSplitter_ClearFreeMemory(ImDrawListSplitter* self);
        
        /// <summary>
        ///     Ims the draw list splitter destroy using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "ImDrawListSplitter_destroy")]
        public static extern void ImDrawListSplitter_destroy(ImDrawListSplitter* self);
        
        /// <summary>
        ///     Ims the draw list splitter im draw list splitter
        /// </summary>
        /// <returns>The im draw list splitter</returns>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "ImDrawListSplitter_ImDrawListSplitter")]
        public static extern ImDrawListSplitter* ImDrawListSplitter_ImDrawListSplitter();
        
        /// <summary>
        ///     Ims the draw list splitter merge using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        /// <param name="drawList">The draw list</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "ImDrawListSplitter_Merge")]
        public static extern void ImDrawListSplitter_Merge(ImDrawListSplitter* self, IntPtr drawList);
        
        /// <summary>
        ///     Ims the draw list splitter set current channel using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        /// <param name="drawList">The draw list</param>
        /// <param name="channelIdx">The channel idx</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "ImDrawListSplitter_SetCurrentChannel")]
        public static extern void ImDrawListSplitter_SetCurrentChannel(ImDrawListSplitter* self, IntPtr drawList, int channelIdx);
        
        /// <summary>
        ///     Ims the draw list splitter split using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        /// <param name="drawList">The draw list</param>
        /// <param name="count">The count</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "ImDrawListSplitter_Split")]
        public static extern void ImDrawListSplitter_Split(ImDrawListSplitter* self, IntPtr drawList, int count);
        
        /// <summary>
        ///     Ims the font add glyph using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        /// <param name="srcCfg">The src cfg</param>
        /// <param name="c">The </param>
        /// <param name="x0">The </param>
        /// <param name="y0">The </param>
        /// <param name="x1">The </param>
        /// <param name="y1">The </param>
        /// <param name="u0">The </param>
        /// <param name="v0">The </param>
        /// <param name="u1">The </param>
        /// <param name="v1">The </param>
        /// <param name="advanceX">The advance</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "ImFont_AddGlyph")]
        public static extern void ImFont_AddGlyph(IntPtr self, IntPtr srcCfg, ushort c, float x0, float y0, float x1, float y1, float u0, float v0, float u1, float v1, float advanceX);
        
        /// <summary>
        ///     Ims the font add remap char using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        /// <param name="dst">The dst</param>
        /// <param name="src">The src</param>
        /// <param name="overwriteDst">The overwrite dst</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "ImFont_AddRemapChar")]
        public static extern void ImFont_AddRemapChar(IntPtr self, ushort dst, ushort src, byte overwriteDst);
        
        /// <summary>
        ///     Ims the font build lookup table using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "ImFont_BuildLookupTable")]
        public static extern void ImFont_BuildLookupTable(IntPtr self);
        
        /// <summary>
        ///     Ims the font calc text size a using the specified p out
        /// </summary>
        /// <param name="pOut">The out</param>
        /// <param name="self">The self</param>
        /// <param name="size">The size</param>
        /// <param name="maxWidth">The max width</param>
        /// <param name="wrapWidth">The wrap width</param>
        /// <param name="textBegin">The text begin</param>
        /// <param name="textEnd">The text end</param>
        /// <param name="remaining">The remaining</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "ImFont_CalcTextSizeA")]
        public static extern void ImFont_CalcTextSizeA(out Vector2 pOut, IntPtr self, float size, float maxWidth, float wrapWidth, byte* textBegin, byte[] textEnd, byte** remaining);
        
        /// <summary>
        ///     Ims the font calc word wrap position a using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        /// <param name="scale">The scale</param>
        /// <param name="text">The text</param>
        /// <param name="textEnd">The text end</param>
        /// <param name="wrapWidth">The wrap width</param>
        /// <returns>The byte</returns>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "ImFont_CalcWordWrapPositionA")]
        public static extern byte* ImFont_CalcWordWrapPositionA(IntPtr self, float scale, byte[] text, byte[] textEnd, float wrapWidth);
        
        /// <summary>
        ///     Ims the font clear output data using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "ImFont_ClearOutputData")]
        public static extern void ImFont_ClearOutputData(IntPtr self);
        
        /// <summary>
        ///     Ims the font destroy using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "ImFont_destroy")]
        public static extern void ImFont_destroy(IntPtr self);
        
        /// <summary>
        ///     Ims the font find glyph using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        /// <param name="c">The </param>
        /// <returns>The im font glyph</returns>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "ImFont_FindGlyph")]
        public static extern ImFontGlyph ImFont_FindGlyph(IntPtr self, ushort c);
        
        /// <summary>
        ///     Ims the font find glyph no fallback using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        /// <param name="c">The </param>
        /// <returns>The im font glyph</returns>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "ImFont_FindGlyphNoFallback")]
        public static extern ImFontGlyph ImFont_FindGlyphNoFallback(IntPtr self, ushort c);
        
        /// <summary>
        ///     Ims the font get char advance using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        /// <param name="c">The </param>
        /// <returns>The float</returns>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "ImFont_GetCharAdvance")]
        public static extern float ImFont_GetCharAdvance(IntPtr self, ushort c);
        
        /// <summary>
        ///     Ims the font get debug name using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        /// <returns>The byte</returns>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "ImFont_GetDebugName")]
        public static extern byte* ImFont_GetDebugName(IntPtr self);
        
        /// <summary>
        ///     Ims the font grow index using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        /// <param name="newSize">The new size</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "ImFont_GrowIndex")]
        public static extern void ImFont_GrowIndex(IntPtr self, int newSize);
        
        /// <summary>
        ///     Ims the font im font
        /// </summary>
        /// <returns>The im font</returns>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "ImFont_ImFont")]
        public static extern IntPtr ImFont_ImFont();
        
        /// <summary>
        ///     Ims the font is glyph range unused using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        /// <param name="cBegin">The begin</param>
        /// <param name="cLast">The last</param>
        /// <returns>The byte</returns>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "ImFont_IsGlyphRangeUnused")]
        public static extern byte ImFont_IsGlyphRangeUnused(IntPtr self, uint cBegin, uint cLast);
        
        /// <summary>
        ///     Ims the font is loaded using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        /// <returns>The byte</returns>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "ImFont_IsLoaded")]
        public static extern byte ImFont_IsLoaded(IntPtr self);
        
        /// <summary>
        ///     Ims the font render char using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        /// <param name="drawList">The draw list</param>
        /// <param name="size">The size</param>
        /// <param name="pos">The pos</param>
        /// <param name="col">The col</param>
        /// <param name="c">The </param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "ImFont_RenderChar")]
        public static extern void ImFont_RenderChar(IntPtr self, IntPtr drawList, float size, Vector2 pos, uint col, ushort c);
        
        /// <summary>
        ///     Ims the font render text using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        /// <param name="drawList">The draw list</param>
        /// <param name="size">The size</param>
        /// <param name="pos">The pos</param>
        /// <param name="col">The col</param>
        /// <param name="clipRect">The clip rect</param>
        /// <param name="textBegin">The text begin</param>
        /// <param name="textEnd">The text end</param>
        /// <param name="wrapWidth">The wrap width</param>
        /// <param name="cpuFineClip">The cpu fine clip</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "ImFont_RenderText")]
        public static extern void ImFont_RenderText(IntPtr self, IntPtr drawList, float size, Vector2 pos, uint col, Vector4 clipRect, byte* textBegin, byte[] textEnd, float wrapWidth, byte cpuFineClip);
        
        /// <summary>
        ///     Ims the font set glyph visible using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        /// <param name="c">The </param>
        /// <param name="visible">The visible</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "ImFont_SetGlyphVisible")]
        public static extern void ImFont_SetGlyphVisible(IntPtr self, ushort c, byte visible);
        
        /// <summary>
        ///     Ims the font atlas add custom rect font glyph using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        /// <param name="font">The font</param>
        /// <param name="id">The id</param>
        /// <param name="width">The width</param>
        /// <param name="height">The height</param>
        /// <param name="advanceX">The advance</param>
        /// <param name="offset">The offset</param>
        /// <returns>The int</returns>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "ImFontAtlas_AddCustomRectFontGlyph")]
        public static extern int ImFontAtlas_AddCustomRectFontGlyph(IntPtr self, IntPtr font, ushort id, int width, int height, float advanceX, Vector2 offset);
        
        /// <summary>
        ///     Ims the font atlas add custom rect regular using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        /// <param name="width">The width</param>
        /// <param name="height">The height</param>
        /// <returns>The int</returns>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "ImFontAtlas_AddCustomRectRegular")]
        public static extern int ImFontAtlas_AddCustomRectRegular(IntPtr self, int width, int height);
        
        /// <summary>
        ///     Ims the font atlas add font using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        /// <param name="fontCfg">The font cfg</param>
        /// <returns>The im font</returns>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "ImFontAtlas_AddFont")]
        public static extern IntPtr ImFontAtlas_AddFont(IntPtr self, IntPtr fontCfg);
        
        /// <summary>
        ///     Ims the font atlas add font default using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        /// <param name="fontCfg">The font cfg</param>
        /// <returns>The im font</returns>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "ImFontAtlas_AddFontDefault")]
        public static extern IntPtr ImFontAtlas_AddFontDefault(IntPtr self, IntPtr fontCfg);
        
        /// <summary>
        ///     Ims the font atlas add font from file ttf using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        /// <param name="filename">The filename</param>
        /// <param name="sizePixels">The size pixels</param>
        /// <param name="fontCfg">The font cfg</param>
        /// <param name="glyphRanges">The glyph ranges</param>
        /// <returns>The im font</returns>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "ImFontAtlas_AddFontFromFileTTF")]
        public static extern IntPtr ImFontAtlas_AddFontFromFileTTF(IntPtr self, byte* filename, float sizePixels, IntPtr fontCfg, ushort* glyphRanges);
        
        /// <summary>
        ///     Ims the font atlas add font from memory compressed base 85 ttf using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        /// <param name="compressedFontDataBase85">The compressed font data base85</param>
        /// <param name="sizePixels">The size pixels</param>
        /// <param name="fontCfg">The font cfg</param>
        /// <param name="glyphRanges">The glyph ranges</param>
        /// <returns>The im font</returns>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "ImFontAtlas_AddFontFromMemoryCompressedBase85TTF")]
        public static extern IntPtr ImFontAtlas_AddFontFromMemoryCompressedBase85TTF(IntPtr self, byte* compressedFontDataBase85, float sizePixels, IntPtr fontCfg, ushort* glyphRanges);
        
        /// <summary>
        ///     Ims the font atlas add font from memory compressed ttf using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        /// <param name="compressedFontData">The compressed font data</param>
        /// <param name="compressedFontSize">The compressed font size</param>
        /// <param name="sizePixels">The size pixels</param>
        /// <param name="fontCfg">The font cfg</param>
        /// <param name="glyphRanges">The glyph ranges</param>
        /// <returns>The im font</returns>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "ImFontAtlas_AddFontFromMemoryCompressedTTF")]
        public static extern IntPtr ImFontAtlas_AddFontFromMemoryCompressedTTF(IntPtr self, IntPtr compressedFontData, int compressedFontSize, float sizePixels, IntPtr fontCfg, ushort* glyphRanges);
        
        /// <summary>
        ///     Ims the font atlas add font from memory ttf using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        /// <param name="fontData">The font data</param>
        /// <param name="fontSize">The font size</param>
        /// <param name="sizePixels">The size pixels</param>
        /// <param name="fontCfg">The font cfg</param>
        /// <param name="glyphRanges">The glyph ranges</param>
        /// <returns>The im font</returns>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "ImFontAtlas_AddFontFromMemoryTTF")]
        public static extern IntPtr ImFontAtlas_AddFontFromMemoryTTF(IntPtr self, IntPtr fontData, int fontSize, float sizePixels, IntPtr fontCfg, ushort* glyphRanges);
        
        /// <summary>
        ///     Ims the font atlas build using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        /// <returns>The byte</returns>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "ImFontAtlas_Build")]
        public static extern byte ImFontAtlas_Build(IntPtr self);
        
        /// <summary>
        ///     Ims the font atlas calc custom rect uv using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        /// <param name="rect">The rect</param>
        /// <param name="outUvMin">The out uv min</param>
        /// <param name="outUvMax">The out uv max</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "ImFontAtlas_CalcCustomRectUV")]
        public static extern void ImFontAtlas_CalcCustomRectUV(IntPtr self, ImFontAtlasCustomRect rect, Vector2* outUvMin, Vector2* outUvMax);
        
        /// <summary>
        ///     Ims the font atlas clear using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "ImFontAtlas_Clear")]
        public static extern void ImFontAtlas_Clear(IntPtr self);
        
        /// <summary>
        ///     Ims the font atlas clear fonts using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "ImFontAtlas_ClearFonts")]
        public static extern void ImFontAtlas_ClearFonts(IntPtr self);
        
        /// <summary>
        ///     Ims the font atlas clear input data using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "ImFontAtlas_ClearInputData")]
        public static extern void ImFontAtlas_ClearInputData(IntPtr self);
        
        /// <summary>
        ///     Ims the font atlas clear tex data using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "ImFontAtlas_ClearTexData")]
        public static extern void ImFontAtlas_ClearTexData(IntPtr self);
        
        /// <summary>
        ///     Ims the font atlas destroy using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "ImFontAtlas_destroy")]
        public static extern void ImFontAtlas_destroy(IntPtr self);
        
        /// <summary>
        ///     Ims the font atlas get custom rect by index using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        /// <param name="index">The index</param>
        /// <returns>The im font atlas custom rect</returns>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "ImFontAtlas_GetCustomRectByIndex")]
        public static extern ImFontAtlasCustomRect ImFontAtlas_GetCustomRectByIndex(IntPtr self, int index);
        
        /// <summary>
        ///     Ims the font atlas get glyph ranges chinese full using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        /// <returns>The ushort</returns>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "ImFontAtlas_GetGlyphRangesChineseFull")]
        public static extern ushort* ImFontAtlas_GetGlyphRangesChineseFull(IntPtr self);
        
        /// <summary>
        ///     Ims the font atlas get glyph ranges chinese simplified common using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        /// <returns>The ushort</returns>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "ImFontAtlas_GetGlyphRangesChineseSimplifiedCommon")]
        public static extern ushort* ImFontAtlas_GetGlyphRangesChineseSimplifiedCommon(IntPtr self);
        
        /// <summary>
        ///     Ims the font atlas get glyph ranges cyrillic using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        /// <returns>The ushort</returns>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "ImFontAtlas_GetGlyphRangesCyrillic")]
        public static extern ushort* ImFontAtlas_GetGlyphRangesCyrillic(IntPtr self);
        
        /// <summary>
        ///     Ims the font atlas get glyph ranges default using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        /// <returns>The ushort</returns>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "ImFontAtlas_GetGlyphRangesDefault")]
        public static extern ushort* ImFontAtlas_GetGlyphRangesDefault(IntPtr self);
        
        /// <summary>
        ///     Ims the font atlas get glyph ranges greek using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        /// <returns>The ushort</returns>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "ImFontAtlas_GetGlyphRangesGreek")]
        public static extern ushort* ImFontAtlas_GetGlyphRangesGreek(IntPtr self);
        
        /// <summary>
        ///     Ims the font atlas get glyph ranges japanese using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        /// <returns>The ushort</returns>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "ImFontAtlas_GetGlyphRangesJapanese")]
        public static extern ushort* ImFontAtlas_GetGlyphRangesJapanese(IntPtr self);
        
        /// <summary>
        ///     Ims the font atlas get glyph ranges korean using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        /// <returns>The ushort</returns>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "ImFontAtlas_GetGlyphRangesKorean")]
        public static extern ushort* ImFontAtlas_GetGlyphRangesKorean(IntPtr self);
        
        /// <summary>
        ///     Ims the font atlas get glyph ranges thai using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        /// <returns>The ushort</returns>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "ImFontAtlas_GetGlyphRangesThai")]
        public static extern ushort* ImFontAtlas_GetGlyphRangesThai(IntPtr self);
        
        /// <summary>
        ///     Ims the font atlas get glyph ranges vietnamese using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        /// <returns>The ushort</returns>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "ImFontAtlas_GetGlyphRangesVietnamese")]
        public static extern ushort* ImFontAtlas_GetGlyphRangesVietnamese(IntPtr self);
        
        /// <summary>
        ///     Ims the font atlas get mouse cursor tex data using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        /// <param name="cursor">The cursor</param>
        /// <param name="outOffset">The out offset</param>
        /// <param name="outSize">The out size</param>
        /// <param name="outUvBorder">The out uv border</param>
        /// <param name="outUvFill">The out uv fill</param>
        /// <returns>The byte</returns>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "ImFontAtlas_GetMouseCursorTexData")]
        public static extern byte ImFontAtlas_GetMouseCursorTexData(IntPtr self, ImGuiMouseCursor cursor, Vector2* outOffset, Vector2* outSize, Vector2* outUvBorder, Vector2* outUvFill);
        
        /// <summary>
        ///     Ims the font atlas get tex data as alpha 8 using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        /// <param name="outPixels">The out pixels</param>
        /// <param name="outWidth">The out width</param>
        /// <param name="outHeight">The out height</param>
        /// <param name="outBytesPerPixel">The out bytes per pixel</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "ImFontAtlas_GetTexDataAsAlpha8")]
        public static extern void ImFontAtlas_GetTexDataAsAlpha8(IntPtr self, byte** outPixels, int* outWidth, int* outHeight, int* outBytesPerPixel);
        
        /// <summary>
        ///     Ims the font atlas get tex data as alpha 8 using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        /// <param name="outPixels">The out pixels</param>
        /// <param name="outWidth">The out width</param>
        /// <param name="outHeight">The out height</param>
        /// <param name="outBytesPerPixel">The out bytes per pixel</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "ImFontAtlas_GetTexDataAsAlpha8")]
        public static extern void ImFontAtlas_GetTexDataAsAlpha8(IntPtr self, IntPtr* outPixels, int* outWidth, int* outHeight, int* outBytesPerPixel);
        
        /// <summary>
        ///     Ims the font atlas get tex data as rgba 32 using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        /// <param name="outPixels">The out pixels</param>
        /// <param name="outWidth">The out width</param>
        /// <param name="outHeight">The out height</param>
        /// <param name="outBytesPerPixel">The out bytes per pixel</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "ImFontAtlas_GetTexDataAsRGBA32")]
        public static extern void ImFontAtlas_GetTexDataAsRGBA32(IntPtr self, byte** outPixels, int* outWidth, int* outHeight, int* outBytesPerPixel);
        
        /// <summary>
        ///     Ims the font atlas get tex data as rgba 32 using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        /// <param name="outPixels">The out pixels</param>
        /// <param name="outWidth">The out width</param>
        /// <param name="outHeight">The out height</param>
        /// <param name="outBytesPerPixel">The out bytes per pixel</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "ImFontAtlas_GetTexDataAsRGBA32")]
        public static extern void ImFontAtlas_GetTexDataAsRGBA32(IntPtr self, IntPtr* outPixels, int* outWidth, int* outHeight, int* outBytesPerPixel);
        
        /// <summary>
        ///     Ims the font atlas im font atlas
        /// </summary>
        /// <returns>The im font atlas</returns>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "ImFontAtlas_ImFontAtlas")]
        public static extern IntPtr ImFontAtlas_ImFontAtlas();
        
        /// <summary>
        ///     Ims the font atlas is built using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        /// <returns>The byte</returns>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "ImFontAtlas_IsBuilt")]
        public static extern byte ImFontAtlas_IsBuilt(IntPtr self);
        
        /// <summary>
        ///     Ims the font atlas set tex id using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        /// <param name="id">The id</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "ImFontAtlas_SetTexID")]
        public static extern void ImFontAtlas_SetTexID(IntPtr self, IntPtr id);
        
        /// <summary>
        ///     Ims the font atlas custom rect destroy using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "ImFontAtlasCustomRect_destroy")]
        public static extern void ImFontAtlasCustomRect_destroy(ref ImFontAtlasCustomRect self);
        
        /// <summary>
        ///     Ims the font atlas custom rect im font atlas custom rect
        /// </summary>
        /// <returns>The im font atlas custom rect</returns>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "ImFontAtlasCustomRect_ImFontAtlasCustomRect")]
        public static extern ImFontAtlasCustomRect ImFontAtlasCustomRect_ImFontAtlasCustomRect();
        
        /// <summary>
        ///     Ims the font atlas custom rect is packed using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        /// <returns>The byte</returns>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "ImFontAtlasCustomRect_IsPacked")]
        public static extern byte ImFontAtlasCustomRect_IsPacked(ref ImFontAtlasCustomRect self);
        
        /// <summary>
        ///     Ims the font config destroy using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "ImFontConfig_destroy")]
        public static extern void ImFontConfig_destroy(IntPtr self);
        
        /// <summary>
        ///     Ims the font config im font config
        /// </summary>
        /// <returns>The im font config</returns>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "ImFontConfig_ImFontConfig")]
        public static extern IntPtr ImFontConfig_ImFontConfig();
        
        /// <summary>
        ///     Ims the font glyph ranges builder add char using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        /// <param name="c">The </param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "ImFontGlyphRangesBuilder_AddChar")]
        public static extern void ImFontGlyphRangesBuilder_AddChar(ref ImFontGlyphRangesBuilder self, ushort c);
        
        /// <summary>
        ///     Ims the font glyph ranges builder add ranges using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        /// <param name="ranges">The ranges</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "ImFontGlyphRangesBuilder_AddRanges")]
        public static extern void ImFontGlyphRangesBuilder_AddRanges(ref ImFontGlyphRangesBuilder self, ushort* ranges);
        
        /// <summary>
        ///     Ims the font glyph ranges builder add text using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        /// <param name="text">The text</param>
        /// <param name="textEnd">The text end</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "ImFontGlyphRangesBuilder_AddText")]
        public static extern void ImFontGlyphRangesBuilder_AddText(ref ImFontGlyphRangesBuilder self, byte[] text, byte[] textEnd);
        
        /// <summary>
        ///     Ims the font glyph ranges builder build ranges using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        /// <param name="outRanges">The out ranges</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "ImFontGlyphRangesBuilder_BuildRanges")]
        public static extern void ImFontGlyphRangesBuilder_BuildRanges(ref ImFontGlyphRangesBuilder self, ImVector* outRanges);
        
        /// <summary>
        ///     Ims the font glyph ranges builder clear using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "ImFontGlyphRangesBuilder_Clear")]
        public static extern void ImFontGlyphRangesBuilder_Clear(ref ImFontGlyphRangesBuilder self);
        
        /// <summary>
        ///     Ims the font glyph ranges builder destroy using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "ImFontGlyphRangesBuilder_destroy")]
        public static extern void ImFontGlyphRangesBuilder_destroy(ref ImFontGlyphRangesBuilder self);
        
        /// <summary>
        ///     Ims the font glyph ranges builder get bit using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        /// <param name="n">The </param>
        /// <returns>The byte</returns>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "ImFontGlyphRangesBuilder_GetBit")]
        public static extern byte ImFontGlyphRangesBuilder_GetBit(ref ImFontGlyphRangesBuilder self, uint n);
        
        /// <summary>
        ///     Ims the font glyph ranges builder im font glyph ranges builder
        /// </summary>
        /// <returns>The im font glyph ranges builder</returns>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "ImFontGlyphRangesBuilder_ImFontGlyphRangesBuilder")]
        public static extern IntPtr ImFontGlyphRangesBuilder_ImFontGlyphRangesBuilder();
        
        /// <summary>
        ///     Ims the font glyph ranges builder set bit using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        /// <param name="n">The </param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "ImFontGlyphRangesBuilder_SetBit")]
        public static extern void ImFontGlyphRangesBuilder_SetBit(ref ImFontGlyphRangesBuilder self, uint n);
        
        /// <summary>
        ///     Ims the gui input text callback data clear selection using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "ImGuiInputTextCallbackData_ClearSelection")]
        public static extern void ImGuiInputTextCallbackData_ClearSelection(IntPtr self);
        
        /// <summary>
        ///     Ims the gui input text callback data delete chars using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        /// <param name="pos">The pos</param>
        /// <param name="bytesCount">The bytes count</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "ImGuiInputTextCallbackData_DeleteChars")]
        public static extern void ImGuiInputTextCallbackData_DeleteChars(IntPtr self, int pos, int bytesCount);
        
        /// <summary>
        ///     Ims the gui input text callback data destroy using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "ImGuiInputTextCallbackData_destroy")]
        public static extern void ImGuiInputTextCallbackData_destroy(IntPtr self);
        
        /// <summary>
        ///     Ims the gui input text callback data has selection using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        /// <returns>The byte</returns>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "ImGuiInputTextCallbackData_HasSelection")]
        public static extern byte ImGuiInputTextCallbackData_HasSelection(IntPtr self);
        
        /// <summary>
        ///     Ims the gui input text callback data im gui input text callback data
        /// </summary>
        /// <returns>The im gui input text callback data</returns>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "ImGuiInputTextCallbackData_ImGuiInputTextCallbackData")]
        public static extern IntPtr ImGuiInputTextCallbackData_ImGuiInputTextCallbackData();
        
        /// <summary>
        ///     Ims the gui input text callback data insert chars using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        /// <param name="pos">The pos</param>
        /// <param name="text">The text</param>
        /// <param name="textEnd">The text end</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "ImGuiInputTextCallbackData_InsertChars")]
        public static extern void ImGuiInputTextCallbackData_InsertChars(IntPtr self, int pos, byte[] text, byte[] textEnd);
        
        /// <summary>
        ///     Ims the gui input text callback data select all using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "ImGuiInputTextCallbackData_SelectAll")]
        public static extern void ImGuiInputTextCallbackData_SelectAll(IntPtr self);
        
        /// <summary>
        ///     Ims the gui io add focus event using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        /// <param name="focused">The focused</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "ImGuiIO_AddFocusEvent")]
        public static extern void ImGuiIO_AddFocusEvent(IntPtr self, byte focused);
        
        /// <summary>
        ///     Ims the gui io add input character using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        /// <param name="c">The </param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "ImGuiIO_AddInputCharacter")]
        public static extern void ImGuiIO_AddInputCharacter(IntPtr self, uint c);
        
        /// <summary>
        ///     Ims the gui io add input characters utf 8 using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        /// <param name="str">The str</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "ImGuiIO_AddInputCharactersUTF8")]
        public static extern void ImGuiIO_AddInputCharactersUTF8(IntPtr self, byte* str);
        
        /// <summary>
        ///     Ims the gui io add input character utf 16 using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        /// <param name="c">The </param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "ImGuiIO_AddInputCharacterUTF16")]
        public static extern void ImGuiIO_AddInputCharacterUTF16(IntPtr self, ushort c);
        
        /// <summary>
        ///     Ims the gui io add key analog event using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        /// <param name="key">The key</param>
        /// <param name="down">The down</param>
        /// <param name="v">The </param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "ImGuiIO_AddKeyAnalogEvent")]
        public static extern void ImGuiIO_AddKeyAnalogEvent(IntPtr self, ImGuiKey key, byte down, float v);
        
        /// <summary>
        ///     Ims the gui io add key event using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        /// <param name="key">The key</param>
        /// <param name="down">The down</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "ImGuiIO_AddKeyEvent")]
        public static extern void ImGuiIO_AddKeyEvent(IntPtr self, ImGuiKey key, byte down);
        
        /// <summary>
        ///     Ims the gui io add mouse button event using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        /// <param name="button">The button</param>
        /// <param name="down">The down</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "ImGuiIO_AddMouseButtonEvent")]
        public static extern void ImGuiIO_AddMouseButtonEvent(IntPtr self, int button, byte down);
        
        /// <summary>
        ///     Ims the gui io add mouse pos event using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        /// <param name="x">The </param>
        /// <param name="y">The </param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "ImGuiIO_AddMousePosEvent")]
        public static extern void ImGuiIO_AddMousePosEvent(IntPtr self, float x, float y);
        
        /// <summary>
        ///     Ims the gui io add mouse viewport event using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        /// <param name="id">The id</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "ImGuiIO_AddMouseViewportEvent")]
        public static extern void ImGuiIO_AddMouseViewportEvent(IntPtr self, uint id);
        
        /// <summary>
        ///     Ims the gui io add mouse wheel event using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        /// <param name="whX">The wh</param>
        /// <param name="whY">The wh</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "ImGuiIO_AddMouseWheelEvent")]
        public static extern void ImGuiIO_AddMouseWheelEvent(IntPtr self, float whX, float whY);
        
        /// <summary>
        ///     Ims the gui io clear input characters using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "ImGuiIO_ClearInputCharacters")]
        public static extern void ImGuiIO_ClearInputCharacters(IntPtr self);
        
        /// <summary>
        ///     Ims the gui io clear input keys using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "ImGuiIO_ClearInputKeys")]
        public static extern void ImGuiIO_ClearInputKeys(IntPtr self);
        
        /// <summary>
        ///     Ims the gui io destroy using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "ImGuiIO_destroy")]
        public static extern void ImGuiIO_destroy(IntPtr self);
        
        /// <summary>
        ///     Ims the gui io im gui io
        /// </summary>
        /// <returns>The im gui io</returns>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "ImGuiIO_ImGuiIO")]
        public static extern IntPtr ImGuiIO_ImGuiIO();
        
        /// <summary>
        ///     Ims the gui io set app accepting events using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        /// <param name="acceptingEvents">The accepting events</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "ImGuiIO_SetAppAcceptingEvents")]
        public static extern void ImGuiIO_SetAppAcceptingEvents(IntPtr self, byte acceptingEvents);
        
        /// <summary>
        ///     Ims the gui io set key event native data using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        /// <param name="key">The key</param>
        /// <param name="nativeKeycode">The native keycode</param>
        /// <param name="nativeScancode">The native scancode</param>
        /// <param name="nativeLegacyIndex">The native legacy index</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "ImGuiIO_SetKeyEventNativeData")]
        public static extern void ImGuiIO_SetKeyEventNativeData(IntPtr self, ImGuiKey key, int nativeKeycode, int nativeScancode, int nativeLegacyIndex);
        
        /// <summary>
        ///     Ims the gui list clipper begin using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        /// <param name="itemsCount">The items count</param>
        /// <param name="itemsHeight">The items height</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "ImGuiListClipper_Begin")]
        public static extern void ImGuiListClipper_Begin(IntPtr self, int itemsCount, float itemsHeight);
        
        /// <summary>
        ///     Ims the gui list clipper destroy using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "ImGuiListClipper_destroy")]
        public static extern void ImGuiListClipper_destroy(IntPtr self);
        
        /// <summary>
        ///     Ims the gui list clipper end using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "ImGuiListClipper_End")]
        public static extern void ImGuiListClipper_End(IntPtr self);
        
        /// <summary>
        ///     Ims the gui list clipper force display range by indices using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        /// <param name="itemMin">The item min</param>
        /// <param name="itemMax">The item max</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "ImGuiListClipper_ForceDisplayRangeByIndices")]
        public static extern void ImGuiListClipper_ForceDisplayRangeByIndices(IntPtr self, int itemMin, int itemMax);
        
        /// <summary>
        ///     Ims the gui list clipper im gui list clipper
        /// </summary>
        /// <returns>The im gui list clipper</returns>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "ImGuiListClipper_ImGuiListClipper")]
        public static extern IntPtr ImGuiListClipper_ImGuiListClipper();
        
        /// <summary>
        ///     Ims the gui list clipper step using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        /// <returns>The byte</returns>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "ImGuiListClipper_Step")]
        public static extern byte ImGuiListClipper_Step(IntPtr self);
        
        /// <summary>
        ///     Ims the gui once upon a frame destroy using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "ImGuiOnceUponAFrame_destroy")]
        public static extern void ImGuiOnceUponAFrame_destroy(IntPtr self);
        
        /// <summary>
        ///     Ims the gui once upon a frame im gui once upon a frame
        /// </summary>
        /// <returns>The im gui once upon frame</returns>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "ImGuiOnceUponAFrame_ImGuiOnceUponAFrame")]
        public static extern IntPtr ImGuiOnceUponAFrame_ImGuiOnceUponAFrame();
        
        /// <summary>
        ///     Ims the gui payload clear using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "ImGuiPayload_Clear")]
        public static extern void ImGuiPayload_Clear(ref ImGuiPayload self);
        
        /// <summary>
        ///     Ims the gui payload destroy using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "ImGuiPayload_destroy")]
        public static extern void ImGuiPayload_destroy(ref ImGuiPayload self);
        
        /// <summary>
        ///     Ims the gui payload im gui payload
        /// </summary>
        /// <returns>The im gui payload</returns>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "ImGuiPayload_ImGuiPayload")]
        public static extern ImGuiPayload ImGuiPayload_ImGuiPayload();
        
        /// <summary>
        ///     Ims the gui payload is data type using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        /// <param name="type">The type</param>
        /// <returns>The byte</returns>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "ImGuiPayload_IsDataType")]
        public static extern byte ImGuiPayload_IsDataType(ref ImGuiPayload self, byte* type);
        
        /// <summary>
        ///     Ims the gui payload is delivery using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        /// <returns>The byte</returns>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "ImGuiPayload_IsDelivery")]
        public static extern byte ImGuiPayload_IsDelivery(ref ImGuiPayload self);
        
        /// <summary>
        ///     Ims the gui payload is preview using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        /// <returns>The byte</returns>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "ImGuiPayload_IsPreview")]
        public static extern byte ImGuiPayload_IsPreview(ref ImGuiPayload self);
        
        /// <summary>
        ///     Ims the gui platform ime data destroy using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "ImGuiPlatformImeData_destroy")]
        public static extern void ImGuiPlatformImeData_destroy(IntPtr self);
        
        /// <summary>
        ///     Ims the gui platform ime data im gui platform ime data
        /// </summary>
        /// <returns>The im gui platform ime data</returns>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "ImGuiPlatformImeData_ImGuiPlatformImeData")]
        public static extern IntPtr ImGuiPlatformImeData_ImGuiPlatformImeData();
        
        /// <summary>
        ///     Ims the gui platform io destroy using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "ImGuiPlatformIO_destroy")]
        public static extern void ImGuiPlatformIO_destroy(IntPtr self);
        
        /// <summary>
        ///     Ims the gui platform io im gui platform io
        /// </summary>
        /// <returns>The im gui platform io</returns>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "ImGuiPlatformIO_ImGuiPlatformIO")]
        public static extern IntPtr ImGuiPlatformIO_ImGuiPlatformIO();
        
        /// <summary>
        ///     Ims the gui platform monitor destroy using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "ImGuiPlatformMonitor_destroy")]
        public static extern void ImGuiPlatformMonitor_destroy(IntPtr self);
        
        /// <summary>
        ///     Ims the gui platform monitor im gui platform monitor
        /// </summary>
        /// <returns>The im gui platform monitor</returns>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "ImGuiPlatformMonitor_ImGuiPlatformMonitor")]
        public static extern IntPtr ImGuiPlatformMonitor_ImGuiPlatformMonitor();
        
        /// <summary>
        ///     Ims the gui storage build sort by key using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "ImGuiStorage_BuildSortByKey")]
        public static extern void ImGuiStorage_BuildSortByKey(ImGuiStorage self);
        
        /// <summary>
        ///     Ims the gui storage clear using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "ImGuiStorage_Clear")]
        public static extern void ImGuiStorage_Clear(ImGuiStorage self);
        
        /// <summary>
        ///     Ims the gui storage get bool using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        /// <param name="key">The key</param>
        /// <param name="defaultVal">The default val</param>
        /// <returns>The byte</returns>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "ImGuiStorage_GetBool")]
        public static extern byte ImGuiStorage_GetBool(ImGuiStorage self, uint key, byte defaultVal);
        
        /// <summary>
        ///     Ims the gui storage get bool ref using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        /// <param name="key">The key</param>
        /// <param name="defaultVal">The default val</param>
        /// <returns>The byte</returns>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "ImGuiStorage_GetBoolRef")]
        public static extern byte* ImGuiStorage_GetBoolRef(ImGuiStorage self, uint key, byte defaultVal);
        
        /// <summary>
        ///     Ims the gui storage get float using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        /// <param name="key">The key</param>
        /// <param name="defaultVal">The default val</param>
        /// <returns>The float</returns>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "ImGuiStorage_GetFloat")]
        public static extern float ImGuiStorage_GetFloat(ImGuiStorage self, uint key, float defaultVal);
        
        /// <summary>
        ///     Ims the gui storage get float ref using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        /// <param name="key">The key</param>
        /// <param name="defaultVal">The default val</param>
        /// <returns>The float</returns>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "ImGuiStorage_GetFloat")]
        public static extern float* ImGuiStorage_GetFloatRef(ImGuiStorage self, uint key, float defaultVal);
        
        /// <summary>
        ///     Ims the gui storage get int using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        /// <param name="key">The key</param>
        /// <param name="defaultVal">The default val</param>
        /// <returns>The int</returns>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "ImGuiStorage_GetInt")]
        public static extern int ImGuiStorage_GetInt(ImGuiStorage self, uint key, int defaultVal);
        
        /// <summary>
        ///     Ims the gui storage get int ref using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        /// <param name="key">The key</param>
        /// <param name="defaultVal">The default val</param>
        /// <returns>The int</returns>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "ImGuiStorage_GetIntRef")]
        public static extern int* ImGuiStorage_GetIntRef(ImGuiStorage self, uint key, int defaultVal);
        
        /// <summary>
        ///     Ims the gui storage get void ptr using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        /// <param name="key">The key</param>
        /// <returns>The void</returns>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "ImGuiStorage_GetVoidPtr")]
        public static extern IntPtr ImGuiStorage_GetVoidPtr(ImGuiStorage self, uint key);
        
        /// <summary>
        ///     Ims the gui storage get void ptr ref using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        /// <param name="key">The key</param>
        /// <param name="defaultVal">The default val</param>
        /// <returns>The void</returns>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "ImGuiStorage_GetVoidPtrRef")]
        public static extern void** ImGuiStorage_GetVoidPtrRef(ImGuiStorage self, uint key, IntPtr defaultVal);
        
        /// <summary>
        ///     Ims the gui storage set all int using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        /// <param name="val">The val</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "ImGuiStorage_SetAllInt")]
        public static extern void ImGuiStorage_SetAllInt(ImGuiStorage self, int val);
        
        /// <summary>
        ///     Ims the gui storage set bool using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        /// <param name="key">The key</param>
        /// <param name="val">The val</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "ImGuiStorage_SetBool")]
        public static extern void ImGuiStorage_SetBool(ImGuiStorage self, uint key, byte val);
        
        /// <summary>
        ///     Ims the gui storage set float using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        /// <param name="key">The key</param>
        /// <param name="val">The val</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "ImGuiStorage_SetFloat")]
        public static extern void ImGuiStorage_SetFloat(ImGuiStorage self, uint key, float val);
        
        /// <summary>
        ///     Ims the gui storage set int using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        /// <param name="key">The key</param>
        /// <param name="val">The val</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "ImGuiStorage_SetInt")]
        public static extern void ImGuiStorage_SetInt(ImGuiStorage self, uint key, int val);
        
        /// <summary>
        ///     Ims the gui storage set void ptr using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        /// <param name="key">The key</param>
        /// <param name="val">The val</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "ImGuiStorage_SetVoidPtr")]
        public static extern void ImGuiStorage_SetVoidPtr(ImGuiStorage self, uint key, IntPtr val);
        
        /// <summary>
        ///     Ims the gui storage pair destroy using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "ImGuiStoragePair_destroy")]
        public static extern void ImGuiStoragePair_destroy(ImGuiStoragePair* self);
        
        /// <summary>
        ///     Ims the gui storage pair im gui storage pair int using the specified  key
        /// </summary>
        /// <param name="key">The key</param>
        /// <param name="valI">The val</param>
        /// <returns>The im gui storage pair</returns>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "ImGuiStoragePair_ImGuiStoragePair_Int")]
        public static extern ImGuiStoragePair* ImGuiStoragePair_ImGuiStoragePair_Int(uint key, int valI);
        
        /// <summary>
        ///     Ims the gui storage pair im gui storage pair float using the specified  key
        /// </summary>
        /// <param name="key">The key</param>
        /// <param name="valF">The val</param>
        /// <returns>The im gui storage pair</returns>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "ImGuiStoragePair_ImGuiStoragePair_Float")]
        public static extern ImGuiStoragePair* ImGuiStoragePair_ImGuiStoragePair_Float(uint key, float valF);
        
        /// <summary>
        ///     Ims the gui storage pair im gui storage pair ptr using the specified  key
        /// </summary>
        /// <param name="key">The key</param>
        /// <param name="valP">The val</param>
        /// <returns>The im gui storage pair</returns>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "ImGuiStoragePair_ImGuiStoragePair_Ptr")]
        public static extern ImGuiStoragePair* ImGuiStoragePair_ImGuiStoragePair_Ptr(uint key, IntPtr valP);
        
        /// <summary>
        ///     Ims the gui style destroy using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "ImGuiStyle_destroy")]
        public static extern void ImGuiStyle_destroy(ImGuiStyle self);
        
        /// <summary>
        ///     Ims the gui style im gui style
        /// </summary>
        /// <returns>The im gui style</returns>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "ImGuiStyle_ImGuiStyle")]
        public static extern IntPtr ImGuiStyle_ImGuiStyle();
        
        /// <summary>
        ///     Ims the gui style scale all sizes using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        /// <param name="scaleFactor">The scale factor</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "ImGuiStyle_ScaleAllSizes")]
        public static extern void ImGuiStyle_ScaleAllSizes(ImGuiStyle self, float scaleFactor);
        
        /// <summary>
        ///     Ims the gui table column sort specs destroy using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "ImGuiTableColumnSortSpecs_destroy")]
        public static extern void ImGuiTableColumnSortSpecs_destroy(IntPtr self);
        
        /// <summary>
        ///     Ims the gui table column sort specs im gui table column sort specs
        /// </summary>
        /// <returns>The im gui table column sort specs</returns>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "ImGuiTableColumnSortSpecs_ImGuiTableColumnSortSpecs")]
        public static extern IntPtr ImGuiTableColumnSortSpecs_ImGuiTableColumnSortSpecs();
        
        /// <summary>
        ///     Ims the gui table sort specs destroy using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "ImGuiTableSortSpecs_destroy")]
        public static extern void ImGuiTableSortSpecs_destroy(ref ImGuiTableSortSpecs self);
        
        /// <summary>
        ///     Ims the gui table sort specs im gui table sort specs
        /// </summary>
        /// <returns>The im gui table sort specs</returns>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "ImGuiTableSortSpecs_ImGuiTableSortSpecs")]
        public static extern ImGuiTableSortSpecs ImGuiTableSortSpecs_ImGuiTableSortSpecs();
        
        /// <summary>
        ///     Ims the gui text buffer append using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        /// <param name="str">The str</param>
        /// <param name="strEnd">The str end</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "ImGuiTextBuffer_append")]
        public static extern void ImGuiTextBuffer_append(IntPtr self, byte* str, byte* strEnd);
        
        /// <summary>
        ///     Ims the gui text buffer appendf using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        /// <param name="fmt">The fmt</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "ImGuiTextBuffer_appendf")]
        public static extern void ImGuiTextBuffer_appendf(IntPtr self, byte[] fmt);
        
        /// <summary>
        ///     Ims the gui text buffer begin using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        /// <returns>The byte</returns>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "ImGuiTextBuffer_begin")]
        public static extern byte* ImGuiTextBuffer_begin(IntPtr self);
        
        /// <summary>
        ///     Ims the gui text buffer c str using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        /// <returns>The byte</returns>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "ImGuiTextBuffer_c_str")]
        public static extern byte* ImGuiTextBuffer_c_str(IntPtr self);
        
        /// <summary>
        ///     Ims the gui text buffer clear using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "ImGuiTextBuffer_clear")]
        public static extern void ImGuiTextBuffer_clear(IntPtr self);
        
        /// <summary>
        ///     Ims the gui text buffer destroy using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "ImGuiTextBuffer_destroy")]
        public static extern void ImGuiTextBuffer_destroy(IntPtr self);
        
        /// <summary>
        ///     Ims the gui text buffer empty using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        /// <returns>The byte</returns>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "ImGuiTextBuffer_empty")]
        public static extern byte ImGuiTextBuffer_empty(IntPtr self);
        
        /// <summary>
        ///     Ims the gui text buffer end using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        /// <returns>The byte</returns>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "ImGuiTextBuffer_end")]
        public static extern byte* ImGuiTextBuffer_end(IntPtr self);
        
        /// <summary>
        ///     Ims the gui text buffer im gui text buffer
        /// </summary>
        /// <returns>The im gui text buffer</returns>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "ImGuiTextBuffer_ImGuiTextBuffer")]
        public static extern IntPtr ImGuiTextBuffer_ImGuiTextBuffer();
        
        /// <summary>
        ///     Ims the gui text buffer reserve using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        /// <param name="capacity">The capacity</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "ImGuiTextBuffer_reserve")]
        public static extern void ImGuiTextBuffer_reserve(IntPtr self, int capacity);
        
        /// <summary>
        ///     Ims the gui text buffer size using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        /// <returns>The int</returns>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "ImGuiTextBuffer_size")]
        public static extern int ImGuiTextBuffer_size(IntPtr self);
        
        /// <summary>
        ///     Ims the gui text filter build using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "ImGuiTextFilter_Build")]
        public static extern void ImGuiTextFilter_Build(IntPtr self);
        
        /// <summary>
        ///     Ims the gui text filter clear using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "ImGuiTextFilter_Clear")]
        public static extern void ImGuiTextFilter_Clear(IntPtr self);
        
        /// <summary>
        ///     Ims the gui text filter destroy using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "ImGuiTextFilter_destroy")]
        public static extern void ImGuiTextFilter_destroy(IntPtr self);
        
        /// <summary>
        ///     Ims the gui text filter draw using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        /// <param name="label">The label</param>
        /// <param name="width">The width</param>
        /// <returns>The byte</returns>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "ImGuiTextFilter_Draw")]
        public static extern byte ImGuiTextFilter_Draw(IntPtr self, byte[] label, float width);
        
        /// <summary>
        ///     Ims the gui text filter im gui text filter using the specified default filter
        /// </summary>
        /// <param name="defaultFilter">The default filter</param>
        /// <returns>The im gui text filter</returns>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "ImGuiTextFilter_ImGuiTextFilter")]
        public static extern IntPtr ImGuiTextFilter_ImGuiTextFilter(byte* defaultFilter);
        
        /// <summary>
        ///     Ims the gui text filter is active using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        /// <returns>The byte</returns>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "ImGuiTextFilter_IsActive")]
        public static extern byte ImGuiTextFilter_IsActive(IntPtr self);
        
        /// <summary>
        ///     Ims the gui text filter pass filter using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        /// <param name="text">The text</param>
        /// <param name="textEnd">The text end</param>
        /// <returns>The byte</returns>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "ImGuiTextFilter_PassFilter")]
        public static extern byte ImGuiTextFilter_PassFilter(IntPtr self, byte[] text, byte[] textEnd);
        
        /// <summary>
        ///     Ims the gui text range destroy using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "ImGuiTextRange_destroy")]
        public static extern void ImGuiTextRange_destroy(IntPtr self);
        
        /// <summary>
        ///     Ims the gui text range empty using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        /// <returns>The byte</returns>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "ImGuiTextRange_empty")]
        public static extern byte ImGuiTextRange_empty(IntPtr self);
        
        /// <summary>
        ///     Ims the gui text range im gui text range nil
        /// </summary>
        /// <returns>The im gui text range</returns>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "ImGuiTextRange_ImGuiTextRange_Nil")]
        public static extern IntPtr ImGuiTextRange_ImGuiTextRange_Nil();
        
        /// <summary>
        ///     Ims the gui text range im gui text range str using the specified  b
        /// </summary>
        /// <param name="b">The </param>
        /// <param name="e">The </param>
        /// <returns>The im gui text range</returns>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "ImGuiTextRange_ImGuiTextRange_Str")]
        public static extern IntPtr ImGuiTextRange_ImGuiTextRange_Str(byte* b, byte* e);
        
        /// <summary>
        ///     Ims the gui text range split using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        /// <param name="separator">The separator</param>
        /// <param name="out">The out</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "ImGuiTextRange_split")]
        public static extern void ImGuiTextRange_split(IntPtr self, byte separator, ImVector* @out);
        
        /// <summary>
        ///     Ims the gui viewport destroy using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "ImGuiViewport_destroy")]
        public static extern void ImGuiViewport_destroy(IntPtr self);
        
        /// <summary>
        ///     Ims the gui viewport get center using the specified p out
        /// </summary>
        /// <param name="pOut">The out</param>
        /// <param name="self">The self</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "ImGuiViewport_GetCenter")]
        public static extern void ImGuiViewport_GetCenter(out Vector2 pOut, IntPtr self);
        
        /// <summary>
        ///     Ims the gui viewport get work center using the specified p out
        /// </summary>
        /// <param name="pOut">The out</param>
        /// <param name="self">The self</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "ImGuiViewport_GetWorkCenter")]
        public static extern void ImGuiViewport_GetWorkCenter(out Vector2 pOut, IntPtr self);
        
        /// <summary>
        ///     Ims the gui viewport im gui viewport
        /// </summary>
        /// <returns>The im gui viewport</returns>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "ImGuiViewport_ImGuiViewport")]
        public static extern IntPtr ImGuiViewport_ImGuiViewport();
        
        /// <summary>
        ///     Ims the gui window class destroy using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "ImGuiWindowClass_destroy")]
        public static extern void ImGuiWindowClass_destroy(ImGuiWindowClass self);
        
        /// <summary>
        ///     Ims the gui window class im gui window
        /// </summary>
        /// <returns>The im gui window class</returns>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "ImGuiWindowClass_ImGuiWindowClass")]
        public static extern ImGuiWindowClass ImGuiWindowClass_ImGuiWindowClass();
        
        /// <summary>
        ///     Ims the vec 2 destroy using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "ImVec2_destroy")]
        public static extern void ImVec2_destroy(Vector2* self);
        
        /// <summary>
        ///     Ims the vec 2 im vec 2 nil
        /// </summary>
        /// <returns>The vector</returns>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "ImVec2_ImVec2_Nil")]
        public static extern Vector2* ImVec2_ImVec2_Nil();
        
        /// <summary>
        ///     Ims the vec 2 im vec 2 float using the specified  x
        /// </summary>
        /// <param name="x">The </param>
        /// <param name="y">The </param>
        /// <returns>The vector</returns>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "ImVec2_ImVec2_Float")]
        public static extern Vector2* ImVec2_ImVec2_Float(float x, float y);
        
        /// <summary>
        ///     Ims the vec 4 destroy using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "ImVec4_destroy")]
        public static extern void ImVec4_destroy(Vector4 self);
        
        /// <summary>
        ///     Ims the vec 4 im vec 4 nil
        /// </summary>
        /// <returns>The vector</returns>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl , EntryPoint = "ImVec4_ImVec4_Nil")]
        public static extern Vector4 ImVec4_ImVec4_Nil();
        
        /// <summary>
        ///     Ims the vec 4 im vec 4 float using the specified  x
        /// </summary>
        /// <param name="x">The </param>
        /// <param name="y">The </param>
        /// <param name="z">The </param>
        /// <param name="w">The </param>
        /// <returns>The vector</returns>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ImVec4_ImVec4_Float")]
        public static extern Vector4 ImVec4_ImVec4_Float(float x, float y, float z, float w);
    }
}