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
using System.Text;
using Alis.Core.Aspect.Math.Vector;

namespace Alis.Core.Graphic.ImGui
{
    /// <summary>
    ///     The im gui io ptr
    /// </summary>
    public unsafe struct ImGuiIoPtr
    {
        /// <summary>
        ///     Gets the value of the native ptr
        /// </summary>
        public ImGuiIo* NativePtr { get; }

        /// <summary>
        ///     Initializes a new instance of the <see cref="ImGuiIoPtr" /> class
        /// </summary>
        /// <param name="nativePtr">The native ptr</param>
        public ImGuiIoPtr(ImGuiIo* nativePtr) => NativePtr = nativePtr;

        /// <summary>
        ///     Initializes a new instance of the <see cref="ImGuiIoPtr" /> class
        /// </summary>
        /// <param name="nativePtr">The native ptr</param>
        public ImGuiIoPtr(IntPtr nativePtr) => NativePtr = (ImGuiIo*) nativePtr;

        /// <summary>
        /// </summary>
        /// <param name="nativePtr"></param>
        /// <returns></returns>
        public static implicit operator ImGuiIoPtr(ImGuiIo* nativePtr) => new ImGuiIoPtr(nativePtr);

        /// <summary>
        ///     /
        /// </summary>
        /// <param name="wrappedPtr"></param>
        /// <returns></returns>
        public static implicit operator ImGuiIo*(ImGuiIoPtr wrappedPtr) => wrappedPtr.NativePtr;

        /// <summary>
        /// </summary>
        /// <param name="nativePtr"></param>
        /// <returns></returns>
        public static implicit operator ImGuiIoPtr(IntPtr nativePtr) => new ImGuiIoPtr(nativePtr);

        /// <summary>
        ///     Gets the value of the config flags
        /// </summary>
        public ref ImGuiConfigFlags ConfigFlags => ref Unsafe.AsRef<ImGuiConfigFlags>(&NativePtr->ConfigFlags);

        /// <summary>
        ///     Gets the value of the backend flags
        /// </summary>
        public ref ImGuiBackendFlags BackendFlags => ref Unsafe.AsRef<ImGuiBackendFlags>(&NativePtr->BackendFlags);

        /// <summary>
        ///     Gets the value of the display size
        /// </summary>
        public ref Vector2 DisplaySize => ref Unsafe.AsRef<Vector2>(&NativePtr->DisplaySize);

        /// <summary>
        ///     Gets the value of the delta time
        /// </summary>
        public ref float DeltaTime => ref Unsafe.AsRef<float>(&NativePtr->DeltaTime);

        /// <summary>
        ///     Gets the value of the ini saving rate
        /// </summary>
        public ref float IniSavingRate => ref Unsafe.AsRef<float>(&NativePtr->IniSavingRate);

        /// <summary>
        ///     Gets the value of the ini filename
        /// </summary>
        public NullTerminatedString IniFilename => new NullTerminatedString(NativePtr->IniFilename);

        /// <summary>
        ///     Gets the value of the log filename
        /// </summary>
        public NullTerminatedString LogFilename => new NullTerminatedString(NativePtr->LogFilename);

        /// <summary>
        ///     Gets the value of the mouse double click time
        /// </summary>
        public ref float MouseDoubleClickTime => ref Unsafe.AsRef<float>(&NativePtr->MouseDoubleClickTime);

        /// <summary>
        ///     Gets the value of the mouse double click max dist
        /// </summary>
        public ref float MouseDoubleClickMaxDist => ref Unsafe.AsRef<float>(&NativePtr->MouseDoubleClickMaxDist);

        /// <summary>
        ///     Gets the value of the mouse drag threshold
        /// </summary>
        public ref float MouseDragThreshold => ref Unsafe.AsRef<float>(&NativePtr->MouseDragThreshold);

        /// <summary>
        ///     Gets the value of the key repeat delay
        /// </summary>
        public ref float KeyRepeatDelay => ref Unsafe.AsRef<float>(&NativePtr->KeyRepeatDelay);

        /// <summary>
        ///     Gets the value of the key repeat rate
        /// </summary>
        public ref float KeyRepeatRate => ref Unsafe.AsRef<float>(&NativePtr->KeyRepeatRate);

