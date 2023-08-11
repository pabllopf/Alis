using System;
using static Veldrid.MetalBindings.ObjectiveCRuntime;

namespace Veldrid.MetalBindings
{
    /// <summary>
    /// The mtl render pass stencil attachment descriptor
    /// </summary>
    public struct MTLRenderPassStencilAttachmentDescriptor
    {
        /// <summary>
        /// The native ptr
        /// </summary>
        public readonly IntPtr NativePtr;

        /// <summary>
        /// Gets or sets the value of the texture
        /// </summary>
        public MTLTexture texture
        {
            get => objc_msgSend<MTLTexture>(NativePtr, Selectors.texture);
            set => objc_msgSend(NativePtr, Selectors.setTexture, value.NativePtr);
        }

        /// <summary>
        /// Gets or sets the value of the load action
        /// </summary>
        public MTLLoadAction loadAction
        {
            get => (MTLLoadAction)uint_objc_msgSend(NativePtr, Selectors.loadAction);
            set => objc_msgSend(NativePtr, Selectors.setLoadAction, (uint)value);
        }

        /// <summary>
        /// Gets or sets the value of the store action
        /// </summary>
        public MTLStoreAction storeAction
        {
            get => (MTLStoreAction)uint_objc_msgSend(NativePtr, Selectors.storeAction);
            set => objc_msgSend(NativePtr, Selectors.setStoreAction, (uint)value);
        }

        /// <summary>
        /// Gets or sets the value of the clear stencil
        /// </summary>
        public uint clearStencil
        {
            get => uint_objc_msgSend(NativePtr, sel_clearStencil);
            set => objc_msgSend(NativePtr, sel_setClearStencil, value);
        }

        /// <summary>
        /// Gets or sets the value of the slice
        /// </summary>
        public UIntPtr slice
        {
            get => UIntPtr_objc_msgSend(NativePtr, Selectors.slice);
            set => objc_msgSend(NativePtr, Selectors.setSlice, value);
        }

        /// <summary>
        /// The sel clearstencil
        /// </summary>
        private static readonly Selector sel_clearStencil = "clearStencil";
        /// <summary>
        /// The sel setclearstencil
        /// </summary>
        private static readonly Selector sel_setClearStencil = "setClearStencil:";
    }
}