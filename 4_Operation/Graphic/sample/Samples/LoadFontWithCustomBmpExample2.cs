

using Alis.Core.Aspect.Math.Definition;
using Alis.Core.Graphic.OpenGL;
using Alis.Core.Graphic.OpenGL.Enums;
using Alis.Core.Graphic.Ui;

namespace Alis.Core.Graphic.Sample.Samples
{
    /// <summary>
    ///     The load font with custom bmp example class
    /// </summary>
    /// <seealso cref="IExample" />
    public class LoadFontWithCustomBmpExample2 : IExample
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


            FontManager.RenderText("Hola", 0, 0, Color.Red, Color.Green);


            FontManager.RenderText("Mundo!", 250, 200, Color.Blue, Color.Yellow);


            FontManager.RenderText("JEJEJ", -300, -200, Color.Cyan, Color.Magenta);
        }

        /// <summary>
        ///     Cleanups this instance
        /// </summary>
        public void Cleanup()
        {
        }
    }
}