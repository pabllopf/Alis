

using Alis.Core.Physic.Collisions;
using Xunit;

namespace Alis.Core.Physic.Test.Collisions
{
    /// <summary>
    ///     The contact feature test class
    /// </summary>
    public class ContactFeatureTest
    {
        /// <summary>
        ///     Tests that default constructor should initialize with zero values
        /// </summary>
        [Fact]
        public void DefaultConstructor_ShouldInitializeWithZeroValues()
        {
            ContactFeature feature = new ContactFeature();

            Assert.Equal(0, feature.IndexA);
            Assert.Equal(0, feature.IndexB);
            Assert.Equal(0, feature.TypeA);
            Assert.Equal(0, feature.TypeB);
        }

        /// <summary>
        ///     Tests that index a property should set and get correctly
        /// </summary>
        [Fact]
        public void IndexAProperty_ShouldSetAndGetCorrectly()
        {
            ContactFeature feature = new ContactFeature
            {
                IndexA = 5
            };

            Assert.Equal(5, feature.IndexA);
        }

        /// <summary>
        ///     Tests that index b property should set and get correctly
        /// </summary>
        [Fact]
        public void IndexBProperty_ShouldSetAndGetCorrectly()
        {
            ContactFeature feature = new ContactFeature
            {
                IndexB = 7
            };

            Assert.Equal(7, feature.IndexB);
        }

        /// <summary>
        ///     Tests that type a property should set and get correctly
        /// </summary>
        [Fact]
        public void TypeAProperty_ShouldSetAndGetCorrectly()
        {
            ContactFeature feature = new ContactFeature
            {
                TypeA = 1
            };

            Assert.Equal(1, feature.TypeA);
        }

        /// <summary>
        ///     Tests that type b property should set and get correctly
        /// </summary>
        [Fact]
        public void TypeBProperty_ShouldSetAndGetCorrectly()
        {
            ContactFeature feature = new ContactFeature
            {
                TypeB = 2
            };

            Assert.Equal(2, feature.TypeB);
        }

        /// <summary>
        ///     Tests that contact feature should support max byte values
        /// </summary>
        [Fact]
        public void ContactFeature_ShouldSupportMaxByteValues()
        {
            ContactFeature feature = new ContactFeature
            {
                IndexA = byte.MaxValue,
                IndexB = byte.MaxValue,
                TypeA = byte.MaxValue,
                TypeB = byte.MaxValue
            };

            Assert.Equal(byte.MaxValue, feature.IndexA);
            Assert.Equal(byte.MaxValue, feature.IndexB);
            Assert.Equal(byte.MaxValue, feature.TypeA);
            Assert.Equal(byte.MaxValue, feature.TypeB);
        }

        /// <summary>
        ///     Tests that contact feature should be value type
        /// </summary>
        [Fact]
        public void ContactFeature_ShouldBeValueType()
        {
            ContactFeature feature1 = new ContactFeature {IndexA = 1, IndexB = 2};
            ContactFeature feature2 = feature1;

            feature2.IndexA = 10;

            Assert.NotEqual(feature1.IndexA, feature2.IndexA);
        }

        /// <summary>
        ///     Tests that contact feature should handle all properties independently
        /// </summary>
        [Fact]
        public void ContactFeature_ShouldHandleAllPropertiesIndependently()
        {
            ContactFeature feature = new ContactFeature
            {
                IndexA = 1,
                IndexB = 2,
                TypeA = 3,
                TypeB = 4
            };

            Assert.Equal(1, feature.IndexA);
            Assert.Equal(2, feature.IndexB);
            Assert.Equal(3, feature.TypeA);
            Assert.Equal(4, feature.TypeB);
        }

        /// <summary>
        ///     Tests that contact feature should support vertex and face type values
        /// </summary>
        [Fact]
        public void ContactFeature_ShouldSupportVertexAndFaceTypeValues()
        {
            ContactFeature feature = new ContactFeature
            {
                TypeA = (byte) ContactFeatureType.Vertex,
                TypeB = (byte) ContactFeatureType.Face
            };

            Assert.Equal((byte) ContactFeatureType.Vertex, feature.TypeA);
            Assert.Equal((byte) ContactFeatureType.Face, feature.TypeB);
        }
    }
}