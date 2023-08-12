using System;
using System.Runtime.InteropServices;

namespace Alis.Core.Graphic.Backends.OpenGL.EGL
{
    /// <summary>
    /// The egl native class
    /// </summary>
    internal static unsafe class EGLNative
    {
        /// <summary>
        /// The lib name
        /// </summary>
        private const string LibName = "libEGL.so";

        /// <summary>
        /// The egl draw
        /// </summary>
        public const int EGL_DRAW = 0x3059;
        /// <summary>
        /// The egl read
        /// </summary>
        public const int EGL_READ = 0x305A;
        /// <summary>
        /// The egl red size
        /// </summary>
        public const int EGL_RED_SIZE = 0x3024;
        /// <summary>
        /// The egl green size
        /// </summary>
        public const int EGL_GREEN_SIZE = 0x3023;
        /// <summary>
        /// The egl blue size
        /// </summary>
        public const int EGL_BLUE_SIZE = 0x3022;
        /// <summary>
        /// The egl alpha size
        /// </summary>
        public const int EGL_ALPHA_SIZE = 0x3021;
        /// <summary>
        /// The egl depth size
        /// </summary>
        public const int EGL_DEPTH_SIZE = 0x3025;
        /// <summary>
        /// The egl surface type
        /// </summary>
        public const int EGL_SURFACE_TYPE = 0x3033;
        /// <summary>
        /// The egl window bit
        /// </summary>
        public const int EGL_WINDOW_BIT = 0x0004;
        /// <summary>
        /// The egl opengl es bit
        /// </summary>
        public const int EGL_OPENGL_ES_BIT = 0x0001;
        /// <summary>
        /// The egl opengl es2 bit
        /// </summary>
        public const int EGL_OPENGL_ES2_BIT = 0x0004;
        /// <summary>
        /// The egl opengl es3 bit
        /// </summary>
        public const int EGL_OPENGL_ES3_BIT = 0x00000040;
        /// <summary>
        /// The egl renderable type
        /// </summary>
        public const int EGL_RENDERABLE_TYPE = 0x3040;
        /// <summary>
        /// The egl none
        /// </summary>
        public const int EGL_NONE = 0x3038;
        /// <summary>
        /// The egl native visual id
        /// </summary>
        public const int EGL_NATIVE_VISUAL_ID = 0x302E;
        /// <summary>
        /// The egl context client version
        /// </summary>
        public const int EGL_CONTEXT_CLIENT_VERSION = 0x3098;

