using System;

namespace Alis.Core.Ecs.Components;
public interface IUniformChunkAction<TUniform, TArg1, TArg2, TArg3, TArg4, TArg5>
{
    /// <summary>
    /// Executes the function
    /// </summary>
    void RunChunk(TUniform uniform, Span<TArg1> arg1, Span<TArg2> arg2, Span<TArg3> arg3, Span<TArg4> arg4, Span<TArg5> arg5);
}