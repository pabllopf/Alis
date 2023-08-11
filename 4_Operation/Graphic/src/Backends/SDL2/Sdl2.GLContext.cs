using System;
using System.Runtime.InteropServices;

namespace Veldrid.Sdl2
{
    /// <summary>
    /// The sdl native class
    /// </summary>
    public static unsafe partial class Sdl2Native
    {
        /// <summary>
        /// The sdl gl createcontext
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate IntPtr SDL_GL_CreateContext_t(SDL_Window SDL2Window);
        /// <summary>
        /// The sdl gl createcontext
        /// </summary>
        private static SDL_GL_CreateContext_t s_gl_createContext = LoadFunction<SDL_GL_CreateContext_t>("SDL_GL_CreateContext");
        /// <summary>
        /// Sdls the gl create context using the specified sdl 2 window
        /// </summary>
        /// <param name="Sdl2Window">The sdl window</param>
        /// <returns>The int ptr</returns>
        public static IntPtr SDL_GL_CreateContext(SDL_Window Sdl2Window) => s_gl_createContext(Sdl2Window);

        /// <summary>
        /// The sdl gl getprocaddress
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate IntPtr SDL_GL_GetProcAddress_t(string proc);
        /// <summary>
        /// The sdl gl getprocaddress
        /// </summary>
        private static SDL_GL_GetProcAddress_t s_getProcAddress = LoadFunction<SDL_GL_GetProcAddress_t>("SDL_GL_GetProcAddress");
        /// <summary>
        /// Sdls the gl get proc address using the specified proc
        /// </summary>
        /// <param name="proc">The proc</param>
        /// <returns>The int ptr</returns>
        public static IntPtr SDL_GL_GetProcAddress(string proc)
        {
            return s_getProcAddress(proc);
        }

        /// <summary>
        /// The sdl gl getcurrentcontext
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate IntPtr SDL_GL_GetCurrentContext_t();
        /// <summary>
        /// The sdl gl getcurrentcontext
        /// </summary>
        private static SDL_GL_GetCurrentContext_t s_gl_getCurrentContext = LoadFunction<SDL_GL_GetCurrentContext_t>("SDL_GL_GetCurrentContext");
        /// <summary>
        /// Sdls the gl get current context
        /// </summary>
        /// <returns>The ret</returns>
        public static IntPtr SDL_GL_GetCurrentContext()
        {
            var ret = s_gl_getCurrentContext();
            return ret;
        }

        /// <summary>
        /// The sdl gl swapwindow
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void SDL_GL_SwapWindow_t(SDL_Window SDL2Window);
        /// <summary>
        /// The sdl gl swapwindow
        /// </summary>
        private static SDL_GL_SwapWindow_t s_gl_swapWindow = LoadFunction<SDL_GL_SwapWindow_t>("SDL_GL_SwapWindow");
        /// <summary>
        /// Sdls the gl swap window using the specified sdl 2 window
        /// </summary>
        /// <param name="Sdl2Window">The sdl window</param>
        public static void SDL_GL_SwapWindow(SDL_Window Sdl2Window) => s_gl_swapWindow(Sdl2Window);

        /// <summary>
        /// The sdl gl setattribute
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate int SDL_GL_SetAttribute_t(SDL_GLAttribute attr, int value);
        /// <summary>
        /// The sdl gl setattribute
        /// </summary>
        private static SDL_GL_SetAttribute_t s_gl_setAttribute = LoadFunction<SDL_GL_SetAttribute_t>("SDL_GL_SetAttribute");
        /// <summary>
        /// Sdls the gl set attribute using the specified attr
        /// </summary>
        /// <param name="attr">The attr</param>
        /// <param name="value">The value</param>
        /// <returns>The int</returns>
        public static int SDL_GL_SetAttribute(SDL_GLAttribute attr, int value) => s_gl_setAttribute(attr, value);

        /// <summary>
        /// The sdl gl getattribute
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate int SDL_GL_GetAttribute_t(SDL_GLAttribute attr, int* value);
        /// <summary>
        /// The sdl gl getattribute
        /// </summary>
        private static SDL_GL_GetAttribute_t s_gl_getAttribute = LoadFunction<SDL_GL_GetAttribute_t>("SDL_GL_GetAttribute");
        /// <summary>
        /// Sdls the gl get attribute using the specified attr
        /// </summary>
        /// <param name="attr">The attr</param>
        /// <param name="value">The value</param>
        /// <returns>The int</returns>
        public static int SDL_GL_GetAttribute(SDL_GLAttribute attr, int* value) => s_gl_getAttribute(attr, value);

        /// <summary>
        /// The sdl gl makecurrent
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate int SDL_GL_MakeCurrent_t(SDL_Window SDL2Window, IntPtr context);
        /// <summary>
        /// The sdl gl makecurrent
        /// </summary>
        private static SDL_GL_MakeCurrent_t s_gl_makeCurrent = LoadFunction<SDL_GL_MakeCurrent_t>("SDL_GL_MakeCurrent");
        /// <summary>
        /// Sdls the gl make current using the specified sdl 2 window
        /// </summary>
        /// <param name="Sdl2Window">The sdl window</param>
        /// <param name="context">The context</param>
        /// <returns>The int</returns>
        public static int SDL_GL_MakeCurrent(SDL_Window Sdl2Window, IntPtr context) => s_gl_makeCurrent(Sdl2Window, context);

