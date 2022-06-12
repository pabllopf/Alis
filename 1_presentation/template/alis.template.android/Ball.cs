using System;
using OpenTK;
using OpenTK.Graphics.ES30;

namespace Alis.Template.Android
{
    /// <summary>
    /// The ball class
    /// </summary>
    public class Ball
    {
        /// <summary>
        /// The uniform projection
        /// </summary>
        const int UNIFORM_PROJECTION = 0;
        /// <summary>
        /// The uniform light
        /// </summary>
        const int UNIFORM_LIGHT = 1;
        /// <summary>
        /// The uniform view
        /// </summary>
        const int UNIFORM_VIEW = 2;
        /// <summary>
        /// The uniform normal matrix
        /// </summary>
        const int UNIFORM_NORMAL_MATRIX = 3;
        /// <summary>
        /// The uniform angle count
        /// </summary>
        const int UNIFORM_ANGLE_COUNT = 4;
        /// <summary>
        /// The uniform count
        /// </summary>
        const int UNIFORM_COUNT = 5;
        /// <summary>
        /// The uniform count
        /// </summary>
        int[] uniforms = new int[UNIFORM_COUNT];
        /// <summary>
        /// The attrib vertex
        /// </summary>
        const int ATTRIB_VERTEX = 0;
        /// <summary>
        /// The attrib normal
        /// </summary>
        const int ATTRIB_NORMAL = 1;
        /// <summary>
        /// The attrib count
        /// </summary>
        const int ATTRIB_COUNT = 2;

        /// <summary>
        /// The vbi
        /// </summary>
        int vbo, vbi;

        /// <summary>
        /// The angle
        /// </summary>
        public float xAngle = (float)-Math.PI / 2, yAngle = 0;
        /// <summary>
        /// The acc
        /// </summary>
        public float xAcc, yAcc;
        /// <summary>
        /// The sign
        /// </summary>
        public float xSign = 1, ySign = 1;
        /// <summary>
        /// The inc
        /// </summary>
        float xInc = .0033f, yInc = .01f;
        /// <summary>
        /// The height
        /// </summary>
        int Width, Height;
        /// <summary>
        /// The count
        /// </summary>
        int count = 0;

        /// <summary>
        /// Inits the model
        /// </summary>
        internal void InitModel()
        {
            GL.GenBuffers(1, out vbo);
            GL.BindBuffer(BufferTarget.ArrayBuffer, vbo);
            GL.BufferData(BufferTarget.ArrayBuffer, (IntPtr)(BallModel.vertices.Length * sizeof(float)), BallModel.vertices, BufferUsage.StaticDraw);
            GL.BindBuffer(BufferTarget.ArrayBuffer, 0);

            GL.GenBuffers(1, out vbi);
            GL.BindBuffer(BufferTarget.ElementArrayBuffer, vbi);
            GL.BufferData(BufferTarget.ElementArrayBuffer, (IntPtr)(BallModel.faceIndexes.Length * sizeof(ushort)), BallModel.faceIndexes, BufferUsage.StaticDraw);
            GL.BindBuffer(BufferTarget.ElementArrayBuffer, 0);
        }

        /// <summary>
        /// Starts this instance
        /// </summary>
        internal void Start()
        {
            GL.Enable(EnableCap.DepthTest);
            GL.Enable(EnableCap.CullFace);
            GL.CullFace(CullFaceMode.Back);
        }

        /// <summary>
        /// Draws the model
        /// </summary>
        internal void DrawModel()
        {
            // Update attribute values.
            GL.BindBuffer(BufferTarget.ArrayBuffer, vbo);
            GL.VertexAttribPointer(ATTRIB_VERTEX, 3, VertexAttribPointerType.Float, false, sizeof(float) * 8, IntPtr.Zero);
            GL.EnableVertexAttribArray(ATTRIB_VERTEX);

            GL.VertexAttribPointer(ATTRIB_NORMAL, 3, VertexAttribPointerType.Float, false, sizeof(float) * 8, new IntPtr(sizeof(float) * 3));
            GL.EnableVertexAttribArray(ATTRIB_NORMAL);

            GL.BindBuffer(BufferTarget.ElementArrayBuffer, vbi);
            GL.DrawElementsInstanced(PrimitiveType.Triangles, BallModel.faceIndexes.Length, DrawElementsType.UnsignedShort, IntPtr.Zero, 24);

            GL.BindBuffer(BufferTarget.ArrayBuffer, 0);
            GL.BindBuffer(BufferTarget.ElementArrayBuffer, 0);
        }

