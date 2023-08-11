using System;

namespace Veldrid.MetalBindings
{
    /// <summary>
    /// The ns dictionary
    /// </summary>
    public struct NSDictionary
    {
        /// <summary>
        /// The native ptr
        /// </summary>
        public readonly IntPtr NativePtr;

        /// <summary>
        /// Gets the value of the count
        /// </summary>
        public UIntPtr count => ObjectiveCRuntime.UIntPtr_objc_msgSend(NativePtr, "count");
    }
}