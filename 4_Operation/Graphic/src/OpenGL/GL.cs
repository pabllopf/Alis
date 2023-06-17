// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:GL.cs
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
using System.Text;
using Alis.Core.Graphic.OpenGL.Delegates;
using Alis.Core.Graphic.OpenGL.Enums;
using Alis.Core.Graphic.SDL;

namespace Alis.Core.Graphic.OpenGL
{
    /// <summary>
    ///     The gl class
    /// </summary>
    public static partial class Gl
    {
        /// <summary>
        ///     The get string
        /// </summary>
        private static GetString _getString = _<GetString>("glGetString");

        /// <summary>
        ///     The gen buffers
        /// </summary>
        private static readonly GenBuffers GlGenBuffers = _<GenBuffers>("glGenBuffers");

        /// <summary>
        ///     The delete buffers
        /// </summary>
        private static readonly DeleteBuffers GlDeleteBuffers = _<DeleteBuffers>("glDeleteBuffers");

        /// <summary>
        ///     The viewport
        /// </summary>
        public static readonly Viewport GlViewport = _<Viewport>("glViewport");

        /// <summary>
        ///     The clear color
        /// </summary>
        public static readonly ClearColor GlClearColor = _<ClearColor>("glClearColor");

        /// <summary>
        ///     The clear
        /// </summary>
        public static readonly Clear GlClear = _<Clear>("glClear");

        /// <summary>
        ///     The enable
        /// </summary>
        public static readonly Enable GlEnable = _<Enable>("glEnable");

        /// <summary>
        ///     The disable
        /// </summary>
        public static readonly Disable GlDisable = _<Disable>("glDisable");

        /// <summary>
        ///     The blend equation
        /// </summary>
        public static readonly BlendEquation GlBlendEquation = _<BlendEquation>("glBlendEquation");

        /// <summary>
        ///     The blend func
        /// </summary>
        public static readonly BlendFunc GlBlendFunc = _<BlendFunc>("glBlendFunc");

        /// <summary>
        ///     The use program
        /// </summary>
        public static readonly UseProgram GlUseProgram = _<UseProgram>("glUseProgram");

        /// <summary>
        ///     The get shaderiv
        /// </summary>
        private static readonly GetShaderiv GlGetShaderiv = _<GetShaderiv>("glGetShaderiv");

        /// <summary>
        ///     The get shader info log del
        /// </summary>
        private static readonly GetShaderInfoLogDel GlGetShaderInfoLog = _<GetShaderInfoLogDel>("glGetShaderInfoLog");

        /// <summary>
        ///     The create shader
        /// </summary>
        public static readonly CreateShader GlCreateShader = _<CreateShader>("glCreateShader");

        /// <summary>
        ///     The shader source del
        /// </summary>
        private static readonly ShaderSourceDel GlShaderSource = _<ShaderSourceDel>("glShaderSource");

        /// <summary>
        ///     The compile shader
        /// </summary>
        public static readonly CompileShader GlCompileShader = _<CompileShader>("glCompileShader");

        /// <summary>
        ///     The delete shader
        /// </summary>
        public static readonly DeleteShader GlDeleteShader = _<DeleteShader>("glDeleteShader");

        /// <summary>
        ///     The get programiv
        /// </summary>
        public static readonly GetProgramiv GlGetProgramiv = _<GetProgramiv>("glGetProgramiv");

        /// <summary>
        ///     The get program info log del
        /// </summary>
        private static readonly GetProgramInfoLogDel GlGetProgramInfoLog = _<GetProgramInfoLogDel>("glGetProgramInfoLog");

        /// <summary>
        ///     The create program
        /// </summary>
        public static readonly CreateProgram GlCreateProgram = _<CreateProgram>("glCreateProgram");

        /// <summary>
        ///     The attach shader
        /// </summary>
        public static readonly AttachShader GlAttachShader = _<AttachShader>("glAttachShader");

        /// <summary>
        ///     The link program
        /// </summary>
        public static readonly LinkProgram GlLinkProgram = _<LinkProgram>("glLinkProgram");

        /// <summary>
        ///     The get uniform location
        /// </summary>
        public static readonly GetUniformLocation GlGetUniformLocation = _<GetUniformLocation>("glGetUniformLocation");

        /// <summary>
        ///     The get attrib location
        /// </summary>
        public static readonly GetAttribLocation GlGetAttribLocation = _<GetAttribLocation>("glGetAttribLocation");

        /// <summary>
        ///     The detach shader
        /// </summary>
        public static readonly DetachShader GlDetachShader = _<DetachShader>("glDetachShader");

        /// <summary>
        ///     The delete program
        /// </summary>
        public static readonly DeleteProgram GlDeleteProgram = _<DeleteProgram>("glDeleteProgram");

        /// <summary>
        ///     The get active attrib
        /// </summary>
        public static readonly GetActiveAttrib GlGetActiveAttrib = _<GetActiveAttrib>("glGetActiveAttrib");

        /// <summary>
        ///     The get active uniform
        /// </summary>
        public static readonly GetActiveUniform GlGetActiveUniform = _<GetActiveUniform>("glGetActiveUniform");

        /// <summary>
        ///     The uniform 1f
        /// </summary>
        public static readonly Uniform1F GlUniform1F = _<Uniform1F>("glUniform1f");

        /// <summary>
        ///     The uniform 2f
        /// </summary>
        public static readonly Uniform2F GlUniform2F = _<Uniform2F>("glUniform2f");

        /// <summary>
        ///     The uniform 3f
        /// </summary>
        public static readonly Uniform3F GlUniform3F = _<Uniform3F>("glUniform3f");

