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
using Alis.Core.Aspect.Math.Vector;

namespace Alis.Extension.Graphic.ImGui
{
    /// <summary>
    ///     The im gui io
    /// </summary>
    public unsafe struct ImGuiIo
    {
        /// <summary>
        ///     The config flags
        /// </summary>
        public ImGuiConfigFlags ConfigFlags;

        /// <summary>
        ///     The backend flags
        /// </summary>
        public ImGuiBackendFlags BackendFlags;

        /// <summary>
        ///     The display size
        /// </summary>
        public Vector2 DisplaySize;

        /// <summary>
        ///     The delta time
        /// </summary>
        public float DeltaTime;

        /// <summary>
        ///     The ini saving rate
        /// </summary>
        public float IniSavingRate;

        /// <summary>
        ///     The ini filename
        /// </summary>
        public byte* IniFilename;

        /// <summary>
        ///     The log filename
        /// </summary>
        public byte* LogFilename;

        /// <summary>
        ///     The mouse double click time
        /// </summary>
        public float MouseDoubleClickTime;

        /// <summary>
        ///     The mouse double click max dist
        /// </summary>
        public float MouseDoubleClickMaxDist;

        /// <summary>
        ///     The mouse drag threshold
        /// </summary>
        public float MouseDragThreshold;

        /// <summary>
        ///     The key repeat delay
        /// </summary>
        public float KeyRepeatDelay;

        /// <summary>
        ///     The key repeat rate
        /// </summary>
        public float KeyRepeatRate;

        /// <summary>
        ///     The hover delay normal
        /// </summary>
        public float HoverDelayNormal;

        /// <summary>
        ///     The hover delay short
        /// </summary>
        public float HoverDelayShort;

        /// <summary>
        ///     The user data
        /// </summary>
        public void* UserData;

        /// <summary>
        ///     The fonts
        /// </summary>
        public ImFontAtlas* Fonts;

        /// <summary>
        ///     The font global scale
        /// </summary>
        public float FontGlobalScale;

        /// <summary>
        ///     The font allow user scaling
        /// </summary>
        public byte FontAllowUserScaling;

        /// <summary>
        ///     The font default
        /// </summary>
        public ImFont* FontDefault;

        /// <summary>
        ///     The display framebuffer scale
        /// </summary>
        public Vector2 DisplayFramebufferScale;

        /// <summary>
        ///     The config docking no split
        /// </summary>
        public byte ConfigDockingNoSplit;

        /// <summary>
        ///     The config docking with shift
        /// </summary>
        public byte ConfigDockingWithShift;

        /// <summary>
        ///     The config docking always tab bar
        /// </summary>
        public byte ConfigDockingAlwaysTabBar;

        /// <summary>
        ///     The config docking transparent payload
        /// </summary>
        public byte ConfigDockingTransparentPayload;

        /// <summary>
        ///     The config viewports no auto merge
        /// </summary>
        public byte ConfigViewportsNoAutoMerge;

        /// <summary>
        ///     The config viewports no task bar icon
        /// </summary>
        public byte ConfigViewportsNoTaskBarIcon;

        /// <summary>
        ///     The config viewports no decoration
        /// </summary>
        public byte ConfigViewportsNoDecoration;

        /// <summary>
        ///     The config viewports no default parent
        /// </summary>
        public byte ConfigViewportsNoDefaultParent;

        /// <summary>
        ///     The mouse draw cursor
        /// </summary>
        public byte MouseDrawCursor;

        /// <summary>
        ///     The config mac osx behaviors
        /// </summary>
        public byte ConfigMacOsxBehaviors;

        /// <summary>
        ///     The config input trickle event queue
        /// </summary>
        public byte ConfigInputTrickleEventQueue;

        /// <summary>
        ///     The config input text cursor blink
        /// </summary>
        public byte ConfigInputTextCursorBlink;

        /// <summary>
        ///     The config input text enter keep active
        /// </summary>
        public byte ConfigInputTextEnterKeepActive;

        /// <summary>
        ///     The config drag click to input text
        /// </summary>
        public byte ConfigDragClickToInputText;

        /// <summary>
        ///     The config windows resize from edges
        /// </summary>
        public byte ConfigWindowsResizeFromEdges;

        /// <summary>
        ///     The config windows move from title bar only
        /// </summary>
        public byte ConfigWindowsMoveFromTitleBarOnly;

        /// <summary>
        ///     The config memory compact timer
        /// </summary>
        public float ConfigMemoryCompactTimer;

        /// <summary>
        ///     The backend platform name
        /// </summary>
        public byte* BackendPlatformName;

        /// <summary>
        ///     The backend renderer name
        /// </summary>
        public byte* BackendRendererName;

        /// <summary>
        ///     The backend platform user data
        /// </summary>
        public void* BackendPlatformUserData;

        /// <summary>
        ///     The backend renderer user data
        /// </summary>
        public void* BackendRendererUserData;

        /// <summary>
        ///     The backend language user data
        /// </summary>
        public void* BackendLanguageUserData;

        /// <summary>
        ///     The get clipboard text fn
        /// </summary>
        public IntPtr GetClipboardTextFn;

        /// <summary>
        ///     The set clipboard text fn
        /// </summary>
        public IntPtr SetClipboardTextFn;

        /// <summary>
        ///     The clipboard user data
        /// </summary>
        public void* ClipboardUserData;

        /// <summary>
        ///     The set platform ime data fn
        /// </summary>
        public IntPtr SetPlatformImeDataFn;

        /// <summary>
        ///     The unused padding
        /// </summary>
        public void* UnusedPadding;

        /// <summary>
        ///     The want capture mouse
        /// </summary>
        public byte WantCaptureMouse;

        /// <summary>
        ///     The want capture keyboard
        /// </summary>
        public byte WantCaptureKeyboard;

        /// <summary>
        ///     The want text input
        /// </summary>
        public byte WantTextInput;

        /// <summary>
        ///     The want set mouse pos
        /// </summary>
        public byte WantSetMousePos;

        /// <summary>
        ///     The want save ini settings
        /// </summary>
        public byte WantSaveIniSettings;

        /// <summary>
        ///     The nav active
        /// </summary>
        public byte NavActive;

        /// <summary>
        ///     The nav visible
        /// </summary>
        public byte NavVisible;

        /// <summary>
        ///     The framerate
        /// </summary>
        public float Framerate;

        /// <summary>
        ///     The metrics render vertices
        /// </summary>
        public int MetricsRenderVertices;

        /// <summary>
        ///     The metrics render indices
        /// </summary>
        public int MetricsRenderIndices;

        /// <summary>
        ///     The metrics render windows
        /// </summary>
        public int MetricsRenderWindows;

        /// <summary>
        ///     The metrics active windows
        /// </summary>
        public int MetricsActiveWindows;

        /// <summary>
        ///     The metrics active allocations
        /// </summary>
        public int MetricsActiveAllocations;

        /// <summary>
        ///     The mouse delta
        /// </summary>
        public Vector2 MouseDelta;

        /// <summary>
        ///     The key map
        /// </summary>
        public fixed int KeyMap[652];

        /// <summary>
        ///     The keys down
        /// </summary>
        public fixed byte KeysDown[652];

        /// <summary>
        ///     The nav inputs
        /// </summary>
        public fixed float NavInputs[16];

        /// <summary>
        ///     The mouse pos
        /// </summary>
        public Vector2 MousePos;

        /// <summary>
        ///     The mouse down
        /// </summary>
        public fixed byte MouseDown[5];

        /// <summary>
        ///     The mouse wheel
        /// </summary>
        public float MouseWheel;

        /// <summary>
        ///     The mouse wheel
        /// </summary>
        public float MouseWheelH;

        /// <summary>
        ///     The mouse hovered viewport
        /// </summary>
        public uint MouseHoveredViewport;

        /// <summary>
        ///     The key ctrl
        /// </summary>
        public byte KeyCtrl;

        /// <summary>
        ///     The key shift
        /// </summary>
        public byte KeyShift;

        /// <summary>
        ///     The key alt
        /// </summary>
        public byte KeyAlt;

        /// <summary>
        ///     The key super
        /// </summary>
        public byte KeySuper;

        /// <summary>
        ///     The key mods
        /// </summary>
        public ImGuiKey KeyMods;

        /// <summary>
        ///     The keysdata
        /// </summary>
        public ImGuiKeyData KeysData0;

        /// <summary>
        ///     The keysdata
        /// </summary>
        public ImGuiKeyData KeysData1;

        /// <summary>
        ///     The keysdata
        /// </summary>
        public ImGuiKeyData KeysData2;

        /// <summary>
        ///     The keysdata
        /// </summary>
        public ImGuiKeyData KeysData3;

        /// <summary>
        ///     The keysdata
        /// </summary>
        public ImGuiKeyData KeysData4;

        /// <summary>
        ///     The keysdata
        /// </summary>
        public ImGuiKeyData KeysData5;

        /// <summary>
        ///     The keysdata
        /// </summary>
        public ImGuiKeyData KeysData6;

        /// <summary>
        ///     The keysdata
        /// </summary>
        public ImGuiKeyData KeysData7;

        /// <summary>
        ///     The keysdata
        /// </summary>
        public ImGuiKeyData KeysData8;

        /// <summary>
        ///     The keysdata
        /// </summary>
        public ImGuiKeyData KeysData9;

        /// <summary>
        ///     The keysdata 10
        /// </summary>
        public ImGuiKeyData KeysData10;

        /// <summary>
        ///     The keysdata 11
        /// </summary>
        public ImGuiKeyData KeysData11;

        /// <summary>
        ///     The keysdata 12
        /// </summary>
        public ImGuiKeyData KeysData12;

        /// <summary>
        ///     The keysdata 13
        /// </summary>
        public ImGuiKeyData KeysData13;

        /// <summary>
        ///     The keysdata 14
        /// </summary>
        public ImGuiKeyData KeysData14;

        /// <summary>
        ///     The keysdata 15
        /// </summary>
        public ImGuiKeyData KeysData15;

        /// <summary>
        ///     The keysdata 16
        /// </summary>
        public ImGuiKeyData KeysData16;

        /// <summary>
        ///     The keysdata 17
        /// </summary>
        public ImGuiKeyData KeysData17;

        /// <summary>
        ///     The keysdata 18
        /// </summary>
        public ImGuiKeyData KeysData18;

        /// <summary>
        ///     The keysdata 19
        /// </summary>
        public ImGuiKeyData KeysData19;

        /// <summary>
        ///     The keysdata 20
        /// </summary>
        public ImGuiKeyData KeysData20;

        /// <summary>
        ///     The keysdata 21
        /// </summary>
        public ImGuiKeyData KeysData21;

        /// <summary>
        ///     The keysdata 22
        /// </summary>
        public ImGuiKeyData KeysData22;

