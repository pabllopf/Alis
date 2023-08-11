using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Veldrid.OpenGL
{
    /// <summary>
    /// The staging memory pool class
    /// </summary>
    /// <seealso cref="IDisposable"/>
    internal unsafe sealed class StagingMemoryPool : IDisposable
    {
        /// <summary>
        /// The minimum capacity
        /// </summary>
        private const uint MinimumCapacity = 128;

        /// <summary>
        /// The storage
        /// </summary>
        private readonly List<StagingBlock> _storage;
        /// <summary>
        /// The available blocks
        /// </summary>
        private readonly SortedList<uint, uint> _availableBlocks;
        /// <summary>
        /// The lock
        /// </summary>
        private object _lock = new object();
        /// <summary>
        /// The disposed
        /// </summary>
        private bool _disposed;

        /// <summary>
        /// Initializes a new instance of the <see cref="StagingMemoryPool"/> class
        /// </summary>
        public StagingMemoryPool()
        {
            _storage = new List<StagingBlock>();
            _availableBlocks = new SortedList<uint, uint>(new CapacityComparer());
        }

        /// <summary>
        /// Stages the source
        /// </summary>
        /// <param name="source">The source</param>
        /// <param name="sizeInBytes">The size in bytes</param>
        /// <returns>The block</returns>
        public StagingBlock Stage(IntPtr source, uint sizeInBytes)
        {
            Rent(sizeInBytes, out StagingBlock block);
            Unsafe.CopyBlock(block.Data, source.ToPointer(), sizeInBytes);
            return block;
        }

        /// <summary>
        /// Stages the bytes
        /// </summary>
        /// <param name="bytes">The bytes</param>
        /// <returns>The block</returns>
        public StagingBlock Stage(byte[] bytes)
        {
            Rent((uint)bytes.Length, out StagingBlock block);
            Marshal.Copy(bytes, 0, (IntPtr)block.Data, bytes.Length);
            return block;
        }

        /// <summary>
        /// Gets the staging block using the specified size in bytes
        /// </summary>
        /// <param name="sizeInBytes">The size in bytes</param>
        /// <returns>The block</returns>
        public StagingBlock GetStagingBlock(uint sizeInBytes)
        {
            Rent(sizeInBytes, out StagingBlock block);
            return block;
        }

        /// <summary>
        /// Retrieves the by id using the specified id
        /// </summary>
        /// <param name="id">The id</param>
        /// <returns>The staging block</returns>
        public StagingBlock RetrieveById(uint id)
        {
            return _storage[(int)id];
        }

        /// <summary>
        /// Rents the size
        /// </summary>
        /// <param name="size">The size</param>
        /// <param name="block">The block</param>
        private void Rent(uint size, out StagingBlock block)
        {
            lock (_lock)
            {
                SortedList<uint, uint> available = _availableBlocks;
                IList<uint> indices = available.Values;
                for (int i = 0; i < available.Count; i++)
                {
                    int index = (int)indices[i];
                    StagingBlock current = _storage[index];
                    if (current.Capacity >= size)
                    {
                        available.RemoveAt(i);
                        current.SizeInBytes = size;
                        block = current;
                        _storage[index] = current;
                        return;
                    }
                }

                Allocate(size, out block);
            }
        }

        /// <summary>
        /// Allocates the size in bytes
        /// </summary>
        /// <param name="sizeInBytes">The size in bytes</param>
        /// <param name="stagingBlock">The staging block</param>
        private void Allocate(uint sizeInBytes, out StagingBlock stagingBlock)
        {
            uint capacity = Math.Max(MinimumCapacity, sizeInBytes);
            IntPtr ptr = Marshal.AllocHGlobal((int)capacity);
            uint id = (uint)_storage.Count;
            stagingBlock = new StagingBlock(id, (void*)ptr, capacity, sizeInBytes);
            _storage.Add(stagingBlock);
        }

        /// <summary>
        /// Frees the block
        /// </summary>
        /// <param name="block">The block</param>
        public void Free(StagingBlock block)
        {
            lock (_lock)
            {
                if (!_disposed)
                {
                    Debug.Assert(block.Id < _storage.Count);
                    _availableBlocks.Add(block.Capacity, block.Id);
                }
            }
        }

        /// <summary>
        /// Disposes this instance
        /// </summary>
        public void Dispose()
        {
            lock (_lock)
            {
                _availableBlocks.Clear();
                foreach (StagingBlock block in _storage)
                {
                    Marshal.FreeHGlobal((IntPtr)block.Data);
                }
                _storage.Clear();
                _disposed = true;
            }
        }

        /// <summary>
        /// The capacity comparer class
        /// </summary>
        /// <seealso cref="IComparer{uint}"/>
        private class CapacityComparer : IComparer<uint>
        {
            /// <summary>
            /// Compares the x
            /// </summary>
            /// <param name="x">The </param>
            /// <param name="y">The </param>
            /// <returns>The int</returns>
            public int Compare(uint x, uint y)
            {
                return x >= y ? 1 : -1;
            }
        }
    }

    /// <summary>
    /// The staging block
    /// </summary>
    internal unsafe struct StagingBlock
    {
        /// <summary>
        /// The id
        /// </summary>
        public readonly uint Id;
        /// <summary>
        /// The data
        /// </summary>
        public readonly void* Data;
        /// <summary>
        /// The capacity
        /// </summary>
        public readonly uint Capacity;
        /// <summary>
        /// The size in bytes
        /// </summary>
        public uint SizeInBytes;

        /// <summary>
        /// Initializes a new instance of the <see cref="StagingBlock"/> class
        /// </summary>
        /// <param name="id">The id</param>
        /// <param name="data">The data</param>
        /// <param name="capacity">The capacity</param>
        /// <param name="size">The size</param>
        public StagingBlock(uint id, void* data, uint capacity, uint size)
        {
            Id = id;
            Data = data;
            Capacity = capacity;
            SizeInBytes = size;
        }
    }
}
