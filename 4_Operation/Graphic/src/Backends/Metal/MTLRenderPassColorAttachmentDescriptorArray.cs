using System;
using System.Runtime.InteropServices;
using static Alis.Core.Graphic.Backends.Metal.ObjectiveCRuntime;

namespace Alis.Core.Graphic.Backends.Metal
{
    /// <summary>
    /// The mtl render pass color attachment descriptor array
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct MTLRenderPassColorAttachmentDescriptorArray
    {
        /// <summary>
        /// The native ptr
        /// </summary>
        public readonly IntPtr NativePtr;

        /// <summary>
        /// The index
        /// </summary>
        public MTLRenderPassColorAttachmentDescriptor this[uint index]
        {
            get
            {
                IntPtr value = IntPtr_objc_msgSend(NativePtr, Selectors.objectAtIndexedSubscript, (UIntPtr)index);
                return new MTLRenderPassColorAttachmentDescriptor(value);
            }
            set
            {
                objc_msgSend(NativePtr, Selectors.setObjectAtIndexedSubscript, value.NativePtr, (UIntPtr)index);
            }
        }
    }
}