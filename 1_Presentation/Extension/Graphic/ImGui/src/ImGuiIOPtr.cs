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
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using Alis.Core.Aspect.Math.Vector;

namespace Alis.Extension.Graphic.ImGui
{
    /// <summary>
    ///     The im gui io ptr
    /// </summary>
    public struct ImGuiIoPtr
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
        ///     Initializes a new instance of the <see cref="ImGuiIoPtr" /> class
        /// </summary>
        /// <param name="imGuiIo">The im gui io</param>
        public ImGuiIoPtr(ImGuiIo imGuiIo)
        {
            NativePtr = Marshal.AllocHGlobal(Marshal.SizeOf<ImGuiIo>());
            Marshal.StructureToPtr(imGuiIo, NativePtr, false);
        }

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
        public ImGuiConfigFlags ConfigFlags
        {
            get => Marshal.PtrToStructure<ImGuiIo>(NativePtr).ConfigFlags;
            set
            {
                // Write x and y values to the DisplaySize field
                ImGuiIo io = Marshal.PtrToStructure<ImGuiIo>(NativePtr);
                io.ConfigFlags = value;
                Marshal.StructureToPtr(io, NativePtr, false);
            }
        }

        /// <summary>
        ///     Gets the value of the backend flags
        /// </summary>
        public ImGuiBackendFlags BackendFlags
        {
            get => Marshal.PtrToStructure<ImGuiIo>(NativePtr).BackendFlags;
            set
            {
                // Write x and y values to the DisplaySize field
                ImGuiIo io = Marshal.PtrToStructure<ImGuiIo>(NativePtr);
                io.BackendFlags = value;
                Marshal.StructureToPtr(io, NativePtr, false);
            }
        }

        /// <summary>
        ///     Gets the value of the display size
        /// </summary>
        public Vector2F DisplaySize
        {
            get
            {
                ImGuiIo io = Marshal.PtrToStructure<ImGuiIo>(NativePtr);
                return new Vector2F(io.DisplaySize.X, io.DisplaySize.Y);
            }
            set
            {
                // Write x and y values to the DisplaySize field
                ImGuiIo io = Marshal.PtrToStructure<ImGuiIo>(NativePtr);
                io.DisplaySize = new Vector2F(value.X, value.Y);
                Marshal.StructureToPtr(io, NativePtr, false);
            }
        }

        /// <summary>
        ///     Gets the value of the delta time
        /// </summary>
        public float DeltaTime
        {
            get => Marshal.PtrToStructure<ImGuiIo>(NativePtr).DeltaTime;
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
        public float IniSavingRate => Marshal.PtrToStructure<ImGuiIo>(NativePtr).IniSavingRate;

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
        public float MouseDoubleClickTime => Marshal.PtrToStructure<ImGuiIo>(NativePtr).MouseDoubleClickTime;

        /// <summary>
        ///     Gets the value of the mouse double click max dist
        /// </summary>
        public float MouseDoubleClickMaxDist => Marshal.PtrToStructure<ImGuiIo>(NativePtr).MouseDoubleClickMaxDist;

        /// <summary>
        ///     Gets the value of the mouse drag threshold
        /// </summary>
        public float MouseDragThreshold => Marshal.PtrToStructure<ImGuiIo>(NativePtr).MouseDragThreshold;

        /// <summary>
        ///     Gets the value of the key repeat delay
        /// </summary>
        public float KeyRepeatDelay => Marshal.PtrToStructure<ImGuiIo>(NativePtr).KeyRepeatDelay;

        /// <summary>
        ///     Gets the value of the key repeat rate
        /// </summary>
        public float KeyRepeatRate => Marshal.PtrToStructure<ImGuiIo>(NativePtr).KeyRepeatRate;

        /// <summary>
        ///     Gets the value of the hover delay normal
        /// </summary>
        public float HoverDelayNormal => Marshal.PtrToStructure<ImGuiIo>(NativePtr).HoverDelayNormal;

        /// <summary>
        ///     Gets the value of the hover delay short
        /// </summary>
        public float HoverDelayShort => Marshal.PtrToStructure<ImGuiIo>(NativePtr).HoverDelayShort;

        /// <summary>
        ///     Gets or sets the value of the user data
        /// </summary>
        public IntPtr UserData
        {
            get => Marshal.PtrToStructure<ImGuiIo>(NativePtr).UserData;
            set
            {
                // Write x and y values to the DisplaySize field
                ImGuiIo io = Marshal.PtrToStructure<ImGuiIo>(NativePtr);
                io.UserData = value;
                Marshal.StructureToPtr(io, NativePtr, false);
            }
        }

        /// <summary>
        ///     Gets the value of the fonts
        /// </summary>
        public ImFontAtlasPtr Fonts => new ImFontAtlasPtr(Marshal.PtrToStructure<ImGuiIo>(NativePtr).Fonts);

        /// <summary>
        ///     Gets the value of the font global scale
        /// </summary>
        public float FontGlobalScale => Marshal.PtrToStructure<ImGuiIo>(NativePtr).FontGlobalScale;

        /// <summary>
        ///     Gets the value of the font allow user scaling
        /// </summary>
        public bool FontAllowUserScaling => Marshal.PtrToStructure<ImGuiIo>(NativePtr).FontAllowUserScaling != 0;

        /// <summary>
        ///     Gets the value of the font default
        /// </summary>
        public ImFontPtr FontDefault => new ImFontPtr(Marshal.PtrToStructure<ImGuiIo>(NativePtr).FontDefault);

        /// <summary>
        ///     Gets the value of the display framebuffer scale
        /// </summary>
        public Vector2F DisplayFramebufferScale
        {
            get => Marshal.PtrToStructure<ImGuiIo>(NativePtr).DisplayFramebufferScale;
            set
            {
                // Write x and y values to the DisplayFramebufferScale field
                ImGuiIo io = Marshal.PtrToStructure<ImGuiIo>(NativePtr);
                io.DisplayFramebufferScale = new Vector2F(value.X, value.Y);
                Marshal.StructureToPtr(io, NativePtr, false);
            }
        }

        /// <summary>
        ///     Gets the value of the config docking no split
        /// </summary>
        public bool ConfigDockingNoSplit => Marshal.PtrToStructure<ImGuiIo>(NativePtr).ConfigDockingNoSplit != 0;

        /// <summary>
        ///     Gets the value of the config docking with shift
        /// </summary>
        public bool ConfigDockingWithShift => Marshal.PtrToStructure<ImGuiIo>(NativePtr).ConfigDockingWithShift != 0;

        /// <summary>
        ///     Gets the value of the config docking always tab bar
        /// </summary>
        public bool ConfigDockingAlwaysTabBar => Marshal.PtrToStructure<ImGuiIo>(NativePtr).ConfigDockingAlwaysTabBar != 0;

        /// <summary>
        ///     Gets the value of the config docking transparent payload
        /// </summary>
        public bool ConfigDockingTransparentPayload => Marshal.PtrToStructure<ImGuiIo>(NativePtr).ConfigDockingTransparentPayload != 0;

        /// <summary>
        ///     Gets the value of the config viewports no auto merge
        /// </summary>
        public bool ConfigViewportsNoAutoMerge => Marshal.PtrToStructure<ImGuiIo>(NativePtr).ConfigViewportsNoAutoMerge != 0;

        /// <summary>
        ///     Gets the value of the config viewports no task bar icon
        /// </summary>
        public bool ConfigViewportsNoTaskBarIcon => Marshal.PtrToStructure<ImGuiIo>(NativePtr).ConfigViewportsNoTaskBarIcon != 0;

        /// <summary>
        ///     Gets the value of the config viewports no decoration
        /// </summary>
        public bool ConfigViewportsNoDecoration => Marshal.PtrToStructure<ImGuiIo>(NativePtr).ConfigViewportsNoDecoration != 0;

        /// <summary>
        ///     Gets the value of the config viewports no default parent
        /// </summary>
        public bool ConfigViewportsNoDefaultParent => Marshal.PtrToStructure<ImGuiIo>(NativePtr).ConfigViewportsNoDefaultParent != 0;

        /// <summary>
        ///     Gets the value of the mouse draw cursor
        /// </summary>
        public bool MouseDrawCursor => Marshal.PtrToStructure<ImGuiIo>(NativePtr).MouseDrawCursor != 0;

        /// <summary>
        ///     Gets the value of the config mac osx behaviors
        /// </summary>
        public bool ConfigMacOsxBehaviors => Marshal.PtrToStructure<ImGuiIo>(NativePtr).ConfigMacOsxBehaviors != 0;

        /// <summary>
        ///     Gets the value of the config input trickle event queue
        /// </summary>
        public bool ConfigInputTrickleEventQueue => Marshal.PtrToStructure<ImGuiIo>(NativePtr).ConfigInputTrickleEventQueue != 0;

        /// <summary>
        ///     Gets the value of the config input text cursor blink
        /// </summary>
        public bool ConfigInputTextCursorBlink => Marshal.PtrToStructure<ImGuiIo>(NativePtr).ConfigInputTextCursorBlink != 0;

        /// <summary>
        ///     Gets the value of the config input text enter keep active
        /// </summary>
        public bool ConfigInputTextEnterKeepActive => Marshal.PtrToStructure<ImGuiIo>(NativePtr).ConfigInputTextEnterKeepActive != 0;

        /// <summary>
        ///     Gets the value of the config drag click to input text
        /// </summary>
        public bool ConfigDragClickToInputText => Marshal.PtrToStructure<ImGuiIo>(NativePtr).ConfigDragClickToInputText != 0;

        /// <summary>
        ///     Gets the value of the config windows resize from edges
        /// </summary>
        public bool ConfigWindowsResizeFromEdges => Marshal.PtrToStructure<ImGuiIo>(NativePtr).ConfigWindowsResizeFromEdges != 0;

        /// <summary>
        ///     Gets the value of the config windows move from title bar only
        /// </summary>
        public bool ConfigWindowsMoveFromTitleBarOnly => Marshal.PtrToStructure<ImGuiIo>(NativePtr).ConfigWindowsMoveFromTitleBarOnly != 0;

        /// <summary>
        ///     Gets the value of the config memory compact timer
        /// </summary>
        public float ConfigMemoryCompactTimer => Marshal.PtrToStructure<ImGuiIo>(NativePtr).ConfigMemoryCompactTimer;

        /// <summary>
        ///     Gets the value of the backend platform name
        /// </summary>
        public NullTerminatedString BackendPlatformName
        {
            get => new NullTerminatedString(Marshal.PtrToStructure<ImGuiIo>(NativePtr).BackendPlatformName);
            set
            {
                ImGuiIo io = Marshal.PtrToStructure<ImGuiIo>(NativePtr);
                io.BackendPlatformName = value.Data;
                Marshal.StructureToPtr(io, NativePtr, false);
            }
        }

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
            set
            {
                ImGuiIo io = Marshal.PtrToStructure<ImGuiIo>(NativePtr);
                io.BackendPlatformUserData = value;
                Marshal.StructureToPtr(io, NativePtr, false);
            }
        }

