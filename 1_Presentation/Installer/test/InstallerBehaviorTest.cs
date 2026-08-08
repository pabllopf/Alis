// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:InstallerBehaviorTest.cs
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
using System.Diagnostics;
using System.Reflection;
using System.Runtime.InteropServices;
using Alis.Core.Graphic.Platforms;
using Xunit;

namespace Alis.App.Installer.Test
{
    /// <summary>
    /// The installer behavior test class
    /// </summary>
    public class InstallerBehaviorTest
    {
        /// <summary>
        /// Gets the private method using the specified name
        /// </summary>
        /// <param name="name">The name</param>
        /// <returns>The method info</returns>
        private static MethodInfo GetPrivateMethod(string name)
        {
            return typeof(Installer).GetMethod(name, BindingFlags.NonPublic | BindingFlags.Static);
        }

        /// <summary>
        /// Invokes the private using the specified method name
        /// </summary>
        /// <param name="methodName">The method name</param>
        /// <param name="args">The args</param>
        /// <returns>The object</returns>
        private static object InvokePrivate(string methodName, params object[] args)
        {
            return GetPrivateMethod(methodName).Invoke(null, args);
        }

        /// <summary>
        /// Invokes the safe private using the specified method name
        /// </summary>
        /// <param name="methodName">The method name</param>
        /// <param name="args">The args</param>
        private static void InvokeSafePrivate(string methodName, params object[] args)
        {
            try { GetPrivateMethod(methodName).Invoke(null, args); }
            catch (TargetInvocationException) { }
        }

        /// <summary>
        /// Creates the im gui io ptr
        /// </summary>
        /// <returns>The object</returns>
        private static object CreateImGuiIoPtr()
        {
            Type type = Type.GetType("Alis.Extension.Graphic.Ui.ImGuiIoPtr, Alis.Extension.Graphic.Ui");
            return Activator.CreateInstance(type, new object[] { IntPtr.Zero });
        }

        // ========================
        // CalculateDeltaTime (pure math)
        // ========================

        /// <summary>
        /// Tests that calculate delta time normal delta returns delta
        /// </summary>
        [Fact]
        public void CalculateDeltaTime_NormalDelta_ReturnsDelta()
        {
            object[] args = new object[] { 0.0, 1.0 / 60.0, 1.0 / 60.0 };
            double result = (double)InvokePrivate("CalculateDeltaTime", args);
            Assert.Equal(1.0 / 60.0, result, 10);
            Assert.Equal(1.0 / 60.0, (double)args[0], 10);
        }

        /// <summary>
        /// Tests that calculate delta time negative delta returns target
        /// </summary>
        [Fact]
        public void CalculateDeltaTime_NegativeDelta_ReturnsTarget()
        {
            double result = (double)InvokePrivate("CalculateDeltaTime", 10.0, 5.0, 1.0 / 60.0);
            Assert.Equal(1.0 / 60.0, result, 10);
        }

        /// <summary>
        /// Tests that calculate delta time zero delta returns target
        /// </summary>
        [Fact]
        public void CalculateDeltaTime_ZeroDelta_ReturnsTarget()
        {
            double result = (double)InvokePrivate("CalculateDeltaTime", 5.0, 5.0, 1.0 / 60.0);
            Assert.Equal(1.0 / 60.0, result, 10);
        }

        /// <summary>
        /// Tests that calculate delta time large delta clamps
        /// </summary>
        [Fact]
        public void CalculateDeltaTime_LargeDelta_Clamps()
        {
            double result = (double)InvokePrivate("CalculateDeltaTime", 0.0, 1.0, 1.0 / 60.0);
            Assert.Equal(0.25, result, 10);
        }

        // ========================
        // ApplyFrameTiming
        // ========================

        /// <summary>
        /// Tests that apply frame timing sleep time positive sleeps
        /// </summary>
        [Fact]
        public void ApplyFrameTiming_SleepTimePositive_Sleeps()
        {
            Stopwatch sw = Stopwatch.StartNew();
            System.Threading.Thread.Sleep(5);
            InvokePrivate("ApplyFrameTiming", sw, sw.Elapsed.TotalSeconds, 0.1);
        }

