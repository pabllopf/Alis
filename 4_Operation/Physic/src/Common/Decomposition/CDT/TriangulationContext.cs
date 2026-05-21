

using System.Collections.Generic;
using Alis.Core.Physic.Common.Decomposition.CDT.Delaunay;

namespace Alis.Core.Physic.Common.Decomposition.CDT
{
    /// <summary>
    ///     The triangulation context class
    /// </summary>
    internal abstract class TriangulationContext
    {
        /// <summary>
        ///     The triangulation point
        /// </summary>
        public readonly List<TriangulationPoint> Points = new List<TriangulationPoint>(200);

        /// <summary>
        ///     The delaunay triangle
        /// </summary>
        public readonly List<DelaunayTriangle> Triangles = new List<DelaunayTriangle>();

        /// <summary>
        ///     Initializes a new instance of the <see cref="TriangulationContext" /> class
        /// </summary>
        public TriangulationContext() => Terminated = false;

        /// <summary>
        ///     Gets or sets the value of the triangulation mode
        /// </summary>
        public TriangulationMode TriangulationMode { get; protected set; }

        /// <summary>
        ///     Gets or sets the value of the triangulatable
        /// </summary>
        public ITriangulatable Triangulatable { get; internal set; }

        /// <summary>
        ///     Gets the value of the wait until notified
        /// </summary>
        public bool WaitUntilNotified { get; }

        /// <summary>
        ///     Gets or sets the value of the terminated
        /// </summary>
        public bool Terminated { get; set; }

        /// <summary>
        ///     Gets or sets the value of the step count
        /// </summary>
        public int StepCount { get; private set; }

        /// <summary>
        ///     Dones this instance
        /// </summary>
        public void Done()
        {
            StepCount++;
        }

        /// <summary>
        ///     Prepares the triangulation using the specified t
        /// </summary>
        /// <param name="t">The </param>
        public virtual void PrepareTriangulation(ITriangulatable t)
        {
            Triangulatable = t;
            TriangulationMode = t.TriangulationMode;
            t.PrepareTriangulation(this);
        }

        /// <summary>
        ///     News the constraint using the specified a
        /// </summary>
        /// <param name="a">The </param>
        /// <param name="b">The </param>
        /// <returns>The triangulation constraint</returns>
        public abstract TriangulationConstraint NewConstraint(TriangulationPoint a, TriangulationPoint b);

        /// <summary>
        ///     Clears this instance
        /// </summary>
        public virtual void Clear()
        {
            Points.Clear();
            Terminated = false;
            StepCount = 0;
        }
    }
}