        /// <summary>
        ///     Gets or sets the value of the backend renderer user data
        /// </summary>
        public IntPtr BackendRendererUserData
        {
            get => Marshal.PtrToStructure<ImGuiIo>(NativePtr).BackendRendererUserData;
            set
            {
                ImGuiIo io = Marshal.PtrToStructure<ImGuiIo>(NativePtr);
                io.BackendRendererUserData = value;
                Marshal.StructureToPtr(io, NativePtr, false);
            }
        }

        /// <summary>
        ///     Gets or sets the value of the backend language user data
        /// </summary>
        public IntPtr BackendLanguageUserData
        {
            get => Marshal.PtrToStructure<ImGuiIo>(NativePtr).BackendLanguageUserData;
            set
            {
                ImGuiIo io = Marshal.PtrToStructure<ImGuiIo>(NativePtr);
                io.BackendLanguageUserData = value;
                Marshal.StructureToPtr(io, NativePtr, false);
            }
        }

        /// <summary>
        ///     Gets the value of the get clipboard text fn
        /// </summary>
        public IntPtr GetClipboardTextFn
        {
            get => Marshal.PtrToStructure<ImGuiIo>(NativePtr).GetClipboardTextFn;
            set
            {
                ImGuiIo io = Marshal.PtrToStructure<ImGuiIo>(NativePtr);
                io.GetClipboardTextFn = value;
                Marshal.StructureToPtr(io, NativePtr, false);
            }
        }

        /// <summary>
        ///     Gets the value of the set clipboard text fn
        /// </summary>
        public IntPtr SetClipboardTextFn
        {
            get => Marshal.PtrToStructure<ImGuiIo>(NativePtr).SetClipboardTextFn;
            set
            {
                ImGuiIo io = Marshal.PtrToStructure<ImGuiIo>(NativePtr);
                io.SetClipboardTextFn = value;
                Marshal.StructureToPtr(io, NativePtr, false);
            }
        }

        /// <summary>
        ///     Gets or sets the value of the clipboard user data
        /// </summary>
        public IntPtr ClipboardUserData
        {
            get => Marshal.PtrToStructure<ImGuiIo>(NativePtr).ClipboardUserData;
            set
            {
                ImGuiIo io = Marshal.PtrToStructure<ImGuiIo>(NativePtr);
                io.ClipboardUserData = value;
                Marshal.StructureToPtr(io, NativePtr, false);
            }
        }

        /// <summary>
        ///     Gets the value of the set platform ime data fn
        /// </summary>
        public IntPtr SetPlatformImeDataFn
        {
            get => Marshal.PtrToStructure<ImGuiIo>(NativePtr).SetPlatformImeDataFn;
            set
            {
                ImGuiIo io = Marshal.PtrToStructure<ImGuiIo>(NativePtr);
                io.SetPlatformImeDataFn = value;
                Marshal.StructureToPtr(io, NativePtr, false);
            }
        }

