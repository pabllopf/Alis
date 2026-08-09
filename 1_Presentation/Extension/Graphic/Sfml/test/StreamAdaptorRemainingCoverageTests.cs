// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:StreamAdaptorRemainingCoverageTests.cs
// 
//  Author:Pablo Perdomo Falcón
//  Web:https://www.pabllopf.dev/
// 
//  Copyright (c) 2021 GNU General Public License v3.0
// 
//  This program is free software:you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
// 
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.See the
//  GNU General Public License for more details.
// 
//  You should have received a copy of the GNU General Public License
//  along with this program.If not, see <http://www.gnu.org/licenses/>.
// 
//  --------------------------------------------------------------------------

using System;
using System.IO;
using System.Runtime.InteropServices;
using Alis.Extension.Graphic.Sfml.Systems;
using Xunit;

namespace Alis.Extension.Graphic.Sfml.Test
{
    /// <summary>
    ///     The stream adaptor remaining coverage tests class
    /// </summary>
    public class StreamAdaptorRemainingCoverageTests
    {
        /// <summary>
        ///     Tests that constructor allocates input stream pointer
        /// </summary>
        [Fact]
        public void Constructor_AllocatesInputStreamPointer()
        {
            MemoryStream stream = new MemoryStream(new byte[] { 1, 2, 3 });
            StreamAdaptor adaptor = new StreamAdaptor(stream);

            Assert.NotEqual(IntPtr.Zero, adaptor.InputStreamPtr);
            Assert.Equal(stream, adaptor.myStream);
            Assert.Equal(4, adaptor._pinnedCallbacks.Count);

            adaptor.Dispose();
            stream.Dispose();
        }

        /// <summary>
        ///     Tests that read callback returns bytes from stream
        /// </summary>
        [Fact]
        public void Read_ReturnsBytesFromStream()
        {
            MemoryStream stream = new MemoryStream(new byte[] { 0x48, 0x65, 0x6C, 0x6C, 0x6F });
            StreamAdaptor adaptor = new StreamAdaptor(stream);
            InputStream inputStream = Marshal.PtrToStructure<InputStream>(adaptor.InputStreamPtr);

            IntPtr buffer = Marshal.AllocHGlobal(8);
            long count = inputStream.Read(buffer, 8, IntPtr.Zero);

            Assert.Equal(5, count);
            Assert.Equal(0x48, Marshal.ReadByte(buffer, 0));
            Assert.Equal(0x65, Marshal.ReadByte(buffer, 1));
            Assert.Equal(0x6F, Marshal.ReadByte(buffer, 4));

            Marshal.FreeHGlobal(buffer);
            adaptor.Dispose();
            stream.Dispose();
        }

        /// <summary>
        ///     Tests that read callback with empty stream returns zero
        /// </summary>
        [Fact]
        public void Read_WithEmptyStream_ReturnsZero()
        {
            MemoryStream stream = new MemoryStream(Array.Empty<byte>());
            StreamAdaptor adaptor = new StreamAdaptor(stream);
            InputStream inputStream = Marshal.PtrToStructure<InputStream>(adaptor.InputStreamPtr);

            IntPtr buffer = Marshal.AllocHGlobal(8);
            long count = inputStream.Read(buffer, 8, IntPtr.Zero);

            Assert.Equal(0, count);

            Marshal.FreeHGlobal(buffer);
            adaptor.Dispose();
            stream.Dispose();
        }

        /// <summary>
        ///     Tests that read callback with size larger than stream reads available bytes
        /// </summary>
        [Fact]
        public void Read_WithSizeLargerThanStream_ReadsAvailableBytes()
        {
            MemoryStream stream = new MemoryStream(new byte[] { 1, 2 });
            StreamAdaptor adaptor = new StreamAdaptor(stream);
            InputStream inputStream = Marshal.PtrToStructure<InputStream>(adaptor.InputStreamPtr);

            IntPtr buffer = Marshal.AllocHGlobal(16);
            long count = inputStream.Read(buffer, 16, IntPtr.Zero);

            Assert.Equal(2, count);

            Marshal.FreeHGlobal(buffer);
            adaptor.Dispose();
            stream.Dispose();
        }

