using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Alis.Core.Ecs.Core.Memory
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
        public static ref T UnsafeArrayIndex<T>(this T[] arr, nint index)
        {
            return ref Unsafe.Add(ref MemoryMarshal.GetArrayDataReference(arr), index);
        }

        /// <summary>
        ///     Unsafes the array index using the specified arr
        /// </summary>
        /// <typeparam name="T">The </typeparam>
        /// <param name="arr">The arr</param>
        /// <param name="index">The index</param>
        /// <returns>The ref</returns>
        public static ref T UnsafeArrayIndex<T>(this T[] arr, int index)
        {
            return ref Unsafe.Add(ref MemoryMarshal.GetArrayDataReference(arr), index);
        }

        /// <summary>
        ///     Unsafes the array index using the specified arr
        /// </summary>
        /// <typeparam name="T">The </typeparam>
        /// <param name="arr">The arr</param>
        /// <param name="index">The index</param>
        /// <returns>The ref</returns>
        public static ref T UnsafeArrayIndex<T>(this T[] arr, ushort index)
        {
            return ref Unsafe.Add(ref MemoryMarshal.GetArrayDataReference(arr), index);
        }

        /// <summary>
        ///     Unsafes the span index using the specified arr
        /// </summary>
        /// <typeparam name="T">The </typeparam>
        /// <param name="arr">The arr</param>
        /// <param name="index">The index</param>
        /// <returns>The ref</returns>
        public static ref T UnsafeSpanIndex<T>(this Span<T> arr, int index)
        {
            return ref Unsafe.Add(ref MemoryMarshal.GetReference(arr), index);
        }

        /// <summary>
        ///     Unsafes the span index using the specified arr
        /// </summary>
        /// <typeparam name="T">The </typeparam>
        /// <param name="arr">The arr</param>
        /// <param name="index">The index</param>
        /// <returns>The ref</returns>
        public static ref T UnsafeSpanIndex<T>(this Span<T> arr, ushort index)
        {
            return ref Unsafe.Add(ref MemoryMarshal.GetReference(arr), index);
        }


        /// <summary>
        ///     Unsafes the cast using the specified o
        /// </summary>
        /// <typeparam name="T">The </typeparam>
        /// <param name="o">The </param>
        /// <returns>The</returns>
        public static T UnsafeCast<T>(object o) where T : class
        {
            return Unsafe.As<T>(o);
        }
    }
}