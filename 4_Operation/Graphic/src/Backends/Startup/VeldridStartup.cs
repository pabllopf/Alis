using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using Alis.Core.Graphic.Backends.SDL2;
using Alis.Core.Graphic.Backends.Vk;

namespace Alis.Core.Graphic.Backends.Startup
{
    /// <summary>
    /// The veldrid startup class
    /// </summary>
    public static class VeldridStartup
    {
        /// <summary>
        /// Creates the window and graphics device using the specified window ci
        /// </summary>
        /// <param name="windowCI">The window ci</param>
        /// <param name="window">The window</param>
        /// <param name="gd">The gd</param>
        public static void CreateWindowAndGraphicsDevice(
            WindowCreateInfo windowCI,
            out Sdl2Window window,
            out GraphicsDevice gd)
            => CreateWindowAndGraphicsDevice(
                windowCI,
                new GraphicsDeviceOptions(),
                GetPlatformDefaultBackend(),
                out window,
                out gd);

        /// <summary>
        /// Creates the window and graphics device using the specified window ci
        /// </summary>
        /// <param name="windowCI">The window ci</param>
        /// <param name="deviceOptions">The device options</param>
        /// <param name="window">The window</param>
        /// <param name="gd">The gd</param>
        public static void CreateWindowAndGraphicsDevice(
            WindowCreateInfo windowCI,
            GraphicsDeviceOptions deviceOptions,
            out Sdl2Window window,
            out GraphicsDevice gd)
            => CreateWindowAndGraphicsDevice(windowCI, deviceOptions, GetPlatformDefaultBackend(), out window, out gd);

        /// <summary>
        /// Creates the window and graphics device using the specified window ci
        /// </summary>
        /// <param name="windowCI">The window ci</param>
        /// <param name="deviceOptions">The device options</param>
        /// <param name="preferredBackend">The preferred backend</param>
        /// <param name="window">The window</param>
        /// <param name="gd">The gd</param>
        public static void CreateWindowAndGraphicsDevice(
            WindowCreateInfo windowCI,
            GraphicsDeviceOptions deviceOptions,
            GraphicsBackend preferredBackend,
            out Sdl2Window window,
            out GraphicsDevice gd)
        {
            Sdl2Native.SDL_Init(SDLInitFlags.Video);
            if (preferredBackend == GraphicsBackend.OpenGL || preferredBackend == GraphicsBackend.OpenGLES)
            {
                SetSDLGLContextAttributes(deviceOptions, preferredBackend);
            }

            window = CreateWindow(ref windowCI);
            gd = CreateGraphicsDevice(window, deviceOptions, preferredBackend);
        }


        /// <summary>
        /// Creates the window using the specified window ci
        /// </summary>
        /// <param name="windowCI">The window ci</param>
        /// <returns>The sdl window</returns>
        public static Sdl2Window CreateWindow(WindowCreateInfo windowCI) => CreateWindow(ref windowCI);

        /// <summary>
        /// Creates the window using the specified window ci
        /// </summary>
        /// <param name="windowCI">The window ci</param>
        /// <returns>The window</returns>
        public static Sdl2Window CreateWindow(ref WindowCreateInfo windowCI)
        {
            SDL_WindowFlags flags = SDL_WindowFlags.OpenGL | SDL_WindowFlags.Resizable
                    | GetWindowFlags(windowCI.WindowInitialState);
            if (windowCI.WindowInitialState != WindowState.Hidden)
            {
                flags |= SDL_WindowFlags.Shown;
            }
            Sdl2Window window = new Sdl2Window(
                windowCI.WindowTitle,
                windowCI.X,
                windowCI.Y,
                windowCI.WindowWidth,
                windowCI.WindowHeight,
                flags,
                false);

            return window;
        }

        /// <summary>
        /// Gets the window flags using the specified state
        /// </summary>
        /// <param name="state">The state</param>
        /// <exception cref="VeldridException"></exception>
        /// <returns>The sdl window flags</returns>
        private static SDL_WindowFlags GetWindowFlags(WindowState state)
        {
            switch (state)
            {
                case WindowState.Normal:
                    return 0;
                case WindowState.FullScreen:
                    return SDL_WindowFlags.Fullscreen;
                case WindowState.Maximized:
                    return SDL_WindowFlags.Maximized;
                case WindowState.Minimized:
                    return SDL_WindowFlags.Minimized;
                case WindowState.BorderlessFullScreen:
                    return SDL_WindowFlags.FullScreenDesktop;
                case WindowState.Hidden:
                    return SDL_WindowFlags.Hidden;
                default:
                    throw new VeldridException("Invalid WindowState: " + state);
            }
        }

