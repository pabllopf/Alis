

using System.Collections.Generic;
using Alis.Core.Physic.Common.Decomposition.CDT.Delaunay;

namespace Alis.Core.Physic.Common.Decomposition.CDT.Sets
{
    /// <summary>
    ///     The point set class
    /// </summary>
    /// <seealso cref="ITriangulatable" />
    internal class PointSet : ITriangulatable
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="PointSet" /> class
        /// </summary>
        /// <param name="points">The points</param>
        public PointSet(List<TriangulationPoint> points) => GetPoints = new List<TriangulationPoint>(points);


        /// <summary>
        ///     Gets the value of the points
        /// </summary>
        public IList<TriangulationPoint> GetPoints { get; }

        /// <summary>
        ///     Gets or sets the value of the triangles
        /// </summary>
        public IList<DelaunayTriangle> GetTriangles { get; internal set; }

        /// <summary>
        ///     Gets the value of the triangulation mode
        /// </summary>
        public virtual TriangulationMode TriangulationMode => TriangulationMode.Unconstrained;

        /// <summary>
        ///     Adds the triangle using the specified t
        /// </summary>
        /// <param name="t">The </param>
        public void AddTriangle(DelaunayTriangle t)
        {
            GetTriangles.Add(t);
        }

        /// <summary>
        ///     Adds the triangles using the specified list
        /// </summary>
        /// <param name="list">The list</param>
        public void AddTriangles(IEnumerable<DelaunayTriangle> list)
        {
            foreach (DelaunayTriangle tri in list)
            {
                GetTriangles.Add(tri);
            }
        }

        /// <summary>
        ///     Clears the triangles
        /// </summary>
        public void ClearTriangles()
        {
            GetTriangles.Clear();
        }

        /// <summary>
        ///     Prepares the triangulation using the specified tcx
        /// </summary>
        /// <param name="tcx">The tcx</param>
        public virtual void PrepareTriangulation(TriangulationContext tcx)
        {
            if (GetTriangles == null)
            {
                GetTriangles = new List<DelaunayTriangle>(GetPoints.Count);
            }
            else
            {
                GetTriangles.Clear();
            }

            tcx.Points.AddRange(GetPoints);
        }
    }
}