        /// <summary>
        ///     Gets the value of the hover delay normal
        /// </summary>
        public ref float HoverDelayNormal => ref Unsafe.AsRef<float>(&NativePtr->HoverDelayNormal);

        /// <summary>
        ///     Gets the value of the hover delay short
        /// </summary>
        public ref float HoverDelayShort => ref Unsafe.AsRef<float>(&NativePtr->HoverDelayShort);

        /// <summary>
        ///     Gets or sets the value of the user data
        /// </summary>
        public IntPtr UserData
        {
            get => (IntPtr) NativePtr->UserData;
            set => NativePtr->UserData = (void*) value;
        }

        /// <summary>
        ///     Gets the value of the fonts
        /// </summary>
        public ImFontAtlasPtr Fonts => new ImFontAtlasPtr(NativePtr->Fonts);

        /// <summary>
        ///     Gets the value of the font global scale
        /// </summary>
        public ref float FontGlobalScale => ref Unsafe.AsRef<float>(&NativePtr->FontGlobalScale);

        /// <summary>
        ///     Gets the value of the font allow user scaling
        /// </summary>
        public ref bool FontAllowUserScaling => ref Unsafe.AsRef<bool>(&NativePtr->FontAllowUserScaling);

        /// <summary>
        ///     Gets the value of the font default
        /// </summary>
        public ImFontPtr FontDefault => new ImFontPtr(NativePtr->FontDefault);

        /// <summary>
        ///     Gets the value of the display framebuffer scale
        /// </summary>
        public ref Vector2 DisplayFramebufferScale => ref Unsafe.AsRef<Vector2>(&NativePtr->DisplayFramebufferScale);

        /// <summary>
        ///     Gets the value of the config docking no split
        /// </summary>
        public ref bool ConfigDockingNoSplit => ref Unsafe.AsRef<bool>(&NativePtr->ConfigDockingNoSplit);

        /// <summary>
        ///     Gets the value of the config docking with shift
        /// </summary>
        public ref bool ConfigDockingWithShift => ref Unsafe.AsRef<bool>(&NativePtr->ConfigDockingWithShift);

        /// <summary>
        ///     Gets the value of the config docking always tab bar
        /// </summary>
        public ref bool ConfigDockingAlwaysTabBar => ref Unsafe.AsRef<bool>(&NativePtr->ConfigDockingAlwaysTabBar);

        /// <summary>
        ///     Gets the value of the config docking transparent payload
        /// </summary>
        public ref bool ConfigDockingTransparentPayload => ref Unsafe.AsRef<bool>(&NativePtr->ConfigDockingTransparentPayload);

        /// <summary>
        ///     Gets the value of the config viewports no auto merge
        /// </summary>
        public ref bool ConfigViewportsNoAutoMerge => ref Unsafe.AsRef<bool>(&NativePtr->ConfigViewportsNoAutoMerge);

        /// <summary>
        ///     Gets the value of the config viewports no task bar icon
        /// </summary>
        public ref bool ConfigViewportsNoTaskBarIcon => ref Unsafe.AsRef<bool>(&NativePtr->ConfigViewportsNoTaskBarIcon);

        /// <summary>
        ///     Gets the value of the config viewports no decoration
        /// </summary>
        public ref bool ConfigViewportsNoDecoration => ref Unsafe.AsRef<bool>(&NativePtr->ConfigViewportsNoDecoration);

        /// <summary>
        ///     Gets the value of the config viewports no default parent
        /// </summary>
        public ref bool ConfigViewportsNoDefaultParent => ref Unsafe.AsRef<bool>(&NativePtr->ConfigViewportsNoDefaultParent);

        /// <summary>
        ///     Gets the value of the mouse draw cursor
        /// </summary>
        public ref bool MouseDrawCursor => ref Unsafe.AsRef<bool>(&NativePtr->MouseDrawCursor);

        /// <summary>
        ///     Gets the value of the config mac osx behaviors
        /// </summary>
        public ref bool ConfigMacOsxBehaviors => ref Unsafe.AsRef<bool>(&NativePtr->ConfigMacOsxBehaviors);

        /// <summary>
        ///     Gets the value of the config input trickle event queue
        /// </summary>
        public ref bool ConfigInputTrickleEventQueue => ref Unsafe.AsRef<bool>(&NativePtr->ConfigInputTrickleEventQueue);

