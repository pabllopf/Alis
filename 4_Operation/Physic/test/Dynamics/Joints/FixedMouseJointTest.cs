using Xunit;

namespace Alis.Core.Physic.Test.Dynamics.Joints
{
    public class FixedMouseJointTest
    {
        [Fact]
        public void FixedMouseJoint_TypeShouldBeAccessible()
        {
            Assert.NotNull(typeof(global::Alis.Core.Physic.Dynamics.Joints.FixedMouseJoint));
        }
    }
}

