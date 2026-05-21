

using System;

namespace Alis.Core.Aspect.Math.Collections
{
    /// <summary>
    ///     Internal interface for accessing an untyped reference to the underlying array of a <see cref="FastImmutableArray{T}" />.
    /// </summary>
    internal interface IFastImmutableArray
    {
        /// <summary>
        ///     Gets an untyped reference to the underlying array.
        /// </summary>
        Array Array { get; }
    }
}
