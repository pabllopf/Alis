// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:GlfwTestBootstrap.cs
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
using Alis.Extension.Graphic.Glfw.Enums;
using Alis.Extension.Graphic.Glfw.Structs;
using Xunit;

/// <summary>
///     Runtime startup hook invoked by the .NET runtime on the main thread before the entry point when
///     <c>DOTNET_STARTUP_HOOKS</c> points at this assembly and <c>ALIS_GLFW_HOOK=1</c> is set.
/// </summary>
public static class StartupHook
{
    /// <summary>
    ///     Initializes the GLFW bootstrap on the main thread.
    /// </summary>
    public static void Initialize()
    {
        try
        {
            if (Environment.GetEnvironmentVariable("ALIS_GLFW_HOOK") == "1")
            {
                Alis.Extension.Graphic.Glfw.Test.GlfwTestBootstrap.Initialize();
            }
        }
        catch (Exception)
        {
        }
    }
}

namespace Alis.Extension.Graphic.Glfw.Test
{
    /// <summary>
    ///     Initializes GLFW on the process main thread and owns the persistent native window used by the coverage tests.
    ///     <para>
    ///         GLFW 3.4 on macOS requires initialization and window creation on the main thread. xUnit runs tests on worker
    ///         threads, so this bootstrap is triggered from the <see cref="StartupHook" /> which the runtime executes on the
    ///         main thread before the entry point.
    ///     </para>
    /// </summary>
    internal static class GlfwTestBootstrap
    {
        /// <summary>
        ///     Rooted non-throwing error callback that records GLFW errors without crashing the test host.
        /// </summary>
        private static readonly ErrorCallback SilentErrorCallback = (code, message) => { };

        /// <summary>
        ///     The persistent native window created on the main thread.
        /// </summary>
        internal static NativeWindow Window;

        /// <summary>
        ///     The game window created on the main thread.
        /// </summary>
        internal static GameWindow GameWindowInstance;

        /// <summary>
        ///     The sized game window created on the main thread.
        /// </summary>
        internal static GameWindow GameWindowSizedInstance;

        /// <summary>
        ///     The fully parameterized game window created on the main thread.
        /// </summary>
        internal static GameWindow GameWindowFullInstance;

        /// <summary>
        ///     The primary monitor handle captured on the main thread.
        /// </summary>
        internal static Monitor PrimaryMonitor;

        /// <summary>
        ///     Indicates whether the bootstrap completed successfully on the main thread.
        /// </summary>
        internal static bool Ready;

        /// <summary>
        ///     Initializes GLFW and creates the persistent hidden window.
        /// </summary>
        internal static void Initialize()
        {
            if (Ready)
            {
                return;
            }

            GlfwNative.WindowHint(Hint.Visible, false);
            GlfwNative.WindowHint(Hint.ContextVersionMajor, 3);
            GlfwNative.WindowHint(Hint.ContextVersionMinor, 3);
            GlfwNative.WindowHint(Hint.OpenglProfile, GlfwProfile.Core);
            GlfwNative.WindowHint(Hint.OpenglForwardCompatible, true);
            Window = new TestableNativeWindow(320, 200, "alis-coverage");
            GameWindowInstance = new GameWindow();
            GameWindowSizedInstance = new GameWindow(320, 200, "alis-sized");
            GameWindowFullInstance = new GameWindow(320, 200, "alis-full", Alis.Extension.Graphic.Glfw.Structs.Monitor.None, Alis.Extension.Graphic.Glfw.Structs.Window.None);
            PrimaryMonitor = GlfwNative.PrimaryMonitor;
            GlfwNative.SetErrorCallback(SilentErrorCallback);
            Ready = true;
        }

        /// <summary>
        ///     Ensures the bootstrap ran; throws a skip signal when GLFW could not be initialized on the main thread.
        /// </summary>
        internal static void EnsureReady()
        {
            Assert.True(Ready, "GLFW main-thread bootstrap is unavailable; run with ALIS_GLFW_HOOK=1 and DOTNET_STARTUP_HOOKS set.");
        }
    }

    /// <summary>
    ///     Exposes protected <see cref="NativeWindow" /> members to the coverage tests.
    /// </summary>
    internal class TestableNativeWindow : NativeWindow
    {
        /// <inheritdoc cref="NativeWindow(int, int, string)" />
        public TestableNativeWindow(int width, int height, string title) : base(width, height, title)
        {
        }

        /// <summary>
        ///     Gets the underlying window handle.
        /// </summary>
        public Window UnderlyingWindow => Window;

        /// <summary>
        ///     Raises the <see cref="NativeWindow.Maximized" /> change handlers.
        /// </summary>
        public void FireOnMaximizeChanged(bool maximized) => OnMaximizeChanged(maximized);

        /// <summary>
        ///     Raises the content scale change handlers.
        /// </summary>
        public void FireOnContentScaleChanged(float xScale, float yScale) => OnContentScaleChanged(xScale, yScale);

        /// <summary>
        ///     Raises the character input handlers.
        /// </summary>
        public void FireOnCharacterInput(uint codePoint, ModifierKeys mods) => OnCharacterInput(codePoint, mods);

        /// <summary>
        ///     Raises the closed handlers.
        /// </summary>
        public void FireOnClosed() => OnClosed();

        /// <summary>
        ///     Raises the closing handlers.
        /// </summary>
        public void FireOnClosing() => OnClosing();

        /// <summary>
        ///     Raises the file drop handlers.
        /// </summary>
        public void FireOnFileDrop(string[] paths) => OnFileDrop(paths);

        /// <summary>
        ///     Raises the file drop handlers from a native pointer array.
        /// </summary>
        public void FireOnFileDrop(int count, IntPtr pointer) => OnFileDrop(count, pointer);

        /// <summary>
        ///     Raises the focus change handlers.
        /// </summary>
        public void FireOnFocusChanged(bool focusing) => OnFocusChanged(focusing);

        /// <summary>
        ///     Raises the framebuffer size handlers.
        /// </summary>
        public void FireOnFramebufferSizeChanged(int width, int height) => OnFramebufferSizeChanged(width, height);

        /// <summary>
        ///     Raises the key handlers.
        /// </summary>
        public void FireOnKey(Keys key, int scanCode, InputState state, ModifierKeys mods) => OnKey(key, scanCode, state, mods);

        /// <summary>
        ///     Raises the mouse button handlers.
        /// </summary>
        public void FireOnMouseButton(MouseButton button, InputState state, ModifierKeys modifiers) => OnMouseButton(button, state, modifiers);

        /// <summary>
        ///     Raises the mouse enter or leave handlers.
        /// </summary>
        public void FireOnMouseEnter(bool entering) => OnMouseEnter(entering);

        /// <summary>
        ///     Raises the mouse move handlers.
        /// </summary>
        public void FireOnMouseMove(double x, double y) => OnMouseMove(x, y);

        /// <summary>
        ///     Raises the mouse scroll handlers.
        /// </summary>
        public void FireOnMouseScroll(double x, double y) => OnMouseScroll(x, y);

        /// <summary>
        ///     Raises the position change handlers.
        /// </summary>
        public void FireOnPositionChanged(double x, double y) => OnPositionChanged(x, y);

        /// <summary>
        ///     Raises the size change handlers.
        /// </summary>
        public void FireOnSizeChanged(int width, int height) => OnSizeChanged(width, height);
    }
}