        /// <summary>
        ///     Gets or sets the value of the  unusedpadding
        /// </summary>
        public IntPtr UnusedPadding
        {
            get => Marshal.PtrToStructure<ImGuiIo>(NativePtr).UnusedPadding;
            set
            {
                ImGuiIo io = Marshal.PtrToStructure<ImGuiIo>(NativePtr);
                io.UnusedPadding = value;
                Marshal.StructureToPtr(io, NativePtr, false);
            }
        }

        /// <summary>
        ///     Gets the value of the want capture mouse
        /// </summary>
        public bool WantCaptureMouse
        {
            get => Marshal.PtrToStructure<ImGuiIo>(NativePtr).WantCaptureMouse != 0;
            set
            {
                ImGuiIo io = Marshal.PtrToStructure<ImGuiIo>(NativePtr);
                io.WantCaptureMouse = value ? (byte) 1 : (byte) 0;
                Marshal.StructureToPtr(io, NativePtr, false);
            }
        }

        /// <summary>
        ///     Gets the value of the want capture keyboard
        /// </summary>
        public bool WantCaptureKeyboard
        {
            get => Marshal.PtrToStructure<ImGuiIo>(NativePtr).WantCaptureKeyboard != 0;
            set
            {
                ImGuiIo io = Marshal.PtrToStructure<ImGuiIo>(NativePtr);
                io.WantCaptureKeyboard = value ? (byte) 1 : (byte) 0;
                Marshal.StructureToPtr(io, NativePtr, false);
            }
        }

        /// <summary>
        ///     Gets the value of the want text input
        /// </summary>
        public bool WantTextInput
        {
            get => Marshal.PtrToStructure<ImGuiIo>(NativePtr).WantTextInput != 0;
            set
            {
                ImGuiIo io = Marshal.PtrToStructure<ImGuiIo>(NativePtr);
                io.WantTextInput = value ? (byte) 1 : (byte) 0;
                Marshal.StructureToPtr(io, NativePtr, false);
            }
        }

        /// <summary>
        ///     Gets the value of the want set mouse pos
        /// </summary>
        public bool WantSetMousePos
        {
            get => Marshal.PtrToStructure<ImGuiIo>(NativePtr).WantSetMousePos != 0;
            set
            {
                ImGuiIo io = Marshal.PtrToStructure<ImGuiIo>(NativePtr);
                io.WantSetMousePos = value ? (byte) 1 : (byte) 0;
                Marshal.StructureToPtr(io, NativePtr, false);
            }
        }

        /// <summary>
        ///     Gets the value of the want save ini settings
        /// </summary>
        public bool WantSaveIniSettings
        {
            get => Marshal.PtrToStructure<ImGuiIo>(NativePtr).WantSaveIniSettings != 0;
            set
            {
                ImGuiIo io = Marshal.PtrToStructure<ImGuiIo>(NativePtr);
                io.WantSaveIniSettings = value ? (byte) 1 : (byte) 0;
                Marshal.StructureToPtr(io, NativePtr, false);
            }
        }

        /// <summary>
        ///     Gets the value of the nav active
        /// </summary>
        public bool NavActive
        {
            get => Marshal.PtrToStructure<ImGuiIo>(NativePtr).NavActive != 0;
            set
            {
                ImGuiIo io = Marshal.PtrToStructure<ImGuiIo>(NativePtr);
                io.NavActive = value ? (byte) 1 : (byte) 0;
                Marshal.StructureToPtr(io, NativePtr, false);
            }
        }

        /// <summary>
        ///     Gets the value of the nav visible
        /// </summary>
        public bool NavVisible
        {
            get => Marshal.PtrToStructure<ImGuiIo>(NativePtr).NavVisible != 0;
            set
            {
                ImGuiIo io = Marshal.PtrToStructure<ImGuiIo>(NativePtr);
                io.NavVisible = value ? (byte) 1 : (byte) 0;
                Marshal.StructureToPtr(io, NativePtr, false);
            }
        }

        /// <summary>
        ///     Gets the value of the framerate
        /// </summary>
        public float Framerate
        {
            get => Marshal.PtrToStructure<ImGuiIo>(NativePtr).Framerate;
            set
            {
                ImGuiIo io = Marshal.PtrToStructure<ImGuiIo>(NativePtr);
                io.Framerate = value;
                Marshal.StructureToPtr(io, NativePtr, false);
            }
        }

        /// <summary>
        ///     Gets the value of the metrics render vertices
        /// </summary>
        public int MetricsRenderVertices
        {
            get => Marshal.PtrToStructure<ImGuiIo>(NativePtr).MetricsRenderVertices;
            set
            {
                ImGuiIo io = Marshal.PtrToStructure<ImGuiIo>(NativePtr);
                io.MetricsRenderVertices = value;
                Marshal.StructureToPtr(io, NativePtr, false);
            }
        }

        /// <summary>
        ///     Gets the value of the metrics render indices
        /// </summary>
        public int MetricsRenderIndices
        {
            get => Marshal.PtrToStructure<ImGuiIo>(NativePtr).MetricsRenderIndices;
            set
            {
                ImGuiIo io = Marshal.PtrToStructure<ImGuiIo>(NativePtr);
                io.MetricsRenderIndices = value;
                Marshal.StructureToPtr(io, NativePtr, false);
            }
        }

        /// <summary>
        ///     Gets the value of the metrics render windows
        /// </summary>
        public int MetricsRenderWindows
        {
            get => Marshal.PtrToStructure<ImGuiIo>(NativePtr).MetricsRenderWindows;
            set
            {
                ImGuiIo io = Marshal.PtrToStructure<ImGuiIo>(NativePtr);
                io.MetricsRenderWindows = value;
                Marshal.StructureToPtr(io, NativePtr, false);
            }
        }

        /// <summary>
        ///     Gets the value of the metrics active windows
        /// </summary>
        public int MetricsActiveWindows
        {
            get => Marshal.PtrToStructure<ImGuiIo>(NativePtr).MetricsActiveWindows;
            set
            {
                ImGuiIo io = Marshal.PtrToStructure<ImGuiIo>(NativePtr);
                io.MetricsActiveWindows = value;
                Marshal.StructureToPtr(io, NativePtr, false);
            }
        }

        /// <summary>
        ///     Gets the value of the metrics active allocations
        /// </summary>
        public int MetricsActiveAllocations
        {
            get => Marshal.PtrToStructure<ImGuiIo>(NativePtr).MetricsActiveAllocations;
            set
            {
                ImGuiIo io = Marshal.PtrToStructure<ImGuiIo>(NativePtr);
                io.MetricsActiveAllocations = value;
                Marshal.StructureToPtr(io, NativePtr, false);
            }
        }

