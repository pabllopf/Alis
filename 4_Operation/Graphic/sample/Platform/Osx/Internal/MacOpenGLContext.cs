#if OSX
using System;
using System.Runtime.InteropServices;
using Alis.Core.Graphic.Sample.Platform.OSX.Internal;

namespace Alis.Core.Graphic.Sample.Platform.OSX.Internal
{
    /// <summary>
    /// Gestiona el contexto OpenGL nativo en macOS
    /// </summary>
    internal class MacOpenGLContext
    {
        public IntPtr View { get; private set; }
        public IntPtr Context { get; private set; }
        public IntPtr PixelFormat { get; private set; }

        public MacOpenGLContext(MacWindow window)
        {
            CrearContexto(window);
        }

        private void CrearContexto(MacWindow window)
        {
            int[] attrs = {
                MacConstants.NsOpenGlpfaOpenGlProfile, MacConstants.NsOpenGlProfileVersion32Core,
                MacConstants.NsOpenGlpfaDoubleBuffer,
                MacConstants.NsOpenGlpfaColorSize, 24,
                MacConstants.NsOpenGlpfaDepthSize, 24,
                0
            };
            PixelFormat = ObjectiveCInterop.objc_msgSend(ObjectiveCInterop.Class("NSOpenGLPixelFormat"), ObjectiveCInterop.Sel("alloc"));
            GCHandle pin = GCHandle.Alloc(attrs, GCHandleType.Pinned);
            try
            {
                PixelFormat = ObjectiveCInterop.objc_msgSend_IntPtr(PixelFormat, ObjectiveCInterop.Sel("initWithAttributes:"), pin.AddrOfPinnedObject());
            }
            finally { pin.Free(); }
            View = ObjectiveCInterop.objc_msgSend(ObjectiveCInterop.Class("NSOpenGLView"), ObjectiveCInterop.Sel("alloc"));
            NsRect frame = window.GetFrame();
            View = ObjectiveCInterop.objc_msgSend_NSRect_IntPtr(View, ObjectiveCInterop.Sel("initWithFrame:pixelFormat:"),
                frame.x, frame.y, frame.width, frame.height, PixelFormat);
            ObjectiveCInterop.objc_msgSend_void_IntPtr(window.Handle, ObjectiveCInterop.Sel("setContentView:"), View);
            Context = ObjectiveCInterop.objc_msgSend(View, ObjectiveCInterop.Sel("openGLContext"));
        }

        public void MakeCurrent() => ObjectiveCInterop.objc_msgSend_void(Context, ObjectiveCInterop.Sel("makeCurrentContext"));
        public void SwapBuffers() => ObjectiveCInterop.objc_msgSend_void(Context, ObjectiveCInterop.Sel("flushBuffer"));
    }
}
#endif

