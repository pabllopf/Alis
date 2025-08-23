#if LINUX

using System;

namespace Alis.Core.Graphic.Platforms.Linux
{
    /// <summary>
    /// The linux native platform class
    /// </summary>
    /// <seealso cref="INativePlatform"/>
    public class LinuxNativePlatform : INativePlatform
    {
        // Campos nativos
        private IntPtr display = IntPtr.Zero;
        private IntPtr window = IntPtr.Zero;
        private IntPtr glxContext = IntPtr.Zero;
        private int width, height;
        private string title;
        private bool windowVisible = false;
        private ConsoleKey? lastKeyPressed = null;
        private bool running = true;

        // DllImports X11 y GLX
        [System.Runtime.InteropServices.DllImport("libX11.so.6")]
        private static extern IntPtr XOpenDisplay(IntPtr display);
        [System.Runtime.InteropServices.DllImport("libX11.so.6")]
        private static extern int XDefaultScreen(IntPtr display);
        [System.Runtime.InteropServices.DllImport("libX11.so.6")]
        private static extern IntPtr XRootWindow(IntPtr display, int screen);
        [System.Runtime.InteropServices.DllImport("libX11.so.6")]
        private static extern IntPtr XCreateSimpleWindow(IntPtr display, IntPtr parent, int x, int y, uint width, uint height, uint border_width, ulong border, ulong background);
        [System.Runtime.InteropServices.DllImport("libX11.so.6")]
        private static extern void XMapWindow(IntPtr display, IntPtr window);
        [System.Runtime.InteropServices.DllImport("libX11.so.6")]
        private static extern void XUnmapWindow(IntPtr display, IntPtr window);
        [System.Runtime.InteropServices.DllImport("libX11.so.6")]
        private static extern void XStoreName(IntPtr display, IntPtr window, string name);
        [System.Runtime.InteropServices.DllImport("libX11.so.6")]
        private static extern void XResizeWindow(IntPtr display, IntPtr window, uint width, uint height);
        [System.Runtime.InteropServices.DllImport("libX11.so.6")]
        private static extern void XDestroyWindow(IntPtr display, IntPtr window);
        [System.Runtime.InteropServices.DllImport("libX11.so.6")]
        private static extern void XCloseDisplay(IntPtr display);
        [System.Runtime.InteropServices.DllImport("libX11.so.6")]
        private static extern void XSelectInput(IntPtr display, IntPtr window, long eventMask);
        [System.Runtime.InteropServices.DllImport("libX11.so.6")]
        private static extern int XPending(IntPtr display);
        [System.Runtime.InteropServices.DllImport("libX11.so.6")]
        private static extern int XNextEvent(IntPtr display, ref XEvent xevent);

        // GLX
        [System.Runtime.InteropServices.DllImport("libGL.so.1")]
        private static extern IntPtr glXChooseVisual(IntPtr display, int screen, int[] attribList);
        [System.Runtime.InteropServices.DllImport("libGL.so.1")]
        private static extern IntPtr glXCreateContext(IntPtr display, IntPtr visual, IntPtr shareList, int direct);
        [System.Runtime.InteropServices.DllImport("libGL.so.1")]
        private static extern void glXMakeCurrent(IntPtr display, IntPtr drawable, IntPtr ctx);
        [System.Runtime.InteropServices.DllImport("libGL.so.1")]
        private static extern void glXSwapBuffers(IntPtr display, IntPtr drawable);
        [System.Runtime.InteropServices.DllImport("libGL.so.1")]
        private static extern void glXDestroyContext(IntPtr display, IntPtr ctx);
        [System.Runtime.InteropServices.DllImport("libGL.so.1")]
        private static extern IntPtr glXGetProcAddress(byte[] name);
        [System.Runtime.InteropServices.DllImport("libGL.so.1")]
        private static extern IntPtr glXChooseFBConfig(IntPtr display, int screen, int[] attribList, out int nitems);
        [System.Runtime.InteropServices.DllImport("libGL.so.1")]
        private static extern IntPtr glXGetVisualFromFBConfig(IntPtr display, IntPtr fbConfig);

