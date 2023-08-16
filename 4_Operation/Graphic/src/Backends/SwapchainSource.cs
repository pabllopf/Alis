using System;

namespace Alis.Core.Graphic.Backends
{
    /// <summary>
    /// A platform-specific object representing a renderable surface.
    /// A SwapchainSource can be created with one of several static factory methods.
    /// A SwapchainSource is used to describe a Swapchain (see <see cref="SwapchainDescription"/>).
    /// </summary>
    public abstract class SwapchainSource
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SwapchainSource"/> class
        /// </summary>
        internal SwapchainSource() { }

        /// <summary>
        /// Creates a new SwapchainSource for a Win32 window.
        /// </summary>
        /// <param name="hwnd">The Win32 window handle.</param>
        /// <param name="hinstance">The Win32 instance handle.</param>
        /// <returns>A new SwapchainSource which can be used to create a <see cref="Swapchain"/> for the given Win32 window.
        /// </returns>
        public static SwapchainSource CreateWin32(IntPtr hwnd, IntPtr hinstance) => new Win32SwapchainSource(hwnd, hinstance);

        /// <summary>
        /// Creates a new SwapchainSource for a UWP SwapChain panel.
        /// </summary>
        /// <param name="swapChainPanel">A COM object which must implement the
        /// or interface. Generally, this should be a SwapChainPanel
        /// or SwapChainBackgroundPanel contained in your application window.</param>
        /// <param name="logicalDpi">The logical DPI of the swapchain panel.</param>
        /// <returns>A new SwapchainSource which can be used to create a <see cref="Swapchain"/> for the given UWP panel.
        /// </returns>
        public static SwapchainSource CreateUwp(object swapChainPanel, float logicalDpi)
            => new UwpSwapchainSource(swapChainPanel, logicalDpi);

        /// <summary>
        /// Creates a new SwapchainSource from the given Xlib information.
        /// </summary>
        /// <param name="display">An Xlib Display.</param>
        /// <param name="window">An Xlib Window.</param>
        /// <returns>A new SwapchainSource which can be used to create a <see cref="Swapchain"/> for the given Xlib window.
        /// </returns>
        public static SwapchainSource CreateXlib(IntPtr display, IntPtr window) => new XlibSwapchainSource(display, window);

        /// <summary>
        /// Creates a new SwapchainSource from the given Wayland information.
        /// </summary>
        /// <param name="display">The Wayland display proxy.</param>
        /// <param name="surface">The Wayland surface proxy to map.</param>
        /// <returns>A new SwapchainSource which can be used to create a <see cref="Swapchain"/> for the given Wayland surface.
        /// </returns>
        public static SwapchainSource CreateWayland(IntPtr display, IntPtr surface) => new WaylandSwapchainSource(display, surface);


        /// <summary>
        /// Creates a new SwapchainSource for the given NSWindow.
        /// </summary>
        /// <param name="nsWindow">A pointer to an NSWindow.</param>
        /// <returns>A new SwapchainSource which can be used to create a Metal <see cref="Swapchain"/> for the given NSWindow.
        /// </returns>
        public static SwapchainSource CreateNSWindow(IntPtr nsWindow) => new NSWindowSwapchainSource(nsWindow);

        /// <summary>
        /// Creates a new SwapchainSource for the given UIView.
        /// </summary>
        /// <param name="uiView">The UIView's native handle.</param>
        /// <returns>A new SwapchainSource which can be used to create a Metal <see cref="Swapchain"/> or an OpenGLES
        /// <see cref="GraphicsDevice"/> for the given UIView.
        /// </returns>
        public static SwapchainSource CreateUIView(IntPtr uiView) => new UIViewSwapchainSource(uiView);

        /// <summary>
        /// Creates a new SwapchainSource for the given Android Surface.
        /// </summary>
        /// <param name="surfaceHandle">The handle of the Android Surface.</param>
        /// <param name="jniEnv">The Java Native Interface Environment handle.</param>
        /// <returns>A new SwapchainSource which can be used to create a Vulkan <see cref="Swapchain"/> or an OpenGLES
        /// <see cref="GraphicsDevice"/> for the given Android Surface.</returns>
        public static SwapchainSource CreateAndroidSurface(IntPtr surfaceHandle, IntPtr jniEnv)
            => new AndroidSurfaceSwapchainSource(surfaceHandle, jniEnv);

