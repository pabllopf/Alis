using Android.Content;
using Android.Opengl;

namespace Alis.Template.Game.Android
{
    /// <summary>
    ///     The my gl surface view class
    /// </summary>
    /// <seealso cref="GLSurfaceView" />
    internal class MyGLSurfaceView : GLSurfaceView
    {
        /// <summary>
        ///     The touch scale factor
        /// </summary>
        private const float TOUCH_SCALE_FACTOR = 180.0f / 320;

        /// <summary>
        ///     The renderer
        /// </summary>
        private MyGLRenderer mRenderer;

        /// <summary>
        ///     Initializes a new instance of the <see cref="MyGLSurfaceView" /> class
        /// </summary>
        /// <param name="context">The context</param>
        public MyGLSurfaceView(Context context) : base(context)
        {
            // Create an OpenGL ES 3.0 context.
            SetEGLContextClientVersion(3);

            // Set the Renderer for drawing on the GLSurfaceView
            mRenderer = new MyGLRenderer();
            SetRenderer(mRenderer);

            // Render the view only when there is a change in the drawing data
            RenderMode = Rendermode.Continuously;
        }
    }
}