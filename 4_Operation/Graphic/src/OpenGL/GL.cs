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
using static Alis.Core.Graphic.SDL.Sdl;

namespace Alis.Core.Graphic.OpenGL
{
    /// <summary>
    ///     The gl class
    /// </summary>
    public static partial class Gl
    {
        /// <summary>
        ///     The attach shader
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate void AttachShader(uint program, uint shader);

        /// <summary>
        ///     The bind buffer
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate void BindBuffer(BufferTarget target, uint buffer);

        /// <summary>
        ///     The bind sampler
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate void BindSampler(uint unit, uint sampler);

        /// <summary>
        ///     The bind texture
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate void BindTexture(TextureTarget target, uint texture);

        /// <summary>
        ///     The bind vertex array
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate void BindVertexArray(uint array);

        /// <summary>
        ///     The blend equation
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate void BlendEquation(BlendEquationMode mode);

        /// <summary>
        ///     The blend func
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate void BlendFunc(BlendingFactorSrc sfactor, BlendingFactorDest dfactor);

        /// <summary>
        ///     The buffer data
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate void BufferData(BufferTarget target, IntPtr size, IntPtr data, BufferUsageHint usage);

        /// <summary>
        ///     The clear
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate void Clear(ClearBufferMask mask);

        /// <summary>
        ///     The clear color
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate void ClearColor(float r, float g, float b, float a);

        /// <summary>
        ///     The compile shader
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate void CompileShader(uint shader);

        /// <summary>
        ///     The create program
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate uint CreateProgram();

        /// <summary>
        ///     The create shader
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate uint CreateShader(ShaderType shaderType);

        /// <summary>
        ///     The delete buffers
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate void DeleteBuffers(int n, uint[] buffers);

        /// <summary>
        ///     The delete program
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate void DeleteProgram(uint program);

        /// <summary>
        ///     The delete shader
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate void DeleteShader(uint shader);

        /// <summary>
        ///     The delete textures
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate void DeleteTextures(int n, uint[] textures);

        /// <summary>
        ///     The delete vertex arrays
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate void DeleteVertexArrays(int n, uint[] arrays);

        /// <summary>
        ///     The detach shader
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate void DetachShader(uint program, uint shader);

        /// <summary>
        ///     The disable
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate void Disable(EnableCap cap);

        /// <summary>
        ///     The disable vertex attrib array
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate void DisableVertexAttribArray(uint index);

        /// <summary>
        ///     The draw elements base vertex
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate void DrawElementsBaseVertex(BeginMode mode, int count, DrawElementsType type, IntPtr indices, int basevertex);

        /// <summary>
        ///     The enable
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate void Enable(EnableCap cap);

        /// <summary>
        ///     The enable vertex attrib array del
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate void EnableVertexAttribArrayDel(uint index);

        /// <summary>
        ///     The gen buffers
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate void GenBuffers(int n, [Out] uint[] buffers);

        /// <summary>
        ///     The gen textures
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate void GenTextures(int n, [Out] uint[] textures);

        /// <summary>
        ///     The gen vertex arrays
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate void GenVertexArrays(int n, [Out] uint[] arrays);

        /// <summary>
        ///     The get active attrib
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate void GetActiveAttrib(uint program, uint index, int bufSize, [Out] int[] length, [Out] int[] size, [Out] ActiveAttribType[] type, [Out] StringBuilder name);

        /// <summary>
        ///     The get active uniform
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate void GetActiveUniform(uint program, uint index, int bufSize, [Out] int[] length, [Out] int[] size, [Out] ActiveUniformType[] type, [Out] StringBuilder name);

        /// <summary>
        ///     The get attrib location
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate int GetAttribLocation(uint program, string name);

        /// <summary>
        ///     The get program info log del
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate void GetProgramInfoLogDel(uint program, int maxLength, [Out] int[] length, [Out] StringBuilder infoLog);

        /// <summary>
        ///     The get programiv
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate void GetProgramiv(uint program, ProgramParameter pname, [Out] int[] @params);

