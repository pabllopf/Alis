using System;
using System.Runtime.InteropServices;

namespace Alis.Core.Ecs.Operations
{
    /// <summary>
    ///     The chunk tuple
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public ref struct ChunkTuple<T>
    {
        /// <summary>
        ///     The entities
        /// </summary>
        public EntityEnumerator.EntityEnumerable Entities;

        /// <summary>
        ///     The span
        /// </summary>
        public Span<T> Span;

        /// <summary>
        ///     Deconstructs the comp 1
        /// </summary>
        /// <param name="comp1">The comp</param>
        public void Deconstruct(out Span<T> comp1)
        {
            comp1 = Span;
        }
    }
}