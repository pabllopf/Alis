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
//  --------------------------------------------------------------------------

using System;
using System.Runtime.InteropServices;
using System.Text;
using Alis.Core.Aspect.Math.Matrix;
using Alis.Core.Graphic.OpenGL.Delegates;
using Alis.Core.Graphic.OpenGL.Enums;

namespace Alis.Core.Graphic.OpenGL
{
    /// <summary>
    /// Provides a managed wrapper around OpenGL functions loaded at runtime via platform-specific GetProcAddress.
    /// All OpenGL commands are exposed as static delegates that are resolved dynamically,
    /// enabling cross-platform support for Windows, macOS, Linux, and WebAssembly.
    /// </summary>
    public static class Gl
    {
        /// <summary>
        /// Activates the specified texture unit for subsequent texture binding operations.
        /// </summary>
        /// <param name="texture">The texture unit to activate.</param>
        public delegate void ActiveTexture(TextureUnit texture);

        /// <summary>
        /// Binds a framebuffer object to the specified target.
        /// </summary>
        /// <param name="target">The framebuffer target (e.g., Framebuffer).</param>
        /// <param name="framebuffer">The framebuffer object name.</param>
        public delegate void BindFramebuffer(FramebufferTarget target, uint framebuffer);

        /// <summary>
        /// Attaches a texture as a buffer attachment point to a framebuffer object.
        /// </summary>
        /// <param name="target">The framebuffer target.</param>
        /// <param name="attachment">The attachment point.</param>
        /// <param name="texTarget">The texture target.</param>
        /// <param name="texture">The texture object name.</param>
        /// <param name="level">The mipmap level of the texture to attach.</param>
        public delegate void FramebufferTexture2D(FramebufferTarget target, FramebufferAttachment attachment, TextureTarget texTarget, uint texture, int level);

        /// <summary>
        /// Generates a single framebuffer object name.
        /// </summary>
        /// <returns>The generated framebuffer object name.</returns>
        public delegate uint GenFramebuffer();

        /// <summary>
        /// Returns the value of a specified OpenGL integer parameter.
        /// </summary>
        /// <param name="pname">The parameter name to query.</param>
        /// <param name="data">The array that receives the parameter value(s).</param>
        public delegate void GetIntegerv(int pname, int[] data);

        /// <summary>
        /// Delegate for loading OpenGL function pointers from the platform.
        /// </summary>
        /// <param name="procName">The name of the OpenGL function to load.</param>
        /// <returns>A pointer to the function, or IntPtr.Zero if not found.</returns>
        public delegate IntPtr GetProcAddressDelegate(string procName);

        /// <summary>
        /// Sets the width of rasterized lines.
        /// </summary>
        /// <param name="width">The width of the line in pixels.</param>
        public delegate void LineWidth(float width);

        /// <summary>
        /// Reads a block of pixels from the framebuffer.
        /// </summary>
        /// <param name="x">The x-coordinate of the lower-left corner.</param>
        /// <param name="y">The y-coordinate of the lower-left corner.</param>
        /// <param name="width">The width of the pixel rectangle.</param>
        /// <param name="height">The height of the pixel rectangle.</param>
        /// <param name="format">The pixel format of the output data.</param>
        /// <param name="type">The data type of the pixel data.</param>
        /// <param name="pixels">A pointer to the output buffer.</param>
        public delegate void ReadPixels(int x, int y, int width, int height, PixelFormat format, PixelType type, IntPtr pixels);

        /// <summary>
        /// Sets a 2x3 float matrix uniform value.
        /// </summary>
        /// <param name="location">The uniform location.</param>
        /// <param name="count">The number of matrices.</param>
        /// <param name="transpose">Whether to transpose the matrix.</param>
        /// <param name="value">The matrix values.</param>
        public delegate void UniformMatrix2x3FvDel(int location, int count, bool transpose, Span<float> value);

        /// <summary>
        /// The cached GetProcAddress delegate used to resolve OpenGL function pointers.
        /// </summary>
        private static GetProcAddressDelegate _getProcAddress;

