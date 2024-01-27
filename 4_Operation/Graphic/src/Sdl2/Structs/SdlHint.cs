// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File: SdlHint.cs
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

namespace Alis.Core.Graphic.Sdl2.Structs
{
    /// <summary>
    /// The sdl hint class
    /// </summary>
    public static class SdlHint 
    {
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
    }
}