        /// <summary>
        /// Egls the get error
        /// </summary>
        /// <returns>The egl error</returns>
        [DllImport(LibName)]
        public static extern EGLError eglGetError();
        /// <summary>
        /// Egls the get current context
        /// </summary>
        /// <returns>The int ptr</returns>
        [DllImport(LibName)]
        public static extern IntPtr eglGetCurrentContext();
        /// <summary>
        /// Egls the destroy context using the specified display
        /// </summary>
        /// <param name="display">The display</param>
        /// <param name="context">The context</param>
        /// <returns>The int</returns>
        [DllImport(LibName)]
        public static extern int eglDestroyContext(IntPtr display, IntPtr context);
        /// <summary>
        /// Egls the make current using the specified display
        /// </summary>
        /// <param name="display">The display</param>
        /// <param name="draw">The draw</param>
        /// <param name="read">The read</param>
        /// <param name="context">The context</param>
        /// <returns>The int</returns>
        [DllImport(LibName)]
        public static extern int eglMakeCurrent(IntPtr display, IntPtr draw, IntPtr read, IntPtr context);
        /// <summary>
        /// Egls the choose config using the specified display
        /// </summary>
        /// <param name="display">The display</param>
        /// <param name="attrib_list">The attrib list</param>
        /// <param name="configs">The configs</param>
        /// <param name="config_size">The config size</param>
        /// <param name="num_config">The num config</param>
        /// <returns>The int</returns>
        [DllImport(LibName)]
        public static extern int eglChooseConfig(IntPtr display, int* attrib_list, IntPtr* configs, int config_size, int* num_config);
        /// <summary>
        /// Egls the get proc address using the specified name
        /// </summary>
        /// <param name="name">The name</param>
        /// <returns>The int ptr</returns>
        [DllImport(LibName)]
        public static extern IntPtr eglGetProcAddress(string name);
        /// <summary>
        /// Egls the get current display
        /// </summary>
        /// <returns>The int ptr</returns>
        [DllImport(LibName)]
        public static extern IntPtr eglGetCurrentDisplay();
        /// <summary>
        /// Egls the get display using the specified native display
        /// </summary>
        /// <param name="native_display">The native display</param>
        /// <returns>The int ptr</returns>
        [DllImport(LibName)]
        public static extern IntPtr eglGetDisplay(int native_display);
        /// <summary>
        /// Egls the get current surface using the specified readdraw
        /// </summary>
        /// <param name="readdraw">The readdraw</param>
        /// <returns>The int ptr</returns>
        [DllImport(LibName)]
        public static extern IntPtr eglGetCurrentSurface(int readdraw);
        /// <summary>
        /// Egls the initialize using the specified display
        /// </summary>
        /// <param name="display">The display</param>
        /// <param name="major">The major</param>
        /// <param name="minor">The minor</param>
        /// <returns>The int</returns>
        [DllImport(LibName)]
        public static extern int eglInitialize(IntPtr display, int* major, int* minor);
        /// <summary>
        /// Egls the create window surface using the specified display
        /// </summary>
        /// <param name="display">The display</param>
        /// <param name="config">The config</param>
        /// <param name="native_window">The native window</param>
        /// <param name="attrib_list">The attrib list</param>
        /// <returns>The int ptr</returns>
        [DllImport(LibName)]
        public static extern IntPtr eglCreateWindowSurface(
            IntPtr display,
            IntPtr config,
            IntPtr native_window,
            int* attrib_list);
        /// <summary>
        /// Egls the create context using the specified display
        /// </summary>
        /// <param name="display">The display</param>
        /// <param name="config">The config</param>
        /// <param name="share_context">The share context</param>
        /// <param name="attrib_list">The attrib list</param>
        /// <returns>The int ptr</returns>
        [DllImport(LibName)]
        public static extern IntPtr eglCreateContext(IntPtr display,
            IntPtr config,
            IntPtr share_context,
            int* attrib_list);
        /// <summary>
        /// Egls the swap buffers using the specified display
        /// </summary>
        /// <param name="display">The display</param>
        /// <param name="surface">The surface</param>
        /// <returns>The int</returns>
        [DllImport(LibName)]
        public static extern int eglSwapBuffers(IntPtr display, IntPtr surface);
        /// <summary>
        /// Egls the swap interval using the specified display
        /// </summary>
        /// <param name="display">The display</param>
        /// <param name="value">The value</param>
        /// <returns>The int</returns>
        [DllImport(LibName)]
        public static extern int eglSwapInterval(IntPtr display, int value);
        /// <summary>
        /// Egls the get config attrib using the specified display
        /// </summary>
        /// <param name="display">The display</param>
        /// <param name="config">The config</param>
        /// <param name="attribute">The attribute</param>
        /// <param name="value">The value</param>
        /// <returns>The int</returns>
        [DllImport(LibName)]
        public static extern int eglGetConfigAttrib(IntPtr display, IntPtr config, int attribute, int* value);
    }

    /// <summary>
    /// The egl error enum
    /// </summary>
    internal enum EGLError
    {
        /// <summary>
        /// The success egl error
        /// </summary>
        Success = 0x3000,
        /// <summary>
        /// The not initialized egl error
        /// </summary>
        NotInitialized = 0x3001,
        /// <summary>
        /// The bad access egl error
        /// </summary>
        BadAccess = 0x3002,
        /// <summary>
        /// The bad alloc egl error
        /// </summary>
        BadAlloc = 0x3003,
        /// <summary>
        /// The bad attribute egl error
        /// </summary>
        BadAttribute = 0x3004,
        /// <summary>
        /// The bad config egl error
        /// </summary>
        BadConfig = 0x3005,
        /// <summary>
        /// The bad context egl error
        /// </summary>
        BadContext = 0x3006,
        /// <summary>
        /// The bad current surface egl error
        /// </summary>
        BadCurrentSurface = 0x3007,
        /// <summary>
        /// The bad display egl error
        /// </summary>
        BadDisplay = 0x3008,
        /// <summary>
        /// The bad match egl error
        /// </summary>
        BadMatch = 0x3009,
        /// <summary>
        /// The bad native pixmap egl error
        /// </summary>
        BadNativePixmap = 0x300A,
        /// <summary>
        /// The bad native window egl error
        /// </summary>
        BadNativeWindow = 0x300B,
        /// <summary>
        /// The bad parameter egl error
        /// </summary>
        BadParameter = 0x300C,
        /// <summary>
        /// The bad surface egl error
        /// </summary>
        BadSurface = 0x300D,
        /// <summary>
        /// The context lost egl error
        /// </summary>
        ContextLost = 0x300E,
    }
}