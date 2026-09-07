// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:WebAssemblyInputManagerGamepadEdgeCoverageTests.cs
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

using Alis.Core.Graphic.Platforms.Web;
using Xunit;

namespace Alis.Core.Graphic.Test.Platforms.Web
{
    /// <summary>
    ///     The web assembly input manager gamepad edge coverage tests class
    /// </summary>
    public class WebAssemblyInputManagerGamepadEdgeCoverageTests
    {
        /// <summary>
        ///     Tests that is gamepad button just pressed with no previous state returns the current button state
        /// </summary>
        [Fact]
        public void IsGamepadButtonJustPressed_WithNoPreviousState_ReturnsCurrentButtonState()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            WebAssemblyInputManager manager = new WebAssemblyInputManager(platform);
            platform.OnGamepadConnect(0);
            platform._gamepadStates[0].Buttons[0] = true;

            bool result = manager.IsGamepadButtonJustPressed(0, 0);

            Assert.True(result);
        }

        /// <summary>
        ///     Tests that is gamepad button just pressed with no previous state returns false when button released
        /// </summary>
        [Fact]
        public void IsGamepadButtonJustPressed_WithNoPreviousState_ButtonReleased_ReturnsFalse()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            WebAssemblyInputManager manager = new WebAssemblyInputManager(platform);
            platform.OnGamepadConnect(0);

            bool result = manager.IsGamepadButtonJustPressed(0, 0);

            Assert.False(result);
        }

        /// <summary>
        ///     Tests that is gamepad button just pressed with previous state and button pressed now returns true
        /// </summary>
        [Fact]
        public void IsGamepadButtonJustPressed_WithPreviousState_JustPressed_ReturnsTrue()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            WebAssemblyInputManager manager = new WebAssemblyInputManager(platform);
            platform.OnGamepadConnect(0);
            platform._gamepadStates[0].Buttons[0] = true;
            GamepadInputState previous = new GamepadInputState
            {
                CurrentState = new GamepadState()
            };
            manager._previousGamepadStates[0] = previous;

            bool result = manager.IsGamepadButtonJustPressed(0, 0);

            Assert.True(result);
        }

        /// <summary>
        ///     Tests that is gamepad button just pressed with previous state and button held returns false
        /// </summary>
        [Fact]
        public void IsGamepadButtonJustPressed_WithPreviousState_ButtonHeld_ReturnsFalse()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            WebAssemblyInputManager manager = new WebAssemblyInputManager(platform);
            platform.OnGamepadConnect(0);
            GamepadState heldState = new GamepadState();
            heldState.Buttons[0] = true;
            GamepadInputState previous = new GamepadInputState
            {
                CurrentState = heldState
            };
            platform._gamepadStates[0] = heldState;
            manager._previousGamepadStates[0] = previous;

            bool result = manager.IsGamepadButtonJustPressed(0, 0);

            Assert.False(result);
        }

        /// <summary>
        ///     Tests that is gamepad button just pressed with previous state and button not pressed now returns false
        /// </summary>
        [Fact]
        public void IsGamepadButtonJustPressed_WithPreviousState_NotPressedNow_ReturnsFalse()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            WebAssemblyInputManager manager = new WebAssemblyInputManager(platform);
            platform.OnGamepadConnect(0);
            GamepadState pressedState = new GamepadState();
            pressedState.Buttons[0] = true;
            GamepadInputState previous = new GamepadInputState
            {
                CurrentState = pressedState
            };
            manager._previousGamepadStates[0] = previous;

            bool result = manager.IsGamepadButtonJustPressed(0, 0);

            Assert.False(result);
        }

        /// <summary>
        ///     Tests that is gamepad button just released with previous state and button released now returns true
        /// </summary>
        [Fact]
        public void IsGamepadButtonJustReleased_WithPreviousState_JustReleased_ReturnsTrue()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            WebAssemblyInputManager manager = new WebAssemblyInputManager(platform);
            platform.OnGamepadConnect(0);
            GamepadState pressedState = new GamepadState();
            pressedState.Buttons[0] = true;
            GamepadInputState previous = new GamepadInputState
            {
                CurrentState = pressedState
            };
            manager._previousGamepadStates[0] = previous;

            bool result = manager.IsGamepadButtonJustReleased(0, 0);

            Assert.True(result);
        }

        /// <summary>
        ///     Tests that is gamepad button just released with previous state and button pressed now returns false
        /// </summary>
        [Fact]
        public void IsGamepadButtonJustReleased_WithPreviousState_ButtonPressedNow_ReturnsFalse()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            WebAssemblyInputManager manager = new WebAssemblyInputManager(platform);
            platform.OnGamepadConnect(0);
            GamepadState pressedState = new GamepadState();
            pressedState.Buttons[0] = true;
            GamepadInputState previous = new GamepadInputState
            {
                CurrentState = pressedState
            };
            platform._gamepadStates[0] = pressedState;
            manager._previousGamepadStates[0] = previous;

            bool result = manager.IsGamepadButtonJustReleased(0, 0);

            Assert.False(result);
        }
    }
}