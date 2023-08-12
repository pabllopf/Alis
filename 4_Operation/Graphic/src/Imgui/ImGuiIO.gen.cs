using System;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Text;

namespace Alis.Core.Graphic.Imgui
{
    /// <summary>
    /// The im gui io
    /// </summary>
    public unsafe partial struct ImGuiIO
    {
        /// <summary>
        /// The config flags
        /// </summary>
        public ImGuiConfigFlags ConfigFlags;
        /// <summary>
        /// The backend flags
        /// </summary>
        public ImGuiBackendFlags BackendFlags;
        /// <summary>
        /// The display size
        /// </summary>
        public Vector2 DisplaySize;
        /// <summary>
        /// The delta time
        /// </summary>
        public float DeltaTime;
        /// <summary>
        /// The ini saving rate
        /// </summary>
        public float IniSavingRate;
        /// <summary>
        /// The ini filename
        /// </summary>
        public byte* IniFilename;
        /// <summary>
        /// The log filename
        /// </summary>
        public byte* LogFilename;
        /// <summary>
        /// The mouse double click time
        /// </summary>
        public float MouseDoubleClickTime;
        /// <summary>
        /// The mouse double click max dist
        /// </summary>
        public float MouseDoubleClickMaxDist;
        /// <summary>
        /// The mouse drag threshold
        /// </summary>
        public float MouseDragThreshold;
        /// <summary>
        /// The key repeat delay
        /// </summary>
        public float KeyRepeatDelay;
        /// <summary>
        /// The key repeat rate
        /// </summary>
        public float KeyRepeatRate;
        /// <summary>
        /// The hover delay normal
        /// </summary>
        public float HoverDelayNormal;
        /// <summary>
        /// The hover delay short
        /// </summary>
        public float HoverDelayShort;
        /// <summary>
        /// The user data
        /// </summary>
        public void* UserData;
        /// <summary>
        /// The fonts
        /// </summary>
        public ImFontAtlas* Fonts;
        /// <summary>
        /// The font global scale
        /// </summary>
        public float FontGlobalScale;
        /// <summary>
        /// The font allow user scaling
        /// </summary>
        public byte FontAllowUserScaling;
        /// <summary>
        /// The font default
        /// </summary>
        public ImFont* FontDefault;
        /// <summary>
        /// The display framebuffer scale
        /// </summary>
        public Vector2 DisplayFramebufferScale;
        /// <summary>
        /// The config docking no split
        /// </summary>
        public byte ConfigDockingNoSplit;
        /// <summary>
        /// The config docking with shift
        /// </summary>
        public byte ConfigDockingWithShift;
        /// <summary>
        /// The config docking always tab bar
        /// </summary>
        public byte ConfigDockingAlwaysTabBar;
        /// <summary>
        /// The config docking transparent payload
        /// </summary>
        public byte ConfigDockingTransparentPayload;
        /// <summary>
        /// The config viewports no auto merge
        /// </summary>
        public byte ConfigViewportsNoAutoMerge;
        /// <summary>
        /// The config viewports no task bar icon
        /// </summary>
        public byte ConfigViewportsNoTaskBarIcon;
        /// <summary>
        /// The config viewports no decoration
        /// </summary>
        public byte ConfigViewportsNoDecoration;
        /// <summary>
        /// The config viewports no default parent
        /// </summary>
        public byte ConfigViewportsNoDefaultParent;
        /// <summary>
        /// The mouse draw cursor
        /// </summary>
        public byte MouseDrawCursor;
        /// <summary>
        /// The config mac osx behaviors
        /// </summary>
        public byte ConfigMacOSXBehaviors;
        /// <summary>
        /// The config input trickle event queue
        /// </summary>
        public byte ConfigInputTrickleEventQueue;
        /// <summary>
        /// The config input text cursor blink
        /// </summary>
        public byte ConfigInputTextCursorBlink;
        /// <summary>
        /// The config input text enter keep active
        /// </summary>
        public byte ConfigInputTextEnterKeepActive;
        /// <summary>
        /// The config drag click to input text
        /// </summary>
        public byte ConfigDragClickToInputText;
        /// <summary>
        /// The config windows resize from edges
        /// </summary>
        public byte ConfigWindowsResizeFromEdges;
        /// <summary>
        /// The config windows move from title bar only
        /// </summary>
        public byte ConfigWindowsMoveFromTitleBarOnly;
        /// <summary>
        /// The config memory compact timer
        /// </summary>
        public float ConfigMemoryCompactTimer;
        /// <summary>
        /// The backend platform name
        /// </summary>
        public byte* BackendPlatformName;
        /// <summary>
        /// The backend renderer name
        /// </summary>
        public byte* BackendRendererName;
        /// <summary>
        /// The backend platform user data
        /// </summary>
        public void* BackendPlatformUserData;
        /// <summary>
        /// The backend renderer user data
        /// </summary>
        public void* BackendRendererUserData;
        /// <summary>
        /// The backend language user data
        /// </summary>
        public void* BackendLanguageUserData;
        /// <summary>
        /// The get clipboard text fn
        /// </summary>
        public IntPtr GetClipboardTextFn;
        /// <summary>
        /// The set clipboard text fn
        /// </summary>
        public IntPtr SetClipboardTextFn;
        /// <summary>
        /// The clipboard user data
        /// </summary>
        public void* ClipboardUserData;
        /// <summary>
        /// The set platform ime data fn
        /// </summary>
        public IntPtr SetPlatformImeDataFn;
        /// <summary>
        /// The unused padding
        /// </summary>
        public void* _UnusedPadding;
        /// <summary>
        /// The want capture mouse
        /// </summary>
        public byte WantCaptureMouse;
        /// <summary>
        /// The want capture keyboard
        /// </summary>
        public byte WantCaptureKeyboard;
        /// <summary>
        /// The want text input
        /// </summary>
        public byte WantTextInput;
        /// <summary>
        /// The want set mouse pos
        /// </summary>
        public byte WantSetMousePos;
        /// <summary>
        /// The want save ini settings
        /// </summary>
        public byte WantSaveIniSettings;
        /// <summary>
        /// The nav active
        /// </summary>
        public byte NavActive;
        /// <summary>
        /// The nav visible
        /// </summary>
        public byte NavVisible;
        /// <summary>
        /// The framerate
        /// </summary>
        public float Framerate;
        /// <summary>
        /// The metrics render vertices
        /// </summary>
        public int MetricsRenderVertices;
        /// <summary>
        /// The metrics render indices
        /// </summary>
        public int MetricsRenderIndices;
        /// <summary>
        /// The metrics render windows
        /// </summary>
        public int MetricsRenderWindows;
        /// <summary>
        /// The metrics active windows
        /// </summary>
        public int MetricsActiveWindows;
        /// <summary>
        /// The metrics active allocations
        /// </summary>
        public int MetricsActiveAllocations;
        /// <summary>
        /// The mouse delta
        /// </summary>
        public Vector2 MouseDelta;
        /// <summary>
        /// The key map
        /// </summary>
        public fixed int KeyMap[652];
        /// <summary>
        /// The keys down
        /// </summary>
        public fixed byte KeysDown[652];
        /// <summary>
        /// The nav inputs
        /// </summary>
        public fixed float NavInputs[16];
        /// <summary>
        /// The mouse pos
        /// </summary>
        public Vector2 MousePos;
        /// <summary>
        /// The mouse down
        /// </summary>
        public fixed byte MouseDown[5];
        /// <summary>
        /// The mouse wheel
        /// </summary>
        public float MouseWheel;
        /// <summary>
        /// The mouse wheel
        /// </summary>
        public float MouseWheelH;
        /// <summary>
        /// The mouse hovered viewport
        /// </summary>
        public uint MouseHoveredViewport;
        /// <summary>
        /// The key ctrl
        /// </summary>
        public byte KeyCtrl;
        /// <summary>
        /// The key shift
        /// </summary>
        public byte KeyShift;
        /// <summary>
        /// The key alt
        /// </summary>
        public byte KeyAlt;
        /// <summary>
        /// The key super
        /// </summary>
        public byte KeySuper;
        /// <summary>
        /// The key mods
        /// </summary>
        public ImGuiKey KeyMods;
        /// <summary>
        /// The keysdata
        /// </summary>
        public ImGuiKeyData KeysData_0;
        /// <summary>
        /// The keysdata
        /// </summary>
        public ImGuiKeyData KeysData_1;
        /// <summary>
        /// The keysdata
        /// </summary>
        public ImGuiKeyData KeysData_2;
        /// <summary>
        /// The keysdata
        /// </summary>
        public ImGuiKeyData KeysData_3;
        /// <summary>
        /// The keysdata
        /// </summary>
        public ImGuiKeyData KeysData_4;
        /// <summary>
        /// The keysdata
        /// </summary>
        public ImGuiKeyData KeysData_5;
        /// <summary>
        /// The keysdata
        /// </summary>
        public ImGuiKeyData KeysData_6;
        /// <summary>
        /// The keysdata
        /// </summary>
        public ImGuiKeyData KeysData_7;
        /// <summary>
        /// The keysdata
        /// </summary>
        public ImGuiKeyData KeysData_8;
        /// <summary>
        /// The keysdata
        /// </summary>
        public ImGuiKeyData KeysData_9;
        /// <summary>
        /// The keysdata 10
        /// </summary>
        public ImGuiKeyData KeysData_10;
        /// <summary>
        /// The keysdata 11
        /// </summary>
        public ImGuiKeyData KeysData_11;
        /// <summary>
        /// The keysdata 12
        /// </summary>
        public ImGuiKeyData KeysData_12;
        /// <summary>
        /// The keysdata 13
        /// </summary>
        public ImGuiKeyData KeysData_13;
        /// <summary>
        /// The keysdata 14
        /// </summary>
        public ImGuiKeyData KeysData_14;
        /// <summary>
        /// The keysdata 15
        /// </summary>
        public ImGuiKeyData KeysData_15;
        /// <summary>
        /// The keysdata 16
        /// </summary>
        public ImGuiKeyData KeysData_16;
        /// <summary>
        /// The keysdata 17
        /// </summary>
        public ImGuiKeyData KeysData_17;
        /// <summary>
        /// The keysdata 18
        /// </summary>
        public ImGuiKeyData KeysData_18;
        /// <summary>
        /// The keysdata 19
        /// </summary>
        public ImGuiKeyData KeysData_19;
        /// <summary>
        /// The keysdata 20
        /// </summary>
        public ImGuiKeyData KeysData_20;
        /// <summary>
        /// The keysdata 21
        /// </summary>
        public ImGuiKeyData KeysData_21;
        /// <summary>
        /// The keysdata 22
        /// </summary>
        public ImGuiKeyData KeysData_22;
        /// <summary>
        /// The keysdata 23
        /// </summary>
        public ImGuiKeyData KeysData_23;
        /// <summary>
        /// The keysdata 24
        /// </summary>
        public ImGuiKeyData KeysData_24;
        /// <summary>
        /// The keysdata 25
        /// </summary>
        public ImGuiKeyData KeysData_25;
        /// <summary>
        /// The keysdata 26
        /// </summary>
        public ImGuiKeyData KeysData_26;
        /// <summary>
        /// The keysdata 27
        /// </summary>
        public ImGuiKeyData KeysData_27;
        /// <summary>
        /// The keysdata 28
        /// </summary>
        public ImGuiKeyData KeysData_28;
        /// <summary>
        /// The keysdata 29
        /// </summary>
        public ImGuiKeyData KeysData_29;
        /// <summary>
        /// The keysdata 30
        /// </summary>
        public ImGuiKeyData KeysData_30;
        /// <summary>
        /// The keysdata 31
        /// </summary>
        public ImGuiKeyData KeysData_31;
        /// <summary>
        /// The keysdata 32
        /// </summary>
        public ImGuiKeyData KeysData_32;
        /// <summary>
        /// The keysdata 33
        /// </summary>
        public ImGuiKeyData KeysData_33;
        /// <summary>
        /// The keysdata 34
        /// </summary>
        public ImGuiKeyData KeysData_34;
        /// <summary>
        /// The keysdata 35
        /// </summary>
        public ImGuiKeyData KeysData_35;
        /// <summary>
        /// The keysdata 36
        /// </summary>
        public ImGuiKeyData KeysData_36;
        /// <summary>
        /// The keysdata 37
        /// </summary>
        public ImGuiKeyData KeysData_37;
        /// <summary>
        /// The keysdata 38
        /// </summary>
        public ImGuiKeyData KeysData_38;
        /// <summary>
        /// The keysdata 39
        /// </summary>
        public ImGuiKeyData KeysData_39;
        /// <summary>
        /// The keysdata 40
        /// </summary>
        public ImGuiKeyData KeysData_40;
        /// <summary>
        /// The keysdata 41
        /// </summary>
        public ImGuiKeyData KeysData_41;
        /// <summary>
        /// The keysdata 42
        /// </summary>
        public ImGuiKeyData KeysData_42;
        /// <summary>
        /// The keysdata 43
        /// </summary>
        public ImGuiKeyData KeysData_43;
        /// <summary>
        /// The keysdata 44
        /// </summary>
        public ImGuiKeyData KeysData_44;
        /// <summary>
        /// The keysdata 45
        /// </summary>
        public ImGuiKeyData KeysData_45;
        /// <summary>
        /// The keysdata 46
        /// </summary>
        public ImGuiKeyData KeysData_46;
        /// <summary>
        /// The keysdata 47
        /// </summary>
        public ImGuiKeyData KeysData_47;
        /// <summary>
        /// The keysdata 48
        /// </summary>
        public ImGuiKeyData KeysData_48;
        /// <summary>
        /// The keysdata 49
        /// </summary>
        public ImGuiKeyData KeysData_49;
        /// <summary>
        /// The keysdata 50
        /// </summary>
        public ImGuiKeyData KeysData_50;
        /// <summary>
        /// The keysdata 51
        /// </summary>
        public ImGuiKeyData KeysData_51;
        /// <summary>
        /// The keysdata 52
        /// </summary>
        public ImGuiKeyData KeysData_52;
        /// <summary>
        /// The keysdata 53
        /// </summary>
        public ImGuiKeyData KeysData_53;
        /// <summary>
        /// The keysdata 54
        /// </summary>
        public ImGuiKeyData KeysData_54;
        /// <summary>
        /// The keysdata 55
        /// </summary>
        public ImGuiKeyData KeysData_55;
        /// <summary>
        /// The keysdata 56
        /// </summary>
        public ImGuiKeyData KeysData_56;
        /// <summary>
        /// The keysdata 57
        /// </summary>
        public ImGuiKeyData KeysData_57;
        /// <summary>
        /// The keysdata 58
        /// </summary>
        public ImGuiKeyData KeysData_58;
        /// <summary>
        /// The keysdata 59
        /// </summary>
        public ImGuiKeyData KeysData_59;
        /// <summary>
        /// The keysdata 60
        /// </summary>
        public ImGuiKeyData KeysData_60;
        /// <summary>
        /// The keysdata 61
        /// </summary>
        public ImGuiKeyData KeysData_61;
        /// <summary>
        /// The keysdata 62
        /// </summary>
        public ImGuiKeyData KeysData_62;
        /// <summary>
        /// The keysdata 63
        /// </summary>
        public ImGuiKeyData KeysData_63;
        /// <summary>
        /// The keysdata 64
        /// </summary>
        public ImGuiKeyData KeysData_64;
        /// <summary>
        /// The keysdata 65
        /// </summary>
        public ImGuiKeyData KeysData_65;
        /// <summary>
        /// The keysdata 66
        /// </summary>
        public ImGuiKeyData KeysData_66;
        /// <summary>
        /// The keysdata 67
        /// </summary>
        public ImGuiKeyData KeysData_67;
        /// <summary>
        /// The keysdata 68
        /// </summary>
        public ImGuiKeyData KeysData_68;
        /// <summary>
        /// The keysdata 69
        /// </summary>
        public ImGuiKeyData KeysData_69;
        /// <summary>
        /// The keysdata 70
        /// </summary>
        public ImGuiKeyData KeysData_70;
        /// <summary>
        /// The keysdata 71
        /// </summary>
        public ImGuiKeyData KeysData_71;
        /// <summary>
        /// The keysdata 72
        /// </summary>
        public ImGuiKeyData KeysData_72;
        /// <summary>
        /// The keysdata 73
        /// </summary>
        public ImGuiKeyData KeysData_73;
        /// <summary>
        /// The keysdata 74
        /// </summary>
        public ImGuiKeyData KeysData_74;
        /// <summary>
        /// The keysdata 75
        /// </summary>
        public ImGuiKeyData KeysData_75;
        /// <summary>
        /// The keysdata 76
        /// </summary>
        public ImGuiKeyData KeysData_76;
        /// <summary>
        /// The keysdata 77
        /// </summary>
        public ImGuiKeyData KeysData_77;
        /// <summary>
        /// The keysdata 78
        /// </summary>
        public ImGuiKeyData KeysData_78;
        /// <summary>
        /// The keysdata 79
        /// </summary>
        public ImGuiKeyData KeysData_79;
        /// <summary>
        /// The keysdata 80
        /// </summary>
        public ImGuiKeyData KeysData_80;
        /// <summary>
        /// The keysdata 81
        /// </summary>
        public ImGuiKeyData KeysData_81;
        /// <summary>
        /// The keysdata 82
        /// </summary>
        public ImGuiKeyData KeysData_82;
        /// <summary>
        /// The keysdata 83
        /// </summary>
        public ImGuiKeyData KeysData_83;
        /// <summary>
        /// The keysdata 84
        /// </summary>
        public ImGuiKeyData KeysData_84;
        /// <summary>
        /// The keysdata 85
        /// </summary>
        public ImGuiKeyData KeysData_85;
        /// <summary>
        /// The keysdata 86
        /// </summary>
        public ImGuiKeyData KeysData_86;
        /// <summary>
        /// The keysdata 87
        /// </summary>
        public ImGuiKeyData KeysData_87;
        /// <summary>
        /// The keysdata 88
        /// </summary>
        public ImGuiKeyData KeysData_88;
        /// <summary>
        /// The keysdata 89
        /// </summary>
        public ImGuiKeyData KeysData_89;
        /// <summary>
        /// The keysdata 90
        /// </summary>
        public ImGuiKeyData KeysData_90;
        /// <summary>
        /// The keysdata 91
        /// </summary>
        public ImGuiKeyData KeysData_91;
        /// <summary>
        /// The keysdata 92
        /// </summary>
        public ImGuiKeyData KeysData_92;
        /// <summary>
        /// The keysdata 93
        /// </summary>
        public ImGuiKeyData KeysData_93;
        /// <summary>
        /// The keysdata 94
        /// </summary>
        public ImGuiKeyData KeysData_94;
        /// <summary>
        /// The keysdata 95
        /// </summary>
        public ImGuiKeyData KeysData_95;
        /// <summary>
        /// The keysdata 96
        /// </summary>
        public ImGuiKeyData KeysData_96;
        /// <summary>
        /// The keysdata 97
        /// </summary>
        public ImGuiKeyData KeysData_97;
        /// <summary>
        /// The keysdata 98
        /// </summary>
        public ImGuiKeyData KeysData_98;
        /// <summary>
        /// The keysdata 99
        /// </summary>
        public ImGuiKeyData KeysData_99;
        /// <summary>
        /// The keysdata 100
        /// </summary>
        public ImGuiKeyData KeysData_100;
        /// <summary>
        /// The keysdata 101
        /// </summary>
        public ImGuiKeyData KeysData_101;
        /// <summary>
        /// The keysdata 102
        /// </summary>
        public ImGuiKeyData KeysData_102;
        /// <summary>
        /// The keysdata 103
        /// </summary>
        public ImGuiKeyData KeysData_103;
        /// <summary>
        /// The keysdata 104
        /// </summary>
        public ImGuiKeyData KeysData_104;
        /// <summary>
        /// The keysdata 105
        /// </summary>
        public ImGuiKeyData KeysData_105;
        /// <summary>
        /// The keysdata 106
        /// </summary>
        public ImGuiKeyData KeysData_106;
        /// <summary>
        /// The keysdata 107
        /// </summary>
        public ImGuiKeyData KeysData_107;
        /// <summary>
        /// The keysdata 108
        /// </summary>
        public ImGuiKeyData KeysData_108;
        /// <summary>
        /// The keysdata 109
        /// </summary>
        public ImGuiKeyData KeysData_109;
        /// <summary>
        /// The keysdata 110
        /// </summary>
        public ImGuiKeyData KeysData_110;
        /// <summary>
        /// The keysdata 111
        /// </summary>
        public ImGuiKeyData KeysData_111;
        /// <summary>
        /// The keysdata 112
        /// </summary>
        public ImGuiKeyData KeysData_112;
        /// <summary>
        /// The keysdata 113
        /// </summary>
        public ImGuiKeyData KeysData_113;
        /// <summary>
        /// The keysdata 114
        /// </summary>
        public ImGuiKeyData KeysData_114;
        /// <summary>
        /// The keysdata 115
        /// </summary>
        public ImGuiKeyData KeysData_115;
        /// <summary>
        /// The keysdata 116
        /// </summary>
        public ImGuiKeyData KeysData_116;
        /// <summary>
        /// The keysdata 117
        /// </summary>
        public ImGuiKeyData KeysData_117;
        /// <summary>
        /// The keysdata 118
        /// </summary>
        public ImGuiKeyData KeysData_118;
        /// <summary>
        /// The keysdata 119
        /// </summary>
        public ImGuiKeyData KeysData_119;
        /// <summary>
        /// The keysdata 120
        /// </summary>
        public ImGuiKeyData KeysData_120;
        /// <summary>
        /// The keysdata 121
        /// </summary>
        public ImGuiKeyData KeysData_121;
        /// <summary>
        /// The keysdata 122
        /// </summary>
        public ImGuiKeyData KeysData_122;
        /// <summary>
        /// The keysdata 123
        /// </summary>
        public ImGuiKeyData KeysData_123;
        /// <summary>
        /// The keysdata 124
        /// </summary>
        public ImGuiKeyData KeysData_124;
        /// <summary>
        /// The keysdata 125
        /// </summary>
        public ImGuiKeyData KeysData_125;
        /// <summary>
        /// The keysdata 126
        /// </summary>
        public ImGuiKeyData KeysData_126;
        /// <summary>
        /// The keysdata 127
        /// </summary>
        public ImGuiKeyData KeysData_127;
        /// <summary>
        /// The keysdata 128
        /// </summary>
        public ImGuiKeyData KeysData_128;
        /// <summary>
        /// The keysdata 129
        /// </summary>
        public ImGuiKeyData KeysData_129;
        /// <summary>
        /// The keysdata 130
        /// </summary>
        public ImGuiKeyData KeysData_130;
        /// <summary>
        /// The keysdata 131
        /// </summary>
        public ImGuiKeyData KeysData_131;
        /// <summary>
        /// The keysdata 132
        /// </summary>
        public ImGuiKeyData KeysData_132;
        /// <summary>
        /// The keysdata 133
        /// </summary>
        public ImGuiKeyData KeysData_133;
        /// <summary>
        /// The keysdata 134
        /// </summary>
        public ImGuiKeyData KeysData_134;
        /// <summary>
        /// The keysdata 135
        /// </summary>
        public ImGuiKeyData KeysData_135;
        /// <summary>
        /// The keysdata 136
        /// </summary>
        public ImGuiKeyData KeysData_136;
        /// <summary>
        /// The keysdata 137
        /// </summary>
        public ImGuiKeyData KeysData_137;
        /// <summary>
        /// The keysdata 138
        /// </summary>
        public ImGuiKeyData KeysData_138;
        /// <summary>
        /// The keysdata 139
        /// </summary>
        public ImGuiKeyData KeysData_139;
        /// <summary>
        /// The keysdata 140
        /// </summary>
        public ImGuiKeyData KeysData_140;
        /// <summary>
        /// The keysdata 141
        /// </summary>
        public ImGuiKeyData KeysData_141;
        /// <summary>
        /// The keysdata 142
        /// </summary>
        public ImGuiKeyData KeysData_142;
        /// <summary>
        /// The keysdata 143
        /// </summary>
        public ImGuiKeyData KeysData_143;
        /// <summary>
        /// The keysdata 144
        /// </summary>
        public ImGuiKeyData KeysData_144;
        /// <summary>
        /// The keysdata 145
        /// </summary>
        public ImGuiKeyData KeysData_145;
        /// <summary>
        /// The keysdata 146
        /// </summary>
        public ImGuiKeyData KeysData_146;
        /// <summary>
        /// The keysdata 147
        /// </summary>
        public ImGuiKeyData KeysData_147;
        /// <summary>
        /// The keysdata 148
        /// </summary>
        public ImGuiKeyData KeysData_148;
        /// <summary>
        /// The keysdata 149
        /// </summary>
        public ImGuiKeyData KeysData_149;
        /// <summary>
        /// The keysdata 150
        /// </summary>
        public ImGuiKeyData KeysData_150;
        /// <summary>
        /// The keysdata 151
        /// </summary>
        public ImGuiKeyData KeysData_151;
        /// <summary>
        /// The keysdata 152
        /// </summary>
        public ImGuiKeyData KeysData_152;
        /// <summary>
        /// The keysdata 153
        /// </summary>
        public ImGuiKeyData KeysData_153;
        /// <summary>
        /// The keysdata 154
        /// </summary>
        public ImGuiKeyData KeysData_154;
        /// <summary>
        /// The keysdata 155
        /// </summary>
        public ImGuiKeyData KeysData_155;
        /// <summary>
        /// The keysdata 156
        /// </summary>
        public ImGuiKeyData KeysData_156;
        /// <summary>
        /// The keysdata 157
        /// </summary>
        public ImGuiKeyData KeysData_157;
        /// <summary>
        /// The keysdata 158
        /// </summary>
        public ImGuiKeyData KeysData_158;
        /// <summary>
        /// The keysdata 159
        /// </summary>
        public ImGuiKeyData KeysData_159;
        /// <summary>
        /// The keysdata 160
        /// </summary>
        public ImGuiKeyData KeysData_160;
        /// <summary>
        /// The keysdata 161
        /// </summary>
        public ImGuiKeyData KeysData_161;
        /// <summary>
        /// The keysdata 162
        /// </summary>
        public ImGuiKeyData KeysData_162;
        /// <summary>
        /// The keysdata 163
        /// </summary>
        public ImGuiKeyData KeysData_163;
        /// <summary>
        /// The keysdata 164
        /// </summary>
        public ImGuiKeyData KeysData_164;
        /// <summary>
        /// The keysdata 165
        /// </summary>
        public ImGuiKeyData KeysData_165;
        /// <summary>
        /// The keysdata 166
        /// </summary>
        public ImGuiKeyData KeysData_166;
        /// <summary>
        /// The keysdata 167
        /// </summary>
        public ImGuiKeyData KeysData_167;
        /// <summary>
        /// The keysdata 168
        /// </summary>
        public ImGuiKeyData KeysData_168;
        /// <summary>
        /// The keysdata 169
        /// </summary>
        public ImGuiKeyData KeysData_169;
        /// <summary>
        /// The keysdata 170
        /// </summary>
        public ImGuiKeyData KeysData_170;
        /// <summary>
        /// The keysdata 171
        /// </summary>
        public ImGuiKeyData KeysData_171;
        /// <summary>
        /// The keysdata 172
        /// </summary>
        public ImGuiKeyData KeysData_172;
        /// <summary>
        /// The keysdata 173
        /// </summary>
        public ImGuiKeyData KeysData_173;
        /// <summary>
        /// The keysdata 174
        /// </summary>
        public ImGuiKeyData KeysData_174;
        /// <summary>
        /// The keysdata 175
        /// </summary>
        public ImGuiKeyData KeysData_175;
        /// <summary>
        /// The keysdata 176
        /// </summary>
        public ImGuiKeyData KeysData_176;
        /// <summary>
        /// The keysdata 177
        /// </summary>
        public ImGuiKeyData KeysData_177;
        /// <summary>
        /// The keysdata 178
        /// </summary>
        public ImGuiKeyData KeysData_178;
        /// <summary>
        /// The keysdata 179
        /// </summary>
        public ImGuiKeyData KeysData_179;
        /// <summary>
        /// The keysdata 180
        /// </summary>
        public ImGuiKeyData KeysData_180;
        /// <summary>
        /// The keysdata 181
        /// </summary>
        public ImGuiKeyData KeysData_181;
        /// <summary>
        /// The keysdata 182
        /// </summary>
        public ImGuiKeyData KeysData_182;
        /// <summary>
        /// The keysdata 183
        /// </summary>
        public ImGuiKeyData KeysData_183;
        /// <summary>
        /// The keysdata 184
        /// </summary>
        public ImGuiKeyData KeysData_184;
        /// <summary>
        /// The keysdata 185
        /// </summary>
        public ImGuiKeyData KeysData_185;
        /// <summary>
        /// The keysdata 186
        /// </summary>
        public ImGuiKeyData KeysData_186;
        /// <summary>
        /// The keysdata 187
        /// </summary>
        public ImGuiKeyData KeysData_187;
        /// <summary>
        /// The keysdata 188
        /// </summary>
        public ImGuiKeyData KeysData_188;
        /// <summary>
        /// The keysdata 189
        /// </summary>
        public ImGuiKeyData KeysData_189;
        /// <summary>
        /// The keysdata 190
        /// </summary>
        public ImGuiKeyData KeysData_190;
        /// <summary>
        /// The keysdata 191
        /// </summary>
        public ImGuiKeyData KeysData_191;
        /// <summary>
        /// The keysdata 192
        /// </summary>
        public ImGuiKeyData KeysData_192;
        /// <summary>
        /// The keysdata 193
        /// </summary>
        public ImGuiKeyData KeysData_193;
        /// <summary>
        /// The keysdata 194
        /// </summary>
        public ImGuiKeyData KeysData_194;
        /// <summary>
        /// The keysdata 195
        /// </summary>
        public ImGuiKeyData KeysData_195;
        /// <summary>
        /// The keysdata 196
        /// </summary>
        public ImGuiKeyData KeysData_196;
        /// <summary>
        /// The keysdata 197
        /// </summary>
        public ImGuiKeyData KeysData_197;
        /// <summary>
        /// The keysdata 198
        /// </summary>
        public ImGuiKeyData KeysData_198;
        /// <summary>
        /// The keysdata 199
        /// </summary>
        public ImGuiKeyData KeysData_199;
        /// <summary>
        /// The keysdata 200
        /// </summary>
        public ImGuiKeyData KeysData_200;
        /// <summary>
        /// The keysdata 201
        /// </summary>
        public ImGuiKeyData KeysData_201;
        /// <summary>
        /// The keysdata 202
        /// </summary>
        public ImGuiKeyData KeysData_202;
        /// <summary>
        /// The keysdata 203
        /// </summary>
        public ImGuiKeyData KeysData_203;
        /// <summary>
        /// The keysdata 204
        /// </summary>
        public ImGuiKeyData KeysData_204;
        /// <summary>
        /// The keysdata 205
        /// </summary>
        public ImGuiKeyData KeysData_205;
        /// <summary>
        /// The keysdata 206
        /// </summary>
        public ImGuiKeyData KeysData_206;
        /// <summary>
        /// The keysdata 207
        /// </summary>
        public ImGuiKeyData KeysData_207;
        /// <summary>
        /// The keysdata 208
        /// </summary>
        public ImGuiKeyData KeysData_208;
        /// <summary>
        /// The keysdata 209
        /// </summary>
        public ImGuiKeyData KeysData_209;
        /// <summary>
        /// The keysdata 210
        /// </summary>
        public ImGuiKeyData KeysData_210;
        /// <summary>
        /// The keysdata 211
        /// </summary>
        public ImGuiKeyData KeysData_211;
        /// <summary>
        /// The keysdata 212
        /// </summary>
        public ImGuiKeyData KeysData_212;
        /// <summary>
        /// The keysdata 213
        /// </summary>
        public ImGuiKeyData KeysData_213;
        /// <summary>
        /// The keysdata 214
        /// </summary>
        public ImGuiKeyData KeysData_214;
        /// <summary>
        /// The keysdata 215
        /// </summary>
        public ImGuiKeyData KeysData_215;
        /// <summary>
        /// The keysdata 216
        /// </summary>
        public ImGuiKeyData KeysData_216;
        /// <summary>
        /// The keysdata 217
        /// </summary>
        public ImGuiKeyData KeysData_217;
        /// <summary>
        /// The keysdata 218
        /// </summary>
        public ImGuiKeyData KeysData_218;
        /// <summary>
        /// The keysdata 219
        /// </summary>
        public ImGuiKeyData KeysData_219;
        /// <summary>
        /// The keysdata 220
        /// </summary>
        public ImGuiKeyData KeysData_220;
        /// <summary>
        /// The keysdata 221
        /// </summary>
        public ImGuiKeyData KeysData_221;
        /// <summary>
        /// The keysdata 222
        /// </summary>
        public ImGuiKeyData KeysData_222;
        /// <summary>
        /// The keysdata 223
        /// </summary>
        public ImGuiKeyData KeysData_223;
        /// <summary>
        /// The keysdata 224
        /// </summary>
        public ImGuiKeyData KeysData_224;
        /// <summary>
        /// The keysdata 225
        /// </summary>
        public ImGuiKeyData KeysData_225;
        /// <summary>
        /// The keysdata 226
        /// </summary>
        public ImGuiKeyData KeysData_226;
        /// <summary>
        /// The keysdata 227
        /// </summary>
        public ImGuiKeyData KeysData_227;
        /// <summary>
        /// The keysdata 228
        /// </summary>
        public ImGuiKeyData KeysData_228;
        /// <summary>
        /// The keysdata 229
        /// </summary>
        public ImGuiKeyData KeysData_229;
        /// <summary>
        /// The keysdata 230
        /// </summary>
        public ImGuiKeyData KeysData_230;
        /// <summary>
        /// The keysdata 231
        /// </summary>
        public ImGuiKeyData KeysData_231;
        /// <summary>
        /// The keysdata 232
        /// </summary>
        public ImGuiKeyData KeysData_232;
        /// <summary>
        /// The keysdata 233
        /// </summary>
        public ImGuiKeyData KeysData_233;
        /// <summary>
        /// The keysdata 234
        /// </summary>
        public ImGuiKeyData KeysData_234;
        /// <summary>
        /// The keysdata 235
        /// </summary>
        public ImGuiKeyData KeysData_235;
        /// <summary>
        /// The keysdata 236
        /// </summary>
        public ImGuiKeyData KeysData_236;
        /// <summary>
        /// The keysdata 237
        /// </summary>
        public ImGuiKeyData KeysData_237;
        /// <summary>
        /// The keysdata 238
        /// </summary>
        public ImGuiKeyData KeysData_238;
        /// <summary>
        /// The keysdata 239
        /// </summary>
        public ImGuiKeyData KeysData_239;
        /// <summary>
        /// The keysdata 240
        /// </summary>
        public ImGuiKeyData KeysData_240;
        /// <summary>
        /// The keysdata 241
        /// </summary>
        public ImGuiKeyData KeysData_241;
        /// <summary>
        /// The keysdata 242
        /// </summary>
        public ImGuiKeyData KeysData_242;
        /// <summary>
        /// The keysdata 243
        /// </summary>
        public ImGuiKeyData KeysData_243;
        /// <summary>
        /// The keysdata 244
        /// </summary>
        public ImGuiKeyData KeysData_244;
        /// <summary>
        /// The keysdata 245
        /// </summary>
        public ImGuiKeyData KeysData_245;
        /// <summary>
        /// The keysdata 246
        /// </summary>
        public ImGuiKeyData KeysData_246;
        /// <summary>
        /// The keysdata 247
        /// </summary>
        public ImGuiKeyData KeysData_247;
        /// <summary>
        /// The keysdata 248
        /// </summary>
        public ImGuiKeyData KeysData_248;
        /// <summary>
        /// The keysdata 249
        /// </summary>
        public ImGuiKeyData KeysData_249;
        /// <summary>
        /// The keysdata 250
        /// </summary>
        public ImGuiKeyData KeysData_250;
        /// <summary>
        /// The keysdata 251
        /// </summary>
        public ImGuiKeyData KeysData_251;
        /// <summary>
        /// The keysdata 252
        /// </summary>
        public ImGuiKeyData KeysData_252;
        /// <summary>
        /// The keysdata 253
        /// </summary>
        public ImGuiKeyData KeysData_253;
        /// <summary>
        /// The keysdata 254
        /// </summary>
        public ImGuiKeyData KeysData_254;
        /// <summary>
        /// The keysdata 255
        /// </summary>
        public ImGuiKeyData KeysData_255;
        /// <summary>
        /// The keysdata 256
        /// </summary>
        public ImGuiKeyData KeysData_256;
        /// <summary>
        /// The keysdata 257
        /// </summary>
        public ImGuiKeyData KeysData_257;
        /// <summary>
        /// The keysdata 258
        /// </summary>
        public ImGuiKeyData KeysData_258;
        /// <summary>
        /// The keysdata 259
        /// </summary>
        public ImGuiKeyData KeysData_259;
        /// <summary>
        /// The keysdata 260
        /// </summary>
        public ImGuiKeyData KeysData_260;
        /// <summary>
        /// The keysdata 261
        /// </summary>
        public ImGuiKeyData KeysData_261;
        /// <summary>
        /// The keysdata 262
        /// </summary>
        public ImGuiKeyData KeysData_262;
        /// <summary>
        /// The keysdata 263
        /// </summary>
        public ImGuiKeyData KeysData_263;
        /// <summary>
        /// The keysdata 264
        /// </summary>
        public ImGuiKeyData KeysData_264;
        /// <summary>
        /// The keysdata 265
        /// </summary>
        public ImGuiKeyData KeysData_265;
        /// <summary>
        /// The keysdata 266
        /// </summary>
        public ImGuiKeyData KeysData_266;
        /// <summary>
        /// The keysdata 267
        /// </summary>
        public ImGuiKeyData KeysData_267;
        /// <summary>
        /// The keysdata 268
        /// </summary>
        public ImGuiKeyData KeysData_268;
        /// <summary>
        /// The keysdata 269
        /// </summary>
        public ImGuiKeyData KeysData_269;
        /// <summary>
        /// The keysdata 270
        /// </summary>
        public ImGuiKeyData KeysData_270;
        /// <summary>
        /// The keysdata 271
        /// </summary>
        public ImGuiKeyData KeysData_271;
        /// <summary>
        /// The keysdata 272
        /// </summary>
        public ImGuiKeyData KeysData_272;
        /// <summary>
        /// The keysdata 273
        /// </summary>
        public ImGuiKeyData KeysData_273;
        /// <summary>
        /// The keysdata 274
        /// </summary>
        public ImGuiKeyData KeysData_274;
        /// <summary>
        /// The keysdata 275
        /// </summary>
        public ImGuiKeyData KeysData_275;
        /// <summary>
        /// The keysdata 276
        /// </summary>
        public ImGuiKeyData KeysData_276;
        /// <summary>
        /// The keysdata 277
        /// </summary>
        public ImGuiKeyData KeysData_277;
        /// <summary>
        /// The keysdata 278
        /// </summary>
        public ImGuiKeyData KeysData_278;
        /// <summary>
        /// The keysdata 279
        /// </summary>
        public ImGuiKeyData KeysData_279;
        /// <summary>
        /// The keysdata 280
        /// </summary>
        public ImGuiKeyData KeysData_280;
        /// <summary>
        /// The keysdata 281
        /// </summary>
        public ImGuiKeyData KeysData_281;
        /// <summary>
        /// The keysdata 282
        /// </summary>
        public ImGuiKeyData KeysData_282;
        /// <summary>
        /// The keysdata 283
        /// </summary>
        public ImGuiKeyData KeysData_283;
        /// <summary>
        /// The keysdata 284
        /// </summary>
        public ImGuiKeyData KeysData_284;
        /// <summary>
        /// The keysdata 285
        /// </summary>
        public ImGuiKeyData KeysData_285;
        /// <summary>
        /// The keysdata 286
        /// </summary>
        public ImGuiKeyData KeysData_286;
        /// <summary>
        /// The keysdata 287
        /// </summary>
        public ImGuiKeyData KeysData_287;
        /// <summary>
        /// The keysdata 288
        /// </summary>
        public ImGuiKeyData KeysData_288;
        /// <summary>
        /// The keysdata 289
        /// </summary>
        public ImGuiKeyData KeysData_289;
        /// <summary>
        /// The keysdata 290
        /// </summary>
        public ImGuiKeyData KeysData_290;
        /// <summary>
        /// The keysdata 291
        /// </summary>
        public ImGuiKeyData KeysData_291;
        /// <summary>
        /// The keysdata 292
        /// </summary>
        public ImGuiKeyData KeysData_292;
        /// <summary>
        /// The keysdata 293
        /// </summary>
        public ImGuiKeyData KeysData_293;
        /// <summary>
        /// The keysdata 294
        /// </summary>
        public ImGuiKeyData KeysData_294;
        /// <summary>
        /// The keysdata 295
        /// </summary>
        public ImGuiKeyData KeysData_295;
        /// <summary>
        /// The keysdata 296
        /// </summary>
        public ImGuiKeyData KeysData_296;
        /// <summary>
        /// The keysdata 297
        /// </summary>
        public ImGuiKeyData KeysData_297;
        /// <summary>
        /// The keysdata 298
        /// </summary>
        public ImGuiKeyData KeysData_298;
        /// <summary>
        /// The keysdata 299
        /// </summary>
        public ImGuiKeyData KeysData_299;
        /// <summary>
        /// The keysdata 300
        /// </summary>
        public ImGuiKeyData KeysData_300;
        /// <summary>
        /// The keysdata 301
        /// </summary>
        public ImGuiKeyData KeysData_301;
        /// <summary>
        /// The keysdata 302
        /// </summary>
        public ImGuiKeyData KeysData_302;
        /// <summary>
        /// The keysdata 303
        /// </summary>
        public ImGuiKeyData KeysData_303;
        /// <summary>
        /// The keysdata 304
        /// </summary>
        public ImGuiKeyData KeysData_304;
        /// <summary>
        /// The keysdata 305
        /// </summary>
        public ImGuiKeyData KeysData_305;
        /// <summary>
        /// The keysdata 306
        /// </summary>
        public ImGuiKeyData KeysData_306;
        /// <summary>
        /// The keysdata 307
        /// </summary>
        public ImGuiKeyData KeysData_307;
        /// <summary>
        /// The keysdata 308
        /// </summary>
        public ImGuiKeyData KeysData_308;
        /// <summary>
        /// The keysdata 309
        /// </summary>
        public ImGuiKeyData KeysData_309;
        /// <summary>
        /// The keysdata 310
        /// </summary>
        public ImGuiKeyData KeysData_310;
        /// <summary>
        /// The keysdata 311
        /// </summary>
        public ImGuiKeyData KeysData_311;
        /// <summary>
        /// The keysdata 312
        /// </summary>
        public ImGuiKeyData KeysData_312;
        /// <summary>
        /// The keysdata 313
        /// </summary>
        public ImGuiKeyData KeysData_313;
        /// <summary>
        /// The keysdata 314
        /// </summary>
        public ImGuiKeyData KeysData_314;
        /// <summary>
        /// The keysdata 315
        /// </summary>
        public ImGuiKeyData KeysData_315;
        /// <summary>
        /// The keysdata 316
        /// </summary>
        public ImGuiKeyData KeysData_316;
        /// <summary>
        /// The keysdata 317
        /// </summary>
        public ImGuiKeyData KeysData_317;
        /// <summary>
        /// The keysdata 318
        /// </summary>
        public ImGuiKeyData KeysData_318;
        /// <summary>
        /// The keysdata 319
        /// </summary>
        public ImGuiKeyData KeysData_319;
        /// <summary>
        /// The keysdata 320
        /// </summary>
        public ImGuiKeyData KeysData_320;
        /// <summary>
        /// The keysdata 321
        /// </summary>
        public ImGuiKeyData KeysData_321;
        /// <summary>
        /// The keysdata 322
        /// </summary>
        public ImGuiKeyData KeysData_322;
        /// <summary>
        /// The keysdata 323
        /// </summary>
        public ImGuiKeyData KeysData_323;
        /// <summary>
        /// The keysdata 324
        /// </summary>
        public ImGuiKeyData KeysData_324;
        /// <summary>
        /// The keysdata 325
        /// </summary>
        public ImGuiKeyData KeysData_325;
        /// <summary>
        /// The keysdata 326
        /// </summary>
        public ImGuiKeyData KeysData_326;
        /// <summary>
        /// The keysdata 327
        /// </summary>
        public ImGuiKeyData KeysData_327;
        /// <summary>
        /// The keysdata 328
        /// </summary>
        public ImGuiKeyData KeysData_328;
        /// <summary>
        /// The keysdata 329
        /// </summary>
        public ImGuiKeyData KeysData_329;
        /// <summary>
        /// The keysdata 330
        /// </summary>
        public ImGuiKeyData KeysData_330;
        /// <summary>
        /// The keysdata 331
        /// </summary>
        public ImGuiKeyData KeysData_331;
        /// <summary>
        /// The keysdata 332
        /// </summary>
        public ImGuiKeyData KeysData_332;
        /// <summary>
        /// The keysdata 333
        /// </summary>
        public ImGuiKeyData KeysData_333;
        /// <summary>
        /// The keysdata 334
        /// </summary>
        public ImGuiKeyData KeysData_334;
        /// <summary>
        /// The keysdata 335
        /// </summary>
        public ImGuiKeyData KeysData_335;
        /// <summary>
        /// The keysdata 336
        /// </summary>
        public ImGuiKeyData KeysData_336;
        /// <summary>
        /// The keysdata 337
        /// </summary>
        public ImGuiKeyData KeysData_337;
        /// <summary>
        /// The keysdata 338
        /// </summary>
        public ImGuiKeyData KeysData_338;
        /// <summary>
        /// The keysdata 339
        /// </summary>
        public ImGuiKeyData KeysData_339;
        /// <summary>
        /// The keysdata 340
        /// </summary>
        public ImGuiKeyData KeysData_340;
        /// <summary>
        /// The keysdata 341
        /// </summary>
        public ImGuiKeyData KeysData_341;
        /// <summary>
        /// The keysdata 342
        /// </summary>
        public ImGuiKeyData KeysData_342;
        /// <summary>
        /// The keysdata 343
        /// </summary>
        public ImGuiKeyData KeysData_343;
        /// <summary>
        /// The keysdata 344
        /// </summary>
        public ImGuiKeyData KeysData_344;
        /// <summary>
        /// The keysdata 345
        /// </summary>
        public ImGuiKeyData KeysData_345;
        /// <summary>
        /// The keysdata 346
        /// </summary>
        public ImGuiKeyData KeysData_346;
        /// <summary>
        /// The keysdata 347
        /// </summary>
        public ImGuiKeyData KeysData_347;
        /// <summary>
        /// The keysdata 348
        /// </summary>
        public ImGuiKeyData KeysData_348;
        /// <summary>
        /// The keysdata 349
        /// </summary>
        public ImGuiKeyData KeysData_349;
        /// <summary>
        /// The keysdata 350
        /// </summary>
        public ImGuiKeyData KeysData_350;
        /// <summary>
        /// The keysdata 351
        /// </summary>
        public ImGuiKeyData KeysData_351;
        /// <summary>
        /// The keysdata 352
        /// </summary>
        public ImGuiKeyData KeysData_352;
        /// <summary>
        /// The keysdata 353
        /// </summary>
        public ImGuiKeyData KeysData_353;
        /// <summary>
        /// The keysdata 354
        /// </summary>
        public ImGuiKeyData KeysData_354;
        /// <summary>
        /// The keysdata 355
        /// </summary>
        public ImGuiKeyData KeysData_355;
        /// <summary>
        /// The keysdata 356
        /// </summary>
        public ImGuiKeyData KeysData_356;
        /// <summary>
        /// The keysdata 357
        /// </summary>
        public ImGuiKeyData KeysData_357;
        /// <summary>
        /// The keysdata 358
        /// </summary>
        public ImGuiKeyData KeysData_358;
        /// <summary>
        /// The keysdata 359
        /// </summary>
        public ImGuiKeyData KeysData_359;
        /// <summary>
        /// The keysdata 360
        /// </summary>
        public ImGuiKeyData KeysData_360;
        /// <summary>
        /// The keysdata 361
        /// </summary>
        public ImGuiKeyData KeysData_361;
        /// <summary>
        /// The keysdata 362
        /// </summary>
        public ImGuiKeyData KeysData_362;
        /// <summary>
        /// The keysdata 363
        /// </summary>
        public ImGuiKeyData KeysData_363;
        /// <summary>
        /// The keysdata 364
        /// </summary>
        public ImGuiKeyData KeysData_364;
        /// <summary>
        /// The keysdata 365
        /// </summary>
        public ImGuiKeyData KeysData_365;
        /// <summary>
        /// The keysdata 366
        /// </summary>
        public ImGuiKeyData KeysData_366;
        /// <summary>
        /// The keysdata 367
        /// </summary>
        public ImGuiKeyData KeysData_367;
        /// <summary>
        /// The keysdata 368
        /// </summary>
        public ImGuiKeyData KeysData_368;
        /// <summary>
        /// The keysdata 369
        /// </summary>
        public ImGuiKeyData KeysData_369;
        /// <summary>
        /// The keysdata 370
        /// </summary>
        public ImGuiKeyData KeysData_370;
        /// <summary>
        /// The keysdata 371
        /// </summary>
        public ImGuiKeyData KeysData_371;
        /// <summary>
        /// The keysdata 372
        /// </summary>
        public ImGuiKeyData KeysData_372;
        /// <summary>
        /// The keysdata 373
        /// </summary>
        public ImGuiKeyData KeysData_373;
        /// <summary>
        /// The keysdata 374
        /// </summary>
        public ImGuiKeyData KeysData_374;
        /// <summary>
        /// The keysdata 375
        /// </summary>
        public ImGuiKeyData KeysData_375;
        /// <summary>
        /// The keysdata 376
        /// </summary>
        public ImGuiKeyData KeysData_376;
        /// <summary>
        /// The keysdata 377
        /// </summary>
        public ImGuiKeyData KeysData_377;
        /// <summary>
        /// The keysdata 378
        /// </summary>
        public ImGuiKeyData KeysData_378;
        /// <summary>
        /// The keysdata 379
        /// </summary>
        public ImGuiKeyData KeysData_379;
        /// <summary>
        /// The keysdata 380
        /// </summary>
        public ImGuiKeyData KeysData_380;
        /// <summary>
        /// The keysdata 381
        /// </summary>
        public ImGuiKeyData KeysData_381;
        /// <summary>
        /// The keysdata 382
        /// </summary>
        public ImGuiKeyData KeysData_382;
        /// <summary>
        /// The keysdata 383
        /// </summary>
        public ImGuiKeyData KeysData_383;
        /// <summary>
        /// The keysdata 384
        /// </summary>
        public ImGuiKeyData KeysData_384;
        /// <summary>
        /// The keysdata 385
        /// </summary>
        public ImGuiKeyData KeysData_385;
        /// <summary>
        /// The keysdata 386
        /// </summary>
        public ImGuiKeyData KeysData_386;
        /// <summary>
        /// The keysdata 387
        /// </summary>
        public ImGuiKeyData KeysData_387;
        /// <summary>
        /// The keysdata 388
        /// </summary>
        public ImGuiKeyData KeysData_388;
        /// <summary>
        /// The keysdata 389
        /// </summary>
        public ImGuiKeyData KeysData_389;
        /// <summary>
        /// The keysdata 390
        /// </summary>
        public ImGuiKeyData KeysData_390;
        /// <summary>
        /// The keysdata 391
        /// </summary>
        public ImGuiKeyData KeysData_391;
        /// <summary>
        /// The keysdata 392
        /// </summary>
        public ImGuiKeyData KeysData_392;
        /// <summary>
        /// The keysdata 393
        /// </summary>
        public ImGuiKeyData KeysData_393;
        /// <summary>
        /// The keysdata 394
        /// </summary>
        public ImGuiKeyData KeysData_394;
        /// <summary>
        /// The keysdata 395
        /// </summary>
        public ImGuiKeyData KeysData_395;
        /// <summary>
        /// The keysdata 396
        /// </summary>
        public ImGuiKeyData KeysData_396;
        /// <summary>
        /// The keysdata 397
        /// </summary>
        public ImGuiKeyData KeysData_397;
        /// <summary>
        /// The keysdata 398
        /// </summary>
        public ImGuiKeyData KeysData_398;
        /// <summary>
        /// The keysdata 399
        /// </summary>
        public ImGuiKeyData KeysData_399;
        /// <summary>
        /// The keysdata 400
        /// </summary>
        public ImGuiKeyData KeysData_400;
        /// <summary>
        /// The keysdata 401
        /// </summary>
        public ImGuiKeyData KeysData_401;
        /// <summary>
        /// The keysdata 402
        /// </summary>
        public ImGuiKeyData KeysData_402;
        /// <summary>
        /// The keysdata 403
        /// </summary>
        public ImGuiKeyData KeysData_403;
        /// <summary>
        /// The keysdata 404
        /// </summary>
        public ImGuiKeyData KeysData_404;
        /// <summary>
        /// The keysdata 405
        /// </summary>
        public ImGuiKeyData KeysData_405;
        /// <summary>
        /// The keysdata 406
        /// </summary>
        public ImGuiKeyData KeysData_406;
        /// <summary>
        /// The keysdata 407
        /// </summary>
        public ImGuiKeyData KeysData_407;
        /// <summary>
        /// The keysdata 408
        /// </summary>
        public ImGuiKeyData KeysData_408;
        /// <summary>
        /// The keysdata 409
        /// </summary>
        public ImGuiKeyData KeysData_409;
        /// <summary>
        /// The keysdata 410
        /// </summary>
        public ImGuiKeyData KeysData_410;
        /// <summary>
        /// The keysdata 411
        /// </summary>
        public ImGuiKeyData KeysData_411;
        /// <summary>
        /// The keysdata 412
        /// </summary>
        public ImGuiKeyData KeysData_412;
        /// <summary>
        /// The keysdata 413
        /// </summary>
        public ImGuiKeyData KeysData_413;
        /// <summary>
        /// The keysdata 414
        /// </summary>
        public ImGuiKeyData KeysData_414;
        /// <summary>
        /// The keysdata 415
        /// </summary>
        public ImGuiKeyData KeysData_415;
        /// <summary>
        /// The keysdata 416
        /// </summary>
        public ImGuiKeyData KeysData_416;
        /// <summary>
        /// The keysdata 417
        /// </summary>
        public ImGuiKeyData KeysData_417;
        /// <summary>
        /// The keysdata 418
        /// </summary>
        public ImGuiKeyData KeysData_418;
        /// <summary>
        /// The keysdata 419
        /// </summary>
        public ImGuiKeyData KeysData_419;
        /// <summary>
        /// The keysdata 420
        /// </summary>
        public ImGuiKeyData KeysData_420;
        /// <summary>
        /// The keysdata 421
        /// </summary>
        public ImGuiKeyData KeysData_421;
        /// <summary>
        /// The keysdata 422
        /// </summary>
        public ImGuiKeyData KeysData_422;
        /// <summary>
        /// The keysdata 423
        /// </summary>
        public ImGuiKeyData KeysData_423;
        /// <summary>
        /// The keysdata 424
        /// </summary>
        public ImGuiKeyData KeysData_424;
        /// <summary>
        /// The keysdata 425
        /// </summary>
        public ImGuiKeyData KeysData_425;
        /// <summary>
        /// The keysdata 426
        /// </summary>
        public ImGuiKeyData KeysData_426;
        /// <summary>
        /// The keysdata 427
        /// </summary>
        public ImGuiKeyData KeysData_427;
        /// <summary>
        /// The keysdata 428
        /// </summary>
        public ImGuiKeyData KeysData_428;
        /// <summary>
        /// The keysdata 429
        /// </summary>
        public ImGuiKeyData KeysData_429;
        /// <summary>
        /// The keysdata 430
        /// </summary>
        public ImGuiKeyData KeysData_430;
        /// <summary>
        /// The keysdata 431
        /// </summary>
        public ImGuiKeyData KeysData_431;
        /// <summary>
        /// The keysdata 432
        /// </summary>
        public ImGuiKeyData KeysData_432;
        /// <summary>
        /// The keysdata 433
        /// </summary>
        public ImGuiKeyData KeysData_433;
        /// <summary>
        /// The keysdata 434
        /// </summary>
        public ImGuiKeyData KeysData_434;
        /// <summary>
        /// The keysdata 435
        /// </summary>
        public ImGuiKeyData KeysData_435;
        /// <summary>
        /// The keysdata 436
        /// </summary>
        public ImGuiKeyData KeysData_436;
        /// <summary>
        /// The keysdata 437
        /// </summary>
        public ImGuiKeyData KeysData_437;
        /// <summary>
        /// The keysdata 438
        /// </summary>
        public ImGuiKeyData KeysData_438;
        /// <summary>
        /// The keysdata 439
        /// </summary>
        public ImGuiKeyData KeysData_439;
        /// <summary>
        /// The keysdata 440
        /// </summary>
        public ImGuiKeyData KeysData_440;
        /// <summary>
        /// The keysdata 441
        /// </summary>
        public ImGuiKeyData KeysData_441;
        /// <summary>
        /// The keysdata 442
        /// </summary>
        public ImGuiKeyData KeysData_442;
        /// <summary>
        /// The keysdata 443
        /// </summary>
        public ImGuiKeyData KeysData_443;
        /// <summary>
        /// The keysdata 444
        /// </summary>
        public ImGuiKeyData KeysData_444;
        /// <summary>
        /// The keysdata 445
        /// </summary>
        public ImGuiKeyData KeysData_445;
        /// <summary>
        /// The keysdata 446
        /// </summary>
        public ImGuiKeyData KeysData_446;
        /// <summary>
        /// The keysdata 447
        /// </summary>
        public ImGuiKeyData KeysData_447;
        /// <summary>
        /// The keysdata 448
        /// </summary>
        public ImGuiKeyData KeysData_448;
        /// <summary>
        /// The keysdata 449
        /// </summary>
        public ImGuiKeyData KeysData_449;
        /// <summary>
        /// The keysdata 450
        /// </summary>
        public ImGuiKeyData KeysData_450;
        /// <summary>
        /// The keysdata 451
        /// </summary>
        public ImGuiKeyData KeysData_451;
        /// <summary>
        /// The keysdata 452
        /// </summary>
        public ImGuiKeyData KeysData_452;
        /// <summary>
        /// The keysdata 453
        /// </summary>
        public ImGuiKeyData KeysData_453;
        /// <summary>
        /// The keysdata 454
        /// </summary>
        public ImGuiKeyData KeysData_454;
        /// <summary>
        /// The keysdata 455
        /// </summary>
        public ImGuiKeyData KeysData_455;
        /// <summary>
        /// The keysdata 456
        /// </summary>
        public ImGuiKeyData KeysData_456;
        /// <summary>
        /// The keysdata 457
        /// </summary>
        public ImGuiKeyData KeysData_457;
        /// <summary>
        /// The keysdata 458
        /// </summary>
        public ImGuiKeyData KeysData_458;
        /// <summary>
        /// The keysdata 459
        /// </summary>
        public ImGuiKeyData KeysData_459;
        /// <summary>
        /// The keysdata 460
        /// </summary>
        public ImGuiKeyData KeysData_460;
        /// <summary>
        /// The keysdata 461
        /// </summary>
        public ImGuiKeyData KeysData_461;
        /// <summary>
        /// The keysdata 462
        /// </summary>
        public ImGuiKeyData KeysData_462;
        /// <summary>
        /// The keysdata 463
        /// </summary>
        public ImGuiKeyData KeysData_463;
        /// <summary>
        /// The keysdata 464
        /// </summary>
        public ImGuiKeyData KeysData_464;
        /// <summary>
        /// The keysdata 465
        /// </summary>
        public ImGuiKeyData KeysData_465;
        /// <summary>
        /// The keysdata 466
        /// </summary>
        public ImGuiKeyData KeysData_466;
        /// <summary>
        /// The keysdata 467
        /// </summary>
        public ImGuiKeyData KeysData_467;
        /// <summary>
        /// The keysdata 468
        /// </summary>
        public ImGuiKeyData KeysData_468;
        /// <summary>
        /// The keysdata 469
        /// </summary>
        public ImGuiKeyData KeysData_469;
        /// <summary>
        /// The keysdata 470
        /// </summary>
        public ImGuiKeyData KeysData_470;
        /// <summary>
        /// The keysdata 471
        /// </summary>
        public ImGuiKeyData KeysData_471;
        /// <summary>
        /// The keysdata 472
        /// </summary>
        public ImGuiKeyData KeysData_472;
        /// <summary>
        /// The keysdata 473
        /// </summary>
        public ImGuiKeyData KeysData_473;
        /// <summary>
        /// The keysdata 474
        /// </summary>
        public ImGuiKeyData KeysData_474;
        /// <summary>
        /// The keysdata 475
        /// </summary>
        public ImGuiKeyData KeysData_475;
        /// <summary>
        /// The keysdata 476
        /// </summary>
        public ImGuiKeyData KeysData_476;
        /// <summary>
        /// The keysdata 477
        /// </summary>
        public ImGuiKeyData KeysData_477;
        /// <summary>
        /// The keysdata 478
        /// </summary>
        public ImGuiKeyData KeysData_478;
        /// <summary>
        /// The keysdata 479
        /// </summary>
        public ImGuiKeyData KeysData_479;
        /// <summary>
        /// The keysdata 480
        /// </summary>
        public ImGuiKeyData KeysData_480;
        /// <summary>
        /// The keysdata 481
        /// </summary>
        public ImGuiKeyData KeysData_481;
        /// <summary>
        /// The keysdata 482
        /// </summary>
        public ImGuiKeyData KeysData_482;
        /// <summary>
        /// The keysdata 483
        /// </summary>
        public ImGuiKeyData KeysData_483;
        /// <summary>
        /// The keysdata 484
        /// </summary>
        public ImGuiKeyData KeysData_484;
        /// <summary>
        /// The keysdata 485
        /// </summary>
        public ImGuiKeyData KeysData_485;
        /// <summary>
        /// The keysdata 486
        /// </summary>
        public ImGuiKeyData KeysData_486;
        /// <summary>
        /// The keysdata 487
        /// </summary>
        public ImGuiKeyData KeysData_487;
        /// <summary>
        /// The keysdata 488
        /// </summary>
        public ImGuiKeyData KeysData_488;
        /// <summary>
        /// The keysdata 489
        /// </summary>
        public ImGuiKeyData KeysData_489;
        /// <summary>
        /// The keysdata 490
        /// </summary>
        public ImGuiKeyData KeysData_490;
        /// <summary>
        /// The keysdata 491
        /// </summary>
        public ImGuiKeyData KeysData_491;
        /// <summary>
        /// The keysdata 492
        /// </summary>
        public ImGuiKeyData KeysData_492;
        /// <summary>
        /// The keysdata 493
        /// </summary>
        public ImGuiKeyData KeysData_493;
        /// <summary>
        /// The keysdata 494
        /// </summary>
        public ImGuiKeyData KeysData_494;
        /// <summary>
        /// The keysdata 495
        /// </summary>
        public ImGuiKeyData KeysData_495;
        /// <summary>
        /// The keysdata 496
        /// </summary>
        public ImGuiKeyData KeysData_496;
        /// <summary>
        /// The keysdata 497
        /// </summary>
        public ImGuiKeyData KeysData_497;
        /// <summary>
        /// The keysdata 498
        /// </summary>
        public ImGuiKeyData KeysData_498;
        /// <summary>
        /// The keysdata 499
        /// </summary>
        public ImGuiKeyData KeysData_499;
        /// <summary>
        /// The keysdata 500
        /// </summary>
        public ImGuiKeyData KeysData_500;
        /// <summary>
        /// The keysdata 501
        /// </summary>
        public ImGuiKeyData KeysData_501;
        /// <summary>
        /// The keysdata 502
        /// </summary>
        public ImGuiKeyData KeysData_502;
        /// <summary>
        /// The keysdata 503
        /// </summary>
        public ImGuiKeyData KeysData_503;
        /// <summary>
        /// The keysdata 504
        /// </summary>
        public ImGuiKeyData KeysData_504;
        /// <summary>
        /// The keysdata 505
        /// </summary>
        public ImGuiKeyData KeysData_505;
        /// <summary>
        /// The keysdata 506
        /// </summary>
        public ImGuiKeyData KeysData_506;
        /// <summary>
        /// The keysdata 507
        /// </summary>
        public ImGuiKeyData KeysData_507;
        /// <summary>
        /// The keysdata 508
        /// </summary>
        public ImGuiKeyData KeysData_508;
        /// <summary>
        /// The keysdata 509
        /// </summary>
        public ImGuiKeyData KeysData_509;
        /// <summary>
        /// The keysdata 510
        /// </summary>
        public ImGuiKeyData KeysData_510;
        /// <summary>
        /// The keysdata 511
        /// </summary>
        public ImGuiKeyData KeysData_511;
        /// <summary>
        /// The keysdata 512
        /// </summary>
        public ImGuiKeyData KeysData_512;
        /// <summary>
        /// The keysdata 513
        /// </summary>
        public ImGuiKeyData KeysData_513;
        /// <summary>
        /// The keysdata 514
        /// </summary>
        public ImGuiKeyData KeysData_514;
        /// <summary>
        /// The keysdata 515
        /// </summary>
        public ImGuiKeyData KeysData_515;
        /// <summary>
        /// The keysdata 516
        /// </summary>
        public ImGuiKeyData KeysData_516;
        /// <summary>
        /// The keysdata 517
        /// </summary>
        public ImGuiKeyData KeysData_517;
        /// <summary>
        /// The keysdata 518
        /// </summary>
        public ImGuiKeyData KeysData_518;
        /// <summary>
        /// The keysdata 519
        /// </summary>
        public ImGuiKeyData KeysData_519;
        /// <summary>
        /// The keysdata 520
        /// </summary>
        public ImGuiKeyData KeysData_520;
        /// <summary>
        /// The keysdata 521
        /// </summary>
        public ImGuiKeyData KeysData_521;
        /// <summary>
        /// The keysdata 522
        /// </summary>
        public ImGuiKeyData KeysData_522;
        /// <summary>
        /// The keysdata 523
        /// </summary>
        public ImGuiKeyData KeysData_523;
        /// <summary>
        /// The keysdata 524
        /// </summary>
        public ImGuiKeyData KeysData_524;
        /// <summary>
        /// The keysdata 525
        /// </summary>
        public ImGuiKeyData KeysData_525;
        /// <summary>
        /// The keysdata 526
        /// </summary>
        public ImGuiKeyData KeysData_526;
        /// <summary>
        /// The keysdata 527
        /// </summary>
        public ImGuiKeyData KeysData_527;
        /// <summary>
        /// The keysdata 528
        /// </summary>
        public ImGuiKeyData KeysData_528;
        /// <summary>
        /// The keysdata 529
        /// </summary>
        public ImGuiKeyData KeysData_529;
        /// <summary>
        /// The keysdata 530
        /// </summary>
        public ImGuiKeyData KeysData_530;
        /// <summary>
        /// The keysdata 531
        /// </summary>
        public ImGuiKeyData KeysData_531;
        /// <summary>
        /// The keysdata 532
        /// </summary>
        public ImGuiKeyData KeysData_532;
        /// <summary>
        /// The keysdata 533
        /// </summary>
        public ImGuiKeyData KeysData_533;
        /// <summary>
        /// The keysdata 534
        /// </summary>
        public ImGuiKeyData KeysData_534;
        /// <summary>
        /// The keysdata 535
        /// </summary>
        public ImGuiKeyData KeysData_535;
        /// <summary>
        /// The keysdata 536
        /// </summary>
        public ImGuiKeyData KeysData_536;
        /// <summary>
        /// The keysdata 537
        /// </summary>
        public ImGuiKeyData KeysData_537;
        /// <summary>
        /// The keysdata 538
        /// </summary>
        public ImGuiKeyData KeysData_538;
        /// <summary>
        /// The keysdata 539
        /// </summary>
        public ImGuiKeyData KeysData_539;
        /// <summary>
        /// The keysdata 540
        /// </summary>
        public ImGuiKeyData KeysData_540;
        /// <summary>
        /// The keysdata 541
        /// </summary>
        public ImGuiKeyData KeysData_541;
        /// <summary>
        /// The keysdata 542
        /// </summary>
        public ImGuiKeyData KeysData_542;
        /// <summary>
        /// The keysdata 543
        /// </summary>
        public ImGuiKeyData KeysData_543;
        /// <summary>
        /// The keysdata 544
        /// </summary>
        public ImGuiKeyData KeysData_544;
        /// <summary>
        /// The keysdata 545
        /// </summary>
        public ImGuiKeyData KeysData_545;
        /// <summary>
        /// The keysdata 546
        /// </summary>
        public ImGuiKeyData KeysData_546;
        /// <summary>
        /// The keysdata 547
        /// </summary>
        public ImGuiKeyData KeysData_547;
        /// <summary>
        /// The keysdata 548
        /// </summary>
        public ImGuiKeyData KeysData_548;
        /// <summary>
        /// The keysdata 549
        /// </summary>
        public ImGuiKeyData KeysData_549;
        /// <summary>
        /// The keysdata 550
        /// </summary>
        public ImGuiKeyData KeysData_550;
        /// <summary>
        /// The keysdata 551
        /// </summary>
        public ImGuiKeyData KeysData_551;
        /// <summary>
        /// The keysdata 552
        /// </summary>
        public ImGuiKeyData KeysData_552;
        /// <summary>
        /// The keysdata 553
        /// </summary>
        public ImGuiKeyData KeysData_553;
        /// <summary>
        /// The keysdata 554
        /// </summary>
        public ImGuiKeyData KeysData_554;
        /// <summary>
        /// The keysdata 555
        /// </summary>
        public ImGuiKeyData KeysData_555;
        /// <summary>
        /// The keysdata 556
        /// </summary>
        public ImGuiKeyData KeysData_556;
        /// <summary>
        /// The keysdata 557
        /// </summary>
        public ImGuiKeyData KeysData_557;
        /// <summary>
        /// The keysdata 558
        /// </summary>
        public ImGuiKeyData KeysData_558;
        /// <summary>
        /// The keysdata 559
        /// </summary>
        public ImGuiKeyData KeysData_559;
        /// <summary>
        /// The keysdata 560
        /// </summary>
        public ImGuiKeyData KeysData_560;
        /// <summary>
        /// The keysdata 561
        /// </summary>
        public ImGuiKeyData KeysData_561;
        /// <summary>
        /// The keysdata 562
        /// </summary>
        public ImGuiKeyData KeysData_562;
        /// <summary>
        /// The keysdata 563
        /// </summary>
        public ImGuiKeyData KeysData_563;
        /// <summary>
        /// The keysdata 564
        /// </summary>
        public ImGuiKeyData KeysData_564;
        /// <summary>
        /// The keysdata 565
        /// </summary>
        public ImGuiKeyData KeysData_565;
        /// <summary>
        /// The keysdata 566
        /// </summary>
        public ImGuiKeyData KeysData_566;
        /// <summary>
        /// The keysdata 567
        /// </summary>
        public ImGuiKeyData KeysData_567;
        /// <summary>
        /// The keysdata 568
        /// </summary>
        public ImGuiKeyData KeysData_568;
        /// <summary>
        /// The keysdata 569
        /// </summary>
        public ImGuiKeyData KeysData_569;
        /// <summary>
        /// The keysdata 570
        /// </summary>
        public ImGuiKeyData KeysData_570;
        /// <summary>
        /// The keysdata 571
        /// </summary>
        public ImGuiKeyData KeysData_571;
        /// <summary>
        /// The keysdata 572
        /// </summary>
        public ImGuiKeyData KeysData_572;
        /// <summary>
        /// The keysdata 573
        /// </summary>
        public ImGuiKeyData KeysData_573;
        /// <summary>
        /// The keysdata 574
        /// </summary>
        public ImGuiKeyData KeysData_574;
        /// <summary>
        /// The keysdata 575
        /// </summary>
        public ImGuiKeyData KeysData_575;
        /// <summary>
        /// The keysdata 576
        /// </summary>
        public ImGuiKeyData KeysData_576;
        /// <summary>
        /// The keysdata 577
        /// </summary>
        public ImGuiKeyData KeysData_577;
        /// <summary>
        /// The keysdata 578
        /// </summary>
        public ImGuiKeyData KeysData_578;
        /// <summary>
        /// The keysdata 579
        /// </summary>
        public ImGuiKeyData KeysData_579;
        /// <summary>
        /// The keysdata 580
        /// </summary>
        public ImGuiKeyData KeysData_580;
        /// <summary>
        /// The keysdata 581
        /// </summary>
        public ImGuiKeyData KeysData_581;
        /// <summary>
        /// The keysdata 582
        /// </summary>
        public ImGuiKeyData KeysData_582;
        /// <summary>
        /// The keysdata 583
        /// </summary>
        public ImGuiKeyData KeysData_583;
        /// <summary>
        /// The keysdata 584
        /// </summary>
        public ImGuiKeyData KeysData_584;
        /// <summary>
        /// The keysdata 585
        /// </summary>
        public ImGuiKeyData KeysData_585;
        /// <summary>
        /// The keysdata 586
        /// </summary>
        public ImGuiKeyData KeysData_586;
        /// <summary>
        /// The keysdata 587
        /// </summary>
        public ImGuiKeyData KeysData_587;
        /// <summary>
        /// The keysdata 588
        /// </summary>
        public ImGuiKeyData KeysData_588;
        /// <summary>
        /// The keysdata 589
        /// </summary>
        public ImGuiKeyData KeysData_589;
        /// <summary>
        /// The keysdata 590
        /// </summary>
        public ImGuiKeyData KeysData_590;
        /// <summary>
        /// The keysdata 591
        /// </summary>
        public ImGuiKeyData KeysData_591;
        /// <summary>
        /// The keysdata 592
        /// </summary>
        public ImGuiKeyData KeysData_592;
        /// <summary>
        /// The keysdata 593
        /// </summary>
        public ImGuiKeyData KeysData_593;
        /// <summary>
        /// The keysdata 594
        /// </summary>
        public ImGuiKeyData KeysData_594;
        /// <summary>
        /// The keysdata 595
        /// </summary>
        public ImGuiKeyData KeysData_595;
        /// <summary>
        /// The keysdata 596
        /// </summary>
        public ImGuiKeyData KeysData_596;
        /// <summary>
        /// The keysdata 597
        /// </summary>
        public ImGuiKeyData KeysData_597;
        /// <summary>
        /// The keysdata 598
        /// </summary>
        public ImGuiKeyData KeysData_598;
        /// <summary>
        /// The keysdata 599
        /// </summary>
        public ImGuiKeyData KeysData_599;
        /// <summary>
        /// The keysdata 600
        /// </summary>
        public ImGuiKeyData KeysData_600;
        /// <summary>
        /// The keysdata 601
        /// </summary>
        public ImGuiKeyData KeysData_601;
        /// <summary>
        /// The keysdata 602
        /// </summary>
        public ImGuiKeyData KeysData_602;
        /// <summary>
        /// The keysdata 603
        /// </summary>
        public ImGuiKeyData KeysData_603;
        /// <summary>
        /// The keysdata 604
        /// </summary>
        public ImGuiKeyData KeysData_604;
        /// <summary>
        /// The keysdata 605
        /// </summary>
        public ImGuiKeyData KeysData_605;
        /// <summary>
        /// The keysdata 606
        /// </summary>
        public ImGuiKeyData KeysData_606;
        /// <summary>
        /// The keysdata 607
        /// </summary>
        public ImGuiKeyData KeysData_607;
        /// <summary>
        /// The keysdata 608
        /// </summary>
        public ImGuiKeyData KeysData_608;
        /// <summary>
        /// The keysdata 609
        /// </summary>
        public ImGuiKeyData KeysData_609;
        /// <summary>
        /// The keysdata 610
        /// </summary>
        public ImGuiKeyData KeysData_610;
        /// <summary>
        /// The keysdata 611
        /// </summary>
        public ImGuiKeyData KeysData_611;
        /// <summary>
        /// The keysdata 612
        /// </summary>
        public ImGuiKeyData KeysData_612;
        /// <summary>
        /// The keysdata 613
        /// </summary>
        public ImGuiKeyData KeysData_613;
        /// <summary>
        /// The keysdata 614
        /// </summary>
        public ImGuiKeyData KeysData_614;
        /// <summary>
        /// The keysdata 615
        /// </summary>
        public ImGuiKeyData KeysData_615;
        /// <summary>
        /// The keysdata 616
        /// </summary>
        public ImGuiKeyData KeysData_616;
        /// <summary>
        /// The keysdata 617
        /// </summary>
        public ImGuiKeyData KeysData_617;
        /// <summary>
        /// The keysdata 618
        /// </summary>
        public ImGuiKeyData KeysData_618;
        /// <summary>
        /// The keysdata 619
        /// </summary>
        public ImGuiKeyData KeysData_619;
        /// <summary>
        /// The keysdata 620
        /// </summary>
        public ImGuiKeyData KeysData_620;
        /// <summary>
        /// The keysdata 621
        /// </summary>
        public ImGuiKeyData KeysData_621;
        /// <summary>
        /// The keysdata 622
        /// </summary>
        public ImGuiKeyData KeysData_622;
        /// <summary>
        /// The keysdata 623
        /// </summary>
        public ImGuiKeyData KeysData_623;
        /// <summary>
        /// The keysdata 624
        /// </summary>
        public ImGuiKeyData KeysData_624;
        /// <summary>
        /// The keysdata 625
        /// </summary>
        public ImGuiKeyData KeysData_625;
        /// <summary>
        /// The keysdata 626
        /// </summary>
        public ImGuiKeyData KeysData_626;
        /// <summary>
        /// The keysdata 627
        /// </summary>
        public ImGuiKeyData KeysData_627;
        /// <summary>
        /// The keysdata 628
        /// </summary>
        public ImGuiKeyData KeysData_628;
        /// <summary>
        /// The keysdata 629
        /// </summary>
        public ImGuiKeyData KeysData_629;
        /// <summary>
        /// The keysdata 630
        /// </summary>
        public ImGuiKeyData KeysData_630;
        /// <summary>
        /// The keysdata 631
        /// </summary>
        public ImGuiKeyData KeysData_631;
        /// <summary>
        /// The keysdata 632
        /// </summary>
        public ImGuiKeyData KeysData_632;
        /// <summary>
        /// The keysdata 633
        /// </summary>
        public ImGuiKeyData KeysData_633;
        /// <summary>
        /// The keysdata 634
        /// </summary>
        public ImGuiKeyData KeysData_634;
        /// <summary>
        /// The keysdata 635
        /// </summary>
        public ImGuiKeyData KeysData_635;
        /// <summary>
        /// The keysdata 636
        /// </summary>
        public ImGuiKeyData KeysData_636;
        /// <summary>
        /// The keysdata 637
        /// </summary>
        public ImGuiKeyData KeysData_637;
        /// <summary>
        /// The keysdata 638
        /// </summary>
        public ImGuiKeyData KeysData_638;
        /// <summary>
        /// The keysdata 639
        /// </summary>
        public ImGuiKeyData KeysData_639;
        /// <summary>
        /// The keysdata 640
        /// </summary>
        public ImGuiKeyData KeysData_640;
        /// <summary>
        /// The keysdata 641
        /// </summary>
        public ImGuiKeyData KeysData_641;
        /// <summary>
        /// The keysdata 642
        /// </summary>
        public ImGuiKeyData KeysData_642;
        /// <summary>
        /// The keysdata 643
        /// </summary>
        public ImGuiKeyData KeysData_643;
        /// <summary>
        /// The keysdata 644
        /// </summary>
        public ImGuiKeyData KeysData_644;
        /// <summary>
        /// The keysdata 645
        /// </summary>
        public ImGuiKeyData KeysData_645;
        /// <summary>
        /// The keysdata 646
        /// </summary>
        public ImGuiKeyData KeysData_646;
        /// <summary>
        /// The keysdata 647
        /// </summary>
        public ImGuiKeyData KeysData_647;
        /// <summary>
        /// The keysdata 648
        /// </summary>
        public ImGuiKeyData KeysData_648;
        /// <summary>
        /// The keysdata 649
        /// </summary>
        public ImGuiKeyData KeysData_649;
        /// <summary>
        /// The keysdata 650
        /// </summary>
        public ImGuiKeyData KeysData_650;
        /// <summary>
        /// The keysdata 651
        /// </summary>
        public ImGuiKeyData KeysData_651;
        /// <summary>
        /// The want capture mouse unless popup close
        /// </summary>
        public byte WantCaptureMouseUnlessPopupClose;
        /// <summary>
        /// The mouse pos prev
        /// </summary>
        public Vector2 MousePosPrev;
        /// <summary>
        /// The mouseclickedpos
        /// </summary>
        public Vector2 MouseClickedPos_0;
        /// <summary>
        /// The mouseclickedpos
        /// </summary>
        public Vector2 MouseClickedPos_1;
        /// <summary>
        /// The mouseclickedpos
        /// </summary>
        public Vector2 MouseClickedPos_2;
        /// <summary>
        /// The mouseclickedpos
        /// </summary>
        public Vector2 MouseClickedPos_3;
        /// <summary>
        /// The mouseclickedpos
        /// </summary>
        public Vector2 MouseClickedPos_4;
        /// <summary>
        /// The mouse clicked time
        /// </summary>
        public fixed double MouseClickedTime[5];
        /// <summary>
        /// The mouse clicked
        /// </summary>
        public fixed byte MouseClicked[5];
        /// <summary>
        /// The mouse double clicked
        /// </summary>
        public fixed byte MouseDoubleClicked[5];
        /// <summary>
        /// The mouse clicked count
        /// </summary>
        public fixed ushort MouseClickedCount[5];
        /// <summary>
        /// The mouse clicked last count
        /// </summary>
        public fixed ushort MouseClickedLastCount[5];
        /// <summary>
        /// The mouse released
        /// </summary>
        public fixed byte MouseReleased[5];
        /// <summary>
        /// The mouse down owned
        /// </summary>
        public fixed byte MouseDownOwned[5];
        /// <summary>
        /// The mouse down owned unless popup close
        /// </summary>
        public fixed byte MouseDownOwnedUnlessPopupClose[5];
        /// <summary>
        /// The mouse down duration
        /// </summary>
        public fixed float MouseDownDuration[5];
        /// <summary>
        /// The mouse down duration prev
        /// </summary>
        public fixed float MouseDownDurationPrev[5];
        /// <summary>
        /// The mousedragmaxdistanceabs
        /// </summary>
        public Vector2 MouseDragMaxDistanceAbs_0;
        /// <summary>
        /// The mousedragmaxdistanceabs
        /// </summary>
        public Vector2 MouseDragMaxDistanceAbs_1;
        /// <summary>
        /// The mousedragmaxdistanceabs
        /// </summary>
        public Vector2 MouseDragMaxDistanceAbs_2;
        /// <summary>
        /// The mousedragmaxdistanceabs
        /// </summary>
        public Vector2 MouseDragMaxDistanceAbs_3;
        /// <summary>
        /// The mousedragmaxdistanceabs
        /// </summary>
        public Vector2 MouseDragMaxDistanceAbs_4;
        /// <summary>
        /// The mouse drag max distance sqr
        /// </summary>
        public fixed float MouseDragMaxDistanceSqr[5];
        /// <summary>
        /// The pen pressure
        /// </summary>
        public float PenPressure;
        /// <summary>
        /// The app focus lost
        /// </summary>
        public byte AppFocusLost;
        /// <summary>
        /// The app accepting events
        /// </summary>
        public byte AppAcceptingEvents;
        /// <summary>
        /// The backend using legacy key arrays
        /// </summary>
        public sbyte BackendUsingLegacyKeyArrays;
        /// <summary>
        /// The backend using legacy nav input array
        /// </summary>
        public byte BackendUsingLegacyNavInputArray;
        /// <summary>
        /// The input queue surrogate
        /// </summary>
        public ushort InputQueueSurrogate;
        /// <summary>
        /// The input queue characters
        /// </summary>
        public ImVector InputQueueCharacters;
    }
    /// <summary>
    /// The im gui io ptr
    /// </summary>
    public unsafe partial struct ImGuiIOPtr
    {
        /// <summary>
        /// Gets the value of the native ptr
        /// </summary>
        public ImGuiIO* NativePtr { get; }
        /// <summary>
        /// Initializes a new instance of the <see cref="ImGuiIOPtr"/> class
        /// </summary>
        /// <param name="nativePtr">The native ptr</param>
        public ImGuiIOPtr(ImGuiIO* nativePtr) => NativePtr = nativePtr;
        /// <summary>
        /// Initializes a new instance of the <see cref="ImGuiIOPtr"/> class
        /// </summary>
        /// <param name="nativePtr">The native ptr</param>
        public ImGuiIOPtr(IntPtr nativePtr) => NativePtr = (ImGuiIO*)nativePtr;
        public static implicit operator ImGuiIOPtr(ImGuiIO* nativePtr) => new ImGuiIOPtr(nativePtr);
        public static implicit operator ImGuiIO* (ImGuiIOPtr wrappedPtr) => wrappedPtr.NativePtr;
        public static implicit operator ImGuiIOPtr(IntPtr nativePtr) => new ImGuiIOPtr(nativePtr);
        /// <summary>
        /// Gets the value of the config flags
        /// </summary>
        public ref ImGuiConfigFlags ConfigFlags => ref Unsafe.AsRef<ImGuiConfigFlags>(&NativePtr->ConfigFlags);
        /// <summary>
        /// Gets the value of the backend flags
        /// </summary>
        public ref ImGuiBackendFlags BackendFlags => ref Unsafe.AsRef<ImGuiBackendFlags>(&NativePtr->BackendFlags);
        /// <summary>
        /// Gets the value of the display size
        /// </summary>
        public ref Vector2 DisplaySize => ref Unsafe.AsRef<Vector2>(&NativePtr->DisplaySize);
        /// <summary>
        /// Gets the value of the delta time
        /// </summary>
        public ref float DeltaTime => ref Unsafe.AsRef<float>(&NativePtr->DeltaTime);
        /// <summary>
        /// Gets the value of the ini saving rate
        /// </summary>
        public ref float IniSavingRate => ref Unsafe.AsRef<float>(&NativePtr->IniSavingRate);
        /// <summary>
        /// Gets the value of the ini filename
        /// </summary>
        public NullTerminatedString IniFilename => new NullTerminatedString(NativePtr->IniFilename);
        /// <summary>
        /// Gets the value of the log filename
        /// </summary>
        public NullTerminatedString LogFilename => new NullTerminatedString(NativePtr->LogFilename);
        /// <summary>
        /// Gets the value of the mouse double click time
        /// </summary>
        public ref float MouseDoubleClickTime => ref Unsafe.AsRef<float>(&NativePtr->MouseDoubleClickTime);
        /// <summary>
        /// Gets the value of the mouse double click max dist
        /// </summary>
        public ref float MouseDoubleClickMaxDist => ref Unsafe.AsRef<float>(&NativePtr->MouseDoubleClickMaxDist);
        /// <summary>
        /// Gets the value of the mouse drag threshold
        /// </summary>
        public ref float MouseDragThreshold => ref Unsafe.AsRef<float>(&NativePtr->MouseDragThreshold);
        /// <summary>
        /// Gets the value of the key repeat delay
        /// </summary>
        public ref float KeyRepeatDelay => ref Unsafe.AsRef<float>(&NativePtr->KeyRepeatDelay);
        /// <summary>
        /// Gets the value of the key repeat rate
        /// </summary>
        public ref float KeyRepeatRate => ref Unsafe.AsRef<float>(&NativePtr->KeyRepeatRate);
        /// <summary>
        /// Gets the value of the hover delay normal
        /// </summary>
        public ref float HoverDelayNormal => ref Unsafe.AsRef<float>(&NativePtr->HoverDelayNormal);
        /// <summary>
        /// Gets the value of the hover delay short
        /// </summary>
        public ref float HoverDelayShort => ref Unsafe.AsRef<float>(&NativePtr->HoverDelayShort);
        /// <summary>
        /// Gets or sets the value of the user data
        /// </summary>
        public IntPtr UserData { get => (IntPtr)NativePtr->UserData; set => NativePtr->UserData = (void*)value; }
        /// <summary>
        /// Gets the value of the fonts
        /// </summary>
        public ImFontAtlasPtr Fonts => new ImFontAtlasPtr(NativePtr->Fonts);
        /// <summary>
        /// Gets the value of the font global scale
        /// </summary>
        public ref float FontGlobalScale => ref Unsafe.AsRef<float>(&NativePtr->FontGlobalScale);
        /// <summary>
        /// Gets the value of the font allow user scaling
        /// </summary>
        public ref bool FontAllowUserScaling => ref Unsafe.AsRef<bool>(&NativePtr->FontAllowUserScaling);
        /// <summary>
        /// Gets the value of the font default
        /// </summary>
        public ImFontPtr FontDefault => new ImFontPtr(NativePtr->FontDefault);
        /// <summary>
        /// Gets the value of the display framebuffer scale
        /// </summary>
        public ref Vector2 DisplayFramebufferScale => ref Unsafe.AsRef<Vector2>(&NativePtr->DisplayFramebufferScale);
        /// <summary>
        /// Gets the value of the config docking no split
        /// </summary>
        public ref bool ConfigDockingNoSplit => ref Unsafe.AsRef<bool>(&NativePtr->ConfigDockingNoSplit);
        /// <summary>
        /// Gets the value of the config docking with shift
        /// </summary>
        public ref bool ConfigDockingWithShift => ref Unsafe.AsRef<bool>(&NativePtr->ConfigDockingWithShift);
        /// <summary>
        /// Gets the value of the config docking always tab bar
        /// </summary>
        public ref bool ConfigDockingAlwaysTabBar => ref Unsafe.AsRef<bool>(&NativePtr->ConfigDockingAlwaysTabBar);
        /// <summary>
        /// Gets the value of the config docking transparent payload
        /// </summary>
        public ref bool ConfigDockingTransparentPayload => ref Unsafe.AsRef<bool>(&NativePtr->ConfigDockingTransparentPayload);
        /// <summary>
        /// Gets the value of the config viewports no auto merge
        /// </summary>
        public ref bool ConfigViewportsNoAutoMerge => ref Unsafe.AsRef<bool>(&NativePtr->ConfigViewportsNoAutoMerge);
        /// <summary>
        /// Gets the value of the config viewports no task bar icon
        /// </summary>
        public ref bool ConfigViewportsNoTaskBarIcon => ref Unsafe.AsRef<bool>(&NativePtr->ConfigViewportsNoTaskBarIcon);
        /// <summary>
        /// Gets the value of the config viewports no decoration
        /// </summary>
        public ref bool ConfigViewportsNoDecoration => ref Unsafe.AsRef<bool>(&NativePtr->ConfigViewportsNoDecoration);
        /// <summary>
        /// Gets the value of the config viewports no default parent
        /// </summary>
        public ref bool ConfigViewportsNoDefaultParent => ref Unsafe.AsRef<bool>(&NativePtr->ConfigViewportsNoDefaultParent);
        /// <summary>
        /// Gets the value of the mouse draw cursor
        /// </summary>
        public ref bool MouseDrawCursor => ref Unsafe.AsRef<bool>(&NativePtr->MouseDrawCursor);
        /// <summary>
        /// Gets the value of the config mac osx behaviors
        /// </summary>
        public ref bool ConfigMacOSXBehaviors => ref Unsafe.AsRef<bool>(&NativePtr->ConfigMacOSXBehaviors);
        /// <summary>
        /// Gets the value of the config input trickle event queue
        /// </summary>
        public ref bool ConfigInputTrickleEventQueue => ref Unsafe.AsRef<bool>(&NativePtr->ConfigInputTrickleEventQueue);
        /// <summary>
        /// Gets the value of the config input text cursor blink
        /// </summary>
        public ref bool ConfigInputTextCursorBlink => ref Unsafe.AsRef<bool>(&NativePtr->ConfigInputTextCursorBlink);
        /// <summary>
        /// Gets the value of the config input text enter keep active
        /// </summary>
        public ref bool ConfigInputTextEnterKeepActive => ref Unsafe.AsRef<bool>(&NativePtr->ConfigInputTextEnterKeepActive);
        /// <summary>
        /// Gets the value of the config drag click to input text
        /// </summary>
        public ref bool ConfigDragClickToInputText => ref Unsafe.AsRef<bool>(&NativePtr->ConfigDragClickToInputText);
        /// <summary>
        /// Gets the value of the config windows resize from edges
        /// </summary>
        public ref bool ConfigWindowsResizeFromEdges => ref Unsafe.AsRef<bool>(&NativePtr->ConfigWindowsResizeFromEdges);
        /// <summary>
        /// Gets the value of the config windows move from title bar only
        /// </summary>
        public ref bool ConfigWindowsMoveFromTitleBarOnly => ref Unsafe.AsRef<bool>(&NativePtr->ConfigWindowsMoveFromTitleBarOnly);
        /// <summary>
        /// Gets the value of the config memory compact timer
        /// </summary>
        public ref float ConfigMemoryCompactTimer => ref Unsafe.AsRef<float>(&NativePtr->ConfigMemoryCompactTimer);
        /// <summary>
        /// Gets the value of the backend platform name
        /// </summary>
        public NullTerminatedString BackendPlatformName => new NullTerminatedString(NativePtr->BackendPlatformName);
        /// <summary>
        /// Gets the value of the backend renderer name
        /// </summary>
        public NullTerminatedString BackendRendererName => new NullTerminatedString(NativePtr->BackendRendererName);
        /// <summary>
        /// Gets or sets the value of the backend platform user data
        /// </summary>
        public IntPtr BackendPlatformUserData { get => (IntPtr)NativePtr->BackendPlatformUserData; set => NativePtr->BackendPlatformUserData = (void*)value; }
        /// <summary>
        /// Gets or sets the value of the backend renderer user data
        /// </summary>
        public IntPtr BackendRendererUserData { get => (IntPtr)NativePtr->BackendRendererUserData; set => NativePtr->BackendRendererUserData = (void*)value; }
        /// <summary>
        /// Gets or sets the value of the backend language user data
        /// </summary>
        public IntPtr BackendLanguageUserData { get => (IntPtr)NativePtr->BackendLanguageUserData; set => NativePtr->BackendLanguageUserData = (void*)value; }
        /// <summary>
        /// Gets the value of the get clipboard text fn
        /// </summary>
        public ref IntPtr GetClipboardTextFn => ref Unsafe.AsRef<IntPtr>(&NativePtr->GetClipboardTextFn);
        /// <summary>
        /// Gets the value of the set clipboard text fn
        /// </summary>
        public ref IntPtr SetClipboardTextFn => ref Unsafe.AsRef<IntPtr>(&NativePtr->SetClipboardTextFn);
        /// <summary>
        /// Gets or sets the value of the clipboard user data
        /// </summary>
        public IntPtr ClipboardUserData { get => (IntPtr)NativePtr->ClipboardUserData; set => NativePtr->ClipboardUserData = (void*)value; }
        /// <summary>
        /// Gets the value of the set platform ime data fn
        /// </summary>
        public ref IntPtr SetPlatformImeDataFn => ref Unsafe.AsRef<IntPtr>(&NativePtr->SetPlatformImeDataFn);
        /// <summary>
        /// Gets or sets the value of the  unusedpadding
        /// </summary>
        public IntPtr _UnusedPadding { get => (IntPtr)NativePtr->_UnusedPadding; set => NativePtr->_UnusedPadding = (void*)value; }
        /// <summary>
        /// Gets the value of the want capture mouse
        /// </summary>
        public ref bool WantCaptureMouse => ref Unsafe.AsRef<bool>(&NativePtr->WantCaptureMouse);
        /// <summary>
        /// Gets the value of the want capture keyboard
        /// </summary>
        public ref bool WantCaptureKeyboard => ref Unsafe.AsRef<bool>(&NativePtr->WantCaptureKeyboard);
        /// <summary>
        /// Gets the value of the want text input
        /// </summary>
        public ref bool WantTextInput => ref Unsafe.AsRef<bool>(&NativePtr->WantTextInput);
        /// <summary>
        /// Gets the value of the want set mouse pos
        /// </summary>
        public ref bool WantSetMousePos => ref Unsafe.AsRef<bool>(&NativePtr->WantSetMousePos);
        /// <summary>
        /// Gets the value of the want save ini settings
        /// </summary>
        public ref bool WantSaveIniSettings => ref Unsafe.AsRef<bool>(&NativePtr->WantSaveIniSettings);
        /// <summary>
        /// Gets the value of the nav active
        /// </summary>
        public ref bool NavActive => ref Unsafe.AsRef<bool>(&NativePtr->NavActive);
        /// <summary>
        /// Gets the value of the nav visible
        /// </summary>
        public ref bool NavVisible => ref Unsafe.AsRef<bool>(&NativePtr->NavVisible);
        /// <summary>
        /// Gets the value of the framerate
        /// </summary>
        public ref float Framerate => ref Unsafe.AsRef<float>(&NativePtr->Framerate);
        /// <summary>
        /// Gets the value of the metrics render vertices
        /// </summary>
        public ref int MetricsRenderVertices => ref Unsafe.AsRef<int>(&NativePtr->MetricsRenderVertices);
        /// <summary>
        /// Gets the value of the metrics render indices
        /// </summary>
        public ref int MetricsRenderIndices => ref Unsafe.AsRef<int>(&NativePtr->MetricsRenderIndices);
        /// <summary>
        /// Gets the value of the metrics render windows
        /// </summary>
        public ref int MetricsRenderWindows => ref Unsafe.AsRef<int>(&NativePtr->MetricsRenderWindows);
        /// <summary>
        /// Gets the value of the metrics active windows
        /// </summary>
        public ref int MetricsActiveWindows => ref Unsafe.AsRef<int>(&NativePtr->MetricsActiveWindows);
        /// <summary>
        /// Gets the value of the metrics active allocations
        /// </summary>
        public ref int MetricsActiveAllocations => ref Unsafe.AsRef<int>(&NativePtr->MetricsActiveAllocations);
        /// <summary>
        /// Gets the value of the mouse delta
        /// </summary>
        public ref Vector2 MouseDelta => ref Unsafe.AsRef<Vector2>(&NativePtr->MouseDelta);
        /// <summary>
        /// Gets the value of the key map
        /// </summary>
        public RangeAccessor<int> KeyMap => new RangeAccessor<int>(NativePtr->KeyMap, 652);
        /// <summary>
        /// Gets the value of the keys down
        /// </summary>
        public RangeAccessor<bool> KeysDown => new RangeAccessor<bool>(NativePtr->KeysDown, 652);
        /// <summary>
        /// Gets the value of the nav inputs
        /// </summary>
        public RangeAccessor<float> NavInputs => new RangeAccessor<float>(NativePtr->NavInputs, 16);
        /// <summary>
        /// Gets the value of the mouse pos
        /// </summary>
        public ref Vector2 MousePos => ref Unsafe.AsRef<Vector2>(&NativePtr->MousePos);
        /// <summary>
        /// Gets the value of the mouse down
        /// </summary>
        public RangeAccessor<bool> MouseDown => new RangeAccessor<bool>(NativePtr->MouseDown, 5);
        /// <summary>
        /// Gets the value of the mouse wheel
        /// </summary>
        public ref float MouseWheel => ref Unsafe.AsRef<float>(&NativePtr->MouseWheel);
        /// <summary>
        /// Gets the value of the mouse wheel h
        /// </summary>
        public ref float MouseWheelH => ref Unsafe.AsRef<float>(&NativePtr->MouseWheelH);
        /// <summary>
        /// Gets the value of the mouse hovered viewport
        /// </summary>
        public ref uint MouseHoveredViewport => ref Unsafe.AsRef<uint>(&NativePtr->MouseHoveredViewport);
        /// <summary>
        /// Gets the value of the key ctrl
        /// </summary>
        public ref bool KeyCtrl => ref Unsafe.AsRef<bool>(&NativePtr->KeyCtrl);
        /// <summary>
        /// Gets the value of the key shift
        /// </summary>
        public ref bool KeyShift => ref Unsafe.AsRef<bool>(&NativePtr->KeyShift);
        /// <summary>
        /// Gets the value of the key alt
        /// </summary>
        public ref bool KeyAlt => ref Unsafe.AsRef<bool>(&NativePtr->KeyAlt);
        /// <summary>
        /// Gets the value of the key super
        /// </summary>
        public ref bool KeySuper => ref Unsafe.AsRef<bool>(&NativePtr->KeySuper);
        /// <summary>
        /// Gets the value of the key mods
        /// </summary>
        public ref ImGuiKey KeyMods => ref Unsafe.AsRef<ImGuiKey>(&NativePtr->KeyMods);
        /// <summary>
        /// Gets the value of the keys data
        /// </summary>
        public RangeAccessor<ImGuiKeyData> KeysData => new RangeAccessor<ImGuiKeyData>(&NativePtr->KeysData_0, 652);
        /// <summary>
        /// Gets the value of the want capture mouse unless popup close
        /// </summary>
        public ref bool WantCaptureMouseUnlessPopupClose => ref Unsafe.AsRef<bool>(&NativePtr->WantCaptureMouseUnlessPopupClose);
        /// <summary>
        /// Gets the value of the mouse pos prev
        /// </summary>
        public ref Vector2 MousePosPrev => ref Unsafe.AsRef<Vector2>(&NativePtr->MousePosPrev);
        /// <summary>
        /// Gets the value of the mouse clicked pos
        /// </summary>
        public RangeAccessor<Vector2> MouseClickedPos => new RangeAccessor<Vector2>(&NativePtr->MouseClickedPos_0, 5);
        /// <summary>
        /// Gets the value of the mouse clicked time
        /// </summary>
        public RangeAccessor<double> MouseClickedTime => new RangeAccessor<double>(NativePtr->MouseClickedTime, 5);
        /// <summary>
        /// Gets the value of the mouse clicked
        /// </summary>
        public RangeAccessor<bool> MouseClicked => new RangeAccessor<bool>(NativePtr->MouseClicked, 5);
        /// <summary>
        /// Gets the value of the mouse double clicked
        /// </summary>
        public RangeAccessor<bool> MouseDoubleClicked => new RangeAccessor<bool>(NativePtr->MouseDoubleClicked, 5);
        /// <summary>
        /// Gets the value of the mouse clicked count
        /// </summary>
        public RangeAccessor<ushort> MouseClickedCount => new RangeAccessor<ushort>(NativePtr->MouseClickedCount, 5);
        /// <summary>
        /// Gets the value of the mouse clicked last count
        /// </summary>
        public RangeAccessor<ushort> MouseClickedLastCount => new RangeAccessor<ushort>(NativePtr->MouseClickedLastCount, 5);
        /// <summary>
        /// Gets the value of the mouse released
        /// </summary>
        public RangeAccessor<bool> MouseReleased => new RangeAccessor<bool>(NativePtr->MouseReleased, 5);
        /// <summary>
        /// Gets the value of the mouse down owned
        /// </summary>
        public RangeAccessor<bool> MouseDownOwned => new RangeAccessor<bool>(NativePtr->MouseDownOwned, 5);
        /// <summary>
        /// Gets the value of the mouse down owned unless popup close
        /// </summary>
        public RangeAccessor<bool> MouseDownOwnedUnlessPopupClose => new RangeAccessor<bool>(NativePtr->MouseDownOwnedUnlessPopupClose, 5);
        /// <summary>
        /// Gets the value of the mouse down duration
        /// </summary>
        public RangeAccessor<float> MouseDownDuration => new RangeAccessor<float>(NativePtr->MouseDownDuration, 5);
        /// <summary>
        /// Gets the value of the mouse down duration prev
        /// </summary>
        public RangeAccessor<float> MouseDownDurationPrev => new RangeAccessor<float>(NativePtr->MouseDownDurationPrev, 5);
        /// <summary>
        /// Gets the value of the mouse drag max distance abs
        /// </summary>
        public RangeAccessor<Vector2> MouseDragMaxDistanceAbs => new RangeAccessor<Vector2>(&NativePtr->MouseDragMaxDistanceAbs_0, 5);
        /// <summary>
        /// Gets the value of the mouse drag max distance sqr
        /// </summary>
        public RangeAccessor<float> MouseDragMaxDistanceSqr => new RangeAccessor<float>(NativePtr->MouseDragMaxDistanceSqr, 5);
        /// <summary>
        /// Gets the value of the pen pressure
        /// </summary>
        public ref float PenPressure => ref Unsafe.AsRef<float>(&NativePtr->PenPressure);
        /// <summary>
        /// Gets the value of the app focus lost
        /// </summary>
        public ref bool AppFocusLost => ref Unsafe.AsRef<bool>(&NativePtr->AppFocusLost);
        /// <summary>
        /// Gets the value of the app accepting events
        /// </summary>
        public ref bool AppAcceptingEvents => ref Unsafe.AsRef<bool>(&NativePtr->AppAcceptingEvents);
        /// <summary>
        /// Gets the value of the backend using legacy key arrays
        /// </summary>
        public ref sbyte BackendUsingLegacyKeyArrays => ref Unsafe.AsRef<sbyte>(&NativePtr->BackendUsingLegacyKeyArrays);
        /// <summary>
        /// Gets the value of the backend using legacy nav input array
        /// </summary>
        public ref bool BackendUsingLegacyNavInputArray => ref Unsafe.AsRef<bool>(&NativePtr->BackendUsingLegacyNavInputArray);
        /// <summary>
        /// Gets the value of the input queue surrogate
        /// </summary>
        public ref ushort InputQueueSurrogate => ref Unsafe.AsRef<ushort>(&NativePtr->InputQueueSurrogate);
        /// <summary>
        /// Gets the value of the input queue characters
        /// </summary>
        public ImVector<ushort> InputQueueCharacters => new ImVector<ushort>(NativePtr->InputQueueCharacters);
        /// <summary>
        /// Adds the focus event using the specified focused
        /// </summary>
        /// <param name="focused">The focused</param>
        public void AddFocusEvent(bool focused)
        {
            byte native_focused = focused ? (byte)1 : (byte)0;
            ImGuiNative.ImGuiIO_AddFocusEvent((ImGuiIO*)(NativePtr), native_focused);
        }
        /// <summary>
        /// Adds the input character using the specified c
        /// </summary>
        /// <param name="c">The </param>
        public void AddInputCharacter(uint c)
        {
            ImGuiNative.ImGuiIO_AddInputCharacter((ImGuiIO*)(NativePtr), c);
        }
        /// <summary>
        /// Adds the input characters utf 8 using the specified str
        /// </summary>
        /// <param name="str">The str</param>
        public void AddInputCharactersUTF8(string str)
        {
            byte* native_str;
            int str_byteCount = 0;
            if (str != null)
            {
                str_byteCount = Encoding.UTF8.GetByteCount(str);
                if (str_byteCount > Util.StackAllocationSizeLimit)
                {
                    native_str = Util.Allocate(str_byteCount + 1);
                }
                else
                {
                    byte* native_str_stackBytes = stackalloc byte[str_byteCount + 1];
                    native_str = native_str_stackBytes;
                }
                int native_str_offset = Util.GetUtf8(str, native_str, str_byteCount);
                native_str[native_str_offset] = 0;
            }
            else { native_str = null; }
            ImGuiNative.ImGuiIO_AddInputCharactersUTF8((ImGuiIO*)(NativePtr), native_str);
            if (str_byteCount > Util.StackAllocationSizeLimit)
            {
                Util.Free(native_str);
            }
        }
        /// <summary>
        /// Adds the input character utf 16 using the specified c
        /// </summary>
        /// <param name="c">The </param>
        public void AddInputCharacterUTF16(ushort c)
        {
            ImGuiNative.ImGuiIO_AddInputCharacterUTF16((ImGuiIO*)(NativePtr), c);
        }
        /// <summary>
        /// Adds the key analog event using the specified key
        /// </summary>
        /// <param name="key">The key</param>
        /// <param name="down">The down</param>
        /// <param name="v">The </param>
        public void AddKeyAnalogEvent(ImGuiKey key, bool down, float v)
        {
            byte native_down = down ? (byte)1 : (byte)0;
            ImGuiNative.ImGuiIO_AddKeyAnalogEvent((ImGuiIO*)(NativePtr), key, native_down, v);
        }
        /// <summary>
        /// Adds the key event using the specified key
        /// </summary>
        /// <param name="key">The key</param>
        /// <param name="down">The down</param>
        public void AddKeyEvent(ImGuiKey key, bool down)
        {
            byte native_down = down ? (byte)1 : (byte)0;
            ImGuiNative.ImGuiIO_AddKeyEvent((ImGuiIO*)(NativePtr), key, native_down);
        }
        /// <summary>
        /// Adds the mouse button event using the specified button
        /// </summary>
        /// <param name="button">The button</param>
        /// <param name="down">The down</param>
        public void AddMouseButtonEvent(int button, bool down)
        {
            byte native_down = down ? (byte)1 : (byte)0;
            ImGuiNative.ImGuiIO_AddMouseButtonEvent((ImGuiIO*)(NativePtr), button, native_down);
        }
        /// <summary>
        /// Adds the mouse pos event using the specified x
        /// </summary>
        /// <param name="x">The </param>
        /// <param name="y">The </param>
        public void AddMousePosEvent(float x, float y)
        {
            ImGuiNative.ImGuiIO_AddMousePosEvent((ImGuiIO*)(NativePtr), x, y);
        }
        /// <summary>
        /// Adds the mouse viewport event using the specified id
        /// </summary>
        /// <param name="id">The id</param>
        public void AddMouseViewportEvent(uint id)
        {
            ImGuiNative.ImGuiIO_AddMouseViewportEvent((ImGuiIO*)(NativePtr), id);
        }
        /// <summary>
        /// Adds the mouse wheel event using the specified wh x
        /// </summary>
        /// <param name="wh_x">The wh</param>
        /// <param name="wh_y">The wh</param>
        public void AddMouseWheelEvent(float wh_x, float wh_y)
        {
            ImGuiNative.ImGuiIO_AddMouseWheelEvent((ImGuiIO*)(NativePtr), wh_x, wh_y);
        }
        /// <summary>
        /// Clears the input characters
        /// </summary>
        public void ClearInputCharacters()
        {
            ImGuiNative.ImGuiIO_ClearInputCharacters((ImGuiIO*)(NativePtr));
        }
        /// <summary>
        /// Clears the input keys
        /// </summary>
        public void ClearInputKeys()
        {
            ImGuiNative.ImGuiIO_ClearInputKeys((ImGuiIO*)(NativePtr));
        }
        /// <summary>
        /// Destroys this instance
        /// </summary>
        public void Destroy()
        {
            ImGuiNative.ImGuiIO_destroy((ImGuiIO*)(NativePtr));
        }
        /// <summary>
        /// Sets the app accepting events using the specified accepting events
        /// </summary>
        /// <param name="accepting_events">The accepting events</param>
        public void SetAppAcceptingEvents(bool accepting_events)
        {
            byte native_accepting_events = accepting_events ? (byte)1 : (byte)0;
            ImGuiNative.ImGuiIO_SetAppAcceptingEvents((ImGuiIO*)(NativePtr), native_accepting_events);
        }
        /// <summary>
        /// Sets the key event native data using the specified key
        /// </summary>
        /// <param name="key">The key</param>
        /// <param name="native_keycode">The native keycode</param>
        /// <param name="native_scancode">The native scancode</param>
        public void SetKeyEventNativeData(ImGuiKey key, int native_keycode, int native_scancode)
        {
            int native_legacy_index = -1;
            ImGuiNative.ImGuiIO_SetKeyEventNativeData((ImGuiIO*)(NativePtr), key, native_keycode, native_scancode, native_legacy_index);
        }
        /// <summary>
        /// Sets the key event native data using the specified key
        /// </summary>
        /// <param name="key">The key</param>
        /// <param name="native_keycode">The native keycode</param>
        /// <param name="native_scancode">The native scancode</param>
        /// <param name="native_legacy_index">The native legacy index</param>
        public void SetKeyEventNativeData(ImGuiKey key, int native_keycode, int native_scancode, int native_legacy_index)
        {
            ImGuiNative.ImGuiIO_SetKeyEventNativeData((ImGuiIO*)(NativePtr), key, native_keycode, native_scancode, native_legacy_index);
        }
    }
}
