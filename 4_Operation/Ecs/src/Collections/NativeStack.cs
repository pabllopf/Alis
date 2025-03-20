using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Alis.Core.Ecs.Core.Memory;

namespace Alis.Core.Ecs.Collections
{
#if (NETSTANDARD || NETFRAMEWORK || NETCOREAPP) && !NET6_0_OR_GREATER
//Do not pass around this struct by value!!!
//You must use the constructor when initalizating!!!

#pragma warning disable CS8500 // This takes the address of, gets the size of, or declares a pointer to a managed type
//As long as the user always uses the ctor, it would throw when managed type is used
internal unsafe struct NativeStack<T> : IDisposable where T : struct
{
    public int Count => _nextIndex;

    private T[] _array;
    private int _nextIndex;

    public ref T this[int index]
    {
        get
        {
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
#else
//Do not pass around this struct by value!!!
//You must use the constructor when initalizating!!!

#pragma warning disable CS8500 // This takes the address of, gets the size of, or declares a pointer to a managed type
//As long as the user always uses the ctor, it would throw when managed type is used
    /// <summary>
    /// The native stack
    /// </summary>
    internal unsafe struct NativeStack<T> : IDisposable where T : struct
    {
        /// <summary>
        /// Gets the value of the count
        /// </summary>
        public int Count => _nextIndex;

        /// <summary>
        /// The 
        /// </summary>
        private static readonly nuint Size = (nuint)Unsafe.SizeOf<T>();
        /// <summary>
        /// The array
        /// </summary>
        private T* _array;
        /// <summary>
        /// The capacity
        /// </summary>
        private int _capacity;
        /// <summary>
        /// The next index
        /// </summary>
        private int _nextIndex;

        /// <summary>
        /// The index
        /// </summary>
        public ref T this[int index]
        {
            get
            {
                return ref _array[index];
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="NativeStack"/> class
        /// </summary>
        /// <param name="initalCapacity">The inital capacity</param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        /// <exception cref="InvalidOperationException">Cannot store managed objects in native code</exception>
        public NativeStack(int initalCapacity)
        {
            if (RuntimeHelpers.IsReferenceOrContainsReferences<T>())
                throw new InvalidOperationException("Cannot store managed objects in native code");
            if (initalCapacity < 1)
                throw new ArgumentOutOfRangeException();

            _capacity = initalCapacity;
            _array = (T*)NativeMemory.Alloc((nuint)initalCapacity * Size);
        }

        /// <summary>
        /// Pushes this instance
        /// </summary>
        /// <returns>The ref</returns>
        public ref T Push()
        {
            if (_nextIndex == _capacity)
                Resize();
            return ref _array[_nextIndex++];
        }

        /// <summary>
        /// Pops the value
        /// </summary>
        /// <param name="value">The value</param>
        public void Pop(out T value)
        {
            if (_nextIndex == 0)
                FrentExceptions.Throw_InvalidOperationException("Stack is empty!");
            value = _array[--_nextIndex];
        }

        /// <summary>
        /// Cans the pop
        /// </summary>
        /// <returns>The bool</returns>
        public bool CanPop() => _nextIndex != 0;

        /// <summary>
        /// Pops the unsafe
        /// </summary>
        /// <returns>The</returns>
        public T PopUnsafe() => _array[--_nextIndex];

        /// <summary>
        /// Tries the pop using the specified value
        /// </summary>
        /// <param name="value">The value</param>
        /// <returns>The bool</returns>
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

        /// <summary>
        /// Removes the at using the specified index
        /// </summary>
        /// <param name="index">The index</param>
        public void RemoveAt(int index)
        {
            if ((uint)index < (uint)_nextIndex)
            {
                _array[index] = _array[--_nextIndex];
                return;
            }
            FrentExceptions.Throw_InvalidOperationException("Invalid Index!");
        }

        /// <summary>
        /// Resizes this instance
        /// </summary>
        private void Resize()
        {
            _capacity = checked(_capacity * 2);
            _array = (T*)NativeMemory.Realloc(_array, Size * (nuint)_capacity);
        }

        /// <summary>
        /// Disposes this instance
        /// </summary>
        public void Dispose()
        {
            NativeMemory.Free(_array);
            //null reference isnt as bad as a use after free, right?
            _array = (T*)0;
        }

        /// <summary>
        /// Converts the span
        /// </summary>
        /// <returns>A span of t</returns>
        public Span<T> AsSpan() => MemoryMarshal.CreateSpan(ref Unsafe.AsRef<T>(_array), _nextIndex);
    }
#endif
}