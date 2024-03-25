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
using Alis.Core.Aspect.Math.Matrix;
using Alis.Core.Graphic.Sdl2;
using Alis.Core.Graphic.Sdl2.Enums;
using Alis.Core.Graphic.Sdl2.Structs;
using Alis.Extension.Graphic.OpenGL.Enums;
using Version = Alis.Core.Graphic.Sdl2.Structs.Version;

namespace Alis.Extension.Graphic.OpenGL.Sample
{
    /// <summary>
    ///     The triangle sample class
    /// </summary>
    public class TriangleSample
    {
        /// <summary>
        ///     The context
        /// </summary>
        private IntPtr context;

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
        private IntPtr window;

        /// <summary>
        ///     Draws this instance
        /// </summary>
        public void Draw()
        {
            // Create a rotation matrix
            Matrix4X4 transform = Matrix4X4.CreateRotationZ((float) DateTime.Now.TimeOfDay.TotalSeconds); // Rotate around Z-axis

            // Get the location of the "transform" uniform variable
            int transformLocation = Gl.GlGetUniformLocation(shaderProgram, "transform");

            // Set the value of the "transform" uniform variable
            Gl.UniformMatrix4Fv(transformLocation, transform);

            // Draw the triangle
            Gl.GlDrawArrays(PrimitiveType.Triangles, 0, 3);
        }

        /// <summary>
        ///     Runs this instance
        /// </summary>
        public void Run()
        {
            // Initialize SDL and create a window
            Sdl.Init(InitSettings.InitVideo);

            // GET VERSION SDL2
            Version version = Sdl.GetVersion();
            Console.WriteLine(@$"SDL2 VERSION {version.major}.{version.minor}.{version.patch}");

            // CONFIG THE SDL2 AN OPENGL CONFIGURATION
            Sdl.SetAttributeByInt(GlAttr.SdlGlContextFlags, (int) GlContexts.SdlGlContextForwardCompatibleFlag);
            Sdl.SetAttributeByProfile(GlAttr.SdlGlContextProfileMask, GlProfiles.SdlGlContextProfileCore);
            Sdl.SetAttributeByInt(GlAttr.SdlGlContextMajorVersion, 3);
            Sdl.SetAttributeByInt(GlAttr.SdlGlContextMinorVersion, 2);

            Sdl.SetAttributeByProfile(GlAttr.SdlGlContextProfileMask, GlProfiles.SdlGlContextProfileCore);
            Sdl.SetAttributeByInt(GlAttr.SdlGlDoubleBuffer, 1);
            Sdl.SetAttributeByInt(GlAttr.SdlGlDepthSize, 24);
            Sdl.SetAttributeByInt(GlAttr.SdlGlAlphaSize, 8);
            Sdl.SetAttributeByInt(GlAttr.SdlGlStencilSize, 8);

            window = Sdl.CreateWindow("OpenGL Window", 100, 100, 800, 600, WindowSettings.WindowOpengl | WindowSettings.WindowResizable);

            // Initialize OpenGL context
            context = Sdl.CreateContext(window);

            // Define the vertices for the triangle
            float[] vertices =
            {
                0.0f, 0.5f, 0.0f, // Top
                -0.5f, -0.5f, 0.0f, // Bottom Left
                0.5f, -0.5f, 0.0f // Bottom Right
            };

            // Create a vertex buffer object (VBO) and a vertex array object (VAO)
            vbo = Gl.GenBuffer();
            vao = Gl.GenVertexArray();

            // Bind the VAO and VBO
            Gl.GlBindVertexArray(vao);
            Gl.GlBindBuffer(BufferTarget.ArrayBuffer, vbo);

            GCHandle handle = GCHandle.Alloc(vertices, GCHandleType.Pinned);
            try
            {
                IntPtr pointer = handle.AddrOfPinnedObject();
                Gl.GlBufferData(BufferTarget.ArrayBuffer, (IntPtr) (vertices.Length * sizeof(float)), pointer, BufferUsageHint.StaticDraw);
            }
            finally
            {
                if (handle.IsAllocated)
                {
                    handle.Free();
                }
            }

            // Update vertex shader source code
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

            // Bind the VAO and shader program
            Gl.GlBindVertexArray(vao);
            Gl.GlUseProgram(shaderProgram);

            // Enable the vertex attribute array
            Gl.EnableVertexAttribArray(0);
            Gl.VertexAttribPointer(0, 3, VertexAttribPointerType.Float, false, 3 * sizeof(float), IntPtr.Zero);

            // Print the OpenGL version
            Console.WriteLine(@$"OpenGL VERSION {Gl.GlGetString(StringName.Version)}");

            // Print the OpenGL vendor
            Console.WriteLine(@$"OpenGL VENDOR {Gl.GlGetString(StringName.Vendor)}");

            // Print the OpenGL renderer
            Console.WriteLine(@$"OpenGL RENDERER {Gl.GlGetString(StringName.Renderer)}");

            // Print the OpenGL shading language version
            Console.WriteLine(@$"OpenGL SHADING LANGUAGE VERSION {Gl.GlGetString(StringName.ShadingLanguageVersion)}");

            while (running)
            {
                // Event handling
                while (Sdl.PollEvent(out Event evt) != 0)
                {
                    if (evt.type == EventType.Quit)
                    {
                        running = false;
                    }
                }

                // Clear the screen
                Gl.GlClear(ClearBufferMask.ColorBufferBit);

                Draw();

                // Swap the buffers to display the triangle
                Sdl.SwapWindow(window);
            }

            // Cleanup
            Gl.DeleteVertexArray(vao);
            Gl.DeleteBuffer(vbo);
            Gl.GlDeleteProgram(shaderProgram);

            // Cleanup SDL
            Sdl.DeleteContext(context);
            Sdl.DestroyWindow(window);
            Sdl.Quit();
        }
    }
}