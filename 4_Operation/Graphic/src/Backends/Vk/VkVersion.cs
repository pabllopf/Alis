namespace Alis.Core.Graphic.Backends.Vk
{
    /// <summary>
    /// The vk version
    /// </summary>
    internal struct VkVersion
    {
        /// <summary>
        /// The value
        /// </summary>
        private readonly uint value;

        /// <summary>
        /// Initializes a new instance of the <see cref="VkVersion"/> class
        /// </summary>
        /// <param name="major">The major</param>
        /// <param name="minor">The minor</param>
        /// <param name="patch">The patch</param>
        public VkVersion(uint major, uint minor, uint patch)
        {
            value = major << 22 | minor << 12 | patch;
        }

        /// <summary>
        /// Gets the value of the major
        /// </summary>
        public uint Major => value >> 22;

        /// <summary>
        /// Gets the value of the minor
        /// </summary>
        public uint Minor => (value >> 12) & 0x3ff;

        /// <summary>
        /// Gets the value of the patch
        /// </summary>
        public uint Patch => (value >> 22) & 0xfff;

        public static implicit operator uint(VkVersion version)
        {
            return version.value;
        }
    }
}
