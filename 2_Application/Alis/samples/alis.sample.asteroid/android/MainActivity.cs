using System;
using Android.Content;
using Android.Opengl;
using Android.Util;
using System.Runtime.InteropServices;
using Alis.Core.Graphic.OpenGL;
using Alis.Core.Graphic.OpenGL.Enums;
using Alis.Core.Graphic.Platforms.Android;
using Android.App;
using Android.OS;
using Android.Runtime;

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
        private uint program;
        private int positionHandle;
        private IntPtr _vertexPtr;
        private static readonly float[] TriangleCoords = {
            0f, 0.5f,
            -0.5f, -0.5f,
            0.5f, -0.5f
        };
        private const int CoordsPerVertex = 2;
        private static readonly string VertexShaderCode =
            "attribute vec2 vPosition; void main() { gl_Position = vec4(vPosition, 0.0, 1.0); }";
        private static readonly string FragmentShaderCode =
            "precision mediump float; void main() { gl_FragColor = vec4(1.0, 1.0, 1.0, 1.0); }";
        
        
        public void OnSurfaceCreated(Java.Lang.Object gl, Java.Lang.Object config)
        {
            // Inicializar Gl con el puntero de funciones de EGL
            Gl.Initialize(EGLDroid.GetProcAddress);
            Log.Debug("AlisGL", "OnSurfaceCreated llamado");
            int size = TriangleCoords.Length * sizeof(float);
            IntPtr vertexPtr = Marshal.AllocHGlobal(size);
            Marshal.Copy(TriangleCoords, 0, vertexPtr, TriangleCoords.Length);

            uint vertexShader = Gl.GlCreateShader(ShaderType.VertexShader);
            Gl.ShaderSource(vertexShader, VertexShaderCode);
            Gl.GlCompileShader(vertexShader);

            uint fragmentShader = Gl.GlCreateShader(ShaderType.FragmentShader);
            Gl.ShaderSource(fragmentShader, FragmentShaderCode);
            Gl.GlCompileShader(fragmentShader);

            program = Gl.GlCreateProgram();
            Gl.GlAttachShader(program, vertexShader);
            Gl.GlAttachShader(program, fragmentShader);
            Gl.GlLinkProgram(program);

            positionHandle = Gl.GlGetAttribLocation(program, "vPosition");

            _vertexPtr = vertexPtr;
        }

        public void OnDrawFrame(Java.Lang.Object gl)
        {
            Log.Debug("AlisGL", "OnDrawFrame llamado");
            if (_vertexPtr == IntPtr.Zero) {
                Log.Error("AlisGL", "vertexPtr es null");
                return;
            }
            Gl.GlClearColor(1f, 0f, 0f, 1f); // Fondo rojo
            Gl.GlClear(ClearBufferMask.ColorBufferBit); // Limpiar buffer de color
            Gl.GlUseProgram(program);
            Gl.EnableVertexAttribArray(positionHandle);
            Gl.VertexAttribPointer(
                positionHandle,
                CoordsPerVertex,
                VertexAttribPointerType.Float,
                false,
                0,
                _vertexPtr
            );
            Gl.GlDrawArrays(PrimitiveType.Triangles, 0, 3); // Triángulo blanco
            
        }

        public void OnSurfaceChanged(Java.Lang.Object gl, int width, int height)
        {
            Log.Debug("AlisGL", $"OnSurfaceChanged llamado: width={width}, height={height}");
            Gl.GlViewport(0, 0, width, height);
        }

        private uint LoadShader(ShaderType type, string shaderCode)
        {
            uint shader = Gl.GlCreateShader(type);
            Gl.ShaderSource(shader, shaderCode);
            Gl.GlCompileShader(shader);
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
            OnDrawFrame((Java.Lang.Object)null);
        }
        public void OnSurfaceChanged(Javax.Microedition.Khronos.Opengles.IGL10? gl, int width, int height)
        {
            OnSurfaceChanged((Java.Lang.Object)null, width, height);
        }
        public void OnSurfaceCreated(Javax.Microedition.Khronos.Opengles.IGL10? gl, Javax.Microedition.Khronos.Egl.EGLConfig? config)
        {
            OnSurfaceCreated((Java.Lang.Object)null, (Java.Lang.Object)null);
        }
    }
}