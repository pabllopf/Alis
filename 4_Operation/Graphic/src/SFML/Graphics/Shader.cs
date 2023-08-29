// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:Shader.cs
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
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using Alis.Core.Aspect.Base.Attributes;
using Alis.Core.Aspect.Base.Exceptions;
using Alis.Core.Aspect.Base.Settings;
using Alis.Core.Aspect.Math.Matrix;
using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Aspect.Memory.Streams.SFML;
using Alis.Core.Graphic.SFML.Windows;

namespace Alis.Core.Graphic.SFML.Graphics
{
    ////////////////////////////////////////////////////////////
    /// <summary>
    ///     Wrapper for pixel shaders
    /// </summary>
    ////////////////////////////////////////////////////////////
    public class Shader : ObjectBase
    {
        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Special value that can be passed to SetParameter,
        ///     and that represents the texture of the object being drawn
        /// </summary>
        ////////////////////////////////////////////////////////////
        public static readonly CurrentTextureType CurrentTexture = null;

        // Keeps references to used Textures for GC prevention during use
        /// <summary>
        ///     The texture
        /// </summary>
        private readonly Dictionary<string, Texture> myTextures = new Dictionary<string, Texture>();

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Load the vertex, geometry and fragment shaders from files
        /// </summary>
        /// <remarks>
        ///     This function loads the vertex, geometry and fragment
        ///     shaders. Pass NULL if you don't want to load
        ///     a specific shader.
        ///     The sources must be text files containing valid shaders
        ///     in GLSL language. GLSL is a C-like language dedicated to
        ///     OpenGL shaders; you'll probably need to read a good documentation
        ///     for it before writing your own shaders.
        /// </remarks>
        /// <param name="vertexShaderFilename">Path of the vertex shader file to load, or null to skip this shader</param>
        /// <param name="geometryShaderFilename">Path of the geometry shader file to load, or null to skip this shader</param>
        /// <param name="fragmentShaderFilename">Path of the fragment shader file to load, or null to skip this shader</param>
        /// <exception cref="LoadingFailedException" />
        ////////////////////////////////////////////////////////////
        public Shader(string vertexShaderFilename, string geometryShaderFilename, string fragmentShaderFilename) :
            base(sfShader_createFromFile(vertexShaderFilename, geometryShaderFilename, fragmentShaderFilename))
        {
            if (CPointer == IntPtr.Zero)
            {
                throw new LoadingFailedException("shader", vertexShaderFilename + " " + fragmentShaderFilename);
            }
        }

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Load the vertex, geometry and fragment shaders from custom streams
        /// </summary>
        /// <remarks>
        ///     This function loads the vertex, geometry and fragment
        ///     shaders. Pass NULL if you don't want to load
        ///     a specific shader.
        ///     The sources must be valid shaders in GLSL language. GLSL is
        ///     a C-like language dedicated to OpenGL shaders; you'll
        ///     probably need to read a good documentation for it before
        ///     writing your own shaders.
        /// </remarks>
        /// <param name="vertexShaderStream">Source stream to read the vertex shader from, or null to skip this shader</param>
        /// <param name="geometryShaderStream">Source stream to read the geometry shader from, or null to skip this shader</param>
        /// <param name="fragmentShaderStream">Source stream to read the fragment shader from, or null to skip this shader</param>
        /// <exception cref="LoadingFailedException" />
        ////////////////////////////////////////////////////////////
        public Shader(Stream vertexShaderStream, Stream geometryShaderStream, Stream fragmentShaderStream) :
            base(IntPtr.Zero)
        {
            // using these funky conditional operators because StreamAdaptor doesn't have some method for dealing with
            // its constructor argument being null
            using (StreamAdaptor vertexAdaptor =
                   vertexShaderStream != null ? new StreamAdaptor(vertexShaderStream) : null,
                   geometryAdaptor = geometryShaderStream != null ? new StreamAdaptor(geometryShaderStream) : null,
                   fragmentAdaptor = fragmentShaderStream != null ? new StreamAdaptor(fragmentShaderStream) : null)
            {
                CPointer = sfShader_createFromStream(vertexAdaptor != null ? vertexAdaptor.InputStreamPtr : IntPtr.Zero,
                    geometryAdaptor != null ? geometryAdaptor.InputStreamPtr : IntPtr.Zero,
                    fragmentAdaptor != null ? fragmentAdaptor.InputStreamPtr : IntPtr.Zero);
            }

            if (CPointer == IntPtr.Zero)
            {
                throw new LoadingFailedException("shader");
            }
        }

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Construct the shader from a pointer
        /// </summary>
        /// <param name="ptr">Pointer to the shader instance</param>
        ////////////////////////////////////////////////////////////
        public Shader(IntPtr ptr) :
            base(ptr)
        {
        }

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Get the underlying OpenGL handle of the shader.
        /// </summary>
        /// <remarks>
        ///     You shouldn't need to use this handle, unless you have
        ///     very specific stuff to implement that SFML doesn't support.
        /// </remarks>
        ////////////////////////////////////////////////////////////
        public uint NativeHandle => sfShader_getNativeHandle(CPointer);

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Tell whether or not the system supports shaders.
        /// </summary>
        /// <remarks>
        ///     This property should always be checked before using
        ///     the shader features. If it returns false, then
        ///     any attempt to use Shader will fail.
        /// </remarks>
        ////////////////////////////////////////////////////////////
        public static bool IsAvailable => sfShader_isAvailable();

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Tell whether or not the system supports geometry shaders.
        /// </summary>
        /// <remarks>
        ///     <para>
        ///         This property should always be checked before using
        ///         the geometry shader features. If it returns false, then
        ///         any attempt to use geometry shader features will fail.
        ///     </para>
        ///     <para>
        ///         Note: The first call to this function, whether by your
        ///         code or SFML will result in a context switch.
        ///     </para>
        /// </remarks>
        ////////////////////////////////////////////////////////////
        public static bool IsGeometryAvailable => sfShader_isGeometryAvailable();

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Load the vertex, geometry and fragment shaders from source code in memory
        /// </summary>
        /// <remarks>
        ///     This function loads the vertex, geometry and fragment
        ///     shaders. Pass NULL if you don't want to load
        ///     a specific shader.
        ///     The sources must be valid shaders in GLSL language. GLSL is
        ///     a C-like language dedicated to OpenGL shaders; you'll
        ///     probably need to read a good documentation for it before
        ///     writing your own shaders.
        /// </remarks>
        /// <param name="vertexShader">String containing the source code of the vertex shader</param>
        /// <param name="geometryShader">String containing the source code of the geometry shader</param>
        /// <param name="fragmentShader">String containing the source code of the fragment shader</param>
        /// <returns>New shader instance</returns>
        /// <exception cref="LoadingFailedException" />
        ////////////////////////////////////////////////////////////
        public static Shader FromString(string vertexShader, string geometryShader, string fragmentShader)
        {
            IntPtr ptr = sfShader_createFromMemory(vertexShader, geometryShader, fragmentShader);
            if (ptr == IntPtr.Zero)
            {
                throw new LoadingFailedException("shader");
            }

            return new Shader(ptr);
        }

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Specify value for <c>float</c> uniform
        /// </summary>
        /// <param name="name">Name of the uniform variable in GLSL</param>
        /// <param name="x">Value of the float scalar</param>
        ////////////////////////////////////////////////////////////
        public void SetUniform(string name, float x)
        {
            sfShader_setFloatUniform(CPointer, name, x);
        }

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Specify value for <c>vec2</c> uniform
        /// </summary>
        /// <param name="name">Name of the uniform variable in GLSL</param>
        /// <param name="vector">Value of the vec2 vector</param>
        ////////////////////////////////////////////////////////////
        public void SetUniform(string name, Vector2 vector)
        {
            sfShader_setVec2Uniform(CPointer, name, vector);
        }

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Specify value for <c>vec3</c> uniform
        /// </summary>
        /// <param name="name">Name of the uniform variable in GLSL</param>
        /// <param name="vector">Value of the vec3 vector</param>
        ////////////////////////////////////////////////////////////
        public void SetUniform(string name, Vector3 vector)
        {
            sfShader_setVec3Uniform(CPointer, name, vector);
        }

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Specify value for <c>vec4</c> uniform
        /// </summary>
        /// <param name="name">Name of the uniform variable in GLSL</param>
        /// <param name="vector">Value of the vec4 vector</param>
        ////////////////////////////////////////////////////////////
        public void SetUniform(string name, Vector4 vector)
        {
            sfShader_setVec4Uniform(CPointer, name, vector);
        }

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Specify value for <c>int</c> uniform
        /// </summary>
        /// <param name="name">Name of the uniform variable in GLSL</param>
        /// <param name="x">Value of the int scalar</param>
        ////////////////////////////////////////////////////////////
        public void SetUniform(string name, int x)
        {
            sfShader_setIntUniform(CPointer, name, x);
        }

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Specify value for <c>ivec2</c> uniform
        /// </summary>
        /// <param name="name">Name of the uniform variable in GLSL</param>
        /// <param name="vector">Value of the ivec2 vector</param>
        ////////////////////////////////////////////////////////////
        public void SetUniform(string name, Vector2I vector)
        {
            sfShader_setIvec2Uniform(CPointer, name, vector);
        }

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Specify value for <c>ivec3</c> uniform
        /// </summary>
        /// <param name="name">Name of the uniform variable in GLSL</param>
        /// <param name="vector">Value of the ivec3 vector</param>
        ////////////////////////////////////////////////////////////
        public void SetUniform(string name, Vector3I vector)
        {
            sfShader_setIvec3Uniform(CPointer, name, vector);
        }

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Specify value for <c>ivec4</c> uniform
        /// </summary>
        /// <param name="name">Name of the uniform variable in GLSL</param>
        /// <param name="vector">Value of the ivec4 vector</param>
        ////////////////////////////////////////////////////////////
        public void SetUniform(string name, Vector4I vector)
        {
            sfShader_setIvec4Uniform(CPointer, name, vector);
        }

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Specify value for <c>bool</c> uniform
        /// </summary>
        /// <param name="name">Name of the uniform variable in GLSL</param>
        /// <param name="x">Value of the bool scalar</param>
        ////////////////////////////////////////////////////////////
        public void SetUniform(string name, bool x)
        {
            sfShader_setBoolUniform(CPointer, name, x);
        }

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Specify value for <c>bvec2</c> uniform
        /// </summary>
        /// <param name="name">Name of the uniform variable in GLSL</param>
        /// <param name="vector">Value of the bvec2 vector</param>
        ////////////////////////////////////////////////////////////
        public void SetUniform(string name, Vector2B vector)
        {
            sfShader_setBvec2Uniform(CPointer, name, vector);
        }

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Specify value for <c>bvec3</c> uniform
        /// </summary>
        /// <param name="name">Name of the uniform variable in GLSL</param>
        /// <param name="vector">Value of the bvec3 vector</param>
        ////////////////////////////////////////////////////////////
        public void SetUniform(string name, Vector3B vector)
        {
            sfShader_setBvec3Uniform(CPointer, name, vector);
        }

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Specify value for <c>bvec4</c> uniform
        /// </summary>
        /// <param name="name">Name of the uniform variable in GLSL</param>
        /// <param name="vector">Value of the bvec4 vector</param>
        ////////////////////////////////////////////////////////////
        public void SetUniform(string name, Vector4B vector)
        {
            sfShader_setBvec4Uniform(CPointer, name, vector);
        }

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Specify value for <c>mat3</c> uniform
        /// </summary>
        /// <param name="name">Name of the uniform variable in GLSL</param>
        /// <param name="matrix">Value of the mat3 matrix</param>
        ////////////////////////////////////////////////////////////
        public void SetUniform(string name, Matrix3X3F matrix)
        {
            sfShader_setMat3Uniform(CPointer, name, matrix);
        }

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Specify value for <c>mat4</c> uniform
        /// </summary>
        /// <param name="name">Name of the uniform variable in GLSL</param>
        /// <param name="matrix">Value of the mat4 matrix</param>
        ////////////////////////////////////////////////////////////
        public void SetUniform(string name, Matrix4X4F matrix)
        {
            sfShader_setMat4Uniform(CPointer, name, matrix);
        }

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Specify a texture as <c>sampler2D</c> uniform
        /// </summary>
        /// <remarks>
        ///     <para>
        ///         name is the name of the variable to change in the shader.
        ///         The corresponding parameter in the shader must be a 2D texture
        ///         (<c>sampler2D</c> GLSL type).
        ///     </para>
        ///     <para>
        ///         Example:
        ///         <code>
        /// uniform sampler2D the_texture; // this is the variable in the shader
        /// </code>
        ///         <code>
        /// sf::Texture texture;
        /// ...
        /// shader.setUniform("the_texture", texture);
        /// </code>
        ///         It is important to note that <paramref name="texture" /> must remain alive as long
        ///         as the shader uses it, no copy is made internally.
        ///     </para>
        ///     <para>
        ///         To use the texture of the object being drawn, which cannot be
        ///         known in advance, you can pass the special value
        ///         Shader.CurrentTexture:
        ///         <code>
        /// shader.setUniform("the_texture", Shader.CurrentTexture);
        /// </code>
        ///     </para>
        /// </remarks>
        /// <param name="name">Name of the texture in the shader</param>
        /// <param name="texture">Texture to assign</param>
        ////////////////////////////////////////////////////////////
        public void SetUniform(string name, Texture texture)
        {
            // Keep a reference to the Texture so it doesn't get GC'd
            myTextures[name] = texture;
            sfShader_setTextureUniform(CPointer, name, texture.CPointer);
        }

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Specify current texture as \p sampler2D uniform
        /// </summary>
        /// <remarks>
        ///     <para>
        ///         This overload maps a shader texture variable to the
        ///         texture of the object being drawn, which cannot be
        ///         known in advance. The second argument must be
        ///         <see cref="CurrentTexture" />.
        ///         The corresponding parameter in the shader must be a 2D texture
        ///         (<c>sampler2D</c> GLSL type).
        ///     </para>
        ///     <para>
        ///         Example:
        ///         <code>
        /// uniform sampler2D current; // this is the variable in the shader
        /// </code>
        ///         <code>
        /// shader.setUniform("current", Shader.CurrentTexture);
        /// </code>
        ///     </para>
        /// </remarks>
        /// <param name="name">Name of the texture in the shader</param>
        /// <param name="current" />
        ////////////////////////////////////////////////////////////
        public void SetUniform(string name, CurrentTextureType current)
        {
            sfShader_setCurrentTextureUniform(CPointer, name);
        }

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Specify values for <c>float[]</c> array uniforms
        /// </summary>
        /// <param name="name">Name of the uniform variable in GLSL</param>
        /// <param name="array">array of <c>float</c> values</param>
        ////////////////////////////////////////////////////////////
        public void SetUniformArray(string name, float[] array)
        {
            sfShader_setFloatUniformArray(CPointer, name, array, (uint) array.Length);
        }

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Specify values for <c>vec2[]</c> array uniforms
        /// </summary>
        /// <param name="name">Name of the uniform variable in GLSL</param>
        /// <param name="array">array of <c>vec2</c> values</param>
        ////////////////////////////////////////////////////////////
        public void SetUniformArray(string name, Vector2[] array)
        {
            sfShader_setVec2UniformArray(CPointer, name, array, (uint) array.Length);
        }

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Specify values for <c>vec3[]</c> array uniforms
        /// </summary>
        /// <param name="name">Name of the uniform variable in GLSL</param>
        /// <param name="array">array of <c>vec3</c> values</param>
        ////////////////////////////////////////////////////////////
        public void SetUniformArray(string name, Vector3[] array)
        {
            sfShader_setVec3UniformArray(CPointer, name, array, (uint) array.Length);
        }

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Specify values for <c>vec4[]</c> array uniforms
        /// </summary>
        /// <param name="name">Name of the uniform variable in GLSL</param>
        /// <param name="array">array of <c>vec4</c> values</param>
        ////////////////////////////////////////////////////////////
        public void SetUniformArray(string name, Vector4[] array)
        {
            sfShader_setVec4UniformArray(CPointer, name, array, (uint) array.Length);
        }

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Specify values for <c>mat3[]</c> array uniforms
        /// </summary>
        /// <param name="name">Name of the uniform variable in GLSL</param>
        /// <param name="array">array of <c>mat3</c> values</param>
        ////////////////////////////////////////////////////////////
        public void SetUniformArray(string name, Matrix3X3F array)
        {
            sfShader_setMat3UniformArray(CPointer, name, array, 9);
        }

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Specify values for <c>mat4[]</c> array uniforms
        /// </summary>
        /// <param name="name">Name of the uniform variable in GLSL</param>
        /// <param name="array">array of <c>mat4</c> values</param>
        ////////////////////////////////////////////////////////////
        public void SetUniformArray(string name, Matrix4X4F[] array)
        {
            sfShader_setMat4UniformArray(CPointer, name, array, (uint) array.Length);
        }

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Bind a shader for rendering
        /// </summary>
        /// <param name="shader">Shader to bind (can be null to use no shader)</param>
        ////////////////////////////////////////////////////////////
        public static void Bind(Shader shader)
        {
            sfShader_bind(shader != null ? shader.CPointer : IntPtr.Zero);
        }

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Provide a string describing the object
        /// </summary>
        /// <returns>String description of the object</returns>
        ////////////////////////////////////////////////////////////
        public override string ToString() => "[Shader]";

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Handle the destruction of the object
        /// </summary>
        /// <param name="disposing">Is the GC disposing the object, or is it an explicit call ?</param>
        ////////////////////////////////////////////////////////////
        protected override void Destroy(bool disposing)
        {
            if (!disposing)
            {
                Context.Global.SetActive(true);
            }

            myTextures.Clear();
            sfShader_destroy(CPointer);

            if (!disposing)
            {
                Context.Global.SetActive(false);
            }
        }

