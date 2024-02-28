using CryMediaAPI.Audio.Models;
using CryMediaAPI.BaseClasses;

using System.Linq;
using System.Text.Json.Serialization;

namespace CryMediaAPI.Video.Models;

// prepare for source generation
/// <summary>

/// The source generation context class

/// </summary>

/// <seealso cref="JsonSerializerContext"/>

[JsonSourceGenerationOptions(WriteIndented = true)]
[JsonSerializable(typeof(VideoMetadata))]
[JsonSerializable(typeof(AudioMetadata))]
internal partial class SourceGenerationContext : JsonSerializerContext {}

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
    /// Average video framerate in frequency format
    /// </summary>
    public string AvgFramerateText { get; set; }

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

/// <summary>

/// The video format tags class

/// </summary>

public class VideoFormatTags
{
    /// <summary>
    /// Gets or sets the value of the major brand
    /// </summary>
    [JsonPropertyName("major_brand")]
    public string MajorBrand { get; set; }

    /// <summary>
    /// Gets or sets the value of the minor version
    /// </summary>
    [JsonPropertyName("minor_version")]
    public string MinorVersion { get; set; }

    /// <summary>
    /// Gets or sets the value of the compatible brands
    /// </summary>
    [JsonPropertyName("compatible_brands")]
    public string CompatibleBrands { get; set; }

    /// <summary>
    /// Gets or sets the value of the creation time
    /// </summary>
    [JsonPropertyName("creation_time")]
    public string CreationTime { get; set; }

    /// <summary>
    /// Gets or sets the value of the encoder
    /// </summary>
    [JsonPropertyName("encoder")]
    public string Encoder { get; set; }
}