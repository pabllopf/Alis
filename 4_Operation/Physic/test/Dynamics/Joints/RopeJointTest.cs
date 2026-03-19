using Xunit;

namespace Alis.Core.Physic.Test.Dynamics.Joints
{
    /// <summary>
    /// The rope joint test class
    /// </summary>
    public class RopeJointTest
    {
        /// <summary>
        /// Tests that rope joint type should be accessible
        /// </summary>
        [Fact]
        public void RopeJoint_TypeShouldBeAccessible()
        {
            Assert.NotNull(typeof(global::Alis.Core.Physic.Dynamics.Joints.RopeJoint));
        }
    }
}

