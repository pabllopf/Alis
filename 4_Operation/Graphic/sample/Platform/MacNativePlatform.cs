using System;
using System.Runtime.InteropServices;
using System.Text;

namespace Alis.Core.Graphic.Sample.Platform
{
    public class MacNativePlatform : INativePlatform
    {
        const string Objc = "/usr/lib/libobjc.A.dylib";
        [DllImport(Objc, EntryPoint = "objc_getClass", CallingConvention = CallingConvention.Cdecl)]
        static extern IntPtr objc_getClass(string name);
        [DllImport(Objc, EntryPoint = "sel_registerName", CallingConvention = CallingConvention.Cdecl)]
        static extern IntPtr sel_registerName(string name);
        [DllImport(Objc, EntryPoint = "objc_msgSend", CallingConvention = CallingConvention.Cdecl)]
        static extern IntPtr objc_msgSend(IntPtr recv, IntPtr sel);
        [DllImport(Objc, EntryPoint = "objc_msgSend", CallingConvention = CallingConvention.Cdecl)]
        static extern IntPtr objc_msgSend_IntPtr(IntPtr recv, IntPtr sel, IntPtr arg1);
        [DllImport(Objc, EntryPoint = "objc_msgSend", CallingConvention = CallingConvention.Cdecl)]
        static extern void objc_msgSend_void(IntPtr recv, IntPtr sel);
        [DllImport(Objc, EntryPoint = "objc_msgSend", CallingConvention = CallingConvention.Cdecl)]
        static extern void objc_msgSend_void_IntPtr(IntPtr recv, IntPtr sel, IntPtr arg1);
        [DllImport(Objc, EntryPoint = "objc_msgSend", CallingConvention = CallingConvention.Cdecl)]
        static extern void objc_msgSend_void_Bool(IntPtr recv, IntPtr sel, bool arg1);
        [DllImport(Objc, EntryPoint = "objc_msgSend", CallingConvention = CallingConvention.Cdecl)]
        static extern void objc_msgSend_void_Long(IntPtr recv, IntPtr sel, long value);
        [DllImport(Objc, EntryPoint = "objc_msgSend", CallingConvention = CallingConvention.Cdecl)]
        static extern IntPtr objc_msgSend_NSRect_UL_UL_Bool(
            IntPtr recv, IntPtr sel,
            double x, double y, double w, double h,
            ulong styleMask, ulong backing, bool defer);
        [DllImport(Objc, EntryPoint = "objc_msgSend", CallingConvention = CallingConvention.Cdecl)]
        static extern IntPtr objc_msgSend_NSRect_IntPtr(
            IntPtr recv, IntPtr sel,
            double x, double y, double w, double h,
            IntPtr arg1);
        [DllImport(Objc, EntryPoint = "objc_msgSend", CallingConvention = CallingConvention.Cdecl)]
        static extern IntPtr objc_msgSend_UL_IntPtr_IntPtr_Bool(
            IntPtr recv, IntPtr sel, ulong mask, IntPtr untilDate, IntPtr inMode, bool dequeue);
        [DllImport("/System/Library/Frameworks/CoreFoundation.framework/CoreFoundation")]
        static extern IntPtr CFStringCreateWithCString(IntPtr alloc, string str, uint enc);
        const uint KCfStringEncodingUtf8 = 0x08000100;
        const ulong NsWindowStyleMaskTitled         = 1UL << 0;
        const ulong NsWindowStyleMaskClosable       = 1UL << 1;
        const ulong NsWindowStyleMaskMiniaturizable = 1UL << 2;
        const ulong NsWindowStyleMaskResizable      = 1UL << 3;
        const ulong NsBackingStoreBuffered = 2;
        const long NsApplicationActivationPolicyRegular = 0;
        const int NsOpenGlpfaOpenGlProfile = 99;
        const int NsOpenGlProfileVersion32Core = 0x3200;
        const int NsOpenGlpfaDoubleBuffer = 5;
        const int NsOpenGlpfaColorSize    = 8;
        const int NsOpenGlpfaDepthSize    = 12;
        private IntPtr window, view, ctx, pool, app;
        private int width, height;
        private string title;
        private IntPtr fmt;
        private IntPtr distantPast;
        private IntPtr runLoopMode;
        public void Initialize(int w, int h, string t)
        {
            width = w; height = h; title = t;
            NSApplicationLoad();
            pool = objc_msgSend(Class("NSAutoreleasePool"), Sel("new"));
            app = objc_msgSend(Class("NSApplication"), Sel("sharedApplication"));
            objc_msgSend_void_Long(app, Sel("setActivationPolicy:"), NsApplicationActivationPolicyRegular);
            objc_msgSend_void_Bool(app, Sel("activateIgnoringOtherApps:"), true);
            objc_msgSend_void(app, Sel("finishLaunching"));
            window = objc_msgSend(Class("NSWindow"), Sel("alloc"));
            window = objc_msgSend_NSRect_UL_UL_Bool(
                window, Sel("initWithContentRect:styleMask:backing:defer:"),
                100.0, 100.0, width, height,
                NsWindowStyleMaskTitled | NsWindowStyleMaskClosable | NsWindowStyleMaskMiniaturizable | NsWindowStyleMaskResizable,
                NsBackingStoreBuffered, false);
            objc_msgSend_void_IntPtr(window, Sel("setTitle:"), NsString(title));
            objc_msgSend_void(window, Sel("center"));
            int[] attrs = {
                NsOpenGlpfaOpenGlProfile, NsOpenGlProfileVersion32Core,
                NsOpenGlpfaDoubleBuffer,
                NsOpenGlpfaColorSize, 24,
                NsOpenGlpfaDepthSize, 24,
                0
            };
            fmt = objc_msgSend(Class("NSOpenGLPixelFormat"), Sel("alloc"));
            GCHandle pin = GCHandle.Alloc(attrs, GCHandleType.Pinned);
            try
            {
                fmt = objc_msgSend_IntPtr(fmt, Sel("initWithAttributes:"), pin.AddrOfPinnedObject());
            }
            finally { pin.Free(); }
            view = objc_msgSend(Class("NSOpenGLView"), Sel("alloc"));
            var frame = GetWindowFrame(window);
            view = objc_msgSend_NSRect_IntPtr(view, Sel("initWithFrame:pixelFormat:"),
                frame.x, frame.y, frame.width, frame.height, fmt);
            objc_msgSend_void_IntPtr(window, Sel("setContentView:"), view);
            objc_msgSend_void_IntPtr(window, Sel("makeKeyAndOrderFront:"), IntPtr.Zero);
            ctx = objc_msgSend(view, Sel("openGLContext"));
            distantPast = objc_msgSend(Class("NSDate"), Sel("distantPast"));
            runLoopMode = CFStringCreateWithCString(IntPtr.Zero, "kCFRunLoopDefaultMode", KCfStringEncodingUtf8);
        }
        public void ShowWindow() => objc_msgSend_void_IntPtr(window, Sel("makeKeyAndOrderFront:"), IntPtr.Zero);
        public void HideWindow() => objc_msgSend_void(window, Sel("orderOut:"));
        public void SetTitle(string t)
        {
            title = t;
            objc_msgSend_void_IntPtr(window, Sel("setTitle:"), NsString(title));
        }
        public void SetSize(int w, int h)
        {
            width = w; height = h;
            // Cambiar tamaño de la ventana
            objc_msgSend_void_IntPtr(window, Sel("setContentSize:"), Marshal.AllocHGlobal(sizeof(double) * 2));
        }
        public void MakeContextCurrent() => objc_msgSend_void(ctx, Sel("makeCurrentContext"));
        public void SwapBuffers() => objc_msgSend_void(ctx, Sel("flushBuffer"));
        public bool IsWindowVisible() => objc_msgSend(window, Sel("isVisible")) != IntPtr.Zero;
        public bool PollEvents()
        {
            IntPtr evt = objc_msgSend_UL_IntPtr_IntPtr_Bool(app,
                Sel("nextEventMatchingMask:untilDate:inMode:dequeue:"),
                ulong.MaxValue, distantPast, runLoopMode, true);
            if (evt != IntPtr.Zero)
            {
                objc_msgSend_void_IntPtr(app, Sel("sendEvent:"), evt);
                objc_msgSend_void(app, Sel("updateWindows"));
            }
            return IsWindowVisible();
        }
        public void Cleanup()
        {
            objc_msgSend_void(pool, Sel("release"));
        }
        public int GetWindowWidth() => width;
        public int GetWindowHeight() => height;
        
        
        [DllImport("/usr/lib/libSystem.B.dylib")]
        static extern IntPtr dlsym(IntPtr handle, string symbol);
        [DllImport("/usr/lib/libSystem.B.dylib")]
        static extern IntPtr dlopen(string path, int mode);
        const int RtldDefault = 0;

