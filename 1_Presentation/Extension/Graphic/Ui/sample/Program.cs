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
using System.IO;
using System.Runtime.InteropServices;
using System.Diagnostics;
using Alis.Core.Aspect.Logging;
using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Aspect.Memory;
using Alis.Core.Graphic.OpenGL;
using Alis.Core.Graphic.OpenGL.Enums;
using Alis.Core.Graphic.Platforms;
using Alis.Extension.Graphic.Ui.Extras.GuizMo;
using Alis.Extension.Graphic.Ui.Extras.Node;
using Alis.Extension.Graphic.Ui.Extras.Plot;
using Alis.Extension.Graphic.Ui.Fonts;
using Alis.Extension.Graphic.Ui.Sample.Examples;

namespace Alis.Extension.Graphic.Ui.Sample
{
    /// <summary>
    /// Sample host application that creates a native window, initializes OpenGL and ImGui,
    /// and runs the selected example. Code is organized for clarity and maintainability.
    /// </summary>
    public static class Program
    {
        /// <summary>
        /// Application entry point.
        /// </summary>
        public static void Main(string[] args)
        {
            INativePlatform platform = GetPlatform();
            Debug.Assert(platform != null, "Platform implementation must be provided for the current OS.");

            // Initialize native window and GL context
            if (!InitializePlatform(platform, 800, 600, "C# + OpenGL Platform"))
            {
                Logger.Info("Failed to initialize platform or OpenGL context. Exiting.");
                platform?.Cleanup();
                return;
            }

            // Ensure GL API is loaded and viewport configured
            platform.MakeContextCurrent();
            Gl.Initialize(platform.GetProcAddress);
            Gl.GlViewport(0, 0, platform.GetWindowWidth(), platform.GetWindowHeight());
            Gl.GlEnable(EnableCap.DepthTest);

            // Create ImGui context and configure backends
            IntPtr imguiContext = ImGui.CreateContext();
            ImGui.SetCurrentContext(imguiContext);

            // Create the example instance after GL and ImGui are ready
            IExample example = new ImguiSample(platform);
            example.Initialize();

            platform.ShowWindow();
            platform.SetTitle("C# + OpenGL Platform - ImGui");

            // Configure IO and features
            ImGuiIoPtr io = ImGui.GetIo();
            io.DisplaySize = new Vector2F(platform.GetWindowWidth(), platform.GetWindowHeight());

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
            IntPtr primaryFontPtr = LoadFontFromResource(jetBrainsStream, fontSize);
            ImFontPtr fontLoaded = fonts.AddFontFromMemoryTtf(primaryFontPtr, fontSize, fontSize);

            // Icon font (FontAwesome) - only if resource exists
            const int iconFontSize = 18;
            Stream faStream = AssetRegistry.GetResourceMemoryStreamByName(FontAwesome5.NameLight);
            if (faStream != null && faStream.Length > 0)
            {
                IntPtr iconsPtr = LoadFontFromResource(faStream, iconFontSize);

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
                running = platform.PollEvents();

                if (platform.TryGetLastKeyPressed(out ConsoleKey key))
                {
                    Logger.Info($"Key pressed: {key}");
                }

                example.Draw();
                platform.SwapBuffers();

                int glError = Gl.GlGetError();
                if (glError != 0)
                {
                    Logger.Info($"OpenGL error after SwapBuffers: 0x{glError:X}");
                }
            }

            // Cleanup
            example.Cleanup();
            platform.Cleanup();
        }

        // Returns the appropriate platform implementation for the current OS.
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
        private static bool InitializePlatform(INativePlatform platform, int width, int height, string title)
        {
            if (platform == null) return false;
            bool ok = platform.Initialize(width, height, title);
            if (!ok)
            {
                Logger.Info("Failed to create native window / OpenGL context.");
                return false;
            }

            return true;
        }

        // Loads a font from an input stream into unmanaged memory and returns the IntPtr to the data buffer.
        // Note: The caller is responsible for memory lifetime if the native API expects it to remain valid.
        private static IntPtr LoadFontFromResource(Stream stream, int size)
        {
            Debug.Assert(stream != null && stream.Length > 0, "Font stream must be valid.");

            byte[] data = new byte[stream.Length];
            stream.ReadExactly(data, 0, (int)stream.Length);
            IntPtr nativePtr = Marshal.AllocHGlobal(data.Length);
            Marshal.Copy(data, 0, nativePtr, data.Length);
            return nativePtr;
        }

        // Loads the texture using the specified pixel data (RGBA8) and returns the GL texture id.
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

