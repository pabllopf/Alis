

using System;
using System.Runtime.InteropServices;

namespace Alis.Extension.Graphic.Ui
{
    /// <summary>
    ///     The im vector
    /// </summary>
    public struct ImVector
    {
        /// <summary>
        ///     Gets or sets the size
        /// </summary>
        public int Size { get; set; }

        /// <summary>
        ///     Gets or sets the capacity
        /// </summary>
        public int Capacity { get; set; }

        /// <summary>
        ///     Gets or sets the data
        /// </summary>
        public IntPtr Data { get; set; }

        /// <summary>
        ///     Initializes a new instance of the <see cref="ImVector" /> class
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
        ///     Refs the index
        /// </summary>
        /// <typeparam name="T">The </typeparam>
        /// <param name="index">The index</param>
        /// <returns>The</returns>
        public T Ref<T>(int index) where T : unmanaged
        {
            byte[] bytes = new byte[Marshal.SizeOf<T>()];
            Marshal.Copy(Data + index * Marshal.SizeOf<T>(), bytes, 0, bytes.Length);
            GCHandle handle = GCHandle.Alloc(bytes, GCHandleType.Pinned);
            try
            {
                return (T) Marshal.PtrToStructure(handle.AddrOfPinnedObject(), typeof(T));
            }
            finally
            {
                handle.Free();
            }
        }

        /// <summary>
        ///     Addresses the index
        /// </summary>
        /// <typeparam name="T">The </typeparam>
        /// <param name="index">The index</param>
        /// <returns>The int ptr</returns>
        public IntPtr Address<T>(int index) => Data + index * Marshal.SizeOf<T>();
    }
}