using System.Collections.Generic;
using Alis.Core.Aspect.Math.Vector;

namespace Alis.Core.Physic.Common.ConvexHull
{
    /// <summary>
    ///     The point comparer class
    /// </summary>
    /// <seealso cref="Comparer{Vector2F}" />
    internal class PointComparer : Comparer<Vector2F>
    {
        /// <summary>
        ///     Compares the a
        /// </summary>
        /// <param name="a">The </param>
        /// <param name="b">The </param>
        /// <returns>The int</returns>
        public override int Compare(Vector2F a, Vector2F b)
        {
            int f = a.X.CompareTo(b.X);
            return f != 0 ? f : a.Y.CompareTo(b.Y);
        }
    }
}