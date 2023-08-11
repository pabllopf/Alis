using System;
using static Veldrid.MetalBindings.ObjectiveCRuntime;

namespace Veldrid.MetalBindings
{
    /// <summary>
    /// The ns window
    /// </summary>
    public unsafe struct NSWindow
    {
        /// <summary>
        /// The native ptr
        /// </summary>
        public readonly IntPtr NativePtr;
        /// <summary>
        /// Initializes a new instance of the <see cref="NSWindow"/> class
        /// </summary>
        /// <param name="ptr">The ptr</param>
        public NSWindow(IntPtr ptr)
        {
            NativePtr = ptr;
        }

        /// <summary>
        /// Gets the value of the content view
        /// </summary>
        public NSView contentView => objc_msgSend<NSView>(NativePtr, "contentView");
    }
}