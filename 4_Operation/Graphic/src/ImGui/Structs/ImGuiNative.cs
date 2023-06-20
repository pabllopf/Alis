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
using Alis.Core.Graphic.ImGui.Delegates;
using Alis.Core.Graphic.ImGui.Enums;

namespace Alis.Core.Graphic.ImGui.Structs
{
    /// <summary>
    ///     The im gui native class
    /// </summary>
    internal static unsafe class ImGuiNative
    {
        /// <summary>
        ///     Igs the accept drag drop payload using the specified type
        /// </summary>
        /// <param name="type">The type</param>
        /// <param name="flag">The flags</param>
        /// <returns>The im gui payload</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern ImGuiPayload* igAcceptDragDropPayload(byte* type, ImGuiDragDropFlag flag);

        /// <summary>
        ///     Ims the gui platform io set platform get window pos using the specified platform io
        /// </summary>
        /// <param name="platformIo">The platform io</param>
        /// <param name="funcPtr">The func ptr</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ImGuiPlatformIO_Set_Platform_GetWindowPos(ImGuiPlatformIo* platformIo, IntPtr funcPtr);

        /// <summary>
        ///     Ims the gui platform io set platform get window size using the specified platform io
        /// </summary>
        /// <param name="platformIo">The platform io</param>
        /// <param name="funcPtr">The func ptr</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ImGuiPlatformIO_Set_Platform_GetWindowSize(ImGuiPlatformIo* platformIo, IntPtr funcPtr);

        /// <summary>
        ///     Igs the align text to frame padding
        /// </summary>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void igAlignTextToFramePadding();

        /// <summary>
        ///     Igs the arrow button using the specified str id
        /// </summary>
        /// <param name="strId">The str id</param>
        /// <param name="dir">The dir</param>
        /// <returns>The byte</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern byte igArrowButton(byte* strId, ImGuiDir dir);

        /// <summary>
        ///     Igs the begin using the specified name
        /// </summary>
        /// <param name="name">The name</param>
        /// <param name="pOpen">The open</param>
        /// <param name="flag">The flags</param>
        /// <returns>The byte</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern byte igBegin(byte* name, byte* pOpen, ImGuiWindowFlag flag);

        /// <summary>
        ///     Igs the begin child str using the specified str id
        /// </summary>
        /// <param name="strId">The str id</param>
        /// <param name="size">The size</param>
        /// <param name="border">The border</param>
        /// <param name="flag">The flags</param>
        /// <returns>The byte</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern byte igBeginChild_Str(byte* strId, Vector2F size, byte border, ImGuiWindowFlag flag);

        /// <summary>
        ///     Igs the begin child id using the specified id
        /// </summary>
        /// <param name="id">The id</param>
        /// <param name="size">The size</param>
        /// <param name="border">The border</param>
        /// <param name="flag">The flags</param>
        /// <returns>The byte</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern byte igBeginChild_ID(uint id, Vector2F size, byte border, ImGuiWindowFlag flag);

        /// <summary>
        ///     Igs the begin child frame using the specified id
        /// </summary>
        /// <param name="id">The id</param>
        /// <param name="size">The size</param>
        /// <param name="flag">The flags</param>
        /// <returns>The byte</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern byte igBeginChildFrame(uint id, Vector2F size, ImGuiWindowFlag flag);

        /// <summary>
        ///     Igs the begin combo using the specified label
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="previewValue">The preview value</param>
        /// <param name="flag">The flags</param>
        /// <returns>The byte</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern byte igBeginCombo(byte* label, byte* previewValue, ImGuiComboFlag flag);

        /// <summary>
        ///     Igs the begin disabled using the specified disabled
        /// </summary>
        /// <param name="disabled">The disabled</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void igBeginDisabled(byte disabled);

        /// <summary>
        ///     Igs the begin drag drop source using the specified flags
        /// </summary>
        /// <param name="flag">The flags</param>
        /// <returns>The byte</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern byte igBeginDragDropSource(ImGuiDragDropFlag flag);

        /// <summary>
        ///     Igs the begin drag drop target
        /// </summary>
        /// <returns>The byte</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern byte igBeginDragDropTarget();

        /// <summary>
        ///     Igs the begin group
        /// </summary>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void igBeginGroup();

        /// <summary>
        ///     Igs the begin list box using the specified label
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="size">The size</param>
        /// <returns>The byte</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern byte igBeginListBox(byte* label, Vector2F size);

        /// <summary>
        ///     Igs the begin main menu bar
        /// </summary>
        /// <returns>The byte</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern byte igBeginMainMenuBar();

        /// <summary>
        ///     Igs the begin menu using the specified label
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="enabled">The enabled</param>
        /// <returns>The byte</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern byte igBeginMenu(byte* label, byte enabled);

        /// <summary>
        ///     Igs the begin menu bar
        /// </summary>
        /// <returns>The byte</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern byte igBeginMenuBar();

        /// <summary>
        ///     Igs the begin popup using the specified str id
        /// </summary>
        /// <param name="strId">The str id</param>
        /// <param name="flag">The flags</param>
        /// <returns>The byte</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern byte igBeginPopup(byte* strId, ImGuiWindowFlag flag);

        /// <summary>
        ///     Igs the begin popup context item using the specified str id
        /// </summary>
        /// <param name="strId">The str id</param>
        /// <param name="popupFlag">The popup flags</param>
        /// <returns>The byte</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern byte igBeginPopupContextItem(byte* strId, ImGuiPopupFlag popupFlag);

        /// <summary>
        ///     Igs the begin popup context void using the specified str id
        /// </summary>
        /// <param name="strId">The str id</param>
        /// <param name="popupFlag">The popup flags</param>
        /// <returns>The byte</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern byte igBeginPopupContextVoid(byte* strId, ImGuiPopupFlag popupFlag);

        /// <summary>
        ///     Igs the begin popup context window using the specified str id
        /// </summary>
        /// <param name="strId">The str id</param>
        /// <param name="popupFlag">The popup flags</param>
        /// <returns>The byte</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern byte igBeginPopupContextWindow(byte* strId, ImGuiPopupFlag popupFlag);

        /// <summary>
        ///     Igs the begin popup modal using the specified name
        /// </summary>
        /// <param name="name">The name</param>
        /// <param name="pOpen">The open</param>
        /// <param name="flag">The flags</param>
        /// <returns>The byte</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern byte igBeginPopupModal(byte* name, byte* pOpen, ImGuiWindowFlag flag);

        /// <summary>
        ///     Igs the begin tab bar using the specified str id
        /// </summary>
        /// <param name="strId">The str id</param>
        /// <param name="flag">The flags</param>
        /// <returns>The byte</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern byte igBeginTabBar(byte* strId, ImGuiTabBarFlag flag);

        /// <summary>
        ///     Igs the begin tab item using the specified label
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="pOpen">The open</param>
        /// <param name="flag">The flags</param>
        /// <returns>The byte</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern byte igBeginTabItem(byte* label, byte* pOpen, ImGuiTabItemFlag flag);

        /// <summary>
        ///     Igs the begin table using the specified str id
        /// </summary>
        /// <param name="strId">The str id</param>
        /// <param name="column">The column</param>
        /// <param name="flag">The flags</param>
        /// <param name="outerSize">The outer size</param>
        /// <param name="innerWidth">The inner width</param>
        /// <returns>The byte</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern byte igBeginTable(byte* strId, int column, ImGuiTableFlag flag, Vector2F outerSize, float innerWidth);

        /// <summary>
        ///     Igs the begin tooltip
        /// </summary>
        /// <returns>The byte</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern byte igBeginTooltip();

        /// <summary>
        ///     Igs the bullet
        /// </summary>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void igBullet();

        /// <summary>
        ///     Igs the bullet text using the specified fmt
        /// </summary>
        /// <param name="fmt">The fmt</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void igBulletText(byte* fmt);

        /// <summary>
        ///     Igs the button using the specified label
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="size">The size</param>
        /// <returns>The byte</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern byte igButton(byte* label, Vector2F size);

        /// <summary>
        ///     Igs the calc item width
        /// </summary>
        /// <returns>The float</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern float igCalcItemWidth();

        /// <summary>
        ///     Igs the calc text size using the specified p out
        /// </summary>
        /// <param name="pOut">The out</param>
        /// <param name="text">The text</param>
        /// <param name="textEnd">The text end</param>
        /// <param name="hideTextAfterDoubleHash">The hide text after double hash</param>
        /// <param name="wrapWidth">The wrap width</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void igCalcTextSize(Vector2F* pOut, byte* text, byte* textEnd, byte hideTextAfterDoubleHash, float wrapWidth);

        /// <summary>
        ///     Igs the checkbox using the specified label
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="v">The </param>
        /// <returns>The byte</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern byte igCheckbox(byte* label, byte* v);

        /// <summary>
        ///     Igs the checkbox flags int ptr using the specified label
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="flags">The flags</param>
        /// <param name="flagsValue">The flags value</param>
        /// <returns>The byte</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern byte igCheckboxFlags_IntPtr(byte* label, int* flags, int flagsValue);

        /// <summary>
        ///     Igs the checkbox flags uint ptr using the specified label
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="flags">The flags</param>
        /// <param name="flagsValue">The flags value</param>
        /// <returns>The byte</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern byte igCheckboxFlags_UintPtr(byte* label, uint* flags, uint flagsValue);

        /// <summary>
        ///     Igs the close current popup
        /// </summary>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void igCloseCurrentPopup();

        /// <summary>
        ///     Igs the collapsing header tree node flags using the specified label
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="flag">The flags</param>
        /// <returns>The byte</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern byte igCollapsingHeader_TreeNodeFlags(byte* label, ImGuiTreeNodeFlag flag);

        /// <summary>
        ///     Igs the collapsing header bool ptr using the specified label
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="pVisible">The visible</param>
        /// <param name="flag">The flags</param>
        /// <returns>The byte</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern byte igCollapsingHeader_BoolPtr(byte* label, byte* pVisible, ImGuiTreeNodeFlag flag);

        /// <summary>
        ///     Igs the color button using the specified desc id
        /// </summary>
        /// <param name="descId">The desc id</param>
        /// <param name="col">The col</param>
        /// <param name="flag">The flags</param>
        /// <param name="size">The size</param>
        /// <returns>The byte</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern byte igColorButton(byte* descId, Vector4F col, ImGuiColorEditFlag flag, Vector2F size);


        /// <summary>
        /// </summary>
        /// <param name="in"></param>
        /// <returns></returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern uint igColorConvertFloat4ToU32(Vector4F @in);

        /// <summary>
        ///     Igs the color convert hs vto rgb using the specified h
        /// </summary>
        /// <param name="h">The </param>
        /// <param name="s">The </param>
        /// <param name="v">The </param>
        /// <param name="outR">The out</param>
        /// <param name="outG">The out</param>
        /// <param name="outB">The out</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void igColorConvertHSVtoRGB(float h, float s, float v, float* outR, float* outG, float* outB);

        /// <summary>
        ///     Igs the color convert rg bto hsv using the specified r
        /// </summary>
        /// <param name="r">The </param>
        /// <param name="g">The </param>
        /// <param name="b">The </param>
        /// <param name="outH">The out</param>
        /// <param name="outS">The out</param>
        /// <param name="outV">The out</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void igColorConvertRGBtoHSV(float r, float g, float b, float* outH, float* outS, float* outV);

        /// <summary>
        /// </summary>
        /// <param name="pOut"></param>
        /// <param name="in"></param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void igColorConvertU32ToFloat4(Vector4F* pOut, uint @in);

        /// <summary>
        ///     Igs the color edit 3 using the specified label
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="col">The col</param>
        /// <param name="flag">The flags</param>
        /// <returns>The byte</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern byte igColorEdit3(byte* label, Vector3F* col, ImGuiColorEditFlag flag);

        /// <summary>
        ///     Igs the color edit 4 using the specified label
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="col">The col</param>
        /// <param name="flag">The flags</param>
        /// <returns>The byte</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern byte igColorEdit4(byte* label, Vector4F* col, ImGuiColorEditFlag flag);

        /// <summary>
        ///     Igs the color picker 3 using the specified label
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="col">The col</param>
        /// <param name="flag">The flags</param>
        /// <returns>The byte</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern byte igColorPicker3(byte* label, Vector3F* col, ImGuiColorEditFlag flag);

        /// <summary>
        ///     Igs the color picker 4 using the specified label
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="col">The col</param>
        /// <param name="flag">The flags</param>
        /// <param name="refCol">The ref col</param>
        /// <returns>The byte</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern byte igColorPicker4(byte* label, Vector4F* col, ImGuiColorEditFlag flag, float* refCol);

        /// <summary>
        ///     Igs the columns using the specified count
        /// </summary>
        /// <param name="count">The count</param>
        /// <param name="id">The id</param>
        /// <param name="border">The border</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void igColumns(int count, byte* id, byte border);

        /// <summary>
        ///     Igs the combo str arr using the specified label
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="currentItem">The current item</param>
        /// <param name="items">The items</param>
        /// <param name="itemsCount">The items count</param>
        /// <param name="popupMaxHeightInItems">The popup max height in items</param>
        /// <returns>The byte</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern byte igCombo_Str_arr(byte* label, int* currentItem, byte** items, int itemsCount, int popupMaxHeightInItems);

        /// <summary>
        ///     Igs the combo str using the specified label
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="currentItem">The current item</param>
        /// <param name="itemsSeparatedByZeros">The items separated by zeros</param>
        /// <param name="popupMaxHeightInItems">The popup max height in items</param>
        /// <returns>The byte</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern byte igCombo_Str(byte* label, int* currentItem, byte* itemsSeparatedByZeros, int popupMaxHeightInItems);

        /// <summary>
        ///     Igs the create context using the specified shared font atlas
        /// </summary>
        /// <param name="sharedFontAtlas">The shared font atlas</param>
        /// <returns>The int ptr</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr igCreateContext(ImFontAtlas* sharedFontAtlas);

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
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern byte igDebugCheckVersionAndDataLayout(byte* versionStr, uint szIo, uint szStyle, uint szVec2, uint szVec4, uint szDrawvert, uint szDrawidx);

        /// <summary>
        ///     Igs the debug text encoding using the specified text
        /// </summary>
        /// <param name="text">The text</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void igDebugTextEncoding(byte* text);

        /// <summary>
        ///     Igs the destroy context using the specified ctx
        /// </summary>
        /// <param name="ctx">The ctx</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void igDestroyContext(IntPtr ctx);

        /// <summary>
        ///     Igs the destroy platform windows
        /// </summary>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void igDestroyPlatformWindows();

        /// <summary>
        ///     Igs the dock space using the specified id
        /// </summary>
        /// <param name="id">The id</param>
        /// <param name="size">The size</param>
        /// <param name="flag">The flags</param>
        /// <param name="windowClass">The window class</param>
        /// <returns>The uint</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern uint igDockSpace(uint id, Vector2F size, ImGuiDockNodeFlag flag, ImGuiWindowClass* windowClass);

        /// <summary>
        ///     Igs the dock space over viewport using the specified viewport
        /// </summary>
        /// <param name="viewport">The viewport</param>
        /// <param name="flag">The flags</param>
        /// <param name="windowClass">The window class</param>
        /// <returns>The uint</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern uint igDockSpaceOverViewport(ImGuiViewport* viewport, ImGuiDockNodeFlag flag, ImGuiWindowClass* windowClass);

        /// <summary>
        ///     Igs the drag float using the specified label
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="v">The </param>
        /// <param name="vSpeed">The speed</param>
        /// <param name="vMin">The min</param>
        /// <param name="vMax">The max</param>
        /// <param name="format">The format</param>
        /// <param name="flag">The flags</param>
        /// <returns>The byte</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern byte igDragFloat(byte* label, float* v, float vSpeed, float vMin, float vMax, byte* format, ImGuiSliderFlag flag);

        /// <summary>
        ///     Igs the drag float 2 using the specified label
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="v">The </param>
        /// <param name="vSpeed">The speed</param>
        /// <param name="vMin">The min</param>
        /// <param name="vMax">The max</param>
        /// <param name="format">The format</param>
        /// <param name="flag">The flags</param>
        /// <returns>The byte</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern byte igDragFloat2(byte* label, Vector2F* v, float vSpeed, float vMin, float vMax, byte* format, ImGuiSliderFlag flag);

        /// <summary>
        ///     Igs the drag float 3 using the specified label
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="v">The </param>
        /// <param name="vSpeed">The speed</param>
        /// <param name="vMin">The min</param>
        /// <param name="vMax">The max</param>
        /// <param name="format">The format</param>
        /// <param name="flag">The flags</param>
        /// <returns>The byte</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern byte igDragFloat3(byte* label, Vector3F* v, float vSpeed, float vMin, float vMax, byte* format, ImGuiSliderFlag flag);

        /// <summary>
        ///     Igs the drag float 4 using the specified label
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="v">The </param>
        /// <param name="vSpeed">The speed</param>
        /// <param name="vMin">The min</param>
        /// <param name="vMax">The max</param>
        /// <param name="format">The format</param>
        /// <param name="flag">The flags</param>
        /// <returns>The byte</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern byte igDragFloat4(byte* label, Vector4F* v, float vSpeed, float vMin, float vMax, byte* format, ImGuiSliderFlag flag);

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
        /// <param name="flag">The flags</param>
        /// <returns>The byte</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern byte igDragFloatRange2(byte* label, float* vCurrentMin, float* vCurrentMax, float vSpeed, float vMin, float vMax, byte* format, byte* formatMax, ImGuiSliderFlag flag);

        /// <summary>
        ///     Igs the drag int using the specified label
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="v">The </param>
        /// <param name="vSpeed">The speed</param>
        /// <param name="vMin">The min</param>
        /// <param name="vMax">The max</param>
        /// <param name="format">The format</param>
        /// <param name="flag">The flags</param>
        /// <returns>The byte</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern byte igDragInt(byte* label, int* v, float vSpeed, int vMin, int vMax, byte* format, ImGuiSliderFlag flag);

