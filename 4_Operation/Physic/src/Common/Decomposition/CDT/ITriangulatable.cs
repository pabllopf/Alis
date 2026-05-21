

using System.Collections.Generic;
using Alis.Core.Physic.Common.Decomposition.CDT.Delaunay;

namespace Alis.Core.Physic.Common.Decomposition.CDT
{
    /// <summary>
    ///     The triangulatable interface
    /// </summary>
    internal interface ITriangulatable
    {
        /// <summary>
        ///     Gets the value of the points
        /// </summary>
        IList<TriangulationPoint> GetPoints { get; } // MM: Neither of these are used via interface (yet?)

        /// <summary>
        ///     Gets the value of the triangles
        /// </summary>
        IList<DelaunayTriangle> GetTriangles { get; }

        /// <summary>
        ///     Gets the value of the triangulation mode
        /// </summary>
        TriangulationMode TriangulationMode { get; }

        /// <summary>
        ///     Prepares the triangulation using the specified tcx
        /// </summary>
        /// <param name="tcx">The tcx</param>
        void PrepareTriangulation(TriangulationContext tcx);

        /// <summary>
        ///     Adds the triangle using the specified t
        /// </summary>
        /// <param name="t">The </param>
        void AddTriangle(DelaunayTriangle t);

        /// <summary>
        ///     Adds the triangles using the specified list
        /// </summary>
        /// <param name="list">The list</param>
        void AddTriangles(IEnumerable<DelaunayTriangle> list);

        /// <summary>
        ///     Clears the triangles
        /// </summary>
        void ClearTriangles();
    }
}