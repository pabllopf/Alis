// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:WebAssemblyPlatformTest.cs
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
using System.Reflection;
using Alis.Core.Graphic.Platforms.Web;
using Xunit;

namespace Alis.Core.Graphic.Test.Platforms.Web
{
    /// <summary>
    ///     Tests for WebAssemblyPlatform state, input handling, and window management.
    /// </summary>
    public class WebAssemblyPlatformTest
    {
        /// <summary>
        /// Tests that web assembly platform default state is consistent
        /// </summary>
        [Fact]
        public void WebAssemblyPlatform_DefaultState_IsConsistent()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();

            Assert.Equal(800, platform.GetWindowWidth());
            Assert.Equal(600, platform.GetWindowHeight());
            Assert.False(platform.IsWindowVisible());
            Assert.False(platform.TryGetLastKeyPressed(out ConsoleKey _));
            Assert.False(platform.TryGetLastInputCharacters(out string _));
            Assert.Equal(0.0f, platform.GetMouseWheel(), 5);

            platform.GetMouseState(out int x, out int y, out bool[] buttons);
            Assert.Equal(0, x);
            Assert.Equal(0, y);
            Assert.Equal(5, buttons.Length);
            foreach (bool button in buttons)
            {
                Assert.False(button);
            }
        }

        /// <summary>
        /// Tests that web assembly platform key events update state and queue
        /// </summary>
        [Fact]
        public void WebAssemblyPlatform_KeyEvents_UpdateStateAndQueue()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();

            InvokePrivate(platform, "OnKeyDown", 65, 0);

            Assert.True(platform.IsKeyDown(ConsoleKey.A));
            Assert.True(platform.TryGetLastKeyPressed(out ConsoleKey key));
            Assert.Equal(ConsoleKey.A, key);

            InvokePrivate(platform, "OnKeyUp", 65, 0);