        /// <summary>
        ///     Gets the value of the mouse delta
        /// </summary>
        public Vector2F MouseDelta
        {
            get => Marshal.PtrToStructure<ImGuiIo>(NativePtr).MouseDelta;
            set
            {
                ImGuiIo io = Marshal.PtrToStructure<ImGuiIo>(NativePtr);
                io.MouseDelta = new Vector2F(value.X, value.Y);
                Marshal.StructureToPtr(io, NativePtr, false);
            }
        }

        /// <summary>
        ///     Gets or sets the value of the key map
        /// </summary>
        public List<int> KeyMap
        {
            get
            {
                // Create an empty list for the key map
                List<int> map = new List<int>();

                // Retrieve the key map array from the ImGuiIo structure
                int[] keyMap = Marshal.PtrToStructure<ImGuiIo>(NativePtr).KeyMap;

                // Add each key map value to the list
                foreach (int key in keyMap)
                {
                    map.Add(key);
                }

                return map;
            }
            set
            {
                // Retrieve the existing key map array from the ImGuiIo structure
                int[] keyMap = Marshal.PtrToStructure<ImGuiIo>(NativePtr).KeyMap;

                // Update the key map array with values from the provided list
                for (int i = 0; i < value.Count; i++)
                {
                    keyMap[i] = value[i];
                }

                // Update the ImGuiIo structure with the modified key map array
                ImGuiIo io = Marshal.PtrToStructure<ImGuiIo>(NativePtr);
                io.KeyMap = keyMap;
                Marshal.StructureToPtr(io, NativePtr, false);
            }
        }

        /// <summary>
        ///     Gets the value of the keys down
        /// </summary>
        public List<bool> KeysDown
        {
            get
            {
                // Assuming the size of the keys down is known to be 512
                List<bool> down = new List<bool>(512);

                byte[] keysDown = Marshal.PtrToStructure<ImGuiIo>(NativePtr).KeysDown;
                foreach (byte b in keysDown)
                {
                    down.Add(b != 0);
                }

                return down;
            }
            set
            {
                // Assuming KeysDown is the first field in ImGuiIo, adjust the offset accordingly if it's not.
                int offsetToKeysDown = Marshal.OffsetOf<ImGuiIo>("KeysDown").ToInt32();
                IntPtr keysDownPtr = IntPtr.Add(NativePtr, offsetToKeysDown);

                // Convert the List<bool> to a byte[] array.
                byte[] keysDown = new byte[value.Count];
                for (int i = 0; i < value.Count; i++)
                {
                    keysDown[i] = value[i] ? (byte) 1 : (byte) 0;
                }

                // Copy the byte[] array directly to unmanaged memory.
                Marshal.Copy(keysDown, 0, keysDownPtr, keysDown.Length);
            }
        }

        /// <summary>
        ///     Gets the value of the nav inputs
        /// </summary>
        public List<float> NavInputs
        {
            get
            {
                float[] navInputs = Marshal.PtrToStructure<ImGuiIo>(NativePtr).NavInputs;

                // Assuming the size of the nav inputs is known to be 21
                List<float> inputs = new List<float>(navInputs.Length);

                foreach (float f in navInputs)
                {
                    inputs.Add(f);
                }

                return inputs;
            }
            set
            {
                float[] navInputs = Marshal.PtrToStructure<ImGuiIo>(NativePtr).NavInputs;

                float[] navInputs2 = new float[21];
                for (int i = 0; i < value.Count; i++)
                {
                    navInputs2[i] = value[i];
                }

                ImGuiIo io = Marshal.PtrToStructure<ImGuiIo>(NativePtr);
                io.NavInputs = navInputs2;
                Marshal.StructureToPtr(io, NativePtr, false);
            }
        }

        /// <summary>
        ///     Gets the value of the mouse pos
        /// </summary>
        public Vector2F MousePos
        {
            get => Marshal.PtrToStructure<ImGuiIo>(NativePtr).MousePos;
            set
            {
                // Write x and y values to the MousePos field
                ImGuiIo io = Marshal.PtrToStructure<ImGuiIo>(NativePtr);
                io.MousePos = new Vector2F(value.X, value.Y);
                Marshal.StructureToPtr(io, NativePtr, false);
            }
        }

        /// <summary>
        ///     Gets the value of the mouse down
        /// </summary>
        public List<bool> MouseDown
        {
            get
            {
                // Assuming the size of the mouse down is known to be 5
                List<bool> down = new List<bool>(5);

                byte[] mouseDown = Marshal.PtrToStructure<ImGuiIo>(NativePtr).MouseDown;
                foreach (byte b in mouseDown)
                {
                    down.Add(b != 0);
                }

                return down;
            }
            set
            {
                // Assuming MouseDown is the first field in ImGuiIo, adjust the offset accordingly if it's not.
                int offsetToMouseDown = Marshal.OffsetOf<ImGuiIo>("MouseDown").ToInt32();
                IntPtr mouseDownPtr = IntPtr.Add(NativePtr, offsetToMouseDown);

                // Convert the List<bool> to a byte[] array.
                byte[] mouseDown = new byte[value.Count];
                for (int i = 0; i < value.Count; i++)
                {
                    mouseDown[i] = value[i] ? (byte) 1 : (byte) 0;
                }

                // Copy the byte[] array directly to unmanaged memory.
                Marshal.Copy(mouseDown, 0, mouseDownPtr, mouseDown.Length);
            }
        }

        /// <summary>
        ///     Gets the value of the mouse wheel
        /// </summary>
        public float MouseWheel
        {
            get => Marshal.PtrToStructure<ImGuiIo>(NativePtr).MouseWheel;
            set
            {
                // Write x and y values to the MouseWheel field
                ImGuiIo io = Marshal.PtrToStructure<ImGuiIo>(NativePtr);
                io.MouseWheel = value;
                Marshal.StructureToPtr(io, NativePtr, false);
            }
        }

        /// <summary>
        ///     Gets the value of the mouse wheel h
        /// </summary>
        public float MouseWheelH
        {
            get => Marshal.PtrToStructure<ImGuiIo>(NativePtr).MouseWheelH;
            set
            {
                // Write x and y values to the MouseWheelH field
                ImGuiIo io = Marshal.PtrToStructure<ImGuiIo>(NativePtr);
                io.MouseWheelH = value;
                Marshal.StructureToPtr(io, NativePtr, false);
            }
        }

        /// <summary>
        ///     Gets the value of the mouse hovered viewport
        /// </summary>
        public uint MouseHoveredViewport
        {
            get => Marshal.PtrToStructure<ImGuiIo>(NativePtr).MouseHoveredViewport;
            set
            {
                ImGuiIo io = Marshal.PtrToStructure<ImGuiIo>(NativePtr);
                io.MouseHoveredViewport = value;
                Marshal.StructureToPtr(io, NativePtr, false);
            }
        }

