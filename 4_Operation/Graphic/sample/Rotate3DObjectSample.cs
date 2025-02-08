using System;
using System.IO;
using System.Numerics;
using System.Runtime.InteropServices;
using Alis.Core.Graphic.GlfwLib;
using Alis.Core.Graphic.GlfwLib.Enums;
using Alis.Core.Graphic.GlfwLib.Structs;
using Alis.Core.Graphic.OpenGL;
using Alis.Core.Graphic.OpenGL.Enums;
using Alis.Core.Graphic.Stb;
using Exception = System.Exception;

namespace Alis.Core.Graphic.Sample
{
    public class Rotate3DObjectSample
    {
        private bool running = true;
        private uint shaderProgram;
        private uint vao;
        private uint vbo;
        private uint ebo;
        private uint texture;
        private Window window;

        public void Draw()
        {
            Gl.GlUseProgram(shaderProgram);
            Gl.GlBindVertexArray(vao);
            Gl.GlDrawElements(PrimitiveType.Triangles, 6, DrawElementsType.UnsignedInt, IntPtr.Zero);
        }

        public void Run()
        {
            if (!Glfw.Init())
            {
                throw new Exception("Failed to initialize GLFW");
            }

            Glfw.WindowHint(Hint.ContextVersionMajor, 3);
            Glfw.WindowHint(Hint.ContextVersionMinor, 3);
            Glfw.WindowHint(Hint.OpenglProfile, Profile.Core);
            Glfw.WindowHint(Hint.OpenglForwardCompatible, true);

            window = Glfw.CreateWindow(800, 600, "OpenGL Window", Monitor.None, Window.None);
            if (window == Window.None)
            {
                throw new Exception("Failed to create GLFW window");
            }

            Glfw.MakeContextCurrent(window);
            Glfw.SwapInterval(1);

            // Dimensiones de la ventana
            int windowWidth = 800;
            int windowHeight = 600;

            // Dimensiones de la imagen
            int imageWidth = 16; // Ajusta esto al tamaño real de tu imagen
            int imageHeight = 32; // Ajusta esto al tamaño real de tu imagen

            // Factor de escalado
            float scaleX = (float)imageWidth / windowWidth;
            float scaleY = (float)imageHeight / windowHeight;

            // Vértices con coordenadas de textura invertidas y aplicando el factor de escalado
            float[] vertices =
            {
                // Positions                          // Texture Coords
                1 * scaleX, 1 * scaleY, 0.0f, 1.0f, 0.0f, // Top Right
                1 * scaleX, -1 * scaleY, 0.0f, 1.0f, 1.0f, // Bottom Right
                -1 * scaleX, -1 * scaleY, 0.0f, 0.0f, 1.0f, // Bottom Left
                -1 * scaleX, 1f * scaleY, 0.0f, 0.0f, 0.0f // Top Left
            };

            uint[] indices = { 0, 1, 3, 1, 2, 3 };

            vao = Gl.GenVertexArray();
            vbo = Gl.GenBuffer();
            ebo = Gl.GenBuffer();

            Gl.GlBindVertexArray(vao);

            Gl.GlBindBuffer(BufferTarget.ArrayBuffer, vbo);
            GCHandle verticesHandle = GCHandle.Alloc(vertices, GCHandleType.Pinned);
            Gl.GlBufferData(BufferTarget.ArrayBuffer, vertices.Length * sizeof(float),
                verticesHandle.AddrOfPinnedObject(), BufferUsageHint.StaticDraw);
            verticesHandle.Free();

            Gl.GlBindBuffer(BufferTarget.ElementArrayBuffer, ebo);
            GCHandle indicesHandle = GCHandle.Alloc(indices, GCHandleType.Pinned);
            Gl.GlBufferData(BufferTarget.ElementArrayBuffer, indices.Length * sizeof(uint),
                indicesHandle.AddrOfPinnedObject(), BufferUsageHint.StaticDraw);
            indicesHandle.Free();

            Gl.VertexAttribPointer(0, 3, VertexAttribPointerType.Float, false, 5 * sizeof(float), IntPtr.Zero);
            Gl.EnableVertexAttribArray(0);

            Gl.VertexAttribPointer(1, 2, VertexAttribPointerType.Float, false, 5 * sizeof(float),
                (IntPtr)(3 * sizeof(float)));
            Gl.EnableVertexAttribArray(1);

            string vertexShaderSource = @"
            #version 330 core
            layout (location = 0) in vec3 aPos;
            layout (location = 1) in vec2 aTexCoord;
            out vec2 TexCoord;
            uniform mat3 transform;
            void main()
            {
                vec3 pos = transform * vec3(aPos.xy, 1.0);
                gl_Position = vec4(pos.xy, 0.0, 1.0);
                TexCoord = vec2(aTexCoord.x, 1.0 - aTexCoord.y); // Flip Y-coordinate
            }
            ";

            string fragmentShaderSource = @"
               #version 330 core
               out vec4 FragColor;
               in vec2 TexCoord;
               uniform sampler2D texture1;
               void main()
               {
                   FragColor = texture(texture1, TexCoord);
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

            Gl.GlDeleteShader(vertexShader);
            Gl.GlDeleteShader(fragmentShader);

            // Load and bind texture
            string imagePath = Path.Combine(Environment.CurrentDirectory, "tile000.bmp");
            if (!File.Exists(imagePath))
            {
                throw new FileNotFoundException("Texture file not found", imagePath);
            }

            using (FileStream stream = File.OpenRead(imagePath))
            {
                ImageResult image = ImageResult.FromStream(stream, ColorComponents.RedGreenBlueAlpha);

                // Invert the image in the Y-axis
                for (int y = 0; y < image.Height / 2; y++)
                {
                    for (int x = 0; x < image.Width * 4; x++)
                    {
                        (image.Data[y * image.Width * 4 + x],
                            image.Data[(image.Height - 1 - y) * image.Width * 4 + x]) = (
                            image.Data[(image.Height - 1 - y) * image.Width * 4 + x],
                            image.Data[y * image.Width * 4 + x]);
                    }
                }

                texture = Gl.GenTexture();
                Gl.GlBindTexture(TextureTarget.Texture2D, texture);

                Gl.GlTexParameteri(TextureTarget.Texture2D, TextureParameterName.TextureWrapS,
                    TextureParameter.ClampToEdge);
                Gl.GlTexParameteri(TextureTarget.Texture2D, TextureParameterName.TextureWrapT,
                    TextureParameter.ClampToEdge);
                Gl.GlTexParameteri(TextureTarget.Texture2D, TextureParameterName.TextureMinFilter,
                    TextureParameter.Linear);
                Gl.GlTexParameteri(TextureTarget.Texture2D, TextureParameterName.TextureMagFilter,
                    TextureParameter.Linear);

                GCHandle imageHandle = GCHandle.Alloc(image.Data, GCHandleType.Pinned);
                Gl.GlTexImage2D(TextureTarget.Texture2D, 0, PixelInternalFormat.Rgba, image.Width, image.Height, 0,
                    PixelFormat.Rgba, PixelType.UnsignedByte, imageHandle.AddrOfPinnedObject());
                imageHandle.Free();

                Gl.GenerateMipmap(TextureTarget.Texture2D);
            }

            Gl.GlUseProgram(shaderProgram);
            Gl.GlUniform1F(Gl.GlGetUniformLocation(shaderProgram, "texture1"), 0);

            float xPosition = 0.0f;
            float yPosition = 0.0f;
            
            while (running)
            {
                Glfw.PollEvents();
                if (Glfw.WindowShouldClose(window))
                {
                    running = false;
                }
            
                // Handle keyboard input
                if (Glfw.GetKey(window, Keys.W) == InputState.Press)
                {
                    yPosition += 0.01f;
                }
            
                if (Glfw.GetKey(window, Keys.S) == InputState.Press)
                {
                    yPosition -= 0.01f;
                }
            
                if (Glfw.GetKey(window, Keys.A) == InputState.Press)
                {
                    xPosition -= 0.01f;
                }
            
                if (Glfw.GetKey(window, Keys.D) == InputState.Press)
                {
                    xPosition += 0.01f;
                }
            
                Gl.GlClear(ClearBufferMask.ColorBufferBit);
            
                // Update the transformation matrix
                Matrix3x2 transform = Matrix3x2.CreateTranslation(xPosition, yPosition);
                float[] transformArray =
                {
                    transform.M11, transform.M12,
                    transform.M21, transform.M22,
                    transform.M31, transform.M32
                };
            
                int transformLoc = Gl.GlGetUniformLocation(shaderProgram, "transform");
                Gl.GlUniformMatrix3Fv(transformLoc, 1, false, transformArray);
            
                Draw();
                Glfw.SwapBuffers(window);
            }


            Gl.DeleteVertexArray(vao);
            Gl.DeleteBuffer(vbo);
            Gl.DeleteBuffer(ebo);
            Gl.GlDeleteProgram(shaderProgram);
            Gl.DeleteTexture(texture);
        }
    }
}
