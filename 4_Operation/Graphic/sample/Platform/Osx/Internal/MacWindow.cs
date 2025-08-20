#if OSX
using System;
using System.Runtime.InteropServices;
using Alis.Core.Graphic.Sample.Platform.OSX.Internal;

namespace Alis.Core.Graphic.Sample.Platform.OSX.Internal
{
    /// <summary>
    /// Representa una ventana nativa de macOS
    /// </summary>
    internal class MacWindow
    {
        public IntPtr Handle { get; private set; }
        public int Width { get; private set; }
        public int Height { get; private set; }
        public string Title { get; private set; }

        public MacWindow(int width, int height, string title)
        {
            Width = width;
            Height = height;
            Title = title;
            CrearVentana();
        }

        private void CrearVentana()
        {
            Handle = ObjectiveCInterop.objc_msgSend(ObjectiveCInterop.Class("NSWindow"), ObjectiveCInterop.Sel("alloc"));
            Handle = ObjectiveCInterop.objc_msgSend_NSRect_UL_UL_Bool(
                Handle, ObjectiveCInterop.Sel("initWithContentRect:styleMask:backing:defer:"),
                100.0, 100.0, Width, Height,
                MacConstants.NsWindowStyleMaskTitled | MacConstants.NsWindowStyleMaskClosable | MacConstants.NsWindowStyleMaskMiniaturizable | MacConstants.NsWindowStyleMaskResizable,
                MacConstants.NsBackingStoreBuffered, false);
            ObjectiveCInterop.objc_msgSend_void_IntPtr(Handle, ObjectiveCInterop.Sel("setTitle:"), ObjectiveCInterop.NsString(Title));
            ObjectiveCInterop.objc_msgSend_void(Handle, ObjectiveCInterop.Sel("center"));
        }

        public void Show() => ObjectiveCInterop.objc_msgSend_void_IntPtr(Handle, ObjectiveCInterop.Sel("makeKeyAndOrderFront:"), IntPtr.Zero);
        public void Hide() => ObjectiveCInterop.objc_msgSend_void(Handle, ObjectiveCInterop.Sel("orderOut:"));
        public void SetTitle(string title)
        {
            Title = title;
            ObjectiveCInterop.objc_msgSend_void_IntPtr(Handle, ObjectiveCInterop.Sel("setTitle:"), ObjectiveCInterop.NsString(Title));
        }
        public void SetSize(int width, int height)
        {
            Width = width;
            Height = height;
            // Cambiar tamaño de la ventana
            ObjectiveCInterop.objc_msgSend_void_IntPtr(Handle, ObjectiveCInterop.Sel("setContentSize:"), Marshal.AllocHGlobal(sizeof(double) * 2));
        }
        public bool IsVisible() => ObjectiveCInterop.objc_msgSend(Handle, ObjectiveCInterop.Sel("isVisible")) != IntPtr.Zero;
        public NsRect GetFrame()
        {
            IntPtr framePtr = ObjectiveCInterop.objc_msgSend(Handle, ObjectiveCInterop.Sel("frame"));
            return Marshal.PtrToStructure<NsRect>(framePtr);
        }
    }
}
#endif

