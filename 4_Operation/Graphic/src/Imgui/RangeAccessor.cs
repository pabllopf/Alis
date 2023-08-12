using System;
using System.Runtime.CompilerServices;
using System.Text;

namespace Alis.Core.Graphic.Imgui
{
    /// <summary>
    /// The range accessor
    /// </summary>
    public unsafe struct RangeAccessor<T> where T : struct
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
        /// Initializes a new instance of the <see cref="RangeAccessor"/> class
        /// </summary>
        /// <param name="data">The data</param>
        /// <param name="count">The count</param>
        public RangeAccessor(IntPtr data, int count) : this(data.ToPointer(), count) { }
        /// <summary>
        /// Initializes a new instance of the <see cref="RangeAccessor"/> class
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

    /// <summary>
    /// The range ptr accessor
    /// </summary>
    public unsafe struct RangePtrAccessor<T> where T : struct
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
        /// Initializes a new instance of the <see cref="RangePtrAccessor"/> class
        /// </summary>
        /// <param name="data">The data</param>
        /// <param name="count">The count</param>
        public RangePtrAccessor(IntPtr data, int count) : this(data.ToPointer(), count) { }
        /// <summary>
        /// Initializes a new instance of the <see cref="RangePtrAccessor"/> class
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

    /// <summary>
    /// The range accessor extensions class
    /// </summary>
    public static class RangeAccessorExtensions
    {
        /// <summary>
        /// Gets the string ascii using the specified string accessor
        /// </summary>
        /// <param name="stringAccessor">The string accessor</param>
        /// <returns>The string</returns>
        public static unsafe string GetStringASCII(this RangeAccessor<byte> stringAccessor)
        {
            return Encoding.ASCII.GetString((byte*)stringAccessor.Data, stringAccessor.Count);
        }
    }
}
