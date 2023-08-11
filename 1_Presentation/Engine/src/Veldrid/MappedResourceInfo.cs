namespace Veldrid
{
    /// <summary>
    /// The mapped resource info
    /// </summary>
    internal struct MappedResourceInfo
    {
        /// <summary>
        /// The ref count
        /// </summary>
        public int RefCount;
        /// <summary>
        /// The mode
        /// </summary>
        public MapMode Mode;
        /// <summary>
        /// The mapped resource
        /// </summary>
        public MappedResource MappedResource;
    }
}
