using Xunit;

namespace Alis.Core.Physic.Test.Dynamics.Joints
{
    public class PulleyJointTest
    {
        [Fact]
        public void PulleyJoint_TypeShouldBeAccessible()
        {
            Assert.NotNull(typeof(global::Alis.Core.Physic.Dynamics.Joints.PulleyJoint));
        }
    }
}

