// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:VideoWriterTests.cs
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
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Threading;
using Alis.Extension.Media.FFmpeg.Encoding;
using Alis.Extension.Media.FFmpeg.Encoding.Builders;
using Alis.Extension.Media.FFmpeg.Video;
using Xunit;

namespace Alis.Extension.Media.FFmpeg.Test.Video
{
    public class VideoWriterTests : IDisposable
    {
        private readonly string _tempDir;
        private readonly string _fakeFfmpegPath;
        private bool _disposed;

        public VideoWriterTests()
        {
            _tempDir = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString());
            Directory.CreateDirectory(_tempDir);
            _fakeFfmpegPath = Path.Combine(_tempDir, "ffmpeg");
            File.WriteAllText(_fakeFfmpegPath,
                "#!/bin/bash\ncat > /dev/null 2>/dev/null");
            using Process chmod = Process.Start("chmod", $"+x \"{_fakeFfmpegPath}\"");
            chmod.WaitForExit();
        }

        public void Dispose()
        {
            if (!_disposed)
            {
                _disposed = true;
                if (Directory.Exists(_tempDir))
                {
                    try { Directory.Delete(_tempDir, recursive: true); } catch { }
                }
            }
        }
        [Fact]
        public void FileCtor_NullFilename_ThrowsArgumentNullException()
        {
            ArgumentNullException ex = Assert.Throws<ArgumentNullException>(
                () => new VideoWriter((string)null, 1920, 1080, 30));
            Assert.Contains("Filename can't be null or empty!", ex.Message);
        }

        [Fact]
        public void FileCtor_EmptyFilename_ThrowsArgumentNullException()
        {
            ArgumentNullException ex = Assert.Throws<ArgumentNullException>(
                () => new VideoWriter("", 1920, 1080, 30));
            Assert.Contains("Filename can't be null or empty!", ex.Message);
        }

        [Fact]
        public void FileCtor_ZeroWidth_ThrowsInvalidDataException()
        {
            InvalidDataException ex = Assert.Throws<InvalidDataException>(
                () => new VideoWriter("out.mp4", 0, 1080, 30));
            Assert.Contains("dimensions have to be bigger than 0", ex.Message);
        }

        [Fact]
        public void FileCtor_NegativeWidth_ThrowsInvalidDataException()
        {
            InvalidDataException ex = Assert.Throws<InvalidDataException>(
                () => new VideoWriter("out.mp4", -1, 1080, 30));
            Assert.Contains("dimensions have to be bigger than 0", ex.Message);
        }

        [Fact]
        public void FileCtor_ZeroHeight_ThrowsInvalidDataException()
        {
            InvalidDataException ex = Assert.Throws<InvalidDataException>(
                () => new VideoWriter("out.mp4", 1920, 0, 30));
            Assert.Contains("dimensions have to be bigger than 0", ex.Message);
        }

        [Fact]
        public void FileCtor_NegativeHeight_ThrowsInvalidDataException()
        {
            InvalidDataException ex = Assert.Throws<InvalidDataException>(
                () => new VideoWriter("out.mp4", 1920, -1, 30));
            Assert.Contains("dimensions have to be bigger than 0", ex.Message);
        }

        [Fact]
        public void FileCtor_ZeroFramerate_ThrowsInvalidDataException()
        {
            InvalidDataException ex = Assert.Throws<InvalidDataException>(
                () => new VideoWriter("out.mp4", 1920, 1080, 0));
            Assert.Contains("framerate has to be bigger than 0", ex.Message);
        }

        [Fact]
        public void FileCtor_NegativeFramerate_ThrowsInvalidDataException()
        {
            InvalidDataException ex = Assert.Throws<InvalidDataException>(
                () => new VideoWriter("out.mp4", 1920, 1080, -1));
            Assert.Contains("framerate has to be bigger than 0", ex.Message);
        }

