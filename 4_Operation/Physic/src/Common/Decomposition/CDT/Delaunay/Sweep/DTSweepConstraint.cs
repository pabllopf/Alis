

using System;

namespace Alis.Core.Physic.Common.Decomposition.CDT.Delaunay.Sweep
{
    /// <summary>
    ///     The dt sweep constraint class
    /// </summary>
    /// <seealso cref="TriangulationConstraint" />
    internal class DtSweepConstraint : TriangulationConstraint
    {
        /// <summary>
        ///     Give two points in any order. Will always be ordered so
        ///     that q.y > p.y and q.x > p.x if same y value
        /// </summary>
        public DtSweepConstraint(TriangulationPoint p1, TriangulationPoint p2)
        {
            P = p1;
            Q = p2;
            if (p1.Y > p2.Y)
            {
                Q = p1;
                P = p2;
            }
            else if (Math.Abs(p1.Y - p2.Y) < float.Epsilon)
            {
                if (p1.X > p2.X)
                {
                    Q = p1;
                    P = p2;
                }
                else if (Math.Abs(p1.X - p2.X) < float.Epsilon)
                {
                }
            }

            Q.AddEdge(this);
        }
    }
}