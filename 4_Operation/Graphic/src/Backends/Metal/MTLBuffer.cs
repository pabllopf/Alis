using System;
using System.Runtime.InteropServices;

namespace Alis.Core.Graphic.Backends.Metal
{
    /// <summary>
    /// The mtl buffer
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct MTLBuffer
    {
        /// <summary>
        /// The native ptr
        /// </summary>
        public readonly IntPtr NativePtr;
        /// <summary>
        /// Initializes a new instance of the <see cref="MTLBuffer"/> class
        /// </summary>
        /// <param name="ptr">The ptr</param>
        public MTLBuffer(IntPtr ptr) => NativePtr = ptr;
        /// <summary>
        /// Gets the value of the is null
        /// </summary>
        public bool IsNull => NativePtr == IntPtr.Zero;

        /// <summary>
        /// Contentses this instance
        /// </summary>
        /// <returns>The void</returns>
        public void* contents() => ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_contents).ToPointer();

        /// <summary>
        /// Gets the value of the length
        /// </summary>
        public UIntPtr length => ObjectiveCRuntime.UIntPtr_objc_msgSend(NativePtr, sel_length);

        /// <summary>
        /// Dids the modify range using the specified range
        /// </summary>
        /// <param name="range">The range</param>
        public void didModifyRange(NSRange range)
            => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_didModifyRange, range);

        /// <summary>
        /// Adds the debug marker using the specified marker
        /// </summary>
        /// <param name="marker">The marker</param>
        /// <param name="range">The range</param>
        public void addDebugMarker(NSString marker, NSRange range)
            => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_addDebugMarker, marker.NativePtr, range);

        /// <summary>
        /// Removes the all debug markers
        /// </summary>
        public void removeAllDebugMarkers()
            => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_removeAllDebugMarkers);

        /// <summary>
        /// The sel contents
        /// </summary>
        private static readonly Selector sel_contents = "contents";
        /// <summary>
        /// The sel length
        /// </summary>
        private static readonly Selector sel_length = "length";
        /// <summary>
        /// The sel didmodifyrange
        /// </summary>
        private static readonly Selector sel_didModifyRange = "didModifyRange:";
        /// <summary>
        /// The sel adddebugmarker
        /// </summary>
        private static readonly Selector sel_addDebugMarker = "addDebugMarker:range:";
        /// <summary>
        /// The sel removealldebugmarkers
        /// </summary>
        private static readonly Selector sel_removeAllDebugMarkers = "removeAllDebugMarkers";
    }
}