        /// <summary>
        ///     Gets the value of the key ctrl
        /// </summary>
        public bool KeyCtrl
        {
            get => Marshal.PtrToStructure<ImGuiIo>(NativePtr).KeyCtrl != 0;
            set
            {
                ImGuiIo io = Marshal.PtrToStructure<ImGuiIo>(NativePtr);
                io.KeyCtrl = value ? (byte) 1 : (byte) 0;
                Marshal.StructureToPtr(io, NativePtr, false);
            }
        }

        /// <summary>
        ///     Gets the value of the key shift
        /// </summary>
        public bool KeyShift
        {
            get => Marshal.PtrToStructure<ImGuiIo>(NativePtr).KeyShift != 0;
            set
            {
                ImGuiIo io = Marshal.PtrToStructure<ImGuiIo>(NativePtr);
                io.KeyShift = value ? (byte) 1 : (byte) 0;
                Marshal.StructureToPtr(io, NativePtr, false);
            }
        }

        /// <summary>
        ///     Gets the value of the key alt
        /// </summary>
        public bool KeyAlt
        {
            get => Marshal.PtrToStructure<ImGuiIo>(NativePtr).KeyAlt != 0;
            set
            {
                ImGuiIo io = Marshal.PtrToStructure<ImGuiIo>(NativePtr);
                io.KeyAlt = value ? (byte) 1 : (byte) 0;
                Marshal.StructureToPtr(io, NativePtr, false);
            }
        }

        /// <summary>
        ///     Gets the value of the key super
        /// </summary>
        public bool KeySuper
        {
            get => Marshal.PtrToStructure<ImGuiIo>(NativePtr).KeySuper != 0;
            set
            {
                ImGuiIo io = Marshal.PtrToStructure<ImGuiIo>(NativePtr);
                io.KeySuper = value ? (byte) 1 : (byte) 0;
                Marshal.StructureToPtr(io, NativePtr, false);
            }
        }

        /// <summary>
        ///     Gets the value of the key mods
        /// </summary>
        public ImGuiKey KeyMods
        {
            get => Marshal.PtrToStructure<ImGuiIo>(NativePtr).KeyMods;
            set
            {
                ImGuiIo io = Marshal.PtrToStructure<ImGuiIo>(NativePtr);
                io.KeyMods = value;
                Marshal.StructureToPtr(io, NativePtr, false);
            }
        }

        /// <summary>
        ///     Gets the value of the keys data
        /// </summary>
        public List<ImGuiKeyData> KeysData
        {
            get
            {
                // Assuming KeysData is the first field in ImGuiIo, adjust the offset accordingly if it's not.
                int offsetToKeysData = Marshal.OffsetOf<ImGuiIo>("KeysData").ToInt32();
                IntPtr keysDataPtr = IntPtr.Add(NativePtr, offsetToKeysData);

                // Assuming the size of the keys data is known to be 512
                List<ImGuiKeyData> data = new List<ImGuiKeyData>(512);
                for (int i = 0; i < 512; i++)
                {
                    data.Add(Marshal.PtrToStructure<ImGuiKeyData>(IntPtr.Add(keysDataPtr, i * Marshal.SizeOf<ImGuiKeyData>())));
                }

                return data;
            }
        }

        /// <summary>
        ///     Gets the value of the want capture mouse unless popup close
        /// </summary>
        public bool WantCaptureMouseUnlessPopupClose
        {
            get => Marshal.PtrToStructure<ImGuiIo>(NativePtr).WantCaptureMouseUnlessPopupClose != 0;
            set
            {
                ImGuiIo io = Marshal.PtrToStructure<ImGuiIo>(NativePtr);
                io.WantCaptureMouseUnlessPopupClose = value ? (byte) 1 : (byte) 0;
                Marshal.StructureToPtr(io, NativePtr, false);
            }
        }

        /// <summary>
        ///     Gets the value of the mouse pos prev
        /// </summary>
        public Vector2F MousePosPrev
        {
            get => Marshal.PtrToStructure<ImGuiIo>(NativePtr).MousePosPrev;
            set
            {
                ImGuiIo io = Marshal.PtrToStructure<ImGuiIo>(NativePtr);
                io.MousePosPrev = new Vector2F(value.X, value.Y);
                Marshal.StructureToPtr(io, NativePtr, false);
            }
        }

        /// <summary>
        ///     Gets the value of the mouse clicked pos
        /// </summary>
        public List<Vector2F> MouseClickedPos
        {
            get
            {
                // Assuming MouseClickedPos is the first field in ImGuiIo, adjust the offset accordingly if it's not.
                int offsetToMouseClickedPos = Marshal.OffsetOf<ImGuiIo>("MouseClickedPos").ToInt32();
                IntPtr mouseClickedPosPtr = IntPtr.Add(NativePtr, offsetToMouseClickedPos);

                // Assuming the size of the mouse clicked pos is known to be 5
                List<Vector2F> pos = new List<Vector2F>(5);
                for (int i = 0; i < 5; i++)
                {
                    pos.Add(Marshal.PtrToStructure<Vector2F>(IntPtr.Add(mouseClickedPosPtr, i * Marshal.SizeOf<Vector2F>())));
                }

                return pos;
            }
        }

        /// <summary>
        ///     Gets the value of the mouse clicked time
        /// </summary>
        public List<double> MouseClickedTime
        {
            get
            {
                // Assuming MouseClickedTime is the first field in ImGuiIo, adjust the offset accordingly if it's not.
                int offsetToMouseClickedTime = Marshal.OffsetOf<ImGuiIo>("MouseClickedTime").ToInt32();
                IntPtr mouseClickedTimePtr = IntPtr.Add(NativePtr, offsetToMouseClickedTime);

                // Assuming the size of the mouse clicked time is known to be 5
                List<double> time = new List<double>(5);
                for (int i = 0; i < 5; i++)
                {
                    time.Add(Marshal.PtrToStructure<double>(IntPtr.Add(mouseClickedTimePtr, i * Marshal.SizeOf<double>())));
                }

                return time;
            }
            set
            {
                // Assuming MouseClickedTime is the first field in ImGuiIo, adjust the offset accordingly if it's not.
                int offsetToMouseClickedTime = Marshal.OffsetOf<ImGuiIo>("MouseClickedTime").ToInt32();
                IntPtr mouseClickedTimePtr = IntPtr.Add(NativePtr, offsetToMouseClickedTime);

                // Assuming the size of the mouse clicked time is known to be 5
                for (int i = 0; i < 5; i++)
                {
                    Marshal.StructureToPtr(value[i], IntPtr.Add(mouseClickedTimePtr, i * Marshal.SizeOf<double>()), false);
                }
            }
        }

