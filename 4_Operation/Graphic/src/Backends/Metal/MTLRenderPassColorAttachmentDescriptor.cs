using System;
using static Alis.Core.Graphic.Backends.Metal.ObjectiveCRuntime;

namespace Alis.Core.Graphic.Backends.Metal
{
    /// <summary>
    /// The mtl render pass color attachment descriptor
    /// </summary>
    public struct MTLRenderPassColorAttachmentDescriptor
    {
        /// <summary>
        /// The native ptr
        /// </summary>
        public readonly IntPtr NativePtr;
        /// <summary>
        /// Initializes a new instance of the <see cref="MTLRenderPassColorAttachmentDescriptor"/> class
        /// </summary>
        /// <param name="ptr">The ptr</param>
        public MTLRenderPassColorAttachmentDescriptor(IntPtr ptr) => NativePtr = ptr;

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
        /// Gets or sets the value of the resolve texture
        /// </summary>
        public MTLTexture resolveTexture
        {
            get => objc_msgSend<MTLTexture>(NativePtr, Selectors.resolveTexture);
            set => objc_msgSend(NativePtr, Selectors.setResolveTexture, value.NativePtr);
        }

        /// <summary>
        /// Gets or sets the value of the clear color
        /// </summary>
        public MTLClearColor clearColor
        {
            get
            {
                if (ObjectiveCRuntime.UseStret<MTLClearColor>())
                {
                    return objc_msgSend_stret<MTLClearColor>(NativePtr, sel_clearColor);
                }
                else
                {
                    return MTLClearColor_objc_msgSend(NativePtr,sel_clearColor);
                }
            }
            set => objc_msgSend(NativePtr, sel_setClearColor, value);
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
        /// The sel clearcolor
        /// </summary>
        private static readonly Selector sel_clearColor = "clearColor";
        /// <summary>
        /// The sel setclearcolor
        /// </summary>
        private static readonly Selector sel_setClearColor = "setClearColor:";
    }
}