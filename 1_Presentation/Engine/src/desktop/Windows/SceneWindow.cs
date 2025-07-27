// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:SceneWindow.cs
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
using Alis.App.Engine.Desktop.Core;
using Alis.Core.Aspect.Logging;
using Alis.Core.Aspect.Math.Matrix;
using Alis.Core.Graphic.OpenGL;
using Alis.Core.Graphic.OpenGL.Enums;
using Alis.Extension.Graphic.Ui;
using Alis.Extension.Graphic.Ui.Fonts;

namespace Alis.App.Engine.Desktop.Windows
{
    /// <summary>
    ///     The scene window class
    /// </summary>
    public class SceneWindow : IWindow
    {
        /// <summary>
        ///     The hashtag
        /// </summary>
        private static readonly string NameWindow = $"{FontAwesome5.Hashtag} Scene";
        
        private bool _isOpen = true;
        
        // PREVIEW WINDOWS:
        private  uint shaderProgram;
        private  uint vao;
        private  uint vbo;
        private  uint _previewTexture;
        private  int _previewWidth = 512, _previewHeight = 512;
        
        /// <summary>
        ///     Initializes a new instance of the <see cref="SceneWindow" /> class
        /// </summary>
        /// <param name="spaceWork">The space work</param>
        public SceneWindow(SpaceWork spaceWork) => SpaceWork = spaceWork;

        /// <summary>
        ///     Gets the value of the space work
        /// </summary>
        public SpaceWork SpaceWork { get; }

        /// <summary>
        ///     Initializes this instance
        /// </summary>
        public void Initialize()
        {
        }

        public void Start()
        {
            // Initialize OpenGL resources for the preview
            InitializePreviewResources();
        }

        public void Render()
        {
            if (!_isOpen)
            {
                return;
            }
            
            // Render the triangle directly to the OpenGL context
            RenderTriangleDirectly();
            
            // Show the preview image in ImGui
            ShowPreviewImage();
            
            if (ImGui.Begin(NameWindow, ref _isOpen, ImGuiWindowFlags.NoCollapse))
            {
                ImGui.Image((IntPtr) _previewTexture, ImGui.GetContentRegionAvail());
            }
            
            ImGui.End();
        }
        
          private void InitializePreviewResources()
        {
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
                Gl.GlBufferData(BufferTarget.ArrayBuffer, new IntPtr(vertices.Length * sizeof(float)), pointer, BufferUsageHint.StaticDraw);
            }
            finally
            {
                if (handle.IsAllocated)
                {
                    handle.Free();
                }
            }

            _previewTexture = Gl.GenTexture();
            Gl.GlBindTexture(TextureTarget.Texture2D, _previewTexture);
            Gl.GlTexImage2D(TextureTarget.Texture2D, 0, PixelInternalFormat.Rgba, _previewWidth, _previewHeight, 0, PixelFormat.Rgba, PixelType.UnsignedByte, IntPtr.Zero);
            Gl.GlTexParameteri(TextureTarget.Texture2D, TextureParameterName.TextureMinFilter, TextureParameter.Linear);
            Gl.GlTexParameteri(TextureTarget.Texture2D, TextureParameterName.TextureMagFilter, TextureParameter.Linear);

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
            Logger.Log(@$"OpenGL VERSION {Gl.GlGetString(StringName.Version)}");

            // Print the OpenGL vendor
            Logger.Log(@$"OpenGL VENDOR {Gl.GlGetString(StringName.Vendor)}");

            // Print the OpenGL renderer
            Logger.Log(@$"OpenGL RENDERER {Gl.GlGetString(StringName.Renderer)}");

            // Print the OpenGL shading language version
            Logger.Log(@$"OpenGL SHADING LANGUAGE VERSION {Gl.GlGetString(StringName.ShadingLanguageVersion)}");
        }
        
         private  void RenderTriangleDirectly()
        {
            // Configura el viewport para la ventana principal
            Gl.GlViewport(0, 0, _previewWidth, _previewHeight);

            // Limpia el color de fondo
            Gl.GlClearColor(0.8f, 0.1f, 0.1f, 1.0f); // Fondo rojo
            Gl.GlClear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

            // Usa el programa de shaders y el VAO
            Gl.GlUseProgram(shaderProgram);
            Gl.GlBindVertexArray(vao);

            // Aplica la transformación al triángulo
            Matrix4X4 transform = Matrix4X4.CreateRotationZ((float) DateTime.Now.TimeOfDay.TotalSeconds);
            int transformLocation = Gl.GlGetUniformLocation(shaderProgram, "transform");
            Gl.UniformMatrix4Fv(transformLocation, transform);

            // Dibuja el triángulo
            Gl.GlDrawArrays(PrimitiveType.Triangles, 0, 3);

            // Desactiva el VAO y el programa de shaders
            Gl.GlBindVertexArray(0);
            Gl.GlUseProgram(0);
        }

        private  void ShowPreviewImage()
        {

            // Copia el framebuffer a una textura para ImGui
            byte[] pixelBuffer = new byte[_previewWidth * _previewHeight * 4];

            GCHandle handle2 = GCHandle.Alloc(pixelBuffer, GCHandleType.Pinned);
            try
            {
                Gl.GlReadPixels(0, 0, _previewWidth, _previewHeight, PixelFormat.Rgba, PixelType.UnsignedByte, handle2.AddrOfPinnedObject());
            }
            finally
            {
                handle2.Free();
            }

            Gl.GlBindTexture(TextureTarget.Texture2D, _previewTexture);
            GCHandle handle = GCHandle.Alloc(pixelBuffer, GCHandleType.Pinned);
            try
            {
                Gl.GlTexImage2D(TextureTarget.Texture2D, 0, PixelInternalFormat.Rgba, _previewWidth, _previewHeight, 0, PixelFormat.Rgba, PixelType.UnsignedByte, handle.AddrOfPinnedObject());
            }
            finally
            {
                handle.Free();
            }

            Gl.GlBindTexture(TextureTarget.Texture2D, 0);
        }
    }
}