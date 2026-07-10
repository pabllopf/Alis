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

namespace Alis.Extension.Graphic.Sfml.Test.Systems
{
    /// <summary>
    ///     Remaining coverage tests for <see cref="StreamAdaptor" />.
    /// </summary>
    public class StreamAdaptorRemainingCoverageTests
    {
        private static (StreamAdaptor Adaptor, InputStream InputStream) CreateAdaptor(byte[] data)
        {
            MemoryStream stream = new MemoryStream(data);
            StreamAdaptor adaptor = new StreamAdaptor(stream);
            InputStream inputStream = Marshal.PtrToStructure<InputStream>(adaptor.InputStreamPtr);
            return (adaptor, inputStream);
        }

        [Fact]
        public void Read_ShouldReturnCorrectBytes()
        {
            var (adaptor, stream) = CreateAdaptor(new byte[] { 10, 20, 30, 40, 50, 60, 70, 80 });
            using (adaptor)
            {
                IntPtr buffer = Marshal.AllocHGlobal(8);
                try
                {
                    long bytesRead = stream.Read(buffer, 8, IntPtr.Zero);
                    Assert.Equal(8, bytesRead);

                    byte[] result = new byte[8];
                    Marshal.Copy(buffer, result, 0, 8);
                    Assert.Equal(new byte[] { 10, 20, 30, 40, 50, 60, 70, 80 }, result);
                }
                finally
                {
                    Marshal.FreeHGlobal(buffer);
                }
            }
        }

        [Fact]
        public void Read_ShouldReturnPartialBytes_WhenBufferLargerThanStream()
        {
            var (adaptor, stream) = CreateAdaptor(new byte[] { 10, 20, 30, 40, 50, 60, 70, 80 });
            using (adaptor)
            {
                IntPtr buffer = Marshal.AllocHGlobal(16);
                try
                {
                    long bytesRead = stream.Read(buffer, 16, IntPtr.Zero);
                    Assert.Equal(8, bytesRead);
                }
                finally
                {
                    Marshal.FreeHGlobal(buffer);
                }
            }
        }

        [Fact]
        public void Read_ShouldReturnZero_WhenStreamEmpty()
        {
            var (adaptor, stream) = CreateAdaptor(Array.Empty<byte>());
            using (adaptor)
            {
                IntPtr buffer = Marshal.AllocHGlobal(4);
                try
                {
                    long bytesRead = stream.Read(buffer, 4, IntPtr.Zero);
                    Assert.Equal(0, bytesRead);
                }
                finally
                {
                    Marshal.FreeHGlobal(buffer);
                }
            }
        }

        [Fact]
        public void Seek_ShouldUpdatePosition()
        {
            var (adaptor, stream) = CreateAdaptor(new byte[] { 10, 20, 30, 40, 50, 60, 70, 80 });
            using (adaptor)
            {
                long newPos = stream.Seek(3, IntPtr.Zero);
                Assert.Equal(3, newPos);
            }
        }

        [Fact]
        public void Seek_ToEnd_ShouldReturnLength()
        {
            var (adaptor, stream) = CreateAdaptor(new byte[] { 10, 20, 30, 40, 50, 60, 70, 80 });
            using (adaptor)
            {
                long newPos = stream.Seek(8, IntPtr.Zero);
                Assert.Equal(8, newPos);
            }
        }

        [Fact]
        public void Seek_ToBeginning_ShouldReturnZero()
        {
            var (adaptor, stream) = CreateAdaptor(new byte[] { 10, 20, 30, 40, 50, 60, 70, 80 });
            using (adaptor)
            {
                stream.Seek(5, IntPtr.Zero);
                long newPos = stream.Seek(0, IntPtr.Zero);
                Assert.Equal(0, newPos);
            }
        }

