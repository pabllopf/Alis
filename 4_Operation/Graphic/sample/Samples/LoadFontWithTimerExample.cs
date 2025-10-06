using Alis.Core.Aspect.Math.Definition;
using Alis.Core.Aspect.Time;
using Alis.Core.Graphic.OpenGL;
using Alis.Core.Graphic.OpenGL.Enums;
using Alis.Core.Graphic.Ui;

namespace Alis.Core.Graphic.Sample.Samples
{
    public class LoadFontwithTimerExample : IExample
    {
        private Clock clock = new Clock();

        public void Initialize()
        {
            clock.Restart();
        }

        public void Draw()
        {
            Gl.GlClearColor(0f, 0f, 0f, 1f);
            Gl.GlClear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

            // Obtiene el tiempo transcurrido en segundos
            int elapsed = (int) clock.ElapsedMilliseconds;
            elapsed /= 1000;
            int hours = elapsed / 3600;
            int minutes = (elapsed % 3600) / 60;
            int seconds = elapsed % 60;

            string timeText = $"{hours:D2}:{minutes:D2}:{seconds:D2}";
            FontManager.RenderText(timeText, -90, 0, Color.White, Color.Transparent);
        }

        public void Cleanup()
        {
        }
    }
}