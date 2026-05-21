

using System.Collections.Generic;
using Alis.Core.Physic.Common.Decomposition.CDT.Delaunay.Sweep;

namespace Alis.Core.Physic.Common.Decomposition.CDT
{
    /// <summary>
    ///     The triangulation point class
    /// </summary>
    internal class TriangulationPoint
    {
        // List of edges this point constitutes an upper ending point (CDT)

        /// <summary>
        ///     The
        /// </summary>
        public double X, Y;

        /// <summary>
        ///     Initializes a new instance of the <see cref="TriangulationPoint" /> class
        /// </summary>
        /// <param name="x">The </param>
        /// <param name="y">The </param>
        public TriangulationPoint(double x, double y)
        {
            X = x;
            Y = y;
        }

        /// <summary>
        ///     Gets or sets the value of the edges
        /// </summary>
        public List<DtSweepConstraint> Edges { get; internal set; }

        /// <summary>
        ///     Gets or sets the value of the xf
        /// </summary>
        public float Xf
        {
            get => (float) X;
            set => X = value;
        }

        /// <summary>
        ///     Gets or sets the value of the yf
        /// </summary>
        public float Yf
        {
            get => (float) Y;
            set => Y = value;
        }

        /// <summary>
        ///     Gets the value of the has edges
        /// </summary>
        public bool HasEdges => Edges != null;

        /// <summary>
        ///     Returns the string
        /// </summary>
        /// <returns>The string</returns>
        public override string ToString() => "[" + X + "," + Y + "]";

        /// <summary>
        ///     Adds the edge using the specified e
        /// </summary>
        /// <param name="e">The </param>
        public void AddEdge(DtSweepConstraint e)
        {
            if (Edges == null)
            {
                Edges = new List<DtSweepConstraint>();
            }

            Edges.Add(e);
        }
    }
}