        /// <summary>
        ///     The keysdata 23
        /// </summary>
        public ImGuiKeyData KeysData23;

        /// <summary>
        ///     The keysdata 24
        /// </summary>
        public ImGuiKeyData KeysData24;

        /// <summary>
        ///     The keysdata 25
        /// </summary>
        public ImGuiKeyData KeysData25;

        /// <summary>
        ///     The keysdata 26
        /// </summary>
        public ImGuiKeyData KeysData26;

        /// <summary>
        ///     The keysdata 27
        /// </summary>
        public ImGuiKeyData KeysData27;

        /// <summary>
        ///     The keysdata 28
        /// </summary>
        public ImGuiKeyData KeysData28;

        /// <summary>
        ///     The keysdata 29
        /// </summary>
        public ImGuiKeyData KeysData29;

        /// <summary>
        ///     The keysdata 30
        /// </summary>
        public ImGuiKeyData KeysData30;

        /// <summary>
        ///     The keysdata 31
        /// </summary>
        public ImGuiKeyData KeysData31;

        /// <summary>
        ///     The keysdata 32
        /// </summary>
        public ImGuiKeyData KeysData32;

        /// <summary>
        ///     The keysdata 33
        /// </summary>
        public ImGuiKeyData KeysData33;

        /// <summary>
        ///     The keysdata 34
        /// </summary>
        public ImGuiKeyData KeysData34;

        /// <summary>
        ///     The keysdata 35
        /// </summary>
        public ImGuiKeyData KeysData35;

        /// <summary>
        ///     The keysdata 36
        /// </summary>
        public ImGuiKeyData KeysData36;

        /// <summary>
        ///     The keysdata 37
        /// </summary>
        public ImGuiKeyData KeysData37;

        /// <summary>
        ///     The keysdata 38
        /// </summary>
        public ImGuiKeyData KeysData38;

        /// <summary>
        ///     The keysdata 39
        /// </summary>
        public ImGuiKeyData KeysData39;

        /// <summary>
        ///     The keysdata 40
        /// </summary>
        public ImGuiKeyData KeysData40;

        /// <summary>
        ///     The keysdata 41
        /// </summary>
        public ImGuiKeyData KeysData41;

        /// <summary>
        ///     The keysdata 42
        /// </summary>
        public ImGuiKeyData KeysData42;

        /// <summary>
        ///     The keysdata 43
        /// </summary>
        public ImGuiKeyData KeysData43;

        /// <summary>
        ///     The keysdata 44
        /// </summary>
        public ImGuiKeyData KeysData44;

        /// <summary>
        ///     The keysdata 45
        /// </summary>
        public ImGuiKeyData KeysData45;

        /// <summary>
        ///     The keysdata 46
        /// </summary>
        public ImGuiKeyData KeysData46;

        /// <summary>
        ///     The keysdata 47
        /// </summary>
        public ImGuiKeyData KeysData47;

        /// <summary>
        ///     The keysdata 48
        /// </summary>
        public ImGuiKeyData KeysData48;

        /// <summary>
        ///     The keysdata 49
        /// </summary>
        public ImGuiKeyData KeysData49;

        /// <summary>
        ///     The keysdata 50
        /// </summary>
        public ImGuiKeyData KeysData50;

        /// <summary>
        ///     The keysdata 51
        /// </summary>
        public ImGuiKeyData KeysData51;

        /// <summary>
        ///     The keysdata 52
        /// </summary>
        public ImGuiKeyData KeysData52;

        /// <summary>
        ///     The keysdata 53
        /// </summary>
        public ImGuiKeyData KeysData53;

        /// <summary>
        ///     The keysdata 54
        /// </summary>
        public ImGuiKeyData KeysData54;

        /// <summary>
        ///     The keysdata 55
        /// </summary>
        public ImGuiKeyData KeysData55;

        /// <summary>
        ///     The keysdata 56
        /// </summary>
        public ImGuiKeyData KeysData56;

        /// <summary>
        ///     The keysdata 57
        /// </summary>
        public ImGuiKeyData KeysData57;

        /// <summary>
        ///     The keysdata 58
        /// </summary>
        public ImGuiKeyData KeysData58;

        /// <summary>
        ///     The keysdata 59
        /// </summary>
        public ImGuiKeyData KeysData59;

        /// <summary>
        ///     The keysdata 60
        /// </summary>
        public ImGuiKeyData KeysData60;

        /// <summary>
        ///     The keysdata 61
        /// </summary>
        public ImGuiKeyData KeysData61;

        /// <summary>
        ///     The keysdata 62
        /// </summary>
        public ImGuiKeyData KeysData62;

        /// <summary>
        ///     The keysdata 63
        /// </summary>
        public ImGuiKeyData KeysData63;

        /// <summary>
        ///     The keysdata 64
        /// </summary>
        public ImGuiKeyData KeysData64;

        /// <summary>
        ///     The keysdata 65
        /// </summary>
        public ImGuiKeyData KeysData65;

        /// <summary>
        ///     The keysdata 66
        /// </summary>
        public ImGuiKeyData KeysData66;

        /// <summary>
        ///     The keysdata 67
        /// </summary>
        public ImGuiKeyData KeysData67;

        /// <summary>
        ///     The keysdata 68
        /// </summary>
        public ImGuiKeyData KeysData68;

        /// <summary>
        ///     The keysdata 69
        /// </summary>
        public ImGuiKeyData KeysData69;

        /// <summary>
        ///     The keysdata 70
        /// </summary>
        public ImGuiKeyData KeysData70;

        /// <summary>
        ///     The keysdata 71
        /// </summary>
        public ImGuiKeyData KeysData71;

        /// <summary>
        ///     The keysdata 72
        /// </summary>
        public ImGuiKeyData KeysData72;

        /// <summary>
        ///     The keysdata 73
        /// </summary>
        public ImGuiKeyData KeysData73;

        /// <summary>
        ///     The keysdata 74
        /// </summary>
        public ImGuiKeyData KeysData74;

        /// <summary>
        ///     The keysdata 75
        /// </summary>
        public ImGuiKeyData KeysData75;

        /// <summary>
        ///     The keysdata 76
        /// </summary>
        public ImGuiKeyData KeysData76;

        /// <summary>
        ///     The keysdata 77
        /// </summary>
        public ImGuiKeyData KeysData77;

        /// <summary>
        ///     The keysdata 78
        /// </summary>
        public ImGuiKeyData KeysData78;

        /// <summary>
        ///     The keysdata 79
        /// </summary>
        public ImGuiKeyData KeysData79;

        /// <summary>
        ///     The keysdata 80
        /// </summary>
        public ImGuiKeyData KeysData80;

        /// <summary>
        ///     The keysdata 81
        /// </summary>
        public ImGuiKeyData KeysData81;

        /// <summary>
        ///     The keysdata 82
        /// </summary>
        public ImGuiKeyData KeysData82;

        /// <summary>
        ///     The keysdata 83
        /// </summary>
        public ImGuiKeyData KeysData83;

        /// <summary>
        ///     The keysdata 84
        /// </summary>
        public ImGuiKeyData KeysData84;

        /// <summary>
        ///     The keysdata 85
        /// </summary>
        public ImGuiKeyData KeysData85;

        /// <summary>
        ///     The keysdata 86
        /// </summary>
        public ImGuiKeyData KeysData86;

        /// <summary>
        ///     The keysdata 87
        /// </summary>
        public ImGuiKeyData KeysData87;

        /// <summary>
        ///     The keysdata 88
        /// </summary>
        public ImGuiKeyData KeysData88;

        /// <summary>
        ///     The keysdata 89
        /// </summary>
        public ImGuiKeyData KeysData89;

        /// <summary>
        ///     The keysdata 90
        /// </summary>
        public ImGuiKeyData KeysData90;

        /// <summary>
        ///     The keysdata 91
        /// </summary>
        public ImGuiKeyData KeysData91;

        /// <summary>
        ///     The keysdata 92
        /// </summary>
        public ImGuiKeyData KeysData92;

        /// <summary>
        ///     The keysdata 93
        /// </summary>
        public ImGuiKeyData KeysData93;

        /// <summary>
        ///     The keysdata 94
        /// </summary>
        public ImGuiKeyData KeysData94;

        /// <summary>
        ///     The keysdata 95
        /// </summary>
        public ImGuiKeyData KeysData95;

        /// <summary>
        ///     The keysdata 96
        /// </summary>
        public ImGuiKeyData KeysData96;

        /// <summary>
        ///     The keysdata 97
        /// </summary>
        public ImGuiKeyData KeysData97;

        /// <summary>
        ///     The keysdata 98
        /// </summary>
        public ImGuiKeyData KeysData98;

        /// <summary>
        ///     The keysdata 99
        /// </summary>
        public ImGuiKeyData KeysData99;

        /// <summary>
        ///     The keysdata 100
        /// </summary>
        public ImGuiKeyData KeysData100;

        /// <summary>
        ///     The keysdata 101
        /// </summary>
        public ImGuiKeyData KeysData101;

        /// <summary>
        ///     The keysdata 102
        /// </summary>
        public ImGuiKeyData KeysData102;

        /// <summary>
        ///     The keysdata 103
        /// </summary>
        public ImGuiKeyData KeysData103;

        /// <summary>
        ///     The keysdata 104
        /// </summary>
        public ImGuiKeyData KeysData104;

        /// <summary>
        ///     The keysdata 105
        /// </summary>
        public ImGuiKeyData KeysData105;

        /// <summary>
        ///     The keysdata 106
        /// </summary>
        public ImGuiKeyData KeysData106;

        /// <summary>
        ///     The keysdata 107
        /// </summary>
        public ImGuiKeyData KeysData107;

        /// <summary>
        ///     The keysdata 108
        /// </summary>
        public ImGuiKeyData KeysData108;

        /// <summary>
        ///     The keysdata 109
        /// </summary>
        public ImGuiKeyData KeysData109;

        /// <summary>
        ///     The keysdata 110
        /// </summary>
        public ImGuiKeyData KeysData110;

        /// <summary>
        ///     The keysdata 111
        /// </summary>
        public ImGuiKeyData KeysData111;

        /// <summary>
        ///     The keysdata 112
        /// </summary>
        public ImGuiKeyData KeysData112;

        /// <summary>
        ///     The keysdata 113
        /// </summary>
        public ImGuiKeyData KeysData113;

        /// <summary>
        ///     The keysdata 114
        /// </summary>
        public ImGuiKeyData KeysData114;

        /// <summary>
        ///     The keysdata 115
        /// </summary>
        public ImGuiKeyData KeysData115;

        /// <summary>
        ///     The keysdata 116
        /// </summary>
        public ImGuiKeyData KeysData116;

