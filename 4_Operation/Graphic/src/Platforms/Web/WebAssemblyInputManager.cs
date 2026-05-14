// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:WebAssemblyInputManager.cs
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

namespace Alis.Core.Graphic.Platforms.Web
{
    /// <summary>
    ///     Advanced input manager for WebAssembly applications
    ///     Provides high-level input handling for keyboards, mice, gamepads, and touch
    /// </summary>
    public class WebAssemblyInputManager
    {
        /// <summary>
        /// The platform
        /// </summary>
        private readonly WebAssemblyPlatform _platform;
        /// <summary>
        /// The key bindings
        /// </summary>
        private Dictionary<string, KeyBinding> _keyBindings;
        /// <summary>
        /// The previous gamepad states
        /// </summary>
        private Dictionary<int, GamepadInputState> _previousGamepadStates;
        /// <summary>
        /// The last mouse Y position
        /// </summary>
        private int _lastMouseY;
        /// <summary>
        /// The last mouse wheel delta
        /// </summary>
        private float _lastMouseWheelDelta;
        /// <summary>
        /// The touch points
        /// </summary>
        private Dictionary<int, TouchPoint> _touchPoints;

        /// <summary>
        ///     Initializes a new instance of the WebAssemblyInputManager
        /// </summary>
        public WebAssemblyInputManager(WebAssemblyPlatform platform)
        {
            _platform = platform ?? throw new ArgumentNullException(nameof(platform));
            _keyBindings = new Dictionary<string, KeyBinding>();
            _previousGamepadStates = new Dictionary<int, GamepadInputState>();
            _touchPoints = new Dictionary<int, TouchPoint>();
            _lastMouseY = 0;
            _lastMouseWheelDelta = 0.0f;
        }

        /// <summary>
        ///     Registers a key binding for a specific action
        /// </summary>
        public void RegisterKeyBinding(string action, ConsoleKey key)
        {
            if (!_keyBindings.ContainsKey(action))
            {
                _keyBindings[action] = new KeyBinding();
            }
            _keyBindings[action].AddKey(key);
        }

        /// <summary>
        ///     Registers multiple keys for a single action
        /// </summary>
        public void RegisterKeyBinding(string action, params ConsoleKey[] keys)
        {
            if (!_keyBindings.ContainsKey(action))
            {
                _keyBindings[action] = new KeyBinding();
            }
            foreach (ConsoleKey key in keys)
            {
                _keyBindings[action].AddKey(key);
            }
        }

        /// <summary>
        ///     Clears all key bindings for an action
        /// </summary>
        public void ClearKeyBinding(string action)
        {
            if (_keyBindings.ContainsKey(action))
            {
                _keyBindings[action].Clear();
            }
        }

        /// <summary>
        ///     Checks if an action is currently active (any bound key is pressed)
        /// </summary>
        public bool IsActionActive(string action)
        {
            if (!_keyBindings.ContainsKey(action))
            {
                return false;
            }

            return _keyBindings[action].IsActive(_platform);
        }