        /// <summary>
        ///     Gets the value of the config input text cursor blink
        /// </summary>
        public ref bool ConfigInputTextCursorBlink => ref Unsafe.AsRef<bool>(&NativePtr->ConfigInputTextCursorBlink);

        /// <summary>
        ///     Gets the value of the config input text enter keep active
        /// </summary>
        public ref bool ConfigInputTextEnterKeepActive => ref Unsafe.AsRef<bool>(&NativePtr->ConfigInputTextEnterKeepActive);

        /// <summary>
        ///     Gets the value of the config drag click to input text
        /// </summary>
        public ref bool ConfigDragClickToInputText => ref Unsafe.AsRef<bool>(&NativePtr->ConfigDragClickToInputText);

        /// <summary>
        ///     Gets the value of the config windows resize from edges
        /// </summary>
        public ref bool ConfigWindowsResizeFromEdges => ref Unsafe.AsRef<bool>(&NativePtr->ConfigWindowsResizeFromEdges);

        /// <summary>
        ///     Gets the value of the config windows move from title bar only
        /// </summary>
        public ref bool ConfigWindowsMoveFromTitleBarOnly => ref Unsafe.AsRef<bool>(&NativePtr->ConfigWindowsMoveFromTitleBarOnly);

        /// <summary>
        ///     Gets the value of the config memory compact timer
        /// </summary>
        public ref float ConfigMemoryCompactTimer => ref Unsafe.AsRef<float>(&NativePtr->ConfigMemoryCompactTimer);

        /// <summary>
        ///     Gets the value of the config debug begin return value once
        /// </summary>
        public ref bool ConfigDebugBeginReturnValueOnce => ref Unsafe.AsRef<bool>(&NativePtr->ConfigDebugBeginReturnValueOnce);

        /// <summary>
        ///     Gets the value of the config debug begin return value loop
        /// </summary>
        public ref bool ConfigDebugBeginReturnValueLoop => ref Unsafe.AsRef<bool>(&NativePtr->ConfigDebugBeginReturnValueLoop);

        /// <summary>
        ///     Gets the value of the backend platform name
        /// </summary>
        public NullTerminatedString BackendPlatformName => new NullTerminatedString(NativePtr->BackendPlatformName);

        /// <summary>
        ///     Gets the value of the backend renderer name
        /// </summary>
        public NullTerminatedString BackendRendererName => new NullTerminatedString(NativePtr->BackendRendererName);

        /// <summary>
        ///     Gets or sets the value of the backend platform user data
        /// </summary>
        public IntPtr BackendPlatformUserData
        {
            get => (IntPtr) NativePtr->BackendPlatformUserData;
            set => NativePtr->BackendPlatformUserData = (void*) value;
        }

        /// <summary>
        ///     Gets or sets the value of the backend renderer user data
        /// </summary>
        public IntPtr BackendRendererUserData
        {
            get => (IntPtr) NativePtr->BackendRendererUserData;
            set => NativePtr->BackendRendererUserData = (void*) value;
        }

        /// <summary>
        ///     Gets or sets the value of the backend language user data
        /// </summary>
        public IntPtr BackendLanguageUserData
        {
            get => (IntPtr) NativePtr->BackendLanguageUserData;
            set => NativePtr->BackendLanguageUserData = (void*) value;
        }

        /// <summary>
        ///     Gets the value of the get clipboard text fn
        /// </summary>
        public ref IntPtr GetClipboardTextFn => ref Unsafe.AsRef<IntPtr>(&NativePtr->GetClipboardTextFn);

        /// <summary>
        ///     Gets the value of the set clipboard text fn
        /// </summary>
        public ref IntPtr SetClipboardTextFn => ref Unsafe.AsRef<IntPtr>(&NativePtr->SetClipboardTextFn);

        /// <summary>
        ///     Gets or sets the value of the clipboard user data
        /// </summary>
        public IntPtr ClipboardUserData
        {
            get => (IntPtr) NativePtr->ClipboardUserData;
            set => NativePtr->ClipboardUserData = (void*) value;
        }

        /// <summary>
        ///     Gets the value of the set platform ime data fn
        /// </summary>
        public ref IntPtr SetPlatformImeDataFn => ref Unsafe.AsRef<IntPtr>(&NativePtr->SetPlatformImeDataFn);

