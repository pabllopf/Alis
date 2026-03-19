using Xunit;

namespace Alis.Core.Physic.Test.Dynamics.Joints
{
    public class MotorJointTest
    {
        [Fact]
        public void MotorJoint_TypeShouldBeAccessible()
        {
            Assert.NotNull(typeof(global::Alis.Core.Physic.Dynamics.Joints.MotorJoint));
        }
    }
}

