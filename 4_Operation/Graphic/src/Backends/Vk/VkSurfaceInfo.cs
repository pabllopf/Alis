using System;
using Vulkan;
using Vulkan.Xlib;

namespace Veldrid.Vk
{
    /// <summary>
    /// An object which can be used to create a VkSurfaceKHR.
    /// </summary>
    public abstract class VkSurfaceSource
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="VkSurfaceSource"/> class
        /// </summary>
        internal VkSurfaceSource() { }

        /// <summary>
        /// Creates a new VkSurfaceKHR attached to this source.
        /// </summary>
        /// <param name="instance">The VkInstance to use.</param>
        /// <returns>A new VkSurfaceKHR.</returns>
        public abstract VkSurfaceKHR CreateSurface(VkInstance instance);

        /// <summary>
        /// Creates a new <see cref="VkSurfaceSource"/> from the given Win32 instance and window handle.
        /// </summary>
        /// <param name="hinstance">The Win32 instance handle.</param>
        /// <param name="hwnd">The Win32 window handle.</param>
        /// <returns>A new VkSurfaceSource.</returns>
        public static VkSurfaceSource CreateWin32(IntPtr hinstance, IntPtr hwnd) => new Win32VkSurfaceInfo(hinstance, hwnd);
        /// <summary>
        /// Creates a new VkSurfaceSource from the given Xlib information.
        /// </summary>
        /// <param name="display">A pointer to the Xlib Display.</param>
        /// <param name="window">An Xlib window.</param>
        /// <returns>A new VkSurfaceSource.</returns>
        public unsafe static VkSurfaceSource CreateXlib(Display* display, Window window) => new XlibVkSurfaceInfo(display, window);

        /// <summary>
        /// Gets the surface source
        /// </summary>
        /// <returns>The swapchain source</returns>
        internal abstract SwapchainSource GetSurfaceSource();
    }

    /// <summary>
    /// The win 32 vk surface info class
    /// </summary>
    /// <seealso cref="VkSurfaceSource"/>
    internal class Win32VkSurfaceInfo : VkSurfaceSource
    {
        /// <summary>
        /// The hinstance
        /// </summary>
        private readonly IntPtr _hinstance;
        /// <summary>
        /// The hwnd
        /// </summary>
        private readonly IntPtr _hwnd;

        /// <summary>
        /// Initializes a new instance of the <see cref="Win32VkSurfaceInfo"/> class
        /// </summary>
        /// <param name="hinstance">The hinstance</param>
        /// <param name="hwnd">The hwnd</param>
        public Win32VkSurfaceInfo(IntPtr hinstance, IntPtr hwnd)
        {
            _hinstance = hinstance;
            _hwnd = hwnd;
        }

        /// <summary>
        /// Creates the surface using the specified instance
        /// </summary>
        /// <param name="instance">The instance</param>
        /// <returns>The vk surface khr</returns>
        public unsafe override VkSurfaceKHR CreateSurface(VkInstance instance)
        {
            return VkSurfaceUtil.CreateSurface(null, instance, GetSurfaceSource());
        }

        /// <summary>
        /// Gets the surface source
        /// </summary>
        /// <returns>The swapchain source</returns>
        internal override SwapchainSource GetSurfaceSource()
        {
            return new Win32SwapchainSource(_hwnd, _hinstance);
        }
    }

    /// <summary>
    /// The xlib vk surface info class
    /// </summary>
    /// <seealso cref="VkSurfaceSource"/>
    internal class XlibVkSurfaceInfo : VkSurfaceSource
    {
        /// <summary>
        /// The display
        /// </summary>
        private readonly unsafe Display* _display;
        /// <summary>
        /// The window
        /// </summary>
        private readonly Window _window;

        /// <summary>
        /// Initializes a new instance of the <see cref="XlibVkSurfaceInfo"/> class
        /// </summary>
        /// <param name="display">The display</param>
        /// <param name="window">The window</param>
        public unsafe XlibVkSurfaceInfo(Display* display, Window window)
        {
            _display = display;
            _window = window;
        }

        /// <summary>
        /// Creates the surface using the specified instance
        /// </summary>
        /// <param name="instance">The instance</param>
        /// <returns>The vk surface khr</returns>
        public unsafe override VkSurfaceKHR CreateSurface(VkInstance instance)
        {
            return VkSurfaceUtil.CreateSurface(null, instance, GetSurfaceSource());
        }

        /// <summary>
        /// Gets the surface source
        /// </summary>
        /// <returns>The swapchain source</returns>
        internal unsafe override SwapchainSource GetSurfaceSource()
        {
            return new XlibSwapchainSource((IntPtr)_display, _window.Value);
        }
    }
}
