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

        [Fact]
        public void WebAssemblyPlatform_CharInput_CollectsAndClears()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();

            InvokePrivate(platform, "OnCharInput", (uint) 65);

            Assert.True(platform.TryGetLastInputCharacters(out string chars));
            Assert.Equal("A", chars);
            Assert.False(platform.TryGetLastInputCharacters(out string _));
        }

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

        [Fact]
        public void WebAssemblyPlatform_GetMousePositionInView_ReturnsDefaultCoords()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            platform.GetMousePositionInView(out float x, out float y);
            Assert.Equal(0, x);
            Assert.Equal(0, y);
        }

        [Fact]
        public void WebAssemblyPlatform_TryGetGamepadState_NoGamepads_ReturnsFalse()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            bool result = platform.TryGetGamepadState(0, out GamepadState state);
            Assert.False(result);
            Assert.Null(state);
        }

        [Fact]
        public void WebAssemblyPlatform_GetConnectedGamepadIndices_Empty_ReturnsEmptyArray()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            int[] indices = platform.GetConnectedGamepadIndices();
            Assert.NotNull(indices);
            Assert.Empty(indices);
        }

        [Fact]
        public void WebAssemblyPlatform_GetProcAddress_CallsInterop()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            Assert.ThrowsAny<Exception>(() => platform.GetProcAddress("glClearColor"));
        }

        [Fact]
        public void WebAssemblyPlatform_ShowWindow_SetsVisible()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            platform.ShowWindow();
            Assert.True(platform.IsWindowVisible());
        }

        [Fact]
        public void WebAssemblyPlatform_HideWindow_ClearsVisible()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            platform.ShowWindow();
            platform.HideWindow();
            Assert.False(platform.IsWindowVisible());
        }

        [Fact]
        public void WebAssemblyPlatform_SetTitle_DoesNotThrow()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            platform.SetTitle("New Title");
        }

        [Fact]
        public void WebAssemblyPlatform_SetSize_DoesNotThrow()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            platform.SetSize(1024, 768);
        }

        [Fact]
        public void WebAssemblyPlatform_SetWindowIcon_DoesNotThrow()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            platform.SetWindowIcon("/icon.png");
        }

        [Fact]
        public void WebAssemblyPlatform_PollEvents_ResetsWheelDelta()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            InvokePrivate(platform, "OnMouseWheel", 0, 5);
            Assert.Equal(5.0f, platform.GetMouseWheel());

            platform.PollEvents();

            Assert.Equal(0.0f, platform.GetMouseWheel());
        }

        [Fact]
        public void WebAssemblyPlatform_PollEvents_ReturnsTrueWhenNotClosing()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            bool result = platform.PollEvents();
            Assert.True(result);
        }

        [Fact]
        public void WebAssemblyPlatform_Cleanup_NotInitialized_DoesNothing()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            platform.Cleanup();
        }

        [Fact]
        public void WebAssemblyPlatform_Cleanup_NotInitialized_DoesNotClearState()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            InvokePrivate(platform, "OnKeyDown", 65, 0);
            InvokePrivate(platform, "OnCharInput", (uint)'B');

            platform.Cleanup();

            Assert.True(platform.IsKeyDown(ConsoleKey.A));
        }

        [Fact]
        public void WebAssemblyPlatform_Initialize_WhenAlreadyInitialized_ReturnsTrue()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            platform.Initialize(800, 600, "Test");
        }

        [Fact]
        public void WebAssemblyPlatform_MakeContextCurrent_WithZeroHandles_DoesNotThrow()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            platform.MakeContextCurrent();
        }

        [Fact]
        public void WebAssemblyPlatform_SwapBuffers_WithZeroHandles_DoesNotThrow()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            platform.SwapBuffers();
        }

        [Fact]
        public void WebAssemblyPlatform_TryGetLastKeyPressed_EmptyQueue_ReturnsFalse()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            bool result = platform.TryGetLastKeyPressed(out ConsoleKey key);
            Assert.False(result);
            Assert.Equal(ConsoleKey.NoName, key);
        }

        [Fact]
        public void WebAssemblyPlatform_IsKeyDown_UnknownKey_ReturnsFalse()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            Assert.False(platform.IsKeyDown(ConsoleKey.F24));
        }

        [Fact]
        public void WebAssemblyPlatform_TryGetLastInputCharacters_Empty_ReturnsFalse()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            bool result = platform.TryGetLastInputCharacters(out string chars);
            Assert.False(result);
            Assert.Equal(string.Empty, chars);
        }

        [Fact]
        public void WebAssemblyPlatform_OnMouseWheel_SetsDelta()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            InvokePrivate(platform, "OnMouseWheel", 0, -3);
            Assert.Equal(-3.0f, platform.GetMouseWheel());
        }

        [Fact]
        public void WebAssemblyPlatform_OnMouseWheel_PositiveDelta()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            InvokePrivate(platform, "OnMouseWheel", 0, 10);
            Assert.Equal(10.0f, platform.GetMouseWheel());
        }

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

        [Fact]
        public void WebAssemblyPlatform_OnMouseDown_BoundaryButton4_Works()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            InvokePrivate(platform, "OnMouseDown", 4, 0, 0, 10, 20);
            platform.GetMouseState(out int x, out int y, out bool[] buttons);
            Assert.True(buttons[4]);
        }

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

        [Fact]
        public void WebAssemblyPlatform_OnMouseDown_NegativeButton_Ignored()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            InvokePrivate(platform, "OnMouseDown", -1, 0, 0, 10, 20);
            platform.GetMouseState(out int x, out int y, out bool[] buttons);
            Assert.False(buttons[0]);
        }

        [Fact]
        public void WebAssemblyPlatform_OnMouseUp_OutOfBoundsButton_Ignored()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            InvokePrivate(platform, "OnMouseUp", 10, 0, 0, 0, 0);
        }

        [Fact]
        public void WebAssemblyPlatform_OnWindowResize_UpdatesDimensions()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            InvokePrivate(platform, "OnWindowResize", 1920, 1080);
            Assert.Equal(1920, platform.GetWindowWidth());
            Assert.Equal(1080, platform.GetWindowHeight());
        }

        [Fact]
        public void WebAssemblyPlatform_OnWindowClose_SetsShouldClose()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            InvokePrivate(platform, "OnWindowClose");
            bool result = platform.PollEvents();
            Assert.False(result);
        }

        [Fact]
        public void WebAssemblyPlatform_OnWindowFocus_True_SetsVisible()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            InvokePrivate(platform, "OnWindowFocus", true);
            Assert.True(platform.IsWindowVisible());
        }

        [Fact]
        public void WebAssemblyPlatform_OnWindowFocus_False_ClearsVisible()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            InvokePrivate(platform, "OnWindowFocus", false);
            Assert.False(platform.IsWindowVisible());
        }

        [Fact]
        public void WebAssemblyPlatform_OnGamepadConnect_CreatesState()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            InvokePrivate(platform, "OnGamepadConnect", 0);
            bool result = platform.TryGetGamepadState(0, out GamepadState state);
            Assert.True(result);
            Assert.True(state.Connected);
        }

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

        [Fact]
        public void WebAssemblyPlatform_OnGamepadDisconnect_NonExistent_DoesNotThrow()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            InvokePrivate(platform, "OnGamepadDisconnect", 99);
        }

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

        [Fact]
        public void WebAssemblyPlatform_GetConnectedGamepadIndices_AllDisconnected_ReturnsEmpty()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            InvokePrivate(platform, "OnGamepadConnect", 0);
            InvokePrivate(platform, "OnGamepadDisconnect", 0);

            int[] indices = platform.GetConnectedGamepadIndices();
            Assert.Empty(indices);
        }

        [Fact]
        public void WebAssemblyPlatform_OnCharInput_InvalidCharCode_DoesNotThrow()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            InvokePrivate(platform, "OnCharInput", (uint)0x110000);
        }

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

        [Fact]
        public void WebAssemblyPlatform_OnKeyDown_RepeatedKey_DoesNotEnqueueWithoutRelease()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();

            InvokePrivate(platform, "OnKeyDown", 65, 0);
            Assert.True(platform.TryGetLastKeyPressed(out _));

            InvokePrivate(platform, "OnKeyDown", 65, 0);

            Assert.False(platform.TryGetLastKeyPressed(out _));
        }

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

        [Fact]
        public void WebAssemblyPlatform_OnKeyUp_KeyNotInStates_DoesNotThrow()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            InvokePrivate(platform, "OnKeyUp", 65, 0);
        }

        [Fact]
        public void WebAssemblyPlatform_OnMouseMove_UpdatesClientCoords()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            InvokePrivate(platform, "OnMouseMove", 100, 200, 300, 400);
            platform.GetMouseState(out int x, out int y, out _);
            Assert.Equal(300, x);
            Assert.Equal(400, y);
        }

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

        [Fact]
        public void WebAssemblyPlatform_OnMouseWheel_NegativeDelta()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            InvokePrivate(platform, "OnMouseWheel", 0, -10);
            Assert.Equal(-10.0f, platform.GetMouseWheel());
        }

        [Fact]
        public void WebAssemblyPlatform_OnMouseWheel_ZeroDelta()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            InvokePrivate(platform, "OnMouseWheel", 0, 0);
            Assert.Equal(0.0f, platform.GetMouseWheel());
        }

        [Fact]
        public void WebAssemblyPlatform_OnGamepadConnect_SameIndexTwice_DoesNotDuplicate()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            InvokePrivate(platform, "OnGamepadConnect", 0);
            InvokePrivate(platform, "OnGamepadConnect", 0);
            int[] indices = platform.GetConnectedGamepadIndices();
            Assert.Single(indices);
        }

        [Fact]
        public void WebAssemblyPlatform_OnWindowResize_SameSize_Works()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            InvokePrivate(platform, "OnWindowResize", 800, 600);
            Assert.Equal(800, platform.GetWindowWidth());
            Assert.Equal(600, platform.GetWindowHeight());
        }

        [Fact]
        public void WebAssemblyPlatform_OnWindowResize_ZeroSize_Works()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            InvokePrivate(platform, "OnWindowResize", 0, 0);
            Assert.Equal(0, platform.GetWindowWidth());
            Assert.Equal(0, platform.GetWindowHeight());
        }

        [Fact]
        public void WebAssemblyPlatform_OnWindowResize_MaxSize_Works()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            InvokePrivate(platform, "OnWindowResize", int.MaxValue, int.MaxValue);
            Assert.Equal(int.MaxValue, platform.GetWindowWidth());
            Assert.Equal(int.MaxValue, platform.GetWindowHeight());
        }

        [Fact]
        public void WebAssemblyPlatform_OnWindowResize_NegativeSize_Works()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            InvokePrivate(platform, "OnWindowResize", -100, -200);
            Assert.Equal(-100, platform.GetWindowWidth());
            Assert.Equal(-200, platform.GetWindowHeight());
        }

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

        [Fact]
        public void WebAssemblyPlatform_SetWindowIcon_EmptyPath_DoesNotThrow()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            platform.SetWindowIcon("");
        }

        [Fact]
        public void WebAssemblyPlatform_SetWindowIcon_NullPath_DoesNotThrow()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            platform.SetWindowIcon(null);
        }

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
        

        [Fact]
        public void WebAssemblyPlatform_GetMouseState_ReturnsClonedArray()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            platform.GetMouseState(out int x1, out int y1, out bool[] buttons1);
            platform.GetMouseState(out int x2, out int y2, out bool[] buttons2);
            Assert.NotSame(buttons1, buttons2);
        }

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

        [Theory]
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

        [Fact]
        public void WebAssemblyPlatform_ConvertKeyCode_UnknownKey_MapsToNoName()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            InvokePrivate(platform, "OnKeyDown", 999, 0);
            Assert.True(platform.IsKeyDown(ConsoleKey.NoName));
        }

        [Fact]
        public void WebAssemblyPlatform_GetWindowPositionX_ReturnsDefaultOnNonBrowser()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            int x = platform.GetWindowPositionX();
            Assert.Equal(0, x);
        }

        [Fact]
        public void WebAssemblyPlatform_GetWindowPositionY_ReturnsDefaultOnNonBrowser()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            int y = platform.GetWindowPositionY();
            Assert.Equal(0, y);
        }

        private static void InvokePrivate(object instance, string methodName, params object[] arguments)
        {
            MethodInfo method = instance.GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.NonPublic);
            Assert.NotNull(method);
            method.Invoke(instance, arguments);
        }
    }
}
