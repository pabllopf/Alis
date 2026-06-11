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
    public class Installer
    {
        /// <summary>
        ///     The platform
        /// </summary>
        private static INativePlatform _platform;

        /// <summary>
        ///     Application entry point.
        /// </summary>
        public static void Run(string[] args)
        {
            const double targetFrameTime = 1.0 / 60.0;
            Stopwatch frameTimer = Stopwatch.StartNew();
            double lastTime = frameTimer.Elapsed.TotalSeconds;

            _platform = GetPlatform();
            Debug.Assert(_platform != null, "Platform implementation must be provided for the current OS.");

            if (!InitializePlatform(_platform, 800, 600, "C# + OpenGL Platform"))
            {
                Logger.Info("Failed to initialize platform or OpenGL context. Exiting.");
                _platform.Cleanup();
                return;
            }

            _platform.MakeContextCurrent();
            Gl.Initialize(_platform.GetProcAddress);
            Gl.GlViewport(0, 0, _platform.GetWindowWidth(), _platform.GetWindowHeight());
            Gl.GlEnable(EnableCap.DepthTest);

            IntPtr imguiContext = ImGui.CreateContext();
            ImGui.SetCurrentContext(imguiContext);

            IExample example = new ImguiSample(_platform);
            example.Initialize();

            _platform.ShowWindow();
            _platform.SetTitle("C# + OpenGL Platform - ImGui");

            ImGuiIoPtr io = ImGui.GetIo();
            io.DisplaySize = new Vector2F(_platform.GetWindowWidth(), _platform.GetWindowHeight());

            Logger.Info($"IMGUI VERSION {ImGui.GetVersion()}");

            io.BackendFlags |= ImGuiBackendFlags.RendererHasVtxOffset
                               | ImGuiBackendFlags.PlatformHasViewports
                               | ImGuiBackendFlags.HasGamepad
                               | ImGuiBackendFlags.HasMouseHoveredViewport
                               | ImGuiBackendFlags.HasMouseCursors;

            io.ConfigFlags |= ImGuiConfigFlags.NavEnableKeyboard
                              | ImGuiConfigFlags.NavEnableGamepad
                              | ImGuiConfigFlags.DockingEnable
                              | ImGuiConfigFlags.ViewportsEnable;

            ImNodes.CreateContext();
            ImPlot.CreateContext();
            ImGuizMo.SetImGuiContext(imguiContext);
            ImGui.SetCurrentContext(imguiContext);

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

            ImGuiStyle style = ImGui.GetStyle();
            ImGui.StyleColorsDark();
            style.WindowRounding = 0.0f;
            style.Colors2 = new Vector4F(0.00f, 0.00f, 0.00f, 1.00f);

            RunGameLoop(frameTimer, ref lastTime, targetFrameTime, io, example);

            example.Cleanup();
            _platform.Cleanup();
        }

        /// <summary>
        ///     Processes the key with imgui
        /// </summary>
        private static void ProcessKeyWithImgui()
        {
            ImGuiIoPtr io = ImGui.GetIo();

            ProcessKey(io, ConsoleKey.Backspace, ImGuiKey.Backspace);
            ProcessKey(io, ConsoleKey.Tab, ImGuiKey.Tab);
            ProcessKey(io, ConsoleKey.Enter, ImGuiKey.Enter);
            ProcessKey(io, ConsoleKey.Pause, ImGuiKey.Pause);
            ProcessKey(io, ConsoleKey.PrintScreen, ImGuiKey.PrintScreen);
            ProcessKey(io, ConsoleKey.Escape, ImGuiKey.Escape);
            ProcessKey(io, ConsoleKey.Spacebar, ImGuiKey.Space);
            ProcessKey(io, ConsoleKey.PageUp, ImGuiKey.PageUp);
            ProcessKey(io, ConsoleKey.PageDown, ImGuiKey.PageDown);
            ProcessKey(io, ConsoleKey.End, ImGuiKey.End);
            ProcessKey(io, ConsoleKey.Home, ImGuiKey.Home);
            ProcessKey(io, ConsoleKey.Insert, ImGuiKey.Insert);
            ProcessKey(io, ConsoleKey.Delete, ImGuiKey.Delete);
            ProcessKey(io, ConsoleKey.LeftArrow, ImGuiKey.LeftArrow);
            ProcessKey(io, ConsoleKey.UpArrow, ImGuiKey.UpArrow);
            ProcessKey(io, ConsoleKey.RightArrow, ImGuiKey.RightArrow);
            ProcessKey(io, ConsoleKey.DownArrow, ImGuiKey.DownArrow);
            ProcessKey(io, ConsoleKey.D0, ImGuiKey._0);
            ProcessKey(io, ConsoleKey.D1, ImGuiKey._1);
            ProcessKey(io, ConsoleKey.D2, ImGuiKey._2);
            ProcessKey(io, ConsoleKey.D3, ImGuiKey._3);
            ProcessKey(io, ConsoleKey.D4, ImGuiKey._4);
            ProcessKey(io, ConsoleKey.D5, ImGuiKey._5);
            ProcessKey(io, ConsoleKey.D6, ImGuiKey._6);
            ProcessKey(io, ConsoleKey.D7, ImGuiKey._7);
            ProcessKey(io, ConsoleKey.D8, ImGuiKey._8);
            ProcessKey(io, ConsoleKey.D9, ImGuiKey._9);
            ProcessKey(io, ConsoleKey.A, ImGuiKey.A);
            ProcessKey(io, ConsoleKey.B, ImGuiKey.B);
            ProcessKey(io, ConsoleKey.C, ImGuiKey.C);
            ProcessKey(io, ConsoleKey.D, ImGuiKey.D);
            ProcessKey(io, ConsoleKey.E, ImGuiKey.E);
            ProcessKey(io, ConsoleKey.F, ImGuiKey.F);
            ProcessKey(io, ConsoleKey.G, ImGuiKey.G);
            ProcessKey(io, ConsoleKey.H, ImGuiKey.H);
            ProcessKey(io, ConsoleKey.I, ImGuiKey.I);
            ProcessKey(io, ConsoleKey.J, ImGuiKey.J);
            ProcessKey(io, ConsoleKey.K, ImGuiKey.K);
            ProcessKey(io, ConsoleKey.L, ImGuiKey.L);
            ProcessKey(io, ConsoleKey.M, ImGuiKey.M);
            ProcessKey(io, ConsoleKey.N, ImGuiKey.N);
            ProcessKey(io, ConsoleKey.O, ImGuiKey.O);
            ProcessKey(io, ConsoleKey.P, ImGuiKey.P);
            ProcessKey(io, ConsoleKey.Q, ImGuiKey.Q);
            ProcessKey(io, ConsoleKey.R, ImGuiKey.R);
            ProcessKey(io, ConsoleKey.S, ImGuiKey.S);
            ProcessKey(io, ConsoleKey.T, ImGuiKey.T);
            ProcessKey(io, ConsoleKey.U, ImGuiKey.U);
            ProcessKey(io, ConsoleKey.V, ImGuiKey.V);
            ProcessKey(io, ConsoleKey.W, ImGuiKey.W);
            ProcessKey(io, ConsoleKey.X, ImGuiKey.X);
            ProcessKey(io, ConsoleKey.Y, ImGuiKey.Y);
            ProcessKey(io, ConsoleKey.Z, ImGuiKey.Z);
            ProcessKey(io, ConsoleKey.F1, ImGuiKey.F1);
            ProcessKey(io, ConsoleKey.F2, ImGuiKey.F2);
            ProcessKey(io, ConsoleKey.F3, ImGuiKey.F3);
            ProcessKey(io, ConsoleKey.F4, ImGuiKey.F4);
            ProcessKey(io, ConsoleKey.F5, ImGuiKey.F5);
            ProcessKey(io, ConsoleKey.F6, ImGuiKey.F6);
            ProcessKey(io, ConsoleKey.F7, ImGuiKey.F7);
            ProcessKey(io, ConsoleKey.F8, ImGuiKey.F8);
            ProcessKey(io, ConsoleKey.F9, ImGuiKey.F9);
            ProcessKey(io, ConsoleKey.F10, ImGuiKey.F10);
            ProcessKey(io, ConsoleKey.F11, ImGuiKey.F11);
            ProcessKey(io, ConsoleKey.F12, ImGuiKey.F12);
            ProcessKey(io, ConsoleKey.NumPad0, ImGuiKey.Keypad0);
            ProcessKey(io, ConsoleKey.NumPad1, ImGuiKey.Keypad1);
            ProcessKey(io, ConsoleKey.NumPad2, ImGuiKey.Keypad2);
            ProcessKey(io, ConsoleKey.NumPad3, ImGuiKey.Keypad3);
            ProcessKey(io, ConsoleKey.NumPad4, ImGuiKey.Keypad4);
            ProcessKey(io, ConsoleKey.NumPad5, ImGuiKey.Keypad5);
            ProcessKey(io, ConsoleKey.NumPad6, ImGuiKey.Keypad6);
            ProcessKey(io, ConsoleKey.NumPad7, ImGuiKey.Keypad7);
            ProcessKey(io, ConsoleKey.NumPad8, ImGuiKey.Keypad8);
            ProcessKey(io, ConsoleKey.NumPad9, ImGuiKey.Keypad9);
            ProcessKey(io, ConsoleKey.Multiply, ImGuiKey.KeypadMultiply);
            ProcessKey(io, ConsoleKey.Add, ImGuiKey.KeypadAdd);
            ProcessKey(io, ConsoleKey.Subtract, ImGuiKey.KeypadSubtract);
            ProcessKey(io, ConsoleKey.Decimal, ImGuiKey.KeypadDecimal);
            ProcessKey(io, ConsoleKey.Divide, ImGuiKey.KeypadDivide);
            ProcessKey(io, ConsoleKey.Oem1, ImGuiKey.Semicolon);
            ProcessKey(io, ConsoleKey.Oem2, ImGuiKey.Slash);
            ProcessKey(io, ConsoleKey.Oem3, ImGuiKey.GraveAccent);
            ProcessKey(io, ConsoleKey.Oem4, ImGuiKey.LeftBracket);
            ProcessKey(io, ConsoleKey.Oem5, ImGuiKey.Backslash);
            ProcessKey(io, ConsoleKey.Oem6, ImGuiKey.RightBracket);
            ProcessKey(io, ConsoleKey.Oem7, ImGuiKey.Apostrophe);
            ProcessKey(io, ConsoleKey.OemComma, ImGuiKey.Comma);
            ProcessKey(io, ConsoleKey.OemMinus, ImGuiKey.Minus);
            ProcessKey(io, ConsoleKey.OemPeriod, ImGuiKey.Period);
            ProcessKey(io, ConsoleKey.OemPlus, ImGuiKey.Equal);
        }

        /// <summary>
        ///     Processes a single key event.
        /// </summary>
        private static void ProcessKey(ImGuiIoPtr io, ConsoleKey key, ImGuiKey imguiKey)
        {
            if (_platform.IsKeyDown(key))
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
        private static void RunGameLoop(Stopwatch frameTimer, ref double lastTime, double targetFrameTime, ImGuiIoPtr io, IExample example)
        {
            bool running = true;
            while (running)
            {
                double now = frameTimer.Elapsed.TotalSeconds;
                double delta = CalculateDeltaTime(ref lastTime, now, targetFrameTime);
                io.DeltaTime = (float) delta;

                running = _platform.PollEvents();

                ProcessKeyWithImgui();

                ProcessPendingInput();

                example.Draw();
                _platform.SwapBuffers();

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

        private static void ProcessPendingInput()
        {
            if (_platform.TryGetLastInputCharacters(out string pendingChars) && !string.IsNullOrEmpty(pendingChars))
            {
                ImGui.GetIo().AddInputCharactersUtf8(pendingChars);
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