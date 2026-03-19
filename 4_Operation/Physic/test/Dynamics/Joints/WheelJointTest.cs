using Xunit;

namespace Alis.Core.Physic.Test.Dynamics.Joints
{
    public class WheelJointTest
    {
        [Fact]
        public void WheelJoint_TypeShouldBeAccessible()
        {
            Assert.NotNull(typeof(global::Alis.Core.Physic.Dynamics.Joints.WheelJoint));
        }
    }
}

