using System;
using System.Diagnostics;
using System.Net.Http;
using System.Numerics;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Alis.Core.Graphic.OpenGL;
using Alis.Core.Graphic.OpenGL.Enums;
using CoroutineScheduler;

namespace Alis.Sample.Web
{
    /// <summary>
    /// The mesh demo class
    /// </summary>
    public class MeshDemo
    {
        /// <summary>
        /// Gets the value of the scheduler
        /// </summary>
        private Scheduler Scheduler { get; }
	
        /// <summary>
        /// Downloads the file using the specified client
        /// </summary>
        /// <param name="client">The client</param>
        /// <param name="path">The path</param>
        /// <exception cref="Exception"></exception>
        /// <returns>A task containing the string</returns>
        private static async Task<string> DownloadFile(
            HttpClient client,
            string path)
        {
            var response = await client.GetAsync(new Uri(path, UriKind.Relative));
            if (!response.IsSuccessStatusCode)
                throw new Exception();
            return await response.Content.ReadAsStringAsync();
        }

        /// <summary>
        /// Loads the gl
        /// </summary>
        /// <param name="gl">The gl</param>
        /// <param name="baseAddress">The base address</param>
        /// <returns>A task containing the mesh demo</returns>
        public static async Task<MeshDemo> LoadAsync(Uri baseAddress)
        {
            var client = new HttpClient()
            {
                BaseAddress = baseAddress,
            };

            var vertResponseTask = DownloadFile(client, "Assets/Vert.glsl");
            var fragResponseTask = DownloadFile(client, "Assets/Frag.glsl");

            await Task.WhenAll(vertResponseTask, fragResponseTask);

            var vertSource = await vertResponseTask;
            var fragSource = await fragResponseTask;

            return new MeshDemo(vertSource, fragSource);
        }

