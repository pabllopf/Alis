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
using Alis.Core.Graphic.ImGui.Enums;

namespace Alis.Core.Graphic.ImGui.Structs
{
    /// <summary>
    ///     The im gui io
    /// </summary>
    public unsafe struct ImGuiIo
    {
        /// <summary>
        ///     The config flags
        /// </summary>
        public ImGuiConfigs Configs;

        /// <summary>
        ///     The backend flags
        /// </summary>
        public ImGuiBackends Backends;

        /// <summary>
        ///     The display size
        /// </summary>
        public Vector2F DisplaySize;

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
        public Vector2F DisplayFramebufferScale;

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
        ///     The config debug begin return value once
        /// </summary>
        public byte ConfigDebugBeginReturnValueOnce;

        /// <summary>
        ///     The config debug begin return value loop
        /// </summary>
        public byte ConfigDebugBeginReturnValueLoop;

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
        public Vector2F MouseDelta;

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
        ///     The ctx
        /// </summary>
        public IntPtr Ctx;

        /// <summary>
        ///     The mouse pos
        /// </summary>
        public Vector2F MousePos;

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
        ///     The mouse source
        /// </summary>
        public ImGuiMouseSource MouseSource;

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
        ///     The keys data
        /// </summary>
        public ImGuiKeyData KeysData0;

        /// <summary>
        ///     The keys data
        /// </summary>
        public ImGuiKeyData KeysData1;

        /// <summary>
        ///     The keys data
        /// </summary>
        public ImGuiKeyData KeysData2;

        /// <summary>
        ///     The keys data
        /// </summary>
        public ImGuiKeyData KeysData3;

        /// <summary>
        ///     The keys data
        /// </summary>
        public ImGuiKeyData KeysData4;

        /// <summary>
        ///     The keys data
        /// </summary>
        public ImGuiKeyData KeysData5;

        /// <summary>
        ///     The keys data
        /// </summary>
        public ImGuiKeyData KeysData6;

        /// <summary>
        ///     The keys data
        /// </summary>
        public ImGuiKeyData KeysData7;

        /// <summary>
        ///     The keys data
        /// </summary>
        public ImGuiKeyData KeysData8;

        /// <summary>
        ///     The keys data
        /// </summary>
        public ImGuiKeyData KeysData9;

        /// <summary>
        ///     The keys data 10
        /// </summary>
        public ImGuiKeyData KeysData10;

        /// <summary>
        ///     The keys data 11
        /// </summary>
        public ImGuiKeyData KeysData11;

        /// <summary>
        ///     The keys data 12
        /// </summary>
        public ImGuiKeyData KeysData12;

        /// <summary>
        ///     The keys data 13
        /// </summary>
        public ImGuiKeyData KeysData13;

        /// <summary>
        ///     The keys data 14
        /// </summary>
        public ImGuiKeyData KeysData14;

        /// <summary>
        ///     The keys data 15
        /// </summary>
        public ImGuiKeyData KeysData15;

        /// <summary>
        ///     The keys data 16
        /// </summary>
        public ImGuiKeyData KeysData16;

        /// <summary>
        ///     The keys data 17
        /// </summary>
        public ImGuiKeyData KeysData17;

        /// <summary>
        ///     The keys data 18
        /// </summary>
        public ImGuiKeyData KeysData18;

        /// <summary>
        ///     The keys data 19
        /// </summary>
        public ImGuiKeyData KeysData19;

        /// <summary>
        ///     The keys data 20
        /// </summary>
        public ImGuiKeyData KeysData20;

        /// <summary>
        ///     The keys data 21
        /// </summary>
        public ImGuiKeyData KeysData21;

        /// <summary>
        ///     The keys data 22
        /// </summary>
        public ImGuiKeyData KeysData22;

        /// <summary>
        ///     The keys data 23
        /// </summary>
        public ImGuiKeyData KeysData23;

        /// <summary>
        ///     The keys data 24
        /// </summary>
        public ImGuiKeyData KeysData24;

        /// <summary>
        ///     The keys data 25
        /// </summary>
        public ImGuiKeyData KeysData25;

        /// <summary>
        ///     The keys data 26
        /// </summary>
        public ImGuiKeyData KeysData26;

        /// <summary>
        ///     The keys data 27
        /// </summary>
        public ImGuiKeyData KeysData27;

        /// <summary>
        ///     The keys data 28
        /// </summary>
        public ImGuiKeyData KeysData28;

        /// <summary>
        ///     The keys data 29
        /// </summary>
        public ImGuiKeyData KeysData29;

        /// <summary>
        ///     The keys data 30
        /// </summary>
        public ImGuiKeyData KeysData30;

        /// <summary>
        ///     The keys data 31
        /// </summary>
        public ImGuiKeyData KeysData31;

        /// <summary>
        ///     The keys data 32
        /// </summary>
        public ImGuiKeyData KeysData32;

        /// <summary>
        ///     The keys data 33
        /// </summary>
        public ImGuiKeyData KeysData33;

        /// <summary>
        ///     The keys data 34
        /// </summary>
        public ImGuiKeyData KeysData34;

        /// <summary>
        ///     The keys data 35
        /// </summary>
        public ImGuiKeyData KeysData35;

        /// <summary>
        ///     The keys data 36
        /// </summary>
        public ImGuiKeyData KeysData36;

        /// <summary>
        ///     The keys data 37
        /// </summary>
        public ImGuiKeyData KeysData37;

        /// <summary>
        ///     The keys data 38
        /// </summary>
        public ImGuiKeyData KeysData38;

        /// <summary>
        ///     The keys data 39
        /// </summary>
        public ImGuiKeyData KeysData39;

        /// <summary>
        ///     The keys data 40
        /// </summary>
        public ImGuiKeyData KeysData40;

        /// <summary>
        ///     The keys data 41
        /// </summary>
        public ImGuiKeyData KeysData41;

        /// <summary>
        ///     The keys data 42
        /// </summary>
        public ImGuiKeyData KeysData42;

        /// <summary>
        ///     The keys data 43
        /// </summary>
        public ImGuiKeyData KeysData43;

        /// <summary>
        ///     The keys data 44
        /// </summary>
        public ImGuiKeyData KeysData44;

        /// <summary>
        ///     The keys data 45
        /// </summary>
        public ImGuiKeyData KeysData45;

        /// <summary>
        ///     The keys data 46
        /// </summary>
        public ImGuiKeyData KeysData46;

        /// <summary>
        ///     The keys data 47
        /// </summary>
        public ImGuiKeyData KeysData47;

        /// <summary>
        ///     The keys data 48
        /// </summary>
        public ImGuiKeyData KeysData48;

        /// <summary>
        ///     The keys data 49
        /// </summary>
        public ImGuiKeyData KeysData49;

        /// <summary>
        ///     The keys data 50
        /// </summary>
        public ImGuiKeyData KeysData50;

        /// <summary>
        ///     The keys data 51
        /// </summary>
        public ImGuiKeyData KeysData51;

        /// <summary>
        ///     The keys data 52
        /// </summary>
        public ImGuiKeyData KeysData52;

        /// <summary>
        ///     The keys data 53
        /// </summary>
        public ImGuiKeyData KeysData53;

        /// <summary>
        ///     The keys data 54
        /// </summary>
        public ImGuiKeyData KeysData54;

        /// <summary>
        ///     The keys data 55
        /// </summary>
        public ImGuiKeyData KeysData55;

        /// <summary>
        ///     The keys data 56
        /// </summary>
        public ImGuiKeyData KeysData56;

        /// <summary>
        ///     The keys data 57
        /// </summary>
        public ImGuiKeyData KeysData57;

        /// <summary>
        ///     The keys data 58
        /// </summary>
        public ImGuiKeyData KeysData58;

        /// <summary>
        ///     The keys data 59
        /// </summary>
        public ImGuiKeyData KeysData59;

        /// <summary>
        ///     The keys data 60
        /// </summary>
        public ImGuiKeyData KeysData60;

        /// <summary>
        ///     The keys data 61
        /// </summary>
        public ImGuiKeyData KeysData61;

        /// <summary>
        ///     The keys data 62
        /// </summary>
        public ImGuiKeyData KeysData62;

        /// <summary>
        ///     The keys data 63
        /// </summary>
        public ImGuiKeyData KeysData63;

        /// <summary>
        ///     The keys data 64
        /// </summary>
        public ImGuiKeyData KeysData64;

        /// <summary>
        ///     The keys data 65
        /// </summary>
        public ImGuiKeyData KeysData65;

        /// <summary>
        ///     The keys data 66
        /// </summary>
        public ImGuiKeyData KeysData66;

        /// <summary>
        ///     The keys data 67
        /// </summary>
        public ImGuiKeyData KeysData67;

        /// <summary>
        ///     The keys data 68
        /// </summary>
        public ImGuiKeyData KeysData68;

        /// <summary>
        ///     The keys data 69
        /// </summary>
        public ImGuiKeyData KeysData69;

        /// <summary>
        ///     The keys data 70
        /// </summary>
        public ImGuiKeyData KeysData70;

        /// <summary>
        ///     The keys data 71
        /// </summary>
        public ImGuiKeyData KeysData71;

        /// <summary>
        ///     The keys data 72
        /// </summary>
        public ImGuiKeyData KeysData72;

        /// <summary>
        ///     The keys data 73
        /// </summary>
        public ImGuiKeyData KeysData73;

