using System;
using static Alis.Core.Graphic.Backends.Metal.ObjectiveCRuntime;

namespace Alis.Core.Graphic.Backends.Metal
{
    /// <summary>
    /// The ca metal layer
    /// </summary>
    public struct CAMetalLayer
    {
        /// <summary>
        /// The native ptr
        /// </summary>
        public readonly IntPtr NativePtr;

        /// <summary>
        /// Initializes a new instance of the <see cref="CAMetalLayer"/> class
        /// </summary>
        /// <param name="ptr">The ptr</param>
        public CAMetalLayer(IntPtr ptr) => NativePtr = ptr;

        /// <summary>
        /// News
        /// </summary>
        /// <returns>The ca metal layer</returns>
        public static CAMetalLayer New() => s_class.AllocInit<CAMetalLayer>();

        /// <summary>
        /// Describes whether try cast
        /// </summary>
        /// <param name="layerPointer">The layer pointer</param>
        /// <param name="metalLayer">The metal layer</param>
        /// <returns>The bool</returns>
        public static bool TryCast(IntPtr layerPointer, out CAMetalLayer metalLayer)
        {
            var layerObject = new NSObject(layerPointer);

            if (layerObject.IsKindOfClass(s_class))
            {
                metalLayer = new CAMetalLayer(layerPointer);
                return true;
            }

            metalLayer = default;
            return false;
        }

        /// <summary>
        /// Gets or sets the value of the device
        /// </summary>
        public MTLDevice device
        {
            get => objc_msgSend<MTLDevice>(NativePtr, sel_device);
            set => objc_msgSend(NativePtr, sel_setDevice, value);
        }

        /// <summary>
        /// Gets or sets the value of the pixel format
        /// </summary>
        public MTLPixelFormat pixelFormat
        {
            get => (MTLPixelFormat)uint_objc_msgSend(NativePtr, sel_pixelFormat);
            set => objc_msgSend(NativePtr, sel_setPixelFormat, (uint)value);
        }

        /// <summary>
        /// Gets or sets the value of the framebuffer only
        /// </summary>
        public Bool8 framebufferOnly
        {
            get => bool8_objc_msgSend(NativePtr, sel_framebufferOnly);
            set => objc_msgSend(NativePtr, sel_setFramebufferOnly, value);
        }

        /// <summary>
        /// Gets or sets the value of the drawable size
        /// </summary>
        public CGSize drawableSize
        {
            get => CGSize_objc_msgSend(NativePtr, sel_drawableSize);
            set => objc_msgSend(NativePtr, sel_setDrawableSize, value);
        }

        /// <summary>
        /// Gets or sets the value of the frame
        /// </summary>
        public CGRect frame
        {
            get => CGRect_objc_msgSend(NativePtr, "frame");
            set => objc_msgSend(NativePtr, "setFrame:", value);
        }

        /// <summary>
        /// Gets or sets the value of the opaque
        /// </summary>
        public Bool8 opaque
        {
            get => bool8_objc_msgSend(NativePtr, "isOpaque");
            set => objc_msgSend(NativePtr, "setOpaque:", value);
        }

        /// <summary>
        /// Nexts the drawable
        /// </summary>
        /// <returns>The ca metal drawable</returns>
        public CAMetalDrawable nextDrawable() => objc_msgSend<CAMetalDrawable>(NativePtr, sel_nextDrawable);

        /// <summary>
        /// Gets or sets the value of the display sync enabled
        /// </summary>
        public Bool8 displaySyncEnabled
        {
            get => bool8_objc_msgSend(NativePtr, "displaySyncEnabled");
            set => objc_msgSend(NativePtr, "setDisplaySyncEnabled:", value);
        }

        /// <summary>
        /// The ca metal layer
        /// </summary>
        private static readonly ObjCClass s_class = new ObjCClass(nameof(CAMetalLayer));
        /// <summary>
        /// The sel device
        /// </summary>
        private static readonly Selector sel_device = "device";
        /// <summary>
        /// The sel setdevice
        /// </summary>
        private static readonly Selector sel_setDevice = "setDevice:";
        /// <summary>
        /// The sel pixelformat
        /// </summary>
        private static readonly Selector sel_pixelFormat = "pixelFormat";
        /// <summary>
        /// The sel setpixelformat
        /// </summary>
        private static readonly Selector sel_setPixelFormat = "setPixelFormat:";
        /// <summary>
        /// The sel framebufferonly
        /// </summary>
        private static readonly Selector sel_framebufferOnly = "framebufferOnly";
        /// <summary>
        /// The sel setframebufferonly
        /// </summary>
        private static readonly Selector sel_setFramebufferOnly = "setFramebufferOnly:";
        /// <summary>
        /// The sel drawablesize
        /// </summary>
        private static readonly Selector sel_drawableSize = "drawableSize";
        /// <summary>
        /// The sel setdrawablesize
        /// </summary>
        private static readonly Selector sel_setDrawableSize = "setDrawableSize:";
        /// <summary>
        /// The sel nextdrawable
        /// </summary>
        private static readonly Selector sel_nextDrawable = "nextDrawable";
    }
}