using System;

namespace Alis.Core.Graphic.ImGui
{
    /// <summary>
    /// The range accessor
    /// </summary>
    public unsafe struct RangeAccessor<T> where T : unmanaged
    {
        /// <summary>
        /// The 
        /// </summary>
        private static readonly int s_sizeOfT = Unsafe.SizeOf<T>();

        /// <summary>
        /// The data
        /// </summary>
        public readonly void* Data;
        /// <summary>
        /// The count
        /// </summary>
        public readonly int Count;

        /// <summary>
        /// Initializes a new instance of the class
        /// </summary>
        /// <param name="data">The data</param>
        /// <param name="count">The count</param>
        public RangeAccessor(IntPtr data, int count) : this(data.ToPointer(), count) { }
        /// <summary>
        /// Initializes a new instance of the class
        /// </summary>
        /// <param name="data">The data</param>
        /// <param name="count">The count</param>
        public RangeAccessor(void* data, int count)
        {
            Data = data;
            Count = count;
        }

        /// <summary>
        /// The index
        /// </summary>
        public ref T this[int index]
        {
            get
            {
                if (index < 0 || index >= Count)
                {
                    throw new IndexOutOfRangeException();
                }

                return ref Unsafe.AsRef<T>((byte*)Data + s_sizeOfT * index);
            }
        }
    }
}