        /// <summary>
        ///     The get shader info log del
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate void GetShaderInfoLogDel(uint shader, int maxLength, [Out] int[] length, [Out] StringBuilder infoLog);

        /// <summary>
        ///     The get shaderiv
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate void GetShaderiv(uint shader, ShaderParameter pname, [Out] int[] @params);

        /// <summary>
        ///     The get uniform location
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate int GetUniformLocation(uint program, string name);

        /// <summary>
        ///     The link program
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate void LinkProgram(uint program);

        /// <summary>
        ///     The pixel storei
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate void PixelStorei(PixelStoreParameter pname, int param);

        /// <summary>
        ///     The scissor
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate void Scissor(int x, int y, int width, int height);

        /// <summary>
        ///     The shader source del
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate void ShaderSourceDel(uint shader, int count, string[] @string, int[] length);

        /// <summary>
        ///     The tex image
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate void TexImage2D(TextureTarget target, int level, PixelInternalFormat internalFormat, int width, int height, int border, PixelFormat format, PixelType type, IntPtr data);

        /// <summary>
        ///     The tex parameteri
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate void TexParameteri(TextureTarget target, TextureParameterName pname, TextureParameter param);

        /// <summary>
        ///     The uniform 1f
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate void Uniform1F(int location, float v0);

        /// <summary>
        ///     The uniform 1i
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate void Uniform1I(int location, int v0);

        /// <summary>
        ///     The uniform 2f
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate void Uniform2F(int location, float v0, float v1);

        /// <summary>
        ///     The uniform 3f
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate void Uniform3F(int location, float v0, float v1, float v2);

        /// <summary>
        ///     The uniform 3fv
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate void Uniform3Fv(int location, int count, float[] value);

        /// <summary>
        ///     The uniform 4f
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate void Uniform4F(int location, float v0, float v1, float v2, float v3);

        /// <summary>
        ///     The uniform 4fv
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate void Uniform4Fv(int location, int count, float[] value);

        /// <summary>
        ///     The uniform matrix 3fv del
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate void UniformMatrix3FvDel(int location, int count, bool transpose, float[] value);

        /// <summary>
        ///     The uniform matrix 4fv del
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate void UniformMatrix4FvDel(int location, int count, bool transpose, float[] value);

        /// <summary>
        ///     The use program
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate void UseProgram(uint program);

        /// <summary>
        ///     The vertex attrib pointer del
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate void VertexAttribPointerDel(uint index, int size, VertexAttribPointerType type, bool normalized, int stride, IntPtr pointer);

        /// <summary>
        ///     The viewport
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate void Viewport(int x, int y, int width, int height);

        /// <summary>
        ///     The get string
        /// </summary>
        private static GetString _getString = _<GetString>("glGetString");

        /// <summary>
        ///     The gen buffers
        /// </summary>
        public static GenBuffers glGenBuffers = _<GenBuffers>("glGenBuffers");

        /// <summary>
        ///     The delete buffers
        /// </summary>
        public static DeleteBuffers glDeleteBuffers = _<DeleteBuffers>("glDeleteBuffers");

        /// <summary>
        ///     The viewport
        /// </summary>
        public static Viewport glViewport = _<Viewport>("glViewport");

        /// <summary>
        ///     The clear color
        /// </summary>
        public static ClearColor glClearColor = _<ClearColor>("glClearColor");

        /// <summary>
        ///     The clear
        /// </summary>
        public static Clear glClear = _<Clear>("glClear");

        /// <summary>
        ///     The enable
        /// </summary>
        public static Enable glEnable = _<Enable>("glEnable");

        /// <summary>
        ///     The disable
        /// </summary>
        public static Disable glDisable = _<Disable>("glDisable");

        /// <summary>
        ///     The blend equation
        /// </summary>
        public static BlendEquation glBlendEquation = _<BlendEquation>("glBlendEquation");

        /// <summary>
        ///     The blend func
        /// </summary>
        public static BlendFunc glBlendFunc = _<BlendFunc>("glBlendFunc");

        /// <summary>
        ///     The use program
        /// </summary>
        public static UseProgram glUseProgram = _<UseProgram>("glUseProgram");

