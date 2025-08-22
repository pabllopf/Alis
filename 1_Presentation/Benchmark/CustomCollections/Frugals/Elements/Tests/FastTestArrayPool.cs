using System;
using System.Buffers;
using System.Numerics;
using System.Runtime.CompilerServices;
using Alis.Core.Ecs;
using Alis.Core.Ecs.Redifinition;

namespace Alis.Benchmark.CustomCollections.Frugals.Elements.Tests
{
    /// <summary>
    /// The fast test array pool class
    /// </summary>
    /// <seealso cref="ArrayPool{T}"/>
    public sealed class FastTestArrayPool<T> : ArrayPool<T>
    {
        /// <summary>
        /// The min bucket size
        /// </summary>
        private const int MinBucketSize = 16;     // 2^4
        /// <summary>
        /// The bucket count
        /// </summary>
        private const int BucketCount = 27;       // Buckets from 2^4 (16) to 2^30 (~1G elements)
        /// <summary>
        /// The bucket count
        /// </summary>
        private readonly T[][] _buckets = new T[BucketCount][];

        /// <summary>
        /// Gets the value of the instance
        /// </summary>
        public static FastTestArrayPool<T> Instance { get; } = new();

        /// <summary>
        /// Initializes a new instance of the <see cref="FastTestArrayPool{T}"/> class
        /// </summary>
        public FastTestArrayPool()
        {
            Gen2GcCallback.Gen2CollectionOccured += ClearBuckets;
        }

        /// <summary>
        /// Resizes the array from pool using the specified arr
        /// </summary>
        /// <param name="arr">The arr</param>
        /// <param name="len">The len</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ResizeArrayFromPool(ref T[] arr, int len)
        {
            var finalArr = Instance.Rent(len);
            arr.AsSpan().CopyTo(finalArr.AsSpan(0, Math.Min(arr.Length, finalArr.Length)));
            Instance.Return(arr);
            arr = finalArr;
        }

        /// <summary>
        /// Rents the minimum length
        /// </summary>
        /// <param name="minimumLength">The minimum length</param>
        /// <returns>The array</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override T[] Rent(int minimumLength)
        {
            if (minimumLength < MinBucketSize)
                return new T[minimumLength];

            int bucketIndex = GetBucketIndex(minimumLength);
            if (bucketIndex == -1)
                return new T[minimumLength]; // fallback for oversized arrays

            ref T[] slot = ref _buckets[bucketIndex];
            if (slot is not null)
            {
                var arr = slot;
                slot = null!;
                return arr!;
            }

#if NET6_0_OR_GREATER
            return GC.AllocateUninitializedArray<T>(1 << (bucketIndex + 4));
#else
            return new T[1 << (bucketIndex + 4)];
#endif
        }

        /// <summary>
        /// Returns the array
        /// </summary>
        /// <param name="array">The array</param>
        /// <param name="clearArray">The clear array</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override void Return(T[] array, bool clearArray = false)
        {
            int bucketIndex = GetBucketIndex(array.Length);
            if (bucketIndex == -1)
                return;

            if (clearArray && RuntimeHelpers.IsReferenceOrContainsReferences<T>())
                array.AsSpan().Clear();

            _buckets[bucketIndex] = array;
        }

        /// <summary>
        /// Gets the bucket index using the specified size
        /// </summary>
        /// <param name="size">The size</param>
        /// <returns>The int</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static int GetBucketIndex(int size)
        {
            if (size < MinBucketSize)
                return -1;

            int log2;
#if NET6_0_OR_GREATER
            log2 = BitOperations.Log2((uint)size - 1) + 1;
#else
            log2 = 0;
            int n = size - 1;
            if ((n & 0xFFFF0000) != 0) { n >>= 16; log2 += 16; }
            if ((n & 0xFF00) != 0) { n >>= 8; log2 += 8; }
            if ((n & 0xF0) != 0) { n >>= 4; log2 += 4; }
            if ((n & 0xC) != 0) { n >>= 2; log2 += 2; }
            if ((n & 0x2) != 0) log2 += 1;
            log2 += 1; // since we rounded down
#endif

            int index = log2 - 4;
            return (index >= 0 && index < BucketCount) ? index : -1;
        }

        /// <summary>
        /// Clears the buckets
        /// </summary>
        private void ClearBuckets()
        {
            for (int i = 0; i < BucketCount; i++)
                _buckets[i] = null;
        }
    }
}