// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:Gl.cs
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
using System.Numerics;
using System.Runtime.InteropServices;
using System.Text;
using Alis.Core.Aspect.Math.Matrix;
using Alis.Core.Graphic.OpenGL.Delegates;
using Alis.Core.Graphic.OpenGL.Enums;

namespace Alis.Core.Graphic.OpenGL
{
    /// <summary>
    ///     The gl class
    /// </summary>
    public static class Gl
    {
        /// <summary>
        ///     The get proc address delegate
        /// </summary>
        public delegate IntPtr GetProcAddressDelegate(string procName);

        /// <summary>
        ///     The get proc address
        /// </summary>
        private static GetProcAddressDelegate _getProcAddress;

        /// <summary>
        ///     The uint
        /// </summary>
        public static uint[] Uint1 = new uint[1];

        /// <summary>
        ///     The int
        /// </summary>
        public static int[] Int1 = new int[1];

        /// <summary>
        ///     The matrix float
        /// </summary>
        public static float[] Matrix4Float = new float[16];

        /// <summary>
        ///     The get string
        /// </summary>
        public static GetString GetString => GetCommand<GetString>("glGetString");

        /// <summary>
        ///     The gen buffers
        /// </summary>
        public static GenBuffers GlGenBuffers => GetCommand<GenBuffers>("glGenBuffers");

        /// <summary>
        ///     The delete buffers
        /// </summary>
        public static DeleteBuffers GlDeleteBuffers => GetCommand<DeleteBuffers>("glDeleteBuffers");

        /// <summary>
        ///     The viewport
        /// </summary>
        public static Viewport GlViewport => GetCommand<Viewport>("glViewport");

        /// <summary>
        ///     The clear color
        /// </summary>
        public static ClearColor GlClearColor => GetCommand<ClearColor>("glClearColor");

        /// <summary>
        ///     The color 4f
        /// </summary>
        public static Color4F GlColor4F => GetCommand<Color4F>("glColor4f");


        /// <summary>
        ///     The end
        /// </summary>
        public static End GlEnd => GetCommand<End>("glEnd");

        /// <summary>
        ///     The clear
        /// </summary>
        public static Clear GlClear => GetCommand<Clear>("glClear");

        /// <summary>
        ///     The enable
        /// </summary>
        public static Enable GlEnable => GetCommand<Enable>("glEnable");

        /// <summary>
        ///     The disable
        /// </summary>
        public static Disable GlDisable => GetCommand<Disable>("glDisable");

        /// <summary>
        ///     The blend equation
        /// </summary>
        public static BlendEquation GlBlendEquation => GetCommand<BlendEquation>("glBlendEquation");

        /// <summary>
        ///     The blend func
        /// </summary>
        public static BlendFunc GlBlendFunc => GetCommand<BlendFunc>("glBlendFunc");

        /// <summary>
        ///     The use program
        /// </summary>
        public static UseProgram GlUseProgram => GetCommand<UseProgram>("glUseProgram");

        /// <summary>
        ///     The get shader
        /// </summary>
        public static GetShaderiv GlGetShaderIv => GetCommand<GetShaderiv>("glGetShaderiv");

        /// <summary>
        ///     The get shader info log del
        /// </summary>
        public static GetShaderInfoLogDel GlGetShaderInfoLog => GetCommand<GetShaderInfoLogDel>("glGetShaderInfoLog");

        /// <summary>
        ///     The create shader
        /// </summary>
        public static CreateShader GlCreateShader => GetCommand<CreateShader>("glCreateShader");

        /// <summary>
        ///     The begin
        /// </summary>
        public static Begin GlBegin => GetCommand<Begin>("glBegin");

        /// <summary>
        ///     The shader source del
        /// </summary>
        public static ShaderSourceDel GlShaderSource => GetCommand<ShaderSourceDel>("glShaderSource");

        /// <summary>
        ///     The compile shader
        /// </summary>
        public static CompileShader GlCompileShader => GetCommand<CompileShader>("glCompileShader");

        /// <summary>
        ///     The delete shader
        /// </summary>
        public static DeleteShader GlDeleteShader => GetCommand<DeleteShader>("glDeleteShader");