        /// <summary>
        ///     The keysdata 117
        /// </summary>
        public ImGuiKeyData KeysData117;

        /// <summary>
        ///     The keysdata 118
        /// </summary>
        public ImGuiKeyData KeysData118;

        /// <summary>
        ///     The keysdata 119
        /// </summary>
        public ImGuiKeyData KeysData119;

        /// <summary>
        ///     The keysdata 120
        /// </summary>
        public ImGuiKeyData KeysData120;

        /// <summary>
        ///     The keysdata 121
        /// </summary>
        public ImGuiKeyData KeysData121;

        /// <summary>
        ///     The keysdata 122
        /// </summary>
        public ImGuiKeyData KeysData122;

        /// <summary>
        ///     The keysdata 123
        /// </summary>
        public ImGuiKeyData KeysData123;

        /// <summary>
        ///     The keysdata 124
        /// </summary>
        public ImGuiKeyData KeysData124;

        /// <summary>
        ///     The keysdata 125
        /// </summary>
        public ImGuiKeyData KeysData125;

        /// <summary>
        ///     The keysdata 126
        /// </summary>
        public ImGuiKeyData KeysData126;

        /// <summary>
        ///     The keysdata 127
        /// </summary>
        public ImGuiKeyData KeysData127;

        /// <summary>
        ///     The keysdata 128
        /// </summary>
        public ImGuiKeyData KeysData128;

        /// <summary>
        ///     The keysdata 129
        /// </summary>
        public ImGuiKeyData KeysData129;

        /// <summary>
        ///     The keysdata 130
        /// </summary>
        public ImGuiKeyData KeysData130;

        /// <summary>
        ///     The keysdata 131
        /// </summary>
        public ImGuiKeyData KeysData131;

        /// <summary>
        ///     The keysdata 132
        /// </summary>
        public ImGuiKeyData KeysData132;

        /// <summary>
        ///     The keysdata 133
        /// </summary>
        public ImGuiKeyData KeysData133;

        /// <summary>
        ///     The keysdata 134
        /// </summary>
        public ImGuiKeyData KeysData134;

        /// <summary>
        ///     The keysdata 135
        /// </summary>
        public ImGuiKeyData KeysData135;

        /// <summary>
        ///     The keysdata 136
        /// </summary>
        public ImGuiKeyData KeysData136;

        /// <summary>
        ///     The keysdata 137
        /// </summary>
        public ImGuiKeyData KeysData137;

        /// <summary>
        ///     The keysdata 138
        /// </summary>
        public ImGuiKeyData KeysData138;

        /// <summary>
        ///     The keysdata 139
        /// </summary>
        public ImGuiKeyData KeysData139;

        /// <summary>
        ///     The keysdata 140
        /// </summary>
        public ImGuiKeyData KeysData140;

        /// <summary>
        ///     The keysdata 141
        /// </summary>
        public ImGuiKeyData KeysData141;

        /// <summary>
        ///     The keysdata 142
        /// </summary>
        public ImGuiKeyData KeysData142;

        /// <summary>
        ///     The keysdata 143
        /// </summary>
        public ImGuiKeyData KeysData143;

        /// <summary>
        ///     The keysdata 144
        /// </summary>
        public ImGuiKeyData KeysData144;

        /// <summary>
        ///     The keysdata 145
        /// </summary>
        public ImGuiKeyData KeysData145;

        /// <summary>
        ///     The keysdata 146
        /// </summary>
        public ImGuiKeyData KeysData146;

        /// <summary>
        ///     The keysdata 147
        /// </summary>
        public ImGuiKeyData KeysData147;

        /// <summary>
        ///     The keysdata 148
        /// </summary>
        public ImGuiKeyData KeysData148;

        /// <summary>
        ///     The keysdata 149
        /// </summary>
        public ImGuiKeyData KeysData149;

        /// <summary>
        ///     The keysdata 150
        /// </summary>
        public ImGuiKeyData KeysData150;

        /// <summary>
        ///     The keysdata 151
        /// </summary>
        public ImGuiKeyData KeysData151;

        /// <summary>
        ///     The keysdata 152
        /// </summary>
        public ImGuiKeyData KeysData152;

        /// <summary>
        ///     The keysdata 153
        /// </summary>
        public ImGuiKeyData KeysData153;

        /// <summary>
        ///     The keysdata 154
        /// </summary>
        public ImGuiKeyData KeysData154;

        /// <summary>
        ///     The keysdata 155
        /// </summary>
        public ImGuiKeyData KeysData155;

        /// <summary>
        ///     The keysdata 156
        /// </summary>
        public ImGuiKeyData KeysData156;

        /// <summary>
        ///     The keysdata 157
        /// </summary>
        public ImGuiKeyData KeysData157;

        /// <summary>
        ///     The keysdata 158
        /// </summary>
        public ImGuiKeyData KeysData158;

        /// <summary>
        ///     The keysdata 159
        /// </summary>
        public ImGuiKeyData KeysData159;

        /// <summary>
        ///     The keysdata 160
        /// </summary>
        public ImGuiKeyData KeysData160;

        /// <summary>
        ///     The keysdata 161
        /// </summary>
        public ImGuiKeyData KeysData161;

        /// <summary>
        ///     The keysdata 162
        /// </summary>
        public ImGuiKeyData KeysData162;

        /// <summary>
        ///     The keysdata 163
        /// </summary>
        public ImGuiKeyData KeysData163;

        /// <summary>
        ///     The keysdata 164
        /// </summary>
        public ImGuiKeyData KeysData164;

        /// <summary>
        ///     The keysdata 165
        /// </summary>
        public ImGuiKeyData KeysData165;

        /// <summary>
        ///     The keysdata 166
        /// </summary>
        public ImGuiKeyData KeysData166;

        /// <summary>
        ///     The keysdata 167
        /// </summary>
        public ImGuiKeyData KeysData167;

        /// <summary>
        ///     The keysdata 168
        /// </summary>
        public ImGuiKeyData KeysData168;

        /// <summary>
        ///     The keysdata 169
        /// </summary>
        public ImGuiKeyData KeysData169;

        /// <summary>
        ///     The keysdata 170
        /// </summary>
        public ImGuiKeyData KeysData170;

        /// <summary>
        ///     The keysdata 171
        /// </summary>
        public ImGuiKeyData KeysData171;

        /// <summary>
        ///     The keysdata 172
        /// </summary>
        public ImGuiKeyData KeysData172;

        /// <summary>
        ///     The keysdata 173
        /// </summary>
        public ImGuiKeyData KeysData173;

        /// <summary>
        ///     The keysdata 174
        /// </summary>
        public ImGuiKeyData KeysData174;

        /// <summary>
        ///     The keysdata 175
        /// </summary>
        public ImGuiKeyData KeysData175;

        /// <summary>
        ///     The keysdata 176
        /// </summary>
        public ImGuiKeyData KeysData176;

        /// <summary>
        ///     The keysdata 177
        /// </summary>
        public ImGuiKeyData KeysData177;

        /// <summary>
        ///     The keysdata 178
        /// </summary>
        public ImGuiKeyData KeysData178;

        /// <summary>
        ///     The keysdata 179
        /// </summary>
        public ImGuiKeyData KeysData179;

        /// <summary>
        ///     The keysdata 180
        /// </summary>
        public ImGuiKeyData KeysData180;

        /// <summary>
        ///     The keysdata 181
        /// </summary>
        public ImGuiKeyData KeysData181;

        /// <summary>
        ///     The keysdata 182
        /// </summary>
        public ImGuiKeyData KeysData182;

        /// <summary>
        ///     The keysdata 183
        /// </summary>
        public ImGuiKeyData KeysData183;

        /// <summary>
        ///     The keysdata 184
        /// </summary>
        public ImGuiKeyData KeysData184;

        /// <summary>
        ///     The keysdata 185
        /// </summary>
        public ImGuiKeyData KeysData185;

        /// <summary>
        ///     The keysdata 186
        /// </summary>
        public ImGuiKeyData KeysData186;

        /// <summary>
        ///     The keysdata 187
        /// </summary>
        public ImGuiKeyData KeysData187;

        /// <summary>
        ///     The keysdata 188
        /// </summary>
        public ImGuiKeyData KeysData188;

        /// <summary>
        ///     The keysdata 189
        /// </summary>
        public ImGuiKeyData KeysData189;

        /// <summary>
        ///     The keysdata 190
        /// </summary>
        public ImGuiKeyData KeysData190;

        /// <summary>
        ///     The keysdata 191
        /// </summary>
        public ImGuiKeyData KeysData191;

        /// <summary>
        ///     The keysdata 192
        /// </summary>
        public ImGuiKeyData KeysData192;

        /// <summary>
        ///     The keysdata 193
        /// </summary>
        public ImGuiKeyData KeysData193;

        /// <summary>
        ///     The keysdata 194
        /// </summary>
        public ImGuiKeyData KeysData194;

        /// <summary>
        ///     The keysdata 195
        /// </summary>
        public ImGuiKeyData KeysData195;

        /// <summary>
        ///     The keysdata 196
        /// </summary>
        public ImGuiKeyData KeysData196;

        /// <summary>
        ///     The keysdata 197
        /// </summary>
        public ImGuiKeyData KeysData197;

        /// <summary>
        ///     The keysdata 198
        /// </summary>
        public ImGuiKeyData KeysData198;

        /// <summary>
        ///     The keysdata 199
        /// </summary>
        public ImGuiKeyData KeysData199;

        /// <summary>
        ///     The keysdata 200
        /// </summary>
        public ImGuiKeyData KeysData200;

        /// <summary>
        ///     The keysdata 201
        /// </summary>
        public ImGuiKeyData KeysData201;

        /// <summary>
        ///     The keysdata 202
        /// </summary>
        public ImGuiKeyData KeysData202;

        /// <summary>
        ///     The keysdata 203
        /// </summary>
        public ImGuiKeyData KeysData203;

        /// <summary>
        ///     The keysdata 204
        /// </summary>
        public ImGuiKeyData KeysData204;

        /// <summary>
        ///     The keysdata 205
        /// </summary>
        public ImGuiKeyData KeysData205;

        /// <summary>
        ///     The keysdata 206
        /// </summary>
        public ImGuiKeyData KeysData206;

        /// <summary>
        ///     The keysdata 207
        /// </summary>
        public ImGuiKeyData KeysData207;

        /// <summary>
        ///     The keysdata 208
        /// </summary>
        public ImGuiKeyData KeysData208;

        /// <summary>
        ///     The keysdata 209
        /// </summary>
        public ImGuiKeyData KeysData209;

        /// <summary>
        ///     The keysdata 210
        /// </summary>
        public ImGuiKeyData KeysData210;

        /// <summary>
        ///     The keysdata 211
        /// </summary>
        public ImGuiKeyData KeysData211;

