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

namespace Alis.Extension.Graphic.Sfml.Test.Systems
{
    /// <summary>
    ///     The stream adaptor test class
    /// </summary>
    public class StreamAdaptorTest : IDisposable
    {
        private StreamAdaptor _streamAdaptor;
        private MemoryStream _memoryStream;

        public StreamAdaptorTest()
        {
            _memoryStream = new MemoryStream(new byte[] { 1, 2, 3, 4, 5 });
            _streamAdaptor = new StreamAdaptor(_memoryStream);
        }

        public void Dispose()
        {
            _streamAdaptor?.Dispose();
            _memoryStream?.Dispose();
        }

        /// <summary>
        ///     Tests that StreamAdaptor constructor creates a valid instance
        /// </summary>
        [Fact]
        public void Constructor_ShouldCreateValidInstance()
        {
            Assert.NotNull(_streamAdaptor);
        }

        /// <summary>
        ///     Tests that InputStreamPtr returns a valid pointer
        /// </summary>
        [Fact]
        public void InputStreamPtr_ShouldReturnValidPointer()
        {
            Assert.NotEqual(IntPtr.Zero, _streamAdaptor.InputStreamPtr);
        }

        /// <summary>
        ///     Tests that StreamAdaptor with empty stream works
        /// </summary>
        [Fact]
        public void Constructor_WithEmptyStream_ShouldCreateValidInstance()
        {
            MemoryStream emptyStream = new MemoryStream();
            StreamAdaptor adaptor = new StreamAdaptor(emptyStream);

            Assert.NotNull(adaptor);
            Assert.NotEqual(IntPtr.Zero, adaptor.InputStreamPtr);

            adaptor.Dispose();
        }

        /// <summary>
        ///     Tests that StreamAdaptor with non-empty stream works
        /// </summary>
        [Fact]
        public void Constructor_WithNonEmptyStream_ShouldCreateValidInstance()
        {
            byte[] data = new byte[1024];
            for (int i = 0; i < data.Length; i++)
            {
                data[i] = (byte)(i % 256);
            }

            MemoryStream stream = new MemoryStream(data);
            StreamAdaptor adaptor = new StreamAdaptor(stream);

            Assert.NotNull(adaptor);
            Assert.NotEqual(IntPtr.Zero, adaptor.InputStreamPtr);

            adaptor.Dispose();
        }

        /// <summary>
        ///     Tests that multiple StreamAdaptor instances can be created
        /// </summary>
        [Fact]
        public void MultipleInstances_ShouldWorkIndependently()
        {
            MemoryStream stream1 = new MemoryStream(new byte[] { 1, 2, 3 });
            MemoryStream stream2 = new MemoryStream(new byte[] { 4, 5, 6 });

            StreamAdaptor adaptor1 = new StreamAdaptor(stream1);
            StreamAdaptor adaptor2 = new StreamAdaptor(stream2);

            Assert.NotNull(adaptor1.InputStreamPtr);
            Assert.NotNull(adaptor2.InputStreamPtr);
            Assert.NotEqual(adaptor1.InputStreamPtr, adaptor2.InputStreamPtr);

            adaptor1.Dispose();
            adaptor2.Dispose();
        }
    }
}
