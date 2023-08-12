using System;
using Alis.Core.Graphic.Backends.Android;
using Alis.Core.Graphic.Backends.Metal;
using Vulkan;
using Vulkan.Wayland;
using Vulkan.Xlib;
using static Vulkan.VulkanNative;
using static Alis.Core.Graphic.Backends.Vk.VulkanUtil;

namespace Alis.Core.Graphic.Backends.Vk
{
    /// <summary>
    /// The vk surface util class
    /// </summary>
    internal static unsafe class VkSurfaceUtil
    {
        /// <summary>
        /// Creates the surface using the specified gd
        /// </summary>
        /// <param name="gd">The gd</param>
        /// <param name="instance">The instance</param>
        /// <param name="swapchainSource">The swapchain source</param>
        /// <exception cref="VeldridException"></exception>
        /// <exception cref="VeldridException"></exception>
        /// <exception cref="VeldridException"></exception>
        /// <exception cref="VeldridException">The provided SwapchainSource cannot be used to create a Vulkan surface.</exception>
        /// <exception cref="VeldridException">The required instance extension was not available: {CommonStrings.VK_KHR_ANDROID_SURFACE_EXTENSION_NAME}</exception>
        /// <exception cref="VeldridException">The required instance extension was not available: {CommonStrings.VK_KHR_SURFACE_EXTENSION_NAME}</exception>
        /// <exception cref="VeldridException">The required instance extension was not available: {CommonStrings.VK_KHR_WAYLAND_SURFACE_EXTENSION_NAME}</exception>
        /// <exception cref="VeldridException">The required instance extension was not available: {CommonStrings.VK_KHR_WIN32_SURFACE_EXTENSION_NAME}</exception>
        /// <exception cref="VeldridException">The required instance extension was not available: {CommonStrings.VK_KHR_XLIB_SURFACE_EXTENSION_NAME}</exception>
        /// <returns>The vk surface khr</returns>
        internal static VkSurfaceKHR CreateSurface(VkGraphicsDevice gd, VkInstance instance, SwapchainSource swapchainSource)
        {
            // TODO a null GD is passed from VkSurfaceSource.CreateSurface for compatibility
            //      when VkSurfaceInfo is removed we do not have to handle gd == null anymore
            var doCheck = gd != null;

            if (doCheck && !gd.HasSurfaceExtension(CommonStrings.VK_KHR_SURFACE_EXTENSION_NAME))
                throw new VeldridException($"The required instance extension was not available: {CommonStrings.VK_KHR_SURFACE_EXTENSION_NAME}");

            switch (swapchainSource)
            {
                case XlibSwapchainSource xlibSource:
                    if (doCheck && !gd.HasSurfaceExtension(CommonStrings.VK_KHR_XLIB_SURFACE_EXTENSION_NAME))
                    {
                        throw new VeldridException($"The required instance extension was not available: {CommonStrings.VK_KHR_XLIB_SURFACE_EXTENSION_NAME}");
                    }
                    return CreateXlib(instance, xlibSource);
                case WaylandSwapchainSource waylandSource:
                    if (doCheck && !gd.HasSurfaceExtension(CommonStrings.VK_KHR_WAYLAND_SURFACE_EXTENSION_NAME))
                    {
                        throw new VeldridException($"The required instance extension was not available: {CommonStrings.VK_KHR_WAYLAND_SURFACE_EXTENSION_NAME}");
                    }
                    return CreateWayland(instance, waylandSource);
                case Win32SwapchainSource win32Source:
                    if (doCheck && !gd.HasSurfaceExtension(CommonStrings.VK_KHR_WIN32_SURFACE_EXTENSION_NAME))
                    {
                        throw new VeldridException($"The required instance extension was not available: {CommonStrings.VK_KHR_WIN32_SURFACE_EXTENSION_NAME}");
                    }
                    return CreateWin32(instance, win32Source);
                case AndroidSurfaceSwapchainSource androidSource:
                    if (doCheck && !gd.HasSurfaceExtension(CommonStrings.VK_KHR_ANDROID_SURFACE_EXTENSION_NAME))
                    {
                        throw new VeldridException($"The required instance extension was not available: {CommonStrings.VK_KHR_ANDROID_SURFACE_EXTENSION_NAME}");
                    }
                    return CreateAndroidSurface(instance, androidSource);
                case NSWindowSwapchainSource nsWindowSource:
                    if (doCheck)
                    {
                        bool hasMetalExtension = gd.HasSurfaceExtension(CommonStrings.VK_EXT_METAL_SURFACE_EXTENSION_NAME);
                        if (hasMetalExtension || gd.HasSurfaceExtension(CommonStrings.VK_MVK_MACOS_SURFACE_EXTENSION_NAME))
                        {
                            return CreateNSWindowSurface(gd, instance, nsWindowSource, hasMetalExtension);
                        }
                        else
                        {
                            throw new VeldridException($"Neither macOS surface extension was available: " +
                                $"{CommonStrings.VK_MVK_MACOS_SURFACE_EXTENSION_NAME}, {CommonStrings.VK_EXT_METAL_SURFACE_EXTENSION_NAME}");
                        }
                    }

                    return CreateNSWindowSurface(gd, instance, nsWindowSource, false);
                case NSViewSwapchainSource nsViewSource:
                    if (doCheck)
                    {
                        bool hasMetalExtension = gd.HasSurfaceExtension(CommonStrings.VK_EXT_METAL_SURFACE_EXTENSION_NAME);
                        if (hasMetalExtension || gd.HasSurfaceExtension(CommonStrings.VK_MVK_MACOS_SURFACE_EXTENSION_NAME))
                        {
                            return CreateNSViewSurface(gd, instance, nsViewSource, hasMetalExtension);
                        }
                        else
                        {
                            throw new VeldridException($"Neither macOS surface extension was available: " +
                                $"{CommonStrings.VK_MVK_MACOS_SURFACE_EXTENSION_NAME}, {CommonStrings.VK_EXT_METAL_SURFACE_EXTENSION_NAME}");
                        }
                    }

                    return CreateNSViewSurface(gd, instance, nsViewSource, false);
                case UIViewSwapchainSource uiViewSource:
                    if (doCheck)
                    {
                        bool hasMetalExtension = gd.HasSurfaceExtension(CommonStrings.VK_EXT_METAL_SURFACE_EXTENSION_NAME);
                        if (hasMetalExtension || gd.HasSurfaceExtension(CommonStrings.VK_MVK_IOS_SURFACE_EXTENSION_NAME))
                        {
                            return CreateUIViewSurface(gd, instance, uiViewSource, hasMetalExtension);
                        }
                        else
                        {
                            throw new VeldridException($"Neither macOS surface extension was available: " +
                                $"{CommonStrings.VK_MVK_MACOS_SURFACE_EXTENSION_NAME}, {CommonStrings.VK_MVK_IOS_SURFACE_EXTENSION_NAME}");
                        }
                    }

                    return CreateUIViewSurface(gd, instance, uiViewSource, false);
                default:
                    throw new VeldridException($"The provided SwapchainSource cannot be used to create a Vulkan surface.");
            }
        }

