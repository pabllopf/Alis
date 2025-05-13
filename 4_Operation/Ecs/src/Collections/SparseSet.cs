using System;
using System.Numerics;
using Alis.Core.Ecs.Core;
using Alis.Core.Ecs.Core.Memory;

namespace Alis.Core.Ecs.Collections
{
    internal class SparseSet<T>
    {
        private int _nextIndex;
        private T[] _dense;
        private int[] _sparse;

        public ref T this[int id]
        {
            get
            {
                ref var index = ref EnsureSparseCapacityAndGetIndex(id);

                if (index == int.MaxValue)
                    index = _nextIndex++;

                return ref MemoryHelpers.GetValueOrResize(ref _dense, index);
            }
        }

        public SparseSet()
        {
            const int InitialCapacity = 4;
            _dense = new T[InitialCapacity];
            _sparse = new int[InitialCapacity];
            _sparse.AsSpan().Fill(int.MaxValue);
        }

        private ref int EnsureSparseCapacityAndGetIndex(int id)
        {
            var localSparse = _sparse;
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