        /// <summary>
        /// The matrix
        /// </summary>
        internal Matrix4 view = new Matrix4();
        /// <summary>
        /// The matrix
        /// </summary>
        internal Matrix4 normalMatrix = new Matrix4();
        /// <summary>
        /// The matrix
        /// </summary>
        internal Matrix4 projection = new Matrix4();

        /// <summary>
        /// The program
        /// </summary>
        int program;

        /// <summary>
        /// Renders the frame
        /// </summary>
        internal void RenderFrame()
        {
            // Replace the implementation of this method to do your own custom drawing.
            GL.ClearColor(0.1f, 0.1f, 0.1f, 1.0f);
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
            CheckGLError();

            // Use shader program.
            GL.UseProgram(program);
            CheckGLError();

            // Update uniform value.
            GL.UniformMatrix4(uniforms[UNIFORM_PROJECTION], false, ref projection);
            GL.UniformMatrix4(uniforms[UNIFORM_VIEW], false, ref view);
            GL.UniformMatrix4(uniforms[UNIFORM_NORMAL_MATRIX], false, ref normalMatrix);
            GL.Uniform3(uniforms[UNIFORM_LIGHT], 25f, 25f, 28f);
            GL.Uniform1(uniforms[UNIFORM_ANGLE_COUNT], count++);
            count = count % (5 * 60);
            CheckGLError();

            DrawModel();
            CheckGLError();

            // Validate program before drawing. This is a good check, but only really necessary in a debug build.
        }

        /// <summary>
        /// Loads the resource using the specified name
        /// </summary>
        /// <param name="name">The name</param>
        /// <returns>The string</returns>
        string LoadResource(string name)
        {
            return new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(name)).ReadToEnd();
        }

        /// <summary>
        /// Loads the shaders
        /// </summary>
        internal void LoadShaders()
        {
            LoadShaders(LoadResource("Alis.Template.Android.Shaders.Shader.vsh"), LoadResource("Alis.Template.Android.Shaders.Shader.fsh"));
        }

        /// <summary>
        /// Describes whether this instance load shaders
        /// </summary>
        /// <param name="vertShaderSource">The vert shader source</param>
        /// <param name="fragShaderSource">The frag shader source</param>
        /// <returns>The bool</returns>
        internal bool LoadShaders(string vertShaderSource, string fragShaderSource)
        {
            Console.WriteLine("load shaders");
            int vertShader, fragShader;

            // Create shader program.
            program = GL.CreateProgram();

            // Create and compile vertex shader.
            if (!CompileShader(ShaderType.VertexShader, vertShaderSource, out vertShader))
            {
                Console.WriteLine("Failed to compile vertex shader");
                return false;
            }
            // Create and compile fragment shader.
            if (!CompileShader(ShaderType.FragmentShader, fragShaderSource, out fragShader))
            {
                Console.WriteLine("Failed to compile fragment shader");
                return false;
            }

            // Attach vertex shader to program.
            GL.AttachShader(program, vertShader);

            // Attach fragment shader to program.
            GL.AttachShader(program, fragShader);

            // Bind attribute locations.
            // This needs to be done prior to linking.
            GL.BindAttribLocation(program, ATTRIB_VERTEX, "position");
            GL.BindAttribLocation(program, ATTRIB_NORMAL, "normal");

            // Link program.
            if (!LinkProgram(program))
            {
                Console.WriteLine($"Failed to link program: {program:x}");

                if (vertShader != 0)
                    GL.DeleteShader(vertShader);

                if (fragShader != 0)
                    GL.DeleteShader(fragShader);

                if (program != 0)
                {
                    GL.DeleteProgram(program);
                    program = 0;
                }
                return false;
            }

            // Get uniform locations.
            uniforms[UNIFORM_PROJECTION] = GL.GetUniformLocation(program, "projection");
            uniforms[UNIFORM_VIEW] = GL.GetUniformLocation(program, "view");
            uniforms[UNIFORM_NORMAL_MATRIX] = GL.GetUniformLocation(program, "normalMatrix");
            uniforms[UNIFORM_LIGHT] = GL.GetUniformLocation(program, "light");
            uniforms[UNIFORM_ANGLE_COUNT] = GL.GetUniformLocation(program, "count");

            // Release vertex and fragment shaders.
            if (vertShader != 0)
            {
                GL.DetachShader(program, vertShader);
                GL.DeleteShader(vertShader);
            }

            if (fragShader != 0)
            {
                GL.DetachShader(program, fragShader);
                GL.DeleteShader(fragShader);
            }

            return true;
        }

