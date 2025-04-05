using System;

namespace Alis.Core.Ecs.Operations
{
    /// <summary>
    ///     An arbitary function that operates over a range of components
    /// </summary>
    /// <remarks>Used for SIMD</remarks>
    public interface IEntityChunkAction<TArg>
    {
        /// <summary>
        ///     Executes the function
        /// </summary>
        void RunChunk(ReadOnlySpan<GameObject> entity, Span<TArg> arg);
    }
}