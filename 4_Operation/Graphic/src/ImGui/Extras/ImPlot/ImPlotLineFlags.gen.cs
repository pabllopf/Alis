namespace ImPlotNET
{
    /// <summary>
    /// The im plot line flags enum
    /// </summary>
    [System.Flags]
    public enum ImPlotLineFlags
    {
        /// <summary>
        /// The none im plot line flags
        /// </summary>
        None = 0,
        /// <summary>
        /// The segments im plot line flags
        /// </summary>
        Segments = 1024,
        /// <summary>
        /// The loop im plot line flags
        /// </summary>
        Loop = 2048,
        /// <summary>
        /// The skip na im plot line flags
        /// </summary>
        SkipNaN = 4096,
        /// <summary>
        /// The no clip im plot line flags
        /// </summary>
        NoClip = 8192,
        /// <summary>
        /// The shaded im plot line flags
        /// </summary>
        Shaded = 16384,
    }
}
