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
using Alis.Core.Aspect.Base.Dll;
using Alis.Core.Aspect.Memory;
using Alis.Core.Aspect.Memory.Attributes;
using Alis.Core.Graphic.SDL.Delegates;
using Alis.Core.Graphic.SDL.Enums;
using Alis.Core.Graphic.SDL.Structs;

namespace Alis.Core.Graphic.SDL
{
    /// <summary>
    ///     The sdl class
    /// </summary>
    public static class Sdl
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="Sdl" /> class
        /// </summary>
        static Sdl() => EmbeddedDllClass.ExtractEmbeddedDlls("sdl2", SdlDlls.SdlDllBytes);
        
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
        public const uint SdlRwOpsUnknown = 0;

        /// <summary>
        ///     The sdl rw ops win file
        /// </summary>
        public const uint SdlRwOpsWinFile = 1;

        /// <summary>
        ///     The sdl rw ops std file
        /// </summary>
        public const uint SdlRwOpsStdFile = 2;

        /// <summary>
        ///     The sdl rw ops jni file
        /// </summary>
        public const uint SdlRwOpsJniFile = 3;

        /// <summary>
        ///     The sdl rw ops memory
        /// </summary>
        public const uint SdlRwOpsMemory = 4;

        /// <summary>
        ///     The sdl rw ops memory ro
        /// </summary>
        public const uint SdlRwOpsMemoryRo = 5;
        
        /// <summary>
        ///     The sdl init timer
        /// </summary>
        private const uint SdlInitTimer = 0x00000001;

        /// <summary>
        ///     The sdl init audio
        /// </summary>
        private const uint SdlInitAudio = 0x00000010;

        /// <summary>
        ///     The sdl init video
        /// </summary>
        public const uint SdlInitVideo = 0x00000020;

        /// <summary>
        ///     The sdl init joystick
        /// </summary>
        private const uint SdlInitJoystick = 0x00000200;

        /// <summary>
        ///     The sdl init haptic
        /// </summary>
        private const uint SdlInitHaptic = 0x00001000;

        /// <summary>
        ///     The sdl init game controller
        /// </summary>
        private const uint SdlInitGameController = 0x00002000;

        /// <summary>
        ///     The sdl init events
        /// </summary>
        private const uint SdlInitEvents = 0x00004000;

        /// <summary>
        ///     The sdl init sensor
        /// </summary>
        private const uint SdlInitSensor = 0x00008000;

        /// <summary>
        ///     The sdl init no parachute
        /// </summary>
        public const uint SdlInitNoParachute = 0x00100000;

        /// <summary>
        ///     The sdl init sensor
        /// </summary>
        public const uint SdlInitEverything = SdlInitTimer | SdlInitAudio | SdlInitVideo | SdlInitEvents | SdlInitJoystick | SdlInitHaptic | SdlInitGameController | SdlInitSensor;
        
        /// <summary>
        ///     The sdl hint framebuffer acceleration
        /// </summary>
        public const string SdlHintFramebufferAcceleration = "SDL_FRAMEBUFFER_ACCELERATION";

        /// <summary>
        ///     The sdl hint render driver
        /// </summary>
        public const string SdlHintRenderDriver = "SDL_RENDER_DRIVER";

        /// <summary>
        ///     The sdl hint render opengl shaders
        /// </summary>
        public const string SdlHintRenderOpenglShaders = "SDL_RENDER_OPENGL_SHADERS";

        /// <summary>
        ///     The sdl hint render direct3d threadsafe
        /// </summary>
        public const string SdlHintRenderDirect3DThreadsafe = "SDL_RENDER_DIRECT3D_THREADSAFE";

        /// <summary>
        ///     The sdl hint render vsync
        /// </summary>
        public const string SdlHintRenderVsync = "SDL_RENDER_VSYNC";

        /// <summary>
        ///     The sdl hint video x11 x vid mode
        /// </summary>
        public const string SdlHintVideoX11XVidMode = "SDL_VIDEO_X11_XVIDMODE";

        /// <summary>
        ///     The sdl hint video x11 x ine rama
        /// </summary>
        public const string SdlHintVideoX11XIneRama = "SDL_VIDEO_X11_XINERAMA";

        /// <summary>
        ///     The sdl hint video x11 xrandr
        /// </summary>
        public const string SdlHintVideoX11Xrandr = "SDL_VIDEO_X11_XRANDR";

        /// <summary>
        ///     The sdl hint grab keyboard
        /// </summary>
        public const string SdlHintGrabKeyboard = "SDL_GRAB_KEYBOARD";

        /// <summary>
        ///     The sdl hint video minimize on focus loss
        /// </summary>
        public const string SdlHintVideoMinimizeOnFocusLoss = "SDL_VIDEO_MINIMIZE_ON_FOCUS_LOSS";

        /// <summary>
        ///     The sdl hint idle timer disabled
        /// </summary>
        public const string SdlHintIdleTimerDisabled = "SDL_IOS_IDLE_TIMER_DISABLED";

        /// <summary>
        ///     The sdl hint orientations
        /// </summary>
        public const string SdlHintOrientations = "SDL_IOS_ORIENTATIONS";

        /// <summary>
        ///     The sdl hint x input enabled
        /// </summary>
        public const string SdlHintXInputEnabled = "SDL_XINPUT_ENABLED";

        /// <summary>
        ///     The sdl hint game controller config
        /// </summary>
        public const string SdlHintGameControllerConfig = "SDL_GAMECONTROLLERCONFIG";

        /// <summary>
        ///     The sdl hint joystick allow background events
        /// </summary>
        public const string SdlHintJoystickAllowBackgroundEvents = "SDL_JOYSTICK_ALLOW_BACKGROUND_EVENTS";

        /// <summary>
        ///     The sdl hint allow topmost
        /// </summary>
        public const string SdlHintAllowTopmost = "SDL_ALLOW_TOPMOST";

        /// <summary>
        ///     The sdl hint timer resolution
        /// </summary>
        public const string SdlHintTimerResolution = "SDL_TIMER_RESOLUTION";

        /// <summary>
        ///     The sdl hint render scale quality
        /// </summary>
        public const string SdlHintRenderScaleQuality = "SDL_RENDER_SCALE_QUALITY";
        
        /// <summary>
        ///     The sdl hint video high dpi disabled
        /// </summary>
        public const string SdlHintVideoHighDpiDisabled = "SDL_VIDEO_HIGHDPI_DISABLED";
        
        /// <summary>
        ///     The sdl hint ctrl click emulate right click
        /// </summary>
        public const string SdlHintCtrlClickEmulateRightClick = "SDL_CTRL_CLICK_EMULATE_RIGHT_CLICK";

        /// <summary>
        ///     The sdl hint video win d3d compiler
        /// </summary>
        public const string SdlHintVideoWinD3DCompiler = "SDL_VIDEO_WIN_D3DCOMPILER";

        /// <summary>
        ///     The sdl hint mouse relative mode warp
        /// </summary>
        public const string SdlHintMouseRelativeModeWarp = "SDL_MOUSE_RELATIVE_MODE_WARP";

        /// <summary>
        ///     The sdl hint video window share pixel format
        /// </summary>
        public const string SdlHintVideoWindowSharePixelFormat = "SDL_VIDEO_WINDOW_SHARE_PIXEL_FORMAT";

        /// <summary>
        ///     The sdl hint video allow screensaver
        /// </summary>
        public const string SdlHintVideoAllowScreensaver = "SDL_VIDEO_ALLOW_SCREENSAVER";

        /// <summary>
        ///     The sdl hint accelerometer as joystick
        /// </summary>
        public const string SdlHintAccelerometerAsJoystick = "SDL_ACCELEROMETER_AS_JOYSTICK";

        /// <summary>
        ///     The sdl hint video mac fullscreen spaces
        /// </summary>
        public const string SdlHintVideoMacFullscreenSpaces = "SDL_VIDEO_MAC_FULLSCREEN_SPACES";

        /// <summary>
        ///     The sdl hint winrt privacy policy url
        /// </summary>
        public const string SdlHintWinrtPrivacyPolicyUrl = "SDL_WINRT_PRIVACY_POLICY_URL";

        /// <summary>
        ///     The sdl hint winrt privacy policy label
        /// </summary>
        public const string SdlHintWinrtPrivacyPolicyLabel = "SDL_WINRT_PRIVACY_POLICY_LABEL";

        /// <summary>
        ///     The sdl hint winrt handle back button
        /// </summary>
        public const string SdlHintWinrtHandleBackButton = "SDL_WINRT_HANDLE_BACK_BUTTON";
        
        /// <summary>
        ///     The sdl hint no signal handlers
        /// </summary>
        public const string SdlHintNoSignalHandlers = "SDL_NO_SIGNAL_HANDLERS";

        /// <summary>
        ///     The sdl hint ime internal editing
        /// </summary>
        public const string SdlHintImeInternalEditing = "SDL_IME_INTERNAL_EDITING";

        /// <summary>
        ///     The sdl hint android separate mouse and touch
        /// </summary>
        public const string SdlHintAndroidSeparateMouseAndTouch = "SDL_ANDROID_SEPARATE_MOUSE_AND_TOUCH";

        /// <summary>
        ///     The sdl hint emscripten keyboard element
        /// </summary>
        public const string SdlHintEmscriptenKeyboardElement = "SDL_EMSCRIPTEN_KEYBOARD_ELEMENT";

        /// <summary>
        ///     The sdl hint thread stack size
        /// </summary>
        public const string SdlHintThreadStackSize = "SDL_THREAD_STACK_SIZE";

        /// <summary>
        ///     The sdl hint window frame usable while cursor hidden
        /// </summary>
        public const string SdlHintWindowFrameUsableWhileCursorHidden = "SDL_WINDOW_FRAME_USABLE_WHILE_CURSOR_HIDDEN";

        /// <summary>
        ///     The sdl hint windows enable message loop
        /// </summary>
        public const string SdlHintWindowsEnableMessageLoop = "SDL_WINDOWS_ENABLE_MESSAGELOOP";

        /// <summary>
        ///     The sdl hint windows no close on alt f4
        /// </summary>
        public const string SdlHintWindowsNoCloseOnAltF4 = "SDL_WINDOWS_NO_CLOSE_ON_ALT_F4";

        /// <summary>
        ///     The sdl hint x input use old joystick mapping
        /// </summary>
        public const string SdlHintXInputUseOldJoystickMapping = "SDL_XINPUT_USE_OLD_JOYSTICK_MAPPING";

        /// <summary>
        ///     The sdl hint mac background app
        /// </summary>
        public const string SdlHintMacBackgroundApp = "SDL_MAC_BACKGROUND_APP";

        /// <summary>
        ///     The sdl hint video x11 net wm ping
        /// </summary>
        public const string SdlHintVideoX11NetWmPing = "SDL_VIDEO_X11_NET_WM_PING";

        /// <summary>
        ///     The sdl hint android apk expansion main file version
        /// </summary>
        public const string SdlHintAndroidApkExpansionMainFileVersion = "SDL_ANDROID_APK_EXPANSION_MAIN_FILE_VERSION";

        /// <summary>
        ///     The sdl hint android apk expansion patch file version
        /// </summary>
        public const string SdlHintAndroidApkExpansionPatchFileVersion = "SDL_ANDROID_APK_EXPANSION_PATCH_FILE_VERSION";
        
        /// <summary>
        ///     The sdl hint mouse focus click through
        /// </summary>
        public const string SdlHintMouseFocusClickThrough = "SDL_MOUSE_FOCUS_CLICKTHROUGH";

        /// <summary>
        ///     The sdl hint bmp save legacy format
        /// </summary>
        public const string SdlHintBmpSaveLegacyFormat = "SDL_BMP_SAVE_LEGACY_FORMAT";

        /// <summary>
        ///     The sdl hint windows disable thread naming
        /// </summary>
        public const string SdlHintWindowsDisableThreadNaming = "SDL_WINDOWS_DISABLE_THREAD_NAMING";

        /// <summary>
        ///     The sdl hint apple tv remote allow rotation
        /// </summary>
        public const string SdlHintAppleTvRemoteAllowRotation = "SDL_APPLE_TV_REMOTE_ALLOW_ROTATION";
        
        /// <summary>
        ///     The sdl hint audio resampling mode
        /// </summary>
        public const string SdlHintAudioResamplingMode = "SDL_AUDIO_RESAMPLING_MODE";

        /// <summary>
        ///     The sdl hint render logical size mode
        /// </summary>
        public const string SdlHintRenderLogicalSizeMode = "SDL_RENDER_LOGICAL_SIZE_MODE";

        /// <summary>
        ///     The sdl hint mouse normal speed scale
        /// </summary>
        public const string SdlHintMouseNormalSpeedScale = "SDL_MOUSE_NORMAL_SPEED_SCALE";

        /// <summary>
        ///     The sdl hint mouse relative speed scale
        /// </summary>
        public const string SdlHintMouseRelativeSpeedScale = "SDL_MOUSE_RELATIVE_SPEED_SCALE";

        /// <summary>
        ///     The sdl hint touch mouse events
        /// </summary>
        public const string SdlHintTouchMouseEvents = "SDL_TOUCH_MOUSE_EVENTS";

        /// <summary>
        ///     The sdl hint windows intro source icon
        /// </summary>
        public const string SdlHintWindowsIntroSourceIcon = "SDL_WINDOWS_INTRESOURCE_ICON";

        /// <summary>
        ///     The sdl hint windows intro source icon small
        /// </summary>
        public const string SdlHintWindowsIntroSourceIconSmall = "SDL_WINDOWS_INTRESOURCE_ICON_SMALL";
        
        /// <summary>
        ///     The sdl hint ios hide home indicator
        /// </summary>
        public const string SdlHintIosHideHomeIndicator = "SDL_IOS_HIDE_HOME_INDICATOR";

        /// <summary>
        ///     The sdl hint tv remote as joystick
        /// </summary>
        public const string SdlHintTvRemoteAsJoystick = "SDL_TV_REMOTE_AS_JOYSTICK";

        /// <summary>
        ///     The sdl video x11 net wm bypass compositor
        /// </summary>
        public const string SdlVideoX11NetWmBypassCompositor = "SDL_VIDEO_X11_NET_WM_BYPASS_COMPOSITOR";
        
        /// <summary>
        ///     The sdl hint mouse double click time
        /// </summary>
        public const string SdlHintMouseDoubleClickTime = "SDL_MOUSE_DOUBLE_CLICK_TIME";

        /// <summary>
        ///     The sdl hint mouse double click radius
        /// </summary>
        public const string SdlHintMouseDoubleClickRadius = "SDL_MOUSE_DOUBLE_CLICK_RADIUS";

        /// <summary>
        ///     The sdl hint joystick hidapi
        /// </summary>
        public const string SdlHintJoystickHidapi = "SDL_JOYSTICK_HIDAPI";

        /// <summary>
        ///     The sdl hint joystick hidapi ps4
        /// </summary>
        public const string SdlHintJoystickHidapiPs4 = "SDL_JOYSTICK_HIDAPI_PS4";

        /// <summary>
        ///     The sdl hint joystick hidapi ps4 rumble
        /// </summary>
        public const string SdlHintJoystickHidapiPs4Rumble = "SDL_JOYSTICK_HIDAPI_PS4_RUMBLE";

        /// <summary>
        ///     The sdl hint joystick hidapi steam
        /// </summary>
        public const string SdlHintJoystickHidapiSteam = "SDL_JOYSTICK_HIDAPI_STEAM";

        /// <summary>
        ///     The sdl hint joystick hidapi switch
        /// </summary>
        public const string SdlHintJoystickHidapiSwitch = "SDL_JOYSTICK_HIDAPI_SWITCH";

        /// <summary>
        ///     The sdl hint joystick hidapi xbox
        /// </summary>
        public const string SdlHintJoystickHidapiXbox = "SDL_JOYSTICK_HIDAPI_XBOX";

        /// <summary>
        ///     The sdl hint enable steam controllers
        /// </summary>
        public const string SdlHintEnableSteamControllers = "SDL_ENABLE_STEAM_CONTROLLERS";

        /// <summary>
        ///     The sdl hint android trap back button
        /// </summary>
        public const string SdlHintAndroidTrapBackButton = "SDL_ANDROID_TRAP_BACK_BUTTON";
        
        /// <summary>
        ///     The sdl hint mouse touch events
        /// </summary>
        public const string SdlHintMouseTouchEvents = "SDL_MOUSE_TOUCH_EVENTS";

        /// <summary>
        ///     The sdl hint game controller config file
        /// </summary>
        public const string SdlHintGameControllerConfigFile = "SDL_GAMECONTROLLERCONFIG_FILE";

        /// <summary>
        ///     The sdl hint android block on pause
        /// </summary>
        public const string SdlHintAndroidBlockOnPause = "SDL_ANDROID_BLOCK_ON_PAUSE";

        /// <summary>
        ///     The sdl hint render batching
        /// </summary>
        public const string SdlHintRenderBatching = "SDL_RENDER_BATCHING";

        /// <summary>
        ///     The sdl hint event logging
        /// </summary>
        public const string SdlHintEventLogging = "SDL_EVENT_LOGGING";

        /// <summary>
        ///     The sdl hint wave riff chunk size
        /// </summary>
        public const string SdlHintWaveRiffChunkSize = "SDL_WAVE_RIFF_CHUNK_SIZE";

        /// <summary>
        ///     The sdl hint wave truncation
        /// </summary>
        public const string SdlHintWaveTruncation = "SDL_WAVE_TRUNCATION";

        /// <summary>
        ///     The sdl hint wave fact chunk
        /// </summary>
        public const string SdlHintWaveFactChunk = "SDL_WAVE_FACT_CHUNK";
        
        /// <summary>
        ///     The sdl hint x11 window visual id
        /// </summary>
        public const string SdlHintVideoX11WindowVisualId = "SDL_VIDEO_X11_WINDOW_VISUALID";

        /// <summary>
        ///     The sdl hint game controller use button labels
        /// </summary>
        public const string SdlHintGameControllerUseButtonLabels = "SDL_GAMECONTROLLER_USE_BUTTON_LABELS";

        /// <summary>
        ///     The sdl hint video external context
        /// </summary>
        public const string SdlHintVideoExternalContext = "SDL_VIDEO_EXTERNAL_CONTEXT";

        /// <summary>
        ///     The sdl hint joystick hidapi game cube
        /// </summary>
        public const string SdlHintJoystickHidapiGameCube = "SDL_JOYSTICK_HIDAPI_GAMECUBE";

        /// <summary>
        ///     The sdl hint display usable bounds
        /// </summary>
        public const string SdlHintDisplayUsableBounds = "SDL_DISPLAY_USABLE_BOUNDS";

        /// <summary>
        ///     The sdl hint video x11 force egl
        /// </summary>
        public const string SdlHintVideoX11ForceEgl = "SDL_VIDEO_X11_FORCE_EGL";

        /// <summary>
        ///     The sdl hint game controller type
        /// </summary>
        public const string SdlHintGameControllerType = "SDL_GAMECONTROLLERTYPE";
        
        /// <summary>
        ///     The sdl hint joystick hidapi correlate x input
        /// </summary>
        public const string SdlHintJoystickHidapiCorrelateXInput = "SDL_JOYSTICK_HIDAPI_CORRELATE_XINPUT";

        /// <summary>
        ///     The sdl hint joystick raw input
        /// </summary>
        public const string SdlHintJoystickRawInput = "SDL_JOYSTICK_RAWINPUT";

        /// <summary>
        ///     The sdl hint audio device app name
        /// </summary>
        public const string SdlHintAudioDeviceAppName = "SDL_AUDIO_DEVICE_APP_NAME";

        /// <summary>
        ///     The sdl hint audio device stream name
        /// </summary>
        public const string SdlHintAudioDeviceStreamName = "SDL_AUDIO_DEVICE_STREAM_NAME";

        /// <summary>
        ///     The sdl hint preferred locales
        /// </summary>
        public const string SdlHintPreferredLocales = "SDL_PREFERRED_LOCALES";

        /// <summary>
        ///     The sdl hint thread priority policy
        /// </summary>
        public const string SdlHintThreadPriorityPolicy = "SDL_THREAD_PRIORITY_POLICY";

        /// <summary>
        ///     The sdl hint emscripten asyncify
        /// </summary>
        public const string SdlHintEmscriptenAsyncify = "SDL_EMSCRIPTEN_ASYNCIFY";

        /// <summary>
        ///     The sdl hint linux joystick dead zones
        /// </summary>
        public const string SdlHintLinuxJoystickDeadZones = "SDL_LINUX_JOYSTICK_DEADZONES";

        /// <summary>
        ///     The sdl hint android block on pause pause audio
        /// </summary>
        public const string SdlHintAndroidBlockOnPausePauseAudio = "SDL_ANDROID_BLOCK_ON_PAUSE_PAUSEAUDIO";

        /// <summary>
        ///     The sdl hint joystick hidapi ps5
        /// </summary>
        public const string SdlHintJoystickHidapiPs5 = "SDL_JOYSTICK_HIDAPI_PS5";

        /// <summary>
        ///     The sdl hint thread force realtime time critical
        /// </summary>
        public const string SdlHintThreadForceRealtimeTimeCritical = "SDL_THREAD_FORCE_REALTIME_TIME_CRITICAL";

        /// <summary>
        ///     The sdl hint joystick thread
        /// </summary>
        public const string SdlHintJoystickThread = "SDL_JOYSTICK_THREAD";

        /// <summary>
        ///     The sdl hint auto update joysticks
        /// </summary>
        public const string SdlHintAutoUpdateJoysticks = "SDL_AUTO_UPDATE_JOYSTICKS";

        /// <summary>
        ///     The sdl hint auto update sensors
        /// </summary>
        public const string SdlHintAutoUpdateSensors = "SDL_AUTO_UPDATE_SENSORS";

        /// <summary>
        ///     The sdl hint mouse relative scaling
        /// </summary>
        public const string SdlHintMouseRelativeScaling = "SDL_MOUSE_RELATIVE_SCALING";

        /// <summary>
        ///     The sdl hint joystick hidapi ps5 rumble
        /// </summary>
        public const string SdlHintJoystickHidapiPs5Rumble = "SDL_JOYSTICK_HIDAPI_PS5_RUMBLE";
        
        /// <summary>
        ///     The sdl hint windows force mutex critical sections
        /// </summary>
        public const string SdlHintWindowsForceMutexCriticalSections = "SDL_WINDOWS_FORCE_MUTEX_CRITICAL_SECTIONS";

        /// <summary>
        ///     The sdl hint windows force semaphore kernel
        /// </summary>
        public const string SdlHintWindowsForceSemaphoreKernel = "SDL_WINDOWS_FORCE_SEMAPHORE_KERNEL";

        /// <summary>
        ///     The sdl hint joystick hidapi ps5 player led
        /// </summary>
        public const string SdlHintJoystickHidapiPs5PlayerLed = "SDL_JOYSTICK_HIDAPI_PS5_PLAYER_LED";

        /// <summary>
        ///     The sdl hint windows use d3d9ex
        /// </summary>
        public const string SdlHintWindowsUseD3D9Ex = "SDL_WINDOWS_USE_D3D9EX";

        /// <summary>
        ///     The sdl hint joystick hidapi joy cons
        /// </summary>
        public const string SdlHintJoystickHidapiJoyCons = "SDL_JOYSTICK_HIDAPI_JOY_CONS";

        /// <summary>
        ///     The sdl hint joystick hidapi stadia
        /// </summary>
        public const string SdlHintJoystickHidapiStadia = "SDL_JOYSTICK_HIDAPI_STADIA";

        /// <summary>
        ///     The sdl hint joystick hidapi switch home led
        /// </summary>
        public const string SdlHintJoystickHidapiSwitchHomeLed = "SDL_JOYSTICK_HIDAPI_SWITCH_HOME_LED";

        /// <summary>
        ///     The sdl hint allow alt tab while grabbed
        /// </summary>
        public const string SdlHintAllowAltTabWhileGrabbed = "SDL_ALLOW_ALT_TAB_WHILE_GRABBED";

        /// <summary>
        ///     The sdl hint km sd rm require drm master
        /// </summary>
        public const string SdlHintKmSdFmRequireDrmMaster = "SDL_KMSDRM_REQUIRE_DRM_MASTER";

        /// <summary>
        ///     The sdl hint audio device stream role
        /// </summary>
        public const string SdlHintAudioDeviceStreamRole = "SDL_AUDIO_DEVICE_STREAM_ROLE";

        /// <summary>
        ///     The sdl hint x11 force override redirect
        /// </summary>
        public const string SdlHintX11ForceOverrideRedirect = "SDL_X11_FORCE_OVERRIDE_REDIRECT";

        /// <summary>
        ///     The sdl hint joystick hidapi luna
        /// </summary>
        public const string SdlHintJoystickHidapiLuna = "SDL_JOYSTICK_HIDAPI_LUNA";
        
        /// <summary>
        ///     The sdl hint joystick raw input correlate x input
        /// </summary>
        public const string SdlHintJoystickRawInputCorrelateXInput = "SDL_JOYSTICK_RAWINPUT_CORRELATE_XINPUT";
        
        /// <summary>
        ///     The sdl hint audio include monitors
        /// </summary>
        public const string SdlHintAudioIncludeMonitors = "SDL_AUDIO_INCLUDE_MONITORS";

        /// <summary>
        ///     The sdl hint video wayland allow lib decor
        /// </summary>
        public const string SdlHintVideoWaylandAllowLibDecor = "SDL_VIDEO_WAYLAND_ALLOW_LIBDECOR";
        
        /// <summary>
        ///     The sdl hint video egl allow transparency
        /// </summary>
        public const string SdlHintVideoEglAllowTransparency = "SDL_VIDEO_EGL_ALLOW_TRANSPARENCY";

        /// <summary>
        ///     The sdl hint app name
        /// </summary>
        public const string SdlHintAppName = "SDL_APP_NAME";

        /// <summary>
        ///     The sdl hint screensaver inhibit activity name
        /// </summary>
        public const string SdlHintScreensaverInhibitActivityName = "SDL_SCREENSAVER_INHIBIT_ACTIVITY_NAME";

        /// <summary>
        ///     The sdl hint ime show ui
        /// </summary>
        public const string SdlHintImeShowUi = "SDL_IME_SHOW_UI";

        /// <summary>
        ///     The sdl hint window no activation when shown
        /// </summary>
        public const string SdlHintWindowNoActivationWhenShown = "SDL_WINDOW_NO_ACTIVATION_WHEN_SHOWN";

        /// <summary>
        ///     The sdl hint poll sentinel
        /// </summary>
        public const string SdlHintPollSentinel = "SDL_POLL_SENTINEL";

        /// <summary>
        ///     The sdl hint joystick device
        /// </summary>
        public const string SdlHintJoystickDevice = "SDL_JOYSTICK_DEVICE";

        /// <summary>
        ///     The sdl hint linux joystick classic
        /// </summary>
        public const string SdlHintLinuxJoystickClassic = "SDL_LINUX_JOYSTICK_CLASSIC";
        
        /// <summary>
        ///     The sdl major version
        /// </summary>
        private const int SdlMajorVersion = 2;

        /// <summary>
        ///     The sdl minor version
        /// </summary>
        private const int SdlMinorVersion = 0;

        /// <summary>
        ///     The sdl patch level
        /// </summary>
        private const int SdlPatchLevel = 18;
        
        /// <summary>
        ///     The sdl window pos undefined mask
        /// </summary>
        private const int SdlWindowPosUndefinedMask = 0x1FFF0000;

        /// <summary>
        ///     The sdl window pos centered mask
        /// </summary>
        private const int SdlWindowPosCenteredMask = 0x2FFF0000;

        /// <summary>
        ///     The sdl window pos undefined
        /// </summary>
        public const int SdlWindowPosUndefined = 0x1FFF0000;

        /// <summary>
        ///     The sdl window pos centered
        /// </summary>
        public const int SdlWindowPosCentered = 0x2FFF0000;

        /// <summary>
        ///     The sdl sw surface
        /// </summary>
        public const uint SdlSwSurface = 0x00000000;

        /// <summary>
        ///     The sdl pre alloc
        /// </summary>
        public const uint SdlPreAlloc = 0x00000001;

        /// <summary>
        ///     The sdl rle accel
        /// </summary>
        private const uint SdlRleAccel = 0x00000002;

        /// <summary>
        ///     The sdl dont free
        /// </summary>
        public const uint SdlDontFree = 0x00000004;
        
        /// <summary>
        ///     The sdl pressed
        /// </summary>
        public const byte SdlPressed = 1;

        /// <summary>
        ///     The sdl released
        /// </summary>
        public const byte SdlReleased = 0;
        
        /// <summary>
        ///     The sdl text editing event text size
        /// </summary>
        public const int SdlTextEditingEventTextSize = 32;

        /// <summary>
        ///     The sdl text input event text size
        /// </summary>
        public const int SdlTextInputEventTextSize = 32;

        /// <summary>
        ///     The sdl query
        /// </summary>
        private const int SdlQuery = -1;

        /// <summary>
        ///     The sdl ignore
        /// </summary>
        public const int SdlIgnore = 0;

        /// <summary>
        ///     The sdl disable
        /// </summary>
        public const int SdlDisable = 0;

        /// <summary>
        ///     The sdl enable
        /// </summary>
        public const int SdlEnable = 1;

        /// <summary>
        ///     The sdl scancode mask
        /// </summary>
        public const int SdlKScancodeMask = 1 << 30;

        /// <summary>
        ///     The sdl button left
        /// </summary>
        public const uint SdlButtonLeft = 1;

        /// <summary>
        ///     The sdl button middle
        /// </summary>
        public const uint SdlButtonMiddle = 2;

        /// <summary>
        ///     The sdl button right
        /// </summary>
        public const uint SdlButtonRight = 3;

        /// <summary>
        ///     The sdl button x1
        /// </summary>
        private const uint SdlButtonX1 = 4;

        /// <summary>
        ///     The sdl button x2
        /// </summary>
        private const uint SdlButtonX2 = 5;

        /// <summary>
        ///     The max value
        /// </summary>
        public const uint SdlTouchMouseId = uint.MaxValue;
        
        /// <summary>
        ///     The sdl hat centered
        /// </summary>
        public const byte SdlHatCentered = 0x00;

        /// <summary>
        ///     The sdl hat up
        /// </summary>
        private const byte SdlHatUp = 0x01;

        /// <summary>
        ///     The sdl hat right
        /// </summary>
        private const byte SdlHatRight = 0x02;

        /// <summary>
        ///     The sdl hat down
        /// </summary>
        private const byte SdlHatDown = 0x04;

        /// <summary>
        ///     The sdl hat left
        /// </summary>
        private const byte SdlHatLeft = 0x08;

        /// <summary>
        ///     The sdl hat up
        /// </summary>
        public const byte SdlHatRightUp = SdlHatRight | SdlHatUp;

        /// <summary>
        ///     The sdl hat down
        /// </summary>
        public const byte SdlHatRightDown = SdlHatRight | SdlHatDown;

        /// <summary>
        ///     The sdl hat up
        /// </summary>
        public const byte SdlHatLeftUp = SdlHatLeft | SdlHatUp;

        /// <summary>
        ///     The sdl hat down
        /// </summary>
        public const byte SdlHatLeftDown = SdlHatLeft | SdlHatDown;


        /// <summary>
        ///     The sdl iphone max g force
        /// </summary>
        public const float SdlIphoneMaxGForce = 5.0f;

        /// <summary>
        ///     The sdl haptic constant
        /// </summary>
        public const ushort SdlHapticConstant = 1 << 0;

        /// <summary>
        ///     The sdl haptic sine
        /// </summary>
        public const ushort SdlHapticSine = 1 << 1;

        /// <summary>
        ///     The sdl haptic left right
        /// </summary>
        public const ushort SdlHapticLeftRight = 1 << 2;

        /// <summary>
        ///     The sdl haptic triangle
        /// </summary>
        public const ushort SdlHapticTriangle = 1 << 3;

        /// <summary>
        ///     The sdl haptic saw tooth up
        /// </summary>
        public const ushort SdlHapticSawToothUp = 1 << 4;

        /// <summary>
        ///     The sdl haptic saw tooth down
        /// </summary>
        public const ushort SdlHapticSawToothDown = 1 << 5;

        /// <summary>
        ///     The sdl haptic spring
        /// </summary>
        public const ushort SdlHapticSpring = 1 << 7;

        /// <summary>
        ///     The sdl haptic damper
        /// </summary>
        public const ushort SdlHapticDamper = 1 << 8;

        /// <summary>
        ///     The sdl haptic inertia
        /// </summary>
        public const ushort SdlHapticInertia = 1 << 9;

        /// <summary>
        ///     The sdl haptic friction
        /// </summary>
        public const ushort SdlHapticFriction = 1 << 10;