        [Fact]
        public void FileCtor_ValidParams_SetsPropertiesCorrectly()
        {
            EncoderOptions customOptions = new EncoderOptions
            {
                Format = "matroska",
                EncoderName = "libx265",
                EncoderArguments = "-preset fast"
            };
            using VideoWriter writer = new VideoWriter("output.mp4", 640, 480, 29.97, customOptions, "my-ffmpeg");

            Assert.Equal("output.mp4", writer.Filename);
            Assert.True(writer.UseFilename);
            Assert.Equal(640, writer.Width);
            Assert.Equal(480, writer.Height);
            Assert.Equal(29.97, writer.Framerate);
            Assert.Equal(customOptions, writer.EncoderOptions);
            Assert.Null(writer.DestinationStream);
            Assert.Null(writer.OutputDataStream);
            Assert.Null(writer.CurrentFFmpegProcess);
        }

        [Fact]
        public void FileCtor_DefaultEncoderOptions_CreatesH264Encoder()
        {
            using VideoWriter writer = new VideoWriter("out.mp4", 1920, 1080, 30);
            Assert.NotNull(writer.EncoderOptions);
            Assert.Equal("mp4", writer.EncoderOptions.Format);
            Assert.Equal("libx264", writer.EncoderOptions.EncoderName);
        }

        [Fact]
        public void FileCtor_PrivateFfmpegField_StoresExecutable()
        {
            VideoWriter writer = new VideoWriter("out.mp4", 640, 480, 30, null, "/custom/path/ffmpeg");
            FieldInfo field = typeof(VideoWriter).GetField("ffmpeg", BindingFlags.NonPublic | BindingFlags.Instance);
            Assert.Equal("/custom/path/ffmpeg", field.GetValue(writer));
            writer.Dispose();
        }

        [Fact]
        public void StreamCtor_NullStream_ThrowsArgumentNullException()
        {
            ArgumentNullException ex = Assert.Throws<ArgumentNullException>(
                () => new VideoWriter((Stream)null, 1920, 1080, 30));
            Assert.Contains("Stream can't be null!", ex.Message);
        }

        [Fact]
        public void StreamCtor_ZeroWidth_ThrowsInvalidDataException()
        {
            using MemoryStream ms = new MemoryStream();
            Assert.Throws<InvalidDataException>(() => new VideoWriter(ms, 0, 1080, 30));
        }

        [Fact]
        public void StreamCtor_NegativeWidth_ThrowsInvalidDataException()
        {
            using MemoryStream ms = new MemoryStream();
            Assert.Throws<InvalidDataException>(() => new VideoWriter(ms, -1, 1080, 30));
        }

        [Fact]
        public void StreamCtor_ZeroHeight_ThrowsInvalidDataException()
        {
            using MemoryStream ms = new MemoryStream();
            Assert.Throws<InvalidDataException>(() => new VideoWriter(ms, 1920, 0, 30));
        }

        [Fact]
        public void StreamCtor_NegativeHeight_ThrowsInvalidDataException()
        {
            using MemoryStream ms = new MemoryStream();
            Assert.Throws<InvalidDataException>(() => new VideoWriter(ms, 1920, -1, 30));
        }

        [Fact]
        public void StreamCtor_ZeroFramerate_ThrowsInvalidDataException()
        {
            using MemoryStream ms = new MemoryStream();
            Assert.Throws<InvalidDataException>(() => new VideoWriter(ms, 1920, 1080, 0));
        }

        [Fact]
        public void StreamCtor_NegativeFramerate_ThrowsInvalidDataException()
        {
            using MemoryStream ms = new MemoryStream();
            Assert.Throws<InvalidDataException>(() => new VideoWriter(ms, 1920, 1080, -1));
        }

