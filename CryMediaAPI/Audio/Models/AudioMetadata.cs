using CryMediaAPI.BaseClasses;

using System.Linq;
using System.Text.Json.Serialization;

namespace CryMediaAPI.Audio.Models;

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
/// <summary>
 /// The audio format class
 /// </summary>
 public class AudioFormat
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
}

/// <summary>

/// The tags class

/// </summary>

public class Tags
{
    /// <summary>
    /// Gets or sets the value of the encoder
    /// </summary>
    [JsonPropertyName("encoder")]
    public string Encoder { get; set; }
}

