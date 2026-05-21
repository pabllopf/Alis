

using Alis.Core.Physic.Collisions;
using Xunit;

namespace Alis.Core.Physic.Test.Collisions
{
    /// <summary>
    ///     The contact feature type test class
    /// </summary>
    public class ContactFeatureTypeTest
    {
        /// <summary>
        ///     Tests that vertex should have value zero
        /// </summary>
        [Fact]
        public void Vertex_ShouldHaveValueZero()
        {
            byte value = 0;
            Assert.Equal(value, (byte) ContactFeatureType.Vertex);
        }

        /// <summary>
        ///     Tests that face should have value one
        /// </summary>
        [Fact]
        public void Face_ShouldHaveValueOne()
        {
            byte value = 1;
            Assert.Equal(value, (byte) ContactFeatureType.Face);
        }

        /// <summary>
        ///     Tests that all values should be unique
        /// </summary>
        [Fact]
        public void AllValues_ShouldBeUnique()
        {
            Assert.NotEqual(ContactFeatureType.Vertex, ContactFeatureType.Face);
        }
    }
}