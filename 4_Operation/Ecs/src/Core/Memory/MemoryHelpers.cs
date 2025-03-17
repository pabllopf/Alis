// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:MemoryHelpers.cs
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
using System.Buffers;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Alis.Core.Ecs.Buffers;

namespace Alis.Core.Ecs.Core.Memory
{
    /// <summary>
    ///     The memory helpers class
    /// </summary>
    internal static class MemoryHelpers
    {
        /// <summary>
        ///     The max component count
        /// </summary>
        public const int MaxComponentCount = 127;

        /// <summary>
        ///     Rounds the down to power of two using the specified value
        /// </summary>
        /// <param name="value">The value</param>
        /// <returns>The uint</returns>
        public static uint RoundDownToPowerOfTwo(uint value) => BitOperations.RoundUpToPowerOf2((value >> 1) + 1);

        /// <summary>
        ///     Rounds the up to next multiple of 16 using the specified value
        /// </summary>
        /// <param name="value">The value</param>
        /// <returns>The int</returns>
        public static int RoundUpToNextMultipleOf16(int value) => (value + 15) & ~15;

        /// <summary>
        ///     Rounds the down to next multiple of 16 using the specified value
        /// </summary>
        /// <param name="value">The value</param>
        /// <returns>The int</returns>
        public static int RoundDownToNextMultipleOf16(int value) => value & ~15;

        /// <summary>
        ///     Bools the to byte using the specified b
        /// </summary>
        /// <param name="b">The </param>
        /// <returns>The byte</returns>
        public static byte BoolToByte(bool b) => Unsafe.As<bool, byte>(ref b);

        /// <summary>
        ///     Reads the only span to immutable array using the specified span
        /// </summary>
        /// <typeparam name="T">The </typeparam>
        /// <param name="span">The span</param>
        /// <returns>An immutable array of t</returns>
        public static ImmutableArray<T> ReadOnlySpanToImmutableArray<T>(ReadOnlySpan<T> span)
        {
            ImmutableArray<T>.Builder? builder = ImmutableArray.CreateBuilder<T>(span.Length);
            for (int i = 0; i < span.Length; i++)
                builder.Add(span[i]);
            return builder.MoveToImmutable();
        }

        /// <summary>
        ///     Concats the start
        /// </summary>
        /// <typeparam name="T">The </typeparam>
        /// <param name="start">The start</param>
        /// <param name="span">The span</param>
        /// <returns>An immutable array of t</returns>
        public static ImmutableArray<T> Concat<T>(ImmutableArray<T> start, ReadOnlySpan<T> span)
            where T : ITypeID
        {
            ImmutableArray<T>.Builder? builder = ImmutableArray.CreateBuilder<T>(start.Length + span.Length);
            for (int i = 0; i < start.Length; i++)
                builder.Add(start[i]);
            for (int i = 0; i < span.Length; i++)
            {
                T? t = span[i];
                if (start.IndexOf(t) != -1)
                {
                    FrentExceptions.Throw_InvalidOperationException($"This entity already has a component of type {t.Type.Name}");
                }

                builder.Add(t);
            }

            return builder.MoveToImmutable();
        }

        /// <summary>
        ///     Concats the types
        /// </summary>
        /// <typeparam name="T">The </typeparam>
        /// <param name="types">The types</param>
        /// <param name="type">The type</param>
        /// <returns>The result</returns>
        public static ImmutableArray<T> Concat<T>(ImmutableArray<T> types, T type)
            where T : ITypeID
        {
            if (types.IndexOf(type) != -1)
            {
                FrentExceptions.Throw_InvalidOperationException($"This entity already has a component of type {type.Type.Name}");
            }

            ImmutableArray<T>.Builder? builder = ImmutableArray.CreateBuilder<T>(types.Length + 1);
            builder.AddRange(types);
            builder.Add(type);

            ImmutableArray<T> result = builder.MoveToImmutable();
            return result;
        }

