using Alis.Core.Physic.Common.Decomposition.CDT;
using Xunit;

namespace Alis.Core.Physic.Test.Common.Decomposition.CDT
{
    /// <summary>
    /// The triangulation util remaining coverage tests class
    /// </summary>
    public class TriangulationUtilRemainingCoverageTests
    {
        /// <summary>
        /// Tests that smart incircle oabd negative returns false
        /// </summary>
        [Fact]
        public void SmartIncircle_OabdNegative_ReturnsFalse()
        {
            TriangulationPoint pa = new TriangulationPoint(0.0, 1.0);
            TriangulationPoint pb = new TriangulationPoint(1.0, 0.0);
            TriangulationPoint pc = new TriangulationPoint(0.0, 0.0);
            TriangulationPoint pd = new TriangulationPoint(0.0, 0.0);

            bool result = TriangulationUtil.SmartIncircle(pa, pb, pc, pd);

            Assert.False(result);
        }

        /// <summary>
        /// Tests that smart incircle oabd zero returns false
        /// </summary>
        [Fact]
        public void SmartIncircle_OabdZero_ReturnsFalse()
        {
            TriangulationPoint pa = new TriangulationPoint(1.0, 0.0);
            TriangulationPoint pb = new TriangulationPoint(2.0, 0.0);
            TriangulationPoint pc = new TriangulationPoint(0.0, 1.0);
            TriangulationPoint pd = new TriangulationPoint(0.0, 0.0);

            bool result = TriangulationUtil.SmartIncircle(pa, pb, pc, pd);

            Assert.False(result);
        }

        /// <summary>
        /// Tests that smart incircle ocad zero returns false
        /// </summary>
        [Fact]
        public void SmartIncircle_OcadZero_ReturnsFalse()
        {
            TriangulationPoint pa = new TriangulationPoint(2.0, 1.0);
            TriangulationPoint pb = new TriangulationPoint(5.0, 3.0);
            TriangulationPoint pc = new TriangulationPoint(4.0, 2.0);
            TriangulationPoint pd = new TriangulationPoint(0.0, 0.0);

            bool result = TriangulationUtil.SmartIncircle(pa, pb, pc, pd);

            Assert.False(result);
        }

        /// <summary>
        /// Tests that smart incircle det zero returns false
        /// </summary>
        [Fact]
        public void SmartIncircle_DetZero_ReturnsFalse()
        {
            TriangulationPoint pa = new TriangulationPoint(0.0, 0.0);
            TriangulationPoint pb = new TriangulationPoint(2.0, 0.0);
            TriangulationPoint pc = new TriangulationPoint(1.0, 2.0);
            TriangulationPoint pd = new TriangulationPoint(2.0, 1.5);

            bool result = TriangulationUtil.SmartIncircle(pa, pb, pc, pd);

            Assert.False(result);
        }

        /// <summary>
        /// Tests that in scan area oadb at negative epsilon boundary returns false
        /// </summary>
        [Fact]
        public void InScanArea_OadbAtNegativeEpsilonBoundary_ReturnsFalse()
        {
            double eps = TriangulationUtil.Epsilon;
            TriangulationPoint pa = new TriangulationPoint(1.0, 0.0);
            TriangulationPoint pb = new TriangulationPoint(0.0, 0.0);
            TriangulationPoint pc = new TriangulationPoint(0.0, 1.0);
            TriangulationPoint pd = new TriangulationPoint(0.0, -eps);

            bool result = TriangulationUtil.InScanArea(pa, pb, pc, pd);

            Assert.False(result);
        }

        /// <summary>
        /// Tests that in scan area oadc at epsilon boundary oadb passes returns false
        /// </summary>
        [Fact]
        public void InScanArea_OadcAtEpsilonBoundary_OadbPasses_ReturnsFalse()
        {
            double eps = TriangulationUtil.Epsilon;
            TriangulationPoint pa = new TriangulationPoint(0.0, 1.0);
            TriangulationPoint pb = new TriangulationPoint(0.0, 0.0);
            TriangulationPoint pc = new TriangulationPoint(0.5, 0.5 + eps);
            TriangulationPoint pd = new TriangulationPoint(1.0, 0.0);

            bool result = TriangulationUtil.InScanArea(pa, pb, pc, pd);

            Assert.False(result);
        }

