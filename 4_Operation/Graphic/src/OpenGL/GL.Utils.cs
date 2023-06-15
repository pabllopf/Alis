// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:GL.Utils.cs
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
using System.Text;
using Alis.Core.Aspect.Math.Matrix;

namespace Alis.Core.Graphic.OpenGL
{
    /// <summary>
    ///     the methods here are just convenience wrappers for calling the raw gl* method
    /// </summary>
    public static partial class Gl
    {
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
        ///     Gens the buffer
        /// </summary>
        /// <returns>The uint</returns>
        public static uint GenBuffer()
        {
            Uint1[0] = 0;
            glGenBuffers(1, Uint1);
            return Uint1[0];
        }

        /// <summary>
        ///     Deletes the buffer using the specified buffer
        /// </summary>
        /// <param name="buffer">The buffer</param>
        public static void DeleteBuffer(uint buffer)
        {
            Uint1[0] = 0;
            glDeleteBuffers(1, Uint1);
            Uint1[0] = 0;
        }

        /// <summary>
        ///     Gets the shader info log using the specified shader
        /// </summary>
        /// <param name="shader">The shader</param>
        /// <returns>The string</returns>
        public static string GetShaderInfoLog(uint shader)
        {
            glGetShaderiv(shader, ShaderParameter.InfoLogLength, Int1);
            if (Int1[0] == 0)
            {
                return string.Empty;
            }

            StringBuilder sb = new StringBuilder(Int1[0]);
            glGetShaderInfoLog(shader, sb.Capacity, Int1, sb);
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
            glShaderSource(shader, 1, new[] {source}, Int1);
        }

        /// <summary>
        ///     Describes whether get shader compile status
        /// </summary>
        /// <param name="shader">The shader</param>
        /// <returns>The bool</returns>
        public static bool GetShaderCompileStatus(uint shader)
        {
            glGetShaderiv(shader, ShaderParameter.CompileStatus, Int1);
            return Int1[0] == 1;
        }

        /// <summary>
        ///     Gets the program info log using the specified program
        /// </summary>
        /// <param name="program">The program</param>
        /// <returns>The string</returns>
        public static string GetProgramInfoLog(uint program)
        {
            glGetProgramiv(program, ProgramParameter.InfoLogLength, Int1);
            if (Int1[0] == 0)
            {
                return string.Empty;
            }

            StringBuilder sb = new StringBuilder(Int1[0]);
            glGetProgramInfoLog(program, sb.Capacity, Int1, sb);
            return sb.ToString();
        }

        /// <summary>
        ///     Describes whether get program link status
        /// </summary>
        /// <param name="program">The program</param>
        /// <returns>The bool</returns>
        public static bool GetProgramLinkStatus(uint program)
        {
            glGetProgramiv(program, ProgramParameter.LinkStatus, Int1);
            return Int1[0] == 1;
        }

        /// <summary>
        ///     Uniforms the matrix 4fv using the specified location
        /// </summary>
        /// <param name="location">The location</param>
        /// <param name="param">The param</param>
        public static void UniformMatrix4Fv(int location, Matrix4x4 param)
        {
            // use the statically allocated float[] for setting the uniform
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

            glUniformMatrix4Fv(location, 1, false, Matrix4Float);
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

            glVertexAttribPointer((uint) index, size, type, normalized, stride, pointer);
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

            glEnableVertexAttribArray((uint) index);
        }

        /// <summary>
        ///     Gens the vertex array
        /// </summary>
        /// <returns>The uint</returns>
        public static uint GenVertexArray()
        {
            Uint1[0] = 0;
            glGenVertexArrays(1, Uint1);
            return Uint1[0];
        }

        /// <summary>
        ///     Deletes the vertex array using the specified vao
        /// </summary>
        /// <param name="vao">The vao</param>
        public static void DeleteVertexArray(uint vao)
        {
            Uint1[0] = vao;
            glDeleteVertexArrays(1, Uint1);
        }

        /// <summary>
        ///     Gens the texture
        /// </summary>
        /// <returns>The uint</returns>
        public static uint GenTexture()
        {
            Uint1[0] = 0;
            glGenTextures(1, Uint1);
            return Uint1[0];
        }

        /// <summary>
        ///     Deletes the texture using the specified texture
        /// </summary>
        /// <param name="texture">The texture</param>
        public static void DeleteTexture(uint texture)
        {
            Uint1[0] = texture;
            glDeleteTextures(1, Uint1);
        }
    }
}