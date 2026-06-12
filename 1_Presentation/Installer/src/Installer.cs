// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:Installer.cs
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
using System.Runtime.InteropServices;
using System.Threading;
using Alis.Core.Aspect.Logging;
using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Aspect.Memory;
using Alis.Core.Graphic.OpenGL;
using Alis.Core.Graphic.OpenGL.Enums;
using Alis.Core.Graphic.Platforms;
using Alis.Core.Graphic.Platforms.Osx;
using Alis.Extension.Graphic.Ui;
using Alis.Extension.Graphic.Ui.Extras.GuizMo;
using Alis.Extension.Graphic.Ui.Extras.Node;
using Alis.Extension.Graphic.Ui.Extras.Plot;
using Alis.Extension.Graphic.Ui.Fonts;

namespace Alis.App.Installer
{
    /// <summary>
    ///     Sample host application that creates a native window, initializes OpenGL and ImGui,
    ///     and runs the selected example. Code is organized for clarity and maintainability.
    /// </summary>
    public static class Installer
    {
        /// <summary>
        ///     Application entry point.
        /// </summary>
        public static void Run(string[] args)
        {
            const double targetFrameTime = 1.0 / 60.0;
            Stopwatch frameTimer = Stopwatch.StartNew();
            double lastTime = frameTimer.Elapsed.TotalSeconds;

            INativePlatform platform = GetPlatform();
            Debug.Assert(platform != null, "Platform implementation must be provided for the current OS.");

            if (!InitializePlatform(platform, 800, 600, "C# + OpenGL Platform"))
            {
                Logger.Info("Failed to initialize platform or OpenGL context. Exiting.");
                platform.Cleanup();
                return;
            }

            InitializeOpenGL(platform);
            IntPtr imguiContext = InitializeImGui();
            IExample example = new ImguiSample(platform);
            example.Initialize();

            platform.ShowWindow();
            platform.SetTitle("C# + OpenGL Platform - ImGui");

            ImGuiIoPtr io = ConfigureImGui(platform);
            Logger.Info($"IMGUI VERSION {ImGui.GetVersion()}");

            LoadFonts();
            ConfigureStyle();

            RunGameLoop(frameTimer, ref lastTime, targetFrameTime, io, example, platform);

            example.Cleanup();
            platform.Cleanup();
        }

        /// <summary>
        ///     Initializes OpenGL settings and context.
        /// </summary>
        private static void InitializeOpenGL(INativePlatform platform)
        {
            platform.MakeContextCurrent();
            Gl.Initialize(platform.GetProcAddress);
            Gl.GlViewport(0, 0, platform.GetWindowWidth(), platform.GetWindowHeight());
            Gl.GlEnable(EnableCap.DepthTest);
        }

        /// <summary>
        ///     Initializes ImGui context and returns it.
        /// </summary>
        private static IntPtr InitializeImGui()
        {
            IntPtr imguiContext = ImGui.CreateContext();
            ImGui.SetCurrentContext(imguiContext);

            ImNodes.CreateContext();
            ImPlot.CreateContext();
            ImGuizMo.SetImGuiContext(imguiContext);
            ImGui.SetCurrentContext(imguiContext);

            return imguiContext;
        }

        /// <summary>
        ///     Configures ImGui IO settings and returns the IO pointer.
        /// </summary>
        private static ImGuiIoPtr ConfigureImGui(INativePlatform platform)
        {
            ImGuiIoPtr io = ImGui.GetIo();
            io.DisplaySize = new Vector2F(platform.GetWindowWidth(), platform.GetWindowHeight());

            io.BackendFlags |= ImGuiBackendFlags.RendererHasVtxOffset
                               | ImGuiBackendFlags.PlatformHasViewports
                               | ImGuiBackendFlags.HasGamepad
                               | ImGuiBackendFlags.HasMouseHoveredViewport
                               | ImGuiBackendFlags.HasMouseCursors;

            io.ConfigFlags |= ImGuiConfigFlags.NavEnableKeyboard
                              | ImGuiConfigFlags.NavEnableGamepad
                              | ImGuiConfigFlags.DockingEnable
                              | ImGuiConfigFlags.ViewportsEnable;

            return io;
        }