        /// <summary>
        ///     The keys data 74
        /// </summary>
        public ImGuiKeyData KeysData74;

        /// <summary>
        ///     The keys data 75
        /// </summary>
        public ImGuiKeyData KeysData75;

        /// <summary>
        ///     The keys data 76
        /// </summary>
        public ImGuiKeyData KeysData76;

        /// <summary>
        ///     The keys data 77
        /// </summary>
        public ImGuiKeyData KeysData77;

        /// <summary>
        ///     The keys data 78
        /// </summary>
        public ImGuiKeyData KeysData78;

        /// <summary>
        ///     The keys data 79
        /// </summary>
        public ImGuiKeyData KeysData79;

        /// <summary>
        ///     The keys data 80
        /// </summary>
        public ImGuiKeyData KeysData80;

        /// <summary>
        ///     The keys data 81
        /// </summary>
        public ImGuiKeyData KeysData81;

        /// <summary>
        ///     The keys data 82
        /// </summary>
        public ImGuiKeyData KeysData82;

        /// <summary>
        ///     The keys data 83
        /// </summary>
        public ImGuiKeyData KeysData83;

        /// <summary>
        ///     The keys data 84
        /// </summary>
        public ImGuiKeyData KeysData84;

        /// <summary>
        ///     The keys data 85
        /// </summary>
        public ImGuiKeyData KeysData85;

        /// <summary>
        ///     The keys data 86
        /// </summary>
        public ImGuiKeyData KeysData86;

        /// <summary>
        ///     The keys data 87
        /// </summary>
        public ImGuiKeyData KeysData87;

        /// <summary>
        ///     The keys data 88
        /// </summary>
        public ImGuiKeyData KeysData88;

        /// <summary>
        ///     The keys data 89
        /// </summary>
        public ImGuiKeyData KeysData89;

        /// <summary>
        ///     The keys data 90
        /// </summary>
        public ImGuiKeyData KeysData90;

        /// <summary>
        ///     The keys data 91
        /// </summary>
        public ImGuiKeyData KeysData91;

        /// <summary>
        ///     The keys data 92
        /// </summary>
        public ImGuiKeyData KeysData92;

        /// <summary>
        ///     The keys data 93
        /// </summary>
        public ImGuiKeyData KeysData93;

        /// <summary>
        ///     The keys data 94
        /// </summary>
        public ImGuiKeyData KeysData94;

        /// <summary>
        ///     The keys data 95
        /// </summary>
        public ImGuiKeyData KeysData95;

        /// <summary>
        ///     The keys data 96
        /// </summary>
        public ImGuiKeyData KeysData96;

        /// <summary>
        ///     The keys data 97
        /// </summary>
        public ImGuiKeyData KeysData97;

        /// <summary>
        ///     The keys data 98
        /// </summary>
        public ImGuiKeyData KeysData98;

        /// <summary>
        ///     The keys data 99
        /// </summary>
        public ImGuiKeyData KeysData99;

        /// <summary>
        ///     The keys data 100
        /// </summary>
        public ImGuiKeyData KeysData100;

        /// <summary>
        ///     The keys data 101
        /// </summary>
        public ImGuiKeyData KeysData101;

        /// <summary>
        ///     The keys data 102
        /// </summary>
        public ImGuiKeyData KeysData102;

        /// <summary>
        ///     The keys data 103
        /// </summary>
        public ImGuiKeyData KeysData103;

        /// <summary>
        ///     The keys data 104
        /// </summary>
        public ImGuiKeyData KeysData104;

        /// <summary>
        ///     The keys data 105
        /// </summary>
        public ImGuiKeyData KeysData105;

        /// <summary>
        ///     The keys data 106
        /// </summary>
        public ImGuiKeyData KeysData106;

        /// <summary>
        ///     The keys data 107
        /// </summary>
        public ImGuiKeyData KeysData107;

        /// <summary>
        ///     The keys data 108
        /// </summary>
        public ImGuiKeyData KeysData108;

        /// <summary>
        ///     The keys data 109
        /// </summary>
        public ImGuiKeyData KeysData109;

        /// <summary>
        ///     The keys data 110
        /// </summary>
        public ImGuiKeyData KeysData110;

        /// <summary>
        ///     The keys data 111
        /// </summary>
        public ImGuiKeyData KeysData111;

        /// <summary>
        ///     The keys data 112
        /// </summary>
        public ImGuiKeyData KeysData112;

        /// <summary>
        ///     The keys data 113
        /// </summary>
        public ImGuiKeyData KeysData113;

        /// <summary>
        ///     The keys data 114
        /// </summary>
        public ImGuiKeyData KeysData114;

        /// <summary>
        ///     The keys data 115
        /// </summary>
        public ImGuiKeyData KeysData115;

        /// <summary>
        ///     The keys data 116
        /// </summary>
        public ImGuiKeyData KeysData116;

        /// <summary>
        ///     The keys data 117
        /// </summary>
        public ImGuiKeyData KeysData117;

        /// <summary>
        ///     The keys data 118
        /// </summary>
        public ImGuiKeyData KeysData118;

        /// <summary>
        ///     The keys data 119
        /// </summary>
        public ImGuiKeyData KeysData119;

        /// <summary>
        ///     The keys data 120
        /// </summary>
        public ImGuiKeyData KeysData120;

        /// <summary>
        ///     The keys data 121
        /// </summary>
        public ImGuiKeyData KeysData121;

        /// <summary>
        ///     The keys data 122
        /// </summary>
        public ImGuiKeyData KeysData122;

        /// <summary>
        ///     The keys data 123
        /// </summary>
        public ImGuiKeyData KeysData123;

        /// <summary>
        ///     The keys data 124
        /// </summary>
        public ImGuiKeyData KeysData124;

        /// <summary>
        ///     The keys data 125
        /// </summary>
        public ImGuiKeyData KeysData125;

        /// <summary>
        ///     The keys data 126
        /// </summary>
        public ImGuiKeyData KeysData126;

        /// <summary>
        ///     The keys data 127
        /// </summary>
        public ImGuiKeyData KeysData127;

        /// <summary>
        ///     The keys data 128
        /// </summary>
        public ImGuiKeyData KeysData128;

        /// <summary>
        ///     The keys data 129
        /// </summary>
        public ImGuiKeyData KeysData129;

        /// <summary>
        ///     The keys data 130
        /// </summary>
        public ImGuiKeyData KeysData130;

        /// <summary>
        ///     The keys data 131
        /// </summary>
        public ImGuiKeyData KeysData131;

        /// <summary>
        ///     The keys data 132
        /// </summary>
        public ImGuiKeyData KeysData132;

        /// <summary>
        ///     The keys data 133
        /// </summary>
        public ImGuiKeyData KeysData133;

        /// <summary>
        ///     The keys data 134
        /// </summary>
        public ImGuiKeyData KeysData134;

        /// <summary>
        ///     The keys data 135
        /// </summary>
        public ImGuiKeyData KeysData135;

        /// <summary>
        ///     The keys data 136
        /// </summary>
        public ImGuiKeyData KeysData136;

        /// <summary>
        ///     The keys data 137
        /// </summary>
        public ImGuiKeyData KeysData137;

        /// <summary>
        ///     The keys data 138
        /// </summary>
        public ImGuiKeyData KeysData138;

        /// <summary>
        ///     The keys data 139
        /// </summary>
        public ImGuiKeyData KeysData139;

        /// <summary>
        ///     The keys data 140
        /// </summary>
        public ImGuiKeyData KeysData140;

        /// <summary>
        ///     The keys data 141
        /// </summary>
        public ImGuiKeyData KeysData141;

        /// <summary>
        ///     The keys data 142
        /// </summary>
        public ImGuiKeyData KeysData142;

        /// <summary>
        ///     The keys data 143
        /// </summary>
        public ImGuiKeyData KeysData143;

        /// <summary>
        ///     The keys data 144
        /// </summary>
        public ImGuiKeyData KeysData144;

        /// <summary>
        ///     The keys data 145
        /// </summary>
        public ImGuiKeyData KeysData145;

        /// <summary>
        ///     The keys data 146
        /// </summary>
        public ImGuiKeyData KeysData146;

        /// <summary>
        ///     The keys data 147
        /// </summary>
        public ImGuiKeyData KeysData147;

        /// <summary>
        ///     The keys data 148
        /// </summary>
        public ImGuiKeyData KeysData148;

        /// <summary>
        ///     The keys data 149
        /// </summary>
        public ImGuiKeyData KeysData149;

        /// <summary>
        ///     The keys data 150
        /// </summary>
        public ImGuiKeyData KeysData150;

        /// <summary>
        ///     The keys data 151
        /// </summary>
        public ImGuiKeyData KeysData151;

        /// <summary>
        ///     The keys data 152
        /// </summary>
        public ImGuiKeyData KeysData152;

        /// <summary>
        ///     The keys data 153
        /// </summary>
        public ImGuiKeyData KeysData153;

        /// <summary>
        ///     The keys data 154
        /// </summary>
        public ImGuiKeyData KeysData154;

        /// <summary>
        ///     The keys data 155
        /// </summary>
        public ImGuiKeyData KeysData155;

        /// <summary>
        ///     The keys data 156
        /// </summary>
        public ImGuiKeyData KeysData156;

        /// <summary>
        ///     The keys data 157
        /// </summary>
        public ImGuiKeyData KeysData157;

        /// <summary>
        ///     The keys data 158
        /// </summary>
        public ImGuiKeyData KeysData158;

