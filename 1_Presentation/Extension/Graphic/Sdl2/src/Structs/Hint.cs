// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:Hint.cs
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

namespace Alis.Extension.Graphic.Sdl2.Structs
{
    /// <summary>
    ///     Provides string constants for SDL hint names used to configure video, audio, input, and platform-specific behaviour.
    /// </summary>
    public static class Hint
    {
        /// <summary>
        ///     Controls whether framebuffer acceleration is enabled.
        /// </summary>
        public const string HintFramebufferAcceleration = "SDL_FRAMEBUFFER_ACCELERATION";

        /// <summary>
        ///     Specifies the render driver to use (e.g. "direct3d", "opengl", "software").
        /// </summary>
        public const string HintRenderDriver = "SDL_RENDER_DRIVER";

        /// <summary>
        ///     Enables or disables OpenGL shaders in the renderer.
        /// </summary>
        public const string HintRenderOpenglShaders = "SDL_RENDER_OPENGL_SHADERS";

        /// <summary>
        ///     Controls whether Direct3D rendering is threadsafe.
        /// </summary>
        public const string HintRenderDirect3DThreadsafe = "SDL_RENDER_DIRECT3D_THREADSAFE";

        /// <summary>
        ///     Enables or disables vertical sync (vsync) in the renderer.
        /// </summary>
        public const string HintRenderVsync = "SDL_RENDER_VSYNC";

        /// <summary>
        ///     Controls whether X11 VidMode extension is used for fullscreen.
        /// </summary>
        public const string HintVideoX11XVidMode = "SDL_VIDEO_X11_XVIDMODE";

        /// <summary>
        ///     Controls whether X11 Xinerama extension is used.
        /// </summary>
        public const string HintVideoX11XIneRama = "SDL_VIDEO_X11_XINERAMA";

        /// <summary>
        ///     Controls whether X11 XRandR extension is used for resolution switching.
        /// </summary>
        public const string HintVideoX11Xrandr = "SDL_VIDEO_X11_XRANDR";

        /// <summary>
        ///     Controls whether the keyboard is grabbed in fullscreen mode.
        /// </summary>
        public const string HintGrabKeyboard = "SDL_GRAB_KEYBOARD";

        /// <summary>
        ///     Controls whether the video is minimized when focus is lost.
        /// </summary>
        public const string HintVideoMinimizeOnFocusLoss = "SDL_VIDEO_MINIMIZE_ON_FOCUS_LOSS";

        /// <summary>
        ///     Disables the iOS idle timer to prevent screen sleep.
        /// </summary>
        public const string HintIdleTimerDisabled = "SDL_IOS_IDLE_TIMER_DISABLED";

        /// <summary>
        ///     Specifies allowed iOS orientations.
        /// </summary>
        public const string HintOrientations = "SDL_IOS_ORIENTATIONS";

        /// <summary>
        ///     Enables or disables XInput game controller support on Windows.
        /// </summary>
        public const string HintXInputEnabled = "SDL_XINPUT_ENABLED";

        /// <summary>
        ///     Specifies a custom game controller mapping database.
        /// </summary>
        public const string HintGameControllerConfig = "SDL_GAMECONTROLLERCONFIG";

        /// <summary>
        ///     Allows joystick events to be processed when the application is in the background.
        /// </summary>
        public const string HintJoystickAllowBackgroundEvents = "SDL_JOYSTICK_ALLOW_BACKGROUND_EVENTS";

        /// <summary>
        ///     Controls whether the window can be topmost.
        /// </summary>
        public const string HintAllowTopmost = "SDL_ALLOW_TOPMOST";

        /// <summary>
        ///     Specifies the timer resolution in milliseconds.
        /// </summary>
        public const string HintTimerResolution = "SDL_TIMER_RESOLUTION";

        /// <summary>
        ///     Sets the render scaling quality (0 = nearest pixel, 1 = linear, 2 = anisotropic).
        /// </summary>
        public const string HintRenderScaleQuality = "SDL_RENDER_SCALE_QUALITY";

        /// <summary>
        ///     Disables high-DPI mode on supported platforms.
        /// </summary>
        public const string HintVideoHighDpiDisabled = "SDL_VIDEO_HIGHDPI_DISABLED";

