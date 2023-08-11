namespace Veldrid.MetalBindings
{
    /// <summary>
    /// The mtl store action enum
    /// </summary>
    public enum MTLStoreAction
    {
        /// <summary>
        /// The dont care mtl store action
        /// </summary>
        DontCare = 0,
        /// <summary>
        /// The store mtl store action
        /// </summary>
        Store = 1,
        /// <summary>
        /// The multisample resolve mtl store action
        /// </summary>
        MultisampleResolve = 2,
        /// <summary>
        /// The store and multisample resolve mtl store action
        /// </summary>
        StoreAndMultisampleResolve = 3,
        /// <summary>
        /// The unknown mtl store action
        /// </summary>
        Unknown = 4,
        /// <summary>
        /// The custom sample depth store mtl store action
        /// </summary>
        CustomSampleDepthStore = 5,
    }
}