        /// <summary>
        ///     The keys data 159
        /// </summary>
        public ImGuiKeyData KeysData159;

        /// <summary>
        ///     The keys data 160
        /// </summary>
        public ImGuiKeyData KeysData160;

        /// <summary>
        ///     The keys data 161
        /// </summary>
        public ImGuiKeyData KeysData161;

        /// <summary>
        ///     The keys data 162
        /// </summary>
        public ImGuiKeyData KeysData162;

        /// <summary>
        ///     The keys data 163
        /// </summary>
        public ImGuiKeyData KeysData163;

        /// <summary>
        ///     The keys data 164
        /// </summary>
        public ImGuiKeyData KeysData164;

        /// <summary>
        ///     The keys data 165
        /// </summary>
        public ImGuiKeyData KeysData165;

        /// <summary>
        ///     The keys data 166
        /// </summary>
        public ImGuiKeyData KeysData166;

        /// <summary>
        ///     The keys data 167
        /// </summary>
        public ImGuiKeyData KeysData167;

        /// <summary>
        ///     The keys data 168
        /// </summary>
        public ImGuiKeyData KeysData168;

        /// <summary>
        ///     The keys data 169
        /// </summary>
        public ImGuiKeyData KeysData169;

        /// <summary>
        ///     The keys data 170
        /// </summary>
        public ImGuiKeyData KeysData170;

        /// <summary>
        ///     The keys data 171
        /// </summary>
        public ImGuiKeyData KeysData171;

        /// <summary>
        ///     The keys data 172
        /// </summary>
        public ImGuiKeyData KeysData172;

        /// <summary>
        ///     The keys data 173
        /// </summary>
        public ImGuiKeyData KeysData173;

        /// <summary>
        ///     The keys data 174
        /// </summary>
        public ImGuiKeyData KeysData174;

        /// <summary>
        ///     The keys data 175
        /// </summary>
        public ImGuiKeyData KeysData175;

        /// <summary>
        ///     The keys data 176
        /// </summary>
        public ImGuiKeyData KeysData176;

        /// <summary>
        ///     The keys data 177
        /// </summary>
        public ImGuiKeyData KeysData177;

        /// <summary>
        ///     The keys data 178
        /// </summary>
        public ImGuiKeyData KeysData178;

        /// <summary>
        ///     The keys data 179
        /// </summary>
        public ImGuiKeyData KeysData179;

        /// <summary>
        ///     The keys data 180
        /// </summary>
        public ImGuiKeyData KeysData180;

        /// <summary>
        ///     The keys data 181
        /// </summary>
        public ImGuiKeyData KeysData181;

        /// <summary>
        ///     The keys data 182
        /// </summary>
        public ImGuiKeyData KeysData182;

        /// <summary>
        ///     The keys data 183
        /// </summary>
        public ImGuiKeyData KeysData183;

        /// <summary>
        ///     The keys data 184
        /// </summary>
        public ImGuiKeyData KeysData184;

        /// <summary>
        ///     The keys data 185
        /// </summary>
        public ImGuiKeyData KeysData185;

        /// <summary>
        ///     The keys data 186
        /// </summary>
        public ImGuiKeyData KeysData186;

        /// <summary>
        ///     The keys data 187
        /// </summary>
        public ImGuiKeyData KeysData187;

        /// <summary>
        ///     The keys data 188
        /// </summary>
        public ImGuiKeyData KeysData188;

        /// <summary>
        ///     The keys data 189
        /// </summary>
        public ImGuiKeyData KeysData189;

        /// <summary>
        ///     The keys data 190
        /// </summary>
        public ImGuiKeyData KeysData190;

        /// <summary>
        ///     The keys data 191
        /// </summary>
        public ImGuiKeyData KeysData191;

        /// <summary>
        ///     The keys data 192
        /// </summary>
        public ImGuiKeyData KeysData192;

        /// <summary>
        ///     The keys data 193
        /// </summary>
        public ImGuiKeyData KeysData193;

        /// <summary>
        ///     The keys data 194
        /// </summary>
        public ImGuiKeyData KeysData194;

        /// <summary>
        ///     The keys data 195
        /// </summary>
        public ImGuiKeyData KeysData195;

        /// <summary>
        ///     The keys data 196
        /// </summary>
        public ImGuiKeyData KeysData196;

        /// <summary>
        ///     The keys data 197
        /// </summary>
        public ImGuiKeyData KeysData197;

        /// <summary>
        ///     The keys data 198
        /// </summary>
        public ImGuiKeyData KeysData198;

        /// <summary>
        ///     The keys data 199
        /// </summary>
        public ImGuiKeyData KeysData199;

        /// <summary>
        ///     The keys data 200
        /// </summary>
        public ImGuiKeyData KeysData200;

        /// <summary>
        ///     The keys data 201
        /// </summary>
        public ImGuiKeyData KeysData201;

        /// <summary>
        ///     The keys data 202
        /// </summary>
        public ImGuiKeyData KeysData202;

        /// <summary>
        ///     The keys data 203
        /// </summary>
        public ImGuiKeyData KeysData203;

        /// <summary>
        ///     The keys data 204
        /// </summary>
        public ImGuiKeyData KeysData204;

        /// <summary>
        ///     The keys data 205
        /// </summary>
        public ImGuiKeyData KeysData205;

        /// <summary>
        ///     The keys data 206
        /// </summary>
        public ImGuiKeyData KeysData206;

        /// <summary>
        ///     The keys data 207
        /// </summary>
        public ImGuiKeyData KeysData207;

        /// <summary>
        ///     The keys data 208
        /// </summary>
        public ImGuiKeyData KeysData208;

        /// <summary>
        ///     The keys data 209
        /// </summary>
        public ImGuiKeyData KeysData209;

        /// <summary>
        ///     The keys data 210
        /// </summary>
        public ImGuiKeyData KeysData210;

        /// <summary>
        ///     The keys data 211
        /// </summary>
        public ImGuiKeyData KeysData211;

        /// <summary>
        ///     The keys data 212
        /// </summary>
        public ImGuiKeyData KeysData212;

        /// <summary>
        ///     The keys data 213
        /// </summary>
        public ImGuiKeyData KeysData213;

        /// <summary>
        ///     The keys data 214
        /// </summary>
        public ImGuiKeyData KeysData214;

        /// <summary>
        ///     The keys data 215
        /// </summary>
        public ImGuiKeyData KeysData215;

        /// <summary>
        ///     The keys data 216
        /// </summary>
        public ImGuiKeyData KeysData216;

        /// <summary>
        ///     The keys data 217
        /// </summary>
        public ImGuiKeyData KeysData217;

        /// <summary>
        ///     The keys data 218
        /// </summary>
        public ImGuiKeyData KeysData218;

        /// <summary>
        ///     The keys data 219
        /// </summary>
        public ImGuiKeyData KeysData219;

        /// <summary>
        ///     The keys data 220
        /// </summary>
        public ImGuiKeyData KeysData220;

        /// <summary>
        ///     The keys data 221
        /// </summary>
        public ImGuiKeyData KeysData221;

        /// <summary>
        ///     The keys data 222
        /// </summary>
        public ImGuiKeyData KeysData222;

        /// <summary>
        ///     The keys data 223
        /// </summary>
        public ImGuiKeyData KeysData223;

        /// <summary>
        ///     The keys data 224
        /// </summary>
        public ImGuiKeyData KeysData224;

        /// <summary>
        ///     The keys data 225
        /// </summary>
        public ImGuiKeyData KeysData225;

        /// <summary>
        ///     The keys data 226
        /// </summary>
        public ImGuiKeyData KeysData226;

        /// <summary>
        ///     The keys data 227
        /// </summary>
        public ImGuiKeyData KeysData227;

        /// <summary>
        ///     The keys data 228
        /// </summary>
        public ImGuiKeyData KeysData228;

        /// <summary>
        ///     The keys data 229
        /// </summary>
        public ImGuiKeyData KeysData229;

        /// <summary>
        ///     The keys data 230
        /// </summary>
        public ImGuiKeyData KeysData230;

        /// <summary>
        ///     The keys data 231
        /// </summary>
        public ImGuiKeyData KeysData231;

        /// <summary>
        ///     The keys data 232
        /// </summary>
        public ImGuiKeyData KeysData232;

        /// <summary>
        ///     The keys data 233
        /// </summary>
        public ImGuiKeyData KeysData233;

        /// <summary>
        ///     The keys data 234
        /// </summary>
        public ImGuiKeyData KeysData234;

        /// <summary>
        ///     The keys data 235
        /// </summary>
        public ImGuiKeyData KeysData235;

        /// <summary>
        ///     The keys data 236
        /// </summary>
        public ImGuiKeyData KeysData236;

        /// <summary>
        ///     The keys data 237
        /// </summary>
        public ImGuiKeyData KeysData237;

        /// <summary>
        ///     The keys data 238
        /// </summary>
        public ImGuiKeyData KeysData238;

        /// <summary>
        ///     The keys data 239
        /// </summary>
        public ImGuiKeyData KeysData239;

        /// <summary>
        ///     The keys data 240
        /// </summary>
        public ImGuiKeyData KeysData240;

        /// <summary>
        ///     The keys data 241
        /// </summary>
        public ImGuiKeyData KeysData241;

        /// <summary>
        ///     The keys data 242
        /// </summary>
        public ImGuiKeyData KeysData242;

        /// <summary>
        ///     The keys data 243
        /// </summary>
        public ImGuiKeyData KeysData243;

