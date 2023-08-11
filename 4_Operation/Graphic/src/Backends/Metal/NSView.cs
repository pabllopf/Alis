using System;
using System.Runtime.InteropServices;
using static Veldrid.MetalBindings.ObjectiveCRuntime;

namespace Veldrid.MetalBindings
{
    /// <summary>
    /// The ns view
    /// </summary>
    public unsafe struct NSView
    {
        /// <summary>
        /// The native ptr
        /// </summary>
        public readonly IntPtr NativePtr;
        public static implicit operator IntPtr(NSView nsView) => nsView.NativePtr;

        /// <summary>
        /// Initializes a new instance of the <see cref="NSView"/> class
        /// </summary>
        /// <param name="ptr">The ptr</param>
        public NSView(IntPtr ptr) => NativePtr = ptr;

        /// <summary>
        /// Gets or sets the value of the wants layer
        /// </summary>
        public Bool8 wantsLayer
        {
            get => bool8_objc_msgSend(NativePtr, "wantsLayer");
            set => objc_msgSend(NativePtr, "setWantsLayer:", value);
        }

        /// <summary>
        /// Gets or sets the value of the layer
        /// </summary>
        public IntPtr layer
        {
            get => IntPtr_objc_msgSend(NativePtr, "layer");
            set => objc_msgSend(NativePtr, "setLayer:", value);
        }

        /// <summary>
        /// Gets the value of the frame
        /// </summary>
        public CGRect frame
        {
            get
            {
                return RuntimeInformation.ProcessArchitecture == Architecture.Arm64
                    ? CGRect_objc_msgSend(NativePtr, "frame")
                    : objc_msgSend_stret<CGRect>(NativePtr, "frame");
            }
        }
    }
}