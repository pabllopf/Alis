// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File: Sdl.cs
// 
//  Author: Pablo Perdomo Falcón
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
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Alis.Core.Aspect.Base.Mapping;
using Alis.Core.Aspect.Math.Shape.Point;
using Alis.Core.Aspect.Math.Shape.Rectangle;
using Alis.Core.Aspect.Memory;
using Alis.Core.Aspect.Memory.Attributes;
using Alis.Core.Graphic.Sdl2.Delegates;
using Alis.Core.Graphic.Sdl2.Enums;
using Alis.Core.Graphic.Sdl2.Structs;

namespace Alis.Core.Graphic.Sdl2
{
    /// <summary>
    ///     The sdl class
    /// </summary>
    public static class Sdl
    {
        /// <summary>
        ///     The rw seek set
        /// </summary>
        public const int RwSeekSet = 0;

        /// <summary>
        ///     The rw seek cur
        /// </summary>
        public const int RwSeekCur = 1;

        /// <summary>
        ///     The rw seek end
        /// </summary>
        public const int RwSeekEnd = 2;

        /// <summary>
        ///     The sdl rw ops unknown
        /// </summary>
        public const uint RwOpsUnknown = 0;

        /// <summary>
        ///     The sdl rw ops win file
        /// </summary>
        public const uint RwOpsWinFile = 1;

        /// <summary>
        ///     The sdl rw ops std file
        /// </summary>
        public const uint RwOpsStdFile = 2;

        /// <summary>
        ///     The sdl rw ops jni file
        /// </summary>
        public const uint RwOpsJniFile = 3;

        /// <summary>
        ///     The sdl rw ops memory
        /// </summary>
        public const uint RwOpsMemory = 4;

        /// <summary>
        ///     The sdl rw ops memory ro
        /// </summary>
        public const uint RwOpsMemoryRo = 5;
        
        /// <summary>
        ///     The sdl hint framebuffer acceleration
        /// </summary>
        public const string HintFramebufferAcceleration = "SDL_FRAMEBUFFER_ACCELERATION";

        /// <summary>
        ///     The sdl hint render driver
        /// </summary>
        public const string HintRenderDriver = "SDL_RENDER_DRIVER";

        /// <summary>
        ///     The sdl hint render opengl shaders
        /// </summary>
        public const string HintRenderOpenglShaders = "SDL_RENDER_OPENGL_SHADERS";

        /// <summary>
        ///     The sdl hint render direct3d threadsafe
        /// </summary>
        public const string HintRenderDirect3DThreadsafe = "SDL_RENDER_DIRECT3D_THREADSAFE";

        /// <summary>
        ///     The sdl hint render vsync
        /// </summary>
        public const string HintRenderVsync = "SDL_RENDER_VSYNC";

        /// <summary>
        ///     The sdl hint video x11 x vid mode
        /// </summary>
        public const string HintVideoX11XVidMode = "SDL_VIDEO_X11_XVIDMODE";

        /// <summary>
        ///     The sdl hint video x11 x ine rama
        /// </summary>
        public const string HintVideoX11XIneRama = "SDL_VIDEO_X11_XINERAMA";

        /// <summary>
        ///     The sdl hint video x11 xrandr
        /// </summary>
        public const string HintVideoX11Xrandr = "SDL_VIDEO_X11_XRANDR";

        /// <summary>
        ///     The sdl hint grab keyboard
        /// </summary>
        public const string HintGrabKeyboard = "SDL_GRAB_KEYBOARD";

        /// <summary>
        ///     The sdl hint video minimize on focus loss
        /// </summary>
        public const string HintVideoMinimizeOnFocusLoss = "SDL_VIDEO_MINIMIZE_ON_FOCUS_LOSS";

        /// <summary>
        ///     The sdl hint idle timer disabled
        /// </summary>
        public const string HintIdleTimerDisabled = "SDL_IOS_IDLE_TIMER_DISABLED";

        /// <summary>
        ///     The sdl hint orientations
        /// </summary>
        public const string HintOrientations = "SDL_IOS_ORIENTATIONS";

        /// <summary>
        ///     The sdl hint x input enabled
        /// </summary>
        public const string HintXInputEnabled = "SDL_XINPUT_ENABLED";

        /// <summary>
        ///     The sdl hint game controller config
        /// </summary>
        public const string HintGameControllerConfig = "SDL_GAMECONTROLLERCONFIG";

        /// <summary>
        ///     The sdl hint joystick allow background events
        /// </summary>
        public const string HintJoystickAllowBackgroundEvents = "SDL_JOYSTICK_ALLOW_BACKGROUND_EVENTS";

        /// <summary>
        ///     The sdl hint allow topmost
        /// </summary>
        public const string HintAllowTopmost = "SDL_ALLOW_TOPMOST";

        /// <summary>
        ///     The sdl hint timer resolution
        /// </summary>
        public const string HintTimerResolution = "SDL_TIMER_RESOLUTION";

        /// <summary>
        ///     The sdl hint render scale quality
        /// </summary>
        public const string HintRenderScaleQuality = "SDL_RENDER_SCALE_QUALITY";

        /// <summary>
        ///     The sdl hint video high dpi disabled
        /// </summary>
        public const string HintVideoHighDpiDisabled = "SDL_VIDEO_HIGHDPI_DISABLED";

        /// <summary>
        ///     The sdl hint ctrl click emulate right click
        /// </summary>
        public const string HintCtrlClickEmulateRightClick = "SDL_CTRL_CLICK_EMULATE_RIGHT_CLICK";

        /// <summary>
        ///     The sdl hint video win d3d compiler
        /// </summary>
        public const string HintVideoWinD3DCompiler = "SDL_VIDEO_WIN_D3DCOMPILER";

        /// <summary>
        ///     The sdl hint mouse relative mode warp
        /// </summary>
        public const string HintMouseRelativeModeWarp = "SDL_MOUSE_RELATIVE_MODE_WARP";

        /// <summary>
        ///     The sdl hint video window share pixel format
        /// </summary>
        public const string HintVideoWindowSharePixelFormat = "SDL_VIDEO_WINDOW_SHARE_PIXEL_FORMAT";

        /// <summary>
        ///     The sdl hint video allow screensaver
        /// </summary>
        public const string HintVideoAllowScreensaver = "SDL_VIDEO_ALLOW_SCREENSAVER";

        /// <summary>
        ///     The sdl hint accelerometer as joystick
        /// </summary>
        public const string HintAccelerometerAsJoystick = "SDL_ACCELEROMETER_AS_JOYSTICK";

        /// <summary>
        ///     The sdl hint video mac fullscreen spaces
        /// </summary>
        public const string HintVideoMacFullscreenSpaces = "SDL_VIDEO_MAC_FULLSCREEN_SPACES";

        /// <summary>
        ///     The sdl hint winrt privacy policy url
        /// </summary>
        public const string HintWinrtPrivacyPolicyUrl = "SDL_WINRT_PRIVACY_POLICY_URL";

        /// <summary>
        ///     The sdl hint winrt privacy policy label
        /// </summary>
        public const string HintWinrtPrivacyPolicyLabel = "SDL_WINRT_PRIVACY_POLICY_LABEL";

        /// <summary>
        ///     The sdl hint winrt handle back button
        /// </summary>
        public const string HintWinrtHandleBackButton = "SDL_WINRT_HANDLE_BACK_BUTTON";

        /// <summary>
        ///     The sdl hint no signal handlers
        /// </summary>
        public const string HintNoSignalHandlers = "SDL_NO_SIGNAL_HANDLERS";

        /// <summary>
        ///     The sdl hint ime internal editing
        /// </summary>
        public const string HintImeInternalEditing = "SDL_IME_INTERNAL_EDITING";

        /// <summary>
        ///     The sdl hint android separate mouse and touch
        /// </summary>
        public const string HintAndroidSeparateMouseAndTouch = "SDL_ANDROID_SEPARATE_MOUSE_AND_TOUCH";

        /// <summary>
        ///     The sdl hint emscripten keyboard element
        /// </summary>
        public const string HintEmscriptenKeyboardElement = "SDL_EMSCRIPTEN_KEYBOARD_ELEMENT";

        /// <summary>
        ///     The sdl hint thread stack size
        /// </summary>
        public const string HintThreadStackSize = "SDL_THREAD_STACK_SIZE";

        /// <summary>
        ///     The sdl hint window frame usable while cursor hidden
        /// </summary>
        public const string HintWindowFrameUsableWhileCursorHidden = "SDL_WINDOW_FRAME_USABLE_WHILE_CURSOR_HIDDEN";

        /// <summary>
        ///     The sdl hint windows enable message loop
        /// </summary>
        public const string HintWindowsEnableMessageLoop = "SDL_WINDOWS_ENABLE_MESSAGELOOP";

        /// <summary>
        ///     The sdl hint windows no close on alt f4
        /// </summary>
        public const string HintWindowsNoCloseOnAltF4 = "SDL_WINDOWS_NO_CLOSE_ON_ALT_F4";

        /// <summary>
        ///     The sdl hint x input use old joystick mapping
        /// </summary>
        public const string HintXInputUseOldJoystickMapping = "SDL_XINPUT_USE_OLD_JOYSTICK_MAPPING";

        /// <summary>
        ///     The sdl hint mac background app
        /// </summary>
        public const string HintMacBackgroundApp = "SDL_MAC_BACKGROUND_APP";

        /// <summary>
        ///     The sdl hint video x11 net wm ping
        /// </summary>
        public const string HintVideoX11NetWmPing = "SDL_VIDEO_X11_NET_WM_PING";

        /// <summary>
        ///     The sdl hint android apk expansion main file version
        /// </summary>
        public const string HintAndroidApkExpansionMainFileVersion = "SDL_ANDROID_APK_EXPANSION_MAIN_FILE_VERSION";

        /// <summary>
        ///     The sdl hint android apk expansion patch file version
        /// </summary>
        public const string HintAndroidApkExpansionPatchFileVersion = "SDL_ANDROID_APK_EXPANSION_PATCH_FILE_VERSION";

        /// <summary>
        ///     The sdl hint mouse focus click through
        /// </summary>
        public const string HintMouseFocusClickThrough = "SDL_MOUSE_FOCUS_CLICKTHROUGH";

        /// <summary>
        ///     The sdl hint bmp save legacy format
        /// </summary>
        public const string HintBmpSaveLegacyFormat = "SDL_BMP_SAVE_LEGACY_FORMAT";

        /// <summary>
        ///     The sdl hint windows disable thread naming
        /// </summary>
        public const string HintWindowsDisableThreadNaming = "SDL_WINDOWS_DISABLE_THREAD_NAMING";

        /// <summary>
        ///     The sdl hint apple tv remote allow rotation
        /// </summary>
        public const string HintAppleTvRemoteAllowRotation = "SDL_APPLE_TV_REMOTE_ALLOW_ROTATION";

        /// <summary>
        ///     The sdl hint audio resampling mode
        /// </summary>
        public const string HintAudioResamplingMode = "SDL_AUDIO_RESAMPLING_MODE";

        /// <summary>
        ///     The sdl hint render logical size mode
        /// </summary>
        public const string HintRenderLogicalSizeMode = "SDL_RENDER_LOGICAL_SIZE_MODE";

        /// <summary>
        ///     The sdl hint mouse normal speed scale
        /// </summary>
        public const string HintMouseNormalSpeedScale = "SDL_MOUSE_NORMAL_SPEED_SCALE";

        /// <summary>
        ///     The sdl hint mouse relative speed scale
        /// </summary>
        public const string HintMouseRelativeSpeedScale = "SDL_MOUSE_RELATIVE_SPEED_SCALE";

        /// <summary>
        ///     The sdl hint touch mouse events
        /// </summary>
        public const string HintTouchMouseEvents = "SDL_TOUCH_MOUSE_EVENTS";

        /// <summary>
        ///     The sdl hint windows intro source icon
        /// </summary>
        public const string HintWindowsIntroSourceIcon = "SDL_WINDOWS_INTRESOURCE_ICON";

        /// <summary>
        ///     The sdl hint windows intro source icon small
        /// </summary>
        public const string HintWindowsIntroSourceIconSmall = "SDL_WINDOWS_INTRESOURCE_ICON_SMALL";

        /// <summary>
        ///     The sdl hint ios hide home indicator
        /// </summary>
        public const string HintIosHideHomeIndicator = "SDL_IOS_HIDE_HOME_INDICATOR";

        /// <summary>
        ///     The sdl hint tv remote as joystick
        /// </summary>
        public const string HintTvRemoteAsJoystick = "SDL_TV_REMOTE_AS_JOYSTICK";

        /// <summary>
        ///     The sdl video x11 net wm bypass compositor
        /// </summary>
        public const string VideoX11NetWmBypassCompositor = "SDL_VIDEO_X11_NET_WM_BYPASS_COMPOSITOR";

        /// <summary>
        ///     The sdl hint mouse double click time
        /// </summary>
        public const string HintMouseDoubleClickTime = "SDL_MOUSE_DOUBLE_CLICK_TIME";

        /// <summary>
        ///     The sdl hint mouse double click radius
        /// </summary>
        public const string HintMouseDoubleClickRadius = "SDL_MOUSE_DOUBLE_CLICK_RADIUS";

        /// <summary>
        ///     The sdl hint joystick hidapi
        /// </summary>
        public const string HintJoystickHidapi = "SDL_JOYSTICK_HIDAPI";

        /// <summary>
        ///     The sdl hint joystick hidapi ps4
        /// </summary>
        public const string HintJoystickHidapiPs4 = "SDL_JOYSTICK_HIDAPI_PS4";

        /// <summary>
        ///     The sdl hint joystick hidapi ps4 rumble
        /// </summary>
        public const string HintJoystickHidapiPs4Rumble = "SDL_JOYSTICK_HIDAPI_PS4_RUMBLE";

        /// <summary>
        ///     The sdl hint joystick hidapi steam
        /// </summary>
        public const string HintJoystickHidapiSteam = "SDL_JOYSTICK_HIDAPI_STEAM";

        /// <summary>
        ///     The sdl hint joystick hidapi switch
        /// </summary>
        public const string HintJoystickHidapiSwitch = "SDL_JOYSTICK_HIDAPI_SWITCH";

        /// <summary>
        ///     The sdl hint joystick hidapi xbox
        /// </summary>
        public const string HintJoystickHidapiXbox = "SDL_JOYSTICK_HIDAPI_XBOX";

        /// <summary>
        ///     The sdl hint enable steam controllers
        /// </summary>
        public const string HintEnableSteamControllers = "SDL_ENABLE_STEAM_CONTROLLERS";

        /// <summary>
        ///     The sdl hint android trap back button
        /// </summary>
        public const string HintAndroidTrapBackButton = "SDL_ANDROID_TRAP_BACK_BUTTON";

        /// <summary>
        ///     The sdl hint mouse touch events
        /// </summary>
        public const string HintMouseTouchEvents = "SDL_MOUSE_TOUCH_EVENTS";

        /// <summary>
        ///     The sdl hint game controller config file
        /// </summary>
        public const string HintGameControllerConfigFile = "SDL_GAMECONTROLLERCONFIG_FILE";

        /// <summary>
        ///     The sdl hint android block on pause
        /// </summary>
        public const string HintAndroidBlockOnPause = "SDL_ANDROID_BLOCK_ON_PAUSE";

        /// <summary>
        ///     The sdl hint render batching
        /// </summary>
        public const string HintRenderBatching = "SDL_RENDER_BATCHING";

        /// <summary>
        ///     The sdl hint event logging
        /// </summary>
        public const string HintEventLogging = "SDL_EVENT_LOGGING";

        /// <summary>
        ///     The sdl hint wave riff chunk size
        /// </summary>
        public const string HintWaveRiffChunkSize = "SDL_WAVE_RIFF_CHUNK_SIZE";

        /// <summary>
        ///     The sdl hint wave truncation
        /// </summary>
        public const string HintWaveTruncation = "SDL_WAVE_TRUNCATION";

        /// <summary>
        ///     The sdl hint wave fact chunk
        /// </summary>
        public const string HintWaveFactChunk = "SDL_WAVE_FACT_CHUNK";

        /// <summary>
        ///     The sdl hint x11 window visual id
        /// </summary>
        public const string HintVideoX11WindowVisualId = "SDL_VIDEO_X11_WINDOW_VISUALID";

        /// <summary>
        ///     The sdl hint game controller use button labels
        /// </summary>
        public const string HintGameControllerUseButtonLabels = "SDL_GAMECONTROLLER_USE_BUTTON_LABELS";

        /// <summary>
        ///     The sdl hint video external context
        /// </summary>
        public const string HintVideoExternalContext = "SDL_VIDEO_EXTERNAL_CONTEXT";

        /// <summary>
        ///     The sdl hint joystick hidapi game cube
        /// </summary>
        public const string HintJoystickHidapiGameCube = "SDL_JOYSTICK_HIDAPI_GAMECUBE";

        /// <summary>
        ///     The sdl hint display usable bounds
        /// </summary>
        public const string HintDisplayUsableBounds = "SDL_DISPLAY_USABLE_BOUNDS";

        /// <summary>
        ///     The sdl hint video x11 force egl
        /// </summary>
        public const string HintVideoX11ForceEgl = "SDL_VIDEO_X11_FORCE_EGL";

        /// <summary>
        ///     The sdl hint game controller type
        /// </summary>
        public const string HintGameControllerType = "SDL_GAMECONTROLLERTYPE";

        /// <summary>
        ///     The sdl hint joystick hidapi correlate x input
        /// </summary>
        public const string HintJoystickHidapiCorrelateXInput = "SDL_JOYSTICK_HIDAPI_CORRELATE_XINPUT";

        /// <summary>
        ///     The sdl hint joystick raw input
        /// </summary>
        public const string HintJoystickRawInput = "SDL_JOYSTICK_RAWINPUT";

        /// <summary>
        ///     The sdl hint audio device app name
        /// </summary>
        public const string HintAudioDeviceAppName = "SDL_AUDIO_DEVICE_APP_NAME";

        /// <summary>
        ///     The sdl hint audio device stream name
        /// </summary>
        public const string HintAudioDeviceStreamName = "SDL_AUDIO_DEVICE_STREAM_NAME";

        /// <summary>
        ///     The sdl hint preferred locales
        /// </summary>
        public const string HintPreferredLocales = "SDL_PREFERRED_LOCALES";

        /// <summary>
        ///     The sdl hint thread priority policy
        /// </summary>
        public const string HintThreadPriorityPolicy = "SDL_THREAD_PRIORITY_POLICY";

        /// <summary>
        ///     The sdl hint emscripten asyncify
        /// </summary>
        public const string HintEmscriptenAsyncify = "SDL_EMSCRIPTEN_ASYNCIFY";

        /// <summary>
        ///     The sdl hint linux joystick dead zones
        /// </summary>
        public const string HintLinuxJoystickDeadZones = "SDL_LINUX_JOYSTICK_DEADZONES";

        /// <summary>
        ///     The sdl hint android block on pause pause audio
        /// </summary>
        public const string HintAndroidBlockOnPausePauseAudio = "SDL_ANDROID_BLOCK_ON_PAUSE_PAUSEAUDIO";

        /// <summary>
        ///     The sdl hint joystick hidapi ps5
        /// </summary>
        public const string HintJoystickHidapiPs5 = "SDL_JOYSTICK_HIDAPI_PS5";

        /// <summary>
        ///     The sdl hint thread force realtime time critical
        /// </summary>
        public const string HintThreadForceRealtimeTimeCritical = "SDL_THREAD_FORCE_REALTIME_TIME_CRITICAL";

        /// <summary>
        ///     The sdl hint joystick thread
        /// </summary>
        public const string SdlHintJoystickThread = "SDL_JOYSTICK_THREAD";

        /// <summary>
        ///     The sdl hint auto update joysticks
        /// </summary>
        public const string HintAutoUpdateJoysticks = "SDL_AUTO_UPDATE_JOYSTICKS";

        /// <summary>
        ///     The sdl hint auto update sensors
        /// </summary>
        public const string HintAutoUpdateSensors = "SDL_AUTO_UPDATE_SENSORS";

        /// <summary>
        ///     The sdl hint mouse relative scaling
        /// </summary>
        public const string HintMouseRelativeScaling = "SDL_MOUSE_RELATIVE_SCALING";

        /// <summary>
        ///     The sdl hint joystick hidapi ps5 rumble
        /// </summary>
        public const string HintJoystickHidapiPs5Rumble = "SDL_JOYSTICK_HIDAPI_PS5_RUMBLE";

        /// <summary>
        ///     The sdl hint windows force mutex critical sections
        /// </summary>
        public const string HintWindowsForceMutexCriticalSections = "SDL_WINDOWS_FORCE_MUTEX_CRITICAL_SECTIONS";

        /// <summary>
        ///     The sdl hint windows force semaphore kernel
        /// </summary>
        public const string HintWindowsForceSemaphoreKernel = "SDL_WINDOWS_FORCE_SEMAPHORE_KERNEL";

        /// <summary>
        ///     The sdl hint joystick hidapi ps5 player led
        /// </summary>
        public const string HintJoystickHidapiPs5PlayerLed = "SDL_JOYSTICK_HIDAPI_PS5_PLAYER_LED";

        /// <summary>
        ///     The sdl hint windows use d3d9ex
        /// </summary>
        public const string HintWindowsUseD3D9Ex = "SDL_WINDOWS_USE_D3D9EX";

        /// <summary>
        ///     The sdl hint joystick hidapi joy cons
        /// </summary>
        public const string HintJoystickHidapiJoyCons = "SDL_JOYSTICK_HIDAPI_JOY_CONS";

        /// <summary>
        ///     The sdl hint joystick hidapi stadia
        /// </summary>
        public const string HintJoystickHidapiStadia = "SDL_JOYSTICK_HIDAPI_STADIA";

        /// <summary>
        ///     The sdl hint joystick hidapi switch home led
        /// </summary>
        public const string HintJoystickHidapiSwitchHomeLed = "SDL_JOYSTICK_HIDAPI_SWITCH_HOME_LED";

        /// <summary>
        ///     The sdl hint allow alt tab while grabbed
        /// </summary>
        public const string HintAllowAltTabWhileGrabbed = "SDL_ALLOW_ALT_TAB_WHILE_GRABBED";

        /// <summary>
        ///     The sdl hint km sd rm require drm master
        /// </summary>
        public const string HintKmSdFmRequireDrmMaster = "SDL_KMSDRM_REQUIRE_DRM_MASTER";

        /// <summary>
        ///     The sdl hint audio device stream role
        /// </summary>
        public const string HintAudioDeviceStreamRole = "SDL_AUDIO_DEVICE_STREAM_ROLE";

        /// <summary>
        ///     The sdl hint x11 force override redirect
        /// </summary>
        public const string HintX11ForceOverrideRedirect = "SDL_X11_FORCE_OVERRIDE_REDIRECT";

        /// <summary>
        ///     The sdl hint joystick hidapi luna
        /// </summary>
        public const string HintJoystickHidapiLuna = "SDL_JOYSTICK_HIDAPI_LUNA";

        /// <summary>
        ///     The sdl hint joystick raw input correlate x input
        /// </summary>
        public const string HintJoystickRawInputCorrelateXInput = "SDL_JOYSTICK_RAWINPUT_CORRELATE_XINPUT";

        /// <summary>
        ///     The sdl hint audio include monitors
        /// </summary>
        public const string HintAudioIncludeMonitors = "SDL_AUDIO_INCLUDE_MONITORS";

        /// <summary>
        ///     The sdl hint video wayland allow lib decor
        /// </summary>
        public const string HintVideoWaylandAllowLibDecor = "SDL_VIDEO_WAYLAND_ALLOW_LIBDECOR";

        /// <summary>
        ///     The sdl hint video egl allow transparency
        /// </summary>
        public const string HintVideoEglAllowTransparency = "SDL_VIDEO_EGL_ALLOW_TRANSPARENCY";

        /// <summary>
        ///     The sdl hint app name
        /// </summary>
        public const string HintAppName = "SDL_APP_NAME";

        /// <summary>
        ///     The sdl hint screensaver inhibit activity name
        /// </summary>
        public const string HintScreensaverInhibitActivityName = "SDL_SCREENSAVER_INHIBIT_ACTIVITY_NAME";

        /// <summary>
        ///     The sdl hint ime show ui
        /// </summary>
        public const string HintImeShowUi = "SDL_IME_SHOW_UI";

        /// <summary>
        ///     The sdl hint window no activation when shown
        /// </summary>
        public const string HintWindowNoActivationWhenShown = "SDL_WINDOW_NO_ACTIVATION_WHEN_SHOWN";

        /// <summary>
        ///     The sdl hint poll sentinel
        /// </summary>
        public const string HintPollSentinel = "SDL_POLL_SENTINEL";

        /// <summary>
        ///     The sdl hint joystick device
        /// </summary>
        public const string HintJoystickDevice = "SDL_JOYSTICK_DEVICE";

        /// <summary>
        ///     The sdl hint linux joystick classic
        /// </summary>
        public const string HintLinuxJoystickClassic = "SDL_LINUX_JOYSTICK_CLASSIC";

        /// <summary>
        ///     The sdl major version
        /// </summary>
        public const int MajorVersion = 2;

        /// <summary>
        ///     The sdl minor version
        /// </summary>
        public const int MinorVersion = 0;

        /// <summary>
        ///     The sdl patch level
        /// </summary>
        public const int PatchLevel = 18;

        /// <summary>
        ///     The sdl window pos undefined mask
        /// </summary>
        public const int WindowPosUndefinedMask = 0x1FFF0000;

        /// <summary>
        ///     The sdl window pos centered mask
        /// </summary>
        public const int WindowPosCenteredMask = 0x2FFF0000;

        /// <summary>
        ///     The sdl window pos undefined
        /// </summary>
        public const int WindowPosUndefined = 0x1FFF0000;

        /// <summary>
        ///     The sdl window pos centered
        /// </summary>
        public const int WindowPosCentered = 0x2FFF0000;

        /// <summary>
        ///     The sdl sw surface
        /// </summary>
        public const uint SwSurface = 0x00000000;

        /// <summary>
        ///     The sdl pre alloc
        /// </summary>
        public const uint PreAlloc = 0x00000001;

        /// <summary>
        ///     The sdl rle accel
        /// </summary>
        public const uint RleAccel = 0x00000002;

        /// <summary>
        ///     The sdl dont free
        /// </summary>
        public const uint DontFree = 0x00000004;

        /// <summary>
        ///     The sdl pressed
        /// </summary>
        public const byte Pressed = 1;

        /// <summary>
        ///     The sdl released
        /// </summary>
        public const byte Released = 0;

        /// <summary>
        ///     The sdl text editing event text size
        /// </summary>
        public const int TextEditingEventTextSize = 32;

        /// <summary>
        ///     The sdl text input event text size
        /// </summary>
        public const int TextInputEventTextSize = 32;

        /// <summary>
        ///     The sdl query
        /// </summary>
        public const int Query = -1;

        /// <summary>
        ///     The sdl ignore
        /// </summary>
        public const int Ignore = 0;

        /// <summary>
        ///     The sdl disable
        /// </summary>
        public const int Disable = 0;

        /// <summary>
        ///     The sdl enable
        /// </summary>
        public const int Enable = 1;

        /// <summary>
        ///     The sdl scancode mask
        /// </summary>
        public const int KScancodeMask = 1 << 30;

        /// <summary>
        ///     The sdl button left
        /// </summary>
        public const uint ButtonLeft = 1;

        /// <summary>
        ///     The sdl button middle
        /// </summary>
        public const uint ButtonMiddle = 2;

        /// <summary>
        ///     The sdl button right
        /// </summary>
        public const uint ButtonRight = 3;

        /// <summary>
        ///     The sdl button x1
        /// </summary>
        public const uint ButtonX1 = 4;

        /// <summary>
        ///     The sdl button x2
        /// </summary>
        public const uint ButtonX2 = 5;

        /// <summary>
        ///     The max value
        /// </summary>
        public const uint TouchMouseId = uint.MaxValue;

        /// <summary>
        ///     The sdl hat centered
        /// </summary>
        public const byte HatCentered = 0x00;

        /// <summary>
        ///     The sdl hat up
        /// </summary>
        public const byte HatUp = 0x01;

        /// <summary>
        ///     The sdl hat right
        /// </summary>
        public const byte HatRight = 0x02;

        /// <summary>
        ///     The sdl hat down
        /// </summary>
        public const byte HatDown = 0x04;

        /// <summary>
        ///     The sdl hat left
        /// </summary>
        public const byte HatLeft = 0x08;

        /// <summary>
        ///     The sdl hat up
        /// </summary>
        public const byte HatRightUp = HatRight | HatUp;

        /// <summary>
        ///     The sdl hat down
        /// </summary>
        public const byte HatRightDown = HatRight | HatDown;

        /// <summary>
        ///     The sdl hat up
        /// </summary>
        public const byte HatLeftUp = HatLeft | HatUp;

        /// <summary>
        ///     The sdl hat down
        /// </summary>
        public const byte HatLeftDown = HatLeft | HatDown;


        /// <summary>
        ///     The sdl iphone max g force
        /// </summary>
        public const float IphoneMaxGForce = 5.0f;

        /// <summary>
        ///     The sdl haptic constant
        /// </summary>
        public const ushort HapticConstant = 1 << 0;

        /// <summary>
        ///     The sdl haptic sine
        /// </summary>
        public const ushort HapticSine = 1 << 1;

        /// <summary>
        ///     The sdl haptic left right
        /// </summary>
        public const ushort HapticLeftRight = 1 << 2;

        /// <summary>
        ///     The sdl haptic triangle
        /// </summary>
        public const ushort HapticTriangle = 1 << 3;

        /// <summary>
        ///     The sdl haptic saw tooth up
        /// </summary>
        public const ushort HapticSawToothUp = 1 << 4;

        /// <summary>
        ///     The sdl haptic saw tooth down
        /// </summary>
        public const ushort HapticSawToothDown = 1 << 5;

        /// <summary>
        ///     The sdl haptic spring
        /// </summary>
        public const ushort HapticSpring = 1 << 7;

        /// <summary>
        ///     The sdl haptic damper
        /// </summary>
        public const ushort HapticDamper = 1 << 8;

        /// <summary>
        ///     The sdl haptic inertia
        /// </summary>
        public const ushort HapticInertia = 1 << 9;

        /// <summary>
        ///     The sdl haptic friction
        /// </summary>
        public const ushort HapticFriction = 1 << 10;

        /// <summary>
        ///     The sdl haptic custom
        /// </summary>
        public const ushort HapticCustom = 1 << 11;

        /// <summary>
        ///     The sdl haptic gain
        /// </summary>
        public const ushort HapticGain = 1 << 12;

        /// <summary>
        ///     The sdl haptic auto center
        /// </summary>
        public const ushort HapticAutoCenter = 1 << 13;

        /// <summary>
        ///     The sdl haptic status
        /// </summary>
        public const ushort HapticStatus = 1 << 14;

        /// <summary>
        ///     The sdl haptic pause
        /// </summary>
        public const ushort HapticPauseVar = 1 << 15;

        /// <summary>
        ///     The sdl haptic polar
        /// </summary>
        public const byte HapticPolar = 0;

        /// <summary>
        ///     The sdl haptic cartesian
        /// </summary>
        public const byte HapticCartesian = 1;

        /// <summary>
        ///     The sdl haptic spherical
        /// </summary>
        public const byte HapticSpherical = 2;

        /// <summary>
        ///     The sdl haptic steering axis
        /// </summary>
        public const byte HapticSteeringAxis = 3;

        /// <summary>
        ///     The sdl haptic infinity
        /// </summary>
        public const uint HapticInfinity = 4294967295U;

        /// <summary>
        ///     The sdl standard gravity
        /// </summary>
        public const float StandardGravity = 9.80665f;