        /// <summary>
        ///     The keys data 244
        /// </summary>
        public ImGuiKeyData KeysData244;

        /// <summary>
        ///     The keys data 245
        /// </summary>
        public ImGuiKeyData KeysData245;

        /// <summary>
        ///     The keys data 246
        /// </summary>
        public ImGuiKeyData KeysData246;

        /// <summary>
        ///     The keys data 247
        /// </summary>
        public ImGuiKeyData KeysData247;

        /// <summary>
        ///     The keys data 248
        /// </summary>
        public ImGuiKeyData KeysData248;

        /// <summary>
        ///     The keys data 249
        /// </summary>
        public ImGuiKeyData KeysData249;

        /// <summary>
        ///     The keys data 250
        /// </summary>
        public ImGuiKeyData KeysData250;

        /// <summary>
        ///     The keys data 251
        /// </summary>
        public ImGuiKeyData KeysData251;

        /// <summary>
        ///     The keys data 252
        /// </summary>
        public ImGuiKeyData KeysData252;

        /// <summary>
        ///     The keys data 253
        /// </summary>
        public ImGuiKeyData KeysData253;

        /// <summary>
        ///     The keys data 254
        /// </summary>
        public ImGuiKeyData KeysData254;

        /// <summary>
        ///     The keys data 255
        /// </summary>
        public ImGuiKeyData KeysData255;

        /// <summary>
        ///     The keys data 256
        /// </summary>
        public ImGuiKeyData KeysData256;

        /// <summary>
        ///     The keys data 257
        /// </summary>
        public ImGuiKeyData KeysData257;

        /// <summary>
        ///     The keys data 258
        /// </summary>
        public ImGuiKeyData KeysData258;

        /// <summary>
        ///     The keys data 259
        /// </summary>
        public ImGuiKeyData KeysData259;

        /// <summary>
        ///     The keys data 260
        /// </summary>
        public ImGuiKeyData KeysData260;

        /// <summary>
        ///     The keys data 261
        /// </summary>
        public ImGuiKeyData KeysData261;

        /// <summary>
        ///     The keys data 262
        /// </summary>
        public ImGuiKeyData KeysData262;

        /// <summary>
        ///     The keys data 263
        /// </summary>
        public ImGuiKeyData KeysData263;

        /// <summary>
        ///     The keys data 264
        /// </summary>
        public ImGuiKeyData KeysData264;

        /// <summary>
        ///     The keys data 265
        /// </summary>
        public ImGuiKeyData KeysData265;

        /// <summary>
        ///     The keys data 266
        /// </summary>
        public ImGuiKeyData KeysData266;

        /// <summary>
        ///     The keys data 267
        /// </summary>
        public ImGuiKeyData KeysData267;

        /// <summary>
        ///     The keys data 268
        /// </summary>
        public ImGuiKeyData KeysData268;

        /// <summary>
        ///     The keys data 269
        /// </summary>
        public ImGuiKeyData KeysData269;

        /// <summary>
        ///     The keys data 270
        /// </summary>
        public ImGuiKeyData KeysData270;

        /// <summary>
        ///     The keys data 271
        /// </summary>
        public ImGuiKeyData KeysData271;

        /// <summary>
        ///     The keys data 272
        /// </summary>
        public ImGuiKeyData KeysData272;

        /// <summary>
        ///     The keys data 273
        /// </summary>
        public ImGuiKeyData KeysData273;

        /// <summary>
        ///     The keys data 274
        /// </summary>
        public ImGuiKeyData KeysData274;

        /// <summary>
        ///     The keys data 275
        /// </summary>
        public ImGuiKeyData KeysData275;

        /// <summary>
        ///     The keys data 276
        /// </summary>
        public ImGuiKeyData KeysData276;

        /// <summary>
        ///     The keys data 277
        /// </summary>
        public ImGuiKeyData KeysData277;

        /// <summary>
        ///     The keys data 278
        /// </summary>
        public ImGuiKeyData KeysData278;

        /// <summary>
        ///     The keys data 279
        /// </summary>
        public ImGuiKeyData KeysData279;

        /// <summary>
        ///     The keys data 280
        /// </summary>
        public ImGuiKeyData KeysData280;

        /// <summary>
        ///     The keys data 281
        /// </summary>
        public ImGuiKeyData KeysData281;

        /// <summary>
        ///     The keys data 282
        /// </summary>
        public ImGuiKeyData KeysData282;

        /// <summary>
        ///     The keys data 283
        /// </summary>
        public ImGuiKeyData KeysData283;

        /// <summary>
        ///     The keys data 284
        /// </summary>
        public ImGuiKeyData KeysData284;

        /// <summary>
        ///     The keys data 285
        /// </summary>
        public ImGuiKeyData KeysData285;

        /// <summary>
        ///     The keys data 286
        /// </summary>
        public ImGuiKeyData KeysData286;

        /// <summary>
        ///     The keys data 287
        /// </summary>
        public ImGuiKeyData KeysData287;

        /// <summary>
        ///     The keys data 288
        /// </summary>
        public ImGuiKeyData KeysData288;

        /// <summary>
        ///     The keys data 289
        /// </summary>
        public ImGuiKeyData KeysData289;

        /// <summary>
        ///     The keys data 290
        /// </summary>
        public ImGuiKeyData KeysData290;

        /// <summary>
        ///     The keys data 291
        /// </summary>
        public ImGuiKeyData KeysData291;

        /// <summary>
        ///     The keys data 292
        /// </summary>
        public ImGuiKeyData KeysData292;

        /// <summary>
        ///     The keys data 293
        /// </summary>
        public ImGuiKeyData KeysData293;

        /// <summary>
        ///     The keys data 294
        /// </summary>
        public ImGuiKeyData KeysData294;

        /// <summary>
        ///     The keys data 295
        /// </summary>
        public ImGuiKeyData KeysData295;

        /// <summary>
        ///     The keys data 296
        /// </summary>
        public ImGuiKeyData KeysData296;

        /// <summary>
        ///     The keys data 297
        /// </summary>
        public ImGuiKeyData KeysData297;

        /// <summary>
        ///     The keys data 298
        /// </summary>
        public ImGuiKeyData KeysData298;

        /// <summary>
        ///     The keys data 299
        /// </summary>
        public ImGuiKeyData KeysData299;

        /// <summary>
        ///     The keys data 300
        /// </summary>
        public ImGuiKeyData KeysData300;

        /// <summary>
        ///     The keys data 301
        /// </summary>
        public ImGuiKeyData KeysData301;

        /// <summary>
        ///     The keys data 302
        /// </summary>
        public ImGuiKeyData KeysData302;

        /// <summary>
        ///     The keys data 303
        /// </summary>
        public ImGuiKeyData KeysData303;

        /// <summary>
        ///     The keys data 304
        /// </summary>
        public ImGuiKeyData KeysData304;

        /// <summary>
        ///     The keys data 305
        /// </summary>
        public ImGuiKeyData KeysData305;

        /// <summary>
        ///     The keys data 306
        /// </summary>
        public ImGuiKeyData KeysData306;

        /// <summary>
        ///     The keys data 307
        /// </summary>
        public ImGuiKeyData KeysData307;

        /// <summary>
        ///     The keys data 308
        /// </summary>
        public ImGuiKeyData KeysData308;

        /// <summary>
        ///     The keys data 309
        /// </summary>
        public ImGuiKeyData KeysData309;

        /// <summary>
        ///     The keys data 310
        /// </summary>
        public ImGuiKeyData KeysData310;

        /// <summary>
        ///     The keys data 311
        /// </summary>
        public ImGuiKeyData KeysData311;

        /// <summary>
        ///     The keys data 312
        /// </summary>
        public ImGuiKeyData KeysData312;

        /// <summary>
        ///     The keys data 313
        /// </summary>
        public ImGuiKeyData KeysData313;

        /// <summary>
        ///     The keys data 314
        /// </summary>
        public ImGuiKeyData KeysData314;

        /// <summary>
        ///     The keys data 315
        /// </summary>
        public ImGuiKeyData KeysData315;

        /// <summary>
        ///     The keys data 316
        /// </summary>
        public ImGuiKeyData KeysData316;

        /// <summary>
        ///     The keys data 317
        /// </summary>
        public ImGuiKeyData KeysData317;

        /// <summary>
        ///     The keys data 318
        /// </summary>
        public ImGuiKeyData KeysData318;

        /// <summary>
        ///     The keys data 319
        /// </summary>
        public ImGuiKeyData KeysData319;

        /// <summary>
        ///     The keys data 320
        /// </summary>
        public ImGuiKeyData KeysData320;

        /// <summary>
        ///     The keys data 321
        /// </summary>
        public ImGuiKeyData KeysData321;

        /// <summary>
        ///     The keys data 322
        /// </summary>
        public ImGuiKeyData KeysData322;

        /// <summary>
        ///     The keys data 323
        /// </summary>
        public ImGuiKeyData KeysData323;

        /// <summary>
        ///     The keys data 324
        /// </summary>
        public ImGuiKeyData KeysData324;

        /// <summary>
        ///     The keys data 325
        /// </summary>
        public ImGuiKeyData KeysData325;

        /// <summary>
        ///     The keys data 326
        /// </summary>
        public ImGuiKeyData KeysData326;

        /// <summary>
        ///     The keys data 327
        /// </summary>
        public ImGuiKeyData KeysData327;

