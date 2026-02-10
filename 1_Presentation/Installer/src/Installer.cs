// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:Program.cs
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
using Alis.Extension.Graphic.Ui;
using Alis.Extension.Graphic.Ui.Extras.GuizMo;
using Alis.Extension.Graphic.Ui.Extras.Node;
using Alis.Extension.Graphic.Ui.Extras.Plot;
using Alis.Extension.Graphic.Ui.Fonts;

namespace Alis.App.Installer
{
    /// <summary>
    /// Sample host application that creates a native window, initializes OpenGL and ImGui,
    /// and runs the selected example. Code is organized for clarity and maintainability.
    /// </summary>
    public class Installer
    {
        /// <summary>
        /// The platform
        /// </summary>
        private static INativePlatform _platform;
        
        /// <summary>
        /// Application entry point.
        /// </summary>
        public void Run(string[] args)
        {
            // Frame limiter: 60 FPS target
            const double targetFrameTime = 1.0 / 60.0;
            Stopwatch frameTimer = Stopwatch.StartNew();
            double lastTime = frameTimer.Elapsed.TotalSeconds;

            _platform = GetPlatform();
            Debug.Assert(_platform != null, "Platform implementation must be provided for the current OS.");

            // Initialize native window and GL context
            if (!InitializePlatform(_platform, 800, 600, "C# + OpenGL Platform"))
            {
                Logger.Info("Failed to initialize platform or OpenGL context. Exiting.");
                _platform.Cleanup();
                return;
            }

            // Ensure GL API is loaded and viewport configured
            _platform.MakeContextCurrent();
            Gl.Initialize(_platform.GetProcAddress);
            Gl.GlViewport(0, 0, _platform.GetWindowWidth(), _platform.GetWindowHeight());
            Gl.GlEnable(EnableCap.DepthTest);

            // Create ImGui context and configure backends
            IntPtr imguiContext = ImGui.CreateContext();
            ImGui.SetCurrentContext(imguiContext);

            // Create the example instance after GL and ImGui are ready
            IExample example = new ImguiSample(_platform);
            example.Initialize();

            _platform.ShowWindow();
            _platform.SetTitle("C# + OpenGL Platform - ImGui");

            // Configure IO and features
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

            // Initialize optional ImGui extensions
            ImNodes.CreateContext();
            ImPlot.CreateContext();
            ImGuizMo.SetImGuiContext(imguiContext);
            ImGui.SetCurrentContext(imguiContext);

            // Load fonts and create font texture
            ImFontAtlasPtr fonts = ImGui.GetIo().Fonts;

            // Primary font (JetBrainsMono)
            const int fontSize = 14;
            Stream jetBrainsStream = AssetRegistry.GetResourceMemoryStreamByName("JetBrainsMono-Bold.ttf");
            Debug.Assert(jetBrainsStream != null && jetBrainsStream.Length > 0, "Primary font resource not found.");
            IntPtr primaryFontPtr = LoadFontFromResource(jetBrainsStream);

            fonts.AddFontFromMemoryTtf(primaryFontPtr, fontSize, fontSize);

            // Icon font (FontAwesome) - only if resource exists
            const int iconFontSize = 18;
            Stream faStream = AssetRegistry.GetResourceMemoryStreamByName(FontAwesome5.NameLight);
            if (faStream != null && faStream.Length > 0)
            {
                IntPtr iconsPtr = LoadFontFromResource(faStream);

                // Prepare glyph ranges for FontAwesome
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

                // Free the pinned ranges handle immediately; AddFontFromMemoryTtf typically copies the needed data.
                iconRangesHandle.Free();
            }

            // Build font atlas and upload to GL
            fonts.GetTexDataAsRgba32(out IntPtr pixelData, out int texWidth, out int texHeight, out int _);
            uint fontTexId = LoadTexture(pixelData, texWidth, texHeight);
            fonts.TexId = (IntPtr)fontTexId;
            fonts.ClearTexData();

            // Configure style
            ImGuiStyle style = ImGui.GetStyle();
            ImGui.StyleColorsDark();
            style.WindowRounding = 0.0f;
            style.Colors2 = new Vector4F(0.00f, 0.00f, 0.00f, 1.00f);

            // Main loop
            bool running = true;
            while (running)
            {
                // Update delta time for ImGui using high-resolution timer
                double now = frameTimer.Elapsed.TotalSeconds;
                double delta = now - lastTime;
                lastTime = now;
                if (delta <= 0.0)
                {
                    delta = targetFrameTime;
                }

                if (delta > 0.25)
                {
                    delta = 0.25; // avoid huge dt values
                }

                io.DeltaTime = (float)delta;

                running = _platform.PollEvents();

                // Process key states for ImGui every frame (send down/up)
                ProcessKeyWithImgui();

                // If platform provides text input (characters), forward them to ImGui
                if (_platform.TryGetLastInputCharacters(out string pendingChars) && !string.IsNullOrEmpty(pendingChars))
                {
                    ImGui.GetIo().AddInputCharactersUtf8(pendingChars);
                }

                example.Draw();
                _platform.SwapBuffers();

                int glError = Gl.GlGetError();
                if (glError != 0)
                {
                    Logger.Info($"OpenGL error after SwapBuffers: 0x{glError:X}");
                }

                // Frame pacing: sleep / spin until target frame time reached
                double frameEnd = frameTimer.Elapsed.TotalSeconds;
                double frameElapsed = frameEnd - now;
                double sleepTime = targetFrameTime - frameElapsed;
                if (sleepTime > 0.0)
                {
                    int sleepMs = (int)(sleepTime * 1000.0);
                    if (sleepMs > 0)
                    {
                        // Sleep most of the remaining time (leave small margin for precision)
                        Thread.Sleep(sleepMs);
                    }
                    // Busy-wait the rest for better precision
                    while (frameTimer.Elapsed.TotalSeconds - now < targetFrameTime)
                    {
                        Thread.SpinWait(10);
                    }
                }
            }

            // Cleanup
            example.Cleanup();
            _platform.Cleanup();
        }

