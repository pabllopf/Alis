using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Frent.Core
{
    /// <summary>
    /// The unsafe extensions class
    /// </summary>
    internal static class UnsafeExtensions
    {
#if !DEBUG
    /// <summary>
    /// Unsafes the array index using the specified arr
    /// </summary>
    /// <typeparam name="T">The </typeparam>
    /// <param name="arr">The arr</param>
    /// <param name="index">The index</param>
    /// <returns>The ref</returns>
    public static ref T UnsafeArrayIndex<T>(this T[] arr, nint index) =>
        ref Unsafe.Add(ref MemoryMarshal.GetArrayDataReference(arr), index);
    /// <summary>
    /// Unsafes the array index using the specified arr
    /// </summary>
    /// <typeparam name="T">The </typeparam>
    /// <param name="arr">The arr</param>
    /// <param name="index">The index</param>
    /// <returns>The ref</returns>
    public static ref T UnsafeArrayIndex<T>(this T[] arr, int index) =>
        ref Unsafe.Add(ref MemoryMarshal.GetArrayDataReference(arr), index);
    /// <summary>
    /// Unsafes the array index using the specified arr
    /// </summary>
    /// <typeparam name="T">The </typeparam>
    /// <param name="arr">The arr</param>
    /// <param name="index">The index</param>
    /// <returns>The ref</returns>
    public static ref T UnsafeArrayIndex<T>(this T[] arr, ushort index) =>
        ref Unsafe.Add(ref MemoryMarshal.GetArrayDataReference(arr), index);
    /// <summary>
    /// Unsafes the array index using the specified arr
    /// </summary>
    /// <typeparam name="T">The </typeparam>
    /// <param name="arr">The arr</param>
    /// <param name="index">The index</param>
    /// <returns>The ref</returns>
    public static ref T UnsafeArrayIndex<T>(this T[] arr, uint index) =>
        ref Unsafe.Add(ref MemoryMarshal.GetArrayDataReference(arr), new IntPtr(index));
    /// <summary>
    /// Unsafes the span index using the specified arr
    /// </summary>
    /// <typeparam name="T">The </typeparam>
    /// <param name="arr">The arr</param>
    /// <param name="index">The index</param>
    /// <returns>The ref</returns>
    public static ref T UnsafeSpanIndex<T>(this Span<T> arr, int index) =>
        ref Unsafe.Add(ref MemoryMarshal.GetReference(arr), index);
    /// <summary>
    /// Unsafes the span index using the specified arr
    /// </summary>
    /// <typeparam name="T">The </typeparam>
    /// <param name="arr">The arr</param>
    /// <param name="index">The index</param>
    /// <returns>The ref</returns>
    public static ref T UnsafeSpanIndex<T>(this Span<T> arr, ushort index) =>
        ref Unsafe.Add(ref MemoryMarshal.GetReference(arr), index);
    /// <summary>
    /// Unsafes the span index using the specified arr
    /// </summary>
    /// <typeparam name="T">The </typeparam>
    /// <param name="arr">The arr</param>
    /// <param name="index">The index</param>
    /// <returns>The ref</returns>
    public static ref T UnsafeSpanIndex<T>(this Span<T> arr, uint index) =>
        ref Unsafe.Add(ref MemoryMarshal.GetReference(arr), new IntPtr(index));
    /// <summary>
    /// Unsafes the cast using the specified o
    /// </summary>
    /// <typeparam name="T">The </typeparam>
    /// <param name="o">The </param>
    /// <returns>The</returns>
    public static T UnsafeCast<T>(object o) where T : class =>
        Unsafe.As<T>(o);
#else
        public static ref T UnsafeArrayIndex<T>(this T[] arr, nint index) =>
            ref arr[index];
        public static ref T UnsafeArrayIndex<T>(this T[] arr, int index) =>
            ref arr[index];
        public static ref T UnsafeArrayIndex<T>(this T[] arr, ushort index) =>
            ref arr[index];
        public static ref T UnsafeArrayIndex<T>(this T[] arr, uint index) =>
            ref arr[index];
        public static ref T UnsafeSpanIndex<T>(this Span<T> arr, int index) =>
            ref arr[index];
        public static ref T UnsafeSpanIndex<T>(this Span<T> arr, ushort index) =>
            ref arr[index];
        public static ref T UnsafeSpanIndex<T>(this Span<T> arr, uint index) =>
            ref arr[(int)index];
        public static T UnsafeCast<T>(object o) where T : class =>
            (T)o;
#endif
    }
}
