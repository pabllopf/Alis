using System.Linq;
using System.Text.Json.Serialization;
using Alis.Extension.FFMeg.BaseClasses;

namespace Alis.Extension.FFMeg.Audio.Models
{
    /// <summary>
    /// The audio metadata class
    /// </summary>
    public class AudioMetadata
    {
        /// <summary>
        /// Audio sample format
        /// </summary>
        public string SampleFormat { get; set; }

        /// <summary>
        /// Audio codec (long name)
        /// </summary>
        public string CodecLongName { get; set; }

        /// <summary>
        /// Audio codec
        /// </summary>
        public string Codec { get; set; }

        /// <summary>
        /// Audio channel count
        /// </summary>
        public int Channels { get; set; }

        /// <summary>
        /// Audio sample rate
        /// </summary>
        public int SampleRate { get; set; }

        /// <summary>
        /// Audio duration in seconds
        /// </summary>
        public double Duration { get; set; }

        /// <summary>
        /// Average audio bitrate
        /// </summary>
        public int BitRate { get; set; }

        /// <summary>
        /// Bits per sample
        /// </summary>
        public int BitDepth { get; set; }

        /// <summary>
        /// Predicted sample count based on sample rate and duration
        /// </summary>
        public long PredictedSampleCount { get; set; }

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
        public AudioFormat Format { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="AudioMetadata"/> class
        /// </summary>
        public AudioMetadata() { }
    }
}

