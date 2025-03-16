using System;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Frent.Collections;


//Do not pass around this struct by value!!!
//You must use the constructor when initalizating!!!

#pragma warning disable CS8500 // This takes the address of, gets the size of, or declares a pointer to a managed type
//As long as the user always uses the ctor, it would throw when managed type is used
internal struct NativeTable<T> : IDisposable where T : struct
{
    private T[] _array;
    private int _length;

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

    public ref T UnsafeIndexNoResize(int index)
    {
        return ref _array[index];
    }

    public NativeTable(int initalCapacity)
    {
        if (RuntimeHelpers.IsReferenceOrContainsReferences<T>())
            throw new InvalidOperationException("Cannot store managed objects in native code");
        if(initalCapacity < 1)
            throw new ArgumentOutOfRangeException();

        _length = initalCapacity;
        _array = new T[initalCapacity];
    }

    public void Dispose()
    {

    }

    private ref T ResizeFor(int index)
    {
        _length = checked((int)BitOperations.RoundUpToPowerOf2((uint)(index + 1)));
        Array.Resize(ref _array, _length);
        return ref _array[index];
    }

    public void EnsureCapacity(int newCapacity)
    {
        _length = checked((int)BitOperations.RoundUpToPowerOf2((uint)newCapacity));
        Array.Resize(ref _array, _length);
    }

    public Span<T> AsSpan() => _array.AsSpan(0, _length);

    internal Span<T> Span => AsSpan();
}