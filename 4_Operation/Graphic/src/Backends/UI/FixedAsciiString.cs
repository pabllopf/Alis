using System;
using System.Runtime.InteropServices;
using System.Text;

namespace Alis.Core.Graphic.Backends.UI
{
    /// <summary>
    /// The fixed ascii string class
    /// </summary>
    /// <seealso cref="IDisposable"/>
    public class FixedAsciiString : IDisposable
    {
        /// <summary>
        /// Gets the value of the data ptr
        /// </summary>
        public IntPtr DataPtr { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="FixedAsciiString"/> class
        /// </summary>
        /// <param name="s">The </param>
        public unsafe FixedAsciiString(string s)
        {
            int byteCount = Encoding.ASCII.GetByteCount(s);
            DataPtr = Marshal.AllocHGlobal(byteCount + 1);
            fixed (char* sPtr = s)
            {
                int end = Encoding.ASCII.GetBytes(sPtr, s.Length, (byte*)DataPtr, byteCount);
                ((byte*)DataPtr)[end] = 0;
            }
        }

        /// <summary>
        /// Disposes this instance
        /// </summary>
        public void Dispose()
        {
            Marshal.FreeHGlobal(DataPtr);
        }
    }
}
