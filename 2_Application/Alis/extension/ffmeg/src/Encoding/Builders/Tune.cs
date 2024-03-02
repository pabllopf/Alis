namespace Alis.Extension.FFMeg.Encoding.Builders
{
    /// <summary>
    /// The tune enum
    /// </summary>
    public enum Tune
    {
        /// <summary>
        /// The auto tune
        /// </summary>
        Auto,
        /// <summary>
        ///  Use for high quality movie content; lowers deblocking 
        /// </summary>
        Film,
        /// <summary>
        /// Good for cartoons; uses higher deblocking and more reference frames 
        /// </summary>
        Animation,
        /// <summary>
        /// Preserves the grain structure in old, grainy film material 
        /// </summary>
        Grain,
        /// <summary>
        /// Good for slideshow-like content 
        /// </summary>
        StillImage,
        /// <summary>
        /// Allows faster decoding by disabling certain filters 
        /// </summary>
        FastDecode,
        /// <summary>
        /// Good for fast encoding and low-latency streaming 
        /// </summary>
        ZeroLatency
    }
}