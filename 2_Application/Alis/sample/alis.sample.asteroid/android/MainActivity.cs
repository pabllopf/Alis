using Android.App;
using Android.OS;
using Android.Content;
using Android.Opengl;
using Java.Nio;
using Android.Util;

namespace Alis.Sample.Asteroid.Android
{
    [Activity(Label = "Alis.Sample.Asteroid.Android", MainLauncher = true, Theme = "@android:style/Theme.NoTitleBar")]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
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
        private FloatBuffer? vertexBuffer;
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
            ByteBuffer bb = ByteBuffer.AllocateDirect(triangleCoords.Length * 4);
            bb.Order(ByteOrder.NativeOrder());
            vertexBuffer = bb.AsFloatBuffer();
            vertexBuffer.Put(triangleCoords);
            vertexBuffer.Position(0);

            int vertexShader = LoadShader(GLES20.GlVertexShader, vertexShaderCode);
            int fragmentShader = LoadShader(GLES20.GlFragmentShader, fragmentShaderCode);

            program = GLES20.GlCreateProgram();
            GLES20.GlAttachShader(program, vertexShader);
            GLES20.GlAttachShader(program, fragmentShader);
            GLES20.GlLinkProgram(program);

            positionHandle = GLES20.GlGetAttribLocation(program, "vPosition");
        }

        public void OnDrawFrame(Java.Lang.Object gl)
        {
            Log.Debug("AlisGL", "OnDrawFrame llamado");
            if (vertexBuffer == null) {
                Log.Error("AlisGL", "vertexBuffer es null");
                return;
            }
            GLES20.GlClearColor(1f, 0f, 0f, 1f);
            GLES20.GlClear(GLES20.GlColorBufferBit);
            GLES20.GlUseProgram(program);
            GLES20.GlEnableVertexAttribArray(positionHandle);
            vertexBuffer.Position(0);
            GLES20.GlVertexAttribPointer(positionHandle, COORDS_PER_VERTEX, GLES20.GlFloat, false, 0, vertexBuffer);
            GLES20.GlDrawArrays(GLES20.GlTriangles, 0, 3);
            GLES20.GlDisableVertexAttribArray(positionHandle);
        }

        public void OnSurfaceChanged(Java.Lang.Object gl, int width, int height)
        {
            Log.Debug("AlisGL", $"OnSurfaceChanged llamado: width={width}, height={height}");
            GLES20.GlViewport(0, 0, width, height);
        }

        private int LoadShader(int type, string shaderCode)
        {
            int shader = GLES20.GlCreateShader(type);
            GLES20.GlShaderSource(shader, shaderCode);
            GLES20.GlCompileShader(shader);
            return shader;
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