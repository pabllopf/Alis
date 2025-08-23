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

        // Constantes de eventos X11
        private const long ExposureMask = 0x00008000L;
        private const long KeyPressMask = 0x00000001L;
        private const long StructureNotifyMask = 0x00020000L;
        private const int KeyPress = 2;
        private const int DestroyNotify = 17;

        private IntPtr GetBestVisual(IntPtr display, int screen)
        {
            // Try several attribute sets for maximum compatibility
            int[][] fbAttribSets = new int[][] {
                new int[] { 0x8010, 1, 0x8011, 1, 0x6, 1, 0x8012, 1, 0x8, 24, 0 }, // Modern
                new int[] { 0x6, 1, 0x8, 24, 0x8010, 1, 0 }, // Legacy
                new int[] { 0x8010, 1, 0x8012, 1, 0x8, 16, 0 }, // 16-bit depth
                new int[] { 0x8010, 1, 0x8012, 1, 0 } // Minimal
            };
            foreach (var fbAttribs in fbAttribSets)
            {
                int nitems;
                IntPtr fbConfigs = glXChooseFBConfig(display, screen, fbAttribs, out nitems);
                if (fbConfigs != IntPtr.Zero && nitems > 0)
                {
                    IntPtr fbConfig = System.Runtime.InteropServices.Marshal.ReadIntPtr(fbConfigs);
                    IntPtr visual = glXGetVisualFromFBConfig(display, fbConfig);
                    if (visual != IntPtr.Zero)
                    {
                        Console.WriteLine("GLX visual obtained via FBConfig");
                        return visual;
                    }
                }
            }
            // Try several attribute sets for glXChooseVisual
            int[][] visualAttribSets = new int[][] {
                new int[] { 0x6, 1, 0x8, 24, 0x8010, 1, 0 },
                new int[] { 0x6, 1, 0x8, 16, 0 },
                new int[] { 0x6, 1, 0 }
            };
            foreach (var attribs in visualAttribSets)
            {
                IntPtr visual = glXChooseVisual(display, screen, attribs);
                if (visual != IntPtr.Zero)
                {
                    Console.WriteLine("GLX visual obtained via glXChooseVisual");
                    return visual;
                }
            }
            // If all fail, print diagnostics
            Console.Error.WriteLine("No se pudo obtener un visual GLX válido (ni FBConfig ni Visual)");
            return IntPtr.Zero;
        }

        public void Initialize(int w, int h, string t)
        {
            width = w;
            height = h;
            title = t;
            display = XOpenDisplay(IntPtr.Zero);
            if (display == IntPtr.Zero)
                throw new Exception("No se pudo abrir el display X11");
            int screen = XDefaultScreen(display);
            IntPtr root = XRootWindow(display, screen);
            IntPtr visual = GetBestVisual(display, screen);
            if (visual == IntPtr.Zero)
            {
                throw new Exception("No se pudo obtener un visual GLX válido (ni FBConfig ni Visual). Verifica que tienes instalado libgl1-mesa-glx, libgl1-mesa-dev, libx11-dev y que estás usando X11, no Wayland.");
            }
            window = XCreateSimpleWindow(display, root, 0, 0, (uint)width, (uint)height, 1, 0, 0);
            XStoreName(display, window, title);
            XSelectInput(display, window, ExposureMask | KeyPressMask | StructureNotifyMask);
            glxContext = glXCreateContext(display, visual, IntPtr.Zero, 1);
            if (glxContext == IntPtr.Zero)
                throw new Exception("No se pudo crear el contexto GLX");
            glXMakeCurrent(display, window, glxContext);
            XMapWindow(display, window);
            windowVisible = true;
            running = true;
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