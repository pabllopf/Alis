using System.Drawing;
using AppKit;
using CoreGraphics;
using OpenTK.Graphics.OpenGL;

namespace OpenGLViewSample
{
    public class GLView : NSOpenGLView
    {
        public GLView (CGRect rect, NSOpenGLPixelFormat format) : base (rect, format) {
        }
		
        static void DrawTriangle ()
        {
            GL.Color3 (1.0f, 0.85f, 0.35f);
            GL.Begin (BeginMode.Triangles);
			
            GL.Vertex3 (0.0, 0.6, 0.0);
            GL.Vertex3 (-0.2, -0.3, 0.0);
            GL.Vertex3 (0.2, -0.3 ,0.0);
			
            GL.End ();
        }
		
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