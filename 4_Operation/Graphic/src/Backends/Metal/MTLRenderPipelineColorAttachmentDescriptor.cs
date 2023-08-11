using System;
using System.Runtime.InteropServices;
using static Veldrid.MetalBindings.ObjectiveCRuntime;

namespace Veldrid.MetalBindings
{
    /// <summary>
    /// The mtl render pipeline color attachment descriptor
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct MTLRenderPipelineColorAttachmentDescriptor
    {
        /// <summary>
        /// The native ptr
        /// </summary>
        public readonly IntPtr NativePtr;

        /// <summary>
        /// Initializes a new instance of the <see cref="MTLRenderPipelineColorAttachmentDescriptor"/> class
        /// </summary>
        /// <param name="ptr">The ptr</param>
        public MTLRenderPipelineColorAttachmentDescriptor(IntPtr ptr) => NativePtr = ptr;

        /// <summary>
        /// Gets or sets the value of the pixel format
        /// </summary>
        public MTLPixelFormat pixelFormat
        {
            get => (MTLPixelFormat)uint_objc_msgSend(NativePtr, Selectors.pixelFormat);
            set => objc_msgSend(NativePtr, Selectors.setPixelFormat, (uint)value);
        }

        /// <summary>
        /// Gets or sets the value of the write mask
        /// </summary>
        public MTLColorWriteMask writeMask
        {
            get => (MTLColorWriteMask)uint_objc_msgSend(NativePtr, sel_writeMask);
            set => objc_msgSend(NativePtr, sel_setWriteMask, (uint)value);
        }

        /// <summary>
        /// Gets or sets the value of the blending enabled
        /// </summary>
        public Bool8 blendingEnabled
        {
            get => bool8_objc_msgSend(NativePtr, sel_isBlendingEnabled);
            set => objc_msgSend(NativePtr, sel_setBlendingEnabled, value);
        }

        /// <summary>
        /// Gets or sets the value of the alpha blend operation
        /// </summary>
        public MTLBlendOperation alphaBlendOperation
        {
            get => (MTLBlendOperation)uint_objc_msgSend(NativePtr, sel_alphaBlendOperation);
            set => objc_msgSend(NativePtr, sel_setAlphaBlendOperation, (uint)value);
        }

        /// <summary>
        /// Gets or sets the value of the rgb blend operation
        /// </summary>
        public MTLBlendOperation rgbBlendOperation
        {
            get => (MTLBlendOperation)uint_objc_msgSend(NativePtr, sel_rgbBlendOperation);
            set => objc_msgSend(NativePtr, sel_setRGBBlendOperation, (uint)value);
        }

        /// <summary>
        /// Gets or sets the value of the destination alpha blend factor
        /// </summary>
        public MTLBlendFactor destinationAlphaBlendFactor
        {
            get => (MTLBlendFactor)uint_objc_msgSend(NativePtr, sel_destinationAlphaBlendFactor);
            set => objc_msgSend(NativePtr, sel_setDestinationAlphaBlendFactor, (uint)value);
        }

        /// <summary>
        /// Gets or sets the value of the destination rgb blend factor
        /// </summary>
        public MTLBlendFactor destinationRGBBlendFactor
        {
            get => (MTLBlendFactor)uint_objc_msgSend(NativePtr, sel_destinationRGBBlendFactor);
            set => objc_msgSend(NativePtr, sel_setDestinationRGBBlendFactor, (uint)value);
        }

        /// <summary>
        /// Gets or sets the value of the source alpha blend factor
        /// </summary>
        public MTLBlendFactor sourceAlphaBlendFactor
        {
            get => (MTLBlendFactor)uint_objc_msgSend(NativePtr, sel_sourceAlphaBlendFactor);
            set => objc_msgSend(NativePtr, sel_setSourceAlphaBlendFactor, (uint)value);
        }

        /// <summary>
        /// Gets or sets the value of the source rgb blend factor
        /// </summary>
        public MTLBlendFactor sourceRGBBlendFactor
        {
            get => (MTLBlendFactor)uint_objc_msgSend(NativePtr, sel_sourceRGBBlendFactor);
            set => objc_msgSend(NativePtr, sel_setSourceRGBBlendFactor, (uint)value);
        }

        /// <summary>
        /// The sel isblendingenabled
        /// </summary>
        private static readonly Selector sel_isBlendingEnabled = "isBlendingEnabled";
        /// <summary>
        /// The sel setblendingenabled
        /// </summary>
        private static readonly Selector sel_setBlendingEnabled = "setBlendingEnabled:";
        /// <summary>
        /// The sel writemask
        /// </summary>
        private static readonly Selector sel_writeMask = "writeMask";
        /// <summary>
        /// The sel setwritemask
        /// </summary>
        private static readonly Selector sel_setWriteMask = "setWriteMask:";
        /// <summary>
        /// The sel alphablendoperation
        /// </summary>
        private static readonly Selector sel_alphaBlendOperation = "alphaBlendOperation";
        /// <summary>
        /// The sel setalphablendoperation
        /// </summary>
        private static readonly Selector sel_setAlphaBlendOperation = "setAlphaBlendOperation:";
        /// <summary>
        /// The sel rgbblendoperation
        /// </summary>
        private static readonly Selector sel_rgbBlendOperation = "rgbBlendOperation";
        /// <summary>
        /// The sel setrgbblendoperation
        /// </summary>
        private static readonly Selector sel_setRGBBlendOperation = "setRgbBlendOperation:";
        /// <summary>
        /// The sel destinationalphablendfactor
        /// </summary>
        private static readonly Selector sel_destinationAlphaBlendFactor = "destinationAlphaBlendFactor";
        /// <summary>
        /// The sel setdestinationalphablendfactor
        /// </summary>
        private static readonly Selector sel_setDestinationAlphaBlendFactor = "setDestinationAlphaBlendFactor:";
        /// <summary>
        /// The sel destinationrgbblendfactor
        /// </summary>
        private static readonly Selector sel_destinationRGBBlendFactor = "destinationRGBBlendFactor";
        /// <summary>
        /// The sel setdestinationrgbblendfactor
        /// </summary>
        private static readonly Selector sel_setDestinationRGBBlendFactor = "setDestinationRGBBlendFactor:";
        /// <summary>
        /// The sel sourcealphablendfactor
        /// </summary>
        private static readonly Selector sel_sourceAlphaBlendFactor = "sourceAlphaBlendFactor";
        /// <summary>
        /// The sel setsourcealphablendfactor
        /// </summary>
        private static readonly Selector sel_setSourceAlphaBlendFactor = "setSourceAlphaBlendFactor:";
        /// <summary>
        /// The sel sourcergbblendfactor
        /// </summary>
        private static readonly Selector sel_sourceRGBBlendFactor = "sourceRGBBlendFactor";
        /// <summary>
        /// The sel setsourcergbblendfactor
        /// </summary>
        private static readonly Selector sel_setSourceRGBBlendFactor = "setSourceRGBBlendFactor:";
    }
}