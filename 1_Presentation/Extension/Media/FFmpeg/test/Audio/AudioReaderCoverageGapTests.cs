// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:AudioReaderCoverageGapTests.cs
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
using System.Threading.Tasks;
using Alis.Extension.Media.FFmpeg.Audio;
using Xunit;

namespace Alis.Extension.Media.FFmpeg.Test.Audio
{
    /// <summary>
    ///     Coverage gap tests for <see cref="AudioReader" /> metadata loading paths driven by fake ffprobe scripts.
    /// </summary>
    public class AudioReaderCoverageGapTests : IDisposable
    {
        private readonly string _tempFile;

        private const string NoAudioStreamJson = "{\"streams\":[{\"index\":0,\"codec_type\":\"video\",\"codec_name\":\"h264\"}],\"format\":{\"duration\":\"1.000000\"}}";

        private const string EmptyObjectJson = "{}";

        private const string CorruptJson = "not a json payload";

        /// <summary>
        ///     Initializes a new instance of the <see cref="AudioReaderCoverageGapTests" /> class.
        /// </summary>
        public AudioReaderCoverageGapTests()
        {
            _tempFile = Path.GetTempFileName();
        }

        /// <summary>
        ///     Disposes this instance.
        /// </summary>
        public void Dispose()
        {
            if (File.Exists(_tempFile))
            {
                File.Delete(_tempFile);
            }
        }

        /// <summary>
        ///     Creates an executable ffprobe script that prints the given payload.
        /// </summary>
        /// <param name="payload">The payload printed by the script.</param>
        /// <returns>The created script path.</returns>
        private static string CreateFfprobeScript(string payload)
        {
            string scriptPath = Path.GetTempFileName();
            File.WriteAllText(scriptPath, "#!/bin/bash\necho '" + payload + "'");
            File.SetUnixFileMode(
                scriptPath,
                UnixFileMode.UserRead |
                UnixFileMode.UserWrite |
                UnixFileMode.UserExecute |
                UnixFileMode.GroupRead |
                UnixFileMode.GroupExecute |
                UnixFileMode.OtherRead |
                UnixFileMode.OtherExecute);
            return scriptPath;
        }

        /// <summary>
        ///     Tests that LoadMetadataAsync with valid ffprobe output loads metadata successfully.
        /// </summary>
        [Fact]
        public async Task LoadMetadataAsync_WithValidFfprobeOutput_LoadsMetadata()
        {
            string script = CreateFfprobeScript(NoAudioStreamJson);
            try
            {
                using AudioReader reader = new AudioReader(_tempFile, "ffmpeg", script);

                await reader.LoadMetadataAsync();

                Assert.True(reader.MetadataLoaded);
                Assert.NotNull(reader.Metadata);
                Assert.Equal(0, reader.Metadata.Channels);
                Assert.Equal("1.000000", reader.Metadata.Format.Duration);
            }
            finally
            {
                File.Delete(script);
            }
        }

        /// <summary>
        ///     Tests that LoadMetadataAsync with an empty ffprobe object still marks metadata as loaded.
        /// </summary>
        [Fact]
        public async Task LoadMetadataAsync_WithEmptyObjectJson_LoadsMetadata()
        {
            string script = CreateFfprobeScript(EmptyObjectJson);
            try
            {
                using AudioReader reader = new AudioReader(_tempFile, "ffmpeg", script);

                await reader.LoadMetadataAsync();

                Assert.True(reader.MetadataLoaded);
                Assert.NotNull(reader.Metadata);
            }
            finally
            {
                File.Delete(script);
            }
        }

        /// <summary>
        ///     Tests that the synchronous LoadMetadata wrapper loads metadata with valid ffprobe output.
        /// </summary>
        [Fact]
        public void LoadMetadata_WithValidFfprobeOutput_LoadsMetadata()
        {
            string script = CreateFfprobeScript(NoAudioStreamJson);
            try
            {
                using AudioReader reader = new AudioReader(_tempFile, "ffmpeg", script);

                reader.LoadMetadata();

                Assert.True(reader.MetadataLoaded);
                Assert.NotNull(reader.Metadata);
            }
            finally
            {
                File.Delete(script);
            }
        }

        /// <summary>
        ///     Tests that the synchronous LoadMetadata wrapper surfaces corrupt ffprobe output as
        ///     an InvalidOperationException through the AggregateException.
        /// </summary>
        [Fact]
        public void LoadMetadata_WithCorruptFfprobeOutput_ThrowsInvalidOperationException()
        {
            string script = CreateFfprobeScript(CorruptJson);
            try
            {
                using AudioReader reader = new AudioReader(_tempFile, "ffmpeg", script);

                AggregateException ex = Assert.Throws<AggregateException>(() => reader.LoadMetadata());

                Assert.Contains("Failed to interpret ffprobe audio metadata output", ex.InnerException.Message);
                Assert.False(reader.MetadataLoaded);
            }
            finally
            {
                File.Delete(script);
            }
        }

        /// <summary>
        ///     Tests that LoadMetadataAsync throws with the already-loaded message when metadata is loaded twice.
        /// </summary>
        [Fact]
        public async Task LoadMetadataAsync_WhenAlreadyLoaded_ThrowsWithAlreadyLoadedMessage()
        {
            string script = CreateFfprobeScript(NoAudioStreamJson);
            try
            {
                using AudioReader reader = new AudioReader(_tempFile, "ffmpeg", script);
                await reader.LoadMetadataAsync();

                InvalidOperationException ex = await Assert.ThrowsAsync<InvalidOperationException>(() => reader.LoadMetadataAsync());

                Assert.Contains("already loaded", ex.Message);
            }
            finally
            {
                File.Delete(script);
            }
        }
    }
}