        /// <summary>
        ///     Gets or sets the value of the  unusedpadding
        /// </summary>
        public IntPtr UnusedPadding
        {
            get => (IntPtr) NativePtr->UnusedPadding;
            set => NativePtr->UnusedPadding = (void*) value;
        }

        /// <summary>
        ///     Gets the value of the want capture mouse
        /// </summary>
        public ref bool WantCaptureMouse => ref Unsafe.AsRef<bool>(&NativePtr->WantCaptureMouse);

        /// <summary>
        ///     Gets the value of the want capture keyboard
        /// </summary>
        public ref bool WantCaptureKeyboard => ref Unsafe.AsRef<bool>(&NativePtr->WantCaptureKeyboard);

        /// <summary>
        ///     Gets the value of the want text input
        /// </summary>
        public ref bool WantTextInput => ref Unsafe.AsRef<bool>(&NativePtr->WantTextInput);

        /// <summary>
        ///     Gets the value of the want set mouse pos
        /// </summary>
        public ref bool WantSetMousePos => ref Unsafe.AsRef<bool>(&NativePtr->WantSetMousePos);

        /// <summary>
        ///     Gets the value of the want save ini settings
        /// </summary>
        public ref bool WantSaveIniSettings => ref Unsafe.AsRef<bool>(&NativePtr->WantSaveIniSettings);

        /// <summary>
        ///     Gets the value of the nav active
        /// </summary>
        public ref bool NavActive => ref Unsafe.AsRef<bool>(&NativePtr->NavActive);

        /// <summary>
        ///     Gets the value of the nav visible
        /// </summary>
        public ref bool NavVisible => ref Unsafe.AsRef<bool>(&NativePtr->NavVisible);

        /// <summary>
        ///     Gets the value of the framerate
        /// </summary>
        public ref float Framerate => ref Unsafe.AsRef<float>(&NativePtr->Framerate);

        /// <summary>
        ///     Gets the value of the metrics render vertices
        /// </summary>
        public ref int MetricsRenderVertices => ref Unsafe.AsRef<int>(&NativePtr->MetricsRenderVertices);

        /// <summary>
        ///     Gets the value of the metrics render indices
        /// </summary>
        public ref int MetricsRenderIndices => ref Unsafe.AsRef<int>(&NativePtr->MetricsRenderIndices);

        /// <summary>
        ///     Gets the value of the metrics render windows
        /// </summary>
        public ref int MetricsRenderWindows => ref Unsafe.AsRef<int>(&NativePtr->MetricsRenderWindows);

        /// <summary>
        ///     Gets the value of the metrics active windows
        /// </summary>
        public ref int MetricsActiveWindows => ref Unsafe.AsRef<int>(&NativePtr->MetricsActiveWindows);

        /// <summary>
        ///     Gets the value of the metrics active allocations
        /// </summary>
        public ref int MetricsActiveAllocations => ref Unsafe.AsRef<int>(&NativePtr->MetricsActiveAllocations);

        /// <summary>
        ///     Gets the value of the mouse delta
        /// </summary>
        public ref Vector2 MouseDelta => ref Unsafe.AsRef<Vector2>(&NativePtr->MouseDelta);

        /// <summary>
        ///     Gets the value of the key map
        /// </summary>
        public RangeAccessor<int> KeyMap => new RangeAccessor<int>(NativePtr->KeyMap, 652);

        /// <summary>
        ///     Gets the value of the keys down
        /// </summary>
        public RangeAccessor<bool> KeysDown => new RangeAccessor<bool>(NativePtr->KeysDown, 652);

        /// <summary>
        ///     Gets the value of the nav inputs
        /// </summary>
        public RangeAccessor<float> NavInputs => new RangeAccessor<float>(NativePtr->NavInputs, 16);

        /// <summary>
        ///     Gets the value of the ctx
        /// </summary>
        public ref IntPtr Ctx => ref Unsafe.AsRef<IntPtr>(&NativePtr->Ctx);

        /// <summary>
        ///     Gets the value of the mouse pos
        /// </summary>
        public ref Vector2 MousePos => ref Unsafe.AsRef<Vector2>(&NativePtr->MousePos);

        /// <summary>
        ///     Gets the value of the mouse down
        /// </summary>
        public RangeAccessor<bool> MouseDown => new RangeAccessor<bool>(NativePtr->MouseDown, 5);

