#if (NETSTANDARD || NETFRAMEWORK || NETCOREAPP) && (!NET6_0_OR_GREATER)

// ReSharper disable once CheckNamespace
namespace System.Runtime.InteropServices
{
    public static class MemoryMarshal
    {
        public static ref T GetReference<T>(Span<T> span)
        {
            return ref span.GetPinnableReference();
        }

        public static ref T GetArrayDataReference<T>(T[] arr)
        {
            return ref GetReference(arr.AsSpan());
        }

        public static ref byte GetArrayDataReference(Array arr)
        {
            throw new NotSupportedException();
        }
    }
}

#endif