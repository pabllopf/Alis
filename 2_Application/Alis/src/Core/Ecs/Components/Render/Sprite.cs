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
using Alis.Core.Aspect.Data.Resource;
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
    public record struct Sprite(Context context, string NameFile, int Depth) : ISprite
    {
        /// <summary>
        ///     The image handle
        /// </summary>

        private GCHandle imageHandle;

        /// <summary>
        ///     The vertices handle
        /// </summary>

        // removed per-instance vertices/indices handles - we use shared buffers now

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
        ///     Gets or sets the value of the shader program
        /// </summary>
        // shader and quad buffers are now shared to avoid recompiling/allocating per sprite
        private static uint SharedShaderProgram;
        private static uint SharedVao;
        private static uint SharedVbo;
        private static uint SharedEbo;
        private static bool SharedInitialized = false;

        // cached uniform locations
        private static int OffsetLocation = -1;
        private static int ScaleLocation = -1;
        private static int RotationLocation = -1;
        private static int FlipLocation = -1;
        private static int TextureLocation = -1;

        // track last bound texture to avoid redundant binds
        private static uint LastBoundTexture = 0;

        /// <summary>
        /// Called once per frame before rendering sprites to reset cached state and enable blending.
        /// </summary>
        public static void BeginFrame()
        {
            // ensure shader and buffers initialized
            InitializeSharedResources();
            // reset last bound texture to force the first bind
            LastBoundTexture = 0;
            // enable blending once per frame
            Gl.GlEnable(EnableCap.Blend);
            Gl.GlBlendFunc(BlendingFactorSrc.SrcAlpha, BlendingFactorDest.OneMinusSrcAlpha);
        }

        /// <summary>
        /// Called after rendering sprites for the frame to optionally restore GL state.
        /// </summary>
        public static void EndFrame()
        {
            // optionally disable blending; some renderers prefer leaving it enabled
            Gl.GlDisable(EnableCap.Blend);
            // unbind VAO and program for cleanliness
            Gl.GlBindVertexArray(0);
            Gl.GlUseProgram(0);
        }

        /// <summary>
        /// Release shared GL resources used by Sprite (call on application shutdown)
        /// </summary>
        public static void ReleaseSharedResources()
        {
            if (!SharedInitialized)
                return;

            if (SharedVao != 0) Gl.DeleteVertexArray(SharedVao);
            if (SharedVbo != 0) Gl.DeleteBuffer(SharedVbo);
            if (SharedEbo != 0) Gl.DeleteBuffer(SharedEbo);
            if (SharedShaderProgram != 0) Gl.GlDeleteProgram(SharedShaderProgram);

            SharedVao = 0;
            SharedVbo = 0;
            SharedEbo = 0;
            SharedShaderProgram = 0;
            SharedInitialized = false;
            LastBoundTexture = 0;
        }

        /// <summary>
        ///     Gets or sets the value of the vao
        /// </summary>
        // removed per-instance Vao/Vbo/Ebo

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
        ///     Initializes the shared shaders and quad buffers (run once)
        /// </summary>
        private static void InitializeSharedResources()
        {
            if (SharedInitialized)
                return;

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

            SharedShaderProgram = Gl.GlCreateProgram();
            Gl.GlAttachShader(SharedShaderProgram, vertexShader);
            Gl.GlAttachShader(SharedShaderProgram, fragmentShader);
            Gl.GlLinkProgram(SharedShaderProgram);

            Gl.GlDeleteShader(vertexShader);
            Gl.GlDeleteShader(fragmentShader);

            // cache uniform locations after linking
            Gl.GlUseProgram(SharedShaderProgram);
            OffsetLocation = Gl.GlGetUniformLocation(SharedShaderProgram, "offset");
            ScaleLocation = Gl.GlGetUniformLocation(SharedShaderProgram, "scale");
            RotationLocation = Gl.GlGetUniformLocation(SharedShaderProgram, "rotation");
            FlipLocation = Gl.GlGetUniformLocation(SharedShaderProgram, "flip");
            TextureLocation = Gl.GlGetUniformLocation(SharedShaderProgram, "texture1");
            // set default texture unit (0)
            Gl.GlUniform1I(TextureLocation, 0);
            Gl.GlUseProgram(0);

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
            var vHandle = GCHandle.Alloc(vertices, GCHandleType.Pinned);
            Gl.GlBufferData(BufferTarget.ArrayBuffer, new IntPtr(vertices.Length * sizeof(float)), vHandle.AddrOfPinnedObject(), BufferUsageHint.StaticDraw);
            vHandle.Free();

            Gl.GlBindBuffer(BufferTarget.ElementArrayBuffer, SharedEbo);
            var iHandle = GCHandle.Alloc(indices, GCHandleType.Pinned);
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

        // removed SetupBuffers per-instance; we use shared buffers

        /// <summary>
        ///     Renders the gameobject
        /// </summary>
        /// <param name="gameobject">The gameobject</param>
        /// <param name="cameraPosition">The camera position</param>
        /// <param name="cameraResolution">The camera resolution</param>
        /// <param name="pixelsPerMeter">The pixels per meter</param>
        public void Render(GameObject gameobject, Vector2F cameraPosition, Vector2F cameraResolution, float pixelsPerMeter)
        {
            if (!string.IsNullOrEmpty(NameFile) && (Path == string.Empty))
            {
                Path = AssetManager.Find(NameFile);
                // Initialize shared shader+buffers once
                InitializeSharedResources();
                LoadTexture(Path);
                // no per-instance buffers to setup
            }

            Vector2F position = gameobject.Get<Transform>().Position;
            float spriteRotation = gameobject.Get<Transform>().Rotation;
            var transformScale = gameobject.Get<Transform>().Scale;
            
            // Insertar en Render(...) después de obtener position y spriteRotation
            if (!IsSpriteVisible(position, Size, transformScale, spriteRotation, cameraPosition, cameraResolution, pixelsPerMeter))
                return;

            Gl.GlUseProgram(SharedShaderProgram);
            Gl.GlBindVertexArray(SharedVao);
            Gl.GlBindBuffer(BufferTarget.ElementArrayBuffer, SharedEbo);
            Gl.GlBindBuffer(BufferTarget.ArrayBuffer, SharedVbo);

            // Conversión de metros a píxeles
            float positionXPixels = (position.X - cameraPosition.X) * pixelsPerMeter;
            float positionYPixels = (position.Y - cameraPosition.Y) * pixelsPerMeter;

            // Normalizar a coordenadas OpenGL (-1 a 1) usando la resolución de la cámara
            float worldX = 2.0f * positionXPixels / cameraResolution.X;
            float worldY = 2.0f * positionYPixels / cameraResolution.Y;

            // Enviar valores normalizados al shader
            Gl.GlUniform2F(OffsetLocation, worldX, worldY);

            // compute scale uniform so that quad vertices (which are -1..1) are scaled to sprite pixel size
            int windowWidth = (int)Context.Setting.Graphic.WindowSize.X;
            int windowHeight = (int)Context.Setting.Graphic.WindowSize.Y;

            // scaleX/Y convert sprite pixel size into normalized device coordinates factor used by vertex shader
            float scaleX = (Size.X / windowWidth) * transformScale.X;
            float scaleY = (Size.Y / windowHeight) * transformScale.Y;

            Gl.GlUniform2F(ScaleLocation, scaleX, scaleY);
            Gl.GlUniform1F(RotationLocation, spriteRotation);
            Gl.GlUniform1I(FlipLocation, Flip ? 1 : 0);

            // Vincular la textura antes de dibujar (evitar binds redundantes)
            if (LastBoundTexture != Texture)
            {
                Gl.GlBindTexture(TextureTarget.Texture2D, Texture);
                LastBoundTexture = Texture;
            }

            // Dibujar el sprite
            Gl.GlDrawElements(PrimitiveType.Triangles, 6, DrawElementsType.UnsignedInt, IntPtr.Zero);

            // NOTE: blending should ideally be enabled once per frame by the renderer/system to avoid overhead.
        }
        
       
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
        


        
        /// <summary>
        /// Gets or sets the value of the context
        /// </summary>
        public Context Context { get; set; } = context;
        
        /// <summary>
        /// Ons the exit using the specified self
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
    }
}
