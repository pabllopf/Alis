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
using Alis.Core.Aspect.Math.Matrix;
using Alis.Core.Graphic.Sdl2;
using Alis.Extension.OpenGL.Delegates;
using Alis.Extension.OpenGL.Enums;

namespace Alis.Extension.OpenGL
{
    /// <summary>
    ///     The gl class
    /// </summary>
    public static class Gl
    {
        /// <summary>
        ///     The get string
        /// </summary>
        public static readonly GetString GetString = _<GetString>("glGetString");

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
        ///     The get shader
        /// </summary>
        private static readonly GetShaderiv GlGetShaderIv = _<GetShaderiv>("glGetShaderiv");

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
        public static readonly BindTexture GlBindTexture = _<BindTexture>("glBindTexture");

        /// <summary>
        ///     The buffer data
        /// </summary>
        public static readonly BufferData GlBufferData = _<BufferData>("glBufferData");

        /// <summary>
        ///     The scissor
        /// </summary>
        public static readonly Scissor GlScissor = _<Scissor>("glScissor");

        /// <summary>
        ///     The draw elements base vertex
        /// </summary>
        public static readonly DrawElementsBaseVertex GlDrawElementsBaseVertex = _<DrawElementsBaseVertex>("glDrawElementsBaseVertex");

        /// <summary>
        ///     The delete vertex arrays
        /// </summary>
        private static readonly DeleteVertexArrays GlDeleteVertexArrays = _<DeleteVertexArrays>("glDeleteVertexArrays");

        /// <summary>
        ///     The gen vertex arrays
        /// </summary>
        public static readonly GenVertexArrays GlGenVertexArrays = _<GenVertexArrays>("glGenVertexArrays");

        /// <summary>
        ///     The gen textures
        /// </summary>
        private static readonly GenTextures GlGenTextures = _<GenTextures>("glGenTextures");

        /// <summary>
        ///     The pixel storei
        /// </summary>
        public static readonly Storei GlPixelStorei = _<Storei>("glPixelStorei");

        /// <summary>
        ///     The tex image
        /// </summary>
        public static readonly TexImage2D GlTexImage2D = _<TexImage2D>("glTexImage2D");

        /// <summary>
        ///     The tex parameteri
        /// </summary>
        public static readonly TexParameteri GlTexParameteri = _<TexParameteri>("glTexParameteri");

        /// <summary>
        ///     The delete textures
        /// </summary>
        private static readonly DeleteTextures GlDeleteTextures = _<DeleteTextures>("glDeleteTextures");

        /// <summary>
        ///     The uint
        /// </summary>
        private static readonly uint[] Uint1 = new uint[1];

        /// <summary>
        ///     The int
        /// </summary>
        private static readonly int[] Int1 = new int[1];

        /// <summary>
        ///     The matrix float
        /// </summary>
        private static readonly float[] Matrix4Float = new float[16];

        /// <summary>
        ///     S
        /// </summary>
        /// <param name="command"></param>
        /// <typeparam name="T">The </typeparam>
        /// <exception cref="Exception">nogo: {method} from {typeof(T).Name}</exception>
        /// <returns>The</returns>
        private static T _<T>(string command) where T : class
        {
            IntPtr ptr = Sdl.GetProcAddress(command);
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
            IntPtr ptr = GetString(pname);
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

        /// <summary>
        ///     Gens the buffer
        /// </summary>
        /// <returns>The uint</returns>
        public static uint GenBuffer()
        {
            Uint1[0] = 0;
            GlGenBuffers(1, Uint1);
            return Uint1[0];
        }

        /// <summary>
        ///     Deletes the buffer using the specified buffer
        /// </summary>
        /// <param name="buffer">The buffer</param>
        public static void DeleteBuffer(uint buffer)
        {
            Uint1[0] = 0;
            GlDeleteBuffers(1, Uint1);
            Uint1[0] = 0;
        }

        /// <summary>
        ///     Gets the shader info log using the specified shader
        /// </summary>
        /// <param name="shader">The shader</param>
        /// <returns>The string</returns>
        public static string GetShaderInfoLog(uint shader)
        {
            GlGetShaderIv(shader, ShaderParameter.InfoLogLength, Int1);
            if (Int1[0] == 0)
            {
                return string.Empty;
            }

            StringBuilder sb = new StringBuilder(Int1[0]);
            GlGetShaderInfoLog(shader, sb.Capacity, Int1, sb);
            return sb.ToString();
        }

        /// <summary>
        ///     Shaders the source using the specified shader
        /// </summary>
        /// <param name="shader">The shader</param>
        /// <param name="source">The source</param>
        public static void ShaderSource(uint shader, string source)
        {
            Int1[0] = source.Length;
            GlShaderSource(shader, 1, new[] {source}, Int1);
        }

        /// <summary>
        ///     Describes whether get shader compile status
        /// </summary>
        /// <param name="shader">The shader</param>
        /// <returns>The bool</returns>
        public static bool GetShaderCompileStatus(uint shader)
        {
            GlGetShaderIv(shader, ShaderParameter.CompileStatus, Int1);
            return Int1[0] == 1;
        }

        /// <summary>
        ///     Gets the program info log using the specified program
        /// </summary>
        /// <param name="program">The program</param>
        /// <returns>The string</returns>
        public static string GetProgramInfoLog(uint program)
        {
            GlGetProgramiv(program, ProgramParameter.InfoLogLength, Int1);
            if (Int1[0] == 0)
            {
                return string.Empty;
            }

            StringBuilder sb = new StringBuilder(Int1[0]);
            GlGetProgramInfoLog(program, sb.Capacity, Int1, sb);
            return sb.ToString();
        }

        /// <summary>
        ///     Describes whether get program link status
        /// </summary>
        /// <param name="program">The program</param>
        /// <returns>The bool</returns>
        public static bool GetProgramLinkStatus(uint program)
        {
            GlGetProgramiv(program, ProgramParameter.LinkStatus, Int1);
            return Int1[0] == 1;
        }

        /// <summary>
        ///     Uniforms the matrix 4fv using the specified location
        /// </summary>
        /// <param name="location">The location</param>
        /// <param name="param">The param</param>
        public static void UniformMatrix4Fv(int location, Matrix4X4 param)
        {
            Matrix4Float[0] = param.M11;
            Matrix4Float[1] = param.M12;
            Matrix4Float[2] = param.M13;
            Matrix4Float[3] = param.M14;
            Matrix4Float[4] = param.M21;
            Matrix4Float[5] = param.M22;
            Matrix4Float[6] = param.M23;
            Matrix4Float[7] = param.M24;
            Matrix4Float[8] = param.M31;
            Matrix4Float[9] = param.M32;
            Matrix4Float[10] = param.M33;
            Matrix4Float[11] = param.M34;
            Matrix4Float[12] = param.M41;
            Matrix4Float[13] = param.M42;
            Matrix4Float[14] = param.M43;
            Matrix4Float[15] = param.M44;

            GlUniformMatrix4Fv(location, 1, false, Matrix4Float);
        }

        /// <summary>
        ///     Vertexes the attrib pointer using the specified index
        /// </summary>
        /// <param name="index">The index</param>
        /// <param name="size">The size</param>
        /// <param name="type">The type</param>
        /// <param name="normalized">The normalized</param>
        /// <param name="stride">The stride</param>
        /// <param name="pointer">The pointer</param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static void VertexAttribPointer(int index, int size, VertexAttribPointerType type, bool normalized, int stride, IntPtr pointer)
        {
            if (index < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(index));
            }

            GlVertexAttribPointer((uint) index, size, type, normalized, stride, pointer);
        }

