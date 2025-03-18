// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:NativeTable.cs
// 
//  Author:Pablo Perdomo Falcón
//  Web:https://www.pabllopf.dev/
// 
//  Copyright (c) 2021 GNU General Public License v3.0
// 
//  This program is free software:you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
// 
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.See the
//  GNU General Public License for more details.
// 
//  You should have received a copy of the GNU General Public License
//  along with this program.If not, see <http://www.gnu.org/licenses/>.
// 
//  --------------------------------------------------------------------------

using System;
using System.Numerics;
using System.Runtime.CompilerServices;

namespace Alis.Core.Ecs.Collections
{
    
#if (NETSTANDARD || NETCOREAPP || NETFRAMEWORK) && !NET6_0_OR_GREATER
//Do not pass around this struct by value!!!
//You must use the constructor when initalizating!!!

#pragma warning disable CS8500 // This takes the address of, gets the size of, or declares a pointer to a managed type
//As long as the user always uses the ctor, it would throw when managed type is used
internal unsafe struct NativeTable<T> : IDisposable where T : struct
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
#else
//Do not pass around this struct by value!!!
//You must use the constructor when initalizating!!!

#pragma warning disable CS8500 // This takes the address of, gets the size of, or declares a pointer to a managed type
//As long as the user always uses the ctor, it would throw when managed type is used
internal unsafe struct NativeTable<T> : IDisposable where T : struct
{
    private static readonly nuint Size = (nuint)Unsafe.SizeOf<T>();
    private T* _array;
    private int _length;

    public ref T this[int index]
    {
        get
        {
#if DEBUG
            if (index < 0)
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
        if (initalCapacity < 1)
            throw new ArgumentOutOfRangeException();

        _length = initalCapacity;
        _array = (T*)System.Runtime.InteropServices.NativeMemory.Alloc((nuint)initalCapacity * Size);
    }

    public void Dispose()
    {
        System.Runtime.InteropServices.NativeMemory.Free(_array);
        //null reference isnt as bad as a use after free, right?
        _array = (T*)0;
    }

    private ref T ResizeFor(int index)
    {
        _length = checked((int)BitOperations.RoundUpToPowerOf2((uint)(index + 1)));
        _array = (T*)System.Runtime.InteropServices.NativeMemory.Realloc(_array, (nuint)_length * Size);
        return ref _array[index];
    }

    public void EnsureCapacity(int newCapacity)
    {
        _length = checked((int)BitOperations.RoundUpToPowerOf2((uint)newCapacity));
        _array = (T*)System.Runtime.InteropServices.NativeMemory.Realloc(_array, (nuint)_length * Size);
    }

    public Span<T> AsSpan() => System.Runtime.InteropServices.MemoryMarshal.CreateSpan(ref Unsafe.AsRef<T>(_array), _length);

    internal Span<T> Span => AsSpan();
}
#endif
}