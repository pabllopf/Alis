using Xunit;

namespace Alis.Core.Physic.Test.Dynamics.Joints
{
    public class RopeJointTest
    {
        [Fact]
        public void RopeJoint_TypeShouldBeAccessible()
        {
            Assert.NotNull(typeof(global::Alis.Core.Physic.Dynamics.Joints.RopeJoint));
        }
    }
}

