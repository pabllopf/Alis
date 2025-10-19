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
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using Alis.Core.Aspect.Data.Resource;
using Alis.Core.Aspect.Math.Definition;
using Alis.Core.Aspect.Math.Shape.Rectangle;
using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Graphic.OpenGL;
using Alis.Core.Graphic.OpenGL.Enums;

namespace Alis.Core.Graphic.Ui
{
    /// <summary>
    ///     The sprite
    /// </summary>
    public class Font(string NameFile, int Depth, int size, string fullPath)
    {
        /// <summary>
        ///     The image handle
        /// </summary>
        private GCHandle imageHandle;
        
        /// <summary>
        /// The size
        /// </summary>
        private int sizeFont = size;
        
        /// <summary>
        /// The full path
        /// </summary>
        private string fullPathFont = fullPath;

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
                uniform vec4 colorFont;
                uniform vec4 colorBackgroundFont;
                void main()
                {
                    vec4 texColor = texture(texture1, TexCoord);
                    if (texColor.a > 0.0)
                        FragColor = vec4(colorFont.rgb, colorFont.a * texColor.a);
                    else
                        FragColor = colorBackgroundFont;
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
            Image image;
            if (File.Exists(imagePath))
            {
                image = Image.Load(imagePath);
            }
            else
            {
                // get name of resources from imagepath:
                image = Image.LoadImageFromResources(NameFile);
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
        ///     Setup the buffers
        /// </summary>
        /// <summary>
        ///     Setup the buffers
        /// </summary>
        private void SetupBuffers()
        {
            int windowWidth = 800;
            int windowHeight = 600;

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


        // Diccionario para las posiciones de cada carácter en el atlas
        /// <summary>
        /// The character rects
        /// </summary>
        private Dictionary<char, RectangleI> CharacterRects = new();

        // Inicializa el diccionario de rectángulos de caracteres (asume cuadrícula ASCII)
        /// <summary>
        /// Initializes the character rects using the specified char width
        /// </summary>
        /// <param name="charWidth">The char width</param>
        /// <param name="charHeight">The char height</param>
        private void InitializeCharacterRects(int charWidth, int charHeight)
        {
            int atlasCols = (int)(Size.X / charWidth);
            int atlasRows = (int)(Size.Y / charHeight);
            for (int i = 0; i < 256; i++) // ASCII básico
            {
                int col = i % atlasCols;
                int row = i / atlasCols;
                CharacterRects[(char)i] = new RectangleI
                {
                    X = col * charWidth,
                    Y = row * charHeight,
                    W = charWidth,
                    H = charHeight
                };
            }
        }

        // Inicializa el diccionario de rectángulos de caracteres usando organización personalizada
        /// <summary>
        /// Initializes the character rects custom using the specified char width
        /// </summary>
        /// <param name="charWidth">The char width</param>
        /// <param name="charHeight">The char height</param>
        /// <param name="charsPerRow">The chars per row</param>
        /// <param name="xSpacing">The spacing</param>
        /// <param name="ySpacing">The spacing</param>
        private void InitializeCharacterRectsCustom(int charWidth, int charHeight, int charsPerRow, int xSpacing, int ySpacing)
        {
            CharacterRects.Clear();
            string lowercase = "abcdefghijklmnopqrstuvwxyz";
            string uppercase = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string special = "0123456789";

            // Minúsculas
            for (int i = 0; i < lowercase.Length; i++)
            {
                char c = lowercase[i];
                int x = (i % charsPerRow) * (charWidth + xSpacing);
                int y = (i / charsPerRow) * (charHeight + ySpacing);
                CharacterRects[c] = new RectangleI { X = x, Y = y, W = charWidth, H = charHeight };
            }
            // Mayúsculas
            for (int i = 0; i < uppercase.Length; i++)
            {
                char c = uppercase[i];
                int x = (i % charsPerRow) * (charWidth + xSpacing);
                int y = ((i / charsPerRow) + 1) * (charHeight + ySpacing); // Siguiente fila
                CharacterRects[c] = new RectangleI { X = x, Y = y, W = charWidth, H = charHeight };
            }
            // Números
            for (int i = 0; i < special.Length; i++)
            {
                char c = special[i];
                int x = (i % charsPerRow) * (charWidth + xSpacing);
                int y = ((i / charsPerRow) + 2) * (charHeight + ySpacing); // Siguiente fila
                CharacterRects[c] = new RectangleI { X = x, Y = y, W = charWidth, H = charHeight };
            }
        }

        // Inicializa el diccionario de rectángulos de caracteres siguiendo la lógica exacta del ejemplo proporcionado
        /// <summary>
        /// Initializes the character rects from atlas using the specified char width
        /// </summary>
        /// <param name="charWidth">The char width</param>
        /// <param name="charHeight">The char height</param>
        /// <param name="charsPerRow">The chars per row</param>
        /// <param name="xSpacing">The spacing</param>
        /// <param name="ySpacing">The spacing</param>
        private void InitializeCharacterRectsFromAtlas(int charWidth, int charHeight, int charsPerRow, int xSpacing, int ySpacing)
        {
            CharacterRects.Clear();
            Dictionary<char, RectangleI> characterRects = new Dictionary<char, RectangleI>();
            string lowercase = "abcdefghijklmnopqrstuvwxyz";
            string uppercase = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string special = "0123456789.:;,(*!?)^#$%{&-+@";
            
            
            // Iterate over special characters
            for (int i = 0; i < special.Length; i++)
            {
                char c = special[i];
                int x = i % charsPerRow * (charWidth + xSpacing);
                int y = (i / charsPerRow + 0) * (charHeight + ySpacing); // Move to the next row
                characterRects[c] = new RectangleI
                    {X = x, Y = y, W = charWidth, H = charHeight};
            }
            
            // Iterate over uppercase characters
            for (int i = 0; i < uppercase.Length; i++)
            {
                char c = uppercase[i];
                int x = i % charsPerRow * (charWidth + xSpacing);
                int y = (i / charsPerRow + 1) * (charHeight + ySpacing); // Move to the next row
                characterRects[c] = new RectangleI
                    {X = x, Y = y, W = charWidth, H = charHeight};
            }

            
            // Iterate over lowercase characters
            for (int i = 0; i < lowercase.Length; i++)
            {
                char c = lowercase[i];
                int x = i % charsPerRow * (charWidth + xSpacing);
                int y = (i / charsPerRow + 2) * (charHeight + ySpacing); // Move to the next row
                characterRects[c] = new RectangleI
                    {X = x, Y = y, W = charWidth, H = charHeight};
            }

          
           
            
            CharacterRects = characterRects;
        }

        /// <summary>
        /// Renders the text using the specified text
        /// </summary>
        /// <param name="text">The text</param>
        /// <param name="xPos">The pos</param>
        /// <param name="yPos">The pos</param>
        /// <param name="colorFont">The color font</param>
        /// <param name="colorBackgroundFont">The color background font</param>
        public void RenderText(string text, int xPos, int yPos, Color colorFont, Color colorBackgroundFont)
        {
            if (!string.IsNullOrEmpty(NameFile) && (Path == string.Empty))
            {
                Path = AssetManager.Find(NameFile);
                InitializeShaders();
                LoadTexture(Path);
                SetupBuffers();
            }

            // Parámetros personalizados del atlas
            int charWidth = 10; // ancho de cada carácter en la textura BMP
            int charHeight = 16; // alto de cada carácter en la textura BMP
            int charsPerRow = 28; // caracteres por fila
            int xSpacing = 1; // espaciado horizontal
            int ySpacing = 0; // espaciado vertical
            if (CharacterRects.Count == 0) InitializeCharacterRectsFromAtlas(charWidth, charHeight, charsPerRow, xSpacing, ySpacing);

            // Tamaño lógico de la fuente en pantalla
            float fontSize = sizeFont; // valor lógico de la fuente (por ejemplo, 1)
            float pixelsPerUnit = 32.0f; // 1 unidad lógica equivale a 32 píxeles en pantalla
            float screenCharWidth = fontSize * pixelsPerUnit;
            float screenCharHeight = fontSize * pixelsPerUnit * ((float)charHeight / charWidth); // mantiene proporción

            Vector2F cameraPosition = new Vector2F(0, 0);
            Vector2F cameraResolution = new Vector2F(800, 600);

            Gl.GlUseProgram(ShaderProgram);
            Gl.GlBindVertexArray(Vao);
            Gl.GlBindBuffer(BufferTarget.ElementArrayBuffer, Ebo);
            Gl.GlBindBuffer(BufferTarget.ArrayBuffer, Vbo);

            int colorFontLocation = Gl.GlGetUniformLocation(ShaderProgram, "colorFont");
            int colorBackgroundLocation = Gl.GlGetUniformLocation(ShaderProgram, "colorBackgroundFont");
            int offsetLocation = Gl.GlGetUniformLocation(ShaderProgram, "offset");
            int scaleLocation = Gl.GlGetUniformLocation(ShaderProgram, "scale");
            int rotationLocation = Gl.GlGetUniformLocation(ShaderProgram, "rotation");
            int flipLocation = Gl.GlGetUniformLocation(ShaderProgram, "flip");

            Gl.GlEnable(EnableCap.Blend);
            Gl.GlBlendFunc(BlendingFactorSrc.SrcAlpha, BlendingFactorDest.OneMinusSrcAlpha);
            Gl.GlBindTexture(TextureTarget.Texture2D, Texture);

            float posX = xPos;
            foreach (char c in text)
            {
                if (!CharacterRects.TryGetValue(c, out RectangleI srcRect)) continue;

                // Coordenadas de textura (UV)
                /*float u0 = (float)srcRect.X / Size.X;
                float v0 = (float)srcRect.Y / Size.Y;
                float u1 = (float)(srcRect.X + srcRect.W) / Size.X;
                float v1 = (float)(srcRect.Y + srcRect.H) / Size.Y;*/

                int posXx = srcRect.X;
                int posYy = srcRect.Y;
                
                float u0 = posXx / Size.X;
                float v0 = posYy / Size.Y;
                float u1 = (posXx + srcRect.W) / Size.X;
                float v1 = (posYy + srcRect.H) / Size.Y;

                // Posición en pantalla (en píxeles)
                float positionXPixels = posX;
                float positionYPixels = yPos;

                // Normalizar a coordenadas OpenGL (-1 a 1)
                float worldX = 2.0f * (positionXPixels - cameraPosition.X) / cameraResolution.X;
                float worldY = 2.0f * (positionYPixels - cameraPosition.Y) / cameraResolution.Y;

                // Escala lógica para cada carácter
                Vector2F charScale = new Vector2F(screenCharWidth / cameraResolution.X, screenCharHeight / cameraResolution.Y);

                // Enviar colores y parámetros al shader
                Gl.GlUniform4F(colorFontLocation, colorFont.R / 255.0f, colorFont.G / 255.0f, colorFont.B / 255.0f, colorFont.A / 255.0f);
                Gl.GlUniform4F(colorBackgroundLocation, colorBackgroundFont.R / 255.0f, colorBackgroundFont.G / 255.0f, colorBackgroundFont.B / 255.0f, colorBackgroundFont.A / 255.0f);
                Gl.GlUniform2F(offsetLocation, worldX, worldY);
                Gl.GlUniform2F(scaleLocation, charScale.X, charScale.Y);
                Gl.GlUniform1F(rotationLocation, 0.0f);
                Gl.GlUniform1I(flipLocation, Flip ? 1 : 0);
                float[] vertices =
                {
                    1, -1, 0.0f, u1, v0,
                    1,  1, 0.0f, u1, v1,
                   -1,  1, 0.0f, u0, v1,
                   -1, -1, 0.0f, u0, v0
                };
                Gl.GlBindBuffer(BufferTarget.ArrayBuffer, Vbo);
                verticesHandle = GCHandle.Alloc(vertices, GCHandleType.Pinned);
                Gl.GlBufferData(BufferTarget.ArrayBuffer, new IntPtr(vertices.Length * sizeof(float)), verticesHandle.AddrOfPinnedObject(), BufferUsageHint.StaticDraw);
                verticesHandle.Free();
                Gl.GlDrawElements(PrimitiveType.Triangles, 6, DrawElementsType.UnsignedInt, IntPtr.Zero);

                posX += screenCharWidth + xSpacing; // avanzar según el tamaño lógico en pantalla
            }
            Gl.GlDisable(EnableCap.Blend);
        }
    }
}
