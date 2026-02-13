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
using System.IO;
using System.Runtime.InteropServices;
using Alis.Core.Aspect.Fluent.Components;
using Alis.Core.Aspect.Logging;
using Alis.Core.Aspect.Math;
using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Ecs.Systems.Scope;
using Alis.Core.Graphic;
using Alis.Core.Graphic.OpenGL;
using Alis.Core.Graphic.OpenGL.Enums;

namespace Alis.Core.Ecs.Components.Render
{
    /// <summary>
    ///     The sprite
    /// </summary>
    public record struct Sprite(Context Context, string NameFile, int Depth) : ISprite
    {
        /// <summary>
        ///     Gets or sets the value of the shader program
        /// </summary>
        // shader and quad buffers are now shared to avoid recompiling/allocating per sprite
        private static uint SharedShaderProgram;

        /// <summary>
        ///     The shared vao
        /// </summary>
        private static uint SharedVao;

        /// <summary>
        ///     The shared vbo
        /// </summary>
        private static uint SharedVbo;

        /// <summary>
        ///     The shared ebo
        /// </summary>
        private static uint SharedEbo;

        /// <summary>
        ///     The shared initialized
        /// </summary>
        private static bool SharedInitialized = false;

        // cached uniform locations
        /// <summary>
        ///     The offset location
        /// </summary>
        private static int OffsetLocation = -1;

        /// <summary>
        ///     The scale location
        /// </summary>
        private static int ScaleLocation = -1;

        /// <summary>
        ///     The rotation location
        /// </summary>
        private static int RotationLocation = -1;

        /// <summary>
        ///     The flip location
        /// </summary>
        private static int FlipLocation = -1;

        /// <summary>
        ///     The texture location
        /// </summary>
        private static int TextureLocation = -1;

        // track last bound texture to avoid redundant binds
        /// <summary>
        ///     The last bound texture
        /// </summary>
        private static uint LastBoundTexture = 0;

        /// <summary>
        ///     The image handle
        /// </summary>
        private GCHandle imageHandle;

        /// <summary>
        ///     Gets or sets the value of the depth
        /// </summary>

        public int Depth { get; set; } = Depth;

        /// <summary>
        ///     Gets or sets the value of the path
        /// </summary>

        private string Path { get; set; } = string.Empty;

        /// <summary>
        ///     Gets or sets the value of the name file
        /// </summary>

        public string NameFile { get; set; } = NameFile;

        /// <summary>
        ///     Gets or sets the value of the size
        /// </summary>

        private Vector2F Size { get; set; }

        /// <summary>
        ///     Gets or sets the value of the texture
        /// </summary>
        private uint Texture { get; set; }

        /// <summary>
        ///     Gets or sets the value of the flip
        /// </summary>

        private bool Flip { get; set; }

        /// <summary>
        ///     Inits the self
        /// </summary>
        /// <param name="self">The self</param>
        public void OnUpdate(IGameObject self)
        {
        }

        /// <summary>
        ///     Updates the self
        /// </summary>
        /// <param name="self">The self</param>
        public void OnStart(IGameObject self)
        {
        }
        
        /// <summary>
        ///     Ons the exit using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        public void OnExit(IGameObject self)
        {
            // free per-instance texture
            try
            {
                if (Texture != 0)
                {
                    Gl.DeleteTexture(Texture);
                    Texture = 0;
                }
            }
            catch (Exception ex)
            {
                Logger.Warning($"Error releasing sprite texture: {ex.Message}");
            }

            Path = string.Empty;
            Logger.Info("Sprite instance resources have been released.");
        }
        
