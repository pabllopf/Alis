using System;
using System.Buffers;
using System.Buffers.Binary;
using System.Numerics;
using System.Runtime.CompilerServices;
using Alis.Core.Ecs.Core.Memory;

namespace Alis.Core.Ecs.Buffers
{
    public sealed class ComponentArrayPool<T> : ArrayPool<T>
    {
        private readonly T[][] Buckets;

        public ComponentArrayPool()
        {
            Gen2GcCallback.Gen2CollectionOccured += ClearBuckets;
            Buckets = new T[27][];
        }

        public static ComponentArrayPool<T> Instance { get; } = new ComponentArrayPool<T>();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override T[] Rent(int minimumLength)
        {
            if ((uint)minimumLength < 16u)
            {
                return new T[minimumLength];
            }

            int bucketIndex = BitOperations.Log2((uint)minimumLength) - 4;
            if ((uint)bucketIndex < (uint)Buckets.Length)
            {
                T[] array = Buckets[bucketIndex];
                if (array != null)
                {
                    Buckets[bucketIndex] = null;
                    return array;
                }
            }
            return new T[minimumLength];
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override void Return(T[] array, bool clearArray = false)
        {
            if (RuntimeHelpers.IsReferenceOrContainsReferences<T>())
            {
                array.AsSpan().Clear();
            }

            int bucketIndex = BitOperations.Log2((uint)array.Length) - 4;
            if ((uint)bucketIndex < (uint)Buckets.Length)
            {
                Buckets[bucketIndex] = array;
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ResizeArrayFromPool(ref T[] arr, int len)
        {
            T[] newArr = Instance.Rent(len);
            arr.AsSpan().CopyTo(newArr);
            Instance.Return(arr);
            arr = newArr;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private void ClearBuckets() => Array.Clear(Buckets, 0, Buckets.Length);
    }
}