        /// <summary>
        ///     Loads and configures fonts from resources.
        /// </summary>
        private static void LoadFonts()
        {
            ImFontAtlasPtr fonts = ImGui.GetIo().Fonts;

            const int fontSize = 14;
            Stream jetBrainsStream = AssetRegistry.GetResourceMemoryStreamByName("JetBrainsMono-Bold.ttf");
            Debug.Assert((jetBrainsStream != null) && (jetBrainsStream.Length > 0), "Primary font resource not found.");
            IntPtr primaryFontPtr = LoadFontFromResource(jetBrainsStream);

            fonts.AddFontFromMemoryTtf(primaryFontPtr, fontSize, fontSize);

            const int iconFontSize = 18;
            Stream faStream = AssetRegistry.GetResourceMemoryStreamByName(FontAwesome5.NameLight);
            if ((faStream != null) && (faStream.Length > 0))
            {
                IntPtr iconsPtr = LoadFontFromResource(faStream);

                ushort[] iconRanges = new ushort[3];
                iconRanges[0] = FontAwesome5.IconMin;
                iconRanges[1] = FontAwesome5.IconMax;
                iconRanges[2] = 0;

                GCHandle iconRangesHandle = GCHandle.Alloc(iconRanges, GCHandleType.Pinned);
                IntPtr rangePtr = iconRangesHandle.AddrOfPinnedObject();

                ImFontConfigPtr iconsConfig = ImGui.ImFontConfig();
                iconsConfig.MergeMode = true;
                iconsConfig.SnapH = true;
                iconsConfig.GlyphMinAdvanceX = 18;

                fonts.AddFontFromMemoryTtf(iconsPtr, iconFontSize, iconFontSize, iconsConfig, rangePtr);

                iconRangesHandle.Free();
            }

            fonts.GetTexDataAsRgba32(out IntPtr pixelData, out int texWidth, out int texHeight, out int _);
            uint fontTexId = LoadTexture(pixelData, texWidth, texHeight);
            fonts.TexId = (IntPtr) fontTexId;
            fonts.ClearTexData();
        }

        /// <summary>
        ///     Configures ImGui styling.
        /// </summary>
        private static void ConfigureStyle()
        {
            ImGuiStyle style = ImGui.GetStyle();
            ImGui.StyleColorsDark();
            style.WindowRounding = 0.0f;
            style.Colors2 = new Vector4F(0.00f, 0.00f, 0.00f, 1.00f);
        }

