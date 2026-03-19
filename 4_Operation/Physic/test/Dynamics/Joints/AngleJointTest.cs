using Xunit;

namespace Alis.Core.Physic.Test.Dynamics.Joints
{
    public class AngleJointTest
    {
        [Fact]
        public void AngleJoint_TypeShouldBeAccessible()
        {
            Assert.NotNull(typeof(global::Alis.Core.Physic.Dynamics.Joints.AngleJoint));
        }
    }
}