        /// <summary>
        ///     Emulates a right-click when Ctrl+click is pressed.
        /// </summary>
        public const string HintCtrlClickEmulateRightClick = "SDL_CTRL_CLICK_EMULATE_RIGHT_CLICK";

        /// <summary>
        ///     Specifies the Direct3D shader compiler to use on Windows.
        /// </summary>
        public const string HintVideoWinD3DCompiler = "SDL_VIDEO_WIN_D3DCOMPILER";

        /// <summary>
        ///     Enables mouse relative mode warp instead of raw input.
        /// </summary>
        public const string HintMouseRelativeModeWarp = "SDL_MOUSE_RELATIVE_MODE_WARP";

        /// <summary>
        ///     Shares the pixel format between windows.
        /// </summary>
        public const string HintVideoWindowSharePixelFormat = "SDL_VIDEO_WINDOW_SHARE_PIXEL_FORMAT";

        /// <summary>
        ///     Allows the screensaver to activate while the application is running.
        /// </summary>
        public const string HintVideoAllowScreensaver = "SDL_VIDEO_ALLOW_SCREENSAVER";

        /// <summary>
        ///     Treats the accelerometer as a joystick device on mobile platforms.
        /// </summary>
        public const string HintAccelerometerAsJoystick = "SDL_ACCELEROMETER_AS_JOYSTICK";

        /// <summary>
        ///     Enables or disables macOS fullscreen spaces support.
        /// </summary>
        public const string HintVideoMacFullscreenSpaces = "SDL_VIDEO_MAC_FULLSCREEN_SPACES";

        /// <summary>
        ///     Specifies the WinRT privacy policy URL.
        /// </summary>
        public const string HintWinrtPrivacyPolicyUrl = "SDL_WINRT_PRIVACY_POLICY_URL";

        /// <summary>
        ///     Specifies the WinRT privacy policy label text.
        /// </summary>
        public const string HintWinrtPrivacyPolicyLabel = "SDL_WINRT_PRIVACY_POLICY_LABEL";

        /// <summary>
        ///     Controls whether WinRT handles the back button natively.
        /// </summary>
        public const string HintWinrtHandleBackButton = "SDL_WINRT_HANDLE_BACK_BUTTON";

        /// <summary>
        ///     Prevents SDL from installing its own signal handlers.
        /// </summary>
        public const string HintNoSignalHandlers = "SDL_NO_SIGNAL_HANDLERS";

        /// <summary>
        ///     Enables or disables IME internal editing.
        /// </summary>
        public const string HintImeInternalEditing = "SDL_IME_INTERNAL_EDITING";

        /// <summary>
        ///     Separates mouse and touch input on Android.
        /// </summary>
        public const string HintAndroidSeparateMouseAndTouch = "SDL_ANDROID_SEPARATE_MOUSE_AND_TOUCH";

        /// <summary>
        ///     Specifies the Emscripten keyboard element ID.
        /// </summary>
        public const string HintEmscriptenKeyboardElement = "SDL_EMSCRIPTEN_KEYBOARD_ELEMENT";

        /// <summary>
        ///     Specifies the default thread stack size in bytes.
        /// </summary>
        public const string HintThreadStackSize = "SDL_THREAD_STACK_SIZE";

        /// <summary>
        ///     Allows the window frame to be usable while the cursor is hidden.
        /// </summary>
        public const string HintWindowFrameUsableWhileCursorHidden = "SDL_WINDOW_FRAME_USABLE_WHILE_CURSOR_HIDDEN";

        /// <summary>
        ///     Enables the Windows message loop.
        /// </summary>
        public const string HintWindowsEnableMessageLoop = "SDL_WINDOWS_ENABLE_MESSAGELOOP";

        /// <summary>
        ///     Prevents Alt+F4 from closing the window on Windows.
        /// </summary>
        public const string HintWindowsNoCloseOnAltF4 = "SDL_WINDOWS_NO_CLOSE_ON_ALT_F4";

        /// <summary>
        ///     Uses the old joystick mapping for XInput devices.
        /// </summary>
        public const string HintXInputUseOldJoystickMapping = "SDL_XINPUT_USE_OLD_JOYSTICK_MAPPING";

        /// <summary>
        ///     Treats the macOS application as a background app (no menu bar).
        /// </summary>
        public const string HintMacBackgroundApp = "SDL_MAC_BACKGROUND_APP";

