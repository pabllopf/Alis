using System;
using static Veldrid.MetalBindings.ObjectiveCRuntime;

namespace Veldrid.MetalBindings
{
    /// <summary>
    /// The mtl vertex attribute descriptor
    /// </summary>
    public struct MTLVertexAttributeDescriptor
    {
        /// <summary>
        /// The native ptr
        /// </summary>
        public readonly IntPtr NativePtr;

        /// <summary>
        /// Initializes a new instance of the <see cref="MTLVertexAttributeDescriptor"/> class
        /// </summary>
        /// <param name="ptr">The ptr</param>
        public MTLVertexAttributeDescriptor(IntPtr ptr) => NativePtr = ptr;

        /// <summary>
        /// Gets or sets the value of the format
        /// </summary>
        public MTLVertexFormat format
        {
            get => (MTLVertexFormat)uint_objc_msgSend(NativePtr, sel_format);
            set => objc_msgSend(NativePtr, sel_setFormat, (uint)value);
        }

        /// <summary>
        /// Gets or sets the value of the offset
        /// </summary>
        public UIntPtr offset
        {
            get => UIntPtr_objc_msgSend(NativePtr, sel_offset);
            set => objc_msgSend(NativePtr, sel_setOffset, value);
        }

        /// <summary>
        /// Gets or sets the value of the buffer index
        /// </summary>
        public UIntPtr bufferIndex
        {
            get => UIntPtr_objc_msgSend(NativePtr, sel_bufferIndex);
            set => objc_msgSend(NativePtr, sel_setBufferIndex, value);
        }

        /// <summary>
        /// The sel format
        /// </summary>
        private static readonly Selector sel_format = "format";
        /// <summary>
        /// The sel setformat
        /// </summary>
        private static readonly Selector sel_setFormat = "setFormat:";
        /// <summary>
        /// The sel offset
        /// </summary>
        private static readonly Selector sel_offset = "offset";
        /// <summary>
        /// The sel setoffset
        /// </summary>
        private static readonly Selector sel_setOffset = "setOffset:";
        /// <summary>
        /// The sel bufferindex
        /// </summary>
        private static readonly Selector sel_bufferIndex = "bufferIndex";
        /// <summary>
        /// The sel setbufferindex
        /// </summary>
        private static readonly Selector sel_setBufferIndex = "setBufferIndex:";
    }
}