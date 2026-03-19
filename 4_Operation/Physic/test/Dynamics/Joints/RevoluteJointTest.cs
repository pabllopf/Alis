using Xunit;

namespace Alis.Core.Physic.Test.Dynamics.Joints
{
    /// <summary>
    /// The revolute joint test class
    /// </summary>
    public class RevoluteJointTest
    {
        /// <summary>
        /// Tests that revolute joint type should be accessible
        /// </summary>
        [Fact]
        public void RevoluteJoint_TypeShouldBeAccessible()
        {
            Assert.NotNull(typeof(global::Alis.Core.Physic.Dynamics.Joints.RevoluteJoint));
        }
    }
}

