using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Alis.Core.Ecs.Redifinition
{
    /// <summary>
    ///     The unsafe extensions class
    /// </summary>
    public static class UnsafeExtensions
    {
        /// <summary>
        ///     Unsafes the array index using the specified arr
        /// </summary>
        /// <typeparam name="T">The </typeparam>
        /// <param name="arr">The arr</param>
        /// <param name="index">The index</param>
        /// <returns>The ref</returns>
        public static ref T XxUnsafeArrayIndex<T>(this T[] arr, int index)
        {
            return ref Unsafe.Add(ref arr[0], index);
        }
        
        /// <summary>
        ///     Unsafes the span index using the specified arr
        /// </summary>
        /// <typeparam name="T">The </typeparam>
        /// <param name="arr">The arr</param>
        /// <param name="index">The index</param>
        /// <returns>The ref</returns>
        public static ref T XxUnsafeSpanIndex<T>(this Span<T> arr, int index)
        {
            return ref Unsafe.Add(ref MemoryMarshal.GetReference(arr), index);
        }
    }
}