        /// <summary>
        ///     Igs the drag int 2 using the specified label
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="v">The </param>
        /// <param name="vSpeed">The speed</param>
        /// <param name="vMin">The min</param>
        /// <param name="vMax">The max</param>
        /// <param name="format">The format</param>
        /// <param name="flag">The flags</param>
        /// <returns>The byte</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern byte igDragInt2(byte* label, int* v, float vSpeed, int vMin, int vMax, byte* format, ImGuiSliderFlag flag);

        /// <summary>
        ///     Igs the drag int 3 using the specified label
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="v">The </param>
        /// <param name="vSpeed">The speed</param>
        /// <param name="vMin">The min</param>
        /// <param name="vMax">The max</param>
        /// <param name="format">The format</param>
        /// <param name="flag">The flags</param>
        /// <returns>The byte</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern byte igDragInt3(byte* label, int* v, float vSpeed, int vMin, int vMax, byte* format, ImGuiSliderFlag flag);

        /// <summary>
        ///     Igs the drag int 4 using the specified label
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="v">The </param>
        /// <param name="vSpeed">The speed</param>
        /// <param name="vMin">The min</param>
        /// <param name="vMax">The max</param>
        /// <param name="format">The format</param>
        /// <param name="flag">The flags</param>
        /// <returns>The byte</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern byte igDragInt4(byte* label, int* v, float vSpeed, int vMin, int vMax, byte* format, ImGuiSliderFlag flag);

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
        /// <param name="flag">The flags</param>
        /// <returns>The byte</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern byte igDragIntRange2(byte* label, int* vCurrentMin, int* vCurrentMax, float vSpeed, int vMin, int vMax, byte* format, byte* formatMax, ImGuiSliderFlag flag);

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
        /// <param name="flag">The flags</param>
        /// <returns>The byte</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern byte igDragScalar(byte* label, ImGuiDataType dataType, void* pData, float vSpeed, void* pMin, void* pMax, byte* format, ImGuiSliderFlag flag);

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
        /// <param name="flag">The flags</param>
        /// <returns>The byte</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern byte igDragScalarN(byte* label, ImGuiDataType dataType, void* pData, int components, float vSpeed, void* pMin, void* pMax, byte* format, ImGuiSliderFlag flag);

        /// <summary>
        ///     Igs the dummy using the specified size
        /// </summary>
        /// <param name="size">The size</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void igDummy(Vector2F size);

        /// <summary>
        ///     Igs the end
        /// </summary>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void igEnd();

        /// <summary>
        ///     Igs the end child
        /// </summary>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void igEndChild();

        /// <summary>
        ///     Igs the end child frame
        /// </summary>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void igEndChildFrame();

        /// <summary>
        ///     Igs the end combo
        /// </summary>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void igEndCombo();

        /// <summary>
        ///     Igs the end disabled
        /// </summary>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void igEndDisabled();

        /// <summary>
        ///     Igs the end drag drop source
        /// </summary>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void igEndDragDropSource();

        /// <summary>
        ///     Igs the end drag drop target
        /// </summary>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void igEndDragDropTarget();

        /// <summary>
        ///     Igs the end frame
        /// </summary>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void igEndFrame();

        /// <summary>
        ///     Igs the end group
        /// </summary>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void igEndGroup();

        /// <summary>
        ///     Igs the end list box
        /// </summary>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void igEndListBox();

        /// <summary>
        ///     Igs the end main menu bar
        /// </summary>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void igEndMainMenuBar();

        /// <summary>
        ///     Igs the end menu
        /// </summary>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void igEndMenu();

        /// <summary>
        ///     Igs the end menu bar
        /// </summary>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void igEndMenuBar();

        /// <summary>
        ///     Igs the end popup
        /// </summary>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void igEndPopup();

        /// <summary>
        ///     Igs the end tab bar
        /// </summary>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void igEndTabBar();

        /// <summary>
        ///     Igs the end tab item
        /// </summary>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void igEndTabItem();

        /// <summary>
        ///     Igs the end table
        /// </summary>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void igEndTable();

        /// <summary>
        ///     Igs the end tooltip
        /// </summary>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void igEndTooltip();

        /// <summary>
        ///     Igs the find viewport by id using the specified id
        /// </summary>
        /// <param name="id">The id</param>
        /// <returns>The im gui viewport</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern ImGuiViewport* igFindViewportByID(uint id);

        /// <summary>
        ///     Igs the find viewport by platform handle using the specified platform handle
        /// </summary>
        /// <param name="platformHandle">The platform handle</param>
        /// <returns>The im gui viewport</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern ImGuiViewport* igFindViewportByPlatformHandle(void* platformHandle);

        /// <summary>
        ///     Igs the get allocator functions using the specified p alloc func
        /// </summary>
        /// <param name="pAllocFunc">The alloc func</param>
        /// <param name="pFreeFunc">The free func</param>
        /// <param name="pUserData">The user data</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void igGetAllocatorFunctions(IntPtr* pAllocFunc, IntPtr* pFreeFunc, void** pUserData);

        /// <summary>
        ///     Igs the get background draw list nil
        /// </summary>
        /// <returns>The im draw list</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern ImDrawList* igGetBackgroundDrawList_Nil();

        /// <summary>
        ///     Igs the get background draw list viewport ptr using the specified viewport
        /// </summary>
        /// <param name="viewport">The viewport</param>
        /// <returns>The im draw list</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern ImDrawList* igGetBackgroundDrawList_ViewportPtr(ImGuiViewport* viewport);

        /// <summary>
        ///     Igs the get clipboard text
        /// </summary>
        /// <returns>The byte</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern byte* igGetClipboardText();

        /// <summary>
        ///     Igs the get color u 32 col using the specified idx
        /// </summary>
        /// <param name="idx">The idx</param>
        /// <param name="alphaMul">The alpha mul</param>
        /// <returns>The uint</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern uint igGetColorU32_Col(ImGuiCol idx, float alphaMul);

        /// <summary>
        ///     Igs the get color u 32 vec 4 using the specified col
        /// </summary>
        /// <param name="col">The col</param>
        /// <returns>The uint</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern uint igGetColorU32_Vec4(Vector4F col);

        /// <summary>
        ///     Igs the get color u 32 u 32 using the specified col
        /// </summary>
        /// <param name="col">The col</param>
        /// <returns>The uint</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern uint igGetColorU32_U32(uint col);

        /// <summary>
        ///     Igs the get column index
        /// </summary>
        /// <returns>The int</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int igGetColumnIndex();

        /// <summary>
        ///     Igs the get column offset using the specified column index
        /// </summary>
        /// <param name="columnIndex">The column index</param>
        /// <returns>The float</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern float igGetColumnOffset(int columnIndex);

        /// <summary>
        ///     Igs the get columns count
        /// </summary>
        /// <returns>The int</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int igGetColumnsCount();

        /// <summary>
        ///     Igs the get column width using the specified column index
        /// </summary>
        /// <param name="columnIndex">The column index</param>
        /// <returns>The float</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern float igGetColumnWidth(int columnIndex);

        /// <summary>
        ///     Igs the get content region avail using the specified p out
        /// </summary>
        /// <param name="pOut">The out</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void igGetContentRegionAvail(Vector2F* pOut);

        /// <summary>
        ///     Igs the get content region max using the specified p out
        /// </summary>
        /// <param name="pOut">The out</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void igGetContentRegionMax(Vector2F* pOut);

        /// <summary>
        ///     Igs the get current context
        /// </summary>
        /// <returns>The int ptr</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr igGetCurrentContext();

        /// <summary>
        ///     Igs the get cursor pos using the specified p out
        /// </summary>
        /// <param name="pOut">The out</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void igGetCursorPos(Vector2F* pOut);

        /// <summary>
        ///     Igs the get cursor pos x
        /// </summary>
        /// <returns>The float</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern float igGetCursorPosX();

        /// <summary>
        ///     Igs the get cursor pos y
        /// </summary>
        /// <returns>The float</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern float igGetCursorPosY();

        /// <summary>
        ///     Igs the get cursor screen pos using the specified p out
        /// </summary>
        /// <param name="pOut">The out</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void igGetCursorScreenPos(Vector2F* pOut);

        /// <summary>
        ///     Igs the get cursor start pos using the specified p out
        /// </summary>
        /// <param name="pOut">The out</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void igGetCursorStartPos(Vector2F* pOut);

        /// <summary>
        ///     Igs the get drag drop payload
        /// </summary>
        /// <returns>The im gui payload</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern ImGuiPayload* igGetDragDropPayload();

        /// <summary>
        ///     Igs the get draw data
        /// </summary>
        /// <returns>The im draw data</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern ImDrawData* igGetDrawData();

        /// <summary>
        ///     Igs the get draw list shared data
        /// </summary>
        /// <returns>The int ptr</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr igGetDrawListSharedData();

        /// <summary>
        ///     Igs the get font
        /// </summary>
        /// <returns>The im font</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern ImFont* igGetFont();

        /// <summary>
        ///     Igs the get font size
        /// </summary>
        /// <returns>The float</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern float igGetFontSize();

        /// <summary>
        ///     Igs the get font tex uv white pixel using the specified p out
        /// </summary>
        /// <param name="pOut">The out</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void igGetFontTexUvWhitePixel(Vector2F* pOut);

        /// <summary>
        ///     Igs the get foreground draw list nil
        /// </summary>
        /// <returns>The im draw list</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern ImDrawList* igGetForegroundDrawList_Nil();

        /// <summary>
        ///     Igs the get foreground draw list viewport ptr using the specified viewport
        /// </summary>
        /// <param name="viewport">The viewport</param>
        /// <returns>The im draw list</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern ImDrawList* igGetForegroundDrawList_ViewportPtr(ImGuiViewport* viewport);

        /// <summary>
        ///     Igs the get frame count
        /// </summary>
        /// <returns>The int</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int igGetFrameCount();

        /// <summary>
        ///     Igs the get frame height
        /// </summary>
        /// <returns>The float</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern float igGetFrameHeight();

        /// <summary>
        ///     Igs the get frame height with spacing
        /// </summary>
        /// <returns>The float</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern float igGetFrameHeightWithSpacing();

        /// <summary>
        ///     Igs the get id str using the specified str id
        /// </summary>
        /// <param name="strId">The str id</param>
        /// <returns>The uint</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern uint igGetID_Str(byte* strId);

        /// <summary>
        ///     Igs the get id str str using the specified str id begin
        /// </summary>
        /// <param name="strIdBegin">The str id begin</param>
        /// <param name="strIdEnd">The str id end</param>
        /// <returns>The uint</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern uint igGetID_StrStr(byte* strIdBegin, byte* strIdEnd);

        /// <summary>
        ///     Igs the get id ptr using the specified ptr id
        /// </summary>
        /// <param name="ptrId">The ptr id</param>
        /// <returns>The uint</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern uint igGetID_Ptr(void* ptrId);

        /// <summary>
        ///     Igs the get io
        /// </summary>
        /// <returns>The im gui io</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern ImGuiIo* igGetIO();

        /// <summary>
        ///     Igs the get item id
        /// </summary>
        /// <returns>The uint</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern uint igGetItemID();

        /// <summary>
        ///     Igs the get item rect max using the specified p out
        /// </summary>
        /// <param name="pOut">The out</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void igGetItemRectMax(Vector2F* pOut);

        /// <summary>
        ///     Igs the get item rect min using the specified p out
        /// </summary>
        /// <param name="pOut">The out</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void igGetItemRectMin(Vector2F* pOut);

        /// <summary>
        ///     Igs the get item rect size using the specified p out
        /// </summary>
        /// <param name="pOut">The out</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void igGetItemRectSize(Vector2F* pOut);

        /// <summary>
        ///     Igs the get key index using the specified key
        /// </summary>
        /// <param name="key">The key</param>
        /// <returns>The im gui key</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern ImGuiKey igGetKeyIndex(ImGuiKey key);

        /// <summary>
        ///     Igs the get key name using the specified key
        /// </summary>
        /// <param name="key">The key</param>
        /// <returns>The byte</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern byte* igGetKeyName(ImGuiKey key);

        /// <summary>
        ///     Igs the get key pressed amount using the specified key
        /// </summary>
        /// <param name="key">The key</param>
        /// <param name="repeatDelay">The repeat delay</param>
        /// <param name="rate">The rate</param>
        /// <returns>The int</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int igGetKeyPressedAmount(ImGuiKey key, float repeatDelay, float rate);

        /// <summary>
        ///     Igs the get main viewport
        /// </summary>
        /// <returns>The im gui viewport</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern ImGuiViewport* igGetMainViewport();

        /// <summary>
        ///     Igs the get mouse clicked count using the specified button
        /// </summary>
        /// <param name="button">The button</param>
        /// <returns>The int</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int igGetMouseClickedCount(ImGuiMouseButton button);

        /// <summary>
        ///     Igs the get mouse cursor
        /// </summary>
        /// <returns>The im gui mouse cursor</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern ImGuiMouseCursor igGetMouseCursor();

        /// <summary>
        ///     Igs the get mouse drag delta using the specified p out
        /// </summary>
        /// <param name="pOut">The out</param>
        /// <param name="button">The button</param>
        /// <param name="lockThreshold">The lock threshold</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void igGetMouseDragDelta(Vector2F* pOut, ImGuiMouseButton button, float lockThreshold);

        /// <summary>
        ///     Igs the get mouse pos using the specified p out
        /// </summary>
        /// <param name="pOut">The out</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void igGetMousePos(Vector2F* pOut);

        /// <summary>
        ///     Igs the get mouse pos on opening current popup using the specified p out
        /// </summary>
        /// <param name="pOut">The out</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void igGetMousePosOnOpeningCurrentPopup(Vector2F* pOut);

        /// <summary>
        ///     Igs the get platform io
        /// </summary>
        /// <returns>The im gui platform io</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern ImGuiPlatformIo* igGetPlatformIO();

        /// <summary>
        ///     Igs the get scroll max x
        /// </summary>
        /// <returns>The float</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern float igGetScrollMaxX();

        /// <summary>
        ///     Igs the get scroll max y
        /// </summary>
        /// <returns>The float</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern float igGetScrollMaxY();

        /// <summary>
        ///     Igs the get scroll x
        /// </summary>
        /// <returns>The float</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern float igGetScrollX();

        /// <summary>
        ///     Igs the get scroll y
        /// </summary>
        /// <returns>The float</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern float igGetScrollY();

        /// <summary>
        ///     Igs the get state storage
        /// </summary>
        /// <returns>The im gui storage</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern ImGuiStorage* igGetStateStorage();

        /// <summary>
        ///     Igs the get style
        /// </summary>
        /// <returns>The im gui style</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern ImGuiStyle* igGetStyle();

        /// <summary>
        ///     Igs the get style color name using the specified idx
        /// </summary>
        /// <param name="idx">The idx</param>
        /// <returns>The byte</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern byte* igGetStyleColorName(ImGuiCol idx);

        /// <summary>
        ///     Igs the get style color vec 4 using the specified idx
        /// </summary>
        /// <param name="idx">The idx</param>
        /// <returns>The vector</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern Vector4F* igGetStyleColorVec4(ImGuiCol idx);

        /// <summary>
        ///     Igs the get text line height
        /// </summary>
        /// <returns>The float</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern float igGetTextLineHeight();

        /// <summary>
        ///     Igs the get text line height with spacing
        /// </summary>
        /// <returns>The float</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern float igGetTextLineHeightWithSpacing();

        /// <summary>
        ///     Igs the get time
        /// </summary>
        /// <returns>The double</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern double igGetTime();

        /// <summary>
        ///     Igs the get tree node to label spacing
        /// </summary>
        /// <returns>The float</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern float igGetTreeNodeToLabelSpacing();

        /// <summary>
        ///     Igs the get version
        /// </summary>
        /// <returns>The byte</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern byte* igGetVersion();

        /// <summary>
        ///     Igs the get window content region max using the specified p out
        /// </summary>
        /// <param name="pOut">The out</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void igGetWindowContentRegionMax(Vector2F* pOut);

        /// <summary>
        ///     Igs the get window content region min using the specified p out
        /// </summary>
        /// <param name="pOut">The out</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void igGetWindowContentRegionMin(Vector2F* pOut);

        /// <summary>
        ///     Igs the get window dock id
        /// </summary>
        /// <returns>The uint</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern uint igGetWindowDockID();

        /// <summary>
        ///     Igs the get window dpi scale
        /// </summary>
        /// <returns>The float</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern float igGetWindowDpiScale();

        /// <summary>
        ///     Igs the get window draw list
        /// </summary>
        /// <returns>The im draw list</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern ImDrawList* igGetWindowDrawList();

        /// <summary>
        ///     Igs the get window height
        /// </summary>
        /// <returns>The float</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern float igGetWindowHeight();

        /// <summary>
        ///     Igs the get window pos using the specified p out
        /// </summary>
        /// <param name="pOut">The out</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void igGetWindowPos(Vector2F* pOut);

        /// <summary>
        ///     Igs the get window size using the specified p out
        /// </summary>
        /// <param name="pOut">The out</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void igGetWindowSize(Vector2F* pOut);

        /// <summary>
        ///     Igs the get window viewport
        /// </summary>
        /// <returns>The im gui viewport</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern ImGuiViewport* igGetWindowViewport();

        /// <summary>
        ///     Igs the get window width
        /// </summary>
        /// <returns>The float</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern float igGetWindowWidth();