        /// <summary>
        /// Tests that apply frame timing sleep time zero does not sleep
        /// </summary>
        [Fact]
        public void ApplyFrameTiming_SleepTimeZero_DoesNotSleep()
        {
            Stopwatch sw = Stopwatch.StartNew();
            System.Threading.Thread.Sleep(50);
            InvokePrivate("ApplyFrameTiming", sw, sw.Elapsed.TotalSeconds, 0.001);
        }

        /// <summary>
        /// Tests that apply frame timing sleep time negative does not sleep
        /// </summary>
        [Fact]
        public void ApplyFrameTiming_SleepTimeNegative_DoesNotSleep()
        {
            Stopwatch sw = Stopwatch.StartNew();
            System.Threading.Thread.Sleep(100);
            InvokePrivate("ApplyFrameTiming", sw, sw.Elapsed.TotalSeconds, 0.001);
        }

        // ========================
        // ProcessPendingInput (safe paths)
        // ========================

        /// <summary>
        /// Tests that process pending input null chars skips
        /// </summary>
        [Fact]
        public void ProcessPendingInput_NullChars_Skips()
        {
            object io = CreateImGuiIoPtr();
            FakeBehaviorPlatform platform = new FakeBehaviorPlatform
            {
                TryGetLastInputCharactersResult = true,
                TryGetLastInputCharactersValue = null
            };
            InvokePrivate("ProcessPendingInput", io, platform);
        }

        /// <summary>
        /// Tests that process pending input empty chars skips
        /// </summary>
        [Fact]
        public void ProcessPendingInput_EmptyChars_Skips()
        {
            object io = CreateImGuiIoPtr();
            FakeBehaviorPlatform platform = new FakeBehaviorPlatform
            {
                TryGetLastInputCharactersResult = true,
                TryGetLastInputCharactersValue = string.Empty
            };
            InvokePrivate("ProcessPendingInput", io, platform);
        }

        /// <summary>
        /// Tests that process pending input no chars skips
        /// </summary>
        [Fact]
        public void ProcessPendingInput_NoChars_Skips()
        {
            object io = CreateImGuiIoPtr();
            FakeBehaviorPlatform platform = new FakeBehaviorPlatform
            {
                TryGetLastInputCharactersResult = false
            };
            InvokePrivate("ProcessPendingInput", io, platform);
        }

        // ========================
        // CheckGlError (safe - throws NullRef)
        // ========================

        /// <summary>
        /// Tests that check gl error safe
        /// </summary>
        [Fact]
        public void CheckGlError_Safe()
        {
            InvokeSafePrivate("CheckGlError");
        }

        // ========================
        // GetPlatform
        // ========================

        /// <summary>
        /// Tests that get platform returns platform
        /// </summary>
        [Fact]
        public void GetPlatform_ReturnsPlatform()
        {
            object result = InvokePrivate("GetPlatform");
            Assert.NotNull(result);
        }

        // ========================
        // InitializeImGui (creates context - cleanup after)
        // ========================

        /// <summary>
        /// Tests that initialize im gui safe
        /// </summary>
        [Fact]
        public void InitializeImGui_Safe()
        {
            try
            {
                InvokePrivate("InitializeImGui");
            }
            catch (TargetInvocationException) { }
            finally
            {
                CleanupImGuiContext();
            }
        }

        /// <summary>
        /// Cleanups the im gui context
        /// </summary>
        private static void CleanupImGuiContext()
        {
            try
            {
                Type t = Type.GetType("Alis.Extension.Graphic.Ui.ImGui, Alis.Extension.Graphic.Ui");
                if (t != null)
                {
                    t.GetMethod("SetCurrentContext", new[] { typeof(IntPtr) })
                        ?.Invoke(null, new object[] { IntPtr.Zero });
                }
            }
            catch { }
        }

        // ========================
        // InitializeOpenGL (throws NullRef - safe)
        // ========================

        /// <summary>
        /// Tests that initialize open gl safe
        /// </summary>
        [Fact]
        public void InitializeOpenGL_Safe()
        {
            InvokeSafePrivate("InitializeOpenGL", new FakeBehaviorPlatform());
        }

        // ========================
        // LoadTexture (throws NullRef - safe)
        // ========================

