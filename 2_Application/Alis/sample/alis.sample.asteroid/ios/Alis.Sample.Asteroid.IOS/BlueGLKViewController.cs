using GLKit;
using OpenGLES;
using System.Runtime.InteropServices;

namespace Alis.Sample.Asteroid.IOS
{
    // GLKViewController que pinta el fondo rojo y un triángulo blanco
    public class BlueGlkViewController : GLKViewController
    {
        private EAGLContext? _context;
        private int _program;
        private uint _vbo;
        private int _positionLoc;

        [DllImport("__Internal")] private static extern void glClearColor(float r, float g, float b, float a);
        [DllImport("__Internal")] private static extern void glClear(uint mask);
        [DllImport("__Internal")] private static extern int glCreateShader(uint type);
        [DllImport("__Internal")] private static extern void glShaderSource(int shader, int count, string[] source, int[] length);
        [DllImport("__Internal")] private static extern void glCompileShader(int shader);
        [DllImport("__Internal")] private static extern int glCreateProgram();
        [DllImport("__Internal")] private static extern void glAttachShader(int program, int shader);
        [DllImport("__Internal")] private static extern void glLinkProgram(int program);
        [DllImport("__Internal")] private static extern void glUseProgram(int program);
        [DllImport("__Internal")] private static extern int glGetAttribLocation(int program, string name);
        [DllImport("__Internal")] private static extern void glEnableVertexAttribArray(int index);
        [DllImport("__Internal")] private static extern void glVertexAttribPointer(int index, int size, uint type, bool normalized, int stride, System.IntPtr pointer);
        [DllImport("__Internal")] private static extern void glGenBuffers(int n, out uint buffers);
        [DllImport("__Internal")] private static extern void glBindBuffer(uint target, uint buffer);
        [DllImport("__Internal")] private static extern void glBufferData(uint target, System.IntPtr size, float[] data, uint usage);
        [DllImport("__Internal")] private static extern void glDrawArrays(uint mode, int first, int count);
        [DllImport("__Internal")] private static extern void glDeleteProgram(int program);
        [DllImport("__Internal")] private static extern void glDeleteBuffers(int n, ref uint buffers);

        private const uint GL_COLOR_BUFFER_BIT = 0x4000;
        private const uint GL_ARRAY_BUFFER = 0x8892;
        private const uint GL_STATIC_DRAW = 0x88E4;
        private const uint GL_FLOAT = 0x1406;
        private const uint GL_TRIANGLES = 0x0004;

        public BlueGlkViewController(CoreGraphics.CGRect frame)
        {
            _context = new EAGLContext(EAGLRenderingAPI.OpenGLES2);
            var glkView = new GLKView(frame)
            {
                Context = _context,
                DrawableColorFormat = GLKViewDrawableColorFormat.RGBA8888,
                DrawableDepthFormat = GLKViewDrawableDepthFormat.Format24,
                DrawableStencilFormat = GLKViewDrawableStencilFormat.Format8,
                DrawableMultisample = GLKViewDrawableMultisample.None
            };
            base.View = glkView;
            base.PreferredFramesPerSecond = 60;
            SetupGL();
        }

        private void SetupGL()
        {
            EAGLContext.SetCurrentContext(_context);
            // Vertex shader
            string vertexShaderSrc = "attribute vec2 a_position; void main() { gl_Position = vec4(a_position, 0.0, 1.0); }";
            // Fragment shader
            string fragmentShaderSrc = "precision mediump float; void main() { gl_FragColor = vec4(1.0, 1.0, 1.0, 1.0); }";
            int vertexShader = glCreateShader(0x8B31); // GL_VERTEX_SHADER
            int fragmentShader = glCreateShader(0x8B30); // GL_FRAGMENT_SHADER
            glShaderSource(vertexShader, 1, new[] { vertexShaderSrc }, new[] { vertexShaderSrc.Length });
            glCompileShader(vertexShader);
            glShaderSource(fragmentShader, 1, new[] { fragmentShaderSrc }, new[] { fragmentShaderSrc.Length });
            glCompileShader(fragmentShader);
            _program = glCreateProgram();
            glAttachShader(_program, vertexShader);
            glAttachShader(_program, fragmentShader);
            glLinkProgram(_program);
            glUseProgram(_program);
            _positionLoc = glGetAttribLocation(_program, "a_position");
            // Triángulo centrado
            float[] vertices = new float[]
            {
                0.0f,  0.5f, // Arriba
               -0.5f, -0.5f, // Izquierda
                0.5f, -0.5f  // Derecha
            };
            glGenBuffers(1, out _vbo);
            glBindBuffer(GL_ARRAY_BUFFER, _vbo);
            glBufferData(GL_ARRAY_BUFFER, (System.IntPtr)(vertices.Length * sizeof(float)), vertices, GL_STATIC_DRAW);
        }

        public override void DrawInRect(GLKView view, CoreGraphics.CGRect rect)
        {
            EAGLContext.SetCurrentContext(_context);
            // Fondo rojo
            glClearColor(1f, 0f, 0f, 1f);
            glClear(GL_COLOR_BUFFER_BIT);
            // Dibuja triángulo blanco
            glUseProgram(_program);
            glBindBuffer(GL_ARRAY_BUFFER, _vbo);
            glEnableVertexAttribArray(_positionLoc);
            glVertexAttribPointer(_positionLoc, 2, GL_FLOAT, false, 2 * sizeof(float), System.IntPtr.Zero);
            glDrawArrays(GL_TRIANGLES, 0, 3);
        }

        protected override void Dispose(bool disposing)
        {
            if (_vbo != 0)
            {
                glDeleteBuffers(1, ref _vbo);
                _vbo = 0;
            }
            if (_program != 0)
            {
                glDeleteProgram(_program);
                _program = 0;
            }
            _context?.Dispose();
            base.Dispose(disposing);
        }
    }
}
