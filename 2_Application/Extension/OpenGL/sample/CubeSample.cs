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
using Alis.Core.Aspect.Math.Matrix;
using Alis.Core.Graphic.Sdl2;
using Alis.Core.Graphic.Sdl2.Enums;
using Alis.Extension.OpenGL.Enums;
using Version = Alis.Core.Graphic.Sdl2.Structs.Version;

namespace Alis.Extension.OpenGL.Sample
{
    public class CubeSample
    {
        private uint vbo;
        private uint vao;
        private uint ebo;
        private uint shaderProgram;

        public IntPtr Initialize(out IntPtr context)
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

            IntPtr window = Sdl.CreateWindow("OpenGL Window", 100, 100, 800, 600, WindowSettings.WindowOpengl | WindowSettings.WindowResizable);

            // Initialize OpenGL context
            context = Sdl.CreateContext(window);

            // Define the vertices for the cube
            float[] vertices =
            {
                -0.5f, -0.5f, -0.5f, // Front bottom-left
                0.5f, -0.5f, -0.5f, // Front bottom-right
                0.5f, 0.5f, -0.5f, // Front top-right
                -0.5f, 0.5f, -0.5f, // Front top-left
                -0.5f, -0.5f, 0.5f, // Back bottom-left
                0.5f, -0.5f, 0.5f, // Back bottom-right
                0.5f, 0.5f, 0.5f, // Back top-right
                -0.5f, 0.5f, 0.5f // Back top-left
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
                Gl.GlBufferData(BufferTarget.ArrayBuffer, (IntPtr) (vertices.Length * sizeof(float)), vPointer, BufferUsageHint.StaticDraw);
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
                Gl.GlBufferData(BufferTarget.ElementArrayBuffer, (IntPtr) (indices.Length * sizeof(uint)), iPointer, BufferUsageHint.StaticDraw);
            }
            finally
            {
                if (iHandle.IsAllocated)
                {
                    iHandle.Free();
                }
            }

            // Set up the shader program
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

            // Delete the shaders as they're linked into our program now and no longer necessary
            Gl.GlDeleteShader(vertexShader);
            Gl.GlDeleteShader(fragmentShader);

            // Bind the VAO and shader program
            Gl.GlBindVertexArray(vao);
            Gl.GlUseProgram(shaderProgram);

            // Enable the vertex attribute array
            Gl.EnableVertexAttribArray(0);
            Gl.VertexAttribPointer(0, 3, VertexAttribPointerType.Float, false, 3 * sizeof(float), IntPtr.Zero);


            return window;
        }

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

            // Draw the cube
            Gl.GlDrawElements(PrimitiveType.Triangles, 36, DrawElementsType.UnsignedInt, IntPtr.Zero);
        }

        public void Cleanup()
        {
            // Cleanup
            Gl.DeleteVertexArray(vao);
            Gl.DeleteBuffer(vbo);
            Gl.DeleteBuffer(ebo);
            Gl.GlDeleteProgram(shaderProgram);
        }
    }
}