        /// <summary>
        ///     The keysdata 212
        /// </summary>
        public ImGuiKeyData KeysData212;

        /// <summary>
        ///     The keysdata 213
        /// </summary>
        public ImGuiKeyData KeysData213;

        /// <summary>
        ///     The keysdata 214
        /// </summary>
        public ImGuiKeyData KeysData214;

        /// <summary>
        ///     The keysdata 215
        /// </summary>
        public ImGuiKeyData KeysData215;

        /// <summary>
        ///     The keysdata 216
        /// </summary>
        public ImGuiKeyData KeysData216;

        /// <summary>
        ///     The keysdata 217
        /// </summary>
        public ImGuiKeyData KeysData217;

        /// <summary>
        ///     The keysdata 218
        /// </summary>
        public ImGuiKeyData KeysData218;

        /// <summary>
        ///     The keysdata 219
        /// </summary>
        public ImGuiKeyData KeysData219;

        /// <summary>
        ///     The keysdata 220
        /// </summary>
        public ImGuiKeyData KeysData220;

        /// <summary>
        ///     The keysdata 221
        /// </summary>
        public ImGuiKeyData KeysData221;

        /// <summary>
        ///     The keysdata 222
        /// </summary>
        public ImGuiKeyData KeysData222;

        /// <summary>
        ///     The keysdata 223
        /// </summary>
        public ImGuiKeyData KeysData223;

        /// <summary>
        ///     The keysdata 224
        /// </summary>
        public ImGuiKeyData KeysData224;

        /// <summary>
        ///     The keysdata 225
        /// </summary>
        public ImGuiKeyData KeysData225;

        /// <summary>
        ///     The keysdata 226
        /// </summary>
        public ImGuiKeyData KeysData226;

        /// <summary>
        ///     The keysdata 227
        /// </summary>
        public ImGuiKeyData KeysData227;

        /// <summary>
        ///     The keysdata 228
        /// </summary>
        public ImGuiKeyData KeysData228;

        /// <summary>
        ///     The keysdata 229
        /// </summary>
        public ImGuiKeyData KeysData229;

        /// <summary>
        ///     The keysdata 230
        /// </summary>
        public ImGuiKeyData KeysData230;

        /// <summary>
        ///     The keysdata 231
        /// </summary>
        public ImGuiKeyData KeysData231;

        /// <summary>
        ///     The keysdata 232
        /// </summary>
        public ImGuiKeyData KeysData232;

        /// <summary>
        ///     The keysdata 233
        /// </summary>
        public ImGuiKeyData KeysData233;

        /// <summary>
        ///     The keysdata 234
        /// </summary>
        public ImGuiKeyData KeysData234;

        /// <summary>
        ///     The keysdata 235
        /// </summary>
        public ImGuiKeyData KeysData235;

        /// <summary>
        ///     The keysdata 236
        /// </summary>
        public ImGuiKeyData KeysData236;

        /// <summary>
        ///     The keysdata 237
        /// </summary>
        public ImGuiKeyData KeysData237;

        /// <summary>
        ///     The keysdata 238
        /// </summary>
        public ImGuiKeyData KeysData238;

        /// <summary>
        ///     The keysdata 239
        /// </summary>
        public ImGuiKeyData KeysData239;

        /// <summary>
        ///     The keysdata 240
        /// </summary>
        public ImGuiKeyData KeysData240;

        /// <summary>
        ///     The keysdata 241
        /// </summary>
        public ImGuiKeyData KeysData241;

        /// <summary>
        ///     The keysdata 242
        /// </summary>
        public ImGuiKeyData KeysData242;

        /// <summary>
        ///     The keysdata 243
        /// </summary>
        public ImGuiKeyData KeysData243;

        /// <summary>
        ///     The keysdata 244
        /// </summary>
        public ImGuiKeyData KeysData244;

        /// <summary>
        ///     The keysdata 245
        /// </summary>
        public ImGuiKeyData KeysData245;

        /// <summary>
        ///     The keysdata 246
        /// </summary>
        public ImGuiKeyData KeysData246;

        /// <summary>
        ///     The keysdata 247
        /// </summary>
        public ImGuiKeyData KeysData247;

        /// <summary>
        ///     The keysdata 248
        /// </summary>
        public ImGuiKeyData KeysData248;

        /// <summary>
        ///     The keysdata 249
        /// </summary>
        public ImGuiKeyData KeysData249;

        /// <summary>
        ///     The keysdata 250
        /// </summary>
        public ImGuiKeyData KeysData250;

        /// <summary>
        ///     The keysdata 251
        /// </summary>
        public ImGuiKeyData KeysData251;

        /// <summary>
        ///     The keysdata 252
        /// </summary>
        public ImGuiKeyData KeysData252;

        /// <summary>
        ///     The keysdata 253
        /// </summary>
        public ImGuiKeyData KeysData253;

        /// <summary>
        ///     The keysdata 254
        /// </summary>
        public ImGuiKeyData KeysData254;

        /// <summary>
        ///     The keysdata 255
        /// </summary>
        public ImGuiKeyData KeysData255;

        /// <summary>
        ///     The keysdata 256
        /// </summary>
        public ImGuiKeyData KeysData256;

        /// <summary>
        ///     The keysdata 257
        /// </summary>
        public ImGuiKeyData KeysData257;

        /// <summary>
        ///     The keysdata 258
        /// </summary>
        public ImGuiKeyData KeysData258;

        /// <summary>
        ///     The keysdata 259
        /// </summary>
        public ImGuiKeyData KeysData259;

        /// <summary>
        ///     The keysdata 260
        /// </summary>
        public ImGuiKeyData KeysData260;

        /// <summary>
        ///     The keysdata 261
        /// </summary>
        public ImGuiKeyData KeysData261;

        /// <summary>
        ///     The keysdata 262
        /// </summary>
        public ImGuiKeyData KeysData262;

        /// <summary>
        ///     The keysdata 263
        /// </summary>
        public ImGuiKeyData KeysData263;

        /// <summary>
        ///     The keysdata 264
        /// </summary>
        public ImGuiKeyData KeysData264;

        /// <summary>
        ///     The keysdata 265
        /// </summary>
        public ImGuiKeyData KeysData265;

        /// <summary>
        ///     The keysdata 266
        /// </summary>
        public ImGuiKeyData KeysData266;

        /// <summary>
        ///     The keysdata 267
        /// </summary>
        public ImGuiKeyData KeysData267;

        /// <summary>
        ///     The keysdata 268
        /// </summary>
        public ImGuiKeyData KeysData268;

        /// <summary>
        ///     The keysdata 269
        /// </summary>
        public ImGuiKeyData KeysData269;

        /// <summary>
        ///     The keysdata 270
        /// </summary>
        public ImGuiKeyData KeysData270;

        /// <summary>
        ///     The keysdata 271
        /// </summary>
        public ImGuiKeyData KeysData271;

        /// <summary>
        ///     The keysdata 272
        /// </summary>
        public ImGuiKeyData KeysData272;

        /// <summary>
        ///     The keysdata 273
        /// </summary>
        public ImGuiKeyData KeysData273;

        /// <summary>
        ///     The keysdata 274
        /// </summary>
        public ImGuiKeyData KeysData274;

        /// <summary>
        ///     The keysdata 275
        /// </summary>
        public ImGuiKeyData KeysData275;

        /// <summary>
        ///     The keysdata 276
        /// </summary>
        public ImGuiKeyData KeysData276;

        /// <summary>
        ///     The keysdata 277
        /// </summary>
        public ImGuiKeyData KeysData277;

        /// <summary>
        ///     The keysdata 278
        /// </summary>
        public ImGuiKeyData KeysData278;

        /// <summary>
        ///     The keysdata 279
        /// </summary>
        public ImGuiKeyData KeysData279;

        /// <summary>
        ///     The keysdata 280
        /// </summary>
        public ImGuiKeyData KeysData280;

        /// <summary>
        ///     The keysdata 281
        /// </summary>
        public ImGuiKeyData KeysData281;

        /// <summary>
        ///     The keysdata 282
        /// </summary>
        public ImGuiKeyData KeysData282;

        /// <summary>
        ///     The keysdata 283
        /// </summary>
        public ImGuiKeyData KeysData283;

        /// <summary>
        ///     The keysdata 284
        /// </summary>
        public ImGuiKeyData KeysData284;

        /// <summary>
        ///     The keysdata 285
        /// </summary>
        public ImGuiKeyData KeysData285;

        /// <summary>
        ///     The keysdata 286
        /// </summary>
        public ImGuiKeyData KeysData286;

        /// <summary>
        ///     The keysdata 287
        /// </summary>
        public ImGuiKeyData KeysData287;

        /// <summary>
        ///     The keysdata 288
        /// </summary>
        public ImGuiKeyData KeysData288;

        /// <summary>
        ///     The keysdata 289
        /// </summary>
        public ImGuiKeyData KeysData289;

        /// <summary>
        ///     The keysdata 290
        /// </summary>
        public ImGuiKeyData KeysData290;

        /// <summary>
        ///     The keysdata 291
        /// </summary>
        public ImGuiKeyData KeysData291;

        /// <summary>
        ///     The keysdata 292
        /// </summary>
        public ImGuiKeyData KeysData292;

        /// <summary>
        ///     The keysdata 293
        /// </summary>
        public ImGuiKeyData KeysData293;

        /// <summary>
        ///     The keysdata 294
        /// </summary>
        public ImGuiKeyData KeysData294;

        /// <summary>
        ///     The keysdata 295
        /// </summary>
        public ImGuiKeyData KeysData295;

        /// <summary>
        ///     The keysdata 296
        /// </summary>
        public ImGuiKeyData KeysData296;

        /// <summary>
        ///     The keysdata 297
        /// </summary>
        public ImGuiKeyData KeysData297;

        /// <summary>
        ///     The keysdata 298
        /// </summary>
        public ImGuiKeyData KeysData298;

        /// <summary>
        ///     The keysdata 299
        /// </summary>
        public ImGuiKeyData KeysData299;

        /// <summary>
        ///     The keysdata 300
        /// </summary>
        public ImGuiKeyData KeysData300;

        /// <summary>
        ///     The keysdata 301
        /// </summary>
        public ImGuiKeyData KeysData301;

        /// <summary>
        ///     The keysdata 302
        /// </summary>
        public ImGuiKeyData KeysData302;

        /// <summary>
        ///     The keysdata 303
        /// </summary>
        public ImGuiKeyData KeysData303;

        /// <summary>
        ///     The keysdata 304
        /// </summary>
        public ImGuiKeyData KeysData304;

        /// <summary>
        ///     The keysdata 305
        /// </summary>
        public ImGuiKeyData KeysData305;

        /// <summary>
        ///     The keysdata 306
        /// </summary>
        public ImGuiKeyData KeysData306;