        /// <summary>
        /// Tests that orient 2d val at epsilon returns ccw
        /// </summary>
        [Fact]
        public void Orient2d_ValAtEpsilon_ReturnsCcw()
        {
            TriangulationPoint pa = new TriangulationPoint(0.0, 0.0);
            TriangulationPoint pb = new TriangulationPoint(1.0, 0.0);
            TriangulationPoint pc = new TriangulationPoint(1.0, TriangulationUtil.Epsilon);

            Orientation result = TriangulationUtil.Orient2d(pa, pb, pc);

            Assert.Equal(Orientation.Ccw, result);
        }

        /// <summary>
        /// Tests that orient 2d val at negative epsilon returns cw
        /// </summary>
        [Fact]
        public void Orient2d_ValAtNegativeEpsilon_ReturnsCw()
        {
            TriangulationPoint pa = new TriangulationPoint(0.0, 0.0);
            TriangulationPoint pb = new TriangulationPoint(1.0, 0.0);
            TriangulationPoint pc = new TriangulationPoint(1.0, -TriangulationUtil.Epsilon);

            Orientation result = TriangulationUtil.Orient2d(pa, pb, pc);

            Assert.Equal(Orientation.Cw, result);
        }

        /// <summary>
        /// Tests that orient 2d val half epsilon returns collinear
        /// </summary>
        [Fact]
        public void Orient2d_ValHalfEpsilon_ReturnsCollinear()
        {
            TriangulationPoint pa = new TriangulationPoint(0.0, 0.0);
            TriangulationPoint pb = new TriangulationPoint(1.0, 0.0);
            TriangulationPoint pc = new TriangulationPoint(1.0, TriangulationUtil.Epsilon / 2);

            Orientation result = TriangulationUtil.Orient2d(pa, pb, pc);

            Assert.Equal(Orientation.Collinear, result);
        }

        /// <summary>
        /// Tests that orient 2d val half negative epsilon returns collinear
        /// </summary>
        [Fact]
        public void Orient2d_ValHalfNegativeEpsilon_ReturnsCollinear()
        {
            TriangulationPoint pa = new TriangulationPoint(0.0, 0.0);
            TriangulationPoint pb = new TriangulationPoint(1.0, 0.0);
            TriangulationPoint pc = new TriangulationPoint(1.0, -TriangulationUtil.Epsilon / 2);

            Orientation result = TriangulationUtil.Orient2d(pa, pb, pc);

            Assert.Equal(Orientation.Collinear, result);
        }

        /// <summary>
        /// Tests that orient 2d val just above epsilon returns ccw
        /// </summary>
        [Fact]
        public void Orient2d_ValJustAboveEpsilon_ReturnsCcw()
        {
            TriangulationPoint pa = new TriangulationPoint(0.0, 0.0);
            TriangulationPoint pb = new TriangulationPoint(1.0, 0.0);
            TriangulationPoint pc = new TriangulationPoint(1.0, TriangulationUtil.Epsilon * 2);

            Orientation result = TriangulationUtil.Orient2d(pa, pb, pc);

            Assert.Equal(Orientation.Ccw, result);
        }

        /// <summary>
        /// Tests that orient 2d val just below negative epsilon returns cw
        /// </summary>
        [Fact]
        public void Orient2d_ValJustBelowNegativeEpsilon_ReturnsCw()
        {
            TriangulationPoint pa = new TriangulationPoint(0.0, 0.0);
            TriangulationPoint pb = new TriangulationPoint(1.0, 0.0);
            TriangulationPoint pc = new TriangulationPoint(1.0, -TriangulationUtil.Epsilon * 2);

            Orientation result = TriangulationUtil.Orient2d(pa, pb, pc);

            Assert.Equal(Orientation.Cw, result);
        }
    }
}
