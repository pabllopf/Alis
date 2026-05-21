

//   Replace entire class with HashSet<Polygon> ?

using System.Collections.Generic;

namespace Alis.Core.Physic.Common.Decomposition.CDT.Polygon
{
    /// <summary>
    ///     The polygon set class
    /// </summary>
    internal class PolygonSet
    {
        /// <summary>
        ///     The polygon
        /// </summary>
        protected readonly List<Polygon> Polygons = new List<Polygon>();

        /// <summary>
        ///     Initializes a new instance of the <see cref="PolygonSet" /> class
        /// </summary>
        public PolygonSet()
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="PolygonSet" /> class
        /// </summary>
        /// <param name="poly">The poly</param>
        public PolygonSet(Polygon poly)
        {
            Polygons.Add(poly);
        }

        /// <summary>
        ///     Gets the value of the polygons
        /// </summary>
        public IEnumerable<Polygon> GetPolygons => Polygons;

        /// <summary>
        ///     Adds the p
        /// </summary>
        /// <param name="p">The </param>
        public void Add(Polygon p)
        {
            Polygons.Add(p);
        }
    }
}