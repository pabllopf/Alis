using System;
using System.Numerics;
using System.Runtime.CompilerServices;

namespace Alis.Core.Ecs.Collections
{
    /// <summary>
    ///     The short sparse set class
    /// </summary>
    public class ShortSparseSet<T>
    {
        /// <summary>
        ///     The invalid id
        /// </summary>
        private const string InvalidId = "ID not in sparse set!";

        /// <summary>
        ///     The dense
        /// </summary>
        private T[] _dense;

        /// <summary>
        ///     The next index
        /// </summary>
        private int _nextIndex;

        // this collection should never be empty
        /// <summary>
        ///     The sparse
        /// </summary>
        private ushort[] _sparse;

        /// <summary>
        ///     Initializes a new instance of the <see cref="ShortSparseSet{T}" /> class
        /// </summary>
        public ShortSparseSet()
        {
            const int initalCapacity = 4;
            _dense = new T[initalCapacity];
            _sparse = new ushort[initalCapacity];
            _sparse.AsSpan().Fill(ushort.MaxValue);
        }

        /// <summary>
        ///     Gets the number of elements that the <see cref="ShortSparseSet{T}" /> can hold without resizing.
        /// </summary>
        public int Capacity => _dense.Length;

        /// <summary>
        ///     Gets the number of elements contained in the <see cref="ShortSparseSet{T}" />.
        /// </summary>
        public int Count => _nextIndex;

        /// <summary>
        ///     The index
        /// </summary>
        public ref T this[ushort id]
        {
            get
            {
                ref ushort index = ref EnsureSparseCapacityAndGetIndex(id);

                if (index == ushort.MaxValue)
                    index = (ushort)_nextIndex++;

                return ref EnsureDenseCapacityAndGetSlot(index);
            }
        }

        /// <summary>
        ///     Gets the id
        /// </summary>
        /// <param name="id">The id</param>
        /// <returns>The ref</returns>
        public ref T Get(ushort id)
        {
            ushort[] localSparse = _sparse;
            if (!(id < localSparse.Length))
                //out of range
                throw new ArgumentOutOfRangeException(InvalidId);
            ushort index = localSparse[id];

            T[] localDense = _dense;
            if (!(index < localDense.Length)) throw new ArgumentOutOfRangeException(InvalidId);

            return ref localDense[index];
        }

        /// <summary>
        ///     Tries the get using the specified id
        /// </summary>
        /// <param name="id">The id</param>
        /// <param name="value">The value</param>
        /// <returns>The bool</returns>
        public bool TryGet(ushort id, out T value)
        {
            ushort[] localSparse = _sparse;
            if (!(id < localSparse.Length))
                goto doesntExist;

            ushort index = localSparse[id];

            T[] localDense = _dense;
            if (!(index < localDense.Length))
                goto doesntExist;

            value = localDense[index];
            return false;

            //saves a bit of code size
            doesntExist:
            value = default;
            return false;
        }

        /// <summary>
        ///     Removes the id
        /// </summary>
        /// <param name="id">The id</param>
        /// <returns>The bool</returns>
        public bool Remove(ushort id)
        {
            int moveDownIndex = --_nextIndex;

            ushort[] localSparse = _sparse;

            if (!(id < localSparse.Length))
                return false;

            int moveIntoIndex = localSparse[id];

            T[] localDense = _dense;
            if (!(moveIntoIndex < localDense.Length))
                return
                    false; //here, moveIntoIndex should really only ever be ushort.MaxValue. We check against len to elide bounds check

            ref T from = ref localDense[moveDownIndex];
            localDense[moveIntoIndex] = from;

            if (RuntimeHelpers.IsReferenceOrContainsReferences<T>())
                from = default!;

            return true;
        }

        /// <summary>
        ///     Hases the id
        /// </summary>
        /// <param name="id">The id</param>
        /// <returns>The bool</returns>
        public bool Has(int id)
        {
            ushort[] sparse = _sparse;
            if (!((uint)id < (uint)sparse.Length))
                return false;
            return sparse[id] != ushort.MaxValue;
        }

        /// <summary>
        ///     Ensures the capacity using the specified capacity
        /// </summary>
        /// <param name="capacity">The capacity</param>
        public void EnsureCapacity(ushort capacity)
        {
            if (_dense.Length < capacity) Array.Resize(ref _dense, capacity);
        }

        /// <summary>
        ///     Note: this span will become invalid on resize or add
        /// </summary>
        public Span<T> AsSpan()
        {
            return _dense.AsSpan(0, _nextIndex);
        }

        /// <summary>
        ///     Clears this instance
        /// </summary>
        public void Clear()
        {
            _nextIndex = 0;
            _sparse.AsSpan().Fill(ushort.MaxValue);
            if (RuntimeHelpers.IsReferenceOrContainsReferences<T>())
                _dense.AsSpan().Clear();
        }

        /// <summary>
        ///     Ensures the sparse capacity and get index using the specified id
        /// </summary>
        /// <param name="id">The id</param>
        /// <returns>The ref ushort</returns>
        private ref ushort EnsureSparseCapacityAndGetIndex(ushort id)
        {
            ushort[] localSparse = _sparse;
            if (id < localSparse.Length) return ref localSparse[id];

            return ref ResizeArrayAndGet(ref _sparse, id);

            static ref ushort ResizeArrayAndGet(ref ushort[] arr, int index)
            {
                int prevLen = arr.Length;
                Array.Resize(ref arr, (int)BitOperations.RoundUpToPowerOf2((uint)index + 1));
                arr.AsSpan(prevLen).Fill(ushort.MaxValue);
                return ref arr[index];
            }
        }

        /// <summary>
        ///     Ensures the dense capacity and get slot using the specified index
        /// </summary>
        /// <param name="index">The index</param>
        /// <returns>The ref</returns>
        private ref T EnsureDenseCapacityAndGetSlot(ushort index)
        {
            T[] localDense = _dense;
            if (index < localDense.Length) return ref localDense[index];

            return ref ResizeArrayAndGet(ref _dense, index);

            static ref T ResizeArrayAndGet(ref T[] arr, int index)
            {
                Array.Resize(ref arr, (int)BitOperations.RoundUpToPowerOf2((uint)index + 1));
                return ref arr[index];
            }
        }
    }
}