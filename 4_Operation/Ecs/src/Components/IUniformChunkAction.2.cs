using System;

namespace Alis.Core.Ecs.Components;
public interface IUniformChunkAction<TUniform, TArg1, TArg2>
{
    /// <summary>
    /// Executes the function
    /// </summary>
    void RunChunk(TUniform uniform, Span<TArg1> arg1, Span<TArg2> arg2);
}