        /// <summary>
        ///     Igs the image using the specified user texture id
        /// </summary>
        /// <param name="userTextureId">The user texture id</param>
        /// <param name="size">The size</param>
        /// <param name="uv0">The uv</param>
        /// <param name="uv1">The uv</param>
        /// <param name="tintCol">The tint col</param>
        /// <param name="borderCol">The border col</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void igImage(IntPtr userTextureId, Vector2F size, Vector2F uv0, Vector2F uv1, Vector4F tintCol, Vector4F borderCol);

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
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern byte igImageButton(byte* strId, IntPtr userTextureId, Vector2F size, Vector2F uv0, Vector2F uv1, Vector4F bgCol, Vector4F tintCol);

        /// <summary>
        ///     Igs the indent using the specified indent w
        /// </summary>
        /// <param name="indentW">The indent</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void igIndent(float indentW);

        /// <summary>
        ///     Igs the input double using the specified label
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="v">The </param>
        /// <param name="step">The step</param>
        /// <param name="stepFast">The step fast</param>
        /// <param name="format">The format</param>
        /// <param name="flag">The flags</param>
        /// <returns>The byte</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern byte igInputDouble(byte* label, double* v, double step, double stepFast, byte* format, ImGuiInputTextFlag flag);

        /// <summary>
        ///     Igs the input float using the specified label
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="v">The </param>
        /// <param name="step">The step</param>
        /// <param name="stepFast">The step fast</param>
        /// <param name="format">The format</param>
        /// <param name="flag">The flags</param>
        /// <returns>The byte</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern byte igInputFloat(byte* label, float* v, float step, float stepFast, byte* format, ImGuiInputTextFlag flag);

        /// <summary>
        ///     Igs the input float 2 using the specified label
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="v">The </param>
        /// <param name="format">The format</param>
        /// <param name="flag">The flags</param>
        /// <returns>The byte</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern byte igInputFloat2(byte* label, Vector2F* v, byte* format, ImGuiInputTextFlag flag);

        /// <summary>
        ///     Igs the input float 3 using the specified label
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="v">The </param>
        /// <param name="format">The format</param>
        /// <param name="flag">The flags</param>
        /// <returns>The byte</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern byte igInputFloat3(byte* label, Vector3F* v, byte* format, ImGuiInputTextFlag flag);

        /// <summary>
        ///     Igs the input float 4 using the specified label
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="v">The </param>
        /// <param name="format">The format</param>
        /// <param name="flag">The flags</param>
        /// <returns>The byte</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern byte igInputFloat4(byte* label, Vector4F* v, byte* format, ImGuiInputTextFlag flag);

        /// <summary>
        ///     Igs the input int using the specified label
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="v">The </param>
        /// <param name="step">The step</param>
        /// <param name="stepFast">The step fast</param>
        /// <param name="flag">The flags</param>
        /// <returns>The byte</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern byte igInputInt(byte* label, int* v, int step, int stepFast, ImGuiInputTextFlag flag);

        /// <summary>
        ///     Igs the input int 2 using the specified label
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="v">The </param>
        /// <param name="flag">The flags</param>
        /// <returns>The byte</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern byte igInputInt2(byte* label, int* v, ImGuiInputTextFlag flag);

        /// <summary>
        ///     Igs the input int 3 using the specified label
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="v">The </param>
        /// <param name="flag">The flags</param>
        /// <returns>The byte</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern byte igInputInt3(byte* label, int* v, ImGuiInputTextFlag flag);

        /// <summary>
        ///     Igs the input int 4 using the specified label
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="v">The </param>
        /// <param name="flag">The flags</param>
        /// <returns>The byte</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern byte igInputInt4(byte* label, int* v, ImGuiInputTextFlag flag);

        /// <summary>
        ///     Igs the input scalar using the specified label
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="dataType">The data type</param>
        /// <param name="pData">The data</param>
        /// <param name="pStep">The step</param>
        /// <param name="pStepFast">The step fast</param>
        /// <param name="format">The format</param>
        /// <param name="flag">The flags</param>
        /// <returns>The byte</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern byte igInputScalar(byte* label, ImGuiDataType dataType, void* pData, void* pStep, void* pStepFast, byte* format, ImGuiInputTextFlag flag);

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
        /// <param name="flag">The flags</param>
        /// <returns>The byte</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern byte igInputScalarN(byte* label, ImGuiDataType dataType, void* pData, int components, void* pStep, void* pStepFast, byte* format, ImGuiInputTextFlag flag);

        /// <summary>
        ///     Igs the input text using the specified label
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="buf">The buf</param>
        /// <param name="bufSize">The buf size</param>
        /// <param name="flag">The flags</param>
        /// <param name="callback">The callback</param>
        /// <param name="userData">The user data</param>
        /// <returns>The byte</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern byte igInputText(byte* label, byte* buf, uint bufSize, ImGuiInputTextFlag flag, ImGuiInputTextCallback callback, void* userData);

        /// <summary>
        ///     Igs the input text multiline using the specified label
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="buf">The buf</param>
        /// <param name="bufSize">The buf size</param>
        /// <param name="size">The size</param>
        /// <param name="flag">The flags</param>
        /// <param name="callback">The callback</param>
        /// <param name="userData">The user data</param>
        /// <returns>The byte</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern byte igInputTextMultiline(byte* label, byte* buf, uint bufSize, Vector2F size, ImGuiInputTextFlag flag, ImGuiInputTextCallback callback, void* userData);

        /// <summary>
        ///     Igs the input text with hint using the specified label
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="hint">The hint</param>
        /// <param name="buf">The buf</param>
        /// <param name="bufSize">The buf size</param>
        /// <param name="flag">The flags</param>
        /// <param name="callback">The callback</param>
        /// <param name="userData">The user data</param>
        /// <returns>The byte</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern byte igInputTextWithHint(byte* label, byte* hint, byte* buf, uint bufSize, ImGuiInputTextFlag flag, ImGuiInputTextCallback callback, void* userData);

        /// <summary>
        ///     Igs the invisible button using the specified str id
        /// </summary>
        /// <param name="strId">The str id</param>
        /// <param name="size">The size</param>
        /// <param name="flag">The flags</param>
        /// <returns>The byte</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern byte igInvisibleButton(byte* strId, Vector2F size, ImGuiButtonFlag flag);

        /// <summary>
        ///     Igs the is any item active
        /// </summary>
        /// <returns>The byte</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern byte igIsAnyItemActive();

        /// <summary>
        ///     Igs the is any item focused
        /// </summary>
        /// <returns>The byte</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern byte igIsAnyItemFocused();

        /// <summary>
        ///     Igs the is any item hovered
        /// </summary>
        /// <returns>The byte</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern byte igIsAnyItemHovered();

        /// <summary>
        ///     Igs the is any mouse down
        /// </summary>
        /// <returns>The byte</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern byte igIsAnyMouseDown();

        /// <summary>
        ///     Igs the is item activated
        /// </summary>
        /// <returns>The byte</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern byte igIsItemActivated();

        /// <summary>
        ///     Igs the is item active
        /// </summary>
        /// <returns>The byte</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern byte igIsItemActive();

        /// <summary>
        ///     Igs the is item clicked using the specified mouse button
        /// </summary>
        /// <param name="mouseButton">The mouse button</param>
        /// <returns>The byte</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern byte igIsItemClicked(ImGuiMouseButton mouseButton);

        /// <summary>
        ///     Igs the is item deactivated
        /// </summary>
        /// <returns>The byte</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern byte igIsItemDeactivated();

        /// <summary>
        ///     Igs the is item deactivated after edit
        /// </summary>
        /// <returns>The byte</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern byte igIsItemDeactivatedAfterEdit();

        /// <summary>
        ///     Igs the is item edited
        /// </summary>
        /// <returns>The byte</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern byte igIsItemEdited();

        /// <summary>
        ///     Igs the is item focused
        /// </summary>
        /// <returns>The byte</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern byte igIsItemFocused();

        /// <summary>
        ///     Igs the is item hovered using the specified flags
        /// </summary>
        /// <param name="flag">The flags</param>
        /// <returns>The byte</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern byte igIsItemHovered(ImGuiHoveredFlag flag);

        /// <summary>
        ///     Igs the is item toggled open
        /// </summary>
        /// <returns>The byte</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern byte igIsItemToggledOpen();

        /// <summary>
        ///     Igs the is item visible
        /// </summary>
        /// <returns>The byte</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern byte igIsItemVisible();

        /// <summary>
        ///     Igs the is key down nil using the specified key
        /// </summary>
        /// <param name="key">The key</param>
        /// <returns>The byte</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern byte igIsKeyDown_Nil(ImGuiKey key);

        /// <summary>
        ///     Igs the is key pressed bool using the specified key
        /// </summary>
        /// <param name="key">The key</param>
        /// <param name="repeat">The repeat</param>
        /// <returns>The byte</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern byte igIsKeyPressed_Bool(ImGuiKey key, byte repeat);

        /// <summary>
        ///     Igs the is key released nil using the specified key
        /// </summary>
        /// <param name="key">The key</param>
        /// <returns>The byte</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern byte igIsKeyReleased_Nil(ImGuiKey key);

        /// <summary>
        ///     Igs the is mouse clicked bool using the specified button
        /// </summary>
        /// <param name="button">The button</param>
        /// <param name="repeat">The repeat</param>
        /// <returns>The byte</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern byte igIsMouseClicked_Bool(ImGuiMouseButton button, byte repeat);

        /// <summary>
        ///     Igs the is mouse double clicked using the specified button
        /// </summary>
        /// <param name="button">The button</param>
        /// <returns>The byte</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern byte igIsMouseDoubleClicked(ImGuiMouseButton button);

        /// <summary>
        ///     Igs the is mouse down nil using the specified button
        /// </summary>
        /// <param name="button">The button</param>
        /// <returns>The byte</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern byte igIsMouseDown_Nil(ImGuiMouseButton button);

        /// <summary>
        ///     Igs the is mouse dragging using the specified button
        /// </summary>
        /// <param name="button">The button</param>
        /// <param name="lockThreshold">The lock threshold</param>
        /// <returns>The byte</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern byte igIsMouseDragging(ImGuiMouseButton button, float lockThreshold);

        /// <summary>
        ///     Igs the is mouse hovering rect using the specified r min
        /// </summary>
        /// <param name="rMin">The min</param>
        /// <param name="rMax">The max</param>
        /// <param name="clip">The clip</param>
        /// <returns>The byte</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern byte igIsMouseHoveringRect(Vector2F rMin, Vector2F rMax, byte clip);

        /// <summary>
        ///     Igs the is mouse pos valid using the specified mouse pos
        /// </summary>
        /// <param name="mousePos">The mouse pos</param>
        /// <returns>The byte</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern byte igIsMousePosValid(Vector2F* mousePos);

        /// <summary>
        ///     Igs the is mouse released nil using the specified button
        /// </summary>
        /// <param name="button">The button</param>
        /// <returns>The byte</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern byte igIsMouseReleased_Nil(ImGuiMouseButton button);

        /// <summary>
        ///     Igs the is popup open str using the specified str id
        /// </summary>
        /// <param name="strId">The str id</param>
        /// <param name="flag">The flags</param>
        /// <returns>The byte</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern byte igIsPopupOpen_Str(byte* strId, ImGuiPopupFlag flag);

        /// <summary>
        ///     Igs the is rect visible nil using the specified size
        /// </summary>
        /// <param name="size">The size</param>
        /// <returns>The byte</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern byte igIsRectVisible_Nil(Vector2F size);

        /// <summary>
        ///     Igs the is rect visible vec 2 using the specified rect min
        /// </summary>
        /// <param name="rectMin">The rect min</param>
        /// <param name="rectMax">The rect max</param>
        /// <returns>The byte</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern byte igIsRectVisible_Vec2(Vector2F rectMin, Vector2F rectMax);

        /// <summary>
        ///     Igs the is window appearing
        /// </summary>
        /// <returns>The byte</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern byte igIsWindowAppearing();

        /// <summary>
        ///     Igs the is window collapsed
        /// </summary>
        /// <returns>The byte</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern byte igIsWindowCollapsed();

        /// <summary>
        ///     Igs the is window docked
        /// </summary>
        /// <returns>The byte</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern byte igIsWindowDocked();

        /// <summary>
        ///     Igs the is window focused using the specified flags
        /// </summary>
        /// <param name="flag">The flags</param>
        /// <returns>The byte</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern byte igIsWindowFocused(ImGuiFocusedFlag flag);

        /// <summary>
        ///     Igs the is window hovered using the specified flags
        /// </summary>
        /// <param name="flag">The flags</param>
        /// <returns>The byte</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern byte igIsWindowHovered(ImGuiHoveredFlag flag);

        /// <summary>
        ///     Igs the label text using the specified label
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="fmt">The fmt</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void igLabelText(byte* label, byte* fmt);

        /// <summary>
        ///     Igs the list box str arr using the specified label
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="currentItem">The current item</param>
        /// <param name="items">The items</param>
        /// <param name="itemsCount">The items count</param>
        /// <param name="heightInItems">The height in items</param>
        /// <returns>The byte</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern byte igListBox_Str_arr(byte* label, int* currentItem, byte** items, int itemsCount, int heightInItems);

        /// <summary>
        ///     Igs the load ini settings from disk using the specified ini filename
        /// </summary>
        /// <param name="iniFilename">The ini filename</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void igLoadIniSettingsFromDisk(byte* iniFilename);

        /// <summary>
        ///     Igs the load ini settings from memory using the specified ini data
        /// </summary>
        /// <param name="iniData">The ini data</param>
        /// <param name="iniSize">The ini size</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void igLoadIniSettingsFromMemory(byte* iniData, uint iniSize);

        /// <summary>
        ///     Igs the log buttons
        /// </summary>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void igLogButtons();

        /// <summary>
        ///     Igs the log finish
        /// </summary>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void igLogFinish();

        /// <summary>
        ///     Igs the log text using the specified fmt
        /// </summary>
        /// <param name="fmt">The fmt</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void igLogText(byte* fmt);

        /// <summary>
        ///     Igs the log to clipboard using the specified auto open depth
        /// </summary>
        /// <param name="autoOpenDepth">The auto open depth</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void igLogToClipboard(int autoOpenDepth);

        /// <summary>
        ///     Igs the log to file using the specified auto open depth
        /// </summary>
        /// <param name="autoOpenDepth">The auto open depth</param>
        /// <param name="filename">The filename</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void igLogToFile(int autoOpenDepth, byte* filename);

        /// <summary>
        ///     Igs the log to tty using the specified auto open depth
        /// </summary>
        /// <param name="autoOpenDepth">The auto open depth</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void igLogToTTY(int autoOpenDepth);

        /// <summary>
        ///     Igs the mem alloc using the specified size
        /// </summary>
        /// <param name="size">The size</param>
        /// <returns>The void</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void* igMemAlloc(uint size);

        /// <summary>
        ///     Igs the mem free using the specified ptr
        /// </summary>
        /// <param name="ptr">The ptr</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void igMemFree(void* ptr);

        /// <summary>
        ///     Igs the menu item bool using the specified label
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="shortcut">The shortcut</param>
        /// <param name="selected">The selected</param>
        /// <param name="enabled">The enabled</param>
        /// <returns>The byte</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern byte igMenuItem_Bool(byte* label, byte* shortcut, byte selected, byte enabled);

        /// <summary>
        ///     Igs the menu item bool ptr using the specified label
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="shortcut">The shortcut</param>
        /// <param name="pSelected">The selected</param>
        /// <param name="enabled">The enabled</param>
        /// <returns>The byte</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern byte igMenuItem_BoolPtr(byte* label, byte* shortcut, byte* pSelected, byte enabled);

        /// <summary>
        ///     Igs the new frame
        /// </summary>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void igNewFrame();

        /// <summary>
        ///     Igs the new line
        /// </summary>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void igNewLine();

        /// <summary>
        ///     Igs the next column
        /// </summary>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void igNextColumn();

        /// <summary>
        ///     Igs the open popup str using the specified str id
        /// </summary>
        /// <param name="strId">The str id</param>
        /// <param name="popupFlag">The popup flags</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void igOpenPopup_Str(byte* strId, ImGuiPopupFlag popupFlag);

        /// <summary>
        ///     Igs the open popup id using the specified id
        /// </summary>
        /// <param name="id">The id</param>
        /// <param name="popupFlag">The popup flags</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void igOpenPopup_ID(uint id, ImGuiPopupFlag popupFlag);

        /// <summary>
        ///     Igs the open popup on item click using the specified str id
        /// </summary>
        /// <param name="strId">The str id</param>
        /// <param name="popupFlag">The popup flags</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void igOpenPopupOnItemClick(byte* strId, ImGuiPopupFlag popupFlag);

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
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void igPlotHistogram_FloatPtr(byte* label, float* values, int valuesCount, int valuesOffset, byte* overlayText, float scaleMin, float scaleMax, Vector2F graphSize, int stride);

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
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void igPlotLines_FloatPtr(byte* label, float* values, int valuesCount, int valuesOffset, byte* overlayText, float scaleMin, float scaleMax, Vector2F graphSize, int stride);

        /// <summary>
        ///     Igs the pop button repeat
        /// </summary>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void igPopButtonRepeat();

        /// <summary>
        ///     Igs the pop clip rect
        /// </summary>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void igPopClipRect();

        /// <summary>
        ///     Igs the pop font
        /// </summary>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void igPopFont();

        /// <summary>
        ///     Igs the pop id
        /// </summary>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void igPopID();

        /// <summary>
        ///     Igs the pop item width
        /// </summary>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void igPopItemWidth();

        /// <summary>
        ///     Igs the pop style color using the specified count
        /// </summary>
        /// <param name="count">The count</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void igPopStyleColor(int count);

        /// <summary>
        ///     Igs the pop style var using the specified count
        /// </summary>
        /// <param name="count">The count</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void igPopStyleVar(int count);

        /// <summary>
        ///     Igs the pop tab stop
        /// </summary>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void igPopTabStop();

        /// <summary>
        ///     Igs the pop text wrap pos
        /// </summary>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void igPopTextWrapPos();