            Assert.False(platform.IsKeyDown(ConsoleKey.A));
        }

        /// <summary>
        /// Tests that web assembly platform char input collects and clears
        /// </summary>
        [Fact]
        public void WebAssemblyPlatform_CharInput_CollectsAndClears()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();

            InvokePrivate(platform, "OnCharInput", (uint) 65);

            Assert.True(platform.TryGetLastInputCharacters(out string chars));
            Assert.Equal("A", chars);
            Assert.False(platform.TryGetLastInputCharacters(out string _));
        }

        /// <summary>
        /// Tests that web assembly platform mouse events update coordinates and buttons
        /// </summary>
        [Fact]
        public void WebAssemblyPlatform_MouseEvents_UpdateCoordinatesAndButtons()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();

            InvokePrivate(platform, "OnMouseMove", 0, 0, 12, 34);
            InvokePrivate(platform, "OnMouseDown", 1, 0, 0, 12, 34);

            platform.GetMouseState(out int x, out int y, out bool[] buttons);
            Assert.Equal(12, x);
            Assert.Equal(34, y);
            Assert.True(buttons[1]);

            InvokePrivate(platform, "OnMouseUp", 1, 0, 0, 12, 34);

            platform.GetMouseState(out x, out y, out buttons);
            Assert.False(buttons[1]);
        }

        /// <summary>
        /// Tests that web assembly platform get mouse position in view returns default coords
        /// </summary>
        [Fact]
        public void WebAssemblyPlatform_GetMousePositionInView_ReturnsDefaultCoords()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            platform.GetMousePositionInView(out float x, out float y);
            Assert.Equal(0, x);
            Assert.Equal(0, y);
        }

        /// <summary>
        /// Tests that web assembly platform try get gamepad state no gamepads returns false
        /// </summary>
        [Fact]
        public void WebAssemblyPlatform_TryGetGamepadState_NoGamepads_ReturnsFalse()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            bool result = platform.TryGetGamepadState(0, out GamepadState state);
            Assert.False(result);
            Assert.Null(state);
        }

        /// <summary>
        /// Tests that web assembly platform get connected gamepad indices empty returns empty array
        /// </summary>
        [Fact]
        public void WebAssemblyPlatform_GetConnectedGamepadIndices_Empty_ReturnsEmptyArray()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            int[] indices = platform.GetConnectedGamepadIndices();
            Assert.NotNull(indices);
            Assert.Empty(indices);
        }

        /// <summary>
        /// Tests that web assembly platform get proc address calls interop
        /// </summary>
        [Fact]
        public void WebAssemblyPlatform_GetProcAddress_CallsInterop()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            Assert.ThrowsAny<Exception>(() => platform.GetProcAddress("glClearColor"));
        }

        /// <summary>
        /// Tests that web assembly platform show window sets visible
        /// </summary>
        [Fact]
        public void WebAssemblyPlatform_ShowWindow_SetsVisible()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            platform.ShowWindow();
            Assert.True(platform.IsWindowVisible());
        }

        /// <summary>
        /// Tests that web assembly platform hide window clears visible
        /// </summary>
        [Fact]
        public void WebAssemblyPlatform_HideWindow_ClearsVisible()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            platform.ShowWindow();
            platform.HideWindow();
            Assert.False(platform.IsWindowVisible());
        }

        /// <summary>
        /// Tests that web assembly platform set title does not throw
        /// </summary>
        [Fact]
        public void WebAssemblyPlatform_SetTitle_DoesNotThrow()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            platform.SetTitle("New Title");
        }

        /// <summary>
        /// Tests that web assembly platform set size does not throw
        /// </summary>
        [Fact]
        public void WebAssemblyPlatform_SetSize_DoesNotThrow()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            platform.SetSize(1024, 768);
        }

        /// <summary>
        /// Tests that web assembly platform set window icon does not throw
        /// </summary>
        [Fact]
        public void WebAssemblyPlatform_SetWindowIcon_DoesNotThrow()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            platform.SetWindowIcon("/icon.png");
        }

        /// <summary>
        /// Tests that web assembly platform poll events resets wheel delta
        /// </summary>
        [Fact]
        public void WebAssemblyPlatform_PollEvents_ResetsWheelDelta()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            InvokePrivate(platform, "OnMouseWheel", 0, 5);
            Assert.Equal(5.0f, platform.GetMouseWheel());

            platform.PollEvents();

            Assert.Equal(0.0f, platform.GetMouseWheel());
        }

        /// <summary>
        /// Tests that web assembly platform poll events returns true when not closing
        /// </summary>
        [Fact]
        public void WebAssemblyPlatform_PollEvents_ReturnsTrueWhenNotClosing()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            bool result = platform.PollEvents();
            Assert.True(result);
        }

        /// <summary>
        /// Tests that web assembly platform cleanup not initialized does nothing
        /// </summary>
        [Fact]
        public void WebAssemblyPlatform_Cleanup_NotInitialized_DoesNothing()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            platform.Cleanup();
        }

        /// <summary>
        /// Tests that web assembly platform cleanup not initialized does not clear state
        /// </summary>
        [Fact]
        public void WebAssemblyPlatform_Cleanup_NotInitialized_DoesNotClearState()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            InvokePrivate(platform, "OnKeyDown", 65, 0);
            InvokePrivate(platform, "OnCharInput", (uint)'B');

            platform.Cleanup();

            Assert.True(platform.IsKeyDown(ConsoleKey.A));
        }

        /// <summary>
        /// Tests that web assembly platform initialize when already initialized returns true
        /// </summary>
        [Fact]
        public void WebAssemblyPlatform_Initialize_WhenAlreadyInitialized_ReturnsTrue()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            platform.Initialize(800, 600, "Test");
        }

        /// <summary>
        /// Tests that web assembly platform make context current with zero handles does not throw
        /// </summary>
        [Fact]
        public void WebAssemblyPlatform_MakeContextCurrent_WithZeroHandles_DoesNotThrow()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            platform.MakeContextCurrent();
        }

        /// <summary>
        /// Tests that web assembly platform swap buffers with zero handles does not throw
        /// </summary>
        [Fact]
        public void WebAssemblyPlatform_SwapBuffers_WithZeroHandles_DoesNotThrow()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            platform.SwapBuffers();
        }

        /// <summary>
        /// Tests that web assembly platform try get last key pressed empty queue returns false
        /// </summary>
        [Fact]
        public void WebAssemblyPlatform_TryGetLastKeyPressed_EmptyQueue_ReturnsFalse()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            bool result = platform.TryGetLastKeyPressed(out ConsoleKey key);
            Assert.False(result);
            Assert.Equal(ConsoleKey.NoName, key);
        }

        /// <summary>
        /// Tests that web assembly platform is key down unknown key returns false
        /// </summary>
        [Fact]
        public void WebAssemblyPlatform_IsKeyDown_UnknownKey_ReturnsFalse()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            Assert.False(platform.IsKeyDown(ConsoleKey.F24));
        }

        /// <summary>
        /// Tests that web assembly platform try get last input characters empty returns false
        /// </summary>
        [Fact]
        public void WebAssemblyPlatform_TryGetLastInputCharacters_Empty_ReturnsFalse()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            bool result = platform.TryGetLastInputCharacters(out string chars);
            Assert.False(result);
            Assert.Equal(string.Empty, chars);
        }

        /// <summary>
        /// Tests that web assembly platform on mouse wheel sets delta
        /// </summary>
        [Fact]
        public void WebAssemblyPlatform_OnMouseWheel_SetsDelta()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            InvokePrivate(platform, "OnMouseWheel", 0, -3);
            Assert.Equal(-3.0f, platform.GetMouseWheel());
        }

        /// <summary>
        /// Tests that web assembly platform on mouse wheel positive delta
        /// </summary>
        [Fact]
        public void WebAssemblyPlatform_OnMouseWheel_PositiveDelta()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            InvokePrivate(platform, "OnMouseWheel", 0, 10);
            Assert.Equal(10.0f, platform.GetMouseWheel());
        }

        /// <summary>
        /// Tests that web assembly platform on mouse down boundary button 0 works
        /// </summary>
        [Fact]
        public void WebAssemblyPlatform_OnMouseDown_BoundaryButton0_Works()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            InvokePrivate(platform, "OnMouseDown", 0, 0, 0, 50, 60);
            platform.GetMouseState(out int x, out int y, out bool[] buttons);
            Assert.True(buttons[0]);
            Assert.Equal(50, x);
            Assert.Equal(60, y);
        }

        /// <summary>
        /// Tests that web assembly platform on mouse down boundary button 4 works
        /// </summary>
        [Fact]
        public void WebAssemblyPlatform_OnMouseDown_BoundaryButton4_Works()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            InvokePrivate(platform, "OnMouseDown", 4, 0, 0, 10, 20);
            platform.GetMouseState(out int x, out int y, out bool[] buttons);
            Assert.True(buttons[4]);
        }

        /// <summary>
        /// Tests that web assembly platform on mouse down out of bounds button ignored
        /// </summary>
        [Fact]
        public void WebAssemblyPlatform_OnMouseDown_OutOfBoundsButton_Ignored()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            InvokePrivate(platform, "OnMouseDown", 5, 0, 0, 10, 20);
            platform.GetMouseState(out int x, out int y, out bool[] buttons);
            Assert.False(buttons[0]);
            Assert.False(buttons[1]);
            Assert.False(buttons[2]);
            Assert.False(buttons[3]);
            Assert.False(buttons[4]);
        }

        /// <summary>
        /// Tests that web assembly platform on mouse down negative button ignored
        /// </summary>
        [Fact]
        public void WebAssemblyPlatform_OnMouseDown_NegativeButton_Ignored()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            InvokePrivate(platform, "OnMouseDown", -1, 0, 0, 10, 20);
            platform.GetMouseState(out int x, out int y, out bool[] buttons);
            Assert.False(buttons[0]);
        }

        /// <summary>
        /// Tests that web assembly platform on mouse up out of bounds button ignored
        /// </summary>
        [Fact]
        public void WebAssemblyPlatform_OnMouseUp_OutOfBoundsButton_Ignored()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            InvokePrivate(platform, "OnMouseUp", 10, 0, 0, 0, 0);
        }

        /// <summary>
        /// Tests that web assembly platform on window resize updates dimensions
        /// </summary>
        [Fact]
        public void WebAssemblyPlatform_OnWindowResize_UpdatesDimensions()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            InvokePrivate(platform, "OnWindowResize", 1920, 1080);
            Assert.Equal(1920, platform.GetWindowWidth());
            Assert.Equal(1080, platform.GetWindowHeight());
        }

        /// <summary>
        /// Tests that web assembly platform on window close sets should close
        /// </summary>
        [Fact]
        public void WebAssemblyPlatform_OnWindowClose_SetsShouldClose()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            InvokePrivate(platform, "OnWindowClose");
            bool result = platform.PollEvents();
            Assert.False(result);
        }

        /// <summary>
        /// Tests that web assembly platform on window focus true sets visible
        /// </summary>
        [Fact]
        public void WebAssemblyPlatform_OnWindowFocus_True_SetsVisible()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            InvokePrivate(platform, "OnWindowFocus", true);
            Assert.True(platform.IsWindowVisible());
        }

        /// <summary>
        /// Tests that web assembly platform on window focus false clears visible
        /// </summary>
        [Fact]
        public void WebAssemblyPlatform_OnWindowFocus_False_ClearsVisible()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            InvokePrivate(platform, "OnWindowFocus", false);
            Assert.False(platform.IsWindowVisible());
        }

        /// <summary>
        /// Tests that web assembly platform on gamepad connect creates state
        /// </summary>
        [Fact]
        public void WebAssemblyPlatform_OnGamepadConnect_CreatesState()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            InvokePrivate(platform, "OnGamepadConnect", 0);
            bool result = platform.TryGetGamepadState(0, out GamepadState state);
            Assert.True(result);
            Assert.True(state.Connected);
        }

        /// <summary>
        /// Tests that web assembly platform on gamepad connect multiple gamepads
        /// </summary>
        [Fact]
        public void WebAssemblyPlatform_OnGamepadConnect_MultipleGamepads()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            InvokePrivate(platform, "OnGamepadConnect", 0);
            InvokePrivate(platform, "OnGamepadConnect", 1);
            InvokePrivate(platform, "OnGamepadConnect", 2);

            Assert.True(platform.TryGetGamepadState(0, out GamepadState s0) && s0.Connected);
            Assert.True(platform.TryGetGamepadState(1, out GamepadState s1) && s1.Connected);
            Assert.True(platform.TryGetGamepadState(2, out GamepadState s2) && s2.Connected);
        }

        /// <summary>
        /// Tests that web assembly platform on gamepad disconnect sets disconnected
        /// </summary>
        [Fact]
        public void WebAssemblyPlatform_OnGamepadDisconnect_SetsDisconnected()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            InvokePrivate(platform, "OnGamepadConnect", 0);
            InvokePrivate(platform, "OnGamepadDisconnect", 0);
            bool result = platform.TryGetGamepadState(0, out GamepadState state);
            Assert.True(result);
            Assert.False(state.Connected);
        }

        /// <summary>
        /// Tests that web assembly platform on gamepad disconnect non existent does not throw
        /// </summary>
        [Fact]
        public void WebAssemblyPlatform_OnGamepadDisconnect_NonExistent_DoesNotThrow()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            InvokePrivate(platform, "OnGamepadDisconnect", 99);
        }

        /// <summary>
        /// Tests that web assembly platform get connected gamepad indices returns only connected
        /// </summary>
        [Fact]
        public void WebAssemblyPlatform_GetConnectedGamepadIndices_ReturnsOnlyConnected()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            InvokePrivate(platform, "OnGamepadConnect", 0);
            InvokePrivate(platform, "OnGamepadConnect", 1);
            InvokePrivate(platform, "OnGamepadDisconnect", 1);

            int[] indices = platform.GetConnectedGamepadIndices();
            Assert.Single(indices);
            Assert.Contains(0, indices);
        }

        /// <summary>
        /// Tests that web assembly platform get connected gamepad indices all disconnected returns empty
        /// </summary>
        [Fact]
        public void WebAssemblyPlatform_GetConnectedGamepadIndices_AllDisconnected_ReturnsEmpty()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            InvokePrivate(platform, "OnGamepadConnect", 0);
            InvokePrivate(platform, "OnGamepadDisconnect", 0);

            int[] indices = platform.GetConnectedGamepadIndices();
            Assert.Empty(indices);
        }

        /// <summary>
        /// Tests that web assembly platform on char input invalid char code does not throw
        /// </summary>
        [Fact]
        public void WebAssemblyPlatform_OnCharInput_InvalidCharCode_DoesNotThrow()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            InvokePrivate(platform, "OnCharInput", (uint)0x110000);
        }

        /// <summary>
        /// Tests that web assembly platform on char input multiple characters accumulates
        /// </summary>
        [Fact]
        public void WebAssemblyPlatform_OnCharInput_MultipleCharacters_Accumulates()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            InvokePrivate(platform, "OnCharInput", (uint)'H');
            InvokePrivate(platform, "OnCharInput", (uint)'i');
            InvokePrivate(platform, "OnCharInput", (uint)'!');

            Assert.True(platform.TryGetLastInputCharacters(out string chars));
            Assert.Equal("Hi!", chars);
        }

        /// <summary>
        /// Tests that web assembly platform on key down same key multiple times enqueues each time
        /// </summary>
        [Fact]
        public void WebAssemblyPlatform_OnKeyDown_SameKeyMultipleTimes_EnqueuesEachTime()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            InvokePrivate(platform, "OnKeyDown", 65, 0);
            InvokePrivate(platform, "OnKeyUp", 65, 0);
            InvokePrivate(platform, "OnKeyDown", 65, 0);

            Assert.True(platform.TryGetLastKeyPressed(out ConsoleKey key1));
            Assert.Equal(ConsoleKey.A, key1);
            Assert.True(platform.TryGetLastKeyPressed(out ConsoleKey key2));
            Assert.Equal(ConsoleKey.A, key2);
        }

        /// <summary>
        /// Tests that web assembly platform on key down repeated key does not enqueue without release
        /// </summary>
        [Fact]
        public void WebAssemblyPlatform_OnKeyDown_RepeatedKey_DoesNotEnqueueWithoutRelease()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();

            InvokePrivate(platform, "OnKeyDown", 65, 0);
            Assert.True(platform.TryGetLastKeyPressed(out _));

            InvokePrivate(platform, "OnKeyDown", 65, 0);

            Assert.False(platform.TryGetLastKeyPressed(out _));
        }

        /// <summary>
        /// Tests that web assembly platform on key down different keys queue order preserved
        /// </summary>
        [Fact]
        public void WebAssemblyPlatform_OnKeyDown_DifferentKeys_QueueOrderPreserved()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();

            InvokePrivate(platform, "OnKeyDown", 65, 0);
            InvokePrivate(platform, "OnKeyDown", 66, 0);
            InvokePrivate(platform, "OnKeyDown", 67, 0);

            Assert.True(platform.TryGetLastKeyPressed(out ConsoleKey k1));
            Assert.True(platform.TryGetLastKeyPressed(out ConsoleKey k2));
            Assert.True(platform.TryGetLastKeyPressed(out ConsoleKey k3));

            Assert.Equal(ConsoleKey.A, k1);
            Assert.Equal(ConsoleKey.B, k2);
            Assert.Equal(ConsoleKey.C, k3);
        }

        /// <summary>
        /// Tests that web assembly platform on key up key not in states does not throw
        /// </summary>
        [Fact]
        public void WebAssemblyPlatform_OnKeyUp_KeyNotInStates_DoesNotThrow()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            InvokePrivate(platform, "OnKeyUp", 65, 0);
        }

        /// <summary>
        /// Tests that web assembly platform on mouse move updates client coords
        /// </summary>
        [Fact]
        public void WebAssemblyPlatform_OnMouseMove_UpdatesClientCoords()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            InvokePrivate(platform, "OnMouseMove", 100, 200, 300, 400);
            platform.GetMouseState(out int x, out int y, out _);
            Assert.Equal(300, x);
            Assert.Equal(400, y);
        }

        /// <summary>
        /// Tests that web assembly platform on mouse down updates coords and button
        /// </summary>
        [Fact]
        public void WebAssemblyPlatform_OnMouseDown_UpdatesCoordsAndButton()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            InvokePrivate(platform, "OnMouseDown", 0, 50, 60, 70, 80);
            platform.GetMouseState(out int x, out int y, out bool[] buttons);
            Assert.True(buttons[0]);
            Assert.Equal(70, x);
            Assert.Equal(80, y);
        }

        /// <summary>
        /// Tests that web assembly platform on mouse up updates coords and releases button
        /// </summary>
        [Fact]
        public void WebAssemblyPlatform_OnMouseUp_UpdatesCoordsAndReleasesButton()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            InvokePrivate(platform, "OnMouseDown", 0, 0, 0, 10, 20);
            InvokePrivate(platform, "OnMouseUp", 0, 0, 0, 30, 40);
            platform.GetMouseState(out int x, out int y, out bool[] buttons);
            Assert.False(buttons[0]);
            Assert.Equal(30, x);
            Assert.Equal(40, y);
        }

        /// <summary>
        /// Tests that web assembly platform on mouse wheel negative delta
        /// </summary>
        [Fact]
        public void WebAssemblyPlatform_OnMouseWheel_NegativeDelta()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            InvokePrivate(platform, "OnMouseWheel", 0, -10);
            Assert.Equal(-10.0f, platform.GetMouseWheel());
        }

        /// <summary>
        /// Tests that web assembly platform on mouse wheel zero delta
        /// </summary>
        [Fact]
        public void WebAssemblyPlatform_OnMouseWheel_ZeroDelta()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            InvokePrivate(platform, "OnMouseWheel", 0, 0);
            Assert.Equal(0.0f, platform.GetMouseWheel());
        }

        /// <summary>
        /// Tests that web assembly platform on gamepad connect same index twice does not duplicate
        /// </summary>
        [Fact]
        public void WebAssemblyPlatform_OnGamepadConnect_SameIndexTwice_DoesNotDuplicate()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            InvokePrivate(platform, "OnGamepadConnect", 0);
            InvokePrivate(platform, "OnGamepadConnect", 0);
            int[] indices = platform.GetConnectedGamepadIndices();
            Assert.Single(indices);
        }

        /// <summary>
        /// Tests that web assembly platform on window resize same size works
        /// </summary>
        [Fact]
        public void WebAssemblyPlatform_OnWindowResize_SameSize_Works()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            InvokePrivate(platform, "OnWindowResize", 800, 600);
            Assert.Equal(800, platform.GetWindowWidth());
            Assert.Equal(600, platform.GetWindowHeight());
        }

        /// <summary>
        /// Tests that web assembly platform on window resize zero size works
        /// </summary>
        [Fact]
        public void WebAssemblyPlatform_OnWindowResize_ZeroSize_Works()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            InvokePrivate(platform, "OnWindowResize", 0, 0);
            Assert.Equal(0, platform.GetWindowWidth());
            Assert.Equal(0, platform.GetWindowHeight());
        }

        /// <summary>
        /// Tests that web assembly platform on window resize max size works
        /// </summary>
        [Fact]
        public void WebAssemblyPlatform_OnWindowResize_MaxSize_Works()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            InvokePrivate(platform, "OnWindowResize", int.MaxValue, int.MaxValue);
            Assert.Equal(int.MaxValue, platform.GetWindowWidth());
            Assert.Equal(int.MaxValue, platform.GetWindowHeight());
        }

        /// <summary>
        /// Tests that web assembly platform on window resize negative size works
        /// </summary>
        [Fact]
        public void WebAssemblyPlatform_OnWindowResize_NegativeSize_Works()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            InvokePrivate(platform, "OnWindowResize", -100, -200);
            Assert.Equal(-100, platform.GetWindowWidth());
            Assert.Equal(-200, platform.GetWindowHeight());
        }

        /// <summary>
        /// Tests that web assembly platform poll events multiple calls resets wheel each time
        /// </summary>
        [Fact]
        public void WebAssemblyPlatform_PollEvents_MultipleCalls_ResetsWheelEachTime()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            InvokePrivate(platform, "OnMouseWheel", 0, 5);
            platform.PollEvents();
            Assert.Equal(0.0f, platform.GetMouseWheel());

            InvokePrivate(platform, "OnMouseWheel", 0, 10);
            platform.PollEvents();
            Assert.Equal(0.0f, platform.GetMouseWheel());
        }

        /// <summary>
        /// Tests that web assembly platform set window icon empty path does not throw
        /// </summary>
        [Fact]
        public void WebAssemblyPlatform_SetWindowIcon_EmptyPath_DoesNotThrow()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            platform.SetWindowIcon("");
        }

        /// <summary>
        /// Tests that web assembly platform set window icon null path does not throw
        /// </summary>
        [Fact]
        public void WebAssemblyPlatform_SetWindowIcon_NullPath_DoesNotThrow()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            platform.SetWindowIcon(null);
        }

        /// <summary>
        /// Tests that web assembly platform get window metrics returns default values on non browser
        /// </summary>
        [Fact]
        public void WebAssemblyPlatform_GetWindowMetrics_ReturnsDefaultValuesOnNonBrowser()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            platform.GetWindowMetrics(out int winX, out int winY, out int winW, out int winH, out int fbW, out int fbH);
            Assert.Equal(0, winX);
            Assert.Equal(0, winY);
            Assert.Equal(800, winW);
            Assert.Equal(600, winH);
        }
        

        /// <summary>
        /// Tests that web assembly platform get mouse state returns cloned array
        /// </summary>
        [Fact]
        public void WebAssemblyPlatform_GetMouseState_ReturnsClonedArray()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            platform.GetMouseState(out int x1, out int y1, out bool[] buttons1);
            platform.GetMouseState(out int x2, out int y2, out bool[] buttons2);
            Assert.NotSame(buttons1, buttons2);
        }

        /// <summary>
        /// Tests that web assembly platform get mouse state multiple buttons
        /// </summary>
        [Fact]
        public void WebAssemblyPlatform_GetMouseState_MultipleButtons()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            InvokePrivate(platform, "OnMouseDown", 0, 0, 0, 10, 20);
            InvokePrivate(platform, "OnMouseDown", 2, 0, 0, 10, 20);
            InvokePrivate(platform, "OnMouseDown", 4, 0, 0, 10, 20);
            platform.GetMouseState(out int x, out int y, out bool[] buttons);
            Assert.True(buttons[0]);
            Assert.False(buttons[1]);
            Assert.True(buttons[2]);
            Assert.False(buttons[3]);
            Assert.True(buttons[4]);
        }

        
        /// <summary>
        /// Webs the assembly platform convert key code maps correctly using the specified key code
        /// </summary>
        /// <param name="keyCode">The key code</param>
        /// <param name="expected">The expected</param>
        [InlineData(65, ConsoleKey.A)]
        [InlineData(66, ConsoleKey.B)]
        [InlineData(90, ConsoleKey.Z)]
        [InlineData(48, ConsoleKey.D0)]
        [InlineData(57, ConsoleKey.D9)]
        [InlineData(13, ConsoleKey.Enter)]
        [InlineData(9, ConsoleKey.Tab)]
        [InlineData(32, ConsoleKey.Spacebar)]
        [InlineData(8, ConsoleKey.Backspace)]
        [InlineData(27, ConsoleKey.Escape)]
        [InlineData(46, ConsoleKey.Delete)]
        [InlineData(37, ConsoleKey.LeftArrow)]
        [InlineData(38, ConsoleKey.UpArrow)]
        [InlineData(39, ConsoleKey.RightArrow)]
        [InlineData(40, ConsoleKey.DownArrow)]
        [InlineData(112, ConsoleKey.F1)]
        [InlineData(123, ConsoleKey.F12)]
        [InlineData(96, ConsoleKey.NumPad0)]
        [InlineData(105, ConsoleKey.NumPad9)]
        [InlineData(36, ConsoleKey.Home)]
        [InlineData(35, ConsoleKey.End)]
        [InlineData(33, ConsoleKey.PageUp)]
        [InlineData(34, ConsoleKey.PageDown)]
        [InlineData(45, ConsoleKey.Insert)]
        [InlineData(19, ConsoleKey.Pause)]
        public void WebAssemblyPlatform_ConvertKeyCode_MapsCorrectly(int keyCode, ConsoleKey expected)
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            InvokePrivate(platform, "OnKeyDown", keyCode, 0);
            Assert.True(platform.IsKeyDown(expected));
        }

        /// <summary>
        /// Tests that web assembly platform convert key code unknown key maps to no name
        /// </summary>
        [Fact]
        public void WebAssemblyPlatform_ConvertKeyCode_UnknownKey_MapsToNoName()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            InvokePrivate(platform, "OnKeyDown", 999, 0);
            Assert.True(platform.IsKeyDown(ConsoleKey.NoName));
        }

        /// <summary>
        /// Tests that web assembly platform get window position x returns default on non browser
        /// </summary>
        [Fact]
        public void WebAssemblyPlatform_GetWindowPositionX_ReturnsDefaultOnNonBrowser()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            int x = platform.GetWindowPositionX();
            Assert.Equal(0, x);
        }

        /// <summary>
        /// Tests that web assembly platform get window position y returns default on non browser
        /// </summary>
        [Fact]
        public void WebAssemblyPlatform_GetWindowPositionY_ReturnsDefaultOnNonBrowser()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            int y = platform.GetWindowPositionY();
            Assert.Equal(0, y);
        }

        /// <summary>
        /// Invokes the private using the specified instance
        /// </summary>
        /// <param name="instance">The instance</param>
        /// <param name="methodName">The method name</param>
        /// <param name="arguments">The arguments</param>
        private static void InvokePrivate(object instance, string methodName, params object[] arguments)
        {
            MethodInfo method = instance.GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.NonPublic);
            Assert.NotNull(method);
            method.Invoke(instance, arguments);
        }
    }
}
