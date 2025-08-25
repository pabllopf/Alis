// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:AudioVideoWriter.cs
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
using System.Net;
using System.Net.Sockets;
using System.Threading;
using Alis.Extension.Media.FFmpeg.Audio;
using Alis.Extension.Media.FFmpeg.Encoding;

namespace Alis.Extension.Media.FFmpeg.Video
{
    /// <summary>
    ///     The audio video writer class
    /// </summary>
    /// <seealso cref="IDisposable" />
    public class AudioVideoWriter : IDisposable
    {
        /// <summary>
        ///     The ffmpeg
        /// </summary>
        private readonly string ffmpeg;

        /// <summary>
        ///     The connected socket
        /// </summary>
        private Socket connectedSocket;

        /// <summary>
        ///     The csc
        /// </summary>
        private CancellationTokenSource csc;

        /// <summary>
        ///     The ffmpegp
        /// </summary>
        internal Process Ffmpegp;

        /// <summary>
        ///     The socket
        /// </summary>
        private Socket socket;

        /// <summary>
        ///     Used for encoding video and audio frames into a single file
        /// </summary>
        /// <param name="filename">Output file name</param>
        /// <param name="videoWidth">Input video width in pixels</param>
        /// <param name="videoHeight">Input video height in pixels</param>
        /// <param name="videoFramerate">Input video framerate in fps</param>
        /// <param name="audioChannels">Input audio channel count</param>
        /// <param name="audioSampleRate">Input audio sample rate</param>
        /// <param name="audioBitDepth">Input audio bits per sample</param>
        /// <param name="videoEncoderOptions">Video encoding options that will be passed to FFmpeg</param>
        /// <param name="audioEncoderOptions">Audio encoding options that will be passed to FFmpeg</param>
        /// <param name="ffmpegExecutable">Name or path to the ffmpeg executable</param>
        public AudioVideoWriter(string filename, int videoWidth, int videoHeight, double videoFramerate,
            int audioChannels, int audioSampleRate, int audioBitDepth,
            EncoderOptions videoEncoderOptions,
            EncoderOptions audioEncoderOptions,
            string ffmpegExecutable = "ffmpeg")
        {
            if (videoWidth <= 0 || videoHeight <= 0)
            {
                throw new InvalidDataException("Video frame dimensions have to be bigger than 0 pixels!");
            }

            if (videoFramerate <= 0)
            {
                throw new InvalidDataException("Video framerate has to be bigger than 0!");
            }

            if (string.IsNullOrEmpty(filename))
            {
                throw new NullReferenceException("Filename can't be null or empty!");
            }

            if (audioChannels <= 0 || audioSampleRate <= 0)
            {
                throw new InvalidDataException("Channels/Sample rate have to be bigger than 0!");
            }

            if ((audioBitDepth != 16) && (audioBitDepth != 24) && (audioBitDepth != 32))
            {
                throw new InvalidOperationException("Acceptable bit depths are 16, 24 and 32");
            }

            Filename = filename;
            UseFilename = true;

            VideoWidth = videoWidth;
            VideoHeight = videoHeight;
            VideoFramerate = videoFramerate;
            VideoEncoderOptions = videoEncoderOptions;

            AudioChannels = audioChannels;
            AudioSampleRate = audioSampleRate;
            AudioBitDepth = audioBitDepth;
            AudioEncoderOptions = audioEncoderOptions;

            ffmpeg = ffmpegExecutable;
        }