        /// <summary>
        ///     The keysdata 307
        /// </summary>
        public ImGuiKeyData KeysData307;

        /// <summary>
        ///     The keysdata 308
        /// </summary>
        public ImGuiKeyData KeysData308;

        /// <summary>
        ///     The keysdata 309
        /// </summary>
        public ImGuiKeyData KeysData309;

        /// <summary>
        ///     The keysdata 310
        /// </summary>
        public ImGuiKeyData KeysData310;

        /// <summary>
        ///     The keysdata 311
        /// </summary>
        public ImGuiKeyData KeysData311;

        /// <summary>
        ///     The keysdata 312
        /// </summary>
        public ImGuiKeyData KeysData312;

        /// <summary>
        ///     The keysdata 313
        /// </summary>
        public ImGuiKeyData KeysData313;

        /// <summary>
        ///     The keysdata 314
        /// </summary>
        public ImGuiKeyData KeysData314;

        /// <summary>
        ///     The keysdata 315
        /// </summary>
        public ImGuiKeyData KeysData315;

        /// <summary>
        ///     The keysdata 316
        /// </summary>
        public ImGuiKeyData KeysData316;

        /// <summary>
        ///     The keysdata 317
        /// </summary>
        public ImGuiKeyData KeysData317;

        /// <summary>
        ///     The keysdata 318
        /// </summary>
        public ImGuiKeyData KeysData318;

        /// <summary>
        ///     The keysdata 319
        /// </summary>
        public ImGuiKeyData KeysData319;

        /// <summary>
        ///     The keysdata 320
        /// </summary>
        public ImGuiKeyData KeysData320;

        /// <summary>
        ///     The keysdata 321
        /// </summary>
        public ImGuiKeyData KeysData321;

        /// <summary>
        ///     The keysdata 322
        /// </summary>
        public ImGuiKeyData KeysData322;

        /// <summary>
        ///     The keysdata 323
        /// </summary>
        public ImGuiKeyData KeysData323;

        /// <summary>
        ///     The keysdata 324
        /// </summary>
        public ImGuiKeyData KeysData324;

        /// <summary>
        ///     The keysdata 325
        /// </summary>
        public ImGuiKeyData KeysData325;

        /// <summary>
        ///     The keysdata 326
        /// </summary>
        public ImGuiKeyData KeysData326;

        /// <summary>
        ///     The keysdata 327
        /// </summary>
        public ImGuiKeyData KeysData327;

        /// <summary>
        ///     The keysdata 328
        /// </summary>
        public ImGuiKeyData KeysData328;

        /// <summary>
        ///     The keysdata 329
        /// </summary>
        public ImGuiKeyData KeysData329;

        /// <summary>
        ///     The keysdata 330
        /// </summary>
        public ImGuiKeyData KeysData330;

        /// <summary>
        ///     The keysdata 331
        /// </summary>
        public ImGuiKeyData KeysData331;

        /// <summary>
        ///     The keysdata 332
        /// </summary>
        public ImGuiKeyData KeysData332;

        /// <summary>
        ///     The keysdata 333
        /// </summary>
        public ImGuiKeyData KeysData333;

        /// <summary>
        ///     The keysdata 334
        /// </summary>
        public ImGuiKeyData KeysData334;

        /// <summary>
        ///     The keysdata 335
        /// </summary>
        public ImGuiKeyData KeysData335;

        /// <summary>
        ///     The keysdata 336
        /// </summary>
        public ImGuiKeyData KeysData336;

        /// <summary>
        ///     The keysdata 337
        /// </summary>
        public ImGuiKeyData KeysData337;

        /// <summary>
        ///     The keysdata 338
        /// </summary>
        public ImGuiKeyData KeysData338;

        /// <summary>
        ///     The keysdata 339
        /// </summary>
        public ImGuiKeyData KeysData339;

        /// <summary>
        ///     The keysdata 340
        /// </summary>
        public ImGuiKeyData KeysData340;

        /// <summary>
        ///     The keysdata 341
        /// </summary>
        public ImGuiKeyData KeysData341;

        /// <summary>
        ///     The keysdata 342
        /// </summary>
        public ImGuiKeyData KeysData342;

        /// <summary>
        ///     The keysdata 343
        /// </summary>
        public ImGuiKeyData KeysData343;

        /// <summary>
        ///     The keysdata 344
        /// </summary>
        public ImGuiKeyData KeysData344;

        /// <summary>
        ///     The keysdata 345
        /// </summary>
        public ImGuiKeyData KeysData345;

        /// <summary>
        ///     The keysdata 346
        /// </summary>
        public ImGuiKeyData KeysData346;

        /// <summary>
        ///     The keysdata 347
        /// </summary>
        public ImGuiKeyData KeysData347;

        /// <summary>
        ///     The keysdata 348
        /// </summary>
        public ImGuiKeyData KeysData348;

        /// <summary>
        ///     The keysdata 349
        /// </summary>
        public ImGuiKeyData KeysData349;

        /// <summary>
        ///     The keysdata 350
        /// </summary>
        public ImGuiKeyData KeysData350;

        /// <summary>
        ///     The keysdata 351
        /// </summary>
        public ImGuiKeyData KeysData351;

        /// <summary>
        ///     The keysdata 352
        /// </summary>
        public ImGuiKeyData KeysData352;

        /// <summary>
        ///     The keysdata 353
        /// </summary>
        public ImGuiKeyData KeysData353;

        /// <summary>
        ///     The keysdata 354
        /// </summary>
        public ImGuiKeyData KeysData354;

        /// <summary>
        ///     The keysdata 355
        /// </summary>
        public ImGuiKeyData KeysData355;

        /// <summary>
        ///     The keysdata 356
        /// </summary>
        public ImGuiKeyData KeysData356;

        /// <summary>
        ///     The keysdata 357
        /// </summary>
        public ImGuiKeyData KeysData357;

        /// <summary>
        ///     The keysdata 358
        /// </summary>
        public ImGuiKeyData KeysData358;

        /// <summary>
        ///     The keysdata 359
        /// </summary>
        public ImGuiKeyData KeysData359;

        /// <summary>
        ///     The keysdata 360
        /// </summary>
        public ImGuiKeyData KeysData360;

        /// <summary>
        ///     The keysdata 361
        /// </summary>
        public ImGuiKeyData KeysData361;

        /// <summary>
        ///     The keysdata 362
        /// </summary>
        public ImGuiKeyData KeysData362;

        /// <summary>
        ///     The keysdata 363
        /// </summary>
        public ImGuiKeyData KeysData363;

        /// <summary>
        ///     The keysdata 364
        /// </summary>
        public ImGuiKeyData KeysData364;

        /// <summary>
        ///     The keysdata 365
        /// </summary>
        public ImGuiKeyData KeysData365;

        /// <summary>
        ///     The keysdata 366
        /// </summary>
        public ImGuiKeyData KeysData366;

        /// <summary>
        ///     The keysdata 367
        /// </summary>
        public ImGuiKeyData KeysData367;

        /// <summary>
        ///     The keysdata 368
        /// </summary>
        public ImGuiKeyData KeysData368;

        /// <summary>
        ///     The keysdata 369
        /// </summary>
        public ImGuiKeyData KeysData369;

        /// <summary>
        ///     The keysdata 370
        /// </summary>
        public ImGuiKeyData KeysData370;

        /// <summary>
        ///     The keysdata 371
        /// </summary>
        public ImGuiKeyData KeysData371;

        /// <summary>
        ///     The keysdata 372
        /// </summary>
        public ImGuiKeyData KeysData372;

        /// <summary>
        ///     The keysdata 373
        /// </summary>
        public ImGuiKeyData KeysData373;

        /// <summary>
        ///     The keysdata 374
        /// </summary>
        public ImGuiKeyData KeysData374;

        /// <summary>
        ///     The keysdata 375
        /// </summary>
        public ImGuiKeyData KeysData375;

        /// <summary>
        ///     The keysdata 376
        /// </summary>
        public ImGuiKeyData KeysData376;

        /// <summary>
        ///     The keysdata 377
        /// </summary>
        public ImGuiKeyData KeysData377;

        /// <summary>
        ///     The keysdata 378
        /// </summary>
        public ImGuiKeyData KeysData378;

        /// <summary>
        ///     The keysdata 379
        /// </summary>
        public ImGuiKeyData KeysData379;

        /// <summary>
        ///     The keysdata 380
        /// </summary>
        public ImGuiKeyData KeysData380;

        /// <summary>
        ///     The keysdata 381
        /// </summary>
        public ImGuiKeyData KeysData381;

        /// <summary>
        ///     The keysdata 382
        /// </summary>
        public ImGuiKeyData KeysData382;

        /// <summary>
        ///     The keysdata 383
        /// </summary>
        public ImGuiKeyData KeysData383;

        /// <summary>
        ///     The keysdata 384
        /// </summary>
        public ImGuiKeyData KeysData384;

        /// <summary>
        ///     The keysdata 385
        /// </summary>
        public ImGuiKeyData KeysData385;

        /// <summary>
        ///     The keysdata 386
        /// </summary>
        public ImGuiKeyData KeysData386;

        /// <summary>
        ///     The keysdata 387
        /// </summary>
        public ImGuiKeyData KeysData387;

        /// <summary>
        ///     The keysdata 388
        /// </summary>
        public ImGuiKeyData KeysData388;

        /// <summary>
        ///     The keysdata 389
        /// </summary>
        public ImGuiKeyData KeysData389;

        /// <summary>
        ///     The keysdata 390
        /// </summary>
        public ImGuiKeyData KeysData390;

        /// <summary>
        ///     The keysdata 391
        /// </summary>
        public ImGuiKeyData KeysData391;

        /// <summary>
        ///     The keysdata 392
        /// </summary>
        public ImGuiKeyData KeysData392;

        /// <summary>
        ///     The keysdata 393
        /// </summary>
        public ImGuiKeyData KeysData393;

        /// <summary>
        ///     The keysdata 394
        /// </summary>
        public ImGuiKeyData KeysData394;

        /// <summary>
        ///     The keysdata 395
        /// </summary>
        public ImGuiKeyData KeysData395;

        /// <summary>
        ///     The keysdata 396
        /// </summary>
        public ImGuiKeyData KeysData396;

        /// <summary>
        ///     The keysdata 397
        /// </summary>
        public ImGuiKeyData KeysData397;

        /// <summary>
        ///     The keysdata 398
        /// </summary>
        public ImGuiKeyData KeysData398;

        /// <summary>
        ///     The keysdata 399
        /// </summary>
        public ImGuiKeyData KeysData399;

        /// <summary>
        ///     The keysdata 400
        /// </summary>
        public ImGuiKeyData KeysData400;