        /// <summary>
        ///     Igs the progress bar using the specified fraction
        /// </summary>
        /// <param name="fraction">The fraction</param>
        /// <param name="sizeArg">The size arg</param>
        /// <param name="overlay">The overlay</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void igProgressBar(float fraction, Vector2F sizeArg, byte* overlay);

        /// <summary>
        ///     Igs the push button repeat using the specified repeat
        /// </summary>
        /// <param name="repeat">The repeat</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void igPushButtonRepeat(byte repeat);

        /// <summary>
        ///     Igs the push clip rect using the specified clip rect min
        /// </summary>
        /// <param name="clipRectMin">The clip rect min</param>
        /// <param name="clipRectMax">The clip rect max</param>
        /// <param name="intersectWithCurrentClipRect">The intersect with current clip rect</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void igPushClipRect(Vector2F clipRectMin, Vector2F clipRectMax, byte intersectWithCurrentClipRect);

        /// <summary>
        ///     Igs the push font using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void igPushFont(ImFont* font);

        /// <summary>
        ///     Igs the push id str using the specified str id
        /// </summary>
        /// <param name="strId">The str id</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void igPushID_Str(byte* strId);

        /// <summary>
        ///     Igs the push id str str using the specified str id begin
        /// </summary>
        /// <param name="strIdBegin">The str id begin</param>
        /// <param name="strIdEnd">The str id end</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void igPushID_StrStr(byte* strIdBegin, byte* strIdEnd);

        /// <summary>
        ///     Igs the push id ptr using the specified ptr id
        /// </summary>
        /// <param name="ptrId">The ptr id</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void igPushID_Ptr(void* ptrId);

        /// <summary>
        ///     Igs the push id int using the specified int id
        /// </summary>
        /// <param name="intId">The int id</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void igPushID_Int(int intId);

        /// <summary>
        ///     Igs the push item width using the specified item width
        /// </summary>
        /// <param name="itemWidth">The item width</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void igPushItemWidth(float itemWidth);

        /// <summary>
        ///     Igs the push style color u 32 using the specified idx
        /// </summary>
        /// <param name="idx">The idx</param>
        /// <param name="col">The col</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void igPushStyleColor_U32(ImGuiCol idx, uint col);

        /// <summary>
        ///     Igs the push style color vec 4 using the specified idx
        /// </summary>
        /// <param name="idx">The idx</param>
        /// <param name="col">The col</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void igPushStyleColor_Vec4(ImGuiCol idx, Vector4F col);

        /// <summary>
        ///     Igs the push style var float using the specified idx
        /// </summary>
        /// <param name="idx">The idx</param>
        /// <param name="val">The val</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void igPushStyleVar_Float(ImGuiStyleVar idx, float val);

        /// <summary>
        ///     Igs the push style var vec 2 using the specified idx
        /// </summary>
        /// <param name="idx">The idx</param>
        /// <param name="val">The val</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void igPushStyleVar_Vec2(ImGuiStyleVar idx, Vector2F val);

        /// <summary>
        ///     Igs the push tab stop using the specified tab stop
        /// </summary>
        /// <param name="tabStop">The tab stop</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void igPushTabStop(byte tabStop);

        /// <summary>
        ///     Igs the push text wrap pos using the specified wrap local pos x
        /// </summary>
        /// <param name="wrapLocalPosX">The wrap local pos</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void igPushTextWrapPos(float wrapLocalPosX);

        /// <summary>
        ///     Igs the radio button bool using the specified label
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="active">The active</param>
        /// <returns>The byte</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern byte igRadioButton_Bool(byte* label, byte active);

        /// <summary>
        ///     Igs the radio button int ptr using the specified label
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="v">The </param>
        /// <param name="vButton">The button</param>
        /// <returns>The byte</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern byte igRadioButton_IntPtr(byte* label, int* v, int vButton);

        /// <summary>
        ///     Igs the render
        /// </summary>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void igRender();

        /// <summary>
        ///     Igs the render platform windows default using the specified platform render arg
        /// </summary>
        /// <param name="platformRenderArg">The platform render arg</param>
        /// <param name="rendererRenderArg">The renderer render arg</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void igRenderPlatformWindowsDefault(void* platformRenderArg, void* rendererRenderArg);

        /// <summary>
        ///     Igs the reset mouse drag delta using the specified button
        /// </summary>
        /// <param name="button">The button</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void igResetMouseDragDelta(ImGuiMouseButton button);

        /// <summary>
        ///     Igs the same line using the specified offset from start x
        /// </summary>
        /// <param name="offsetFromStartX">The offset from start</param>
        /// <param name="spacing">The spacing</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void igSameLine(float offsetFromStartX, float spacing);

        /// <summary>
        ///     Igs the save ini settings to disk using the specified ini filename
        /// </summary>
        /// <param name="iniFilename">The ini filename</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void igSaveIniSettingsToDisk(byte* iniFilename);

        /// <summary>
        ///     Igs the save ini settings to memory using the specified out ini size
        /// </summary>
        /// <param name="outIniSize">The out ini size</param>
        /// <returns>The byte</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern byte* igSaveIniSettingsToMemory(uint* outIniSize);

        /// <summary>
        ///     Igs the selectable bool using the specified label
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="selected">The selected</param>
        /// <param name="flag">The flags</param>
        /// <param name="size">The size</param>
        /// <returns>The byte</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern byte igSelectable_Bool(byte* label, byte selected, ImGuiSelectableFlag flag, Vector2F size);

        /// <summary>
        ///     Igs the selectable bool ptr using the specified label
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="pSelected">The selected</param>
        /// <param name="flag">The flags</param>
        /// <param name="size">The size</param>
        /// <returns>The byte</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern byte igSelectable_BoolPtr(byte* label, byte* pSelected, ImGuiSelectableFlag flag, Vector2F size);

        /// <summary>
        ///     Igs the separator
        /// </summary>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void igSeparator();

        /// <summary>
        ///     Igs the separator text using the specified label
        /// </summary>
        /// <param name="label">The label</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void igSeparatorText(byte* label);

        /// <summary>
        ///     Igs the set allocator functions using the specified alloc func
        /// </summary>
        /// <param name="allocFunc">The alloc func</param>
        /// <param name="freeFunc">The free func</param>
        /// <param name="userData">The user data</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void igSetAllocatorFunctions(IntPtr allocFunc, IntPtr freeFunc, void* userData);

        /// <summary>
        ///     Igs the set clipboard text using the specified text
        /// </summary>
        /// <param name="text">The text</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void igSetClipboardText(byte* text);

        /// <summary>
        ///     Igs the set color edit options using the specified flags
        /// </summary>
        /// <param name="flag">The flags</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void igSetColorEditOptions(ImGuiColorEditFlag flag);

        /// <summary>
        ///     Igs the set column offset using the specified column index
        /// </summary>
        /// <param name="columnIndex">The column index</param>
        /// <param name="offsetX">The offset</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void igSetColumnOffset(int columnIndex, float offsetX);

        /// <summary>
        ///     Igs the set column width using the specified column index
        /// </summary>
        /// <param name="columnIndex">The column index</param>
        /// <param name="width">The width</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void igSetColumnWidth(int columnIndex, float width);

        /// <summary>
        ///     Igs the set current context using the specified ctx
        /// </summary>
        /// <param name="ctx">The ctx</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void igSetCurrentContext(IntPtr ctx);

        /// <summary>
        ///     Igs the set cursor pos using the specified local pos
        /// </summary>
        /// <param name="localPos">The local pos</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void igSetCursorPos(Vector2F localPos);

        /// <summary>
        ///     Igs the set cursor pos x using the specified local x
        /// </summary>
        /// <param name="localX">The local</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void igSetCursorPosX(float localX);

        /// <summary>
        ///     Igs the set cursor pos y using the specified local y
        /// </summary>
        /// <param name="localY">The local</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void igSetCursorPosY(float localY);

        /// <summary>
        ///     Igs the set cursor screen pos using the specified pos
        /// </summary>
        /// <param name="pos">The pos</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void igSetCursorScreenPos(Vector2F pos);

        /// <summary>
        ///     Igs the set drag drop payload using the specified type
        /// </summary>
        /// <param name="type">The type</param>
        /// <param name="data">The data</param>
        /// <param name="sz">The sz</param>
        /// <param name="cond">The cond</param>
        /// <returns>The byte</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern byte igSetDragDropPayload(byte* type, void* data, uint sz, ImGuiCond cond);

        /// <summary>
        ///     Igs the set item allow overlap
        /// </summary>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void igSetItemAllowOverlap();

        /// <summary>
        ///     Igs the set item default focus
        /// </summary>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void igSetItemDefaultFocus();

        /// <summary>
        ///     Igs the set keyboard focus here using the specified offset
        /// </summary>
        /// <param name="offset">The offset</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void igSetKeyboardFocusHere(int offset);

        /// <summary>
        ///     Igs the set mouse cursor using the specified cursor type
        /// </summary>
        /// <param name="cursorType">The cursor type</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void igSetMouseCursor(ImGuiMouseCursor cursorType);

        /// <summary>
        ///     Igs the set next frame want capture keyboard using the specified want capture keyboard
        /// </summary>
        /// <param name="wantCaptureKeyboard">The want capture keyboard</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void igSetNextFrameWantCaptureKeyboard(byte wantCaptureKeyboard);

        /// <summary>
        ///     Igs the set next frame want capture mouse using the specified want capture mouse
        /// </summary>
        /// <param name="wantCaptureMouse">The want capture mouse</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void igSetNextFrameWantCaptureMouse(byte wantCaptureMouse);

        /// <summary>
        ///     Igs the set next item open using the specified is open
        /// </summary>
        /// <param name="isOpen">The is open</param>
        /// <param name="cond">The cond</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void igSetNextItemOpen(byte isOpen, ImGuiCond cond);

        /// <summary>
        ///     Igs the set next item width using the specified item width
        /// </summary>
        /// <param name="itemWidth">The item width</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void igSetNextItemWidth(float itemWidth);

        /// <summary>
        ///     Igs the set next window bg alpha using the specified alpha
        /// </summary>
        /// <param name="alpha">The alpha</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void igSetNextWindowBgAlpha(float alpha);

        /// <summary>
        ///     Igs the set next window using the specified window class
        /// </summary>
        /// <param name="windowClass">The window class</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void igSetNextWindowClass(ImGuiWindowClass* windowClass);

        /// <summary>
        ///     Igs the set next window collapsed using the specified collapsed
        /// </summary>
        /// <param name="collapsed">The collapsed</param>
        /// <param name="cond">The cond</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void igSetNextWindowCollapsed(byte collapsed, ImGuiCond cond);

        /// <summary>
        ///     Igs the set next window content size using the specified size
        /// </summary>
        /// <param name="size">The size</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void igSetNextWindowContentSize(Vector2F size);

        /// <summary>
        ///     Igs the set next window dock id using the specified dock id
        /// </summary>
        /// <param name="dockId">The dock id</param>
        /// <param name="cond">The cond</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void igSetNextWindowDockID(uint dockId, ImGuiCond cond);

        /// <summary>
        ///     Igs the set next window focus
        /// </summary>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void igSetNextWindowFocus();

        /// <summary>
        ///     Igs the set next window pos using the specified pos
        /// </summary>
        /// <param name="pos">The pos</param>
        /// <param name="cond">The cond</param>
        /// <param name="pivot">The pivot</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void igSetNextWindowPos(Vector2F pos, ImGuiCond cond, Vector2F pivot);

        /// <summary>
        ///     Igs the set next window scroll using the specified scroll
        /// </summary>
        /// <param name="scroll">The scroll</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void igSetNextWindowScroll(Vector2F scroll);

        /// <summary>
        ///     Igs the set next window size using the specified size
        /// </summary>
        /// <param name="size">The size</param>
        /// <param name="cond">The cond</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void igSetNextWindowSize(Vector2F size, ImGuiCond cond);

        /// <summary>
        ///     Igs the set next window size constraints using the specified size min
        /// </summary>
        /// <param name="sizeMin">The size min</param>
        /// <param name="sizeMax">The size max</param>
        /// <param name="customCallback">The custom callback</param>
        /// <param name="customCallbackData">The custom callback data</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void igSetNextWindowSizeConstraints(Vector2F sizeMin, Vector2F sizeMax, ImGuiSizeCallback customCallback, void* customCallbackData);

        /// <summary>
        ///     Igs the set next window viewport using the specified viewport id
        /// </summary>
        /// <param name="viewportId">The viewport id</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void igSetNextWindowViewport(uint viewportId);

        /// <summary>
        ///     Igs the set scroll from pos x float using the specified local x
        /// </summary>
        /// <param name="localX">The local</param>
        /// <param name="centerXRatio">The center ratio</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void igSetScrollFromPosX_Float(float localX, float centerXRatio);

        /// <summary>
        ///     Igs the set scroll from pos y float using the specified local y
        /// </summary>
        /// <param name="localY">The local</param>
        /// <param name="centerYRatio">The center ratio</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void igSetScrollFromPosY_Float(float localY, float centerYRatio);

        /// <summary>
        ///     Igs the set scroll here x using the specified center x ratio
        /// </summary>
        /// <param name="centerXRatio">The center ratio</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void igSetScrollHereX(float centerXRatio);

        /// <summary>
        ///     Igs the set scroll here y using the specified center y ratio
        /// </summary>
        /// <param name="centerYRatio">The center ratio</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void igSetScrollHereY(float centerYRatio);

        /// <summary>
        ///     Igs the set scroll x float using the specified scroll x
        /// </summary>
        /// <param name="scrollX">The scroll</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void igSetScrollX_Float(float scrollX);

        /// <summary>
        ///     Igs the set scroll y float using the specified scroll y
        /// </summary>
        /// <param name="scrollY">The scroll</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void igSetScrollY_Float(float scrollY);

        /// <summary>
        ///     Igs the set state storage using the specified storage
        /// </summary>
        /// <param name="storage">The storage</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void igSetStateStorage(ImGuiStorage* storage);

        /// <summary>
        ///     Igs the set tab item closed using the specified tab or docked window label
        /// </summary>
        /// <param name="tabOrDockedWindowLabel">The tab or docked window label</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void igSetTabItemClosed(byte* tabOrDockedWindowLabel);

        /// <summary>
        ///     Igs the set tooltip using the specified fmt
        /// </summary>
        /// <param name="fmt">The fmt</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void igSetTooltip(byte* fmt);

        /// <summary>
        ///     Igs the set window collapsed bool using the specified collapsed
        /// </summary>
        /// <param name="collapsed">The collapsed</param>
        /// <param name="cond">The cond</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void igSetWindowCollapsed_Bool(byte collapsed, ImGuiCond cond);

        /// <summary>
        ///     Igs the set window collapsed str using the specified name
        /// </summary>
        /// <param name="name">The name</param>
        /// <param name="collapsed">The collapsed</param>
        /// <param name="cond">The cond</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void igSetWindowCollapsed_Str(byte* name, byte collapsed, ImGuiCond cond);

        /// <summary>
        ///     Igs the set window focus nil
        /// </summary>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void igSetWindowFocus_Nil();

        /// <summary>
        ///     Igs the set window focus str using the specified name
        /// </summary>
        /// <param name="name">The name</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void igSetWindowFocus_Str(byte* name);

        /// <summary>
        ///     Igs the set window font scale using the specified scale
        /// </summary>
        /// <param name="scale">The scale</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void igSetWindowFontScale(float scale);

        /// <summary>
        ///     Igs the set window pos vec 2 using the specified pos
        /// </summary>
        /// <param name="pos">The pos</param>
        /// <param name="cond">The cond</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void igSetWindowPos_Vec2(Vector2F pos, ImGuiCond cond);

        /// <summary>
        ///     Igs the set window pos str using the specified name
        /// </summary>
        /// <param name="name">The name</param>
        /// <param name="pos">The pos</param>
        /// <param name="cond">The cond</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void igSetWindowPos_Str(byte* name, Vector2F pos, ImGuiCond cond);

        /// <summary>
        ///     Igs the set window size vec 2 using the specified size
        /// </summary>
        /// <param name="size">The size</param>
        /// <param name="cond">The cond</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void igSetWindowSize_Vec2(Vector2F size, ImGuiCond cond);

        /// <summary>
        ///     Igs the set window size str using the specified name
        /// </summary>
        /// <param name="name">The name</param>
        /// <param name="size">The size</param>
        /// <param name="cond">The cond</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void igSetWindowSize_Str(byte* name, Vector2F size, ImGuiCond cond);

        /// <summary>
        ///     Igs the show about window using the specified p open
        /// </summary>
        /// <param name="pOpen">The open</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void igShowAboutWindow(byte* pOpen);

        /// <summary>
        ///     Igs the show debug log window using the specified p open
        /// </summary>
        /// <param name="pOpen">The open</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void igShowDebugLogWindow(byte* pOpen);

        /// <summary>
        ///     Igs the show demo window using the specified p open
        /// </summary>
        /// <param name="pOpen">The open</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void igShowDemoWindow(byte* pOpen);

        /// <summary>
        ///     Igs the show font selector using the specified label
        /// </summary>
        /// <param name="label">The label</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void igShowFontSelector(byte* label);

        /// <summary>
        ///     Igs the show metrics window using the specified p open
        /// </summary>
        /// <param name="pOpen">The open</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void igShowMetricsWindow(byte* pOpen);

        /// <summary>
        ///     Igs the show stack tool window using the specified p open
        /// </summary>
        /// <param name="pOpen">The open</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void igShowStackToolWindow(byte* pOpen);

        /// <summary>
        /// </summary>
        /// <param name="ref"></param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void igShowStyleEditor(ImGuiStyle* @ref);

        /// <summary>
        ///     Igs the show style selector using the specified label
        /// </summary>
        /// <param name="label">The label</param>
        /// <returns>The byte</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern byte igShowStyleSelector(byte* label);

        /// <summary>
        ///     Igs the show user guide
        /// </summary>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void igShowUserGuide();

