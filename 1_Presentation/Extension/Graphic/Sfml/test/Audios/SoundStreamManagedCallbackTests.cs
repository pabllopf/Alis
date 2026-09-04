// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:SoundStreamManagedCallbackTests.cs
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
using System.Reflection;
using Alis.Extension.Graphic.Sfml.Audios;
using Alis.Extension.Graphic.Sfml.Systems;
using Alis.Extension.Graphic.Sfml.Test.Attributes;
using Xunit;

namespace Alis.Extension.Graphic.Sfml.Test.Audios
{
    /// <summary>
    ///     Executes the managed callback plumbing of SoundStream without touching the native
    ///     audio thread: the private GetData callback (both fill and EOF branches) and the
    ///     internal Seek forwarding to the OnSeek override.
    /// </summary>
    public class SoundStreamManagedCallbackTests
    {
        /// <summary>
        ///     Executes the private GetData callback when OnGetData returns true and asserts that
        ///     the chunk is filled with the pinned sample buffer and its length.
        /// </summary>
        [RequireCSfmlAudioFact]
        public void GetData_WhenOnGetDataTrue_FillsChunkWithSamples()
        {
            ProbeStream stream = new ProbeStream();
            stream.DataResult = true;

            Chunk chunk = new Chunk();
            bool result = InvokeGetData(stream, ref chunk);

            Assert.True(result);
            Assert.NotEqual(IntPtr.Zero, chunk.samples);
            Assert.Equal(256u, chunk.sampleCount);
        }

        /// <summary>
        ///     Executes the private GetData callback when OnGetData returns false and asserts that
        ///     the chunk stays untouched and the callback reports EOF.
        /// </summary>
        [RequireCSfmlAudioFact]
        public void GetData_WhenOnGetDataFalse_ReturnsFalse()
        {
            ProbeStream stream = new ProbeStream();
            stream.DataResult = false;

            Chunk chunk = new Chunk();
            bool result = InvokeGetData(stream, ref chunk);

            Assert.False(result);
            Assert.Equal((uint) 0, chunk.sampleCount);
        }

        /// <summary>
        ///     Executes the internal Seek callback and asserts that it forwards to the OnSeek override.
        /// </summary>
        [RequireCSfmlAudioFact]
        public void Seek_ForwardsToOnSeek()
        {
            ProbeStream stream = new ProbeStream();

            stream.Seek(SfmlTime.FromMilliseconds(125), IntPtr.Zero);

            Assert.True(stream.SeekCalled);
        }

        /// <summary>
        ///     Invokes the private GetData callback through reflection and returns the reported branch.
        /// </summary>
        /// <param name="stream">The stream holding the myTempBuffer</param>
        /// <param name="chunk">The chunk filled by the callback</param>
        /// <returns>The bool</returns>
        private static bool InvokeGetData(ProbeStream stream, ref Chunk chunk)
        {
            MethodInfo method = typeof(SoundStream).GetMethod("GetData", BindingFlags.Instance | BindingFlags.NonPublic);
            Assert.NotNull(method);

            object[] arguments = new object[] { chunk, IntPtr.Zero };
            object result = method.Invoke(stream, arguments);
            chunk = (Chunk) arguments[0];
            return (bool) result;
        }

        /// <summary>
        ///     The probe stream
        /// </summary>
        /// <seealso cref="SoundStream"/>
        private class ProbeStream : SoundStream
        {
            /// <summary>
            ///     Gets or sets a value indicating whether the data result
            /// </summary>
            public bool DataResult { get; set; } = true;

            /// <summary>
            ///     Gets or sets a value indicating whether the seek called
            /// </summary>
            public bool SeekCalled { get; set; }

            /// <summary>
            ///     Ons the get data using the specified samples
            /// </summary>
            /// <param name="samples">The samples</param>
            /// <returns>The bool</returns>
            public override bool OnGetData(out short[] samples)
            {
                samples = DataResult ? new short[256] : System.Array.Empty<short>();
                return DataResult;
            }

            /// <summary>
            ///     Ons the seek using the specified sfml time offset
            /// </summary>
            /// <param name="sfmlTimeOffset">The sfml time offset</param>
            public override void OnSeek(SfmlTime sfmlTimeOffset)
            {
                SeekCalled = true;
            }
        }
    }
}