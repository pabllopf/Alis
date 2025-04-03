using System;

namespace Alis.Core.Ecs.Operations
{
    /// <summary>
    ///     An arbitary function that operates over a range of components
    /// </summary>
    /// <remarks>Used for SIMD</remarks>
    public interface IUniformChunkAction<TUniform, TArg>
    {
        /// <summary>
        ///     Executes the function
        /// </summary>
        void RunChunk(TUniform uniform, Span<TArg> arg);
    }
}