        /// <summary>
        ///     The keys data 328
        /// </summary>
        public ImGuiKeyData KeysData328;

        /// <summary>
        ///     The keys data 329
        /// </summary>
        public ImGuiKeyData KeysData329;

        /// <summary>
        ///     The keys data 330
        /// </summary>
        public ImGuiKeyData KeysData330;

        /// <summary>
        ///     The keys data 331
        /// </summary>
        public ImGuiKeyData KeysData331;

        /// <summary>
        ///     The keys data 332
        /// </summary>
        public ImGuiKeyData KeysData332;

        /// <summary>
        ///     The keys data 333
        /// </summary>
        public ImGuiKeyData KeysData333;

        /// <summary>
        ///     The keys data 334
        /// </summary>
        public ImGuiKeyData KeysData334;

        /// <summary>
        ///     The keys data 335
        /// </summary>
        public ImGuiKeyData KeysData335;

        /// <summary>
        ///     The keys data 336
        /// </summary>
        public ImGuiKeyData KeysData336;

        /// <summary>
        ///     The keys data 337
        /// </summary>
        public ImGuiKeyData KeysData337;

        /// <summary>
        ///     The keys data 338
        /// </summary>
        public ImGuiKeyData KeysData338;

        /// <summary>
        ///     The keys data 339
        /// </summary>
        public ImGuiKeyData KeysData339;

        /// <summary>
        ///     The keys data 340
        /// </summary>
        public ImGuiKeyData KeysData340;

        /// <summary>
        ///     The keys data 341
        /// </summary>
        public ImGuiKeyData KeysData341;

        /// <summary>
        ///     The keys data 342
        /// </summary>
        public ImGuiKeyData KeysData342;

        /// <summary>
        ///     The keys data 343
        /// </summary>
        public ImGuiKeyData KeysData343;

        /// <summary>
        ///     The keys data 344
        /// </summary>
        public ImGuiKeyData KeysData344;

        /// <summary>
        ///     The keys data 345
        /// </summary>
        public ImGuiKeyData KeysData345;

        /// <summary>
        ///     The keys data 346
        /// </summary>
        public ImGuiKeyData KeysData346;

        /// <summary>
        ///     The keys data 347
        /// </summary>
        public ImGuiKeyData KeysData347;

        /// <summary>
        ///     The keys data 348
        /// </summary>
        public ImGuiKeyData KeysData348;

        /// <summary>
        ///     The keys data 349
        /// </summary>
        public ImGuiKeyData KeysData349;

        /// <summary>
        ///     The keys data 350
        /// </summary>
        public ImGuiKeyData KeysData350;

        /// <summary>
        ///     The keys data 351
        /// </summary>
        public ImGuiKeyData KeysData351;

        /// <summary>
        ///     The keys data 352
        /// </summary>
        public ImGuiKeyData KeysData352;

        /// <summary>
        ///     The keys data 353
        /// </summary>
        public ImGuiKeyData KeysData353;

        /// <summary>
        ///     The keys data 354
        /// </summary>
        public ImGuiKeyData KeysData354;

        /// <summary>
        ///     The keys data 355
        /// </summary>
        public ImGuiKeyData KeysData355;

        /// <summary>
        ///     The keys data 356
        /// </summary>
        public ImGuiKeyData KeysData356;

        /// <summary>
        ///     The keys data 357
        /// </summary>
        public ImGuiKeyData KeysData357;

        /// <summary>
        ///     The keys data 358
        /// </summary>
        public ImGuiKeyData KeysData358;

        /// <summary>
        ///     The keys data 359
        /// </summary>
        public ImGuiKeyData KeysData359;

        /// <summary>
        ///     The keys data 360
        /// </summary>
        public ImGuiKeyData KeysData360;

        /// <summary>
        ///     The keys data 361
        /// </summary>
        public ImGuiKeyData KeysData361;

        /// <summary>
        ///     The keys data 362
        /// </summary>
        public ImGuiKeyData KeysData362;

        /// <summary>
        ///     The keys data 363
        /// </summary>
        public ImGuiKeyData KeysData363;

        /// <summary>
        ///     The keys data 364
        /// </summary>
        public ImGuiKeyData KeysData364;

        /// <summary>
        ///     The keys data 365
        /// </summary>
        public ImGuiKeyData KeysData365;

        /// <summary>
        ///     The keys data 366
        /// </summary>
        public ImGuiKeyData KeysData366;

        /// <summary>
        ///     The keys data 367
        /// </summary>
        public ImGuiKeyData KeysData367;

        /// <summary>
        ///     The keys data 368
        /// </summary>
        public ImGuiKeyData KeysData368;

        /// <summary>
        ///     The keys data 369
        /// </summary>
        public ImGuiKeyData KeysData369;

        /// <summary>
        ///     The keys data 370
        /// </summary>
        public ImGuiKeyData KeysData370;

        /// <summary>
        ///     The keys data 371
        /// </summary>
        public ImGuiKeyData KeysData371;

        /// <summary>
        ///     The keys data 372
        /// </summary>
        public ImGuiKeyData KeysData372;

        /// <summary>
        ///     The keys data 373
        /// </summary>
        public ImGuiKeyData KeysData373;

        /// <summary>
        ///     The keys data 374
        /// </summary>
        public ImGuiKeyData KeysData374;

        /// <summary>
        ///     The keys data 375
        /// </summary>
        public ImGuiKeyData KeysData375;

        /// <summary>
        ///     The keys data 376
        /// </summary>
        public ImGuiKeyData KeysData376;

        /// <summary>
        ///     The keys data 377
        /// </summary>
        public ImGuiKeyData KeysData377;

        /// <summary>
        ///     The keys data 378
        /// </summary>
        public ImGuiKeyData KeysData378;

        /// <summary>
        ///     The keys data 379
        /// </summary>
        public ImGuiKeyData KeysData379;

        /// <summary>
        ///     The keys data 380
        /// </summary>
        public ImGuiKeyData KeysData380;

        /// <summary>
        ///     The keys data 381
        /// </summary>
        public ImGuiKeyData KeysData381;

        /// <summary>
        ///     The keys data 382
        /// </summary>
        public ImGuiKeyData KeysData382;

        /// <summary>
        ///     The keys data 383
        /// </summary>
        public ImGuiKeyData KeysData383;

        /// <summary>
        ///     The keys data 384
        /// </summary>
        public ImGuiKeyData KeysData384;

        /// <summary>
        ///     The keys data 385
        /// </summary>
        public ImGuiKeyData KeysData385;

        /// <summary>
        ///     The keys data 386
        /// </summary>
        public ImGuiKeyData KeysData386;

        /// <summary>
        ///     The keys data 387
        /// </summary>
        public ImGuiKeyData KeysData387;

        /// <summary>
        ///     The keys data 388
        /// </summary>
        public ImGuiKeyData KeysData388;

        /// <summary>
        ///     The keys data 389
        /// </summary>
        public ImGuiKeyData KeysData389;

        /// <summary>
        ///     The keys data 390
        /// </summary>
        public ImGuiKeyData KeysData390;

        /// <summary>
        ///     The keys data 391
        /// </summary>
        public ImGuiKeyData KeysData391;

        /// <summary>
        ///     The keys data 392
        /// </summary>
        public ImGuiKeyData KeysData392;

        /// <summary>
        ///     The keys data 393
        /// </summary>
        public ImGuiKeyData KeysData393;

        /// <summary>
        ///     The keys data 394
        /// </summary>
        public ImGuiKeyData KeysData394;

        /// <summary>
        ///     The keys data 395
        /// </summary>
        public ImGuiKeyData KeysData395;

        /// <summary>
        ///     The keys data 396
        /// </summary>
        public ImGuiKeyData KeysData396;

        /// <summary>
        ///     The keys data 397
        /// </summary>
        public ImGuiKeyData KeysData397;

        /// <summary>
        ///     The keys data 398
        /// </summary>
        public ImGuiKeyData KeysData398;

        /// <summary>
        ///     The keys data 399
        /// </summary>
        public ImGuiKeyData KeysData399;

        /// <summary>
        ///     The keys data 400
        /// </summary>
        public ImGuiKeyData KeysData400;

        /// <summary>
        ///     The keys data 401
        /// </summary>
        public ImGuiKeyData KeysData401;

        /// <summary>
        ///     The keys data 402
        /// </summary>
        public ImGuiKeyData KeysData402;

        /// <summary>
        ///     The keys data 403
        /// </summary>
        public ImGuiKeyData KeysData403;

        /// <summary>
        ///     The keys data 404
        /// </summary>
        public ImGuiKeyData KeysData404;

        /// <summary>
        ///     The keys data 405
        /// </summary>
        public ImGuiKeyData KeysData405;

        /// <summary>
        ///     The keys data 406
        /// </summary>
        public ImGuiKeyData KeysData406;

        /// <summary>
        ///     The keys data 407
        /// </summary>
        public ImGuiKeyData KeysData407;

        /// <summary>
        ///     The keys data 408
        /// </summary>
        public ImGuiKeyData KeysData408;

        /// <summary>
        ///     The keys data 409
        /// </summary>
        public ImGuiKeyData KeysData409;

        /// <summary>
        ///     The keys data 410
        /// </summary>
        public ImGuiKeyData KeysData410;

        /// <summary>
        ///     The keys data 411
        /// </summary>
        public ImGuiKeyData KeysData411;

        /// <summary>
        ///     The keys data 412
        /// </summary>
        public ImGuiKeyData KeysData412;

