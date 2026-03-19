using Xunit;

namespace Alis.Core.Physic.Test.Dynamics.Joints
{
    public class FrictionJointTest
    {
        [Fact]
        public void FrictionJoint_TypeShouldBeAccessible()
        {
            Assert.NotNull(typeof(global::Alis.Core.Physic.Dynamics.Joints.FrictionJoint));
        }
    }
}

