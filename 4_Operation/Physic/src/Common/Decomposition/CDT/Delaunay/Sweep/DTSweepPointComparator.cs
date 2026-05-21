

using System.Collections.Generic;

namespace Alis.Core.Physic.Common.Decomposition.CDT.Delaunay.Sweep
{
    /// <summary>
    ///     The dt sweep point comparator class
    /// </summary>
    /// <seealso cref="IComparer{TriangulationPoint}" />
    internal class DtSweepPointComparator : IComparer<TriangulationPoint>
    {
        /// <summary>
        ///     Compares the p 1
        /// </summary>
        /// <param name="p1">The </param>
        /// <param name="p2">The </param>
        /// <returns>The int</returns>
        public int Compare(TriangulationPoint p1, TriangulationPoint p2)
        {
            if (p1.Y < p2.Y)
            {
                return -1;
            }

            if (p1.Y > p2.Y)
            {
                return 1;
            }

            if (p1.X < p2.X)
            {
                return -1;
            }

            if (p1.X > p2.X)
            {
                return 1;
            }

            return 0;
        }
    }
}