        /// <summary>
        ///     Gets the value of the mouse wheel
        /// </summary>
        public ref float MouseWheel => ref Unsafe.AsRef<float>(&NativePtr->MouseWheel);

        /// <summary>
        ///     Gets the value of the mouse wheel h
        /// </summary>
        public ref float MouseWheelH => ref Unsafe.AsRef<float>(&NativePtr->MouseWheelH);

        /// <summary>
        ///     Gets the value of the mouse source
        /// </summary>
        public ref ImGuiMouseSource MouseSource => ref Unsafe.AsRef<ImGuiMouseSource>(&NativePtr->MouseSource);

        /// <summary>
        ///     Gets the value of the mouse hovered viewport
        /// </summary>
        public ref uint MouseHoveredViewport => ref Unsafe.AsRef<uint>(&NativePtr->MouseHoveredViewport);

        /// <summary>
        ///     Gets the value of the key ctrl
        /// </summary>
        public ref bool KeyCtrl => ref Unsafe.AsRef<bool>(&NativePtr->KeyCtrl);

        /// <summary>
        ///     Gets the value of the key shift
        /// </summary>
        public ref bool KeyShift => ref Unsafe.AsRef<bool>(&NativePtr->KeyShift);

        /// <summary>
        ///     Gets the value of the key alt
        /// </summary>
        public ref bool KeyAlt => ref Unsafe.AsRef<bool>(&NativePtr->KeyAlt);

        /// <summary>
        ///     Gets the value of the key super
        /// </summary>
        public ref bool KeySuper => ref Unsafe.AsRef<bool>(&NativePtr->KeySuper);

        /// <summary>
        ///     Gets the value of the key mods
        /// </summary>
        public ref ImGuiKey KeyMods => ref Unsafe.AsRef<ImGuiKey>(&NativePtr->KeyMods);

        /// <summary>
        ///     Gets the value of the keys data
        /// </summary>
        public RangeAccessor<ImGuiKeyData> KeysData => new RangeAccessor<ImGuiKeyData>(&NativePtr->KeysData0, 652);

        /// <summary>
        ///     Gets the value of the want capture mouse unless popup close
        /// </summary>
        public ref bool WantCaptureMouseUnlessPopupClose => ref Unsafe.AsRef<bool>(&NativePtr->WantCaptureMouseUnlessPopupClose);

        /// <summary>
        ///     Gets the value of the mouse pos prev
        /// </summary>
        public ref Vector2 MousePosPrev => ref Unsafe.AsRef<Vector2>(&NativePtr->MousePosPrev);

        /// <summary>
        ///     Gets the value of the mouse clicked pos
        /// </summary>
        public RangeAccessor<Vector2> MouseClickedPos => new RangeAccessor<Vector2>(&NativePtr->MouseClickedPos0, 5);

        /// <summary>
        ///     Gets the value of the mouse clicked time
        /// </summary>
        public RangeAccessor<double> MouseClickedTime => new RangeAccessor<double>(NativePtr->MouseClickedTime, 5);

        /// <summary>
        ///     Gets the value of the mouse clicked
        /// </summary>
        public RangeAccessor<bool> MouseClicked => new RangeAccessor<bool>(NativePtr->MouseClicked, 5);

        /// <summary>
        ///     Gets the value of the mouse double clicked
        /// </summary>
        public RangeAccessor<bool> MouseDoubleClicked => new RangeAccessor<bool>(NativePtr->MouseDoubleClicked, 5);

        /// <summary>
        ///     Gets the value of the mouse clicked count
        /// </summary>
        public RangeAccessor<ushort> MouseClickedCount => new RangeAccessor<ushort>(NativePtr->MouseClickedCount, 5);

        /// <summary>
        ///     Gets the value of the mouse clicked last count
        /// </summary>
        public RangeAccessor<ushort> MouseClickedLastCount => new RangeAccessor<ushort>(NativePtr->MouseClickedLastCount, 5);

        /// <summary>
        ///     Gets the value of the mouse released
        /// </summary>
        public RangeAccessor<bool> MouseReleased => new RangeAccessor<bool>(NativePtr->MouseReleased, 5);

        /// <summary>
        ///     Gets the value of the mouse down owned
        /// </summary>
        public RangeAccessor<bool> MouseDownOwned => new RangeAccessor<bool>(NativePtr->MouseDownOwned, 5);