        /// <summary>
        ///     Igs the slider angle using the specified label
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="vRad">The rad</param>
        /// <param name="vDegreesMin">The degrees min</param>
        /// <param name="vDegreesMax">The degrees max</param>
        /// <param name="format">The format</param>
        /// <param name="flag">The flags</param>
        /// <returns>The byte</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern byte igSliderAngle(byte* label, float* vRad, float vDegreesMin, float vDegreesMax, byte* format, ImGuiSliderFlag flag);

        /// <summary>
        ///     Igs the slider float using the specified label
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="v">The </param>
        /// <param name="vMin">The min</param>
        /// <param name="vMax">The max</param>
        /// <param name="format">The format</param>
        /// <param name="flag">The flags</param>
        /// <returns>The byte</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern byte igSliderFloat(byte* label, float* v, float vMin, float vMax, byte* format, ImGuiSliderFlag flag);

        /// <summary>
        ///     Igs the slider float 2 using the specified label
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="v">The </param>
        /// <param name="vMin">The min</param>
        /// <param name="vMax">The max</param>
        /// <param name="format">The format</param>
        /// <param name="flag">The flags</param>
        /// <returns>The byte</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern byte igSliderFloat2(byte* label, Vector2F* v, float vMin, float vMax, byte* format, ImGuiSliderFlag flag);

        /// <summary>
        ///     Igs the slider float 3 using the specified label
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="v">The </param>
        /// <param name="vMin">The min</param>
        /// <param name="vMax">The max</param>
        /// <param name="format">The format</param>
        /// <param name="flag">The flags</param>
        /// <returns>The byte</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern byte igSliderFloat3(byte* label, Vector3F* v, float vMin, float vMax, byte* format, ImGuiSliderFlag flag);

        /// <summary>
        ///     Igs the slider float 4 using the specified label
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="v">The </param>
        /// <param name="vMin">The min</param>
        /// <param name="vMax">The max</param>
        /// <param name="format">The format</param>
        /// <param name="flag">The flags</param>
        /// <returns>The byte</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern byte igSliderFloat4(byte* label, Vector4F* v, float vMin, float vMax, byte* format, ImGuiSliderFlag flag);

        /// <summary>
        ///     Igs the slider int using the specified label
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="v">The </param>
        /// <param name="vMin">The min</param>
        /// <param name="vMax">The max</param>
        /// <param name="format">The format</param>
        /// <param name="flag">The flags</param>
        /// <returns>The byte</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern byte igSliderInt(byte* label, int* v, int vMin, int vMax, byte* format, ImGuiSliderFlag flag);

        /// <summary>
        ///     Igs the slider int 2 using the specified label
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="v">The </param>
        /// <param name="vMin">The min</param>
        /// <param name="vMax">The max</param>
        /// <param name="format">The format</param>
        /// <param name="flag">The flags</param>
        /// <returns>The byte</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern byte igSliderInt2(byte* label, int* v, int vMin, int vMax, byte* format, ImGuiSliderFlag flag);

        /// <summary>
        ///     Igs the slider int 3 using the specified label
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="v">The </param>
        /// <param name="vMin">The min</param>
        /// <param name="vMax">The max</param>
        /// <param name="format">The format</param>
        /// <param name="flag">The flags</param>
        /// <returns>The byte</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern byte igSliderInt3(byte* label, int* v, int vMin, int vMax, byte* format, ImGuiSliderFlag flag);

        /// <summary>
        ///     Igs the slider int 4 using the specified label
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="v">The </param>
        /// <param name="vMin">The min</param>
        /// <param name="vMax">The max</param>
        /// <param name="format">The format</param>
        /// <param name="flag">The flags</param>
        /// <returns>The byte</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern byte igSliderInt4(byte* label, int* v, int vMin, int vMax, byte* format, ImGuiSliderFlag flag);

        /// <summary>
        ///     Igs the slider scalar using the specified label
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="dataType">The data type</param>
        /// <param name="pData">The data</param>
        /// <param name="pMin">The min</param>
        /// <param name="pMax">The max</param>
        /// <param name="format">The format</param>
        /// <param name="flag">The flags</param>
        /// <returns>The byte</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern byte igSliderScalar(byte* label, ImGuiDataType dataType, void* pData, void* pMin, void* pMax, byte* format, ImGuiSliderFlag flag);

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
        /// <param name="flag">The flags</param>
        /// <returns>The byte</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern byte igSliderScalarN(byte* label, ImGuiDataType dataType, void* pData, int components, void* pMin, void* pMax, byte* format, ImGuiSliderFlag flag);

        /// <summary>
        ///     Igs the small button using the specified label
        /// </summary>
        /// <param name="label">The label</param>
        /// <returns>The byte</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern byte igSmallButton(byte* label);

        /// <summary>
        ///     Igs the spacing
        /// </summary>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void igSpacing();

        /// <summary>
        ///     Igs the style colors classic using the specified dst
        /// </summary>
        /// <param name="dst">The dst</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void igStyleColorsClassic(ImGuiStyle* dst);

        /// <summary>
        ///     Igs the style colors dark using the specified dst
        /// </summary>
        /// <param name="dst">The dst</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void igStyleColorsDark(ImGuiStyle* dst);

        /// <summary>
        ///     Igs the style colors light using the specified dst
        /// </summary>
        /// <param name="dst">The dst</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void igStyleColorsLight(ImGuiStyle* dst);

        /// <summary>
        ///     Igs the tab item button using the specified label
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="flag">The flags</param>
        /// <returns>The byte</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern byte igTabItemButton(byte* label, ImGuiTabItemFlag flag);

        /// <summary>
        ///     Igs the table get column count
        /// </summary>
        /// <returns>The int</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int igTableGetColumnCount();

        /// <summary>
        ///     Igs the table get column flags using the specified column n
        /// </summary>
        /// <param name="columnN">The column</param>
        /// <returns>The im gui table column flags</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern ImGuiTableColumnFlag igTableGetColumnFlags(int columnN);

        /// <summary>
        ///     Igs the table get column index
        /// </summary>
        /// <returns>The int</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int igTableGetColumnIndex();

        /// <summary>
        ///     Igs the table get column name int using the specified column n
        /// </summary>
        /// <param name="columnN">The column</param>
        /// <returns>The byte</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern byte* igTableGetColumnName_Int(int columnN);

        /// <summary>
        ///     Igs the table get row index
        /// </summary>
        /// <returns>The int</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int igTableGetRowIndex();

        /// <summary>
        ///     Igs the table get sort specs
        /// </summary>
        /// <returns>The im gui table sort specs</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern ImGuiTableSortSpecs* igTableGetSortSpecs();

        /// <summary>
        ///     Igs the table header using the specified label
        /// </summary>
        /// <param name="label">The label</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void igTableHeader(byte* label);

        /// <summary>
        ///     Igs the table headers row
        /// </summary>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void igTableHeadersRow();

        /// <summary>
        ///     Igs the table next column
        /// </summary>
        /// <returns>The byte</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern byte igTableNextColumn();

        /// <summary>
        ///     Igs the table next row using the specified row flags
        /// </summary>
        /// <param name="rowFlag">The row flags</param>
        /// <param name="minRowHeight">The min row height</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void igTableNextRow(ImGuiTableRowFlag rowFlag, float minRowHeight);

        /// <summary>
        ///     Igs the table set bg color using the specified target
        /// </summary>
        /// <param name="target">The target</param>
        /// <param name="color">The color</param>
        /// <param name="columnN">The column</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void igTableSetBgColor(ImGuiTableBgTarget target, uint color, int columnN);

        /// <summary>
        ///     Igs the table set column enabled using the specified column n
        /// </summary>
        /// <param name="columnN">The column</param>
        /// <param name="v">The </param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void igTableSetColumnEnabled(int columnN, byte v);

        /// <summary>
        ///     Igs the table set column index using the specified column n
        /// </summary>
        /// <param name="columnN">The column</param>
        /// <returns>The byte</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern byte igTableSetColumnIndex(int columnN);

        /// <summary>
        ///     Igs the table setup column using the specified label
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="flag">The flags</param>
        /// <param name="initWidthOrWeight">The init width or weight</param>
        /// <param name="userId">The user id</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void igTableSetupColumn(byte* label, ImGuiTableColumnFlag flag, float initWidthOrWeight, uint userId);

        /// <summary>
        ///     Igs the table setup scroll freeze using the specified cols
        /// </summary>
        /// <param name="cols">The cols</param>
        /// <param name="rows">The rows</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void igTableSetupScrollFreeze(int cols, int rows);

        /// <summary>
        ///     Igs the text using the specified fmt
        /// </summary>
        /// <param name="fmt">The fmt</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void igText(byte* fmt);

        /// <summary>
        ///     Igs the text colored using the specified col
        /// </summary>
        /// <param name="col">The col</param>
        /// <param name="fmt">The fmt</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void igTextColored(Vector4F col, byte* fmt);

        /// <summary>
        ///     Igs the text disabled using the specified fmt
        /// </summary>
        /// <param name="fmt">The fmt</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void igTextDisabled(byte* fmt);

        /// <summary>
        ///     Igs the text unformatted using the specified text
        /// </summary>
        /// <param name="text">The text</param>
        /// <param name="textEnd">The text end</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void igTextUnformatted(byte* text, byte* textEnd);

        /// <summary>
        ///     Igs the text wrapped using the specified fmt
        /// </summary>
        /// <param name="fmt">The fmt</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void igTextWrapped(byte* fmt);

        /// <summary>
        ///     Igs the tree node str using the specified label
        /// </summary>
        /// <param name="label">The label</param>
        /// <returns>The byte</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern byte igTreeNode_Str(byte* label);

        /// <summary>
        ///     Igs the tree node str str using the specified str id
        /// </summary>
        /// <param name="strId">The str id</param>
        /// <param name="fmt">The fmt</param>
        /// <returns>The byte</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern byte igTreeNode_StrStr(byte* strId, byte* fmt);

        /// <summary>
        ///     Igs the tree node ptr using the specified ptr id
        /// </summary>
        /// <param name="ptrId">The ptr id</param>
        /// <param name="fmt">The fmt</param>
        /// <returns>The byte</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern byte igTreeNode_Ptr(void* ptrId, byte* fmt);

        /// <summary>
        ///     Igs the tree node ex str using the specified label
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="flag">The flags</param>
        /// <returns>The byte</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern byte igTreeNodeEx_Str(byte* label, ImGuiTreeNodeFlag flag);

        /// <summary>
        ///     Igs the tree node ex str str using the specified str id
        /// </summary>
        /// <param name="strId">The str id</param>
        /// <param name="flag">The flags</param>
        /// <param name="fmt">The fmt</param>
        /// <returns>The byte</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern byte igTreeNodeEx_StrStr(byte* strId, ImGuiTreeNodeFlag flag, byte* fmt);

        /// <summary>
        ///     Igs the tree node ex ptr using the specified ptr id
        /// </summary>
        /// <param name="ptrId">The ptr id</param>
        /// <param name="flag">The flags</param>
        /// <param name="fmt">The fmt</param>
        /// <returns>The byte</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern byte igTreeNodeEx_Ptr(void* ptrId, ImGuiTreeNodeFlag flag, byte* fmt);

        /// <summary>
        ///     Igs the tree pop
        /// </summary>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void igTreePop();

        /// <summary>
        ///     Igs the tree push str using the specified str id
        /// </summary>
        /// <param name="strId">The str id</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void igTreePush_Str(byte* strId);

        /// <summary>
        ///     Igs the tree push ptr using the specified ptr id
        /// </summary>
        /// <param name="ptrId">The ptr id</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void igTreePush_Ptr(void* ptrId);

        /// <summary>
        ///     Igs the unindent using the specified indent w
        /// </summary>
        /// <param name="indentW">The indent</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void igUnindent(float indentW);

        /// <summary>
        ///     Igs the update platform windows
        /// </summary>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void igUpdatePlatformWindows();

        /// <summary>
        ///     Igs the value bool using the specified prefix
        /// </summary>
        /// <param name="prefix">The prefix</param>
        /// <param name="b">The </param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void igValue_Bool(byte* prefix, byte b);

        /// <summary>
        ///     Igs the value int using the specified prefix
        /// </summary>
        /// <param name="prefix">The prefix</param>
        /// <param name="v">The </param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void igValue_Int(byte* prefix, int v);

        /// <summary>
        ///     Igs the value uint using the specified prefix
        /// </summary>
        /// <param name="prefix">The prefix</param>
        /// <param name="v">The </param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void igValue_Uint(byte* prefix, uint v);

        /// <summary>
        ///     Igs the value float using the specified prefix
        /// </summary>
        /// <param name="prefix">The prefix</param>
        /// <param name="v">The </param>
        /// <param name="floatFormat">The float format</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void igValue_Float(byte* prefix, float v, byte* floatFormat);

        /// <summary>
        ///     Igs the v slider float using the specified label
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="size">The size</param>
        /// <param name="v">The </param>
        /// <param name="vMin">The min</param>
        /// <param name="vMax">The max</param>
        /// <param name="format">The format</param>
        /// <param name="flag">The flags</param>
        /// <returns>The byte</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern byte igVSliderFloat(byte* label, Vector2F size, float* v, float vMin, float vMax, byte* format, ImGuiSliderFlag flag);

        /// <summary>
        ///     Igs the v slider int using the specified label
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="size">The size</param>
        /// <param name="v">The </param>
        /// <param name="vMin">The min</param>
        /// <param name="vMax">The max</param>
        /// <param name="format">The format</param>
        /// <param name="flag">The flags</param>
        /// <returns>The byte</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern byte igVSliderInt(byte* label, Vector2F size, int* v, int vMin, int vMax, byte* format, ImGuiSliderFlag flag);

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
        /// <param name="flag">The flags</param>
        /// <returns>The byte</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern byte igVSliderScalar(byte* label, Vector2F size, ImGuiDataType dataType, void* pData, void* pMin, void* pMax, byte* format, ImGuiSliderFlag flag);

        /// <summary>
        ///     Ims the color destroy using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ImColor_destroy(ImColor* self);

        /// <summary>
        ///     Ims the color hsv using the specified p out
        /// </summary>
        /// <param name="pOut">The out</param>
        /// <param name="h">The </param>
        /// <param name="s">The </param>
        /// <param name="v">The </param>
        /// <param name="a">The </param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ImColor_HSV(ImColor* pOut, float h, float s, float v, float a);

        /// <summary>
        ///     Ims the color im color nil
        /// </summary>
        /// <returns>The im color</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern ImColor* ImColor_ImColor_Nil();

        /// <summary>
        ///     Ims the color im color float using the specified r
        /// </summary>
        /// <param name="r">The </param>
        /// <param name="g">The </param>
        /// <param name="b">The </param>
        /// <param name="a">The </param>
        /// <returns>The im color</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern ImColor* ImColor_ImColor_Float(float r, float g, float b, float a);

        /// <summary>
        ///     Ims the color im color vec 4 using the specified col
        /// </summary>
        /// <param name="col">The col</param>
        /// <returns>The im color</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern ImColor* ImColor_ImColor_Vec4(Vector4F col);

        /// <summary>
        ///     Ims the color im color int using the specified r
        /// </summary>
        /// <param name="r">The </param>
        /// <param name="g">The </param>
        /// <param name="b">The </param>
        /// <param name="a">The </param>
        /// <returns>The im color</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern ImColor* ImColor_ImColor_Int(int r, int g, int b, int a);

        /// <summary>
        ///     Ims the color im color u 32 using the specified rgba
        /// </summary>
        /// <param name="rgba">The rgba</param>
        /// <returns>The im color</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern ImColor* ImColor_ImColor_U32(uint rgba);

        /// <summary>
        ///     Ims the color set hsv using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        /// <param name="h">The </param>
        /// <param name="s">The </param>
        /// <param name="v">The </param>
        /// <param name="a">The </param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ImColor_SetHSV(ImColor* self, float h, float s, float v, float a);

        /// <summary>
        ///     Ims the draw cmd destroy using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ImDrawCmd_destroy(ImDrawCmd* self);

        /// <summary>
        ///     Ims the draw cmd get tex id using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        /// <returns>The int ptr</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr ImDrawCmd_GetTexID(ImDrawCmd* self);

        /// <summary>
        ///     Ims the draw cmd im draw cmd
        /// </summary>
        /// <returns>The im draw cmd</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern ImDrawCmd* ImDrawCmd_ImDrawCmd();

        /// <summary>
        ///     Ims the draw data clear using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ImDrawData_Clear(ImDrawData* self);

        /// <summary>
        ///     Ims the draw data de index all buffers using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ImDrawData_DeIndexAllBuffers(ImDrawData* self);

        /// <summary>
        ///     Ims the draw data destroy using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ImDrawData_destroy(ImDrawData* self);

        /// <summary>
        ///     Ims the draw data im draw data
        /// </summary>
        /// <returns>The im draw data</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern ImDrawData* ImDrawData_ImDrawData();

        /// <summary>
        ///     Ims the draw data scale clip rects using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        /// <param name="fbScale">The fb scale</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ImDrawData_ScaleClipRects(ImDrawData* self, Vector2F fbScale);

        /// <summary>
        ///     Ims the draw list calc circle auto segment count using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        /// <param name="radius">The radius</param>
        /// <returns>The int</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int ImDrawList__CalcCircleAutoSegmentCount(ImDrawList* self, float radius);

        /// <summary>
        ///     Ims the draw list clear free memory using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ImDrawList__ClearFreeMemory(ImDrawList* self);

        /// <summary>
        ///     Ims the draw list on changed clip rect using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ImDrawList__OnChangedClipRect(ImDrawList* self);

        /// <summary>
        ///     Ims the draw list on changed texture id using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ImDrawList__OnChangedTextureID(ImDrawList* self);

        /// <summary>
        ///     Ims the draw list on changed vtx offset using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ImDrawList__OnChangedVtxOffset(ImDrawList* self);

