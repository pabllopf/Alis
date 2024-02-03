using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace Alis.Core.Aspect.Data.Json
{
    /// <summary>
    ///     A utility class to compare object by their reference.
    /// </summary>
    public sealed class ReferenceComparer : IEqualityComparer<object>
    {
        /// <summary>
        ///     Gets the instance of the ReferenceComparer class.
        /// </summary>
        public static readonly ReferenceComparer Instance = new ReferenceComparer();

        /// <summary>
        ///     Initializes a new instance of the <see cref="ReferenceComparer" /> class
        /// </summary>
        internal ReferenceComparer()
        {
        }

        /// <summary>
        ///     Describes whether this instance equals
        /// </summary>
        /// <param name="x">The </param>
        /// <param name="y">The </param>
        /// <returns>The bool</returns>
        bool IEqualityComparer<object>.Equals(object x, object y) => ReferenceEquals(x, y);

        /// <summary>
        ///     Gets the hash code using the specified obj
        /// </summary>
        /// <param name="obj">The obj</param>
        /// <returns>The int</returns>
        int IEqualityComparer<object>.GetHashCode(object obj) => RuntimeHelpers.GetHashCode(obj);
    }
}