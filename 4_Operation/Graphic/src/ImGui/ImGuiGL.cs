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
using static Alis.Core.Graphic.SDL.SDL;
using static Alis.Core.Graphic.OpenGL.GL;


namespace Alis.Core.Graphic.ImGui
{
    /// <summary>
    ///     The im gui gl class
    /// </summary>
    public static class ImGuiGL
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ImGuiGL"/> class
        /// </summary>
        static ImGuiGL()
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
        public static (IntPtr, IntPtr) CreateWindowAndGLContext(string title, int width, int height, bool fullscreen = false, bool highDpi = false)
        {
            // initialize SDL and set a few defaults for the OpenGL context
            SDL_Init(SDL_INIT_VIDEO);
            SDL_GL_SetAttribute(SDL_GLattr.SDL_GL_CONTEXT_FLAGS, (int) SDL_GLcontext.SDL_GL_CONTEXT_FORWARD_COMPATIBLE_FLAG);
            SDL_GL_SetAttribute(SDL_GLattr.SDL_GL_CONTEXT_PROFILE_MASK, SDL_GLprofile.SDL_GL_CONTEXT_PROFILE_CORE);
            SDL_GL_SetAttribute(SDL_GLattr.SDL_GL_CONTEXT_MAJOR_VERSION, 3);
            SDL_GL_SetAttribute(SDL_GLattr.SDL_GL_CONTEXT_MINOR_VERSION, 2);

            SDL_GL_SetAttribute(SDL_GLattr.SDL_GL_CONTEXT_PROFILE_MASK, SDL_GLprofile.SDL_GL_CONTEXT_PROFILE_CORE);
            SDL_GL_SetAttribute(SDL_GLattr.SDL_GL_DOUBLEBUFFER, 1);
            SDL_GL_SetAttribute(SDL_GLattr.SDL_GL_DEPTH_SIZE, 24);
            SDL_GL_SetAttribute(SDL_GLattr.SDL_GL_ALPHA_SIZE, 8);
            SDL_GL_SetAttribute(SDL_GLattr.SDL_GL_STENCIL_SIZE, 8);

            // create the window which should be able to have a valid OpenGL context and is resizable
            SDL_WindowFlags flags = SDL_WindowFlags.SDL_WINDOW_OPENGL | SDL_WindowFlags.SDL_WINDOW_RESIZABLE;
            if (fullscreen)
            {
                flags |= SDL_WindowFlags.SDL_WINDOW_FULLSCREEN;
            }

            if (highDpi)
            {
                flags |= SDL_WindowFlags.SDL_WINDOW_ALLOW_HIGHDPI;
            }

            IntPtr window = SDL_CreateWindow(title, SDL_WINDOWPOS_CENTERED, SDL_WINDOWPOS_CENTERED, width, height, flags);
            IntPtr glContext = CreateGLContext(window);
            return (window, glContext);
        }

        /// <summary>
        ///     Creates the gl context using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <exception cref="Exception">CouldNotCreateContext</exception>
        /// <returns>The gl context</returns>
        private static IntPtr CreateGLContext(IntPtr window)
        {
            IntPtr glContext = SDL_GL_CreateContext(window);
            if (glContext == IntPtr.Zero)
            {
                throw new Exception("CouldNotCreateContext");
            }

            SDL_GL_MakeCurrent(window, glContext);
            SDL_GL_SetSwapInterval(1);

            // initialize the screen to black as soon as possible
            glClearColor(0f, 0f, 0f, 1f);
            glClear(ClearBufferMask.ColorBufferBit);
            SDL_GL_SwapWindow(window);

            Console.WriteLine($"GL Version: {glGetString(StringName.Version)}");
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
            glPixelStorei(PixelStoreParameter.UnpackAlignment, 1);
            glBindTexture(TextureTarget.Texture2D, textureId);
            glTexImage2D(TextureTarget.Texture2D, 0, internalFormat, width, height, 0, format, PixelType.UnsignedByte, pixelData);
            glTexParameteri(TextureTarget.Texture2D, TextureParameterName.TextureMagFilter, TextureParameter.Linear);
            glTexParameteri(TextureTarget.Texture2D, TextureParameterName.TextureMinFilter, TextureParameter.Linear);
            glBindTexture(TextureTarget.Texture2D, 0);
            return textureId;
        }
    }
}