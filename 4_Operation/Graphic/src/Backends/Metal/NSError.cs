using System;
using static Veldrid.MetalBindings.ObjectiveCRuntime;

namespace Veldrid.MetalBindings
{
    /// <summary>
    /// The ns error
    /// </summary>
    public struct NSError
    {
        /// <summary>
        /// The native ptr
        /// </summary>
        public readonly IntPtr NativePtr;
        /// <summary>
        /// Gets the value of the domain
        /// </summary>
        public string domain => string_objc_msgSend(NativePtr, "domain");
        /// <summary>
        /// Gets the value of the localized description
        /// </summary>
        public string localizedDescription => string_objc_msgSend(NativePtr, "localizedDescription");
    }
}