        // shader ids
        /// <summary>
        /// Gets the value of the shader program
        /// </summary>
        private uint ShaderProgram { get; }
        /// <summary>
        /// Gets the value of the vertex shader
        /// </summary>
        private uint VertexShader { get; }
        /// <summary>
        /// Gets the value of the fragment shader
        /// </summary>
        private uint FragmentShader { get; }
        /// <summary>
        /// Gets the value of the view projection location
        /// </summary>
        private int ViewProjectionLocation { get; }
        // vao ids
        /// <summary>
        /// Gets or sets the value of the vao
        /// </summary>
        private uint VAO { get; set; }
        /// <summary>
        /// Gets or sets the value of the vbo
        /// </summary>
        private uint VBO { get; set; }
        /// <summary>
        /// Gets or sets the value of the vbi
        /// </summary>
        private uint VBI { get; set; }
        /// <summary>
        /// Gets the value of the vertex buffer
        /// </summary>
        private VertexShaderInput[] VertexBuffer { get; }
        /// <summary>
        /// Gets the value of the index buffer
        /// </summary>
        private ushort[] IndexBuffer { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="MeshDemo"/> class
        /// </summary>
        /// <param name="gl">The gl</param>
        /// <param name="vertexSource">The vertex source</param>
        /// <param name="fragmentSource">The fragment source</param>
        unsafe private MeshDemo(
            string vertexSource,
            string fragmentSource)
        {
            Console.WriteLine("[MeshDemo] INICIALIZACIÓN");
            Scheduler = new();
            _ = Scheduler.SpawnTask(LogicThread);

            // setup the vertex buffer to draw
            VertexBuffer = new VertexShaderInput[MeshData.TriangleVerts.Length];
            IndexBuffer = new ushort[MeshData.TriangleIndices.Length];

            // create the shader
            ShaderProgram = Gl.GlCreateProgram();
            Console.WriteLine($"[MeshDemo] ShaderProgram: {ShaderProgram}");

            VertexShader = Gl.GlCreateShader(ShaderType.VertexShader);
            Gl.ShaderSource(VertexShader, vertexSource);
            Gl.GlCompileShader(VertexShader);
            Gl.GlGetShader(VertexShader, ShaderParameter.CompileStatus, out int res);
            Gl.GlGetShader(VertexShader, ShaderParameter.InfoLogLength, out int logLen);
            if (logLen > 1)
            {
                var log = new string(' ', logLen);
                var output = new int[]                {
                    0
                };
                Gl.GlGetShaderInfoLog(VertexShader, logLen, output, new StringBuilder(log));
                Console.WriteLine($"[MeshDemo] VertexShader log: {log}");
            }
            Console.WriteLine($"[MeshDemo] VertexShader CompileStatus: {res}");
            Debug.Assert(res != 0);

            FragmentShader = Gl.GlCreateShader(ShaderType.FragmentShader);
            Gl.ShaderSource(FragmentShader, fragmentSource);
            Gl.GlCompileShader(FragmentShader);
            Gl.GlGetShader(FragmentShader, ShaderParameter.CompileStatus, out res);
            Gl.GlGetShader(FragmentShader, ShaderParameter.InfoLogLength, out logLen);
            if (logLen > 1)
            {
                var log = new string(' ', logLen);
                var output = new int[]                {
                    0
                };
                Gl.GlGetShaderInfoLog(FragmentShader, logLen, output, new StringBuilder(log));
                Console.WriteLine($"[MeshDemo] FragmentShader log: {log}");
            }
            Console.WriteLine($"[MeshDemo] FragmentShader CompileStatus: {res}");
            Debug.Assert(res != 0);

            Gl.GlAttachShader(ShaderProgram, VertexShader);
            Gl.GlAttachShader(ShaderProgram, FragmentShader);
            Gl.GlLinkProgram(ShaderProgram);
            Gl.GlGetProgram(ShaderProgram, ProgramParameter.LinkStatus, out res);
            Gl.GlGetProgram(ShaderProgram, ProgramParameter.InfoLogLength, out logLen);
            if (logLen > 1)
            {
                var log = new string(' ', logLen);
                var output = new int[]                {
                    0
                };
                Gl.GlGetProgramInfoLog(ShaderProgram, logLen,  output, new StringBuilder(log));
                Console.WriteLine($"[MeshDemo] Program link log: {log}");
            }
            Console.WriteLine($"[MeshDemo] Program LinkStatus: {res}");
            Debug.Assert(res != 0);

            ViewProjectionLocation = Gl.GlGetUniformLocation(ShaderProgram, "viewprojection");
            Console.WriteLine($"[MeshDemo] ViewProjectionLocation: {ViewProjectionLocation}");

            // use and configure the shader
            Gl.GlUseProgram(ShaderProgram);
            var vp = Matrix3x2.Identity;
            Span<float> matrix = stackalloc float[]
            {
                vp.M11, vp.M21, vp.M31,
                vp.M12, vp.M22, vp.M32
            };
            Gl.GlUniformMatrix2x3(ViewProjectionLocation, false, matrix);
            var err = Gl.GlGetError();
            Console.WriteLine($"[MeshDemo] After UniformMatrix2x3, GL Error: {err}");

            // create the VAO
            VAO = Gl.GenVertexArray();
            Gl.GlBindVertexArray(VAO);
            Console.WriteLine($"[MeshDemo] VAO: {VAO}");

            uint[] vbos =  new uint[2];
            Gl.GlGenBuffers(2, vbos);
            VBO = vbos[0];
            VBI = vbos[1];
            Console.WriteLine($"[MeshDemo] VBO: {VBO}, VBI: {VBI}");

            int vert_size = Marshal.SizeOf<Vector2>();
            int colr_size = Marshal.SizeOf<Vector3>();
            int stride = Marshal.SizeOf<VertexShaderInput>();
            Console.WriteLine($"[MeshDemo] stride: {stride}, vert_size: {vert_size}, colr_size: {colr_size}");

            Gl.GlBindBuffer(BufferTarget.ArrayBuffer, VBO);
            Gl.GlBufferData(
                BufferTarget.ArrayBuffer,
                (stride * VertexBuffer.Length), IntPtr.Zero,
                BufferUsageHint.StreamDraw);
            Console.WriteLine($"[MeshDemo] After initial GlBufferData ArrayBuffer, GL Error: {Gl.GlGetError()}");

            Gl.EnableVertexAttribArray(0); // vertex
            Gl.EnableVertexAttribArray(1); // color
            Console.WriteLine($"[MeshDemo] After EnableVertexAttribArray, GL Error: {Gl.GlGetError()}");

            Gl.VertexAttribPointer(0, vert_size / sizeof(float), VertexAttribPointerType.Float, false, stride, (IntPtr)0);
            Console.WriteLine($"[MeshDemo] After VertexAttribPointer 0, GL Error: {Gl.GlGetError()}");
            Gl.VertexAttribPointer(1, colr_size / sizeof(float), VertexAttribPointerType.Float, false, stride, (IntPtr)vert_size);
            Console.WriteLine($"[MeshDemo] After VertexAttribPointer 1, GL Error: {Gl.GlGetError()}");

            Gl.GlBindBuffer(BufferTarget.ElementArrayBuffer, VBI);
            Gl.GlBufferData(BufferTarget.ElementArrayBuffer, (IntPtr)(sizeof(ushort) * IndexBuffer.Length), new IntPtr(null), BufferUsageHint.StreamDraw);
            Console.WriteLine($"[MeshDemo] After initial GlBufferData ElementArrayBuffer, GL Error: {Gl.GlGetError()}");

            Gl.GlBindVertexArray(0);
            Console.WriteLine("[MeshDemo] INICIALIZACIÓN FIN");
        }

        /// <summary>
        /// Binds the vao
        /// </summary>
        public void BindVAO()
        {
            Gl.GlBindVertexArray(VAO);
            Gl.GlBindBuffer(BufferTarget.ArrayBuffer, VBO);
            Gl.GlBindBuffer(BufferTarget.ElementArrayBuffer, VBI);
        }

        /// <summary>
        /// Unbinds the vao
        /// </summary>
        public void UnbindVAO()
        {
            Gl.GlBindVertexArray(0);
            Gl.GlBindBuffer(BufferTarget.ArrayBuffer, 0);
            Gl.GlBindBuffer(BufferTarget.ElementArrayBuffer, 0);
        }

        /// <summary>
        /// Gets or sets the value of the logo translation
        /// </summary>
        private Vector2 LogoTranslation { get; set; }
        /// <summary>
        /// Gets or sets the value of the logo scale
        /// </summary>
        private Vector2 LogoScale { get; set; } = Vector2.One;
        /// <summary>
        /// Gets or sets the value of the logo rotation
        /// </summary>
        private float LogoRotation { get; set; }
        /// <summary>
        /// Renders this instance
        /// </summary>
        public unsafe void Render()
        {
            Console.WriteLine("[MeshDemo] Render START");
            Scheduler.Resume();

            // update the vertex buffer
            var modelMatrix =
                Matrix3x2.CreateScale(LogoScale) *
                Matrix3x2.CreateRotation(LogoRotation) *
                Matrix3x2.CreateTranslation(LogoTranslation);
            Console.WriteLine($"[MeshDemo] modelMatrix: {modelMatrix}");
            for (int i = 0; i < MeshData.TriangleVerts.Length; i++)
            {
                ref var dstVert = ref VertexBuffer[i];
                ref var srcVert = ref MeshData.TriangleVerts[i];
                dstVert.Vertex = Vector2.Transform(srcVert.Vertex, modelMatrix);
                dstVert.Color = srcVert.Color;
                if (i < 3) Console.WriteLine($"[MeshDemo] VertexBuffer[{i}]: {dstVert.Vertex} Color: {dstVert.Color}");
            }
            for (int i = 0; i < MeshData.TriangleIndices.Length; i++)
            {
                IndexBuffer[i] = MeshData.TriangleIndices[i];
                if (i < 6) Console.WriteLine($"[MeshDemo] IndexBuffer[{i}]: {IndexBuffer[i]}");
            }
            Console.WriteLine($"[MeshDemo] VertexBuffer.Length: {VertexBuffer.Length}, IndexBuffer.Length: {IndexBuffer.Length}");

            // dispatch GL commands
            Gl.GlClearColor(0.392f, 0.584f, 0.929f, 1.0f);
            Console.WriteLine($"[MeshDemo] After GlClearColor, GL Error: {Gl.GlGetError()}");
            Gl.GlClear(ClearBufferMask.ColorBufferBit);
            Console.WriteLine($"[MeshDemo] After GlClear, GL Error: {Gl.GlGetError()}");

            BindVAO();
            Console.WriteLine($"[MeshDemo] After BindVAO, GL Error: {Gl.GlGetError()}");
            var vertexHandle = GCHandle.Alloc(VertexBuffer, GCHandleType.Pinned);
            var indexHandle = GCHandle.Alloc(IndexBuffer, GCHandleType.Pinned);
            try
            {
                Console.WriteLine($"[MeshDemo] Uploading vertex buffer: size={Marshal.SizeOf<VertexShaderInput>() * VertexBuffer.Length}");
                Gl.GlBufferData(BufferTarget.ArrayBuffer, Marshal.SizeOf<VertexShaderInput>() * VertexBuffer.Length, vertexHandle.AddrOfPinnedObject(), BufferUsageHint.StreamDraw);
                Console.WriteLine($"[MeshDemo] After GlBufferData ArrayBuffer, GL Error: {Gl.GlGetError()}");
                Console.WriteLine($"[MeshDemo] Uploading index buffer: size={sizeof(ushort) * IndexBuffer.Length}");
                Gl.GlBufferData(BufferTarget.ElementArrayBuffer, sizeof(ushort) * IndexBuffer.Length, indexHandle.AddrOfPinnedObject(), BufferUsageHint.StreamDraw);
                Console.WriteLine($"[MeshDemo] After GlBufferData ElementArrayBuffer, GL Error: {Gl.GlGetError()}");
            }
            finally
            {
                vertexHandle.Free();
                indexHandle.Free();
            }
            Console.WriteLine($"[MeshDemo] Drawing elements: count={IndexBuffer.Length}");
            Gl.GlDrawElements(PrimitiveType.Triangles, (int)IndexBuffer.Length, DrawElementsType.UnsignedShort, (IntPtr)0);
            Console.WriteLine($"[MeshDemo] After GlDrawElements, GL Error: {Gl.GlGetError()}");
            UnbindVAO();
            Console.WriteLine("[MeshDemo] Render END");
        }

        /// <summary>
        /// Canvases the resized using the specified width
        /// </summary>
        /// <param name="width">The width</param>
        /// <param name="height">The height</param>
        internal void CanvasResized(int width, int height)
        {
            Gl.GlViewport(0, 0, width, height);

            // note: in a rea lgame, aspect ratio corrections should be applies
            // to your projection transform, not your model transform
            LogoScale = new Vector2(height / (float)width, 1.0f);
        }

        /// <summary>
        /// Moves the to using the specified position
        /// </summary>
        /// <param name="position">The position</param>
        /// <param name="speed">The speed</param>
        public async Task MoveTo(Vector2 position, float speed)
        {
            var delta = position - LogoTranslation;
            var deltaPerFrame = delta / delta.Length() * speed;

            int count = (int)(delta.Length() / deltaPerFrame.Length());
            for (int i = 0; i < count; i++)
            {
                LogoTranslation += deltaPerFrame;
                await Scheduler.Yield();
            }
            LogoTranslation = position;
        }

        /// <summary>
        /// Logics the thread
        /// </summary>
        private async Task LogicThread()
        {
            const float speed = 0.005f;
            while (true)
            {
                await MoveTo(new Vector2(-0.7f, +0.0f), speed);
                await MoveTo(new Vector2(+0.0f, +0.5f), speed);
                await MoveTo(new Vector2(+0.7f, +0.0f), speed);
                await MoveTo(new Vector2(+0.0f, -0.5f), speed);
            }
        }
    }
}
