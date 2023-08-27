using System;
using Alis.Core.Graphic.ImGui.Utils;

namespace Alis.Core.Graphic.Imgui
{
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