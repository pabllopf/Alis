// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:RenderSquareUnfilled.cs
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
using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Graphic.OpenGL;
using Alis.Core.Graphic.OpenGL.Enums;
using Alis.Extension.Graphic.Glfw.Enums;
using Alis.Extension.Graphic.Glfw.Structs;
using Exception = System.Exception;

namespace Alis.Extension.Graphic.Glfw.Sample
{
    /// <summary>
    ///     The render square unfilled class
    /// </summary>
    public class RenderSquareUnfilled
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
        ///     Runs this instance
        /// </summary>
        public void Run()
        {
            Init();

            while (running)
            {
                GlfwNative.PollEvents();
                if (GlfwNative.WindowShouldClose(window))
                {
                    running = false;
                }

                Gl.GlClear(ClearBufferMask.ColorBufferBit);

                Draw(new Vector2F(0.0f, 0.0f), new Vector2F(0.5f, 0.5f));
                Draw(new Vector2F(0.5f, 0.5f), new Vector2F(0.25f, 0.25f));

                GlfwNative.SwapBuffers(window);
            }

            Gl.DeleteVertexArray(vao);
            Gl.DeleteBuffer(vbo);
            Gl.GlDeleteProgram(shaderProgram);
        }

        /// <summary>
        ///     Inits this instance
        /// </summary>
        /// <exception cref="Exception">Failed to create GLFW window</exception>
        /// <exception cref="Exception">Failed to initialize GLFW</exception>
        private void Init()
        {
            // Initialize GLFW
            if (!GlfwNative.Init())
            {
                throw new Exception("Failed to initialize GLFW");
            }

            Gl.Initialize(GlfwNative.GetProcAddress);

            GlfwNative.WindowHint(Hint.ContextVersionMajor, 3);
            GlfwNative.WindowHint(Hint.ContextVersionMinor, 3);
            GlfwNative.WindowHint(Hint.OpenglProfile, GlfwProfile.Core);
            GlfwNative.WindowHint(Hint.OpenglForwardCompatible, true);

            window = GlfwNative.CreateWindow(800, 600, "OpenGL Window", Monitor.None, Window.None);
            if (window == Window.None)
            {
                throw new Exception("Failed to create GLFW window");
            }

            GlfwNative.MakeContextCurrent(window);
            GlfwNative.SwapInterval(1);

            GlfwNative.SetFramebufferSizeCallback(window, FramebufferSizeCallback);

            float[] vertices =
            {
                -0.5f, 0.5f, 0.0f, // Top-left
                0.5f, 0.5f, 0.0f, // Top-right
                0.5f, -0.5f, 0.0f, // Bottom-right
                -0.5f, -0.5f, 0.0f // Bottom-left
            };

            uint[] indices =
            {
                0, 1, 2, // First triangle
                2, 3, 0 // Second triangle
            };

            vbo = Gl.GenBuffer();
            vao = Gl.GenVertexArray();
            uint ebo = Gl.GenBuffer();

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

            Gl.GlBindBuffer(BufferTarget.ElementArrayBuffer, ebo);
            handle = GCHandle.Alloc(indices, GCHandleType.Pinned);
            try
            {
                IntPtr pointer = handle.AddrOfPinnedObject();
                Gl.GlBufferData(BufferTarget.ElementArrayBuffer, new IntPtr(indices.Length * sizeof(uint)), pointer, BufferUsageHint.StaticDraw);
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
              void main()
              {
                  gl_Position = vec4(aPos, 1.0);
              }
          ";

            string fragmentShaderSource = @"
              #version 330 core
              out vec4 FragColor;
              void main()
              {
                  FragColor = vec4(1.0f, 0.0f, 0.0f, 1.0f); // Red color
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
        }

        /// <summary>
        ///     Draws the pos
        /// </summary>
        /// <param name="pos">The pos</param>
        /// <param name="size">The size</param>
        private void Draw(Vector2F pos, Vector2F size)
        {
            // Update the vertex positions based on the given position and size
            float[] vertices =
            {
                pos.X - size.X / 2, pos.Y + size.Y / 2, 0.0f, // Top-left
                pos.X + size.X / 2, pos.Y + size.Y / 2, 0.0f, // Top-right
                pos.X + size.X / 2, pos.Y - size.Y / 2, 0.0f, // Bottom-right
                pos.X - size.X / 2, pos.Y - size.Y / 2, 0.0f // Bottom-left
            };

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

            Gl.GlPolygonMode(MaterialFace.FrontAndBack, PolygonModeEnum.Line);
            Gl.GlDrawElements(PrimitiveType.LineLoop, 6, DrawElementsType.UnsignedInt, IntPtr.Zero);
            Gl.GlPolygonMode(MaterialFace.FrontAndBack, PolygonModeEnum.Fill);
        }

        /// <summary>
        ///     Framebuffers the size callback using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="width">The width</param>
        /// <param name="height">The height</param>
        private void FramebufferSizeCallback(Window window, int width, int height)
        {
            Gl.GlViewport(0, 0, width, height);
        }
    }
}