using System;
using System.Numerics;
using Alis.Core.Ecs.Kernel.Memory;

namespace Alis.Core.Ecs.Collections
{
    /// <summary>
    ///     The sparse set class
    /// </summary>
    public class SparseSet<T>
    {
        /// <summary>
        ///     The dense
        /// </summary>
        private T[] _dense;

        /// <summary>
        ///     The next index
        /// </summary>
        private int _nextIndex;

        /// <summary>
        ///     The sparse
        /// </summary>
        private int[] _sparse;

        /// <summary>
        ///     Initializes a new instance of the <see cref="SparseSet{T}" /> class
        /// </summary>
        public SparseSet()
        {
            const int initialCapacity = 4;
            _dense = new T[initialCapacity];
            _sparse = new int[initialCapacity];
            _sparse.AsSpan().Fill(int.MaxValue);
        }

        /// <summary>
        ///     The index
        /// </summary>
        public ref T this[int id]
        {
            get
            {
                ref int index = ref EnsureSparseCapacityAndGetIndex(id);

                if (index == int.MaxValue)
                    index = _nextIndex++;

                return ref MemoryHelpers.GetValueOrResize(ref _dense, index);
            }
        }

        /// <summary>
        ///     Ensures the sparse capacity and get index using the specified id
        /// </summary>
        /// <param name="id">The id</param>
        /// <returns>The ref int</returns>
        private ref int EnsureSparseCapacityAndGetIndex(int id)
        {
            int[] localSparse = _sparse;
            if (id < localSparse.Length)
                return ref localSparse[id];

            return ref ResizeArrayAndGet(ref _sparse, id);

            static ref int ResizeArrayAndGet(ref int[] arr, int index)
            {
                int prevLen = arr.Length;
                Array.Resize(ref arr, (int)BitOperations.RoundUpToPowerOf2((uint)index + 1));
                arr.AsSpan(prevLen).Fill(int.MaxValue);
                return ref arr[index];
            }
        }
    }
}