        /// <summary>
        /// Creates the graphics device using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <returns>The graphics device</returns>
        public static GraphicsDevice CreateGraphicsDevice(Sdl2Window window)
            => CreateGraphicsDevice(window, new GraphicsDeviceOptions(), GetPlatformDefaultBackend());
        /// <summary>
        /// Creates the graphics device using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="options">The options</param>
        /// <returns>The graphics device</returns>
        public static GraphicsDevice CreateGraphicsDevice(Sdl2Window window, GraphicsDeviceOptions options)
            => CreateGraphicsDevice(window, options, GetPlatformDefaultBackend());
        /// <summary>
        /// Creates the graphics device using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="preferredBackend">The preferred backend</param>
        /// <returns>The graphics device</returns>
        public static GraphicsDevice CreateGraphicsDevice(Sdl2Window window, GraphicsBackend preferredBackend)
            => CreateGraphicsDevice(window, new GraphicsDeviceOptions(), preferredBackend);
        /// <summary>
        /// Creates the graphics device using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="options">The options</param>
        /// <param name="preferredBackend">The preferred backend</param>
        /// <exception cref="VeldridException"></exception>
        /// <returns>The graphics device</returns>
        public static GraphicsDevice CreateGraphicsDevice(
            Sdl2Window window,
            GraphicsDeviceOptions options,
            GraphicsBackend preferredBackend)
        {
            switch (preferredBackend)
            {
                case GraphicsBackend.Direct3D11:
#if !EXCLUDE_D3D11_BACKEND
                    return CreateDefaultD3D11GraphicsDevice(options, window);
#else
                    throw new VeldridException("D3D11 support has not been included in this configuration of Veldrid");
#endif
                case GraphicsBackend.Vulkan:
#if !EXCLUDE_VULKAN_BACKEND
                    return CreateVulkanGraphicsDevice(options, window);
#else
                    throw new VeldridException("Vulkan support has not been included in this configuration of Veldrid");
#endif
                case GraphicsBackend.OpenGL:
#if !EXCLUDE_OPENGL_BACKEND
                    return CreateDefaultOpenGLGraphicsDevice(options, window, preferredBackend);
#else
                    throw new VeldridException("OpenGL support has not been included in this configuration of Veldrid");
#endif
                case GraphicsBackend.Metal:
#if !EXCLUDE_METAL_BACKEND
                    return CreateMetalGraphicsDevice(options, window);
#else
                    throw new VeldridException("Metal support has not been included in this configuration of Veldrid");
#endif
                case GraphicsBackend.OpenGLES:
#if !EXCLUDE_OPENGL_BACKEND
                    return CreateDefaultOpenGLGraphicsDevice(options, window, preferredBackend);
#else
                    throw new VeldridException("OpenGL support has not been included in this configuration of Veldrid");
#endif
                default:
                    throw new VeldridException("Invalid GraphicsBackend: " + preferredBackend);
            }
        }

