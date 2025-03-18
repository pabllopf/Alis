// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:NativeArray.cs
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
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Alis.Core.Ecs.Collections
{
#if (!NETSTANDARD && !NETCOREAPP && !NETFRAMEWORK) || NET6_0_OR_GREATER
//Do not pass around this struct by value!!!
//You must use the constructor when initalizating!!!

#pragma warning disable CS8500 // This takes the address of, gets the size of, or declares a pointer to a managed type
//As long as the user always uses the ctor, it would throw when managed type is used
    internal unsafe struct NativeArray<T> : IDisposable
    {
        public int Length => _length;

        private static readonly nuint Size = (nuint)Unsafe.SizeOf<T>();
        private T* _array;
        private int _length;

        public ref T this[int index]
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
#if DEBUG
            if (index >= _length || index < 0)
                throw new IndexOutOfRangeException();
#endif
                return ref _array[index];
            }
        }

        public NativeArray(int length)
        {
            if (RuntimeHelpers.IsReferenceOrContainsReferences<T>())
                throw new InvalidOperationException("Cannot store managed objects in native code");
            if (length < 1)
                throw new ArgumentOutOfRangeException();

            _length = length;
            _array = (T*)NativeMemory.Alloc((nuint)length * Size);
        }

        public void Resize(int size)
        {
            _length = size;
            _array = (T*)NativeMemory.Realloc(_array, Size * (nuint)size);
        }

        public void Dispose()
        {
            NativeMemory.Free(_array);
            //null reference isnt as bad as a use after free, right?
            _array = (T*)0;
        }

        public Span<T> AsSpan() => MemoryMarshal.CreateSpan(ref Unsafe.AsRef<T>(_array), _length);
        public Span<T> AsSpanLen(int len)
        {
            System.Diagnostics.Debug.Assert(len <= _length);
            return MemoryMarshal.CreateSpan(ref Unsafe.AsRef<T>(_array), len);
        }
    }
#endif
}