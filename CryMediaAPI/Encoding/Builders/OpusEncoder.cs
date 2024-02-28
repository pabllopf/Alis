namespace CryMediaAPI.Encoding.Builders;

/// <summary>

/// The opus encoder class

/// </summary>

/// <seealso cref="EncoderOptionsBuilder"/>

public class OpusEncoder : EncoderOptionsBuilder
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
    /// Set intended application type. (Default: audio)
    /// </summary>
    public Application CodecApplication { get; set; } = Application.Audio;
    /// <summary>
    /// Set encoding algorithm complexity (0-10, 10 gives highest quality but is slowest). (Default: 10)
    /// </summary>
    public int CompressionLevel { get; set; } = 10;

    /// <summary>
    /// Gets or sets the value of the format
    /// </summary>
    public override string Format { get; set; } = "ogg";
    /// <summary>
    /// Gets the value of the name
    /// </summary>
    public override string Name => "libopus";
    /// <summary>
    /// Gets or sets the value of the current quality settings
    /// </summary>
    public string CurrentQualitySettings { get; private set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="OpusEncoder"/> class
    /// </summary>
    public OpusEncoder()
    {
        SetVBR();
    }

    /// <summary>
    /// Constant bitrate encoding.
    /// </summary>
    /// <param name="bitrate">Target bitrate (ex: '320k', '250k', ...)</param>
    public void SetCBR(string bitrate)
    {
        CurrentQualitySettings = $"-b:a {bitrate} -vbr off";
    }

    /// <summary>
    /// Average bitrate encoding. (Default)
    /// </summary>
    /// <param name="bitrate">Target bitrate (ex: '320k', '250k', ...)</param>
    public void SetVBR(string bitrate = "128k")
    {
        CurrentQualitySettings = $"-b:a {bitrate} -vbr on";
    }

    /// <summary>
    /// Constrained VBR encoding
    /// </summary>
    /// <param name="bitrate">Target bitrate (ex: '320k', '250k', ...)</param>
    public void SetCVBR(string bitrate = "128k")
    {
        CurrentQualitySettings = $"-b:a {bitrate} -vbr constrained";
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
            EncoderArguments = $"{CurrentQualitySettings} " +
                $"-application {CodecApplication.ToString().ToLowerInvariant()} " +
                $"-compression_level {CompressionLevel}" +
                (ChannelCount == null ? "" : $" -ac {ChannelCount}") +
                (SampleRate == null ? "" : $" -ar {SampleRate}")
        };
    }

    /// <summary>
    /// The application enum
    /// </summary>
    public enum Application
    {
        /// <summary>
        /// Favor improved speech intelligibility.
        /// </summary>
        VoIP,
        /// <summary>
        /// Favor faithfulness to the input
        /// </summary>
        Audio,
        /// <summary>
        /// Restrict to only the lowest delay modes. 
        /// </summary>
        LowDelay
    }
}