        /// <summary>
        ///     Gets the value of the mouse clicked
        /// </summary>
        public List<bool> MouseClicked
        {
            get
            {
                // Assuming MouseClicked is the first field in ImGuiIo, adjust the offset accordingly if it's not.
                int offsetToMouseClicked = Marshal.OffsetOf<ImGuiIo>("MouseClicked").ToInt32();
                IntPtr mouseClickedPtr = IntPtr.Add(NativePtr, offsetToMouseClicked);

                // Assuming the size of the mouse clicked is known to be 5
                List<bool> clicked = new List<bool>(5);
                for (int i = 0; i < 5; i++)
                {
                    clicked.Add(Marshal.PtrToStructure<bool>(IntPtr.Add(mouseClickedPtr, i * Marshal.SizeOf<bool>())));
                }

                return clicked;
            }
            set
            {
                // Assuming MouseClicked is the first field in ImGuiIo, adjust the offset accordingly if it's not.
                int offsetToMouseClicked = Marshal.OffsetOf<ImGuiIo>("MouseClicked").ToInt32();
                IntPtr mouseClickedPtr = IntPtr.Add(NativePtr, offsetToMouseClicked);

                // Assuming the size of the mouse clicked is known to be 5
                for (int i = 0; i < 5; i++)
                {
                    Marshal.StructureToPtr(value[i], IntPtr.Add(mouseClickedPtr, i * Marshal.SizeOf<bool>()), false);
                }
            }
        }

        /// <summary>
        ///     Gets the value of the mouse double clicked
        /// </summary>
        public List<bool> MouseDoubleClicked
        {
            get
            {
                // Assuming MouseDoubleClicked is the first field in ImGuiIo, adjust the offset accordingly if it's not.
                int offsetToMouseDoubleClicked = Marshal.OffsetOf<ImGuiIo>("MouseDoubleClicked").ToInt32();
                IntPtr mouseDoubleClickedPtr = IntPtr.Add(NativePtr, offsetToMouseDoubleClicked);

                // Assuming the size of the mouse double clicked is known to be 5
                List<bool> doubleClicked = new List<bool>(5);
                for (int i = 0; i < 5; i++)
                {
                    doubleClicked.Add(Marshal.PtrToStructure<bool>(IntPtr.Add(mouseDoubleClickedPtr, i * Marshal.SizeOf<bool>())));
                }

                return doubleClicked;
            }
            set
            {
                // Assuming MouseDoubleClicked is the first field in ImGuiIo, adjust the offset accordingly if it's not.
                int offsetToMouseDoubleClicked = Marshal.OffsetOf<ImGuiIo>("MouseDoubleClicked").ToInt32();
                IntPtr mouseDoubleClickedPtr = IntPtr.Add(NativePtr, offsetToMouseDoubleClicked);

                // Assuming the size of the mouse double clicked is known to be 5
                for (int i = 0; i < 5; i++)
                {
                    Marshal.StructureToPtr(value[i], IntPtr.Add(mouseDoubleClickedPtr, i * Marshal.SizeOf<bool>()), false);
                }
            }
        }

        /// <summary>
        ///     Gets the value of the mouse clicked count
        /// </summary>
        public List<ushort> MouseClickedCount
        {
            get
            {
                // Assuming MouseClickedCount is the first field in ImGuiIo, adjust the offset accordingly if it's not.
                int offsetToMouseClickedCount = Marshal.OffsetOf<ImGuiIo>("MouseClickedCount").ToInt32();
                IntPtr mouseClickedCountPtr = IntPtr.Add(NativePtr, offsetToMouseClickedCount);

                // Assuming the size of the mouse clicked count is known to be 5
                List<ushort> count = new List<ushort>(5);
                for (int i = 0; i < 5; i++)
                {
                    count.Add(Marshal.PtrToStructure<ushort>(IntPtr.Add(mouseClickedCountPtr, i * Marshal.SizeOf<ushort>())));
                }

                return count;
            }
            set
            {
                // Assuming MouseClickedCount is the first field in ImGuiIo, adjust the offset accordingly if it's not.
                int offsetToMouseClickedCount = Marshal.OffsetOf<ImGuiIo>("MouseClickedCount").ToInt32();
                IntPtr mouseClickedCountPtr = IntPtr.Add(NativePtr, offsetToMouseClickedCount);

                // Assuming the size of the mouse clicked count is known to be 5
                for (int i = 0; i < 5; i++)
                {
                    Marshal.StructureToPtr(value[i], IntPtr.Add(mouseClickedCountPtr, i * Marshal.SizeOf<ushort>()), false);
                }
            }
        }

        /// <summary>
        ///     Gets the value of the mouse clicked last count
        /// </summary>
        public List<ushort> MouseClickedLastCount
        {
            get
            {
                // Assuming MouseClickedLastCount is the first field in ImGuiIo, adjust the offset accordingly if it's not.
                int offsetToMouseClickedLastCount = Marshal.OffsetOf<ImGuiIo>("MouseClickedLastCount").ToInt32();
                IntPtr mouseClickedLastCountPtr = IntPtr.Add(NativePtr, offsetToMouseClickedLastCount);

                // Assuming the size of the mouse clicked last count is known to be 5
                List<ushort> lastCount = new List<ushort>(5);
                for (int i = 0; i < 5; i++)
                {
                    lastCount.Add(Marshal.PtrToStructure<ushort>(IntPtr.Add(mouseClickedLastCountPtr, i * Marshal.SizeOf<ushort>())));
                }

                return lastCount;
            }
            set
            {
                // Assuming MouseClickedLastCount is the first field in ImGuiIo, adjust the offset accordingly if it's not.
                int offsetToMouseClickedLastCount = Marshal.OffsetOf<ImGuiIo>("MouseClickedLastCount").ToInt32();
                IntPtr mouseClickedLastCountPtr = IntPtr.Add(NativePtr, offsetToMouseClickedLastCount);

                // Assuming the size of the mouse clicked last count is known to be 5
                for (int i = 0; i < 5; i++)
                {
                    Marshal.StructureToPtr(value[i], IntPtr.Add(mouseClickedLastCountPtr, i * Marshal.SizeOf<ushort>()), false);
                }
            }
        }

        /// <summary>
        ///     Gets the value of the mouse released
        /// </summary>
        public List<bool> MouseReleased
        {
            get
            {
                // Assuming MouseReleased is the first field in ImGuiIo, adjust the offset accordingly if it's not.
                int offsetToMouseReleased = Marshal.OffsetOf<ImGuiIo>("MouseReleased").ToInt32();
                IntPtr mouseReleasedPtr = IntPtr.Add(NativePtr, offsetToMouseReleased);

                // Assuming the size of the mouse released is known to be 5
                List<bool> released = new List<bool>(5);
                for (int i = 0; i < 5; i++)
                {
                    released.Add(Marshal.PtrToStructure<bool>(IntPtr.Add(mouseReleasedPtr, i * Marshal.SizeOf<bool>())));
                }

                return released;
            }
            set
            {
                // Assuming MouseReleased is the first field in ImGuiIo, adjust the offset accordingly if it's not.
                int offsetToMouseReleased = Marshal.OffsetOf<ImGuiIo>("MouseReleased").ToInt32();
                IntPtr mouseReleasedPtr = IntPtr.Add(NativePtr, offsetToMouseReleased);

                // Assuming the size of the mouse released is known to be 5
                for (int i = 0; i < 5; i++)
                {
                    Marshal.StructureToPtr(value[i], IntPtr.Add(mouseReleasedPtr, i * Marshal.SizeOf<bool>()), false);
                }
            }
        }

