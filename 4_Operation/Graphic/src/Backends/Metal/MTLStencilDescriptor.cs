using System;
using static Alis.Core.Graphic.Backends.Metal.ObjectiveCRuntime;

namespace Alis.Core.Graphic.Backends.Metal
{
    /// <summary>
    /// The mtl stencil descriptor
    /// </summary>
    public struct MTLStencilDescriptor
    {
        /// <summary>
        /// The native ptr
        /// </summary>
        public readonly IntPtr NativePtr;

        /// <summary>
        /// Gets or sets the value of the stencil failure operation
        /// </summary>
        public MTLStencilOperation stencilFailureOperation
        {
            get => (MTLStencilOperation)uint_objc_msgSend(NativePtr, sel_stencilFailureOperation);
            set => objc_msgSend(NativePtr, sel_setStencilFailureOperation, (uint)value);
        }

        /// <summary>
        /// Gets or sets the value of the depth failure operation
        /// </summary>
        public MTLStencilOperation depthFailureOperation
        {
            get => (MTLStencilOperation)uint_objc_msgSend(NativePtr, sel_depthFailureOperation);
            set => objc_msgSend(NativePtr, sel_setDepthFailureOperation, (uint)value);
        }

        /// <summary>
        /// Gets or sets the value of the depth stencil pass operation
        /// </summary>
        public MTLStencilOperation depthStencilPassOperation
        {
            get => (MTLStencilOperation)uint_objc_msgSend(NativePtr, sel_depthStencilPassOperation);
            set => objc_msgSend(NativePtr, sel_setDepthStencilPassOperation, (uint)value);
        }

        /// <summary>
        /// Gets or sets the value of the stencil compare function
        /// </summary>
        public MTLCompareFunction stencilCompareFunction
        {
            get => (MTLCompareFunction)uint_objc_msgSend(NativePtr, sel_stencilCompareFunction);
            set => objc_msgSend(NativePtr, sel_setStencilCompareFunction, (uint)value);
        }

        /// <summary>
        /// Gets or sets the value of the read mask
        /// </summary>
        public uint readMask
        {
            get => uint_objc_msgSend(NativePtr, sel_readMask);
            set => objc_msgSend(NativePtr, sel_setReadMask, value);
        }

        /// <summary>
        /// Gets or sets the value of the write mask
        /// </summary>
        public uint writeMask
        {
            get => uint_objc_msgSend(NativePtr, sel_writeMask);
            set => objc_msgSend(NativePtr, sel_setWriteMask, value);
        }

        /// <summary>
        /// The sel depthfailureoperation
        /// </summary>
        private static readonly Selector sel_depthFailureOperation = "depthFailureOperation";
        /// <summary>
        /// The sel stencilfailureoperation
        /// </summary>
        private static readonly Selector sel_stencilFailureOperation = "stencilFailureOperation";
        /// <summary>
        /// The sel setstencilfailureoperation
        /// </summary>
        private static readonly Selector sel_setStencilFailureOperation = "setStencilFailureOperation:";
        /// <summary>
        /// The sel setdepthfailureoperation
        /// </summary>
        private static readonly Selector sel_setDepthFailureOperation = "setDepthFailureOperation:";
        /// <summary>
        /// The sel depthstencilpassoperation
        /// </summary>
        private static readonly Selector sel_depthStencilPassOperation = "depthStencilPassOperation";
        /// <summary>
        /// The sel setdepthstencilpassoperation
        /// </summary>
        private static readonly Selector sel_setDepthStencilPassOperation = "setDepthStencilPassOperation:";
        /// <summary>
        /// The sel stencilcomparefunction
        /// </summary>
        private static readonly Selector sel_stencilCompareFunction = "stencilCompareFunction";
        /// <summary>
        /// The sel setstencilcomparefunction
        /// </summary>
        private static readonly Selector sel_setStencilCompareFunction = "setStencilCompareFunction:";
        /// <summary>
        /// The sel readmask
        /// </summary>
        private static readonly Selector sel_readMask = "readMask";
        /// <summary>
        /// The sel setreadmask
        /// </summary>
        private static readonly Selector sel_setReadMask = "setReadMask:";
        /// <summary>
        /// The sel writemask
        /// </summary>
        private static readonly Selector sel_writeMask = "writeMask";
        /// <summary>
        /// The sel setwritemask
        /// </summary>
        private static readonly Selector sel_setWriteMask = "setWriteMask:";
    }
}