        /// <summary>
        ///     Processes the key with imgui
        /// </summary>
        private static void ProcessKeyWithImgui(ImGuiIoPtr io, INativePlatform platform)
        {
            ProcessKey(io, ConsoleKey.Backspace, ImGuiKey.Backspace, platform);
            ProcessKey(io, ConsoleKey.Tab, ImGuiKey.Tab, platform);
            ProcessKey(io, ConsoleKey.Enter, ImGuiKey.Enter, platform);
            ProcessKey(io, ConsoleKey.Pause, ImGuiKey.Pause, platform);
            ProcessKey(io, ConsoleKey.PrintScreen, ImGuiKey.PrintScreen, platform);
            ProcessKey(io, ConsoleKey.Escape, ImGuiKey.Escape, platform);
            ProcessKey(io, ConsoleKey.Spacebar, ImGuiKey.Space, platform);
            ProcessKey(io, ConsoleKey.PageUp, ImGuiKey.PageUp, platform);
            ProcessKey(io, ConsoleKey.PageDown, ImGuiKey.PageDown, platform);
            ProcessKey(io, ConsoleKey.End, ImGuiKey.End, platform);
            ProcessKey(io, ConsoleKey.Home, ImGuiKey.Home, platform);
            ProcessKey(io, ConsoleKey.Insert, ImGuiKey.Insert, platform);
            ProcessKey(io, ConsoleKey.Delete, ImGuiKey.Delete, platform);
            ProcessKey(io, ConsoleKey.LeftArrow, ImGuiKey.LeftArrow, platform);
            ProcessKey(io, ConsoleKey.UpArrow, ImGuiKey.UpArrow, platform);
            ProcessKey(io, ConsoleKey.RightArrow, ImGuiKey.RightArrow, platform);
            ProcessKey(io, ConsoleKey.DownArrow, ImGuiKey.DownArrow, platform);
            ProcessKey(io, ConsoleKey.D0, ImGuiKey._0, platform);
            ProcessKey(io, ConsoleKey.D1, ImGuiKey._1, platform);
            ProcessKey(io, ConsoleKey.D2, ImGuiKey._2, platform);
            ProcessKey(io, ConsoleKey.D3, ImGuiKey._3, platform);
            ProcessKey(io, ConsoleKey.D4, ImGuiKey._4, platform);
            ProcessKey(io, ConsoleKey.D5, ImGuiKey._5, platform);
            ProcessKey(io, ConsoleKey.D6, ImGuiKey._6, platform);
            ProcessKey(io, ConsoleKey.D7, ImGuiKey._7, platform);
            ProcessKey(io, ConsoleKey.D8, ImGuiKey._8, platform);
            ProcessKey(io, ConsoleKey.D9, ImGuiKey._9, platform);
            ProcessKey(io, ConsoleKey.A, ImGuiKey.A, platform);
            ProcessKey(io, ConsoleKey.B, ImGuiKey.B, platform);
            ProcessKey(io, ConsoleKey.C, ImGuiKey.C, platform);
            ProcessKey(io, ConsoleKey.D, ImGuiKey.D, platform);
            ProcessKey(io, ConsoleKey.E, ImGuiKey.E, platform);
            ProcessKey(io, ConsoleKey.F, ImGuiKey.F, platform);
            ProcessKey(io, ConsoleKey.G, ImGuiKey.G, platform);
            ProcessKey(io, ConsoleKey.H, ImGuiKey.H, platform);
            ProcessKey(io, ConsoleKey.I, ImGuiKey.I, platform);
            ProcessKey(io, ConsoleKey.J, ImGuiKey.J, platform);
            ProcessKey(io, ConsoleKey.K, ImGuiKey.K, platform);
            ProcessKey(io, ConsoleKey.L, ImGuiKey.L, platform);
            ProcessKey(io, ConsoleKey.M, ImGuiKey.M, platform);
            ProcessKey(io, ConsoleKey.N, ImGuiKey.N, platform);
            ProcessKey(io, ConsoleKey.O, ImGuiKey.O, platform);
            ProcessKey(io, ConsoleKey.P, ImGuiKey.P, platform);
            ProcessKey(io, ConsoleKey.Q, ImGuiKey.Q, platform);
            ProcessKey(io, ConsoleKey.R, ImGuiKey.R, platform);
            ProcessKey(io, ConsoleKey.S, ImGuiKey.S, platform);
            ProcessKey(io, ConsoleKey.T, ImGuiKey.T, platform);
            ProcessKey(io, ConsoleKey.U, ImGuiKey.U, platform);
            ProcessKey(io, ConsoleKey.V, ImGuiKey.V, platform);
            ProcessKey(io, ConsoleKey.W, ImGuiKey.W, platform);
            ProcessKey(io, ConsoleKey.X, ImGuiKey.X, platform);
            ProcessKey(io, ConsoleKey.Y, ImGuiKey.Y, platform);
            ProcessKey(io, ConsoleKey.Z, ImGuiKey.Z, platform);
            ProcessKey(io, ConsoleKey.F1, ImGuiKey.F1, platform);
            ProcessKey(io, ConsoleKey.F2, ImGuiKey.F2, platform);
            ProcessKey(io, ConsoleKey.F3, ImGuiKey.F3, platform);
            ProcessKey(io, ConsoleKey.F4, ImGuiKey.F4, platform);
            ProcessKey(io, ConsoleKey.F5, ImGuiKey.F5, platform);
            ProcessKey(io, ConsoleKey.F6, ImGuiKey.F6, platform);
            ProcessKey(io, ConsoleKey.F7, ImGuiKey.F7, platform);
            ProcessKey(io, ConsoleKey.F8, ImGuiKey.F8, platform);
            ProcessKey(io, ConsoleKey.F9, ImGuiKey.F9, platform);
            ProcessKey(io, ConsoleKey.F10, ImGuiKey.F10, platform);
            ProcessKey(io, ConsoleKey.F11, ImGuiKey.F11, platform);
            ProcessKey(io, ConsoleKey.F12, ImGuiKey.F12, platform);
            ProcessKey(io, ConsoleKey.NumPad0, ImGuiKey.Keypad0, platform);
            ProcessKey(io, ConsoleKey.NumPad1, ImGuiKey.Keypad1, platform);
            ProcessKey(io, ConsoleKey.NumPad2, ImGuiKey.Keypad2, platform);
            ProcessKey(io, ConsoleKey.NumPad3, ImGuiKey.Keypad3, platform);
            ProcessKey(io, ConsoleKey.NumPad4, ImGuiKey.Keypad4, platform);
            ProcessKey(io, ConsoleKey.NumPad5, ImGuiKey.Keypad5, platform);
            ProcessKey(io, ConsoleKey.NumPad6, ImGuiKey.Keypad6, platform);
            ProcessKey(io, ConsoleKey.NumPad7, ImGuiKey.Keypad7, platform);
            ProcessKey(io, ConsoleKey.NumPad8, ImGuiKey.Keypad8, platform);
            ProcessKey(io, ConsoleKey.NumPad9, ImGuiKey.Keypad9, platform);
            ProcessKey(io, ConsoleKey.Multiply, ImGuiKey.KeypadMultiply, platform);
            ProcessKey(io, ConsoleKey.Add, ImGuiKey.KeypadAdd, platform);
            ProcessKey(io, ConsoleKey.Subtract, ImGuiKey.KeypadSubtract, platform);
            ProcessKey(io, ConsoleKey.Decimal, ImGuiKey.KeypadDecimal, platform);
            ProcessKey(io, ConsoleKey.Divide, ImGuiKey.KeypadDivide, platform);
            ProcessKey(io, ConsoleKey.Oem1, ImGuiKey.Semicolon, platform);
            ProcessKey(io, ConsoleKey.Oem2, ImGuiKey.Slash, platform);
            ProcessKey(io, ConsoleKey.Oem3, ImGuiKey.GraveAccent, platform);
            ProcessKey(io, ConsoleKey.Oem4, ImGuiKey.LeftBracket, platform);
            ProcessKey(io, ConsoleKey.Oem5, ImGuiKey.Backslash, platform);
            ProcessKey(io, ConsoleKey.Oem6, ImGuiKey.RightBracket, platform);
            ProcessKey(io, ConsoleKey.Oem7, ImGuiKey.Apostrophe, platform);
            ProcessKey(io, ConsoleKey.OemComma, ImGuiKey.Comma, platform);
            ProcessKey(io, ConsoleKey.OemMinus, ImGuiKey.Minus, platform);
            ProcessKey(io, ConsoleKey.OemPeriod, ImGuiKey.Period, platform);
            ProcessKey(io, ConsoleKey.OemPlus, ImGuiKey.Equal, platform);
        }

