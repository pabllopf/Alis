using System;

namespace Veldrid.MetalBindings
{
    /// <summary>
    /// The ns autorelease pool
    /// </summary>
    public struct NSAutoreleasePool : IDisposable
    {
        /// <summary>
        /// The ns autorelease pool
        /// </summary>
        private static readonly ObjCClass s_class = new ObjCClass(nameof(NSAutoreleasePool));
        /// <summary>
        /// The native ptr
        /// </summary>
        public readonly IntPtr NativePtr;
        /// <summary>
        /// Initializes a new instance of the <see cref="NSAutoreleasePool"/> class
        /// </summary>
        /// <param name="ptr">The ptr</param>
        public NSAutoreleasePool(IntPtr ptr) => NativePtr = ptr;

        /// <summary>
        /// Begins
        /// </summary>
        /// <returns>The ns autorelease pool</returns>
        public static NSAutoreleasePool Begin()
        {
            return s_class.AllocInit<NSAutoreleasePool>();
        }

        /// <summary>
        /// Disposes this instance
        /// </summary>
        public void Dispose()
        {
            ObjectiveCRuntime.release(this.NativePtr);
        }
    }
}