// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:InstallerComprehensiveTest.cs
// 
//  Author:Pablo Perdomo Falcon
//  Web:https://www.pabllopf.dev/
// 
//  Copyright (c) 2021 GNU General Public License v3.0
// 
//  --------------------------------------------------------------------------

using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using Alis.Core.Graphic.Platforms;
using Xunit;

namespace Alis.App.Installer.Test
{
    /// <summary>
    ///     Comprehensive API-surface and private-method coverage for Installer module.
    ///     These tests avoid GL runtime execution and focus on deterministic behavior.
    /// </summary>
    public class InstallerComprehensiveTest
    {
        [Fact]
        public void Installer_Type_ShouldBePublicClass()
        {
            Type type = typeof(Installer);

            Assert.True(type.IsClass);
            Assert.True(type.IsPublic);
        }

        [Fact]
        public void Program_Type_ShouldBePublicStaticClass()
        {
            Type type = typeof(Program);

            Assert.True(type.IsClass);
            Assert.True(type.IsPublic);
            Assert.True(type.IsAbstract);
            Assert.True(type.IsSealed);
        }

        [Fact]
        public void Program_Main_ShouldMatchEntryPointSignature()
        {
            MethodInfo main = typeof(Program).GetMethod("Main", BindingFlags.Public | BindingFlags.Static);

            Assert.NotNull(main);
            Assert.Equal(typeof(void), main.ReturnType);

            ParameterInfo[] parameters = main.GetParameters();
            Assert.Single(parameters);
            Assert.Equal(typeof(string[]), parameters[0].ParameterType);
        }

        [Fact]
        public void ImguiSample_ShouldImplementInternalIExample()
        {
            Type imguiSample = typeof(ImguiSample);
            Type[] interfaces = imguiSample.GetInterfaces();

            Assert.Contains(interfaces, i => i.Name == "IExample");
        }

        [Fact]
        public void ImguiSample_Constructors_ShouldExist()
        {
            ConstructorInfo[] ctors = typeof(ImguiSample).GetConstructors(BindingFlags.Public | BindingFlags.Instance);

            Assert.Contains(ctors, c => c.GetParameters().Length == 0);
            Assert.Contains(ctors, c =>
            {
                ParameterInfo[] p = c.GetParameters();
                return p.Length == 1 && p[0].ParameterType == typeof(INativePlatform);
            });
        }

        [Fact]
        public void ImguiSample_PublicLifecycleMethods_ShouldExist()
        {
            MethodInfo initialize = typeof(ImguiSample).GetMethod("Initialize", BindingFlags.Public | BindingFlags.Instance);
            MethodInfo draw = typeof(ImguiSample).GetMethod("Draw", BindingFlags.Public | BindingFlags.Instance);
            MethodInfo cleanup = typeof(ImguiSample).GetMethod("Cleanup", BindingFlags.Public | BindingFlags.Instance);

            Assert.NotNull(initialize);
            Assert.NotNull(draw);
            Assert.NotNull(cleanup);

            Assert.Equal(typeof(void), initialize.ReturnType);
            Assert.Equal(typeof(void), draw.ReturnType);
            Assert.Equal(typeof(void), cleanup.ReturnType);
        }

        [Fact]
        public void Installer_Run_ShouldExposeExpectedSignature()
        {
            MethodInfo run = typeof(Installer).GetMethod("Run", BindingFlags.Public | BindingFlags.Instance);

            Assert.NotNull(run);
            Assert.Equal(typeof(void), run.ReturnType);

            ParameterInfo[] parameters = run.GetParameters();
            Assert.Single(parameters);
            Assert.Equal(typeof(string[]), parameters[0].ParameterType);
        }

        [Fact]
        public void Installer_InitializePlatform_ShouldReturnFalse_WhenPlatformIsNull()
        {
            MethodInfo method = typeof(Installer).GetMethod("InitializePlatform", BindingFlags.NonPublic | BindingFlags.Static);

            Assert.NotNull(method);

            object result = method.Invoke(null, new object[] { null, 800, 600, "title" });

            Assert.IsType<bool>(result);
            Assert.False((bool)result);
        }

        [Fact]
        public void Installer_InitializePlatform_ShouldReturnFalse_WhenInitializeFails()
        {
            MethodInfo method = typeof(Installer).GetMethod("InitializePlatform", BindingFlags.NonPublic | BindingFlags.Static);
            FakePlatform platform = new FakePlatform { InitializeResult = false };

            object result = method.Invoke(null, new object[] { platform, 1024, 768, "Fail Case" });

            Assert.False((bool)result);
            Assert.Equal(1, platform.InitializeCalls);
            Assert.Equal(1024, platform.LastWidth);
            Assert.Equal(768, platform.LastHeight);
            Assert.Equal("Fail Case", platform.LastTitle);
        }

