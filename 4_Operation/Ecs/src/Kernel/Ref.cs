using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Alis.Core.Ecs.Kernel
{
    /// <summary>
    ///     A wrapper ref struct over a reference to a <typeparamref name="T" />
    /// </summary>
    /// <typeparam name="T">The type this <see cref="Ref{T}" /> wraps over</typeparam>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public ref struct Ref<T>
    {
#if NET7_0_OR_GREATER
    internal Ref(T[] compArr, int index) => _comp = ref Unsafe.Add(ref compArr[0], index);
    internal Ref(Span<T> compSpan, int index) => _comp = ref Unsafe.Add(ref MemoryMarshal.GetReference(compSpan), index);
    internal Ref(Alis.Core.Ecs.Updating.ComponentStorage<T> compSpan, int index) => _comp = ref compSpan[index];

    private ref T _comp;

    /// <summary>
    /// The wrapped reference to <typeparamref name="T"/>
    /// </summary>
    public readonly ref T Value => ref _comp;

    /// <summary>
    /// Extracts the wrapped <typeparamref name="T"/> from this <see cref="Ref{T}"/>
    /// </summary>
    public static implicit operator T(Ref<T> @ref) => @ref.Value;

    /// <summary>
    /// Calls the wrapped <typeparamref name="T"/>'s ToString() function, or returns null.
    /// </summary>
    /// <returns>A string representation of the wrapped <typeparamref name="T"/>'s</returns>
    public readonly override string ToString() => Value?.ToString();
#elif (NETSTANDARD || NETFRAMEWORK || NETCOREAPP) && !NET7_0_OR_GREATER
        internal Ref(T[] compArr, int index)
        {
            _data = compArr;
            _offset = index;
        }

        internal Ref(Span<T> compSpan, int index)
        {
            _data = compSpan;
            _offset = index;
        }

        internal Ref(Alis.Core.Ecs.Updating.ComponentStorage<T> compSpan, int index)
        {
            _data = compSpan.AsSpan();
            _offset = index;
        }

        private readonly Span<T> _data;
        private readonly int _offset;

        /// <summary>
        ///     The wrapped reference to <typeparamref name="T" />
        /// </summary>
        public readonly ref T Value => ref Unsafe.Add(ref _data[0], _offset); 

        /// <summary>
        ///     Extracts the wrapped <typeparamref name="T" /> from this <see cref="Ref{T}" />
        /// </summary>
        public static implicit operator T(Ref<T> @ref)
        {
            return @ref.Value;
        }

        /// <summary>
        ///     Calls the wrapped <typeparamref name="T" />'s ToString() function, or returns null.
        /// </summary>
        /// <returns>A string representation of the wrapped <typeparamref name="T" />'s</returns>
        public readonly override string ToString()
        {
            return Value?.ToString();
        }
#endif
    }
}