        /// <summary>
        ///     Gets the value of the mouse down owned unless popup close
        /// </summary>
        public RangeAccessor<bool> MouseDownOwnedUnlessPopupClose => new RangeAccessor<bool>(NativePtr->MouseDownOwnedUnlessPopupClose, 5);

        /// <summary>
        ///     Gets the value of the mouse wheel request axis swap
        /// </summary>
        public ref bool MouseWheelRequestAxisSwap => ref Unsafe.AsRef<bool>(&NativePtr->MouseWheelRequestAxisSwap);

        /// <summary>
        ///     Gets the value of the mouse down duration
        /// </summary>
        public RangeAccessor<float> MouseDownDuration => new RangeAccessor<float>(NativePtr->MouseDownDuration, 5);

        /// <summary>
        ///     Gets the value of the mouse down duration prev
        /// </summary>
        public RangeAccessor<float> MouseDownDurationPrev => new RangeAccessor<float>(NativePtr->MouseDownDurationPrev, 5);

        /// <summary>
        ///     Gets the value of the mouse drag max distance abs
        /// </summary>
        public RangeAccessor<Vector2> MouseDragMaxDistanceAbs => new RangeAccessor<Vector2>(&NativePtr->MouseDragMaxDistanceAbs0, 5);

        /// <summary>
        ///     Gets the value of the mouse drag max distance sqr
        /// </summary>
        public RangeAccessor<float> MouseDragMaxDistanceSqr => new RangeAccessor<float>(NativePtr->MouseDragMaxDistanceSqr, 5);

        /// <summary>
        ///     Gets the value of the pen pressure
        /// </summary>
        public ref float PenPressure => ref Unsafe.AsRef<float>(&NativePtr->PenPressure);

        /// <summary>
        ///     Gets the value of the app focus lost
        /// </summary>
        public ref bool AppFocusLost => ref Unsafe.AsRef<bool>(&NativePtr->AppFocusLost);

        /// <summary>
        ///     Gets the value of the app accepting events
        /// </summary>
        public ref bool AppAcceptingEvents => ref Unsafe.AsRef<bool>(&NativePtr->AppAcceptingEvents);

        /// <summary>
        ///     Gets the value of the backend using legacy key arrays
        /// </summary>
        public ref sbyte BackendUsingLegacyKeyArrays => ref Unsafe.AsRef<sbyte>(&NativePtr->BackendUsingLegacyKeyArrays);

        /// <summary>
        ///     Gets the value of the backend using legacy nav input array
        /// </summary>
        public ref bool BackendUsingLegacyNavInputArray => ref Unsafe.AsRef<bool>(&NativePtr->BackendUsingLegacyNavInputArray);

        /// <summary>
        ///     Gets the value of the input queue surrogate
        /// </summary>
        public ref ushort InputQueueSurrogate => ref Unsafe.AsRef<ushort>(&NativePtr->InputQueueSurrogate);

        /// <summary>
        ///     Gets the value of the input queue characters
        /// </summary>
        public ImVector<ushort> InputQueueCharacters => new ImVector<ushort>(NativePtr->InputQueueCharacters);

        /// <summary>
        ///     Adds the focus event using the specified focused
        /// </summary>
        /// <param name="focused">The focused</param>
        public void AddFocusEvent(bool focused)
        {
            byte nativeFocused = focused ? (byte) 1 : (byte) 0;
            ImGuiNative.ImGuiIO_AddFocusEvent(NativePtr, nativeFocused);
        }

        /// <summary>
        ///     Adds the input character using the specified c
        /// </summary>
        /// <param name="c">The </param>
        public void AddInputCharacter(uint c)
        {
            ImGuiNative.ImGuiIO_AddInputCharacter(NativePtr, c);
        }

        /// <summary>
        ///     Adds the input characters utf 8 using the specified str
        /// </summary>
        /// <param name="str">The str</param>
        public void AddInputCharactersUtf8(string str)
        {
            byte* nativeStr;
            int strByteCount = 0;
            if (str != null)
            {
                strByteCount = Encoding.UTF8.GetByteCount(str);
                if (strByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeStr = Util.Allocate(strByteCount + 1);
                }
                else
                {
                    byte* nativeStrStackBytes = stackalloc byte[strByteCount + 1];
                    nativeStr = nativeStrStackBytes;
                }

                int nativeStrOffset = Util.GetUtf8(str, nativeStr, strByteCount);
                nativeStr[nativeStrOffset] = 0;
            }
            else
            {
                nativeStr = null;
            }

            ImGuiNative.ImGuiIO_AddInputCharactersUTF8(NativePtr, nativeStr);
            if (strByteCount > Util.StackAllocationSizeLimit)
            {
                Util.Free(nativeStr);
            }
        }