        /// <summary>
        /// Creates a new SwapchainSource for the given NSView.
        /// </summary>
        /// <param name="nsView">A pointer to an NSView.</param>
        /// <returns>A new SwapchainSource which can be used to create a Metal <see cref="Swapchain"/> for the given NSView.
        /// </returns>
        public static SwapchainSource CreateNSView(IntPtr nsView)
            => new NSViewSwapchainSource(nsView);
    }

    /// <summary>
    /// The win 32 swapchain source class
    /// </summary>
    /// <seealso cref="SwapchainSource"/>
    internal class Win32SwapchainSource : SwapchainSource
    {
        /// <summary>
        /// Gets the value of the hwnd
        /// </summary>
        public IntPtr Hwnd { get; }
        /// <summary>
        /// Gets the value of the hinstance
        /// </summary>
        public IntPtr Hinstance { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Win32SwapchainSource"/> class
        /// </summary>
        /// <param name="hwnd">The hwnd</param>
        /// <param name="hinstance">The hinstance</param>
        public Win32SwapchainSource(IntPtr hwnd, IntPtr hinstance)
        {
            Hwnd = hwnd;
            Hinstance = hinstance;
        }
    }

    /// <summary>
    /// The uwp swapchain source class
    /// </summary>
    /// <seealso cref="SwapchainSource"/>
    internal class UwpSwapchainSource : SwapchainSource
    {
        /// <summary>
        /// Gets the value of the swap chain panel native
        /// </summary>
        public object SwapChainPanelNative { get; }
        /// <summary>
        /// Gets the value of the logical dpi
        /// </summary>
        public float LogicalDpi { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="UwpSwapchainSource"/> class
        /// </summary>
        /// <param name="swapChainPanelNative">The swap chain panel native</param>
        /// <param name="logicalDpi">The logical dpi</param>
        public UwpSwapchainSource(object swapChainPanelNative, float logicalDpi)
        {
            SwapChainPanelNative = swapChainPanelNative;
            LogicalDpi = logicalDpi;
        }
    }

    /// <summary>
    /// The xlib swapchain source class
    /// </summary>
    /// <seealso cref="SwapchainSource"/>
    internal class XlibSwapchainSource : SwapchainSource
    {
        /// <summary>
        /// Gets the value of the display
        /// </summary>
        public IntPtr Display { get; }
        /// <summary>
        /// Gets the value of the window
        /// </summary>
        public IntPtr Window { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="XlibSwapchainSource"/> class
        /// </summary>
        /// <param name="display">The display</param>
        /// <param name="window">The window</param>
        public XlibSwapchainSource(IntPtr display, IntPtr window)
        {
            Display = display;
            Window = window;
        }
    }

    /// <summary>
    /// The wayland swapchain source class
    /// </summary>
    /// <seealso cref="SwapchainSource"/>
    internal class WaylandSwapchainSource : SwapchainSource
    {
        /// <summary>
        /// Gets the value of the display
        /// </summary>
        public IntPtr Display { get; }
        /// <summary>
        /// Gets the value of the surface
        /// </summary>
        public IntPtr Surface { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="WaylandSwapchainSource"/> class
        /// </summary>
        /// <param name="display">The display</param>
        /// <param name="surface">The surface</param>
        public WaylandSwapchainSource(IntPtr display, IntPtr surface)
        {
            Display = display;
            Surface = surface;
        }
    }

    /// <summary>
    /// The ns window swapchain source class
    /// </summary>
    /// <seealso cref="SwapchainSource"/>
    internal class NSWindowSwapchainSource : SwapchainSource
    {
        /// <summary>
        /// Gets the value of the ns window
        /// </summary>
        public IntPtr NSWindow { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="NSWindowSwapchainSource"/> class
        /// </summary>
        /// <param name="nsWindow">The ns window</param>
        public NSWindowSwapchainSource(IntPtr nsWindow)
        {
            NSWindow = nsWindow;
        }
    }

    /// <summary>
    /// The ui view swapchain source class
    /// </summary>
    /// <seealso cref="SwapchainSource"/>
    internal class UIViewSwapchainSource : SwapchainSource
    {
        /// <summary>
        /// Gets the value of the ui view
        /// </summary>
        public IntPtr UIView { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="UIViewSwapchainSource"/> class
        /// </summary>
        /// <param name="uiView">The ui view</param>
        public UIViewSwapchainSource(IntPtr uiView)
        {
            UIView = uiView;
        }
    }

    /// <summary>
    /// The android surface swapchain source class
    /// </summary>
    /// <seealso cref="SwapchainSource"/>
    internal class AndroidSurfaceSwapchainSource : SwapchainSource
    {
        /// <summary>
        /// Gets the value of the surface
        /// </summary>
        public IntPtr Surface { get; }
        /// <summary>
        /// Gets the value of the jni env
        /// </summary>
        public IntPtr JniEnv { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="AndroidSurfaceSwapchainSource"/> class
        /// </summary>
        /// <param name="surfaceHandle">The surface handle</param>
        /// <param name="jniEnv">The jni env</param>
        public AndroidSurfaceSwapchainSource(IntPtr surfaceHandle, IntPtr jniEnv)
        {
            Surface = surfaceHandle;
            JniEnv = jniEnv;
        }
    }

    /// <summary>
    /// The ns view swapchain source class
    /// </summary>
    /// <seealso cref="SwapchainSource"/>
    internal class NSViewSwapchainSource : SwapchainSource
    {
        /// <summary>
        /// Gets the value of the ns view
        /// </summary>
        public IntPtr NSView { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="NSViewSwapchainSource"/> class
        /// </summary>
        /// <param name="nsView">The ns view</param>
        public NSViewSwapchainSource(IntPtr nsView)
        {
            NSView = nsView;
        }
    }
}
