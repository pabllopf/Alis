// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:Sdl.cs
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
using System.Reflection;
using Alis.Core.Aspect.Base.Dll;
using Alis.Core.Aspect.Base.Mapping;
using Alis.Core.Aspect.Math.Shape.Point;
using Alis.Core.Aspect.Math.Shape.Rectangle;
using Alis.Core.Aspect.Memory;
using Alis.Core.Aspect.Memory.Attributes;
using Alis.Core.Graphic.SDL.Delegates;
using Alis.Core.Graphic.SDL.Enums;
using Alis.Core.Graphic.SDL.Structs;
using Type = Alis.Core.Graphic.SDL.Enums.Type;

namespace Alis.Core.Graphic.SDL
{
    /// <summary>
    ///     The sdl class
    /// </summary>
    public static class Sdl
    {
        /// <summary>
        ///     The native lib name
        /// </summary>
        private const string NativeLibName = "sdl2";

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
        ///     The sdl init timer
        /// </summary>
        public const uint InitTimer = 0x00000001;

        /// <summary>
        ///     The sdl init audio
        /// </summary>
        public const uint InitAudio = 0x00000010;

        /// <summary>
        ///     The sdl init video
        /// </summary>
        public const uint InitVideo = 0x00000020;

        /// <summary>
        ///     The sdl init joystick
        /// </summary>
        private const uint InitJoystick = 0x00000200;

        /// <summary>
        ///     The sdl init haptic
        /// </summary>
        private const uint InitHaptic = 0x00001000;

        /// <summary>
        ///     The sdl init game controller
        /// </summary>
        public const uint InitGameController = 0x00002000;

        /// <summary>
        ///     The sdl init events
        /// </summary>
        private const uint InitEvents = 0x00004000;

        /// <summary>
        ///     The sdl init sensor
        /// </summary>
        private const uint InitSensor = 0x00008000;

        /// <summary>
        ///     The sdl init no parachute
        /// </summary>
        public const uint InitNoParachute = 0x00100000;

        /// <summary>
        ///     The sdl init sensor
        /// </summary>
        public const uint InitEverything = InitTimer | InitAudio | InitVideo | InitEvents | InitJoystick | InitHaptic | InitGameController | InitSensor;

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
        private const int WindowPosUndefinedMask = 0x1FFF0000;

        /// <summary>
        ///     The sdl window pos centered mask
        /// </summary>
        private const int WindowPosCenteredMask = 0x2FFF0000;

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
        private const uint RleAccel = 0x00000002;

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
        private const int Query = -1;

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
        private const uint ButtonX1 = 4;

        /// <summary>
        ///     The sdl button x2
        /// </summary>
        private const uint ButtonX2 = 5;

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
        private const byte HatUp = 0x01;

        /// <summary>
        ///     The sdl hat right
        /// </summary>
        private const byte HatRight = 0x02;

        /// <summary>
        ///     The sdl hat down
        /// </summary>
        private const byte HatDown = 0x04;

        /// <summary>
        ///     The sdl hat left
        /// </summary>
        private const byte HatLeft = 0x08;

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
        private const ushort AudioMaskBitSize = 0xFF;

        /// <summary>
        ///     The sdl audio mask datatype
        /// </summary>
        private const ushort AudioMaskDatatype = 1 << 8;

        /// <summary>
        ///     The sdl audio mask endian
        /// </summary>
        private const ushort AudioMaskEndian = 1 << 12;

        /// <summary>
        ///     The sdl audio mask signed
        /// </summary>
        private const ushort AudioMaskSigned = 1 << 15;

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
        private const ushort AudioU16Lsb = 0x0010;

        /// <summary>
        ///     The audio s16lsb
        /// </summary>
        private const ushort AudioS16Lsb = 0x8010;

        /// <summary>
        ///     The audio u16msb
        /// </summary>
        private const ushort AudioU16Msb = 0x1010;

        /// <summary>
        ///     The audio s16msb
        /// </summary>
        private const ushort AudioS16Msb = 0x9010;

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
        private const ushort AudioS32Lsb = 0x8020;

        /// <summary>
        ///     The audio s32msb
        /// </summary>
        private const ushort AudioS32Msb = 0x9020;

        /// <summary>
        ///     The audio s32lsb
        /// </summary>
        public const ushort AudioS32 = AudioS32Lsb;

        /// <summary>
        ///     The audio f32lsb
        /// </summary>
        private const ushort AudioF32Lsb = 0x8120;

        /// <summary>
        ///     The audio f32msb
        /// </summary>
        private const ushort AudioF32Msb = 0x9120;

        /// <summary>
        ///     The audio f32lsb
        /// </summary>
        public const ushort AudioF32 = AudioF32Lsb;

        /// <summary>
        ///     The sdl audio allow frequency change
        /// </summary>
        private const uint AudioAllowFrequencyChange = 0x00000001;

        /// <summary>
        ///     The sdl audio allow format change
        /// </summary>
        private const uint AudioAllowFormatChange = 0x00000002;

        /// <summary>
        ///     The sdl audio allow channels change
        /// </summary>
        private const uint AudioAllowChannelsChange = 0x00000004;

        /// <summary>
        ///     The sdl audio allow samples change
        /// </summary>
        private const uint AudioAllowSamplesChange = 0x00000008;

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
        private static readonly int CompiledVersion = VersionNum(MajorVersion, MinorVersion, PatchLevel);

        /// <summary>
        ///     The sdl pixel format unknown
        /// </summary>
        public static readonly uint PixelFormatUnknown = 0;

        /// <summary>
        ///     The sdl bit map order 4321
        /// </summary>
        public static readonly uint PixelFormatIndex1Lsb = SdlDefinePixelFormat(Type.TypeIndex1, (uint) BitmapOrder.BitMapOrder4321, 0, 1, 0);

        /// <summary>
        ///     The sdl bit map order 1234
        /// </summary>
        public static readonly uint PixelFormatIndex1Msb = SdlDefinePixelFormat(Type.TypeIndex1, (uint) BitmapOrder.BitMapOrder1234, 0, 1, 0);

        /// <summary>
        ///     The sdl bit map order 4321
        /// </summary>
        public static readonly uint PixelFormatIndex4Lsb = SdlDefinePixelFormat(Type.TypeIndex4, (uint) BitmapOrder.BitMapOrder4321, 0, 4, 0);

        /// <summary>
        ///     The sdl bit map order 1234
        /// </summary>
        public static readonly uint PixelFormatIndex4Msb = SdlDefinePixelFormat(Type.TypeIndex4, (uint) BitmapOrder.BitMapOrder1234, 0, 4, 0);

        /// <summary>
        ///     The sdl pixel type index8
        /// </summary>
        public static readonly uint PixelFormatIndex8 = SdlDefinePixelFormat(Type.TypeIndex8, 0, 0, 8, 1);

        /// <summary>
        ///     The sdl packed layout 332
        /// </summary>
        public static readonly uint PixelFormatRgb332 = SdlDefinePixelFormat(Type.TypePacked8, (uint) PackedOrder.PackedOrderXRgb, PackedLayout.PackedLayout332, 8, 1);

        /// <summary>
        ///     The sdl packed layout 4444
        /// </summary>
        private static readonly uint FormatXRgb444 = SdlDefinePixelFormat(Type.TypePacked16, (uint) PackedOrder.PackedOrderXRgb, PackedLayout.PackedLayout4444, 12, 2);

        /// <summary>
        ///     The sdl pixel format x rgb 444
        /// </summary>
        public static readonly uint PixelFormatRgb444 = FormatXRgb444;

        /// <summary>
        ///     The sdl packed layout 4444
        /// </summary>
        private static readonly uint FormatXBgr444 = SdlDefinePixelFormat(Type.TypePacked16, (uint) PackedOrder.PackedOrderXBgr, PackedLayout.PackedLayout4444, 12, 2);

        /// <summary>
        ///     The sdl pixel format x bgr 444
        /// </summary>
        public static readonly uint PixelFormatBgr444 = FormatXBgr444;

        /// <summary>
        ///     The sdl packed layout 1555
        /// </summary>
        private static readonly uint FormatXRgb1555 = SdlDefinePixelFormat(Type.TypePacked16, (uint) PackedOrder.PackedOrderXRgb, PackedLayout.PackedLayout1555, 15, 2);

        /// <summary>
        ///     The sdl pixel format xrgb1555
        /// </summary>
        public static readonly uint PixelFormatRgb555 = FormatXRgb1555;

        /// <summary>
        ///     The sdl packed layout 1555
        /// </summary>
        private static readonly uint FormatXBgr1555 = SdlDefinePixelFormat(Type.TypeIndex1, (uint) BitmapOrder.BitMapOrder4321, PackedLayout.PackedLayout1555, 15, 2);

        /// <summary>
        ///     The sdl pixel format xbgr1555
        /// </summary>
        public static readonly uint PixelFormatBgr555 = FormatXBgr1555;

        /// <summary>
        ///     The sdl packed layout 4444
        /// </summary>
        public static readonly uint PixelFormatArgb4444 = SdlDefinePixelFormat(Type.TypePacked16, (uint) PackedOrder.PackedOrderARgb, PackedLayout.PackedLayout4444, 16, 2);

        /// <summary>
        ///     The sdl packed layout 4444
        /// </summary>
        public static readonly uint PixelFormatRgba4444 = SdlDefinePixelFormat(Type.TypePacked16, (uint) PackedOrder.PackedOrderRGba, PackedLayout.PackedLayout4444, 16, 2);

        /// <summary>
        ///     The sdl packed layout 4444
        /// </summary>
        public static readonly uint PixelFormatABgr4444 = SdlDefinePixelFormat(Type.TypePacked16, (uint) PackedOrder.PackedOrderABgr, PackedLayout.PackedLayout4444, 16, 2);

        /// <summary>
        ///     The sdl packed layout 4444
        /// </summary>
        public static readonly uint PixelFormatBGra4444 = SdlDefinePixelFormat(Type.TypePacked16, (uint) PackedOrder.PackedOrderBGra, PackedLayout.PackedLayout4444, 16, 2);

        /// <summary>
        ///     The sdl packed layout 1555
        /// </summary>
        public static readonly uint PixelFormatArgb1555 = SdlDefinePixelFormat(Type.TypePacked16, (uint) PackedOrder.PackedOrderARgb, PackedLayout.PackedLayout1555, 16, 2);

        /// <summary>
        ///     The sdl packed layout 5551
        /// </summary>
        public static readonly uint PixelFormatRgba5551 = SdlDefinePixelFormat(Type.TypePacked16, (uint) PackedOrder.PackedOrderRGba, PackedLayout.PackedLayout5551, 16, 2);

        /// <summary>
        ///     The sdl packed layout 1555
        /// </summary>
        public static readonly uint PixelFormatABgr1555 = SdlDefinePixelFormat(Type.TypePacked16, (uint) PackedOrder.PackedOrderABgr, PackedLayout.PackedLayout1555, 16, 2);

        /// <summary>
        ///     The sdl packed layout 5551
        /// </summary>
        public static readonly uint PixelFormatBGra5551 = SdlDefinePixelFormat(Type.TypePacked16, (uint) PackedOrder.PackedOrderBGra, PackedLayout.PackedLayout5551, 16, 2);

        /// <summary>
        ///     The sdl packed layout 565
        /// </summary>
        public static readonly uint PixelFormatRgb565 = SdlDefinePixelFormat(Type.TypePacked16, (uint) PackedOrder.PackedOrderXRgb, PackedLayout.PackedLayout565, 16, 2);

        /// <summary>
        ///     The sdl packed layout 565
        /// </summary>
        public static readonly uint PixelFormatBgr565 = SdlDefinePixelFormat(Type.TypePacked16, (uint) PackedOrder.PackedOrderXBgr, PackedLayout.PackedLayout565, 16, 2);

        /// <summary>
        ///     The sdl array order rgb
        /// </summary>
        public static readonly uint PixelFormatRgb24 = SdlDefinePixelFormat(Type.TypeArrayU8, (uint) SdlArrayOrder.SdlArrayorderRgb, 0, 24, 3);

        /// <summary>
        ///     The sdl array order bgr
        /// </summary>
        public static readonly uint PixelFormatBgr24 = SdlDefinePixelFormat(Type.TypeArrayU8, (uint) SdlArrayOrder.SdlArrayorderBgr, 0, 24, 3);

        /// <summary>
        ///     The sdl packed layout 8888
        /// </summary>
        private static readonly uint FormatXRgb888 = SdlDefinePixelFormat(Type.TypePacked32, (uint) PackedOrder.PackedOrderXRgb, PackedLayout.PackedLayout8888, 24, 4);

        /// <summary>
        ///     The sdl pixel format x rgb 888
        /// </summary>
        public static readonly uint PixelFormatRgb888 = FormatXRgb888;

        /// <summary>
        ///     The sdl packed layout 8888
        /// </summary>
        public static readonly uint PixelFormatRgbX8888 = SdlDefinePixelFormat(Type.TypePacked32, (uint) PackedOrder.PackedOrderRGbx, PackedLayout.PackedLayout8888, 24, 4);

        /// <summary>
        ///     The sdl packed layout 8888
        /// </summary>
        private static readonly uint FormatXBgr888 = SdlDefinePixelFormat(Type.TypePacked32, (uint) PackedOrder.PackedOrderXBgr, PackedLayout.PackedLayout8888, 24, 4);

        /// <summary>
        ///     The sdl pixel format x bgr 888
        /// </summary>
        public static readonly uint PixelFormatBgr888 = FormatXBgr888;

        /// <summary>
        ///     The sdl packed layout 8888
        /// </summary>
        public static readonly uint PixelFormatBGrx8888 = SdlDefinePixelFormat(Type.TypePacked32, (uint) PackedOrder.PackedOrderBGrx, PackedLayout.PackedLayout8888, 24, 4);

        /// <summary>
        ///     The sdl packed layout 8888
        /// </summary>
        public static readonly uint PixelFormatArgb8888 = SdlDefinePixelFormat(Type.TypePacked32, (uint) PackedOrder.PackedOrderARgb, PackedLayout.PackedLayout8888, 32, 4);

        /// <summary>
        ///     The sdl packed layout 8888
        /// </summary>
        public static readonly uint PixelFormatRgba8888 = SdlDefinePixelFormat(Type.TypePacked32, (uint) PackedOrder.PackedOrderRGba, PackedLayout.PackedLayout8888, 32, 4);

        /// <summary>
        ///     The sdl packed layout 8888
        /// </summary>
        public static readonly uint PixelFormatABgr8888 = SdlDefinePixelFormat(Type.TypePacked32, (uint) PackedOrder.PackedOrderABgr, PackedLayout.PackedLayout8888, 32, 4);

        /// <summary>
        ///     The sdl packed layout 8888
        /// </summary>
        public static readonly uint PixelFormatB8888 = SdlDefinePixelFormat(Type.TypePacked32, (uint) PackedOrder.PackedOrderBGra, PackedLayout.PackedLayout8888, 32, 4);

        /// <summary>
        ///     The sdl packed layout 2101010
        /// </summary>
        public static readonly uint PixelFormatArgb2101010 = SdlDefinePixelFormat(Type.TypePacked32, (uint) PackedOrder.PackedOrderARgb, PackedLayout.PackedLayout2101010, 32, 4);

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
        private static readonly uint FormatYuy2 = SdlDefinePixelFourcc((byte) 'Y', (byte) 'U', (byte) 'Y', (byte) '2');

        /// <summary>
        ///     The sdl define pixel four
        /// </summary>
        private static readonly uint FormatUy = SdlDefinePixelFourcc((byte) 'U', (byte) 'Y', (byte) 'V', (byte) 'Y');

        /// <summary>
        ///     The sdl define pixel four
        /// </summary>
        private static readonly uint FormatYv = SdlDefinePixelFourcc((byte) 'Y', (byte) 'V', (byte) 'Y', (byte) 'U');

        /// <summary>
        ///     The sdl button left
        /// </summary>
        public static readonly uint ButtonLMask = Button(ButtonLeft);

        /// <summary>
        ///     The sdl button middle
        /// </summary>
        public static readonly uint ButtonMMask = Button(ButtonMiddle);

        /// <summary>
        ///     The sdl button right
        /// </summary>
        public static readonly uint ButtonRMask = Button(ButtonRight);

        /// <summary>
        ///     The sdl button x1
        /// </summary>
        public static readonly uint ButtonX1Mask = Button(ButtonX1);

        /// <summary>
        ///     The sdl button x2
        /// </summary>
        public static readonly uint ButtonX2Mask = Button(ButtonX2);

        /// <summary>
        ///     The audio u16msb
        /// </summary>
        public static readonly ushort AudioU16Sys = BitConverter.IsLittleEndian ? AudioU16Lsb : AudioU16Msb;

        /// <summary>
        ///     The audio s16msb
        /// </summary>
        public static readonly ushort AudioS16Sys = BitConverter.IsLittleEndian ? AudioS16Lsb : AudioS16Msb;

        /// <summary>
        ///     The audio s32msb
        /// </summary>
        public static readonly ushort AudioS32Sys = BitConverter.IsLittleEndian ? AudioS32Lsb : AudioS32Msb;

        /// <summary>
        ///     The audio f32msb
        /// </summary>
        public static readonly ushort AudioF32Sys = BitConverter.IsLittleEndian ? AudioF32Lsb : AudioF32Msb;

        /// <summary>
        ///     Initializes a new instance of the <see cref="Sdl" /> class
        /// </summary>
        static Sdl() => EmbeddedDllClass.ExtractEmbeddedDlls("sdl2", SdlDlls.SdlDllBytes, Assembly.GetExecutingAssembly());

        /// <summary>
        ///     Sdl the fourcc using the specified a
        /// </summary>
        /// <param name="a">The </param>
        /// <param name="b">The </param>
        /// <param name="c">The </param>
        /// <param name="d">The </param>
        /// <returns>The uint</returns>
        [return: NotNull]
        private static uint Fourcc(byte a, byte b, byte c, byte d) => (uint) (a | (b << 8) | (c << 16) | (d << 24));

        /// <summary>
        ///     Sdl the malloc using the specified size
        /// </summary>
        /// <param name="size">The size</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_malloc", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern IntPtr INTERNAL_SDL_malloc(int size);

        /// <summary>
        ///     Malloc the size
        /// </summary>
        /// <param name="size">The size</param>
        /// <returns>The int ptr</returns>
        [return: NotNull]
        public static IntPtr Malloc([NotNull, NotZero] int size) => INTERNAL_SDL_malloc(size.Validate());

        /// <summary>
        ///     Sdl the free using the specified mem block
        /// </summary>
        /// <param name="memBlock">The mem block</param>
        [DllImport(NativeLibName, EntryPoint = "SDL_free", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern void INTERNAL_SDL_free([NotNull] IntPtr memBlock);

        /// <summary>
        ///     Frees the mem block
        /// </summary>
        /// <param name="memBlock">The mem block</param>
        [return: NotNull]
        public static void Free([NotNull] IntPtr memBlock) => INTERNAL_SDL_free(memBlock.Validate());

        /// <summary>
        ///     Sdl the mem cpy using the specified dst
        /// </summary>
        /// <param name="dst">The dst</param>
        /// <param name="src">The src</param>
        /// <param name="len">The len</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_memCpy", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern IntPtr INTERNAL_SDL_memCpy([NotNull] IntPtr dst, [NotNull] IntPtr src, [NotNull] IntPtr len);

        /// <summary>
        ///     Mem the cpy using the specified dst
        /// </summary>
        /// <param name="dst">The dst</param>
        /// <param name="src">The src</param>
        /// <param name="len">The len</param>
        /// <returns>The int ptr</returns>
        [return: NotNull]
        public static IntPtr MemCpy([NotNull] IntPtr dst, [NotNull] IntPtr src, [NotNull] IntPtr len) => INTERNAL_SDL_memCpy(dst.Validate(), src.Validate(), len.Validate());

        /// <summary>
        ///     Internals the sdl rw from file using the specified file
        /// </summary>
        /// <param name="file">The file</param>
        /// <param name="mode">The mode</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_RWFromFile", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern IntPtr INTERNAL_SDL_RWFromFile([NotNull] byte[] file, [NotNull] byte[] mode);

        /// <summary>
        ///     Sdl the rw from file using the specified file
        /// </summary>
        /// <param name="file">The file</param>
        /// <param name="mode">The mode</param>
        /// <returns>The rw ops</returns>
        [return: NotNull]
        private static IntPtr RwFromFile([NotNull] string file, [NotNull] string mode) => INTERNAL_SDL_RWFromFile(Utf8Manager.Utf8EncodeHeap(file), Utf8Manager.Utf8EncodeHeap(mode));

        /// <summary>
        ///     Sdl the alloc rw
        /// </summary>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_AllocRW", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern IntPtr INTERNAL_SDL_AllocRW();

        /// <summary>
        ///     Internal the sdl alloc rw
        /// </summary>
        /// <returns>The int ptr</returns>
        [return: NotNull]
        public static IntPtr AllocRw() => INTERNAL_SDL_AllocRW();

        /// <summary>
        ///     Sdl the free rw using the specified area
        /// </summary>
        /// <param name="area">The area</param>
        [DllImport(NativeLibName, EntryPoint = "SDL_FreeRW", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern void INTERNAL_SDL_FreeRW([NotNull] IntPtr area);

        /// <summary>
        ///     Free the rw using the specified area
        /// </summary>
        /// <param name="area">The area</param>
        public static void FreeRw([NotNull] IntPtr area) => INTERNAL_SDL_FreeRW(area.Validate());

        /// <summary>
        ///     Sdl the rw from fp using the specified fp
        /// </summary>
        /// <param name="fp">The fp</param>
        /// <param name="autoClose">The auto close</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_RWFromFP", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern IntPtr INTERNAL_SDL_RWFromFP([NotNull] IntPtr fp, [NotNull] SdlBool autoClose);

        /// <summary>
        ///     Rws the from fp using the specified fp
        /// </summary>
        /// <param name="fp">The fp</param>
        /// <param name="autoClose">The auto close</param>
        /// <returns>The int ptr</returns>
        public static IntPtr RwFromFp([NotNull] IntPtr fp, [NotNull] SdlBool autoClose) => INTERNAL_SDL_RWFromFP(fp.Validate(), autoClose.Validate());

        /// <summary>
        ///     Sdl the rw from mem using the specified mem
        /// </summary>
        /// <param name="mem">The mem</param>
        /// <param name="size">The size</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_RWFromMem", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern IntPtr INTERNAL_SDL_RWFromMem([NotNull] IntPtr mem, [NotNull] int size);

        /// <summary>
        ///     Rws the from mem using the specified mem
        /// </summary>
        /// <param name="mem">The mem</param>
        /// <param name="size">The size</param>
        /// <returns>The int ptr</returns>
        [return: NotNull]
        public static IntPtr RwFromMem([NotNull] IntPtr mem, [NotNull] int size) => INTERNAL_SDL_RWFromMem(mem.Validate(), size.Validate());

        /// <summary>
        ///     Sdl the rw from const mem using the specified mem
        /// </summary>
        /// <param name="mem">The mem</param>
        /// <param name="size">The size</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_RWFromConstMem", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern IntPtr INTERNAL_SDL_RWFromConstMem(IntPtr mem, [NotNull] int size);

        /// <summary>
        ///     Rws the from const mem using the specified mem
        /// </summary>
        /// <param name="mem">The mem</param>
        /// <param name="size">The size</param>
        /// <returns>The int ptr</returns>
        [return: NotNull]
        public static IntPtr RwFromConstMem([NotNull] IntPtr mem, [NotNull] int size) => INTERNAL_SDL_RWFromConstMem(mem.Validate(), size.Validate());

        /// <summary>
        ///     Sdl the r w size using the specified context
        /// </summary>
        /// <param name="context">The context</param>
        /// <returns>The long</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_RwSize", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern long INTERNAL_SDL_RwSize([NotNull] IntPtr context);

        /// <summary>
        ///     Rws the size using the specified context
        /// </summary>
        /// <param name="context">The context</param>
        /// <returns>The long</returns>
        [return: NotNull]
        public static long RwSize([NotNull] IntPtr context) => INTERNAL_SDL_RwSize(context.Validate());

        /// <summary>
        ///     Sdl the r w seek using the specified context
        /// </summary>
        /// <param name="context">The context</param>
        /// <param name="offset">The offset</param>
        /// <param name="whence">The whence</param>
        /// <returns>The long</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_RwSeek", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern long INTERNAL_SDL_RwSeek([NotNull] IntPtr context, [NotNull] long offset, [NotNull] int whence);

        /// <summary>
        ///     Rws the seek using the specified context
        /// </summary>
        /// <param name="context">The context</param>
        /// <param name="offset">The offset</param>
        /// <param name="whence">The whence</param>
        /// <returns>The long</returns>
        [return: NotNull]
        public static long RwSeek([NotNull] IntPtr context, [NotNull] long offset, [NotNull] int whence) => INTERNAL_SDL_RwSeek(context.Validate(), offset.Validate(), whence.Validate());

        /// <summary>
        ///     Sdl the r w tell using the specified context
        /// </summary>
        /// <param name="context">The context</param>
        /// <returns>The long</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_RwTell", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern long INTERNAL_SDL_RwTell(IntPtr context);

        /// <summary>
        ///     Rws the tell using the specified context
        /// </summary>
        /// <param name="context">The context</param>
        /// <returns>The long</returns>
        [return: NotNull]
        public static long RwTell([NotNull] IntPtr context) => INTERNAL_SDL_RwTell(context.Validate());

        /// <summary>
        ///     Sdl the r w read using the specified context
        /// </summary>
        /// <param name="context">The context</param>
        /// <param name="ptr">The ptr</param>
        /// <param name="size">The size</param>
        /// <param name="maxNum">The max num</param>
        /// <returns>The long</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_RwRead", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern long INTERNAL_SDL_RwRead([NotNull] IntPtr context, [NotNull] IntPtr ptr, [NotNull] IntPtr size, [NotNull] IntPtr maxNum);

        /// <summary>
        ///     Rws the read using the specified context
        /// </summary>
        /// <param name="context">The context</param>
        /// <param name="ptr">The ptr</param>
        /// <param name="size">The size</param>
        /// <param name="maxNum">The max num</param>
        /// <returns>The long</returns>
        [return: NotNull]
        public static long RwRead([NotNull] IntPtr context, [NotNull] IntPtr ptr, [NotNull] IntPtr size, [NotNull] IntPtr maxNum) => INTERNAL_SDL_RwRead(context.Validate(), ptr.Validate(), size.Validate(), maxNum.Validate());

        /// <summary>
        ///     Sdl the r w write using the specified context
        /// </summary>
        /// <param name="context">The context</param>
        /// <param name="ptr">The ptr</param>
        /// <param name="size">The size</param>
        /// <param name="maxNum">The max num</param>
        /// <returns>The long</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_RwWrite", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern long INTERNAL_SDL_RwWrite([NotNull] IntPtr context, [NotNull] IntPtr ptr, [NotNull] IntPtr size, [NotNull] IntPtr maxNum);

        /// <summary>
        ///     Rws the write using the specified context
        /// </summary>
        /// <param name="context">The context</param>
        /// <param name="ptr">The ptr</param>
        /// <param name="size">The size</param>
        /// <param name="maxNum">The max num</param>
        /// <returns>The long</returns>
        [return: NotNull]
        public static long RwWrite([NotNull] IntPtr context, [NotNull] IntPtr ptr, [NotNull] IntPtr size, [NotNull] IntPtr maxNum) => INTERNAL_SDL_RwWrite(context.Validate(), ptr.Validate(), size.Validate(), maxNum.Validate());

        /// <summary>
        ///     Sdl the read u 8 using the specified src
        /// </summary>
        /// <param name="src">The src</param>
        /// <returns>The byte</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_ReadU8", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern byte INTERNAL_SDL_ReadU8([NotNull] IntPtr src);

        /// <summary>
        ///     Reads the u 8 using the specified src
        /// </summary>
        /// <param name="src">The src</param>
        /// <returns>The byte</returns>
        [return: NotNull]
        public static byte ReadU8([NotNull] IntPtr src) => INTERNAL_SDL_ReadU8(src.Validate());

        /// <summary>
        ///     Sdl the read le 16 using the specified src
        /// </summary>
        /// <param name="src">The src</param>
        /// <returns>The int 16</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_ReadLE16", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern ushort INTERNAL_SDL_ReadLE16([NotNull] IntPtr src);

        /// <summary>
        ///     Reads the le 16 using the specified src
        /// </summary>
        /// <param name="src">The src</param>
        /// <returns>The ushort</returns>
        [return: NotNull]
        public static ushort ReadLe16([NotNull] IntPtr src) => INTERNAL_SDL_ReadLE16(src.Validate());

        /// <summary>
        ///     Sdl the read be 16 using the specified src
        /// </summary>
        /// <param name="src">The src</param>
        /// <returns>The int 16</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_ReadBE16", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern ushort INTERNAL_SDL_ReadBE16([NotNull] IntPtr src);

        /// <summary>
        ///     Reads the be 16 using the specified src
        /// </summary>
        /// <param name="src">The src</param>
        /// <returns>The ushort</returns>
        [return: NotNull]
        public static ushort ReadBe16([NotNull] IntPtr src) => INTERNAL_SDL_ReadBE16(src.Validate());

        /// <summary>
        ///     Sdl the read le 32 using the specified src
        /// </summary>
        /// <param name="src">The src</param>
        /// <returns>The int 32</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_ReadLE32", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern uint INTERNAL_SDL_ReadLE32([NotNull] IntPtr src);

        /// <summary>
        ///     Reads the le 32 using the specified src
        /// </summary>
        /// <param name="src">The src</param>
        /// <returns>The uint</returns>
        [return: NotNull]
        public static uint ReadLe32([NotNull] IntPtr src) => INTERNAL_SDL_ReadLE32(src.Validate());

        /// <summary>
        ///     Sdl the read be 32 using the specified src
        /// </summary>
        /// <param name="src">The src</param>
        /// <returns>The int 32</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_ReadBE32", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern uint INTERNAL_SDL_ReadBE32([NotNull] IntPtr src);

        /// <summary>
        ///     Reads the be 32 using the specified src
        /// </summary>
        /// <param name="src">The src</param>
        /// <returns>The uint</returns>
        [return: NotNull]
        public static uint ReadBe32([NotNull] IntPtr src) => INTERNAL_SDL_ReadBE32(src.Validate());

        /// <summary>
        ///     Sdl the read le 64 using the specified src
        /// </summary>
        /// <param name="src">The src</param>
        /// <returns>The int 64</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_ReadLE64", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern ulong INTERNAL_SDL_ReadLE64([NotNull] IntPtr src);

        /// <summary>
        ///     Reads the le 64 using the specified src
        /// </summary>
        /// <param name="src">The src</param>
        /// <returns>The ulong</returns>
        [return: NotNull]
        public static ulong ReadLe64([NotNull] IntPtr src) => INTERNAL_SDL_ReadLE64(src.Validate());

        /// <summary>
        ///     Sdl the read be 64 using the specified src
        /// </summary>
        /// <param name="src">The src</param>
        /// <returns>The int 64</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_ReadBE64", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern ulong INTERNAL_SDL_ReadBE64([NotNull] IntPtr src);

        /// <summary>
        ///     Reads the be 64 using the specified src
        /// </summary>
        /// <param name="src">The src</param>
        /// <returns>The ulong</returns>
        [return: NotNull]
        public static ulong ReadBe64([NotNull] IntPtr src) => INTERNAL_SDL_ReadBE64(src.Validate());

        /// <summary>
        ///     Sdl the write u 8 using the specified dst
        /// </summary>
        /// <param name="dst">The dst</param>
        /// <param name="value">The value</param>
        /// <returns>The uint</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_WriteU8", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern uint INTERNAL_SDL_WriteU8([NotNull] IntPtr dst, [NotNull] byte value);

        /// <summary>
        ///     Writes the u 8 using the specified dst
        /// </summary>
        /// <param name="dst">The dst</param>
        /// <param name="value">The value</param>
        /// <returns>The uint</returns>
        [return: NotNull]
        public static uint WriteU8([NotNull] IntPtr dst, [NotNull] byte value) => INTERNAL_SDL_WriteU8(dst.Validate(), value.Validate());

        /// <summary>
        ///     Sdl the write le 16 using the specified dst
        /// </summary>
        /// <param name="dst">The dst</param>
        /// <param name="value">The value</param>
        /// <returns>The uint</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_WriteLE16", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern uint INTERNAL_SDL_WriteLE16([NotNull] IntPtr dst, [NotNull] ushort value);

        /// <summary>
        ///     Writes the le 16 using the specified dst
        /// </summary>
        /// <param name="dst">The dst</param>
        /// <param name="value">The value</param>
        /// <returns>The uint</returns>
        [return: NotNull]
        public static uint WriteLe16([NotNull] IntPtr dst, [NotNull] ushort value) => INTERNAL_SDL_WriteLE16(dst.Validate(), value.Validate());

        /// <summary>
        ///     Sdl the write be 16 using the specified dst
        /// </summary>
        /// <param name="dst">The dst</param>
        /// <param name="value">The value</param>
        /// <returns>The uint</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_WriteBE16", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern uint INTERNAL_SDL_WriteBE16([NotNull] IntPtr dst, [NotNull] ushort value);

        /// <summary>
        ///     Writes the be 16 using the specified dst
        /// </summary>
        /// <param name="dst">The dst</param>
        /// <param name="value">The value</param>
        /// <returns>The uint</returns>
        [return: NotNull]
        public static uint WriteBe16([NotNull] IntPtr dst, [NotNull] ushort value) => INTERNAL_SDL_WriteBE16(dst.Validate(), value.Validate());

        /// <summary>
        ///     Sdl the write le 32 using the specified dst
        /// </summary>
        /// <param name="dst">The dst</param>
        /// <param name="value">The value</param>
        /// <returns>The uint</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_WriteLE32", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern uint INTERNAL_SDL_WriteLE32([NotNull] IntPtr dst, [NotNull] uint value);

        /// <summary>
        ///     Writes the le 32 using the specified dst
        /// </summary>
        /// <param name="dst">The dst</param>
        /// <param name="value">The value</param>
        /// <returns>The uint</returns>
        [return: NotNull]
        public static uint WriteLe32([NotNull] IntPtr dst, [NotNull] uint value) => INTERNAL_SDL_WriteLE32(dst.Validate(), value.Validate());

        /// <summary>
        ///     Sdl the write be 32 using the specified dst
        /// </summary>
        /// <param name="dst">The dst</param>
        /// <param name="value">The value</param>
        /// <returns>The uint</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_WriteBE32", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern uint INTERNAL_SDL_WriteBE32([NotNull] IntPtr dst, [NotNull] uint value);

        /// <summary>
        ///     Writes the be 32 using the specified dst
        /// </summary>
        /// <param name="dst">The dst</param>
        /// <param name="value">The value</param>
        /// <returns>The uint</returns>
        [return: NotNull]
        public static uint WriteBe32([NotNull] IntPtr dst, [NotNull] uint value) => INTERNAL_SDL_WriteBE32(dst.Validate(), value.Validate());

        /// <summary>
        ///     Sdl the write le 64 using the specified dst
        /// </summary>
        /// <param name="dst">The dst</param>
        /// <param name="value">The value</param>
        /// <returns>The uint</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_WriteLE64", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern uint INTERNAL_SDL_WriteLE64([NotNull] IntPtr dst, [NotNull] ulong value);

        /// <summary>
        ///     Writes the le 64 using the specified dst
        /// </summary>
        /// <param name="dst">The dst</param>
        /// <param name="value">The value</param>
        /// <returns>The uint</returns>
        [return: NotNull]
        public static uint WriteLe64([NotNull] IntPtr dst, [NotNull] ulong value) => INTERNAL_SDL_WriteLE64(dst.Validate(), value.Validate());

        /// <summary>
        ///     Sdl the write be 64 using the specified dst
        /// </summary>
        /// <param name="dst">The dst</param>
        /// <param name="value">The value</param>
        /// <returns>The uint</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_WriteBE64", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern uint INTERNAL_SDL_WriteBE64([NotNull] IntPtr dst, [NotNull] ulong value);

        /// <summary>
        ///     Writes the be 64 using the specified dst
        /// </summary>
        /// <param name="dst">The dst</param>
        /// <param name="value">The value</param>
        /// <returns>The uint</returns>
        public static uint WriteBe64([NotNull] IntPtr dst, [NotNull] ulong value) => INTERNAL_SDL_WriteBE64(dst.Validate(), value.Validate());

        /// <summary>
        ///     Sdl the r w close using the specified context
        /// </summary>
        /// <param name="context">The context</param>
        /// <returns>The long</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_RwClose", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern long INTERNAL_SDL_RwClose([NotNull] IntPtr context);

        /// <summary>
        ///     Rws the close using the specified context
        /// </summary>
        /// <param name="context">The context</param>
        /// <returns>The long</returns>
        [return: NotNull]
        public static long RwClose([NotNull] IntPtr context) => INTERNAL_SDL_RwClose(context.Validate());

        /// <summary>
        ///     Internals the sdl load file using the specified file
        /// </summary>
        /// <param name="file">The file</param>
        /// <param name="dataSize">The data size</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_LoadFile", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern IntPtr INTERNAL_SDL_LoadFile([NotNull] byte[] file, out IntPtr dataSize);

        /// <summary>
        ///     Sdl the load file using the specified file
        /// </summary>
        /// <param name="file">The file</param>
        /// <param name="dataSize">The data size</param>
        /// <returns>The result</returns>
        [return: NotNull]
        public static IntPtr LoadFile([NotNull] string file, out IntPtr dataSize) => INTERNAL_SDL_LoadFile(Utf8Manager.Utf8EncodeHeap(file), out dataSize);

        /// <summary>
        ///     Sdl the set main ready
        /// </summary>
        [DllImport(NativeLibName, EntryPoint = "SDL_SetMainReady", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern void INTERNAL_SDL_SetMainReady();

        /// <summary>
        ///     Sets the main ready
        /// </summary>
        [return: NotNull]
        public static void SetMainReady() => INTERNAL_SDL_SetMainReady();

        /// <summary>
        ///     Sdl the win rt run app using the specified main function
        /// </summary>
        /// <param name="mainFunction">The main function</param>
        /// <param name="reserved">The reserved</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_WinRTRunApp", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern int INTERNAL_SDL_WinRTRunApp(SdlMainFunc mainFunction, [NotNull] IntPtr reserved);

        /// <summary>
        ///     Wins the rt run app using the specified main function
        /// </summary>
        /// <param name="mainFunction">The main function</param>
        /// <param name="reserved">The reserved</param>
        /// <returns>The int</returns>
        [return: NotNull]
        public static int WinRtRunApp([NotNull] SdlMainFunc mainFunction, [NotNull] IntPtr reserved) => INTERNAL_SDL_WinRTRunApp(mainFunction.Validate(), reserved.Validate());

        /// <summary>
        ///     Sdl the ui kit run app using the specified argc
        /// </summary>
        /// <param name="argc">The argc</param>
        /// <param name="argv">The argv</param>
        /// <param name="mainFunction">The main function</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_UIKitRunApp", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern int INTERNAL_SDL_UIKitRunApp([NotNull] int argc, IntPtr argv, SdlMainFunc mainFunction);

        /// <summary>
        ///     Uis the kit run app using the specified argc
        /// </summary>
        /// <param name="argc">The argc</param>
        /// <param name="argv">The argv</param>
        /// <param name="mainFunction">The main function</param>
        /// <returns>The int</returns>
        [return: NotNull]
        public static int UiKitRunApp([NotNull] int argc, [NotNull] IntPtr argv, [NotNull] SdlMainFunc mainFunction) => INTERNAL_SDL_UIKitRunApp(argc.Validate(), argv.Validate(), mainFunction.Validate());

        /// <summary>
        ///     Sdl the init using the specified flags
        /// </summary>
        /// <param name="flags">The flags</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_Init", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern int INTERNAL_SDL_Init([NotNull] uint flags);

        /// <summary>
        ///     Sdl the init using the specified flags
        /// </summary>
        /// <param name="flags">The flags</param>
        /// <returns>The int</returns>
        [return: NotNull]
        public static int Init([NotNull] uint flags) => INTERNAL_SDL_Init(flags.Validate());

        /// <summary>
        ///     Sdl the init sub system using the specified flags
        /// </summary>
        /// <param name="flags">The flags</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_InitSubSystem", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern int INTERNAL_SDL_InitSubSystem([NotNull] uint flags);

        /// <summary>
        ///     Inits the sub system using the specified flags
        /// </summary>
        /// <param name="flags">The flags</param>
        /// <returns>The int</returns>
        public static int InitSubSystem([NotNull] uint flags) => INTERNAL_SDL_InitSubSystem(flags.Validate());

        /// <summary>
        ///     Sdl the quit
        /// </summary>
        [DllImport(NativeLibName, EntryPoint = "SDL_Quit", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern void INTERNAL_SDL_Quit();

        /// <summary>
        ///     Sdl the quit
        /// </summary>
        [return: NotNull]
        public static void Quit() => INTERNAL_SDL_Quit();

        /// <summary>
        ///     Sdl the quit sub system using the specified flags
        /// </summary>
        /// <param name="flags">The flags</param>
        [DllImport(NativeLibName, EntryPoint = "SDL_QuitSubSystem", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern void INTERNAL_SDL_QuitSubSystem([NotNull] uint flags);

        /// <summary>
        ///     Quits the sub system using the specified flags
        /// </summary>
        /// <param name="flags">The flags</param>
        [return: NotNull]
        public static void QuitSubSystem([NotNull] uint flags) => INTERNAL_SDL_QuitSubSystem(flags.Validate());

        /// <summary>
        ///     Sdl the was init using the specified flags
        /// </summary>
        /// <param name="flags">The flags</param>
        /// <returns>The uint</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_WasInit", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern uint INTERNAL_SDL_WasInit([NotNull] uint flags);

        /// <summary>
        ///     Sdl the was init using the specified flags
        /// </summary>
        /// <param name="flags">The flags</param>
        /// <returns>The uint</returns>
        [return: NotNull]
        public static uint SDL_WasInit([NotNull] uint flags) => INTERNAL_SDL_WasInit(flags.Validate());

        /// <summary>
        ///     Internals the sdl get platform
        /// </summary>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GetPlatform", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern IntPtr INTERNAL_SDL_GetPlatform();

        /// <summary>
        ///     Sdl the get platform
        /// </summary>
        /// <returns>The string</returns>
        [return: NotNull]
        public static string GetPlatform() => Utf8Manager.Utf8ToManaged(INTERNAL_SDL_GetPlatform());

        /// <summary>
        ///     Sdl the clear hints
        /// </summary>
        [DllImport(NativeLibName, EntryPoint = "SDL_ClearHints", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern void INTERNAL_SDL_ClearHints();

        /// <summary>
        ///     Clears the hints
        /// </summary>
        [return: NotNull]
        public static void ClearHints() => INTERNAL_SDL_ClearHints();

        /// <summary>
        ///     Internals the sdl get hint using the specified name
        /// </summary>
        /// <param name="name">The name</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GetHint", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern IntPtr INTERNAL_SDL_GetHint([NotNull] byte[] name);

        /// <summary>
        ///     Sdl the get hint using the specified name
        /// </summary>
        /// <param name="name">The name</param>
        /// <returns>The string</returns>
        [return: NotNull]
        public static string GetHint([NotNull] string name) => Utf8Manager.Utf8ToManaged(INTERNAL_SDL_GetHint(Utf8Manager.Utf8Encode(name, new byte[Utf8Manager.Utf8Size(name)], Utf8Manager.Utf8Size(name))));

        /// <summary>
        ///     Internals the sdl set hint using the specified name
        /// </summary>
        /// <param name="name">The name</param>
        /// <param name="value">The value</param>
        /// <returns>The sdl bool</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_SetHint", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern SdlBool INTERNAL_SDL_SetHint([NotNull] byte[] name, [NotNull] byte[] value);

        /// <summary>
        ///     Sdl the set hint using the specified name
        /// </summary>
        /// <param name="name">The name</param>
        /// <param name="value">The value</param>
        /// <returns>The sdl bool</returns>
        [return: NotNull]
        public static SdlBool SetHint([NotNull] string name, [NotNull] string value) => INTERNAL_SDL_SetHint(Utf8Manager.Utf8Encode(name, new byte[Utf8Manager.Utf8Size(name)], Utf8Manager.Utf8Size(name)), Utf8Manager.Utf8Encode(value, new byte[Utf8Manager.Utf8Size(value)], Utf8Manager.Utf8Size(value)));

        /// <summary>
        ///     Internals the sdl set hint with priority using the specified name
        /// </summary>
        /// <param name="name">The name</param>
        /// <param name="value">The value</param>
        /// <param name="priority">The priority</param>
        /// <returns>The sdl bool</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_SetHintWithPriority", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern SdlBool INTERNAL_SDL_SetHintWithPriority([NotNull] byte[] name, [NotNull] byte[] value, SdlHintPriority priority);

        /// <summary>
        ///     Sdl the set hint with priority using the specified name
        /// </summary>
        /// <param name="name">The name</param>
        /// <param name="value">The value</param>
        /// <param name="priority">The priority</param>
        /// <returns>The sdl bool</returns>
        [return: NotNull]
        public static SdlBool SetHintWithPriority([NotNull] string name, [NotNull] string value, SdlHintPriority priority) => INTERNAL_SDL_SetHintWithPriority(Utf8Manager.Utf8Encode(name, new byte[Utf8Manager.Utf8Size(name)], Utf8Manager.Utf8Size(name)), Utf8Manager.Utf8Encode(value, new byte[Utf8Manager.Utf8Size(value)], Utf8Manager.Utf8Size(value)), priority);

        /// <summary>
        ///     Internals the sdl get hint boolean using the specified name
        /// </summary>
        /// <param name="name">The name</param>
        /// <param name="defaultValue">The default value</param>
        /// <returns>The sdl bool</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GetHintBoolean", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern SdlBool INTERNAL_SDL_GetHintBoolean([NotNull] byte[] name, SdlBool defaultValue);

        /// <summary>
        ///     Sdl the get hint boolean using the specified name
        /// </summary>
        /// <param name="name">The name</param>
        /// <param name="defaultValue">The default value</param>
        /// <returns>The sdl bool</returns>
        [return: NotNull]
        public static SdlBool GetHintBoolean([NotNull] string name, SdlBool defaultValue) => INTERNAL_SDL_GetHintBoolean(Utf8Manager.Utf8Encode(name, new byte[Utf8Manager.Utf8Size(name)], Utf8Manager.Utf8Size(name)), defaultValue);

        /// <summary>
        ///     Sdl the clear error
        /// </summary>
        [DllImport(NativeLibName, EntryPoint = "SDL_ClearError", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern void INTERNAL_SDL_ClearError();

        /// <summary>
        ///     Sdl the clear error
        /// </summary>
        [return: NotNull]
        public static void ClearError() => INTERNAL_SDL_ClearError();

        /// <summary>
        ///     Internals the sdl get error
        /// </summary>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GetError", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern IntPtr INTERNAL_SDL_GetError();

        /// <summary>
        ///     Sdl the get error
        /// </summary>
        /// <returns>The string</returns>
        [return: NotNull]
        public static string GetError() => Utf8Manager.Utf8ToManaged(INTERNAL_SDL_GetError());

        /// <summary>
        ///     Internals the sdl set error using the specified fmt and arg list
        /// </summary>
        /// <param name="fmtAndArgList">The fmt and arg list</param>
        [DllImport(NativeLibName, EntryPoint = "SDL_SetError", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern void INTERNAL_SDL_SetError([NotNull] byte[] fmtAndArgList);

        /// <summary>
        ///     Sdl the set error using the specified fmt and arg list
        /// </summary>
        /// <param name="fmtAndArgList">The fmt and arg list</param>
        [return: NotNull]
        public static void SetError([NotNull] string fmtAndArgList) => INTERNAL_SDL_SetError(Utf8Manager.Utf8Encode(fmtAndArgList, new byte[Utf8Manager.Utf8Size(fmtAndArgList)], Utf8Manager.Utf8Size(fmtAndArgList)));

        /// <summary>
        ///     Sdl the get error msg using the specified err str
        /// </summary>
        /// <param name="errStr">The err str</param>
        /// <param name="maxlength">The maxlength</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GetErrorMsg", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern IntPtr INTERNAL_SDL_GetErrorMsg([NotNull] IntPtr errStr, [NotNull] int maxlength);

        /// <summary>
        ///     Sdl the get error msg using the specified err str
        /// </summary>
        /// <param name="errStr">The err str</param>
        /// <param name="maxlength">The maxlength</param>
        /// <returns>The int ptr</returns>
        public static IntPtr GetErrorMsg([NotNull] IntPtr errStr, [NotNull] int maxlength) => INTERNAL_SDL_GetErrorMsg(errStr.Validate(), maxlength.Validate());

        /// <summary>
        ///     Internals the sdl log using the specified fmt and arg list
        /// </summary>
        /// <param name="fmtAndArgList">The fmt and arg list</param>
        [DllImport(NativeLibName, EntryPoint = "SDL_Log", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern void INTERNAL_SDL_Log([NotNull] byte[] fmtAndArgList);

        /// <summary>
        ///     Sdl the log using the specified fmt and arg list
        /// </summary>
        /// <param name="fmtAndArgList">The fmt and arg list</param>
        [return: NotNull]
        public static void Log([NotNull] string fmtAndArgList) => INTERNAL_SDL_Log(Utf8Manager.Utf8Encode(fmtAndArgList, new byte[Utf8Manager.Utf8Size(fmtAndArgList)], Utf8Manager.Utf8Size(fmtAndArgList)));

        /// <summary>
        ///     Internals the sdl log verbose using the specified category
        /// </summary>
        /// <param name="category">The category</param>
        /// <param name="fmtAndArgList">The fmt and arg list</param>
        [DllImport(NativeLibName, EntryPoint = "SDL_LogVerbose", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern void INTERNAL_SDL_LogVerbose([NotNull] int category, [NotNull] byte[] fmtAndArgList);

        /// <summary>
        ///     Sdl the log verbose using the specified category
        /// </summary>
        /// <param name="category">The category</param>
        /// <param name="fmtAndArgList">The fmt and arg list</param>
        [return: NotNull]
        public static void LogVerbose([NotNull] int category, [NotNull] string fmtAndArgList) => INTERNAL_SDL_LogVerbose(category, Utf8Manager.Utf8Encode(fmtAndArgList, new byte[Utf8Manager.Utf8Size(fmtAndArgList)], Utf8Manager.Utf8Size(fmtAndArgList)));

        /// <summary>
        ///     Internals the sdl log debug using the specified category
        /// </summary>
        /// <param name="category">The category</param>
        /// <param name="fmtAndArgList">The fmt and arg list</param>
        [DllImport(NativeLibName, EntryPoint = "SDL_LogDebug", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern void INTERNAL_SDL_LogDebug([NotNull] int category, [NotNull] byte[] fmtAndArgList);

        /// <summary>
        ///     Sdl the log debug using the specified category
        /// </summary>
        /// <param name="category">The category</param>
        /// <param name="fmtAndArgList">The fmt and arg list</param>
        public static void LogDebug([NotNull] int category, [NotNull] string fmtAndArgList) => INTERNAL_SDL_LogDebug(category, Utf8Manager.Utf8Encode(fmtAndArgList, new byte[Utf8Manager.Utf8Size(fmtAndArgList)], Utf8Manager.Utf8Size(fmtAndArgList)));

        /// <summary>
        ///     Internals the sdl log info using the specified category
        /// </summary>
        /// <param name="category">The category</param>
        /// <param name="fmtAndArgList">The fmt and arg list</param>
        [DllImport(NativeLibName, EntryPoint = "SDL_LogInfo", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern void INTERNAL_SDL_LogInfo([NotNull] int category, [NotNull] byte[] fmtAndArgList);

        /// <summary>
        ///     Sdl the log info using the specified category
        /// </summary>
        /// <param name="category">The category</param>
        /// <param name="fmtAndArgList">The fmt and arg list</param>
        public static void LogInfo([NotNull] int category, [NotNull] string fmtAndArgList) => INTERNAL_SDL_LogInfo(category, Utf8Manager.Utf8Encode(fmtAndArgList, new byte[Utf8Manager.Utf8Size(fmtAndArgList)], Utf8Manager.Utf8Size(fmtAndArgList)));

        /// <summary>
        ///     Internals the sdl log warn using the specified category
        /// </summary>
        /// <param name="category">The category</param>
        /// <param name="fmtAndArgList">The fmt and arg list</param>
        [DllImport(NativeLibName, EntryPoint = "SDL_LogWarn", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern void INTERNAL_SDL_LogWarn([NotNull] int category, [NotNull] byte[] fmtAndArgList);

        /// <summary>
        ///     Sdl the log warn using the specified category
        /// </summary>
        /// <param name="category">The category</param>
        /// <param name="fmtAndArgList">The fmt and arg list</param>
        [return: NotNull]
        public static void LogWarning([NotNull] int category, [NotNull] string fmtAndArgList) => INTERNAL_SDL_LogWarn(category, Utf8Manager.Utf8Encode(fmtAndArgList, new byte[Utf8Manager.Utf8Size(fmtAndArgList)], Utf8Manager.Utf8Size(fmtAndArgList)));

        /// <summary>
        ///     Internals the sdl log error using the specified category
        /// </summary>
        /// <param name="category">The category</param>
        /// <param name="fmtAndArgList">The fmt and arg list</param>
        [DllImport(NativeLibName, EntryPoint = "SDL_LogError", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern void INTERNAL_SDL_LogError([NotNull] int category, [NotNull] byte[] fmtAndArgList);

        /// <summary>
        ///     Sdl the log error using the specified category
        /// </summary>
        /// <param name="category">The category</param>
        /// <param name="fmtAndArgList">The fmt and arg list</param>
        [return: NotNull]
        public static void LogError([NotNull] int category, [NotNull] string fmtAndArgList) => INTERNAL_SDL_LogError(category, Utf8Manager.Utf8Encode(fmtAndArgList, new byte[Utf8Manager.Utf8Size(fmtAndArgList)], Utf8Manager.Utf8Size(fmtAndArgList)));

        /// <summary>
        ///     Internals the sdl log critical using the specified category
        /// </summary>
        /// <param name="category">The category</param>
        /// <param name="fmtAndArgList">The fmt and arg list</param>
        [DllImport(NativeLibName, EntryPoint = "SDL_LogCritical", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern void INTERNAL_SDL_LogCritical([NotNull] int category, [NotNull] byte[] fmtAndArgList);

        /// <summary>
        ///     Sdl the log critical using the specified category
        /// </summary>
        /// <param name="category">The category</param>
        /// <param name="fmtAndArgList">The fmt and arg list</param>
        [return: NotNull]
        public static void LogCritical([NotNull] int category, [NotNull] string fmtAndArgList) => INTERNAL_SDL_LogCritical(category, Utf8Manager.Utf8Encode(fmtAndArgList, new byte[Utf8Manager.Utf8Size(fmtAndArgList)], Utf8Manager.Utf8Size(fmtAndArgList)));

        /// <summary>
        ///     Internals the sdl log message using the specified category
        /// </summary>
        /// <param name="category">The category</param>
        /// <param name="priority">The priority</param>
        /// <param name="fmtAndArgList">The fmt and arg list</param>
        [DllImport(NativeLibName, EntryPoint = "SDL_LogMessage", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern void INTERNAL_SDL_LogMessage([NotNull] int category, SdlLogPriority priority, [NotNull] byte[] fmtAndArgList);

        /// <summary>
        ///     Sdl the log message using the specified category
        /// </summary>
        /// <param name="category">The category</param>
        /// <param name="priority">The priority</param>
        /// <param name="fmtAndArgList">The fmt and arg list</param>
        [return: NotNull]
        public static void LogMessage([NotNull] int category, SdlLogPriority priority, [NotNull] string fmtAndArgList) => INTERNAL_SDL_LogMessage(category, priority, Utf8Manager.Utf8Encode(fmtAndArgList, new byte[Utf8Manager.Utf8Size(fmtAndArgList)], Utf8Manager.Utf8Size(fmtAndArgList)));

        /// <summary>
        ///     Internals the sdl log message v using the specified category
        /// </summary>
        /// <param name="category">The category</param>
        /// <param name="priority">The priority</param>
        /// <param name="fmtAndArgList">The fmt and arg list</param>
        [DllImport(NativeLibName, EntryPoint = "SDL_LogMessageV", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern void INTERNAL_SDL_LogMessageV([NotNull] int category, SdlLogPriority priority, [NotNull] byte[] fmtAndArgList);

        /// <summary>
        ///     Sdl the log message v using the specified category
        /// </summary>
        /// <param name="category">The category</param>
        /// <param name="priority">The priority</param>
        /// <param name="fmtAndArgList">The fmt and arg list</param>
        [return: NotNull]
        public static void LogMessageV([NotNull] int category, SdlLogPriority priority, [NotNull] string fmtAndArgList) => INTERNAL_SDL_LogMessageV(category, priority, Utf8Manager.Utf8Encode(fmtAndArgList, new byte[Utf8Manager.Utf8Size(fmtAndArgList)], Utf8Manager.Utf8Size(fmtAndArgList)));

        /// <summary>
        ///     Sdl the log get priority using the specified category
        /// </summary>
        /// <param name="category">The category</param>
        /// <returns>The sdl log priority</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_LogGetPriority", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern SdlLogPriority INTERNAL_SDL_LogGetPriority([NotNull] int category);

        /// <summary>
        ///     Sdl the log get priority using the specified category
        /// </summary>
        /// <param name="category">The category</param>
        /// <returns>The sdl log priority</returns>
        [return: NotNull]
        public static SdlLogPriority LogGetPriority([NotNull] int category) => INTERNAL_SDL_LogGetPriority(category.Validate());

        /// <summary>
        ///     Sdl the log set priority using the specified category
        /// </summary>
        /// <param name="category">The category</param>
        /// <param name="priority">The priority</param>
        [DllImport(NativeLibName, EntryPoint = "SDL_LogSetPriority", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern void INTERNAL_SDL_LogSetPriority([NotNull] int category, SdlLogPriority priority);

        /// <summary>
        ///     Sdl the log set priority using the specified category
        /// </summary>
        /// <param name="category">The category</param>
        /// <param name="priority">The priority</param>
        [return: NotNull]
        public static void LogSetPriority([NotNull] int category, [NotNull] SdlLogPriority priority) => INTERNAL_SDL_LogSetPriority(category.Validate(), priority.Validate());

        /// <summary>
        ///     Sdl the log set all priority using the specified priority
        /// </summary>
        /// <param name="priority">The priority</param>
        [DllImport(NativeLibName, EntryPoint = "SDL_LogSetAllPriority", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern void INTERNAL_SDL_LogSetAllPriority([NotNull] SdlLogPriority priority);

        /// <summary>
        ///     Sdl the log set all priority using the specified priority
        /// </summary>
        /// <param name="priority">The priority</param>
        [return: NotNull]
        public static void LogSetAllPriority([NotNull] SdlLogPriority priority) => INTERNAL_SDL_LogSetAllPriority(priority.Validate());

        /// <summary>
        ///     Sdl the log reset priorities
        /// </summary>
        [DllImport(NativeLibName, EntryPoint = "SDL_LogResetPriorities", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern void INTERNAL_SDL_LogResetPriorities();

        /// <summary>
        ///     Sdl the log reset priorities
        /// </summary>
        [return: NotNull]
        public static void LogResetPriorities() => INTERNAL_SDL_LogResetPriorities();

        /// <summary>
        ///     Sdl the log get output function using the specified callback
        /// </summary>
        /// <param name="callback">The callback</param>
        /// <param name="userdata">The userdata</param>
        [DllImport(NativeLibName, EntryPoint = "SDL_LogGetOutputFunction", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern void INTERNAL_SDL_LogGetOutputFunction(out IntPtr callback, out IntPtr userdata);

        /// <summary>
        ///     Sdl the log get output function using the specified callback
        /// </summary>
        /// <param name="callback">The callback</param>
        /// <param name="userdata">The userdata</param>
        [return: NotNull]
        public static void SDL_LogGetOutputFunction(out SdlLogOutputFunction callback, out IntPtr userdata)
        {
            INTERNAL_SDL_LogGetOutputFunction(
                out IntPtr result,
                out userdata
            );
            if (result != IntPtr.Zero)
            {
                callback = (SdlLogOutputFunction) Marshal.GetDelegateForFunctionPointer(
                    result,
                    typeof(SdlLogOutputFunction)
                );
            }
            else
            {
                callback = null;
            }
        }

        /// <summary>
        ///     Sdl the log set output function using the specified callback
        /// </summary>
        /// <param name="callback">The callback</param>
        /// <param name="userdata">The userdata</param>
        [DllImport(NativeLibName, EntryPoint = "SDL_LogSetOutputFunction", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern void INTERNAL_SDL_LogSetOutputFunction([NotNull] SdlLogOutputFunction callback, [NotNull] IntPtr userdata);

        /// <summary>
        ///     Logs the set output function using the specified callback
        /// </summary>
        /// <param name="callback">The callback</param>
        /// <param name="userdata">The userdata</param>
        [return: NotNull]
        public static void LogSetOutputFunction([NotNull] SdlLogOutputFunction callback, [NotNull] IntPtr userdata) => INTERNAL_SDL_LogSetOutputFunction(callback.Validate(), userdata.Validate());

        /// <summary>
        ///     Internals the sdl show message box using the specified message box data
        /// </summary>
        /// <param name="messageBoxData">The message box data</param>
        /// <param name="buttonId">The button id</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_ShowMessageBox", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern int INTERNAL_SDL_ShowMessageBox([In] ref InternalSdlMessageBoxData messageBoxData, out int buttonId);

        /// <summary>
        ///     Internals the alloc utf 8 using the specified str
        /// </summary>
        /// <param name="str">The str</param>
        /// <returns>The mem</returns>
        [return: NotNull]
        private static IntPtr INTERNAL_AllocUTF8([NotNull] string str)
        {
            if (string.IsNullOrEmpty(str))
            {
                return IntPtr.Zero;
            }

            IntPtr mem = INTERNAL_SDL_malloc(Encoding.UTF8.GetBytes(str + '\0').Length);
            Marshal.Copy(Encoding.UTF8.GetBytes(str + '\0'), 0, mem, Encoding.UTF8.GetBytes(str + '\0').Length);
            return mem;
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
                title = INTERNAL_AllocUTF8(messageBoxData.title),
                message = INTERNAL_AllocUTF8(messageBoxData.message),
                numbuttons = messageBoxData.numbuttons
            };

            InternalSdlMessageBoxButtonData[] buttons = new InternalSdlMessageBoxButtonData[messageBoxData.numbuttons];
            IntPtr buttonsPtr = IntPtr.Zero;

            try
            {
                for (int i = 0; i < messageBoxData.numbuttons; i++)
                {
                    buttons[i] = new InternalSdlMessageBoxButtonData
                    {
                        flags = messageBoxData.buttons[i].flags,
                        buttonId = messageBoxData.buttons[i].buttonId,
                        text = INTERNAL_AllocUTF8(messageBoxData.buttons[i].text)
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
                if (messageBoxData.colorScheme != null)
                {
                    colorSchemePtr = Marshal.AllocHGlobal(Marshal.SizeOf<SdlMessageBoxColorScheme>());
                    Marshal.StructureToPtr(messageBoxData.colorScheme.Value, colorSchemePtr, false);
                }

                int result = INTERNAL_SDL_ShowMessageBox(ref data, out buttonId);

                for (int i = 0; i < messageBoxData.numbuttons; i++)
                {
                    INTERNAL_SDL_free(buttons[i].text);
                }

                INTERNAL_SDL_free(data.message);
                INTERNAL_SDL_free(data.title);

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
        ///     Internals the sdl show simple message box using the specified flags
        /// </summary>
        /// <param name="flags">The flags</param>
        /// <param name="title">The title</param>
        /// <param name="message">The message</param>
        /// <param name="window">The window</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_ShowSimpleMessageBox", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern int INTERNAL_SDL_ShowSimpleMessageBox(SdlMessageBoxFlags flags, [NotNull] byte[] title, [NotNull] byte[] message, [NotNull] IntPtr window);

        /// <summary>
        ///     Sdl the show simple message box using the specified flags
        /// </summary>
        /// <param name="flags">The flags</param>
        /// <param name="title">The title</param>
        /// <param name="message">The message</param>
        /// <param name="window">The window</param>
        /// <returns>The int</returns>
        [return: NotNull]
        public static int ShowSimpleMessageBox(SdlMessageBoxFlags flags, [NotNull] string title, [NotNull] string message, [NotNull] IntPtr window)
            => INTERNAL_SDL_ShowSimpleMessageBox(flags, Utf8Manager.Utf8Encode(title, new byte[Utf8Manager.Utf8Size(title)], Utf8Manager.Utf8Size(title)), Utf8Manager.Utf8Encode(message, new byte[Utf8Manager.Utf8Size(message)], Utf8Manager.Utf8Size(message)), window);

        /// <summary>
        ///     Sdl the version
        /// </summary>
        /// <returns>The sdl version</returns>
        [return: NotNull]
        public static SdlVersion Version() => new SdlVersion(MajorVersion, MinorVersion, PatchLevel);

        /// <summary>
        ///     Sdl the version num using the specified x
        /// </summary>
        /// <param name="x">The </param>
        /// <param name="y">The </param>
        /// <param name="z">The </param>
        /// <returns>The int</returns>
        private static int VersionNum([NotNull] int x, [NotNull] int y, [NotNull] int z) => x * 1000 + y * 100 + z;

        /// <summary>
        ///     Describes whether sdl version at least
        /// </summary>
        /// <param name="x">The </param>
        /// <param name="y">The </param>
        /// <param name="z">The </param>
        /// <returns>The bool</returns>
        public static bool VersionAtLeast([NotNull] int x, [NotNull] int y, [NotNull] int z) => CompiledVersion >= VersionNum(x, y, z);

        /// <summary>
        ///     Sdl the get version using the specified ver
        /// </summary>
        /// <param name="ver">The ver</param>
        [DllImport(NativeLibName, EntryPoint = "SDL_GetVersion", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern void INTERNAL_SDL_GetVersion(out SdlVersion ver);

        /// <summary>
        ///     Sdl the get version using the specified ver
        /// </summary>
        /// <param name="ver">The ver</param>
        [return: NotNull]
        public static void GetVersion(out SdlVersion ver)
        {
            ver = default(SdlVersion).Validate();
            INTERNAL_SDL_GetVersion(out ver);
        }

        /// <summary>
        ///     Internals the sdl get revision
        /// </summary>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GetRevision", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern IntPtr INTERNAL_SDL_GetRevision();

        /// <summary>
        ///     Sdl the get revision
        /// </summary>
        /// <returns>The string</returns>
        [return: NotNull]
        public static string GetRevision() => Utf8Manager.Utf8ToManaged(INTERNAL_SDL_GetRevision());

        /// <summary>
        ///     Sdl the get revision number
        /// </summary>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GetRevisionNumber", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern int INTERNAL_SDL_GetRevisionNumber();

        /// <summary>
        ///     Sdl the get revision number
        /// </summary>
        /// <returns>The int</returns>
        [return: NotNull]
        public static int GetRevisionNumber() => INTERNAL_SDL_GetRevisionNumber();

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
        ///     Internals the sdl create window using the specified title
        /// </summary>
        /// <param name="title">The title</param>
        /// <param name="x">The </param>
        /// <param name="y">The </param>
        /// <param name="w">The </param>
        /// <param name="h">The </param>
        /// <param name="flags">The flags</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_CreateWindow", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern IntPtr INTERNAL_SDL_CreateWindow([NotNull] [NotNull] byte[] title, [NotNull] int x, [NotNull] int y, [NotNull] int w, [NotNull] int h, [NotNull] SdlWindowFlags flags);

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
        public static IntPtr CreateWindow([NotNull] string title, [NotNull] int x, [NotNull] int y, [NotNull] int w, [NotNull] int h, [NotNull] SdlWindowFlags flags) => INTERNAL_SDL_CreateWindow(Utf8Manager.Utf8Encode(title, new byte[Utf8Manager.Utf8Size(title.Validate())], Utf8Manager.Utf8Size(title.Validate())), x, y, w, h, flags);

        /// <summary>
        ///     Sdl the create window and renderer using the specified width
        /// </summary>
        /// <param name="width">The width</param>
        /// <param name="height">The height</param>
        /// <param name="windowFlags">The window flags</param>
        /// <param name="window">The window</param>
        /// <param name="renderer">The renderer</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_CreateWindowAndRenderer", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern int INTERNAL_SDL_CreateWindowAndRenderer([NotNull] int width, [NotNull] int height, [NotNull] SdlWindowFlags windowFlags, out IntPtr window, out IntPtr renderer);

        /// <summary>
        ///     Sdl the create window and renderer using the specified width
        /// </summary>
        /// <param name="width">The width</param>
        /// <param name="height">The height</param>
        /// <param name="windowFlags">The window flags</param>
        /// <param name="window">The window</param>
        /// <param name="renderer">The renderer</param>
        /// <returns>The int</returns>
        public static int CreateWindowAndRenderer([NotNull] int width, [NotNull] int height, [NotNull] SdlWindowFlags windowFlags, out IntPtr window, out IntPtr renderer) => INTERNAL_SDL_CreateWindowAndRenderer(width.Validate(), height.Validate(), windowFlags.Validate(), out window, out renderer);

        /// <summary>
        ///     Sdl the create window from using the specified data
        /// </summary>
        /// <param name="data">The data</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_CreateWindowFrom", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern IntPtr INTERNAL_SDL_CreateWindowFrom([NotNull] IntPtr data);

        /// <summary>
        ///     Sdl the create window from using the specified data
        /// </summary>
        /// <param name="data">The data</param>
        /// <returns>The int ptr</returns>
        [return: NotNull]
        public static IntPtr CreateWindowFrom([NotNull] IntPtr data) => INTERNAL_SDL_CreateWindowFrom(data.Validate());

        /// <summary>
        ///     Sdl the destroy window using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        [DllImport(NativeLibName, EntryPoint = "SDL_DestroyWindow", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern void INTERNAL_SDL_DestroyWindow([NotNull] IntPtr window);

        /// <summary>
        ///     Sdl the destroy window using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        [return: NotNull]
        public static void DestroyWindow([NotNull] IntPtr window) => INTERNAL_SDL_DestroyWindow(window.Validate());

        /// <summary>
        ///     Sdl the disable screen saver
        /// </summary>
        [DllImport(NativeLibName, EntryPoint = "SDL_DisableScreenSaver", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern void INTERNAL_SDL_DisableScreenSaver();

        /// <summary>
        ///     Sdl the disable screen saver
        /// </summary>
        [return: NotNull]
        public static void DisableScreenSaver() => INTERNAL_SDL_DisableScreenSaver();

        /// <summary>
        ///     Sdl the enable screen saver
        /// </summary>
        [DllImport(NativeLibName, EntryPoint = "SDL_EnableScreenSaver", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern void INTERNAL_SDL_EnableScreenSaver();

        /// <summary>
        ///     Internals the sdl enable screen saver
        /// </summary>
        public static void EnableScreenSaver() => INTERNAL_SDL_EnableScreenSaver();

        /// <summary>
        ///     Sdl the get closest display mode using the specified display index
        /// </summary>
        /// <param name="displayIndex">The display index</param>
        /// <param name="mode">The mode</param>
        /// <param name="closest">The closest</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GetClosestDisplayMode", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern IntPtr INTERNAL_SDL_GetClosestDisplayMode([NotNull] int displayIndex, ref SdlDisplayMode mode, out SdlDisplayMode closest);

        /// <summary>
        ///     Sdl the get closest display mode using the specified display index
        /// </summary>
        /// <param name="displayIndex">The display index</param>
        /// <param name="mode">The mode</param>
        /// <param name="closest">The closest</param>
        /// <returns>The int ptr</returns>
        [return: NotNull]
        public static IntPtr GetClosestDisplayMode([NotNull] int displayIndex, ref SdlDisplayMode mode, out SdlDisplayMode closest) => INTERNAL_SDL_GetClosestDisplayMode(displayIndex.Validate(), ref mode, out closest);

        /// <summary>
        ///     Sdl the get current display mode using the specified display index
        /// </summary>
        /// <param name="displayIndex">The display index</param>
        /// <param name="mode">The mode</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GetCurrentDisplayMode", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern int INTERNAL_SDL_GetCurrentDisplayMode([NotNull] int displayIndex, out SdlDisplayMode mode);

        /// <summary>
        ///     Sdl the get current display mode using the specified display index
        /// </summary>
        /// <param name="displayIndex">The display index</param>
        /// <param name="mode">The mode</param>
        /// <returns>The int</returns>
        [return: NotNull]
        public static int GetCurrentDisplayMode([NotNull] int displayIndex, out SdlDisplayMode mode) => INTERNAL_SDL_GetCurrentDisplayMode(displayIndex.Validate(), out mode);

        /// <summary>
        ///     Internals the sdl get current video driver
        /// </summary>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GetCurrentVideoDriver", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern IntPtr INTERNAL_SDL_GetCurrentVideoDriver();

        /// <summary>
        ///     Sdl the get current video driver
        /// </summary>
        /// <returns>The string</returns>
        public static string SDL_GetCurrentVideoDriver() => Utf8Manager.Utf8ToManaged(INTERNAL_SDL_GetCurrentVideoDriver());

        /// <summary>
        ///     Sdl the get desktop display mode using the specified display index
        /// </summary>
        /// <param name="displayIndex">The display index</param>
        /// <param name="mode">The mode</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GetDesktopDisplayMode", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern int INTERNAL_SDL_GetDesktopDisplayMode([NotNull] int displayIndex, out SdlDisplayMode mode);

        /// <summary>
        ///     Gets the desktop display mode using the specified display index
        /// </summary>
        /// <param name="displayIndex">The display index</param>
        /// <param name="mode">The mode</param>
        /// <returns>The int</returns>
        [return: NotNull]
        public static int GetDesktopDisplayMode([NotNull] int displayIndex, out SdlDisplayMode mode) => INTERNAL_SDL_GetDesktopDisplayMode(displayIndex.Validate(), out mode);

        /// <summary>
        ///     Internals the sdl get display name using the specified index
        /// </summary>
        /// <param name="index">The index</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GetDisplayName", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern IntPtr INTERNAL_SDL_GetDisplayName([NotNull] int index);

        /// <summary>
        ///     Sdl the get display name using the specified index
        /// </summary>
        /// <param name="index">The index</param>
        /// <returns>The string</returns>
        [return: NotNull]
        public static string GetDisplayName([NotNull] int index) => Utf8Manager.Utf8ToManaged(INTERNAL_SDL_GetDisplayName(index));

        /// <summary>
        ///     Sdl the get display bounds using the specified display index
        /// </summary>
        /// <param name="displayIndex">The display index</param>
        /// <param name="rect">The rect</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GetDisplayBounds", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern int INTERNAL_SDL_GetDisplayBounds([NotNull] int displayIndex, out RectangleI rect);

        /// <summary>
        ///     Gets the display bounds using the specified display index
        /// </summary>
        /// <param name="displayIndex">The display index</param>
        /// <param name="rect">The rect</param>
        /// <returns>The int</returns>
        [return: NotNull]
        public static int GetDisplayBounds([NotNull] int displayIndex, out RectangleI rect) => INTERNAL_SDL_GetDisplayBounds(displayIndex.Validate(), out rect);

        /// <summary>
        ///     Sdl the get display dpi using the specified display index
        /// </summary>
        /// <param name="displayIndex">The display index</param>
        /// <param name="dDpi">The d dpi</param>
        /// <param name="hDpi">The h dpi</param>
        /// <param name="vDpi">The v dpi</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GetDisplayDPI", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern int INTERNAL_SDL_GetDisplayDPI([NotNull] int displayIndex, out float dDpi, out float hDpi, out float vDpi);

        /// <summary>
        ///     Gets the display dpi using the specified display index
        /// </summary>
        /// <param name="displayIndex">The display index</param>
        /// <param name="dDpi">The dpi</param>
        /// <param name="hDpi">The dpi</param>
        /// <param name="vDpi">The dpi</param>
        /// <returns>The int</returns>
        [return: NotNull]
        public static int GetDisplayDpi([NotNull] int displayIndex, out float dDpi, out float hDpi, out float vDpi) => INTERNAL_SDL_GetDisplayDPI(displayIndex.Validate(), out dDpi, out hDpi, out vDpi);

        /// <summary>
        ///     Sdl the get display orientation using the specified display index
        /// </summary>
        /// <param name="displayIndex">The display index</param>
        /// <returns>The sdl display orientation</returns>
        [DllImport(NativeLibName, EntryPoint = "SdlDisplayOrientation", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern SdlDisplayOrientation INTERNAL_SDL_GetDisplayOrientation([NotNull] int displayIndex);

        /// <summary>
        ///     Gets the display orientation using the specified display index
        /// </summary>
        /// <param name="displayIndex">The display index</param>
        /// <returns>The sdl display orientation</returns>
        [return: NotNull]
        public static SdlDisplayOrientation GetDisplayOrientation([NotNull] int displayIndex) => INTERNAL_SDL_GetDisplayOrientation(displayIndex.Validate());


        /// <summary>
        ///     Sdl the get display mode using the specified display index
        /// </summary>
        /// <param name="displayIndex">The display index</param>
        /// <param name="modeIndex">The mode index</param>
        /// <param name="mode">The mode</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GetDisplayMode", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern int INTERNAL_SDL_GetDisplayMode([NotNull] int displayIndex, [NotNull] int modeIndex, out SdlDisplayMode mode);

        /// <summary>
        ///     Gets the display mode using the specified display index
        /// </summary>
        /// <param name="displayIndex">The display index</param>
        /// <param name="modeIndex">The mode index</param>
        /// <param name="mode">The mode</param>
        /// <returns>The int</returns>
        [return: NotNull]
        public static int GetDisplayMode([NotNull] int displayIndex, [NotNull] int modeIndex, out SdlDisplayMode mode) => INTERNAL_SDL_GetDisplayMode(displayIndex.Validate(), modeIndex.Validate(), out mode);


        /// <summary>
        ///     Sdl the get display usable bounds using the specified display index
        /// </summary>
        /// <param name="displayIndex">The display index</param>
        /// <param name="rect">The rect</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GetDisplayUsableBounds", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern int INTERNAL_SDL_GetDisplayUsableBounds([NotNull] int displayIndex, out RectangleI rect);

        /// <summary>
        ///     Gets the display usable bounds using the specified display index
        /// </summary>
        /// <param name="displayIndex">The display index</param>
        /// <param name="rect">The rect</param>
        /// <returns>The int</returns>
        [return: NotNull]
        public static int GetDisplayUsableBounds([NotNull] int displayIndex, out RectangleI rect) => INTERNAL_SDL_GetDisplayUsableBounds(displayIndex.Validate(), out rect);


        /// <summary>
        ///     Sdl the get num display modes using the specified display index
        /// </summary>
        /// <param name="displayIndex">The display index</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GetNumDisplayModes", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern int INTERNAL_SDL_GetNumDisplayModes([NotNull] int displayIndex);

        /// <summary>
        ///     Gets the num display modes using the specified display index
        /// </summary>
        /// <param name="displayIndex">The display index</param>
        /// <returns>The int</returns>
        [return: NotNull]
        public static int GetNumDisplayModes([NotNull] int displayIndex) => INTERNAL_SDL_GetNumDisplayModes(displayIndex.Validate());

        /// <summary>
        ///     Sdl the get num video displays
        /// </summary>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GetNumVideoDisplays", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern int INTERNAL_SDL_GetNumVideoDisplays();

        /// <summary>
        ///     Gets the num video displays
        /// </summary>
        /// <returns>The int</returns>
        [return: NotNull]
        public static int GetNumVideoDisplays() => INTERNAL_SDL_GetNumVideoDisplays();

        /// <summary>
        ///     Sdl the get num video drivers
        /// </summary>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GetNumVideoDrivers", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern int INTERNAL_SDL_GetNumVideoDrivers();

        /// <summary>
        ///     Gets the num video drivers
        /// </summary>
        /// <returns>The int</returns>
        [return: NotNull]
        public static int GetNumVideoDrivers() => INTERNAL_SDL_GetNumVideoDrivers().Validate();

        /// <summary>
        ///     Internals the sdl get video driver using the specified index
        /// </summary>
        /// <param name="index">The index</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GetVideoDriver", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern IntPtr INTERNAL_SDL_GetVideoDriver([NotNull] int index);

        /// <summary>
        ///     Sdl the get video driver using the specified index
        /// </summary>
        /// <param name="index">The index</param>
        /// <returns>The string</returns>
        [return: NotNull]
        public static string GetVideoDriver([NotNull] int index) => Utf8Manager.Utf8ToManaged(INTERNAL_SDL_GetVideoDriver(index));

        /// <summary>
        ///     Sdl the get window brightness using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <returns>The float</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GetWindowBrightness", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern float INTERNAL_SDL_GetWindowBrightness([NotNull] IntPtr window);

        /// <summary>
        ///     Gets the window brightness using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <returns>The float</returns>
        [return: NotNull]
        public static float GetWindowBrightness([NotNull] IntPtr window) => INTERNAL_SDL_GetWindowBrightness(window.Validate());

        /// <summary>
        ///     Sdl the set window opacity using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="opacity">The opacity</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_SetWindowOpacity", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern int INTERNAL_SDL_SetWindowOpacity([NotNull] IntPtr window, [NotNull] float opacity);

        /// <summary>
        ///     Sets the window opacity using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="opacity">The opacity</param>
        /// <returns>The int</returns>
        [return: NotNull]
        public static int SetWindowOpacity([NotNull] IntPtr window, [NotNull] float opacity) => INTERNAL_SDL_SetWindowOpacity(window.Validate(), opacity.Validate());

        /// <summary>
        ///     Sdl the get window opacity using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="outOpacity">The out opacity</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_SetWindowOpacity", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern int INTERNAL_SDL_GetWindowOpacity([NotNull] IntPtr window, out float outOpacity);

        /// <summary>
        ///     Gets the window opacity using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="outOpacity">The out opacity</param>
        /// <returns>The int</returns>
        [return: NotNull]
        public static int GetWindowOpacity([NotNull] IntPtr window, out float outOpacity) => INTERNAL_SDL_GetWindowOpacity(window.Validate(), out outOpacity);

        /// <summary>
        ///     Sdl the set window modal for using the specified modal window
        /// </summary>
        /// <param name="modalWindow">The modal window</param>
        /// <param name="parentWindow">The parent window</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_SetWindowModalFor", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern int INTERNAL_SDL_SetWindowModalFor([NotNull] IntPtr modalWindow, [NotNull] IntPtr parentWindow);

        /// <summary>
        ///     Sets the window modal for using the specified modal window
        /// </summary>
        /// <param name="modalWindow">The modal window</param>
        /// <param name="parentWindow">The parent window</param>
        /// <returns>The int</returns>
        [return: NotNull]
        public static int SetWindowModalFor([NotNull] IntPtr modalWindow, [NotNull] IntPtr parentWindow) => INTERNAL_SDL_SetWindowModalFor(modalWindow.Validate(), parentWindow.Validate());

        /// <summary>
        ///     Sdl the set window input focus using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_SetWindowInputFocus", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern int INTERNAL_SDL_SetWindowInputFocus([NotNull] IntPtr window);

        /// <summary>
        ///     Sets the window input focus using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <returns>The int</returns>
        [return: NotNull]
        public static int SetWindowInputFocus([NotNull] IntPtr window) => INTERNAL_SDL_SetWindowInputFocus(window.Validate());

        /// <summary>
        ///     Internals the sdl get window data using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="name">The name</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GetWindowData", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern IntPtr INTERNAL_SDL_GetWindowData([NotNull] IntPtr window, [NotNull] byte[] name);

        /// <summary>
        ///     Sdl the get window data using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="name">The name</param>
        /// <returns>The int ptr</returns>
        [return: NotNull]
        public static IntPtr GetWindowData([NotNull] IntPtr window, [NotNull] string name) => INTERNAL_SDL_GetWindowData(window, Utf8Manager.Utf8Encode(name, new byte[Utf8Manager.Utf8Size(name)], Utf8Manager.Utf8Size(name)));

        /// <summary>
        ///     Sdl the get window display index using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GetWindowDisplayIndex", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern int INTERNAL_SDL_GetWindowDisplayIndex([NotNull] IntPtr window);

        /// <summary>
        ///     Gets the window display index using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <returns>The int</returns>
        [return: NotNull]
        public static int GetWindowDisplayIndex([NotNull] IntPtr window) => INTERNAL_SDL_GetWindowDisplayIndex(window.Validate());

        /// <summary>
        ///     Sdl the get window display mode using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="mode">The mode</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GetWindowDisplayMode", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern int INTERNAL_SDL_GetWindowDisplayMode([NotNull] IntPtr window, out SdlDisplayMode mode);

        /// <summary>
        ///     Gets the window display mode using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="mode">The mode</param>
        /// <returns>The int</returns>
        [return: NotNull]
        public static int GetWindowDisplayMode([NotNull] IntPtr window, out SdlDisplayMode mode) => INTERNAL_SDL_GetWindowDisplayMode(window.Validate(), out mode);

        /// <summary>
        ///     Sdl the get window icc profile using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="mode">The mode</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GetWindowICCProfile", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern IntPtr INTERNAL_SDL_GetWindowICCProfile([NotNull] IntPtr window, out IntPtr mode);

        /// <summary>
        ///     Gets the window icc profile using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="mode">The mode</param>
        /// <returns>The int ptr</returns>
        [return: NotNull]
        public static IntPtr GetWindowIccProfile([NotNull] IntPtr window, out IntPtr mode) => INTERNAL_SDL_GetWindowICCProfile(window.Validate(), out mode);

        /// <summary>
        ///     Sdl the get window flags using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <returns>The uint</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GetWindowFlags", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern uint INTERNAL_SDL_GetWindowFlags([NotNull] IntPtr window);

        /// <summary>
        ///     Gets the window flags using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <returns>The uint</returns>
        [return: NotNull]
        public static uint GetWindowFlags([NotNull] IntPtr window) => INTERNAL_SDL_GetWindowFlags(window.Validate());

        /// <summary>
        ///     Sdl the get window from id using the specified id
        /// </summary>
        /// <param name="id">The id</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GetWindowFromID", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern IntPtr INTERNAL_SDL_GetWindowFromID([NotNull] uint id);

        /// <summary>
        ///     Gets the window from id using the specified id
        /// </summary>
        /// <param name="id">The id</param>
        /// <returns>The int ptr</returns>
        [return: NotNull]
        public static IntPtr GetWindowFromId([NotNull] uint id) => INTERNAL_SDL_GetWindowFromID(id.Validate());

        /// <summary>
        ///     Sdl the get window gamma ramp using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="red">The red</param>
        /// <param name="green">The green</param>
        /// <param name="blue">The blue</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GetWindowGammaRamp", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern int INTERNAL_SDL_GetWindowGammaRamp([NotNull] IntPtr window, [Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U2, SizeConst = 256)] ushort[] red, [Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U2, SizeConst = 256)] ushort[] green,
            [Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U2, SizeConst = 256)] ushort[] blue);

        /// <summary>
        ///     Gets the window gamma ramp using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="red">The red</param>
        /// <param name="green">The green</param>
        /// <param name="blue">The blue</param>
        /// <returns>The int</returns>
        [return: NotNull]
        public static int GetWindowGammaRamp([NotNull] IntPtr window, [Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U2, SizeConst = 256)] ushort[] red, [Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U2, SizeConst = 256)] ushort[] green, [Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U2, SizeConst = 256)] ushort[] blue)
            => INTERNAL_SDL_GetWindowGammaRamp(window.Validate(), red, green, blue);

        /// <summary>
        ///     Sdl the get window grab using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <returns>The sdl bool</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GetWindowGrab", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern SdlBool INTERNAL_SDL_GetWindowGrab([NotNull] IntPtr window);

        /// <summary>
        ///     Gets the window grab using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <returns>The sdl bool</returns>
        [return: NotNull]
        public static SdlBool GetWindowGrab([NotNull] IntPtr window) => INTERNAL_SDL_GetWindowGrab(window.Validate());

        /// <summary>
        ///     Sdl the get window keyboard grab using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <returns>The sdl bool</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GetWindowKeyboardGrab", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern SdlBool INTERNAL_SDL_GetWindowKeyboardGrab([NotNull] IntPtr window);

        /// <summary>
        ///     Gets the window keyboard grab using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <returns>The sdl bool</returns>
        [return: NotNull]
        public static SdlBool GetWindowKeyboardGrab([NotNull] IntPtr window) => INTERNAL_SDL_GetWindowKeyboardGrab(window.Validate());

        /// <summary>
        ///     Sdl the get window mouse grab using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <returns>The sdl bool</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GetWindowMouseGrab", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern SdlBool INTERNAL_SDL_GetWindowMouseGrab([NotNull] IntPtr window);

        /// <summary>
        ///     Gets the window mouse grab using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <returns>The sdl bool</returns>
        [return: NotNull]
        public static SdlBool GetWindowMouseGrab([NotNull] IntPtr window) => INTERNAL_SDL_GetWindowMouseGrab(window.Validate());

        /// <summary>
        ///     Sdl the get window id using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <returns>The uint</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GetWindowID", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern uint INTERNAL_SDL_GetWindowID([NotNull] IntPtr window);

        /// <summary>
        ///     Gets the window id using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <returns>The uint</returns>
        [return: NotNull]
        public static uint GetWindowId([NotNull] IntPtr window) => INTERNAL_SDL_GetWindowID(window.Validate());

        /// <summary>
        ///     Sdl the get window pixel format using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <returns>The uint</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GetWindowPixelFormat", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern uint INTERNAL_SDL_GetWindowPixelFormat([NotNull] IntPtr window);

        /// <summary>
        ///     Gets the window pixel format using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <returns>The uint</returns>
        [return: NotNull]
        public static uint GetWindowPixelFormat([NotNull] IntPtr window) => INTERNAL_SDL_GetWindowPixelFormat(window.Validate());

        /// <summary>
        ///     Sdl the get window maximum size using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="maxW">The max</param>
        /// <param name="maxH">The max</param>
        [DllImport(NativeLibName, EntryPoint = "SDL_GetWindowMaximumSize", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern void INTERNAL_SDL_GetWindowMaximumSize([NotNull] IntPtr window, out int maxW, out int maxH);

        /// <summary>
        ///     Gets the window maximum size using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="maxW">The max</param>
        /// <param name="maxH">The max</param>
        [return: NotNull]
        public static void GetWindowMaximumSize([NotNull] IntPtr window, out int maxW, out int maxH) => INTERNAL_SDL_GetWindowMaximumSize(window.Validate(), out maxW, out maxH);

        /// <summary>
        ///     Sdl the get window minimum size using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="minW">The min</param>
        /// <param name="minH">The min</param>
        [DllImport(NativeLibName, EntryPoint = "SDL_GetWindowMinimumSize", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern void INTERNAL_SDL_GetWindowMinimumSize([NotNull] IntPtr window, out int minW, out int minH);

        /// <summary>
        ///     Gets the window minimum size using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="minW">The min</param>
        /// <param name="minH">The min</param>
        [return: NotNull]
        public static void GetWindowMinimumSize([NotNull] IntPtr window, out int minW, out int minH) => INTERNAL_SDL_GetWindowMinimumSize(window.Validate(), out minW, out minH);

        /// <summary>
        ///     Sdl the get window position using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="x">The </param>
        /// <param name="y">The </param>
        [DllImport(NativeLibName, EntryPoint = "SDL_GetWindowPosition", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern void INTERNAL_SDL_GetWindowPosition([NotNull] IntPtr window, out int x, out int y);

        /// <summary>
        ///     Gets the window position using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="x">The </param>
        /// <param name="y">The </param>
        [return: NotNull]
        public static void GetWindowPosition([NotNull] IntPtr window, out int x, out int y) => INTERNAL_SDL_GetWindowPosition(window.Validate(), out x, out y);


        /// <summary>
        ///     Sdl the get window size using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="w">The </param>
        /// <param name="h">The </param>
        [DllImport(NativeLibName, EntryPoint = "SDL_GetWindowSize", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern void INTERNAL_SDL_GetWindowSize([NotNull] IntPtr window, out int w, out int h);

        /// <summary>
        ///     Gets the window size using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="w">The </param>
        /// <param name="h">The </param>
        [return: NotNull]
        public static void GetWindowSize([NotNull] IntPtr window, out int w, out int h) => INTERNAL_SDL_GetWindowSize(window.Validate(), out w, out h);

        /// <summary>
        ///     Sdl the get window surface using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GetWindowSurface", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern IntPtr INTERNAL_SDL_GetWindowSurface([NotNull] IntPtr window);

        /// <summary>
        ///     Gets the window surface using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <returns>The int ptr</returns>
        [return: NotNull]
        public static IntPtr GetWindowSurface([NotNull] IntPtr window) => INTERNAL_SDL_GetWindowSurface(window.Validate());

        /// <summary>
        ///     Internals the sdl get window title using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GetWindowTitle", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern IntPtr INTERNAL_SDL_GetWindowTitle([NotNull] IntPtr window);

        /// <summary>
        ///     Sdl the get window title using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <returns>The string</returns>
        [return: NotNull]
        public static string GetWindowTitle([NotNull] IntPtr window) => Utf8Manager.Utf8ToManaged(INTERNAL_SDL_GetWindowTitle(window));

        /// <summary>
        ///     Sdl the gl bind texture using the specified texture
        /// </summary>
        /// <param name="texture">The texture</param>
        /// <param name="texW">The tex w</param>
        /// <param name="texH">The tex h</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GL_BindTexture", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern int INTERNAL_SDL_GL_BindTexture([NotNull] IntPtr texture, out float texW, out float texH);

        /// <summary>
        ///     Gls the bind texture using the specified texture
        /// </summary>
        /// <param name="texture">The texture</param>
        /// <param name="texW">The tex</param>
        /// <param name="texH">The tex</param>
        /// <returns>The int</returns>
        [return: NotNull]
        public static int GlBindTexture([NotNull] IntPtr texture, out float texW, out float texH) => INTERNAL_SDL_GL_BindTexture(texture.Validate(), out texW, out texH);

        /// <summary>
        ///     Sdl the gl create context using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GL_CreateContext", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern IntPtr INTERNAL_SDL_GL_CreateContext([NotNull] IntPtr window);

        /// <summary>
        ///     Gls the create context using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <returns>The int ptr</returns>
        [return: NotNull]
        public static IntPtr GlCreateContext([NotNull] IntPtr window) => INTERNAL_SDL_GL_CreateContext(window.Validate());

        /// <summary>
        ///     Sdl the gl delete context using the specified context
        /// </summary>
        /// <param name="context">The context</param>
        [DllImport(NativeLibName, EntryPoint = "SDL_GL_DeleteContext", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern void INTERNAL_SDL_GL_DeleteContext([NotNull] IntPtr context);

        /// <summary>
        ///     Gls the delete context using the specified context
        /// </summary>
        /// <param name="context">The context</param>
        [return: NotNull]
        public static void GlDeleteContext([NotNull] IntPtr context) => INTERNAL_SDL_GL_DeleteContext(context.Validate());

        /// <summary>
        ///     Internals the sdl gl load library using the specified path
        /// </summary>
        /// <param name="path">The path</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GL_LoadLibrary", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern int INTERNAL_SDL_GL_LoadLibrary([NotNull] byte[] path);

        /// <summary>
        ///     Sdl the gl load library using the specified path
        /// </summary>
        /// <param name="path">The path</param>
        /// <returns>The result</returns>
        [return: NotNull]
        public static int GlLoadLibrary([NotNull] string path) => INTERNAL_SDL_GL_LoadLibrary(Utf8Manager.Utf8EncodeHeap(path));

        /// <summary>
        ///     Sdl the gl get proc address using the specified proc
        /// </summary>
        /// <param name="proc">The proc</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GL_GetProcAddress", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern IntPtr INTERNAL_SDL_GL_GetProcAddress([NotNull] byte[] proc);

        /// <summary>
        ///     Sdl the gl get proc address using the specified proc
        /// </summary>
        /// <param name="proc">The proc</param>
        /// <returns>The int ptr</returns>
        [return: NotNull]
        public static IntPtr GlGetProcAddress([NotNull] string proc) => INTERNAL_SDL_GL_GetProcAddress(Utf8Manager.Utf8Encode(proc, new byte[Utf8Manager.Utf8Size(proc)], Utf8Manager.Utf8Size(proc)));

        /// <summary>
        ///     Sdl the gl unload library
        /// </summary>
        [DllImport(NativeLibName, EntryPoint = "SDL_GL_UnloadLibrary", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern void INTERNAL_SDL_GL_UnloadLibrary();

        /// <summary>
        ///     Gls the unload library
        /// </summary>
        [return: NotNull]
        public static void GlUnloadLibrary() => INTERNAL_SDL_GL_UnloadLibrary();

        /// <summary>
        ///     Internals the sdl gl extension supported using the specified extension
        /// </summary>
        /// <param name="extension">The extension</param>
        /// <returns>The sdl bool</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GL_ExtensionSupported", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern SdlBool INTERNAL_SDL_GL_ExtensionSupported([NotNull] byte[] extension);

        /// <summary>
        ///     Sdl the gl extension supported using the specified extension
        /// </summary>
        /// <param name="extension">The extension</param>
        /// <returns>The sdl bool</returns>
        [return: NotNull]
        public static SdlBool GlExtensionSupported([NotNull] string extension) => INTERNAL_SDL_GL_ExtensionSupported(Utf8Manager.Utf8Encode(extension, new byte[Utf8Manager.Utf8Size(extension)], Utf8Manager.Utf8Size(extension)));

        /// <summary>
        ///     Sdl the gl reset attributes
        /// </summary>
        [DllImport(NativeLibName, EntryPoint = "SDL_GL_ResetAttributes", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern void INTERNAL_SDL_GL_ResetAttributes();

        /// <summary>
        ///     Gls the reset attributes
        /// </summary>
        [return: NotNull]
        public static void GlResetAttributes() => INTERNAL_SDL_GL_ResetAttributes();

        /// <summary>
        ///     Sdl the gl get attribute using the specified attr
        /// </summary>
        /// <param name="attr">The attr</param>
        /// <param name="value">The value</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GL_GetAttribute", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern int INTERNAL_SDL_GL_GetAttribute([NotNull] SdlGlAttr attr, out int value);

        /// <summary>
        ///     Gls the get attribute using the specified attr
        /// </summary>
        /// <param name="attr">The attr</param>
        /// <param name="value">The value</param>
        /// <returns>The int</returns>
        [return: NotNull]
        public static int GlGetAttribute([NotNull] SdlGlAttr attr, out int value) => INTERNAL_SDL_GL_GetAttribute(attr.Validate(), out value);

        /// <summary>
        ///     Sdl the gl get swap interval
        /// </summary>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GL_GetSwapInterval", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern int INTERNAL_SDL_GL_GetSwapInterval();

        /// <summary>
        ///     Gls the get swap interval
        /// </summary>
        /// <returns>The int</returns>
        [return: NotNull]
        public static int GlGetSwapInterval() => INTERNAL_SDL_GL_GetSwapInterval();

        /// <summary>
        ///     Sdl the gl make current using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="context">The context</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GL_MakeCurrent", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern int INTERNAL_SDL_GL_MakeCurrent([NotNull] IntPtr window, [NotNull] IntPtr context);

        /// <summary>
        ///     Gls the make current using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="context">The context</param>
        /// <returns>The int</returns>
        [return: NotNull]
        public static int GlMakeCurrent([NotNull] IntPtr window, [NotNull] IntPtr context) => INTERNAL_SDL_GL_MakeCurrent(window.Validate(), context.Validate());


        /// <summary>
        ///     Sdl the gl get current window
        /// </summary>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GL_GetCurrentWindow", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern IntPtr INTERNAL_SDL_GL_GetCurrentWindow();

        /// <summary>
        ///     Gls the get current window
        /// </summary>
        /// <returns>The int ptr</returns>
        [return: NotNull]
        public static IntPtr GlGetCurrentWindow() => INTERNAL_SDL_GL_GetCurrentWindow().Validate();

        /// <summary>
        ///     Sdl the gl get current context
        /// </summary>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GL_GetCurrentContext", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern IntPtr INTERNAL_SDL_GL_GetCurrentContext();

        /// <summary>
        ///     Gls the get current context
        /// </summary>
        /// <returns>The int ptr</returns>
        [return: NotNull]
        public static IntPtr GlGetCurrentContext() => INTERNAL_SDL_GL_GetCurrentContext().Validate();

        /// <summary>
        ///     Sdl the gl get drawable size using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="w">The </param>
        /// <param name="h">The </param>
        [DllImport(NativeLibName, EntryPoint = "SDL_GL_GetDrawableSize", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern void INTERNAL_SDL_GL_GetDrawableSize([NotNull] IntPtr window, out int w, out int h);

        /// <summary>
        ///     Gls the get drawable size using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="w">The </param>
        /// <param name="h">The </param>
        [return: NotNull]
        public static void GlGetDrawableSize([NotNull] IntPtr window, out int w, out int h) => INTERNAL_SDL_GL_GetDrawableSize(window.Validate(), out w, out h);

        /// <summary>
        ///     Sdl the gl set attribute using the specified attr
        /// </summary>
        /// <param name="attr">The attr</param>
        /// <param name="value">The value</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GL_SetAttribute", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern int INTERNAL_SDL_GL_SetAttribute([NotNull] SdlGlAttr attr, [NotNull] int value);

        /// <summary>
        ///     Gls the set attribute using the specified attr
        /// </summary>
        /// <param name="attr">The attr</param>
        /// <param name="value">The value</param>
        /// <returns>The int</returns>
        [return: NotNull]
        public static int GlSetAttributeByInt([NotNull] SdlGlAttr attr, [NotNull] int value) => INTERNAL_SDL_GL_SetAttribute(attr.Validate(), value.Validate());

        /// <summary>
        ///     Sdl the gl set attribute using the specified attr
        /// </summary>
        /// <param name="attr">The attr</param>
        /// <param name="profile">The profile</param>
        /// <returns>The int</returns>
        [return: NotNull]
        public static int GlSetAttributeByProfile([NotNull] SdlGlAttr attr, [NotNull] SdlGlProfile profile) => INTERNAL_SDL_GL_SetAttribute(attr.Validate(), (int) profile.Validate());

        /// <summary>
        ///     Sdl the gl set swap interval using the specified interval
        /// </summary>
        /// <param name="interval">The interval</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GL_SetSwapInterval", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern int INTERNAL_SDL_GL_SetSwapInterval([NotNull] int interval);

        /// <summary>
        ///     Gls the set swap interval using the specified interval
        /// </summary>
        /// <param name="interval">The interval</param>
        /// <returns>The int</returns>
        [return: NotNull]
        public static int GlSetSwapInterval([NotNull] int interval) => INTERNAL_SDL_GL_SetSwapInterval(interval.Validate());

        /// <summary>
        ///     Sdl the gl swap window using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        [DllImport(NativeLibName, EntryPoint = "SDL_GL_SwapWindow", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern void INTERNAL_SDL_GL_SwapWindow([NotNull] IntPtr window);

        /// <summary>
        ///     Gls the swap window using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        [return: NotNull]
        public static void GlSwapWindow([NotNull] IntPtr window) => INTERNAL_SDL_GL_SwapWindow(window.Validate());

        /// <summary>
        ///     Sdl the gl unbind texture using the specified texture
        /// </summary>
        /// <param name="texture">The texture</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GL_UnbindTexture", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern int INTERNAL_SDL_GL_UnbindTexture([NotNull] IntPtr texture);

        /// <summary>
        ///     Gls the unbind texture using the specified texture
        /// </summary>
        /// <param name="texture">The texture</param>
        /// <returns>The int</returns>
        [return: NotNull]
        public static int GlUnbindTexture([NotNull] IntPtr texture) => INTERNAL_SDL_GL_UnbindTexture(texture.Validate());

        /// <summary>
        ///     Sdl the hide window using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        [DllImport(NativeLibName, EntryPoint = "SDL_HideWindow", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern void INTERNAL_SDL_HideWindow([NotNull] IntPtr window);

        /// <summary>
        ///     Hides the window using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        [return: NotNull]
        public static void HideWindow([NotNull] IntPtr window) => INTERNAL_SDL_HideWindow(window.Validate());

        /// <summary>
        ///     Sdl the is screen saver enabled
        /// </summary>
        /// <returns>The sdl bool</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_IsScreenSaverEnabled", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern SdlBool INTERNAL_SDL_IsScreenSaverEnabled();

        /// <summary>
        ///     Is the screen saver enabled
        /// </summary>
        /// <returns>The sdl bool</returns>
        [return: NotNull]
        public static SdlBool IsScreenSaverEnabled() => INTERNAL_SDL_IsScreenSaverEnabled();

        /// <summary>
        ///     Sdl the maximize window using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        [DllImport(NativeLibName, EntryPoint = "SDL_MaximizeWindow", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern void INTERNAL_SDL_MaximizeWindow([NotNull] IntPtr window);

        /// <summary>
        ///     Maximizes the window using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        [return: NotNull]
        public static void MaximizeWindow([NotNull] IntPtr window) => INTERNAL_SDL_MaximizeWindow(window.Validate());

        /// <summary>
        ///     Sdl the minimize window using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        [DllImport(NativeLibName, EntryPoint = "SDL_MinimizeWindow", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern void INTERNAL_SDL_MinimizeWindow([NotNull] IntPtr window);

        /// <summary>
        ///     Minimizes the window using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        [return: NotNull]
        public static void MinimizeWindow([NotNull] IntPtr window) => INTERNAL_SDL_MinimizeWindow(window.Validate());

        /// <summary>
        ///     Sdl the raise window using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        [DllImport(NativeLibName, EntryPoint = "SDL_RaiseWindow", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern void INTERNAL_SDL_RaiseWindow([NotNull] IntPtr window);

        /// <summary>
        ///     Raises the window using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        [return: NotNull]
        public static void RaiseWindow([NotNull] IntPtr window) => INTERNAL_SDL_RaiseWindow(window.Validate());

        /// <summary>
        ///     Sdl the restore window using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        [DllImport(NativeLibName, EntryPoint = "SDL_RestoreWindow", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern void INTERNAL_SDL_RestoreWindow([NotNull] IntPtr window);

        /// <summary>
        ///     Restores the window using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        [return: NotNull]
        public static void RestoreWindow([NotNull] IntPtr window) => INTERNAL_SDL_RestoreWindow(window.Validate());

        /// <summary>
        ///     Sdl the set window brightness using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="brightness">The brightness</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_SetWindowBrightness", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern int INTERNAL_SDL_SetWindowBrightness([NotNull] IntPtr window, float brightness);

        /// <summary>
        ///     Sets the window brightness using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="brightness">The brightness</param>
        /// <returns>The int</returns>
        [return: NotNull]
        public static int SetWindowBrightness([NotNull] IntPtr window, float brightness) => INTERNAL_SDL_SetWindowBrightness(window.Validate(), brightness.Validate());

        /// <summary>
        ///     Internals the sdl set window data using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="name">The name</param>
        /// <param name="userdata">The userdata</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_SetWindowData", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern IntPtr INTERNAL_SDL_SetWindowData([NotNull] IntPtr window, [NotNull] byte[] name, [NotNull] IntPtr userdata);

        /// <summary>
        ///     Sdl the set window data using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="name">The name</param>
        /// <param name="userdata">The userdata</param>
        /// <returns>The int ptr</returns>
        [return: NotNull]
        public static IntPtr SetWindowData([NotNull] IntPtr window, [NotNull] string name, [NotNull] IntPtr userdata) => INTERNAL_SDL_SetWindowData(window, Utf8Manager.Utf8Encode(name, new byte[Utf8Manager.Utf8Size(name)], Utf8Manager.Utf8Size(name)), userdata);

        /// <summary>
        ///     Sdl the set window display mode using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="mode">The mode</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_SetWindowDisplayMode", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern int INTERNAL_SDL_SetWindowDisplayMode([NotNull] IntPtr window, ref SdlDisplayMode mode);

        /// <summary>
        ///     Sets the window display mode using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="mode">The mode</param>
        /// <returns>The int</returns>
        [return: NotNull]
        public static int SetWindowDisplayMode([NotNull] IntPtr window, ref SdlDisplayMode mode) => INTERNAL_SDL_SetWindowDisplayMode(window.Validate(), ref mode);

        /// <summary>
        ///     Sdl the set window display mode using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="mode">The mode</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_SetWindowDisplayMode", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern int INTERNAL_SDL_SetWindowDisplayMode([NotNull] IntPtr window, [NotNull] IntPtr mode);

        /// <summary>
        ///     Sets the window display mode using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="mode">The mode</param>
        /// <returns>The int</returns>
        [return: NotNull]
        public static int SetWindowDisplayMode([NotNull] IntPtr window, [NotNull] IntPtr mode) => INTERNAL_SDL_SetWindowDisplayMode(window.Validate(), mode.Validate());

        /// <summary>
        ///     Sdl the set window fullscreen using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="flags">The flags</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_SetWindowFullscreen", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern int INTERNAL_SDL_SetWindowFullscreen([NotNull] IntPtr window, [NotNull] uint flags);

        /// <summary>
        ///     Sets the window fullscreen using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="flags">The flags</param>
        /// <returns>The int</returns>
        [return: NotNull]
        public static int SetWindowFullscreen([NotNull] IntPtr window, [NotNull] uint flags) => INTERNAL_SDL_SetWindowFullscreen(window.Validate(), flags.Validate());

        /// <summary>
        ///     Sdl the set window gamma ramp using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="red">The red</param>
        /// <param name="green">The green</param>
        /// <param name="blue">The blue</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_SetWindowGammaRamp", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern int INTERNAL_SDL_SetWindowGammaRamp([NotNull] IntPtr window, [In, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U2, SizeConst = 256)] ushort[] red, [In, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U2, SizeConst = 256)] ushort[] green,
            [In, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U2, SizeConst = 256)] ushort[] blue);

        /// <summary>
        ///     Sets the window gamma ramp using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="red">The red</param>
        /// <param name="green">The green</param>
        /// <param name="blue">The blue</param>
        /// <returns>The int</returns>
        [return: NotNull]
        public static int SetWindowGammaRamp([NotNull] IntPtr window, [In, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U2, SizeConst = 256)] ushort[] red, [In, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U2, SizeConst = 256)] ushort[] green, [In, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U2, SizeConst = 256)] ushort[] blue)
            => INTERNAL_SDL_SetWindowGammaRamp(window.Validate(), red.Validate(), green.Validate(), blue.Validate());

        /// <summary>
        ///     Sdl the set window grab using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="grabbed">The grabbed</param>
        [DllImport(NativeLibName, EntryPoint = "SDL_SetWindowGrab", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern void INTERNAL_SDL_SetWindowGrab([NotNull] IntPtr window, [NotNull] SdlBool grabbed);

        /// <summary>
        ///     Sets the window grab using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="grabbed">The grabbed</param>
        [return: NotNull]
        public static void SetWindowGrab([NotNull] IntPtr window, [NotNull] SdlBool grabbed) => INTERNAL_SDL_SetWindowGrab(window.Validate(), grabbed.Validate());

        /// <summary>
        ///     Sdl the set window keyboard grab using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="grabbed">The grabbed</param>
        [DllImport(NativeLibName, EntryPoint = "SDL_SetWindowKeyboardGrab", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern void INTERNAL_SDL_SetWindowKeyboardGrab([NotNull] IntPtr window, [NotNull] SdlBool grabbed);

        /// <summary>
        ///     Sets the window keyboard grab using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="grabbed">The grabbed</param>
        [return: NotNull]
        public static void SetWindowKeyboardGrab([NotNull] IntPtr window, [NotNull] SdlBool grabbed) => INTERNAL_SDL_SetWindowKeyboardGrab(window.Validate(), grabbed);

        /// <summary>
        ///     Sdl the set window mouse grab using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="grabbed">The grabbed</param>
        [DllImport(NativeLibName, EntryPoint = "SDL_SetWindowMouseGrab", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern void INTERNAL_SDL_SetWindowMouseGrab([NotNull] IntPtr window, SdlBool grabbed);

        /// <summary>
        ///     Sets the window mouse grab using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="grabbed">The grabbed</param>
        [return: NotNull]
        public static void SetWindowMouseGrab([NotNull] IntPtr window, SdlBool grabbed) => INTERNAL_SDL_SetWindowMouseGrab(window.Validate(), grabbed);

        /// <summary>
        ///     Sdl the set window icon using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="icon">The icon</param>
        [DllImport(NativeLibName, EntryPoint = "SDL_SetWindowIcon", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern void INTERNAL_SDL_SetWindowIcon([NotNull] IntPtr window, [NotNull] IntPtr icon);

        /// <summary>
        ///     Sets the window icon using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="icon">The icon</param>
        [return: NotNull]
        public static void SetWindowIcon([NotNull] IntPtr window, [NotNull] IntPtr icon) => INTERNAL_SDL_SetWindowIcon(window.Validate(), icon.Validate());

        /// <summary>
        ///     Sdl the set window maximum size using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="maxW">The max</param>
        /// <param name="maxH">The max</param>
        [DllImport(NativeLibName, EntryPoint = "SDL_SetWindowMaximumSize", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern void INTERNAL_SDL_SetWindowMaximumSize([NotNull] IntPtr window, [NotNull] int maxW, [NotNull] int maxH);

        /// <summary>
        ///     Sets the window maximum size using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="maxW">The max</param>
        /// <param name="maxH">The max</param>
        [return: NotNull]
        public static void SetWindowMaximumSize([NotNull] IntPtr window, [NotNull] int maxW, [NotNull] int maxH) => INTERNAL_SDL_SetWindowMaximumSize(window.Validate(), maxW, maxH);

        /// <summary>
        ///     Sdl the set window minimum size using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="minW">The min</param>
        /// <param name="minH">The min</param>
        [DllImport(NativeLibName, EntryPoint = "SDL_SetWindowMinimumSize", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern void INTERNAL_SDL_SetWindowMinimumSize([NotNull] IntPtr window, [NotNull] int minW, [NotNull] int minH);

        /// <summary>
        ///     Sets the window minimum size using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="minW">The min</param>
        /// <param name="minH">The min</param>
        [return: NotNull]
        public static void SetWindowMinimumSize([NotNull] IntPtr window, [NotNull] int minW, [NotNull] int minH) => INTERNAL_SDL_SetWindowMinimumSize(window.Validate(), minW, minH);

        /// <summary>
        ///     Sdl the set window position using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="x">The </param>
        /// <param name="y">The </param>
        [DllImport(NativeLibName, EntryPoint = "SDL_SetWindowPosition", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern void SDL_SetWindowPosition([NotNull] IntPtr window, [NotNull] int x, [NotNull] int y);

        /// <summary>
        ///     Sets the window position using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="x">The </param>
        /// <param name="y">The </param>
        [return: NotNull]
        public static void SetWindowPosition([NotNull] IntPtr window, [NotNull] int x, [NotNull] int y) => SDL_SetWindowPosition(window.Validate(), x, y);

        /// <summary>
        ///     Sdl the set window size using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="w">The </param>
        /// <param name="h">The </param>
        [DllImport(NativeLibName, EntryPoint = "SDL_SetWindowSize", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern void INTERNAL_SDL_SetWindowSize([NotNull] IntPtr window, [NotNull] int w, [NotNull] int h);

        /// <summary>
        ///     Sets the window size using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="w">The </param>
        /// <param name="h">The </param>
        [return: NotNull]
        public static void SetWindowSize([NotNull] IntPtr window, [NotNull] int w, [NotNull] int h) => INTERNAL_SDL_SetWindowSize(window.Validate(), w, h);

        /// <summary>
        ///     Sdl the set window bordered using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="bordered">The bordered</param>
        [DllImport(NativeLibName, EntryPoint = "SDL_SetWindowBordered", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern void INTERNAL_SDL_SetWindowBordered([NotNull] IntPtr window, SdlBool bordered);

        /// <summary>
        ///     Sets the window bordered using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="bordered">The bordered</param>
        [return: NotNull]
        public static void SetWindowBordered([NotNull] IntPtr window, SdlBool bordered) => INTERNAL_SDL_SetWindowBordered(window.Validate(), bordered);

        /// <summary>
        ///     Sdl the get window borders size using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="top">The top</param>
        /// <param name="left">The left</param>
        /// <param name="bottom">The bottom</param>
        /// <param name="right">The right</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_SetWindowBordered", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern int INTERNAL_SDL_GetWindowBordersSize([NotNull] IntPtr window, out int top, out int left, out int bottom, out int right);

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
        public static int GetWindowBordersSize([NotNull] IntPtr window, out int top, out int left, out int bottom, out int right) => INTERNAL_SDL_GetWindowBordersSize(window.Validate(), out top, out left, out bottom, out right);

        /// <summary>
        ///     Sdl the set window resizable using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="resizable">The resizable</param>
        [DllImport(NativeLibName, EntryPoint = "SDL_SetWindowResizable", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern void INTERNAL_SDL_SetWindowResizable([NotNull] IntPtr window, SdlBool resizable);

        /// <summary>
        ///     Sets the window resizable using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="resizable">The resizable</param>
        [return: NotNull]
        public static void SetWindowResizable([NotNull] IntPtr window, SdlBool resizable) => INTERNAL_SDL_SetWindowResizable(window.Validate(), resizable);

        /// <summary>
        ///     Sdl the set window always on top using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="onTop">The on top</param>
        [DllImport(NativeLibName, EntryPoint = "SDL_SetWindowAlwaysOnTop", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern void INTERNAL_SDL_SetWindowAlwaysOnTop([NotNull] IntPtr window, SdlBool onTop);

        /// <summary>
        ///     Sets the window always on top using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="onTop">The on top</param>
        [return: NotNull]
        public static void SetWindowAlwaysOnTop([NotNull] IntPtr window, SdlBool onTop) => INTERNAL_SDL_SetWindowAlwaysOnTop(window.Validate(), onTop);

        /// <summary>
        ///     Internals the sdl set window title using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="title">The title</param>
        [DllImport(NativeLibName, EntryPoint = "SDL_SetWindowTitle", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern void INTERNAL_SDL_SetWindowTitle([NotNull] IntPtr window, [NotNull] byte[] title);

        /// <summary>
        ///     Sdl the set window title using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="title">The title</param>
        [return: NotNull]
        public static void SetWindowTitle([NotNull] IntPtr window, [NotNull] string title) => INTERNAL_SDL_SetWindowTitle(window, Utf8Manager.Utf8Encode(title, new byte[Utf8Manager.Utf8Size(title)], Utf8Manager.Utf8Size(title)));

        /// <summary>
        ///     Sdl the show window using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        [DllImport(NativeLibName, EntryPoint = "SDL_ShowWindow", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern void INTERNAL_SDL_ShowWindow([NotNull] IntPtr window);

        /// <summary>
        ///     Shows the window using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        [return: NotNull]
        public static void ShowWindow([NotNull] IntPtr window) => INTERNAL_SDL_ShowWindow(window.Validate());

        /// <summary>
        ///     Sdl the update window surface using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_UpdateWindowSurface", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern int INTERNAL_SDL_UpdateWindowSurface([NotNull] IntPtr window);

        /// <summary>
        ///     Updates the window surface using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <returns>The int</returns>
        [return: NotNull]
        public static int UpdateWindowSurface([NotNull] IntPtr window) => INTERNAL_SDL_UpdateWindowSurface(window.Validate());

        /// <summary>
        ///     Sdl the update window surface rects using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="rects">The rects</param>
        /// <param name="numRects">The num rects</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_UpdateWindowSurfaceRects", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern int INTERNAL_SDL_UpdateWindowSurfaceRects([NotNull] IntPtr window, [In] RectangleI[] rects, [NotNull] int numRects);

        /// <summary>
        ///     Updates the window surface rects using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="rects">The rects</param>
        /// <param name="numRects">The num rects</param>
        /// <returns>The int</returns>
        [return: NotNull]
        public static int UpdateWindowSurfaceRects([NotNull] IntPtr window, [In] RectangleI[] rects, [NotNull] int numRects) => INTERNAL_SDL_UpdateWindowSurfaceRects(window.Validate(), rects, numRects);

        /// <summary>
        ///     Internals the sdl video init using the specified driver name
        /// </summary>
        /// <param name="driverName">The driver name</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_VideoInit", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern int INTERNAL_SDL_VideoInit([NotNull] byte[] driverName);

        /// <summary>
        ///     Sdl the video init using the specified driver name
        /// </summary>
        /// <param name="driverName">The driver name</param>
        /// <returns>The int</returns>
        [return: NotNull]
        public static int VideoInit([NotNull] string driverName) => INTERNAL_SDL_VideoInit(Utf8Manager.Utf8Encode(driverName, new byte[Utf8Manager.Utf8Size(driverName)], Utf8Manager.Utf8Size(driverName)));

        /// <summary>
        ///     Sdl the video quit
        /// </summary>
        [DllImport(NativeLibName, EntryPoint = "SDL_VideoQuit", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern void INTERNAL_SDL_VideoQuit();

        /// <summary>
        ///     Video the quit
        /// </summary>
        [return: NotNull]
        public static void VideoQuit() => INTERNAL_SDL_VideoQuit();

        /// <summary>
        ///     Sdl the set window hit test using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="callback">The callback</param>
        /// <param name="callbackData">The callback data</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_SetWindowHitTest", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern int INTERNAL_SDL_SetWindowHitTest([NotNull] IntPtr window, SdlHitTest callback, [NotNull] IntPtr callbackData);

        /// <summary>
        ///     Sets the window hit test using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="callback">The callback</param>
        /// <param name="callbackData">The callback data</param>
        /// <returns>The int</returns>
        [return: NotNull]
        public static int SetWindowHitTest([NotNull] IntPtr window, SdlHitTest callback, [NotNull] IntPtr callbackData) => INTERNAL_SDL_SetWindowHitTest(window.Validate(), callback, callbackData);

        /// <summary>
        ///     Sdl the get grabbed window
        /// </summary>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GetGrabbedWindow", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern IntPtr INTERNAL_SDL_GetGrabbedWindow();

        /// <summary>
        ///     Gets the grabbed window
        /// </summary>
        /// <returns>The int ptr</returns>
        [return: NotNull]
        public static IntPtr GetGrabbedWindow() => INTERNAL_SDL_GetGrabbedWindow().Validate();

        /// <summary>
        ///     Sdl the set window mouse rect using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="rect">The rect</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_SetWindowMouseRect", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern int INTERNAL_SDL_SetWindowMouseRect([NotNull] IntPtr window, ref RectangleI rect);

        /// <summary>
        ///     Sets the window mouse rect using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="rect">The rect</param>
        /// <returns>The int</returns>
        [return: NotNull]
        public static int SetWindowMouseRect([NotNull] IntPtr window, ref RectangleI rect) => INTERNAL_SDL_SetWindowMouseRect(window.Validate(), ref rect);

        /// <summary>
        ///     Sdl the set window mouse rect using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="rect">The rect</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_SetWindowMouseRect", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern int INTERNAL_SDL_SetWindowMouseRect([NotNull] IntPtr window, [NotNull] IntPtr rect);

        /// <summary>
        ///     Sets the window mouse rect using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="rect">The rect</param>
        /// <returns>The int</returns>
        [return: NotNull]
        public static int SetWindowMouseRect([NotNull] IntPtr window, [NotNull] IntPtr rect) => INTERNAL_SDL_SetWindowMouseRect(window.Validate(), rect);

        /// <summary>
        ///     Sdl the get window mouse rect using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GetWindowMouseRect", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern IntPtr INTERNAL_SDL_GetWindowMouseRect([NotNull] IntPtr window);

        /// <summary>
        ///     Gets the window mouse rect using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <returns>The int ptr</returns>
        [return: NotNull]
        public static IntPtr GetWindowMouseRect([NotNull] IntPtr window) => INTERNAL_SDL_GetWindowMouseRect(window.Validate());

        /// <summary>
        ///     Sdl the flash window using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="operation">The operation</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_FlashWindow", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern int INTERNAL_SDL_FlashWindow([NotNull] IntPtr window, SdlFlashOperation operation);

        /// <summary>
        ///     Flashes the window using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="operation">The operation</param>
        /// <returns>The int</returns>
        [return: NotNull]
        public static int FlashWindow([NotNull] IntPtr window, SdlFlashOperation operation) => INTERNAL_SDL_FlashWindow(window.Validate(), operation);

        /// <summary>
        ///     Sdl the compose custom blend mode using the specified src color factor
        /// </summary>
        /// <param name="srcColorFactor">The src color factor</param>
        /// <param name="dstColorFactor">The dst color factor</param>
        /// <param name="colorOperation">The color operation</param>
        /// <param name="srcAlphaFactor">The src alpha factor</param>
        /// <param name="dstAlphaFactor">The dst alpha factor</param>
        /// <param name="alphaOperation">The alpha operation</param>
        /// <returns>The sdl blend mode</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_ComposeCustomBlendMode", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern SdlBlendMode INTERNAL_SDL_ComposeCustomBlendMode([NotNull] SdlBlendFactor srcColorFactor, [NotNull] SdlBlendFactor dstColorFactor, [NotNull] SdlBlendOperation colorOperation, [NotNull] SdlBlendFactor srcAlphaFactor, [NotNull] SdlBlendFactor dstAlphaFactor, [NotNull] SdlBlendOperation alphaOperation);

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
        public static SdlBlendMode ComposeCustomBlendMode([NotNull] SdlBlendFactor srcColorFactor, [NotNull] SdlBlendFactor dstColorFactor, [NotNull] SdlBlendOperation colorOperation, [NotNull] SdlBlendFactor srcAlphaFactor, [NotNull] SdlBlendFactor dstAlphaFactor, [NotNull] SdlBlendOperation alphaOperation)
            => INTERNAL_SDL_ComposeCustomBlendMode(srcColorFactor.Validate(), dstColorFactor.Validate(), colorOperation.Validate(), srcAlphaFactor.Validate(), dstAlphaFactor.Validate(), alphaOperation.Validate());

        /// <summary>
        ///     Internals the sdl vulkan load library using the specified path
        /// </summary>
        /// <param name="path">The path</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_Vulkan_LoadLibrary", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern int INTERNAL_SDL_Vulkan_LoadLibrary([NotNull] byte[] path);

        /// <summary>
        ///     Sdl the vulkan load library using the specified path
        /// </summary>
        /// <param name="path">The path</param>
        /// <returns>The result</returns>
        public static int VulkanLoadLibrary([NotNull] string path) => INTERNAL_SDL_Vulkan_LoadLibrary(Utf8Manager.Utf8EncodeHeap(path.Validate()));

        /// <summary>
        ///     Sdl the vulkan get vk get instance proc addr
        /// </summary>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_Vulkan_GetVkGetInstanceProcAddr", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern IntPtr INTERNAL_SDL_Vulkan_GetVkGetInstanceProcAddr();

        /// <summary>
        ///     Vulkan the get vk get instance proc addr
        /// </summary>
        /// <returns>The int ptr</returns>
        [return: NotNull]
        public static IntPtr VulkanGetVkGetInstanceProcAddr() => INTERNAL_SDL_Vulkan_GetVkGetInstanceProcAddr().Validate();

        /// <summary>
        ///     Sdl the vulkan unload library
        /// </summary>
        [DllImport(NativeLibName, EntryPoint = "SDL_Vulkan_UnloadLibrary", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern void INTERNAL_SDL_Vulkan_UnloadLibrary();

        /// <summary>
        ///     Vulkan the unload library
        /// </summary>
        [return: NotNull]
        public static void VulkanUnloadLibrary() => INTERNAL_SDL_Vulkan_UnloadLibrary();

        /// <summary>
        ///     Sdl the vulkan get instance extensions using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="pCount">The count</param>
        /// <param name="pNames">The names</param>
        /// <returns>The sdl bool</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_Vulkan_GetInstanceExtensions", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern SdlBool INTERNAL_SDL_Vulkan_GetInstanceExtensions([NotNull] IntPtr window, out uint pCount, [NotNull] IntPtr pNames);

        /// <summary>
        ///     Vulkan the get instance extensions using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="pCount">The count</param>
        /// <param name="pNames">The names</param>
        /// <returns>The sdl bool</returns>
        [return: NotNull]
        public static SdlBool VulkanGetInstanceExtensions([NotNull] IntPtr window, out uint pCount, [NotNull] IntPtr pNames) => INTERNAL_SDL_Vulkan_GetInstanceExtensions(window.Validate(), out pCount, pNames.Validate());

        /// <summary>
        ///     Sdl the vulkan get instance extensions using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="pCount">The count</param>
        /// <param name="pNames">The names</param>
        /// <returns>The sdl bool</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_Vulkan_GetInstanceExtensions", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern SdlBool INTERNAL_SDL_Vulkan_GetInstanceExtensions([NotNull] IntPtr window, out uint pCount, [NotNull] IntPtr[] pNames);

        /// <summary>
        ///     Vulkan the get instance extensions using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="pCount">The count</param>
        /// <param name="pNames">The names</param>
        /// <returns>The sdl bool</returns>
        [return: NotNull]
        public static SdlBool VulkanGetInstanceExtensions([NotNull] IntPtr window, out uint pCount, [NotNull] IntPtr[] pNames) => INTERNAL_SDL_Vulkan_GetInstanceExtensions(window.Validate(), out pCount, pNames.Validate());

        /// <summary>
        ///     Sdl the vulkan create surface using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="instance">The instance</param>
        /// <param name="surface">The surface</param>
        /// <returns>The sdl bool</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_Vulkan_CreateSurface", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern SdlBool INTERNAL_SDL_Vulkan_CreateSurface([NotNull] IntPtr window, [NotNull] IntPtr instance, out ulong surface);

        /// <summary>
        ///     Vulkan the create surface using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="instance">The instance</param>
        /// <param name="surface">The surface</param>
        /// <returns>The sdl bool</returns>
        [return: NotNull]
        public static SdlBool VulkanCreateSurface([NotNull] IntPtr window, [NotNull] IntPtr instance, out ulong surface) => INTERNAL_SDL_Vulkan_CreateSurface(window.Validate(), instance.Validate(), out surface);

        /// <summary>
        ///     Sdl the vulkan get drawable size using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="w">The </param>
        /// <param name="h">The </param>
        [DllImport(NativeLibName, EntryPoint = "SDL_Vulkan_GetDrawableSize", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern void INTERNAL_SDL_Vulkan_GetDrawableSize([NotNull] IntPtr window, out int w, out int h);

        /// <summary>
        ///     Vulkan the get drawable size using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="w">The </param>
        /// <param name="h">The </param>
        [return: NotNull]
        public static void VulkanGetDrawableSize([NotNull] IntPtr window, out int w, out int h) => INTERNAL_SDL_Vulkan_GetDrawableSize(window.Validate(), out w, out h);

        /// <summary>
        ///     Sdl the metal create view using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_Metal_CreateView", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern IntPtr INTERNAL_SDL_Metal_CreateView([NotNull] IntPtr window);

        /// <summary>
        ///     Metals the create view using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <returns>The int ptr</returns>
        [return: NotNull]
        public static IntPtr MetalCreateView([NotNull] IntPtr window) => INTERNAL_SDL_Metal_CreateView(window.Validate());

        /// <summary>
        ///     Sdl the metal destroy view using the specified view
        /// </summary>
        /// <param name="view">The view</param>
        [DllImport(NativeLibName, EntryPoint = "SDL_Metal_DestroyView", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern void INTERNAL_SDL_Metal_DestroyView([NotNull] IntPtr view);

        /// <summary>
        ///     Metals the destroy view using the specified view
        /// </summary>
        /// <param name="view">The view</param>
        [return: NotNull]
        public static void MetalDestroyView([NotNull] IntPtr view) => INTERNAL_SDL_Metal_DestroyView(view.Validate());

        /// <summary>
        ///     Sdl the metal get layer using the specified view
        /// </summary>
        /// <param name="view">The view</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_Metal_GetLayer", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern IntPtr INTERNAL_SDL_Metal_GetLayer([NotNull] IntPtr view);

        /// <summary>
        ///     Metals the get layer using the specified view
        /// </summary>
        /// <param name="view">The view</param>
        /// <returns>The int ptr</returns>
        [return: NotNull]
        public static IntPtr MetalGetLayer([NotNull] IntPtr view) => INTERNAL_SDL_Metal_GetLayer(view.Validate());

        /// <summary>
        ///     Sdl the metal get drawable size using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="w">The </param>
        /// <param name="h">The </param>
        [DllImport(NativeLibName, EntryPoint = "SDL_Metal_GetDrawableSize", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern void INTERNAL_SDL_Metal_GetDrawableSize([NotNull] IntPtr window, out int w, out int h);

        /// <summary>
        ///     Metals the get drawable size using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="w">The </param>
        /// <param name="h">The </param>
        [return: NotNull]
        public static void MetalGetDrawableSize([NotNull] IntPtr window, out int w, out int h) => INTERNAL_SDL_Metal_GetDrawableSize(window.Validate(), out w, out h);

        /// <summary>
        ///     Sdl the create renderer using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="index">The index</param>
        /// <param name="flags">The flags</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_CreateRenderer", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern IntPtr INTERNAL_SDL_CreateRenderer([NotNull] IntPtr window, [NotNull] int index, SdlRendererFlags flags);

        /// <summary>
        ///     Creates the renderer using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="index">The index</param>
        /// <param name="flags">The flags</param>
        /// <returns>The int ptr</returns>
        [return: NotNull]
        public static IntPtr CreateRenderer([NotNull] IntPtr window, [NotNull] int index, SdlRendererFlags flags) => INTERNAL_SDL_CreateRenderer(window.Validate(), index, flags);

        /// <summary>
        ///     Sdl the create software renderer using the specified surface
        /// </summary>
        /// <param name="surface">The surface</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_CreateSoftwareRenderer", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern IntPtr INTERNAL_SDL_CreateSoftwareRenderer([NotNull] IntPtr surface);

        /// <summary>
        ///     Creates the software renderer using the specified surface
        /// </summary>
        /// <param name="surface">The surface</param>
        /// <returns>The int ptr</returns>
        [return: NotNull]
        public static IntPtr CreateSoftwareRenderer([NotNull] IntPtr surface) => INTERNAL_SDL_CreateSoftwareRenderer(surface.Validate());

        /// <summary>
        ///     Sdl the create texture using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="format">The format</param>
        /// <param name="access">The access</param>
        /// <param name="w">The </param>
        /// <param name="h">The </param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_CreateTexture", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern IntPtr INTERNAL_SDL_CreateTexture([NotNull] IntPtr renderer, [NotNull] uint format, [NotNull] int access, [NotNull] int w, [NotNull] int h);

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
        public static IntPtr CreateTexture([NotNull] IntPtr renderer, [NotNull] uint format, [NotNull] int access, [NotNull] int w, [NotNull] int h) => INTERNAL_SDL_CreateTexture(renderer.Validate(), format, access, w, h);

        /// <summary>
        ///     Sdl the create texture from surface using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="surface">The surface</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_CreateTextureFromSurface", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern IntPtr INTERNAL_SDL_CreateTextureFromSurface([NotNull] IntPtr renderer, [NotNull] IntPtr surface);

        /// <summary>
        ///     Creates the texture from surface using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="surface">The surface</param>
        /// <returns>The int ptr</returns>
        [return: NotNull]
        public static IntPtr CreateTextureFromSurface([NotNull] IntPtr renderer, [NotNull] IntPtr surface) => INTERNAL_SDL_CreateTextureFromSurface(renderer.Validate(), surface.Validate());

        /// <summary>
        ///     Sdl the destroy renderer using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        [DllImport(NativeLibName, EntryPoint = "SDL_DestroyRenderer", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern void INTERNAL_SDL_DestroyRenderer([NotNull] IntPtr renderer);

        /// <summary>
        ///     Destroys the renderer using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        [return: NotNull]
        public static void DestroyRenderer([NotNull] IntPtr renderer) => INTERNAL_SDL_DestroyRenderer(renderer.Validate());

        /// <summary>
        ///     Sdl the destroy texture using the specified texture
        /// </summary>
        /// <param name="texture">The texture</param>
        [DllImport(NativeLibName, EntryPoint = "SDL_DestroyTexture", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern void INTERNAL_SDL_DestroyTexture([NotNull] IntPtr texture);

        /// <summary>
        ///     Destroys the texture using the specified texture
        /// </summary>
        /// <param name="texture">The texture</param>
        [return: NotNull]
        public static void DestroyTexture([NotNull] IntPtr texture) => INTERNAL_SDL_DestroyTexture(texture.Validate());

        /// <summary>
        ///     Sdl the get num render drivers
        /// </summary>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GetNumRenderDrivers", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern int INTERNAL_SDL_GetNumRenderDrivers();

        /// <summary>
        ///     Gets the num render drivers
        /// </summary>
        /// <returns>The int</returns>
        [return: NotNull]
        public static int GetNumRenderDrivers() => INTERNAL_SDL_GetNumRenderDrivers().Validate();

        /// <summary>
        ///     Sdl the get render draw blend mode using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="blendMode">The blend mode</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GetRenderDrawBlendMode", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern int INTERNAL_SDL_GetRenderDrawBlendMode([NotNull] IntPtr renderer, out SdlBlendMode blendMode);

        /// <summary>
        ///     Gets the render draw blend mode using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="blendMode">The blend mode</param>
        /// <returns>The int</returns>
        [return: NotNull]
        public static int GetRenderDrawBlendMode([NotNull] IntPtr renderer, out SdlBlendMode blendMode) => INTERNAL_SDL_GetRenderDrawBlendMode(renderer.Validate(), out blendMode);

        /// <summary>
        ///     Sdl the set texture scale mode using the specified texture
        /// </summary>
        /// <param name="texture">The texture</param>
        /// <param name="scaleMode">The scale mode</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_SetTextureScaleMode", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern int INTERNAL_SDL_SetTextureScaleMode([NotNull] IntPtr texture, SdlScaleMode scaleMode);

        /// <summary>
        ///     Sets the texture scale mode using the specified texture
        /// </summary>
        /// <param name="texture">The texture</param>
        /// <param name="scaleMode">The scale mode</param>
        /// <returns>The int</returns>
        [return: NotNull]
        public static int SetTextureScaleMode([NotNull] IntPtr texture, SdlScaleMode scaleMode) => INTERNAL_SDL_SetTextureScaleMode(texture.Validate(), scaleMode);

        /// <summary>
        ///     Sdl the get texture scale mode using the specified texture
        /// </summary>
        /// <param name="texture">The texture</param>
        /// <param name="scaleMode">The scale mode</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GetTextureScaleMode", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern int INTERNAL_SDL_GetTextureScaleMode([NotNull] IntPtr texture, out SdlScaleMode scaleMode);

        /// <summary>
        ///     Gets the texture scale mode using the specified texture
        /// </summary>
        /// <param name="texture">The texture</param>
        /// <param name="scaleMode">The scale mode</param>
        /// <returns>The int</returns>
        [return: NotNull]
        public static int GetTextureScaleMode([NotNull] IntPtr texture, out SdlScaleMode scaleMode) => INTERNAL_SDL_GetTextureScaleMode(texture.Validate(), out scaleMode);

        /// <summary>
        ///     Sdl the set texture user data using the specified texture
        /// </summary>
        /// <param name="texture">The texture</param>
        /// <param name="userdata">The userdata</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_SetTextureUserData", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern int INTERNAL_SDL_SetTextureUserData([NotNull] IntPtr texture, [NotNull] IntPtr userdata);

        /// <summary>
        ///     Sets the texture user data using the specified texture
        /// </summary>
        /// <param name="texture">The texture</param>
        /// <param name="userdata">The userdata</param>
        /// <returns>The int</returns>
        [return: NotNull]
        public static int SetTextureUserData([NotNull] IntPtr texture, [NotNull] IntPtr userdata) => INTERNAL_SDL_SetTextureUserData(texture.Validate(), userdata.Validate());

        /// <summary>
        ///     Sdl the get texture user data using the specified texture
        /// </summary>
        /// <param name="texture">The texture</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GetTextureUserData", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern IntPtr INTERNAL_SDL_GetTextureUserData([NotNull] IntPtr texture);

        /// <summary>
        ///     Internals the sdl get texture user data using the specified texture
        /// </summary>
        /// <param name="texture">The texture</param>
        /// <returns>The int ptr</returns>
        [return: NotNull]
        public static IntPtr GetTextureUserData([NotNull] IntPtr texture) => INTERNAL_SDL_GetTextureUserData(texture.Validate());

        /// <summary>
        ///     Sdl the get render draw color using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="r">The </param>
        /// <param name="g">The </param>
        /// <param name="b">The </param>
        /// <param name="a">The </param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GetRenderDrawColor", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern int INTERNAL_SDL_GetRenderDrawColor([NotNull] IntPtr renderer, out byte r, out byte g, out byte b, out byte a);

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
        public static int GetRenderDrawColor([NotNull] IntPtr renderer, out byte r, out byte g, out byte b, out byte a) => INTERNAL_SDL_GetRenderDrawColor(renderer.Validate(), out r, out g, out b, out a);

        /// <summary>
        ///     Sdl the get render driver info using the specified index
        /// </summary>
        /// <param name="index">The index</param>
        /// <param name="info">The info</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GetRenderDriverInfo", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern int INTERNAL_SDL_GetRenderDriverInfo([NotNull] int index, out SdlRendererInfo info);

        /// <summary>
        ///     Gets the render driver info using the specified index
        /// </summary>
        /// <param name="index">The index</param>
        /// <param name="info">The info</param>
        /// <returns>The int</returns>
        [return: NotNull]
        public static int GetRenderDriverInfo([NotNull] int index, out SdlRendererInfo info) => INTERNAL_SDL_GetRenderDriverInfo(index.Validate(), out info);

        /// <summary>
        ///     Sdl the get renderer using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GetRenderer", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern IntPtr INTERNAL_SDL_GetRenderer([NotNull] IntPtr window);

        /// <summary>
        ///     Gets the renderer using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <returns>The int ptr</returns>
        [return: NotNull]
        public static IntPtr GetRenderer([NotNull] IntPtr window) => INTERNAL_SDL_GetRenderer(window.Validate());

        /// <summary>
        ///     Sdl the get renderer info using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="info">The info</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GetRendererInfo", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern int INTERNAL_SDL_GetRendererInfo([NotNull] IntPtr renderer, out SdlRendererInfo info);

        /// <summary>
        ///     Gets the renderer info using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="info">The info</param>
        /// <returns>The int</returns>
        [return: NotNull]
        public static int GetRendererInfo([NotNull] IntPtr renderer, out SdlRendererInfo info) => INTERNAL_SDL_GetRendererInfo(renderer.Validate(), out info);

        /// <summary>
        ///     Sdl the get renderer output size using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="w">The </param>
        /// <param name="h">The </param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GetRendererOutputSize", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern int INTERNAL_SDL_GetRendererOutputSize([NotNull] IntPtr renderer, out int w, out int h);

        /// <summary>
        ///     Gets the renderer output size using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="w">The </param>
        /// <param name="h">The </param>
        /// <returns>The int</returns>
        [return: NotNull]
        public static int GetRendererOutputSize([NotNull] IntPtr renderer, out int w, out int h) => INTERNAL_SDL_GetRendererOutputSize(renderer.Validate(), out w, out h);

        /// <summary>
        ///     Sdl the get texture alpha mod using the specified texture
        /// </summary>
        /// <param name="texture">The texture</param>
        /// <param name="alpha">The alpha</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GetTextureAlphaMod", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern int INTERNAL_SDL_GetTextureAlphaMod([NotNull] IntPtr texture, out byte alpha);

        /// <summary>
        ///     Gets the texture alpha mod using the specified texture
        /// </summary>
        /// <param name="texture">The texture</param>
        /// <param name="alpha">The alpha</param>
        /// <returns>The int</returns>
        [return: NotNull]
        public static int GetTextureAlphaMod([NotNull] IntPtr texture, out byte alpha) => INTERNAL_SDL_GetTextureAlphaMod(texture.Validate(), out alpha);

        /// <summary>
        ///     Sdl the get texture blend mode using the specified texture
        /// </summary>
        /// <param name="texture">The texture</param>
        /// <param name="blendMode">The blend mode</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GetTextureBlendMode", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern int INTERNAL_SDL_GetTextureBlendMode([NotNull] IntPtr texture, out SdlBlendMode blendMode);

        /// <summary>
        ///     Gets the texture blend mode using the specified texture
        /// </summary>
        /// <param name="texture">The texture</param>
        /// <param name="blendMode">The blend mode</param>
        /// <returns>The int</returns>
        [return: NotNull]
        public static int GetTextureBlendMode([NotNull] IntPtr texture, out SdlBlendMode blendMode) => INTERNAL_SDL_GetTextureBlendMode(texture.Validate(), out blendMode);

        /// <summary>
        ///     Sdl the get texture color mod using the specified texture
        /// </summary>
        /// <param name="texture">The texture</param>
        /// <param name="r">The </param>
        /// <param name="g">The </param>
        /// <param name="b">The </param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GetTextureColorMod", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern int INTERNAL_SDL_GetTextureColorMod([NotNull] IntPtr texture, out byte r, out byte g, out byte b);

        /// <summary>
        ///     Gets the texture color mod using the specified texture
        /// </summary>
        /// <param name="texture">The texture</param>
        /// <param name="r">The </param>
        /// <param name="g">The </param>
        /// <param name="b">The </param>
        /// <returns>The int</returns>
        [return: NotNull]
        public static int GetTextureColorMod([NotNull] IntPtr texture, out byte r, out byte g, out byte b) => INTERNAL_SDL_GetTextureColorMod(texture.Validate(), out r, out g, out b);

        /// <summary>
        ///     Sdl the lock texture using the specified texture
        /// </summary>
        /// <param name="texture">The texture</param>
        /// <param name="rect">The rect</param>
        /// <param name="pixels">The pixels</param>
        /// <param name="pitch">The pitch</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_LockTexture", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern int INTERNAL_SDL_LockTexture([NotNull] IntPtr texture, ref RectangleI rect, out IntPtr pixels, out int pitch);

        /// <summary>
        ///     Locks the texture using the specified texture
        /// </summary>
        /// <param name="texture">The texture</param>
        /// <param name="rect">The rect</param>
        /// <param name="pixels">The pixels</param>
        /// <param name="pitch">The pitch</param>
        /// <returns>The int</returns>
        [return: NotNull]
        public static int LockTexture([NotNull] IntPtr texture, ref RectangleI rect, out IntPtr pixels, out int pitch) => INTERNAL_SDL_LockTexture(texture.Validate(), ref rect, out pixels, out pitch);

        /// <summary>
        ///     Sdl the lock texture using the specified texture
        /// </summary>
        /// <param name="texture">The texture</param>
        /// <param name="rect">The rect</param>
        /// <param name="pixels">The pixels</param>
        /// <param name="pitch">The pitch</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_LockTexture", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern int INTERNAL_SDL_LockTexture([NotNull] IntPtr texture, [NotNull] IntPtr rect, out IntPtr pixels, out int pitch);

        /// <summary>
        ///     Locks the texture using the specified texture
        /// </summary>
        /// <param name="texture">The texture</param>
        /// <param name="rect">The rect</param>
        /// <param name="pixels">The pixels</param>
        /// <param name="pitch">The pitch</param>
        /// <returns>The int</returns>
        [return: NotNull]
        public static int LockTexture([NotNull] IntPtr texture, [NotNull] IntPtr rect, out IntPtr pixels, out int pitch) => INTERNAL_SDL_LockTexture(texture.Validate(), rect.Validate(), out pixels, out pitch);

        /// <summary>
        ///     Sdl the lock texture to surface using the specified texture
        /// </summary>
        /// <param name="texture">The texture</param>
        /// <param name="rect">The rect</param>
        /// <param name="surface">The surface</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_LockTextureToSurface", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern int INTERNAL_SDL_LockTextureToSurface([NotNull] IntPtr texture, ref RectangleI rect, out IntPtr surface);

        /// <summary>
        ///     Locks the texture to surface using the specified texture
        /// </summary>
        /// <param name="texture">The texture</param>
        /// <param name="rect">The rect</param>
        /// <param name="surface">The surface</param>
        /// <returns>The int</returns>
        [return: NotNull]
        public static int LockTextureToSurface([NotNull] IntPtr texture, ref RectangleI rect, out IntPtr surface) => INTERNAL_SDL_LockTextureToSurface(texture.Validate(), ref rect, out surface);

        /// <summary>
        ///     Sdl the lock texture to surface using the specified texture
        /// </summary>
        /// <param name="texture">The texture</param>
        /// <param name="rect">The rect</param>
        /// <param name="surface">The surface</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_LockTextureToSurface", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern int INTERNAL_SDL_LockTextureToSurface([NotNull] IntPtr texture, [NotNull] IntPtr rect, out IntPtr surface);

        /// <summary>
        ///     Locks the texture to surface using the specified texture
        /// </summary>
        /// <param name="texture">The texture</param>
        /// <param name="rect">The rect</param>
        /// <param name="surface">The surface</param>
        /// <returns>The int</returns>
        [return: NotNull]
        public static int LockTextureToSurface([NotNull] IntPtr texture, [NotNull] IntPtr rect, out IntPtr surface) => INTERNAL_SDL_LockTextureToSurface(texture.Validate(), rect.Validate(), out surface);

        /// <summary>
        ///     Sdl the query texture using the specified texture
        /// </summary>
        /// <param name="texture">The texture</param>
        /// <param name="format">The format</param>
        /// <param name="access">The access</param>
        /// <param name="w">The </param>
        /// <param name="h">The </param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_QueryTexture", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern int INTERNAL_SDL_QueryTexture([NotNull] IntPtr texture, out uint format, out int access, out int w, out int h);

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
        public static int QueryTexture([NotNull] IntPtr texture, out uint format, out int access, out int w, out int h) => INTERNAL_SDL_QueryTexture(texture.Validate(), out format, out access, out w, out h);

        /// <summary>
        ///     Sdl the render clear using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_RenderClear", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern int INTERNAL_SDL_RenderClear([NotNull] IntPtr renderer);

        /// <summary>
        ///     Renders the clear using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <returns>The int</returns>
        [return: NotNull]
        public static int RenderClear([NotNull] IntPtr renderer) => INTERNAL_SDL_RenderClear(renderer.Validate());

        /// <summary>
        ///     Sdl the render copy using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="texture">The texture</param>
        /// <param name="srcRect">The src rect</param>
        /// <param name="dstRect">The dst rect</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_RenderCopy", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern int INTERNAL_SDL_RenderCopy([NotNull] IntPtr renderer, [NotNull] IntPtr texture, ref RectangleI srcRect, ref RectangleI dstRect);

        /// <summary>
        ///     Renders the copy using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="texture">The texture</param>
        /// <param name="srcRect">The src rect</param>
        /// <param name="dstRect">The dst rect</param>
        /// <returns>The int</returns>
        [return: NotNull]
        public static int RenderCopy([NotNull] IntPtr renderer, [NotNull] IntPtr texture, ref RectangleI srcRect, ref RectangleI dstRect) => INTERNAL_SDL_RenderCopy(renderer.Validate(), texture.Validate(), ref srcRect, ref dstRect);

        /// <summary>
        ///     Sdl the render copy using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="texture">The texture</param>
        /// <param name="srcRect">The src rect</param>
        /// <param name="dstRect">The dst rect</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_RenderCopy", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern int INTERNAL_SDL_RenderCopy([NotNull] IntPtr renderer, [NotNull] IntPtr texture, [NotNull] IntPtr srcRect, ref RectangleI dstRect);

        /// <summary>
        ///     Renders the copy using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="texture">The texture</param>
        /// <param name="srcRect">The src rect</param>
        /// <param name="dstRect">The dst rect</param>
        /// <returns>The int</returns>
        [return: NotNull]
        public static int RenderCopy([NotNull] IntPtr renderer, [NotNull] IntPtr texture, [NotNull] IntPtr srcRect, ref RectangleI dstRect) => INTERNAL_SDL_RenderCopy(renderer.Validate(), texture.Validate(), srcRect.Validate(), ref dstRect);
        
        /// <summary>
        ///     Sdl the render copy using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="texture">The texture</param>
        /// <param name="srcRect">The src rect</param>
        /// <param name="dstRect">The dst rect</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_RenderCopy", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern int INTERNAL_SDL_RenderCopy([NotNull] IntPtr renderer, [NotNull] IntPtr texture, ref RectangleI srcRect, [NotNull] IntPtr dstRect);

        /// <summary>
        ///     Renders the copy using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="texture">The texture</param>
        /// <param name="srcRect">The src rect</param>
        /// <param name="dstRect">The dst rect</param>
        /// <returns>The int</returns>
        [return: NotNull]
        public static int RenderCopy([NotNull] IntPtr renderer, [NotNull] IntPtr texture, ref RectangleI srcRect, [NotNull] IntPtr dstRect) => INTERNAL_SDL_RenderCopy(renderer.Validate(), texture.Validate(), ref srcRect, dstRect.Validate());

        /// <summary>
        ///     Sdl the render copy using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="texture">The texture</param>
        /// <param name="srcRect">The src rect</param>
        /// <param name="dstRect">The dst rect</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_RenderCopy", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern int INTERNAL_SDL_RenderCopy([NotNull] IntPtr renderer, [NotNull] IntPtr texture, [NotNull] IntPtr srcRect, [NotNull] IntPtr dstRect);

        /// <summary>
        ///     Renders the copy using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="texture">The texture</param>
        /// <param name="srcRect">The src rect</param>
        /// <param name="dstRect">The dst rect</param>
        /// <returns>The int</returns>
        [return: NotNull]
        public static int RenderCopy([NotNull] IntPtr renderer, [NotNull] IntPtr texture, [NotNull] IntPtr srcRect, [NotNull] IntPtr dstRect) => INTERNAL_SDL_RenderCopy(renderer.Validate(), texture.Validate(), srcRect.Validate(), dstRect.Validate());

        /// <summary>
        ///     Sdl the render copy ex using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="texture">The texture</param>
        /// <param name="srcRect">The src rect</param>
        /// <param name="dstRect">The dst rect</param>
        /// <param name="angle">The angle</param>
        /// <param name="center">The center</param>
        /// <param name="flip">The flip</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_RenderCopyEx", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern int INTERNAL_SDL_RenderCopyEx([NotNull] IntPtr renderer, [NotNull] IntPtr texture, ref RectangleI srcRect, ref RectangleI dstRect, double angle, ref PointI center, SdlRendererFlip flip);

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
        public static int RenderCopyEx([NotNull] IntPtr renderer, [NotNull] IntPtr texture, ref RectangleI srcRect, ref RectangleI dstRect, double angle, ref PointI center, SdlRendererFlip flip) => INTERNAL_SDL_RenderCopyEx(renderer.Validate(), texture.Validate(), ref srcRect, ref dstRect, angle, ref center, flip);

        /// <summary>
        ///     Sdl the render copy ex using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="texture">The texture</param>
        /// <param name="srcRect">The src rect</param>
        /// <param name="dstRect">The dst rect</param>
        /// <param name="angle">The angle</param>
        /// <param name="center">The center</param>
        /// <param name="flip">The flip</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_RenderCopyEx", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern int INTERNAL_SDL_RenderCopyEx([NotNull] IntPtr renderer, [NotNull] IntPtr texture, [NotNull] IntPtr srcRect, ref RectangleI dstRect, double angle, ref PointI center, SdlRendererFlip flip);

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
        public static int RenderCopyEx([NotNull] IntPtr renderer, [NotNull] IntPtr texture, [NotNull] IntPtr srcRect, ref RectangleI dstRect, double angle, ref PointI center, SdlRendererFlip flip) => INTERNAL_SDL_RenderCopyEx(renderer.Validate(), texture.Validate(), srcRect.Validate(), ref dstRect, angle, ref center, flip);

        /// <summary>
        ///     Sdl the render copy ex using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="texture">The texture</param>
        /// <param name="srcRect">The src rect</param>
        /// <param name="dstRect">The dst rect</param>
        /// <param name="angle">The angle</param>
        /// <param name="center">The center</param>
        /// <param name="flip">The flip</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_RenderCopyEx", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern int INTERNAL_SDL_RenderCopyEx([NotNull] IntPtr renderer, [NotNull] IntPtr texture, ref RectangleI srcRect, [NotNull] IntPtr dstRect, double angle, ref PointI center, SdlRendererFlip flip);

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
        public static int RenderCopyEx([NotNull] IntPtr renderer, [NotNull] IntPtr texture, ref RectangleI srcRect, [NotNull] IntPtr dstRect, double angle, ref PointI center, SdlRendererFlip flip) => INTERNAL_SDL_RenderCopyEx(renderer.Validate(), texture.Validate(), ref srcRect, dstRect.Validate(), angle, ref center, flip);

        /// <summary>
        ///     Sdl the render copy ex using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="texture">The texture</param>
        /// <param name="srcRect">The src rect</param>
        /// <param name="dstRect"></param>
        /// <param name="angle">The angle</param>
        /// <param name="center">The center</param>
        /// <param name="flip">The flip</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_RenderCopyEx", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern int INTERNAL_SDL_RenderCopyEx([NotNull] IntPtr renderer, [NotNull] IntPtr texture, ref RectangleI srcRect, ref RectangleI dstRect, double angle, [NotNull] IntPtr center, SdlRendererFlip flip);

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
        public static int RenderCopyEx([NotNull] IntPtr renderer, [NotNull] IntPtr texture, ref RectangleI srcRect, ref RectangleI dstRect, double angle, [NotNull] IntPtr center, SdlRendererFlip flip) => INTERNAL_SDL_RenderCopyEx(renderer.Validate(), texture.Validate(), ref srcRect, ref dstRect, angle, center.Validate(), flip);

        /// <summary>
        ///     Sdl the render copy ex using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="texture">The texture</param>
        /// <param name="srcRect">The src rect</param>
        /// <param name="dstRect">The dst rect</param>
        /// <param name="angle">The angle</param>
        /// <param name="center">The center</param>
        /// <param name="flip">The flip</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_RenderCopyEx", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern int INTERNAL_SDL_RenderCopyEx([NotNull] IntPtr renderer, [NotNull] IntPtr texture, [NotNull] IntPtr srcRect, [NotNull] IntPtr dstRect, double angle, ref PointI center, SdlRendererFlip flip);

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
        public static int RenderCopyEx([NotNull] IntPtr renderer, [NotNull] IntPtr texture, [NotNull] IntPtr srcRect, [NotNull] IntPtr dstRect, double angle, ref PointI center, SdlRendererFlip flip) => INTERNAL_SDL_RenderCopyEx(renderer.Validate(), texture.Validate(), srcRect.Validate(), dstRect.Validate(), angle, ref center, flip);

        /// <summary>
        ///     Sdl the render copy ex using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="texture">The texture</param>
        /// <param name="srcRect">The src rect</param>
        /// <param name="dstRect">The dst rect</param>
        /// <param name="angle">The angle</param>
        /// <param name="center">The center</param>
        /// <param name="flip">The flip</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_RenderCopyEx", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern int INTERNAL_SDL_RenderCopyEx([NotNull] IntPtr renderer, [NotNull] IntPtr texture, [NotNull] IntPtr srcRect, ref RectangleI dstRect, double angle, [NotNull] IntPtr center, SdlRendererFlip flip);

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
        public static int RenderCopyEx([NotNull] IntPtr renderer, [NotNull] IntPtr texture, [NotNull] IntPtr srcRect, ref RectangleI dstRect, double angle, [NotNull] IntPtr center, SdlRendererFlip flip) => INTERNAL_SDL_RenderCopyEx(renderer.Validate(), texture.Validate(), srcRect.Validate(), ref dstRect, angle, center.Validate(), flip);

        /// <summary>
        ///     Sdl the render copy ex using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="texture">The texture</param>
        /// <param name="srcRect">The src rect</param>
        /// <param name="dstRect">The dst rect</param>
        /// <param name="angle">The angle</param>
        /// <param name="center">The center</param>
        /// <param name="flip">The flip</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_RenderCopyEx", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern int INTERNAL_SDL_RenderCopyEx([NotNull] IntPtr renderer, [NotNull] IntPtr texture, ref RectangleI srcRect, [NotNull] IntPtr dstRect, double angle, [NotNull] IntPtr center, SdlRendererFlip flip);

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
        public static int RenderCopyEx([NotNull] IntPtr renderer, [NotNull] IntPtr texture, ref RectangleI srcRect, [NotNull] IntPtr dstRect, double angle, [NotNull] IntPtr center, SdlRendererFlip flip) => INTERNAL_SDL_RenderCopyEx(renderer.Validate(), texture.Validate(), ref srcRect, dstRect.Validate(), angle, center.Validate(), flip);

        /// <summary>
        ///     Sdl the render copy ex using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="texture">The texture</param>
        /// <param name="srcRect">The src rect</param>
        /// <param name="dstRect">The dst rect</param>
        /// <param name="angle">The angle</param>
        /// <param name="center">The center</param>
        /// <param name="flip">The flip</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_RenderCopyEx", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern int INTERNAL_SDL_RenderCopyEx([NotNull] IntPtr renderer, [NotNull] IntPtr texture, [NotNull] IntPtr srcRect, [NotNull] IntPtr dstRect, double angle, [NotNull] IntPtr center, SdlRendererFlip flip);

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
        public static int RenderCopyEx([NotNull] IntPtr renderer, [NotNull] IntPtr texture, [NotNull] IntPtr srcRect, [NotNull] IntPtr dstRect, double angle, [NotNull] IntPtr center, SdlRendererFlip flip) => INTERNAL_SDL_RenderCopyEx(renderer.Validate(), texture.Validate(), srcRect.Validate(), dstRect.Validate(), angle, center.Validate(), flip);

        /// <summary>
        ///     Sdl the render draw line using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="x1">The </param>
        /// <param name="y1">The </param>
        /// <param name="x2">The </param>
        /// <param name="y2">The </param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_RenderDrawLine", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern int INTERNAL_SDL_RenderDrawLine([NotNull] IntPtr renderer, [NotNull] int x1, [NotNull] int y1, [NotNull] int x2, [NotNull] int y2);

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
        public static int RenderDrawLine([NotNull] IntPtr renderer, [NotNull] int x1, [NotNull] int y1, [NotNull] int x2, [NotNull] int y2) => INTERNAL_SDL_RenderDrawLine(renderer.Validate(), x1, y1, x2, y2);

        /// <summary>
        ///     Sdl the render draw lines using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="points">The points</param>
        /// <param name="count">The count</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_RenderDrawLines", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern int INTERNAL_SDL_RenderDrawLines([NotNull] IntPtr renderer, [In] PointI[] points, [NotNull] int count);

        /// <summary>
        ///     Renders the draw lines using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="points">The points</param>
        /// <param name="count">The count</param>
        /// <returns>The int</returns>
        [return: NotNull]
        public static int RenderDrawLines([NotNull] IntPtr renderer, [In] PointI[] points, [NotNull] int count) => INTERNAL_SDL_RenderDrawLines(renderer.Validate(), points, count);

        /// <summary>
        ///     Sdl the render draw point using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="x">The </param>
        /// <param name="y">The </param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_RenderDrawPoint", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern int INTERNAL_SDL_RenderDrawPoint([NotNull] IntPtr renderer, [NotNull] int x, [NotNull] int y);

        /// <summary>
        ///     Renders the draw point using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="x">The </param>
        /// <param name="y">The </param>
        /// <returns>The int</returns>
        [return: NotNull]
        public static int RenderDrawPoint([NotNull] IntPtr renderer, [NotNull] int x, [NotNull] int y) => INTERNAL_SDL_RenderDrawPoint(renderer.Validate(), x, y);

        /// <summary>
        ///     Sdl the render draw points using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="points">The points</param>
        /// <param name="count">The count</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_RenderDrawPoints", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern int INTERNAL_SDL_RenderDrawPoints([NotNull] IntPtr renderer, [In] PointI[] points, [NotNull] int count);

        /// <summary>
        ///     Renders the draw points using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="points">The points</param>
        /// <param name="count">The count</param>
        /// <returns>The int</returns>
        [return: NotNull]
        public static int RenderDrawPoints([NotNull] IntPtr renderer, [In] PointI[] points, [NotNull] int count) => INTERNAL_SDL_RenderDrawPoints(renderer.Validate(), points, count);

        /// <summary>
        ///     Sdl the render draw rect using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="rect">The rect</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_RenderDrawRect", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern int INTERNAL_SDL_RenderDrawRect([NotNull] IntPtr renderer, ref RectangleI rect);

        /// <summary>
        ///     Renders the draw rect using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="rect">The rect</param>
        /// <returns>The int</returns>
        [return: NotNull]
        public static int RenderDrawRect([NotNull] IntPtr renderer, ref RectangleI rect) => INTERNAL_SDL_RenderDrawRect(renderer.Validate(), ref rect);

        /// <summary>
        ///     Sdl the render draw rect using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="rect">The rect</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_RenderDrawRect", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern int INTERNAL_SDL_RenderDrawRect([NotNull] IntPtr renderer, [NotNull] IntPtr rect);

        /// <summary>
        ///     Renders the draw rect using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="rect">The rect</param>
        /// <returns>The int</returns>
        [return: NotNull]
        public static int RenderDrawRect([NotNull] IntPtr renderer, [NotNull] IntPtr rect) => INTERNAL_SDL_RenderDrawRect(renderer.Validate(), rect.Validate());

        /// <summary>
        ///     Sdl the render draw rects using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="rects">The rects</param>
        /// <param name="count">The count</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_RenderDrawRects", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern int INTERNAL_SDL_RenderDrawRects([NotNull] IntPtr renderer, [In] RectangleI[] rects, [NotNull] int count);

        /// <summary>
        ///     Renders the draw rects using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="rects">The rects</param>
        /// <param name="count">The count</param>
        /// <returns>The int</returns>
        [return: NotNull]
        public static int RenderDrawRects([NotNull] IntPtr renderer, [In] RectangleI[] rects, [NotNull] int count) => INTERNAL_SDL_RenderDrawRects(renderer, rects, count);

        /// <summary>
        ///     Sdl the render fill rect using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="rect">The rect</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_RenderFillRect", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern int INTERNAL_SDL_RenderFillRect([NotNull] IntPtr renderer, ref RectangleI rect);

        /// <summary>
        ///     Renders the fill rect using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="rect">The rect</param>
        /// <returns>The int</returns>
        [return: NotNull]
        public static int RenderFillRect([NotNull] IntPtr renderer, ref RectangleI rect) => INTERNAL_SDL_RenderFillRect(renderer.Validate(), ref rect);

        /// <summary>
        ///     Sdl the render fill rect using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="rect">The rect</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_RenderFillRect", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern int INTERNAL_SDL_RenderFillRect([NotNull] IntPtr renderer, [NotNull] IntPtr rect);

        /// <summary>
        ///     Renders the fill rect using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="rect">The rect</param>
        /// <returns>The int</returns>
        [return: NotNull]
        public static int RenderFillRect([NotNull] IntPtr renderer, [NotNull] IntPtr rect) => INTERNAL_SDL_RenderFillRect(renderer.Validate(), rect.Validate());

        /// <summary>
        ///     Sdl the render fill rects using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="rects">The rects</param>
        /// <param name="count">The count</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_RenderFillRects", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern int INTERNAL_SDL_RenderFillRects([NotNull] IntPtr renderer, [In] RectangleI[] rects, [NotNull] int count);

        /// <summary>
        ///     Renders the fill rects using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="rects">The rects</param>
        /// <param name="count">The count</param>
        /// <returns>The int</returns>
        [return: NotNull]
        public static int RenderFillRects([NotNull] IntPtr renderer, [In] RectangleI[] rects, [NotNull] int count) => INTERNAL_SDL_RenderFillRects(renderer.Validate(), rects, count);

        /// <summary>
        ///     Sdl the render copy f using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="texture">The texture</param>
        /// <param name="srcRect">The src rect</param>
        /// <param name="dst">The dst rect</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_RenderCopyF", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern int INTERNAL_SDL_RenderCopyF([NotNull] IntPtr renderer, [NotNull] IntPtr texture, ref RectangleI srcRect, ref RectangleF dst);

        /// <summary>
        ///     Renders the copy f using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="texture">The texture</param>
        /// <param name="srcRect">The src rect</param>
        /// <param name="dst">The dst rect</param>
        /// <returns>The int</returns>
        [return: NotNull]
        public static int RenderCopyF([NotNull] IntPtr renderer, [NotNull] IntPtr texture, ref RectangleI srcRect, ref RectangleF dst) => INTERNAL_SDL_RenderCopyF(renderer.Validate(), texture.Validate(), ref srcRect, ref dst);

        /// <summary>
        ///     Sdl the render copy f using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="texture">The texture</param>
        /// <param name="srcRect">The src rect</param>
        /// <param name="dst">The dst rect</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_RenderCopyF", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern int INTERNAL_SDL_RenderCopyF([NotNull] IntPtr renderer, [NotNull] IntPtr texture, [NotNull] IntPtr srcRect, ref RectangleF dst);

        /// <summary>
        ///     Renders the copy f using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="texture">The texture</param>
        /// <param name="srcRect">The src rect</param>
        /// <param name="dst">The dst rect</param>
        /// <returns>The int</returns>
        [return: NotNull]
        public static int RenderCopyF([NotNull] IntPtr renderer, [NotNull] IntPtr texture, [NotNull] IntPtr srcRect, ref RectangleF dst) => INTERNAL_SDL_RenderCopyF(renderer.Validate(), texture.Validate(), srcRect.Validate(), ref dst);

        /// <summary>
        ///     Sdl the render copy f using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="texture">The texture</param>
        /// <param name="srcRect">The src rect</param>
        /// <param name="dstRect">The dst rect</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_RenderCopyF", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern int INTERNAL_SDL_RenderCopyF([NotNull] IntPtr renderer, [NotNull] IntPtr texture, ref RectangleI srcRect, [NotNull] IntPtr dstRect);

        /// <summary>
        ///     Renders the copy f using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="texture">The texture</param>
        /// <param name="srcRect">The src rect</param>
        /// <param name="dstRect">The dst rect</param>
        /// <returns>The int</returns>
        [return: NotNull]
        public static int RenderCopyF([NotNull] IntPtr renderer, [NotNull] IntPtr texture, ref RectangleI srcRect, [NotNull] IntPtr dstRect) => INTERNAL_SDL_RenderCopyF(renderer.Validate(), texture.Validate(), ref srcRect, dstRect.Validate());

        /// <summary>
        ///     Sdl the render copy f using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="texture">The texture</param>
        /// <param name="srcRect">The src rect</param>
        /// <param name="dstRect">The dst rect</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_RenderCopyF", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern int INTERNAL_SDL_RenderCopyF([NotNull] IntPtr renderer, [NotNull] IntPtr texture, [NotNull] IntPtr srcRect, [NotNull] IntPtr dstRect);

        /// <summary>
        ///     Renders the copy f using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="texture">The texture</param>
        /// <param name="srcRect">The src rect</param>
        /// <param name="dstRect">The dst rect</param>
        /// <returns>The int</returns>
        [return: NotNull]
        public static int RenderCopyF([NotNull] IntPtr renderer, [NotNull] IntPtr texture, [NotNull] IntPtr srcRect, [NotNull] IntPtr dstRect) => INTERNAL_SDL_RenderCopyF(renderer.Validate(), texture.Validate(), srcRect.Validate(), dstRect.Validate());

        /// <summary>
        ///     Sdl the render copy ex using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="texture">The texture</param>
        /// <param name="srcRect">The src rect</param>
        /// <param name="dst">The dst rect</param>
        /// <param name="angle">The angle</param>
        /// <param name="center">The center</param>
        /// <param name="flip">The flip</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_RenderCopyEx", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern int INTERNAL_SDL_RenderCopyEx([NotNull] IntPtr renderer, [NotNull] IntPtr texture, ref RectangleI srcRect, ref RectangleF dst, double angle, ref PointF center, SdlRendererFlip flip);

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
        public static int RenderCopyEx([NotNull] IntPtr renderer, [NotNull] IntPtr texture, ref RectangleI srcRect, ref RectangleF dst, double angle, ref PointF center, SdlRendererFlip flip) => INTERNAL_SDL_RenderCopyEx(renderer.Validate(), texture.Validate(), ref srcRect, ref dst, angle, ref center, flip);

        /// <summary>
        ///     Sdl the render copy ex using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="texture">The texture</param>
        /// <param name="srcRect">The src rect</param>
        /// <param name="dst">The dst rect</param>
        /// <param name="angle">The angle</param>
        /// <param name="center">The center</param>
        /// <param name="flip">The flip</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_RenderCopyEx", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern int INTERNAL_SDL_RenderCopyEx([NotNull] IntPtr renderer, [NotNull] IntPtr texture, [NotNull] IntPtr srcRect, ref RectangleF dst, double angle, ref PointF center, SdlRendererFlip flip);

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
        public static int RenderCopyEx([NotNull] IntPtr renderer, [NotNull] IntPtr texture, [NotNull] IntPtr srcRect, ref RectangleF dst, double angle, ref PointF center, SdlRendererFlip flip) => INTERNAL_SDL_RenderCopyEx(renderer.Validate(), texture.Validate(), srcRect.Validate(), ref dst, angle, ref center, flip);

        /// <summary>
        ///     Sdl the render copy ex f using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="texture">The texture</param>
        /// <param name="srcRect">The src rect</param>
        /// <param name="dstRect">The dst rect</param>
        /// <param name="angle">The angle</param>
        /// <param name="center">The center</param>
        /// <param name="flip">The flip</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_RenderCopyExF", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern int INTERNAL_SDL_RenderCopyExF([NotNull] IntPtr renderer, [NotNull] IntPtr texture, ref RectangleI srcRect, [NotNull] IntPtr dstRect, double angle, ref PointF center, SdlRendererFlip flip);

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
        public static int RenderCopyExF([NotNull] IntPtr renderer, [NotNull] IntPtr texture, ref RectangleI srcRect, [NotNull] IntPtr dstRect, double angle, ref PointF center, SdlRendererFlip flip) => INTERNAL_SDL_RenderCopyExF(renderer.Validate(), texture.Validate(), ref srcRect, dstRect.Validate(), angle, ref center, flip);

        /// <summary>
        ///     Sdl the render copy ex f using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="texture">The texture</param>
        /// <param name="srcRect">The src rect</param>
        /// <param name="dst">The dst rect</param>
        /// <param name="angle">The angle</param>
        /// <param name="center">The center</param>
        /// <param name="flip">The flip</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_RenderCopyExF", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern int INTERNAL_SDL_RenderCopyExF([NotNull] IntPtr renderer, [NotNull] IntPtr texture, ref RectangleI srcRect, ref RectangleF dst, double angle, [NotNull] IntPtr center, SdlRendererFlip flip);

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
        public static int RenderCopyExF([NotNull] IntPtr renderer, [NotNull] IntPtr texture, ref RectangleI srcRect, ref RectangleF dst, double angle, [NotNull] IntPtr center, SdlRendererFlip flip) => INTERNAL_SDL_RenderCopyExF(renderer.Validate(), texture.Validate(), ref srcRect, ref dst, angle, center.Validate(), flip);

        /// <summary>
        ///     Sdl the render copy ex f using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="texture">The texture</param>
        /// <param name="srcRect">The src rect</param>
        /// <param name="dstRect">The dst rect</param>
        /// <param name="angle">The angle</param>
        /// <param name="center">The center</param>
        /// <param name="flip">The flip</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_RenderCopyExF", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern int INTERNAL_SDL_RenderCopyExF([NotNull] IntPtr renderer, [NotNull] IntPtr texture, [NotNull] IntPtr srcRect, [NotNull] IntPtr dstRect, double angle, ref PointF center, SdlRendererFlip flip);

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
        public static int RenderCopyExF([NotNull] IntPtr renderer, [NotNull] IntPtr texture, [NotNull] IntPtr srcRect, [NotNull] IntPtr dstRect, double angle, ref PointF center, SdlRendererFlip flip) => INTERNAL_SDL_RenderCopyExF(renderer.Validate(), texture.Validate(), srcRect.Validate(), dstRect.Validate(), angle, ref center, flip);


        /// <summary>
        ///     Sdl the render copy ex f using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="texture">The texture</param>
        /// <param name="srcRect">The src rect</param>
        /// <param name="dst">The dst rect</param>
        /// <param name="angle">The angle</param>
        /// <param name="center">The center</param>
        /// <param name="flip">The flip</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_RenderCopyExF", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern int INTERNAL_SDL_RenderCopyExF([NotNull] IntPtr renderer, [NotNull] IntPtr texture, [NotNull] IntPtr srcRect, ref RectangleF dst, double angle, [NotNull] IntPtr center, SdlRendererFlip flip);

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
        public static int RenderCopyExF([NotNull] IntPtr renderer, [NotNull] IntPtr texture, [NotNull] IntPtr srcRect, ref RectangleF dst, double angle, [NotNull] IntPtr center, SdlRendererFlip flip) => INTERNAL_SDL_RenderCopyExF(renderer.Validate(), texture.Validate(), srcRect.Validate(), ref dst, angle, center.Validate(), flip);


        /// <summary>
        ///     Sdl the render copy ex f using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="texture">The texture</param>
        /// <param name="srcRect">The src rect</param>
        /// <param name="dstRect">The dst rect</param>
        /// <param name="angle">The angle</param>
        /// <param name="center">The center</param>
        /// <param name="flip">The flip</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_RenderCopyExF", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern int INTERNAL_SDL_RenderCopyExF([NotNull] IntPtr renderer, [NotNull] IntPtr texture, ref RectangleI srcRect, [NotNull] IntPtr dstRect, double angle, [NotNull] IntPtr center, SdlRendererFlip flip);

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
        public static int RenderCopyExF([NotNull] IntPtr renderer, [NotNull] IntPtr texture, ref RectangleI srcRect, [NotNull] IntPtr dstRect, double angle, [NotNull] IntPtr center, SdlRendererFlip flip) => INTERNAL_SDL_RenderCopyExF(renderer.Validate(), texture.Validate(), ref srcRect, dstRect.Validate(), angle, center.Validate(), flip);


        /// <summary>
        ///     Sdl the render copy ex f using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="texture">The texture</param>
        /// <param name="srcRect">The src rect</param>
        /// <param name="dstRect">The dst rect</param>
        /// <param name="angle">The angle</param>
        /// <param name="center">The center</param>
        /// <param name="flip">The flip</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_RenderCopyExF", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern int INTERNAL_SDL_RenderCopyExF([NotNull] IntPtr renderer, [NotNull] IntPtr texture, [NotNull] IntPtr srcRect, [NotNull] IntPtr dstRect, double angle, [NotNull] IntPtr center, SdlRendererFlip flip);

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
        public static int RenderCopyExF([NotNull] IntPtr renderer, [NotNull] IntPtr texture, [NotNull] IntPtr srcRect, [NotNull] IntPtr dstRect, double angle, [NotNull] IntPtr center, SdlRendererFlip flip) => INTERNAL_SDL_RenderCopyExF(renderer.Validate(), texture.Validate(), srcRect.Validate(), dstRect.Validate(), angle, center.Validate(), flip);


        /// <summary>
        ///     Sdl the render geometry using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="texture">The texture</param>
        /// <param name="vertices">The vertices</param>
        /// <param name="numVertices">The num vertices</param>
        /// <param name="indices">The indices</param>
        /// <param name="numIndices">The num indices</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_RenderGeometry", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern int INTERNAL_SDL_RenderGeometry([NotNull] IntPtr renderer, [NotNull] IntPtr texture, [In] SdlVertex[] vertices, [NotNull] int numVertices, [In] [NotNull] int[] indices, [NotNull] int numIndices);

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
        public static int RenderGeometry([NotNull] IntPtr renderer, [NotNull] IntPtr texture, [In] SdlVertex[] vertices, [NotNull] int numVertices, [In] [NotNull] int[] indices, [NotNull] int numIndices) => INTERNAL_SDL_RenderGeometry(renderer.Validate(), texture.Validate(), vertices, numVertices, indices, numIndices);


        /// <summary>
        ///     Sdl the render geometry raw using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="texture">The texture</param>
        /// <param name="xy">The xy</param>
        /// <param name="xyStride">The xy stride</param>
        /// <param name="color">The color</param>
        /// <param name="colorStride">The color stride</param>
        /// <param name="uv">The uv</param>
        /// <param name="uvStride">The uv stride</param>
        /// <param name="numVertices">The num vertices</param>
        /// <param name="indices">The indices</param>
        /// <param name="numIndices">The num indices</param>
        /// <param name="sizeIndices">The size indices</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_RenderGeometryRaw", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern int INTERNAL_SDL_RenderGeometryRaw([NotNull] IntPtr renderer, [NotNull] IntPtr texture, [In] float[] xy, [NotNull] int xyStride, [In] [NotNull] int[] color, [NotNull] int colorStride, [In] float[] uv, [NotNull] int uvStride, [NotNull] int numVertices, [NotNull] IntPtr indices, [NotNull] int numIndices, [NotNull] int sizeIndices);

        /// <summary>
        ///     Renders the geometry raw using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="texture">The texture</param>
        /// <param name="xy">The xy</param>
        /// <param name="xyStride">The xy stride</param>
        /// <param name="color">The color</param>
        /// <param name="colorStride">The color stride</param>
        /// <param name="uv">The uv</param>
        /// <param name="uvStride">The uv stride</param>
        /// <param name="numVertices">The num vertices</param>
        /// <param name="indices">The indices</param>
        /// <param name="numIndices">The num indices</param>
        /// <param name="sizeIndices">The size indices</param>
        /// <returns>The int</returns>
        [return: NotNull]
        public static int RenderGeometryRaw([NotNull] IntPtr renderer, [NotNull] IntPtr texture, [In] float[] xy, [NotNull] int xyStride, [In] [NotNull] int[] color, [NotNull] int colorStride, [In] float[] uv, [NotNull] int uvStride, [NotNull] int numVertices, [NotNull] IntPtr indices, [NotNull] int numIndices, [NotNull] int sizeIndices)
            => INTERNAL_SDL_RenderGeometryRaw(renderer.Validate(), texture.Validate(), xy, xyStride, color, colorStride, uv, uvStride, numVertices, indices, numIndices, sizeIndices);

        /// <summary>
        ///     Sdl the render draw point f using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="x">The </param>
        /// <param name="y">The </param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_RenderDrawPointF", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern int INTERNAL_SDL_RenderDrawPointF([NotNull] IntPtr renderer, float x, float y);

        /// <summary>
        ///     Renders the draw point f using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="x">The </param>
        /// <param name="y">The </param>
        /// <returns>The int</returns>
        [return: NotNull]
        public static int RenderDrawPointF([NotNull] IntPtr renderer, float x, float y) => INTERNAL_SDL_RenderDrawPointF(renderer.Validate(), x, y);

        /// <summary>
        ///     Sdl the render draw points f using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="points">The points</param>
        /// <param name="count">The count</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_RenderDrawPointsF", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern int INTERNAL_SDL_RenderDrawPointsF(IntPtr renderer, [In] PointF[] points, [NotNull] int count);

        /// <summary>
        ///     Renders the draw points f using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="points">The points</param>
        /// <param name="count">The count</param>
        /// <returns>The int</returns>
        [return: NotNull]
        public static int RenderDrawPointsF(IntPtr renderer, [In] PointF[] points, [NotNull] int count) => INTERNAL_SDL_RenderDrawPointsF(renderer.Validate(), points, count);

        /// <summary>
        ///     Sdl the render draw line f using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="x1">The </param>
        /// <param name="y1">The </param>
        /// <param name="x2">The </param>
        /// <param name="y2">The </param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_RenderDrawLineF", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern int INTERNAL_SDL_RenderDrawLineF([NotNull] IntPtr renderer, float x1, float y1, float x2, float y2);

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
        public static int RenderDrawLineF([NotNull] IntPtr renderer, float x1, float y1, float x2, float y2) => INTERNAL_SDL_RenderDrawLineF(renderer.Validate(), x1, y1, x2, y2);


        /// <summary>
        ///     Sdl the render draw lines f using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="points">The points</param>
        /// <param name="count">The count</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_RenderDrawLinesF", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern int INTERNAL_SDL_RenderDrawLinesF([NotNull] IntPtr renderer, [In] PointF[] points, [NotNull] int count);

        /// <summary>
        ///     Renders the draw lines f using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="points">The points</param>
        /// <param name="count">The count</param>
        /// <returns>The int</returns>
        [return: NotNull]
        public static int RenderDrawLinesF([NotNull] IntPtr renderer, [In] PointF[] points, [NotNull] int count) => INTERNAL_SDL_RenderDrawLinesF(renderer.Validate(), points, count);


        /// <summary>
        ///     Sdl the render draw rect f using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="rect">The rect</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_RenderDrawRectF", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern int INTERNAL_SDL_RenderDrawRectF([NotNull] IntPtr renderer, ref RectangleF rect);

        /// <summary>
        ///     Renders the draw rect f using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="rect">The rect</param>
        /// <returns>The int</returns>
        [return: NotNull]
        public static int RenderDrawRectF([NotNull] IntPtr renderer, ref RectangleF rect) => INTERNAL_SDL_RenderDrawRectF(renderer.Validate(), ref rect);


        /// <summary>
        ///     Sdl the render draw rect f using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="rect">The rect</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_RenderDrawRectF", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern int INTERNAL_SDL_RenderDrawRectF([NotNull] IntPtr renderer, [NotNull] IntPtr rect);

        /// <summary>
        ///     Renders the draw rect f using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="rect">The rect</param>
        /// <returns>The int</returns>
        [return: NotNull]
        public static int RenderDrawRectF([NotNull] IntPtr renderer, [NotNull] IntPtr rect) => INTERNAL_SDL_RenderDrawRectF(renderer.Validate(), rect);


        /// <summary>
        ///     Sdl the render draw rects f using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="rects">The rects</param>
        /// <param name="count">The count</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_RenderDrawRectsF", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern int INTERNAL_SDL_RenderDrawRectsF([NotNull] IntPtr renderer, [In] RectangleF[] rects, [NotNull] int count);

        /// <summary>
        ///     Renders the draw rects f using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="rects">The rects</param>
        /// <param name="count">The count</param>
        /// <returns>The int</returns>
        [return: NotNull]
        public static int RenderDrawRectsF([NotNull] IntPtr renderer, [In] RectangleF[] rects, [NotNull] int count) => INTERNAL_SDL_RenderDrawRectsF(renderer.Validate(), rects, count);


        /// <summary>
        ///     Sdl the render fill rect f using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="rect">The rect</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_RenderFillRectF", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern int INTERNAL_SDL_RenderFillRectF([NotNull] IntPtr renderer, RectangleF rect);

        /// <summary>
        ///     Renders the fill rect f using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="rect">The rect</param>
        /// <returns>The int</returns>
        [return: NotNull]
        public static int RenderFillRectF([NotNull] IntPtr renderer, RectangleF rect) => INTERNAL_SDL_RenderFillRectF(renderer.Validate(), rect);

        /// <summary>
        ///     Sdl the render fill rect f using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="rect">The rect</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_RenderFillRectF", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern int INTERNAL_SDL_RenderFillRectF([NotNull] IntPtr renderer, [NotNull] IntPtr rect);

        /// <summary>
        ///     Renders the fill rect f using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="rect">The rect</param>
        /// <returns>The int</returns>
        [return: NotNull]
        public static int RenderFillRectF([NotNull] IntPtr renderer, [NotNull] IntPtr rect) => INTERNAL_SDL_RenderFillRectF(renderer.Validate(), rect);

        /// <summary>
        ///     Sdl the render fill rects f using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="rects">The rects</param>
        /// <param name="count">The count</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_RenderFillRectsF", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern int INTERNAL_SDL_RenderFillRectsF([NotNull] IntPtr renderer, [In] RectangleF[] rects, [NotNull] int count);

        /// <summary>
        ///     Renders the fill rects f using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="rects">The rects</param>
        /// <param name="count">The count</param>
        /// <returns>The int</returns>
        [return: NotNull]
        public static int RenderFillRectsF([NotNull] IntPtr renderer, [In] RectangleF[] rects, [NotNull] int count) => INTERNAL_SDL_RenderFillRectsF(renderer.Validate(), rects, count);


        /// <summary>
        ///     Sdl the render get clip rect using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="rect">The rect</param>
        [DllImport(NativeLibName, EntryPoint = "SDL_RenderGetClipRect", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern void INTERNAL_SDL_RenderGetClipRect([NotNull] IntPtr renderer, out RectangleI rect);

        /// <summary>
        ///     Renders the get clip rect using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="rect">The rect</param>
        [return: NotNull]
        public static void RenderGetClipRect([NotNull] IntPtr renderer, out RectangleI rect) => INTERNAL_SDL_RenderGetClipRect(renderer.Validate(), out rect);


        /// <summary>
        ///     Sdl the render get logical size using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="w">The </param>
        /// <param name="h">The </param>
        [DllImport(NativeLibName, EntryPoint = "SDL_RenderGetLogicalSize", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern void INTERNAL_SDL_RenderGetLogicalSize([NotNull] IntPtr renderer, out int w, out int h);

        /// <summary>
        ///     Renders the get logical size using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="w">The </param>
        /// <param name="h">The </param>
        [return: NotNull]
        public static void RenderGetLogicalSize([NotNull] IntPtr renderer, out int w, out int h) => INTERNAL_SDL_RenderGetLogicalSize(renderer.Validate(), out w, out h);


        /// <summary>
        ///     Sdl the render get scale using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="scaleX">The scale</param>
        /// <param name="scaleY">The scale</param>
        [DllImport(NativeLibName, EntryPoint = "SDL_RenderGetScale", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern void INTERNAL_SDL_RenderGetScale([NotNull] IntPtr renderer, out float scaleX, out float scaleY);

        /// <summary>
        ///     Renders the get scale using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="scaleX">The scale</param>
        /// <param name="scaleY">The scale</param>
        [return: NotNull]
        public static void RenderGetScale([NotNull] IntPtr renderer, out float scaleX, out float scaleY) => INTERNAL_SDL_RenderGetScale(renderer.Validate(), out scaleX, out scaleY);


        /// <summary>
        ///     Sdl the render window to logical using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="windowX">The window</param>
        /// <param name="windowY">The window</param>
        /// <param name="logicalX">The logical</param>
        /// <param name="logicalY">The logical</param>
        [DllImport(NativeLibName, EntryPoint = "SDL_RenderWindowToLogical", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern void INTERNAL_SDL_RenderWindowToLogical([NotNull] IntPtr renderer, [NotNull] int windowX, [NotNull] int windowY, out float logicalX, out float logicalY);

        /// <summary>
        ///     Renders the window to logical using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="windowX">The window</param>
        /// <param name="windowY">The window</param>
        /// <param name="logicalX">The logical</param>
        /// <param name="logicalY">The logical</param>
        [return: NotNull]
        public static void RenderWindowToLogical([NotNull] IntPtr renderer, [NotNull] int windowX, [NotNull] int windowY, out float logicalX, out float logicalY) => INTERNAL_SDL_RenderWindowToLogical(renderer.Validate(), windowX, windowY, out logicalX, out logicalY);


        /// <summary>
        ///     Sdl the render logical to window using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="logicalX">The logical</param>
        /// <param name="logicalY">The logical</param>
        /// <param name="windowX">The window</param>
        /// <param name="windowY">The window</param>
        [DllImport(NativeLibName, EntryPoint = "SDL_RenderLogicalToWindow", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern void INTERNAL_SDL_RenderLogicalToWindow([NotNull] IntPtr renderer, float logicalX, float logicalY, out int windowX, out int windowY);

        /// <summary>
        ///     Renders the logical to window using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="logicalX">The logical</param>
        /// <param name="logicalY">The logical</param>
        /// <param name="windowX">The window</param>
        /// <param name="windowY">The window</param>
        [return: NotNull]
        public static void RenderLogicalToWindow([NotNull] IntPtr renderer, float logicalX, float logicalY, out int windowX, out int windowY) => INTERNAL_SDL_RenderLogicalToWindow(renderer.Validate(), logicalX, logicalY, out windowX, out windowY);


        /// <summary>
        ///     Sdl the render get viewport using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="rect">The rect</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_RenderGetViewport", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern int INTERNAL_SDL_RenderGetViewport([NotNull] IntPtr renderer, out RectangleI rect);

        /// <summary>
        ///     Renders the get viewport using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="rect">The rect</param>
        /// <returns>The int</returns>
        [return: NotNull]
        public static int RenderGetViewport([NotNull] IntPtr renderer, out RectangleI rect) => INTERNAL_SDL_RenderGetViewport(renderer.Validate(), out rect);

        /// <summary>
        ///     Sdl the render present using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        [DllImport(NativeLibName, EntryPoint = "SDL_RenderPresent", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern void INTERNAL_SDL_RenderPresent(IntPtr renderer);

        /// <summary>
        ///     Renders the present using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        [return: NotNull]
        public static void RenderPresent(IntPtr renderer) => INTERNAL_SDL_RenderPresent(renderer);
        
        /// <summary>
        ///     Sdl the render read pixels using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="rect">The rect</param>
        /// <param name="format">The format</param>
        /// <param name="pixels">The pixels</param>
        /// <param name="pitch">The pitch</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_RenderReadPixels", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern int INTERNAL_SDL_RenderReadPixels([NotNull] IntPtr renderer, ref RectangleI rect, [NotNull] uint format, [NotNull] IntPtr pixels, [NotNull] int pitch);

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
        public static int RenderReadPixels([NotNull] IntPtr renderer, ref RectangleI rect, [NotNull] uint format, [NotNull] IntPtr pixels, [NotNull] int pitch) => INTERNAL_SDL_RenderReadPixels(renderer.Validate(), ref rect, format, pixels, pitch);


        /// <summary>
        ///     Sdl the render set clip rect using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="rect">The rect</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_RenderSetClipRect", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern int INTERNAL_SDL_RenderSetClipRect([NotNull] IntPtr renderer, ref RectangleI rect);

        /// <summary>
        ///     Renders the set clip rect using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="rect">The rect</param>
        /// <returns>The int</returns>
        [return: NotNull]
        public static int RenderSetClipRect([NotNull] IntPtr renderer, ref RectangleI rect) => INTERNAL_SDL_RenderSetClipRect(renderer.Validate(), ref rect);


        /// <summary>
        ///     Sdl the render set clip rect using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="rect">The rect</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_RenderSetClipRect", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern int INTERNAL_SDL_RenderSetClipRect([NotNull] IntPtr renderer, [NotNull] IntPtr rect);

        /// <summary>
        ///     Renders the set clip rect using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="rect">The rect</param>
        /// <returns>The int</returns>
        [return: NotNull]
        public static int RenderSetClipRect([NotNull] IntPtr renderer, [NotNull] IntPtr rect) => INTERNAL_SDL_RenderSetClipRect(renderer.Validate(), rect);


        /// <summary>
        ///     Sdl the render set logical size using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="w">The </param>
        /// <param name="h">The </param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_RenderSetLogicalSize", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern int INTERNAL_SDL_RenderSetLogicalSize([NotNull] IntPtr renderer, [NotNull] int w, [NotNull] int h);

        /// <summary>
        ///     Renders the set logical size using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="w">The </param>
        /// <param name="h">The </param>
        /// <returns>The int</returns>
        [return: NotNull]
        public static int RenderSetLogicalSize([NotNull] IntPtr renderer, [NotNull] int w, [NotNull] int h) => INTERNAL_SDL_RenderSetLogicalSize(renderer.Validate(), w, h);


        /// <summary>
        ///     Sdl the render set scale using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="scaleX">The scale</param>
        /// <param name="scaleY">The scale</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_RenderSetScale", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern int INTERNAL_SDL_RenderSetScale([NotNull] IntPtr renderer, float scaleX, float scaleY);

        /// <summary>
        ///     Renders the set scale using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="scaleX">The scale</param>
        /// <param name="scaleY">The scale</param>
        /// <returns>The int</returns>
        [return: NotNull]
        public static int RenderSetScale([NotNull] IntPtr renderer, float scaleX, float scaleY) => INTERNAL_SDL_RenderSetScale(renderer.Validate(), scaleX, scaleY);


        /// <summary>
        ///     Sdl the render set integer scale using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="enable">The enable</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_RenderSetIntegerScale", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern int INTERNAL_SDL_RenderSetIntegerScale([NotNull] IntPtr renderer, SdlBool enable);

        /// <summary>
        ///     Renders the set integer scale using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="enable">The enable</param>
        /// <returns>The int</returns>
        [return: NotNull]
        public static int RenderSetIntegerScale([NotNull] IntPtr renderer, SdlBool enable) => INTERNAL_SDL_RenderSetIntegerScale(renderer.Validate(), enable);

        /// <summary>
        ///     Sdl the render set viewport using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="rect">The rect</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_RenderSetViewport", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern int INTERNAL_SDL_RenderSetViewport([NotNull] IntPtr renderer, ref RectangleI rect);

        /// <summary>
        ///     Renders the set viewport using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="rect">The rect</param>
        /// <returns>The int</returns>
        [return: NotNull]
        public static int RenderSetViewport([NotNull] IntPtr renderer, ref RectangleI rect) => INTERNAL_SDL_RenderSetViewport(renderer.Validate(), ref rect);


        /// <summary>
        ///     Sdl the set render draw blend mode using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="blendMode">The blend mode</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_SetRenderDrawBlendMode", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern int INTERNAL_SDL_SetRenderDrawBlendMode([NotNull] IntPtr renderer, SdlBlendMode blendMode);

        /// <summary>
        ///     Sets the render draw blend mode using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="blendMode">The blend mode</param>
        /// <returns>The int</returns>
        [return: NotNull]
        public static int SetRenderDrawBlendMode([NotNull] IntPtr renderer, SdlBlendMode blendMode) => INTERNAL_SDL_SetRenderDrawBlendMode(renderer.Validate(), blendMode);

        /// <summary>
        ///     Sdl the set render draw color using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="r">The </param>
        /// <param name="g">The </param>
        /// <param name="b">The </param>
        /// <param name="a">The </param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_SetRenderDrawColor", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern int INTERNAL_SDL_SetRenderDrawColor([NotNull] IntPtr renderer, [NotNull] byte r, [NotNull] byte g, [NotNull] byte b, [NotNull] byte a);

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
        public static int SetRenderDrawColor([NotNull] IntPtr renderer, [NotNull] byte r, [NotNull] byte g, [NotNull] byte b, [NotNull] byte a) => INTERNAL_SDL_SetRenderDrawColor(renderer.Validate(), r, g, b, a);


        /// <summary>
        ///     Sdl the set render target using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="texture">The texture</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_SetRenderTarget", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern int INTERNAL_SDL_SetRenderTarget([NotNull] IntPtr renderer, [NotNull] IntPtr texture);

        /// <summary>
        ///     Sets the render target using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="texture">The texture</param>
        /// <returns>The int</returns>
        [return: NotNull]
        public static int SetRenderTarget([NotNull] IntPtr renderer, [NotNull] IntPtr texture) => INTERNAL_SDL_SetRenderTarget(renderer.Validate(), texture.Validate());

        /// <summary>
        ///     Sdl the set texture alpha mod using the specified texture
        /// </summary>
        /// <param name="texture">The texture</param>
        /// <param name="alpha">The alpha</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_SetTextureAlphaMod", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern int INTERNAL_SDL_SetTextureAlphaMod([NotNull] IntPtr texture, [NotNull] byte alpha);

        /// <summary>
        ///     Sets the texture alpha mod using the specified texture
        /// </summary>
        /// <param name="texture">The texture</param>
        /// <param name="alpha">The alpha</param>
        /// <returns>The int</returns>
        [return: NotNull]
        public static int SetTextureAlphaMod([NotNull] IntPtr texture, [NotNull] byte alpha) => INTERNAL_SDL_SetTextureAlphaMod(texture.Validate(), alpha);


        /// <summary>
        ///     Sdl the set texture blend mode using the specified texture
        /// </summary>
        /// <param name="texture">The texture</param>
        /// <param name="blendMode">The blend mode</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_SetTextureBlendMode", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern int INTERNAL_SDL_SetTextureBlendMode([NotNull] IntPtr texture, SdlBlendMode blendMode);

        /// <summary>
        ///     Sets the texture blend mode using the specified texture
        /// </summary>
        /// <param name="texture">The texture</param>
        /// <param name="blendMode">The blend mode</param>
        /// <returns>The int</returns>
        [return: NotNull]
        public static int SetTextureBlendMode([NotNull] IntPtr texture, SdlBlendMode blendMode) => INTERNAL_SDL_SetTextureBlendMode(texture.Validate(), blendMode);


        /// <summary>
        ///     Sdl the set texture color mod using the specified texture
        /// </summary>
        /// <param name="texture">The texture</param>
        /// <param name="r">The </param>
        /// <param name="g">The </param>
        /// <param name="b">The </param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_SetTextureColorMod", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern int INTERNAL_SDL_SetTextureColorMod([NotNull] IntPtr texture, [NotNull] byte r, [NotNull] byte g, [NotNull] byte b);

        /// <summary>
        ///     Sets the texture color mod using the specified texture
        /// </summary>
        /// <param name="texture">The texture</param>
        /// <param name="r">The </param>
        /// <param name="g">The </param>
        /// <param name="b">The </param>
        /// <returns>The int</returns>
        [return: NotNull]
        public static int SetTextureColorMod([NotNull] IntPtr texture, [NotNull] byte r, [NotNull] byte g, [NotNull] byte b) => INTERNAL_SDL_SetTextureColorMod(texture.Validate(), r, g, b);


        /// <summary>
        ///     Sdl the unlock texture using the specified texture
        /// </summary>
        /// <param name="texture">The texture</param>
        [DllImport(NativeLibName, EntryPoint = "SDL_UnlockTexture", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern void INTERNAL_SDL_UnlockTexture([NotNull] IntPtr texture);

        /// <summary>
        ///     Unlocks the texture using the specified texture
        /// </summary>
        /// <param name="texture">The texture</param>
        [return: NotNull]
        public static void UnlockTexture([NotNull] IntPtr texture) => INTERNAL_SDL_UnlockTexture(texture.Validate());

        /// <summary>
        ///     Sdl the update texture using the specified texture
        /// </summary>
        /// <param name="texture">The texture</param>
        /// <param name="rect">The rect</param>
        /// <param name="pixels">The pixels</param>
        /// <param name="pitch">The pitch</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_UpdateTexture", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern int INTERNAL_SDL_UpdateTexture([NotNull] IntPtr texture, ref RectangleI rect, [NotNull] IntPtr pixels, [NotNull] int pitch);

        /// <summary>
        ///     Updates the texture using the specified texture
        /// </summary>
        /// <param name="texture">The texture</param>
        /// <param name="rect">The rect</param>
        /// <param name="pixels">The pixels</param>
        /// <param name="pitch">The pitch</param>
        /// <returns>The int</returns>
        [return: NotNull]
        public static int UpdateTexture([NotNull] IntPtr texture, ref RectangleI rect, [NotNull] IntPtr pixels, [NotNull] int pitch) => INTERNAL_SDL_UpdateTexture(texture.Validate(), ref rect, pixels, pitch);

        /// <summary>
        ///     Sdl the update texture using the specified texture
        /// </summary>
        /// <param name="texture">The texture</param>
        /// <param name="rect">The rect</param>
        /// <param name="pixels">The pixels</param>
        /// <param name="pitch">The pitch</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_UpdateTexture", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern int INTERNAL_SDL_UpdateTexture([NotNull] IntPtr texture, [NotNull] IntPtr rect, [NotNull] IntPtr pixels, [NotNull] int pitch);

        /// <summary>
        ///     Updates the texture using the specified texture
        /// </summary>
        /// <param name="texture">The texture</param>
        /// <param name="rect">The rect</param>
        /// <param name="pixels">The pixels</param>
        /// <param name="pitch">The pitch</param>
        /// <returns>The int</returns>
        [return: NotNull]
        public static int UpdateTexture([NotNull] IntPtr texture, [NotNull] IntPtr rect, [NotNull] IntPtr pixels, [NotNull] int pitch) => INTERNAL_SDL_UpdateTexture(texture.Validate(), rect, pixels, pitch);

        /// <summary>
        ///     Sdl the update yuv texture using the specified texture
        /// </summary>
        /// <param name="texture">The texture</param>
        /// <param name="rect">The rect</param>
        /// <param name="yPlane">The plane</param>
        /// <param name="yPitch">The pitch</param>
        /// <param name="uPlane">The plane</param>
        /// <param name="uPitch">The pitch</param>
        /// <param name="vPlane">The plane</param>
        /// <param name="vPitch">The pitch</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_UpdateYUVTexture", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern int INTERNAL_SDL_UpdateYUVTexture([NotNull] IntPtr texture, ref RectangleI rect, [NotNull] IntPtr yPlane, [NotNull] int yPitch, [NotNull] IntPtr uPlane, [NotNull] int uPitch, [NotNull] IntPtr vPlane, [NotNull] int vPitch);

        /// <summary>
        ///     Updates the yuv texture using the specified texture
        /// </summary>
        /// <param name="texture">The texture</param>
        /// <param name="rect">The rect</param>
        /// <param name="yPlane">The plane</param>
        /// <param name="yPitch">The pitch</param>
        /// <param name="uPlane">The plane</param>
        /// <param name="uPitch">The pitch</param>
        /// <param name="vPlane">The plane</param>
        /// <param name="vPitch">The pitch</param>
        /// <returns>The int</returns>
        [return: NotNull]
        public static int UpdateYuvTexture([NotNull] IntPtr texture, ref RectangleI rect, [NotNull] IntPtr yPlane, [NotNull] int yPitch, [NotNull] IntPtr uPlane, [NotNull] int uPitch, [NotNull] IntPtr vPlane, [NotNull] int vPitch) => INTERNAL_SDL_UpdateYUVTexture(texture, ref rect, yPlane, yPitch, uPlane, uPitch, vPlane, vPitch);

        /// <summary>
        ///     Sdl the update nv texture using the specified texture
        /// </summary>
        /// <param name="texture">The texture</param>
        /// <param name="rect">The rect</param>
        /// <param name="yPlane">The plane</param>
        /// <param name="yPitch">The pitch</param>
        /// <param name="uvPlane">The uv plane</param>
        /// <param name="uvPitch">The uv pitch</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_UpdateNVTexture", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern int INTERNAL_SDL_UpdateNVTexture([NotNull] IntPtr texture, ref RectangleI rect, [NotNull] IntPtr yPlane, [NotNull] int yPitch, [NotNull] IntPtr uvPlane, [NotNull] int uvPitch);

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
        public static int UpdateNvTexture([NotNull] IntPtr texture, ref RectangleI rect, [NotNull] IntPtr yPlane, [NotNull] int yPitch, [NotNull] IntPtr uvPlane, [NotNull] int uvPitch) => INTERNAL_SDL_UpdateNVTexture(texture.Validate(), ref rect, yPlane, yPitch, uvPlane, uvPitch);

        /// <summary>
        ///     Sdl the render target supported using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <returns>The sdl bool</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_RenderTargetSupported", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern SdlBool INTERNAL_SDL_RenderTargetSupported([NotNull] IntPtr renderer);

        /// <summary>
        ///     Renders the target supported using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <returns>The sdl bool</returns>
        [return: NotNull]
        public static SdlBool RenderTargetSupported([NotNull] IntPtr renderer) => INTERNAL_SDL_RenderTargetSupported(renderer.Validate());

        /// <summary>
        ///     Sdl the get render target using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GetRenderTarget", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern IntPtr INTERNAL_SDL_GetRenderTarget([NotNull] IntPtr renderer);

        /// <summary>
        ///     Gets the render target using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <returns>The int ptr</returns>
        [return: NotNull]
        public static IntPtr GetRenderTarget([NotNull] IntPtr renderer) => INTERNAL_SDL_GetRenderTarget(renderer.Validate());

        /// <summary>
        ///     Sdl the render get metal layer using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_RenderGetMetalLayer", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern IntPtr INTERNAL_SDL_RenderGetMetalLayer([NotNull] IntPtr renderer);

        /// <summary>
        ///     Renders the get metal layer using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <returns>The int ptr</returns>
        [return: NotNull]
        public static IntPtr RenderGetMetalLayer([NotNull] IntPtr renderer) => INTERNAL_SDL_RenderGetMetalLayer(renderer.Validate());

        /// <summary>
        ///     Sdl the render get metal command encoder using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_RenderGetMetalCommandEncoder", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern IntPtr INTERNAL_SDL_RenderGetMetalCommandEncoder([NotNull] IntPtr renderer);

        /// <summary>
        ///     Renders the get metal command encoder using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <returns>The int ptr</returns>
        [return: NotNull]
        public static IntPtr RenderGetMetalCommandEncoder([NotNull] IntPtr renderer) => INTERNAL_SDL_RenderGetMetalCommandEncoder(renderer.Validate());

        /// <summary>
        ///     Sdl the render set v sync using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="vsync">The vsync</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_RenderSetVSync", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern int INTERNAL_SDL_RenderSetVSync([NotNull] IntPtr renderer, [NotNull] int vsync);

        /// <summary>
        ///     Renders the set v sync using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="vsync">The vsync</param>
        /// <returns>The int</returns>
        [return: NotNull]
        public static int RenderSetVSync([NotNull] IntPtr renderer, [NotNull] int vsync) => INTERNAL_SDL_RenderSetVSync(renderer.Validate(), vsync);

        /// <summary>
        ///     Sdl the render is clip enabled using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <returns>The sdl bool</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_RenderIsClipEnabled", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern SdlBool INTERNAL_SDL_RenderIsClipEnabled([NotNull] IntPtr renderer);

        /// <summary>
        ///     Renders the is clip enabled using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <returns>The sdl bool</returns>
        [return: NotNull]
        public static SdlBool RenderIsClipEnabled([NotNull] IntPtr renderer) => INTERNAL_SDL_RenderIsClipEnabled(renderer.Validate());

        /// <summary>
        ///     Sdl the render flush using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_RenderFlush", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern int INTERNAL_SDL_RenderFlush([NotNull] IntPtr renderer);

        /// <summary>
        ///     Renders the flush using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <returns>The int</returns>
        [return: NotNull]
        public static int RenderFlush([NotNull] IntPtr renderer) => INTERNAL_SDL_RenderFlush(renderer.Validate());

        /// <summary>
        ///     Sdl the define pixel fourcc using the specified a
        /// </summary>
        /// <param name="a">The </param>
        /// <param name="b">The </param>
        /// <param name="c">The </param>
        /// <param name="d">The </param>
        /// <returns>The uint</returns>
        [return: NotNull]
        private static uint SdlDefinePixelFourcc([NotNull] byte a, [NotNull] byte b, [NotNull] byte c, [NotNull] byte d) => Fourcc(a, b, c, d);

        /// <summary>
        ///     Sdl the define pixel format using the specified type
        /// </summary>
        /// <param name="type">The type</param>
        /// <param name="order">The order</param>
        /// <param name="layout">The layout</param>
        /// <param name="bits">The bits</param>
        /// <param name="bytes">The bytes</param>
        /// <returns>The uint</returns>
        [return: NotNull]
        private static uint SdlDefinePixelFormat(Type type, [NotNull] uint order, PackedLayout layout, [NotNull] byte bits, [NotNull] byte bytes) => (uint) ((1 << 28) | ((byte) type << 24) | ((byte) order << 20) | ((byte) layout << 16) | (bits << 8) | bytes);

        /// <summary>
        ///     Sdl the pixel flag using the specified x
        /// </summary>
        /// <param name="x">The </param>
        /// <returns>The byte</returns>
        [return: NotNull]
        private static byte SdlPixelFlag([NotNull] uint x) => (byte) ((x >> 28) & 0x0F);

        /// <summary>
        ///     Sdl the pixel type using the specified x
        /// </summary>
        /// <param name="x">The </param>
        /// <returns>The byte</returns>
        [return: NotNull]
        private static byte SdlPixelType([NotNull] uint x) => (byte) ((x >> 24) & 0x0F);

        /// <summary>
        ///     Sdl the pixel order using the specified x
        /// </summary>
        /// <param name="x">The </param>
        /// <returns>The byte</returns>
        [return: NotNull]
        private static byte SdlPixelOrder([NotNull] uint x) => (byte) ((x >> 20) & 0x0F);

        /// <summary>
        ///     Sdl the pixel layout using the specified x
        /// </summary>
        /// <param name="x">The </param>
        /// <returns>The byte</returns>
        [return: NotNull]
        public static byte SdlPixelLayout([NotNull] uint x) => (byte) ((x >> 16) & 0x0F);

        /// <summary>
        ///     Sdl the bits per pixel using the specified x
        /// </summary>
        /// <param name="x">The </param>
        /// <returns>The byte</returns>
        [return: NotNull]
        public static byte SdlBitsPerPixel([NotNull] uint x) => (byte) ((x >> 8) & 0xFF);

        /// <summary>
        ///     Sdl the bytes per pixel using the specified x
        /// </summary>
        /// <param name="x">The </param>
        /// <returns>The byte</returns>
        [return: NotNull]
        public static byte SdlBytesPerPixel([NotNull] uint x)
        {
            if (SdlIsPixelFormatFour(x))
            {
                if (x == FormatYuy2 ||
                    x == FormatUy ||
                    x == FormatYv)
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
        public static bool IsPixelFormatIndexed([NotNull] uint format)
        {
            if (SdlIsPixelFormatFour(format))
            {
                return false;
            }

            Type pType =
                (Type) SdlPixelType(format);
            return pType == Type.TypeIndex1 ||
                   pType == Type.TypeIndex4 ||
                   pType == Type.TypeIndex8;
        }

        /// <summary>
        ///     Describes whether sdl is pixel format packed
        /// </summary>
        /// <param name="format">The format</param>
        /// <returns>The bool</returns>
        [return: NotNull]
        private static bool SdlIsPixelFormatPacked([NotNull] uint format)
        {
            if (SdlIsPixelFormatFour(format))
            {
                return false;
            }

            Type pType =
                (Type) SdlPixelType(format);
            return pType == Type.TypePacked8 ||
                   pType == Type.TypePacked16 ||
                   pType == Type.TypePacked32;
        }

        /// <summary>
        ///     Describes whether sdl is pixel format array
        /// </summary>
        /// <param name="format">The format</param>
        /// <returns>The bool</returns>
        [return: NotNull]
        private static bool SdlIsPixelFormatArray([NotNull] uint format)
        {
            if (SdlIsPixelFormatFour(format))
            {
                return false;
            }

            Type pType =
                (Type) SdlPixelType(format);
            return pType == Type.TypeArrayU8 ||
                   pType == Type.TypeArrayU16 ||
                   pType == Type.TypeArrayU32 ||
                   pType == Type.TypeArrayF16 ||
                   pType == Type.TypeArrayF32;
        }

        /// <summary>
        ///     Describes whether sdl is pixel format alpha
        /// </summary>
        /// <param name="format">The format</param>
        /// <returns>The bool</returns>
        [return: NotNull]
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
                return aOrder == SdlArrayOrder.SdlArrayorderArgb ||
                       aOrder == SdlArrayOrder.SdlArrayorderRgba ||
                       aOrder == SdlArrayOrder.SdlArrayorderAbgr ||
                       aOrder == SdlArrayOrder.SdlArrayorderBgra;
            }

            return false;
        }

        /// <summary>
        ///     Describes whether sdl is pixel format fourcc
        /// </summary>
        /// <param name="format">The format</param>
        /// <returns>The bool</returns>
        [return: NotNull]
        private static bool SdlIsPixelFormatFour([NotNull] uint format) => (format == 0) && (SdlPixelFlag(format) != 1);

        /// <summary>
        ///     Sdl the alloc format using the specified pixel format
        /// </summary>
        /// <param name="pixelFormat">The pixel format</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_AllocFormat", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern IntPtr INTERNAL_SDL_AllocFormat([NotNull] uint pixelFormat);

        /// <summary>
        ///     Allow the format using the specified pixel format
        /// </summary>
        /// <param name="pixelFormat">The pixel format</param>
        /// <returns>The int ptr</returns>
        [return: NotNull]
        public static IntPtr AllocFormat([NotNull] uint pixelFormat) => INTERNAL_SDL_AllocFormat(pixelFormat.Validate());

        /// <summary>
        ///     Sdl the alloc palette using the specified n colors
        /// </summary>
        /// <param name="nColors">The n colors</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_AllocPalette", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern IntPtr INTERNAL_SDL_AllocPalette([NotNull] int nColors);

        /// <summary>
        ///     Allow the palette using the specified n colors
        /// </summary>
        /// <param name="nColors">The colors</param>
        /// <returns>The int ptr</returns>
        [return: NotNull]
        public static IntPtr AllocPalette([NotNull] int nColors) => INTERNAL_SDL_AllocPalette(nColors.Validate());

        /// <summary>
        ///     Sdl the calculate gamma ramp using the specified gamma
        /// </summary>
        /// <param name="gamma">The gamma</param>
        /// <param name="ramp">The ramp</param>
        [DllImport(NativeLibName, EntryPoint = "SDL_CalculateGammaRamp", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern void INTERNAL_SDL_CalculateGammaRamp(float gamma, [Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U2, SizeConst = 256)] ushort[] ramp);

        /// <summary>
        ///     Calculates the gamma ramp using the specified gamma
        /// </summary>
        /// <param name="gamma">The gamma</param>
        /// <param name="ramp">The ramp</param>
        [return: NotNull]
        public static void CalculateGammaRamp(float gamma, [Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U2, SizeConst = 256)] ushort[] ramp) => INTERNAL_SDL_CalculateGammaRamp(gamma.Validate(), ramp);


        /// <summary>
        ///     Sdl the free format using the specified format
        /// </summary>
        /// <param name="format">The format</param>
        [DllImport(NativeLibName, EntryPoint = "SDL_FreeFormat", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern void INTERNAL_SDL_FreeFormat([NotNull] IntPtr format);

        /// <summary>
        ///     Frees the format using the specified format
        /// </summary>
        /// <param name="format">The format</param>
        [return: NotNull]
        public static void FreeFormat([NotNull] IntPtr format) => INTERNAL_SDL_FreeFormat(format.Validate());

        /// <summary>
        ///     Sdl the free palette using the specified palette
        /// </summary>
        /// <param name="palette">The palette</param>
        [DllImport(NativeLibName, EntryPoint = "SDL_FreePalette", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern void INTERNAL_SDL_FreePalette([NotNull] IntPtr palette);

        /// <summary>
        ///     Frees the palette using the specified palette
        /// </summary>
        /// <param name="palette">The palette</param>
        [return: NotNull]
        public static void FreePalette([NotNull] IntPtr palette) => INTERNAL_SDL_FreePalette(palette.Validate());

        /// <summary>
        ///     Internals the sdl get pixel format name using the specified format
        /// </summary>
        /// <param name="format">The format</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GetPixelFormatName", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern IntPtr INTERNAL_SDL_GetPixelFormatName([NotNull] uint format);

        /// <summary>
        ///     Sdl the get pixel format name using the specified format
        /// </summary>
        /// <param name="format">The format</param>
        /// <returns>The string</returns>
        [return: NotNull]
        public static string GetPixelFormatName([NotNull] uint format) => Utf8Manager.Utf8ToManaged(INTERNAL_SDL_GetPixelFormatName(format));

        /// <summary>
        ///     Sdl the get rgb using the specified pixel
        /// </summary>
        /// <param name="pixel">The pixel</param>
        /// <param name="format">The format</param>
        /// <param name="r">The </param>
        /// <param name="g">The </param>
        /// <param name="b">The </param>
        [DllImport(NativeLibName, EntryPoint = "SDL_GetRGB", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern void INTERNAL_SDL_GetRGB([NotNull] uint pixel, [NotNull] IntPtr format, out byte r, out byte g, out byte b);

        /// <summary>
        ///     Gets the rgb using the specified pixel
        /// </summary>
        /// <param name="pixel">The pixel</param>
        /// <param name="format">The format</param>
        /// <param name="r">The </param>
        /// <param name="g">The </param>
        /// <param name="b">The </param>
        [return: NotNull]
        public static void GetRgb([NotNull] uint pixel, [NotNull] IntPtr format, out byte r, out byte g, out byte b) => INTERNAL_SDL_GetRGB(pixel, format.Validate(), out r, out g, out b);


        /// <summary>
        ///     Sdl the get rgba using the specified pixel
        /// </summary>
        /// <param name="pixel">The pixel</param>
        /// <param name="format">The format</param>
        /// <param name="r">The </param>
        /// <param name="g">The </param>
        /// <param name="b">The </param>
        /// <param name="a">The </param>
        [DllImport(NativeLibName, EntryPoint = "SDL_GetRGBA", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern void INTERNAL_SDL_GetRGBA([NotNull] uint pixel, [NotNull] IntPtr format, out byte r, out byte g, out byte b, out byte a);

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
        public static void GetRgba([NotNull] uint pixel, [NotNull] IntPtr format, out byte r, out byte g, out byte b, out byte a) => INTERNAL_SDL_GetRGBA(pixel, format.Validate(), out r, out g, out b, out a);

        /// <summary>
        ///     Sdl the map rgb using the specified format
        /// </summary>
        /// <param name="format">The format</param>
        /// <param name="r">The </param>
        /// <param name="g">The </param>
        /// <param name="b">The </param>
        /// <returns>The uint</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_MapRGB", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern uint INTERNAL_SDL_MapRGB([NotNull] IntPtr format, byte r, [NotNull] byte g, [NotNull] byte b);

        /// <summary>
        ///     Maps the rgb using the specified format
        /// </summary>
        /// <param name="format">The format</param>
        /// <param name="r">The </param>
        /// <param name="g">The </param>
        /// <param name="b">The </param>
        /// <returns>The uint</returns>
        [return: NotNull]
        public static uint MapRgb([NotNull] IntPtr format, byte r, [NotNull] byte g, [NotNull] byte b) => INTERNAL_SDL_MapRGB(format.Validate(), r, g, b);


        /// <summary>
        ///     Sdl the map rgba using the specified format
        /// </summary>
        /// <param name="format">The format</param>
        /// <param name="r">The </param>
        /// <param name="g">The </param>
        /// <param name="b">The </param>
        /// <param name="a">The </param>
        /// <returns>The uint</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_MapRGBA", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern uint INTERNAL_SDL_MapRGBA([NotNull] IntPtr format, [NotNull] byte r, [NotNull] byte g, [NotNull] byte b, [NotNull] byte a);

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
        public static uint MapRgba([NotNull] IntPtr format, [NotNull] byte r, [NotNull] byte g, [NotNull] byte b, [NotNull] byte a) => INTERNAL_SDL_MapRGBA(format.Validate(), r, g, b, a);

        /// <summary>
        ///     Sdl the masks to pixel format enum using the specified bpp
        /// </summary>
        /// <param name="bpp">The bpp</param>
        /// <param name="rMask">The r mask</param>
        /// <param name="gMask">The g mask</param>
        /// <param name="bMask">The b mask</param>
        /// <param name="aMask">The a mask</param>
        /// <returns>The uint</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_MasksToPixelFormatEnum", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern uint INTERNAL_SDL_MasksToPixelFormatEnum([NotNull] int bpp, [NotNull] uint rMask, [NotNull] uint gMask, [NotNull] uint bMask, [NotNull] uint aMask);

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
        public static uint MasksToPixelFormatEnum([NotNull] int bpp, [NotNull] uint rMask, [NotNull] uint gMask, [NotNull] uint bMask, [NotNull] uint aMask) => INTERNAL_SDL_MasksToPixelFormatEnum(bpp.Validate(), rMask, gMask, bMask, aMask);

        /// <summary>
        ///     Sdl the pixel format enum to masks using the specified format
        /// </summary>
        /// <param name="format">The format</param>
        /// <param name="bpp">The bpp</param>
        /// <param name="rMask">The r mask</param>
        /// <param name="gMask">The g mask</param>
        /// <param name="bMask">The b mask</param>
        /// <param name="aMask">The a mask</param>
        /// <returns>The sdl bool</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_PixelFormatEnumToMasks", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern SdlBool INTERNAL_SDL_PixelFormatEnumToMasks([NotNull] uint format, out int bpp, out uint rMask, out uint gMask, out uint bMask, out uint aMask);

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
        public static SdlBool FormatEnumToMasks([NotNull] uint format, out int bpp, out uint rMask, out uint gMask, out uint bMask, out uint aMask) => INTERNAL_SDL_PixelFormatEnumToMasks(format.Validate(), out bpp, out rMask, out gMask, out bMask, out aMask);


        /// <summary>
        ///     Sdl the set palette colors using the specified palette
        /// </summary>
        /// <param name="palette">The palette</param>
        /// <param name="colors">The colors</param>
        /// <param name="firstColor">The first color</param>
        /// <param name="nColors">The n colors</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_SetPaletteColors", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern int INTERNAL_SDL_SetPaletteColors([NotNull] IntPtr palette, [In] SdlColor[] colors, [NotNull] int firstColor, [NotNull] int nColors);

        /// <summary>
        ///     Sets the palette colors using the specified palette
        /// </summary>
        /// <param name="palette">The palette</param>
        /// <param name="colors">The colors</param>
        /// <param name="firstColor">The first color</param>
        /// <param name="nColors">The colors</param>
        /// <returns>The int</returns>
        [return: NotNull]
        public static int SetPaletteColors([NotNull] IntPtr palette, [In] SdlColor[] colors, [NotNull] int firstColor, [NotNull] int nColors) => INTERNAL_SDL_SetPaletteColors(palette.Validate(), colors, firstColor, nColors);


        /// <summary>
        ///     Sdl the set pixel format palette using the specified format
        /// </summary>
        /// <param name="format">The format</param>
        /// <param name="palette">The palette</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_SetPixelFormatPalette", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern int INTERNAL_SDL_SetPixelFormatPalette([NotNull] IntPtr format, [NotNull] IntPtr palette);

        /// <summary>
        ///     Sets the pixel format palette using the specified format
        /// </summary>
        /// <param name="format">The format</param>
        /// <param name="palette">The palette</param>
        /// <returns>The int</returns>
        [return: NotNull]
        public static int SetPixelFormatPalette([NotNull] IntPtr format, [NotNull] IntPtr palette) => INTERNAL_SDL_SetPixelFormatPalette(format.Validate(), palette.Validate());


        /// <summary>
        ///     Sdl the point in rect using the specified p
        /// </summary>
        /// <param name="p">The </param>
        /// <param name="r">The </param>
        /// <returns>The sdl bool</returns>
        public static SdlBool PointInRect(ref PointI p, ref RectangleI r) => (p.x >= r.x) && (p.x < r.x + r.w) && (p.y >= r.y) && (p.y < r.y + r.h) ? SdlBool.SdlTrue : SdlBool.SdlFalse;

        /// <summary>
        ///     Sdl the enclose points using the specified points
        /// </summary>
        /// <param name="points">The points</param>
        /// <param name="count">The count</param>
        /// <param name="clip">The clip</param>
        /// <param name="result">The result</param>
        /// <returns>The sdl bool</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_EnclosePoints", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern SdlBool INTERNAL_SDL_EnclosePoints([In] PointI[] points, [NotNull] int count, ref RectangleI clip, out RectangleI result);

        /// <summary>
        ///     Encloses the points using the specified points
        /// </summary>
        /// <param name="points">The points</param>
        /// <param name="count">The count</param>
        /// <param name="clip">The clip</param>
        /// <param name="result">The result</param>
        /// <returns>The sdl bool</returns>
        [return: NotNull]
        public static SdlBool EnclosePoints([In] PointI[] points, [NotNull] int count, ref RectangleI clip, out RectangleI result) => INTERNAL_SDL_EnclosePoints(points, count, ref clip, out result).Validate();


        /// <summary>
        ///     Sdl the has intersection using the specified a
        /// </summary>
        /// <param name="a">The </param>
        /// <param name="b">The </param>
        /// <returns>The sdl bool</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_HasIntersection", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern SdlBool INTERNAL_SDL_HasIntersection(ref RectangleI a, ref RectangleI b);

        /// <summary>
        ///     Has the intersection using the specified a
        /// </summary>
        /// <param name="a">The </param>
        /// <param name="b">The </param>
        /// <returns>The sdl bool</returns>
        [return: NotNull]
        public static SdlBool HasIntersection(ref RectangleI a, ref RectangleI b) => INTERNAL_SDL_HasIntersection(ref a, ref b).Validate();

        /// <summary>
        ///     Sdl the intersect rect using the specified a
        /// </summary>
        /// <param name="a">The </param>
        /// <param name="b">The </param>
        /// <param name="result">The result</param>
        /// <returns>The sdl bool</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_IntersectRect", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern SdlBool INTERNAL_SDL_IntersectRect(ref RectangleI a, ref RectangleI b, out RectangleI result);

        /// <summary>
        ///     Intersects the rect using the specified a
        /// </summary>
        /// <param name="a">The </param>
        /// <param name="b">The </param>
        /// <param name="result">The result</param>
        /// <returns>The sdl bool</returns>
        [return: NotNull]
        public static SdlBool IntersectRect(ref RectangleI a, ref RectangleI b, out RectangleI result) => INTERNAL_SDL_IntersectRect(ref a, ref b, out result).Validate();

        /// <summary>
        ///     Sdl the intersect rect and line using the specified rect
        /// </summary>
        /// <param name="rect">The rect</param>
        /// <param name="x1">The </param>
        /// <param name="y1">The </param>
        /// <param name="x2">The </param>
        /// <param name="y2">The </param>
        /// <returns>The sdl bool</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_IntersectRectAndLine", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern SdlBool INTERNAL_SDL_IntersectRectAndLine(ref RectangleI rect, ref int x1, ref int y1, ref int x2, ref int y2);

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
        public static SdlBool IntersectRectAndLine(ref RectangleI rect, ref int x1, ref int y1, ref int x2, ref int y2) => INTERNAL_SDL_IntersectRectAndLine(ref rect, ref x1, ref y1, ref x2, ref y2);

        /// <summary>
        ///     Sdl the rect empty using the specified r
        /// </summary>
        /// <param name="r">The </param>
        /// <returns>The sdl bool</returns>
        [return: NotNull]
        public static SdlBool RectEmpty(ref RectangleI r) => r.w <= 0 || r.h <= 0 ? SdlBool.SdlTrue : SdlBool.SdlFalse;

        /// <summary>
        ///     Sdl the rect equals using the specified a
        /// </summary>
        /// <param name="a">The </param>
        /// <param name="b">The </param>
        /// <returns>The sdl bool</returns>
        [return: NotNull]
        public static SdlBool SDL_RectEquals(ref RectangleI a, ref RectangleI b) => (a.x == b.x) && (a.y == b.y) && (a.w == b.w) && (a.h == b.h) ? SdlBool.SdlTrue : SdlBool.SdlFalse;

        /// <summary>
        ///     Sdl the union rect using the specified a
        /// </summary>
        /// <param name="a">The </param>
        /// <param name="b">The </param>
        /// <param name="result">The result</param>
        [DllImport(NativeLibName, EntryPoint = "SDL_UnionRect", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern void INTERNAL_SDL_UnionRect(RectangleI a, RectangleI b, out RectangleI result);

        /// <summary>
        ///     Unions the rect using the specified a
        /// </summary>
        /// <param name="a">The </param>
        /// <param name="b">The </param>
        /// <param name="result">The result</param>
        [return: NotNull]
        public static void UnionRect(RectangleI a, RectangleI b, out RectangleI result) => INTERNAL_SDL_UnionRect(a.Validate(), b.Validate(), out result);

        /// <summary>
        ///     Describes whether sdl must lock
        /// </summary>
        /// <param name="surface">The surface</param>
        /// <returns>The bool</returns>
        [return: NotNull]
        public static bool SdlMustLock([NotNull] IntPtr surface)
        {
            SdlSurface sur = (SdlSurface) Marshal.PtrToStructure(
                surface,
                typeof(SdlSurface)
            );
            return (sur.flags & RleAccel) != 0;
        }

        /// <summary>
        ///     Sdl the blit surface using the specified src
        /// </summary>
        /// <param name="src">The src</param>
        /// <param name="srcRect">The src rect</param>
        /// <param name="dst">The dst</param>
        /// <param name="dstRect">The dst rect</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_UpperBlit", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern int INTERNAL_SDL_BlitSurface([NotNull] IntPtr src, ref RectangleI srcRect, [NotNull] IntPtr dst, ref RectangleI dstRect);

        /// <summary>
        ///     Blit the surface using the specified src
        /// </summary>
        /// <param name="src">The src</param>
        /// <param name="srcRect">The src rect</param>
        /// <param name="dst">The dst</param>
        /// <param name="dstRect">The dst rect</param>
        /// <returns>The int</returns>
        [return: NotNull]
        public static int BlitSurface([NotNull] IntPtr src, ref RectangleI srcRect, [NotNull] IntPtr dst, ref RectangleI dstRect) => INTERNAL_SDL_BlitSurface(src.Validate(), ref srcRect, dst, ref dstRect);

        /// <summary>
        ///     Sdl the blit surface using the specified src
        /// </summary>
        /// <param name="src">The src</param>
        /// <param name="srcRect">The src rect</param>
        /// <param name="dst">The dst</param>
        /// <param name="dstRect">The dst rect</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_UpperBlit", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern int INTERNAL_SDL_BlitSurface([NotNull] IntPtr src, [NotNull] IntPtr srcRect, [NotNull] IntPtr dst, ref RectangleI dstRect);


        /// <summary>
        ///     Blit the surface using the specified src
        /// </summary>
        /// <param name="src">The src</param>
        /// <param name="srcRect">The src rect</param>
        /// <param name="dst">The dst</param>
        /// <param name="dstRect">The dst rect</param>
        /// <returns>The int</returns>
        [return: NotNull]
        public static int BlitSurface([NotNull] IntPtr src, [NotNull] IntPtr srcRect, [NotNull] IntPtr dst, ref RectangleI dstRect) => INTERNAL_SDL_BlitSurface(src.Validate(), srcRect, dst, ref dstRect);

        /// <summary>
        ///     Sdl the blit surface using the specified src
        /// </summary>
        /// <param name="src">The src</param>
        /// <param name="srcRect">The src rect</param>
        /// <param name="dst">The dst</param>
        /// <param name="dstRect">The dst rect</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_UpperBlit", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern int INTERNAL_SDL_BlitSurface([NotNull] IntPtr src, ref RectangleI srcRect, [NotNull] IntPtr dst, [NotNull] IntPtr dstRect);

        /// <summary>
        ///     Blit the surface using the specified src
        /// </summary>
        /// <param name="src">The src</param>
        /// <param name="srcRect">The src rect</param>
        /// <param name="dst">The dst</param>
        /// <param name="dstRect">The dst rect</param>
        /// <returns>The int</returns>
        [return: NotNull]
        public static int BlitSurface([NotNull] IntPtr src, ref RectangleI srcRect, [NotNull] IntPtr dst, [NotNull] IntPtr dstRect) => INTERNAL_SDL_BlitSurface(src.Validate(), ref srcRect, dst, dstRect);

        /// <summary>
        ///     Sdl the blit surface using the specified src
        /// </summary>
        /// <param name="src">The src</param>
        /// <param name="srcRect">The src rect</param>
        /// <param name="dst">The dst</param>
        /// <param name="dstRect">The dst rect</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_UpperBlit", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern int INTERNAL_SDL_BlitSurface([NotNull] IntPtr src, [NotNull] IntPtr srcRect, [NotNull] IntPtr dst, [NotNull] IntPtr dstRect);

        /// <summary>
        ///     Blit the surface using the specified src
        /// </summary>
        /// <param name="src">The src</param>
        /// <param name="srcRect">The src rect</param>
        /// <param name="dst">The dst</param>
        /// <param name="dstRect">The dst rect</param>
        /// <returns>The int</returns>
        [return: NotNull]
        public static int BlitSurface([NotNull] IntPtr src, [NotNull] IntPtr srcRect, [NotNull] IntPtr dst, [NotNull] IntPtr dstRect) => INTERNAL_SDL_BlitSurface(src.Validate(), srcRect, dst, dstRect);


        /// <summary>
        ///     Sdl the blit scaled using the specified src
        /// </summary>
        /// <param name="src">The src</param>
        /// <param name="srcRect">The src rect</param>
        /// <param name="dst">The dst</param>
        /// <param name="dstRect">The dst rect</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_UpperBlitScaled", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern int INTERNAL_SDL_BlitScaled([NotNull] IntPtr src, ref RectangleI srcRect, [NotNull] IntPtr dst, ref RectangleI dstRect);

        /// <summary>
        ///     Blit the scaled using the specified src
        /// </summary>
        /// <param name="src">The src</param>
        /// <param name="srcRect">The src rect</param>
        /// <param name="dst">The dst</param>
        /// <param name="dstRect">The dst rect</param>
        /// <returns>The int</returns>
        [return: NotNull]
        public static int BlitScaled([NotNull] IntPtr src, ref RectangleI srcRect, [NotNull] IntPtr dst, ref RectangleI dstRect) => INTERNAL_SDL_BlitScaled(src.Validate(), ref srcRect, dst, ref dstRect);


        /// <summary>
        ///     Sdl the blit scaled using the specified src
        /// </summary>
        /// <param name="src">The src</param>
        /// <param name="srcRect">The src rect</param>
        /// <param name="dst">The dst</param>
        /// <param name="dstRect">The dst rect</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_UpperBlitScaled", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern int INTERNAL_SDL_BlitScaled([NotNull] IntPtr src, [NotNull] IntPtr srcRect, [NotNull] IntPtr dst, ref RectangleI dstRect);

        /// <summary>
        ///     Blit the scaled using the specified src
        /// </summary>
        /// <param name="src">The src</param>
        /// <param name="srcRect">The src rect</param>
        /// <param name="dst">The dst</param>
        /// <param name="dstRect">The dst rect</param>
        /// <returns>The int</returns>
        [return: NotNull]
        public static int BlitScaled([NotNull] IntPtr src, [NotNull] IntPtr srcRect, [NotNull] IntPtr dst, ref RectangleI dstRect) => INTERNAL_SDL_BlitScaled(src.Validate(), srcRect, dst, ref dstRect);


        /// <summary>
        ///     Sdl the blit scaled using the specified src
        /// </summary>
        /// <param name="src">The src</param>
        /// <param name="srcRect">The src rect</param>
        /// <param name="dst">The dst</param>
        /// <param name="dstRect">The dst rect</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_UpperBlitScaled", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern int INTERNAL_SDL_BlitScaled([NotNull] IntPtr src, ref RectangleI srcRect, [NotNull] IntPtr dst, [NotNull] IntPtr dstRect);

        /// <summary>
        ///     Blit the scaled using the specified src
        /// </summary>
        /// <param name="src">The src</param>
        /// <param name="srcRect">The src rect</param>
        /// <param name="dst">The dst</param>
        /// <param name="dstRect">The dst rect</param>
        /// <returns>The int</returns>
        [return: NotNull]
        public static int BlitScaled([NotNull] IntPtr src, ref RectangleI srcRect, [NotNull] IntPtr dst, [NotNull] IntPtr dstRect) => INTERNAL_SDL_BlitScaled(src.Validate(), ref srcRect, dst, dstRect);

        /// <summary>
        ///     Sdl the blit scaled using the specified src
        /// </summary>
        /// <param name="src">The src</param>
        /// <param name="srcRect">The src rect</param>
        /// <param name="dst">The dst</param>
        /// <param name="dstRect">The dst rect</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_UpperBlitScaled", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern int INTERNAL_SDL_BlitScaled([NotNull] IntPtr src, [NotNull] IntPtr srcRect, [NotNull] IntPtr dst, [NotNull] IntPtr dstRect);

        /// <summary>
        ///     Blit the scaled using the specified src
        /// </summary>
        /// <param name="src">The src</param>
        /// <param name="srcRect">The src rect</param>
        /// <param name="dst">The dst</param>
        /// <param name="dstRect">The dst rect</param>
        /// <returns>The int</returns>
        [return: NotNull]
        public static int BlitScaled([NotNull] IntPtr src, [NotNull] IntPtr srcRect, [NotNull] IntPtr dst, [NotNull] IntPtr dstRect) => INTERNAL_SDL_BlitScaled(src.Validate(), srcRect, dst, dstRect);


        /// <summary>
        ///     Sdl the convert pixels using the specified width
        /// </summary>
        /// <param name="width">The width</param>
        /// <param name="height">The height</param>
        /// <param name="srcFormat">The src format</param>
        /// <param name="src">The src</param>
        /// <param name="srcPitch">The src pitch</param>
        /// <param name="dstFormat">The dst format</param>
        /// <param name="dst">The dst</param>
        /// <param name="dstPitch">The dst pitch</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_ConvertPixels", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern int INTERNAL_SDL_ConvertPixels([NotNull] int width, [NotNull] int height, [NotNull] uint srcFormat, [NotNull] IntPtr src, [NotNull] int srcPitch, [NotNull] uint dstFormat, [NotNull] IntPtr dst, [NotNull] int dstPitch);

        /// <summary>
        ///     Converts the pixels using the specified width
        /// </summary>
        /// <param name="width">The width</param>
        /// <param name="height">The height</param>
        /// <param name="srcFormat">The src format</param>
        /// <param name="src">The src</param>
        /// <param name="srcPitch">The src pitch</param>
        /// <param name="dstFormat">The dst format</param>
        /// <param name="dst">The dst</param>
        /// <param name="dstPitch">The dst pitch</param>
        /// <returns>The int</returns>
        [return: NotNull]
        public static int ConvertPixels([NotNull] int width, [NotNull] int height, [NotNull] uint srcFormat, [NotNull] IntPtr src, [NotNull] int srcPitch, [NotNull] uint dstFormat, [NotNull] IntPtr dst, [NotNull] int dstPitch) => INTERNAL_SDL_ConvertPixels(width.Validate(), height.Validate(), srcFormat, src, srcPitch, dstFormat, dst, dstPitch);


        /// <summary>
        ///     Sdl the premultiply alpha using the specified width
        /// </summary>
        /// <param name="width">The width</param>
        /// <param name="height">The height</param>
        /// <param name="srcFormat">The src format</param>
        /// <param name="src">The src</param>
        /// <param name="srcPitch">The src pitch</param>
        /// <param name="dstFormat">The dst format</param>
        /// <param name="dst">The dst</param>
        /// <param name="dstPitch">The dst pitch</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_PremultiplyAlpha", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern int INTERNAL_SDL_PremultiplyAlpha([NotNull] int width, [NotNull] int height, [NotNull] uint srcFormat, [NotNull] IntPtr src, [NotNull] int srcPitch, [NotNull] uint dstFormat, [NotNull] IntPtr dst, [NotNull] int dstPitch);

        /// <summary>
        ///     Pre the alpha using the specified width
        /// </summary>
        /// <param name="width">The width</param>
        /// <param name="height">The height</param>
        /// <param name="srcFormat">The src format</param>
        /// <param name="src">The src</param>
        /// <param name="srcPitch">The src pitch</param>
        /// <param name="dstFormat">The dst format</param>
        /// <param name="dst">The dst</param>
        /// <param name="dstPitch">The dst pitch</param>
        /// <returns>The int</returns>
        [return: NotNull]
        public static int PremultiplyAlpha([NotNull] int width, [NotNull] int height, [NotNull] uint srcFormat, [NotNull] IntPtr src, [NotNull] int srcPitch, [NotNull] uint dstFormat, [NotNull] IntPtr dst, [NotNull] int dstPitch) => INTERNAL_SDL_PremultiplyAlpha(width.Validate(), height.Validate(), srcFormat, src, srcPitch, dstFormat, dst, dstPitch);


        /// <summary>
        ///     Sdl the convert surface using the specified src
        /// </summary>
        /// <param name="src">The src</param>
        /// <param name="fmt">The fmt</param>
        /// <param name="flags">The flags</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_ConvertSurface", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern IntPtr INTERNAL_SDL_ConvertSurface([NotNull] IntPtr src, [NotNull] IntPtr fmt, [NotNull] uint flags);

        /// <summary>
        ///     Converts the surface using the specified src
        /// </summary>
        /// <param name="src">The src</param>
        /// <param name="fmt">The fmt</param>
        /// <param name="flags">The flags</param>
        /// <returns>The int ptr</returns>
        [return: NotNull]
        public static IntPtr ConvertSurface([NotNull] IntPtr src, [NotNull] IntPtr fmt, [NotNull] uint flags) => INTERNAL_SDL_ConvertSurface(src.Validate(), fmt, flags);


        /// <summary>
        ///     Sdl the convert surface format using the specified src
        /// </summary>
        /// <param name="src">The src</param>
        /// <param name="pixelFormat">The pixel format</param>
        /// <param name="flags">The flags</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_ConvertSurfaceFormat", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern IntPtr INTERNAL_SDL_ConvertSurfaceFormat([NotNull] IntPtr src, [NotNull] uint pixelFormat, [NotNull] uint flags);

        /// <summary>
        ///     Converts the surface format using the specified src
        /// </summary>
        /// <param name="src">The src</param>
        /// <param name="pixelFormat">The pixel format</param>
        /// <param name="flags">The flags</param>
        /// <returns>The int ptr</returns>
        [return: NotNull]
        public static IntPtr ConvertSurfaceFormat([NotNull] IntPtr src, [NotNull] uint pixelFormat, [NotNull] uint flags) => INTERNAL_SDL_ConvertSurfaceFormat(src.Validate(), pixelFormat, flags);


        /// <summary>
        ///     Sdl the create rgb surface using the specified flags
        /// </summary>
        /// <param name="flags">The flags</param>
        /// <param name="width">The width</param>
        /// <param name="height">The height</param>
        /// <param name="depth">The depth</param>
        /// <param name="rMask">The r mask</param>
        /// <param name="gMask">The g mask</param>
        /// <param name="bMask">The b mask</param>
        /// <param name="aMask">The a mask</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_CreateRGBSurface", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern IntPtr INTERNAL_SDL_CreateRGBSurface([NotNull] uint flags, [NotNull] int width, [NotNull] int height, [NotNull] int depth, [NotNull] uint rMask, [NotNull] uint gMask, [NotNull] uint bMask, [NotNull] uint aMask);

        /// <summary>
        ///     Creates the rgb surface using the specified flags
        /// </summary>
        /// <param name="flags">The flags</param>
        /// <param name="width">The width</param>
        /// <param name="height">The height</param>
        /// <param name="depth">The depth</param>
        /// <param name="rMask">The mask</param>
        /// <param name="gMask">The mask</param>
        /// <param name="bMask">The mask</param>
        /// <param name="aMask">The mask</param>
        /// <returns>The int ptr</returns>
        [return: NotNull]
        public static IntPtr CreateRgbSurface([NotNull] uint flags, [NotNull] int width, [NotNull] int height, [NotNull] int depth, [NotNull] uint rMask, [NotNull] uint gMask, [NotNull] uint bMask, [NotNull] uint aMask) => INTERNAL_SDL_CreateRGBSurface(flags, width.Validate(), height.Validate(), depth.Validate(), rMask, gMask, bMask, aMask);


        /// <summary>
        ///     Sdl the create rgb surface from using the specified pixels
        /// </summary>
        /// <param name="pixels">The pixels</param>
        /// <param name="width">The width</param>
        /// <param name="height">The height</param>
        /// <param name="depth">The depth</param>
        /// <param name="pitch">The pitch</param>
        /// <param name="rMask">The r mask</param>
        /// <param name="gMask">The g mask</param>
        /// <param name="bMask">The b mask</param>
        /// <param name="aMask">The a mask</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_CreateRGBSurfaceFrom", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern IntPtr INTERNAL_SDL_CreateRGBSurfaceFrom([NotNull] IntPtr pixels, [NotNull] int width, [NotNull] int height, [NotNull] int depth, [NotNull] int pitch, [NotNull] uint rMask, [NotNull] uint gMask, [NotNull] uint bMask, [NotNull] uint aMask);

        /// <summary>
        ///     Creates the rgb surface from using the specified pixels
        /// </summary>
        /// <param name="pixels">The pixels</param>
        /// <param name="width">The width</param>
        /// <param name="height">The height</param>
        /// <param name="depth">The depth</param>
        /// <param name="pitch">The pitch</param>
        /// <param name="rMask">The mask</param>
        /// <param name="gMask">The mask</param>
        /// <param name="bMask">The mask</param>
        /// <param name="aMask">The mask</param>
        /// <returns>The int ptr</returns>
        [return: NotNull]
        public static IntPtr CreateRgbSurfaceFrom([NotNull] IntPtr pixels, [NotNull] int width, [NotNull] int height, [NotNull] int depth, [NotNull] int pitch, [NotNull] uint rMask, [NotNull] uint gMask, [NotNull] uint bMask, [NotNull] uint aMask)
            => INTERNAL_SDL_CreateRGBSurfaceFrom(pixels.Validate(), width.Validate(), height.Validate(), depth.Validate(), pitch.Validate(), rMask, gMask, bMask, aMask);

        /// <summary>
        ///     Sdl the create rgb surface with format using the specified flags
        /// </summary>
        /// <param name="flags">The flags</param>
        /// <param name="width">The width</param>
        /// <param name="height">The height</param>
        /// <param name="depth">The depth</param>
        /// <param name="format">The format</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_CreateRGBSurfaceWithFormat", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern IntPtr INTERNAL_SDL_CreateRGBSurfaceWithFormat([NotNull] uint flags, [NotNull] int width, [NotNull] int height, [NotNull] int depth, [NotNull] uint format);

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
        public static IntPtr CreateRgbSurfaceWithFormat([NotNull] uint flags, [NotNull] int width, [NotNull] int height, [NotNull] int depth, [NotNull] uint format) => INTERNAL_SDL_CreateRGBSurfaceWithFormat(flags, width.Validate(), height.Validate(), depth.Validate(), format);


        /// <summary>
        ///     Sdl the create rgb surface with format from using the specified pixels
        /// </summary>
        /// <param name="pixels">The pixels</param>
        /// <param name="width">The width</param>
        /// <param name="height">The height</param>
        /// <param name="depth">The depth</param>
        /// <param name="pitch">The pitch</param>
        /// <param name="format">The format</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_CreateRGBSurfaceWithFormatFrom", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern IntPtr INTERNAL_SDL_CreateRGBSurfaceWithFormatFrom([NotNull] IntPtr pixels, [NotNull] int width, [NotNull] int height, [NotNull] int depth, [NotNull] int pitch, [NotNull] uint format);

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
        public static IntPtr CreateRgbSurfaceWithFormatFrom([NotNull] IntPtr pixels, [NotNull] int width, [NotNull] int height, [NotNull] int depth, [NotNull] int pitch, [NotNull] uint format) => INTERNAL_SDL_CreateRGBSurfaceWithFormatFrom(pixels.Validate(), width, height, depth, pitch, format);


        /// <summary>
        ///     Sdl the fill rect using the specified dst
        /// </summary>
        /// <param name="dst">The dst</param>
        /// <param name="rect">The rect</param>
        /// <param name="color">The color</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_FillRect", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern int INTERNAL_SDL_FillRect([NotNull] IntPtr dst, ref RectangleI rect, [NotNull] uint color);

        /// <summary>
        ///     Fills the rect using the specified dst
        /// </summary>
        /// <param name="dst">The dst</param>
        /// <param name="rect">The rect</param>
        /// <param name="color">The color</param>
        /// <returns>The int</returns>
        [return: NotNull]
        public static int FillRect([NotNull] IntPtr dst, ref RectangleI rect, [NotNull] uint color) => INTERNAL_SDL_FillRect(dst.Validate(), ref rect, color);

        /// <summary>
        ///     Sdl the fill rect using the specified dst
        /// </summary>
        /// <param name="dst">The dst</param>
        /// <param name="rect">The rect</param>
        /// <param name="color">The color</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_FillRect", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern int INTERNAL_SDL_FillRect([NotNull] IntPtr dst, [NotNull] IntPtr rect, [NotNull] uint color);

        /// <summary>
        ///     Fills the rect using the specified dst
        /// </summary>
        /// <param name="dst">The dst</param>
        /// <param name="rect">The rect</param>
        /// <param name="color">The color</param>
        /// <returns>The int</returns>
        [return: NotNull]
        public static int FillRect([NotNull] IntPtr dst, [NotNull] IntPtr rect, [NotNull] uint color) => INTERNAL_SDL_FillRect(dst.Validate(), rect.Validate(), color);

        /// <summary>
        ///     Sdl the fill rects using the specified dst
        /// </summary>
        /// <param name="dst">The dst</param>
        /// <param name="rects">The rects</param>
        /// <param name="count">The count</param>
        /// <param name="color">The color</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_FillRects", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern int INTERNAL_SDL_FillRects([NotNull] IntPtr dst, [In] RectangleI[] rects, [NotNull] int count, [NotNull] uint color);

        /// <summary>
        ///     Fills the rects using the specified dst
        /// </summary>
        /// <param name="dst">The dst</param>
        /// <param name="rects">The rects</param>
        /// <param name="count">The count</param>
        /// <param name="color">The color</param>
        /// <returns>The int</returns>
        [return: NotNull]
        public static int FillRects([NotNull] IntPtr dst, [In] RectangleI[] rects, [NotNull] int count, [NotNull] uint color) => INTERNAL_SDL_FillRects(dst.Validate(), rects, count, color);

        /// <summary>
        ///     Sdl the free surface using the specified surface
        /// </summary>
        /// <param name="surface">The surface</param>
        [DllImport(NativeLibName, EntryPoint = "SDL_FreeSurface", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern void INTERNAL_SDL_FreeSurface([NotNull] IntPtr surface);

        /// <summary>
        ///     Frees the surface using the specified surface
        /// </summary>
        /// <param name="surface">The surface</param>
        [return: NotNull]
        public static void FreeSurface([NotNull] IntPtr surface) => INTERNAL_SDL_FreeSurface(surface.Validate());

        /// <summary>
        ///     Sdl the get clip rect using the specified surface
        /// </summary>
        /// <param name="surface">The surface</param>
        /// <param name="rect">The rect</param>
        [DllImport(NativeLibName, EntryPoint = "SDL_GetClipRect", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern void INTERNAL_SDL_GetClipRect([NotNull] IntPtr surface, out RectangleI rect);

        /// <summary>
        ///     Gets the clip rect using the specified surface
        /// </summary>
        /// <param name="surface">The surface</param>
        /// <param name="rect">The rect</param>
        [return: NotNull]
        public static void GetClipRect([NotNull] IntPtr surface, out RectangleI rect) => INTERNAL_SDL_GetClipRect(surface.Validate(), out rect);

        /// <summary>
        ///     Sdl the has color key using the specified surface
        /// </summary>
        /// <param name="surface">The surface</param>
        /// <returns>The sdl bool</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_HasColorKey", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern SdlBool INTERNAL_SDL_HasColorKey([NotNull] IntPtr surface);

        /// <summary>
        ///     Has the color key using the specified surface
        /// </summary>
        /// <param name="surface">The surface</param>
        /// <returns>The sdl bool</returns>
        [return: NotNull]
        public static SdlBool HasColorKey([NotNull] IntPtr surface) => INTERNAL_SDL_HasColorKey(surface.Validate());

        /// <summary>
        ///     Sdl the get color key using the specified surface
        /// </summary>
        /// <param name="surface">The surface</param>
        /// <param name="key">The key</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GetColorKey", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern int INTERNAL_SDL_GetColorKey([NotNull] IntPtr surface, out uint key);

        /// <summary>
        ///     Gets the color key using the specified surface
        /// </summary>
        /// <param name="surface">The surface</param>
        /// <param name="key">The key</param>
        /// <returns>The int</returns>
        [return: NotNull]
        public static int GetColorKey([NotNull] IntPtr surface, out uint key) => INTERNAL_SDL_GetColorKey(surface.Validate(), out key);

        /// <summary>
        ///     Sdl the get surface alpha mod using the specified surface
        /// </summary>
        /// <param name="surface">The surface</param>
        /// <param name="alpha">The alpha</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GetSurfaceAlphaMod", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern int INTERNAL_SDL_GetSurfaceAlphaMod([NotNull] IntPtr surface, out byte alpha);

        /// <summary>
        ///     Gets the surface alpha mod using the specified surface
        /// </summary>
        /// <param name="surface">The surface</param>
        /// <param name="alpha">The alpha</param>
        /// <returns>The int</returns>
        [return: NotNull]
        public static int GetSurfaceAlphaMod([NotNull] IntPtr surface, out byte alpha) => INTERNAL_SDL_GetSurfaceAlphaMod(surface.Validate(), out alpha);

        /// <summary>
        ///     Sdl the get surface blend mode using the specified surface
        /// </summary>
        /// <param name="surface">The surface</param>
        /// <param name="blendMode">The blend mode</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GetSurfaceBlendMode", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern int INTERNAL_SDL_GetSurfaceBlendMode([NotNull] IntPtr surface, out SdlBlendMode blendMode);

        /// <summary>
        ///     Gets the surface blend mode using the specified surface
        /// </summary>
        /// <param name="surface">The surface</param>
        /// <param name="blendMode">The blend mode</param>
        /// <returns>The int</returns>
        [return: NotNull]
        public static int GetSurfaceBlendMode([NotNull] IntPtr surface, out SdlBlendMode blendMode) => INTERNAL_SDL_GetSurfaceBlendMode(surface.Validate(), out blendMode);

        /// <summary>
        ///     Sdl the get surface color mod using the specified surface
        /// </summary>
        /// <param name="surface">The surface</param>
        /// <param name="r">The </param>
        /// <param name="g">The </param>
        /// <param name="b">The </param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GetSurfaceColorMod", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern int INTERNAL_SDL_GetSurfaceColorMod([NotNull] IntPtr surface, out byte r, out byte g, out byte b);

        /// <summary>
        ///     Gets the surface color mod using the specified surface
        /// </summary>
        /// <param name="surface">The surface</param>
        /// <param name="r">The </param>
        /// <param name="g">The </param>
        /// <param name="b">The </param>
        /// <returns>The int</returns>
        [return: NotNull]
        public static int GetSurfaceColorMod([NotNull] IntPtr surface, out byte r, out byte g, out byte b) => INTERNAL_SDL_GetSurfaceColorMod(surface.Validate(), out r, out g, out b);

        /// <summary>
        ///     Internals the sdl load bmp rw using the specified src
        /// </summary>
        /// <param name="src">The src</param>
        /// <param name="freeSrc">The free src</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_LoadBMP_RW", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern IntPtr INTERNAL_SDL_LoadBMP_RW([NotNull] IntPtr src, [NotNull] int freeSrc);

        /// <summary>
        ///     Sdl the load bmp using the specified file
        /// </summary>
        /// <param name="file">The file</param>
        /// <returns>The int ptr</returns>
        [return: NotNull]
        public static IntPtr LoadBmp([NotNull] string file) => INTERNAL_SDL_LoadBMP_RW(RwFromFile(file, "rb"), 1);

        /// <summary>
        ///     Sdl the lock surface using the specified surface
        /// </summary>
        /// <param name="surface">The surface</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_LockSurface", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern int INTERNAL_SDL_LockSurface([NotNull] IntPtr surface);

        /// <summary>
        ///     Locks the surface using the specified surface
        /// </summary>
        /// <param name="surface">The surface</param>
        /// <returns>The int</returns>
        [return: NotNull]
        public static int LockSurface([NotNull] IntPtr surface) => INTERNAL_SDL_LockSurface(surface.Validate());

        /// <summary>
        ///     Sdl the lower blit using the specified src
        /// </summary>
        /// <param name="src">The src</param>
        /// <param name="srcRect">The src rect</param>
        /// <param name="dst">The dst</param>
        /// <param name="dstRect">The dst rect</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_LowerBlit", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern int INTERNAL_SDL_LowerBlit([NotNull] IntPtr src, ref RectangleI srcRect, [NotNull] IntPtr dst, ref RectangleI dstRect);

        /// <summary>
        ///     Lowers the blit using the specified src
        /// </summary>
        /// <param name="src">The src</param>
        /// <param name="srcRect">The src rect</param>
        /// <param name="dst">The dst</param>
        /// <param name="dstRect">The dst rect</param>
        /// <returns>The int</returns>
        [return: NotNull]
        public static int LowerBlit([NotNull] IntPtr src, ref RectangleI srcRect, [NotNull] IntPtr dst, ref RectangleI dstRect) => INTERNAL_SDL_LowerBlit(src.Validate(), ref srcRect, dst, ref dstRect);

        /// <summary>
        ///     Sdl the lower blit scaled using the specified src
        /// </summary>
        /// <param name="src">The src</param>
        /// <param name="srcRect">The src rect</param>
        /// <param name="dst">The dst</param>
        /// <param name="dstRect">The dst rect</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_LowerBlitScaled", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern int INTERNAL_SDL_LowerBlitScaled([NotNull] IntPtr src, ref RectangleI srcRect, [NotNull] IntPtr dst, ref RectangleI dstRect);

        /// <summary>
        ///     Lowers the blit scaled using the specified src
        /// </summary>
        /// <param name="src">The src</param>
        /// <param name="srcRect">The src rect</param>
        /// <param name="dst">The dst</param>
        /// <param name="dstRect">The dst rect</param>
        /// <returns>The int</returns>
        [return: NotNull]
        public static int LowerBlitScaled([NotNull] IntPtr src, ref RectangleI srcRect, [NotNull] IntPtr dst, ref RectangleI dstRect) => INTERNAL_SDL_LowerBlitScaled(src.Validate(), ref srcRect, dst, ref dstRect);

        /// <summary>
        ///     Internals the sdl save bmp rw using the specified surface
        /// </summary>
        /// <param name="surface">The surface</param>
        /// <param name="src">The src</param>
        /// <param name="freeSrc">The free src</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_SaveBMP_RW", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern int INTERNAL_SDL_SaveBMP_RW([NotNull] IntPtr surface, [NotNull] IntPtr src, [NotNull] int freeSrc);

        /// <summary>
        ///     Sdl the save bmp using the specified surface
        /// </summary>
        /// <param name="surface">The surface</param>
        /// <param name="file">The file</param>
        /// <returns>The int</returns>
        [return: NotNull]
        public static int SaveBmp([NotNull] IntPtr surface, [NotNull] string file) => INTERNAL_SDL_SaveBMP_RW(surface, RwFromFile(file, "wb"), 1);

        /// <summary>
        ///     Sdl the set clip rect using the specified surface
        /// </summary>
        /// <param name="surface">The surface</param>
        /// <param name="rect">The rect</param>
        /// <returns>The sdl bool</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_SetClipRect", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern SdlBool INTERNAL_SDL_SetClipRect([NotNull] IntPtr surface, ref RectangleI rect);

        /// <summary>
        ///     Sets the clip rect using the specified surface
        /// </summary>
        /// <param name="surface">The surface</param>
        /// <param name="rect">The rect</param>
        /// <returns>The sdl bool</returns>
        [return: NotNull]
        public static SdlBool SetClipRect([NotNull] IntPtr surface, ref RectangleI rect) => INTERNAL_SDL_SetClipRect(surface.Validate(), ref rect);

        /// <summary>
        ///     Sdl the set color key using the specified surface
        /// </summary>
        /// <param name="surface">The surface</param>
        /// <param name="flag">The flag</param>
        /// <param name="key">The key</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_SetColorKey", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern int INTERNAL_SDL_SetColorKey([NotNull] IntPtr surface, [NotNull] int flag, [NotNull] uint key);

        /// <summary>
        ///     Sets the color key using the specified surface
        /// </summary>
        /// <param name="surface">The surface</param>
        /// <param name="flag">The flag</param>
        /// <param name="key">The key</param>
        /// <returns>The int</returns>
        [return: NotNull]
        public static int SetColorKey([NotNull] IntPtr surface, [NotNull] int flag, [NotNull] uint key) => INTERNAL_SDL_SetColorKey(surface.Validate(), flag, key);

        /// <summary>
        ///     Sdl the set surface alpha mod using the specified surface
        /// </summary>
        /// <param name="surface">The surface</param>
        /// <param name="alpha">The alpha</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_SetSurfaceAlphaMod", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern int INTERNAL_SDL_SetSurfaceAlphaMod([NotNull] IntPtr surface, [NotNull] byte alpha);

        /// <summary>
        ///     Sets the surface alpha mod using the specified surface
        /// </summary>
        /// <param name="surface">The surface</param>
        /// <param name="alpha">The alpha</param>
        /// <returns>The int</returns>
        [return: NotNull]
        public static int SetSurfaceAlphaMod([NotNull] IntPtr surface, [NotNull] byte alpha) => INTERNAL_SDL_SetSurfaceAlphaMod(surface.Validate(), alpha);

        /// <summary>
        ///     Sdl the set surface blend mode using the specified surface
        /// </summary>
        /// <param name="surface">The surface</param>
        /// <param name="blendMode">The blend mode</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_SetSurfaceBlendMode", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern int INTERNAL_SDL_SetSurfaceBlendMode([NotNull] IntPtr surface, SdlBlendMode blendMode);

        /// <summary>
        ///     Sets the surface blend mode using the specified surface
        /// </summary>
        /// <param name="surface">The surface</param>
        /// <param name="blendMode">The blend mode</param>
        /// <returns>The int</returns>
        [return: NotNull]
        public static int SetSurfaceBlendMode([NotNull] IntPtr surface, SdlBlendMode blendMode) => INTERNAL_SDL_SetSurfaceBlendMode(surface.Validate(), blendMode);

        /// <summary>
        ///     Sdl the set surface color mod using the specified surface
        /// </summary>
        /// <param name="surface">The surface</param>
        /// <param name="r">The </param>
        /// <param name="g">The </param>
        /// <param name="b">The </param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_SetSurfaceColorMod", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern int INTERNAL_SDL_SetSurfaceColorMod([NotNull] IntPtr surface, [NotNull] byte r, [NotNull] byte g, [NotNull] byte b);

        /// <summary>
        ///     Sets the surface color mod using the specified surface
        /// </summary>
        /// <param name="surface">The surface</param>
        /// <param name="r">The </param>
        /// <param name="g">The </param>
        /// <param name="b">The </param>
        /// <returns>The int</returns>
        [return: NotNull]
        public static int SetSurfaceColorMod([NotNull] IntPtr surface, [NotNull] byte r, [NotNull] byte g, [NotNull] byte b) => INTERNAL_SDL_SetSurfaceColorMod(surface.Validate(), r, g, b);

        /// <summary>
        ///     Sdl the set surface palette using the specified surface
        /// </summary>
        /// <param name="surface">The surface</param>
        /// <param name="palette">The palette</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_SetSurfacePalette", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern int INTERNAL_SDL_SetSurfacePalette([NotNull] IntPtr surface, [NotNull] IntPtr palette);

        /// <summary>
        ///     Sets the surface palette using the specified surface
        /// </summary>
        /// <param name="surface">The surface</param>
        /// <param name="palette">The palette</param>
        /// <returns>The int</returns>
        [return: NotNull]
        public static int SetSurfacePalette([NotNull] IntPtr surface, [NotNull] IntPtr palette) => INTERNAL_SDL_SetSurfacePalette(surface.Validate(), palette.Validate());

        /// <summary>
        ///     Sdl the set surface rle using the specified surface
        /// </summary>
        /// <param name="surface">The surface</param>
        /// <param name="flag">The flag</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_SetSurfaceRLE", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern int INTERNAL_SDL_SetSurfaceRLE([NotNull] IntPtr surface, [NotNull] int flag);

        /// <summary>
        ///     Sets the surface rle using the specified surface
        /// </summary>
        /// <param name="surface">The surface</param>
        /// <param name="flag">The flag</param>
        /// <returns>The int</returns>
        [return: NotNull]
        public static int SetSurfaceRle([NotNull] IntPtr surface, [NotNull] int flag) => INTERNAL_SDL_SetSurfaceRLE(surface.Validate(), flag);

        /// <summary>
        ///     Sdl the has surface rle using the specified surface
        /// </summary>
        /// <param name="surface">The surface</param>
        /// <returns>The sdl bool</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_HasSurfaceRLE", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern SdlBool INTERNAL_SDL_HasSurfaceRLE([NotNull] IntPtr surface);

        /// <summary>
        ///     Has the surface rle using the specified surface
        /// </summary>
        /// <param name="surface">The surface</param>
        /// <returns>The sdl bool</returns>
        [return: NotNull]
        public static SdlBool HasSurfaceRle([NotNull] IntPtr surface) => INTERNAL_SDL_HasSurfaceRLE(surface.Validate());

        /// <summary>
        ///     Sdl the soft stretch using the specified src
        /// </summary>
        /// <param name="src">The src</param>
        /// <param name="srcRect">The src rect</param>
        /// <param name="dst">The dst</param>
        /// <param name="dstRect">The dst rect</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_SoftStretch", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern int INTERNAL_SDL_SoftStretch([NotNull] IntPtr src, ref RectangleI srcRect, [NotNull] IntPtr dst, ref RectangleI dstRect);

        /// <summary>
        ///     Soft the stretch using the specified src
        /// </summary>
        /// <param name="src">The src</param>
        /// <param name="srcRect">The src rect</param>
        /// <param name="dst">The dst</param>
        /// <param name="dstRect">The dst rect</param>
        /// <returns>The int</returns>
        [return: NotNull]
        public static int SoftStretch([NotNull] IntPtr src, ref RectangleI srcRect, [NotNull] IntPtr dst, ref RectangleI dstRect) => INTERNAL_SDL_SoftStretch(src.Validate(), ref srcRect, dst.Validate(), ref dstRect);

        /// <summary>
        ///     Sdl the soft stretch linear using the specified src
        /// </summary>
        /// <param name="src">The src</param>
        /// <param name="srcRect">The src rect</param>
        /// <param name="dst">The dst</param>
        /// <param name="dstRect">The dst rect</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_SoftStretchLinear", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern int INTERNAL_SDL_SoftStretchLinear([NotNull] IntPtr src, ref RectangleI srcRect, [NotNull] IntPtr dst, ref RectangleI dstRect);

        /// <summary>
        ///     Soft the stretch linear using the specified src
        /// </summary>
        /// <param name="src">The src</param>
        /// <param name="srcRect">The src rect</param>
        /// <param name="dst">The dst</param>
        /// <param name="dstRect">The dst rect</param>
        /// <returns>The int</returns>
        [return: NotNull]
        public static int SoftStretchLinear([NotNull] IntPtr src, ref RectangleI srcRect, [NotNull] IntPtr dst, ref RectangleI dstRect) => INTERNAL_SDL_SoftStretchLinear(src.Validate(), ref srcRect, dst.Validate(), ref dstRect);

        /// <summary>
        ///     Sdl the unlock surface using the specified surface
        /// </summary>
        /// <param name="surface">The surface</param>
        [DllImport(NativeLibName, EntryPoint = "SDL_UnlockSurface", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern void INTERNAL_SDL_UnlockSurface([NotNull] IntPtr surface);

        /// <summary>
        ///     Unlocks the surface using the specified surface
        /// </summary>
        /// <param name="surface">The surface</param>
        [return: NotNull]
        public static void UnlockSurface([NotNull] IntPtr surface) => INTERNAL_SDL_UnlockSurface(surface.Validate());

        /// <summary>
        ///     Sdl the upper blit using the specified src
        /// </summary>
        /// <param name="src">The src</param>
        /// <param name="srcRect">The src rect</param>
        /// <param name="dst">The dst</param>
        /// <param name="dstRect">The dst rect</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_UpperBlit", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern int INTERNAL_SDL_UpperBlit([NotNull] IntPtr src, ref RectangleI srcRect, [NotNull] IntPtr dst, ref RectangleI dstRect);

        /// <summary>
        ///     Uppers the blit using the specified src
        /// </summary>
        /// <param name="src">The src</param>
        /// <param name="srcRect">The src rect</param>
        /// <param name="dst">The dst</param>
        /// <param name="dstRect">The dst rect</param>
        /// <returns>The int</returns>
        [return: NotNull]
        public static int UpperBlit([NotNull] IntPtr src, ref RectangleI srcRect, [NotNull] IntPtr dst, ref RectangleI dstRect) => INTERNAL_SDL_UpperBlit(src.Validate(), ref srcRect, dst.Validate(), ref dstRect);

        /// <summary>
        ///     Sdl the upper blit scaled using the specified src
        /// </summary>
        /// <param name="src">The src</param>
        /// <param name="srcRect">The src rect</param>
        /// <param name="dst">The dst</param>
        /// <param name="dstRect">The dst rect</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_UpperBlitScaled", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern int INTERNAL_SDL_UpperBlitScaled([NotNull] IntPtr src, ref RectangleI srcRect, [NotNull] IntPtr dst, ref RectangleI dstRect);

        /// <summary>
        ///     Uppers the blit scaled using the specified src
        /// </summary>
        /// <param name="src">The src</param>
        /// <param name="srcRect">The src rect</param>
        /// <param name="dst">The dst</param>
        /// <param name="dstRect">The dst rect</param>
        /// <returns>The int</returns>
        [return: NotNull]
        public static int UpperBlitScaled([NotNull] IntPtr src, ref RectangleI srcRect, [NotNull] IntPtr dst, ref RectangleI dstRect) => INTERNAL_SDL_UpperBlitScaled(src.Validate(), ref srcRect, dst, ref dstRect);

        /// <summary>
        ///     Sdl the duplicate surface using the specified surface
        /// </summary>
        /// <param name="surface">The surface</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_DuplicateSurface", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern IntPtr INTERNAL_SDL_DuplicateSurface([NotNull] IntPtr surface);

        /// <summary>
        ///     Duplicates the surface using the specified surface
        /// </summary>
        /// <param name="surface">The surface</param>
        /// <returns>The int ptr</returns>
        [return: NotNull]
        public static IntPtr DuplicateSurface([NotNull] IntPtr surface) => INTERNAL_SDL_DuplicateSurface(surface).Validate();

        /// <summary>
        ///     Sdl the has clipboard text
        /// </summary>
        /// <returns>The sdl bool</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_HasClipboardText", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern SdlBool INTERNAL_SDL_HasClipboardText();

        /// <summary>
        ///     Has the clipboard text
        /// </summary>
        /// <returns>The sdl bool</returns>
        [return: NotNull]
        public static SdlBool HasClipboardText() => INTERNAL_SDL_HasClipboardText().Validate();

        /// <summary>
        ///     Internals the sdl get clipboard text
        /// </summary>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GetClipboardText", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern IntPtr INTERNAL_SDL_GetClipboardText();

        /// <summary>
        ///     Sdl the get clipboard text
        /// </summary>
        /// <returns>The string</returns>
        [return: NotNull]
        public static string GetClipboardText() => Utf8Manager.Utf8ToManaged(INTERNAL_SDL_GetClipboardText(), true);

        /// <summary>
        ///     Internals the sdl set clipboard text using the specified text
        /// </summary>
        /// <param name="text">The text</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_SetClipboardText", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern int INTERNAL_SDL_SetClipboardText([NotNull] byte[] text);

        /// <summary>
        ///     Sdl the set clipboard text using the specified text
        /// </summary>
        /// <param name="text">The text</param>
        /// <returns>The result</returns>
        [return: NotNull]
        public static int SetClipboardText([NotNull] string text) => INTERNAL_SDL_SetClipboardText(Utf8Manager.Utf8EncodeHeap(text));

        /// <summary>
        ///     Sdl the pump events
        /// </summary>
        [DllImport(NativeLibName, EntryPoint = "SDL_PumpEvents", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern void INTERNAL_SDL_PumpEvents();

        /// <summary>
        ///     Pumps the events
        /// </summary>
        [return: NotNull]
        public static void PumpEvents() => INTERNAL_SDL_PumpEvents();

        /// <summary>
        ///     Sdl the peep events using the specified events
        /// </summary>
        /// <param name="events">The events</param>
        /// <param name="numEvents">The num events</param>
        /// <param name="action">The action</param>
        /// <param name="minType">The min type</param>
        /// <param name="maxType">The max type</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_PeepEvents", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern int INTERNAL_SDL_PeepEvents([Out] SdlEvent[] events, [NotNull] int numEvents, SdlEventAction action, SdlEventType minType, SdlEventType maxType);

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
        public static int PeepEvents([Out] SdlEvent[] events, [NotNull] int numEvents, SdlEventAction action, SdlEventType minType, SdlEventType maxType) => INTERNAL_SDL_PeepEvents(events, numEvents, action, minType.Validate(), maxType.Validate());


        /// <summary>
        ///     Sdl the has event using the specified type
        /// </summary>
        /// <param name="type">The type</param>
        /// <returns>The sdl bool</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_HasEvent", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern SdlBool INTERNAL_SDL_HasEvent(SdlEventType type);

        /// <summary>
        ///     Has the event using the specified type
        /// </summary>
        /// <param name="type">The type</param>
        /// <returns>The sdl bool</returns>
        [return: NotNull]
        public static SdlBool HasEvent(SdlEventType type) => INTERNAL_SDL_HasEvent(type.Validate());

        /// <summary>
        ///     Sdl the has events using the specified min type
        /// </summary>
        /// <param name="minType">The min type</param>
        /// <param name="maxType">The max type</param>
        /// <returns>The sdl bool</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_HasEvents", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern SdlBool INTERNAL_SDL_HasEvents(SdlEventType minType, SdlEventType maxType);

        /// <summary>
        ///     Has the events using the specified min type
        /// </summary>
        /// <param name="minType">The min type</param>
        /// <param name="maxType">The max type</param>
        /// <returns>The sdl bool</returns>
        [return: NotNull]
        public static SdlBool HasEvents(SdlEventType minType, SdlEventType maxType) => INTERNAL_SDL_HasEvents(minType.Validate(), maxType.Validate());

        /// <summary>
        ///     Sdl the flush event using the specified type
        /// </summary>
        /// <param name="type">The type</param>
        [DllImport(NativeLibName, EntryPoint = "SDL_FlushEvent", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern void INTERNAL_SDL_FlushEvent(SdlEventType type);

        /// <summary>
        ///     Flushes the event using the specified type
        /// </summary>
        /// <param name="type">The type</param>
        [return: NotNull]
        public static void FlushEvent([NotNull] SdlEventType type) => INTERNAL_SDL_FlushEvent(type.Validate());

        /// <summary>
        ///     Sdl the flush events using the specified min
        /// </summary>
        /// <param name="min">The min</param>
        /// <param name="max">The max</param>
        [DllImport(NativeLibName, EntryPoint = "SDL_FlushEvents", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern void INTERNAL_SDL_FlushEvents(SdlEventType min, SdlEventType max);

        /// <summary>
        ///     Flushes the events using the specified min
        /// </summary>
        /// <param name="min">The min</param>
        /// <param name="max">The max</param>
        [return: NotNull]
        public static void FlushEvents(SdlEventType min, SdlEventType max) => INTERNAL_SDL_FlushEvents(min.Validate(), max.Validate());

        /// <summary>
        ///     Sdl the poll event using the specified  event
        /// </summary>
        /// <param name="sdlEvent">The event</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_PollEvent", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern int INTERNAL_SDL_PollEvent(out SdlEvent sdlEvent);

        /// <summary>
        ///     Polls the event using the specified sdl event
        /// </summary>
        /// <param name="sdlEvent">The sdl event</param>
        /// <returns>The int</returns>
        [return: NotNull]
        public static int PollEvent(out SdlEvent sdlEvent) => INTERNAL_SDL_PollEvent(out sdlEvent).Validate();

        /// <summary>
        ///     Sdl the wait event using the specified  event
        /// </summary>
        /// <param name="sdlEvent">The event</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_WaitEvent", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern int INTERNAL_SDL_WaitEvent(out SdlEvent sdlEvent);

        /// <summary>
        ///     Waits the event using the specified sdl event
        /// </summary>
        /// <param name="sdlEvent">The sdl event</param>
        /// <returns>The int</returns>
        [return: NotNull]
        public static int WaitEvent(out SdlEvent sdlEvent) => INTERNAL_SDL_WaitEvent(out sdlEvent);

        /// <summary>
        ///     Sdl the wait event timeout using the specified  event
        /// </summary>
        /// <param name="sdlEvent">The event</param>
        /// <param name="timeout">The timeout</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_WaitEventTimeout", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern int INTERNAL_SDL_WaitEventTimeout(out SdlEvent sdlEvent, [NotNull] int timeout);

        /// <summary>
        ///     Waits the event timeout using the specified sdl event
        /// </summary>
        /// <param name="sdlEvent">The sdl event</param>
        /// <param name="timeout">The timeout</param>
        /// <returns>The int</returns>
        [return: NotNull]
        public static int WaitEventTimeout(out SdlEvent sdlEvent, [NotNull] int timeout) => INTERNAL_SDL_WaitEventTimeout(out sdlEvent, timeout).Validate();

        /// <summary>
        ///     Sdl the push event using the specified  event
        /// </summary>
        /// <param name="sdlEvent">The event</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_PushEvent", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern int INTERNAL_SDL_PushEvent(ref SdlEvent sdlEvent);

        /// <summary>
        ///     Pushes the event using the specified sdl event
        /// </summary>
        /// <param name="sdlEvent">The sdl event</param>
        /// <returns>The int</returns>
        [return: NotNull]
        public static int PushEvent(ref SdlEvent sdlEvent) => INTERNAL_SDL_PushEvent(ref sdlEvent).Validate();

        /// <summary>
        ///     Sdl the set event filter using the specified filter
        /// </summary>
        /// <param name="filter">The filter</param>
        /// <param name="userdata">The userdata</param>
        [DllImport(NativeLibName, EntryPoint = "SDL_SetEventFilter", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern void INTERNAL_SDL_SetEventFilter(SdlEventFilter filter, [NotNull] IntPtr userdata);

        /// <summary>
        ///     Sets the event filter using the specified filter
        /// </summary>
        /// <param name="filter">The filter</param>
        /// <param name="userdata">The userdata</param>
        [return: NotNull]
        public static void SetEventFilter(SdlEventFilter filter, [NotNull] IntPtr userdata) => INTERNAL_SDL_SetEventFilter(filter.Validate(), userdata.Validate());

        /// <summary>
        ///     Sdl the get event filter using the specified filter
        /// </summary>
        /// <param name="filter">The filter</param>
        /// <param name="userdata">The userdata</param>
        /// <returns>The sdl bool</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GetEventFilter", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern SdlBool INTERNAL_SDL_GetEventFilter(out IntPtr filter, out IntPtr userdata);

        /// <summary>
        ///     Sdl the get event filter using the specified filter
        /// </summary>
        /// <param name="filter">The filter</param>
        /// <param name="userdata">The userdata</param>
        /// <returns>The ret val</returns>
        [return: NotNull]
        public static SdlBool GetEventFilter(out SdlEventFilter filter, out IntPtr userdata)
        {
            SdlBool val = INTERNAL_SDL_GetEventFilter(out IntPtr result, out userdata);
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
        ///     Sdl the add event watch using the specified filter
        /// </summary>
        /// <param name="filter">The filter</param>
        /// <param name="userdata">The userdata</param>
        [DllImport(NativeLibName, EntryPoint = "SDL_AddEventWatch", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern void INTERNAL_SDL_AddEventWatch(SdlEventFilter filter, [NotNull] IntPtr userdata);

        /// <summary>
        ///     Adds the event watch using the specified filter
        /// </summary>
        /// <param name="filter">The filter</param>
        /// <param name="userdata">The userdata</param>
        [return: NotNull]
        public static void AddEventWatch(SdlEventFilter filter, [NotNull] IntPtr userdata) => INTERNAL_SDL_AddEventWatch(filter.Validate(), userdata.Validate());

        /// <summary>
        ///     Sdl the del event watch using the specified filter
        /// </summary>
        /// <param name="filter">The filter</param>
        /// <param name="userdata">The userdata</param>
        [DllImport(NativeLibName, EntryPoint = "SDL_DelEventWatch", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern void INTERNAL_SDL_DelEventWatch(SdlEventFilter filter, [NotNull] IntPtr userdata);

        /// <summary>
        ///     Del the event watch using the specified filter
        /// </summary>
        /// <param name="filter">The filter</param>
        /// <param name="userdata">The userdata</param>
        [return: NotNull]
        public static void DelEventWatch(SdlEventFilter filter, [NotNull] IntPtr userdata) => INTERNAL_SDL_DelEventWatch(filter.Validate(), userdata.Validate());

        /// <summary>
        ///     Sdl the filter events using the specified filter
        /// </summary>
        /// <param name="filter">The filter</param>
        /// <param name="userdata">The userdata</param>
        [DllImport(NativeLibName, EntryPoint = "SDL_FilterEvents", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern void INTERNAL_SDL_FilterEvents(SdlEventFilter filter, IntPtr userdata);

        /// <summary>
        ///     Filters the events using the specified filter
        /// </summary>
        /// <param name="filter">The filter</param>
        /// <param name="userdata">The userdata</param>
        [return: NotNull]
        public static void FilterEvents([NotNull] SdlEventFilter filter, [NotNull] IntPtr userdata) => INTERNAL_SDL_FilterEvents(filter.Validate(), userdata.Validate());

        /// <summary>
        ///     Sdl the event state using the specified type
        /// </summary>
        /// <param name="type">The type</param>
        /// <param name="state">The state</param>
        /// <returns>The byte</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_EventState", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern byte INTERNAL_SDL_EventState(SdlEventType type, [NotNull] int state);

        /// <summary>
        ///     Sdl the get event state using the specified type
        /// </summary>
        /// <param name="type">The type</param>
        /// <returns>The byte</returns>
        [return: NotNull]
        public static byte GetEventState(SdlEventType type) => INTERNAL_SDL_EventState(type, Query);

        /// <summary>
        ///     Sdl the register events using the specified num events
        /// </summary>
        /// <param name="numEvents">The num events</param>
        /// <returns>The int 32</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_RegisterEvents", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern uint INTERNAL_SDL_RegisterEvents([NotNull] int numEvents);

        /// <summary>
        ///     Registers the events using the specified num events
        /// </summary>
        /// <param name="numEvents">The num events</param>
        /// <returns>The uint</returns>
        [return: NotNull]
        public static uint RegisterEvents([NotNull] int numEvents) => INTERNAL_SDL_RegisterEvents(numEvents).Validate();

        /// <summary>
        ///     Sdl the scancode to keycode using the specified x
        /// </summary>
        /// <param name="x">The </param>
        /// <returns>The sdl keycode</returns>
        [return: NotNull]
        public static SdlKeycode ScanCodeToKeyCode(SdlScancode x) => (SdlKeycode) ((int) x | KScancodeMask);

        /// <summary>
        ///     Sdl the get keyboard focus
        /// </summary>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GetKeyboardFocus", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern IntPtr INTERNAL_SDL_GetKeyboardFocus();

        /// <summary>
        ///     Gets the keyboard focus
        /// </summary>
        /// <returns>The int ptr</returns>
        [return: NotNull]
        public static IntPtr GetKeyboardFocus() => INTERNAL_SDL_GetKeyboardFocus().Validate();

        /// <summary>
        ///     Sdl the get keyboard state using the specified num keys
        /// </summary>
        /// <param name="numKeys">The num keys</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GetKeyboardState", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern IntPtr INTERNAL_SDL_GetKeyboardState(out int numKeys);

        /// <summary>
        ///     Gets the keyboard state using the specified num keys
        /// </summary>
        /// <param name="numKeys">The num keys</param>
        /// <returns>The int ptr</returns>
        [return: NotNull]
        public static IntPtr GetKeyboardState(out int numKeys) => INTERNAL_SDL_GetKeyboardState(out numKeys).Validate();

        /// <summary>
        ///     Sdl the get mod state
        /// </summary>
        /// <returns>The sdl key mod</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GetModState", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern SdlKeymod INTERNAL_SDL_GetModState();

        /// <summary>
        ///     Gets the mod state
        /// </summary>
        /// <returns>The sdl key mod</returns>
        [return: NotNull]
        public static SdlKeymod GetModState() => INTERNAL_SDL_GetModState().Validate();

        /// <summary>
        ///     Sdl the set mod state using the specified mod state
        /// </summary>
        /// <param name="modState">The mod state</param>
        [DllImport(NativeLibName, EntryPoint = "SDL_SetModState", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern void INTERNAL_SDL_SetModState(SdlKeymod modState);

        /// <summary>
        ///     Sets the mod state using the specified mod state
        /// </summary>
        /// <param name="modState">The mod state</param>
        [return: NotNull]
        public static void SetModState(SdlKeymod modState) => INTERNAL_SDL_SetModState(modState);

        /// <summary>
        ///     Sdl the get key from scancode using the specified scancode
        /// </summary>
        /// <param name="scancode">The scancode</param>
        /// <returns>The sdl keycode</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GetKeyFromScancode", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern SdlKeycode INTERNAL_SDL_GetKeyFromScancode(SdlScancode scancode);

        /// <summary>
        ///     Gets the key from scancode using the specified scancode
        /// </summary>
        /// <param name="scancode">The scancode</param>
        /// <returns>The sdl keycode</returns>
        [return: NotNull]
        public static SdlKeycode GetKeyFromScancode(SdlScancode scancode) => INTERNAL_SDL_GetKeyFromScancode(scancode).Validate();

        /// <summary>
        ///     Sdl the get scancode from key using the specified key
        /// </summary>
        /// <param name="key">The key</param>
        /// <returns>The sdl scancode</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GetScancodeFromKey", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern SdlScancode INTERNAL_SDL_GetScancodeFromKey(SdlKeycode key);

        /// <summary>
        ///     Gets the scancode from key using the specified key
        /// </summary>
        /// <param name="key">The key</param>
        /// <returns>The sdl scancode</returns>
        [return: NotNull]
        public static SdlScancode GetScancodeFromKey(SdlKeycode key) => INTERNAL_SDL_GetScancodeFromKey(key).Validate();

        /// <summary>
        ///     Internals the sdl get scancode name using the specified scancode
        /// </summary>
        /// <param name="scancode">The scancode</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GetScancodeName", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern IntPtr INTERNAL_SDL_GetScancodeName(SdlScancode scancode);

        /// <summary>
        ///     Sdl the get scancode name using the specified scancode
        /// </summary>
        /// <param name="scancode">The scancode</param>
        /// <returns>The string</returns>
        [return: NotNull]
        public static string GetScancodeName(SdlScancode scancode) => Utf8Manager.Utf8ToManaged(INTERNAL_SDL_GetScancodeName(scancode));

        /// <summary>
        ///     Internals the sdl get scancode from name using the specified name
        /// </summary>
        /// <param name="name">The name</param>
        /// <returns>The sdl scancode</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GetScancodeFromName", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern SdlScancode INTERNAL_SDL_GetScancodeFromName([NotNull] byte[] name);

        /// <summary>
        ///     Sdl the get scancode from name using the specified name
        /// </summary>
        /// <param name="name">The name</param>
        /// <returns>The sdl scancode</returns>
        [return: NotNull]
        public static SdlScancode GetScancodeFromName([NotNull] string name) => INTERNAL_SDL_GetScancodeFromName(Utf8Manager.Utf8Encode(name, new byte[Utf8Manager.Utf8Size(name)], Utf8Manager.Utf8Size(name)));

        /// <summary>
        ///     Internals the sdl get key name using the specified key
        /// </summary>
        /// <param name="key">The key</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GetKeyName", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern IntPtr INTERNAL_SDL_GetKeyName(SdlKeycode key);

        /// <summary>
        ///     Sdl the get key name using the specified key
        /// </summary>
        /// <param name="key">The key</param>
        /// <returns>The string</returns>
        [return: NotNull]
        public static string SGetKeyName(SdlKeycode key) => Utf8Manager.Utf8ToManaged(INTERNAL_SDL_GetKeyName(key));

        /// <summary>
        ///     Internals the sdl get key from name using the specified name
        /// </summary>
        /// <param name="name">The name</param>
        /// <returns>The sdl keycode</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GetKeyFromName", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern SdlKeycode INTERNAL_SDL_GetKeyFromName([NotNull] byte[] name);

        /// <summary>
        ///     Sdl the get key from name using the specified name
        /// </summary>
        /// <param name="name">The name</param>
        /// <returns>The sdl keycode</returns>
        [return: NotNull]
        public static SdlKeycode GetKeyFromName([NotNull] string name) => INTERNAL_SDL_GetKeyFromName(Utf8Manager.Utf8Encode(name, new byte[Utf8Manager.Utf8Size(name)], Utf8Manager.Utf8Size(name)));

        /// <summary>
        ///     Sdl the start text input
        /// </summary>
        [DllImport(NativeLibName, EntryPoint = "SDL_StartTextInput", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern void INTERNAL_SDL_StartTextInput();

        /// <summary>
        ///     Starts the text input
        /// </summary>
        [return: NotNull]
        public static void StartTextInput() => INTERNAL_SDL_StartTextInput();

        /// <summary>
        ///     Sdl the is text input active
        /// </summary>
        /// <returns>The sdl bool</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_IsTextInputActive", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern SdlBool INTERNAL_SDL_IsTextInputActive();

        /// <summary>
        ///     Is the text input active
        /// </summary>
        /// <returns>The sdl bool</returns>
        [return: NotNull]
        public static SdlBool IsTextInputActive() => INTERNAL_SDL_IsTextInputActive().Validate();

        /// <summary>
        ///     Sdl the stop text input
        /// </summary>
        [DllImport(NativeLibName, EntryPoint = "SDL_StopTextInput", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern void INTERNAL_SDL_StopTextInput();

        /// <summary>
        ///     Stops the text input
        /// </summary>
        [return: NotNull]
        public static void StopTextInput() => INTERNAL_SDL_StopTextInput();

        /// <summary>
        ///     Sdl the set text input rect using the specified rect
        /// </summary>
        /// <param name="rect">The rect</param>
        [DllImport(NativeLibName, EntryPoint = "SDL_SetTextInputRect", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern void INTERNAL_SDL_SetTextInputRect(ref RectangleI rect);

        /// <summary>
        ///     Sets the text input rect using the specified rect
        /// </summary>
        /// <param name="rect">The rect</param>
        [return: NotNull]
        public static void SetTextInputRect(ref RectangleI rect) => INTERNAL_SDL_SetTextInputRect(ref rect);

        /// <summary>
        ///     Sdl the has screen keyboard support
        /// </summary>
        /// <returns>The sdl bool</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_HasScreenKeyboardSupport", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern SdlBool INTERNAL_SDL_HasScreenKeyboardSupport();

        /// <summary>
        ///     Has the screen keyboard support
        /// </summary>
        /// <returns>The sdl bool</returns>
        [return: NotNull]
        public static SdlBool HasScreenKeyboardSupport() => INTERNAL_SDL_HasScreenKeyboardSupport().Validate();

        /// <summary>
        ///     Sdl the is screen keyboard shown using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <returns>The sdl bool</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_IsScreenKeyboardShown", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern SdlBool INTERNAL_SDL_IsScreenKeyboardShown([NotNull] IntPtr window);

        /// <summary>
        ///     Is the screen keyboard shown using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <returns>The sdl bool</returns>
        [return: NotNull]
        public static SdlBool IsScreenKeyboardShown([NotNull] IntPtr window) => INTERNAL_SDL_IsScreenKeyboardShown(window.Validate()).Validate();

        /// <summary>
        ///     Sdl the get mouse focus
        /// </summary>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GetMouseFocus", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern IntPtr INTERNAL_SDL_GetMouseFocus();

        /// <summary>
        ///     Gets the mouse focus
        /// </summary>
        /// <returns>The int ptr</returns>
        [return: NotNull]
        public static IntPtr GetMouseFocus() => INTERNAL_SDL_GetMouseFocus().Validate();

        /// <summary>
        ///     Sdl the get mouse state using the specified x
        /// </summary>
        /// <param name="x">The </param>
        /// <param name="y">The </param>
        /// <returns>The int 32</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GetMouseState", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern uint INTERNAL_SDL_GetMouseState(out int x, out int y);

        /// <summary>
        ///     Gets the mouse state using the specified x
        /// </summary>
        /// <param name="x">The </param>
        /// <param name="y">The </param>
        /// <returns>The uint</returns>
        [return: NotNull]
        public static uint GetMouseStateOutXAndY(out int x, out int y) => INTERNAL_SDL_GetMouseState(out x, out y).Validate();

        /// <summary>
        ///     Sdl the get mouse state using the specified x
        /// </summary>
        /// <param name="x">The </param>
        /// <param name="y">The </param>
        /// <returns>The int 32</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GetMouseState", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern uint INTERNAL_SDL_GetMouseState([NotNull] IntPtr x, out int y);

        /// <summary>
        ///     Gets the mouse state using the specified x
        /// </summary>
        /// <param name="x">The </param>
        /// <param name="y">The </param>
        /// <returns>The uint</returns>
        [return: NotNull]
        public static uint GetMouseStateXAndYOut([NotNull] IntPtr x, out int y) => INTERNAL_SDL_GetMouseState(x.Validate(), out y);

        /// <summary>
        ///     Sdl the get mouse state using the specified x
        /// </summary>
        /// <param name="x">The </param>
        /// <param name="y">The </param>
        /// <returns>The int 32</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GetMouseState", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern uint INTERNAL_SDL_GetMouseState(out int x, [NotNull] IntPtr y);

        /// <summary>
        ///     Gets the mouse state using the specified x
        /// </summary>
        /// <param name="x">The </param>
        /// <param name="y">The </param>
        /// <returns>The uint</returns>
        [return: NotNull]
        public static uint GetMouseStateXOutAndY(out int x, [NotNull] IntPtr y) => INTERNAL_SDL_GetMouseState(out x, y.Validate());

        /// <summary>
        ///     Sdl the get mouse state using the specified x
        /// </summary>
        /// <param name="x">The </param>
        /// <param name="y">The </param>
        /// <returns>The int 32</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GetMouseState", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern uint INTERNAL_SDL_GetMouseState([NotNull] IntPtr x, [NotNull] IntPtr y);

        /// <summary>
        ///     Gets the mouse state using the specified x
        /// </summary>
        /// <param name="x">The </param>
        /// <param name="y">The </param>
        /// <returns>The uint</returns>
        [return: NotNull]
        public static uint GetMouseStateToXAndY([NotNull] IntPtr x, [NotNull] IntPtr y) => INTERNAL_SDL_GetMouseState(x.Validate(), y.Validate());

        /// <summary>
        ///     Sdl the get global mouse state using the specified x
        /// </summary>
        /// <param name="x">The </param>
        /// <param name="y">The </param>
        /// <returns>The int 32</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GetGlobalMouseState", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern uint INTERNAL_SDL_GetGlobalMouseState(out int x, out int y);

        /// <summary>
        ///     Gets the global mouse state using the specified x
        /// </summary>
        /// <param name="x">The </param>
        /// <param name="y">The </param>
        /// <returns>The uint</returns>
        [return: NotNull]
        public static uint GetGlobalMouseStateOutXAndOutY(out int x, out int y) => INTERNAL_SDL_GetGlobalMouseState(out x, out y).Validate();

        /// <summary>
        ///     Sdl the get global mouse state using the specified x
        /// </summary>
        /// <param name="x">The </param>
        /// <param name="y">The </param>
        /// <returns>The int 32</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GetGlobalMouseState", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern uint INTERNAL_SDL_GetGlobalMouseState([NotNull] IntPtr x, out int y);

        /// <summary>
        ///     Gets the global mouse state using the specified x
        /// </summary>
        /// <param name="x">The </param>
        /// <param name="y">The </param>
        /// <returns>The uint</returns>
        [return: NotNull]
        public static uint GetGlobalMouseStateXAndYOut([NotNull] IntPtr x, out int y) => INTERNAL_SDL_GetGlobalMouseState(x.Validate(), out y).Validate();

        /// <summary>
        ///     Sdl the get global mouse state using the specified x
        /// </summary>
        /// <param name="x">The </param>
        /// <param name="y">The </param>
        /// <returns>The int 32</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GetGlobalMouseState", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern uint INTERNAL_SDL_GetGlobalMouseState(out int x, [NotNull] IntPtr y);

        /// <summary>
        ///     Gets the global mouse state using the specified x
        /// </summary>
        /// <param name="x">The </param>
        /// <param name="y">The </param>
        /// <returns>The uint</returns>
        [return: NotNull]
        public static uint GetGlobalMouseStateOutXAndY(out int x, [NotNull] IntPtr y) => INTERNAL_SDL_GetGlobalMouseState(out x, y.Validate()).Validate();

        /// <summary>
        ///     Sdl the get global mouse state using the specified x
        /// </summary>
        /// <param name="x">The </param>
        /// <param name="y">The </param>
        /// <returns>The int 32</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GetGlobalMouseState", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern uint INTERNAL_SDL_GetGlobalMouseState([NotNull] IntPtr x, [NotNull] IntPtr y);

        /// <summary>
        ///     Gets the global mouse state using the specified x
        /// </summary>
        /// <param name="x">The </param>
        /// <param name="y">The </param>
        /// <returns>The uint</returns>
        [return: NotNull]
        public static uint GetGlobalMouseStateXAndY([NotNull] IntPtr x, [NotNull] IntPtr y) => INTERNAL_SDL_GetGlobalMouseState(x.Validate(), y.Validate()).Validate();

        /// <summary>
        ///     Sdl the get relative mouse state using the specified x
        /// </summary>
        /// <param name="x">The </param>
        /// <param name="y">The </param>
        /// <returns>The int 32</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GetRelativeMouseState", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern uint INTERNAL_SDL_GetRelativeMouseState(out int x, out int y);

        /// <summary>
        ///     Gets the relative mouse state using the specified x
        /// </summary>
        /// <param name="x">The </param>
        /// <param name="y">The </param>
        /// <returns>The uint</returns>
        [return: NotNull]
        public static uint GetRelativeMouseState(out int x, out int y) => INTERNAL_SDL_GetRelativeMouseState(out x, out y).Validate();

        /// <summary>
        ///     Sdl the warp mouse in window using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="x">The </param>
        /// <param name="y">The </param>
        [DllImport(NativeLibName, EntryPoint = "SDL_WarpMouseInWindow", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern void INTERNAL_SDL_WarpMouseInWindow([NotNull] IntPtr window, [NotNull] int x, [NotNull] int y);

        /// <summary>
        ///     Warps the mouse in window using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="x">The </param>
        /// <param name="y">The </param>
        [return: NotNull]
        public static void WarpMouseInWindow([NotNull] IntPtr window, [NotNull] int x, [NotNull] int y) => INTERNAL_SDL_WarpMouseInWindow(window.Validate(), x.Validate(), y.Validate());

        /// <summary>
        ///     Sdl the warp mouse global using the specified x
        /// </summary>
        /// <param name="x">The </param>
        /// <param name="y">The </param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_WarpMouseGlobal", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern int INTERNAL_SDL_WarpMouseGlobal([NotNull] int x, [NotNull] int y);

        /// <summary>
        ///     Warps the mouse global using the specified x
        /// </summary>
        /// <param name="x">The </param>
        /// <param name="y">The </param>
        /// <returns>The int</returns>
        [return: NotNull]
        public static int WarpMouseGlobal([NotNull] int x, [NotNull] int y) => INTERNAL_SDL_WarpMouseGlobal(x.Validate(), y.Validate());

        /// <summary>
        ///     Sdl the set relative mouse mode using the specified enabled
        /// </summary>
        /// <param name="enabled">The enabled</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_SetRelativeMouseMode", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern int INTERNAL_SDL_SetRelativeMouseMode(SdlBool enabled);

        /// <summary>
        ///     Sets the relative mouse mode using the specified enabled
        /// </summary>
        /// <param name="enabled">The enabled</param>
        /// <returns>The int</returns>
        [return: NotNull]
        public static int SetRelativeMouseMode(SdlBool enabled) => INTERNAL_SDL_SetRelativeMouseMode(enabled.Validate());

        /// <summary>
        ///     Sdl the capture mouse using the specified enabled
        /// </summary>
        /// <param name="enabled">The enabled</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_CaptureMouse", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern int INTERNAL_SDL_CaptureMouse(SdlBool enabled);

        /// <summary>
        ///     Captures the mouse using the specified enabled
        /// </summary>
        /// <param name="enabled">The enabled</param>
        /// <returns>The int</returns>
        [return: NotNull]
        public static int CaptureMouse([NotNull] SdlBool enabled) => INTERNAL_SDL_CaptureMouse(enabled.Validate());

        /// <summary>
        ///     Sdl the get relative mouse mode
        /// </summary>
        /// <returns>The sdl bool</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GetRelativeMouseMode", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern SdlBool INTERNAL_SDL_GetRelativeMouseMode();

        /// <summary>
        ///     Gets the relative mouse mode
        /// </summary>
        /// <returns>The sdl bool</returns>
        [return: NotNull]
        public static SdlBool GetRelativeMouseMode() => INTERNAL_SDL_GetRelativeMouseMode().Validate();

        /// <summary>
        ///     Sdl the create cursor using the specified data
        /// </summary>
        /// <param name="data">The data</param>
        /// <param name="mask">The mask</param>
        /// <param name="w">The </param>
        /// <param name="h">The </param>
        /// <param name="hotX">The hot</param>
        /// <param name="hotY">The hot</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_CreateCursor", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern IntPtr INTERNAL_SDL_CreateCursor([NotNull] IntPtr data, [NotNull] IntPtr mask, [NotNull] int w, [NotNull] int h, [NotNull] int hotX, [NotNull] int hotY);

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
        public static IntPtr CreateCursor([NotNull] IntPtr data, [NotNull] IntPtr mask, [NotNull] int w, [NotNull] int h, [NotNull] int hotX, [NotNull] int hotY) => INTERNAL_SDL_CreateCursor(data.Validate(), mask.Validate(), w, h, hotX, hotY);

        /// <summary>
        ///     Sdl the create color cursor using the specified surface
        /// </summary>
        /// <param name="surface">The surface</param>
        /// <param name="hotX">The hot</param>
        /// <param name="hotY">The hot</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_CreateColorCursor", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern IntPtr INTERNAL_SDL_CreateColorCursor([NotNull] IntPtr surface, [NotNull] int hotX, [NotNull] int hotY);

        /// <summary>
        ///     Creates the color cursor using the specified surface
        /// </summary>
        /// <param name="surface">The surface</param>
        /// <param name="hotX">The hot</param>
        /// <param name="hotY">The hot</param>
        /// <returns>The int ptr</returns>
        [return: NotNull]
        public static IntPtr CreateColorCursor([NotNull] IntPtr surface, [NotNull] int hotX, [NotNull] int hotY) => INTERNAL_SDL_CreateColorCursor(surface.Validate(), hotX, hotY);

        /// <summary>
        ///     Sdl the create system cursor using the specified id
        /// </summary>
        /// <param name="id">The id</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_CreateSystemCursor", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern IntPtr INTERNAL_SDL_CreateSystemCursor(SdlSystemCursor id);

        /// <summary>
        ///     Creates the system cursor using the specified id
        /// </summary>
        /// <param name="id">The id</param>
        /// <returns>The int ptr</returns>
        [return: NotNull]
        public static IntPtr CreateSystemCursor(SdlSystemCursor id) => INTERNAL_SDL_CreateSystemCursor(id.Validate());

        /// <summary>
        ///     Sdl the set cursor using the specified cursor
        /// </summary>
        /// <param name="cursor">The cursor</param>
        [DllImport(NativeLibName, EntryPoint = "SDL_SetCursor", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern void INTERNAL_SDL_SetCursor([NotNull] IntPtr cursor);

        /// <summary>
        ///     Sets the cursor using the specified cursor
        /// </summary>
        /// <param name="cursor">The cursor</param>
        [return: NotNull]
        public static void SetCursor([NotNull] IntPtr cursor) => INTERNAL_SDL_SetCursor(cursor.Validate());

        /// <summary>
        ///     Sdl the get cursor
        /// </summary>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GetCursor", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern IntPtr INTERNAL_SDL_GetCursor();

        /// <summary>
        ///     Gets the cursor
        /// </summary>
        /// <returns>The int ptr</returns>
        [return: NotNull]
        public static IntPtr GetCursor() => INTERNAL_SDL_GetCursor().Validate();

        /// <summary>
        ///     Sdl the free cursor using the specified cursor
        /// </summary>
        /// <param name="cursor">The cursor</param>
        [DllImport(NativeLibName, EntryPoint = "SDL_FreeCursor", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern void INTERNAL_SDL_FreeCursor([NotNull] IntPtr cursor);

        /// <summary>
        ///     Frees the cursor using the specified cursor
        /// </summary>
        /// <param name="cursor">The cursor</param>
        [return: NotNull]
        public static void FreeCursor([NotNull] IntPtr cursor) => INTERNAL_SDL_FreeCursor(cursor.Validate());

        /// <summary>
        ///     Sdl the show cursor using the specified toggle
        /// </summary>
        /// <param name="toggle">The toggle</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_ShowCursor", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern int INTERNAL_SDL_ShowCursor([NotNull] int toggle);

        /// <summary>
        ///     Shows the cursor using the specified toggle
        /// </summary>
        /// <param name="toggle">The toggle</param>
        /// <returns>The int</returns>
        [return: NotNull]
        public static int ShowCursor([NotNull] int toggle) => INTERNAL_SDL_ShowCursor(toggle.Validate()).Validate();

        /// <summary>
        ///     Sdl the button using the specified x
        /// </summary>
        /// <param name="x">The </param>
        /// <returns>The uint</returns>
        [return: NotNull]
        public static uint Button([NotNull] uint x) => (uint) (1 << ((int) x - 1));

        /// <summary>
        ///     Sdl the get num touch devices
        /// </summary>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GetNumTouchDevices", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern int INTERNAL_SDL_GetNumTouchDevices();

        /// <summary>
        ///     Gets the num touch devices
        /// </summary>
        /// <returns>The int</returns>
        [return: NotNull]
        public static int GetNumTouchDevices() => INTERNAL_SDL_GetNumTouchDevices().Validate();

        /// <summary>
        ///     Sdl the get touch device using the specified index
        /// </summary>
        /// <param name="index">The index</param>
        /// <returns>The long</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GetTouchDevice", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern long INTERNAL_SDL_GetTouchDevice([NotNull] int index);

        /// <summary>
        ///     Gets the touch device using the specified index
        /// </summary>
        /// <param name="index">The index</param>
        /// <returns>The long</returns>
        [return: NotNull]
        public static long GetTouchDevice([NotNull] int index) => INTERNAL_SDL_GetTouchDevice(index.Validate());

        /// <summary>
        ///     Sdl the get num touch fingers using the specified touch id
        /// </summary>
        /// <param name="touchId">The touch id</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GetNumTouchFingers", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern int INTERNAL_SDL_GetNumTouchFingers(long touchId);

        /// <summary>
        ///     Gets the num touch fingers using the specified touch id
        /// </summary>
        /// <param name="touchId">The touch id</param>
        /// <returns>The int</returns>
        [return: NotNull]
        public static int GetNumTouchFingers(long touchId) => INTERNAL_SDL_GetNumTouchFingers(touchId.Validate());

        /// <summary>
        ///     Sdl the get touch finger using the specified touch id
        /// </summary>
        /// <param name="touchId">The touch id</param>
        /// <param name="index">The index</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GetTouchFinger", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern IntPtr INTERNAL_SDL_GetTouchFinger([NotNull] long touchId, [NotNull] int index);

        /// <summary>
        ///     Gets the touch finger using the specified touch id
        /// </summary>
        /// <param name="touchId">The touch id</param>
        /// <param name="index">The index</param>
        /// <returns>The int ptr</returns>
        [return: NotNull]
        public static IntPtr GetTouchFinger([NotNull] long touchId, [NotNull] int index) => INTERNAL_SDL_GetTouchFinger(touchId.Validate(), index.Validate());

        /// <summary>
        ///     Sdl the get touch device type using the specified touch id
        /// </summary>
        /// <param name="touchId">The touch id</param>
        /// <returns>The sdl touch device type</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GetTouchDeviceType", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern SdlTouchDeviceType INTERNAL_SDL_GetTouchDeviceType([NotNull] long touchId);

        /// <summary>
        ///     Gets the touch device type using the specified touch id
        /// </summary>
        /// <param name="touchId">The touch id</param>
        /// <returns>The sdl touch device type</returns>
        [return: NotNull]
        public static SdlTouchDeviceType GetTouchDeviceType([NotNull] long touchId) => INTERNAL_SDL_GetTouchDeviceType(touchId.Validate());


        /// <summary>
        ///     Sdl the joystick rumble using the specified joystick
        /// </summary>
        /// <param name="joystick">The joystick</param>
        /// <param name="lowFrequencyRumble">The low frequency rumble</param>
        /// <param name="highFrequencyRumble">The high frequency rumble</param>
        /// <param name="durationMs">The duration ms</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_JoystickRumble", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern int INTERNAL_SDL_JoystickRumble([NotNull] IntPtr joystick, [NotNull] ushort lowFrequencyRumble, [NotNull] ushort highFrequencyRumble, [NotNull] uint durationMs);

        /// <summary>
        ///     Joysticks the rumble using the specified joystick
        /// </summary>
        /// <param name="joystick">The joystick</param>
        /// <param name="lowFrequencyRumble">The low frequency rumble</param>
        /// <param name="highFrequencyRumble">The high frequency rumble</param>
        /// <param name="durationMs">The duration ms</param>
        /// <returns>The int</returns>
        [return: NotNull]
        public static int JoystickRumble([NotNull] IntPtr joystick, [NotNull] ushort lowFrequencyRumble, [NotNull] ushort highFrequencyRumble, [NotNull] uint durationMs) => INTERNAL_SDL_JoystickRumble(joystick.Validate(), lowFrequencyRumble, highFrequencyRumble, durationMs);

        /// <summary>
        ///     Sdl the joystick rumble triggers using the specified joystick
        /// </summary>
        /// <param name="joystick">The joystick</param>
        /// <param name="leftRumble">The left rumble</param>
        /// <param name="rightRumble">The right rumble</param>
        /// <param name="durationMs">The duration ms</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_JoystickRumbleTriggers", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern int INTERNAL_SDL_JoystickRumbleTriggers([NotNull] IntPtr joystick, [NotNull] ushort leftRumble, [NotNull] ushort rightRumble, [NotNull] uint durationMs);

        /// <summary>
        ///     Joysticks the rumble triggers using the specified joystick
        /// </summary>
        /// <param name="joystick">The joystick</param>
        /// <param name="leftRumble">The left rumble</param>
        /// <param name="rightRumble">The right rumble</param>
        /// <param name="durationMs">The duration ms</param>
        /// <returns>The int</returns>
        [return: NotNull]
        public static int JoystickRumbleTriggers([NotNull] IntPtr joystick, [NotNull] ushort leftRumble, [NotNull] ushort rightRumble, [NotNull] uint durationMs) => INTERNAL_SDL_JoystickRumbleTriggers(joystick.Validate(), leftRumble, rightRumble, durationMs);

        /// <summary>
        ///     Sdl the joystick close using the specified joystick
        /// </summary>
        /// <param name="joystick">The joystick</param>
        [DllImport(NativeLibName, EntryPoint = "SDL_JoystickClose", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern void INTERNAL_SDL_JoystickClose([NotNull] IntPtr joystick);

        /// <summary>
        ///     Joysticks the close using the specified joystick
        /// </summary>
        /// <param name="joystick">The joystick</param>
        [return: NotNull]
        public static void JoystickClose([NotNull] IntPtr joystick) => INTERNAL_SDL_JoystickClose(joystick.Validate());

        /// <summary>
        ///     Sdl the joystick event state using the specified state
        /// </summary>
        /// <param name="state">The state</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_JoystickEventState", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern int INTERNAL_SDL_JoystickEventState([NotNull] int state);

        /// <summary>
        ///     Joysticks the event state using the specified state
        /// </summary>
        /// <param name="state">The state</param>
        /// <returns>The int</returns>
        [return: NotNull]
        public static int JoystickEventState([NotNull] int state) => INTERNAL_SDL_JoystickEventState(state.Validate());

        /// <summary>
        ///     Sdl the joystick get axis using the specified joystick
        /// </summary>
        /// <param name="joystick">The joystick</param>
        /// <param name="axis">The axis</param>
        /// <returns>The short</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_JoystickGetAxis", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern short INTERNAL_SDL_JoystickGetAxis([NotNull] IntPtr joystick, [NotNull] int axis);

        /// <summary>
        ///     Joysticks the get axis using the specified joystick
        /// </summary>
        /// <param name="joystick">The joystick</param>
        /// <param name="axis">The axis</param>
        /// <returns>The short</returns>
        [return: NotNull]
        public static short JoystickGetAxis([NotNull] IntPtr joystick, [NotNull] int axis) => INTERNAL_SDL_JoystickGetAxis(joystick.Validate(), axis);

        /// <summary>
        ///     Sdl the joystick get axis initial state using the specified joystick
        /// </summary>
        /// <param name="joystick">The joystick</param>
        /// <param name="axis">The axis</param>
        /// <param name="state">The state</param>
        /// <returns>The sdl bool</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_JoystickGetAxisInitialState", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern SdlBool INTERNAL_SDL_JoystickGetAxisInitialState([NotNull] IntPtr joystick, [NotNull] int axis, out ushort state);

        /// <summary>
        ///     Joysticks the get axis initial state using the specified joystick
        /// </summary>
        /// <param name="joystick">The joystick</param>
        /// <param name="axis">The axis</param>
        /// <param name="state">The state</param>
        /// <returns>The sdl bool</returns>
        [return: NotNull]
        public static SdlBool JoystickGetAxisInitialState([NotNull] IntPtr joystick, [NotNull] int axis, out ushort state) => INTERNAL_SDL_JoystickGetAxisInitialState(joystick.Validate(), axis, out state);

        /// <summary>
        ///     Sdl the joystick get ball using the specified joystick
        /// </summary>
        /// <param name="joystick">The joystick</param>
        /// <param name="ball">The ball</param>
        /// <param name="dx">The dx</param>
        /// <param name="dy">The dy</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_JoystickGetBall", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern int INTERNAL_SDL_JoystickGetBall([NotNull] IntPtr joystick, [NotNull] int ball, out int dx, out int dy);

        /// <summary>
        ///     Joysticks the get ball using the specified joystick
        /// </summary>
        /// <param name="joystick">The joystick</param>
        /// <param name="ball">The ball</param>
        /// <param name="dx">The dx</param>
        /// <param name="dy">The dy</param>
        /// <returns>The int</returns>
        [return: NotNull]
        public static int JoystickGetBall([NotNull] IntPtr joystick, [NotNull] int ball, out int dx, out int dy) => INTERNAL_SDL_JoystickGetBall(joystick.Validate(), ball.Validate(), out dx, out dy);

        /// <summary>
        ///     Sdl the joystick get button using the specified joystick
        /// </summary>
        /// <param name="joystick">The joystick</param>
        /// <param name="button">The button</param>
        /// <returns>The byte</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_JoystickGetButton", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern byte INTERNAL_SDL_JoystickGetButton([NotNull] IntPtr joystick, [NotNull] int button);

        /// <summary>
        ///     Joysticks the get button using the specified joystick
        /// </summary>
        /// <param name="joystick">The joystick</param>
        /// <param name="button">The button</param>
        /// <returns>The byte</returns>
        [return: NotNull]
        public static byte JoystickGetButton([NotNull] IntPtr joystick, [NotNull] int button) => INTERNAL_SDL_JoystickGetButton(joystick.Validate(), button.Validate());

        /// <summary>
        ///     Sdl the joystick get hat using the specified joystick
        /// </summary>
        /// <param name="joystick">The joystick</param>
        /// <param name="hat">The hat</param>
        /// <returns>The byte</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_JoystickGetHat", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern byte INTERNAL_SDL_JoystickGetHat([NotNull] IntPtr joystick, [NotNull] int hat);

        /// <summary>
        ///     Joysticks the get hat using the specified joystick
        /// </summary>
        /// <param name="joystick">The joystick</param>
        /// <param name="hat">The hat</param>
        /// <returns>The byte</returns>
        [return: NotNull]
        public static byte JoystickGetHat([NotNull] IntPtr joystick, [NotNull] int hat) => INTERNAL_SDL_JoystickGetHat(joystick.Validate(), hat.Validate());

        /// <summary>
        ///     Internals the sdl joystick name using the specified joystick
        /// </summary>
        /// <param name="joystick">The joystick</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_JoystickName", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern IntPtr INTERNAL_SDL_JoystickName([NotNull] IntPtr joystick);

        /// <summary>
        ///     Sdl the joystick name using the specified joystick
        /// </summary>
        /// <param name="joystick">The joystick</param>
        /// <returns>The string</returns>
        [return: NotNull]
        public static string JoystickName([NotNull] IntPtr joystick) => Utf8Manager.Utf8ToManaged(INTERNAL_SDL_JoystickName(joystick));

        /// <summary>
        ///     Internals the sdl joystick name for index using the specified device index
        /// </summary>
        /// <param name="deviceIndex">The device index</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_JoystickNameForIndex", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern IntPtr INTERNAL_SDL_JoystickNameForIndex([NotNull] int deviceIndex);

        /// <summary>
        ///     Sdl the joystick name for index using the specified device index
        /// </summary>
        /// <param name="deviceIndex">The device index</param>
        /// <returns>The string</returns>
        [return: NotNull]
        public static string JoystickNameForIndex([NotNull] int deviceIndex) => Utf8Manager.Utf8ToManaged(INTERNAL_SDL_JoystickNameForIndex(deviceIndex));

        /// <summary>
        ///     Sdl the joystick num axes using the specified joystick
        /// </summary>
        /// <param name="joystick">The joystick</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_JoystickNumAxes", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern int INTERNAL_SDL_JoystickNumAxes([NotNull] IntPtr joystick);

        /// <summary>
        ///     Joysticks the num axes using the specified joystick
        /// </summary>
        /// <param name="joystick">The joystick</param>
        /// <returns>The int</returns>
        [return: NotNull]
        public static int JoystickNumAxes([NotNull] IntPtr joystick) => INTERNAL_SDL_JoystickNumAxes(joystick.Validate());

        /// <summary>
        ///     Sdl the joystick num balls using the specified joystick
        /// </summary>
        /// <param name="joystick">The joystick</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_JoystickNumBalls", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern int INTERNAL_SDL_JoystickNumBalls([NotNull] IntPtr joystick);

        /// <summary>
        ///     Joysticks the num balls using the specified joystick
        /// </summary>
        /// <param name="joystick">The joystick</param>
        /// <returns>The int</returns>
        [return: NotNull]
        public static int JoystickNumBalls([NotNull] IntPtr joystick) => INTERNAL_SDL_JoystickNumBalls(joystick.Validate());

        /// <summary>
        ///     Sdl the joystick num buttons using the specified joystick
        /// </summary>
        /// <param name="joystick">The joystick</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_JoystickNumButtons", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern int INTERNAL_SDL_JoystickNumButtons([NotNull] IntPtr joystick);

        /// <summary>
        ///     Joysticks the num buttons using the specified joystick
        /// </summary>
        /// <param name="joystick">The joystick</param>
        /// <returns>The int</returns>
        [return: NotNull]
        public static int JoystickNumButtons([NotNull] IntPtr joystick) => INTERNAL_SDL_JoystickNumButtons(joystick.Validate());

        /// <summary>
        ///     Sdl the joystick num hats using the specified joystick
        /// </summary>
        /// <param name="joystick">The joystick</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_JoystickNumHats", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern int INTERNAL_SDL_JoystickNumHats([NotNull] IntPtr joystick);

        /// <summary>
        ///     Joysticks the num hats using the specified joystick
        /// </summary>
        /// <param name="joystick">The joystick</param>
        /// <returns>The int</returns>
        [return: NotNull]
        public static int JoystickNumHats([NotNull] IntPtr joystick) => INTERNAL_SDL_JoystickNumHats(joystick.Validate());

        /// <summary>
        ///     Sdl the joystick open using the specified device index
        /// </summary>
        /// <param name="deviceIndex">The device index</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_JoystickOpen", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern IntPtr INTERNAL_SDL_JoystickOpen([NotNull] int deviceIndex);

        /// <summary>
        ///     Joysticks the open using the specified device index
        /// </summary>
        /// <param name="deviceIndex">The device index</param>
        /// <returns>The int ptr</returns>
        [return: NotNull]
        public static IntPtr JoystickOpen([NotNull] int deviceIndex) => INTERNAL_SDL_JoystickOpen(deviceIndex.Validate());

        /// <summary>
        ///     Sdl the joystick update
        /// </summary>
        [DllImport(NativeLibName, EntryPoint = "SDL_JoystickUpdate", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern void INTERNAL_SDL_JoystickUpdate();

        /// <summary>
        ///     Joysticks the update
        /// </summary>
        [return: NotNull]
        public static void JoystickUpdate() => INTERNAL_SDL_JoystickUpdate();

        /// <summary>
        ///     Sdl the num joysticks
        /// </summary>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_NumJoysticks", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern int INTERNAL_SDL_NumJoysticks();

        /// <summary>
        ///     Nums the joysticks
        /// </summary>
        /// <returns>The int</returns>
        [return: NotNull]
        public static int NumJoysticks() => INTERNAL_SDL_NumJoysticks();

        /// <summary>
        ///     Sdl the joystick get device guid using the specified device index
        /// </summary>
        /// <param name="deviceIndex">The device index</param>
        /// <returns>The guid</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_JoystickGetDeviceGUID", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern Guid INTERNAL_SDL_JoystickGetDeviceGUID([NotNull] int deviceIndex);

        /// <summary>
        ///     Joysticks the get device guid using the specified device index
        /// </summary>
        /// <param name="deviceIndex">The device index</param>
        /// <returns>The guid</returns>
        [return: NotNull]
        public static Guid JoystickGetDeviceGuid([NotNull] int deviceIndex) => INTERNAL_SDL_JoystickGetDeviceGUID(deviceIndex.Validate());

        /// <summary>
        ///     Sdl the joystick get guid using the specified joystick
        /// </summary>
        /// <param name="joystick">The joystick</param>
        /// <returns>The guid</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_JoystickGetGUID", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern Guid INTERNAL_SDL_JoystickGetGUID(IntPtr joystick);

        /// <summary>
        ///     Joysticks the get guid using the specified joystick
        /// </summary>
        /// <param name="joystick">The joystick</param>
        /// <returns>The guid</returns>
        [return: NotNull]
        public static Guid JoystickGetGuid(IntPtr joystick) => INTERNAL_SDL_JoystickGetGUID(joystick.Validate());

        /// <summary>
        ///     Sdl the joystick get guid string using the specified guid
        /// </summary>
        /// <param name="guid">The guid</param>
        /// <param name="pszGuid">The psz guid</param>
        /// <param name="cbGuid">The cb guid</param>
        [DllImport(NativeLibName, EntryPoint = "SDL_JoystickGetGUIDString", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern void INTERNAL_SDL_JoystickGetGUIDString(Guid guid, [NotNull] byte[] pszGuid, [NotNull] int cbGuid);

        /// <summary>
        ///     Joysticks the get guid string using the specified guid
        /// </summary>
        /// <param name="guid">The guid</param>
        /// <param name="pszGuid">The psz guid</param>
        /// <param name="cbGuid">The cb guid</param>
        [return: NotNull]
        public static void JoystickGetGuidString(Guid guid, [NotNull] byte[] pszGuid, [NotNull] int cbGuid) => INTERNAL_SDL_JoystickGetGUIDString(guid.Validate(), pszGuid.Validate(), cbGuid.Validate());

        /// <summary>
        ///     Internals the sdl joystick get guid from string using the specified pch guid
        /// </summary>
        /// <param name="pchGuid">The pch guid</param>
        /// <returns>The guid</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_JoystickGetGUIDFromString", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern Guid INTERNAL_SDL_JoystickGetGUIDFromString([NotNull] byte[] pchGuid);

        /// <summary>
        ///     Sdl the joystick get guid from string using the specified pch guid
        /// </summary>
        /// <param name="pchGuid">The pch guid</param>
        /// <returns>The guid</returns>
        [return: NotNull]
        public static Guid JoystickGetGuidFromString([NotNull] string pchGuid) => INTERNAL_SDL_JoystickGetGUIDFromString(Utf8Manager.Utf8Encode(pchGuid.Validate(), new byte[Utf8Manager.Utf8Size(pchGuid)], Utf8Manager.Utf8Size(pchGuid)));

        /// <summary>
        ///     Sdl the joystick get device vendor using the specified device index
        /// </summary>
        /// <param name="deviceIndex">The device index</param>
        /// <returns>The ushort</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_JoystickGetDeviceVendor", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern ushort INTERNAL_SDL_JoystickGetDeviceVendor([NotNull] int deviceIndex);

        /// <summary>
        ///     Joysticks the get device vendor using the specified device index
        /// </summary>
        /// <param name="deviceIndex">The device index</param>
        /// <returns>The ushort</returns>
        [return: NotNull]
        public static ushort JoystickGetDeviceVendor([NotNull] int deviceIndex) => INTERNAL_SDL_JoystickGetDeviceVendor(deviceIndex.Validate());

        /// <summary>
        ///     Sdl the joystick get device product using the specified device index
        /// </summary>
        /// <param name="deviceIndex">The device index</param>
        /// <returns>The ushort</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_JoystickGetDeviceProduct", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern ushort INTERNAL_SDL_JoystickGetDeviceProduct([NotNull] int deviceIndex);

        /// <summary>
        ///     Joysticks the get device product using the specified device index
        /// </summary>
        /// <param name="deviceIndex">The device index</param>
        /// <returns>The ushort</returns>
        [return: NotNull]
        public static ushort JoystickGetDeviceProduct([NotNull] int deviceIndex) => INTERNAL_SDL_JoystickGetDeviceProduct(deviceIndex.Validate());

        /// <summary>
        ///     Sdl the joystick get device product version using the specified device index
        /// </summary>
        /// <param name="deviceIndex">The device index</param>
        /// <returns>The ushort</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_JoystickGetDeviceProductVersion", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern ushort INTERNAL_SDL_JoystickGetDeviceProductVersion([NotNull] int deviceIndex);

        /// <summary>
        ///     Joysticks the get device product version using the specified device index
        /// </summary>
        /// <param name="deviceIndex">The device index</param>
        /// <returns>The ushort</returns>
        [return: NotNull]
        public static ushort JoystickGetDeviceProductVersion([NotNull] int deviceIndex) => INTERNAL_SDL_JoystickGetDeviceProductVersion(deviceIndex.Validate());

        /// <summary>
        ///     Sdl the joystick get device type using the specified device index
        /// </summary>
        /// <param name="deviceIndex">The device index</param>
        /// <returns>The sdl joystick type</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_JoystickGetDeviceType", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern SdlJoystickType INTERNAL_SDL_JoystickGetDeviceType([NotNull] int deviceIndex);

        /// <summary>
        ///     Joysticks the get device type using the specified device index
        /// </summary>
        /// <param name="deviceIndex">The device index</param>
        /// <returns>The sdl joystick type</returns>
        [return: NotNull]
        public static SdlJoystickType JoystickGetDeviceType([NotNull] int deviceIndex) => INTERNAL_SDL_JoystickGetDeviceType(deviceIndex.Validate());

        /// <summary>
        ///     Sdl the joystick get device instance id using the specified device index
        /// </summary>
        /// <param name="deviceIndex">The device index</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_JoystickGetDeviceInstanceID", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern int INTERNAL_SDL_JoystickGetDeviceInstanceID([NotNull] int deviceIndex);

        /// <summary>
        ///     Joysticks the get device instance id using the specified device index
        /// </summary>
        /// <param name="deviceIndex">The device index</param>
        /// <returns>The int</returns>
        [return: NotNull]
        public static int JoystickGetDeviceInstanceId([NotNull] int deviceIndex) => INTERNAL_SDL_JoystickGetDeviceInstanceID(deviceIndex.Validate());

        /// <summary>
        ///     Sdl the joystick get vendor using the specified joystick
        /// </summary>
        /// <param name="joystick">The joystick</param>
        /// <returns>The ushort</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_JoystickGetVendor", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern ushort INTERNAL_SDL_JoystickGetVendor([NotNull] IntPtr joystick);

        /// <summary>
        ///     Joysticks the get vendor using the specified joystick
        /// </summary>
        /// <param name="joystick">The joystick</param>
        /// <returns>The ushort</returns>
        [return: NotNull]
        public static ushort JoystickGetVendor([NotNull] IntPtr joystick) => INTERNAL_SDL_JoystickGetVendor(joystick.Validate());

        /// <summary>
        ///     Sdl the joystick get product using the specified joystick
        /// </summary>
        /// <param name="joystick">The joystick</param>
        /// <returns>The ushort</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_JoystickGetProduct", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern ushort INTERNAL_SDL_JoystickGetProduct([NotNull] IntPtr joystick);

        /// <summary>
        ///     Joysticks the get product using the specified joystick
        /// </summary>
        /// <param name="joystick">The joystick</param>
        /// <returns>The ushort</returns>
        [return: NotNull]
        public static ushort JoystickGetProduct([NotNull] IntPtr joystick) => INTERNAL_SDL_JoystickGetProduct(joystick.Validate());

        /// <summary>
        ///     Sdl the joystick get product version using the specified joystick
        /// </summary>
        /// <param name="joystick">The joystick</param>
        /// <returns>The ushort</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_JoystickGetProductVersion", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern ushort INTERNAL_SDL_JoystickGetProductVersion([NotNull] IntPtr joystick);

        /// <summary>
        ///     Joysticks the get product version using the specified joystick
        /// </summary>
        /// <param name="joystick">The joystick</param>
        /// <returns>The ushort</returns>
        [return: NotNull]
        public static ushort JoystickGetProductVersion([NotNull] IntPtr joystick) => INTERNAL_SDL_JoystickGetProductVersion(joystick.Validate());

        /// <summary>
        ///     Internals the sdl joystick get serial using the specified joystick
        /// </summary>
        /// <param name="joystick">The joystick</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_JoystickGetSerial", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern IntPtr INTERNAL_SDL_JoystickGetSerial([NotNull] IntPtr joystick);

        /// <summary>
        ///     Sdl the joystick get serial using the specified joystick
        /// </summary>
        /// <param name="joystick">The joystick</param>
        /// <returns>The string</returns>
        [return: NotNull]
        public static string JoystickGetSerial([NotNull] IntPtr joystick) => Utf8Manager.Utf8ToManaged(INTERNAL_SDL_JoystickGetSerial(joystick));

        /// <summary>
        ///     Sdl the joystick get type using the specified joystick
        /// </summary>
        /// <param name="joystick">The joystick</param>
        /// <returns>The sdl joystick type</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_JoystickGetType", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern SdlJoystickType INTERNAL_SDL_JoystickGetType([NotNull] IntPtr joystick);

        /// <summary>
        ///     Joysticks the get type using the specified joystick
        /// </summary>
        /// <param name="joystick">The joystick</param>
        /// <returns>The sdl joystick type</returns>
        [return: NotNull]
        public static SdlJoystickType JoystickGetType([NotNull] IntPtr joystick) => INTERNAL_SDL_JoystickGetType(joystick.Validate());

        /// <summary>
        ///     Sdl the joystick get attached using the specified joystick
        /// </summary>
        /// <param name="joystick">The joystick</param>
        /// <returns>The sdl bool</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_JoystickGetAttached", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern SdlBool INTERNAL_SDL_JoystickGetAttached([NotNull] IntPtr joystick);

        /// <summary>
        ///     Joysticks the get attached using the specified joystick
        /// </summary>
        /// <param name="joystick">The joystick</param>
        /// <returns>The sdl bool</returns>
        [return: NotNull]
        public static SdlBool JoystickGetAttached([NotNull] IntPtr joystick) => INTERNAL_SDL_JoystickGetAttached(joystick.Validate());

        /// <summary>
        ///     Sdl the joystick instance id using the specified joystick
        /// </summary>
        /// <param name="joystick">The joystick</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_JoystickInstanceID", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern int INTERNAL_SDL_JoystickInstanceID([NotNull] IntPtr joystick);

        /// <summary>
        ///     Joysticks the instance id using the specified joystick
        /// </summary>
        /// <param name="joystick">The joystick</param>
        /// <returns>The int</returns>
        [return: NotNull]
        public static int JoystickInstanceId([NotNull] IntPtr joystick) => INTERNAL_SDL_JoystickInstanceID(joystick.Validate());

        /// <summary>
        ///     Sdl the joystick current power level using the specified joystick
        /// </summary>
        /// <param name="joystick">The joystick</param>
        /// <returns>The sdl joystick power level</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_JoystickCurrentPowerLevel", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern SdlJoystickPowerLevel INTERNAL_SDL_JoystickCurrentPowerLevel([NotNull] IntPtr joystick);

        /// <summary>
        ///     Joysticks the current power level using the specified joystick
        /// </summary>
        /// <param name="joystick">The joystick</param>
        /// <returns>The sdl joystick power level</returns>
        [return: NotNull]
        public static SdlJoystickPowerLevel JoystickCurrentPowerLevel([NotNull] IntPtr joystick) => INTERNAL_SDL_JoystickCurrentPowerLevel(joystick.Validate());

        /// <summary>
        ///     Sdl the joystick from instance id using the specified instance id
        /// </summary>
        /// <param name="instanceId">The instance id</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_JoystickFromInstanceID", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern IntPtr INTERNAL_SDL_JoystickFromInstanceID([NotNull] int instanceId);

        /// <summary>
        ///     Joysticks the from instance id using the specified instance id
        /// </summary>
        /// <param name="instanceId">The instance id</param>
        /// <returns>The int ptr</returns>
        [return: NotNull]
        public static IntPtr JoystickFromInstanceId([NotNull] int instanceId) => INTERNAL_SDL_JoystickFromInstanceID(instanceId);

        /// <summary>
        ///     Sdl the lock joysticks
        /// </summary>
        [DllImport(NativeLibName, EntryPoint = "SDL_LockJoysticks", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern void INTERNAL_SDL_LockJoysticks();

        /// <summary>
        ///     Locks the joysticks
        /// </summary>
        [return: NotNull]
        public static void LockJoysticks() => INTERNAL_SDL_LockJoysticks();

        /// <summary>
        ///     Sdl the unlock joysticks
        /// </summary>
        [DllImport(NativeLibName, EntryPoint = "SDL_UnlockJoysticks", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern void INTERNAL_SDL_UnlockJoysticks();

        /// <summary>
        ///     Unlocks the joysticks
        /// </summary>
        [return: NotNull]
        public static void UnlockJoysticks() => INTERNAL_SDL_UnlockJoysticks();

        /// <summary>
        ///     Sdl the joystick from player index using the specified player index
        /// </summary>
        /// <param name="playerIndex">The player index</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_JoystickFromPlayerIndex", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern IntPtr INTERNAL_SDL_JoystickFromPlayerIndex([NotNull] int playerIndex);

        /// <summary>
        ///     Joysticks the from player index using the specified player index
        /// </summary>
        /// <param name="playerIndex">The player index</param>
        /// <returns>The int ptr</returns>
        [return: NotNull]
        public static IntPtr JoystickFromPlayerIndex([NotNull] int playerIndex) => INTERNAL_SDL_JoystickFromPlayerIndex(playerIndex.Validate());

        /// <summary>
        ///     Sdl the joystick set player index using the specified joystick
        /// </summary>
        /// <param name="joystick">The joystick</param>
        /// <param name="playerIndex">The player index</param>
        [DllImport(NativeLibName, EntryPoint = "SDL_JoystickSetPlayerIndex", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern void INTERNAL_SDL_JoystickSetPlayerIndex([NotNull] IntPtr joystick, [NotNull] int playerIndex);

        /// <summary>
        ///     Joysticks the set player index using the specified joystick
        /// </summary>
        /// <param name="joystick">The joystick</param>
        /// <param name="playerIndex">The player index</param>
        [return: NotNull]
        public static void JoystickSetPlayerIndex([NotNull] IntPtr joystick, [NotNull] int playerIndex) => INTERNAL_SDL_JoystickSetPlayerIndex(joystick.Validate(), playerIndex.Validate());

        /// <summary>
        ///     Sdl the joystick attach virtual using the specified type
        /// </summary>
        /// <param name="type">The type</param>
        /// <param name="nAxes">The n axes</param>
        /// <param name="nButtons">The n buttons</param>
        /// <param name="nHats">The n hats</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_JoystickAttachVirtual", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern int INTERNAL_SDL_JoystickAttachVirtual([NotNull] int type, [NotNull] int nAxes, [NotNull] int nButtons, [NotNull] int nHats);

        /// <summary>
        ///     Sdl the joystick attach virtual using the specified type
        /// </summary>
        /// <param name="type">The type</param>
        /// <param name="nAxes">The axes</param>
        /// <param name="nButtons">The buttons</param>
        /// <param name="nHats">The hats</param>
        /// <returns>The int</returns>
        [return: NotNull]
        public static int SdlJoystickAttachVirtual([NotNull] int type, [NotNull] int nAxes, [NotNull] int nButtons, [NotNull] int nHats) => INTERNAL_SDL_JoystickAttachVirtual(type, nAxes, nButtons, nHats);

        /// <summary>
        ///     Sdl the joystick detach virtual using the specified device index
        /// </summary>
        /// <param name="deviceIndex">The device index</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_JoystickDetachVirtual", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern int INTERNAL_SDL_JoystickDetachVirtual([NotNull] int deviceIndex);

        /// <summary>
        ///     Joysticks the detach virtual using the specified device index
        /// </summary>
        /// <param name="deviceIndex">The device index</param>
        /// <returns>The int</returns>
        [return: NotNull]
        public static int JoystickDetachVirtual([NotNull] int deviceIndex) => INTERNAL_SDL_JoystickDetachVirtual(deviceIndex.Validate());

        /// <summary>
        ///     Sdl the joystick is virtual using the specified device index
        /// </summary>
        /// <param name="deviceIndex">The device index</param>
        /// <returns>The sdl bool</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_JoystickIsVirtual", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern SdlBool INTERNAL_SDL_JoystickIsVirtual([NotNull] int deviceIndex);

        /// <summary>
        ///     Joysticks the is virtual using the specified device index
        /// </summary>
        /// <param name="deviceIndex">The device index</param>
        /// <returns>The sdl bool</returns>
        [return: NotNull]
        public static SdlBool JoystickIsVirtual([NotNull] int deviceIndex) => INTERNAL_SDL_JoystickIsVirtual(deviceIndex.Validate());

        /// <summary>
        ///     Sdl the joystick set virtual axis using the specified joystick
        /// </summary>
        /// <param name="joystick">The joystick</param>
        /// <param name="axis">The axis</param>
        /// <param name="value">The value</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_JoystickSetVirtualAxis", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern int INTERNAL_SDL_JoystickSetVirtualAxis([NotNull] IntPtr joystick, [NotNull] int axis, short value);

        /// <summary>
        ///     Joysticks the set virtual axis using the specified joystick
        /// </summary>
        /// <param name="joystick">The joystick</param>
        /// <param name="axis">The axis</param>
        /// <param name="value">The value</param>
        /// <returns>The int</returns>
        [return: NotNull]
        public static int JoystickSetVirtualAxis([NotNull] IntPtr joystick, [NotNull] int axis, short value) => INTERNAL_SDL_JoystickSetVirtualAxis(joystick.Validate(), axis.Validate(), value.Validate());

        /// <summary>
        ///     Sdl the joystick set virtual button using the specified joystick
        /// </summary>
        /// <param name="joystick">The joystick</param>
        /// <param name="button">The button</param>
        /// <param name="value">The value</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_JoystickSetVirtualButton", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern int INTERNAL_SDL_JoystickSetVirtualButton([NotNull] IntPtr joystick, [NotNull] int button, [NotNull] byte value);

        /// <summary>
        ///     Joysticks the set virtual button using the specified joystick
        /// </summary>
        /// <param name="joystick">The joystick</param>
        /// <param name="button">The button</param>
        /// <param name="value">The value</param>
        /// <returns>The int</returns>
        [return: NotNull]
        public static int JoystickSetVirtualButton([NotNull] IntPtr joystick, [NotNull] int button, [NotNull] byte value) => INTERNAL_SDL_JoystickSetVirtualButton(joystick.Validate(), button.Validate(), value.Validate());

        /// <summary>
        ///     Sdl the joystick set virtual hat using the specified joystick
        /// </summary>
        /// <param name="joystick">The joystick</param>
        /// <param name="hat">The hat</param>
        /// <param name="value">The value</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_JoystickSetVirtualHat", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern int INTERNAL_SDL_JoystickSetVirtualHat([NotNull] IntPtr joystick, [NotNull] int hat, [NotNull] byte value);

        /// <summary>
        ///     Joysticks the set virtual hat using the specified joystick
        /// </summary>
        /// <param name="joystick">The joystick</param>
        /// <param name="hat">The hat</param>
        /// <param name="value">The value</param>
        /// <returns>The int</returns>
        [return: NotNull]
        public static int JoystickSetVirtualHat([NotNull] IntPtr joystick, [NotNull] int hat, [NotNull] byte value) => INTERNAL_SDL_JoystickSetVirtualHat(joystick.Validate(), hat.Validate(), value.Validate());

        /// <summary>
        ///     Sdl the joystick has led using the specified joystick
        /// </summary>
        /// <param name="joystick">The joystick</param>
        /// <returns>The sdl bool</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_JoystickHasLED", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern SdlBool INTERNAL_SDL_JoystickHasLED([NotNull] IntPtr joystick);

        /// <summary>
        ///     Joysticks the has led using the specified joystick
        /// </summary>
        /// <param name="joystick">The joystick</param>
        /// <returns>The sdl bool</returns>
        [return: NotNull]
        public static SdlBool JoystickHasLed([NotNull] IntPtr joystick) => INTERNAL_SDL_JoystickHasLED(joystick.Validate());

        /// <summary>
        ///     Sdl the joystick has rumble using the specified joystick
        /// </summary>
        /// <param name="joystick">The joystick</param>
        /// <returns>The sdl bool</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_JoystickHasRumble", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern SdlBool INTERNAL_SDL_JoystickHasRumble([NotNull] IntPtr joystick);

        /// <summary>
        ///     Joysticks the has rumble using the specified joystick
        /// </summary>
        /// <param name="joystick">The joystick</param>
        /// <returns>The sdl bool</returns>
        [return: NotNull]
        public static SdlBool JoystickHasRumble([NotNull] IntPtr joystick) => INTERNAL_SDL_JoystickHasRumble(joystick.Validate());

        /// <summary>
        ///     Sdl the joystick has rumble triggers using the specified joystick
        /// </summary>
        /// <param name="joystick">The joystick</param>
        /// <returns>The sdl bool</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_JoystickHasRumbleTriggers", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern SdlBool INTERNAL_SDL_JoystickHasRumbleTriggers([NotNull] IntPtr joystick);

        /// <summary>
        ///     Joysticks the has rumble triggers using the specified joystick
        /// </summary>
        /// <param name="joystick">The joystick</param>
        /// <returns>The sdl bool</returns>
        [return: NotNull]
        public static SdlBool JoystickHasRumbleTriggers([NotNull] IntPtr joystick) => INTERNAL_SDL_JoystickHasRumbleTriggers(joystick.Validate());


        /// <summary>
        ///     Sdl the joystick set led using the specified joystick
        /// </summary>
        /// <param name="joystick">The joystick</param>
        /// <param name="red">The red</param>
        /// <param name="green">The green</param>
        /// <param name="blue">The blue</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_JoystickSetLED", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern int INTERNAL_SDL_JoystickSetLED([NotNull] IntPtr joystick, [NotNull] byte red, [NotNull] byte green, [NotNull] byte blue);

        /// <summary>
        ///     Joysticks the set led using the specified joystick
        /// </summary>
        /// <param name="joystick">The joystick</param>
        /// <param name="red">The red</param>
        /// <param name="green">The green</param>
        /// <param name="blue">The blue</param>
        /// <returns>The int</returns>
        [return: NotNull]
        public static int JoystickSetLed([NotNull] IntPtr joystick, [NotNull] byte red, [NotNull] byte green, [NotNull] byte blue) => INTERNAL_SDL_JoystickSetLED(joystick.Validate(), red.Validate(), green.Validate(), blue.Validate());

        /// <summary>
        ///     Sdl the joystick send effect using the specified joystick
        /// </summary>
        /// <param name="joystick">The joystick</param>
        /// <param name="data">The data</param>
        /// <param name="size">The size</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_JoystickSendEffect", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern int INTERNAL_SDL_JoystickSendEffect([NotNull] IntPtr joystick, [NotNull] IntPtr data, [NotNull] int size);

        /// <summary>
        ///     Joysticks the send effect using the specified joystick
        /// </summary>
        /// <param name="joystick">The joystick</param>
        /// <param name="data">The data</param>
        /// <param name="size">The size</param>
        /// <returns>The int</returns>
        [return: NotNull]
        public static int JoystickSendEffect([NotNull] IntPtr joystick, [NotNull] IntPtr data, [NotNull] int size) => INTERNAL_SDL_JoystickSendEffect(joystick.Validate(), data.Validate(), size.Validate());

        /// <summary>
        ///     Internals the sdl game controller add mapping using the specified mapping string
        /// </summary>
        /// <param name="mappingString">The mapping string</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GameControllerAddMapping", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern int INTERNAL_SDL_GameControllerAddMapping([NotNull] byte[] mappingString);

        /// <summary>
        ///     Sdl the game controller add mapping using the specified mapping string
        /// </summary>
        /// <param name="mappingString">The mapping string</param>
        /// <returns>The result</returns>
        [return: NotNull]
        public static int GameControllerAddMapping([NotNull] string mappingString) => INTERNAL_SDL_GameControllerAddMapping(Utf8Manager.Utf8EncodeHeap(mappingString));

        /// <summary>
        ///     Sdl the game controller num mappings
        /// </summary>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GameControllerNumMappings", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern int INTERNAL_SDL_GameControllerNumMappings();

        /// <summary>
        ///     Games the controller num mappings
        /// </summary>
        /// <returns>The int</returns>
        [return: NotNull]
        public static int GameControllerNumMappings() => INTERNAL_SDL_GameControllerNumMappings().Validate();

        /// <summary>
        ///     Internals the sdl game controller mapping for index using the specified mapping index
        /// </summary>
        /// <param name="mappingIndex">The mapping index</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GameControllerMappingForIndex", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern IntPtr INTERNAL_SDL_GameControllerMappingForIndex([NotNull] int mappingIndex);

        /// <summary>
        ///     Sdl the game controller mapping for index using the specified mapping index
        /// </summary>
        /// <param name="mappingIndex">The mapping index</param>
        /// <returns>The string</returns>
        [return: NotNull]
        public static string GameControllerMappingForIndex([NotNull] int mappingIndex) => Utf8Manager.Utf8ToManaged(INTERNAL_SDL_GameControllerMappingForIndex(mappingIndex), true);

        /// <summary>
        ///     Internals the sdl game controller add mappings from rw using the specified rw
        /// </summary>
        /// <param name="rw">The rw</param>
        /// <param name="freeRw">The free rw</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GameControllerAddMappingsFromRW", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern int INTERNAL_SDL_GameControllerAddMappingsFromRW([NotNull] IntPtr rw, [NotNull] int freeRw);

        /// <summary>
        ///     Sdl the game controller add mappings from file using the specified file
        /// </summary>
        /// <param name="file">The file</param>
        /// <returns>The int</returns>
        [return: NotNull]
        public static int GameControllerAddMappingsFromFile([NotNull] string file) => INTERNAL_SDL_GameControllerAddMappingsFromRW(RwFromFile(file, "rb"), 1);

        /// <summary>
        ///     Internals the sdl game controller mapping for guid using the specified guid
        /// </summary>
        /// <param name="guid">The guid</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GameControllerMappingForGUID", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern IntPtr INTERNAL_SDL_GameControllerMappingForGUID(Guid guid);

        /// <summary>
        ///     Sdl the game controller mapping for guid using the specified guid
        /// </summary>
        /// <param name="guid">The guid</param>
        /// <returns>The string</returns>
        [return: NotNull]
        public static string GameControllerMappingForGuid(Guid guid) => Utf8Manager.Utf8ToManaged(INTERNAL_SDL_GameControllerMappingForGUID(guid), true);

        /// <summary>
        ///     Internals the sdl game controller mapping using the specified game controller
        /// </summary>
        /// <param name="gameController">The game controller</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GameControllerMapping", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern IntPtr INTERNAL_SDL_GameControllerMapping([NotNull] IntPtr gameController);

        /// <summary>
        ///     Sdl the game controller mapping using the specified game controller
        /// </summary>
        /// <param name="gameController">The game controller</param>
        /// <returns>The string</returns>
        [return: NotNull]
        public static string GameControllerMapping([NotNull] IntPtr gameController) => Utf8Manager.Utf8ToManaged(INTERNAL_SDL_GameControllerMapping(gameController), true);

        /// <summary>
        ///     Sdl the is game controller using the specified joystick index
        /// </summary>
        /// <param name="joystickIndex">The joystick index</param>
        /// <returns>The sdl bool</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_IsGameController", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern SdlBool INTERNAL_SDL_IsGameController([NotNull] int joystickIndex);

        /// <summary>
        ///     Is the game controller using the specified joystick index
        /// </summary>
        /// <param name="joystickIndex">The joystick index</param>
        /// <returns>The sdl bool</returns>
        [return: NotNull]
        public static SdlBool IsGameController([NotNull] int joystickIndex) => INTERNAL_SDL_IsGameController(joystickIndex.Validate());

        /// <summary>
        ///     Internals the sdl game controller name for index using the specified joystick index
        /// </summary>
        /// <param name="joystickIndex">The joystick index</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GameControllerNameForIndex", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern IntPtr INTERNAL_SDL_GameControllerNameForIndex([NotNull] int joystickIndex);

        /// <summary>
        ///     Sdl the game controller name for index using the specified joystick index
        /// </summary>
        /// <param name="joystickIndex">The joystick index</param>
        /// <returns>The string</returns>
        [return: NotNull]
        public static string GameControllerNameForIndex([NotNull] int joystickIndex) => Utf8Manager.Utf8ToManaged(INTERNAL_SDL_GameControllerNameForIndex(joystickIndex));

        /// <summary>
        ///     Internals the sdl game controller mapping for device index using the specified joystick index
        /// </summary>
        /// <param name="joystickIndex">The joystick index</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GameControllerMappingForDeviceIndex", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern IntPtr INTERNAL_SDL_GameControllerMappingForDeviceIndex([NotNull] int joystickIndex);

        /// <summary>
        ///     Sdl the game controller mapping for device index using the specified joystick index
        /// </summary>
        /// <param name="joystickIndex">The joystick index</param>
        /// <returns>The string</returns>
        [return: NotNull]
        public static string GameControllerMappingForDeviceIndex([NotNull] int joystickIndex) => Utf8Manager.Utf8ToManaged(INTERNAL_SDL_GameControllerMappingForDeviceIndex(joystickIndex), true);

        /// <summary>
        ///     Sdl the game controller open using the specified joystick index
        /// </summary>
        /// <param name="joystickIndex">The joystick index</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GameControllerOpen", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern IntPtr INTERNAL_SDL_GameControllerOpen([NotNull] int joystickIndex);

        /// <summary>
        ///     Games the controller open using the specified joystick index
        /// </summary>
        /// <param name="joystickIndex">The joystick index</param>
        /// <returns>The int ptr</returns>
        [return: NotNull]
        public static IntPtr GameControllerOpen([NotNull] int joystickIndex) => INTERNAL_SDL_GameControllerOpen(joystickIndex.Validate());

        /// <summary>
        ///     Internals the sdl game controller name using the specified game controller
        /// </summary>
        /// <param name="gameController">The game controller</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GameControllerName", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern IntPtr INTERNAL_SDL_GameControllerName([NotNull] IntPtr gameController);

        /// <summary>
        ///     Sdl the game controller name using the specified game controller
        /// </summary>
        /// <param name="gameController">The game controller</param>
        /// <returns>The string</returns>
        [return: NotNull]
        public static string GameControllerName([NotNull] IntPtr gameController) => Utf8Manager.Utf8ToManaged(INTERNAL_SDL_GameControllerName(gameController));

        /// <summary>
        ///     Sdl the game controller get vendor using the specified game controller
        /// </summary>
        /// <param name="gameController">The game controller</param>
        /// <returns>The ushort</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GameControllerGetVendor", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern ushort INTERNAL_SDL_GameControllerGetVendor([NotNull] IntPtr gameController);

        /// <summary>
        ///     Games the controller get vendor using the specified game controller
        /// </summary>
        /// <param name="gameController">The game controller</param>
        /// <returns>The ushort</returns>
        [return: NotNull]
        public static ushort GameControllerGetVendor([NotNull] IntPtr gameController) => INTERNAL_SDL_GameControllerGetVendor(gameController.Validate());

        /// <summary>
        ///     Sdl the game controller get product using the specified game controller
        /// </summary>
        /// <param name="gameController">The game controller</param>
        /// <returns>The ushort</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GameControllerGetProduct", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern ushort INTERNAL_SDL_GameControllerGetProduct([NotNull] IntPtr gameController);

        /// <summary>
        ///     Games the controller get product using the specified game controller
        /// </summary>
        /// <param name="gameController">The game controller</param>
        /// <returns>The ushort</returns>
        [return: NotNull]
        public static ushort GameControllerGetProduct([NotNull] IntPtr gameController) => INTERNAL_SDL_GameControllerGetProduct(gameController.Validate());

        /// <summary>
        ///     Sdl the game controller get product version using the specified game controller
        /// </summary>
        /// <param name="gameController">The game controller</param>
        /// <returns>The ushort</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GameControllerGetProductVersion", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern ushort INTERNAL_SDL_GameControllerGetProductVersion([NotNull] IntPtr gameController);

        /// <summary>
        ///     Games the controller get product version using the specified game controller
        /// </summary>
        /// <param name="gameController">The game controller</param>
        /// <returns>The ushort</returns>
        [return: NotNull]
        public static ushort GameControllerGetProductVersion([NotNull] IntPtr gameController) => INTERNAL_SDL_GameControllerGetProductVersion(gameController.Validate());


        /// <summary>
        ///     Internals the sdl game controller get serial using the specified game controller
        /// </summary>
        /// <param name="gameController">The game controller</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GameControllerGetSerial", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern IntPtr INTERNAL_SDL_GameControllerGetSerial([NotNull] IntPtr gameController);

        /// <summary>
        ///     Sdl the game controller get serial using the specified game controller
        /// </summary>
        /// <param name="gameController">The game controller</param>
        /// <returns>The string</returns>
        [return: NotNull]
        public static string SDL_GameControllerGetSerial([NotNull] IntPtr gameController) => Utf8Manager.Utf8ToManaged(INTERNAL_SDL_GameControllerGetSerial(gameController));

        /// <summary>
        ///     Sdl the game controller get attached using the specified game controller
        /// </summary>
        /// <param name="gameController">The game controller</param>
        /// <returns>The sdl bool</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GameControllerGetAttached", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern SdlBool INTERNAL_SDL_GameControllerGetAttached([NotNull] IntPtr gameController);

        /// <summary>
        ///     Games the controller get attached using the specified game controller
        /// </summary>
        /// <param name="gameController">The game controller</param>
        /// <returns>The sdl bool</returns>
        [return: NotNull]
        public static SdlBool GameControllerGetAttached([NotNull] IntPtr gameController) => INTERNAL_SDL_GameControllerGetAttached(gameController.Validate());

        /// <summary>
        ///     Sdl the game controller get joystick using the specified game controller
        /// </summary>
        /// <param name="gameController">The game controller</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GameControllerGetJoystick", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern IntPtr INTERNAL_SDL_GameControllerGetJoystick([NotNull] IntPtr gameController);

        /// <summary>
        ///     Games the controller get joystick using the specified game controller
        /// </summary>
        /// <param name="gameController">The game controller</param>
        /// <returns>The int ptr</returns>
        [return: NotNull]
        public static IntPtr GameControllerGetJoystick([NotNull] IntPtr gameController) => INTERNAL_SDL_GameControllerGetJoystick(gameController.Validate());

        /// <summary>
        ///     Sdl the game controller event state using the specified state
        /// </summary>
        /// <param name="state">The state</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GameControllerEventState", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern int INTERNAL_SDL_GameControllerEventState([NotNull] int state);

        /// <summary>
        ///     Games the controller event state using the specified state
        /// </summary>
        /// <param name="state">The state</param>
        /// <returns>The int</returns>
        [return: NotNull]
        public static int GameControllerEventState([NotNull] int state) => INTERNAL_SDL_GameControllerEventState(state.Validate());

        /// <summary>
        ///     Sdl the game controller update
        /// </summary>
        [DllImport(NativeLibName, EntryPoint = "SDL_GameControllerUpdate", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern void INTERNAL_SDL_GameControllerUpdate();

        /// <summary>
        ///     Games the controller update
        /// </summary>
        [return: NotNull]
        public static void GameControllerUpdate() => INTERNAL_SDL_GameControllerUpdate();

        /// <summary>
        ///     Internals the sdl game controller get axis from string using the specified pch string
        /// </summary>
        /// <param name="pchString">The pch string</param>
        /// <returns>The sdl game controller axis</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GameControllerGetAxisFromString", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern SdlGameControllerAxis INTERNAL_SDL_GameControllerGetAxisFromString([NotNull] byte[] pchString);

        /// <summary>
        ///     Sdl the game controller get axis from string using the specified pch string
        /// </summary>
        /// <param name="pchString">The pch string</param>
        /// <returns>The sdl game controller axis</returns>
        [return: NotNull]
        public static SdlGameControllerAxis GameControllerGetAxisFromString([NotNull] string pchString) => INTERNAL_SDL_GameControllerGetAxisFromString(Utf8Manager.Utf8Encode(pchString, new byte[Utf8Manager.Utf8Size(pchString)], Utf8Manager.Utf8Size(pchString)));

        /// <summary>
        ///     Internals the sdl game controller get string for axis using the specified axis
        /// </summary>
        /// <param name="axis">The axis</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GameControllerGetStringForAxis", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern IntPtr INTERNAL_SDL_GameControllerGetStringForAxis(SdlGameControllerAxis axis);

        /// <summary>
        ///     Sdl the game controller get string for axis using the specified axis
        /// </summary>
        /// <param name="axis">The axis</param>
        /// <returns>The string</returns>
        [return: NotNull]
        public static string GameControllerGetStringForAxis(SdlGameControllerAxis axis) => Utf8Manager.Utf8ToManaged(INTERNAL_SDL_GameControllerGetStringForAxis(axis));

        /// <summary>
        ///     Internals the sdl game controller get bind for axis using the specified game controller
        /// </summary>
        /// <param name="gameController">The game controller</param>
        /// <param name="axis">The axis</param>
        /// <returns>The internal sdl game controller button bind</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GameControllerGetBindForAxis", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern InternalSdlGameControllerButtonBind INTERNAL_SDL_GameControllerGetBindForAxis([NotNull] IntPtr gameController, SdlGameControllerAxis axis);

        /// <summary>
        ///     Sdl the game controller get bind for axis using the specified game controller
        /// </summary>
        /// <param name="gameController">The game controller</param>
        /// <param name="axis">The axis</param>
        /// <returns>The result</returns>
        [return: NotNull]
        public static SdlGameControllerButtonBind GameControllerGetBindForAxis([NotNull] IntPtr gameController, SdlGameControllerAxis axis)
        {
            // This is guaranteed to never be null
            InternalSdlGameControllerButtonBind dumb = INTERNAL_SDL_GameControllerGetBindForAxis(
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
        ///     Sdl the game controller get axis using the specified game controller
        /// </summary>
        /// <param name="gameController">The game controller</param>
        /// <param name="axis">The axis</param>
        /// <returns>The short</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GameControllerGetAxis", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern short INTERNAL_SDL_GameControllerGetAxis([NotNull] IntPtr gameController, SdlGameControllerAxis axis);

        /// <summary>
        ///     Games the controller get axis using the specified game controller
        /// </summary>
        /// <param name="gameController">The game controller</param>
        /// <param name="axis">The axis</param>
        /// <returns>The short</returns>
        [return: NotNull]
        public static short GameControllerGetAxis([NotNull] IntPtr gameController, SdlGameControllerAxis axis) => INTERNAL_SDL_GameControllerGetAxis(gameController.Validate(), axis);

        /// <summary>
        ///     Internals the sdl game controller get button from string using the specified pch string
        /// </summary>
        /// <param name="pchString">The pch string</param>
        /// <returns>The sdl game controller button</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GameControllerGetButtonFromString", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern SdlGameControllerButton INTERNAL_SDL_GameControllerGetButtonFromString([NotNull] byte[] pchString);

        /// <summary>
        ///     Sdl the game controller get button from string using the specified pch string
        /// </summary>
        /// <param name="pchString">The pch string</param>
        /// <returns>The sdl game controller button</returns>
        [return: NotNull]
        public static SdlGameControllerButton SDL_GameControllerGetButtonFromString([NotNull] string pchString) => INTERNAL_SDL_GameControllerGetButtonFromString(Utf8Manager.Utf8Encode(pchString, new byte[Utf8Manager.Utf8Size(pchString)], Utf8Manager.Utf8Size(pchString)));

        /// <summary>
        ///     Internals the sdl game controller get string for button using the specified button
        /// </summary>
        /// <param name="button">The button</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GameControllerGetStringForButton", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern IntPtr INTERNAL_SDL_GameControllerGetStringForButton(SdlGameControllerButton button);

        /// <summary>
        ///     Sdl the game controller get string for button using the specified button
        /// </summary>
        /// <param name="button">The button</param>
        /// <returns>The string</returns>
        [return: NotNull]
        public static string GameControllerGetStringForButton(SdlGameControllerButton button) => Utf8Manager.Utf8ToManaged(INTERNAL_SDL_GameControllerGetStringForButton(button));

        /// <summary>
        ///     Internals the sdl game controller get bind for button using the specified game controller
        /// </summary>
        /// <param name="gameController">The game controller</param>
        /// <param name="button">The button</param>
        /// <returns>The internal sdl game controller button bind</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GameControllerGetBindForButton", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern InternalSdlGameControllerButtonBind INTERNAL_SDL_GameControllerGetBindForButton([NotNull] IntPtr gameController, SdlGameControllerButton button);

        /// <summary>
        ///     Sdl the game controller get bind for button using the specified game controller
        /// </summary>
        /// <param name="gameController">The game controller</param>
        /// <param name="button">The button</param>
        /// <returns>The result</returns>
        [return: NotNull]
        public static SdlGameControllerButtonBind GameControllerGetBindForButton(
            IntPtr gameController,
            SdlGameControllerButton button
        )
        {
            // This is guaranteed to never be null
            InternalSdlGameControllerButtonBind dumb = INTERNAL_SDL_GameControllerGetBindForButton(
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
        ///     Sdl the game controller get button using the specified game controller
        /// </summary>
        /// <param name="gameController">The game controller</param>
        /// <param name="button">The button</param>
        /// <returns>The byte</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GameControllerGetButton", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern byte INTERNAL_SDL_GameControllerGetButton([NotNull] IntPtr gameController, SdlGameControllerButton button);

        /// <summary>
        ///     Games the controller get button using the specified game controller
        /// </summary>
        /// <param name="gameController">The game controller</param>
        /// <param name="button">The button</param>
        /// <returns>The byte</returns>
        [return: NotNull]
        public static byte GameControllerGetButton([NotNull] IntPtr gameController, SdlGameControllerButton button) => INTERNAL_SDL_GameControllerGetButton(gameController.Validate(), button.Validate());

        /// <summary>
        ///     Sdl the game controller rumble using the specified game controller
        /// </summary>
        /// <param name="gameController">The game controller</param>
        /// <param name="lowFrequencyRumble">The low frequency rumble</param>
        /// <param name="highFrequencyRumble">The high frequency rumble</param>
        /// <param name="durationMs">The duration ms</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GameControllerRumble", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern int INTERNAL_SDL_GameControllerRumble([NotNull] IntPtr gameController, [NotNull] ushort lowFrequencyRumble, [NotNull] ushort highFrequencyRumble, [NotNull] uint durationMs);

        /// <summary>
        ///     Games the controller rumble using the specified game controller
        /// </summary>
        /// <param name="gameController">The game controller</param>
        /// <param name="lowFrequencyRumble">The low frequency rumble</param>
        /// <param name="highFrequencyRumble">The high frequency rumble</param>
        /// <param name="durationMs">The duration ms</param>
        /// <returns>The int</returns>
        [return: NotNull]
        public static int GameControllerRumble([NotNull] IntPtr gameController, [NotNull] ushort lowFrequencyRumble, [NotNull] ushort highFrequencyRumble, [NotNull] uint durationMs) => INTERNAL_SDL_GameControllerRumble(gameController.Validate(), lowFrequencyRumble.Validate(), highFrequencyRumble.Validate(), durationMs.Validate());

        /// <summary>
        ///     Sdl the game controller rumble triggers using the specified game controller
        /// </summary>
        /// <param name="gameController">The game controller</param>
        /// <param name="leftRumble">The left rumble</param>
        /// <param name="rightRumble">The right rumble</param>
        /// <param name="durationMs">The duration ms</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GameControllerRumbleTriggers", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern int INTERNAL_SDL_GameControllerRumbleTriggers([NotNull] IntPtr gameController, [NotNull] ushort leftRumble, [NotNull] ushort rightRumble, [NotNull] uint durationMs);

        /// <summary>
        ///     Games the controller rumble triggers using the specified game controller
        /// </summary>
        /// <param name="gameController">The game controller</param>
        /// <param name="leftRumble">The left rumble</param>
        /// <param name="rightRumble">The right rumble</param>
        /// <param name="durationMs">The duration ms</param>
        /// <returns>The int</returns>
        [return: NotNull]
        public static int GameControllerRumbleTriggers([NotNull] IntPtr gameController, [NotNull] ushort leftRumble, [NotNull] ushort rightRumble, [NotNull] uint durationMs) => INTERNAL_SDL_GameControllerRumbleTriggers(gameController.Validate(), leftRumble, rightRumble, durationMs);

        /// <summary>
        ///     Sdl the game controller close using the specified game controller
        /// </summary>
        /// <param name="gameController">The game controller</param>
        [DllImport(NativeLibName, EntryPoint = "SDL_GameControllerClose", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern void INTERNAL_SDL_GameControllerClose([NotNull] IntPtr gameController);

        /// <summary>
        ///     Games the controller close using the specified game controller
        /// </summary>
        /// <param name="gameController">The game controller</param>
        [return: NotNull]
        public static void GameControllerClose([NotNull] IntPtr gameController) => INTERNAL_SDL_GameControllerClose(gameController.Validate());

        /// <summary>
        ///     Internals the sdl game controller get apple sf symbols name for button using the specified game controller
        /// </summary>
        /// <param name="gameController">The game controller</param>
        /// <param name="button">The button</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GameControllerGetAppleSFSymbolsNameForButton", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern IntPtr INTERNAL_SDL_GameControllerGetAppleSFSymbolsNameForButton([NotNull] IntPtr gameController, SdlGameControllerButton button);

        /// <summary>
        ///     Sdl the game controller get apple sf symbols name for button using the specified game controller
        /// </summary>
        /// <param name="gameController">The game controller</param>
        /// <param name="button">The button</param>
        /// <returns>The string</returns>
        [return: NotNull]
        public static string SDL_GameControllerGetAppleSFSymbolsNameForButton([NotNull] IntPtr gameController, SdlGameControllerButton button) => Utf8Manager.Utf8ToManaged(INTERNAL_SDL_GameControllerGetAppleSFSymbolsNameForButton(gameController, button));

        /// <summary>
        ///     Internals the sdl game controller get apple sf symbols name for axis using the specified game controller
        /// </summary>
        /// <param name="gameController">The game controller</param>
        /// <param name="axis">The axis</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GameControllerGetAppleSFSymbolsNameForAxis", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern IntPtr INTERNAL_SDL_GameControllerGetAppleSFSymbolsNameForAxis([NotNull] IntPtr gameController, SdlGameControllerAxis axis);

        /// <summary>
        ///     Sdl the game controller get apple sf symbols name for axis using the specified game controller
        /// </summary>
        /// <param name="gameController">The game controller</param>
        /// <param name="axis">The axis</param>
        /// <returns>The string</returns>
        [return: NotNull]
        public static string SDL_GameControllerGetAppleSFSymbolsNameForAxis([NotNull] IntPtr gameController, SdlGameControllerAxis axis) => Utf8Manager.Utf8ToManaged(INTERNAL_SDL_GameControllerGetAppleSFSymbolsNameForAxis(gameController, axis));

        /// <summary>
        ///     Sdl the game controller from instance id using the specified joy id
        /// </summary>
        /// <param name="joyId">The joy id</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GameControllerFromInstanceID", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern IntPtr INTERNAL_SDL_GameControllerFromInstanceID([NotNull] int joyId);

        /// <summary>
        ///     Internals the sdl game controller from instance id using the specified joy id
        /// </summary>
        /// <param name="joyId">The joy id</param>
        /// <returns>The int ptr</returns>
        [return: NotNull]
        public static IntPtr GameControllerFromInstanceId([NotNull] int joyId) => INTERNAL_SDL_GameControllerFromInstanceID(joyId.Validate());

        /// <summary>
        ///     Sdl the game controller type for index using the specified joystick index
        /// </summary>
        /// <param name="joystickIndex">The joystick index</param>
        /// <returns>The sdl game controller type</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GameControllerTypeForIndex", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern SdlGameControllerType INTERNAL_SDL_GameControllerTypeForIndex([NotNull] int joystickIndex);

        /// <summary>
        ///     Games the controller type for index using the specified joystick index
        /// </summary>
        /// <param name="joystickIndex">The joystick index</param>
        /// <returns>The sdl game controller type</returns>
        [return: NotNull]
        public static SdlGameControllerType GameControllerTypeForIndex([NotNull] int joystickIndex) => INTERNAL_SDL_GameControllerTypeForIndex(joystickIndex.Validate());

        /// <summary>
        ///     Sdl the game controller get type using the specified game controller
        /// </summary>
        /// <param name="gameController">The game controller</param>
        /// <returns>The sdl game controller type</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GameControllerGetType", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern SdlGameControllerType INTERNAL_SDL_GameControllerGetType([NotNull] IntPtr gameController);

        /// <summary>
        ///     Games the controller get type using the specified game controller
        /// </summary>
        /// <param name="gameController">The game controller</param>
        /// <returns>The sdl game controller type</returns>
        [return: NotNull]
        public static SdlGameControllerType GameControllerGetType([NotNull] IntPtr gameController) => INTERNAL_SDL_GameControllerGetType(gameController.Validate());

        /// <summary>
        ///     Sdl the game controller from player index using the specified player index
        /// </summary>
        /// <param name="playerIndex">The player index</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GameControllerFromPlayerIndex", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern IntPtr INTERNAL_SDL_GameControllerFromPlayerIndex([NotNull] int playerIndex);

        /// <summary>
        ///     Games the controller from player index using the specified player index
        /// </summary>
        /// <param name="playerIndex">The player index</param>
        /// <returns>The int ptr</returns>
        [return: NotNull]
        public static IntPtr GameControllerFromPlayerIndex([NotNull] int playerIndex) => INTERNAL_SDL_GameControllerFromPlayerIndex(playerIndex.Validate());


        /// <summary>
        ///     Sdl the game controller set player index using the specified game controller
        /// </summary>
        /// <param name="gameController">The game controller</param>
        /// <param name="playerIndex">The player index</param>
        [DllImport(NativeLibName, EntryPoint = "SDL_GameControllerSetPlayerIndex", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern void INTERNAL_SDL_GameControllerSetPlayerIndex([NotNull] IntPtr gameController, [NotNull] int playerIndex);

        /// <summary>
        ///     Games the controller set player index using the specified game controller
        /// </summary>
        /// <param name="gameController">The game controller</param>
        /// <param name="playerIndex">The player index</param>
        [return: NotNull]
        public static void GameControllerSetPlayerIndex([NotNull] IntPtr gameController, [NotNull] int playerIndex) => INTERNAL_SDL_GameControllerSetPlayerIndex(gameController, playerIndex.Validate());


        /// <summary>
        ///     Sdl the game controller has led using the specified game controller
        /// </summary>
        /// <param name="gameController">The game controller</param>
        /// <returns>The sdl bool</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GameControllerHasLED", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern SdlBool INTERNAL_SDL_GameControllerHasLED([NotNull] IntPtr gameController);

        /// <summary>
        ///     Games the controller has led using the specified game controller
        /// </summary>
        /// <param name="gameController">The game controller</param>
        /// <returns>The sdl bool</returns>
        [return: NotNull]
        public static SdlBool GameControllerHasLed([NotNull] IntPtr gameController) => INTERNAL_SDL_GameControllerHasLED(gameController.Validate());


        /// <summary>
        ///     Sdl the game controller has rumble using the specified game controller
        /// </summary>
        /// <param name="gameController">The game controller</param>
        /// <returns>The sdl bool</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GameControllerHasRumble", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern SdlBool INTERNAL_SDL_GameControllerHasRumble([NotNull] IntPtr gameController);

        /// <summary>
        ///     Games the controller has rumble using the specified game controller
        /// </summary>
        /// <param name="gameController">The game controller</param>
        /// <returns>The sdl bool</returns>
        [return: NotNull]
        public static SdlBool GameControllerHasRumble([NotNull] IntPtr gameController) => INTERNAL_SDL_GameControllerHasRumble(gameController.Validate());

        /// <summary>
        ///     Sdl the game controller has rumble triggers using the specified game controller
        /// </summary>
        /// <param name="gameController">The game controller</param>
        /// <returns>The sdl bool</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GameControllerHasRumbleTriggers", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern SdlBool INTERNAL_SDL_GameControllerHasRumbleTriggers([NotNull] IntPtr gameController);

        /// <summary>
        ///     Games the controller has rumble triggers using the specified game controller
        /// </summary>
        /// <param name="gameController">The game controller</param>
        /// <returns>The sdl bool</returns>
        [return: NotNull]
        public static SdlBool GameControllerHasRumbleTriggers([NotNull] IntPtr gameController) => INTERNAL_SDL_GameControllerHasRumbleTriggers(gameController.Validate());

        /// <summary>
        ///     Sdl the game controller set led using the specified game controller
        /// </summary>
        /// <param name="gameController">The game controller</param>
        /// <param name="red">The red</param>
        /// <param name="green">The green</param>
        /// <param name="blue">The blue</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GameControllerSetLED", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern int INTERNAL_SDL_GameControllerSetLED([NotNull] IntPtr gameController, [NotNull] byte red, [NotNull] byte green, [NotNull] byte blue);

        /// <summary>
        ///     Games the controller set led using the specified game controller
        /// </summary>
        /// <param name="gameController">The game controller</param>
        /// <param name="red">The red</param>
        /// <param name="green">The green</param>
        /// <param name="blue">The blue</param>
        /// <returns>The int</returns>
        [return: NotNull]
        public static int GameControllerSetLed([NotNull] IntPtr gameController, [NotNull] byte red, [NotNull] byte green, [NotNull] byte blue) => INTERNAL_SDL_GameControllerSetLED(gameController.Validate(), red, green, blue);


        /// <summary>
        ///     Sdl the game controller has axis using the specified game controller
        /// </summary>
        /// <param name="gameController">The game controller</param>
        /// <param name="axis">The axis</param>
        /// <returns>The sdl bool</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GameControllerHasAxis", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern SdlBool INTERNAL_SDL_GameControllerHasAxis([NotNull] IntPtr gameController, SdlGameControllerAxis axis);

        /// <summary>
        ///     Games the controller has axis using the specified game controller
        /// </summary>
        /// <param name="gameController">The game controller</param>
        /// <param name="axis">The axis</param>
        /// <returns>The sdl bool</returns>
        [return: NotNull]
        public static SdlBool GameControllerHasAxis([NotNull] IntPtr gameController, SdlGameControllerAxis axis) => INTERNAL_SDL_GameControllerHasAxis(gameController.Validate(), axis);

        /// <summary>
        ///     Sdl the game controller has button using the specified game controller
        /// </summary>
        /// <param name="gameController">The game controller</param>
        /// <param name="button">The button</param>
        /// <returns>The sdl bool</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GameControllerHasButton", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern SdlBool INTERNAL_SDL_GameControllerHasButton([NotNull] IntPtr gameController, SdlGameControllerButton button);

        /// <summary>
        ///     Games the controller has button using the specified game controller
        /// </summary>
        /// <param name="gameController">The game controller</param>
        /// <param name="button">The button</param>
        /// <returns>The sdl bool</returns>
        [return: NotNull]
        public static SdlBool GameControllerHasButton([NotNull] IntPtr gameController, SdlGameControllerButton button) => INTERNAL_SDL_GameControllerHasButton(gameController.Validate(), button);

        /// <summary>
        ///     Sdl the game controller get num touchpads using the specified game controller
        /// </summary>
        /// <param name="gameController">The game controller</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GameControllerGetNumTouchpads", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern int INTERNAL_SDL_GameControllerGetNumTouchpads([NotNull] IntPtr gameController);

        /// <summary>
        ///     Games the controller get num touchpads using the specified game controller
        /// </summary>
        /// <param name="gameController">The game controller</param>
        /// <returns>The int</returns>
        [return: NotNull]
        public static int GameControllerGetNumTouchpads([NotNull] IntPtr gameController) => INTERNAL_SDL_GameControllerGetNumTouchpads(gameController.Validate());

        /// <summary>
        ///     Sdl the game controller get num touchpad fingers using the specified game controller
        /// </summary>
        /// <param name="gameController">The game controller</param>
        /// <param name="touchpad">The touchpad</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GameControllerGetNumTouchpadFingers", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern int INTERNAL_SDL_GameControllerGetNumTouchpadFingers([NotNull] IntPtr gameController, [NotNull] int touchpad);

        /// <summary>
        ///     Games the controller get num touchpad fingers using the specified game controller
        /// </summary>
        /// <param name="gameController">The game controller</param>
        /// <param name="touchpad">The touchpad</param>
        /// <returns>The int</returns>
        [return: NotNull]
        public static int GameControllerGetNumTouchpadFingers([NotNull] IntPtr gameController, [NotNull] int touchpad) => INTERNAL_SDL_GameControllerGetNumTouchpadFingers(gameController.Validate(), touchpad);

        /// <summary>
        ///     Sdl the game controller get touchpad finger using the specified game controller
        /// </summary>
        /// <param name="gameController">The game controller</param>
        /// <param name="touchpad">The touchpad</param>
        /// <param name="finger">The finger</param>
        /// <param name="state">The state</param>
        /// <param name="x">The </param>
        /// <param name="y">The </param>
        /// <param name="pressure">The pressure</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GameControllerGetTouchpadFinger", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern int INTERNAL_SDL_GameControllerGetTouchpadFinger([NotNull] IntPtr gameController, [NotNull] int touchpad, [NotNull] int finger, out byte state, out float x, out float y, out float pressure);

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
        public static int GameControllerGetTouchpadFinger([NotNull] IntPtr gameController, [NotNull] int touchpad, [NotNull] int finger, out byte state, out float x, out float y, out float pressure) => INTERNAL_SDL_GameControllerGetTouchpadFinger(gameController.Validate(), touchpad, finger, out state, out x, out y, out pressure);

        /// <summary>
        ///     Sdl the game controller has sensor using the specified game controller
        /// </summary>
        /// <param name="gameController">The game controller</param>
        /// <param name="type">The type</param>
        /// <returns>The sdl bool</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GameControllerHasSensor", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern SdlBool INTERNAL_SDL_GameControllerHasSensor([NotNull] IntPtr gameController, SdlSensorType type);

        /// <summary>
        ///     Games the controller has sensor using the specified game controller
        /// </summary>
        /// <param name="gameController">The game controller</param>
        /// <param name="type">The type</param>
        /// <returns>The sdl bool</returns>
        [return: NotNull]
        public static SdlBool GameControllerHasSensor([NotNull] IntPtr gameController, SdlSensorType type) => INTERNAL_SDL_GameControllerHasSensor(gameController.Validate(), type);

        /// <summary>
        ///     Sdl the game controller set sensor enabled using the specified game controller
        /// </summary>
        /// <param name="gameController">The game controller</param>
        /// <param name="type">The type</param>
        /// <param name="enabled">The enabled</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GameControllerSetSensorEnabled", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern int INTERNAL_SDL_GameControllerSetSensorEnabled([NotNull] IntPtr gameController, SdlSensorType type, SdlBool enabled);

        /// <summary>
        ///     Games the controller set sensor enabled using the specified game controller
        /// </summary>
        /// <param name="gameController">The game controller</param>
        /// <param name="type">The type</param>
        /// <param name="enabled">The enabled</param>
        /// <returns>The int</returns>
        [return: NotNull]
        public static int GameControllerSetSensorEnabled([NotNull] IntPtr gameController, SdlSensorType type, SdlBool enabled) => INTERNAL_SDL_GameControllerSetSensorEnabled(gameController.Validate(), type, enabled);

        /// <summary>
        ///     Sdl the game controller is sensor enabled using the specified game controller
        /// </summary>
        /// <param name="gameController">The game controller</param>
        /// <param name="type">The type</param>
        /// <returns>The sdl bool</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GameControllerIsSensorEnabled", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern SdlBool INTERNAL_SDL_GameControllerIsSensorEnabled([NotNull] IntPtr gameController, SdlSensorType type);

        /// <summary>
        ///     Games the controller is sensor enabled using the specified game controller
        /// </summary>
        /// <param name="gameController">The game controller</param>
        /// <param name="type">The type</param>
        /// <returns>The sdl bool</returns>
        [return: NotNull]
        public static SdlBool GameControllerIsSensorEnabled([NotNull] IntPtr gameController, SdlSensorType type) => INTERNAL_SDL_GameControllerIsSensorEnabled(gameController.Validate(), type);

        /// <summary>
        ///     Sdl the game controller get sensor data using the specified game controller
        /// </summary>
        /// <param name="gameController">The game controller</param>
        /// <param name="type">The type</param>
        /// <param name="data">The data</param>
        /// <param name="numValues">The num values</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GameControllerGetSensorData", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern int INTERNAL_SDL_GameControllerGetSensorData([NotNull] IntPtr gameController, SdlSensorType type, [NotNull] IntPtr data, [NotNull] int numValues);


        /// <summary>
        ///     Games the controller get sensor data using the specified game controller
        /// </summary>
        /// <param name="gameController">The game controller</param>
        /// <param name="type">The type</param>
        /// <param name="data">The data</param>
        /// <param name="numValues">The num values</param>
        /// <returns>The int</returns>
        [return: NotNull]
        public static int GameControllerGetSensorData([NotNull] IntPtr gameController, SdlSensorType type, [NotNull] IntPtr data, [NotNull] int numValues) => INTERNAL_SDL_GameControllerGetSensorData(gameController.Validate(), type, data, numValues);

        /// <summary>
        ///     Sdl the game controller get sensor data rate using the specified game controller
        /// </summary>
        /// <param name="gameController">The game controller</param>
        /// <param name="type">The type</param>
        /// <returns>The float</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GameControllerGetSensorDataRate", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern float INTERNAL_SDL_GameControllerGetSensorDataRate([NotNull] IntPtr gameController, SdlSensorType type);

        /// <summary>
        ///     Games the controller get sensor data rate using the specified game controller
        /// </summary>
        /// <param name="gameController">The game controller</param>
        /// <param name="type">The type</param>
        /// <returns>The float</returns>
        [return: NotNull]
        public static float GameControllerGetSensorDataRate([NotNull] IntPtr gameController, SdlSensorType type) => INTERNAL_SDL_GameControllerGetSensorDataRate(gameController.Validate(), type);


        /// <summary>
        ///     Sdl the game controller send effect using the specified game controller
        /// </summary>
        /// <param name="gameController">The game controller</param>
        /// <param name="data">The data</param>
        /// <param name="size">The size</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GameControllerSendEffect", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern int INTERNAL_SDL_GameControllerSendEffect([NotNull] IntPtr gameController, [NotNull] IntPtr data, [NotNull] int size);

        /// <summary>
        ///     Games the controller send effect using the specified game controller
        /// </summary>
        /// <param name="gameController">The game controller</param>
        /// <param name="data">The data</param>
        /// <param name="size">The size</param>
        /// <returns>The int</returns>
        [return: NotNull]
        public static int GameControllerSendEffect([NotNull] IntPtr gameController, [NotNull] IntPtr data, [NotNull] int size) => INTERNAL_SDL_GameControllerSendEffect(gameController.Validate(), data, size);

        /// <summary>
        ///     Sdl the haptic close using the specified haptic
        /// </summary>
        /// <param name="haptic">The haptic</param>
        [DllImport(NativeLibName, EntryPoint = "SDL_HapticClose", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern void INTERNAL_SDL_HapticClose([NotNull] IntPtr haptic);

        /// <summary>
        ///     Haptics the close using the specified haptic
        /// </summary>
        /// <param name="haptic">The haptic</param>
        [return: NotNull]
        public static void HapticClose([NotNull] IntPtr haptic) => INTERNAL_SDL_HapticClose(haptic.Validate());


        /// <summary>
        ///     Sdl the haptic destroy effect using the specified haptic
        /// </summary>
        /// <param name="haptic">The haptic</param>
        /// <param name="effect">The effect</param>
        [DllImport(NativeLibName, EntryPoint = "SDL_HapticDestroyEffect", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern void INTERNAL_SDL_HapticDestroyEffect([NotNull] IntPtr haptic, [NotNull] int effect);

        /// <summary>
        ///     Haptics the destroy effect using the specified haptic
        /// </summary>
        /// <param name="haptic">The haptic</param>
        /// <param name="effect">The effect</param>
        [return: NotNull]
        public static void HapticDestroyEffect([NotNull] IntPtr haptic, [NotNull] int effect) => INTERNAL_SDL_HapticDestroyEffect(haptic.Validate(), effect);


        /// <summary>
        ///     Sdl the haptic effect supported using the specified haptic
        /// </summary>
        /// <param name="haptic">The haptic</param>
        /// <param name="effect">The effect</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_HapticEffectSupported", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern int INTERNAL_SDL_HapticEffectSupported([NotNull] IntPtr haptic, ref SdlHapticEffect effect);

        /// <summary>
        ///     Haptics the effect supported using the specified haptic
        /// </summary>
        /// <param name="haptic">The haptic</param>
        /// <param name="effect">The effect</param>
        /// <returns>The int</returns>
        [return: NotNull]
        public static int HapticEffectSupported([NotNull] IntPtr haptic, ref SdlHapticEffect effect) => INTERNAL_SDL_HapticEffectSupported(haptic.Validate(), ref effect);


        /// <summary>
        ///     Sdl the haptic get effect status using the specified haptic
        /// </summary>
        /// <param name="haptic">The haptic</param>
        /// <param name="effect">The effect</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_HapticGetEffectStatus", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern int INTERNAL_SDL_HapticGetEffectStatus([NotNull] IntPtr haptic, [NotNull] int effect);

        /// <summary>
        ///     Haptics the get effect status using the specified haptic
        /// </summary>
        /// <param name="haptic">The haptic</param>
        /// <param name="effect">The effect</param>
        /// <returns>The int</returns>
        [return: NotNull]
        public static int HapticGetEffectStatus([NotNull] IntPtr haptic, [NotNull] int effect) => INTERNAL_SDL_HapticGetEffectStatus(haptic.Validate(), effect);

        /// <summary>
        ///     Sdl the haptic index using the specified haptic
        /// </summary>
        /// <param name="haptic">The haptic</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_HapticIndex", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern int INTERNAL_SDL_HapticIndex([NotNull] IntPtr haptic);

        /// <summary>
        ///     Haptics the index using the specified haptic
        /// </summary>
        /// <param name="haptic">The haptic</param>
        /// <returns>The int</returns>
        [return: NotNull]
        public static int HapticIndex([NotNull] IntPtr haptic) => INTERNAL_SDL_HapticIndex(haptic.Validate());

        /// <summary>
        ///     Internals the sdl haptic name using the specified device index
        /// </summary>
        /// <param name="deviceIndex">The device index</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_HapticName", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern IntPtr INTERNAL_SDL_HapticName([NotNull] int deviceIndex);

        /// <summary>
        ///     Sdl the haptic name using the specified device index
        /// </summary>
        /// <param name="deviceIndex">The device index</param>
        /// <returns>The string</returns>
        [return: NotNull]
        public static string HapticName([NotNull] int deviceIndex) => Utf8Manager.Utf8ToManaged(INTERNAL_SDL_HapticName(deviceIndex.Validate()));

        /// <summary>
        ///     Sdl the haptic new effect using the specified haptic
        /// </summary>
        /// <param name="haptic">The haptic</param>
        /// <param name="effect">The effect</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_HapticNewEffect", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern int INTERNAL_SDL_HapticNewEffect([NotNull] IntPtr haptic, ref SdlHapticEffect effect);

        /// <summary>
        ///     Haptics the new effect using the specified haptic
        /// </summary>
        /// <param name="haptic">The haptic</param>
        /// <param name="effect">The effect</param>
        /// <returns>The int</returns>
        [return: NotNull]
        public static int HapticNewEffect([NotNull] IntPtr haptic, ref SdlHapticEffect effect) => INTERNAL_SDL_HapticNewEffect(haptic, ref effect).Validate();

        /// <summary>
        ///     Sdl the haptic num axes using the specified haptic
        /// </summary>
        /// <param name="haptic">The haptic</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_HapticNumAxes", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern int INTERNAL_SDL_HapticNumAxes([NotNull] IntPtr haptic);

        /// <summary>
        ///     Haptics the num axes using the specified haptic
        /// </summary>
        /// <param name="haptic">The haptic</param>
        /// <returns>The int</returns>
        [return: NotNull]
        public static int HapticNumAxes([NotNull] IntPtr haptic) => INTERNAL_SDL_HapticNumAxes(haptic).Validate();

        /// <summary>
        ///     Sdl the haptic num effects using the specified haptic
        /// </summary>
        /// <param name="haptic">The haptic</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_HapticNumEffects", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern int INTERNAL_SDL_HapticNumEffects([NotNull] IntPtr haptic);

        /// <summary>
        ///     Haptics the num effects using the specified haptic
        /// </summary>
        /// <param name="haptic">The haptic</param>
        /// <returns>The int</returns>
        [return: NotNull]
        public static int HapticNumEffects([NotNull] IntPtr haptic) => INTERNAL_SDL_HapticNumEffects(haptic).Validate();

        /// <summary>
        ///     Sdl the haptic num effects playing using the specified haptic
        /// </summary>
        /// <param name="haptic">The haptic</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_HapticNumEffectsPlaying", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern int INTERNAL_SDL_HapticNumEffectsPlaying([NotNull] IntPtr haptic);

        /// <summary>
        ///     Haptics the num effects playing using the specified haptic
        /// </summary>
        /// <param name="haptic">The haptic</param>
        /// <returns>The int</returns>
        [return: NotNull]
        public static int HapticNumEffectsPlaying([NotNull] IntPtr haptic) => INTERNAL_SDL_HapticNumEffectsPlaying(haptic).Validate();

        /// <summary>
        ///     Sdl the haptic open using the specified device index
        /// </summary>
        /// <param name="deviceIndex">The device index</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_HapticOpen", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern IntPtr INTERNAL_SDL_HapticOpen([NotNull] int deviceIndex);

        /// <summary>
        ///     Haptics the open using the specified device index
        /// </summary>
        /// <param name="deviceIndex">The device index</param>
        /// <returns>The int ptr</returns>
        [return: NotNull]
        public static IntPtr HapticOpen([NotNull] int deviceIndex) => INTERNAL_SDL_HapticOpen(deviceIndex).Validate();

        /// <summary>
        ///     Sdl the haptic opened using the specified device index
        /// </summary>
        /// <param name="deviceIndex">The device index</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_HapticOpened", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern int INTERNAL_SDL_HapticOpened([NotNull] int deviceIndex);

        /// <summary>
        ///     Haptics the opened using the specified device index
        /// </summary>
        /// <param name="deviceIndex">The device index</param>
        /// <returns>The int</returns>
        [return: NotNull]
        public static int HapticOpened([NotNull] int deviceIndex) => INTERNAL_SDL_HapticOpened(deviceIndex).Validate();

        /// <summary>
        ///     Sdl the haptic open from joystick using the specified joystick
        /// </summary>
        /// <param name="joystick">The joystick</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_HapticOpenFromJoystick", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern IntPtr INTERNAL_SDL_HapticOpenFromJoystick([NotNull] IntPtr joystick);

        /// <summary>
        ///     Haptics the open from joystick using the specified joystick
        /// </summary>
        /// <param name="joystick">The joystick</param>
        /// <returns>The int ptr</returns>
        [return: NotNull]
        public static IntPtr HapticOpenFromJoystick([NotNull] IntPtr joystick) => INTERNAL_SDL_HapticOpenFromJoystick(joystick).Validate();

        /// <summary>
        ///     Sdl the haptic open from mouse
        /// </summary>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_HapticOpenFromMouse", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern IntPtr INTERNAL_SDL_HapticOpenFromMouse();

        /// <summary>
        ///     Haptics the open from mouse
        /// </summary>
        /// <returns>The int ptr</returns>
        [return: NotNull]
        public static IntPtr HapticOpenFromMouse() => INTERNAL_SDL_HapticOpenFromMouse().Validate();

        /// <summary>
        ///     Sdl the haptic pause using the specified haptic
        /// </summary>
        /// <param name="haptic">The haptic</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_HapticPause", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern int INTERNAL_SDL_HapticPause([NotNull] IntPtr haptic);

        /// <summary>
        ///     Haptics the pause using the specified haptic
        /// </summary>
        /// <param name="haptic">The haptic</param>
        /// <returns>The int</returns>
        [return: NotNull]
        public static int HapticPause([NotNull] IntPtr haptic) => INTERNAL_SDL_HapticPause(haptic.Validate()).Validate();

        /// <summary>
        ///     Sdl the haptic query using the specified haptic
        /// </summary>
        /// <param name="haptic">The haptic</param>
        /// <returns>The uint</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_HapticQuery", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern uint INTERNAL_SDL_HapticQuery([NotNull] IntPtr haptic);

        /// <summary>
        ///     Haptics the query using the specified haptic
        /// </summary>
        /// <param name="haptic">The haptic</param>
        /// <returns>The uint</returns>
        [return: NotNull]
        public static uint HapticQuery([NotNull] IntPtr haptic) => INTERNAL_SDL_HapticQuery(haptic.Validate()).Validate();

        /// <summary>
        ///     Sdl the haptic rumble init using the specified haptic
        /// </summary>
        /// <param name="haptic">The haptic</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_HapticRumbleInit", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern int INTERNAL_SDL_HapticRumbleInit([NotNull] IntPtr haptic);

        /// <summary>
        ///     Haptics the rumble init using the specified haptic
        /// </summary>
        /// <param name="haptic">The haptic</param>
        /// <returns>The int</returns>
        [return: NotNull]
        public static int HapticRumbleInit([NotNull] IntPtr haptic) => INTERNAL_SDL_HapticRumbleInit(haptic.Validate()).Validate();

        /// <summary>
        ///     Sdl the haptic rumble play using the specified haptic
        /// </summary>
        /// <param name="haptic">The haptic</param>
        /// <param name="strength">The strength</param>
        /// <param name="length">The length</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_HapticRumblePlay", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern int INTERNAL_SDL_HapticRumblePlay([NotNull] IntPtr haptic, float strength, [NotNull] uint length);

        /// <summary>
        ///     Haptics the rumble play using the specified haptic
        /// </summary>
        /// <param name="haptic">The haptic</param>
        /// <param name="strength">The strength</param>
        /// <param name="length">The length</param>
        /// <returns>The int</returns>
        [return: NotNull]
        public static int HapticRumblePlay([NotNull] IntPtr haptic, float strength, [NotNull] uint length) => INTERNAL_SDL_HapticRumblePlay(haptic.Validate(), strength, length.Validate()).Validate();

        /// <summary>
        ///     Sdl the haptic rumble stop using the specified haptic
        /// </summary>
        /// <param name="haptic">The haptic</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_HapticRumbleStop", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern int INTERNAL_SDL_HapticRumbleStop([NotNull] IntPtr haptic);

        /// <summary>
        ///     Haptics the rumble stop using the specified haptic
        /// </summary>
        /// <param name="haptic">The haptic</param>
        /// <returns>The int</returns>
        [return: NotNull]
        public static int HapticRumbleStop([NotNull] IntPtr haptic) => INTERNAL_SDL_HapticRumbleStop(haptic.Validate()).Validate();

        /// <summary>
        ///     Sdl the haptic rumble supported using the specified haptic
        /// </summary>
        /// <param name="haptic">The haptic</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_HapticRumbleSupported", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern int INTERNAL_SDL_HapticRumbleSupported([NotNull] IntPtr haptic);

        /// <summary>
        ///     Haptics the rumble supported using the specified haptic
        /// </summary>
        /// <param name="haptic">The haptic</param>
        /// <returns>The int</returns>
        [return: NotNull]
        public static int HapticRumbleSupported([NotNull] IntPtr haptic) => INTERNAL_SDL_HapticRumbleSupported(haptic.Validate()).Validate();

        /// <summary>
        ///     Sdl the haptic run effect using the specified haptic
        /// </summary>
        /// <param name="haptic">The haptic</param>
        /// <param name="effect">The effect</param>
        /// <param name="iterations">The iterations</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_HapticRunEffect", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern int INTERNAL_SDL_HapticRunEffect([NotNull] IntPtr haptic, [NotNull] int effect, [NotNull] uint iterations);

        /// <summary>
        ///     Haptics the run effect using the specified haptic
        /// </summary>
        /// <param name="haptic">The haptic</param>
        /// <param name="effect">The effect</param>
        /// <param name="iterations">The iterations</param>
        /// <returns>The int</returns>
        [return: NotNull]
        public static int HapticRunEffect([NotNull] IntPtr haptic, [NotNull] int effect, [NotNull] uint iterations) => INTERNAL_SDL_HapticRunEffect(haptic.Validate(), effect, iterations).Validate();

        /// <summary>
        ///     Sdl the haptic set auto center using the specified haptic
        /// </summary>
        /// <param name="haptic">The haptic</param>
        /// <param name="autoCenter">The auto center</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_HapticSetAutoCenter", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern int INTERNAL_SDL_HapticSetAutoCenter([NotNull] IntPtr haptic, [NotNull] int autoCenter);

        /// <summary>
        ///     Haptics the set auto center using the specified haptic
        /// </summary>
        /// <param name="haptic">The haptic</param>
        /// <param name="autoCenter">The auto center</param>
        /// <returns>The int</returns>
        [return: NotNull]
        public static int HapticSetAutoCenter([NotNull] IntPtr haptic, [NotNull] int autoCenter) => INTERNAL_SDL_HapticSetAutoCenter(haptic.Validate(), autoCenter).Validate();

        /// <summary>
        ///     Sdl the haptic set gain using the specified haptic
        /// </summary>
        /// <param name="haptic">The haptic</param>
        /// <param name="gain">The gain</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_HapticSetGain", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern int INTERNAL_SDL_HapticSetGain([NotNull] IntPtr haptic, [NotNull] int gain);

        /// <summary>
        ///     Haptics the set gain using the specified haptic
        /// </summary>
        /// <param name="haptic">The haptic</param>
        /// <param name="gain">The gain</param>
        /// <returns>The int</returns>
        [return: NotNull]
        public static int HapticSetGain([NotNull] IntPtr haptic, [NotNull] int gain) => INTERNAL_SDL_HapticSetGain(haptic.Validate(), gain).Validate();

        /// <summary>
        ///     Sdl the haptic stop all using the specified haptic
        /// </summary>
        /// <param name="haptic">The haptic</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_HapticStopAll", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern int INTERNAL_SDL_HapticStopAll([NotNull] IntPtr haptic);

        /// <summary>
        ///     Haptics the stop all using the specified haptic
        /// </summary>
        /// <param name="haptic">The haptic</param>
        /// <returns>The int</returns>
        [return: NotNull]
        public static int HapticStopAll([NotNull] IntPtr haptic) => INTERNAL_SDL_HapticStopAll(haptic.Validate()).Validate();

        /// <summary>
        ///     Sdl the haptic stop effect using the specified haptic
        /// </summary>
        /// <param name="haptic">The haptic</param>
        /// <param name="effect">The effect</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_HapticStopEffect", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern int INTERNAL_SDL_HapticStopEffect([NotNull] IntPtr haptic, [NotNull] int effect);

        /// <summary>
        ///     Haptics the stop effect using the specified haptic
        /// </summary>
        /// <param name="haptic">The haptic</param>
        /// <param name="effect">The effect</param>
        /// <returns>The int</returns>
        [return: NotNull]
        public static int HapticStopEffect([NotNull] IntPtr haptic, [NotNull] int effect) => INTERNAL_SDL_HapticStopEffect(haptic.Validate(), effect).Validate();

        /// <summary>
        ///     Sdl the haptic unpause using the specified haptic
        /// </summary>
        /// <param name="haptic">The haptic</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_HapticUnpause", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern int INTERNAL_SDL_HapticUnpause([NotNull] IntPtr haptic);

        /// <summary>
        ///     Haptics the unpause using the specified haptic
        /// </summary>
        /// <param name="haptic">The haptic</param>
        /// <returns>The int</returns>
        [return: NotNull]
        public static int HapticUnpause([NotNull] IntPtr haptic) => INTERNAL_SDL_HapticUnpause(haptic.Validate()).Validate();

        /// <summary>
        ///     Sdl the haptic update effect using the specified haptic
        /// </summary>
        /// <param name="haptic">The haptic</param>
        /// <param name="effect">The effect</param>
        /// <param name="data">The data</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_HapticUpdateEffect", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern int INTERNAL_SDL_HapticUpdateEffect([NotNull] IntPtr haptic, [NotNull] int effect, ref SdlHapticEffect data);

        /// <summary>
        ///     Haptics the update effect using the specified haptic
        /// </summary>
        /// <param name="haptic">The haptic</param>
        /// <param name="effect">The effect</param>
        /// <param name="data">The data</param>
        /// <returns>The int</returns>
        [return: NotNull]
        public static int HapticUpdateEffect([NotNull] IntPtr haptic, [NotNull] int effect, ref SdlHapticEffect data) => INTERNAL_SDL_HapticUpdateEffect(haptic.Validate(), effect, ref data).Validate();

        /// <summary>
        ///     Sdl the joystick is haptic using the specified joystick
        /// </summary>
        /// <param name="joystick">The joystick</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_JoystickIsHaptic", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern int INTERNAL_SDL_JoystickIsHaptic([NotNull] IntPtr joystick);

        /// <summary>
        ///     Joysticks the is haptic using the specified joystick
        /// </summary>
        /// <param name="joystick">The joystick</param>
        /// <returns>The int</returns>
        [return: NotNull]
        public static int JoystickIsHaptic([NotNull] IntPtr joystick) => INTERNAL_SDL_JoystickIsHaptic(joystick.Validate()).Validate();

        /// <summary>
        ///     Sdl the mouse is haptic
        /// </summary>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_MouseIsHaptic", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern int INTERNAL_SDL_MouseIsHaptic();

        /// <summary>
        ///     Mouses the is haptic
        /// </summary>
        /// <returns>The int</returns>
        [return: NotNull]
        public static int MouseIsHaptic() => INTERNAL_SDL_MouseIsHaptic().Validate();

        /// <summary>
        ///     Sdl the num haptics
        /// </summary>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_NumHaptics", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern int INTERNAL_SDL_NumHaptics();

        /// <summary>
        ///     Nums the haptics
        /// </summary>
        /// <returns>The int</returns>
        [return: NotNull]
        public static int NumHaptics() => INTERNAL_SDL_NumHaptics().Validate();

        /// <summary>
        ///     Sdl the num sensors
        /// </summary>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_NumSensors", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern int INTERNAL_SDL_NumSensors();

        /// <summary>
        ///     Nums the sensors
        /// </summary>
        /// <returns>The int</returns>
        [return: NotNull]
        public static int NumSensors() => INTERNAL_SDL_NumSensors().Validate();

        /// <summary>
        ///     Internals the sdl sensor get device name using the specified device index
        /// </summary>
        /// <param name="deviceIndex">The device index</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_SensorGetDeviceName", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern IntPtr INTERNAL_SDL_SensorGetDeviceName([NotNull] int deviceIndex);

        /// <summary>
        ///     Sdl the sensor get device name using the specified device index
        /// </summary>
        /// <param name="deviceIndex">The device index</param>
        /// <returns>The string</returns>
        [return: NotNull]
        public static string SensorGetDeviceName([NotNull] int deviceIndex) => Utf8Manager.Utf8ToManaged(INTERNAL_SDL_SensorGetDeviceName(deviceIndex.Validate()));

        /// <summary>
        ///     Sdl the sensor get device type using the specified device index
        /// </summary>
        /// <param name="deviceIndex">The device index</param>
        /// <returns>The sdl sensor type</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_SensorGetDeviceType", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern SdlSensorType INTERNAL_SDL_SensorGetDeviceType([NotNull] int deviceIndex);

        /// <summary>
        ///     Sensors the get device type using the specified device index
        /// </summary>
        /// <param name="deviceIndex">The device index</param>
        /// <returns>The sdl sensor type</returns>
        [return: NotNull]
        public static SdlSensorType SensorGetDeviceType([NotNull] int deviceIndex) => INTERNAL_SDL_SensorGetDeviceType(deviceIndex.Validate());

        /// <summary>
        ///     Sdl the sensor get device non portable type using the specified device index
        /// </summary>
        /// <param name="deviceIndex">The device index</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_SensorGetDeviceNonPortableType", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern int INTERNAL_SDL_SensorGetDeviceNonPortableType([NotNull] int deviceIndex);

        /// <summary>
        ///     Sensors the get device non portable type using the specified device index
        /// </summary>
        /// <param name="deviceIndex">The device index</param>
        /// <returns>The int</returns>
        [return: NotNull]
        public static int SensorGetDeviceNonPortableType([NotNull] int deviceIndex) => INTERNAL_SDL_SensorGetDeviceNonPortableType(deviceIndex.Validate());

        /// <summary>
        ///     Sdl the sensor get device instance id using the specified device index
        /// </summary>
        /// <param name="deviceIndex">The device index</param>
        /// <returns>The int 32</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_SensorGetDeviceInstanceID", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern int INTERNAL_SDL_SensorGetDeviceInstanceID([NotNull] int deviceIndex);

        /// <summary>
        ///     Sensors the get device instance id using the specified device index
        /// </summary>
        /// <param name="deviceIndex">The device index</param>
        /// <returns>The int</returns>
        [return: NotNull]
        public static int SensorGetDeviceInstanceId([NotNull] int deviceIndex) => INTERNAL_SDL_SensorGetDeviceInstanceID(deviceIndex.Validate());

        /// <summary>
        ///     Sdl the sensor open using the specified device index
        /// </summary>
        /// <param name="deviceIndex">The device index</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_SensorOpen", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern IntPtr INTERNAL_SDL_SensorOpen([NotNull] int deviceIndex);

        /// <summary>
        ///     Sensors the open using the specified device index
        /// </summary>
        /// <param name="deviceIndex">The device index</param>
        /// <returns>The int ptr</returns>
        [return: NotNull]
        public static IntPtr SensorOpen([NotNull] int deviceIndex) => INTERNAL_SDL_SensorOpen(deviceIndex.Validate());

        /// <summary>
        ///     Sdl the sensor from instance id using the specified instance id
        /// </summary>
        /// <param name="instanceId">The instance id</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_SensorFromInstanceID", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern IntPtr INTERNAL_SDL_SensorFromInstanceID([NotNull] int instanceId);

        /// <summary>
        ///     Sensors the from instance id using the specified instance id
        /// </summary>
        /// <param name="instanceId">The instance id</param>
        /// <returns>The int ptr</returns>
        [return: NotNull]
        public static IntPtr SensorFromInstanceId([NotNull] int instanceId) => INTERNAL_SDL_SensorFromInstanceID(instanceId.Validate());

        /// <summary>
        ///     Internals the sdl sensor get name using the specified sensor
        /// </summary>
        /// <param name="sensor">The sensor</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_SensorGetName", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern IntPtr INTERNAL_SDL_SensorGetName([NotNull] IntPtr sensor);

        /// <summary>
        ///     Sdl the sensor get name using the specified sensor
        /// </summary>
        /// <param name="sensor">The sensor</param>
        /// <returns>The string</returns>
        [return: NotNull]
        public static string SensorGetName([NotNull] IntPtr sensor) => Utf8Manager.Utf8ToManaged(INTERNAL_SDL_SensorGetName(sensor.Validate()));

        /// <summary>
        ///     Sdl the sensor get type using the specified sensor
        /// </summary>
        /// <param name="sensor">The sensor</param>
        /// <returns>The sdl sensor type</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_SensorGetType", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern SdlSensorType INTERNAL_SDL_SensorGetType([NotNull] IntPtr sensor);

        /// <summary>
        ///     Sensors the get type using the specified sensor
        /// </summary>
        /// <param name="sensor">The sensor</param>
        /// <returns>The sdl sensor type</returns>
        [return: NotNull]
        public static SdlSensorType SensorGetType([NotNull] IntPtr sensor) => INTERNAL_SDL_SensorGetType(sensor.Validate());

        /// <summary>
        ///     Sdl the sensor get non portable type using the specified sensor
        /// </summary>
        /// <param name="sensor">The sensor</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_SensorGetNonPortableType", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern int INTERNAL_SDL_SensorGetNonPortableType([NotNull] IntPtr sensor);

        /// <summary>
        ///     Sensors the get non portable type using the specified sensor
        /// </summary>
        /// <param name="sensor">The sensor</param>
        /// <returns>The int</returns>
        [return: NotNull]
        public static int SensorGetNonPortableType([NotNull] IntPtr sensor) => INTERNAL_SDL_SensorGetNonPortableType(sensor.Validate());

        /// <summary>
        ///     Sdl the sensor get instance id using the specified sensor
        /// </summary>
        /// <param name="sensor">The sensor</param>
        /// <returns>The int 32</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_SensorGetInstanceID", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern int INTERNAL_SDL_SensorGetInstanceID([NotNull] IntPtr sensor);

        /// <summary>
        ///     Sensors the get instance id using the specified sensor
        /// </summary>
        /// <param name="sensor">The sensor</param>
        /// <returns>The int</returns>
        [return: NotNull]
        public static int SensorGetInstanceId([NotNull] IntPtr sensor) => INTERNAL_SDL_SensorGetInstanceID(sensor.Validate());

        /// <summary>
        ///     Sdl the sensor get data using the specified sensor
        /// </summary>
        /// <param name="sensor">The sensor</param>
        /// <param name="data">The data</param>
        /// <param name="numValues">The num values</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_SensorGetData", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern int INTERNAL_SDL_SensorGetData([NotNull] IntPtr sensor, float[] data, [NotNull] int numValues);

        /// <summary>
        ///     Sensors the get data using the specified sensor
        /// </summary>
        /// <param name="sensor">The sensor</param>
        /// <param name="data">The data</param>
        /// <param name="numValues">The num values</param>
        /// <returns>The int</returns>
        [return: NotNull]
        public static int SensorGetData([NotNull] IntPtr sensor, float[] data, [NotNull] int numValues) => INTERNAL_SDL_SensorGetData(sensor.Validate(), data, numValues);

        /// <summary>
        ///     Sdl the sensor close using the specified sensor
        /// </summary>
        /// <param name="sensor">The sensor</param>
        [DllImport(NativeLibName, EntryPoint = "SDL_SensorClose", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern void INTERNAL_SDL_SensorClose([NotNull] IntPtr sensor);

        /// <summary>
        ///     Sensors the close using the specified sensor
        /// </summary>
        /// <param name="sensor">The sensor</param>
        [return: NotNull]
        public static void SensorClose([NotNull] IntPtr sensor) => INTERNAL_SDL_SensorClose(sensor.Validate());

        /// <summary>
        ///     Sdl the sensor update
        /// </summary>
        [DllImport(NativeLibName, EntryPoint = "SDL_SensorUpdate", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern void INTERNAL_SDL_SensorUpdate();

        /// <summary>
        ///     Sensors the update
        /// </summary>
        [return: NotNull]
        public static void SensorUpdate() => INTERNAL_SDL_SensorUpdate();

        /// <summary>
        ///     Sdl the lock sensors
        /// </summary>
        [DllImport(NativeLibName, EntryPoint = "SDL_LockSensors", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern void INTERNAL_SDL_LockSensors();

        /// <summary>
        ///     Locks the sensors
        /// </summary>
        [return: NotNull]
        public static void LockSensors() => INTERNAL_SDL_LockSensors();

        /// <summary>
        ///     Sdl the unlock sensors
        /// </summary>
        [DllImport(NativeLibName, EntryPoint = "SDL_UnlockSensors", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern void INTERNAL_SDL_UnlockSensors();

        /// <summary>
        ///     Unlocks the sensors
        /// </summary>
        [return: NotNull]
        public static void UnlockSensors() => INTERNAL_SDL_UnlockSensors();

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
        ///     Internals the sdl audio init using the specified driver name
        /// </summary>
        /// <param name="driverName">The driver name</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_AudioInit", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern int INTERNAL_SDL_AudioInit([NotNull] byte[] driverName);

        /// <summary>
        ///     Sdl the audio init using the specified driver name
        /// </summary>
        /// <param name="driverName">The driver name</param>
        /// <returns>The int</returns>
        public static int AudioInit([NotNull] string driverName) => INTERNAL_SDL_AudioInit(Utf8Manager.Utf8Encode(driverName, new byte[Utf8Manager.Utf8Size(driverName)], Utf8Manager.Utf8Size(driverName)));

        /// <summary>
        ///     Sdl the audio quit
        /// </summary>
        [DllImport(NativeLibName, EntryPoint = "SDL_AudioQuit", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern void INTERNAL_SDL_AudioQuit();

        /// <summary>
        ///     Audio the quit
        /// </summary>
        [return: NotNull]
        public static void AudioQuit() => INTERNAL_SDL_AudioQuit();

        /// <summary>
        ///     Sdl the close audio
        /// </summary>
        [DllImport(NativeLibName, EntryPoint = "SDL_CloseAudio", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern void INTERNAL_SDL_CloseAudio();

        /// <summary>
        ///     Closes the audio
        /// </summary>
        [return: NotNull]
        public static void CloseAudio() => INTERNAL_SDL_CloseAudio();

        /// <summary>
        ///     Sdl the close audio device using the specified dev
        /// </summary>
        /// <param name="dev">The dev</param>
        [DllImport(NativeLibName, EntryPoint = "SDL_CloseAudioDevice", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern void INTERNAL_SDL_CloseAudioDevice([NotNull] uint dev);

        /// <summary>
        ///     Closes the audio device using the specified dev
        /// </summary>
        /// <param name="dev">The dev</param>
        [return: NotNull]
        public static void CloseAudioDevice([NotNull] uint dev) => INTERNAL_SDL_CloseAudioDevice(dev.Validate());

        /// <summary>
        ///     Sdl the free wav using the specified audio buf
        /// </summary>
        /// <param name="audioBuf">The audio buf</param>
        [DllImport(NativeLibName, EntryPoint = "SDL_FreeWAV", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern void INTERNAL_SDL_FreeWAV([NotNull] IntPtr audioBuf);

        /// <summary>
        ///     Frees the wav using the specified audio buf
        /// </summary>
        /// <param name="audioBuf">The audio buf</param>
        [return: NotNull]
        public static void FreeWav([NotNull] IntPtr audioBuf) => INTERNAL_SDL_FreeWAV(audioBuf.Validate());

        /// <summary>
        ///     Internals the sdl get audio device name using the specified index
        /// </summary>
        /// <param name="index">The index</param>
        /// <param name="isCapture">The is capture</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GetAudioDeviceName", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern IntPtr INTERNAL_SDL_GetAudioDeviceName([NotNull] int index, [NotNull] int isCapture);

        /// <summary>
        ///     Sdl the get audio device name using the specified index
        /// </summary>
        /// <param name="index">The index</param>
        /// <param name="isCapture">The is capture</param>
        /// <returns>The string</returns>
        public static string GetAudioDeviceName([NotNull] int index, [NotNull] int isCapture) => Utf8Manager.Utf8ToManaged(INTERNAL_SDL_GetAudioDeviceName(index, isCapture));

        /// <summary>
        ///     Sdl the get audio device status using the specified dev
        /// </summary>
        /// <param name="dev">The dev</param>
        /// <returns>The sdl audio status</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GetAudioDeviceStatus", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern SdlAudioStatus INTERNAL_SDL_GetAudioDeviceStatus([NotNull] uint dev);

        /// <summary>
        ///     Gets the audio device status using the specified dev
        /// </summary>
        /// <param name="dev">The dev</param>
        /// <returns>The sdl audio status</returns>
        [return: NotNull]
        public static SdlAudioStatus GetAudioDeviceStatus([NotNull] uint dev) => INTERNAL_SDL_GetAudioDeviceStatus(dev.Validate());

        /// <summary>
        ///     Internals the sdl get audio driver using the specified index
        /// </summary>
        /// <param name="index">The index</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GetAudioDriver", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern IntPtr INTERNAL_SDL_GetAudioDriver([NotNull] int index);

        /// <summary>
        ///     Sdl the get audio driver using the specified index
        /// </summary>
        /// <param name="index">The index</param>
        /// <returns>The string</returns>
        public static string GetAudioDriver([NotNull] int index) => Utf8Manager.Utf8ToManaged(INTERNAL_SDL_GetAudioDriver(index.Validate()));

        /// <summary>
        ///     Sdl the get audio status
        /// </summary>
        /// <returns>The sdl audio status</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GetAudioStatus", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern SdlAudioStatus INTERNAL_SDL_GetAudioStatus();

        /// <summary>
        ///     Gets the audio status
        /// </summary>
        /// <returns>The sdl audio status</returns>
        [return: NotNull]
        public static SdlAudioStatus GetAudioStatus() => INTERNAL_SDL_GetAudioStatus().Validate();

        /// <summary>
        ///     Internals the sdl get current audio driver
        /// </summary>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GetCurrentAudioDriver", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern IntPtr INTERNAL_SDL_GetCurrentAudioDriver();

        /// <summary>
        ///     Sdl the get current audio driver
        /// </summary>
        /// <returns>The string</returns>
        [return: NotNull]
        public static string GetCurrentAudioDriver() => Utf8Manager.Utf8ToManaged(INTERNAL_SDL_GetCurrentAudioDriver()).Validate();

        /// <summary>
        ///     Sdl the get num audio devices using the specified is capture
        /// </summary>
        /// <param name="isCapture">The is capture</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GetNumAudioDevices", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern int INTERNAL_SDL_GetNumAudioDevices([NotNull] int isCapture);

        /// <summary>
        ///     Gets the num audio devices using the specified is capture
        /// </summary>
        /// <param name="isCapture">The is capture</param>
        /// <returns>The int</returns>
        [return: NotNull]
        public static int GetNumAudioDevices([NotNull] int isCapture) => INTERNAL_SDL_GetNumAudioDevices(isCapture.Validate());

        /// <summary>
        ///     Sdl the get num audio drivers
        /// </summary>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GetNumAudioDrivers", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern int INTERNAL_SDL_GetNumAudioDrivers();

        /// <summary>
        ///     Gets the num audio drivers
        /// </summary>
        /// <returns>The int</returns>
        [return: NotNull]
        public static int GetNumAudioDrivers() => INTERNAL_SDL_GetNumAudioDrivers();

        /// <summary>
        ///     Internals the sdl load wav rw using the specified src
        /// </summary>
        /// <param name="src">The src</param>
        /// <param name="freeSrc">The free src</param>
        /// <param name="spec">The spec</param>
        /// <param name="audioBuf">The audio buf</param>
        /// <param name="audioLen">The audio len</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_LoadWAV_RW", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern IntPtr INTERNAL_SDL_LoadWAV_RW([NotNull] IntPtr src, [NotNull] int freeSrc, out SdlAudioSpec spec, out IntPtr audioBuf, out uint audioLen);

        /// <summary>
        ///     Sdl the load wav using the specified file
        /// </summary>
        /// <param name="file">The file</param>
        /// <param name="spec">The spec</param>
        /// <param name="audioBuf">The audio buf</param>
        /// <param name="audioLen">The audio len</param>
        /// <returns>The int ptr</returns>
        public static IntPtr LoadWav([NotNull] string file, out SdlAudioSpec spec, out IntPtr audioBuf, out uint audioLen) => INTERNAL_SDL_LoadWAV_RW(RwFromFile(file, "rb"), 1, out spec, out audioBuf, out audioLen);

        /// <summary>
        ///     Sdl the lock audio
        /// </summary>
        [DllImport(NativeLibName, EntryPoint = "SDL_LockAudio", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern void INTERNAL_SDL_LockAudio();

        /// <summary>
        ///     Locks the audio
        /// </summary>
        [return: NotNull]
        public static void LockAudio() => INTERNAL_SDL_LockAudio();

        /// <summary>
        ///     Sdl the lock audio device using the specified dev
        /// </summary>
        /// <param name="dev">The dev</param>
        [DllImport(NativeLibName, EntryPoint = "SDL_LockAudioDevice", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern void INTERNAL_SDL_LockAudioDevice([NotNull] uint dev);

        /// <summary>
        ///     Locks the audio device using the specified dev
        /// </summary>
        /// <param name="dev">The dev</param>
        [return: NotNull]
        public static void LockAudioDevice([NotNull] uint dev) => INTERNAL_SDL_LockAudioDevice(dev.Validate());

        /// <summary>
        ///     Sdl the mix audio using the specified dst
        /// </summary>
        /// <param name="dst">The dst</param>
        /// <param name="src">The src</param>
        /// <param name="len">The len</param>
        /// <param name="volume">The volume</param>
        [DllImport(NativeLibName, EntryPoint = "SDL_MixAudio", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern void INTERNAL_SDL_MixAudio([Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U1, SizeParamIndex = 2)] [NotNull] byte[] dst, [In, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U1, SizeParamIndex = 2)] [NotNull] byte[] src, [NotNull] uint len, [NotNull] int volume);

        /// <summary>
        ///     Mixes the audio using the specified dst
        /// </summary>
        /// <param name="dst">The dst</param>
        /// <param name="src">The src</param>
        /// <param name="len">The len</param>
        /// <param name="volume">The volume</param>
        [return: NotNull]
        public static void MixAudio([Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U1, SizeParamIndex = 2)] [NotNull] byte[] dst, [In, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U1, SizeParamIndex = 2)] [NotNull] byte[] src, [NotNull] uint len, [NotNull] int volume) => INTERNAL_SDL_MixAudio(dst.Validate(), src.Validate(), len, volume);

        /// <summary>
        ///     Sdl the mix audio format using the specified dst
        /// </summary>
        /// <param name="dst">The dst</param>
        /// <param name="src">The src</param>
        /// <param name="format">The format</param>
        /// <param name="len">The len</param>
        /// <param name="volume">The volume</param>
        [DllImport(NativeLibName, EntryPoint = "SDL_MixAudioFormat", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern void INTERNAL_SDL_MixAudioFormat([NotNull] IntPtr dst, [NotNull] IntPtr src, [NotNull] ushort format, [NotNull] uint len, [NotNull] int volume);

        /// <summary>
        ///     Mixes the audio format using the specified dst
        /// </summary>
        /// <param name="dst">The dst</param>
        /// <param name="src">The src</param>
        /// <param name="format">The format</param>
        /// <param name="len">The len</param>
        /// <param name="volume">The volume</param>
        [return: NotNull]
        public static void MixAudioFormat([NotNull] IntPtr dst, [NotNull] IntPtr src, [NotNull] ushort format, [NotNull] uint len, [NotNull] int volume) => INTERNAL_SDL_MixAudioFormat(dst.Validate(), src.Validate(), format.Validate(), len.Validate(), volume.Validate());

        /// <summary>
        ///     Sdl the mix audio format using the specified dst
        /// </summary>
        /// <param name="dst">The dst</param>
        /// <param name="src">The src</param>
        /// <param name="format">The format</param>
        /// <param name="len">The len</param>
        /// <param name="volume">The volume</param>
        [DllImport(NativeLibName, EntryPoint = "SDL_MixAudioFormat", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern void INTERNAL_SDL_MixAudioFormat([Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U1, SizeParamIndex = 3)] [NotNull] byte[] dst, [In, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U1, SizeParamIndex = 3)] [NotNull] byte[] src, [NotNull] ushort format, [NotNull] uint len, [NotNull] int volume);

        /// <summary>
        ///     Mixes the audio format using the specified dst
        /// </summary>
        /// <param name="dst">The dst</param>
        /// <param name="src">The src</param>
        /// <param name="format">The format</param>
        /// <param name="len">The len</param>
        /// <param name="volume">The volume</param>
        [return: NotNull]
        public static void MixAudioFormat([Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U1, SizeParamIndex = 3)] [NotNull] byte[] dst, [In, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U1, SizeParamIndex = 3)] [NotNull] byte[] src, [NotNull] ushort format, [NotNull] uint len, [NotNull] int volume)
            => INTERNAL_SDL_MixAudioFormat(dst.Validate(), src.Validate(), format.Validate(), len.Validate(), volume.Validate());

        /// <summary>
        ///     Sdl the open audio using the specified desired
        /// </summary>
        /// <param name="desired">The desired</param>
        /// <param name="obtained">The obtained</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_OpenAudio", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern int INTERNAL_SDL_OpenAudio(ref SdlAudioSpec desired, out SdlAudioSpec obtained);

        /// <summary>
        ///     Sdl the open audio using the specified desired
        /// </summary>
        /// <param name="desired">The desired</param>
        /// <param name="obtained">The obtained</param>
        /// <returns>The int</returns>
        [return: NotNull]
        public static int SdlOpenAudio(ref SdlAudioSpec desired, out SdlAudioSpec obtained) => INTERNAL_SDL_OpenAudio(ref desired, out obtained);

        /// <summary>
        ///     Sdl the open audio using the specified desired
        /// </summary>
        /// <param name="desired">The desired</param>
        /// <param name="obtained">The obtained</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_OpenAudio", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern int INTERNAL_SDL_OpenAudio(ref SdlAudioSpec desired, [NotNull] IntPtr obtained);

        /// <summary>
        ///     Sdl the open audio using the specified desired
        /// </summary>
        /// <param name="desired">The desired</param>
        /// <param name="obtained">The obtained</param>
        /// <returns>The int</returns>
        [return: NotNull]
        public static int SdlOpenAudio(ref SdlAudioSpec desired, [NotNull] IntPtr obtained) => INTERNAL_SDL_OpenAudio(ref desired, obtained.Validate());

        /// <summary>
        ///     Sdl the open audio device using the specified device
        /// </summary>
        /// <param name="device">The device</param>
        /// <param name="isCapture">The is capture</param>
        /// <param name="desired">The desired</param>
        /// <param name="obtained">The obtained</param>
        /// <param name="allowedChanges">The allowed changes</param>
        /// <returns>The uint</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_OpenAudioDevice", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern uint INTERNAL_SDL_OpenAudioDevice([NotNull] IntPtr device, [NotNull] int isCapture, ref SdlAudioSpec desired, out SdlAudioSpec obtained, [NotNull] int allowedChanges);

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
        public static uint SdlOpenAudioDevice([NotNull] IntPtr device, [NotNull] int isCapture, ref SdlAudioSpec desired, out SdlAudioSpec obtained, [NotNull] int allowedChanges) => INTERNAL_SDL_OpenAudioDevice(device.Validate(), isCapture.Validate(), ref desired, out obtained, allowedChanges.Validate());

        /// <summary>
        ///     Internals the sdl open audio device using the specified device
        /// </summary>
        /// <param name="device">The device</param>
        /// <param name="isCapture">The is capture</param>
        /// <param name="desired">The desired</param>
        /// <param name="obtained">The obtained</param>
        /// <param name="allowedChanges">The allowed changes</param>
        /// <returns>The uint</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_OpenAudioDevice", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern uint INTERNAL_SDL_OpenAudioDevice([NotNull] byte[] device, [NotNull] int isCapture, ref SdlAudioSpec desired, out SdlAudioSpec obtained, [NotNull] int allowedChanges);

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
        public static uint SdlOpenAudioDevice([NotNull] string device, [NotNull] int isCapture, ref SdlAudioSpec desired, out SdlAudioSpec obtained, [NotNull] int allowedChanges)
            => INTERNAL_SDL_OpenAudioDevice(Utf8Manager.Utf8Encode(device.Validate(), new byte[Utf8Manager.Utf8Size(device.Validate())], Utf8Manager.Utf8Size(device.Validate())), isCapture, ref desired, out obtained, allowedChanges);

        /// <summary>
        ///     Sdl the pause audio using the specified pause on
        /// </summary>
        /// <param name="pauseOn">The pause on</param>
        [DllImport(NativeLibName, EntryPoint = "SDL_PauseAudio", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern void INTERNAL_SDL_PauseAudio([NotNull] int pauseOn);

        /// <summary>
        ///     Sdl the pause audio using the specified pause on
        /// </summary>
        /// <param name="pauseOn">The pause on</param>
        [return: NotNull]
        public static void SdlPauseAudio([NotNull] int pauseOn) => INTERNAL_SDL_PauseAudio(pauseOn.Validate());

        /// <summary>
        ///     Sdl the pause audio device using the specified dev
        /// </summary>
        /// <param name="dev">The dev</param>
        /// <param name="pauseOn">The pause on</param>
        [DllImport(NativeLibName, EntryPoint = "SDL_PauseAudioDevice", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern void INTERNAL_SDL_PauseAudioDevice([NotNull] uint dev, [NotNull] int pauseOn);

        /// <summary>
        ///     Sdl the pause audio device using the specified dev
        /// </summary>
        /// <param name="dev">The dev</param>
        /// <param name="pauseOn">The pause on</param>
        [return: NotNull]
        public static void SdlPauseAudioDevice([NotNull] uint dev, [NotNull] int pauseOn) => INTERNAL_SDL_PauseAudioDevice(dev.Validate(), pauseOn.Validate());

        /// <summary>
        ///     Sdl the unlock audio
        /// </summary>
        [DllImport(NativeLibName, EntryPoint = "SDL_UnlockAudio", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern void INTERNAL_SDL_UnlockAudio();

        /// <summary>
        ///     Sdl the unlock audio
        /// </summary>
        [return: NotNull]
        public static void SdlUnlockAudio() => INTERNAL_SDL_UnlockAudio();

        /// <summary>
        ///     Sdl the unlock audio device using the specified dev
        /// </summary>
        /// <param name="dev">The dev</param>
        [DllImport(NativeLibName, EntryPoint = "SDL_UnlockAudioDevice", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern void INTERNAL_SDL_UnlockAudioDevice([NotNull] uint dev);

        /// <summary>
        ///     Sdl the unlock audio device using the specified dev
        /// </summary>
        /// <param name="dev">The dev</param>
        [return: NotNull]
        public static void SdlUnlockAudioDevice([NotNull] uint dev) => INTERNAL_SDL_UnlockAudioDevice(dev.Validate());

        /// <summary>
        ///     Sdl the queue audio using the specified dev
        /// </summary>
        /// <param name="dev">The dev</param>
        /// <param name="data">The data</param>
        /// <param name="len">The len</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_QueueAudio", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern int INTERNAL_SDL_QueueAudio([NotNull] uint dev, [NotNull] IntPtr data, [NotNull] uint len);

        /// <summary>
        ///     Sdl the queue audio using the specified dev
        /// </summary>
        /// <param name="dev">The dev</param>
        /// <param name="data">The data</param>
        /// <param name="len">The len</param>
        /// <returns>The int</returns>
        [return: NotNull]
        public static int SdlQueueAudio([NotNull] uint dev, [NotNull] IntPtr data, [NotNull] uint len) => INTERNAL_SDL_QueueAudio(dev.Validate(), data.Validate(), len.Validate());

        /// <summary>
        ///     Sdl the dequeue audio using the specified dev
        /// </summary>
        /// <param name="dev">The dev</param>
        /// <param name="data">The data</param>
        /// <param name="len">The len</param>
        /// <returns>The uint</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_DequeueAudio", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern uint INTERNAL_SDL_DequeueAudio([NotNull] uint dev, [NotNull] IntPtr data, [NotNull] uint len);

        /// <summary>
        ///     Sdl the dequeue audio using the specified dev
        /// </summary>
        /// <param name="dev">The dev</param>
        /// <param name="data">The data</param>
        /// <param name="len">The len</param>
        /// <returns>The uint</returns>
        [return: NotNull]
        public static uint SdlDequeueAudio([NotNull] uint dev, [NotNull] IntPtr data, [NotNull] uint len) => INTERNAL_SDL_DequeueAudio(dev.Validate(), data.Validate(), len.Validate());

        /// <summary>
        ///     Sdl the get queued audio size using the specified dev
        /// </summary>
        /// <param name="dev">The dev</param>
        /// <returns>The int 32</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GetQueuedAudioSize", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern uint INTERNAL_SDL_GetQueuedAudioSize([NotNull] uint dev);

        /// <summary>
        ///     Sdl the get queued audio size using the specified dev
        /// </summary>
        /// <param name="dev">The dev</param>
        /// <returns>The uint</returns>
        [return: NotNull]
        public static uint SdlGetQueuedAudioSize([NotNull] uint dev) => INTERNAL_SDL_GetQueuedAudioSize(dev.Validate());

        /// <summary>
        ///     Sdl the clear queued audio using the specified dev
        /// </summary>
        /// <param name="dev">The dev</param>
        [DllImport(NativeLibName, EntryPoint = "SDL_ClearQueuedAudio", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern void INTERNAL_SDL_ClearQueuedAudio([NotNull] uint dev);

        /// <summary>
        ///     Sdl the clear queued audio using the specified dev
        /// </summary>
        /// <param name="dev">The dev</param>
        [return: NotNull]
        public static void SdlClearQueuedAudio([NotNull] uint dev) => INTERNAL_SDL_ClearQueuedAudio(dev.Validate());

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
        [DllImport(NativeLibName, EntryPoint = "SDL_NewAudioStream", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern IntPtr INTERNAL_SDL_NewAudioStream([NotNull] ushort srcFormat, [NotNull] byte srcChannels, [NotNull] int srcRate, [NotNull] ushort dstFormat, [NotNull] byte dstChannels, [NotNull] int dstRate);

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
        public static IntPtr SdlNewAudioStream([NotNull] ushort srcFormat, [NotNull] byte srcChannels, [NotNull] int srcRate, [NotNull] ushort dstFormat, [NotNull] byte dstChannels, [NotNull] int dstRate) => INTERNAL_SDL_NewAudioStream(srcFormat.Validate(), srcChannels.Validate(), srcRate.Validate(), dstFormat.Validate(), dstChannels.Validate(), dstRate.Validate());

        /// <summary>
        ///     Sdl the audio stream put using the specified stream
        /// </summary>
        /// <param name="stream">The stream</param>
        /// <param name="buf">The buf</param>
        /// <param name="len">The len</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_AudioStreamPut", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern int INTERNAL_SDL_AudioStreamPut([NotNull] IntPtr stream, [NotNull] IntPtr buf, [NotNull] int len);

        /// <summary>
        ///     Sdl the audio stream put using the specified stream
        /// </summary>
        /// <param name="stream">The stream</param>
        /// <param name="buf">The buf</param>
        /// <param name="len">The len</param>
        /// <returns>The int</returns>
        [return: NotNull]
        public static int SdlAudioStreamPut([NotNull] IntPtr stream, [NotNull] IntPtr buf, [NotNull] int len) => INTERNAL_SDL_AudioStreamPut(stream.Validate(), buf.Validate(), len.Validate());

        /// <summary>
        ///     Sdl the audio stream get using the specified stream
        /// </summary>
        /// <param name="stream">The stream</param>
        /// <param name="buf">The buf</param>
        /// <param name="len">The len</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_AudioStreamGet", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern int INTERNAL_SDL_AudioStreamGet([NotNull] IntPtr stream, [NotNull] IntPtr buf, [NotNull] int len);

        /// <summary>
        ///     Sdl the audio stream get using the specified stream
        /// </summary>
        /// <param name="stream">The stream</param>
        /// <param name="buf">The buf</param>
        /// <param name="len">The len</param>
        /// <returns>The int</returns>
        [return: NotNull]
        public static int SdlAudioStreamGet([NotNull] IntPtr stream, [NotNull] IntPtr buf, [NotNull] int len) => INTERNAL_SDL_AudioStreamGet(stream.Validate(), buf.Validate(), len.Validate());

        /// <summary>
        ///     Sdl the audio stream available using the specified stream
        /// </summary>
        /// <param name="stream">The stream</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_AudioStreamAvailable", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern int INTERNAL_SDL_AudioStreamAvailable(IntPtr stream);

        /// <summary>
        ///     Sdl the audio stream available using the specified stream
        /// </summary>
        /// <param name="stream">The stream</param>
        /// <returns>The int</returns>
        [return: NotNull]
        public static int SdlAudioStreamAvailable([NotNull] IntPtr stream) => INTERNAL_SDL_AudioStreamAvailable(stream.Validate());

        /// <summary>
        ///     Sdl the audio stream clear using the specified stream
        /// </summary>
        /// <param name="stream">The stream</param>
        [DllImport(NativeLibName, EntryPoint = "SDL_AudioStreamClear", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern void INTERNAL_SDL_AudioStreamClear([NotNull] IntPtr stream);

        /// <summary>
        ///     Sdl the audio stream clear using the specified stream
        /// </summary>
        /// <param name="stream">The stream</param>
        [return: NotNull]
        public static void SdlAudioStreamClear([NotNull] IntPtr stream) => INTERNAL_SDL_AudioStreamClear(stream.Validate());

        /// <summary>
        ///     Sdl the free audio stream using the specified stream
        /// </summary>
        /// <param name="stream">The stream</param>
        [DllImport(NativeLibName, EntryPoint = "SDL_FreeAudioStream", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern void INTERNAL_SDL_FreeAudioStream([NotNull] IntPtr stream);

        /// <summary>
        ///     Sdl the free audio stream using the specified stream
        /// </summary>
        /// <param name="stream">The stream</param>
        [return: NotNull]
        public static void SdlFreeAudioStream([NotEmpty] IntPtr stream) => INTERNAL_SDL_FreeAudioStream(stream.Validate());

        /// <summary>
        ///     Sdl the get audio device spec using the specified index
        /// </summary>
        /// <param name="index">The index</param>
        /// <param name="isCapture">The is capture</param>
        /// <param name="spec">The spec</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GetAudioDeviceSpec", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern int INTERNAL_SDL_GetAudioDeviceSpec([NotNull] int index, [NotNull] int isCapture, out SdlAudioSpec spec);

        /// <summary>
        ///     Sdl the get audio device spec using the specified index
        /// </summary>
        /// <param name="index">The index</param>
        /// <param name="isCapture">The is capture</param>
        /// <param name="spec">The spec</param>
        /// <returns>The int</returns>
        [return: NotNull]
        public static int SdlGetAudioDeviceSpec([NotNull] int index, [NotNull] int isCapture, out SdlAudioSpec spec) => INTERNAL_SDL_GetAudioDeviceSpec(index.Validate(), isCapture.Validate(), out spec);

        /// <summary>
        ///     Describes whether sdl ticks passed
        /// </summary>
        /// <param name="a">The </param>
        /// <param name="b">The </param>
        /// <returns>The bool</returns>
        public static bool SDL_TICKS_PASSED([NotNull] uint a, [NotNull] uint b) => (int) (b - a) <= 0;

        /// <summary>
        ///     Sdl the delay using the specified ms
        /// </summary>
        /// <param name="ms">The ms</param>
        [DllImport(NativeLibName, EntryPoint = "SDL_Delay", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern void INTERNAL_SDL_Delay([NotNull] uint ms);

        /// <summary>
        ///     Delays the ms
        /// </summary>
        /// <param name="ms">The ms</param>
        [return: NotNull]
        public static void Delay([NotNull] uint ms) => INTERNAL_SDL_Delay(ms.Validate());

        /// <summary>
        ///     Sdl the get ticks
        /// </summary>
        /// <returns>The int 32</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GetTicks", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern uint INTERNAL_SDL_GetTicks();

        /// <summary>
        ///     Internals the sdl get ticks
        /// </summary>
        /// <returns>The uint</returns>
        [return: NotNull]
        public static uint GetTicks() => INTERNAL_SDL_GetTicks().Validate();

        /// <summary>
        ///     Sdl the get ticks 64
        /// </summary>
        /// <returns>The int 64</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GetTicks64", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern ulong INTERNAL_SDL_GetTicks64();

        /// <summary>
        ///     Gets the ticks 64
        /// </summary>
        /// <returns>The ulong</returns>
        [return: NotNull]
        public static ulong GetTicks64() => INTERNAL_SDL_GetTicks64().Validate();

        /// <summary>
        ///     Sdl the get performance counter
        /// </summary>
        /// <returns>The int 64</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GetPerformanceCounter", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern ulong INTERNAL_SDL_GetPerformanceCounter();

        /// <summary>
        ///     Gets the performance counter
        /// </summary>
        /// <returns>The ulong</returns>
        [return: NotNull]
        public static ulong GetPerformanceCounter() => INTERNAL_SDL_GetPerformanceCounter().Validate();

        /// <summary>
        ///     Sdl the get performance frequency
        /// </summary>
        /// <returns>The int 64</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GetPerformanceFrequency", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern ulong INTERNAL_SDL_GetPerformanceFrequency();

        /// <summary>
        ///     Internals the sdl get performance frequency
        /// </summary>
        /// <returns>The ulong</returns>
        [return: NotNull]
        public static ulong GetPerformanceFrequency() => INTERNAL_SDL_GetPerformanceFrequency().Validate();

        /// <summary>
        ///     Sdl the add timer using the specified interval
        /// </summary>
        /// <param name="interval">The interval</param>
        /// <param name="callback">The callback</param>
        /// <param name="param">The param</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_AddTimer", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern int INTERNAL_SDL_AddTimer([NotNull] uint interval, SdlTimerCallback callback, IntPtr param);

        /// <summary>
        ///     Adds the timer using the specified interval
        /// </summary>
        /// <param name="interval">The interval</param>
        /// <param name="callback">The callback</param>
        /// <param name="param">The param</param>
        /// <returns>The int</returns>
        [return: NotNull]
        public static int AddTimer([NotNull] uint interval, SdlTimerCallback callback, IntPtr param) => INTERNAL_SDL_AddTimer(interval.Validate(), callback, param);

        /// <summary>
        ///     Sdl the remove timer using the specified id
        /// </summary>
        /// <param name="id">The id</param>
        /// <returns>The sdl bool</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_RemoveTimer", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern SdlBool INTERNAL_SDL_RemoveTimer([NotNull] int id);

        /// <summary>
        ///     Removes the timer using the specified id
        /// </summary>
        /// <param name="id">The id</param>
        /// <returns>The sdl bool</returns>
        [return: NotNull]
        public static SdlBool RemoveTimer([NotNull] int id) => INTERNAL_SDL_RemoveTimer(id.Validate());

        /// <summary>
        ///     Sdl the set windows message hook using the specified callback
        /// </summary>
        /// <param name="callback">The callback</param>
        /// <param name="userdata">The userdata</param>
        [DllImport(NativeLibName, EntryPoint = "SDL_SetWindowsMessageHook", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern void INTERNAL_SDL_SetWindowsMessageHook([NotNull] SdlWindowsMessageHook callback, [NotNull] IntPtr userdata);

        /// <summary>
        ///     Sets the windows message hook using the specified callback
        /// </summary>
        /// <param name="callback">The callback</param>
        /// <param name="userdata">The userdata</param>
        [return: NotNull]
        public static void SetWindowsMessageHook([NotNull] SdlWindowsMessageHook callback, [NotNull] IntPtr userdata) => INTERNAL_SDL_SetWindowsMessageHook(callback, userdata);

        /// <summary>
        ///     Sdl the render get d 3 d 9 device using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_RenderGetD3D9Device", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern IntPtr INTERNAL_SDL_RenderGetD3D9Device([NotNull] IntPtr renderer);

        /// <summary>
        ///     Renders the get d 3 d 9 device using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <returns>The int ptr</returns>
        [return: NotNull]
        public static IntPtr RenderGetD3D9Device([NotNull] IntPtr renderer) => INTERNAL_SDL_RenderGetD3D9Device(renderer.Validate());

        /// <summary>
        ///     Sdl the render get d 3 d 11 device using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_RenderGetD3D11Device", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern IntPtr INTERNAL_SDL_RenderGetD3D11Device([NotNull] IntPtr renderer);

        /// <summary>
        ///     Renders the get d 3 d 11 device using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <returns>The int ptr</returns>
        [return: NotNull]
        public static IntPtr RenderGetD3D11Device([NotNull] IntPtr renderer) => INTERNAL_SDL_RenderGetD3D11Device(renderer.Validate());

        /// <summary>
        ///     Sdl the i phone set animation callback using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="interval">The interval</param>
        /// <param name="callback">The callback</param>
        /// <param name="callbackParam">The callback param</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_iPhoneSetAnimationCallback", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern int INTERNAL_SDL_iPhoneSetAnimationCallback(IntPtr window, [NotNull] int interval, SdlIPhoneAnimationCallback callback, IntPtr callbackParam);

        /// <summary>
        ///     Is the phone set animation callback using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="interval">The interval</param>
        /// <param name="callback">The callback</param>
        /// <param name="callbackParam">The callback param</param>
        /// <returns>The int</returns>
        [return: NotNull]
        public static int PhoneSetAnimationCallback(IntPtr window, [NotNull] int interval, SdlIPhoneAnimationCallback callback, IntPtr callbackParam) => INTERNAL_SDL_iPhoneSetAnimationCallback(window.Validate(), interval, callback, callbackParam);

        /// <summary>
        ///     Sdl the i phone set event pump using the specified enabled
        /// </summary>
        /// <param name="enabled">The enabled</param>
        [DllImport(NativeLibName, EntryPoint = "SDL_iPhoneSetEventPump", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern void SDL_iPhoneSetEventPump([NotNull] SdlBool enabled);

        /// <summary>
        ///     Is the phone set event pump using the specified enabled
        /// </summary>
        /// <param name="enabled">The enabled</param>
        [return: NotNull]
        public static void PhoneSetEventPump([NotNull] SdlBool enabled) => SDL_iPhoneSetEventPump(enabled.Validate());

        /// <summary>
        ///     Sdl the android get jni env
        /// </summary>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_AndroidGetJNIEnv", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern IntPtr INTERNAL_SDL_AndroidGetJNIEnv();

        /// <summary>
        ///     Androids the get jni env
        /// </summary>
        /// <returns>The int ptr</returns>
        [return: NotNull]
        public static IntPtr AndroidGetJniEnv() => INTERNAL_SDL_AndroidGetJNIEnv().Validate();

        /// <summary>
        ///     Sdl the android get activity
        /// </summary>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_AndroidGetActivity", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern IntPtr INTERNAL_SDL_AndroidGetActivity();

        /// <summary>
        ///     Sdl the android get activity
        /// </summary>
        /// <returns>The int ptr</returns>
        [return: NotNull]
        public static IntPtr SdlAndroidGetActivity() => INTERNAL_SDL_AndroidGetActivity();

        /// <summary>
        ///     Sdl the is android tv
        /// </summary>
        /// <returns>The sdl bool</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_IsAndroidTV", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern SdlBool INTERNAL_SDL_IsAndroidTV();

        /// <summary>
        ///     Sdl the is android tv
        /// </summary>
        /// <returns>The sdl bool</returns>
        [return: NotNull]
        public static SdlBool SdlIsAndroidTv() => INTERNAL_SDL_IsAndroidTV();

        /// <summary>
        ///     Sdl the is chromebook
        /// </summary>
        /// <returns>The sdl bool</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_IsChromebook", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern SdlBool INTERNAL_SDL_IsChromebook();

        /// <summary>
        ///     Sdl the is chromebook
        /// </summary>
        /// <returns>The sdl bool</returns>
        [return: NotNull]
        public static SdlBool SdlIsChromebook() => INTERNAL_SDL_IsChromebook();

        /// <summary>
        ///     Sdl the is de x mode
        /// </summary>
        /// <returns>The sdl bool</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_IsDeXMode", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern SdlBool INTERNAL_SDL_IsDeXMode();

        /// <summary>
        ///     Sdl the is de x mode
        /// </summary>
        /// <returns>The sdl bool</returns>
        [return: NotNull]
        public static SdlBool SdlIsDeXMode() => INTERNAL_SDL_IsDeXMode();

        /// <summary>
        ///     Sdl the android back button
        /// </summary>
        [DllImport(NativeLibName, EntryPoint = "SDL_AndroidBackButton", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern void INTERNAL_SDL_AndroidBackButton();

        /// <summary>
        ///     Sdl the android back button
        /// </summary>
        [return: NotNull]
        public static void SdlAndroidBackButton() => INTERNAL_SDL_AndroidBackButton();

        /// <summary>
        ///     Internals the sdl android get internal storage path
        /// </summary>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_AndroidGetInternalStoragePath", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern IntPtr INTERNAL_SDL_AndroidGetInternalStoragePath();

        /// <summary>
        ///     Sdl the android get internal storage path
        /// </summary>
        /// <returns>The string</returns>
        [return: NotNull]
        public static string SdlAndroidGetInternalStoragePath() => Utf8Manager.Utf8ToManaged(INTERNAL_SDL_AndroidGetInternalStoragePath());

        /// <summary>
        ///     Sdl the android get external storage state
        /// </summary>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_AndroidGetExternalStorageState", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern int INTERNAL_SDL_AndroidGetExternalStorageState();

        /// <summary>
        ///     Sdl the android get external storage state
        /// </summary>
        /// <returns>The int</returns>
        [return: NotNull]
        public static int SdlAndroidGetExternalStorageState() => INTERNAL_SDL_AndroidGetExternalStorageState();

        /// <summary>
        ///     Internals the sdl android get external storage path
        /// </summary>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_AndroidGetExternalStoragePath", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern IntPtr INTERNAL_SDL_AndroidGetExternalStoragePath();

        /// <summary>
        ///     Sdl the android get external storage path
        /// </summary>
        /// <returns>The string</returns>
        [return: NotNull]
        public static string SdlAndroidGetExternalStoragePath() => Utf8Manager.Utf8ToManaged(INTERNAL_SDL_AndroidGetExternalStoragePath());

        /// <summary>
        ///     Sdl the get android sdk version
        /// </summary>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GetAndroidSDKVersion", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern int INTERNAL_SDL_GetAndroidSDKVersion();

        /// <summary>
        ///     Sdl the get android sdk version
        /// </summary>
        /// <returns>The int</returns>
        [return: NotNull]
        public static int SdlGetAndroidSdkVersion() => INTERNAL_SDL_GetAndroidSDKVersion();

        /// <summary>
        ///     Internals the sdl android request permission using the specified permission
        /// </summary>
        /// <param name="permission">The permission</param>
        /// <returns>The sdl bool</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_AndroidRequestPermission", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern SdlBool INTERNAL_SDL_AndroidRequestPermission([NotNull] byte[] permission);

        /// <summary>
        ///     Sdl the android request permission using the specified permission
        /// </summary>
        /// <param name="permission">The permission</param>
        /// <returns>The result</returns>
        [return: NotNull]
        public static SdlBool SdlAndroidRequestPermission([NotNull] string permission) => INTERNAL_SDL_AndroidRequestPermission(Utf8Manager.Utf8EncodeHeap(permission.Validate()));

        /// <summary>
        ///     Internals the sdl android show toast using the specified message
        /// </summary>
        /// <param name="message">The message</param>
        /// <param name="duration">The duration</param>
        /// <param name="gravity">The gravity</param>
        /// <param name="xOffset">The offset</param>
        /// <param name="yOffset">The offset</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_AndroidShowToast", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern int INTERNAL_SDL_AndroidShowToast([NotNull] byte[] message, [NotNull] int duration, [NotNull] int gravity, [NotNull] int xOffset, [NotNull] int yOffset);

        /// <summary>
        ///     Sdl the android show toast using the specified message
        /// </summary>
        /// <param name="message">The message</param>
        /// <param name="duration">The duration</param>
        /// <param name="gravity">The gravity</param>
        /// <param name="xOffset">The offset</param>
        /// <param name="yOffset">The offset</param>
        /// <returns>The result</returns>
        [return: NotNull]
        public static int SDL_AndroidShowToast([NotNull] string message, [NotNull] int duration, [NotNull] int gravity, [NotNull] int xOffset, [NotNull] int yOffset) => INTERNAL_SDL_AndroidShowToast(Utf8Manager.Utf8EncodeHeap(message), duration.Validate(), gravity.Validate(), xOffset.Validate(), yOffset.Validate());

        /// <summary>
        ///     Sdl the win rt get device family
        /// </summary>
        /// <returns>The sdl win rt device family</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_WinRTGetDeviceFamily", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern SdlWinRtDeviceFamily INTERNAL_SDL_WinRTGetDeviceFamily();

        /// <summary>
        ///     Sdl the win rt get device family
        /// </summary>
        /// <returns>The sdl win rt device family</returns>
        [return: NotNull]
        public static SdlWinRtDeviceFamily SdlWinRtGetDeviceFamily() => INTERNAL_SDL_WinRTGetDeviceFamily();

        /// <summary>
        ///     Sdl the is tablet
        /// </summary>
        /// <returns>The sdl bool</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_IsTablet", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern SdlBool INTERNAL_SDL_IsTablet();

        /// <summary>
        ///     Sdl the is tablet
        /// </summary>
        /// <returns>The sdl bool</returns>
        [return: NotNull]
        public static SdlBool SdlIsTablet() => INTERNAL_SDL_IsTablet();

        /// <summary>
        ///     Sdl the get window wm info using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="info">The info</param>
        /// <returns>The sdl bool</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GetWindowWMInfo", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern SdlBool INTERNAL_SDL_GetWindowWMInfo([NotNull] IntPtr window, ref SdlSysWMinfo info);

        /// <summary>
        ///     Sdl the get window wm info using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="info">The info</param>
        /// <returns>The sdl bool</returns>
        [return: NotNull]
        public static SdlBool SdlGetWindowWmInfo([NotNull] IntPtr window, ref SdlSysWMinfo info) => INTERNAL_SDL_GetWindowWMInfo(window.Validate(), ref info);

        /// <summary>
        ///     Internals the sdl get base path
        /// </summary>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GetBasePath", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern IntPtr INTERNAL_SDL_GetBasePath();

        /// <summary>
        ///     Sdl the get base path
        /// </summary>
        /// <returns>The string</returns>
        [return: NotNull]
        public static string SdlGetBasePath() => Utf8Manager.Utf8ToManaged(INTERNAL_SDL_GetBasePath().Validate(), true);

        /// <summary>
        ///     Internals the sdl get pref path using the specified org
        /// </summary>
        /// <param name="org">The org</param>
        /// <param name="app">The app</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GetPrefPath", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern IntPtr INTERNAL_SDL_GetPrefPath([NotNull] byte[] org, [NotNull] byte[] app);

        /// <summary>
        ///     Sdl the get pref path using the specified org
        /// </summary>
        /// <param name="org">The org</param>
        /// <param name="app">The app</param>
        /// <returns>The string</returns>
        [return: NotNull]
        public static string SdlGetPrefPath([NotNull] string org, [NotNull] string app)
            => Utf8Manager.Utf8ToManaged(INTERNAL_SDL_GetPrefPath(Utf8Manager.Utf8Encode(org.Validate(), new byte[Utf8Manager.Utf8Size(org.Validate())], Utf8Manager.Utf8Size(org.Validate())), Utf8Manager.Utf8Encode(app.Validate(), new byte[Utf8Manager.Utf8Size(app.Validate())], Utf8Manager.Utf8Size(app.Validate()))), true);

        /// <summary>
        ///     Sdl the get power info using the specified secs
        /// </summary>
        /// <param name="secs">The secs</param>
        /// <param name="pct">The pct</param>
        /// <returns>The sdl power state</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GetPowerInfo", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern SdlPowerState INTERNAL_SDL_GetPowerInfo(out int secs, out int pct);

        /// <summary>
        ///     Sdl the get power info using the specified secs
        /// </summary>
        /// <param name="secs">The secs</param>
        /// <param name="pct">The pct</param>
        /// <returns>The sdl power state</returns>
        [return: NotNull]
        public static SdlPowerState SdlGetPowerInfo(out int secs, out int pct) => INTERNAL_SDL_GetPowerInfo(out secs, out pct);

        /// <summary>
        ///     Sdl the get cpu count
        /// </summary>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GetCPUCount", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern int INTERNAL_SDL_GetCPUCount();

        /// <summary>
        ///     Sdl the get cpu count
        /// </summary>
        /// <returns>The int</returns>
        [return: NotNull]
        public static int SdlGetCpuCount() => INTERNAL_SDL_GetCPUCount();

        /// <summary>
        ///     Sdl the get cpu cache line size
        /// </summary>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GetCPUCacheLineSize", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern int INTERNAL_SDL_GetCPUCacheLineSize();

        /// <summary>
        ///     Sdl the get cpu cache line size
        /// </summary>
        /// <returns>The int</returns>
        [return: NotNull]
        public static int SdlGetCpuCacheLineSize() => INTERNAL_SDL_GetCPUCacheLineSize();

        /// <summary>
        ///     Sdl the has rdtsc
        /// </summary>
        /// <returns>The sdl bool</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_HasRDTSC", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern SdlBool INTERNAL_SDL_HasRDTSC();

        /// <summary>
        ///     Sdl the has rdtsc
        /// </summary>
        /// <returns>The sdl bool</returns>
        [return: NotNull]
        public static SdlBool SdlHasRdtsc() => INTERNAL_SDL_HasRDTSC();

        /// <summary>
        ///     Sdl the has alti vec
        /// </summary>
        /// <returns>The sdl bool</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_HasAltiVec", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern SdlBool INTERNAL_SDL_HasAltiVec();

        /// <summary>
        ///     Sdl the has alti vec
        /// </summary>
        /// <returns>The sdl bool</returns>
        [return: NotNull]
        public static SdlBool SdlHasAltiVec() => INTERNAL_SDL_HasAltiVec();

        /// <summary>
        ///     Sdl the has mmx
        /// </summary>
        /// <returns>The sdl bool</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_HasMMX", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern SdlBool INTERNAL_SDL_HasMMX();

        /// <summary>
        ///     Sdl the has mmx
        /// </summary>
        /// <returns>The sdl bool</returns>
        [return: NotNull]
        public static SdlBool SdlHasMmx() => INTERNAL_SDL_HasMMX();

        /// <summary>
        ///     Sdl the has 3 d now
        /// </summary>
        /// <returns>The sdl bool</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_Has3DNow", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern SdlBool INTERNAL_SDL_Has3DNow();

        /// <summary>
        ///     Sdl the has 3 d now
        /// </summary>
        /// <returns>The sdl bool</returns>
        [return: NotNull]
        public static SdlBool SdlHas3DNow() => INTERNAL_SDL_Has3DNow();

        /// <summary>
        ///     Sdl the has sse
        /// </summary>
        /// <returns>The sdl bool</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_HasSSE", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern SdlBool INTERNAL_SDL_HasSSE();

        /// <summary>
        ///     Sdl the has sse
        /// </summary>
        /// <returns>The sdl bool</returns>
        [return: NotNull]
        public static SdlBool SdlHasSse() => INTERNAL_SDL_HasSSE();

        /// <summary>
        ///     Sdl the has sse 2
        /// </summary>
        /// <returns>The sdl bool</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_HasSSE2", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern SdlBool INTERNAL_SDL_HasSSE2();

        /// <summary>
        ///     Sdl the has sse 2
        /// </summary>
        /// <returns>The sdl bool</returns>
        [return: NotNull]
        public static SdlBool SdlHasSse2() => INTERNAL_SDL_HasSSE2();

        /// <summary>
        ///     Sdl the has sse 3
        /// </summary>
        /// <returns>The sdl bool</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_HasSSE3", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern SdlBool INTERNAL_SDL_HasSSE3();

        /// <summary>
        ///     Sdl the has sse 3
        /// </summary>
        /// <returns>The sdl bool</returns>
        [return: NotNull]
        public static SdlBool SdlHasSse3() => INTERNAL_SDL_HasSSE3();

        /// <summary>
        ///     Sdl the has sse 41
        /// </summary>
        /// <returns>The sdl bool</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_HasSSE41", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern SdlBool INTERNAL_SDL_HasSSE41();

        /// <summary>
        ///     Sdl the has sse 41
        /// </summary>
        /// <returns>The sdl bool</returns>
        [return: NotNull]
        public static SdlBool SdlHasSse41() => INTERNAL_SDL_HasSSE41();

        /// <summary>
        ///     Sdl the has sse 42
        /// </summary>
        /// <returns>The sdl bool</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_HasSSE42", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern SdlBool INTERNAL_SDL_HasSSE42();

        /// <summary>
        ///     Sdl the has sse 42
        /// </summary>
        /// <returns>The sdl bool</returns>
        [return: NotNull]
        public static SdlBool SdlHasSse42() => INTERNAL_SDL_HasSSE42();

        /// <summary>
        ///     Sdl the has avx
        /// </summary>
        /// <returns>The sdl bool</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_HasAVX", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern SdlBool INTERNAL_SDL_HasAVX();

        /// <summary>
        ///     Sdl the has avx
        /// </summary>
        /// <returns>The sdl bool</returns>
        [return: NotNull]
        public static SdlBool SdlHasAvx() => INTERNAL_SDL_HasAVX();

        /// <summary>
        ///     Sdl the has avx 2
        /// </summary>
        /// <returns>The sdl bool</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_HasAVX2", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern SdlBool INTERNAL_SDL_HasAVX2();

        /// <summary>
        ///     Sdl the has avx 2
        /// </summary>
        /// <returns>The sdl bool</returns>
        [return: NotNull]
        public static SdlBool SdlHasAvX2() => INTERNAL_SDL_HasAVX2();

        /// <summary>
        ///     Sdl the has avx 512 f
        /// </summary>
        /// <returns>The sdl bool</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_HasAVX512F", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern SdlBool INTERNAL_SDL_HasAVX512F();

        /// <summary>
        ///     Sdl the has avx 512 f
        /// </summary>
        /// <returns>The sdl bool</returns>
        [return: NotNull]
        public static SdlBool SdlHasAvx512F() => INTERNAL_SDL_HasAVX512F();

        /// <summary>
        ///     Sdl the has neon
        /// </summary>
        /// <returns>The sdl bool</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_HasNEON", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern SdlBool INTERNAL_SDL_HasNEON();

        /// <summary>
        ///     Sdl the has neon
        /// </summary>
        /// <returns>The sdl bool</returns>
        [return: NotNull]
        public static SdlBool SdlHasNeon() => INTERNAL_SDL_HasNEON();

        /// <summary>
        ///     Sdl the get system ram
        /// </summary>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GetSystemRAM", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern int INTERNAL_SDL_GetSystemRAM();

        /// <summary>
        ///     Sdl the get system ram
        /// </summary>
        /// <returns>The int</returns>
        [return: NotNull]
        public static int SdlGetSystemRam() => INTERNAL_SDL_GetSystemRAM();

        /// <summary>
        ///     Sdl the simd get alignment
        /// </summary>
        /// <returns>The uint</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_SIMDGetAlignment", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern uint INTERNAL_SDL_SIMDGetAlignment();

        /// <summary>
        ///     Sdl the simd get alignment
        /// </summary>
        /// <returns>The uint</returns>
        [return: NotNull]
        public static uint SdlSimdGetAlignment() => INTERNAL_SDL_SIMDGetAlignment();

        /// <summary>
        ///     Sdl the simd alloc using the specified len
        /// </summary>
        /// <param name="len">The len</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_SIMDAlloc", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern IntPtr INTERNAL_SDL_SIMDAlloc([NotNull] uint len);

        /// <summary>
        ///     Sdl the simd alloc using the specified len
        /// </summary>
        /// <param name="len">The len</param>
        /// <returns>The int ptr</returns>
        [return: NotNull]
        public static IntPtr SdlSimdAlloc([NotNull] uint len) => INTERNAL_SDL_SIMDAlloc(len.Validate());

        /// <summary>
        ///     Sdl the simd realloc using the specified ptr
        /// </summary>
        /// <param name="ptr">The ptr</param>
        /// <param name="len">The len</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_SIMDRealloc", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern IntPtr INTERNAL_SDL_SIMDRealloc([NotNull] IntPtr ptr, [NotNull] uint len);

        /// <summary>
        ///     Sdl the simd realloc using the specified ptr
        /// </summary>
        /// <param name="ptr">The ptr</param>
        /// <param name="len">The len</param>
        /// <returns>The int ptr</returns>
        [return: NotNull]
        public static IntPtr SdlSimdRealloc([NotNull] IntPtr ptr, [NotNull] uint len) => INTERNAL_SDL_SIMDRealloc(ptr.Validate(), len.Validate());

        /// <summary>
        ///     Sdl the simd free using the specified ptr
        /// </summary>
        /// <param name="ptr">The ptr</param>
        [DllImport(NativeLibName, EntryPoint = "SDL_SIMDFree", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern void INTERNAL_SDL_SIMDFree(IntPtr ptr);

        /// <summary>
        ///     Sdl the simd free using the specified ptr
        /// </summary>
        /// <param name="ptr">The ptr</param>
        public static void SdlSimdFree([NotNull] IntPtr ptr) => INTERNAL_SDL_SIMDFree(ptr.Validate());

        /// <summary>
        ///     Sdl the has arms imd
        /// </summary>
        [DllImport(NativeLibName, EntryPoint = "SDL_HasARMSIMD", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern void INTERNAL_SDL_HasARMSIMD();

        /// <summary>
        ///     Sdl the has armsimd
        /// </summary>
        public static void SdlHasArmsimd() => INTERNAL_SDL_HasARMSIMD();

        /// <summary>
        ///     Sdl the get preferred locales
        /// </summary>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GetPreferredLocales", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern IntPtr INTERNAL_SDL_GetPreferredLocales();

        /// <summary>
        ///     Sdl the get preferred locales
        /// </summary>
        /// <returns>The int ptr</returns>
        [return: NotNull]
        public static IntPtr SdlGetPreferredLocales() => INTERNAL_SDL_GetPreferredLocales();

        /// <summary>
        ///     Internals the sdl open url using the specified url
        /// </summary>
        /// <param name="url">The url</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_OpenURL", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern int INTERNAL_SDL_OpenURL([NotNull, NotEmpty] byte[] url);

        /// <summary>
        ///     Sdl the open url using the specified url
        /// </summary>
        /// <param name="url">The url</param>
        /// <returns>The result</returns>
        [return: NotNull]
        public static int SDL_OpenURL([NotNull] string url) => INTERNAL_SDL_OpenURL(Utf8Manager.Utf8EncodeHeap(url.Validate()));
    }
}