        /// <summary>
        ///     Gets the value of the mouse down owned
        /// </summary>
        public List<bool> MouseDownOwned
        {
            get
            {
                // Assuming MouseDownOwned is the first field in ImGuiIo, adjust the offset accordingly if it's not.
                int offsetToMouseDownOwned = Marshal.OffsetOf<ImGuiIo>("MouseDownOwned").ToInt32();
                IntPtr mouseDownOwnedPtr = IntPtr.Add(NativePtr, offsetToMouseDownOwned);

                // Assuming the size of the mouse down owned is known to be 5
                List<bool> owned = new List<bool>(5);
                for (int i = 0; i < 5; i++)
                {
                    owned.Add(Marshal.PtrToStructure<bool>(IntPtr.Add(mouseDownOwnedPtr, i * Marshal.SizeOf<bool>())));
                }

                return owned;
            }
            set
            {
                // Assuming MouseDownOwned is the first field in ImGuiIo, adjust the offset accordingly if it's not.
                int offsetToMouseDownOwned = Marshal.OffsetOf<ImGuiIo>("MouseDownOwned").ToInt32();
                IntPtr mouseDownOwnedPtr = IntPtr.Add(NativePtr, offsetToMouseDownOwned);

                // Assuming the size of the mouse down owned is known to be 5
                for (int i = 0; i < 5; i++)
                {
                    Marshal.StructureToPtr(value[i], IntPtr.Add(mouseDownOwnedPtr, i * Marshal.SizeOf<bool>()), false);
                }
            }
        }

        /// <summary>
        ///     Gets the value of the mouse down owned unless popup close
        /// </summary>
        public List<bool> MouseDownOwnedUnlessPopupClose
        {
            get
            {
                // Assuming MouseDownOwnedUnlessPopupClose is the first field in ImGuiIo, adjust the offset accordingly if it's not.
                int offsetToMouseDownOwnedUnlessPopupClose = Marshal.OffsetOf<ImGuiIo>("MouseDownOwnedUnlessPopupClose").ToInt32();
                IntPtr mouseDownOwnedUnlessPopupClosePtr = IntPtr.Add(NativePtr, offsetToMouseDownOwnedUnlessPopupClose);

                // Assuming the size of the mouse down owned unless popup close is known to be 5
                List<bool> ownedUnlessPopupClose = new List<bool>(5);
                for (int i = 0; i < 5; i++)
                {
                    ownedUnlessPopupClose.Add(Marshal.PtrToStructure<bool>(IntPtr.Add(mouseDownOwnedUnlessPopupClosePtr, i * Marshal.SizeOf<bool>())));
                }

                return ownedUnlessPopupClose;
            }
            set
            {
                // Assuming MouseDownOwnedUnlessPopupClose is the first field in ImGuiIo, adjust the offset accordingly if it's not.
                int offsetToMouseDownOwnedUnlessPopupClose = Marshal.OffsetOf<ImGuiIo>("MouseDownOwnedUnlessPopupClose").ToInt32();
                IntPtr mouseDownOwnedUnlessPopupClosePtr = IntPtr.Add(NativePtr, offsetToMouseDownOwnedUnlessPopupClose);

                // Assuming the size of the mouse down owned unless popup close is known to be 5
                for (int i = 0; i < 5; i++)
                {
                    Marshal.StructureToPtr(value[i], IntPtr.Add(mouseDownOwnedUnlessPopupClosePtr, i * Marshal.SizeOf<bool>()), false);
                }
            }
        }

        /// <summary>
        ///     Gets the value of the mouse down duration
        /// </summary>
        public List<float> MouseDownDuration
        {
            get
            {
                // Assuming MouseDownDuration is the first field in ImGuiIo, adjust the offset accordingly if it's not.
                int offsetToMouseDownDuration = Marshal.OffsetOf<ImGuiIo>("MouseDownDuration").ToInt32();
                IntPtr mouseDownDurationPtr = IntPtr.Add(NativePtr, offsetToMouseDownDuration);

                // Assuming the size of the mouse down duration is known to be 5
                List<float> duration = new List<float>(5);
                for (int i = 0; i < 5; i++)
                {
                    duration.Add(Marshal.PtrToStructure<float>(IntPtr.Add(mouseDownDurationPtr, i * Marshal.SizeOf<float>())));
                }

                return duration;
            }
            set
            {
                // Assuming MouseDownDuration is the first field in ImGuiIo, adjust the offset accordingly if it's not.
                int offsetToMouseDownDuration = Marshal.OffsetOf<ImGuiIo>("MouseDownDuration").ToInt32();
                IntPtr mouseDownDurationPtr = IntPtr.Add(NativePtr, offsetToMouseDownDuration);

                // Assuming the size of the mouse down duration is known to be 5
                for (int i = 0; i < 5; i++)
                {
                    Marshal.StructureToPtr(value[i], IntPtr.Add(mouseDownDurationPtr, i * Marshal.SizeOf<float>()), false);
                }
            }
        }

        /// <summary>
        ///     Gets the value of the mouse down duration prev
        /// </summary>
        public List<float> MouseDownDurationPrev
        {
            get
            {
                // Assuming MouseDownDurationPrev is the first field in ImGuiIo, adjust the offset accordingly if it's not.
                int offsetToMouseDownDurationPrev = Marshal.OffsetOf<ImGuiIo>("MouseDownDurationPrev").ToInt32();
                IntPtr mouseDownDurationPrevPtr = IntPtr.Add(NativePtr, offsetToMouseDownDurationPrev);

                // Assuming the size of the mouse down duration prev is known to be 5
                List<float> durationPrev = new List<float>(5);
                for (int i = 0; i < 5; i++)
                {
                    durationPrev.Add(Marshal.PtrToStructure<float>(IntPtr.Add(mouseDownDurationPrevPtr, i * Marshal.SizeOf<float>())));
                }

                return durationPrev;
            }
            set
            {
                // Assuming MouseDownDurationPrev is the first field in ImGuiIo, adjust the offset accordingly if it's not.
                int offsetToMouseDownDurationPrev = Marshal.OffsetOf<ImGuiIo>("MouseDownDurationPrev").ToInt32();
                IntPtr mouseDownDurationPrevPtr = IntPtr.Add(NativePtr, offsetToMouseDownDurationPrev);

                // Assuming the size of the mouse down duration prev is known to be 5
                for (int i = 0; i < 5; i++)
                {
                    Marshal.StructureToPtr(value[i], IntPtr.Add(mouseDownDurationPrevPtr, i * Marshal.SizeOf<float>()), false);
                }
            }
        }

