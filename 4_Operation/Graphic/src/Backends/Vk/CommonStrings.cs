using System;

namespace Alis.Core.Graphic.Backends.Vk
{
    /// <summary>
    /// The common strings class
    /// </summary>
    internal static class CommonStrings
    {
        /// <summary>
        /// The vk instance create enumerate portability bit khr
        /// </summary>
        public static FixedUtf8String VK_INSTANCE_CREATE_ENUMERATE_PORTABILITY_BIT_KHR { get; } = "VK_INSTANCE_CREATE_ENUMERATE_PORTABILITY_BIT_KHR";

        /// <summary>
        /// Gets the value of the vk khr surface extension name
        /// </summary>
        public static FixedUtf8String VK_KHR_SURFACE_EXTENSION_NAME { get; } = "VK_KHR_surface";
        /// <summary>
        /// Gets the value of the vk khr win32 surface extension name
        /// </summary>
        public static FixedUtf8String VK_KHR_WIN32_SURFACE_EXTENSION_NAME { get; } = "VK_KHR_win32_surface";
        /// <summary>
        /// Gets the value of the vk khr xcb surface extension name
        /// </summary>
        public static FixedUtf8String VK_KHR_XCB_SURFACE_EXTENSION_NAME { get; } = "VK_KHR_xcb_surface";
        /// <summary>
        /// Gets the value of the vk khr xlib surface extension name
        /// </summary>
        public static FixedUtf8String VK_KHR_XLIB_SURFACE_EXTENSION_NAME { get; } = "VK_KHR_xlib_surface";
        /// <summary>
        /// Gets the value of the vk khr wayland surface extension name
        /// </summary>
        public static FixedUtf8String VK_KHR_WAYLAND_SURFACE_EXTENSION_NAME { get; } = "VK_KHR_wayland_surface";
        /// <summary>
        /// Gets the value of the vk khr android surface extension name
        /// </summary>
        public static FixedUtf8String VK_KHR_ANDROID_SURFACE_EXTENSION_NAME { get; } = "VK_KHR_android_surface";
        /// <summary>
        /// Gets the value of the vk khr swapchain extension name
        /// </summary>
        public static FixedUtf8String VK_KHR_SWAPCHAIN_EXTENSION_NAME { get; } = "VK_KHR_swapchain";
        /// <summary>
        /// Gets the value of the vk mvk macos surface extension name
        /// </summary>
        public static FixedUtf8String VK_MVK_MACOS_SURFACE_EXTENSION_NAME { get; } = "VK_MVK_macos_surface";
        /// <summary>
        /// Gets the value of the vk mvk ios surface extension name
        /// </summary>
        public static FixedUtf8String VK_MVK_IOS_SURFACE_EXTENSION_NAME { get; } = "VK_MVK_ios_surface";
        /// <summary>
        /// Gets the value of the vk ext metal surface extension name
        /// </summary>
        public static FixedUtf8String VK_EXT_METAL_SURFACE_EXTENSION_NAME { get; } = "VK_EXT_metal_surface";
        /// <summary>
        /// Gets the value of the vk ext debug report extension name
        /// </summary>
        public static FixedUtf8String VK_EXT_DEBUG_REPORT_EXTENSION_NAME { get; } = "VK_EXT_debug_report";
        /// <summary>
        /// Gets the value of the vk ext debug marker extension name
        /// </summary>
        public static FixedUtf8String VK_EXT_DEBUG_MARKER_EXTENSION_NAME { get; } = "VK_EXT_debug_marker";
        /// <summary>
        /// Gets the value of the standard validation layer name
        /// </summary>
        public static FixedUtf8String StandardValidationLayerName { get; } = "VK_LAYER_LUNARG_standard_validation";
        /// <summary>
        /// Gets the value of the khronos validation layer name
        /// </summary>
        public static FixedUtf8String KhronosValidationLayerName { get; } = "VK_LAYER_KHRONOS_validation";
        /// <summary>
        /// Gets the value of the main
        /// </summary>
        public static FixedUtf8String main { get; } = "main";
        /// <summary>
        /// Gets the value of the vk khr get physical device properties2
        /// </summary>
        public static FixedUtf8String VK_KHR_get_physical_device_properties2 { get; } = "VK_KHR_get_physical_device_properties2";
        /// <summary>
        /// Gets the value of the vk khr portability subset
        /// </summary>
        public static FixedUtf8String VK_KHR_portability_subset { get; } = "VK_KHR_portability_subset";

        /// <summary>
        /// Gets the value of the vk khr portability enumeration
        /// </summary>
        public static FixedUtf8String VK_KHR_portability_enumeration { get; } = "VK_KHR_portability_enumeration";
    }
}
