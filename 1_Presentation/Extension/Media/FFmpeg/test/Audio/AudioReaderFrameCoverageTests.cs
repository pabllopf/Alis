// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:AudioReaderFrameCoverageTests.cs
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
using System.Reflection;
using Alis.Extension.Media.FFmpeg.Audio;
using Alis.Extension.Media.FFmpeg.Audio.Models;
using Alis.Extension.Media.FFmpeg.Test.Attributes;
using Xunit;

namespace Alis.Extension.Media.FFmpeg.Test.Audio
{
    /// <summary>
    ///     The audio reader frame coverage tests class
    /// </summary>
    /// <seealso cref="IDisposable"/>
    public class AudioReaderFrameCoverageTests : IDisposable
    {
        /// <summary>
        ///     The temp file
        /// </summary>
        private readonly string _tempFile;

        /// <summary>
        ///     The disposed
        /// </summary>
        private bool _disposed;

        /// <summary>
        ///     Initializes a new instance of the <see cref="AudioReaderFrameCoverageTests"/> class
        /// </summary>
        public AudioReaderFrameCoverageTests()
        {
            _tempFile = Path.GetTempFileName();
        }

        /// <summary>
        ///     Disposes this instance
        /// </summary>
        public void Dispose()
        {
            if (!_disposed)
            {
                _disposed = true;
                if (File.Exists(_tempFile))
                {
                    File.Delete(_tempFile);
                }
            }
        }

        /// <summary>
        ///     Tests that NextFrame with an explicit sample count reads data when metadata is set
        /// </summary>
        [RequireFfmpegFact]
        public void NextFrame_WithSamples_WhenMetadataSet_ShouldReturnFrame()
        {
            FrameCoverageAudioReader reader = new FrameCoverageAudioReader(_tempFile);
            try
            {
                SetBackingField(reader, "Metadata", new AudioMetadata { Channels = 2 });
                reader.SetOpenedForReading(true);
                reader.SetDataStream(new MemoryStream(new byte[1024 * 2 * 2]));

                AudioFrame result = reader.NextFrame(1024);

                Assert.NotNull(result);
                Assert.Equal(1024, result.LoadedSamples);
                Assert.Equal(1024, reader.CurrentSampleOffset);
            }
            finally
            {
                reader.Dispose();
            }
        }

        /// <summary>
        ///     Tests that NextFrame with an explicit sample count returns null on an empty stream
        /// </summary>
        [RequireFfmpegFact]
        public void NextFrame_WithSamples_WhenStreamEmpty_ShouldReturnNull()
        {
            FrameCoverageAudioReader reader = new FrameCoverageAudioReader(_tempFile);
            try
            {
                SetBackingField(reader, "Metadata", new AudioMetadata { Channels = 2 });
                reader.SetOpenedForReading(true);
                reader.SetDataStream(new MemoryStream());

                AudioFrame result = reader.NextFrame(1024);

                Assert.Null(result);
                Assert.Equal(0, reader.CurrentSampleOffset);
            }
            finally
            {
                reader.Dispose();
            }
        }

        /// <summary>
        ///     Tests that LoadMetadataAsync throws when ffprobe emits corrupt output
        /// </summary>
        [RequireFfmpegFact]
        public async System.Threading.Tasks.Task LoadMetadataAsync_WithCorruptFfprobe_ShouldThrowInvalidOperation()
        {
            string tempDir = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString());
            Directory.CreateDirectory(tempDir);
            string fakeFfprobe = Path.Combine(tempDir, "ffprobe");
            File.WriteAllText(fakeFfprobe, "#!/bin/bash\necho '{{{ not valid json'");
            using (System.Diagnostics.Process chmod = System.Diagnostics.Process.Start("chmod", $"+x \"{fakeFfprobe}\""))
            {
                chmod.WaitForExit();
            }

            try
            {
                using AudioReader reader = new AudioReader(_tempFile, "ffmpeg", fakeFfprobe);

                InvalidOperationException ex = await Assert.ThrowsAsync<InvalidOperationException>(() => reader.LoadMetadataAsync());
                Assert.Contains("Failed to interpret ffprobe audio metadata output", ex.Message);
            }
            finally
            {
                try { Directory.Delete(tempDir, recursive: true); } catch { }
            }
        }

        /// <summary>
        ///     Sets the backing field using the specified obj
        /// </summary>
        /// <param name="obj">The obj</param>
        /// <param name="propName">The prop name</param>
        /// <param name="value">The value</param>
        private static void SetBackingField(object obj, string propName, object value)
        {
            FieldInfo field = typeof(AudioReader).GetField($"<{propName}>k__BackingField",
                BindingFlags.NonPublic | BindingFlags.Instance);
            field.SetValue(obj, value);
        }
    }

    /// <summary>
    ///     The frame coverage audio reader class
    /// </summary>
    /// <seealso cref="AudioReader"/>
    public class FrameCoverageAudioReader : AudioReader
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="FrameCoverageAudioReader"/> class
        /// </summary>
        /// <param name="filename">The filename</param>
        public FrameCoverageAudioReader(string filename)
            : base(filename)
        {
        }

        /// <summary>
        ///     Sets the opened for reading using the specified value
        /// </summary>
        /// <param name="value">The value</param>
        public void SetOpenedForReading(bool value) => OpenedForReading = value;

        /// <summary>
        ///     Sets the data stream using the specified stream
        /// </summary>
        /// <param name="stream">The stream</param>
        public void SetDataStream(Stream stream) => DataStream = stream;
    }
}
