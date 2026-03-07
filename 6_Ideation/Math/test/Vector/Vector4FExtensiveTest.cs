using Alis.Core.Aspect.Math.Vector;
using Xunit;

namespace Alis.Core.Aspect.Math.Test.Vector
{
    /// <summary>
    /// Extensive unit tests for Vector4F struct.
    /// Tests all operators, methods, properties, and edge cases.
    /// </summary>
    public class Vector4FExtensiveTest
    {
        

        

        /// <summary>
        /// Tests that constructor four values sets all components correctly
        /// </summary>
        [Fact]
        public void Constructor_FourValues_SetsAllComponentsCorrectly()
        {
            Vector4F vector = new Vector4F(1.0f, 2.0f, 3.0f, 4.0f);
            Assert.Equal(1.0f, vector.X);
            Assert.Equal(2.0f, vector.Y);
            Assert.Equal(3.0f, vector.Z);
            Assert.Equal(4.0f, vector.W);
        }

        /// <summary>
        /// Tests that constructor default creates zero vector
        /// </summary>
        [Fact]
        public void Constructor_Default_CreatesZeroVector()
        {
            Vector4F vector = default;
            Assert.Equal(0.0f, vector.X);
            Assert.Equal(0.0f, vector.Y);
            Assert.Equal(0.0f, vector.Z);
            Assert.Equal(0.0f, vector.W);
        }

        
        
        
    }
}

