namespace Alis.Core.Extension.FFMeg.Encoding.Builders
{
    /// <summary>
    /// The aac encoder class
    /// </summary>
    /// <seealso cref="EncoderOptionsBuilder"/>
    public class AACEncoder : EncoderOptionsBuilder
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
        public override string Format { get; set; } = "m4a";
        /// <summary>
        /// Gets the value of the name
        /// </summary>
        public override string Name => "aac";
        /// <summary>
        /// Gets or sets the value of the current quality settings
        /// </summary>
        public string CurrentQualitySettings { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="AACEncoder"/> class
        /// </summary>
        public AACEncoder()
    {
        SetCBR();
    }

        /// <summary>
        /// Constant bitrate encoding
        /// </summary>
        /// <param name="bitrate">Target bitrate (ex: '320k', '128k', ...)</param>
        public void SetCBR(string bitrate = "128k")
    {
        CurrentQualitySettings = $"-b:a {bitrate}";
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
}
