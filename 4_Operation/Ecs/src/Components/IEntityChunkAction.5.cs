using System;

namespace Alis.Core.Ecs.Components;
public interface IEntityChunkAction<TArg1, TArg2, TArg3, TArg4, TArg5>
{
    /// <summary>
    /// Executes the function
    /// </summary>
    void RunChunk(ReadOnlySpan<Entity> entity, Span<TArg1> arg1, Span<TArg2> arg2, Span<TArg3> arg3, Span<TArg4> arg4, Span<TArg5> arg5);
}