        /// <summary>
        ///     Ims the draw list path arc to fast ex using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        /// <param name="center">The center</param>
        /// <param name="radius">The radius</param>
        /// <param name="aMinSample">The min sample</param>
        /// <param name="aMaxSample">The max sample</param>
        /// <param name="aStep">The step</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ImDrawList__PathArcToFastEx(ImDrawList* self, Vector2F center, float radius, int aMinSample, int aMaxSample, int aStep);

        /// <summary>
        ///     Ims the draw list path arc to n using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        /// <param name="center">The center</param>
        /// <param name="radius">The radius</param>
        /// <param name="aMin">The min</param>
        /// <param name="aMax">The max</param>
        /// <param name="numSegments">The num segments</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ImDrawList__PathArcToN(ImDrawList* self, Vector2F center, float radius, float aMin, float aMax, int numSegments);

        /// <summary>
        ///     Ims the draw list pop unused draw cmd using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ImDrawList__PopUnusedDrawCmd(ImDrawList* self);

        /// <summary>
        ///     Ims the draw list reset for new frame using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ImDrawList__ResetForNewFrame(ImDrawList* self);

        /// <summary>
        ///     Ims the draw list try merge draw cmds using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ImDrawList__TryMergeDrawCmds(ImDrawList* self);

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
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ImDrawList_AddBezierCubic(ImDrawList* self, Vector2F p1, Vector2F p2, Vector2F p3, Vector2F p4, uint col, float thickness, int numSegments);

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
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ImDrawList_AddBezierQuadratic(ImDrawList* self, Vector2F p1, Vector2F p2, Vector2F p3, uint col, float thickness, int numSegments);

        /// <summary>
        ///     Ims the draw list add callback using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        /// <param name="callback">The callback</param>
        /// <param name="callbackData">The callback data</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ImDrawList_AddCallback(ImDrawList* self, IntPtr callback, void* callbackData);

        /// <summary>
        ///     Ims the draw list add circle using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        /// <param name="center">The center</param>
        /// <param name="radius">The radius</param>
        /// <param name="col">The col</param>
        /// <param name="numSegments">The num segments</param>
        /// <param name="thickness">The thickness</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ImDrawList_AddCircle(ImDrawList* self, Vector2F center, float radius, uint col, int numSegments, float thickness);

        /// <summary>
        ///     Ims the draw list add circle filled using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        /// <param name="center">The center</param>
        /// <param name="radius">The radius</param>
        /// <param name="col">The col</param>
        /// <param name="numSegments">The num segments</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ImDrawList_AddCircleFilled(ImDrawList* self, Vector2F center, float radius, uint col, int numSegments);

        /// <summary>
        ///     Ims the draw list add convex poly filled using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        /// <param name="points">The points</param>
        /// <param name="numPoints">The num points</param>
        /// <param name="col">The col</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ImDrawList_AddConvexPolyFilled(ImDrawList* self, Vector2F* points, int numPoints, uint col);

        /// <summary>
        ///     Ims the draw list add draw cmd using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ImDrawList_AddDrawCmd(ImDrawList* self);

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
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ImDrawList_AddImage(ImDrawList* self, IntPtr userTextureId, Vector2F pMin, Vector2F pMax, Vector2F uvMin, Vector2F uvMax, uint col);

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
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ImDrawList_AddImageQuad(ImDrawList* self, IntPtr userTextureId, Vector2F p1, Vector2F p2, Vector2F p3, Vector2F p4, Vector2F uv1, Vector2F uv2, Vector2F uv3, Vector2F uv4, uint col);

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
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ImDrawList_AddImageRounded(ImDrawList* self, IntPtr userTextureId, Vector2F pMin, Vector2F pMax, Vector2F uvMin, Vector2F uvMax, uint col, float rounding, ImDrawFlag flags);

        /// <summary>
        ///     Ims the draw list add line using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        /// <param name="p1">The </param>
        /// <param name="p2">The </param>
        /// <param name="col">The col</param>
        /// <param name="thickness">The thickness</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ImDrawList_AddLine(ImDrawList* self, Vector2F p1, Vector2F p2, uint col, float thickness);

        /// <summary>
        ///     Ims the draw list add ngon using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        /// <param name="center">The center</param>
        /// <param name="radius">The radius</param>
        /// <param name="col">The col</param>
        /// <param name="numSegments">The num segments</param>
        /// <param name="thickness">The thickness</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ImDrawList_AddNgon(ImDrawList* self, Vector2F center, float radius, uint col, int numSegments, float thickness);

        /// <summary>
        ///     Ims the draw list add ngon filled using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        /// <param name="center">The center</param>
        /// <param name="radius">The radius</param>
        /// <param name="col">The col</param>
        /// <param name="numSegments">The num segments</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ImDrawList_AddNgonFilled(ImDrawList* self, Vector2F center, float radius, uint col, int numSegments);

        /// <summary>
        ///     Ims the draw list add polyline using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        /// <param name="points">The points</param>
        /// <param name="numPoints">The num points</param>
        /// <param name="col">The col</param>
        /// <param name="flags">The flags</param>
        /// <param name="thickness">The thickness</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ImDrawList_AddPolyline(ImDrawList* self, Vector2F* points, int numPoints, uint col, ImDrawFlag flags, float thickness);

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
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ImDrawList_AddQuad(ImDrawList* self, Vector2F p1, Vector2F p2, Vector2F p3, Vector2F p4, uint col, float thickness);

        /// <summary>
        ///     Ims the draw list add quad filled using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        /// <param name="p1">The </param>
        /// <param name="p2">The </param>
        /// <param name="p3">The </param>
        /// <param name="p4">The </param>
        /// <param name="col">The col</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ImDrawList_AddQuadFilled(ImDrawList* self, Vector2F p1, Vector2F p2, Vector2F p3, Vector2F p4, uint col);

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
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ImDrawList_AddRect(ImDrawList* self, Vector2F pMin, Vector2F pMax, uint col, float rounding, ImDrawFlag flags, float thickness);

        /// <summary>
        ///     Ims the draw list add rect filled using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        /// <param name="pMin">The min</param>
        /// <param name="pMax">The max</param>
        /// <param name="col">The col</param>
        /// <param name="rounding">The rounding</param>
        /// <param name="flags">The flags</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ImDrawList_AddRectFilled(ImDrawList* self, Vector2F pMin, Vector2F pMax, uint col, float rounding, ImDrawFlag flags);

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
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ImDrawList_AddRectFilledMultiColor(ImDrawList* self, Vector2F pMin, Vector2F pMax, uint colUprLeft, uint colUprRight, uint colBotRight, uint colBotLeft);

        /// <summary>
        ///     Ims the draw list add text vec 2 using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        /// <param name="pos">The pos</param>
        /// <param name="col">The col</param>
        /// <param name="textBegin">The text begin</param>
        /// <param name="textEnd">The text end</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ImDrawList_AddText_Vec2(ImDrawList* self, Vector2F pos, uint col, byte* textBegin, byte* textEnd);

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
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ImDrawList_AddText_FontPtr(ImDrawList* self, ImFont* font, float fontSize, Vector2F pos, uint col, byte* textBegin, byte* textEnd, float wrapWidth, Vector4F* cpuFineClipRect);

        /// <summary>
        ///     Ims the draw list add triangle using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        /// <param name="p1">The </param>
        /// <param name="p2">The </param>
        /// <param name="p3">The </param>
        /// <param name="col">The col</param>
        /// <param name="thickness">The thickness</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ImDrawList_AddTriangle(ImDrawList* self, Vector2F p1, Vector2F p2, Vector2F p3, uint col, float thickness);

        /// <summary>
        ///     Ims the draw list add triangle filled using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        /// <param name="p1">The </param>
        /// <param name="p2">The </param>
        /// <param name="p3">The </param>
        /// <param name="col">The col</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ImDrawList_AddTriangleFilled(ImDrawList* self, Vector2F p1, Vector2F p2, Vector2F p3, uint col);

        /// <summary>
        ///     Ims the draw list channels merge using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ImDrawList_ChannelsMerge(ImDrawList* self);

        /// <summary>
        ///     Ims the draw list channels set current using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        /// <param name="n">The </param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ImDrawList_ChannelsSetCurrent(ImDrawList* self, int n);

        /// <summary>
        ///     Ims the draw list channels split using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        /// <param name="count">The count</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ImDrawList_ChannelsSplit(ImDrawList* self, int count);

        /// <summary>
        ///     Ims the draw list clone output using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        /// <returns>The im draw list</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern ImDrawList* ImDrawList_CloneOutput(ImDrawList* self);

        /// <summary>
        ///     Ims the draw list destroy using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ImDrawList_destroy(ImDrawList* self);

        /// <summary>
        ///     Ims the draw list get clip rect max using the specified p out
        /// </summary>
        /// <param name="pOut">The out</param>
        /// <param name="self">The self</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ImDrawList_GetClipRectMax(Vector2F* pOut, ImDrawList* self);

        /// <summary>
        ///     Ims the draw list get clip rect min using the specified p out
        /// </summary>
        /// <param name="pOut">The out</param>
        /// <param name="self">The self</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ImDrawList_GetClipRectMin(Vector2F* pOut, ImDrawList* self);

        /// <summary>
        ///     Ims the draw list im draw list using the specified shared data
        /// </summary>
        /// <param name="sharedData">The shared data</param>
        /// <returns>The im draw list</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern ImDrawList* ImDrawList_ImDrawList(IntPtr sharedData);

        /// <summary>
        ///     Ims the draw list path arc to using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        /// <param name="center">The center</param>
        /// <param name="radius">The radius</param>
        /// <param name="aMin">The min</param>
        /// <param name="aMax">The max</param>
        /// <param name="numSegments">The num segments</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ImDrawList_PathArcTo(ImDrawList* self, Vector2F center, float radius, float aMin, float aMax, int numSegments);

        /// <summary>
        ///     Ims the draw list path arc to fast using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        /// <param name="center">The center</param>
        /// <param name="radius">The radius</param>
        /// <param name="aMinOf12">The min of 12</param>
        /// <param name="aMaxOf12">The max of 12</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ImDrawList_PathArcToFast(ImDrawList* self, Vector2F center, float radius, int aMinOf12, int aMaxOf12);

        /// <summary>
        ///     Ims the draw list path bezier cubic curve to using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        /// <param name="p2">The </param>
        /// <param name="p3">The </param>
        /// <param name="p4">The </param>
        /// <param name="numSegments">The num segments</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ImDrawList_PathBezierCubicCurveTo(ImDrawList* self, Vector2F p2, Vector2F p3, Vector2F p4, int numSegments);

        /// <summary>
        ///     Ims the draw list path bezier quadratic curve to using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        /// <param name="p2">The </param>
        /// <param name="p3">The </param>
        /// <param name="numSegments">The num segments</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ImDrawList_PathBezierQuadraticCurveTo(ImDrawList* self, Vector2F p2, Vector2F p3, int numSegments);

        /// <summary>
        ///     Ims the draw list path clear using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ImDrawList_PathClear(ImDrawList* self);

        /// <summary>
        ///     Ims the draw list path fill convex using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        /// <param name="col">The col</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ImDrawList_PathFillConvex(ImDrawList* self, uint col);

        /// <summary>
        ///     Ims the draw list path line to using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        /// <param name="pos">The pos</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ImDrawList_PathLineTo(ImDrawList* self, Vector2F pos);

        /// <summary>
        ///     Ims the draw list path line to merge duplicate using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        /// <param name="pos">The pos</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ImDrawList_PathLineToMergeDuplicate(ImDrawList* self, Vector2F pos);

        /// <summary>
        ///     Ims the draw list path rect using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        /// <param name="rectMin">The rect min</param>
        /// <param name="rectMax">The rect max</param>
        /// <param name="rounding">The rounding</param>
        /// <param name="flags">The flags</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ImDrawList_PathRect(ImDrawList* self, Vector2F rectMin, Vector2F rectMax, float rounding, ImDrawFlag flags);

        /// <summary>
        ///     Ims the draw list path stroke using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        /// <param name="col">The col</param>
        /// <param name="flags">The flags</param>
        /// <param name="thickness">The thickness</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ImDrawList_PathStroke(ImDrawList* self, uint col, ImDrawFlag flags, float thickness);

        /// <summary>
        ///     Ims the draw list pop clip rect using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ImDrawList_PopClipRect(ImDrawList* self);

        /// <summary>
        ///     Ims the draw list pop texture id using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ImDrawList_PopTextureID(ImDrawList* self);

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
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ImDrawList_PrimQuadUV(ImDrawList* self, Vector2F a, Vector2F b, Vector2F c, Vector2F d, Vector2F uvA, Vector2F uvB, Vector2F uvC, Vector2F uvD, uint col);

        /// <summary>
        ///     Ims the draw list prim rect using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        /// <param name="a">The </param>
        /// <param name="b">The </param>
        /// <param name="col">The col</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ImDrawList_PrimRect(ImDrawList* self, Vector2F a, Vector2F b, uint col);

        /// <summary>
        ///     Ims the draw list prim rect uv using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        /// <param name="a">The </param>
        /// <param name="b">The </param>
        /// <param name="uvA">The uv</param>
        /// <param name="uvB">The uv</param>
        /// <param name="col">The col</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ImDrawList_PrimRectUV(ImDrawList* self, Vector2F a, Vector2F b, Vector2F uvA, Vector2F uvB, uint col);

        /// <summary>
        ///     Ims the draw list prim reserve using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        /// <param name="idxCount">The idx count</param>
        /// <param name="vtxCount">The vtx count</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ImDrawList_PrimReserve(ImDrawList* self, int idxCount, int vtxCount);

        /// <summary>
        ///     Ims the draw list prim unreserve using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        /// <param name="idxCount">The idx count</param>
        /// <param name="vtxCount">The vtx count</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ImDrawList_PrimUnreserve(ImDrawList* self, int idxCount, int vtxCount);

        /// <summary>
        ///     Ims the draw list prim vtx using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        /// <param name="pos">The pos</param>
        /// <param name="uv">The uv</param>
        /// <param name="col">The col</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ImDrawList_PrimVtx(ImDrawList* self, Vector2F pos, Vector2F uv, uint col);

        /// <summary>
        ///     Ims the draw list prim write idx using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        /// <param name="idx">The idx</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ImDrawList_PrimWriteIdx(ImDrawList* self, ushort idx);

        /// <summary>
        ///     Ims the draw list prim write vtx using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        /// <param name="pos">The pos</param>
        /// <param name="uv">The uv</param>
        /// <param name="col">The col</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ImDrawList_PrimWriteVtx(ImDrawList* self, Vector2F pos, Vector2F uv, uint col);

        /// <summary>
        ///     Ims the draw list push clip rect using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        /// <param name="clipRectMin">The clip rect min</param>
        /// <param name="clipRectMax">The clip rect max</param>
        /// <param name="intersectWithCurrentClipRect">The intersect with current clip rect</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ImDrawList_PushClipRect(ImDrawList* self, Vector2F clipRectMin, Vector2F clipRectMax, byte intersectWithCurrentClipRect);

        /// <summary>
        ///     Ims the draw list push clip rect full screen using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ImDrawList_PushClipRectFullScreen(ImDrawList* self);

        /// <summary>
        ///     Ims the draw list push texture id using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        /// <param name="textureId">The texture id</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ImDrawList_PushTextureID(ImDrawList* self, IntPtr textureId);

        /// <summary>
        ///     Ims the draw list splitter clear using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ImDrawListSplitter_Clear(ImDrawListSplitter* self);

        /// <summary>
        ///     Ims the draw list splitter clear free memory using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ImDrawListSplitter_ClearFreeMemory(ImDrawListSplitter* self);

        /// <summary>
        ///     Ims the draw list splitter destroy using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ImDrawListSplitter_destroy(ImDrawListSplitter* self);

        /// <summary>
        ///     Ims the draw list splitter im draw list splitter
        /// </summary>
        /// <returns>The im draw list splitter</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern ImDrawListSplitter* ImDrawListSplitter_ImDrawListSplitter();

        /// <summary>
        ///     Ims the draw list splitter merge using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        /// <param name="drawList">The draw list</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ImDrawListSplitter_Merge(ImDrawListSplitter* self, ImDrawList* drawList);

        /// <summary>
        ///     Ims the draw list splitter set current channel using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        /// <param name="drawList">The draw list</param>
        /// <param name="channelIdx">The channel idx</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ImDrawListSplitter_SetCurrentChannel(ImDrawListSplitter* self, ImDrawList* drawList, int channelIdx);

        /// <summary>
        ///     Ims the draw list splitter split using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        /// <param name="drawList">The draw list</param>
        /// <param name="count">The count</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ImDrawListSplitter_Split(ImDrawListSplitter* self, ImDrawList* drawList, int count);

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
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ImFont_AddGlyph(ImFont* self, ImFontConfig* srcCfg, ushort c, float x0, float y0, float x1, float y1, float u0, float v0, float u1, float v1, float advanceX);

        /// <summary>
        ///     Ims the font add remap char using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        /// <param name="dst">The dst</param>
        /// <param name="src">The src</param>
        /// <param name="overwriteDst">The overwrite dst</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ImFont_AddRemapChar(ImFont* self, ushort dst, ushort src, byte overwriteDst);

        /// <summary>
        ///     Ims the font build lookup table using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ImFont_BuildLookupTable(ImFont* self);

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
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ImFont_CalcTextSizeA(Vector2F* pOut, ImFont* self, float size, float maxWidth, float wrapWidth, byte* textBegin, byte* textEnd, byte** remaining);

        /// <summary>
        ///     Ims the font calc word wrap position a using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        /// <param name="scale">The scale</param>
        /// <param name="text">The text</param>
        /// <param name="textEnd">The text end</param>
        /// <param name="wrapWidth">The wrap width</param>
        /// <returns>The byte</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern byte* ImFont_CalcWordWrapPositionA(ImFont* self, float scale, byte* text, byte* textEnd, float wrapWidth);

