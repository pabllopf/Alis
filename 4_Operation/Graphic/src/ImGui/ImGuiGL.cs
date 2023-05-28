// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImGuiGL.cs
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
using System.Runtime.InteropServices;
using Alis.Core.Aspect.Base.Dll;
using Alis.Core.Graphic.Properties;
using static Alis.Core.Graphic.SDL.Sdl;
using static Alis.Core.Graphic.OpenGL.Gl;


namespace Alis.Core.Graphic.ImGui
{
    /// <summary>
    ///     The im gui gl class
    /// </summary>
    public static class ImGuiGl
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ImGuiGl"/> class
        /// </summary>
        static ImGuiGl()
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
            {
                switch (RuntimeInformation.ProcessArchitecture)
                {
                    case Architecture.Arm64:
                        EmbeddedDllClass.ExtractEmbeddedDlls("cimgui.dylib", NativeGraphic.osx_arm64_cimgui);
                        break;
                    case Architecture.X64:
                        EmbeddedDllClass.ExtractEmbeddedDlls("cimgui.dylib", NativeGraphic.osx_x64_cimgui);
                        break;
                }
            }

            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                switch (RuntimeInformation.ProcessArchitecture)
                {
                    case Architecture.Arm64:
                        EmbeddedDllClass.ExtractEmbeddedDlls("cimgui.dll", NativeGraphic.win_arm64_cimgui);
                        break;
                    case Architecture.X86:
                        EmbeddedDllClass.ExtractEmbeddedDlls("cimgui.dll", NativeGraphic.win_x86_cimgui);
                        break;
                    case Architecture.X64:
                        EmbeddedDllClass.ExtractEmbeddedDlls("cimgui.dll", NativeGraphic.win_x64_cimgui);
                        break;
                }
            }

            if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            {
                switch (RuntimeInformation.ProcessArchitecture)
                {
                    case Architecture.Arm64:
                        EmbeddedDllClass.ExtractEmbeddedDlls("cimgui.so", NativeGraphic.linux_arm64_cimgui);
                        break;
                    case Architecture.X64:
                        EmbeddedDllClass.ExtractEmbeddedDlls("cimgui.so", NativeGraphic.linux_x64_cimgui);
                        break;
                }
            }
        }

        /// <summary>
        ///     Creates the window and gl context using the specified title
        /// </summary>
        /// <param name="title">The title</param>
        /// <param name="width">The width</param>
        /// <param name="height">The height</param>
        /// <param name="fullscreen">The fullscreen</param>
        /// <param name="highDpi">The high dpi</param>
        /// <returns>The int ptr int ptr</returns>
        public static (IntPtr, IntPtr) CreateWindowAndGlContext(string title, int width, int height, bool fullscreen = false, bool highDpi = false)
        {
            // initialize SDL and set a few defaults for the OpenGL context
            SDL_Init(SdlInitVideo);
            SDL_GL_SetAttribute(SdlGLattr.SdlGlContextFlags, (int) SdlGLcontext.SdlGlContextForwardCompatibleFlag);
            SDL_GL_SetAttribute(SdlGLattr.SdlGlContextProfileMask, SdlGLprofile.SdlGlContextProfileCore);
            SDL_GL_SetAttribute(SdlGLattr.SdlGlContextMajorVersion, 3);
            SDL_GL_SetAttribute(SdlGLattr.SdlGlContextMinorVersion, 2);

            SDL_GL_SetAttribute(SdlGLattr.SdlGlContextProfileMask, SdlGLprofile.SdlGlContextProfileCore);
            SDL_GL_SetAttribute(SdlGLattr.SdlGlDoublebuffer, 1);
            SDL_GL_SetAttribute(SdlGLattr.SdlGlDepthSize, 24);
            SDL_GL_SetAttribute(SdlGLattr.SdlGlAlphaSize, 8);
            SDL_GL_SetAttribute(SdlGLattr.SdlGlStencilSize, 8);

            // create the window which should be able to have a valid OpenGL context and is resizable
            SdlWindowFlags flags = SdlWindowFlags.SdlWindowOpengl | SdlWindowFlags.SdlWindowResizable;
            if (fullscreen)
            {
                flags |= SdlWindowFlags.SdlWindowFullscreen;
            }

            if (highDpi)
            {
                flags |= SdlWindowFlags.SdlWindowAllowHighdpi;
            }

            IntPtr window = SDL_CreateWindow(title, SdlWindowposCentered, SdlWindowposCentered, width, height, flags);
            IntPtr glContext = CreateGlContext(window);
            return (window, glContext);
        }

        /// <summary>
        ///     Creates the gl context using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <exception cref="Exception">CouldNotCreateContext</exception>
        /// <returns>The gl context</returns>
        private static IntPtr CreateGlContext(IntPtr window)
        {
            IntPtr glContext = SDL_GL_CreateContext(window);
            if (glContext == IntPtr.Zero)
            {
                throw new Exception("CouldNotCreateContext");
            }

            SDL_GL_MakeCurrent(window, glContext);
            SDL_GL_SetSwapInterval(1);

            // initialize the screen to black as soon as possible
            GlClearColor(0f, 0f, 0f, 1f);
            GlClear(ClearBufferMask.ColorBufferBit);
            SDL_GL_SwapWindow(window);

            Console.WriteLine($"GL Version: {GlGetString(StringName.Version)}");
            return glContext;
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
        public static uint LoadTexture(IntPtr pixelData, int width, int height, PixelFormat format = PixelFormat.Rgba, PixelInternalFormat internalFormat = PixelInternalFormat.Rgba)
        {
            uint textureId = GenTexture();
            GlPixelStorei(PixelStoreParameter.UnpackAlignment, 1);
            GlBindTexture(TextureTarget.Texture2D, textureId);
            GlTexImage2D(TextureTarget.Texture2D, 0, internalFormat, width, height, 0, format, PixelType.UnsignedByte, pixelData);
            GlTexParameteri(TextureTarget.Texture2D, TextureParameterName.TextureMagFilter, TextureParameter.Linear);
            GlTexParameteri(TextureTarget.Texture2D, TextureParameterName.TextureMinFilter, TextureParameter.Linear);
            GlBindTexture(TextureTarget.Texture2D, 0);
            return textureId;
        }
    }
}