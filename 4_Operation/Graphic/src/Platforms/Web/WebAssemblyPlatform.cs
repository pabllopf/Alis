// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:WebAssemblyPlatform.cs
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
using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;
using System.Text;

namespace Alis.Core.Graphic.Platforms.Web
{
    /// <summary>
    ///     WebAssembly platform controller implementing INativePlatform interface
    ///     Provides full support for graphics, input handling, and window management
    ///     in WebAssembly environments for cross-platform game development.
    /// </summary>
    public class WebAssemblyPlatform : INativePlatform
    {
        // Window and rendering state
        /// <summary>
        /// The window width
        /// </summary>
        private int _windowWidth;
        /// <summary>
        /// The window height
        /// </summary>
        private int _windowHeight;
        /// <summary>
        /// The window title
        /// </summary>
        private string _windowTitle;
        /// <summary>
        /// The is window visible
        /// </summary>
        private bool _isWindowVisible;
        /// <summary>
        /// The window should close
        /// </summary>
        private bool _windowShouldClose;

        // EGL context state
        /// <summary>
        /// The zero
        /// </summary>
        private IntPtr _eglDisplay = IntPtr.Zero;
        /// <summary>
        /// The zero
        /// </summary>
        private IntPtr _eglContext = IntPtr.Zero;
        /// <summary>
        /// The zero
        /// </summary>
        private IntPtr _eglSurface = IntPtr.Zero;
        /// <summary>
        /// The zero
        /// </summary>
        private IntPtr _eglConfig = IntPtr.Zero;

        // Input state
        /// <summary>
        /// The key states
        /// </summary>
        private readonly Dictionary<ConsoleKey, bool> _keyStates;
        /// <summary>
        /// The key pressed queue
        /// </summary>
        private readonly Queue<ConsoleKey> _keyPressedQueue;
        /// <summary>
        /// The input character builder
        /// </summary>
        private readonly StringBuilder _inputCharacterBuilder;
        /// <summary>
        /// The mouse
        /// </summary>
        private int _mouseX;
        /// <summary>
        /// The mouse
        /// </summary>
        private int _mouseY;
        /// <summary>
        /// The mouse buttons
        /// </summary>
        private readonly bool[] _mouseButtons; // [left, right, middle, aux1, aux2]
        /// <summary>
        /// The mouse wheel delta
        /// </summary>
        private float _mouseWheelDelta;
        /// <summary>
        /// The gamepad states
        /// </summary>
        private readonly Dictionary<int, GamepadState> _gamepadStates;
        /// <summary>
        /// The is initialized
        /// </summary>
        private bool _isInitialized;

        /// <summary>
        ///     Initializes a new instance of the WebAssemblyPlatform class
        /// </summary>
        public WebAssemblyPlatform()
        {
            _windowWidth = 800;
            _windowHeight = 600;
            _windowTitle = "WebAssembly Application";
            _isWindowVisible = false;
            _windowShouldClose = false;
            _isInitialized = false;

            _keyStates = new Dictionary<ConsoleKey, bool>();
            _keyPressedQueue = new Queue<ConsoleKey>();
            _inputCharacterBuilder = new StringBuilder();
            _mouseButtons = new bool[5] { false, false, false, false, false };
            _mouseWheelDelta = 0.0f;
            _gamepadStates = new Dictionary<int, GamepadState>();

            InitializeDefaultKeyStates();
        }

        /// <summary>
        ///     Initializes default key states for all console keys
        /// </summary>
        private void InitializeDefaultKeyStates()
        {
            _keyStates.Clear();
            foreach (ConsoleKey key in Enum.GetValues(typeof(ConsoleKey)))
            {
                _keyStates[key] = false;
            }
        }

        /// <summary>
        ///     Initializes the window and EGL context with specified dimensions and title
        /// </summary>
        public bool Initialize(int width, int height, string title)
        {
            return Initialize(width, height, title, null);
        }

