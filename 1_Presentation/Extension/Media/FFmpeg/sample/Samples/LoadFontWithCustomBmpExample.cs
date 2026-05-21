

using Alis.Core.Graphic.OpenGL;
using Alis.Core.Graphic.OpenGL.Enums;
using Alis.Core.Graphic.Ui;

namespace Alis.Extension.Media.FFmpeg.Sample.Samples
{
    /// <summary>
    ///     The load font with custom bmp example class
    /// </summary>
    /// <seealso cref="IExample" />
    public class LoadFontWithCustomBmpExample : IExample
    {
        /// <summary>
        ///     Initializes this instance
        /// </summary>
        public void Initialize()
        {
        }

        /// <summary>
        ///     Draws this instance
        /// </summary>
        public void Draw()
        {
            Gl.GlClearColor(0f, 0f, 0f, 1f);
            Gl.GlClear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);


            FontManager.RenderText("Hola Mundo", 0, 0);
        }

        /// <summary>
        ///     Cleanups this instance
        /// </summary>
        public void Cleanup()
        {
        }
    }
}