        /// <summary>
        ///     The get shaderiv
        /// </summary>
        public static GetShaderiv glGetShaderiv = _<GetShaderiv>("glGetShaderiv");

        /// <summary>
        ///     The get shader info log del
        /// </summary>
        public static GetShaderInfoLogDel glGetShaderInfoLog = _<GetShaderInfoLogDel>("glGetShaderInfoLog");

        /// <summary>
        ///     The create shader
        /// </summary>
        public static CreateShader glCreateShader = _<CreateShader>("glCreateShader");

        /// <summary>
        ///     The shader source del
        /// </summary>
        public static ShaderSourceDel glShaderSource = _<ShaderSourceDel>("glShaderSource");

        /// <summary>
        ///     The compile shader
        /// </summary>
        public static CompileShader glCompileShader = _<CompileShader>("glCompileShader");

        /// <summary>
        ///     The delete shader
        /// </summary>
        public static DeleteShader glDeleteShader = _<DeleteShader>("glDeleteShader");

        /// <summary>
        ///     The get programiv
        /// </summary>
        public static GetProgramiv glGetProgramiv = _<GetProgramiv>("glGetProgramiv");

        /// <summary>
        ///     The get program info log del
        /// </summary>
        public static GetProgramInfoLogDel glGetProgramInfoLog = _<GetProgramInfoLogDel>("glGetProgramInfoLog");

        /// <summary>
        ///     The create program
        /// </summary>
        public static CreateProgram glCreateProgram = _<CreateProgram>("glCreateProgram");

        /// <summary>
        ///     The attach shader
        /// </summary>
        public static AttachShader glAttachShader = _<AttachShader>("glAttachShader");

        /// <summary>
        ///     The link program
        /// </summary>
        public static LinkProgram glLinkProgram = _<LinkProgram>("glLinkProgram");

        /// <summary>
        ///     The get uniform location
        /// </summary>
        public static GetUniformLocation glGetUniformLocation = _<GetUniformLocation>("glGetUniformLocation");

        /// <summary>
        ///     The get attrib location
        /// </summary>
        public static GetAttribLocation glGetAttribLocation = _<GetAttribLocation>("glGetAttribLocation");

        /// <summary>
        ///     The detach shader
        /// </summary>
        public static DetachShader glDetachShader = _<DetachShader>("glDetachShader");

        /// <summary>
        ///     The delete program
        /// </summary>
        public static DeleteProgram glDeleteProgram = _<DeleteProgram>("glDeleteProgram");

        /// <summary>
        ///     The get active attrib
        /// </summary>
        public static GetActiveAttrib glGetActiveAttrib = _<GetActiveAttrib>("glGetActiveAttrib");

        /// <summary>
        ///     The get active uniform
        /// </summary>
        public static GetActiveUniform glGetActiveUniform = _<GetActiveUniform>("glGetActiveUniform");

        /// <summary>
        ///     The uniform 1f
        /// </summary>
        public static Uniform1F glUniform1F = _<Uniform1F>("glUniform1f");

        /// <summary>
        ///     The uniform 2f
        /// </summary>
        public static Uniform2F glUniform2F = _<Uniform2F>("glUniform2f");

        /// <summary>
        ///     The uniform 3f
        /// </summary>
        public static Uniform3F glUniform3F = _<Uniform3F>("glUniform3f");

        /// <summary>
        ///     The uniform 4f
        /// </summary>
        public static Uniform4F glUniform4F = _<Uniform4F>("glUniform4f");

        /// <summary>
        ///     The uniform 1i
        /// </summary>
        public static Uniform1I glUniform1I = _<Uniform1I>("glUniform1i");

        /// <summary>
        ///     The uniform 3fv
        /// </summary>
        public static Uniform3Fv glUniform3Fv = _<Uniform3Fv>("glUniform3fv");

        /// <summary>
        ///     The uniform 4fv
        /// </summary>
        public static Uniform4Fv glUniform4Fv = _<Uniform4Fv>("glUniform4fv");

        /// <summary>
        ///     The uniform matrix 3fv del
        /// </summary>
        public static UniformMatrix3FvDel glUniformMatrix3Fv = _<UniformMatrix3FvDel>("glUniformMatrix3fv");