        static IntPtr _openGlHandle = IntPtr.Zero;
        
        
        
        public IntPtr GetProcAddress(string name)
        {
            if (_openGlHandle == IntPtr.Zero)
            {
                _openGlHandle = dlopen("/System/Library/Frameworks/OpenGL.framework/OpenGL", 0);
                if (_openGlHandle == IntPtr.Zero)
                {
                    Console.WriteLine("❌ No se pudo abrir la librería OpenGL");
                    return IntPtr.Zero;
                }
            }
            return dlsym(_openGlHandle, name);
        }

        static IntPtr Class(string n) => objc_getClass(n);
        static IntPtr Sel(string n) => sel_registerName(n);
        static IntPtr NsString(string s)
        {
            var bytes = Encoding.UTF8.GetBytes(s);
            var mem = Marshal.AllocHGlobal(bytes.Length + 1);
            Marshal.Copy(bytes, 0, mem, bytes.Length);
            Marshal.WriteByte(mem, bytes.Length, 0);
            var str = objc_msgSend_IntPtr(Class("NSString"), Sel("stringWithUTF8String:"), mem);
            Marshal.FreeHGlobal(mem);
            return str;
        }
        [DllImport("/System/Library/Frameworks/AppKit.framework/AppKit")]
        static extern void NSApplicationLoad();
        [StructLayout(LayoutKind.Sequential)]
        struct NsRect
        {
            public double x;
            public double y;
            public double width;
            public double height;
        }
        static NsRect GetWindowFrame(IntPtr window)
        {
            IntPtr framePtr = objc_msgSend(window, Sel("frame"));
            return Marshal.PtrToStructure<NsRect>(framePtr);
        }
    }
}
