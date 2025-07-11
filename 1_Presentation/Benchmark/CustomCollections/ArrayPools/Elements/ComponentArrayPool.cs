using System;
using System.Buffers;
using System.Numerics;
using System.Runtime.CompilerServices;
using Alis.Core.Ecs.Redifinition;

namespace Alis.Benchmark.CustomCollections.ArrayPools.Elements
{
    //super simple arraypool class
    /// <summary>
    /// The component array pool class
    /// </summary>
    /// <seealso cref="ArrayPool{T}"/>
    public class ComponentArrayPool<T> : ArrayPool<T>
    {
        /// <summary>
        /// The buckets
        /// </summary>
        private T[][] _buckets;

        /// <summary>
        /// Initializes a new instance of the <see cref="ComponentArrayPool{T}"/> class
        /// </summary>
        public ComponentArrayPool()
        {
            //16, 32, 64, 128, 256, 512, 1024, 2048, 4096, 8192, 16384, 32768, 65536 
            //13 array sizes for components
            Gen2GcCallback.Gen2CollectionOccured += ClearBuckets;

            _buckets = new T[27][];
        }
        
        /// <summary>
        /// Gets the value of the instance
        /// </summary>
        public static ComponentArrayPool<T> Instance { get; } = new();

        /// <summary>
        /// Resizes the array from pool using the specified arr
        /// </summary>
        /// <param name="arr">The arr</param>
        /// <param name="len">The len</param>
        public static void ResizeArrayFromPool(ref T[] arr, int len)
        {
            var finalArr = Instance.Rent(len);
            arr.AsSpan().CopyTo(finalArr);
            Instance.Return(arr);
            arr = finalArr;
        }

        /// <summary>
        /// Rents the minimum length
        /// </summary>
        /// <param name="minimumLength">The minimum length</param>
        /// <returns>The array</returns>
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

        /// <summary>
        /// Returns the array
        /// </summary>
        /// <param name="array">The array</param>
        /// <param name="clearArray">The clear array</param>
        public override void Return(T[] array, bool clearArray = false)
        {
            //easier to deal w/ all logic here
            if (RuntimeHelpers.IsReferenceOrContainsReferences<T>())
                array.AsSpan().Clear();
            int bucketIndex = BitOperations.Log2((uint)array.Length) - 4;
            if ((uint)bucketIndex < (uint)_buckets.Length)
                _buckets[bucketIndex] = array;
        }

        /// <summary>
        /// Clears the buckets
        /// </summary>
        private void ClearBuckets()
        {
            _buckets.AsSpan().Clear();
        }
    }
}