        /// <summary>
        ///     Enables the vertex attrib array using the specified index
        /// </summary>
        /// <param name="index">The index</param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static void EnableVertexAttribArray(int index)
        {
            if (index < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(index));
            }

            GlEnableVertexAttribArray((uint) index);
        }

        /// <summary>
        ///     Gens the vertex array
        /// </summary>
        /// <returns>The uint</returns>
        public static uint GenVertexArray()
        {
            Uint1[0] = 0;
            GlGenVertexArrays(1, Uint1);
            return Uint1[0];
        }

        /// <summary>
        ///     Deletes the vertex array using the specified vao
        /// </summary>
        /// <param name="vao">The vao</param>
        public static void DeleteVertexArray(uint vao)
        {
            Uint1[0] = vao;
            GlDeleteVertexArrays(1, Uint1);
        }

        /// <summary>
        ///     Gens the texture
        /// </summary>
        /// <returns>The uint</returns>
        public static uint GenTexture()
        {
            Uint1[0] = 0;
            GlGenTextures(1, Uint1);
            return Uint1[0];
        }

        /// <summary>
        ///     Deletes the texture using the specified texture
        /// </summary>
        /// <param name="texture">The texture</param>
        public static void DeleteTexture(uint texture)
        {
            Uint1[0] = texture;
            GlDeleteTextures(1, Uint1);
        }

        /// <summary>
        ///     The draw arrays
        /// </summary>
        public static readonly DrawArrays GlDrawArrays = _<DrawArrays>("glDrawArrays");

        /// <summary>
        /// The draw elements
        /// </summary>
        public static readonly DrawElements GlDrawElements = _<DrawElements>("glDrawElements");
        
    }

    /// <summary>
    /// The draw elements
    /// </summary>
    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate void DrawElements(PrimitiveType mode, int count, DrawElementsType type, IntPtr indices);
        
    /// <summary>
    /// The draw arrays
    /// </summary>
    public delegate void DrawArrays(PrimitiveType mode, int first, int count);

    /// <summary>
    /// The primitive type enum
    /// </summary>
    public enum PrimitiveType
    {
        /// <summary>
        /// The points primitive type
        /// </summary>
        Points = 0x0000,       // GL_POINTS
        /// <summary>
        /// The lines primitive type
        /// </summary>
        Lines = 0x0001,        // GL_LINES
        /// <summary>
        /// The line loop primitive type
        /// </summary>
        LineLoop = 0x0002,     // GL_LINE_LOOP
        /// <summary>
        /// The line strip primitive type
        /// </summary>
        LineStrip = 0x0003,    // GL_LINE_STRIP
        /// <summary>
        /// The triangles primitive type
        /// </summary>
        Triangles = 0x0004,    // GL_TRIANGLES
        /// <summary>
        /// The triangle strip primitive type
        /// </summary>
        TriangleStrip = 0x0005,// GL_TRIANGLE_STRIP
        /// <summary>
        /// The triangle fan primitive type
        /// </summary>
        TriangleFan = 0x0006   // GL_TRIANGLE_FAN
    }
}