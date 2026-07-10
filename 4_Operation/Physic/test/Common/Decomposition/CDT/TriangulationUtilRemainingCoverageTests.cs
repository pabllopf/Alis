using Alis.Core.Physic.Common.Decomposition.CDT;
using Xunit;

namespace Alis.Core.Physic.Test.Common.Decomposition.CDT
{
    public class TriangulationUtilRemainingCoverageTests
    {
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

        [Fact]
        public void Orient2d_ValAtEpsilon_ReturnsCcw()
        {
            TriangulationPoint pa = new TriangulationPoint(0.0, 0.0);
            TriangulationPoint pb = new TriangulationPoint(1.0, 0.0);
            TriangulationPoint pc = new TriangulationPoint(1.0, TriangulationUtil.Epsilon);

            Orientation result = TriangulationUtil.Orient2d(pa, pb, pc);

            Assert.Equal(Orientation.Ccw, result);
        }

        [Fact]
        public void Orient2d_ValAtNegativeEpsilon_ReturnsCw()
        {
            TriangulationPoint pa = new TriangulationPoint(0.0, 0.0);
            TriangulationPoint pb = new TriangulationPoint(1.0, 0.0);
            TriangulationPoint pc = new TriangulationPoint(1.0, -TriangulationUtil.Epsilon);

            Orientation result = TriangulationUtil.Orient2d(pa, pb, pc);

            Assert.Equal(Orientation.Cw, result);
        }

        [Fact]
        public void Orient2d_ValHalfEpsilon_ReturnsCollinear()
        {
            TriangulationPoint pa = new TriangulationPoint(0.0, 0.0);
            TriangulationPoint pb = new TriangulationPoint(1.0, 0.0);
            TriangulationPoint pc = new TriangulationPoint(1.0, TriangulationUtil.Epsilon / 2);

            Orientation result = TriangulationUtil.Orient2d(pa, pb, pc);

            Assert.Equal(Orientation.Collinear, result);
        }

        [Fact]
        public void Orient2d_ValHalfNegativeEpsilon_ReturnsCollinear()
        {
            TriangulationPoint pa = new TriangulationPoint(0.0, 0.0);
            TriangulationPoint pb = new TriangulationPoint(1.0, 0.0);
            TriangulationPoint pc = new TriangulationPoint(1.0, -TriangulationUtil.Epsilon / 2);

            Orientation result = TriangulationUtil.Orient2d(pa, pb, pc);

            Assert.Equal(Orientation.Collinear, result);
        }

        [Fact]
        public void Orient2d_ValJustAboveEpsilon_ReturnsCcw()
        {
            TriangulationPoint pa = new TriangulationPoint(0.0, 0.0);
            TriangulationPoint pb = new TriangulationPoint(1.0, 0.0);
            TriangulationPoint pc = new TriangulationPoint(1.0, TriangulationUtil.Epsilon * 2);

            Orientation result = TriangulationUtil.Orient2d(pa, pb, pc);

            Assert.Equal(Orientation.Ccw, result);
        }

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
