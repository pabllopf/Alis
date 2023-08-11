using System;
using System.Buffers;
using System.Runtime.CompilerServices;

namespace Veldrid
{
    /// <summary>
    /// The small fixed or dynamic array
    /// </summary>
    internal unsafe struct SmallFixedOrDynamicArray : IDisposable
    {
        /// <summary>
        /// The max fixed values
        /// </summary>
        private const int MaxFixedValues = 5;

        /// <summary>
        /// The count
        /// </summary>
        public readonly uint Count;
        /// <summary>
        /// The max fixed values
        /// </summary>
        private fixed uint FixedData[MaxFixedValues];
        /// <summary>
        /// The data
        /// </summary>
        public readonly uint[] Data;

        /// <summary>
        /// Gets the i
        /// </summary>
        /// <param name="i">The </param>
        /// <returns>The uint</returns>
        public uint Get(uint i) => Count > MaxFixedValues ? Data[i] : FixedData[i];

        /// <summary>
        /// Initializes a new instance of the <see cref="SmallFixedOrDynamicArray"/> class
        /// </summary>
        /// <param name="count">The count</param>
        /// <param name="data">The data</param>
        public SmallFixedOrDynamicArray(uint count, ref uint data)
        {
            if (count > MaxFixedValues)
            {
                Data = ArrayPool<uint>.Shared.Rent((int)count);
            }
            else
            {
                for (int i = 0; i < count; i++)
                {
                    FixedData[i] = Unsafe.Add(ref data, i);
                }

                Data = null;
            }

            Count = count;
        }

        /// <summary>
        /// Disposes this instance
        /// </summary>
        public void Dispose()
        {
            if (Data != null) { ArrayPool<uint>.Shared.Return(Data); }
        }
    }
}