        /// <summary>
        ///     The get programiv
        /// </summary>
        public static GetProgramiv GlGetProgramiv => GetCommand<GetProgramiv>("glGetProgramiv");

        /// <summary>
        ///     The get program info log del
        /// </summary>
        public static GetProgramInfoLogDel GlGetProgramInfoLog => GetCommand<GetProgramInfoLogDel>("glGetProgramInfoLog");

        /// <summary>
        ///     The create program
        /// </summary>
        public static CreateProgram GlCreateProgram => GetCommand<CreateProgram>("glCreateProgram");

        /// <summary>
        ///     The attach shader
        /// </summary>
        public static AttachShader GlAttachShader => GetCommand<AttachShader>("glAttachShader");

        /// <summary>
        ///     The link program
        /// </summary>
        public static LinkProgram GlLinkProgram => GetCommand<LinkProgram>("glLinkProgram");

        /// <summary>
        ///     The get uniform location
        /// </summary>
        public static GetUniformLocation GlGetUniformLocation => GetCommand<GetUniformLocation>("glGetUniformLocation");

        /// <summary>
        ///     The get attrib location
        /// </summary>
        public static GetAttribLocation GlGetAttribLocation => GetCommand<GetAttribLocation>("glGetAttribLocation");

        /// <summary>
        ///     The detach shader
        /// </summary>
        public static DetachShader GlDetachShader => GetCommand<DetachShader>("glDetachShader");

        /// <summary>
        ///     The delete program
        /// </summary>
        public static DeleteProgram GlDeleteProgram => GetCommand<DeleteProgram>("glDeleteProgram");

        /// <summary>
        ///     The get active attrib
        /// </summary>
        public static GetActiveAttrib GlGetActiveAttrib => GetCommand<GetActiveAttrib>("glGetActiveAttrib");

        /// <summary>
        ///     The get active uniform
        /// </summary>
        public static GetActiveUniform GlGetActiveUniform => GetCommand<GetActiveUniform>("glGetActiveUniform");

        /// <summary>
        ///     The uniform 1f
        /// </summary>
        public static Uniform1F GlUniform1F => GetCommand<Uniform1F>("glUniform1f");

        /// <summary>
        ///     The uniform 2f
        /// </summary>
        public static Uniform2F GlUniform2F => GetCommand<Uniform2F>("glUniform2f");

        /// <summary>
        ///     The uniform 3f
        /// </summary>
        public static Uniform3F GlUniform3F => GetCommand<Uniform3F>("glUniform3f");

        /// <summary>
        ///     The uniform 4f
        /// </summary>
        public static Uniform4F GlUniform4F => GetCommand<Uniform4F>("glUniform4f");

        /// <summary>
        ///     The uniform 1i
        /// </summary>
        public static Uniform1I GlUniform1I => GetCommand<Uniform1I>("glUniform1i");

        /// <summary>
        ///     The uniform 3fv
        /// </summary>
        private static Uniform3Fv GlUniform3Fv => GetCommand<Uniform3Fv>("glUniform3fv");

        // En Gl.cs
        /// <summary>
        /// The read pixels
        /// </summary>
        public delegate void ReadPixels(int x, int y, int width, int height, PixelFormat format, PixelType type, IntPtr pixels);
        /// <summary>
        /// Gets the value of the gl read pixels
        /// </summary>
        public static ReadPixels GlReadPixels => GetCommand<ReadPixels>("glReadPixels");
        
        /// <summary>
        /// The gen framebuffer
        /// </summary>
        public delegate uint GenFramebuffer();
        
        
        /// <summary>
        /// Gets the value of the gl gen framebuffer
        /// </summary>
        public static GenFramebuffer GlGenFramebuffer => GetCommand<GenFramebuffer>("glGenFramebuffers");

