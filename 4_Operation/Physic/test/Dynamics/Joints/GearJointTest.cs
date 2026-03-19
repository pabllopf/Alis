using Xunit;

namespace Alis.Core.Physic.Test.Dynamics.Joints
{
    /// <summary>
    /// The gear joint test class
    /// </summary>
    public class GearJointTest
    {
        /// <summary>
        /// Tests that gear joint type should be accessible
        /// </summary>
        [Fact]
        public void GearJoint_TypeShouldBeAccessible()
        {
            Assert.NotNull(typeof(global::Alis.Core.Physic.Dynamics.Joints.GearJoint));
        }
    }
}

