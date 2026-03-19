using Xunit;

namespace Alis.Core.Physic.Test.Dynamics.Joints
{
    public class GearJointTest
    {
        [Fact]
        public void GearJoint_TypeShouldBeAccessible()
        {
            Assert.NotNull(typeof(global::Alis.Core.Physic.Dynamics.Joints.GearJoint));
        }
    }
}