        /// <summary>
        /// Creates the win 32 using the specified instance
        /// </summary>
        /// <param name="instance">The instance</param>
        /// <param name="win32Source">The win 32 source</param>
        /// <returns>The surface</returns>
        private static VkSurfaceKHR CreateWin32(VkInstance instance, Win32SwapchainSource win32Source)
        {
            VkWin32SurfaceCreateInfoKHR surfaceCI = VkWin32SurfaceCreateInfoKHR.New();
            surfaceCI.hwnd = win32Source.Hwnd;
            surfaceCI.hinstance = win32Source.Hinstance;
            VkResult result = vkCreateWin32SurfaceKHR(instance, ref surfaceCI, null, out VkSurfaceKHR surface);
            CheckResult(result);
            return surface;
        }

        /// <summary>
        /// Creates the xlib using the specified instance
        /// </summary>
        /// <param name="instance">The instance</param>
        /// <param name="xlibSource">The xlib source</param>
        /// <returns>The surface</returns>
        private static VkSurfaceKHR CreateXlib(VkInstance instance, XlibSwapchainSource xlibSource)
        {
            VkXlibSurfaceCreateInfoKHR xsci = VkXlibSurfaceCreateInfoKHR.New();
            xsci.dpy = (Display*)xlibSource.Display;
            xsci.window = new Window { Value = xlibSource.Window };
            VkResult result = vkCreateXlibSurfaceKHR(instance, ref xsci, null, out VkSurfaceKHR surface);
            CheckResult(result);
            return surface;
        }

        /// <summary>
        /// Creates the wayland using the specified instance
        /// </summary>
        /// <param name="instance">The instance</param>
        /// <param name="waylandSource">The wayland source</param>
        /// <returns>The surface</returns>
        private static VkSurfaceKHR CreateWayland(VkInstance instance, WaylandSwapchainSource waylandSource)
        {
            VkWaylandSurfaceCreateInfoKHR wsci = VkWaylandSurfaceCreateInfoKHR.New();
            wsci.display = (wl_display*)waylandSource.Display;
            wsci.surface = (wl_surface*)waylandSource.Surface;
            VkResult result = vkCreateWaylandSurfaceKHR(instance, ref wsci, null, out VkSurfaceKHR surface);
            CheckResult(result);
            return surface;
        }

        /// <summary>
        /// Creates the android surface using the specified instance
        /// </summary>
        /// <param name="instance">The instance</param>
        /// <param name="androidSource">The android source</param>
        /// <returns>The surface</returns>
        private static VkSurfaceKHR CreateAndroidSurface(VkInstance instance, AndroidSurfaceSwapchainSource androidSource)
        {
            IntPtr aNativeWindow = AndroidRuntime.ANativeWindow_fromSurface(androidSource.JniEnv, androidSource.Surface);

            VkAndroidSurfaceCreateInfoKHR androidSurfaceCI = VkAndroidSurfaceCreateInfoKHR.New();
            androidSurfaceCI.window = (Vulkan.Android.ANativeWindow*)aNativeWindow;
            VkResult result = vkCreateAndroidSurfaceKHR(instance, ref androidSurfaceCI, null, out VkSurfaceKHR surface);
            CheckResult(result);
            return surface;
        }