        /// <summary>
        /// Gets the swapchain source using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <exception cref="PlatformNotSupportedException"></exception>
        /// <returns>The swapchain source</returns>
        public static unsafe SwapchainSource GetSwapchainSource(Sdl2Window window)
        {
            IntPtr sdlHandle = window.SdlWindowHandle;
            SDL_SysWMinfo sysWmInfo;
            Sdl2Native.SDL_GetVersion(&sysWmInfo.version);
            Sdl2Native.SDL_GetWMWindowInfo(sdlHandle, &sysWmInfo);
            switch (sysWmInfo.subsystem)
            {
                case SysWMType.Windows:
                    Win32WindowInfo w32Info = Unsafe.Read<Win32WindowInfo>(&sysWmInfo.info);
                    return SwapchainSource.CreateWin32(w32Info.Sdl2Window, w32Info.hinstance);
                case SysWMType.X11:
                    X11WindowInfo x11Info = Unsafe.Read<X11WindowInfo>(&sysWmInfo.info);
                    return SwapchainSource.CreateXlib(
                        x11Info.display,
                        x11Info.Sdl2Window);
                case SysWMType.Wayland:
                    WaylandWindowInfo wlInfo = Unsafe.Read<WaylandWindowInfo>(&sysWmInfo.info);
                    return SwapchainSource.CreateWayland(wlInfo.display, wlInfo.surface);
                case SysWMType.Cocoa:
                    CocoaWindowInfo cocoaInfo = Unsafe.Read<CocoaWindowInfo>(&sysWmInfo.info);
                    IntPtr nsWindow = cocoaInfo.Window;
                    return SwapchainSource.CreateNSWindow(nsWindow);
                default:
                    throw new PlatformNotSupportedException("Cannot create a SwapchainSource for " + sysWmInfo.subsystem + ".");
            }
        }

#if !EXCLUDE_METAL_BACKEND
        /// <summary>
        /// Creates the metal graphics device using the specified options
        /// </summary>
        /// <param name="options">The options</param>
        /// <param name="window">The window</param>
        /// <returns>The graphics device</returns>
        private static unsafe GraphicsDevice CreateMetalGraphicsDevice(GraphicsDeviceOptions options, Sdl2Window window)
            => CreateMetalGraphicsDevice(options, window, options.SwapchainSrgbFormat);
        /// <summary>
        /// Creates the metal graphics device using the specified options
        /// </summary>
        /// <param name="options">The options</param>
        /// <param name="window">The window</param>
        /// <param name="colorSrgb">The color srgb</param>
        /// <returns>The graphics device</returns>
        private static unsafe GraphicsDevice CreateMetalGraphicsDevice(
            GraphicsDeviceOptions options,
            Sdl2Window window,
            bool colorSrgb)
        {
            SwapchainSource source = GetSwapchainSource(window);
            SwapchainDescription swapchainDesc = new SwapchainDescription(
                source,
                (uint)window.Width, (uint)window.Height,
                options.SwapchainDepthFormat,
                options.SyncToVerticalBlank,
                colorSrgb);

            return GraphicsDevice.CreateMetal(options, swapchainDesc);
        }
#endif

        /// <summary>
        /// Gets the platform default backend
        /// </summary>
        /// <returns>The graphics backend</returns>
        public static GraphicsBackend GetPlatformDefaultBackend()
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                return GraphicsBackend.Direct3D11;
            }
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
            {
                return GraphicsDevice.IsBackendSupported(GraphicsBackend.Metal)
                    ? GraphicsBackend.Metal
                    : GraphicsBackend.OpenGL;
            }
            else
            {
                return GraphicsDevice.IsBackendSupported(GraphicsBackend.Vulkan)
                    ? GraphicsBackend.Vulkan
                    : GraphicsBackend.OpenGL;
            }
        }

#if !EXCLUDE_VULKAN_BACKEND
        /// <summary>
        /// Creates the vulkan graphics device using the specified options
        /// </summary>
        /// <param name="options">The options</param>
        /// <param name="window">The window</param>
        /// <returns>The graphics device</returns>
        public static unsafe GraphicsDevice CreateVulkanGraphicsDevice(GraphicsDeviceOptions options, Sdl2Window window)
            => CreateVulkanGraphicsDevice(options, window, false);
        /// <summary>
        /// Creates the vulkan graphics device using the specified options
        /// </summary>
        /// <param name="options">The options</param>
        /// <param name="window">The window</param>
        /// <param name="colorSrgb">The color srgb</param>
        /// <returns>The gd</returns>
        public static unsafe GraphicsDevice CreateVulkanGraphicsDevice(
            GraphicsDeviceOptions options,
            Sdl2Window window,
            bool colorSrgb)
        {
            SwapchainDescription scDesc = new SwapchainDescription(
                GetSwapchainSource(window),
                (uint)window.Width,
                (uint)window.Height,
                options.SwapchainDepthFormat,
                options.SyncToVerticalBlank,
                colorSrgb);
            GraphicsDevice gd = GraphicsDevice.CreateVulkan(options, scDesc);

            return gd;
        }

        /// <summary>
        /// Gets the surface source using the specified sys wm info
        /// </summary>
        /// <param name="sysWmInfo">The sys wm info</param>
        /// <exception cref="PlatformNotSupportedException"></exception>
        /// <returns>The veldrid vk vk surface source</returns>
        private static unsafe VkSurfaceSource GetSurfaceSource(SDL_SysWMinfo sysWmInfo)
        {
            switch (sysWmInfo.subsystem)
            {
                case SysWMType.Windows:
                    Win32WindowInfo w32Info = Unsafe.Read<Win32WindowInfo>(&sysWmInfo.info);
                    return Vk.VkSurfaceSource.CreateWin32(w32Info.hinstance, w32Info.Sdl2Window);
                case SysWMType.X11:
                    X11WindowInfo x11Info = Unsafe.Read<X11WindowInfo>(&sysWmInfo.info);
                    return Vk.VkSurfaceSource.CreateXlib(
                        (Vulkan.Xlib.Display*)x11Info.display,
                        new Vulkan.Xlib.Window() { Value = x11Info.Sdl2Window });
                default:
                    throw new PlatformNotSupportedException("Cannot create a Vulkan surface for " + sysWmInfo.subsystem + ".");
            }
        }