        /// <summary>
        /// Processes the key with imgui
        /// </summary>
        private static void ProcessKeyWithImgui()
        {
            ImGuiIoPtr io = ImGui.GetIo();
            
            // Control y edición
            if (_platform.IsKeyDown(ConsoleKey.Backspace))
            {
                io.AddKeyEvent(ImGuiKey.Backspace, true);
            }
            else
            {
                io.AddKeyEvent(ImGuiKey.Backspace, false);
            }

            if (_platform.IsKeyDown(ConsoleKey.Tab))
            {
                io.AddKeyEvent(ImGuiKey.Tab, true);
            }
            else
            {
                io.AddKeyEvent(ImGuiKey.Tab, false);
            }

            if (_platform.IsKeyDown(ConsoleKey.Enter))
            {
                io.AddKeyEvent(ImGuiKey.Enter, true);
            }
            else
            {
                io.AddKeyEvent(ImGuiKey.Enter, false);
            }

            if (_platform.IsKeyDown(ConsoleKey.Pause))
            {
                io.AddKeyEvent(ImGuiKey.Pause, true);
            }
            else
            {
                io.AddKeyEvent(ImGuiKey.Pause, false);
            }

            if (_platform.IsKeyDown(ConsoleKey.PrintScreen))
            {
                io.AddKeyEvent(ImGuiKey.PrintScreen, true);
            }
            else
            {
                io.AddKeyEvent(ImGuiKey.PrintScreen, false);
            }

            if (_platform.IsKeyDown(ConsoleKey.Escape))
            {
                io.AddKeyEvent(ImGuiKey.Escape, true);
            }
            else
            {
                io.AddKeyEvent(ImGuiKey.Escape, false);
            }

            if (_platform.IsKeyDown(ConsoleKey.Spacebar))
            {
                io.AddKeyEvent(ImGuiKey.Space, true);
            }
            else
            {
                io.AddKeyEvent(ImGuiKey.Space, false);
            }

            if (_platform.IsKeyDown(ConsoleKey.PageUp))
            {
                io.AddKeyEvent(ImGuiKey.PageUp, true);
            }
            else
            {
                io.AddKeyEvent(ImGuiKey.PageUp, false);
            }

            if (_platform.IsKeyDown(ConsoleKey.PageDown))
            {
                io.AddKeyEvent(ImGuiKey.PageDown, true);
            }
            else
            {
                io.AddKeyEvent(ImGuiKey.PageDown, false);
            }

            if (_platform.IsKeyDown(ConsoleKey.End))
            {
                io.AddKeyEvent(ImGuiKey.End, true);
            }
            else
            {
                io.AddKeyEvent(ImGuiKey.End, false);
            }

            if (_platform.IsKeyDown(ConsoleKey.Home))
            {
                io.AddKeyEvent(ImGuiKey.Home, true);
            }
            else
            {
                io.AddKeyEvent(ImGuiKey.Home, false);
            }

            if (_platform.IsKeyDown(ConsoleKey.Insert))
            {
                io.AddKeyEvent(ImGuiKey.Insert, true);
            }
            else
            {
                io.AddKeyEvent(ImGuiKey.Insert, false);
            }

            if (_platform.IsKeyDown(ConsoleKey.Delete))
            {
                io.AddKeyEvent(ImGuiKey.Delete, true);
            }
            else
            {
                io.AddKeyEvent(ImGuiKey.Delete, false);
            }

            // Flechas
            if (_platform.IsKeyDown(ConsoleKey.LeftArrow))
            {
                io.AddKeyEvent(ImGuiKey.LeftArrow, true);
            }
            else
            {
                io.AddKeyEvent(ImGuiKey.LeftArrow, false);
            }

            if (_platform.IsKeyDown(ConsoleKey.UpArrow))
            {
                io.AddKeyEvent(ImGuiKey.UpArrow, true);
            }
            else
            {
                io.AddKeyEvent(ImGuiKey.UpArrow, false);
            }

            if (_platform.IsKeyDown(ConsoleKey.RightArrow))
            {
                io.AddKeyEvent(ImGuiKey.RightArrow, true);
            }
            else
            {
                io.AddKeyEvent(ImGuiKey.RightArrow, false);
            }

            if (_platform.IsKeyDown(ConsoleKey.DownArrow))
            {
                io.AddKeyEvent(ImGuiKey.DownArrow, true);
            }
            else
            {
                io.AddKeyEvent(ImGuiKey.DownArrow, false);
            }

            // Números fila superior
            if (_platform.IsKeyDown(ConsoleKey.D0))
            {
                io.AddKeyEvent(ImGuiKey._0, true);
            }
            else
            {
                io.AddKeyEvent(ImGuiKey._0, false);
            }

            if (_platform.IsKeyDown(ConsoleKey.D1))
            {
                io.AddKeyEvent(ImGuiKey._1, true);
            }
            else
            {
                io.AddKeyEvent(ImGuiKey._1, false);
            }

            if (_platform.IsKeyDown(ConsoleKey.D2))
            {
                io.AddKeyEvent(ImGuiKey._2, true);
            }
            else
            {
                io.AddKeyEvent(ImGuiKey._2, false);
            }

            if (_platform.IsKeyDown(ConsoleKey.D3))
            {
                io.AddKeyEvent(ImGuiKey._3, true);
            }
            else
            {
                io.AddKeyEvent(ImGuiKey._3, false);
            }

            if (_platform.IsKeyDown(ConsoleKey.D4))
            {
                io.AddKeyEvent(ImGuiKey._4, true);
            }
            else
            {
                io.AddKeyEvent(ImGuiKey._4, false);
            }

            if (_platform.IsKeyDown(ConsoleKey.D5))
            {
                io.AddKeyEvent(ImGuiKey._5, true);
            }
            else
            {
                io.AddKeyEvent(ImGuiKey._5, false);
            }

            if (_platform.IsKeyDown(ConsoleKey.D6))
            {
                io.AddKeyEvent(ImGuiKey._6, true);
            }
            else
            {
                io.AddKeyEvent(ImGuiKey._6, false);
            }

            if (_platform.IsKeyDown(ConsoleKey.D7))
            {
                io.AddKeyEvent(ImGuiKey._7, true);
            }
            else
            {
                io.AddKeyEvent(ImGuiKey._7, false);
            }

            if (_platform.IsKeyDown(ConsoleKey.D8))
            {
                io.AddKeyEvent(ImGuiKey._8, true);
            }
            else
            {
                io.AddKeyEvent(ImGuiKey._8, false);
            }

            if (_platform.IsKeyDown(ConsoleKey.D9))
            {
                io.AddKeyEvent(ImGuiKey._9, true);
            }
            else
            {
                io.AddKeyEvent(ImGuiKey._9, false);
            }

            // Letras A-Z
            if (_platform.IsKeyDown(ConsoleKey.A))
            {
                io.AddKeyEvent(ImGuiKey.A, true);
            }
            else
            {
                io.AddKeyEvent(ImGuiKey.A, false);
            }

            if (_platform.IsKeyDown(ConsoleKey.B))
            {
                io.AddKeyEvent(ImGuiKey.B, true);
            }
            else
            {
                io.AddKeyEvent(ImGuiKey.B, false);
            }

            if (_platform.IsKeyDown(ConsoleKey.C))
            {
                io.AddKeyEvent(ImGuiKey.C, true);
            }
            else
            {
                io.AddKeyEvent(ImGuiKey.C, false);
            }

            if (_platform.IsKeyDown(ConsoleKey.D))
            {
                io.AddKeyEvent(ImGuiKey.D, true);
            }
            else
            {
                io.AddKeyEvent(ImGuiKey.D, false);
            }

            if (_platform.IsKeyDown(ConsoleKey.E))
            {
                io.AddKeyEvent(ImGuiKey.E, true);
            }
            else
            {
                io.AddKeyEvent(ImGuiKey.E, false);
            }

            if (_platform.IsKeyDown(ConsoleKey.F))
            {
                io.AddKeyEvent(ImGuiKey.F, true);
            }
            else
            {
                io.AddKeyEvent(ImGuiKey.F, false);
            }

            if (_platform.IsKeyDown(ConsoleKey.G))
            {
                io.AddKeyEvent(ImGuiKey.G, true);
            }
            else
            {
                io.AddKeyEvent(ImGuiKey.G, false);
            }

            if (_platform.IsKeyDown(ConsoleKey.H))
            {
                io.AddKeyEvent(ImGuiKey.H, true);
            }
            else
            {
                io.AddKeyEvent(ImGuiKey.H, false);
            }

            if (_platform.IsKeyDown(ConsoleKey.I))
            {
                io.AddKeyEvent(ImGuiKey.I, true);
            }
            else
            {
                io.AddKeyEvent(ImGuiKey.I, false);
            }

            if (_platform.IsKeyDown(ConsoleKey.J))
            {
                io.AddKeyEvent(ImGuiKey.J, true);
            }
            else
            {
                io.AddKeyEvent(ImGuiKey.J, false);
            }

            if (_platform.IsKeyDown(ConsoleKey.K))
            {
                io.AddKeyEvent(ImGuiKey.K, true);
            }
            else
            {
                io.AddKeyEvent(ImGuiKey.K, false);
            }

            if (_platform.IsKeyDown(ConsoleKey.L))
            {
                io.AddKeyEvent(ImGuiKey.L, true);
            }
            else
            {
                io.AddKeyEvent(ImGuiKey.L, false);
            }

            if (_platform.IsKeyDown(ConsoleKey.M))
            {
                io.AddKeyEvent(ImGuiKey.M, true);
            }
            else
            {
                io.AddKeyEvent(ImGuiKey.M, false);
            }

            if (_platform.IsKeyDown(ConsoleKey.N))
            {
                io.AddKeyEvent(ImGuiKey.N, true);
            }
            else
            {
                io.AddKeyEvent(ImGuiKey.N, false);
            }

            if (_platform.IsKeyDown(ConsoleKey.O))
            {
                io.AddKeyEvent(ImGuiKey.O, true);
            }
            else
            {
                io.AddKeyEvent(ImGuiKey.O, false);
            }

            if (_platform.IsKeyDown(ConsoleKey.P))
            {
                io.AddKeyEvent(ImGuiKey.P, true);
            }
            else
            {
                io.AddKeyEvent(ImGuiKey.P, false);
            }

            if (_platform.IsKeyDown(ConsoleKey.Q))
            {
                io.AddKeyEvent(ImGuiKey.Q, true);
            }
            else
            {
                io.AddKeyEvent(ImGuiKey.Q, false);
            }

            if (_platform.IsKeyDown(ConsoleKey.R))
            {
                io.AddKeyEvent(ImGuiKey.R, true);
            }
            else
            {
                io.AddKeyEvent(ImGuiKey.R, false);
            }

            if (_platform.IsKeyDown(ConsoleKey.S))
            {
                io.AddKeyEvent(ImGuiKey.S, true);
            }
            else
            {
                io.AddKeyEvent(ImGuiKey.S, false);
            }

            if (_platform.IsKeyDown(ConsoleKey.T))
            {
                io.AddKeyEvent(ImGuiKey.T, true);
            }
            else
            {
                io.AddKeyEvent(ImGuiKey.T, false);
            }

            if (_platform.IsKeyDown(ConsoleKey.U))
            {
                io.AddKeyEvent(ImGuiKey.U, true);
            }
            else
            {
                io.AddKeyEvent(ImGuiKey.U, false);
            }

            if (_platform.IsKeyDown(ConsoleKey.V))
            {
                io.AddKeyEvent(ImGuiKey.V, true);
            }
            else
            {
                io.AddKeyEvent(ImGuiKey.V, false);
            }

            if (_platform.IsKeyDown(ConsoleKey.W))
            {
                io.AddKeyEvent(ImGuiKey.W, true);
            }
            else
            {
                io.AddKeyEvent(ImGuiKey.W, false);
            }

            if (_platform.IsKeyDown(ConsoleKey.X))
            {
                io.AddKeyEvent(ImGuiKey.X, true);
            }
            else
            {
                io.AddKeyEvent(ImGuiKey.X, false);
            }

            if (_platform.IsKeyDown(ConsoleKey.Y))
            {
                io.AddKeyEvent(ImGuiKey.Y, true);
            }
            else
            {
                io.AddKeyEvent(ImGuiKey.Y, false);
            }

            if (_platform.IsKeyDown(ConsoleKey.Z))
            {
                io.AddKeyEvent(ImGuiKey.Z, true);
            }
            else
            {
                io.AddKeyEvent(ImGuiKey.Z, false);
            }

            // Teclas de función
            if (_platform.IsKeyDown(ConsoleKey.F1))
            {
                io.AddKeyEvent(ImGuiKey.F1, true);
            }
            else
            {
                io.AddKeyEvent(ImGuiKey.F1, false);
            }

            if (_platform.IsKeyDown(ConsoleKey.F2))
            {
                io.AddKeyEvent(ImGuiKey.F2, true);
            }
            else
            {
                io.AddKeyEvent(ImGuiKey.F2, false);
            }

            if (_platform.IsKeyDown(ConsoleKey.F3))
            {
                io.AddKeyEvent(ImGuiKey.F3, true);
            }
            else
            {
                io.AddKeyEvent(ImGuiKey.F3, false);
            }

            if (_platform.IsKeyDown(ConsoleKey.F4))
            {
                io.AddKeyEvent(ImGuiKey.F4, true);
            }
            else
            {
                io.AddKeyEvent(ImGuiKey.F4, false);
            }

            if (_platform.IsKeyDown(ConsoleKey.F5))
            {
                io.AddKeyEvent(ImGuiKey.F5, true);
            }
            else
            {
                io.AddKeyEvent(ImGuiKey.F5, false);
            }

            if (_platform.IsKeyDown(ConsoleKey.F6))
            {
                io.AddKeyEvent(ImGuiKey.F6, true);
            }
            else
            {
                io.AddKeyEvent(ImGuiKey.F6, false);
            }

            if (_platform.IsKeyDown(ConsoleKey.F7))
            {
                io.AddKeyEvent(ImGuiKey.F7, true);
            }
            else
            {
                io.AddKeyEvent(ImGuiKey.F7, false);
            }

            if (_platform.IsKeyDown(ConsoleKey.F8))
            {
                io.AddKeyEvent(ImGuiKey.F8, true);
            }
            else
            {
                io.AddKeyEvent(ImGuiKey.F8, false);
            }

            if (_platform.IsKeyDown(ConsoleKey.F9))
            {
                io.AddKeyEvent(ImGuiKey.F9, true);
            }
            else
            {
                io.AddKeyEvent(ImGuiKey.F9, false);
            }

            if (_platform.IsKeyDown(ConsoleKey.F10))
            {
                io.AddKeyEvent(ImGuiKey.F10, true);
            }
            else
            {
                io.AddKeyEvent(ImGuiKey.F10, false);
            }

            if (_platform.IsKeyDown(ConsoleKey.F11))
            {
                io.AddKeyEvent(ImGuiKey.F11, true);
            }
            else
            {
                io.AddKeyEvent(ImGuiKey.F11, false);
            }

            if (_platform.IsKeyDown(ConsoleKey.F12))
            {
                io.AddKeyEvent(ImGuiKey.F12, true);
            }
            else
            {
                io.AddKeyEvent(ImGuiKey.F12, false);
            }

            // Teclado numérico
            if (_platform.IsKeyDown(ConsoleKey.NumPad0))
            {
                io.AddKeyEvent(ImGuiKey.Keypad0, true);
            }
            else
            {
                io.AddKeyEvent(ImGuiKey.Keypad0, false);
            }

            if (_platform.IsKeyDown(ConsoleKey.NumPad1))
            {
                io.AddKeyEvent(ImGuiKey.Keypad1, true);
            }
            else
            {
                io.AddKeyEvent(ImGuiKey.Keypad1, false);
            }

            if (_platform.IsKeyDown(ConsoleKey.NumPad2))
            {
                io.AddKeyEvent(ImGuiKey.Keypad2, true);
            }
            else
            {
                io.AddKeyEvent(ImGuiKey.Keypad2, false);
            }

            if (_platform.IsKeyDown(ConsoleKey.NumPad3))
            {
                io.AddKeyEvent(ImGuiKey.Keypad3, true);
            }
            else
            {
                io.AddKeyEvent(ImGuiKey.Keypad3, false);
            }

            if (_platform.IsKeyDown(ConsoleKey.NumPad4))
            {
                io.AddKeyEvent(ImGuiKey.Keypad4, true);
            }
            else
            {
                io.AddKeyEvent(ImGuiKey.Keypad4, false);
            }

            if (_platform.IsKeyDown(ConsoleKey.NumPad5))
            {
                io.AddKeyEvent(ImGuiKey.Keypad5, true);
            }
            else
            {
                io.AddKeyEvent(ImGuiKey.Keypad5, false);
            }

            if (_platform.IsKeyDown(ConsoleKey.NumPad6))
            {
                io.AddKeyEvent(ImGuiKey.Keypad6, true);
            }
            else
            {
                io.AddKeyEvent(ImGuiKey.Keypad6, false);
            }

            if (_platform.IsKeyDown(ConsoleKey.NumPad7))
            {
                io.AddKeyEvent(ImGuiKey.Keypad7, true);
            }
            else
            {
                io.AddKeyEvent(ImGuiKey.Keypad7, false);
            }

            if (_platform.IsKeyDown(ConsoleKey.NumPad8))
            {
                io.AddKeyEvent(ImGuiKey.Keypad8, true);
            }
            else
            {
                io.AddKeyEvent(ImGuiKey.Keypad8, false);
            }

            if (_platform.IsKeyDown(ConsoleKey.NumPad9))
            {
                io.AddKeyEvent(ImGuiKey.Keypad9, true);
            }
            else
            {
                io.AddKeyEvent(ImGuiKey.Keypad9, false);
            }

            if (_platform.IsKeyDown(ConsoleKey.Multiply))
            {
                io.AddKeyEvent(ImGuiKey.KeypadMultiply, true);
            }
            else
            {
                io.AddKeyEvent(ImGuiKey.KeypadMultiply, false);
            }

            if (_platform.IsKeyDown(ConsoleKey.Add))
            {
                io.AddKeyEvent(ImGuiKey.KeypadAdd, true);
            }
            else
            {
                io.AddKeyEvent(ImGuiKey.KeypadAdd, false);
            }

            if (_platform.IsKeyDown(ConsoleKey.Subtract))
            {
                io.AddKeyEvent(ImGuiKey.KeypadSubtract, true);
            }
            else
            {
                io.AddKeyEvent(ImGuiKey.KeypadSubtract, false);
            }

            if (_platform.IsKeyDown(ConsoleKey.Decimal))
            {
                io.AddKeyEvent(ImGuiKey.KeypadDecimal, true);
            }
            else
            {
                io.AddKeyEvent(ImGuiKey.KeypadDecimal, false);
            }

            if (_platform.IsKeyDown(ConsoleKey.Divide))
            {
                io.AddKeyEvent(ImGuiKey.KeypadDivide, true);
            }
            else
            {
                io.AddKeyEvent(ImGuiKey.KeypadDivide, false);
            }

            // Puntuación / OEM
            if (_platform.IsKeyDown(ConsoleKey.Oem1))
            {
                io.AddKeyEvent(ImGuiKey.Semicolon, true);
            }
            else
            {
                io.AddKeyEvent(ImGuiKey.Semicolon, false);
            }

            if (_platform.IsKeyDown(ConsoleKey.Oem2))
            {
                io.AddKeyEvent(ImGuiKey.Slash, true);
            }
            else
            {
                io.AddKeyEvent(ImGuiKey.Slash, false);
            }

            if (_platform.IsKeyDown(ConsoleKey.Oem3))
            {
                io.AddKeyEvent(ImGuiKey.GraveAccent, true);
            }
            else
            {
                io.AddKeyEvent(ImGuiKey.GraveAccent, false);
            }

            if (_platform.IsKeyDown(ConsoleKey.Oem4))
            {
                io.AddKeyEvent(ImGuiKey.LeftBracket, true);
            }
            else
            {
                io.AddKeyEvent(ImGuiKey.LeftBracket, false);
            }

            if (_platform.IsKeyDown(ConsoleKey.Oem5))
            {
                io.AddKeyEvent(ImGuiKey.Backslash, true);
            }
            else
            {
                io.AddKeyEvent(ImGuiKey.Backslash, false);
            }

            if (_platform.IsKeyDown(ConsoleKey.Oem6))
            {
                io.AddKeyEvent(ImGuiKey.RightBracket, true);
            }
            else
            {
                io.AddKeyEvent(ImGuiKey.RightBracket, false);
            }

            if (_platform.IsKeyDown(ConsoleKey.Oem7))
            {
                io.AddKeyEvent(ImGuiKey.Apostrophe, true);
            }
            else
            {
                io.AddKeyEvent(ImGuiKey.Apostrophe, false);
            }

            if (_platform.IsKeyDown(ConsoleKey.OemComma))
            {
                io.AddKeyEvent(ImGuiKey.Comma, true);
            }
            else
            {
                io.AddKeyEvent(ImGuiKey.Comma, false);
            }

            if (_platform.IsKeyDown(ConsoleKey.OemMinus))
            {
                io.AddKeyEvent(ImGuiKey.Minus, true);
            }
            else
            {
                io.AddKeyEvent(ImGuiKey.Minus, false);
            }

            if (_platform.IsKeyDown(ConsoleKey.OemPeriod))
            {
                io.AddKeyEvent(ImGuiKey.Period, true);
            }
            else
            {
                io.AddKeyEvent(ImGuiKey.Period, false);
            }

            if (_platform.IsKeyDown(ConsoleKey.OemPlus))
            {
                io.AddKeyEvent(ImGuiKey.Equal, true);
            }
            else
            {
                io.AddKeyEvent(ImGuiKey.Equal, false);
            }
        }