        /// <summary>
        ///     Checks if an action was just pressed this frame
        /// </summary>
        public bool IsActionJustPressed(string action)
        {
            if (!_keyBindings.ContainsKey(action))
            {
                return false;
            }

            ConsoleKey key;
            while (_platform.TryGetLastKeyPressed(out key))
            {
                if (_keyBindings[action].ContainsKey(key))
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        ///     Updates the input manager state (should be called every frame)
        /// </summary>
        public void Update()
        {
            UpdateGamepadStates();
            UpdateMouseState();
        }

        /// <summary>
        ///     Updates gamepad states and tracks changes
        /// </summary>
        private void UpdateGamepadStates()
        {
            int[] connectedIndices = _platform.GetConnectedGamepadIndices();

            foreach (int index in connectedIndices)
            {
                if (_platform.TryGetGamepadState(index, out GamepadState state))
                {
                    if (!_previousGamepadStates.ContainsKey(index))
                    {
                        _previousGamepadStates[index] = new GamepadInputState();
                    }

                    _previousGamepadStates[index].Update(state);
                }
            }
        }

        /// <summary>
        ///     Updates mouse state
        /// </summary>
        private void UpdateMouseState()
        {
            _platform.GetMouseState(out _, out _lastMouseY, out bool[] buttons);
            _lastMouseWheelDelta = _platform.GetMouseWheel();
        }

        /// <summary>
        ///     Gets the current mouse position
        /// </summary>
        public void GetMousePosition(out int x, out int y)
        {
            _platform.GetMouseState(out x, out y, out bool[] buttons);
        }

        /// <summary>
        ///     Gets the mouse wheel delta (vertical scroll)
        /// </summary>
        public float GetMouseWheelDelta()
        {
            return _lastMouseWheelDelta;
        }

        /// <summary>
        ///     Checks if a mouse button is currently pressed
        /// </summary>
        public bool IsMouseButtonDown(int button)
        {
            _platform.GetMouseState(out int x, out int y, out bool[] buttons);
            return button >= 0 && button < buttons.Length && buttons[button];
        }

        /// <summary>
        ///     Gets the current state of a specific gamepad
        /// </summary>
        public bool TryGetGamepadState(int gamepadIndex, out GamepadInputState state)
        {
            state = null;

            if (_platform.TryGetGamepadState(gamepadIndex, out GamepadState platformState))
            {
                state = new GamepadInputState();
                state.CurrentState = platformState;

                if (_previousGamepadStates.TryGetValue(gamepadIndex, out GamepadInputState prevState))
                {
                    state.PreviousState = prevState.CurrentState;
                }

                return true;
            }

            return false;
        }

        /// <summary>
        ///     Gets all connected gamepad indices
        /// </summary>
        public int[] GetConnectedGamepadIndices()
        {
            return _platform.GetConnectedGamepadIndices();
        }

        /// <summary>
        ///     Checks if a gamepad button was just pressed
        /// </summary>
        public bool IsGamepadButtonJustPressed(int gamepadIndex, int buttonIndex)
        {
            if (!TryGetGamepadState(gamepadIndex, out GamepadInputState state))
            {
                return false;
            }

            if (state.PreviousState == null)
            {
                return state.CurrentState.GetButton(buttonIndex);
            }

            return state.CurrentState.GetButton(buttonIndex) && !state.PreviousState.GetButton(buttonIndex);
        }

        /// <summary>
        ///     Checks if a gamepad button was just released
        /// </summary>
        public bool IsGamepadButtonJustReleased(int gamepadIndex, int buttonIndex)
        {
            if (!TryGetGamepadState(gamepadIndex, out GamepadInputState state))
            {
                return false;
            }

            if (state.PreviousState == null)
            {
                return false;
            }

            return !state.CurrentState.GetButton(buttonIndex) && state.PreviousState.GetButton(buttonIndex);
        }

        /// <summary>
        ///     Vibrates a gamepad (rumble support)
        /// </summary>
        public bool VibrateGamepad(int gamepadIndex, float leftMotor, float rightMotor, float duration = 0.1f)
        {
            return EmscriptenWeb.VibrateGamepad(gamepadIndex, leftMotor, rightMotor, duration);
        }

        /// <summary>
        ///     Gets a human-readable name for a console key
        /// </summary>
        public static string GetKeyName(ConsoleKey key)
        {
            return key switch
            {
                ConsoleKey.A => "A", ConsoleKey.B => "B", ConsoleKey.C => "C", ConsoleKey.D => "D",
                ConsoleKey.E => "E", ConsoleKey.F => "F", ConsoleKey.G => "G", ConsoleKey.H => "H",
                ConsoleKey.I => "I", ConsoleKey.J => "J", ConsoleKey.K => "K", ConsoleKey.L => "L",
                ConsoleKey.M => "M", ConsoleKey.N => "N", ConsoleKey.O => "O", ConsoleKey.P => "P",
                ConsoleKey.Q => "Q", ConsoleKey.R => "R", ConsoleKey.S => "S", ConsoleKey.T => "T",
                ConsoleKey.U => "U", ConsoleKey.V => "V", ConsoleKey.W => "W", ConsoleKey.X => "X",
                ConsoleKey.Y => "Y", ConsoleKey.Z => "Z",

                ConsoleKey.D0 => "0", ConsoleKey.D1 => "1", ConsoleKey.D2 => "2", ConsoleKey.D3 => "3",
                ConsoleKey.D4 => "4", ConsoleKey.D5 => "5", ConsoleKey.D6 => "6", ConsoleKey.D7 => "7",
                ConsoleKey.D8 => "8", ConsoleKey.D9 => "9",

                ConsoleKey.Enter => "Enter", ConsoleKey.Escape => "Escape", ConsoleKey.Backspace => "Backspace",
                ConsoleKey.Tab => "Tab", ConsoleKey.Spacebar => "Space", ConsoleKey.Delete => "Delete",
                ConsoleKey.Insert => "Insert", ConsoleKey.Home => "Home", ConsoleKey.End => "End",
                ConsoleKey.PageUp => "Page Up", ConsoleKey.PageDown => "Page Down",

                ConsoleKey.UpArrow => "Up", ConsoleKey.DownArrow => "Down",
                ConsoleKey.LeftArrow => "Left", ConsoleKey.RightArrow => "Right",

                ConsoleKey.F1 => "F1", ConsoleKey.F2 => "F2", ConsoleKey.F3 => "F3", ConsoleKey.F4 => "F4",
                ConsoleKey.F5 => "F5", ConsoleKey.F6 => "F6", ConsoleKey.F7 => "F7", ConsoleKey.F8 => "F8",
                ConsoleKey.F9 => "F9", ConsoleKey.F10 => "F10", ConsoleKey.F11 => "F11", ConsoleKey.F12 => "F12",

                ConsoleKey.Pause => "Pause",

                ConsoleKey.NumPad0 => "Numpad 0", ConsoleKey.NumPad1 => "Numpad 1", ConsoleKey.NumPad2 => "Numpad 2",
                ConsoleKey.NumPad3 => "Numpad 3", ConsoleKey.NumPad4 => "Numpad 4", ConsoleKey.NumPad5 => "Numpad 5",
                ConsoleKey.NumPad6 => "Numpad 6", ConsoleKey.NumPad7 => "Numpad 7", ConsoleKey.NumPad8 => "Numpad 8",
                ConsoleKey.NumPad9 => "Numpad 9",

                _ => "Unknown"
            };
        }
    }

    /// <summary>
    ///     Represents a key binding associated with an action
    /// </summary>
    public class KeyBinding
    {
        /// <summary>
        /// The keys
        /// </summary>
        private HashSet<ConsoleKey> _keys;

        /// <summary>
        /// Initializes a new instance of the <see cref="KeyBinding"/> class
        /// </summary>
        public KeyBinding()
        {
            _keys = new HashSet<ConsoleKey>();
        }

        /// <summary>
        /// Adds the key using the specified key
        /// </summary>
        /// <param name="key">The key</param>
        public void AddKey(ConsoleKey key)
        {
            _keys.Add(key);
        }

        /// <summary>
        /// Removes the key using the specified key
        /// </summary>
        /// <param name="key">The key</param>
        public void RemoveKey(ConsoleKey key)
        {
            _keys.Remove(key);
        }

        /// <summary>
        /// Containses the key using the specified key
        /// </summary>
        /// <param name="key">The key</param>
        /// <returns>The bool</returns>
        public bool ContainsKey(ConsoleKey key)
        {
            return _keys.Contains(key);
        }

        /// <summary>
        /// Clears this instance
        /// </summary>
        public void Clear()
        {
            _keys.Clear();
        }

        /// <summary>
        /// Ises the active using the specified platform
        /// </summary>
        /// <param name="platform">The platform</param>
        /// <returns>The bool</returns>
        public bool IsActive(WebAssemblyPlatform platform)
        {
            foreach (ConsoleKey key in _keys)
            {
                if (platform.IsKeyDown(key))
                {
                    return true;
                }
            }
            return false;
        }
    }

    /// <summary>
    ///     Tracks gamepad input state changes between frames
    /// </summary>
    public class GamepadInputState
    {
        /// <summary>
        /// Gets or sets the value of the current state
        /// </summary>
        public GamepadState CurrentState { get; set; }
        /// <summary>
        /// Gets or sets the value of the previous state
        /// </summary>
        public GamepadState PreviousState { get; set; }

        /// <summary>
        /// Updates the new state
        /// </summary>
        /// <param name="newState">The new state</param>
        public void Update(GamepadState newState)
        {
            PreviousState = CurrentState;
            CurrentState = newState;
        }
    }

    /// <summary>
    ///     Enumeration of touch point states
    /// </summary>
    public enum TouchState
    {
        /// <summary>
        /// The begin touch state
        /// </summary>
        Begin,
        /// <summary>
        /// The moved touch state
        /// </summary>
        Moved,
        /// <summary>
        /// The stationary touch state
        /// </summary>
        Stationary,
        /// <summary>
        /// The ended touch state
        /// </summary>
        Ended,
        /// <summary>
        /// The cancelled touch state
        /// </summary>
        Cancelled
    }

    /// <summary>
    ///     Represents a single touch point on a touch screen
    /// </summary>
    public class TouchPoint
    {
        /// <summary>
        /// Gets or sets the value of the id
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Gets or sets the value of the x
        /// </summary>
        public int X { get; set; }
        /// <summary>
        /// Gets or sets the value of the y
        /// </summary>
        public int Y { get; set; }
        /// <summary>
        /// Gets or sets the value of the is active
        /// </summary>
        public bool IsActive { get; set; }
        /// <summary>
        /// Gets or sets the value of the state
        /// </summary>
        public TouchState State { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="TouchPoint"/> class
        /// </summary>
        public TouchPoint()
        {
            IsActive = true;
            State = TouchState.Begin;
        }
    }

    /// <summary>
    ///     Extended input context for WebAssembly with advanced features
    /// </summary>
    public class WebAssemblyInputContext
    {
        /// <summary>
        /// The input manager
        /// </summary>
        private readonly WebAssemblyInputManager _inputManager;
        /// <summary>
        /// The platform
        /// </summary>
        private readonly WebAssemblyPlatform _platform;

        /// <summary>
        /// Initializes a new instance of the <see cref="WebAssemblyInputContext"/> class
        /// </summary>
        /// <param name="platform">The platform</param>
        /// <exception cref="ArgumentNullException"></exception>
        public WebAssemblyInputContext(WebAssemblyPlatform platform)
        {
            _platform = platform ?? throw new ArgumentNullException(nameof(platform));
            _inputManager = new WebAssemblyInputManager(platform);
        }

        /// <summary>
        ///     Gets the input manager
        /// </summary>
        public WebAssemblyInputManager InputManager => _inputManager;

        /// <summary>
        ///     Gets the platform
        /// </summary>
        public WebAssemblyPlatform Platform => _platform;

        /// <summary>
        ///     Polls for text input from the platform
        /// </summary>
        public bool TryGetTextInput(out string text)
        {
            return _platform.TryGetLastInputCharacters(out text);
        }

        /// <summary>
        ///     Updates the input context (should be called every frame)
        /// </summary>
        public void Update()
        {
            _inputManager.Update();
        }

        /// <summary>
        ///     Locks the pointer to the window (for FPS games)
        /// </summary>
        public bool LockPointer()
        {
            return EmscriptenWeb.LockPointer();
        }

        /// <summary>
        ///     Unlocks the pointer
        /// </summary>
        public bool UnlockPointer()
        {
            return EmscriptenWeb.UnlockPointer();
        }

        /// <summary>
        ///     Checks if the pointer is locked
        /// </summary>
        public bool IsPointerLocked()
        {
            return EmscriptenWeb.IsPointerLocked();
        }

        /// <summary>
        ///     Enters fullscreen mode
        /// </summary>
        public bool RequestFullscreen()
        {
            return EmscriptenWeb.RequestFullscreen();
        }

        /// <summary>
        ///     Exits fullscreen mode
        /// </summary>
        public bool ExitFullscreen()
        {
            return EmscriptenWeb.ExitFullscreen();
        }

        /// <summary>
        ///     Checks if currently in fullscreen
        /// </summary>
        public bool IsFullscreen()
        {
            return EmscriptenWeb.IsFullscreenEnabled();
        }
    }
}

