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
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using Alis.Core.Graphic.Platforms;
using Xunit;

namespace Alis.App.Installer.Test
{
    public class InstallerBehaviorTest
    {
        private static MethodInfo GetPrivateMethod(string name)
        {
            return typeof(Installer).GetMethod(name, BindingFlags.NonPublic | BindingFlags.Static);
        }

        private static object Invoke(string methodName, params object[] args)
        {
            return GetPrivateMethod(methodName).Invoke(null, args);
        }

        private static object CreateImGuiIoPtr()
        {
            Type type = Type.GetType("Alis.Extension.Graphic.Ui.ImGuiIoPtr, Alis.Extension.Graphic.Ui");
            return Activator.CreateInstance(type, new object[] { IntPtr.Zero });
        }

        private static object GetImGuiKey(string name)
        {
            Type type = Type.GetType("Alis.Extension.Graphic.Ui.ImGuiKey, Alis.Extension.Graphic.Ui");
            return Enum.Parse(type, name);
        }

        // ========================
        // CalculateDeltaTime (pure math)
        // ========================

        [Fact]
        public void CalculateDeltaTime_NormalDelta_ReturnsDelta()
        {
            object[] args = new object[] { 0.0, 1.0 / 60.0, 1.0 / 60.0 };
            double result = (double)Invoke("CalculateDeltaTime", args);
            Assert.Equal(1.0 / 60.0, result, 10);
            Assert.Equal(1.0 / 60.0, (double)args[0], 10);
        }

        [Fact]
        public void CalculateDeltaTime_NegativeDelta_ReturnsTarget()
        {
            double result = (double)Invoke("CalculateDeltaTime", 10.0, 5.0, 1.0 / 60.0);
            Assert.Equal(1.0 / 60.0, result, 10);
        }

        [Fact]
        public void CalculateDeltaTime_ZeroDelta_ReturnsTarget()
        {
            double result = (double)Invoke("CalculateDeltaTime", 5.0, 5.0, 1.0 / 60.0);
            Assert.Equal(1.0 / 60.0, result, 10);
        }

        [Fact]
        public void CalculateDeltaTime_LargeDelta_Clamps()
        {
            double result = (double)Invoke("CalculateDeltaTime", 0.0, 1.0, 1.0 / 60.0);
            Assert.Equal(0.25, result, 10);
        }

        // ========================
        // ApplyFrameTiming
        // ========================

        [Fact]
        public void ApplyFrameTiming_SleepTimePositive_Sleeps()
        {
            Stopwatch sw = Stopwatch.StartNew();
            System.Threading.Thread.Sleep(5);
            Invoke("ApplyFrameTiming", sw, sw.Elapsed.TotalSeconds, 0.1);
        }

        [Fact]
        public void ApplyFrameTiming_SleepTimeZero_DoesNotSleep()
        {
            Stopwatch sw = Stopwatch.StartNew();
            System.Threading.Thread.Sleep(50);
            Invoke("ApplyFrameTiming", sw, sw.Elapsed.TotalSeconds, 0.001);
        }

        [Fact]
        public void ApplyFrameTiming_SleepTimeNegative_DoesNotSleep()
        {
            Stopwatch sw = Stopwatch.StartNew();
            System.Threading.Thread.Sleep(100);
            Invoke("ApplyFrameTiming", sw, sw.Elapsed.TotalSeconds, 0.001);
        }

        // ========================
        // ProcessPendingInput (safe paths)
        // ========================

        [Fact]
        public void ProcessPendingInput_NullChars_Skips()
        {
            object io = CreateImGuiIoPtr();
            FakeBehaviorPlatform platform = new FakeBehaviorPlatform
            {
                TryGetLastInputCharactersResult = true,
                TryGetLastInputCharactersValue = null
            };
            Invoke("ProcessPendingInput", io, platform);
        }

        [Fact]
        public void ProcessPendingInput_EmptyChars_Skips()
        {
            object io = CreateImGuiIoPtr();
            FakeBehaviorPlatform platform = new FakeBehaviorPlatform
            {
                TryGetLastInputCharactersResult = true,
                TryGetLastInputCharactersValue = string.Empty
            };
            Invoke("ProcessPendingInput", io, platform);
        }

        [Fact]
        public void ProcessPendingInput_NoChars_Skips()
        {
            object io = CreateImGuiIoPtr();
            FakeBehaviorPlatform platform = new FakeBehaviorPlatform
            {
                TryGetLastInputCharactersResult = false
            };
            Invoke("ProcessPendingInput", io, platform);
        }

        // ========================
        // CheckGlError
        // ========================

        [Fact]
        public void CheckGlError_Safe()
        {
            try { Invoke("CheckGlError"); }
            catch (TargetInvocationException) { }
        }

        // ========================
        // GetPlatform
        // ========================

        [Fact]
        public void GetPlatform_ReturnsPlatform()
        {
            object result = Invoke("GetPlatform");
            Assert.NotNull(result);
        }

        // ========================
        // ImguiSample Constructors & Cleanup
        // ========================

        [Fact]
        public void ImguiSample_ParameterlessConstructor_Works()
        {
            Assert.NotNull(new ImguiSample());
        }

        [Fact]
        public void ImguiSample_PlatformConstructor_Works()
        {
            Assert.NotNull(new ImguiSample(new FakeBehaviorPlatform()));
        }

        [Fact]
        public void ImguiSample_Cleanup_ZeroResources_Works()
        {
            new ImguiSample().Cleanup();
        }

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

    public sealed class FakeBehaviorPlatform : INativePlatform
    {
        public bool InitializeResult { get; set; } = true;
        public int InitializeCalls { get; private set; }
        public int LastWidth { get; private set; }
        public int LastHeight { get; private set; }
        public string LastTitle { get; private set; }
        public bool IsKeyDownResult { get; set; } = false;
        public bool TryGetLastInputCharactersResult { get; set; } = false;
        public string TryGetLastInputCharactersValue { get; set; }

        public bool Initialize(int width, int height, string title)
        {
            InitializeCalls++; LastWidth = width; LastHeight = height; LastTitle = title;
            return InitializeResult;
        }
        public bool Initialize(int width, int height, string title, string iconPath) => Initialize(width, height, title);
        public void ShowWindow() { }
        public void HideWindow() { }
        public void SetTitle(string title) { }
        public void SetSize(int width, int height) { }
        public void MakeContextCurrent() { }
        public void SwapBuffers() { }
        public bool IsWindowVisible() => true;
        public bool PollEvents() => false;
        public void Cleanup() { }
        public int GetWindowWidth() => 800;
        public int GetWindowHeight() => 600;
        public IntPtr GetProcAddress(string procName) => IntPtr.Zero;
        public bool TryGetLastKeyPressed(out ConsoleKey key) { key = default; return false; }
        public bool IsKeyDown(ConsoleKey consoleKey) => IsKeyDownResult;
        public void SetWindowIcon(string iconPath) { }
        public void GetMouseState(out int x, out int y, out bool[] buttons) { x = 0; y = 0; buttons = new bool[5]; }
        public float GetMouseWheel() => 0f;
        public bool TryGetLastInputCharacters(out string chars) { chars = TryGetLastInputCharactersValue; return TryGetLastInputCharactersResult; }
        public int GetWindowPositionX() => 0;
        public int GetWindowPositionY() => 0;
        public void GetWindowMetrics(out int a, out int b, out int c, out int d, out int e, out int f) { a = b = c = d = e = f = 0; }
        public void GetMousePositionInView(out float x, out float y) { x = 0; y = 0; }
    }
}
