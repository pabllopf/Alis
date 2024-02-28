using System;
using System.IO;
using System.Threading;
using System.Diagnostics;
using CryMediaAPI.BaseClasses;
using CryMediaAPI.Encoding;
using CryMediaAPI.Encoding.Builders;

namespace CryMediaAPI.Video;

/// <summary>

/// The video writer class

/// </summary>

/// <seealso cref="MediaWriter{VideoFrame}"/>

/// <seealso cref="IDisposable"/>

public class VideoWriter : MediaWriter<VideoFrame>, IDisposable
{
    /// <summary>
    /// The ffmpeg
    /// </summary>
    string ffmpeg;
    /// <summary>
    /// The csc
    /// </summary>
    CancellationTokenSource csc;
    /// <summary>
    /// The ffmpegp
    /// </summary>
    internal Process ffmpegp;

    /// <summary>
    /// Gets the value of the current f fmpeg process
    /// </summary>
    public Process CurrentFFmpegProcess => ffmpegp;

    /// <summary>
    /// Gets the value of the width
    /// </summary>
    public int Width { get; }
    /// <summary>
    /// Gets the value of the height
    /// </summary>
    public int Height { get; }
    /// <summary>
    /// Gets the value of the framerate
    /// </summary>
    public double Framerate { get; }
    /// <summary>
    /// Gets the value of the use filename
    /// </summary>
    public bool UseFilename { get; }
    /// <summary>
    /// Gets the value of the encoder options
    /// </summary>
    public EncoderOptions EncoderOptions { get; }

    /// <summary>
    /// Gets or sets the value of the destination stream
    /// </summary>
    public Stream DestinationStream { get; private set; }
    /// <summary>
    /// Gets or sets the value of the output data stream
    /// </summary>
    public Stream OutputDataStream { get; private set; }


    /// <summary>
    /// Used for encoding frames into a new video file
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
    /// Used for encoding frames into a stream (Requires using a supported format like 'flv' for streaming)
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
    /// Opens the write using the specified show f fmpeg output
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

            InputDataStream = FFmpegWrapper.OpenInput(ffmpeg, $"{cmd} \"{Filename}\"", out ffmpegp, showFFmpegOutput);
        }
        else
        {
            csc = new CancellationTokenSource();

            // using stream
            (InputDataStream, OutputDataStream) = FFmpegWrapper.Open(ffmpeg, $"{cmd} -", out ffmpegp, showFFmpegOutput);
            _ = OutputDataStream.CopyToAsync(DestinationStream, 81920, csc.Token); // 81920 is the default buffer size
        }

        OpenedForWriting = true;
    }

    /// <summary>
    /// Closes output video file.
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
            catch { }
        }
        finally
        {
            OpenedForWriting = false;
        }
    }

    /// <summary>
    /// Disposes this instance
    /// </summary>
    public void Dispose()
    {
        if (OpenedForWriting) CloseWrite();
    }
}
