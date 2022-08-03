using Android.Opengl;
using Java.Lang;
using Javax.Microedition.Khronos.Opengles;
using EGLConfig = Javax.Microedition.Khronos.Egl.EGLConfig;

namespace Alis.Template.Game.Android
{
    /// <summary>
    ///     The my gl renderer class
    /// </summary>
    /// <seealso cref="Java.Lang.Object" />
    /// <seealso cref="GLSurfaceView.IRenderer" />
    internal class MyGLRenderer : Object, GLSurfaceView.IRenderer
    {
        /// <summary>
        ///     The tag
        /// </summary>
        private static string TAG = "MyGLRenderer";

        /// <summary>
        ///     The proj matrix
        /// </summary>
        private float[] mProjMatrix = new float[16];


        /// <summary>
        ///     Ons the draw frame using the specified gl
        /// </summary>
        /// <param name="gl">The gl</param>
        public void OnDrawFrame(IGL10 gl)
        {
            RenderManager.OnDrawFrame();
        }

        /// <summary>
        ///     Ons the surface changed using the specified gl
        /// </summary>
        /// <param name="gl">The gl</param>
        /// <param name="width">The width</param>
        /// <param name="height">The height</param>
        public void OnSurfaceChanged(IGL10 gl, int width, int height)
        {
            // Adjust the viewport based on geometry changes,
            // such as screen rotation
            GLES20.GlViewport(0, 0, width, height);

            float ratio = (float)width / height;

            // this projection matrix is applied to object coordinates
            // in the onDrawFrame() method
            Matrix.FrustumM(mProjMatrix, 0, -ratio, ratio, -1, 1, 3, 7);
        }

        /// <summary>
        ///     Ons the surface created using the specified gl
        /// </summary>
        /// <param name="gl">The gl</param>
        /// <param name="config">The config</param>
        public void OnSurfaceCreated(IGL10 gl, EGLConfig config)
        {
            //GLES30.GlClearColor (0.0f, 0.0f, 0.0f, 1.0f);
        }
    }
}