using Xunit;

namespace Alis.Core.Physic.Test.Dynamics.Joints
{
    /// <summary>
    /// The prismatic joint test class
    /// </summary>
    public class PrismaticJointTest
    {
        /// <summary>
        /// Tests that prismatic joint type should be accessible
        /// </summary>
        [Fact]
        public void PrismaticJoint_TypeShouldBeAccessible()
        {
            Assert.NotNull(typeof(global::Alis.Core.Physic.Dynamics.Joints.PrismaticJoint));
        }
    }
}

