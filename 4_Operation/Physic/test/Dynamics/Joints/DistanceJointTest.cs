using Xunit;

namespace Alis.Core.Physic.Test.Dynamics.Joints
{
    public class DistanceJointTest
    {
        [Fact]
        public void DistanceJoint_TypeShouldBeAccessible()
        {
            Assert.NotNull(typeof(global::Alis.Core.Physic.Dynamics.Joints.DistanceJoint));
        }
    }
}