        /// <summary>
        ///     The sdl audio mask bit size
        /// </summary>
        public const ushort AudioMaskBitSize = 0xFF;

        /// <summary>
        ///     The sdl audio mask datatype
        /// </summary>
        public const ushort AudioMaskDatatype = 1 << 8;

        /// <summary>
        ///     The sdl audio mask endian
        /// </summary>
        public const ushort AudioMaskEndian = 1 << 12;

        /// <summary>
        ///     The sdl audio mask signed
        /// </summary>
        public const ushort AudioMaskSigned = 1 << 15;

        /// <summary>
        ///     The audio u8
        /// </summary>
        public const ushort AudioU8 = 0x0008;

        /// <summary>
        ///     The audio s8
        /// </summary>
        public const ushort AudioS8 = 0x8008;

        /// <summary>
        ///     The audio u16lsb
        /// </summary>
        public const ushort AudioU16Lsb = 0x0010;

        /// <summary>
        ///     The audio s16lsb
        /// </summary>
        public const ushort AudioS16Lsb = 0x8010;

        /// <summary>
        ///     The audio u16msb
        /// </summary>
        public const ushort AudioU16Msb = 0x1010;

        /// <summary>
        ///     The audio s16msb
        /// </summary>
        public const ushort AudioS16Msb = 0x9010;

        /// <summary>
        ///     The audio u16lsb
        /// </summary>
        public const ushort AudioU16 = AudioU16Lsb;

        /// <summary>
        ///     The audio s16lsb
        /// </summary>
        public const ushort AudioS16 = AudioS16Lsb;

        /// <summary>
        ///     The audio s32lsb
        /// </summary>
        public const ushort AudioS32Lsb = 0x8020;

        /// <summary>
        ///     The audio s32msb
        /// </summary>
        public const ushort AudioS32Msb = 0x9020;

        /// <summary>
        ///     The audio s32lsb
        /// </summary>
        public const ushort AudioS32 = AudioS32Lsb;

        /// <summary>
        ///     The audio f32lsb
        /// </summary>
        public const ushort AudioF32Lsb = 0x8120;

        /// <summary>
        ///     The audio f32msb
        /// </summary>
        public const ushort AudioF32Msb = 0x9120;

        /// <summary>
        ///     The audio f32lsb
        /// </summary>
        public const ushort AudioF32 = AudioF32Lsb;

        /// <summary>
        ///     The sdl audio allow frequency change
        /// </summary>
        public const uint AudioAllowFrequencyChange = 0x00000001;

        /// <summary>
        ///     The sdl audio allow format change
        /// </summary>
        public const uint AudioAllowFormatChange = 0x00000002;

        /// <summary>
        ///     The sdl audio allow channels change
        /// </summary>
        public const uint AudioAllowChannelsChange = 0x00000004;

        /// <summary>
        ///     The sdl audio allow samples change
        /// </summary>
        public const uint AudioAllowSamplesChange = 0x00000008;

        /// <summary>
        ///     The sdl audio allow samples change
        /// </summary>
        public const uint AudioAllowAnyChange = AudioAllowFrequencyChange | AudioAllowFormatChange | AudioAllowChannelsChange | AudioAllowSamplesChange;

        /// <summary>
        ///     The sdl mix max volume
        /// </summary>
        public const int MixMaxVolume = 128;

        /// <summary>
        ///     The sdl android external storage read
        /// </summary>
        public const int AndroidExternalStorageRead = 0x01;

        /// <summary>
        ///     The sdl android external storage write
        /// </summary>
        public const int AndroidExternalStorageWrite = 0x02;

        /// <summary>
        ///     The sdl patch level
        /// </summary>
        public static int GetGlCompiledVersion() => MajorVersion * 1000 + MinorVersion * 100 + PatchLevel;   

        /// <summary>
        ///     The sdl pixel format unknown
        /// </summary>
        public static readonly uint PixelFormatUnknown = 0;

        /// <summary>
        ///     The sdl bit map order 4321
        /// </summary>
        public static readonly uint PixelFormatIndex1Lsb = SdlDefinePixelFormat(TypePixel.TypeIndex1, (uint) BitmapOrder.BitMapOrder4321, 0, 1, 0);

        /// <summary>
        ///     The sdl bit map order 1234
        /// </summary>
        public static readonly uint PixelFormatIndex1Msb = SdlDefinePixelFormat(TypePixel.TypeIndex1, (uint) BitmapOrder.BitMapOrder1234, 0, 1, 0);

        /// <summary>
        ///     The sdl bit map order 4321
        /// </summary>
        public static readonly uint PixelFormatIndex4Lsb = SdlDefinePixelFormat(TypePixel.TypeIndex4, (uint) BitmapOrder.BitMapOrder4321, 0, 4, 0);

        /// <summary>
        ///     The sdl bit map order 1234
        /// </summary>
        public static readonly uint PixelFormatIndex4Msb = SdlDefinePixelFormat(TypePixel.TypeIndex4, (uint) BitmapOrder.BitMapOrder1234, 0, 4, 0);

        /// <summary>
        ///     The sdl pixel type index8
        /// </summary>
        public static readonly uint PixelFormatIndex8 = SdlDefinePixelFormat(TypePixel.TypeIndex8, 0, 0, 8, 1);

        /// <summary>
        ///     The sdl packed layout 332
        /// </summary>
        public static readonly uint PixelFormatRgb332 = SdlDefinePixelFormat(TypePixel.TypePacked8, (uint) PackedOrder.PackedOrderXRgb, PackedLayout.PackedLayout332, 8, 1);

        /// <summary>
        ///     The sdl packed layout 4444
        /// </summary>
        public static readonly uint GlFormatXRgb444 = SdlDefinePixelFormat(TypePixel.TypePacked16, (uint) PackedOrder.PackedOrderXRgb, PackedLayout.PackedLayout4444, 12, 2);

        /// <summary>
        ///     The sdl pixel format x rgb 444
        /// </summary>
        public static readonly uint PixelFormatRgb444 = GlFormatXRgb444;

        /// <summary>
        ///     The sdl packed layout 4444
        /// </summary>
        public static readonly uint GlFormatXBgr444 = SdlDefinePixelFormat(TypePixel.TypePacked16, (uint) PackedOrder.PackedOrderXBgr, PackedLayout.PackedLayout4444, 12, 2);

        /// <summary>
        ///     The sdl pixel format x bgr 444
        /// </summary>
        public static readonly uint PixelFormatBgr444 = GlFormatXBgr444;

        /// <summary>
        ///     The sdl packed layout 1555
        /// </summary>
        public static readonly uint GlFormatXRgb1555 = SdlDefinePixelFormat(TypePixel.TypePacked16, (uint) PackedOrder.PackedOrderXRgb, PackedLayout.PackedLayout1555, 15, 2);

        /// <summary>
        ///     The sdl pixel format xrgb1555
        /// </summary>
        public static readonly uint PixelFormatRgb555 = GlFormatXRgb1555;

        /// <summary>
        ///     The sdl packed layout 1555
        /// </summary>
        public static readonly uint GlFormatXBgr1555 = SdlDefinePixelFormat(TypePixel.TypeIndex1, (uint) BitmapOrder.BitMapOrder4321, PackedLayout.PackedLayout1555, 15, 2);

        /// <summary>
        ///     The sdl pixel format xbgr1555
        /// </summary>
        public static readonly uint PixelFormatBgr555 = GlFormatXBgr1555;

        /// <summary>
        ///     The sdl packed layout 4444
        /// </summary>
        public static readonly uint PixelFormatArgb4444 = SdlDefinePixelFormat(TypePixel.TypePacked16, (uint) PackedOrder.PackedOrderARgb, PackedLayout.PackedLayout4444, 16, 2);

        /// <summary>
        ///     The sdl packed layout 4444
        /// </summary>
        public static readonly uint PixelFormatRgba4444 = SdlDefinePixelFormat(TypePixel.TypePacked16, (uint) PackedOrder.PackedOrderRGba, PackedLayout.PackedLayout4444, 16, 2);

        /// <summary>
        ///     The sdl packed layout 4444
        /// </summary>
        public static readonly uint PixelFormatABgr4444 = SdlDefinePixelFormat(TypePixel.TypePacked16, (uint) PackedOrder.PackedOrderABgr, PackedLayout.PackedLayout4444, 16, 2);

        /// <summary>
        ///     The sdl packed layout 4444
        /// </summary>
        public static readonly uint PixelFormatBGra4444 = SdlDefinePixelFormat(TypePixel.TypePacked16, (uint) PackedOrder.PackedOrderBGra, PackedLayout.PackedLayout4444, 16, 2);

        /// <summary>
        ///     The sdl packed layout 1555
        /// </summary>
        public static readonly uint PixelFormatArgb1555 = SdlDefinePixelFormat(TypePixel.TypePacked16, (uint) PackedOrder.PackedOrderARgb, PackedLayout.PackedLayout1555, 16, 2);

        /// <summary>
        ///     The sdl packed layout 5551
        /// </summary>
        public static readonly uint PixelFormatRgba5551 = SdlDefinePixelFormat(TypePixel.TypePacked16, (uint) PackedOrder.PackedOrderRGba, PackedLayout.PackedLayout5551, 16, 2);

        /// <summary>
        ///     The sdl packed layout 1555
        /// </summary>
        public static readonly uint PixelFormatABgr1555 = SdlDefinePixelFormat(TypePixel.TypePacked16, (uint) PackedOrder.PackedOrderABgr, PackedLayout.PackedLayout1555, 16, 2);

        /// <summary>
        ///     The sdl packed layout 5551
        /// </summary>
        public static readonly uint PixelFormatBGra5551 = SdlDefinePixelFormat(TypePixel.TypePacked16, (uint) PackedOrder.PackedOrderBGra, PackedLayout.PackedLayout5551, 16, 2);

        /// <summary>
        ///     The sdl packed layout 565
        /// </summary>
        public static readonly uint PixelFormatRgb565 = SdlDefinePixelFormat(TypePixel.TypePacked16, (uint) PackedOrder.PackedOrderXRgb, PackedLayout.PackedLayout565, 16, 2);

        /// <summary>
        ///     The sdl packed layout 565
        /// </summary>
        public static readonly uint PixelFormatBgr565 = SdlDefinePixelFormat(TypePixel.TypePacked16, (uint) PackedOrder.PackedOrderXBgr, PackedLayout.PackedLayout565, 16, 2);

        /// <summary>
        ///     The sdl array order rgb
        /// </summary>
        public static readonly uint PixelFormatRgb24 = SdlDefinePixelFormat(TypePixel.TypeArrayU8, (uint) SdlArrayOrder.SdlArrayOrderRgb, 0, 24, 3);

        /// <summary>
        ///     The sdl array order bgr
        /// </summary>
        public static readonly uint PixelFormatBgr24 = SdlDefinePixelFormat(TypePixel.TypeArrayU8, (uint) SdlArrayOrder.SdlArrayOrderBgr, 0, 24, 3);

        /// <summary>
        ///     The sdl packed layout 8888
        /// </summary>
        public static readonly uint GlFormatXRgb888 = SdlDefinePixelFormat(TypePixel.TypePacked32, (uint) PackedOrder.PackedOrderXRgb, PackedLayout.PackedLayout8888, 24, 4);

        /// <summary>
        ///     The sdl pixel format x rgb 888
        /// </summary>
        public static readonly uint PixelFormatRgb888 = GlFormatXRgb888;

        /// <summary>
        ///     The sdl packed layout 8888
        /// </summary>
        public static readonly uint PixelFormatRgbX8888 = SdlDefinePixelFormat(TypePixel.TypePacked32, (uint) PackedOrder.PackedOrderRGbx, PackedLayout.PackedLayout8888, 24, 4);

        /// <summary>
        ///     The sdl packed layout 8888
        /// </summary>
        public static readonly uint GlFormatXBgr888 = SdlDefinePixelFormat(TypePixel.TypePacked32, (uint) PackedOrder.PackedOrderXBgr, PackedLayout.PackedLayout8888, 24, 4);

        /// <summary>
        ///     The sdl pixel format x bgr 888
        /// </summary>
        public static readonly uint PixelFormatBgr888 = GlFormatXBgr888;

        /// <summary>
        ///     The sdl packed layout 8888
        /// </summary>
        public static readonly uint PixelFormatBGrx8888 = SdlDefinePixelFormat(TypePixel.TypePacked32, (uint) PackedOrder.PackedOrderBGrx, PackedLayout.PackedLayout8888, 24, 4);

        /// <summary>
        ///     The sdl packed layout 8888
        /// </summary>
        public static readonly uint PixelFormatArgb8888 = SdlDefinePixelFormat(TypePixel.TypePacked32, (uint) PackedOrder.PackedOrderARgb, PackedLayout.PackedLayout8888, 32, 4);

        /// <summary>
        ///     The sdl packed layout 8888
        /// </summary>
        public static readonly uint PixelFormatRgba8888 = SdlDefinePixelFormat(TypePixel.TypePacked32, (uint) PackedOrder.PackedOrderRGba, PackedLayout.PackedLayout8888, 32, 4);

        /// <summary>
        ///     The sdl packed layout 8888
        /// </summary>
        public static readonly uint PixelFormatABgr8888 = SdlDefinePixelFormat(TypePixel.TypePacked32, (uint) PackedOrder.PackedOrderABgr, PackedLayout.PackedLayout8888, 32, 4);

        /// <summary>
        ///     The sdl packed layout 8888
        /// </summary>
        public static readonly uint PixelFormatB8888 = SdlDefinePixelFormat(TypePixel.TypePacked32, (uint) PackedOrder.PackedOrderBGra, PackedLayout.PackedLayout8888, 32, 4);

        /// <summary>
        ///     The sdl packed layout 2101010
        /// </summary>
        public static readonly uint PixelFormatArgb2101010 = SdlDefinePixelFormat(TypePixel.TypePacked32, (uint) PackedOrder.PackedOrderARgb, PackedLayout.PackedLayout2101010, 32, 4);

        /// <summary>
        ///     The sdl define pixel four cc
        /// </summary>
        public static readonly uint PixelFormatYv12 = SdlDefinePixelFourcc((byte) 'Y', (byte) 'V', (byte) '1', (byte) '2');

        /// <summary>
        ///     The sdl define pixel four cc
        /// </summary>
        public static readonly uint PixelFormatIy = SdlDefinePixelFourcc((byte) 'I', (byte) 'Y', (byte) 'U', (byte) 'V');

        /// <summary>
        ///     The sdl define pixel four
        /// </summary>
        public static readonly uint GlFormatYuy2 = SdlDefinePixelFourcc((byte) 'Y', (byte) 'U', (byte) 'Y', (byte) '2');

        /// <summary>
        ///     The sdl define pixel four
        /// </summary>
        public static readonly uint GlFormatUy = SdlDefinePixelFourcc((byte) 'U', (byte) 'Y', (byte) 'V', (byte) 'Y');

        /// <summary>
        ///     The sdl define pixel four
        /// </summary>
        public static readonly uint GlFormatYv = SdlDefinePixelFourcc((byte) 'Y', (byte) 'V', (byte) 'Y', (byte) 'U');

        /// <summary>
        ///     The sdl button left
        /// </summary>
        public static readonly uint GlButtonLMask = Button(ButtonLeft);

        /// <summary>
        ///     The sdl button middle
        /// </summary>
        public static readonly uint GlButtonMMask = Button(ButtonMiddle);

        /// <summary>
        ///     The sdl button right
        /// </summary>
        public static readonly uint GlButtonRMask = Button(ButtonRight);

        /// <summary>
        ///     The sdl button x1
        /// </summary>
        public static readonly uint GlButtonX1Mask = Button(ButtonX1);

        /// <summary>
        ///     The sdl button x2
        /// </summary>
        public static readonly uint GlButtonX2Mask = Button(ButtonX2);

        /// <summary>
        ///     The audio u16msb
        /// </summary>
        public static readonly ushort GlAudioU16Sys = BitConverter.IsLittleEndian ? AudioU16Lsb : AudioU16Msb;

        /// <summary>
        ///     The audio s16msb
        /// </summary>
        public static readonly ushort GlAudioS16Sys = BitConverter.IsLittleEndian ? AudioS16Lsb : AudioS16Msb;

        /// <summary>
        ///     The audio s32msb
        /// </summary>
        public static readonly ushort GlAudioS32Sys = BitConverter.IsLittleEndian ? AudioS32Lsb : AudioS32Msb;

        /// <summary>
        ///     The audio f32msb
        /// </summary>
        public static readonly ushort GlAudioF32Sys = BitConverter.IsLittleEndian ? AudioF32Lsb : AudioF32Msb;

        /// <summary>
        ///     Sdl the fourcc using the specified a
        /// </summary>
        /// <param name="a">The </param>
        /// <param name="b">The </param>
        /// <param name="c">The </param>
        /// <param name="d">The </param>
        /// <returns>The uint</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint Fourcc(byte a, byte b, byte c, byte d) => (uint) (a | (b << 8) | (c << 16) | (d << 24));

        /// <summary>
        ///     Malloc the size
        /// </summary>
        /// <param name="size">The size</param>
        /// <returns>The int ptr</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IntPtr Malloc([NotNull, NotZero] int size)
        {
            Validator.ValidateInput(size);
            IntPtr result = NativeSdl.InternalMalloc(size);
            Validator.ValidateOutput(result);
            return result;
        }

        /// <summary>
        ///     Frees the mem block
        /// </summary>
        /// <param name="memBlock">The mem block</param>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Free([NotNull] IntPtr memBlock)
        {
            Validator.ValidateInput(memBlock);
            NativeSdl.InternalFree(memBlock);
        }

        /// <summary>
        ///     Mem the cpy using the specified dst
        /// </summary>
        /// <param name="dst">The dst</param>
        /// <param name="src">The src</param>
        /// <param name="len">The len</param>
        /// <returns>The int ptr</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IntPtr MemCpy([NotNull] IntPtr dst, [NotNull] IntPtr src, [NotNull] IntPtr len)
        {
            Validator.ValidateInput(dst);
            Validator.ValidateInput(src);
            Validator.ValidateInput(len);
            IntPtr result = NativeSdl.InternalMemCpy(dst, src, len);
            Validator.ValidateOutput(result);
            return result;
        }

        /// <summary>
        ///     Sdl the rw from file using the specified file
        /// </summary>
        /// <param name="file">The file</param>
        /// <param name="mode">The mode</param>
        /// <returns>The rw ops</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IntPtr RwFromFile([NotNull] string file, [NotNull] string mode)
        {
            Validator.ValidateInput(file);
            Validator.ValidateInput(mode);
            IntPtr result = NativeSdl.InternalRWFromFile(file, mode);
            Validator.ValidateOutput(result);
            return result;
        }

        /// <summary>
        ///     Internal the sdl alloc rw
        /// </summary>
        /// <returns>The int ptr</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IntPtr AllocRw()
        {
            IntPtr result = NativeSdl.InternalAllocRW();
            Validator.ValidateOutput(result);
            return result;
        }

        /// <summary>
        ///     Free the rw using the specified area
        /// </summary>
        /// <param name="area">The area</param>
        public static void FreeRw([NotNull] IntPtr area)
        {
            Validator.ValidateInput(area);
            NativeSdl.InternalFreeRW(area);
        }

        /// <summary>
        ///     Rws the from fp using the specified fp
        /// </summary>
        /// <param name="fp">The fp</param>
        /// <param name="autoClose">The auto close</param>
        /// <returns>The int ptr</returns>
        public static IntPtr RwFromFp([NotNull] IntPtr fp, [NotNull] SdlBool autoClose)
        {
            Validator.ValidateInput(fp);
            Validator.ValidateInput(autoClose);
            IntPtr result = NativeSdl.InternalRWFromFP(fp, autoClose);
            Validator.ValidateOutput(result);
            return result;
        }

        /// <summary>
        ///     Rws the from mem using the specified mem
        /// </summary>
        /// <param name="mem">The mem</param>
        /// <param name="size">The size</param>
        /// <returns>The int ptr</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IntPtr RwFromMem([NotNull] IntPtr mem, [NotNull] int size)
        {
            Validator.ValidateInput(mem);
            Validator.ValidateInput(size);
            IntPtr result = NativeSdl.InternalRWFromMem(mem, size);
            Validator.ValidateOutput(result);
            return result;
        }

        /// <summary>
        ///     Rws the from const mem using the specified mem
        /// </summary>
        /// <param name="mem">The mem</param>
        /// <param name="size">The size</param>
        /// <returns>The int ptr</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IntPtr RwFromConstMem([NotNull] IntPtr mem, [NotNull] int size)
        {
            Validator.ValidateInput(mem);
            Validator.ValidateInput(size);
            IntPtr result = NativeSdl.InternalRWFromConstMem(mem, size);
            Validator.ValidateOutput(result);
            return result;
        }

        /// <summary>
        ///     Rws the size using the specified context
        /// </summary>
        /// <param name="context">The context</param>
        /// <returns>The long</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long RwSize([NotNull] IntPtr context)
        {
            Validator.ValidateInput(context);
            long result = NativeSdl.InternalRwSize(context);
            Validator.ValidateOutput(result);
            return result;
        }

        /// <summary>
        ///     Rws the seek using the specified context
        /// </summary>
        /// <param name="context">The context</param>
        /// <param name="offset">The offset</param>
        /// <param name="whence">The whence</param>
        /// <returns>The long</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long RwSeek([NotNull] IntPtr context, [NotNull] long offset, [NotNull] int whence)
        {
            Validator.ValidateInput(context);
            Validator.ValidateInput(offset);
            Validator.ValidateInput(whence);
            long result = NativeSdl.InternalRwSeek(context, offset, whence);
            Validator.ValidateOutput(result);
            return result;
        }

        /// <summary>
        ///     Rws the tell using the specified context
        /// </summary>
        /// <param name="context">The context</param>
        /// <returns>The long</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long RwTell([NotNull] IntPtr context)
        {
            Validator.ValidateInput(context);
            long result = NativeSdl.InternalRwTell(context);
            Validator.ValidateOutput(result);
            return result;
        }

        /// <summary>
        ///     Rws the read using the specified context
        /// </summary>
        /// <param name="context">The context</param>
        /// <param name="ptr">The ptr</param>
        /// <param name="size">The size</param>
        /// <param name="maxNum">The max num</param>
        /// <returns>The long</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long RwRead([NotNull] IntPtr context, [NotNull] IntPtr ptr, [NotNull] IntPtr size, [NotNull] IntPtr maxNum)
        {
            Validator.ValidateInput(context);
            Validator.ValidateInput(ptr);
            Validator.ValidateInput(size);
            Validator.ValidateInput(maxNum);
            long result = NativeSdl.InternalRwRead(context, ptr, size, maxNum);
            Validator.ValidateOutput(result);
            return result;
        }

        /// <summary>
        ///     Rws the write using the specified context
        /// </summary>
        /// <param name="context">The context</param>
        /// <param name="ptr">The ptr</param>
        /// <param name="size">The size</param>
        /// <param name="maxNum">The max num</param>
        /// <returns>The long</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long RwWrite([NotNull] IntPtr context, [NotNull] IntPtr ptr, [NotNull] IntPtr size, [NotNull] IntPtr maxNum)
        {
            Validator.ValidateInput(context);
            Validator.ValidateInput(ptr);
            Validator.ValidateInput(size);
            Validator.ValidateInput(maxNum);
            long result = NativeSdl.InternalRwWrite(context, ptr, size, maxNum);
            Validator.ValidateOutput(result);
            return result;
        }
        /// <summary>
        ///     Rws the close using the specified context
        /// </summary>
        /// <param name="context">The context</param>
        /// <returns>The long</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long RwClose([NotNull] IntPtr context)
        {
            Validator.ValidateInput(context);
            long result = NativeSdl.InternalRwClose(context);
            Validator.ValidateOutput(result);
            return result;
        }

        /// <summary>
        ///     Sdl the load file using the specified file
        /// </summary>
        /// <param name="file">The file</param>
        /// <param name="dataSize">The data size</param>
        /// <returns>The result</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IntPtr LoadFile([NotNull] string file, out IntPtr dataSize)
        {
            Validator.ValidateInput(file);
            IntPtr result = NativeSdl.InternalLoadFile(file, out dataSize);
            Validator.ValidateOutput(result);
            return result;
        }

        /// <summary>
        ///     Sets the main ready
        /// </summary>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetMainReady()
        {
            NativeSdl.InternalSetMainReady();
        }

        /// <summary>
        ///     Wins the rt run app using the specified main function
        /// </summary>
        /// <param name="mainFunction">The main function</param>
        /// <param name="reserved">The reserved</param>
        /// <returns>The int</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int WinRtRunApp([NotNull] SdlMainFunc mainFunction, [NotNull] IntPtr reserved)
        {
            Validator.ValidateInput(mainFunction);
            Validator.ValidateInput(reserved);
            int result = NativeSdl.InternalWinRTRunApp(mainFunction, reserved);
            Validator.ValidateOutput(result);
            return result;
        }

        /// <summary>
        ///     Uis the kit run app using the specified argc
        /// </summary>
        /// <param name="argc">The argc</param>
        /// <param name="argv">The argv</param>
        /// <param name="mainFunction">The main function</param>
        /// <returns>The int</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int UiKitRunApp([NotNull] int argc, [NotNull] IntPtr argv, [NotNull] SdlMainFunc mainFunction)
        {
            Validator.ValidateInput(argc);
            Validator.ValidateInput(argv);
            Validator.ValidateInput(mainFunction);
            int result = NativeSdl.InternalUIKitRunApp(argc, argv, mainFunction);
            Validator.ValidateOutput(result);
            return result;
        }
        
        /// <summary>
        ///     Sdl the clear error
        /// </summary>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ClearError()
        {
            NativeSdl.InternalClearError();
        }

        /// <summary>
        ///     Sdl the get error
        /// </summary>
        /// <returns>The string</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string GetError()
        {
            string result = Marshal.PtrToStringAnsi(NativeSdl.InternalGetError());
            Validator.ValidateOutput(result);
            return result;
        }

        /// <summary>
        ///     Sdl the set error using the specified fmt and arg list
        /// </summary>
        /// <param name="fmtAndArgList">The fmt and arg list</param>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetError([NotNull] string fmtAndArgList)
        {
            Validator.ValidateInput(fmtAndArgList);
            NativeSdl.InternalSetError(fmtAndArgList);
        }

        /// <summary>
        ///     Sdl the init using the specified flags
        /// </summary>
        /// <param name="flags">The flags</param>
        /// <returns>The int</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Init([NotNull] SdlInit flags)
        {
            Validator.ValidateInput(flags);
            int result = NativeSdl.InternalInit(flags);
            Validator.ValidateOutput(result);
            return result;
        }
        
        /// <summary>
        ///     Sdl the quit
        /// </summary>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Quit()
        {
            NativeSdl.InternalQuit();
        }

        /// <summary>
        ///     Sdl the was init using the specified flags
        /// </summary>
        /// <param name="flags">The flags</param>
        /// <returns>The uint</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint WasInit([NotNull] SdlInit flags)
        {
            Validator.ValidateInput(flags);
            uint result = NativeSdl.InternalWasInit(flags);
            Validator.ValidateOutput(result);
            return result;
        }
        /// <summary>
        ///     Clears the hints
        /// </summary>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ClearHints()
        {
            NativeSdl.InternalClearHints();
        }

        /// <summary>
        ///     Sdl the get hint using the specified name
        /// </summary>
        /// <param name="name">The name</param>
        /// <returns>The string</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string GetHint([NotNull] string name)
        {
            Validator.ValidateInput(name);
            string result = NativeSdl.InternalGetHint(name);
            Validator.ValidateOutput(result);
            return result;
        }

        /// <summary>
        ///     Sdl the set hint using the specified name
        /// </summary>
        /// <param name="name">The name</param>
        /// <param name="value">The value</param>
        /// <returns>The sdl bool</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static SdlBool SetHint([NotNull] string name, [NotNull] string value)
        {
            Validator.ValidateInput(name);
            Validator.ValidateInput(value);
            SdlBool result = NativeSdl.InternalSetHint(name, value);
            Validator.ValidateOutput(result);
            return result;
        }

        /// <summary>
        ///     Sdl the set hint with priority using the specified name
        /// </summary>
        /// <param name="name">The name</param>
        /// <param name="value">The value</param>
        /// <param name="priority">The priority</param>
        /// <returns>The sdl bool</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static SdlBool SetHintWithPriority([NotNull] string name, [NotNull] string value, SdlHintPriority priority)
        {
            Validator.ValidateInput(name);
            Validator.ValidateInput(value);
            Validator.ValidateInput(priority);
            SdlBool result = NativeSdl.InternalSetHintWithPriority(name, value, priority);
            Validator.ValidateOutput(result);
            return result;
        }

        /// <summary>
        ///     Sdl the get hint boolean using the specified name
        /// </summary>
        /// <param name="name">The name</param>
        /// <param name="defaultValue">The default value</param>
        /// <returns>The sdl bool</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static SdlBool GetHintBoolean([NotNull] string name, SdlBool defaultValue)
        {
            Validator.ValidateInput(name);
            Validator.ValidateInput(defaultValue);
            SdlBool result = NativeSdl.InternalGetHintBoolean(name, defaultValue);
            Validator.ValidateOutput(result);
            return result;
        }

        /// <summary>
        ///     Sdl the show message box using the specified message box data
        /// </summary>
        /// <param name="messageBoxData">The message box data</param>
        /// <param name="buttonId">The button id</param>
        /// <returns>The result</returns>
        public static int ShowMessageBox(ref SdlMessageBoxData messageBoxData, out int buttonId)
        {
            InternalSdlMessageBoxData data = new InternalSdlMessageBoxData
            {
                flags = messageBoxData.flags,
                window = messageBoxData.window,
                title = NativeSdl.AllocUtf8(messageBoxData.title),
                message = NativeSdl.AllocUtf8(messageBoxData.message),
                numButtons = messageBoxData.numButtons
            };

            InternalSdlMessageBoxButtonData[] buttons = new InternalSdlMessageBoxButtonData[messageBoxData.numButtons];
            IntPtr buttonsPtr = IntPtr.Zero;

            try
            {
                for (int i = 0; i < messageBoxData.numButtons; i++)
                {
                    buttons[i] = new InternalSdlMessageBoxButtonData
                    {
                        flags = messageBoxData.buttons[i].flags,
                        buttonId = messageBoxData.buttons[i].buttonId,
                        text = NativeSdl.AllocUtf8(messageBoxData.buttons[i].text)
                    };
                }

                buttonsPtr = Marshal.AllocHGlobal(buttons.Length * Marshal.SizeOf<InternalSdlMessageBoxButtonData>());
                for (int i = 0; i < buttons.Length; i++)
                {
                    IntPtr buttonPtr = buttonsPtr + i * Marshal.SizeOf<InternalSdlMessageBoxButtonData>();
                    Marshal.StructureToPtr(buttons[i], buttonPtr, false);
                }

                data.buttons = buttonsPtr;

                IntPtr colorSchemePtr = IntPtr.Zero;
                if (messageBoxData.colorScheme.colors != null)
                {
                    colorSchemePtr = Marshal.AllocHGlobal(Marshal.SizeOf<SdlMessageBoxColorScheme>());
                    Marshal.StructureToPtr(messageBoxData.colorScheme, colorSchemePtr, false);
                }

                int result = NativeSdl.InternalShowMessageBox(ref data, out buttonId);

                for (int i = 0; i < messageBoxData.numButtons; i++)
                {
                    NativeSdl.InternalFree(buttons[i].text);
                }

                NativeSdl.InternalFree(data.message);
                NativeSdl.InternalFree(data.title);

                if (colorSchemePtr != IntPtr.Zero)
                {
                    Marshal.DestroyStructure<SdlMessageBoxColorScheme>(colorSchemePtr);
                    Marshal.FreeHGlobal(colorSchemePtr);
                }

                return result;
            }
            finally
            {
                if (buttonsPtr != IntPtr.Zero)
                {
                    Marshal.FreeHGlobal(buttonsPtr);
                }
            }
        }

