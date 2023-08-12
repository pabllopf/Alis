using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace Alis.Core.Graphic.Backends.Vk
{
    /// <summary>
    /// A super-dangerous stack-only list which can hold up to 256 bytes of blittable data.
    /// </summary>
    /// <typeparam name="T">The type of element held in the list. Must be blittable.</typeparam>
    internal unsafe struct StackList<T> where T : struct
    {
        /// <summary>
        /// The capacity in bytes
        /// </summary>
        public const int CapacityInBytes = 256;
        /// <summary>
        /// The 
        /// </summary>
        private static readonly int s_sizeofT = Unsafe.SizeOf<T>();

        /// <summary>
        /// The capacity in bytes
        /// </summary>
        private fixed byte _storage[CapacityInBytes];
        /// <summary>
        /// The count
        /// </summary>
        private uint _count;

        /// <summary>
        /// Gets the value of the count
        /// </summary>
        public uint Count => _count;
        /// <summary>
        /// Gets the value of the data
        /// </summary>
        public void* Data => Unsafe.AsPointer(ref this);

        /// <summary>
        /// Adds the item
        /// </summary>
        /// <param name="item">The item</param>
        public void Add(T item)
        {
            byte* basePtr = (byte*)Data;
            int offset = (int)(_count * s_sizeofT);
#if DEBUG
            Debug.Assert((offset + s_sizeofT) <= CapacityInBytes);
#endif
            Unsafe.Write(basePtr + offset, item);

            _count += 1;
        }

        /// <summary>
        /// The offset
        /// </summary>
        public ref T this[uint index]
        {
            get
            {
                byte* basePtr = (byte*)Unsafe.AsPointer(ref this);
                int offset = (int)(index * s_sizeofT);
                return ref Unsafe.AsRef<T>(basePtr + offset);
            }
        }

        /// <summary>
        /// The offset
        /// </summary>
        public ref T this[int index]
        {
            get
            {
                byte* basePtr = (byte*)Unsafe.AsPointer(ref this);
                int offset = index * s_sizeofT;
                return ref Unsafe.AsRef<T>(basePtr + offset);
            }
        }
    }

    /// <summary>
    /// A super-dangerous stack-only list which can hold a number of bytes determined by the second type parameter.
    /// </summary>
    /// <typeparam name="T">The type of element held in the list. Must be blittable.</typeparam>
    /// <typeparam name="TSize">A type parameter dictating the capacity of the list.</typeparam>
    internal unsafe struct StackList<T, TSize> where T : struct where TSize : struct
    {
        /// <summary>
        /// The 
        /// </summary>
        private static readonly int s_sizeofT = Unsafe.SizeOf<T>();

#pragma warning disable 0169 // Unused field. This is used implicity because it controls the size of the structure on the stack.
        /// <summary>
        /// The storage
        /// </summary>
        private TSize _storage;
#pragma warning restore 0169
        /// <summary>
        /// The count
        /// </summary>
        private uint _count;

        /// <summary>
        /// Gets the value of the count
        /// </summary>
        public uint Count => _count;
        /// <summary>
        /// Gets the value of the data
        /// </summary>
        public void* Data => Unsafe.AsPointer(ref this);

        /// <summary>
        /// Adds the item
        /// </summary>
        /// <param name="item">The item</param>
        public void Add(T item)
        {
            ref T dest = ref Unsafe.Add(ref Unsafe.As<TSize, T>(ref _storage), (int)_count);
#if DEBUG
            int offset = (int)(_count * s_sizeofT);
            Debug.Assert((offset + s_sizeofT) <= Unsafe.SizeOf<TSize>());
#endif
            dest = item;

            _count += 1;
        }

        /// <summary>
        /// The index
        /// </summary>
        public ref T this[int index] => ref Unsafe.Add(ref Unsafe.AsRef<T>(Data), index);
        /// <summary>
        /// The index
        /// </summary>
        public ref T this[uint index] => ref Unsafe.Add(ref Unsafe.AsRef<T>(Data), (int)index);
    }

    /// <summary>
    /// The size 16 bytes
    /// </summary>
    internal unsafe struct Size16Bytes { /// <summary>
 /// The data
 /// </summary>
 public fixed byte Data[16]; }
    /// <summary>
    /// The size 64 bytes
    /// </summary>
    internal unsafe struct Size64Bytes { /// <summary>
 /// The data
 /// </summary>
 public fixed byte Data[64]; }
    /// <summary>
    /// The size 128 bytes
    /// </summary>
    internal unsafe struct Size128Bytes { /// <summary>
 /// The data
 /// </summary>
 public fixed byte Data[64]; }
    /// <summary>
    /// The size 512 bytes
    /// </summary>
    internal unsafe struct Size512Bytes { /// <summary>
 /// The data
 /// </summary>
 public fixed byte Data[1024]; }
    /// <summary>
    /// The size 1024 bytes
    /// </summary>
    internal unsafe struct Size1024Bytes { /// <summary>
 /// The data
 /// </summary>
 public fixed byte Data[1024]; }
    /// <summary>
    /// The size 2048 bytes
    /// </summary>
    internal unsafe struct Size2048Bytes { /// <summary>
 /// The data
 /// </summary>
 public fixed byte Data[2048]; }
#pragma warning disable 0649 // Fields are not assigned directly -- expected.
    /// <summary>
    /// The size int ptr
    /// </summary>
    internal unsafe struct Size2IntPtr { /// <summary>
 /// The first
 /// </summary>
 public IntPtr First; /// <summary>
 /// The second
 /// </summary>
 public IntPtr Second; }
    /// <summary>
    /// The size int ptr
    /// </summary>
    internal unsafe struct Size6IntPtr { /// <summary>
 /// The first
 /// </summary>
 public IntPtr First; /// <summary>
 /// The second
 /// </summary>
 public IntPtr Second; /// <summary>
 /// The third
 /// </summary>
 public IntPtr Third; /// <summary>
 /// The fourth
 /// </summary>
 public IntPtr Fourth; /// <summary>
 /// The fifth
 /// </summary>
 public IntPtr Fifth; /// <summary>
 /// The sixth
 /// </summary>
 public IntPtr Sixth; }
#pragma warning restore 0649
}
