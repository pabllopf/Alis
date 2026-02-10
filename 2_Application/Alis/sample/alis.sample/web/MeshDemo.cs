using System;
using System.Diagnostics;
using System.Net.Http;
using System.Numerics;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using CoroutineScheduler;
using Silk.NET.OpenGLES;

namespace Alis.Sample.Web
{
    /// <summary>
    /// The mesh demo class
    /// </summary>
    public class MeshDemo
    {
        /// <summary>
        /// Gets the value of the gl
        /// </summary>
        private GL Gl { get; }
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
        public static async Task<MeshDemo> LoadAsync(GL gl, Uri baseAddress)
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

            return new MeshDemo(gl, vertSource, fragSource);
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
            GL gl,
            string vertexSource,
            string fragmentSource)
        {
            Gl = gl;
            Scheduler = new();
            _ = Scheduler.SpawnTask(LogicThread);

            // setup the vertex buffer to draw
            VertexBuffer = new VertexShaderInput[MeshData.TriangleVerts.Length];
            IndexBuffer = new ushort[MeshData.TriangleIndices.Length];

            // create the shader
            ShaderProgram = gl.CreateProgram();

            VertexShader = gl.CreateShader(ShaderType.VertexShader);
            gl.ShaderSource(VertexShader, vertexSource);
            gl.CompileShader(VertexShader);
            gl.GetShader(VertexShader, ShaderParameterName.CompileStatus, out int res);
            //gl.GetShaderInfoLog(VertexShader, out string log);
            Debug.Assert(res != 0);

            FragmentShader = gl.CreateShader(ShaderType.FragmentShader);
            gl.ShaderSource(FragmentShader, fragmentSource);
            gl.CompileShader(FragmentShader);
            gl.GetShader(FragmentShader, ShaderParameterName.CompileStatus, out res);
            //gl.GetShaderInfoLog(FragmentShader, out log);
            Debug.Assert(res != 0);

            gl.AttachShader(ShaderProgram, VertexShader);
            gl.AttachShader(ShaderProgram, FragmentShader);
            gl.LinkProgram(ShaderProgram);
		
            gl.GetProgram(ShaderProgram, ProgramPropertyARB.LinkStatus, out res);
            //gl.GetProgramInfoLog(ShaderProgram, out log);
            Debug.Assert(res != 0);

            ViewProjectionLocation = gl.GetUniformLocation(ShaderProgram, "viewprojection"u8);
            Debug.Assert(gl.GetError() == GLEnum.NoError, "GetUniformLocation()");

            // use and configure the shader
            gl.UseProgram(ShaderProgram);
            var vp = Matrix3x2.Identity;
            Span<float> matrix = stackalloc float[]
            {
                vp.M11, vp.M21, vp.M31,
                vp.M12, vp.M22, vp.M32
            };
            gl.UniformMatrix2x3(ViewProjectionLocation, false, matrix);
            var err = gl.GetError();

            // create the VAO
            VAO = gl.GenVertexArray();
            gl.BindVertexArray(VAO);

            Span<uint> vbos = stackalloc uint[2];
            gl.GenBuffers(vbos);
            VBO = vbos[0];
            VBI = vbos[1];

            int vert_size = Marshal.SizeOf<Vector2>();
            int colr_size = Marshal.SizeOf<Vector3>();
            int stride = Marshal.SizeOf<VertexShaderInput>();

            gl.BindBuffer(BufferTargetARB.ArrayBuffer, VBO);
            gl.BufferData(
                BufferTargetARB.ArrayBuffer,
                (nuint)(stride * VertexBuffer.Length),
                in nint.Zero,
                BufferUsageARB.StreamDraw);

            gl.EnableVertexAttribArray(0); // vertex
            gl.EnableVertexAttribArray(1); // color

            gl.VertexAttribPointer(0, vert_size / sizeof(float), VertexAttribPointerType.Float, false, (uint)stride, (void*)(0));
            gl.VertexAttribPointer(1, colr_size / sizeof(float), VertexAttribPointerType.Float, false, (uint)stride, (void*)(vert_size));

            gl.BindBuffer(BufferTargetARB.ElementArrayBuffer, VBI);
            gl.BufferData(BufferTargetARB.ElementArrayBuffer, (nuint)(sizeof(ushort) * IndexBuffer.Length), null, BufferUsageARB.StreamDraw);

            gl.BindVertexArray(0);
            Debug.Assert(gl.GetError() == GLEnum.NoError);
        }

        /// <summary>
        /// Binds the vao
        /// </summary>
        public void BindVAO()
        {
            Gl.BindVertexArray(VAO);
            Gl.BindBuffer(BufferTargetARB.ArrayBuffer, VBO);
            Gl.BindBuffer(BufferTargetARB.ElementArrayBuffer, VBI);
            Debug.Assert(Gl.GetError() == GLEnum.NoError);
        }

        /// <summary>
        /// Unbinds the vao
        /// </summary>
        public void UnbindVAO()
        {
            Gl.BindVertexArray(0);
            Gl.BindBuffer(BufferTargetARB.ArrayBuffer, 0);
            Gl.BindBuffer(BufferTargetARB.ElementArrayBuffer, 0);
            Debug.Assert(Gl.GetError() == GLEnum.NoError);
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
            // iterate our logic thread
            Scheduler.Resume();

            // update the vertex buffer
            var modelMatrix =
                Matrix3x2.CreateScale(LogoScale) *
                Matrix3x2.CreateRotation(LogoRotation) *
                Matrix3x2.CreateTranslation(LogoTranslation);
            for (int i = 0; i < MeshData.TriangleVerts.Length; i++)
            {
                ref var dstVert = ref VertexBuffer[i];
                ref var srcVert = ref MeshData.TriangleVerts[i];
                dstVert.Vertex = Vector2.Transform(srcVert.Vertex, modelMatrix);
                dstVert.Color = srcVert.Color;
            }
            for (int i = 0; i < MeshData.TriangleIndices.Length; i++)
                IndexBuffer[i] = MeshData.TriangleIndices[i];

            // dispatch GL commands
            Gl.ClearColor(0.392f, 0.584f, 0.929f, 1.0f);
            Gl.Clear(ClearBufferMask.ColorBufferBit);

            BindVAO();
            Gl.BufferData<VertexShaderInput>(BufferTargetARB.ArrayBuffer, VertexBuffer, BufferUsageARB.StreamDraw);
            Gl.BufferData<ushort>(BufferTargetARB.ElementArrayBuffer, IndexBuffer, BufferUsageARB.StreamDraw);
            Gl.DrawElements(PrimitiveType.Triangles, (uint)IndexBuffer.Length, DrawElementsType.UnsignedShort, (void*)0);
            UnbindVAO();
        }

        /// <summary>
        /// Canvases the resized using the specified width
        /// </summary>
        /// <param name="width">The width</param>
        /// <param name="height">The height</param>
        internal void CanvasResized(int width, int height)
        {
            Gl.Viewport(0, 0, (uint)width, (uint)height);

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
