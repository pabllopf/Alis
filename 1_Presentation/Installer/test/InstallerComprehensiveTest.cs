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
        /// <summary>
        /// Tests that installer type should be public
        /// </summary>
        [Fact]
        public void Installer_Type_ShouldBePublicClass()
        {
            Type type = typeof(Installer);

            Assert.True(type.IsClass);
            Assert.True(type.IsPublic);
        }

        /// <summary>
        /// Tests that program type should be public static
        /// </summary>
        [Fact]
        public void Program_Type_ShouldBePublicStaticClass()
        {
            Type type = typeof(Program);

            Assert.True(type.IsClass);
            Assert.True(type.IsPublic);
            Assert.True(type.IsAbstract);
            Assert.True(type.IsSealed);
        }

        /// <summary>
        /// Tests that program main should match entry point signature
        /// </summary>
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

        /// <summary>
        /// Tests that imgui sample should implement internal i example
        /// </summary>
        [Fact]
        public void ImguiSample_ShouldImplementInternalIExample()
        {
            Type imguiSample = typeof(ImguiSample);
            Type[] interfaces = imguiSample.GetInterfaces();

            Assert.Contains(interfaces, i => i.Name == "IExample");
        }

        /// <summary>
        /// Tests that imgui sample constructors should exist
        /// </summary>
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

        /// <summary>
        /// Tests that imgui sample public lifecycle methods should exist
        /// </summary>
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

        /// <summary>
        /// Tests that installer run should expose expected signature
        /// </summary>
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

        /// <summary>
        /// Tests that installer initialize platform should return false when platform is null
        /// </summary>
        [Fact]
        public void Installer_InitializePlatform_ShouldReturnFalse_WhenPlatformIsNull()
        {
            MethodInfo method = typeof(Installer).GetMethod("InitializePlatform", BindingFlags.NonPublic | BindingFlags.Static);

            Assert.NotNull(method);

            object result = method.Invoke(null, new object[] { null, 800, 600, "title" });

            Assert.IsType<bool>(result);
            Assert.False((bool)result);
        }

        /// <summary>
        /// Tests that installer initialize platform should return false when initialize fails
        /// </summary>
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

        /// <summary>
        /// Tests that installer initialize platform should return true when initialize succeeds
        /// </summary>
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

        /// <summary>
        /// Tests that installer load font from resource should copy bytes to native memory
        /// </summary>
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

        /// <summary>
        /// Tests that installer load font from resource should advance stream position to end
        /// </summary>
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

        /// <summary>
        /// Tests that installer private helpers should exist with expected signatures
        /// </summary>
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

        /// <summary>
        /// The fake platform class
        /// </summary>
        /// <seealso cref="INativePlatform"/>
        private sealed class FakePlatform : INativePlatform
        {
            /// <summary>
            /// Gets or sets the value of the initialize result
            /// </summary>
            public bool InitializeResult { get; set; }
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
            /// Initializes the width
            /// </summary>
            /// <param name="width">The width</param>
            /// <param name="height">The height</param>
            /// <param name="title">The title</param>
            /// <returns>The initialize result</returns>
            public bool Initialize(int width, int height, string title)
            {
                InitializeCalls++;
                LastWidth = width;
                LastHeight = height;
                LastTitle = title;
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
            public bool PollEvents() => true;
            /// <summary>
            /// Cleanups this instance
            /// </summary>
            public void Cleanup() { }
            /// <summary>
            /// Gets the window width
            /// </summary>
            /// <returns>The int</returns>
            public int GetWindowWidth() => 0;
            /// <summary>
            /// Gets the window height
            /// </summary>
            /// <returns>The int</returns>
            public int GetWindowHeight() => 0;
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
            public bool TryGetLastKeyPressed(out ConsoleKey key)
            {
                key = default;
                return false;
            }

            /// <summary>
            /// Ises the key down using the specified console key
            /// </summary>
            /// <param name="consoleKey">The console key</param>
            /// <returns>The bool</returns>
            public bool IsKeyDown(ConsoleKey consoleKey) => false;
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
            public void GetMouseState(out int x, out int y, out bool[] buttons)
            {
                x = 0;
                y = 0;
                buttons = new bool[5];
            }

            /// <summary>
            /// Gets the mouse wheel
            /// </summary>
            /// <returns>The float</returns>
            public float GetMouseWheel() => 0f;
            /// <summary>
            /// Tries the get last input characters using the specified chars
            /// </summary>
            /// <param name="chars">The chars</param>
            /// <returns>The bool</returns>
            public bool TryGetLastInputCharacters(out string chars)
            {
                chars = null;
                return false;
            }

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
            /// Gets the window metrics using the specified win x
            /// </summary>
            /// <param name="winX">The win</param>
            /// <param name="winY">The win</param>
            /// <param name="winW">The win</param>
            /// <param name="winH">The win</param>
            /// <param name="fbW">The fb</param>
            /// <param name="fbH">The fb</param>
            public void GetWindowMetrics(out int winX, out int winY, out int winW, out int winH, out int fbW, out int fbH)
            {
                winX = 0;
                winY = 0;
                winW = 0;
                winH = 0;
                fbW = 0;
                fbH = 0;
            }

            /// <summary>
            /// Gets the mouse position in view using the specified x
            /// </summary>
            /// <param name="x">The </param>
            /// <param name="y">The </param>
            public void GetMousePositionInView(out float x, out float y)
            {
                x = 0;
                y = 0;
            }
        }
    }
}

