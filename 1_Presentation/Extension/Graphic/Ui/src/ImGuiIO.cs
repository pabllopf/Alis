// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImGuiIO.cs
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

namespace Alis.Extension.Graphic.Ui
{
    /// <summary>
    ///     The im gui io
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct ImGuiIo
    {
        /// <summary>
        ///     The config flags
        /// </summary>
        public ImGuiConfigFlags ConfigFlags { get; set; }

        /// <summary>
        ///     The backend flags
        /// </summary>
        public ImGuiBackendFlags BackendFlags { get; set; }

        /// <summary>
        ///     The display size
        /// </summary>
        public Vector2F DisplaySize { get; set; }

        /// <summary>
        ///     The delta time
        /// </summary>
        public float DeltaTime { get; set; }

        /// <summary>
        ///     The ini saving rate
        /// </summary>
        public float IniSavingRate { get; set; }

        /// <summary>
        ///     The ini filename
        /// </summary>
        public IntPtr IniFilename { get; set; }

        /// <summary>
        ///     The log filename
        /// </summary>
        public IntPtr LogFilename { get; set; }

        /// <summary>
        ///     The mouse double click time
        /// </summary>
        public float MouseDoubleClickTime { get; set; }

        /// <summary>
        ///     The mouse double click max dist
        /// </summary>
        public float MouseDoubleClickMaxDist { get; set; }

        /// <summary>
        ///     The mouse drag threshold
        /// </summary>
        public float MouseDragThreshold { get; set; }

        /// <summary>
        ///     The key repeat delay
        /// </summary>
        public float KeyRepeatDelay { get; set; }

        /// <summary>
        ///     The key repeat rate
        /// </summary>
        public float KeyRepeatRate { get; set; }

        /// <summary>
        ///     The hover delay normal
        /// </summary>
        public float HoverDelayNormal { get; set; }

        /// <summary>
        ///     The hover delay short
        /// </summary>
        public float HoverDelayShort { get; set; }

        /// <summary>
        ///     The user data
        /// </summary>
        public IntPtr UserData { get; set; }

        /// <summary>
        ///     The fonts
        /// </summary>
        public IntPtr Fonts { get; set; }

        /// <summary>
        ///     The font global scale
        /// </summary>
        public float FontGlobalScale { get; set; }

        /// <summary>
        ///     The font allow user scaling
        /// </summary>
        public byte FontAllowUserScaling { get; set; }

        /// <summary>
        ///     The font default
        /// </summary>
        public IntPtr FontDefault { get; set; }

        /// <summary>
        ///     The display framebuffer scale
        /// </summary>
        public Vector2F DisplayFramebufferScale { get; set; }

        /// <summary>
        ///     The config docking no split
        /// </summary>
        public byte ConfigDockingNoSplit { get; set; }

        /// <summary>
        ///     The config docking with shift
        /// </summary>
        public byte ConfigDockingWithShift { get; set; }

        /// <summary>
        ///     The config docking always tab bar
        /// </summary>
        public byte ConfigDockingAlwaysTabBar { get; set; }

        /// <summary>
        ///     The config docking transparent payload
        /// </summary>
        public byte ConfigDockingTransparentPayload { get; set; }

        /// <summary>
        ///     The config viewports no auto merge
        /// </summary>
        public byte ConfigViewportsNoAutoMerge { get; set; }

        /// <summary>
        ///     The config viewports no task bar icon
        /// </summary>
        public byte ConfigViewportsNoTaskBarIcon { get; set; }

        /// <summary>
        ///     The config viewports no decoration
        /// </summary>
        public byte ConfigViewportsNoDecoration { get; set; }

        /// <summary>
        ///     The config viewports no default parent
        /// </summary>
        public byte ConfigViewportsNoDefaultParent { get; set; }

        /// <summary>
        ///     The mouse draw cursor
        /// </summary>
        public byte MouseDrawCursor { get; set; }

        /// <summary>
        ///     The config mac osx behaviors
        /// </summary>
        public byte ConfigMacOsxBehaviors { get; set; }

        /// <summary>
        ///     The config input trickle event queue
        /// </summary>
        public byte ConfigInputTrickleEventQueue { get; set; }

        /// <summary>
        ///     The config input text cursor blink
        /// </summary>
        public byte ConfigInputTextCursorBlink { get; set; }

        /// <summary>
        ///     The config input text enter keep active
        /// </summary>
        public byte ConfigInputTextEnterKeepActive { get; set; }

        /// <summary>
        ///     The config drag click to input text
        /// </summary>
        public byte ConfigDragClickToInputText { get; set; }

        /// <summary>
        ///     The config windows resize from edges
        /// </summary>
        public byte ConfigWindowsResizeFromEdges { get; set; }

        /// <summary>
        ///     The config windows move from title bar only
        /// </summary>
        public byte ConfigWindowsMoveFromTitleBarOnly { get; set; }

        /// <summary>
        ///     The config memory compact timer
        /// </summary>
        public float ConfigMemoryCompactTimer { get; set; }

        /// <summary>
        ///     The backend platform name
        /// </summary>
        public IntPtr BackendPlatformName { get; set; }

        /// <summary>
        ///     The backend renderer name
        /// </summary>
        public IntPtr BackendRendererName { get; set; }

        /// <summary>
        ///     The backend platform user data
        /// </summary>
        public IntPtr BackendPlatformUserData { get; set; }

        /// <summary>
        ///     The backend renderer user data
        /// </summary>
        public IntPtr BackendRendererUserData { get; set; }

        /// <summary>
        ///     The backend language user data
        /// </summary>
        public IntPtr BackendLanguageUserData { get; set; }

        /// <summary>
        ///     The get clipboard text fn
        /// </summary>
        public IntPtr GetClipboardTextFn { get; set; }

        /// <summary>
        ///     The set clipboard text fn
        /// </summary>
        public IntPtr SetClipboardTextFn { get; set; }

        /// <summary>
        ///     The clipboard user data
        /// </summary>
        public IntPtr ClipboardUserData { get; set; }

        /// <summary>
        ///     The set platform ime data fn
        /// </summary>
        public IntPtr SetPlatformImeDataFn { get; set; }

        /// <summary>
        ///     The unused padding
        /// </summary>
        public IntPtr UnusedPadding { get; set; }

        /// <summary>
        ///     The want capture mouse
        /// </summary>
        public byte WantCaptureMouse { get; set; }

        /// <summary>
        ///     The want capture keyboard
        /// </summary>
        public byte WantCaptureKeyboard { get; set; }

        /// <summary>
        ///     The want text input
        /// </summary>
        public byte WantTextInput { get; set; }

        /// <summary>
        ///     The want set mouse pos
        /// </summary>
        public byte WantSetMousePos { get; set; }

        /// <summary>
        ///     The want save ini settings
        /// </summary>
        public byte WantSaveIniSettings { get; set; }

        /// <summary>
        ///     The nav active
        /// </summary>
        public byte NavActive { get; set; }

        /// <summary>
        ///     The nav visible
        /// </summary>
        public byte NavVisible { get; set; }

        /// <summary>
        ///     The framerate
        /// </summary>
        public float Framerate { get; set; }

        /// <summary>
        ///     The metrics render vertices
        /// </summary>
        public int MetricsRenderVertices { get; set; }

        /// <summary>
        ///     The metrics render indices
        /// </summary>
        public int MetricsRenderIndices { get; set; }

        /// <summary>
        ///     The metrics render windows
        /// </summary>
        public int MetricsRenderWindows { get; set; }

        /// <summary>
        ///     The metrics active windows
        /// </summary>
        public int MetricsActiveWindows { get; set; }

        /// <summary>
        ///     The metrics active allocations
        /// </summary>
        public int MetricsActiveAllocations { get; set; }

        /// <summary>
        ///     The mouse delta
        /// </summary>
        public Vector2F MouseDelta { get; set; }

        /// <summary>
        ///     The key map
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 652)]
        public int[] KeyMap;

        /// <summary>
        ///     The keys down
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 652)]
        public byte[] KeysDown;

        /// <summary>
        ///     The nav inputs
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
        public float[] NavInputs;

        /// <summary>
        ///     The mouse pos
        /// </summary>
        public Vector2F MousePos { get; set; }

        /// <summary>
        ///     The mouse down
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 5)]
        public byte[] MouseDown;

        /// <summary>
        ///     The mouse wheel
        /// </summary>
        public float MouseWheel { get; set; }

        /// <summary>
        ///     The mouse wheel
        /// </summary>
        public float MouseWheelH { get; set; }

        /// <summary>
        ///     The mouse hovered viewport
        /// </summary>
        public uint MouseHoveredViewport { get; set; }

        /// <summary>
        ///     The key ctrl
        /// </summary>
        public byte KeyCtrl { get; set; }

        /// <summary>
        ///     The key shift
        /// </summary>
        public byte KeyShift { get; set; }

        /// <summary>
        ///     The key alt
        /// </summary>
        public byte KeyAlt { get; set; }

        /// <summary>
        ///     The key super
        /// </summary>
        public byte KeySuper { get; set; }

        /// <summary>
        ///     The key mods
        /// </summary>
        public ImGuiKey KeyMods { get; set; }

        /// <summary>
        ///     The keysdata
        /// </summary>
        public ImGuiKeyData KeysData0 { get; set; }

        /// <summary>
        ///     The keysdata
        /// </summary>
        public ImGuiKeyData KeysData1 { get; set; }

        /// <summary>
        ///     The keysdata
        /// </summary>
        public ImGuiKeyData KeysData2 { get; set; }

        /// <summary>
        ///     The keysdata
        /// </summary>
        public ImGuiKeyData KeysData3 { get; set; }

        /// <summary>
        ///     The keysdata
        /// </summary>
        public ImGuiKeyData KeysData4 { get; set; }

        /// <summary>
        ///     The keysdata
        /// </summary>
        public ImGuiKeyData KeysData5 { get; set; }

        /// <summary>
        ///     The keysdata
        /// </summary>
        public ImGuiKeyData KeysData6 { get; set; }

        /// <summary>
        ///     The keysdata
        /// </summary>
        public ImGuiKeyData KeysData7 { get; set; }

        /// <summary>
        ///     The keysdata
        /// </summary>
        public ImGuiKeyData KeysData8 { get; set; }

        /// <summary>
        ///     The keysdata
        /// </summary>
        public ImGuiKeyData KeysData9 { get; set; }

        /// <summary>
        ///     The keysdata 10
        /// </summary>
        public ImGuiKeyData KeysData10 { get; set; }

        /// <summary>
        ///     The keysdata 11
        /// </summary>
        public ImGuiKeyData KeysData11 { get; set; }

        /// <summary>
        ///     The keysdata 12
        /// </summary>
        public ImGuiKeyData KeysData12 { get; set; }

        /// <summary>
        ///     The keysdata 13
        /// </summary>
        public ImGuiKeyData KeysData13 { get; set; }

        /// <summary>
        ///     The keysdata 14
        /// </summary>
        public ImGuiKeyData KeysData14 { get; set; }

        /// <summary>
        ///     The keysdata 15
        /// </summary>
        public ImGuiKeyData KeysData15 { get; set; }

        /// <summary>
        ///     The keysdata 16
        /// </summary>
        public ImGuiKeyData KeysData16 { get; set; }

        /// <summary>
        ///     The keysdata 17
        /// </summary>
        public ImGuiKeyData KeysData17 { get; set; }

        /// <summary>
        ///     The keysdata 18
        /// </summary>
        public ImGuiKeyData KeysData18 { get; set; }

        /// <summary>
        ///     The keysdata 19
        /// </summary>
        public ImGuiKeyData KeysData19 { get; set; }

        /// <summary>
        ///     The keysdata 20
        /// </summary>
        public ImGuiKeyData KeysData20 { get; set; }

        /// <summary>
        ///     The keysdata 21
        /// </summary>
        public ImGuiKeyData KeysData21 { get; set; }

        /// <summary>
        ///     The keysdata 22
        /// </summary>
        public ImGuiKeyData KeysData22 { get; set; }

        /// <summary>
        ///     The keysdata 23
        /// </summary>
        public ImGuiKeyData KeysData23 { get; set; }

        /// <summary>
        ///     The keysdata 24
        /// </summary>
        public ImGuiKeyData KeysData24 { get; set; }

        /// <summary>
        ///     The keysdata 25
        /// </summary>
        public ImGuiKeyData KeysData25 { get; set; }

        /// <summary>
        ///     The keysdata 26
        /// </summary>
        public ImGuiKeyData KeysData26 { get; set; }

        /// <summary>
        ///     The keysdata 27
        /// </summary>
        public ImGuiKeyData KeysData27 { get; set; }

        /// <summary>
        ///     The keysdata 28
        /// </summary>
        public ImGuiKeyData KeysData28 { get; set; }

        /// <summary>
        ///     The keysdata 29
        /// </summary>
        public ImGuiKeyData KeysData29 { get; set; }

        /// <summary>
        ///     The keysdata 30
        /// </summary>
        public ImGuiKeyData KeysData30 { get; set; }

        /// <summary>
        ///     The keysdata 31
        /// </summary>
        public ImGuiKeyData KeysData31 { get; set; }

        /// <summary>
        ///     The keysdata 32
        /// </summary>
        public ImGuiKeyData KeysData32 { get; set; }

        /// <summary>
        ///     The keysdata 33
        /// </summary>
        public ImGuiKeyData KeysData33 { get; set; }

        /// <summary>
        ///     The keysdata 34
        /// </summary>
        public ImGuiKeyData KeysData34 { get; set; }

        /// <summary>
        ///     The keysdata 35
        /// </summary>
        public ImGuiKeyData KeysData35 { get; set; }

        /// <summary>
        ///     The keysdata 36
        /// </summary>
        public ImGuiKeyData KeysData36 { get; set; }

        /// <summary>
        ///     The keysdata 37
        /// </summary>
        public ImGuiKeyData KeysData37 { get; set; }

        /// <summary>
        ///     The keysdata 38
        /// </summary>
        public ImGuiKeyData KeysData38 { get; set; }

        /// <summary>
        ///     The keysdata 39
        /// </summary>
        public ImGuiKeyData KeysData39 { get; set; }

        /// <summary>
        ///     The keysdata 40
        /// </summary>
        public ImGuiKeyData KeysData40 { get; set; }

        /// <summary>
        ///     The keysdata 41
        /// </summary>
        public ImGuiKeyData KeysData41 { get; set; }

        /// <summary>
        ///     The keysdata 42
        /// </summary>
        public ImGuiKeyData KeysData42 { get; set; }

        /// <summary>
        ///     The keysdata 43
        /// </summary>
        public ImGuiKeyData KeysData43 { get; set; }

        /// <summary>
        ///     The keysdata 44
        /// </summary>
        public ImGuiKeyData KeysData44 { get; set; }

        /// <summary>
        ///     The keysdata 45
        /// </summary>
        public ImGuiKeyData KeysData45 { get; set; }

        /// <summary>
        ///     The keysdata 46
        /// </summary>
        public ImGuiKeyData KeysData46 { get; set; }

        /// <summary>
        ///     The keysdata 47
        /// </summary>
        public ImGuiKeyData KeysData47 { get; set; }

        /// <summary>
        ///     The keysdata 48
        /// </summary>
        public ImGuiKeyData KeysData48 { get; set; }

        /// <summary>
        ///     The keysdata 49
        /// </summary>
        public ImGuiKeyData KeysData49 { get; set; }

        /// <summary>
        ///     The keysdata 50
        /// </summary>
        public ImGuiKeyData KeysData50 { get; set; }

        /// <summary>
        ///     The keysdata 51
        /// </summary>
        public ImGuiKeyData KeysData51 { get; set; }

        /// <summary>
        ///     The keysdata 52
        /// </summary>
        public ImGuiKeyData KeysData52 { get; set; }

        /// <summary>
        ///     The keysdata 53
        /// </summary>
        public ImGuiKeyData KeysData53 { get; set; }

        /// <summary>
        ///     The keysdata 54
        /// </summary>
        public ImGuiKeyData KeysData54 { get; set; }

        /// <summary>
        ///     The keysdata 55
        /// </summary>
        public ImGuiKeyData KeysData55 { get; set; }

        /// <summary>
        ///     The keysdata 56
        /// </summary>
        public ImGuiKeyData KeysData56 { get; set; }

        /// <summary>
        ///     The keysdata 57
        /// </summary>
        public ImGuiKeyData KeysData57 { get; set; }

        /// <summary>
        ///     The keysdata 58
        /// </summary>
        public ImGuiKeyData KeysData58 { get; set; }

        /// <summary>
        ///     The keysdata 59
        /// </summary>
        public ImGuiKeyData KeysData59 { get; set; }

        /// <summary>
        ///     The keysdata 60
        /// </summary>
        public ImGuiKeyData KeysData60 { get; set; }

        /// <summary>
        ///     The keysdata 61
        /// </summary>
        public ImGuiKeyData KeysData61 { get; set; }

        /// <summary>
        ///     The keysdata 62
        /// </summary>
        public ImGuiKeyData KeysData62 { get; set; }

        /// <summary>
        ///     The keysdata 63
        /// </summary>
        public ImGuiKeyData KeysData63 { get; set; }

        /// <summary>
        ///     The keysdata 64
        /// </summary>
        public ImGuiKeyData KeysData64 { get; set; }

        /// <summary>
        ///     The keysdata 65
        /// </summary>
        public ImGuiKeyData KeysData65 { get; set; }

        /// <summary>
        ///     The keysdata 66
        /// </summary>
        public ImGuiKeyData KeysData66 { get; set; }

        /// <summary>
        ///     The keysdata 67
        /// </summary>
        public ImGuiKeyData KeysData67 { get; set; }

        /// <summary>
        ///     The keysdata 68
        /// </summary>
        public ImGuiKeyData KeysData68 { get; set; }

        /// <summary>
        ///     The keysdata 69
        /// </summary>
        public ImGuiKeyData KeysData69 { get; set; }

        /// <summary>
        ///     The keysdata 70
        /// </summary>
        public ImGuiKeyData KeysData70 { get; set; }

        /// <summary>
        ///     The keysdata 71
        /// </summary>
        public ImGuiKeyData KeysData71 { get; set; }

        /// <summary>
        ///     The keysdata 72
        /// </summary>
        public ImGuiKeyData KeysData72 { get; set; }

        /// <summary>
        ///     The keysdata 73
        /// </summary>
        public ImGuiKeyData KeysData73 { get; set; }

        /// <summary>
        ///     The keysdata 74
        /// </summary>
        public ImGuiKeyData KeysData74 { get; set; }

        /// <summary>
        ///     The keysdata 75
        /// </summary>
        public ImGuiKeyData KeysData75 { get; set; }

        /// <summary>
        ///     The keysdata 76
        /// </summary>
        public ImGuiKeyData KeysData76 { get; set; }

        /// <summary>
        ///     The keysdata 77
        /// </summary>
        public ImGuiKeyData KeysData77 { get; set; }

        /// <summary>
        ///     The keysdata 78
        /// </summary>
        public ImGuiKeyData KeysData78 { get; set; }

        /// <summary>
        ///     The keysdata 79
        /// </summary>
        public ImGuiKeyData KeysData79 { get; set; }

        /// <summary>
        ///     The keysdata 80
        /// </summary>
        public ImGuiKeyData KeysData80 { get; set; }

        /// <summary>
        ///     The keysdata 81
        /// </summary>
        public ImGuiKeyData KeysData81 { get; set; }

        /// <summary>
        ///     The keysdata 82
        /// </summary>
        public ImGuiKeyData KeysData82 { get; set; }

        /// <summary>
        ///     The keysdata 83
        /// </summary>
        public ImGuiKeyData KeysData83 { get; set; }

        /// <summary>
        ///     The keysdata 84
        /// </summary>
        public ImGuiKeyData KeysData84 { get; set; }

        /// <summary>
        ///     The keysdata 85
        /// </summary>
        public ImGuiKeyData KeysData85 { get; set; }

        /// <summary>
        ///     The keysdata 86
        /// </summary>
        public ImGuiKeyData KeysData86 { get; set; }

        /// <summary>
        ///     The keysdata 87
        /// </summary>
        public ImGuiKeyData KeysData87 { get; set; }

        /// <summary>
        ///     The keysdata 88
        /// </summary>
        public ImGuiKeyData KeysData88 { get; set; }

        /// <summary>
        ///     The keysdata 89
        /// </summary>
        public ImGuiKeyData KeysData89 { get; set; }

        /// <summary>
        ///     The keysdata 90
        /// </summary>
        public ImGuiKeyData KeysData90 { get; set; }

        /// <summary>
        ///     The keysdata 91
        /// </summary>
        public ImGuiKeyData KeysData91 { get; set; }

        /// <summary>
        ///     The keysdata 92
        /// </summary>
        public ImGuiKeyData KeysData92 { get; set; }

        /// <summary>
        ///     The keysdata 93
        /// </summary>
        public ImGuiKeyData KeysData93 { get; set; }

        /// <summary>
        ///     The keysdata 94
        /// </summary>
        public ImGuiKeyData KeysData94 { get; set; }

        /// <summary>
        ///     The keysdata 95
        /// </summary>
        public ImGuiKeyData KeysData95 { get; set; }

        /// <summary>
        ///     The keysdata 96
        /// </summary>
        public ImGuiKeyData KeysData96 { get; set; }

        /// <summary>
        ///     The keysdata 97
        /// </summary>
        public ImGuiKeyData KeysData97 { get; set; }

        /// <summary>
        ///     The keysdata 98
        /// </summary>
        public ImGuiKeyData KeysData98 { get; set; }

        /// <summary>
        ///     The keysdata 99
        /// </summary>
        public ImGuiKeyData KeysData99 { get; set; }

        /// <summary>
        ///     The keysdata 100
        /// </summary>
        public ImGuiKeyData KeysData100 { get; set; }

        /// <summary>
        ///     The keysdata 101
        /// </summary>
        public ImGuiKeyData KeysData101 { get; set; }

        /// <summary>
        ///     The keysdata 102
        /// </summary>
        public ImGuiKeyData KeysData102 { get; set; }

        /// <summary>
        ///     The keysdata 103
        /// </summary>
        public ImGuiKeyData KeysData103 { get; set; }

        /// <summary>
        ///     The keysdata 104
        /// </summary>
        public ImGuiKeyData KeysData104 { get; set; }

        /// <summary>
        ///     The keysdata 105
        /// </summary>
        public ImGuiKeyData KeysData105 { get; set; }

        /// <summary>
        ///     The keysdata 106
        /// </summary>
        public ImGuiKeyData KeysData106 { get; set; }

        /// <summary>
        ///     The keysdata 107
        /// </summary>
        public ImGuiKeyData KeysData107 { get; set; }

        /// <summary>
        ///     The keysdata 108
        /// </summary>
        public ImGuiKeyData KeysData108 { get; set; }

        /// <summary>
        ///     The keysdata 109
        /// </summary>
        public ImGuiKeyData KeysData109 { get; set; }

        /// <summary>
        ///     The keysdata 110
        /// </summary>
        public ImGuiKeyData KeysData110 { get; set; }

        /// <summary>
        ///     The keysdata 111
        /// </summary>
        public ImGuiKeyData KeysData111 { get; set; }

        /// <summary>
        ///     The keysdata 112
        /// </summary>
        public ImGuiKeyData KeysData112 { get; set; }

        /// <summary>
        ///     The keysdata 113
        /// </summary>
        public ImGuiKeyData KeysData113 { get; set; }

        /// <summary>
        ///     The keysdata 114
        /// </summary>
        public ImGuiKeyData KeysData114 { get; set; }

        /// <summary>
        ///     The keysdata 115
        /// </summary>
        public ImGuiKeyData KeysData115 { get; set; }

        /// <summary>
        ///     The keysdata 116
        /// </summary>
        public ImGuiKeyData KeysData116 { get; set; }

        /// <summary>
        ///     The keysdata 117
        /// </summary>
        public ImGuiKeyData KeysData117 { get; set; }

        /// <summary>
        ///     The keysdata 118
        /// </summary>
        public ImGuiKeyData KeysData118 { get; set; }

        /// <summary>
        ///     The keysdata 119
        /// </summary>
        public ImGuiKeyData KeysData119 { get; set; }

        /// <summary>
        ///     The keysdata 120
        /// </summary>
        public ImGuiKeyData KeysData120 { get; set; }

        /// <summary>
        ///     The keysdata 121
        /// </summary>
        public ImGuiKeyData KeysData121 { get; set; }

        /// <summary>
        ///     The keysdata 122
        /// </summary>
        public ImGuiKeyData KeysData122 { get; set; }

        /// <summary>
        ///     The keysdata 123
        /// </summary>
        public ImGuiKeyData KeysData123 { get; set; }

        /// <summary>
        ///     The keysdata 124
        /// </summary>
        public ImGuiKeyData KeysData124 { get; set; }

        /// <summary>
        ///     The keysdata 125
        /// </summary>
        public ImGuiKeyData KeysData125 { get; set; }

        /// <summary>
        ///     The keysdata 126
        /// </summary>
        public ImGuiKeyData KeysData126 { get; set; }

        /// <summary>
        ///     The keysdata 127
        /// </summary>
        public ImGuiKeyData KeysData127 { get; set; }

        /// <summary>
        ///     The keysdata 128
        /// </summary>
        public ImGuiKeyData KeysData128 { get; set; }

        /// <summary>
        ///     The keysdata 129
        /// </summary>
        public ImGuiKeyData KeysData129 { get; set; }

        /// <summary>
        ///     The keysdata 130
        /// </summary>
        public ImGuiKeyData KeysData130 { get; set; }

        /// <summary>
        ///     The keysdata 131
        /// </summary>
        public ImGuiKeyData KeysData131 { get; set; }

        /// <summary>
        ///     The keysdata 132
        /// </summary>
        public ImGuiKeyData KeysData132 { get; set; }

        /// <summary>
        ///     The keysdata 133
        /// </summary>
        public ImGuiKeyData KeysData133 { get; set; }

        /// <summary>
        ///     The keysdata 134
        /// </summary>
        public ImGuiKeyData KeysData134 { get; set; }

        /// <summary>
        ///     The keysdata 135
        /// </summary>
        public ImGuiKeyData KeysData135 { get; set; }

        /// <summary>
        ///     The keysdata 136
        /// </summary>
        public ImGuiKeyData KeysData136 { get; set; }

        /// <summary>
        ///     The keysdata 137
        /// </summary>
        public ImGuiKeyData KeysData137 { get; set; }

        /// <summary>
        ///     The keysdata 138
        /// </summary>
        public ImGuiKeyData KeysData138 { get; set; }

        /// <summary>
        ///     The keysdata 139
        /// </summary>
        public ImGuiKeyData KeysData139 { get; set; }

        /// <summary>
        ///     The keysdata 140
        /// </summary>
        public ImGuiKeyData KeysData140 { get; set; }

        /// <summary>
        ///     The keysdata 141
        /// </summary>
        public ImGuiKeyData KeysData141 { get; set; }

        /// <summary>
        ///     The keysdata 142
        /// </summary>
        public ImGuiKeyData KeysData142 { get; set; }

        /// <summary>
        ///     The keysdata 143
        /// </summary>
        public ImGuiKeyData KeysData143 { get; set; }

        /// <summary>
        ///     The keysdata 144
        /// </summary>
        public ImGuiKeyData KeysData144 { get; set; }

        /// <summary>
        ///     The keysdata 145
        /// </summary>
        public ImGuiKeyData KeysData145 { get; set; }

        /// <summary>
        ///     The keysdata 146
        /// </summary>
        public ImGuiKeyData KeysData146 { get; set; }

        /// <summary>
        ///     The keysdata 147
        /// </summary>
        public ImGuiKeyData KeysData147 { get; set; }

        /// <summary>
        ///     The keysdata 148
        /// </summary>
        public ImGuiKeyData KeysData148 { get; set; }

        /// <summary>
        ///     The keysdata 149
        /// </summary>
        public ImGuiKeyData KeysData149 { get; set; }

        /// <summary>
        ///     The keysdata 150
        /// </summary>
        public ImGuiKeyData KeysData150 { get; set; }

        /// <summary>
        ///     The keysdata 151
        /// </summary>
        public ImGuiKeyData KeysData151 { get; set; }

        /// <summary>
        ///     The keysdata 152
        /// </summary>
        public ImGuiKeyData KeysData152 { get; set; }

        /// <summary>
        ///     The keysdata 153
        /// </summary>
        public ImGuiKeyData KeysData153 { get; set; }

        /// <summary>
        ///     The keysdata 154
        /// </summary>
        public ImGuiKeyData KeysData154 { get; set; }

        /// <summary>
        ///     The keysdata 155
        /// </summary>
        public ImGuiKeyData KeysData155 { get; set; }

        /// <summary>
        ///     The keysdata 156
        /// </summary>
        public ImGuiKeyData KeysData156 { get; set; }

        /// <summary>
        ///     The keysdata 157
        /// </summary>
        public ImGuiKeyData KeysData157 { get; set; }

        /// <summary>
        ///     The keysdata 158
        /// </summary>
        public ImGuiKeyData KeysData158 { get; set; }

        /// <summary>
        ///     The keysdata 159
        /// </summary>
        public ImGuiKeyData KeysData159 { get; set; }

        /// <summary>
        ///     The keysdata 160
        /// </summary>
        public ImGuiKeyData KeysData160 { get; set; }

        /// <summary>
        ///     The keysdata 161
        /// </summary>
        public ImGuiKeyData KeysData161 { get; set; }

        /// <summary>
        ///     The keysdata 162
        /// </summary>
        public ImGuiKeyData KeysData162 { get; set; }

        /// <summary>
        ///     The keysdata 163
        /// </summary>
        public ImGuiKeyData KeysData163 { get; set; }

        /// <summary>
        ///     The keysdata 164
        /// </summary>
        public ImGuiKeyData KeysData164 { get; set; }

        /// <summary>
        ///     The keysdata 165
        /// </summary>
        public ImGuiKeyData KeysData165 { get; set; }

        /// <summary>
        ///     The keysdata 166
        /// </summary>
        public ImGuiKeyData KeysData166 { get; set; }

        /// <summary>
        ///     The keysdata 167
        /// </summary>
        public ImGuiKeyData KeysData167 { get; set; }

        /// <summary>
        ///     The keysdata 168
        /// </summary>
        public ImGuiKeyData KeysData168 { get; set; }

        /// <summary>
        ///     The keysdata 169
        /// </summary>
        public ImGuiKeyData KeysData169 { get; set; }

        /// <summary>
        ///     The keysdata 170
        /// </summary>
        public ImGuiKeyData KeysData170 { get; set; }

        /// <summary>
        ///     The keysdata 171
        /// </summary>
        public ImGuiKeyData KeysData171 { get; set; }

        /// <summary>
        ///     The keysdata 172
        /// </summary>
        public ImGuiKeyData KeysData172 { get; set; }

        /// <summary>
        ///     The keysdata 173
        /// </summary>
        public ImGuiKeyData KeysData173 { get; set; }

        /// <summary>
        ///     The keysdata 174
        /// </summary>
        public ImGuiKeyData KeysData174 { get; set; }

        /// <summary>
        ///     The keysdata 175
        /// </summary>
        public ImGuiKeyData KeysData175 { get; set; }

        /// <summary>
        ///     The keysdata 176
        /// </summary>
        public ImGuiKeyData KeysData176 { get; set; }

        /// <summary>
        ///     The keysdata 177
        /// </summary>
        public ImGuiKeyData KeysData177 { get; set; }

        /// <summary>
        ///     The keysdata 178
        /// </summary>
        public ImGuiKeyData KeysData178 { get; set; }

        /// <summary>
        ///     The keysdata 179
        /// </summary>
        public ImGuiKeyData KeysData179 { get; set; }

        /// <summary>
        ///     The keysdata 180
        /// </summary>
        public ImGuiKeyData KeysData180 { get; set; }

        /// <summary>
        ///     The keysdata 181
        /// </summary>
        public ImGuiKeyData KeysData181 { get; set; }

        /// <summary>
        ///     The keysdata 182
        /// </summary>
        public ImGuiKeyData KeysData182 { get; set; }

        /// <summary>
        ///     The keysdata 183
        /// </summary>
        public ImGuiKeyData KeysData183 { get; set; }

        /// <summary>
        ///     The keysdata 184
        /// </summary>
        public ImGuiKeyData KeysData184 { get; set; }

        /// <summary>
        ///     The keysdata 185
        /// </summary>
        public ImGuiKeyData KeysData185 { get; set; }

        /// <summary>
        ///     The keysdata 186
        /// </summary>
        public ImGuiKeyData KeysData186 { get; set; }

        /// <summary>
        ///     The keysdata 187
        /// </summary>
        public ImGuiKeyData KeysData187 { get; set; }

        /// <summary>
        ///     The keysdata 188
        /// </summary>
        public ImGuiKeyData KeysData188 { get; set; }

        /// <summary>
        ///     The keysdata 189
        /// </summary>
        public ImGuiKeyData KeysData189 { get; set; }

        /// <summary>
        ///     The keysdata 190
        /// </summary>
        public ImGuiKeyData KeysData190 { get; set; }

        /// <summary>
        ///     The keysdata 191
        /// </summary>
        public ImGuiKeyData KeysData191 { get; set; }

        /// <summary>
        ///     The keysdata 192
        /// </summary>
        public ImGuiKeyData KeysData192 { get; set; }

        /// <summary>
        ///     The keysdata 193
        /// </summary>
        public ImGuiKeyData KeysData193 { get; set; }

        /// <summary>
        ///     The keysdata 194
        /// </summary>
        public ImGuiKeyData KeysData194 { get; set; }

        /// <summary>
        ///     The keysdata 195
        /// </summary>
        public ImGuiKeyData KeysData195 { get; set; }

        /// <summary>
        ///     The keysdata 196
        /// </summary>
        public ImGuiKeyData KeysData196 { get; set; }

        /// <summary>
        ///     The keysdata 197
        /// </summary>
        public ImGuiKeyData KeysData197 { get; set; }

        /// <summary>
        ///     The keysdata 198
        /// </summary>
        public ImGuiKeyData KeysData198 { get; set; }

        /// <summary>
        ///     The keysdata 199
        /// </summary>
        public ImGuiKeyData KeysData199 { get; set; }

        /// <summary>
        ///     The keysdata 200
        /// </summary>
        public ImGuiKeyData KeysData200 { get; set; }

        /// <summary>
        ///     The keysdata 201
        /// </summary>
        public ImGuiKeyData KeysData201 { get; set; }

        /// <summary>
        ///     The keysdata 202
        /// </summary>
        public ImGuiKeyData KeysData202 { get; set; }

        /// <summary>
        ///     The keysdata 203
        /// </summary>
        public ImGuiKeyData KeysData203 { get; set; }

        /// <summary>
        ///     The keysdata 204
        /// </summary>
        public ImGuiKeyData KeysData204 { get; set; }

        /// <summary>
        ///     The keysdata 205
        /// </summary>
        public ImGuiKeyData KeysData205 { get; set; }

        /// <summary>
        ///     The keysdata 206
        /// </summary>
        public ImGuiKeyData KeysData206 { get; set; }

        /// <summary>
        ///     The keysdata 207
        /// </summary>
        public ImGuiKeyData KeysData207 { get; set; }

        /// <summary>
        ///     The keysdata 208
        /// </summary>
        public ImGuiKeyData KeysData208 { get; set; }

        /// <summary>
        ///     The keysdata 209
        /// </summary>
        public ImGuiKeyData KeysData209 { get; set; }

        /// <summary>
        ///     The keysdata 210
        /// </summary>
        public ImGuiKeyData KeysData210 { get; set; }

        /// <summary>
        ///     The keysdata 211
        /// </summary>
        public ImGuiKeyData KeysData211 { get; set; }

        /// <summary>
        ///     The keysdata 212
        /// </summary>
        public ImGuiKeyData KeysData212 { get; set; }

        /// <summary>
        ///     The keysdata 213
        /// </summary>
        public ImGuiKeyData KeysData213 { get; set; }

        /// <summary>
        ///     The keysdata 214
        /// </summary>
        public ImGuiKeyData KeysData214 { get; set; }

        /// <summary>
        ///     The keysdata 215
        /// </summary>
        public ImGuiKeyData KeysData215 { get; set; }

        /// <summary>
        ///     The keysdata 216
        /// </summary>
        public ImGuiKeyData KeysData216 { get; set; }

        /// <summary>
        ///     The keysdata 217
        /// </summary>
        public ImGuiKeyData KeysData217 { get; set; }

        /// <summary>
        ///     The keysdata 218
        /// </summary>
        public ImGuiKeyData KeysData218 { get; set; }

        /// <summary>
        ///     The keysdata 219
        /// </summary>
        public ImGuiKeyData KeysData219 { get; set; }

        /// <summary>
        ///     The keysdata 220
        /// </summary>
        public ImGuiKeyData KeysData220 { get; set; }

        /// <summary>
        ///     The keysdata 221
        /// </summary>
        public ImGuiKeyData KeysData221 { get; set; }

        /// <summary>
        ///     The keysdata 222
        /// </summary>
        public ImGuiKeyData KeysData222 { get; set; }

        /// <summary>
        ///     The keysdata 223
        /// </summary>
        public ImGuiKeyData KeysData223 { get; set; }

        /// <summary>
        ///     The keysdata 224
        /// </summary>
        public ImGuiKeyData KeysData224 { get; set; }

        /// <summary>
        ///     The keysdata 225
        /// </summary>
        public ImGuiKeyData KeysData225 { get; set; }

        /// <summary>
        ///     The keysdata 226
        /// </summary>
        public ImGuiKeyData KeysData226 { get; set; }

        /// <summary>
        ///     The keysdata 227
        /// </summary>
        public ImGuiKeyData KeysData227 { get; set; }

        /// <summary>
        ///     The keysdata 228
        /// </summary>
        public ImGuiKeyData KeysData228 { get; set; }

        /// <summary>
        ///     The keysdata 229
        /// </summary>
        public ImGuiKeyData KeysData229 { get; set; }

        /// <summary>
        ///     The keysdata 230
        /// </summary>
        public ImGuiKeyData KeysData230 { get; set; }

        /// <summary>
        ///     The keysdata 231
        /// </summary>
        public ImGuiKeyData KeysData231 { get; set; }

        /// <summary>
        ///     The keysdata 232
        /// </summary>
        public ImGuiKeyData KeysData232 { get; set; }

        /// <summary>
        ///     The keysdata 233
        /// </summary>
        public ImGuiKeyData KeysData233 { get; set; }

        /// <summary>
        ///     The keysdata 234
        /// </summary>
        public ImGuiKeyData KeysData234 { get; set; }

        /// <summary>
        ///     The keysdata 235
        /// </summary>
        public ImGuiKeyData KeysData235 { get; set; }

        /// <summary>
        ///     The keysdata 236
        /// </summary>
        public ImGuiKeyData KeysData236 { get; set; }

        /// <summary>
        ///     The keysdata 237
        /// </summary>
        public ImGuiKeyData KeysData237 { get; set; }

        /// <summary>
        ///     The keysdata 238
        /// </summary>
        public ImGuiKeyData KeysData238 { get; set; }

        /// <summary>
        ///     The keysdata 239
        /// </summary>
        public ImGuiKeyData KeysData239 { get; set; }

        /// <summary>
        ///     The keysdata 240
        /// </summary>
        public ImGuiKeyData KeysData240 { get; set; }

        /// <summary>
        ///     The keysdata 241
        /// </summary>
        public ImGuiKeyData KeysData241 { get; set; }

        /// <summary>
        ///     The keysdata 242
        /// </summary>
        public ImGuiKeyData KeysData242 { get; set; }

        /// <summary>
        ///     The keysdata 243
        /// </summary>
        public ImGuiKeyData KeysData243 { get; set; }

        /// <summary>
        ///     The keysdata 244
        /// </summary>
        public ImGuiKeyData KeysData244 { get; set; }

        /// <summary>
        ///     The keysdata 245
        /// </summary>
        public ImGuiKeyData KeysData245 { get; set; }

        /// <summary>
        ///     The keysdata 246
        /// </summary>
        public ImGuiKeyData KeysData246 { get; set; }

        /// <summary>
        ///     The keysdata 247
        /// </summary>
        public ImGuiKeyData KeysData247 { get; set; }

        /// <summary>
        ///     The keysdata 248
        /// </summary>
        public ImGuiKeyData KeysData248 { get; set; }

        /// <summary>
        ///     The keysdata 249
        /// </summary>
        public ImGuiKeyData KeysData249 { get; set; }

        /// <summary>
        ///     The keysdata 250
        /// </summary>
        public ImGuiKeyData KeysData250 { get; set; }

        /// <summary>
        ///     The keysdata 251
        /// </summary>
        public ImGuiKeyData KeysData251 { get; set; }

        /// <summary>
        ///     The keysdata 252
        /// </summary>
        public ImGuiKeyData KeysData252 { get; set; }

        /// <summary>
        ///     The keysdata 253
        /// </summary>
        public ImGuiKeyData KeysData253 { get; set; }

        /// <summary>
        ///     The keysdata 254
        /// </summary>
        public ImGuiKeyData KeysData254 { get; set; }

        /// <summary>
        ///     The keysdata 255
        /// </summary>
        public ImGuiKeyData KeysData255 { get; set; }

        /// <summary>
        ///     The keysdata 256
        /// </summary>
        public ImGuiKeyData KeysData256 { get; set; }

        /// <summary>
        ///     The keysdata 257
        /// </summary>
        public ImGuiKeyData KeysData257 { get; set; }

        /// <summary>
        ///     The keysdata 258
        /// </summary>
        public ImGuiKeyData KeysData258 { get; set; }

        /// <summary>
        ///     The keysdata 259
        /// </summary>
        public ImGuiKeyData KeysData259 { get; set; }

        /// <summary>
        ///     The keysdata 260
        /// </summary>
        public ImGuiKeyData KeysData260 { get; set; }

        /// <summary>
        ///     The keysdata 261
        /// </summary>
        public ImGuiKeyData KeysData261 { get; set; }

        /// <summary>
        ///     The keysdata 262
        /// </summary>
        public ImGuiKeyData KeysData262 { get; set; }

        /// <summary>
        ///     The keysdata 263
        /// </summary>
        public ImGuiKeyData KeysData263 { get; set; }

        /// <summary>
        ///     The keysdata 264
        /// </summary>
        public ImGuiKeyData KeysData264 { get; set; }

        /// <summary>
        ///     The keysdata 265
        /// </summary>
        public ImGuiKeyData KeysData265 { get; set; }

        /// <summary>
        ///     The keysdata 266
        /// </summary>
        public ImGuiKeyData KeysData266 { get; set; }

        /// <summary>
        ///     The keysdata 267
        /// </summary>
        public ImGuiKeyData KeysData267 { get; set; }

        /// <summary>
        ///     The keysdata 268
        /// </summary>
        public ImGuiKeyData KeysData268 { get; set; }

        /// <summary>
        ///     The keysdata 269
        /// </summary>
        public ImGuiKeyData KeysData269 { get; set; }

        /// <summary>
        ///     The keysdata 270
        /// </summary>
        public ImGuiKeyData KeysData270 { get; set; }

        /// <summary>
        ///     The keysdata 271
        /// </summary>
        public ImGuiKeyData KeysData271 { get; set; }

        /// <summary>
        ///     The keysdata 272
        /// </summary>
        public ImGuiKeyData KeysData272 { get; set; }

        /// <summary>
        ///     The keysdata 273
        /// </summary>
        public ImGuiKeyData KeysData273 { get; set; }

        /// <summary>
        ///     The keysdata 274
        /// </summary>
        public ImGuiKeyData KeysData274 { get; set; }

        /// <summary>
        ///     The keysdata 275
        /// </summary>
        public ImGuiKeyData KeysData275 { get; set; }

        /// <summary>
        ///     The keysdata 276
        /// </summary>
        public ImGuiKeyData KeysData276 { get; set; }

        /// <summary>
        ///     The keysdata 277
        /// </summary>
        public ImGuiKeyData KeysData277 { get; set; }

        /// <summary>
        ///     The keysdata 278
        /// </summary>
        public ImGuiKeyData KeysData278 { get; set; }

        /// <summary>
        ///     The keysdata 279
        /// </summary>
        public ImGuiKeyData KeysData279 { get; set; }

        /// <summary>
        ///     The keysdata 280
        /// </summary>
        public ImGuiKeyData KeysData280 { get; set; }

        /// <summary>
        ///     The keysdata 281
        /// </summary>
        public ImGuiKeyData KeysData281 { get; set; }

        /// <summary>
        ///     The keysdata 282
        /// </summary>
        public ImGuiKeyData KeysData282 { get; set; }

        /// <summary>
        ///     The keysdata 283
        /// </summary>
        public ImGuiKeyData KeysData283 { get; set; }

        /// <summary>
        ///     The keysdata 284
        /// </summary>
        public ImGuiKeyData KeysData284 { get; set; }

        /// <summary>
        ///     The keysdata 285
        /// </summary>
        public ImGuiKeyData KeysData285 { get; set; }

        /// <summary>
        ///     The keysdata 286
        /// </summary>
        public ImGuiKeyData KeysData286 { get; set; }

        /// <summary>
        ///     The keysdata 287
        /// </summary>
        public ImGuiKeyData KeysData287 { get; set; }

        /// <summary>
        ///     The keysdata 288
        /// </summary>
        public ImGuiKeyData KeysData288 { get; set; }

        /// <summary>
        ///     The keysdata 289
        /// </summary>
        public ImGuiKeyData KeysData289 { get; set; }

        /// <summary>
        ///     The keysdata 290
        /// </summary>
        public ImGuiKeyData KeysData290 { get; set; }

        /// <summary>
        ///     The keysdata 291
        /// </summary>
        public ImGuiKeyData KeysData291 { get; set; }

        /// <summary>
        ///     The keysdata 292
        /// </summary>
        public ImGuiKeyData KeysData292 { get; set; }

        /// <summary>
        ///     The keysdata 293
        /// </summary>
        public ImGuiKeyData KeysData293 { get; set; }

        /// <summary>
        ///     The keysdata 294
        /// </summary>
        public ImGuiKeyData KeysData294 { get; set; }

        /// <summary>
        ///     The keysdata 295
        /// </summary>
        public ImGuiKeyData KeysData295 { get; set; }

        /// <summary>
        ///     The keysdata 296
        /// </summary>
        public ImGuiKeyData KeysData296 { get; set; }

        /// <summary>
        ///     The keysdata 297
        /// </summary>
        public ImGuiKeyData KeysData297 { get; set; }

        /// <summary>
        ///     The keysdata 298
        /// </summary>
        public ImGuiKeyData KeysData298 { get; set; }

        /// <summary>
        ///     The keysdata 299
        /// </summary>
        public ImGuiKeyData KeysData299 { get; set; }

        /// <summary>
        ///     The keysdata 300
        /// </summary>
        public ImGuiKeyData KeysData300 { get; set; }

        /// <summary>
        ///     The keysdata 301
        /// </summary>
        public ImGuiKeyData KeysData301 { get; set; }

        /// <summary>
        ///     The keysdata 302
        /// </summary>
        public ImGuiKeyData KeysData302 { get; set; }

        /// <summary>
        ///     The keysdata 303
        /// </summary>
        public ImGuiKeyData KeysData303 { get; set; }

        /// <summary>
        ///     The keysdata 304
        /// </summary>
        public ImGuiKeyData KeysData304 { get; set; }

        /// <summary>
        ///     The keysdata 305
        /// </summary>
        public ImGuiKeyData KeysData305 { get; set; }

        /// <summary>
        ///     The keysdata 306
        /// </summary>
        public ImGuiKeyData KeysData306 { get; set; }

        /// <summary>
        ///     The keysdata 307
        /// </summary>
        public ImGuiKeyData KeysData307 { get; set; }

        /// <summary>
        ///     The keysdata 308
        /// </summary>
        public ImGuiKeyData KeysData308 { get; set; }

        /// <summary>
        ///     The keysdata 309
        /// </summary>
        public ImGuiKeyData KeysData309 { get; set; }

        /// <summary>
        ///     The keysdata 310
        /// </summary>
        public ImGuiKeyData KeysData310 { get; set; }

        /// <summary>
        ///     The keysdata 311
        /// </summary>
        public ImGuiKeyData KeysData311 { get; set; }

        /// <summary>
        ///     The keysdata 312
        /// </summary>
        public ImGuiKeyData KeysData312 { get; set; }

        /// <summary>
        ///     The keysdata 313
        /// </summary>
        public ImGuiKeyData KeysData313 { get; set; }

        /// <summary>
        ///     The keysdata 314
        /// </summary>
        public ImGuiKeyData KeysData314 { get; set; }

        /// <summary>
        ///     The keysdata 315
        /// </summary>
        public ImGuiKeyData KeysData315 { get; set; }

        /// <summary>
        ///     The keysdata 316
        /// </summary>
        public ImGuiKeyData KeysData316 { get; set; }

        /// <summary>
        ///     The keysdata 317
        /// </summary>
        public ImGuiKeyData KeysData317 { get; set; }

        /// <summary>
        ///     The keysdata 318
        /// </summary>
        public ImGuiKeyData KeysData318 { get; set; }

        /// <summary>
        ///     The keysdata 319
        /// </summary>
        public ImGuiKeyData KeysData319 { get; set; }

        /// <summary>
        ///     The keysdata 320
        /// </summary>
        public ImGuiKeyData KeysData320 { get; set; }

        /// <summary>
        ///     The keysdata 321
        /// </summary>
        public ImGuiKeyData KeysData321 { get; set; }

        /// <summary>
        ///     The keysdata 322
        /// </summary>
        public ImGuiKeyData KeysData322 { get; set; }

        /// <summary>
        ///     The keysdata 323
        /// </summary>
        public ImGuiKeyData KeysData323 { get; set; }

        /// <summary>
        ///     The keysdata 324
        /// </summary>
        public ImGuiKeyData KeysData324 { get; set; }

        /// <summary>
        ///     The keysdata 325
        /// </summary>
        public ImGuiKeyData KeysData325 { get; set; }

        /// <summary>
        ///     The keysdata 326
        /// </summary>
        public ImGuiKeyData KeysData326 { get; set; }

        /// <summary>
        ///     The keysdata 327
        /// </summary>
        public ImGuiKeyData KeysData327 { get; set; }

        /// <summary>
        ///     The keysdata 328
        /// </summary>
        public ImGuiKeyData KeysData328 { get; set; }

        /// <summary>
        ///     The keysdata 329
        /// </summary>
        public ImGuiKeyData KeysData329 { get; set; }

        /// <summary>
        ///     The keysdata 330
        /// </summary>
        public ImGuiKeyData KeysData330 { get; set; }

        /// <summary>
        ///     The keysdata 331
        /// </summary>
        public ImGuiKeyData KeysData331 { get; set; }

        /// <summary>
        ///     The keysdata 332
        /// </summary>
        public ImGuiKeyData KeysData332 { get; set; }

        /// <summary>
        ///     The keysdata 333
        /// </summary>
        public ImGuiKeyData KeysData333 { get; set; }

        /// <summary>
        ///     The keysdata 334
        /// </summary>
        public ImGuiKeyData KeysData334 { get; set; }

        /// <summary>
        ///     The keysdata 335
        /// </summary>
        public ImGuiKeyData KeysData335 { get; set; }

        /// <summary>
        ///     The keysdata 336
        /// </summary>
        public ImGuiKeyData KeysData336 { get; set; }

        /// <summary>
        ///     The keysdata 337
        /// </summary>
        public ImGuiKeyData KeysData337 { get; set; }

        /// <summary>
        ///     The keysdata 338
        /// </summary>
        public ImGuiKeyData KeysData338 { get; set; }

        /// <summary>
        ///     The keysdata 339
        /// </summary>
        public ImGuiKeyData KeysData339 { get; set; }

        /// <summary>
        ///     The keysdata 340
        /// </summary>
        public ImGuiKeyData KeysData340 { get; set; }

        /// <summary>
        ///     The keysdata 341
        /// </summary>
        public ImGuiKeyData KeysData341 { get; set; }

        /// <summary>
        ///     The keysdata 342
        /// </summary>
        public ImGuiKeyData KeysData342 { get; set; }

        /// <summary>
        ///     The keysdata 343
        /// </summary>
        public ImGuiKeyData KeysData343 { get; set; }

        /// <summary>
        ///     The keysdata 344
        /// </summary>
        public ImGuiKeyData KeysData344 { get; set; }

        /// <summary>
        ///     The keysdata 345
        /// </summary>
        public ImGuiKeyData KeysData345 { get; set; }

        /// <summary>
        ///     The keysdata 346
        /// </summary>
        public ImGuiKeyData KeysData346 { get; set; }

        /// <summary>
        ///     The keysdata 347
        /// </summary>
        public ImGuiKeyData KeysData347 { get; set; }

        /// <summary>
        ///     The keysdata 348
        /// </summary>
        public ImGuiKeyData KeysData348 { get; set; }

        /// <summary>
        ///     The keysdata 349
        /// </summary>
        public ImGuiKeyData KeysData349 { get; set; }

        /// <summary>
        ///     The keysdata 350
        /// </summary>
        public ImGuiKeyData KeysData350 { get; set; }

        /// <summary>
        ///     The keysdata 351
        /// </summary>
        public ImGuiKeyData KeysData351 { get; set; }

        /// <summary>
        ///     The keysdata 352
        /// </summary>
        public ImGuiKeyData KeysData352 { get; set; }

        /// <summary>
        ///     The keysdata 353
        /// </summary>
        public ImGuiKeyData KeysData353 { get; set; }

        /// <summary>
        ///     The keysdata 354
        /// </summary>
        public ImGuiKeyData KeysData354 { get; set; }

        /// <summary>
        ///     The keysdata 355
        /// </summary>
        public ImGuiKeyData KeysData355 { get; set; }

        /// <summary>
        ///     The keysdata 356
        /// </summary>
        public ImGuiKeyData KeysData356 { get; set; }

        /// <summary>
        ///     The keysdata 357
        /// </summary>
        public ImGuiKeyData KeysData357 { get; set; }

        /// <summary>
        ///     The keysdata 358
        /// </summary>
        public ImGuiKeyData KeysData358 { get; set; }

        /// <summary>
        ///     The keysdata 359
        /// </summary>
        public ImGuiKeyData KeysData359 { get; set; }

        /// <summary>
        ///     The keysdata 360
        /// </summary>
        public ImGuiKeyData KeysData360 { get; set; }

        /// <summary>
        ///     The keysdata 361
        /// </summary>
        public ImGuiKeyData KeysData361 { get; set; }

        /// <summary>
        ///     The keysdata 362
        /// </summary>
        public ImGuiKeyData KeysData362 { get; set; }

        /// <summary>
        ///     The keysdata 363
        /// </summary>
        public ImGuiKeyData KeysData363 { get; set; }

        /// <summary>
        ///     The keysdata 364
        /// </summary>
        public ImGuiKeyData KeysData364 { get; set; }

        /// <summary>
        ///     The keysdata 365
        /// </summary>
        public ImGuiKeyData KeysData365 { get; set; }

        /// <summary>
        ///     The keysdata 366
        /// </summary>
        public ImGuiKeyData KeysData366 { get; set; }

        /// <summary>
        ///     The keysdata 367
        /// </summary>
        public ImGuiKeyData KeysData367 { get; set; }

        /// <summary>
        ///     The keysdata 368
        /// </summary>
        public ImGuiKeyData KeysData368 { get; set; }

        /// <summary>
        ///     The keysdata 369
        /// </summary>
        public ImGuiKeyData KeysData369 { get; set; }

        /// <summary>
        ///     The keysdata 370
        /// </summary>
        public ImGuiKeyData KeysData370 { get; set; }

        /// <summary>
        ///     The keysdata 371
        /// </summary>
        public ImGuiKeyData KeysData371 { get; set; }

        /// <summary>
        ///     The keysdata 372
        /// </summary>
        public ImGuiKeyData KeysData372 { get; set; }

        /// <summary>
        ///     The keysdata 373
        /// </summary>
        public ImGuiKeyData KeysData373 { get; set; }

        /// <summary>
        ///     The keysdata 374
        /// </summary>
        public ImGuiKeyData KeysData374 { get; set; }

        /// <summary>
        ///     The keysdata 375
        /// </summary>
        public ImGuiKeyData KeysData375 { get; set; }

        /// <summary>
        ///     The keysdata 376
        /// </summary>
        public ImGuiKeyData KeysData376 { get; set; }

        /// <summary>
        ///     The keysdata 377
        /// </summary>
        public ImGuiKeyData KeysData377 { get; set; }

        /// <summary>
        ///     The keysdata 378
        /// </summary>
        public ImGuiKeyData KeysData378 { get; set; }

        /// <summary>
        ///     The keysdata 379
        /// </summary>
        public ImGuiKeyData KeysData379 { get; set; }

        /// <summary>
        ///     The keysdata 380
        /// </summary>
        public ImGuiKeyData KeysData380 { get; set; }

        /// <summary>
        ///     The keysdata 381
        /// </summary>
        public ImGuiKeyData KeysData381 { get; set; }

        /// <summary>
        ///     The keysdata 382
        /// </summary>
        public ImGuiKeyData KeysData382 { get; set; }

        /// <summary>
        ///     The keysdata 383
        /// </summary>
        public ImGuiKeyData KeysData383 { get; set; }

        /// <summary>
        ///     The keysdata 384
        /// </summary>
        public ImGuiKeyData KeysData384 { get; set; }

        /// <summary>
        ///     The keysdata 385
        /// </summary>
        public ImGuiKeyData KeysData385 { get; set; }

        /// <summary>
        ///     The keysdata 386
        /// </summary>
        public ImGuiKeyData KeysData386 { get; set; }

        /// <summary>
        ///     The keysdata 387
        /// </summary>
        public ImGuiKeyData KeysData387 { get; set; }

        /// <summary>
        ///     The keysdata 388
        /// </summary>
        public ImGuiKeyData KeysData388 { get; set; }

        /// <summary>
        ///     The keysdata 389
        /// </summary>
        public ImGuiKeyData KeysData389 { get; set; }

        /// <summary>
        ///     The keysdata 390
        /// </summary>
        public ImGuiKeyData KeysData390 { get; set; }

        /// <summary>
        ///     The keysdata 391
        /// </summary>
        public ImGuiKeyData KeysData391 { get; set; }

        /// <summary>
        ///     The keysdata 392
        /// </summary>
        public ImGuiKeyData KeysData392 { get; set; }

        /// <summary>
        ///     The keysdata 393
        /// </summary>
        public ImGuiKeyData KeysData393 { get; set; }

        /// <summary>
        ///     The keysdata 394
        /// </summary>
        public ImGuiKeyData KeysData394 { get; set; }

        /// <summary>
        ///     The keysdata 395
        /// </summary>
        public ImGuiKeyData KeysData395 { get; set; }

        /// <summary>
        ///     The keysdata 396
        /// </summary>
        public ImGuiKeyData KeysData396 { get; set; }

        /// <summary>
        ///     The keysdata 397
        /// </summary>
        public ImGuiKeyData KeysData397 { get; set; }

        /// <summary>
        ///     The keysdata 398
        /// </summary>
        public ImGuiKeyData KeysData398 { get; set; }

        /// <summary>
        ///     The keysdata 399
        /// </summary>
        public ImGuiKeyData KeysData399 { get; set; }

        /// <summary>
        ///     The keysdata 400
        /// </summary>
        public ImGuiKeyData KeysData400 { get; set; }

        /// <summary>
        ///     The keysdata 401
        /// </summary>
        public ImGuiKeyData KeysData401 { get; set; }

        /// <summary>
        ///     The keysdata 402
        /// </summary>
        public ImGuiKeyData KeysData402 { get; set; }

        /// <summary>
        ///     The keysdata 403
        /// </summary>
        public ImGuiKeyData KeysData403 { get; set; }

        /// <summary>
        ///     The keysdata 404
        /// </summary>
        public ImGuiKeyData KeysData404 { get; set; }

        /// <summary>
        ///     The keysdata 405
        /// </summary>
        public ImGuiKeyData KeysData405 { get; set; }

        /// <summary>
        ///     The keysdata 406
        /// </summary>
        public ImGuiKeyData KeysData406 { get; set; }

        /// <summary>
        ///     The keysdata 407
        /// </summary>
        public ImGuiKeyData KeysData407 { get; set; }

        /// <summary>
        ///     The keysdata 408
        /// </summary>
        public ImGuiKeyData KeysData408 { get; set; }

        /// <summary>
        ///     The keysdata 409
        /// </summary>
        public ImGuiKeyData KeysData409 { get; set; }

        /// <summary>
        ///     The keysdata 410
        /// </summary>
        public ImGuiKeyData KeysData410 { get; set; }

        /// <summary>
        ///     The keysdata 411
        /// </summary>
        public ImGuiKeyData KeysData411 { get; set; }

        /// <summary>
        ///     The keysdata 412
        /// </summary>
        public ImGuiKeyData KeysData412 { get; set; }

        /// <summary>
        ///     The keysdata 413
        /// </summary>
        public ImGuiKeyData KeysData413 { get; set; }

        /// <summary>
        ///     The keysdata 414
        /// </summary>
        public ImGuiKeyData KeysData414 { get; set; }

        /// <summary>
        ///     The keysdata 415
        /// </summary>
        public ImGuiKeyData KeysData415 { get; set; }

        /// <summary>
        ///     The keysdata 416
        /// </summary>
        public ImGuiKeyData KeysData416 { get; set; }

        /// <summary>
        ///     The keysdata 417
        /// </summary>
        public ImGuiKeyData KeysData417 { get; set; }

        /// <summary>
        ///     The keysdata 418
        /// </summary>
        public ImGuiKeyData KeysData418 { get; set; }

        /// <summary>
        ///     The keysdata 419
        /// </summary>
        public ImGuiKeyData KeysData419 { get; set; }

        /// <summary>
        ///     The keysdata 420
        /// </summary>
        public ImGuiKeyData KeysData420 { get; set; }

        /// <summary>
        ///     The keysdata 421
        /// </summary>
        public ImGuiKeyData KeysData421 { get; set; }

        /// <summary>
        ///     The keysdata 422
        /// </summary>
        public ImGuiKeyData KeysData422 { get; set; }

        /// <summary>
        ///     The keysdata 423
        /// </summary>
        public ImGuiKeyData KeysData423 { get; set; }

        /// <summary>
        ///     The keysdata 424
        /// </summary>
        public ImGuiKeyData KeysData424 { get; set; }

        /// <summary>
        ///     The keysdata 425
        /// </summary>
        public ImGuiKeyData KeysData425 { get; set; }

        /// <summary>
        ///     The keysdata 426
        /// </summary>
        public ImGuiKeyData KeysData426 { get; set; }

        /// <summary>
        ///     The keysdata 427
        /// </summary>
        public ImGuiKeyData KeysData427 { get; set; }

        /// <summary>
        ///     The keysdata 428
        /// </summary>
        public ImGuiKeyData KeysData428 { get; set; }

        /// <summary>
        ///     The keysdata 429
        /// </summary>
        public ImGuiKeyData KeysData429 { get; set; }

        /// <summary>
        ///     The keysdata 430
        /// </summary>
        public ImGuiKeyData KeysData430 { get; set; }

        /// <summary>
        ///     The keysdata 431
        /// </summary>
        public ImGuiKeyData KeysData431 { get; set; }

        /// <summary>
        ///     The keysdata 432
        /// </summary>
        public ImGuiKeyData KeysData432 { get; set; }

        /// <summary>
        ///     The keysdata 433
        /// </summary>
        public ImGuiKeyData KeysData433 { get; set; }

        /// <summary>
        ///     The keysdata 434
        /// </summary>
        public ImGuiKeyData KeysData434 { get; set; }

        /// <summary>
        ///     The keysdata 435
        /// </summary>
        public ImGuiKeyData KeysData435 { get; set; }

        /// <summary>
        ///     The keysdata 436
        /// </summary>
        public ImGuiKeyData KeysData436 { get; set; }

        /// <summary>
        ///     The keysdata 437
        /// </summary>
        public ImGuiKeyData KeysData437 { get; set; }

        /// <summary>
        ///     The keysdata 438
        /// </summary>
        public ImGuiKeyData KeysData438 { get; set; }

        /// <summary>
        ///     The keysdata 439
        /// </summary>
        public ImGuiKeyData KeysData439 { get; set; }

        /// <summary>
        ///     The keysdata 440
        /// </summary>
        public ImGuiKeyData KeysData440 { get; set; }

        /// <summary>
        ///     The keysdata 441
        /// </summary>
        public ImGuiKeyData KeysData441 { get; set; }

        /// <summary>
        ///     The keysdata 442
        /// </summary>
        public ImGuiKeyData KeysData442 { get; set; }

        /// <summary>
        ///     The keysdata 443
        /// </summary>
        public ImGuiKeyData KeysData443 { get; set; }

        /// <summary>
        ///     The keysdata 444
        /// </summary>
        public ImGuiKeyData KeysData444 { get; set; }

        /// <summary>
        ///     The keysdata 445
        /// </summary>
        public ImGuiKeyData KeysData445 { get; set; }

        /// <summary>
        ///     The keysdata 446
        /// </summary>
        public ImGuiKeyData KeysData446 { get; set; }

        /// <summary>
        ///     The keysdata 447
        /// </summary>
        public ImGuiKeyData KeysData447 { get; set; }

        /// <summary>
        ///     The keysdata 448
        /// </summary>
        public ImGuiKeyData KeysData448 { get; set; }

        /// <summary>
        ///     The keysdata 449
        /// </summary>
        public ImGuiKeyData KeysData449 { get; set; }

        /// <summary>
        ///     The keysdata 450
        /// </summary>
        public ImGuiKeyData KeysData450 { get; set; }

        /// <summary>
        ///     The keysdata 451
        /// </summary>
        public ImGuiKeyData KeysData451 { get; set; }

        /// <summary>
        ///     The keysdata 452
        /// </summary>
        public ImGuiKeyData KeysData452 { get; set; }

        /// <summary>
        ///     The keysdata 453
        /// </summary>
        public ImGuiKeyData KeysData453 { get; set; }

        /// <summary>
        ///     The keysdata 454
        /// </summary>
        public ImGuiKeyData KeysData454 { get; set; }

        /// <summary>
        ///     The keysdata 455
        /// </summary>
        public ImGuiKeyData KeysData455 { get; set; }

        /// <summary>
        ///     The keysdata 456
        /// </summary>
        public ImGuiKeyData KeysData456 { get; set; }

        /// <summary>
        ///     The keysdata 457
        /// </summary>
        public ImGuiKeyData KeysData457 { get; set; }

        /// <summary>
        ///     The keysdata 458
        /// </summary>
        public ImGuiKeyData KeysData458 { get; set; }

        /// <summary>
        ///     The keysdata 459
        /// </summary>
        public ImGuiKeyData KeysData459 { get; set; }

        /// <summary>
        ///     The keysdata 460
        /// </summary>
        public ImGuiKeyData KeysData460 { get; set; }

        /// <summary>
        ///     The keysdata 461
        /// </summary>
        public ImGuiKeyData KeysData461 { get; set; }

        /// <summary>
        ///     The keysdata 462
        /// </summary>
        public ImGuiKeyData KeysData462 { get; set; }

        /// <summary>
        ///     The keysdata 463
        /// </summary>
        public ImGuiKeyData KeysData463 { get; set; }

        /// <summary>
        ///     The keysdata 464
        /// </summary>
        public ImGuiKeyData KeysData464 { get; set; }

        /// <summary>
        ///     The keysdata 465
        /// </summary>
        public ImGuiKeyData KeysData465 { get; set; }

        /// <summary>
        ///     The keysdata 466
        /// </summary>
        public ImGuiKeyData KeysData466 { get; set; }

        /// <summary>
        ///     The keysdata 467
        /// </summary>
        public ImGuiKeyData KeysData467 { get; set; }

        /// <summary>
        ///     The keysdata 468
        /// </summary>
        public ImGuiKeyData KeysData468 { get; set; }

        /// <summary>
        ///     The keysdata 469
        /// </summary>
        public ImGuiKeyData KeysData469 { get; set; }

        /// <summary>
        ///     The keysdata 470
        /// </summary>
        public ImGuiKeyData KeysData470 { get; set; }

        /// <summary>
        ///     The keysdata 471
        /// </summary>
        public ImGuiKeyData KeysData471 { get; set; }

        /// <summary>
        ///     The keysdata 472
        /// </summary>
        public ImGuiKeyData KeysData472 { get; set; }

        /// <summary>
        ///     The keysdata 473
        /// </summary>
        public ImGuiKeyData KeysData473 { get; set; }

        /// <summary>
        ///     The keysdata 474
        /// </summary>
        public ImGuiKeyData KeysData474 { get; set; }

        /// <summary>
        ///     The keysdata 475
        /// </summary>
        public ImGuiKeyData KeysData475 { get; set; }

        /// <summary>
        ///     The keysdata 476
        /// </summary>
        public ImGuiKeyData KeysData476 { get; set; }

        /// <summary>
        ///     The keysdata 477
        /// </summary>
        public ImGuiKeyData KeysData477 { get; set; }

        /// <summary>
        ///     The keysdata 478
        /// </summary>
        public ImGuiKeyData KeysData478 { get; set; }

        /// <summary>
        ///     The keysdata 479
        /// </summary>
        public ImGuiKeyData KeysData479 { get; set; }

        /// <summary>
        ///     The keysdata 480
        /// </summary>
        public ImGuiKeyData KeysData480 { get; set; }

        /// <summary>
        ///     The keysdata 481
        /// </summary>
        public ImGuiKeyData KeysData481 { get; set; }

        /// <summary>
        ///     The keysdata 482
        /// </summary>
        public ImGuiKeyData KeysData482 { get; set; }

        /// <summary>
        ///     The keysdata 483
        /// </summary>
        public ImGuiKeyData KeysData483 { get; set; }

        /// <summary>
        ///     The keysdata 484
        /// </summary>
        public ImGuiKeyData KeysData484 { get; set; }

        /// <summary>
        ///     The keysdata 485
        /// </summary>
        public ImGuiKeyData KeysData485 { get; set; }

        /// <summary>
        ///     The keysdata 486
        /// </summary>
        public ImGuiKeyData KeysData486 { get; set; }

        /// <summary>
        ///     The keysdata 487
        /// </summary>
        public ImGuiKeyData KeysData487 { get; set; }

        /// <summary>
        ///     The keysdata 488
        /// </summary>
        public ImGuiKeyData KeysData488 { get; set; }

        /// <summary>
        ///     The keysdata 489
        /// </summary>
        public ImGuiKeyData KeysData489 { get; set; }

        /// <summary>
        ///     The keysdata 490
        /// </summary>
        public ImGuiKeyData KeysData490 { get; set; }

        /// <summary>
        ///     The keysdata 491
        /// </summary>
        public ImGuiKeyData KeysData491 { get; set; }

        /// <summary>
        ///     The keysdata 492
        /// </summary>
        public ImGuiKeyData KeysData492 { get; set; }

        /// <summary>
        ///     The keysdata 493
        /// </summary>
        public ImGuiKeyData KeysData493 { get; set; }

        /// <summary>
        ///     The keysdata 494
        /// </summary>
        public ImGuiKeyData KeysData494 { get; set; }

        /// <summary>
        ///     The keysdata 495
        /// </summary>
        public ImGuiKeyData KeysData495 { get; set; }

        /// <summary>
        ///     The keysdata 496
        /// </summary>
        public ImGuiKeyData KeysData496 { get; set; }

        /// <summary>
        ///     The keysdata 497
        /// </summary>
        public ImGuiKeyData KeysData497 { get; set; }

        /// <summary>
        ///     The keysdata 498
        /// </summary>
        public ImGuiKeyData KeysData498 { get; set; }

        /// <summary>
        ///     The keysdata 499
        /// </summary>
        public ImGuiKeyData KeysData499 { get; set; }

        /// <summary>
        ///     The keysdata 500
        /// </summary>
        public ImGuiKeyData KeysData500 { get; set; }

        /// <summary>
        ///     The keysdata 501
        /// </summary>
        public ImGuiKeyData KeysData501 { get; set; }

        /// <summary>
        ///     The keysdata 502
        /// </summary>
        public ImGuiKeyData KeysData502 { get; set; }

        /// <summary>
        ///     The keysdata 503
        /// </summary>
        public ImGuiKeyData KeysData503 { get; set; }

        /// <summary>
        ///     The keysdata 504
        /// </summary>
        public ImGuiKeyData KeysData504 { get; set; }

        /// <summary>
        ///     The keysdata 505
        /// </summary>
        public ImGuiKeyData KeysData505 { get; set; }

        /// <summary>
        ///     The keysdata 506
        /// </summary>
        public ImGuiKeyData KeysData506 { get; set; }

        /// <summary>
        ///     The keysdata 507
        /// </summary>
        public ImGuiKeyData KeysData507 { get; set; }

        /// <summary>
        ///     The keysdata 508
        /// </summary>
        public ImGuiKeyData KeysData508 { get; set; }

        /// <summary>
        ///     The keysdata 509
        /// </summary>
        public ImGuiKeyData KeysData509 { get; set; }

        /// <summary>
        ///     The keysdata 510
        /// </summary>
        public ImGuiKeyData KeysData510 { get; set; }

        /// <summary>
        ///     The keysdata 511
        /// </summary>
        public ImGuiKeyData KeysData511 { get; set; }

        /// <summary>
        ///     The keysdata 512
        /// </summary>
        public ImGuiKeyData KeysData512 { get; set; }

        /// <summary>
        ///     The keysdata 513
        /// </summary>
        public ImGuiKeyData KeysData513 { get; set; }

        /// <summary>
        ///     The keysdata 514
        /// </summary>
        public ImGuiKeyData KeysData514 { get; set; }

        /// <summary>
        ///     The keysdata 515
        /// </summary>
        public ImGuiKeyData KeysData515 { get; set; }

        /// <summary>
        ///     The keysdata 516
        /// </summary>
        public ImGuiKeyData KeysData516 { get; set; }

        /// <summary>
        ///     The keysdata 517
        /// </summary>
        public ImGuiKeyData KeysData517 { get; set; }

        /// <summary>
        ///     The keysdata 518
        /// </summary>
        public ImGuiKeyData KeysData518 { get; set; }

        /// <summary>
        ///     The keysdata 519
        /// </summary>
        public ImGuiKeyData KeysData519 { get; set; }

        /// <summary>
        ///     The keysdata 520
        /// </summary>
        public ImGuiKeyData KeysData520 { get; set; }

        /// <summary>
        ///     The keysdata 521
        /// </summary>
        public ImGuiKeyData KeysData521 { get; set; }

        /// <summary>
        ///     The keysdata 522
        /// </summary>
        public ImGuiKeyData KeysData522 { get; set; }

        /// <summary>
        ///     The keysdata 523
        /// </summary>
        public ImGuiKeyData KeysData523 { get; set; }

        /// <summary>
        ///     The keysdata 524
        /// </summary>
        public ImGuiKeyData KeysData524 { get; set; }

        /// <summary>
        ///     The keysdata 525
        /// </summary>
        public ImGuiKeyData KeysData525 { get; set; }

        /// <summary>
        ///     The keysdata 526
        /// </summary>
        public ImGuiKeyData KeysData526 { get; set; }

        /// <summary>
        ///     The keysdata 527
        /// </summary>
        public ImGuiKeyData KeysData527 { get; set; }

        /// <summary>
        ///     The keysdata 528
        /// </summary>
        public ImGuiKeyData KeysData528 { get; set; }

        /// <summary>
        ///     The keysdata 529
        /// </summary>
        public ImGuiKeyData KeysData529 { get; set; }

        /// <summary>
        ///     The keysdata 530
        /// </summary>
        public ImGuiKeyData KeysData530 { get; set; }

        /// <summary>
        ///     The keysdata 531
        /// </summary>
        public ImGuiKeyData KeysData531 { get; set; }

        /// <summary>
        ///     The keysdata 532
        /// </summary>
        public ImGuiKeyData KeysData532 { get; set; }

        /// <summary>
        ///     The keysdata 533
        /// </summary>
        public ImGuiKeyData KeysData533 { get; set; }

        /// <summary>
        ///     The keysdata 534
        /// </summary>
        public ImGuiKeyData KeysData534 { get; set; }

        /// <summary>
        ///     The keysdata 535
        /// </summary>
        public ImGuiKeyData KeysData535 { get; set; }

        /// <summary>
        ///     The keysdata 536
        /// </summary>
        public ImGuiKeyData KeysData536 { get; set; }

        /// <summary>
        ///     The keysdata 537
        /// </summary>
        public ImGuiKeyData KeysData537 { get; set; }

        /// <summary>
        ///     The keysdata 538
        /// </summary>
        public ImGuiKeyData KeysData538 { get; set; }

        /// <summary>
        ///     The keysdata 539
        /// </summary>
        public ImGuiKeyData KeysData539 { get; set; }

        /// <summary>
        ///     The keysdata 540
        /// </summary>
        public ImGuiKeyData KeysData540 { get; set; }

        /// <summary>
        ///     The keysdata 541
        /// </summary>
        public ImGuiKeyData KeysData541 { get; set; }

        /// <summary>
        ///     The keysdata 542
        /// </summary>
        public ImGuiKeyData KeysData542 { get; set; }

        /// <summary>
        ///     The keysdata 543
        /// </summary>
        public ImGuiKeyData KeysData543 { get; set; }

        /// <summary>
        ///     The keysdata 544
        /// </summary>
        public ImGuiKeyData KeysData544 { get; set; }

        /// <summary>
        ///     The keysdata 545
        /// </summary>
        public ImGuiKeyData KeysData545 { get; set; }

        /// <summary>
        ///     The keysdata 546
        /// </summary>
        public ImGuiKeyData KeysData546 { get; set; }

        /// <summary>
        ///     The keysdata 547
        /// </summary>
        public ImGuiKeyData KeysData547 { get; set; }

        /// <summary>
        ///     The keysdata 548
        /// </summary>
        public ImGuiKeyData KeysData548 { get; set; }

        /// <summary>
        ///     The keysdata 549
        /// </summary>
        public ImGuiKeyData KeysData549 { get; set; }

        /// <summary>
        ///     The keysdata 550
        /// </summary>
        public ImGuiKeyData KeysData550 { get; set; }

        /// <summary>
        ///     The keysdata 551
        /// </summary>
        public ImGuiKeyData KeysData551 { get; set; }

        /// <summary>
        ///     The keysdata 552
        /// </summary>
        public ImGuiKeyData KeysData552 { get; set; }

        /// <summary>
        ///     The keysdata 553
        /// </summary>
        public ImGuiKeyData KeysData553 { get; set; }

        /// <summary>
        ///     The keysdata 554
        /// </summary>
        public ImGuiKeyData KeysData554 { get; set; }

        /// <summary>
        ///     The keysdata 555
        /// </summary>
        public ImGuiKeyData KeysData555 { get; set; }

        /// <summary>
        ///     The keysdata 556
        /// </summary>
        public ImGuiKeyData KeysData556 { get; set; }

        /// <summary>
        ///     The keysdata 557
        /// </summary>
        public ImGuiKeyData KeysData557 { get; set; }

        /// <summary>
        ///     The keysdata 558
        /// </summary>
        public ImGuiKeyData KeysData558 { get; set; }

        /// <summary>
        ///     The keysdata 559
        /// </summary>
        public ImGuiKeyData KeysData559 { get; set; }

        /// <summary>
        ///     The keysdata 560
        /// </summary>
        public ImGuiKeyData KeysData560 { get; set; }

        /// <summary>
        ///     The keysdata 561
        /// </summary>
        public ImGuiKeyData KeysData561 { get; set; }

        /// <summary>
        ///     The keysdata 562
        /// </summary>
        public ImGuiKeyData KeysData562 { get; set; }

        /// <summary>
        ///     The keysdata 563
        /// </summary>
        public ImGuiKeyData KeysData563 { get; set; }

        /// <summary>
        ///     The keysdata 564
        /// </summary>
        public ImGuiKeyData KeysData564 { get; set; }

        /// <summary>
        ///     The keysdata 565
        /// </summary>
        public ImGuiKeyData KeysData565 { get; set; }

        /// <summary>
        ///     The keysdata 566
        /// </summary>
        public ImGuiKeyData KeysData566 { get; set; }

        /// <summary>
        ///     The keysdata 567
        /// </summary>
        public ImGuiKeyData KeysData567 { get; set; }

        /// <summary>
        ///     The keysdata 568
        /// </summary>
        public ImGuiKeyData KeysData568 { get; set; }

        /// <summary>
        ///     The keysdata 569
        /// </summary>
        public ImGuiKeyData KeysData569 { get; set; }

        /// <summary>
        ///     The keysdata 570
        /// </summary>
        public ImGuiKeyData KeysData570 { get; set; }

        /// <summary>
        ///     The keysdata 571
        /// </summary>
        public ImGuiKeyData KeysData571 { get; set; }

        /// <summary>
        ///     The keysdata 572
        /// </summary>
        public ImGuiKeyData KeysData572 { get; set; }

        /// <summary>
        ///     The keysdata 573
        /// </summary>
        public ImGuiKeyData KeysData573 { get; set; }

        /// <summary>
        ///     The keysdata 574
        /// </summary>
        public ImGuiKeyData KeysData574 { get; set; }

        /// <summary>
        ///     The keysdata 575
        /// </summary>
        public ImGuiKeyData KeysData575 { get; set; }

        /// <summary>
        ///     The keysdata 576
        /// </summary>
        public ImGuiKeyData KeysData576 { get; set; }

        /// <summary>
        ///     The keysdata 577
        /// </summary>
        public ImGuiKeyData KeysData577 { get; set; }

        /// <summary>
        ///     The keysdata 578
        /// </summary>
        public ImGuiKeyData KeysData578 { get; set; }

        /// <summary>
        ///     The keysdata 579
        /// </summary>
        public ImGuiKeyData KeysData579 { get; set; }

        /// <summary>
        ///     The keysdata 580
        /// </summary>
        public ImGuiKeyData KeysData580 { get; set; }

        /// <summary>
        ///     The keysdata 581
        /// </summary>
        public ImGuiKeyData KeysData581 { get; set; }

        /// <summary>
        ///     The keysdata 582
        /// </summary>
        public ImGuiKeyData KeysData582 { get; set; }

        /// <summary>
        ///     The keysdata 583
        /// </summary>
        public ImGuiKeyData KeysData583 { get; set; }

        /// <summary>
        ///     The keysdata 584
        /// </summary>
        public ImGuiKeyData KeysData584 { get; set; }

        /// <summary>
        ///     The keysdata 585
        /// </summary>
        public ImGuiKeyData KeysData585 { get; set; }

        /// <summary>
        ///     The keysdata 586
        /// </summary>
        public ImGuiKeyData KeysData586 { get; set; }

        /// <summary>
        ///     The keysdata 587
        /// </summary>
        public ImGuiKeyData KeysData587 { get; set; }

        /// <summary>
        ///     The keysdata 588
        /// </summary>
        public ImGuiKeyData KeysData588 { get; set; }

        /// <summary>
        ///     The keysdata 589
        /// </summary>
        public ImGuiKeyData KeysData589 { get; set; }

        /// <summary>
        ///     The keysdata 590
        /// </summary>
        public ImGuiKeyData KeysData590 { get; set; }

        /// <summary>
        ///     The keysdata 591
        /// </summary>
        public ImGuiKeyData KeysData591 { get; set; }

        /// <summary>
        ///     The keysdata 592
        /// </summary>
        public ImGuiKeyData KeysData592 { get; set; }

        /// <summary>
        ///     The keysdata 593
        /// </summary>
        public ImGuiKeyData KeysData593 { get; set; }

        /// <summary>
        ///     The keysdata 594
        /// </summary>
        public ImGuiKeyData KeysData594 { get; set; }

        /// <summary>
        ///     The keysdata 595
        /// </summary>
        public ImGuiKeyData KeysData595 { get; set; }

        /// <summary>
        ///     The keysdata 596
        /// </summary>
        public ImGuiKeyData KeysData596 { get; set; }

        /// <summary>
        ///     The keysdata 597
        /// </summary>
        public ImGuiKeyData KeysData597 { get; set; }

        /// <summary>
        ///     The keysdata 598
        /// </summary>
        public ImGuiKeyData KeysData598 { get; set; }

        /// <summary>
        ///     The keysdata 599
        /// </summary>
        public ImGuiKeyData KeysData599 { get; set; }

        /// <summary>
        ///     The keysdata 600
        /// </summary>
        public ImGuiKeyData KeysData600 { get; set; }

        /// <summary>
        ///     The keysdata 601
        /// </summary>
        public ImGuiKeyData KeysData601 { get; set; }

        /// <summary>
        ///     The keysdata 602
        /// </summary>
        public ImGuiKeyData KeysData602 { get; set; }

        /// <summary>
        ///     The keysdata 603
        /// </summary>
        public ImGuiKeyData KeysData603 { get; set; }

        /// <summary>
        ///     The keysdata 604
        /// </summary>
        public ImGuiKeyData KeysData604 { get; set; }

        /// <summary>
        ///     The keysdata 605
        /// </summary>
        public ImGuiKeyData KeysData605 { get; set; }

        /// <summary>
        ///     The keysdata 606
        /// </summary>
        public ImGuiKeyData KeysData606 { get; set; }

        /// <summary>
        ///     The keysdata 607
        /// </summary>
        public ImGuiKeyData KeysData607 { get; set; }

        /// <summary>
        ///     The keysdata 608
        /// </summary>
        public ImGuiKeyData KeysData608 { get; set; }

        /// <summary>
        ///     The keysdata 609
        /// </summary>
        public ImGuiKeyData KeysData609 { get; set; }

        /// <summary>
        ///     The keysdata 610
        /// </summary>
        public ImGuiKeyData KeysData610 { get; set; }

        /// <summary>
        ///     The keysdata 611
        /// </summary>
        public ImGuiKeyData KeysData611 { get; set; }

        /// <summary>
        ///     The keysdata 612
        /// </summary>
        public ImGuiKeyData KeysData612 { get; set; }

        /// <summary>
        ///     The keysdata 613
        /// </summary>
        public ImGuiKeyData KeysData613 { get; set; }

        /// <summary>
        ///     The keysdata 614
        /// </summary>
        public ImGuiKeyData KeysData614 { get; set; }

        /// <summary>
        ///     The keysdata 615
        /// </summary>
        public ImGuiKeyData KeysData615 { get; set; }

        /// <summary>
        ///     The keysdata 616
        /// </summary>
        public ImGuiKeyData KeysData616 { get; set; }

        /// <summary>
        ///     The keysdata 617
        /// </summary>
        public ImGuiKeyData KeysData617 { get; set; }

        /// <summary>
        ///     The keysdata 618
        /// </summary>
        public ImGuiKeyData KeysData618 { get; set; }

        /// <summary>
        ///     The keysdata 619
        /// </summary>
        public ImGuiKeyData KeysData619 { get; set; }

        /// <summary>
        ///     The keysdata 620
        /// </summary>
        public ImGuiKeyData KeysData620 { get; set; }

        /// <summary>
        ///     The keysdata 621
        /// </summary>
        public ImGuiKeyData KeysData621 { get; set; }

        /// <summary>
        ///     The keysdata 622
        /// </summary>
        public ImGuiKeyData KeysData622 { get; set; }

        /// <summary>
        ///     The keysdata 623
        /// </summary>
        public ImGuiKeyData KeysData623 { get; set; }

        /// <summary>
        ///     The keysdata 624
        /// </summary>
        public ImGuiKeyData KeysData624 { get; set; }

        /// <summary>
        ///     The keysdata 625
        /// </summary>
        public ImGuiKeyData KeysData625 { get; set; }

        /// <summary>
        ///     The keysdata 626
        /// </summary>
        public ImGuiKeyData KeysData626 { get; set; }

        /// <summary>
        ///     The keysdata 627
        /// </summary>
        public ImGuiKeyData KeysData627 { get; set; }

        /// <summary>
        ///     The keysdata 628
        /// </summary>
        public ImGuiKeyData KeysData628 { get; set; }

        /// <summary>
        ///     The keysdata 629
        /// </summary>
        public ImGuiKeyData KeysData629 { get; set; }

        /// <summary>
        ///     The keysdata 630
        /// </summary>
        public ImGuiKeyData KeysData630 { get; set; }

        /// <summary>
        ///     The keysdata 631
        /// </summary>
        public ImGuiKeyData KeysData631 { get; set; }

        /// <summary>
        ///     The keysdata 632
        /// </summary>
        public ImGuiKeyData KeysData632 { get; set; }

        /// <summary>
        ///     The keysdata 633
        /// </summary>
        public ImGuiKeyData KeysData633 { get; set; }

        /// <summary>
        ///     The keysdata 634
        /// </summary>
        public ImGuiKeyData KeysData634 { get; set; }

        /// <summary>
        ///     The keysdata 635
        /// </summary>
        public ImGuiKeyData KeysData635 { get; set; }

        /// <summary>
        ///     The keysdata 636
        /// </summary>
        public ImGuiKeyData KeysData636 { get; set; }

        /// <summary>
        ///     The keysdata 637
        /// </summary>
        public ImGuiKeyData KeysData637 { get; set; }

        /// <summary>
        ///     The keysdata 638
        /// </summary>
        public ImGuiKeyData KeysData638 { get; set; }

        /// <summary>
        ///     The keysdata 639
        /// </summary>
        public ImGuiKeyData KeysData639 { get; set; }

        /// <summary>
        ///     The keysdata 640
        /// </summary>
        public ImGuiKeyData KeysData640 { get; set; }

        /// <summary>
        ///     The keysdata 641
        /// </summary>
        public ImGuiKeyData KeysData641 { get; set; }

        /// <summary>
        ///     The keysdata 642
        /// </summary>
        public ImGuiKeyData KeysData642 { get; set; }

        /// <summary>
        ///     The keysdata 643
        /// </summary>
        public ImGuiKeyData KeysData643 { get; set; }

        /// <summary>
        ///     The keysdata 644
        /// </summary>
        public ImGuiKeyData KeysData644 { get; set; }

        /// <summary>
        ///     The keysdata 645
        /// </summary>
        public ImGuiKeyData KeysData645 { get; set; }

        /// <summary>
        ///     The keysdata 646
        /// </summary>
        public ImGuiKeyData KeysData646 { get; set; }

        /// <summary>
        ///     The keysdata 647
        /// </summary>
        public ImGuiKeyData KeysData647 { get; set; }

        /// <summary>
        ///     The keysdata 648
        /// </summary>
        public ImGuiKeyData KeysData648 { get; set; }

        /// <summary>
        ///     The keysdata 649
        /// </summary>
        public ImGuiKeyData KeysData649 { get; set; }

        /// <summary>
        ///     The keysdata 650
        /// </summary>
        public ImGuiKeyData KeysData650 { get; set; }

        /// <summary>
        ///     The keysdata 651
        /// </summary>
        public ImGuiKeyData KeysData651 { get; set; }

        /// <summary>
        ///     The want capture mouse unless popup close
        /// </summary>
        public byte WantCaptureMouseUnlessPopupClose { get; set; }

        /// <summary>
        ///     The mouse pos prev
        /// </summary>
        public Vector2F MousePosPrev { get; set; }

        /// <summary>
        ///     The mouseclickedpos
        /// </summary>
        public Vector2F MouseClickedPos0 { get; }

        /// <summary>
        ///     The mouseclickedpos
        /// </summary>
        public Vector2F MouseClickedPos1 { get; set; }

        /// <summary>
        ///     The mouseclickedpos
        /// </summary>
        public Vector2F MouseClickedPos2 { get; set; }

        /// <summary>
        ///     The mouseclickedpos
        /// </summary>
        public Vector2F MouseClickedPos3 { get; set; }

        /// <summary>
        ///     The mouseclickedpos
        /// </summary>
        public Vector2F MouseClickedPos4 { get; set; }

        /// <summary>
        ///     The mouse clicked time
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 5)]
        public double[] MouseClickedTime;

        /// <summary>
        ///     The mouse clicked
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 5)]
        public byte[] MouseClicked;

        /// <summary>
        ///     The mouse double clicked
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 5)]
        public byte[] MouseDoubleClicked;

        /// <summary>
        ///     The mouse clicked count
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 5)]
        public ushort[] MouseClickedCount;

        /// <summary>
        ///     The mouse clicked last count
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 5)]
        public ushort[] MouseClickedLastCount;

        /// <summary>
        ///     The mouse released
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 5)]
        public byte[] MouseReleased;

        /// <summary>
        ///     The mouse down owned
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 5)]
        public byte[] MouseDownOwned;

        /// <summary>
        ///     The mouse down owned unless popup close
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 5)]
        public byte[] MouseDownOwnedUnlessPopupClose;

        /// <summary>
        ///     The mouse down duration
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 5)]
        public float[] MouseDownDuration;

        /// <summary>
        ///     The mouse down duration prev
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 5)]
        public float[] MouseDownDurationPrev;

        /// <summary>
        ///     The mousedragmaxdistanceabs
        /// </summary>
        public Vector2F MouseDragMaxDistanceAbs0 { get; set; }

        /// <summary>
        ///     The mousedragmaxdistanceabs
        /// </summary>
        public Vector2F MouseDragMaxDistanceAbs1 { get; set; }

        /// <summary>
        ///     The mousedragmaxdistanceabs
        /// </summary>
        public Vector2F MouseDragMaxDistanceAbs2 { get; set; }

        /// <summary>
        ///     The mousedragmaxdistanceabs
        /// </summary>
        public Vector2F MouseDragMaxDistanceAbs3 { get; set; }

        /// <summary>
        ///     The mousedragmaxdistanceabs
        /// </summary>
        public Vector2F MouseDragMaxDistanceAbs4 { get; set; }

        /// <summary>
        ///     The mouse drag max distance sqr
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 5)]
        public float[] MouseDragMaxDistanceSqr;

        /// <summary>
        ///     The pen pressure
        /// </summary>
        public float PenPressure { get; set; }

        /// <summary>
        ///     The app focus lost
        /// </summary>
        public byte AppFocusLost { get; set; }

        /// <summary>
        ///     The app accepting events
        /// </summary>
        public byte AppAcceptingEvents { get; set; }

        /// <summary>
        ///     The backend using legacy key arrays
        /// </summary>
        public sbyte BackendUsingLegacyKeyArrays { get; set; }

        /// <summary>
        ///     The backend using legacy nav input array
        /// </summary>
        public byte BackendUsingLegacyNavInputArray { get; set; }

        /// <summary>
        ///     The input queue surrogate
        /// </summary>
        public ushort InputQueueSurrogate { get; set; }

        /// <summary>
        ///     The input queue characters
        /// </summary>
        public ImVectorG<ushort> InputQueueCharacters { get; set; }
    }
}