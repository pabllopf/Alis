using Xunit;

namespace Alis.Core.Physic.Test.Dynamics.Joints
{
    public class RevoluteJointTest
    {
        [Fact]
        public void RevoluteJoint_TypeShouldBeAccessible()
        {
            Assert.NotNull(typeof(global::Alis.Core.Physic.Dynamics.Joints.RevoluteJoint));
        }
    }
}