        /// <summary>
        ///     The keys data 413
        /// </summary>
        public ImGuiKeyData KeysData413;

        /// <summary>
        ///     The keys data 414
        /// </summary>
        public ImGuiKeyData KeysData414;

        /// <summary>
        ///     The keys data 415
        /// </summary>
        public ImGuiKeyData KeysData415;

        /// <summary>
        ///     The keys data 416
        /// </summary>
        public ImGuiKeyData KeysData416;

        /// <summary>
        ///     The keys data 417
        /// </summary>
        public ImGuiKeyData KeysData417;

        /// <summary>
        ///     The keys data 418
        /// </summary>
        public ImGuiKeyData KeysData418;

        /// <summary>
        ///     The keys data 419
        /// </summary>
        public ImGuiKeyData KeysData419;

        /// <summary>
        ///     The keys data 420
        /// </summary>
        public ImGuiKeyData KeysData420;

        /// <summary>
        ///     The keys data 421
        /// </summary>
        public ImGuiKeyData KeysData421;

        /// <summary>
        ///     The keys data 422
        /// </summary>
        public ImGuiKeyData KeysData422;

        /// <summary>
        ///     The keys data 423
        /// </summary>
        public ImGuiKeyData KeysData423;

        /// <summary>
        ///     The keys data 424
        /// </summary>
        public ImGuiKeyData KeysData424;

        /// <summary>
        ///     The keys data 425
        /// </summary>
        public ImGuiKeyData KeysData425;

        /// <summary>
        ///     The keys data 426
        /// </summary>
        public ImGuiKeyData KeysData426;

        /// <summary>
        ///     The keys data 427
        /// </summary>
        public ImGuiKeyData KeysData427;

        /// <summary>
        ///     The keys data 428
        /// </summary>
        public ImGuiKeyData KeysData428;

        /// <summary>
        ///     The keys data 429
        /// </summary>
        public ImGuiKeyData KeysData429;

        /// <summary>
        ///     The keys data 430
        /// </summary>
        public ImGuiKeyData KeysData430;

        /// <summary>
        ///     The keys data 431
        /// </summary>
        public ImGuiKeyData KeysData431;

        /// <summary>
        ///     The keys data 432
        /// </summary>
        public ImGuiKeyData KeysData432;

        /// <summary>
        ///     The keys data 433
        /// </summary>
        public ImGuiKeyData KeysData433;

        /// <summary>
        ///     The keys data 434
        /// </summary>
        public ImGuiKeyData KeysData434;

        /// <summary>
        ///     The keys data 435
        /// </summary>
        public ImGuiKeyData KeysData435;

        /// <summary>
        ///     The keys data 436
        /// </summary>
        public ImGuiKeyData KeysData436;

        /// <summary>
        ///     The keys data 437
        /// </summary>
        public ImGuiKeyData KeysData437;

        /// <summary>
        ///     The keys data 438
        /// </summary>
        public ImGuiKeyData KeysData438;

        /// <summary>
        ///     The keys data 439
        /// </summary>
        public ImGuiKeyData KeysData439;

        /// <summary>
        ///     The keys data 440
        /// </summary>
        public ImGuiKeyData KeysData440;

        /// <summary>
        ///     The keys data 441
        /// </summary>
        public ImGuiKeyData KeysData441;

        /// <summary>
        ///     The keys data 442
        /// </summary>
        public ImGuiKeyData KeysData442;

        /// <summary>
        ///     The keys data 443
        /// </summary>
        public ImGuiKeyData KeysData443;

        /// <summary>
        ///     The keys data 444
        /// </summary>
        public ImGuiKeyData KeysData444;

        /// <summary>
        ///     The keys data 445
        /// </summary>
        public ImGuiKeyData KeysData445;

        /// <summary>
        ///     The keys data 446
        /// </summary>
        public ImGuiKeyData KeysData446;

        /// <summary>
        ///     The keys data 447
        /// </summary>
        public ImGuiKeyData KeysData447;

        /// <summary>
        ///     The keys data 448
        /// </summary>
        public ImGuiKeyData KeysData448;

        /// <summary>
        ///     The keys data 449
        /// </summary>
        public ImGuiKeyData KeysData449;

        /// <summary>
        ///     The keys data 450
        /// </summary>
        public ImGuiKeyData KeysData450;

        /// <summary>
        ///     The keys data 451
        /// </summary>
        public ImGuiKeyData KeysData451;

        /// <summary>
        ///     The keys data 452
        /// </summary>
        public ImGuiKeyData KeysData452;

        /// <summary>
        ///     The keys data 453
        /// </summary>
        public ImGuiKeyData KeysData453;

        /// <summary>
        ///     The keys data 454
        /// </summary>
        public ImGuiKeyData KeysData454;

        /// <summary>
        ///     The keys data 455
        /// </summary>
        public ImGuiKeyData KeysData455;

        /// <summary>
        ///     The keys data 456
        /// </summary>
        public ImGuiKeyData KeysData456;

        /// <summary>
        ///     The keys data 457
        /// </summary>
        public ImGuiKeyData KeysData457;

        /// <summary>
        ///     The keys data 458
        /// </summary>
        public ImGuiKeyData KeysData458;

        /// <summary>
        ///     The keys data 459
        /// </summary>
        public ImGuiKeyData KeysData459;

        /// <summary>
        ///     The keys data 460
        /// </summary>
        public ImGuiKeyData KeysData460;

        /// <summary>
        ///     The keys data 461
        /// </summary>
        public ImGuiKeyData KeysData461;

        /// <summary>
        ///     The keys data 462
        /// </summary>
        public ImGuiKeyData KeysData462;

        /// <summary>
        ///     The keys data 463
        /// </summary>
        public ImGuiKeyData KeysData463;

        /// <summary>
        ///     The keys data 464
        /// </summary>
        public ImGuiKeyData KeysData464;

        /// <summary>
        ///     The keys data 465
        /// </summary>
        public ImGuiKeyData KeysData465;

        /// <summary>
        ///     The keys data 466
        /// </summary>
        public ImGuiKeyData KeysData466;

        /// <summary>
        ///     The keys data 467
        /// </summary>
        public ImGuiKeyData KeysData467;

        /// <summary>
        ///     The keys data 468
        /// </summary>
        public ImGuiKeyData KeysData468;

        /// <summary>
        ///     The keys data 469
        /// </summary>
        public ImGuiKeyData KeysData469;

        /// <summary>
        ///     The keys data 470
        /// </summary>
        public ImGuiKeyData KeysData470;

        /// <summary>
        ///     The keys data 471
        /// </summary>
        public ImGuiKeyData KeysData471;

        /// <summary>
        ///     The keys data 472
        /// </summary>
        public ImGuiKeyData KeysData472;

        /// <summary>
        ///     The keys data 473
        /// </summary>
        public ImGuiKeyData KeysData473;

        /// <summary>
        ///     The keys data 474
        /// </summary>
        public ImGuiKeyData KeysData474;

        /// <summary>
        ///     The keys data 475
        /// </summary>
        public ImGuiKeyData KeysData475;

        /// <summary>
        ///     The keys data 476
        /// </summary>
        public ImGuiKeyData KeysData476;

        /// <summary>
        ///     The keys data 477
        /// </summary>
        public ImGuiKeyData KeysData477;

        /// <summary>
        ///     The keys data 478
        /// </summary>
        public ImGuiKeyData KeysData478;

        /// <summary>
        ///     The keys data 479
        /// </summary>
        public ImGuiKeyData KeysData479;

        /// <summary>
        ///     The keys data 480
        /// </summary>
        public ImGuiKeyData KeysData480;

        /// <summary>
        ///     The keys data 481
        /// </summary>
        public ImGuiKeyData KeysData481;

        /// <summary>
        ///     The keys data 482
        /// </summary>
        public ImGuiKeyData KeysData482;

        /// <summary>
        ///     The keys data 483
        /// </summary>
        public ImGuiKeyData KeysData483;

        /// <summary>
        ///     The keys data 484
        /// </summary>
        public ImGuiKeyData KeysData484;

        /// <summary>
        ///     The keys data 485
        /// </summary>
        public ImGuiKeyData KeysData485;

        /// <summary>
        ///     The keys data 486
        /// </summary>
        public ImGuiKeyData KeysData486;

        /// <summary>
        ///     The keys data 487
        /// </summary>
        public ImGuiKeyData KeysData487;

        /// <summary>
        ///     The keys data 488
        /// </summary>
        public ImGuiKeyData KeysData488;

        /// <summary>
        ///     The keys data 489
        /// </summary>
        public ImGuiKeyData KeysData489;

        /// <summary>
        ///     The keys data 490
        /// </summary>
        public ImGuiKeyData KeysData490;

        /// <summary>
        ///     The keys data 491
        /// </summary>
        public ImGuiKeyData KeysData491;

        /// <summary>
        ///     The keys data 492
        /// </summary>
        public ImGuiKeyData KeysData492;

        /// <summary>
        ///     The keys data 493
        /// </summary>
        public ImGuiKeyData KeysData493;

        /// <summary>
        ///     The keys data 494
        /// </summary>
        public ImGuiKeyData KeysData494;

        /// <summary>
        ///     The keys data 495
        /// </summary>
        public ImGuiKeyData KeysData495;

        /// <summary>
        ///     The keys data 496
        /// </summary>
        public ImGuiKeyData KeysData496;