        /// <summary>
        ///     Processes a single key event.
        /// </summary>
        private static void ProcessKey(ImGuiIoPtr io, ConsoleKey key, ImGuiKey imguiKey, INativePlatform platform)
        {
            if (platform.IsKeyDown(key))
            {
                io.AddKeyEvent(imguiKey, true);
            }
            else
            {
                io.AddKeyEvent(imguiKey, false);
            }
        }

        /// <summary>
        ///     Gets the platform
        /// </summary>
        /// <returns>The native platform</returns>
        private static INativePlatform GetPlatform()
        {
#if osxarm64 || osxarm || osxx64 || osx || osxarm || osxx64 || osx
            return new MacNativePlatform();
#elif winx64 || winx86 || winarm64 || winarm || win
            return new Alis.Core.Graphic.Platforms.Win.WinNativePlatform();
#elif linuxx64 || linuxx86 || linuxarm64 || linuxarm || linux
            return new Alis.Core.Graphic.Platforms.Linux.LinuxNativePlatform();
#else
            return null;
#endif
        }

        /// <summary>
        ///     Initializes the platform using the specified plat
        /// </summary>
        /// <param name="plat">The plat</param>
        /// <param name="width">The width</param>
        /// <param name="height">The height</param>
        /// <param name="title">The title</param>
        /// <returns>The bool</returns>
        private static bool InitializePlatform(INativePlatform plat, int width, int height, string title)
        {
            if (plat == null)
            {
                return false;
            }

            bool ok = plat.Initialize(width, height, title);
            if (!ok)
            {
                Logger.Info("Failed to create native window / OpenGL context.");
                return false;
            }

            return true;
        }

