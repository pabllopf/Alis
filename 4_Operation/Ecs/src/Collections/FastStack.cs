// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:FastStack.cs
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
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;

using Alis.Core.Ecs.Buffers;
using Alis.Core.Ecs.Core.Memory;

namespace Alis.Core.Ecs.Collections
{
    /// <summary>
    ///     The fast stack
    /// </summary>
    internal struct FastStack<T>(int initalComponents) : IEnumerable<T>
{
    [DebuggerStepThrough]
    public static FastStack<T> Create(int initalComponents) => new FastStack<T>(initalComponents);
    public static FastStack<T> Create(T[] initalBuffer) => new FastStack<T>()
    {
        _buffer = initalBuffer
    };

    private T[] _buffer = new T[initalComponents];
    private int _nextIndex = 0;

    public readonly int Count => _nextIndex;
    public readonly T Top => _buffer[_nextIndex - 1];
    public readonly bool HasElements => _nextIndex > 0;

    public readonly ref T this[int i] => ref _buffer[i];


    [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
    public void Push(T comp)
    {
        var buffer = _buffer;
        if ((uint)_nextIndex < (uint)buffer.Length)
            buffer[_nextIndex++] = comp;
        else
            ResizeAndPush(comp);
    }

    private void ResizeAndPush(in T comp)
    {
        FastStackArrayPool<T>.ResizeArrayFromPool(ref _buffer, _buffer.Length * 2);
        _buffer[_nextIndex++] = comp;
    }

    public void Compact() => Array.Resize(ref _buffer, _nextIndex);

    [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
    public T Pop()
    {
        var buffer = _buffer;
        var next = buffer[--_nextIndex];
        if (System.Runtime.CompilerServices.RuntimeHelpers.IsReferenceOrContainsReferences<T>())
            buffer[_nextIndex] = default!;
        return next;
    }

    [DebuggerStepThrough]
    public bool TryPop(out T? value)
    {
        if (System.Runtime.CompilerServices.RuntimeHelpers.IsReferenceOrContainsReferences<T>())
            throw new NotImplementedException();

        if (_nextIndex == 0)
        {
            value = default;
            return false;
        }

        //we can ignore - as the as the user doesn't push null onto the stack
        //they won't get null from the stack
        value = _buffer.UnsafeArrayIndex(--_nextIndex)!;
        return true;
    }

    public void RemoveAtReplace(int index)
    {
        Debug.Assert(Count > 0);

        var buffer = _buffer;
        if (index < buffer.Length)
        {
            buffer[index] = buffer[--_nextIndex];
            if (System.Runtime.CompilerServices.RuntimeHelpers.IsReferenceOrContainsReferences<T>())
                buffer[_nextIndex] = default!;
        }
    }


    /// <summary>
    /// DO NOT ALTER WHILE SPAN IS IN USE
    /// </summary>
#if (NETSTANDARD || NETCOREAPP || NETFRAMEWORK) && !NET6_0_OR_GREATER
    public readonly Span<T> AsSpan() => _buffer.AsSpan(0, _nextIndex);
#else
    public readonly Span<T> AsSpan() =>  System.Runtime.InteropServices.MemoryMarshal.CreateSpan(ref  System.Runtime.InteropServices.MemoryMarshal.GetArrayDataReference(_buffer), _nextIndex);
#endif

    public void Clear()
    {
        if (System.Runtime.CompilerServices.RuntimeHelpers.IsReferenceOrContainsReferences<T>())
            AsSpan().Clear();
        _nextIndex = 0;
    }

    public void ClearWithoutClearingGCReferences() => _nextIndex = 0;

    readonly IEnumerator<T> IEnumerable<T>.GetEnumerator() => GetEnumerator();
    readonly IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    public readonly FastStackEnumerator GetEnumerator() => new(this);

    public struct FastStackEnumerator(FastStack<T> stack) : IEnumerator<T>
    {
        private T[] _elements = stack._buffer;
        private int _max = stack._nextIndex;
        private int _index = -1;
        public readonly T Current => _elements[_index];
        readonly object? IEnumerator.Current => _elements[_index];
        public void Dispose() => _elements = null!;
        public bool MoveNext() => ++_index < _max;
        public void Reset() => _index = -1;
    }
}
}