        /// <summary>
        /// Reusable 1-element uint array for buffer/texture/framebuffer name generation.
        /// </summary>
        public static uint[] Uint1 = new uint[1];

        /// <summary>
        /// Reusable 1-element int array for shader/program parameter queries.
        /// </summary>
        public static int[] Int1 = new int[1];

        /// <summary>
        /// Reusable 16-element float array for matrix4x4 uniform uploads.
        /// </summary>
        public static float[] Matrix4Float = new float[16];

        // ---------------------------------------------------------------
        // OpenGL function delegates resolved via GetProcAddress
        // ---------------------------------------------------------------

        /// <summary>Gets the GetString delegate resolved from "glGetString".</summary>
        public static GetString GetString => GetCommand<GetString>("glGetString");

        /// <summary>Gets the GenBuffers delegate resolved from "glGenBuffers".</summary>
        public static GenBuffers GlGenBuffers => GetCommand<GenBuffers>("glGenBuffers");

        /// <summary>Gets the DeleteBuffers delegate resolved from "glDeleteBuffers".</summary>
        public static DeleteBuffers GlDeleteBuffers => GetCommand<DeleteBuffers>("glDeleteBuffers");

        /// <summary>Gets the GetIntegerv delegate resolved from "glGetIntegerv".</summary>
        public static GetIntegerv GlGetIntegerV => GetCommand<GetIntegerv>("glGetIntegerv");

        /// <summary>Gets the Viewport delegate resolved from "glViewport".</summary>
        public static Viewport GlViewport => GetCommand<Viewport>("glViewport");

        /// <summary>Gets the ClearColor delegate resolved from "glClearColor".</summary>
        public static ClearColor GlClearColor => GetCommand<ClearColor>("glClearColor");

        /// <summary>Gets the Color4F delegate resolved from "glColor4f".</summary>
        public static Color4F GlColor4F => GetCommand<Color4F>("glColor4f");

        /// <summary>Gets the End delegate resolved from "glEnd".</summary>
        public static End GlEnd => GetCommand<End>("glEnd");

        /// <summary>Gets the Clear delegate resolved from "glClear".</summary>
        public static Clear GlClear => GetCommand<Clear>("glClear");

        /// <summary>Gets the Enable delegate resolved from "glEnable".</summary>
        public static Enable GlEnable => GetCommand<Enable>("glEnable");

        /// <summary>Gets the Disable delegate resolved from "glDisable".</summary>
        public static Disable GlDisable => GetCommand<Disable>("glDisable");

        /// <summary>Gets the BlendEquation delegate resolved from "glBlendEquation".</summary>
        public static BlendEquation GlBlendEquation => GetCommand<BlendEquation>("glBlendEquation");

        /// <summary>Gets the BlendFunc delegate resolved from "glBlendFunc".</summary>
        public static BlendFunc GlBlendFunc => GetCommand<BlendFunc>("glBlendFunc");

        /// <summary>Gets the UseProgram delegate resolved from "glUseProgram".</summary>
        public static UseProgram GlUseProgram => GetCommand<UseProgram>("glUseProgram");

        /// <summary>Gets the GetShaderiv delegate resolved from "glGetShaderiv".</summary>
        public static GetShaderiv GlGetShaderIv => GetCommand<GetShaderiv>("glGetShaderiv");

        /// <summary>Gets the GetShaderInfoLogDel delegate resolved from "glGetShaderInfoLog".</summary>
        public static GetShaderInfoLogDel GlGetShaderInfoLog => GetCommand<GetShaderInfoLogDel>("glGetShaderInfoLog");

        /// <summary>Gets the CreateShader delegate resolved from "glCreateShader".</summary>
        public static CreateShader GlCreateShader => GetCommand<CreateShader>("glCreateShader");

        /// <summary>Gets the Begin delegate resolved from "glBegin".</summary>
        public static Begin GlBegin => GetCommand<Begin>("glBegin");

        /// <summary>Gets the ShaderSourceDel delegate resolved from "glShaderSource".</summary>
        public static ShaderSourceDel GlShaderSource => GetCommand<ShaderSourceDel>("glShaderSource");

