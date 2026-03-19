using Xunit;

namespace Alis.Core.Physic.Test.Dynamics.Joints
{
    /// <summary>
    /// The weld joint test class
    /// </summary>
    public class WeldJointTest
    {
        /// <summary>
        /// Tests that weld joint type should be accessible
        /// </summary>
        [Fact]
        public void WeldJoint_TypeShouldBeAccessible()
        {
            Assert.NotNull(typeof(global::Alis.Core.Physic.Dynamics.Joints.WeldJoint));
        }
    }
}