        [Fact]
        public void StreamCtor_ValidParams_SetsPropertiesCorrectly()
        {
            using MemoryStream ms = new MemoryStream();
            EncoderOptions customOptions = new EncoderOptions
            {
                Format = "flv",
                EncoderName = "libx264",
                EncoderArguments = "-crf 23"
            };
            using VideoWriter writer = new VideoWriter(ms, 1280, 720, 60, customOptions, "stream-ffmpeg");

            Assert.False(writer.UseFilename);
            Assert.Null(writer.Filename);
            Assert.Equal(1280, writer.Width);
            Assert.Equal(720, writer.Height);
            Assert.Equal(60, writer.Framerate);
            Assert.Equal(customOptions, writer.EncoderOptions);
            Assert.Equal(ms, writer.DestinationStream);
            Assert.Null(writer.OutputDataStream);
            Assert.Null(writer.CurrentFFmpegProcess);
        }

        [Fact]
        public void StreamCtor_DefaultEncoderOptions_CreatesH264Encoder()
        {
            using MemoryStream ms = new MemoryStream();
            using VideoWriter writer = new VideoWriter(ms, 1920, 1080, 30);
            Assert.NotNull(writer.EncoderOptions);
            Assert.Equal("mp4", writer.EncoderOptions.Format);
            Assert.Equal("libx264", writer.EncoderOptions.EncoderName);
        }

        [Fact]
        public void StreamCtor_PrivateFfmpegField_StoresExecutable()
        {
            using MemoryStream ms = new MemoryStream();
            VideoWriter writer = new VideoWriter(ms, 640, 480, 30, null, "custom-ff");
            FieldInfo field = typeof(VideoWriter).GetField("ffmpeg", BindingFlags.NonPublic | BindingFlags.Instance);
            Assert.Equal("custom-ff", field.GetValue(writer));
            writer.Dispose();
        }

        [Fact]
        public void Dispose_PublicMethod_CompletesWithoutException()
        {
            VideoWriter writer = new VideoWriter("out.mp4", 640, 480, 30);
            Exception ex = Record.Exception(() => writer.Dispose());
            Assert.Null(ex);
        }

        [Fact]
        public void Dispose_WithDisposingFalse_DoesNotReleaseManagedResources()
        {
            using MemoryStream dest = new MemoryStream();
            VideoWriter writer = new VideoWriter(dest, 640, 480, 30);
            MethodInfo disposeMethod = typeof(VideoWriter).GetMethod("Dispose",
                BindingFlags.NonPublic | BindingFlags.Instance);

            Exception ex = Record.Exception(() =>
                disposeMethod.Invoke(writer, new object[] { false }));
            Assert.Null(ex);

            Assert.True(dest.CanWrite);
            writer.Dispose();
        }

        [Fact]
        public void Dispose_WithDisposingTrueAndOpenedForWriting_CallsCloseWrite()
        {
            VideoWriter writer = new VideoWriter("out.mp4", 640, 480, 30);
            PropertyInfo openedProp = typeof(VideoWriter).GetProperty("OpenedForWriting",
                BindingFlags.Public | BindingFlags.Instance);
            openedProp.GetSetMethod(nonPublic: true).Invoke(writer, new object[] { true });
            PropertyInfo inputStreamProp = typeof(VideoWriter).GetProperty("InputDataStream",
                BindingFlags.Public | BindingFlags.Instance);
            inputStreamProp.GetSetMethod(nonPublic: true).Invoke(writer, new object[] { new MemoryStream() });

            ProcessStartInfo psi = new ProcessStartInfo
            {
                FileName = "/bin/echo",
                Arguments = "test",
                UseShellExecute = false,
                RedirectStandardOutput = true,
                CreateNoWindow = true
            };
            Process process = Process.Start(psi);
            process.WaitForExit(1000);
            FieldInfo ffmpegpField = typeof(VideoWriter).GetField("Ffmpegp",
                BindingFlags.NonPublic | BindingFlags.Instance);
            ffmpegpField.SetValue(writer, process);

            MethodInfo disposeMethod = typeof(VideoWriter).GetMethod("Dispose",
                BindingFlags.NonPublic | BindingFlags.Instance);
            disposeMethod.Invoke(writer, new object[] { true });

            Assert.False(writer.OpenedForWriting);
            writer.Dispose();
        }

