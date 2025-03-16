using System;
using Frent.Core;
using System.Buffers;
using System.Numerics;
using System.Runtime.CompilerServices;

namespace Frent.Buffers;

/// <summary>
/// The fast stack array pool class
/// </summary>
/// <seealso cref="ArrayPool{T}"/>
internal class FastStackArrayPool<T> : ArrayPool<T>
{
    /// <summary>
    /// Gets the value of the instance
    /// </summary>
    public static FastStackArrayPool<T> Instance { get; } = new();

    /// <summary>
    /// Resizes the array from pool using the specified arr
    /// </summary>
    /// <param name="arr">The arr</param>
    /// <param name="len">The len</param>
    internal static void ResizeArrayFromPool(ref T[] arr, int len)
    {
        var finalArr = Instance.Rent(len);
        arr.AsSpan().CopyTo(finalArr);
        Instance.Return(arr);
        arr = finalArr;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="FastStackArrayPool{T}"/> class
    /// </summary>
    public FastStackArrayPool()
    {
        //16, 32, 64, 128, 256, 512, 1024, 2048, 4096, 8192, 16384, 32768, 65536 
        Gen2GcCallback.Gen2CollectionOccured += ClearBuckets;

        Buckets = new T[27][];
    }

    /// <summary>
    /// The buckets
    /// </summary>
    private T[][] Buckets;

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
        int bucketIndex = BitOperations.Log2((uint)array.Length) - 5;
        if ((uint)bucketIndex < (uint)Buckets.Length)
            Buckets[bucketIndex] = array;
    }

    /// <summary>
    /// Clears the buckets
    /// </summary>
    private void ClearBuckets()
    {
        Buckets.AsSpan().Clear();
    }
}