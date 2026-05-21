

using Alis.Core.Aspect.Math.Definition;
using Alis.Core.Aspect.Time;
using Alis.Core.Graphic.OpenGL;
using Alis.Core.Graphic.OpenGL.Enums;
using Alis.Core.Graphic.Ui;

namespace Alis.Extension.Media.FFmpeg.Sample.Samples
{
    /// <summary>
    ///     The load fontwith timer example class
    /// </summary>
    /// <seealso cref="IExample" />
    public class LoadFontwithTimerExample : IExample
    {
        /// <summary>
        ///     The clock
        /// </summary>
        private readonly Clock clock = new Clock();

        /// <summary>
        ///     Initializes this instance
        /// </summary>
        public void Initialize()
        {
            clock.Restart();
        }

        /// <summary>
        ///     Draws this instance
        /// </summary>
        public void Draw()
        {
            Gl.GlClearColor(0f, 0f, 0f, 1f);
            Gl.GlClear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

            int elapsed = (int) clock.ElapsedMilliseconds;
            elapsed /= 1000;
            int hours = elapsed / 3600;
            int minutes = elapsed % 3600 / 60;
            int seconds = elapsed % 60;

            string timeText = $"{hours:D2}:{minutes:D2}:{seconds:D2}";
            FontManager.RenderText(timeText, -90, 0, Color.White, Color.Transparent);
        }

        /// <summary>
        ///     Cleanups this instance
        /// </summary>
        public void Cleanup()
        {
        }
    }
}