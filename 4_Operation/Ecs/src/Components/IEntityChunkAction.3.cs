using System;

namespace Alis.Core.Ecs.Components;
public interface IEntityChunkAction<TArg1, TArg2, TArg3>
{
    /// <summary>
    /// Executes the function
    /// </summary>
    void RunChunk(ReadOnlySpan<Entity> entity, Span<TArg1> arg1, Span<TArg2> arg2, Span<TArg3> arg3);
}