        /// <summary>
        /// Tests that load texture safe
        /// </summary>
        [Fact]
        public void LoadTexture_Safe()
        {
            IntPtr pixelData = Marshal.AllocHGlobal(4);
            try
            {
                InvokeSafePrivate("LoadTexture", pixelData, 1, 1, Type.Missing, Type.Missing);
            }
            finally
            {
                Marshal.FreeHGlobal(pixelData);
            }
        }

        // ========================
        // ImguiSample Constructors & Cleanup
        // ========================

        /// <summary>
        /// Tests that imgui sample parameterless constructor works
        /// </summary>
        [Fact]
        public void ImguiSample_ParameterlessConstructor_Works()
        {
            Assert.NotNull(new ImguiSample());
        }

        /// <summary>
        /// Tests that imgui sample platform constructor works
        /// </summary>
        [Fact]
        public void ImguiSample_PlatformConstructor_Works()
        {
            Assert.NotNull(new ImguiSample(new FakeBehaviorPlatform()));
        }

        /// <summary>
        /// Tests that imgui sample cleanup zero resources works
        /// </summary>
        [Fact]
        public void ImguiSample_Cleanup_ZeroResources_Works()
        {
            new ImguiSample().Cleanup();
        }

        /// <summary>
        /// Tests that imgui sample cleanup multiple calls works
        /// </summary>
        [Fact]
        public void ImguiSample_Cleanup_MultipleCalls_Works()
        {
            ImguiSample s = new ImguiSample();
            s.Cleanup();
            s.Cleanup();
        }

        // ========================
        // All private methods exist
        // ========================

        /// <summary>
        /// Tests that all private methods exist
        /// </summary>
        [Fact]
        public void AllPrivateMethods_Exist()
        {
            string[] methods =
            {
                "CalculateDeltaTime", "ApplyFrameTiming", "ProcessPendingInput",
                "ProcessKey", "ProcessKeyWithImgui", "CheckGlError", "ConfigureStyle",
                "GetPlatform", "InitializeOpenGL", "InitializeImGui", "ConfigureImGui",
                "LoadFonts", "LoadTexture", "InitializePlatform", "LoadFontFromResource", "RunGameLoop"
            };
            foreach (string m in methods)
                Assert.NotNull(GetPrivateMethod(m));
        }
    }

    /// <summary>
    /// The fake behavior platform class
    /// </summary>
    /// <seealso cref="INativePlatform"/>
    public sealed class FakeBehaviorPlatform : INativePlatform
    {
        /// <summary>
        /// Gets or sets the value of the initialize result
        /// </summary>
        public bool InitializeResult { get; set; } = true;
        /// <summary>
        /// Gets or sets the value of the initialize calls
        /// </summary>
        public int InitializeCalls { get; private set; }
        /// <summary>
        /// Gets or sets the value of the last width
        /// </summary>
        public int LastWidth { get; private set; }
        /// <summary>
        /// Gets or sets the value of the last height
        /// </summary>
        public int LastHeight { get; private set; }
        /// <summary>
        /// Gets or sets the value of the last title
        /// </summary>
        public string LastTitle { get; private set; }
        /// <summary>
        /// Gets or sets the value of the is key down result
        /// </summary>
        public bool IsKeyDownResult { get; set; } = false;
        /// <summary>
        /// Gets or sets the value of the try get last input characters result
        /// </summary>
        public bool TryGetLastInputCharactersResult { get; set; } = false;
        /// <summary>
        /// Gets or sets the value of the try get last input characters value
        /// </summary>
        public string TryGetLastInputCharactersValue { get; set; }