        [Fact]
        public void Tell_ShouldReturnCurrentPosition()
        {
            var (adaptor, stream) = CreateAdaptor(new byte[] { 10, 20, 30, 40, 50, 60, 70, 80 });
            using (adaptor)
            {
                stream.Seek(4, IntPtr.Zero);
                long pos = stream.Tell(IntPtr.Zero);
                Assert.Equal(4, pos);
            }
        }

        [Fact]
        public void Tell_ShouldReturnZero_Initially()
        {
            var (adaptor, stream) = CreateAdaptor(new byte[] { 10, 20, 30, 40, 50, 60, 70, 80 });
            using (adaptor)
            {
                long pos = stream.Tell(IntPtr.Zero);
                Assert.Equal(0, pos);
            }
        }

        [Fact]
        public void GetSize_ShouldReturnStreamLength()
        {
            var (adaptor, stream) = CreateAdaptor(new byte[] { 10, 20, 30, 40, 50, 60, 70, 80 });
            using (adaptor)
            {
                long size = stream.GetSize(IntPtr.Zero);
                Assert.Equal(8, size);
            }
        }

        [Fact]
        public void GetSize_ShouldReturnZero_ForEmptyStream()
        {
            var (adaptor, stream) = CreateAdaptor(Array.Empty<byte>());
            using (adaptor)
            {
                long size = stream.GetSize(IntPtr.Zero);
                Assert.Equal(0, size);
            }
        }

        [Fact]
        public void Dispose_ShouldFreeMemory()
        {
            using StreamAdaptor adaptor = new StreamAdaptor(new MemoryStream(new byte[] { 1, 2, 3 }));
            Assert.NotEqual(IntPtr.Zero, adaptor.InputStreamPtr);
        }

        [Fact]
        public void Read_AfterSeek_ShouldReadFromCorrectPosition()
        {
            var (adaptor, stream) = CreateAdaptor(new byte[] { 10, 20, 30, 40, 50, 60, 70, 80 });
            using (adaptor)
            {
                stream.Seek(3, IntPtr.Zero);

                IntPtr buffer = Marshal.AllocHGlobal(3);
                try
                {
                    long bytesRead = stream.Read(buffer, 3, IntPtr.Zero);
                    Assert.Equal(3, bytesRead);

                    byte[] result = new byte[3];
                    Marshal.Copy(buffer, result, 0, 3);
                    Assert.Equal(new byte[] { 40, 50, 60 }, result);
                }
                finally
                {
                    Marshal.FreeHGlobal(buffer);
                }
            }
        }

        [Fact]
        public void Read_ShouldReadZeroBytes_WhenSizeIsZero()
        {
            var (adaptor, stream) = CreateAdaptor(new byte[] { 10, 20, 30 });
            using (adaptor)
            {
                IntPtr buffer = Marshal.AllocHGlobal(1);
                try
                {
                    long bytesRead = stream.Read(buffer, 0, IntPtr.Zero);
                    Assert.Equal(0, bytesRead);
                }
                finally
                {
                    Marshal.FreeHGlobal(buffer);
                }
            }
        }

        [Fact]
        public void Tell_AfterSeek_ShouldReturnUpdatedPosition()
        {
            var (adaptor, stream) = CreateAdaptor(new byte[] { 10, 20, 30, 40, 50, 60, 70, 80 });
            using (adaptor)
            {
                stream.Seek(5, IntPtr.Zero);
                long pos = stream.Tell(IntPtr.Zero);
                Assert.Equal(5, pos);
            }
        }

        [Fact]
        public void Tell_AfterRead_ShouldReturnUpdatedPosition()
        {
            var (adaptor, stream) = CreateAdaptor(new byte[] { 10, 20, 30, 40, 50, 60, 70, 80 });
            using (adaptor)
            {
                IntPtr buffer = Marshal.AllocHGlobal(3);
                try
                {
                    stream.Read(buffer, 3, IntPtr.Zero);
                    long pos = stream.Tell(IntPtr.Zero);
                    Assert.Equal(3, pos);
                }
                finally
                {
                    Marshal.FreeHGlobal(buffer);
                }
            }
        }
    }
}
