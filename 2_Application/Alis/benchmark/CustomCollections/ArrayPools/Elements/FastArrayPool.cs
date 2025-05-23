using System;
using System.Buffers;
using System.Numerics;
using System.Runtime.CompilerServices;

namespace Alis.Benchmark.CustomCollections.ArrayPools.Elements
{
    public class FastArrayPool<T> : ArrayPool<T>
    {
        private T[][] _buckets;

        public FastArrayPool()
        {
            //16, 32, 64, 128, 256, 512, 1024, 2048, 4096, 8192, 16384, 32768, 65536 
            Gen2GcCallback.Gen2CollectionOccured += ClearBuckets;

            _buckets = new T[27][];
        }

        public static FastArrayPool<T> Instance { get; } = new();

        public static void ResizeArrayFromPool(ref T[] arr, int len)
        {
            var finalArr = Instance.Rent(len);
            arr.AsSpan().CopyTo(finalArr);
            Instance.Return(arr);
            arr = finalArr;
        }

        public override T[] Rent(int minimumLength)
        {
            if (minimumLength < 16)
                return new T[minimumLength];

            int bucketIndex = BitOperations.Log2((uint)minimumLength) - 4;

            if ((uint)bucketIndex < (uint)_buckets.Length)
            {
                ref T[] item = ref _buckets[bucketIndex];

                if (item is not null)
                {
                    var loc = item;
                    item = null!;
                    return loc;
                }
            }

            return new T[minimumLength]; 
        }

        public override void Return(T[] array, bool clearArray = false)
        {
            //easier to deal w/ all logic here
            if (RuntimeHelpers.IsReferenceOrContainsReferences<T>())
                array.AsSpan().Clear();
            int bucketIndex = BitOperations.Log2((uint)array.Length) - 5;
            if ((uint)bucketIndex < (uint)_buckets.Length)
                _buckets[bucketIndex] = array;
        }

        private void ClearBuckets()
        {
            _buckets.AsSpan().Clear();
        }
    }
}