        /// <summary>
        ///     Sdl the show simple message box using the specified flags
        /// </summary>
        /// <param name="flags">The flags</param>
        /// <param name="title">The title</param>
        /// <param name="message">The message</param>
        /// <param name="window">The window</param>
        /// <returns>The int</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int ShowSimpleMessageBox(SdlMessageBoxFlags flags, [NotNull] string title, [NotNull] string message, [NotNull] IntPtr window) => NativeSdl.InternalShowSimpleMessageBox(flags, title, message, window);

        /// <summary>
        ///     Sdl the version
        /// </summary>
        /// <returns>The sdl version</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static SdlVersion Version() => new SdlVersion(MajorVersion, MinorVersion, PatchLevel);
        
        /// <summary>
        ///     Sdl the get version using the specified ver
        /// </summary>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static SdlVersion GetVersion()
        {
            NativeSdl.InternalGetVersion(out SdlVersion version);
            return version;
        }
        
        /// <summary>
        ///     Sdl the get revision number
        /// </summary>
        /// <returns>The int</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int GetRevisionNumber() => NativeSdl.InternalGetRevisionNumber();

        /// <summary>
        ///     Sdl the window pos undefined display using the specified x
        /// </summary>
        /// <param name="x">The </param>
        /// <returns>The int</returns>
        public static int WindowPosUndefinedDisplay([NotNull] int x) => WindowPosUndefinedMask | x;

        /// <summary>
        ///     Describes whether sdl window pos is undefined
        /// </summary>
        /// <param name="x">The </param>
        /// <returns>The bool</returns>
        public static bool WindowPosIsUndefined([NotNull] int x) => (x & 0xFFFF0000) == WindowPosUndefinedMask;

        /// <summary>
        ///     Sdl the window pos centered display using the specified x
        /// </summary>
        /// <param name="x">The </param>
        /// <returns>The int</returns>
        public static int WindowPosCenteredDisplay([NotNull] int x) => WindowPosCenteredMask | x;

        /// <summary>
        ///     Describes whether sdl window pos is centered
        /// </summary>
        /// <param name="x">The </param>
        /// <returns>The bool</returns>
        public static bool WindowPosIsCentered([NotNull] int x) => (x & 0xFFFF0000) == WindowPosCenteredMask;

        /// <summary>
        ///     Sdl the create window using the specified title
        /// </summary>
        /// <param name="title">The title</param>
        /// <param name="x">The </param>
        /// <param name="y">The </param>
        /// <param name="w">The </param>
        /// <param name="h">The </param>
        /// <param name="flags">The flags</param>
        /// <returns>The int ptr</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IntPtr CreateWindow([NotNull] string title, [NotNull] int x, [NotNull] int y, [NotNull] int w, [NotNull] int h, [NotNull] SdlWindowFlags flags) => NativeSdl.InternalCreateWindow(title, x, y, w, h, flags);

        /// <summary>
        ///     Sdl the create window and renderer using the specified width
        /// </summary>
        /// <param name="width">The width</param>
        /// <param name="height">The height</param>
        /// <param name="windowFlags">The window flags</param>
        /// <param name="window">The window</param>
        /// <param name="renderer">The renderer</param>
        /// <returns>The int</returns>
        public static int CreateWindowAndRenderer([NotNull] int width, [NotNull] int height, [NotNull] SdlWindowFlags windowFlags, out IntPtr window, out IntPtr renderer)
        {
            Validator.ValidateInput(width);
            Validator.ValidateInput(height);
            return NativeSdl.InternalCreateWindowAndRenderer(width, height, windowFlags, out window, out renderer);
        }

        /// <summary>
        ///     Sdl the create window from using the specified data
        /// </summary>
        /// <param name="data">The data</param>
        /// <returns>The int ptr</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IntPtr CreateWindowFrom([NotNull] IntPtr data)
        {
            Validator.ValidateInput(data);
            return NativeSdl.InternalCreateWindowFrom(data);
        }

        /// <summary>
        ///     Sdl the destroy window using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void DestroyWindow([NotNull] IntPtr window)
        {
            Validator.ValidateInput(window);
            NativeSdl.InternalDestroyWindow(window);
        }

        /// <summary>
        ///     Sdl the disable screen saver
        /// </summary>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void DisableScreenSaver()
        {
            NativeSdl.InternalDisableScreenSaver();
        }

        /// <summary>
        ///     Internals the sdl enable screen saver
        /// </summary>
        public static void EnableScreenSaver()
        {
            NativeSdl.InternalEnableScreenSaver();
        }

        /// <summary>
        ///     Sdl the get closest display mode using the specified display index
        /// </summary>
        /// <param name="displayIndex">The display index</param>
        /// <param name="mode">The mode</param>
        /// <param name="closest">The closest</param>
        /// <returns>The int ptr</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IntPtr GetClosestDisplayMode([NotNull] int displayIndex, ref SdlDisplayMode mode, out SdlDisplayMode closest)
        {
            Validator.ValidateInput(displayIndex);
            IntPtr result = NativeSdl.InternalGetClosestDisplayMode(displayIndex, ref mode, out closest);
            Validator.ValidateOutput(result);
            return result;
        }

        /// <summary>
        ///     Sdl the get current display mode using the specified display index
        /// </summary>
        /// <param name="displayIndex">The display index</param>
        /// <param name="mode">The mode</param>
        /// <returns>The int</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int GetCurrentDisplayMode([NotNull] int displayIndex, out SdlDisplayMode mode)
        {
            Validator.ValidateInput(displayIndex);
            int result = NativeSdl.InternalGetCurrentDisplayMode(displayIndex, out mode);
            Validator.ValidateOutput(result);
            return result;
        }

        /// <summary>
        ///     Sdl the get current video driver
        /// </summary>
        /// <returns>The string</returns>
        public static string GetCurrentVideoDriver()
        {
            string result = NativeSdl.InternalGetCurrentVideoDriver();
            Validator.ValidateOutput(result);
            return result;
        }

        /// <summary>
        ///     Gets the desktop display mode using the specified display index
        /// </summary>
        /// <param name="displayIndex">The display index</param>
        /// <param name="mode">The mode</param>
        /// <returns>The int</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int GetDesktopDisplayMode([NotNull] int displayIndex, out SdlDisplayMode mode)
        {
            Validator.ValidateInput(displayIndex);
            int result = NativeSdl.InternalGetDesktopDisplayMode(displayIndex, out mode);
            Validator.ValidateOutput(result);
            return result;
        }

        /// <summary>
        ///     Sdl the get display name using the specified index
        /// </summary>
        /// <param name="index">The index</param>
        /// <returns>The string</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string GetDisplayName([NotNull] int index)
        {
            Validator.ValidateInput(index);
            string result = Marshal.PtrToStringAnsi(NativeSdl.InternalGetDisplayName(index));
            Validator.ValidateOutput(result);
            return result;
        }

        /// <summary>
        ///     Gets the display bounds using the specified display index
        /// </summary>
        /// <param name="displayIndex">The display index</param>
        /// <param name="rect">The rect</param>
        /// <returns>The int</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int GetDisplayBounds([NotNull] int displayIndex, out RectangleI rect)
        {
            Validator.ValidateInput(displayIndex);
            int result = NativeSdl.InternalGetDisplayBounds(displayIndex, out rect);
            Validator.ValidateOutput(result);
            return result;
        }

        /// <summary>
        ///     Gets the display dpi using the specified display index
        /// </summary>
        /// <param name="displayIndex">The display index</param>
        /// <param name="dDpi">The dpi</param>
        /// <param name="hDpi">The dpi</param>
        /// <param name="vDpi">The dpi</param>
        /// <returns>The int</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int GetDisplayDpi([NotNull] int displayIndex, out float dDpi, out float hDpi, out float vDpi)
        {
            Validator.ValidateInput(displayIndex);
            int result = NativeSdl.InternalGetDisplayDPI(displayIndex, out dDpi, out hDpi, out vDpi);
            Validator.ValidateOutput(result);
            return result;
        }

        /// <summary>
        ///     Gets the display orientation using the specified display index
        /// </summary>
        /// <param name="displayIndex">The display index</param>
        /// <returns>The sdl display orientation</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static SdlDisplayOrientation GetDisplayOrientation([NotNull] int displayIndex)
        {
            Validator.ValidateInput(displayIndex);
            SdlDisplayOrientation result = NativeSdl.InternalGetDisplayOrientation(displayIndex);
            Validator.ValidateOutput(result);
            return result;
        }


        /// <summary>
        ///     Gets the display mode using the specified display index
        /// </summary>
        /// <param name="displayIndex">The display index</param>
        /// <param name="modeIndex">The mode index</param>
        /// <param name="mode">The mode</param>
        /// <returns>The int</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int GetDisplayMode([NotNull] int displayIndex, [NotNull] int modeIndex, out SdlDisplayMode mode)
        {
            Validator.ValidateInput(displayIndex);
            Validator.ValidateInput(modeIndex);
            int result = NativeSdl.InternalGetDisplayMode(displayIndex, modeIndex, out mode);
            Validator.ValidateOutput(result);
            return result;
        }


        /// <summary>
        ///     Gets the display usable bounds using the specified display index
        /// </summary>
        /// <param name="displayIndex">The display index</param>
        /// <param name="rect">The rect</param>
        /// <returns>The int</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int GetDisplayUsableBounds([NotNull] int displayIndex, out RectangleI rect) => NativeSdl.InternalGetDisplayUsableBounds(displayIndex, out rect);


        /// <summary>
        ///     Gets the num display modes using the specified display index
        /// </summary>
        /// <param name="displayIndex">The display index</param>
        /// <returns>The int</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int GetNumDisplayModes([NotNull] int displayIndex) => NativeSdl.InternalGetNumDisplayModes(displayIndex);

        /// <summary>
        ///     Gets the num video displays
        /// </summary>
        /// <returns>The int</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int GetNumVideoDisplays() => NativeSdl.InternalGetNumVideoDisplays();

        /// <summary>
        ///     Gets the num video drivers
        /// </summary>
        /// <returns>The int</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int GetNumVideoDrivers() => NativeSdl.InternalGetNumVideoDrivers();

        /// <summary>
        ///     Sdl the get video driver using the specified index
        /// </summary>
        /// <param name="index">The index</param>
        /// <returns>The string</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string GetVideoDriver([NotNull] int index) => Marshal.PtrToStringAnsi(NativeSdl.InternalGetVideoDriver(index));

        /// <summary>
        ///     Gets the window brightness using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <returns>The float</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float GetWindowBrightness([NotNull] IntPtr window) => NativeSdl.InternalGetWindowBrightness(window);

        /// <summary>
        ///     Sets the window opacity using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="opacity">The opacity</param>
        /// <returns>The int</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int SetWindowOpacity([NotNull] IntPtr window, [NotNull] float opacity) => NativeSdl.InternalSetWindowOpacity(window, opacity);

        /// <summary>
        ///     Gets the window opacity using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="outOpacity">The out opacity</param>
        /// <returns>The int</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int GetWindowOpacity([NotNull] IntPtr window, out float outOpacity) => NativeSdl.InternalGetWindowOpacity(window, out outOpacity);

        /// <summary>
        ///     Sets the window modal for using the specified modal window
        /// </summary>
        /// <param name="modalWindow">The modal window</param>
        /// <param name="parentWindow">The parent window</param>
        /// <returns>The int</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int SetWindowModalFor([NotNull] IntPtr modalWindow, [NotNull] IntPtr parentWindow) => NativeSdl.InternalSetWindowModalFor(modalWindow, parentWindow);

        /// <summary>
        ///     Sets the window input focus using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <returns>The int</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int SetWindowInputFocus([NotNull] IntPtr window) => NativeSdl.InternalSetWindowInputFocus(window);

        /// <summary>
        ///     Sdl the get window data using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="name">The name</param>
        /// <returns>The int ptr</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IntPtr GetWindowData([NotNull] IntPtr window, [NotNull] string name) => NativeSdl.InternalGetWindowData(window, name);

        /// <summary>
        ///     Gets the window display index using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <returns>The int</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int GetWindowDisplayIndex([NotNull] IntPtr window) => NativeSdl.InternalGetWindowDisplayIndex(window);

        /// <summary>
        ///     Gets the window display mode using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="mode">The mode</param>
        /// <returns>The int</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int GetWindowDisplayMode([NotNull] IntPtr window, out SdlDisplayMode mode)
        {
            Validator.ValidateInput(window);
            int result = NativeSdl.InternalGetWindowDisplayMode(window, out mode);
            Validator.ValidateOutput(result);
            return result;
        }

        /// <summary>
        ///     Gets the window icc profile using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="mode">The mode</param>
        /// <returns>The int ptr</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IntPtr GetWindowIccProfile([NotNull] IntPtr window, out IntPtr mode)
        {
            Validator.ValidateInput(window);
            IntPtr result = NativeSdl.InternalGetWindowICCProfile(window, out mode);
            Validator.ValidateOutput(result);
            return result;
        }

        /// <summary>
        ///     Gets the window flags using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <returns>The uint</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint GetWindowFlags([NotNull] IntPtr window)
        {
            Validator.ValidateInput(window);
            uint result = NativeSdl.InternalGetWindowFlags(window);
            Validator.ValidateOutput(result);
            return result;
        }

        /// <summary>
        ///     Gets the window from id using the specified id
        /// </summary>
        /// <param name="id">The id</param>
        /// <returns>The int ptr</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IntPtr GetWindowFromId([NotNull] uint id)
        {
            Validator.ValidateInput(id);
            IntPtr result = NativeSdl.InternalGetWindowFromID(id);
            Validator.ValidateOutput(result);
            return result;
        }

        /// <summary>
        ///     Gets the window gamma ramp using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="red">The red</param>
        /// <param name="green">The green</param>
        /// <param name="blue">The blue</param>
        /// <returns>The int</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int GetWindowGammaRamp([NotNull] IntPtr window, [Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U2, SizeConst = 256)] ushort[] red, [Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U2, SizeConst = 256)] ushort[] green, [Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U2, SizeConst = 256)] ushort[] blue)
        {
            Validator.ValidateInput(window);
            Validator.ValidateInput(red);
            Validator.ValidateInput(green);
            Validator.ValidateInput(blue);
            int result = NativeSdl.InternalGetWindowGammaRamp(window, red, green, blue);
            Validator.ValidateOutput(result);
            return result;
        }

        /// <summary>
        ///     Gets the window grab using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <returns>The sdl bool</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static SdlBool GetWindowGrab([NotNull] IntPtr window)
        {
            Validator.ValidateInput(window);
            SdlBool result = NativeSdl.InternalGetWindowGrab(window);
            Validator.ValidateOutput(result);
            return result;
        }

        /// <summary>
        ///     Gets the window keyboard grab using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <returns>The sdl bool</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static SdlBool GetWindowKeyboardGrab([NotNull] IntPtr window)
        {
            Validator.ValidateInput(window);
            SdlBool result = NativeSdl.InternalGetWindowKeyboardGrab(window);
            Validator.ValidateOutput(result);
            return result;
        }

        /// <summary>
        ///     Gets the window mouse grab using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <returns>The sdl bool</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static SdlBool GetWindowMouseGrab([NotNull] IntPtr window)
        {
            Validator.ValidateInput(window);
            SdlBool result = NativeSdl.InternalGetWindowMouseGrab(window);
            Validator.ValidateOutput(result);
            return result;
        }

        /// <summary>
        ///     Gets the window id using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <returns>The uint</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint GetWindowId([NotNull] IntPtr window)
        {
            Validator.ValidateInput(window);
            uint result = NativeSdl.InternalGetWindowID(window);
            Validator.ValidateOutput(result);
            return result;
        }

        /// <summary>
        ///     Gets the window pixel format using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <returns>The uint</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint GetWindowPixelFormat([NotNull] IntPtr window)
        {
            Validator.ValidateInput(window);
            return NativeSdl.InternalGetWindowPixelFormat(window);
        }

        /// <summary>
        ///     Gets the window maximum size using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="maxW">The max</param>
        /// <param name="maxH">The max</param>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void GetWindowMaximumSize([NotNull] IntPtr window, out int maxW, out int maxH)
        {
            Validator.ValidateInput(window);
            NativeSdl.InternalGetWindowMaximumSize(window, out maxW, out maxH);
        }

        /// <summary>
        ///     Gets the window minimum size using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="minW">The min</param>
        /// <param name="minH">The min</param>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void GetWindowMinimumSize([NotNull] IntPtr window, out int minW, out int minH)
        {
            Validator.ValidateInput(window);
            NativeSdl.InternalGetWindowMinimumSize(window, out minW, out minH);
        }

        /// <summary>
        ///     Gets the window position using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="x">The </param>
        /// <param name="y">The </param>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void GetWindowPosition([NotNull] IntPtr window, out int x, out int y)
        {
            Validator.ValidateInput(window);
            NativeSdl.InternalGetWindowPosition(window, out x, out y);
        }


        /// <summary>
        ///     Gets the window size using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="w">The </param>
        /// <param name="h">The </param>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void GetWindowSize([NotNull] IntPtr window, out int w, out int h)
        {
            Validator.ValidateInput(window);
            NativeSdl.InternalGetWindowSize(window, out w, out h);
        }

        /// <summary>
        ///     Gets the window surface using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <returns>The int ptr</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IntPtr GetWindowSurface([NotNull] IntPtr window) => NativeSdl.InternalGetWindowSurface(window);

        /// <summary>
        ///     Sdl the get window title using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <returns>The string</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string GetWindowTitle([NotNull] IntPtr window) => NativeSdl.InternalGetWindowTitle(window);

        /// <summary>
        ///     Gls the bind texture using the specified texture
        /// </summary>
        /// <param name="texture">The texture</param>
        /// <param name="texW">The tex</param>
        /// <param name="texH">The tex</param>
        /// <returns>The int</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int BindTexture([NotNull] IntPtr texture, out float texW, out float texH) => NativeSdl.InternalGL_BindTexture(texture, out texW, out texH);

        /// <summary>
        ///     Gls the create context using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <returns>The int ptr</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IntPtr CreateContext([NotNull] IntPtr window) => NativeSdl.InternalGL_CreateContext(window);

        /// <summary>
        ///     Gls the delete context using the specified context
        /// </summary>
        /// <param name="context">The context</param>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void DeleteContext([NotNull] IntPtr context)
        {
            NativeSdl.InternalGL_DeleteContext(context);
        }

        /// <summary>
        ///     Sdl the gl load library using the specified path
        /// </summary>
        /// <param name="path">The path</param>
        /// <returns>The result</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int LoadLibrary([NotNull] string path) => NativeSdl.InternalGL_LoadLibrary(path);

        /// <summary>
        ///     Sdl the gl get proc address using the specified proc
        /// </summary>
        /// <param name="proc">The proc</param>
        /// <returns>The int ptr</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IntPtr GetProcAddress([NotNull] string proc) => NativeSdl.InternalGL_GetProcAddress(proc);

        /// <summary>
        ///     Gls the unload library
        /// </summary>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void UnloadLibrary()
        {
            NativeSdl.InternalGL_UnloadLibrary();
        }

        /// <summary>
        ///     Sdl the gl extension supported using the specified extension
        /// </summary>
        /// <param name="extension">The extension</param>
        /// <returns>The sdl bool</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static SdlBool ExtensionSupported([NotNull] string extension) => NativeSdl.InternalGL_ExtensionSupported(extension);

        /// <summary>
        ///     Gls the reset attributes
        /// </summary>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ResetAttributes()
        {
            NativeSdl.InternalGL_ResetAttributes();
        }

        /// <summary>
        ///     Gls the get attribute using the specified attr
        /// </summary>
        /// <param name="attr">The attr</param>
        /// <param name="value">The value</param>
        /// <returns>The int</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int GetAttribute([NotNull] SdlGlAttr attr, out int value) => NativeSdl.InternalGL_GetAttribute(attr, out value);

        /// <summary>
        ///     Gls the get swap interval
        /// </summary>
        /// <returns>The int</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int GetSwapInterval() => NativeSdl.InternalGL_GetSwapInterval();

        /// <summary>
        ///     Gls the make current using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="context">The context</param>
        /// <returns>The int</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int MakeCurrent([NotNull] IntPtr window, [NotNull] IntPtr context) => NativeSdl.InternalGL_MakeCurrent(window, context);


        /// <summary>
        ///     Gls the get current window
        /// </summary>
        /// <returns>The int ptr</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IntPtr GetCurrentWindow() => NativeSdl.InternalGL_GetCurrentWindow();

        /// <summary>
        ///     Gls the get current context
        /// </summary>
        /// <returns>The int ptr</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IntPtr GetCurrentContext() => NativeSdl.InternalGlGetCurrentContext();

        /// <summary>
        ///     Gls the get drawable size using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="w">The </param>
        /// <param name="h">The </param>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void GetDrawableSize([NotNull] IntPtr window, out int w, out int h)
        {
            NativeSdl.InternalGL_GetDrawableSize(window, out w, out h);
        }

        /// <summary>
        ///     Gls the set attribute using the specified attr
        /// </summary>
        /// <param name="attr">The attr</param>
        /// <param name="value">The value</param>
        /// <returns>The int</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int SetAttributeByInt([NotNull] SdlGlAttr attr, [NotNull] int value) => NativeSdl.InternalGL_SetAttribute(attr, value);

        /// <summary>
        ///     Sdl the gl set attribute using the specified attr
        /// </summary>
        /// <param name="attr">The attr</param>
        /// <param name="profile">The profile</param>
        /// <returns>The int</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int SetAttributeByProfile([NotNull] SdlGlAttr attr, [NotNull] SdlGlProfile profile)
        {
            Validator.ValidateInput(attr);
            Validator.ValidateInput(profile);
            int result = NativeSdl.InternalGL_SetAttribute(attr, (int) profile);
            Validator.ValidateOutput(result);
            return result;
        }

        /// <summary>
        ///     Gls the set swap interval using the specified interval
        /// </summary>
        /// <param name="interval">The interval</param>
        /// <returns>The int</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int SetSwapInterval([NotNull] int interval)
        {
            Validator.ValidateInput(interval);
            int result = NativeSdl.InternalGL_SetSwapInterval(interval);
            Validator.ValidateOutput(result);
            return result;
        }

        /// <summary>
        ///     Gls the swap window using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SwapWindow([NotNull] IntPtr window)
        {
            Validator.ValidateInput(window);
            NativeSdl.InternalGL_SwapWindow(window);
        }

        /// <summary>
        ///     Gls the unbind texture using the specified texture
        /// </summary>
        /// <param name="texture">The texture</param>
        /// <returns>The int</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int UnbindTexture([NotNull] IntPtr texture)
        {
            Validator.ValidateInput(texture);
            int result = NativeSdl.InternalGL_UnbindTexture(texture);
            Validator.ValidateOutput(result);
            return result;
        }

        /// <summary>
        ///     Hides the window using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void HideWindow([NotNull] IntPtr window)
        {
            Validator.ValidateInput(window);
            NativeSdl.InternalHideWindow(window);
        }

        /// <summary>
        ///     Is the screen saver enabled
        /// </summary>
        /// <returns>The sdl bool</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static SdlBool IsScreenSaverEnabled()
        {
            SdlBool result = NativeSdl.InternalIsScreenSaverEnabled();
            Validator.ValidateOutput(result);
            return result;
        }

        /// <summary>
        ///     Maximizes the window using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void MaximizeWindow([NotNull] IntPtr window)
        {
            Validator.ValidateInput(window);
            NativeSdl.InternalMaximizeWindow(window);
        }

        /// <summary>
        ///     Minimizes the window using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void MinimizeWindow([NotNull] IntPtr window)
        {
            Validator.ValidateInput(window);
            NativeSdl.InternalMinimizeWindow(window);
        }

        /// <summary>
        ///     Raises the window using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void RaiseWindow([NotNull] IntPtr window)
        {
            Validator.ValidateInput(window);
            NativeSdl.InternalRaiseWindow(window);
        }

        /// <summary>
        ///     Restores the window using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void RestoreWindow([NotNull] IntPtr window)
        {
            Validator.ValidateInput(window);
            NativeSdl.InternalRestoreWindow(window);
        }

        /// <summary>
        ///     Sets the window brightness using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="brightness">The brightness</param>
        /// <returns>The int</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int SetWindowBrightness([NotNull] IntPtr window, float brightness)
        {
            Validator.ValidateInput(window);
            Validator.ValidateInput(brightness);
            int result = NativeSdl.InternalSetWindowBrightness(window, brightness);
            Validator.ValidateOutput(result);
            return result;
        }

        /// <summary>
        ///     Sdl the set window data using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="name">The name</param>
        /// <param name="userdata">The userdata</param>
        /// <returns>The int ptr</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IntPtr SetWindowData([NotNull] IntPtr window, [NotNull] string name, [NotNull] IntPtr userdata)
        {
            Validator.ValidateInput(window);
            Validator.ValidateInput(name);
            Validator.ValidateInput(userdata);
            IntPtr result = NativeSdl.InternalSetWindowData(window, name, userdata);
            Validator.ValidateOutput(result);
            return result;
        }

        /// <summary>
        ///     Sets the window display mode using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="mode">The mode</param>
        /// <returns>The int</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int SetWindowDisplayMode([NotNull] IntPtr window, ref SdlDisplayMode mode)
        {
            Validator.ValidateInput(window);
            Validator.ValidateInput(mode);
            int result = NativeSdl.InternalSetWindowDisplayMode(window, ref mode);
            Validator.ValidateOutput(result);
            return result;
        }

        /// <summary>
        ///     Sets the window display mode using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="mode">The mode</param>
        /// <returns>The int</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int SetWindowDisplayMode([NotNull] IntPtr window, [NotNull] IntPtr mode)
        {
            Validator.ValidateInput(window);
            Validator.ValidateInput(mode);
            int result = NativeSdl.InternalSetWindowDisplayMode(window, mode);
            Validator.ValidateOutput(result);
            return result;
        }

        /// <summary>
        ///     Sets the window fullscreen using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="flags">The flags</param>
        /// <returns>The int</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int SetWindowFullscreen([NotNull] IntPtr window, [NotNull] uint flags)
        {
            Validator.ValidateInput(window);
            Validator.ValidateInput(flags);
            int result = NativeSdl.InternalSetWindowFullscreen(window, flags);
            Validator.ValidateOutput(result);
            return result;
        }

        /// <summary>
        ///     Sets the window gamma ramp using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="red">The red</param>
        /// <param name="green">The green</param>
        /// <param name="blue">The blue</param>
        /// <returns>The int</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int SetWindowGammaRamp([NotNull] IntPtr window, [In, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U2, SizeConst = 256)] ushort[] red, [In, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U2, SizeConst = 256)] ushort[] green, [In, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U2, SizeConst = 256)] ushort[] blue)
        {
            Validator.ValidateInput(window);
            Validator.ValidateInput(red);
            Validator.ValidateInput(green);
            Validator.ValidateInput(blue);
            int result = NativeSdl.InternalSetWindowGammaRamp(window, red, green, blue);
            Validator.ValidateOutput(result);
            return result;
        }

        /// <summary>
        ///     Sets the window grab using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="grabbed">The grabbed</param>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetWindowGrab([NotNull] IntPtr window, [NotNull] SdlBool grabbed)
        {
            Validator.ValidateInput(window);
            Validator.ValidateInput(grabbed);
            NativeSdl.InternalSetWindowGrab(window, grabbed);
        }

        /// <summary>
        ///     Sets the window keyboard grab using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="grabbed">The grabbed</param>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetWindowKeyboardGrab([NotNull] IntPtr window, [NotNull] SdlBool grabbed)
        {
            Validator.ValidateInput(window);
            Validator.ValidateInput(grabbed);
            NativeSdl.InternalSetWindowKeyboardGrab(window, grabbed);
        }

        /// <summary>
        ///     Sets the window mouse grab using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="grabbed">The grabbed</param>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetWindowMouseGrab([NotNull] IntPtr window, SdlBool grabbed)
        {
            Validator.ValidateInput(window);
            Validator.ValidateInput(grabbed);
            NativeSdl.InternalSetWindowMouseGrab(window, grabbed);
        }

        /// <summary>
        ///     Sets the window icon using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="icon">The icon</param>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetWindowIcon([NotNull] IntPtr window, [NotNull] IntPtr icon)
        {
            Validator.ValidateInput(window);
            Validator.ValidateInput(icon);
            NativeSdl.InternalSetWindowIcon(window, icon);
        }

        /// <summary>
        ///     Sets the window maximum size using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="maxW">The max</param>
        /// <param name="maxH">The max</param>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetWindowMaximumSize([NotNull] IntPtr window, [NotNull] int maxW, [NotNull] int maxH)
        {
            Validator.ValidateInput(window);
            Validator.ValidateInput(maxW);
            Validator.ValidateInput(maxH);
            NativeSdl.InternalSetWindowMaximumSize(window, maxW, maxH);
        }

        /// <summary>
        ///     Sets the window minimum size using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="minW">The min</param>
        /// <param name="minH">The min</param>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetWindowMinimumSize([NotNull] IntPtr window, [NotNull] int minW, [NotNull] int minH)
        {
            Validator.ValidateInput(window);
            Validator.ValidateInput(minW);
            Validator.ValidateInput(minH);
            NativeSdl.InternalSetWindowMinimumSize(window, minW, minH);
        }

        /// <summary>
        ///     Sets the window position using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="x">The </param>
        /// <param name="y">The </param>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetWindowPosition([NotNull] IntPtr window, [NotNull] int x, [NotNull] int y)
        {
            Validator.ValidateInput(window);
            Validator.ValidateInput(x);
            Validator.ValidateInput(y);
            NativeSdl.InternalSetWindowPosition(window, x, y);
        }

        /// <summary>
        ///     Sets the window size using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="w">The </param>
        /// <param name="h">The </param>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetWindowSize([NotNull] IntPtr window, [NotNull] int w, [NotNull] int h)
        {
            Validator.ValidateInput(window);
            Validator.ValidateInput(w);
            Validator.ValidateInput(h);
            NativeSdl.InternalSetWindowSize(window, w, h);
        }

        /// <summary>
        ///     Sets the window bordered using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="bordered">The bordered</param>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetWindowBordered([NotNull] IntPtr window, SdlBool bordered)
        {
            Validator.ValidateInput(window);
            Validator.ValidateInput(bordered);
            NativeSdl.InternalSetWindowBordered(window, bordered);
        }

        /// <summary>
        ///     Gets the window borders size using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="top">The top</param>
        /// <param name="left">The left</param>
        /// <param name="bottom">The bottom</param>
        /// <param name="right">The right</param>
        /// <returns>The int</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int GetWindowBordersSize([NotNull] IntPtr window, out int top, out int left, out int bottom, out int right)
        {
            Validator.ValidateInput(window);
            int result = NativeSdl.InternalGetWindowBordersSize(window, out top, out left, out bottom, out right);
            Validator.ValidateOutput(result);
            return result;
        }

        /// <summary>
        ///     Sets the window resizable using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="resizable">The resizable</param>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetWindowResizable([NotNull] IntPtr window, SdlBool resizable)
        {
            Validator.ValidateInput(window);
            Validator.ValidateInput(resizable);
            NativeSdl.InternalSetWindowResizable(window, resizable);
        }

        /// <summary>
        ///     Sets the window always on top using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="onTop">The on top</param>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetWindowAlwaysOnTop([NotNull] IntPtr window, SdlBool onTop)
        {
            Validator.ValidateInput(window);
            Validator.ValidateInput(onTop);
            NativeSdl.InternalSetWindowAlwaysOnTop(window, onTop);
        }