        /// <summary>
        ///     The keysdata 401
        /// </summary>
        public ImGuiKeyData KeysData401;

        /// <summary>
        ///     The keysdata 402
        /// </summary>
        public ImGuiKeyData KeysData402;

        /// <summary>
        ///     The keysdata 403
        /// </summary>
        public ImGuiKeyData KeysData403;

        /// <summary>
        ///     The keysdata 404
        /// </summary>
        public ImGuiKeyData KeysData404;

        /// <summary>
        ///     The keysdata 405
        /// </summary>
        public ImGuiKeyData KeysData405;

        /// <summary>
        ///     The keysdata 406
        /// </summary>
        public ImGuiKeyData KeysData406;

        /// <summary>
        ///     The keysdata 407
        /// </summary>
        public ImGuiKeyData KeysData407;

        /// <summary>
        ///     The keysdata 408
        /// </summary>
        public ImGuiKeyData KeysData408;

        /// <summary>
        ///     The keysdata 409
        /// </summary>
        public ImGuiKeyData KeysData409;

        /// <summary>
        ///     The keysdata 410
        /// </summary>
        public ImGuiKeyData KeysData410;

        /// <summary>
        ///     The keysdata 411
        /// </summary>
        public ImGuiKeyData KeysData411;

        /// <summary>
        ///     The keysdata 412
        /// </summary>
        public ImGuiKeyData KeysData412;

        /// <summary>
        ///     The keysdata 413
        /// </summary>
        public ImGuiKeyData KeysData413;

        /// <summary>
        ///     The keysdata 414
        /// </summary>
        public ImGuiKeyData KeysData414;

        /// <summary>
        ///     The keysdata 415
        /// </summary>
        public ImGuiKeyData KeysData415;

        /// <summary>
        ///     The keysdata 416
        /// </summary>
        public ImGuiKeyData KeysData416;

        /// <summary>
        ///     The keysdata 417
        /// </summary>
        public ImGuiKeyData KeysData417;

        /// <summary>
        ///     The keysdata 418
        /// </summary>
        public ImGuiKeyData KeysData418;

        /// <summary>
        ///     The keysdata 419
        /// </summary>
        public ImGuiKeyData KeysData419;

        /// <summary>
        ///     The keysdata 420
        /// </summary>
        public ImGuiKeyData KeysData420;

        /// <summary>
        ///     The keysdata 421
        /// </summary>
        public ImGuiKeyData KeysData421;

        /// <summary>
        ///     The keysdata 422
        /// </summary>
        public ImGuiKeyData KeysData422;

        /// <summary>
        ///     The keysdata 423
        /// </summary>
        public ImGuiKeyData KeysData423;

        /// <summary>
        ///     The keysdata 424
        /// </summary>
        public ImGuiKeyData KeysData424;

        /// <summary>
        ///     The keysdata 425
        /// </summary>
        public ImGuiKeyData KeysData425;

        /// <summary>
        ///     The keysdata 426
        /// </summary>
        public ImGuiKeyData KeysData426;

        /// <summary>
        ///     The keysdata 427
        /// </summary>
        public ImGuiKeyData KeysData427;

        /// <summary>
        ///     The keysdata 428
        /// </summary>
        public ImGuiKeyData KeysData428;

        /// <summary>
        ///     The keysdata 429
        /// </summary>
        public ImGuiKeyData KeysData429;

        /// <summary>
        ///     The keysdata 430
        /// </summary>
        public ImGuiKeyData KeysData430;

        /// <summary>
        ///     The keysdata 431
        /// </summary>
        public ImGuiKeyData KeysData431;

        /// <summary>
        ///     The keysdata 432
        /// </summary>
        public ImGuiKeyData KeysData432;

        /// <summary>
        ///     The keysdata 433
        /// </summary>
        public ImGuiKeyData KeysData433;

        /// <summary>
        ///     The keysdata 434
        /// </summary>
        public ImGuiKeyData KeysData434;

        /// <summary>
        ///     The keysdata 435
        /// </summary>
        public ImGuiKeyData KeysData435;

        /// <summary>
        ///     The keysdata 436
        /// </summary>
        public ImGuiKeyData KeysData436;

        /// <summary>
        ///     The keysdata 437
        /// </summary>
        public ImGuiKeyData KeysData437;

        /// <summary>
        ///     The keysdata 438
        /// </summary>
        public ImGuiKeyData KeysData438;

        /// <summary>
        ///     The keysdata 439
        /// </summary>
        public ImGuiKeyData KeysData439;

        /// <summary>
        ///     The keysdata 440
        /// </summary>
        public ImGuiKeyData KeysData440;

        /// <summary>
        ///     The keysdata 441
        /// </summary>
        public ImGuiKeyData KeysData441;

        /// <summary>
        ///     The keysdata 442
        /// </summary>
        public ImGuiKeyData KeysData442;

        /// <summary>
        ///     The keysdata 443
        /// </summary>
        public ImGuiKeyData KeysData443;

        /// <summary>
        ///     The keysdata 444
        /// </summary>
        public ImGuiKeyData KeysData444;

        /// <summary>
        ///     The keysdata 445
        /// </summary>
        public ImGuiKeyData KeysData445;

        /// <summary>
        ///     The keysdata 446
        /// </summary>
        public ImGuiKeyData KeysData446;

        /// <summary>
        ///     The keysdata 447
        /// </summary>
        public ImGuiKeyData KeysData447;

        /// <summary>
        ///     The keysdata 448
        /// </summary>
        public ImGuiKeyData KeysData448;

        /// <summary>
        ///     The keysdata 449
        /// </summary>
        public ImGuiKeyData KeysData449;

        /// <summary>
        ///     The keysdata 450
        /// </summary>
        public ImGuiKeyData KeysData450;

        /// <summary>
        ///     The keysdata 451
        /// </summary>
        public ImGuiKeyData KeysData451;

        /// <summary>
        ///     The keysdata 452
        /// </summary>
        public ImGuiKeyData KeysData452;

        /// <summary>
        ///     The keysdata 453
        /// </summary>
        public ImGuiKeyData KeysData453;

        /// <summary>
        ///     The keysdata 454
        /// </summary>
        public ImGuiKeyData KeysData454;

        /// <summary>
        ///     The keysdata 455
        /// </summary>
        public ImGuiKeyData KeysData455;

        /// <summary>
        ///     The keysdata 456
        /// </summary>
        public ImGuiKeyData KeysData456;

        /// <summary>
        ///     The keysdata 457
        /// </summary>
        public ImGuiKeyData KeysData457;

        /// <summary>
        ///     The keysdata 458
        /// </summary>
        public ImGuiKeyData KeysData458;

        /// <summary>
        ///     The keysdata 459
        /// </summary>
        public ImGuiKeyData KeysData459;

        /// <summary>
        ///     The keysdata 460
        /// </summary>
        public ImGuiKeyData KeysData460;

        /// <summary>
        ///     The keysdata 461
        /// </summary>
        public ImGuiKeyData KeysData461;

        /// <summary>
        ///     The keysdata 462
        /// </summary>
        public ImGuiKeyData KeysData462;

        /// <summary>
        ///     The keysdata 463
        /// </summary>
        public ImGuiKeyData KeysData463;

        /// <summary>
        ///     The keysdata 464
        /// </summary>
        public ImGuiKeyData KeysData464;

        /// <summary>
        ///     The keysdata 465
        /// </summary>
        public ImGuiKeyData KeysData465;

        /// <summary>
        ///     The keysdata 466
        /// </summary>
        public ImGuiKeyData KeysData466;

        /// <summary>
        ///     The keysdata 467
        /// </summary>
        public ImGuiKeyData KeysData467;

        /// <summary>
        ///     The keysdata 468
        /// </summary>
        public ImGuiKeyData KeysData468;

        /// <summary>
        ///     The keysdata 469
        /// </summary>
        public ImGuiKeyData KeysData469;

        /// <summary>
        ///     The keysdata 470
        /// </summary>
        public ImGuiKeyData KeysData470;

        /// <summary>
        ///     The keysdata 471
        /// </summary>
        public ImGuiKeyData KeysData471;

        /// <summary>
        ///     The keysdata 472
        /// </summary>
        public ImGuiKeyData KeysData472;

        /// <summary>
        ///     The keysdata 473
        /// </summary>
        public ImGuiKeyData KeysData473;

        /// <summary>
        ///     The keysdata 474
        /// </summary>
        public ImGuiKeyData KeysData474;

        /// <summary>
        ///     The keysdata 475
        /// </summary>
        public ImGuiKeyData KeysData475;

        /// <summary>
        ///     The keysdata 476
        /// </summary>
        public ImGuiKeyData KeysData476;

        /// <summary>
        ///     The keysdata 477
        /// </summary>
        public ImGuiKeyData KeysData477;

        /// <summary>
        ///     The keysdata 478
        /// </summary>
        public ImGuiKeyData KeysData478;

        /// <summary>
        ///     The keysdata 479
        /// </summary>
        public ImGuiKeyData KeysData479;

        /// <summary>
        ///     The keysdata 480
        /// </summary>
        public ImGuiKeyData KeysData480;

        /// <summary>
        ///     The keysdata 481
        /// </summary>
        public ImGuiKeyData KeysData481;

        /// <summary>
        ///     The keysdata 482
        /// </summary>
        public ImGuiKeyData KeysData482;

        /// <summary>
        ///     The keysdata 483
        /// </summary>
        public ImGuiKeyData KeysData483;

        /// <summary>
        ///     The keysdata 484
        /// </summary>
        public ImGuiKeyData KeysData484;

        /// <summary>
        ///     The keysdata 485
        /// </summary>
        public ImGuiKeyData KeysData485;

        /// <summary>
        ///     The keysdata 486
        /// </summary>
        public ImGuiKeyData KeysData486;

        /// <summary>
        ///     The keysdata 487
        /// </summary>
        public ImGuiKeyData KeysData487;

        /// <summary>
        ///     The keysdata 488
        /// </summary>
        public ImGuiKeyData KeysData488;

        /// <summary>
        ///     The keysdata 489
        /// </summary>
        public ImGuiKeyData KeysData489;

        /// <summary>
        ///     The keysdata 490
        /// </summary>
        public ImGuiKeyData KeysData490;

        /// <summary>
        ///     The keysdata 491
        /// </summary>
        public ImGuiKeyData KeysData491;

        /// <summary>
        ///     The keysdata 492
        /// </summary>
        public ImGuiKeyData KeysData492;

        /// <summary>
        ///     The keysdata 493
        /// </summary>
        public ImGuiKeyData KeysData493;

        /// <summary>
        ///     The keysdata 494
        /// </summary>
        public ImGuiKeyData KeysData494;

        /// <summary>
        ///     The keysdata 495
        /// </summary>
        public ImGuiKeyData KeysData495;

