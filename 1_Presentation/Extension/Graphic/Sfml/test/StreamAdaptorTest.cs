// --------------------------------------------------------------------------
//
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
//
//  --------------------------------------------------------------------------
//  File:StreamAdaptorTest.cs
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
using Alis.Extension.Graphic.Sfml.Systems;
using Xunit;

namespace Alis.Extension.Graphic.Sfml.Test
{
    /// <summary>
    ///     Tests for the StreamAdaptor class
    /// </summary>
    public class StreamAdaptorTest : IDisposable
    {
        /// <summary>
        /// The adaptor
        /// </summary>
        private StreamAdaptor? _adaptor;
        /// <summary>
        /// The stream
        /// </summary>
        private MemoryStream? _stream;

        /// <summary>
        ///     Cleans up resources
        /// </summary>
        public void Dispose()
        {
            _adaptor?.Dispose();
            _stream?.Dispose();
        }

        /// <summary>
        /// Creates the test stream using the specified data
        /// </summary>
        /// <param name="data">The data</param>
        /// <returns>The stream</returns>
        private MemoryStream CreateTestStream(byte[] data)
        {
            MemoryStream stream = new MemoryStream(data);
            _stream = stream;
            return stream;
        }

        /// <summary>
        ///     Tests that constructor should create a valid StreamAdaptor with non-null InputStreamPtr
        /// </summary>
        [Fact]
        public void Constructor_ShouldCreateValidAdaptorWithNonNullInputStreamPtr()
        {
            MemoryStream stream = CreateTestStream(new byte[] { 0x01, 0x02, 0x03, 0x04 });
            _adaptor = new StreamAdaptor(stream);

            Assert.NotNull(_adaptor);
            Assert.NotEqual(IntPtr.Zero, _adaptor.InputStreamPtr);
        }

        /// <summary>
        ///     Tests that constructor should not throw with empty stream
        /// </summary>
        [Fact]
        public void Constructor_ShouldNotThrowWithEmptyStream()
        {
            MemoryStream stream = CreateTestStream(Array.Empty<byte>());
            _adaptor = new StreamAdaptor(stream);

            Assert.NotNull(_adaptor);
            Assert.NotEqual(IntPtr.Zero, _adaptor.InputStreamPtr);
        }

        /// <summary>
        ///     Tests that constructor should not throw with large stream
        /// </summary>
        [Fact]
        public void Constructor_ShouldNotThrowWithLargeStream()
        {
            byte[] largeData = new byte[1024 * 1024]; // 1MB
            for (int i = 0; i < largeData.Length; i++)
            {
                largeData[i] = (byte)(i % 256);
            }

            MemoryStream stream = CreateTestStream(largeData);
            _adaptor = new StreamAdaptor(stream);

            Assert.NotNull(_adaptor);
            Assert.NotEqual(IntPtr.Zero, _adaptor.InputStreamPtr);
        }
      
        /// <summary>
        ///     Tests that InputStreamPtr remains valid after successful read operations
        /// </summary>
        [Fact]
        public void InputStreamPtr_ValidAfterConstruction()
        {
            byte[] data = new byte[] { 0x48, 0x65, 0x6C, 0x6C, 0x6F }; // "Hello"
            MemoryStream stream = CreateTestStream(data);
            _adaptor = new StreamAdaptor(stream);

            IntPtr ptr = _adaptor.InputStreamPtr;
            Assert.NotEqual(IntPtr.Zero, ptr);
        }

        /// <summary>
        ///     Tests that StreamAdaptor implements IDisposable correctly
        /// </summary>
        [Fact]
        public void StreamAdaptor_ShouldImplementIDisposable()
        {
            MemoryStream stream = CreateTestStream(new byte[] { 0x01 });
            _adaptor = new StreamAdaptor(stream);

            Assert.IsAssignableFrom<IDisposable>(_adaptor);
        }
    }
}
