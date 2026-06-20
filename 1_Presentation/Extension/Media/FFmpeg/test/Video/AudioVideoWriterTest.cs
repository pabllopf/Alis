// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:AudioVideoWriterTest.cs
// 
//  Author:Pablo Perdomo Falcón
//  Web:https://www.pabllopf.dev/
// 
//  Copyright (c) 2021 GNU General Public License v3.0
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
using Alis.Extension.Media.FFmpeg.Audio;
using Alis.Extension.Media.FFmpeg.Encoding;
using Alis.Extension.Media.FFmpeg.Video;
using Xunit;

namespace Alis.Extension.Media.FFmpeg.Video.Test
{
    /// <summary>
    ///     The audio video writer test class
    /// </summary>
    public class AudioVideoWriterTest
    {
        /// <summary>
        ///     Tests that constructor with filename validates video dimensions
        /// </summary>
        [Fact]
        public void AudioVideoWriter_Constructor_WithFilename_ZeroWidth_ShouldThrowInvalidDataException()
        {
            string path = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString() + ".mp4");

            try
            {
                InvalidDataException ex = Assert.Throws<InvalidDataException>(() => new AudioVideoWriter(path, 0, 1080, 30.0, 2, 44100, 16, null, null));

                Assert.Contains("frame dimensions", ex.Message);
            }
            finally
            {
                if (File.Exists(path))
                {
                    File.Delete(path);
                }
            }
        }

        /// <summary>
        ///     Tests that constructor with filename validates negative video height
        /// </summary>
        [Fact]
        public void AudioVideoWriter_Constructor_WithFilename_NegativeHeight_ShouldThrowInvalidDataException()
        {
            string path = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString() + ".mp4");

