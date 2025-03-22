﻿using System;
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
    internal static class MemoryHelpers
    {
        public const int MaxComponentCount = 127;

        public static uint RoundDownToPowerOfTwo(uint value) => BitOperations.RoundUpToPowerOf2((value >> 1) + 1);

        public static int RoundUpToNextMultipleOf16(int value) => (value + 15) & ~15;
        public static int RoundDownToNextMultipleOf16(int value) => value & ~15;
        public static byte BoolToByte(bool b) => Unsafe.As<bool, byte>(ref b);

        public static ImmutableArray<T> ReadOnlySpanToImmutableArray<T>(ReadOnlySpan<T> span)
        {
            var builder = ImmutableArray.CreateBuilder<T>(span.Length);
            for (int i = 0; i < span.Length; i++)
                builder.Add(span[i]);
            return builder.MoveToImmutable();
        }

        public static ImmutableArray<T> Concat<T>(ImmutableArray<T> start, ReadOnlySpan<T> span)
            where T : ITypeID
        {
            var builder = ImmutableArray.CreateBuilder<T>(start.Length + span.Length);
            for (int i = 0; i < start.Length; i++)
                builder.Add(start[i]);
            for (int i = 0; i < span.Length; i++)
            {
                var t = span[i];
                if (start.IndexOf(t) != -1)
                    FrentExceptions.Throw_InvalidOperationException($"This entity already has a component of type {t.Type.Name}");
                builder.Add(t);
            }
            return builder.MoveToImmutable();
        }

        public static ImmutableArray<T> Concat<T>(ImmutableArray<T> types, T type)
            where T : ITypeID
        {
            if (types.IndexOf(type) != -1)
                FrentExceptions.Throw_InvalidOperationException($"This entity already has a component of type {type.Type.Name}");

            var builder = ImmutableArray.CreateBuilder<T>(types.Length + 1);
            builder.AddRange(types);
            builder.Add(type);

            var result = builder.MoveToImmutable();
            return result;
        }

        public static ImmutableArray<T> Remove<T>(ImmutableArray<T> types, T type)
            where T : ITypeID
        {
            int index = types.IndexOf(type);
            if (index == -1)
                FrentExceptions.Throw_ComponentNotFoundException(type.Type);
            var result = types.RemoveAt(index);
            return result;
        }

        public static ImmutableArray<T> Remove<T>(ImmutableArray<T> types, ReadOnlySpan<T> span)
            where T : ITypeID
        {
            var builder = ImmutableArray.CreateBuilder<T>(types.Length);
            builder.AddRange(types);

            foreach (var type in span)
            {
                int index = builder.IndexOf(type);
                if (index == -1)
                    FrentExceptions.Throw_ComponentNotFoundException(type.Type);
                builder.RemoveAt(index);
            }

            return builder.ToImmutable();
        }

        public static TValue GetOrAddNew<TKey, TValue>(this Dictionary<TKey, TValue> dictionary, TKey key)
            where TKey : notnull
            where TValue : new()
        {
#if NETSTANDARD2_1
        if (dictionary.TryGetValue(key, out var value))
        {
            return value;
        }
        return dictionary[key] = new();
#else
            ref var res = ref CollectionsMarshal.GetValueRefOrAddDefault(dictionary, key, out bool _);
            return res ??= new();
#endif
        }

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

        [StructLayout(LayoutKind.Sequential, Size = 2)]
        internal struct Block2;
        [StructLayout(LayoutKind.Sequential, Size = 4)]
        internal struct Block4;
        [StructLayout(LayoutKind.Sequential, Size = 8)]
        internal struct Block8;
        [StructLayout(LayoutKind.Sequential, Size = 16)]
        internal struct Block16;


        // catch bugs with Unsafe.SkitInit
        [Conditional("DEBUG")]
        public static void Poison<T>(ref T item)
        {
            if (RuntimeHelpers.IsReferenceOrContainsReferences<T>())
                throw new NotSupportedException("Cleared anyways");

#if NET6_0_OR_GREATER
            Span<byte> raw = MemoryMarshal.CreateSpan(ref Unsafe.As<T, byte>(ref item), Unsafe.SizeOf<T>());
            raw.Fill(93);
#endif
        }
    }

    internal static class MemoryHelpers<T>
    {
        private static ComponentArrayPool<T> _pool = new();
        internal static ArrayPool<T> Pool => _pool;
    }
}