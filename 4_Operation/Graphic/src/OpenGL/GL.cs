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
using static Alis.Core.Graphic.SDL.SDL;

namespace Alis.Core.Graphic.OpenGL
{
    /// <summary>
    ///     The gl class
    /// </summary>
    public static partial class GL
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
        public delegate void Uniform1f(int location, float v0);

        /// <summary>
        ///     The uniform 1i
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate void Uniform1i(int location, int v0);

        /// <summary>
        ///     The uniform 2f
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate void Uniform2f(int location, float v0, float v1);

        /// <summary>
        ///     The uniform 3f
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate void Uniform3f(int location, float v0, float v1, float v2);

        /// <summary>
        ///     The uniform 3fv
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate void Uniform3fv(int location, int count, float[] value);

        /// <summary>
        ///     The uniform 4f
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate void Uniform4f(int location, float v0, float v1, float v2, float v3);

        /// <summary>
        ///     The uniform 4fv
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate void Uniform4fv(int location, int count, float[] value);

        /// <summary>
        ///     The uniform matrix 3fv del
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate void UniformMatrix3fvDel(int location, int count, bool transpose, float[] value);

        /// <summary>
        ///     The uniform matrix 4fv del
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate void UniformMatrix4fvDel(int location, int count, bool transpose, float[] value);

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
        private static GetString _GetString = _<GetString>();

        /// <summary>
        ///     The gen buffers
        /// </summary>
        public static GenBuffers glGenBuffers = _<GenBuffers>();

        /// <summary>
        ///     The delete buffers
        /// </summary>
        public static DeleteBuffers glDeleteBuffers = _<DeleteBuffers>();

        /// <summary>
        ///     The viewport
        /// </summary>
        public static Viewport glViewport = _<Viewport>();

        /// <summary>
        ///     The clear color
        /// </summary>
        public static ClearColor glClearColor = _<ClearColor>();

        /// <summary>
        ///     The clear
        /// </summary>
        public static Clear glClear = _<Clear>();

        /// <summary>
        ///     The enable
        /// </summary>
        public static Enable glEnable = _<Enable>();

        /// <summary>
        ///     The disable
        /// </summary>
        public static Disable glDisable = _<Disable>();

        /// <summary>
        ///     The blend equation
        /// </summary>
        public static BlendEquation glBlendEquation = _<BlendEquation>();

        /// <summary>
        ///     The blend func
        /// </summary>
        public static BlendFunc glBlendFunc = _<BlendFunc>();

        /// <summary>
        ///     The use program
        /// </summary>
        public static UseProgram glUseProgram = _<UseProgram>();

        /// <summary>
        ///     The get shaderiv
        /// </summary>
        public static GetShaderiv glGetShaderiv = _<GetShaderiv>();

        /// <summary>
        ///     The get shader info log del
        /// </summary>
        public static GetShaderInfoLogDel glGetShaderInfoLog = _Del<GetShaderInfoLogDel>();

        /// <summary>
        ///     The create shader
        /// </summary>
        public static CreateShader glCreateShader = _<CreateShader>();

        /// <summary>
        ///     The shader source del
        /// </summary>
        public static ShaderSourceDel glShaderSource = _Del<ShaderSourceDel>();

        /// <summary>
        ///     The compile shader
        /// </summary>
        public static CompileShader glCompileShader = _<CompileShader>();

        /// <summary>
        ///     The delete shader
        /// </summary>
        public static DeleteShader glDeleteShader = _<DeleteShader>();

        /// <summary>
        ///     The get programiv
        /// </summary>
        public static GetProgramiv glGetProgramiv = _<GetProgramiv>();

        /// <summary>
        ///     The get program info log del
        /// </summary>
        public static GetProgramInfoLogDel glGetProgramInfoLog = _Del<GetProgramInfoLogDel>();

        /// <summary>
        ///     The create program
        /// </summary>
        public static CreateProgram glCreateProgram = _<CreateProgram>();

        /// <summary>
        ///     The attach shader
        /// </summary>
        public static AttachShader glAttachShader = _<AttachShader>();

        /// <summary>
        ///     The link program
        /// </summary>
        public static LinkProgram glLinkProgram = _<LinkProgram>();

        /// <summary>
        ///     The get uniform location
        /// </summary>
        public static GetUniformLocation glGetUniformLocation = _<GetUniformLocation>();

        /// <summary>
        ///     The get attrib location
        /// </summary>
        public static GetAttribLocation glGetAttribLocation = _<GetAttribLocation>();

        /// <summary>
        ///     The detach shader
        /// </summary>
        public static DetachShader glDetachShader = _<DetachShader>();

        /// <summary>
        ///     The delete program
        /// </summary>
        public static DeleteProgram glDeleteProgram = _<DeleteProgram>();

        /// <summary>
        ///     The get active attrib
        /// </summary>
        public static GetActiveAttrib glGetActiveAttrib = _<GetActiveAttrib>();

        /// <summary>
        ///     The get active uniform
        /// </summary>
        public static GetActiveUniform glGetActiveUniform = _<GetActiveUniform>();

        /// <summary>
        ///     The uniform 1f
        /// </summary>
        public static Uniform1f glUniform1f = _<Uniform1f>();

        /// <summary>
        ///     The uniform 2f
        /// </summary>
        public static Uniform2f glUniform2f = _<Uniform2f>();

