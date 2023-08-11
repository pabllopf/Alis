namespace Veldrid.MetalBindings
{
    /// <summary>
    /// The mtl storage mode enum
    /// </summary>
    public enum MTLStorageMode : uint
    {
        /// <summary>
        /// The shared mtl storage mode
        /// </summary>
        Shared = 0,
        /// <summary>
        /// The managed mtl storage mode
        /// </summary>
        Managed = 1,
        /// <summary>
        /// The private mtl storage mode
        /// </summary>
        Private = 2,
        /// <summary>
        /// The memoryless mtl storage mode
        /// </summary>
        Memoryless = 3,
    }
}