        /// <summary>Gets the CompileShader delegate resolved from "glCompileShader".</summary>
        public static CompileShader GlCompileShader => GetCommand<CompileShader>("glCompileShader");

        /// <summary>Gets the DeleteShader delegate resolved from "glDeleteShader".</summary>
        public static DeleteShader GlDeleteShader => GetCommand<DeleteShader>("glDeleteShader");

        /// <summary>Gets the GetProgramiv delegate resolved from "glGetProgramiv".</summary>
        public static GetProgramiv GlGetProgramiv => GetCommand<GetProgramiv>("glGetProgramiv");

        /// <summary>Gets the GetProgramInfoLogDel delegate resolved from "glGetProgramInfoLog".</summary>
        public static GetProgramInfoLogDel GlGetProgramInfoLog => GetCommand<GetProgramInfoLogDel>("glGetProgramInfoLog");

        /// <summary>Gets the CreateProgram delegate resolved from "glCreateProgram".</summary>
        public static CreateProgram GlCreateProgram => GetCommand<CreateProgram>("glCreateProgram");

        /// <summary>Gets the AttachShader delegate resolved from "glAttachShader".</summary>
        public static AttachShader GlAttachShader => GetCommand<AttachShader>("glAttachShader");

        /// <summary>Gets the LinkProgram delegate resolved from "glLinkProgram".</summary>
        public static LinkProgram GlLinkProgram => GetCommand<LinkProgram>("glLinkProgram");

        /// <summary>Gets the GetUniformLocation delegate resolved from "glGetUniformLocation".</summary>
        public static GetUniformLocation GlGetUniformLocation => GetCommand<GetUniformLocation>("glGetUniformLocation");

        /// <summary>Gets the GetAttribLocation delegate resolved from "glGetAttribLocation".</summary>
        public static GetAttribLocation GlGetAttribLocation => GetCommand<GetAttribLocation>("glGetAttribLocation");

        /// <summary>Gets the DetachShader delegate resolved from "glDetachShader".</summary>
        public static DetachShader GlDetachShader => GetCommand<DetachShader>("glDetachShader");

        /// <summary>Gets the DeleteProgram delegate resolved from "glDeleteProgram".</summary>
        public static DeleteProgram GlDeleteProgram => GetCommand<DeleteProgram>("glDeleteProgram");

        /// <summary>Gets the GetActiveAttrib delegate resolved from "glGetActiveAttrib".</summary>
        public static GetActiveAttrib GlGetActiveAttrib => GetCommand<GetActiveAttrib>("glGetActiveAttrib");

        /// <summary>Gets the GetActiveUniform delegate resolved from "glGetActiveUniform".</summary>
        public static GetActiveUniform GlGetActiveUniform => GetCommand<GetActiveUniform>("glGetActiveUniform");

        /// <summary>Gets the Uniform1F delegate resolved from "glUniform1f".</summary>
        public static Uniform1F GlUniform1F => GetCommand<Uniform1F>("glUniform1f");

        /// <summary>Gets the Uniform2F delegate resolved from "glUniform2f".</summary>
        public static Uniform2F GlUniform2F => GetCommand<Uniform2F>("glUniform2f");

        /// <summary>Gets the Uniform3F delegate resolved from "glUniform3f".</summary>
        public static Uniform3F GlUniform3F => GetCommand<Uniform3F>("glUniform3f");

        /// <summary>Gets the Uniform4F delegate resolved from "glUniform4f".</summary>
        public static Uniform4F GlUniform4F => GetCommand<Uniform4F>("glUniform4f");

        /// <summary>Gets the Uniform1I delegate resolved from "glUniform1i".</summary>
        public static Uniform1I GlUniform1I => GetCommand<Uniform1I>("glUniform1i");

        /// <summary>Gets the Uniform3Fv delegate resolved from "glUniform3fv".</summary>
        private static Uniform3Fv GlUniform3Fv => GetCommand<Uniform3Fv>("glUniform3fv");

        /// <summary>Gets the ReadPixels delegate resolved from "glReadPixels".</summary>
        public static ReadPixels GlReadPixels => GetCommand<ReadPixels>("glReadPixels");

