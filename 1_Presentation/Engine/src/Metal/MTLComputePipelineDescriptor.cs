using System;
using static Veldrid.MetalBindings.ObjectiveCRuntime;

namespace Veldrid.MetalBindings
{
    /// <summary>
    /// The mtl compute pipeline descriptor
    /// </summary>
    public struct MTLComputePipelineDescriptor
    {
        /// <summary>
        /// The native ptr
        /// </summary>
        public readonly IntPtr NativePtr;

        /// <summary>
        /// Gets or sets the value of the compute function
        /// </summary>
        public MTLFunction computeFunction
        {
            get => objc_msgSend<MTLFunction>(NativePtr, sel_computeFunction);
            set => objc_msgSend(NativePtr, sel_setComputeFunction, value.NativePtr);
        }

        /// <summary>
        /// Gets the value of the buffers
        /// </summary>
        public MTLPipelineBufferDescriptorArray buffers
            => objc_msgSend<MTLPipelineBufferDescriptorArray>(NativePtr, sel_buffers);

        /// <summary>
        /// The sel computefunction
        /// </summary>
        private static readonly Selector sel_computeFunction = "computeFunction";
        /// <summary>
        /// The sel setcomputefunction
        /// </summary>
        private static readonly Selector sel_setComputeFunction = "setComputeFunction:";
        /// <summary>
        /// The sel buffers
        /// </summary>
        private static readonly Selector sel_buffers = "buffers";
    }
}