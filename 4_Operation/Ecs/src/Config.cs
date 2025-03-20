namespace Alis.Core.Ecs
{
    /// <summary>
    /// Config information for a <see cref="World"/>.
    /// </summary>
    public class Config
    {
        /// <summary>
        /// Whether or not to multithread.
        /// </summary>
#if NET7_0_OR_GREATER
        public bool MultiThreadedUpdate { get; init; }
#else
        public bool MultiThreadedUpdate { get; set; }
#endif
        

        /// <summary>
        /// The default multithreaded config.
        /// </summary>
        public static Config Multithreaded { get; } = new Config() { MultiThreadedUpdate = true };
        /// <summary>
        /// The default singlethreaded config.
        /// </summary>
        public static Config Singlethreaded { get; } = new Config() { MultiThreadedUpdate = false };
    }
}
