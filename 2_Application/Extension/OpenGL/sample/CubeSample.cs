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
using System.Numerics;
using System.Runtime.InteropServices;
using Alis.Core.Aspect.Math.Matrix;
using Alis.Core.Graphic.Sdl2;
using Alis.Core.Graphic.Sdl2.Enums;
using Alis.Extension.OpenGL.Enums;
using Vector3 = Alis.Core.Aspect.Math.Vector.Vector3;
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
            string vertexShaderSource = @"
            #version 330 core
            layout (location = 0) in vec3 aPos;

            uniform mat4 model;
            uniform mat4 view;
            uniform mat4 projection;

            void main()
            {
                gl_Position = projection * view * model * vec4(aPos, 1.0);
            }";
            
            string fragmentShaderSource = @"
            #version 330 core
            out vec4 FragColor;

            void main()
            {
                FragColor = vec4(1.0f, 1.0f, 1.0f, 1.0f);
            }";
                        
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
            Gl.GlClear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

            Gl.GlUseProgram(shaderProgram);
            
            Matrix4x4 temp = Matrix4x4.CreateLookAt(new System.Numerics.Vector3(4.0f, 3.0f, 3.0f), System.Numerics.Vector3.Zero, System.Numerics.Vector3.UnitY);
            
            Matrix4X4 view = new Matrix4X4(
                temp.M11, temp.M12, temp.M13, temp.M14,
                temp.M21, temp.M22, temp.M23, temp.M24,
                temp.M31, temp.M32, temp.M33, temp.M34,
                temp.M41, temp.M42, temp.M43, temp.M44
            );
                
            Matrix4x4 temp2 = Matrix4x4.CreatePerspectiveFieldOfView((float)Math.PI / 4, 800.0f / 600.0f, 0.1f, 100.0f);
            
            Matrix4X4 projection = new Matrix4X4(
                temp2.M11, temp2.M12, temp2.M13, temp2.M14,
                temp2.M21, temp2.M22, temp2.M23, temp2.M24,
                temp2.M31, temp2.M32, temp2.M33, temp2.M34,
                temp2.M41, temp2.M42, temp2.M43, temp2.M44
            );
            
            Matrix4x4 temp3 = Matrix4x4.CreateRotationY((float)DateTime.Now.TimeOfDay.TotalSeconds);
            
            Matrix4X4 model = new Matrix4X4(
                temp3.M11, temp3.M12, temp3.M13, temp3.M14,
                temp3.M21, temp3.M22, temp3.M23, temp3.M24,
                temp3.M31, temp3.M32, temp3.M33, temp3.M34,
                temp3.M41, temp3.M42, temp3.M43, temp3.M44
            );
            
            int modelMatrixLocation = Gl.GlGetUniformLocation(shaderProgram, "model");
            Gl.UniformMatrix4Fv(modelMatrixLocation, model);
            
            int viewMatrixLocation = Gl.GlGetUniformLocation(shaderProgram, "view");
            Gl.UniformMatrix4Fv(viewMatrixLocation, view);

            int projectionMatrixLocation = Gl.GlGetUniformLocation(shaderProgram, "projection");
            Gl.UniformMatrix4Fv(projectionMatrixLocation, projection);

            // Draw the cube
            Gl.GlDrawElements(PrimitiveType.Triangles, CubeIndices.Length, DrawElementsType.UnsignedInt, IntPtr.Zero);
        }
    }
}