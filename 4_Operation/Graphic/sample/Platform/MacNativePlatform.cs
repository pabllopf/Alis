using System;
using System.Runtime.InteropServices;
using System.Text;

namespace Alis.Core.Graphic.Sample.Platform
{
    /// <summary>
    /// The mac native platform class
    /// </summary>
    /// <seealso cref="INativePlatform"/>
    public class MacNativePlatform : INativePlatform
    {
        /// <summary>
        /// The objc
        /// </summary>
        const string Objc = "/usr/lib/libobjc.A.dylib";
        /// <summary>
        /// Objcs the get using the specified name
        /// </summary>
        /// <param name="name">The name</param>
        /// <returns>The int ptr</returns>
        [DllImport(Objc, EntryPoint = "objc_getClass", CallingConvention = CallingConvention.Cdecl)]
        static extern IntPtr objc_getClass(string name);
        /// <summary>
        /// Sels the register name using the specified name
        /// </summary>
        /// <param name="name">The name</param>
        /// <returns>The int ptr</returns>
        [DllImport(Objc, EntryPoint = "sel_registerName", CallingConvention = CallingConvention.Cdecl)]
        static extern IntPtr sel_registerName(string name);
        /// <summary>
        /// Objcs the msg send using the specified recv
        /// </summary>
        /// <param name="recv">The recv</param>
        /// <param name="sel">The sel</param>
        /// <returns>The int ptr</returns>
        [DllImport(Objc, EntryPoint = "objc_msgSend", CallingConvention = CallingConvention.Cdecl)]
        static extern IntPtr objc_msgSend(IntPtr recv, IntPtr sel);
        /// <summary>
        /// Objcs the msg send int ptr using the specified recv
        /// </summary>
        /// <param name="recv">The recv</param>
        /// <param name="sel">The sel</param>
        /// <param name="arg1">The arg</param>
        /// <returns>The int ptr</returns>
        [DllImport(Objc, EntryPoint = "objc_msgSend", CallingConvention = CallingConvention.Cdecl)]
        static extern IntPtr objc_msgSend_IntPtr(IntPtr recv, IntPtr sel, IntPtr arg1);
        /// <summary>
        /// Objcs the msg send void using the specified recv
        /// </summary>
        /// <param name="recv">The recv</param>
        /// <param name="sel">The sel</param>
        [DllImport(Objc, EntryPoint = "objc_msgSend", CallingConvention = CallingConvention.Cdecl)]
        static extern void objc_msgSend_void(IntPtr recv, IntPtr sel);
        /// <summary>
        /// Objcs the msg send void int ptr using the specified recv
        /// </summary>
        /// <param name="recv">The recv</param>
        /// <param name="sel">The sel</param>
        /// <param name="arg1">The arg</param>
        [DllImport(Objc, EntryPoint = "objc_msgSend", CallingConvention = CallingConvention.Cdecl)]
        static extern void objc_msgSend_void_IntPtr(IntPtr recv, IntPtr sel, IntPtr arg1);
        /// <summary>
        /// Objcs the msg send void bool using the specified recv
        /// </summary>
        /// <param name="recv">The recv</param>
        /// <param name="sel">The sel</param>
        /// <param name="arg1">The arg</param>
        [DllImport(Objc, EntryPoint = "objc_msgSend", CallingConvention = CallingConvention.Cdecl)]
        static extern void objc_msgSend_void_Bool(IntPtr recv, IntPtr sel, bool arg1);
        /// <summary>
        /// Objcs the msg send void long using the specified recv
        /// </summary>
        /// <param name="recv">The recv</param>
        /// <param name="sel">The sel</param>
        /// <param name="value">The value</param>
        [DllImport(Objc, EntryPoint = "objc_msgSend", CallingConvention = CallingConvention.Cdecl)]
        static extern void objc_msgSend_void_Long(IntPtr recv, IntPtr sel, long value);
        /// <summary>
        /// Objcs the msg send ns rect ul ul bool using the specified recv
        /// </summary>
        /// <param name="recv">The recv</param>
        /// <param name="sel">The sel</param>
        /// <param name="x">The </param>
        /// <param name="y">The </param>
        /// <param name="w">The </param>
        /// <param name="h">The </param>
        /// <param name="styleMask">The style mask</param>
        /// <param name="backing">The backing</param>
        /// <param name="defer">The defer</param>
        /// <returns>The int ptr</returns>
        [DllImport(Objc, EntryPoint = "objc_msgSend", CallingConvention = CallingConvention.Cdecl)]
        static extern IntPtr objc_msgSend_NSRect_UL_UL_Bool(
            IntPtr recv, IntPtr sel,
            double x, double y, double w, double h,
            ulong styleMask, ulong backing, bool defer);
        /// <summary>
        /// Objcs the msg send ns rect int ptr using the specified recv
        /// </summary>
        /// <param name="recv">The recv</param>
        /// <param name="sel">The sel</param>
        /// <param name="x">The </param>
        /// <param name="y">The </param>
        /// <param name="w">The </param>
        /// <param name="h">The </param>
        /// <param name="arg1">The arg</param>
        /// <returns>The int ptr</returns>
        [DllImport(Objc, EntryPoint = "objc_msgSend", CallingConvention = CallingConvention.Cdecl)]
        static extern IntPtr objc_msgSend_NSRect_IntPtr(
            IntPtr recv, IntPtr sel,
            double x, double y, double w, double h,
            IntPtr arg1);
        /// <summary>
        /// Objcs the msg send ul int ptr int ptr bool using the specified recv
        /// </summary>
        /// <param name="recv">The recv</param>
        /// <param name="sel">The sel</param>
        /// <param name="mask">The mask</param>
        /// <param name="untilDate">The until date</param>
        /// <param name="inMode">The in mode</param>
        /// <param name="dequeue">The dequeue</param>
        /// <returns>The int ptr</returns>
        [DllImport(Objc, EntryPoint = "objc_msgSend", CallingConvention = CallingConvention.Cdecl)]
        static extern IntPtr objc_msgSend_UL_IntPtr_IntPtr_Bool(
            IntPtr recv, IntPtr sel, ulong mask, IntPtr untilDate, IntPtr inMode, bool dequeue);
        /// <summary>
        /// Cfs the string create with c string using the specified alloc
        /// </summary>
        /// <param name="alloc">The alloc</param>
        /// <param name="str">The str</param>
        /// <param name="enc">The enc</param>
        /// <returns>The int ptr</returns>
        [DllImport("/System/Library/Frameworks/CoreFoundation.framework/CoreFoundation")]
        static extern IntPtr CFStringCreateWithCString(IntPtr alloc, string str, uint enc);
        /// <summary>
        /// The cf string encoding utf
        /// </summary>
        const uint KCfStringEncodingUtf8 = 0x08000100;
        /// <summary>
        /// The ns window style mask titled
        /// </summary>
        const ulong NsWindowStyleMaskTitled         = 1UL << 0;
        /// <summary>
        /// The ns window style mask closable
        /// </summary>
        const ulong NsWindowStyleMaskClosable       = 1UL << 1;
        /// <summary>
        /// The ns window style mask miniaturizable
        /// </summary>
        const ulong NsWindowStyleMaskMiniaturizable = 1UL << 2;
        /// <summary>
        /// The ns window style mask resizable
        /// </summary>
        const ulong NsWindowStyleMaskResizable      = 1UL << 3;
        /// <summary>
        /// The ns backing store buffered
        /// </summary>
        const ulong NsBackingStoreBuffered = 2;
        /// <summary>
        /// The ns application activation policy regular
        /// </summary>
        const long NsApplicationActivationPolicyRegular = 0;
        /// <summary>
        /// The ns open glpfa open gl profile
        /// </summary>
        const int NsOpenGlpfaOpenGlProfile = 99;
        /// <summary>
        /// The ns open gl profile version 32 core
        /// </summary>
        const int NsOpenGlProfileVersion32Core = 0x3200;
        /// <summary>
        /// The ns open glpfa double buffer
        /// </summary>
        const int NsOpenGlpfaDoubleBuffer = 5;
        /// <summary>
        /// The ns open glpfa color size
        /// </summary>
        const int NsOpenGlpfaColorSize    = 8;
        /// <summary>
        /// The ns open glpfa depth size
        /// </summary>
        const int NsOpenGlpfaDepthSize    = 12;
        /// <summary>
        /// The app
        /// </summary>
        private IntPtr window, view, ctx, pool, app;
        /// <summary>
        /// The height
        /// </summary>
        private int width, height;
        /// <summary>
        /// The title
        /// </summary>
        private string title;
        /// <summary>
        /// The fmt
        /// </summary>
        private IntPtr fmt;
        /// <summary>
        /// The distant past
        /// </summary>
        private IntPtr distantPast;
        /// <summary>
        /// The run loop mode
        /// </summary>
        private IntPtr runLoopMode;
        /// <summary>
        /// Initializes the w
        /// </summary>
        /// <param name="w">The </param>
        /// <param name="h">The </param>
        /// <param name="t">The </param>
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
        /// <summary>
        /// Shows the window
        /// </summary>
        public void ShowWindow() => objc_msgSend_void_IntPtr(window, Sel("makeKeyAndOrderFront:"), IntPtr.Zero);
        /// <summary>
        /// Hides the window
        /// </summary>
        public void HideWindow() => objc_msgSend_void(window, Sel("orderOut:"));
        /// <summary>
        /// Sets the title using the specified t
        /// </summary>
        /// <param name="t">The </param>
        public void SetTitle(string t)
        {
            title = t;
            objc_msgSend_void_IntPtr(window, Sel("setTitle:"), NsString(title));
        }
        /// <summary>
        /// Sets the size using the specified w
        /// </summary>
        /// <param name="w">The </param>
        /// <param name="h">The </param>
        public void SetSize(int w, int h)
        {
            width = w; height = h;
            // Cambiar tamaño de la ventana
            objc_msgSend_void_IntPtr(window, Sel("setContentSize:"), Marshal.AllocHGlobal(sizeof(double) * 2));
        }
        /// <summary>
        /// Makes the context current
        /// </summary>
        public void MakeContextCurrent() => objc_msgSend_void(ctx, Sel("makeCurrentContext"));
        /// <summary>
        /// Swaps the buffers
        /// </summary>
        public void SwapBuffers() => objc_msgSend_void(ctx, Sel("flushBuffer"));
        /// <summary>
        /// Ises the window visible
        /// </summary>
        /// <returns>The bool</returns>
        public bool IsWindowVisible() => objc_msgSend(window, Sel("isVisible")) != IntPtr.Zero;
        /// <summary>
        /// Polls the events
        /// </summary>
        /// <returns>The bool</returns>
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
        /// <summary>
        /// Cleanups this instance
        /// </summary>
        public void Cleanup()
        {
            objc_msgSend_void(pool, Sel("release"));
        }
        /// <summary>
        /// Gets the window width
        /// </summary>
        /// <returns>The int</returns>
        public int GetWindowWidth() => width;
        /// <summary>
        /// Gets the window height
        /// </summary>
        /// <returns>The int</returns>
        public int GetWindowHeight() => height;
        
        
        /// <summary>
        /// Dlsyms the handle
        /// </summary>
        /// <param name="handle">The handle</param>
        /// <param name="symbol">The symbol</param>
        /// <returns>The int ptr</returns>
        [DllImport("/usr/lib/libSystem.B.dylib")]
        static extern IntPtr dlsym(IntPtr handle, string symbol);
        /// <summary>
        /// Dlopens the path
        /// </summary>
        /// <param name="path">The path</param>
        /// <param name="mode">The mode</param>
        /// <returns>The int ptr</returns>
        [DllImport("/usr/lib/libSystem.B.dylib")]
        static extern IntPtr dlopen(string path, int mode);
        /// <summary>
        /// The rtld default
        /// </summary>
        const int RtldDefault = 0;

