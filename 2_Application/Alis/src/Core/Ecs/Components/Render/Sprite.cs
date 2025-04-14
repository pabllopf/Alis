// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:Sprite.cs
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
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using Alis.Builder.Core.Ecs.Component.Render;
using Alis.Core.Aspect.Data.Json;
using Alis.Core.Aspect.Data.Resource;
using Alis.Core.Aspect.Fluent;
using Alis.Core.Aspect.Logging;
using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Graphic.OpenGL;
using Alis.Core.Graphic.OpenGL.Enums;
using Alis.Core.Graphic.Stb;
using Alis.Core.Physic.Dynamics;

namespace Alis.Core.Ecs.Components.Render
{
    /// <summary>
    ///     The sprite
    /// </summary>
    public struct Sprite(string nameFile, int depth) : ISprite, IInitable, IEntityComponent
    {

        private IGameObject GameObject;
        
        /// <summary>
        ///     Updates the self
        /// </summary>
        /// <param name="self">The self</param>
        public void Init(IGameObject self)
        {
            Logger.Log("Sprite");
            GameObject = self;
        }
        
        /// <summary>
        /// Inits the self
        /// </summary>
        /// <param name="self">The self</param>
        public void Update(IGameObject self)
        {
            Logger.Log("Sprite");
            GameObject = self;
            if (!string.IsNullOrEmpty(NameFile))
            {
                Path = AssetManager.Find(NameFile);
                InitializeShaders();
                LoadTexture(Path);
                SetupBuffers();
            }
        }

        /// <summary>
        ///     The image handle
        /// </summary>
        private GCHandle imageHandle;

        /// <summary>
        ///     The indices handle
        /// </summary>
        private GCHandle indicesHandle;

        /// <summary>
        ///     The vertices handle
        /// </summary>
        private GCHandle verticesHandle;

        /// <summary>
        ///     Gets or sets the value of the depth
        /// </summary>
        [JsonPropertyName("_Depth_")]
        public int Depth { get; set; } = depth;

        /// <summary>
        ///     Gets or sets the value of the path
        /// </summary>
        [JsonIgnore]
        private string Path { get; set; }

        /// <summary>
        ///     Gets or sets the value of the name file
        /// </summary>
        [JsonPropertyName("_NameFile_")]
        public string NameFile { get; set; } = nameFile;

        /// <summary>
        ///     Gets or sets the value of the size
        /// </summary>
        [JsonPropertyName("_Size_")]
        private Vector2F Size { get; set; }

        /// <summary>
        ///     Gets or sets the value of the shader program
        /// </summary>
        private uint ShaderProgram { get; set; }

        /// <summary>
        ///     Gets or sets the value of the vao
        /// </summary>
        private uint Vao { get; set; }

        /// <summary>
        ///     Gets or sets the value of the vbo
        /// </summary>
        private uint Vbo { get; set; }

        /// <summary>
        ///     Gets or sets the value of the ebo
        /// </summary>
        private uint Ebo { get; set; }

        /// <summary>
        ///     Gets or sets the value of the texture
        /// </summary>
        private uint Texture { get; set; }

        /// <summary>
        ///     Gets or sets the value of the flip
        /// </summary>
        [JsonPropertyName("_Flip_")]
        private bool Flip { get; set; }

