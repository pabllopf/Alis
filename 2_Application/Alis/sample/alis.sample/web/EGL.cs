using System;
using System.Runtime.InteropServices;

namespace Alis.Sample.Web
{
    /// <summary>
    /// The egl class
    /// </summary>
    internal static class EGL
    {
        /// <summary>
        /// The lib egl
        /// </summary>
        public const string LibEgl = "libEGL";
        /// <summary>
        /// The egl none
        /// </summary>
        public const int EGL_NONE = 0x3038;
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
        /// The egl depth size
        /// </summary>
        public const int EGL_DEPTH_SIZE = 0x3025;
        /// <summary>
        /// The egl stencil size
        /// </summary>
        public const int EGL_STENCIL_SIZE = 0x3026;
        /// <summary>
        /// The egl surface type
        /// </summary>
        public const int EGL_SURFACE_TYPE = 0x3033;
        /// <summary>
        /// The egl renderable type
        /// </summary>
        public const int EGL_RENDERABLE_TYPE = 0x3040;
        /// <summary>
        /// The egl samples
        /// </summary>
        public const int EGL_SAMPLES = 0x3031;
        /// <summary>
        /// The egl window bit
        /// </summary>
        public const int EGL_WINDOW_BIT = 0x0004;
        /// <summary>
        /// The egl opengl es2 bit
        /// </summary>
        public const int EGL_OPENGL_ES2_BIT = 0x0004;
        /// <summary>
        /// The egl opengl es3 bit
        /// </summary>
        public const int EGL_OPENGL_ES3_BIT = 0x00000040;
        /// <summary>
        /// The egl context client version
        /// </summary>
        public const int EGL_CONTEXT_CLIENT_VERSION = 0x3098;
        /// <summary>
        /// The egl no context
        /// </summary>
        public const int EGL_NO_CONTEXT = 0x0;
        /// <summary>
        /// The egl native visual id
        /// </summary>
        public const int EGL_NATIVE_VISUAL_ID = 0x302E;
        /// <summary>
        /// The egl opengl es api
        /// </summary>
        public const int EGL_OPENGL_ES_API = 0x30A0;