        /// <summary>
        ///     Ims the font clear output data using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ImFont_ClearOutputData(ImFont* self);

        /// <summary>
        ///     Ims the font destroy using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ImFont_destroy(ImFont* self);

        /// <summary>
        ///     Ims the font find glyph using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        /// <param name="c">The </param>
        /// <returns>The im font glyph</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern ImFontGlyph* ImFont_FindGlyph(ImFont* self, ushort c);

        /// <summary>
        ///     Ims the font find glyph no fallback using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        /// <param name="c">The </param>
        /// <returns>The im font glyph</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern ImFontGlyph* ImFont_FindGlyphNoFallback(ImFont* self, ushort c);

        /// <summary>
        ///     Ims the font get char advance using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        /// <param name="c">The </param>
        /// <returns>The float</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern float ImFont_GetCharAdvance(ImFont* self, ushort c);

        /// <summary>
        ///     Ims the font get debug name using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        /// <returns>The byte</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern byte* ImFont_GetDebugName(ImFont* self);

        /// <summary>
        ///     Ims the font grow index using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        /// <param name="newSize">The new size</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ImFont_GrowIndex(ImFont* self, int newSize);

        /// <summary>
        ///     Ims the font im font
        /// </summary>
        /// <returns>The im font</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern ImFont* ImFont_ImFont();

        /// <summary>
        ///     Ims the font is glyph range unused using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        /// <param name="cBegin">The begin</param>
        /// <param name="cLast">The last</param>
        /// <returns>The byte</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern byte ImFont_IsGlyphRangeUnused(ImFont* self, uint cBegin, uint cLast);

        /// <summary>
        ///     Ims the font is loaded using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        /// <returns>The byte</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern byte ImFont_IsLoaded(ImFont* self);

        /// <summary>
        ///     Ims the font render char using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        /// <param name="drawList">The draw list</param>
        /// <param name="size">The size</param>
        /// <param name="pos">The pos</param>
        /// <param name="col">The col</param>
        /// <param name="c">The </param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ImFont_RenderChar(ImFont* self, ImDrawList* drawList, float size, Vector2F pos, uint col, ushort c);

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
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ImFont_RenderText(ImFont* self, ImDrawList* drawList, float size, Vector2F pos, uint col, Vector4F clipRect, byte* textBegin, byte* textEnd, float wrapWidth, byte cpuFineClip);

        /// <summary>
        ///     Ims the font set glyph visible using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        /// <param name="c">The </param>
        /// <param name="visible">The visible</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ImFont_SetGlyphVisible(ImFont* self, ushort c, byte visible);

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
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int ImFontAtlas_AddCustomRectFontGlyph(ImFontAtlas* self, ImFont* font, ushort id, int width, int height, float advanceX, Vector2F offset);

        /// <summary>
        ///     Ims the font atlas add custom rect regular using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        /// <param name="width">The width</param>
        /// <param name="height">The height</param>
        /// <returns>The int</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int ImFontAtlas_AddCustomRectRegular(ImFontAtlas* self, int width, int height);

        /// <summary>
        ///     Ims the font atlas add font using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        /// <param name="fontCfg">The font cfg</param>
        /// <returns>The im font</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern ImFont* ImFontAtlas_AddFont(ImFontAtlas* self, ImFontConfig* fontCfg);

        /// <summary>
        ///     Ims the font atlas add font default using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        /// <param name="fontCfg">The font cfg</param>
        /// <returns>The im font</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern ImFont* ImFontAtlas_AddFontDefault(ImFontAtlas* self, ImFontConfig* fontCfg);

        /// <summary>
        ///     Ims the font atlas add font from file ttf using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        /// <param name="filename">The filename</param>
        /// <param name="sizePixels">The size pixels</param>
        /// <param name="fontCfg">The font cfg</param>
        /// <param name="glyphRanges">The glyph ranges</param>
        /// <returns>The im font</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern ImFont* ImFontAtlas_AddFontFromFileTTF(ImFontAtlas* self, byte* filename, float sizePixels, ImFontConfig* fontCfg, ushort* glyphRanges);

        /// <summary>
        ///     Ims the font atlas add font from memory compressed base 85 ttf using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        /// <param name="compressedFontDataBase85">The compressed font data base85</param>
        /// <param name="sizePixels">The size pixels</param>
        /// <param name="fontCfg">The font cfg</param>
        /// <param name="glyphRanges">The glyph ranges</param>
        /// <returns>The im font</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern ImFont* ImFontAtlas_AddFontFromMemoryCompressedBase85TTF(ImFontAtlas* self, byte* compressedFontDataBase85, float sizePixels, ImFontConfig* fontCfg, ushort* glyphRanges);

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
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern ImFont* ImFontAtlas_AddFontFromMemoryCompressedTTF(ImFontAtlas* self, void* compressedFontData, int compressedFontSize, float sizePixels, ImFontConfig* fontCfg, ushort* glyphRanges);

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
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern ImFont* ImFontAtlas_AddFontFromMemoryTTF(ImFontAtlas* self, void* fontData, int fontSize, float sizePixels, ImFontConfig* fontCfg, ushort* glyphRanges);

        /// <summary>
        ///     Ims the font atlas build using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        /// <returns>The byte</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern byte ImFontAtlas_Build(ImFontAtlas* self);

        /// <summary>
        ///     Ims the font atlas calc custom rect uv using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        /// <param name="rect">The rect</param>
        /// <param name="outUvMin">The out uv min</param>
        /// <param name="outUvMax">The out uv max</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ImFontAtlas_CalcCustomRectUV(ImFontAtlas* self, ImFontAtlasCustomRect* rect, Vector2F* outUvMin, Vector2F* outUvMax);

        /// <summary>
        ///     Ims the font atlas clear using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ImFontAtlas_Clear(ImFontAtlas* self);

        /// <summary>
        ///     Ims the font atlas clear fonts using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ImFontAtlas_ClearFonts(ImFontAtlas* self);

        /// <summary>
        ///     Ims the font atlas clear input data using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ImFontAtlas_ClearInputData(ImFontAtlas* self);

        /// <summary>
        ///     Ims the font atlas clear tex data using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ImFontAtlas_ClearTexData(ImFontAtlas* self);

        /// <summary>
        ///     Ims the font atlas destroy using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ImFontAtlas_destroy(ImFontAtlas* self);

        /// <summary>
        ///     Ims the font atlas get custom rect by index using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        /// <param name="index">The index</param>
        /// <returns>The im font atlas custom rect</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern ImFontAtlasCustomRect* ImFontAtlas_GetCustomRectByIndex(ImFontAtlas* self, int index);

        /// <summary>
        ///     Ims the font atlas get glyph ranges chinese full using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        /// <returns>The ushort</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern ushort* ImFontAtlas_GetGlyphRangesChineseFull(ImFontAtlas* self);

        /// <summary>
        ///     Ims the font atlas get glyph ranges chinese simplified common using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        /// <returns>The ushort</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern ushort* ImFontAtlas_GetGlyphRangesChineseSimplifiedCommon(ImFontAtlas* self);

        /// <summary>
        ///     Ims the font atlas get glyph ranges cyrillic using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        /// <returns>The ushort</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern ushort* ImFontAtlas_GetGlyphRangesCyrillic(ImFontAtlas* self);

        /// <summary>
        ///     Ims the font atlas get glyph ranges default using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        /// <returns>The ushort</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern ushort* ImFontAtlas_GetGlyphRangesDefault(ImFontAtlas* self);

        /// <summary>
        ///     Ims the font atlas get glyph ranges greek using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        /// <returns>The ushort</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern ushort* ImFontAtlas_GetGlyphRangesGreek(ImFontAtlas* self);

        /// <summary>
        ///     Ims the font atlas get glyph ranges japanese using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        /// <returns>The ushort</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern ushort* ImFontAtlas_GetGlyphRangesJapanese(ImFontAtlas* self);

        /// <summary>
        ///     Ims the font atlas get glyph ranges korean using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        /// <returns>The ushort</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern ushort* ImFontAtlas_GetGlyphRangesKorean(ImFontAtlas* self);

        /// <summary>
        ///     Ims the font atlas get glyph ranges thai using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        /// <returns>The ushort</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern ushort* ImFontAtlas_GetGlyphRangesThai(ImFontAtlas* self);

        /// <summary>
        ///     Ims the font atlas get glyph ranges vietnamese using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        /// <returns>The ushort</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern ushort* ImFontAtlas_GetGlyphRangesVietnamese(ImFontAtlas* self);

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
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern byte ImFontAtlas_GetMouseCursorTexData(ImFontAtlas* self, ImGuiMouseCursor cursor, Vector2F* outOffset, Vector2F* outSize, Vector2F* outUvBorder, Vector2F* outUvFill);

        /// <summary>
        ///     Ims the font atlas get tex data as alpha 8 using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        /// <param name="outPixels">The out pixels</param>
        /// <param name="outWidth">The out width</param>
        /// <param name="outHeight">The out height</param>
        /// <param name="outBytesPerPixel">The out bytes per pixel</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ImFontAtlas_GetTexDataAsAlpha8(ImFontAtlas* self, byte** outPixels, int* outWidth, int* outHeight, int* outBytesPerPixel);

        /// <summary>
        ///     Ims the font atlas get tex data as alpha 8 using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        /// <param name="outPixels">The out pixels</param>
        /// <param name="outWidth">The out width</param>
        /// <param name="outHeight">The out height</param>
        /// <param name="outBytesPerPixel">The out bytes per pixel</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ImFontAtlas_GetTexDataAsAlpha8(ImFontAtlas* self, IntPtr* outPixels, int* outWidth, int* outHeight, int* outBytesPerPixel);

        /// <summary>
        ///     Ims the font atlas get tex data as rgba 32 using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        /// <param name="outPixels">The out pixels</param>
        /// <param name="outWidth">The out width</param>
        /// <param name="outHeight">The out height</param>
        /// <param name="outBytesPerPixel">The out bytes per pixel</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ImFontAtlas_GetTexDataAsRGBA32(ImFontAtlas* self, byte** outPixels, int* outWidth, int* outHeight, int* outBytesPerPixel);

        /// <summary>
        ///     Ims the font atlas get tex data as rgba 32 using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        /// <param name="outPixels">The out pixels</param>
        /// <param name="outWidth">The out width</param>
        /// <param name="outHeight">The out height</param>
        /// <param name="outBytesPerPixel">The out bytes per pixel</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ImFontAtlas_GetTexDataAsRGBA32(ImFontAtlas* self, IntPtr* outPixels, int* outWidth, int* outHeight, int* outBytesPerPixel);

        /// <summary>
        ///     Ims the font atlas im font atlas
        /// </summary>
        /// <returns>The im font atlas</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern ImFontAtlas* ImFontAtlas_ImFontAtlas();

        /// <summary>
        ///     Ims the font atlas is built using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        /// <returns>The byte</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern byte ImFontAtlas_IsBuilt(ImFontAtlas* self);

        /// <summary>
        ///     Ims the font atlas set tex id using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        /// <param name="id">The id</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ImFontAtlas_SetTexID(ImFontAtlas* self, IntPtr id);

        /// <summary>
        ///     Ims the font atlas custom rect destroy using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ImFontAtlasCustomRect_destroy(ImFontAtlasCustomRect* self);

        /// <summary>
        ///     Ims the font atlas custom rect im font atlas custom rect
        /// </summary>
        /// <returns>The im font atlas custom rect</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern ImFontAtlasCustomRect* ImFontAtlasCustomRect_ImFontAtlasCustomRect();

        /// <summary>
        ///     Ims the font atlas custom rect is packed using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        /// <returns>The byte</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern byte ImFontAtlasCustomRect_IsPacked(ImFontAtlasCustomRect* self);

        /// <summary>
        ///     Ims the font config destroy using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ImFontConfig_destroy(ImFontConfig* self);

        /// <summary>
        ///     Ims the font config im font config
        /// </summary>
        /// <returns>The im font config</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern ImFontConfig* ImFontConfig_ImFontConfig();

        /// <summary>
        ///     Ims the font glyph ranges builder add char using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        /// <param name="c">The </param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ImFontGlyphRangesBuilder_AddChar(ImFontGlyphRangesBuilder* self, ushort c);

        /// <summary>
        ///     Ims the font glyph ranges builder add ranges using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        /// <param name="ranges">The ranges</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ImFontGlyphRangesBuilder_AddRanges(ImFontGlyphRangesBuilder* self, ushort* ranges);

        /// <summary>
        ///     Ims the font glyph ranges builder add text using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        /// <param name="text">The text</param>
        /// <param name="textEnd">The text end</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ImFontGlyphRangesBuilder_AddText(ImFontGlyphRangesBuilder* self, byte* text, byte* textEnd);

        /// <summary>
        ///     Ims the font glyph ranges builder build ranges using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        /// <param name="outRanges">The out ranges</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ImFontGlyphRangesBuilder_BuildRanges(ImFontGlyphRangesBuilder* self, ImVector* outRanges);

        /// <summary>
        ///     Ims the font glyph ranges builder clear using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ImFontGlyphRangesBuilder_Clear(ImFontGlyphRangesBuilder* self);

        /// <summary>
        ///     Ims the font glyph ranges builder destroy using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ImFontGlyphRangesBuilder_destroy(ImFontGlyphRangesBuilder* self);

        /// <summary>
        ///     Ims the font glyph ranges builder get bit using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        /// <param name="n">The </param>
        /// <returns>The byte</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern byte ImFontGlyphRangesBuilder_GetBit(ImFontGlyphRangesBuilder* self, uint n);

        /// <summary>
        ///     Ims the font glyph ranges builder im font glyph ranges builder
        /// </summary>
        /// <returns>The im font glyph ranges builder</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern ImFontGlyphRangesBuilder* ImFontGlyphRangesBuilder_ImFontGlyphRangesBuilder();

        /// <summary>
        ///     Ims the font glyph ranges builder set bit using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        /// <param name="n">The </param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ImFontGlyphRangesBuilder_SetBit(ImFontGlyphRangesBuilder* self, uint n);

        /// <summary>
        ///     Ims the gui input text callback data clear selection using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ImGuiInputTextCallbackData_ClearSelection(ImGuiInputTextCallbackData* self);

        /// <summary>
        ///     Ims the gui input text callback data delete chars using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        /// <param name="pos">The pos</param>
        /// <param name="bytesCount">The bytes count</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ImGuiInputTextCallbackData_DeleteChars(ImGuiInputTextCallbackData* self, int pos, int bytesCount);

        /// <summary>
        ///     Ims the gui input text callback data destroy using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ImGuiInputTextCallbackData_destroy(ImGuiInputTextCallbackData* self);

        /// <summary>
        ///     Ims the gui input text callback data has selection using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        /// <returns>The byte</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern byte ImGuiInputTextCallbackData_HasSelection(ImGuiInputTextCallbackData* self);

        /// <summary>
        ///     Ims the gui input text callback data im gui input text callback data
        /// </summary>
        /// <returns>The im gui input text callback data</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern ImGuiInputTextCallbackData* ImGuiInputTextCallbackData_ImGuiInputTextCallbackData();

        /// <summary>
        ///     Ims the gui input text callback data insert chars using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        /// <param name="pos">The pos</param>
        /// <param name="text">The text</param>
        /// <param name="textEnd">The text end</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ImGuiInputTextCallbackData_InsertChars(ImGuiInputTextCallbackData* self, int pos, byte* text, byte* textEnd);

        /// <summary>
        ///     Ims the gui input text callback data select all using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ImGuiInputTextCallbackData_SelectAll(ImGuiInputTextCallbackData* self);

        /// <summary>
        ///     Ims the gui io add focus event using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        /// <param name="focused">The focused</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ImGuiIO_AddFocusEvent(ImGuiIo* self, byte focused);

        /// <summary>
        ///     Ims the gui io add input character using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        /// <param name="c">The </param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ImGuiIO_AddInputCharacter(ImGuiIo* self, uint c);

        /// <summary>
        ///     Ims the gui io add input characters utf 8 using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        /// <param name="str">The str</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ImGuiIO_AddInputCharactersUTF8(ImGuiIo* self, byte* str);

        /// <summary>
        ///     Ims the gui io add input character utf 16 using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        /// <param name="c">The </param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ImGuiIO_AddInputCharacterUTF16(ImGuiIo* self, ushort c);

        /// <summary>
        ///     Ims the gui io add key analog event using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        /// <param name="key">The key</param>
        /// <param name="down">The down</param>
        /// <param name="v">The </param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ImGuiIO_AddKeyAnalogEvent(ImGuiIo* self, ImGuiKey key, byte down, float v);

        /// <summary>
        ///     Ims the gui io add key event using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        /// <param name="key">The key</param>
        /// <param name="down">The down</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ImGuiIO_AddKeyEvent(ImGuiIo* self, ImGuiKey key, byte down);

        /// <summary>
        ///     Ims the gui io add mouse button event using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        /// <param name="button">The button</param>
        /// <param name="down">The down</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ImGuiIO_AddMouseButtonEvent(ImGuiIo* self, int button, byte down);

        /// <summary>
        ///     Ims the gui io add mouse pos event using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        /// <param name="x">The </param>
        /// <param name="y">The </param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ImGuiIO_AddMousePosEvent(ImGuiIo* self, float x, float y);

        /// <summary>
        ///     Ims the gui io add mouse source event using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        /// <param name="source">The source</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ImGuiIO_AddMouseSourceEvent(ImGuiIo* self, ImGuiMouseSource source);

        /// <summary>
        ///     Ims the gui io add mouse viewport event using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        /// <param name="id">The id</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ImGuiIO_AddMouseViewportEvent(ImGuiIo* self, uint id);

        /// <summary>
        ///     Ims the gui io add mouse wheel event using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        /// <param name="wheelX">The wheel</param>
        /// <param name="wheelY">The wheel</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ImGuiIO_AddMouseWheelEvent(ImGuiIo* self, float wheelX, float wheelY);