        /// <summary>
        ///     The uniform 3f
        /// </summary>
        public static Uniform3f glUniform3f = _<Uniform3f>();

        /// <summary>
        ///     The uniform 4f
        /// </summary>
        public static Uniform4f glUniform4f = _<Uniform4f>();

        /// <summary>
        ///     The uniform 1i
        /// </summary>
        public static Uniform1i glUniform1i = _<Uniform1i>();

        /// <summary>
        ///     The uniform 3fv
        /// </summary>
        public static Uniform3fv glUniform3fv = _<Uniform3fv>();

        /// <summary>
        ///     The uniform 4fv
        /// </summary>
        public static Uniform4fv glUniform4fv = _<Uniform4fv>();

        /// <summary>
        ///     The uniform matrix 3fv del
        /// </summary>
        public static UniformMatrix3fvDel glUniformMatrix3fv = _Del<UniformMatrix3fvDel>();

        /// <summary>
        ///     The uniform matrix 4fv del
        /// </summary>
        public static UniformMatrix4fvDel glUniformMatrix4fv = _Del<UniformMatrix4fvDel>();

        /// <summary>
        ///     The bind sampler
        /// </summary>
        public static BindSampler glBindSampler = _<BindSampler>();

        /// <summary>
        ///     The bind vertex array
        /// </summary>
        public static BindVertexArray glBindVertexArray = _<BindVertexArray>();

        /// <summary>
        ///     The bind buffer
        /// </summary>
        public static BindBuffer glBindBuffer = _<BindBuffer>();

        /// <summary>
        ///     The enable vertex attrib array del
        /// </summary>
        public static EnableVertexAttribArrayDel glEnableVertexAttribArray = _Del<EnableVertexAttribArrayDel>();

        /// <summary>
        ///     The disable vertex attrib array
        /// </summary>
        public static DisableVertexAttribArray glDisableVertexAttribArray = _<DisableVertexAttribArray>();

        /// <summary>
        ///     The vertex attrib pointer del
        /// </summary>
        public static VertexAttribPointerDel glVertexAttribPointer = _Del<VertexAttribPointerDel>();

        /// <summary>
        ///     The bind texture
        /// </summary>
        public static BindTexture glBindTexture = _<BindTexture>();

        /// <summary>
        ///     The buffer data
        /// </summary>
        public static BufferData glBufferData = _<BufferData>();

        /// <summary>
        ///     The scissor
        /// </summary>
        public static Scissor glScissor = _<Scissor>();

        /// <summary>
        ///     The draw elements base vertex
        /// </summary>
        public static DrawElementsBaseVertex glDrawElementsBaseVertex = _<DrawElementsBaseVertex>();

        /// <summary>
        ///     The delete vertex arrays
        /// </summary>
        public static DeleteVertexArrays glDeleteVertexArrays = _<DeleteVertexArrays>();

        /// <summary>
        ///     The gen vertex arrays
        /// </summary>
        public static GenVertexArrays glGenVertexArrays = _<GenVertexArrays>();

        /// <summary>
        ///     The gen textures
        /// </summary>
        public static GenTextures glGenTextures = _<GenTextures>();

        /// <summary>
        ///     The pixel storei
        /// </summary>
        public static PixelStorei glPixelStorei = _<PixelStorei>();

        /// <summary>
        ///     The tex image
        /// </summary>
        public static TexImage2D glTexImage2D = _<TexImage2D>();

        /// <summary>
        ///     The tex parameteri
        /// </summary>
        public static TexParameteri glTexParameteri = _<TexParameteri>();

        /// <summary>
        ///     The delete textures
        /// </summary>
        public static DeleteTextures glDeleteTextures = _<DeleteTextures>();

        /// <summary>
        ///     S
        /// </summary>
        /// <typeparam name="T">The </typeparam>
        /// <exception cref="Exception">nogo: {method} from {typeof(T).Name}</exception>
        /// <returns>The</returns>
        private static T _<T>() where T : class
        {
            string method = "gl" + typeof(T).Name;
            IntPtr ptr = SDL_GL_GetProcAddress(method);
            if (ptr == IntPtr.Zero)
            {
                throw new Exception($"nogo: {method} from {typeof(T).Name}");
            }

            return Marshal.GetDelegateForFunctionPointer(ptr, typeof(T)) as T;
        }

        /// <summary>
        ///     Alternate delegate fetcher for when our delegate Type ends in "Del". These happen when the method needs a wrapper
        ///     in GL.Utils.
        /// </summary>
        private static T _Del<T>() where T : class
        {
            string method = "gl" + typeof(T).Name.Substring(0, typeof(T).Name.Length - 3);
            IntPtr ptr = SDL_GL_GetProcAddress(method);
            if (ptr == IntPtr.Zero)
            {
                throw new Exception($"nogo: {method} from {typeof(T).Name}");
            }

            return Marshal.GetDelegateForFunctionPointer(ptr, typeof(T)) as T;
        }

        /// <summary>
        ///     Gls the get string using the specified pname
        /// </summary>
        /// <param name="pname">The pname</param>
        /// <returns>The string</returns>
        public static unsafe string glGetString(StringName pname) => new string((sbyte*) _GetString(pname));


        /// <summary>
        ///     The get string
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        private delegate IntPtr GetString(StringName pname);
    }
}