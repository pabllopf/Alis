using Xunit;

namespace Alis.Core.Physic.Test.Dynamics.Joints
{
    public class WeldJointTest
    {
        [Fact]
        public void WeldJoint_TypeShouldBeAccessible()
        {
            Assert.NotNull(typeof(global::Alis.Core.Physic.Dynamics.Joints.WeldJoint));
        }
    }
}

