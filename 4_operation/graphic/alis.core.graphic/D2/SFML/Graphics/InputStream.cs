using System;
using System.Runtime.InteropServices;

namespace Alis.Core.Graphic.D2.SFML.Graphics
{
    /// <summary>
    ///     Structure that contains InputStream callbacks
    ///     (directly maps to a CSFML sfInputStream)
    /// </summary>
    ////////////////////////////////////////////////////////////
    [StructLayout(LayoutKind.Sequential)]
    public struct InputStream
    {
        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Type of callback to read data from the current stream
        /// </summary>
        ////////////////////////////////////////////////////////////
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate long ReadCallbackType(IntPtr data, long size, IntPtr userData);

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Type of callback to seek the current stream's position
        /// </summary>
        ////////////////////////////////////////////////////////////
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate long SeekCallbackType(long position, IntPtr userData);

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Type of callback to return the current stream's position
        /// </summary>
        ////////////////////////////////////////////////////////////
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate long TellCallbackType(IntPtr userData);

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Type of callback to return the current stream's size
        /// </summary>
        ////////////////////////////////////////////////////////////
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate long GetSizeCallbackType(IntPtr userData);

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Function that is called to read data from the stream
        /// </summary>
        ////////////////////////////////////////////////////////////
        public ReadCallbackType Read;

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Function that is called to seek the stream
        /// </summary>
        ////////////////////////////////////////////////////////////
        public SeekCallbackType Seek;

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Function that is called to return the positon
        /// </summary>
        ////////////////////////////////////////////////////////////
        public TellCallbackType Tell;

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Function that is called to return the size
        /// </summary>
        ////////////////////////////////////////////////////////////
        public GetSizeCallbackType GetSize;
    }
}