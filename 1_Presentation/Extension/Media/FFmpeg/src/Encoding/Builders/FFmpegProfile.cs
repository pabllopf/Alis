

namespace Alis.Extension.Media.FFmpeg.Encoding.Builders
{
    /// <summary>
    ///     The profile enum
    /// </summary>
    public enum FFmpegProfile
    {
        /// <summary>
        ///     Automatically pick the appropriate profile
        /// </summary>
        Auto = 0,

        /// <summary>
        ///     Maximum compatibility on older devices. Least demanding.
        /// </summary>
        Baseline = 1,

        /// <summary>
        ///     Good compatibility even on older devices
        /// </summary>
        Main = 2,

        /// <summary>
        ///     Supported by most modern devices
        /// </summary>
        High = 3,

        /// <summary>
        ///     Support for 10-bit depth
        /// </summary>
        High10 = 4,

        /// <summary>
        ///     Support for 4:2:2 chroma subsampling
        /// </summary>
        High442 = 5,

        /// <summary>
        ///     Support for 4:4:4 chroma subsampling
        /// </summary>
        High444 = 6
    }
}