        /// <summary>
        ///     The keysdata 496
        /// </summary>
        public ImGuiKeyData KeysData496;

        /// <summary>
        ///     The keysdata 497
        /// </summary>
        public ImGuiKeyData KeysData497;

        /// <summary>
        ///     The keysdata 498
        /// </summary>
        public ImGuiKeyData KeysData498;

        /// <summary>
        ///     The keysdata 499
        /// </summary>
        public ImGuiKeyData KeysData499;

        /// <summary>
        ///     The keysdata 500
        /// </summary>
        public ImGuiKeyData KeysData500;

        /// <summary>
        ///     The keysdata 501
        /// </summary>
        public ImGuiKeyData KeysData501;

        /// <summary>
        ///     The keysdata 502
        /// </summary>
        public ImGuiKeyData KeysData502;

        /// <summary>
        ///     The keysdata 503
        /// </summary>
        public ImGuiKeyData KeysData503;

        /// <summary>
        ///     The keysdata 504
        /// </summary>
        public ImGuiKeyData KeysData504;

        /// <summary>
        ///     The keysdata 505
        /// </summary>
        public ImGuiKeyData KeysData505;

        /// <summary>
        ///     The keysdata 506
        /// </summary>
        public ImGuiKeyData KeysData506;

        /// <summary>
        ///     The keysdata 507
        /// </summary>
        public ImGuiKeyData KeysData507;

        /// <summary>
        ///     The keysdata 508
        /// </summary>
        public ImGuiKeyData KeysData508;

        /// <summary>
        ///     The keysdata 509
        /// </summary>
        public ImGuiKeyData KeysData509;

        /// <summary>
        ///     The keysdata 510
        /// </summary>
        public ImGuiKeyData KeysData510;

        /// <summary>
        ///     The keysdata 511
        /// </summary>
        public ImGuiKeyData KeysData511;

        /// <summary>
        ///     The keysdata 512
        /// </summary>
        public ImGuiKeyData KeysData512;

        /// <summary>
        ///     The keysdata 513
        /// </summary>
        public ImGuiKeyData KeysData513;

        /// <summary>
        ///     The keysdata 514
        /// </summary>
        public ImGuiKeyData KeysData514;

        /// <summary>
        ///     The keysdata 515
        /// </summary>
        public ImGuiKeyData KeysData515;

        /// <summary>
        ///     The keysdata 516
        /// </summary>
        public ImGuiKeyData KeysData516;

        /// <summary>
        ///     The keysdata 517
        /// </summary>
        public ImGuiKeyData KeysData517;

        /// <summary>
        ///     The keysdata 518
        /// </summary>
        public ImGuiKeyData KeysData518;

        /// <summary>
        ///     The keysdata 519
        /// </summary>
        public ImGuiKeyData KeysData519;

        /// <summary>
        ///     The keysdata 520
        /// </summary>
        public ImGuiKeyData KeysData520;

        /// <summary>
        ///     The keysdata 521
        /// </summary>
        public ImGuiKeyData KeysData521;

        /// <summary>
        ///     The keysdata 522
        /// </summary>
        public ImGuiKeyData KeysData522;

        /// <summary>
        ///     The keysdata 523
        /// </summary>
        public ImGuiKeyData KeysData523;

        /// <summary>
        ///     The keysdata 524
        /// </summary>
        public ImGuiKeyData KeysData524;

        /// <summary>
        ///     The keysdata 525
        /// </summary>
        public ImGuiKeyData KeysData525;

        /// <summary>
        ///     The keysdata 526
        /// </summary>
        public ImGuiKeyData KeysData526;

        /// <summary>
        ///     The keysdata 527
        /// </summary>
        public ImGuiKeyData KeysData527;

        /// <summary>
        ///     The keysdata 528
        /// </summary>
        public ImGuiKeyData KeysData528;

        /// <summary>
        ///     The keysdata 529
        /// </summary>
        public ImGuiKeyData KeysData529;

        /// <summary>
        ///     The keysdata 530
        /// </summary>
        public ImGuiKeyData KeysData530;

        /// <summary>
        ///     The keysdata 531
        /// </summary>
        public ImGuiKeyData KeysData531;

        /// <summary>
        ///     The keysdata 532
        /// </summary>
        public ImGuiKeyData KeysData532;

        /// <summary>
        ///     The keysdata 533
        /// </summary>
        public ImGuiKeyData KeysData533;

        /// <summary>
        ///     The keysdata 534
        /// </summary>
        public ImGuiKeyData KeysData534;

        /// <summary>
        ///     The keysdata 535
        /// </summary>
        public ImGuiKeyData KeysData535;

        /// <summary>
        ///     The keysdata 536
        /// </summary>
        public ImGuiKeyData KeysData536;

        /// <summary>
        ///     The keysdata 537
        /// </summary>
        public ImGuiKeyData KeysData537;

        /// <summary>
        ///     The keysdata 538
        /// </summary>
        public ImGuiKeyData KeysData538;

        /// <summary>
        ///     The keysdata 539
        /// </summary>
        public ImGuiKeyData KeysData539;

        /// <summary>
        ///     The keysdata 540
        /// </summary>
        public ImGuiKeyData KeysData540;

        /// <summary>
        ///     The keysdata 541
        /// </summary>
        public ImGuiKeyData KeysData541;

        /// <summary>
        ///     The keysdata 542
        /// </summary>
        public ImGuiKeyData KeysData542;

        /// <summary>
        ///     The keysdata 543
        /// </summary>
        public ImGuiKeyData KeysData543;

        /// <summary>
        ///     The keysdata 544
        /// </summary>
        public ImGuiKeyData KeysData544;

        /// <summary>
        ///     The keysdata 545
        /// </summary>
        public ImGuiKeyData KeysData545;

        /// <summary>
        ///     The keysdata 546
        /// </summary>
        public ImGuiKeyData KeysData546;

        /// <summary>
        ///     The keysdata 547
        /// </summary>
        public ImGuiKeyData KeysData547;

        /// <summary>
        ///     The keysdata 548
        /// </summary>
        public ImGuiKeyData KeysData548;

        /// <summary>
        ///     The keysdata 549
        /// </summary>
        public ImGuiKeyData KeysData549;

        /// <summary>
        ///     The keysdata 550
        /// </summary>
        public ImGuiKeyData KeysData550;

        /// <summary>
        ///     The keysdata 551
        /// </summary>
        public ImGuiKeyData KeysData551;

        /// <summary>
        ///     The keysdata 552
        /// </summary>
        public ImGuiKeyData KeysData552;

        /// <summary>
        ///     The keysdata 553
        /// </summary>
        public ImGuiKeyData KeysData553;

        /// <summary>
        ///     The keysdata 554
        /// </summary>
        public ImGuiKeyData KeysData554;

        /// <summary>
        ///     The keysdata 555
        /// </summary>
        public ImGuiKeyData KeysData555;

        /// <summary>
        ///     The keysdata 556
        /// </summary>
        public ImGuiKeyData KeysData556;

        /// <summary>
        ///     The keysdata 557
        /// </summary>
        public ImGuiKeyData KeysData557;

        /// <summary>
        ///     The keysdata 558
        /// </summary>
        public ImGuiKeyData KeysData558;

        /// <summary>
        ///     The keysdata 559
        /// </summary>
        public ImGuiKeyData KeysData559;

        /// <summary>
        ///     The keysdata 560
        /// </summary>
        public ImGuiKeyData KeysData560;

        /// <summary>
        ///     The keysdata 561
        /// </summary>
        public ImGuiKeyData KeysData561;

        /// <summary>
        ///     The keysdata 562
        /// </summary>
        public ImGuiKeyData KeysData562;

        /// <summary>
        ///     The keysdata 563
        /// </summary>
        public ImGuiKeyData KeysData563;

        /// <summary>
        ///     The keysdata 564
        /// </summary>
        public ImGuiKeyData KeysData564;

        /// <summary>
        ///     The keysdata 565
        /// </summary>
        public ImGuiKeyData KeysData565;

        /// <summary>
        ///     The keysdata 566
        /// </summary>
        public ImGuiKeyData KeysData566;

        /// <summary>
        ///     The keysdata 567
        /// </summary>
        public ImGuiKeyData KeysData567;

        /// <summary>
        ///     The keysdata 568
        /// </summary>
        public ImGuiKeyData KeysData568;

        /// <summary>
        ///     The keysdata 569
        /// </summary>
        public ImGuiKeyData KeysData569;

        /// <summary>
        ///     The keysdata 570
        /// </summary>
        public ImGuiKeyData KeysData570;

        /// <summary>
        ///     The keysdata 571
        /// </summary>
        public ImGuiKeyData KeysData571;

        /// <summary>
        ///     The keysdata 572
        /// </summary>
        public ImGuiKeyData KeysData572;

        /// <summary>
        ///     The keysdata 573
        /// </summary>
        public ImGuiKeyData KeysData573;

        /// <summary>
        ///     The keysdata 574
        /// </summary>
        public ImGuiKeyData KeysData574;

        /// <summary>
        ///     The keysdata 575
        /// </summary>
        public ImGuiKeyData KeysData575;

        /// <summary>
        ///     The keysdata 576
        /// </summary>
        public ImGuiKeyData KeysData576;

        /// <summary>
        ///     The keysdata 577
        /// </summary>
        public ImGuiKeyData KeysData577;

        /// <summary>
        ///     The keysdata 578
        /// </summary>
        public ImGuiKeyData KeysData578;

        /// <summary>
        ///     The keysdata 579
        /// </summary>
        public ImGuiKeyData KeysData579;

        /// <summary>
        ///     The keysdata 580
        /// </summary>
        public ImGuiKeyData KeysData580;

        /// <summary>
        ///     The keysdata 581
        /// </summary>
        public ImGuiKeyData KeysData581;

        /// <summary>
        ///     The keysdata 582
        /// </summary>
        public ImGuiKeyData KeysData582;

        /// <summary>
        ///     The keysdata 583
        /// </summary>
        public ImGuiKeyData KeysData583;

        /// <summary>
        ///     The keysdata 584
        /// </summary>
        public ImGuiKeyData KeysData584;

        /// <summary>
        ///     The keysdata 585
        /// </summary>
        public ImGuiKeyData KeysData585;

        /// <summary>
        ///     The keysdata 586
        /// </summary>
        public ImGuiKeyData KeysData586;

        /// <summary>
        ///     The keysdata 587
        /// </summary>
        public ImGuiKeyData KeysData587;

        /// <summary>
        ///     The keysdata 588
        /// </summary>
        public ImGuiKeyData KeysData588;

        /// <summary>
        ///     The keysdata 589
        /// </summary>
        public ImGuiKeyData KeysData589;

