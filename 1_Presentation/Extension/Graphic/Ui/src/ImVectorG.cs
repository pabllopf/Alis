

using System;
using System.Runtime.InteropServices;

namespace Alis.Extension.Graphic.Ui
{
    /// <summary>
    ///     The im vector
    /// </summary>
    public readonly struct ImVectorG<T> where T : unmanaged
    {
        /// <summary>
        ///     The size
        /// </summary>
        public readonly int Size;

        /// <summary>
        ///     The capacity
        /// </summary>
        public readonly int Capacity;

        /// <summary>
        ///     The data
        /// </summary>
        public readonly IntPtr Data;

        /// <summary>
        ///     Initializes a new instance of the <see cref="ImVector" /> class
        /// </summary>
        /// <param name="vector">The vector</param>
        public ImVectorG(ImVector vector)
        {
            Size = vector.Size;
            Capacity = vector.Capacity;
            Data = vector.Data;
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="ImVector" /> class
        /// </summary>
        /// <param name="size">The size</param>
        /// <param name="capacity">The capacity</param>
        /// <param name="data">The data</param>
        public ImVectorG(int size, int capacity, IntPtr data)
        {
            Size = size;
            Capacity = capacity;
            Data = data;
        }

        /// <summary>
        ///     The free
        /// </summary>
        public T this[int index]
        {
            get
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
        }
    }
}