        [Fact]
        public void Dispose_WithDisposingTrue_DisposesDestinationStream()
        {
            MemoryStream dest = new MemoryStream();
            VideoWriter writer = new VideoWriter(dest, 640, 480, 30);
            MethodInfo disposeMethod = typeof(VideoWriter).GetMethod("Dispose",
                BindingFlags.NonPublic | BindingFlags.Instance);
            disposeMethod.Invoke(writer, new object[] { true });
            Assert.Throws<ObjectDisposedException>(() => dest.WriteByte(0));
        }

        [Fact]
        public void Dispose_WithDisposingTrue_DisposesCancellationTokenSource()
        {
            VideoWriter writer = new VideoWriter(new MemoryStream(), 640, 480, 30);
            CancellationTokenSource csc = new CancellationTokenSource();
            FieldInfo cscField = typeof(VideoWriter).GetField("csc",
                BindingFlags.NonPublic | BindingFlags.Instance);
            cscField.SetValue(writer, csc);
            MethodInfo disposeMethod = typeof(VideoWriter).GetMethod("Dispose",
                BindingFlags.NonPublic | BindingFlags.Instance);
            disposeMethod.Invoke(writer, new object[] { true });
            Assert.Throws<ObjectDisposedException>(() => csc.Token.Register(() => { }));
            writer.Dispose();
        }

        [Fact]
        public void Dispose_WithDisposingTrueAndNullCsc_DoesNotThrow()
        {
            VideoWriter writer = new VideoWriter("out.mp4", 640, 480, 30);
            MethodInfo disposeMethod = typeof(VideoWriter).GetMethod("Dispose",
                BindingFlags.NonPublic | BindingFlags.Instance);
            Exception ex = Record.Exception(() =>
                disposeMethod.Invoke(writer, new object[] { true }));
            Assert.Null(ex);
            writer.Dispose();
        }

        [Fact]
        public void Dispose_WithDisposingTrueAndNullDestinationStream_DoesNotThrow()
        {
            VideoWriter writer = new VideoWriter("out.mp4", 640, 480, 30);
            MethodInfo disposeMethod = typeof(VideoWriter).GetMethod("Dispose",
                BindingFlags.NonPublic | BindingFlags.Instance);
            Exception ex = Record.Exception(() =>
                disposeMethod.Invoke(writer, new object[] { true }));
            Assert.Null(ex);
            writer.Dispose();
        }

        [Fact]
        public void OpenWrite_AlreadyOpened_ThrowsInvalidOperationException()
        {
            VideoWriter writer = new VideoWriter("out.mp4", 640, 480, 30);
            PropertyInfo openedProp = typeof(VideoWriter).GetProperty("OpenedForWriting",
                BindingFlags.Public | BindingFlags.Instance);
            openedProp.GetSetMethod(nonPublic: true).Invoke(writer, new object[] { true });

            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(() => writer.OpenWrite());
            Assert.Contains("already opened", ex.Message);

            openedProp.GetSetMethod(nonPublic: true).Invoke(writer, new object[] { false });
            writer.Dispose();
        }

        [Fact]
        public void CloseWrite_NotOpened_ThrowsInvalidOperationException()
        {
            VideoWriter writer = new VideoWriter("out.mp4", 640, 480, 30);
            Assert.Throws<InvalidOperationException>(() => writer.CloseWrite());
            writer.Dispose();
        }

        [Fact]
        public void CloseWrite_NullFfmpegp_SetsOpenedForWritingFalse()
        {
            VideoWriter writer = new VideoWriter("out.mp4", 640, 480, 30);
            PropertyInfo openedProp = typeof(VideoWriter).GetProperty("OpenedForWriting",
                BindingFlags.Public | BindingFlags.Instance);
            openedProp.GetSetMethod(nonPublic: true).Invoke(writer, new object[] { true });
            PropertyInfo inputStreamProp = typeof(VideoWriter).GetProperty("InputDataStream",
                BindingFlags.Public | BindingFlags.Instance);
            inputStreamProp.GetSetMethod(nonPublic: true).Invoke(writer, new object[] { new MemoryStream() });

            Exception ex = Record.Exception(() => writer.CloseWrite());
            Assert.Null(ex);
            Assert.False(writer.OpenedForWriting);
            writer.Dispose();
        }