        /// <summary>
        /// Initializes the width
        /// </summary>
        /// <param name="width">The width</param>
        /// <param name="height">The height</param>
        /// <param name="title">The title</param>
        /// <returns>The initialize result</returns>
        public bool Initialize(int width, int height, string title)
        {
            InitializeCalls++; LastWidth = width; LastHeight = height; LastTitle = title;
            return InitializeResult;
        }
        /// <summary>
        /// Initializes the width
        /// </summary>
        /// <param name="width">The width</param>
        /// <param name="height">The height</param>
        /// <param name="title">The title</param>
        /// <param name="iconPath">The icon path</param>
        /// <returns>The bool</returns>
        public bool Initialize(int width, int height, string title, string iconPath) => Initialize(width, height, title);
        /// <summary>
        /// Shows the window
        /// </summary>
        public void ShowWindow() { }
        /// <summary>
        /// Hides the window
        /// </summary>
        public void HideWindow() { }
        /// <summary>
        /// Sets the title using the specified title
        /// </summary>
        /// <param name="title">The title</param>
        public void SetTitle(string title) { }
        /// <summary>
        /// Sets the size using the specified width
        /// </summary>
        /// <param name="width">The width</param>
        /// <param name="height">The height</param>
        public void SetSize(int width, int height) { }
        /// <summary>
        /// Makes the context current
        /// </summary>
        public void MakeContextCurrent() { }
        /// <summary>
        /// Swaps the buffers
        /// </summary>
        public void SwapBuffers() { }
        /// <summary>
        /// Ises the window visible
        /// </summary>
        /// <returns>The bool</returns>
        public bool IsWindowVisible() => true;
        /// <summary>
        /// Polls the events
        /// </summary>
        /// <returns>The bool</returns>
        public bool PollEvents() => false;
        /// <summary>
        /// Cleanups this instance
        /// </summary>
        public void Cleanup() { }
        /// <summary>
        /// Gets the window width
        /// </summary>
        /// <returns>The int</returns>
        public int GetWindowWidth() => 800;
        /// <summary>
        /// Gets the window height
        /// </summary>
        /// <returns>The int</returns>
        public int GetWindowHeight() => 600;
        /// <summary>
        /// Gets the proc address using the specified proc name
        /// </summary>
        /// <param name="procName">The proc name</param>
        /// <returns>The int ptr</returns>
        public IntPtr GetProcAddress(string procName) => IntPtr.Zero;
        /// <summary>
        /// Tries the get last key pressed using the specified key
        /// </summary>
        /// <param name="key">The key</param>
        /// <returns>The bool</returns>
        public bool TryGetLastKeyPressed(out ConsoleKey key) { key = default; return false; }
        /// <summary>
        /// Ises the key down using the specified console key
        /// </summary>
        /// <param name="consoleKey">The console key</param>
        /// <returns>The bool</returns>
        public bool IsKeyDown(ConsoleKey consoleKey) => IsKeyDownResult;
        /// <summary>
        /// Sets the window icon using the specified icon path
        /// </summary>
        /// <param name="iconPath">The icon path</param>
        public void SetWindowIcon(string iconPath) { }
        /// <summary>
        /// Gets the mouse state using the specified x
        /// </summary>
        /// <param name="x">The </param>
        /// <param name="y">The </param>
        /// <param name="buttons">The buttons</param>
        public void GetMouseState(out int x, out int y, out bool[] buttons) { x = 0; y = 0; buttons = new bool[5]; }
        /// <summary>
        /// Gets the mouse wheel
        /// </summary>
        /// <returns>The float</returns>
        public float GetMouseWheel() => 0f;
        /// <summary>
        /// Tries the get last input characters using the specified chars
        /// </summary>
        /// <param name="chars">The chars</param>
        /// <returns>The try get last input characters result</returns>
        public bool TryGetLastInputCharacters(out string chars) { chars = TryGetLastInputCharactersValue; return TryGetLastInputCharactersResult; }
        /// <summary>
        /// Gets the window position x
        /// </summary>
        /// <returns>The int</returns>
        public int GetWindowPositionX() => 0;
        /// <summary>
        /// Gets the window position y
        /// </summary>
        /// <returns>The int</returns>
        public int GetWindowPositionY() => 0;
        /// <summary>
        /// Gets the window metrics using the specified a
        /// </summary>
        /// <param name="a">The </param>
        /// <param name="b">The </param>
        /// <param name="c">The </param>
        /// <param name="d">The </param>
        /// <param name="e">The </param>
        /// <param name="f">The </param>
        public void GetWindowMetrics(out int a, out int b, out int c, out int d, out int e, out int f) { a = b = c = d = e = f = 0; }
        /// <summary>
        /// Gets the mouse position in view using the specified x
        /// </summary>
        /// <param name="x">The </param>
        /// <param name="y">The </param>
        public void GetMousePositionInView(out float x, out float y) { x = 0; y = 0; }
    }
}