        /// <summary>
        ///     Sdl the set window title using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="title">The title</param>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetWindowTitle([NotNull] IntPtr window, [NotNull] string title)
        {
            Validator.ValidateInput(window);
            Validator.ValidateInput(title);
            NativeSdl.InternalSetWindowTitle(window, title);
        }

        /// <summary>
        ///     Shows the window using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ShowWindow([NotNull] IntPtr window)
        {
            Validator.ValidateInput(window);
            NativeSdl.InternalShowWindow(window);
        }

        /// <summary>
        ///     Updates the window surface using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <returns>The int</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int UpdateWindowSurface([NotNull] IntPtr window)
        {
            Validator.ValidateInput(window);
            int result = NativeSdl.InternalUpdateWindowSurface(window);
            Validator.ValidateOutput(result);
            return result;
        }

        /// <summary>
        ///     Updates the window surface rects using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="rects">The rects</param>
        /// <param name="numRects">The num rects</param>
        /// <returns>The int</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int UpdateWindowSurfaceRects([NotNull] IntPtr window, [In] RectangleI[] rects, [NotNull] int numRects)
        {
            Validator.ValidateInput(window);
            Validator.ValidateInput(rects);
            Validator.ValidateInput(numRects);
            int result = NativeSdl.InternalUpdateWindowSurfaceRects(window, rects, numRects);
            Validator.ValidateOutput(result);
            return result;
        }

        /// <summary>
        ///     Sdl the video init using the specified driver name
        /// </summary>
        /// <param name="driverName">The driver name</param>
        /// <returns>The int</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int VideoInit([NotNull] string driverName)
        {
            Validator.ValidateInput(driverName);
            int result = NativeSdl.InternalVideoInit(driverName);
            Validator.ValidateOutput(result);
            return result;
        }

        /// <summary>
        ///     Video the quit
        /// </summary>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void VideoQuit()
        {
            NativeSdl.InternalVideoQuit();
        }

        /// <summary>
        ///     Sets the window hit test using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="callback">The callback</param>
        /// <param name="callbackData">The callback data</param>
        /// <returns>The int</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int SetWindowHitTest([NotNull] IntPtr window, SdlHitTest callback, [NotNull] IntPtr callbackData)
        {
            Validator.ValidateInput(window);
            Validator.ValidateInput(callbackData);
            Validator.ValidateInput(callback);
            int result = NativeSdl.InternalSetWindowHitTest(window, callback, callbackData);
            Validator.ValidateOutput(result);
            return result;
        }

        /// <summary>
        ///     Gets the grabbed window
        /// </summary>
        /// <returns>The int ptr</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IntPtr GetGrabbedWindow()
        {
            IntPtr result = NativeSdl.InternalGetGrabbedWindow();
            Validator.ValidateOutput(result);
            return result;
        }

        /// <summary>
        ///     Sets the window mouse rect using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="rect">The rect</param>
        /// <returns>The int</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int SetWindowMouseRect([NotNull] IntPtr window, ref RectangleI rect)
        {
            Validator.ValidateInput(window);
            Validator.ValidateInput(rect);
            int result = NativeSdl.InternalSetWindowMouseRect(window, ref rect);
            Validator.ValidateOutput(result);
            return result;
        }

        /// <summary>
        ///     Sets the window mouse rect using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="rect">The rect</param>
        /// <returns>The int</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int SetWindowMouseRect([NotNull] IntPtr window, [NotNull] IntPtr rect)
        {
            Validator.ValidateInput(window);
            Validator.ValidateInput(rect);
            int result = NativeSdl.InternalSetWindowMouseRect(window, rect);
            Validator.ValidateOutput(result);
            return result;
        }

        /// <summary>
        ///     Gets the window mouse rect using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <returns>The int ptr</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IntPtr GetWindowMouseRect([NotNull] IntPtr window)
        {
            Validator.ValidateInput(window);
            IntPtr result = NativeSdl.InternalGetWindowMouseRect(window);
            Validator.ValidateOutput(result);
            return result;
        }

        /// <summary>
        ///     Flashes the window using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="operation">The operation</param>
        /// <returns>The int</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int FlashWindow([NotNull] IntPtr window, SdlFlashOperation operation)
        {
            Validator.ValidateInput(window);
            int result = NativeSdl.InternalFlashWindow(window, operation);
            Validator.ValidateOutput(result);
            return result;
        }

        /// <summary>
        ///     Composes the custom blend mode using the specified src color factor
        /// </summary>
        /// <param name="srcColorFactor">The src color factor</param>
        /// <param name="dstColorFactor">The dst color factor</param>
        /// <param name="colorOperation">The color operation</param>
        /// <param name="srcAlphaFactor">The src alpha factor</param>
        /// <param name="dstAlphaFactor">The dst alpha factor</param>
        /// <param name="alphaOperation">The alpha operation</param>
        /// <returns>The sdl blend mode</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static SdlBlendMode ComposeCustomBlendMode([NotNull] SdlBlendFactor srcColorFactor, [NotNull] SdlBlendFactor dstColorFactor, [NotNull] SdlBlendOperation colorOperation, [NotNull] SdlBlendFactor srcAlphaFactor, [NotNull] SdlBlendFactor dstAlphaFactor, [NotNull] SdlBlendOperation alphaOperation)
        {
            Validator.ValidateInput(srcColorFactor);
            Validator.ValidateInput(dstColorFactor);
            Validator.ValidateInput(colorOperation);
            Validator.ValidateInput(srcAlphaFactor);
            Validator.ValidateInput(dstAlphaFactor);
            Validator.ValidateInput(alphaOperation);
            SdlBlendMode result = NativeSdl.InternalComposeCustomBlendMode(srcColorFactor, dstColorFactor, colorOperation, srcAlphaFactor, dstAlphaFactor, alphaOperation);
            Validator.ValidateOutput(result);
            return result;
        }

        /// <summary>
        ///     Sdl the vulkan load library using the specified path
        /// </summary>
        /// <param name="path">The path</param>
        /// <returns>The result</returns>
        public static int VulkanLoadLibrary([NotNull] string path)
        {
            Validator.ValidateInput(path);
            int result = NativeSdl.InternalVulkan_LoadLibrary(path);
            Validator.ValidateOutput(result);
            return result;
        }

        /// <summary>
        ///     Vulkan the get vk get instance proc addr
        /// </summary>
        /// <returns>The int ptr</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IntPtr VulkanGetVkGetInstanceProcAddr()
        {
            IntPtr result = NativeSdl.InternalVulkan_GetVkGetInstanceProcAddr();
            Validator.ValidateOutput(result);
            return result;
        }

        /// <summary>
        ///     Vulkan the unload library
        /// </summary>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void VulkanUnloadLibrary()
        {
            NativeSdl.InternalVulkan_UnloadLibrary();
        }

        /// <summary>
        ///     Vulkan the get instance extensions using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="pCount">The count</param>
        /// <param name="pNames">The names</param>
        /// <returns>The sdl bool</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static SdlBool VulkanGetInstanceExtensions([NotNull] IntPtr window, out uint pCount, [NotNull] IntPtr pNames) => NativeSdl.InternalVulkan_GetInstanceExtensions(window, out pCount, pNames);

        /// <summary>
        ///     Vulkan the get instance extensions using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="pCount">The count</param>
        /// <param name="pNames">The names</param>
        /// <returns>The sdl bool</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static SdlBool VulkanGetInstanceExtensions([NotNull] IntPtr window, out uint pCount, [NotNull] IntPtr[] pNames) => NativeSdl.InternalVulkan_GetInstanceExtensions(window, out pCount, pNames);

        /// <summary>
        ///     Vulkan the create surface using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="instance">The instance</param>
        /// <param name="surface">The surface</param>
        /// <returns>The sdl bool</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static SdlBool VulkanCreateSurface([NotNull] IntPtr window, [NotNull] IntPtr instance, out ulong surface) => NativeSdl.InternalVulkan_CreateSurface(window, instance, out surface);

        /// <summary>
        ///     Vulkan the get drawable size using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="w">The </param>
        /// <param name="h">The </param>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void VulkanGetDrawableSize([NotNull] IntPtr window, out int w, out int h)
        {
            NativeSdl.InternalVulkan_GetDrawableSize(window, out w, out h);
        }

        /// <summary>
        ///     Metals the create view using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <returns>The int ptr</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IntPtr MetalCreateView([NotNull] IntPtr window) => NativeSdl.InternalMetal_CreateView(window);

        /// <summary>
        ///     Metals the destroy view using the specified view
        /// </summary>
        /// <param name="view">The view</param>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void MetalDestroyView([NotNull] IntPtr view)
        {
            NativeSdl.InternalMetal_DestroyView(view);
        }

        /// <summary>
        ///     Metals the get layer using the specified view
        /// </summary>
        /// <param name="view">The view</param>
        /// <returns>The int ptr</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IntPtr MetalGetLayer([NotNull] IntPtr view) => NativeSdl.InternalMetal_GetLayer(view);

        /// <summary>
        ///     Metals the get drawable size using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="w">The </param>
        /// <param name="h">The </param>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void MetalGetDrawableSize([NotNull] IntPtr window, out int w, out int h)
        {
            NativeSdl.InternalMetal_GetDrawableSize(window, out w, out h);
        }

        /// <summary>
        ///     Creates the renderer using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="index">The index</param>
        /// <param name="flags">The flags</param>
        /// <returns>The int ptr</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IntPtr CreateRenderer([NotNull] IntPtr window, [NotNull] int index, SdlRendererFlags flags) => NativeSdl.InternalCreateRenderer(window, index, flags);

        /// <summary>
        ///     Creates the software renderer using the specified surface
        /// </summary>
        /// <param name="surface">The surface</param>
        /// <returns>The int ptr</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IntPtr CreateSoftwareRenderer([NotNull] IntPtr surface) => NativeSdl.InternalCreateSoftwareRenderer(surface);

        /// <summary>
        ///     Creates the texture using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="format">The format</param>
        /// <param name="access">The access</param>
        /// <param name="w">The </param>
        /// <param name="h">The </param>
        /// <returns>The int ptr</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IntPtr CreateTexture([NotNull] IntPtr renderer, [NotNull] uint format, [NotNull] int access, [NotNull] int w, [NotNull] int h) => NativeSdl.InternalCreateTexture(renderer, format, access, w, h);

        /// <summary>
        ///     Creates the texture from surface using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="surface">The surface</param>
        /// <returns>The int ptr</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IntPtr CreateTextureFromSurface([NotNull] IntPtr renderer, [NotNull] IntPtr surface) => NativeSdl.InternalCreateTextureFromSurface(renderer, surface);

        /// <summary>
        ///     Destroys the renderer using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void DestroyRenderer([NotNull] IntPtr renderer)
        {
            NativeSdl.InternalDestroyRenderer(renderer);
        }

        /// <summary>
        ///     Destroys the texture using the specified texture
        /// </summary>
        /// <param name="texture">The texture</param>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void DestroyTexture([NotNull] IntPtr texture)
        {
            NativeSdl.InternalDestroyTexture(texture);
        }

        /// <summary>
        ///     Gets the num render drivers
        /// </summary>
        /// <returns>The int</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int GetNumRenderDrivers() => NativeSdl.InternalGetNumRenderDrivers();

        /// <summary>
        ///     Gets the render draw blend mode using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="blendMode">The blend mode</param>
        /// <returns>The int</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int GetRenderDrawBlendMode([NotNull] IntPtr renderer, out SdlBlendMode blendMode) => NativeSdl.InternalGetRenderDrawBlendMode(renderer, out blendMode);

        /// <summary>
        ///     Sets the texture scale mode using the specified texture
        /// </summary>
        /// <param name="texture">The texture</param>
        /// <param name="scaleMode">The scale mode</param>
        /// <returns>The int</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int SetTextureScaleMode([NotNull] IntPtr texture, SdlScaleMode scaleMode) => NativeSdl.InternalSetTextureScaleMode(texture, scaleMode);

        /// <summary>
        ///     Gets the texture scale mode using the specified texture
        /// </summary>
        /// <param name="texture">The texture</param>
        /// <param name="scaleMode">The scale mode</param>
        /// <returns>The int</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int GetTextureScaleMode([NotNull] IntPtr texture, out SdlScaleMode scaleMode) => NativeSdl.InternalGetTextureScaleMode(texture, out scaleMode);

        /// <summary>
        ///     Sets the texture user data using the specified texture
        /// </summary>
        /// <param name="texture">The texture</param>
        /// <param name="userdata">The userdata</param>
        /// <returns>The int</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int SetTextureUserData([NotNull] IntPtr texture, [NotNull] IntPtr userdata) => NativeSdl.InternalSetTextureUserData(texture, userdata);

        /// <summary>
        ///     Internals the sdl get texture user data using the specified texture
        /// </summary>
        /// <param name="texture">The texture</param>
        /// <returns>The int ptr</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IntPtr GetTextureUserData([NotNull] IntPtr texture) => NativeSdl.InternalGetTextureUserData(texture);

        /// <summary>
        ///     Gets the render draw color using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="r">The </param>
        /// <param name="g">The </param>
        /// <param name="b">The </param>
        /// <param name="a">The </param>
        /// <returns>The int</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int GetRenderDrawColor([NotNull] IntPtr renderer, out byte r, out byte g, out byte b, out byte a) => NativeSdl.InternalGetRenderDrawColor(renderer, out r, out g, out b, out a);

        /// <summary>
        ///     Gets the render driver info using the specified index
        /// </summary>
        /// <param name="index">The index</param>
        /// <param name="info">The info</param>
        /// <returns>The int</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int GetRenderDriverInfo([NotNull] int index, out SdlRendererInfo info) => NativeSdl.InternalGetRenderDriverInfo(index, out info);

        /// <summary>
        ///     Gets the renderer using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <returns>The int ptr</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IntPtr GetRenderer([NotNull] IntPtr window) => NativeSdl.InternalGetRenderer(window);

        /// <summary>
        ///     Gets the renderer info using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="info">The info</param>
        /// <returns>The int</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int GetRendererInfo([NotNull] IntPtr renderer, out SdlRendererInfo info) => NativeSdl.InternalGetRendererInfo(renderer, out info);

        /// <summary>
        ///     Gets the renderer output size using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="w">The </param>
        /// <param name="h">The </param>
        /// <returns>The int</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int GetRendererOutputSize([NotNull] IntPtr renderer, out int w, out int h) => NativeSdl.InternalGetRendererOutputSize(renderer, out w, out h);

        /// <summary>
        ///     Gets the texture alpha mod using the specified texture
        /// </summary>
        /// <param name="texture">The texture</param>
        /// <param name="alpha">The alpha</param>
        /// <returns>The int</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int GetTextureAlphaMod([NotNull] IntPtr texture, out byte alpha) => NativeSdl.InternalGetTextureAlphaMod(texture, out alpha);

        /// <summary>
        ///     Gets the texture blend mode using the specified texture
        /// </summary>
        /// <param name="texture">The texture</param>
        /// <param name="blendMode">The blend mode</param>
        /// <returns>The int</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int GetTextureBlendMode([NotNull] IntPtr texture, out SdlBlendMode blendMode) => NativeSdl.InternalGetTextureBlendMode(texture, out blendMode);

        /// <summary>
        ///     Gets the texture color mod using the specified texture
        /// </summary>
        /// <param name="texture">The texture</param>
        /// <param name="r">The </param>
        /// <param name="g">The </param>
        /// <param name="b">The </param>
        /// <returns>The int</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int GetTextureColorMod([NotNull] IntPtr texture, out byte r, out byte g, out byte b) => NativeSdl.InternalGetTextureColorMod(texture, out r, out g, out b);

        /// <summary>
        ///     Locks the texture using the specified texture
        /// </summary>
        /// <param name="texture">The texture</param>
        /// <param name="rect">The rect</param>
        /// <param name="pixels">The pixels</param>
        /// <param name="pitch">The pitch</param>
        /// <returns>The int</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int LockTexture([NotNull] IntPtr texture, ref RectangleI rect, out IntPtr pixels, out int pitch) => NativeSdl.InternalLockTexture(texture, ref rect, out pixels, out pitch);

        /// <summary>
        ///     Locks the texture using the specified texture
        /// </summary>
        /// <param name="texture">The texture</param>
        /// <param name="rect">The rect</param>
        /// <param name="pixels">The pixels</param>
        /// <param name="pitch">The pitch</param>
        /// <returns>The int</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int LockTexture([NotNull] IntPtr texture, [NotNull] IntPtr rect, out IntPtr pixels, out int pitch) => NativeSdl.InternalLockTexture(texture, rect, out pixels, out pitch);

        /// <summary>
        ///     Locks the texture to surface using the specified texture
        /// </summary>
        /// <param name="texture">The texture</param>
        /// <param name="rect">The rect</param>
        /// <param name="surface">The surface</param>
        /// <returns>The int</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int LockTextureToSurface([NotNull] IntPtr texture, ref RectangleI rect, out IntPtr surface) => NativeSdl.InternalLockTextureToSurface(texture, ref rect, out surface);

        /// <summary>
        ///     Locks the texture to surface using the specified texture
        /// </summary>
        /// <param name="texture">The texture</param>
        /// <param name="rect">The rect</param>
        /// <param name="surface">The surface</param>
        /// <returns>The int</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int LockTextureToSurface([NotNull] IntPtr texture, [NotNull] IntPtr rect, out IntPtr surface) => NativeSdl.InternalLockTextureToSurface(texture, rect, out surface);

        /// <summary>
        ///     Queries the texture using the specified texture
        /// </summary>
        /// <param name="texture">The texture</param>
        /// <param name="format">The format</param>
        /// <param name="access">The access</param>
        /// <param name="w">The </param>
        /// <param name="h">The </param>
        /// <returns>The int</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int QueryTexture([NotNull] IntPtr texture, out uint format, out int access, out int w, out int h) => NativeSdl.InternalQueryTexture(texture, out format, out access, out w, out h);

        /// <summary>
        ///     Renders the clear using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <returns>The int</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int RenderClear([NotNull] IntPtr renderer) => NativeSdl.InternalRenderClear(renderer);

        /// <summary>
        ///     Renders the copy using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="texture">The texture</param>
        /// <param name="srcRect">The src rect</param>
        /// <param name="dstRect">The dst rect</param>
        /// <returns>The int</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int RenderCopy([NotNull] IntPtr renderer, [NotNull] IntPtr texture, ref RectangleI srcRect, ref RectangleI dstRect) => NativeSdl.InternalRenderCopy(renderer, texture, ref srcRect, ref dstRect);

        /// <summary>
        ///     Renders the copy using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="texture">The texture</param>
        /// <param name="srcRect">The src rect</param>
        /// <param name="dstRect">The dst rect</param>
        /// <returns>The int</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int RenderCopy([NotNull] IntPtr renderer, [NotNull] IntPtr texture, [NotNull] IntPtr srcRect, ref RectangleI dstRect) => NativeSdl.InternalRenderCopy(renderer, texture, srcRect, ref dstRect);

        /// <summary>
        ///     Renders the copy using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="texture">The texture</param>
        /// <param name="srcRect">The src rect</param>
        /// <param name="dstRect">The dst rect</param>
        /// <returns>The int</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int RenderCopy([NotNull] IntPtr renderer, [NotNull] IntPtr texture, ref RectangleI srcRect, [NotNull] IntPtr dstRect) => NativeSdl.InternalRenderCopy(renderer, texture, ref srcRect, dstRect);

        /// <summary>
        ///     Renders the copy using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="texture">The texture</param>
        /// <param name="srcRect">The src rect</param>
        /// <param name="dstRect">The dst rect</param>
        /// <returns>The int</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int RenderCopy([NotNull] IntPtr renderer, [NotNull] IntPtr texture, [NotNull] IntPtr srcRect, [NotNull] IntPtr dstRect) => NativeSdl.InternalRenderCopy(renderer, texture, srcRect, dstRect);

        /// <summary>
        ///     Renders the copy ex using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="texture">The texture</param>
        /// <param name="srcRect">The src rect</param>
        /// <param name="dstRect">The dst rect</param>
        /// <param name="angle">The angle</param>
        /// <param name="center">The center</param>
        /// <param name="flip">The flip</param>
        /// <returns>The int</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int RenderCopyEx([NotNull] IntPtr renderer, [NotNull] IntPtr texture, ref RectangleI srcRect, ref RectangleI dstRect, double angle, ref PointI center, SdlRendererFlip flip) => NativeSdl.InternalRenderCopyEx(renderer, texture, ref srcRect, ref dstRect, angle, ref center, flip);

        /// <summary>
        ///     Renders the copy ex using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="texture">The texture</param>
        /// <param name="srcRect">The src rect</param>
        /// <param name="dstRect">The dst rect</param>
        /// <param name="angle">The angle</param>
        /// <param name="center">The center</param>
        /// <param name="flip">The flip</param>
        /// <returns>The int</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int RenderCopyEx([NotNull] IntPtr renderer, [NotNull] IntPtr texture, [NotNull] IntPtr srcRect, ref RectangleI dstRect, double angle, ref PointI center, SdlRendererFlip flip) => NativeSdl.InternalRenderCopyEx(renderer, texture, srcRect, ref dstRect, angle, ref center, flip);

        /// <summary>
        ///     Renders the copy ex using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="texture">The texture</param>
        /// <param name="srcRect">The src rect</param>
        /// <param name="dstRect">The dst rect</param>
        /// <param name="angle">The angle</param>
        /// <param name="center">The center</param>
        /// <param name="flip">The flip</param>
        /// <returns>The int</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int RenderCopyEx([NotNull] IntPtr renderer, [NotNull] IntPtr texture, ref RectangleI srcRect, [NotNull] IntPtr dstRect, double angle, ref PointI center, SdlRendererFlip flip) => NativeSdl.InternalRenderCopyEx(renderer, texture, ref srcRect, dstRect, angle, ref center, flip);

        /// <summary>
        ///     Renders the copy ex using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="texture">The texture</param>
        /// <param name="srcRect">The src rect</param>
        /// <param name="dstRect">The dst rect</param>
        /// <param name="angle">The angle</param>
        /// <param name="center">The center</param>
        /// <param name="flip">The flip</param>
        /// <returns>The int</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int RenderCopyEx([NotNull] IntPtr renderer, [NotNull] IntPtr texture, ref RectangleI srcRect, ref RectangleI dstRect, double angle, [NotNull] IntPtr center, SdlRendererFlip flip) => NativeSdl.InternalRenderCopyEx(renderer, texture, ref srcRect, ref dstRect, angle, center, flip);

        /// <summary>
        ///     Renders the copy ex using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="texture">The texture</param>
        /// <param name="srcRect">The src rect</param>
        /// <param name="dstRect">The dst rect</param>
        /// <param name="angle">The angle</param>
        /// <param name="center">The center</param>
        /// <param name="flip">The flip</param>
        /// <returns>The int</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int RenderCopyEx([NotNull] IntPtr renderer, [NotNull] IntPtr texture, [NotNull] IntPtr srcRect, [NotNull] IntPtr dstRect, double angle, ref PointI center, SdlRendererFlip flip) => NativeSdl.InternalRenderCopyEx(renderer, texture, srcRect, dstRect, angle, ref center, flip);

        /// <summary>
        ///     Renders the copy ex using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="texture">The texture</param>
        /// <param name="srcRect">The src rect</param>
        /// <param name="dstRect">The dst rect</param>
        /// <param name="angle">The angle</param>
        /// <param name="center">The center</param>
        /// <param name="flip">The flip</param>
        /// <returns>The int</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int RenderCopyEx([NotNull] IntPtr renderer, [NotNull] IntPtr texture, [NotNull] IntPtr srcRect, ref RectangleI dstRect, double angle, [NotNull] IntPtr center, SdlRendererFlip flip) => NativeSdl.InternalRenderCopyEx(renderer, texture, srcRect, ref dstRect, angle, center, flip);

        /// <summary>
        ///     Renders the copy ex using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="texture">The texture</param>
        /// <param name="srcRect">The src rect</param>
        /// <param name="dstRect">The dst rect</param>
        /// <param name="angle">The angle</param>
        /// <param name="center">The center</param>
        /// <param name="flip">The flip</param>
        /// <returns>The int</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int RenderCopyEx([NotNull] IntPtr renderer, [NotNull] IntPtr texture, ref RectangleI srcRect, [NotNull] IntPtr dstRect, double angle, [NotNull] IntPtr center, SdlRendererFlip flip) => NativeSdl.InternalRenderCopyEx(renderer, texture, ref srcRect, dstRect, angle, center, flip);

        /// <summary>
        ///     Renders the copy ex using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="texture">The texture</param>
        /// <param name="srcRect">The src rect</param>
        /// <param name="dstRect">The dst rect</param>
        /// <param name="angle">The angle</param>
        /// <param name="center">The center</param>
        /// <param name="flip">The flip</param>
        /// <returns>The int</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int RenderCopyEx([NotNull] IntPtr renderer, [NotNull] IntPtr texture, [NotNull] IntPtr srcRect, [NotNull] IntPtr dstRect, double angle, [NotNull] IntPtr center, SdlRendererFlip flip) => NativeSdl.InternalRenderCopyEx(renderer, texture, srcRect, dstRect, angle, center, flip);

        /// <summary>
        ///     Renders the draw line using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="x1">The </param>
        /// <param name="y1">The </param>
        /// <param name="x2">The </param>
        /// <param name="y2">The </param>
        /// <returns>The int</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int RenderDrawLine([NotNull] IntPtr renderer, [NotNull] int x1, [NotNull] int y1, [NotNull] int x2, [NotNull] int y2) => NativeSdl.InternalRenderDrawLine(renderer, x1, y1, x2, y2);

        /// <summary>
        ///     Renders the draw lines using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="points">The points</param>
        /// <param name="count">The count</param>
        /// <returns>The int</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int RenderDrawLines([NotNull] IntPtr renderer, [In] PointI[] points, [NotNull] int count) => NativeSdl.InternalRenderDrawLines(renderer, points, count);

        /// <summary>
        ///     Renders the draw point using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="x">The </param>
        /// <param name="y">The </param>
        /// <returns>The int</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int RenderDrawPoint([NotNull] IntPtr renderer, [NotNull] int x, [NotNull] int y) => NativeSdl.InternalRenderDrawPoint(renderer, x, y);

        /// <summary>
        ///     Renders the draw points using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="points">The points</param>
        /// <param name="count">The count</param>
        /// <returns>The int</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int RenderDrawPoints([NotNull] IntPtr renderer, [In] PointI[] points, [NotNull] int count) => NativeSdl.InternalRenderDrawPoints(renderer, points, count);

        /// <summary>
        ///     Renders the draw rect using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="rect">The rect</param>
        /// <returns>The int</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int RenderDrawRect([NotNull] IntPtr renderer, ref RectangleI rect) => NativeSdl.InternalRenderDrawRect(renderer, ref rect);

        /// <summary>
        ///     Renders the draw rect using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="rect">The rect</param>
        /// <returns>The int</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int RenderDrawRect([NotNull] IntPtr renderer, [NotNull] IntPtr rect) => NativeSdl.InternalRenderDrawRect(renderer, rect);

        /// <summary>
        ///     Renders the draw rects using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="rects">The rects</param>
        /// <param name="count">The count</param>
        /// <returns>The int</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int RenderDrawRects([NotNull] IntPtr renderer, [In] RectangleI[] rects, [NotNull] int count) => NativeSdl.InternalRenderDrawRects(renderer, rects, count);

        /// <summary>
        ///     Renders the fill rect using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="rect">The rect</param>
        /// <returns>The int</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int RenderFillRect([NotNull] IntPtr renderer, ref RectangleI rect) => NativeSdl.InternalRenderFillRect(renderer, ref rect);

        /// <summary>
        ///     Renders the fill rect using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="rect">The rect</param>
        /// <returns>The int</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int RenderFillRect([NotNull] IntPtr renderer, [NotNull] IntPtr rect) => NativeSdl.InternalRenderFillRect(renderer, rect);

        /// <summary>
        ///     Renders the fill rects using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="rects">The rects</param>
        /// <param name="count">The count</param>
        /// <returns>The int</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int RenderFillRects([NotNull] IntPtr renderer, [In] RectangleI[] rects, [NotNull] int count) => NativeSdl.InternalRenderFillRects(renderer, rects, count);

        /// <summary>
        ///     Renders the copy f using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="texture">The texture</param>
        /// <param name="srcRect">The src rect</param>
        /// <param name="dst">The dst rect</param>
        /// <returns>The int</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int RenderCopyF([NotNull] IntPtr renderer, [NotNull] IntPtr texture, ref RectangleI srcRect, ref RectangleF dst) => NativeSdl.InternalRenderCopyF(renderer, texture, ref srcRect, ref dst);

        /// <summary>
        ///     Renders the copy f using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="texture">The texture</param>
        /// <param name="srcRect">The src rect</param>
        /// <param name="dst">The dst rect</param>
        /// <returns>The int</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int RenderCopyF([NotNull] IntPtr renderer, [NotNull] IntPtr texture, [NotNull] IntPtr srcRect, ref RectangleF dst) => NativeSdl.InternalRenderCopyF(renderer, texture, srcRect, ref dst);

        /// <summary>
        ///     Renders the copy f using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="texture">The texture</param>
        /// <param name="srcRect">The src rect</param>
        /// <param name="dstRect">The dst rect</param>
        /// <returns>The int</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int RenderCopyF([NotNull] IntPtr renderer, [NotNull] IntPtr texture, ref RectangleI srcRect, [NotNull] IntPtr dstRect) => NativeSdl.InternalRenderCopyF(renderer, texture, ref srcRect, dstRect);

        /// <summary>
        ///     Renders the copy f using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="texture">The texture</param>
        /// <param name="srcRect">The src rect</param>
        /// <param name="dstRect">The dst rect</param>
        /// <returns>The int</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int RenderCopyF([NotNull] IntPtr renderer, [NotNull] IntPtr texture, [NotNull] IntPtr srcRect, [NotNull] IntPtr dstRect) => NativeSdl.InternalRenderCopyF(renderer, texture, srcRect, dstRect);

        /// <summary>
        ///     Renders the copy ex using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="texture">The texture</param>
        /// <param name="srcRect">The src rect</param>
        /// <param name="dst">The dst rect</param>
        /// <param name="angle">The angle</param>
        /// <param name="center">The center</param>
        /// <param name="flip">The flip</param>
        /// <returns>The int</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int RenderCopyEx([NotNull] IntPtr renderer, [NotNull] IntPtr texture, ref RectangleI srcRect, ref RectangleF dst, double angle, ref PointF center, SdlRendererFlip flip) => NativeSdl.InternalRenderCopyEx(renderer, texture, ref srcRect, ref dst, angle, ref center, flip);

        /// <summary>
        ///     Renders the copy ex using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="texture">The texture</param>
        /// <param name="srcRect">The src rect</param>
        /// <param name="dst">The dst rect</param>
        /// <param name="angle">The angle</param>
        /// <param name="center">The center</param>
        /// <param name="flip">The flip</param>
        /// <returns>The int</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int RenderCopyEx([NotNull] IntPtr renderer, [NotNull] IntPtr texture, [NotNull] IntPtr srcRect, ref RectangleF dst, double angle, ref PointF center, SdlRendererFlip flip) => NativeSdl.InternalRenderCopyEx(renderer, texture, srcRect, ref dst, angle, ref center, flip);

        /// <summary>
        ///     Renders the copy ex f using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="texture">The texture</param>
        /// <param name="srcRect">The src rect</param>
        /// <param name="dstRect">The dst rect</param>
        /// <param name="angle">The angle</param>
        /// <param name="center">The center</param>
        /// <param name="flip">The flip</param>
        /// <returns>The int</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int RenderCopyExF([NotNull] IntPtr renderer, [NotNull] IntPtr texture, ref RectangleI srcRect, [NotNull] IntPtr dstRect, double angle, ref PointF center, SdlRendererFlip flip) => NativeSdl.InternalRenderCopyExF(renderer, texture, ref srcRect, dstRect, angle, ref center, flip);

