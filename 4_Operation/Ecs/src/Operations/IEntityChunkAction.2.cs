using System;

namespace Alis.Core.Ecs.Operations
{
    public interface IEntityChunkAction<TArg1, TArg2>
    {
        /// <summary>
        /// Executes the function
        /// </summary>
        void RunChunk(ReadOnlySpan<GameObject> entity, Span<TArg1> arg1, Span<TArg2> arg2);
    }
}
