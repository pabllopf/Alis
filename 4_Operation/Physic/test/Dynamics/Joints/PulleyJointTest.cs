using Xunit;

namespace Alis.Core.Physic.Test.Dynamics.Joints
{
    /// <summary>
    /// The pulley joint test class
    /// </summary>
    public class PulleyJointTest
    {
        /// <summary>
        /// Tests that pulley joint type should be accessible
        /// </summary>
        [Fact]
        public void PulleyJoint_TypeShouldBeAccessible()
        {
            Assert.NotNull(typeof(global::Alis.Core.Physic.Dynamics.Joints.PulleyJoint));
        }
    }
}

