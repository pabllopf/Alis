using System;

namespace Alis.Core.Ecs.Systems
{
    /// <summary>
    ///     An arbitary function that operates over a range of components
    /// </summary>
    /// <remarks>Used for SIMD</remarks>
    public interface IChunkAction<TArg>
    {
        /// <summary>
        ///     Executes the function
        /// </summary>
        void RunChunk(Span<TArg> arg);
    }
}