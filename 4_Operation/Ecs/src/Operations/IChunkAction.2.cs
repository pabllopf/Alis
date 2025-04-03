

using System;

namespace Alis.Core.Ecs.Operations
{
    public interface IChunkAction<TArg1, TArg2>
    {
        /// <summary>
        /// Executes the function
        /// </summary>
        void RunChunk(Span<TArg1> arg1, Span<TArg2> arg2);
    }
}
