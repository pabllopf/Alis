using System;

namespace Alis.Core.Ecs.Operations
{
    public interface IEntityChunkAction<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>
    {
        /// <summary>
        /// Executes the function
        /// </summary>
        void RunChunk(ReadOnlySpan<GameObject> entity, Span<TArg1> arg1, Span<TArg2> arg2, Span<TArg3> arg3, Span<TArg4> arg4, Span<TArg5> arg5, Span<TArg6> arg6);
    }
}
