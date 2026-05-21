

using System;

namespace Alis.Core.Ecs.Generator.Collections
{
    /// <summary>
    ///     The fast immutable array interface
    /// </summary>
    internal interface IFastImmutableArray
    {
        /// <summary>
        ///     Gets an untyped reference to the array.
        /// </summary>
        Array Array { get; }
    }
}