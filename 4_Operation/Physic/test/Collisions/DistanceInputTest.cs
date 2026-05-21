

using Alis.Core.Physic.Collisions;
using Alis.Core.Physic.Dynamics;
using Xunit;

namespace Alis.Core.Physic.Test.Collisions
{
    /// <summary>
    ///     The distance input test class
    /// </summary>
    public class DistanceInputTest
    {
        /// <summary>
        ///     Tests that constructor should initialize with default values
        /// </summary>
        [Fact]
        public void Constructor_ShouldInitializeWithDefaultValues()
        {
            DistanceInput input = new DistanceInput();

            Assert.False(input.UseRadii);
        }

        /// <summary>
        ///     Tests that use radii should set and get correctly
        /// </summary>
        [Fact]
        public void UseRadii_ShouldSetAndGetCorrectly()
        {
            DistanceInput input = new DistanceInput
            {
                UseRadii = true
            };

            Assert.True(input.UseRadii);
        }

        /// <summary>
        ///     Tests that proxy a should set and get correctly
        /// </summary>
        [Fact]
        public void ProxyA_ShouldSetAndGetCorrectly()
        {
            DistanceInput input = new DistanceInput();
            DistanceProxy proxy = new DistanceProxy();

            input.ProxyA = proxy;

            Assert.Equal(proxy, input.ProxyA);
        }

        /// <summary>
        ///     Tests that proxy b should set and get correctly
        /// </summary>
        [Fact]
        public void ProxyB_ShouldSetAndGetCorrectly()
        {
            DistanceInput input = new DistanceInput();
            DistanceProxy proxy = new DistanceProxy();

            input.ProxyB = proxy;

            Assert.Equal(proxy, input.ProxyB);
        }

        /// <summary>
        ///     Tests that transform a should set and get correctly
        /// </summary>
        [Fact]
        public void TransformA_ShouldSetAndGetCorrectly()
        {
            DistanceInput input = new DistanceInput();
            ControllerTransform transform = ControllerTransform.Identity;

            input.ControllerTransformA = transform;

            Assert.Equal(transform, input.ControllerTransformA);
        }

        /// <summary>
        ///     Tests that transform b should set and get correctly
        /// </summary>
        [Fact]
        public void TransformB_ShouldSetAndGetCorrectly()
        {
            DistanceInput input = new DistanceInput();
            ControllerTransform transform = ControllerTransform.Identity;

            input.ControllerTransformB = transform;

            Assert.Equal(transform, input.ControllerTransformB);
        }

        /// <summary>
        ///     Tests that all properties should set correctly
        /// </summary>
        [Fact]
        public void AllProperties_ShouldSetCorrectly()
        {
            DistanceInput input = new DistanceInput
            {
                ProxyA = new DistanceProxy(),
                ProxyB = new DistanceProxy(),
                ControllerTransformA = ControllerTransform.Identity,
                ControllerTransformB = ControllerTransform.Identity,
                UseRadii = true
            };

            Assert.True(input.UseRadii);
        }
    }
}