        /// <summary>
        /// Destroys the shaders
        /// </summary>
        internal void DestroyShaders()
        {
            if (program != 0)
            {
                GL.DeleteProgram(program);
                program = 0;
            }
        }

        /// <summary>
        /// Describes whether compile shader
        /// </summary>
        /// <param name="type">The type</param>
        /// <param name="src">The src</param>
        /// <param name="shader">The shader</param>
        /// <returns>The bool</returns>
        static bool CompileShader(ShaderType type, string src, out int shader)
        {
            shader = GL.CreateShader(type);
            GL.ShaderSource(shader, src);
            GL.CompileShader(shader);


            int status = 0;
            GL.GetShader(shader, ShaderParameter.CompileStatus, out status);
            if (status == 0)
            {
                GL.DeleteShader(shader);
                return false;
            }

            return true;
        }

        /// <summary>
        /// Describes whether link program
        /// </summary>
        /// <param name="prog">The prog</param>
        /// <returns>The bool</returns>
        internal static bool LinkProgram(int prog)
        {
            GL.LinkProgram(prog);

            int status = 0;
            GL.GetProgram(prog, ProgramParameter.LinkStatus, out status);
            if (status == 0)
                return false;

            return true;
        }

        /// <summary>
        /// Checks the gl error
        /// </summary>
        static void CheckGLError()
        {
            ErrorCode code = GL.GetErrorCode();
            if (code != ErrorCode.NoError)
                Console.WriteLine($"GL Error {code}");
        }

        /// <summary>
        /// Describes whether validate program
        /// </summary>
        /// <param name="prog">The prog</param>
        /// <returns>The bool</returns>
        static bool ValidateProgram(int prog)
        {
            GL.ValidateProgram(prog);
            CheckGLError();

            int logLength = 0;
            GL.GetProgram(prog, ProgramParameter.InfoLogLength, out logLength);
            CheckGLError();
            if (logLength > 0)
            {
                var infoLog = new System.Text.StringBuilder(logLength);
                GL.GetProgramInfoLog(prog, logLength, out logLength, infoLog);
            }

            int status = 0;
            GL.GetProgram(prog, ProgramParameter.LinkStatus, out status);
            CheckGLError();
            if (status == 0)
                return false;

            return true;
        }

        /// <summary>
        /// Setup the projection using the specified width
        /// </summary>
        /// <param name="width">The width</param>
        /// <param name="height">The height</param>
        internal void SetupProjection(int width, int height)
        {
            Matrix4 model = Matrix4.Mult(Matrix4.CreateRotationX(-xAngle), Matrix4.CreateRotationZ(-yAngle));

            float aspect = (float)width / height;
            if (aspect > 1)
            {
                Matrix4 scale = Matrix4.Scale(aspect);
                model = Matrix4.Mult(model, scale);
            }
            view = Matrix4.Mult(model, Matrix4.LookAt(0, -70, 5, 0, 10, 0, 0, 1, 0));
            projection = Matrix4.CreatePerspectiveFieldOfView(OpenTK.MathHelper.DegreesToRadians(42.0f), aspect, 1.0f, 200.0f);
            projection = Matrix4.Mult(view, projection);
            normalMatrix = Matrix4.Invert(view);
            normalMatrix.Transpose();

            Width = width;
            Height = height;
        }

        /// <summary>
        /// Updates the world
        /// </summary>
        public void UpdateWorld()
        {
            xAngle += xSign * (xInc + xAcc * xAcc);
            yAngle += ySign * (yInc + yAcc * yAcc);
            SetupProjection(Width, Height);
            xAcc = System.Math.Max(0, xAcc - 0.001f);
            yAcc = System.Math.Max(0, yAcc - 0.001f);
        }
    }
}

