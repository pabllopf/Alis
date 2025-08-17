using Alis.Core.Graphic.OpenGL;
using Alis.Core.Graphic.OpenGL.Enums;

namespace Alis.Core.Graphic.Sample.Samples
{
    /// <summary>
    /// The simple red example class
    /// </summary>
    /// <seealso cref="IExample"/>
    class SimpleRedExample : IExample
    {
        /// <summary>
        /// Initializes this instance
        /// </summary>
        public void Initialize() { }
        /// <summary>
        /// Draws this instance
        /// </summary>
        public void Draw() {
            Gl.GlClearColor(1.0f, 0.0f, 0.0f, 1.0f);
            Gl.GlClear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
        }
        /// <summary>
        /// Cleanups this instance
        /// </summary>
        public void Cleanup() { }
    }
}