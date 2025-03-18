﻿using System;
using Frent.Core;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Frent.Collections;

//Do not pass around this struct by value!!!
//You must use the constructor when initalizating!!!

#pragma warning disable CS8500 // This takes the address of, gets the size of, or declares a pointer to a managed type
//As long as the user always uses the ctor, it would throw when managed type is used
internal struct NativeStack<T> : IDisposable where T : struct
{
    public int Count => _nextIndex;

    private T[] _array;
    private int _nextIndex;

    public ref T this[int index]
    {
        get
        {
#if DEBUG
            if (index >= _nextIndex || index < 0)
                throw new IndexOutOfRangeException();
#endif
            return ref _array.UnsafeArrayIndex(index);
        }
    }

    public NativeStack(int initalCapacity)
    {
        if (RuntimeHelpers.IsReferenceOrContainsReferences<T>())
            throw new InvalidOperationException("Cannot store managed objects in native code");
        if (initalCapacity < 1)
            throw new ArgumentOutOfRangeException();

        _array = new T[initalCapacity];
    }

    public ref T Push()
    {
        if (_nextIndex == _array.Length)
            Resize();
        return ref _array[_nextIndex++];
    }

    public void Pop(out T value)
    {
        if (_nextIndex == 0)
            FrentExceptions.Throw_InvalidOperationException("Stack is empty!");
        value = _array[--_nextIndex];
    }

    public bool CanPop() => _nextIndex != 0;

    public T PopUnsafe() => _array[--_nextIndex];

    public bool TryPop(out T value)
    {
        if (_nextIndex == 0)
        {
            Unsafe.SkipInit(out value);
            MemoryHelpers.Poison(ref value);
            return false;
        }

        value = _array[--_nextIndex];
        return true;
    }

    public void RemoveAt(int index)
    {
        if ((uint)index < (uint)_nextIndex)
        {
            _array[index] = _array[--_nextIndex];
            return;
        }
        FrentExceptions.Throw_InvalidOperationException("Invalid Index!");
    }

    private void Resize()
    {
        Array.Resize(ref _array, _array.Length << 1);
    }

    public void Dispose()
    {

    }

    public Span<T> AsSpan() => _array.AsSpan(0, _nextIndex);
}