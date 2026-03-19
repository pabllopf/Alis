using Xunit;

namespace Alis.Core.Physic.Test.Dynamics.Joints
{
    /// <summary>
    /// The fixed mouse joint test class
    /// </summary>
    public class FixedMouseJointTest
    {
        /// <summary>
        /// Tests that fixed mouse joint type should be accessible
        /// </summary>
        [Fact]
        public void FixedMouseJoint_TypeShouldBeAccessible()
        {
            Assert.NotNull(typeof(global::Alis.Core.Physic.Dynamics.Joints.FixedMouseJoint));
        }
    }
}