        /// <summary>
        ///     The keys data 497
        /// </summary>
        public ImGuiKeyData KeysData497;

        /// <summary>
        ///     The keys data 498
        /// </summary>
        public ImGuiKeyData KeysData498;

        /// <summary>
        ///     The keys data 499
        /// </summary>
        public ImGuiKeyData KeysData499;

        /// <summary>
        ///     The keys data 500
        /// </summary>
        public ImGuiKeyData KeysData500;

        /// <summary>
        ///     The keys data 501
        /// </summary>
        public ImGuiKeyData KeysData501;

        /// <summary>
        ///     The keys data 502
        /// </summary>
        public ImGuiKeyData KeysData502;

        /// <summary>
        ///     The keys data 503
        /// </summary>
        public ImGuiKeyData KeysData503;

        /// <summary>
        ///     The keys data 504
        /// </summary>
        public ImGuiKeyData KeysData504;

        /// <summary>
        ///     The keys data 505
        /// </summary>
        public ImGuiKeyData KeysData505;

        /// <summary>
        ///     The keys data 506
        /// </summary>
        public ImGuiKeyData KeysData506;

        /// <summary>
        ///     The keys data 507
        /// </summary>
        public ImGuiKeyData KeysData507;

        /// <summary>
        ///     The keys data 508
        /// </summary>
        public ImGuiKeyData KeysData508;

        /// <summary>
        ///     The keys data 509
        /// </summary>
        public ImGuiKeyData KeysData509;

        /// <summary>
        ///     The keys data 510
        /// </summary>
        public ImGuiKeyData KeysData510;

        /// <summary>
        ///     The keys data 511
        /// </summary>
        public ImGuiKeyData KeysData511;

        /// <summary>
        ///     The keys data 512
        /// </summary>
        public ImGuiKeyData KeysData512;

        /// <summary>
        ///     The keys data 513
        /// </summary>
        public ImGuiKeyData KeysData513;

        /// <summary>
        ///     The keys data 514
        /// </summary>
        public ImGuiKeyData KeysData514;

        /// <summary>
        ///     The keys data 515
        /// </summary>
        public ImGuiKeyData KeysData515;

        /// <summary>
        ///     The keys data 516
        /// </summary>
        public ImGuiKeyData KeysData516;

        /// <summary>
        ///     The keys data 517
        /// </summary>
        public ImGuiKeyData KeysData517;

        /// <summary>
        ///     The keys data 518
        /// </summary>
        public ImGuiKeyData KeysData518;

        /// <summary>
        ///     The keys data 519
        /// </summary>
        public ImGuiKeyData KeysData519;

        /// <summary>
        ///     The keys data 520
        /// </summary>
        public ImGuiKeyData KeysData520;

        /// <summary>
        ///     The keys data 521
        /// </summary>
        public ImGuiKeyData KeysData521;

        /// <summary>
        ///     The keys data 522
        /// </summary>
        public ImGuiKeyData KeysData522;

        /// <summary>
        ///     The keys data 523
        /// </summary>
        public ImGuiKeyData KeysData523;

        /// <summary>
        ///     The keys data 524
        /// </summary>
        public ImGuiKeyData KeysData524;

        /// <summary>
        ///     The keys data 525
        /// </summary>
        public ImGuiKeyData KeysData525;

        /// <summary>
        ///     The keys data 526
        /// </summary>
        public ImGuiKeyData KeysData526;

        /// <summary>
        ///     The keys data 527
        /// </summary>
        public ImGuiKeyData KeysData527;

        /// <summary>
        ///     The keys data 528
        /// </summary>
        public ImGuiKeyData KeysData528;

        /// <summary>
        ///     The keys data 529
        /// </summary>
        public ImGuiKeyData KeysData529;

        /// <summary>
        ///     The keys data 530
        /// </summary>
        public ImGuiKeyData KeysData530;

        /// <summary>
        ///     The keys data 531
        /// </summary>
        public ImGuiKeyData KeysData531;

        /// <summary>
        ///     The keys data 532
        /// </summary>
        public ImGuiKeyData KeysData532;

        /// <summary>
        ///     The keys data 533
        /// </summary>
        public ImGuiKeyData KeysData533;

        /// <summary>
        ///     The keys data 534
        /// </summary>
        public ImGuiKeyData KeysData534;

        /// <summary>
        ///     The keys data 535
        /// </summary>
        public ImGuiKeyData KeysData535;

        /// <summary>
        ///     The keys data 536
        /// </summary>
        public ImGuiKeyData KeysData536;

        /// <summary>
        ///     The keys data 537
        /// </summary>
        public ImGuiKeyData KeysData537;

        /// <summary>
        ///     The keys data 538
        /// </summary>
        public ImGuiKeyData KeysData538;

        /// <summary>
        ///     The keys data 539
        /// </summary>
        public ImGuiKeyData KeysData539;

        /// <summary>
        ///     The keys data 540
        /// </summary>
        public ImGuiKeyData KeysData540;

        /// <summary>
        ///     The keys data 541
        /// </summary>
        public ImGuiKeyData KeysData541;

        /// <summary>
        ///     The keys data 542
        /// </summary>
        public ImGuiKeyData KeysData542;

        /// <summary>
        ///     The keys data 543
        /// </summary>
        public ImGuiKeyData KeysData543;

        /// <summary>
        ///     The keys data 544
        /// </summary>
        public ImGuiKeyData KeysData544;

        /// <summary>
        ///     The keys data 545
        /// </summary>
        public ImGuiKeyData KeysData545;

        /// <summary>
        ///     The keys data 546
        /// </summary>
        public ImGuiKeyData KeysData546;

        /// <summary>
        ///     The keys data 547
        /// </summary>
        public ImGuiKeyData KeysData547;

        /// <summary>
        ///     The keys data 548
        /// </summary>
        public ImGuiKeyData KeysData548;

        /// <summary>
        ///     The keys data 549
        /// </summary>
        public ImGuiKeyData KeysData549;

        /// <summary>
        ///     The keys data 550
        /// </summary>
        public ImGuiKeyData KeysData550;

        /// <summary>
        ///     The keys data 551
        /// </summary>
        public ImGuiKeyData KeysData551;

        /// <summary>
        ///     The keys data 552
        /// </summary>
        public ImGuiKeyData KeysData552;

        /// <summary>
        ///     The keys data 553
        /// </summary>
        public ImGuiKeyData KeysData553;

        /// <summary>
        ///     The keys data 554
        /// </summary>
        public ImGuiKeyData KeysData554;

        /// <summary>
        ///     The keys data 555
        /// </summary>
        public ImGuiKeyData KeysData555;

        /// <summary>
        ///     The keys data 556
        /// </summary>
        public ImGuiKeyData KeysData556;

        /// <summary>
        ///     The keys data 557
        /// </summary>
        public ImGuiKeyData KeysData557;

        /// <summary>
        ///     The keys data 558
        /// </summary>
        public ImGuiKeyData KeysData558;

        /// <summary>
        ///     The keys data 559
        /// </summary>
        public ImGuiKeyData KeysData559;

        /// <summary>
        ///     The keys data 560
        /// </summary>
        public ImGuiKeyData KeysData560;

        /// <summary>
        ///     The keys data 561
        /// </summary>
        public ImGuiKeyData KeysData561;

        /// <summary>
        ///     The keys data 562
        /// </summary>
        public ImGuiKeyData KeysData562;

        /// <summary>
        ///     The keys data 563
        /// </summary>
        public ImGuiKeyData KeysData563;

        /// <summary>
        ///     The keys data 564
        /// </summary>
        public ImGuiKeyData KeysData564;

        /// <summary>
        ///     The keys data 565
        /// </summary>
        public ImGuiKeyData KeysData565;

        /// <summary>
        ///     The keys data 566
        /// </summary>
        public ImGuiKeyData KeysData566;

        /// <summary>
        ///     The keys data 567
        /// </summary>
        public ImGuiKeyData KeysData567;

        /// <summary>
        ///     The keys data 568
        /// </summary>
        public ImGuiKeyData KeysData568;

        /// <summary>
        ///     The keys data 569
        /// </summary>
        public ImGuiKeyData KeysData569;

        /// <summary>
        ///     The keys data 570
        /// </summary>
        public ImGuiKeyData KeysData570;

        /// <summary>
        ///     The keys data 571
        /// </summary>
        public ImGuiKeyData KeysData571;

        /// <summary>
        ///     The keys data 572
        /// </summary>
        public ImGuiKeyData KeysData572;

        /// <summary>
        ///     The keys data 573
        /// </summary>
        public ImGuiKeyData KeysData573;

        /// <summary>
        ///     The keys data 574
        /// </summary>
        public ImGuiKeyData KeysData574;

        /// <summary>
        ///     The keys data 575
        /// </summary>
        public ImGuiKeyData KeysData575;

        /// <summary>
        ///     The keys data 576
        /// </summary>
        public ImGuiKeyData KeysData576;

        /// <summary>
        ///     The keys data 577
        /// </summary>
        public ImGuiKeyData KeysData577;

        /// <summary>
        ///     The keys data 578
        /// </summary>
        public ImGuiKeyData KeysData578;

        /// <summary>
        ///     The keys data 579
        /// </summary>
        public ImGuiKeyData KeysData579;

        /// <summary>
        ///     The keys data 580
        /// </summary>
        public ImGuiKeyData KeysData580;

        /// <summary>
        ///     The keys data 581
        /// </summary>
        public ImGuiKeyData KeysData581;

