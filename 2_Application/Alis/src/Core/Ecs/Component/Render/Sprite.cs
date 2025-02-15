using System;
using System.IO;
using System.Runtime.InteropServices;
using Alis.Builder.Core.Ecs.Component.Render;
using Alis.Core.Aspect.Data.Json;
using Alis.Core.Aspect.Data.Resource;
using Alis.Core.Aspect.Fluent;
using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Graphic.OpenGL;
using Alis.Core.Graphic.OpenGL.Enums;
using Alis.Core.Graphic.Stb;

namespace Alis.Core.Ecs.Component.Render
{
    /// <summary>
    /// The sprite class
    /// </summary>
    /// <seealso cref="AComponent"/>
    /// <seealso cref="IHasBuilder{SpriteBuilder}"/>
    public class Sprite : AComponent, IHasBuilder<SpriteBuilder>
    {
        /// <summary>
        /// The image handle
        /// </summary>
        private GCHandle imageHandle;
        /// <summary>
        /// The indices handle
        /// </summary>
        private GCHandle indicesHandle;
        /// <summary>
        /// The vertices handle
        /// </summary>
        private GCHandle verticesHandle;

        /// <summary>
        /// Initializes a new instance of the <see cref="Sprite"/> class
        /// </summary>
        public Sprite()
        {
            NameFile = "";
            Path = "";
            Depth = 0;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Sprite"/> class
        /// </summary>
        /// <param name="nameFile">The name file</param>
        public Sprite(string nameFile)
        {
            NameFile = nameFile;
            Path = "";
            Depth = 0;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Sprite"/> class
        /// </summary>
        /// <param name="nameFile">The name file</param>
        /// <param name="depth">The depth</param>
        private Sprite(string nameFile, int depth)
        {
            NameFile = nameFile;
            Path = AssetManager.Find(nameFile);
            Depth = depth;
        }

        /// <summary>
        /// Gets or sets the value of the depth
        /// </summary>
        [JsonPropertyName("_Depth_")] 
        public int Depth { get; set; }

        /// <summary>
        /// Gets or sets the value of the path
        /// </summary>
        [JsonIgnore] 
        public string Path { get; set; }

        /// <summary>
        /// Gets or sets the value of the name file
        /// </summary>
        [JsonPropertyName("_NameFile_")] 
        public string NameFile { get; set; }

        /// <summary>
        /// Gets or sets the value of the size
        /// </summary>
        [JsonPropertyName("_Size_")] 
        public Vector2F Size { get; set; }

        /// <summary>
        /// Gets or sets the value of the shader program
        /// </summary>
        public uint ShaderProgram { get; private set; }
        
        /// <summary>
        /// Gets or sets the value of the vao
        /// </summary>
        public uint Vao { get; private set; }
        
        /// <summary>
        /// Gets or sets the value of the vbo
        /// </summary>
        public uint Vbo { get; private set; }
        
        /// <summary>
        /// Gets or sets the value of the ebo
        /// </summary>
        public uint Ebo { get; private set; }
        
        /// <summary>
        /// Gets or sets the value of the texture
        /// </summary>
        public uint Texture { get; private set; }

        /// <summary>
        /// Builders this instance
        /// </summary>
        /// <returns>The sprite builder</returns>
        public SpriteBuilder Builder() => new SpriteBuilder();

        /// <summary>
        /// Ons the init
        /// </summary>
        public override void OnInit()
        {
            if (!string.IsNullOrEmpty(NameFile))
            {
                Path = AssetManager.Find(NameFile);
                InitializeShaders();
                LoadTexture(Path);
                SetupBuffers();
            }
        }

        /// <summary>
        /// Ons the awake
        /// </summary>
        public override void OnAwake()
        {
            Context.GraphicManager.Attach(this);
        }

        /// <summary>
        /// Ons the start
        /// </summary>
        public override void OnStart()
        {
        }

        /// <summary>
        /// Ons the update
        /// </summary>
        public override void OnUpdate()
        {
        }

        /// <summary>
        /// Ons the exit
        /// </summary>
        public override void OnExit()
        {
            Context.GraphicManager.UnAttach(this);
        }

        /// <summary>
        /// Initializes the shaders
        /// </summary>
        private void InitializeShaders()
        {
            string vertexShaderSource = @"
                #version 330 core
                layout (location = 0) in vec3 aPos;
                layout (location = 1) in vec2 aTexCoord;
                out vec2 TexCoord;
                uniform vec2 offset;
                uniform float rotation;
                void main()
                {
                    float radians = radians(rotation);
                    float cosTheta = cos(radians);
                    float sinTheta = sin(radians);
                    mat2 rotationMatrix = mat2(cosTheta, -sinTheta, sinTheta, cosTheta);
                    vec2 rotatedPos = rotationMatrix * aPos.xy;
                    gl_Position = vec4(rotatedPos + offset, aPos.z, 1.0);
                    TexCoord = vec2(aTexCoord.x, 1.0 - aTexCoord.y);
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
        /// Loads the texture using the specified image path
        /// </summary>
        /// <param name="imagePath">The image path</param>
        /// <exception cref="FileNotFoundException">Texture file not found </exception>
        private void LoadTexture(string imagePath)
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
                    if (image.Data[i] == r && image.Data[i + 1] == g && image.Data[i + 2] == b)
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
                Gl.GlTexParameteri(TextureTarget.Texture2D, TextureParameterName.TextureMinFilter, TextureParameter.Linear);
                Gl.GlTexParameteri(TextureTarget.Texture2D, TextureParameterName.TextureMagFilter, TextureParameter.Linear);

                imageHandle = GCHandle.Alloc(image.Data, GCHandleType.Pinned);
                Gl.GlTexImage2D(TextureTarget.Texture2D, 0, PixelInternalFormat.Rgba, image.Width, image.Height, 0, PixelFormat.Rgba, PixelType.UnsignedByte, imageHandle.AddrOfPinnedObject());
                imageHandle.Free();

                Gl.GenerateMipmap(TextureTarget.Texture2D);
            }
        }

        /// <summary>
        /// Setup the buffers
        /// </summary>
        private void SetupBuffers()
        {
            int windowWidth = 800;
            int windowHeight = 600;

            float scaleX = Size.X / windowWidth;
            float scaleY = Size.Y / windowHeight;

            float[] vertices =
            {
                1 * scaleX, 1 * scaleY, 0.0f, 1.0f, 0.0f,
                1 * scaleX, -1 * scaleY, 0.0f, 1.0f, 1.0f,
                -1 * scaleX, -1 * scaleY, 0.0f, 0.0f, 1.0f,
                -1 * scaleX, 1f * scaleY, 0.0f, 0.0f, 0.0f
            };

            uint[] indices = {0, 1, 3, 1, 2, 3};

            Vao = Gl.GenVertexArray();
            Vbo = Gl.GenBuffer();
            Ebo = Gl.GenBuffer();

            Gl.GlBindVertexArray(Vao);

            Gl.GlBindBuffer(BufferTarget.ArrayBuffer, Vbo);
            verticesHandle = GCHandle.Alloc(vertices, GCHandleType.Pinned);
            Gl.GlBufferData(BufferTarget.ArrayBuffer, (IntPtr)(vertices.Length * sizeof(float)), verticesHandle.AddrOfPinnedObject(), BufferUsageHint.StaticDraw);
            verticesHandle.Free();

            Gl.GlBindBuffer(BufferTarget.ElementArrayBuffer, Ebo);
            indicesHandle = GCHandle.Alloc(indices, GCHandleType.Pinned);
            Gl.GlBufferData(BufferTarget.ElementArrayBuffer, (IntPtr)(indices.Length * sizeof(uint)), indicesHandle.AddrOfPinnedObject(), BufferUsageHint.StaticDraw);
            indicesHandle.Free();

            Gl.VertexAttribPointer(0, 3, VertexAttribPointerType.Float, false, 5 * sizeof(float), IntPtr.Zero);
            Gl.EnableVertexAttribArray(0);

            Gl.VertexAttribPointer(1, 2, VertexAttribPointerType.Float, false, 5 * sizeof(float), (IntPtr) (3 * sizeof(float)));
            Gl.EnableVertexAttribArray(1);
        }

       /// <summary>
       /// Renders this instance
       /// </summary>
       public void Render()
       {
           Gl.GlUseProgram(ShaderProgram);
           int offsetLocation = Gl.GlGetUniformLocation(ShaderProgram, "offset");
           Gl.GlUniform2F(offsetLocation, GameObject.Transform.Position.X, GameObject.Transform.Position.Y);
           Gl.GlBindVertexArray(Vao);
           Gl.GlEnable(EnableCap.Blend);
           Gl.GlBlendFunc(BlendingFactorSrc.SrcAlpha, BlendingFactorDest.OneMinusSrcAlpha);
           
           // Bind the texture before drawing
           Gl.GlBindTexture(TextureTarget.Texture2D, Texture);
           
           Gl.GlDrawElements(PrimitiveType.Triangles, 6, DrawElementsType.UnsignedInt, IntPtr.Zero);
           Gl.GlDisable(EnableCap.Blend);
       }
        
        /// <summary>
        /// Clones this instance
        /// </summary>
        /// <returns>The object</returns>
        public override object Clone() => new Sprite(NameFile, Depth);

       /// <summary>
       /// Renders the camera position
       /// </summary>
       /// <param name="cameraPosition">The camera position</param>
       /// <param name="cameraResolution">The camera resolution</param>
       /// <param name="pixelsPerMeter">The pixels per meter</param>
       public void Render(Vector2F cameraPosition, Vector2F cameraResolution, float pixelsPerMeter)
       {
           float spriteRotation = GameObject.Transform.Rotation;
           
           Gl.GlUseProgram(ShaderProgram);

           float offsetX = (GameObject.Transform.Position.X - cameraPosition.X) * pixelsPerMeter / cameraResolution.X;
           float offsetY = (GameObject.Transform.Position.Y - cameraPosition.Y) * pixelsPerMeter / cameraResolution.Y;
       
           int offsetLocation = Gl.GlGetUniformLocation(ShaderProgram, "offset");
           Gl.GlUniform2F(offsetLocation, offsetX, offsetY);
       
           int rotationLocation = Gl.GlGetUniformLocation(ShaderProgram, "rotation");
           Gl.GlUniform1F(rotationLocation, spriteRotation);
       
           Gl.GlBindVertexArray(Vao);
           Gl.GlEnable(EnableCap.Blend);
           Gl.GlBlendFunc(BlendingFactorSrc.SrcAlpha, BlendingFactorDest.OneMinusSrcAlpha);
       
           // Bind the texture before drawing
           Gl.GlBindTexture(TextureTarget.Texture2D, Texture);
       
           Gl.GlDrawElements(PrimitiveType.Triangles, 6, DrawElementsType.UnsignedInt, IntPtr.Zero);
           Gl.GlDisable(EnableCap.Blend);
       }
    }
}