        // Estructuras X11
        private struct XEvent
        {
            public int type;
            public IntPtr pad1;
            public IntPtr pad2;
            public IntPtr pad3;
            public IntPtr pad4;
            public IntPtr pad5;
            public IntPtr pad6;
            public IntPtr pad7;
            public IntPtr pad8;
            public IntPtr pad9;
            public IntPtr pad10;
            public IntPtr pad11;
            public IntPtr pad12;
            public IntPtr pad13;
            public IntPtr pad14;
            public IntPtr pad15;
            public IntPtr pad16;
            public IntPtr pad17;
            public IntPtr pad18;
            public IntPtr pad19;
            public IntPtr pad20;
            public IntPtr pad21;
            public IntPtr pad22;
            public IntPtr pad23;
        }
        [System.Runtime.InteropServices.StructLayout(System.Runtime.InteropServices.LayoutKind.Sequential)]
        private struct XVisualInfo
        {
            public IntPtr visual;
            public IntPtr visualid;
            public int screen;
            public int depth;
            public int cclass;
            public ulong red_mask;
            public ulong green_mask;
            public ulong blue_mask;
            public int colormap_size;
            public int bits_per_rgb;
        }
        [System.Runtime.InteropServices.DllImport("libX11.so.6")]
        private static extern IntPtr XCreateColormap(IntPtr display, IntPtr window, IntPtr visual, int alloc);
        [System.Runtime.InteropServices.DllImport("libX11.so.6")]
        private static extern IntPtr XCreateWindow(IntPtr display, IntPtr parent, int x, int y, uint width, uint height, uint border_width, int depth, uint class_, IntPtr visual, ulong valuemask, ref XSetWindowAttributes attributes);
        [System.Runtime.InteropServices.StructLayout(System.Runtime.InteropServices.LayoutKind.Sequential)]
        private struct XSetWindowAttributes
        {
            public IntPtr background_pixmap;
            public ulong background_pixel;
            public IntPtr border_pixmap;
            public ulong border_pixel;
            public int bit_gravity;
            public int win_gravity;
            public int backing_store;
            public ulong backing_planes;
            public ulong backing_pixel;
            public int save_under;
            public IntPtr event_mask;
            public IntPtr do_not_propagate_mask;
            public int override_redirect;
            public IntPtr colormap;
            public IntPtr cursor;
        }
        [System.Runtime.InteropServices.DllImport("libX11.so.6")]
        private static extern IntPtr XGetVisualInfo(IntPtr display, long vinfo_mask, ref XVisualInfo vinfo_template, ref int nitems);
        private const long VisualIDMask = 0x2;

        // Constantes de eventos X11
        private const long ExposureMask = 0x00008000L;
        private const long KeyPressMask = 0x00000001L;
        private const long StructureNotifyMask = 0x00020000L;
        private const int KeyPress = 2;
        private const int DestroyNotify = 17;

