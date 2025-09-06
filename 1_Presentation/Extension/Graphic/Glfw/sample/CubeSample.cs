// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:CubeSample.cs
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
using Alis.Core.Aspect.Math.Matrix;
using Alis.Core.Graphic.OpenGL;
using Alis.Core.Graphic.OpenGL.Enums;
using Alis.Extension.Graphic.Glfw.Enums;
using Alis.Extension.Graphic.Glfw.Structs;
using Exception = System.Exception;


namespace Alis.Extension.Graphic.Glfw.Sample
{
    /// <summary>
    ///     The cube sample class
    /// </summary>
    public class CubeSample
    {
        /// <summary>
        ///     The ebo
        /// </summary>
        private uint ebo;

        /// <summary>
        ///     The running
        /// </summary>
        private bool running = true;

        /// <summary>
        ///     The shader program
        /// </summary>
        private uint shaderProgram;

        /// <summary>
        ///     The vao
        /// </summary>
        private uint vao;

        /// <summary>
        ///     The vbo
        /// </summary>
        private uint vbo;

        /// <summary>
        ///     The window
        /// </summary>
        private Window window;

        /// <summary>
        ///     Draws this instance
        /// </summary>
        public void Draw()
        {
            // Create a rotation matrix
            Matrix4X4 transform = Matrix4X4.CreateRotationZ((float) DateTime.Now.TimeOfDay.TotalSeconds); // Rotate around Z-axis

            // rotate around X-axis
            transform = Matrix4X4.Multiply(transform, Matrix4X4.CreateRotationX((float) DateTime.Now.TimeOfDay.TotalSeconds));

            // Get the location of the "transform" uniform variable
            int transformLocation = Gl.GlGetUniformLocation(shaderProgram, "transform");

            // Set the value of the "transform" uniform variable
            Gl.UniformMatrix4Fv(transformLocation, transform);

            // Draw the cube in wireframe mode
            Gl.GlDrawElements(PrimitiveType.Triangles, 36, DrawElementsType.UnsignedInt, IntPtr.Zero);
        }