        /// <summary>
        ///     Gets the value of the mouse drag max distance abs
        /// </summary>
        public List<Vector2F> MouseDragMaxDistanceAbs
        {
            get
            {
                // Assuming MouseDragMaxDistanceAbs is the first field in ImGuiIo, adjust the offset accordingly if it's not.
                int offsetToMouseDragMaxDistanceAbs = Marshal.OffsetOf<ImGuiIo>("MouseDragMaxDistanceAbs").ToInt32();
                IntPtr mouseDragMaxDistanceAbsPtr = IntPtr.Add(NativePtr, offsetToMouseDragMaxDistanceAbs);

                // Assuming the size of the mouse drag max distance abs is known to be 5
                List<Vector2F> distanceAbs = new List<Vector2F>(5);
                for (int i = 0; i < 5; i++)
                {
                    distanceAbs.Add(Marshal.PtrToStructure<Vector2F>(IntPtr.Add(mouseDragMaxDistanceAbsPtr, i * Marshal.SizeOf<Vector2F>())));
                }

                return distanceAbs;
            }
        }

        /// <summary>
        ///     Gets the value of the mouse drag max distance sqr
        /// </summary>
        public List<float> MouseDragMaxDistanceSqr
        {
            get
            {
                // Assuming MouseDragMaxDistanceSqr is the first field in ImGuiIo, adjust the offset accordingly if it's not.
                int offsetToMouseDragMaxDistanceSqr = Marshal.OffsetOf<ImGuiIo>("MouseDragMaxDistanceSqr").ToInt32();
                IntPtr mouseDragMaxDistanceSqrPtr = IntPtr.Add(NativePtr, offsetToMouseDragMaxDistanceSqr);

                // Assuming the size of the mouse drag max distance sqr is known to be 5
                List<float> distanceSqr = new List<float>(5);
                for (int i = 0; i < 5; i++)
                {
                    distanceSqr.Add(Marshal.PtrToStructure<float>(IntPtr.Add(mouseDragMaxDistanceSqrPtr, i * Marshal.SizeOf<float>())));
                }

                return distanceSqr;
            }
            set
            {
                // Assuming MouseDragMaxDistanceSqr is the first field in ImGuiIo, adjust the offset accordingly if it's not.
                int offsetToMouseDragMaxDistanceSqr = Marshal.OffsetOf<ImGuiIo>("MouseDragMaxDistanceSqr").ToInt32();
                IntPtr mouseDragMaxDistanceSqrPtr = IntPtr.Add(NativePtr, offsetToMouseDragMaxDistanceSqr);

                // Assuming the size of the mouse drag max distance sqr is known to be 5
                for (int i = 0; i < 5; i++)
                {
                    Marshal.StructureToPtr(value[i], IntPtr.Add(mouseDragMaxDistanceSqrPtr, i * Marshal.SizeOf<float>()), false);
                }
            }
        }

        /// <summary>
        ///     Gets the value of the pen pressure
        /// </summary>
        public float PenPressure
        {
            get => Marshal.PtrToStructure<ImGuiIo>(NativePtr).PenPressure;
            set
            {
                // Write x and y values to the PenPressure field
                ImGuiIo io = Marshal.PtrToStructure<ImGuiIo>(NativePtr);
                io.PenPressure = value;
                Marshal.StructureToPtr(io, NativePtr, false);
            }
        }

        /// <summary>
        ///     Gets the value of the app focus lost
        /// </summary>
        public bool AppFocusLost
        {
            get => Marshal.PtrToStructure<ImGuiIo>(NativePtr).AppFocusLost != 0;
            set
            {
                ImGuiIo io = Marshal.PtrToStructure<ImGuiIo>(NativePtr);
                io.AppFocusLost = value ? (byte) 1 : (byte) 0;
                Marshal.StructureToPtr(io, NativePtr, false);
            }
        }

        /// <summary>
        ///     Gets the value of the app accepting events
        /// </summary>
        public bool AppAcceptingEvents
        {
            get => Marshal.PtrToStructure<ImGuiIo>(NativePtr).AppAcceptingEvents != 0;
            set
            {
                ImGuiIo io = Marshal.PtrToStructure<ImGuiIo>(NativePtr);
                io.AppAcceptingEvents = value ? (byte) 1 : (byte) 0;
                Marshal.StructureToPtr(io, NativePtr, false);
            }
        }

        /// <summary>
        ///     Gets the value of the backend using legacy key arrays
        /// </summary>
        public sbyte BackendUsingLegacyKeyArrays
        {
            get => Marshal.PtrToStructure<ImGuiIo>(NativePtr).BackendUsingLegacyKeyArrays;
            set
            {
                ImGuiIo io = Marshal.PtrToStructure<ImGuiIo>(NativePtr);
                io.BackendUsingLegacyKeyArrays = value;
                Marshal.StructureToPtr(io, NativePtr, false);
            }
        }

        /// <summary>
        ///     Gets the value of the backend using legacy nav input array
        /// </summary>
        public bool BackendUsingLegacyNavInputArray
        {
            get => Marshal.PtrToStructure<ImGuiIo>(NativePtr).BackendUsingLegacyNavInputArray != 0;
            set
            {
                ImGuiIo io = Marshal.PtrToStructure<ImGuiIo>(NativePtr);
                io.BackendUsingLegacyNavInputArray = value ? (byte) 1 : (byte) 0;
                Marshal.StructureToPtr(io, NativePtr, false);
            }
        }

        /// <summary>
        ///     Gets the value of the input queue surrogate
        /// </summary>
        public ushort InputQueueSurrogate
        {
            get => Marshal.PtrToStructure<ImGuiIo>(NativePtr).InputQueueSurrogate;
            set
            {
                ImGuiIo io = Marshal.PtrToStructure<ImGuiIo>(NativePtr);
                io.InputQueueSurrogate = value;
                Marshal.StructureToPtr(io, NativePtr, false);
            }
        }

        /// <summary>
        ///     Gets the value of the input queue characters
        /// </summary>
        public ImVectorG<ushort> InputQueueCharacters
        {
            get => Marshal.PtrToStructure<ImGuiIo>(NativePtr).InputQueueCharacters;
            set
            {
                ImGuiIo io = Marshal.PtrToStructure<ImGuiIo>(NativePtr);
                io.InputQueueCharacters = value;
                Marshal.StructureToPtr(io, NativePtr, false);
            }
        }

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
            ImGuiNative.ImGuiIO_AddInputCharactersUTF8(NativePtr, Encoding.UTF8.GetBytes(str));
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
        ///     Adds the mouse viewport event using the specified id
        /// </summary>
        /// <param name="id">The id</param>
        public void AddMouseViewportEvent(uint id)
        {
            ImGuiNative.ImGuiIO_AddMouseViewportEvent(NativePtr, id);
        }

        /// <summary>
        ///     Adds the mouse wheel event using the specified wh x
        /// </summary>
        /// <param name="whX">The wh</param>
        /// <param name="whY">The wh</param>
        public void AddMouseWheelEvent(float whX, float whY)
        {
            ImGuiNative.ImGuiIO_AddMouseWheelEvent(NativePtr, whX, whY);
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