        /// <summary>
        /// Gets the proc address using the specified proc
        /// </summary>
        /// <param name="proc">The proc</param>
        /// <returns>The int ptr</returns>
        [DllImport(LibEgl, EntryPoint = "eglGetProcAddress", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        [DefaultDllImportSearchPaths(DllImportSearchPath.SafeDirectories)]
        public static extern IntPtr GetProcAddress(string proc);

        /// <summary>
        /// Gets the display using the specified display id
        /// </summary>
        /// <param name="displayId">The display id</param>
        /// <returns>The int ptr</returns>
        [DllImport(LibEgl, EntryPoint = "eglGetDisplay", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        [DefaultDllImportSearchPaths(DllImportSearchPath.SafeDirectories)]
        public static extern IntPtr GetDisplay(IntPtr displayId);

        /// <summary>
        /// Initializes the display
        /// </summary>
        /// <param name="display">The display</param>
        /// <param name="major">The major</param>
        /// <param name="minor">The minor</param>
        /// <returns>The bool</returns>
        [DllImport(LibEgl, EntryPoint = "eglInitialize", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        [DefaultDllImportSearchPaths(DllImportSearchPath.SafeDirectories)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool Initialize(IntPtr display, out int major, out int minor);


        /// <summary>
        /// Chooses the config using the specified dpy
        /// </summary>
        /// <param name="dpy">The dpy</param>
        /// <param name="attribList">The attrib list</param>
        /// <param name="configs">The configs</param>
        /// <param name="configSize">The config size</param>
        /// <param name="numConfig">The num config</param>
        /// <returns>The bool</returns>
        [DllImport(LibEgl, EntryPoint = "eglChooseConfig", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        [DefaultDllImportSearchPaths(DllImportSearchPath.SafeDirectories)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool ChooseConfig(IntPtr dpy, int[] attribList, ref IntPtr configs, IntPtr configSize/*fixed to 1*/, ref IntPtr numConfig);

        /// <summary>
        /// Binds the api using the specified api
        /// </summary>
        /// <param name="api">The api</param>
        /// <returns>The bool</returns>
        [DllImport(LibEgl, EntryPoint = "eglBindAPI", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        [DefaultDllImportSearchPaths(DllImportSearchPath.SafeDirectories)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool BindApi(int api);

        /// <summary>
        /// Creates the context using the specified display
        /// </summary>
        /// <param name="display">The display</param>
        /// <param name="config">The config</param>
        /// <param name="shareContext">The share context</param>
        /// <param name="attribList">The attrib list</param>
        /// <returns>The int ptr</returns>
        [DllImport(LibEgl, EntryPoint = "eglCreateContext", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        [DefaultDllImportSearchPaths(DllImportSearchPath.SafeDirectories)]
        public static extern IntPtr CreateContext(IntPtr/*EGLDisplay*/ display, IntPtr/*EGLConfig*/ config, IntPtr shareContext, int[] attribList);

        /// <summary>
        /// Gets the config attrib using the specified display
        /// </summary>
        /// <param name="display">The display</param>
        /// <param name="config">The config</param>
        /// <param name="attribute">The attribute</param>
        /// <param name="value">The value</param>
        /// <returns>The bool</returns>
        [DllImport(LibEgl, EntryPoint = "eglGetConfigAttrib", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        [DefaultDllImportSearchPaths(DllImportSearchPath.SafeDirectories)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool GetConfigAttrib(IntPtr/*EGLDisplay*/ display, IntPtr/*EGLConfig*/ config, IntPtr attribute, ref IntPtr value);

        /// <summary>
        /// Creates the window surface using the specified display
        /// </summary>
        /// <param name="display">The display</param>
        /// <param name="config">The config</param>
        /// <param name="win">The win</param>
        /// <param name="attribList">The attrib list</param>
        /// <returns>The int ptr</returns>
        [DllImport(LibEgl, EntryPoint = "eglCreateWindowSurface", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        [DefaultDllImportSearchPaths(DllImportSearchPath.SafeDirectories)]
        public static extern IntPtr CreateWindowSurface(IntPtr display, IntPtr config, IntPtr win, IntPtr attribList/*fixed to NULL*/);

        /// <summary>
        /// Destroys the surface using the specified display
        /// </summary>
        /// <param name="display">The display</param>
        /// <param name="surface">The surface</param>
        /// <returns>The int</returns>
        [DllImport(LibEgl, EntryPoint = "eglDestroySurface", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        [DefaultDllImportSearchPaths(DllImportSearchPath.SafeDirectories)]
        public static extern int DestroySurface(IntPtr display, IntPtr surface);

        /// <summary>
        /// Destroys the context using the specified display
        /// </summary>
        /// <param name="display">The display</param>
        /// <param name="ctx">The ctx</param>
        /// <returns>The int</returns>
        [DllImport(LibEgl, EntryPoint = "eglDestroyContext", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        [DefaultDllImportSearchPaths(DllImportSearchPath.SafeDirectories)]
        public static extern int DestroyContext(IntPtr display, IntPtr ctx);

        /// <summary>
        /// Makes the current using the specified display
        /// </summary>
        /// <param name="display">The display</param>
        /// <param name="draw">The draw</param>
        /// <param name="read">The read</param>
        /// <param name="ctx">The ctx</param>
        /// <returns>The bool</returns>
        [DllImport(LibEgl, EntryPoint = "eglMakeCurrent", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        [DefaultDllImportSearchPaths(DllImportSearchPath.SafeDirectories)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool MakeCurrent(IntPtr display, IntPtr draw, IntPtr read, IntPtr ctx);

        /// <summary>
        /// Terminates the display
        /// </summary>
        /// <param name="display">The display</param>
        /// <returns>The int</returns>
        [DllImport(LibEgl, EntryPoint = "eglTerminate", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        [DefaultDllImportSearchPaths(DllImportSearchPath.SafeDirectories)]
        public static extern int Terminate(IntPtr display);

        /// <summary>
        /// Swaps the buffers using the specified display
        /// </summary>
        /// <param name="display">The display</param>
        /// <param name="surface">The surface</param>
        /// <returns>The int</returns>
        [DllImport(LibEgl, EntryPoint = "eglSwapBuffers", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        [DefaultDllImportSearchPaths(DllImportSearchPath.SafeDirectories)]
        public static extern int SwapBuffers(IntPtr display, IntPtr surface);

        /// <summary>
        /// Swaps the interval using the specified display
        /// </summary>
        /// <param name="display">The display</param>
        /// <param name="interval">The interval</param>
        /// <returns>The int</returns>
        [DllImport(LibEgl, EntryPoint = "eglSwapInterval", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        [DefaultDllImportSearchPaths(DllImportSearchPath.SafeDirectories)]
        public static extern int SwapInterval(IntPtr display, int interval);
    }
}
