using System;
using static Alis.Core.Graphic.Backends.Metal.ObjectiveCRuntime;

namespace Alis.Core.Graphic.Backends.Metal
{
    /// <summary>
    /// The ns object
    /// </summary>
    public struct NSObject
    {
        /// <summary>
        /// The native ptr
        /// </summary>
        public readonly IntPtr NativePtr;

        /// <summary>
        /// Initializes a new instance of the <see cref="NSObject"/> class
        /// </summary>
        /// <param name="ptr">The ptr</param>
        public NSObject(IntPtr ptr) => NativePtr = ptr;

        /// <summary>
        /// Ises the kind of using the specified class
        /// </summary>
        /// <param name="class">The class</param>
        /// <returns>The bool</returns>
        public Bool8 IsKindOfClass(IntPtr @class) => bool8_objc_msgSend(NativePtr, sel_isKindOfClass, @class);

        /// <summary>
        /// The sel iskindof
        /// </summary>
        private static readonly Selector sel_isKindOfClass = "isKindOfClass:";
    }
}
