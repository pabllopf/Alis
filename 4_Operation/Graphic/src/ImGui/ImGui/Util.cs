using System;
using System.Runtime.InteropServices;
using System.Text;

namespace Alis.Core.Graphic.ImGui.ImGui
{
    /// <summary>
    /// The util class
    /// </summary>
    internal static unsafe class Util
    {
        /// <summary>
        /// The stack allocation size limit
        /// </summary>
        internal const int StackAllocationSizeLimit = 2048;

        /// <summary>
        /// Strings the from ptr using the specified ptr
        /// </summary>
        /// <param name="ptr">The ptr</param>
        /// <returns>The string</returns>
        public static string StringFromPtr(byte* ptr)
        {
            int characters = 0;
            while (ptr[characters] != 0)
            {
                characters++;
            }

            return Encoding.UTF8.GetString(ptr, characters);
        }

        /// <summary>
        /// Describes whether are strings equal
        /// </summary>
        /// <param name="a">The </param>
        /// <param name="aLength">The length</param>
        /// <param name="b">The </param>
        /// <returns>The bool</returns>
        internal static bool AreStringsEqual(byte* a, int aLength, byte* b)
        {
            for (int i = 0; i < aLength; i++)
            {
                if (a[i] != b[i]) { return false; }
            }

            if (b[aLength] != 0) { return false; }

            return true;
        }

        /// <summary>
        /// Allocates the byte count
        /// </summary>
        /// <param name="byteCount">The byte count</param>
        /// <returns>The byte</returns>
        internal static byte* Allocate(int byteCount) => (byte*)Marshal.AllocHGlobal(byteCount);

        /// <summary>
        /// Frees the ptr
        /// </summary>
        /// <param name="ptr">The ptr</param>
        internal static void Free(byte* ptr) => Marshal.FreeHGlobal((IntPtr)ptr);

        /// <summary>
        /// Calcs the size in utf 8 using the specified s
        /// </summary>
        /// <param name="s">The </param>
        /// <param name="start">The start</param>
        /// <param name="length">The length</param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        /// <returns>The int</returns>
        internal static int CalcSizeInUtf8(string s, int start, int length)
        {
            if (start < 0 || length < 0 || start + length > s.Length)
            {
                throw new ArgumentOutOfRangeException();
            }

            fixed (char* utf16Ptr = s)
            {
                return Encoding.UTF8.GetByteCount(utf16Ptr + start, length);
            }
        }

        /// <summary>
        /// Gets the utf 8 using the specified s
        /// </summary>
        /// <param name="s">The </param>
        /// <param name="utf8Bytes">The utf bytes</param>
        /// <param name="utf8ByteCount">The utf byte count</param>
        /// <returns>The int</returns>
        internal static int GetUtf8(string s, byte* utf8Bytes, int utf8ByteCount)
        {
            fixed (char* utf16Ptr = s)
            {
                return Encoding.UTF8.GetBytes(utf16Ptr, s.Length, utf8Bytes, utf8ByteCount);
            }
        }

        /// <summary>
        /// Gets the utf 8 using the specified s
        /// </summary>
        /// <param name="s">The </param>
        /// <param name="start">The start</param>
        /// <param name="length">The length</param>
        /// <param name="utf8Bytes">The utf bytes</param>
        /// <param name="utf8ByteCount">The utf byte count</param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        /// <returns>The int</returns>
        internal static int GetUtf8(string s, int start, int length, byte* utf8Bytes, int utf8ByteCount)
        {
            if (start < 0 || length < 0 || start + length > s.Length)
            {
                throw new ArgumentOutOfRangeException();
            }

            fixed (char* utf16Ptr = s)
            {
                return Encoding.UTF8.GetBytes(utf16Ptr + start, length, utf8Bytes, utf8ByteCount);
            }
        }
    }
}