        [Fact]
        public void CloseWrite_FileModeWithExitedProcess_CompletesSuccessfully()
        {
            VideoWriter writer = new VideoWriter("out.mp4", 640, 480, 30);
            PropertyInfo openedProp = typeof(VideoWriter).GetProperty("OpenedForWriting",
                BindingFlags.Public | BindingFlags.Instance);
            openedProp.GetSetMethod(nonPublic: true).Invoke(writer, new object[] { true });
            PropertyInfo inputStreamProp = typeof(VideoWriter).GetProperty("InputDataStream",
                BindingFlags.Public | BindingFlags.Instance);
            inputStreamProp.GetSetMethod(nonPublic: true).Invoke(writer, new object[] { new MemoryStream() });

            ProcessStartInfo psi = new ProcessStartInfo
            {
                FileName = "/bin/echo",
                Arguments = "done",
                UseShellExecute = false,
                RedirectStandardOutput = true,
                CreateNoWindow = true
            };
            Process process = Process.Start(psi);
            process.WaitForExit(1000);
            FieldInfo ffmpegpField = typeof(VideoWriter).GetField("Ffmpegp",
                BindingFlags.NonPublic | BindingFlags.Instance);
            ffmpegpField.SetValue(writer, process);

            Exception ex = Record.Exception(() => writer.CloseWrite());
            Assert.Null(ex);
            Assert.False(writer.OpenedForWriting);
            writer.Dispose();
        }

        [Fact]
        public void CloseWrite_StreamModeWithExitedProcess_CompletesSuccessfully()
        {
            VideoWriter writer = new VideoWriter(new MemoryStream(), 640, 480, 30);
            PropertyInfo openedProp = typeof(VideoWriter).GetProperty("OpenedForWriting",
                BindingFlags.Public | BindingFlags.Instance);
            openedProp.GetSetMethod(nonPublic: true).Invoke(writer, new object[] { true });
            PropertyInfo inputStreamProp = typeof(VideoWriter).GetProperty("InputDataStream",
                BindingFlags.Public | BindingFlags.Instance);
            inputStreamProp.GetSetMethod(nonPublic: true).Invoke(writer, new object[] { new MemoryStream() });
            PropertyInfo outputStreamProp = typeof(VideoWriter).GetProperty("OutputDataStream",
                BindingFlags.Public | BindingFlags.Instance);
            outputStreamProp.GetSetMethod(nonPublic: true).Invoke(writer, new object[] { new MemoryStream() });
            FieldInfo cscField = typeof(VideoWriter).GetField("csc",
                BindingFlags.NonPublic | BindingFlags.Instance);
            cscField.SetValue(writer, new CancellationTokenSource());

            ProcessStartInfo psi = new ProcessStartInfo
            {
                FileName = "/bin/echo",
                Arguments = "done",
                UseShellExecute = false,
                RedirectStandardOutput = true,
                CreateNoWindow = true
            };
            Process process = Process.Start(psi);
            process.WaitForExit(1000);
            FieldInfo ffmpegpField = typeof(VideoWriter).GetField("Ffmpegp",
                BindingFlags.NonPublic | BindingFlags.Instance);
            ffmpegpField.SetValue(writer, process);

            Exception ex = Record.Exception(() => writer.CloseWrite());
            Assert.Null(ex);
            Assert.False(writer.OpenedForWriting);
            writer.Dispose();
        }

