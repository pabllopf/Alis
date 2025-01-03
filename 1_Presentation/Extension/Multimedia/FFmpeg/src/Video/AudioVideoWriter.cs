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
using Alis.Extension.Multimedia.FFmpeg.Audio;
using Alis.Extension.Multimedia.FFmpeg.Encoding;

namespace Alis.Extension.Multimedia.FFmpeg.Video
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
        private Socket connected_socket;

        /// <summary>
        ///     The csc
        /// </summary>
        private CancellationTokenSource csc;

        /// <summary>
        ///     The ffmpegp
        /// </summary>
        internal Process ffmpegp;

        /// <summary>
        ///     The socket
        /// </summary>
        private Socket socket;

        /// <summary>
        ///     Used for encoding video and audio frames into a single file
        /// </summary>
        /// <param name="filename">Output file name</param>
        /// <param name="video_width">Input video width in pixels</param>
        /// <param name="video_height">Input video height in pixels</param>
        /// <param name="video_framerate">Input video framerate in fps</param>
        /// <param name="audio_channels">Input audio channel count</param>
        /// <param name="audio_sampleRate">Input audio sample rate</param>
        /// <param name="audio_bitDepth">Input audio bits per sample</param>
        /// <param name="videoEncoderOptions">Video encoding options that will be passed to FFmpeg</param>
        /// <param name="audioEncoderOptions">Audio encoding options that will be passed to FFmpeg</param>
        /// <param name="ffmpegExecutable">Name or path to the ffmpeg executable</param>
        public AudioVideoWriter(string filename, int video_width, int video_height, double video_framerate,
            int audio_channels, int audio_sampleRate, int audio_bitDepth,
            EncoderOptions videoEncoderOptions,
            EncoderOptions audioEncoderOptions,
            string ffmpegExecutable = "ffmpeg")
        {
            if (video_width <= 0 || video_height <= 0)
            {
                throw new InvalidDataException("Video frame dimensions have to be bigger than 0 pixels!");
            }

            if (video_framerate <= 0)
            {
                throw new InvalidDataException("Video framerate has to be bigger than 0!");
            }

            if (string.IsNullOrEmpty(filename))
            {
                throw new NullReferenceException("Filename can't be null or empty!");
            }

            if (audio_channels <= 0 || audio_sampleRate <= 0)
            {
                throw new InvalidDataException("Channels/Sample rate have to be bigger than 0!");
            }

            if ((audio_bitDepth != 16) && (audio_bitDepth != 24) && (audio_bitDepth != 32))
            {
                throw new InvalidOperationException("Acceptable bit depths are 16, 24 and 32");
            }

            Filename = filename;
            UseFilename = true;

            VideoWidth = video_width;
            VideoHeight = video_height;
            VideoFramerate = video_framerate;
            VideoEncoderOptions = videoEncoderOptions;

            AudioChannels = audio_channels;
            AudioSampleRate = audio_sampleRate;
            AudioBitDepth = audio_bitDepth;
            AudioEncoderOptions = audioEncoderOptions;

            ffmpeg = ffmpegExecutable;
        }

        /// <summary>
        ///     Used for encoding video and audio frames into a single stream
        /// </summary>
        /// <param name="outputStream">Output stream</param>
        /// <param name="video_width">Input video width in pixels</param>
        /// <param name="video_height">Input video height in pixels</param>
        /// <param name="video_framerate">Input video framerate in fps</param>
        /// <param name="audio_channels">Input audio channel count</param>
        /// <param name="audio_sampleRate">Input audio sample rate</param>
        /// <param name="audio_bitDepth">Input audio bits per sample</param>
        /// <param name="videoEncoderOptions">Video encoding options that will be passed to FFmpeg</param>
        /// <param name="audioEncoderOptions">Audio encoding options that will be passed to FFmpeg</param>
        /// <param name="ffmpegExecutable">Name or path to the ffmpeg executable</param>
        public AudioVideoWriter(Stream outputStream, int video_width, int video_height, double video_framerate,
            int audio_channels, int audio_sampleRate, int audio_bitDepth,
            EncoderOptions videoEncoderOptions,
            EncoderOptions audioEncoderOptions,
            string ffmpegExecutable = "ffmpeg")
        {
            if (video_width <= 0 || video_height <= 0)
            {
                throw new InvalidDataException("Video frame dimensions have to be bigger than 0 pixels!");
            }

            if (video_framerate <= 0)
            {
                throw new InvalidDataException("Video framerate has to be bigger than 0!");
            }

            if (audio_channels <= 0 || audio_sampleRate <= 0)
            {
                throw new InvalidDataException("Channels/Sample rate have to be bigger than 0!");
            }

            if ((audio_bitDepth != 16) && (audio_bitDepth != 24) && (audio_bitDepth != 32))
            {
                throw new InvalidOperationException("Acceptable bit depths are 16, 24 and 32");
            }

            DestinationStream = outputStream ?? throw new NullReferenceException("Stream can't be null!");
            UseFilename = false;

            VideoWidth = video_width;
            VideoHeight = video_height;
            VideoFramerate = video_framerate;
            VideoEncoderOptions = videoEncoderOptions;

            AudioChannels = audio_channels;
            AudioSampleRate = audio_sampleRate;
            AudioBitDepth = audio_bitDepth;
            AudioEncoderOptions = audioEncoderOptions;

            ffmpeg = ffmpegExecutable;
        }

        /// <summary>
        ///     Gets the value of the current f fmpeg process
        /// </summary>
        public Process CurrentFFmpegProcess => ffmpegp;

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
        /// <param name="thread_queue_size">
        ///     Max. number of queued packets when reading from file/stream.
        ///     Should be set to higher when dealing with high rate/low latency streams.
        /// </param>
        public void OpenWrite(bool showFFmpegOutput = false, int thread_queue_size = 4096)
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
                connected_socket = socket.EndAccept(r);
                InputDataStreamAudio = new NetworkStream(connected_socket);
                manual.Set();
            }, null);

            string cmd = $"-f s{AudioBitDepth}le -channels {AudioChannels} -sample_rate {AudioSampleRate} " +
                         $"-thread_queue_size {thread_queue_size} -i \"tcp://{IPAddress.Loopback}:{port}\" " +
                         $"-f rawvideo -video_size {VideoWidth}:{VideoHeight} -r {VideoFramerate} " +
                         $"-thread_queue_size {thread_queue_size} -pixel_format rgb24 -i - " +
                         $"-map 0 -c:a {AudioEncoderOptions.EncoderName} {AudioEncoderOptions.EncoderArguments} " +
                         $"-map 1 -c:v {VideoEncoderOptions.EncoderName} {VideoEncoderOptions.EncoderArguments} " +
                         $"-f {VideoEncoderOptions.Format}";

            if (UseFilename)
            {
                if (File.Exists(Filename))
                {
                    File.Delete(Filename);
                }

                InputDataStreamVideo = FfMpegWrapper.OpenInput(ffmpeg, $"{cmd} \"{Filename}\"", out ffmpegp, showFFmpegOutput);
            }
            else
            {
                csc = new CancellationTokenSource();

                // using stream
                (InputDataStreamVideo, OutputDataStream) = FfMpegWrapper.Open(ffmpeg, $"{cmd} -", out ffmpegp, showFFmpegOutput);
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

                connected_socket?.Shutdown(SocketShutdown.Both);
                connected_socket?.Close();
                socket?.Close();

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