        /// <summary>
        ///     Enables or disables X11 _NET_WM_PING protocol support.
        /// </summary>
        public const string HintVideoX11NetWmPing = "SDL_VIDEO_X11_NET_WM_PING";

        /// <summary>
        ///     Specifies the Android APK expansion main file version.
        /// </summary>
        public const string HintAndroidApkExpansionMainFileVersion = "SDL_ANDROID_APK_EXPANSION_MAIN_FILE_VERSION";

        /// <summary>
        ///     Specifies the Android APK expansion patch file version.
        /// </summary>
        public const string HintAndroidApkExpansionPatchFileVersion = "SDL_ANDROID_APK_EXPANSION_PATCH_FILE_VERSION";

        /// <summary>
        ///     Allows mouse events to pass through clicks that activate the window.
        /// </summary>
        public const string HintMouseFocusClickThrough = "SDL_MOUSE_FOCUS_CLICKTHROUGH";

        /// <summary>
        ///     Saves BMP files in the legacy (old) format.
        /// </summary>
        public const string HintBmpSaveLegacyFormat = "SDL_BMP_SAVE_LEGACY_FORMAT";

        /// <summary>
        ///     Disables Windows thread naming via exception.
        /// </summary>
        public const string HintWindowsDisableThreadNaming = "SDL_WINDOWS_DISABLE_THREAD_NAMING";

        /// <summary>
        ///     Allows rotation of the Apple TV remote.
        /// </summary>
        public const string HintAppleTvRemoteAllowRotation = "SDL_APPLE_TV_REMOTE_ALLOW_ROTATION";

        /// <summary>
        ///     Specifies the audio resampling mode (e.g. "normal", "fast", "medium", "best").
        /// </summary>
        public const string HintAudioResamplingMode = "SDL_AUDIO_RESAMPLING_MODE";

        /// <summary>
        ///     Controls how the logical size is applied in the renderer.
        /// </summary>
        public const string HintRenderLogicalSizeMode = "SDL_RENDER_LOGICAL_SIZE_MODE";

        /// <summary>
        ///     Sets the mouse normal (non-relative) speed scale factor.
        /// </summary>
        public const string HintMouseNormalSpeedScale = "SDL_MOUSE_NORMAL_SPEED_SCALE";

        /// <summary>
        ///     Sets the mouse relative mode speed scale factor.
        /// </summary>
        public const string HintMouseRelativeSpeedScale = "SDL_MOUSE_RELATIVE_SPEED_SCALE";

        /// <summary>
        ///     Controls whether touch events generate synthetic mouse events.
        /// </summary>
        public const string HintTouchMouseEvents = "SDL_TOUCH_MOUSE_EVENTS";

        /// <summary>
        ///     Specifies the Windows icon resource (large).
        /// </summary>
        public const string HintWindowsIntroSourceIcon = "SDL_WINDOWS_INTRESOURCE_ICON";

        /// <summary>
        ///     Specifies the Windows icon resource (small).
        /// </summary>
        public const string HintWindowsIntroSourceIconSmall = "SDL_WINDOWS_INTRESOURCE_ICON_SMALL";

        /// <summary>
        ///     Hides the iOS home indicator on iPhone X and later.
        /// </summary>
        public const string HintIosHideHomeIndicator = "SDL_IOS_HIDE_HOME_INDICATOR";

        /// <summary>
        ///     Treats the Apple TV remote as a joystick device.
        /// </summary>
        public const string HintTvRemoteAsJoystick = "SDL_TV_REMOTE_AS_JOYSTICK";

        /// <summary>
        ///     Bypasses the X11 compositor for fullscreen windows.
        /// </summary>
        public const string VideoX11NetWmBypassCompositor = "SDL_VIDEO_X11_NET_WM_BYPASS_COMPOSITOR";

        /// <summary>
        ///     Sets the mouse double-click time threshold in milliseconds.
        /// </summary>
        public const string HintMouseDoubleClickTime = "SDL_MOUSE_DOUBLE_CLICK_TIME";

        /// <summary>
        ///     Sets the mouse double-click distance radius in pixels.
        /// </summary>
        public const string HintMouseDoubleClickRadius = "SDL_MOUSE_DOUBLE_CLICK_RADIUS";

        /// <summary>
        ///     Enables or disables HIDAPI joystick support.
        /// </summary>
        public const string HintJoystickHidapi = "SDL_JOYSTICK_HIDAPI";

