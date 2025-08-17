using System;
using System.Runtime.InteropServices;
using System.Text;
using Alis.Core.Graphic.OpenGL;
using Alis.Core.Graphic.OpenGL.Enums;
using Alis.Core.Aspect.Math.Matrix;
using Alis.Core.Aspect.Math.Vector;

static class Program
{
    const string OBJC = "/usr/lib/libobjc.A.dylib";

    [DllImport(OBJC, EntryPoint = "objc_getClass", CallingConvention = CallingConvention.Cdecl)]
    static extern IntPtr objc_getClass(string name);

    [DllImport(OBJC, EntryPoint = "sel_registerName", CallingConvention = CallingConvention.Cdecl)]
    static extern IntPtr sel_registerName(string name);

    [DllImport(OBJC, EntryPoint = "objc_msgSend", CallingConvention = CallingConvention.Cdecl)]
    static extern IntPtr objc_msgSend(IntPtr recv, IntPtr sel);

    [DllImport(OBJC, EntryPoint = "objc_msgSend", CallingConvention = CallingConvention.Cdecl)]
    static extern IntPtr objc_msgSend_IntPtr(IntPtr recv, IntPtr sel, IntPtr arg1);

    [DllImport(OBJC, EntryPoint = "objc_msgSend", CallingConvention = CallingConvention.Cdecl)]
    static extern void objc_msgSend_void(IntPtr recv, IntPtr sel);

    [DllImport(OBJC, EntryPoint = "objc_msgSend", CallingConvention = CallingConvention.Cdecl)]
    static extern void objc_msgSend_void_IntPtr(IntPtr recv, IntPtr sel, IntPtr arg1);

    [DllImport(OBJC, EntryPoint = "objc_msgSend", CallingConvention = CallingConvention.Cdecl)]
    static extern void objc_msgSend_void_Bool(IntPtr recv, IntPtr sel, bool arg1);

    [DllImport(OBJC, EntryPoint = "objc_msgSend", CallingConvention = CallingConvention.Cdecl)]
    static extern void objc_msgSend_void_Long(IntPtr recv, IntPtr sel, long value);

    // Para ARM64: descomponemos el NSRect
    [DllImport(OBJC, EntryPoint = "objc_msgSend", CallingConvention = CallingConvention.Cdecl)]
    static extern IntPtr objc_msgSend_NSRect_UL_UL_Bool(
        IntPtr recv, IntPtr sel,
        double x, double y, double w, double h,
        ulong styleMask, ulong backing, bool defer);

    [DllImport(OBJC, EntryPoint = "objc_msgSend", CallingConvention = CallingConvention.Cdecl)]
    static extern IntPtr objc_msgSend_NSRect_IntPtr(
        IntPtr recv, IntPtr sel,
        double x, double y, double w, double h,
        IntPtr arg1);

    [DllImport(OBJC, EntryPoint = "objc_msgSend", CallingConvention = CallingConvention.Cdecl)]
    static extern IntPtr objc_msgSend_UL_IntPtr_IntPtr_Bool(
        IntPtr recv, IntPtr sel, ulong mask, IntPtr untilDate, IntPtr inMode, bool dequeue);

    [DllImport("/System/Library/Frameworks/CoreFoundation.framework/CoreFoundation")]
    static extern IntPtr CFStringCreateWithCString(IntPtr alloc, string str, uint enc);
    const uint kCFStringEncodingUTF8 = 0x08000100;

    const uint GL_COLOR_BUFFER_BIT = 0x00004000;

    const ulong NSWindowStyleMaskTitled         = 1UL << 0;
    const ulong NSWindowStyleMaskClosable       = 1UL << 1;
    const ulong NSWindowStyleMaskMiniaturizable = 1UL << 2;
    const ulong NSWindowStyleMaskResizable      = 1UL << 3;

    const ulong NSBackingStoreBuffered = 2;
    const long NSApplicationActivationPolicyRegular = 0;

    const int NSOpenGLPFAOpenGLProfile = 99;
    const int NSOpenGLProfileVersion3_2Core = 0x3200;
    const int NSOpenGLPFADoubleBuffer = 5;
    const int NSOpenGLPFAColorSize    = 8;
    const int NSOpenGLPFADepthSize    = 12;

    static IntPtr CLASS(string n) => objc_getClass(n);
    static IntPtr SEL(string n) => sel_registerName(n);

    static IntPtr NSString(string s)
    {
        var bytes = Encoding.UTF8.GetBytes(s);
        var mem = Marshal.AllocHGlobal(bytes.Length + 1);
        Marshal.Copy(bytes, 0, mem, bytes.Length);
        Marshal.WriteByte(mem, bytes.Length, 0);
        var str = objc_msgSend_IntPtr(CLASS("NSString"), SEL("stringWithUTF8String:"), mem);
        Marshal.FreeHGlobal(mem);
        return str;
    }

