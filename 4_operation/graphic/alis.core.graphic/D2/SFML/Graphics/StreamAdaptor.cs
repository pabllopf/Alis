// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:   StreamAdaptor.cs
// 
//  Author: Pablo Perdomo Falcón
//  Web:    https://www.pabllopf.dev/
// 
//  Copyright (c) 2021 GNU General Public License v3.0
// 
//  This program is free software: you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
// 
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//  GNU General Public License for more details.
// 
//  You should have received a copy of the GNU General Public License
//  along with this program.  If not, see <http://www.gnu.org/licenses/>.
// 
//  --------------------------------------------------------------------------

using System;
using System.IO;
using System.Runtime.InteropServices;

namespace Alis.Core.Graphic.D2.SFML.Graphics
{
    ////////////////////////////////////////////////////////////
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

    ////////////////////////////////////////////////////////////
    /// <summary>
    ///     Adapts a System.IO.Stream to be usable as a SFML InputStream
    /// </summary>
    ////////////////////////////////////////////////////////////
    public class StreamAdaptor : IDisposable
    {
        /// <summary>
        ///     The my input stream
        /// </summary>
        private readonly InputStream myInputStream;

        /// <summary>
        ///     The my input stream ptr
        /// </summary>
        private readonly IntPtr myInputStreamPtr;

        /// <summary>
        ///     The my stream
        /// </summary>
        private readonly Stream myStream;

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Construct from a System.IO.Stream
        /// </summary>
        /// <param name="stream">Stream to adapt</param>
        ////////////////////////////////////////////////////////////
        public StreamAdaptor(Stream stream)
        {
            myStream = stream;

            myInputStream = new InputStream
            {
                Read = Read,
                Seek = Seek,
                Tell = Tell,
                GetSize = GetSize
            };

            myInputStreamPtr = Marshal.AllocHGlobal(Marshal.SizeOf(myInputStream));
            Marshal.StructureToPtr(myInputStream, myInputStreamPtr, false);
        }

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     The pointer to the CSFML InputStream structure
        /// </summary>
        ////////////////////////////////////////////////////////////
        public IntPtr InputStreamPtr => myInputStreamPtr;

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Explicitly dispose the object
        /// </summary>
        ////////////////////////////////////////////////////////////
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Dispose the object
        /// </summary>
        ////////////////////////////////////////////////////////////
        ~StreamAdaptor()
        {
            Dispose(false);
        }

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Destroy the object
        /// </summary>
        /// <param name="disposing">Is the GC disposing the object, or is it an explicit call ?</param>
        ////////////////////////////////////////////////////////////
        private void Dispose(bool disposing)
        {
            Marshal.FreeHGlobal(myInputStreamPtr);
        }

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Called to read from the stream
        /// </summary>
        /// <param name="data">Where to copy the read bytes</param>
        /// <param name="size">Size to read, in bytes</param>
        /// <param name="userData">User data -- unused</param>
        /// <returns>Number of bytes read</returns>
        ////////////////////////////////////////////////////////////
        private long Read(IntPtr data, long size, IntPtr userData)
        {
            byte[] buffer = new byte[size];
            int count = myStream.Read(buffer, 0, (int) size);
            Marshal.Copy(buffer, 0, data, count);
            return count;
        }

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Called to set the read position in the stream
        /// </summary>
        /// <param name="position">New read position</param>
        /// <param name="userData">User data -- unused</param>
        /// <returns>Actual position</returns>
        ////////////////////////////////////////////////////////////
        private long Seek(long position, IntPtr userData)
        {
            return myStream.Seek(position, SeekOrigin.Begin);
        }

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Get the current read position in the stream
        /// </summary>
        /// <param name="userData">User data -- unused</param>
        /// <returns>Current position in the stream</returns>
        ////////////////////////////////////////////////////////////
        private long Tell(IntPtr userData)
        {
            return myStream.Position;
        }

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Called to get the total size of the stream
        /// </summary>
        /// <param name="userData">User data -- unused</param>
        /// <returns>Number of bytes in the stream</returns>
        ////////////////////////////////////////////////////////////
        private long GetSize(IntPtr userData)
        {
            return myStream.Length;
        }
    }
}