#endif

#if !EXCLUDE_OPENGL_BACKEND
        /// <summary>
        /// Creates the default open gl graphics device using the specified options
        /// </summary>
        /// <param name="options">The options</param>
        /// <param name="window">The window</param>
        /// <param name="backend">The backend</param>
        /// <exception cref="VeldridException">Unable to create OpenGL Context: \"{errorString}\". This may indicate that the system does not support the requested OpenGL profile, version, or Swapchain format.</exception>
        /// <returns>The graphics device</returns>
        public static unsafe GraphicsDevice CreateDefaultOpenGLGraphicsDevice(
            GraphicsDeviceOptions options,
            Sdl2Window window,
            GraphicsBackend backend)
        {
            Sdl2Native.SDL_ClearError();
            IntPtr sdlHandle = window.SdlWindowHandle;

            SDL_SysWMinfo sysWmInfo;
            Sdl2Native.SDL_GetVersion(&sysWmInfo.version);
            Sdl2Native.SDL_GetWMWindowInfo(sdlHandle, &sysWmInfo);

            SetSDLGLContextAttributes(options, backend);

            IntPtr contextHandle = Sdl2Native.SDL_GL_CreateContext(sdlHandle);
            byte* error = Sdl2Native.SDL_GetError();
            if (error != null)
            {
                string errorString = GetString(error);
                if (!string.IsNullOrEmpty(errorString))
                {
                    throw new VeldridException(
                        $"Unable to create OpenGL Context: \"{errorString}\". This may indicate that the system does not support the requested OpenGL profile, version, or Swapchain format.");
                }
            }

            int actualDepthSize;
            int result = Sdl2Native.SDL_GL_GetAttribute(SDL_GLAttribute.DepthSize, &actualDepthSize);
            int actualStencilSize;
            result = Sdl2Native.SDL_GL_GetAttribute(SDL_GLAttribute.StencilSize, &actualStencilSize);

            result = Sdl2Native.SDL_GL_SetSwapInterval(options.SyncToVerticalBlank ? 1 : 0);

            OpenGL.OpenGLPlatformInfo platformInfo = new OpenGL.OpenGLPlatformInfo(
                contextHandle,
                Sdl2Native.SDL_GL_GetProcAddress,
                context => Sdl2Native.SDL_GL_MakeCurrent(sdlHandle, context),
                () => Sdl2Native.SDL_GL_GetCurrentContext(),
                () => Sdl2Native.SDL_GL_MakeCurrent(new SDL_Window(IntPtr.Zero), IntPtr.Zero),
                Sdl2Native.SDL_GL_DeleteContext,
                () => Sdl2Native.SDL_GL_SwapWindow(sdlHandle),
                sync => Sdl2Native.SDL_GL_SetSwapInterval(sync ? 1 : 0));

            return GraphicsDevice.CreateOpenGL(
                options,
                platformInfo,
                (uint)window.Width,
                (uint)window.Height);
        }

        /// <summary>
        /// Sets the sdlgl context attributes using the specified options
        /// </summary>
        /// <param name="options">The options</param>
        /// <param name="backend">The backend</param>
        /// <exception cref="VeldridException"></exception>
        /// <exception cref="VeldridException">{nameof(backend)} must be {nameof(GraphicsBackend.OpenGL)} or {nameof(GraphicsBackend.OpenGLES)}.</exception>
        public static unsafe void SetSDLGLContextAttributes(GraphicsDeviceOptions options, GraphicsBackend backend)
        {
            if (backend != GraphicsBackend.OpenGL && backend != GraphicsBackend.OpenGLES)
            {
                throw new VeldridException(
                    $"{nameof(backend)} must be {nameof(GraphicsBackend.OpenGL)} or {nameof(GraphicsBackend.OpenGLES)}.");
            }

            SDL_GLContextFlag contextFlags = options.Debug
                ? SDL_GLContextFlag.Debug | SDL_GLContextFlag.ForwardCompatible
                : SDL_GLContextFlag.ForwardCompatible;

            Sdl2Native.SDL_GL_SetAttribute(SDL_GLAttribute.ContextFlags, (int)contextFlags);

            (int major, int minor) = GetMaxGLVersion(backend == GraphicsBackend.OpenGLES);

            if (backend == GraphicsBackend.OpenGL)
            {
                Sdl2Native.SDL_GL_SetAttribute(SDL_GLAttribute.ContextProfileMask, (int)SDL_GLProfile.Core);
                Sdl2Native.SDL_GL_SetAttribute(SDL_GLAttribute.ContextMajorVersion, major);
                Sdl2Native.SDL_GL_SetAttribute(SDL_GLAttribute.ContextMinorVersion, minor);
            }
            else
            {
                Sdl2Native.SDL_GL_SetAttribute(SDL_GLAttribute.ContextProfileMask, (int)SDL_GLProfile.ES);
                Sdl2Native.SDL_GL_SetAttribute(SDL_GLAttribute.ContextMajorVersion, major);
                Sdl2Native.SDL_GL_SetAttribute(SDL_GLAttribute.ContextMinorVersion, minor);
            }

            int depthBits = 0;
            int stencilBits = 0;
            if (options.SwapchainDepthFormat.HasValue)
            {
                switch (options.SwapchainDepthFormat)
                {
                    case PixelFormat.R16_UNorm:
                        depthBits = 16;
                        break;
                    case PixelFormat.D24_UNorm_S8_UInt:
                        depthBits = 24;
                        stencilBits = 8;
                        break;
                    case PixelFormat.R32_Float:
                        depthBits = 32;
                        break;
                    case PixelFormat.D32_Float_S8_UInt:
                        depthBits = 32;
                        stencilBits = 8;
                        break;
                    default:
                        throw new VeldridException("Invalid depth format: " + options.SwapchainDepthFormat.Value);
                }
            }

            int result = Sdl2Native.SDL_GL_SetAttribute(SDL_GLAttribute.DepthSize, depthBits);
            result = Sdl2Native.SDL_GL_SetAttribute(SDL_GLAttribute.StencilSize, stencilBits);

            if (options.SwapchainSrgbFormat)
            {
                Sdl2Native.SDL_GL_SetAttribute(SDL_GLAttribute.FramebufferSrgbCapable, 1);
            }
            else
            {
                Sdl2Native.SDL_GL_SetAttribute(SDL_GLAttribute.FramebufferSrgbCapable, 0);
            }
        }