        /// <summary>
        ///     Initializes the shaders
        /// </summary>
        private void InitializeShaders()
        {
            string vertexShaderSource = @"
             #version 330 core
             layout (location = 0) in vec3 aPos;
             layout (location = 1) in vec2 aTexCoord;
             out vec2 TexCoord;
             uniform vec2 offset;
             uniform vec2 scale;
             uniform float rotation;
             uniform int flip;
             void main()
             {
                 float radians = radians(rotation);
                 float cosTheta = cos(radians);
                 float sinTheta = sin(radians);
                 mat2 rotationMatrix = mat2(cosTheta, -sinTheta, sinTheta, cosTheta);
                 vec2 scaledPos = aPos.xy * scale;
                 vec2 rotatedPos = rotationMatrix * scaledPos;
                 gl_Position = vec4(rotatedPos + offset, aPos.z, 1.0);
                 if (flip == 1)
                 {
                     TexCoord = vec2(1.0 - aTexCoord.x, aTexCoord.y);
                 }
                 else
                 {
                     TexCoord = vec2(aTexCoord.x, aTexCoord.y);
                 }
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

        /// <summary>
        ///     Loads the texture using the specified image path
        /// </summary>
        /// <param name="imagePath">The image path</param>
        /// <exception cref="FileNotFoundException">Texture file not found </exception>
        internal void LoadTexture(string imagePath)
        {
            if (!File.Exists(imagePath))
            {
                throw new FileNotFoundException("Texture file not found", imagePath);
            }

            using (FileStream stream = File.OpenRead(imagePath))
            {
                ImageResult image = ImageResult.FromStream(stream, ColorComponents.RedGreenBlueAlpha);

                Size = new Vector2F(image.Width, image.Height);

                byte r = image.Data[0];
                byte g = image.Data[1];
                byte b = image.Data[2];

                for (int i = 0; i < image.Data.Length; i += 4)
                {
                    if ((image.Data[i] == r) && (image.Data[i + 1] == g) && (image.Data[i + 2] == b))
                    {
                        image.Data[i + 3] = 0;
                    }
                }

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
                Gl.GlTexParameteri(TextureTarget.Texture2D, TextureParameterName.TextureMinFilter, TextureParameter.Nearest);
                Gl.GlTexParameteri(TextureTarget.Texture2D, TextureParameterName.TextureMagFilter, TextureParameter.Nearest);

                imageHandle = GCHandle.Alloc(image.Data, GCHandleType.Pinned);
                Gl.GlTexImage2D(TextureTarget.Texture2D, 0, PixelInternalFormat.Rgba, image.Width, image.Height, 0, PixelFormat.Rgba, PixelType.UnsignedByte, imageHandle.AddrOfPinnedObject());
                imageHandle.Free();

                Gl.GenerateMipmap(TextureTarget.Texture2D);
            }
        }

        /// <summary>
        ///     Setup the buffers
        /// </summary>
        /// <summary>
        ///     Setup the buffers
        /// </summary>
        private void SetupBuffers()
        {
            int windowWidth = (int) 800;
            int windowHeight = (int) 600;

            float scaleX = Size.X / windowWidth;
            float scaleY = Size.Y / windowHeight;

            float[] vertices =
            {
                1 * scaleX, -1 * scaleY, 0.0f, 1.0f, 0.0f,
                1 * scaleX, 1 * scaleY, 0.0f, 1.0f, 1.0f,
                -1 * scaleX, 1 * scaleY, 0.0f, 0.0f, 1.0f,
                -1 * scaleX, -1 * scaleY, 0.0f, 0.0f, 0.0f
            };

            uint[] indices = {0, 1, 3, 1, 2, 3};

            Vao = Gl.GenVertexArray();
            Vbo = Gl.GenBuffer();
            Ebo = Gl.GenBuffer();

            Gl.GlBindVertexArray(Vao);

            Gl.GlBindBuffer(BufferTarget.ArrayBuffer, Vbo);
            verticesHandle = GCHandle.Alloc(vertices, GCHandleType.Pinned);
            Gl.GlBufferData(BufferTarget.ArrayBuffer, new IntPtr(vertices.Length * sizeof(float)), verticesHandle.AddrOfPinnedObject(), BufferUsageHint.StaticDraw);
            verticesHandle.Free();

            Gl.GlBindBuffer(BufferTarget.ElementArrayBuffer, Ebo);
            indicesHandle = GCHandle.Alloc(indices, GCHandleType.Pinned);
            Gl.GlBufferData(BufferTarget.ElementArrayBuffer, new IntPtr(indices.Length * sizeof(uint)), indicesHandle.AddrOfPinnedObject(), BufferUsageHint.StaticDraw);
            indicesHandle.Free();

            Gl.VertexAttribPointer(0, 3, VertexAttribPointerType.Float, false, 5 * sizeof(float), IntPtr.Zero);
            Gl.EnableVertexAttribArray(0);

            Gl.VertexAttribPointer(1, 2, VertexAttribPointerType.Float, false, 5 * sizeof(float), new IntPtr(3 * sizeof(float)));
            Gl.EnableVertexAttribArray(1);
        }
        
        public void Render(Vector2F cameraPosition, Vector2F cameraResolution, float pixelsPerMeter)
        {
            Vector2F position = GameObject.Get<Transform>().Position;
            float spriteRotation = GameObject.Get<Transform>().Rotation.R;

            Gl.GlUseProgram(ShaderProgram);
            Gl.GlBindVertexArray(Vao);
            Gl.GlBindBuffer(BufferTarget.ElementArrayBuffer, Ebo);
            Gl.GlBindBuffer(BufferTarget.ArrayBuffer, Vbo);

            // Conversión de metros a píxeles
            float positionXPixels = (position.X - cameraPosition.X) * pixelsPerMeter;
            float positionYPixels = (position.Y - cameraPosition.Y) * pixelsPerMeter;

            // Normalizar a coordenadas OpenGL (-1 a 1) usando la resolución de la cámara
            float worldX = 2.0f * positionXPixels / cameraResolution.X;
            float worldY = 2.0f * positionYPixels / cameraResolution.Y;

            // Enviar valores normalizados al shader
            int offsetLocation = Gl.GlGetUniformLocation(ShaderProgram, "offset");
            Gl.GlUniform2F(offsetLocation, worldX, worldY);

            int scaleLocation = Gl.GlGetUniformLocation(ShaderProgram, "scale");
            Gl.GlUniform2F(scaleLocation, GameObject.Get<Transform>().Scale.X, GameObject.Get<Transform>().Scale.Y);

            int rotationLocation = Gl.GlGetUniformLocation(ShaderProgram, "rotation");
            Gl.GlUniform1F(rotationLocation, spriteRotation);

            // Enviar la propiedad Flip al shader
            int flipLocation = Gl.GlGetUniformLocation(ShaderProgram, "flip");
            Gl.GlUniform1I(flipLocation, Flip ? 1 : 0);

            // Activar blending para manejar transparencias
            Gl.GlEnable(EnableCap.Blend);
            Gl.GlBlendFunc(BlendingFactorSrc.SrcAlpha, BlendingFactorDest.OneMinusSrcAlpha);

            // Vincular la textura antes de dibujar
            Gl.GlBindTexture(TextureTarget.Texture2D, Texture);

            // Dibujar el sprite
            Gl.GlDrawElements(PrimitiveType.Triangles, 6, DrawElementsType.UnsignedInt, IntPtr.Zero);

            Gl.GlDisable(EnableCap.Blend);
        }
    }
}