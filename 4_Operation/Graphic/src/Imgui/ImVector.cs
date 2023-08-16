using System;
using System.Runtime.CompilerServices;
using Alis.Core.Graphic.ImGui.Utils;

namespace Alis.Core.Graphic.Imgui
{
    /// <summary>
    /// The im vector
    /// </summary>
    public unsafe struct ImVector
    {
        /// <summary>
        /// The size
        /// </summary>
        public readonly int Size;
        /// <summary>
        /// The capacity
        /// </summary>
        public readonly int Capacity;
        /// <summary>
        /// The data
        /// </summary>
        public readonly IntPtr Data;

        /// <summary>
        /// Initializes a new instance of the <see cref="ImVector"/> class
        /// </summary>
        /// <param name="size">The size</param>
        /// <param name="capacity">The capacity</param>
        /// <param name="data">The data</param>
        public ImVector(int size, int capacity, IntPtr data)
        {
            Size = size;
            Capacity = capacity;
            Data = data;
        }

        /// <summary>
        /// Refs the index
        /// </summary>
        /// <typeparam name="T">The </typeparam>
        /// <param name="index">The index</param>
        /// <returns>The ref</returns>
        public ref T Ref<T>(int index) where T : unmanaged
        {
            return ref Unsafe.AsRef<T>((byte*)Data + index * Unsafe.SizeOf<T>());
        }

        /// <summary>
        /// Addresses the index
        /// </summary>
        /// <typeparam name="T">The </typeparam>
        /// <param name="index">The index</param>
        /// <returns>The int ptr</returns>
        public IntPtr Address<T>(int index)
        {
            return (IntPtr)((byte*)Data + index * Unsafe.SizeOf<T>());
        }
    }

    /// <summary>
    /// The im vector
    /// </summary>
    public unsafe struct ImVector<T> where T : unmanaged
    {
        /// <summary>
        /// The size
        /// </summary>
        public readonly int Size;
        /// <summary>
        /// The capacity
        /// </summary>
        public readonly int Capacity;
        /// <summary>
        /// The data
        /// </summary>
        public readonly IntPtr Data;

        /// <summary>
        /// Initializes a new instance of the <see cref="ImVector"/> class
        /// </summary>
        /// <param name="vector">The vector</param>
        public ImVector(ImVector vector)
        {
            Size = vector.Size;
            Capacity = vector.Capacity;
            Data = vector.Data;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ImVector"/> class
        /// </summary>
        /// <param name="size">The size</param>
        /// <param name="capacity">The capacity</param>
        /// <param name="data">The data</param>
        public ImVector(int size, int capacity, IntPtr data)
        {
            Size = size;
            Capacity = capacity;
            Data = data;
        }

        /// <summary>
        /// The 
        /// </summary>
        public ref T this[int index] => ref Unsafe.AsRef<T>((byte*)Data + index * Unsafe.SizeOf<T>());
    }

    /// <summary>
    /// The im ptr vector
    /// </summary>
    public unsafe struct ImPtrVector<T> where T : unmanaged
    {
        /// <summary>
        /// The size
        /// </summary>
        public readonly int Size;
        /// <summary>
        /// The capacity
        /// </summary>
        public readonly int Capacity;
        /// <summary>
        /// The data
        /// </summary>
        public readonly IntPtr Data;
        /// <summary>
        /// The stride
        /// </summary>
        private readonly int _stride;

        /// <summary>
        /// Initializes a new instance of the  class
        /// </summary>
        /// <param name="vector">The vector</param>
        /// <param name="stride">The stride</param>
        public ImPtrVector(ImVector vector, int stride)
            : this(vector.Size, vector.Capacity, vector.Data, stride)
        { }

        /// <summary>
        /// Initializes a new instance of the  class
        /// </summary>
        /// <param name="size">The size</param>
        /// <param name="capacity">The capacity</param>
        /// <param name="data">The data</param>
        /// <param name="stride">The stride</param>
        public ImPtrVector(int size, int capacity, IntPtr data, int stride)
        {
            Size = size;
            Capacity = capacity;
            Data = data;
            _stride = stride;
        }

        /// <summary>
        /// The ret
        /// </summary>
        public T this[int index]
        {
            get
            {
                byte* address = (byte*)Data + index * _stride;
                T ret = Unsafe.Read<T>(&address);
                return ret;
            }
        }
    }
}
