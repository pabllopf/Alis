using Android.App;
using Android.Content;
using Android.Opengl;
using Android.Util;
using System.Runtime.InteropServices;
using Android.Runtime;
using Android.OS;

namespace Alis.Sample.Asteroid.Android
{
    [Activity(Label = "Alis.Sample.Asteroid.Android", MainLauncher = true, Theme = "@android:style/Theme.NoTitleBar")]
    [Register("crc647600d30597f44ece.MainActivity")]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle? savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            var glView = new GlView(this);
            SetContentView(glView);
        }
    }

    public class GlView : GLSurfaceView
    {
        public GlView(Context context) : base(context)
        {
            SetEGLContextClientVersion(2);
            SetRenderer(new TriangleRenderer());
        }
    }

    public class TriangleRenderer : Java.Lang.Object, GLSurfaceView.IRenderer
    {
        private int program;
        private int positionHandle;
        private static readonly float[] triangleCoords = {
            0f, 0.5f,
            -0.5f, -0.5f,
            0.5f, -0.5f
        };
        private const int COORDS_PER_VERTEX = 2;
        private static readonly string vertexShaderCode =
            "attribute vec2 vPosition; void main() { gl_Position = vec4(vPosition, 0.0, 1.0); }";
        private static readonly string fragmentShaderCode =
            "precision mediump float; void main() { gl_FragColor = vec4(1.0, 1.0, 1.0, 1.0); }";

        public void OnSurfaceCreated(Java.Lang.Object gl, Java.Lang.Object config)
        {
            Log.Debug("AlisGL", "OnSurfaceCreated llamado");
            // Fijar el array de vértices en memoria no administrada
            int size = triangleCoords.Length * sizeof(float);
            IntPtr vertexPtr = Marshal.AllocHGlobal(size);
            Marshal.Copy(triangleCoords, 0, vertexPtr, triangleCoords.Length);

            int vertexShader = LoadShader(GL.GL_VERTEX_SHADER, vertexShaderCode);
            int fragmentShader = LoadShader(GL.GL_FRAGMENT_SHADER, fragmentShaderCode);

            program = GL.glCreateProgram();
            GL.glAttachShader(program, vertexShader);
            GL.glAttachShader(program, fragmentShader);
            GL.glLinkProgram(program);

            positionHandle = GL.glGetAttribLocation(program, "vPosition");

            // Guardar el puntero para usarlo en OnDrawFrame
            _vertexPtr = vertexPtr;
        }

        private IntPtr _vertexPtr;

        public void OnDrawFrame(Java.Lang.Object gl)
        {
            Log.Debug("AlisGL", "OnDrawFrame llamado");
            if (_vertexPtr == IntPtr.Zero) {
                Log.Error("AlisGL", "vertexPtr es null");
                return;
            }
            GL.glClearColor(1f, 0f, 0f, 1f);
            GL.glClear(GL.GL_COLOR_BUFFER_BIT);
            GL.glUseProgram(program);
            GL.glEnableVertexAttribArray(positionHandle);
            GL.glVertexAttribPointer(positionHandle, COORDS_PER_VERTEX, GL.GL_FLOAT, false, 0, _vertexPtr);
            GL.glDrawArrays(GL.GL_TRIANGLES, 0, 3);
            GL.glDisableVertexAttribArray(positionHandle);
        }

        public void OnSurfaceChanged(Java.Lang.Object gl, int width, int height)
        {
            Log.Debug("AlisGL", $"OnSurfaceChanged llamado: width={width}, height={height}");
            GL.glViewport(0, 0, width, height);
        }

        private int LoadShader(int type, string shaderCode)
        {
            int shader = GL.glCreateShader(type);
            // Preparar el string como UTF8 y pasar el puntero
            IntPtr strPtr = Marshal.StringToHGlobalAnsi(shaderCode);
            IntPtr[] strArray = new IntPtr[] { strPtr };
            int[] length = new int[] { shaderCode.Length };
            GCHandle handle = GCHandle.Alloc(strArray, GCHandleType.Pinned);
            try {
                GL.glShaderSource(shader, 1, handle.AddrOfPinnedObject(), length);
            } finally {
                handle.Free();
                Marshal.FreeHGlobal(strPtr);
            }
            GL.glCompileShader(shader);
            return shader;
        }

        protected override void Dispose(bool disposing)
        {
            if (_vertexPtr != IntPtr.Zero)
            {
                Marshal.FreeHGlobal(_vertexPtr);
                _vertexPtr = IntPtr.Zero;
            }
            base.Dispose(disposing);
        }

        // Métodos para compatibilidad con IGL10/EGLConfig
        public void OnDrawFrame(Javax.Microedition.Khronos.Opengles.IGL10? gl)
        {
            OnDrawFrame((Java.Lang.Object)null!);
        }
        public void OnSurfaceChanged(Javax.Microedition.Khronos.Opengles.IGL10? gl, int width, int height)
        {
            OnSurfaceChanged((Java.Lang.Object)null!, width, height);
        }
        public void OnSurfaceCreated(Javax.Microedition.Khronos.Opengles.IGL10? gl, Javax.Microedition.Khronos.Egl.EGLConfig? config)
        {
            OnSurfaceCreated((Java.Lang.Object)null!, (Java.Lang.Object)null!);
        }
    }
}