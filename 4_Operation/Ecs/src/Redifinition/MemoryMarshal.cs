

using System.Diagnostics.CodeAnalysis;

#if (NETFRAMEWORK || NETCOREAPP) && (!NET6_0_OR_GREATER)
namespace System.Runtime.InteropServices
{
    /// <summary>
    ///     Provides methods for accessing and manipulating memory in a low-level manner.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public static class MemoryMarshal
    {
        /// <summary>
        ///     Gets a reference to the first element of a <see cref="Span{T}" />.
        /// </summary>
        /// <typeparam name="T">The type of elements in the span.</typeparam>
        /// <param name="span">The span to get the reference from.</param>
        /// <returns>A reference to the first element of the span.</returns>
        public static ref T GetReference<T>(Span<T> span) => ref span.GetPinnableReference();

        /// <summary>
        ///     Gets a reference to the first element of an array.
        /// </summary>
        /// <typeparam name="T">The type of elements in the array.</typeparam>
        /// <param name="arr">The array to get the reference from.</param>
        /// <returns>A reference to the first element of the array.</returns>
        public static ref T GetArrayDataReference<T>(T[] arr) => ref GetReference(arr.AsSpan());

        /// <summary>
        ///     Gets a reference to the first element of a non-generic array.
        /// </summary>
        /// <param name="arr">The array to get the reference from.</param>
        /// <returns>A reference to the first element of the array.</returns>
        /// <exception cref="NotSupportedException">Thrown when this method is called.</exception>
        public static ref byte GetArrayDataReference(Array arr) => throw new NotSupportedException();
    }
}

#endif