    [DllImport("/System/Library/Frameworks/AppKit.framework/AppKit")]
    static extern void NSApplicationLoad();

    [StructLayout(LayoutKind.Sequential)]
    struct NSRect
    {
        public double x;
        public double y;
        public double width;
        public double height;
    }

    static NSRect GetWindowFrame(IntPtr window)
    {
        IntPtr framePtr = objc_msgSend(window, SEL("frame"));
        return Marshal.PtrToStructure<NSRect>(framePtr);
    }

    [DllImport("/usr/lib/libSystem.B.dylib")]
    static extern IntPtr dlsym(IntPtr handle, string symbol);
    [DllImport("/usr/lib/libSystem.B.dylib")]
    static extern IntPtr dlopen(string path, int mode);
    const int RTLD_DEFAULT = 0;

    static IntPtr openGLHandle = IntPtr.Zero;

    static IntPtr GetProcAddress(string name)
    {
        if (openGLHandle == IntPtr.Zero)
        {
            openGLHandle = dlopen("/System/Library/Frameworks/OpenGL.framework/OpenGL", 0);
            if (openGLHandle == IntPtr.Zero)
            {
                Console.WriteLine("❌ No se pudo abrir la librería OpenGL");
                return IntPtr.Zero;
            }
        }
        return dlsym(openGLHandle, name);
    }

    // --- TriangleRenderer para renderizar un triángulo blanco ---
    class TriangleRenderer
    {
        private uint vao, vbo, shaderProgram;
        private float width, height;
        private float[] vertices = {
            // posiciones
            -0.5f, -0.5f, 0.0f,
             0.5f, -0.5f, 0.0f,
             0.0f,  0.5f, 0.0f
        };
        private string vertexShaderSource = @"
#version 150 core
in vec3 aPos;
void main() {
    gl_Position = vec4(aPos, 1.0);
}
";
        private string fragmentShaderSource = @"
#version 150 core
out vec4 FragColor;
void main() {
    FragColor = vec4(1.0, 1.0, 1.0, 1.0);
}
";

        public TriangleRenderer(float w, float h) { width = w; height = h; }

        public void Initialize()
        {
            vao = Gl.GenVertexArray();
            vbo = Gl.GenBuffer();
            Gl.GlBindVertexArray(vao);
            Gl.GlBindBuffer(BufferTarget.ArrayBuffer, vbo);
            GCHandle vHandle = GCHandle.Alloc(vertices, GCHandleType.Pinned);
            Gl.GlBufferData(BufferTarget.ArrayBuffer, vertices.Length * sizeof(float), vHandle.AddrOfPinnedObject(), BufferUsageHint.StaticDraw);
            vHandle.Free();
            uint vertexShader = Gl.GlCreateShader(ShaderType.VertexShader);
            Gl.ShaderSource(vertexShader, vertexShaderSource);
            Gl.GlCompileShader(vertexShader);
            if (!Gl.GetShaderCompileStatus(vertexShader))
                Console.WriteLine("Vertex shader error: " + Gl.GetShaderInfoLog(vertexShader));
            uint fragmentShader = Gl.GlCreateShader(ShaderType.FragmentShader);
            Gl.ShaderSource(fragmentShader, fragmentShaderSource);
            Gl.GlCompileShader(fragmentShader);
            if (!Gl.GetShaderCompileStatus(fragmentShader))
                Console.WriteLine("Fragment shader error: " + Gl.GetShaderInfoLog(fragmentShader));
            shaderProgram = Gl.GlCreateProgram();
            Gl.GlAttachShader(shaderProgram, vertexShader);
            Gl.GlAttachShader(shaderProgram, fragmentShader);
            Gl.GlLinkProgram(shaderProgram);
            if (!Gl.GetProgramLinkStatus(shaderProgram))
                Console.WriteLine("Program link error: " + Gl.GetProgramInfoLog(shaderProgram));
            Gl.GlDeleteShader(vertexShader);
            Gl.GlDeleteShader(fragmentShader);
            Gl.GlBindVertexArray(vao);
            Gl.GlUseProgram(shaderProgram);
            Gl.EnableVertexAttribArray(0);
            Gl.VertexAttribPointer(0, 3, VertexAttribPointerType.Float, false, 3 * sizeof(float), IntPtr.Zero);
        }

        public void Draw()
        {
            Gl.GlBindVertexArray(vao);
            Gl.GlUseProgram(shaderProgram);
            Gl.GlDrawArrays(PrimitiveType.Triangles, 0, 3);
        }