        /// <summary>Gets the GenFramebuffer delegate resolved from "glGenFramebuffers".</summary>
        public static GenFramebuffer GlGenFramebuffer => GetCommand<GenFramebuffer>("glGenFramebuffers");

        /// <summary>Gets the FramebufferTexture2D delegate resolved from "glFramebufferTexture2D".</summary>
        public static FramebufferTexture2D GlFramebufferTexture2D => GetCommand<FramebufferTexture2D>("glFramebufferTexture2D");

        /// <summary>Gets the Uniform4Fv delegate resolved from "glUniform4fv".</summary>
        private static Uniform4Fv GlUniform4Fv => GetCommand<Uniform4Fv>("glUniform4fv");

        /// <summary>Gets the UniformMatrix3FvDel delegate resolved from "glUniformMatrix3fv".</summary>
        public static UniformMatrix3FvDel GlUniformMatrix3Fv => GetCommand<UniformMatrix3FvDel>("glUniformMatrix3fv");

        /// <summary>Gets the UniformMatrix4FvDel delegate resolved from "glUniformMatrix4fv".</summary>
        public static UniformMatrix4FvDel GlUniformMatrix4Fv => GetCommand<UniformMatrix4FvDel>("glUniformMatrix4fv");

        /// <summary>Gets the BindSampler delegate resolved from "glBindSampler".</summary>
        public static BindSampler GlBindSampler => GetCommand<BindSampler>("glBindSampler");

        /// <summary>Gets the BindVertexArray delegate resolved from "glBindVertexArray".</summary>
        public static BindVertexArray GlBindVertexArray => GetCommand<BindVertexArray>("glBindVertexArray");

        /// <summary>Gets the BindBuffer delegate resolved from "glBindBuffer".</summary>
        public static BindBuffer GlBindBuffer => GetCommand<BindBuffer>("glBindBuffer");

        /// <summary>Gets the Vertex2F delegate resolved from "glVertex2f".</summary>
        public static Vertex2F GlVertex2F => GetCommand<Vertex2F>("glVertex2f");

        /// <summary>Gets the TexCoord2F delegate resolved from "glTexCoord2f".</summary>
        public static TexCoord2F GlTexCoord2F => GetCommand<TexCoord2F>("glTexCoord2f");

        /// <summary>Gets the EnableVertexAttribArrayDel delegate resolved from "glEnableVertexAttribArray".</summary>
        public static EnableVertexAttribArrayDel GlEnableVertexAttribArray => GetCommand<EnableVertexAttribArrayDel>("glEnableVertexAttribArray");

        /// <summary>Gets the DisableVertexAttribArray delegate resolved from "glDisableVertexAttribArray".</summary>
        public static DisableVertexAttribArray GlDisableVertexAttribArray => GetCommand<DisableVertexAttribArray>("glDisableVertexAttribArray");

        /// <summary>Gets the VertexAttribPointerDel delegate resolved from "glVertexAttribPointer".</summary>
        public static VertexAttribPointerDel GlVertexAttribPointer => GetCommand<VertexAttribPointerDel>("glVertexAttribPointer");

        /// <summary>Gets the BindFramebuffer delegate resolved from "glBindFramebuffer".</summary>
        public static BindFramebuffer GlBindFramebuffer => GetCommand<BindFramebuffer>("glBindFramebuffer");

        /// <summary>Gets the BindTexture delegate resolved from "glBindTexture".</summary>
        public static BindTexture GlBindTexture => GetCommand<BindTexture>("glBindTexture");

        /// <summary>Gets the BufferData delegate resolved from "glBufferData".</summary>
        public static BufferData GlBufferData => GetCommand<BufferData>("glBufferData");

        /// <summary>Gets the Scissor delegate resolved from "glScissor".</summary>
        public static Scissor GlScissor => GetCommand<Scissor>("glScissor");

        /// <summary>Gets the DrawElementsBaseVertex delegate resolved from "glDrawElementsBaseVertex".</summary>
        public static DrawElementsBaseVertex GlDrawElementsBaseVertex => GetCommand<DrawElementsBaseVertex>("glDrawElementsBaseVertex");

