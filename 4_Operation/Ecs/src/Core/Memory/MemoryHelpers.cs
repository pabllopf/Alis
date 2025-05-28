using System;
using System.Buffers;
using System.Collections.Generic;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Alis.Core.Aspect.Math.Collections;
using Alis.Core.Ecs.Collections;
using Alis.Core.Ecs.Exceptions;
using Alis.Core.Ecs.Updating;

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
        public static uint RoundDownToPowerOfTwo(uint value)
        {
            return BitOperations.RoundUpToPowerOf2((value >> 1) + 1);
        }

        /// <summary>
        ///     Rounds the up to next multiple of 16 using the specified value
        /// </summary>
        /// <param name="value">The value</param>
        /// <returns>The int</returns>
        public static int RoundUpToNextMultipleOf16(int value)
        {
            return (value + 15) & ~15;
        }

        /// <summary>
        ///     Rounds the down to next multiple of 16 using the specified value
        /// </summary>
        /// <param name="value">The value</param>
        /// <returns>The int</returns>
        public static int RoundDownToNextMultipleOf16(int value)
        {
            return value & ~15;
        }

        /// <summary>
        ///     Bools the to byte using the specified b
        /// </summary>
        /// <param name="b">The </param>
        /// <returns>The byte</returns>
        public static byte BoolToByte(bool b)
        {
            return Unsafe.As<bool, byte>(ref b);
        }

        /// <summary>
        ///     Reads the only span to immutable array using the specified span
        /// </summary>
        /// <typeparam name="T">The </typeparam>
        /// <param name="span">The span</param>
        /// <returns>An immutable array of t</returns>
        public static FastImmutableArray<T> ReadOnlySpanToImmutableArray<T>(ReadOnlySpan<T> span)
        {
            FastImmutableArray<T>.Builder builder = FastImmutableArray<T>.CreateBuilder<T>(span.Length);
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
        public static FastImmutableArray<T> Concat<T>(FastImmutableArray<T> start, ReadOnlySpan<T> span)
            where T : ITypeId
        {
            FastImmutableArray<T>.Builder builder = FastImmutableArray<T>.CreateBuilder<T>(start.Length + span.Length);
            for (int i = 0; i < start.Length; i++)
                builder.Add(start[i]);
            for (int i = 0; i < span.Length; i++)
            {
                T t = span[i];
                if (start.IndexOf<object>(t) != -1)
                    throw new InvalidOperationException(
                        $"This gameObject already has a component of type {t.Type.Name}");
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
        public static FastImmutableArray<T> Concat<T>(FastImmutableArray<T> types, T type)
            where T : ITypeId
        {
            if (types.IndexOf<object>(type) != -1)
                throw new InvalidOperationException(
                    $"This gameObject already has a component of type {type.Type.Name}");

            FastImmutableArray<T>.Builder builder = FastImmutableArray<T>.CreateBuilder<T>(types.Length + 1);
            builder.AddRange(types);
            builder.Add(type);

            FastImmutableArray<T> result = builder.MoveToImmutable();
            return result;
        }

        /// <summary>
        ///     Removes the types
        /// </summary>
        /// <typeparam name="T">The </typeparam>
        /// <param name="types">The types</param>
        /// <param name="type">The type</param>
        /// <returns>The result</returns>
        public static FastImmutableArray<T> Remove<T>(FastImmutableArray<T> types, T type)
            where T : ITypeId
        {
            int index = types.IndexOf<object>(type);
            if (index == -1)
                throw new ComponentNotFoundException(type.Type);
            FastImmutableArray<T> result = types.RemoveAt<T>(index);
            return result;
        }

        /// <summary>
        ///     Removes the types
        /// </summary>
        /// <typeparam name="T">The </typeparam>
        /// <param name="types">The types</param>
        /// <param name="span">The span</param>
        /// <returns>An immutable array of t</returns>
        public static FastImmutableArray<T> Remove<T>(FastImmutableArray<T> types, ReadOnlySpan<T> span)
            where T : ITypeId
        {
            FastImmutableArray<T>.Builder builder = FastImmutableArray<T>.CreateBuilder<T>(types.Length);
            builder.AddRange(types);

            foreach (T type in span)
            {
                int index = builder.IndexOf(type);
                if (index == -1)
                    throw new ComponentNotFoundException(type.Type);
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
#if (NETSTANDARD || NETFRAMEWORK || NETCOREAPP) && (!NET6_0_OR_GREATER)
            if (dictionary.TryGetValue(key, out TValue value)) return value;
            return dictionary[key] = new();
#else
        ref TValue res = ref System.Runtime.InteropServices.CollectionsMarshal.GetValueRefOrAddDefault(dictionary, key, out bool _);
        return res ??= new();
#endif
        }

        /// <summary>
        ///     Gets the value or resize using the specified arr
        /// </summary>
        /// <typeparam name="T">The </typeparam>
        /// <param name="arr">The arr</param>
        /// <param name="index">The index</param>
        /// <returns>The ref</returns>
        public static ref T GetValueOrResize<T>(ref T[] arr, int index)
        {
            if ((uint)index < (uint)arr.Length)
                return ref arr[index];
            return ref ResizeAndGet(ref arr, index);
        }

        /// <summary>
        ///     Resizes the and get using the specified arr
        /// </summary>
        /// <typeparam name="T">The </typeparam>
        /// <param name="arr">The arr</param>
        /// <param name="index">The index</param>
        /// <returns>The ref</returns>
        private static ref T ResizeAndGet<T>(ref T[] arr, int index)
        {
            int newSize = (int)BitOperations.RoundUpToPowerOf2((uint)(index + 1));
            Array.Resize(ref arr, newSize);
            return ref arr[index];
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
            Unsafe.As<byte, TBlock>(ref destination) = Unsafe.As<byte, TBlock>(ref destination);
        }


        // catch bugs with Unsafe.SkipInit
        /// <summary>
        ///     Poisons the item
        /// </summary>
        /// <typeparam name="T">The </typeparam>
        /// <param name="item">The item</param>
        /// <exception cref="NotSupportedException">Cleared anyways</exception>
        public static void Poison<T>(ref T item)
        {
            if (RuntimeHelpers.IsReferenceOrContainsReferences<T>())
                throw new NotSupportedException("Cleared anyways");

#if NET6_0_OR_GREATER
        Span<byte> raw = MemoryMarshal.CreateSpan(ref Unsafe.As<T, byte>(ref item), Unsafe.SizeOf<T>());
        raw.Fill(93);
#endif
        }

        /// <summary>
        ///     The block
        /// </summary>
        [StructLayout(LayoutKind.Sequential, Size = 2)]
        public struct Block2;

        /// <summary>
        ///     The block
        /// </summary>
        [StructLayout(LayoutKind.Sequential, Size = 4)]
        public struct Block4;

        /// <summary>
        ///     The block
        /// </summary>
        [StructLayout(LayoutKind.Sequential, Size = 8)]
        public struct Block8;

        /// <summary>
        ///     The block 16
        /// </summary>
        [StructLayout(LayoutKind.Sequential, Size = 16)]
        public struct Block16;

#if (NETSTANDARD || NETFRAMEWORK || NETCOREAPP) && (!NET6_0_OR_GREATER)
        [ThreadStatic] internal static readonly ComponentHandle[] SharedTempComponentHandleBuffer = new ComponentHandle[8];

        [ThreadStatic]
        internal static readonly ComponentStorageBase[] SharedTempComponentStorageBuffer = new ComponentStorageBase[8];
#endif
    }

    /// <summary>
    ///     The memory helpers class
    /// </summary>
    internal static class MemoryHelpers<T>
    {
        /// <summary>
        ///     The pool
        /// </summary>
        private static readonly FastestArrayPool<T> _pool = new();

        /// <summary>
        ///     Gets the value of the pool
        /// </summary>
        internal static ArrayPool<T> Pool => _pool;
    }
}