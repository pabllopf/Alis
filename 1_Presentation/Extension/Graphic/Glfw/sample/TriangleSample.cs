// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:TriangleSample.cs
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
    ///     The triangle sample class
    /// </summary>
    public class TriangleSample
    {
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
            Matrix4X4 transform = Matrix4X4.CreateRotationZ((float) DateTime.Now.TimeOfDay.TotalSeconds); // Rotate around Z-axis

            int transformLocation = Gl.GlGetUniformLocation(shaderProgram, "transform");

            Gl.UniformMatrix4Fv(transformLocation, transform);

            Gl.GlDrawArrays(PrimitiveType.Triangles, 0, 3);
        }

        /// <summary>
        ///     Runs this instance
        /// </summary>
        public void Run()
        {
            if (!GlfwNative.Init())
            {
                throw new Exception("Failed to initialize GLFW");
            }

            Gl.Initialize(GlfwNative.GetProcAddress);

            GlfwNative.WindowHint(Hint.ContextVersionMajor, 3);
            GlfwNative.WindowHint(Hint.ContextVersionMinor, 2);
            GlfwNative.WindowHint(Hint.OpenglProfile, GlfwProfile.Core);
            GlfwNative.WindowHint(Hint.OpenglForwardCompatible, true);
            GlfwNative.WindowHint(Hint.Doublebuffer, true);
            GlfwNative.WindowHint(Hint.DepthBits, 24);
            GlfwNative.WindowHint(Hint.AlphaBits, 8);
            GlfwNative.WindowHint(Hint.StencilBits, 8);

            window = GlfwNative.CreateWindow(800, 600, "OpenGL Window", Monitor.None, Window.None);
            if (window == Window.None)
            {
                throw new Exception("Failed to create GLFW window");
            }

            GlfwNative.MakeContextCurrent(window);

            GlfwNative.SwapInterval(1);

            Logger.Log($"GLFW VERSION {GlfwNative.GetVersionString()}");

            float[] vertices =
            {
                0.0f, 0.5f, 0.0f, // Top
                -0.5f, -0.5f, 0.0f, // Bottom Left
                0.5f, -0.5f, 0.0f // Bottom Right
            };

            vbo = Gl.GenBuffer();
            vao = Gl.GenVertexArray();

            Gl.GlBindVertexArray(vao);
            Gl.GlBindBuffer(BufferTarget.ArrayBuffer, vbo);

            GCHandle handle = GCHandle.Alloc(vertices, GCHandleType.Pinned);
            try
            {
                IntPtr pointer = handle.AddrOfPinnedObject();
                Gl.GlBufferData(BufferTarget.ArrayBuffer, new IntPtr(vertices.Length * sizeof(float)), pointer, BufferUsageHint.StaticDraw);
            }
            finally
            {
                if (handle.IsAllocated)
                {
                    handle.Free();
                }
            }

            string vertexShaderSource = @"
                #version 330 core
                layout (location = 0) in vec3 aPos;
                uniform mat4 transform;
                void main()
                {
                    gl_Position = transform * vec4(aPos.x, aPos.y, aPos.z, 1.0);
                }
                ";

            string fragmentShaderSource = @"
                #version 330 core
                out vec4 FragColor;
                void main()
                {
                    FragColor = vec4(1.0f, 1.0f, 1.0f, 1.0f); // white color
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

            Gl.GlBindVertexArray(vao);
            Gl.GlUseProgram(shaderProgram);

            Gl.EnableVertexAttribArray(0);
            Gl.VertexAttribPointer(0, 3, VertexAttribPointerType.Float, false, 3 * sizeof(float), IntPtr.Zero);

            Logger.Log(@$"OpenGL VERSION {Gl.GlGetString(StringName.Version)}");

            Logger.Log(@$"OpenGL VENDOR {Gl.GlGetString(StringName.Vendor)}");

            Logger.Log(@$"OpenGL RENDERER {Gl.GlGetString(StringName.Renderer)}");

            Logger.Log(@$"OpenGL SHADING LANGUAGE VERSION {Gl.GlGetString(StringName.ShadingLanguageVersion)}");

            while (running)
            {
                GlfwNative.PollEvents();
                if (GlfwNative.WindowShouldClose(window))
                {
                    running = false;
                }

                Gl.GlClear(ClearBufferMasks.ColorBufferBit);

                Draw();

                GlfwNative.SwapBuffers(window);
            }

            Gl.DeleteVertexArray(vao);
            Gl.DeleteBuffer(vbo);
            Gl.GlDeleteProgram(shaderProgram);
        }
    }
}