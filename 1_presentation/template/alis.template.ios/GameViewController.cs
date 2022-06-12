using System;
using System.Diagnostics;

using Foundation;
using GLKit;
using OpenGLES;
using OpenTK;
using OpenTK.Graphics.ES20;

namespace Alis.Template.IOS
{
    /// <summary>
    /// The game view controller class
    /// </summary>
    /// <seealso cref="GLKViewController"/>
    /// <seealso cref="IGLKViewDelegate"/>
    [Register ("GameViewController")]
    public class GameViewController : GLKViewController, IGLKViewDelegate
    {
        /// <summary>
        /// The uniform enum
        /// </summary>
        enum Uniform
        {
            /// <summary>
            /// The modelviewprojection matrix uniform
            /// </summary>
            ModelViewProjection_Matrix,
            /// <summary>
            /// The normal matrix uniform
            /// </summary>
            Normal_Matrix,
            /// <summary>
            /// The count uniform
            /// </summary>
            Count
        }

        /// <summary>
        /// The attribute enum
        /// </summary>
        enum Attribute
        {
            /// <summary>
            /// The vertex attribute
            /// </summary>
            Vertex,
            /// <summary>
            /// The normal attribute
            /// </summary>
            Normal,
            /// <summary>
            /// The count attribute
            /// </summary>
            Count
        }

        /// <summary>
        /// The count
        /// </summary>
        int[] uniforms = new int [(int)Uniform.Count];

        /// <summary>
        /// The cube vertex data
        /// </summary>
        float[] cubeVertexData = {
            // Data layout for each line below is:
            // positionX, positionY, positionZ,     normalX, normalY, normalZ,
            0.5f, -0.5f, -0.5f,        1.0f, 0.0f, 0.0f,
            0.5f, 0.5f, -0.5f,         1.0f, 0.0f, 0.0f,
            0.5f, -0.5f, 0.5f,         1.0f, 0.0f, 0.0f,
            0.5f, -0.5f, 0.5f,         1.0f, 0.0f, 0.0f,
            0.5f, 0.5f, -0.5f,          1.0f, 0.0f, 0.0f,
            0.5f, 0.5f, 0.5f,         1.0f, 0.0f, 0.0f,

            0.5f, 0.5f, -0.5f,         0.0f, 1.0f, 0.0f,
            -0.5f, 0.5f, -0.5f,        0.0f, 1.0f, 0.0f,
            0.5f, 0.5f, 0.5f,          0.0f, 1.0f, 0.0f,
            0.5f, 0.5f, 0.5f,          0.0f, 1.0f, 0.0f,
            -0.5f, 0.5f, -0.5f,        0.0f, 1.0f, 0.0f,
            -0.5f, 0.5f, 0.5f,         0.0f, 1.0f, 0.0f,

            -0.5f, 0.5f, -0.5f,        -1.0f, 0.0f, 0.0f,
            -0.5f, -0.5f, -0.5f,       -1.0f, 0.0f, 0.0f,
            -0.5f, 0.5f, 0.5f,         -1.0f, 0.0f, 0.0f,
            -0.5f, 0.5f, 0.5f,         -1.0f, 0.0f, 0.0f,
            -0.5f, -0.5f, -0.5f,       -1.0f, 0.0f, 0.0f,
            -0.5f, -0.5f, 0.5f,        -1.0f, 0.0f, 0.0f,

            -0.5f, -0.5f, -0.5f,       0.0f, -1.0f, 0.0f,
            0.5f, -0.5f, -0.5f,        0.0f, -1.0f, 0.0f,
            -0.5f, -0.5f, 0.5f,        0.0f, -1.0f, 0.0f,
            -0.5f, -0.5f, 0.5f,        0.0f, -1.0f, 0.0f,
            0.5f, -0.5f, -0.5f,        0.0f, -1.0f, 0.0f,
            0.5f, -0.5f, 0.5f,         0.0f, -1.0f, 0.0f,

            0.5f, 0.5f, 0.5f,          0.0f, 0.0f, 1.0f,
            -0.5f, 0.5f, 0.5f,         0.0f, 0.0f, 1.0f,
            0.5f, -0.5f, 0.5f,         0.0f, 0.0f, 1.0f,
            0.5f, -0.5f, 0.5f,         0.0f, 0.0f, 1.0f,
            -0.5f, 0.5f, 0.5f,         0.0f, 0.0f, 1.0f,
            -0.5f, -0.5f, 0.5f,        0.0f, 0.0f, 1.0f,

            0.5f, -0.5f, -0.5f,        0.0f, 0.0f, -1.0f,
            -0.5f, -0.5f, -0.5f,       0.0f, 0.0f, -1.0f,
            0.5f, 0.5f, -0.5f,         0.0f, 0.0f, -1.0f,
            0.5f, 0.5f, -0.5f,         0.0f, 0.0f, -1.0f,
            -0.5f, -0.5f, -0.5f,       0.0f, 0.0f, -1.0f,
            -0.5f, 0.5f, -0.5f,        0.0f, 0.0f, -1.0f
        };