        /// <summary>
        ///     The sdl haptic custom
        /// </summary>
        public const ushort SdlHapticCustom = 1 << 11;

        /// <summary>
        ///     The sdl haptic gain
        /// </summary>
        public const ushort SdlHapticGain = 1 << 12;

        /// <summary>
        ///     The sdl haptic auto center
        /// </summary>
        public const ushort SdlHapticAutoCenter = 1 << 13;

        /// <summary>
        ///     The sdl haptic status
        /// </summary>
        public const ushort SdlHapticStatus = 1 << 14;

        /// <summary>
        ///     The sdl haptic pause
        /// </summary>
        public const ushort SdlHapticPause = 1 << 15;


        /// <summary>
        ///     The sdl haptic polar
        /// </summary>
        public const byte SdlHapticPolar = 0;

        /// <summary>
        ///     The sdl haptic cartesian
        /// </summary>
        public const byte SdlHapticCartesian = 1;

        /// <summary>
        ///     The sdl haptic spherical
        /// </summary>
        public const byte SdlHapticSpherical = 2;

        /// <summary>
        ///     The sdl haptic steering axis
        /// </summary>
        public const byte SdlHapticSteeringAxis = 3;


        /// <summary>
        ///     The sdl haptic infinity
        /// </summary>
        public const uint SdlHapticInfinity = 4294967295U;

        /// <summary>
        ///     The sdl standard gravity
        /// </summary>
        public const float SdlStandardGravity = 9.80665f;

        /// <summary>
        ///     The sdl audio mask bit size
        /// </summary>
        private const ushort SdlAudioMaskBitSize = 0xFF;

        /// <summary>
        ///     The sdl audio mask datatype
        /// </summary>
        private const ushort SdlAudioMaskDatatype = 1 << 8;

        /// <summary>
        ///     The sdl audio mask endian
        /// </summary>
        private const ushort SdlAudioMaskEndian = 1 << 12;

        /// <summary>
        ///     The sdl audio mask signed
        /// </summary>
        private const ushort SdlAudioMaskSigned = 1 << 15;

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
        private const uint SdlAudioAllowFrequencyChange = 0x00000001;

        /// <summary>
        ///     The sdl audio allow format change
        /// </summary>
        private const uint SdlAudioAllowFormatChange = 0x00000002;

        /// <summary>
        ///     The sdl audio allow channels change
        /// </summary>
        private const uint SdlAudioAllowChannelsChange = 0x00000004;

        /// <summary>
        ///     The sdl audio allow samples change
        /// </summary>
        private const uint SdlAudioAllowSamplesChange = 0x00000008;

        /// <summary>
        ///     The sdl audio allow samples change
        /// </summary>
        public const uint SdlAudioAllowAnyChange = SdlAudioAllowFrequencyChange |
                                                   SdlAudioAllowFormatChange |
                                                   SdlAudioAllowChannelsChange |
                                                   SdlAudioAllowSamplesChange;

        /// <summary>
        ///     The sdl mix max volume
        /// </summary>
        public const int SdlMixMaxVolume = 128;


        /// <summary>
        ///     The sdl android external storage read
        /// </summary>
        public const int SdlAndroidExternalStorageRead = 0x01;

        /// <summary>
        ///     The sdl android external storage write
        /// </summary>
        public const int SdlAndroidExternalStorageWrite = 0x02;

        /// <summary>
        ///     The sdl patch level
        /// </summary>
        private static readonly int SdlCompiledVersion = SdlVersionNum(
            SdlMajorVersion,
            SdlMinorVersion,
            SdlPatchLevel
        );

        /// <summary>
        ///     The sdl pixel format unknown
        /// </summary>
        public static readonly uint SdlPixelFormatUnknown = 0;

        /// <summary>
        ///     The sdl bit map order 4321
        /// </summary>
        public static readonly uint SdlPixelFormatIndex1Lsb =
            SdlDefinePixelFormat(
                Enums.SdlPixelType.SdlPixeltypeIndex1,
                (uint) SdlBitmapOrder.SdlBitMapOrder4321,
                0,
                1, 0
            );

        /// <summary>
        ///     The sdl bit map order 1234
        /// </summary>
        public static readonly uint SdlPixelFormatIndex1Msb =
            SdlDefinePixelFormat(
                Enums.SdlPixelType.SdlPixeltypeIndex1,
                (uint) SdlBitmapOrder.SdlBitMapOrder1234,
                0,
                1, 0
            );

        /// <summary>
        ///     The sdl bit map order 4321
        /// </summary>
        public static readonly uint SdlPixelFormatIndex4Lsb =
            SdlDefinePixelFormat(
                Enums.SdlPixelType.SdlPixeltypeIndex4,
                (uint) SdlBitmapOrder.SdlBitMapOrder4321,
                0,
                4, 0
            );

        /// <summary>
        ///     The sdl bit map order 1234
        /// </summary>
        public static readonly uint SdlPixelFormatIndex4Msb =
            SdlDefinePixelFormat(
                Enums.SdlPixelType.SdlPixeltypeIndex4,
                (uint) SdlBitmapOrder.SdlBitMapOrder1234,
                0,
                4, 0
            );

        /// <summary>
        ///     The sdl pixel type index8
        /// </summary>
        public static readonly uint SdlPixelFormatIndex8 =
            SdlDefinePixelFormat(
                Enums.SdlPixelType.SdlPixeltypeIndex8,
                0,
                0,
                8, 1
            );

        /// <summary>
        ///     The sdl packed layout 332
        /// </summary>
        public static readonly uint SdlPixelFormatRgb332 =
            SdlDefinePixelFormat(
                Enums.SdlPixelType.SdlPixeltypePacked8,
                (uint) SdlPackedOrder.SdlPackedorderXrgb,
                SdlPackedLayout.SdlPackedlayout332,
                8, 1
            );

        /// <summary>
        ///     The sdl packed layout 4444
        /// </summary>
        private static readonly uint SdlPixelFormatXRgb444 =
            SdlDefinePixelFormat(
                Enums.SdlPixelType.SdlPixeltypePacked16,
                (uint) SdlPackedOrder.SdlPackedorderXrgb,
                SdlPackedLayout.SdlPackedlayout4444,
                12, 2
            );

        /// <summary>
        ///     The sdl pixel format x rgb 444
        /// </summary>
        public static readonly uint SdlPixelFormatRgb444 =
            SdlPixelFormatXRgb444;

        /// <summary>
        ///     The sdl packed layout 4444
        /// </summary>
        private static readonly uint SdlPixelFormatXBgr444 =
            SdlDefinePixelFormat(
                Enums.SdlPixelType.SdlPixeltypePacked16,
                (uint) SdlPackedOrder.SdlPackedorderXbgr,
                SdlPackedLayout.SdlPackedlayout4444,
                12, 2
            );

        /// <summary>
        ///     The sdl pixel format x bgr 444
        /// </summary>
        public static readonly uint SdlPixelFormatBgr444 =
            SdlPixelFormatXBgr444;

        /// <summary>
        ///     The sdl packed layout 1555
        /// </summary>
        private static readonly uint SdlPixelFormatXRgb1555 =
            SdlDefinePixelFormat(
                Enums.SdlPixelType.SdlPixeltypePacked16,
                (uint) SdlPackedOrder.SdlPackedorderXrgb,
                SdlPackedLayout.SdlPackedlayout1555,
                15, 2
            );

        /// <summary>
        ///     The sdl pixel format xrgb1555
        /// </summary>
        public static readonly uint SdlPixelFormatRgb555 =
            SdlPixelFormatXRgb1555;

        /// <summary>
        ///     The sdl packed layout 1555
        /// </summary>
        private static readonly uint SdlPixelFormatXBgr1555 =
            SdlDefinePixelFormat(
                Enums.SdlPixelType.SdlPixeltypeIndex1,
                (uint) SdlBitmapOrder.SdlBitMapOrder4321,
                SdlPackedLayout.SdlPackedlayout1555,
                15, 2
            );

        /// <summary>
        ///     The sdl pixel format xbgr1555
        /// </summary>
        public static readonly uint SdlPixelFormatBgr555 =
            SdlPixelFormatXBgr1555;

        /// <summary>
        ///     The sdl packed layout 4444
        /// </summary>
        public static readonly uint SdlPixelFormatArgb4444 =
            SdlDefinePixelFormat(
                Enums.SdlPixelType.SdlPixeltypePacked16,
                (uint) SdlPackedOrder.SdlPackedorderArgb,
                SdlPackedLayout.SdlPackedlayout4444,
                16, 2
            );

        /// <summary>
        ///     The sdl packed layout 4444
        /// </summary>
        public static readonly uint SdlPixelFormatRgba4444 =
            SdlDefinePixelFormat(
                Enums.SdlPixelType.SdlPixeltypePacked16,
                (uint) SdlPackedOrder.SdlPackedorderRgba,
                SdlPackedLayout.SdlPackedlayout4444,
                16, 2
            );

        /// <summary>
        ///     The sdl packed layout 4444
        /// </summary>
        public static readonly uint SdlPixelFormatABgr4444 =
            SdlDefinePixelFormat(
                Enums.SdlPixelType.SdlPixeltypePacked16,
                (uint) SdlPackedOrder.SdlPackedorderAbgr,
                SdlPackedLayout.SdlPackedlayout4444,
                16, 2
            );

        /// <summary>
        ///     The sdl packed layout 4444
        /// </summary>
        public static readonly uint SdlPixelFormatBGra4444 =
            SdlDefinePixelFormat(
                Enums.SdlPixelType.SdlPixeltypePacked16,
                (uint) SdlPackedOrder.SdlPackedorderBgra,
                SdlPackedLayout.SdlPackedlayout4444,
                16, 2
            );

        /// <summary>
        ///     The sdl packed layout 1555
        /// </summary>
        public static readonly uint SdlPixelFormatArgb1555 =
            SdlDefinePixelFormat(
                Enums.SdlPixelType.SdlPixeltypePacked16,
                (uint) SdlPackedOrder.SdlPackedorderArgb,
                SdlPackedLayout.SdlPackedlayout1555,
                16, 2
            );

        /// <summary>
        ///     The sdl packed layout 5551
        /// </summary>
        public static readonly uint SdlPixelFormatRgba5551 =
            SdlDefinePixelFormat(
                Enums.SdlPixelType.SdlPixeltypePacked16,
                (uint) SdlPackedOrder.SdlPackedorderRgba,
                SdlPackedLayout.SdlPackedlayout5551,
                16, 2
            );

        /// <summary>
        ///     The sdl packed layout 1555
        /// </summary>
        public static readonly uint SdlPixelFormatABgr1555 =
            SdlDefinePixelFormat(
                Enums.SdlPixelType.SdlPixeltypePacked16,
                (uint) SdlPackedOrder.SdlPackedorderAbgr,
                SdlPackedLayout.SdlPackedlayout1555,
                16, 2
            );

        /// <summary>
        ///     The sdl packed layout 5551
        /// </summary>
        public static readonly uint SdlPixelFormatBGra5551 =
            SdlDefinePixelFormat(
                Enums.SdlPixelType.SdlPixeltypePacked16,
                (uint) SdlPackedOrder.SdlPackedorderBgra,
                SdlPackedLayout.SdlPackedlayout5551,
                16, 2
            );

        /// <summary>
        ///     The sdl packed layout 565
        /// </summary>
        public static readonly uint SdlPixelFormatRgb565 =
            SdlDefinePixelFormat(
                Enums.SdlPixelType.SdlPixeltypePacked16,
                (uint) SdlPackedOrder.SdlPackedorderXrgb,
                SdlPackedLayout.SdlPackedlayout565,
                16, 2
            );

        /// <summary>
        ///     The sdl packed layout 565
        /// </summary>
        public static readonly uint SdlPixelFormatBgr565 =
            SdlDefinePixelFormat(
                Enums.SdlPixelType.SdlPixeltypePacked16,
                (uint) SdlPackedOrder.SdlPackedorderXbgr,
                SdlPackedLayout.SdlPackedlayout565,
                16, 2
            );

        /// <summary>
        ///     The sdl array order rgb
        /// </summary>
        public static readonly uint SdlPixelFormatRgb24 =
            SdlDefinePixelFormat(
                Enums.SdlPixelType.SdlPixeltypeArrayu8,
                (uint) SdlArrayOrder.SdlArrayorderRgb,
                0,
                24, 3
            );

        /// <summary>
        ///     The sdl array order bgr
        /// </summary>
        public static readonly uint SdlPixelFormatBgr24 =
            SdlDefinePixelFormat(
                Enums.SdlPixelType.SdlPixeltypeArrayu8,
                (uint) SdlArrayOrder.SdlArrayorderBgr,
                0,
                24, 3
            );

        /// <summary>
        ///     The sdl packed layout 8888
        /// </summary>
        private static readonly uint SdlPixelFormatXRgb888 =
            SdlDefinePixelFormat(
                Enums.SdlPixelType.SdlPixeltypePacked32,
                (uint) SdlPackedOrder.SdlPackedorderXrgb,
                SdlPackedLayout.SdlPackedlayout8888,
                24, 4
            );

        /// <summary>
        ///     The sdl pixel format x rgb 888
        /// </summary>
        public static readonly uint SdlPixelFormatRgb888 =
            SdlPixelFormatXRgb888;

        /// <summary>
        ///     The sdl packed layout 8888
        /// </summary>
        public static readonly uint SdlPixelFormatRgbX8888 =
            SdlDefinePixelFormat(
                Enums.SdlPixelType.SdlPixeltypePacked32,
                (uint) SdlPackedOrder.SdlPackedorderRgbx,
                SdlPackedLayout.SdlPackedlayout8888,
                24, 4
            );

        /// <summary>
        ///     The sdl packed layout 8888
        /// </summary>
        private static readonly uint SdlPixelFormatXBgr888 =
            SdlDefinePixelFormat(
                Enums.SdlPixelType.SdlPixeltypePacked32,
                (uint) SdlPackedOrder.SdlPackedorderXbgr,
                SdlPackedLayout.SdlPackedlayout8888,
                24, 4
            );

        /// <summary>
        ///     The sdl pixel format x bgr 888
        /// </summary>
        public static readonly uint SdlPixelFormatBgr888 =
            SdlPixelFormatXBgr888;

        /// <summary>
        ///     The sdl packed layout 8888
        /// </summary>
        public static readonly uint SdlPixelFormatBGrx8888 =
            SdlDefinePixelFormat(
                Enums.SdlPixelType.SdlPixeltypePacked32,
                (uint) SdlPackedOrder.SdlPackedorderBgrx,
                SdlPackedLayout.SdlPackedlayout8888,
                24, 4
            );

        /// <summary>
        ///     The sdl packed layout 8888
        /// </summary>
        public static readonly uint SdlPixelFormatArgb8888 =
            SdlDefinePixelFormat(
                Enums.SdlPixelType.SdlPixeltypePacked32,
                (uint) SdlPackedOrder.SdlPackedorderArgb,
                SdlPackedLayout.SdlPackedlayout8888,
                32, 4
            );

        /// <summary>
        ///     The sdl packed layout 8888
        /// </summary>
        public static readonly uint SdlPixelFormatRgba8888 =
            SdlDefinePixelFormat(
                Enums.SdlPixelType.SdlPixeltypePacked32,
                (uint) SdlPackedOrder.SdlPackedorderRgba,
                SdlPackedLayout.SdlPackedlayout8888,
                32, 4
            );

        /// <summary>
        ///     The sdl packed layout 8888
        /// </summary>
        public static readonly uint SdlPixelFormatABgr8888 =
            SdlDefinePixelFormat(
                Enums.SdlPixelType.SdlPixeltypePacked32,
                (uint) SdlPackedOrder.SdlPackedorderAbgr,
                SdlPackedLayout.SdlPackedlayout8888,
                32, 4
            );

        /// <summary>
        ///     The sdl packed layout 8888
        /// </summary>
        public static readonly uint SdlPixelFormatB8888 =
            SdlDefinePixelFormat(
                Enums.SdlPixelType.SdlPixeltypePacked32,
                (uint) SdlPackedOrder.SdlPackedorderBgra,
                SdlPackedLayout.SdlPackedlayout8888,
                32, 4
            );

        /// <summary>
        ///     The sdl packed layout 2101010
        /// </summary>
        public static readonly uint SdlPixelFormatArgb2101010 = SdlDefinePixelFormat(Enums.SdlPixelType.SdlPixeltypePacked32, (uint) SdlPackedOrder.SdlPackedorderArgb, SdlPackedLayout.SdlPackedlayout2101010, 32, 4);

        /// <summary>
        ///     The sdl define pixel four cc
        /// </summary>
        public static readonly uint SdlPixelFormatYv12 = SdlDefinePixelFourcc((byte) 'Y', (byte) 'V', (byte) '1', (byte) '2');

        /// <summary>
        ///     The sdl define pixel four cc
        /// </summary>
        public static readonly uint SdlPixelFormatIy = SdlDefinePixelFourcc((byte) 'I', (byte) 'Y', (byte) 'U', (byte) 'V');

        /// <summary>
        ///     The sdl define pixel four
        /// </summary>
        private static readonly uint SdlPixelFormatYuy2 = SdlDefinePixelFourcc((byte) 'Y', (byte) 'U', (byte) 'Y', (byte) '2');

        /// <summary>
        ///     The sdl define pixel four 
        /// </summary>
        private static readonly uint SdlPixelFormatUy = SdlDefinePixelFourcc((byte) 'U', (byte) 'Y', (byte) 'V', (byte) 'Y');

        /// <summary>
        ///     The sdl define pixel four
        /// </summary>
        private static readonly uint SdlPixelFormatYv = SdlDefinePixelFourcc((byte) 'Y', (byte) 'V', (byte) 'Y', (byte) 'U');

        /// <summary>
        ///     The sdl button left
        /// </summary>
        public static readonly uint SdlButtonLMask = SDL_BUTTON(SdlButtonLeft);

        /// <summary>
        ///     The sdl button middle
        /// </summary>
        public static readonly uint SdlButtonMMask = SDL_BUTTON(SdlButtonMiddle);

        /// <summary>
        ///     The sdl button right
        /// </summary>
        public static readonly uint SdlButtonRMask = SDL_BUTTON(SdlButtonRight);

        /// <summary>
        ///     The sdl button x1
        /// </summary>
        public static readonly uint SdlButtonX1Mask = SDL_BUTTON(SdlButtonX1);

        /// <summary>
        ///     The sdl button x2
        /// </summary>
        public static readonly uint SdlButtonX2Mask = SDL_BUTTON(SdlButtonX2);

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
        ///     Utf the 8 size using the specified str
        /// </summary>
        /// <param name="str">The str</param>
        /// <returns>The int</returns>
        [return: NotNull]
        internal static int Utf8Size([NotNull] string str) => str.Validate().Length * 4 + 1;

        /// <summary>
        ///     Utf the 8 encode using the specified str
        /// </summary>
        /// <param name="str">The str</param>
        /// <param name="buffer">The buffer</param>
        /// <param name="bufferSize">The buffer size</param>
        /// <returns>The buffer</returns>
        [return: NotNull]
        internal static byte[] Utf8Encode([NotNull]string str, [NotNull] byte[] buffer, [NotNull] int bufferSize)
        {
            Encoding.UTF8.GetBytes(str.Validate(), 0, str.Validate().Length, buffer, 0);
            buffer[str.Length] = 0;
            return buffer;
        }
        
        /// <summary>
        ///     Utf the 8 encode heap using the specified str
        /// </summary>
        /// <param name="str">The str</param>
        /// <returns>The buffer</returns>
        internal static byte[] Utf8EncodeHeap(string str)
        {
            if (str == null)
            {
                return null;
            }

            int bufferSize = Encoding.UTF8.GetByteCount(str) + 1;
            byte[] buffer = new byte[bufferSize];
            Encoding.UTF8.GetBytes(str, 0, str.Length, buffer, 0);
            buffer[bufferSize - 1] = 0; // Null-terminate the string

            return buffer;
        }


        /// <summary>
        ///     Utf the 8 to managed using the specified s
        /// </summary>
        /// <param name="s">The </param>
        /// <param name="freePtr">The free ptr</param>
        /// <returns>The result</returns>
        public static string Utf8ToManaged(IntPtr s, bool freePtr = false)
        {
            if (s == IntPtr.Zero)
            {
                return null;
            }

            int len = 0;
            while (Marshal.ReadByte(s, len) != 0)
            {
                len++;
            }

            if (len == 0)
            {
                return string.Empty;
            }

            byte[] bytes = new byte[len];
            Marshal.Copy(s, bytes, 0, len);
            string result = Encoding.UTF8.GetString(bytes);

            if (freePtr)
            {
                SDL_free(s);
            }

            return result;
        }


        /// <summary>
        ///     Sdl the fourcc using the specified a
        /// </summary>
        /// <param name="a">The </param>
        /// <param name="b">The </param>
        /// <param name="c">The </param>
        /// <param name="d">The </param>
        /// <returns>The uint</returns>
        private static uint SDL_FOURCC(byte a, byte b, byte c, byte d) => (uint) (a | (b << 8) | (c << 16) | (d << 24));

        /// <summary>
        ///     Sdl the malloc using the specified size
        /// </summary>
        /// <param name="size">The size</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr SDL_malloc(int size);

        /// <summary>
        ///     Sdl the free using the specified mem block
        /// </summary>
        /// <param name="memBlock">The mem block</param>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        private static extern void SDL_free(IntPtr memBlock);
        
        /// <summary>
        ///     Sdl the mem cpy using the specified dst
        /// </summary>
        /// <param name="dst">The dst</param>
        /// <param name="src">The src</param>
        /// <param name="len">The len</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr SDL_memCpy(IntPtr dst, IntPtr src, IntPtr len);


