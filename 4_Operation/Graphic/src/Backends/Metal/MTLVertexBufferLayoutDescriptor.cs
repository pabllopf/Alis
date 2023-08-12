using System;
using static Alis.Core.Graphic.Backends.Metal.ObjectiveCRuntime;

namespace Alis.Core.Graphic.Backends.Metal
{
    /// <summary>
    /// The mtl vertex buffer layout descriptor
    /// </summary>
    public struct MTLVertexBufferLayoutDescriptor
    {
        /// <summary>
        /// The native ptr
        /// </summary>
        public readonly IntPtr NativePtr;

        /// <summary>
        /// Initializes a new instance of the <see cref="MTLVertexBufferLayoutDescriptor"/> class
        /// </summary>
        /// <param name="ptr">The ptr</param>
        public MTLVertexBufferLayoutDescriptor(IntPtr ptr) => NativePtr = ptr;

        /// <summary>
        /// Gets or sets the value of the step function
        /// </summary>
        public MTLVertexStepFunction stepFunction
        {
            get => (MTLVertexStepFunction)uint_objc_msgSend(NativePtr, sel_stepFunction);
            set => objc_msgSend(NativePtr, sel_setStepFunction, (uint)value);
        }

        /// <summary>
        /// Gets or sets the value of the stride
        /// </summary>
        public UIntPtr stride
        {
            get => UIntPtr_objc_msgSend(NativePtr, sel_stride);
            set => objc_msgSend(NativePtr, sel_setStride, value);
        }

        /// <summary>
        /// Gets or sets the value of the step rate
        /// </summary>
        public UIntPtr stepRate
        {
            get => UIntPtr_objc_msgSend(NativePtr, sel_stepRate);
            set => objc_msgSend(NativePtr, sel_setStepRate, value);
        }

        /// <summary>
        /// The sel stepfunction
        /// </summary>
        private static readonly Selector sel_stepFunction = "stepFunction";
        /// <summary>
        /// The sel setstepfunction
        /// </summary>
        private static readonly Selector sel_setStepFunction = "setStepFunction:";
        /// <summary>
        /// The sel stride
        /// </summary>
        private static readonly Selector sel_stride = "stride";
        /// <summary>
        /// The sel setstride
        /// </summary>
        private static readonly Selector sel_setStride = "setStride:";
        /// <summary>
        /// The sel steprate
        /// </summary>
        private static readonly Selector sel_stepRate = "stepRate";
        /// <summary>
        /// The sel setsteprate
        /// </summary>
        private static readonly Selector sel_setStepRate = "setStepRate:";
    }
}