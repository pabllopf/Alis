using System;
using static Veldrid.MetalBindings.ObjectiveCRuntime;

namespace Veldrid.MetalBindings
{
    /// <summary>
    /// The ui view
    /// </summary>
    public struct UIView
    {
        /// <summary>
        /// The native ptr
        /// </summary>
        public readonly IntPtr NativePtr;
        /// <summary>
        /// Initializes a new instance of the <see cref="UIView"/> class
        /// </summary>
        /// <param name="ptr">The ptr</param>
        public UIView(IntPtr ptr) => NativePtr = ptr;

        /// <summary>
        /// Gets the value of the layer
        /// </summary>
        public CALayer layer => objc_msgSend<CALayer>(NativePtr, "layer");

        /// <summary>
        /// Gets the value of the frame
        /// </summary>
        public CGRect frame => CGRect_objc_msgSend(NativePtr, "frame");
    }
}