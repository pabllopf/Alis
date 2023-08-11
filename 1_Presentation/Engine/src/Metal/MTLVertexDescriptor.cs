using System;
using static Veldrid.MetalBindings.ObjectiveCRuntime;

namespace Veldrid.MetalBindings
{
    /// <summary>
    /// The mtl vertex descriptor
    /// </summary>
    public unsafe struct MTLVertexDescriptor
    {
        /// <summary>
        /// The native ptr
        /// </summary>
        public readonly IntPtr NativePtr;

        /// <summary>
        /// Gets the value of the layouts
        /// </summary>
        public MTLVertexBufferLayoutDescriptorArray layouts
            => objc_msgSend<MTLVertexBufferLayoutDescriptorArray>(NativePtr, sel_layouts);

        /// <summary>
        /// Gets the value of the attributes
        /// </summary>
        public MTLVertexAttributeDescriptorArray attributes
            => objc_msgSend<MTLVertexAttributeDescriptorArray>(NativePtr, sel_attributes);

        /// <summary>
        /// The sel layouts
        /// </summary>
        private static readonly Selector sel_layouts = "layouts";
        /// <summary>
        /// The sel attributes
        /// </summary>
        private static readonly Selector sel_attributes = "attributes";
    }
}