        /// <summary>
        ///     Renders the copy ex f using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="texture">The texture</param>
        /// <param name="srcRect">The src rect</param>
        /// <param name="dst">The dst rect</param>
        /// <param name="angle">The angle</param>
        /// <param name="center">The center</param>
        /// <param name="flip">The flip</param>
        /// <returns>The int</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int RenderCopyExF([NotNull] IntPtr renderer, [NotNull] IntPtr texture, ref RectangleI srcRect, ref RectangleF dst, double angle, [NotNull] IntPtr center, SdlRendererFlip flip) => NativeSdl.InternalRenderCopyExF(renderer, texture, ref srcRect, ref dst, angle, center, flip);

        /// <summary>
        ///     Renders the copy ex f using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="texture">The texture</param>
        /// <param name="srcRect">The src rect</param>
        /// <param name="dstRect">The dst rect</param>
        /// <param name="angle">The angle</param>
        /// <param name="center">The center</param>
        /// <param name="flip">The flip</param>
        /// <returns>The int</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int RenderCopyExF([NotNull] IntPtr renderer, [NotNull] IntPtr texture, [NotNull] IntPtr srcRect, [NotNull] IntPtr dstRect, double angle, ref PointF center, SdlRendererFlip flip) => NativeSdl.InternalRenderCopyExF(renderer, texture, srcRect, dstRect, angle, ref center, flip);


        /// <summary>
        ///     Renders the copy ex f using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="texture">The texture</param>
        /// <param name="srcRect">The src rect</param>
        /// <param name="dst">The dst rect</param>
        /// <param name="angle">The angle</param>
        /// <param name="center">The center</param>
        /// <param name="flip">The flip</param>
        /// <returns>The int</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int RenderCopyExF([NotNull] IntPtr renderer, [NotNull] IntPtr texture, [NotNull] IntPtr srcRect, ref RectangleF dst, double angle, [NotNull] IntPtr center, SdlRendererFlip flip) => NativeSdl.InternalRenderCopyExF(renderer, texture, srcRect, ref dst, angle, center, flip);


        /// <summary>
        ///     Renders the copy ex f using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="texture">The texture</param>
        /// <param name="srcRect">The src rect</param>
        /// <param name="dstRect">The dst rect</param>
        /// <param name="angle">The angle</param>
        /// <param name="center">The center</param>
        /// <param name="flip">The flip</param>
        /// <returns>The int</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int RenderCopyExF([NotNull] IntPtr renderer, [NotNull] IntPtr texture, ref RectangleI srcRect, [NotNull] IntPtr dstRect, double angle, [NotNull] IntPtr center, SdlRendererFlip flip) => NativeSdl.InternalRenderCopyExF(renderer, texture, ref srcRect, dstRect, angle, center, flip);


        /// <summary>
        ///     Renders the copy ex f using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="texture">The texture</param>
        /// <param name="srcRect">The src rect</param>
        /// <param name="dstRect">The dst rect</param>
        /// <param name="angle">The angle</param>
        /// <param name="center">The center</param>
        /// <param name="flip">The flip</param>
        /// <returns>The int</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int RenderCopyExF([NotNull] IntPtr renderer, [NotNull] IntPtr texture, [NotNull] IntPtr srcRect, [NotNull] IntPtr dstRect, double angle, [NotNull] IntPtr center, SdlRendererFlip flip) => NativeSdl.InternalRenderCopyExF(renderer, texture, srcRect, dstRect, angle, center, flip);


        /// <summary>
        ///     Renders the geometry using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="texture">The texture</param>
        /// <param name="vertices">The vertices</param>
        /// <param name="numVertices">The num vertices</param>
        /// <param name="indices">The indices</param>
        /// <param name="numIndices">The num indices</param>
        /// <returns>The int</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int RenderGeometry([NotNull] IntPtr renderer, [NotNull] IntPtr texture, [In] SdlVertex[] vertices, [NotNull] int numVertices, [In] [NotNull] int[] indices, [NotNull] int numIndices) => NativeSdl.InternalRenderGeometry(renderer, texture, vertices, numVertices, indices, numIndices);

        /// <summary>
        ///     Renders the draw point f using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="x">The </param>
        /// <param name="y">The </param>
        /// <returns>The int</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int RenderDrawPointF([NotNull] IntPtr renderer, float x, float y) => NativeSdl.InternalRenderDrawPointF(renderer, x, y);

        /// <summary>
        ///     Renders the draw points f using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="points">The points</param>
        /// <param name="count">The count</param>
        /// <returns>The int</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int RenderDrawPointsF(IntPtr renderer, [In] PointF[] points, [NotNull] int count) => NativeSdl.InternalRenderDrawPointsF(renderer, points, count);

        /// <summary>
        ///     Renders the draw line f using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="x1">The </param>
        /// <param name="y1">The </param>
        /// <param name="x2">The </param>
        /// <param name="y2">The </param>
        /// <returns>The int</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int RenderDrawLineF([NotNull] IntPtr renderer, float x1, float y1, float x2, float y2) => NativeSdl.InternalRenderDrawLineF(renderer, x1, y1, x2, y2);


        /// <summary>
        ///     Renders the draw lines f using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="points">The points</param>
        /// <param name="count">The count</param>
        /// <returns>The int</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int RenderDrawLinesF([NotNull] IntPtr renderer, [In] PointF[] points, [NotNull] int count) => NativeSdl.InternalRenderDrawLinesF(renderer, points, count);


        /// <summary>
        ///     Renders the draw rect f using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="rect">The rect</param>
        /// <returns>The int</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int RenderDrawRectF([NotNull] IntPtr renderer, ref RectangleF rect) => NativeSdl.InternalRenderDrawRectF(renderer, ref rect);


        /// <summary>
        ///     Renders the draw rect f using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="rect">The rect</param>
        /// <returns>The int</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int RenderDrawRectF([NotNull] IntPtr renderer, [NotNull] IntPtr rect) => NativeSdl.InternalRenderDrawRectF(renderer, rect);


        /// <summary>
        ///     Renders the draw rects f using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="rects">The rects</param>
        /// <param name="count">The count</param>
        /// <returns>The int</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int RenderDrawRectsF([NotNull] IntPtr renderer, [In] RectangleF[] rects, [NotNull] int count) => NativeSdl.InternalRenderDrawRectsF(renderer, rects, count);


        /// <summary>
        ///     Renders the fill rect f using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="rect">The rect</param>
        /// <returns>The int</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int RenderFillRectF([NotNull] IntPtr renderer, RectangleF rect) => NativeSdl.InternalRenderFillRectF(renderer, rect);

        /// <summary>
        ///     Renders the fill rect f using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="rect">The rect</param>
        /// <returns>The int</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int RenderFillRectF([NotNull] IntPtr renderer, [NotNull] IntPtr rect) => NativeSdl.InternalRenderFillRectF(renderer, rect);

        /// <summary>
        ///     Renders the fill rects f using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="rects">The rects</param>
        /// <param name="count">The count</param>
        /// <returns>The int</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int RenderFillRectsF([NotNull] IntPtr renderer, [In] RectangleF[] rects, [NotNull] int count) => NativeSdl.InternalRenderFillRectsF(renderer, rects, count);


        /// <summary>
        ///     Renders the get clip rect using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="rect">The rect</param>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void RenderGetClipRect([NotNull] IntPtr renderer, out RectangleI rect)
        {
            NativeSdl.InternalRenderGetClipRect(renderer, out rect);
        }


        /// <summary>
        ///     Renders the get logical size using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="w">The </param>
        /// <param name="h">The </param>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void RenderGetLogicalSize([NotNull] IntPtr renderer, out int w, out int h)
        {
            NativeSdl.InternalRenderGetLogicalSize(renderer, out w, out h);
        }


        /// <summary>
        ///     Renders the get scale using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="scaleX">The scale</param>
        /// <param name="scaleY">The scale</param>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void RenderGetScale([NotNull] IntPtr renderer, out float scaleX, out float scaleY)
        {
            NativeSdl.InternalRenderGetScale(renderer, out scaleX, out scaleY);
        }


        /// <summary>
        ///     Renders the window to logical using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="windowX">The window</param>
        /// <param name="windowY">The window</param>
        /// <param name="logicalX">The logical</param>
        /// <param name="logicalY">The logical</param>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void RenderWindowToLogical([NotNull] IntPtr renderer, [NotNull] int windowX, [NotNull] int windowY, out float logicalX, out float logicalY)
        {
            NativeSdl.InternalRenderWindowToLogical(renderer, windowX, windowY, out logicalX, out logicalY);
        }


        /// <summary>
        ///     Renders the logical to window using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="logicalX">The logical</param>
        /// <param name="logicalY">The logical</param>
        /// <param name="windowX">The window</param>
        /// <param name="windowY">The window</param>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void RenderLogicalToWindow([NotNull] IntPtr renderer, float logicalX, float logicalY, out int windowX, out int windowY)
        {
            NativeSdl.InternalRenderLogicalToWindow(renderer, logicalX, logicalY, out windowX, out windowY);
        }


        /// <summary>
        ///     Renders the get viewport using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="rect">The rect</param>
        /// <returns>The int</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int RenderGetViewport([NotNull] IntPtr renderer, out RectangleI rect) => NativeSdl.InternalRenderGetViewport(renderer, out rect);

        /// <summary>
        ///     Renders the present using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void RenderPresent(IntPtr renderer)
        {
            NativeSdl.InternalRenderPresent(renderer);
        }

        /// <summary>
        ///     Renders the read pixels using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="rect">The rect</param>
        /// <param name="format">The format</param>
        /// <param name="pixels">The pixels</param>
        /// <param name="pitch">The pitch</param>
        /// <returns>The int</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int RenderReadPixels([NotNull] IntPtr renderer, ref RectangleI rect, [NotNull] uint format, [NotNull] IntPtr pixels, [NotNull] int pitch) => NativeSdl.InternalRenderReadPixels(renderer, ref rect, format, pixels, pitch);


        /// <summary>
        ///     Renders the set clip rect using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="rect">The rect</param>
        /// <returns>The int</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int RenderSetClipRect([NotNull] IntPtr renderer, ref RectangleI rect) => NativeSdl.InternalRenderSetClipRect(renderer, ref rect);


        /// <summary>
        ///     Renders the set clip rect using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="rect">The rect</param>
        /// <returns>The int</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int RenderSetClipRect([NotNull] IntPtr renderer, [NotNull] IntPtr rect) => NativeSdl.InternalRenderSetClipRect(renderer, rect);


        /// <summary>
        ///     Renders the set logical size using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="w">The </param>
        /// <param name="h">The </param>
        /// <returns>The int</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int RenderSetLogicalSize([NotNull] IntPtr renderer, [NotNull] int w, [NotNull] int h) => NativeSdl.InternalRenderSetLogicalSize(renderer, w, h);


        /// <summary>
        ///     Renders the set scale using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="scaleX">The scale</param>
        /// <param name="scaleY">The scale</param>
        /// <returns>The int</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int RenderSetScale([NotNull] IntPtr renderer, float scaleX, float scaleY) => NativeSdl.InternalRenderSetScale(renderer, scaleX, scaleY);


        /// <summary>
        ///     Renders the set integer scale using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="enable">The enable</param>
        /// <returns>The int</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int RenderSetIntegerScale([NotNull] IntPtr renderer, SdlBool enable) => NativeSdl.InternalRenderSetIntegerScale(renderer, enable);

        /// <summary>
        ///     Renders the set viewport using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="rect">The rect</param>
        /// <returns>The int</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int RenderSetViewport([NotNull] IntPtr renderer, ref RectangleI rect) => NativeSdl.InternalRenderSetViewport(renderer, ref rect);


        /// <summary>
        ///     Sets the render draw blend mode using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="blendMode">The blend mode</param>
        /// <returns>The int</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int SetRenderDrawBlendMode([NotNull] IntPtr renderer, SdlBlendMode blendMode) => NativeSdl.InternalSetRenderDrawBlendMode(renderer, blendMode);

        /// <summary>
        ///     Sets the render draw color using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="r">The </param>
        /// <param name="g">The </param>
        /// <param name="b">The </param>
        /// <param name="a">The </param>
        /// <returns>The int</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int SetRenderDrawColor([NotNull] IntPtr renderer, [NotNull] byte r, [NotNull] byte g, [NotNull] byte b, [NotNull] byte a) => NativeSdl.InternalSetRenderDrawColor(renderer, r, g, b, a);


        /// <summary>
        ///     Sets the render target using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="texture">The texture</param>
        /// <returns>The int</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int SetRenderTarget([NotNull] IntPtr renderer, [NotNull] IntPtr texture) => NativeSdl.InternalSetRenderTarget(renderer, texture);

        /// <summary>
        ///     Sets the texture alpha mod using the specified texture
        /// </summary>
        /// <param name="texture">The texture</param>
        /// <param name="alpha">The alpha</param>
        /// <returns>The int</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int SetTextureAlphaMod([NotNull] IntPtr texture, [NotNull] byte alpha) => NativeSdl.InternalSetTextureAlphaMod(texture, alpha);


        /// <summary>
        ///     Sets the texture blend mode using the specified texture
        /// </summary>
        /// <param name="texture">The texture</param>
        /// <param name="blendMode">The blend mode</param>
        /// <returns>The int</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int SetTextureBlendMode([NotNull] IntPtr texture, SdlBlendMode blendMode) => NativeSdl.InternalSetTextureBlendMode(texture, blendMode);


        /// <summary>
        ///     Sets the texture color mod using the specified texture
        /// </summary>
        /// <param name="texture">The texture</param>
        /// <param name="r">The </param>
        /// <param name="g">The </param>
        /// <param name="b">The </param>
        /// <returns>The int</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int SetTextureColorMod([NotNull] IntPtr texture, [NotNull] byte r, [NotNull] byte g, [NotNull] byte b) => NativeSdl.InternalSetTextureColorMod(texture, r, g, b);


        /// <summary>
        ///     Unlocks the texture using the specified texture
        /// </summary>
        /// <param name="texture">The texture</param>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void UnlockTexture([NotNull] IntPtr texture)
        {
            NativeSdl.InternalUnlockTexture(texture);
        }

        /// <summary>
        ///     Updates the texture using the specified texture
        /// </summary>
        /// <param name="texture">The texture</param>
        /// <param name="rect">The rect</param>
        /// <param name="pixels">The pixels</param>
        /// <param name="pitch">The pitch</param>
        /// <returns>The int</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int UpdateTexture([NotNull] IntPtr texture, ref RectangleI rect, [NotNull] IntPtr pixels, [NotNull] int pitch) => NativeSdl.InternalUpdateTexture(texture, ref rect, pixels, pitch);

        /// <summary>
        ///     Updates the texture using the specified texture
        /// </summary>
        /// <param name="texture">The texture</param>
        /// <param name="rect">The rect</param>
        /// <param name="pixels">The pixels</param>
        /// <param name="pitch">The pitch</param>
        /// <returns>The int</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int UpdateTexture([NotNull] IntPtr texture, [NotNull] IntPtr rect, [NotNull] IntPtr pixels, [NotNull] int pitch) => NativeSdl.InternalUpdateTexture(texture, rect, pixels, pitch);

        /// <summary>
        ///     Updates the nv texture using the specified texture
        /// </summary>
        /// <param name="texture">The texture</param>
        /// <param name="rect">The rect</param>
        /// <param name="yPlane">The plane</param>
        /// <param name="yPitch">The pitch</param>
        /// <param name="uvPlane">The uv plane</param>
        /// <param name="uvPitch">The uv pitch</param>
        /// <returns>The int</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int UpdateNvTexture([NotNull] IntPtr texture, ref RectangleI rect, [NotNull] IntPtr yPlane, [NotNull] int yPitch, [NotNull] IntPtr uvPlane, [NotNull] int uvPitch) => NativeSdl.InternalUpdateNVTexture(texture, ref rect, yPlane, yPitch, uvPlane, uvPitch);

        /// <summary>
        ///     Renders the target supported using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <returns>The sdl bool</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static SdlBool RenderTargetSupported([NotNull] IntPtr renderer) => NativeSdl.InternalRenderTargetSupported(renderer);

        /// <summary>
        ///     Gets the render target using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <returns>The int ptr</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IntPtr GetRenderTarget([NotNull] IntPtr renderer) => NativeSdl.InternalGetRenderTarget(renderer);

        /// <summary>
        ///     Renders the get metal layer using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <returns>The int ptr</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IntPtr RenderGetMetalLayer([NotNull] IntPtr renderer) => NativeSdl.InternalRenderGetMetalLayer(renderer);

        /// <summary>
        ///     Renders the get metal command encoder using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <returns>The int ptr</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IntPtr RenderGetMetalCommandEncoder([NotNull] IntPtr renderer) => NativeSdl.InternalRenderGetMetalCommandEncoder(renderer);

        /// <summary>
        ///     Renders the set v sync using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="vsync">The vsync</param>
        /// <returns>The int</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int RenderSetVSync([NotNull] IntPtr renderer, [NotNull] int vsync) => NativeSdl.InternalRenderSetVSync(renderer, vsync);

        /// <summary>
        ///     Renders the is clip enabled using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <returns>The sdl bool</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static SdlBool RenderIsClipEnabled([NotNull] IntPtr renderer) => NativeSdl.InternalRenderIsClipEnabled(renderer);

        /// <summary>
        ///     Renders the flush using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <returns>The int</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int RenderFlush([NotNull] IntPtr renderer) => NativeSdl.InternalRenderFlush(renderer);

        /// <summary>
        ///     Sdl the define pixel fourcc using the specified a
        /// </summary>
        /// <param name="a">The </param>
        /// <param name="b">The </param>
        /// <param name="c">The </param>
        /// <param name="d">The </param>
        /// <returns>The uint</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint SdlDefinePixelFourcc([NotNull] byte a, [NotNull] byte b, [NotNull] byte c, [NotNull] byte d) => Fourcc(a, b, c, d);

        /// <summary>
        ///     Sdl the define pixel format using the specified type
        /// </summary>
        /// <param name="typePixel">The type</param>
        /// <param name="order">The order</param>
        /// <param name="layout">The layout</param>
        /// <param name="bits">The bits</param>
        /// <param name="bytes">The bytes</param>
        /// <returns>The uint</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint SdlDefinePixelFormat(TypePixel typePixel, [NotNull] uint order, PackedLayout layout, [NotNull] byte bits, [NotNull] byte bytes) => (uint) ((1 << 28) | ((byte) typePixel << 24) | ((byte) order << 20) | ((byte) layout << 16) | (bits << 8) | bytes);

        /// <summary>
        ///     Sdl the pixel flag using the specified x
        /// </summary>
        /// <param name="x">The </param>
        /// <returns>The byte</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte SdlPixelFlag([NotNull] uint x) => (byte) ((x >> 28) & 0x0F);

        /// <summary>
        ///     Sdl the pixel type using the specified x
        /// </summary>
        /// <param name="x">The </param>
        /// <returns>The byte</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte SdlPixelType([NotNull] uint x) => (byte) ((x >> 24) & 0x0F);

        /// <summary>
        ///     Sdl the pixel order using the specified x
        /// </summary>
        /// <param name="x">The </param>
        /// <returns>The byte</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte SdlPixelOrder([NotNull] uint x) => (byte) ((x >> 20) & 0x0F);

        /// <summary>
        ///     Sdl the pixel layout using the specified x
        /// </summary>
        /// <param name="x">The </param>
        /// <returns>The byte</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte SdlPixelLayout([NotNull] uint x) => (byte) ((x >> 16) & 0x0F);

        /// <summary>
        ///     Sdl the bits per pixel using the specified x
        /// </summary>
        /// <param name="x">The </param>
        /// <returns>The byte</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte SdlBitsPerPixel([NotNull] uint x) => (byte) ((x >> 8) & 0xFF);

        /// <summary>
        ///     Sdl the bytes per pixel using the specified x
        /// </summary>
        /// <param name="x">The </param>
        /// <returns>The byte</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte SdlBytesPerPixel([NotNull] uint x)
        {
            if (SdlIsPixelFormatFour(x))
            {
                if (x == GlFormatYuy2 ||
                    x == GlFormatUy ||
                    x == GlFormatYv)
                {
                    return 2;
                }

                return 1;
            }

            return (byte) (x & 0xFF);
        }

        /// <summary>
        ///     Describes whether sdl is pixel format indexed
        /// </summary>
        /// <param name="format">The format</param>
        /// <returns>The bool</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsPixelFormatIndexed([NotNull] uint format)
        {
            if (SdlIsPixelFormatFour(format))
            {
                return false;
            }

            TypePixel pTypePixel =
                (TypePixel) SdlPixelType(format);
            return pTypePixel == TypePixel.TypeIndex1 ||
                   pTypePixel == TypePixel.TypeIndex4 ||
                   pTypePixel == TypePixel.TypeIndex8;
        }

        /// <summary>
        ///     Describes whether sdl is pixel format packed
        /// </summary>
        /// <param name="format">The format</param>
        /// <returns>The bool</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool SdlIsPixelFormatPacked([NotNull] uint format)
        {
            if (SdlIsPixelFormatFour(format))
            {
                return false;
            }

            TypePixel pTypePixel =
                (TypePixel) SdlPixelType(format);
            return pTypePixel == TypePixel.TypePacked8 ||
                   pTypePixel == TypePixel.TypePacked16 ||
                   pTypePixel == TypePixel.TypePacked32;
        }

        /// <summary>
        ///     Describes whether sdl is pixel format array
        /// </summary>
        /// <param name="format">The format</param>
        /// <returns>The bool</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool SdlIsPixelFormatArray([NotNull] uint format)
        {
            if (SdlIsPixelFormatFour(format))
            {
                return false;
            }

            TypePixel pTypePixel =
                (TypePixel) SdlPixelType(format);
            return pTypePixel == TypePixel.TypeArrayU8 ||
                   pTypePixel == TypePixel.TypeArrayU16 ||
                   pTypePixel == TypePixel.TypeArrayU32 ||
                   pTypePixel == TypePixel.TypeArrayF16 ||
                   pTypePixel == TypePixel.TypeArrayF32;
        }

        /// <summary>
        ///     Describes whether sdl is pixel format alpha
        /// </summary>
        /// <param name="format">The format</param>
        /// <returns>The bool</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool SdlIsPixelFormatAlpha([NotNull] uint format)
        {
            if (SdlIsPixelFormatPacked(format))
            {
                PackedOrder pOrder =
                    (PackedOrder) SdlPixelOrder(format);
                return pOrder == PackedOrder.PackedOrderARgb ||
                       pOrder == PackedOrder.PackedOrderRGba ||
                       pOrder == PackedOrder.PackedOrderABgr ||
                       pOrder == PackedOrder.PackedOrderBGra;
            }

            if (SdlIsPixelFormatArray(format))
            {
                SdlArrayOrder aOrder =
                    (SdlArrayOrder) SdlPixelOrder(format);
                return aOrder == SdlArrayOrder.SdlArrayOrderArgb ||
                       aOrder == SdlArrayOrder.SdlArrayOrderRgba ||
                       aOrder == SdlArrayOrder.SdlArrayOrderAbgR ||
                       aOrder == SdlArrayOrder.SdlArrayOrderBgrA;
            }

            return false;
        }

        /// <summary>
        ///     Describes whether sdl is pixel format fourcc
        /// </summary>
        /// <param name="format">The format</param>
        /// <returns>The bool</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool SdlIsPixelFormatFour([NotNull] uint format) => (format == 0) && (SdlPixelFlag(format) != 1);

        /// <summary>
        ///     Allow the format using the specified pixel format
        /// </summary>
        /// <param name="pixelFormat">The pixel format</param>
        /// <returns>The int ptr</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IntPtr AllocFormat([NotNull] uint pixelFormat) => NativeSdl.InternalAllocFormat(pixelFormat);

        /// <summary>
        ///     Allow the palette using the specified n colors
        /// </summary>
        /// <param name="nColors">The colors</param>
        /// <returns>The int ptr</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IntPtr AllocPalette([NotNull] int nColors) => NativeSdl.InternalAllocPalette(nColors);

        /// <summary>
        ///     Calculates the gamma ramp using the specified gamma
        /// </summary>
        /// <param name="gamma">The gamma</param>
        /// <param name="ramp">The ramp</param>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void CalculateGammaRamp(float gamma, [Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U2, SizeConst = 256)] ushort[] ramp)
        {
            NativeSdl.InternalCalculateGammaRamp(gamma, ramp);
        }


        /// <summary>
        ///     Frees the format using the specified format
        /// </summary>
        /// <param name="format">The format</param>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void FreeFormat([NotNull] IntPtr format)
        {
            NativeSdl.InternalFreeFormat(format);
        }

        /// <summary>
        ///     Frees the palette using the specified palette
        /// </summary>
        /// <param name="palette">The palette</param>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void FreePalette([NotNull] IntPtr palette)
        {
            NativeSdl.InternalFreePalette(palette);
        }

        /// <summary>
        ///     Sdl the get pixel format name using the specified format
        /// </summary>
        /// <param name="format">The format</param>
        /// <returns>The string</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string GetPixelFormatName([NotNull] uint format) => NativeSdl.InternalGetPixelFormatName(format);

        /// <summary>
        ///     Gets the rgb using the specified pixel
        /// </summary>
        /// <param name="pixel">The pixel</param>
        /// <param name="format">The format</param>
        /// <param name="r">The </param>
        /// <param name="g">The </param>
        /// <param name="b">The </param>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void GetRgb([NotNull] uint pixel, [NotNull] IntPtr format, out byte r, out byte g, out byte b)
        {
            NativeSdl.InternalGetRGB(pixel, format, out r, out g, out b);
        }


        /// <summary>
        ///     Gets the rgba using the specified pixel
        /// </summary>
        /// <param name="pixel">The pixel</param>
        /// <param name="format">The format</param>
        /// <param name="r">The </param>
        /// <param name="g">The </param>
        /// <param name="b">The </param>
        /// <param name="a">The </param>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void GetRgba([NotNull] uint pixel, [NotNull] IntPtr format, out byte r, out byte g, out byte b, out byte a)
        {
            NativeSdl.InternalGetRGBA(pixel, format, out r, out g, out b, out a);
        }

        /// <summary>
        ///     Maps the rgb using the specified format
        /// </summary>
        /// <param name="format">The format</param>
        /// <param name="r">The </param>
        /// <param name="g">The </param>
        /// <param name="b">The </param>
        /// <returns>The uint</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint MapRgb([NotNull] IntPtr format, byte r, [NotNull] byte g, [NotNull] byte b) => NativeSdl.InternalMapRGB(format, r, g, b);


        /// <summary>
        ///     Maps the rgba using the specified format
        /// </summary>
        /// <param name="format">The format</param>
        /// <param name="r">The </param>
        /// <param name="g">The </param>
        /// <param name="b">The </param>
        /// <param name="a">The </param>
        /// <returns>The uint</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint MapRgba([NotNull] IntPtr format, [NotNull] byte r, [NotNull] byte g, [NotNull] byte b, [NotNull] byte a) => NativeSdl.InternalMapRGBA(format, r, g, b, a);

        /// <summary>
        ///     Mask the to pixel format enum using the specified bpp
        /// </summary>
        /// <param name="bpp">The bpp</param>
        /// <param name="rMask">The mask</param>
        /// <param name="gMask">The mask</param>
        /// <param name="bMask">The mask</param>
        /// <param name="aMask">The mask</param>
        /// <returns>The uint</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint MasksToPixelFormatEnum([NotNull] int bpp, [NotNull] uint rMask, [NotNull] uint gMask, [NotNull] uint bMask, [NotNull] uint aMask) => NativeSdl.InternalMasksToPixelFormatEnum(bpp, rMask, gMask, bMask, aMask);

        /// <summary>
        ///     Pixels the format enum to masks using the specified format
        /// </summary>
        /// <param name="format">The format</param>
        /// <param name="bpp">The bpp</param>
        /// <param name="rMask">The mask</param>
        /// <param name="gMask">The mask</param>
        /// <param name="bMask">The mask</param>
        /// <param name="aMask">The mask</param>
        /// <returns>The sdl bool</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static SdlBool FormatEnumToMasks([NotNull] uint format, out int bpp, out uint rMask, out uint gMask, out uint bMask, out uint aMask) => NativeSdl.InternalPixelFormatEnumToMasks(format, out bpp, out rMask, out gMask, out bMask, out aMask);


        /// <summary>
        ///     Sets the palette colors using the specified palette
        /// </summary>
        /// <param name="palette">The palette</param>
        /// <param name="colors">The colors</param>
        /// <param name="firstColor">The first color</param>
        /// <param name="nColors">The colors</param>
        /// <returns>The int</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int SetPaletteColors([NotNull] IntPtr palette, [In] SdlColor[] colors, [NotNull] int firstColor, [NotNull] int nColors) => NativeSdl.InternalSetPaletteColors(palette, colors, firstColor, nColors);


        /// <summary>
        ///     Sets the pixel format palette using the specified format
        /// </summary>
        /// <param name="format">The format</param>
        /// <param name="palette">The palette</param>
        /// <returns>The int</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int SetPixelFormatPalette([NotNull] IntPtr format, [NotNull] IntPtr palette) => NativeSdl.InternalSetPixelFormatPalette(format, palette);


        /// <summary>
        ///     Sdl the point in rect using the specified p
        /// </summary>
        /// <param name="p">The </param>
        /// <param name="r">The </param>
        /// <returns>The sdl bool</returns>
        public static SdlBool PointInRect(ref PointI p, ref RectangleI r) => (p.x >= r.x) && (p.x < r.x + r.w) && (p.y >= r.y) && (p.y < r.y + r.h) ? SdlBool.SdlTrue : SdlBool.SdlFalse;

        /// <summary>
        ///     Encloses the points using the specified points
        /// </summary>
        /// <param name="points">The points</param>
        /// <param name="count">The count</param>
        /// <param name="clip">The clip</param>
        /// <param name="result">The result</param>
        /// <returns>The sdl bool</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static SdlBool EnclosePoints([In] PointI[] points, [NotNull] int count, ref RectangleI clip, out RectangleI result) => NativeSdl.InternalEnclosePoints(points, count, ref clip, out result);

        /// <summary>
        ///     Has the intersection using the specified a
        /// </summary>
        /// <param name="a">The </param>
        /// <param name="b">The </param>
        /// <returns>The sdl bool</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static SdlBool HasIntersection(ref RectangleI a, ref RectangleI b) => NativeSdl.InternalHasIntersection(ref a, ref b);

        /// <summary>
        ///     Intersects the rect using the specified a
        /// </summary>
        /// <param name="a">The </param>
        /// <param name="b">The </param>
        /// <param name="result">The result</param>
        /// <returns>The sdl bool</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static SdlBool IntersectRect(ref RectangleI a, ref RectangleI b, out RectangleI result) => NativeSdl.InternalIntersectRect(ref a, ref b, out result);

        /// <summary>
        ///     Intersects the rect and line using the specified rect
        /// </summary>
        /// <param name="rect">The rect</param>
        /// <param name="x1">The </param>
        /// <param name="y1">The </param>
        /// <param name="x2">The </param>
        /// <param name="y2">The </param>
        /// <returns>The sdl bool</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static SdlBool IntersectRectAndLine(ref RectangleI rect, ref int x1, ref int y1, ref int x2, ref int y2) => NativeSdl.InternalIntersectRectAndLine(ref rect, ref x1, ref y1, ref x2, ref y2);

