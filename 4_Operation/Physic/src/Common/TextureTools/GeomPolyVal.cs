

namespace Alis.Core.Physic.Common.TextureTools
{
    /// <summary>
    ///     The geom poly val class
    /// </summary>
    internal class GeomPolyVal
    {
        /**
         * Associated polygon at coordinate *
         * Key of original sub-polygon *
         */
        public readonly int Key;

        /// <summary>
        ///     The geom
        /// </summary>
        public MarchingSquares.GeomPoly GeomP;

        /// <summary>
        ///     Initializes a new instance of the <see cref="GeomPolyVal" /> class
        /// </summary>
        /// <param name="geomP">The geom</param>
        /// <param name="k">The </param>
        public GeomPolyVal(MarchingSquares.GeomPoly geomP, int k)
        {
            GeomP = geomP;
            Key = k;
        }
    }
}