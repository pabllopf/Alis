
using System;

#if WINDOWS
using OpenTK.Graphics.ES30;
#elif MONOANDROID
using OpenTK.Graphics.ES30;
#elif XAMARIN_IOS
using OpenTK.Graphics.ES30;
#else
using OpenTK.Graphics.OpenGL;
#endif

namespace alis
{
    /// <summary>
    /// The open gl manager class
    /// </summary>
    public class OpenGLManager
    {
        /// <summary>
        /// The red
        /// </summary>
        private static float red;
        /// <summary>
        /// The green
        /// </summary>
        private static float green;
        /// <summary>
        /// The blue
        /// </summary>
        private static float blue;
        
        /// <summary>
        /// Renders
        /// </summary>
        public static void Render()
        {
            GL.ClearColor (red, green, blue, 1.0f);
            GL.Clear ((ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit));

            red += 0.01f;
            if (red >= 1.0f)
                red -= 1.0f;
            green += 0.02f;
            if (green >= 1.0f)
                green -= 1.0f;
            blue += 0.03f;
            if (blue >= 1.0f)
                blue -= 1.0f;
        }
    }
}