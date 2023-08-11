namespace Veldrid.MetalBindings
{
    /// <summary>
    /// The mtl command buffer status enum
    /// </summary>
    public enum MTLCommandBufferStatus
    {
        /// <summary>
        /// The not enqueued mtl command buffer status
        /// </summary>
        NotEnqueued = 0,
        /// <summary>
        /// The enqueued mtl command buffer status
        /// </summary>
        Enqueued = 1,
        /// <summary>
        /// The committed mtl command buffer status
        /// </summary>
        Committed = 2,
        /// <summary>
        /// The scheduled mtl command buffer status
        /// </summary>
        Scheduled = 3,
        /// <summary>
        /// The completed mtl command buffer status
        /// </summary>
        Completed = 4,
        /// <summary>
        /// The error mtl command buffer status
        /// </summary>
        Error = 5,
    }
}