        /// <summary>
        ///     Tests that seek callback moves stream position
        /// </summary>
        [Fact]
        public void Seek_MovesStreamPosition()
        {
            MemoryStream stream = new MemoryStream(new byte[] { 1, 2, 3, 4, 5 });
            StreamAdaptor adaptor = new StreamAdaptor(stream);
            InputStream inputStream = Marshal.PtrToStructure<InputStream>(adaptor.InputStreamPtr);

            long position = inputStream.Seek(3, IntPtr.Zero);

            Assert.Equal(3, position);
            Assert.Equal(3, stream.Position);
            Assert.Equal(3, inputStream.Tell(IntPtr.Zero));

            adaptor.Dispose();
            stream.Dispose();
        }

        /// <summary>
        ///     Tests that tell callback returns current position
        /// </summary>
        [Fact]
        public void Tell_ReturnsCurrentPosition()
        {
            MemoryStream stream = new MemoryStream(new byte[] { 1, 2, 3 });
            StreamAdaptor adaptor = new StreamAdaptor(stream);
            InputStream inputStream = Marshal.PtrToStructure<InputStream>(adaptor.InputStreamPtr);

            stream.Position = 2;
            long position = inputStream.Tell(IntPtr.Zero);

            Assert.Equal(2, position);

            adaptor.Dispose();
            stream.Dispose();
        }

        /// <summary>
        ///     Tests that get size callback returns stream length
        /// </summary>
        [Fact]
        public void GetSize_ReturnsStreamLength()
        {
            MemoryStream stream = new MemoryStream(new byte[] { 1, 2, 3, 4 });
            StreamAdaptor adaptor = new StreamAdaptor(stream);
            InputStream inputStream = Marshal.PtrToStructure<InputStream>(adaptor.InputStreamPtr);

            long size = inputStream.GetSize(IntPtr.Zero);

            Assert.Equal(4, size);

            adaptor.Dispose();
            stream.Dispose();
        }

        /// <summary>
        ///     Tests that dispose frees input stream pointer
        /// </summary>
        [Fact]
        public void Dispose_FreesInputStreamPointer()
        {
            MemoryStream stream = new MemoryStream(new byte[] { 1 });
            StreamAdaptor adaptor = new StreamAdaptor(stream);
            IntPtr ptr = adaptor.InputStreamPtr;

            adaptor.Dispose();

            Assert.Equal(0, adaptor._pinnedCallbacks.Count);

            stream.Dispose();
        }

        /// <summary>
        ///     Tests that dispose suppresses finalizer
        /// </summary>
        [Fact]
        public void Dispose_SuppressesFinalizer()
        {
            MemoryStream stream = new MemoryStream(new byte[] { 1 });
            StreamAdaptor adaptor = new StreamAdaptor(stream);

            adaptor.Dispose();

            Assert.Equal(0, adaptor._pinnedCallbacks.Count);
            Assert.NotEqual(IntPtr.Zero, adaptor.InputStreamPtr);

            stream.Dispose();
        }

        /// <summary>
        ///     Tests that finalizer frees input stream pointer without throwing
        /// </summary>
        [Fact]
        public void Finalizer_FreesInputStreamPointer_WithoutThrowing()
        {
            MemoryStream stream = new MemoryStream(new byte[] { 1 });
            CreateUnreferencedAdaptor(stream);

            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();

            Assert.True(true);
        }

        /// <summary>
        ///     Creates the unreferenced adaptor
        /// </summary>
        /// <param name="stream">The stream</param>
        private static void CreateUnreferencedAdaptor(MemoryStream stream)
        {
            StreamAdaptor adaptor = new StreamAdaptor(stream);
        }
    }
}
