using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Text;

namespace Veldrid.Vk
{
    /// <summary>
    /// The fixed utf string class
    /// </summary>
    /// <seealso cref="IDisposable"/>
    internal unsafe class FixedUtf8String : IDisposable
    {
        /// <summary>
        /// The handle
        /// </summary>
        private GCHandle _handle;
        /// <summary>
        /// The num bytes
        /// </summary>
        private uint _numBytes;

        /// <summary>
        /// Gets the value of the string ptr
        /// </summary>
        public byte* StringPtr => (byte*)_handle.AddrOfPinnedObject().ToPointer();

        /// <summary>
        /// Initializes a new instance of the <see cref="FixedUtf8String"/> class
        /// </summary>
        /// <param name="s">The </param>
        /// <exception cref="ArgumentNullException"></exception>
        public FixedUtf8String(string s)
        {
            if (s == null)
            {
                throw new ArgumentNullException(nameof(s));
            }

            int byteCount = Encoding.UTF8.GetByteCount(s);
            byte[] text = new byte[byteCount + 1];
            _handle = GCHandle.Alloc(text, GCHandleType.Pinned);
            _numBytes = (uint)text.Length - 1; // Includes null terminator
            int encodedCount = Encoding.UTF8.GetBytes(s, 0, s.Length, text, 0);
            Debug.Assert(encodedCount == byteCount);
        }

        /// <summary>
        /// Gets the string
        /// </summary>
        /// <returns>The string</returns>
        private string GetString()
        {
            return Encoding.UTF8.GetString(StringPtr, (int)_numBytes);
        }

        /// <summary>
        /// Disposes this instance
        /// </summary>
        public void Dispose()
        {
            _handle.Free();
        }

        /// <summary>
        /// Returns the string
        /// </summary>
        /// <returns>The string</returns>
        public override string ToString() => GetString();

        public static implicit operator byte* (FixedUtf8String utf8String) => utf8String.StringPtr;
        public static implicit operator IntPtr(FixedUtf8String utf8String) => new IntPtr(utf8String.StringPtr);
        public static implicit operator FixedUtf8String(string s) => new FixedUtf8String(s);
        public static implicit operator string(FixedUtf8String utf8String) => utf8String.GetString();
    }
}
