// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:VideoWriter.cs
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
using System.Threading;
using Alis.Extension.Encode.FFMeg.BaseClasses;
using Alis.Extension.Encode.FFMeg.Encoding;
using Alis.Extension.Encode.FFMeg.Encoding.Builders;

namespace Alis.Extension.Encode.FFMeg.Video
{
    /// <summary>
    ///     The video writer class
    /// </summary>
    /// <seealso cref="MediaWriter{Frame}" />
    /// <seealso cref="IDisposable" />
    public class VideoWriter : MediaWriter<VideoFrame>, IDisposable
    {
        /// <summary>
        ///     The csc
        /// </summary>
        private CancellationTokenSource csc;

        /// <summary>
        ///     The ffmpeg
        /// </summary>
        private readonly string ffmpeg;

        /// <summary>
        ///     The ffmpegp
        /// </summary>
        internal Process ffmpegp;


        /// <summary>
        ///     Used for encoding frames into a new video file
        /// </summary>
        /// <param name="filename">Output video file name/path</param>
        /// <param name="width">Input width of the video in pixels</param>
        /// <param name="height">Input height of the video in pixels </param>
        /// <param name="framerate">Input framerate of the video in fps</param>
        /// <param name="encoderOptions">Encoding options that will be passed to FFmpeg</param>
        /// <param name="ffmpegExecutable">Name or path to the ffmpeg executable</param>
        public VideoWriter(string filename, int width, int height, double framerate,
            EncoderOptions encoderOptions = null, string ffmpegExecutable = "ffmpeg")
        {
            if (width <= 0 || height <= 0) throw new InvalidDataException("Video frame dimensions have to be bigger than 0 pixels!");
            if (framerate <= 0) throw new InvalidDataException("Video framerate has to be bigger than 0!");
            if (string.IsNullOrEmpty(filename)) throw new NullReferenceException("Filename can't be null or empty!");

            UseFilename = true;
            Filename = filename;

            ffmpeg = ffmpegExecutable;

            Width = width;
            Height = height;
            Framerate = framerate;
            DestinationStream = null;
            EncoderOptions = encoderOptions ?? new H264Encoder().Create();
        }

        /// <summary>
        ///     Used for encoding frames into a stream (Requires using a supported format like 'flv' for streaming)
        /// </summary>
        /// <param name="destinationStream">Output stream</param>
        /// <param name="width">Input width of the video in pixels</param>
        /// <param name="height">Input height of the video in pixels </param>
        /// <param name="framerate">Input framerate of the video in fps</param>
        /// <param name="encoderOptions">Extra FFmpeg encoding options that will be passed to FFmpeg</param>
        /// <param name="ffmpegExecutable">Name or path to the ffmpeg executable</param>
        public VideoWriter(Stream destinationStream, int width, int height, double framerate,
            EncoderOptions encoderOptions = null, string ffmpegExecutable = "ffmpeg")
        {
            if (width <= 0 || height <= 0) throw new InvalidDataException("Video frame dimensions have to be bigger than 0 pixels!");
            if (framerate <= 0) throw new InvalidDataException("Video framerate has to be bigger than 0!");

            UseFilename = false;

            ffmpeg = ffmpegExecutable;

            Width = width;
            Height = height;
            Framerate = framerate;
            DestinationStream = destinationStream ?? throw new NullReferenceException("Stream can't be null!");
            EncoderOptions = encoderOptions ?? new H264Encoder().Create();
        }

        /// <summary>
        ///     Gets the value of the current f fmpeg process
        /// </summary>
        public Process CurrentFFmpegProcess => ffmpegp;

        /// <summary>
        ///     Gets the value of the width
        /// </summary>
        public int Width { get; }

        /// <summary>
        ///     Gets the value of the height
        /// </summary>
        public int Height { get; }

        /// <summary>
        ///     Gets the value of the framerate
        /// </summary>
        public double Framerate { get; }

        /// <summary>
        ///     Gets the value of the use filename
        /// </summary>
        public bool UseFilename { get; }

        /// <summary>
        ///     Gets the value of the encoder options
        /// </summary>
        public EncoderOptions EncoderOptions { get; }

        /// <summary>
        ///     Gets or sets the value of the destination stream
        /// </summary>
        public Stream DestinationStream { get; }

        /// <summary>
        ///     Gets or sets the value of the output data stream
        /// </summary>
        public Stream OutputDataStream { get; private set; }

        /// <summary>
        ///     Disposes this instance
        /// </summary>
        public void Dispose()
        {
            if (OpenedForWriting) CloseWrite();
            DestinationStream?.Dispose();
            csc?.Dispose();
        }

        /// <summary>
        ///     Opens the write using the specified show f fmpeg output
        /// </summary>
        /// <param name="showFFmpegOutput">The show fmpeg output</param>
        /// <exception cref="InvalidOperationException">File was already opened for writing!</exception>
        public void OpenWrite(bool showFFmpegOutput = false)
        {
            if (OpenedForWriting) throw new InvalidOperationException("File was already opened for writing!");

            string cmd = $"-f rawvideo -video_size {Width}:{Height} -r {Framerate} -pixel_format rgb24 -i - " +
                         $"-c:v {EncoderOptions.EncoderName} {EncoderOptions.EncoderArguments} -f {EncoderOptions.Format}";

            if (UseFilename)
            {
                if (File.Exists(Filename)) File.Delete(Filename);

                InputDataStream = FfMpegWrapper.OpenInput(ffmpeg, $"{cmd} \"{Filename}\"", out ffmpegp, showFFmpegOutput);
            }
            else
            {
                csc = new CancellationTokenSource();

                // using stream
                (InputDataStream, OutputDataStream) = FfMpegWrapper.Open(ffmpeg, $"{cmd} -", out ffmpegp, showFFmpegOutput);
                _ = OutputDataStream.CopyToAsync(DestinationStream, 81920, csc.Token); // 81920 is the default buffer size
            }

            OpenedForWriting = true;
        }

        /// <summary>
        ///     Closes output video file.
        /// </summary>
        public void CloseWrite()
        {
            if (!OpenedForWriting) throw new InvalidOperationException("File is not opened for writing!");

            try
            {
                InputDataStream.Dispose();
                ffmpegp.WaitForExit();
                csc?.Cancel();

                if (!UseFilename) OutputDataStream?.Dispose();

                try
                {
                    if (ffmpegp?.HasExited == false) ffmpegp.Kill();
                }
                catch
                {
                }
            }
            finally
            {
                OpenedForWriting = false;
            }
        }
    }
}