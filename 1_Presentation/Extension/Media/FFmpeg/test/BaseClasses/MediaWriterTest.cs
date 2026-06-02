// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:MediaWriterTest.cs
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
using Alis.Extension.Media.FFmpeg.BaseClasses;
using Xunit;

namespace Alis.Extension.Media.FFmpeg.Test.BaseClasses
{
    /// <summary>
    ///     The media writer test class
    /// </summary>
    /// <seealso cref="MediaWriter{TFrame}" />
    public class MediaWriterTest
    {
        private sealed class TestFrame : IMediaFrame
        {
            public TestFrame(byte[] rawData)
            {
                RawData = rawData;
            }

            public byte[] RawData { get; }

            public bool Load(Stream stream) => true;
        }

        private sealed class TestWriter : MediaWriter<TestFrame>
        {
            public void SetOpened(bool value) => OpenedForWriting = value;

            public void SetStream(Stream stream) => InputDataStream = stream;
        }

        [Fact]
        public void MediaWriter_WriteFrame_ShouldThrowWhenNotOpened()
        {
            TestWriter writer = new TestWriter();

            Assert.Throws<InvalidOperationException>(() => writer.WriteFrame(new TestFrame(new byte[1])));
        }
    }
}
