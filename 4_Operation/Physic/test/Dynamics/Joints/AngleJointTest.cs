using Xunit;

namespace Alis.Core.Physic.Test.Dynamics.Joints
{
    /// <summary>
    /// The angle joint test class
    /// </summary>
    public class AngleJointTest
    {
        /// <summary>
        /// Tests that angle joint type should be accessible
        /// </summary>
        [Fact]
        public void AngleJoint_TypeShouldBeAccessible()
        {
            Assert.NotNull(typeof(global::Alis.Core.Physic.Dynamics.Joints.AngleJoint));
        }
    }
}

