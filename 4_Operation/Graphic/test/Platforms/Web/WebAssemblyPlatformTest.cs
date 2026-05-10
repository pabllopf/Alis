using System;
using System.Reflection;
using Alis.Core.Graphic.Platforms.Web;
using Xunit;

namespace Alis.Core.Graphic.Test.Platforms.Web
{
    /// <summary>
    ///     Tests for WebAssemblyPlatform state and input handling behavior.
    /// </summary>
    public class WebAssemblyPlatformTest
    {
        /// <summary>
        ///     Validates the default state on construction.
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
        ///     Validates that key events update the internal state and queue.
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
        ///     Validates that character input is accumulated and cleared.
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
        ///     Validates mouse movement and button state updates.
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
