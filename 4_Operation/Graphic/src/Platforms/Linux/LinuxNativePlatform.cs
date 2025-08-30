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
        /// <summary>
                /// 
                /// </summary>
        private IntPtr display = IntPtr.Zero;
        /// <summary>
                /// 
                /// </summary>
        private IntPtr window = IntPtr.Zero;
        /// <summary>
                /// 
                /// </summary>
        private IntPtr glxContext = IntPtr.Zero;
        
        /// <summary>
                /// 
                /// </summary>
        private int width;

        /// <summary>
        /// 
        /// </summary>
        private int height;

        /// <summary>
                /// 
                /// </summary>
        private string title;
        
        /// <summary>
                /// 
                /// </summary>
        private bool windowVisible = false;
        
        /// <summary>
                /// 
                /// </summary>
        private ConsoleKey? lastKeyPressed = null;
        
        /// <summary>
        /// 
        /// </summary>
        private bool running = true;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="display"></param>
        /// <returns></returns>
        [System.Runtime.InteropServices.DllImport("libX11.so.6")]
        private static extern IntPtr XOpenDisplay(IntPtr display);
        
        /// <summary>
        /// 
        /// </summary>
        [System.Runtime.InteropServices.DllImport("libX11.so.6")]
        private static extern int XDefaultScreen(IntPtr display);
        
        /// <summary>
        /// 
        /// </summary>
        [System.Runtime.InteropServices.DllImport("libX11.so.6")]
        private static extern IntPtr XRootWindow(IntPtr display, int screen);
        
        /// <summary>
        /// 
        /// </summary>
        [System.Runtime.InteropServices.DllImport("libX11.so.6")]
        private static extern IntPtr XCreateSimpleWindow(IntPtr display, IntPtr parent, int x, int y, uint width, uint height, uint border_width, ulong border, ulong background);
        
        /// <summary>
        /// 
        /// </summary>
        [System.Runtime.InteropServices.DllImport("libX11.so.6")]
        private static extern void XMapWindow(IntPtr display, IntPtr window);
        
        /// <summary>
        /// 
        /// </summary>
        [System.Runtime.InteropServices.DllImport("libX11.so.6")]
        private static extern void XUnmapWindow(IntPtr display, IntPtr window);
        
        /// <summary>
        /// 
        /// </summary>
        [System.Runtime.InteropServices.DllImport("libX11.so.6")]
        private static extern void XStoreName(IntPtr display, IntPtr window, string name);
        
        /// <summary>
        /// 
        /// </summary>
        [System.Runtime.InteropServices.DllImport("libX11.so.6")]
        private static extern void XResizeWindow(IntPtr display, IntPtr window, uint width, uint height);
        
        /// <summary>
        /// 
        /// </summary>
        [System.Runtime.InteropServices.DllImport("libX11.so.6")]
        private static extern void XDestroyWindow(IntPtr display, IntPtr window);
        
        /// <summary>
        /// 
        /// </summary>
        [System.Runtime.InteropServices.DllImport("libX11.so.6")]
        private static extern void XCloseDisplay(IntPtr display);
        
        /// <summary>
        /// 
        /// </summary>
        [System.Runtime.InteropServices.DllImport("libX11.so.6")]
        private static extern void XSelectInput(IntPtr display, IntPtr window, long eventMask);
        
        /// <summary>
        /// 
        /// </summary>
        [System.Runtime.InteropServices.DllImport("libX11.so.6")]
        private static extern int XPending(IntPtr display);
        
        /// <summary>
        /// 
        /// </summary>
        [System.Runtime.InteropServices.DllImport("libX11.so.6")]
        private static extern int XNextEvent(IntPtr display, ref XEvent xevent);

        /// <summary>
        /// 
        /// </summary>
        [System.Runtime.InteropServices.DllImport("libGL.so.1")]
        private static extern IntPtr glXChooseVisual(IntPtr display, int screen, int[] attribList);
        
        /// <summary>
        /// 
        /// </summary>
        [System.Runtime.InteropServices.DllImport("libGL.so.1")]
        private static extern IntPtr glXCreateContext(IntPtr display, IntPtr visual, IntPtr shareList, int direct);
        
        /// <summary>
        /// 
        /// </summary>
        [System.Runtime.InteropServices.DllImport("libGL.so.1")]
        private static extern void glXMakeCurrent(IntPtr display, IntPtr drawable, IntPtr ctx);
        
        /// <summary>
        /// 
        /// </summary>
        [System.Runtime.InteropServices.DllImport("libGL.so.1")]
        private static extern void glXSwapBuffers(IntPtr display, IntPtr drawable);
        
        /// <summary>
        /// 
        /// </summary>
        [System.Runtime.InteropServices.DllImport("libGL.so.1")]
        private static extern void glXDestroyContext(IntPtr display, IntPtr ctx);
        
        /// <summary>
        /// 
        /// </summary>
        [System.Runtime.InteropServices.DllImport("libGL.so.1")]
        private static extern IntPtr glXGetProcAddress(byte[] name);
        
        /// <summary>
        /// 
        /// </summary>
        [System.Runtime.InteropServices.DllImport("libGL.so.1")]
        private static extern IntPtr glXChooseFBConfig(IntPtr display, int screen, int[] attribList, out int nitems);
        
        /// <summary>
        /// 
        /// </summary>
        [System.Runtime.InteropServices.DllImport("libGL.so.1")]
        private static extern IntPtr glXGetVisualFromFBConfig(IntPtr display, IntPtr fbConfig);

        // Estructuras X11
        /// <summary>
        /// The visual info
        /// </summary>
        [System.Runtime.InteropServices.StructLayout(System.Runtime.InteropServices.LayoutKind.Sequential)]
        private struct XVisualInfo
        {
            /// <summary>
            /// The visual
            /// </summary>
            public IntPtr visual;
            /// <summary>
            /// The visualid
            /// </summary>
            public IntPtr visualid;
            /// <summary>
            /// The screen
            /// </summary>
            public int screen;
            /// <summary>
            /// The depth
            /// </summary>
            public int depth;
            /// <summary>
            /// The cclass
            /// </summary>
            public int cclass;
            /// <summary>
            /// The red mask
            /// </summary>
            public ulong red_mask;
            /// <summary>
            /// The green mask
            /// </summary>
            public ulong green_mask;
            /// <summary>
            /// The blue mask
            /// </summary>
            public ulong blue_mask;
            /// <summary>
            /// The colormap size
            /// </summary>
            public int colormap_size;
            /// <summary>
            /// The bits per rgb
            /// </summary>
            public int bits_per_rgb;
        }
        /// <summary>
        /// Xes the create colormap using the specified display
        /// </summary>
        /// <param name="display">The display</param>
        /// <param name="window">The window</param>
        /// <param name="visual">The visual</param>
        /// <param name="alloc">The alloc</param>
        /// <returns>The int ptr</returns>
        [System.Runtime.InteropServices.DllImport("libX11.so.6")]
        private static extern IntPtr XCreateColormap(IntPtr display, IntPtr window, IntPtr visual, int alloc);
        /// <summary>
        /// Xes the create window using the specified display
        /// </summary>
        /// <param name="display">The display</param>
        /// <param name="parent">The parent</param>
        /// <param name="x">The </param>
        /// <param name="y">The </param>
        /// <param name="width">The width</param>
        /// <param name="height">The height</param>
        /// <param name="border_width">The border width</param>
        /// <param name="depth">The depth</param>
        /// <param name="class_">The class</param>
        /// <param name="visual">The visual</param>
        /// <param name="valuemask">The valuemask</param>
        /// <param name="attributes">The attributes</param>
        /// <returns>The int ptr</returns>
        [System.Runtime.InteropServices.DllImport("libX11.so.6")]
        private static extern IntPtr XCreateWindow(IntPtr display, IntPtr parent, int x, int y, uint width, uint height, uint border_width, int depth, uint class_, IntPtr visual, ulong valuemask, ref XSetWindowAttributes attributes);
        /// <summary>
        /// The set window attributes
        /// </summary>
        [System.Runtime.InteropServices.StructLayout(System.Runtime.InteropServices.LayoutKind.Sequential)]
        private struct XSetWindowAttributes
        {
            /// <summary>
            /// The background pixmap
            /// </summary>
            public IntPtr background_pixmap;
            /// <summary>
            /// The background pixel
            /// </summary>
            public ulong background_pixel;
            /// <summary>
            /// The border pixmap
            /// </summary>
            public IntPtr border_pixmap;
            /// <summary>
            /// The border pixel
            /// </summary>
            public ulong border_pixel;
            /// <summary>
            /// The bit gravity
            /// </summary>
            public int bit_gravity;
            /// <summary>
            /// The win gravity
            /// </summary>
            public int win_gravity;
            /// <summary>
            /// The backing store
            /// </summary>
            public int backing_store;
            /// <summary>
            /// The backing planes
            /// </summary>
            public ulong backing_planes;
            /// <summary>
            /// The backing pixel
            /// </summary>
            public ulong backing_pixel;
            /// <summary>
            /// The save under
            /// </summary>
            public int save_under;
            /// <summary>
            /// The event mask
            /// </summary>
            public IntPtr event_mask;
            /// <summary>
            /// The do not propagate mask
            /// </summary>
            public IntPtr do_not_propagate_mask;
            /// <summary>
            /// The override redirect
            /// </summary>
            public int override_redirect;
            /// <summary>
            /// The colormap
            /// </summary>
            public IntPtr colormap;
            /// <summary>
            /// The cursor
            /// </summary>
            public IntPtr cursor;
        }
        /// <summary>
        /// Xes the get visual info using the specified display
        /// </summary>
        /// <param name="display">The display</param>
        /// <param name="vinfo_mask">The vinfo mask</param>
        /// <param name="vinfo_template">The vinfo template</param>
        /// <param name="nitems">The nitems</param>
        /// <returns>The int ptr</returns>
        [System.Runtime.InteropServices.DllImport("libX11.so.6")]
        private static extern IntPtr XGetVisualInfo(IntPtr display, long vinfo_mask, ref XVisualInfo vinfo_template, ref int nitems);
        /// <summary>
        /// The visual id mask
        /// </summary>
        private const long VisualIDMask = 0x2;

        // Constantes de eventos X11
        /// <summary>
        /// The exposure mask
        /// </summary>
        private const long ExposureMask = 0x00008000L;
        /// <summary>
        /// The key press mask
        /// </summary>
        private const long KeyPressMask = 0x00000001L;
        /// <summary>
        /// The structure notify mask
        /// </summary>
        private const long StructureNotifyMask = 0x00020000L;
        /// <summary>
        /// The key press
        /// </summary>
        private const int KeyPress = 2;
        /// <summary>
        /// The destroy notify
        /// </summary>
        private const int DestroyNotify = 17;

        /// <summary>
        /// The visual selection result
        /// </summary>
        private struct VisualSelectionResult {
            /// <summary>
            /// The visual ptr
            /// </summary>
            public IntPtr VisualPtr;
            /// <summary>
            /// The visual info
            /// </summary>
            public XVisualInfo VisualInfo;
            /// <summary>
            /// The source
            /// </summary>
            public string Source;
        }
        /// <summary>
        /// Prints the x visual info using the specified prefix
        /// </summary>
        /// <param name="prefix">The prefix</param>
        /// <param name="info">The info</param>
        /// <param name="ptr">The ptr</param>
        private void PrintXVisualInfo(string prefix, XVisualInfo info, IntPtr ptr)
        {
            Console.WriteLine($"{prefix} visual: ptr=0x{ptr.ToInt64():X}, visualid={info.visualid}, depth={info.depth}, class={info.cclass}, screen={info.screen}, colormap_size={info.colormap_size}, bits_per_rgb={info.bits_per_rgb}, red_mask=0x{info.red_mask:X}, green_mask=0x{info.green_mask:X}, blue_mask=0x{info.blue_mask:X}");
        }
        /// <summary>
        /// Gets the valid visual info using the specified display
        /// </summary>
        /// <param name="display">The display</param>
        /// <param name="screen">The screen</param>
        /// <returns>The visual selection result</returns>
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
        /// <summary>
        /// Initializes the w
        /// </summary>
        /// <param name="w">The </param>
        /// <param name="h">The </param>
        /// <param name="t">The </param>
        /// <exception cref="Exception">[Init] Error creando el colormap</exception>
        /// <exception cref="Exception">[Init] Error creando la ventana X11 (BadMatch): revisa el visual y el colormap</exception>
        /// <exception cref="Exception">[Init] No se pudo abrir el display X11</exception>
        /// <exception cref="Exception">[Init] No se pudo crear el contexto GLX</exception>
        /// <exception cref="Exception">[Init] No se pudo obtener un visual GLX válido (ni FBConfig ni Visual). Verifica que tienes instalado libgl1-mesa-glx, libgl1-mesa-dev, libx11-dev y que estás usando X11, no Wayland.</exception>
        /// <returns>The bool</returns>
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
        /// <summary>
        /// Shows the window
        /// </summary>
        public void ShowWindow()
        {
            if (display != IntPtr.Zero && window != IntPtr.Zero)
            {
                XMapWindow(display, window);
                windowVisible = true;
            }
        }
        /// <summary>
        /// Hides the window
        /// </summary>
        public void HideWindow()
        {
            if (display != IntPtr.Zero && window != IntPtr.Zero)
            {
                XUnmapWindow(display, window);
                windowVisible = false;
            }
        }
        /// <summary>
        /// Sets the title using the specified t
        /// </summary>
        /// <param name="t">The </param>
        public void SetTitle(string t)
        {
            if (display != IntPtr.Zero && window != IntPtr.Zero)
            {
                XStoreName(display, window, t);
                title = t;
            }
        }
        /// <summary>
        /// Sets the size using the specified w
        /// </summary>
        /// <param name="w">The </param>
        /// <param name="h">The </param>
        public void SetSize(int w, int h)
        {
            if (display != IntPtr.Zero && window != IntPtr.Zero)
            {
                XResizeWindow(display, window, (uint)w, (uint)h);
                width = w;
                height = h;
            }
        }
        /// <summary>
        /// Makes the context current
        /// </summary>
        public void MakeContextCurrent()
        {
            if (display != IntPtr.Zero && window != IntPtr.Zero && glxContext != IntPtr.Zero)
            {
                glXMakeCurrent(display, window, glxContext);
            }
        }
        /// <summary>
        /// Swaps the buffers
        /// </summary>
        public void SwapBuffers()
        {
            if (display != IntPtr.Zero && window != IntPtr.Zero)
            {
                glXSwapBuffers(display, window);
            }
        }
        /// <summary>
        /// Ises the window visible
        /// </summary>
        /// <returns>The window visible</returns>
        public bool IsWindowVisible()
        {
            return windowVisible;
        }
        /// <summary>
        /// Polls the events
        /// </summary>
        /// <returns>The bool</returns>
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
        /// <summary>
        /// Cleanups this instance
        /// </summary>
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
        /// Gets the proc address using the specified name
        /// </summary>
        /// <param name="name">The name</param>
        /// <returns>The int ptr</returns>
        public IntPtr GetProcAddress(string name)
        {
            byte[] bytes = System.Text.Encoding.ASCII.GetBytes(name + "\0");
            return glXGetProcAddress(bytes);
        }
        /// <summary>
        /// Tries the get last key pressed using the specified key
        /// </summary>
        /// <param name="key">The key</param>
        /// <returns>The bool</returns>
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