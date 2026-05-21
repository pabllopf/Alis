

using Alis.Core.Physic.Common.TextureTools;
using Xunit;

namespace Alis.Core.Physic.Test.Common.TextureTools
{
    /// <summary>
    ///     The geom poly val test class
    /// </summary>
    public class GeomPolyValTest
    {
        /// <summary>
        ///     Tests that constructor should initialize with parameters
        /// </summary>
        [Fact]
        public void Constructor_ShouldInitializeWithParameters()
        {
            MarchingSquares.GeomPoly geomPoly = new MarchingSquares.GeomPoly();
            int key = 42;

            GeomPolyVal geomPolyVal = new GeomPolyVal(geomPoly, key);

            Assert.NotNull(geomPolyVal);
            Assert.Equal(key, geomPolyVal.Key);
            Assert.Equal(geomPoly, geomPolyVal.GeomP);
        }

        /// <summary>
        ///     Tests that key property should be readonly and set through constructor
        /// </summary>
        [Fact]
        public void KeyProperty_ShouldBeReadonlyAndSetThroughConstructor()
        {
            int key = 100;
            GeomPolyVal geomPolyVal = new GeomPolyVal(new MarchingSquares.GeomPoly(), key);

            Assert.Equal(100, geomPolyVal.Key);
        }

        /// <summary>
        ///     Tests that geom p property should set and get correctly
        /// </summary>
        [Fact]
        public void GeomPProperty_ShouldSetAndGetCorrectly()
        {
            MarchingSquares.GeomPoly geomPoly1 = new MarchingSquares.GeomPoly();
            MarchingSquares.GeomPoly geomPoly2 = new MarchingSquares.GeomPoly();
            GeomPolyVal geomPolyVal = new GeomPolyVal(geomPoly1, 1);

            geomPolyVal.GeomP = geomPoly2;

            Assert.Equal(geomPoly2, geomPolyVal.GeomP);
        }

        /// <summary>
        ///     Tests that constructor should handle null geom poly
        /// </summary>
        [Fact]
        public void Constructor_ShouldHandleNullGeomPoly()
        {
            GeomPolyVal geomPolyVal = new GeomPolyVal(null, 5);

            Assert.Null(geomPolyVal.GeomP);
            Assert.Equal(5, geomPolyVal.Key);
        }

        /// <summary>
        ///     Tests that constructor should handle negative key
        /// </summary>
        [Fact]
        public void Constructor_ShouldHandleNegativeKey()
        {
            GeomPolyVal geomPolyVal = new GeomPolyVal(new MarchingSquares.GeomPoly(), -10);

            Assert.Equal(-10, geomPolyVal.Key);
        }

        /// <summary>
        ///     Tests that constructor should handle zero key
        /// </summary>
        [Fact]
        public void Constructor_ShouldHandleZeroKey()
        {
            GeomPolyVal geomPolyVal = new GeomPolyVal(new MarchingSquares.GeomPoly(), 0);

            Assert.Equal(0, geomPolyVal.Key);
        }

        /// <summary>
        ///     Tests that geom poly val should allow geom p reassignment
        /// </summary>
        [Fact]
        public void GeomPolyVal_ShouldAllowGeomPReassignment()
        {
            MarchingSquares.GeomPoly geomPoly1 = new MarchingSquares.GeomPoly();
            MarchingSquares.GeomPoly geomPoly2 = new MarchingSquares.GeomPoly();
            GeomPolyVal geomPolyVal = new GeomPolyVal(geomPoly1, 1);

            geomPolyVal.GeomP = geomPoly2;
            geomPolyVal.GeomP = null;

            Assert.Null(geomPolyVal.GeomP);
        }
    }
}