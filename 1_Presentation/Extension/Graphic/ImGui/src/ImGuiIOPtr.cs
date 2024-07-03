// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImGuiIOPtr.cs
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
using System.Text;
using Alis.Core.Aspect.Math.Vector;

namespace Alis.Extension.Graphic.ImGui
{
    /// <summary>
    ///     The im gui io ptr
    /// </summary>
    public readonly struct ImGuiIoPtr
    {
        /// <summary>
        ///     Gets the value of the native ptr
        /// </summary>
        public IntPtr NativePtr { get; }
        
        /// <summary>
        ///     Initializes a new instance of the <see cref="ImGuiIoPtr" /> class
        /// </summary>
        /// <param name="nativePtr">The native ptr</param>
        public ImGuiIoPtr(IntPtr nativePtr) => NativePtr = nativePtr;
        
        /// <summary>
        /// </summary>
        /// <param name="wrappedPtr"></param>
        /// <returns></returns>
        public static implicit operator IntPtr(ImGuiIoPtr wrappedPtr) => wrappedPtr.NativePtr;
        
        /// <summary>
        /// </summary>
        /// <param name="nativePtr"></param>
        /// <returns></returns>
        public static implicit operator ImGuiIoPtr(IntPtr nativePtr) => new ImGuiIoPtr(nativePtr);
        
        /// <summary>
        ///     Gets the value of the config flags
        /// </summary>
        public  ImGuiConfigFlags ConfigFlags
        {
            get { return Marshal.PtrToStructure<ImGuiIo>(NativePtr).ConfigFlags; }
            set { Marshal.WriteIntPtr(NativePtr, (int) Marshal.OffsetOf<ImGuiIo>("ConfigFlags"), (IntPtr) value); }
        }
        
        /// <summary>
        ///     Gets the value of the backend flags
        /// </summary>
        public ImGuiBackendFlags BackendFlags
        {
            get => Marshal.PtrToStructure<ImGuiIo>(NativePtr).BackendFlags;
            set => Marshal.WriteIntPtr(NativePtr, (int) Marshal.OffsetOf<ImGuiIo>("BackendFlags"), (IntPtr) value);
        }
        
        /// <summary>
        ///     Gets the value of the display size
        /// </summary>
        public Vector2 DisplaySize
        {
            get
            {
                ImGuiIo io = Marshal.PtrToStructure<ImGuiIo>(NativePtr);
                return new Vector2(io.DisplaySize.X, io.DisplaySize.Y);
            }
            set
            {
                // Write x and y values to the DisplaySize field
                ImGuiIo io = Marshal.PtrToStructure<ImGuiIo>(NativePtr);
                io.DisplaySize.X = value.X;
                io.DisplaySize.Y = value.Y;
                Marshal.StructureToPtr(io, NativePtr, false);
            }
        }
        
        /// <summary>
        ///     Gets the value of the delta time
        /// </summary>
        public  float DeltaTime
        {
            get { return Marshal.PtrToStructure<ImGuiIo>(NativePtr).DeltaTime; }
            set
            {
                // Write x and y values to the DisplaySize field
                ImGuiIo io = Marshal.PtrToStructure<ImGuiIo>(NativePtr);
                io.DeltaTime = value;
                Marshal.StructureToPtr(io, NativePtr, false);
            }
        }
        
        /// <summary>
        ///     Gets the value of the ini saving rate
        /// </summary>
        public  float IniSavingRate => Marshal.PtrToStructure<ImGuiIo>(NativePtr).IniSavingRate;
        
        /// <summary>
        ///     Gets the value of the ini filename
        /// </summary>
        public NullTerminatedString IniFilename => new NullTerminatedString(Marshal.PtrToStructure<ImGuiIo>(NativePtr).IniFilename);
        
        /// <summary>
        ///     Gets the value of the log filename
        /// </summary>
        public NullTerminatedString LogFilename => new NullTerminatedString(Marshal.PtrToStructure<ImGuiIo>(NativePtr).LogFilename);
        
        /// <summary>
        ///     Gets the value of the mouse double click time
        /// </summary>
        public  float MouseDoubleClickTime =>  Marshal.PtrToStructure<ImGuiIo>(NativePtr).MouseDoubleClickTime;
        
        /// <summary>
        ///     Gets the value of the mouse double click max dist
        /// </summary>
        public  float MouseDoubleClickMaxDist =>  Marshal.PtrToStructure<ImGuiIo>(NativePtr).MouseDoubleClickMaxDist;
        
        /// <summary>
        ///     Gets the value of the mouse drag threshold
        /// </summary>
        public  float MouseDragThreshold => Marshal.PtrToStructure<ImGuiIo>(NativePtr).MouseDragThreshold;
        
        /// <summary>
        ///     Gets the value of the key repeat delay
        /// </summary>
        public  float KeyRepeatDelay => Marshal.PtrToStructure<ImGuiIo>(NativePtr).KeyRepeatDelay;
        
        /// <summary>
        ///     Gets the value of the key repeat rate
        /// </summary>
        public  float KeyRepeatRate => Marshal.PtrToStructure<ImGuiIo>(NativePtr).KeyRepeatRate;
        
        /// <summary>
        ///     Gets the value of the hover delay normal
        /// </summary>
        public  float HoverDelayNormal => Marshal.PtrToStructure<ImGuiIo>(NativePtr).HoverDelayNormal;
        
        /// <summary>
        ///     Gets the value of the hover delay short
        /// </summary>
        public  float HoverDelayShort => Marshal.PtrToStructure<ImGuiIo>(NativePtr).HoverDelayShort;
        
        /// <summary>
        ///     Gets or sets the value of the user data
        /// </summary>
        public IntPtr UserData
        {
            get => Marshal.PtrToStructure<ImGuiIo>(NativePtr).UserData;
            set => Marshal.WriteIntPtr(NativePtr, (int) Marshal.OffsetOf<ImGuiIo>("UserData"), value);
        }
        
        /// <summary>
        ///     Gets the value of the fonts
        /// </summary>
        public ImFontAtlasPtr Fonts => new ImFontAtlasPtr(Marshal.PtrToStructure<ImGuiIo>(NativePtr).Fonts);
        
        /// <summary>
        ///     Gets the value of the font global scale
        /// </summary>
        public  float FontGlobalScale => Marshal.PtrToStructure<ImGuiIo>(NativePtr).FontGlobalScale;
        
        /// <summary>
        ///     Gets the value of the font allow user scaling
        /// </summary>
        public  bool FontAllowUserScaling => Marshal.PtrToStructure<ImGuiIo>(NativePtr).FontAllowUserScaling != 0;
        
        /// <summary>
        ///     Gets the value of the font default
        /// </summary>
        public ImFontPtr FontDefault => new ImFontPtr(Marshal.PtrToStructure<ImGuiIo>(NativePtr).FontDefault);
        
        /// <summary>
        ///     Gets the value of the display framebuffer scale
        /// </summary>
        public  Vector2 DisplayFramebufferScale
        {
            get { return Marshal.PtrToStructure<ImGuiIo>(NativePtr).DisplayFramebufferScale; }
            set
            {
                // Write x and y values to the DisplayFramebufferScale field
                ImGuiIo io = Marshal.PtrToStructure<ImGuiIo>(NativePtr);
                io.DisplayFramebufferScale.X = value.X;
                io.DisplayFramebufferScale.Y = value.Y;
                Marshal.StructureToPtr(io, NativePtr, false);
            }
        }
        
        /// <summary>
        ///     Gets the value of the config docking no split
        /// </summary>
        public  bool ConfigDockingNoSplit => Marshal.PtrToStructure<ImGuiIo>(NativePtr).ConfigDockingNoSplit != 0;
        
        /// <summary>
        ///     Gets the value of the config docking with shift
        /// </summary>
        public  bool ConfigDockingWithShift => Marshal.PtrToStructure<ImGuiIo>(NativePtr).ConfigDockingWithShift != 0;
        
        /// <summary>
        ///     Gets the value of the config docking always tab bar
        /// </summary>
        public  bool ConfigDockingAlwaysTabBar => Marshal.PtrToStructure<ImGuiIo>(NativePtr).ConfigDockingAlwaysTabBar != 0;
        
        /// <summary>
        ///     Gets the value of the config docking transparent payload
        /// </summary>
        public  bool ConfigDockingTransparentPayload => Marshal.PtrToStructure<ImGuiIo>(NativePtr).ConfigDockingTransparentPayload != 0;
        
        /// <summary>
        ///     Gets the value of the config viewports no auto merge
        /// </summary>
        public  bool ConfigViewportsNoAutoMerge => Marshal.PtrToStructure<ImGuiIo>(NativePtr).ConfigViewportsNoAutoMerge != 0;
        
        /// <summary>
        ///     Gets the value of the config viewports no task bar icon
        /// </summary>
        public  bool ConfigViewportsNoTaskBarIcon => Marshal.PtrToStructure<ImGuiIo>(NativePtr).ConfigViewportsNoTaskBarIcon != 0;
        
        /// <summary>
        ///     Gets the value of the config viewports no decoration
        /// </summary>
        public  bool ConfigViewportsNoDecoration => Marshal.PtrToStructure<ImGuiIo>(NativePtr).ConfigViewportsNoDecoration != 0;
        
        /// <summary>
        ///     Gets the value of the config viewports no default parent
        /// </summary>
        public  bool ConfigViewportsNoDefaultParent => Marshal.PtrToStructure<ImGuiIo>(NativePtr).ConfigViewportsNoDefaultParent != 0;
        
        /// <summary>
        ///     Gets the value of the mouse draw cursor
        /// </summary>
        public  bool MouseDrawCursor => Marshal.PtrToStructure<ImGuiIo>(NativePtr).MouseDrawCursor != 0;
        
        /// <summary>
        ///     Gets the value of the config mac osx behaviors
        /// </summary>
        public  bool ConfigMacOsxBehaviors => Marshal.PtrToStructure<ImGuiIo>(NativePtr).ConfigMacOsxBehaviors != 0;
        
        /// <summary>
        ///     Gets the value of the config input trickle event queue
        /// </summary>
        public  bool ConfigInputTrickleEventQueue => Marshal.PtrToStructure<ImGuiIo>(NativePtr).ConfigInputTrickleEventQueue != 0;
        
        /// <summary>
        ///     Gets the value of the config input text cursor blink
        /// </summary>
        public  bool ConfigInputTextCursorBlink => Marshal.PtrToStructure<ImGuiIo>(NativePtr).ConfigInputTextCursorBlink != 0;
        
        /// <summary>
        ///     Gets the value of the config input text enter keep active
        /// </summary>
        public  bool ConfigInputTextEnterKeepActive =>  Marshal.PtrToStructure<ImGuiIo>(NativePtr).ConfigInputTextEnterKeepActive != 0;
        
        /// <summary>
        ///     Gets the value of the config drag click to input text
        /// </summary>
        public  bool ConfigDragClickToInputText => Marshal.PtrToStructure<ImGuiIo>(NativePtr).ConfigDragClickToInputText != 0;
        
        /// <summary>
        ///     Gets the value of the config windows resize from edges
        /// </summary>
        public  bool ConfigWindowsResizeFromEdges => Marshal.PtrToStructure<ImGuiIo>(NativePtr).ConfigWindowsResizeFromEdges != 0;
        
        /// <summary>
        ///     Gets the value of the config windows move from title bar only
        /// </summary>
        public  bool ConfigWindowsMoveFromTitleBarOnly => Marshal.PtrToStructure<ImGuiIo>(NativePtr).ConfigWindowsMoveFromTitleBarOnly != 0;
        
        /// <summary>
        ///     Gets the value of the config memory compact timer
        /// </summary>
        public  float ConfigMemoryCompactTimer => Marshal.PtrToStructure<ImGuiIo>(NativePtr).ConfigMemoryCompactTimer;
        
        /// <summary>
        ///     Gets the value of the backend platform name
        /// </summary>
        public NullTerminatedString BackendPlatformName => new NullTerminatedString(Marshal.PtrToStructure<ImGuiIo>(NativePtr).BackendPlatformName);
        
        /// <summary>
        ///     Gets the value of the backend renderer name
        /// </summary>
        public NullTerminatedString BackendRendererName => new NullTerminatedString(Marshal.PtrToStructure<ImGuiIo>(NativePtr).BackendRendererName);
        
        /// <summary>
        ///     Gets or sets the value of the backend platform user data
        /// </summary>
        public IntPtr BackendPlatformUserData
        {
            get => Marshal.PtrToStructure<ImGuiIo>(NativePtr).BackendPlatformUserData;
            set => Marshal.WriteIntPtr(NativePtr, (int) Marshal.OffsetOf<ImGuiIo>("BackendPlatformUserData"), value);
        }
        
        /// <summary>
        ///     Gets or sets the value of the backend renderer user data
        /// </summary>
        public IntPtr BackendRendererUserData
        {
            get => Marshal.PtrToStructure<ImGuiIo>(NativePtr).BackendRendererUserData;
            set => Marshal.WriteIntPtr(NativePtr, (int) Marshal.OffsetOf<ImGuiIo>("BackendRendererUserData"), value);
        }
        
        /// <summary>
        ///     Gets or sets the value of the backend language user data
        /// </summary>
        public IntPtr BackendLanguageUserData
        {
            get => Marshal.PtrToStructure<ImGuiIo>(NativePtr).BackendLanguageUserData;
            set => Marshal.WriteIntPtr(NativePtr, (int) Marshal.OffsetOf<ImGuiIo>("BackendLanguageUserData"), value);
        }
        
        /// <summary>
        ///     Gets the value of the get clipboard text fn
        /// </summary>
        public  IntPtr GetClipboardTextFn => Marshal.PtrToStructure<ImGuiIo>(NativePtr).GetClipboardTextFn;
        
        /// <summary>
        ///     Gets the value of the set clipboard text fn
        /// </summary>
        public  IntPtr SetClipboardTextFn => Marshal.PtrToStructure<ImGuiIo>(NativePtr).SetClipboardTextFn;
        
        /// <summary>
        ///     Gets or sets the value of the clipboard user data
        /// </summary>
        public IntPtr ClipboardUserData
        {
            get => Marshal.PtrToStructure<ImGuiIo>(NativePtr).ClipboardUserData;
            set => Marshal.WriteIntPtr(NativePtr, (int) Marshal.OffsetOf<ImGuiIo>("ClipboardUserData"), value);
        }
        
        /// <summary>
        ///     Gets the value of the set platform ime data fn
        /// </summary>
        public  IntPtr SetPlatformImeDataFn =>  Marshal.PtrToStructure<ImGuiIo>(NativePtr).SetPlatformImeDataFn;
        
        /// <summary>
        ///     Gets or sets the value of the  unusedpadding
        /// </summary>
        public IntPtr UnusedPadding
        {
            get => Marshal.PtrToStructure<ImGuiIo>(NativePtr).UnusedPadding;
            set => Marshal.WriteIntPtr(NativePtr, (int) Marshal.OffsetOf<ImGuiIo>("UnusedPadding"), value);
        }
        
        /// <summary>
        ///     Gets the value of the want capture mouse
        /// </summary>
        public  bool WantCaptureMouse => Marshal.PtrToStructure<ImGuiIo>(NativePtr).WantCaptureMouse != 0;
        
        /// <summary>
        ///     Gets the value of the want capture keyboard
        /// </summary>
        public  bool WantCaptureKeyboard => Marshal.PtrToStructure<ImGuiIo>(NativePtr).WantCaptureKeyboard != 0;
        
        /// <summary>
        ///     Gets the value of the want text input
        /// </summary>
        public  bool WantTextInput => Marshal.PtrToStructure<ImGuiIo>(NativePtr).WantTextInput != 0;
        
        /// <summary>
        ///     Gets the value of the want set mouse pos
        /// </summary>
        public  bool WantSetMousePos => Marshal.PtrToStructure<ImGuiIo>(NativePtr).WantSetMousePos != 0;
        
        /// <summary>
        ///     Gets the value of the want save ini settings
        /// </summary>
        public  bool WantSaveIniSettings => Marshal.PtrToStructure<ImGuiIo>(NativePtr).WantSaveIniSettings != 0;
        
        /// <summary>
        ///     Gets the value of the nav active
        /// </summary>
        public  bool NavActive => Marshal.PtrToStructure<ImGuiIo>(NativePtr).NavActive != 0;
        
        /// <summary>
        ///     Gets the value of the nav visible
        /// </summary>
        public  bool NavVisible => Marshal.PtrToStructure<ImGuiIo>(NativePtr).NavVisible != 0;
        
        /// <summary>
        ///     Gets the value of the framerate
        /// </summary>
        public  float Framerate => Marshal.PtrToStructure<ImGuiIo>(NativePtr).Framerate;
        
        /// <summary>
        ///     Gets the value of the metrics render vertices
        /// </summary>
        public  int MetricsRenderVertices => Marshal.PtrToStructure<ImGuiIo>(NativePtr).MetricsRenderVertices;
        
        /// <summary>
        ///     Gets the value of the metrics render indices
        /// </summary>
        public  int MetricsRenderIndices => Marshal.PtrToStructure<ImGuiIo>(NativePtr).MetricsRenderIndices;
        
        /// <summary>
        ///     Gets the value of the metrics render windows
        /// </summary>
        public  int MetricsRenderWindows => Marshal.PtrToStructure<ImGuiIo>(NativePtr).MetricsRenderWindows;
        
        /// <summary>
        ///     Gets the value of the metrics active windows
        /// </summary>
        public  int MetricsActiveWindows => Marshal.PtrToStructure<ImGuiIo>(NativePtr).MetricsActiveWindows;
        
        /// <summary>
        ///     Gets the value of the metrics active allocations
        /// </summary>
        public  int MetricsActiveAllocations =>  Marshal.PtrToStructure<ImGuiIo>(NativePtr).MetricsActiveAllocations;
        
        /// <summary>
        ///     Gets the value of the mouse delta
        /// </summary>
        public  Vector2 MouseDelta => Marshal.PtrToStructure<ImGuiIo>(NativePtr).MouseDelta;
        
        /// <summary>
        /// Gets or sets the value of the key map
        /// </summary>
        public RangeAccessor<int> KeyMap
        {
            get
            {
                // Assuming KeyMap is the first field in ImGuiIo, adjust the offset accordingly if it's not.
                int offsetToKeyMap = Marshal.OffsetOf<ImGuiIo>("KeyMap").ToInt32();
                IntPtr keyMapPtr = IntPtr.Add(NativePtr, offsetToKeyMap);

                // Assuming the size of the key map is known to be 652
                return new RangeAccessor<int>(keyMapPtr, 652);
            }
            set
            {
                // Assuming KeyMap is the first field in ImGuiIo, adjust the offset accordingly if it's not.
                int offsetToKeyMap = Marshal.OffsetOf<ImGuiIo>("KeyMap").ToInt32();
                IntPtr keyMapPtr = IntPtr.Add(NativePtr, offsetToKeyMap);

                // Assuming the size of the key map is known to be 652
                Marshal.WriteIntPtr(keyMapPtr, value.Data);
            }
        }
        
        /// <summary>
        ///     Gets the value of the keys down
        /// </summary>
        public RangeAccessor<bool> KeysDown
        {
            get
            {
                // Assuming KeysDown is the first field in ImGuiIo, adjust the offset accordingly if it's not.
                int offsetToKeysDown = Marshal.OffsetOf<ImGuiIo>("KeysDown").ToInt32();
                IntPtr keysDownPtr = IntPtr.Add(NativePtr, offsetToKeysDown);

                // Assuming the size of the keys down is known to be 512
                return new RangeAccessor<bool>(keysDownPtr, 512);
            }
            set
            {
                // Assuming KeysDown is the first field in ImGuiIo, adjust the offset accordingly if it's not.
                int offsetToKeysDown = Marshal.OffsetOf<ImGuiIo>("KeysDown").ToInt32();
                IntPtr keysDownPtr = IntPtr.Add(NativePtr, offsetToKeysDown);

                // Assuming the size of the keys down is known to be 512
                Marshal.WriteIntPtr(keysDownPtr, value.Data);
            }
        }
        
        /// <summary>
        ///     Gets the value of the nav inputs
        /// </summary>
        public RangeAccessor<float> NavInputs
        {
            get
            {
                // Assuming NavInputs is the first field in ImGuiIo, adjust the offset accordingly if it's not.
                int offsetToNavInputs = Marshal.OffsetOf<ImGuiIo>("NavInputs").ToInt32();
                IntPtr navInputsPtr = IntPtr.Add(NativePtr, offsetToNavInputs);

                // Assuming the size of the nav inputs is known to be 21
                return new RangeAccessor<float>(navInputsPtr, 21);
            }
            set
            {
                // Assuming NavInputs is the first field in ImGuiIo, adjust the offset accordingly if it's not.
                int offsetToNavInputs = Marshal.OffsetOf<ImGuiIo>("NavInputs").ToInt32();
                IntPtr navInputsPtr = IntPtr.Add(NativePtr, offsetToNavInputs);

                // Assuming the size of the nav inputs is known to be 21
                Marshal.WriteIntPtr(navInputsPtr, value.Data);
            }
        }
        
        /// <summary>
        ///     Gets the value of the mouse pos
        /// </summary>
        public  Vector2 MousePos
        {
            get { return Marshal.PtrToStructure<ImGuiIo>(NativePtr).MousePos; }
            set
            {
                // Write x and y values to the MousePos field
                ImGuiIo io = Marshal.PtrToStructure<ImGuiIo>(NativePtr);
                io.MousePos.X = value.X;
                io.MousePos.Y = value.Y;
                Marshal.StructureToPtr(io, NativePtr, false);
            }
        }
        
        /// <summary>
        ///     Gets the value of the mouse down
        /// </summary>
        public RangeAccessor<bool> MouseDown
        {
            get
            {
                // Assuming MouseDown is the first field in ImGuiIo, adjust the offset accordingly if it's not.
                int offsetToMouseDown = Marshal.OffsetOf<ImGuiIo>("MouseDown").ToInt32();
                IntPtr mouseDownPtr = IntPtr.Add(NativePtr, offsetToMouseDown);

                // Assuming the size of the mouse down is known to be 5
                return new RangeAccessor<bool>(mouseDownPtr, 5);
            }
            set
            {
                // Assuming MouseDown is the first field in ImGuiIo, adjust the offset accordingly if it's not.
                int offsetToMouseDown = Marshal.OffsetOf<ImGuiIo>("MouseDown").ToInt32();
                IntPtr mouseDownPtr = IntPtr.Add(NativePtr, offsetToMouseDown);

                // Assuming the size of the mouse down is known to be 5
                Marshal.WriteIntPtr(mouseDownPtr, value.Data);
            }
        }
        
        /// <summary>
        ///     Gets the value of the mouse wheel
        /// </summary>
        public  float MouseWheel
        {
            get { return Marshal.PtrToStructure<ImGuiIo>(NativePtr).MouseWheel; }
            set { Marshal.WriteIntPtr(NativePtr, (int) Marshal.OffsetOf<ImGuiIo>("MouseWheel"), (IntPtr) value); }
        }
        
        /// <summary>
        ///     Gets the value of the mouse wheel h
        /// </summary>
        public  float MouseWheelH
        {
            get { return Marshal.PtrToStructure<ImGuiIo>(NativePtr).MouseWheelH; }
            set { Marshal.WriteIntPtr(NativePtr, (int) Marshal.OffsetOf<ImGuiIo>("MouseWheelH"), (IntPtr) value); }
        }
        
        /// <summary>
        ///     Gets the value of the mouse hovered viewport
        /// </summary>
        public  uint MouseHoveredViewport => Marshal.PtrToStructure<ImGuiIo>(NativePtr).MouseHoveredViewport;
        
        /// <summary>
        ///     Gets the value of the key ctrl
        /// </summary>
        public  bool KeyCtrl
        {
            get { return Marshal.PtrToStructure<ImGuiIo>(NativePtr).KeyCtrl != 0; }
            set {
                ImGuiIo io = Marshal.PtrToStructure<ImGuiIo>(NativePtr);
                io.KeyCtrl = value ? (byte) 1 : (byte) 0;
                Marshal.StructureToPtr(io, NativePtr, false);
            }
        }
        
        /// <summary>
        ///     Gets the value of the key shift
        /// </summary>
        public  bool KeyShift
        {
            get { return Marshal.PtrToStructure<ImGuiIo>(NativePtr).KeyShift != 0; }
            set {
                ImGuiIo io = Marshal.PtrToStructure<ImGuiIo>(NativePtr);
                io.KeyShift = value ? (byte) 1 : (byte) 0;
                Marshal.StructureToPtr(io, NativePtr, false);
            }
        }
        
        /// <summary>
        ///     Gets the value of the key alt
        /// </summary>
        public  bool KeyAlt
        {
            get { return Marshal.PtrToStructure<ImGuiIo>(NativePtr).KeyAlt != 0; }
            set {
                ImGuiIo io = Marshal.PtrToStructure<ImGuiIo>(NativePtr);
                io.KeyAlt = value ? (byte) 1 : (byte) 0;
                Marshal.StructureToPtr(io, NativePtr, false);
            }
        }
        
        /// <summary>
        ///     Gets the value of the key super
        /// </summary>
        public  bool KeySuper
        {
            get { return Marshal.PtrToStructure<ImGuiIo>(NativePtr).KeySuper != 0; }
            set {
                ImGuiIo io = Marshal.PtrToStructure<ImGuiIo>(NativePtr);
                io.KeySuper = value ? (byte) 1 : (byte) 0;
                Marshal.StructureToPtr(io, NativePtr, false);
            }
        }
        
        /// <summary>
        ///     Gets the value of the key mods
        /// </summary>
        public  ImGuiKey KeyMods => Marshal.PtrToStructure<ImGuiIo>(NativePtr).KeyMods;
        
        /// <summary>
        ///     Gets the value of the keys data
        /// </summary>
        public RangeAccessor<ImGuiKeyData> KeysData
        {
            get
            {
                // Assuming KeysData is the first field in ImGuiIo, adjust the offset accordingly if it's not.
                int offsetToKeysData = Marshal.OffsetOf<ImGuiIo>("KeysData").ToInt32();
                IntPtr keysDataPtr = IntPtr.Add(NativePtr, offsetToKeysData);

                // Assuming the size of the keys data is known to be 512
                return new RangeAccessor<ImGuiKeyData>(keysDataPtr, 512);
            }
            set
            {
                // Assuming KeysData is the first field in ImGuiIo, adjust the offset accordingly if it's not.
                int offsetToKeysData = Marshal.OffsetOf<ImGuiIo>("KeysData").ToInt32();
                IntPtr keysDataPtr = IntPtr.Add(NativePtr, offsetToKeysData);

                // Assuming the size of the keys data is known to be 512
                Marshal.WriteIntPtr(keysDataPtr, value.Data);
            }
        }
        
        /// <summary>
        ///     Gets the value of the want capture mouse unless popup close
        /// </summary>
        public  bool WantCaptureMouseUnlessPopupClose => Marshal.PtrToStructure<ImGuiIo>(NativePtr).WantCaptureMouseUnlessPopupClose != 0;
        
        /// <summary>
        ///     Gets the value of the mouse pos prev
        /// </summary>
        public  Vector2 MousePosPrev => Marshal.PtrToStructure<ImGuiIo>(NativePtr).MousePosPrev;
        
        /// <summary>
        ///     Gets the value of the mouse clicked pos
        /// </summary>
        public RangeAccessor<Vector2> MouseClickedPos
        {
            get
            {
                // Assuming MouseClickedPos is the first field in ImGuiIo, adjust the offset accordingly if it's not.
                int offsetToMouseClickedPos = Marshal.OffsetOf<ImGuiIo>("MouseClickedPos").ToInt32();
                IntPtr mouseClickedPosPtr = IntPtr.Add(NativePtr, offsetToMouseClickedPos);

                // Assuming the size of the mouse clicked pos is known to be 5
                return new RangeAccessor<Vector2>(mouseClickedPosPtr, 5);
            }
            set
            {
                // Assuming MouseClickedPos is the first field in ImGuiIo, adjust the offset accordingly if it's not.
                int offsetToMouseClickedPos = Marshal.OffsetOf<ImGuiIo>("MouseClickedPos").ToInt32();
                IntPtr mouseClickedPosPtr = IntPtr.Add(NativePtr, offsetToMouseClickedPos);

                // Assuming the size of the mouse clicked pos is known to be 5
                Marshal.WriteIntPtr(mouseClickedPosPtr, value.Data);
            }
        }
        
        /// <summary>
        ///     Gets the value of the mouse clicked time
        /// </summary>
        public RangeAccessor<double> MouseClickedTime
        {
            get
            {
                // Assuming MouseClickedTime is the first field in ImGuiIo, adjust the offset accordingly if it's not.
                int offsetToMouseClickedTime = Marshal.OffsetOf<ImGuiIo>("MouseClickedTime").ToInt32();
                IntPtr mouseClickedTimePtr = IntPtr.Add(NativePtr, offsetToMouseClickedTime);

                // Assuming the size of the mouse clicked time is known to be 5
                return new RangeAccessor<double>(mouseClickedTimePtr, 5);
            }
            set
            {
                // Assuming MouseClickedTime is the first field in ImGuiIo, adjust the offset accordingly if it's not.
                int offsetToMouseClickedTime = Marshal.OffsetOf<ImGuiIo>("MouseClickedTime").ToInt32();
                IntPtr mouseClickedTimePtr = IntPtr.Add(NativePtr, offsetToMouseClickedTime);

                // Assuming the size of the mouse clicked time is known to be 5
                Marshal.WriteIntPtr(mouseClickedTimePtr, value.Data);
            }
        }
        
        /// <summary>
        ///     Gets the value of the mouse clicked
        /// </summary>
        public RangeAccessor<bool> MouseClicked
        {
            get
            {
                // Assuming MouseClicked is the first field in ImGuiIo, adjust the offset accordingly if it's not.
                int offsetToMouseClicked = Marshal.OffsetOf<ImGuiIo>("MouseClicked").ToInt32();
                IntPtr mouseClickedPtr = IntPtr.Add(NativePtr, offsetToMouseClicked);

                // Assuming the size of the mouse clicked is known to be 5
                return new RangeAccessor<bool>(mouseClickedPtr, 5);
            }
            set
            {
                // Assuming MouseClicked is the first field in ImGuiIo, adjust the offset accordingly if it's not.
                int offsetToMouseClicked = Marshal.OffsetOf<ImGuiIo>("MouseClicked").ToInt32();
                IntPtr mouseClickedPtr = IntPtr.Add(NativePtr, offsetToMouseClicked);

                // Assuming the size of the mouse clicked is known to be 5
                Marshal.WriteIntPtr(mouseClickedPtr, value.Data);
            }
        }
        
        /// <summary>
        ///     Gets the value of the mouse double clicked
        /// </summary>
        public RangeAccessor<bool> MouseDoubleClicked
        {
            get
            {
                // Assuming MouseDoubleClicked is the first field in ImGuiIo, adjust the offset accordingly if it's not.
                int offsetToMouseDoubleClicked = Marshal.OffsetOf<ImGuiIo>("MouseDoubleClicked").ToInt32();
                IntPtr mouseDoubleClickedPtr = IntPtr.Add(NativePtr, offsetToMouseDoubleClicked);

                // Assuming the size of the mouse double clicked is known to be 5
                return new RangeAccessor<bool>(mouseDoubleClickedPtr, 5);
            }
            set
            {
                // Assuming MouseDoubleClicked is the first field in ImGuiIo, adjust the offset accordingly if it's not.
                int offsetToMouseDoubleClicked = Marshal.OffsetOf<ImGuiIo>("MouseDoubleClicked").ToInt32();
                IntPtr mouseDoubleClickedPtr = IntPtr.Add(NativePtr, offsetToMouseDoubleClicked);

                // Assuming the size of the mouse double clicked is known to be 5
                Marshal.WriteIntPtr(mouseDoubleClickedPtr, value.Data);
            }
        }
        
        /// <summary>
        ///     Gets the value of the mouse clicked count
        /// </summary>
        public RangeAccessor<ushort> MouseClickedCount
        {
            get
            {
                // Assuming MouseClickedCount is the first field in ImGuiIo, adjust the offset accordingly if it's not.
                int offsetToMouseClickedCount = Marshal.OffsetOf<ImGuiIo>("MouseClickedCount").ToInt32();
                IntPtr mouseClickedCountPtr = IntPtr.Add(NativePtr, offsetToMouseClickedCount);

                // Assuming the size of the mouse clicked count is known to be 5
                return new RangeAccessor<ushort>(mouseClickedCountPtr, 5);
            }
            set
            {
                // Assuming MouseClickedCount is the first field in ImGuiIo, adjust the offset accordingly if it's not.
                int offsetToMouseClickedCount = Marshal.OffsetOf<ImGuiIo>("MouseClickedCount").ToInt32();
                IntPtr mouseClickedCountPtr = IntPtr.Add(NativePtr, offsetToMouseClickedCount);

                // Assuming the size of the mouse clicked count is known to be 5
                Marshal.WriteIntPtr(mouseClickedCountPtr, value.Data);
            }
        }
        
        /// <summary>
        ///     Gets the value of the mouse clicked last count
        /// </summary>
        public RangeAccessor<ushort> MouseClickedLastCount
        {
            get
            {
                // Assuming MouseClickedLastCount is the first field in ImGuiIo, adjust the offset accordingly if it's not.
                int offsetToMouseClickedLastCount = Marshal.OffsetOf<ImGuiIo>("MouseClickedLastCount").ToInt32();
                IntPtr mouseClickedLastCountPtr = IntPtr.Add(NativePtr, offsetToMouseClickedLastCount);

                // Assuming the size of the mouse clicked last count is known to be 5
                return new RangeAccessor<ushort>(mouseClickedLastCountPtr, 5);
            }
            set
            {
                // Assuming MouseClickedLastCount is the first field in ImGuiIo, adjust the offset accordingly if it's not.
                int offsetToMouseClickedLastCount = Marshal.OffsetOf<ImGuiIo>("MouseClickedLastCount").ToInt32();
                IntPtr mouseClickedLastCountPtr = IntPtr.Add(NativePtr, offsetToMouseClickedLastCount);

                // Assuming the size of the mouse clicked last count is known to be 5
                Marshal.WriteIntPtr(mouseClickedLastCountPtr, value.Data);
            }
        }
        
        /// <summary>
        ///     Gets the value of the mouse released
        /// </summary>
        public RangeAccessor<bool> MouseReleased
        {
            get
            {
                // Assuming MouseReleased is the first field in ImGuiIo, adjust the offset accordingly if it's not.
                int offsetToMouseReleased = Marshal.OffsetOf<ImGuiIo>("MouseReleased").ToInt32();
                IntPtr mouseReleasedPtr = IntPtr.Add(NativePtr, offsetToMouseReleased);

                // Assuming the size of the mouse released is known to be 5
                return new RangeAccessor<bool>(mouseReleasedPtr, 5);
            }
            set
            {
                // Assuming MouseReleased is the first field in ImGuiIo, adjust the offset accordingly if it's not.
                int offsetToMouseReleased = Marshal.OffsetOf<ImGuiIo>("MouseReleased").ToInt32();
                IntPtr mouseReleasedPtr = IntPtr.Add(NativePtr, offsetToMouseReleased);

                // Assuming the size of the mouse released is known to be 5
                Marshal.WriteIntPtr(mouseReleasedPtr, value.Data);
            }
        }
        
        /// <summary>
        ///     Gets the value of the mouse down owned
        /// </summary>
        public RangeAccessor<bool> MouseDownOwned
        {
            get
            {
                // Assuming MouseDownOwned is the first field in ImGuiIo, adjust the offset accordingly if it's not.
                int offsetToMouseDownOwned = Marshal.OffsetOf<ImGuiIo>("MouseDownOwned").ToInt32();
                IntPtr mouseDownOwnedPtr = IntPtr.Add(NativePtr, offsetToMouseDownOwned);

                // Assuming the size of the mouse down owned is known to be 5
                return new RangeAccessor<bool>(mouseDownOwnedPtr, 5);
            }
            set
            {
                // Assuming MouseDownOwned is the first field in ImGuiIo, adjust the offset accordingly if it's not.
                int offsetToMouseDownOwned = Marshal.OffsetOf<ImGuiIo>("MouseDownOwned").ToInt32();
                IntPtr mouseDownOwnedPtr = IntPtr.Add(NativePtr, offsetToMouseDownOwned);

                // Assuming the size of the mouse down owned is known to be 5
                Marshal.WriteIntPtr(mouseDownOwnedPtr, value.Data);
            }
        }
        
        /// <summary>
        ///     Gets the value of the mouse down owned unless popup close
        /// </summary>
        public RangeAccessor<bool> MouseDownOwnedUnlessPopupClose
        {
            get
            {
                // Assuming MouseDownOwnedUnlessPopupClose is the first field in ImGuiIo, adjust the offset accordingly if it's not.
                int offsetToMouseDownOwnedUnlessPopupClose = Marshal.OffsetOf<ImGuiIo>("MouseDownOwnedUnlessPopupClose").ToInt32();
                IntPtr mouseDownOwnedUnlessPopupClosePtr = IntPtr.Add(NativePtr, offsetToMouseDownOwnedUnlessPopupClose);

                // Assuming the size of the mouse down owned unless popup close is known to be 5
                return new RangeAccessor<bool>(mouseDownOwnedUnlessPopupClosePtr, 5);
            }
            set
            {
                // Assuming MouseDownOwnedUnlessPopupClose is the first field in ImGuiIo, adjust the offset accordingly if it's not.
                int offsetToMouseDownOwnedUnlessPopupClose = Marshal.OffsetOf<ImGuiIo>("MouseDownOwnedUnlessPopupClose").ToInt32();
                IntPtr mouseDownOwnedUnlessPopupClosePtr = IntPtr.Add(NativePtr, offsetToMouseDownOwnedUnlessPopupClose);

                // Assuming the size of the mouse down owned unless popup close is known to be 5
                Marshal.WriteIntPtr(mouseDownOwnedUnlessPopupClosePtr, value.Data);
            }
        }
        
        /// <summary>
        ///     Gets the value of the mouse down duration
        /// </summary>
        public RangeAccessor<float> MouseDownDuration
        {
            get
            {
                // Assuming MouseDownDuration is the first field in ImGuiIo, adjust the offset accordingly if it's not.
                int offsetToMouseDownDuration = Marshal.OffsetOf<ImGuiIo>("MouseDownDuration").ToInt32();
                IntPtr mouseDownDurationPtr = IntPtr.Add(NativePtr, offsetToMouseDownDuration);

                // Assuming the size of the mouse down duration is known to be 5
                return new RangeAccessor<float>(mouseDownDurationPtr, 5);
            }
            set
            {
                // Assuming MouseDownDuration is the first field in ImGuiIo, adjust the offset accordingly if it's not.
                int offsetToMouseDownDuration = Marshal.OffsetOf<ImGuiIo>("MouseDownDuration").ToInt32();
                IntPtr mouseDownDurationPtr = IntPtr.Add(NativePtr, offsetToMouseDownDuration);

                // Assuming the size of the mouse down duration is known to be 5
                Marshal.WriteIntPtr(mouseDownDurationPtr, value.Data);
            }
        }
        
        /// <summary>
        ///     Gets the value of the mouse down duration prev
        /// </summary>
        public RangeAccessor<float> MouseDownDurationPrev
        {
            get
            {
                // Assuming MouseDownDurationPrev is the first field in ImGuiIo, adjust the offset accordingly if it's not.
                int offsetToMouseDownDurationPrev = Marshal.OffsetOf<ImGuiIo>("MouseDownDurationPrev").ToInt32();
                IntPtr mouseDownDurationPrevPtr = IntPtr.Add(NativePtr, offsetToMouseDownDurationPrev);

                // Assuming the size of the mouse down duration prev is known to be 5
                return new RangeAccessor<float>(mouseDownDurationPrevPtr, 5);
            }
            set
            {
                // Assuming MouseDownDurationPrev is the first field in ImGuiIo, adjust the offset accordingly if it's not.
                int offsetToMouseDownDurationPrev = Marshal.OffsetOf<ImGuiIo>("MouseDownDurationPrev").ToInt32();
                IntPtr mouseDownDurationPrevPtr = IntPtr.Add(NativePtr, offsetToMouseDownDurationPrev);

                // Assuming the size of the mouse down duration prev is known to be 5
                Marshal.WriteIntPtr(mouseDownDurationPrevPtr, value.Data);
            }
        }
        
        /// <summary>
        ///     Gets the value of the mouse drag max distance abs
        /// </summary>
        public RangeAccessor<Vector2> MouseDragMaxDistanceAbs
        {
            get
            {
                // Assuming MouseDragMaxDistanceAbs is the first field in ImGuiIo, adjust the offset accordingly if it's not.
                int offsetToMouseDragMaxDistanceAbs = Marshal.OffsetOf<ImGuiIo>("MouseDragMaxDistanceAbs").ToInt32();
                IntPtr mouseDragMaxDistanceAbsPtr = IntPtr.Add(NativePtr, offsetToMouseDragMaxDistanceAbs);

                // Assuming the size of the mouse drag max distance abs is known to be 5
                return new RangeAccessor<Vector2>(mouseDragMaxDistanceAbsPtr, 5);
            }
            set
            {
                // Assuming MouseDragMaxDistanceAbs is the first field in ImGuiIo, adjust the offset accordingly if it's not.
                int offsetToMouseDragMaxDistanceAbs = Marshal.OffsetOf<ImGuiIo>("MouseDragMaxDistanceAbs").ToInt32();
                IntPtr mouseDragMaxDistanceAbsPtr = IntPtr.Add(NativePtr, offsetToMouseDragMaxDistanceAbs);

                // Assuming the size of the mouse drag max distance abs is known to be 5
                Marshal.WriteIntPtr(mouseDragMaxDistanceAbsPtr, value.Data);
            }
        }
        
        /// <summary>
        ///     Gets the value of the mouse drag max distance sqr
        /// </summary>
        public RangeAccessor<float> MouseDragMaxDistanceSqr
        {
            get
            {
                // Assuming MouseDragMaxDistanceSqr is the first field in ImGuiIo, adjust the offset accordingly if it's not.
                int offsetToMouseDragMaxDistanceSqr = Marshal.OffsetOf<ImGuiIo>("MouseDragMaxDistanceSqr").ToInt32();
                IntPtr mouseDragMaxDistanceSqrPtr = IntPtr.Add(NativePtr, offsetToMouseDragMaxDistanceSqr);

                // Assuming the size of the mouse drag max distance sqr is known to be 5
                return new RangeAccessor<float>(mouseDragMaxDistanceSqrPtr, 5);
            }
            set
            {
                // Assuming MouseDragMaxDistanceSqr is the first field in ImGuiIo, adjust the offset accordingly if it's not.
                int offsetToMouseDragMaxDistanceSqr = Marshal.OffsetOf<ImGuiIo>("MouseDragMaxDistanceSqr").ToInt32();
                IntPtr mouseDragMaxDistanceSqrPtr = IntPtr.Add(NativePtr, offsetToMouseDragMaxDistanceSqr);

                // Assuming the size of the mouse drag max distance sqr is known to be 5
                Marshal.WriteIntPtr(mouseDragMaxDistanceSqrPtr, value.Data);
            }
        }
        
        /// <summary>
        ///     Gets the value of the pen pressure
        /// </summary>
        public  float PenPressure => Marshal.PtrToStructure<ImGuiIo>(NativePtr).PenPressure;
        
        /// <summary>
        ///     Gets the value of the app focus lost
        /// </summary>
        public  bool AppFocusLost => Marshal.PtrToStructure<ImGuiIo>(NativePtr).AppFocusLost != 0;
        
        /// <summary>
        ///     Gets the value of the app accepting events
        /// </summary>
        public  bool AppAcceptingEvents => Marshal.PtrToStructure<ImGuiIo>(NativePtr).AppAcceptingEvents != 0;
        
        /// <summary>
        ///     Gets the value of the backend using legacy key arrays
        /// </summary>
        public  sbyte BackendUsingLegacyKeyArrays => Marshal.PtrToStructure<ImGuiIo>(NativePtr).BackendUsingLegacyKeyArrays;
        
        /// <summary>
        ///     Gets the value of the backend using legacy nav input array
        /// </summary>
        public  bool BackendUsingLegacyNavInputArray => Marshal.PtrToStructure<ImGuiIo>(NativePtr).BackendUsingLegacyNavInputArray != 0;
        
        /// <summary>
        ///     Gets the value of the input queue surrogate
        /// </summary>
        public  ushort InputQueueSurrogate => Marshal.PtrToStructure<ImGuiIo>(NativePtr).InputQueueSurrogate;
        
        /// <summary>
        ///     Gets the value of the input queue characters
        /// </summary>
        public ImVectorG<ushort> InputQueueCharacters => new ImVectorG<ushort>(Marshal.PtrToStructure<ImGuiIo>(NativePtr).InputQueueCharacters);
        
        /// <summary>
        ///     Adds the focus event using the specified focused
        /// </summary>
        /// <param name="focused">The focused</param>
        public void AddFocusEvent(bool focused)
        {
            byte nativeFocused = focused ? (byte) 1 : (byte) 0;
            ImGuiNative.ImGuiIO_AddFocusEvent((IntPtr)NativePtr, nativeFocused);
        }
        
        /// <summary>
        ///     Adds the input character using the specified c
        /// </summary>
        /// <param name="c">The </param>
        public void AddInputCharacter(uint c)
        {
            ImGuiNative.ImGuiIO_AddInputCharacter((IntPtr)NativePtr, c);
        }
        
        /// <summary>
        ///     Adds the input characters utf 8 using the specified str
        /// </summary>
        /// <param name="str">The str</param>
        public void AddInputCharactersUtf8(string str)
        {
            ImGuiNative.ImGuiIO_AddInputCharactersUTF8((IntPtr)NativePtr,Encoding.UTF8.GetBytes(str));
        }
        
        /// <summary>
        ///     Adds the input character utf 16 using the specified c
        /// </summary>
        /// <param name="c">The </param>
        public void AddInputCharacterUtf16(ushort c)
        {
            ImGuiNative.ImGuiIO_AddInputCharacterUTF16((IntPtr)NativePtr, c);
        }
        
        /// <summary>
        ///     Adds the key analog event using the specified key
        /// </summary>
        /// <param name="key">The key</param>
        /// <param name="down">The down</param>
        /// <param name="v">The </param>
        public void AddKeyAnalogEvent(ImGuiKey key, bool down, float v)
        {
            byte nativeDown = down ? (byte) 1 : (byte) 0;
            ImGuiNative.ImGuiIO_AddKeyAnalogEvent((IntPtr)NativePtr, key, nativeDown, v);
        }
        
        /// <summary>
        ///     Adds the key event using the specified key
        /// </summary>
        /// <param name="key">The key</param>
        /// <param name="down">The down</param>
        public void AddKeyEvent(ImGuiKey key, bool down)
        {
            byte nativeDown = down ? (byte) 1 : (byte) 0;
            ImGuiNative.ImGuiIO_AddKeyEvent((IntPtr)NativePtr, key, nativeDown);
        }
        
        /// <summary>
        ///     Adds the mouse button event using the specified button
        /// </summary>
        /// <param name="button">The button</param>
        /// <param name="down">The down</param>
        public void AddMouseButtonEvent(int button, bool down)
        {
            byte nativeDown = down ? (byte) 1 : (byte) 0;
            ImGuiNative.ImGuiIO_AddMouseButtonEvent((IntPtr)NativePtr, button, nativeDown);
        }
        
        /// <summary>
        ///     Adds the mouse pos event using the specified x
        /// </summary>
        /// <param name="x">The </param>
        /// <param name="y">The </param>
        public void AddMousePosEvent(float x, float y)
        {
            ImGuiNative.ImGuiIO_AddMousePosEvent((IntPtr)NativePtr, x, y);
        }
        
        /// <summary>
        ///     Adds the mouse viewport event using the specified id
        /// </summary>
        /// <param name="id">The id</param>
        public void AddMouseViewportEvent(uint id)
        {
            ImGuiNative.ImGuiIO_AddMouseViewportEvent((IntPtr)NativePtr, id);
        }
        
        /// <summary>
        ///     Adds the mouse wheel event using the specified wh x
        /// </summary>
        /// <param name="whX">The wh</param>
        /// <param name="whY">The wh</param>
        public void AddMouseWheelEvent(float whX, float whY)
        {
            ImGuiNative.ImGuiIO_AddMouseWheelEvent((IntPtr)NativePtr, whX, whY);
        }
        
        /// <summary>
        ///     Clears the input characters
        /// </summary>
        public void ClearInputCharacters()
        {
            ImGuiNative.ImGuiIO_ClearInputCharacters((IntPtr)NativePtr);
        }
        
        /// <summary>
        ///     Clears the input keys
        /// </summary>
        public void ClearInputKeys()
        {
            ImGuiNative.ImGuiIO_ClearInputKeys((IntPtr)NativePtr);
        }
        
        /// <summary>
        ///     Destroys this instance
        /// </summary>
        public void Destroy()
        {
            ImGuiNative.ImGuiIO_destroy((IntPtr)NativePtr);
        }
        
        /// <summary>
        ///     Sets the app accepting events using the specified accepting events
        /// </summary>
        /// <param name="acceptingEvents">The accepting events</param>
        public void SetAppAcceptingEvents(bool acceptingEvents)
        {
            byte nativeAcceptingEvents = acceptingEvents ? (byte) 1 : (byte) 0;
            ImGuiNative.ImGuiIO_SetAppAcceptingEvents((IntPtr)NativePtr, nativeAcceptingEvents);
        }
        
        /// <summary>
        ///     Sets the key event native data using the specified key
        /// </summary>
        /// <param name="key">The key</param>
        /// <param name="nativeKeycode">The native keycode</param>
        /// <param name="nativeScancode">The native scancode</param>
        public void SetKeyEventNativeData(ImGuiKey key, int nativeKeycode, int nativeScancode)
        {
            int nativeLegacyIndex = -1;
            ImGuiNative.ImGuiIO_SetKeyEventNativeData((IntPtr)NativePtr, key, nativeKeycode, nativeScancode, nativeLegacyIndex);
        }
        
        /// <summary>
        ///     Sets the key event native data using the specified key
        /// </summary>
        /// <param name="key">The key</param>
        /// <param name="nativeKeycode">The native keycode</param>
        /// <param name="nativeScancode">The native scancode</param>
        /// <param name="nativeLegacyIndex">The native legacy index</param>
        public void SetKeyEventNativeData(ImGuiKey key, int nativeKeycode, int nativeScancode, int nativeLegacyIndex)
        {
            ImGuiNative.ImGuiIO_SetKeyEventNativeData((IntPtr)NativePtr, key, nativeKeycode, nativeScancode, nativeLegacyIndex);
        }
    }
}