        /// <summary>
        ///     Sdl the rect empty using the specified r
        /// </summary>
        /// <param name="r">The </param>
        /// <returns>The sdl bool</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static SdlBool RectEmpty(ref RectangleI r) => r.w <= 0 || r.h <= 0 ? SdlBool.SdlTrue : SdlBool.SdlFalse;

        /// <summary>
        ///     Sdl the rect equals using the specified a
        /// </summary>
        /// <param name="a">The </param>
        /// <param name="b">The </param>
        /// <returns>The sdl bool</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static SdlBool RectEquals(ref RectangleI a, ref RectangleI b) => (a.x == b.x) && (a.y == b.y) && (a.w == b.w) && (a.h == b.h) ? SdlBool.SdlTrue : SdlBool.SdlFalse;

        /// <summary>
        ///     Unions the rect using the specified a
        /// </summary>
        /// <param name="a">The </param>
        /// <param name="b">The </param>
        /// <param name="result">The result</param>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void UnionRect(RectangleI a, RectangleI b, out RectangleI result)
        {
            Validator.ValidateInput(a);
            Validator.ValidateInput(b);
            NativeSdl.InternalUnionRect(a, b, out result);
        }

        /// <summary>
        ///     Describes whether sdl must lock
        /// </summary>
        /// <param name="surface">The surface</param>
        /// <returns>The bool</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool SdlMustLock([NotNull] IntPtr surface)
        {
            SdlSurface sur = Marshal.PtrToStructure<SdlSurface>(surface);
            return (sur.flags & RleAccel) != 0;
        }

        /// <summary>
        ///     Blit the surface using the specified src
        /// </summary>
        /// <param name="src">The src</param>
        /// <param name="srcRect">The src rect</param>
        /// <param name="dst">The dst</param>
        /// <param name="dstRect">The dst rect</param>
        /// <returns>The int</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int BlitSurface([NotNull] IntPtr src, ref RectangleI srcRect, [NotNull] IntPtr dst, ref RectangleI dstRect)
        {
            Validator.ValidateInput(src);
            Validator.ValidateInput(srcRect);
            Validator.ValidateInput(dst);
            Validator.ValidateInput(dstRect);
            int result = NativeSdl.InternalBlitSurface(src, ref srcRect, dst, ref dstRect);
            Validator.ValidateOutput(result);
            return result;
        }


        /// <summary>
        ///     Blit the surface using the specified src
        /// </summary>
        /// <param name="src">The src</param>
        /// <param name="srcRect">The src rect</param>
        /// <param name="dst">The dst</param>
        /// <param name="dstRect">The dst rect</param>
        /// <returns>The int</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int BlitSurface([NotNull] IntPtr src, [NotNull] IntPtr srcRect, [NotNull] IntPtr dst, ref RectangleI dstRect)
        {
            Validator.ValidateInput(src);
            Validator.ValidateInput(srcRect);
            Validator.ValidateInput(dst);
            Validator.ValidateInput(dstRect);
            int result = NativeSdl.InternalBlitSurface(src, srcRect, dst, ref dstRect);
            Validator.ValidateOutput(result);
            return result;
        }

        /// <summary>
        ///     Blit the surface using the specified src
        /// </summary>
        /// <param name="src">The src</param>
        /// <param name="srcRect">The src rect</param>
        /// <param name="dst">The dst</param>
        /// <param name="dstRect">The dst rect</param>
        /// <returns>The int</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int BlitSurface([NotNull] IntPtr src, ref RectangleI srcRect, [NotNull] IntPtr dst, [NotNull] IntPtr dstRect)
        {
            Validator.ValidateInput(src);
            Validator.ValidateInput(srcRect);
            Validator.ValidateInput(dst);
            Validator.ValidateInput(dstRect);
            int result = NativeSdl.InternalBlitSurface(src, ref srcRect, dst, dstRect);
            Validator.ValidateOutput(result);
            return result;
        }

        /// <summary>
        ///     Blit the surface using the specified src
        /// </summary>
        /// <param name="src">The src</param>
        /// <param name="srcRect">The src rect</param>
        /// <param name="dst">The dst</param>
        /// <param name="dstRect">The dst rect</param>
        /// <returns>The int</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int BlitSurface([NotNull] IntPtr src, [NotNull] IntPtr srcRect, [NotNull] IntPtr dst, [NotNull] IntPtr dstRect)
        {
            Validator.ValidateInput(src);
            Validator.ValidateInput(srcRect);
            Validator.ValidateInput(dst);
            Validator.ValidateInput(dstRect);
            int result = NativeSdl.InternalBlitSurface(src, srcRect, dst, dstRect);
            Validator.ValidateOutput(result);
            return result;
        }

        /// <summary>
        ///     Converts the surface using the specified src
        /// </summary>
        /// <param name="src">The src</param>
        /// <param name="fmt">The fmt</param>
        /// <param name="flags">The flags</param>
        /// <returns>The int ptr</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IntPtr ConvertSurface([NotNull] IntPtr src, [NotNull] IntPtr fmt, [NotNull] uint flags)
        {
            Validator.ValidateInput(src);
            Validator.ValidateInput(fmt);
            Validator.ValidateInput(flags);
            IntPtr result = NativeSdl.InternalConvertSurface(src, fmt, flags);
            Validator.ValidateOutput(result);
            return result;
        }

        /// <summary>
        ///     Converts the surface format using the specified src
        /// </summary>
        /// <param name="src">The src</param>
        /// <param name="pixelFormat">The pixel format</param>
        /// <param name="flags">The flags</param>
        /// <returns>The int ptr</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IntPtr ConvertSurfaceFormat([NotNull] IntPtr src, [NotNull] uint pixelFormat, [NotNull] uint flags) => NativeSdl.InternalConvertSurfaceFormat(src, pixelFormat, flags);

        /// <summary>
        ///     Creates the rgb surface with format using the specified flags
        /// </summary>
        /// <param name="flags">The flags</param>
        /// <param name="width">The width</param>
        /// <param name="height">The height</param>
        /// <param name="depth">The depth</param>
        /// <param name="format">The format</param>
        /// <returns>The int ptr</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IntPtr CreateRgbSurfaceWithFormat([NotNull] uint flags, [NotNull] int width, [NotNull] int height, [NotNull] int depth, [NotNull] uint format) => NativeSdl.InternalCreateRGBSurfaceWithFormat(flags, width, height, depth, format);


        /// <summary>
        ///     Creates the rgb surface with format from using the specified pixels
        /// </summary>
        /// <param name="pixels">The pixels</param>
        /// <param name="width">The width</param>
        /// <param name="height">The height</param>
        /// <param name="depth">The depth</param>
        /// <param name="pitch">The pitch</param>
        /// <param name="format">The format</param>
        /// <returns>The int ptr</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IntPtr CreateRgbSurfaceWithFormatFrom([NotNull] IntPtr pixels, [NotNull] int width, [NotNull] int height, [NotNull] int depth, [NotNull] int pitch, [NotNull] uint format) => NativeSdl.InternalCreateRGBSurfaceWithFormatFrom(pixels, width, height, depth, pitch, format);


        /// <summary>
        ///     Fills the rect using the specified dst
        /// </summary>
        /// <param name="dst">The dst</param>
        /// <param name="rect">The rect</param>
        /// <param name="color">The color</param>
        /// <returns>The int</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int FillRect([NotNull] IntPtr dst, ref RectangleI rect, [NotNull] uint color) => NativeSdl.InternalFillRect(dst, ref rect, color);

        /// <summary>
        ///     Fills the rect using the specified dst
        /// </summary>
        /// <param name="dst">The dst</param>
        /// <param name="rect">The rect</param>
        /// <param name="color">The color</param>
        /// <returns>The int</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int FillRect([NotNull] IntPtr dst, [NotNull] IntPtr rect, [NotNull] uint color) => NativeSdl.InternalFillRect(dst, rect, color);

        /// <summary>
        ///     Fills the rects using the specified dst
        /// </summary>
        /// <param name="dst">The dst</param>
        /// <param name="rects">The rects</param>
        /// <param name="count">The count</param>
        /// <param name="color">The color</param>
        /// <returns>The int</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int FillRects([NotNull] IntPtr dst, [In] RectangleI[] rects, [NotNull] int count, [NotNull] uint color) => NativeSdl.InternalFillRects(dst, rects, count, color);

        /// <summary>
        ///     Frees the surface using the specified surface
        /// </summary>
        /// <param name="surface">The surface</param>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void FreeSurface([NotNull] IntPtr surface)
        {
            NativeSdl.InternalFreeSurface(surface);
        }

        /// <summary>
        ///     Gets the clip rect using the specified surface
        /// </summary>
        /// <param name="surface">The surface</param>
        /// <param name="rect">The rect</param>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void GetClipRect([NotNull] IntPtr surface, out RectangleI rect)
        {
            NativeSdl.InternalGetClipRect(surface, out rect);
        }

        /// <summary>
        ///     Has the color key using the specified surface
        /// </summary>
        /// <param name="surface">The surface</param>
        /// <returns>The sdl bool</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static SdlBool HasColorKey([NotNull] IntPtr surface) => NativeSdl.InternalHasColorKey(surface);

        /// <summary>
        ///     Gets the color key using the specified surface
        /// </summary>
        /// <param name="surface">The surface</param>
        /// <param name="key">The key</param>
        /// <returns>The int</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int GetColorKey([NotNull] IntPtr surface, out uint key) => NativeSdl.InternalGetColorKey(surface, out key);

        /// <summary>
        ///     Gets the surface alpha mod using the specified surface
        /// </summary>
        /// <param name="surface">The surface</param>
        /// <param name="alpha">The alpha</param>
        /// <returns>The int</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int GetSurfaceAlphaMod([NotNull] IntPtr surface, out byte alpha) => NativeSdl.InternalGetSurfaceAlphaMod(surface, out alpha);

        /// <summary>
        ///     Gets the surface blend mode using the specified surface
        /// </summary>
        /// <param name="surface">The surface</param>
        /// <param name="blendMode">The blend mode</param>
        /// <returns>The int</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int GetSurfaceBlendMode([NotNull] IntPtr surface, out SdlBlendMode blendMode) => NativeSdl.InternalGetSurfaceBlendMode(surface, out blendMode);

        /// <summary>
        ///     Gets the surface color mod using the specified surface
        /// </summary>
        /// <param name="surface">The surface</param>
        /// <param name="r">The </param>
        /// <param name="g">The </param>
        /// <param name="b">The </param>
        /// <returns>The int</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int GetSurfaceColorMod([NotNull] IntPtr surface, out byte r, out byte g, out byte b) => NativeSdl.InternalGetSurfaceColorMod(surface, out r, out g, out b);

        /// <summary>
        ///     Sdl the load bmp using the specified file
        /// </summary>
        /// <param name="file">The file</param>
        /// <returns>The int ptr</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IntPtr LoadBmp([NotNull] string file) => NativeSdl.InternalLoadBMP_RW(RwFromFile(file, "rb"), 1);

        /// <summary>
        ///     Locks the surface using the specified surface
        /// </summary>
        /// <param name="surface">The surface</param>
        /// <returns>The int</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int LockSurface([NotNull] IntPtr surface) => NativeSdl.InternalLockSurface(surface);

        /// <summary>
        ///     Lowers the blit using the specified src
        /// </summary>
        /// <param name="src">The src</param>
        /// <param name="srcRect">The src rect</param>
        /// <param name="dst">The dst</param>
        /// <param name="dstRect">The dst rect</param>
        /// <returns>The int</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int LowerBlit([NotNull] IntPtr src, ref RectangleI srcRect, [NotNull] IntPtr dst, ref RectangleI dstRect) => NativeSdl.InternalLowerBlit(src, ref srcRect, dst, ref dstRect);

        /// <summary>
        ///     Lowers the blit scaled using the specified src
        /// </summary>
        /// <param name="src">The src</param>
        /// <param name="srcRect">The src rect</param>
        /// <param name="dst">The dst</param>
        /// <param name="dstRect">The dst rect</param>
        /// <returns>The int</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int LowerBlitScaled([NotNull] IntPtr src, ref RectangleI srcRect, [NotNull] IntPtr dst, ref RectangleI dstRect) => NativeSdl.InternalLowerBlitScaled(src, ref srcRect, dst, ref dstRect);

        /// <summary>
        ///     Sdl the save bmp using the specified surface
        /// </summary>
        /// <param name="surface">The surface</param>
        /// <param name="file">The file</param>
        /// <returns>The int</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int SaveBmp([NotNull] IntPtr surface, [NotNull] string file) => NativeSdl.InternalSaveBMP_RW(surface, RwFromFile(file, "wb"), 1);

        /// <summary>
        ///     Sets the clip rect using the specified surface
        /// </summary>
        /// <param name="surface">The surface</param>
        /// <param name="rect">The rect</param>
        /// <returns>The sdl bool</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static SdlBool SetClipRect([NotNull] IntPtr surface, ref RectangleI rect) => NativeSdl.InternalSetClipRect(surface, ref rect);

        /// <summary>
        ///     Sets the color key using the specified surface
        /// </summary>
        /// <param name="surface">The surface</param>
        /// <param name="flag">The flag</param>
        /// <param name="key">The key</param>
        /// <returns>The int</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int SetColorKey([NotNull] IntPtr surface, [NotNull] int flag, [NotNull] uint key) => NativeSdl.InternalSetColorKey(surface, flag, key);

        /// <summary>
        ///     Sets the surface alpha mod using the specified surface
        /// </summary>
        /// <param name="surface">The surface</param>
        /// <param name="alpha">The alpha</param>
        /// <returns>The int</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int SetSurfaceAlphaMod([NotNull] IntPtr surface, [NotNull] byte alpha) => NativeSdl.InternalSetSurfaceAlphaMod(surface, alpha);

        /// <summary>
        ///     Sets the surface blend mode using the specified surface
        /// </summary>
        /// <param name="surface">The surface</param>
        /// <param name="blendMode">The blend mode</param>
        /// <returns>The int</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int SetSurfaceBlendMode([NotNull] IntPtr surface, SdlBlendMode blendMode) => NativeSdl.InternalSetSurfaceBlendMode(surface, blendMode);

        /// <summary>
        ///     Sets the surface color mod using the specified surface
        /// </summary>
        /// <param name="surface">The surface</param>
        /// <param name="r">The </param>
        /// <param name="g">The </param>
        /// <param name="b">The </param>
        /// <returns>The int</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int SetSurfaceColorMod([NotNull] IntPtr surface, [NotNull] byte r, [NotNull] byte g, [NotNull] byte b) => NativeSdl.InternalSetSurfaceColorMod(surface, r, g, b);

        /// <summary>
        ///     Sets the surface palette using the specified surface
        /// </summary>
        /// <param name="surface">The surface</param>
        /// <param name="palette">The palette</param>
        /// <returns>The int</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int SetSurfacePalette([NotNull] IntPtr surface, [NotNull] IntPtr palette) => NativeSdl.InternalSetSurfacePalette(surface, palette);

        /// <summary>
        ///     Sets the surface rle using the specified surface
        /// </summary>
        /// <param name="surface">The surface</param>
        /// <param name="flag">The flag</param>
        /// <returns>The int</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int SetSurfaceRle([NotNull] IntPtr surface, [NotNull] int flag) => NativeSdl.InternalSetSurfaceRLE(surface, flag);

        /// <summary>
        ///     Has the surface rle using the specified surface
        /// </summary>
        /// <param name="surface">The surface</param>
        /// <returns>The sdl bool</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static SdlBool HasSurfaceRle([NotNull] IntPtr surface) => NativeSdl.InternalHasSurfaceRLE(surface);

        /// <summary>
        ///     Soft the stretch using the specified src
        /// </summary>
        /// <param name="src">The src</param>
        /// <param name="srcRect">The src rect</param>
        /// <param name="dst">The dst</param>
        /// <param name="dstRect">The dst rect</param>
        /// <returns>The int</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int SoftStretch([NotNull] IntPtr src, ref RectangleI srcRect, [NotNull] IntPtr dst, ref RectangleI dstRect) => NativeSdl.InternalSoftStretch(src, ref srcRect, dst, ref dstRect);

        /// <summary>
        ///     Soft the stretch linear using the specified src
        /// </summary>
        /// <param name="src">The src</param>
        /// <param name="srcRect">The src rect</param>
        /// <param name="dst">The dst</param>
        /// <param name="dstRect">The dst rect</param>
        /// <returns>The int</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int SoftStretchLinear([NotNull] IntPtr src, ref RectangleI srcRect, [NotNull] IntPtr dst, ref RectangleI dstRect) => NativeSdl.InternalSoftStretchLinear(src, ref srcRect, dst, ref dstRect);

        /// <summary>
        ///     Unlocks the surface using the specified surface
        /// </summary>
        /// <param name="surface">The surface</param>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void UnlockSurface([NotNull] IntPtr surface)
        {
            NativeSdl.InternalUnlockSurface(surface);
        }

        /// <summary>
        ///     Uppers the blit using the specified src
        /// </summary>
        /// <param name="src">The src</param>
        /// <param name="srcRect">The src rect</param>
        /// <param name="dst">The dst</param>
        /// <param name="dstRect">The dst rect</param>
        /// <returns>The int</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int UpperBlit([NotNull] IntPtr src, ref RectangleI srcRect, [NotNull] IntPtr dst, ref RectangleI dstRect) => NativeSdl.InternalUpperBlit(src, ref srcRect, dst, ref dstRect);

        /// <summary>
        ///     Uppers the blit scaled using the specified src
        /// </summary>
        /// <param name="src">The src</param>
        /// <param name="srcRect">The src rect</param>
        /// <param name="dst">The dst</param>
        /// <param name="dstRect">The dst rect</param>
        /// <returns>The int</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int UpperBlitScaled([NotNull] IntPtr src, ref RectangleI srcRect, [NotNull] IntPtr dst, ref RectangleI dstRect) => NativeSdl.InternalUpperBlitScaled(src, ref srcRect, dst, ref dstRect);

        /// <summary>
        ///     Duplicates the surface using the specified surface
        /// </summary>
        /// <param name="surface">The surface</param>
        /// <returns>The int ptr</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IntPtr DuplicateSurface([NotNull] IntPtr surface) => NativeSdl.InternalDuplicateSurface(surface);

        /// <summary>
        ///     Has the clipboard text
        /// </summary>
        /// <returns>The sdl bool</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static SdlBool HasClipboardText() => NativeSdl.InternalHasClipboardText();

        /// <summary>
        ///     Sdl the get clipboard text
        /// </summary>
        /// <returns>The string</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string GetClipboardText() => NativeSdl.InternalGetClipboardText();

        /// <summary>
        ///     Sdl the set clipboard text using the specified text
        /// </summary>
        /// <param name="text">The text</param>
        /// <returns>The result</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int SetClipboardText([NotNull] string text) => NativeSdl.InternalSetClipboardText(text);

        /// <summary>
        ///     Pumps the events
        /// </summary>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void PumpEvents()
        {
            NativeSdl.InternalPumpEvents();
        }

        /// <summary>
        ///     Peeps the events using the specified events
        /// </summary>
        /// <param name="events">The events</param>
        /// <param name="numEvents">The num events</param>
        /// <param name="action">The action</param>
        /// <param name="minType">The min type</param>
        /// <param name="maxType">The max type</param>
        /// <returns>The int</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int PeepEvents([Out] SdlEvent[] events, [NotNull] int numEvents, SdlEventAction action, SdlEventType minType, SdlEventType maxType) => NativeSdl.InternalPeepEvents(events, numEvents, action, minType, maxType);


        /// <summary>
        ///     Has the event using the specified type
        /// </summary>
        /// <param name="type">The type</param>
        /// <returns>The sdl bool</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static SdlBool HasEvent(SdlEventType type) => NativeSdl.InternalHasEvent(type);

        /// <summary>
        ///     Has the events using the specified min type
        /// </summary>
        /// <param name="minType">The min type</param>
        /// <param name="maxType">The max type</param>
        /// <returns>The sdl bool</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static SdlBool HasEvents(SdlEventType minType, SdlEventType maxType) => NativeSdl.InternalHasEvents(minType, maxType);

        /// <summary>
        ///     Flushes the event using the specified type
        /// </summary>
        /// <param name="type">The type</param>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void FlushEvent([NotNull] SdlEventType type)
        {
            NativeSdl.InternalFlushEvent(type);
        }

        /// <summary>
        ///     Flushes the events using the specified min
        /// </summary>
        /// <param name="min">The min</param>
        /// <param name="max">The max</param>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void FlushEvents(SdlEventType min, SdlEventType max)
        {
            NativeSdl.InternalFlushEvents(min, max);
        }

        /// <summary>
        ///     Polls the event using the specified sdl event
        /// </summary>
        /// <param name="sdlEvent">The sdl event</param>
        /// <returns>The int</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int PollEvent(out SdlEvent sdlEvent) => NativeSdl.InternalPollEvent(out sdlEvent);

        /// <summary>
        ///     Waits the event using the specified sdl event
        /// </summary>
        /// <param name="sdlEvent">The sdl event</param>
        /// <returns>The int</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int WaitEvent(out SdlEvent sdlEvent) => NativeSdl.InternalWaitEvent(out sdlEvent);

        /// <summary>
        ///     Waits the event timeout using the specified sdl event
        /// </summary>
        /// <param name="sdlEvent">The sdl event</param>
        /// <param name="timeout">The timeout</param>
        /// <returns>The int</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int WaitEventTimeout(out SdlEvent sdlEvent, [NotNull] int timeout) => NativeSdl.InternalWaitEventTimeout(out sdlEvent, timeout);

        /// <summary>
        ///     Pushes the event using the specified sdl event
        /// </summary>
        /// <param name="sdlEvent">The sdl event</param>
        /// <returns>The int</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int PushEvent(ref SdlEvent sdlEvent) => NativeSdl.InternalPushEvent(ref sdlEvent);

        /// <summary>
        ///     Sets the event filter using the specified filter
        /// </summary>
        /// <param name="filter">The filter</param>
        /// <param name="userdata">The userdata</param>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetEventFilter(SdlEventFilter filter, [NotNull] IntPtr userdata)
        {
            NativeSdl.InternalSetEventFilter(filter, userdata);
        }

        /// <summary>
        ///     Sdl the get event filter using the specified filter
        /// </summary>
        /// <param name="filter">The filter</param>
        /// <param name="userdata">The userdata</param>
        /// <returns>The ret val</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static SdlBool GetEventFilter(out SdlEventFilter filter, out IntPtr userdata)
        {
            SdlBool val = NativeSdl.InternalGetEventFilter(out IntPtr result, out userdata);
            if (result != IntPtr.Zero)
            {
                filter = (SdlEventFilter) Marshal.GetDelegateForFunctionPointer(
                    result,
                    typeof(SdlEventFilter)
                );
            }
            else
            {
                filter = null;
            }

            return val;
        }

        /// <summary>
        ///     Adds the event watch using the specified filter
        /// </summary>
        /// <param name="filter">The filter</param>
        /// <param name="userdata">The userdata</param>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void AddEventWatch(SdlEventFilter filter, [NotNull] IntPtr userdata)
        {
            NativeSdl.InternalAddEventWatch(filter, userdata);
        }

        /// <summary>
        ///     Del the event watch using the specified filter
        /// </summary>
        /// <param name="filter">The filter</param>
        /// <param name="userdata">The userdata</param>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void DelEventWatch(SdlEventFilter filter, [NotNull] IntPtr userdata)
        {
            NativeSdl.InternalDelEventWatch(filter, userdata);
        }

        /// <summary>
        ///     Filters the events using the specified filter
        /// </summary>
        /// <param name="filter">The filter</param>
        /// <param name="userdata">The userdata</param>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void FilterEvents([NotNull] SdlEventFilter filter, [NotNull] IntPtr userdata)
        {
            NativeSdl.InternalFilterEvents(filter, userdata);
        }

        /// <summary>
        ///     Sdl the get event state using the specified type
        /// </summary>
        /// <param name="type">The type</param>
        /// <returns>The byte</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte GetEventState(SdlEventType type) => NativeSdl.InternalEventState(type, Query);

        /// <summary>
        ///     Registers the events using the specified num events
        /// </summary>
        /// <param name="numEvents">The num events</param>
        /// <returns>The uint</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint RegisterEvents([NotNull] int numEvents) => NativeSdl.InternalRegisterEvents(numEvents);

        /// <summary>
        ///     Sdl the scancode to keycode using the specified x
        /// </summary>
        /// <param name="x">The </param>
        /// <returns>The sdl keycode</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static SdlKeycode ScanCodeToKeyCode(SdlScancode x) => (SdlKeycode) ((int) x | KScancodeMask);

        /// <summary>
        ///     Gets the keyboard focus
        /// </summary>
        /// <returns>The int ptr</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IntPtr GetKeyboardFocus() => NativeSdl.InternalGetKeyboardFocus();

        /// <summary>
        ///     Gets the keyboard state using the specified num keys
        /// </summary>
        /// <param name="numKeys">The num keys</param>
        /// <returns>The int ptr</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IntPtr GetKeyboardState(out int numKeys) => NativeSdl.InternalGetKeyboardState(out numKeys);

        /// <summary>
        ///     Gets the mod state
        /// </summary>
        /// <returns>The sdl key mod</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static SdlKeyMod GetModState() => NativeSdl.InternalGetModState();

        /// <summary>
        ///     Sets the mod state using the specified mod state
        /// </summary>
        /// <param name="modState">The mod state</param>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetModState(SdlKeyMod modState)
        {
            NativeSdl.InternalSetModState(modState);
        }

        /// <summary>
        ///     Gets the key from scancode using the specified scancode
        /// </summary>
        /// <param name="scancode">The scancode</param>
        /// <returns>The sdl keycode</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static SdlKeycode GetKeyFromScancode(SdlScancode scancode) => NativeSdl.InternalGetKeyFromScancode(scancode);

        /// <summary>
        ///     Gets the scancode from key using the specified key
        /// </summary>
        /// <param name="key">The key</param>
        /// <returns>The sdl scancode</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static SdlScancode GetScancodeFromKey(SdlKeycode key) => NativeSdl.InternalGetScancodeFromKey(key);

        /// <summary>
        ///     Sdl the get scancode name using the specified scancode
        /// </summary>
        /// <param name="scancode">The scancode</param>
        /// <returns>The string</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string GetScancodeName(SdlScancode scancode) => NativeSdl.InternalGetScancodeName(scancode);

        /// <summary>
        ///     Sdl the get scancode from name using the specified name
        /// </summary>
        /// <param name="name">The name</param>
        /// <returns>The sdl scancode</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static SdlScancode GetScancodeFromName([NotNull] string name) => NativeSdl.InternalGetScancodeFromName(name);

        /// <summary>
        ///     Sdl the get key name using the specified key
        /// </summary>
        /// <param name="key">The key</param>
        /// <returns>The string</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string SGetKeyName(SdlKeycode key) => NativeSdl.InternalGetKeyName(key);

        /// <summary>
        ///     Sdl the get key from name using the specified name
        /// </summary>
        /// <param name="name">The name</param>
        /// <returns>The sdl keycode</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static SdlKeycode GetKeyFromName([NotNull] string name) => NativeSdl.InternalGetKeyFromName(name);

        /// <summary>
        ///     Starts the text input
        /// </summary>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void StartTextInput()
        {
            NativeSdl.InternalStartTextInput();
        }

        /// <summary>
        ///     Is the text input active
        /// </summary>
        /// <returns>The sdl bool</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static SdlBool IsTextInputActive() => NativeSdl.InternalIsTextInputActive();

        /// <summary>
        ///     Stops the text input
        /// </summary>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void StopTextInput()
        {
            NativeSdl.InternalStopTextInput();
        }

        /// <summary>
        ///     Sets the text input rect using the specified rect
        /// </summary>
        /// <param name="rect">The rect</param>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetTextInputRect(ref RectangleI rect)
        {
            NativeSdl.InternalSetTextInputRect(ref rect);
        }

        /// <summary>
        ///     Has the screen keyboard support
        /// </summary>
        /// <returns>The sdl bool</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static SdlBool HasScreenKeyboardSupport() => NativeSdl.InternalHasScreenKeyboardSupport();

        /// <summary>
        ///     Is the screen keyboard shown using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <returns>The sdl bool</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static SdlBool IsScreenKeyboardShown([NotNull] IntPtr window) => NativeSdl.InternalIsScreenKeyboardShown(window);

        /// <summary>
        ///     Gets the mouse focus
        /// </summary>
        /// <returns>The int ptr</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IntPtr GetMouseFocus() => NativeSdl.InternalGetMouseFocus();

        /// <summary>
        ///     Gets the mouse state using the specified x
        /// </summary>
        /// <param name="x">The </param>
        /// <param name="y">The </param>
        /// <returns>The uint</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint GetMouseStateOutXAndY(out int x, out int y) => NativeSdl.InternalGetMouseState(out x, out y);

        /// <summary>
        ///     Gets the mouse state using the specified x
        /// </summary>
        /// <param name="x">The </param>
        /// <param name="y">The </param>
        /// <returns>The uint</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint GetMouseStateXAndYOut([NotNull] IntPtr x, out int y) => NativeSdl.InternalGetMouseState(x, out y);

        /// <summary>
        ///     Gets the mouse state using the specified x
        /// </summary>
        /// <param name="x">The </param>
        /// <param name="y">The </param>
        /// <returns>The uint</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint GetMouseStateXOutAndY(out int x, [NotNull] IntPtr y) => NativeSdl.InternalGetMouseState(out x, y);

        /// <summary>
        ///     Gets the mouse state using the specified x
        /// </summary>
        /// <param name="x">The </param>
        /// <param name="y">The </param>
        /// <returns>The uint</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint GetMouseStateToXAndY([NotNull] IntPtr x, [NotNull] IntPtr y) => NativeSdl.InternalGetMouseState(x, y);

        /// <summary>
        ///     Gets the global mouse state using the specified x
        /// </summary>
        /// <param name="x">The </param>
        /// <param name="y">The </param>
        /// <returns>The uint</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint GetGlobalMouseStateOutXAndOutY(out int x, out int y) => NativeSdl.InternalGetGlobalMouseState(out x, out y);

        /// <summary>
        ///     Gets the global mouse state using the specified x
        /// </summary>
        /// <param name="x">The </param>
        /// <param name="y">The </param>
        /// <returns>The uint</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint GetGlobalMouseStateXAndYOut([NotNull] IntPtr x, out int y) => NativeSdl.InternalGetGlobalMouseState(x, out y);

        /// <summary>
        ///     Gets the global mouse state using the specified x
        /// </summary>
        /// <param name="x">The </param>
        /// <param name="y">The </param>
        /// <returns>The uint</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint GetGlobalMouseStateOutXAndY(out int x, [NotNull] IntPtr y) => NativeSdl.InternalGetGlobalMouseState(out x, y);

        /// <summary>
        ///     Gets the global mouse state using the specified x
        /// </summary>
        /// <param name="x">The </param>
        /// <param name="y">The </param>
        /// <returns>The uint</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint GetGlobalMouseStateXAndY([NotNull] IntPtr x, [NotNull] IntPtr y) => NativeSdl.InternalGetGlobalMouseState(x, y);

        /// <summary>
        ///     Gets the relative mouse state using the specified x
        /// </summary>
        /// <param name="x">The </param>
        /// <param name="y">The </param>
        /// <returns>The uint</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint GetRelativeMouseState(out int x, out int y) => NativeSdl.InternalGetRelativeMouseState(out x, out y);

        /// <summary>
        ///     Warps the mouse in window using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="x">The </param>
        /// <param name="y">The </param>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void WarpMouseInWindow([NotNull] IntPtr window, [NotNull] int x, [NotNull] int y)
        {
            NativeSdl.InternalWarpMouseInWindow(window, x, y);
        }

