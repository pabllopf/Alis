using Xunit;

namespace Alis.Core.Physic.Test.Dynamics.Joints
{
    /// <summary>
    /// The distance joint test class
    /// </summary>
    public class DistanceJointTest
    {
        /// <summary>
        /// Tests that distance joint type should be accessible
        /// </summary>
        [Fact]
        public void DistanceJoint_TypeShouldBeAccessible()
        {
            Assert.NotNull(typeof(global::Alis.Core.Physic.Dynamics.Joints.DistanceJoint));
        }
    }
}

