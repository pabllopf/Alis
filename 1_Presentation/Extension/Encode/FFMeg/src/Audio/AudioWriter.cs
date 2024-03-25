// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:AudioWriter.cs
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

namespace Alis.Extension.Encode.FFMeg.Audio
{
    /// <summary>
    ///     The audio writer class
    /// </summary>
    /// <seealso cref="MediaWriter{Frame}" />
    /// <seealso cref="IDisposable" />
    public class AudioWriter : MediaWriter<AudioFrame>, IDisposable
    {
        /// <summary>
        ///     The ffmpeg
        /// </summary>
        private readonly string ffmpeg;

        /// <summary>
        ///     The csc
        /// </summary>
        private CancellationTokenSource csc;

        /// <summary>
        ///     The ffmpegp
        /// </summary>
        internal Process ffmpegp;


        /// <summary>
        ///     Used for encoding audio samples into a new audio file
        /// </summary>
        /// <param name="filename">Output audio file name/path</param>
        /// <param name="channels">Input number of channels</param>
        /// <param name="sampleRate">Input sample rate</param>
        /// <param name="bitDepth">Input bits per sample</param>
        /// <param name="encoderOptions">Extra FFmpeg encoding options that will be passed to FFmpeg</param>
        /// <param name="ffmpegExecutable">Name or path to the ffmpeg executable</param>
        public AudioWriter(string filename, int channels, int sampleRate, int bitDepth = 16,
            EncoderOptions encoderOptions = null, string ffmpegExecutable = "ffmpeg")
        {
            if (channels <= 0 || sampleRate <= 0)
            {
                throw new InvalidDataException("Channels/Sample rate have to be bigger than 0!");
            }

            if ((bitDepth != 16) && (bitDepth != 24) && (bitDepth != 32))
            {
                throw new InvalidOperationException("Acceptable bit depths are 16, 24 and 32");
            }

            if (string.IsNullOrEmpty(filename))
            {
                throw new NullReferenceException("Filename can't be null or empty!");
            }

            UseFilename = true;
            ffmpeg = ffmpegExecutable;

            Channels = channels;
            BitDepth = bitDepth;
            SampleRate = sampleRate;

            Filename = filename;
            EncoderOptions = encoderOptions ?? new MP3Encoder().Create();
        }

        /// <summary>
        ///     Used for encoding audio samples into a stream
        /// </summary>
        /// <param name="destinationStream">Output stream</param>
        /// <param name="channels">Input number of channels</param>
        /// <param name="sampleRate">Input sample rate</param>
        /// <param name="bitDepth">Input bits per sample</param>
        /// <param name="encoderOptions">Extra FFmpeg encoding options that will be passed to FFmpeg</param>
        /// <param name="ffmpegExecutable">Name or path to the ffmpeg executable</param>
        public AudioWriter(Stream destinationStream, int channels, int sampleRate, int bitDepth = 16,
            EncoderOptions encoderOptions = null, string ffmpegExecutable = "ffmpeg")
        {
            if (channels <= 0 || sampleRate <= 0)
            {
                throw new InvalidDataException("Channels/Sample rate have to be bigger than 0!");
            }

            if ((bitDepth != 16) && (bitDepth != 24) && (bitDepth != 32))
            {
                throw new InvalidOperationException("Acceptable bit depths are 16, 24 and 32");
            }

            UseFilename = false;
            ffmpeg = ffmpegExecutable;

            Channels = channels;
            BitDepth = bitDepth;
            SampleRate = sampleRate;

            DestinationStream = destinationStream ?? throw new NullReferenceException("Stream can't be null!");
            EncoderOptions = encoderOptions ?? new MP3Encoder().Create();
        }

        /// <summary>
        ///     Gets the value of the current f fmpeg process
        /// </summary>
        public Process CurrentFFmpegProcess => ffmpegp;

        /// <summary>
        ///     Gets the value of the channels
        /// </summary>
        public int Channels { get; }

        /// <summary>
        ///     Gets the value of the sample rate
        /// </summary>
        public int SampleRate { get; }

        /// <summary>
        ///     Gets the value of the bit depth
        /// </summary>
        public int BitDepth { get; }

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
            if (OpenedForWriting)
            {
                CloseWrite();
            }

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
            if (OpenedForWriting)
            {
                throw new InvalidOperationException("File was already opened for writing!");
            }

            string cmd = $"-f s{BitDepth}le -channels {Channels} -sample_rate {SampleRate} -i - " +
                         $"-c:a {EncoderOptions.EncoderName} {EncoderOptions.EncoderArguments} -f {EncoderOptions.Format}";

            if (UseFilename)
            {
                if (File.Exists(Filename))
                {
                    File.Delete(Filename);
                }

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
        ///     Closes output audio file.
        /// </summary>
        public void CloseWrite()
        {
            if (!OpenedForWriting)
            {
                throw new InvalidOperationException("File is not opened for writing!");
            }

            try
            {
                InputDataStream.Dispose();
                ffmpegp.WaitForExit();
                csc?.Cancel();

                if (!UseFilename)
                {
                    OutputDataStream?.Dispose();
                }

                try
                {
                    if (ffmpegp?.HasExited == false)
                    {
                        ffmpegp.Kill();
                    }
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