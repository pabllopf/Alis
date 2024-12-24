// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:OpenGlController.cs
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
using Alis.App.Hub.Core;
using Alis.App.Hub.Shaders;
using Alis.Core.Aspect.Logging;
using Alis.Core.Graphic.Sdl2;
using Alis.Extension.Graphic.OpenGL;
using Alis.Extension.Graphic.OpenGL.Constructs;
using Alis.Extension.Graphic.OpenGL.Enums;

namespace Alis.App.Hub.Controllers
{
    /// <summary>
    /// The open gl controller class
    /// </summary>
    /// <seealso cref="AController"/>
    public class OpenGlController : AController
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OpenGlController"/> class
        /// </summary>
        /// <param name="spaceWork">The space work</param>
        public OpenGlController(SpaceWork spaceWork) : base(spaceWork)
        {
        }

        /// <summary>
        /// Ons the init
        /// </summary>
        public override void OnInit()
        {
            SpaceWork.GlContext = CreateGlContext(SpaceWork.WindowHub);
            SpaceWork.GlShader = new GlShaderProgram(VertexShader.ShaderCode, FragmentShader.ShaderCode);
        }

        /// <summary>
        /// Creates the gl context using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <returns>The gl context</returns>
        public IntPtr CreateGlContext(IntPtr window)
        {
            IntPtr glContext = Sdl.CreateContext(window);
            if (glContext == IntPtr.Zero)
            {
                Logger.Exception("Could Not Create GL Context.");
            }

            Sdl.MakeCurrent(window, glContext);
            Sdl.SetSwapInterval(1);
            
            Gl.GlClearColor(0f, 0f, 0f, 1f);
            Gl.GlClear(ClearBufferMask.ColorBufferBit);
            Sdl.SwapWindow(window);

            Logger.Info($"GL Version: {Gl.GlGetString(StringName.Version)}");
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
        public uint LoadTexture(IntPtr pixelData, int width, int height, PixelFormat format = PixelFormat.Rgba, PixelInternalFormat internalFormat = PixelInternalFormat.Rgba)
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
        /// Ons the start
        /// </summary>
        public override void OnStart()
        {
            SpaceWork.VboHandle = Gl.GenBuffer();
            SpaceWork.ElementsHandle = Gl.GenBuffer();
            SpaceWork.VertexArrayObject = Gl.GenVertexArray();
        }

        /// <summary>
        /// Ons the start render
        /// </summary>
        public override void OnStartRender()
        {
            
        }
        
        /// <summary>
        /// Ons the update
        /// </summary>
        public override void OnUpdate()
        {
            
        }

        /// <summary>
        /// Ons the end render
        /// </summary>
        public override void OnEndRender()
        {
            
        }
        
        /// <summary>
        /// Ons the destroy
        /// </summary>
        public override void OnDestroy()
        {
        }
    }
}