        [Fact]
        public void CloseWrite_ProcessNeedsKill_KillsAndWaitsForExit()
        {
            VideoWriter writer = new VideoWriter("out.mp4", 640, 480, 30);
            PropertyInfo openedProp = typeof(VideoWriter).GetProperty("OpenedForWriting",
                BindingFlags.Public | BindingFlags.Instance);
            openedProp.GetSetMethod(nonPublic: true).Invoke(writer, new object[] { true });
            PropertyInfo inputStreamProp = typeof(VideoWriter).GetProperty("InputDataStream",
                BindingFlags.Public | BindingFlags.Instance);
            inputStreamProp.GetSetMethod(nonPublic: true).Invoke(writer, new object[] { new MemoryStream() });

            ProcessStartInfo psi = new ProcessStartInfo
            {
                FileName = "/bin/sleep",
                Arguments = "10",
                UseShellExecute = false,
                CreateNoWindow = true
            };
            Process process = Process.Start(psi);
            FieldInfo ffmpegpField = typeof(VideoWriter).GetField("Ffmpegp",
                BindingFlags.NonPublic | BindingFlags.Instance);
            ffmpegpField.SetValue(writer, process);

            Stopwatch sw = Stopwatch.StartNew();
            Exception ex = Record.Exception(() => writer.CloseWrite());
            sw.Stop();

            Assert.Null(ex);
            Assert.False(writer.OpenedForWriting);
            Assert.True(process.HasExited);
            Assert.True(sw.ElapsedMilliseconds < 8000);
            writer.Dispose();
        }

        [Fact]
        public void CloseWrite_StreamMode_DisposesOutputStream()
        {
            VideoWriter writer = new VideoWriter(new MemoryStream(), 640, 480, 30);
            PropertyInfo openedProp = typeof(VideoWriter).GetProperty("OpenedForWriting",
                BindingFlags.Public | BindingFlags.Instance);
            openedProp.GetSetMethod(nonPublic: true).Invoke(writer, new object[] { true });
            PropertyInfo inputStreamProp = typeof(VideoWriter).GetProperty("InputDataStream",
                BindingFlags.Public | BindingFlags.Instance);
            inputStreamProp.GetSetMethod(nonPublic: true).Invoke(writer, new object[] { new MemoryStream() });
            MemoryStream outputStream = new MemoryStream();
            PropertyInfo outputStreamProp = typeof(VideoWriter).GetProperty("OutputDataStream",
                BindingFlags.Public | BindingFlags.Instance);
            outputStreamProp.GetSetMethod(nonPublic: true).Invoke(writer, new object[] { outputStream });
            FieldInfo cscField = typeof(VideoWriter).GetField("csc",
                BindingFlags.NonPublic | BindingFlags.Instance);
            cscField.SetValue(writer, new CancellationTokenSource());

            ProcessStartInfo psi = new ProcessStartInfo
            {
                FileName = "/bin/echo",
                Arguments = "done",
                UseShellExecute = false,
                RedirectStandardOutput = true,
                CreateNoWindow = true
            };
            Process process = Process.Start(psi);
            process.WaitForExit(1000);
            FieldInfo ffmpegpField = typeof(VideoWriter).GetField("Ffmpegp",
                BindingFlags.NonPublic | BindingFlags.Instance);
            ffmpegpField.SetValue(writer, process);

            writer.CloseWrite();
            Assert.Throws<ObjectDisposedException>(() => outputStream.ReadByte());
            writer.Dispose();
        }

        [Fact]
        public void InternalFields_CscAndFfmpegp_InitiallyNull()
        {
            using VideoWriter writer = new VideoWriter("out.mp4", 640, 480, 30);
            FieldInfo cscField = typeof(VideoWriter).GetField("csc", BindingFlags.NonPublic | BindingFlags.Instance);
            FieldInfo ffmpegpField = typeof(VideoWriter).GetField("Ffmpegp", BindingFlags.NonPublic | BindingFlags.Instance);
            Assert.Null(cscField.GetValue(writer));
            Assert.Null(ffmpegpField.GetValue(writer));
        }

        [Fact]
        public void CurrentFFmpegProcess_ReturnsNullInitially()
        {
            using VideoWriter writer = new VideoWriter("out.mp4", 640, 480, 30);
            Assert.Null(writer.CurrentFFmpegProcess);
        }

        [Fact]
        public void OutputDataStream_ReturnsNullInitially()
        {
            using VideoWriter writer = new VideoWriter("out.mp4", 640, 480, 30);
            Assert.Null(writer.OutputDataStream);
        }