        /// <summary>
        ///     Removes the types
        /// </summary>
        /// <typeparam name="T">The </typeparam>
        /// <param name="types">The types</param>
        /// <param name="type">The type</param>
        /// <returns>The result</returns>
        public static ImmutableArray<T> Remove<T>(ImmutableArray<T> types, T type)
            where T : ITypeID
        {
            int index = types.IndexOf(type);
            if (index == -1)
            {
                FrentExceptions.Throw_ComponentNotFoundException(type.Type);
            }

            ImmutableArray<T> result = types.RemoveAt(index);
            return result;
        }

        /// <summary>
        ///     Removes the types
        /// </summary>
        /// <typeparam name="T">The </typeparam>
        /// <param name="types">The types</param>
        /// <param name="span">The span</param>
        /// <returns>An immutable array of t</returns>
        public static ImmutableArray<T> Remove<T>(ImmutableArray<T> types, ReadOnlySpan<T> span)
            where T : ITypeID
        {
            ImmutableArray<T>.Builder? builder = ImmutableArray.CreateBuilder<T>(types.Length);
            builder.AddRange(types);

            foreach (T? type in span)
            {
                int index = builder.IndexOf(type);
                if (index == -1)
                {
                    FrentExceptions.Throw_ComponentNotFoundException(type.Type);
                }

                builder.RemoveAt(index);
            }

            return builder.ToImmutable();
        }

        /// <summary>
        ///     Gets the or add new using the specified dictionary
        /// </summary>
        /// <typeparam name="TKey">The key</typeparam>
        /// <typeparam name="TValue">The value</typeparam>
        /// <param name="dictionary">The dictionary</param>
        /// <param name="key">The key</param>
        /// <returns>The value</returns>
        public static TValue GetOrAddNew<TKey, TValue>(this Dictionary<TKey, TValue> dictionary, TKey key)
            where TKey : notnull
            where TValue : new()
        {
            if (dictionary.TryGetValue(key, out TValue? value))
            {
                return value;
            }

            return dictionary[key] = new();
        }

        /// <summary>
        ///     Copies the block using the specified destination
        /// </summary>
        /// <typeparam name="TBlock">The block</typeparam>
        /// <param name="destination">The destination</param>
        /// <param name="source">The source</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void CopyBlock<TBlock>(ref byte destination, ref byte source)
            where TBlock : struct
        {
            Debug.Assert(
                typeof(TBlock) == typeof(Block2)
                || typeof(TBlock) == typeof(Block4)
                || typeof(TBlock) == typeof(Block8)
                || typeof(TBlock) == typeof(Block16));
            Unsafe.As<byte, TBlock>(ref destination) = Unsafe.As<byte, TBlock>(ref destination);
        }


        // catch bugs with Unsafe.SkitInit
        /// <summary>
        ///     Poisons the item
        /// </summary>
        /// <typeparam name="T">The </typeparam>
        /// <param name="item">The item</param>
        /// <exception cref="NotSupportedException">Cleared anyways</exception>
        [Conditional("DEBUG")]
        public static void Poison<T>(ref T item)
        {
            if (RuntimeHelpers.IsReferenceOrContainsReferences<T>())
            {
                throw new NotSupportedException("Cleared anyways");
            }
        }

        /// <summary>
        ///     The block
        /// </summary>
        [StructLayout(LayoutKind.Sequential, Size = 2)]
        internal struct Block2;

        /// <summary>
        ///     The block
        /// </summary>
        [StructLayout(LayoutKind.Sequential, Size = 4)]
        internal struct Block4;

        /// <summary>
        ///     The block
        /// </summary>
        [StructLayout(LayoutKind.Sequential, Size = 8)]
        internal struct Block8;

        /// <summary>
        ///     The block 16
        /// </summary>
        [StructLayout(LayoutKind.Sequential, Size = 16)]
        internal struct Block16;
    }

    /// <summary>
    ///     The memory helpers class
    /// </summary>
    internal static class MemoryHelpers<T>
    {
        /// <summary>
        ///     The pool
        /// </summary>
        private static readonly ComponentArrayPool<T> _pool = new();

        /// <summary>
        ///     Gets the value of the pool
        /// </summary>
        internal static ArrayPool<T> Pool => _pool;
    }
}