            try
            {
                InvalidDataException ex = Assert.Throws<InvalidDataException>(() => new AudioVideoWriter(path, 1920, -1080, 30.0, 2, 44100, 16, null, null));

                Assert.Contains("frame dimensions", ex.Message);
            }
            finally
            {
                if (File.Exists(path))
                {
                    File.Delete(path);
                }
            }
        }

        /// <summary>
        ///     Tests that constructor with filename validates video framerate
        /// </summary>
        [Fact]
        public void AudioVideoWriter_Constructor_WithFilename_ZeroFramerate_ShouldThrowInvalidDataException()
        {
            string path = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString() + ".mp4");

            try
            {
                InvalidDataException ex = Assert.Throws<InvalidDataException>(() => new AudioVideoWriter(path, 1920, 1080, 0, 2, 44100, 16, null, null));

                Assert.Contains("framerate", ex.Message);
            }
            finally
            {
                if (File.Exists(path))
                {
                    File.Delete(path);
                }
            }
        }

        /// <summary>
        ///     Tests that constructor with filename validates negative video framerate
        /// </summary>
        [Fact]
        public void AudioVideoWriter_Constructor_WithFilename_NegativeFramerate_ShouldThrowInvalidDataException()
        {
            string path = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString() + ".mp4");

            try
            {
                InvalidDataException ex = Assert.Throws<InvalidDataException>(() => new AudioVideoWriter(path, 1920, 1080, -30.0, 2, 44100, 16, null, null));

                Assert.Contains("framerate", ex.Message);
            }
            finally
            {
                if (File.Exists(path))
                {
                    File.Delete(path);
                }
            }
        }

        /// <summary>
        ///     Tests that constructor with filename validates empty filename
        /// </summary>
        [Fact]
        public void AudioVideoWriter_Constructor_WithFilename_Empty_ShouldThrowArgumentException()
        {
            string path = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString() + ".mp4");

            try
            {
                ArgumentException ex = Assert.Throws<ArgumentException>(() => new AudioVideoWriter(string.Empty, 1920, 1080, 30.0, 2, 44100, 16, null, null));

                Assert.Contains("Filename", ex.Message);
            }
            finally
            {
                if (File.Exists(path))
                {
                    File.Delete(path);
                }
            }
        }

        /// <summary>
        ///     Tests that constructor with filename validates null audio channels
        /// </summary>
        [Fact]
        public void AudioVideoWriter_Constructor_WithFilename_ZeroAudioChannels_ShouldThrowInvalidDataException()
        {
            string path = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString() + ".mp4");

            try
            {
                InvalidDataException ex = Assert.Throws<InvalidDataException>(() => new AudioVideoWriter(path, 1920, 1080, 30.0, 0, 44100, 16, null, null));

                Assert.Contains("Channels/Sample rate", ex.Message);
            }
            finally
            {
                if (File.Exists(path))
                {
                    File.Delete(path);
                }
            }
        }

        /// <summary>
        ///     Tests that constructor with filename validates zero audio sample rate
        /// </summary>
        [Fact]
        public void AudioVideoWriter_Constructor_WithFilename_ZeroAudioSampleRate_ShouldThrowInvalidDataException()
        {
            string path = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString() + ".mp4");

            try
            {
                InvalidDataException ex = Assert.Throws<InvalidDataException>(() => new AudioVideoWriter(path, 1920, 1080, 30.0, 2, 0, 16, null, null));

                Assert.Contains("Channels/Sample rate", ex.Message);
            }
            finally
            {
                if (File.Exists(path))
                {
                    File.Delete(path);
                }
            }
        }

        /// <summary>
        ///     Tests that constructor with filename validates invalid audio bit depth 8
        /// </summary>
        [Fact]
        public void AudioVideoWriter_Constructor_WithFilename_AudioBitDepth8_ShouldThrowInvalidOperationException()
        {
            string path = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString() + ".mp4");

            try
            {
                InvalidOperationException ex = Assert.Throws<InvalidOperationException>(() => new AudioVideoWriter(path, 1920, 1080, 30.0, 2, 44100, 8, null, null));

                Assert.Contains("bit depths", ex.Message);
            }
            finally
            {
                if (File.Exists(path))
                {
                    File.Delete(path);
                }
            }
        }

        /// <summary>
        ///     Tests that constructor with filename validates invalid audio bit depth 64
        /// </summary>
        [Fact]
        public void AudioVideoWriter_Constructor_WithFilename_AudioBitDepth64_ShouldThrowInvalidOperationException()
        {
            string path = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString() + ".mp4");

            try
            {
                InvalidOperationException ex = Assert.Throws<InvalidOperationException>(() => new AudioVideoWriter(path, 1920, 1080, 30.0, 2, 44100, 64, null, null));

                Assert.Contains("bit depths", ex.Message);
            }
            finally
            {
                if (File.Exists(path))
                {
                    File.Delete(path);
                }
            }
        }

        /// <summary>
        ///     Tests that constructor with filename sets properties correctly
        /// </summary>
        [Fact]
        public void AudioVideoWriter_Constructor_WithFilename_ShouldSetProperties()
        {
            string path = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString() + ".mp4");

            try
            {
                using AudioVideoWriter writer = new(path, 1920, 1080, 30.0, 2, 44100, 16, null, null);

                Assert.Equal(path, writer.Filename);
                Assert.True(writer.UseFilename);
                Assert.Equal(1920, writer.VideoWidth);
                Assert.Equal(1080, writer.VideoHeight);
                Assert.Equal(30.0, writer.VideoFramerate);
                Assert.Equal(2, writer.AudioChannels);
                Assert.Equal(44100, writer.AudioSampleRate);
                Assert.Equal(16, writer.AudioBitDepth);
            }
            finally
            {
                if (File.Exists(path))
                {
                    File.Delete(path);
                }
            }
        }

        /// <summary>
        ///     Tests that constructor with stream validates null stream
        /// </summary>
        [Fact]
        public void AudioVideoWriter_Constructor_WithStream_Null_ShouldThrowArgumentNullException()
        {
            ArgumentNullException ex = Assert.Throws<ArgumentNullException>(() => new AudioVideoWriter((Stream)null, 1920, 1080, 30.0, 2, 44100, 16, null, null));

            Assert.Contains("outputStream", ex.Message);
        }

        /// <summary>
        ///     Tests that constructor with stream sets properties correctly
        /// </summary>
        [Fact]
        public void AudioVideoWriter_Constructor_WithStream_ShouldSetProperties()
        {
            using MemoryStream stream = new();

            using AudioVideoWriter writer = new(stream, 1920, 1080, 30.0, 2, 44100, 16, null, null);

            Assert.Null(writer.Filename);
            Assert.False(writer.UseFilename);
            Assert.Equal(1920, writer.VideoWidth);
            Assert.Equal(1080, writer.VideoHeight);
            Assert.Equal(30.0, writer.VideoFramerate);
        }

        /// <summary>
        ///     Tests that Dispose does not throw on fresh instance
        /// </summary>
        [Fact]
        public void AudioVideoWriter_Dispose_ShouldNotThrowOnFreshInstance()
        {
            string path = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString() + ".mp4");

            try
            {
                using AudioVideoWriter writer = new(path, 1920, 1080, 30.0, 2, 44100, 16, null, null);

                bool threw = false;
                try
                {
                    writer.Dispose();
                }
                catch
                {
                    threw = true;
                }

                Assert.False(threw);
            }
            finally
            {
                if (File.Exists(path))
                {
                    File.Delete(path);
                }
            }
        }

        /// <summary>
        ///     Tests that Dispose can be called multiple times without throwing
        /// </summary>
        [Fact]
        public void AudioVideoWriter_MultipleDispose_ShouldNotThrow()
        {
            string path = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString() + ".mp4");

            try
            {
                using AudioVideoWriter writer = new(path, 1920, 1080, 30.0, 2, 44100, 16, null, null);

                bool threw = false;
                try
                {
                    writer.Dispose();
                    writer.Dispose();
                    writer.Dispose();
                }
                catch
                {
                    threw = true;
                }

                Assert.False(threw);
            }
            finally
            {
                if (File.Exists(path))
                {
                    File.Delete(path);
                }
            }
        }

        /// <summary>
        ///     Tests that CloseWrite throws when not opened for writing
        /// </summary>
        [Fact]
        public void AudioVideoWriter_CloseWrite_NotOpened_ShouldThrowInvalidOperationException()
        {
            string path = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString() + ".mp4");

            try
            {
                using AudioVideoWriter writer = new(path, 1920, 1080, 30.0, 2, 44100, 16, null, null);

                InvalidOperationException ex = Assert.Throws<InvalidOperationException>(() => writer.CloseWrite());

                Assert.Contains("not opened", ex.Message);
            }
            finally
            {
                if (File.Exists(path))
                {
                    File.Delete(path);
                }
            }
        }

        /// <summary>
        ///     Tests that CurrentFFmpegProcess is initially null
        /// </summary>
        [Fact]
        public void AudioVideoWriter_CurrentFFmpegProcess_InitialState_ShouldBeNull()
        {
            string path = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString() + ".mp4");

            try
            {
                using AudioVideoWriter writer = new(path, 1920, 1080, 30.0, 2, 44100, 16, null, null);

                Assert.Null(writer.CurrentFFmpegProcess);
            }
            finally
            {
                if (File.Exists(path))
                {
                    File.Delete(path);
                }
            }
        }

        /// <summary>
        ///     Tests that DestinationStream is initially null for filename constructor
        /// </summary>
        [Fact]
        public void AudioVideoWriter_DestinationStream_FilenameConstructor_ShouldBeNull()
        {
            string path = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString() + ".mp4");

            try
            {
                using AudioVideoWriter writer = new(path, 1920, 1080, 30.0, 2, 44100, 16, null, null);

                Assert.Null(writer.DestinationStream);
            }
            finally
            {
                if (File.Exists(path))
                {
                    File.Delete(path);
                }
            }
        }

        /// <summary>
        ///     Tests that DestinationStream is set for stream constructor
        /// </summary>
        [Fact]
        public void AudioVideoWriter_DestinationStream_StreamConstructor_ShouldBeSet()
        {
            using MemoryStream stream = new();

            using AudioVideoWriter writer = new(stream, 1920, 1080, 30.0, 2, 44100, 16, null, null);

            Assert.NotNull(writer.DestinationStream);
        }

        /// <summary>
        ///     Tests that InputDataStreamVideo is initially null
        /// </summary>
        [Fact]
        public void AudioVideoWriter_InputDataStreamVideo_InitialState_ShouldBeNull()
        {
            string path = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString() + ".mp4");

            try
            {
                using AudioVideoWriter writer = new(path, 1920, 1080, 30.0, 2, 44100, 16, null, null);

                Assert.Null(writer.InputDataStreamVideo);
            }
            finally
            {
                if (File.Exists(path))
                {
                    File.Delete(path);
                }
            }
        }

        /// <summary>
        ///     Tests that OutputDataStream is initially null
        /// </summary>
        [Fact]
        public void AudioVideoWriter_OutputDataStream_InitialState_ShouldBeNull()
        {
            string path = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString() + ".mp4");

            try
            {
                using AudioVideoWriter writer = new(path, 1920, 1080, 30.0, 2, 44100, 16, null, null);

                Assert.Null(writer.OutputDataStream);
            }
            finally
            {
                if (File.Exists(path))
                {
                    File.Delete(path);
                }
            }
        }

        /// <summary>
        ///     Tests that constructor with custom ffmpeg executable sets it correctly
        /// </summary>
        [Fact]
        public void AudioVideoWriter_Constructor_CustomFfmpeg_ShouldAcceptPath()
        {
            string path = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString() + ".mp4");

            try
            {
                using AudioVideoWriter writer = new(path, 1920, 1080, 30.0, 2, 44100, 16, null, null, "custom_ffmpeg");

                Assert.NotNull(writer);
            }
            finally
            {
                if (File.Exists(path))
                {
                    File.Delete(path);
                }
            }
        }

        /// <summary>
        ///     Tests that constructor with stream and custom ffmpeg executable sets it correctly
        /// </summary>
        [Fact]
        public void AudioVideoWriter_Constructor_WithStream_CustomFfmpeg_ShouldAcceptPath()
        {
            using MemoryStream stream = new();

            using AudioVideoWriter writer = new(stream, 1920, 1080, 30.0, 2, 44100, 16, null, null, "custom_ffmpeg");

            Assert.NotNull(writer);
        }

        /// <summary>
        ///     Tests that constructor with different video resolutions works correctly
        /// </summary>
        [Fact]
        public void AudioVideoWriter_Constructor_DifferentResolutions_ShouldSetCorrectly()
        {
            string path = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString() + ".mp4");

            try
            {
                using AudioVideoWriter writer = new(path, 1280, 720, 60.0, 1, 48000, 24, null, null);

                Assert.Equal(1280, writer.VideoWidth);
                Assert.Equal(720, writer.VideoHeight);
                Assert.Equal(60.0, writer.VideoFramerate);
                Assert.Equal(1, writer.AudioChannels);
                Assert.Equal(48000, writer.AudioSampleRate);
                Assert.Equal(24, writer.AudioBitDepth);
            }
            finally
            {
                if (File.Exists(path))
                {
                    File.Delete(path);
                }
            }
        }

        /// <summary>
        ///     Tests that constructor with 4K resolution works correctly
        /// </summary>
        [Fact]
        public void AudioVideoWriter_Constructor_4K_ShouldSetCorrectly()
        {
            string path = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString() + ".mp4");

            try
            {
                using AudioVideoWriter writer = new(path, 3840, 2160, 24.0, 6, 96000, 32, null, null);

                Assert.Equal(3840, writer.VideoWidth);
                Assert.Equal(2160, writer.VideoHeight);
                Assert.Equal(24.0, writer.VideoFramerate);
            }
            finally
            {
                if (File.Exists(path))
                {
                    File.Delete(path);
                }
            }
        }

        /// <summary>
        ///     Tests that WriteFrame throws when not opened for writing
        /// </summary>
        [Fact]
        public void AudioVideoWriter_WriteFrame_Audio_NotOpened_ShouldThrowInvalidOperationException()
        {
            string path = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString() + ".mp4");

            try
            {
                using AudioVideoWriter writer = new(path, 1920, 1080, 30.0, 2, 44100, 16, null, null);
                AudioFrame frame = new(2, 1024, 16);

                InvalidOperationException ex = Assert.Throws<InvalidOperationException>(() => writer.WriteFrame(frame));

                Assert.Contains("prepared for writing", ex.Message);
            }
            finally
            {
                if (File.Exists(path))
                {
                    File.Delete(path);
                }
            }
        }

        /// <summary>
        ///     Tests that WriteFrame with video frame throws when not opened for writing
        /// </summary>
        [Fact]
        public void AudioVideoWriter_WriteFrame_Video_NotOpened_ShouldThrowInvalidOperationException()
        {
            string path = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString() + ".mp4");

            try
            {
                using AudioVideoWriter writer = new(path, 1920, 1080, 30.0, 2, 44100, 16, null, null);
                VideoFrame frame = new(1920, 1080);

                InvalidOperationException ex = Assert.Throws<InvalidOperationException>(() => writer.WriteFrame(frame));

                Assert.Contains("prepared for writing", ex.Message);
            }
            finally
            {
                if (File.Exists(path))
                {
                    File.Delete(path);
                }
            }
        }
    }
}
