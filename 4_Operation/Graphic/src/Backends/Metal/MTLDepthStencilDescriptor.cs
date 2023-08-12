using System;
using static Alis.Core.Graphic.Backends.Metal.ObjectiveCRuntime;

namespace Alis.Core.Graphic.Backends.Metal
{
    /// <summary>
    /// The mtl depth stencil descriptor
    /// </summary>
    public struct MTLDepthStencilDescriptor
    {
        /// <summary>
        /// The native ptr
        /// </summary>
        public readonly IntPtr NativePtr;
        /// <summary>
        /// Initializes a new instance of the <see cref="MTLDepthStencilDescriptor"/> class
        /// </summary>
        /// <param name="ptr">The ptr</param>
        public MTLDepthStencilDescriptor(IntPtr ptr) => NativePtr = ptr;

        /// <summary>
        /// Gets or sets the value of the depth compare function
        /// </summary>
        public MTLCompareFunction depthCompareFunction
        {
            get => (MTLCompareFunction)uint_objc_msgSend(NativePtr, sel_depthCompareFunction);
            set => objc_msgSend(NativePtr, sel_setDepthCompareFunction, (uint)value);
        }

        /// <summary>
        /// Gets or sets the value of the depth write enabled
        /// </summary>
        public Bool8 depthWriteEnabled
        {
            get => bool8_objc_msgSend(NativePtr, sel_isDepthWriteEnabled);
            set => objc_msgSend(NativePtr, sel_setDepthWriteEnabled, value);
        }

        /// <summary>
        /// Gets or sets the value of the back face stencil
        /// </summary>
        public MTLStencilDescriptor backFaceStencil
        {
            get => objc_msgSend<MTLStencilDescriptor>(NativePtr, sel_backFaceStencil);
            set => objc_msgSend(NativePtr, sel_setBackFaceStencil, value.NativePtr);
        }

        /// <summary>
        /// Gets or sets the value of the front face stencil
        /// </summary>
        public MTLStencilDescriptor frontFaceStencil
        {
            get => objc_msgSend<MTLStencilDescriptor>(NativePtr, sel_frontFaceStencil);
            set => objc_msgSend(NativePtr, sel_setFrontFaceStencil, value.NativePtr);
        }

        /// <summary>
        /// The sel depthcomparefunction
        /// </summary>
        private static readonly Selector sel_depthCompareFunction = "depthCompareFunction";
        /// <summary>
        /// The sel setdepthcomparefunction
        /// </summary>
        private static readonly Selector sel_setDepthCompareFunction = "setDepthCompareFunction:";
        /// <summary>
        /// The sel isdepthwriteenabled
        /// </summary>
        private static readonly Selector sel_isDepthWriteEnabled = "isDepthWriteEnabled";
        /// <summary>
        /// The sel setdepthwriteenabled
        /// </summary>
        private static readonly Selector sel_setDepthWriteEnabled = "setDepthWriteEnabled:";
        /// <summary>
        /// The sel backfacestencil
        /// </summary>
        private static readonly Selector sel_backFaceStencil = "backFaceStencil";
        /// <summary>
        /// The sel setbackfacestencil
        /// </summary>
        private static readonly Selector sel_setBackFaceStencil = "setBackFaceStencil:";
        /// <summary>
        /// The sel frontfacestencil
        /// </summary>
        private static readonly Selector sel_frontFaceStencil = "frontFaceStencil";
        /// <summary>
        /// The sel setfrontfacestencil
        /// </summary>
        private static readonly Selector sel_setFrontFaceStencil = "setFrontFaceStencil:";
    }
}