        /// <summary>
        ///     Internals the sdl rw from file using the specified file
        /// </summary>
        /// <param name="file">The file</param>
        /// <param name="mode">The mode</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_RWFromFile", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr INTERNAL_SDL_RWFromFile(
            byte[] file,
            byte[] mode
        );

        /// <summary>
        ///     Sdl the rw from file using the specified file
        /// </summary>
        /// <param name="file">The file</param>
        /// <param name="mode">The mode</param>
        /// <returns>The rw ops</returns>
        private static IntPtr SDL_RWFromFile(
            string file,
            string mode
        )
        {
            byte[] utf8File = Utf8EncodeHeap(file);
            byte[] utf8Mode = Utf8EncodeHeap(mode);
            IntPtr rwOps = INTERNAL_SDL_RWFromFile(
                utf8File,
                utf8Mode
            );
            return rwOps;
        }


        /// <summary>
        ///     Sdl the alloc rw
        /// </summary>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr SDL_AllocRW();


        /// <summary>
        ///     Sdl the free rw using the specified area
        /// </summary>
        /// <param name="area">The area</param>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_FreeRW(IntPtr area);


        /// <summary>
        ///     Sdl the rw from fp using the specified fp
        /// </summary>
        /// <param name="fp">The fp</param>
        /// <param name="autoClose">The auto close</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr SDL_RWFromFP(IntPtr fp, SdlBool autoClose);


        /// <summary>
        ///     Sdl the rw from mem using the specified mem
        /// </summary>
        /// <param name="mem">The mem</param>
        /// <param name="size">The size</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr SDL_RWFromMem(IntPtr mem, int size);


        /// <summary>
        ///     Sdl the rw from const mem using the specified mem
        /// </summary>
        /// <param name="mem">The mem</param>
        /// <param name="size">The size</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr SDL_RWFromConstMem(IntPtr mem, int size);


        /// <summary>
        ///     Sdl the r w size using the specified context
        /// </summary>
        /// <param name="context">The context</param>
        /// <returns>The long</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern long SDL_RwSize(IntPtr context);

        /// <summary>
        ///     Sdl the r w seek using the specified context
        /// </summary>
        /// <param name="context">The context</param>
        /// <param name="offset">The offset</param>
        /// <param name="whence">The whence</param>
        /// <returns>The long</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern long SDL_RwSeek(
            IntPtr context,
            long offset,
            int whence
        );

        /// <summary>
        ///     Sdl the r w tell using the specified context
        /// </summary>
        /// <param name="context">The context</param>
        /// <returns>The long</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern long SDL_RwTell(IntPtr context);


        /// <summary>
        ///     Sdl the r w read using the specified context
        /// </summary>
        /// <param name="context">The context</param>
        /// <param name="ptr">The ptr</param>
        /// <param name="size">The size</param>
        /// <param name="maxNum">The max num</param>
        /// <returns>The long</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern long SDL_RwRead(
            IntPtr context,
            IntPtr ptr,
            IntPtr size,
            IntPtr maxNum
        );


        /// <summary>
        ///     Sdl the r w write using the specified context
        /// </summary>
        /// <param name="context">The context</param>
        /// <param name="ptr">The ptr</param>
        /// <param name="size">The size</param>
        /// <param name="maxNum">The max num</param>
        /// <returns>The long</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern long SDL_RwWrite(
            IntPtr context,
            IntPtr ptr,
            IntPtr size,
            IntPtr maxNum
        );


        /// <summary>
        ///     Sdl the read u 8 using the specified src
        /// </summary>
        /// <param name="src">The src</param>
        /// <returns>The byte</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern byte SDL_ReadU8(IntPtr src);

        /// <summary>
        ///     Sdl the read le 16 using the specified src
        /// </summary>
        /// <param name="src">The src</param>
        /// <returns>The int 16</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern ushort SDL_ReadLE16(IntPtr src);

        /// <summary>
        ///     Sdl the read be 16 using the specified src
        /// </summary>
        /// <param name="src">The src</param>
        /// <returns>The int 16</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern ushort SDL_ReadBE16(IntPtr src);

        /// <summary>
        ///     Sdl the read le 32 using the specified src
        /// </summary>
        /// <param name="src">The src</param>
        /// <returns>The int 32</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern uint SDL_ReadLE32(IntPtr src);

        /// <summary>
        ///     Sdl the read be 32 using the specified src
        /// </summary>
        /// <param name="src">The src</param>
        /// <returns>The int 32</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern uint SDL_ReadBE32(IntPtr src);

        /// <summary>
        ///     Sdl the read le 64 using the specified src
        /// </summary>
        /// <param name="src">The src</param>
        /// <returns>The int 64</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern ulong SDL_ReadLE64(IntPtr src);

        /// <summary>
        ///     Sdl the read be 64 using the specified src
        /// </summary>
        /// <param name="src">The src</param>
        /// <returns>The int 64</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern ulong SDL_ReadBE64(IntPtr src);

        /// <summary>
        ///     Sdl the write u 8 using the specified dst
        /// </summary>
        /// <param name="dst">The dst</param>
        /// <param name="value">The value</param>
        /// <returns>The uint</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern uint SDL_WriteU8(IntPtr dst, byte value);

        /// <summary>
        ///     Sdl the write le 16 using the specified dst
        /// </summary>
        /// <param name="dst">The dst</param>
        /// <param name="value">The value</param>
        /// <returns>The uint</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern uint SDL_WriteLE16(IntPtr dst, ushort value);

        /// <summary>
        ///     Sdl the write be 16 using the specified dst
        /// </summary>
        /// <param name="dst">The dst</param>
        /// <param name="value">The value</param>
        /// <returns>The uint</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern uint SDL_WriteBE16(IntPtr dst, ushort value);

        /// <summary>
        ///     Sdl the write le 32 using the specified dst
        /// </summary>
        /// <param name="dst">The dst</param>
        /// <param name="value">The value</param>
        /// <returns>The uint</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern uint SDL_WriteLE32(IntPtr dst, uint value);

        /// <summary>
        ///     Sdl the write be 32 using the specified dst
        /// </summary>
        /// <param name="dst">The dst</param>
        /// <param name="value">The value</param>
        /// <returns>The uint</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern uint SDL_WriteBE32(IntPtr dst, uint value);

        /// <summary>
        ///     Sdl the write le 64 using the specified dst
        /// </summary>
        /// <param name="dst">The dst</param>
        /// <param name="value">The value</param>
        /// <returns>The uint</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern uint SDL_WriteLE64(IntPtr dst, ulong value);

        /// <summary>
        ///     Sdl the write be 64 using the specified dst
        /// </summary>
        /// <param name="dst">The dst</param>
        /// <param name="value">The value</param>
        /// <returns>The uint</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern uint SDL_WriteBE64(IntPtr dst, ulong value);


        /// <summary>
        ///     Sdl the r w close using the specified context
        /// </summary>
        /// <param name="context">The context</param>
        /// <returns>The long</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern long SDL_RwClose(IntPtr context);

        /// <summary>
        ///     Internals the sdl load file using the specified file
        /// </summary>
        /// <param name="file">The file</param>
        /// <param name="dataSize">The data size</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_LoadFile", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr INTERNAL_SDL_LoadFile(byte[] file, out IntPtr dataSize);

        /// <summary>
        ///     Sdl the load file using the specified file
        /// </summary>
        /// <param name="file">The file</param>
        /// <param name="dataSize">The data size</param>
        /// <returns>The result</returns>
        public static IntPtr SDL_LoadFile(string file, out IntPtr dataSize)
        {
            byte[] utf8File = Utf8EncodeHeap(file);
            IntPtr result = INTERNAL_SDL_LoadFile(utf8File, out dataSize);
            return result;
        }

        /// <summary>
        ///     Sdl the set main ready
        /// </summary>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_SetMainReady();


        /// <summary>
        ///     Sdl the win rt run app using the specified main function
        /// </summary>
        /// <param name="mainFunction">The main function</param>
        /// <param name="reserved">The reserved</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_WinRTRunApp(
            SdlMainFunc mainFunction,
            IntPtr reserved
        );

        /// <summary>
        ///     Sdl the ui kit run app using the specified argc
        /// </summary>
        /// <param name="argc">The argc</param>
        /// <param name="argv">The argv</param>
        /// <param name="mainFunction">The main function</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_UIKitRunApp(
            int argc,
            IntPtr argv,
            SdlMainFunc mainFunction
        );

        /// <summary>
        ///     Sdl the init using the specified flags
        /// </summary>
        /// <param name="flags">The flags</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_Init(uint flags);

        /// <summary>
        ///     Sdl the init sub system using the specified flags
        /// </summary>
        /// <param name="flags">The flags</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_InitSubSystem(uint flags);

        /// <summary>
        ///     Sdl the quit
        /// </summary>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_Quit();

        /// <summary>
        ///     Sdl the quit sub system using the specified flags
        /// </summary>
        /// <param name="flags">The flags</param>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_QuitSubSystem(uint flags);

        /// <summary>
        ///     Sdl the was init using the specified flags
        /// </summary>
        /// <param name="flags">The flags</param>
        /// <returns>The uint</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern uint SDL_WasInit(uint flags);

        /// <summary>
        ///     Internals the sdl get platform
        /// </summary>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GetPlatform", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr INTERNAL_SDL_GetPlatform();

        /// <summary>
        ///     Sdl the get platform
        /// </summary>
        /// <returns>The string</returns>
        public static string SDL_GetPlatform() => Utf8ToManaged(INTERNAL_SDL_GetPlatform());

        /// <summary>
        ///     Sdl the clear hints
        /// </summary>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_ClearHints();

        /// <summary>
        ///     Internals the sdl get hint using the specified name
        /// </summary>
        /// <param name="name">The name</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GetHint", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr INTERNAL_SDL_GetHint(byte[] name);

        /// <summary>
        ///     Sdl the get hint using the specified name
        /// </summary>
        /// <param name="name">The name</param>
        /// <returns>The string</returns>
        public static string SDL_GetHint(string name)
        {
            int utf8NameBufSize = Utf8Size(name);
            byte[] utf8Name = new byte[utf8NameBufSize];
            return Utf8ToManaged(
                INTERNAL_SDL_GetHint(
                    Utf8Encode(name, utf8Name, utf8NameBufSize)
                )
            );
        }

        /// <summary>
        ///     Internals the sdl set hint using the specified name
        /// </summary>
        /// <param name="name">The name</param>
        /// <param name="value">The value</param>
        /// <returns>The sdl bool</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_SetHint", CallingConvention = CallingConvention.Cdecl)]
        private static extern SdlBool INTERNAL_SDL_SetHint(
            byte[] name,
            byte[] value
        );

        /// <summary>
        ///     Sdl the set hint using the specified name
        /// </summary>
        /// <param name="name">The name</param>
        /// <param name="value">The value</param>
        /// <returns>The sdl bool</returns>
        public static SdlBool SDL_SetHint(string name, string value)
        {
            int utf8NameBufSize = Utf8Size(name);
            byte[] utf8Name = new byte[utf8NameBufSize];

            int utf8ValueBufSize = Utf8Size(value);
            byte[] utf8Value = new byte[utf8ValueBufSize];

            return INTERNAL_SDL_SetHint(
                Utf8Encode(name, utf8Name, utf8NameBufSize),
                Utf8Encode(value, utf8Value, utf8ValueBufSize)
            );
        }

        /// <summary>
        ///     Internals the sdl set hint with priority using the specified name
        /// </summary>
        /// <param name="name">The name</param>
        /// <param name="value">The value</param>
        /// <param name="priority">The priority</param>
        /// <returns>The sdl bool</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_SetHintWithPriority", CallingConvention = CallingConvention.Cdecl)]
        private static extern SdlBool INTERNAL_SDL_SetHintWithPriority(
            byte[] name,
            byte[] value,
            SdlHintPriority priority
        );

        /// <summary>
        ///     Sdl the set hint with priority using the specified name
        /// </summary>
        /// <param name="name">The name</param>
        /// <param name="value">The value</param>
        /// <param name="priority">The priority</param>
        /// <returns>The sdl bool</returns>
        public static SdlBool SDL_SetHintWithPriority(
            string name,
            string value,
            SdlHintPriority priority
        )
        {
            int utf8NameBufSize = Utf8Size(name);
            byte[] utf8Name = new byte[utf8NameBufSize];

            int utf8ValueBufSize = Utf8Size(value);
            byte[] utf8Value = new byte[utf8ValueBufSize];

            return INTERNAL_SDL_SetHintWithPriority(
                Utf8Encode(name, utf8Name, utf8NameBufSize),
                Utf8Encode(value, utf8Value, utf8ValueBufSize),
                priority
            );
        }


        /// <summary>
        ///     Internals the sdl get hint boolean using the specified name
        /// </summary>
        /// <param name="name">The name</param>
        /// <param name="defaultValue">The default value</param>
        /// <returns>The sdl bool</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GetHintBoolean", CallingConvention = CallingConvention.Cdecl)]
        private static extern SdlBool INTERNAL_SDL_GetHintBoolean(
            byte[] name,
            SdlBool defaultValue
        );

        /// <summary>
        ///     Sdl the get hint boolean using the specified name
        /// </summary>
        /// <param name="name">The name</param>
        /// <param name="defaultValue">The default value</param>
        /// <returns>The sdl bool</returns>
        public static SdlBool SDL_GetHintBoolean(
            string name,
            SdlBool defaultValue
        )
        {
            int utf8NameBufSize = Utf8Size(name);
            byte[] utf8Name = new byte[utf8NameBufSize];
            return INTERNAL_SDL_GetHintBoolean(
                Utf8Encode(name, utf8Name, utf8NameBufSize),
                defaultValue
            );
        }

        /// <summary>
        ///     Sdl the clear error
        /// </summary>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_ClearError();

        /// <summary>
        ///     Internals the sdl get error
        /// </summary>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GetError", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr INTERNAL_SDL_GetError();

        /// <summary>
        ///     Sdl the get error
        /// </summary>
        /// <returns>The string</returns>
        public static string SDL_GetError() => Utf8ToManaged(INTERNAL_SDL_GetError());


        /// <summary>
        ///     Internals the sdl set error using the specified fmt and arg list
        /// </summary>
        /// <param name="fmtAndArgList">The fmt and arg list</param>
        [DllImport(NativeLibName, EntryPoint = "SDL_SetError", CallingConvention = CallingConvention.Cdecl)]
        private static extern void INTERNAL_SDL_SetError(byte[] fmtAndArgList);

        /// <summary>
        ///     Sdl the set error using the specified fmt and arg list
        /// </summary>
        /// <param name="fmtAndArgList">The fmt and arg list</param>
        public static void SDL_SetError(string fmtAndArgList)
        {
            INTERNAL_SDL_SetError(
                Utf8Encode(fmtAndArgList, new byte[Utf8Size(fmtAndArgList)], Utf8Size(fmtAndArgList))
            );
        }


        /// <summary>
        ///     Sdl the get error msg using the specified err str
        /// </summary>
        /// <param name="errStr">The err str</param>
        /// <param name="maxlength">The maxlength</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr SDL_GetErrorMsg(IntPtr errStr, int maxlength);


        /// <summary>
        ///     Internals the sdl log using the specified fmt and arg list
        /// </summary>
        /// <param name="fmtAndArgList">The fmt and arg list</param>
        [DllImport(NativeLibName, EntryPoint = "SDL_Log", CallingConvention = CallingConvention.Cdecl)]
        private static extern void INTERNAL_SDL_Log(byte[] fmtAndArgList);

        /// <summary>
        ///     Sdl the log using the specified fmt and arg list
        /// </summary>
        /// <param name="fmtAndArgList">The fmt and arg list</param>
        public static void SDL_Log(string fmtAndArgList)
        {
            INTERNAL_SDL_Log(
                Utf8Encode(fmtAndArgList, new byte[Utf8Size(fmtAndArgList)], Utf8Size(fmtAndArgList))
            );
        }


        /// <summary>
        ///     Internals the sdl log verbose using the specified category
        /// </summary>
        /// <param name="category">The category</param>
        /// <param name="fmtAndArgList">The fmt and arg list</param>
        [DllImport(NativeLibName, EntryPoint = "SDL_LogVerbose", CallingConvention = CallingConvention.Cdecl)]
        private static extern void INTERNAL_SDL_LogVerbose(
            int category,
            byte[] fmtAndArgList
        );

        /// <summary>
        ///     Sdl the log verbose using the specified category
        /// </summary>
        /// <param name="category">The category</param>
        /// <param name="fmtAndArgList">The fmt and arg list</param>
        public static void SDL_LogVerbose(
            int category,
            string fmtAndArgList
        )
        {
            int utf8FmtAndArgListBufSize = Utf8Size(fmtAndArgList);
            byte[] utf8FmtAndArgList = new byte[utf8FmtAndArgListBufSize];
            INTERNAL_SDL_LogVerbose(
                category,
                Utf8Encode(fmtAndArgList, utf8FmtAndArgList, utf8FmtAndArgListBufSize)
            );
        }


        /// <summary>
        ///     Internals the sdl log debug using the specified category
        /// </summary>
        /// <param name="category">The category</param>
        /// <param name="fmtAndArgList">The fmt and arg list</param>
        [DllImport(NativeLibName, EntryPoint = "SDL_LogDebug", CallingConvention = CallingConvention.Cdecl)]
        private static extern void INTERNAL_SDL_LogDebug(
            int category,
            byte[] fmtAndArgList
        );

        /// <summary>
        ///     Sdl the log debug using the specified category
        /// </summary>
        /// <param name="category">The category</param>
        /// <param name="fmtAndArgList">The fmt and arg list</param>
        public static void SDL_LogDebug(
            int category,
            string fmtAndArgList
        )
        {
            int utf8FmtAndArgListBufSize = Utf8Size(fmtAndArgList);
            byte[] utf8FmtAndArgList = new byte[utf8FmtAndArgListBufSize];
            INTERNAL_SDL_LogDebug(
                category,
                Utf8Encode(fmtAndArgList, utf8FmtAndArgList, utf8FmtAndArgListBufSize)
            );
        }


        /// <summary>
        ///     Internals the sdl log info using the specified category
        /// </summary>
        /// <param name="category">The category</param>
        /// <param name="fmtAndArgList">The fmt and arg list</param>
        [DllImport(NativeLibName, EntryPoint = "SDL_LogInfo", CallingConvention = CallingConvention.Cdecl)]
        private static extern void INTERNAL_SDL_LogInfo(
            int category,
            byte[] fmtAndArgList
        );

        /// <summary>
        ///     Sdl the log info using the specified category
        /// </summary>
        /// <param name="category">The category</param>
        /// <param name="fmtAndArgList">The fmt and arg list</param>
        public static void SDL_LogInfo(
            int category,
            string fmtAndArgList
        )
        {
            int utf8FmtAndArgListBufSize = Utf8Size(fmtAndArgList);
            byte[] utf8FmtAndArgList = new byte[utf8FmtAndArgListBufSize];
            INTERNAL_SDL_LogInfo(
                category,
                Utf8Encode(fmtAndArgList, utf8FmtAndArgList, utf8FmtAndArgListBufSize)
            );
        }


        /// <summary>
        ///     Internals the sdl log warn using the specified category
        /// </summary>
        /// <param name="category">The category</param>
        /// <param name="fmtAndArgList">The fmt and arg list</param>
        [DllImport(NativeLibName, EntryPoint = "SDL_LogWarn", CallingConvention = CallingConvention.Cdecl)]
        private static extern void INTERNAL_SDL_LogWarn(
            int category,
            byte[] fmtAndArgList
        );

        /// <summary>
        ///     Sdl the log warn using the specified category
        /// </summary>
        /// <param name="category">The category</param>
        /// <param name="fmtAndArgList">The fmt and arg list</param>
        public static void SDL_LogWarn(
            int category,
            string fmtAndArgList
        )
        {
            int utf8FmtAndArgListBufSize = Utf8Size(fmtAndArgList);
            byte[] utf8FmtAndArgList = new byte[utf8FmtAndArgListBufSize];
            INTERNAL_SDL_LogWarn(
                category,
                Utf8Encode(fmtAndArgList, utf8FmtAndArgList, utf8FmtAndArgListBufSize)
            );
        }


        /// <summary>
        ///     Internals the sdl log error using the specified category
        /// </summary>
        /// <param name="category">The category</param>
        /// <param name="fmtAndArgList">The fmt and arg list</param>
        [DllImport(NativeLibName, EntryPoint = "SDL_LogError", CallingConvention = CallingConvention.Cdecl)]
        private static extern void INTERNAL_SDL_LogError(
            int category,
            byte[] fmtAndArgList
        );

        /// <summary>
        ///     Sdl the log error using the specified category
        /// </summary>
        /// <param name="category">The category</param>
        /// <param name="fmtAndArgList">The fmt and arg list</param>
        public static void SDL_LogError(
            int category,
            string fmtAndArgList
        )
        {
            int utf8FmtAndArgListBufSize = Utf8Size(fmtAndArgList);
            byte[] utf8FmtAndArgList = new byte[utf8FmtAndArgListBufSize];
            INTERNAL_SDL_LogError(
                category,
                Utf8Encode(fmtAndArgList, utf8FmtAndArgList, utf8FmtAndArgListBufSize)
            );
        }


        /// <summary>
        ///     Internals the sdl log critical using the specified category
        /// </summary>
        /// <param name="category">The category</param>
        /// <param name="fmtAndArgList">The fmt and arg list</param>
        [DllImport(NativeLibName, EntryPoint = "SDL_LogCritical", CallingConvention = CallingConvention.Cdecl)]
        private static extern void INTERNAL_SDL_LogCritical(
            int category,
            byte[] fmtAndArgList
        );

        /// <summary>
        ///     Sdl the log critical using the specified category
        /// </summary>
        /// <param name="category">The category</param>
        /// <param name="fmtAndArgList">The fmt and arg list</param>
        public static void SDL_LogCritical(
            int category,
            string fmtAndArgList
        )
        {
            int utf8FmtAndArgListBufSize = Utf8Size(fmtAndArgList);
            byte[] utf8FmtAndArgList = new byte[utf8FmtAndArgListBufSize];
            INTERNAL_SDL_LogCritical(
                category,
                Utf8Encode(fmtAndArgList, utf8FmtAndArgList, utf8FmtAndArgListBufSize)
            );
        }


        /// <summary>
        ///     Internals the sdl log message using the specified category
        /// </summary>
        /// <param name="category">The category</param>
        /// <param name="priority">The priority</param>
        /// <param name="fmtAndArgList">The fmt and arg list</param>
        [DllImport(NativeLibName, EntryPoint = "SDL_LogMessage", CallingConvention = CallingConvention.Cdecl)]
        private static extern void INTERNAL_SDL_LogMessage(
            int category,
            SdlLogPriority priority,
            byte[] fmtAndArgList
        );

        /// <summary>
        ///     Sdl the log message using the specified category
        /// </summary>
        /// <param name="category">The category</param>
        /// <param name="priority">The priority</param>
        /// <param name="fmtAndArgList">The fmt and arg list</param>
        public static void SDL_LogMessage(
            int category,
            SdlLogPriority priority,
            string fmtAndArgList
        )
        {
            int utf8FmtAndArgListBufSize = Utf8Size(fmtAndArgList);
            byte[] utf8FmtAndArgList = new byte[utf8FmtAndArgListBufSize];
            INTERNAL_SDL_LogMessage(
                category,
                priority,
                Utf8Encode(fmtAndArgList, utf8FmtAndArgList, utf8FmtAndArgListBufSize)
            );
        }


        /// <summary>
        ///     Internals the sdl log message v using the specified category
        /// </summary>
        /// <param name="category">The category</param>
        /// <param name="priority">The priority</param>
        /// <param name="fmtAndArgList">The fmt and arg list</param>
        [DllImport(NativeLibName, EntryPoint = "SDL_LogMessageV", CallingConvention = CallingConvention.Cdecl)]
        private static extern void INTERNAL_SDL_LogMessageV(
            int category,
            SdlLogPriority priority,
            byte[] fmtAndArgList
        );

        /// <summary>
        ///     Sdl the log message v using the specified category
        /// </summary>
        /// <param name="category">The category</param>
        /// <param name="priority">The priority</param>
        /// <param name="fmtAndArgList">The fmt and arg list</param>
        public static void SDL_LogMessageV(
            int category,
            SdlLogPriority priority,
            string fmtAndArgList
        )
        {
            int utf8FmtAndArgListBufSize = Utf8Size(fmtAndArgList);
            byte[] utf8FmtAndArgList = new byte[utf8FmtAndArgListBufSize];
            INTERNAL_SDL_LogMessageV(
                category,
                priority,
                Utf8Encode(fmtAndArgList, utf8FmtAndArgList, utf8FmtAndArgListBufSize)
            );
        }

        /// <summary>
        ///     Sdl the log get priority using the specified category
        /// </summary>
        /// <param name="category">The category</param>
        /// <returns>The sdl log priority</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern SdlLogPriority SDL_LogGetPriority(
            int category
        );

        /// <summary>
        ///     Sdl the log set priority using the specified category
        /// </summary>
        /// <param name="category">The category</param>
        /// <param name="priority">The priority</param>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_LogSetPriority(
            int category,
            SdlLogPriority priority
        );

        /// <summary>
        ///     Sdl the log set all priority using the specified priority
        /// </summary>
        /// <param name="priority">The priority</param>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_LogSetAllPriority(
            SdlLogPriority priority
        );

        /// <summary>
        ///     Sdl the log reset priorities
        /// </summary>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_LogResetPriorities();


        /// <summary>
        ///     Sdl the log get output function using the specified callback
        /// </summary>
        /// <param name="callback">The callback</param>
        /// <param name="userdata">The userdata</param>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        private static extern void SDL_LogGetOutputFunction(
            out IntPtr callback,
            out IntPtr userdata
        );

        /// <summary>
        ///     Sdl the log get output function using the specified callback
        /// </summary>
        /// <param name="callback">The callback</param>
        /// <param name="userdata">The userdata</param>
        public static void SDL_LogGetOutputFunction(
            out SdlLogOutputFunction callback,
            out IntPtr userdata
        )
        {
            SDL_LogGetOutputFunction(
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
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_LogSetOutputFunction(
            SdlLogOutputFunction callback,
            IntPtr userdata
        );

        /// <summary>
        ///     Internals the sdl show message box using the specified message box data
        /// </summary>
        /// <param name="messageBoxData">The message box data</param>
        /// <param name="buttonId">The button id</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_ShowMessageBox", CallingConvention = CallingConvention.Cdecl)]
        private static extern int INTERNAL_SDL_ShowMessageBox([In] ref InternalSdlMessageBoxData messageBoxData, out int buttonId);


        /// <summary>
        ///     Internals the alloc utf 8 using the specified str
        /// </summary>
        /// <param name="str">The str</param>
        /// <returns>The mem</returns>
        private static IntPtr INTERNAL_AllocUTF8(string str)
        {
            if (string.IsNullOrEmpty(str))
            {
                return IntPtr.Zero;
            }

            byte[] bytes = Encoding.UTF8.GetBytes(str + '\0');
            IntPtr mem = SDL_malloc(bytes.Length);
            Marshal.Copy(bytes, 0, mem, bytes.Length);
            return mem;
        }

        /// <summary>
        ///     Sdl the show message box using the specified message box data
        /// </summary>
        /// <param name="messageBoxData">The message box data</param>
        /// <param name="buttonId">The button id</param>
        /// <returns>The result</returns>
        public static int SDL_ShowMessageBox(ref SdlMessageBoxData messageBoxData, out int buttonId)
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
                    SDL_free(buttons[i].text);
                }

                SDL_free(data.message);
                SDL_free(data.title);

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
        private static extern int INTERNAL_SDL_ShowSimpleMessageBox(
            SdlMessageBoxFlags flags,
            byte[] title,
            byte[] message,
            IntPtr window
        );

        /// <summary>
        ///     Sdl the show simple message box using the specified flags
        /// </summary>
        /// <param name="flags">The flags</param>
        /// <param name="title">The title</param>
        /// <param name="message">The message</param>
        /// <param name="window">The window</param>
        /// <returns>The int</returns>
        public static int SDL_ShowSimpleMessageBox(
            SdlMessageBoxFlags flags,
            string title,
            string message,
            IntPtr window
        )
        {
            int utf8TitleBufSize = Utf8Size(title);
            byte[] utf8Title = new byte[utf8TitleBufSize];

            int utf8MessageBufSize = Utf8Size(message);
            byte[] utf8Message = new byte[utf8MessageBufSize];

            return INTERNAL_SDL_ShowSimpleMessageBox(
                flags,
                Utf8Encode(title, utf8Title, utf8TitleBufSize),
                Utf8Encode(message, utf8Message, utf8MessageBufSize),
                window
            );
        }

        /// <summary>
        ///     Sdl the version using the specified x
        /// </summary>
        /// <param name="x">The </param>
        public static void SDL_VERSION(out SdlVersion x)
        {
            x.major = SdlMajorVersion;
            x.minor = SdlMinorVersion;
            x.patch = SdlPatchLevel;
        }

        /// <summary>
        ///     Sdl the version num using the specified x
        /// </summary>
        /// <param name="x">The </param>
        /// <param name="y">The </param>
        /// <param name="z">The </param>
        /// <returns>The int</returns>
        private static int SdlVersionNum(int x, int y, int z) => x * 1000 + y * 100 + z;

        /// <summary>
        ///     Describes whether sdl version at least
        /// </summary>
        /// <param name="x">The </param>
        /// <param name="y">The </param>
        /// <param name="z">The </param>
        /// <returns>The bool</returns>
        public static bool SdlVersionAtLeast(int x, int y, int z) => SdlCompiledVersion >= SdlVersionNum(x, y, z);

        /// <summary>
        ///     Sdl the get version using the specified ver
        /// </summary>
        /// <param name="ver">The ver</param>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_GetVersion(out SdlVersion ver);

        /// <summary>
        ///     Internals the sdl get revision
        /// </summary>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GetRevision", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr INTERNAL_SDL_GetRevision();

        /// <summary>
        ///     Sdl the get revision
        /// </summary>
        /// <returns>The string</returns>
        public static string SDL_GetRevision() => Utf8ToManaged(INTERNAL_SDL_GetRevision());

        /// <summary>
        ///     Sdl the get revision number
        /// </summary>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_GetRevisionNumber();

        /// <summary>
        ///     Sdl the window pos undefined display using the specified x
        /// </summary>
        /// <param name="x">The </param>
        /// <returns>The int</returns>
        public static int SdlWindowPosUndefinedDisplay(int x) => SdlWindowPosUndefinedMask | x;

        /// <summary>
        ///     Describes whether sdl window pos is undefined
        /// </summary>
        /// <param name="x">The </param>
        /// <returns>The bool</returns>
        public static bool SdlWindowPosIsUndefined(int x) => (x & 0xFFFF0000) == SdlWindowPosUndefinedMask;

        /// <summary>
        ///     Sdl the window pos centered display using the specified x
        /// </summary>
        /// <param name="x">The </param>
        /// <returns>The int</returns>
        public static int SdlWindowPosCenteredDisplay(int x) => SdlWindowPosCenteredMask | x;

        /// <summary>
        ///     Describes whether sdl window pos is centered
        /// </summary>
        /// <param name="x">The </param>
        /// <returns>The bool</returns>
        public static bool SdlWindowPosIsCentered(int x) => (x & 0xFFFF0000) == SdlWindowPosCenteredMask;
        
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
        private static extern IntPtr INTERNAL_SDL_CreateWindow(
            byte[] title,
            int x,
            int y,
            int w,
            int h,
            SdlWindowFlags flags
        );

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
        public static IntPtr SDL_CreateWindow(
            string title,
            int x,
            int y,
            int w,
            int h,
            SdlWindowFlags flags
        )
        {
            int utf8TitleBufSize = Utf8Size(title);
            byte[] utf8Title = new byte[utf8TitleBufSize];
            return INTERNAL_SDL_CreateWindow(
                Utf8Encode(title, utf8Title, utf8TitleBufSize),
                x, y, w, h,
                flags
            );
        }


        /// <summary>
        ///     Sdl the create window and renderer using the specified width
        /// </summary>
        /// <param name="width">The width</param>
        /// <param name="height">The height</param>
        /// <param name="windowFlags">The window flags</param>
        /// <param name="window">The window</param>
        /// <param name="renderer">The renderer</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_CreateWindowAndRenderer(
            int width,
            int height,
            SdlWindowFlags windowFlags,
            out IntPtr window,
            out IntPtr renderer
        );


        /// <summary>
        ///     Sdl the create window from using the specified data
        /// </summary>
        /// <param name="data">The data</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr SDL_CreateWindowFrom(IntPtr data);


        /// <summary>
        ///     Sdl the destroy window using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_DestroyWindow(IntPtr window);

        /// <summary>
        ///     Sdl the disable screen saver
        /// </summary>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_DisableScreenSaver();

        /// <summary>
        ///     Sdl the enable screen saver
        /// </summary>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_EnableScreenSaver();


        /// <summary>
        ///     Sdl the get closest display mode using the specified display index
        /// </summary>
        /// <param name="displayIndex">The display index</param>
        /// <param name="mode">The mode</param>
        /// <param name="closest">The closest</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr SDL_GetClosestDisplayMode(
            int displayIndex,
            ref SdlDisplayMode mode,
            out SdlDisplayMode closest
        );

        /// <summary>
        ///     Sdl the get current display mode using the specified display index
        /// </summary>
        /// <param name="displayIndex">The display index</param>
        /// <param name="mode">The mode</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_GetCurrentDisplayMode(
            int displayIndex,
            out SdlDisplayMode mode
        );

        /// <summary>
        ///     Internals the sdl get current video driver
        /// </summary>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GetCurrentVideoDriver", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr INTERNAL_SDL_GetCurrentVideoDriver();

        /// <summary>
        ///     Sdl the get current video driver
        /// </summary>
        /// <returns>The string</returns>
        public static string SDL_GetCurrentVideoDriver() => Utf8ToManaged(INTERNAL_SDL_GetCurrentVideoDriver());

        /// <summary>
        ///     Sdl the get desktop display mode using the specified display index
        /// </summary>
        /// <param name="displayIndex">The display index</param>
        /// <param name="mode">The mode</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_GetDesktopDisplayMode(
            int displayIndex,
            out SdlDisplayMode mode
        );

        /// <summary>
        ///     Internals the sdl get display name using the specified index
        /// </summary>
        /// <param name="index">The index</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GetDisplayName", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr INTERNAL_SDL_GetDisplayName(int index);

        /// <summary>
        ///     Sdl the get display name using the specified index
        /// </summary>
        /// <param name="index">The index</param>
        /// <returns>The string</returns>
        public static string SDL_GetDisplayName(int index) => Utf8ToManaged(INTERNAL_SDL_GetDisplayName(index));

        /// <summary>
        ///     Sdl the get display bounds using the specified display index
        /// </summary>
        /// <param name="displayIndex">The display index</param>
        /// <param name="rect">The rect</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_GetDisplayBounds(
            int displayIndex,
            out SdlRect rect
        );


        /// <summary>
        ///     Sdl the get display dpi using the specified display index
        /// </summary>
        /// <param name="displayIndex">The display index</param>
        /// <param name="dDpi">The d dpi</param>
        /// <param name="hDpi">The h dpi</param>
        /// <param name="vDpi">The v dpi</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_GetDisplayDPI(
            int displayIndex,
            out float dDpi,
            out float hDpi,
            out float vDpi
        );


        /// <summary>
        ///     Sdl the get display orientation using the specified display index
        /// </summary>
        /// <param name="displayIndex">The display index</param>
        /// <returns>The sdl display orientation</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern SdlDisplayOrientation SDL_GetDisplayOrientation(
            int displayIndex
        );

        /// <summary>
        ///     Sdl the get display mode using the specified display index
        /// </summary>
        /// <param name="displayIndex">The display index</param>
        /// <param name="modeIndex">The mode index</param>
        /// <param name="mode">The mode</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_GetDisplayMode(
            int displayIndex,
            int modeIndex,
            out SdlDisplayMode mode
        );


        /// <summary>
        ///     Sdl the get display usable bounds using the specified display index
        /// </summary>
        /// <param name="displayIndex">The display index</param>
        /// <param name="rect">The rect</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_GetDisplayUsableBounds(
            int displayIndex,
            out SdlRect rect
        );

        /// <summary>
        ///     Sdl the get num display modes using the specified display index
        /// </summary>
        /// <param name="displayIndex">The display index</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_GetNumDisplayModes(
            int displayIndex
        );

        /// <summary>
        ///     Sdl the get num video displays
        /// </summary>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_GetNumVideoDisplays();

        /// <summary>
        ///     Sdl the get num video drivers
        /// </summary>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_GetNumVideoDrivers();

        /// <summary>
        ///     Internals the sdl get video driver using the specified index
        /// </summary>
        /// <param name="index">The index</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GetVideoDriver", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr INTERNAL_SDL_GetVideoDriver(
            int index
        );

        /// <summary>
        ///     Sdl the get video driver using the specified index
        /// </summary>
        /// <param name="index">The index</param>
        /// <returns>The string</returns>
        public static string SDL_GetVideoDriver(int index) => Utf8ToManaged(INTERNAL_SDL_GetVideoDriver(index));


        /// <summary>
        ///     Sdl the get window brightness using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <returns>The float</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern float SDL_GetWindowBrightness(
            IntPtr window
        );


        /// <summary>
        ///     Sdl the set window opacity using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="opacity">The opacity</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_SetWindowOpacity(
            IntPtr window,
            float opacity
        );


        /// <summary>
        ///     Sdl the get window opacity using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="outOpacity">The out opacity</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_GetWindowOpacity(
            IntPtr window,
            out float outOpacity
        );


        /// <summary>
        ///     Sdl the set window modal for using the specified modal window
        /// </summary>
        /// <param name="modalWindow">The modal window</param>
        /// <param name="parentWindow">The parent window</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_SetWindowModalFor(
            IntPtr modalWindow,
            IntPtr parentWindow
        );


        /// <summary>
        ///     Sdl the set window input focus using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_SetWindowInputFocus(IntPtr window);


        /// <summary>
        ///     Internals the sdl get window data using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="name">The name</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GetWindowData", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr INTERNAL_SDL_GetWindowData(
            IntPtr window,
            byte[] name
        );

        /// <summary>
        ///     Sdl the get window data using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="name">The name</param>
        /// <returns>The int ptr</returns>
        public static IntPtr SDL_GetWindowData(
            IntPtr window,
            string name
        )
        {
            int utf8NameBufSize = Utf8Size(name);
            byte[] utf8Name = new byte[utf8NameBufSize];
            return INTERNAL_SDL_GetWindowData(
                window,
                Utf8Encode(name, utf8Name, utf8NameBufSize)
            );
        }


        /// <summary>
        ///     Sdl the get window display index using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_GetWindowDisplayIndex(
            IntPtr window
        );


        /// <summary>
        ///     Sdl the get window display mode using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="mode">The mode</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_GetWindowDisplayMode(
            IntPtr window,
            out SdlDisplayMode mode
        );


        /// <summary>
        ///     Sdl the get window icc profile using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="mode">The mode</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr SDL_GetWindowICCProfile(
            IntPtr window,
            out IntPtr mode
        );


        /// <summary>
        ///     Sdl the get window flags using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <returns>The uint</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern uint SDL_GetWindowFlags(IntPtr window);


        /// <summary>
        ///     Sdl the get window from id using the specified id
        /// </summary>
        /// <param name="id">The id</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr SDL_GetWindowFromID(uint id);


        /// <summary>
        ///     Sdl the get window gamma ramp using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="red">The red</param>
        /// <param name="green">The green</param>
        /// <param name="blue">The blue</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_GetWindowGammaRamp(
            IntPtr window,
            [Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U2, SizeConst = 256)]
            ushort[] red,
            [Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U2, SizeConst = 256)]
            ushort[] green,
            [Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U2, SizeConst = 256)]
            ushort[] blue
        );


        /// <summary>
        ///     Sdl the get window grab using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <returns>The sdl bool</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern SdlBool SDL_GetWindowGrab(IntPtr window);


        /// <summary>
        ///     Sdl the get window keyboard grab using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <returns>The sdl bool</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern SdlBool SDL_GetWindowKeyboardGrab(IntPtr window);


        /// <summary>
        ///     Sdl the get window mouse grab using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <returns>The sdl bool</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern SdlBool SDL_GetWindowMouseGrab(IntPtr window);


        /// <summary>
        ///     Sdl the get window id using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <returns>The uint</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern uint SDL_GetWindowID(IntPtr window);


        /// <summary>
        ///     Sdl the get window pixel format using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <returns>The uint</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern uint SDL_GetWindowPixelFormat(
            IntPtr window
        );


        /// <summary>
        ///     Sdl the get window maximum size using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="maxW">The max</param>
        /// <param name="maxH">The max</param>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_GetWindowMaximumSize(
            IntPtr window,
            out int maxW,
            out int maxH
        );


        /// <summary>
        ///     Sdl the get window minimum size using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="minW">The min</param>
        /// <param name="minH">The min</param>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_GetWindowMinimumSize(
            IntPtr window,
            out int minW,
            out int minH
        );


        /// <summary>
        ///     Sdl the get window position using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="x">The </param>
        /// <param name="y">The </param>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_GetWindowPosition(
            IntPtr window,
            out int x,
            out int y
        );


        /// <summary>
        ///     Sdl the get window size using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="w">The </param>
        /// <param name="h">The </param>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_GetWindowSize(
            IntPtr window,
            out int w,
            out int h
        );


        /// <summary>
        ///     Sdl the get window surface using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr SDL_GetWindowSurface(IntPtr window);


        /// <summary>
        ///     Internals the sdl get window title using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GetWindowTitle", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr INTERNAL_SDL_GetWindowTitle(
            IntPtr window
        );

        /// <summary>
        ///     Sdl the get window title using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <returns>The string</returns>
        public static string SDL_GetWindowTitle(IntPtr window) => Utf8ToManaged(
            INTERNAL_SDL_GetWindowTitle(window)
        );


        /// <summary>
        ///     Sdl the gl bind texture using the specified texture
        /// </summary>
        /// <param name="texture">The texture</param>
        /// <param name="texW">The tex w</param>
        /// <param name="texH">The tex h</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_GL_BindTexture(
            IntPtr texture,
            out float texW,
            out float texH
        );


        /// <summary>
        ///     Sdl the gl create context using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr SDL_GL_CreateContext(IntPtr window);


        /// <summary>
        ///     Sdl the gl delete context using the specified context
        /// </summary>
        /// <param name="context">The context</param>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_GL_DeleteContext(IntPtr context);

        /// <summary>
        ///     Internals the sdl gl load library using the specified path
        /// </summary>
        /// <param name="path">The path</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GL_LoadLibrary", CallingConvention = CallingConvention.Cdecl)]
        private static extern int INTERNAL_SDL_GL_LoadLibrary(byte[] path);

        /// <summary>
        ///     Sdl the gl load library using the specified path
        /// </summary>
        /// <param name="path">The path</param>
        /// <returns>The result</returns>
        public static int SDL_GL_LoadLibrary(string path)
        {
            byte[] utf8Path = Utf8EncodeHeap(path);
            int result = INTERNAL_SDL_GL_LoadLibrary(
                utf8Path
            );
            return result;
        }


        /// <summary>
        ///     Sdl the gl get proc address using the specified proc
        /// </summary>
        /// <param name="proc">The proc</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr SDL_GL_GetProcAddress(byte[] proc);


        /// <summary>
        ///     Sdl the gl get proc address using the specified proc
        /// </summary>
        /// <param name="proc">The proc</param>
        /// <returns>The int ptr</returns>
        public static IntPtr SDL_GL_GetProcAddress(string proc)
        {
            int utf8ProcBufSize = Utf8Size(proc);
            byte[] utf8Proc = new byte[utf8ProcBufSize];
            return SDL_GL_GetProcAddress(
                Utf8Encode(proc, utf8Proc, utf8ProcBufSize)
            );
        }

        /// <summary>
        ///     Sdl the gl unload library
        /// </summary>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_GL_UnloadLibrary();

        /// <summary>
        ///     Internals the sdl gl extension supported using the specified extension
        /// </summary>
        /// <param name="extension">The extension</param>
        /// <returns>The sdl bool</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GL_ExtensionSupported", CallingConvention = CallingConvention.Cdecl)]
        private static extern SdlBool INTERNAL_SDL_GL_ExtensionSupported(
            byte[] extension
        );

        /// <summary>
        ///     Sdl the gl extension supported using the specified extension
        /// </summary>
        /// <param name="extension">The extension</param>
        /// <returns>The sdl bool</returns>
        public static SdlBool SDL_GL_ExtensionSupported(string extension)
        {
            int utf8ExtensionBufSize = Utf8Size(extension);
            byte[] utf8Extension = new byte[utf8ExtensionBufSize];
            return INTERNAL_SDL_GL_ExtensionSupported(
                Utf8Encode(extension, utf8Extension, utf8ExtensionBufSize)
            );
        }


        /// <summary>
        ///     Sdl the gl reset attributes
        /// </summary>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_GL_ResetAttributes();

        /// <summary>
        ///     Sdl the gl get attribute using the specified attr
        /// </summary>
        /// <param name="attr">The attr</param>
        /// <param name="value">The value</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_GL_GetAttribute(
            SdlGlAttr attr,
            out int value
        );

        /// <summary>
        ///     Sdl the gl get swap interval
        /// </summary>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_GL_GetSwapInterval();


        /// <summary>
        ///     Sdl the gl make current using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="context">The context</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_GL_MakeCurrent(
            IntPtr window,
            IntPtr context
        );


        /// <summary>
        ///     Sdl the gl get current window
        /// </summary>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr SDL_GL_GetCurrentWindow();


        /// <summary>
        ///     Sdl the gl get current context
        /// </summary>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr SDL_GL_GetCurrentContext();


        /// <summary>
        ///     Sdl the gl get drawable size using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="w">The </param>
        /// <param name="h">The </param>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_GL_GetDrawableSize(
            IntPtr window,
            out int w,
            out int h
        );

        /// <summary>
        ///     Sdl the gl set attribute using the specified attr
        /// </summary>
        /// <param name="attr">The attr</param>
        /// <param name="value">The value</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_GL_SetAttribute(
            SdlGlAttr attr,
            int value
        );

        /// <summary>
        ///     Sdl the gl set attribute using the specified attr
        /// </summary>
        /// <param name="attr">The attr</param>
        /// <param name="profile">The profile</param>
        /// <returns>The int</returns>
        public static int SDL_GL_SetAttribute(
            SdlGlAttr attr,
            SdlGlProfile profile
        )
            => SDL_GL_SetAttribute(attr, (int) profile);

        /// <summary>
        ///     Sdl the gl set swap interval using the specified interval
        /// </summary>
        /// <param name="interval">The interval</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_GL_SetSwapInterval(int interval);


        /// <summary>
        ///     Sdl the gl swap window using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_GL_SwapWindow(IntPtr window);


        /// <summary>
        ///     Sdl the gl unbind texture using the specified texture
        /// </summary>
        /// <param name="texture">The texture</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_GL_UnbindTexture(IntPtr texture);


        /// <summary>
        ///     Sdl the hide window using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_HideWindow(IntPtr window);

        /// <summary>
        ///     Sdl the is screen saver enabled
        /// </summary>
        /// <returns>The sdl bool</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern SdlBool SDL_IsScreenSaverEnabled();


        /// <summary>
        ///     Sdl the maximize window using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_MaximizeWindow(IntPtr window);


        /// <summary>
        ///     Sdl the minimize window using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_MinimizeWindow(IntPtr window);


        /// <summary>
        ///     Sdl the raise window using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_RaiseWindow(IntPtr window);


        /// <summary>
        ///     Sdl the restore window using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_RestoreWindow(IntPtr window);


        /// <summary>
        ///     Sdl the set window brightness using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="brightness">The brightness</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_SetWindowBrightness(
            IntPtr window,
            float brightness
        );


        /// <summary>
        ///     Internals the sdl set window data using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="name">The name</param>
        /// <param name="userdata">The userdata</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_SetWindowData", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr INTERNAL_SDL_SetWindowData(
            IntPtr window,
            byte[] name,
            IntPtr userdata
        );

        /// <summary>
        ///     Sdl the set window data using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="name">The name</param>
        /// <param name="userdata">The userdata</param>
        /// <returns>The int ptr</returns>
        public static IntPtr SDL_SetWindowData(
            IntPtr window,
            string name,
            IntPtr userdata
        )
        {
            int utf8NameBufSize = Utf8Size(name);
            byte[] utf8Name = new byte[utf8NameBufSize];
            return INTERNAL_SDL_SetWindowData(
                window,
                Utf8Encode(name, utf8Name, utf8NameBufSize),
                userdata
            );
        }


        /// <summary>
        ///     Sdl the set window display mode using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="mode">The mode</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_SetWindowDisplayMode(
            IntPtr window,
            ref SdlDisplayMode mode
        );


        /// <summary>
        ///     Sdl the set window display mode using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="mode">The mode</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_SetWindowDisplayMode(
            IntPtr window,
            IntPtr mode
        );


        /// <summary>
        ///     Sdl the set window fullscreen using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="flags">The flags</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_SetWindowFullscreen(
            IntPtr window,
            uint flags
        );


        /// <summary>
        ///     Sdl the set window gamma ramp using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="red">The red</param>
        /// <param name="green">The green</param>
        /// <param name="blue">The blue</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_SetWindowGammaRamp(
            IntPtr window,
            [In, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U2, SizeConst = 256)]
            ushort[] red,
            [In, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U2, SizeConst = 256)]
            ushort[] green,
            [In, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U2, SizeConst = 256)]
            ushort[] blue
        );


        /// <summary>
        ///     Sdl the set window grab using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="grabbed">The grabbed</param>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_SetWindowGrab(
            IntPtr window,
            SdlBool grabbed
        );


        /// <summary>
        ///     Sdl the set window keyboard grab using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="grabbed">The grabbed</param>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_SetWindowKeyboardGrab(
            IntPtr window,
            SdlBool grabbed
        );


        /// <summary>
        ///     Sdl the set window mouse grab using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="grabbed">The grabbed</param>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_SetWindowMouseGrab(
            IntPtr window,
            SdlBool grabbed
        );


        /// <summary>
        ///     Sdl the set window icon using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="icon">The icon</param>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_SetWindowIcon(
            IntPtr window,
            IntPtr icon
        );


        /// <summary>
        ///     Sdl the set window maximum size using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="maxW">The max</param>
        /// <param name="maxH">The max</param>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_SetWindowMaximumSize(
            IntPtr window,
            int maxW,
            int maxH
        );


        /// <summary>
        ///     Sdl the set window minimum size using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="minW">The min</param>
        /// <param name="minH">The min</param>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_SetWindowMinimumSize(
            IntPtr window,
            int minW,
            int minH
        );


        /// <summary>
        ///     Sdl the set window position using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="x">The </param>
        /// <param name="y">The </param>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_SetWindowPosition(
            IntPtr window,
            int x,
            int y
        );


        /// <summary>
        ///     Sdl the set window size using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="w">The </param>
        /// <param name="h">The </param>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_SetWindowSize(
            IntPtr window,
            int w,
            int h
        );


        /// <summary>
        ///     Sdl the set window bordered using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="bordered">The bordered</param>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_SetWindowBordered(
            IntPtr window,
            SdlBool bordered
        );


        /// <summary>
        ///     Sdl the get window borders size using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="top">The top</param>
        /// <param name="left">The left</param>
        /// <param name="bottom">The bottom</param>
        /// <param name="right">The right</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_GetWindowBordersSize(
            IntPtr window,
            out int top,
            out int left,
            out int bottom,
            out int right
        );


        /// <summary>
        ///     Sdl the set window resizable using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="resizable">The resizable</param>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_SetWindowResizable(
            IntPtr window,
            SdlBool resizable
        );


        /// <summary>
        ///     Sdl the set window always on top using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="onTop">The on top</param>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_SetWindowAlwaysOnTop(
            IntPtr window,
            SdlBool onTop
        );


        /// <summary>
        ///     Internals the sdl set window title using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="title">The title</param>
        [DllImport(NativeLibName, EntryPoint = "SDL_SetWindowTitle", CallingConvention = CallingConvention.Cdecl)]
        private static extern void INTERNAL_SDL_SetWindowTitle(
            IntPtr window,
            byte[] title
        );

        /// <summary>
        ///     Sdl the set window title using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="title">The title</param>
        public static void SDL_SetWindowTitle(
            IntPtr window,
            string title
        )
        {
            int utf8TitleBufSize = Utf8Size(title);
            byte[] utf8Title = new byte[utf8TitleBufSize];
            INTERNAL_SDL_SetWindowTitle(
                window,
                Utf8Encode(title, utf8Title, utf8TitleBufSize)
            );
        }


        /// <summary>
        ///     Sdl the show window using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_ShowWindow(IntPtr window);


        /// <summary>
        ///     Sdl the update window surface using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_UpdateWindowSurface(IntPtr window);


        /// <summary>
        ///     Sdl the update window surface rects using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="rects">The rects</param>
        /// <param name="numRects">The num rects</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_UpdateWindowSurfaceRects(
            IntPtr window,
            [In] SdlRect[] rects,
            int numRects
        );

        /// <summary>
        ///     Internals the sdl video init using the specified driver name
        /// </summary>
        /// <param name="driverName">The driver name</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_VideoInit", CallingConvention = CallingConvention.Cdecl)]
        private static extern int INTERNAL_SDL_VideoInit(
            byte[] driverName
        );

        /// <summary>
        ///     Sdl the video init using the specified driver name
        /// </summary>
        /// <param name="driverName">The driver name</param>
        /// <returns>The int</returns>
        public static int SDL_VideoInit(string driverName)
        {
            int utf8DriverNameBufSize = Utf8Size(driverName);
            byte[] utf8DriverName = new byte[utf8DriverNameBufSize];
            return INTERNAL_SDL_VideoInit(
                Utf8Encode(driverName, utf8DriverName, utf8DriverNameBufSize)
            );
        }

        /// <summary>
        ///     Sdl the video quit
        /// </summary>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_VideoQuit();


        /// <summary>
        ///     Sdl the set window hit test using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="callback">The callback</param>
        /// <param name="callbackData">The callback data</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_SetWindowHitTest(
            IntPtr window,
            SdlHitTest callback,
            IntPtr callbackData
        );


        /// <summary>
        ///     Sdl the get grabbed window
        /// </summary>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr SDL_GetGrabbedWindow();


        /// <summary>
        ///     Sdl the set window mouse rect using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="rect">The rect</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_SetWindowMouseRect(
            IntPtr window,
            ref SdlRect rect
        );


        /// <summary>
        ///     Sdl the set window mouse rect using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="rect">The rect</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_SetWindowMouseRect(
            IntPtr window,
            IntPtr rect
        );


        /// <summary>
        ///     Sdl the get window mouse rect using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr SDL_GetWindowMouseRect(
            IntPtr window
        );


        /// <summary>
        ///     Sdl the flash window using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="operation">The operation</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_FlashWindow(
            IntPtr window,
            SdlFlashOperation operation
        );


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
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern SdlBlendMode SDL_ComposeCustomBlendMode(
            SdlBlendFactor srcColorFactor,
            SdlBlendFactor dstColorFactor,
            SdlBlendOperation colorOperation,
            SdlBlendFactor srcAlphaFactor,
            SdlBlendFactor dstAlphaFactor,
            SdlBlendOperation alphaOperation
        );

        /// <summary>
        ///     Internals the sdl vulkan load library using the specified path
        /// </summary>
        /// <param name="path">The path</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_Vulkan_LoadLibrary", CallingConvention = CallingConvention.Cdecl)]
        private static extern int INTERNAL_SDL_Vulkan_LoadLibrary(
            byte[] path
        );

        /// <summary>
        ///     Sdl the vulkan load library using the specified path
        /// </summary>
        /// <param name="path">The path</param>
        /// <returns>The result</returns>
        public static int SDL_Vulkan_LoadLibrary(string path)
        {
            byte[] utf8Path = Utf8EncodeHeap(path);
            int result = INTERNAL_SDL_Vulkan_LoadLibrary(
                utf8Path
            );
            return result;
        }


        /// <summary>
        ///     Sdl the vulkan get vk get instance proc addr
        /// </summary>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr SDL_Vulkan_GetVkGetInstanceProcAddr();


        /// <summary>
        ///     Sdl the vulkan unload library
        /// </summary>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_Vulkan_UnloadLibrary();


        /// <summary>
        ///     Sdl the vulkan get instance extensions using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="pCount">The count</param>
        /// <param name="pNames">The names</param>
        /// <returns>The sdl bool</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern SdlBool SDL_Vulkan_GetInstanceExtensions(
            IntPtr window,
            out uint pCount,
            IntPtr pNames
        );


        /// <summary>
        ///     Sdl the vulkan get instance extensions using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="pCount">The count</param>
        /// <param name="pNames">The names</param>
        /// <returns>The sdl bool</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern SdlBool SDL_Vulkan_GetInstanceExtensions(
            IntPtr window,
            out uint pCount,
            IntPtr[] pNames
        );


        /// <summary>
        ///     Sdl the vulkan create surface using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="instance">The instance</param>
        /// <param name="surface">The surface</param>
        /// <returns>The sdl bool</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern SdlBool SDL_Vulkan_CreateSurface(
            IntPtr window,
            IntPtr instance,
            out ulong surface
        );


        /// <summary>
        ///     Sdl the vulkan get drawable size using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="w">The </param>
        /// <param name="h">The </param>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_Vulkan_GetDrawableSize(
            IntPtr window,
            out int w,
            out int h
        );

        /// <summary>
        ///     Sdl the metal create view using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr SDL_Metal_CreateView(
            IntPtr window
        );


        /// <summary>
        ///     Sdl the metal destroy view using the specified view
        /// </summary>
        /// <param name="view">The view</param>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_Metal_DestroyView(
            IntPtr view
        );


        /// <summary>
        ///     Sdl the metal get layer using the specified view
        /// </summary>
        /// <param name="view">The view</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr SDL_Metal_GetLayer(
            IntPtr view
        );


        /// <summary>
        ///     Sdl the metal get drawable size using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="w">The </param>
        /// <param name="h">The </param>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_Metal_GetDrawableSize(
            IntPtr window,
            out int w,
            out int h
        );


        /// <summary>
        ///     Sdl the create renderer using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="index">The index</param>
        /// <param name="flags">The flags</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr SDL_CreateRenderer(
            IntPtr window,
            int index,
            SdlRendererFlags flags
        );


        /// <summary>
        ///     Sdl the create software renderer using the specified surface
        /// </summary>
        /// <param name="surface">The surface</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr SDL_CreateSoftwareRenderer(IntPtr surface);


        /// <summary>
        ///     Sdl the create texture using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="format">The format</param>
        /// <param name="access">The access</param>
        /// <param name="w">The </param>
        /// <param name="h">The </param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr SDL_CreateTexture(
            IntPtr renderer,
            uint format,
            int access,
            int w,
            int h
        );


        /// <summary>
        ///     Sdl the create texture from surface using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="surface">The surface</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr SDL_CreateTextureFromSurface(
            IntPtr renderer,
            IntPtr surface
        );


        /// <summary>
        ///     Sdl the destroy renderer using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_DestroyRenderer(IntPtr renderer);


        /// <summary>
        ///     Sdl the destroy texture using the specified texture
        /// </summary>
        /// <param name="texture">The texture</param>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_DestroyTexture(IntPtr texture);

        /// <summary>
        ///     Sdl the get num render drivers
        /// </summary>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_GetNumRenderDrivers();


        /// <summary>
        ///     Sdl the get render draw blend mode using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="blendMode">The blend mode</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_GetRenderDrawBlendMode(
            IntPtr renderer,
            out SdlBlendMode blendMode
        );


        /// <summary>
        ///     Sdl the set texture scale mode using the specified texture
        /// </summary>
        /// <param name="texture">The texture</param>
        /// <param name="scaleMode">The scale mode</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_SetTextureScaleMode(
            IntPtr texture,
            SdlScaleMode scaleMode
        );


        /// <summary>
        ///     Sdl the get texture scale mode using the specified texture
        /// </summary>
        /// <param name="texture">The texture</param>
        /// <param name="scaleMode">The scale mode</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_GetTextureScaleMode(
            IntPtr texture,
            out SdlScaleMode scaleMode
        );


        /// <summary>
        ///     Sdl the set texture user data using the specified texture
        /// </summary>
        /// <param name="texture">The texture</param>
        /// <param name="userdata">The userdata</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_SetTextureUserData(
            IntPtr texture,
            IntPtr userdata
        );


        /// <summary>
        ///     Sdl the get texture user data using the specified texture
        /// </summary>
        /// <param name="texture">The texture</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr SDL_GetTextureUserData(IntPtr texture);


        /// <summary>
        ///     Sdl the get render draw color using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="r">The </param>
        /// <param name="g">The </param>
        /// <param name="b">The </param>
        /// <param name="a">The </param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_GetRenderDrawColor(
            IntPtr renderer,
            out byte r,
            out byte g,
            out byte b,
            out byte a
        );

        /// <summary>
        ///     Sdl the get render driver info using the specified index
        /// </summary>
        /// <param name="index">The index</param>
        /// <param name="info">The info</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_GetRenderDriverInfo(
            int index,
            out SdlRendererInfo info
        );


        /// <summary>
        ///     Sdl the get renderer using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr SDL_GetRenderer(IntPtr window);


        /// <summary>
        ///     Sdl the get renderer info using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="info">The info</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_GetRendererInfo(
            IntPtr renderer,
            out SdlRendererInfo info
        );


        /// <summary>
        ///     Sdl the get renderer output size using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="w">The </param>
        /// <param name="h">The </param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_GetRendererOutputSize(
            IntPtr renderer,
            out int w,
            out int h
        );


        /// <summary>
        ///     Sdl the get texture alpha mod using the specified texture
        /// </summary>
        /// <param name="texture">The texture</param>
        /// <param name="alpha">The alpha</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_GetTextureAlphaMod(
            IntPtr texture,
            out byte alpha
        );


        /// <summary>
        ///     Sdl the get texture blend mode using the specified texture
        /// </summary>
        /// <param name="texture">The texture</param>
        /// <param name="blendMode">The blend mode</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_GetTextureBlendMode(
            IntPtr texture,
            out SdlBlendMode blendMode
        );


        /// <summary>
        ///     Sdl the get texture color mod using the specified texture
        /// </summary>
        /// <param name="texture">The texture</param>
        /// <param name="r">The </param>
        /// <param name="g">The </param>
        /// <param name="b">The </param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_GetTextureColorMod(
            IntPtr texture,
            out byte r,
            out byte g,
            out byte b
        );


        /// <summary>
        ///     Sdl the lock texture using the specified texture
        /// </summary>
        /// <param name="texture">The texture</param>
        /// <param name="rect">The rect</param>
        /// <param name="pixels">The pixels</param>
        /// <param name="pitch">The pitch</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_LockTexture(
            IntPtr texture,
            ref SdlRect rect,
            out IntPtr pixels,
            out int pitch
        );


        /// <summary>
        ///     Sdl the lock texture using the specified texture
        /// </summary>
        /// <param name="texture">The texture</param>
        /// <param name="rect">The rect</param>
        /// <param name="pixels">The pixels</param>
        /// <param name="pitch">The pitch</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_LockTexture(
            IntPtr texture,
            IntPtr rect,
            out IntPtr pixels,
            out int pitch
        );


        /// <summary>
        ///     Sdl the lock texture to surface using the specified texture
        /// </summary>
        /// <param name="texture">The texture</param>
        /// <param name="rect">The rect</param>
        /// <param name="surface">The surface</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_LockTextureToSurface(
            IntPtr texture,
            ref SdlRect rect,
            out IntPtr surface
        );


        /// <summary>
        ///     Sdl the lock texture to surface using the specified texture
        /// </summary>
        /// <param name="texture">The texture</param>
        /// <param name="rect">The rect</param>
        /// <param name="surface">The surface</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_LockTextureToSurface(
            IntPtr texture,
            IntPtr rect,
            out IntPtr surface
        );


        /// <summary>
        ///     Sdl the query texture using the specified texture
        /// </summary>
        /// <param name="texture">The texture</param>
        /// <param name="format">The format</param>
        /// <param name="access">The access</param>
        /// <param name="w">The </param>
        /// <param name="h">The </param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_QueryTexture(
            IntPtr texture,
            out uint format,
            out int access,
            out int w,
            out int h
        );


        /// <summary>
        ///     Sdl the render clear using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_RenderClear(IntPtr renderer);


        /// <summary>
        ///     Sdl the render copy using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="texture">The texture</param>
        /// <param name="srcRect">The src rect</param>
        /// <param name="dstRect">The dst rect</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_RenderCopy(
            IntPtr renderer,
            IntPtr texture,
            ref SdlRect srcRect,
            ref SdlRect dstRect
        );


        /// <summary>
        ///     Sdl the render copy using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="texture">The texture</param>
        /// <param name="srcRect">The src rect</param>
        /// <param name="dstRect">The dst rect</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_RenderCopy(
            IntPtr renderer,
            IntPtr texture,
            IntPtr srcRect,
            ref SdlRect dstRect
        );


        /// <summary>
        ///     Sdl the render copy using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="texture">The texture</param>
        /// <param name="srcRect">The src rect</param>
        /// <param name="dstRect">The dst rect</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_RenderCopy(
            IntPtr renderer,
            IntPtr texture,
            ref SdlRect srcRect,
            IntPtr dstRect
        );


        /// <summary>
        ///     Sdl the render copy using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="texture">The texture</param>
        /// <param name="srcRect">The src rect</param>
        /// <param name="dstRect">The dst rect</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_RenderCopy(
            IntPtr renderer,
            IntPtr texture,
            IntPtr srcRect,
            IntPtr dstRect
        );


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
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_RenderCopyEx(
            IntPtr renderer,
            IntPtr texture,
            ref SdlRect srcRect,
            ref SdlRect dstRect,
            double angle,
            ref SdlPoint center,
            SdlRendererFlip flip
        );


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
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_RenderCopyEx(
            IntPtr renderer,
            IntPtr texture,
            IntPtr srcRect,
            ref SdlRect dstRect,
            double angle,
            ref SdlPoint center,
            SdlRendererFlip flip
        );


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
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_RenderCopyEx(
            IntPtr renderer,
            IntPtr texture,
            ref SdlRect srcRect,
            IntPtr dstRect,
            double angle,
            ref SdlPoint center,
            SdlRendererFlip flip
        );


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
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_RenderCopyEx(
            IntPtr renderer,
            IntPtr texture,
            ref SdlRect srcRect,
            ref SdlRect dstRect,
            double angle,
            IntPtr center,
            SdlRendererFlip flip
        );


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
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_RenderCopyEx(
            IntPtr renderer,
            IntPtr texture,
            IntPtr srcRect,
            IntPtr dstRect,
            double angle,
            ref SdlPoint center,
            SdlRendererFlip flip
        );


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
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_RenderCopyEx(
            IntPtr renderer,
            IntPtr texture,
            IntPtr srcRect,
            ref SdlRect dstRect,
            double angle,
            IntPtr center,
            SdlRendererFlip flip
        );


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
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_RenderCopyEx(
            IntPtr renderer,
            IntPtr texture,
            ref SdlRect srcRect,
            IntPtr dstRect,
            double angle,
            IntPtr center,
            SdlRendererFlip flip
        );


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
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_RenderCopyEx(
            IntPtr renderer,
            IntPtr texture,
            IntPtr srcRect,
            IntPtr dstRect,
            double angle,
            IntPtr center,
            SdlRendererFlip flip
        );


        /// <summary>
        ///     Sdl the render draw line using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="x1">The </param>
        /// <param name="y1">The </param>
        /// <param name="x2">The </param>
        /// <param name="y2">The </param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_RenderDrawLine(
            IntPtr renderer,
            int x1,
            int y1,
            int x2,
            int y2
        );


        /// <summary>
        ///     Sdl the render draw lines using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="points">The points</param>
        /// <param name="count">The count</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_RenderDrawLines(
            IntPtr renderer,
            [In] SdlPoint[] points,
            int count
        );


        /// <summary>
        ///     Sdl the render draw point using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="x">The </param>
        /// <param name="y">The </param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_RenderDrawPoint(
            IntPtr renderer,
            int x,
            int y
        );


        /// <summary>
        ///     Sdl the render draw points using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="points">The points</param>
        /// <param name="count">The count</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_RenderDrawPoints(
            IntPtr renderer,
            [In] SdlPoint[] points,
            int count
        );


        /// <summary>
        ///     Sdl the render draw rect using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="rect">The rect</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_RenderDrawRect(
            IntPtr renderer,
            ref SdlRect rect
        );


        /// <summary>
        ///     Sdl the render draw rect using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="rect">The rect</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_RenderDrawRect(
            IntPtr renderer,
            IntPtr rect
        );


        /// <summary>
        ///     Sdl the render draw rects using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="rects">The rects</param>
        /// <param name="count">The count</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_RenderDrawRects(
            IntPtr renderer,
            [In] SdlRect[] rects,
            int count
        );


        /// <summary>
        ///     Sdl the render fill rect using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="rect">The rect</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_RenderFillRect(
            IntPtr renderer,
            ref SdlRect rect
        );


        /// <summary>
        ///     Sdl the render fill rect using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="rect">The rect</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_RenderFillRect(
            IntPtr renderer,
            IntPtr rect
        );


        /// <summary>
        ///     Sdl the render fill rects using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="rects">The rects</param>
        /// <param name="count">The count</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_RenderFillRects(
            IntPtr renderer,
            [In] SdlRect[] rects,
            int count
        );

        /// <summary>
        ///     Sdl the render copy f using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="texture">The texture</param>
        /// <param name="srcRect">The src rect</param>
        /// <param name="dstRect">The dst rect</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_RenderCopyF(
            IntPtr renderer,
            IntPtr texture,
            ref SdlRect srcRect,
            ref SdlFRect dstRect
        );


        /// <summary>
        ///     Sdl the render copy f using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="texture">The texture</param>
        /// <param name="srcRect">The src rect</param>
        /// <param name="dstRect">The dst rect</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_RenderCopyF(
            IntPtr renderer,
            IntPtr texture,
            IntPtr srcRect,
            ref SdlFRect dstRect
        );


        /// <summary>
        ///     Sdl the render copy f using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="texture">The texture</param>
        /// <param name="srcRect">The src rect</param>
        /// <param name="dstRect">The dst rect</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_RenderCopyF(
            IntPtr renderer,
            IntPtr texture,
            ref SdlRect srcRect,
            IntPtr dstRect
        );


        /// <summary>
        ///     Sdl the render copy f using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="texture">The texture</param>
        /// <param name="srcRect">The src rect</param>
        /// <param name="dstRect">The dst rect</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_RenderCopyF(
            IntPtr renderer,
            IntPtr texture,
            IntPtr srcRect,
            IntPtr dstRect
        );


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
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_RenderCopyEx(
            IntPtr renderer,
            IntPtr texture,
            ref SdlRect srcRect,
            ref SdlFRect dstRect,
            double angle,
            ref SdlFPoint center,
            SdlRendererFlip flip
        );


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
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_RenderCopyEx(
            IntPtr renderer,
            IntPtr texture,
            IntPtr srcRect,
            ref SdlFRect dstRect,
            double angle,
            ref SdlFPoint center,
            SdlRendererFlip flip
        );


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
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_RenderCopyExF(
            IntPtr renderer,
            IntPtr texture,
            ref SdlRect srcRect,
            IntPtr dstRect,
            double angle,
            ref SdlFPoint center,
            SdlRendererFlip flip
        );


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
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_RenderCopyExF(
            IntPtr renderer,
            IntPtr texture,
            ref SdlRect srcRect,
            ref SdlFRect dstRect,
            double angle,
            IntPtr center,
            SdlRendererFlip flip
        );


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
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_RenderCopyExF(
            IntPtr renderer,
            IntPtr texture,
            IntPtr srcRect,
            IntPtr dstRect,
            double angle,
            ref SdlFPoint center,
            SdlRendererFlip flip
        );


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
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_RenderCopyExF(
            IntPtr renderer,
            IntPtr texture,
            IntPtr srcRect,
            ref SdlFRect dstRect,
            double angle,
            IntPtr center,
            SdlRendererFlip flip
        );


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
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_RenderCopyExF(
            IntPtr renderer,
            IntPtr texture,
            ref SdlRect srcRect,
            IntPtr dstRect,
            double angle,
            IntPtr center,
            SdlRendererFlip flip
        );


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
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_RenderCopyExF(
            IntPtr renderer,
            IntPtr texture,
            IntPtr srcRect,
            IntPtr dstRect,
            double angle,
            IntPtr center,
            SdlRendererFlip flip
        );


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
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_RenderGeometry(
            IntPtr renderer,
            IntPtr texture,
            [In] SdlVertex[] vertices,
            int numVertices,
            [In] int[] indices,
            int numIndices
        );


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
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_RenderGeometryRaw(
            IntPtr renderer,
            IntPtr texture,
            [In] float[] xy,
            int xyStride,
            [In] int[] color,
            int colorStride,
            [In] float[] uv,
            int uvStride,
            int numVertices,
            IntPtr indices,
            int numIndices,
            int sizeIndices
        );


        /// <summary>
        ///     Sdl the render draw point f using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="x">The </param>
        /// <param name="y">The </param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_RenderDrawPointF(
            IntPtr renderer,
            float x,
            float y
        );


        /// <summary>
        ///     Sdl the render draw points f using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="points">The points</param>
        /// <param name="count">The count</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_RenderDrawPointsF(
            IntPtr renderer,
            [In] SdlFPoint[] points,
            int count
        );


        /// <summary>
        ///     Sdl the render draw line f using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="x1">The </param>
        /// <param name="y1">The </param>
        /// <param name="x2">The </param>
        /// <param name="y2">The </param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_RenderDrawLineF(
            IntPtr renderer,
            float x1,
            float y1,
            float x2,
            float y2
        );


        /// <summary>
        ///     Sdl the render draw lines f using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="points">The points</param>
        /// <param name="count">The count</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_RenderDrawLinesF(
            IntPtr renderer,
            [In] SdlFPoint[] points,
            int count
        );


        /// <summary>
        ///     Sdl the render draw rect f using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="rect">The rect</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_RenderDrawRectF(
            IntPtr renderer,
            ref SdlFRect rect
        );


        /// <summary>
        ///     Sdl the render draw rect f using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="rect">The rect</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_RenderDrawRectF(
            IntPtr renderer,
            IntPtr rect
        );


        /// <summary>
        ///     Sdl the render draw rects f using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="rects">The rects</param>
        /// <param name="count">The count</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_RenderDrawRectsF(
            IntPtr renderer,
            [In] SdlFRect[] rects,
            int count
        );


        /// <summary>
        ///     Sdl the render fill rect f using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="rect">The rect</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_RenderFillRectF(
            IntPtr renderer,
            ref SdlFRect rect
        );


        /// <summary>
        ///     Sdl the render fill rect f using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="rect">The rect</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_RenderFillRectF(
            IntPtr renderer,
            IntPtr rect
        );


        /// <summary>
        ///     Sdl the render fill rects f using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="rects">The rects</param>
        /// <param name="count">The count</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_RenderFillRectsF(
            IntPtr renderer,
            [In] SdlFRect[] rects,
            int count
        );


        /// <summary>
        ///     Sdl the render get clip rect using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="rect">The rect</param>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_RenderGetClipRect(
            IntPtr renderer,
            out SdlRect rect
        );


        /// <summary>
        ///     Sdl the render get logical size using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="w">The </param>
        /// <param name="h">The </param>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_RenderGetLogicalSize(
            IntPtr renderer,
            out int w,
            out int h
        );


        /// <summary>
        ///     Sdl the render get scale using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="scaleX">The scale</param>
        /// <param name="scaleY">The scale</param>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_RenderGetScale(
            IntPtr renderer,
            out float scaleX,
            out float scaleY
        );


        /// <summary>
        ///     Sdl the render window to logical using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="windowX">The window</param>
        /// <param name="windowY">The window</param>
        /// <param name="logicalX">The logical</param>
        /// <param name="logicalY">The logical</param>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_RenderWindowToLogical(
            IntPtr renderer,
            int windowX,
            int windowY,
            out float logicalX,
            out float logicalY
        );


        /// <summary>
        ///     Sdl the render logical to window using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="logicalX">The logical</param>
        /// <param name="logicalY">The logical</param>
        /// <param name="windowX">The window</param>
        /// <param name="windowY">The window</param>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_RenderLogicalToWindow(
            IntPtr renderer,
            float logicalX,
            float logicalY,
            out int windowX,
            out int windowY
        );


        /// <summary>
        ///     Sdl the render get viewport using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="rect">The rect</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_RenderGetViewport(
            IntPtr renderer,
            out SdlRect rect
        );


        /// <summary>
        ///     Sdl the render present using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_RenderPresent(IntPtr renderer);


        /// <summary>
        ///     Sdl the render read pixels using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="rect">The rect</param>
        /// <param name="format">The format</param>
        /// <param name="pixels">The pixels</param>
        /// <param name="pitch">The pitch</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_RenderReadPixels(
            IntPtr renderer,
            ref SdlRect rect,
            uint format,
            IntPtr pixels,
            int pitch
        );


        /// <summary>
        ///     Sdl the render set clip rect using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="rect">The rect</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_RenderSetClipRect(
            IntPtr renderer,
            ref SdlRect rect
        );


        /// <summary>
        ///     Sdl the render set clip rect using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="rect">The rect</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_RenderSetClipRect(
            IntPtr renderer,
            IntPtr rect
        );


        /// <summary>
        ///     Sdl the render set logical size using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="w">The </param>
        /// <param name="h">The </param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_RenderSetLogicalSize(
            IntPtr renderer,
            int w,
            int h
        );


        /// <summary>
        ///     Sdl the render set scale using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="scaleX">The scale</param>
        /// <param name="scaleY">The scale</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_RenderSetScale(
            IntPtr renderer,
            float scaleX,
            float scaleY
        );


        /// <summary>
        ///     Sdl the render set integer scale using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="enable">The enable</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_RenderSetIntegerScale(
            IntPtr renderer,
            SdlBool enable
        );


        /// <summary>
        ///     Sdl the render set viewport using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="rect">The rect</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_RenderSetViewport(
            IntPtr renderer,
            ref SdlRect rect
        );


        /// <summary>
        ///     Sdl the set render draw blend mode using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="blendMode">The blend mode</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_SetRenderDrawBlendMode(
            IntPtr renderer,
            SdlBlendMode blendMode
        );


        /// <summary>
        ///     Sdl the set render draw color using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="r">The </param>
        /// <param name="g">The </param>
        /// <param name="b">The </param>
        /// <param name="a">The </param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_SetRenderDrawColor(
            IntPtr renderer,
            byte r,
            byte g,
            byte b,
            byte a
        );


        /// <summary>
        ///     Sdl the set render target using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="texture">The texture</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_SetRenderTarget(
            IntPtr renderer,
            IntPtr texture
        );


        /// <summary>
        ///     Sdl the set texture alpha mod using the specified texture
        /// </summary>
        /// <param name="texture">The texture</param>
        /// <param name="alpha">The alpha</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_SetTextureAlphaMod(
            IntPtr texture,
            byte alpha
        );


        /// <summary>
        ///     Sdl the set texture blend mode using the specified texture
        /// </summary>
        /// <param name="texture">The texture</param>
        /// <param name="blendMode">The blend mode</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_SetTextureBlendMode(
            IntPtr texture,
            SdlBlendMode blendMode
        );


        /// <summary>
        ///     Sdl the set texture color mod using the specified texture
        /// </summary>
        /// <param name="texture">The texture</param>
        /// <param name="r">The </param>
        /// <param name="g">The </param>
        /// <param name="b">The </param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_SetTextureColorMod(
            IntPtr texture,
            byte r,
            byte g,
            byte b
        );


        /// <summary>
        ///     Sdl the unlock texture using the specified texture
        /// </summary>
        /// <param name="texture">The texture</param>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_UnlockTexture(IntPtr texture);


        /// <summary>
        ///     Sdl the update texture using the specified texture
        /// </summary>
        /// <param name="texture">The texture</param>
        /// <param name="rect">The rect</param>
        /// <param name="pixels">The pixels</param>
        /// <param name="pitch">The pitch</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_UpdateTexture(
            IntPtr texture,
            ref SdlRect rect,
            IntPtr pixels,
            int pitch
        );


        /// <summary>
        ///     Sdl the update texture using the specified texture
        /// </summary>
        /// <param name="texture">The texture</param>
        /// <param name="rect">The rect</param>
        /// <param name="pixels">The pixels</param>
        /// <param name="pitch">The pitch</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_UpdateTexture(
            IntPtr texture,
            IntPtr rect,
            IntPtr pixels,
            int pitch
        );


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
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_UpdateYUVTexture(
            IntPtr texture,
            ref SdlRect rect,
            IntPtr yPlane,
            int yPitch,
            IntPtr uPlane,
            int uPitch,
            IntPtr vPlane,
            int vPitch
        );


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
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_UpdateNVTexture(
            IntPtr texture,
            ref SdlRect rect,
            IntPtr yPlane,
            int yPitch,
            IntPtr uvPlane,
            int uvPitch
        );


        /// <summary>
        ///     Sdl the render target supported using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <returns>The sdl bool</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern SdlBool SDL_RenderTargetSupported(
            IntPtr renderer
        );


        /// <summary>
        ///     Sdl the get render target using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr SDL_GetRenderTarget(IntPtr renderer);


        /// <summary>
        ///     Sdl the render get metal layer using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr SDL_RenderGetMetalLayer(
            IntPtr renderer
        );


        /// <summary>
        ///     Sdl the render get metal command encoder using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr SDL_RenderGetMetalCommandEncoder(
            IntPtr renderer
        );


        /// <summary>
        ///     Sdl the render set v sync using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="vsync">The vsync</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_RenderSetVSync(IntPtr renderer, int vsync);


        /// <summary>
        ///     Sdl the render is clip enabled using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <returns>The sdl bool</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern SdlBool SDL_RenderIsClipEnabled(IntPtr renderer);


        /// <summary>
        ///     Sdl the render flush using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_RenderFlush(IntPtr renderer);

        /// <summary>
        ///     Sdl the define pixel fourcc using the specified a
        /// </summary>
        /// <param name="a">The </param>
        /// <param name="b">The </param>
        /// <param name="c">The </param>
        /// <param name="d">The </param>
        /// <returns>The uint</returns>
        private static uint SdlDefinePixelFourcc(byte a, byte b, byte c, byte d) => SDL_FOURCC(a, b, c, d);

        /// <summary>
        ///     Sdl the define pixel format using the specified type
        /// </summary>
        /// <param name="type">The type</param>
        /// <param name="order">The order</param>
        /// <param name="layout">The layout</param>
        /// <param name="bits">The bits</param>
        /// <param name="bytes">The bytes</param>
        /// <returns>The uint</returns>
        private static uint SdlDefinePixelFormat(
            SdlPixelType type,
            uint order,
            SdlPackedLayout layout,
            byte bits,
            byte bytes
        )
            => (uint) (
                (1 << 28) |
                ((byte) type << 24) |
                ((byte) order << 20) |
                ((byte) layout << 16) |
                (bits << 8) |
                bytes
            );

        /// <summary>
        ///     Sdl the pixel flag using the specified x
        /// </summary>
        /// <param name="x">The </param>
        /// <returns>The byte</returns>
        private static byte SdlPixelFlag(uint x) => (byte) ((x >> 28) & 0x0F);

        /// <summary>
        ///     Sdl the pixel type using the specified x
        /// </summary>
        /// <param name="x">The </param>
        /// <returns>The byte</returns>
        private static byte SdlPixelType(uint x) => (byte) ((x >> 24) & 0x0F);

        /// <summary>
        ///     Sdl the pixel order using the specified x
        /// </summary>
        /// <param name="x">The </param>
        /// <returns>The byte</returns>
        private static byte SdlPixelOrder(uint x) => (byte) ((x >> 20) & 0x0F);

        /// <summary>
        ///     Sdl the pixel layout using the specified x
        /// </summary>
        /// <param name="x">The </param>
        /// <returns>The byte</returns>
        public static byte SdlPixelLayout(uint x) => (byte) ((x >> 16) & 0x0F);

        /// <summary>
        ///     Sdl the bits per pixel using the specified x
        /// </summary>
        /// <param name="x">The </param>
        /// <returns>The byte</returns>
        public static byte SdlBitsPerPixel(uint x) => (byte) ((x >> 8) & 0xFF);

        /// <summary>
        ///     Sdl the bytes per pixel using the specified x
        /// </summary>
        /// <param name="x">The </param>
        /// <returns>The byte</returns>
        public static byte SdlBytesPerPixel(uint x)
        {
            if (SdlIsPixelFormatFour(x))
            {
                if (x == SdlPixelFormatYuy2 ||
                    x == SdlPixelFormatUy ||
                    x == SdlPixelFormatYv)
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
        public static bool SdlIsPixelFormatIndexed(uint format)
        {
            if (SdlIsPixelFormatFour(format))
            {
                return false;
            }

            SdlPixelType pType =
                (SdlPixelType) SdlPixelType(format);
            return pType == Enums.SdlPixelType.SdlPixeltypeIndex1 ||
                   pType == Enums.SdlPixelType.SdlPixeltypeIndex4 ||
                   pType == Enums.SdlPixelType.SdlPixeltypeIndex8;
        }

        /// <summary>
        ///     Describes whether sdl is pixel format packed
        /// </summary>
        /// <param name="format">The format</param>
        /// <returns>The bool</returns>
        private static bool SdlIsPixelFormatPacked(uint format)
        {
            if (SdlIsPixelFormatFour(format))
            {
                return false;
            }

            SdlPixelType pType =
                (SdlPixelType) SdlPixelType(format);
            return pType == Enums.SdlPixelType.SdlPixeltypePacked8 ||
                   pType == Enums.SdlPixelType.SdlPixeltypePacked16 ||
                   pType == Enums.SdlPixelType.SdlPixeltypePacked32;
        }

        /// <summary>
        ///     Describes whether sdl is pixel format array
        /// </summary>
        /// <param name="format">The format</param>
        /// <returns>The bool</returns>
        private static bool SdlIsPixelFormatArray(uint format)
        {
            if (SdlIsPixelFormatFour(format))
            {
                return false;
            }

            SdlPixelType pType =
                (SdlPixelType) SdlPixelType(format);
            return pType == Enums.SdlPixelType.SdlPixeltypeArrayu8 ||
                   pType == Enums.SdlPixelType.SdlPixeltypeArrayu16 ||
                   pType == Enums.SdlPixelType.SdlPixeltypeArrayu32 ||
                   pType == Enums.SdlPixelType.SdlPixeltypeArrayf16 ||
                   pType == Enums.SdlPixelType.SdlPixeltypeArrayf32;
        }

        /// <summary>
        ///     Describes whether sdl is pixel format alpha
        /// </summary>
        /// <param name="format">The format</param>
        /// <returns>The bool</returns>
        public static bool SdlIsPixelFormatAlpha(uint format)
        {
            if (SdlIsPixelFormatPacked(format))
            {
                SdlPackedOrder pOrder =
                    (SdlPackedOrder) SdlPixelOrder(format);
                return pOrder == SdlPackedOrder.SdlPackedorderArgb ||
                       pOrder == SdlPackedOrder.SdlPackedorderRgba ||
                       pOrder == SdlPackedOrder.SdlPackedorderAbgr ||
                       pOrder == SdlPackedOrder.SdlPackedorderBgra;
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
        private static bool SdlIsPixelFormatFour(uint format) => (format == 0) && (SdlPixelFlag(format) != 1);
        
        /// <summary>
        ///     Sdl the alloc format using the specified pixel format
        /// </summary>
        /// <param name="pixelFormat">The pixel format</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr SDL_AllocFormat(uint pixelFormat);


        /// <summary>
        ///     Sdl the alloc palette using the specified n colors
        /// </summary>
        /// <param name="nColors">The n colors</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr SDL_AllocPalette(int nColors);

        /// <summary>
        ///     Sdl the calculate gamma ramp using the specified gamma
        /// </summary>
        /// <param name="gamma">The gamma</param>
        /// <param name="ramp">The ramp</param>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_CalculateGammaRamp(
            float gamma,
            [Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U2, SizeConst = 256)]
            ushort[] ramp
        );


        /// <summary>
        ///     Sdl the free format using the specified format
        /// </summary>
        /// <param name="format">The format</param>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_FreeFormat(IntPtr format);


        /// <summary>
        ///     Sdl the free palette using the specified palette
        /// </summary>
        /// <param name="palette">The palette</param>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_FreePalette(IntPtr palette);

        /// <summary>
        ///     Internals the sdl get pixel format name using the specified format
        /// </summary>
        /// <param name="format">The format</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GetPixelFormatName", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr INTERNAL_SDL_GetPixelFormatName(
            uint format
        );

        /// <summary>
        ///     Sdl the get pixel format name using the specified format
        /// </summary>
        /// <param name="format">The format</param>
        /// <returns>The string</returns>
        public static string SDL_GetPixelFormatName(uint format) => Utf8ToManaged(
            INTERNAL_SDL_GetPixelFormatName(format)
        );


        /// <summary>
        ///     Sdl the get rgb using the specified pixel
        /// </summary>
        /// <param name="pixel">The pixel</param>
        /// <param name="format">The format</param>
        /// <param name="r">The </param>
        /// <param name="g">The </param>
        /// <param name="b">The </param>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_GetRGB(
            uint pixel,
            IntPtr format,
            out byte r,
            out byte g,
            out byte b
        );


        /// <summary>
        ///     Sdl the get rgba using the specified pixel
        /// </summary>
        /// <param name="pixel">The pixel</param>
        /// <param name="format">The format</param>
        /// <param name="r">The </param>
        /// <param name="g">The </param>
        /// <param name="b">The </param>
        /// <param name="a">The </param>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_GetRGBA(
            uint pixel,
            IntPtr format,
            out byte r,
            out byte g,
            out byte b,
            out byte a
        );


        /// <summary>
        ///     Sdl the map rgb using the specified format
        /// </summary>
        /// <param name="format">The format</param>
        /// <param name="r">The </param>
        /// <param name="g">The </param>
        /// <param name="b">The </param>
        /// <returns>The uint</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern uint SDL_MapRGB(
            IntPtr format,
            byte r,
            byte g,
            byte b
        );


        /// <summary>
        ///     Sdl the map rgba using the specified format
        /// </summary>
        /// <param name="format">The format</param>
        /// <param name="r">The </param>
        /// <param name="g">The </param>
        /// <param name="b">The </param>
        /// <param name="a">The </param>
        /// <returns>The uint</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern uint SDL_MapRGBA(
            IntPtr format,
            byte r,
            byte g,
            byte b,
            byte a
        );

        /// <summary>
        ///     Sdl the masks to pixel format enum using the specified bpp
        /// </summary>
        /// <param name="bpp">The bpp</param>
        /// <param name="rMask">The r mask</param>
        /// <param name="gMask">The g mask</param>
        /// <param name="bMask">The b mask</param>
        /// <param name="aMask">The a mask</param>
        /// <returns>The uint</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern uint SDL_MasksToPixelFormatEnum(
            int bpp,
            uint rMask,
            uint gMask,
            uint bMask,
            uint aMask
        );

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
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern SdlBool SDL_PixelFormatEnumToMasks(
            uint format,
            out int bpp,
            out uint rMask,
            out uint gMask,
            out uint bMask,
            out uint aMask
        );


        /// <summary>
        ///     Sdl the set palette colors using the specified palette
        /// </summary>
        /// <param name="palette">The palette</param>
        /// <param name="colors">The colors</param>
        /// <param name="firstColor">The first color</param>
        /// <param name="nColors">The n colors</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_SetPaletteColors(
            IntPtr palette,
            [In] SdlColor[] colors,
            int firstColor,
            int nColors
        );


        /// <summary>
        ///     Sdl the set pixel format palette using the specified format
        /// </summary>
        /// <param name="format">The format</param>
        /// <param name="palette">The palette</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_SetPixelFormatPalette(
            IntPtr format,
            IntPtr palette
        );

        /// <summary>
        ///     Sdl the point in rect using the specified p
        /// </summary>
        /// <param name="p">The </param>
        /// <param name="r">The </param>
        /// <returns>The sdl bool</returns>
        public static SdlBool SDL_PointInRect(ref SdlPoint p, ref SdlRect r) => (p.x >= r.x) &&
                                                                                (p.x < r.x + r.w) &&
                                                                                (p.y >= r.y) &&
                                                                                (p.y < r.y + r.h)
            ? SdlBool.SdlTrue
            : SdlBool.SdlFalse;

        /// <summary>
        ///     Sdl the enclose points using the specified points
        /// </summary>
        /// <param name="points">The points</param>
        /// <param name="count">The count</param>
        /// <param name="clip">The clip</param>
        /// <param name="result">The result</param>
        /// <returns>The sdl bool</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern SdlBool SDL_EnclosePoints(
            [In] SdlPoint[] points,
            int count,
            ref SdlRect clip,
            out SdlRect result
        );

        /// <summary>
        ///     Sdl the has intersection using the specified a
        /// </summary>
        /// <param name="a">The </param>
        /// <param name="b">The </param>
        /// <returns>The sdl bool</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern SdlBool SDL_HasIntersection(
            ref SdlRect a,
            ref SdlRect b
        );

        /// <summary>
        ///     Sdl the intersect rect using the specified a
        /// </summary>
        /// <param name="a">The </param>
        /// <param name="b">The </param>
        /// <param name="result">The result</param>
        /// <returns>The sdl bool</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern SdlBool SDL_IntersectRect(
            ref SdlRect a,
            ref SdlRect b,
            out SdlRect result
        );

        /// <summary>
        ///     Sdl the intersect rect and line using the specified rect
        /// </summary>
        /// <param name="rect">The rect</param>
        /// <param name="x1">The </param>
        /// <param name="y1">The </param>
        /// <param name="x2">The </param>
        /// <param name="y2">The </param>
        /// <returns>The sdl bool</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern SdlBool SDL_IntersectRectAndLine(
            ref SdlRect rect,
            ref int x1,
            ref int y1,
            ref int x2,
            ref int y2
        );

        /// <summary>
        ///     Sdl the rect empty using the specified r
        /// </summary>
        /// <param name="r">The </param>
        /// <returns>The sdl bool</returns>
        public static SdlBool SDL_RectEmpty(ref SdlRect r) => r.w <= 0 || r.h <= 0 ? SdlBool.SdlTrue : SdlBool.SdlFalse;

        /// <summary>
        ///     Sdl the rect equals using the specified a
        /// </summary>
        /// <param name="a">The </param>
        /// <param name="b">The </param>
        /// <returns>The sdl bool</returns>
        public static SdlBool SDL_RectEquals(
            ref SdlRect a,
            ref SdlRect b
        )
            => (a.x == b.x) &&
               (a.y == b.y) &&
               (a.w == b.w) &&
               (a.h == b.h)
                ? SdlBool.SdlTrue
                : SdlBool.SdlFalse;

        /// <summary>
        ///     Sdl the union rect using the specified a
        /// </summary>
        /// <param name="a">The </param>
        /// <param name="b">The </param>
        /// <param name="result">The result</param>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_UnionRect(
            ref SdlRect a,
            ref SdlRect b,
            out SdlRect result
        );


        /// <summary>
        ///     Describes whether sdl must lock
        /// </summary>
        /// <param name="surface">The surface</param>
        /// <returns>The bool</returns>
        public static bool SdlMustLock(IntPtr surface)
        {
            SdlSurface sur = (SdlSurface) Marshal.PtrToStructure(
                surface,
                typeof(SdlSurface)
            );
            return (sur.flags & SdlRleAccel) != 0;
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
        public static extern int SDL_BlitSurface(
            IntPtr src,
            ref SdlRect srcRect,
            IntPtr dst,
            ref SdlRect dstRect
        );


        /// <summary>
        ///     Sdl the blit surface using the specified src
        /// </summary>
        /// <param name="src">The src</param>
        /// <param name="srcRect">The src rect</param>
        /// <param name="dst">The dst</param>
        /// <param name="dstRect">The dst rect</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_UpperBlit", CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_BlitSurface(
            IntPtr src,
            IntPtr srcRect,
            IntPtr dst,
            ref SdlRect dstRect
        );


        /// <summary>
        ///     Sdl the blit surface using the specified src
        /// </summary>
        /// <param name="src">The src</param>
        /// <param name="srcRect">The src rect</param>
        /// <param name="dst">The dst</param>
        /// <param name="dstRect">The dst rect</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_UpperBlit", CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_BlitSurface(
            IntPtr src,
            ref SdlRect srcRect,
            IntPtr dst,
            IntPtr dstRect
        );


        /// <summary>
        ///     Sdl the blit surface using the specified src
        /// </summary>
        /// <param name="src">The src</param>
        /// <param name="srcRect">The src rect</param>
        /// <param name="dst">The dst</param>
        /// <param name="dstRect">The dst rect</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_UpperBlit", CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_BlitSurface(
            IntPtr src,
            IntPtr srcRect,
            IntPtr dst,
            IntPtr dstRect
        );


        /// <summary>
        ///     Sdl the blit scaled using the specified src
        /// </summary>
        /// <param name="src">The src</param>
        /// <param name="srcRect">The src rect</param>
        /// <param name="dst">The dst</param>
        /// <param name="dstRect">The dst rect</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_UpperBlitScaled", CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_BlitScaled(
            IntPtr src,
            ref SdlRect srcRect,
            IntPtr dst,
            ref SdlRect dstRect
        );


        /// <summary>
        ///     Sdl the blit scaled using the specified src
        /// </summary>
        /// <param name="src">The src</param>
        /// <param name="srcRect">The src rect</param>
        /// <param name="dst">The dst</param>
        /// <param name="dstRect">The dst rect</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_UpperBlitScaled", CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_BlitScaled(
            IntPtr src,
            IntPtr srcRect,
            IntPtr dst,
            ref SdlRect dstRect
        );


        /// <summary>
        ///     Sdl the blit scaled using the specified src
        /// </summary>
        /// <param name="src">The src</param>
        /// <param name="srcRect">The src rect</param>
        /// <param name="dst">The dst</param>
        /// <param name="dstRect">The dst rect</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_UpperBlitScaled", CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_BlitScaled(
            IntPtr src,
            ref SdlRect srcRect,
            IntPtr dst,
            IntPtr dstRect
        );


        /// <summary>
        ///     Sdl the blit scaled using the specified src
        /// </summary>
        /// <param name="src">The src</param>
        /// <param name="srcRect">The src rect</param>
        /// <param name="dst">The dst</param>
        /// <param name="dstRect">The dst rect</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_UpperBlitScaled", CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_BlitScaled(
            IntPtr src,
            IntPtr srcRect,
            IntPtr dst,
            IntPtr dstRect
        );


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
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_ConvertPixels(
            int width,
            int height,
            uint srcFormat,
            IntPtr src,
            int srcPitch,
            uint dstFormat,
            IntPtr dst,
            int dstPitch
        );


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
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_PremultiplyAlpha(
            int width,
            int height,
            uint srcFormat,
            IntPtr src,
            int srcPitch,
            uint dstFormat,
            IntPtr dst,
            int dstPitch
        );


        /// <summary>
        ///     Sdl the convert surface using the specified src
        /// </summary>
        /// <param name="src">The src</param>
        /// <param name="fmt">The fmt</param>
        /// <param name="flags">The flags</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr SDL_ConvertSurface(
            IntPtr src,
            IntPtr fmt,
            uint flags
        );


        /// <summary>
        ///     Sdl the convert surface format using the specified src
        /// </summary>
        /// <param name="src">The src</param>
        /// <param name="pixelFormat">The pixel format</param>
        /// <param name="flags">The flags</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr SDL_ConvertSurfaceFormat(
            IntPtr src,
            uint pixelFormat,
            uint flags
        );


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
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr SDL_CreateRGBSurface(
            uint flags,
            int width,
            int height,
            int depth,
            uint rMask,
            uint gMask,
            uint bMask,
            uint aMask
        );


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
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr SDL_CreateRGBSurfaceFrom(
            IntPtr pixels,
            int width,
            int height,
            int depth,
            int pitch,
            uint rMask,
            uint gMask,
            uint bMask,
            uint aMask
        );


        /// <summary>
        ///     Sdl the create rgb surface with format using the specified flags
        /// </summary>
        /// <param name="flags">The flags</param>
        /// <param name="width">The width</param>
        /// <param name="height">The height</param>
        /// <param name="depth">The depth</param>
        /// <param name="format">The format</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr SDL_CreateRGBSurfaceWithFormat(
            uint flags,
            int width,
            int height,
            int depth,
            uint format
        );


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
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr SDL_CreateRGBSurfaceWithFormatFrom(
            IntPtr pixels,
            int width,
            int height,
            int depth,
            int pitch,
            uint format
        );


        /// <summary>
        ///     Sdl the fill rect using the specified dst
        /// </summary>
        /// <param name="dst">The dst</param>
        /// <param name="rect">The rect</param>
        /// <param name="color">The color</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_FillRect(
            IntPtr dst,
            ref SdlRect rect,
            uint color
        );


        /// <summary>
        ///     Sdl the fill rect using the specified dst
        /// </summary>
        /// <param name="dst">The dst</param>
        /// <param name="rect">The rect</param>
        /// <param name="color">The color</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_FillRect(
            IntPtr dst,
            IntPtr rect,
            uint color
        );


        /// <summary>
        ///     Sdl the fill rects using the specified dst
        /// </summary>
        /// <param name="dst">The dst</param>
        /// <param name="rects">The rects</param>
        /// <param name="count">The count</param>
        /// <param name="color">The color</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_FillRects(
            IntPtr dst,
            [In] SdlRect[] rects,
            int count,
            uint color
        );


        /// <summary>
        ///     Sdl the free surface using the specified surface
        /// </summary>
        /// <param name="surface">The surface</param>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_FreeSurface(IntPtr surface);


        /// <summary>
        ///     Sdl the get clip rect using the specified surface
        /// </summary>
        /// <param name="surface">The surface</param>
        /// <param name="rect">The rect</param>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_GetClipRect(
            IntPtr surface,
            out SdlRect rect
        );


        /// <summary>
        ///     Sdl the has color key using the specified surface
        /// </summary>
        /// <param name="surface">The surface</param>
        /// <returns>The sdl bool</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern SdlBool SDL_HasColorKey(IntPtr surface);


        /// <summary>
        ///     Sdl the get color key using the specified surface
        /// </summary>
        /// <param name="surface">The surface</param>
        /// <param name="key">The key</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_GetColorKey(
            IntPtr surface,
            out uint key
        );


        /// <summary>
        ///     Sdl the get surface alpha mod using the specified surface
        /// </summary>
        /// <param name="surface">The surface</param>
        /// <param name="alpha">The alpha</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_GetSurfaceAlphaMod(
            IntPtr surface,
            out byte alpha
        );


        /// <summary>
        ///     Sdl the get surface blend mode using the specified surface
        /// </summary>
        /// <param name="surface">The surface</param>
        /// <param name="blendMode">The blend mode</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_GetSurfaceBlendMode(
            IntPtr surface,
            out SdlBlendMode blendMode
        );


        /// <summary>
        ///     Sdl the get surface color mod using the specified surface
        /// </summary>
        /// <param name="surface">The surface</param>
        /// <param name="r">The </param>
        /// <param name="g">The </param>
        /// <param name="b">The </param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_GetSurfaceColorMod(
            IntPtr surface,
            out byte r,
            out byte g,
            out byte b
        );


        /// <summary>
        ///     Internals the sdl load bmp rw using the specified src
        /// </summary>
        /// <param name="src">The src</param>
        /// <param name="freeSrc">The free src</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_LoadBMP_RW", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr INTERNAL_SDL_LoadBMP_RW(
            IntPtr src,
            int freeSrc
        );

        /// <summary>
        ///     Sdl the load bmp using the specified file
        /// </summary>
        /// <param name="file">The file</param>
        /// <returns>The int ptr</returns>
        public static IntPtr SDL_LoadBMP(string file)
        {
            return INTERNAL_SDL_LoadBMP_RW(SDL_RWFromFile(file, "rb"), 1);
        }


        /// <summary>
        ///     Sdl the lock surface using the specified surface
        /// </summary>
        /// <param name="surface">The surface</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_LockSurface(IntPtr surface);


        /// <summary>
        ///     Sdl the lower blit using the specified src
        /// </summary>
        /// <param name="src">The src</param>
        /// <param name="srcRect">The src rect</param>
        /// <param name="dst">The dst</param>
        /// <param name="dstRect">The dst rect</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_LowerBlit(
            IntPtr src,
            ref SdlRect srcRect,
            IntPtr dst,
            ref SdlRect dstRect
        );


        /// <summary>
        ///     Sdl the lower blit scaled using the specified src
        /// </summary>
        /// <param name="src">The src</param>
        /// <param name="srcRect">The src rect</param>
        /// <param name="dst">The dst</param>
        /// <param name="dstRect">The dst rect</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_LowerBlitScaled(
            IntPtr src,
            ref SdlRect srcRect,
            IntPtr dst,
            ref SdlRect dstRect
        );


        /// <summary>
        ///     Internals the sdl save bmp rw using the specified surface
        /// </summary>
        /// <param name="surface">The surface</param>
        /// <param name="src">The src</param>
        /// <param name="freeSrc">The free src</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_SaveBMP_RW", CallingConvention = CallingConvention.Cdecl)]
        private static extern int INTERNAL_SDL_SaveBMP_RW(
            IntPtr surface,
            IntPtr src,
            int freeSrc
        );

        /// <summary>
        ///     Sdl the save bmp using the specified surface
        /// </summary>
        /// <param name="surface">The surface</param>
        /// <param name="file">The file</param>
        /// <returns>The int</returns>
        public static int SDL_SaveBMP(IntPtr surface, string file)
        {
            return INTERNAL_SDL_SaveBMP_RW(surface, SDL_RWFromFile(file, "wb"), 1);
        }


        /// <summary>
        ///     Sdl the set clip rect using the specified surface
        /// </summary>
        /// <param name="surface">The surface</param>
        /// <param name="rect">The rect</param>
        /// <returns>The sdl bool</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern SdlBool SDL_SetClipRect(
            IntPtr surface,
            ref SdlRect rect
        );


        /// <summary>
        ///     Sdl the set color key using the specified surface
        /// </summary>
        /// <param name="surface">The surface</param>
        /// <param name="flag">The flag</param>
        /// <param name="key">The key</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_SetColorKey(
            IntPtr surface,
            int flag,
            uint key
        );


        /// <summary>
        ///     Sdl the set surface alpha mod using the specified surface
        /// </summary>
        /// <param name="surface">The surface</param>
        /// <param name="alpha">The alpha</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_SetSurfaceAlphaMod(
            IntPtr surface,
            byte alpha
        );


        /// <summary>
        ///     Sdl the set surface blend mode using the specified surface
        /// </summary>
        /// <param name="surface">The surface</param>
        /// <param name="blendMode">The blend mode</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_SetSurfaceBlendMode(
            IntPtr surface,
            SdlBlendMode blendMode
        );


        /// <summary>
        ///     Sdl the set surface color mod using the specified surface
        /// </summary>
        /// <param name="surface">The surface</param>
        /// <param name="r">The </param>
        /// <param name="g">The </param>
        /// <param name="b">The </param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_SetSurfaceColorMod(
            IntPtr surface,
            byte r,
            byte g,
            byte b
        );


        /// <summary>
        ///     Sdl the set surface palette using the specified surface
        /// </summary>
        /// <param name="surface">The surface</param>
        /// <param name="palette">The palette</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_SetSurfacePalette(
            IntPtr surface,
            IntPtr palette
        );


        /// <summary>
        ///     Sdl the set surface rle using the specified surface
        /// </summary>
        /// <param name="surface">The surface</param>
        /// <param name="flag">The flag</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_SetSurfaceRLE(
            IntPtr surface,
            int flag
        );


        /// <summary>
        ///     Sdl the has surface rle using the specified surface
        /// </summary>
        /// <param name="surface">The surface</param>
        /// <returns>The sdl bool</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern SdlBool SDL_HasSurfaceRLE(
            IntPtr surface
        );


        /// <summary>
        ///     Sdl the soft stretch using the specified src
        /// </summary>
        /// <param name="src">The src</param>
        /// <param name="srcRect">The src rect</param>
        /// <param name="dst">The dst</param>
        /// <param name="dstRect">The dst rect</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_SoftStretch(
            IntPtr src,
            ref SdlRect srcRect,
            IntPtr dst,
            ref SdlRect dstRect
        );
        
        /// <summary>
        ///     Sdl the soft stretch linear using the specified src
        /// </summary>
        /// <param name="src">The src</param>
        /// <param name="srcRect">The src rect</param>
        /// <param name="dst">The dst</param>
        /// <param name="dstRect">The dst rect</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_SoftStretchLinear(
            IntPtr src,
            ref SdlRect srcRect,
            IntPtr dst,
            ref SdlRect dstRect
        );


        /// <summary>
        ///     Sdl the unlock surface using the specified surface
        /// </summary>
        /// <param name="surface">The surface</param>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_UnlockSurface(IntPtr surface);


        /// <summary>
        ///     Sdl the upper blit using the specified src
        /// </summary>
        /// <param name="src">The src</param>
        /// <param name="srcRect">The src rect</param>
        /// <param name="dst">The dst</param>
        /// <param name="dstRect">The dst rect</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_UpperBlit(
            IntPtr src,
            ref SdlRect srcRect,
            IntPtr dst,
            ref SdlRect dstRect
        );


        /// <summary>
        ///     Sdl the upper blit scaled using the specified src
        /// </summary>
        /// <param name="src">The src</param>
        /// <param name="srcRect">The src rect</param>
        /// <param name="dst">The dst</param>
        /// <param name="dstRect">The dst rect</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_UpperBlitScaled(
            IntPtr src,
            ref SdlRect srcRect,
            IntPtr dst,
            ref SdlRect dstRect
        );


        /// <summary>
        ///     Sdl the duplicate surface using the specified surface
        /// </summary>
        /// <param name="surface">The surface</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr SDL_DuplicateSurface(IntPtr surface);

        /// <summary>
        ///     Sdl the has clipboard text
        /// </summary>
        /// <returns>The sdl bool</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern SdlBool SDL_HasClipboardText();

        /// <summary>
        ///     Internals the sdl get clipboard text
        /// </summary>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GetClipboardText", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr INTERNAL_SDL_GetClipboardText();

        /// <summary>
        ///     Sdl the get clipboard text
        /// </summary>
        /// <returns>The string</returns>
        public static string SDL_GetClipboardText() => Utf8ToManaged(INTERNAL_SDL_GetClipboardText(), true);

        /// <summary>
        ///     Internals the sdl set clipboard text using the specified text
        /// </summary>
        /// <param name="text">The text</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_SetClipboardText", CallingConvention = CallingConvention.Cdecl)]
        private static extern int INTERNAL_SDL_SetClipboardText(
            byte[] text
        );

        /// <summary>
        ///     Sdl the set clipboard text using the specified text
        /// </summary>
        /// <param name="text">The text</param>
        /// <returns>The result</returns>
        public static int SDL_SetClipboardText(
            string text
        )
        {
            byte[] utf8Text = Utf8EncodeHeap(text);
            int result = INTERNAL_SDL_SetClipboardText(
                utf8Text
            );
            return result;
        }

        /// <summary>
        ///     Sdl the pump events
        /// </summary>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_PumpEvents();

        /// <summary>
        ///     Sdl the peep events using the specified events
        /// </summary>
        /// <param name="events">The events</param>
        /// <param name="numEvents">The num events</param>
        /// <param name="action">The action</param>
        /// <param name="minType">The min type</param>
        /// <param name="maxType">The max type</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_PeepEvents(
            [Out] SdlEvent[] events,
            int numEvents,
            SdlEventAction action,
            SdlEventType minType,
            SdlEventType maxType
        );


        /// <summary>
        ///     Sdl the has event using the specified type
        /// </summary>
        /// <param name="type">The type</param>
        /// <returns>The sdl bool</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern SdlBool SDL_HasEvent(SdlEventType type);

        /// <summary>
        ///     Sdl the has events using the specified min type
        /// </summary>
        /// <param name="minType">The min type</param>
        /// <param name="maxType">The max type</param>
        /// <returns>The sdl bool</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern SdlBool SDL_HasEvents(
            SdlEventType minType,
            SdlEventType maxType
        );


        /// <summary>
        ///     Sdl the flush event using the specified type
        /// </summary>
        /// <param name="type">The type</param>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_FlushEvent(SdlEventType type);

        /// <summary>
        ///     Sdl the flush events using the specified min
        /// </summary>
        /// <param name="min">The min</param>
        /// <param name="max">The max</param>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_FlushEvents(
            SdlEventType min,
            SdlEventType max
        );


        /// <summary>
        ///     Sdl the poll event using the specified  event
        /// </summary>
        /// <param name="event">The event</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_PollEvent(out SdlEvent @event);


        /// <summary>
        ///     Sdl the wait event using the specified  event
        /// </summary>
        /// <param name="event">The event</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_WaitEvent(out SdlEvent @event);


        /// <summary>
        ///     Sdl the wait event timeout using the specified  event
        /// </summary>
        /// <param name="event">The event</param>
        /// <param name="timeout">The timeout</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_WaitEventTimeout(out SdlEvent @event, int timeout);


        /// <summary>
        ///     Sdl the push event using the specified  event
        /// </summary>
        /// <param name="event">The event</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_PushEvent(ref SdlEvent @event);


        /// <summary>
        ///     Sdl the set event filter using the specified filter
        /// </summary>
        /// <param name="filter">The filter</param>
        /// <param name="userdata">The userdata</param>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_SetEventFilter(
            SdlEventFilter filter,
            IntPtr userdata
        );


        /// <summary>
        ///     Sdl the get event filter using the specified filter
        /// </summary>
        /// <param name="filter">The filter</param>
        /// <param name="userdata">The userdata</param>
        /// <returns>The sdl bool</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        private static extern SdlBool SDL_GetEventFilter(
            out IntPtr filter,
            out IntPtr userdata
        );

        /// <summary>
        ///     Sdl the get event filter using the specified filter
        /// </summary>
        /// <param name="filter">The filter</param>
        /// <param name="userdata">The userdata</param>
        /// <returns>The ret val</returns>
        public static SdlBool SDL_GetEventFilter(
            out SdlEventFilter filter,
            out IntPtr userdata
        )
        {
            SdlBool val = SDL_GetEventFilter(out IntPtr result, out userdata);
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
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_AddEventWatch(
            SdlEventFilter filter,
            IntPtr userdata
        );


        /// <summary>
        ///     Sdl the del event watch using the specified filter
        /// </summary>
        /// <param name="filter">The filter</param>
        /// <param name="userdata">The userdata</param>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_DelEventWatch(
            SdlEventFilter filter,
            IntPtr userdata
        );


        /// <summary>
        ///     Sdl the filter events using the specified filter
        /// </summary>
        /// <param name="filter">The filter</param>
        /// <param name="userdata">The userdata</param>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_FilterEvents(
            SdlEventFilter filter,
            IntPtr userdata
        );

        /// <summary>
        ///     Sdl the event state using the specified type
        /// </summary>
        /// <param name="type">The type</param>
        /// <param name="state">The state</param>
        /// <returns>The byte</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        private static extern byte SDL_EventState(SdlEventType type, int state);

        /// <summary>
        ///     Sdl the get event state using the specified type
        /// </summary>
        /// <param name="type">The type</param>
        /// <returns>The byte</returns>
        public static byte SDL_GetEventState(SdlEventType type) => SDL_EventState(type, SdlQuery);


        /// <summary>
        ///     Sdl the register events using the specified num events
        /// </summary>
        /// <param name="numEvents">The num events</param>
        /// <returns>The int 32</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern uint SDL_RegisterEvents(int numEvents);

        /// <summary>
        ///     Sdl the scancode to keycode using the specified x
        /// </summary>
        /// <param name="x">The </param>
        /// <returns>The sdl keycode</returns>
        public static SdlKeycode SDL_SCANCODE_TO_KEYCODE(SdlScancode x) => (SdlKeycode) ((int) x | SdlKScancodeMask);

        /// <summary>
        ///     Sdl the get keyboard focus
        /// </summary>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr SDL_GetKeyboardFocus();

        /// <summary>
        ///     Sdl the get keyboard state using the specified num keys
        /// </summary>
        /// <param name="numKeys">The num keys</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr SDL_GetKeyboardState(out int numKeys);

        /// <summary>
        ///     Sdl the get mod state
        /// </summary>
        /// <returns>The sdl key mod</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern SdlKeymod SDL_GetModState();

        /// <summary>
        ///     Sdl the set mod state using the specified mod state
        /// </summary>
        /// <param name="modState">The mod state</param>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_SetModState(SdlKeymod modState);

        /// <summary>
        ///     Sdl the get key from scancode using the specified scancode
        /// </summary>
        /// <param name="scancode">The scancode</param>
        /// <returns>The sdl keycode</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern SdlKeycode SDL_GetKeyFromScancode(SdlScancode scancode);

        /// <summary>
        ///     Sdl the get scancode from key using the specified key
        /// </summary>
        /// <param name="key">The key</param>
        /// <returns>The sdl scancode</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern SdlScancode SDL_GetScancodeFromKey(SdlKeycode key);

        /// <summary>
        ///     Internals the sdl get scancode name using the specified scancode
        /// </summary>
        /// <param name="scancode">The scancode</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GetScancodeName", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr INTERNAL_SDL_GetScancodeName(SdlScancode scancode);

        /// <summary>
        ///     Sdl the get scancode name using the specified scancode
        /// </summary>
        /// <param name="scancode">The scancode</param>
        /// <returns>The string</returns>
        public static string SDL_GetScancodeName(SdlScancode scancode) => Utf8ToManaged(
            INTERNAL_SDL_GetScancodeName(scancode)
        );

        /// <summary>
        ///     Internals the sdl get scancode from name using the specified name
        /// </summary>
        /// <param name="name">The name</param>
        /// <returns>The sdl scancode</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GetScancodeFromName", CallingConvention = CallingConvention.Cdecl)]
        private static extern SdlScancode INTERNAL_SDL_GetScancodeFromName(
            byte[] name
        );

        /// <summary>
        ///     Sdl the get scancode from name using the specified name
        /// </summary>
        /// <param name="name">The name</param>
        /// <returns>The sdl scancode</returns>
        public static SdlScancode SDL_GetScancodeFromName(string name)
        {
            int utf8NameBufSize = Utf8Size(name);
            byte[] utf8Name = new byte[utf8NameBufSize];
            return INTERNAL_SDL_GetScancodeFromName(
                Utf8Encode(name, utf8Name, utf8NameBufSize)
            );
        }

        /// <summary>
        ///     Internals the sdl get key name using the specified key
        /// </summary>
        /// <param name="key">The key</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GetKeyName", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr INTERNAL_SDL_GetKeyName(SdlKeycode key);

        /// <summary>
        ///     Sdl the get key name using the specified key
        /// </summary>
        /// <param name="key">The key</param>
        /// <returns>The string</returns>
        public static string SDL_GetKeyName(SdlKeycode key) => Utf8ToManaged(INTERNAL_SDL_GetKeyName(key));

        /// <summary>
        ///     Internals the sdl get key from name using the specified name
        /// </summary>
        /// <param name="name">The name</param>
        /// <returns>The sdl keycode</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GetKeyFromName", CallingConvention = CallingConvention.Cdecl)]
        private static extern SdlKeycode INTERNAL_SDL_GetKeyFromName(
            byte[] name
        );

        /// <summary>
        ///     Sdl the get key from name using the specified name
        /// </summary>
        /// <param name="name">The name</param>
        /// <returns>The sdl keycode</returns>
        public static SdlKeycode SDL_GetKeyFromName(string name)
        {
            int utf8NameBufSize = Utf8Size(name);
            byte[] utf8Name = new byte[utf8NameBufSize];
            return INTERNAL_SDL_GetKeyFromName(
                Utf8Encode(name, utf8Name, utf8NameBufSize)
            );
        }

        /// <summary>
        ///     Sdl the start text input
        /// </summary>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_StartTextInput();

        /// <summary>
        ///     Sdl the is text input active
        /// </summary>
        /// <returns>The sdl bool</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern SdlBool SDL_IsTextInputActive();

        /// <summary>
        ///     Sdl the stop text input
        /// </summary>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_StopTextInput();

        /// <summary>
        ///     Sdl the set text input rect using the specified rect
        /// </summary>
        /// <param name="rect">The rect</param>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_SetTextInputRect(ref SdlRect rect);

        /// <summary>
        ///     Sdl the has screen keyboard support
        /// </summary>
        /// <returns>The sdl bool</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern SdlBool SDL_HasScreenKeyboardSupport();

        /// <summary>
        ///     Sdl the is screen keyboard shown using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <returns>The sdl bool</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern SdlBool SDL_IsScreenKeyboardShown(IntPtr window);

        /// <summary>
        ///     Sdl the get mouse focus
        /// </summary>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr SDL_GetMouseFocus();

        /// <summary>
        ///     Sdl the get mouse state using the specified x
        /// </summary>
        /// <param name="x">The </param>
        /// <param name="y">The </param>
        /// <returns>The int 32</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern uint SDL_GetMouseState(out int x, out int y);

        /// <summary>
        ///     Sdl the get mouse state using the specified x
        /// </summary>
        /// <param name="x">The </param>
        /// <param name="y">The </param>
        /// <returns>The int 32</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern uint SDL_GetMouseState(IntPtr x, out int y);

        /// <summary>
        ///     Sdl the get mouse state using the specified x
        /// </summary>
        /// <param name="x">The </param>
        /// <param name="y">The </param>
        /// <returns>The int 32</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern uint SDL_GetMouseState(out int x, IntPtr y);

        /// <summary>
        ///     Sdl the get mouse state using the specified x
        /// </summary>
        /// <param name="x">The </param>
        /// <param name="y">The </param>
        /// <returns>The int 32</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern uint SDL_GetMouseState(IntPtr x, IntPtr y);

        /// <summary>
        ///     Sdl the get global mouse state using the specified x
        /// </summary>
        /// <param name="x">The </param>
        /// <param name="y">The </param>
        /// <returns>The int 32</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern uint SDL_GetGlobalMouseState(out int x, out int y);

        /// <summary>
        ///     Sdl the get global mouse state using the specified x
        /// </summary>
        /// <param name="x">The </param>
        /// <param name="y">The </param>
        /// <returns>The int 32</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern uint SDL_GetGlobalMouseState(IntPtr x, out int y);

        /// <summary>
        ///     Sdl the get global mouse state using the specified x
        /// </summary>
        /// <param name="x">The </param>
        /// <param name="y">The </param>
        /// <returns>The int 32</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern uint SDL_GetGlobalMouseState(out int x, IntPtr y);

        /// <summary>
        ///     Sdl the get global mouse state using the specified x
        /// </summary>
        /// <param name="x">The </param>
        /// <param name="y">The </param>
        /// <returns>The int 32</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern uint SDL_GetGlobalMouseState(IntPtr x, IntPtr y);

        /// <summary>
        ///     Sdl the get relative mouse state using the specified x
        /// </summary>
        /// <param name="x">The </param>
        /// <param name="y">The </param>
        /// <returns>The int 32</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern uint SDL_GetRelativeMouseState(out int x, out int y);

        /// <summary>
        ///     Sdl the warp mouse in window using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="x">The </param>
        /// <param name="y">The </param>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_WarpMouseInWindow(IntPtr window, int x, int y);

        /// <summary>
        ///     Sdl the warp mouse global using the specified x
        /// </summary>
        /// <param name="x">The </param>
        /// <param name="y">The </param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_WarpMouseGlobal(int x, int y);

        /// <summary>
        ///     Sdl the set relative mouse mode using the specified enabled
        /// </summary>
        /// <param name="enabled">The enabled</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_SetRelativeMouseMode(SdlBool enabled);

        /// <summary>
        ///     Sdl the capture mouse using the specified enabled
        /// </summary>
        /// <param name="enabled">The enabled</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_CaptureMouse(SdlBool enabled);

        /// <summary>
        ///     Sdl the get relative mouse mode
        /// </summary>
        /// <returns>The sdl bool</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern SdlBool SDL_GetRelativeMouseMode();

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
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr SDL_CreateCursor(
            IntPtr data,
            IntPtr mask,
            int w,
            int h,
            int hotX,
            int hotY
        );

        /// <summary>
        ///     Sdl the create color cursor using the specified surface
        /// </summary>
        /// <param name="surface">The surface</param>
        /// <param name="hotX">The hot</param>
        /// <param name="hotY">The hot</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr SDL_CreateColorCursor(
            IntPtr surface,
            int hotX,
            int hotY
        );

        /// <summary>
        ///     Sdl the create system cursor using the specified id
        /// </summary>
        /// <param name="id">The id</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr SDL_CreateSystemCursor(SdlSystemCursor id);

        /// <summary>
        ///     Sdl the set cursor using the specified cursor
        /// </summary>
        /// <param name="cursor">The cursor</param>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_SetCursor(IntPtr cursor);

        /// <summary>
        ///     Sdl the get cursor
        /// </summary>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr SDL_GetCursor();

        /// <summary>
        ///     Sdl the free cursor using the specified cursor
        /// </summary>
        /// <param name="cursor">The cursor</param>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_FreeCursor(IntPtr cursor);

        /// <summary>
        ///     Sdl the show cursor using the specified toggle
        /// </summary>
        /// <param name="toggle">The toggle</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_ShowCursor(int toggle);

        /// <summary>
        ///     Sdl the button using the specified x
        /// </summary>
        /// <param name="x">The </param>
        /// <returns>The uint</returns>
        public static uint SDL_BUTTON(uint x) =>
            // If only there were a better way of doing this in C#
            (uint) (1 << ((int) x - 1));

        /// <summary>
        ///     Sdl the get num touch devices
        /// </summary>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_GetNumTouchDevices();


        /// <summary>
        ///     Sdl the get touch device using the specified index
        /// </summary>
        /// <param name="index">The index</param>
        /// <returns>The long</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern long SDL_GetTouchDevice(int index);

        /// <summary>
        ///     Sdl the get num touch fingers using the specified touch id
        /// </summary>
        /// <param name="touchId">The touch id</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_GetNumTouchFingers(long touchId);

        /// <summary>
        ///     Sdl the get touch finger using the specified touch id
        /// </summary>
        /// <param name="touchId">The touch id</param>
        /// <param name="index">The index</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr SDL_GetTouchFinger(long touchId, int index);

        /// <summary>
        ///     Sdl the get touch device type using the specified touch id
        /// </summary>
        /// <param name="touchId">The touch id</param>
        /// <returns>The sdl touch device type</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern SdlTouchDeviceType SDL_GetTouchDeviceType(long touchId);


        /// <summary>
        ///     Sdl the joystick rumble using the specified joystick
        /// </summary>
        /// <param name="joystick">The joystick</param>
        /// <param name="lowFrequencyRumble">The low frequency rumble</param>
        /// <param name="highFrequencyRumble">The high frequency rumble</param>
        /// <param name="durationMs">The duration ms</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_JoystickRumble(
            IntPtr joystick,
            ushort lowFrequencyRumble,
            ushort highFrequencyRumble,
            uint durationMs
        );


        /// <summary>
        ///     Sdl the joystick rumble triggers using the specified joystick
        /// </summary>
        /// <param name="joystick">The joystick</param>
        /// <param name="leftRumble">The left rumble</param>
        /// <param name="rightRumble">The right rumble</param>
        /// <param name="durationMs">The duration ms</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_JoystickRumbleTriggers(
            IntPtr joystick,
            ushort leftRumble,
            ushort rightRumble,
            uint durationMs
        );


        /// <summary>
        ///     Sdl the joystick close using the specified joystick
        /// </summary>
        /// <param name="joystick">The joystick</param>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_JoystickClose(IntPtr joystick);

        /// <summary>
        ///     Sdl the joystick event state using the specified state
        /// </summary>
        /// <param name="state">The state</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_JoystickEventState(int state);


        /// <summary>
        ///     Sdl the joystick get axis using the specified joystick
        /// </summary>
        /// <param name="joystick">The joystick</param>
        /// <param name="axis">The axis</param>
        /// <returns>The short</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern short SDL_JoystickGetAxis(
            IntPtr joystick,
            int axis
        );


        /// <summary>
        ///     Sdl the joystick get axis initial state using the specified joystick
        /// </summary>
        /// <param name="joystick">The joystick</param>
        /// <param name="axis">The axis</param>
        /// <param name="state">The state</param>
        /// <returns>The sdl bool</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern SdlBool SDL_JoystickGetAxisInitialState(
            IntPtr joystick,
            int axis,
            out ushort state
        );


        /// <summary>
        ///     Sdl the joystick get ball using the specified joystick
        /// </summary>
        /// <param name="joystick">The joystick</param>
        /// <param name="ball">The ball</param>
        /// <param name="dx">The dx</param>
        /// <param name="dy">The dy</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_JoystickGetBall(
            IntPtr joystick,
            int ball,
            out int dx,
            out int dy
        );


        /// <summary>
        ///     Sdl the joystick get button using the specified joystick
        /// </summary>
        /// <param name="joystick">The joystick</param>
        /// <param name="button">The button</param>
        /// <returns>The byte</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern byte SDL_JoystickGetButton(
            IntPtr joystick,
            int button
        );


        /// <summary>
        ///     Sdl the joystick get hat using the specified joystick
        /// </summary>
        /// <param name="joystick">The joystick</param>
        /// <param name="hat">The hat</param>
        /// <returns>The byte</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern byte SDL_JoystickGetHat(
            IntPtr joystick,
            int hat
        );


        /// <summary>
        ///     Internals the sdl joystick name using the specified joystick
        /// </summary>
        /// <param name="joystick">The joystick</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_JoystickName", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr INTERNAL_SDL_JoystickName(
            IntPtr joystick
        );

        /// <summary>
        ///     Sdl the joystick name using the specified joystick
        /// </summary>
        /// <param name="joystick">The joystick</param>
        /// <returns>The string</returns>
        public static string SDL_JoystickName(IntPtr joystick) => Utf8ToManaged(
            INTERNAL_SDL_JoystickName(joystick)
        );

        /// <summary>
        ///     Internals the sdl joystick name for index using the specified device index
        /// </summary>
        /// <param name="deviceIndex">The device index</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_JoystickNameForIndex", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr INTERNAL_SDL_JoystickNameForIndex(
            int deviceIndex
        );

        /// <summary>
        ///     Sdl the joystick name for index using the specified device index
        /// </summary>
        /// <param name="deviceIndex">The device index</param>
        /// <returns>The string</returns>
        public static string SDL_JoystickNameForIndex(int deviceIndex) => Utf8ToManaged(
            INTERNAL_SDL_JoystickNameForIndex(deviceIndex)
        );


        /// <summary>
        ///     Sdl the joystick num axes using the specified joystick
        /// </summary>
        /// <param name="joystick">The joystick</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_JoystickNumAxes(IntPtr joystick);


        /// <summary>
        ///     Sdl the joystick num balls using the specified joystick
        /// </summary>
        /// <param name="joystick">The joystick</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_JoystickNumBalls(IntPtr joystick);


        /// <summary>
        ///     Sdl the joystick num buttons using the specified joystick
        /// </summary>
        /// <param name="joystick">The joystick</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_JoystickNumButtons(IntPtr joystick);


        /// <summary>
        ///     Sdl the joystick num hats using the specified joystick
        /// </summary>
        /// <param name="joystick">The joystick</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_JoystickNumHats(IntPtr joystick);


        /// <summary>
        ///     Sdl the joystick open using the specified device index
        /// </summary>
        /// <param name="deviceIndex">The device index</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr SDL_JoystickOpen(int deviceIndex);


        /// <summary>
        ///     Sdl the joystick update
        /// </summary>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_JoystickUpdate();


        /// <summary>
        ///     Sdl the num joysticks
        /// </summary>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_NumJoysticks();

        /// <summary>
        ///     Sdl the joystick get device guid using the specified device index
        /// </summary>
        /// <param name="deviceIndex">The device index</param>
        /// <returns>The guid</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern Guid SDL_JoystickGetDeviceGUID(
            int deviceIndex
        );


        /// <summary>
        ///     Sdl the joystick get guid using the specified joystick
        /// </summary>
        /// <param name="joystick">The joystick</param>
        /// <returns>The guid</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern Guid SDL_JoystickGetGUID(
            IntPtr joystick
        );

        /// <summary>
        ///     Sdl the joystick get guid string using the specified guid
        /// </summary>
        /// <param name="guid">The guid</param>
        /// <param name="pszGuid">The psz guid</param>
        /// <param name="cbGuid">The cb guid</param>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_JoystickGetGUIDString(
            Guid guid,
            byte[] pszGuid,
            int cbGuid
        );

        /// <summary>
        ///     Internals the sdl joystick get guid from string using the specified pch guid
        /// </summary>
        /// <param name="pchGuid">The pch guid</param>
        /// <returns>The guid</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_JoystickGetGUIDFromString", CallingConvention = CallingConvention.Cdecl)]
        private static extern Guid INTERNAL_SDL_JoystickGetGUIDFromString(
            byte[] pchGuid
        );

        /// <summary>
        ///     Sdl the joystick get guid from string using the specified pch guid
        /// </summary>
        /// <param name="pchGuid">The pch guid</param>
        /// <returns>The guid</returns>
        public static Guid SDL_JoystickGetGUIDFromString(string pchGuid)
        {
            int utf8PchGuidBufSize = Utf8Size(pchGuid);
            byte[] utf8PchGuid = new byte[utf8PchGuidBufSize];
            return INTERNAL_SDL_JoystickGetGUIDFromString(
                Utf8Encode(pchGuid, utf8PchGuid, utf8PchGuidBufSize)
            );
        }


        /// <summary>
        ///     Sdl the joystick get device vendor using the specified device index
        /// </summary>
        /// <param name="deviceIndex">The device index</param>
        /// <returns>The ushort</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern ushort SDL_JoystickGetDeviceVendor(int deviceIndex);


        /// <summary>
        ///     Sdl the joystick get device product using the specified device index
        /// </summary>
        /// <param name="deviceIndex">The device index</param>
        /// <returns>The ushort</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern ushort SDL_JoystickGetDeviceProduct(int deviceIndex);


        /// <summary>
        ///     Sdl the joystick get device product version using the specified device index
        /// </summary>
        /// <param name="deviceIndex">The device index</param>
        /// <returns>The ushort</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern ushort SDL_JoystickGetDeviceProductVersion(int deviceIndex);


        /// <summary>
        ///     Sdl the joystick get device type using the specified device index
        /// </summary>
        /// <param name="deviceIndex">The device index</param>
        /// <returns>The sdl joystick type</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern SdlJoystickType SDL_JoystickGetDeviceType(int deviceIndex);


        /// <summary>
        ///     Sdl the joystick get device instance id using the specified device index
        /// </summary>
        /// <param name="deviceIndex">The device index</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_JoystickGetDeviceInstanceID(int deviceIndex);


        /// <summary>
        ///     Sdl the joystick get vendor using the specified joystick
        /// </summary>
        /// <param name="joystick">The joystick</param>
        /// <returns>The ushort</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern ushort SDL_JoystickGetVendor(IntPtr joystick);


        /// <summary>
        ///     Sdl the joystick get product using the specified joystick
        /// </summary>
        /// <param name="joystick">The joystick</param>
        /// <returns>The ushort</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern ushort SDL_JoystickGetProduct(IntPtr joystick);


        /// <summary>
        ///     Sdl the joystick get product version using the specified joystick
        /// </summary>
        /// <param name="joystick">The joystick</param>
        /// <returns>The ushort</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern ushort SDL_JoystickGetProductVersion(IntPtr joystick);


        /// <summary>
        ///     Internals the sdl joystick get serial using the specified joystick
        /// </summary>
        /// <param name="joystick">The joystick</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_JoystickGetSerial", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr INTERNAL_SDL_JoystickGetSerial(
            IntPtr joystick
        );

        /// <summary>
        ///     Sdl the joystick get serial using the specified joystick
        /// </summary>
        /// <param name="joystick">The joystick</param>
        /// <returns>The string</returns>
        public static string SDL_JoystickGetSerial(
            IntPtr joystick
        )
            => Utf8ToManaged(
                INTERNAL_SDL_JoystickGetSerial(joystick)
            );


        /// <summary>
        ///     Sdl the joystick get type using the specified joystick
        /// </summary>
        /// <param name="joystick">The joystick</param>
        /// <returns>The sdl joystick type</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern SdlJoystickType SDL_JoystickGetType(IntPtr joystick);


        /// <summary>
        ///     Sdl the joystick get attached using the specified joystick
        /// </summary>
        /// <param name="joystick">The joystick</param>
        /// <returns>The sdl bool</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern SdlBool SDL_JoystickGetAttached(IntPtr joystick);


        /// <summary>
        ///     Sdl the joystick instance id using the specified joystick
        /// </summary>
        /// <param name="joystick">The joystick</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_JoystickInstanceID(IntPtr joystick);


        /// <summary>
        ///     Sdl the joystick current power level using the specified joystick
        /// </summary>
        /// <param name="joystick">The joystick</param>
        /// <returns>The sdl joystick power level</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern SdlJoystickPowerLevel SDL_JoystickCurrentPowerLevel(
            IntPtr joystick
        );


        /// <summary>
        ///     Sdl the joystick from instance id using the specified instance id
        /// </summary>
        /// <param name="instanceId">The instance id</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr SDL_JoystickFromInstanceID(int instanceId);


        /// <summary>
        ///     Sdl the lock joysticks
        /// </summary>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_LockJoysticks();
        
        /// <summary>
        ///     Sdl the unlock joysticks
        /// </summary>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_UnlockJoysticks();
        
        /// <summary>
        ///     Sdl the joystick from player index using the specified player index
        /// </summary>
        /// <param name="playerIndex">The player index</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr SDL_JoystickFromPlayerIndex(int playerIndex);
        
        /// <summary>
        ///     Sdl the joystick set player index using the specified joystick
        /// </summary>
        /// <param name="joystick">The joystick</param>
        /// <param name="playerIndex">The player index</param>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_JoystickSetPlayerIndex(IntPtr joystick, int playerIndex);
        
        /// <summary>
        ///     Sdl the joystick attach virtual using the specified type
        /// </summary>
        /// <param name="type">The type</param>
        /// <param name="nAxes">The n axes</param>
        /// <param name="nButtons">The n buttons</param>
        /// <param name="nHats">The n hats</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        private static extern int SDL_JoystickAttachVirtual(int type, int nAxes, int nButtons, int nHats);
        
        /// <summary>
        /// Sdl the joystick attach virtual using the specified type
        /// </summary>
        /// <param name="type">The type</param>
        /// <param name="nAxes">The axes</param>
        /// <param name="nButtons">The buttons</param>
        /// <param name="nHats">The hats</param>
        /// <returns>The int</returns>
        public static int SdlJoystickAttachVirtual(int type, int nAxes, int nButtons, int nHats) => SDL_JoystickAttachVirtual(type, nAxes, nButtons, nHats);
        
        /// <summary>
        ///     Sdl the joystick detach virtual using the specified device index
        /// </summary>
        /// <param name="deviceIndex">The device index</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_JoystickDetachVirtual(int deviceIndex);


        /// <summary>
        ///     Sdl the joystick is virtual using the specified device index
        /// </summary>
        /// <param name="deviceIndex">The device index</param>
        /// <returns>The sdl bool</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern SdlBool SDL_JoystickIsVirtual(int deviceIndex);


        /// <summary>
        ///     Sdl the joystick set virtual axis using the specified joystick
        /// </summary>
        /// <param name="joystick">The joystick</param>
        /// <param name="axis">The axis</param>
        /// <param name="value">The value</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_JoystickSetVirtualAxis(
            IntPtr joystick,
            int axis,
            short value
        );


        /// <summary>
        ///     Sdl the joystick set virtual button using the specified joystick
        /// </summary>
        /// <param name="joystick">The joystick</param>
        /// <param name="button">The button</param>
        /// <param name="value">The value</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_JoystickSetVirtualButton(
            IntPtr joystick,
            int button,
            byte value
        );


        /// <summary>
        ///     Sdl the joystick set virtual hat using the specified joystick
        /// </summary>
        /// <param name="joystick">The joystick</param>
        /// <param name="hat">The hat</param>
        /// <param name="value">The value</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_JoystickSetVirtualHat(
            IntPtr joystick,
            int hat,
            byte value
        );


        /// <summary>
        ///     Sdl the joystick has led using the specified joystick
        /// </summary>
        /// <param name="joystick">The joystick</param>
        /// <returns>The sdl bool</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern SdlBool SDL_JoystickHasLED(IntPtr joystick);


        /// <summary>
        ///     Sdl the joystick has rumble using the specified joystick
        /// </summary>
        /// <param name="joystick">The joystick</param>
        /// <returns>The sdl bool</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern SdlBool SDL_JoystickHasRumble(IntPtr joystick);


        /// <summary>
        ///     Sdl the joystick has rumble triggers using the specified joystick
        /// </summary>
        /// <param name="joystick">The joystick</param>
        /// <returns>The sdl bool</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern SdlBool SDL_JoystickHasRumbleTriggers(IntPtr joystick);


        /// <summary>
        ///     Sdl the joystick set led using the specified joystick
        /// </summary>
        /// <param name="joystick">The joystick</param>
        /// <param name="red">The red</param>
        /// <param name="green">The green</param>
        /// <param name="blue">The blue</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_JoystickSetLED(
            IntPtr joystick,
            byte red,
            byte green,
            byte blue
        );


        /// <summary>
        ///     Sdl the joystick send effect using the specified joystick
        /// </summary>
        /// <param name="joystick">The joystick</param>
        /// <param name="data">The data</param>
        /// <param name="size">The size</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_JoystickSendEffect(
            IntPtr joystick,
            IntPtr data,
            int size
        );


        // FIXME: I'd rather this somehow be private...

        // FIXME: I'd rather this somehow be private...


        /// <summary>
        ///     Internals the sdl game controller add mapping using the specified mapping string
        /// </summary>
        /// <param name="mappingString">The mapping string</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GameControllerAddMapping", CallingConvention = CallingConvention.Cdecl)]
        private static extern int INTERNAL_SDL_GameControllerAddMapping(
            byte[] mappingString
        );

        /// <summary>
        ///     Sdl the game controller add mapping using the specified mapping string
        /// </summary>
        /// <param name="mappingString">The mapping string</param>
        /// <returns>The result</returns>
        public static int SDL_GameControllerAddMapping(
            string mappingString
        )
        {
            byte[] utf8MappingString = Utf8EncodeHeap(mappingString);
            int result = INTERNAL_SDL_GameControllerAddMapping(
                utf8MappingString
            );
            return result;
        }


        /// <summary>
        ///     Sdl the game controller num mappings
        /// </summary>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_GameControllerNumMappings();


        /// <summary>
        ///     Internals the sdl game controller mapping for index using the specified mapping index
        /// </summary>
        /// <param name="mappingIndex">The mapping index</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GameControllerMappingForIndex", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr INTERNAL_SDL_GameControllerMappingForIndex(int mappingIndex);

        /// <summary>
        ///     Sdl the game controller mapping for index using the specified mapping index
        /// </summary>
        /// <param name="mappingIndex">The mapping index</param>
        /// <returns>The string</returns>
        public static string SDL_GameControllerMappingForIndex(int mappingIndex) => Utf8ToManaged(
            INTERNAL_SDL_GameControllerMappingForIndex(
                mappingIndex
            ),
            true
        );


        /// <summary>
        ///     Internals the sdl game controller add mappings from rw using the specified rw
        /// </summary>
        /// <param name="rw">The rw</param>
        /// <param name="freeRw">The free rw</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GameControllerAddMappingsFromRW", CallingConvention = CallingConvention.Cdecl)]
        private static extern int INTERNAL_SDL_GameControllerAddMappingsFromRW(IntPtr rw, int freeRw);

        /// <summary>
        ///     Sdl the game controller add mappings from file using the specified file
        /// </summary>
        /// <param name="file">The file</param>
        /// <returns>The int</returns>
        public static int SdlGameControllerAddMappingsFromFile(string file) => INTERNAL_SDL_GameControllerAddMappingsFromRW(SDL_RWFromFile(file, "rb"), 1);

        /// <summary>
        ///     Internals the sdl game controller mapping for guid using the specified guid
        /// </summary>
        /// <param name="guid">The guid</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GameControllerMappingForGUID", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr INTERNAL_SDL_GameControllerMappingForGUID(
            Guid guid
        );

        /// <summary>
        ///     Sdl the game controller mapping for guid using the specified guid
        /// </summary>
        /// <param name="guid">The guid</param>
        /// <returns>The string</returns>
        public static string SDL_GameControllerMappingForGUID(Guid guid) => Utf8ToManaged(
            INTERNAL_SDL_GameControllerMappingForGUID(guid),
            true
        );


        /// <summary>
        ///     Internals the sdl game controller mapping using the specified game controller
        /// </summary>
        /// <param name="gameController">The game controller</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GameControllerMapping", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr INTERNAL_SDL_GameControllerMapping(
            IntPtr gameController
        );

        /// <summary>
        ///     Sdl the game controller mapping using the specified game controller
        /// </summary>
        /// <param name="gameController">The game controller</param>
        /// <returns>The string</returns>
        public static string SDL_GameControllerMapping(
            IntPtr gameController
        )
            => Utf8ToManaged(
                INTERNAL_SDL_GameControllerMapping(
                    gameController
                ),
                true
            );

        /// <summary>
        ///     Sdl the is game controller using the specified joystick index
        /// </summary>
        /// <param name="joystickIndex">The joystick index</param>
        /// <returns>The sdl bool</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern SdlBool SDL_IsGameController(int joystickIndex);

        /// <summary>
        ///     Internals the sdl game controller name for index using the specified joystick index
        /// </summary>
        /// <param name="joystickIndex">The joystick index</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GameControllerNameForIndex", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr INTERNAL_SDL_GameControllerNameForIndex(
            int joystickIndex
        );

        /// <summary>
        ///     Sdl the game controller name for index using the specified joystick index
        /// </summary>
        /// <param name="joystickIndex">The joystick index</param>
        /// <returns>The string</returns>
        public static string SDL_GameControllerNameForIndex(
            int joystickIndex
        )
            => Utf8ToManaged(
                INTERNAL_SDL_GameControllerNameForIndex(joystickIndex)
            );


        /// <summary>
        ///     Internals the sdl game controller mapping for device index using the specified joystick index
        /// </summary>
        /// <param name="joystickIndex">The joystick index</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GameControllerMappingForDeviceIndex", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr INTERNAL_SDL_GameControllerMappingForDeviceIndex(
            int joystickIndex
        );

        /// <summary>
        ///     Sdl the game controller mapping for device index using the specified joystick index
        /// </summary>
        /// <param name="joystickIndex">The joystick index</param>
        /// <returns>The string</returns>
        public static string SDL_GameControllerMappingForDeviceIndex(
            int joystickIndex
        )
            => Utf8ToManaged(
                INTERNAL_SDL_GameControllerMappingForDeviceIndex(joystickIndex),
                true
            );


        /// <summary>
        ///     Sdl the game controller open using the specified joystick index
        /// </summary>
        /// <param name="joystickIndex">The joystick index</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr SDL_GameControllerOpen(int joystickIndex);


        /// <summary>
        ///     Internals the sdl game controller name using the specified game controller
        /// </summary>
        /// <param name="gameController">The game controller</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GameControllerName", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr INTERNAL_SDL_GameControllerName(
            IntPtr gameController
        );

        /// <summary>
        ///     Sdl the game controller name using the specified game controller
        /// </summary>
        /// <param name="gameController">The game controller</param>
        /// <returns>The string</returns>
        public static string SDL_GameControllerName(
            IntPtr gameController
        )
            => Utf8ToManaged(
                INTERNAL_SDL_GameControllerName(gameController)
            );
        
        /// <summary>
        ///     Sdl the game controller get vendor using the specified game controller
        /// </summary>
        /// <param name="gameController">The game controller</param>
        /// <returns>The ushort</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern ushort SDL_GameControllerGetVendor(
            IntPtr gameController
        );
        
        /// <summary>
        ///     Sdl the game controller get product using the specified game controller
        /// </summary>
        /// <param name="gameController">The game controller</param>
        /// <returns>The ushort</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern ushort SDL_GameControllerGetProduct(
            IntPtr gameController
        );


        /// <summary>
        ///     Sdl the game controller get product version using the specified game controller
        /// </summary>
        /// <param name="gameController">The game controller</param>
        /// <returns>The ushort</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern ushort SDL_GameControllerGetProductVersion(
            IntPtr gameController
        );


        /// <summary>
        ///     Internals the sdl game controller get serial using the specified game controller
        /// </summary>
        /// <param name="gameController">The game controller</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GameControllerGetSerial", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr INTERNAL_SDL_GameControllerGetSerial(
            IntPtr gameController
        );

        /// <summary>
        ///     Sdl the game controller get serial using the specified game controller
        /// </summary>
        /// <param name="gameController">The game controller</param>
        /// <returns>The string</returns>
        public static string SDL_GameControllerGetSerial(
            IntPtr gameController
        )
            => Utf8ToManaged(
                INTERNAL_SDL_GameControllerGetSerial(gameController)
            );


        /// <summary>
        ///     Sdl the game controller get attached using the specified game controller
        /// </summary>
        /// <param name="gameController">The game controller</param>
        /// <returns>The sdl bool</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern SdlBool SDL_GameControllerGetAttached(
            IntPtr gameController
        );


        /// <summary>
        ///     Sdl the game controller get joystick using the specified game controller
        /// </summary>
        /// <param name="gameController">The game controller</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr SDL_GameControllerGetJoystick(
            IntPtr gameController
        );

        /// <summary>
        ///     Sdl the game controller event state using the specified state
        /// </summary>
        /// <param name="state">The state</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_GameControllerEventState(int state);

        /// <summary>
        ///     Sdl the game controller update
        /// </summary>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_GameControllerUpdate();

        /// <summary>
        ///     Internals the sdl game controller get axis from string using the specified pch string
        /// </summary>
        /// <param name="pchString">The pch string</param>
        /// <returns>The sdl game controller axis</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GameControllerGetAxisFromString", CallingConvention = CallingConvention.Cdecl)]
        private static extern SdlGameControllerAxis INTERNAL_SDL_GameControllerGetAxisFromString(
            byte[] pchString
        );

        /// <summary>
        ///     Sdl the game controller get axis from string using the specified pch string
        /// </summary>
        /// <param name="pchString">The pch string</param>
        /// <returns>The sdl game controller axis</returns>
        public static SdlGameControllerAxis SDL_GameControllerGetAxisFromString(
            string pchString
        )
        {
            int utf8PchStringBufSize = Utf8Size(pchString);
            byte[] utf8PchString = new byte[utf8PchStringBufSize];
            return INTERNAL_SDL_GameControllerGetAxisFromString(
                Utf8Encode(pchString, utf8PchString, utf8PchStringBufSize)
            );
        }

        /// <summary>
        ///     Internals the sdl game controller get string for axis using the specified axis
        /// </summary>
        /// <param name="axis">The axis</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GameControllerGetStringForAxis", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr INTERNAL_SDL_GameControllerGetStringForAxis(
            SdlGameControllerAxis axis
        );

        /// <summary>
        ///     Sdl the game controller get string for axis using the specified axis
        /// </summary>
        /// <param name="axis">The axis</param>
        /// <returns>The string</returns>
        public static string SDL_GameControllerGetStringForAxis(
            SdlGameControllerAxis axis
        )
            => Utf8ToManaged(
                INTERNAL_SDL_GameControllerGetStringForAxis(
                    axis
                )
            );


        /// <summary>
        ///     Internals the sdl game controller get bind for axis using the specified game controller
        /// </summary>
        /// <param name="gameController">The game controller</param>
        /// <param name="axis">The axis</param>
        /// <returns>The internal sdl game controller button bind</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GameControllerGetBindForAxis", CallingConvention = CallingConvention.Cdecl)]
        private static extern InternalSdlGameControllerButtonBind INTERNAL_SDL_GameControllerGetBindForAxis(
            IntPtr gameController,
            SdlGameControllerAxis axis
        );

        /// <summary>
        ///     Sdl the game controller get bind for axis using the specified game controller
        /// </summary>
        /// <param name="gameController">The game controller</param>
        /// <param name="axis">The axis</param>
        /// <returns>The result</returns>
        public static SdlGameControllerButtonBind SDL_GameControllerGetBindForAxis(
            IntPtr gameController,
            SdlGameControllerAxis axis
        )
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
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern short SDL_GameControllerGetAxis(
            IntPtr gameController,
            SdlGameControllerAxis axis
        );

        /// <summary>
        ///     Internals the sdl game controller get button from string using the specified pch string
        /// </summary>
        /// <param name="pchString">The pch string</param>
        /// <returns>The sdl game controller button</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GameControllerGetButtonFromString", CallingConvention = CallingConvention.Cdecl)]
        private static extern SdlGameControllerButton INTERNAL_SDL_GameControllerGetButtonFromString(
            byte[] pchString
        );

        /// <summary>
        ///     Sdl the game controller get button from string using the specified pch string
        /// </summary>
        /// <param name="pchString">The pch string</param>
        /// <returns>The sdl game controller button</returns>
        public static SdlGameControllerButton SDL_GameControllerGetButtonFromString(
            string pchString
        )
        {
            int utf8PchStringBufSize = Utf8Size(pchString);
            byte[] utf8PchString = new byte[utf8PchStringBufSize];
            return INTERNAL_SDL_GameControllerGetButtonFromString(
                Utf8Encode(pchString, utf8PchString, utf8PchStringBufSize)
            );
        }

        /// <summary>
        ///     Internals the sdl game controller get string for button using the specified button
        /// </summary>
        /// <param name="button">The button</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GameControllerGetStringForButton", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr INTERNAL_SDL_GameControllerGetStringForButton(
            SdlGameControllerButton button
        );

        /// <summary>
        ///     Sdl the game controller get string for button using the specified button
        /// </summary>
        /// <param name="button">The button</param>
        /// <returns>The string</returns>
        public static string SDL_GameControllerGetStringForButton(
            SdlGameControllerButton button
        )
            => Utf8ToManaged(
                INTERNAL_SDL_GameControllerGetStringForButton(button)
            );


        /// <summary>
        ///     Internals the sdl game controller get bind for button using the specified game controller
        /// </summary>
        /// <param name="gameController">The game controller</param>
        /// <param name="button">The button</param>
        /// <returns>The internal sdl game controller button bind</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GameControllerGetBindForButton", CallingConvention = CallingConvention.Cdecl)]
        private static extern InternalSdlGameControllerButtonBind INTERNAL_SDL_GameControllerGetBindForButton(
            IntPtr gameController,
            SdlGameControllerButton button
        );

        /// <summary>
        ///     Sdl the game controller get bind for button using the specified game controller
        /// </summary>
        /// <param name="gameController">The game controller</param>
        /// <param name="button">The button</param>
        /// <returns>The result</returns>
        public static SdlGameControllerButtonBind SDL_GameControllerGetBindForButton(
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
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern byte SDL_GameControllerGetButton(
            IntPtr gameController,
            SdlGameControllerButton button
        );


        /// <summary>
        ///     Sdl the game controller rumble using the specified game controller
        /// </summary>
        /// <param name="gameController">The game controller</param>
        /// <param name="lowFrequencyRumble">The low frequency rumble</param>
        /// <param name="highFrequencyRumble">The high frequency rumble</param>
        /// <param name="durationMs">The duration ms</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_GameControllerRumble(
            IntPtr gameController,
            ushort lowFrequencyRumble,
            ushort highFrequencyRumble,
            uint durationMs
        );


        /// <summary>
        ///     Sdl the game controller rumble triggers using the specified game controller
        /// </summary>
        /// <param name="gameController">The game controller</param>
        /// <param name="leftRumble">The left rumble</param>
        /// <param name="rightRumble">The right rumble</param>
        /// <param name="durationMs">The duration ms</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_GameControllerRumbleTriggers(
            IntPtr gameController,
            ushort leftRumble,
            ushort rightRumble,
            uint durationMs
        );


        /// <summary>
        ///     Sdl the game controller close using the specified game controller
        /// </summary>
        /// <param name="gameController">The game controller</param>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_GameControllerClose(
            IntPtr gameController
        );


        /// <summary>
        ///     Internals the sdl game controller get apple sf symbols name for button using the specified game controller
        /// </summary>
        /// <param name="gameController">The game controller</param>
        /// <param name="button">The button</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GameControllerGetAppleSFSymbolsNameForButton", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr INTERNAL_SDL_GameControllerGetAppleSFSymbolsNameForButton(
            IntPtr gameController,
            SdlGameControllerButton button
        );

        /// <summary>
        ///     Sdl the game controller get apple sf symbols name for button using the specified game controller
        /// </summary>
        /// <param name="gameController">The game controller</param>
        /// <param name="button">The button</param>
        /// <returns>The string</returns>
        public static string SDL_GameControllerGetAppleSFSymbolsNameForButton(
            IntPtr gameController,
            SdlGameControllerButton button
        )
            => Utf8ToManaged(
                INTERNAL_SDL_GameControllerGetAppleSFSymbolsNameForButton(gameController, button)
            );


        /// <summary>
        ///     Internals the sdl game controller get apple sf symbols name for axis using the specified game controller
        /// </summary>
        /// <param name="gameController">The game controller</param>
        /// <param name="axis">The axis</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GameControllerGetAppleSFSymbolsNameForAxis", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr INTERNAL_SDL_GameControllerGetAppleSFSymbolsNameForAxis(
            IntPtr gameController,
            SdlGameControllerAxis axis
        );

        /// <summary>
        ///     Sdl the game controller get apple sf symbols name for axis using the specified game controller
        /// </summary>
        /// <param name="gameController">The game controller</param>
        /// <param name="axis">The axis</param>
        /// <returns>The string</returns>
        public static string SDL_GameControllerGetAppleSFSymbolsNameForAxis(
            IntPtr gameController,
            SdlGameControllerAxis axis
        )
            => Utf8ToManaged(
                INTERNAL_SDL_GameControllerGetAppleSFSymbolsNameForAxis(gameController, axis)
            );
        
        /// <summary>
        ///     Sdl the game controller from instance id using the specified joy id
        /// </summary>
        /// <param name="joyId">The joy id</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr SDL_GameControllerFromInstanceID(int joyId);
        
        /// <summary>
        ///     Sdl the game controller type for index using the specified joystick index
        /// </summary>
        /// <param name="joystickIndex">The joystick index</param>
        /// <returns>The sdl game controller type</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern SdlGameControllerType SDL_GameControllerTypeForIndex(
            int joystickIndex
        );


        /// <summary>
        ///     Sdl the game controller get type using the specified game controller
        /// </summary>
        /// <param name="gameController">The game controller</param>
        /// <returns>The sdl game controller type</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern SdlGameControllerType SDL_GameControllerGetType(
            IntPtr gameController
        );
        
        /// <summary>
        ///     Sdl the game controller from player index using the specified player index
        /// </summary>
        /// <param name="playerIndex">The player index</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr SDL_GameControllerFromPlayerIndex(
            int playerIndex
        );


        /// <summary>
        ///     Sdl the game controller set player index using the specified game controller
        /// </summary>
        /// <param name="gameController">The game controller</param>
        /// <param name="playerIndex">The player index</param>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_GameControllerSetPlayerIndex(
            IntPtr gameController,
            int playerIndex
        );


        /// <summary>
        ///     Sdl the game controller has led using the specified game controller
        /// </summary>
        /// <param name="gameController">The game controller</param>
        /// <returns>The sdl bool</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern SdlBool SDL_GameControllerHasLED(
            IntPtr gameController
        );

        /// <summary>
        ///     Sdl the game controller has rumble using the specified game controller
        /// </summary>
        /// <param name="gameController">The game controller</param>
        /// <returns>The sdl bool</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern SdlBool SDL_GameControllerHasRumble(
            IntPtr gameController
        );

        /// <summary>
        ///     Sdl the game controller has rumble triggers using the specified game controller
        /// </summary>
        /// <param name="gameController">The game controller</param>
        /// <returns>The sdl bool</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern SdlBool SDL_GameControllerHasRumbleTriggers(
            IntPtr gameController
        );

        /// <summary>
        ///     Sdl the game controller set led using the specified game controller
        /// </summary>
        /// <param name="gameController">The game controller</param>
        /// <param name="red">The red</param>
        /// <param name="green">The green</param>
        /// <param name="blue">The blue</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_GameControllerSetLED(
            IntPtr gameController,
            byte red,
            byte green,
            byte blue
        );

        /// <summary>
        ///     Sdl the game controller has axis using the specified game controller
        /// </summary>
        /// <param name="gameController">The game controller</param>
        /// <param name="axis">The axis</param>
        /// <returns>The sdl bool</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern SdlBool SDL_GameControllerHasAxis(
            IntPtr gameController,
            SdlGameControllerAxis axis
        );

        /// <summary>
        ///     Sdl the game controller has button using the specified game controller
        /// </summary>
        /// <param name="gameController">The game controller</param>
        /// <param name="button">The button</param>
        /// <returns>The sdl bool</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern SdlBool SDL_GameControllerHasButton(
            IntPtr gameController,
            SdlGameControllerButton button
        );

        /// <summary>
        ///     Sdl the game controller get num touchpads using the specified game controller
        /// </summary>
        /// <param name="gameController">The game controller</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_GameControllerGetNumTouchpads(
            IntPtr gameController
        );

        /// <summary>
        ///     Sdl the game controller get num touchpad fingers using the specified game controller
        /// </summary>
        /// <param name="gameController">The game controller</param>
        /// <param name="touchpad">The touchpad</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_GameControllerGetNumTouchpadFingers(
            IntPtr gameController,
            int touchpad
        );

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
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_GameControllerGetTouchpadFinger(
            IntPtr gameController,
            int touchpad,
            int finger,
            out byte state,
            out float x,
            out float y,
            out float pressure
        );

        /// <summary>
        ///     Sdl the game controller has sensor using the specified game controller
        /// </summary>
        /// <param name="gameController">The game controller</param>
        /// <param name="type">The type</param>
        /// <returns>The sdl bool</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern SdlBool SDL_GameControllerHasSensor(
            IntPtr gameController,
            SdlSensorType type
        );

        /// <summary>
        ///     Sdl the game controller set sensor enabled using the specified game controller
        /// </summary>
        /// <param name="gameController">The game controller</param>
        /// <param name="type">The type</param>
        /// <param name="enabled">The enabled</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_GameControllerSetSensorEnabled(
            IntPtr gameController,
            SdlSensorType type,
            SdlBool enabled
        );

        /// <summary>
        ///     Sdl the game controller is sensor enabled using the specified game controller
        /// </summary>
        /// <param name="gameController">The game controller</param>
        /// <param name="type">The type</param>
        /// <returns>The sdl bool</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern SdlBool SDL_GameControllerIsSensorEnabled(
            IntPtr gameController,
            SdlSensorType type
        );

        /// <summary>
        ///     Sdl the game controller get sensor data using the specified game controller
        /// </summary>
        /// <param name="gameController">The game controller</param>
        /// <param name="type">The type</param>
        /// <param name="data">The data</param>
        /// <param name="numValues">The num values</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_GameControllerGetSensorData(
            IntPtr gameController,
            SdlSensorType type,
            IntPtr data,
            int numValues
        );

        /// <summary>
        ///     Sdl the game controller get sensor data rate using the specified game controller
        /// </summary>
        /// <param name="gameController">The game controller</param>
        /// <param name="type">The type</param>
        /// <returns>The float</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern float SDL_GameControllerGetSensorDataRate(
            IntPtr gameController,
            SdlSensorType type
        );

        /// <summary>
        ///     Sdl the game controller send effect using the specified game controller
        /// </summary>
        /// <param name="gameController">The game controller</param>
        /// <param name="data">The data</param>
        /// <param name="size">The size</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_GameControllerSendEffect(
            IntPtr gameController,
            IntPtr data,
            int size
        );

        /// <summary>
        ///     Sdl the haptic close using the specified haptic
        /// </summary>
        /// <param name="haptic">The haptic</param>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_HapticClose(IntPtr haptic);

        /// <summary>
        ///     Sdl the haptic destroy effect using the specified haptic
        /// </summary>
        /// <param name="haptic">The haptic</param>
        /// <param name="effect">The effect</param>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_HapticDestroyEffect(
            IntPtr haptic,
            int effect
        );

        /// <summary>
        ///     Sdl the haptic effect supported using the specified haptic
        /// </summary>
        /// <param name="haptic">The haptic</param>
        /// <param name="effect">The effect</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_HapticEffectSupported(
            IntPtr haptic,
            ref SdlHapticEffect effect
        );

        /// <summary>
        ///     Sdl the haptic get effect status using the specified haptic
        /// </summary>
        /// <param name="haptic">The haptic</param>
        /// <param name="effect">The effect</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_HapticGetEffectStatus(
            IntPtr haptic,
            int effect
        );

        /// <summary>
        ///     Sdl the haptic index using the specified haptic
        /// </summary>
        /// <param name="haptic">The haptic</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_HapticIndex(IntPtr haptic);

        /// <summary>
        ///     Internals the sdl haptic name using the specified device index
        /// </summary>
        /// <param name="deviceIndex">The device index</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_HapticName", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr INTERNAL_SDL_HapticName(int deviceIndex);

        /// <summary>
        ///     Sdl the haptic name using the specified device index
        /// </summary>
        /// <param name="deviceIndex">The device index</param>
        /// <returns>The string</returns>
        public static string SDL_HapticName(int deviceIndex) => Utf8ToManaged(INTERNAL_SDL_HapticName(deviceIndex));

        /// <summary>
        ///     Sdl the haptic new effect using the specified haptic
        /// </summary>
        /// <param name="haptic">The haptic</param>
        /// <param name="effect">The effect</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_HapticNewEffect(
            IntPtr haptic,
            ref SdlHapticEffect effect
        );

        /// <summary>
        ///     Sdl the haptic num axes using the specified haptic
        /// </summary>
        /// <param name="haptic">The haptic</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_HapticNumAxes(IntPtr haptic);

        /// <summary>
        ///     Sdl the haptic num effects using the specified haptic
        /// </summary>
        /// <param name="haptic">The haptic</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_HapticNumEffects(IntPtr haptic);

        /// <summary>
        ///     Sdl the haptic num effects playing using the specified haptic
        /// </summary>
        /// <param name="haptic">The haptic</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_HapticNumEffectsPlaying(IntPtr haptic);

        /// <summary>
        ///     Sdl the haptic open using the specified device index
        /// </summary>
        /// <param name="deviceIndex">The device index</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr SDL_HapticOpen(int deviceIndex);

        /// <summary>
        ///     Sdl the haptic opened using the specified device index
        /// </summary>
        /// <param name="deviceIndex">The device index</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_HapticOpened(int deviceIndex);

        /// <summary>
        ///     Sdl the haptic open from joystick using the specified joystick
        /// </summary>
        /// <param name="joystick">The joystick</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr SDL_HapticOpenFromJoystick(
            IntPtr joystick
        );

        /// <summary>
        ///     Sdl the haptic open from mouse
        /// </summary>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr SDL_HapticOpenFromMouse();

        /// <summary>
        ///     Sdl the haptic pause using the specified haptic
        /// </summary>
        /// <param name="haptic">The haptic</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_HapticPause(IntPtr haptic);

        /// <summary>
        ///     Sdl the haptic query using the specified haptic
        /// </summary>
        /// <param name="haptic">The haptic</param>
        /// <returns>The uint</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern uint SDL_HapticQuery(IntPtr haptic);

        /// <summary>
        ///     Sdl the haptic rumble init using the specified haptic
        /// </summary>
        /// <param name="haptic">The haptic</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_HapticRumbleInit(IntPtr haptic);

        /// <summary>
        ///     Sdl the haptic rumble play using the specified haptic
        /// </summary>
        /// <param name="haptic">The haptic</param>
        /// <param name="strength">The strength</param>
        /// <param name="length">The length</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_HapticRumblePlay(
            IntPtr haptic,
            float strength,
            uint length
        );

        /// <summary>
        ///     Sdl the haptic rumble stop using the specified haptic
        /// </summary>
        /// <param name="haptic">The haptic</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_HapticRumbleStop(IntPtr haptic);

        /// <summary>
        ///     Sdl the haptic rumble supported using the specified haptic
        /// </summary>
        /// <param name="haptic">The haptic</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_HapticRumbleSupported(IntPtr haptic);

        /// <summary>
        ///     Sdl the haptic run effect using the specified haptic
        /// </summary>
        /// <param name="haptic">The haptic</param>
        /// <param name="effect">The effect</param>
        /// <param name="iterations">The iterations</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_HapticRunEffect(
            IntPtr haptic,
            int effect,
            uint iterations
        );

        /// <summary>
        ///     Sdl the haptic set auto center using the specified haptic
        /// </summary>
        /// <param name="haptic">The haptic</param>
        /// <param name="autoCenter">The auto center</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_HapticSetAutoCenter(
            IntPtr haptic,
            int autoCenter
        );

        /// <summary>
        ///     Sdl the haptic set gain using the specified haptic
        /// </summary>
        /// <param name="haptic">The haptic</param>
        /// <param name="gain">The gain</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_HapticSetGain(
            IntPtr haptic,
            int gain
        );

        /// <summary>
        ///     Sdl the haptic stop all using the specified haptic
        /// </summary>
        /// <param name="haptic">The haptic</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_HapticStopAll(IntPtr haptic);


        /// <summary>
        ///     Sdl the haptic stop effect using the specified haptic
        /// </summary>
        /// <param name="haptic">The haptic</param>
        /// <param name="effect">The effect</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_HapticStopEffect(
            IntPtr haptic,
            int effect
        );

        /// <summary>
        ///     Sdl the haptic unpause using the specified haptic
        /// </summary>
        /// <param name="haptic">The haptic</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_HapticUnpause(IntPtr haptic);

        /// <summary>
        ///     Sdl the haptic update effect using the specified haptic
        /// </summary>
        /// <param name="haptic">The haptic</param>
        /// <param name="effect">The effect</param>
        /// <param name="data">The data</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_HapticUpdateEffect(
            IntPtr haptic,
            int effect,
            ref SdlHapticEffect data
        );


        /// <summary>
        ///     Sdl the joystick is haptic using the specified joystick
        /// </summary>
        /// <param name="joystick">The joystick</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_JoystickIsHaptic(IntPtr joystick);

        /// <summary>
        ///     Sdl the mouse is haptic
        /// </summary>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_MouseIsHaptic();

        /// <summary>
        ///     Sdl the num haptics
        /// </summary>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_NumHaptics();

        /// <summary>
        ///     Sdl the num sensors
        /// </summary>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_NumSensors();

        /// <summary>
        ///     Internals the sdl sensor get device name using the specified device index
        /// </summary>
        /// <param name="deviceIndex">The device index</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_SensorGetDeviceName", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr INTERNAL_SDL_SensorGetDeviceName(int deviceIndex);

        /// <summary>
        ///     Sdl the sensor get device name using the specified device index
        /// </summary>
        /// <param name="deviceIndex">The device index</param>
        /// <returns>The string</returns>
        public static string SDL_SensorGetDeviceName(int deviceIndex) => Utf8ToManaged(INTERNAL_SDL_SensorGetDeviceName(deviceIndex));

        /// <summary>
        ///     Sdl the sensor get device type using the specified device index
        /// </summary>
        /// <param name="deviceIndex">The device index</param>
        /// <returns>The sdl sensor type</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern SdlSensorType SDL_SensorGetDeviceType(int deviceIndex);

        /// <summary>
        ///     Sdl the sensor get device non portable type using the specified device index
        /// </summary>
        /// <param name="deviceIndex">The device index</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_SensorGetDeviceNonPortableType(int deviceIndex);

        /// <summary>
        ///     Sdl the sensor get device instance id using the specified device index
        /// </summary>
        /// <param name="deviceIndex">The device index</param>
        /// <returns>The int 32</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_SensorGetDeviceInstanceID(int deviceIndex);

        /// <summary>
        ///     Sdl the sensor open using the specified device index
        /// </summary>
        /// <param name="deviceIndex">The device index</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr SDL_SensorOpen(int deviceIndex);

        /// <summary>
        ///     Sdl the sensor from instance id using the specified instance id
        /// </summary>
        /// <param name="instanceId">The instance id</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr SDL_SensorFromInstanceID(
            int instanceId
        );

        /// <summary>
        ///     Internals the sdl sensor get name using the specified sensor
        /// </summary>
        /// <param name="sensor">The sensor</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_SensorGetName", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr INTERNAL_SDL_SensorGetName(IntPtr sensor);

        /// <summary>
        ///     Sdl the sensor get name using the specified sensor
        /// </summary>
        /// <param name="sensor">The sensor</param>
        /// <returns>The string</returns>
        public static string SDL_SensorGetName(IntPtr sensor) => Utf8ToManaged(INTERNAL_SDL_SensorGetName(sensor));

        /// <summary>
        ///     Sdl the sensor get type using the specified sensor
        /// </summary>
        /// <param name="sensor">The sensor</param>
        /// <returns>The sdl sensor type</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern SdlSensorType SDL_SensorGetType(IntPtr sensor);

        /// <summary>
        ///     Sdl the sensor get non portable type using the specified sensor
        /// </summary>
        /// <param name="sensor">The sensor</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_SensorGetNonPortableType(IntPtr sensor);

        /// <summary>
        ///     Sdl the sensor get instance id using the specified sensor
        /// </summary>
        /// <param name="sensor">The sensor</param>
        /// <returns>The int 32</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_SensorGetInstanceID(IntPtr sensor);

        /// <summary>
        ///     Sdl the sensor get data using the specified sensor
        /// </summary>
        /// <param name="sensor">The sensor</param>
        /// <param name="data">The data</param>
        /// <param name="numValues">The num values</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_SensorGetData(
            IntPtr sensor,
            float[] data,
            int numValues
        );

        /// <summary>
        ///     Sdl the sensor close using the specified sensor
        /// </summary>
        /// <param name="sensor">The sensor</param>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_SensorClose(IntPtr sensor);

        /// <summary>
        ///     Sdl the sensor update
        /// </summary>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_SensorUpdate();

        /// <summary>
        ///     Sdl the lock sensors
        /// </summary>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_LockSensors();

        /// <summary>
        ///     Sdl the unlock sensors
        /// </summary>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_UnlockSensors();

        /// <summary>
        ///     Sdl the audio bit size using the specified x
        /// </summary>
        /// <param name="x">The </param>
        /// <returns>The ushort</returns>
        public static ushort SdlAudioBitSize(ushort x) => (ushort) (x & SdlAudioMaskBitSize);

        /// <summary>
        ///     Describes whether sdl audio is float
        /// </summary>
        /// <param name="x">The </param>
        /// <returns>The bool</returns>
        public static bool SdlAudioIsFloat(ushort x) => (x & SdlAudioMaskDatatype) != 0;

        /// <summary>
        ///     Describes whether sdl audio is big endian
        /// </summary>
        /// <param name="x">The </param>
        /// <returns>The bool</returns>
        public static bool SdlAudioIsBigEndian(ushort x) => (x & SdlAudioMaskEndian) != 0;

        /// <summary>
        ///     Describes whether sdl audio is signed
        /// </summary>
        /// <param name="x">The </param>
        /// <returns>The bool</returns>
        public static bool SdlAudioIsSigned(ushort x) => (x & SdlAudioMaskSigned) != 0;

        /// <summary>
        ///     Describes whether sdl audio is int
        /// </summary>
        /// <param name="x">The </param>
        /// <returns>The bool</returns>
        public static bool SdlAudioIsInt(ushort x) => (x & SdlAudioMaskDatatype) == 0;

        /// <summary>
        ///     Describes whether sdl audio is little endian
        /// </summary>
        /// <param name="x">The </param>
        /// <returns>The bool</returns>
        public static bool SdlAudioIsLittleEndian(ushort x) => (x & SdlAudioMaskEndian) == 0;

        /// <summary>
        ///     Describes whether sdl audio is unsigned
        /// </summary>
        /// <param name="x">The </param>
        /// <returns>The bool</returns>
        public static bool SdlAudioIsUnsigned(ushort x) => (x & SdlAudioMaskSigned) == 0;

        /// <summary>
        ///     Internals the sdl audio init using the specified driver name
        /// </summary>
        /// <param name="driverName">The driver name</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_AudioInit", CallingConvention = CallingConvention.Cdecl)]
        private static extern int INTERNAL_SDL_AudioInit(
            byte[] driverName
        );

        /// <summary>
        ///     Sdl the audio init using the specified driver name
        /// </summary>
        /// <param name="driverName">The driver name</param>
        /// <returns>The int</returns>
        public static int SDL_AudioInit(string driverName)
        {
            int utf8DriverNameBufSize = Utf8Size(driverName);
            byte[] utf8DriverName = new byte[utf8DriverNameBufSize];
            return INTERNAL_SDL_AudioInit(
                Utf8Encode(driverName, utf8DriverName, utf8DriverNameBufSize)
            );
        }

        /// <summary>
        ///     Sdl the audio quit
        /// </summary>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_AudioQuit();

        /// <summary>
        ///     Sdl the close audio
        /// </summary>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_CloseAudio();


        /// <summary>
        ///     Sdl the close audio device using the specified dev
        /// </summary>
        /// <param name="dev">The dev</param>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_CloseAudioDevice(uint dev);


        /// <summary>
        ///     Sdl the free wav using the specified audio buf
        /// </summary>
        /// <param name="audioBuf">The audio buf</param>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_FreeWAV(IntPtr audioBuf);

        /// <summary>
        ///     Internals the sdl get audio device name using the specified index
        /// </summary>
        /// <param name="index">The index</param>
        /// <param name="isCapture">The is capture</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GetAudioDeviceName", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr INTERNAL_SDL_GetAudioDeviceName(
            int index,
            int isCapture
        );

        /// <summary>
        ///     Sdl the get audio device name using the specified index
        /// </summary>
        /// <param name="index">The index</param>
        /// <param name="isCapture">The is capture</param>
        /// <returns>The string</returns>
        public static string SDL_GetAudioDeviceName(
            int index,
            int isCapture
        )
            => Utf8ToManaged(
                INTERNAL_SDL_GetAudioDeviceName(index, isCapture)
            );

        /// <summary>
        ///     Sdl the get audio device status using the specified dev
        /// </summary>
        /// <param name="dev">The dev</param>
        /// <returns>The sdl audio status</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern SdlAudioStatus SDL_GetAudioDeviceStatus(
            uint dev
        );

        /// <summary>
        ///     Internals the sdl get audio driver using the specified index
        /// </summary>
        /// <param name="index">The index</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GetAudioDriver", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr INTERNAL_SDL_GetAudioDriver(int index);

        /// <summary>
        ///     Sdl the get audio driver using the specified index
        /// </summary>
        /// <param name="index">The index</param>
        /// <returns>The string</returns>
        public static string SDL_GetAudioDriver(int index) => Utf8ToManaged(
            INTERNAL_SDL_GetAudioDriver(index)
        );

        /// <summary>
        ///     Sdl the get audio status
        /// </summary>
        /// <returns>The sdl audio status</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern SdlAudioStatus SDL_GetAudioStatus();

        /// <summary>
        ///     Internals the sdl get current audio driver
        /// </summary>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GetCurrentAudioDriver", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr INTERNAL_SDL_GetCurrentAudioDriver();

        /// <summary>
        ///     Sdl the get current audio driver
        /// </summary>
        /// <returns>The string</returns>
        public static string SDL_GetCurrentAudioDriver() => Utf8ToManaged(INTERNAL_SDL_GetCurrentAudioDriver());

        /// <summary>
        ///     Sdl the get num audio devices using the specified is capture
        /// </summary>
        /// <param name="isCapture">The is capture</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_GetNumAudioDevices(int isCapture);

        /// <summary>
        ///     Sdl the get num audio drivers
        /// </summary>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_GetNumAudioDrivers();

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
        private static extern IntPtr INTERNAL_SDL_LoadWAV_RW(
            IntPtr src,
            int freeSrc,
            out SdlAudioSpec spec,
            out IntPtr audioBuf,
            out uint audioLen
        );

        /// <summary>
        ///     Sdl the load wav using the specified file
        /// </summary>
        /// <param name="file">The file</param>
        /// <param name="spec">The spec</param>
        /// <param name="audioBuf">The audio buf</param>
        /// <param name="audioLen">The audio len</param>
        /// <returns>The int ptr</returns>
        public static IntPtr SDL_LoadWAV(
            string file,
            out SdlAudioSpec spec,
            out IntPtr audioBuf,
            out uint audioLen
        )
        {
            IntPtr rw = SDL_RWFromFile(file, "rb");
            return INTERNAL_SDL_LoadWAV_RW(
                rw,
                1,
                out spec,
                out audioBuf,
                out audioLen
            );
        }

        /// <summary>
        ///     Sdl the lock audio
        /// </summary>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_LockAudio();

        /// <summary>
        ///     Sdl the lock audio device using the specified dev
        /// </summary>
        /// <param name="dev">The dev</param>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_LockAudioDevice(uint dev);

        /// <summary>
        ///     Sdl the mix audio using the specified dst
        /// </summary>
        /// <param name="dst">The dst</param>
        /// <param name="src">The src</param>
        /// <param name="len">The len</param>
        /// <param name="volume">The volume</param>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_MixAudio(
            [Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U1, SizeParamIndex = 2)]
            byte[] dst,
            [In, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U1, SizeParamIndex = 2)]
            byte[] src,
            uint len,
            int volume
        );

        /// <summary>
        ///     Sdl the mix audio format using the specified dst
        /// </summary>
        /// <param name="dst">The dst</param>
        /// <param name="src">The src</param>
        /// <param name="format">The format</param>
        /// <param name="len">The len</param>
        /// <param name="volume">The volume</param>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_MixAudioFormat(
            IntPtr dst,
            IntPtr src,
            ushort format,
            uint len,
            int volume
        );

        /// <summary>
        ///     Sdl the mix audio format using the specified dst
        /// </summary>
        /// <param name="dst">The dst</param>
        /// <param name="src">The src</param>
        /// <param name="format">The format</param>
        /// <param name="len">The len</param>
        /// <param name="volume">The volume</param>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_MixAudioFormat(
            [Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U1, SizeParamIndex = 3)]
            byte[] dst,
            [In, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U1, SizeParamIndex = 3)]
            byte[] src,
            ushort format,
            uint len,
            int volume
        );

        /// <summary>
        ///     Sdl the open audio using the specified desired
        /// </summary>
        /// <param name="desired">The desired</param>
        /// <param name="obtained">The obtained</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_OpenAudio(
            ref SdlAudioSpec desired,
            out SdlAudioSpec obtained
        );

        /// <summary>
        ///     Sdl the open audio using the specified desired
        /// </summary>
        /// <param name="desired">The desired</param>
        /// <param name="obtained">The obtained</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_OpenAudio(
            ref SdlAudioSpec desired,
            IntPtr obtained
        );

        /// <summary>
        ///     Sdl the open audio device using the specified device
        /// </summary>
        /// <param name="device">The device</param>
        /// <param name="isCapture">The is capture</param>
        /// <param name="desired">The desired</param>
        /// <param name="obtained">The obtained</param>
        /// <param name="allowedChanges">The allowed changes</param>
        /// <returns>The uint</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern uint SDL_OpenAudioDevice(
            IntPtr device,
            int isCapture,
            ref SdlAudioSpec desired,
            out SdlAudioSpec obtained,
            int allowedChanges
        );

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
        private static extern uint INTERNAL_SDL_OpenAudioDevice(byte[] device, int isCapture, ref SdlAudioSpec desired, out SdlAudioSpec obtained, int allowedChanges);

        /// <summary>
        ///     Sdl the open audio device using the specified device
        /// </summary>
        /// <param name="device">The device</param>
        /// <param name="isCapture">The is capture</param>
        /// <param name="desired">The desired</param>
        /// <param name="obtained">The obtained</param>
        /// <param name="allowedChanges">The allowed changes</param>
        /// <returns>The uint</returns>
        public static uint SdlOpenAudioDevice(string device, int isCapture, ref SdlAudioSpec desired, out SdlAudioSpec obtained, int allowedChanges)
        {
            int utf8DeviceBufSize = Utf8Size(device);
            byte[] utf8Device = new byte[utf8DeviceBufSize];
            return INTERNAL_SDL_OpenAudioDevice(
                Utf8Encode(device, utf8Device, utf8DeviceBufSize),
                isCapture,
                ref desired,
                out obtained,
                allowedChanges
            );
        }

        /// <summary>
        ///     Sdl the pause audio using the specified pause on
        /// </summary>
        /// <param name="pauseOn">The pause on</param>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_PauseAudio(int pauseOn);

        /// <summary>
        ///     Sdl the pause audio device using the specified dev
        /// </summary>
        /// <param name="dev">The dev</param>
        /// <param name="pauseOn">The pause on</param>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_PauseAudioDevice(
            uint dev,
            int pauseOn
        );

        /// <summary>
        ///     Sdl the unlock audio
        /// </summary>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_UnlockAudio();

        /// <summary>
        ///     Sdl the unlock audio device using the specified dev
        /// </summary>
        /// <param name="dev">The dev</param>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_UnlockAudioDevice(uint dev);

        /// <summary>
        ///     Sdl the queue audio using the specified dev
        /// </summary>
        /// <param name="dev">The dev</param>
        /// <param name="data">The data</param>
        /// <param name="len">The len</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_QueueAudio(
            uint dev,
            IntPtr data,
            uint len
        );

        /// <summary>
        ///     Sdl the dequeue audio using the specified dev
        /// </summary>
        /// <param name="dev">The dev</param>
        /// <param name="data">The data</param>
        /// <param name="len">The len</param>
        /// <returns>The uint</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern uint SDL_DequeueAudio(
            uint dev,
            IntPtr data,
            uint len
        );

        /// <summary>
        ///     Sdl the get queued audio size using the specified dev
        /// </summary>
        /// <param name="dev">The dev</param>
        /// <returns>The int 32</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern uint SDL_GetQueuedAudioSize(uint dev);

        /// <summary>
        ///     Sdl the clear queued audio using the specified dev
        /// </summary>
        /// <param name="dev">The dev</param>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_ClearQueuedAudio(uint dev);

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
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr SDL_NewAudioStream(
            ushort srcFormat,
            byte srcChannels,
            int srcRate,
            ushort dstFormat,
            byte dstChannels,
            int dstRate
        );

        /// <summary>
        ///     Sdl the audio stream put using the specified stream
        /// </summary>
        /// <param name="stream">The stream</param>
        /// <param name="buf">The buf</param>
        /// <param name="len">The len</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_AudioStreamPut(
            IntPtr stream,
            IntPtr buf,
            int len
        );

        /// <summary>
        ///     Sdl the audio stream get using the specified stream
        /// </summary>
        /// <param name="stream">The stream</param>
        /// <param name="buf">The buf</param>
        /// <param name="len">The len</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_AudioStreamGet(
            IntPtr stream,
            IntPtr buf,
            int len
        );

        /// <summary>
        ///     Sdl the audio stream available using the specified stream
        /// </summary>
        /// <param name="stream">The stream</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_AudioStreamAvailable(IntPtr stream);

        /// <summary>
        ///     Sdl the audio stream clear using the specified stream
        /// </summary>
        /// <param name="stream">The stream</param>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_AudioStreamClear(IntPtr stream);

        /// <summary>
        ///     Sdl the free audio stream using the specified stream
        /// </summary>
        /// <param name="stream">The stream</param>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_FreeAudioStream(IntPtr stream);


        /// <summary>
        ///     Sdl the get audio device spec using the specified index
        /// </summary>
        /// <param name="index">The index</param>
        /// <param name="isCapture">The is capture</param>
        /// <param name="spec">The spec</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern int SDL_GetAudioDeviceSpec([NotNull] int index, [NotNull]int isCapture, out SdlAudioSpec spec);
        
        /// <summary>
        /// Sdl the get audio device spec using the specified index
        /// </summary>
        /// <param name="index">The index</param>
        /// <param name="isCapture">The is capture</param>
        /// <param name="spec">The spec</param>
        /// <returns>The int</returns>
        [return: NotNull]
        public static int SdlGetAudioDeviceSpec([NotNull] int index, [NotNull] int isCapture, out SdlAudioSpec spec) => SDL_GetAudioDeviceSpec(index.Validate(), isCapture.Validate(), out spec);

        /// <summary>
        ///     Describes whether sdl ticks passed
        /// </summary>
        /// <param name="a">The </param>
        /// <param name="b">The </param>
        /// <returns>The bool</returns>
        public static bool SDL_TICKS_PASSED(uint a, uint b) => (int) (b - a) <= 0;

        /// <summary>
        ///     Sdl the delay using the specified ms
        /// </summary>
        /// <param name="ms">The ms</param>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_Delay(uint ms);

        /// <summary>
        ///     Sdl the get ticks
        /// </summary>
        /// <returns>The int 32</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern uint SDL_GetTicks();

        /// <summary>
        ///     Sdl the get ticks 64
        /// </summary>
        /// <returns>The int 64</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern ulong SDL_GetTicks64();

        /// <summary>
        ///     Sdl the get performance counter
        /// </summary>
        /// <returns>The int 64</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern ulong SDL_GetPerformanceCounter();

        /// <summary>
        ///     Sdl the get performance frequency
        /// </summary>
        /// <returns>The int 64</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern ulong SDL_GetPerformanceFrequency();


        /// <summary>
        ///     Sdl the add timer using the specified interval
        /// </summary>
        /// <param name="interval">The interval</param>
        /// <param name="callback">The callback</param>
        /// <param name="param">The param</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_AddTimer(
            uint interval,
            SdlTimerCallback callback,
            IntPtr param
        );

        /// <summary>
        ///     Sdl the remove timer using the specified id
        /// </summary>
        /// <param name="id">The id</param>
        /// <returns>The sdl bool</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern SdlBool SDL_RemoveTimer(int id);

        /// <summary>
        ///     Sdl the set windows message hook using the specified callback
        /// </summary>
        /// <param name="callback">The callback</param>
        /// <param name="userdata">The userdata</param>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_SetWindowsMessageHook(
            SdlWindowsMessageHook callback,
            IntPtr userdata
        );

        /// <summary>
        ///     Sdl the render get d 3 d 9 device using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr SDL_RenderGetD3D9Device(IntPtr renderer);

        /// <summary>
        ///     Sdl the render get d 3 d 11 device using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr SDL_RenderGetD3D11Device(IntPtr renderer);

        /// <summary>
        ///     Sdl the i phone set animation callback using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="interval">The interval</param>
        /// <param name="callback">The callback</param>
        /// <param name="callbackParam">The callback param</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_iPhoneSetAnimationCallback(
            IntPtr window,
            int interval,
            SdlIPhoneAnimationCallback callback,
            IntPtr callbackParam
        );

        /// <summary>
        ///     Sdl the i phone set event pump using the specified enabled
        /// </summary>
        /// <param name="enabled">The enabled</param>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_iPhoneSetEventPump(SdlBool enabled);


        /// <summary>
        ///     Sdl the android get jni env
        /// </summary>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr SDL_AndroidGetJNIEnv();


        /// <summary>
        ///     Sdl the android get activity
        /// </summary>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr SDL_AndroidGetActivity();

        /// <summary>
        ///     Sdl the is android tv
        /// </summary>
        /// <returns>The sdl bool</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern SdlBool SDL_IsAndroidTV();

        /// <summary>
        ///     Sdl the is chromebook
        /// </summary>
        /// <returns>The sdl bool</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern SdlBool SDL_IsChromebook();
        
        /// <summary>
        /// Sdl the is chromebook
        /// </summary>
        /// <returns>The sdl bool</returns>
        [return: NotNull]
        public static SdlBool SdlIsChromebook() => SDL_IsChromebook();

        /// <summary>
        ///     Sdl the is de x mode
        /// </summary>
        /// <returns>The sdl bool</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern SdlBool SDL_IsDeXMode();

        /// <summary>
        /// Sdl the is de x mode
        /// </summary>
        /// <returns>The sdl bool</returns>
        [return: NotNull]
        public static SdlBool SdlIsDeXMode() => SDL_IsDeXMode();

        /// <summary>
        ///     Sdl the android back button
        /// </summary>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern void SDL_AndroidBackButton();
        
        /// <summary>
        /// Sdl the android back button
        /// </summary>
        [return: NotNull]
        public static void SdlAndroidBackButton() => SDL_AndroidBackButton();

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
        public static string SdlAndroidGetInternalStoragePath() => Utf8ToManaged(INTERNAL_SDL_AndroidGetInternalStoragePath());

        /// <summary>
        ///     Sdl the android get external storage state
        /// </summary>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern int SDL_AndroidGetExternalStorageState();

        /// <summary>
        /// Sdl the android get external storage state
        /// </summary>
        /// <returns>The int</returns>
        [return: NotNull]
        public static int SdlAndroidGetExternalStorageState() => SDL_AndroidGetExternalStorageState();

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
        public static string SdlAndroidGetExternalStoragePath() => Utf8ToManaged(INTERNAL_SDL_AndroidGetExternalStoragePath());

        /// <summary>
        ///     Sdl the get android sdk version
        /// </summary>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern int SDL_GetAndroidSDKVersion();
        
        /// <summary>
        /// Sdl the get android sdk version
        /// </summary>
        /// <returns>The int</returns>
        [return: NotNull]
        public static int SdlGetAndroidSdkVersion() => SDL_GetAndroidSDKVersion();
        
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
        public static SdlBool SdlAndroidRequestPermission([NotNull] string permission) => INTERNAL_SDL_AndroidRequestPermission(Utf8EncodeHeap(permission.Validate()));

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
        private static extern int INTERNAL_SDL_AndroidShowToast([NotNull]byte[] message, [NotNull]int duration, [NotNull]int gravity,[NotNull] int xOffset, [NotNull]int yOffset);

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
        public static int SDL_AndroidShowToast([NotNull]string message, [NotNull]int duration, [NotNull]int gravity, [NotNull]int xOffset, [NotNull]int yOffset) => INTERNAL_SDL_AndroidShowToast(Utf8EncodeHeap(message), duration.Validate(), gravity.Validate(), xOffset.Validate(), yOffset.Validate());

        /// <summary>
        ///     Sdl the win rt get device family
        /// </summary>
        /// <returns>The sdl win rt device family</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        public static extern SdlWinRtDeviceFamily SDL_WinRTGetDeviceFamily();
        
        /// <summary>
        /// Sdl the win rt get device family
        /// </summary>
        /// <returns>The sdl win rt device family</returns>
        [return: NotNull]
        public static SdlWinRtDeviceFamily SdlWinRtGetDeviceFamily() => SDL_WinRTGetDeviceFamily();

        /// <summary>
        ///     Sdl the is tablet
        /// </summary>
        /// <returns>The sdl bool</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        public static extern SdlBool SDL_IsTablet();
        
        /// <summary>
        /// Sdl the is tablet
        /// </summary>
        /// <returns>The sdl bool</returns>
        [return: NotNull]
        public static SdlBool SdlIsTablet() => SDL_IsTablet();

        /// <summary>
        ///     Sdl the get window wm info using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="info">The info</param>
        /// <returns>The sdl bool</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern SdlBool SDL_GetWindowWMInfo([NotNull] IntPtr window, ref SdlSysWMinfo info);
        
        /// <summary>
        /// Sdl the get window wm info using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="info">The info</param>
        /// <returns>The sdl bool</returns>
        [return: NotNull]
        public static SdlBool SdlGetWindowWmInfo([NotNull] IntPtr window, ref SdlSysWMinfo info) => SDL_GetWindowWMInfo(window.Validate(), ref info);

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
        public static string SdlGetBasePath() => Utf8ToManaged(INTERNAL_SDL_GetBasePath().Validate(), true);

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
        public static string SdlGetPrefPath([NotNull] string org, [NotNull] string app) => Utf8ToManaged(INTERNAL_SDL_GetPrefPath(Utf8Encode(org.Validate(), new byte[Utf8Size(org.Validate())], Utf8Size(org.Validate())), Utf8Encode(app.Validate(), new byte[Utf8Size(app.Validate())], Utf8Size(app.Validate()))), true);

        /// <summary>
        ///     Sdl the get power info using the specified secs
        /// </summary>
        /// <param name="secs">The secs</param>
        /// <param name="pct">The pct</param>
        /// <returns>The sdl power state</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern SdlPowerState SDL_GetPowerInfo(out int secs, out int pct);
        
        /// <summary>
        /// Sdl the get power info using the specified secs
        /// </summary>
        /// <param name="secs">The secs</param>
        /// <param name="pct">The pct</param>
        /// <returns>The sdl power state</returns>
        [return: NotNull]
        public static SdlPowerState SdlGetPowerInfo(out int secs, out int pct) => SDL_GetPowerInfo(out secs, out pct);

        /// <summary>
        ///     Sdl the get cpu count
        /// </summary>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern int SDL_GetCPUCount();
        
        /// <summary>
        /// Sdl the get cpu count
        /// </summary>
        /// <returns>The int</returns>
        [return: NotNull]
        public static int SdlGetCpuCount() => SDL_GetCPUCount();

        /// <summary>
        ///     Sdl the get cpu cache line size
        /// </summary>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern int SDL_GetCPUCacheLineSize();
        
        /// <summary>
        /// Sdl the get cpu cache line size
        /// </summary>
        /// <returns>The int</returns>
        [return: NotNull]
        public static int SdlGetCpuCacheLineSize() => SDL_GetCPUCacheLineSize();

        /// <summary>
        ///     Sdl the has rdtsc
        /// </summary>
        /// <returns>The sdl bool</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern SdlBool SDL_HasRDTSC();
        
        /// <summary>
        /// Sdl the has rdtsc
        /// </summary>
        /// <returns>The sdl bool</returns>
        [return: NotNull]
        public static SdlBool SdlHasRdtsc() => SDL_HasRDTSC();

        /// <summary>
        ///     Sdl the has alti vec
        /// </summary>
        /// <returns>The sdl bool</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern SdlBool SDL_HasAltiVec();
        
        /// <summary>
        /// Sdl the has alti vec
        /// </summary>
        /// <returns>The sdl bool</returns>
        [return: NotNull]
        public static SdlBool SdlHasAltiVec() => SDL_HasAltiVec();

        /// <summary>
        ///     Sdl the has mmx
        /// </summary>
        /// <returns>The sdl bool</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern SdlBool SDL_HasMMX();
        
        /// <summary>
        /// Sdl the has mmx
        /// </summary>
        /// <returns>The sdl bool</returns>
        [return: NotNull]
        public static SdlBool SdlHasMmx() => SDL_HasMMX();

        /// <summary>
        ///     Sdl the has 3 d now
        /// </summary>
        /// <returns>The sdl bool</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern SdlBool SDL_Has3DNow();
        
        /// <summary>
        /// Sdl the has 3 d now
        /// </summary>
        /// <returns>The sdl bool</returns>
        [return: NotNull]
        public static SdlBool SdlHas3DNow() => SDL_Has3DNow();

        /// <summary>
        ///     Sdl the has sse
        /// </summary>
        /// <returns>The sdl bool</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern SdlBool SDL_HasSSE();
        
        /// <summary>
        /// Sdl the has sse
        /// </summary>
        /// <returns>The sdl bool</returns>
        [return: NotNull]
        public static SdlBool SdlHasSse() => SDL_HasSSE();

        /// <summary>
        ///     Sdl the has sse 2
        /// </summary>
        /// <returns>The sdl bool</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern SdlBool SDL_HasSSE2();
        
        /// <summary>
        /// Sdl the has sse 2
        /// </summary>
        /// <returns>The sdl bool</returns>
        [return: NotNull]
        public static SdlBool SdlHasSse2() => SDL_HasSSE2();

        /// <summary>
        ///     Sdl the has sse 3
        /// </summary>
        /// <returns>The sdl bool</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern SdlBool SDL_HasSSE3();
        
        /// <summary>
        /// Sdl the has sse 3
        /// </summary>
        /// <returns>The sdl bool</returns>
        [return: NotNull]
        public static SdlBool SdlHasSse3() => SDL_HasSSE3();

        /// <summary>
        ///     Sdl the has sse 41
        /// </summary>
        /// <returns>The sdl bool</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern SdlBool SDL_HasSSE41();
        
        /// <summary>
        /// Sdl the has sse 41
        /// </summary>
        /// <returns>The sdl bool</returns>
        [return: NotNull]
        public static SdlBool SdlHasSse41() => SDL_HasSSE41();

        /// <summary>
        ///     Sdl the has sse 42
        /// </summary>
        /// <returns>The sdl bool</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern SdlBool SDL_HasSSE42();
        
        /// <summary>
        /// Sdl the has sse 42
        /// </summary>
        /// <returns>The sdl bool</returns>
        [return: NotNull]
        public static SdlBool SdlHasSse42() => SDL_HasSSE42();

        /// <summary>
        ///     Sdl the has avx
        /// </summary>
        /// <returns>The sdl bool</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern SdlBool SDL_HasAVX();
        
        /// <summary>
        /// Sdl the has avx
        /// </summary>
        /// <returns>The sdl bool</returns>
        [return: NotNull]
        public static SdlBool SdlHasAvx() => SDL_HasAVX();

        /// <summary>
        ///     Sdl the has avx 2
        /// </summary>
        /// <returns>The sdl bool</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern SdlBool SDL_HasAVX2();
        
        /// <summary>
        /// Sdl the has avx 2
        /// </summary>
        /// <returns>The sdl bool</returns>
        [return: NotNull]
        public static SdlBool SdlHasAvX2() => SDL_HasAVX2();

        /// <summary>
        ///     Sdl the has avx 512 f
        /// </summary>
        /// <returns>The sdl bool</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern SdlBool SDL_HasAVX512F();
        
        /// <summary>
        /// Sdl the has avx 512 f
        /// </summary>
        /// <returns>The sdl bool</returns>
        [return: NotNull]
        public static SdlBool SdlHasAvx512F() => SDL_HasAVX512F();

        /// <summary>
        ///     Sdl the has neon
        /// </summary>
        /// <returns>The sdl bool</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern SdlBool SDL_HasNEON();
        
        /// <summary>
        /// Sdl the has neon
        /// </summary>
        /// <returns>The sdl bool</returns>
        [return: NotNull]
        public static SdlBool SdlHasNeon() => SDL_HasNEON();

        /// <summary>
        ///     Sdl the get system ram
        /// </summary>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern int SDL_GetSystemRAM();
        
        /// <summary>
        /// Sdl the get system ram
        /// </summary>
        /// <returns>The int</returns>
        [return: NotNull]
        public static int SdlGetSystemRam() => SDL_GetSystemRAM();

        /// <summary>
        ///     Sdl the simd get alignment
        /// </summary>
        /// <returns>The uint</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern uint SDL_SIMDGetAlignment();
        
        /// <summary>
        /// Sdl the simd get alignment
        /// </summary>
        /// <returns>The uint</returns>
        [return: NotNull]
        public static uint SdlSimdGetAlignment() => SDL_SIMDGetAlignment();

        /// <summary>
        ///     Sdl the simd alloc using the specified len
        /// </summary>
        /// <param name="len">The len</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr SDL_SIMDAlloc([NotNull] uint len);
        
        /// <summary>
        /// Sdl the simd alloc using the specified len
        /// </summary>
        /// <param name="len">The len</param>
        /// <returns>The int ptr</returns>
        [return: NotNull]
        public static IntPtr SdlSimdAlloc([NotNull] uint len) => SDL_SIMDAlloc(len.Validate());

        /// <summary>
        ///     Sdl the simd realloc using the specified ptr
        /// </summary>
        /// <param name="ptr">The ptr</param>
        /// <param name="len">The len</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern IntPtr SDL_SIMDRealloc([NotNull]IntPtr ptr, [NotNull]uint len);
        
        /// <summary>
        /// Sdl the simd realloc using the specified ptr
        /// </summary>
        /// <param name="ptr">The ptr</param>
        /// <param name="len">The len</param>
        /// <returns>The int ptr</returns>
        [return: NotNull]
        public static IntPtr SdlSimdRealloc([NotNull] IntPtr ptr, [NotNull] uint len) => SDL_SIMDRealloc(ptr.Validate(), len.Validate());

        /// <summary>
        ///     Sdl the simd free using the specified ptr
        /// </summary>
        /// <param name="ptr">The ptr</param>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        private static extern void SDL_SIMDFree(IntPtr ptr);
        
        /// <summary>
        /// Sdl the simd free using the specified ptr
        /// </summary>
        /// <param name="ptr">The ptr</param>
        public static void SdlSimdFree([NotNull] IntPtr ptr) => SDL_SIMDFree(ptr.Validate());

        /// <summary>
        ///     Sdl the has arms imd
        /// </summary>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        private static extern void SDL_HasARMSIMD();
        
        /// <summary>
        /// Sdl the has armsimd
        /// </summary>
        public static void SdlHasArmsimd() => SDL_HasARMSIMD();

        /// <summary>
        ///     Sdl the get preferred locales
        /// </summary>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr SDL_GetPreferredLocales();
        
        /// <summary>
        /// Sdl the get preferred locales
        /// </summary>
        /// <returns>The int ptr</returns>
        [return: NotNull]
        public static IntPtr SdlGetPreferredLocales() => SDL_GetPreferredLocales();

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
        public static int SDL_OpenURL([NotNull] string url) => INTERNAL_SDL_OpenURL(Utf8EncodeHeap(url.Validate()));
    }
}