        /// <summary>
        ///     Used for encoding video and audio frames into a single stream
        /// </summary>
        /// <param name="outputStream">Output stream</param>
        /// <param name="videoWidth">Input video width in pixels</param>
        /// <param name="videoHeight">Input video height in pixels</param>
        /// <param name="videoFramerate">Input video framerate in fps</param>
        /// <param name="audioChannels">Input audio channel count</param>
        /// <param name="audioSampleRate">Input audio sample rate</param>
        /// <param name="audioBitDepth">Input audio bits per sample</param>
        /// <param name="videoEncoderOptions">Video encoding options that will be passed to FFmpeg</param>
        /// <param name="audioEncoderOptions">Audio encoding options that will be passed to FFmpeg</param>
        /// <param name="ffmpegExecutable">Name or path to the ffmpeg executable</param>
        public AudioVideoWriter(Stream outputStream, int videoWidth, int videoHeight, double videoFramerate,
            int audioChannels, int audioSampleRate, int audioBitDepth,
            EncoderOptions videoEncoderOptions,
            EncoderOptions audioEncoderOptions,
            string ffmpegExecutable = "ffmpeg")
        {
            if (videoWidth <= 0 || videoHeight <= 0)
            {
                throw new InvalidDataException("Video frame dimensions have to be bigger than 0 pixels!");
            }

            if (videoFramerate <= 0)
            {
                throw new InvalidDataException("Video framerate has to be bigger than 0!");
            }

            if (audioChannels <= 0 || audioSampleRate <= 0)
            {
                throw new InvalidDataException("Channels/Sample rate have to be bigger than 0!");
            }

            if ((audioBitDepth != 16) && (audioBitDepth != 24) && (audioBitDepth != 32))
            {
                throw new InvalidOperationException("Acceptable bit depths are 16, 24 and 32");
            }

            DestinationStream = outputStream ?? throw new NullReferenceException("Stream can't be null!");
            UseFilename = false;

            VideoWidth = videoWidth;
            VideoHeight = videoHeight;
            VideoFramerate = videoFramerate;
            VideoEncoderOptions = videoEncoderOptions;

            AudioChannels = audioChannels;
            AudioSampleRate = audioSampleRate;
            AudioBitDepth = audioBitDepth;
            AudioEncoderOptions = audioEncoderOptions;

            ffmpeg = ffmpegExecutable;
        }

        /// <summary>
        ///     Gets the value of the current f fmpeg process
        /// </summary>
        public Process CurrentFFmpegProcess => Ffmpegp;

        /// <summary>
        ///     Input video stream
        /// </summary>
        public Stream InputDataStreamVideo { get; private set; }

        /// <summary>
        ///     Input audio stream
        /// </summary>
        public NetworkStream InputDataStreamAudio { get; private set; }

        /// <summary>
        ///     Destination stream (when filename is not specified)
        /// </summary>
        public Stream DestinationStream { get; }

        /// <summary>
        ///     FFmpeg output stream
        /// </summary>
        public Stream OutputDataStream { get; private set; }

        /// <summary>
        ///     Output filename
        /// </summary>
        public string Filename { get; }

        /// <summary>
        ///     Gets the value of the use filename
        /// </summary>
        public bool UseFilename { get; }

        /// <summary>
        ///     Gets the value of the video width
        /// </summary>
        public int VideoWidth { get; }

        /// <summary>
        ///     Gets the value of the video height
        /// </summary>
        public int VideoHeight { get; }

        /// <summary>
        ///     Gets the value of the video framerate
        /// </summary>
        public double VideoFramerate { get; }

        /// <summary>
        ///     Gets the value of the audio channels
        /// </summary>
        public int AudioChannels { get; }

        /// <summary>
        ///     Gets the value of the audio sample rate
        /// </summary>
        public int AudioSampleRate { get; }

        /// <summary>
        ///     Gets the value of the audio bit depth
        /// </summary>
        public int AudioBitDepth { get; }

        /// <summary>
        ///     Is data stream opened for writing
        /// </summary>
        public virtual bool OpenedForWriting { get; protected set; }

        /// <summary>
        ///     Gets the value of the audio encoder options
        /// </summary>
        public EncoderOptions AudioEncoderOptions { get; }

