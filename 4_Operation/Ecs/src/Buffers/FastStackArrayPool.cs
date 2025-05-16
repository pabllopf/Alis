﻿using System;
using Alis.Core.Ecs.Core;
using System.Buffers;
using System.Numerics;
using System.Runtime.CompilerServices;
using Alis.Core.Ecs.Core.Memory;

namespace Alis.Core.Ecs.Buffers
{
    internal class FastStackArrayPool<T> : ArrayPool<T>
    {
        public static FastStackArrayPool<T> Instance { get; } = new();

        internal static void ResizeArrayFromPool(ref T[] arr, int len)
        {
            var finalArr = Instance.Rent(len);
            arr.AsSpan().CopyTo(finalArr);
            Instance.Return(arr);
            arr = finalArr;
        }

        public FastStackArrayPool()
        {
            //16, 32, 64, 128, 256, 512, 1024, 2048, 4096, 8192, 16384, 32768, 65536 
            Gen2GcCallback.Gen2CollectionOccured += ClearBuckets;

            Buckets = new T[27][];
        }

        private T[][] Buckets;

        public override T[] Rent(int minimumLength)
        {
            if (minimumLength < 16)
                return new T[minimumLength];

            int bucketIndex = BitOperations.Log2((uint)minimumLength) - 4;

            if ((uint)bucketIndex < (uint)Buckets.Length)
            {
                ref T[] item = ref Buckets[bucketIndex];

                if (item is not null)
                {
                    var loc = item;
                    item = null!;
                    return loc;
                }
            }

            return new T[minimumLength];//GC.AllocateUninitializedArray<T>(minimumLength)
            //benchmarks say uninit is the same speed
        }

        public override void Return(T[] array, bool clearArray = false)
        {
            //easier to deal w/ all logic here
            if (RuntimeHelpers.IsReferenceOrContainsReferences<T>())
                array.AsSpan().Clear();
            int bucketIndex = BitOperations.Log2((uint)array.Length) - 5;
            if ((uint)bucketIndex < (uint)Buckets.Length)
                Buckets[bucketIndex] = array;
        }

        private void ClearBuckets()
        {
            Buckets.AsSpan().Clear();
        }
    }
}