        /// <summary>
        /// The program
        /// </summary>
        int program;

        /// <summary>
        /// The model view projection matrix
        /// </summary>
        Matrix4 modelViewProjectionMatrix;
        /// <summary>
        /// The normal matrix
        /// </summary>
        Matrix3 normalMatrix;
        /// <summary>
        /// The rotation
        /// </summary>
        float rotation;

        /// <summary>
        /// The vertex array
        /// </summary>
        uint vertexArray;
        /// <summary>
        /// The vertex buffer
        /// </summary>
        uint vertexBuffer;

        /// <summary>
        /// Gets or sets the value of the context
        /// </summary>
        EAGLContext context { get; set; }

        /// <summary>
        /// Gets or sets the value of the effect
        /// </summary>
        GLKBaseEffect effect { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="GameViewController"/> class
        /// </summary>
        /// <param name="coder">The coder</param>
        [Export ("initWithCoder:")]
        public GameViewController (NSCoder coder) : base (coder)
        {
        }

        /// <summary>
        /// Views the did load
        /// </summary>
        public override void ViewDidLoad ()
        {
            base.ViewDidLoad ();

            context = new EAGLContext (EAGLRenderingAPI.OpenGLES2);

            if (context == null) {
                Debug.WriteLine ("Failed to create ES context");
            }

            var view = (GLKView)View;
            view.Context = context;
            view.DrawableDepthFormat = GLKViewDrawableDepthFormat.Format24;

            SetupGL ();
        }

        /// <summary>
        /// Disposes the disposing
        /// </summary>
        /// <param name="disposing">The disposing</param>
        protected override void Dispose (bool disposing)
        {
            base.Dispose (disposing);

            TearDownGL ();

            if (EAGLContext.CurrentContext == context)
                EAGLContext.SetCurrentContext (null);
        }

        /// <summary>
        /// Dids the receive memory warning
        /// </summary>
        public override void DidReceiveMemoryWarning ()
        {
            base.DidReceiveMemoryWarning ();

            if (IsViewLoaded && View.Window == null) {
                View = null;

                TearDownGL ();

                if (EAGLContext.CurrentContext == context) {
                    EAGLContext.SetCurrentContext (null);
                }
            }

            // Dispose of any resources that can be recreated.
        }

        /// <summary>
        /// Describes whether this instance prefers status bar hidden
        /// </summary>
        /// <returns>The bool</returns>
        public override bool PrefersStatusBarHidden ()
        {
            return true;
        }

        /// <summary>
        /// Setup the gl
        /// </summary>
        void SetupGL ()
        {
            EAGLContext.SetCurrentContext (context);

            LoadShaders ();

            effect = new GLKBaseEffect ();
            effect.Light0.Enabled = true;
            effect.Light0.DiffuseColor = new Vector4 (1.0f, 0.4f, 0.4f, 1.0f);

            GL.Enable (EnableCap.DepthTest);

            GL.Oes.GenVertexArrays (1, out vertexArray);
            GL.Oes.BindVertexArray (vertexArray);

            GL.GenBuffers (1, out vertexBuffer);
            GL.BindBuffer (BufferTarget.ArrayBuffer, vertexBuffer);
            GL.BufferData (BufferTarget.ArrayBuffer, (IntPtr)(cubeVertexData.Length * sizeof(float)), cubeVertexData, BufferUsage.StaticDraw);

            GL.EnableVertexAttribArray ((int)GLKVertexAttrib.Position);
            GL.VertexAttribPointer ((int)GLKVertexAttrib.Position, 3, VertexAttribPointerType.Float, false, 24, new IntPtr (0));
            GL.EnableVertexAttribArray ((int)GLKVertexAttrib.Normal);
            GL.VertexAttribPointer ((int)GLKVertexAttrib.Normal, 3, VertexAttribPointerType.Float, false, 24, new IntPtr (12));

            GL.Oes.BindVertexArray (0);
        }

        /// <summary>
        /// Tears the down gl
        /// </summary>
        void TearDownGL ()
        {
            EAGLContext.SetCurrentContext (context);
            GL.DeleteBuffers (1, ref vertexBuffer);
            GL.Oes.DeleteVertexArrays (1, ref vertexArray);

            effect = null;

            if (program > 0) {
                GL.DeleteProgram (program);
                program = 0;
            }
        }

        #region GLKView and GLKViewController delegate methods

        /// <summary>
        /// Updates this instance
        /// </summary>
        public override void Update ()
        {
            var aspect = (float)Math.Abs (View.Bounds.Size.Width / View.Bounds.Size.Height);
            var projectionMatrix = Matrix4.CreatePerspectiveFieldOfView (MathHelper.DegreesToRadians (65.0f), aspect, 0.1f, 100.0f);

            effect.Transform.ProjectionMatrix = projectionMatrix;

            var baseModelViewMatrix = Matrix4.CreateTranslation (0.0f, 0.0f, -4.0f);
            baseModelViewMatrix = Matrix4.CreateFromAxisAngle (new Vector3 (0.0f, 1.0f, 0.0f), rotation) * baseModelViewMatrix;

            // Compute the model view matrix for the object rendered with GLKit
            var modelViewMatrix = Matrix4.CreateTranslation (0.0f, 0.0f, -1.5f);
            modelViewMatrix = Matrix4.CreateFromAxisAngle (new Vector3 (1.0f, 1.0f, 1.0f), rotation) * modelViewMatrix;
            modelViewMatrix = modelViewMatrix * baseModelViewMatrix;

            effect.Transform.ModelViewMatrix = modelViewMatrix;

            // Compute the model view matrix for the object rendered with ES2
            modelViewMatrix = Matrix4.CreateTranslation (0.0f, 0.0f, 1.5f);
            modelViewMatrix = Matrix4.CreateFromAxisAngle (new Vector3 (1.0f, 1.0f, 1.0f), rotation) * modelViewMatrix;
            modelViewMatrix = modelViewMatrix * baseModelViewMatrix;

            normalMatrix = new Matrix3 (Matrix4.Transpose (Matrix4.Invert (modelViewMatrix)));

            modelViewProjectionMatrix = modelViewMatrix * projectionMatrix;

            rotation += (float)TimeSinceLastUpdate * 0.5f;
        }

        /// <summary>
        /// Draws the in rect using the specified view
        /// </summary>
        /// <param name="view">The view</param>
        /// <param name="rect">The rect</param>
        void IGLKViewDelegate.DrawInRect (GLKView view, CoreGraphics.CGRect rect)
        {
            GL.ClearColor (0.65f, 0.65f, 0.65f, 1.0f);
            GL.Clear (ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

            GL.Oes.BindVertexArray (vertexArray);

            // Render the object with GLKit
            effect.PrepareToDraw ();

            GL.DrawArrays (BeginMode.Triangles, 0, 36);

            // Render the object again with ES2
            GL.UseProgram (program);

            GL.UniformMatrix4 (uniforms [(int)Uniform.ModelViewProjection_Matrix], false, ref modelViewProjectionMatrix);
            GL.UniformMatrix3 (uniforms [(int)Uniform.Normal_Matrix], false, ref normalMatrix);

            GL.DrawArrays (BeginMode.Triangles, 0, 36);
        }

        /// <summary>
        /// Describes whether this instance load shaders
        /// </summary>
        /// <returns>The bool</returns>
        bool LoadShaders ()
        {
            int vertShader, fragShader;

            // Create shader program.
            program = GL.CreateProgram ();

            // Create and compile vertex shader.
            if (!CompileShader (ShaderType.VertexShader, LoadResource ("Shader", "vsh"), out vertShader)) {
                Console.WriteLine ("Failed to compile vertex shader");
                return false;
            }
            // Create and compile fragment shader.
            if (!CompileShader (ShaderType.FragmentShader, LoadResource ("Shader", "fsh"), out fragShader)) {
                Console.WriteLine ("Failed to compile fragment shader");
                return false;
            }

            // Attach vertex shader to program.
            GL.AttachShader (program, vertShader);

            // Attach fragment shader to program.
            GL.AttachShader (program, fragShader);

            // Bind attribute locations.
            // This needs to be done prior to linking.
            GL.BindAttribLocation (program, (int)GLKVertexAttrib.Position, "position");
            GL.BindAttribLocation (program, (int)GLKVertexAttrib.Normal, "normal");

            // Link program.
            if (!LinkProgram (program)) {
                Console.WriteLine ("Failed to link program: {0:x}", program);

                if (vertShader != 0)
                    GL.DeleteShader (vertShader);

                if (fragShader != 0)
                    GL.DeleteShader (fragShader);

                if (program != 0) {
                    GL.DeleteProgram (program);
                    program = 0;
                }
                return false;
            }

            // Get uniform locations.
            uniforms [(int)Uniform.ModelViewProjection_Matrix] = GL.GetUniformLocation (program, "modelViewProjectionMatrix");
            uniforms [(int)Uniform.Normal_Matrix] = GL.GetUniformLocation (program, "normalMatrix");

            // Release vertex and fragment shaders.
            if (vertShader != 0) {
                GL.DetachShader (program, vertShader);
                GL.DeleteShader (vertShader);
            }

            if (fragShader != 0) {
                GL.DetachShader (program, fragShader);
                GL.DeleteShader (fragShader);
            }

            return true;
        }

        /// <summary>
        /// Loads the resource using the specified name
        /// </summary>
        /// <param name="name">The name</param>
        /// <param name="type">The type</param>
        /// <returns>The string</returns>
        string LoadResource (string name, string type)
        {
            var path = NSBundle.MainBundle.PathForResource (name, type);
            return System.IO.File.ReadAllText (path);
        }

        #endregion

        /// <summary>
        /// Describes whether this instance compile shader
        /// </summary>
        /// <param name="type">The type</param>
        /// <param name="src">The src</param>
        /// <param name="shader">The shader</param>
        /// <returns>The bool</returns>
        bool CompileShader (ShaderType type, string src, out int shader)
        {
            shader = GL.CreateShader (type);
            GL.ShaderSource (shader, src);
            GL.CompileShader (shader);

            #if DEBUG
            int logLength = 0;
            GL.GetShader (shader, ShaderParameter.InfoLogLength, out logLength);
            if (logLength > 0) {
                Console.WriteLine ("Shader compile log:\n{0}", GL.GetShaderInfoLog (shader));
            }
            #endif

            int status = 0;
            GL.GetShader (shader, ShaderParameter.CompileStatus, out status);
            if (status == 0) {
                GL.DeleteShader (shader);
                return false;
            }

            return true;
        }

        /// <summary>
        /// Describes whether this instance link program
        /// </summary>
        /// <param name="prog">The prog</param>
        /// <returns>The bool</returns>
        bool LinkProgram (int prog)
        {
            GL.LinkProgram (prog);

            #if DEBUG
            int logLength = 0;
            GL.GetProgram (prog, ProgramParameter.InfoLogLength, out logLength);
            if (logLength > 0)
                Console.WriteLine ("Program link log:\n{0}", GL.GetProgramInfoLog (prog));
            #endif
            int status = 0;
            GL.GetProgram (prog, ProgramParameter.LinkStatus, out status);
            return status != 0;
        }

        /// <summary>
        /// Describes whether this instance validate program
        /// </summary>
        /// <param name="prog">The prog</param>
        /// <returns>The bool</returns>
        bool ValidateProgram (int prog)
        {
            int logLength, status = 0;

            GL.ValidateProgram (prog);
            GL.GetProgram (prog, ProgramParameter.InfoLogLength, out logLength);
            if (logLength > 0) {
                var log = new System.Text.StringBuilder (logLength);
                GL.GetProgramInfoLog (prog, logLength, out logLength, log);
                Console.WriteLine ("Program validate log:\n{0}", log);
            }

            GL.GetProgram (prog, ProgramParameter.LinkStatus, out status);
            return status != 0;
        }
    }
}

