using Xunit;

namespace Alis.Core.Physic.Test.Dynamics.Joints
{
    /// <summary>
    /// The motor joint test class
    /// </summary>
    public class MotorJointTest
    {
        /// <summary>
        /// Tests that motor joint type should be accessible
        /// </summary>
        [Fact]
        public void MotorJoint_TypeShouldBeAccessible()
        {
            Assert.NotNull(typeof(global::Alis.Core.Physic.Dynamics.Joints.MotorJoint));
        }
    }
}

