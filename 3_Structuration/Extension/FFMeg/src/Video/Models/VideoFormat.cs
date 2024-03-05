using Alis.Core.Aspect.Data.Json;

namespace Alis.Core.Extension.FFMeg.Video.Models
{
    /// <summary>

    /// The video format class

    /// </summary>

    public class VideoFormat
    {
        /// <summary>
        /// Gets or sets the value of the filename
        /// </summary>
        [JsonPropertyName("filename")]
        public string Filename { get; set; }

        /// <summary>
        /// Gets or sets the value of the nb streams
        /// </summary>
        [JsonPropertyName("nb_streams")]
        public long NbStreams { get; set; }

        /// <summary>
        /// Gets or sets the value of the nb programs
        /// </summary>
        [JsonPropertyName("nb_programs")]
        public long NbPrograms { get; set; }

        /// <summary>
        /// Gets or sets the value of the format name
        /// </summary>
        [JsonPropertyName("format_name")]
        public string FormatName { get; set; }

        /// <summary>
        /// Gets or sets the value of the format long name
        /// </summary>
        [JsonPropertyName("format_long_name")]
        public string FormatLongName { get; set; }

        /// <summary>
        /// Gets or sets the value of the start time
        /// </summary>
        [JsonPropertyName("start_time")]
        public string StartTime { get; set; }

        /// <summary>
        /// Gets or sets the value of the duration
        /// </summary>
        [JsonPropertyName("duration")]
        public string Duration { get; set; }

        /// <summary>
        /// Gets or sets the value of the size
        /// </summary>
        [JsonPropertyName("size")]
        public string Size { get; set; }

        /// <summary>
        /// Gets or sets the value of the bit rate
        /// </summary>
        [JsonPropertyName("bit_rate")]
        public string BitRate { get; set; }

        /// <summary>
        /// Gets or sets the value of the probe score
        /// </summary>
        [JsonPropertyName("probe_score")]
        public long ProbeScore { get; set; }

        /// <summary>
        /// Gets or sets the value of the tags
        /// </summary>
        [JsonPropertyName("tags")]
        public VideoFormatTags Tags { get; set; }
    }
}