        [Fact]
        public void DestinationStream_FileCtor_ReturnsNull()
        {
            using VideoWriter writer = new VideoWriter("out.mp4", 640, 480, 30);
            Assert.Null(writer.DestinationStream);
        }

        [Fact]
        public void DestinationStream_StreamCtor_ReturnsProvidedStream()
        {
            using MemoryStream ms = new MemoryStream();
            using VideoWriter writer = new VideoWriter(ms, 640, 480, 30);
            Assert.Equal(ms, writer.DestinationStream);
        }

        [Fact]
        public void InputDataStream_Default_ShouldBeNull()
        {
            using VideoWriter writer = new VideoWriter("out.mp4", 640, 480, 30);
            Assert.Null(writer.InputDataStream);
        }

        [Fact]
        public void OpenedForWriting_Default_ShouldBeFalse()
        {
            using VideoWriter writer = new VideoWriter("out.mp4", 640, 480, 30);
            Assert.False(writer.OpenedForWriting);
        }

        [Fact]
        public void Filename_Default_ShouldBeNull()
        {
            using MemoryStream ms = new MemoryStream();
            using VideoWriter writer = new VideoWriter(ms, 640, 480, 30);
            Assert.Null(writer.Filename);
        }

        [Fact]
        public void OpenWrite_FileMode_OpensAndSetsInputStream()
        {
            string testFile = Path.Combine(_tempDir, Guid.NewGuid() + ".mp4");
            using VideoWriter writer = new VideoWriter(testFile, 640, 480, 30, null, _fakeFfmpegPath);

            Exception ex = Record.Exception(() => writer.OpenWrite());
            Assert.Null(ex);
            Assert.True(writer.OpenedForWriting);
            Assert.NotNull(writer.CurrentFFmpegProcess);
            Assert.NotNull(writer.InputDataStream);
            writer.CloseWrite();
        }

        [Fact]
        public void OpenWrite_FileMode_WithExistingFile_DeletesFileFirst()
        {
            string testFile = Path.Combine(_tempDir, Guid.NewGuid() + ".mp4");
            File.WriteAllText(testFile, "dummy content");
            using VideoWriter writer = new VideoWriter(testFile, 640, 480, 30, null, _fakeFfmpegPath);

            writer.OpenWrite();
            Assert.False(File.Exists(testFile));
            writer.CloseWrite();
        }

        [Fact]
        public void OpenWrite_FileMode_WithShowFFmpegOutput_Works()
        {
            string testFile = Path.Combine(_tempDir, Guid.NewGuid() + ".mp4");
            using VideoWriter writer = new VideoWriter(testFile, 640, 480, 30, null, _fakeFfmpegPath);

            Exception ex = Record.Exception(() => writer.OpenWrite(showFFmpegOutput: true));
            Assert.Null(ex);
            Assert.True(writer.OpenedForWriting);
            writer.CloseWrite();
        }

        [Fact]
        public void OpenWrite_StreamMode_OpensAndSetsStreams()
        {
            using MemoryStream dest = new MemoryStream();
            using VideoWriter writer = new VideoWriter(dest, 640, 480, 30, null, _fakeFfmpegPath);

            Exception ex = Record.Exception(() => writer.OpenWrite());
            Assert.Null(ex);
            Assert.True(writer.OpenedForWriting);
            Assert.NotNull(writer.CurrentFFmpegProcess);
            Assert.NotNull(writer.InputDataStream);
            Assert.NotNull(writer.OutputDataStream);
            writer.CloseWrite();
        }

        [Fact]
        public void Dispose_WithOpenedForWriting_CallsCloseWrite()
        {
            string testFile = Path.Combine(_tempDir, Guid.NewGuid() + ".mp4");
            VideoWriter writer = new VideoWriter(testFile, 640, 480, 30, null, _fakeFfmpegPath);
            writer.OpenWrite();

            writer.Dispose();
            Assert.False(writer.OpenedForWriting);
        }
    }
}