        /// <summary>
        ///     Initializes the window and EGL context with dimensions, title, and icon
        /// </summary>
        public bool Initialize(int width, int height, string title, string iconPath)
        {
            if (_isInitialized)
            {
                return true;
            }

            _windowWidth = width;
            _windowHeight = height;
            _windowTitle = title;

            try
            {
                InitializeEglContext();
                RegisterInputEvents();
                _isInitialized = true;
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        ///     Initializes the EGL rendering context for WebAssembly
        /// </summary>
        private void InitializeEglContext()
        {
            _eglDisplay = EGL.GetDisplay(IntPtr.Zero);
            if (_eglDisplay == IntPtr.Zero)
            {
                throw new InvalidOperationException("Failed to get EGL display");
            }

            if (!EGL.Initialize(_eglDisplay, out _, out _))
            {
                throw new InvalidOperationException("Failed to initialize EGL");
            }

            if (!EGL.BindApi(EGL.EGL_OPENGL_ES_API))
            {
                throw new InvalidOperationException("Failed to bind OpenGL ES API");
            }

            int[] configAttributes = new int[]
            {
                EGL.EGL_RED_SIZE, 8,
                EGL.EGL_GREEN_SIZE, 8,
                EGL.EGL_BLUE_SIZE, 8,
                EGL.EGL_DEPTH_SIZE, 24,
                EGL.EGL_STENCIL_SIZE, 8,
                EGL.EGL_SURFACE_TYPE, EGL.EGL_WINDOW_BIT,
                EGL.EGL_RENDERABLE_TYPE, EGL.EGL_OPENGL_ES3_BIT,
                EGL.EGL_SAMPLES, 4,
                EGL.EGL_NONE
            };

            IntPtr config = IntPtr.Zero;
            IntPtr configSize = new IntPtr(1);
            IntPtr numConfig = IntPtr.Zero;

            if (!EGL.ChooseConfig(_eglDisplay, configAttributes, ref config, configSize, ref numConfig))
            {
                throw new InvalidOperationException("Failed to choose EGL config");
            }

            _eglConfig = config;

            int[] contextAttributes = new int[]
            {
                EGL.EGL_CONTEXT_CLIENT_VERSION, 3,
                EGL.EGL_NONE
            };

            _eglContext = EGL.CreateContext(_eglDisplay, _eglConfig, IntPtr.Zero, contextAttributes);
            if (_eglContext == IntPtr.Zero)
            {
                throw new InvalidOperationException("Failed to create EGL context");
            }

            _eglSurface = EGL.CreateWindowSurface(_eglDisplay, _eglConfig, IntPtr.Zero, IntPtr.Zero);
            if (_eglSurface == IntPtr.Zero)
            {
                throw new InvalidOperationException("Failed to create EGL window surface");
            }

            if (!EGL.MakeCurrent(_eglDisplay, _eglSurface, _eglSurface, _eglContext))
            {
                throw new InvalidOperationException("Failed to make EGL context current");
            }
        }

        /// <summary>
        ///     Registers input event handlers for keyboard, mouse, and gamepad
        /// </summary>
        private void RegisterInputEvents()
        {
            RegisterKeyboardEvents();
            RegisterMouseEvents();
            RegisterGamepadEvents();
            RegisterWindowEvents();
        }

        /// <summary>
        ///     Registers keyboard event listeners via JavaScript interop
        /// </summary>
        private void RegisterKeyboardEvents()
        {
            try
            {
                EmscriptenWeb.RegisterKeyboardCallbacks(
                    Marshal.GetFunctionPointerForDelegate((KeyEventDelegate)OnKeyDown),
                    Marshal.GetFunctionPointerForDelegate((KeyEventDelegate)OnKeyUp),
                    Marshal.GetFunctionPointerForDelegate((KeyCharDelegate)OnCharInput)
                );
            }
            catch
            {
                // Graceful fallback if JavaScript interop is not available
            }
        }

        /// <summary>
        ///     Registers mouse event listeners via JavaScript interop
        /// </summary>
        private void RegisterMouseEvents()
        {
            try
            {
                EmscriptenWeb.RegisterMouseCallbacks(
                    Marshal.GetFunctionPointerForDelegate((MouseMoveDelegate)OnMouseMove),
                    Marshal.GetFunctionPointerForDelegate((MouseButtonDelegate)OnMouseDown),
                    Marshal.GetFunctionPointerForDelegate((MouseButtonDelegate)OnMouseUp),
                    Marshal.GetFunctionPointerForDelegate((MouseWheelDelegate)OnMouseWheel)
                );
            }
            catch
            {
                // Graceful fallback if JavaScript interop is not available
            }
        }

        /// <summary>
        ///     Registers gamepad event listeners via JavaScript interop
        /// </summary>
        private void RegisterGamepadEvents()
        {
            try
            {
                EmscriptenWeb.RegisterGamepadCallbacks(
                    Marshal.GetFunctionPointerForDelegate((GamepadConnectDelegate)OnGamepadConnect),
                    Marshal.GetFunctionPointerForDelegate((GamepadDisconnectDelegate)OnGamepadDisconnect)
                );
            }
            catch
            {
                // Graceful fallback if JavaScript interop is not available
            }
        }

        /// <summary>
        ///     Registers window event listeners via JavaScript interop
        /// </summary>
        private void RegisterWindowEvents()
        {
            try
            {
                EmscriptenWeb.RegisterWindowCallbacks(
                    Marshal.GetFunctionPointerForDelegate((WindowResizeDelegate)OnWindowResize),
                    Marshal.GetFunctionPointerForDelegate((WindowCloseDelegate)OnWindowClose),
                    Marshal.GetFunctionPointerForDelegate((WindowFocusDelegate)OnWindowFocus)
                );
            }
            catch
            {
                // Graceful fallback if JavaScript interop is not available
            }
        }

        /// <summary>
        ///     Callback for keyboard key down events
        /// </summary>
        private void OnKeyDown(int keyCode, int location)
        {
            ConsoleKey key = ConvertKeyCode(keyCode);
            if (!_keyStates.ContainsKey(key))
            {
                _keyStates[key] = true;
                _keyPressedQueue.Enqueue(key);
            }
            else if (!_keyStates[key])
            {
                _keyStates[key] = true;
                _keyPressedQueue.Enqueue(key);
            }
        }

        /// <summary>
        ///     Callback for keyboard key up events
        /// </summary>
        private void OnKeyUp(int keyCode, int location)
        {
            ConsoleKey key = ConvertKeyCode(keyCode);
            if (_keyStates.ContainsKey(key))
            {
                _keyStates[key] = false;
            }
        }

        /// <summary>
        ///     Callback for character input events
        /// </summary>
        private void OnCharInput(uint charCode)
        {
            try
            {
                _inputCharacterBuilder.Append(char.ConvertFromUtf32((int)charCode));
            }
            catch
            {
                // Invalid character code
            }
        }

        /// <summary>
        ///     Callback for mouse movement events
        /// </summary>
        private void OnMouseMove(int x, int y, int clientX, int clientY)
        {
            _mouseX = clientX;
            _mouseY = clientY;
        }

        /// <summary>
        ///     Callback for mouse button down events
        /// </summary>
        private void OnMouseDown(int button, int x, int y, int clientX, int clientY)
        {
            if (button >= 0 && button < _mouseButtons.Length)
            {
                _mouseButtons[button] = true;
            }
            _mouseX = clientX;
            _mouseY = clientY;
        }

        /// <summary>
        ///     Callback for mouse button up events
        /// </summary>
        private void OnMouseUp(int button, int x, int y, int clientX, int clientY)
        {
            if (button >= 0 && button < _mouseButtons.Length)
            {
                _mouseButtons[button] = false;
            }
            _mouseX = clientX;
            _mouseY = clientY;
        }

        /// <summary>
        ///     Callback for mouse wheel events
        /// </summary>
        private void OnMouseWheel(int deltaX, int deltaY)
        {
            _mouseWheelDelta = deltaY;
        }

        /// <summary>
        ///     Callback for gamepad connection events
        /// </summary>
        private void OnGamepadConnect(int gamepadIndex)
        {
            if (!_gamepadStates.ContainsKey(gamepadIndex))
            {
                _gamepadStates[gamepadIndex] = new GamepadState();
            }
            _gamepadStates[gamepadIndex].Connected = true;
        }

        /// <summary>
        ///     Callback for gamepad disconnection events
        /// </summary>
        private void OnGamepadDisconnect(int gamepadIndex)
        {
            if (_gamepadStates.ContainsKey(gamepadIndex))
            {
                _gamepadStates[gamepadIndex].Connected = false;
            }
        }

        /// <summary>
        ///     Callback for window resize events
        /// </summary>
        private void OnWindowResize(int width, int height)
        {
            _windowWidth = width;
            _windowHeight = height;
        }

        /// <summary>
        ///     Callback for window close events
        /// </summary>
        private void OnWindowClose()
        {
            _windowShouldClose = true;
        }

        /// <summary>
        ///     Callback for window focus change events
        /// </summary>
        private void OnWindowFocus(bool focused)
        {
            _isWindowVisible = focused;
        }

        /// <summary>
        ///     Converts JavaScript key codes to ConsoleKey values
        /// </summary>
        private static ConsoleKey ConvertKeyCode(int keyCode)
        {
            return keyCode switch
            {
                // Alphabet keys
                65 => ConsoleKey.A, 66 => ConsoleKey.B, 67 => ConsoleKey.C, 68 => ConsoleKey.D,
                69 => ConsoleKey.E, 70 => ConsoleKey.F, 71 => ConsoleKey.G, 72 => ConsoleKey.H,
                73 => ConsoleKey.I, 74 => ConsoleKey.J, 75 => ConsoleKey.K, 76 => ConsoleKey.L,
                77 => ConsoleKey.M, 78 => ConsoleKey.N, 79 => ConsoleKey.O, 80 => ConsoleKey.P,
                81 => ConsoleKey.Q, 82 => ConsoleKey.R, 83 => ConsoleKey.S, 84 => ConsoleKey.T,
                85 => ConsoleKey.U, 86 => ConsoleKey.V, 87 => ConsoleKey.W, 88 => ConsoleKey.X,
                89 => ConsoleKey.Y, 90 => ConsoleKey.Z,

                // Number keys (top row)
                48 => ConsoleKey.D0, 49 => ConsoleKey.D1, 50 => ConsoleKey.D2, 51 => ConsoleKey.D3,
                52 => ConsoleKey.D4, 53 => ConsoleKey.D5, 54 => ConsoleKey.D6, 55 => ConsoleKey.D7,
                56 => ConsoleKey.D8, 57 => ConsoleKey.D9,

                // Special keys
                13 => ConsoleKey.Enter, 9 => ConsoleKey.Tab, 32 => ConsoleKey.Spacebar,
                8 => ConsoleKey.Backspace, 27 => ConsoleKey.Escape, 46 => ConsoleKey.Delete,

                // Arrow keys
                37 => ConsoleKey.LeftArrow, 38 => ConsoleKey.UpArrow,
                39 => ConsoleKey.RightArrow, 40 => ConsoleKey.DownArrow,

                // Function keys
                112 => ConsoleKey.F1, 113 => ConsoleKey.F2, 114 => ConsoleKey.F3, 115 => ConsoleKey.F4,
                116 => ConsoleKey.F5, 117 => ConsoleKey.F6, 118 => ConsoleKey.F7, 119 => ConsoleKey.F8,
                120 => ConsoleKey.F9, 121 => ConsoleKey.F10, 122 => ConsoleKey.F11, 123 => ConsoleKey.F12,

                // Modifier keys
                16 => ConsoleKey.LeftArrow, 17 => ConsoleKey.Escape,

                // Other keys
                36 => ConsoleKey.Home, 35 => ConsoleKey.End, 33 => ConsoleKey.PageUp, 34 => ConsoleKey.PageDown,
                45 => ConsoleKey.Insert, 19 => ConsoleKey.Pause,

                // Numpad
                96 => ConsoleKey.NumPad0, 97 => ConsoleKey.NumPad1, 98 => ConsoleKey.NumPad2,
                99 => ConsoleKey.NumPad3, 100 => ConsoleKey.NumPad4, 101 => ConsoleKey.NumPad5,
                102 => ConsoleKey.NumPad6, 103 => ConsoleKey.NumPad7, 104 => ConsoleKey.NumPad8,
                105 => ConsoleKey.NumPad9, 106 => ConsoleKey.Multiply, 107 => ConsoleKey.Add,
                109 => ConsoleKey.Subtract, 110 => ConsoleKey.Decimal, 111 => ConsoleKey.Divide,

                _ => ConsoleKey.NoName
            };
        }

        /// <summary>
        ///     Updates gamepad states from the browser
        /// </summary>
        private void UpdateGamepadStates()
        {
            try
            {
                int[] gamepadIndices = EmscriptenWeb.GetConnectedGamepads();
                if (gamepadIndices == null || gamepadIndices.Length == 0)
                {
                    return;
                }

                foreach (int index in gamepadIndices)
                {
                    GamepadState state;
                    if (!_gamepadStates.TryGetValue(index, out state))
                    {
                        state = new GamepadState();
                        _gamepadStates[index] = state;
                    }

                    float[] axes = EmscriptenWeb.GetGamepadAxes(index);
                    bool[] buttons = EmscriptenWeb.GetGamepadButtons(index);

                    if (axes != null)
                    {
                        state.LeftStickX = axes.Length > 0 ? axes[0] : 0.0f;
                        state.LeftStickY = axes.Length > 1 ? axes[1] : 0.0f;
                        state.RightStickX = axes.Length > 2 ? axes[2] : 0.0f;
                        state.RightStickY = axes.Length > 3 ? axes[3] : 0.0f;
                        state.LeftTrigger = axes.Length > 4 ? axes[4] : 0.0f;
                        state.RightTrigger = axes.Length > 5 ? axes[5] : 0.0f;
                    }

                    if (buttons != null)
                    {
                        for (int i = 0; i < Math.Min(buttons.Length, state.Buttons.Length); i++)
                        {
                            state.Buttons[i] = buttons[i];
                        }
                    }
                }
            }
            catch
            {
                // Graceful fallback if gamepad API is not available
            }
        }

        /// <summary>
        /// Shows the window
        /// </summary>
        public void ShowWindow()
        {
            _isWindowVisible = true;
            EmscriptenWeb.ShowCanvas();
        }

        /// <summary>
        /// Hides the window
        /// </summary>
        public void HideWindow()
        {
            _isWindowVisible = false;
            EmscriptenWeb.HideCanvas();
        }

        /// <summary>
        /// Sets the title using the specified title
        /// </summary>
        /// <param name="title">The title</param>
        public void SetTitle(string title)
        {
            _windowTitle = title;
            EmscriptenWeb.SetWindowTitle(title);
        }

        /// <summary>
        /// Sets the size using the specified width
        /// </summary>
        /// <param name="width">The width</param>
        /// <param name="height">The height</param>
        public void SetSize(int width, int height)
        {
            _windowWidth = width;
            _windowHeight = height;
            EmscriptenWeb.SetCanvasSize(width, height);
        }

        /// <summary>
        /// Makes the context current
        /// </summary>
        public void MakeContextCurrent()
        {
            if (_eglDisplay != IntPtr.Zero && _eglSurface != IntPtr.Zero && _eglContext != IntPtr.Zero)
            {
                EGL.MakeCurrent(_eglDisplay, _eglSurface, _eglSurface, _eglContext);
            }
        }

        /// <summary>
        /// Swaps the buffers
        /// </summary>
        public void SwapBuffers()
        {
            if (_eglDisplay != IntPtr.Zero && _eglSurface != IntPtr.Zero)
            {
                EGL.SwapBuffers(_eglDisplay, _eglSurface);
            }
        }

        /// <summary>
        /// Ises the window visible
        /// </summary>
        /// <returns>The is window visible</returns>
        public bool IsWindowVisible()
        {
            return _isWindowVisible;
        }

        /// <summary>
        /// Polls the events
        /// </summary>
        /// <returns>The bool</returns>
        public bool PollEvents()
        {
            UpdateGamepadStates();
            _mouseWheelDelta = 0.0f; // Reset wheel delta after frame
            return !_windowShouldClose;
        }

        /// <summary>
        /// Cleanups this instance
        /// </summary>
        public void Cleanup()
        {
            if (!_isInitialized)
            {
                return;
            }

            if (_eglDisplay != IntPtr.Zero)
            {
                if (_eglContext != IntPtr.Zero)
                {
                    EGL.DestroyContext(_eglDisplay, _eglContext);
                    _eglContext = IntPtr.Zero;
                }

                if (_eglSurface != IntPtr.Zero)
                {
                    EGL.DestroySurface(_eglDisplay, _eglSurface);
                    _eglSurface = IntPtr.Zero;
                }

                EGL.Terminate(_eglDisplay);
                _eglDisplay = IntPtr.Zero;
            }

            _isInitialized = false;
            _keyStates.Clear();
            _keyPressedQueue.Clear();
            _inputCharacterBuilder.Clear();
            _gamepadStates.Clear();
        }

        /// <summary>
        /// Gets the window width
        /// </summary>
        /// <returns>The window width</returns>
        public int GetWindowWidth()
        {
            return _windowWidth;
        }

        /// <summary>
        /// Gets the window height
        /// </summary>
        /// <returns>The window height</returns>
        public int GetWindowHeight()
        {
            return _windowHeight;
        }

        /// <summary>
        /// Gets the proc address using the specified proc name
        /// </summary>
        /// <param name="procName">The proc name</param>
        /// <returns>The int ptr</returns>
        public IntPtr GetProcAddress(string procName)
        {
            return EGL.GetProcAddress(procName);
        }

        /// <summary>
        /// Tries the get last key pressed using the specified key
        /// </summary>
        /// <param name="key">The key</param>
        /// <returns>The bool</returns>
        public bool TryGetLastKeyPressed(out ConsoleKey key)
        {
            if (_keyPressedQueue.Count > 0)
            {
                key = _keyPressedQueue.Dequeue();
                return true;
            }

            key = ConsoleKey.NoName;
            return false;
        }

        /// <summary>
        /// Ises the key down using the specified console key
        /// </summary>
        /// <param name="consoleKey">The console key</param>
        /// <returns>The bool</returns>
        public bool IsKeyDown(ConsoleKey consoleKey)
        {
            if (_keyStates.TryGetValue(consoleKey, out bool isDown))
            {
                return isDown;
            }

            return false;
        }

        /// <summary>
        /// Sets the window icon using the specified icon path
        /// </summary>
        /// <param name="iconPath">The icon path</param>
        public void SetWindowIcon(string iconPath)
        {
            // WebAssembly context typically doesn't support traditional file system access
            // This can be implemented using data URIs or web-based resources
            try
            {
                EmscriptenWeb.SetWindowIcon(iconPath);
            }
            catch
            {
                // Icon setting not available in WebAssembly context
            }
        }

        /// <summary>
        /// Gets the mouse state using the specified x
        /// </summary>
        /// <param name="x">The </param>
        /// <param name="y">The </param>
        /// <param name="buttons">The buttons</param>
        public void GetMouseState(out int x, out int y, out bool[] buttons)
        {
            x = _mouseX;
            y = _mouseY;
            buttons = (bool[])_mouseButtons.Clone();
        }

        /// <summary>
        /// Gets the mouse wheel
        /// </summary>
        /// <returns>The mouse wheel delta</returns>
        public float GetMouseWheel()
        {
            return _mouseWheelDelta;
        }

        /// <summary>
        /// Tries the get last input characters using the specified chars
        /// </summary>
        /// <param name="chars">The chars</param>
        /// <returns>The bool</returns>
        public bool TryGetLastInputCharacters(out string chars)
        {
            if (_inputCharacterBuilder.Length > 0)
            {
                chars = _inputCharacterBuilder.ToString();
                _inputCharacterBuilder.Clear();
                return true;
            }

            chars = string.Empty;
            return false;
        }

        /// <summary>
        /// Gets the window position x
        /// </summary>
        /// <returns>The int</returns>
        public int GetWindowPositionX()
        {
            return EmscriptenWeb.GetWindowPositionX();
        }

        /// <summary>
        /// Gets the window position y
        /// </summary>
        /// <returns>The int</returns>
        public int GetWindowPositionY()
        {
            return EmscriptenWeb.GetWindowPositionY();
        }

        /// <summary>
        /// Gets the window metrics using the specified win x
        /// </summary>
        /// <param name="winX">The win</param>
        /// <param name="winY">The win</param>
        /// <param name="winW">The win</param>
        /// <param name="winH">The win</param>
        /// <param name="fbW">The fb</param>
        /// <param name="fbH">The fb</param>
        public void GetWindowMetrics(out int winX, out int winY, out int winW, out int winH, out int fbW, out int fbH)
        {
            winX = GetWindowPositionX();
            winY = GetWindowPositionY();
            winW = _windowWidth;
            winH = _windowHeight;
            
            // In WebAssembly, framebuffer size may differ from window size based on device pixel ratio
            float devicePixelRatio = EmscriptenWeb.GetDevicePixelRatio();
            fbW = (int)(_windowWidth * devicePixelRatio);
            fbH = (int)(_windowHeight * devicePixelRatio);
        }

        /// <summary>
        /// Gets the mouse position in view using the specified x
        /// </summary>
        /// <param name="x">The </param>
        /// <param name="y">The </param>
        public void GetMousePositionInView(out float x, out float y)
        {
            x = _mouseX;
            y = _mouseY;
        }

        /// <summary>
        ///     Gets the gamepad state for a specific gamepad index
        /// </summary>
        public bool TryGetGamepadState(int gamepadIndex, out GamepadState state)
        {
            return _gamepadStates.TryGetValue(gamepadIndex, out state);
        }

        /// <summary>
        ///     Gets all connected gamepad indices
        /// </summary>
        public int[] GetConnectedGamepadIndices()
        {
            List<int> connectedIndices = new List<int>();
            foreach (var kvp in _gamepadStates)
            {
                if (kvp.Value.Connected)
                {
                    connectedIndices.Add(kvp.Key);
                }
            }
            return connectedIndices.ToArray();
        }

        // Delegates for JavaScript callbacks
        /// <summary>
        /// The key event delegate
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void KeyEventDelegate(int keyCode, int location);

        /// <summary>
        /// The key char delegate
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void KeyCharDelegate(uint charCode);

        /// <summary>
        /// The mouse move delegate
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void MouseMoveDelegate(int x, int y, int clientX, int clientY);

        /// <summary>
        /// The mouse button delegate
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void MouseButtonDelegate(int button, int x, int y, int clientX, int clientY);

        /// <summary>
        /// The mouse wheel delegate
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void MouseWheelDelegate(int deltaX, int deltaY);

        /// <summary>
        /// The gamepad connect delegate
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GamepadConnectDelegate(int gamepadIndex);

        /// <summary>
        /// The gamepad disconnect delegate
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GamepadDisconnectDelegate(int gamepadIndex);

        /// <summary>
        /// The window resize delegate
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void WindowResizeDelegate(int width, int height);

        /// <summary>
        /// The window close delegate
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void WindowCloseDelegate();

        /// <summary>
        /// The window focus delegate
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void WindowFocusDelegate(bool focused);
    }

    /// <summary>
    ///     Represents the state of a connected gamepad (Xbox controller, PlayStation controller, etc.)
    /// </summary>
    public class GamepadState
    {
        /// <summary>
        ///     Whether this gamepad is currently connected
        /// </summary>
        public bool Connected { get; set; }

        /// <summary>
        ///     Left analog stick X axis (-1.0 to 1.0)
        /// </summary>
        public float LeftStickX { get; set; }

        /// <summary>
        ///     Left analog stick Y axis (-1.0 to 1.0)
        /// </summary>
        public float LeftStickY { get; set; }

        /// <summary>
        ///     Right analog stick X axis (-1.0 to 1.0)
        /// </summary>
        public float RightStickX { get; set; }

        /// <summary>
        ///     Right analog stick Y axis (-1.0 to 1.0)
        /// </summary>
        public float RightStickY { get; set; }

        /// <summary>
        ///     Left trigger pressure (0.0 to 1.0)
        /// </summary>
        public float LeftTrigger { get; set; }

        /// <summary>
        ///     Right trigger pressure (0.0 to 1.0)
        /// </summary>
        public float RightTrigger { get; set; }

        /// <summary>
        ///     Button states array
        ///     [0] = A/Cross
        ///     [1] = B/Circle
        ///     [2] = X/Square
        ///     [3] = Y/Triangle
        ///     [4] = LB/L1
        ///     [5] = RB/R1
        ///     [6] = LT (digital)
        ///     [7] = RT (digital)
        ///     [8] = Back/Select
        ///     [9] = Start
        ///     [10] = Left Stick Click
        ///     [11] = Right Stick Click
        ///     [12] = Guide/Home
        /// </summary>
        public bool[] Buttons { get; private set; } = new bool[13];

        /// <summary>
        ///     Gets the button state by index
        /// </summary>
        public bool GetButton(int index)
        {
            if (index >= 0 && index < Buttons.Length)
            {
                return Buttons[index];
            }
            return false;
        }

        /// <summary>
        ///     Gets the A/Cross button state
        /// </summary>
        public bool ButtonA => Buttons[0];

        /// <summary>
        ///     Gets the B/Circle button state
        /// </summary>
        public bool ButtonB => Buttons[1];

        /// <summary>
        ///     Gets the X/Square button state
        /// </summary>
        public bool ButtonX => Buttons[2];

        /// <summary>
        ///     Gets the Y/Triangle button state
        /// </summary>
        public bool ButtonY => Buttons[3];

        /// <summary>
        ///     Gets the LB/L1 shoulder button state
        /// </summary>
        public bool ButtonLb => Buttons[4];

        /// <summary>
        ///     Gets the RB/R1 shoulder button state
        /// </summary>
        public bool ButtonRb => Buttons[5];

        /// <summary>
        ///     Gets the left stick click (left thumb stick press) button state
        /// </summary>
        public bool ButtonLeftStickClick => Buttons[10];

        /// <summary>
        ///     Gets the right stick click (right thumb stick press) button state
        /// </summary>
        public bool ButtonRightStickClick => Buttons[11];

        /// <summary>
        ///     Gets the Start button state
        /// </summary>
        public bool ButtonStart => Buttons[9];

        /// <summary>
        ///     Gets the Back/Select button state
        /// </summary>
        public bool ButtonBack => Buttons[8];

        /// <summary>
        ///     Gets the Guide/Home button state
        /// </summary>
        public bool ButtonGuide => Buttons[12];
    }
}