        // Returns the appropriate platform implementation for the current OS.
        /// <summary>
        /// Gets the platform
        /// </summary>
        /// <returns>The native platform</returns>
        private static INativePlatform GetPlatform()
        {
#if osxarm64 || osxarm || osxx64 || osx || osxarm || osxx64 || osx
            return new Alis.Core.Graphic.Platforms.Osx.MacNativePlatform();
#elif winx64 || winx86 || winarm64 || winarm || win
            return new Alis.Core.Graphic.Platforms.Win.WinNativePlatform();
#elif linuxx64 || linuxx86 || linuxarm64 || linuxarm || linux
            return new Alis.Core.Graphic.Platforms.Linux.LinuxNativePlatform();
#else
            return null;
#endif
        }

        // Initializes the native platform and OpenGL context. Returns true on success.
        /// <summary>
        /// Initializes the platform using the specified plat
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

        // Loads a font from an input stream into unmanaged memory and returns the IntPtr to the data buffer.
        // Note: The caller is responsible for memory lifetime if the native API expects it to remain valid.
        /// <summary>
        /// Loads the font from resource using the specified stream
        /// </summary>
        /// <param name="stream">The stream</param>
        /// <returns>The native ptr</returns>
        private static IntPtr LoadFontFromResource(Stream stream) {
            Debug.Assert(stream != null && stream.Length > 0, "Font stream must be valid.");

            byte[] data = new byte[stream.Length];
            stream.ReadExactly(data, 0, (int)stream.Length);
            IntPtr nativePtr = Marshal.AllocHGlobal(data.Length);
            Marshal.Copy(data, 0, nativePtr, data.Length);
            return nativePtr;
        }

        // Loads the texture using the specified pixel data (RGBA8) and returns the GL texture id.
        /// <summary>
        /// Loads the texture using the specified pixel data
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
    }
}