        /// <summary>
        ///     Enables or disables HIDAPI support for PS4 controllers.
        /// </summary>
        public const string HintJoystickHidapiPs4 = "SDL_JOYSTICK_HIDAPI_PS4";

        /// <summary>
        ///     Enables or disables rumble for PS4 controllers via HIDAPI.
        /// </summary>
        public const string HintJoystickHidapiPs4Rumble = "SDL_JOYSTICK_HIDAPI_PS4_RUMBLE";

        /// <summary>
        ///     Enables or disables HIDAPI support for Steam Controllers.
        /// </summary>
        public const string HintJoystickHidapiSteam = "SDL_JOYSTICK_HIDAPI_STEAM";

        /// <summary>
        ///     Enables or disables HIDAPI support for Nintendo Switch controllers.
        /// </summary>
        public const string HintJoystickHidapiSwitch = "SDL_JOYSTICK_HIDAPI_SWITCH";

        /// <summary>
        ///     Enables or disables HIDAPI support for Xbox controllers.
        /// </summary>
        public const string HintJoystickHidapiXbox = "SDL_JOYSTICK_HIDAPI_XBOX";

        /// <summary>
        ///     Enables or disables native Steam controller support.
        /// </summary>
        public const string HintEnableSteamControllers = "SDL_ENABLE_STEAM_CONTROLLERS";

        /// <summary>
        ///     Controls whether the Android back button is trapped by SDL.
        /// </summary>
        public const string HintAndroidTrapBackButton = "SDL_ANDROID_TRAP_BACK_BUTTON";

        /// <summary>
        ///     Controls whether mouse events generate synthetic touch events.
        /// </summary>
        public const string HintMouseTouchEvents = "SDL_MOUSE_TOUCH_EVENTS";

        /// <summary>
        ///     Specifies the game controller mapping database file path.
        /// </summary>
        public const string HintGameControllerConfigFile = "SDL_GAMECONTROLLERCONFIG_FILE";

        /// <summary>
        ///     Controls whether the Android app blocks in a pause state.
        /// </summary>
        public const string HintAndroidBlockOnPause = "SDL_ANDROID_BLOCK_ON_PAUSE";

        /// <summary>
        ///     Enables or disables render batching.
        /// </summary>
        public const string HintRenderBatching = "SDL_RENDER_BATCHING";

        /// <summary>
        ///     Enables or disables SDL event logging for debugging.
        /// </summary>
        public const string HintEventLogging = "SDL_EVENT_LOGGING";

        /// <summary>
        ///     Specifies the RIFF chunk size for WAVE files.
        /// </summary>
        public const string HintWaveRiffChunkSize = "SDL_WAVE_RIFF_CHUNK_SIZE";

        /// <summary>
        ///     Controls how WAVE files are truncated (e.g. "std", "dropblock", "dropref").
        /// </summary>
        public const string HintWaveTruncation = "SDL_WAVE_TRUNCATION";

        /// <summary>
        ///     Controls how the WAVE fact chunk is handled.
        /// </summary>
        public const string HintWaveFactChunk = "SDL_WAVE_FACT_CHUNK";

        /// <summary>
        ///     Specifies the X11 window visual ID.
        /// </summary>
        public const string HintVideoX11WindowVisualId = "SDL_VIDEO_X11_WINDOW_VISUALID";

        /// <summary>
        ///     Controls whether the game controller uses button labels (e.g. A/B) instead of positions.
        /// </summary>
        public const string HintGameControllerUseButtonLabels = "SDL_GAMECONTROLLER_USE_BUTTON_LABELS";

        /// <summary>
        ///     Enables or disables external video context.
        /// </summary>
        public const string HintVideoExternalContext = "SDL_VIDEO_EXTERNAL_CONTEXT";

        /// <summary>
        ///     Enables or disables HIDAPI support for GameCube controllers.
        /// </summary>
        public const string HintJoystickHidapiGameCube = "SDL_JOYSTICK_HIDAPI_GAMECUBE";

        /// <summary>
        ///     Returns usable display bounds instead of raw coordinates.
        /// </summary>
        public const string HintDisplayUsableBounds = "SDL_DISPLAY_USABLE_BOUNDS";

