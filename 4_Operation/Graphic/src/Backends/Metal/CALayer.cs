using System;
using static Alis.Core.Graphic.Backends.Metal.ObjectiveCRuntime;

namespace Alis.Core.Graphic.Backends.Metal
{
    /// <summary>
    /// The ca layer
    /// </summary>
    public struct CALayer
    {
        /// <summary>
        /// The native ptr
        /// </summary>
        public readonly IntPtr NativePtr;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        public static implicit operator IntPtr(CALayer c) => c.NativePtr;

        /// <summary>
        /// Initializes a new instance of the <see cref="CALayer"/> class
        /// </summary>
        /// <param name="ptr">The ptr</param>
        public CALayer(IntPtr ptr) => NativePtr = ptr;

        /// <summary>
        /// Adds the sublayer using the specified layer
        /// </summary>
        /// <param name="layer">The layer</param>
        public void addSublayer(IntPtr layer)
        {
            objc_msgSend(NativePtr, "addSublayer:", layer);
        }
    }
}