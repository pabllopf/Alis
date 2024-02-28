using System.Globalization;

namespace CryMediaAPI.Encoding.Builders;

/// <summary>

/// The vorbis encoder class

/// </summary>

/// <seealso cref="EncoderOptionsBuilder"/>

public class VorbisEncoder : EncoderOptionsBuilder
{
    /// <summary>
    /// Set channel count, leave 'null' to match source
    /// </summary>
    public int? ChannelCount { get; set; } = null;
    /// <summary>
    /// Set sample rate, leave 'null' to match source
    /// </summary>
    public int? SampleRate { get; set; } = null;

    /// <summary>
    /// Gets or sets the value of the format
    /// </summary>
    public override string Format { get; set; } = "ogg";
    /// <summary>
    /// Gets the value of the name
    /// </summary>
    public override string Name => "libvorbis";
    /// <summary>
    /// Gets or sets the value of the current quality settings
    /// </summary>
    public string CurrentQualitySettings { get; private set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="VorbisEncoder"/> class
    /// </summary>
    public VorbisEncoder()
    {
        SetCQP();
    }

    /// <summary>
    /// Constant bitrate encoding.
    /// </summary>
    /// <param name="bitrate">Target bitrate (ex: '320k', '250k', ...)</param>
    public void SetCBR(string bitrate)
    {
        CurrentQualitySettings = $"-b:a {bitrate}";
    }

    /// <summary>
    /// Constant quality encoding - VBR mode
    /// </summary>
    /// <param name="q">Float number from -1 to 10 (Higher = higher quality)</param>
    public void SetCQP(float q = 3)
    {
        CurrentQualitySettings = $"-q:a {q.ToString("0.00", CultureInfo.InvariantCulture)}";
    }

    /// <summary>
    /// Creates this instance
    /// </summary>
    /// <returns>The encoder options</returns>
    public override EncoderOptions Create()
    {
        return new EncoderOptions
        {
            Format = Format,
            EncoderName = Name,
            EncoderArguments = $"{CurrentQualitySettings}" +
                (ChannelCount == null ? "" : $" -ac {ChannelCount}") +
                (SampleRate == null ? "" : $" -ar {SampleRate}")
        };
    }
}