        /// <summary>
        ///     The keysdata 590
        /// </summary>
        public ImGuiKeyData KeysData590;

        /// <summary>
        ///     The keysdata 591
        /// </summary>
        public ImGuiKeyData KeysData591;

        /// <summary>
        ///     The keysdata 592
        /// </summary>
        public ImGuiKeyData KeysData592;

        /// <summary>
        ///     The keysdata 593
        /// </summary>
        public ImGuiKeyData KeysData593;

        /// <summary>
        ///     The keysdata 594
        /// </summary>
        public ImGuiKeyData KeysData594;

        /// <summary>
        ///     The keysdata 595
        /// </summary>
        public ImGuiKeyData KeysData595;

        /// <summary>
        ///     The keysdata 596
        /// </summary>
        public ImGuiKeyData KeysData596;

        /// <summary>
        ///     The keysdata 597
        /// </summary>
        public ImGuiKeyData KeysData597;

        /// <summary>
        ///     The keysdata 598
        /// </summary>
        public ImGuiKeyData KeysData598;

        /// <summary>
        ///     The keysdata 599
        /// </summary>
        public ImGuiKeyData KeysData599;

        /// <summary>
        ///     The keysdata 600
        /// </summary>
        public ImGuiKeyData KeysData600;

        /// <summary>
        ///     The keysdata 601
        /// </summary>
        public ImGuiKeyData KeysData601;

        /// <summary>
        ///     The keysdata 602
        /// </summary>
        public ImGuiKeyData KeysData602;

        /// <summary>
        ///     The keysdata 603
        /// </summary>
        public ImGuiKeyData KeysData603;

        /// <summary>
        ///     The keysdata 604
        /// </summary>
        public ImGuiKeyData KeysData604;

        /// <summary>
        ///     The keysdata 605
        /// </summary>
        public ImGuiKeyData KeysData605;

        /// <summary>
        ///     The keysdata 606
        /// </summary>
        public ImGuiKeyData KeysData606;

        /// <summary>
        ///     The keysdata 607
        /// </summary>
        public ImGuiKeyData KeysData607;

        /// <summary>
        ///     The keysdata 608
        /// </summary>
        public ImGuiKeyData KeysData608;

        /// <summary>
        ///     The keysdata 609
        /// </summary>
        public ImGuiKeyData KeysData609;

        /// <summary>
        ///     The keysdata 610
        /// </summary>
        public ImGuiKeyData KeysData610;

        /// <summary>
        ///     The keysdata 611
        /// </summary>
        public ImGuiKeyData KeysData611;

        /// <summary>
        ///     The keysdata 612
        /// </summary>
        public ImGuiKeyData KeysData612;

        /// <summary>
        ///     The keysdata 613
        /// </summary>
        public ImGuiKeyData KeysData613;

        /// <summary>
        ///     The keysdata 614
        /// </summary>
        public ImGuiKeyData KeysData614;

        /// <summary>
        ///     The keysdata 615
        /// </summary>
        public ImGuiKeyData KeysData615;

        /// <summary>
        ///     The keysdata 616
        /// </summary>
        public ImGuiKeyData KeysData616;

        /// <summary>
        ///     The keysdata 617
        /// </summary>
        public ImGuiKeyData KeysData617;

        /// <summary>
        ///     The keysdata 618
        /// </summary>
        public ImGuiKeyData KeysData618;

        /// <summary>
        ///     The keysdata 619
        /// </summary>
        public ImGuiKeyData KeysData619;

        /// <summary>
        ///     The keysdata 620
        /// </summary>
        public ImGuiKeyData KeysData620;

        /// <summary>
        ///     The keysdata 621
        /// </summary>
        public ImGuiKeyData KeysData621;

        /// <summary>
        ///     The keysdata 622
        /// </summary>
        public ImGuiKeyData KeysData622;

        /// <summary>
        ///     The keysdata 623
        /// </summary>
        public ImGuiKeyData KeysData623;

        /// <summary>
        ///     The keysdata 624
        /// </summary>
        public ImGuiKeyData KeysData624;

        /// <summary>
        ///     The keysdata 625
        /// </summary>
        public ImGuiKeyData KeysData625;

        /// <summary>
        ///     The keysdata 626
        /// </summary>
        public ImGuiKeyData KeysData626;

        /// <summary>
        ///     The keysdata 627
        /// </summary>
        public ImGuiKeyData KeysData627;

        /// <summary>
        ///     The keysdata 628
        /// </summary>
        public ImGuiKeyData KeysData628;

        /// <summary>
        ///     The keysdata 629
        /// </summary>
        public ImGuiKeyData KeysData629;

        /// <summary>
        ///     The keysdata 630
        /// </summary>
        public ImGuiKeyData KeysData630;

        /// <summary>
        ///     The keysdata 631
        /// </summary>
        public ImGuiKeyData KeysData631;

        /// <summary>
        ///     The keysdata 632
        /// </summary>
        public ImGuiKeyData KeysData632;

        /// <summary>
        ///     The keysdata 633
        /// </summary>
        public ImGuiKeyData KeysData633;

        /// <summary>
        ///     The keysdata 634
        /// </summary>
        public ImGuiKeyData KeysData634;

        /// <summary>
        ///     The keysdata 635
        /// </summary>
        public ImGuiKeyData KeysData635;

        /// <summary>
        ///     The keysdata 636
        /// </summary>
        public ImGuiKeyData KeysData636;

        /// <summary>
        ///     The keysdata 637
        /// </summary>
        public ImGuiKeyData KeysData637;

        /// <summary>
        ///     The keysdata 638
        /// </summary>
        public ImGuiKeyData KeysData638;

        /// <summary>
        ///     The keysdata 639
        /// </summary>
        public ImGuiKeyData KeysData639;

        /// <summary>
        ///     The keysdata 640
        /// </summary>
        public ImGuiKeyData KeysData640;

        /// <summary>
        ///     The keysdata 641
        /// </summary>
        public ImGuiKeyData KeysData641;

        /// <summary>
        ///     The keysdata 642
        /// </summary>
        public ImGuiKeyData KeysData642;

        /// <summary>
        ///     The keysdata 643
        /// </summary>
        public ImGuiKeyData KeysData643;

        /// <summary>
        ///     The keysdata 644
        /// </summary>
        public ImGuiKeyData KeysData644;

        /// <summary>
        ///     The keysdata 645
        /// </summary>
        public ImGuiKeyData KeysData645;

        /// <summary>
        ///     The keysdata 646
        /// </summary>
        public ImGuiKeyData KeysData646;

        /// <summary>
        ///     The keysdata 647
        /// </summary>
        public ImGuiKeyData KeysData647;

        /// <summary>
        ///     The keysdata 648
        /// </summary>
        public ImGuiKeyData KeysData648;

        /// <summary>
        ///     The keysdata 649
        /// </summary>
        public ImGuiKeyData KeysData649;

        /// <summary>
        ///     The keysdata 650
        /// </summary>
        public ImGuiKeyData KeysData650;

        /// <summary>
        ///     The keysdata 651
        /// </summary>
        public ImGuiKeyData KeysData651;

        /// <summary>
        ///     The want capture mouse unless popup close
        /// </summary>
        public byte WantCaptureMouseUnlessPopupClose;

        /// <summary>
        ///     The mouse pos prev
        /// </summary>
        public Vector2 MousePosPrev;

        /// <summary>
        ///     The mouseclickedpos
        /// </summary>
        public Vector2 MouseClickedPos0;

        /// <summary>
        ///     The mouseclickedpos
        /// </summary>
        public Vector2 MouseClickedPos1;

        /// <summary>
        ///     The mouseclickedpos
        /// </summary>
        public Vector2 MouseClickedPos2;

        /// <summary>
        ///     The mouseclickedpos
        /// </summary>
        public Vector2 MouseClickedPos3;

        /// <summary>
        ///     The mouseclickedpos
        /// </summary>
        public Vector2 MouseClickedPos4;

        /// <summary>
        ///     The mouse clicked time
        /// </summary>
        public fixed double MouseClickedTime[5];

        /// <summary>
        ///     The mouse clicked
        /// </summary>
        public fixed byte MouseClicked[5];

        /// <summary>
        ///     The mouse double clicked
        /// </summary>
        public fixed byte MouseDoubleClicked[5];

        /// <summary>
        ///     The mouse clicked count
        /// </summary>
        public fixed ushort MouseClickedCount[5];

        /// <summary>
        ///     The mouse clicked last count
        /// </summary>
        public fixed ushort MouseClickedLastCount[5];

        /// <summary>
        ///     The mouse released
        /// </summary>
        public fixed byte MouseReleased[5];

        /// <summary>
        ///     The mouse down owned
        /// </summary>
        public fixed byte MouseDownOwned[5];

        /// <summary>
        ///     The mouse down owned unless popup close
        /// </summary>
        public fixed byte MouseDownOwnedUnlessPopupClose[5];

        /// <summary>
        ///     The mouse down duration
        /// </summary>
        public fixed float MouseDownDuration[5];

        /// <summary>
        ///     The mouse down duration prev
        /// </summary>
        public fixed float MouseDownDurationPrev[5];

        /// <summary>
        ///     The mousedragmaxdistanceabs
        /// </summary>
        public Vector2 MouseDragMaxDistanceAbs0;

        /// <summary>
        ///     The mousedragmaxdistanceabs
        /// </summary>
        public Vector2 MouseDragMaxDistanceAbs1;

        /// <summary>
        ///     The mousedragmaxdistanceabs
        /// </summary>
        public Vector2 MouseDragMaxDistanceAbs2;

        /// <summary>
        ///     The mousedragmaxdistanceabs
        /// </summary>
        public Vector2 MouseDragMaxDistanceAbs3;

        /// <summary>
        ///     The mousedragmaxdistanceabs
        /// </summary>
        public Vector2 MouseDragMaxDistanceAbs4;

        /// <summary>
        ///     The mouse drag max distance sqr
        /// </summary>
        public fixed float MouseDragMaxDistanceSqr[5];

        /// <summary>
        ///     The pen pressure
        /// </summary>
        public float PenPressure;

        /// <summary>
        ///     The app focus lost
        /// </summary>
        public byte AppFocusLost;

        /// <summary>
        ///     The app accepting events
        /// </summary>
        public byte AppAcceptingEvents;

        /// <summary>
        ///     The backend using legacy key arrays
        /// </summary>
        public sbyte BackendUsingLegacyKeyArrays;

        /// <summary>
        ///     The backend using legacy nav input array
        /// </summary>
        public byte BackendUsingLegacyNavInputArray;

        /// <summary>
        ///     The input queue surrogate
        /// </summary>
        public ushort InputQueueSurrogate;

        /// <summary>
        ///     The input queue characters
        /// </summary>
        public ImVector InputQueueCharacters;
    }
}