        /// <summary>
        ///     Forces EGL for X11 video output.
        /// </summary>
        public const string HintVideoX11ForceEgl = "SDL_VIDEO_X11_FORCE_EGL";

        /// <summary>
        ///     Specifies the game controller type override.
        /// </summary>
        public const string HintGameControllerType = "SDL_GAMECONTROLLERTYPE";

        /// <summary>
        ///     Correlates HIDAPI joystick input with XInput on Windows.
        /// </summary>
        public const string HintJoystickHidapiCorrelateXInput = "SDL_JOYSTICK_HIDAPI_CORRELATE_XINPUT";

        /// <summary>
        ///     Enables raw input for joysticks on Windows.
        /// </summary>
        public const string HintJoystickRawInput = "SDL_JOYSTICK_RAWINPUT";

        /// <summary>
        ///     Specifies the audio device app name for system mixers.
        /// </summary>
        public const string HintAudioDeviceAppName = "SDL_AUDIO_DEVICE_APP_NAME";

        /// <summary>
        ///     Specifies the audio device stream name for system mixers.
        /// </summary>
        public const string HintAudioDeviceStreamName = "SDL_AUDIO_DEVICE_STREAM_NAME";

        /// <summary>
        ///     Specifies the preferred locales for the application.
        /// </summary>
        public const string HintPreferredLocales = "SDL_PREFERRED_LOCALES";

        /// <summary>
        ///     Specifies the thread priority policy.
        /// </summary>
        public const string HintThreadPriorityPolicy = "SDL_THREAD_PRIORITY_POLICY";

        /// <summary>
        ///     Enables Emscripten asyncify support.
        /// </summary>
        public const string HintEmscriptenAsyncify = "SDL_EMSCRIPTEN_ASYNCIFY";

        /// <summary>
        ///     Enables Linux joystick dead zone processing.
        /// </summary>
        public const string HintLinuxJoystickDeadZones = "SDL_LINUX_JOYSTICK_DEADZONES";

        /// <summary>
        ///     Controls whether audio pauses when Android app is blocked on pause.
        /// </summary>
        public const string HintAndroidBlockOnPausePauseAudio = "SDL_ANDROID_BLOCK_ON_PAUSE_PAUSEAUDIO";

        /// <summary>
        ///     Enables or disables HIDAPI support for PS5 controllers.
        /// </summary>
        public const string HintJoystickHidapiPs5 = "SDL_JOYSTICK_HIDAPI_PS5";

        /// <summary>
        ///     Forces time-critical threads to use realtime scheduling.
        /// </summary>
        public const string HintThreadForceRealtimeTimeCritical = "SDL_THREAD_FORCE_REALTIME_TIME_CRITICAL";

        /// <summary>
        ///     Runs joystick processing in a separate thread.
        /// </summary>
        public const string SdlHintJoystickThread = "SDL_JOYSTICK_THREAD";

        /// <summary>
        ///     Automatically updates joystick device list.
        /// </summary>
        public const string HintAutoUpdateJoysticks = "SDL_AUTO_UPDATE_JOYSTICKS";

        /// <summary>
        ///     Automatically updates sensor device list.
        /// </summary>
        public const string HintAutoUpdateSensors = "SDL_AUTO_UPDATE_SENSORS";

        /// <summary>
        ///     Enables mouse relative mode scaling for consistent sensitivity.
        /// </summary>
        public const string HintMouseRelativeScaling = "SDL_MOUSE_RELATIVE_SCALING";

        /// <summary>
        ///     Enables or disables rumble for PS5 controllers via HIDAPI.
        /// </summary>
        public const string HintJoystickHidapiPs5Rumble = "SDL_JOYSTICK_HIDAPI_PS5_RUMBLE";

        /// <summary>
        ///     Forces mutex to use critical sections on Windows.
        /// </summary>
        public const string HintWindowsForceMutexCriticalSections = "SDL_WINDOWS_FORCE_MUTEX_CRITICAL_SECTIONS";

        /// <summary>
        ///     Forces semaphore to use kernel objects on Windows.
        /// </summary>
        public const string HintWindowsForceSemaphoreKernel = "SDL_WINDOWS_FORCE_SEMAPHORE_KERNEL";

        /// <summary>
        ///     Controls the PS5 controller player LED brightness (0-255).
        /// </summary>
        public const string HintJoystickHidapiPs5PlayerLed = "SDL_JOYSTICK_HIDAPI_PS5_PLAYER_LED";