        /// <summary>
        /// The framebuffer texture
        /// </summary>
        public delegate void FramebufferTexture2D(FramebufferTarget target, FramebufferAttachment attachment, TextureTarget texTarget, uint texture, int level);
        /// <summary>
        /// Gets the value of the gl framebuffer texture 2 d
        /// </summary>
        public static FramebufferTexture2D GlFramebufferTexture2D => GetCommand<FramebufferTexture2D>("glFramebufferTexture2D");

        /// <summary>
        ///     The uniform 4fv
        /// </summary>
        private static Uniform4Fv GlUniform4Fv => GetCommand<Uniform4Fv>("glUniform4fv");

        /// <summary>
        ///     The uniform matrix 3fv del
        /// </summary>
        public static UniformMatrix3FvDel GlUniformMatrix3Fv => GetCommand<UniformMatrix3FvDel>("glUniformMatrix3fv");

        /// <summary>
        ///     The uniform matrix 4fv del
        /// </summary>
        public static UniformMatrix4FvDel GlUniformMatrix4Fv => GetCommand<UniformMatrix4FvDel>("glUniformMatrix4fv");

        /// <summary>
        ///     The bind sampler
        /// </summary>
        public static BindSampler GlBindSampler => GetCommand<BindSampler>("glBindSampler");

        /// <summary>
        ///     The bind vertex array
        /// </summary>
        public static BindVertexArray GlBindVertexArray => GetCommand<BindVertexArray>("glBindVertexArray");

        /// <summary>
        ///     The bind buffer
        /// </summary>
        public static BindBuffer GlBindBuffer => GetCommand<BindBuffer>("glBindBuffer");

        /// <summary>
        ///     The vertex 2f
        /// </summary>
        public static Vertex2F GlVertex2F => GetCommand<Vertex2F>("glVertex2f");

        /// <summary>
        ///     The enable vertex attrib array del
        /// </summary>
        public static EnableVertexAttribArrayDel GlEnableVertexAttribArray => GetCommand<EnableVertexAttribArrayDel>("glEnableVertexAttribArray");

        /// <summary>
        ///     The disable vertex attrib array
        /// </summary>
        public static DisableVertexAttribArray GlDisableVertexAttribArray => GetCommand<DisableVertexAttribArray>("glDisableVertexAttribArray");

        /// <summary>
        ///     The vertex attrib pointer del
        /// </summary>
        public static VertexAttribPointerDel GlVertexAttribPointer => GetCommand<VertexAttribPointerDel>("glVertexAttribPointer");

        // Enum para FramebufferTarget

        /// <summary>
        /// The bind framebuffer
        /// </summary>
        public delegate void BindFramebuffer(FramebufferTarget target, uint framebuffer);

        /// <summary>
        /// Gets the value of the gl bind framebuffer
        /// </summary>
        public static BindFramebuffer GlBindFramebuffer => GetCommand<BindFramebuffer>("glBindFramebuffer");
        
        /// <summary>
        ///     The bind texture
        /// </summary>
        public static BindTexture GlBindTexture => GetCommand<BindTexture>("glBindTexture");

        /// <summary>
        ///     The buffer data
        /// </summary>
        public static BufferData GlBufferData => GetCommand<BufferData>("glBufferData");

        /// <summary>
        ///     The scissor
        /// </summary>
        public static Scissor GlScissor => GetCommand<Scissor>("glScissor");

        /// <summary>
        ///     The draw elements base vertex
        /// </summary>
        public static DrawElementsBaseVertex GlDrawElementsBaseVertex => GetCommand<DrawElementsBaseVertex>("glDrawElementsBaseVertex");

        /// <summary>
        ///     The delete vertex arrays
        /// </summary>
        public static DeleteVertexArrays GlDeleteVertexArrays => GetCommand<DeleteVertexArrays>("glDeleteVertexArrays");

        /// <summary>
        ///     The gen vertex arrays
        /// </summary>
        public static GenVertexArrays GlGenVertexArrays => GetCommand<GenVertexArrays>("glGenVertexArrays");

        /// <summary>
        ///     The gen textures
        /// </summary>
        public static GenTextures GlGenTextures => GetCommand<GenTextures>("glGenTextures");

        /// <summary>
        ///     The pixel storei
        /// </summary>
        public static Storei GlPixelStorei => GetCommand<Storei>("glPixelStorei");

