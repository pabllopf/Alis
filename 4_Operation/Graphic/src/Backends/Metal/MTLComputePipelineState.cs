using System;

namespace Veldrid.MetalBindings
{
    /// <summary>
    /// The mtl compute pipeline state
    /// </summary>
    public struct MTLComputePipelineState
    {
        /// <summary>
        /// The native ptr
        /// </summary>
        public readonly IntPtr NativePtr;
        /// <summary>
        /// Initializes a new instance of the <see cref="MTLComputePipelineState"/> class
        /// </summary>
        /// <param name="ptr">The ptr</param>
        public MTLComputePipelineState(IntPtr ptr) => NativePtr = ptr;
        /// <summary>
        /// Gets the value of the is null
        /// </summary>
        public bool IsNull => NativePtr == IntPtr.Zero;
    }
}