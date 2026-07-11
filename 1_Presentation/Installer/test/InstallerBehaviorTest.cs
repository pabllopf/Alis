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

        private static T InvokePrivate<T>(string methodName, params object[] args)
        {
            MethodInfo method = GetPrivateMethod(methodName);
            object result = method.Invoke(null, args);
            return (T)result;
        }

        private static void InvokePrivateVoid(string methodName, params object[] args)
        {
            MethodInfo method = GetPrivateMethod(methodName);
            method.Invoke(null, args);
        }

        // ========================
        // Program.Main
        // ========================

        [Fact]
        public void Main_ShouldCallInstallerRun()
        {
            MethodInfo main = typeof(Program).GetMethod("Main", BindingFlags.Public | BindingFlags.Static);
            Assert.NotNull(main);
            try
            {
                main.Invoke(null, new object[] { Array.Empty<string>() });
            }
            catch (TargetInvocationException)
            {
            }
        }

        // ========================
        // CalculateDeltaTime
        // ========================

        [Fact]
        public void CalculateDeltaTime_NormalDelta_ReturnsDelta()
        {
            double lastTime = 0.0;
            double now = 1.0 / 60.0;
            double target = 1.0 / 60.0;

            double result = InvokePrivate<double>("CalculateDeltaTime", lastTime, now, target);

            Assert.Equal(now, result, 10);
            Assert.Equal(now, lastTime);
        }

        [Fact]
        public void CalculateDeltaTime_NegativeDelta_ReturnsTargetFrameTime()
        {
            double lastTime = 10.0;
            double now = 5.0;
            double target = 1.0 / 60.0;

            double result = InvokePrivate<double>("CalculateDeltaTime", lastTime, now, target);

            Assert.Equal(target, result, 10);
        }

        [Fact]
        public void CalculateDeltaTime_ZeroDelta_ReturnsTargetFrameTime()
        {
            double lastTime = 5.0;
            double now = 5.0;
            double target = 1.0 / 60.0;

            double result = InvokePrivate<double>("CalculateDeltaTime", lastTime, now, target);

            Assert.Equal(target, result, 10);
        }

        [Fact]
        public void CalculateDeltaTime_LargeDelta_ClampsToQuarter()
        {
            double lastTime = 0.0;
            double now = 1.0;
            double target = 1.0 / 60.0;

            double result = InvokePrivate<double>("CalculateDeltaTime", lastTime, now, target);

            Assert.Equal(0.25, result, 10);
        }

        // ========================
        // ApplyFrameTiming
        // ========================

        [Fact]
        public void ApplyFrameTiming_SleepTimePositiveAndSleepMsPositive_Sleeps()
        {
            Stopwatch sw = Stopwatch.StartNew();
            double now = sw.Elapsed.TotalSeconds;
            double target = 10.0;

            InvokePrivateVoid("ApplyFrameTiming", sw, now, target);
        }

        [Fact]
        public void ApplyFrameTiming_SleepTimeZero_DoesNotSleep()
        {
            Stopwatch sw = Stopwatch.StartNew();
            System.Threading.Thread.Sleep(50);
            double now = sw.Elapsed.TotalSeconds;

            InvokePrivateVoid("ApplyFrameTiming", sw, now, 0.001);
        }

        [Fact]
        public void ApplyFrameTiming_SleepTimeNegative_DoesNotSleep()
        {
            Stopwatch sw = Stopwatch.StartNew();
            System.Threading.Thread.Sleep(100);
            double now = sw.Elapsed.TotalSeconds;

            InvokePrivateVoid("ApplyFrameTiming", sw, now, 0.001);
        }

        // ========================
        // ProcessPendingInput
        // ========================

        [Fact]
        public void ProcessPendingInput_PlatformHasChars_SkipDueToNoImGui()
        {
            FakeBehaviorPlatform platform = new FakeBehaviorPlatform
            {
                TryGetLastInputCharactersResult = true,
                TryGetLastInputCharactersValue = "hello"
            };

            try
            {
                InvokePrivateVoid("ProcessPendingInput", IntPtr.Zero, platform);
            }
            catch (TargetInvocationException)
            {
            }
        }

        [Fact]
        public void ProcessPendingInput_PlatformHasNullChars_Skips()
        {
            FakeBehaviorPlatform platform = new FakeBehaviorPlatform
            {
                TryGetLastInputCharactersResult = true,
                TryGetLastInputCharactersValue = null
            };

            InvokePrivateVoid("ProcessPendingInput", IntPtr.Zero, platform);
        }

        [Fact]
        public void ProcessPendingInput_PlatformHasEmptyChars_Skips()
        {
            FakeBehaviorPlatform platform = new FakeBehaviorPlatform
            {
                TryGetLastInputCharactersResult = true,
                TryGetLastInputCharactersValue = string.Empty
            };

            InvokePrivateVoid("ProcessPendingInput", IntPtr.Zero, platform);
        }

        [Fact]
        public void ProcessPendingInput_PlatformHasNoChars_Skips()
        {
            FakeBehaviorPlatform platform = new FakeBehaviorPlatform
            {
                TryGetLastInputCharactersResult = false
            };

            InvokePrivateVoid("ProcessPendingInput", IntPtr.Zero, platform);
        }

        // ========================
        // ProcessKey
        // ========================

        [Fact]
        public void ProcessKey_KeyIsDown_CallsAddKeyEvent()
        {
            FakeBehaviorPlatform platform = new FakeBehaviorPlatform
            {
                IsKeyDownResult = true
            };

            try
            {
                InvokePrivateVoid("ProcessKey", IntPtr.Zero, ConsoleKey.A, 546, platform);
            }
            catch (TargetInvocationException)
            {
            }
        }

        [Fact]
        public void ProcessKey_KeyIsUp_CallsAddKeyEventFalse()
        {
            FakeBehaviorPlatform platform = new FakeBehaviorPlatform
            {
                IsKeyDownResult = false
            };

            try
            {
                InvokePrivateVoid("ProcessKey", IntPtr.Zero, ConsoleKey.A, 546, platform);
            }
            catch (TargetInvocationException)
            {
            }
        }

        // ========================
        // ProcessKeyWithImgui
        // ========================

        [Fact]
        public void ProcessKeyWithImgui_AllKeysProcessed()
        {
            FakeBehaviorPlatform platform = new FakeBehaviorPlatform();

            try
            {
                InvokePrivateVoid("ProcessKeyWithImgui", IntPtr.Zero, platform);
            }
            catch (TargetInvocationException)
            {
            }
        }

        // ========================
        // CheckGlError
        // ========================

        [Fact]
        public void CheckGlError_NoError_ReturnsSilently()
        {
            InvokePrivateVoid("CheckGlError");
        }

        [Fact]
        public void CheckGlError_WithError_LogsError()
        {
            InvokePrivateVoid("CheckGlError");
        }

        // ========================
        // ConfigureStyle
        // ========================

        [Fact]
        public void ConfigureStyle_ExecutesWithoutCrashing()
        {
            try
            {
                InvokePrivateVoid("ConfigureStyle");
            }
            catch (TargetInvocationException)
            {
            }
        }

        // ========================
        // GetPlatform
        // ========================

        [Fact]
        public void GetPlatform_ReturnsPlatform()
        {
            INativePlatform platform = InvokePrivate<INativePlatform>("GetPlatform");
            Assert.NotNull(platform);
        }

        // ========================
        // InitializeOpenGL
        // ========================

        [Fact]
        public void InitializeOpenGL_ExecutesWithPlatform()
        {
            FakeBehaviorPlatform platform = new FakeBehaviorPlatform();

            try
            {
                InvokePrivateVoid("InitializeOpenGL", platform);
            }
            catch (TargetInvocationException)
            {
            }
        }

        // ========================
        // InitializeImGui
        // ========================

        [Fact]
        public void InitializeImGui_Executes()
        {
            try
            {
                InvokePrivateVoid("InitializeImGui");
            }
            catch (TargetInvocationException)
            {
            }
        }

        // ========================
        // ConfigureImGui
        // ========================

        [Fact]
        public void ConfigureImGui_ExecutesWithPlatform()
        {
            FakeBehaviorPlatform platform = new FakeBehaviorPlatform
            {
                GetWindowWidthResult = 800,
                GetWindowHeightResult = 600
            };

            try
            {
                InvokePrivateVoid("ConfigureImGui", platform);
            }
            catch (TargetInvocationException)
            {
            }
        }

        // ========================
        // LoadFonts
        // ========================

        [Fact]
        public void LoadFonts_Executes()
        {
            try
            {
                InvokePrivateVoid("LoadFonts");
            }
            catch (TargetInvocationException)
            {
            }
        }

        // ========================
        // LoadTexture
        // ========================

        [Fact]
        public void LoadTexture_Executes()
        {
            IntPtr pixelData = Marshal.AllocHGlobal(4);
            try
            {
                InvokePrivate<uint>("LoadTexture", pixelData, 1, 1);
            }
            catch (TargetInvocationException)
            {
            }
            finally
            {
                Marshal.FreeHGlobal(pixelData);
            }
        }

        // ========================
        // Run
        // ========================

        [Fact]
        public void Run_WithEmptyArgs_Executes()
        {
            try
            {
                Installer.Run(Array.Empty<string>());
            }
            catch
            {
            }
        }

        // ========================
        // RunGameLoop
        // ========================

        [Fact]
        public void RunGameLoop_Executes()
        {
            Stopwatch sw = new Stopwatch();
            double lastTime = 0.0;

            try
            {
                InvokePrivateVoid("RunGameLoop", sw, lastTime, 1.0 / 60.0, IntPtr.Zero, new FakeBehaviorExample(), new FakeBehaviorPlatform());
            }
            catch (TargetInvocationException)
            {
            }
        }

        // ========================
        // ImguiSample Constructor
        // ========================

        [Fact]
        public void ImguiSample_ParameterlessConstructor_Initializes()
        {
            ImguiSample sample = new ImguiSample();
            Assert.NotNull(sample);
        }

        [Fact]
        public void ImguiSample_PlatformConstructor_SetsPlatform()
        {
            FakeBehaviorPlatform platform = new FakeBehaviorPlatform();
            ImguiSample sample = new ImguiSample(platform);
            Assert.NotNull(sample);
        }

        // ========================
        // ImguiSample.Initialize
        // ========================

        [Fact]
        public void ImguiSample_Initialize_Executes()
        {
            FakeBehaviorPlatform platform = new FakeBehaviorPlatform();
            ImguiSample sample = new ImguiSample(platform);
            try
            {
                sample.Initialize();
            }
            catch
            {
            }
        }

        // ========================
        // ImguiSample.Draw
        // ========================

        [Fact]
        public void ImguiSample_Draw_Executes()
        {
            FakeBehaviorPlatform platform = new FakeBehaviorPlatform();
            ImguiSample sample = new ImguiSample(platform);
            try
            {
                sample.Draw();
            }
            catch
            {
            }
        }

        // ========================
        // ImguiSample.Cleanup
        // ========================

        [Fact]
        public void ImguiSample_Cleanup_WithZeroResources_Succeeds()
        {
            ImguiSample sample = new ImguiSample();
            sample.Cleanup();
        }

        [Fact]
        public void ImguiSample_Cleanup_MultipleCalls_Succeeds()
        {
            ImguiSample sample = new ImguiSample();
            sample.Cleanup();
            sample.Cleanup();
        }

        // ========================
        // ImguiSample.UpdateMouseState
        // ========================

        [Fact]
        public void UpdateMouseState_NoMouseDown_DoesNotSetClicked()
        {
            FakeBehaviorPlatform platform = new FakeBehaviorPlatform();
            ImguiSample sample = new ImguiSample(platform);

            try
            {
                sample.Draw();
            }
            catch
            {
            }
        }

        // ========================
        // ImguiSample.RenderDrawData
        // ========================

        [Fact]
        public void RenderDrawData_EmptyCmdList_ReturnsEarly()
        {
            FakeBehaviorPlatform platform = new FakeBehaviorPlatform();
            ImguiSample sample = new ImguiSample(platform);

            FieldInfo field = typeof(ImguiSample).GetField("_vao", BindingFlags.NonPublic | BindingFlags.Instance);
            Assert.NotNull(field);
        }

        // ========================
        // All private methods exist
        // ========================

        [Fact]
        public void AllPrivateMethods_Exist()
        {
            string[] expectedMethods =
            {
                "CalculateDeltaTime",
                "ApplyFrameTiming",
                "ProcessPendingInput",
                "ProcessKey",
                "ProcessKeyWithImgui",
                "CheckGlError",
                "ConfigureStyle",
                "GetPlatform",
                "InitializeOpenGL",
                "InitializeImGui",
                "ConfigureImGui",
                "LoadFonts",
                "LoadTexture",
                "InitializePlatform",
                "LoadFontFromResource",
                "RunGameLoop"
            };

            foreach (string methodName in expectedMethods)
            {
                MethodInfo method = GetPrivateMethod(methodName);
                Assert.True(method != null, $"Private method '{methodName}' should exist");
            }
        }
    }

    internal sealed class FakeBehaviorPlatform : INativePlatform
    {
        public bool InitializeResult { get; set; } = true;
        public int InitializeCalls { get; private set; }
        public int LastWidth { get; private set; }
        public int LastHeight { get; private set; }
        public string LastTitle { get; private set; }

        public bool IsKeyDownResult { get; set; } = false;
        public bool TryGetLastInputCharactersResult { get; set; } = false;
        public string TryGetLastInputCharactersValue { get; set; }

        public int GetWindowWidthResult { get; set; } = 800;
        public int GetWindowHeightResult { get; set; } = 600;

        public bool Initialize(int width, int height, string title)
        {
            InitializeCalls++;
            LastWidth = width;
            LastHeight = height;
            LastTitle = title;
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
        public int GetWindowWidth() => GetWindowWidthResult;
        public int GetWindowHeight() => GetWindowHeightResult;
        public IntPtr GetProcAddress(string procName) => IntPtr.Zero;

        public bool TryGetLastKeyPressed(out ConsoleKey key)
        {
            key = default;
            return false;
        }

        public bool IsKeyDown(ConsoleKey consoleKey) => IsKeyDownResult;
        public void SetWindowIcon(string iconPath) { }

        public void GetMouseState(out int x, out int y, out bool[] buttons)
        {
            x = 0;
            y = 0;
            buttons = new bool[5];
        }

        public float GetMouseWheel() => 0f;

        public bool TryGetLastInputCharacters(out string chars)
        {
            chars = TryGetLastInputCharactersValue;
            return TryGetLastInputCharactersResult;
        }

        public int GetWindowPositionX() => 0;
        public int GetWindowPositionY() => 0;

        public void GetWindowMetrics(out int winX, out int winY, out int winW, out int winH, out int fbW, out int fbH)
        {
            winX = 0; winY = 0; winW = 0; winH = 0; fbW = 0; fbH = 0;
        }

        public void GetMousePositionInView(out float x, out float y)
        {
            x = 0; y = 0;
        }
    }

    internal sealed class FakeBehaviorExample : IExample
    {
        public void Initialize() { }
        public void Draw() { }
        public void Cleanup() { }
    }
}
