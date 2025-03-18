using System;
using Frent.Updating.Runners;
using System.Runtime.InteropServices;

namespace Frent.Core;

/// <summary>
/// A wrapper ref struct over a reference to a <typeparamref name="T"/>
/// </summary>
/// <typeparam name="T">The type this <see cref="Ref{T}"/> wraps over</typeparam>
public ref struct Ref<T>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Ref"/> class
    /// </summary>
    /// <param name="compArr">The comp arr</param>
    /// <param name="index">The index</param>
    internal Ref(T[] compArr, int index)
    {
        _data = compArr;
        _offset = index;
    }
    /// <summary>
    /// Initializes a new instance of the <see cref="Ref"/> class
    /// </summary>
    /// <param name="compSpan">The comp span</param>
    /// <param name="index">The index</param>
    internal Ref(Span<T> compSpan, int index)
    {
        _data = compSpan;
        _offset = index;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="Ref"/> class
    /// </summary>
    /// <param name="compSpan">The comp span</param>
    /// <param name="index">The index</param>
    internal Ref(ComponentStorage<T> compSpan, int index)
    {
        _data = compSpan.AsSpan();
        _offset = index;
    }

    /// <summary>
    /// The data
    /// </summary>
    private Span<T> _data;
    /// <summary>
    /// The offset
    /// </summary>
    private int _offset;

    /// <summary>
    /// The wrapped reference to <typeparamref name="T"/>
    /// </summary>
    public readonly ref T Value => ref _data.UnsafeSpanIndex(_offset);
    /// <summary>
    /// Extracts the wrapped <typeparamref name="T"/> from this <see cref="Ref{T}"/>
    /// </summary>
    public static implicit operator T(Ref<T> @ref) => @ref.Value;
    /// <summary>
    /// Calls the wrapped <typeparamref name="T"/>'s ToString() function, or returns null.
    /// </summary>
    /// <returns>A string representation of the wrapped <typeparamref name="T"/>'s</returns>
    public override readonly string? ToString() => Value?.ToString();
}