        /// <summary>
        /// Creates the ns window surface using the specified gd
        /// </summary>
        /// <param name="gd">The gd</param>
        /// <param name="instance">The instance</param>
        /// <param name="nsWindowSource">The ns window source</param>
        /// <param name="hasExtMetalSurface">The has ext metal surface</param>
        /// <returns>The vk surface khr</returns>
        private static unsafe VkSurfaceKHR CreateNSWindowSurface(VkGraphicsDevice gd, VkInstance instance, NSWindowSwapchainSource nsWindowSource, bool hasExtMetalSurface)
        {
            NSWindow nswindow = new NSWindow(nsWindowSource.NSWindow);
            return CreateNSViewSurface(gd, instance, new NSViewSwapchainSource(nswindow.contentView), hasExtMetalSurface);
        }

        /// <summary>
        /// Creates the ns view surface using the specified gd
        /// </summary>
        /// <param name="gd">The gd</param>
        /// <param name="instance">The instance</param>
        /// <param name="nsViewSource">The ns view source</param>
        /// <param name="hasExtMetalSurface">The has ext metal surface</param>
        /// <returns>The vk surface khr</returns>
        private static unsafe VkSurfaceKHR CreateNSViewSurface(VkGraphicsDevice gd, VkInstance instance, NSViewSwapchainSource nsViewSource, bool hasExtMetalSurface)
        {
            NSView contentView = new NSView(nsViewSource.NSView);

            if (!CAMetalLayer.TryCast(contentView.layer, out var metalLayer))
            {
                metalLayer = CAMetalLayer.New();
                contentView.wantsLayer = true;
                contentView.layer = metalLayer.NativePtr;
            }

            if (hasExtMetalSurface)
            {
                VkMetalSurfaceCreateInfoEXT surfaceCI = new VkMetalSurfaceCreateInfoEXT();
                surfaceCI.sType = VkMetalSurfaceCreateInfoEXT.VK_STRUCTURE_TYPE_METAL_SURFACE_CREATE_INFO_EXT;
                surfaceCI.pLayer = metalLayer.NativePtr.ToPointer();
                VkSurfaceKHR surface;
                VkResult result = gd.CreateMetalSurfaceEXT(instance, &surfaceCI, null, &surface);
                CheckResult(result);
                return surface;
            }
            else
            {
                VkMacOSSurfaceCreateInfoMVK surfaceCI = VkMacOSSurfaceCreateInfoMVK.New();
                surfaceCI.pView = contentView.NativePtr.ToPointer();
                VkResult result = vkCreateMacOSSurfaceMVK(instance, ref surfaceCI, null, out VkSurfaceKHR surface);
                CheckResult(result);
                return surface;
            }
        }

        /// <summary>
        /// Creates the ui view surface using the specified gd
        /// </summary>
        /// <param name="gd">The gd</param>
        /// <param name="instance">The instance</param>
        /// <param name="uiViewSource">The ui view source</param>
        /// <param name="hasExtMetalSurface">The has ext metal surface</param>
        /// <returns>The vk surface khr</returns>
        private static VkSurfaceKHR CreateUIViewSurface(VkGraphicsDevice gd, VkInstance instance, UIViewSwapchainSource uiViewSource, bool hasExtMetalSurface)
        {
            UIView uiView = new UIView(uiViewSource.UIView);

            if (!CAMetalLayer.TryCast(uiView.layer, out var metalLayer))
            {
                metalLayer = CAMetalLayer.New();
                metalLayer.frame = uiView.frame;
                metalLayer.opaque = true;
                uiView.layer.addSublayer(metalLayer.NativePtr);
            }

            if (hasExtMetalSurface)
            {
                VkMetalSurfaceCreateInfoEXT surfaceCI = new VkMetalSurfaceCreateInfoEXT();
                surfaceCI.sType = VkMetalSurfaceCreateInfoEXT.VK_STRUCTURE_TYPE_METAL_SURFACE_CREATE_INFO_EXT;
                surfaceCI.pLayer = metalLayer.NativePtr.ToPointer();
                VkSurfaceKHR surface;
                VkResult result = gd.CreateMetalSurfaceEXT(instance, &surfaceCI, null, &surface);
                CheckResult(result);
                return surface;
            }
            else
            {
                VkIOSSurfaceCreateInfoMVK surfaceCI = VkIOSSurfaceCreateInfoMVK.New();
                surfaceCI.pView = uiView.NativePtr.ToPointer();
                VkResult result = vkCreateIOSSurfaceMVK(instance, ref surfaceCI, null, out VkSurfaceKHR surface);
                return surface;
            }
        }
    }
}
