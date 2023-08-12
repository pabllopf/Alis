namespace Alis.Core.Graphic.Backends.Metal
{
    /// <summary>
    /// The mtl resource options enum
    /// </summary>
    public enum MTLResourceOptions : uint
    {
        /// <summary>
        /// The cpu cache mode default cache mtl resource options
        /// </summary>
        CPUCacheModeDefaultCache = MTLCPUCacheMode.DefaultCache,
        /// <summary>
        /// The cpu cache mode write combined mtl resource options
        /// </summary>
        CPUCacheModeWriteCombined = MTLCPUCacheMode.WriteCombined,

        /// <summary>
        /// The storage mode shared mtl resource options
        /// </summary>
        StorageModeShared = MTLStorageMode.Shared << 4,
        /// <summary>
        /// The storage mode managed mtl resource options
        /// </summary>
        StorageModeManaged = MTLStorageMode.Managed << 4,
        /// <summary>
        /// The storage mode private mtl resource options
        /// </summary>
        StorageModePrivate = MTLStorageMode.Private << 4,
        /// <summary>
        /// The storage mode memoryless mtl resource options
        /// </summary>
        StorageModeMemoryless = MTLStorageMode.Memoryless << 4,

        /// <summary>
        /// The hazard tracking mode untracked mtl resource options
        /// </summary>
        HazardTrackingModeUntracked = (uint)(0x1UL << 8),
    }
}