        public void Cleanup()
        {
            Gl.DeleteVertexArray(vao);
            Gl.DeleteBuffer(vbo);
            Gl.GlDeleteProgram(shaderProgram);
        }
    }

    static void Main()
    {
        NSApplicationLoad(); // Fuerza la carga de AppKit
        var pool = objc_msgSend(CLASS("NSAutoreleasePool"), SEL("new"));
        if (pool == IntPtr.Zero)
        {
            Console.WriteLine("❌ NSAutoreleasePool no se creó");
            return;
        }

        IntPtr nsWindowClass = CLASS("NSWindow");
        if (nsWindowClass == IntPtr.Zero)
        {
            Console.WriteLine("❌ NSWindow class no encontrada");
            objc_msgSend_void(pool, SEL("release"));
            return;
        }

        IntPtr app = objc_msgSend(CLASS("NSApplication"), SEL("sharedApplication"));
        if (app == IntPtr.Zero)
        {
            Console.WriteLine("❌ NSApplication no se creó");
            objc_msgSend_void(pool, SEL("release"));
            return;
        }
        objc_msgSend_void_Long(app, SEL("setActivationPolicy:"), NSApplicationActivationPolicyRegular);
        objc_msgSend_void_Bool(app, SEL("activateIgnoringOtherApps:"), true);
        objc_msgSend_void(app, SEL("finishLaunching")); // <-- Asegura que la app está lanzada

        // Crear NSWindow correctamente
        IntPtr window = objc_msgSend(CLASS("NSWindow"), SEL("alloc"));
        if (window == IntPtr.Zero)
        {
            Console.WriteLine("❌ NSWindow alloc falló");
            objc_msgSend_void(pool, SEL("release"));
            return;
        }
        window = objc_msgSend_NSRect_UL_UL_Bool(
            window, SEL("initWithContentRect:styleMask:backing:defer:"),
            100.0, 100.0, 800.0, 600.0,
            NSWindowStyleMaskTitled | NSWindowStyleMaskClosable | NSWindowStyleMaskMiniaturizable | NSWindowStyleMaskResizable,
            NSBackingStoreBuffered, false);

        if (window == IntPtr.Zero)
        {
            Console.WriteLine("❌ NSWindow no se creó (problema ABI ARM64)");
            Console.WriteLine($"Parámetros: x=100, y=100, w=800, h=600, styleMask={NSWindowStyleMaskTitled | NSWindowStyleMaskClosable | NSWindowStyleMaskMiniaturizable | NSWindowStyleMaskResizable}, backing={NSBackingStoreBuffered}, defer=false");
            // Prueba de ventana básica Cocoa sin OpenGL
            IntPtr simpleWindow = objc_msgSend(CLASS("NSWindow"), SEL("alloc"));
            simpleWindow = objc_msgSend_NSRect_UL_UL_Bool(
                simpleWindow, SEL("initWithContentRect:styleMask:backing:defer:"),
                200.0, 200.0, 400.0, 300.0,
                NSWindowStyleMaskTitled,
                NSBackingStoreBuffered, false);
            if (simpleWindow == IntPtr.Zero)
            {
                Console.WriteLine("❌ Prueba de ventana básica Cocoa también falló");
            }
            else
            {
                objc_msgSend_void_IntPtr(simpleWindow, SEL("setTitle:"), NSString("Ventana Cocoa básica"));
                objc_msgSend_void_IntPtr(simpleWindow, SEL("makeKeyAndOrderFront:"), IntPtr.Zero);
                Console.WriteLine("✅ Ventana básica Cocoa creada correctamente");
                objc_msgSend_void(app, SEL("run"));
            }
            objc_msgSend_void(pool, SEL("release"));
            return;
        }

        objc_msgSend_void_IntPtr(window, SEL("setTitle:"), NSString("C# + Cocoa + OpenGL (Apple Silicon)"));
        objc_msgSend_void(window, SEL("center")); // Centra la ventana en pantalla

        // PixelFormat
        int[] attrs = {
            NSOpenGLPFAOpenGLProfile, NSOpenGLProfileVersion3_2Core,
            NSOpenGLPFADoubleBuffer,
            NSOpenGLPFAColorSize, 24,
            NSOpenGLPFADepthSize, 24,
            0
        };
        IntPtr fmt = objc_msgSend(CLASS("NSOpenGLPixelFormat"), SEL("alloc"));
        GCHandle pin = GCHandle.Alloc(attrs, GCHandleType.Pinned);
        try
        {
            fmt = objc_msgSend_IntPtr(fmt, SEL("initWithAttributes:"), pin.AddrOfPinnedObject());
        }
        finally { pin.Free(); }
        if (fmt == IntPtr.Zero) {
            Console.WriteLine("❌ PixelFormat fail");
            objc_msgSend_void(pool, SEL("release"));
            return;
        }

        IntPtr view = objc_msgSend(CLASS("NSOpenGLView"), SEL("alloc"));
        if (view == IntPtr.Zero)
        {
            Console.WriteLine("❌ NSOpenGLView fail");
            objc_msgSend_void(pool, SEL("release"));
            return;
        }

        // Obtener el frame de la ventana
        NSRect windowFrame = GetWindowFrame(window);

        // Inicializar el NSOpenGLView con el frame de la ventana
        view = objc_msgSend(CLASS("NSOpenGLView"), SEL("alloc"));
        view = objc_msgSend_NSRect_IntPtr(view, SEL("initWithFrame:pixelFormat:"),
            windowFrame.x, windowFrame.y, windowFrame.width, windowFrame.height, fmt);

        objc_msgSend_void_IntPtr(window, SEL("setContentView:"), view);
        objc_msgSend_void_IntPtr(window, SEL("makeKeyAndOrderFront:"), IntPtr.Zero);

        IntPtr ctx = objc_msgSend(view, SEL("openGLContext"));
        if (ctx == IntPtr.Zero)
        {
            Console.WriteLine("❌ openGLContext fail");
            objc_msgSend_void(pool, SEL("release"));
            return;
        }
        objc_msgSend_void(ctx, SEL("makeCurrentContext"));

        IntPtr distantPast = objc_msgSend(CLASS("NSDate"), SEL("distantPast"));
        IntPtr runLoopMode = CFStringCreateWithCString(IntPtr.Zero, "kCFRunLoopDefaultMode", kCFStringEncodingUTF8);

        // Inicializar Gl con el delegado correcto
        Gl.Initialize(GetProcAddress);
        // Ajustar el viewport al tamaño de la ventana
        Gl.GlViewport(0, 0, (int)windowFrame.width, (int)windowFrame.height);
        // Habilitar el test de profundidad para 3D
        Gl.GlEnable(EnableCap.DepthTest);
        Gl.GlClearColor(0.2f, 0.3f, 0.3f, 1.0f);
        TriangleRenderer triangle = new TriangleRenderer((float)windowFrame.width, (float)windowFrame.height);
        triangle.Initialize();
        bool running = true;
        while (running)
        {
            IntPtr evt = objc_msgSend_UL_IntPtr_IntPtr_Bool(app,
                SEL("nextEventMatchingMask:untilDate:inMode:dequeue:"),
                ulong.MaxValue, distantPast, runLoopMode, true);
            if (evt != IntPtr.Zero)
            {
                ulong evtType = GetEventType(evt);
                if (evtType == NSKeyDown)
                {
                    string chars = GetCharacters(evt);
                    Console.WriteLine($"Tecla pulsada: {chars}");
                }
                objc_msgSend_void_IntPtr(app, SEL("sendEvent:"), evt);
                objc_msgSend_void(app, SEL("updateWindows"));
            }
            if (!IsWindowVisible(window))
            {
                Console.WriteLine("Ventana cerrada, saliendo...");
                running = false;
                break;
            }
            // Limpiar color y profundidad
            Gl.GlClear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
            triangle.Draw();
            objc_msgSend_void(ctx, SEL("flushBuffer"));
            // Comprobación de errores de OpenGL tras el swap
            var glError = Gl.GlGetError();
            if (glError != 0)
            {
                Console.WriteLine($"OpenGL error tras flushBuffer: 0x{glError:X}");
            }
            System.Threading.Thread.Sleep(10);
        }
        triangle.Cleanup();
        objc_msgSend_void(pool, SEL("release"));
    }

    // Constantes para tipos de evento NSEvent
    const ulong NSKeyDown = 10;
    const ulong NSKeyUp = 11;
    const ulong NSAppKitDefined = 13;
    const ulong NSWindowWillClose = 22; // No existe como tipo, pero se puede detectar por selector

    static ulong GetEventType(IntPtr evt)
    {
        return (ulong)objc_msgSend(evt, SEL("type"));
    }

    static string GetCharacters(IntPtr evt)
    {
        IntPtr strPtr = objc_msgSend(evt, SEL("characters"));
        if (strPtr == IntPtr.Zero) return "";
        int len = (int)objc_msgSend(strPtr, SEL("length"));
        if (len == 0) return "";
        var buffer = new byte[len];
        Marshal.Copy(objc_msgSend(strPtr, SEL("UTF8String")), buffer, 0, len);
        return Encoding.UTF8.GetString(buffer);
    }

    static bool IsWindowVisible(IntPtr window)
    {
        return objc_msgSend(window, SEL("isVisible")) != IntPtr.Zero;
    }
}