        /// <summary>
        /// The sdl gl setswapinterval
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate int SDL_GL_SetSwapInterval_t(int interval);
        /// <summary>
        /// The sdl gl setswapinterval
        /// </summary>
        private static SDL_GL_SetSwapInterval_t s_gl_setSwapInterval = LoadFunction<SDL_GL_SetSwapInterval_t>("SDL_GL_SetSwapInterval");
        /// <summary>
        /// Sdls the gl set swap interval using the specified interval
        /// </summary>
        /// <param name="interval">The interval</param>
        /// <returns>The int</returns>
        public static int SDL_GL_SetSwapInterval(int interval) => s_gl_setSwapInterval(interval);

        /// <summary>
        /// The sdl gl deletecontext
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void SDL_GL_DeleteContext_t(IntPtr context);
        /// <summary>
        /// The sdl gl deletecontext
        /// </summary>
        private static SDL_GL_DeleteContext_t s_gl_deleteContext = LoadFunction<SDL_GL_DeleteContext_t>("SDL_GL_DeleteContext");
        /// <summary>
        /// Sdls the gl delete context using the specified context
        /// </summary>
        /// <param name="context">The context</param>
        public static void SDL_GL_DeleteContext(IntPtr context) => s_gl_deleteContext(context);
    }

    /// <summary>
    /// The sdl glattribute enum
    /// </summary>
    public enum SDL_GLAttribute
    {
        /// <summary>
        /// The red size sdl glattribute
        /// </summary>
        RedSize,
        /// <summary>
        /// The green size sdl glattribute
        /// </summary>
        GreenSize,
        /// <summary>
        /// The blue size sdl glattribute
        /// </summary>
        BlueSize,
        /// <summary>
        /// The alpha size sdl glattribute
        /// </summary>
        AlphaSize,
        /// <summary>
        /// The buffer size sdl glattribute
        /// </summary>
        BufferSize,
        /// <summary>
        /// The double buffer sdl glattribute
        /// </summary>
        DoubleBuffer,
        /// <summary>
        /// The depth size sdl glattribute
        /// </summary>
        DepthSize,
        /// <summary>
        /// The stencil size sdl glattribute
        /// </summary>
        StencilSize,
        /// <summary>
        /// The accumulation red size sdl glattribute
        /// </summary>
        AccumulationRedSize,
        /// <summary>
        /// The accumulation green size sdl glattribute
        /// </summary>
        AccumulationGreenSize,
        /// <summary>
        /// The accumulation blue size sdl glattribute
        /// </summary>
        AccumulationBlueSize,
        /// <summary>
        /// The accumulation alpha size sdl glattribute
        /// </summary>
        AccumulationAlphaSize,
        /// <summary>
        /// The gl stereo sdl glattribute
        /// </summary>
        GLStereo,
        /// <summary>
        /// The multisample buffers sdl glattribute
        /// </summary>
        MultisampleBuffers,
        /// <summary>
        /// The multisample samples sdl glattribute
        /// </summary>
        MultisampleSamples,
        /// <summary>
        /// The accelerated visual sdl glattribute
        /// </summary>
        AcceleratedVisual,
        /// <summary>
        /// The retained backing sdl glattribute
        /// </summary>
        RetainedBacking,
        /// <summary>
        /// The context major version sdl glattribute
        /// </summary>
        ContextMajorVersion,
        /// <summary>
        /// The context minor version sdl glattribute
        /// </summary>
        ContextMinorVersion,
        /// <summary>
        /// The context egl sdl glattribute
        /// </summary>
        ContextEgl,
        /// <summary>
        /// The context flags sdl glattribute
        /// </summary>
        ContextFlags,
        /// <summary>
        /// The context profile mask sdl glattribute
        /// </summary>
        ContextProfileMask,
        /// <summary>
        /// The share with current context sdl glattribute
        /// </summary>
        ShareWithCurrentContext,
        /// <summary>
        /// The framebuffer srgb capable sdl glattribute
        /// </summary>
        FramebufferSrgbCapable,
        /// <summary>
        /// The context release behavior sdl glattribute
        /// </summary>
        ContextReleaseBehavior
    }

    /// <summary>
    /// The sdl glcontextflag enum
    /// </summary>
    public enum SDL_GLContextFlag
    {
        /// <summary>
        /// The debug sdl glcontextflag
        /// </summary>
        Debug = 0x0001,
        /// <summary>
        /// The forward compatible sdl glcontextflag
        /// </summary>
        ForwardCompatible = 0x0002,
        /// <summary>
        /// The robust access sdl glcontextflag
        /// </summary>
        RobustAccess = 0x0004,
        /// <summary>
        /// The reset isolatio sdl glcontextflag
        /// </summary>
        ResetIsolatio = 0x0008,
    }

    /// <summary>
    /// The sdl glprofile enum
    /// </summary>
    public enum SDL_GLProfile
    {
        /// <summary>
        /// The core sdl glprofile
        /// </summary>
        Core = 0x0001,
        /// <summary>
        /// The compatibility sdl glprofile
        /// </summary>
        Compatibility = 0x0002,
        /// <summary>
        /// The es sdl glprofile
        /// </summary>
        ES = 0x0004
    }
}
