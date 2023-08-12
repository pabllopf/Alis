using System;
using static Alis.Core.Graphic.Backends.Metal.ObjectiveCRuntime;

namespace Alis.Core.Graphic.Backends.Metal
{
    /// <summary>
    /// The mtl vertex buffer layout descriptor array
    /// </summary>
    public struct MTLVertexBufferLayoutDescriptorArray
    {
        /// <summary>
        /// The native ptr
        /// </summary>
        public readonly IntPtr NativePtr;

        /// <summary>
        /// The index
        /// </summary>
        public MTLVertexBufferLayoutDescriptor this[uint index]
        {
            get
            {
                IntPtr value = IntPtr_objc_msgSend(NativePtr, Selectors.objectAtIndexedSubscript, index);
                return new MTLVertexBufferLayoutDescriptor(value);
            }
            set => objc_msgSend(NativePtr, Selectors.setObjectAtIndexedSubscript, value.NativePtr, index);
        }
    }
}