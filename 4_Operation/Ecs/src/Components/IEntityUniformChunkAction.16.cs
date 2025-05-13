using System;

namespace Alis.Core.Ecs.Components;
public interface IEntityUniformChunkAction<TUniform, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15, TArg16>
{
    /// <summary>
    /// Executes the function
    /// </summary>
    void RunChunk(ReadOnlySpan<Entity> entity, TUniform uniform, Span<TArg1> arg1, Span<TArg2> arg2, Span<TArg3> arg3, Span<TArg4> arg4, Span<TArg5> arg5, Span<TArg6> arg6, Span<TArg7> arg7, Span<TArg8> arg8, Span<TArg9> arg9, Span<TArg10> arg10, Span<TArg11> arg11, Span<TArg12> arg12, Span<TArg13> arg13, Span<TArg14> arg14, Span<TArg15> arg15, Span<TArg16> arg16);
}