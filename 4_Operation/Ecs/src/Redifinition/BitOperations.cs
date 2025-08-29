#if (NETSTANDARD || NETFRAMEWORK || NETCOREAPP) && (!NET6_0_OR_GREATER)

using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// ReSharper disable once CheckNamespace
namespace System.Numerics
{
    public static class BitOperations
    {
        private static readonly byte[] Log2DeBruijn =
        [
            00, 09, 01, 10, 13, 21, 02, 29,
            11, 14, 16, 18, 22, 25, 03, 30,
            08, 12, 20, 28, 15, 17, 24, 07,
            19, 27, 23, 06, 26, 05, 04, 31
        ];

#if (NETSTANDARD || NETFRAMEWORK || NETCOREAPP) && (!NET6_0_OR_GREATER)
        public static int Log2(uint value)
        {
            value |= value >> 01;
            value |= value >> 02;
            value |= value >> 04;
            value |= value >> 08;
            value |= value >> 16;

            // uint.MaxValue >> 27 is always in range [0 - 31] so we use Unsafe.AddByteOffset to avoid bounds check
            return Unsafe.AddByteOffset(
                // Using deBruijn sequence, k=2, n=5 (2^5=32) : 0b_0000_0111_1100_0100_1010_1100_1101_1101u
                ref Log2DeBruijn[0],
                // uint|long -> IntPtr cast on 32-bit platforms does expensive overflow checks not needed here
                (IntPtr)(int)((value * 0x07C4ACDDu) >> 27));
        }
#else
      public static int Log2(uint value)
        {
            value |= value >> 01;
            value |= value >> 02;
            value |= value >> 04;
            value |= value >> 08;
            value |= value >> 16;

            // uint.MaxValue >> 27 is always in range [0 - 31] so we use Unsafe.AddByteOffset to avoid bounds check
            return Unsafe.AddByteOffset(
                // Using deBruijn sequence, k=2, n=5 (2^5=32) : 0b_0000_0111_1100_0100_1010_1100_1101_1101u
                ref MemoryMarshal.GetArrayDataReference(Log2DeBruijn),
                // uint|long -> IntPtr cast on 32-bit platforms does expensive overflow checks not needed here
                (IntPtr)(int)((value * 0x07C4ACDDu) >> 27));
        }
#endif

        /// <summary>
        /// rounds up to the next highest power of 2.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static uint RoundUpToPowerOf2(uint value)
        {
            --value;
            value |= value >> 1;
            value |= value >> 2;
            value |= value >> 4;
            value |= value >> 8;
            value |= value >> 16;
            return value + 1;
        }

        
        /// <summary>Performs a left bitwise rotation on a 32-bit unsigned integer.</summary>
        /// <param name="value">The value to rotate.</param>
        /// <param name="offset">The number of bits to rotate by.</param>
        /// <returns>The result of rotating <paramref name="value" /> left by <paramref name="offset" /> bits.</returns>
        public static uint RotateLeft(uint value, int offset)
        {
            return (value << offset) | (value >> (32 - offset));
        }
    }
}

#endif