        /// <summary>
        ///     Initializes the shared shaders and quad buffers (run once)
        /// </summary>
        private void InitializeSharedResources()
        {
            if (SharedInitialized)
            {
                return;
            }
            
            string version = Context.Setting.Graphic.PreviewMode ? "#version 300 es\n" : "#version 330 core\n";
            string precision = Context.Setting.Graphic.PreviewMode ? "precision mediump float;\n" : string.Empty;

            string vertexShaderSource = version +
                (Context.Setting.Graphic.PreviewMode ? "in vec3 aPos;\nin vec2 aTexCoord;\nout vec2 TexCoord;\n" : "layout (location = 0) in vec3 aPos;\nlayout (location = 1) in vec2 aTexCoord;\nout vec2 TexCoord;\n") +
                "uniform vec2 offset;\n" +
                "uniform vec2 scale;\n" +
                "uniform float rotation;\n" +
                "uniform int flip;\n" +
                "void main() {\n" +
                "    float radians_ = radians(rotation);\n" +
                "    float cosTheta = cos(radians_);\n" +
                "    float sinTheta = sin(radians_);\n" +
                "    mat2 rotationMatrix = mat2(cosTheta, -sinTheta, sinTheta, cosTheta);\n" +
                "    vec2 scaledPos = aPos.xy * scale;\n" +
                "    vec2 rotatedPos = rotationMatrix * scaledPos;\n" +
                "    gl_Position = vec4(rotatedPos + offset, aPos.z, 1.0);\n" +
                "    if (flip == 1) { TexCoord = vec2(1.0 - aTexCoord.x, aTexCoord.y); }\n" +
                "    else { TexCoord = aTexCoord; }\n" +
                "}\n";

            string fragmentShaderSource = version + precision +
                (Context.Setting.Graphic.PreviewMode ? "in vec2 TexCoord;\nout vec4 FragColor;\n" : "in vec2 TexCoord;\nout vec4 FragColor;\n") +
                "uniform sampler2D texture1;\n" +
                "void main() {\n" +
                "    FragColor = texture(texture1, TexCoord);\n" +
                "}\n";

            uint vertexShader = Gl.GlCreateShader(ShaderType.VertexShader);
            Gl.ShaderSource(vertexShader, vertexShaderSource);
            Gl.GlCompileShader(vertexShader);
            if (!Gl.GetShaderCompileStatus(vertexShader))
            {
                string log = Gl.GetShaderInfoLog(vertexShader);
                Logger.Error($"Vertex shader compilation failed: {log}");
                throw new Exception($"Vertex shader compilation failed: {log}");
            }

            uint fragmentShader = Gl.GlCreateShader(ShaderType.FragmentShader);
            Gl.ShaderSource(fragmentShader, fragmentShaderSource);
            Gl.GlCompileShader(fragmentShader);
            if (!Gl.GetShaderCompileStatus(fragmentShader))
            {
                string log = Gl.GetShaderInfoLog(fragmentShader);
                Logger.Error($"Fragment shader compilation failed: {log}");
                throw new Exception($"Fragment shader compilation failed: {log}");
            }

            SharedShaderProgram = Gl.GlCreateProgram();
            Gl.GlAttachShader(SharedShaderProgram, vertexShader);
            Gl.GlAttachShader(SharedShaderProgram, fragmentShader);
            Gl.GlLinkProgram(SharedShaderProgram);

            // Validar enlace del programa
            int[] linkStatus = new int[1];
            Gl.GlGetProgramiv(SharedShaderProgram, ProgramParameter.LinkStatus, linkStatus);
            if (linkStatus[0] == 0)
            {
                string log = Gl.GetProgramInfoLog(SharedShaderProgram);
                Logger.Error($"Shader program link failed: {log}");
                throw new Exception($"Shader program link failed: {log}");
            }

            Gl.GlDeleteShader(vertexShader);
            Gl.GlDeleteShader(fragmentShader);

            // cache uniform locations after linking
            //Gl.GlUseProgram(SharedShaderProgram);
            OffsetLocation = Gl.GlGetUniformLocation(SharedShaderProgram, "offset");
            ScaleLocation = Gl.GlGetUniformLocation(SharedShaderProgram, "scale");
            RotationLocation = Gl.GlGetUniformLocation(SharedShaderProgram, "rotation");
            FlipLocation = Gl.GlGetUniformLocation(SharedShaderProgram, "flip");
            TextureLocation = Gl.GlGetUniformLocation(SharedShaderProgram, "texture1");
            // set default texture unit (0)
            Gl.GlUniform1I(TextureLocation, 0);
            //Gl.GlUseProgram(0);

            // create a shared unit quad (vertices not pre-scaled)
            float[] vertices =
            {
                1.0f, -1.0f, 0.0f, 1.0f, 0.0f,
                1.0f, 1.0f, 0.0f, 1.0f, 1.0f,
                -1.0f, 1.0f, 0.0f, 0.0f, 1.0f,
                -1.0f, -1.0f, 0.0f, 0.0f, 0.0f
            };

            uint[] indices = {0, 1, 3, 1, 2, 3};

            SharedVao = Gl.GenVertexArray();
            SharedVbo = Gl.GenBuffer();
            SharedEbo = Gl.GenBuffer();

            Gl.GlBindVertexArray(SharedVao);

            Gl.GlBindBuffer(BufferTarget.ArrayBuffer, SharedVbo);
            // pin vertex data briefly for buffer upload
            GCHandle vHandle = GCHandle.Alloc(vertices, GCHandleType.Pinned);
            Gl.GlBufferData(BufferTarget.ArrayBuffer, new IntPtr(vertices.Length * sizeof(float)), vHandle.AddrOfPinnedObject(), BufferUsageHint.StaticDraw);
            vHandle.Free();

            Gl.GlBindBuffer(BufferTarget.ElementArrayBuffer, SharedEbo);
            GCHandle iHandle = GCHandle.Alloc(indices, GCHandleType.Pinned);
            Gl.GlBufferData(BufferTarget.ElementArrayBuffer, new IntPtr(indices.Length * sizeof(uint)), iHandle.AddrOfPinnedObject(), BufferUsageHint.StaticDraw);
            iHandle.Free();

            Gl.VertexAttribPointer(0, 3, VertexAttribPointerType.Float, false, 5 * sizeof(float), IntPtr.Zero);
            Gl.EnableVertexAttribArray(0);

            Gl.VertexAttribPointer(1, 2, VertexAttribPointerType.Float, false, 5 * sizeof(float), new IntPtr(3 * sizeof(float)));
            Gl.EnableVertexAttribArray(1);

            // unbind to be safe
            Gl.GlBindBuffer(BufferTarget.ArrayBuffer, 0);
            Gl.GlBindVertexArray(0);

            SharedInitialized = true;
        }