        /// <summary>
        ///     The uniform 4f
        /// </summary>
        public static readonly Uniform4F GlUniform4F = _<Uniform4F>("glUniform4f");

        /// <summary>
        ///     The uniform 1i
        /// </summary>
        public static readonly Uniform1I GlUniform1I = _<Uniform1I>("glUniform1i");

        /// <summary>
        ///     The uniform 3fv
        /// </summary>
        private static Uniform3Fv _glUniform3Fv = _<Uniform3Fv>("glUniform3fv");

        /// <summary>
        ///     The uniform 4fv
        /// </summary>
        private static Uniform4Fv _glUniform4Fv = _<Uniform4Fv>("glUniform4fv");

        /// <summary>
        ///     The uniform matrix 3fv del
        /// </summary>
        public static readonly UniformMatrix3FvDel GlUniformMatrix3Fv = _<UniformMatrix3FvDel>("glUniformMatrix3fv");

        /// <summary>
        ///     The uniform matrix 4fv del
        /// </summary>
        public static readonly UniformMatrix4FvDel GlUniformMatrix4Fv = _<UniformMatrix4FvDel>("glUniformMatrix4fv");

        /// <summary>
        ///     The bind sampler
        /// </summary>
        public static readonly BindSampler GlBindSampler = _<BindSampler>("glBindSampler");

        /// <summary>
        ///     The bind vertex array
        /// </summary>
        public static readonly BindVertexArray GlBindVertexArray = _<BindVertexArray>("glBindVertexArray");

        /// <summary>
        ///     The bind buffer
        /// </summary>
        public static readonly BindBuffer GlBindBuffer = _<BindBuffer>("glBindBuffer");

        /// <summary>
        ///     The enable vertex attrib array del
        /// </summary>
        private static readonly EnableVertexAttribArrayDel GlEnableVertexAttribArray = _<EnableVertexAttribArrayDel>("glEnableVertexAttribArray");

        /// <summary>
        ///     The disable vertex attrib array
        /// </summary>
        public static DisableVertexAttribArray GlDisableVertexAttribArray = _<DisableVertexAttribArray>("glDisableVertexAttribArray");

        /// <summary>
        ///     The vertex attrib pointer del
        /// </summary>
        private static readonly VertexAttribPointerDel GlVertexAttribPointer = _<VertexAttribPointerDel>("glVertexAttribPointer");

        /// <summary>
        ///     The bind texture
        /// </summary>
        internal static readonly BindTexture GlBindTexture = _<BindTexture>("glBindTexture");

        /// <summary>
        ///     The buffer data
        /// </summary>
        internal static readonly BufferData GlBufferData = _<BufferData>("glBufferData");

        /// <summary>
        ///     The scissor
        /// </summary>
        internal static readonly Scissor GlScissor = _<Scissor>("glScissor");

        /// <summary>
        ///     The draw elements base vertex
        /// </summary>
        internal static readonly DrawElementsBaseVertex GlDrawElementsBaseVertex = _<DrawElementsBaseVertex>("glDrawElementsBaseVertex");

        /// <summary>
        ///     The delete vertex arrays
        /// </summary>
        private static readonly DeleteVertexArrays GlDeleteVertexArrays = _<DeleteVertexArrays>("glDeleteVertexArrays");

        /// <summary>
        ///     The gen vertex arrays
        /// </summary>
        private static readonly GenVertexArrays GlGenVertexArrays = _<GenVertexArrays>("glGenVertexArrays");

        /// <summary>
        ///     The gen textures
        /// </summary>
        private static readonly GenTextures GlGenTextures = _<GenTextures>("glGenTextures");

        /// <summary>
        ///     The pixel storei
        /// </summary>
        internal static readonly PixelStorei GlPixelStorei = _<PixelStorei>("glPixelStorei");

        /// <summary>
        ///     The tex image
        /// </summary>
        internal static readonly TexImage2D GlTexImage2D = _<TexImage2D>("glTexImage2D");

        /// <summary>
        ///     The tex parameteri
        /// </summary>
        internal static readonly TexParameteri GlTexParameteri = _<TexParameteri>("glTexParameteri");

        /// <summary>
        ///     The delete textures
        /// </summary>
        private static readonly DeleteTextures GlDeleteTextures = _<DeleteTextures>("glDeleteTextures");

        /// <summary>
        ///     S
        /// </summary>
        /// <param name="command"></param>
        /// <typeparam name="T">The </typeparam>
        /// <exception cref="Exception">nogo: {method} from {typeof(T).Name}</exception>
        /// <returns>The</returns>
        private static T _<T>(string command) where T : class
        {
            IntPtr ptr = Sdl.SDL_GL_GetProcAddress(command);
            if (ptr == IntPtr.Zero)
            {
                throw new ExternalException($"{command} from {typeof(T).Name}");
            }

            return Marshal.GetDelegateForFunctionPointer(ptr, typeof(T)) as T;
        }

        /// <summary>
        ///     Gls the get string using the specified pname
        /// </summary>
        /// <param name="pname">The pname</param>
        /// <returns>The string</returns>
        public static string GlGetString(StringName pname)
        {
            IntPtr ptr = _getString(pname);
            if (ptr == IntPtr.Zero)
            {
                return string.Empty;
            }

            int length = 0;
            while (Marshal.ReadByte(ptr, length) != 0)
            {
                length++;
            }

            byte[] buffer = new byte[length];
            Marshal.Copy(ptr, buffer, 0, length);

            return Encoding.ASCII.GetString(buffer);
        }
    }
}