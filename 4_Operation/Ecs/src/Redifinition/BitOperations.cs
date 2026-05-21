

using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace System.Numerics
{
    /// <summary>
    ///     Provides bitwise utility operations for integer types
    /// </summary>
    [ExcludeFromCodeCoverage]
    public static class BitOperations
    {
        /// <summary>
        ///     The log de bruijn
        /// </summary>
        private static readonly byte[] Log2DeBruijn =
        [
            00, 09, 01, 10, 13, 21, 02, 29,
            11, 14, 16, 18, 22, 25, 03, 30,
            08, 12, 20, 28, 15, 17, 24, 07,
            19, 27, 23, 06, 26, 05, 04, 31
        ];


        /// <summary>
        ///     Returns the integer logarithm base 2 of the specified value
        /// </summary>
        /// <param name="value">The unsigned integer to compute the log2 of</param>
        /// <returns>The base-2 logarithm of <paramref name="value" /></returns>
        public static int Log2(uint value)
        {
            value |= value >> 01;
            value |= value >> 02;
            value |= value >> 04;
            value |= value >> 08;
            value |= value >> 16;

            return Unsafe.AddByteOffset(
                ref Log2DeBruijn[0],
                (IntPtr) (int) ((value * 0x07C4ACDDu) >> 27));
        }


        /// <summary>
        ///     Rounds up to the next highest power of two
        /// </summary>
        /// <param name="value">The value to round up</param>
        /// <returns>The smallest power of two greater than or equal to <paramref name="value" /></returns>
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
        public static uint RotateLeft(uint value, int offset) => (value << offset) | (value >> (32 - offset));
    }
}