        /// <summary>
        ///     Adds the input character utf 16 using the specified c
        /// </summary>
        /// <param name="c">The </param>
        public void AddInputCharacterUtf16(ushort c)
        {
            ImGuiNative.ImGuiIO_AddInputCharacterUTF16(NativePtr, c);
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
            ImGuiNative.ImGuiIO_AddKeyAnalogEvent(NativePtr, key, nativeDown, v);
        }

        /// <summary>
        ///     Adds the key event using the specified key
        /// </summary>
        /// <param name="key">The key</param>
        /// <param name="down">The down</param>
        public void AddKeyEvent(ImGuiKey key, bool down)
        {
            byte nativeDown = down ? (byte) 1 : (byte) 0;
            ImGuiNative.ImGuiIO_AddKeyEvent(NativePtr, key, nativeDown);
        }

        /// <summary>
        ///     Adds the mouse button event using the specified button
        /// </summary>
        /// <param name="button">The button</param>
        /// <param name="down">The down</param>
        public void AddMouseButtonEvent(int button, bool down)
        {
            byte nativeDown = down ? (byte) 1 : (byte) 0;
            ImGuiNative.ImGuiIO_AddMouseButtonEvent(NativePtr, button, nativeDown);
        }

        /// <summary>
        ///     Adds the mouse pos event using the specified x
        /// </summary>
        /// <param name="x">The </param>
        /// <param name="y">The </param>
        public void AddMousePosEvent(float x, float y)
        {
            ImGuiNative.ImGuiIO_AddMousePosEvent(NativePtr, x, y);
        }

        /// <summary>
        ///     Adds the mouse source event using the specified source
        /// </summary>
        /// <param name="source">The source</param>
        public void AddMouseSourceEvent(ImGuiMouseSource source)
        {
            ImGuiNative.ImGuiIO_AddMouseSourceEvent(NativePtr, source);
        }

        /// <summary>
        ///     Adds the mouse viewport event using the specified id
        /// </summary>
        /// <param name="id">The id</param>
        public void AddMouseViewportEvent(uint id)
        {
            ImGuiNative.ImGuiIO_AddMouseViewportEvent(NativePtr, id);
        }

        /// <summary>
        ///     Adds the mouse wheel event using the specified wheel x
        /// </summary>
        /// <param name="wheelX">The wheel</param>
        /// <param name="wheelY">The wheel</param>
        public void AddMouseWheelEvent(float wheelX, float wheelY)
        {
            ImGuiNative.ImGuiIO_AddMouseWheelEvent(NativePtr, wheelX, wheelY);
        }

        /// <summary>
        ///     Clears the input characters
        /// </summary>
        public void ClearInputCharacters()
        {
            ImGuiNative.ImGuiIO_ClearInputCharacters(NativePtr);
        }

        /// <summary>
        ///     Clears the input keys
        /// </summary>
        public void ClearInputKeys()
        {
            ImGuiNative.ImGuiIO_ClearInputKeys(NativePtr);
        }

        /// <summary>
        ///     Destroys this instance
        /// </summary>
        public void Destroy()
        {
            ImGuiNative.ImGuiIO_destroy(NativePtr);
        }

        /// <summary>
        ///     Sets the app accepting events using the specified accepting events
        /// </summary>
        /// <param name="acceptingEvents">The accepting events</param>
        public void SetAppAcceptingEvents(bool acceptingEvents)
        {
            byte nativeAcceptingEvents = acceptingEvents ? (byte) 1 : (byte) 0;
            ImGuiNative.ImGuiIO_SetAppAcceptingEvents(NativePtr, nativeAcceptingEvents);
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
            ImGuiNative.ImGuiIO_SetKeyEventNativeData(NativePtr, key, nativeKeycode, nativeScancode, nativeLegacyIndex);
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
            ImGuiNative.ImGuiIO_SetKeyEventNativeData(NativePtr, key, nativeKeycode, nativeScancode, nativeLegacyIndex);
        }
    }
}