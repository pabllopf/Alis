using static Veldrid.MetalBindings.ObjectiveCRuntime;
using System;

namespace Veldrid.MetalBindings
{
    /// <summary>
    /// The mtl function
    /// </summary>
    public struct MTLFunction
    {
        /// <summary>
        /// The native ptr
        /// </summary>
        public readonly IntPtr NativePtr;
        /// <summary>
        /// Initializes a new instance of the <see cref="MTLFunction"/> class
        /// </summary>
        /// <param name="ptr">The ptr</param>
        public MTLFunction(IntPtr ptr) => NativePtr = ptr;

        /// <summary>
        /// Gets the value of the function constants dictionary
        /// </summary>
        public NSDictionary functionConstantsDictionary => objc_msgSend<NSDictionary>(NativePtr, sel_functionConstantsDictionary);

        /// <summary>
        /// The sel functionconstantsdictionary
        /// </summary>
        private static readonly Selector sel_functionConstantsDictionary = "functionConstantsDictionary";
    }
}