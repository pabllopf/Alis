using Xunit;

namespace Alis.Core.Physic.Test.Dynamics.Joints
{
    public class PrismaticJointTest
    {
        [Fact]
        public void PrismaticJoint_TypeShouldBeAccessible()
        {
            Assert.NotNull(typeof(global::Alis.Core.Physic.Dynamics.Joints.PrismaticJoint));
        }
    }
}

