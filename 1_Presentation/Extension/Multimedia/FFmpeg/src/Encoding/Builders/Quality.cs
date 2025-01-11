namespace Alis.Extension.Multimedia.FFmpeg.Encoding.Builders
{
    /// <summary>
    ///     The quality enum
    /// </summary>
    public enum Quality
    {
        /// <summary>
        ///     Default and recommended for most applications
        /// </summary>
        Good = 0,

        /// <summary>
        ///     Recommended if you have lots of time and want the best compression efficiency.
        /// </summary>
        Best = 1,

        /// <summary>
        ///     Recommended for live/fast encoding.
        /// </summary>
        RealTime = 2
    }
}