using Xunit;

namespace Alis.Core.Physic.Test.Dynamics.Joints
{
    /// <summary>
    /// The wheel joint test class
    /// </summary>
    public class WheelJointTest
    {
        /// <summary>
        /// Tests that wheel joint type should be accessible
        /// </summary>
        [Fact]
        public void WheelJoint_TypeShouldBeAccessible()
        {
            Assert.NotNull(typeof(global::Alis.Core.Physic.Dynamics.Joints.WheelJoint));
        }
    }
}

