using System;
using Alis.Core.Graphic.ImGui.Utils;

namespace Alis.Core.Graphic.Imgui
{
    /// <summary>
    /// The range ptr accessor
    /// </summary>
    public unsafe struct RangePtrAccessor<T> where T : unmanaged
    {
        /// <summary>
        /// The data
        /// </summary>
        public readonly void* Data;
        /// <summary>
        /// The count
        /// </summary>
        public readonly int Count;

        /// <summary>
        /// Initializes a new instance of the  class
        /// </summary>
        /// <param name="data">The data</param>
        /// <param name="count">The count</param>
        public RangePtrAccessor(IntPtr data, int count) : this(data.ToPointer(), count) { }
        /// <summary>
        /// Initializes a new instance of the  class
        /// </summary>
        /// <param name="data">The data</param>
        /// <param name="count">The count</param>
        public RangePtrAccessor(void* data, int count)
        {
            Data = data;
            Count = count;
        }

        /// <summary>
        /// The index
        /// </summary>
        public T this[int index]
        {
            get
            {
                if (index < 0 || index >= Count)
                {
                    throw new IndexOutOfRangeException();
                }

                return Unsafe.Read<T>((byte*)Data + sizeof(void*) * index);
            }
        }
    }
}