        /// <summary>
        ///     The uniform matrix 4fv del
        /// </summary>
        public static UniformMatrix4FvDel glUniformMatrix4Fv = _<UniformMatrix4FvDel>("glUniformMatrix4fv");

        /// <summary>
        ///     The bind sampler
        /// </summary>
        public static BindSampler glBindSampler = _<BindSampler>("glBindSampler");

        /// <summary>
        ///     The bind vertex array
        /// </summary>
        public static BindVertexArray glBindVertexArray = _<BindVertexArray>("glBindVertexArray");

        /// <summary>
        ///     The bind buffer
        /// </summary>
        public static BindBuffer glBindBuffer = _<BindBuffer>("glBindBuffer");

        /// <summary>
        ///     The enable vertex attrib array del
        /// </summary>
        public static EnableVertexAttribArrayDel glEnableVertexAttribArray = _<EnableVertexAttribArrayDel>("glEnableVertexAttribArray");

        /// <summary>
        ///     The disable vertex attrib array
        /// </summary>
        public static DisableVertexAttribArray glDisableVertexAttribArray = _<DisableVertexAttribArray>("glDisableVertexAttribArray");

        /// <summary>
        ///     The vertex attrib pointer del
        /// </summary>
        public static VertexAttribPointerDel glVertexAttribPointer = _<VertexAttribPointerDel>("glVertexAttribPointer");

        /// <summary>
        ///     The bind texture
        /// </summary>
        public static BindTexture glBindTexture = _<BindTexture>("glBindTexture");

        /// <summary>
        ///     The buffer data
        /// </summary>
        public static BufferData glBufferData = _<BufferData>("glBufferData");

        /// <summary>
        ///     The scissor
        /// </summary>
        public static Scissor glScissor = _<Scissor>("glScissor");

        /// <summary>
        ///     The draw elements base vertex
        /// </summary>
        public static DrawElementsBaseVertex glDrawElementsBaseVertex = _<DrawElementsBaseVertex>("glDrawElementsBaseVertex");

        /// <summary>
        ///     The delete vertex arrays
        /// </summary>
        public static DeleteVertexArrays glDeleteVertexArrays = _<DeleteVertexArrays>("glDeleteVertexArrays");

        /// <summary>
        ///     The gen vertex arrays
        /// </summary>
        public static GenVertexArrays glGenVertexArrays = _<GenVertexArrays>("glGenVertexArrays");

        /// <summary>
        ///     The gen textures
        /// </summary>
        public static GenTextures glGenTextures = _<GenTextures>("glGenTextures");

        /// <summary>
        ///     The pixel storei
        /// </summary>
        public static PixelStorei glPixelStorei = _<PixelStorei>("glPixelStorei");

        /// <summary>
        ///     The tex image
        /// </summary>
        public static TexImage2D glTexImage2D = _<TexImage2D>("glTexImage2D");

        /// <summary>
        ///     The tex parameteri
        /// </summary>
        public static TexParameteri glTexParameteri = _<TexParameteri>("glTexParameteri");

        /// <summary>
        ///     The delete textures
        /// </summary>
        public static DeleteTextures glDeleteTextures = _<DeleteTextures>("glDeleteTextures");

        /// <summary>
        ///     S
        /// </summary>
        /// <param name="command"></param>
        /// <typeparam name="T">The </typeparam>
        /// <exception cref="Exception">nogo: {method} from {typeof(T).Name}</exception>
        /// <returns>The</returns>
        private static T _<T>(string command) where T : class
        {
            IntPtr ptr = SDL_GL_GetProcAddress(command);
            if (ptr == IntPtr.Zero)
            {
                throw new Exception($"nogo: {command} from {typeof(T).Name}");
            }

            return Marshal.GetDelegateForFunctionPointer(ptr, typeof(T)) as T;
        }

        /// <summary>
        ///     Gls the get string using the specified pname
        /// </summary>
        /// <param name="pname">The pname</param>
        /// <returns>The string</returns>
        public static string glGetString(StringName pname)
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



        /// <summary>
        ///     The get string
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        private delegate IntPtr GetString(StringName pname);
    }
}