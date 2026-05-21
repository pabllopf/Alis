

namespace Alis.Extension.Media.FFmpeg.Encoding.Builders
{
    /// <summary>
    ///     The tune enum
    /// </summary>
    public enum Tune
    {
        /// <summary>
        ///     The auto tune
        /// </summary>
        Auto = 0,

        /// <summary>
        ///     Use for high quality movie content; lowers deblocking
        /// </summary>
        Film = 1,

        /// <summary>
        ///     Good for cartoons; uses higher deblocking and more reference frames
        /// </summary>
        Animation = 2,

        /// <summary>
        ///     Preserves the grain structure in old, grainy film material
        /// </summary>
        Grain = 3,

        /// <summary>
        ///     Good for slideshow-like content
        /// </summary>
        StillImage = 4,

        /// <summary>
        ///     Allows faster decoding by disabling certain filters
        /// </summary>
        FastDecode = 5,

        /// <summary>
        ///     Good for fast encoding and low-latency streaming
        /// </summary>
        ZeroLatency = 6
    }
}