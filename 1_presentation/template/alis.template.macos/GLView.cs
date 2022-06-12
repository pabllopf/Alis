using System.Drawing;
using AppKit;
using CoreGraphics;
using OpenTK.Graphics.OpenGL;

namespace MMOpenTK
{
    /// <summary>
    /// The gl view class
    /// </summary>
    /// <seealso cref="NSOpenGLView"/>
    public class GLView : NSOpenGLView
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GLView"/> class
        /// </summary>
        /// <param name="rect">The rect</param>
        /// <param name="format">The format</param>
        public GLView (CGRect rect, NSOpenGLPixelFormat format) : base (rect, format) {
        }
		
        /// <summary>
        /// Draws the triangle
        /// </summary>
        static void DrawTriangle ()
        {
            GL.Color3 (1.0f, 0.85f, 0.35f);
            GL.Begin (BeginMode.Triangles);
			
            GL.Vertex3 (0.0, 0.6, 0.0);
            GL.Vertex3 (-0.2, -0.3, 0.0);
            GL.Vertex3 (0.2, -0.3 ,0.0);
			
            GL.End ();
        }
		
        /// <summary>
        /// Draws the rect using the specified dirty rect
        /// </summary>
        /// <param name="dirtyRect">The dirty rect</param>
        public override void DrawRect (CGRect dirtyRect)
        {
            OpenGLContext.MakeCurrentContext ();
			
            GL.ClearColor (Color.Brown);
	
            GL.ClearColor (0, 0, 0, 0);
            GL.Clear(ClearBufferMask.ColorBufferBit);
 
            DrawTriangle ();
			
            GL.Flush ();
        }
    }
}