        /// <summary>Gets the DeleteVertexArrays delegate resolved from "glDeleteVertexArrays".</summary>
        public static DeleteVertexArrays GlDeleteVertexArrays => GetCommand<DeleteVertexArrays>("glDeleteVertexArrays");

        /// <summary>Gets the GenVertexArrays delegate resolved from "glGenVertexArrays".</summary>
        public static GenVertexArrays GlGenVertexArrays => GetCommand<GenVertexArrays>("glGenVertexArrays");

        /// <summary>Gets the GenTextures delegate resolved from "glGenTextures".</summary>
        public static GenTextures GlGenTextures => GetCommand<GenTextures>("glGenTextures");

        /// <summary>Gets the Storei delegate resolved from "glPixelStorei".</summary>
        public static Storei GlPixelStorei => GetCommand<Storei>("glPixelStorei");

        /// <summary>Gets the TexImage2D delegate resolved from "glTexImage2D".</summary>
        public static TexImage2D GlTexImage2D => GetCommand<TexImage2D>("glTexImage2D");

        /// <summary>Gets the TexParameteri delegate resolved from "glTexParameteri".</summary>
        public static TexParameteri GlTexParameteri => GetCommand<TexParameteri>("glTexParameteri");

        /// <summary>Gets the DeleteTextures delegate resolved from "glDeleteTextures".</summary>
        public static DeleteTextures GlDeleteTextures => GetCommand<DeleteTextures>("glDeleteTextures");

        /// <summary>Gets the DrawArrays delegate resolved from "glDrawArrays".</summary>
        public static DrawArrays GlDrawArrays => GetCommand<DrawArrays>("glDrawArrays");

        /// <summary>Gets the DrawElements delegate resolved from "glDrawElements".</summary>
        public static DrawElements GlDrawElements => GetCommand<DrawElements>("glDrawElements");

        /// <summary>Gets the PolygonMode delegate resolved from "glPolygonMode".</summary>
        public static PolygonMode GlPolygonMode => GetCommand<PolygonMode>("glPolygonMode");

        /// <summary>Gets the GetError delegate resolved from "glGetError".</summary>
        internal static GetError GlGetErrorDelegate => GetCommand<GetError>("glGetError");

        /// <summary>Gets the LineWidth delegate resolved from "glLineWidth".</summary>
        public static LineWidth GlLineWidthDelegate => GetCommand<LineWidth>("glLineWidth");

        /// <summary>Gets the ActiveTexture delegate resolved from "glActiveTexture".</summary>
        public static ActiveTexture GlActiveTextureDelegate => GetCommand<ActiveTexture>("glActiveTexture");

        /// <summary>
        /// Initializes the OpenGL function pointer resolution system with a platform-specific delegate.
        /// Must be called once before any other OpenGL commands are used.
        /// </summary>
        /// <param name="getProcAddress">The platform delegate that resolves OpenGL function names to function pointers.</param>
        public static void Initialize(GetProcAddressDelegate getProcAddress)
        {
            _getProcAddress = getProcAddress;
        }

        /// <summary>
        /// Resolves an OpenGL function pointer by name and returns it as a managed delegate.
        /// </summary>
        /// <typeparam name="T">The delegate type for the OpenGL function.</typeparam>
        /// <param name="command">The name of the OpenGL function to resolve.</param>
        /// <returns>A delegate of type T that wraps the native OpenGL function.</returns>
        /// <exception cref="InvalidOperationException">Thrown when Initialize has not been called before this method.</exception>
        /// <exception cref="ExternalException">Thrown when the specified function cannot be resolved from the OpenGL driver.</exception>
        private static T GetCommand<T>(string command) where T : class
        {
            if (_getProcAddress == null)
            {
                throw new InvalidOperationException("Inicialize called before Initialize");
            }

            IntPtr ptr = _getProcAddress(command);
            if (ptr == IntPtr.Zero)
            {
                throw new ExternalException($"{command} from {nameof(T)}");
            }

            return Marshal.GetDelegateForFunctionPointer<T>(ptr);
        }

