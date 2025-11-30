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
    ///     The program class
    /// </summary>
    public static class Program
    {
        /// <summary>
        ///     Main the args
        /// </summary>
        /// <param name="args">The args</param>
        public static void Main(string[] args)
        {
            INativePlatform platform;
#if osxarm64 || osxarm || osxx64 || osx || osxarm || osxx64 || osx
            platform = new Alis.Core.Graphic.Platforms.Osx.MacNativePlatform();
#elif winx64 || winx86 || winarm64 || winarm || win
            platform = new Alis.Core.Graphic.Platforms.Win.WinNativePlatform();
#elif linuxx64 || linuxx86 || linuxarm64 || linuxarm || linux
            platform = new Alis.Core.Graphic.Platforms.Linux.LinuxNativePlatform();
#else
            throw new Exception("Sistema operativo no soportado");
#endif

            IExample example = null;

            bool ok = platform.Initialize(800, 600, "C# + OpenGL Platform");
            if (!ok)
            {
                Logger.Info("No se pudo inicializar la ventana ni el contexto OpenGL. El programa se cerrará.");
                platform.Cleanup();
                return;
            }
            
            IntPtr _context = ImGui.CreateContext();
            ImGui.SetCurrentContext(_context);

            platform.MakeContextCurrent();
            Gl.Initialize(platform.GetProcAddress);
            Gl.GlViewport(0, 0, platform.GetWindowWidth(), platform.GetWindowHeight());
            Gl.GlEnable(EnableCap.DepthTest);

            // Crear el ejemplo aquí, después de que el contexto nativo y GL estén listos
            example = new ImguiSample(platform);

            //example.Initialize();
            platform.ShowWindow();
            platform.SetTitle("C# + OpenGL Platform - ImGui");
            
            ImGuiIoPtr io = ImGui.GetIo();
            
            io.DisplaySize = new Vector2F(320, 320);
            
            Logger.Info($@"IMGUI VERSION {ImGui.GetVersion()}");
            
            io.BackendFlags |= ImGuiBackendFlags.RendererHasVtxOffset | ImGuiBackendFlags.PlatformHasViewports | ImGuiBackendFlags.HasGamepad | ImGuiBackendFlags.HasMouseHoveredViewport | ImGuiBackendFlags.HasMouseCursors;


            // Enable Keyboard Controls
            io.ConfigFlags |= ImGuiConfigFlags.NavEnableKeyboard;
            io.ConfigFlags |= ImGuiConfigFlags.NavEnableGamepad;

            // CONFIG DOCKSPACE 
            io.ConfigFlags |= ImGuiConfigFlags.DockingEnable;
            io.ConfigFlags |= ImGuiConfigFlags.ViewportsEnable;
            
            ImNodes.CreateContext();
            ImPlot.CreateContext();
            ImGuizMo.SetImGuiContext(_context);
            ImGui.SetCurrentContext(_context);

            // REBUILD ATLAS
            ImFontAtlasPtr fonts = ImGui.GetIo().Fonts;
            
            int fontSize = 14;
            int fontSizeIcon = 18;
            
            MemoryStream fontFileSolid = AssetRegistry.GetResourceMemoryStreamByName("JetBrainsMono-Bold.ttf");
            IntPtr fontData = Marshal.AllocHGlobal((int) fontFileSolid.Length);
            byte[] fontDataBytes = new byte[fontFileSolid.Length];
            fontFileSolid.ReadExactly(fontDataBytes, 0, (int) fontFileSolid.Length);
            Marshal.Copy(fontDataBytes, 0, fontData, (int) fontFileSolid.Length);
            ImFontPtr fontLoaded16Solid = fonts.AddFontFromMemoryTtf(fontData, fontSize, fontSize);
            
            try
            {
                ImFontConfigPtr iconsConfig = ImGui.ImFontConfig();
                iconsConfig.MergeMode = true;
                iconsConfig.SnapH = true;
                iconsConfig.GlyphMinAdvanceX = 18;

                ushort[] iconRanges = new ushort[3];
                iconRanges[0] = FontAwesome5.IconMin;
                iconRanges[1] = FontAwesome5.IconMax;
                iconRanges[2] = 0;

                // Allocate GCHandle to pin IconRanges in memory
                GCHandle iconRangesHandle = GCHandle.Alloc(iconRanges, GCHandleType.Pinned);

                IntPtr rangePtr = iconRangesHandle.AddrOfPinnedObject();


                MemoryStream fontAwesome = AssetRegistry.GetResourceMemoryStreamByName(FontAwesome5.NameLight);
                IntPtr fontAwesomeData = Marshal.AllocHGlobal((int) fontAwesome.Length);
                byte[] fontAwesomeDataBytes = new byte[fontAwesome.Length];
                fontAwesome.ReadExactly(fontAwesomeDataBytes, 0, (int) fontAwesome.Length);
                Marshal.Copy(fontAwesomeDataBytes, 0, fontAwesomeData, (int) fontAwesome.Length);
                fonts.AddFontFromMemoryTtf(fontAwesomeData, fontSizeIcon, fontSizeIcon, iconsConfig, rangePtr);
            }
            catch (Exception e)
            {
                Logger.Exception(@$"ERROR, FONT ICONS NOT FOUND: {FontAwesome5.NameLight} {e.Message}");
                return;
            }
            
            fonts.GetTexDataAsRgba32(out IntPtr pixelData, out int width, out int height, out int _);
            uint _fontTextureId = LoadTexture(pixelData, width, height);
            fonts.TexId = (IntPtr) _fontTextureId;
            fonts.ClearTexData();
            
            ImGuiViewportPtr viewport = ImGui.GetMainViewport();
            
            ImGuiStyle Style = ImGui.GetStyle();
            ImGui.StyleColorsDark();
            Style.WindowRounding = 0.0f;
            Style.Colors2 = new Vector4F(0.00f, 0.00f, 0.00f, 1.00f);
            
            
            uint _vboHandle = Gl.GenBuffer();
            uint _elementsHandle = Gl.GenBuffer();
            uint _vertexArrayObject = Gl.GenVertexArray();
            
            bool running = true;
            while (running)
            {
                running = platform.PollEvents();
                if (platform.TryGetLastKeyPressed(out ConsoleKey key))
                {
                    Logger.Info($"Tecla pulsada: {key}");
                }
                
                example.Draw();
                platform.SwapBuffers();
                int glError = Gl.GlGetError();
                if (glError != 0)
                {
                    Logger.Info($"OpenGL error tras flushBuffer: 0x{glError:X}");
                }
            }

            example.Cleanup();
            platform.Cleanup();
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
    }
    
    
}