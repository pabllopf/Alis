namespace Alis.Extension.FFMeg.Encoding.Builders
{
    /// <summary>
    /// The profile enum
    /// </summary>
    public enum Profile
    {
        /// <summary>
        /// Automatically pick the appropriate profile
        /// </summary>
        Auto,
        /// <summary>
        /// Maximum compatibility on older devices. Least demanding.
        /// </summary>
        Baseline,
        /// <summary>
        /// Good compatibility even on older devices
        /// </summary>
        Main,
        /// <summary>
        /// Supported by most modern devices
        /// </summary>
        High,
        /// <summary>
        /// Support for 10-bit depth
        /// </summary>
        High10,
        /// <summary>
        /// Support for 4:2:2 chroma subsampling
        /// </summary>
        High442,
        /// <summary>
        /// Support for 4:4:4 chroma subsampling
        /// </summary>
        High444
    }
}