using System;

namespace Veldrid.MetalBindings
{
    /// <summary>
    /// The mtl render pipeline state
    /// </summary>
    public struct MTLRenderPipelineState
    {
        /// <summary>
        /// The native ptr
        /// </summary>
        public readonly IntPtr NativePtr;
        /// <summary>
        /// Initializes a new instance of the <see cref="MTLRenderPipelineState"/> class
        /// </summary>
        /// <param name="ptr">The ptr</param>
        public MTLRenderPipelineState(IntPtr ptr) => NativePtr = ptr;
    }
}