        /// <summary>
        /// Retrieves an OpenGL string value (vendor, renderer, version, etc.) as a managed string.
        /// </summary>
        /// <param name="pname">The symbolic constant identifying the string to query.</param>
        /// <returns>The requested string, or <see cref="string.Empty"/> if the pointer is null.</returns>
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
        /// Generates a single buffer object name and returns it.
        /// </summary>
        /// <returns>The generated buffer object name (uint).</returns>
        public static uint GenBuffer()
        {
            Uint1[0] = 0;
            GlGenBuffers(1, Uint1);
            return Uint1[0];
        }

        /// <summary>
        /// Deletes a single buffer object, freeing its OpenGL resources.
        /// </summary>
        /// <param name="buffer">The buffer object name to delete.</param>
        public static void DeleteBuffer(uint buffer)
        {
            Uint1[0] = 0;
            GlDeleteBuffers(1, Uint1);
            Uint1[0] = 0;
        }

        /// <summary>
        /// Retrieves the compilation or linking info log for a shader object.
        /// </summary>
        /// <param name="shader">The shader object to query.</param>
        /// <returns>The info log string, or <see cref="string.Empty"/> if empty.</returns>
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
        /// Sets the source code for a shader object from a managed string.
        /// </summary>
        /// <param name="shader">The shader object to set source on.</param>
        /// <param name="source">The GLSL source code string.</param>
        public static void ShaderSource(uint shader, string source)
        {
            Int1[0] = source.Length;
            GlShaderSource(shader, 1, new[] {source}, Int1);
        }

        /// <summary>
        /// Queries whether a shader compiled successfully.
        /// </summary>
        /// <param name="shader">The shader object to check.</param>
        /// <returns>True if compilation succeeded, false otherwise.</returns>
        public static bool GetShaderCompileStatus(uint shader)
        {
            GlGetShaderIv(shader, ShaderParameter.CompileStatus, Int1);
            return Int1[0] == 1;
        }

        /// <summary>
        /// Retrieves the info log for a program object.
        /// </summary>
        /// <param name="program">The program object to query.</param>
        /// <returns>The info log string, or <see cref="string.Empty"/> if empty.</returns>
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
        /// Queries whether a program linked successfully.
        /// </summary>
        /// <param name="program">The program object to check.</param>
        /// <returns>True if linking succeeded, false otherwise.</returns>
        public static bool GetProgramLinkStatus(uint program)
        {
            GlGetProgramiv(program, ProgramParameter.LinkStatus, Int1);
            return Int1[0] == 1;
        }

        /// <summary>
        /// Sets a 4x4 float matrix uniform by converting a <see cref="Matrix4X4"/> into a flat float array.
        /// </summary>
        /// <param name="location">The uniform location.</param>
        /// <param name="param">The matrix value to upload.</param>
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
        /// Configures a vertex attribute pointer with validation for negative indices.
        /// </summary>
        /// <param name="index">The vertex attribute index (must be >= 0).</param>
        /// <param name="size">The number of components per vertex.</param>
        /// <param name="type">The data type of each component.</param>
        /// <param name="normalized">Whether to normalize fixed-point values.</param>
        /// <param name="stride">The byte stride between consecutive attributes.</param>
        /// <param name="pointer">The offset into the bound vertex buffer.</param>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when index is negative.</exception>
        public static void VertexAttribPointer(int index, int size, VertexAttribPointerType type, bool normalized, int stride, IntPtr pointer)
        {
            if (index < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(index));
            }

            GlVertexAttribPointer((uint) index, size, type, normalized, stride, pointer);
        }

        /// <summary>
        /// Enables a vertex attribute array with validation for negative indices.
        /// </summary>
        /// <param name="index">The vertex attribute index (must be >= 0).</param>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when index is negative.</exception>
        public static void EnableVertexAttribArray(int index)
        {
            if (index < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(index));
            }

