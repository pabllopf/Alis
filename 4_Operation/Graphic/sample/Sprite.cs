using System;
using System.IO;
using System.Runtime.InteropServices;
using Alis.Core.Graphic.OpenGL;
using Alis.Core.Graphic.OpenGL.Enums;
using Alis.Core.Graphic.Stb;

namespace Alis.Core.Graphic.Sample
            {
                public class Sprite
                {
                    public uint ShaderProgram { get; private set; }
                    public uint Vao { get; private set; }
                    public uint Vbo { get; private set; }
                    public uint Ebo { get; private set; }
                    public uint Texture { get; private set; }
                    public float X { get; set; }
                    public float Y { get; set; }
            
                    public Sprite(string imagePath, float x, float y)
                    {
                        X = x;
                        Y = y;
                        InitializeShaders();
                        LoadTexture(imagePath);
                        SetupBuffers();
                    }
            
                    private void InitializeShaders()
                    {
                        string vertexShaderSource = @"
                            #version 330 core
                            layout (location = 0) in vec3 aPos;
                            layout (location = 1) in vec2 aTexCoord;
                            out vec2 TexCoord;
                            uniform vec2 offset;
                            void main()
                            {
                                gl_Position = vec4(aPos.xy + offset, aPos.z, 1.0);
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
            
                        ShaderProgram = Gl.GlCreateProgram();
                        Gl.GlAttachShader(ShaderProgram, vertexShader);
                        Gl.GlAttachShader(ShaderProgram, fragmentShader);
                        Gl.GlLinkProgram(ShaderProgram);
            
                        Gl.GlDeleteShader(vertexShader);
                        Gl.GlDeleteShader(fragmentShader);
                    }
            
                    private void LoadTexture(string imagePath)
                    {
                        if (!File.Exists(imagePath))
                        {
                            throw new FileNotFoundException("Texture file not found", imagePath);
                        }
                        
                        Console.WriteLine($"Loading texture: {imagePath}");
            
                        using (FileStream stream = File.OpenRead(imagePath))
                        {
                            ImageResult image = ImageResult.FromStream(stream, ColorComponents.RedGreenBlueAlpha);
                            
                            // Detect the background color (e.g., the color of the first pixel)
                            byte r = image.Data[0];
                            byte g = image.Data[1];
                            byte b = image.Data[2];
            
                            // Replace the background color with transparency
                            for (int i = 0; i < image.Data.Length; i += 4)
                            {
                                if (image.Data[i] == r && image.Data[i + 1] == g && image.Data[i + 2] == b)
                                {
                                    image.Data[i + 3] = 0; // Set alpha to 0 (transparent)
                                }
                            }
            
                            // Invert the image in the Y-axis
                            for (int y = 0; y < image.Height / 2; y++)
                            {
                                for (int x = 0; x < image.Width * 4; x++)
                                {
                                    (image.Data[y * image.Width * 4 + x], image.Data[(image.Height - 1 - y) * image.Width * 4 + x]) = (image.Data[(image.Height - 1 - y) * image.Width * 4 + x], image.Data[y * image.Width * 4 + x]);
                                }
                            }
            
                            Texture = Gl.GenTexture();
                            Gl.GlBindTexture(TextureTarget.Texture2D, Texture);
            
                            Gl.GlTexParameteri(TextureTarget.Texture2D, TextureParameterName.TextureWrapS, TextureParameter.ClampToEdge);
                            Gl.GlTexParameteri(TextureTarget.Texture2D, TextureParameterName.TextureWrapT, TextureParameter.ClampToEdge);
                            Gl.GlTexParameteri(TextureTarget.Texture2D, TextureParameterName.TextureMinFilter, TextureParameter.Linear);
                            Gl.GlTexParameteri(TextureTarget.Texture2D, TextureParameterName.TextureMagFilter, TextureParameter.Linear);
            
                            GCHandle imageHandle = GCHandle.Alloc(image.Data, GCHandleType.Pinned);
                            Gl.GlTexImage2D(TextureTarget.Texture2D, 0, PixelInternalFormat.Rgba, image.Width, image.Height, 0, PixelFormat.Rgba, PixelType.UnsignedByte, imageHandle.AddrOfPinnedObject());
                            imageHandle.Free();
            
                            Gl.GenerateMipmap(TextureTarget.Texture2D);
                        }
                    }
            
                    private void SetupBuffers()
                    {
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
                            1 * scaleX,  1 * scaleY, 0.0f,  1.0f, 0.0f, // Top Right
                            1 * scaleX, -1 * scaleY, 0.0f,  1.0f, 1.0f, // Bottom Right
                            -1 * scaleX, -1 * scaleY, 0.0f,  0.0f, 1.0f, // Bottom Left
                            -1 * scaleX,  1f * scaleY, 0.0f,  0.0f, 0.0f  // Top Left
                        };
            
                        uint[] indices = { 0, 1, 3, 1, 2, 3 };
            
                        Vao = Gl.GenVertexArray();
                        Vbo = Gl.GenBuffer();
                        Ebo = Gl.GenBuffer();
            
                        Gl.GlBindVertexArray(Vao);
            
                        Gl.GlBindBuffer(BufferTarget.ArrayBuffer, Vbo);
                        GCHandle verticesHandle = GCHandle.Alloc(vertices, GCHandleType.Pinned);
                        Gl.GlBufferData(BufferTarget.ArrayBuffer, vertices.Length * sizeof(float), verticesHandle.AddrOfPinnedObject(), BufferUsageHint.StaticDraw);
                        verticesHandle.Free();
            
                        Gl.GlBindBuffer(BufferTarget.ElementArrayBuffer, Ebo);
                        GCHandle indicesHandle = GCHandle.Alloc(indices, GCHandleType.Pinned);
                        Gl.GlBufferData(BufferTarget.ElementArrayBuffer, indices.Length * sizeof(uint), indicesHandle.AddrOfPinnedObject(), BufferUsageHint.StaticDraw);
                        indicesHandle.Free();
            
                        Gl.VertexAttribPointer(0, 3, VertexAttribPointerType.Float, false, 5 * sizeof(float), IntPtr.Zero);
                        Gl.EnableVertexAttribArray(0);
            
                        Gl.VertexAttribPointer(1, 2, VertexAttribPointerType.Float, false, 5 * sizeof(float), (IntPtr)(3 * sizeof(float)));
                        Gl.EnableVertexAttribArray(1);
                    }
            
                    public void Draw()
                    {
                        Gl.GlUseProgram(ShaderProgram);
                        int offsetLocation = Gl.GlGetUniformLocation(ShaderProgram, "offset");
                        Gl.GlUniform2F(offsetLocation, X, Y);
                        Gl.GlBindVertexArray(Vao);
                        Gl.GlEnable(EnableCap.Blend);
                        Gl.GlBlendFunc(BlendingFactorSrc.SrcAlpha, BlendingFactorDest.OneMinusSrcAlpha);
                        Gl.GlDrawElements(PrimitiveType.Triangles, 6, DrawElementsType.UnsignedInt, IntPtr.Zero);
                        Gl.GlDisable(EnableCap.Blend);
                    }
                }
            }