        /// <summary>
        ///     Sfs the shader create from file using the specified vertex shader filename
        /// </summary>
        /// <param name="vertexShaderFilename">The vertex shader filename</param>
        /// <param name="geometryShaderFilename">The geometry shader filename</param>
        /// <param name="fragmentShaderFilename">The fragment shader filename</param>
        /// <returns>The int ptr</returns>
        [DllImport(Csfml.Graphics, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        private static extern IntPtr sfShader_createFromFile(string vertexShaderFilename, string geometryShaderFilename,
            string fragmentShaderFilename);

        /// <summary>
        ///     Sfs the shader create from memory using the specified vertex shader
        /// </summary>
        /// <param name="vertexShader">The vertex shader</param>
        /// <param name="geometryShader">The geometry shader</param>
        /// <param name="fragmentShader">The fragment shader</param>
        /// <returns>The int ptr</returns>
        [DllImport(Csfml.Graphics, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        private static extern IntPtr sfShader_createFromMemory(string vertexShader, string geometryShader,
            string fragmentShader);

        /// <summary>
        ///     Sfs the shader create from stream using the specified vertex shader stream
        /// </summary>
        /// <param name="vertexShaderStream">The vertex shader stream</param>
        /// <param name="geometryShaderStream">The geometry shader stream</param>
        /// <param name="fragmentShaderStream">The fragment shader stream</param>
        /// <returns>The int ptr</returns>
        [DllImport(Csfml.Graphics, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        private static extern IntPtr sfShader_createFromStream(IntPtr vertexShaderStream, IntPtr geometryShaderStream,
            IntPtr fragmentShaderStream);

        /// <summary>
        ///     Sfs the shader destroy using the specified shader
        /// </summary>
        /// <param name="shader">The shader</param>
        [DllImport(Csfml.Graphics, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        private static extern void sfShader_destroy(IntPtr shader);

        /// <summary>
        ///     Sfs the shader set float uniform using the specified shader
        /// </summary>
        /// <param name="shader">The shader</param>
        /// <param name="name">The name</param>
        /// <param name="x">The </param>
        [DllImport(Csfml.Graphics, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        private static extern void sfShader_setFloatUniform(IntPtr shader, string name, float x);

        /// <summary>
        ///     Sfs the shader set vec 2 uniform using the specified shader
        /// </summary>
        /// <param name="shader">The shader</param>
        /// <param name="name">The name</param>
        /// <param name="vector">The vector</param>
        [DllImport(Csfml.Graphics, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        private static extern void sfShader_setVec2Uniform(IntPtr shader, string name, Vector2 vector);

        /// <summary>
        ///     Sfs the shader set vec 3 uniform using the specified shader
        /// </summary>
        /// <param name="shader">The shader</param>
        /// <param name="name">The name</param>
        /// <param name="vector">The vector</param>
        [DllImport(Csfml.Graphics, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        private static extern void sfShader_setVec3Uniform(IntPtr shader, string name, Vector3 vector);

        /// <summary>
        ///     Sfs the shader set vec 4 uniform using the specified shader
        /// </summary>
        /// <param name="shader">The shader</param>
        /// <param name="name">The name</param>
        /// <param name="vector">The vector</param>
        [DllImport(Csfml.Graphics, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        private static extern void sfShader_setVec4Uniform(IntPtr shader, string name, Vector4 vector);

        /// <summary>
        ///     Sfs the shader set int uniform using the specified shader
        /// </summary>
        /// <param name="shader">The shader</param>
        /// <param name="name">The name</param>
        /// <param name="x">The </param>
        [DllImport(Csfml.Graphics, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        private static extern void sfShader_setIntUniform(IntPtr shader, string name, int x);

        /// <summary>
        ///     Sfs the shader set ivec 2 uniform using the specified shader
        /// </summary>
        /// <param name="shader">The shader</param>
        /// <param name="name">The name</param>
        /// <param name="vector">The vector</param>
        [DllImport(Csfml.Graphics, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        private static extern void sfShader_setIvec2Uniform(IntPtr shader, string name, Vector2I vector);

        /// <summary>
        ///     Sfs the shader set ivec 3 uniform using the specified shader
        /// </summary>
        /// <param name="shader">The shader</param>
        /// <param name="name">The name</param>
        /// <param name="vector">The vector</param>
        [DllImport(Csfml.Graphics, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        private static extern void sfShader_setIvec3Uniform(IntPtr shader, string name, Vector3I vector);

        /// <summary>
        ///     Sfs the shader set ivec 4 uniform using the specified shader
        /// </summary>
        /// <param name="shader">The shader</param>
        /// <param name="name">The name</param>
        /// <param name="vector">The vector</param>
        [DllImport(Csfml.Graphics, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        private static extern void sfShader_setIvec4Uniform(IntPtr shader, string name, Vector4I vector);

        /// <summary>
        ///     Sfs the shader set bool uniform using the specified shader
        /// </summary>
        /// <param name="shader">The shader</param>
        /// <param name="name">The name</param>
        /// <param name="x">The </param>
        [DllImport(Csfml.Graphics, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        private static extern void sfShader_setBoolUniform(IntPtr shader, string name, bool x);

        /// <summary>
        ///     Sfs the shader set bvec 2 uniform using the specified shader
        /// </summary>
        /// <param name="shader">The shader</param>
        /// <param name="name">The name</param>
        /// <param name="vector">The vector</param>
        [DllImport(Csfml.Graphics, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        private static extern void sfShader_setBvec2Uniform(IntPtr shader, string name, Vector2B vector);

        /// <summary>
        ///     Sfs the shader set bvec 3 uniform using the specified shader
        /// </summary>
        /// <param name="shader">The shader</param>
        /// <param name="name">The name</param>
        /// <param name="vector">The vector</param>
        [DllImport(Csfml.Graphics, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        private static extern void sfShader_setBvec3Uniform(IntPtr shader, string name, Vector3B vector);

        /// <summary>
        ///     Sfs the shader set bvec 4 uniform using the specified shader
        /// </summary>
        /// <param name="shader">The shader</param>
        /// <param name="name">The name</param>
        /// <param name="vector">The vector</param>
        [DllImport(Csfml.Graphics, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        private static extern void sfShader_setBvec4Uniform(IntPtr shader, string name, Vector4B vector);

        /// <summary>
        ///     Sfs the shader set mat 3 uniform using the specified shader
        /// </summary>
        /// <param name="shader">The shader</param>
        /// <param name="name">The name</param>
        /// <param name="matrix">The matrix</param>
        [DllImport(Csfml.Graphics, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        private static extern void sfShader_setMat3Uniform(IntPtr shader, string name, Matrix3X3F matrix);

        /// <summary>
        ///     Sfs the shader set mat 4 uniform using the specified shader
        /// </summary>
        /// <param name="shader">The shader</param>
        /// <param name="name">The name</param>
        /// <param name="matrix">The matrix</param>
        [DllImport(Csfml.Graphics, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        private static extern void sfShader_setMat4Uniform(IntPtr shader, string name, Matrix4X4F matrix);

        /// <summary>
        ///     Sfs the shader set texture uniform using the specified shader
        /// </summary>
        /// <param name="shader">The shader</param>
        /// <param name="name">The name</param>
        /// <param name="texture">The texture</param>
        [DllImport(Csfml.Graphics, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        private static extern void sfShader_setTextureUniform(IntPtr shader, string name, IntPtr texture);

        /// <summary>
        ///     Sfs the shader set current texture uniform using the specified shader
        /// </summary>
        /// <param name="shader">The shader</param>
        /// <param name="name">The name</param>
        [DllImport(Csfml.Graphics, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        private static extern void sfShader_setCurrentTextureUniform(IntPtr shader, string name);

        /// <summary>
        ///     Sfs the shader set float uniform array using the specified shader
        /// </summary>
        /// <param name="shader">The shader</param>
        /// <param name="name">The name</param>
        /// <param name="data">The data</param>
        /// <param name="length">The length</param>
        [DllImport(Csfml.Graphics, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        private static extern void sfShader_setFloatUniformArray(IntPtr shader, string name, float[] data,
            uint length);

        /// <summary>
        ///     Sfs the shader set vec 2 uniform array using the specified shader
        /// </summary>
        /// <param name="shader">The shader</param>
        /// <param name="name">The name</param>
        /// <param name="data">The data</param>
        /// <param name="length">The length</param>
        [DllImport(Csfml.Graphics, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        private static extern void sfShader_setVec2UniformArray(IntPtr shader, string name, Vector2[] data,
            uint length);

        /// <summary>
        ///     Sfs the shader set vec 3 uniform array using the specified shader
        /// </summary>
        /// <param name="shader">The shader</param>
        /// <param name="name">The name</param>
        /// <param name="data">The data</param>
        /// <param name="length">The length</param>
        [DllImport(Csfml.Graphics, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        private static extern void sfShader_setVec3UniformArray(IntPtr shader, string name, Vector3[] data,
            uint length);

        /// <summary>
        ///     Sfs the shader set vec 4 uniform array using the specified shader
        /// </summary>
        /// <param name="shader">The shader</param>
        /// <param name="name">The name</param>
        /// <param name="data">The data</param>
        /// <param name="length">The length</param>
        [DllImport(Csfml.Graphics, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        private static extern void sfShader_setVec4UniformArray(IntPtr shader, string name, Vector4[] data,
            uint length);

        /// <summary>
        ///     Sfs the shader set mat 3 uniform array using the specified shader
        /// </summary>
        /// <param name="shader">The shader</param>
        /// <param name="name">The name</param>
        /// <param name="data">The data</param>
        /// <param name="length">The length</param>
        [DllImport(Csfml.Graphics, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        private static extern void sfShader_setMat3UniformArray(IntPtr shader, string name, Matrix3X3F data,
            uint length);

        /// <summary>
        ///     Sfs the shader set mat 4 uniform array using the specified shader
        /// </summary>
        /// <param name="shader">The shader</param>
        /// <param name="name">The name</param>
        /// <param name="data">The data</param>
        /// <param name="length">The length</param>
        [DllImport(Csfml.Graphics, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        private static extern void sfShader_setMat4UniformArray(IntPtr shader, string name, Matrix4X4F[] data,
            uint length);

        /// <summary>
        ///     Sfs the shader get native handle using the specified shader
        /// </summary>
        /// <param name="shader">The shader</param>
        /// <returns>The uint</returns>
        [DllImport(Csfml.Graphics, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        private static extern uint sfShader_getNativeHandle(IntPtr shader);

        /// <summary>
        ///     Sfs the shader bind using the specified shader
        /// </summary>
        /// <param name="shader">The shader</param>
        [DllImport(Csfml.Graphics, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        private static extern void sfShader_bind(IntPtr shader);

        /// <summary>
        ///     Describes whether sf shader is available
        /// </summary>
        /// <returns>The bool</returns>
        [DllImport(Csfml.Graphics, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        private static extern bool sfShader_isAvailable();

        /// <summary>
        ///     Describes whether sf shader is geometry available
        /// </summary>
        /// <returns>The bool</returns>
        [DllImport(Csfml.Graphics, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        private static extern bool sfShader_isGeometryAvailable();

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Special type that can be passed to SetParameter,
        ///     and that represents the texture of the object being drawn
        /// </summary>
        ////////////////////////////////////////////////////////////
        public class CurrentTextureType
        {
        }
    }
}