        /// <summary>
        /// The zero
        /// </summary>
        static IntPtr _openGlHandle = IntPtr.Zero;
        
        
        
        /// <summary>
        /// Gets the proc address using the specified name
        /// </summary>
        /// <param name="name">The name</param>
        /// <returns>The int ptr</returns>
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

        /// <summary>
        /// S the n
        /// </summary>
        /// <param name="n">The </param>
        /// <returns>The int ptr</returns>
        static IntPtr Class(string n) => objc_getClass(n);
        /// <summary>
        /// Sels the n
        /// </summary>
        /// <param name="n">The </param>
        /// <returns>The int ptr</returns>
        static IntPtr Sel(string n) => sel_registerName(n);
        /// <summary>
        /// Nses the string using the specified s
        /// </summary>
        /// <param name="s">The </param>
        /// <returns>The str</returns>
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
        /// <summary>
        /// Nses the application load
        /// </summary>
        [DllImport("/System/Library/Frameworks/AppKit.framework/AppKit")]
        static extern void NSApplicationLoad();
        /// <summary>
        /// The ns rect
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        struct NsRect
        {
            /// <summary>
            /// The 
            /// </summary>
            public double x;
            /// <summary>
            /// The 
            /// </summary>
            public double y;
            /// <summary>
            /// The width
            /// </summary>
            public double width;
            /// <summary>
            /// The height
            /// </summary>
            public double height;
        }
        /// <summary>
        /// Gets the window frame using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <returns>The ns rect</returns>
        static NsRect GetWindowFrame(IntPtr window)
        {
            IntPtr framePtr = objc_msgSend(window, Sel("frame"));
            return Marshal.PtrToStructure<NsRect>(framePtr);
        }
    }
}
