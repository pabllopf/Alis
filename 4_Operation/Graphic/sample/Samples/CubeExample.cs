// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:CubeExample.cs
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
using Alis.Core.Aspect.Logging;
using Alis.Core.Aspect.Math.Matrix;
using Alis.Core.Graphic.OpenGL;
using Alis.Core.Graphic.OpenGL.Enums;

namespace Alis.Core.Graphic.Sample.Samples
{
    /// <summary>
    ///     The cube example class
    /// </summary>
    /// <seealso cref="IExample" />
    internal class CubeExample : IExample
    {
        /// <summary>
        ///     The fragment shader source
        /// </summary>
        private readonly string fragmentShaderSource = @"#version 150 core
in vec3 ourColor;
out vec4 FragColor;
void main()
{
    FragColor = vec4(ourColor, 1.0);
}";

        /// <summary>
        ///     The indices
        /// </summary>
        private readonly uint[] indices =
        {
            0, 1, 3, 1, 2, 3,
            1, 5, 2, 5, 6, 2,
            5, 4, 6, 4, 7, 6,
            4, 0, 7, 0, 3, 7,
            3, 2, 7, 2, 6, 7,
            4, 5, 0, 5, 1, 0
        };

        /// <summary>
        ///     The vertex shader source
        /// </summary>
        private readonly string vertexShaderSource = @"#version 150 core
in vec3 aPos;
in vec3 aColor;
out vec3 ourColor;
uniform mat4 transform;
void main()
{
    gl_Position = transform * vec4(aPos, 1.0);
    ourColor = aColor;
}";

        /// <summary>
        ///     The vertices
        /// </summary>
        private readonly float[] vertices =
        {
            // positions          // colors
            -0.5f, -0.5f, -0.5f, 1.0f, 0.0f, 0.0f,
            0.5f, -0.5f, -0.5f, 0.0f, 1.0f, 0.0f,
            0.5f, 0.5f, -0.5f, 0.0f, 0.0f, 1.0f,
            -0.5f, 0.5f, -0.5f, 1.0f, 1.0f, 0.0f,
            -0.5f, -0.5f, 0.5f, 0.0f, 1.0f, 1.0f,
            0.5f, -0.5f, 0.5f, 1.0f, 0.0f, 1.0f,
            0.5f, 0.5f, 0.5f, 1.0f, 1.0f, 1.0f,
            -0.5f, 0.5f, 0.5f, 0.0f, 0.0f, 0.0f
        };

        /// <summary>
        ///     The shader program
        /// </summary>
        private uint vao, vbo, ebo, shaderProgram;

        /// <summary>
        ///     Initializes this instance
        /// </summary>
        public void Initialize()
        {
            vao = Gl.GenVertexArray();
            vbo = Gl.GenBuffer();
            ebo = Gl.GenBuffer();
            Gl.GlBindVertexArray(vao);
            Gl.GlBindBuffer(BufferTarget.ArrayBuffer, vbo);
            GCHandle vHandle = GCHandle.Alloc(vertices, GCHandleType.Pinned);
            Gl.GlBufferData(BufferTarget.ArrayBuffer, new IntPtr(vertices.Length * sizeof(float)), vHandle.AddrOfPinnedObject(), BufferUsageHint.StaticDraw);
            vHandle.Free();
            Gl.GlBindBuffer(BufferTarget.ElementArrayBuffer, ebo);
            GCHandle iHandle = GCHandle.Alloc(indices, GCHandleType.Pinned);
            Gl.GlBufferData(BufferTarget.ElementArrayBuffer, new IntPtr(indices.Length * sizeof(uint)), iHandle.AddrOfPinnedObject(), BufferUsageHint.StaticDraw);
            iHandle.Free();
            uint vertexShader = Gl.GlCreateShader(ShaderType.VertexShader);
            Gl.ShaderSource(vertexShader, vertexShaderSource);
            Gl.GlCompileShader(vertexShader);
            if (!Gl.GetShaderCompileStatus(vertexShader))
            {
                Logger.Info("Vertex shader error: " + Gl.GetShaderInfoLog(vertexShader));
            }

            uint fragmentShader = Gl.GlCreateShader(ShaderType.FragmentShader);
            Gl.ShaderSource(fragmentShader, fragmentShaderSource);
            Gl.GlCompileShader(fragmentShader);
            if (!Gl.GetShaderCompileStatus(fragmentShader))
            {
                Logger.Info("Fragment shader error: " + Gl.GetShaderInfoLog(fragmentShader));
            }

            shaderProgram = Gl.GlCreateProgram();
            Gl.GlAttachShader(shaderProgram, vertexShader);
            Gl.GlAttachShader(shaderProgram, fragmentShader);
            Gl.GlLinkProgram(shaderProgram);
            if (!Gl.GetProgramLinkStatus(shaderProgram))
            {
                Logger.Info("Program link error: " + Gl.GetProgramInfoLog(shaderProgram));
            }

            Gl.GlDeleteShader(vertexShader);
            Gl.GlDeleteShader(fragmentShader);
            Gl.GlBindVertexArray(vao);
            Gl.GlUseProgram(shaderProgram);
            Gl.EnableVertexAttribArray(0);
            Gl.VertexAttribPointer(0, 3, VertexAttribPointerType.Float, false, 6 * sizeof(float), IntPtr.Zero);
            Gl.EnableVertexAttribArray(1);
            Gl.VertexAttribPointer(1, 3, VertexAttribPointerType.Float, false, 6 * sizeof(float), new IntPtr(3 * sizeof(float)));
        }

        /// <summary>
        ///     Draws this instance
        /// </summary>
        public void Draw()
        {
            Gl.GlClearColor(0.1f, 0.1f, 0.1f, 1.0f);
            Gl.GlClear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
            Gl.GlBindVertexArray(vao);
            Gl.GlUseProgram(shaderProgram);
            // Matriz de rotación animada
            float time = (float) DateTime.Now.TimeOfDay.TotalSeconds;
            Matrix4x4 rotZ = Matrix4x4.CreateRotationZ(time);
            Matrix4x4 rotX = Matrix4x4.CreateRotationX(time);
            Matrix4x4 transform = rotZ * rotX;
            int transformLocation = Gl.GlGetUniformLocation(shaderProgram, "transform");
            // Enviar la matriz al shader
            float[] mat = new float[16];
            mat[0] = transform.M11;
            mat[1] = transform.M12;
            mat[2] = transform.M13;
            mat[3] = transform.M14;
            mat[4] = transform.M21;
            mat[5] = transform.M22;
            mat[6] = transform.M23;
            mat[7] = transform.M24;
            mat[8] = transform.M31;
            mat[9] = transform.M32;
            mat[10] = transform.M33;
            mat[11] = transform.M34;
            mat[12] = transform.M41;
            mat[13] = transform.M42;
            mat[14] = transform.M43;
            mat[15] = transform.M44;


            Gl.UniformMatrix4Fv(transformLocation, new Matrix4X4(mat[0], mat[1], mat[2], mat[3],
                mat[4], mat[5], mat[6], mat[7],
                mat[8], mat[9], mat[10], mat[11],
                mat[12], mat[13], mat[14], mat[15]));
            Gl.GlDrawElements(PrimitiveType.Triangles, indices.Length, DrawElementsType.UnsignedInt, IntPtr.Zero);
        }

        /// <summary>
        ///     Cleanups this instance
        /// </summary>
        public void Cleanup()
        {
            Gl.DeleteVertexArray(vao);
            Gl.DeleteBuffer(vbo);
            Gl.DeleteBuffer(ebo);
            Gl.GlDeleteProgram(shaderProgram);
        }
    }
}