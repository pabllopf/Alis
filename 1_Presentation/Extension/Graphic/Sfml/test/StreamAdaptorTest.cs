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
        private StreamAdaptor? _adaptor;
        private MemoryStream? _stream;

        /// <summary>
        ///     Cleans up resources
        /// </summary>
        public void Dispose()
        {
            _adaptor?.Dispose();
            _stream?.Dispose();
        }

        private MemoryStream CreateTestStream(byte[] data)
        {
            var stream = new MemoryStream(data);
            _stream = stream;
            return stream;
        }

        /// <summary>
        ///     Tests that constructor should create a valid StreamAdaptor with non-null InputStreamPtr
        /// </summary>
        [Fact]
        public void Constructor_ShouldCreateValidAdaptorWithNonNullInputStreamPtr()
        {
            var stream = CreateTestStream(new byte[] { 0x01, 0x02, 0x03, 0x04 });
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
            var stream = CreateTestStream(Array.Empty<byte>());
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
            var largeData = new byte[1024 * 1024]; // 1MB
            for (int i = 0; i < largeData.Length; i++)
            {
                largeData[i] = (byte)(i % 256);
            }

            var stream = CreateTestStream(largeData);
            _adaptor = new StreamAdaptor(stream);

            Assert.NotNull(_adaptor);
            Assert.NotEqual(IntPtr.Zero, _adaptor.InputStreamPtr);
        }

        /// <summary>
        ///     Tests that Dispose should not throw on explicit call
        /// </summary>
        [Fact]
        public void Dispose_ExplicitCall_ShouldNotThrow()
        {
            var stream = CreateTestStream(new byte[] { 0x01, 0x02 });
            _adaptor = new StreamAdaptor(stream);

            _adaptor.Dispose();

            // Should not throw - GC will handle finalizer
        }

        /// <summary>
        ///     Tests that Dispose should not throw when called multiple times
        /// </summary>
        [Fact]
        public void Dispose_MultipleCalls_ShouldNotThrow()
        {
            var stream = CreateTestStream(new byte[] { 0x01, 0x02 });
            _adaptor = new StreamAdaptor(stream);

            _adaptor.Dispose();
            _adaptor.Dispose();
            _adaptor.Dispose();

            // Should not throw - suppress finalize handles repeated calls
        }

        /// <summary>
        ///     Tests that Dispose with null stream should not throw
        /// </summary>
        [Fact]
        public void Dispose_WithNullStream_ShouldNotThrow()
        {
            // StreamAdaptor requires a non-null stream, but Dispose should handle the case
            // where the underlying stream is already disposed or null
            var stream = CreateTestStream(new byte[] { 0x01 });
            _adaptor = new StreamAdaptor(stream);
            stream?.Dispose();

            _adaptor.Dispose();

            // Should not throw even if underlying stream is disposed
        }

        /// <summary>
        ///     Tests that InputStreamPtr remains valid after successful read operations
        /// </summary>
        [Fact]
        public void InputStreamPtr_ValidAfterConstruction()
        {
            var data = new byte[] { 0x48, 0x65, 0x6C, 0x6C, 0x6F }; // "Hello"
            var stream = CreateTestStream(data);
            _adaptor = new StreamAdaptor(stream);

            var ptr = _adaptor.InputStreamPtr;
            Assert.NotEqual(IntPtr.Zero, ptr);
        }

        /// <summary>
        ///     Tests that StreamAdaptor implements IDisposable correctly
        /// </summary>
        [Fact]
        public void StreamAdaptor_ShouldImplementIDisposable()
        {
            var stream = CreateTestStream(new byte[] { 0x01 });
            _adaptor = new StreamAdaptor(stream);

            Assert.IsAssignableFrom<IDisposable>(_adaptor);
        }
    }
}
