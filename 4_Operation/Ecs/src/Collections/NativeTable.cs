using System;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Frent.Collections;


//Do not pass around this struct by value!!!
//You must use the constructor when initalizating!!!

#pragma warning disable CS8500 // This takes the address of, gets the size of, or declares a pointer to a managed type
//As long as the user always uses the ctor, it would throw when managed type is used
/// <summary>
/// The native table
/// </summary>
internal struct NativeTable<T> : IDisposable where T : struct
{
    /// <summary>
    /// The array
    /// </summary>
    private T[] _array;
    /// <summary>
    /// The length
    /// </summary>
    private int _length;

    /// <summary>
    /// The index
    /// </summary>
    public ref T this[int index]
    {
        get
        {
#if DEBUG
            if(index < 0)
                throw new ArgumentOutOfRangeException();
#endif
            if (index >= _length)
                return ref ResizeFor(index);
            return ref _array[index];
        }
    }

    /// <summary>
    /// Unsafes the index no resize using the specified index
    /// </summary>
    /// <param name="index">The index</param>
    /// <returns>The ref</returns>
    public ref T UnsafeIndexNoResize(int index)
    {
        return ref _array[index];
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="NativeTable"/> class
    /// </summary>
    /// <param name="initalCapacity">The inital capacity</param>
    /// <exception cref="ArgumentOutOfRangeException"></exception>
    /// <exception cref="InvalidOperationException">Cannot store managed objects in native code</exception>
    public NativeTable(int initalCapacity)
    {
        if (RuntimeHelpers.IsReferenceOrContainsReferences<T>())
            throw new InvalidOperationException("Cannot store managed objects in native code");
        if(initalCapacity < 1)
            throw new ArgumentOutOfRangeException();

        _length = initalCapacity;
        _array = new T[initalCapacity];
    }

    /// <summary>
    /// Disposes this instance
    /// </summary>
    public void Dispose()
    {

    }

    /// <summary>
    /// Resizes the for using the specified index
    /// </summary>
    /// <param name="index">The index</param>
    /// <returns>The ref</returns>
    private ref T ResizeFor(int index)
    {
        _length = checked((int)BitOperations.RoundUpToPowerOf2((uint)(index + 1)));
        Array.Resize(ref _array, _length);
        return ref _array[index];
    }

    /// <summary>
    /// Ensures the capacity using the specified new capacity
    /// </summary>
    /// <param name="newCapacity">The new capacity</param>
    public void EnsureCapacity(int newCapacity)
    {
        _length = checked((int)BitOperations.RoundUpToPowerOf2((uint)newCapacity));
        Array.Resize(ref _array, _length);
    }

    /// <summary>
    /// Converts the span
    /// </summary>
    /// <returns>A span of t</returns>
    public Span<T> AsSpan() => _array.AsSpan(0, _length);

    /// <summary>
    /// Gets the value of the span
    /// </summary>
    internal Span<T> Span => AsSpan();
}