// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:VideoFrameCoverageGapTests.cs
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
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using Alis.Extension.Media.FFmpeg.Video;
using Xunit;

namespace Alis.Extension.Media.FFmpeg.Test.Video
{
    /// <summary>
    ///     The unix fact attribute class
    /// </summary>
    /// <seealso cref="FactAttribute"/>
    public class UnixFactAttribute : FactAttribute
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UnixFactAttribute"/> class
        /// </summary>
        public UnixFactAttribute()
        {
            if (!RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                return;
            }

            Skip = "Unix stub executable tests are skipped on Windows";
        }
    }

    /// <summary>
    ///     The video frame coverage gap tests class
    /// </summary>
    public class VideoFrameCoverageGapTests
    {
        /// <summary>
        /// Tests creates readable stub executable
        /// </summary>
        /// <param name="path">The path</param>
        private static void CreateReadableStubExecutable(string path)
        {
            using (StreamWriter writer = File.CreateText(path))
            {
                writer.Write("#!/bin/sh\nexec cat > /dev/null\n");
            }

            using (Process chmod = Process.Start(new ProcessStartInfo
            {
                FileName = "/bin/chmod",
                Arguments = "+x \"" + path + "\"",
                UseShellExecute = false,
                CreateNoWindow = true
            }))
            {
                chmod.WaitForExit();
            }
        }

        /// <summary>
        /// Tests that save with stub executable should write pixels without exception
        /// </summary>
        [UnixFact]
        public void Save_WithStubExecutable_ShouldWritePixelsWithoutException()
        {
            VideoFrame frame = new VideoFrame(2, 2);
            byte[] data = new byte[12];
            for (int i = 0; i < data.Length; i++)
            {
                data[i] = (byte)i;
            }

            frame.Load(new MemoryStream(data));

            string stubPath = Path.Combine(Path.GetTempPath(), Path.GetRandomFileName());
            CreateReadableStubExecutable(stubPath);

            string outputPath = Path.Combine(Path.GetTempPath(), Path.GetRandomFileName());

            try
            {
                Exception exception = Record.Exception(() =>
                    frame.Save(outputPath, ffmpegExecutable: stubPath));

                Assert.Null(exception);
            }
            finally
            {
                if (File.Exists(outputPath))
                {
                    File.Delete(outputPath);
                }

                File.Delete(stubPath);
            }
        }

        /// <summary>
        /// Tests that save with stub executable and existing output should delete and write
        /// </summary>
        [UnixFact]
        public void Save_WithStubExecutableAndExistingOutput_ShouldDeleteAndWrite()
        {
            VideoFrame frame = new VideoFrame(2, 2);
            frame.Load(new MemoryStream(new byte[12]));

            string stubPath = Path.Combine(Path.GetTempPath(), Path.GetRandomFileName());
            CreateReadableStubExecutable(stubPath);

            string outputPath = Path.Combine(Path.GetTempPath(), Path.GetRandomFileName());
            File.WriteAllText(outputPath, "dummy");

            try
            {
                Exception exception = Record.Exception(() =>
                    frame.Save(outputPath, encoder: "bmp", extraParameters: "-q:v 2", ffmpegExecutable: stubPath));

                Assert.Null(exception);
                Assert.False(File.Exists(outputPath));
            }
            finally
            {
                if (File.Exists(outputPath))
                {
                    File.Delete(outputPath);
                }

                File.Delete(stubPath);
            }
        }

        /// <summary>
        /// Tests that save with non existent executable should throw win32 exception
        /// </summary>
        [Fact]
        public void Save_WithNonExistentExecutable_ShouldThrowWin32Exception()
        {
            VideoFrame frame = new VideoFrame(2, 2);
            frame.Load(new MemoryStream(new byte[12]));

            string outputPath = Path.Combine(Path.GetTempPath(), Path.GetRandomFileName());

            try
            {
                Assert.Throws<Win32Exception>(() =>
                    frame.Save(outputPath, ffmpegExecutable: "no-such-tool-guaranteed-missing"));

                Assert.False(File.Exists(outputPath));
            }
            finally
            {
                if (File.Exists(outputPath))
                {
                    File.Delete(outputPath);
                }
            }
        }
    }
}