        /// <summary>
        ///     The tex image
        /// </summary>
        public static TexImage2D GlTexImage2D => GetCommand<TexImage2D>("glTexImage2D");

        /// <summary>
        ///     The tex parameteri
        /// </summary>
        public static TexParameteri GlTexParameteri => GetCommand<TexParameteri>("glTexParameteri");

        /// <summary>
        ///     The delete textures
        /// </summary>
        public static DeleteTextures GlDeleteTextures => GetCommand<DeleteTextures>("glDeleteTextures");

        /// <summary>
        ///     The draw arrays
        /// </summary>
        public static DrawArrays GlDrawArrays => GetCommand<DrawArrays>("glDrawArrays");

        /// <summary>
        ///     The draw elements
        /// </summary>
        public static DrawElements GlDrawElements => GetCommand<DrawElements>("glDrawElements");

        /// <summary>
        ///     The polygon mode
        /// </summary>
        public static PolygonMode GlPolygonMode => GetCommand<PolygonMode>("glPolygonMode");

        /// <summary>
        ///     Initializes the get proc address
        /// </summary>
        /// <param name="getProcAddress">The get proc address</param>
        public static void Initialize(GetProcAddressDelegate getProcAddress)
        {
            _getProcAddress = getProcAddress;
        }

        /// <summary>
        ///     Gets the command using the specified command
        /// </summary>
        /// <typeparam name="T">The </typeparam>
        /// <param name="command">The command</param>
        /// <exception cref="InvalidOperationException">Inicialize called before Initialize</exception>
        /// <exception cref="ExternalException">{command} from {typeof(T).Name}</exception>
        /// <returns>The</returns>
        private static T GetCommand<T>(string command) where T : class
        {
            if (_getProcAddress == null)
            {
                throw new InvalidOperationException("Inicialize called before Initialize");
            }
        
            IntPtr ptr = _getProcAddress(command);
            if (ptr == IntPtr.Zero)
            {
                throw new ExternalException($"{command} from {typeof(T).Name}");
            }
        
            return Marshal.GetDelegateForFunctionPointer<T>(ptr);
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
        ///     Generates the mipmap using the specified texture 2 d
        /// </summary>
        /// <param name="texture2D">The texture</param>
        public static void GenerateMipmap(TextureTarget texture2D) => GetCommand<GetString>("glGenerateMipmap");

        /// <summary>
        ///     The get error
        /// </summary>
        public delegate int GetError();
        /// <summary>
        ///     Gets the value of glGetError
        /// </summary>
        public static GetError GlGetErrorDelegate => GetCommand<GetError>("glGetError");
        /// <summary>
        ///     Gets the last error from OpenGL
        /// </summary>
        /// <returns>Error code</returns>
        public static int GlGetError()
        {
            return GlGetErrorDelegate();
        }
        
        /// <summary>
        ///     Sets the width of lines to be rasterized
        /// </summary>
        /// <param name="width">The width of the line</param>
        public delegate void LineWidth(float width);
        /// <summary>
        /// Gets the value of the gl line width delegate
        /// </summary>
        public static LineWidth GlLineWidthDelegate => GetCommand<LineWidth>("glLineWidth");
        /// <summary>
        /// Gls the line width using the specified width
        /// </summary>
        /// <param name="width">The width</param>
        public static void GlLineWidth(float width)
        {
            GlLineWidthDelegate(width);
        }

        /// <summary>
        ///     Activates the specified texture unit
        /// </summary>
        /// <param name="texture">The texture unit</param>
        public delegate void ActiveTexture(TextureUnit texture);
        /// <summary>
        /// Gets the value of the gl active texture delegate
        /// </summary>
        public static ActiveTexture GlActiveTextureDelegate => GetCommand<ActiveTexture>("glActiveTexture");
        /// <summary>
        /// Gls the active texture using the specified texture
        /// </summary>
        /// <param name="texture">The texture</param>
        public static void GlActiveTexture(TextureUnit texture)
        {
            GlActiveTextureDelegate(texture);
        }
    }
}

