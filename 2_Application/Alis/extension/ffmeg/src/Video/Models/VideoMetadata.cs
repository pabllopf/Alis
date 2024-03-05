using System.Linq;
using Alis.Core.Aspect.Data.Json;
using Alis.Extension.FFMeg.BaseClasses;

namespace Alis.Extension.FFMeg.Video.Models
{
    // prepare for source generation

    /// <summary>

    /// The video metadata class

    /// </summary>

    public class VideoMetadata
    {
        /// <summary>
        /// Video pixel format
        /// </summary>
        public string PixelFormat { get; set; }

        /// <summary>
        /// Video codec (long name)
        /// </summary>
        public string CodecLongName { get; set; }

        /// <summary>
        /// Video codec
        /// </summary>
        public string Codec { get; set; }

        /// <summary>
        /// Video width
        /// </summary>
        public int Width { get; set; }

        /// <summary>
        /// Video height
        /// </summary>
        public int Height { get; set; }

        /// <summary>
        /// Video duration in seconds
        /// </summary>
        public double Duration { get; set; }

        /// <summary>
        /// Average video framerate
        /// </summary>
        public double AvgFramerate { get; set; }
        
        /// <summary>
        /// Average video bitrate
        /// </summary>
        public int BitRate { get; set; }

        /// <summary>
        /// Bits per sample
        /// </summary>
        public int BitDepth { get; set; }

        /// <summary>
        /// Pixel aspect ratio
        /// </summary>
        public string SampleAspectRatio { get; set; }

        /// <summary>
        /// Predicted frame count based on average framerate and duration
        /// </summary>
        public int PredictedFrameCount { get; set; }

        /// <summary>
        /// Get first video stream
        /// </summary>
        public MediaStream GetFirstVideoStream() => Streams.Where(x => x.IsVideo).FirstOrDefault();

        /// <summary>
        /// Get first audio stream
        /// </summary>
        public MediaStream GetFirstAudioStream() => Streams.Where(x => x.IsAudio).FirstOrDefault();

        /// <summary>
        /// Media streams inside the file. Can contain non-video streams as well.
        /// </summary>
        [JsonPropertyName("streams")]
        public MediaStream[] Streams { get; set; }

        /// <summary>
        /// File format information.
        /// </summary>
        [JsonPropertyName("format")]
        public VideoFormat Format { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="VideoMetadata"/> class
        /// </summary>
        public VideoMetadata() { }
    }
}