        /// <summary>
        ///     Warps the mouse global using the specified x
        /// </summary>
        /// <param name="x">The </param>
        /// <param name="y">The </param>
        /// <returns>The int</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int WarpMouseGlobal([NotNull] int x, [NotNull] int y) => NativeSdl.InternalWarpMouseGlobal(x, y);

        /// <summary>
        ///     Sets the relative mouse mode using the specified enabled
        /// </summary>
        /// <param name="enabled">The enabled</param>
        /// <returns>The int</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int SetRelativeMouseMode(SdlBool enabled) => NativeSdl.InternalSetRelativeMouseMode(enabled);

        /// <summary>
        ///     Captures the mouse using the specified enabled
        /// </summary>
        /// <param name="enabled">The enabled</param>
        /// <returns>The int</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int CaptureMouse([NotNull] SdlBool enabled) => NativeSdl.InternalCaptureMouse(enabled);

        /// <summary>
        ///     Gets the relative mouse mode
        /// </summary>
        /// <returns>The sdl bool</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static SdlBool GetRelativeMouseMode() => NativeSdl.InternalGetRelativeMouseMode();

        /// <summary>
        ///     Creates the cursor using the specified data
        /// </summary>
        /// <param name="data">The data</param>
        /// <param name="mask">The mask</param>
        /// <param name="w">The </param>
        /// <param name="h">The </param>
        /// <param name="hotX">The hot</param>
        /// <param name="hotY">The hot</param>
        /// <returns>The int ptr</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IntPtr CreateCursor([NotNull] IntPtr data, [NotNull] IntPtr mask, [NotNull] int w, [NotNull] int h, [NotNull] int hotX, [NotNull] int hotY) => NativeSdl.InternalCreateCursor(data, mask, w, h, hotX, hotY);

        /// <summary>
        ///     Creates the color cursor using the specified surface
        /// </summary>
        /// <param name="surface">The surface</param>
        /// <param name="hotX">The hot</param>
        /// <param name="hotY">The hot</param>
        /// <returns>The int ptr</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IntPtr CreateColorCursor([NotNull] IntPtr surface, [NotNull] int hotX, [NotNull] int hotY) => NativeSdl.InternalCreateColorCursor(surface, hotX, hotY);

        /// <summary>
        ///     Creates the system cursor using the specified id
        /// </summary>
        /// <param name="id">The id</param>
        /// <returns>The int ptr</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IntPtr CreateSystemCursor(SdlSystemCursor id) => NativeSdl.InternalCreateSystemCursor(id);

        /// <summary>
        ///     Sets the cursor using the specified cursor
        /// </summary>
        /// <param name="cursor">The cursor</param>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetCursor([NotNull] IntPtr cursor)
        {
            NativeSdl.InternalSetCursor(cursor);
        }

        /// <summary>
        ///     Gets the cursor
        /// </summary>
        /// <returns>The int ptr</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IntPtr GetCursor() => NativeSdl.InternalGetCursor();

        /// <summary>
        ///     Frees the cursor using the specified cursor
        /// </summary>
        /// <param name="cursor">The cursor</param>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void FreeCursor([NotNull] IntPtr cursor)
        {
            NativeSdl.InternalFreeCursor(cursor);
        }

        /// <summary>
        ///     Shows the cursor using the specified toggle
        /// </summary>
        /// <param name="toggle">The toggle</param>
        /// <returns>The int</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int ShowCursor([NotNull] int toggle) => NativeSdl.InternalShowCursor(toggle);

        /// <summary>
        ///     Sdl the button using the specified x
        /// </summary>
        /// <param name="x">The </param>
        /// <returns>The uint</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint Button([NotNull] uint x) => (uint) (1 << ((int) x - 1));

        /// <summary>
        ///     Gets the num touch devices
        /// </summary>
        /// <returns>The int</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int GetNumTouchDevices() => NativeSdl.InternalGetNumTouchDevices();

        /// <summary>
        ///     Gets the touch device using the specified index
        /// </summary>
        /// <param name="index">The index</param>
        /// <returns>The long</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long GetTouchDevice([NotNull] int index) => NativeSdl.InternalGetTouchDevice(index);

        /// <summary>
        ///     Gets the num touch fingers using the specified touch id
        /// </summary>
        /// <param name="touchId">The touch id</param>
        /// <returns>The int</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int GetNumTouchFingers(long touchId) => NativeSdl.InternalGetNumTouchFingers(touchId);

        /// <summary>
        ///     Gets the touch finger using the specified touch id
        /// </summary>
        /// <param name="touchId">The touch id</param>
        /// <param name="index">The index</param>
        /// <returns>The int ptr</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IntPtr GetTouchFinger([NotNull] long touchId, [NotNull] int index) => NativeSdl.InternalGetTouchFinger(touchId, index);

        /// <summary>
        ///     Gets the touch device type using the specified touch id
        /// </summary>
        /// <param name="touchId">The touch id</param>
        /// <returns>The sdl touch device type</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static SdlTouchDeviceType GetTouchDeviceType([NotNull] long touchId) => NativeSdl.InternalGetTouchDeviceType(touchId);


        /// <summary>
        ///     Joysticks the rumble using the specified joystick
        /// </summary>
        /// <param name="joystick">The joystick</param>
        /// <param name="lowFrequencyRumble">The low frequency rumble</param>
        /// <param name="highFrequencyRumble">The high frequency rumble</param>
        /// <param name="durationMs">The duration ms</param>
        /// <returns>The int</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int JoystickRumble([NotNull] IntPtr joystick, [NotNull] ushort lowFrequencyRumble, [NotNull] ushort highFrequencyRumble, [NotNull] uint durationMs) => NativeSdl.InternalJoystickRumble(joystick, lowFrequencyRumble, highFrequencyRumble, durationMs);

        /// <summary>
        ///     Joysticks the rumble triggers using the specified joystick
        /// </summary>
        /// <param name="joystick">The joystick</param>
        /// <param name="leftRumble">The left rumble</param>
        /// <param name="rightRumble">The right rumble</param>
        /// <param name="durationMs">The duration ms</param>
        /// <returns>The int</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int JoystickRumbleTriggers([NotNull] IntPtr joystick, [NotNull] ushort leftRumble, [NotNull] ushort rightRumble, [NotNull] uint durationMs) => NativeSdl.InternalJoystickRumbleTriggers(joystick, leftRumble, rightRumble, durationMs);

        /// <summary>
        ///     Joysticks the close using the specified joystick
        /// </summary>
        /// <param name="joystick">The joystick</param>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void JoystickClose([NotNull] IntPtr joystick)
        {
            NativeSdl.InternalJoystickClose(joystick);
        }

        /// <summary>
        ///     Joysticks the event state using the specified state
        /// </summary>
        /// <param name="state">The state</param>
        /// <returns>The int</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int JoystickEventState([NotNull] int state) => NativeSdl.InternalJoystickEventState(state);

        /// <summary>
        ///     Joysticks the get axis using the specified joystick
        /// </summary>
        /// <param name="joystick">The joystick</param>
        /// <param name="axis">The axis</param>
        /// <returns>The short</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short JoystickGetAxis([NotNull] IntPtr joystick, [NotNull] int axis) => NativeSdl.InternalJoystickGetAxis(joystick, axis);

        /// <summary>
        ///     Joysticks the get axis initial state using the specified joystick
        /// </summary>
        /// <param name="joystick">The joystick</param>
        /// <param name="axis">The axis</param>
        /// <param name="state">The state</param>
        /// <returns>The sdl bool</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static SdlBool JoystickGetAxisInitialState([NotNull] IntPtr joystick, [NotNull] int axis, out ushort state) => NativeSdl.InternalJoystickGetAxisInitialState(joystick, axis, out state);

        /// <summary>
        ///     Joysticks the get ball using the specified joystick
        /// </summary>
        /// <param name="joystick">The joystick</param>
        /// <param name="ball">The ball</param>
        /// <param name="dx">The dx</param>
        /// <param name="dy">The dy</param>
        /// <returns>The int</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int JoystickGetBall([NotNull] IntPtr joystick, [NotNull] int ball, out int dx, out int dy) => NativeSdl.InternalJoystickGetBall(joystick, ball, out dx, out dy);

        /// <summary>
        ///     Joysticks the get button using the specified joystick
        /// </summary>
        /// <param name="joystick">The joystick</param>
        /// <param name="button">The button</param>
        /// <returns>The byte</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte JoystickGetButton([NotNull] IntPtr joystick, [NotNull] int button) => NativeSdl.InternalJoystickGetButton(joystick, button);

        /// <summary>
        ///     Joysticks the get hat using the specified joystick
        /// </summary>
        /// <param name="joystick">The joystick</param>
        /// <param name="hat">The hat</param>
        /// <returns>The byte</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte JoystickGetHat([NotNull] IntPtr joystick, [NotNull] int hat) => NativeSdl.InternalJoystickGetHat(joystick, hat);

        /// <summary>
        ///     Sdl the joystick name using the specified joystick
        /// </summary>
        /// <param name="joystick">The joystick</param>
        /// <returns>The string</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string JoystickName([NotNull] IntPtr joystick) => NativeSdl.InternalJoystickName(joystick);

        /// <summary>
        ///     Sdl the joystick name for index using the specified device index
        /// </summary>
        /// <param name="deviceIndex">The device index</param>
        /// <returns>The string</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string JoystickNameForIndex([NotNull] int deviceIndex) => NativeSdl.InternalJoystickNameForIndex(deviceIndex);

        /// <summary>
        ///     Joysticks the num axes using the specified joystick
        /// </summary>
        /// <param name="joystick">The joystick</param>
        /// <returns>The int</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int JoystickNumAxes([NotNull] IntPtr joystick) => NativeSdl.InternalJoystickNumAxes(joystick);

        /// <summary>
        ///     Joysticks the num balls using the specified joystick
        /// </summary>
        /// <param name="joystick">The joystick</param>
        /// <returns>The int</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int JoystickNumBalls([NotNull] IntPtr joystick) => NativeSdl.InternalJoystickNumBalls(joystick);

        /// <summary>
        ///     Joysticks the num buttons using the specified joystick
        /// </summary>
        /// <param name="joystick">The joystick</param>
        /// <returns>The int</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int JoystickNumButtons([NotNull] IntPtr joystick) => NativeSdl.InternalJoystickNumButtons(joystick);

        /// <summary>
        ///     Joysticks the num hats using the specified joystick
        /// </summary>
        /// <param name="joystick">The joystick</param>
        /// <returns>The int</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int JoystickNumHats([NotNull] IntPtr joystick) => NativeSdl.InternalJoystickNumHats(joystick);

        /// <summary>
        ///     Joysticks the open using the specified device index
        /// </summary>
        /// <param name="deviceIndex">The device index</param>
        /// <returns>The int ptr</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IntPtr JoystickOpen([NotNull] int deviceIndex) => NativeSdl.InternalJoystickOpen(deviceIndex);

        /// <summary>
        ///     Joysticks the update
        /// </summary>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void JoystickUpdate()
        {
            NativeSdl.InternalJoystickUpdate();
        }

        /// <summary>
        ///     Nums the joysticks
        /// </summary>
        /// <returns>The int</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int NumJoysticks()
        {
            int result = NativeSdl.InternalNumJoysticks();
            Validator.ValidateOutput(result);
            return result;
        }

        /// <summary>
        ///     Joysticks the get device guid using the specified device index
        /// </summary>
        /// <param name="deviceIndex">The device index</param>
        /// <returns>The guid</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Guid JoystickGetDeviceGuid([NotNull] int deviceIndex) => NativeSdl.InternalJoystickGetDeviceGUID(deviceIndex);

        /// <summary>
        ///     Joysticks the get guid using the specified joystick
        /// </summary>
        /// <param name="joystick">The joystick</param>
        /// <returns>The guid</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Guid JoystickGetGuid(IntPtr joystick) => NativeSdl.InternalJoystickGetGUID(joystick);

        /// <summary>
        ///     Joysticks the get guid string using the specified guid
        /// </summary>
        /// <param name="guid">The guid</param>
        /// <param name="pszGuid">The psz guid</param>
        /// <param name="cbGuid">The cb guid</param>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void JoystickGetGuidString(Guid guid, [NotNull] byte[] pszGuid, [NotNull] int cbGuid)
        {
            NativeSdl.InternalJoystickGetGUIDString(guid, pszGuid, cbGuid);
        }

        /// <summary>
        ///     Sdl the joystick get guid from string using the specified pch guid
        /// </summary>
        /// <param name="pchGuid">The pch guid</param>
        /// <returns>The guid</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Guid JoystickGetGuidFromString([NotNull] string pchGuid) => NativeSdl.InternalJoystickGetGUIDFromString(pchGuid);

        /// <summary>
        ///     Joysticks the get device vendor using the specified device index
        /// </summary>
        /// <param name="deviceIndex">The device index</param>
        /// <returns>The ushort</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort JoystickGetDeviceVendor([NotNull] int deviceIndex) => NativeSdl.InternalJoystickGetDeviceVendor(deviceIndex);

        /// <summary>
        ///     Joysticks the get device product using the specified device index
        /// </summary>
        /// <param name="deviceIndex">The device index</param>
        /// <returns>The ushort</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort JoystickGetDeviceProduct([NotNull] int deviceIndex) => NativeSdl.InternalJoystickGetDeviceProduct(deviceIndex);

        /// <summary>
        ///     Joysticks the get device product version using the specified device index
        /// </summary>
        /// <param name="deviceIndex">The device index</param>
        /// <returns>The ushort</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort JoystickGetDeviceProductVersion([NotNull] int deviceIndex) => NativeSdl.InternalJoystickGetDeviceProductVersion(deviceIndex);

        /// <summary>
        ///     Joysticks the get device type using the specified device index
        /// </summary>
        /// <param name="deviceIndex">The device index</param>
        /// <returns>The sdl joystick type</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static SdlJoystickType JoystickGetDeviceType([NotNull] int deviceIndex) => NativeSdl.InternalJoystickGetDeviceType(deviceIndex);

        /// <summary>
        ///     Joysticks the get device instance id using the specified device index
        /// </summary>
        /// <param name="deviceIndex">The device index</param>
        /// <returns>The int</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int JoystickGetDeviceInstanceId([NotNull] int deviceIndex) => NativeSdl.InternalJoystickGetDeviceInstanceID(deviceIndex);

        /// <summary>
        ///     Joysticks the get vendor using the specified joystick
        /// </summary>
        /// <param name="joystick">The joystick</param>
        /// <returns>The ushort</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort JoystickGetVendor([NotNull] IntPtr joystick) => NativeSdl.InternalJoystickGetVendor(joystick);

        /// <summary>
        ///     Joysticks the get product using the specified joystick
        /// </summary>
        /// <param name="joystick">The joystick</param>
        /// <returns>The ushort</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort JoystickGetProduct([NotNull] IntPtr joystick) => NativeSdl.InternalJoystickGetProduct(joystick);

        /// <summary>
        ///     Joysticks the get product version using the specified joystick
        /// </summary>
        /// <param name="joystick">The joystick</param>
        /// <returns>The ushort</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort JoystickGetProductVersion([NotNull] IntPtr joystick) => NativeSdl.InternalJoystickGetProductVersion(joystick);

        /// <summary>
        ///     Sdl the joystick get serial using the specified joystick
        /// </summary>
        /// <param name="joystick">The joystick</param>
        /// <returns>The string</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string JoystickGetSerial([NotNull] IntPtr joystick) => NativeSdl.InternalJoystickGetSerial(joystick);

        /// <summary>
        ///     Joysticks the get type using the specified joystick
        /// </summary>
        /// <param name="joystick">The joystick</param>
        /// <returns>The sdl joystick type</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static SdlJoystickType JoystickGetType([NotNull] IntPtr joystick) => NativeSdl.InternalJoystickGetType(joystick);

        /// <summary>
        ///     Joysticks the get attached using the specified joystick
        /// </summary>
        /// <param name="joystick">The joystick</param>
        /// <returns>The sdl bool</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static SdlBool JoystickGetAttached([NotNull] IntPtr joystick) => NativeSdl.InternalJoystickGetAttached(joystick);

        /// <summary>
        ///     Joysticks the instance id using the specified joystick
        /// </summary>
        /// <param name="joystick">The joystick</param>
        /// <returns>The int</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int JoystickInstanceId([NotNull] IntPtr joystick) => NativeSdl.InternalJoystickInstanceID(joystick);

        /// <summary>
        ///     Joysticks the current power level using the specified joystick
        /// </summary>
        /// <param name="joystick">The joystick</param>
        /// <returns>The sdl joystick power level</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static SdlJoystickPowerLevel JoystickCurrentPowerLevel([NotNull] IntPtr joystick) => NativeSdl.InternalJoystickCurrentPowerLevel(joystick);

        /// <summary>
        ///     Joysticks the from instance id using the specified instance id
        /// </summary>
        /// <param name="instanceId">The instance id</param>
        /// <returns>The int ptr</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IntPtr JoystickFromInstanceId([NotNull] int instanceId) => NativeSdl.InternalJoystickFromInstanceID(instanceId);

        /// <summary>
        ///     Locks the joysticks
        /// </summary>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void LockJoysticks()
        {
            NativeSdl.InternalLockJoysticks();
        }

        /// <summary>
        ///     Unlocks the joysticks
        /// </summary>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void UnlockJoysticks()
        {
            NativeSdl.InternalUnlockJoysticks();
        }

        /// <summary>
        ///     Joysticks the from player index using the specified player index
        /// </summary>
        /// <param name="playerIndex">The player index</param>
        /// <returns>The int ptr</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IntPtr JoystickFromPlayerIndex([NotNull] int playerIndex) => NativeSdl.InternalJoystickFromPlayerIndex(playerIndex);

        /// <summary>
        ///     Joysticks the set player index using the specified joystick
        /// </summary>
        /// <param name="joystick">The joystick</param>
        /// <param name="playerIndex">The player index</param>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void JoystickSetPlayerIndex([NotNull] IntPtr joystick, [NotNull] int playerIndex)
        {
            NativeSdl.InternalJoystickSetPlayerIndex(joystick, playerIndex);
        }

        /// <summary>
        ///     Sdl the joystick attach virtual using the specified type
        /// </summary>
        /// <param name="type">The type</param>
        /// <param name="nAxes">The axes</param>
        /// <param name="nButtons">The buttons</param>
        /// <param name="nHats">The hats</param>
        /// <returns>The int</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int SdlJoystickAttachVirtual([NotNull] int type, [NotNull] int nAxes, [NotNull] int nButtons, [NotNull] int nHats) => NativeSdl.InternalJoystickAttachVirtual(type, nAxes, nButtons, nHats);

        /// <summary>
        ///     Joysticks the detach virtual using the specified device index
        /// </summary>
        /// <param name="deviceIndex">The device index</param>
        /// <returns>The int</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int JoystickDetachVirtual([NotNull] int deviceIndex) => NativeSdl.InternalJoystickDetachVirtual(deviceIndex);

        /// <summary>
        ///     Joysticks the is virtual using the specified device index
        /// </summary>
        /// <param name="deviceIndex">The device index</param>
        /// <returns>The sdl bool</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static SdlBool JoystickIsVirtual([NotNull] int deviceIndex) => NativeSdl.InternalJoystickIsVirtual(deviceIndex);

        /// <summary>
        ///     Joysticks the set virtual axis using the specified joystick
        /// </summary>
        /// <param name="joystick">The joystick</param>
        /// <param name="axis">The axis</param>
        /// <param name="value">The value</param>
        /// <returns>The int</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int JoystickSetVirtualAxis([NotNull] IntPtr joystick, [NotNull] int axis, short value) => NativeSdl.InternalJoystickSetVirtualAxis(joystick, axis, value);

        /// <summary>
        ///     Joysticks the set virtual button using the specified joystick
        /// </summary>
        /// <param name="joystick">The joystick</param>
        /// <param name="button">The button</param>
        /// <param name="value">The value</param>
        /// <returns>The int</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int JoystickSetVirtualButton([NotNull] IntPtr joystick, [NotNull] int button, [NotNull] byte value) => NativeSdl.InternalJoystickSetVirtualButton(joystick, button, value);

        /// <summary>
        ///     Joysticks the set virtual hat using the specified joystick
        /// </summary>
        /// <param name="joystick">The joystick</param>
        /// <param name="hat">The hat</param>
        /// <param name="value">The value</param>
        /// <returns>The int</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int JoystickSetVirtualHat([NotNull] IntPtr joystick, [NotNull] int hat, [NotNull] byte value) => NativeSdl.InternalJoystickSetVirtualHat(joystick, hat, value);

        /// <summary>
        ///     Joysticks the has led using the specified joystick
        /// </summary>
        /// <param name="joystick">The joystick</param>
        /// <returns>The sdl bool</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static SdlBool JoystickHasLed([NotNull] IntPtr joystick) => NativeSdl.InternalJoystickHasLED(joystick);

        /// <summary>
        ///     Joysticks the has rumble using the specified joystick
        /// </summary>
        /// <param name="joystick">The joystick</param>
        /// <returns>The sdl bool</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static SdlBool JoystickHasRumble([NotNull] IntPtr joystick) => NativeSdl.InternalJoystickHasRumble(joystick);

        /// <summary>
        ///     Joysticks the has rumble triggers using the specified joystick
        /// </summary>
        /// <param name="joystick">The joystick</param>
        /// <returns>The sdl bool</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static SdlBool JoystickHasRumbleTriggers([NotNull] IntPtr joystick) => NativeSdl.InternalJoystickHasRumbleTriggers(joystick);


        /// <summary>
        ///     Joysticks the set led using the specified joystick
        /// </summary>
        /// <param name="joystick">The joystick</param>
        /// <param name="red">The red</param>
        /// <param name="green">The green</param>
        /// <param name="blue">The blue</param>
        /// <returns>The int</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int JoystickSetLed([NotNull] IntPtr joystick, [NotNull] byte red, [NotNull] byte green, [NotNull] byte blue) => NativeSdl.InternalJoystickSetLED(joystick, red, green, blue);

        /// <summary>
        ///     Joysticks the send effect using the specified joystick
        /// </summary>
        /// <param name="joystick">The joystick</param>
        /// <param name="data">The data</param>
        /// <param name="size">The size</param>
        /// <returns>The int</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int JoystickSendEffect([NotNull] IntPtr joystick, [NotNull] IntPtr data, [NotNull] int size) => NativeSdl.InternalJoystickSendEffect(joystick, data, size);

        /// <summary>
        ///     Sdl the game controller add mapping using the specified mapping string
        /// </summary>
        /// <param name="mappingString">The mapping string</param>
        /// <returns>The result</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int GameControllerAddMapping([NotNull] string mappingString) => NativeSdl.InternalGameControllerAddMapping(mappingString);

        /// <summary>
        ///     Games the controller num mappings
        /// </summary>
        /// <returns>The int</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int GameControllerNumMappings() => NativeSdl.InternalGameControllerNumMappings();

        /// <summary>
        ///     Sdl the game controller mapping for index using the specified mapping index
        /// </summary>
        /// <param name="mappingIndex">The mapping index</param>
        /// <returns>The string</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string GameControllerMappingForIndex([NotNull] int mappingIndex) => NativeSdl.InternalGameControllerMappingForIndex(mappingIndex);

        /// <summary>
        ///     Sdl the game controller add mappings from file using the specified file
        /// </summary>
        /// <param name="file">The file</param>
        /// <returns>The int</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int GameControllerAddMappingsFromFile([NotNull] string file) => NativeSdl.InternalGameControllerAddMappingsFromRW(RwFromFile(file, "rb"), 1);

        /// <summary>
        ///     Sdl the game controller mapping for guid using the specified guid
        /// </summary>
        /// <param name="guid">The guid</param>
        /// <returns>The string</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string GameControllerMappingForGuid(Guid guid) => NativeSdl.InternalGameControllerMappingForGUID(guid);

        /// <summary>
        ///     Sdl the game controller mapping using the specified game controller
        /// </summary>
        /// <param name="gameController">The game controller</param>
        /// <returns>The string</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string GameControllerMapping([NotNull] IntPtr gameController) => NativeSdl.InternalGameControllerMapping(gameController);

        /// <summary>
        ///     Is the game controller using the specified joystick index
        /// </summary>
        /// <param name="joystickIndex">The joystick index</param>
        /// <returns>The sdl bool</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static SdlBool IsGameController([NotNull] int joystickIndex) => NativeSdl.InternalIsGameController(joystickIndex);

        /// <summary>
        ///     Sdl the game controller name for index using the specified joystick index
        /// </summary>
        /// <param name="joystickIndex">The joystick index</param>
        /// <returns>The string</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string GameControllerNameForIndex([NotNull] int joystickIndex) => NativeSdl.InternalGameControllerNameForIndex(joystickIndex);

        /// <summary>
        ///     Sdl the game controller mapping for device index using the specified joystick index
        /// </summary>
        /// <param name="joystickIndex">The joystick index</param>
        /// <returns>The string</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string GameControllerMappingForDeviceIndex([NotNull] int joystickIndex) => NativeSdl.InternalGameControllerMappingForDeviceIndex(joystickIndex);

        /// <summary>
        ///     Games the controller open using the specified joystick index
        /// </summary>
        /// <param name="joystickIndex">The joystick index</param>
        /// <returns>The int ptr</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IntPtr GameControllerOpen([NotNull] int joystickIndex) => NativeSdl.InternalGameControllerOpen(joystickIndex);

        /// <summary>
        ///     Sdl the game controller name using the specified game controller
        /// </summary>
        /// <param name="gameController">The game controller</param>
        /// <returns>The string</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string GameControllerName([NotNull] IntPtr gameController) => NativeSdl.InternalGameControllerName(gameController);

        /// <summary>
        ///     Games the controller get vendor using the specified game controller
        /// </summary>
        /// <param name="gameController">The game controller</param>
        /// <returns>The ushort</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort GameControllerGetVendor([NotNull] IntPtr gameController) => NativeSdl.InternalGameControllerGetVendor(gameController);

        /// <summary>
        ///     Games the controller get product using the specified game controller
        /// </summary>
        /// <param name="gameController">The game controller</param>
        /// <returns>The ushort</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort GameControllerGetProduct([NotNull] IntPtr gameController) => NativeSdl.InternalGameControllerGetProduct(gameController);

        /// <summary>
        ///     Games the controller get product version using the specified game controller
        /// </summary>
        /// <param name="gameController">The game controller</param>
        /// <returns>The ushort</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort GameControllerGetProductVersion([NotNull] IntPtr gameController) => NativeSdl.InternalGameControllerGetProductVersion(gameController);


        /// <summary>
        ///     Sdl the game controller get serial using the specified game controller
        /// </summary>
        /// <param name="gameController">The game controller</param>
        /// <returns>The string</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string GameControllerGetSerial([NotNull] IntPtr gameController) => NativeSdl.InternalGameControllerGetSerial(gameController);

        /// <summary>
        ///     Games the controller get attached using the specified game controller
        /// </summary>
        /// <param name="gameController">The game controller</param>
        /// <returns>The sdl bool</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static SdlBool GameControllerGetAttached([NotNull] IntPtr gameController) => NativeSdl.InternalGameControllerGetAttached(gameController);

        /// <summary>
        ///     Games the controller get joystick using the specified game controller
        /// </summary>
        /// <param name="gameController">The game controller</param>
        /// <returns>The int ptr</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IntPtr GameControllerGetJoystick([NotNull] IntPtr gameController) => NativeSdl.InternalGameControllerGetJoystick(gameController);

        /// <summary>
        ///     Games the controller event state using the specified state
        /// </summary>
        /// <param name="state">The state</param>
        /// <returns>The int</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int GameControllerEventState([NotNull] int state) => NativeSdl.InternalGameControllerEventState(state);

        /// <summary>
        ///     Games the controller update
        /// </summary>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void GameControllerUpdate()
        {
            NativeSdl.InternalGameControllerUpdate();
        }

        /// <summary>
        ///     Sdl the game controller get axis from string using the specified pch string
        /// </summary>
        /// <param name="pchString">The pch string</param>
        /// <returns>The sdl game controller axis</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static SdlGameControllerAxis GameControllerGetAxisFromString([NotNull] string pchString) => NativeSdl.InternalGameControllerGetAxisFromString(pchString);

        /// <summary>
        ///     Sdl the game controller get string for axis using the specified axis
        /// </summary>
        /// <param name="axis">The axis</param>
        /// <returns>The string</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string GameControllerGetStringForAxis(SdlGameControllerAxis axis) => NativeSdl.InternalGameControllerGetStringForAxis(axis);

        /// <summary>
        ///     Sdl the game controller get bind for axis using the specified game controller
        /// </summary>
        /// <param name="gameController">The game controller</param>
        /// <param name="axis">The axis</param>
        /// <returns>The result</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static SdlGameControllerButtonBind GameControllerGetBindForAxis([NotNull] IntPtr gameController, SdlGameControllerAxis axis)
        {
            // This is guaranteed to never be null
            InternalSdlGameControllerButtonBind dumb = NativeSdl.InternalGameControllerGetBindForAxis(
                gameController,
                axis
            );
            SdlGameControllerButtonBind result = new SdlGameControllerButtonBind
            {
                bindType = (SdlGameControllerBindType) dumb.bindType
            };
            result.value.hat.hat = dumb.unionVal0;
            result.value.hat.hat_mask = dumb.unionVal1;
            return result;
        }

        /// <summary>
        ///     Games the controller get axis using the specified game controller
        /// </summary>
        /// <param name="gameController">The game controller</param>
        /// <param name="axis">The axis</param>
        /// <returns>The short</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short GameControllerGetAxis([NotNull] IntPtr gameController, SdlGameControllerAxis axis) => NativeSdl.InternalGameControllerGetAxis(gameController, axis);

        /// <summary>
        ///     Sdl the game controller get button from string using the specified pch string
        /// </summary>
        /// <param name="pchString">The pch string</param>
        /// <returns>The sdl game controller button</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static SdlGameControllerButton GameControllerGetButtonFromString([NotNull] string pchString) => NativeSdl.InternalGameControllerGetButtonFromString(pchString);

        /// <summary>
        ///     Sdl the game controller get string for button using the specified button
        /// </summary>
        /// <param name="button">The button</param>
        /// <returns>The string</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string GameControllerGetStringForButton(SdlGameControllerButton button) => NativeSdl.InternalGameControllerGetStringForButton(button);

        /// <summary>
        ///     Sdl the game controller get bind for button using the specified game controller
        /// </summary>
        /// <param name="gameController">The game controller</param>
        /// <param name="button">The button</param>
        /// <returns>The result</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static SdlGameControllerButtonBind GameControllerGetBindForButton(
            IntPtr gameController,
            SdlGameControllerButton button
        )
        {
            // This is guaranteed to never be null
            InternalSdlGameControllerButtonBind dumb = NativeSdl.InternalGameControllerGetBindForButton(
                gameController,
                button
            );
            SdlGameControllerButtonBind result = new SdlGameControllerButtonBind
            {
                bindType = (SdlGameControllerBindType) dumb.bindType
            };
            result.value.hat.hat = dumb.unionVal0;
            result.value.hat.hat_mask = dumb.unionVal1;
            return result;
        }

        /// <summary>
        ///     Games the controller get button using the specified game controller
        /// </summary>
        /// <param name="gameController">The game controller</param>
        /// <param name="button">The button</param>
        /// <returns>The byte</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte GameControllerGetButton([NotNull] IntPtr gameController, SdlGameControllerButton button) => NativeSdl.InternalGameControllerGetButton(gameController, button);