            GlEnableVertexAttribArray((uint) index);
        }

        /// <summary>
        /// Generates a single vertex array object name.
        /// </summary>
        /// <returns>The generated VAO name.</returns>
        public static uint GenVertexArray()
        {
            Uint1[0] = 0;
            GlGenVertexArrays(1, Uint1);
            return Uint1[0];
        }

        /// <summary>
        /// Deletes a single vertex array object.
        /// </summary>
        /// <param name="vao">The VAO name to delete.</param>
        public static void DeleteVertexArray(uint vao)
        {
            Uint1[0] = vao;
            GlDeleteVertexArrays(1, Uint1);
        }

        /// <summary>
        /// Generates a single texture object name.
        /// </summary>
        /// <returns>The generated texture name.</returns>
        public static uint GenTexture()
        {
            Uint1[0] = 0;
            GlGenTextures(1, Uint1);
            return Uint1[0];
        }

        /// <summary>
        /// Deletes a single texture object.
        /// </summary>
        /// <param name="texture">The texture name to delete.</param>
        public static void DeleteTexture(uint texture)
        {
            Uint1[0] = texture;
            GlDeleteTextures(1, Uint1);
        }

        /// <summary>
        /// Generates mipmaps for the specified texture target.
        /// </summary>
        /// <param name="texture2D">The texture target (e.g., Texture2D).</param>
        public static void GenerateMipmap(TextureTarget texture2D) => GetCommand<GetString>("glGenerateMipmap");

        /// <summary>
        /// Gets the last error code from OpenGL.
        /// </summary>
        /// <returns>The OpenGL error code (int).</returns>
        public static int GlGetError() => GlGetErrorDelegate();

        /// <summary>
        /// Sets the line width using the resolved LineWidth delegate.
        /// </summary>
        /// <param name="width">The line width in pixels.</param>
        public static void GlLineWidth(float width)
        {
            GlLineWidthDelegate(width);
        }

        /// <summary>
        /// Activates the specified texture unit using the resolved ActiveTexture delegate.
        /// </summary>
        /// <param name="texture">The texture unit to activate.</param>
        public static void GlActiveTexture(TextureUnit texture)
        {
            GlActiveTextureDelegate(texture);
        }

        /// <summary>
        /// Queries an integer OpenGL parameter value.
        /// </summary>
        /// <param name="i">The parameter name to query.</param>
        /// <param name="viewport">The array that receives the parameter values.</param>
        public static void GlGetIntegerv(int i, int[] viewport)
        {
            GetIntegerv getIntegerv = GetCommand<GetIntegerv>("glGetIntegerv");
            GlGetIntegerV(i, viewport);
        }

        /// <summary>
        /// Queries a shader parameter (e.g., compile status) via the resolved delegate.
        /// </summary>
        /// <param name="vertexShader">The shader object to query.</param>
        /// <param name="compileStatus">The parameter to query (typically CompileStatus).</param>
        /// <param name="i">Outputs the parameter value.</param>
        public static void GlGetShader(uint vertexShader, object compileStatus, out int i)
        {
            GlGetShaderIv(vertexShader, (ShaderParameter) compileStatus, Int1);
            i = Int1[0];
        }

        /// <summary>
        /// Queries a program parameter (e.g., link status) via the resolved delegate.
        /// </summary>
        /// <param name="shaderProgram">The program object to query.</param>
        /// <param name="linkStatus">The parameter to query (typically LinkStatus).</param>
        /// <param name="res">Outputs the parameter value.</param>
        public static void GlGetProgram(uint shaderProgram, object linkStatus, out int res)
        {
            GlGetProgramiv(shaderProgram, (ProgramParameter) linkStatus, Int1);
            res = Int1[0];
        }

        /// <summary>
        /// Sets a 2x3 float matrix uniform using the dynamically resolved function.
        /// </summary>
        /// <param name="viewProjectionLocation">The uniform location.</param>
        /// <param name="b">Whether to transpose the matrix.</param>
        /// <param name="matrix">The matrix values as a span of floats.</param>
        public static void GlUniformMatrix2x3(int viewProjectionLocation, bool b, Span<float> matrix)
        {
            GetCommand<UniformMatrix2x3FvDel>("glUniformMatrix2x3fv")(viewProjectionLocation, 1, b, matrix);
        }

        /// <summary>
        /// Internal delegate for the OpenGL glGetError function.
        /// </summary>
        internal delegate int GetError();
    }
}