        /// <summary>
        ///     Loads the font from resource using the specified stream
        /// </summary>
        /// <param name="stream">The stream</param>
        /// <returns>The native ptr</returns>
        private static IntPtr LoadFontFromResource(Stream stream)
        {
            Debug.Assert((stream != null) && (stream.Length > 0), "Font stream must be valid.");

            byte[] data = new byte[stream.Length];
            stream.ReadExactly(data, 0, (int) stream.Length);
            IntPtr nativePtr = Marshal.AllocHGlobal(data.Length);
            Marshal.Copy(data, 0, nativePtr, data.Length);
            return nativePtr;
        }

        /// <summary>
        ///     Loads the texture using the specified pixel data
        /// </summary>
        /// <param name="pixelData">The pixel data</param>
        /// <param name="width">The width</param>
        /// <param name="height">The height</param>
        /// <param name="format">The format</param>
        /// <param name="internalFormat">The internal format</param>
        /// <returns>The texture id</returns>
        private static uint LoadTexture(IntPtr pixelData, int width, int height, PixelFormat format = PixelFormat.Rgba, PixelInternalFormat internalFormat = PixelInternalFormat.Rgba)
        {
            uint textureId = Gl.GenTexture();
            Gl.GlPixelStorei(StoreParameter.UnpackAlignment, 1);
            Gl.GlBindTexture(TextureTarget.Texture2D, textureId);
            Gl.GlTexImage2D(TextureTarget.Texture2D, 0, internalFormat, width, height, 0, format, PixelType.UnsignedByte, pixelData);
            Gl.GlTexParameteri(TextureTarget.Texture2D, TextureParameterName.TextureMagFilter, TextureParameter.Linear);
            Gl.GlTexParameteri(TextureTarget.Texture2D, TextureParameterName.TextureMinFilter, TextureParameter.Linear);
            Gl.GlBindTexture(TextureTarget.Texture2D, 0);
            return textureId;
        }

        /// <summary>
        ///     Runs the game loop
        /// </summary>
        private static void RunGameLoop(Stopwatch frameTimer, ref double lastTime, double targetFrameTime, ImGuiIoPtr io, IExample example, INativePlatform platform)
        {
            bool running = true;
            while (running)
            {
                double now = frameTimer.Elapsed.TotalSeconds;
                double delta = CalculateDeltaTime(ref lastTime, now, targetFrameTime);
                io.DeltaTime = (float) delta;

                running = platform.PollEvents();

                ProcessKeyWithImgui(io, platform);
                ProcessPendingInput(io, platform);
                example.Draw();
                platform.SwapBuffers();
                CheckGlError();
                ApplyFrameTiming(frameTimer, now, targetFrameTime);
            }
        }

        private static double CalculateDeltaTime(ref double lastTime, double now, double targetFrameTime)
        {
            double delta = now - lastTime;
            lastTime = now;
            if (delta <= 0.0)
            {
                delta = targetFrameTime;
            }
            else if (delta > 0.25)
            {
                delta = 0.25;
            }

            return delta;
        }

        private static void ProcessPendingInput(ImGuiIoPtr io, INativePlatform platform)
        {
            if (platform.TryGetLastInputCharacters(out string pendingChars) && !string.IsNullOrEmpty(pendingChars))
            {
                io.AddInputCharactersUtf8(pendingChars);
            }
        }

        private static void CheckGlError()
        {
            int glError = Gl.GlGetError();
            if (glError != 0)
            {
                Logger.Info($"OpenGL error after SwapBuffers: 0x{glError:X}");
            }
        }

        /// <summary>
        ///     Applies frame timing to maintain target frame rate
        /// </summary>
        private static void ApplyFrameTiming(Stopwatch frameTimer, double now, double targetFrameTime)
        {
            double frameEnd = frameTimer.Elapsed.TotalSeconds;
            double frameElapsed = frameEnd - now;
            double sleepTime = targetFrameTime - frameElapsed;
            if (sleepTime > 0.0)
            {
                int sleepMs = (int) (sleepTime * 1000.0);
                if (sleepMs > 0)
                {
                    Thread.Sleep(sleepMs);
                }

                while (frameTimer.Elapsed.TotalSeconds - now < targetFrameTime)
                {
                    Thread.SpinWait(10);
                }
            }
        }
    }
}