        /// <summary>
        ///     Uses Direct3D 9Ex on Windows for better compatibility.
        /// </summary>
        public const string HintWindowsUseD3D9Ex = "SDL_WINDOWS_USE_D3D9EX";

        /// <summary>
        ///     Enables or disables HIDAPI support for Joy-Con controllers.
        /// </summary>
        public const string HintJoystickHidapiJoyCons = "SDL_JOYSTICK_HIDAPI_JOY_CONS";

        /// <summary>
        ///     Enables or disables HIDAPI support for Stadia controllers.
        /// </summary>
        public const string HintJoystickHidapiStadia = "SDL_JOYSTICK_HIDAPI_STADIA";

        /// <summary>
        ///     Controls the Switch home button LED via HIDAPI.
        /// </summary>
        public const string HintJoystickHidapiSwitchHomeLed = "SDL_JOYSTICK_HIDAPI_SWITCH_HOME_LED";

        /// <summary>
        ///     Allows Alt+Tab while the mouse is grabbed.
        /// </summary>
        public const string HintAllowAltTabWhileGrabbed = "SDL_ALLOW_ALT_TAB_WHILE_GRABBED";

        /// <summary>
        ///     Requires DRM master for KMS/DRM video driver.
        /// </summary>
        public const string HintKmSdFmRequireDrmMaster = "SDL_KMSDRM_REQUIRE_DRM_MASTER";

        /// <summary>
        ///     Specifies the audio device stream role.
        /// </summary>
        public const string HintAudioDeviceStreamRole = "SDL_AUDIO_DEVICE_STREAM_ROLE";

        /// <summary>
        ///     Forces override redirect on X11 windows (bypasses window manager).
        /// </summary>
        public const string HintX11ForceOverrideRedirect = "SDL_X11_FORCE_OVERRIDE_REDIRECT";

        /// <summary>
        ///     Enables or disables HIDAPI support for Amazon Luna controllers.
        /// </summary>
        public const string HintJoystickHidapiLuna = "SDL_JOYSTICK_HIDAPI_LUNA";

        /// <summary>
        ///     Correlates raw input joystick data with XInput on Windows.
        /// </summary>
        public const string HintJoystickRawInputCorrelateXInput = "SDL_JOYSTICK_RAWINPUT_CORRELATE_XINPUT";

        /// <summary>
        ///     Includes monitor audio outputs in the audio device list.
        /// </summary>
        public const string HintAudioIncludeMonitors = "SDL_AUDIO_INCLUDE_MONITORS";

        /// <summary>
        ///     Allows libdecor for Wayland window decorations.
        /// </summary>
        public const string HintVideoWaylandAllowLibDecor = "SDL_VIDEO_WAYLAND_ALLOW_LIBDECOR";

        /// <summary>
        ///     Allows transparency in EGL surfaces.
        /// </summary>
        public const string HintVideoEglAllowTransparency = "SDL_VIDEO_EGL_ALLOW_TRANSPARENCY";

        /// <summary>
        ///     Specifies the application name for system UI.
        /// </summary>
        public const string HintAppName = "SDL_APP_NAME";

        /// <summary>
        ///     Specifies the activity name for screensaver inhibition.
        /// </summary>
        public const string HintScreensaverInhibitActivityName = "SDL_SCREENSAVER_INHIBIT_ACTIVITY_NAME";

        /// <summary>
        ///     Controls whether the IME UI is shown.
        /// </summary>
        public const string HintImeShowUi = "SDL_IME_SHOW_UI";

        /// <summary>
        ///     Prevents the window from being activated when shown.
        /// </summary>
        public const string HintWindowNoActivationWhenShown = "SDL_WINDOW_NO_ACTIVATION_WHEN_SHOWN";

        /// <summary>
        ///     Enables polling for a sentinel value in the event queue.
        /// </summary>
        public const string HintPollSentinel = "SDL_POLL_SENTINEL";

        /// <summary>
        ///     Specifies the joystick device path on Linux.
        /// </summary>
        public const string HintJoystickDevice = "SDL_JOYSTICK_DEVICE";

        /// <summary>
        ///     Uses the classic Linux joystick driver.
        /// </summary>
        public const string HintLinuxJoystickClassic = "SDL_LINUX_JOYSTICK_CLASSIC";
    }
}