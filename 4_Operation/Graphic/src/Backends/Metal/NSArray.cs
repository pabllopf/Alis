using System;
using static Alis.Core.Graphic.Backends.Metal.ObjectiveCRuntime;

namespace Alis.Core.Graphic.Backends.Metal
{
    /// <summary>
    /// The ns array
    /// </summary>
    public struct NSArray
    {
        /// <summary>
        /// The native ptr
        /// </summary>
        public readonly IntPtr NativePtr;
        /// <summary>
        /// Initializes a new instance of the <see cref="NSArray"/> class
        /// </summary>
        /// <param name="ptr">The ptr</param>
        public NSArray(IntPtr ptr) => NativePtr = ptr;

        /// <summary>
        /// Gets the value of the count
        /// </summary>
        public UIntPtr count => UIntPtr_objc_msgSend(NativePtr, sel_count);
        /// <summary>
        /// The sel count
        /// </summary>
        private static readonly Selector sel_count = "count";
    }
}