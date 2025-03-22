using System;
using System.Runtime.CompilerServices;

namespace Alis.Core.Ecs.Core.Memory
{
    internal static class UnsafeExtensions
    {
    public static ref T UnsafeArrayIndex<T>(this T[] arr, nint index) =>
        ref Unsafe.Add(ref System.Runtime.InteropServices.MemoryMarshal.GetArrayDataReference(arr), index);
    public static ref T UnsafeArrayIndex<T>(this T[] arr, int index) =>
        ref Unsafe.Add(ref System.Runtime.InteropServices.MemoryMarshal.GetArrayDataReference(arr), index);
    public static ref T UnsafeArrayIndex<T>(this T[] arr, ushort index) =>
        ref Unsafe.Add(ref System.Runtime.InteropServices.MemoryMarshal.GetArrayDataReference(arr), index);
    public static ref T UnsafeArrayIndex<T>(this T[] arr, uint index) =>
        ref Unsafe.Add(ref System.Runtime.InteropServices.MemoryMarshal.GetArrayDataReference(arr), index);
    public static ref T UnsafeSpanIndex<T>(this Span<T> arr, int index) =>
        ref Unsafe.Add(ref System.Runtime.InteropServices.MemoryMarshal.GetReference(arr), index);
    public static ref T UnsafeSpanIndex<T>(this Span<T> arr, ushort index) =>
        ref Unsafe.Add(ref System.Runtime.InteropServices.MemoryMarshal.GetReference(arr), index);
    public static ref T UnsafeSpanIndex<T>(this Span<T> arr, uint index) =>
        ref Unsafe.Add(ref System.Runtime.InteropServices.MemoryMarshal.GetReference(arr), index);
    public static T UnsafeCast<T>(object o) where T : class =>
        Unsafe.As<T>(o);
    }
}
