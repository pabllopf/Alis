

namespace Alis.Extension.Media.FFmpeg.Encoding.Builders
{
    /// <summary>
    ///     The mp encoder class
    /// </summary>
    /// <seealso cref="EncoderOptionsBuilder" />
    public class Mp3Encoder : EncoderOptionsBuilder
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="Mp3Encoder" /> class
        /// </summary>
        public Mp3Encoder()
        {
            SetCqp();
        }

        /// <summary>
        ///     Set channel count, leave 'null' to match source
        /// </summary>
        public int? ChannelCount { get; set; } = null;

        /// <summary>
        ///     Set sample rate, leave 'null' to match source
        /// </summary>
        public int? SampleRate { get; set; } = null;

        /// <summary>
        ///     Gets or sets the value of the format
        /// </summary>
        public override string Format { get; set; } = "mp3";

        /// <summary>
        ///     Gets the value of the name
        /// </summary>
        public override string Name => "libmp3lame";

        /// <summary>
        ///     Gets or sets the value of the current quality settings
        /// </summary>
        public string CurrentQualitySettings { get; private set; }

        /// <summary>
        ///     Constant bitrate encoding. (This mode is considered wasteful, use CQP instead)
        /// </summary>
        /// <param name="bitrate">Target bitrate (ex: '320k', '250k', ...)</param>
        public void SetCbr(string bitrate)
        {
            CurrentQualitySettings = $"-b:a {bitrate}";
        }

        /// <summary>
        ///     Average bitrate encoding.
        /// </summary>
        /// <param name="avgBitrate">Average target bitrate (ex: '320k', '250k', ...)</param>
        public void SetAbr(string avgBitrate)
        {
            CurrentQualitySettings = $"-b:a {avgBitrate} -abr 1";
        }

        /// <summary>
        ///     Constant quality encoding - VBR mode (0 produces around 240kbps, 1 -> 220kbps, 2 -> 190, ...)
        /// </summary>
        /// <param name="qscale">Number from 0 to 9 (Lower = higher quality)</param>
        public void SetCqp(int qscale = 4)
        {
            CurrentQualitySettings = $"-q:a {qscale}";
        }

        /// <summary>
        ///     Creates this instance
        /// </summary>
        /// <returns>The encoder options</returns>
        public override EncoderOptions Create() => new EncoderOptions
        {
            Format = Format,
            EncoderName = Name,
            EncoderArguments = $"{CurrentQualitySettings}" +
                               (ChannelCount == null ? "" : $" -ac {ChannelCount}") +
                               (SampleRate == null ? "" : $" -ar {SampleRate}")
        };
    }
}