        /// <summary>
        ///     Games the controller rumble using the specified game controller
        /// </summary>
        /// <param name="gameController">The game controller</param>
        /// <param name="lowFrequencyRumble">The low frequency rumble</param>
        /// <param name="highFrequencyRumble">The high frequency rumble</param>
        /// <param name="durationMs">The duration ms</param>
        /// <returns>The int</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int GameControllerRumble([NotNull] IntPtr gameController, [NotNull] ushort lowFrequencyRumble, [NotNull] ushort highFrequencyRumble, [NotNull] uint durationMs) => NativeSdl.InternalGameControllerRumble(gameController, lowFrequencyRumble, highFrequencyRumble, durationMs);

        /// <summary>
        ///     Games the controller rumble triggers using the specified game controller
        /// </summary>
        /// <param name="gameController">The game controller</param>
        /// <param name="leftRumble">The left rumble</param>
        /// <param name="rightRumble">The right rumble</param>
        /// <param name="durationMs">The duration ms</param>
        /// <returns>The int</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int GameControllerRumbleTriggers([NotNull] IntPtr gameController, [NotNull] ushort leftRumble, [NotNull] ushort rightRumble, [NotNull] uint durationMs) => NativeSdl.InternalGameControllerRumbleTriggers(gameController, leftRumble, rightRumble, durationMs);

        /// <summary>
        ///     Games the controller close using the specified game controller
        /// </summary>
        /// <param name="gameController">The game controller</param>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void GameControllerClose([NotNull] IntPtr gameController)
        {
            NativeSdl.InternalGameControllerClose(gameController);
        }
        
        /// <summary>
        ///     Internals the sdl game controller from instance id using the specified joy id
        /// </summary>
        /// <param name="joyId">The joy id</param>
        /// <returns>The int ptr</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IntPtr GameControllerFromInstanceId([NotNull] int joyId) => NativeSdl.InternalGameControllerFromInstanceID(joyId);

        /// <summary>
        ///     Games the controller type for index using the specified joystick index
        /// </summary>
        /// <param name="joystickIndex">The joystick index</param>
        /// <returns>The sdl game controller type</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static SdlGameControllerType GameControllerTypeForIndex([NotNull] int joystickIndex) => NativeSdl.InternalGameControllerTypeForIndex(joystickIndex);

        /// <summary>
        ///     Games the controller get type using the specified game controller
        /// </summary>
        /// <param name="gameController">The game controller</param>
        /// <returns>The sdl game controller type</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static SdlGameControllerType GameControllerGetType([NotNull] IntPtr gameController) => NativeSdl.InternalGameControllerGetType(gameController);

        /// <summary>
        ///     Games the controller from player index using the specified player index
        /// </summary>
        /// <param name="playerIndex">The player index</param>
        /// <returns>The int ptr</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IntPtr GameControllerFromPlayerIndex([NotNull] int playerIndex) => NativeSdl.InternalGameControllerFromPlayerIndex(playerIndex);


        /// <summary>
        ///     Games the controller set player index using the specified game controller
        /// </summary>
        /// <param name="gameController">The game controller</param>
        /// <param name="playerIndex">The player index</param>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void GameControllerSetPlayerIndex([NotNull] IntPtr gameController, [NotNull] int playerIndex)
        {
            NativeSdl.InternalGameControllerSetPlayerIndex(gameController, playerIndex);
        }


        /// <summary>
        ///     Games the controller has led using the specified game controller
        /// </summary>
        /// <param name="gameController">The game controller</param>
        /// <returns>The sdl bool</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static SdlBool GameControllerHasLed([NotNull] IntPtr gameController) => NativeSdl.InternalGameControllerHasLED(gameController);


        /// <summary>
        ///     Games the controller has rumble using the specified game controller
        /// </summary>
        /// <param name="gameController">The game controller</param>
        /// <returns>The sdl bool</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static SdlBool GameControllerHasRumble([NotNull] IntPtr gameController) => NativeSdl.InternalGameControllerHasRumble(gameController);

        /// <summary>
        ///     Games the controller has rumble triggers using the specified game controller
        /// </summary>
        /// <param name="gameController">The game controller</param>
        /// <returns>The sdl bool</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static SdlBool GameControllerHasRumbleTriggers([NotNull] IntPtr gameController) => NativeSdl.InternalGameControllerHasRumbleTriggers(gameController);

        /// <summary>
        ///     Games the controller set led using the specified game controller
        /// </summary>
        /// <param name="gameController">The game controller</param>
        /// <param name="red">The red</param>
        /// <param name="green">The green</param>
        /// <param name="blue">The blue</param>
        /// <returns>The int</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int GameControllerSetLed([NotNull] IntPtr gameController, [NotNull] byte red, [NotNull] byte green, [NotNull] byte blue) => NativeSdl.InternalGameControllerSetLED(gameController, red, green, blue);


        /// <summary>
        ///     Games the controller has axis using the specified game controller
        /// </summary>
        /// <param name="gameController">The game controller</param>
        /// <param name="axis">The axis</param>
        /// <returns>The sdl bool</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static SdlBool GameControllerHasAxis([NotNull] IntPtr gameController, SdlGameControllerAxis axis) => NativeSdl.InternalGameControllerHasAxis(gameController, axis);

        /// <summary>
        ///     Games the controller has button using the specified game controller
        /// </summary>
        /// <param name="gameController">The game controller</param>
        /// <param name="button">The button</param>
        /// <returns>The sdl bool</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static SdlBool GameControllerHasButton([NotNull] IntPtr gameController, SdlGameControllerButton button) => NativeSdl.InternalGameControllerHasButton(gameController, button);

        /// <summary>
        ///     Games the controller get num touchpads using the specified game controller
        /// </summary>
        /// <param name="gameController">The game controller</param>
        /// <returns>The int</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int GameControllerGetNumTouchpads([NotNull] IntPtr gameController) => NativeSdl.InternalGameControllerGetNumTouchpads(gameController);

        /// <summary>
        ///     Games the controller get num touchpad fingers using the specified game controller
        /// </summary>
        /// <param name="gameController">The game controller</param>
        /// <param name="touchpad">The touchpad</param>
        /// <returns>The int</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int GameControllerGetNumTouchpadFingers([NotNull] IntPtr gameController, [NotNull] int touchpad) => NativeSdl.InternalGameControllerGetNumTouchpadFingers(gameController, touchpad);

        /// <summary>
        ///     Games the controller get touchpad finger using the specified game controller
        /// </summary>
        /// <param name="gameController">The game controller</param>
        /// <param name="touchpad">The touchpad</param>
        /// <param name="finger">The finger</param>
        /// <param name="state">The state</param>
        /// <param name="x">The </param>
        /// <param name="y">The </param>
        /// <param name="pressure">The pressure</param>
        /// <returns>The int</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int GameControllerGetTouchpadFinger([NotNull] IntPtr gameController, [NotNull] int touchpad, [NotNull] int finger, out byte state, out float x, out float y, out float pressure) => NativeSdl.InternalGameControllerGetTouchpadFinger(gameController, touchpad, finger, out state, out x, out y, out pressure);

        /// <summary>
        ///     Games the controller has sensor using the specified game controller
        /// </summary>
        /// <param name="gameController">The game controller</param>
        /// <param name="type">The type</param>
        /// <returns>The sdl bool</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static SdlBool GameControllerHasSensor([NotNull] IntPtr gameController, SdlSensorType type) => NativeSdl.InternalGameControllerHasSensor(gameController, type);

        /// <summary>
        ///     Games the controller set sensor enabled using the specified game controller
        /// </summary>
        /// <param name="gameController">The game controller</param>
        /// <param name="type">The type</param>
        /// <param name="enabled">The enabled</param>
        /// <returns>The int</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int GameControllerSetSensorEnabled([NotNull] IntPtr gameController, SdlSensorType type, SdlBool enabled) => NativeSdl.InternalGameControllerSetSensorEnabled(gameController, type, enabled);

        /// <summary>
        ///     Games the controller is sensor enabled using the specified game controller
        /// </summary>
        /// <param name="gameController">The game controller</param>
        /// <param name="type">The type</param>
        /// <returns>The sdl bool</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static SdlBool GameControllerIsSensorEnabled([NotNull] IntPtr gameController, SdlSensorType type) => NativeSdl.InternalGameControllerIsSensorEnabled(gameController, type);


        /// <summary>
        ///     Games the controller get sensor data using the specified game controller
        /// </summary>
        /// <param name="gameController">The game controller</param>
        /// <param name="type">The type</param>
        /// <param name="data">The data</param>
        /// <param name="numValues">The num values</param>
        /// <returns>The int</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int GameControllerGetSensorData([NotNull] IntPtr gameController, SdlSensorType type, [NotNull] IntPtr data, [NotNull] int numValues) => NativeSdl.InternalGameControllerGetSensorData(gameController, type, data, numValues);

        /// <summary>
        ///     Games the controller get sensor data rate using the specified game controller
        /// </summary>
        /// <param name="gameController">The game controller</param>
        /// <param name="type">The type</param>
        /// <returns>The float</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float GameControllerGetSensorDataRate([NotNull] IntPtr gameController, SdlSensorType type) => NativeSdl.InternalGameControllerGetSensorDataRate(gameController, type);


        /// <summary>
        ///     Games the controller send effect using the specified game controller
        /// </summary>
        /// <param name="gameController">The game controller</param>
        /// <param name="data">The data</param>
        /// <param name="size">The size</param>
        /// <returns>The int</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int GameControllerSendEffect([NotNull] IntPtr gameController, [NotNull] IntPtr data, [NotNull] int size) => NativeSdl.InternalGameControllerSendEffect(gameController, data, size);


        /// <summary>
        /// Joysticks the is haptic using the specified joystick
        /// </summary>
        /// <param name="joystick">The joystick</param>
        /// <returns>The int</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int JoystickIsHaptic([NotNull] IntPtr joystick) => NativeSdl.InternalJoystickIsHaptic(joystick);

        /// <summary>
        ///     Mouses the is haptic
        /// </summary>
        /// <returns>The int</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int MouseIsHaptic() => NativeSdl.InternalMouseIsHaptic();

        /// <summary>
        ///     Nums the haptics
        /// </summary>
        /// <returns>The int</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int NumHaptics() => NativeSdl.InternalNumHaptics();

        /// <summary>
        ///     Nums the sensors
        /// </summary>
        /// <returns>The int</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int NumSensors() => NativeSdl.InternalNumSensors();

        /// <summary>
        ///     Sdl the sensor get device name using the specified device index
        /// </summary>
        /// <param name="deviceIndex">The device index</param>
        /// <returns>The string</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string SensorGetDeviceName([NotNull] int deviceIndex) => NativeSdl.InternalSensorGetDeviceName(deviceIndex);

        /// <summary>
        ///     Sensors the get device type using the specified device index
        /// </summary>
        /// <param name="deviceIndex">The device index</param>
        /// <returns>The sdl sensor type</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static SdlSensorType SensorGetDeviceType([NotNull] int deviceIndex) => NativeSdl.InternalSensorGetDeviceType(deviceIndex);

        /// <summary>
        ///     Sensors the get device non portable type using the specified device index
        /// </summary>
        /// <param name="deviceIndex">The device index</param>
        /// <returns>The int</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int SensorGetDeviceNonPortableType([NotNull] int deviceIndex) => NativeSdl.InternalSensorGetDeviceNonPortableType(deviceIndex);

        /// <summary>
        ///     Sensors the get device instance id using the specified device index
        /// </summary>
        /// <param name="deviceIndex">The device index</param>
        /// <returns>The int</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int SensorGetDeviceInstanceId([NotNull] int deviceIndex) => NativeSdl.InternalSensorGetDeviceInstanceID(deviceIndex);

        /// <summary>
        ///     Sensors the open using the specified device index
        /// </summary>
        /// <param name="deviceIndex">The device index</param>
        /// <returns>The int ptr</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IntPtr SensorOpen([NotNull] int deviceIndex) => NativeSdl.InternalSensorOpen(deviceIndex);

        /// <summary>
        ///     Sensors the from instance id using the specified instance id
        /// </summary>
        /// <param name="instanceId">The instance id</param>
        /// <returns>The int ptr</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IntPtr SensorFromInstanceId([NotNull] int instanceId) => NativeSdl.InternalSensorFromInstanceID(instanceId);

        /// <summary>
        ///     Sdl the sensor get name using the specified sensor
        /// </summary>
        /// <param name="sensor">The sensor</param>
        /// <returns>The string</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string SensorGetName([NotNull] IntPtr sensor) => NativeSdl.InternalSensorGetName(sensor);

        /// <summary>
        ///     Sensors the get type using the specified sensor
        /// </summary>
        /// <param name="sensor">The sensor</param>
        /// <returns>The sdl sensor type</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static SdlSensorType SensorGetType([NotNull] IntPtr sensor) => NativeSdl.InternalSensorGetType(sensor);

        /// <summary>
        ///     Sensors the get non portable type using the specified sensor
        /// </summary>
        /// <param name="sensor">The sensor</param>
        /// <returns>The int</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int SensorGetNonPortableType([NotNull] IntPtr sensor) => NativeSdl.InternalSensorGetNonPortableType(sensor);

        /// <summary>
        ///     Sensors the get instance id using the specified sensor
        /// </summary>
        /// <param name="sensor">The sensor</param>
        /// <returns>The int</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int SensorGetInstanceId([NotNull] IntPtr sensor) => NativeSdl.InternalSensorGetInstanceID(sensor);

        /// <summary>
        ///     Sensors the get data using the specified sensor
        /// </summary>
        /// <param name="sensor">The sensor</param>
        /// <param name="data">The data</param>
        /// <param name="numValues">The num values</param>
        /// <returns>The int</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int SensorGetData([NotNull] IntPtr sensor, float[] data, [NotNull] int numValues) => NativeSdl.InternalSensorGetData(sensor, data, numValues);

        /// <summary>
        ///     Sensors the close using the specified sensor
        /// </summary>
        /// <param name="sensor">The sensor</param>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SensorClose([NotNull] IntPtr sensor)
        {
            NativeSdl.InternalSensorClose(sensor);
        }

        /// <summary>
        ///     Sensors the update
        /// </summary>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SensorUpdate()
        {
            NativeSdl.InternalSensorUpdate();
        }

        /// <summary>
        ///     Locks the sensors
        /// </summary>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void LockSensors()
        {
            NativeSdl.InternalLockSensors();
        }

        /// <summary>
        ///     Unlocks the sensors
        /// </summary>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void UnlockSensors()
        {
            NativeSdl.InternalUnlockSensors();
        }

        /// <summary>
        ///     Sdl the audio bit size using the specified x
        /// </summary>
        /// <param name="x">The </param>
        /// <returns>The ushort</returns>
        public static ushort SdlAudioBitSize([NotNull] ushort x) => (ushort) (x & AudioMaskBitSize);

        /// <summary>
        ///     Describes whether sdl audio is float
        /// </summary>
        /// <param name="x">The </param>
        /// <returns>The bool</returns>
        public static bool SdlAudioIsFloat([NotNull] ushort x) => (x & AudioMaskDatatype) != 0;

        /// <summary>
        ///     Describes whether sdl audio is big endian
        /// </summary>
        /// <param name="x">The </param>
        /// <returns>The bool</returns>
        public static bool SdlAudioIsBigEndian([NotNull] ushort x) => (x & AudioMaskEndian) != 0;

        /// <summary>
        ///     Describes whether sdl audio is signed
        /// </summary>
        /// <param name="x">The </param>
        /// <returns>The bool</returns>
        public static bool SdlAudioIsSigned([NotNull] ushort x) => (x & AudioMaskSigned) != 0;

        /// <summary>
        ///     Describes whether sdl audio is int
        /// </summary>
        /// <param name="x">The </param>
        /// <returns>The bool</returns>
        public static bool SdlAudioIsInt([NotNull] ushort x) => (x & AudioMaskDatatype) == 0;

        /// <summary>
        ///     Describes whether sdl audio is little endian
        /// </summary>
        /// <param name="x">The </param>
        /// <returns>The bool</returns>
        public static bool SdlAudioIsLittleEndian([NotNull] ushort x) => (x & AudioMaskEndian) == 0;

        /// <summary>
        ///     Describes whether sdl audio is unsigned
        /// </summary>
        /// <param name="x">The </param>
        /// <returns>The bool</returns>
        public static bool SdlAudioIsUnsigned([NotNull] ushort x) => (x & AudioMaskSigned) == 0;

        /// <summary>
        ///     Sdl the audio init using the specified driver name
        /// </summary>
        /// <param name="driverName">The driver name</param>
        /// <returns>The int</returns>
        public static int AudioInit([NotNull] string driverName) => NativeSdl.InternalAudioInit(driverName);

        /// <summary>
        ///     Audio the quit
        /// </summary>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void AudioQuit()
        {
            NativeSdl.InternalAudioQuit();
        }
        
        /// <summary>
        ///     Closes the audio device using the specified dev
        /// </summary>
        /// <param name="dev">The dev</param>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void CloseAudioDevice([NotNull] uint dev)
        {
            NativeSdl.InternalCloseAudioDevice(dev);
        }
        
        /// <summary>
        ///     Sdl the get audio device name using the specified index
        /// </summary>
        /// <param name="index">The index</param>
        /// <param name="isCapture">The is capture</param>
        /// <returns>The string</returns>
        public static string GetAudioDeviceName([NotNull] int index, [NotNull] int isCapture)
        {
            Validator.ValidateInput(index);
            Validator.ValidateInput(isCapture);
            var result = Marshal.PtrToStringAnsi(NativeSdl.InternalGetAudioDeviceName(index, isCapture));
            Validator.ValidateOutput(result);
            return result;
        }

        /// <summary>
        ///     Gets the audio device status using the specified dev
        /// </summary>
        /// <param name="dev">The dev</param>
        /// <returns>The sdl audio status</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static SdlAudioStatus GetAudioDeviceStatus([NotNull] uint dev) => NativeSdl.InternalGetAudioDeviceStatus(dev);

        /// <summary>
        ///     Sdl the get audio driver using the specified index
        /// </summary>
        /// <param name="index">The index</param>
        /// <returns>The string</returns>
        public static string GetAudioDriver([NotNull] int index)
        {
            Validator.ValidateInput(index);
            string result = Marshal.PtrToStringAnsi(NativeSdl.InternalGetAudioDriver(index));
            Validator.ValidateOutput(result);
            return result;
        }
        
        /// <summary>
        ///     Sdl the get current audio driver
        /// </summary>
        /// <returns>The string</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string GetCurrentAudioDriver()
        {
            string result = Marshal.PtrToStringAnsi(NativeSdl.InternalGetCurrentAudioDriver());
            Validator.ValidateOutput(result);
            return result;
        }

        /// <summary>
        ///     Gets the num audio devices using the specified is capture
        /// </summary>
        /// <param name="isCapture">The is capture</param>
        /// <returns>The int</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int GetNumAudioDevices([NotNull] int isCapture) => NativeSdl.InternalGetNumAudioDevices(isCapture);

        /// <summary>
        ///     Gets the num audio drivers
        /// </summary>
        /// <returns>The int</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int GetNumAudioDrivers() => NativeSdl.InternalGetNumAudioDrivers();

        /// <summary>
        ///     Sdl the load wav using the specified file
        /// </summary>
        /// <param name="file">The file</param>
        /// <param name="spec">The spec</param>
        /// <param name="audioBuf">The audio buf</param>
        /// <param name="audioLen">The audio len</param>
        /// <returns>The int ptr</returns>
        public static IntPtr LoadWav([NotNull] string file, out SdlAudioSpec spec, out IntPtr audioBuf, out uint audioLen) => NativeSdl.InternalLoadWAV_RW(RwFromFile(file, "rb"), 1, out spec, out audioBuf, out audioLen);
        
        /// <summary>
        ///     Locks the audio device using the specified dev
        /// </summary>
        /// <param name="dev">The dev</param>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void LockAudioDevice([NotNull] uint dev)
        {
            Validator.ValidateInput(dev);
            NativeSdl.InternalLockAudioDevice(dev);
        }

        /// <summary>
        ///     Mixes the audio using the specified dst
        /// </summary>
        /// <param name="dst">The dst</param>
        /// <param name="src">The src</param>
        /// <param name="len">The len</param>
        /// <param name="volume">The volume</param>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void MixAudio([Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U1, SizeParamIndex = 2)] [NotNull] byte[] dst, [In, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U1, SizeParamIndex = 2)] [NotNull] byte[] src, [NotNull] uint len, [NotNull] int volume)
        {
            Validator.ValidateInput(dst);
            Validator.ValidateInput(src);
            Validator.ValidateInput(len);
            Validator.ValidateInput(volume);
            NativeSdl.InternalMixAudio(dst, src, len, volume);
        }

        /// <summary>
        ///     Mixes the audio format using the specified dst
        /// </summary>
        /// <param name="dst">The dst</param>
        /// <param name="src">The src</param>
        /// <param name="format">The format</param>
        /// <param name="len">The len</param>
        /// <param name="volume">The volume</param>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void MixAudioFormat([NotNull] IntPtr dst, [NotNull] IntPtr src, [NotNull] ushort format, [NotNull] uint len, [NotNull] int volume)
        {
            Validator.ValidateInput(dst);
            Validator.ValidateInput(src);
            Validator.ValidateInput(format);
            Validator.ValidateInput(len);
            Validator.ValidateInput(volume);
            NativeSdl.InternalMixAudioFormat(dst, src, format, len, volume);
        }

        /// <summary>
        ///     Mixes the audio format using the specified dst
        /// </summary>
        /// <param name="dst">The dst</param>
        /// <param name="src">The src</param>
        /// <param name="format">The format</param>
        /// <param name="len">The len</param>
        /// <param name="volume">The volume</param>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void MixAudioFormat([Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U1, SizeParamIndex = 3)] [NotNull] byte[] dst, [In, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U1, SizeParamIndex = 3)] [NotNull] byte[] src, [NotNull] ushort format, [NotNull] uint len, [NotNull] int volume)
        {
            Validator.ValidateInput(dst);
            Validator.ValidateInput(src);
            Validator.ValidateInput(format);
            Validator.ValidateInput(len);
            Validator.ValidateInput(volume);
            NativeSdl.InternalMixAudioFormat(dst, src, format, len, volume);
        }

        /// <summary>
        ///     Sdl the open audio device using the specified device
        /// </summary>
        /// <param name="device">The device</param>
        /// <param name="isCapture">The is capture</param>
        /// <param name="desired">The desired</param>
        /// <param name="obtained">The obtained</param>
        /// <param name="allowedChanges">The allowed changes</param>
        /// <returns>The uint</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint SdlOpenAudioDevice([NotNull] IntPtr device, [NotNull] int isCapture, ref SdlAudioSpec desired, out SdlAudioSpec obtained, [NotNull] int allowedChanges)
        {
            Validator.ValidateInput(device);
            Validator.ValidateInput(isCapture);
            Validator.ValidateInput(desired);
            Validator.ValidateInput(allowedChanges);
            uint result = NativeSdl.InternalOpenAudioDevice(device, isCapture, ref desired, out obtained, allowedChanges);
            Validator.ValidateOutput(result);
            return result;
        }

        /// <summary>
        ///     Sdl the open audio device using the specified device
        /// </summary>
        /// <param name="device">The device</param>
        /// <param name="isCapture">The is capture</param>
        /// <param name="desired">The desired</param>
        /// <param name="obtained">The obtained</param>
        /// <param name="allowedChanges">The allowed changes</param>
        /// <returns>The uint</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint SdlOpenAudioDevice(string device, int isCapture, ref SdlAudioSpec desired, out SdlAudioSpec obtained, int allowedChanges)
        {
            Validator.ValidateInput(device);
            Validator.ValidateInput(isCapture);
            Validator.ValidateInput(desired);
            Validator.ValidateInput(allowedChanges);
            uint result = NativeSdl.InternalOpenAudioDevice(device, isCapture, ref desired, out obtained, allowedChanges);
            Validator.ValidateOutput(result);
            return result;
        }

        /// <summary>
        ///     Sdl the pause audio using the specified pause on
        /// </summary>
        /// <param name="pauseOn">The pause on</param>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SdlPauseAudio([NotNull] int pauseOn)
        {
            Validator.ValidateInput(pauseOn);
            NativeSdl.InternalPauseAudio(pauseOn);
        }

        /// <summary>
        ///     Sdl the pause audio device using the specified dev
        /// </summary>
        /// <param name="dev">The dev</param>
        /// <param name="pauseOn">The pause on</param>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SdlPauseAudioDevice([NotNull] uint dev, [NotNull] int pauseOn)
        {
            Validator.ValidateInput(dev);
            Validator.ValidateInput(pauseOn);
            NativeSdl.InternalPauseAudioDevice(dev, pauseOn);
        }
        
        /// <summary>
        ///     Sdl the unlock audio device using the specified dev
        /// </summary>
        /// <param name="dev">The dev</param>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SdlUnlockAudioDevice([NotNull] uint dev)
        {
            Validator.ValidateInput(dev);
            NativeSdl.InternalUnlockAudioDevice(dev);
        }

        /// <summary>
        ///     Sdl the new audio stream using the specified src format
        /// </summary>
        /// <param name="srcFormat">The src format</param>
        /// <param name="srcChannels">The src channels</param>
        /// <param name="srcRate">The src rate</param>
        /// <param name="dstFormat">The dst format</param>
        /// <param name="dstChannels">The dst channels</param>
        /// <param name="dstRate">The dst rate</param>
        /// <returns>The int ptr</returns>
        public static IntPtr SdlNewAudioStream([NotNull] ushort srcFormat, [NotNull] byte srcChannels, [NotNull] int srcRate, [NotNull] ushort dstFormat, [NotNull] byte dstChannels, [NotNull] int dstRate)
        {
            Validator.ValidateInput(srcFormat);
            Validator.ValidateInput(srcChannels);
            Validator.ValidateInput(srcRate);
            Validator.ValidateInput(dstFormat);
            Validator.ValidateInput(dstChannels);
            Validator.ValidateInput(dstRate);
            IntPtr result = NativeSdl.InternalNewAudioStream(srcFormat, srcChannels, srcRate, dstFormat, dstChannels, dstRate);
            Validator.ValidateOutput(result);
            return result;
        }

        /// <summary>
        ///     Sdl the audio stream put using the specified stream
        /// </summary>
        /// <param name="stream">The stream</param>
        /// <param name="buf">The buf</param>
        /// <param name="len">The len</param>
        /// <returns>The int</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int SdlAudioStreamPut([NotNull] IntPtr stream, [NotNull] IntPtr buf, [NotNull] int len)
        {
            Validator.ValidateInput(stream);
            Validator.ValidateInput(buf);
            Validator.ValidateInput(len);
            int result = NativeSdl.InternalAudioStreamPut(stream, buf, len);
            Validator.ValidateOutput(result);
            return result;
        }

        /// <summary>
        ///     Sdl the audio stream get using the specified stream
        /// </summary>
        /// <param name="stream">The stream</param>
        /// <param name="buf">The buf</param>
        /// <param name="len">The len</param>
        /// <returns>The int</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int SdlAudioStreamGet([NotNull] IntPtr stream, [NotNull] IntPtr buf, [NotNull] int len)
        {
            Validator.ValidateInput(stream);
            Validator.ValidateInput(buf);
            Validator.ValidateInput(len);
            int result = NativeSdl.InternalAudioStreamGet(stream, buf, len);
            Validator.ValidateOutput(result);
            return result;
        }

        /// <summary>
        ///     Sdl the audio stream available using the specified stream
        /// </summary>
        /// <param name="stream">The stream</param>
        /// <returns>The int</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int SdlAudioStreamAvailable([NotNull] IntPtr stream)
        {
            Validator.ValidateInput(stream);
            int result = NativeSdl.InternalAudioStreamAvailable(stream);
            Validator.ValidateOutput(result);
            return result;
        }

        /// <summary>
        ///     Sdl the audio stream clear using the specified stream
        /// </summary>
        /// <param name="stream">The stream</param>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SdlAudioStreamClear([NotNull] IntPtr stream)
        {
            Validator.ValidateInput(stream);
            NativeSdl.InternalAudioStreamClear(stream);
        }

        /// <summary>
        ///     Sdl the free audio stream using the specified stream
        /// </summary>
        /// <param name="stream">The stream</param>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SdlFreeAudioStream([NotEmpty] IntPtr stream)
        {
            Validator.ValidateInput(stream);
            NativeSdl.InternalFreeAudioStream(stream);
        }

        /// <summary>
        ///     Sdl the get audio device spec using the specified index
        /// </summary>
        /// <param name="index">The index</param>
        /// <param name="isCapture">The is capture</param>
        /// <param name="spec">The spec</param>
        /// <returns>The int</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int SdlGetAudioDeviceSpec([NotNull] int index, [NotNull] int isCapture, out SdlAudioSpec spec)
        {
            Validator.ValidateInput(index);
            Validator.ValidateInput(isCapture);
            int result = NativeSdl.InternalGetAudioDeviceSpec(index, isCapture, out spec);
            Validator.ValidateOutput(result);
            return result;
        }

        
        /// <summary>
        ///     Removes the timer using the specified id
        /// </summary>
        /// <param name="id">The id</param>
        /// <returns>The sdl bool</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static SdlBool RemoveTimer([NotNull] int id)
        {
            Validator.ValidateInput(id);
            SdlBool result = NativeSdl.InternalRemoveTimer(id);
            Validator.ValidateOutput(result);
            return result;
        }

        /// <summary>
        ///     Sets the windows message hook using the specified callback
        /// </summary>
        /// <param name="callback">The callback</param>
        /// <param name="userdata">The userdata</param>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetWindowsMessageHook([NotNull] SdlWindowsMessageHook callback, [NotNull] IntPtr userdata)
        {
            Validator.ValidateInput(callback);
            Validator.ValidateInput(userdata);
            NativeSdl.InternalSetWindowsMessageHook(callback, userdata);
        }

        /// <summary>
        ///     Renders the get d 3 d 9 device using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <returns>The int ptr</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IntPtr RenderGetD3D9Device([NotNull] IntPtr renderer)
        {
            Validator.ValidateInput(renderer);
            IntPtr result = NativeSdl.InternalRenderGetD3D9Device(renderer);
            Validator.ValidateOutput(result);
            return result;
        }

        /// <summary>
        ///     Renders the get d 3 d 11 device using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <returns>The int ptr</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IntPtr RenderGetD3D11Device([NotNull] IntPtr renderer)
        {
            Validator.ValidateInput(renderer);
            IntPtr result = NativeSdl.InternalRenderGetD3D11Device(renderer);
            Validator.ValidateOutput(result);
            return result;
        }

        /// <summary>
        ///     Sdl the win rt get device family
        /// </summary>
        /// <returns>The sdl win rt device family</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static SdlWinRtDeviceFamily SdlWinRtGetDeviceFamily()
        {
            SdlWinRtDeviceFamily result = NativeSdl.InternalWinRTGetDeviceFamily();
            Validator.ValidateOutput(result);
            return result;
        }

        /// <summary>
        ///     Sdl the get window wm info using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="info">The info</param>
        /// <returns>The sdl bool</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static SdlBool SdlGetWindowWmInfo([NotNull] IntPtr window, ref SdlSysWmInfo info)
        {
            Validator.ValidateInput(window);
            SdlBool result = NativeSdl.InternalGetWindowWMInfo(window, ref info);
            Validator.ValidateOutput(result);
            return result;
        }
        
        /// <summary>
        ///     Internals the sdl get performance frequency
        /// </summary>
        /// <returns>The ulong</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong GetPerformanceFrequency()
        {
            ulong result = NativeSdl.InternalGetPerformanceFrequency();
            Validator.ValidateOutput(result);
            return result;
        }
        
        /// <summary>
        ///     Gets the performance counter
        /// </summary>
        /// <returns>The ulong</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong GetPerformanceCounter()
        {
            ulong result = NativeSdl.InternalGetPerformanceCounter();
            Validator.ValidateOutput(result);
            return result;
        }
    }
}