        /// <summary>
        ///     Loads the texture using the specified image path
        /// </summary>
        /// <param name="imagePath">The image path</param>
        /// <exception cref="FileNotFoundException">Texture file not found </exception>
        internal void LoadTexture(string imagePath)
        {
            Image image;
            if (File.Exists(imagePath))
            {
                image = Image.Load(imagePath);
            }
            else
            {
                string nameToLoadFile = imagePath == string.Empty ? NameFile : imagePath;
                if (NameFile != string.Empty && imagePath != string.Empty && NameFile != imagePath)
                {
                    nameToLoadFile = imagePath;
                    NameFile = imagePath;
                }

                // get name of resources from imagepath:
                image = Image.LoadImageFromResources(nameToLoadFile);
            }


            Size = new Vector2F(image.Width, image.Height);
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


        /// <summary>
        ///     Renders the gameobject
        /// </summary>
        /// <param name="gameobject">The gameobject</param>
        /// <param name="cameraPosition">The camera position</param>
        /// <param name="cameraResolution">The camera resolution</param>
        /// <param name="pixelsPerMeter">The pixels per meter</param>
        public void Render(GameObject gameobject, Vector2F cameraPosition, Vector2F cameraResolution, float pixelsPerMeter)
        {
            // Inicialización de recursos compartidos y textura si es necesario
            if (!string.IsNullOrEmpty(NameFile) && (Path == string.Empty))
            {
                Path = "";
                InitializeSharedResources();
                LoadTexture(Path);
            }

            Vector2F position = gameobject.Get<Transform>().Position;
            float spriteRotation = gameobject.Get<Transform>().Rotation;
            Vector2F transformScale = gameobject.Get<Transform>().Scale;
            
            // Insertar en Render(...) después de obtener position y spriteRotation
            if (!IsSpriteVisible(position, Size, transformScale, spriteRotation, cameraPosition, cameraResolution, pixelsPerMeter))
            {
                return;
            }

            // Escalado físico: tamaño del sprite en metros = (pixeles de la textura / pixelsPerMeter) * escala
            float worldWidth = (Size.X / pixelsPerMeter) * transformScale.X;
            float worldHeight = (Size.Y / pixelsPerMeter) * transformScale.Y;

            // Convertir a NDC (de -1 a 1)
            Vector2F ndcOffset = new Vector2F(
                ((position.X - cameraPosition.X) / (cameraResolution.X / pixelsPerMeter)) * 2.0f,
                ((position.Y - cameraPosition.Y) / (cameraResolution.Y / pixelsPerMeter)) * 2.0f
            );

            Vector2F ndcScale = new Vector2F(
                worldWidth / (cameraResolution.X / pixelsPerMeter),
                worldHeight / (cameraResolution.Y / pixelsPerMeter)
            );

            // Usar shader y VAO compartidos
            Gl.GlUseProgram(SharedShaderProgram);
            Gl.GlBindVertexArray(SharedVao);

            // Uniforms
            Gl.GlUniform2F(OffsetLocation, ndcOffset.X, ndcOffset.Y);
            Gl.GlUniform2F(ScaleLocation, ndcScale.X, ndcScale.Y);
            Gl.GlUniform1F(RotationLocation, spriteRotation);
            Gl.GlUniform1I(FlipLocation, Flip ? 1 : 0);
            Gl.GlUniform1I(TextureLocation, 0); // textura en unidad 0

            // Enlazar textura solo si es diferente a la última
            if (Texture != LastBoundTexture)
            {
                Gl.GlActiveTexture(TextureUnit.Texture0);
                Gl.GlBindTexture(TextureTarget.Texture2D, Texture);
                LastBoundTexture = Texture;
            }

            // Dibujar quad
            Gl.GlDrawElements(PrimitiveType.Triangles, 6, DrawElementsType.UnsignedInt, IntPtr.Zero);

            // Desenlazar VAO y shader por seguridad
            Gl.GlBindVertexArray(0);
            Gl.GlUseProgram(0);
        }
        
        
        /// <summary>
        ///     Ises the sprite visible using the specified sprite world position
        /// </summary>
        /// <param name="spriteWorldPosition">The sprite world position</param>
        /// <param name="spriteSizePixels">The sprite size pixels</param>
        /// <param name="spriteScale">The sprite scale</param>
        /// <param name="rotationDegrees">The rotation degrees</param>
        /// <param name="cameraPosition">The camera position</param>
        /// <param name="cameraResolution">The camera resolution</param>
        /// <param name="pixelsPerMeter">The pixels per meter</param>
        /// <returns>The bool</returns>
        private bool IsSpriteVisible(Vector2F spriteWorldPosition, Vector2F spriteSizePixels, Vector2F spriteScale, float rotationDegrees, Vector2F cameraPosition, Vector2F cameraResolution, float pixelsPerMeter)
        {
            // posición del sprite relativa a la cámara en píxeles (centro de cámara)
            float px = (spriteWorldPosition.X - cameraPosition.X) * pixelsPerMeter;
            float py = (spriteWorldPosition.Y - cameraPosition.Y) * pixelsPerMeter;

            // medias en píxeles
            float halfW = spriteSizePixels.X * spriteScale.X * 0.5f;
            float halfH = spriteSizePixels.Y * spriteScale.Y * 0.5f;

            // ampliar AABB si hay rotación (aprox usando |cos| y |sin|)
            if (CustomMathF.Abs(rotationDegrees) > 0.0001f)
            {
                float rad = rotationDegrees * (CustomMathF.Pi / 180f);
                float c = CustomMathF.Abs(CustomMathF.Cos(rad));
                float s = CustomMathF.Abs(CustomMathF.Sin(rad));
                float rotHalfW = c * halfW + s * halfH;
                float rotHalfH = s * halfW + c * halfH;
                halfW = rotHalfW;
                halfH = rotHalfH;
            }

            float camHalfW = cameraResolution.X * 0.5f;
            float camHalfH = cameraResolution.Y * 0.5f;

            // overlap check (AABB centrado en la cámara)
            return !(CustomMathF.Abs(px) > camHalfW + halfW || CustomMathF.Abs(py) > camHalfH + halfH);
        }
    }
}