        /// <summary>
        ///     Ims the gui io clear input characters using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ImGuiIO_ClearInputCharacters(ImGuiIo* self);

        /// <summary>
        ///     Ims the gui io clear input keys using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ImGuiIO_ClearInputKeys(ImGuiIo* self);

        /// <summary>
        ///     Ims the gui io destroy using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ImGuiIO_destroy(ImGuiIo* self);

        /// <summary>
        ///     Ims the gui io im gui io
        /// </summary>
        /// <returns>The im gui io</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern ImGuiIo* ImGuiIO_ImGuiIO();

        /// <summary>
        ///     Ims the gui io set app accepting events using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        /// <param name="acceptingEvents">The accepting events</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ImGuiIO_SetAppAcceptingEvents(ImGuiIo* self, byte acceptingEvents);

        /// <summary>
        ///     Ims the gui io set key event native data using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        /// <param name="key">The key</param>
        /// <param name="nativeKeycode">The native keycode</param>
        /// <param name="nativeScancode">The native scancode</param>
        /// <param name="nativeLegacyIndex">The native legacy index</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ImGuiIO_SetKeyEventNativeData(ImGuiIo* self, ImGuiKey key, int nativeKeycode, int nativeScancode, int nativeLegacyIndex);

        /// <summary>
        ///     Ims the gui list clipper begin using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        /// <param name="itemsCount">The items count</param>
        /// <param name="itemsHeight">The items height</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ImGuiListClipper_Begin(ImGuiListClipper* self, int itemsCount, float itemsHeight);

        /// <summary>
        ///     Ims the gui list clipper destroy using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ImGuiListClipper_destroy(ImGuiListClipper* self);

        /// <summary>
        ///     Ims the gui list clipper end using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ImGuiListClipper_End(ImGuiListClipper* self);

        /// <summary>
        ///     Ims the gui list clipper force display range by indices using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        /// <param name="itemMin">The item min</param>
        /// <param name="itemMax">The item max</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ImGuiListClipper_ForceDisplayRangeByIndices(ImGuiListClipper* self, int itemMin, int itemMax);

        /// <summary>
        ///     Ims the gui list clipper im gui list clipper
        /// </summary>
        /// <returns>The im gui list clipper</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern ImGuiListClipper* ImGuiListClipper_ImGuiListClipper();

        /// <summary>
        ///     Ims the gui list clipper step using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        /// <returns>The byte</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern byte ImGuiListClipper_Step(ImGuiListClipper* self);

        /// <summary>
        ///     Ims the gui once upon a frame destroy using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ImGuiOnceUponAFrame_destroy(ImGuiOnceUponAFrame* self);

        /// <summary>
        ///     Ims the gui once upon a frame im gui once upon a frame
        /// </summary>
        /// <returns>The im gui once upon frame</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern ImGuiOnceUponAFrame* ImGuiOnceUponAFrame_ImGuiOnceUponAFrame();

        /// <summary>
        ///     Ims the gui payload clear using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ImGuiPayload_Clear(ImGuiPayload* self);

        /// <summary>
        ///     Ims the gui payload destroy using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ImGuiPayload_destroy(ImGuiPayload* self);

        /// <summary>
        ///     Ims the gui payload im gui payload
        /// </summary>
        /// <returns>The im gui payload</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern ImGuiPayload* ImGuiPayload_ImGuiPayload();

        /// <summary>
        ///     Ims the gui payload is data type using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        /// <param name="type">The type</param>
        /// <returns>The byte</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern byte ImGuiPayload_IsDataType(ImGuiPayload* self, byte* type);

        /// <summary>
        ///     Ims the gui payload is delivery using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        /// <returns>The byte</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern byte ImGuiPayload_IsDelivery(ImGuiPayload* self);

        /// <summary>
        ///     Ims the gui payload is preview using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        /// <returns>The byte</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern byte ImGuiPayload_IsPreview(ImGuiPayload* self);

        /// <summary>
        ///     Ims the gui platform ime data destroy using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ImGuiPlatformImeData_destroy(ImGuiPlatformImeData* self);

        /// <summary>
        ///     Ims the gui platform ime data im gui platform ime data
        /// </summary>
        /// <returns>The im gui platform ime data</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern ImGuiPlatformImeData* ImGuiPlatformImeData_ImGuiPlatformImeData();

        /// <summary>
        ///     Ims the gui platform io destroy using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ImGuiPlatformIO_destroy(ImGuiPlatformIo* self);

        /// <summary>
        ///     Ims the gui platform io im gui platform io
        /// </summary>
        /// <returns>The im gui platform io</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern ImGuiPlatformIo* ImGuiPlatformIO_ImGuiPlatformIO();

        /// <summary>
        ///     Ims the gui platform monitor destroy using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ImGuiPlatformMonitor_destroy(ImGuiPlatformMonitor* self);

        /// <summary>
        ///     Ims the gui platform monitor im gui platform monitor
        /// </summary>
        /// <returns>The im gui platform monitor</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern ImGuiPlatformMonitor* ImGuiPlatformMonitor_ImGuiPlatformMonitor();

        /// <summary>
        ///     Ims the gui storage build sort by key using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ImGuiStorage_BuildSortByKey(ImGuiStorage* self);

        /// <summary>
        ///     Ims the gui storage clear using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ImGuiStorage_Clear(ImGuiStorage* self);

        /// <summary>
        ///     Ims the gui storage get bool using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        /// <param name="key">The key</param>
        /// <param name="defaultVal">The default val</param>
        /// <returns>The byte</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern byte ImGuiStorage_GetBool(ImGuiStorage* self, uint key, byte defaultVal);

        /// <summary>
        ///     Ims the gui storage get bool ref using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        /// <param name="key">The key</param>
        /// <param name="defaultVal">The default val</param>
        /// <returns>The byte</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern byte* ImGuiStorage_GetBoolRef(ImGuiStorage* self, uint key, byte defaultVal);

        /// <summary>
        ///     Ims the gui storage get float using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        /// <param name="key">The key</param>
        /// <param name="defaultVal">The default val</param>
        /// <returns>The float</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern float ImGuiStorage_GetFloat(ImGuiStorage* self, uint key, float defaultVal);

        /// <summary>
        ///     Ims the gui storage get float ref using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        /// <param name="key">The key</param>
        /// <param name="defaultVal">The default val</param>
        /// <returns>The float</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern float* ImGuiStorage_GetFloatRef(ImGuiStorage* self, uint key, float defaultVal);

        /// <summary>
        ///     Ims the gui storage get int using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        /// <param name="key">The key</param>
        /// <param name="defaultVal">The default val</param>
        /// <returns>The int</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int ImGuiStorage_GetInt(ImGuiStorage* self, uint key, int defaultVal);

        /// <summary>
        ///     Ims the gui storage get int ref using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        /// <param name="key">The key</param>
        /// <param name="defaultVal">The default val</param>
        /// <returns>The int</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int* ImGuiStorage_GetIntRef(ImGuiStorage* self, uint key, int defaultVal);

        /// <summary>
        ///     Ims the gui storage get void ptr using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        /// <param name="key">The key</param>
        /// <returns>The void</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void* ImGuiStorage_GetVoidPtr(ImGuiStorage* self, uint key);

        /// <summary>
        ///     Ims the gui storage get void ptr ref using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        /// <param name="key">The key</param>
        /// <param name="defaultVal">The default val</param>
        /// <returns>The void</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void** ImGuiStorage_GetVoidPtrRef(ImGuiStorage* self, uint key, void* defaultVal);

        /// <summary>
        ///     Ims the gui storage set all int using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        /// <param name="val">The val</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ImGuiStorage_SetAllInt(ImGuiStorage* self, int val);

        /// <summary>
        ///     Ims the gui storage set bool using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        /// <param name="key">The key</param>
        /// <param name="val">The val</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ImGuiStorage_SetBool(ImGuiStorage* self, uint key, byte val);

        /// <summary>
        ///     Ims the gui storage set float using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        /// <param name="key">The key</param>
        /// <param name="val">The val</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ImGuiStorage_SetFloat(ImGuiStorage* self, uint key, float val);

        /// <summary>
        ///     Ims the gui storage set int using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        /// <param name="key">The key</param>
        /// <param name="val">The val</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ImGuiStorage_SetInt(ImGuiStorage* self, uint key, int val);

        /// <summary>
        ///     Ims the gui storage set void ptr using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        /// <param name="key">The key</param>
        /// <param name="val">The val</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ImGuiStorage_SetVoidPtr(ImGuiStorage* self, uint key, void* val);

        /// <summary>
        ///     Ims the gui storage pair destroy using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ImGuiStoragePair_destroy(ImGuiStoragePair* self);

        /// <summary>
        ///     Ims the gui storage pair im gui storage pair int using the specified  key
        /// </summary>
        /// <param name="key">The key</param>
        /// <param name="valI">The val</param>
        /// <returns>The im gui storage pair</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern ImGuiStoragePair* ImGuiStoragePair_ImGuiStoragePair_Int(uint key, int valI);

        /// <summary>
        ///     Ims the gui storage pair im gui storage pair float using the specified  key
        /// </summary>
        /// <param name="key">The key</param>
        /// <param name="valF">The val</param>
        /// <returns>The im gui storage pair</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern ImGuiStoragePair* ImGuiStoragePair_ImGuiStoragePair_Float(uint key, float valF);

        /// <summary>
        ///     Ims the gui storage pair im gui storage pair ptr using the specified  key
        /// </summary>
        /// <param name="key">The key</param>
        /// <param name="valP">The val</param>
        /// <returns>The im gui storage pair</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern ImGuiStoragePair* ImGuiStoragePair_ImGuiStoragePair_Ptr(uint key, void* valP);

        /// <summary>
        ///     Ims the gui style destroy using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ImGuiStyle_destroy(ImGuiStyle* self);

        /// <summary>
        ///     Ims the gui style im gui style
        /// </summary>
        /// <returns>The im gui style</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern ImGuiStyle* ImGuiStyle_ImGuiStyle();

        /// <summary>
        ///     Ims the gui style scale all sizes using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        /// <param name="scaleFactor">The scale factor</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ImGuiStyle_ScaleAllSizes(ImGuiStyle* self, float scaleFactor);

        /// <summary>
        ///     Ims the gui table column sort specs destroy using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ImGuiTableColumnSortSpecs_destroy(ImGuiTableColumnSortSpecs* self);

        /// <summary>
        ///     Ims the gui table column sort specs im gui table column sort specs
        /// </summary>
        /// <returns>The im gui table column sort specs</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern ImGuiTableColumnSortSpecs* ImGuiTableColumnSortSpecs_ImGuiTableColumnSortSpecs();

        /// <summary>
        ///     Ims the gui table sort specs destroy using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ImGuiTableSortSpecs_destroy(ImGuiTableSortSpecs* self);

        /// <summary>
        ///     Ims the gui table sort specs im gui table sort specs
        /// </summary>
        /// <returns>The im gui table sort specs</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern ImGuiTableSortSpecs* ImGuiTableSortSpecs_ImGuiTableSortSpecs();

        /// <summary>
        ///     Ims the gui text buffer append using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        /// <param name="str">The str</param>
        /// <param name="strEnd">The str end</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ImGuiTextBuffer_append(ImGuiTextBuffer* self, byte* str, byte* strEnd);

        /// <summary>
        ///     Ims the gui text buffer appendf using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        /// <param name="fmt">The fmt</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ImGuiTextBuffer_appendf(ImGuiTextBuffer* self, byte* fmt);

        /// <summary>
        ///     Ims the gui text buffer begin using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        /// <returns>The byte</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern byte* ImGuiTextBuffer_begin(ImGuiTextBuffer* self);

        /// <summary>
        ///     Ims the gui text buffer c str using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        /// <returns>The byte</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern byte* ImGuiTextBuffer_c_str(ImGuiTextBuffer* self);

        /// <summary>
        ///     Ims the gui text buffer clear using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ImGuiTextBuffer_clear(ImGuiTextBuffer* self);

        /// <summary>
        ///     Ims the gui text buffer destroy using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ImGuiTextBuffer_destroy(ImGuiTextBuffer* self);

        /// <summary>
        ///     Ims the gui text buffer empty using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        /// <returns>The byte</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern byte ImGuiTextBuffer_empty(ImGuiTextBuffer* self);

        /// <summary>
        ///     Ims the gui text buffer end using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        /// <returns>The byte</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern byte* ImGuiTextBuffer_end(ImGuiTextBuffer* self);

        /// <summary>
        ///     Ims the gui text buffer im gui text buffer
        /// </summary>
        /// <returns>The im gui text buffer</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern ImGuiTextBuffer* ImGuiTextBuffer_ImGuiTextBuffer();

        /// <summary>
        ///     Ims the gui text buffer reserve using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        /// <param name="capacity">The capacity</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ImGuiTextBuffer_reserve(ImGuiTextBuffer* self, int capacity);

        /// <summary>
        ///     Ims the gui text buffer size using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        /// <returns>The int</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int ImGuiTextBuffer_size(ImGuiTextBuffer* self);

        /// <summary>
        ///     Ims the gui text filter build using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ImGuiTextFilter_Build(ImGuiTextFilter* self);

        /// <summary>
        ///     Ims the gui text filter clear using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ImGuiTextFilter_Clear(ImGuiTextFilter* self);

        /// <summary>
        ///     Ims the gui text filter destroy using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ImGuiTextFilter_destroy(ImGuiTextFilter* self);

        /// <summary>
        ///     Ims the gui text filter draw using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        /// <param name="label">The label</param>
        /// <param name="width">The width</param>
        /// <returns>The byte</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern byte ImGuiTextFilter_Draw(ImGuiTextFilter* self, byte* label, float width);

        /// <summary>
        ///     Ims the gui text filter im gui text filter using the specified default filter
        /// </summary>
        /// <param name="defaultFilter">The default filter</param>
        /// <returns>The im gui text filter</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern ImGuiTextFilter* ImGuiTextFilter_ImGuiTextFilter(byte* defaultFilter);

        /// <summary>
        ///     Ims the gui text filter is active using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        /// <returns>The byte</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern byte ImGuiTextFilter_IsActive(ImGuiTextFilter* self);

        /// <summary>
        ///     Ims the gui text filter pass filter using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        /// <param name="text">The text</param>
        /// <param name="textEnd">The text end</param>
        /// <returns>The byte</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern byte ImGuiTextFilter_PassFilter(ImGuiTextFilter* self, byte* text, byte* textEnd);

        /// <summary>
        ///     Ims the gui text range destroy using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ImGuiTextRange_destroy(ImGuiTextRange* self);

        /// <summary>
        ///     Ims the gui text range empty using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        /// <returns>The byte</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern byte ImGuiTextRange_empty(ImGuiTextRange* self);

        /// <summary>
        ///     Ims the gui text range im gui text range nil
        /// </summary>
        /// <returns>The im gui text range</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern ImGuiTextRange* ImGuiTextRange_ImGuiTextRange_Nil();

        /// <summary>
        ///     Ims the gui text range im gui text range str using the specified  b
        /// </summary>
        /// <param name="b">The </param>
        /// <param name="e">The </param>
        /// <returns>The im gui text range</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern ImGuiTextRange* ImGuiTextRange_ImGuiTextRange_Str(byte* b, byte* e);

        /// <summary>
        /// </summary>
        /// <param name="self"></param>
        /// <param name="separator"></param>
        /// <param name="out"></param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ImGuiTextRange_split(ImGuiTextRange* self, byte separator, ImVector* @out);

        /// <summary>
        ///     Ims the gui viewport destroy using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ImGuiViewport_destroy(ImGuiViewport* self);

        /// <summary>
        ///     Ims the gui viewport get center using the specified p out
        /// </summary>
        /// <param name="pOut">The out</param>
        /// <param name="self">The self</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ImGuiViewport_GetCenter(Vector2F* pOut, ImGuiViewport* self);

        /// <summary>
        ///     Ims the gui viewport get work center using the specified p out
        /// </summary>
        /// <param name="pOut">The out</param>
        /// <param name="self">The self</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ImGuiViewport_GetWorkCenter(Vector2F* pOut, ImGuiViewport* self);

        /// <summary>
        ///     Ims the gui viewport im gui viewport
        /// </summary>
        /// <returns>The im gui viewport</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern ImGuiViewport* ImGuiViewport_ImGuiViewport();

        /// <summary>
        ///     Ims the gui window class destroy using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ImGuiWindowClass_destroy(ImGuiWindowClass* self);

        /// <summary>
        ///     Ims the gui window class im gui window
        /// </summary>
        /// <returns>The im gui window class</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern ImGuiWindowClass* ImGuiWindowClass_ImGuiWindowClass();

        /// <summary>
        ///     Ims the vec 2 destroy using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ImVec2_destroy(Vector2F* self);

        /// <summary>
        ///     Ims the vec 2 im vec 2 nil
        /// </summary>
        /// <returns>The vector</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern Vector2F* ImVec2_ImVec2_Nil();

        /// <summary>
        ///     Ims the vec 2 im vec 2 float using the specified  x
        /// </summary>
        /// <param name="x">The </param>
        /// <param name="y">The </param>
        /// <returns>The vector</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern Vector2F* ImVec2_ImVec2_Float(float x, float y);

        /// <summary>
        ///     Ims the vec 4 destroy using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ImVec4_destroy(Vector4F* self);

        /// <summary>
        ///     Ims the vec 4 im vec 4 nil
        /// </summary>
        /// <returns>The vector</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern Vector4F* ImVec4_ImVec4_Nil();

        /// <summary>
        ///     Ims the vec 4 im vec 4 float using the specified  x
        /// </summary>
        /// <param name="x">The </param>
        /// <param name="y">The </param>
        /// <param name="z">The </param>
        /// <param name="w">The </param>
        /// <returns>The vector</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern Vector4F* ImVec4_ImVec4_Float(float x, float y, float z, float w);
    }
}