        /// <summary>
        ///     The keys data 582
        /// </summary>
        public ImGuiKeyData KeysData582;

        /// <summary>
        ///     The keys data 583
        /// </summary>
        public ImGuiKeyData KeysData583;

        /// <summary>
        ///     The keys data 584
        /// </summary>
        public ImGuiKeyData KeysData584;

        /// <summary>
        ///     The keys data 585
        /// </summary>
        public ImGuiKeyData KeysData585;

        /// <summary>
        ///     The keys data 586
        /// </summary>
        public ImGuiKeyData KeysData586;

        /// <summary>
        ///     The keys data 587
        /// </summary>
        public ImGuiKeyData KeysData587;

        /// <summary>
        ///     The keys data 588
        /// </summary>
        public ImGuiKeyData KeysData588;

        /// <summary>
        ///     The keys data 589
        /// </summary>
        public ImGuiKeyData KeysData589;

        /// <summary>
        ///     The keys data 590
        /// </summary>
        public ImGuiKeyData KeysData590;

        /// <summary>
        ///     The keys data 591
        /// </summary>
        public ImGuiKeyData KeysData591;

        /// <summary>
        ///     The keys data 592
        /// </summary>
        public ImGuiKeyData KeysData592;

        /// <summary>
        ///     The keys data 593
        /// </summary>
        public ImGuiKeyData KeysData593;

        /// <summary>
        ///     The keys data 594
        /// </summary>
        public ImGuiKeyData KeysData594;

        /// <summary>
        ///     The keys data 595
        /// </summary>
        public ImGuiKeyData KeysData595;

        /// <summary>
        ///     The keys data 596
        /// </summary>
        public ImGuiKeyData KeysData596;

        /// <summary>
        ///     The keys data 597
        /// </summary>
        public ImGuiKeyData KeysData597;

        /// <summary>
        ///     The keys data 598
        /// </summary>
        public ImGuiKeyData KeysData598;

        /// <summary>
        ///     The keys data 599
        /// </summary>
        public ImGuiKeyData KeysData599;

        /// <summary>
        ///     The keys data 600
        /// </summary>
        public ImGuiKeyData KeysData600;

        /// <summary>
        ///     The keys data 601
        /// </summary>
        public ImGuiKeyData KeysData601;

        /// <summary>
        ///     The keys data 602
        /// </summary>
        public ImGuiKeyData KeysData602;

        /// <summary>
        ///     The keys data 603
        /// </summary>
        public ImGuiKeyData KeysData603;

        /// <summary>
        ///     The keys data 604
        /// </summary>
        public ImGuiKeyData KeysData604;

        /// <summary>
        ///     The keys data 605
        /// </summary>
        public ImGuiKeyData KeysData605;

        /// <summary>
        ///     The keys data 606
        /// </summary>
        public ImGuiKeyData KeysData606;

        /// <summary>
        ///     The keys data 607
        /// </summary>
        public ImGuiKeyData KeysData607;

        /// <summary>
        ///     The keys data 608
        /// </summary>
        public ImGuiKeyData KeysData608;

        /// <summary>
        ///     The keys data 609
        /// </summary>
        public ImGuiKeyData KeysData609;

        /// <summary>
        ///     The keys data 610
        /// </summary>
        public ImGuiKeyData KeysData610;

        /// <summary>
        ///     The keys data 611
        /// </summary>
        public ImGuiKeyData KeysData611;

        /// <summary>
        ///     The keys data 612
        /// </summary>
        public ImGuiKeyData KeysData612;

        /// <summary>
        ///     The keys data 613
        /// </summary>
        public ImGuiKeyData KeysData613;

        /// <summary>
        ///     The keys data 614
        /// </summary>
        public ImGuiKeyData KeysData614;

        /// <summary>
        ///     The keys data 615
        /// </summary>
        public ImGuiKeyData KeysData615;

        /// <summary>
        ///     The keys data 616
        /// </summary>
        public ImGuiKeyData KeysData616;

        /// <summary>
        ///     The keys data 617
        /// </summary>
        public ImGuiKeyData KeysData617;

        /// <summary>
        ///     The keys data 618
        /// </summary>
        public ImGuiKeyData KeysData618;

        /// <summary>
        ///     The keys data 619
        /// </summary>
        public ImGuiKeyData KeysData619;

        /// <summary>
        ///     The keys data 620
        /// </summary>
        public ImGuiKeyData KeysData620;

        /// <summary>
        ///     The keys data 621
        /// </summary>
        public ImGuiKeyData KeysData621;

        /// <summary>
        ///     The keys data 622
        /// </summary>
        public ImGuiKeyData KeysData622;

        /// <summary>
        ///     The keys data 623
        /// </summary>
        public ImGuiKeyData KeysData623;

        /// <summary>
        ///     The keys data 624
        /// </summary>
        public ImGuiKeyData KeysData624;

        /// <summary>
        ///     The keys data 625
        /// </summary>
        public ImGuiKeyData KeysData625;

        /// <summary>
        ///     The keys data 626
        /// </summary>
        public ImGuiKeyData KeysData626;

        /// <summary>
        ///     The keys data 627
        /// </summary>
        public ImGuiKeyData KeysData627;

        /// <summary>
        ///     The keys data 628
        /// </summary>
        public ImGuiKeyData KeysData628;

        /// <summary>
        ///     The keys data 629
        /// </summary>
        public ImGuiKeyData KeysData629;

        /// <summary>
        ///     The keys data 630
        /// </summary>
        public ImGuiKeyData KeysData630;

        /// <summary>
        ///     The keys data 631
        /// </summary>
        public ImGuiKeyData KeysData631;

        /// <summary>
        ///     The keys data 632
        /// </summary>
        public ImGuiKeyData KeysData632;

        /// <summary>
        ///     The keys data 633
        /// </summary>
        public ImGuiKeyData KeysData633;

        /// <summary>
        ///     The keys data 634
        /// </summary>
        public ImGuiKeyData KeysData634;

        /// <summary>
        ///     The keys data 635
        /// </summary>
        public ImGuiKeyData KeysData635;

        /// <summary>
        ///     The keys data 636
        /// </summary>
        public ImGuiKeyData KeysData636;

        /// <summary>
        ///     The keys data 637
        /// </summary>
        public ImGuiKeyData KeysData637;

        /// <summary>
        ///     The keys data 638
        /// </summary>
        public ImGuiKeyData KeysData638;

        /// <summary>
        ///     The keys data 639
        /// </summary>
        public ImGuiKeyData KeysData639;

        /// <summary>
        ///     The keys data 640
        /// </summary>
        public ImGuiKeyData KeysData640;

        /// <summary>
        ///     The keys data 641
        /// </summary>
        public ImGuiKeyData KeysData641;

        /// <summary>
        ///     The keys data 642
        /// </summary>
        public ImGuiKeyData KeysData642;

        /// <summary>
        ///     The keys data 643
        /// </summary>
        public ImGuiKeyData KeysData643;

        /// <summary>
        ///     The keys data 644
        /// </summary>
        public ImGuiKeyData KeysData644;

        /// <summary>
        ///     The keys data 645
        /// </summary>
        public ImGuiKeyData KeysData645;

        /// <summary>
        ///     The keys data 646
        /// </summary>
        public ImGuiKeyData KeysData646;

        /// <summary>
        ///     The keys data 647
        /// </summary>
        public ImGuiKeyData KeysData647;

        /// <summary>
        ///     The keys data 648
        /// </summary>
        public ImGuiKeyData KeysData648;

        /// <summary>
        ///     The keys data 649
        /// </summary>
        public ImGuiKeyData KeysData649;

        /// <summary>
        ///     The keys data 650
        /// </summary>
        public ImGuiKeyData KeysData650;

        /// <summary>
        ///     The keys data 651
        /// </summary>
        public ImGuiKeyData KeysData651;

        /// <summary>
        ///     The want capture mouse unless popup close
        /// </summary>
        public byte WantCaptureMouseUnlessPopupClose;

        /// <summary>
        ///     The mouse pos prev
        /// </summary>
        public Vector2F MousePosPrev;

        /// <summary>
        ///     The mouseclickedpos
        /// </summary>
        public Vector2F MouseClickedPos0;

        /// <summary>
        ///     The mouseclickedpos
        /// </summary>
        public Vector2F MouseClickedPos1;

        /// <summary>
        ///     The mouseclickedpos
        /// </summary>
        public Vector2F MouseClickedPos2;

        /// <summary>
        ///     The mouseclickedpos
        /// </summary>
        public Vector2F MouseClickedPos3;

        /// <summary>
        ///     The mouseclickedpos
        /// </summary>
        public Vector2F MouseClickedPos4;

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
        ///     The mouse wheel request axis swap
        /// </summary>
        public byte MouseWheelRequestAxisSwap;

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
        public Vector2F MouseDragMaxDistanceAbs0;

        /// <summary>
        ///     The mousedragmaxdistanceabs
        /// </summary>
        public Vector2F MouseDragMaxDistanceAbs1;

        /// <summary>
        ///     The mousedragmaxdistanceabs
        /// </summary>
        public Vector2F MouseDragMaxDistanceAbs2;

        /// <summary>
        ///     The mousedragmaxdistanceabs
        /// </summary>
        public Vector2F MouseDragMaxDistanceAbs3;

        /// <summary>
        ///     The mousedragmaxdistanceabs
        /// </summary>
        public Vector2F MouseDragMaxDistanceAbs4;

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