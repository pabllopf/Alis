using System;
using static Veldrid.MetalBindings.ObjectiveCRuntime;

namespace Veldrid.MetalBindings
{
    /// <summary>
    /// The mtl render pass depth attachment descriptor
    /// </summary>
    public struct MTLRenderPassDepthAttachmentDescriptor
    {
        /// <summary>
        /// The native ptr
        /// </summary>
        public readonly IntPtr NativePtr;

        /// <summary>
        /// Initializes a new instance of the <see cref="MTLRenderPassDepthAttachmentDescriptor"/> class
        /// </summary>
        /// <param name="ptr">The ptr</param>
        public MTLRenderPassDepthAttachmentDescriptor(IntPtr ptr) => NativePtr = ptr;

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
        /// Gets or sets the value of the clear depth
        /// </summary>
        public double clearDepth
        {
            get => double_objc_msgSend(NativePtr, sel_clearDepth);
            set => objc_msgSend(NativePtr, sel_setClearDepth, value);
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
        /// Gets or sets the value of the level
        /// </summary>
        public UIntPtr level
        {
            get => UIntPtr_objc_msgSend(NativePtr, Selectors.level);
            set => objc_msgSend(NativePtr, Selectors.setLevel, value);
        }

        /// <summary>
        /// The sel cleardepth
        /// </summary>
        private static readonly Selector sel_clearDepth = "clearDepth";
        /// <summary>
        /// The sel setcleardepth
        /// </summary>
        private static readonly Selector sel_setClearDepth = "setClearDepth:";
    }
}