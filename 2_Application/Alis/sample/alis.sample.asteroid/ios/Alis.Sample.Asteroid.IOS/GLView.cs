using System;
using CoreGraphics;
using UIKit;
using CoreAnimation;
using OpenGLES;
using ObjCRuntime;
using System.Runtime.InteropServices;

namespace Alis.Sample.Asteroid.IOS
{
    [Register("GLView")]
    public class GLView : UIView
    {
        private EAGLContext? _context;
        private uint _framebuffer;
        private uint _colorRenderbuffer;
        private CADisplayLink? _displayLink;

        [DllImport("libGLESv2.dylib")]
        private static extern void glClearColor(float red, float green, float blue, float alpha);
        [DllImport("libGLESv2.dylib")]
        private static extern void glClear(uint mask);
        [DllImport("libGLESv2.dylib")]
        private static extern void glViewport(int x, int y, int width, int height);
        [DllImport("libGLESv2.dylib")]
        private static extern void glGenFramebuffers(int n, out uint framebuffers);
        [DllImport("libGLESv2.dylib")]
        private static extern void glBindFramebuffer(uint target, uint framebuffer);
        [DllImport("libGLESv2.dylib")]
        private static extern void glGenRenderbuffers(int n, out uint renderbuffers);
        [DllImport("libGLESv2.dylib")]
        private static extern void glBindRenderbuffer(uint target, uint renderbuffer);
        [DllImport("libGLESv2.dylib")]
        private static extern void glFramebufferRenderbuffer(uint target, uint attachment, uint renderbuffertarget, uint renderbuffer);
        [DllImport("libGLESv2.dylib")]
        private static extern void glDeleteFramebuffers(int n, ref uint framebuffers);
        [DllImport("libGLESv2.dylib")]
        private static extern void glDeleteRenderbuffers(int n, ref uint renderbuffers);

        private const uint GL_FRAMEBUFFER = 0x8D40;
        private const uint GL_RENDERBUFFER = 0x8D41;
        private const uint GL_COLOR_ATTACHMENT0 = 0x8CE0;
        private const uint GL_COLOR_BUFFER_BIT = 0x00004000;

        // Es fundamental el 'new' para que UIKit use CAEAGLLayer
        public static new Class LayerClass => new Class(typeof(CAEAGLLayer));

        public GLView(CGRect frame) : base(frame) { }
        public GLView(IntPtr handle) : base(handle) { }

        public override void LayoutSubviews()
        {
            base.LayoutSubviews();
            if (_context == null)
            {
                _context = new EAGLContext(EAGLRenderingAPI.OpenGLES2);
                EAGLContext.SetCurrentContext(_context);
                if (Layer is CAEAGLLayer eaglLayer)
                {
                    eaglLayer.ContentsScale = ContentScaleFactor;
                    eaglLayer.Opaque = true;
                    eaglLayer.DrawableProperties = NSDictionary.FromObjectsAndKeys(
                        new NSObject[] { NSNumber.FromBoolean(false), EAGLColorFormat.RGBA8 },
                        new NSObject[] { EAGLDrawableProperty.RetainedBacking, EAGLDrawableProperty.ColorFormat });
                }
                glGenFramebuffers(1, out _framebuffer);
                glBindFramebuffer(GL_FRAMEBUFFER, _framebuffer);
                glGenRenderbuffers(1, out _colorRenderbuffer);
                glBindRenderbuffer(GL_RENDERBUFFER, _colorRenderbuffer);
                var eaglContext = _context;
                if (eaglContext != null && Layer is CAEAGLLayer eglLayer)
                {
                    eaglContext.RenderBufferStorage(GL_RENDERBUFFER, eglLayer);
                }
                glFramebufferRenderbuffer(GL_FRAMEBUFFER, GL_COLOR_ATTACHMENT0, GL_RENDERBUFFER, _colorRenderbuffer);
                _displayLink = CADisplayLink.Create(RenderFrame);
                _displayLink.AddToRunLoop(NSRunLoop.Main, NSRunLoopMode.Default);
                RenderFrame();
            }
        }

        private void RenderFrame()
        {
            EAGLContext.SetCurrentContext(_context);
            glBindFramebuffer(GL_FRAMEBUFFER, _framebuffer);
            int w = (int)(Bounds.Width * ContentScaleFactor);
            int h = (int)(Bounds.Height * ContentScaleFactor);
            glViewport(0, 0, w, h);
            glClearColor(0, 0, 1, 1); // Fondo azul
            glClear(GL_COLOR_BUFFER_BIT);
            glBindRenderbuffer(GL_RENDERBUFFER, _colorRenderbuffer);
            _context?.PresentRenderBuffer(GL_RENDERBUFFER);
        }

        protected override void Dispose(bool disposing)
        {
            if (_framebuffer != 0)
            {
                glDeleteFramebuffers(1, ref _framebuffer);
                _framebuffer = 0;
            }
            if (_colorRenderbuffer != 0)
            {
                glDeleteRenderbuffers(1, ref _colorRenderbuffer);
                _colorRenderbuffer = 0;
            }
            _displayLink?.Invalidate();
            base.Dispose(disposing);
        }
    }
}
