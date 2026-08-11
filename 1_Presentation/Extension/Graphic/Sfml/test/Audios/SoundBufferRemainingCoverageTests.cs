// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:SoundBufferRemainingCoverageTests.cs
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
using Alis.Extension.Graphic.Sfml.Audios;
using Alis.Extension.Graphic.Sfml.Test.Attributes;
using Alis.Extension.Graphic.Sfml.Windows;
using Xunit;

namespace Alis.Extension.Graphic.Sfml.Test.Audios
{
    /// <summary>
    ///     Remaining coverage tests for the <see cref="SoundBuffer"/> class
    /// </summary>
    public class SoundBufferRemainingCoverageTests
    {
        /// <summary>
        /// The assets dir
        /// </summary>
        private static readonly string AssetsDir;

        /// <summary>
        /// Initializes a new instance of the <see cref="SoundBufferRemainingCoverageTests"/> class
        /// </summary>
        static SoundBufferRemainingCoverageTests()
        {
            string assemblyDir = Path.GetDirectoryName(typeof(SoundBufferRemainingCoverageTests).Assembly.Location);
            AssetsDir = Path.GetFullPath(Path.Combine(assemblyDir, "..", "..", "..", "Assets"));
        }

        /// <summary>
        /// Gets the value of the audio sample path
        /// </summary>
        private static string AudioSamplePath => Path.Combine(AssetsDir, "AudioSample.wav");

        /// <summary>
        /// Tests the file constructor creates a buffer
        /// </summary>
        [RequireCSfmlAudioFact]
        public void File_Constructor_CreatesBuffer()
        {
            using SoundBuffer buffer = new SoundBuffer(AudioSamplePath);
            Assert.NotEqual(IntPtr.Zero, buffer.CPointer);
        }

        /// <summary>
        /// Tests the file constructor throws on invalid path
        /// </summary>
        [RequireCSfmlAudioFact]
        public void File_Constructor_ThrowsOnInvalidPath()
        {
            Assert.Throws<LoadingFailedException>(() => new SoundBuffer("/nonexistent/sound.wav"));
        }

        /// <summary>
        /// Tests the stream constructor creates a buffer
        /// </summary>
        [RequireCSfmlAudioFact]
        public void Stream_Constructor_CreatesBuffer()
        {
            byte[] bytes = File.ReadAllBytes(AudioSamplePath);
            using MemoryStream stream = new MemoryStream(bytes);
            using SoundBuffer buffer = new SoundBuffer(stream);
            Assert.NotEqual(IntPtr.Zero, buffer.CPointer);
        }

        /// <summary>
        /// Tests the stream constructor throws on empty stream
        /// </summary>
        [RequireCSfmlAudioFact]
        public void Stream_Constructor_ThrowsOnEmptyStream()
        {
            using MemoryStream stream = new MemoryStream();
            Assert.Throws<LoadingFailedException>(() => new SoundBuffer(stream));
        }

        /// <summary>
        /// Tests the bytes constructor creates a buffer
        /// </summary>
        [RequireCSfmlAudioFact]
        public void Bytes_Constructor_CreatesBuffer()
        {
            byte[] bytes = File.ReadAllBytes(AudioSamplePath);
            using SoundBuffer buffer = new SoundBuffer(bytes);
            Assert.NotEqual(IntPtr.Zero, buffer.CPointer);
        }

        /// <summary>
        /// Tests the bytes constructor throws on empty bytes
        /// </summary>
        [RequireCSfmlAudioFact]
        public void Bytes_Constructor_ThrowsOnEmptyBytes()
        {
            Assert.Throws<LoadingFailedException>(() => new SoundBuffer(Array.Empty<byte>()));
        }

        /// <summary>
        /// Tests the copy constructor creates a buffer
        /// </summary>
        [RequireCSfmlAudioFact]
        public void Copy_Constructor_CreatesBuffer()
        {
            using SoundBuffer original = new SoundBuffer(AudioSamplePath);
            using SoundBuffer copy = new SoundBuffer(original);
            Assert.NotEqual(IntPtr.Zero, copy.CPointer);
        }

        /// <summary>
        /// Tests the sample rate is greater than zero
        /// </summary>
        [RequireCSfmlAudioFact]
        public void SampleRate_IsGreaterThanZero()
        {
            using SoundBuffer buffer = new SoundBuffer(AudioSamplePath);
            Assert.True(buffer.SampleRate > 0);
        }

        /// <summary>
        /// Tests the channel count is greater than zero
        /// </summary>
        [RequireCSfmlAudioFact]
        public void ChannelCount_IsGreaterThanZero()
        {
            using SoundBuffer buffer = new SoundBuffer(AudioSamplePath);
            Assert.True(buffer.ChannelCount > 0);
        }

        /// <summary>
        /// Tests the duration is positive
        /// </summary>
        [RequireCSfmlAudioFact]
        public void Duration_IsPositive()
        {
            using SoundBuffer buffer = new SoundBuffer(AudioSamplePath);
            Assert.True(buffer.Duration.AsMicroseconds() > 0);
        }

        /// <summary>
        /// Tests the samples array is not empty
        /// </summary>
        [RequireCSfmlAudioFact]
        public void Samples_AreNotEmpty()
        {
            using SoundBuffer buffer = new SoundBuffer(AudioSamplePath);
            Assert.True(buffer.Samples.Length > 0);
        }

        /// <summary>
        /// Tests the save to file returns true
        /// </summary>
        [RequireCSfmlAudioFact]
        public void SaveToFile_ReturnsTrue()
        {
            using SoundBuffer buffer = new SoundBuffer(AudioSamplePath);
            string path = Path.Combine(AppContext.BaseDirectory, "soundbuf_out.wav");
            Assert.True(buffer.SaveToFile(path));
        }

        /// <summary>
        /// Tests the to string returns a formatted description
        /// </summary>
        [RequireCSfmlAudioFact]
        public void ToString_ReturnsFormattedDescription()
        {
            using SoundBuffer buffer = new SoundBuffer(AudioSamplePath);
            Assert.StartsWith("[SoundBuffer]", buffer.ToString());
        }

        /// <summary>
        /// Tests the destroy sets the pointer to zero
        /// </summary>
        [RequireCSfmlAudioFact]
        public void Destroy_SetsPointerToZero()
        {
            SoundBuffer buffer = new SoundBuffer(AudioSamplePath);
            Assert.NotEqual(IntPtr.Zero, buffer.CPointer);
            buffer.Dispose();
            Assert.Equal(IntPtr.Zero, buffer.CPointer);
        }
    }
}
