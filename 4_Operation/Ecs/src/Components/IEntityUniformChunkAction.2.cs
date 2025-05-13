using System;

namespace Alis.Core.Ecs.Components;
public interface IEntityUniformChunkAction<TUniform, TArg1, TArg2>
{
    /// <summary>
    /// Executes the function
    /// </summary>
    void RunChunk(ReadOnlySpan<Entity> entity, TUniform uniform, Span<TArg1> arg1, Span<TArg2> arg2);
}