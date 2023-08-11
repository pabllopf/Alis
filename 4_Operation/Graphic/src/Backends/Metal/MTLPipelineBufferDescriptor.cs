using System;
using static Veldrid.MetalBindings.ObjectiveCRuntime;

namespace Veldrid.MetalBindings
{
    /// <summary>
    /// The mtl pipeline buffer descriptor
    /// </summary>
    public struct MTLPipelineBufferDescriptor
    {
        /// <summary>
        /// The native ptr
        /// </summary>
        public readonly IntPtr NativePtr;

        /// <summary>
        /// Initializes a new instance of the <see cref="MTLPipelineBufferDescriptor"/> class
        /// </summary>
        /// <param name="ptr">The ptr</param>
        public MTLPipelineBufferDescriptor(IntPtr ptr) => NativePtr = ptr;

        /// <summary>
        /// Gets or sets the value of the mutability
        /// </summary>
        public MTLMutability mutability
        {
            get => (MTLMutability)uint_objc_msgSend(NativePtr, sel_mutability);
            set => objc_msgSend(NativePtr, sel_setMutability, (uint)value);
        }

        /// <summary>
        /// The sel mutability
        /// </summary>
        private static readonly Selector sel_mutability = "mutability";
        /// <summary>
        /// The sel setmutability
        /// </summary>
        private static readonly Selector sel_setMutability = "setMutability:";
    }
}