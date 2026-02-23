using Android.Content;
using Android.Opengl;

namespace Alis.Sample.Asteroid.Android
{
    /// <summary>
    /// The gl view class
    /// </summary>
    /// <seealso cref="GLSurfaceView"/>
    public class GlView : GLSurfaceView
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GlView"/> class
        /// </summary>
        /// <param name="context">The context</param>
        public GlView(Context context) : base(context)
        {
            SetEGLContextClientVersion(2);
            SetRenderer(new TriangleRenderer());
        }
    }
}