#endif

#if !EXCLUDE_D3D11_BACKEND
        /// <summary>
        /// Creates the default d 3 d 11 graphics device using the specified options
        /// </summary>
        /// <param name="options">The options</param>
        /// <param name="window">The window</param>
        /// <returns>The graphics device</returns>
        public static GraphicsDevice CreateDefaultD3D11GraphicsDevice(
            GraphicsDeviceOptions options,
            Sdl2Window window)
        {
            SwapchainSource source = GetSwapchainSource(window);
            SwapchainDescription swapchainDesc = new SwapchainDescription(
                source,
                (uint)window.Width, (uint)window.Height,
                options.SwapchainDepthFormat,
                options.SyncToVerticalBlank,
                options.SwapchainSrgbFormat);

            return GraphicsDevice.CreateD3D11(options, swapchainDesc);
        }
#endif

        /// <summary>
        /// Gets the string using the specified string start
        /// </summary>
        /// <param name="stringStart">The string start</param>
        /// <returns>The string</returns>
        private static unsafe string GetString(byte* stringStart)
        {
            int characters = 0;
            while (stringStart[characters] != 0)
            {
                characters++;
            }

            return Encoding.UTF8.GetString(stringStart, characters);
        }

#if !EXCLUDE_OPENGL_BACKEND
        /// <summary>
        /// The glversionlock
        /// </summary>
        private static readonly object s_glVersionLock = new object();
        /// <summary>
        /// The maxsupportedglversion
        /// </summary>
        private static (int Major, int Minor)? s_maxSupportedGLVersion;
        /// <summary>
        /// The maxsupportedglesversion
        /// </summary>
        private static (int Major, int Minor)? s_maxSupportedGLESVersion;

        /// <summary>
        /// Gets the max gl version using the specified gles
        /// </summary>
        /// <param name="gles">The gles</param>
        /// <returns>The int major int minor</returns>
        private static (int Major, int Minor) GetMaxGLVersion(bool gles)
        {
            lock (s_glVersionLock)
            {
                (int Major, int Minor)? maxVer = gles ? s_maxSupportedGLESVersion : s_maxSupportedGLVersion;
                if (maxVer == null)
                {
                    maxVer = TestMaxVersion(gles);
                    if (gles) { s_maxSupportedGLESVersion = maxVer; }
                    else { s_maxSupportedGLVersion = maxVer; }
                }

                return maxVer.Value;
            }
        }

        /// <summary>
        /// Tests the max version using the specified gles
        /// </summary>
        /// <param name="gles">The gles</param>
        /// <returns>The int major int minor</returns>
        private static (int Major, int Minor) TestMaxVersion(bool gles)
        {
            (int, int)[] testVersions = gles
                ? new[] { (3, 2), (3, 0) }
                : new[] { (4, 6), (4, 3), (4, 0), (3, 3), (3, 0) };

            foreach ((int major, int minor) in testVersions)
            {
                if (TestIndividualGLVersion(gles, major, minor)) { return (major, minor); }
            }

            return (0, 0);
        }

        /// <summary>
        /// Describes whether test individual gl version
        /// </summary>
        /// <param name="gles">The gles</param>
        /// <param name="major">The major</param>
        /// <param name="minor">The minor</param>
        /// <returns>The bool</returns>
        private static unsafe bool TestIndividualGLVersion(bool gles, int major, int minor)
        {
            SDL_GLProfile profileMask = gles ? SDL_GLProfile.ES : SDL_GLProfile.Core;

            Sdl2Native.SDL_GL_SetAttribute(SDL_GLAttribute.ContextProfileMask, (int)profileMask);
            Sdl2Native.SDL_GL_SetAttribute(SDL_GLAttribute.ContextMajorVersion, major);
            Sdl2Native.SDL_GL_SetAttribute(SDL_GLAttribute.ContextMinorVersion, minor);

            SDL_Window window = Sdl2Native.SDL_CreateWindow(
                string.Empty,
                0, 0,
                1, 1,
                SDL_WindowFlags.Hidden | SDL_WindowFlags.OpenGL);
            byte* error = Sdl2Native.SDL_GetError();
            string errorString = GetString(error);

            if (window.NativePointer == IntPtr.Zero || !string.IsNullOrEmpty(errorString))
            {
                Sdl2Native.SDL_ClearError();
                Debug.WriteLine($"Unable to create version {major}.{minor} {profileMask} context.");
                return false;
            }

            IntPtr context = Sdl2Native.SDL_GL_CreateContext(window);
            error = Sdl2Native.SDL_GetError();
            if (error != null)
            {
                errorString = GetString(error);
                if (!string.IsNullOrEmpty(errorString))
                {
                    Sdl2Native.SDL_ClearError();
                    Debug.WriteLine($"Unable to create version {major}.{minor} {profileMask} context.");
                    Sdl2Native.SDL_DestroyWindow(window);
                    return false;
                }
            }

            Sdl2Native.SDL_GL_DeleteContext(context);
            Sdl2Native.SDL_DestroyWindow(window);
            return true;
        }
#endif
    }
}