        /// <summary>
        ///     Gets the value of the video encoder options
        /// </summary>
        public EncoderOptions VideoEncoderOptions { get; }

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
        ///     Prepares for writing.
        /// </summary>
        /// <param name="showFFmpegOutput">Show output to terminal. Error stream will not be redirected if this is set to true.</param>
        /// <param name="threadQueueSize">
        ///     Max. number of queued packets when reading from file/stream.
        ///     Should be set to higher when dealing with high rate/low latency streams.
        /// </param>
        public void OpenWrite(bool showFFmpegOutput = false, int threadQueueSize = 4096)
        {
            if (OpenedForWriting)
            {
                throw new InvalidOperationException("File/Stream was already opened for writing!");
            }

            ManualResetEvent manual = new ManualResetEvent(false);

            socket = new Socket(SocketType.Stream, ProtocolType.Tcp);
            socket.Bind(new IPEndPoint(IPAddress.Loopback, 0));
            socket.Listen(4);
            int port = ((IPEndPoint) socket.LocalEndPoint).Port;
            socket.BeginAccept(r =>
            {
                connectedSocket = socket.EndAccept(r);
                InputDataStreamAudio = new NetworkStream(connectedSocket);
                manual.Set();
            }, null);

            string cmd = $"-f s{AudioBitDepth}le -channels {AudioChannels} -sample_rate {AudioSampleRate} " +
                         $"-thread_queue_size {threadQueueSize} -i \"tcp://{IPAddress.Loopback}:{port}\" " +
                         $"-f rawvideo -video_size {VideoWidth}:{VideoHeight} -r {VideoFramerate} " +
                         $"-thread_queue_size {threadQueueSize} -pixel_format rgb24 -i - " +
                         $"-map 0 -c:a {AudioEncoderOptions.EncoderName} {AudioEncoderOptions.EncoderArguments} " +
                         $"-map 1 -c:v {VideoEncoderOptions.EncoderName} {VideoEncoderOptions.EncoderArguments} " +
                         $"-f {VideoEncoderOptions.Format}";

            if (UseFilename)
            {
                if (File.Exists(Filename))
                {
                    File.Delete(Filename);
                }

                InputDataStreamVideo = FfMpegWrapper.OpenInput(ffmpeg, $"{cmd} \"{Filename}\"", out Ffmpegp, showFFmpegOutput);
            }
            else
            {
                csc = new CancellationTokenSource();

                // using stream
                (InputDataStreamVideo, OutputDataStream) = FfMpegWrapper.Open(ffmpeg, $"{cmd} -", out Ffmpegp, showFFmpegOutput);
                _ = OutputDataStream.CopyToAsync(DestinationStream, 81920, csc.Token);
            }

            manual.WaitOne();
            OpenedForWriting = true;
        }

        /// <summary>
        ///     Closes output video.
        /// </summary>
        public void CloseWrite()
        {
            if (!OpenedForWriting)
            {
                throw new InvalidOperationException("File is not opened for writing!");
            }

            try
            {
                InputDataStreamAudio?.Dispose();
                InputDataStreamVideo?.Dispose();

                connectedSocket?.Shutdown(SocketShutdown.Both);
                connectedSocket?.Close();
                socket?.Close();

                Ffmpegp.WaitForExit();
                csc?.Cancel();

                if (!UseFilename)
                {
                    OutputDataStream?.Dispose();
                }

                try
                {
                    if (Ffmpegp?.HasExited == false)
                    {
                        Ffmpegp.Kill();
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

        /// <summary>
        ///     Writes audio frame to output. Make sure to call OpenWrite() before calling this.
        /// </summary>
        /// <param name="frame">Frame containing audio data</param>
        public void WriteFrame(AudioFrame frame)
        {
            if (!OpenedForWriting)
            {
                throw new InvalidOperationException("Media needs to be prepared for writing first!");
            }

            byte[] data = frame.RawData;
            InputDataStreamAudio.Write(data, 0, data.Length);
        }

        /// <summary>
        ///     Writes video frame to output. Make sure to call OpenWrite() before calling this.
        /// </summary>
        /// <param name="frame">Frame containing audio data</param>
        public void WriteFrame(VideoFrame frame)
        {
            if (!OpenedForWriting)
            {
                throw new InvalidOperationException("Media needs to be prepared for writing first!");
            }

            byte[] data = frame.RawData;
            InputDataStreamVideo.Write(data, 0, data.Length);
        }
    }
}