        private struct VisualSelectionResult {
            public IntPtr VisualPtr;
            public XVisualInfo VisualInfo;
            public string Source;
        }
        private void PrintXVisualInfo(string prefix, XVisualInfo info, IntPtr ptr)
        {
            Console.WriteLine($"{prefix} visual: ptr=0x{ptr.ToInt64():X}, visualid={info.visualid}, depth={info.depth}, class={info.cclass}, screen={info.screen}, colormap_size={info.colormap_size}, bits_per_rgb={info.bits_per_rgb}, red_mask=0x{info.red_mask:X}, green_mask=0x{info.green_mask:X}, blue_mask=0x{info.blue_mask:X}");
        }
        private VisualSelectionResult? GetValidVisualInfo(IntPtr display, int screen)
        {
            int[][] fbAttribSets = new int[][] {
                new int[] { 0x8010, 1, 0x8011, 1, 0x6, 1, 0x8012, 1, 0x8, 24, 0 },
                new int[] { 0x6, 1, 0x8, 24, 0x8010, 1, 0 },
                new int[] { 0x8010, 1, 0x8012, 1, 0x8, 16, 0 },
                new int[] { 0x8010, 1, 0x8012, 1, 0 }
            };
            foreach (var fbAttribs in fbAttribSets)
            {
                int nitems;
                IntPtr fbConfigs = glXChooseFBConfig(display, screen, fbAttribs, out nitems);
                if (fbConfigs != IntPtr.Zero && nitems > 0)
                {
                    IntPtr fbConfig = System.Runtime.InteropServices.Marshal.ReadIntPtr(fbConfigs);
                    IntPtr visualPtr = glXGetVisualFromFBConfig(display, fbConfig);
                    if (visualPtr != IntPtr.Zero)
                    {
                        XVisualInfo info = System.Runtime.InteropServices.Marshal.PtrToStructure<XVisualInfo>(visualPtr);
                        PrintXVisualInfo("FBConfig", info, visualPtr);
                        // Get canonical XVisualInfo from XGetVisualInfo
                        int nitems2 = 0;
                        IntPtr canonicalPtr = XGetVisualInfo(display, VisualIDMask, ref info, ref nitems2);
                        if (canonicalPtr != IntPtr.Zero && nitems2 > 0)
                        {
                            XVisualInfo canonicalInfo = System.Runtime.InteropServices.Marshal.PtrToStructure<XVisualInfo>(canonicalPtr);
                            PrintXVisualInfo("Canonical", canonicalInfo, canonicalPtr);
                            if (canonicalInfo.cclass == 4)
                                return new VisualSelectionResult { VisualPtr = canonicalPtr, VisualInfo = canonicalInfo, Source = "FBConfig+Canonical" };
                        }
                    }
                }
            }
            int[][] visualAttribSets = new int[][] {
                new int[] { 0x6, 1, 0x8, 24, 0x8010, 1, 0 },
                new int[] { 0x6, 1, 0x8, 16, 0 },
                new int[] { 0x6, 1, 0 }
            };
            foreach (var attribs in visualAttribSets)
            {
                IntPtr visualPtr = glXChooseVisual(display, screen, attribs);
                if (visualPtr != IntPtr.Zero)
                {
                    XVisualInfo info = System.Runtime.InteropServices.Marshal.PtrToStructure<XVisualInfo>(visualPtr);
                    PrintXVisualInfo("Legacy", info, visualPtr);
                    int nitems2 = 0;
                    IntPtr canonicalPtr = XGetVisualInfo(display, VisualIDMask, ref info, ref nitems2);
                    if (canonicalPtr != IntPtr.Zero && nitems2 > 0)
                    {
                        XVisualInfo canonicalInfo = System.Runtime.InteropServices.Marshal.PtrToStructure<XVisualInfo>(canonicalPtr);
                        PrintXVisualInfo("Canonical", canonicalInfo, canonicalPtr);
                        if (canonicalInfo.cclass == 4)
                            return new VisualSelectionResult { VisualPtr = canonicalPtr, VisualInfo = canonicalInfo, Source = "Legacy+Canonical" };
                    }
                }
            }
            return null;
        }
        public bool Initialize(int w, int h, string t)
        {
            Console.WriteLine("[Init] Starting LinuxNativePlatform initialization...");
            width = w;
            height = h;
            title = t;
            display = XOpenDisplay(IntPtr.Zero);
            if (display == IntPtr.Zero)
                throw new Exception("[Init] No se pudo abrir el display X11");
            int screen = XDefaultScreen(display);
            IntPtr root = XRootWindow(display, screen);
            Console.WriteLine($"[Init] Display opened, screen={screen}, root=0x{root.ToInt64():X}");
            var visualResult = GetValidVisualInfo(display, screen);
            if (!visualResult.HasValue)
            {
                throw new Exception("[Init] No se pudo obtener un visual GLX válido (ni FBConfig ni Visual). Verifica que tienes instalado libgl1-mesa-glx, libgl1-mesa-dev, libx11-dev y que estás usando X11, no Wayland.");
            }
            var visualPtr = visualResult.Value.VisualPtr;
            var visualInfo = visualResult.Value.VisualInfo;
            PrintXVisualInfo("[Init] Selected", visualInfo, visualPtr);
            IntPtr colormap = XCreateColormap(display, root, visualInfo.visual, 0);
            if (colormap == IntPtr.Zero)
                throw new Exception("[Init] Error creando el colormap");
            Console.WriteLine($"[Init] Colormap creado: 0x{colormap.ToInt64():X}");
            XSetWindowAttributes attrs = new XSetWindowAttributes();
            attrs.colormap = colormap;
            attrs.event_mask = (IntPtr)(ExposureMask | KeyPressMask | StructureNotifyMask);
            ulong CWColormap = 0x00000010;
            ulong CWEventMask = 0x00000080;
            ulong valuemask = CWColormap | CWEventMask;
            window = XCreateWindow(display, root, 0, 0, (uint)width, (uint)height, 0, visualInfo.depth, 1 /*InputOutput*/, visualInfo.visual, valuemask, ref attrs);
            if (window == IntPtr.Zero)
                throw new Exception("[Init] Error creando la ventana X11 (BadMatch): revisa el visual y el colormap");
            Console.WriteLine($"[Init] Ventana creada: 0x{window.ToInt64():X}");
            XStoreName(display, window, title);
            XMapWindow(display, window);
            Console.WriteLine("[Init] Ventana mapeada");
            Console.WriteLine($"[Init] glXCreateContext params: display=0x{display.ToInt64():X}, visualPtr=0x{visualPtr.ToInt64():X}, window=0x{window.ToInt64():X}");
            glxContext = glXCreateContext(display, visualPtr, IntPtr.Zero, 1);
            if (glxContext == IntPtr.Zero)
            {
                Console.WriteLine("[Init] glXCreateContext failed, trying legacy visual fallback...");
                // Try legacy visual fallback
                var legacyVisual = GetValidVisualInfo(display, screen);
                if (legacyVisual.HasValue)
                {
                    glxContext = glXCreateContext(display, legacyVisual.Value.VisualPtr, IntPtr.Zero, 1);
                    if (glxContext != IntPtr.Zero)
                        Console.WriteLine("[Init] Legacy visual context created");
                }
            }
            if (glxContext == IntPtr.Zero)
                throw new Exception("[Init] No se pudo crear el contexto GLX");
            Console.WriteLine($"[Init] GLX context creado: 0x{glxContext.ToInt64():X}");
            glXMakeCurrent(display, window, glxContext);
            Console.WriteLine("[Init] GLX context activado");
            // Print OpenGL version
            try {
                var glVersion = Alis.Core.Graphic.OpenGL.Gl.GlGetString(Alis.Core.Graphic.OpenGL.Enums.StringName.Version);
                Console.WriteLine($"[Init] OpenGL version: {glVersion}");
            } catch (Exception ex) {
                Console.WriteLine($"[Init] Error obteniendo la versión de OpenGL: {ex.Message}");
            }
            windowVisible = true;
            running = true;

            return true;
        }
        public void ShowWindow()
        {
            if (display != IntPtr.Zero && window != IntPtr.Zero)
            {
                XMapWindow(display, window);
                windowVisible = true;
            }
        }
        public void HideWindow()
        {
            if (display != IntPtr.Zero && window != IntPtr.Zero)
            {
                XUnmapWindow(display, window);
                windowVisible = false;
            }
        }
        public void SetTitle(string t)
        {
            if (display != IntPtr.Zero && window != IntPtr.Zero)
            {
                XStoreName(display, window, t);
                title = t;
            }
        }
        public void SetSize(int w, int h)
        {
            if (display != IntPtr.Zero && window != IntPtr.Zero)
            {
                XResizeWindow(display, window, (uint)w, (uint)h);
                width = w;
                height = h;
            }
        }
        public void MakeContextCurrent()
        {
            if (display != IntPtr.Zero && window != IntPtr.Zero && glxContext != IntPtr.Zero)
            {
                glXMakeCurrent(display, window, glxContext);
            }
        }
        public void SwapBuffers()
        {
            if (display != IntPtr.Zero && window != IntPtr.Zero)
            {
                glXSwapBuffers(display, window);
            }
        }
        public bool IsWindowVisible()
        {
            return windowVisible;
        }
        public bool PollEvents()
        {
            if (display == IntPtr.Zero || window == IntPtr.Zero)
                return false;
            while (XPending(display) > 0)
            {
                XEvent xev = new XEvent();
                XNextEvent(display, ref xev);
                if (xev.type == KeyPress)
                {
                    lastKeyPressed = ConsoleKey.Spacebar; // Solo ejemplo, se puede mapear mejor
                }
                if (xev.type == DestroyNotify)
                {
                    running = false;
                    windowVisible = false;
                }
            }
            return running && windowVisible;
        }
        public void Cleanup()
        {
            if (display != IntPtr.Zero)
            {
                if (glxContext != IntPtr.Zero)
                {
                    glXMakeCurrent(display, window, IntPtr.Zero);
                    glXDestroyContext(display, glxContext);
                    glxContext = IntPtr.Zero;
                }
                if (window != IntPtr.Zero)
                {
                    XDestroyWindow(display, window);
                    window = IntPtr.Zero;
                }
                XCloseDisplay(display);
                display = IntPtr.Zero;
            }
        }
        public int GetWindowWidth() => width;
        public int GetWindowHeight() => height;
        public IntPtr GetProcAddress(string name)
        {
            byte[] bytes = System.Text.Encoding.ASCII.GetBytes(name + "\0");
            return glXGetProcAddress(bytes);
        }
        public bool TryGetLastKeyPressed(out ConsoleKey key)
        {
            if (lastKeyPressed.HasValue)
            {
                key = lastKeyPressed.Value;
                lastKeyPressed = null;
                return true;
            }
            key = default;
            return false;
        }
    }
}

#endif