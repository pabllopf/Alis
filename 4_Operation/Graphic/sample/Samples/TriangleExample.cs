// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:TriangleExample.cs
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
using Alis.Core.Aspect.Logging;
using Alis.Core.Graphic.OpenGL;
using Alis.Core.Graphic.OpenGL.Enums;

namespace Alis.Core.Graphic.Sample.Samples
{
    /// <summary>
    ///     The triangle example class
    /// </summary>
    /// <seealso cref="IExample" />
    internal class TriangleExample : IExample
    {
        /// <summary>
        ///     The fragment shader source
        /// </summary>
        private readonly string fragmentShaderSource = @"
#version 150 core
out vec4 FragColor;
void main() {
    FragColor = vec4(1.0, 1.0, 1.0, 1.0);
}";

        /// <summary>
        ///     The vertex shader source
        /// </summary>
        private readonly string vertexShaderSource = @"
#version 150 core
in vec3 aPos;
void main() {
    gl_Position = vec4(aPos, 1.0);
}";

        /// <summary>
        ///     The vertices
        /// </summary>
        private readonly float[] vertices =
        {
            -0.5f, -0.5f, 0.0f,
            0.5f, -0.5f, 0.0f,
            0.0f, 0.5f, 0.0f
        };

        /// <summary>
        ///     The shader program
        /// </summary>
        private uint vao, vbo, shaderProgram;

        /// <summary>
        ///     Initializes this instance
        /// </summary>
        public void Initialize()
        {
            vao = Gl.GenVertexArray();
            vbo = Gl.GenBuffer();
            Gl.GlBindVertexArray(vao);
            Gl.GlBindBuffer(BufferTarget.ArrayBuffer, vbo);
            GCHandle vHandle = GCHandle.Alloc(vertices, GCHandleType.Pinned);
            Gl.GlBufferData(BufferTarget.ArrayBuffer, new IntPtr(vertices.Length * sizeof(float)), vHandle.AddrOfPinnedObject(), BufferUsageHint.StaticDraw);
            vHandle.Free();
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
            Gl.VertexAttribPointer(0, 3, VertexAttribPointerType.Float, false, 3 * sizeof(float), IntPtr.Zero);
        }

        /// <summary>
        ///     Draws this instance
        /// </summary>
        public void Draw()
        {
            Gl.GlClearColor(0.2f, 0.3f, 0.3f, 1.0f);
            Gl.GlClear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
            Gl.GlBindVertexArray(vao);
            Gl.GlUseProgram(shaderProgram);
            Gl.GlDrawArrays(PrimitiveType.Triangles, 0, 3);
        }

        /// <summary>
        ///     Cleanups this instance
        /// </summary>
        public void Cleanup()
        {
            Gl.DeleteVertexArray(vao);
            Gl.DeleteBuffer(vbo);
            Gl.GlDeleteProgram(shaderProgram);
        }
    }
}