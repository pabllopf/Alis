namespace Veldrid.Vk
{
    /// <summary>
    /// The descriptor resource counts
    /// </summary>
    internal struct DescriptorResourceCounts
    {
        /// <summary>
        /// The uniform buffer count
        /// </summary>
        public readonly uint UniformBufferCount;
        /// <summary>
        /// The sampled image count
        /// </summary>
        public readonly uint SampledImageCount;
        /// <summary>
        /// The sampler count
        /// </summary>
        public readonly uint SamplerCount;
        /// <summary>
        /// The storage buffer count
        /// </summary>
        public readonly uint StorageBufferCount;
        /// <summary>
        /// The storage image count
        /// </summary>
        public readonly uint StorageImageCount;
        /// <summary>
        /// The uniform buffer dynamic count
        /// </summary>
        public readonly uint UniformBufferDynamicCount;
        /// <summary>
        /// The storage buffer dynamic count
        /// </summary>
        public readonly uint StorageBufferDynamicCount;

        /// <summary>
        /// Initializes a new instance of the <see cref="DescriptorResourceCounts"/> class
        /// </summary>
        /// <param name="uniformBufferCount">The uniform buffer count</param>
        /// <param name="uniformBufferDynamicCount">The uniform buffer dynamic count</param>
        /// <param name="sampledImageCount">The sampled image count</param>
        /// <param name="samplerCount">The sampler count</param>
        /// <param name="storageBufferCount">The storage buffer count</param>
        /// <param name="storageBufferDynamicCount">The storage buffer dynamic count</param>
        /// <param name="storageImageCount">The storage image count</param>
        public DescriptorResourceCounts(
            uint uniformBufferCount,
            uint uniformBufferDynamicCount,
            uint sampledImageCount,
            uint samplerCount,
            uint storageBufferCount,
            uint storageBufferDynamicCount,
            uint storageImageCount)
        {
            UniformBufferCount = uniformBufferCount;
            UniformBufferDynamicCount = uniformBufferDynamicCount;
            SampledImageCount = sampledImageCount;
            SamplerCount = samplerCount;
            StorageBufferCount = storageBufferCount;
            StorageBufferDynamicCount = storageBufferDynamicCount;
            StorageImageCount = storageImageCount;
        }
    }
}
