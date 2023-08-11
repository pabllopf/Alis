using System;
using System.Runtime.InteropServices;
using static Veldrid.MetalBindings.ObjectiveCRuntime;

namespace Veldrid.MetalBindings
{
    /// <summary>
    /// The ca metal drawable
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct CAMetalDrawable
    {
        /// <summary>
        /// The native ptr
        /// </summary>
        public readonly IntPtr NativePtr;
        /// <summary>
        /// Gets the value of the is null
        /// </summary>
        public bool IsNull => NativePtr == IntPtr.Zero;
        /// <summary>
        /// Gets the value of the texture
        /// </summary>
        public MTLTexture texture => objc_msgSend<MTLTexture>(NativePtr, Selectors.texture);
    }
}