using Alis.Core.Aspect.Math.Shapes.Point;
using Xunit;

namespace Alis.Core.Aspect.Math.Test.Shape
{
    /// <summary>
    /// Comprehensive unit tests for PointI struct.
    /// Tests all operations on integer points.
    /// </summary>
    public class PointIExtensiveTest
    {
        
        


        
        /// <summary>
        /// Tests that constructor default creates zero point
        /// </summary>
        [Fact]
        public void Constructor_Default_CreatesZeroPoint()
        {
            var point = default(PointI);
            Assert.Equal(0, point.X);
            Assert.Equal(0, point.Y);
        }

        
        
        
    }
}
