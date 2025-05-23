using System;

namespace Alis.Core.Ecs.Core.Memory
{
    /// <summary>
    ///     Specifies the level of memory trimming Alis internal buffers should do
    /// </summary>
    [Obsolete("I may or may not use this in the future.")]
    public enum MemoryTrimming
    {
        /// <summary>
        ///     Always trim buffers when there is memory pressure
        /// </summary>
        Always = 0,

        /// <summary>
        ///     Trim buffers a balanced amount
        /// </summary>
        Normal = 1,

        /// <summary>
        ///     Never trim buffers, even when there is memory pressure
        /// </summary>
        Never = 2
    }
}