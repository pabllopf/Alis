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
        // Define the vertices and indices for a cube
        private static readonly float[] CubeVertices = new float[]
        {
            -1.0f, -1.0f, -1.0f,
            1.0f, -1.0f, -1.0f,
            1.0f, 1.0f, -1.0f,
            -1.0f, 1.0f, -1.0f,
            -1.0f, -1.0f, 1.0f,
            1.0f, -1.0f, 1.0f,
            1.0f, 1.0f, 1.0f,
            -1.0f, 1.0f, 1.0f
        };

        private static readonly uint[] CubeIndices = new uint[]
        {
            0, 1, 2, 2, 3, 0,
            4, 5, 6, 6, 7, 4,
            0, 1, 5, 5, 4, 0,
            2, 3, 7, 7, 6, 2,
            0, 3, 7, 7, 4, 0,
            1, 2, 6, 6, 5, 1
        };

        // Define the vertex buffer and index buffer
        private uint vertexBuffer;
        private uint indexBuffer;

        // Define the shader program
        private uint shaderProgram;

        public IntPtr Initialize(out IntPtr context)
        {
            // Initialize SDL and create a window and context
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
            
            // Create the window
            IntPtr window = Sdl.CreateWindow("OpenGL Window", 100, 100, 800, 600, WindowSettings.WindowOpengl | WindowSettings.WindowResizable);

            // Initialize OpenGL context
            context = Sdl.CreateContext(window);
            
            // Initialize the vertex buffer and index buffer
            vertexBuffer = Gl.GenBuffer();
            GCHandle pinnedArray = GCHandle.Alloc(CubeVertices, GCHandleType.Pinned);
            IntPtr pointer = pinnedArray.AddrOfPinnedObject();

            Gl.GlBufferData(BufferTarget.ArrayBuffer, (IntPtr)(CubeVertices.Length * sizeof(float)), pointer, BufferUsageHint.StaticDraw);

            pinnedArray.Free(); // Don't forget to free the pinned memory

            indexBuffer = Gl.GenBuffer();
            GCHandle pinnedArray2 = GCHandle.Alloc(CubeIndices, GCHandleType.Pinned);
            IntPtr pointer2 = pinnedArray2.AddrOfPinnedObject();
            Gl.GlBufferData(BufferTarget.ElementArrayBuffer, (IntPtr)(CubeIndices.Length * sizeof(uint)), pointer2, BufferUsageHint.StaticDraw);
            pinnedArray2.Free(); // Don't forget to free the pinned memory

            // Initialize the shader program
            // Note: You need to replace these with your actual shader source code
            string vertexShaderSource = "...";
            string fragmentShaderSource = "...";
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

            Gl.GlDeleteShader(vertexShader);
            Gl.GlDeleteShader(fragmentShader);
            
             
            // Print the OpenGL version
            Console.WriteLine(@$"OpenGL VERSION {Gl.GlGetString(StringName.Version)}");
            
            // Print the OpenGL vendor
            Console.WriteLine(@$"OpenGL VENDOR {Gl.GlGetString(StringName.Vendor)}");
            
            // Print the OpenGL renderer
            Console.WriteLine(@$"OpenGL RENDERER {Gl.GlGetString(StringName.Renderer)}");
            
            // Print the OpenGL shading language version
            Console.WriteLine(@$"OpenGL SHADING LANGUAGE VERSION {Gl.GlGetString(StringName.ShadingLanguageVersion)}");
            
            return window;
        }

        public void Draw()
        {
            // Bind the buffers and shader program
            Gl.GlBindBuffer(BufferTarget.ArrayBuffer, vertexBuffer);
            Gl.GlBindBuffer(BufferTarget.ElementArrayBuffer, indexBuffer);
            Gl.GlUseProgram(shaderProgram);

            // Set the uniforms
            // Note: You need to replace these with your actual uniform names and values
            int modelMatrixLocation = Gl.GlGetUniformLocation(shaderProgram, "modelMatrix");
            Gl.UniformMatrix4Fv(modelMatrixLocation, Matrix4X4.Identity);

            int viewMatrixLocation = Gl.GlGetUniformLocation(shaderProgram, "viewMatrix");
            Gl.UniformMatrix4Fv(viewMatrixLocation, Matrix4X4.Identity);

            int projectionMatrixLocation = Gl.GlGetUniformLocation(shaderProgram, "projectionMatrix");
            Gl.UniformMatrix4Fv(projectionMatrixLocation, Matrix4X4.Identity);

            // Draw the cube
            Gl.GlDrawElements(PrimitiveType.Triangles, CubeIndices.Length, DrawElementsType.UnsignedInt, IntPtr.Zero);
        }
    }
}