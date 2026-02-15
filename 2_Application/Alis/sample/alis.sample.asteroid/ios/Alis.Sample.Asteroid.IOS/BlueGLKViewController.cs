using GLKit;
using OpenGLES;
using System.Runtime.InteropServices;

namespace Alis.Sample.Asteroid.IOS
{
    // GLKViewController que pinta el fondo azul
    public class BlueGlkViewController : GLKViewController
    {
        private EAGLContext? _context;

        [DllImport("__Internal")]
        private static extern void glClearColor(float r, float g, float b, float a);

        [DllImport("__Internal")]
        private static extern void glClear(uint mask);
        

        private const uint GL_COLOR_BUFFER_BIT = 0x4000;

        public BlueGlkViewController(CoreGraphics.CGRect frame)
        {
            _context = new EAGLContext(EAGLRenderingAPI.OpenGLES2);
            var glkView = new GLKView(frame)
            {
                Context = _context,
                DrawableColorFormat = GLKViewDrawableColorFormat.RGBA8888,
                DrawableDepthFormat = GLKViewDrawableDepthFormat.Format24,
                DrawableStencilFormat = GLKViewDrawableStencilFormat.Format8,
                DrawableMultisample = GLKViewDrawableMultisample.None
            };
            base.View = glkView;
            base.PreferredFramesPerSecond = 60;
        }

        public override void DrawInRect(GLKView view, CoreGraphics.CGRect rect)
        {
            // Asegura que el contexto esté activo
            EAGLContext.SetCurrentContext(_context);
            // Establece el color azul (RGBA: 0, 0, 1, 1)
            glClearColor(1f, 0f, 1f, 1f);
            // Limpia el buffer de color
            glClear(GL_COLOR_BUFFER_BIT);
        }

        protected override void Dispose(bool disposing)
        {
            _context?.Dispose();
            base.Dispose(disposing);
        }
    }
}