        [Fact]
        public void Installer_InitializePlatform_ShouldReturnTrue_WhenInitializeSucceeds()
        {
            MethodInfo method = typeof(Installer).GetMethod("InitializePlatform", BindingFlags.NonPublic | BindingFlags.Static);
            FakePlatform platform = new FakePlatform { InitializeResult = true };

            object result = method.Invoke(null, new object[] { platform, 1280, 720, "Ok Case" });

            Assert.True((bool)result);
            Assert.Equal(1, platform.InitializeCalls);
            Assert.Equal(1280, platform.LastWidth);
            Assert.Equal(720, platform.LastHeight);
            Assert.Equal("Ok Case", platform.LastTitle);
        }

        [Fact]
        public void Installer_LoadFontFromResource_ShouldCopyBytesToNativeMemory()
        {
            MethodInfo method = typeof(Installer).GetMethod("LoadFontFromResource", BindingFlags.NonPublic | BindingFlags.Static);
            byte[] data = { 1, 2, 3, 4, 5, 6 };

            IntPtr ptr = IntPtr.Zero;

            try
            {
                using MemoryStream stream = new MemoryStream(data, writable: false);
                ptr = (IntPtr)method.Invoke(null, new object[] { stream });

                Assert.NotEqual(IntPtr.Zero, ptr);

                byte[] copied = new byte[data.Length];
                Marshal.Copy(ptr, copied, 0, copied.Length);

                Assert.True(data.SequenceEqual(copied));
            }
            finally
            {
                if (ptr != IntPtr.Zero)
                {
                    Marshal.FreeHGlobal(ptr);
                }
            }
        }

        [Fact]
        public void Installer_LoadFontFromResource_ShouldAdvanceStreamPositionToEnd()
        {
            MethodInfo method = typeof(Installer).GetMethod("LoadFontFromResource", BindingFlags.NonPublic | BindingFlags.Static);
            byte[] data = new byte[32];
            for (int i = 0; i < data.Length; i++)
            {
                data[i] = (byte)i;
            }

            IntPtr ptr = IntPtr.Zero;

            try
            {
                using MemoryStream stream = new MemoryStream(data, writable: false);
                ptr = (IntPtr)method.Invoke(null, new object[] { stream });

                Assert.Equal(stream.Length, stream.Position);
            }
            finally
            {
                if (ptr != IntPtr.Zero)
                {
                    Marshal.FreeHGlobal(ptr);
                }
            }
        }

        [Fact]
        public void Installer_PrivateHelpers_ShouldExistWithExpectedSignatures()
        {
            MethodInfo initializePlatform = typeof(Installer).GetMethod("InitializePlatform", BindingFlags.NonPublic | BindingFlags.Static);
            MethodInfo loadFont = typeof(Installer).GetMethod("LoadFontFromResource", BindingFlags.NonPublic | BindingFlags.Static);
            MethodInfo getPlatform = typeof(Installer).GetMethod("GetPlatform", BindingFlags.NonPublic | BindingFlags.Static);
            MethodInfo loadTexture = typeof(Installer).GetMethod("LoadTexture", BindingFlags.NonPublic | BindingFlags.Static);

            Assert.NotNull(initializePlatform);
            Assert.NotNull(loadFont);
            Assert.NotNull(getPlatform);
            Assert.NotNull(loadTexture);

            Assert.Equal(typeof(bool), initializePlatform.ReturnType);
            Assert.Equal(typeof(IntPtr), loadFont.ReturnType);
            Assert.Equal(typeof(INativePlatform), getPlatform.ReturnType);
            Assert.Equal(typeof(uint), loadTexture.ReturnType);
        }

        private sealed class FakePlatform : INativePlatform
        {
            public bool InitializeResult { get; set; }
            public int InitializeCalls { get; private set; }
            public int LastWidth { get; private set; }
            public int LastHeight { get; private set; }
            public string LastTitle { get; private set; }

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
            public bool PollEvents() => true;
            public void Cleanup() { }
            public int GetWindowWidth() => 0;
            public int GetWindowHeight() => 0;
            public IntPtr GetProcAddress(string procName) => IntPtr.Zero;
            public bool TryGetLastKeyPressed(out ConsoleKey key)
            {
                key = default;
                return false;
            }

            public bool IsKeyDown(ConsoleKey consoleKey) => false;
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
                chars = null;
                return false;
            }

            public int GetWindowPositionX() => 0;
            public int GetWindowPositionY() => 0;
            public void GetWindowMetrics(out int winX, out int winY, out int winW, out int winH, out int fbW, out int fbH)
            {
                winX = 0;
                winY = 0;
                winW = 0;
                winH = 0;
                fbW = 0;
                fbH = 0;
            }

            public void GetMousePositionInView(out float x, out float y)
            {
                x = 0;
                y = 0;
            }
        }
    }
}

