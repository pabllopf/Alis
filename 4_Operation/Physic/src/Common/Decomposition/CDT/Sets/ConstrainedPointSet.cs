

using System.Collections.Generic;

namespace Alis.Core.Physic.Common.Decomposition.CDT.Sets
{
    /// <summary>
    ///     The constrained point set class
    /// </summary>
    /// <seealso cref="PointSet" />
    internal class ConstrainedPointSet : PointSet
    {
        /// <summary>
        ///     The constrained point list
        /// </summary>
        internal readonly List<TriangulationPoint> _constrainedPointList;

        /// <summary>
        ///     Initializes a new instance of the <see cref="ConstrainedPointSet" /> class
        /// </summary>
        /// <param name="points">The points</param>
        /// <param name="index">The index</param>
        public ConstrainedPointSet(List<TriangulationPoint> points, int[] index)
            : base(points)
            => EdgeIndex = index;


        /// <summary>
        ///     Initializes a new instance of the <see cref="ConstrainedPointSet" /> class
        /// </summary>
        /// <param name="points">The points</param>
        /// <param name="constraints">The constraints</param>
        public ConstrainedPointSet(List<TriangulationPoint> points, IEnumerable<TriangulationPoint> constraints)
            : base(points)
        {
            _constrainedPointList = new List<TriangulationPoint>();
            _constrainedPointList.AddRange(constraints);
        }

        /// <summary>
        ///     Gets the value of the edge index
        /// </summary>
        public int[] EdgeIndex { get; }

        /// <summary>
        ///     Gets the value of the triangulation mode
        /// </summary>
        public override TriangulationMode TriangulationMode => TriangulationMode.Constrained;

        /// <summary>
        ///     Prepares the triangulation using the specified tcx
        /// </summary>
        /// <param name="tcx">The tcx</param>
        public override void PrepareTriangulation(TriangulationContext tcx)
        {
            base.PrepareTriangulation(tcx);
            if (_constrainedPointList != null)
            {
                TriangulationPoint p1, p2;
                List<TriangulationPoint>.Enumerator iterator = _constrainedPointList.GetEnumerator();
                while (iterator.MoveNext())
                {
                    p1 = iterator.Current;
                    iterator.MoveNext();
                    p2 = iterator.Current;
                    tcx.NewConstraint(p1, p2);
                }
            }
            else
            {
                for (int i = 0; i < EdgeIndex.Length; i += 2)
                {
                    tcx.NewConstraint(GetPoints[EdgeIndex[i]], GetPoints[EdgeIndex[i + 1]]);
                }
            }
        }


    }
}