        /// <summary>
        ///     Runs this instance
        /// </summary>
        public void Run()
        {
            // Initialize GLFW
            // Initialize GLFW
            if (!Glfw.Init())
            {
                throw new Exception("Failed to initialize GLFW");
            }

            Gl.Initialize(Glfw.GetProcAddress);

            // Set GLFW window hints for OpenGL context
            Glfw.WindowHint(Hint.ContextVersionMajor, 3);
            Glfw.WindowHint(Hint.ContextVersionMinor, 2);
            Glfw.WindowHint(Hint.OpenglProfile, Profile.Core);
            Glfw.WindowHint(Hint.OpenglForwardCompatible, true);
            Glfw.WindowHint(Hint.Doublebuffer, true);
            Glfw.WindowHint(Hint.DepthBits, 24);
            Glfw.WindowHint(Hint.AlphaBits, 8);
            Glfw.WindowHint(Hint.StencilBits, 8);

            // Create a GLFW window
            window = Glfw.CreateWindow(800, 600, "OpenGL Window", Monitor.None, Window.None);
            if (window == Window.None)
            {
                throw new Exception("Failed to create GLFW window");
            }

            // Make the OpenGL context current
            Glfw.MakeContextCurrent(window);

            // Enable v-sync
            Glfw.SwapInterval(1);

            // Log GLFW version
            Logger.Log($"GLFW VERSION {Glfw.GetVersionString()}");

            // Define the vertices for the cube with color information
            float[] vertices =
            {
                // positions          // colors
                -0.5f, -0.5f, -0.5f, 1.0f, 0.0f, 0.0f, // Front bottom-left
                0.5f, -0.5f, -0.5f, 0.0f, 1.0f, 0.0f, // Front bottom-right
                0.5f, 0.5f, -0.5f, 0.0f, 0.0f, 1.0f, // Front top-right
                -0.5f, 0.5f, -0.5f, 1.0f, 1.0f, 0.0f, // Front top-left
                -0.5f, -0.5f, 0.5f, 0.0f, 1.0f, 1.0f, // Back bottom-left
                0.5f, -0.5f, 0.5f, 1.0f, 0.0f, 1.0f, // Back bottom-right
                0.5f, 0.5f, 0.5f, 1.0f, 1.0f, 1.0f, // Back top-right
                -0.5f, 0.5f, 0.5f, 0.0f, 0.0f, 0.0f // Back top-left
            };

            uint[] indices =
            {
                0, 1, 3, // Front
                1, 2, 3,
                1, 5, 2, // Right
                5, 6, 2,
                5, 4, 6, // Back
                4, 7, 6,
                4, 0, 7, // Left
                0, 3, 7,
                3, 2, 7, // Top
                2, 6, 7,
                4, 5, 0, // Bottom
                5, 1, 0
            };

            // Create a vertex buffer object (VBO), a vertex array object (VAO), and an element buffer object (EBO)
            vbo = Gl.GenBuffer();
            vao = Gl.GenVertexArray();
            ebo = Gl.GenBuffer();

            // Bind the VAO, VBO, and EBO
            Gl.GlBindVertexArray(vao);
            Gl.GlBindBuffer(BufferTarget.ArrayBuffer, vbo);
            Gl.GlBindBuffer(BufferTarget.ElementArrayBuffer, ebo);

            // Buffer the vertex data
            GCHandle vHandle = GCHandle.Alloc(vertices, GCHandleType.Pinned);
            try
            {
                IntPtr vPointer = vHandle.AddrOfPinnedObject();
                Gl.GlBufferData(BufferTarget.ArrayBuffer, vertices.Length * sizeof(float), vPointer, BufferUsageHint.StaticDraw);
            }
            finally
            {
                if (vHandle.IsAllocated)
                {
                    vHandle.Free();
                }
            }

            // Buffer the index data
            GCHandle iHandle = GCHandle.Alloc(indices, GCHandleType.Pinned);
            try
            {
                IntPtr iPointer = iHandle.AddrOfPinnedObject();
                Gl.GlBufferData(BufferTarget.ElementArrayBuffer, indices.Length * sizeof(uint), iPointer, BufferUsageHint.StaticDraw);
            }
            finally
            {
                if (iHandle.IsAllocated)
                {
                    iHandle.Free();
                }
            }

            string vertexShaderSource = @"
            #version 330 core
            layout (location = 0) in vec3 aPos;
            layout (location = 1) in vec3 aColor;
            out vec3 ourColor;
            uniform mat4 transform;
            void main()
            {
                gl_Position = transform * vec4(aPos.x, aPos.y, aPos.z, 1.0);
                ourColor = aColor;
            }
            ";

            string fragmentShaderSource = @"
            #version 330 core
            in vec3 ourColor;
            out vec4 FragColor;
            void main()
            {
                FragColor = vec4(ourColor, 1.0f);
            }
            ";

            uint vertexShader = Gl.GlCreateShader(ShaderType.VertexShader);
            Gl.ShaderSource(vertexShader, vertexShaderSource);
            Gl.GlCompileShader(vertexShader);

            uint fragmentShader = Gl.GlCreateShader(ShaderType.FragmentShader);
            Gl.ShaderSource(fragmentShader, fragmentShaderSource);
            Gl.GlCompileShader(fragmentShader);

            shaderProgram = Gl.GlCreateProgram();
            Gl.GlAttachShader(shaderProgram, vertexShader);
            Gl.GlAttachShader(shaderProgram, fragmentShader);
            Gl.GlLinkProgram(shaderProgram);

            // Delete the shaders as they're linked into our program now and no longer necessary
            Gl.GlDeleteShader(vertexShader);
            Gl.GlDeleteShader(fragmentShader);

            // Bind the VAO and shader program
            Gl.GlBindVertexArray(vao);
            Gl.GlUseProgram(shaderProgram);

            // Enable the vertex attribute array for position and color
            Gl.EnableVertexAttribArray(0);
            Gl.VertexAttribPointer(0, 3, VertexAttribPointerType.Float, false, 6 * sizeof(float), IntPtr.Zero);
            Gl.EnableVertexAttribArray(1);
            Gl.VertexAttribPointer(1, 3, VertexAttribPointerType.Float, false, 6 * sizeof(float), 3 * sizeof(float));

            while (running)
            {
                // Event handling
                Glfw.PollEvents();
                if (Glfw.WindowShouldClose(window))
                {
                    running = false;
                }

                // Clear the screen
                Gl.GlClear(ClearBufferMask.ColorBufferBit);

                Draw();

                // Swap the buffers to display the triangle
                Glfw.SwapBuffers(window);
            }

            // Cleanup
            Gl.DeleteVertexArray(vao);
            Gl.DeleteBuffer(vbo);
            Gl.DeleteBuffer(ebo);
            Gl.GlDeleteProgram(shaderProgram);
        }
    }
}